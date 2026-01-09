using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPosReporting
{
    public partial class FRptCompras : Form
    {
        public bool m_ieps;
        public FRptCompras()
        {
            InitializeComponent();
            m_ieps = false;

        }


        public FRptCompras(bool ieps)
            : this()
        {
            m_ieps = ieps;

        }

        private void FRptCompras_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSReportIpos.ALMACEN' table. You can move, or remove it, as needed.
            this.aLMACENTableAdapter.Fill(this.dSReportIpos.ALMACEN);
            
            if (!m_ieps)
            {
                tabControl1.TabPages.Remove(tabReporte);
            }
            else
            {
                tabControl1.TabPages.Remove(tabPage1);
            }

            CBFactRem.SelectedText = "TODOS";
            CBCajerosTodos.Checked = true;
        }


        private void BTEnviar_Click(object sender, EventArgs e)
        {
                LoadDataSource();
        }

        private void LoadDataSource()
        {

            string strTipoFactRem = "T";
            string strDescTipoFactRem = "Todos";

            switch (CBFactRem.SelectedIndex)
            {
                case 0: strTipoFactRem = "T"; strDescTipoFactRem = "Todos"; break;
                case 1: strTipoFactRem = "R"; strDescTipoFactRem = "Remision"; break;
                case 2: strTipoFactRem = "F"; strDescTipoFactRem = "Factura"; break;
                default: strTipoFactRem = "T"; strDescTipoFactRem = "Todos"; break;

            }

            if (!m_ieps || this.CBReporteTabular.Checked)
            {
                try
                {
                    this.rEP_COMPRATableAdapter.Fill(this.dSReportIpos.REP_COMPRA, this.DTPFrom.Value.Date, this.DTPTo.Value.Date, (CBCajerosTodos.Checked) ? 0 : Int64.Parse(this.VENDEDORIDTextBox.DbValue.ToString()), (CBSoloAlmacen.Checked) ? int.Parse((comboBoxAlmacen.SelectedValue.ToString())) : 0);
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }


            if (!m_ieps)
            {
                try
                {

                    Microsoft.Reporting.WinForms.ReportParameter[] Param = new Microsoft.Reporting.WinForms.ReportParameter[4];
                    Param[0] = new Microsoft.Reporting.WinForms.ReportParameter("FechaInicio", DTPFrom.Value.ToString("dd/MM/yyyy"));
                    Param[1] = new Microsoft.Reporting.WinForms.ReportParameter("FechaFin", DTPTo.Value.ToString("dd/MM/yyyy"));
                    Param[2] = new Microsoft.Reporting.WinForms.ReportParameter("Cajero", (CBCajerosTodos.Checked) ? "Todos" : this.VENDEDORIDTextBox.Text);
                    Param[3] = new Microsoft.Reporting.WinForms.ReportParameter("Almacen", (CBSoloAlmacen.Checked) ? this.comboBoxAlmacen.SelectedText : "Todos");
                    this.reportViewer1.LocalReport.SetParameters(Param);
                    this.reportViewer1.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }
            else
            {
                RecargarReport();
                report1.SetParameterValue("TIPODOCTOID", 11);
                report1.SetParameterValue("FECHAINI", DTPFrom.Value);
                report1.SetParameterValue("FECHAFIN", DTPTo.Value);
                report1.SetParameterValue("TIPODOCTONOMBRE", "Compras");
                report1.SetParameterValue("VENDEDORID", (CBCajerosTodos.Checked) ? 0 : Decimal.Parse(this.VENDEDORIDTextBox.DbValue.ToString()));
                report1.SetParameterValue("VENDEDORNOMBRE", (CBCajerosTodos.Checked) ? "Todos" : this.VENDEDORIDTextBox.Text);


                report1.SetParameterValue("ALMACENID", (CBSoloAlmacen.Checked) ? Decimal.Parse((comboBoxAlmacen.SelectedValue.ToString())) : 0);
                report1.SetParameterValue("NOMBREALMACEN", (CBSoloAlmacen.Checked) ? this.comboBoxAlmacen.SelectedText : "Todos");
                report1.SetParameterValue("REMISIONFACTURA", strTipoFactRem);
                report1.SetParameterValue("REMISIONFACTURADESC", strDescTipoFactRem);

                if (report1.Prepare())
                    report1.ShowPrepared();
            }


        }


        private void RecargarReport()
        {

            report1.Load(FastReportsConfigReport.getPathForFile("InformeDiarioComprasIEPSEXP.frx", FastReportsConfigTipoFile.desistema));
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", ConexionesBD.ConexionBD.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", ConexionesBD.ConexionBD.CurrentUser.IID);
        }


       
    }
}
