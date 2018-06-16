using System;

namespace Common {
	public class Package {
		int cat;
		protected Package(int cat) {
			this.cat = cat;
		}

		public int Cat { get => cat; }
	}
	public class Ignored : Package {
		public Ignored() : base(-1) {
		}
	}
	public class HostNakPackage : Package {
		public HostNakPackage() : base(0) { }

		public override string ToString() {
			return "HostNakPackage!";
		}
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

		public override string ToString() {
			return String.Format("HostAckPackage! mode:{0}, temperature{1}", mode, temperature);
		}
	}
	public class ClientLoginPackage : Package {
		String idNum;
		byte roomNumber;
		public ClientLoginPackage(byte roomNumber, String IdNum) : base(2) {
			this.roomNumber = roomNumber;
			this.idNum = IdNum;
		}

		public string IdNum { get => idNum; }
		public byte RoomNumber { get => roomNumber; }

		public override string ToString() {
			return String.Format("ClientLoginPackage! idNum:{0}, roomNumber:{1}", idNum, roomNumber);
		}
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
		public override string ToString() {
			return String.Format("HostModePackage! mode:{0}, temperature:{1}", mode, temperature);
		}
	}
	public class ClientTemperaturePackage : Package {
		float temperature;
		public ClientTemperaturePackage(float temperature) : base(4) {
			this.temperature = temperature;
		}

		public float Temperature { get => temperature; }
		public override string ToString() {
			return String.Format("ClientTemperaturePackage! temperature:{0}, Temperature:{1}", temperature, Temperature);
		}
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
		public override string ToString() {
			return String.Format("ClientSpeedPackage! speed:{0}, temperature:{1}", speed, temperature);
		}
	}
	public class ClientStopPackage : Package {
		float temperature;
		public ClientStopPackage(float temperature) : base(6) {
			this.temperature = temperature;
		}
		public float Temperature { get => temperature; }
		public override string ToString() {
			return String.Format("ClientStopPackage! temperature:{0}", temperature);
		}
	}
	public class HostCostPackage : Package {
		float cost;
		public HostCostPackage(float cost) : base(7) {
			this.cost = cost;
		}

		public float Cost { get => cost; }
		public override string ToString() {
			return String.Format("HostCostPackage! cost:{0}", cost);
		}
	}
	public class HostSpeedPackage : Package {
		int speed;
		public HostSpeedPackage(int speed) : base(8) {
			this.speed = speed;
		}

		public int Speed { get => speed; }
		public override string ToString() {
			return String.Format("HostSpeedPackage! speed:{0}", speed);
		}
	}
	public class ClientClosePackage : Package {
		float temperature;
		public ClientClosePackage(float temperature) : base(9) {
			this.temperature = temperature;
		}

		public float Temperature { get => temperature; }
		public override string ToString() {
			return String.Format("ClientClosePackage! temperature:{0}", temperature);
		}
	}
	public class RefreshFrequencyPackage : Package {
		int frequency;

		public RefreshFrequencyPackage(int frequency) : base(10) {
			this.frequency = frequency;
		}

		public int Frequency { get => frequency; }
		public override string ToString() {
			return String.Format("RefreshFrequencyPackage! frequency:{0}", frequency);
		}
	}
	public class ClientTargetTemperaturePackage : Package {
		float temperature;

		public ClientTargetTemperaturePackage(float temperature) :base(11) {
			this.temperature = temperature;
		}

		public float Temperature { get => temperature; }
		public override string ToString() {
			return String.Format("ClientTargetTemperaturePackage! temperature:{0}", temperature);
		}
	}
}
