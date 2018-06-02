using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using log4net;

namespace Common {
	class Network : INetWork {
		private const int threadNum = 10;
		private TcpListener listener;
		private int state;
		private ILog LOGGER;
		


		Network() {
			state = 0;
			LOGGER = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
			LOGGER.Info("Network init!");
			threads = new Thread[threadNum];
			semaphore.
			for(int i=0;i<threadNum;i++)
				threads[i]
		}

		private void start() {
			Interlocked.Increment(ref state);
		}

		public void StartListen() {
			throw new NotImplementedException();
		}

		public void StopListen() {
			throw new NotImplementedException();
		}
	}
}
