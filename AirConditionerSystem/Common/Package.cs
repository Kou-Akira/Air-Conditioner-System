﻿using System;

namespace Common {
	public class Package {
		int cat;
		protected Package(int cat) {
			this.cat = cat;
		}

		public int Cat {
			get {
				return cat;
			}
		}
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

		public int Mode {
			get {
				return mode;
			}
		}
		public float Temperature {
			get {
				return temperature;
			}
		}

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

		public string IdNum {
			get {
				return idNum;
			}
		}
		public byte RoomNumber {
			get {
				return roomNumber;
			}
		}

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

		public int Mode {
			get {
				return mode;
			}
		}
		public float Temperature {
			get {
				return temperature;
			}
		}
		public override string ToString() {
			return String.Format("HostModePackage! mode:{0}, temperature:{1}", mode, temperature);
		}
	}
	public class ClientTemperaturePackage : Package {
		float temperature;
		public ClientTemperaturePackage(float temperature) : base(4) {
			this.temperature = temperature;
		}

		public float Temperature {
			get {
				return temperature;
			}
		}
		public override string ToString() {
			return String.Format("ClientTemperaturePackage! temperature:{0}.", Temperature);
		}
	}
	public class ClientSpeedPackage : Package {
		int speed;
		float temperature;
		public ClientSpeedPackage(int speed, float temperature) : base(5) {
			this.speed = speed;
			this.temperature = temperature;
		}

		public int Speed {
			get {
				return speed;
			}
		}
		public float Temperature {
			get {
				return temperature;
			}
		}
		public override string ToString() {
			return String.Format("ClientSpeedPackage! speed:{0}, temperature:{1}", speed, temperature);
		}
	}
	public class ClientStopPackage : Package {
		float temperature;
		public ClientStopPackage(float temperature) : base(6) {
			this.temperature = temperature;
		}
		public float Temperature {
			get {
				return temperature;
			}
		}
		public override string ToString() {
			return String.Format("ClientStopPackage! temperature:{0}", temperature);
		}
	}
	public class HostRequestPackage : Package {
		byte speed;
		float cost;
		public HostRequestPackage(byte speed, float cost) : base(7) {
			this.cost = cost;
			this.speed = speed;
		}

		public float Cost {
			get {
				return cost;
			}
		}

		public byte Speed {
			get {
				return speed;
			}
		}

		public override string ToString() {
			return String.Format("HostRequestPackage! speed:{0} cost:{1}", speed, cost);
		}
	}
	public class HostSpeedPackage : Package {
		int speed;
		public HostSpeedPackage(int speed) : base(8) {
			this.speed = speed;
		}

		public int Speed {
			get {
				return speed;
			}
		}
		public override string ToString() {
			return String.Format("HostSpeedPackage! speed:{0}", speed);
		}
	}
	public class ClientClosePackage : Package {
		float temperature;
		public ClientClosePackage(float temperature) : base(9) {
			this.temperature = temperature;
		}

		public float Temperature {
			get {
				return temperature;
			}
		}
		public override string ToString() {
			return String.Format("ClientClosePackage! temperature:{0}", temperature);
		}
	}
	public class RefreshFrequencyPackage : Package {
		byte frequency;

		public RefreshFrequencyPackage(byte frequency) : base(10) {
			this.frequency = frequency;
		}

		public byte Frequency {
			get {
				return frequency;
			}
		}
		public override string ToString() {
			return String.Format("RefreshFrequencyPackage! frequency:{0}", frequency);
		}
	}
	public class ClientTargetTemperaturePackage : Package {
		float temperature;

		public ClientTargetTemperaturePackage(float temperature) :base(11) {
			this.temperature = temperature;
		}

		public float Temperature {
			get {
				return temperature;
			}
		}
		public override string ToString() {
			return String.Format("ClientTargetTemperaturePackage! temperature:{0}", temperature);
		}
	}
}
