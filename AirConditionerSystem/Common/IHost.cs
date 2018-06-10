using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {
	interface IHost {
		/// <summary>
		/// 
		/// </summary>
		void TurnOn();

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		int ShutDown();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="modle"></param>
		/// <returns></returns>
		int SettModle(int modle);

		// Response[] DealRequest(Request request);

	}
}
