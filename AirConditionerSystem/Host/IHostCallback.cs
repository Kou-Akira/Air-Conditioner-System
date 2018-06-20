using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host {
	internal interface IHostServiceCallback {
		Tuple<int, float> GetDefaultWorkingState();
		void AddClient(RemoteClient client);
		bool Login(byte roomNumber, string idNum, out float cost);

		void RemoveClient(byte clientNum);

		bool SendWind(byte id);

		void StopWind(byte id);
	}
}
