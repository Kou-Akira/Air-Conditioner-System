using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common {
	class ThreadPool {
		private Thread[] threads;
		private Queue<IRequest<Request>>[] requests;
		private Mutex[] mutexes;
		private Semaphore[] semaphores;
		private bool running;
		private int threadNum;

		public ThreadPool(int threadNum) {
			this.threadNum = threadNum;
			running = false;
			threads = new Thread[this.threadNum];
			requests = new Queue<IRequest<Request>>[this.threadNum];
			semaphores = new Semaphore[this.threadNum];
			mutexes = new Mutex[this.threadNum];
			for(int i = 0; i < this.threadNum; i++) {
				requests[i] = new Queue<IRequest<Request>>();
				semaphores[i] = new Semaphore(1, 1);
				mutexes[i] = new Mutex();
			}
		}

		~ThreadPool() {
			if (running) {
				Stop();
			}
		}

		public void Stop() {

		}
		public void Start() {

		}
		public void AddTask(IRequest<Request> request) {
			int i = request.RoomNumber() % this.threadNum;
			
			mutexes[i].WaitOne();

			requests[i].

			mutexes[i].ReleaseMutex();

		}

		private void run() {

		}
	}
}
