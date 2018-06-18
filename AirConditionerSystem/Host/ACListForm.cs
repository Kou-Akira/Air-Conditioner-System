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

namespace Host
{
    public partial class ACListForm : DMSkin.Main
    {
        public SynchronizationContext context;
        private bool isInterrupt;
        private List<Panel> panelList;
        private List<Label> roomNumList;
        private List<PictureBox> iconList;
        private List<Label> tpTextList;
        private List<Label> roomTpTextList;
        private List<Label> nowPayTextList;
        private const int REFRESH_INTERVAL = 500;

        private Host host;
        public ACListForm(Host h)
        {
            host = h;
            isInterrupt = false;
            InitializeComponent();
        }

        private void ShutDownButton_Click(object sender, EventArgs e)
        {
            isInterrupt = true;
            Close();
        }

        private void onDataRefreshed()
        {
            int count = 0;
            IDictionary<byte, ClientStatus> list = host.getHostService().GetClientStatus(out count);
            queueText.Text = Constants.WAITING_CONN_COUNT + count.ToString();
            int i = 0;
            foreach (KeyValuePair<byte, ClientStatus> client in list)
            {
                i++;
                if (i >= 3) break;
                panelList[i].Visible = true;
                roomNumList[i].Text = Constants.ROOM_NUM + client.Key.ToString();
                iconList[i].BackgroundImage = Utils.getRuningImage(host.mode, (ESpeed)(client.Value.Speed));
                tpTextList[i].Text = ((int)(client.Value.TargetTemperature)).ToString() + "℃";
                roomTpTextList[i].Text = Constants.ROOM_TP + client.Value.NowTemperature.ToString();
                nowPayTextList[i].Text = Constants.NOW_PAYMENT + client.Value.Cost.ToString();
            }
            for (; i < 3; i++)
            {
                panelList[i].Visible = false;
            }
        }

        private void ACListForm_Load(object sender, EventArgs e)
        {
            context = SynchronizationContext.Current;
            panelList = new List<Panel>();
            roomNumList = new List<Label>();
            iconList = new List<PictureBox>();
            tpTextList = new List<Label>();
            roomTpTextList = new List<Label>();
            nowPayTextList = new List<Label>();


            panelList.Add(panel0);
            panelList.Add(panel1);
            panelList.Add(panel2);
            roomNumList.Add(roomText0);
            roomNumList.Add(roomText1);
            roomNumList.Add(roomText1);
            iconList.Add(stateIcon0);
            iconList.Add(stateIcon1);
            iconList.Add(stateIcon2);
            tpTextList.Add(tpText0);
            tpTextList.Add(tpText1);
            tpTextList.Add(tpText2);
            roomTpTextList.Add(roomTpText0);
            roomTpTextList.Add(roomTpText1);
            roomTpTextList.Add(roomTpText2);
            nowPayTextList.Add(nowPayText0);
            nowPayTextList.Add(nowPayText1);
            nowPayTextList.Add(nowPayText2);

            onDataRefreshed();

            Thread refresh = new Thread(new ThreadStart(refreshDoWork));
            refresh.IsBackground = true;
            refresh.Start();
        }


        private void refreshHandle(object o)
        {
            onDataRefreshed();
        }

        private void refreshDoWork()
        {
            while (!isInterrupt)
            {
                Thread.Sleep(REFRESH_INTERVAL);
                context.Post(refreshHandle, null);
            }
        }
    }
}
