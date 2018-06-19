using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Host
{
    public partial class Host : DMSkin.Main
    {
        IHostService hostService;
        private bool isOff;
        public SynchronizationContext context;
        public ServiceMode mode;
        private BackgroundWorker refreshTimeWorker;

        public Host()
        {
            isOff = true;
            hostService = new HostService();
            InitializeComponent();
        }

        public IHostService getHostService()
        {
            return hostService;
        }

        private void settingBtn_Click(object sender, EventArgs e)
        {
            new SettingForm().ShowDialog();
        }

        private void ShutDownButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void watchBtn_Click(object sender, EventArgs e)
        {
            new ACListForm(this).ShowDialog();
        }

        private void switchBtn_Click(object sender, EventArgs e)
        {
            if (isOff)
            {
                hostService.TurnOn();
                isOff = false;
                mode = ServiceMode.COLD;
                workStateText.Text = Common.Constants.WORKING_STATE + "运行中";
                workModeText.Text = Common.Constants.WORKING_MODE_STR + "制冷";
            }
            else
            {
                if (hostService.ShutDown())
                {
                    workStateText.Text = Common.Constants.WORKING_STATE + "已停机";
                    workModeText.Text = Common.Constants.WORKING_MODE_STR + "--";
                    isOff = true;
                }
                else
                {
                    new MessageBox("从机正在服务，无法关闭").ShowDialog();
                }
            }
        }

        private void registBtn_Click(object sender, EventArgs e)
        {
            new Register(this).ShowDialog();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            new Cancel(this).ShowDialog();
        }

        private void payBtn_Click(object sender, EventArgs e)
        {
            new Gathering(this).ShowDialog();
        }

        private void Host_Load(object sender, EventArgs e)
        {
            context = SynchronizationContext.Current;
            refreshTimeWorker = new BackgroundWorker();
            refreshTimeWorker.DoWork += getSysTime;
            refreshTimeWorker.ProgressChanged += refreshTimeText;
            refreshTimeWorker.WorkerReportsProgress = true;
            refreshTimeWorker.RunWorkerAsync();
        }

        private void logBtn_Click(object sender, EventArgs e)
        {
            new LogForm(this).ShowDialog();
        }

        private void coldBtn_Click(object sender, EventArgs e)
        {
            if (!isOff && mode != ServiceMode.COLD)
            {
                hostService.SettModle(ServiceMode.COLD);
                mode = ServiceMode.COLD;
                workModeText.Text = Common.Constants.WORKING_MODE_STR + "制冷";
            }

        }

        private void heatBtn_Click(object sender, EventArgs e)
        {
            if (!isOff && mode != ServiceMode.HOT)
            {
                hostService.SettModle(ServiceMode.HOT);
                mode = ServiceMode.HOT;
                workModeText.Text = Common.Constants.WORKING_MODE_STR + "制热";
            }
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
    }
}
