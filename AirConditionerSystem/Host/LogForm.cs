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
    public partial class LogForm : DMSkin.Main
    {
        private Host host;
        private const int DAY_LIST = 0;
        private const int WEEK_LIST = 1;
        private const int MONTH_LIST = 2;

        public LogForm(Host h)
        {
            host = h;
            InitializeComponent();
        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            SheetLoad(DAY_LIST);
        }

        private void SheetLoad(int mode)
        {
            ////add header
            //DataGridViewRow row = new DataGridViewRow();
            //int index = logSheet.Rows.Add(row);
            //logSheet.Rows[0].Cells[0].Value = 
            //logSheet.Rows[0].Cells[1].Value = 
            //logSheet.Rows[index].Height = 68;

            //IDictionary<byte, List<HostLog>> list = host.getHostService().GetLog(DateTime.MinValue,DateTime.MaxValue);

            //int i = 1;
            //foreach (KeyValuePair<byte, List<HostLog>> room in list)
            //{
            //    List<HostLog> logList = room.Value;
            //    foreach(HostLog lg in logList)
            //    {
            //        i++;
            //        DataGridViewRow row = new DataGridViewRow();
            //        int index = logSheet.Rows.Add(row);
            //        logSheet.Rows[i].Cells[0].Value = (i + 1).ToString();
            //        logSheet.Rows[i].Cells[1].Value = list[i];
            //        logSheet.Rows[index].Height = 68;
            //    }
            //}
        
            //while (i < 8)
            //{
            //    DataGridViewRow row = new DataGridViewRow();
            //    int index = logSheet.Rows.Add(row);
            //    logSheet.Rows[i].Cells[0].Value = "";
            //    logSheet.Rows[i].Cells[1].Value = "";
            //    logSheet.Rows[index].Height = 68;
            //    i++;
            //}
            //logSheet.ClearSelection();
            //logSheet.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
