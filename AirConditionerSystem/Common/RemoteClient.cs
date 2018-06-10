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
		private Thread requestThread;
		private Thread heartbreatThread;
		String clientNum;
		private ClientStatus clientStatus;

		public RemoteClient(TcpClient client, IHostCallback callback) {
			this.client = client;
			LOGGER = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
			LOGGER.InfoFormat("Client Connected ! {0} < -- {1}",
				client.Client.LocalEndPoint, client.Client.RemoteEndPoint);
			streamToClient = client.GetStream();
			buffer = new byte[BufferSize];
			requestThread = new Thread(run);
			heartbreatThread = new Thread(heartBeat);
			requestThread.Start(callback);
			heartbreatThread.Start();
		}

		private void run(object cb) {
			IHostCallback callback = cb as IHostCallback;
			try {
				while (true) {
					Request request = null;
					lock (streamToClient) {
						request = RequestHelper.GetRequest(streamToClient);
					}
					Response[] responses = RequestHandler.Deal(request, callback);
					foreach (Response response in responses) {
						byte[] responseBytes = RequestHelper.GetByte(response);
						lock (streamToClient) {
							streamToClient.Write(responseBytes, 0, responseBytes.Length);
						}
					}
				}
			} catch (IOException e) {
				LOGGER.Warn("CLient close!", e);
			} finally {
				streamToClient.Dispose();
				client.Close();
				callback.CloseClient(this);
			}
		}

		private void heartBeat() {
			if (clientStatus.Speed == ESpeed.Unauthorized) return;
			Response response1 = new HostCostResponse(clientStatus.Cost);
			byte[] responseBytes1 = RequestHelper.GetByte(response1);
			Response response2 = new HostSpeedResponse((int)clientStatus.Speed);
			byte[] responseBytes2 = RequestHelper.GetByte(response2);
			lock (streamToClient) {
				streamToClient.Write(responseBytes1, 0, responseBytes1.Length);
				streamToClient.Write(responseBytes2, 0, responseBytes2.Length);
			}
		}

		public void Abort() {
			heartbreatThread.Abort();

			requestThread.Abort();
		}
	}
}
