using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {
	static class RequestDealer {
		public static Response Deal(Request request, IHostCallback callback) {
			switch (request.Cat) {
				case 2: {
					LoginRequest loginRequest = request as LoginRequest;
					return callback.DealRequest(loginRequest);
				}
				case 9: {
					throw new IOException();
				}
				default:
					throw new Exception("RequestDealer::Deal switch out of range with " + request.Cat);
			}
		}
	}
}
