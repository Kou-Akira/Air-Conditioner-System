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

namespace Host {
	class Network : INetWork {
		private TcpListener listener;
		private int state;
		private ILog LOGGER;
		private IHostServiceCallback callback;
		private Thread listenerThread;

		public Network(IHostServiceCallback callback) {
			this.callback = callback;
			state = 0;
			LOGGER = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
			LOGGER.Info("Network init!");
			listener = new TcpListener(IPAddress.Parse("0.0.0.0"), Common.Constants.PORT);
		}

		public void StartListen() {
			Interlocked.Increment(ref state);
			listenerThread = new Thread(listen);
			listenerThread.Start();
		}

		public void StopListen() {
			Interlocked.Decrement(ref state);
			listenerThread.Abort();
		}

		private void listen() {
			try {
				listener.Start();
				LOGGER.InfoFormat("Start listen on port {0}", Common.Constants.PORT);
				while (state == 1) {
					TcpClient tcpClient = listener.AcceptTcpClient();
					Object ignored = new RemoteClient(tcpClient, callback);
				}
			} catch (ThreadAbortException e) {
				LOGGER.Warn("Network listen thread has been abort!", e);
			} finally {
				if (listener != null) {
					listener.Stop();
					LOGGER.Info("Stop Listen!");
				}
			}
		}
	}
}
