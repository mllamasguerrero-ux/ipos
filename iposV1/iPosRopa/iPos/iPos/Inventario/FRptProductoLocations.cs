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
	public partial class FRptProductoLocations : IposForm
    {
        private bool m_loadingForm = true;
        public FRptProductoLocations()
		{
			InitializeComponent();
		}

		private void FRptProductoLocations_Load(object sender, EventArgs e)
        {
            this.ALMACENComboBox.llenarDatos();
            this.ALMACENComboBox.SelectedIndex = -1;

            bool manejaAlmacen = (CurrentUserID.CurrentParameters.IMANEJAALMACEN == "S");

            this.ALMACENComboBox.Visible = manejaAlmacen;
            this.lblAlmacen.Visible = manejaAlmacen;

            if (manejaAlmacen && CurrentUserID.CurrentUser.IALMACENID > 0)
                this.ALMACENComboBox.SelectedDataValue = CurrentUserID.CurrentUser.IALMACENID;


            LlenarListaAnaqueles();
            
            report1.Preview = this.previewControl1;


            m_loadingForm = false;
        }

		private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string anaquelinicio = "Todos";
                string anaquelfin = "Todos";
                if (!CBTodos.Checked)
                {
                    anaquelinicio = this.ANAQUELINICIOComboBox.Text.ToString();
                    anaquelfin = this.ANAQUELFINComboBox.Text.ToString();
                }

                string strNombreReporte = CBTicket.Checked ? "localidadproductosticket.frx" : "localidadproductos.frx";
                report1.Load(FastReportsConfig.getPathForFile(strNombreReporte, FastReportsTipoFile.desistema));
                
                report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
                report1.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
                report1.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);

                report1.SetParameterValue("p_anaquelinicio", anaquelinicio);
                report1.SetParameterValue("p_anaquelfin", anaquelfin);
                report1.SetParameterValue("p_todos", (CBTodos.Checked) ? "1" : "0");
                report1.SetParameterValue("p_kitdesglosado", (CBKitsDesensamblados.Checked) ? "S" : "N");

                if (report1.Prepare())
                    report1.ShowPrepared();

                
                
                /*Microsoft.Reporting.WinForms.ReportParameter[] Param = new Microsoft.Reporting.WinForms.ReportParameter[2];
                Param[0] = new Microsoft.Reporting.WinForms.ReportParameter("anaquelinicio", anaquelinicio);
                Param[1] = new Microsoft.Reporting.WinForms.ReportParameter("anaquelfin", anaquelfin);

                this.reportViewer1.LocalReport.SetParameters(Param);
                this.PRODUCTOLOCATIONSTableAdapter.Fill(this.DSCortesB.PRODUCTOLOCATIONS, anaquelinicio, anaquelfin, (CBTodos.Checked) ? (Int16)1 : (Int16)0);
                this.reportViewer1.RefreshReport();*/

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
		}

		private void button2_Click(object sender, EventArgs e)
		{

		}

		private void button2_Click_1(object sender, EventArgs e)
		{
			//this.reportViewer1.RefreshReport();
        }

        private void FRptProductoLocations_FormClosing(object sender, FormClosingEventArgs e)
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


        private void LlenarListaAnaqueles()
        {

            if (this.ALMACENComboBox.SelectedIndex >= 0 && (CurrentUserID.CurrentParameters.IMANEJAALMACEN == "S"))
            {
                this.ANAQUELINICIOComboBox.Query = "select id,clave as nombre from anaquel where almacenid = " + this.ALMACENComboBox.SelectedDataValue.ToString();
                this.ANAQUELFINComboBox.Query = "select id,clave as nombre from anaquel where almacenid = " + this.ALMACENComboBox.SelectedDataValue.ToString();
            }
            else
            {
                this.ANAQUELINICIOComboBox.Query = "select id,clave as nombre from anaquel";
                this.ANAQUELFINComboBox.Query = "select id,clave as nombre from anaquel";
            }

            this.ANAQUELINICIOComboBox.llenarDatos();
            this.ANAQUELFINComboBox.llenarDatos();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ALMACENComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (!m_loadingForm)
                LlenarListaAnaqueles();
        }
    }
}
