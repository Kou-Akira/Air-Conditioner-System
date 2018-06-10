using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host {
	public enum ESpeed {
		Unauthorized = -1,
		NoWind = 0,
		Small,
		Mid,
		Large
	}
	struct ClientStatus {
		ESpeed speed;
		float temperature;
		float cost;

		public ClientStatus(ESpeed speed, float temperature, float cost) {
			this.speed = speed;
			this.temperature = temperature;
			this.cost = cost;
		}

		public ESpeed Speed { get => speed; set => speed = value; }
		public float Temperature { get => temperature; set => temperature = value; }
		public float Cost { get => cost; set => cost = value; }
	}
}
