using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host {
	interface IHostServiceCallback {
		Tuple<int, float> GetDefaultWorkingState();
		void AddClient(RemoteClient remoteClient);
		bool Login(int roomNumber, string idNum);
		Common.Package ChangeMode();
		void CloseClient(RemoteClient client);
	}
}
