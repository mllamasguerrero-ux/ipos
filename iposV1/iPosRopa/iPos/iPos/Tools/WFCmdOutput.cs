using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos.Tools
{
    public partial class WFCmdOutput : Form
    {
        private string cmdOutput;
        public WFCmdOutput(string cmdOutput)
        {
            InitializeComponent();
            this.cmdOutput = cmdOutput;
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void WFCmdOutput_Load(object sender, EventArgs e)
        {
            cmdOutputTextBox.Text = cmdOutput;
        }
    }
}
