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
	public class ClientStatus {
		int speed;
		int realSpeed;
		float targetTemperature;
		float nowTemperature;
		float cost;
		DateTime lastHeartBeat;

		public ClientStatus() {
			this.speed = (int)ESpeed.Unauthorized;
			this.realSpeed = (int)ESpeed.NoWind;
			this.targetTemperature = this.nowTemperature = -1;
			this.cost = 0;
			this.lastHeartBeat = DateTime.Now;
		}

		public ClientStatus Clone() {
			ClientStatus rtv = new ClientStatus();
			rtv.speed = this.Speed;
			rtv.RealSpeed = this.RealSpeed;
			rtv.TargetTemperature = this.TargetTemperature;
			rtv.NowTemperature = this.NowTemperature;
			rtv.Cost = this.Cost;
			rtv.LastHeartBeat = this.LastHeartBeat;
			return rtv;
		}

		public int Speed {
			get { return Interlocked.Exchange(ref speed, speed); }
			set {
				Interlocked.Exchange(ref speed, value);
			}
		}
		public float TargetTemperature {
			get { return Interlocked.Exchange(ref targetTemperature, targetTemperature); }
			set {
				Interlocked.Exchange(ref targetTemperature, value);
			}
		}
		public float Cost {
			get { return Interlocked.Exchange(ref cost, cost); }
			set {
				Interlocked.Exchange(ref cost, value);
			}
		}
		public float NowTemperature {
			get { return Interlocked.Exchange(ref nowTemperature, nowTemperature); }
			set {
				Interlocked.Exchange(ref nowTemperature, value);
			}
		}
		public DateTime LastHeartBeat {
			get {
				return lastHeartBeat;
			}
			set {
				lock (this) {
					lastHeartBeat = value;
				}
			}
		}

		public int RealSpeed {
			get { return Interlocked.Exchange(ref realSpeed, realSpeed); }
			set {
				Interlocked.Exchange(ref realSpeed, value);
			}
		}
	}
}