using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host {
	interface IHostService {
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

		// Package[] DealRequest(Request request);

	}
}
