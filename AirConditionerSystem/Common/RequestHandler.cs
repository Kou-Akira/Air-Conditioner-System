using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {
	static class RequestHandler {
		public static Response[] Deal(Request request, IHostCallback callback) {
			switch (request.Cat) {
				case 2: {
					ClientLoginRequest loginRequest = request as ClientLoginRequest;
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
