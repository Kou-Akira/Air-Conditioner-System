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
	}
	class LoginRequest : Request {
		public LoginRequest(int cat, int roomNumber) : base(cat, roomNumber) {
		}
	}
}
