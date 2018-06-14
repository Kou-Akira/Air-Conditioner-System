using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {
	public class Package {
		int cat;
		protected Package(int cat) {
			this.cat = cat;
		}

		public int Cat { get => cat; }
	}
	public class HostNakPackage : Package {
		public HostNakPackage() : base(0) { }
	}
	public class HostAckPackage : Package {
		public HostAckPackage() : base(1) { }
	}
	public class ClientLoginPackage : Package {
		String idNum;
		int roomNumber;
		public ClientLoginPackage(int roomNumber, String IdNum) : base(2) {
			this.roomNumber = roomNumber;
			this.idNum = IdNum;
		}

		public string IdNum { get => idNum; }
		public int RoomNumber { get => roomNumber; }
	}
	public class HostModePackage : Package {
		int mode;
		float temperature;
		public HostModePackage(int mode, float temperature) : base(3) {
			this.mode = mode;
			this.temperature = temperature;
		}

		public int Mode { get => mode; }
		public float Temperature { get => temperature; }
	}
	public class ClientTemperaturePackage : Package {
		float temperature;
		public ClientTemperaturePackage(float temperature) : base(4) {
			this.temperature = temperature;
		}

		public float Temperature { get => temperature; }
	}
	public class ClientSpeedPackage : Package {
		int speed;
		public ClientSpeedPackage(int speed) : base(5) {
			this.speed = speed;
		}

		public int Speed { get => speed; }
	}
	public class ClientStopPackage : Package {
		public ClientStopPackage() : base(6) {
		}
	}
	public class HostCostPackage : Package {
		float cost;
		public HostCostPackage(float cost) : base(7) {
			this.cost = cost;
		}

		public float Cost { get => cost; }
	}
	public class HostSpeedPackage : Package {
		int speed;
		public HostSpeedPackage(int speed) : base(8) {
			this.speed = speed;
		}

		public int Speed { get => speed; }
	}
	public class ClientClosePackage : Package {
		public ClientClosePackage() : base(9) {
		}
	}
}
