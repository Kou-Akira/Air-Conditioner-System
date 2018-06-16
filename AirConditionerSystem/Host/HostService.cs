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

namespace Host {
	internal delegate void RequestDelegate(Common.Package request);


	class HostService : IHostService, IHostServiceCallback {
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

		private HostServiceStatus hostState;
		private INetWork netWork;
		private ILog LOGGER;
		private IDictionary<RemoteClient, SchedulingInformation> clients;

		public HostService() {
			LOGGER = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
			netWork = new Network(this);
			clients = new ConcurrentDictionary<RemoteClient, SchedulingInformation>();
		}

		public int SettModle(int modle) {
			throw new NotImplementedException();
		}

		public int ShutDown() {
			throw new NotImplementedException();
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
			// Todo checkLogin
			return true;
		}

		public Common.Package ChangeMode() {
			//return new HostModeResponse((int)this.hostState.mode, GetTemperatureDefault());
			throw new NotImplementedException();
		}

		public void AddClient(RemoteClient remoteClient) {
			clients.Add(remoteClient, new SchedulingInformation());
		}

		public void CloseClient(RemoteClient client) {
			clients.Remove(client);
			client.Abort();
		}

		public void ClientHeartBeat(RemoteClient client, float temperature) {
			throw new NotImplementedException();
		}
	}
}
