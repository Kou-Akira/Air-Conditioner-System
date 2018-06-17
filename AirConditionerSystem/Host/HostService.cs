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


	class HostService : IHostService, IHostServiceCallback {

		#region Constants
		private static readonly int HotMaxTemperature = 30;
		private static readonly int HotMinTemperature = 25;
		private static readonly int HotTemperatureDefault = 28;

		private static readonly int ColdMaxTemperature = 25;
		private static readonly int ColdMinTemperature = 18;
		private static readonly int ColdTemperatureDefault = 22;

		private static readonly double MidSpeedPower = 1.0;
		private static readonly double LowSpeedPower = 0.8;
		private static readonly double HighSpeedPower = 1.3;
		private static readonly int CostPrePower = 5;
		#endregion

		private HostServiceStatus hostState;
		private INetWork netWork;
		private ILog LOGGER;
		private IDictionary<Byte, RemoteClient> clients;
		//private IDictionary<Byte, >

		private SQLConnector sql;

		public HostService() {
			LOGGER = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
			netWork = new Network(this);
			clients = new ConcurrentDictionary<Byte, RemoteClient>();
			sql = new SQLConnector();
		}

		public void ShutDown() {
			if (hostState.state == State.OFF)
				throw new Exception("AirConditioner is already off!");
			netWork.StopListen();
			hostState.state = State.OFF;
			LOGGER.Info("AirConditioner Turn Off!");
		}

		private void Init() {
			clients.Clear();
			hostState.state = State.OFF;
			hostState.mode = Mode.COLD;
			hostState.nowServiceAmount = 0;
			hostState.refreshFrequency = 1;
			hostState.serviceStage = ServiceStage.FIFO;
			LOGGER.Info("State init! " + hostState.ToString());
		}

		public Tuple<int, float> GetDefaultWorkingState() {
			return new Tuple<int, float>
				((int)hostState.mode,
				hostState.mode == Mode.COLD ?
				ColdTemperatureDefault :
				HotTemperatureDefault);
		}

		public void TurnOn() {
			if (hostState.state != State.OFF)
				throw new Exception("AirConditioner is already on!");
			Init();
			hostState.state = State.Sleep;
			netWork.StartListen();
			LOGGER.Info("AirConditioner Turn On!");
		}

		public bool Login(int roomNumber, string idNum) {
			using(SqlConnection con = new SqlConnection(sql.Builder.ConnectionString)) {
				con.Open();
				SqlCommand cmd = con.CreateCommand();
				cmd.CommandText = "select count(*) from dt_RoomIDCard where RoomNum = @a and IDCardNum = @b";
				cmd.Parameters.Clear();
				cmd.Parameters.AddWithValue("@a", roomNumber);
				cmd.Parameters.AddWithValue("@b", idNum);

				int count = Convert.ToInt32(cmd.ExecuteScalar());
				return count > 0;
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

		public void ClientSpeed(byte clientNum, ESpeed speed) {
			throw new NotImplementedException();
		}

		public void SetTargetTemperature(byte clientNum, float temperature) {
			clients[clientNum].SetTargetTemperature(temperature);
		}

		public int SettModle(int modle) {
			throw new NotImplementedException();
		}
	}
}
