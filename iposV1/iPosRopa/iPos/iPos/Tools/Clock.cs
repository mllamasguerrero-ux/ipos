
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
namespace iPos.Tools
{
    public partial class Clock : UserControl
    {
        public Clock()
        {
            InitializeComponent();
        }
        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            lblClockText.Text = DateTime.Now.ToLongTimeString();
        }
        private void Clock_Load(object sender, EventArgs e)
        {
            tmrRefresh.Start();
        }
    }
}
