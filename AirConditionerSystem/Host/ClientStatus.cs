using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Host {
	public enum ESpeed {
		Unauthorized = -1,
		NoWind = 0,
		Small,
		Mid,
		Large
	}
	struct ClientStatus {
		int speed;
		float targetTemperature;
		float nowTemperature;
		float cost;

		public ClientStatus(int speed, float targetTemperature, float nowTemperature, float cost) {
			this.speed = speed;
			this.targetTemperature = targetTemperature;
			this.nowTemperature = nowTemperature;
			this.cost = cost;
		}

		public int Speed { get => Interlocked.Exchange(ref speed, speed); set => Interlocked.Exchange(ref speed, value); }
		public float TargetTemperature { get => Interlocked.Exchange(ref targetTemperature, targetTemperature); set => Interlocked.Exchange(ref targetTemperature, value); }
		public float Cost { get => Interlocked.Exchange(ref cost, cost); set => Interlocked.Exchange(ref cost, value); }
		public float NowTemperature { get => Interlocked.Exchange(ref nowTemperature, nowTemperature); set => Interlocked.Exchange(ref nowTemperature, value); }
	}
}
