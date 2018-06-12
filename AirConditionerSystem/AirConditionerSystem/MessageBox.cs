using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirConditionerSystem
{
    public partial class MessageBox : DMSkin.Main
    {
        private string textContent;
        public MessageBox(string text)
        {
            textContent = text;
            InitializeComponent();
        }

        private void MessageBox_Load(object sender, EventArgs e)
        {
            TextBox.Text = textContent;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
