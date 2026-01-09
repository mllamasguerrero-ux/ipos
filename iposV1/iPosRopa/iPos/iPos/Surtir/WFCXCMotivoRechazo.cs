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
    public partial class WFCXCMotivoRechazo : Form
    {
        public string strMotivoRechazo = "CXC ";
        public bool cancelProceso = true;
        public WFCXCMotivoRechazo()
        {
            InitializeComponent();
        }

        private void btnDesaprobar_Click(object sender, EventArgs e)
        {
            strMotivoRechazo = "CXC " + textBox1.Text;
            cancelProceso = false;
            this.Close();
        }
    }
}
