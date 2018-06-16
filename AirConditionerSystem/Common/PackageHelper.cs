using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Common {
	public static class PackageHelper {
		public static Package GetRequest(NetworkStream networkStream) {
			byte[] buffer = new byte[Constants.MAXBYTES];
			networkStream.Read(buffer, 0, 1);
			int cat = Convert.ToInt32(buffer[0]);
			switch (cat) {
				case 0: {
					return new HostNakPackage();
				}
				case 1: {
					networkStream.Read(buffer, 0, 5);
					int mode = BitConverter.ToBoolean(buffer, 0) == true ? 1 : 0;
					float temperature = BitConverter.ToSingle(buffer, 1);
					return new HostAckPackage(mode,temperature);
				}
				case 2: {
					networkStream.Read(buffer, 0, 1);
					char roomNum = BitConverter.ToChar(buffer,0);
					networkStream.Read(buffer, 0, 18);
					String id = ConvertBytesToId(buffer);
					return new ClientLoginPackage(roomNum, id);
				}
				default:
					throw new Exception("RequestFormatter::GetRequest switch out of range with " + cat);
			}
		}
		public static byte[] GetByte(Package response) {
			switch (response.Cat) {
				case 0: {
					byte[] res = new byte[1];
					res[0] = 0;
					return res;
				}
				case 1: {
					HostAckPackage hostAckPackage = response as HostAckPackage;
					byte[] res = new byte[6];
					res[0] = 1;
					res[1] = (byte)hostAckPackage.Mode;
					byte[] tbt = BitConverter.GetBytes(hostAckPackage.Temperature);
					for (int i = 0; i < 4; i++) res[i + 2] = tbt[i]; 
					return res;
				}
				case 2: {
					ClientLoginPackage clientLoginRequest = response as ClientLoginPackage;
					byte[] buffer = new byte[20];
					buffer[0] = 2;
					buffer[1] = Convert.ToByte(clientLoginRequest.RoomNumber);
					for (int i = 0; i < 18; i++) {
						buffer[2 + i] = Convert.ToByte(clientLoginRequest.IdNum[i]);
					}
					return buffer;
				}
				case 3: {
					HostModePackage hostModePackage = response as HostModePackage;
					byte[] buffer = new byte[20];
					buffer[0] = 3;
					buffer[1] = (byte)hostModePackage.Mode;

					return buffer;
				}
				default:
					throw new Exception("RequestFormatter::GetByte switch out of range with " + response.Cat);
			}
		}
		private static String ConvertBytesToId(byte[] bt) {
			String id = "";
			for (int i = 0; i < bt.Length; i++) {
				id = id + Convert.ToChar(bt[i]);
			}
			return id;
		}

		private static byte[] ConvertIdToBytes(String id) {
			byte[] res = new byte[18];
			for(int i = 0; i < id.Length; i++) {
				res[i] = Convert.ToByte(id[i]);
			}
			return res;
		}

		private static byte[] ConvertFloatToByte(float f) {
			byte[] bt = BitConverter.GetBytes(f);
			return bt;
		}

		private static float ConvertByteToFloat(byte[] bt) {
			float fl = BitConverter.ToSingle(bt, 0);
			return fl;
		}
	}
}
