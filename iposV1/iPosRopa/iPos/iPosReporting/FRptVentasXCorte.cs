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
    public partial class FRptVentasXCorte : Form
    {


        public int m_tipodoctoId;
        public bool m_ieps;

        public FRptVentasXCorte()
        {
            InitializeComponent();
            m_ieps = false;

        }

        public FRptVentasXCorte(bool ieps): this()
        {
            m_ieps = ieps;

        }
        private void FRptVentasXCorte_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSReportIpos.ALMACEN' table. You can move, or remove it, as needed.
            this.aLMACENTableAdapter.Fill(this.dSReportIpos.ALMACEN);

            this.m_tipodoctoId = (int)iPosData.DBValues._DOCTO_TIPO_VENTA;

           

            
        }


        private void BTEnviar_Click(object sender, EventArgs e)
        {

            LlenarDataSourceVentas();
        }

        private void LlenarDataSourceVentas()
        {

            string strTipo = "";

            try
            {

                switch (CBTipo.SelectedIndex)
                {
                    case 0: this.m_tipodoctoId = 21; strTipo = CBTipo.SelectedItem.ToString(); break;
                    case 1: this.m_tipodoctoId = -31; strTipo = CBTipo.SelectedItem.ToString(); break;
                    case 2: this.m_tipodoctoId = 23; strTipo = CBTipo.SelectedItem.ToString(); break;
                    default: this.m_tipodoctoId = -21; strTipo = "TODOS"; break;

                }

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

           
                RecargarReport();
                report1.SetParameterValue("TIPODOCTOID", m_tipodoctoId);
                report1.SetParameterValue("FECHAINI", DTPFrom.Value);
                report1.SetParameterValue("FECHAFIN", DTPTo.Value);
                report1.SetParameterValue("TIPODOCTONOMBRE", strTipo);
                report1.SetParameterValue("VENDEDORID", (CBCajerosTodos.Checked) ? 0 : Decimal.Parse(this.VENDEDORIDTextBox.DbValue.ToString()));
                report1.SetParameterValue("VENDEDORNOMBRE", (CBCajerosTodos.Checked) ? "Todos" : this.VENDEDORIDTextBox.Text);

                report1.SetParameterValue("ALMACENID", (CBSoloAlmacen.Checked) ?  Decimal.Parse((comboBoxAlmacen.SelectedValue.ToString())): 0);
                report1.SetParameterValue("NOMBREALMACEN", (CBSoloAlmacen.Checked) ? this.comboBoxAlmacen.SelectedText : "Todos");

                if (report1.Prepare())
                    report1.ShowPrepared();
            

        }


        private void RecargarReport()
        {

            report1.Load(FastReportsConfigReport.getPathForFile("InformeVentasXCorte.frx", FastReportsConfigTipoFile.desistema));
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", ConexionesBD.ConexionBD.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", ConexionesBD.ConexionBD.CurrentUser.IID);
        }


       
    }
}
