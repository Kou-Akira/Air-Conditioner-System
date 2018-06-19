using log4net;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Host {
	class RemoteClient {
		private TcpClient tcpclient;
		private NetworkStream streamToClient;
		private ILog LOGGER = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
		private System.Threading.Thread requestThread;
		private byte clientNum = 0;
		private ClientStatus clientStatus;
		private System.Timers.Timer heartBeatTimer;
		private Object readLock = new object();
		private Object writeLock = new object();
		private IHostServiceCallback callback;

		public byte ClientNum {
			get { return clientNum; }
			set {
				clientNum = value;
			}
		}

		public ClientStatus ClientStatus {
			get { return clientStatus; }
			set {
				clientStatus = value;
			}
		}

		public RemoteClient(TcpClient client, IHostServiceCallback callback) {
			this.tcpclient = client;
			LOGGER.InfoFormat("Client Connected! {0} < -- {1}",
				client.Client.LocalEndPoint, client.Client.RemoteEndPoint);
			streamToClient = client.GetStream();
			clientStatus = new ClientStatus();
			this.callback = callback;

			heartBeatTimer = new System.Timers.Timer(5000);
			heartBeatTimer.AutoReset = true;
			heartBeatTimer.Elapsed += this.heartBeat;

			requestThread = new System.Threading.Thread(run);
			requestThread.Start(callback);
		}

		private void run(object cb) {
			heartBeatTimer.Enabled = true;
			IHostServiceCallback callback = cb as IHostServiceCallback;
			try {
				while (true) {
					Common.Package request = null;
					lock (readLock) {
						request = Common.PackageHelper.GetRequest(streamToClient);
						LOGGER.InfoFormat("Receive package {0} from client {1}!", request.ToString(),
							clientNum == 0 ? tcpclient.Client.RemoteEndPoint.ToString() : clientNum.ToString());
					}
					Common.Package response = PackageHandler.Deal(this, request, callback);
					if (response.Cat == 1) {
						new System.Threading.Thread(WriteLog).Start(
							new Tuple<byte, int, int, float, float>(clientNum, 0, 0, 0, 0));
					}
					SendPackage(response);
				}
			} catch (IOException e) {
				LOGGER.WarnFormat("Client {0} stop run, maybe close!", this.ClientNum, e);
			} catch (System.Threading.ThreadAbortException) {
				LOGGER.WarnFormat("Client {0} has been aborted!", this.ClientNum);
			} finally {
				WriteLog(new Tuple<byte, int, int, float, float>(clientNum, 1, this.ClientStatus.RealSpeed, this.ClientStatus.NowTemperature, this.ClientStatus.Cost));
				heartBeatTimer.Enabled = false;
				lock (this) {
					this.clientStatus.Speed = (int)ESpeed.Unauthorized;
					this.ClientStatus.RealSpeed = (int)ESpeed.NoWind;
				}
				if (streamToClient != null)
					streamToClient.Dispose();
				if (tcpclient != null)
					tcpclient.Close();
				callback.RemoveClient(this.clientNum);
			}
		}

		private void updateCost() {
			if (this.clientStatus.Speed == (int)ESpeed.Unauthorized || this.clientStatus.Speed == (int)ESpeed.NoWind) return;

			this.clientStatus.Cost += Common.Constants.CostPrePower *
				(this.clientStatus.RealSpeed == 1 ? Common.Constants.LowSpeedPower :
				(this.clientStatus.RealSpeed == 2 ? Common.Constants.MidSpeedPower :
				(this.clientStatus.RealSpeed == 3 ? Common.Constants.HighSpeedPower : 0)));
			using (SqlConnection con = new SqlConnection(new SQLConnector().Builder.ConnectionString)) {
				con.Open();
				SqlCommand cmd = con.CreateCommand();
				cmd.CommandText = "update dt_RoomIDCard set Cost = @a where RoomNum = @b";
				cmd.Parameters.Clear();
				cmd.Parameters.AddWithValue("@b", this.ClientNum);
				cmd.Parameters.AddWithValue("@a", this.clientStatus.Cost);
				int ln = cmd.ExecuteNonQuery();

				if (ln != 1) throw new Exception(String.Format("Unknow error when update cost into db! Room:{0}, Cost{1}", this.ClientNum, this.ClientStatus.Cost));

				LOGGER.InfoFormat("Update room {0} cost {1} into db!", this.ClientNum, this.ClientStatus.Cost);
			}
		}

		private void heartBeat(object source, System.Timers.ElapsedEventArgs e) {

			this.updateCost();

			Common.Package response1;
			if (clientStatus.Speed == (int)ESpeed.Unauthorized) return;
			response1 = new Common.HostRequestPackage((byte)clientStatus.RealSpeed, clientStatus.Cost);
			SendPackage(response1);
		}

		public void Abort() {
			if (streamToClient != null)
				this.streamToClient.Dispose();
			requestThread.Abort();
		}

		private void SendPackage(Common.Package package) {
			try {
				if (package.Cat == -1) return;
				lock (writeLock) {
					byte[] bts = Common.PackageHelper.GetByte(package);
					streamToClient.Write(bts, 0, bts.Length);
					LOGGER.InfoFormat("Send package {0} to host {1}.", package.ToString(),
						clientNum == 0 ? tcpclient.Client.RemoteEndPoint.ToString() : clientNum.ToString());
					LOGGER.DebugFormat("Package: {0}", BitConverter.ToString(bts));
				}
			} catch (Exception e) {
				LOGGER.ErrorFormat("Error when send package to client:{0}, abort client.", this.ClientNum, e);
				requestThread.Abort();
			}
		}

		public void SetTargetTemperature(float temperature) {
			this.clientStatus.TargetTemperature = temperature;
		}

		public void ReceiveHeartBeat(float temperature) {
			this.clientStatus.LastHeartBeat = DateTime.Now;
			this.clientStatus.NowTemperature = temperature;
		}

		public void ChangeMode(IHostServiceCallback cb) {
			var tmp = cb.GetDefaultWorkingState();
			Common.HostModePackage hostModePackage = new Common.HostModePackage(tmp.Item1, tmp.Item2);
			SendPackage(hostModePackage);
			LOGGER.InfoFormat("Host change mode package send mode:{0}, temperature:{1}!", tmp.Item1, tmp.Item2);
		}

		public void ChangeSpeed(int speed) {
			this.ClientStatus.Speed = speed;
			if (this.ClientStatus.RealSpeed >= (int)ESpeed.Small) {
				LOGGER.InfoFormat("Client {0} change speed from {1} to {2}.", ClientNum, ClientStatus.RealSpeed, speed);
				this.ResetRealSpeed();
				new System.Threading.Thread(WriteLog).Start(
							new Tuple<byte, int, int, float, float>(clientNum, 2, this.ClientStatus.RealSpeed, this.ClientStatus.NowTemperature, this.ClientStatus.Cost));
			} else {
				LOGGER.InfoFormat("Client {0} ask for wind!", ClientNum);
				if (callback.SendWind(this.clientNum)) {
					new System.Threading.Thread(WriteLog).Start(
			new Tuple<byte, int, int, float, float>(clientNum, 2, this.ClientStatus.RealSpeed, this.ClientStatus.NowTemperature, this.ClientStatus.Cost));
				}
			}
		}

		public void StopWind() {
			if (this.ClientStatus.RealSpeed <= (int)ESpeed.NoWind) return;
			this.ClientStatus.Speed = (int)ESpeed.NoWind;
			this.ClientStatus.RealSpeed = (int)ESpeed.NoWind;
			callback.StopWind(this.clientNum);
			LOGGER.InfoFormat("Client {0} stop wind!", (int)clientNum);
			new System.Threading.Thread(WriteLog).Start(
			new Tuple<byte, int, int, float, float>(clientNum, 2, this.ClientStatus.RealSpeed, this.ClientStatus.NowTemperature, this.ClientStatus.Cost));
		}

		internal void ResetRealSpeed() {
			this.ClientStatus.RealSpeed = this.ClientStatus.Speed;
		}

		internal bool CanWind() {
			return (ClientStatus.RealSpeed == (int)ESpeed.NoWind) && (clientStatus.Speed >= (int)ESpeed.Small);
		}

		public void ChangeFrequency(byte f) {
			Common.RefreshFrequencyPackage package = new Common.RefreshFrequencyPackage(f);
			SendPackage(package);
			LOGGER.InfoFormat("Host frequency change to {0}!", f);
		}

		public void WriteLog(object obj) {
			Tuple<byte, int, int, float, float> tuple = obj as Tuple<byte, int, int, float, float>;
			byte roomNum = tuple.Item1;
			int opera = tuple.Item2;
			int speed = tuple.Item3;
			float temperature = tuple.Item4;
			float cost = tuple.Item5;
			using (SqlConnection con = new SqlConnection(new SQLConnector().Builder.ConnectionString)) {
				con.Open();
				SqlCommand cmd = con.CreateCommand();
				cmd.CommandText = "insert into dt_Log values(@a,@b,@c,@d,@e,@f)";
				cmd.Parameters.Clear();
				cmd.Parameters.AddWithValue("@a", roomNum);
				cmd.Parameters.AddWithValue("@b", DateTime.Now);
				cmd.Parameters.AddWithValue("@c", opera);
				cmd.Parameters.AddWithValue("@d", speed);
				cmd.Parameters.AddWithValue("@e", temperature);
				cmd.Parameters.AddWithValue("@f", cost);
				int tmp = cmd.ExecuteNonQuery();

				if (tmp == 1)
					LOGGER.DebugFormat("Update db_Log success, [{0},{1},{2},{3},{4}]", roomNum, opera, speed, temperature, cost);
				else
					LOGGER.WarnFormat("Update db_Log fail, [{0},{1},{2},{3},{4}]", roomNum, opera, speed, temperature, cost);
			}
		}
	}
}
