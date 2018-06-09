using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {
	static class RequestFormatter { 
		public static Request GetRequest(byte[] bt) {
			return new Request(6,7);
		}
		public static byte[] GetByte(Request request) {
			return new byte[10];
		} 
	}
}
