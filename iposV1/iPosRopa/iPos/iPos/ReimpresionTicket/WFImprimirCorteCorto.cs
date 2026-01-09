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
    public partial class WFImprimirCorteCorto : IposForm
    {
        public WFImprimirCorteCorto()
        {
            InitializeComponent();
        }

        private void BTReimprimirCorte_Click(object sender, EventArgs e)
        {


            CCORTED corteD = new CCORTED();
            bool bRes = corteD.CALCULARCORTESABIERTOSFECHA(this.DTPCorte.Value, null);

            if (!bRes)
            {
                MessageBox.Show("Hubo un problema al calcular los cortes que aun estan activos");
                return;
            }

            WFImpresionCorte ic = new WFImpresionCorte(this.DTPCorte.Value,cbSumarizado.Checked,
                                         (this.RBPorCajero.Checked)?ImpresionCorteOption.SumarizadoDelDiaXCajero: (this.RBPorGrupoCorto.Checked) ? ImpresionCorteOption.SumarizadoDelDiaXGrupoCajero : ImpresionCorteOption.SumarizadoDelDia);
            ic.ShowDialog();

            if (ic.m_bTicketImpreso)
                MessageBox.Show("El ticket se imprimio");

            ic.Dispose();
            GC.SuppressFinalize(ic);
        }

        private void cbSumarizado_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSumarizado.Checked)
            {
                this.GBOpcionesSumarizado.Enabled = true;
                this.RBNormal.Checked = true;
                this.btnEnviarXMail.Enabled = true;
                this.btnVistaPrevia.Enabled = true;

            }
            else
            {
                this.GBOpcionesSumarizado.Enabled = false;
                this.btnEnviarXMail.Enabled = false;
                this.btnVistaPrevia.Enabled = false;
            }

        }

        private void WFImprimirCorteCorto_Load(object sender, EventArgs e)
        {

            /*WFPreguntaAutorizacion ps = new WFPreguntaAutorizacion();
            ps.ShowDialog();
            if (!ps.m_bPassValido)
            {
                this.Close();
                return;
            }

            if (!ps.m_bIsSupervisor)
            {
                MessageBox.Show("El usuario no es un supervisor");
                this.Close();
                return;
            }*/
        }

        private void btnEnviarXMail_Click(object sender, EventArgs e)
         {
            if(!cbSumarizado.Checked)
                return;

            CCORTED corteD = new CCORTED();
            bool bRes = corteD.CALCULARCORTESABIERTOSFECHA(this.DTPCorte.Value, null);

            if(!bRes)
            {
                MessageBox.Show("Hubo un problema al calcular los cortes que aun estan activos");
                return;
            }

            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("fecha",this.DTPCorte.Value);

            string strReporte = this.RBPorCajero.Checked ? "CorteSumarizadoPorCajeroyFecha.frx" : "CorteSumarizadoPorFecha.frx";
            
            string stSubject = this.RBPorCajero.Checked ? "Corte Sumarizado por cajero y fecha de Suc. " + CurrentUserID.SUCURSAL_CLAVE + " Fecha : " + this.DTPCorte.Value.ToString("dd/MM/yyyy")
                                                        : "Corte Sumarizado por fecha de Suc. " + CurrentUserID.SUCURSAL_CLAVE + " Fecha : " + this.DTPCorte.Value.ToString("dd/MM/yyyy");

            iPos.Login_and_Maintenance.WFReportSending rp = new Login_and_Maintenance.WFReportSending(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), CurrentUserID.CurrentParameters.ISMTPMAILTO, dictionary, stSubject,"PDF");
            rp.ShowDialog();
            rp.Dispose();
            GC.SuppressFinalize(rp);

        }

        private void btnVistaPrevia_Click(object sender, EventArgs e)
        {

            if (!cbSumarizado.Checked)
                return;

            CCORTED corteD = new CCORTED();
            bool bRes = corteD.CALCULARCORTESABIERTOSFECHA(this.DTPCorte.Value, null);

            if (!bRes)
            {
                MessageBox.Show("Hubo un problema al calcular los cortes que aun estan activos");
                return;
            }

            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("fecha", this.DTPCorte.Value);

            string strReporte = this.RBPorCajero.Checked ? "CorteSumarizadoPorCajeroyFecha.frx" : (this.RBPorGrupoCajeros.Checked ? "CorteSumarizadoPorGrupoCajeroyFecha.frx" : (this.RBPorGrupoCorto.Checked ? "CorteSumarizadoPorGrupoYFecha.frx" : "CorteSumarizadoPorFecha.frx"));

            iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema),  dictionary);
            rp.ShowDialog();
            rp.Dispose();
            GC.SuppressFinalize(rp);
        }
    }
}
