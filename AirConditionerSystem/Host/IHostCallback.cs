using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host {
	interface IHostServiceCallback {
		Tuple<int, float> GetDefaultWorkingState();
		void AddClient(byte clientNum);
		bool Login(int roomNumber, string idNum);
		Common.Package ChangeMode();
		void CloseClient(byte clientNum);

		void ClientHeartBeat(byte clientNum, float temperature);

		void ClientSpeed(byte clientNum, ESpeed speed);

		void SetTargetTemperature(byte clientNum, float temperature);
	}
}
