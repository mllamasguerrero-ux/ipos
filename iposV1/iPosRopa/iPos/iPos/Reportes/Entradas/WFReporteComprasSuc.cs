using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos.Reportes.Entradas
{
    public partial class WFReporteComprasSuc : Form
    {
        public WFReporteComprasSuc()
        {
            InitializeComponent();
        }

        private void BTBuscar_Click(object sender, EventArgs e)
        {
            ReporteSucursal();
        }


        private void ReporteSucursal()
        {
            try
            {
                DateTime dtBufferIni = DateTime.MinValue;
                DateTime dtBufferFin = DateTime.MaxValue;
                string porFecha = "S";
                if (CBFecha.Checked)
                {
                    porFecha = "S";
                    dtBufferIni = dateTimePicker1.Value;
                    dtBufferFin = dateTimePicker2.Value;
                }
                else
                {

                    porFecha = "N";
                }


                long sucursalDestinoId = 0;
                string sucursalNombre = "Todos";
                if (this.CBSucursal.Checked && this.SUCURSALIDTextBox.Text != "")
                {
                    sucursalDestinoId = Int32.Parse(this.SUCURSALIDTextBox.DbValue.ToString());
                    sucursalNombre = this.SUCURSALIDLabel.Text;
                }


                long proveedorId = 0;
                string proveedorNombre = "Todos";
                if (this.CBProveedor.Checked && this.ITEMIDTextBox.Text != "")
                {
                    proveedorId = Int64.Parse(this.ITEMIDTextBox.DbValue.ToString());
                    proveedorNombre = this.ITEMLabel.Text;
                }


                string sinfacturaprocesada = CBSinFacturaProc.Checked ? "S" : "N";

                    Dictionary<string, object> dictionary = new Dictionary<string, object>();


                string strReporte = "InformeComprasSuc.frx";
                
                dictionary.Add("porfecha", porFecha);
                dictionary.Add("fechaini", dtBufferIni);
                dictionary.Add("fechafin", dtBufferFin);
                dictionary.Add("personaid", proveedorId);
                dictionary.Add("persona", proveedorNombre);
                dictionary.Add("sucdestid", sucursalDestinoId);
                dictionary.Add("sucdest", sucursalNombre);
                dictionary.Add("sinfactproc", sinfacturaprocesada);


                iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
                rp.ShowDialog();
                rp.Dispose();
                GC.SuppressFinalize(rp);

                //this.transaccionesListaExtTableAdapter.Fill(this.dSReimpresionTicket2.TransaccionesListaExt, m_statusDoctoId, m_tipoDoctoId, dtBuffer, ((m_bEsFacturaElectronica) ? "S" : "N"), 0, sucursalDestinoId, proveedorId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void WFReporteComprasSuc_Load(object sender, EventArgs e)
        {
            
        }
    }
}
