using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {
	class Request {
        //Common Params
        int type;
		int roomNumber;
        float temperature;
        
        int idNumber;
        int hostMode;
        int speedMode;
        float payment;
        int refreshRate;

        public Request(int roomNumber) {
			this.roomNumber = roomNumber;
		}
		
		public int RoomNumber() {
			return roomNumber;
		}
	}
}
