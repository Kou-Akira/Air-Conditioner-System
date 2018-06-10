using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Common {
	static class RequestHelper { 
		public static Request GetRequest(NetworkStream networkStream) {
			byte[] buffer = new byte[Constants.MAXBYTES];
			networkStream.Read(buffer, 0, 1);
			int cat = Convert.ToInt32(buffer[0]);
			switch (cat) {
				case 2: {
					networkStream.Read(buffer, 0, 1);
					int roomNum = Convert.ToInt32(buffer[0]);
					networkStream.Read(buffer, 0, 18);
					String id = GetId(buffer);
					return new ClientLoginRequest(roomNum, id);
				}
				default:
					throw new Exception("RequestFormatter::GetRequest switch out of range with " + cat);
			}
		}
		public static byte[] GetByte(Response response) {
			switch (response.Cat) {
				case 0: {
					byte[] res = new byte[1];
					res[0] = 0;
					return res;
				}
				case 1: {
					byte[] res = new byte[1];
					res[1] = 1;
					return res;
				}
				default:
					throw new Exception("RequestFormatter::GetByte switch out of range with " + response.Cat);
			}
		} 
		private static String GetId(byte[] bt) {
			if (bt.Length != Constants.IDLENTH)
				log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType).ErrorFormat("Id lenth != {0}", Constants.IDLENTH);
			String id = "";
			for(int i = 0; i < bt.Length; i++) {
				id = id + bt[i].ToString();
			}
			log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType).DebugFormat("Convert byte[]{0} to string{1} as id num!", bt, id);
			return id;
		}
	}
}
