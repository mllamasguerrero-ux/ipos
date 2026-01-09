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

namespace iPos
{
    public partial class WFPagoCompProveeList : Form
    {

        public bool m_bPorSucursal = true;

        public WFPagoCompProveeList()
        {
            InitializeComponent();
            m_bPorSucursal = true;
        }


        public WFPagoCompProveeList(bool bPorSucursal) : this()
        {
            m_bPorSucursal = bPorSucursal;
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            LlenarGridPorBusqueda();
        }

        private void LlenarGridPorBusqueda()
        {

            long formaPago = ObtenerFormaPago();
            long proveedorId = 0;

            if (ITEMIDTextBox.DbValue != null)
            {
                proveedorId = long.Parse(ITEMIDTextBox.DbValue);
            }
            LlenarGrid(formaPago,  proveedorId);
        }


        private void LlenarGrid(long formaPago,  long proveedorId)
        {
            try
            {
                this.cOMPRASPAGOSLISTTableAdapter.Fill(this.dSAbonos2.COMPRASPAGOSLIST,
                                               dtpFechaInicial.Value,
                                               dtpFechaFinal.Value,
                                               CBIncluirCancelaciones.Checked ? "S" : "N", formaPago,  proveedorId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }



        private long ObtenerFormaPago()
        {
            switch (FormaPagoComboBox.SelectedIndex)
            {

                case 0:
                    return DBValues._FORMA_PAGO_EFECTIVO;

                case 1:
                    return DBValues._FORMA_PAGO_TARJETA;

                case 2:
                    return DBValues._FORMA_PAGO_TARJETA;

                case 3:
                    return DBValues._FORMA_PAGO_TARJETA;

                case 4:
                    return DBValues._FORMA_PAGO_CHEQUE;

                case 5:
                    return DBValues._FORMA_PAGO_VALE;

                case 6:
                    return DBValues._FORMA_PAGO_TRANSFERENCIA;

                case 7:
                    return DBValues._FORMA_PAGO_INTERCAMBIOMERCANCIACREDITO;

                case 8:
                    return DBValues._FORMA_PAGO_NOIDENTIFICADO;

                case 9:
                    return DBValues._FORMA_PAGO_DEPOSITO;

                case 10:
                    return DBValues._FORMA_PAGO_DEPOSITOTERCERO;
                case 11:
                    return 0;
                default:
                    return 0;
            }
        }

        private void btnAgregarBanco_Click(object sender, EventArgs e)
        {

            WFPagoCompProveeEdit wf = new WFPagoCompProveeEdit(this.m_bPorSucursal);
            wf.ShowDialog();
            wf.Dispose();
            GC.SuppressFinalize(wf);

            LlenarGridPorBusqueda();

        }


        private void pAGOLISTDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cOMPRASPAGOSLISTDataGridView.Columns[e.ColumnIndex].Name == "DGVer")
            {
                if (cOMPRASPAGOSLISTDataGridView.Rows[e.RowIndex].Cells["DGFolio"].Value != null)
                {
                    long folioId = (long)cOMPRASPAGOSLISTDataGridView.Rows[e.RowIndex].Cells["DGFolio"].Value;

                    WFPagoCompProveeEdit wFPagoCompuestoEdit = new WFPagoCompProveeEdit(folioId, this.m_bPorSucursal);
                    wFPagoCompuestoEdit.ShowDialog();
                    wFPagoCompuestoEdit.Dispose();
                    GC.SuppressFinalize(wFPagoCompuestoEdit);

                    LlenarGridPorBusqueda();


                }
            }
        }

        private void WFPagoCompProveeList_Load(object sender, EventArgs e)
        {
            LlenarGridPorBusqueda();
        }



        private void SeleccionaProveedor()
        {
            iPos.Catalogos.WFProveedores look = new iPos.Catalogos.WFProveedores();
            look.m_bSelecionarRegistro = true;
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                string strBuffer = "";
                this.ITEMIDTextBox.DbValue = ((long)dr["ID"]).ToString();
                this.ITEMIDTextBox.MostrarErrores = false;
                this.ITEMIDTextBox.MValidarEntrada(out strBuffer, 1);
                this.ITEMIDTextBox.MostrarErrores = true;

            }
        }

        private void ITEMButton_Click(object sender, EventArgs e)
        {
            SeleccionaProveedor();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {

            long formaPago = ObtenerFormaPago();
            long proveedorId = 0;

            if (ITEMIDTextBox.DbValue != null)
            {
                proveedorId = long.Parse(ITEMIDTextBox.DbValue);
            }
            

                


            Dictionary<string, object> dictionary = new Dictionary<string, object>();


            dictionary.Add("fechafinal", dtpFechaInicial.Value);
            dictionary.Add("fechainicial", dtpFechaFinal.Value);
            dictionary.Add("personaid", proveedorId);
            dictionary.Add("incluircancelaciones", CBIncluirCancelaciones.Checked ? "S" : "N");
            dictionary.Add("formapagoid", formaPago);
            dictionary.Add("formapago", formaPago >= 0 ? FormaPagoComboBox.SelectedText : "");
            dictionary.Add("persona", proveedorId>= 0 ? ITEMLabel.Text : "Todos");




            string strReporte = "InformePagosProveeMultiSuc.frx";



            iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
            rp.ShowDialog();
            rp.Dispose();
            GC.SuppressFinalize(rp);
        }
    }
}
