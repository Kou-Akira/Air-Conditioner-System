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
using System.Text.RegularExpressions;
using Common;

namespace AirConditionerSystem
{
    public partial class login : DMSkin.Main
    {
        private LoadingBox mLoadingBox;
        public login()
        {
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

        private void UserBg_Click(object sender, EventArgs e)
        {

        }

        private void PasswordBg_Click(object sender, EventArgs e)
        {

        }

        private void ShutDownButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }


        private void LoginCallBack(object sender, RunWorkerCompletedEventArgs e)
        {
            if((bool)e.Result)
            {
                mLoadingBox.Hide();
                Close();
            }
            else
            {
                mLoadingBox.setText("Error");
                mLoadingBox.delayHide();
            }

        }

        private void LoginDoWork(object sender, DoWorkEventArgs e)
        {
            bool result;
            result = ApiClient.sendLoginInfo(textBox1.Text, IDTextBox.Text);
            e.Result = result;
        }


        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (IsID(IDTextBox.Text)&&(IsRoomNum(textBox1.Text)))
            {
                AsynTask asynTask = new AsynTask(LoginDoWork, LoginCallBack);//线程
                asynTask.startTask();
                mLoadingBox.ShowDialog();
            }
            else
            {
                MessageBox infoBox = new MessageBox("请输入正确的房间号和身份证号");
                infoBox.ShowDialog();
                infoBox.Dispose();
            }
            
        }

        private void login_Load(object sender, EventArgs e)
        {
            mLoadingBox = new LoadingBox();
        }
    }
}
