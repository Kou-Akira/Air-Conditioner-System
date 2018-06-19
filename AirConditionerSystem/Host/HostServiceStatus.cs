using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Host {

	/// <summary>
	/// 0关闭 1开启 2休眠
	/// </summary>
	public enum ServiceState {
		OFF = 0,
		On,
		//Sleep
	};

	/// <summary>
	/// 0hot 1cold
	/// </summary>
	public enum ServiceMode {
		COLD = 0,
		HOT ,
	}

	/// <summary>
	/// 服务策略
	/// </summary>
	public enum ServiceStage {
		FIFO = 0,
		RoundRobin,
		HighSpeedFirst
	}

	class HostServiceStatus {

		private int state;

		private int mode;

		/// <summary>
		/// 刷新频率
		/// </summary>
		private int refreshFrequency;

		private int stage;

		/// <summary>
		/// 当前服务主机数
		/// </summary>
		private int nowServiceAmount;

		public HostServiceStatus() {
			state = (int)ServiceState.OFF;
			mode = (int)ServiceMode.COLD;
			refreshFrequency = 5;
			stage = (int)ServiceStage.RoundRobin;
		}

		internal int State {
			get { return Interlocked.Exchange(ref state, state); }
			set {
				Interlocked.Exchange(ref state, value);
			}
		}
		internal int Mode {
			get { return Interlocked.Exchange(ref mode, mode); }
			set {
				Interlocked.Exchange(ref mode, value);
			}
		}
		internal int RefreshFrequency {
			get { return Interlocked.Exchange(ref refreshFrequency, refreshFrequency); }
			set {
				Interlocked.Exchange(ref refreshFrequency, value);
			}
		}
		internal int Stage {
			get { return Interlocked.Exchange(ref stage, stage); }
			set {
				Interlocked.Exchange(ref stage, value);
			}
		}
		internal int NowServiceAmount {
			get { return Interlocked.Exchange(ref nowServiceAmount, nowServiceAmount); }
			set {
				Interlocked.Exchange(ref nowServiceAmount, value);
			}
		}

		public override string ToString() {
			return String.Format("State:{0}, Mode:{1}, RefreshFrequency:{2}, ServiceStage:{3}, NowServiceAmount:{4}.",
				state, mode, refreshFrequency, stage, nowServiceAmount);
		}
	}
}
