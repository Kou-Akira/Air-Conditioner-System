using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common {
	class RemoteClient {
		private TcpClient client;
		private NetworkStream streamToClient;
		private const int BufferSize = 8192;
		private byte[] buffer;
		private ILog LOGGER;
		private Thread workThread;

		public RemoteClient(TcpClient client) {
			this.client = client;
			LOGGER = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
			LOGGER.InfoFormat("Client Connected ! {0} < -- {1}",
				client.Client.LocalEndPoint, client.Client.RemoteEndPoint);
			streamToClient = client.GetStream();
			buffer = new byte[BufferSize];
			//workThread = new Thread(run);
		}

		private void run(IHostCallback callback) {
			try {
				while (true) {
					Request request = RequestHelper.GetRequest(streamToClient);
					Response[] responses = RequestHandler.Deal(request, callback);
					foreach (Response response in responses) {
						byte[] responseBytes = RequestHelper.GetByte(response);
						streamToClient.Write(responseBytes, 0, responseBytes.Length);
					}
				}
			} catch (IOException e) {
				LOGGER.Warn("CLient close!", e);
			}

		}

		public void HeartBeat() {

		}
	}
}
