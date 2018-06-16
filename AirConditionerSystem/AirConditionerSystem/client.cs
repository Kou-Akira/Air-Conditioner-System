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
        private SynchronizationContext context;
        private Thread listen;

        private bool isOff;
        private int speedMode;
        private bool isClose;
        private int nowTp;
        private int sendType;

        public Client()
        {
            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            TemperatureSimulator.getInstance().startSimulating();
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
            isClose = false;
            nowTp = Constants.DEFAULT_TEMPERATURE;
            tpText.Text = nowTp.ToString() + "℃";
            context = SynchronizationContext.Current;

        }

        private void tcpConnect()
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

        public static void sendPackage(byte[] buffer)
        {
            lock (writeLock)
            {
                networkStream.Write(buffer, 0, buffer.Length);
            }
        }

        private void tcpCallBack(object pac)
        {
            switch (sendType)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    lg.context.Post(lg.packageReceive, pac);
                    break;
                case 3:
                    break;
            }
            sendType = -1;
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
                if (listen == null)
                {
                    listen = new Thread(new ThreadStart(tcpConnect));
                    listen.IsBackground = true;
                    listen.Start();
                }
                sendType = 2;
                lg = new login();
                lg.ShowDialog();
                isOff = false;
            }
            else
            {
                ApiClient.sendClientCloseRequest();
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
            ApiClient.sendSpeedRequest(Constants.LOW_SPEED, TemperatureSimulator.getInstance().getRoomTemperature());
        }

        private void midSpeedBtn_Click(object sender, EventArgs e)
        {
            timeWordker.CancelAsync();
            SpeedPanel.Visible = false;
            ApiClient.sendSpeedRequest(Constants.MID_SPEED, TemperatureSimulator.getInstance().getRoomTemperature());
        }

        private void highSpeedBtn_Click(object sender, EventArgs e)
        {
            timeWordker.CancelAsync();
            SpeedPanel.Visible = false;
            ApiClient.sendSpeedRequest(Constants.HIGH_SPEED, TemperatureSimulator.getInstance().getRoomTemperature());
        }

        private void tpUpBtn_Click(object sender, EventArgs e)
        {
            if (nowTp < Constants.TEMPERATURE_MAX)
            {
                nowTp++;
                tpText.Text = nowTp.ToString() + "℃";
                ApiClient.sendTpChange(nowTp);
            }
        }

        private void tpDownBtn_Click(object sender, EventArgs e)
        {
            if (nowTp > Constants.TEMPERATURE_MIN)
            {
                nowTp--;
                tpText.Text = nowTp.ToString() + "℃";
                ApiClient.sendTpChange(nowTp);
            }
        }
    }
}
