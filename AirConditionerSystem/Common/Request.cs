using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {
	class Request {
		int cat;
		protected Request(int cat) {
			this.cat = cat;
		}

		public int Cat { get => cat; }
	}
	class Response {
		int cat;
		protected Response(int cat) {
			this.cat = cat;
		}

		public int Cat { get => cat; }
	}
	class HostNakResponse : Response {
		public HostNakResponse() : base(0) { }
	}
	class HostAckResponse : Response {
		public HostAckResponse() : base(1) { }
	}
	class ClientLoginRequest : Request {
		String idNum;
		int roomNumber;
		public ClientLoginRequest(int roomNumber,String  IdNum) : base(2) {
			this.roomNumber = roomNumber;
			this.idNum = IdNum;
		}

		public string IdNum { get => idNum; }
		public int RoomNumber { get => roomNumber; }
	}
	class HostModeResponse : Response {
		int mode;
		float temperature;
		public HostModeResponse(int mode, float temperature) :base(3) {
			this.mode = mode;
			this.temperature = temperature;
		}

		public int Mode { get => mode; }
		public float Temperature { get => temperature; }
	}
	class ClientTemperatureRequest : Request {
		float temperature;
		public ClientTemperatureRequest(float temperature) : base(4) {
			this.temperature = temperature;
		}

		public float Temperature { get => temperature; }
	}
	class ClientSpeedRequest : Request {
		int speed;
		public ClientSpeedRequest(int speed) : base(5) {
			this.speed = speed;
		}

		public int Speed { get => speed;}
	}
	class ClientStopRequest : Request {
		public ClientStopRequest() : base(6) {
		}
	}
	class HostCostResponse : Response {
		float cost;
		public HostCostResponse(float cost) : base(7) {
			this.cost = cost;
		}

		public float Cost { get => cost; }
	}
	class HostSpeedResponse : Response {
		int speed;
		public HostSpeedResponse(int speed) : base(8) {
			this.speed = speed;
		}

		public int Speed { get => speed; }
	}
	class ClientCloseRequest : Request {
		public ClientCloseRequest() : base(9) {
		}
	}
}
