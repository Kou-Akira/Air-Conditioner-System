using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Host {
	class RemoteClient {
		private TcpClient client;
		private NetworkStream streamToClient;
		private const int BufferSize = 8192;
		private ILog LOGGER = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
		private System.Threading.Thread requestThread;
		String clientNum;
		private ClientStatus clientStatus;
		private System.Timers.Timer heartBeatTimer;

		public RemoteClient(TcpClient client, IHostServiceCallback callback) {
			this.client = client;
			LOGGER.InfoFormat("Client Connected ! {0} < -- {1}",
				client.Client.LocalEndPoint, client.Client.RemoteEndPoint);
			streamToClient = client.GetStream();
			clientStatus = new ClientStatus();
			clientStatus.Speed = ESpeed.Unauthorized;

			heartBeatTimer = new System.Timers.Timer(5000);
			heartBeatTimer.AutoReset = true;
			heartBeatTimer.Elapsed += this.heartBeat;

			requestThread = new System.Threading.Thread(run);
			requestThread.Start(callback);
		}

		private void run(object cb) {
			heartBeatTimer.Enabled = true;
			IHostServiceCallback callback = cb as IHostServiceCallback;
			try {
				while (true) {
					Common.Package request = null;
					lock (streamToClient) {
						request = Common.PackageHelper.GetRequest(streamToClient);
					}
					Common.Package response = PackageHandler.Deal(request, callback);
					SendPackage(response);
				}
			} catch (IOException e) {
				LOGGER.Warn("Client stop run, maybe close!", e);
			} finally {
				heartBeatTimer.Enabled = false;
				this.clientStatus.Speed = ESpeed.Unauthorized;
				streamToClient.Dispose();
				client.Close();
				callback.CloseClient(this);
			}
		}

		private void heartBeat(object source, System.Timers.ElapsedEventArgs e) {
			if (clientStatus.Speed == ESpeed.Unauthorized) return;
			Common.Package response1 = new Common.HostCostPackage(clientStatus.Cost);
			Common.Package response2 = new Common.HostSpeedPackage((int)clientStatus.Speed);
			SendPackage(response1);
			SendPackage(response2);
		}

		public void Abort() {
			requestThread.Abort();
		}

		private void SendPackage(Common.Package package) {
			lock (streamToClient) {
				byte[] bts = Common.PackageHelper.GetByte(package);
				streamToClient.Write(bts, 0, bts.Length);
			}
		}
	}
}
