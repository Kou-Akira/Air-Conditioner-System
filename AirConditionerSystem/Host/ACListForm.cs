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

namespace Host
{
    public partial class ACListForm : DMSkin.Main, IDataClient
    {
        public SynchronizationContext context;

        public ACListForm()
        {
            InitializeComponent();
        }

        private void ShutDownButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        void IDataClient.onDataRefreshed(ClientStatus[] clientList)
        {
            
        }

        private void ACListForm_Load(object sender, EventArgs e)
        {
            context = SynchronizationContext.Current;
        }
    }
}
