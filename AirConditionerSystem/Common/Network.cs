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
	class Network : INetWork, INetworkCallback {
		private const int threadNum = 10;
		private TcpListener listener;
		private int state;
		private ILog LOGGER;
		private ThreadPool threadPool;
		private RequestDelegate requestDelegate;
		private Thread listenerThread;

		Network(RequestDelegate requestDelegate) {
			this.requestDelegate = requestDelegate;
			state = 0;
			LOGGER = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
			LOGGER.Info("Network init!");
			threadPool = new ThreadPool(threadNum, this.requestDelegate);
			listener = new TcpListener(IPAddress.Parse("0.0.0.0"), 2333);
			listenerThread = new Thread(listen);
		}

		public void StartListen() {
			Interlocked.Increment(ref state);
			threadPool.Start();
		}

		public void StopListen() {
			Interlocked.Decrement(ref state);
			threadPool.Stop();
		}

		private void listen() {
			while(state == 1) {
				TcpClient tcpClient = listener.AcceptTcpClient();
				RequestFormatter formatter = new RequestFormatter(tcpClient,this);
			}
		}

		public delegate void GetRequestDelegate(Request request);

		public void OnSuccess() {
			throw new NotImplementedException();
		}

		public void OnError() {
			throw new NotImplementedException();
		}
	}
}
