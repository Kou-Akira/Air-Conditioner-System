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
		private HostServiceStatus hostState;
		private INetWork netWork;
		private ILog LOGGER;
		private IDictionary<Byte, RemoteClient> clients;
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

		public bool ShutDown() {
			if (hostState.State == (int)ServiceState.OFF)
				throw new Exception("AirConditioner is already off!");
			if (clients.Count != 0) return false;
			netWork.StopListen();
			hostState.State = (int)ServiceState.OFF;
			LOGGER.Info("AirConditioner Turn Off!");
			return true;
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

		public void RemoveClient(byte clientNum) {
			clients.Remove(clientNum);
			LOGGER.InfoFormat("Remove client {0} from dictionary!", clientNum);
		}

		public bool SettModle(ServiceMode mode) {
			if ((int)mode == hostState.Mode) {
				LOGGER.WarnFormat("Cannot set to the same mode as before:{0}!", mode.ToString());
				return false;
			}
			this.hostState.Mode = (int)mode;
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

		public bool SendWind(byte id) {
			if (clients[id].ClientStatus.Speed <= (int)ESpeed.NoWind) return false;
			lock (this) {
				if (this.hostState.NowServiceAmount < 3) {
					this.hostState.NowServiceAmount++;
					clients[id].ResetRealSpeed();
					LOGGER.InfoFormat("Scheduler send wind to client {0}", (int)id);
					return true;
				} else {
					LOGGER.InfoFormat("Client {0} send wind request failed for host is full!", (int)id);
					return false;
				}
			}
		}

		public void StopWind(byte id) {
			lock (this) {
				this.hostState.NowServiceAmount--;
				clients[id].ClientStatus.RealSpeed = (int)ESpeed.NoWind;
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

				if (ln == 1) {
					LOGGER.InfoFormat("Regist success! room:{0}, user:{1}", roomId, Id);
					return true;
				} else return false;
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

		public IDictionary<byte, ClientStatus> GetClientStatus(out int waiting) {
			IDictionary<byte, ClientStatus> clientStatuses = new Dictionary<byte, ClientStatus>();
			foreach (KeyValuePair<byte, RemoteClient> client in clients) {
				if (client.Value.ClientStatus.RealSpeed >= (int)ESpeed.Small) {
					clientStatuses.Add(client.Key, client.Value.ClientStatus.Clone());
				}
			}
			waiting = clients.Count - clientStatuses.Count;
			return clientStatuses;
		}

		public IDictionary<byte, List<HostLog>> GetLog(DateTime start, DateTime end) {
			using (SqlConnection con = new SqlConnection(sql.Builder.ConnectionString)) {
				con.Open();
				SqlCommand cmd = con.CreateCommand();
				cmd.CommandText = "select * from dt_Log where Time between @a and @b order by Time";
				cmd.Parameters.Clear();
				cmd.Parameters.AddWithValue("@a", start);
				cmd.Parameters.AddWithValue("@b", end);

				SqlDataReader reader = cmd.ExecuteReader();
				IDictionary<byte, List<HostLog>> dic = new Dictionary<byte, List<HostLog>>();
				while (reader.HasRows && reader.Read()) {
					var v = new HostLog(reader);
					if (!dic.ContainsKey(v.RoomNum)) dic[v.RoomNum] = new List<HostLog>();
					dic[v.RoomNum].Add(v);
				}
				return dic;
			}
		}
	}
}
