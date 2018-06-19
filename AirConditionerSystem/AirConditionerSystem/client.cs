using System;
using System.ComponentModel;
using System.Drawing;
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
        private static object clientLock;


        private static TcpClient client;
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
            clientLock = new object();
        }

        private void tcpConnect()
        {
            try
            {
                lock (clientLock)
                {
                    if (client == null || (client != null && !client.Connected))
                    {
                        client = new TcpClient(Constants.IP_ADDRESS, Constants.PORT);
                    }
                    networkStream = client.GetStream();
                }
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
                lock (clientLock)
                {
                    if (client == null || (client != null && !client.Connected))
                    {
                        client = new TcpClient(Constants.IP_ADDRESS, Constants.PORT);
                    }
                    networkStream = client.GetStream();
                }

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
                if (mode == 0)
                {
                    setColdColor();
                }
                else
                {
                    setHotColor();
                }
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
                if (mode == 0)
                {
                    setColdColor();
                }
                else
                {
                    setHotColor();
                }
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
            if (isOff)
            {
                switchBtn.DM_NolImage = mode == 0 ? switchBtn_DM_NolImage : HswitchBtn;
            }
            else
            {
                switchBtn.DM_NolImage = mode == 0 ? CswitchOn : HSwitchOn;
            }
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

        private void lowText_Click(object sender, EventArgs e)
        {
            lowSpeedBtn_Click(sender, e);
        }

        private void midText_Click(object sender, EventArgs e)
        {
            midSpeedBtn_Click(sender, e);
        }

        private void highText_Click(object sender, EventArgs e)
        {
            highSpeedBtn_Click(sender, e);
        }

        private void setHotColor()
        {
            this.BackColor = Color.FromArgb(228, 79, 75);
            mainPanel.BackColor = Color.FromArgb(242, 165, 163);
            SpeedPanel.BackColor = Color.FromArgb(242, 165, 163);
            switchBtn.DM_NolImage = HswitchBtn;
            tpDownBtn.DM_NolImage = HtpDownBtn;
            tpIcon.BackgroundImage = HpictureBox1;
            tpIcon.Image = HpictureBox1;
            tpUpBtn.DM_NolImage = HtpUpBtn;
            speedBtn.DM_NolImage = HspeedBtn;
            lowSpeedBtn.DM_NolImage = HlowSpeedBtn;
            midSpeedBtn.DM_NolImage = HmidSpeedBtn;
            highSpeedBtn.DM_NolImage = HhighSpeedBtn;
            lowText.ForeColor = Color.FromArgb(228, 79, 75);
            midText.ForeColor = Color.FromArgb(228, 79, 75);
            highText.ForeColor = Color.FromArgb(228, 79, 75);
            switchText.ForeColor = Color.FromArgb(228, 79, 75);
            tpBtnText.ForeColor = Color.FromArgb(228, 79, 75);
            speedBtnText.ForeColor = Color.FromArgb(228, 79, 75);
        }

        private void setColdColor()
        {
            this.BackColor = Color.FromArgb(68, 141, 166);
            mainPanel.BackColor = Color.FromArgb(198, 221, 232);
            SpeedPanel.BackColor = Color.FromArgb(198, 221, 232);
            switchBtn.DM_NolImage = switchBtn_BackgroundImage;
            tpDownBtn.DM_NolImage = tpDownBtn_DM_NolImage;
            tpIcon.BackgroundImage = tpIcon_BackgroundImage;
            tpIcon.Image = tpIcon_BackgroundImage;
            tpUpBtn.DM_NolImage = tpUpBtn_DM_NolImage;
            speedBtn.DM_NolImage = speedBtn_BackgroundImage;
            lowSpeedBtn.DM_NolImage = lowSpeedBtn_BackgroundImage;
            midSpeedBtn.DM_NolImage = midSpeedBtn_BackgroundImage;
            highSpeedBtn.DM_NolImage = highSpeedBtn_BackgroundImage;
            lowText.ForeColor = Color.FromArgb(68, 141, 166);
            midText.ForeColor = Color.FromArgb(68, 141, 166);
            highText.ForeColor = Color.FromArgb(68, 141, 166);
            switchText.ForeColor = Color.FromArgb(68, 141, 166);
            tpBtnText.ForeColor = Color.FromArgb(68, 141, 166);
            speedBtnText.ForeColor = Color.FromArgb(68, 141, 166);
        }
    }
}
