using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos.Abonos
{
    public partial class WFNotaPago : Form
    {

        public string strNotaPago = "";
        public WFNotaPago()
        {
            InitializeComponent();
        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {

            if (TBNotaPago.Text.Trim().Length == 0)
                return;


            strNotaPago = TBNotaPago.Text;
            this.Close();
        }
    }
}
