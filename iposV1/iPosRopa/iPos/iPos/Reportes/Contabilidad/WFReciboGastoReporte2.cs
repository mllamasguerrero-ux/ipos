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

namespace iPos.Reportes.Contabilidad
{
    public partial class WFReciboGastoReporte2 : Form
    {
        private bool m_tieneDerechoCambiarAlmacen = false;
        private bool m_manejaAlmacen = false;

        public WFReciboGastoReporte2()
        {
            InitializeComponent();
        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            

            Int64? p_cajero = 0;
            Int64? p_gasto = 0;
            String p_cajeroNombre = "Todos";
            String p_gastoNombre = "Todos";

            Int64? p_almacen = 0;
            String p_almacenNombre = "Todos";

            Int64? p_tipogasto = 0;
            String p_tipogastoNombre = "Todos";

            Int64? p_centrocosto = 0;
            String p_centrocostoNombre = "Todos";

            if (!CBTodas.Checked)
            {
                try
                {
                    p_cajero = Int64.Parse(this.ITEMIDTextBox.DbValue.ToString());
                    p_cajeroNombre = this.ITEMLabel.Text;
                }
                catch
                {
                    MessageBox.Show("Seleccione un cajero valido");
                    return;
                }
            }


            if (!CBTodosGastos.Checked)
            {
                try
                {
                    p_gasto = Int64.Parse(this.GASTOIDTextBox.DbValue.ToString());
                    p_gastoNombre = this.GASTOLabel.Text;
                }
                catch
                {
                    MessageBox.Show("Seleccione un tipo de gasto valido");
                    return;
                }
            }

            long origenFiscalId = DBValues._ORIGENFISCAL_INDEFINIDO;
            switch (this.CBOrigenFiscal.SelectedIndex)
            {
                case 0:
                    origenFiscalId = DBValues._ORIGENFISCAL_REMISIONADO; break;
                case 1:
                    origenFiscalId = DBValues._ORIGENFISCAL_FACTURADO; break;
                default:
                    origenFiscalId = DBValues._ORIGENFISCAL_INDEFINIDO; break;
            }

            if(!CBTodosAlmacenes.Checked)
            {

                try
                {
                    p_almacen = Int64.Parse(this.ALMACENComboBox.SelectedDataValue.ToString());
                    p_almacenNombre = this.ALMACENComboBox.SelectedText;
                }
                catch
                {
                    MessageBox.Show("Seleccione un almacen valido");
                    return;
                }
            }


            if (!CBTodosTipoGasto.Checked)
            {

                try
                {
                    p_tipogasto = Int64.Parse(this.TIPOGASTOIDTextBox.SelectedDataValue.ToString());
                    p_tipogastoNombre = this.TIPOGASTOIDTextBox.SelectedText;
                }
                catch
                {
                    MessageBox.Show("Seleccione un tipo gasto valido");
                    return;
                }
            }


            if (!this.CBTodosCentroCosto.Checked)
            {
                try
                {
                    p_centrocosto = Int64.Parse(this.CENTROCOSTOIDTextBox.DbValue.ToString());
                    p_centrocostoNombre = this.CENTROCOSTOLabel.Text;
                }
                catch
                {
                    MessageBox.Show("Seleccione un centro costo valido");
                    return;
                }
            }


            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("US_ID", CurrentUserID.CurrentUser.IID);
            dictionary.Add("US_NAME", CurrentUserID.CurrentUser.INOMBRE);

            dictionary.Add("cajeroid", (Decimal)p_cajero);
            dictionary.Add("gastoid", (Decimal)p_gasto);
            dictionary.Add("cajeronombre", p_cajeroNombre);
            dictionary.Add("gastonombre", p_gastoNombre);
            dictionary.Add("fechaini", DTPFrom.Value);
            dictionary.Add("fechafin", DTPTo.Value);
            dictionary.Add("origenFiscalId", origenFiscalId);
            dictionary.Add("almacenid", (Decimal)p_almacen);
            dictionary.Add("almacennombre", p_almacenNombre);
            dictionary.Add("tipogastoid", (Decimal)p_tipogasto);
            dictionary.Add("tipogastonombre", p_tipogastoNombre);
            dictionary.Add("centrocostoid", (Decimal)p_centrocosto);
            dictionary.Add("centrocostonombre", p_centrocostoNombre);

            string strReporte = CBSumarizado.Checked ? "InformeGastosSumarizado.frx" : "InformeGastos.frx";

            iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
            rp.ShowDialog();
            rp.Dispose();
            GC.SuppressFinalize(rp);
        }

        private void WFReciboGastoReporte2_Load(object sender, EventArgs e)
        {
            this.CBOrigenFiscal.SelectedIndex = 2;


            CUSUARIOSD usuariosD = new CUSUARIOSD();
            m_tieneDerechoCambiarAlmacen = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_CONDONARCOMISION_TARJETA, null);
            m_manejaAlmacen = (CurrentUserID.CurrentParameters.IMANEJAALMACEN == "S");


            this.ALMACENComboBox.llenarDatos();
            this.ALMACENComboBox.SelectedIndex = -1;

            this.ALMACENComboBox.Visible = m_manejaAlmacen;
            this.lblAlmacen.Visible = m_manejaAlmacen;

            this.ALMACENComboBox.Enabled = m_tieneDerechoCambiarAlmacen && m_manejaAlmacen;

            if (m_manejaAlmacen && CurrentUserID.CurrentUser.IALMACENID > 0)
                this.ALMACENComboBox.SelectedDataValue = CurrentUserID.CurrentUser.IALMACENID;
            else
                this.CBTodosAlmacenes.Checked = true;

            this.TIPOGASTOIDTextBox.llenarDatos();
            this.TIPOGASTOIDTextBox.SelectedIndex = -1;

        }
    }
}
