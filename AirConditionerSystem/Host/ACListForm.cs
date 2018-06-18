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
    public partial class ACListForm : DMSkin.Main, IDataClient
    {
        public SynchronizationContext context;
        private List<Panel> panelList;
        private List<Label> roomNumList;
        private List<PictureBox> iconList;
        private List<Label> tpTextList;
        private List<Label> roomTpTextList;
        private List<Label> nowPayTextList;

        private Host host;
        public ACListForm(Host h)
        {
            host = h;
            InitializeComponent();
        }

        private void ShutDownButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        void IDataClient.onDataRefreshed(ClientStatus[] clientList)
        {
            
        }

        private void onDataRefreshed()
        {
            int count = 0;
            IList<ClientStatus> list = host.getHostService().GetClientStatus(out count);
            for(int i = 0; i < list.Count; i++)
            {
                panelList[i].Visible = true;
                //roomNumList[i].Text = Constants.ROOM_NUM + list[i].
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
        }
    }
}
