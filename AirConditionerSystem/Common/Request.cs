using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {
	class Request {
		int roomNumber;

		public Request(int roomNumber) {
			this.roomNumber = roomNumber;
		}
		
		public int RoomNumber() {
			return roomNumber;
		}
	}
}
