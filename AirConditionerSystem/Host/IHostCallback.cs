﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host {
	interface IHostServiceCallback {
		Tuple<int, float> GetDefaultWorkingState();
		void AddClient(RemoteClient client);
		bool Login(int roomNumber, string idNum);

		void CloseClient(byte clientNum);

		void ReceiveClientHeartBeat(byte clientNum, float temperature);

		void ClientSpeed(byte clientNum, ESpeed speed);

		void SetTargetTemperature(byte clientNum, float temperature);
	}
}
