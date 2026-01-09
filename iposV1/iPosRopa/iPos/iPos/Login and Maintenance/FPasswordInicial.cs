using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iPosData;
using iPosBusinessEntity;
namespace iPos
{
    public partial class FPasswordInicial : IposForm
    {
        long m_personaId;
        bool m_bInicial;
        bool m_bPreguntarAnterior;
        public FPasswordInicial()
        {
            InitializeComponent();
            this.US_PASSWORDAntTextBox.Visible = false;
        }


        public FPasswordInicial(long personaId, bool bInicial, bool bPreguntarAnterior)
        {
            InitializeComponent();
            m_personaId = personaId;
            m_bInicial = bInicial;
            m_bPreguntarAnterior = bPreguntarAnterior;
            if (bInicial || !m_bPreguntarAnterior)
            {
                this.US_PASSWORDAntTextBox.Visible = false;
                this.US_PASSWORDAntLabel.Visible = false;
                this.US_PASSWORDTextBox.Focus();
            }
            else
            {
                this.US_PASSWORDAntTextBox.Focus();
            }
        }
        private void BTSetPassword_Click(object sender, EventArgs e)
        {
            CPERSONABE USUARIOSBE = new CPERSONABE();
            CPERSONAD USUARIOSD = new CPERSONAD();
            USUARIOSBE.IID = this.m_personaId;
            USUARIOSBE = USUARIOSD.seleccionarPERSONA(USUARIOSBE, null);
            if (USUARIOSBE == null)
            {
                MessageBox.Show("El usuario no existe");
                return;
            }
            if (!m_bInicial && m_bPreguntarAnterior)
            {
                if (iPos.EncDec.Decrypt(USUARIOSBE.ICLAVEACCESO, "DryHit" + USUARIOSBE.IUSERNAME.Trim()) != this.US_PASSWORDAntTextBox.Text)
                {
                    MessageBox.Show("El password anterior no concuerda");
                    return;
                }
                USUARIOSBE.IRESET_PASS = 0;
            }
            else
            {
                USUARIOSBE.IRESET_PASS = 1;
            }
            if (this.US_PASSWORDTextBox.Text != this.US_PASSWORDConfTextBox.Text)
            {
                MessageBox.Show("El password de confirmacion no concuerda");
                return;
            }

            USUARIOSBE.ICLAVEACCESO = this.US_PASSWORDTextBox.Text;
            string encryPass = iPos.EncDec.Encrypt(USUARIOSBE.ICLAVEACCESO, "DryHit" + USUARIOSBE.IUSERNAME.Trim());
            USUARIOSBE.ICLAVEACCESO = encryPass;

            USUARIOSD.CambiarPERSONAUSUARIO_PASS_D(USUARIOSBE, USUARIOSBE, null);
            if (USUARIOSD.IComentario == "" || USUARIOSD.IComentario == null)
            {
                
                MessageBox.Show("El registro se ha cambiado");
                this.Close();
            }
            else
            {
                MessageBox.Show("ERRORES: " + USUARIOSD.IComentario.Replace("%", "\n"));
                return ;
            }
        }
    }
}
