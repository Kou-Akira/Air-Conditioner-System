using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {
	class Request {
		int cat;
		int roomNumber;
		protected Request(int cat, int roomNumber) {
			this.cat = cat;
			this.roomNumber = roomNumber;
		}

		public int Cat { get => cat; }
		public int RoomNumber { get => roomNumber; }
	}
	class Response {
		int cat;
		protected Response(int cat) {
			this.cat = cat;
		}

		public int Cat { get => cat; }
	}
	class LoginRequest : Request {
		String idNum;
		public LoginRequest(int cat, int roomNumber,String  IdNum) : base(cat, roomNumber) {
			this.idNum = IdNum;
		}

		public string IdNum { get => idNum; }
	}
	class NakResponse : Response {
		public NakResponse(int cat) : base(cat) { }
	}
	class AckResponse : Response {
		public AckResponse(int cat) : base(cat) { }
	}

}
