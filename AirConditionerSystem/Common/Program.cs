using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common {
	class Program {
		static ILog LOGGER = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
		static void DealRequest(Request request) {
			Thread.Sleep(1000);
			LOGGER.Debug("Deal With " + request.RoomNumber());
			return;
		}
		static void Main(string[] args) {
			log4net.Config.XmlConfigurator.Configure();
			ThreadPool pool = new ThreadPool(10, Program.DealRequest);
			pool.Start();
			Random rand = new Random();
			int i = 0;
			while (i < 1000) {
				pool.AddTask(new Request(i++));
				Thread.Sleep(10);
			}
			pool.Stop();
		}
	}
}
