using iPosBusinessEntity;
using iPosData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPos.Reportes.Ventas
{
    public partial class WFReporteDeConcentradoDeRuta : Form
    {
        string m_EsFactura = "T", m_RutaClave = "|";
        List<CRUTAEMBARQUEBE> CRUTASBE = new List<CRUTAEMBARQUEBE>();

        public WFReporteDeConcentradoDeRuta()
        {
            InitializeComponent();
        }

        private void WFReporteDeConcentradoDeRuta_Load(object sender, EventArgs e)
        {
            CRUTAEMBARQUED CRUTASD = new CRUTAEMBARQUED();
            CRUTASBE = CRUTASD.seleccionarRUTASDEEMBARQUE();
            foreach(CRUTAEMBARQUEBE rutaName in CRUTASBE)
            {
                clbRutas.Items.Add(rutaName.INOMBRE);
            }
        }

        private void RecargarReport()
        {

            report1.Load(FastReportsConfig.getPathForFile("ReporteDeConcentradoDeRuta.frx", FastReportsTipoFile.desistema));
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);
        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            if (clbRutas.CheckedItems.Count <= 0)
            {
                return;
            }

            RecargarReport();

            List<int> selectedItemsRutas = new List<int>();
            selectedItemsRutas = clbRutas.CheckedIndices.Cast<int>().ToList();

            m_RutaClave = "|";
            foreach(int rutaClave in selectedItemsRutas)
            {
                m_RutaClave += CRUTASBE[rutaClave].ICLAVE + "|";
            }

            switch (CBEsFactura.SelectedIndex)
            {
                case 0: this.m_EsFactura = "S"; break;
                case 1: this.m_EsFactura = "N"; break;
                case 2: this.m_EsFactura = "T"; break;

                default: this.m_EsFactura = "T"; break;

            }

            report1.SetParameterValue("fechaini", DTPFrom.Value);
            report1.SetParameterValue("fechafin", DTPTo.Value);
            report1.SetParameterValue("esfactura", m_EsFactura);
            report1.SetParameterValue("rutaclave", m_RutaClave);



            if (report1.Prepare())
                report1.ShowPrepared();
        }

        private void WFReporteDeConcentradoDeRuta_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                report1.Delete();
                report1.Dispose();
            }
            catch
            {
            }
        }
    }
}
