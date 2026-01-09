using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos.Reportes.MultiNivel
{
    public partial class WFClientesProductos : Form
    {
        long m_clienteID = 0;
        public WFClientesProductos()
        {
            InitializeComponent();
        }

        public WFClientesProductos(long clienteID):this()
        {

            m_clienteID = clienteID;
        }

        private void LlenarMovimientos()
        {
            try
            {

                int personaId = 0;
                try
                {
                    personaId = Int32.Parse(this.PERSONAIDTextBox.DbValue.ToString());
                    if (personaId == 0)
                    {
                        MessageBox.Show("Seleccione un cliente valido");
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("Seleccione un cliente valido");
                    return;
                }

                this.mOVIMIENTOSDETALLEFECHATableAdapter.Fill(this.dSFastReports.MOVIMIENTOSDETALLEFECHA, this.DTPFrom.Value, this.DTPTo.Value, personaId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void BTMostrar_Click(object sender, EventArgs e)
        {
            LlenarMovimientos();

        }

        private void WFClientesProductos_Load(object sender, EventArgs e)
        {
            this.DTPFrom.Value = DateTime.Parse("01/01/2012");
            this.DTPTo.Value = DateTime.Parse("31/12/" + DateTime.Today.ToString("yyyy"));


            if (m_clienteID != 0)
            {
                string strBuffer = "";
                this.PERSONAIDTextBox.DbValue = m_clienteID.ToString();
                this.PERSONAIDTextBox.MostrarErrores = false;
                this.PERSONAIDTextBox.MValidarEntrada(out strBuffer, 1);
                this.PERSONAIDTextBox.MostrarErrores = true;
            }


            if (m_clienteID != 0)
            {
                LlenarMovimientos();
                
            }
        }

        private void BTImprimir_Click(object sender, EventArgs e)
        {

            try
            {

                int personaId = 0;
                try
                {
                    personaId = Int32.Parse(this.PERSONAIDTextBox.DbValue.ToString());
                    if (personaId == 0)
                    {
                        MessageBox.Show("Seleccione un cliente valido");
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("Seleccione un cliente valido");
                    return;
                }


                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("clienteid", personaId);
                dictionary.Add("fechaini", this.DTPFrom.Value);
                dictionary.Add("fechafin", this.DTPTo.Value);
                dictionary.Add("nombrecliente", this.PERSONALabel.Text);
                string strReporte = "MovimientosProductoXClienteDetalle.frx";


                iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
                rp.ShowDialog();
                rp.Dispose();
                GC.SuppressFinalize(rp);

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }


        }
    }
}
