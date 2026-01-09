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
    public partial class WFCuentaPago : Form
    {
        public string strCuentaPago = "";
        public WFCuentaPago()
        {
            InitializeComponent();
        }
        public WFCuentaPago(string defaultCuentaPago) : this()
        {
            TBCuentaPago.Text = defaultCuentaPago !=  null ? defaultCuentaPago : "";
        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            if (TBCuentaPago.Text.Trim().Length == 0)
                return;


            strCuentaPago = TBCuentaPago.Text;
            this.Close();
        }
    }
}
