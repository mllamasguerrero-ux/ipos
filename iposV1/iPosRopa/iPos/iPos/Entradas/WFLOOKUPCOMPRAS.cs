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
    public partial class WFLOOKUPCOMPRAS : IposForm
    {
        public DataRow m_rtnDataRow;

        public int m_tipo, m_statusdocto,m_tipodoctoId, m_subtipodoctoId = 0;
        public bool m_preTodosLosCajeros = false;
        public bool m_preCorteActual = true;
        private bool m_loadingForm = true;
        public bool m_deshabilitacombotipo = false;

        bool m_manejaAlmacen = false;
        bool m_usuarioPuedeCambiarAlmacen = false;

        public WFLOOKUPCOMPRAS()
        {
            InitializeComponent();
            this.m_statusdocto = (int)iPosData.DBValues._DOCTO_ESTATUS_BORRADOR;
            this.m_tipodoctoId = (int)iPosData.DBValues._DOCTO_TIPO_VENTA;
            
        }

        public WFLOOKUPCOMPRAS(int p_statusdocto, int p_tipodoctoId)
        {
            InitializeComponent();
            this.m_statusdocto = p_statusdocto;
            this.m_tipodoctoId = p_tipodoctoId;
          

        }


        public WFLOOKUPCOMPRAS(int p_statusdocto, int p_tipodoctoId, bool deshabilitacombotipo)
            : this(p_statusdocto, p_tipodoctoId)
        {
            m_deshabilitacombotipo = deshabilitacombotipo; ;


        }

        public void LlenarTotales()
        {
            int? p_statusdocto, p_tipodoctoId;
            int p_cajero = /*(int)iPos.CurrentUserID.CurrentUser.IID*/ (this.CBCajerosTodos.Checked) ? 0 : Int32.Parse(this.VENDEDORIDTextBox.DbValue.ToString());
            p_statusdocto = m_statusdocto;
            p_tipodoctoId = m_tipodoctoId;


            DateTime fechaQuery = DateTime.Parse("1980-01-01");
            if (!CBCorteActual.Checked)
                fechaQuery = DTPFecha.Value;

            this.totalDevolucionesTableAdapter.Fill(this.dSEntradas.TotalDevoluciones, p_cajero, (CBCorteActual.Checked ? "S" : "N"), fechaQuery);
            this.totalVentaTableAdapter.Fill(this.dSEntradas.TotalVenta, p_cajero, (CBCorteActual.Checked ? "S" : "N"), fechaQuery);
            this.totalTrasladosTableAdapter.Fill(this.dSEntradas.TotalTraslados, p_cajero, (CBCorteActual.Checked ? "S" : "N"), fechaQuery);
            decimal ventasTotales = 0;
            decimal devolucionesTotales = 0;
            decimal ventasNetas = 0;
            decimal trasladosTotales = 0;

            try
            {
                ventasTotales = decimal.Parse(this.dSEntradas.TotalVenta.Rows[0][0].ToString());
            }
            catch
            {
            }
            try
            {
                devolucionesTotales = decimal.Parse(this.dSEntradas.TotalDevoluciones.Rows[0][0].ToString());
            }
            catch
            {
            }
            try
            {
                ventasNetas = ventasTotales - devolucionesTotales;
            }
            catch
            {
            }

            try
            {
                trasladosTotales = decimal.Parse(this.dSEntradas.TotalTraslados.Rows[0][0].ToString()); ;
            }
            catch
            {
            }

            this.TBVentasNetas.Text = ventasNetas.ToString("N2");
            this.vENTASTOTALESTextBox.Text = ventasTotales.ToString("N2");
            this.dEVOLUCIONESTOTALESTextBox.Text = devolucionesTotales.ToString("N2");
            //TBTrasladosTextBox.Text = trasladosTotales.ToString("N2");

        }


        private bool LlenaGrid()
        {
            if (m_loadingForm)
                return true;

            try
            {
                int? p_statusdocto, p_tipodoctoId, p_subTipoDoctoId = 0;
                int p_cajero = /*(int)iPos.CurrentUserID.CurrentUser.IID*/ (this.CBCajerosTodos.Checked) ? 0 : Int32.Parse(this.VENDEDORIDTextBox.DbValue.ToString());
                int p_almacenid = (this.CBAlmacenesTodos.Checked) ? 0 : Int32.Parse(this.ALMACENComboBox.SelectedDataValue.ToString());
                p_statusdocto = m_statusdocto;
                p_tipodoctoId = m_tipodoctoId;
                p_subTipoDoctoId = m_subtipodoctoId;


                DateTime fechaQuery = DateTime.Parse("1980-01-01");
                if (CBFecha.Checked)
                    fechaQuery = DTPFecha.Value;

                this.vENTASLISTATableAdapter1.Fill(this.dSEntradasAux.VENTASLISTA, p_statusdocto, p_tipodoctoId, p_subTipoDoctoId, p_cajero, (CBCorteActual.Checked ? "S" : "N"), fechaQuery, p_almacenid);
                if (this.dSEntradasAux.VENTASLISTA.Rows.Count <= 0)
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


        private void WFLOOKUPVENTAS_Load(object sender, EventArgs e)
        {
            //this.CBTipo.SelectedIndex = 0;
            m_subtipodoctoId = 0;

            string strBuffer = "";
            this.VENDEDORIDTextBox.DbValue = CurrentUserID.CurrentUser.IID.ToString();
            this.VENDEDORIDTextBox.MostrarErrores = false;
            this.VENDEDORIDTextBox.MValidarEntrada(out strBuffer, 1);
            this.VENDEDORIDTextBox.MostrarErrores = true;


            this.CBCorteActual.Checked = this.m_preCorteActual;
            this.CBCajerosTodos.Checked = this.m_preTodosLosCajeros;



            CUSUARIOSD usuariosD = new CUSUARIOSD();
            m_manejaAlmacen = !((bool)CurrentUserID.CurrentParameters.isnull["IMANEJAALMACEN"] || !CurrentUserID.CurrentParameters.IMANEJAALMACEN.Equals("S"));
            if(!this.m_manejaAlmacen)
            {
                CBAlmacenesTodos.Checked = true;
                pnlAlmacen.Visible = false;
            }
            else
            {
                m_usuarioPuedeCambiarAlmacen = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_FILTARPORALMACEN, null);
                pnlAlmacen.Visible = true;
                pnlAlmacen.Enabled = m_usuarioPuedeCambiarAlmacen;
                this.ALMACENComboBox.llenarDatos();
                SetDefaultAlmacenEstatus();
            }


            if (!m_deshabilitacombotipo)
            {

                switch (m_tipodoctoId)
                {
                    case (int)DBValues._DOCTO_TIPO_ORDEN_COMPRA:
                        this.CBTipo.SelectedIndex = 4;
                        break;
                    default:
                        this.CBTipo.SelectedIndex = 0;  //esto automaticamente manda llenar los grids ( por el evento )
                        break;


                }

                m_loadingForm = false;
                if (!LlenaGrid())
                {
                    //this.Close();
                }
                LlenarTotales();
            }
            else
            {

                this.CBTipo.Visible = false;
                LBTIPOREG.Visible = false;
                m_loadingForm = false;
                LlenaGrid();
                LlenarTotales();
            }



        }



        public void SetDefaultAlmacenEstatus()
        {


            if (!(bool)CurrentUserID.CurrentUser.isnull["IALMACENID"])
                this.ALMACENComboBox.SelectedDataValue = CurrentUserID.CurrentUser.IALMACENID;
            else
                this.ALMACENComboBox.SelectedDataValue = DBValues._ALMACEN_DEFAULT;

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
        //        this.totalVentaTableAdapter.Fill(this.dSEntradas.TotalVenta, (int)caja);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(ex.Message);
        //    }

        //}

        private void CBTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_subtipodoctoId = 0;

            if (!CBTipoValidar())
            {
                CBTipo.SelectedIndex = 0;
                return;
            }

            switch (CBTipo.SelectedIndex)
            {
                case 0: this.m_tipodoctoId = 11; break;
                case 1: this.m_tipodoctoId = 13; break;
                case 2: this.m_tipodoctoId = (int)DBValues._DOCTO_TIPO_PEDIDO_COMPRA; break;
                case 3: this.m_tipodoctoId = (int)DBValues._DOCTO_TIPO_TRASPASO_REC; break;
                case 4: this.m_tipodoctoId = (int)DBValues._DOCTO_TIPO_ORDEN_COMPRA; break;
                case 5: this.m_tipodoctoId = 11; m_subtipodoctoId = (int)DBValues._DOCTO_SUBTIPO_COMPRARECORDEN; break;
                case 6: this.m_tipodoctoId = (int)DBValues._DOCTO_TIPO_TRASPASO_ENVIO_DEVO; break;
                case 7: this.m_tipodoctoId = (int)DBValues._DOCTO_TIPO_PEDIDO_ENVIO_DEVO; break;
                case 8: this.m_tipodoctoId = (int)DBValues._DOCTO_TIPO_COMPRA_SUC; break;
                default: this.m_tipodoctoId = 0; break;

            }

            if(this.m_tipodoctoId == (int)DBValues._DOCTO_TIPO_COMPRA_SUC)
            {
                DGSUCURSAL.Visible = true;
                CLAVETIPODOCTO.Visible = false;
            }
            else
            {
                DGSUCURSAL.Visible = false;
                CLAVETIPODOCTO.Visible = true;

            }

            LlenaGrid();
            LlenarTotales();


        }

        private void vENTASLISTADataGridView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                RetornarSeleccion(true);
        }

        private void CBCorteActual_CheckedChanged(object sender, EventArgs e)
        {

            LlenaGrid();
            LlenarTotales();
        }

        private void DTPFecha_ValueChanged(object sender, EventArgs e)
        {

            if (!CBCorteActual.Checked)
            {
                LlenaGrid();
                LlenarTotales();
            }
        }

        private void VENDEDORIDTextBox_Validated(object sender, EventArgs e)
        {

            LlenaGrid();
            LlenarTotales();
        }

        private void CBAlmacenesTodos_CheckedChanged(object sender, EventArgs e)
        {

            LlenaGrid();
            LlenarTotales();
        }

        private void ALMACENComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            LlenaGrid();
            LlenarTotales();
        }
        

        private void CBFecha_CheckedChanged(object sender, EventArgs e)
        {

            LlenaGrid();
            LlenarTotales();
        }

        private void CBCajerosTodos_CheckedChanged(object sender, EventArgs e)
        {

            LlenaGrid();
            LlenarTotales();
        }

        private bool CBTipoValidar()
        {

            switch (CBTipo.SelectedIndex)
            {
                case 0:
                case 4:
                    break;
                default: 
                    if (m_statusdocto == 0 )
                    {
                        MessageBox.Show("Para transacciones en estatus pendiente, solo puede seleccionar compras y ordenes de compras");
                        return false;
                    }
                    break;

            }

            return true;
            
            
        }

      
    }
}
