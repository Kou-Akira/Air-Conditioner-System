using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {
	interface INetworkCallback {
		void OnSuccess();
		void OnError();
	}
}
