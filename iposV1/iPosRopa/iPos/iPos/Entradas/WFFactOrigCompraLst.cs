using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos.Entradas
{
    public partial class WFFactOrigCompraLst : Form
    {
        public WFFactOrigCompraLst()
        {
            InitializeComponent();
        }
        

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            LlenarGridPorBusqueda();
        }

        private void LlenarGridPorBusqueda()
        {
            
            long proveedorId = 0;

            if (ITEMIDTextBox.DbValue != null)
            {
                proveedorId = long.Parse(ITEMIDTextBox.DbValue);
            }

            long sucursalDestinoId = 0;
            if (this.SUCURSALIDTextBox.DbValue != null)
            {
                sucursalDestinoId = Int32.Parse(this.SUCURSALIDTextBox.DbValue.ToString());
            }

            LlenarGrid( proveedorId, sucursalDestinoId);
        }


        private void LlenarGrid( long proveedorId, long sucursalDestinoId)
        {
            try
            {
                this.fACTORIGCOMPRATableAdapter.Fill(this.dSEntrada3.FACTORIGCOMPRA,
                                               dtpFechaInicial.Value,
                                               dtpFechaFinal.Value,
                                               CBFechaFactura.Checked ? "S" : "N",
                                               dtpFechaInicial.Value,
                                               dtpFechaFinal.Value,
                                               CBFechaRecepcion.Checked ? "S" : "N",
                                               CBIncluirProvisionadas.Checked ? "S" : "N", (int)proveedorId, (int)sucursalDestinoId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void ITEMButton_Click(object sender, EventArgs e)
        {
            SeleccionaProveedor();
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

        private void ITEMIDTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ITEMLabel_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void fACTORIGCOMPRADataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex != -1)
            {

                if (fACTORIGCOMPRADataGridView.Columns[e.ColumnIndex].Name == "ColVer")
                {
                    MostrarRegistro("Consultar");
                }
                else if (fACTORIGCOMPRADataGridView.Columns[e.ColumnIndex].Name == "colEditar")
                {
                    MostrarRegistro("Cambiar");
                }
            }
        }


        private void MostrarRegistro(string opc)
        {
            try
            {
                
                int iRetornoRowIndex = fACTORIGCOMPRADataGridView.CurrentRow.Index;
                long regId = (long)fACTORIGCOMPRADataGridView.Rows[iRetornoRowIndex].Cells["DGID"].Value;
                WFFacturaCompOrigEdit fPi = new WFFacturaCompOrigEdit();
                

                    fPi.ReCargar(opc, regId);
                fPi.ShowDialog();
                this.LlenarGridPorBusqueda();
            }
            catch
            {
            }
        }

        private void btnAgregarBanco_Click(object sender, EventArgs e)
        {
            MostrarAgregar();
        }

        private void MostrarAgregar()
        {

            WFFacturaCompOrigEdit fPi = new WFFacturaCompOrigEdit();
            fPi.ReCargar("Agregar", 0);
            fPi.ShowDialog();
            fPi.Dispose();
            GC.SuppressFinalize(fPi);
            LlenarGridPorBusqueda();
        }

        private void CBFechaRecepcion_CheckedChanged(object sender, EventArgs e)
        {
            if (CBFechaRecepcion.Checked)
                CBFechaFactura.Checked = false;
        }

        private void CBFechaFactura_CheckedChanged(object sender, EventArgs e)
        {
            if (CBFechaFactura.Checked)
                CBFechaRecepcion.Checked = false;
        }
    }
}
