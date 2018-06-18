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


        private TcpClient client;
        private static NetworkStream networkStream;
        private static Object writeLock = new Object();
        public SynchronizationContext context;
        private Thread listen;

        private bool isOff;
        private bool isLogin;
        private bool isClose;
        private int nowTp;
        public int mode;
        public int speed;

        public static int sendType;

        public Client()
        {
            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            TemperatureSimulator.getInstance(this).startSimulating();
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
            tpText.Text = nowTp.ToString() + "℃";
            context = SynchronizationContext.Current;

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
            int tp = (int)o;
            roomTpText.Text = Constants.ROOM_TP + tp.ToString();
        }

        public static void sendPackage(byte[] buffer)
        {
            lock (writeLock)
            {
                networkStream.Write(buffer, 0, buffer.Length);
            }
        }

        private void tcpCallBack(object pac)
        {
            Package p = pac as Package;
            if (sendType == 2 && (p.Cat == 0 || p.Cat == 1))
            {
                lg.context.Post(lg.packageReceive, pac);
                sendType = -1;
                return;
            }
            
            if(p.Cat == 7)
            {
                HostRequestPackage res = p as HostRequestPackage;
                refreshUI(res.Speed, res.Cost);
            }
        }

        private void refreshUI(int speed, float cost)
        {
            mainIcon.BackgroundImage = Host.Utils.getRuningImage((Host.ServiceMode)mode, (Host.ESpeed)speed);
            nowPayText.Text = Constants.NOW_PAYMENT + cost.ToString();
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
            }
            else
            {
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
                speed = Constants.LOW_SPEED;
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
                speed = Constants.MID_SPEED;
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
                speed = Constants.HIGH_SPEED;
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
