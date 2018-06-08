using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Common {
	class RequestFormatter {
		INetWork netWork;
		TcpClient tcpClient;
		public RequestFormatter(TcpClient tcpClient,INetWork netWork) {
			this.netWork = netWork;
			this.tcpClient = tcpClient;
		}
		public void GetRequest(TcpClient client) {

		}
	}
}
    