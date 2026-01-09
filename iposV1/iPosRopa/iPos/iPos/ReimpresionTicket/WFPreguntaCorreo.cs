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
    public partial class WFPreguntaCorreo : IposForm
    {
        public string strCorreo = "";
        public bool boolEnviar = false;
        public WFPreguntaCorreo()
        {
            InitializeComponent();
        }


        public WFPreguntaCorreo(string correo) : this()
        {
            if (correo != null)
                strCorreo = correo;
            else
                strCorreo = "";
        }

        private void WFPreguntaCorreo_Load(object sender, EventArgs e)
        {
            TBMail.Text = strCorreo;
        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            if(TBMail.Text.Trim() == "")
            {
                return;
            }
            
            strCorreo = TBMail.Text.Trim();
            boolEnviar = true;
            this.Close();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
