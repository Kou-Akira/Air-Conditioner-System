using System;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using Common;
using System.Threading;

namespace TestHost {


	class Program {
		static void Main(string[] args) {
			while (true) {
				Thread.Sleep(5000);
				TcpClient client = new TcpClient("localhost", 6000);
				NetworkStream stream = client.GetStream();
				try {
					while (true) {
						Package package = null;
						int a = Convert.ToInt32(Console.ReadLine());
						switch (a) {
							case 2: {
								int b = Convert.ToInt32(Console.ReadLine());
								string s = Console.ReadLine();
								package = new ClientLoginPackage((byte)b, s);
								break;
							}
							case 4: {
								package = new ClientTemperaturePackage(78.6f);
								break;
							}
							case 5: {
								int b = Convert.ToInt32(Console.ReadLine());
								package = new ClientSpeedPackage(b, 25.0f);
								break;
							}
							case 6: {
								package = new ClientStopPackage(45.8f);
								break;
							}
							case 9: {
								package = new ClientClosePackage(78.9f);
								break;
							}
							case 11: {
								package = new ClientTargetTemperaturePackage(34.6f);
								break;
							}
							default:
								break;
						}
						byte[] bt = PackageHelper.GetByte(package);
						stream.Write(bt, 0, bt.Length);
						if (package.Cat == 2)
							Console.WriteLine(GetRequest(stream).ToString());

					}
				} catch (Exception e) {
					Console.Write(e);
				} finally {
					if (stream != null) stream.Dispose();
					if (client != null) client.Close();
				}

			}
		}
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
	}


}
