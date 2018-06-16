using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using Common;

namespace AirConditionerSystem
{
    public partial class Client : DMSkin.Main
    {
        private LoadingBox mLoadingBox;
        private BackgroundWorker timeWordker;
        private BackgroundWorker refreshTimeWorker;
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
            TcpConnector.beginConnect(tcpCallBack);
        }

        private void tcpCallBack(object sender, RunWorkerCompletedEventArgs e)
        {
            Package res = (Package)e.Result;
            MessageBox.Show(res.ToString());
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
            while(i < limit && !worker.CancellationPending)
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
            //if ((bool)e.Result)
            //{
            //    mLoadingBox.Hide();
            //    refreshSwitchUI();
            //    isOff = !isOff;
            //    if (isClose)//关闭程序前的关机请求
            //    {
            //        Environment.Exit(0);
            //    }
            //}
            //else
            //{
            //    mLoadingBox.setText("Error");
            //    mLoadingBox.delayHide();
            //}
            mLoadingBox.Hide();
        }

        private void switchDoWork(object sender, DoWorkEventArgs e)
        {
            bool result;
            if (!(bool)e.Argument)
            {
                result = ApiClient.sendTurnOffRequest();
            }
            else
            {
                result = ApiClient.sendTurnOnRequest();
            }
            e.Result = result;
            ApiClient.sendLoginRequest(66,"650204199612181235");
        }

        private void switchBtn_Click(object sender, EventArgs e)
        {
            AsynTask asynTask = new AsynTask(switchDoWork, switchCallBack);
            asynTask.startTask(isOff);
            mLoadingBox.ShowDialog();
        }

        private void speedBtn_Click(object sender, EventArgs e)
        {
            timeWordker.RunWorkerAsync();
            SpeedPanel.Visible = true;
        }

        private void doRefreshSpeedUI()
        {

        }

        private void speedCallBack(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)//暂时用cancel参数表示是否成功
            {
                //set speed success
                mLoadingBox.Hide();
                speedMode = (int)e.Result;
                doRefreshSpeedUI();               
            }
            else
            {
                //failed
                mLoadingBox.setText("Error");
                mLoadingBox.delayHide();
            }
        }

        private void speedDoWork(object sender, DoWorkEventArgs e)
        {
            e.Cancel = !ApiClient.sendSpeedMode((int)e.Argument);
            e.Result = (int)e.Argument;
        }

        private void lowSpeedBtn_Click(object sender, EventArgs e)
        {
            timeWordker.CancelAsync();
            SpeedPanel.Visible = false;
            AsynTask asynTask = new AsynTask(speedDoWork, speedCallBack);
            asynTask.startTask(Constants.LOW_SPEED);
            mLoadingBox.ShowDialog();
        }

        private void midSpeedBtn_Click(object sender, EventArgs e)
        {
            timeWordker.CancelAsync();
            SpeedPanel.Visible = false;
            AsynTask asynTask = new AsynTask(speedDoWork, speedCallBack);
            asynTask.startTask(Constants.MID_SPEED);
            mLoadingBox.ShowDialog();
        }

        private void highSpeedBtn_Click(object sender, EventArgs e)
        {
            timeWordker.CancelAsync();
            SpeedPanel.Visible = false;
            AsynTask asynTask = new AsynTask(speedDoWork, speedCallBack);
            asynTask.startTask(Constants.HIGH_SPEED);
            mLoadingBox.ShowDialog();
        }

        private void tpUpBtn_Click(object sender, EventArgs e)
        {
            if (nowTp < Constants.TEMPERATURE_MAX)
            {
                nowTp++;
                tpText.Text = nowTp.ToString() + "℃";
            }
        }

        private void tpDownBtn_Click(object sender, EventArgs e)
        {
            if (nowTp > Constants.TEMPERATURE_MIN)
            {
                nowTp--;
                tpText.Text = nowTp.ToString() + "℃";
            }
        }
    }
}
