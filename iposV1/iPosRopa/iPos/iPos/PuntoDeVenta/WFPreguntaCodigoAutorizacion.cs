using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iPosData;
using iPosBusinessEntity;

namespace iPos
{
    public partial class WFPreguntaCodigoAutorizacion : Form
    {
        public CPERSONABE m_supervisorBE = null;
        public WFPreguntaCodigoAutorizacion()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Trim().Length == 0)
                return;

            CUSUARIO_PERFILD userPerD = new CUSUARIO_PERFILD();
            CPERSONAD userD = new CPERSONAD();
            CPERSONABE userBE = new CPERSONABE();

            userBE.ICODIGOAUTORIZACION = textBox1.Text;
            userBE = userD.seleccionarPERSONAxCODIGOAUTORIZACION(userBE, null);
            if (userBE == null)
            {
                MessageBox.Show("codigo de autorizacion no existe");
                return;
            }


            m_supervisorBE = userBE;
            this.Close();
        }

        private void BTCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
