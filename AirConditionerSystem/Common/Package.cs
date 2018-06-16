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
		int mode;
		float temperature;
		public HostAckPackage(int mode, float temperature) : base(1) {
			this.mode = mode;
			this.temperature = temperature;
		}

		public int Mode { get => mode; }
		public float Temperature { get => temperature; }
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
		float temperature;
		public ClientSpeedPackage(int speed, float temperature) : base(5) {
			this.speed = speed;
			this.temperature = temperature;
		}

		public int Speed { get => speed; }
		public float Temperature { get => temperature; }
	}
	public class ClientStopPackage : Package {
		float temperature;
		public ClientStopPackage(float temperature) : base(6) {
			this.temperature = temperature;
		}
		public float Temperature { get => temperature; }
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
		float temperature;
		public ClientClosePackage(float temperature) : base(9) {
			this.temperature = temperature;
		}

		public float Temperature { get => temperature; }
	}
	public class RefreshFrequencyPackage : Package {
		int frequency;

		public RefreshFrequencyPackage(int frequency) : base(10) {
			this.frequency = frequency;
		}

		public int Frequency { get => frequency; }
	}
	public class ClientTargetTemperaturePackage : Package {
		float temperature;

		public ClientTargetTemperaturePackage(float temperature) :base(11) {
			this.temperature = temperature;
		}

		public float Temperature { get => temperature; }
	}
}
