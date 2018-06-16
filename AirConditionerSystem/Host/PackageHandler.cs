using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host {
	static class PackageHandler {
		public static Common.Package Deal(RemoteClient client,Common.Package request, IHostServiceCallback callback) {
			switch (request.Cat) {
				case 2: {
					Common.ClientLoginPackage loginRequest = request as Common.ClientLoginPackage;
					client.ClientNum = loginRequest.RoomNumber;
					bool loginOk = callback.Login(loginRequest.RoomNumber, loginRequest.IdNum);
					if (loginOk) {
						var tmp = callback.GetDefaultWorkingState();
						return new Common.HostAckPackage(tmp.Item1,tmp.Item2);
					} else {
						return new Common.HostNakPackage();
					}
				}
				//case 4: {
					//Common.ClientTemperaturePackage clientTemperaturePackage = request as Common.ClientTemperaturePackage;
					//callback.
				//}
				case 9: {
					throw new IOException();
				}
				default:
					throw new Exception("PackageHandler::Deal switch out of range with " + request.Cat);
			}
		}
	}
}
