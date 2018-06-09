using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using log4net;

namespace Common {
	delegate void DealRequestDelegate(TcpClient tcpClient);
	class Network : INetWork {
		private TcpListener listener;
		private int state;
		private ILog LOGGER;
		//private IDictionary<String, RemoteClient> remoteClients;
		DealRequestDelegate dealRequest;

		public Network(DealRequestDelegate dealRequestDelegate) {
			state = 0;
			LOGGER = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
			LOGGER.Info("Network init!");
			//remoteClients = new Dictionary<String, RemoteClient>();
			this.dealRequest = dealRequestDelegate;
			listener = new TcpListener(IPAddress.Parse("0.0.0.0"), Consts.PORT);
			listener.Stop();
		}

		private void start() {
			listener.Start();
			listener.BeginAcceptTcpClient(GetTcpClient, null);
		}
		private void stop() {
			listener.Stop();
		}

		public void StartListen() {
			Interlocked.Increment(ref state);
			start();
		}

		public void StopListen() {
			Interlocked.Decrement(ref state);
			stop();
		}

		private void GetTcpClient(object ignored) {
			TcpClient client = listener.EndAcceptTcpClient(null);
			if (client != null) {
				dealRequest(client);
			}
			listener.BeginAcceptTcpClient(GetTcpClient, null);
		}
	}
}
