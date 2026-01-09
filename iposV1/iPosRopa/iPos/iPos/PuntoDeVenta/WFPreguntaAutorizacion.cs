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
    public partial class WFPreguntaAutorizacion : IposForm
    {
        public CPERSONABE m_supervisorBE;
        public bool m_bIsSupervisor;
        public bool m_bIsAdministrador;
        public bool m_bPassValido;
        public CPERSONABE m_userBE = null;

        public bool m_requiereAdminOrSupervisor = true;


        public WFPreguntaAutorizacion()
        {
            InitializeComponent();
            m_supervisorBE = null;
            m_bIsSupervisor = false;
            m_bIsAdministrador = false;
            m_bPassValido = false;
            m_requiereAdminOrSupervisor = true;
        }

        public WFPreguntaAutorizacion(bool requiereAdminOrSupervisor) : this()
        {
            m_requiereAdminOrSupervisor = requiereAdminOrSupervisor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            CUSUARIO_PERFILD userPerD = new CUSUARIO_PERFILD();        
            CPERSONAD userD = new CPERSONAD();
            CPERSONABE userBE = new CPERSONABE();

            userBE.IUSERNAME = TBNameUser.Text;
            userBE = userD.seleccionarPERSONAxNOMBRE(userBE, null);
            if (userBE == null)
            {
                MessageBox.Show("Usuario no existe");
                return;
            }
            if (iPos.EncDec.Decrypt(userBE.ICLAVEACCESO, "DryHit" + userBE.IUSERNAME.Trim()) == this.TBPassUser.Text)
            {
                
                //int res = userPerD.ExisteUSUARIO_PERFIL(CPERFILESD._PERFIL_SUPERVISOR, userBE.IUS_USERID, null);
                m_bIsSupervisor = userD.UsuarioEsAdmin(userBE.IID, null);
                m_bIsAdministrador = userD.UsuarioEsSupervisor(userBE.IID, null);

                if (!m_requiereAdminOrSupervisor || m_bIsSupervisor || m_bIsAdministrador)
                {
                    m_supervisorBE = userBE;
                    m_bPassValido = true;
                    m_userBE = userBE;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Este usuario no es un supervisor");
                    return;
                }

               /* if ( res == 1)
                {
                    m_supervisorBE = userBE;
                    this.Close();
                }
                else if (res == 0)
                {
                    MessageBox.Show("Este usuario no es un supervisor");
                    return;
                }
                else
                {
                    MessageBox.Show(userPerD.IComentario);
                    return;
                }*/
            }
            else
            {
                MessageBox.Show("InValido");
            }
        }
        private void BTCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void WFPreguntaAutorizacion_Load(object sender, EventArgs e)
        {

        }
    }
}
