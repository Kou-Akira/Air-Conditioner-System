using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {
	public enum ESpeed {
		NoWind = 0,
		Small,
		Mid,
		Large
	}
	struct ClientStatus {
		ESpeed speed;
		int temperature;
		double cost;

		public ClientStatus(ESpeed speed, int temperature, double cost) {
			this.speed = speed;
			this.temperature = temperature;
			this.cost = cost;
		}

		public ESpeed Speed { get => speed; set => speed = value; }
		public int Temperature { get => temperature; set => temperature = value; }
		public double Cost { get => cost; set => cost = value; }
	}
}
