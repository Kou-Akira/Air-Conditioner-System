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
					callback.AddClient(client);
					bool loginOk = callback.Login(loginRequest.RoomNumber, loginRequest.IdNum);
					if (loginOk) {
						var tmp = callback.GetDefaultWorkingState();
						return new Common.HostAckPackage(tmp.Item1,tmp.Item2);
					} else {
						return new Common.HostNakPackage();
					}
				}
				case 4: {
					Common.ClientTemperaturePackage clientTemperaturePackage = request as Common.ClientTemperaturePackage;
					callback.ClientHeartBeat(client.ClientNum, clientTemperaturePackage.Temperature);
					return new Common.Ignored();
				}
				case 5: {
					Common.ClientSpeedPackage clientSpeedPackage = request as Common.ClientSpeedPackage;
					callback.ClientSpeed(client.ClientNum, (ESpeed)clientSpeedPackage.Speed);
					return new Common.Ignored();
				}
				case 6: {
					Common.ClientStopPackage clientStopPackage = request as Common.ClientStopPackage;
					callback.ClientSpeed(client.ClientNum, ESpeed.NoWind);
					return new Common.Ignored();
				}
				case 9: {
					throw new IOException();
				}
				case 11: {
					Common.ClientTargetTemperaturePackage clientTargetTemperaturePackage = request as Common.ClientTargetTemperaturePackage;
					callback.SetTargetTemperature(client.ClientNum, clientTargetTemperaturePackage.Temperature);
					return new Common.Ignored();
				}
				default:
					throw new Exception("PackageHandler::Deal switch out of range with " + request.Cat);
			}
		}
	}
}
