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
using FirebirdSql.Data.FirebirdClient;

namespace iPos
{
    public partial class CorteAbrir : IposForm
    {
        public CorteAbrir()
        {
            InitializeComponent();
        }

        private void CorteAbrir_Load(object sender, EventArgs e)
        {

            if (!ChecarPermisos())
            {
                this.Close();
                return;
            }

            
            if(CurrentUserID.CurrentParameters.IHABFONDODINAMICO != null &&
                CurrentUserID.CurrentParameters.IHABFONDODINAMICO.Equals("S"))
            {
                pnlFondoDinamico.Visible = true;
                PonerFondoDinamico();
            }
            else
            {
                pnlFondoDinamico.Visible = false;
            }
        }

        private void PonerFondoDinamico()
        {
            decimal fondoDinamico = 0;
            CCORTED corteD = new CCORTED();
            corteD.CORTE_ULTIMOFONDODINAMICO(CurrentUserID.CurrentUser.IID, DateTime.Today, ref fondoDinamico, null);


            this.NTBFondoInicial.Text = fondoDinamico.ToString("N2");
        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            CCORTED corteD = new CCORTED();
            CCORTEBE corteBE = new CCORTEBE();
            DateTime fechaCorteActiva = DateTime.MinValue;
            if (corteD.HayCorteActivo(iPos.CurrentUserID.CurrentUser.IID, null,ref fechaCorteActiva))
            {
                MessageBox.Show("Ya hay un corte activo");
                this.Close();
                return;
            }
            corteBE.ISUCURSALID = CurrentUserID.CurrentParameters.ISUCURSALID;
            corteBE.ICAJAID = iPos.CurrentUserID.CurrentCompania.IEM_CAJA;
            corteBE.ICAJEROID = CurrentUserID.CurrentUser.IID;
            corteBE.IFECHACORTE = DateTime.Now;
            //corteBE.ITURNOID = long.Parse(CBTurno.SelectedValue.ToString());
            corteBE.ISALDOINICIAL = decimal.Parse(NTSaldoInicial.Text);
            corteBE.ITIPOCORTEID = DBValues._TIPO_CORTENORMAL;


            CCORTEBE corteBuffer = new CCORTEBE();
            corteBuffer = corteD.seleccionarCORTEXDIAyCAJERO(corteBE, null);
            if (corteBuffer != null)
            {


                MessageBox.Show("Necesitara que un supervisior ingrese sus credenciales para reabrir un corte");

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
            }


            corteBE = corteD.AbrirCORTED(corteBE, null);
            if (corteBE == null)
                MessageBox.Show(corteD.IComentario);
            else
            {
                
                ImprimirTicketFR(corteBE.IID);
                

                MessageBox.Show("El corte se ha abierto con exito");
                ActualizaCurrentUser();
                ConsolidarFacturasDeDiasAnterioresSiAplica();
                DesensamblarKitsViejosSiAplica();

                this.Close();
            }

        }



        private void ActualizaCurrentUser()
        {
            CPERSONAD personaD = new CPERSONAD();
            CurrentUserID.CurrentUser = personaD.seleccionarPERSONA(CurrentUserID.CurrentUser, null);
        }

        private bool ChecarPermisos()
        {

            CPERSONAD personaD = new CPERSONAD();
            int iMenu = int.Parse(DBValues._MENUID_CORTEABRIR.ToString());
            if (!personaD.UsuarioTieneDerechoAMenu(CurrentUserID.CurrentUser.IID, iMenu, null))
            {
                MessageBox.Show("El usuario no tiene derecho a este form");
                return false;
            }
            return true;
        }

        private void ConsolidarFacturasDeDiasAnterioresSiAplica()
        {
            bool bEsNecesarioConsolidacionAutomatica = (((!(bool)CurrentUserID.CurrentParameters.isnull["IHAB_CONSOLIDADOAUTOMATICO"]) && CurrentUserID.CurrentParameters.IHAB_CONSOLIDADOAUTOMATICO != null && CurrentUserID.CurrentParameters.IHAB_CONSOLIDADOAUTOMATICO.Equals("S")) &&
                (((bool)CurrentUserID.CurrentParameters.isnull["IULT_CONSOLIDADOAUTOMATICO"]) || CurrentUserID.CurrentParameters.IULT_CONSOLIDADOAUTOMATICO == null || CurrentUserID.CurrentParameters.IULT_CONSOLIDADOAUTOMATICO.AddDays(1).CompareTo(DateTime.Today) < 0)
                );

            if (bEsNecesarioConsolidacionAutomatica)
            {
                WFConsolidadoAutomatico wf = new WFConsolidadoAutomatico();
                wf.ShowDialog();
                wf.Dispose();
                GC.SuppressFinalize(wf);
            }
        }



        private void DesensamblarKitsViejosSiAplica()
        {
            if (CurrentUserID.CurrentParameters.IMANEJAKITS == null || !CurrentUserID.CurrentParameters.IMANEJAKITS.Equals("S"))
                return;


            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            try
            {

                fConn.Open();
                fTrans = fConn.BeginTransaction();

                CKITDEFINICIOND defD = new CKITDEFINICIOND();
                if(!defD.KIT_DESAMBLARNOVIGENTES(CurrentUserID.CurrentUser.IID, fTrans))
                {
                    MessageBox.Show("El corte se abrio pero hubo un problema al desensamblar kits que ya no estan vigentes. favor de comunicarle a sistemas " + defD.IComentario);
                    fTrans.Rollback();
                    fConn.Close();
                    return;
                }

                fTrans.Commit();
                fConn.Close();

            }
            catch
            {
                fConn.Close();
            }
            finally
            {
                fConn.Close();
            }



        }


        public static void ImprimirTicketFR(long corteId)
        {

            for(int i = 0; i < CurrentUserID.CurrentParameters.ICANTTICKETABRIRCORTE ; i++)
            {
                ImprimirTicketFR_(corteId);
            }
        }

        public static string ImprimirTicketFR_(long corteId)
        {


            
            WFImpresionCorte ic = new WFImpresionCorte(corteId);
            ic.m_iOpcion = ImpresionCorteOption.Apertura;
            ic.ShowDialog();


            if (ic.m_bTicketImpreso)
                MessageBox.Show("El ticket se imprimio");

            ic.Dispose();
            GC.SuppressFinalize(ic);

            return "S";
        }

    }
}
