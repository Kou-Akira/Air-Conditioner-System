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
					return new HostAckPackage(mode, temperature);
				}
				case 2: {
					networkStream.Read(buffer, 0, 1);
					byte roomNum = buffer[0];
					buffer = new byte[18];
					networkStream.Read(buffer, 0, 18);
					String id = ConvertBytesToId(buffer);
					return new ClientLoginPackage(roomNum, id);
				}
				case 3: {
					networkStream.Read(buffer, 0, 5);
					float temp = BitConverter.ToSingle(buffer, 1);
					return new HostModePackage((int)buffer[0], temp);
				}
				case 4: {
					networkStream.Read(buffer, 0, 4);
					float temp = BitConverter.ToSingle(buffer, 0);
					return new ClientTemperaturePackage(temp);
				}
				case 5: {
					networkStream.Read(buffer, 0, 5);
					float temp = BitConverter.ToSingle(buffer, 1);
					return new ClientSpeedPackage((int)buffer[0], temp);
				}
				case 6: {
					networkStream.Read(buffer, 0, 4);
					float temp = BitConverter.ToSingle(buffer, 0);
					return new ClientStopPackage(temp);
				}
				case 7: {
					networkStream.Read(buffer, 0, 5);
					float temp = BitConverter.ToSingle(buffer, 1);
					return new HostRequestPackage(buffer[0], temp);
				}
				//case 8: {
				//	networkStream.Read(buffer, 0, 1);
				//	return new HostSpeedPackage(buffer[0]);
				//}
				case 9: {
					networkStream.Read(buffer, 0, 4);
					float temperature = BitConverter.ToSingle(buffer, 0);
					return new ClientClosePackage(temperature);
				}
				case 10: {
					networkStream.Read(buffer, 0, 1);
					return new RefreshFrequencyPackage(buffer[0]);
				}
				case 11: {
					networkStream.Read(buffer, 0, 4);
					float temperature = BitConverter.ToSingle(buffer, 0);
					return new ClientTargetTemperaturePackage(temperature);
				}
				default:
					throw new Exception("PackageHelper::GetRequest switch out of range with " + cat);
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
					byte[] buffer = new byte[6];
					buffer[0] = 3;
					buffer[1] = (byte)hostModePackage.Mode;
					byte[] tbt = BitConverter.GetBytes(hostModePackage.Temperature);
					for (int i = 0; i < 4; i++) buffer[i + 2] = tbt[i];
					return buffer;
				}
				case 4: {
					ClientTemperaturePackage clientTemperaturePackage = response as ClientTemperaturePackage;
					byte[] res = new byte[5];
					res[0] = 4;
					byte[] tbt = BitConverter.GetBytes(clientTemperaturePackage.Temperature);
					for (int i = 0; i < 4; i++) res[i + 1] = tbt[i];
					return res;
				}
				case 5: {
					ClientSpeedPackage clientSpeedPackage = response as ClientSpeedPackage;
					byte[] res = new byte[6];
					res[0] = 5;
					res[1] = (byte)clientSpeedPackage.Speed;
					byte[] tbt = BitConverter.GetBytes(clientSpeedPackage.Temperature);
					for (int i = 0; i < 4; i++) res[i + 2] = tbt[i];
					return res;
				}
				case 6: {
					ClientStopPackage clientStopPackage = response as ClientStopPackage;
					byte[] res = new byte[5];
					res[0] = 6;
					byte[] tbt = BitConverter.GetBytes(clientStopPackage.Temperature);
					for (int i = 0; i < 4; i++) res[i + 1] = tbt[i];
					return res;
				}
				case 7: {
					HostRequestPackage hostCostPackage = response as HostRequestPackage;
					byte[] res = new byte[6];
					res[0] = 7;
					res[1] = hostCostPackage.Speed;
					byte[] tbt = BitConverter.GetBytes(hostCostPackage.Cost);
					for (int i = 0; i < 4; i++) res[i + 2] = tbt[i];
					return res;
				}
				//case 8: {
				//	HostSpeedPackage hostSpeedPackage = response as HostSpeedPackage;
				//	byte[] res = new byte[2];
				//	res[0] = 8;
				//	res[1] = (byte)hostSpeedPackage.Speed;
				//	return res;
				//}
				case 9: {
					ClientClosePackage clientClosePackage = response as ClientClosePackage;
					byte[] res = new byte[5];
					res[0] = 9;
					byte[] tbt = BitConverter.GetBytes(clientClosePackage.Temperature);
					for (int i = 0; i < 4; i++) res[i + 1] = tbt[i];
					return res;
				}
				case 10: {
					RefreshFrequencyPackage refreshFrequencyPackage = response as RefreshFrequencyPackage;
					byte[] res = new byte[2];
					res[0] = 10;
					res[1] = (byte)refreshFrequencyPackage.Frequency;
					return res;
				}
				case 11: {
					ClientTargetTemperaturePackage clientTargetTemperaturePackage = response as ClientTargetTemperaturePackage;
					byte[] res = new byte[5];
					res[0] = 11;
					byte[] tbt = BitConverter.GetBytes(clientTargetTemperaturePackage.Temperature);
					for (int i = 0; i < 4; i++) res[i + 1] = tbt[i];
					return res;
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
			for (int i = 0; i < id.Length; i++) {
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
