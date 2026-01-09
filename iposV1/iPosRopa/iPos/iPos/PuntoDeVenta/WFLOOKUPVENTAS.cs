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
    public partial class WFLOOKUPVENTAS : iPos.Tools.ScreenConfigurableForm
    {
        public DataRow m_rtnDataRow;

        public int m_tipo, m_statusdocto,m_tipodoctoId = 0 ;
        public bool m_deshabilitacombotipo = false;

        public bool m_bLoadingform = false;

        public bool m_derechoVariosDiasPendientes = false;

        public bool m_derechoVariosDiasCerradas = false;

        public bool m_busquedaInicialAmplia = false;

        public bool m_soloPorSurtir = false;

        bool m_manejaAlmacen = false;
        bool m_usuarioPuedeCambiarAlmacen = false;

        public WFLOOKUPVENTAS()
        {
            InitializeComponent();
            try
            {
                this.m_statusdocto = (int)iPosData.DBValues._DOCTO_ESTATUS_BORRADOR;
                this.m_tipodoctoId = CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S") ? (int)iPosData.DBValues._DOCTO_TIPO_VENTAMOVIL : (int)iPosData.DBValues._DOCTO_TIPO_VENTA;
            }
            catch {}
        }

        public WFLOOKUPVENTAS(int p_statusdocto, int p_tipodoctoId)
        {
            InitializeComponent();
            this.m_statusdocto = p_statusdocto;
            this.m_tipodoctoId = p_tipodoctoId;
          

        }


        public WFLOOKUPVENTAS(int p_statusdocto, int p_tipodoctoId, bool deshabilitacombotipo) :this (p_statusdocto,  p_tipodoctoId)
        {
            m_deshabilitacombotipo = deshabilitacombotipo;

        }

        public void LlenarTotales()
        {

            if (!CBCorteActual.Checked)
            {
                pnlTotales.Visible = false;
                return;
            }

                
            CUSUARIOSD usuariosD = new CUSUARIOSD();
            if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_VER_TOTALES_LISTADOVENTAS, null))
            {
                pnlTotales.Visible = false;
                return;
            }

            pnlTotales.Visible = true;

            long cajeroId = (this.CBCajerosTodos.Checked) ? 0 : Int64.Parse(this.VENDEDORIDTextBox.DbValue.ToString());

            DateTime fechaQuery = DateTime.Parse("1980-01-01");
            DateTime fechaFinQuery = DateTime.Parse("1980-01-01");
            if (!CBCorteActual.Checked || cajeroId == 0)
            {
                fechaQuery = DTPFecha.Value;
                fechaFinQuery = DTPFecha.Value;
            }
            else
            {
                CCORTED corteD = new CCORTED();
                CCORTEBE corteBE = new CCORTEBE();
                corteBE.ICAJEROID = cajeroId;
                corteBE = corteD.seleccionarCORTEACTIVOXCAJERO(corteBE, null);
                if(corteBE == null)
                {

                    pnlTotales.Visible = false;
                    return;
                }

                fechaQuery = corteBE.IFECHACORTE;
                fechaFinQuery = corteBE.IFECHACORTE.AddDays(1);
            }

            this.totalDevolucionesTableAdapter.Fill(this.dSPuntoVenta.TotalDevoluciones, (this.CBCajerosTodos.Checked) ? 0 : Int64.Parse(this.VENDEDORIDTextBox.DbValue.ToString()), (CBCorteActual.Checked ? "S" : "N"), fechaQuery, fechaFinQuery);
            this.totalVentaTableAdapter.Fill(this.dSPuntoVenta.TotalVenta, (this.CBCajerosTodos.Checked) ? 0 : Int64.Parse(this.VENDEDORIDTextBox.DbValue.ToString()), (CBCorteActual.Checked ? "S" : "N"), fechaQuery, fechaFinQuery);
            this.totalTrasladosTableAdapter.Fill(this.dSPuntoVenta.TotalTraslados, (this.CBCajerosTodos.Checked) ? 0 : Int64.Parse(this.VENDEDORIDTextBox.DbValue.ToString()), (CBCorteActual.Checked ? "S" : "N"), fechaQuery, fechaFinQuery);
            this.totalDevoTableAdapter.Fill(this.dSPuntoDeVentaAux.TotalDevo, (this.CBCajerosTodos.Checked) ? 0 : Int64.Parse(this.VENDEDORIDTextBox.DbValue.ToString()), (CBCorteActual.Checked ? "S" : "N"), fechaQuery, fechaFinQuery);

            decimal ventasTotales = 0;
            decimal cancelacionesTotales = 0;
            decimal devolucionesTotales = 0;
            decimal ventasNetas = 0;
            decimal trasladosTotales = 0;

            try
            {
                ventasTotales = decimal.Parse(this.dSPuntoVenta.TotalVenta.Rows[0][0].ToString());
            }
            catch
            {
            }
            try
            {
                cancelacionesTotales = decimal.Parse(this.dSPuntoVenta.TotalDevoluciones.Rows[0][0].ToString());
            }
            catch
            {
            }


            try
            {
                devolucionesTotales = decimal.Parse(this.dSPuntoDeVentaAux.TotalDevo.Rows[0][0].ToString());
            }
            catch
            {
            }

            try
            {
                ventasNetas = ventasTotales - cancelacionesTotales - devolucionesTotales;
            }
            catch
            {
            }

            try
            {
                trasladosTotales = decimal.Parse(this.dSPuntoVenta.TotalTraslados.Rows[0][0].ToString()); ;
            }
            catch
            {
            }



            this.TBVentasNetas.Text = ventasNetas.ToString("N2");
            this.vENTASTOTALESTextBox.Text = ventasTotales.ToString("N2");
            this.CANCELACIONESTOTALESTextBox.Text = cancelacionesTotales.ToString("N2");
            this.DEVOLUCIONESTOTALESTextBox.Text = devolucionesTotales.ToString("N2");
            TBTrasladosTextBox.Text = trasladosTotales.ToString("N2");

        }


        private bool LlenaGrid()
        {
            try
            {
                int? p_statusdocto, p_cajero, p_tipodoctoId, p_estadoSurtidoId = 0, p_almacenid;
                p_cajero = /*(int)iPos.CurrentUserID.CurrentUser.IID*/ (this.CBCajerosTodos.Checked) ? 0 : Int32.Parse(this.VENDEDORIDTextBox.DbValue.ToString());
                p_almacenid = (this.CBAlmacenesTodos.Checked) ? 0 : Int32.Parse(this.ALMACENComboBox.SelectedDataValue.ToString());
                p_statusdocto = m_statusdocto;
                p_tipodoctoId = m_tipodoctoId;

                p_estadoSurtidoId = (this.CBSoloPorSurtir.Checked) ? (int)DBValues._DOCTO_SURTIDOESTADO_PENDIENTE : 0;

                DateTime ? fechaQuery = DateTime.Parse("1980-01-01");
                DateTime? fechaQueryFin = DateTime.Parse("1980-01-01");
                //if (!CBCorteActual.Checked)
                fechaQuery = DTPFecha.Value;

                if (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL != null && CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
                        fechaQueryFin = DTPFechaFin.Value;
                else if (m_derechoVariosDiasPendientes && m_statusdocto == DBValues._DOCTO_ESTATUS_BORRADOR)
                        fechaQueryFin = DTPFechaFin.Value;
                else if (m_derechoVariosDiasCerradas && m_statusdocto != DBValues._DOCTO_ESTATUS_BORRADOR)
                    fechaQueryFin = DTPFechaFin.Value;
                else
                        fechaQueryFin = fechaQuery;


                    this.vENTASLISTATableAdapter1.Fill(dSPuntoDeVentaAux2.VENTASLISTA, p_statusdocto, p_tipodoctoId, p_cajero, fechaQuery, fechaQueryFin, (CBCorteActual.Checked ? "S" : "N"), p_estadoSurtidoId, p_almacenid);


                if (dSPuntoDeVentaAux2.VENTASLISTA.Rows.Count <= 0)
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
            m_bLoadingform = true;
            configuraLaPantalla(true, true);

            CUSUARIOSD usuariosD = new CUSUARIOSD();
            if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_ELIMINAR_VENTA_DIASATRAS, null) &&
               !usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_VERVENTAS_OTROSCORTES, null))
            {
                this.pnlCorteActual.Enabled = false;

            }


            if(!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_ENRUTAR_COTIZACION, null))
            {
                this.DGCOTI_ENRUTADA.Visible = false;
            }


            m_derechoVariosDiasPendientes = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_VENTASPENDIENTES_VARIOSDIAS, null);
            m_derechoVariosDiasCerradas = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_VENTASCERRADAS_X_RANGO, null);

            if (CurrentUserID.ES_ADMINISTRADOR || CurrentUserID.ES_SUPERVISOR)
            {

                this.pnlTotales.Visible = true;
            }
            else
            {
                this.pnlTotales.Visible = false;
            }

            if ((m_statusdocto == DBValues._DOCTO_ESTATUS_BORRADOR && usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_VER_VENTAS_PENDIENTES, null))
                || (m_statusdocto != DBValues._DOCTO_ESTATUS_BORRADOR && usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_VER_VENTAS_COMPLETASOCANCELADAS, null)))
            {
                this.pnlCajero.Enabled = true;
                this.CBCajerosTodos.Checked = true;
            }
            else
            {
                this.pnlCajero.Enabled = false;
                this.CBCajerosTodos.Checked = false;
            }


            if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_VERVENTAS_OTROSCORTES, null))
            {
                this.CBCorteActual.Enabled = false;
            }
            
            m_manejaAlmacen = !((bool)CurrentUserID.CurrentParameters.isnull["IMANEJAALMACEN"] || !CurrentUserID.CurrentParameters.IMANEJAALMACEN.Equals("S"));
            if (!this.m_manejaAlmacen)
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



            string strBuffer = "";
            this.VENDEDORIDTextBox.DbValue = CurrentUserID.CurrentUser.IID.ToString();
            this.VENDEDORIDTextBox.MostrarErrores = false;
            this.VENDEDORIDTextBox.MValidarEntrada(out strBuffer, 1);
            this.VENDEDORIDTextBox.MostrarErrores = true;


            if (!m_deshabilitacombotipo)
            {
                this.CBTipo.SelectedIndex = 0; 
            }
            else
            {
                this.CBTipo.Visible = false;
                LBTIPOREG.Visible = false;
            }

            if (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL != null && CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
            {

                DTPFecha.Value = DateTime.Today.AddDays(-8);
                DTPFechaFin.Value = DateTime.Today;
                pnlFechaTo.Visible = true;
            }
            else if(m_derechoVariosDiasPendientes && m_statusdocto == DBValues._DOCTO_ESTATUS_BORRADOR)
            {

                DTPFecha.Value = DateTime.Today.AddDays(-1 * CurrentUserID.CurrentParameters.IPENDMAXDIAS);
                DTPFechaFin.Value = DateTime.Today;
                pnlFechaTo.Visible = true;
            }
            else if (m_derechoVariosDiasCerradas && m_statusdocto != DBValues._DOCTO_ESTATUS_BORRADOR)
            {

                DTPFecha.Value = DateTime.Today.AddDays(-1 * CurrentUserID.CurrentParameters.IPENDMAXDIAS);
                DTPFechaFin.Value = DateTime.Today;
                pnlFechaTo.Visible = true;
            }
            else
            {

                pnlFechaTo.Visible = false;
            }

            this.m_tipodoctoId = this.m_tipodoctoId == 0 ? (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S") ? (int)iPosData.DBValues._DOCTO_TIPO_VENTAMOVIL : (int)iPosData.DBValues._DOCTO_TIPO_VENTA) : this.m_tipodoctoId;


            if(m_busquedaInicialAmplia)
            {
                CBCorteActual.Checked = false;
                DTPFecha.Value = DateTime.Parse("01/01/2000");
                DTPFechaFin.Value = DateTime.Parse("01/01/2100");
                CBCajerosTodos.Checked = true;
            }


            if(m_statusdocto == DBValues._DOCTO_ESTATUS_BORRADOR)
            {
                DGConsecutivo.Visible = true;

            }

            if (CurrentUserID.CurrentParameters.IHABSURTIDOPREVIO == "S")
            {
                if (m_soloPorSurtir)
                {
                    CBSoloPorSurtir.Checked = m_soloPorSurtir;
                }
            }
            else
            {
                pnlSoloPorSurtir.Visible = false;
                CBSoloPorSurtir.Checked = false;
            }

            LlenaGrid();
            LlenarTotales();

            /*if (m_statusdocto == 0)
            {
                this.CBTipo.Visible = false;
                LBTIPOREG.Visible = false;
            }*/
            /*switch (m_tipodoctoId)
            {
                case (int)DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO:
                    this.CBTipo.SelectedIndex = 3;
                    break;
                default:*/
                    //this.CBTipo.SelectedIndex = 0;  //esto automaticamente manda llenar los grids ( por el evento )
                    /*break;
                     

            }*/




            //if (!
            //LlenaGrid();
            //    )
            //{
            //    this.Close();
            //}
            //LlenarTotales();

            m_bLoadingform = false;

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
        //        this.totalVentaTableAdapter.Fill(this.dSPuntoVenta.TotalVenta, caja);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(ex.Message);
        //    }

        //}

        private void CBTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!m_bLoadingform)
            {
                switch (CBTipo.SelectedIndex)
                {
                    case 0: this.m_tipodoctoId = CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S") ? (int)iPosData.DBValues._DOCTO_TIPO_VENTAMOVIL : (int)iPosData.DBValues._DOCTO_TIPO_VENTA; break;
                    case 1: this.m_tipodoctoId = 31; break;
                    case 2: this.m_tipodoctoId = CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S") ? (int)iPosData.DBValues._DOCTO_TIPO_CANCELACIONMOVIL : (int)iPosData.DBValues._DOCTO_TIPO_CANCELACION; break;
                    case 3: this.m_tipodoctoId = 25; break;
                    case 4: this.m_tipodoctoId = (int)DBValues._DOCTO_TIPO_PEDIDO_TRASPASO_SALIDA; break;
                    case 5: this.m_tipodoctoId = (int)DBValues._DOCTO_TIPO_TRASPASO_ALMACEN; break;
                    case 6: this.m_tipodoctoId = (int)DBValues._DOCTO_TIPO_VENTA_FUTURO; break;

                    default: this.m_tipodoctoId = 0; break;

                }

                LlenaGrid();
                LlenarTotales();
            }


        }

        private void vENTASLISTADataGridView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                RetornarSeleccion(true);
        }

        private void CBCorteActual_CheckedChanged(object sender, EventArgs e)
        {
            if (!m_bLoadingform)
            {
                LlenaGrid();
                LlenarTotales();
            }
        }

        private void CBCajerosTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (!m_bLoadingform)
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

        private void DTPFecha_Validated(object sender, EventArgs e)
        {

        }

        private void CBSoloPorSurtir_CheckedChanged(object sender, EventArgs e)
        {

            if (!m_bLoadingform)
            {
                    LlenaGrid();
                    LlenarTotales();
            }
        }

        private void DTPFecha_ValueChanged(object sender, EventArgs e)
        {
            if (!m_bLoadingform)
            {
                if (!CBCorteActual.Checked)
                {
                    LlenaGrid();
                    LlenarTotales();
                }
            }
        }

        private void DTPFechaFin_ValueChanged(object sender, EventArgs e)
        {

            if (!m_bLoadingform)
            {
                if (!CBCorteActual.Checked)
                {
                    LlenaGrid();
                    LlenarTotales();
                }
            }
        }



        private void CBAlmacenesTodos_CheckedChanged(object sender, EventArgs e)
        {

            if (!m_bLoadingform)
            {
                LlenaGrid();
                LlenarTotales();
            }
        }

        private void ALMACENComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (!m_bLoadingform)
            {
                LlenaGrid();
                LlenarTotales();
            }
        }





    }
}
