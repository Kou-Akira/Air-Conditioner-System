using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {

	/// <summary>
	/// 0关闭 1开启 2休眠
	/// </summary>
	enum State {
		OFF = 0,
		On,
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
		RoundRobin,
		HighSpeedFirst
	}

	struct HostStatus {

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
}
