using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common {
	class ThreadPool {
		private Thread[] threads;
		private Queue<Request>[] requests;
		private Object[] mutexes;
		private bool running;
		private int threadNum;
		private RequestDelegate requestHandler;

		private ILog LOGGER;

		public ThreadPool(int threadNum, RequestDelegate requestHandler) {
			this.threadNum = threadNum;
			this.requestHandler = requestHandler;
			running = false;
			threads = new Thread[this.threadNum];
			requests = new Queue<Request>[this.threadNum];
			mutexes = new object[this.threadNum];
			for (int i = 0; i < this.threadNum; i++) {
				requests[i] = new Queue<Request>();
				mutexes[i] = new Object();
			}
			LOGGER = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
			LOGGER.InfoFormat("ThreadPool init with {0} threads!", this.threadNum);
		}

		~ThreadPool() {
			if (running) {
				Stop();
			}
		}

		public void Stop() {
			running = false;
			for(int i = 0; i < this.threadNum; i++) {
				lock (mutexes[i]) {
					LOGGER.DebugFormat("Thread {0} destroy with {1} tasks left!", i, requests[i].Count);
					requests[i].Clear();
				}
			}
		}
		public void Start() {
			running = true;
			for(int i = 0; i < threadNum; i++) {
				LOGGER.DebugFormat("Thread {0} start!", i);
				threads[i] = new Thread(new ParameterizedThreadStart(run));
				threads[i].Start(i);
			}
		}
		public void AddTask(Request request) {
			int i = request.RoomNumber() % this.threadNum;
			LOGGER.DebugFormat("Add task of room {0} into queue {1} !", request.RoomNumber(), i);
			lock (mutexes[i]) {
				requests[i].Enqueue(request);
				LOGGER.Debug("Add to queue succeed!");
				Monitor.Pulse(mutexes[i]);
			}
		}

		private void run(object I) {
			int i = (int)I;
			while (running) {
				Request request = null;
				lock (mutexes[i]) {
					if (requests[i].Count == 0) {
						LOGGER.DebugFormat("Thread {} wait!", i);
						Monitor.Wait(mutexes[i]);
					}
					if (requests[i].Count != 0) {
						request = requests[i].Dequeue();
						LOGGER.DebugFormat("Request {} deque!", request.ToString());
					} else {
						continue;
					}
				}
				requestHandler(request);
			}
		}
	}
}
