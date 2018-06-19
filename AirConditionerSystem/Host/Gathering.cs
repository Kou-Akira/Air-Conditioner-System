using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Common;

namespace Host
{
    public partial class Gathering : DMSkin.Main
    {
        LoadingBox mLoadingBox;
        Host host;
        private bool hasSearch;
        private String pre;
        public Gathering(Host h)
        {
            pre = "";
            host = h;
            hasSearch = false;
            InitializeComponent();
        }

        private bool IsRoomNum(string input)
        {
            Regex regex = new Regex("^\\d{3}$");
            return regex.IsMatch(input);
        }

        private bool IsMoney(string input)
        {
            Regex regex = new Regex("^([1-9][0-9]*\\.\\d{2})|([1-9][0-9]*\\.\\d{1})|([1-9][0-9]*)$");
            return regex.IsMatch(input);
        }

     
        private void ShutDownButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {

            if (hasSearch && pre.Equals(textBox1.Text) && (IsRoomNum(textBox1.Text)))
            {
                if (!host.getHostService().CheckOut((byte)Convert.ToInt32(textBox1.Text)))
                {
                    new MessageBox("支付失败，请重试").ShowDialog();
                }
                else
                {
                    Close();
                }
            }
            else
            {
                MessageBox infoBox = new MessageBox("请输入正确的房间号和金额\n金额最多有两位小数");
                infoBox.ShowDialog();
                infoBox.Dispose();
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            //payText.Text = +"元";
            pre = textBox1.Text;
        }
    }
}
