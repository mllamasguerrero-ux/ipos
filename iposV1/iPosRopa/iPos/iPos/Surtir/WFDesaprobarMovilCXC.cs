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
    public partial class WFDesaprobarMovilCXC : Form
    {
        public bool m_bSeleccionCancel = false;
        public bool cancelProceso = true;
        public WFDesaprobarMovilCXC()
        {
            InitializeComponent();
        }

        private void btnDesaprobar_Click(object sender, EventArgs e)
        {
            m_bSeleccionCancel = RBCancel.Checked;
            cancelProceso = false;
            this.Close();
        }
    }
}
