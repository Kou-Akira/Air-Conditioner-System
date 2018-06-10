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
		static void Main(string[] args) {
			log4net.Config.XmlConfigurator.Configure();
			IHost host = new Host();
			host.TurnOn();
			while (true) { }
		}
	}
}
