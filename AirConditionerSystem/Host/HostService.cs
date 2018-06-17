using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using log4net;
using System.Data.SqlClient;

namespace Host {
	internal delegate void RequestDelegate(Common.Package request);


	internal class HostService : IHostService, IHostServiceCallback {

		//#region Constants
		//private static readonly int HotMaxTemperature = 30;
		//private static readonly int HotMinTemperature = 25;
		//private static readonly int HotTemperatureDefault = 28;

		//private static readonly int ColdMaxTemperature = 25;
		//private static readonly int ColdMinTemperature = 18;
		//private static readonly int ColdTemperatureDefault = 22;

		//private static readonly double MidSpeedPower = 1.0;
		//private static readonly double LowSpeedPower = 0.8;
		//private static readonly double HighSpeedPower = 1.3;
		//private static readonly int CostPrePower = 5;
		//#endregion

		private HostServiceStatus hostState;
		private INetWork netWork;
		private ILog LOGGER;
		private IDictionary<Byte, RemoteClient> clients;
		//private IDictionary<Byte, >
		private System.Timers.Timer clientHeartBeatChecker;

		private SQLConnector sql;

		public HostService() {
			LOGGER = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
			netWork = new Network(this);
			clients = new ConcurrentDictionary<Byte, RemoteClient>();
			sql = new SQLConnector();
			hostState = new HostServiceStatus();

			clientHeartBeatChecker = new System.Timers.Timer(5000);
			clientHeartBeatChecker.AutoReset = true;
			clientHeartBeatChecker.Elapsed += this.checkClientAlive;
			//clientHeartBeatChecker.Enabled = true;
		}

		public void ShutDown() {
			if (hostState.State == (int)ServiceState.OFF)
				throw new Exception("AirConditioner is already off!");
			netWork.StopListen();
			hostState.State = (int)ServiceState.OFF;
			LOGGER.Info("AirConditioner Turn Off!");
		}

		private void Init() {
			clients.Clear();
			hostState.State = (int)ServiceState.OFF;
			hostState.Mode = (int)ServiceMode.COLD;
			hostState.NowServiceAmount = 0;
			hostState.RefreshFrequency = 1;
			hostState.Stage = (int)ServiceStage.RoundRobin;
			LOGGER.Info("State init! " + hostState.ToString());
		}

		public Tuple<int, float> GetDefaultWorkingState() {
			return new Tuple<int, float>
				(hostState.Mode,
				hostState.Mode == (int)ServiceMode.COLD ?
				Common.Constants.ColdTemperatureDefault :
				Common.Constants.HotTemperatureDefault);
		}

		public void TurnOn() {
			if (hostState.State != (int)ServiceState.OFF)
				throw new Exception("AirConditioner is already on!");
			Init();
			hostState.State = (int)ServiceState.Sleep;
			netWork.StartListen();
			LOGGER.Info("AirConditioner Turn On!");
		}

		public bool Login(byte roomNumber, string idNum, out float cost) {
			using (SqlConnection con = new SqlConnection(sql.Builder.ConnectionString)) {
				con.Open();
				SqlCommand cmd = con.CreateCommand();
				cmd.CommandText = "select * from dt_RoomIDCard where RoomNum = @a and IDCardNum = @b";
				cmd.Parameters.Clear();
				cmd.Parameters.AddWithValue("@a", roomNumber);
				cmd.Parameters.AddWithValue("@b", idNum);

				SqlDataReader dr = cmd.ExecuteReader();
				if (dr.HasRows) {
					dr.Read();
					cost = (float)dr.GetDouble(2);
					if (dr.Read()) throw new Exception(String.Format("have two same row [{0},{1}] in DB!", roomNumber, idNum));
					return true;
				} else {
					cost = 0;
					return false;
				}
			}
		}

		public Common.Package ChangeMode() {
			//return new HostModeResponse((int)this.hostState.mode, GetTemperatureDefault());
			throw new NotImplementedException();
		}

		public void AddClient(RemoteClient remoteClient) {
			clients[remoteClient.ClientNum] = remoteClient;
		}

		public void CloseClient(byte clientNum) {
			clients.Remove(clientNum);
			LOGGER.InfoFormat("Remove client {0} from dictionary!", clientNum);
		}

		public void ReceiveClientHeartBeat(byte clientNum) {
			throw new NotImplementedException();
		}

		public void SetTargetTemperature(byte clientNum, float temperature) {
			clients[clientNum].SetTargetTemperature(temperature);
		}

		public bool SettModle(ServiceMode mode) {
			if ((int)mode == hostState.Mode) {
				LOGGER.WarnFormat("Cannot set to the same mode as before:{0}!", mode.ToString());
				return false;
			}
			void body(RemoteClient client) { client.ChangeMode(this); }
			Parallel.ForEach<RemoteClient>(clients.Values, body);
			LOGGER.InfoFormat("Finish send change mode package to each clients total:{0}!", clients.Count);
			return true;
		}

		private void checkClientAlive(object source, System.Timers.ElapsedEventArgs e) {
			void body(KeyValuePair<byte, RemoteClient> clientAndId) {
				if (DateTime.Now - clientAndId.Value.ClientStatus.LastHeartBeat > TimeSpan.FromSeconds(20)) {
					clients.Remove(clientAndId.Key);
					LOGGER.WarnFormat("Client {0} timeout, removed!", clientAndId.Key);
					clientAndId.Value.Abort();
				}
			}
			Parallel.ForEach(clients, body);
			LOGGER.Debug("Check clients finish!");
		}

		public void SendWind(byte id) {
			if (clients[id].ClientStatus.Speed <= (int)ESpeed.NoWind) return;
			lock (this) {
				if (this.hostState.NowServiceAmount < 3) {
					this.hostState.NowServiceAmount++;
					clients[id].ResetRealSpeed();
					LOGGER.InfoFormat("Scheduler send wind to client {0}", (int)id);
				} else {
					LOGGER.InfoFormat("Client {0} send wind request failed for host is full!", (int)id);
				}
			}
		}
		public void StopWind(byte id) {
			if (clients[id].ClientStatus.Speed <= (int)ESpeed.NoWind) return;
			lock (this) {
				this.hostState.NowServiceAmount--;
				clients[id].ClientStatus.Speed = (int)ESpeed.NoWind;
				LOGGER.InfoFormat("Scheduler stop wind to client {0}", (int)id);
				foreach (var client in clients) {
					if (client.Key > id && client.Value.CanWind()) {
						client.Value.ResetRealSpeed();
						LOGGER.InfoFormat("Scheduler send wind to client {0}", (int)id);
						this.hostState.NowServiceAmount++;
						if (this.hostState.NowServiceAmount == 3) return;
					}
				}
				foreach (var client in clients) {
					if (client.Key <= id && client.Value.CanWind()) {
						client.Value.ResetRealSpeed();
						LOGGER.InfoFormat("Scheduler send wind to client {0}", (int)id);
						this.hostState.NowServiceAmount++;
						if (this.hostState.NowServiceAmount == 3) return;
					}
				}
			}
		}

		public void RefreshFrequency(byte f) {
			this.hostState.RefreshFrequency = f;
			void body(RemoteClient client) { client.ChangeMode(this); }
			Parallel.ForEach<RemoteClient>(clients.Values, body);
			LOGGER.InfoFormat("Finish send change frequency package to each clients total:{0}!", clients.Count);
		}

		public bool Regist(byte roomId, string Id) {
			using (SqlConnection con = new SqlConnection(sql.Builder.ConnectionString)) {
				con.Open();
				SqlCommand cmd = con.CreateCommand();
				cmd.CommandText = "update dt_RoomIDCard set IDCardNum = @b,cost = 0.0 where RoomNum = @a";
				cmd.Parameters.Clear();
				cmd.Parameters.AddWithValue("@a", (int)roomId);
				cmd.Parameters.AddWithValue("@b", Id);

				int ln = cmd.ExecuteNonQuery();

				if (ln == 1) return true;
				else return false;
			}
		}

		public bool UnRegist(byte roomId) {
			using (SqlConnection con = new SqlConnection(sql.Builder.ConnectionString)) {
				con.Open();
				SqlCommand cmd = con.CreateCommand();
				cmd.CommandText = "update dt_RoomIDCard set IDCardNum = null,cost = 0.0 where RoomNum = @a";
				cmd.Parameters.Clear();
				cmd.Parameters.AddWithValue("@a", (int)roomId);

				int ln = cmd.ExecuteNonQuery();

				if (ln == 1) return true;
				else return false;
			}
		}

		public bool CheckOut(byte roomId) {
			using (SqlConnection con = new SqlConnection(sql.Builder.ConnectionString)) {
				con.Open();
				SqlCommand cmd = con.CreateCommand();
				cmd.CommandText = "update dt_RoomIDCard set cost = 0.0 where RoomNum = @a";
				cmd.Parameters.Clear();
				cmd.Parameters.AddWithValue("@a", (int)roomId);

				int ln = cmd.ExecuteNonQuery();

				if (ln == 1) return true;
				else return false;
			}
		}

		public IList<ClientStatus> GetClientStatus(out int waiting) {
			IList<ClientStatus> clientStatuses = new List<ClientStatus>();
			foreach (RemoteClient client in clients.Values) {
				if (client.ClientStatus.RealSpeed >= (int)ESpeed.Small) {
					clientStatuses.Add(client.ClientStatus.Clone());
				}
			}
			waiting = clients.Count - clientStatuses.Count;
			return clientStatuses;
		}
	}
}
