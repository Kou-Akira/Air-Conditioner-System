using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common {
	class RemoteClient {
		private TcpClient client;
		private NetworkStream streamToClient;
		private const int BufferSize = 8192;
		private byte[] buffer;
		private ILog LOGGER;

		public RemoteClient(TcpClient client) {
			this.client = client;
			LOGGER = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
			LOGGER.InfoFormat("Client Connected ! {0} < -- {1}",
				client.Client.LocalEndPoint, client.Client.RemoteEndPoint);
			streamToClient = client.GetStream();
			buffer = new byte[BufferSize];
		}

		public void run(INetworkCallback callback) {
			try {
				while (true) {
					Request request = RequestFormatter.GetRequest(streamToClient);
					Response response = RequestDealer.Deal(request, callback);
					byte[] responseBytes = RequestFormatter.GetByte(response);
					streamToClient.Write(responseBytes, 0, responseBytes.Length);
				}
			} catch (IOException e) {
				LOGGER.Warn("CLient close!", e);
			}

		}




	}
}
