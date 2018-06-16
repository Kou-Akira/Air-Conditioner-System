﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host {
	static class PackageHandler {
		public static Common.Package[] Deal(Common.Package request, IHostServiceCallback callback) {
			switch (request.Cat) {
				case 2: {
					Common.ClientLoginPackage loginRequest = request as Common.ClientLoginPackage;
					bool loginOk = callback.Login(loginRequest.RoomNumber, loginRequest.IdNum);
					if (loginOk) {
						var tmp = callback.GetDefaultWorkingState();
						return new Common.Package[2] {
							new Common.HostAckPackage(),
							new Common.HostModePackage(tmp.Item1,tmp.Item2) };
					} else {
						return new Common.Package[1] { new Common.HostNakPackage() };
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