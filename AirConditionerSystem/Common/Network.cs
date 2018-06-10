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
	class Network : INetWork {
		private TcpListener listener;
		private int state;
		private ILog LOGGER;
		private IHostCallback callback;
		private Thread listenerThread;
		private ISet<RemoteClient> clients;

		public Network(IHostCallback callback) {
			this.callback = callback;
			state = 0;
			LOGGER = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
			LOGGER.Info("Network init!");
			listener = new TcpListener(IPAddress.Parse("0.0.0.0"), Constants.PORT);
			clients = new HashSet<RemoteClient>();
		}
		
		public void StartListen() {
			Interlocked.Increment(ref state);
			clients.Clear();
			listenerThread = new Thread(listen);
		}

		public void StopListen() {
			listenerThread.Abort();
			Interlocked.Decrement(ref state);
		}

		private void listen() {
			listener.Start();
			while(state == 1) {
				TcpClient tcpClient = listener.AcceptTcpClient();
				RemoteClient remoteClient = new RemoteClient(tcpClient);
				clients.Add(remoteClient);
			}
		}
		private void heartBeat() {
			foreach (RemoteClient client in clients) {
				client.HeartBeat();
			}
			Thread.Sleep(4000);
		}
	}
}
