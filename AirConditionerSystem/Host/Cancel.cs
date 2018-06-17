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
        public Cancel()
        {
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

        private bool registerOP(string roomNum)//数据库操作
        {

            return true;
        }

        private void ShutDownButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginCallBack(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((bool)e.Result)
            {
                mLoadingBox.setText("注销成功");
                Close();
            }
            else
                mLoadingBox.setText("加载失败");
        }

        private void LoginDoWork(object sender, DoWorkEventArgs e)
        {
            bool result = true;
            //ApiClient.sendLoginRequest(Convert.ToInt32(textBox1.Text), IDTextBox.Text);
            result = registerOP(textBox1.Text);
            e.Result = result;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {

            if ((IsRoomNum(textBox1.Text)))
            {
                AsynTask asynTask = new AsynTask(LoginDoWork, LoginCallBack);//线程
                asynTask.startTask();
                mLoadingBox = new LoadingBox();
                mLoadingBox.ShowDialog();
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
