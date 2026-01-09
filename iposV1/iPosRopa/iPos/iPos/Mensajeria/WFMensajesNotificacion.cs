using iPos.Mensajeria;
using iPosBusinessEntity;
using iPosData;
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
    public partial class WFMensajesNotificacion : Form
    {
        private int CUENTAMENSAJESSINLEER;

        private int CUENTAMENSAJESSINLEERRESTR;

        private int CUENTAMENSAJESSINLEERADM;

        private int CUENTAMENSAJESSINLEERADMRESTR;

        public WFMensajesNotificacion()
        {
            InitializeComponent();
        }

        public WFMensajesNotificacion(int countMensjSinLeer, int countMensjSinLeerRest,
                                      int countMensjSinLeerAdm, int countMensjSinLeerAdmRest): this()
        {
            this.CUENTAMENSAJESSINLEER = countMensjSinLeer;
            this.CUENTAMENSAJESSINLEERRESTR = countMensjSinLeerRest;
            this.CUENTAMENSAJESSINLEERADM = countMensjSinLeerAdm;
            this.CUENTAMENSAJESSINLEERADMRESTR = countMensjSinLeerAdmRest;
        }

        private void WFMensajesNotificacion_Load(object sender, EventArgs e)
        {
            this.txtMensjSinLeer.Text = this.CUENTAMENSAJESSINLEER.ToString();
            this.txtMensjRestSinLeer.Text = this.CUENTAMENSAJESSINLEERRESTR.ToString();
            this.txtMensjAdminSinLeer.Text = this.CUENTAMENSAJESSINLEERADM.ToString();
            this.txtMensjAdminRestSinLeer.Text = this.CUENTAMENSAJESSINLEERADMRESTR.ToString();

            if(this.CUENTAMENSAJESSINLEERRESTR <= 0 && this.CUENTAMENSAJESSINLEERADMRESTR <= 0)
            {
                this.btnMensjCerrar.Enabled = true;
            }
            else
            {
                this.btnMensjCerrar.Enabled = false;
            }
        }

        private void recargarMensajes(int countMensjSinLeer, int countMensjSinLeerRest,
                                      int countMensjSinLeerAdm, int countMensjSinLeerAdmRest)
        {
            this.CUENTAMENSAJESSINLEER = countMensjSinLeer;
            this.CUENTAMENSAJESSINLEERRESTR = countMensjSinLeerRest;
            this.CUENTAMENSAJESSINLEERADM = countMensjSinLeerAdm;
            this.CUENTAMENSAJESSINLEERADMRESTR = countMensjSinLeerAdmRest;

            this.txtMensjSinLeer.Text = this.CUENTAMENSAJESSINLEER.ToString();
            this.txtMensjRestSinLeer.Text = this.CUENTAMENSAJESSINLEERRESTR.ToString();
            this.txtMensjAdminSinLeer.Text = this.CUENTAMENSAJESSINLEERADM.ToString();
            this.txtMensjAdminRestSinLeer.Text = this.CUENTAMENSAJESSINLEERADMRESTR.ToString();

            if (this.CUENTAMENSAJESSINLEERRESTR <= 0 && this.CUENTAMENSAJESSINLEERADMRESTR <= 0)
            {
                this.btnMensjCerrar.Enabled = true;
            }
            else
            {
                this.btnMensjCerrar.Enabled = false;
            }
        }


        private void btnMensj_Click(object sender, EventArgs e)
        {
            WFBuzon wfBuzon = new WFBuzon(CurrentUserID.CurrentUser.IID);
            wfBuzon.ShowDialog();

            CPERSONAD userD = new CPERSONAD();
            bool ES_ADMINISTRADOR = userD.UsuarioEsAdmin(CurrentUserID.CurrentUser.IID, null);
            bool ES_SUPERVISOR = userD.UsuarioEsAdmin(CurrentUserID.CurrentUser.IID, null);

            string esAdmin = ES_ADMINISTRADOR || ES_SUPERVISOR ? "S" : "N";

            int cMensjSnLeer = 0, cMensjSnLeerRest = 0, cMensjSnLeerAdm = 0, cMensjSnLeerAdmRest = 0;

            CMENSAJED daoMensaje = new CMENSAJED();
            daoMensaje.llamarMENSAJES_ALERTAUSUARIO(CurrentUserID.CurrentUser.IID, esAdmin, ref cMensjSnLeer, ref cMensjSnLeerRest, ref cMensjSnLeerAdm, ref cMensjSnLeerAdmRest, null);

            recargarMensajes(cMensjSnLeer, cMensjSnLeerRest, cMensjSnLeerAdm, cMensjSnLeerAdmRest);

            wfBuzon.Dispose();
            GC.SuppressFinalize(wfBuzon);
        }

        private void btnMensjAdmin_Click(object sender, EventArgs e)
        {
            WFPreguntaAutorizacion ps2 = new WFPreguntaAutorizacion();
            ps2.ShowDialog();
            CPERSONABE userBE = ps2.m_userBE;
            bool bPassValido = ps2.m_bPassValido;
            bool bIsSupervisor = ps2.m_bIsSupervisor;
            bool bIsAdministrador = ps2.m_bIsAdministrador;
            ps2.Dispose();
            GC.SuppressFinalize(ps2);

            if (!bPassValido)
            {
                this.Close();
                return;
            }

            if (!bIsSupervisor)
            {
                MessageBox.Show("El usuario no es un supervisor");
                this.Close();
                return;
            }

            WFBuzon wfBuzon = new WFBuzon(userBE.IID);
            wfBuzon.ShowDialog();

            CPERSONAD userD = new CPERSONAD();
            bool ES_ADMINISTRADOR = userD.UsuarioEsAdmin(CurrentUserID.CurrentUser.IID, null);
            bool ES_SUPERVISOR = userD.UsuarioEsAdmin(CurrentUserID.CurrentUser.IID, null);

            string esAdmin = ES_ADMINISTRADOR || ES_SUPERVISOR ? "S" : "N";

            int cMensjSnLeer = 0, cMensjSnLeerRest = 0, cMensjSnLeerAdm = 0, cMensjSnLeerAdmRest = 0;

            CMENSAJED daoMensaje = new CMENSAJED();
            daoMensaje.llamarMENSAJES_ALERTAUSUARIO(CurrentUserID.CurrentUser.IID, esAdmin, ref cMensjSnLeer, ref cMensjSnLeerRest, ref cMensjSnLeerAdm, ref cMensjSnLeerAdmRest, null);

            recargarMensajes(cMensjSnLeer, cMensjSnLeerRest, cMensjSnLeerAdm, cMensjSnLeerAdmRest);

            wfBuzon.Dispose();
            GC.SuppressFinalize(wfBuzon);
        }

        private void btnMensjCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
