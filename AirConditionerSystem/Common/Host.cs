using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Common {
	internal delegate void RequestDelegate();

	/// <summary>
	/// 0关闭 1开启 2休眠
	/// </summary>
	enum State {
		OFF = 0,
		On ,
		Sleep
	};

	/// <summary>
	/// 0hot 1cold
	/// </summary>
	internal enum Mode {
		HOT = 0,
		COLD 
	}

	/// <summary>
	/// 服务策略
	/// </summary>
	internal enum ServiceStage {
		FIFO = 0,
		RoundRobin ,
		HighSpeedFirst
	}

	struct HostState {

		internal State state;

		internal Mode mode;

		/// <summary>
		/// 刷新频率
		/// </summary>
		internal int refreshFrequency;

		internal ServiceStage serviceStage;

		/// <summary>
		/// 当前服务主机数
		/// </summary>
		internal int nowServiceAmount;

		public override string ToString() {
			return String.Format("State:{0},Mode:{1},RefreshFrequency:{2},ServiceStage:{3},NowServiceAmount:{4}",
				state, mode, refreshFrequency, serviceStage, nowServiceAmount);
		}
	}

	class Host : IHost {
		private static int HotMaxTemperature = 30;
		private static int HotMinTemperature = 25;
		private static int HotTemperatureDefault = 28;

		private static int ColdMaxTemperature = 25;
		private static int ColdMinTemperature = 18;
		private static int ColdTemperatureDefault = 22;

		private static double MidSpeedPower = 1.0;
		private static double LowSpeedPower = 0.8;
		private static double HighSpeedPower = 1.3;
		private static int CostPrePower = 5;

		private HostState hostState;
		private INetWork netWork;
		private ILog LOGGER;
		

		Host(String logdir) {
			LOGGER = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
		}
		

		public int SettModle(int modle) {
			throw new NotImplementedException();
		}

		public int ShutDown() {
			throw new NotImplementedException();
		}

		private void Init() {
			hostState.state = State.OFF;
			hostState.mode = Mode.COLD;
			hostState.nowServiceAmount = 0;
			hostState.refreshFrequency = 1;
			hostState.serviceStage = ServiceStage.FIFO;
			LOGGER.Info("Stata init! " + hostState.ToString());
		}

		internal event RequestDelegate RequestEvent;

		private void DealRequest(IRequest<Request> request) {
			
		}

		public void TurnOn() {
			LOGGER.Info("AirConditioner Turn On!");
			if (hostState.state != State.OFF)
				throw new Exception("AirConditioner is already on!");

			Init();
			hostState.state = State.Sleep;
			netWork.StartListen();
		}

		public void run() {

			throw new NotImplementedException();
		}
	}
}
