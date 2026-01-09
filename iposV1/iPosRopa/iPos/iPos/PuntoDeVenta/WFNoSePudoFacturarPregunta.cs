using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos
{
    public partial class WFNoSePudoFacturarPregunta : Form
    {
        public string strRespuesta = "Remision";
        bool m_bSoloReintentarCancelar = false;


        public WFNoSePudoFacturarPregunta()
        {
            InitializeComponent();
        }
            public WFNoSePudoFacturarPregunta(bool bSoloReintentarCancelar) : this()
        {
            m_bSoloReintentarCancelar = bSoloReintentarCancelar;
        }


        private void AsignarRespuesta()
        {

            if(RBReintentar.Checked)
                strRespuesta = "Reintentar";
            else if(RBRemision.Checked)
                strRespuesta = "Remision";
            else
                strRespuesta = "Cancelar";


        }

        private void RBReintentar_CheckedChanged(object sender, EventArgs e)
        {
            AsignarRespuesta();
        }

        private void RBRemision_CheckedChanged(object sender, EventArgs e)
        {
            AsignarRespuesta();
        }

        private void RBCancelar_CheckedChanged(object sender, EventArgs e)
        {
            AsignarRespuesta();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void WFNoSePudoFacturarPregunta_Load(object sender, EventArgs e)
        {
            if(m_bSoloReintentarCancelar)
            {
                RBReintentar.Checked = true;
                RBRemision.Visible = false;
                strRespuesta = "Reintentar";

            }
        }
    }
}
