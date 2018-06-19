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
            }
            else
            {
				hostService.ShutDown();
                isOff = true;
            }
        }

        private void registBtn_Click(object sender, EventArgs e)
        {
            new Register().ShowDialog();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            new Cancel().ShowDialog();
        }

        private void payBtn_Click(object sender, EventArgs e)
        {
            new Gathering().ShowDialog();
        }

        private void Host_Load(object sender, EventArgs e)
        {
            context = SynchronizationContext.Current;
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
            }
            
        }

        private void heatBtn_Click(object sender, EventArgs e)
        {
            if (!isOff && mode != ServiceMode.HOT)
            {
                hostService.SettModle(ServiceMode.HOT);
                mode = ServiceMode.HOT;
            }
        }
    }
}
