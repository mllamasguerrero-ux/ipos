using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPos
{
    public partial class WFEstadisticosProductoCompra : Form
    {

        long productoId = 0;
        public WFEstadisticosProductoCompra()
        {
            InitializeComponent();
        }

        public WFEstadisticosProductoCompra( long _productoId) : this()
        {
            productoId = _productoId;
        }


        private void LlenarGrid()
        {
            try
            {
                Int64? p_item = 0;
                try
                {
                    p_item = Int64.Parse(this.ITEMIDTextBox.DbValue.ToString());
                }
                catch
                {
                    MessageBox.Show("Seleccione un registro valido");
                    return;
                }

                int iAnio1 = (int)(decimal.Parse(this.ANIO1TextBox.Text.ToString()));
                int iAnio2 = (int)(decimal.Parse(this.ANIO2TextBox.Text.ToString()));
                string strIncluirTrasl = INLUIRTRASLTextBox.Checked ? "S" : "N";

                this.tTL_REP_PROD_COMPRA_COMPARACIONTableAdapter.Fill(this.dSFastReports.TTL_REP_PROD_COMPRA_COMPARACION, p_item, iAnio1, iAnio2, strIncluirTrasl);
                CambiarImagenesGrid();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void ITEMButton_Click(object sender, EventArgs e)
        {
            LOOKPROD look;
            look = new LOOKPROD(ITEMIDTextBox.Text, !CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"), TipoProductoNivel.tp_hijos, 0);
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

                this.ITEMIDTextBox.Focus();

                LlenarGrid();

            }
        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            LlenarGrid();
        }


        private void CambiarImagenesGrid()
        {
            foreach (DataGridViewRow row in tTL_REP_PROD_VENTA_COMPARACIONDataGridView.Rows)
            {
                decimal diferencia = 0;
                try
                {
                    diferencia = decimal.Parse(row.Cells["DGDIFERENCIA"].Value.ToString());
                }
                catch
                {

                }

                DataGridViewImageCell cell = row.Cells["DGIMAGE"] as DataGridViewImageCell;

                if (diferencia > 0)
                {
                    cell.Value = (System.Drawing.Image)iPos.Properties.Resources.th;
                }
                else if (diferencia < 0)
                {
                    cell.Value = (System.Drawing.Image)iPos.Properties.Resources.arrowdown;
                }
                else
                {
                    cell.Value = (System.Drawing.Image)iPos.Properties.Resources.transfer_document;
                }
            }
        }

        private void WFEstadisticosProductoCompra_Load(object sender, EventArgs e)
        {

            int anioActual = DateTime.Today.Year;
            ANIO1TextBox.Text = (anioActual - 1).ToString();
            ANIO2TextBox.Text = anioActual.ToString();


            if(productoId > 0)
            {

                string strBuffer = "";
                this.ITEMIDTextBox.DbValue = productoId.ToString();
                this.ITEMIDTextBox.MostrarErrores = false;
                this.ITEMIDTextBox.MValidarEntrada(out strBuffer, 1);
                this.ITEMIDTextBox.MostrarErrores = true;

                LlenarGrid();
            }



        }

        private void ITEMIDTextBox_Validated(object sender, EventArgs e)
        {
            Int64? p_item = 0;
            try
            {
                p_item = Int64.Parse(this.ITEMIDTextBox.DbValue.ToString());
                if (p_item > 0)
                {
                    LlenarGrid();
                }
            }
            catch
            {
                return;
            }
        }

    }
}
