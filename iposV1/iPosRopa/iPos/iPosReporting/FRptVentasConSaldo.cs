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
    public partial class FRptVentasConSaldo : Form
    {


        public int m_tipodoctoId;

        public FRptVentasConSaldo()
        {
            InitializeComponent();

        }

        private void FRptVentasConSaldo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSReportIpos.ALMACEN' table. You can move, or remove it, as needed.
            this.aLMACENTableAdapter.Fill(this.dSReportIpos.ALMACEN);
            //this.reportViewer1.RefreshReport();
            RecargarReport();
            this.m_tipodoctoId = (int)iPosData.DBValues._DOCTO_TIPO_VENTA;

            CBFactRem.SelectedText = "TODOS";
        }


        private void RecargarReport()
        {

            report1.Load(FastReportsConfigReport.getPathForFile("InformeVentasConSaldo.frx", FastReportsConfigTipoFile.desistema));
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", ConexionesBD.ConexionBD.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", ConexionesBD.ConexionBD.CurrentUser.IID);
        }

        //private void LlenarDataSourceVentas()
        //{

        //    try
        //    {
        //        this.rEP_VENTATableAdapter.Fill(this.DSReportIpos.REP_VENTA, DTPFrom.Value, DTPTo.Value);
        //        Microsoft.Reporting.WinForms.ReportParameter[] Param = new Microsoft.Reporting.WinForms.ReportParameter[2];
        //        Param[0] = new Microsoft.Reporting.WinForms.ReportParameter("FechaInicio", DTPFrom.Value.ToString("dd/MM/yyyy"));
        //        Param[1] = new Microsoft.Reporting.WinForms.ReportParameter("FechaFin", DTPTo.Value.ToString("dd/MM/yyyy"));

        //        this.reportViewer1.LocalReport.SetParameters(Param);
        //        this.reportViewer1.Visible = true;
        //        this.reportViewer1.RefreshReport();
        //    }
        //    catch (System.Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(ex.Message);
        //    }

        //}

        private void BTEnviar_Click(object sender, EventArgs e)
        {

            LlenarDataSourceVentas();
        }

        private void LlenarDataSourceVentas()
        {
            string strTipo = "";
            string strTipoFactRem = "";
            string strDescTipoFactRem = "";
            try
            {


                switch (CBFactRem.SelectedIndex)
                {
                    case 0: strTipoFactRem = "T"; strDescTipoFactRem = "Todos"; break;
                    case 1: strTipoFactRem = "R"; strDescTipoFactRem = "Remision"; break;
                    case 2: strTipoFactRem = "F"; strDescTipoFactRem = "Factura"; break;
                    default: strTipoFactRem = "T"; strDescTipoFactRem = "Todos"; break;

                }

                switch (CBTipo.SelectedIndex)
                {
                    case 0: this.m_tipodoctoId = 21; strTipo = CBTipo.SelectedItem.ToString(); break;
                    case 1: this.m_tipodoctoId = -31; strTipo = CBTipo.SelectedItem.ToString(); break;
                    case 2: this.m_tipodoctoId = 23; strTipo = CBTipo.SelectedItem.ToString(); break;
                    case 3: this.m_tipodoctoId = (int)iPosData.DBValues._DOCTO_TIPO_FACTCONSOLIDADA; strTipo = CBTipo.SelectedItem.ToString(); break;
                    case 4: this.m_tipodoctoId = -21; strTipo = CBTipo.SelectedItem.ToString(); break;
                    case 5: this.m_tipodoctoId = -701; strTipo = CBTipo.SelectedItem.ToString(); break;
                    default: this.m_tipodoctoId = -21; strTipo = "TODOS EXCEPTO FACT. CONS."; break;

                }
                /*this.rEP_VENTA_CONSALDOTableAdapter.Fill(this.dSReportIpos2.REP_VENTA_CONSALDO, DTPFrom.Value, (long)m_tipodoctoId, CBVencidas.Checked ? "S" : "N", (CBSoloAlmacen.Checked) ? int.Parse((comboBoxAlmacen.SelectedValue.ToString())) : 0);
           
                Microsoft.Reporting.WinForms.ReportParameter[] Param = new Microsoft.Reporting.WinForms.ReportParameter[3];
                Param[0] = new Microsoft.Reporting.WinForms.ReportParameter("Vencimiento", CBVencidas.Checked ?  "Vencidas antes de: " + DTPFrom.Value.ToString("dd/MM/yyyy") : "Todos");
                Param[1] = new Microsoft.Reporting.WinForms.ReportParameter("TipoDocto", strTipo);
                Param[2] = new Microsoft.Reporting.WinForms.ReportParameter("Almacen", (CBSoloAlmacen.Checked) ? this.comboBoxAlmacen.SelectedText : "Todos");

                this.reportViewer1.LocalReport.SetParameters(Param);
                this.reportViewer1.RefreshReport();*/

                RecargarReport();
                report1.SetParameterValue("TIPODOCTOID", m_tipodoctoId);
                report1.SetParameterValue("VENCIMIENTO", DTPFrom.Value);
                report1.SetParameterValue("TIPODOCTONOMBRE", strTipo);
                report1.SetParameterValue("VENCIDAS", CBVencidas.Checked ? "S" : "N");
                
                report1.SetParameterValue("ALMACENID", (CBSoloAlmacen.Checked) ? Decimal.Parse((comboBoxAlmacen.SelectedValue.ToString())) : 0);
                report1.SetParameterValue("NOMBREALMACEN", (CBSoloAlmacen.Checked) ? this.comboBoxAlmacen.SelectedText : "Todos");
                report1.SetParameterValue("REMISIONFACTURA", strTipoFactRem);
                report1.SetParameterValue("REMISIONFACTURANOMBRE", strDescTipoFactRem);


                if (report1.Prepare())
                    report1.ShowPrepared();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
        /*
        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.rEP_VENTA_CONSALDOTableAdapter.Fill(this.dSReportIpos2.REP_VENTA_CONSALDO, new System.Nullable<System.DateTime>(((System.DateTime)(System.Convert.ChangeType(fECHAREFToolStripTextBox.Text, typeof(System.DateTime))))), new System.Nullable<long>(((long)(System.Convert.ChangeType(tIPODOCTOIDToolStripTextBox.Text, typeof(long))))), vENCIDOSToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillToolStripButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.rEP_VENTA_CONSALDOTableAdapter.Fill(this.dSReportIpos2.REP_VENTA_CONSALDO, new System.Nullable<System.DateTime>(((System.DateTime)(System.Convert.ChangeType(fECHAREFToolStripTextBox.Text, typeof(System.DateTime))))), new System.Nullable<long>(((long)(System.Convert.ChangeType(tIPODOCTOIDToolStripTextBox.Text, typeof(long))))), vENCIDOSToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }*/


       
    }
}
