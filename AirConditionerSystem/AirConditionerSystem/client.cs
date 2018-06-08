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
using Common;

namespace AirConditionerSystem
{
    public partial class Client : DMSkin.Main
    {
        public Client()
        {
            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {
           
        }

        private void ShutDownButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tpBtn_Click(object sender, EventArgs e)
        {
            AsynTask asynTask = new AsynTask(new Thread(doWork), callBack);
            asynTask.startTask();
        }

        private void callBack()
        {
            MessageBox.Show("hahahahah");
        }

        private void doWork(Object o)
        {
            ApiClient.sendTurnOnRequest();
            Thread.Sleep(2000);
            ((CallBack)o)();
        }
    }
}
