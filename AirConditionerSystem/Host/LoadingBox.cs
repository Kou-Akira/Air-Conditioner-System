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
    public partial class LoadingBox : DMSkin.Main
    {
        private String preText;

        public LoadingBox()
        {
            InitializeComponent();
        }
        private void LoadingBox_Load(object sender, EventArgs e)
        {
            preText = remindText.Text;
        }

        public void delayHide()
        {
            loadIcon.Enabled = false;
            closeBtn.Visible = true;
        }

        public void setText(String str)
        {
            remindText.Text = str;
            closeBtn.Show();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
