using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Common;

namespace Host
{
    public partial class Register : DMSkin.Main
    {
        private LoadingBox mLoadingBox;
        private Host host;
        public Register(Host h)
        {
            host = h;
            InitializeComponent();
        }

        private bool IsID(string input)
        {
            Regex regex = new Regex("^\\d{18}$");
            return regex.IsMatch(input);
        }

        private bool IsRoomNum(string input)
        {
            Regex regex = new Regex("^\\d{3}$");
            return regex.IsMatch(input);
        }

        private void Register_Load(object sender, EventArgs e)
        {
           
        }

        private void ShutDownButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {

            if (IsID(IDTextBox.Text) && (IsRoomNum(textBox1.Text)))
            {
                if (!host.getHostService().Regist((byte)Convert.ToInt32(textBox1.Text), IDTextBox.Text))
                {
                    new MessageBox("注册失败，请重试").ShowDialog();
                }
                else
                {
                    Close();
                }
            }
            else
            {
                MessageBox infoBox = new MessageBox("请输入正确的房间号和身份证号");
                infoBox.ShowDialog();
                infoBox.Dispose();
            }
        }
    }
}
