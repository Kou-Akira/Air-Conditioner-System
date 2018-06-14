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
        public Host()
        {
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
    }
}
