using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {
	interface IHostCallback {
		Tuple<int, float> GetDefaultWorkingState();
		void AddClient(RemoteClient remoteClient);
		bool Login(int roomNumber, string idNum);
		Response ChangeMode();
		void CloseClient(RemoteClient client);
	}
}
