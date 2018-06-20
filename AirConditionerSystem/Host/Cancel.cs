using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Common;

namespace Host
{
    public partial class Cancel : DMSkin.Main
    {
        LoadingBox mLoadingBox;
        Host host;
        public Cancel(Host h)
        {
            host = h;
            InitializeComponent();
        }

        private void Cancel_Load(object sender, EventArgs e)
        {

        }

        private bool IsRoomNum(string input)
        {
            Regex regex = new Regex("^\\d{3}$");
            return regex.IsMatch(input);
        }

        private void ShutDownButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {

            if ((IsRoomNum(textBox1.Text)))
            {
                if (!host.getHostService().UnRegist((byte)Convert.ToInt32(textBox1.Text)))
                {
                    new MessageBox("注销失败，请重试").ShowDialog();
                }
                else
                {
                    Close();
                }
            }
            else
            {
                MessageBox infoBox = new MessageBox("请输入正确的房间号");
                infoBox.ShowDialog();
                infoBox.Dispose();
            }
        }
    }
}
