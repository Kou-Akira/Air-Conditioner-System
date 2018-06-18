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
            }
            else
            {
				hostService.ShutDown();
                isOff = true;
            }
        }

        private void Host_Load(object sender, EventArgs e)
        {
            context = SynchronizationContext.Current;
        }

        private void logBtn_Click(object sender, EventArgs e)
        {
            new LogForm(this).ShowDialog();
        }
    }
}
