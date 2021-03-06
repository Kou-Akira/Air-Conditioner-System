﻿using System;
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
        public SynchronizationContext context;
        private Client client;
        public login(Client c)
        {
            client = c;
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
        }

        private void LoginDoWork(object sender, DoWorkEventArgs e)
        {
            ApiClient.sendLoginRequest(Convert.ToInt32(textBox1.Text), IDTextBox.Text);
        }


        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (IsID(IDTextBox.Text) && (IsRoomNum(textBox1.Text)))
            {
                client.beginThread();
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

        private void login_Load(object sender, EventArgs e)
        {
            context = SynchronizationContext.Current;
            if(client.mode == 1)
            {
                this.BackColor = Color.FromArgb(228, 79, 75);
                mainPanel.BackColor = Color.FromArgb(242, 165, 163);
                LoginButton.BackColor =Color.FromArgb(242, 165, 163);
                LoginButton.ForeColor = Color.FromArgb(228, 79, 75);
                LoginButton.FlatAppearance.BorderColor = Color.FromArgb(228, 79, 75);
                label1.ForeColor = label2.ForeColor = Color.FromArgb(228, 79, 75);
                label1.BackColor = label2.BackColor = Color.FromArgb(242, 165, 163);

            }
        }

        public void packageReceive(object pac)
        {
            Package pack = (Package)pac;
            if (pack.Cat == 1)//success
            {
                client.roomNum = textBox1.Text.Trim();
                mLoadingBox.Close();
                Close();
            }
            else if (pack.Cat == 0)//failed
            {
                mLoadingBox.setText("Error");
                mLoadingBox.delayHide();
                Client.sendType = 2;
                client.closeThread();
            }
        }
    }
}
