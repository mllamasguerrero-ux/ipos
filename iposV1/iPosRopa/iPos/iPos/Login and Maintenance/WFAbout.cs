using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPos
{
    public partial class WFAbout : IposForm
    {
        public WFAbout()
        {
            InitializeComponent();
        }

        private void WFAbout_Load(object sender, EventArgs e)
        {
            LBVersion.Text = "1309.7045";
        }
    }
}
