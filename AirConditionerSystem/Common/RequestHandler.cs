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
					bool loginOk = callback.Login(loginRequest.RoomNumber, loginRequest.IdNum);
					if (loginOk) {
						var tmp = callback.GetDefaultWorkingState();
						return new Response[2] {
							new HostAckResponse(),
							new HostModeResponse(tmp.Item1,tmp.Item2) };
					} else {
						return new Response[1] { new HostNakResponse() };
					}
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
