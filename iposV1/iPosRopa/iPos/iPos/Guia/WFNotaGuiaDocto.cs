using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos.Guia
{
    public partial class WFNotaGuiaDocto : Form
    {

        public string strNota = "";
        public WFNotaGuiaDocto(string preNota)
        {
            InitializeComponent();
            strNota = preNota;
        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {

            if (TBNota.Text.Trim().Length == 0)
                return;


            strNota = TBNota.Text;
            this.Close();
        }

        private void WFNotaGuiaDocto_Load(object sender, EventArgs e)
        {
            TBNota.Text = strNota;
        }
    }
}
