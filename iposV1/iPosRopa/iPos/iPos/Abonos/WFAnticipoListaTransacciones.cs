using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iPosData;

namespace iPos
{
    public partial class WFAnticipoListaTransacciones : IposForm
    {
        public DataRow m_rtnDataRow;

        public int m_tipo, m_statusdocto,m_tipodoctoId;

        public WFAnticipoListaTransacciones()
        {
            InitializeComponent();
            this.m_statusdocto = (int)iPosData.DBValues._DOCTO_ESTATUS_BORRADOR;
            this.m_tipodoctoId = (int)iPosData.DBValues._DOCTO_TIPO_VENTA;
            
        }

        public WFAnticipoListaTransacciones(int p_statusdocto, int p_tipodoctoId)
        {
            InitializeComponent();
            this.m_statusdocto = p_statusdocto;
            this.m_tipodoctoId = p_tipodoctoId;

          

        }


        private bool LlenaGrid()
        {
            try
            {
                int? p_personaid = 0;
                int? p_statusdocto, p_cajero, p_tipodoctoId;
                p_cajero =  (this.CBCajerosTodos.Checked) ? 0 : Int32.Parse(this.VENDEDORIDTextBox.DbValue.ToString());
                p_statusdocto = m_statusdocto;
                p_tipodoctoId = m_tipodoctoId;


                DateTime? fechaQuery = DateTime.Parse("1980-01-01");
                if (!CBCorteActual.Checked)
                    fechaQuery = DTPFecha.Value;

                if (m_tipodoctoId == DBValues._DOCTO_TIPO_ANTICIPO_PROVEEDORES)
                {
                    try
                    {
                        p_personaid = Int32.Parse(this.PROVEEDOR1IDTextBox.DbValue.ToString());
                    }
                    catch
                    {
                        p_personaid = 0;
                    }

                }
                else
                {

                    try
                    {
                        p_personaid = Int32.Parse(this.CLIENTEIDTextBox.DbValue.ToString());
                    }
                    catch
                    {
                        p_personaid = 0;
                    }
                }


                this.vENTASLISTAANTICIPOTableAdapter.Fill(this.dSPuntoDeVentaAux.VENTASLISTAANTICIPO, (CBCorteActual.Checked ? "S" : "N"), p_cajero, fechaQuery, p_tipodoctoId, p_personaid);

                if (this.dSPuntoDeVentaAux.VENTASLISTAANTICIPO.Rows.Count <= 0)
                {
                    m_rtnDataRow = null;
                    MessageBox.Show("No hay registros");
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }

            return true;
        }


        private void WFAnticipoListaTransacciones_Load(object sender, EventArgs e)
        {


            if (m_tipodoctoId == DBValues._DOCTO_TIPO_ANTICIPO_PROVEEDORES)
            {
                this.pnlProveedor.Visible = true;
            }
            else
            {
                this.pnlCliente.Visible = true;
            }




            CUSUARIOSD usuariosD = new CUSUARIOSD();
            if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_ELIMINAR_VENTA_DIASATRAS, null) &&
               !usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_VERVENTAS_OTROSCORTES, null))
            {
                this.pnlCorteActual.Enabled = false;

            }

            if (CurrentUserID.ES_ADMINISTRADOR || CurrentUserID.ES_SUPERVISOR)
            {
                this.pnlCajero.Enabled = true;
                //this.pnlTotales.Visible = true;
            }
            else
            {
                this.pnlCajero.Enabled = false;
                //this.pnlTotales.Visible = false;
            }


            string strBuffer = "";
            this.VENDEDORIDTextBox.DbValue = CurrentUserID.CurrentUser.IID.ToString();
            this.VENDEDORIDTextBox.MostrarErrores = false;
            this.VENDEDORIDTextBox.MValidarEntrada(out strBuffer, 1);
            this.VENDEDORIDTextBox.MostrarErrores = true;

            LlenaGrid();

            //if (!
            //LlenaGrid();
            //    )
            //{
            //    this.Close();
            //}
            //LlenarTotales();


        }


        private void RetornarSeleccion(bool bEnterKey)
        {
            try
            {
                int iRetornoRowIndex = /*(bEnterKey && vENTASLISTADataGridView.CurrentRow.Index < (vENTASLISTADataGridView.RowCount - 1)) 
                                        ? vENTASLISTADataGridView.CurrentRow.Index - 1 :*/ vENTASLISTADataGridView.CurrentRow.Index;
                DataGridViewRow dr = vENTASLISTADataGridView.Rows[iRetornoRowIndex];

                m_rtnDataRow = (dr.DataBoundItem as DataRowView).Row;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
            }
        }

        private void vENTASLISTADataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
                RetornarSeleccion(false);
        }


        private void vENTASLISTADataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)13)
            //    RetornarSeleccion(true);

        }

        //private void fillToolStripButton_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        object caja = new object();
        //        this.totalVentaTableAdapter.Fill(this.dSPuntoVenta.TotalVenta, caja);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(ex.Message);
        //    }

        //}

        private void CBTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenaGrid();
            //LlenarTotales();


        }

        private void vENTASLISTADataGridView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                RetornarSeleccion(true);
        }

        private void CBCorteActual_CheckedChanged(object sender, EventArgs e)
        {
            LlenaGrid();
            //LlenarTotales();
        }

        private void CBCajerosTodos_CheckedChanged(object sender, EventArgs e)
        {

            LlenaGrid();
            //LlenarTotales();
        }

        private void VENDEDORIDTextBox_Validated(object sender, EventArgs e)
        {

            LlenaGrid();
            //LlenarTotales();
        }

        private void DTPFecha_Validated(object sender, EventArgs e)
        {

        }

        private void DTPFecha_ValueChanged(object sender, EventArgs e)
        {
            if (!CBCorteActual.Checked)
            {
                LlenaGrid();
                //LlenarTotales();
            }
        }

        private void CLIENTEIDTextBox_Validated(object sender, EventArgs e)
        {
            LlenaGrid();
        }

        private void PROVEEDOR1IDTextBox_Validated(object sender, EventArgs e)
        {
            LlenaGrid();
        }


      
    }
}
