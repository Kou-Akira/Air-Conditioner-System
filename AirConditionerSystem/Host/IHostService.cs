using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host {
	public interface IHostService {
		/// <summary>
		/// 
		/// </summary>
		void TurnOn();

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		bool ShutDown();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="modle"></param>
		/// <returns></returns>
		bool SettModle(ServiceMode mode);

		bool Regist(byte roomId, string Id);

		bool UnRegist(byte roomId);

		bool CheckOut(byte roomId);

		IList<ClientStatus> GetClientStatus(out int waiting);

		IDictionary<Byte, List<HostLog>> GetLog(DateTime start, DateTime end);
	}
}
