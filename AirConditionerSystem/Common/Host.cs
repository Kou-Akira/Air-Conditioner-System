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

namespace Common {
	internal delegate void RequestDelegate(Request request);


	class Host : IHost, IHostCallback {
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

		private HostStatus hostState;
		private INetWork netWork;
		private ILog LOGGER;
		private IDictionary<String, ClientStatus> clients;


		Host(String logdir) {
			LOGGER = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
			netWork = new Network(this);
			clients = new ConcurrentDictionary<String, ClientStatus>();
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

		private float GetTemperatureDefault() {
			return hostState.mode == Mode.COLD ?
				ColdTemperatureDefault :
				HotTemperatureDefault;
		}

		public void TurnOn() {
			if (hostState.state != State.OFF)
				throw new Exception("AirConditioner is already on!");
			Init();
			hostState.state = State.Sleep;
			netWork.StartListen();
			LOGGER.Info("AirConditioner Turn On!");
		}

		public Response[] DealRequest(Request request) {
			switch (request.Cat) {
				case 2: {
					ClientLoginRequest loginRequest = request as ClientLoginRequest;
					bool loginOk = checkLogin(loginRequest.RoomNumber, loginRequest.IdNum);
					if (loginOk) {
						clients.Add(loginRequest.IdNum,
							new ClientStatus(ESpeed.NoWind, GetTemperatureDefault(), 0));
						return new Response[2] {
							new HostAckResponse(),
							new HostModeResponse((int)this.hostState.mode, GetTemperatureDefault()) };
					} else {
						return new Response[1] { new HostNakResponse() };
					}
				}
				default:
					throw new Exception("Host::DealRequest switch out of range with " + request.Cat);
			}
		}

		private bool checkLogin(int roomNumber, string idNum) {
			// Todo checkLogin
			return true;
		}

		public Response ChangeMode() {
			return new HostModeResponse((int)this.hostState.mode, GetTemperatureDefault());
		}
	}
}
