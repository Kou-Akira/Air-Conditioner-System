using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Host
{
    public partial class Host : DMSkin.Main
    {
        IHostService hostService;
        private bool isOff;

        public Host()
        {
            isOff = true;
            hostService = new HostService();
            InitializeComponent();
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
            new ACListForm().ShowDialog();
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
    }
}
