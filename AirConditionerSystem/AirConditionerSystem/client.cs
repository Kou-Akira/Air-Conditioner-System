using System;
using System.ComponentModel;
using System.Net.Sockets;
using System.Threading;
using Common;

namespace AirConditionerSystem
{
    public partial class Client : DMSkin.Main
    {
        private LoadingBox mLoadingBox;
        private BackgroundWorker timeWordker;
        private BackgroundWorker refreshTimeWorker;
        private login lg;
        private HeartbeatpacketSender heartbeatpacketSender;

        private TcpClient client;
        private static NetworkStream networkStream;
        private static Object writeLock = new Object();
        public SynchronizationContext context;
        private Thread listen;

        private bool isOff;
        private bool isLogin;
        private bool isClose;
        public String roomNum;
        public int nowTp;
        public int mode;
        public int speed;

        public static int sendType;

        public Client()
        {
            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            heartbeatpacketSender = new HeartbeatpacketSender(this);
            mLoadingBox = new LoadingBox();
            timeWordker = new BackgroundWorker();
            refreshTimeWorker = new BackgroundWorker();
            timeWordker.WorkerSupportsCancellation = true;
            timeWordker.DoWork += panelWait;
            timeWordker.RunWorkerCompleted += panelCallBack;
            refreshTimeWorker.DoWork += getSysTime;
            refreshTimeWorker.ProgressChanged += refreshTimeText;
            refreshTimeWorker.WorkerReportsProgress = true;
            refreshTimeWorker.RunWorkerAsync();
            isOff = true;
            isLogin = false;
            isClose = false;
            nowTp = Constants.DEFAULT_TEMPERATURE;
            roomTpText.Text = Constants.ROOM_TP + Constants.DEFAULT_TEMPERATURE.ToString() + "℃";
            context = SynchronizationContext.Current;
            speed = Constants.NONE_SPEED;
        }

        private void tcpConnect()
        {
            try
            {
                if (client == null || (client != null && !client.Connected))
                {
                    client = new TcpClient(Constants.IP_ADDRESS, Constants.PORT);
                }
                networkStream = client.GetStream();
                while (true)
                {
                    //get package
                    Package req = PackageHelper.GetRequest(networkStream);
                    context.Post(tcpCallBack, req);
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                if (networkStream != null)
                    networkStream.Dispose();
                if (client != null)
                    client.Close();
            }

        }

        public void roomTpCallBack(object o)
        {
            int tp = Convert.ToInt32(o);
            roomTpText.Text = Constants.ROOM_TP + tp.ToString() + "℃";
            if (nowTp == tp)
            {
                ApiClient.sendStopSpeedRequest(tp);
                speed = Constants.NONE_SPEED;
                mainIcon.BackgroundImage = Host.Utils.getRuningImage((Host.ServiceMode)mode, (Host.ESpeed)speed);
            }
        }

        public static void sendPackage(byte[] buffer)
        {
            lock (writeLock)
            {
                try
                {
                    networkStream.Write(buffer, 0, buffer.Length);
                }
                catch (Exception e)
                {
                    new MessageBox("主机连接已关闭").ShowDialog();
                    Environment.Exit(0);
                }

            }
        }

        private void tcpCallBack(object pac)
        {
            Package p = pac as Package;
            if (p.Cat == 1)
            {
                HostAckPackage ack = p as HostAckPackage;
                mainIcon.BackgroundImage = Host.Utils.getRuningImage((Host.ServiceMode)ack.Mode, (Host.ESpeed)speed);
                tpText.Text = ack.Temperature.ToString("0") + "℃";
                nowTp = (int)ack.Temperature;
                mode = ack.Mode;
            }
            else if (p.Cat == 7)
            {
                HostRequestPackage res = p as HostRequestPackage;
                speed = res.Speed;
                refreshUI(res.Speed, res.Cost);
            }
            else if (p.Cat == 10)
            {
                RefreshFrequencyPackage fr = p as RefreshFrequencyPackage;
                heartbeatpacketSender.resetTimer(fr.Frequency);
            }
            else if (p.Cat == 3)
            {
                HostModePackage md = p as HostModePackage;
                mode = md.Mode;
                speed = Constants.NONE_SPEED;
                mainIcon.BackgroundImage = Host.Utils.getRuningImage((Host.ServiceMode)mode, (Host.ESpeed)speed);
                nowTp = Constants.HotTemperatureDefault;
                tpText.Text = nowTp.ToString() + "℃";
            }

            if (sendType == 2 && (p.Cat == 0 || p.Cat == 1))
            {
                lg.context.Post(lg.packageReceive, pac);
                sendType = -1;
                return;
            }




        }

        private void refreshUI(int speed, float cost)
        {
            mainIcon.BackgroundImage = Host.Utils.getRuningImage((Host.ServiceMode)mode, (Host.ESpeed)speed);
            nowPayText.Text = Constants.NOW_PAYMENT + cost.ToString("0.0") + "元";
        }

        private void getSysTime(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker myworker = (BackgroundWorker)sender;
            while (true)
            {
                myworker.ReportProgress(1, DateTime.Now.ToLongTimeString());
                System.Threading.Thread.Sleep(1000);
            }
        }

        private void refreshTimeText(object sender, ProgressChangedEventArgs e)
        {
            timeText.Text = e.UserState.ToString();
        }

        private void ShutDownButton_Click(object sender, EventArgs e)
        {
            if (isOff)
            {
                Environment.Exit(0);
            }
            else
            {
                isClose = true;
                switchBtn_Click(this, null);
            }
        }

        private void panelWait(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            int limit = Constants.PANEL_INTERVAL / 100;
            int i = 0;
            while (i < limit && !worker.CancellationPending)
            {
                Thread.Sleep(100);
                i++;
            }
            if (i < limit)
            {
                e.Cancel = true;
            }
        }

        private void panelCallBack(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                SpeedPanel.Visible = false;
            }
        }

        private void refreshSwitchUI()
        {

        }

        public void beginThread()
        {
            listen = new Thread(new ThreadStart(tcpConnect));
            listen.IsBackground = true;
            listen.Start();
        }

        public void closeThread()
        {
            if (listen != null)
            {
                listen.Abort();
            }
        }

        private void switchCallBack(object sender, RunWorkerCompletedEventArgs e)
        {
            roomText.Text = "Room " + roomNum;
            if (isClose)
            {
                Environment.Exit(0);
            }
        }

        private void switchDoWork(object sender, DoWorkEventArgs e)
        {
            if ((bool)e.Argument)
            {
                sendType = 2;
                lg = new login(this);
                lg.ShowDialog();
                isOff = false;
                TemperatureSimulator.getInstance(this).startSimulating();
                heartbeatpacketSender.startSend();
            }
            else
            {
                TemperatureSimulator.getInstance(this).stopSimulate();
                heartbeatpacketSender.stopSend();
                ApiClient.sendClientCloseRequest(TemperatureSimulator.getInstance(this).getRoomTemperature());
                isOff = true;
                listen.Abort();
            }
        }

        private void switchBtn_Click(object sender, EventArgs e)
        {
            AsynTask asynTask = new AsynTask(switchDoWork, switchCallBack);
            asynTask.startTask(isOff);
        }

        private void speedBtn_Click(object sender, EventArgs e)
        {
            timeWordker.RunWorkerAsync();
            SpeedPanel.Visible = true;
        }

        private void lowSpeedBtn_Click(object sender, EventArgs e)
        {
            timeWordker.CancelAsync();
            SpeedPanel.Visible = false;
            if (shouldRequestSpeed())
            {
                ApiClient.sendSpeedRequest(Constants.LOW_SPEED, TemperatureSimulator.getInstance(this).getRoomTemperature());
                mainIcon.BackgroundImage = Host.Utils.getRuningImage((Host.ServiceMode)mode, Host.ESpeed.Small);
                //speed = Constants.LOW_SPEED;
            }
        }

        private void midSpeedBtn_Click(object sender, EventArgs e)
        {
            timeWordker.CancelAsync();
            SpeedPanel.Visible = false;
            if (shouldRequestSpeed())
            {
                ApiClient.sendSpeedRequest(Constants.MID_SPEED, TemperatureSimulator.getInstance(this).getRoomTemperature());
                mainIcon.BackgroundImage = Host.Utils.getRuningImage((Host.ServiceMode)mode, Host.ESpeed.Mid);
                //speed = Constants.MID_SPEED;
            }
        }

        private void highSpeedBtn_Click(object sender, EventArgs e)
        {
            timeWordker.CancelAsync();
            SpeedPanel.Visible = false;
            if (shouldRequestSpeed())
            {
                ApiClient.sendSpeedRequest(Constants.HIGH_SPEED, TemperatureSimulator.getInstance(this).getRoomTemperature());
                mainIcon.BackgroundImage = Host.Utils.getRuningImage((Host.ServiceMode)mode, Host.ESpeed.Large);
                //speed = Constants.HIGH_SPEED;
            }
        }

        private void tpUpBtn_Click(object sender, EventArgs e)
        {
            if (nowTp < (mode == 0 ? Constants.ColdMaxTemperature : Constants.HotMaxTemperature))
            {
                nowTp++;
                tpText.Text = nowTp.ToString() + "℃";
                ApiClient.sendTpChange(nowTp);
            }
        }

        private void tpDownBtn_Click(object sender, EventArgs e)
        {
            if (nowTp > (mode == 0 ? Constants.ColdMinTemperature : Constants.HotMinTemperature))
            {
                nowTp--;
                tpText.Text = nowTp.ToString() + "℃";
                ApiClient.sendTpChange(nowTp);
            }
        }

        private bool shouldRequestSpeed()
        {
            if (mode == 0 && TemperatureSimulator.getInstance(this).getRoomTemperature() <= nowTp)
            {
                return false;
            }
            else if (mode == 1 && TemperatureSimulator.getInstance(this).getRoomTemperature() >= nowTp)
            {
                return false;
            }
            return true;
        }
    }
}
