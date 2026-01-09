using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using iPosData;
using iPosBusinessEntity;
using FirebirdSql.Data.FirebirdClient;
using FlatTabControl;
using iPosReporting;
using System.Diagnostics;
using DataLayer.Importaciones;
using System.IO;

namespace iPos
{

    enum estadoTransaccion { e_SinIniciar, e_Iniciado, e_Cerrada, e_Cancelada };
    public partial class WFCompras : IposForm
    {

        #region Definición de variables y objetos de clase

        int m_estadoTransaccion;
        decimal m_dMontoTransaccion;
        decimal m_dSumaImporte;
        decimal m_dMontoIva;
        decimal m_dDescuento;
        decimal m_dGastosAdic;
        string m_printer = "";
        long m_sucursalTID;
        bool m_bSalirSinPreguntar;
        CDOCTOBE m_Docto;
        CCAJABE m_Caja;

        bool m_enableDescuento = false;


        tipoTransaccionV m_tipoTransaccion;
        CDOCTOBE m_DoctoRef;


        bool m_manejaAlmacen = false;
        bool m_usuarioPuedeCambiarAlmacen = false;

        long m_iProveedorId = 0;
        bool m_validateProveedorOn = true;
        string m_proveedorEsImportador = "N";

        int m_CommandLineWidth = 290;

        bool m_usuarioPuedeCambiarGastosAdic = false;
        bool m_usuarioPuedeImportarCompras = false;



        decimal m_dMontoTransaccionUSD;

        #endregion

        #region Apariencia e Inicializacion

        public WFCompras()
        {
            InitializeComponent();
            ResetearVariablesForm();
            m_bSalirSinPreguntar = false;
        }

        private void ResetearVariablesForm()
        {
            m_iProveedorId = 0;
            m_estadoTransaccion = (int)estadoTransaccion.e_SinIniciar;
            m_Docto = new CDOCTOBE();
            m_Caja = new CCAJABE();
            m_Docto.ITIPODOCTOID = DBValues._DOCTO_TIPO_COMPRA;/*DBValues._DOCTO_TIPO_VENTA*/;
            m_dMontoTransaccion = 0;
            m_dSumaImporte = 0;
            m_dMontoIva = 0;
            m_dDescuento = 0;
            m_dGastosAdic = 0;
            m_sucursalTID = 0;
            RefrescarEstatusBotones();

            m_tipoTransaccion = tipoTransaccionV.t_compra;
            m_DoctoRef = null;

            m_proveedorEsImportador = "N";
        }





        private void WFPuntoDeTransaccion_Load(object sender, EventArgs e)
        {

            if (!ChecarPermisos())
            {
                this.Close();
                return;
            }

            CUSUARIOSD usuariosD = new CUSUARIOSD();
            if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, 10006, null))
            {
                this.TBDescuento.Text = "0";
                this.TBDescuento.Enabled = false;
                m_enableDescuento = false;
            }
            else
            {
                this.TBDescuento.Enabled = true;
                m_enableDescuento = true;
            }


            m_usuarioPuedeCambiarGastosAdic = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_GASTOSADIC_COMPRA, null);

            m_usuarioPuedeImportarCompras = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_IMPORTAR_COMPRAS, null);

            if (bEstaConfiguradoParaPiezasyCajas())
            {
                formatCajasBotellasPiezas(true);
                //gridPVDataGridView.Columns["GVCANTIDAD"].ReadOnly = true;

            }
            else
            {
                formatCajasBotellasPiezas(false);
            }



            this.LBVendedor.Text = iPos.CurrentUserID.CurrentUser.INOMBRE;
            this.LBSucursal.Text = iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO;
            this.LBFecha.Text = DateTime.Today.ToString("dd/MM/yyyy");
            
            this.LBCliente.Text = "MOSTRADOR";
            this.gridPVTableAdapter.SelectCommandTimeout = 100;
            m_printer = Ticket.GetReceiptPrinter();

            if (!ChecarFechaDelSistema())
                return;

            ChecarCorteActivo();
            ObtenerCaja();
            FormatTotalPiezas();
            IrANuevaTransaccion();
            this.TBCommandLine.Focus();




            m_manejaAlmacen = !((bool)CurrentUserID.CurrentParameters.isnull["IMANEJAALMACEN"] || !CurrentUserID.CurrentParameters.IMANEJAALMACEN.Equals("S"));
            if (!m_manejaAlmacen)
            {
                this.ALMACENComboBox.Visible = false;
                this.lblAlmacen.Visible = false;
            }
            else
            {

                this.ALMACENComboBox.Visible = true;
                this.lblAlmacen.Visible = true;

                this.ALMACENComboBox.llenarDatos();
                try
                {
                    this.ALMACENComboBox.SelectedIndex = -1;

                    m_usuarioPuedeCambiarAlmacen =  usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_CAMBIARDEALMACEN, null);

                    SetDefaultAlmacenEstatus();



                }
                catch
                {
                }
            }




            if (CurrentUserID.CurrentParameters.IDIVIDIR_REM_FACT.Equals("N"))
            {
                this.CBOrigenFiscal.Enabled = true;//false;
                this.CBOrigenFiscal.SelectedIndex = 0;
            }


            if (CurrentUserID.CurrentParameters.IAUTOCOMPPROD.Equals("S"))
            {
                this.TBCommandLine.AutoCompleteMode = AutoCompleteMode.Suggest;
                this.TBCommandLine.AutoCompleteSource = AutoCompleteSource.CustomSource;
                this.TBCommandLine.AutoCompleteCustomSource = CurrentUserID.GetAutoSourceCollectionFromTable();
            }

            VisibilidadUSDInfo(CBMostrarUSD.Checked);

            SetGastosAdicionalesVisibility();

            /*this.ComboProveedor.llenarDatos();
            this.ComboProveedor.SelectedIndex = -1;*/
        }



        private void SetGastosAdicionalesVisibility()
        {

            btnGastosAdic.Visible = CurrentUserID.CurrentParameters.IMANEJAGASTOSADIC == "S";
            TBGastosAdic.Visible = CurrentUserID.CurrentParameters.IMANEJAGASTOSADIC == "S";
        }


        private bool bEstaConfiguradoParaPiezasyCajas()
        {
            return (CurrentUserID.CurrentParameters.ICAJASBOTELLAS.Equals("S") && CurrentUserID.CurrentUser.ICAJASBOTELLAS.Equals("S"));
        }

        private void formatCajasBotellasPiezasPorParametro()
        {
            if (bEstaConfiguradoParaPiezasyCajas())
            {
                formatCajasBotellasPiezas(true);

            }
            else
            {
                formatCajasBotellasPiezas(false);
            }
        }

        private void formatCajasBotellasPiezas(bool cajasYBotellas)
        {
            if (cajasYBotellas)
            {
                m_CommandLineWidth = 210;
                TBCommandLine.Width = 210;
                TBCajas.Visible = true;
                lblCajas.Visible = true;
                lblCantidad.Text = "Botellas";
                TBCajas.Text = "0";
                TBCantidad.Text = "0";



            }
            else
            {
                m_CommandLineWidth = 290;
                TBCommandLine.Width = 290;
                TBCajas.Visible = false;
                lblCajas.Visible = false;
                lblCantidad.Text = "Cantidad";
                TBCajas.Text = "0";
                TBCantidad.Text = "1";
            }

        }



        public void SetDefaultAlmacenEstatus()
        {


            if (!(bool)CurrentUserID.CurrentUser.isnull["IALMACENID"])
                this.ALMACENComboBox.SelectedDataValue = CurrentUserID.CurrentUser.IALMACENID;
            else
                this.ALMACENComboBox.SelectedDataValue = DBValues._ALMACEN_DEFAULT;

            if (m_usuarioPuedeCambiarAlmacen)
                this.ALMACENComboBox.Enabled = true;
            else
                this.ALMACENComboBox.Enabled = false;

        }

        private void WFPuntoDeTransaccion_Shown(object sender, EventArgs e)
        {
            this.TBCommandLine.Focus();
        }


        public void FormatGrid()
        {

            this.gridPVDataGridView.BackgroundColor = Color.White;
            this.gridPVDataGridView.DefaultCellStyle.BackColor = Color.White;
        }


        private void RefrescarGridTransaccions()
        {
            this.gridPVTableAdapter.Fill(this.dSEntradas.GridPV, (int)m_Docto.IID);
            FormatGrid();

            if (gridPVDataGridView.Rows.Count > 0)
                gridPVDataGridView.CurrentCell = gridPVDataGridView.Rows[gridPVDataGridView.Rows.Count - 1].Cells["GVCANTIDAD"];


            GetTotalesPagosTransaccion();
            RefreshTotalesTransaccion();

            if (CBMostrarUSD.Checked)
            {
                GetTotalesPagosUSD();
                RefreshTotalesTransaccionUSD();
            }

            RefreshNumTransaccion();
            RefrescarTotalPiezas();
        }



        private void RefrescarTotalPiezas()
        {
            if ((bool)CurrentUserID.CurrentParameters.isnull["IIMPRIMIRNUMEROPIEZAS"])
            {
                return;
            }
            if (CurrentUserID.CurrentParameters.IIMPRIMIRNUMEROPIEZAS.Equals("N"))
            {
                return;
            }

            decimal totalpiezas = 0;

            foreach (Entradas.DSEntradas.GridPVRow dr in this.dSEntradas.GridPV.Rows)
            {
                if (dr.IsCANTIDADNull())
                    continue;

                totalpiezas += dr.CANTIDAD;
            }

            this.lbTotalPiezas.Text = totalpiezas.ToString("N2");
        }

        private void FormatTotalPiezas()
        {

            if ((bool)CurrentUserID.CurrentParameters.isnull["IIMPRIMIRNUMEROPIEZAS"])
            {
                lblEtiquetaTotPzas.Visible = false;
                lbTotalPiezas.Visible = false;
                return;
            }

            if (CurrentUserID.CurrentParameters.IIMPRIMIRNUMEROPIEZAS.Equals("N"))
            {
                lblEtiquetaTotPzas.Visible = false;
                lbTotalPiezas.Visible = false;
                return;
            }

            lblEtiquetaTotPzas.Visible = true;
            lbTotalPiezas.Visible = true;
        }


        public void LimpiarTotalesPagosTransaccion()
        {
            m_dMontoTransaccion = 0;
            m_dSumaImporte = 0;
            m_dMontoIva = 0;
            m_dDescuento = 0;
            m_dGastosAdic = 0;
        }


        public void LimpiarTotalesPagosTransaccionUSD()
        {
            m_dMontoTransaccionUSD = 0;
        }


        public void RefreshTotalesTransaccion()
        {
            this.TBPagosTotalTransaccionBig.Text = m_dMontoTransaccion.ToString("N2");
            this.TBTotal.Text = m_dMontoTransaccion.ToString("N2");
            this.TBSumaTotal.Text = m_dSumaImporte.ToString("N2");
            this.TBIva.Text = m_dMontoIva.ToString("N2");
            this.TBGastosAdic.Text = m_dGastosAdic.ToString("N2");
        }


        public void RefreshTotalesTransaccionUSD()
        {
            this.TBUSDTotal.Text = m_dMontoTransaccionUSD.ToString("N3");
        }


        public void VisibilidadUSDInfo(bool bVisibilidad)
        {

            this.TBUSDTotal.Visible = bVisibilidad;
            lblEtiquetaTotalUSD.Visible = bVisibilidad;


            gridPVDataGridView.Columns["DGCOSTOENDOLAR"].Visible = bVisibilidad;
            gridPVDataGridView.Columns["DGCOSTOENDOLAR"].ReadOnly = !bVisibilidad;
            gridPVDataGridView.Columns["DGIMPORTEENDOLAR"].Visible = bVisibilidad;
            gridPVDataGridView.Columns["dESCRIPCIONDataGridViewTextBoxColumn1"].Width = bVisibilidad ? 250 : 450;

            
        }


        public void RefreshNumTransaccion()
        {
            if (this.m_Docto != null)
            {
                if (!(bool)this.m_Docto.isnull["IFOLIO"])
                {
                    this.LBTransaccion.Text = m_Docto.IFOLIO.ToString();
                }
                else
                {
                    this.LBTransaccion.Text = "...";
                }
            }
            else
            {
                this.LBTransaccion.Text = "...";
            }
        }



        private void RefreshCurrentItemDisplay(int iRowIndex)
        {
            LimpiarCurrentItemDisplay();
            if (this.gridPVDataGridView.Rows[iRowIndex].Cells["DESCRIPCION2"].Value != null && this.gridPVDataGridView.Rows[iRowIndex].Cells["DESCRIPCION2"].Value.ToString() != "")
                this.tbCurrentItem.Text += this.gridPVDataGridView.Rows[iRowIndex].Cells["DESCRIPCION2"].Value.ToString();


            if (this.gridPVDataGridView.Rows[iRowIndex].Cells["LOTE"].Value != null && this.gridPVDataGridView.Rows[iRowIndex].Cells["DESCRIPCION2"].Value.ToString() != "")
                this.tbCurrentItem.Text += this.gridPVDataGridView.Rows[iRowIndex].Cells["LOTE"].Value.ToString();

            if (this.gridPVDataGridView.Rows[iRowIndex].Cells["TEXTO1"].Value != null &&
                this.gridPVDataGridView.Rows[iRowIndex].Cells["TEXTO1"].Value.ToString() != "" &&
                 !(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO1"] &&
                !CurrentUserID.CurrentParameters.ITEXTO1.Trim().Equals(""))
                this.tbCurrentItem.Text += " " + CurrentUserID.CurrentParameters.ITEXTO1 + " : " + this.gridPVDataGridView.Rows[iRowIndex].Cells["TEXTO1"].Value.ToString();


            if (this.gridPVDataGridView.Rows[iRowIndex].Cells["TEXTO2"].Value != null &&
                this.gridPVDataGridView.Rows[iRowIndex].Cells["TEXTO2"].Value.ToString() != "" &&
                 !(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO2"] &&
                !CurrentUserID.CurrentParameters.ITEXTO2.Trim().Equals(""))
                this.tbCurrentItem.Text += " " + CurrentUserID.CurrentParameters.ITEXTO2 + " : " + this.gridPVDataGridView.Rows[iRowIndex].Cells["TEXTO2"].Value.ToString();



            if (this.gridPVDataGridView.Rows[iRowIndex].Cells["TEXTO3"].Value != null &&
                this.gridPVDataGridView.Rows[iRowIndex].Cells["TEXTO3"].Value.ToString() != "" &&
                 !(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO3"] &&
                !CurrentUserID.CurrentParameters.ITEXTO3.Trim().Equals(""))
                this.tbCurrentItem.Text += " " + CurrentUserID.CurrentParameters.ITEXTO3 + " : " + this.gridPVDataGridView.Rows[iRowIndex].Cells["TEXTO3"].Value.ToString();


            if (this.gridPVDataGridView.Rows[iRowIndex].Cells["TEXTO4"].Value != null &&
                this.gridPVDataGridView.Rows[iRowIndex].Cells["TEXTO4"].Value.ToString() != "" &&
                 !(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO4"] &&
                !CurrentUserID.CurrentParameters.ITEXTO4.Trim().Equals(""))
                this.tbCurrentItem.Text += " " + CurrentUserID.CurrentParameters.ITEXTO4 + " " + this.gridPVDataGridView.Rows[iRowIndex].Cells["TEXTO4"].Value.ToString();

            if (this.gridPVDataGridView.Rows[iRowIndex].Cells["TEXTO5"].Value != null &&
                this.gridPVDataGridView.Rows[iRowIndex].Cells["TEXTO5"].Value.ToString() != "" &&
                 !(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO5"] &&
                !CurrentUserID.CurrentParameters.ITEXTO5.Trim().Equals(""))
                this.tbCurrentItem.Text += " " + CurrentUserID.CurrentParameters.ITEXTO5 + " " + this.gridPVDataGridView.Rows[iRowIndex].Cells["TEXTO5"].Value.ToString();


            if (this.gridPVDataGridView.Rows[iRowIndex].Cells["TEXTO6"].Value != null &&
                this.gridPVDataGridView.Rows[iRowIndex].Cells["TEXTO6"].Value.ToString() != "" &&
                 !(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO6"] &&
                !CurrentUserID.CurrentParameters.ITEXTO6.Trim().Equals(""))
                this.tbCurrentItem.Text += " " + CurrentUserID.CurrentParameters.ITEXTO6 + " " + this.gridPVDataGridView.Rows[iRowIndex].Cells["TEXTO6"].Value.ToString();


            if (this.gridPVDataGridView.Rows[iRowIndex].Cells["NUMERO1"].Value != null &&
                this.gridPVDataGridView.Rows[iRowIndex].Cells["NUMERO1"].Value.ToString() != "" &&
                 !(bool)CurrentUserID.CurrentParameters.isnull["INUMERO1"] &&
                !CurrentUserID.CurrentParameters.INUMERO1.Trim().Equals(""))
                this.tbCurrentItem.Text += " " + CurrentUserID.CurrentParameters.INUMERO1 + " " + this.gridPVDataGridView.Rows[iRowIndex].Cells["NUMERO1"].Value.ToString();


            if (this.gridPVDataGridView.Rows[iRowIndex].Cells["NUMERO2"].Value != null &&
                this.gridPVDataGridView.Rows[iRowIndex].Cells["NUMERO2"].Value.ToString() != "" &&
                 !(bool)CurrentUserID.CurrentParameters.isnull["INUMERO2"] &&
                !CurrentUserID.CurrentParameters.INUMERO2.Trim().Equals(""))
                this.tbCurrentItem.Text += " " + CurrentUserID.CurrentParameters.INUMERO2 + " " + this.gridPVDataGridView.Rows[iRowIndex].Cells["NUMERO2"].Value.ToString();


            if (this.gridPVDataGridView.Rows[iRowIndex].Cells["NUMERO3"].Value != null &&
                this.gridPVDataGridView.Rows[iRowIndex].Cells["NUMERO3"].Value.ToString() != "" &&
                 !(bool)CurrentUserID.CurrentParameters.isnull["INUMERO3"] &&
                !CurrentUserID.CurrentParameters.INUMERO3.Trim().Equals(""))
                this.tbCurrentItem.Text += " " + CurrentUserID.CurrentParameters.INUMERO3 + " " + this.gridPVDataGridView.Rows[iRowIndex].Cells["NUMERO3"].Value.ToString();


            if (this.gridPVDataGridView.Rows[iRowIndex].Cells["NUMERO4"].Value != null &&
                this.gridPVDataGridView.Rows[iRowIndex].Cells["NUMERO4"].Value.ToString() != "" &&
                 !(bool)CurrentUserID.CurrentParameters.isnull["INUMERO4"] &&
                !CurrentUserID.CurrentParameters.INUMERO4.Trim().Equals(""))
                this.tbCurrentItem.Text += " " + CurrentUserID.CurrentParameters.INUMERO4 + " " + this.gridPVDataGridView.Rows[iRowIndex].Cells["NUMERO4"].Value.ToString();


        }

        private void gridPVDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            RefreshCurrentItemDisplay(e.RowIndex);
        }


        private void LimpiarCurrentItemDisplay()
        {
            this.tbCurrentItem.Text = "";
        }


        private void RefrescarEstatusBotones()
        {
            if (!(bool)m_Docto.isnull["IID"] && gridPVDataGridView.Rows.Count > 0)
            {
                this.BTPasarANueva.Enabled = true;
                this.BTCancelarTransaccion.Enabled = true;
                this.BTCerrarTransaccion.Enabled = true;

            }
            else
            {
                this.BTPasarANueva.Enabled = false;
                //this.BTCancelarTransaccion.Enabled = false;
                this.BTCancelarTransaccion.Enabled = true;
                this.BTCerrarTransaccion.Enabled = false;
            }

            if (gridPVDataGridView.Rows.Count > 0)
                this.BTEliminarDetalle.Enabled = true;
            else
                this.BTEliminarDetalle.Enabled = false;



            btnGastosAdic.Visible = CurrentUserID.CurrentParameters.IMANEJAGASTOSADIC == "S" && m_usuarioPuedeCambiarGastosAdic && m_Docto != null  && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA;
            TBGastosAdic.Visible = CurrentUserID.CurrentParameters.IMANEJAGASTOSADIC == "S" && m_usuarioPuedeCambiarGastosAdic && m_Docto != null && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA;


            btnImportar.Visible = m_usuarioPuedeImportarCompras && m_Docto != null  && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA;
        }

        #endregion

        #region Seguridad y Validaciones Iniciales
        public bool ChecarFechaDelSistema()
        {

            CComprasD pvd = new CComprasD();
            if (!pvd.ValidarFechaSistema(null))
            {
                MessageBox.Show(pvd.IComentario);
                m_bSalirSinPreguntar = true;
                this.Close();
                return false;
            }
            return true;
        }



        private bool ChecarPermisos()
        {

            CPERSONAD personaD = new CPERSONAD();
            int iMenu = int.Parse(DBValues._MENUID_COMPRA.ToString());
            if (!personaD.UsuarioTieneDerechoAMenu(CurrentUserID.CurrentUser.IID, iMenu, null))
            {
                MessageBox.Show("El usuario no tiene derecho a este form");
                return false;
            }
            return true;
        }

        private void ChecarActualizacionesPrecios()
        {

            //checar si hay surtidos pendientes y este usuario es el encargado de surtirlos, para avisarle
            if (CurrentUserID.CurrentParameters.IHABSURTIDOPOSTPUESTO == null || !CurrentUserID.CurrentParameters.IHABSURTIDOPOSTPUESTO.Equals("S"))
            {
                CPERSONAD personaD = new CPERSONAD();
                int iMenu = int.Parse(DBValues._MENUID_AVISOSURTIRPEDIDO_MOVIL.ToString());
                if (personaD.UsuarioTieneDerechoAMenu(CurrentUserID.CurrentUser.IID, iMenu, null))
                {
                    if (CurrentUserID.CurrentParameters.IMOVILPROCESOSURTIDO == "N" && (CurrentUserID.CurrentParameters.IHABSURTIDOPOSTPUESTO == null || !CurrentUserID.CurrentParameters.IHABSURTIDOPOSTPUESTO.Equals("S")))
                    {

                        if (MessageBox.Show("Hay surtidos de pedidos de vendedor movil pendientes, ¿Quiere marcarlos como 'en proceso de surtido' antes de continuar", "Surtidos moviles pendientes", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            WFSurtidoVentasMoviles impo = new WFSurtidoVentasMoviles();
                            impo.ShowDialog();
                            impo.Dispose();
                            GC.SuppressFinalize(impo);
                        }
                    }
                }
            }

            if(CurrentUserID.CurrentParameters.IHABILITAR_IMPEXP_AUT == DBValues._DB_BOOLVALUE_SI)
            {
                CIMP_FILESD impFiles = new CIMP_FILESD();
                if (impFiles.HayImportacionesPendientes(0))
                {
                    if (MessageBox.Show("Hay importaciones pendientes, ¿Quiere realizar las importaciones antes de continuar", "Importaciones Pendientes", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        WFImportar impo = new WFImportar();
                        impo.ShowDialog();
                        impo.Dispose();
                        GC.SuppressFinalize(impo);
                    }
                }



                CPRECIOSTEMPD tempD = new CPRECIOSTEMPD();
                int iCuentaPreciosTemp = tempD.HAYPRECIOSTEMP(null);


                if (impFiles.HayImportacionesPendientes(21) || iCuentaPreciosTemp > 0)
                {
                    if (MessageBox.Show("Hay precios temporales a etiquetar y aplicar, ¿Quiere realizar el proceso antes de continuar?", "Precios temporales pendientes", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        WFPreciosTemp impo = new WFPreciosTemp();
                        impo.ShowDialog();
                        impo.Dispose();
                        GC.SuppressFinalize(impo);
                    }
                }
            }

        }




        private void ChecarCorteActivo()
        {
            CComprasD pvd = new CComprasD();
            CorteAbrir corteForm;
            DateTime fechaCorte = DateTime.MinValue;
            if (!pvd.HayCorteActivo(ref fechaCorte, iPos.CurrentUserID.CurrentUser.IID))
            {
                corteForm = new CorteAbrir();
                corteForm.ShowDialog();
                corteForm.Dispose();
                GC.SuppressFinalize(corteForm);
            }
            else
            {
                TimeSpan ts = DateTime.Now - fechaCorte/*((fechaCorte == null) ? DateTime.MinValue : fechaCorte)*/;
                if (fechaCorte != null && fechaCorte < DateTime.Today && ts.Hours > 6)
                {

                    MessageBox.Show("Se tiene abierto un corte de una fecha pasada porfavor cierrelo antes de continuar");
                    CorteCerrar cc2 = new CorteCerrar();
                    cc2.ShowDialog();
                    bool bCorteCerrado = cc2.m_bCorteCerrado;
                    cc2.Dispose();
                    GC.SuppressFinalize(cc2);

                    if (!bCorteCerrado)
                    {
                        m_bSalirSinPreguntar = true;
                        this.Close();
                    }
                    else
                    {
                        corteForm = new CorteAbrir();
                        corteForm.ShowDialog();
                        corteForm.Dispose();
                        GC.SuppressFinalize(corteForm);
                    }
                }
                else
                    return;
            }


            if (!pvd.HayCorteActivo(ref fechaCorte, iPos.CurrentUserID.CurrentUser.IID))
            {
                this.Close();
            }
            else
            {
                TimeSpan ts = DateTime.Now - fechaCorte/*((fechaCorte == null) ? DateTime.MinValue : fechaCorte)*/;
                if (fechaCorte != null && fechaCorte < DateTime.Today && ts.Hours > 6)
                    MessageBox.Show("Se tiene abierto un corte de una fecha pasada porfavor cierrelo antes de continuar");

            }

        }

        #endregion

        #region Funciones para obtener datos de la base de datos
        private void ObtenerDoctoDeBD(long lDoctoID)
        {
            CDOCTOD vDocto = new CDOCTOD();
            m_Docto = new CDOCTOBE();
            m_Docto.IID = lDoctoID;
            m_Docto = vDocto.seleccionarDOCTO(m_Docto, null);
        }

        public void GetTotalesPagosTransaccion()
        {

            if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_REC  ||
                (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA && m_Docto.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_COMPRAIMPORTADA) ||
                m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO_DEVO ||
                m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_PEDIDO_ENVIO_DEVO)
            {
                 GetTotalesPagosRecepcionCompraTraspaso();
                 return;
            }
                

            CComprasD pvd = new CComprasD();
            CDOCTOBE doctoBuffer = pvd.ObtenerTransaccion(m_Docto, null);

            if (pvd.IComentario == "" || pvd.IComentario == null)
            {
                m_Docto = doctoBuffer;
                m_dGastosAdic = GetGastosAdicDocto();
                m_dMontoTransaccion = m_Docto.ITOTAL + m_dGastosAdic;
                m_dSumaImporte = m_Docto.ISUBTOTAL + m_Docto.IIEPS;
                m_dMontoIva = m_Docto.IIVA;
                m_dDescuento = m_Docto.IDESCUENTO;
               
            }
            else
            {
                MessageBox.Show("ERRORES: " + pvd.IComentario.Replace("%", "\n"));
                LimpiarTotalesPagosTransaccion();
            }


        }

        public decimal GetGastosAdicDocto()
        {
            if(m_Docto != null && m_Docto.IID > 0 && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA && m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_BORRADOR)
            {
                CDOCTOD doctoD = new CDOCTOD();
                return doctoD.GetSumaGastosAdic(m_Docto, null);
            }
            else
            {
                return 0;
            }
        }


        public void GetTotalesPagosRecepcionCompraTraspaso()
        {
            try
            {
                m_dMontoTransaccion = 0;
                m_dSumaImporte = 0;
                m_dMontoIva = 0;
                m_dDescuento = 0;
                m_dGastosAdic = 0;
                foreach (iPos.Entradas.DSEntradas.GridPVRow dr in dSEntradas.GridPV.Rows)
                {
                    m_dSumaImporte += dr.SUBTOTAL + dr.IEPS;
                    m_dDescuento += dr.DESCUENTO;
                    m_dMontoIva += dr.IVA;
                    m_dMontoTransaccion += dr.TOTAL;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERRORES: " + ex.Message);
                LimpiarTotalesPagosTransaccion();
            }
                
        }


        public void GetTotalesPagosUSD()
        {
            try
            {
                m_dMontoTransaccionUSD = 0;


                if (m_Docto == null || m_Docto.IID == 0)
                    return;


                CDOCTOD doctoD = new CDOCTOD();
                doctoD.DOCTO_GET_TOTALESUSD(m_Docto,  ref m_dMontoTransaccionUSD, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRORES: " + ex.Message);
                LimpiarTotalesPagosTransaccionUSD();
            }

        }


        private CSUCURSALBE DatosSucursalDestino()
        {

            CSUCURSALD sucursalD = new CSUCURSALD();
            CSUCURSALBE sucursalBE = new CSUCURSALBE();

            sucursalBE.IID = m_sucursalTID;
            sucursalBE = sucursalD.seleccionarSUCURSAL(sucursalBE, null);

            return sucursalBE;

        }

        private void ObtenerCaja()
        {
            CComprasD pvd = new CComprasD();
            m_Caja = pvd.ObtenerDatosCaja(iPos.CurrentUserID.CurrentCompania.IEM_CAJA);
        }



        #endregion


        #region Operaciones
        #region LInea de comando

        public ArrayList SplitCommandLine(string commandLine, ArrayList splitChars)
        {
            ArrayList commandElemts = new ArrayList();
            PVCommandElement elemInicial;
            elemInicial.commandText = commandLine;
            elemInicial.commandOper = ' ';
            commandElemts.Add(elemInicial);
            foreach (Object objSep in splitChars)
            {
                char[] cSep = new char[1];
                cSep[0] = (char)objSep;
                ArrayList BufferArr = new ArrayList();
                foreach (Object objComm in commandElemts)
                {
                    PVCommandElement pvComm = (PVCommandElement)objComm;

                    string[] splittedComm = pvComm.commandText.Split(cSep, StringSplitOptions.RemoveEmptyEntries);
                    int numSplittedStr = splittedComm.Count();
                    for (int iSplitIndex = 0; iSplitIndex < numSplittedStr; iSplitIndex++)
                    {
                        PVCommandElement bufferElem;
                        bufferElem.commandText = splittedComm[iSplitIndex];
                        if (iSplitIndex == 0)
                        {
                            bufferElem.commandOper = pvComm.commandOper;
                        }
                        else
                        {
                            bufferElem.commandOper = cSep[0];
                        }
                        BufferArr.Add(bufferElem);
                    }
                }
                commandElemts.Clear();
                commandElemts = (ArrayList)BufferArr.Clone();
            }
            return commandElemts;
        }
        private void BTSendCommand_Click(object sender, EventArgs e)
        {
            ProcessCommand();
        }






        private void DecifrarComando(string texto, ref CPRODUCTOBE prod, ref Decimal cantidad, ref CComprasD pvd, ref Decimal costo, ref Decimal descuento)
        {


            //bool bLastAssigned = false; // ultima busqueda

            string bufferBusquedaText = texto;
            if (bufferBusquedaText.Contains(" <(("))
            {
                string[] strSeparators = new string[] { " <((" };


                string[] strBuffert = bufferBusquedaText.Split(strSeparators, StringSplitOptions.RemoveEmptyEntries);
                if (strBuffert.Count() > 1)
                {

                    //ultima busqueda
                    //bLastAssigned = true;

                    bufferBusquedaText = strBuffert[strBuffert.Count() - 1];


                    string[] strSeparatorsBeta = new string[] { "))>" };

                    string[] strBufferz = bufferBusquedaText.Split(strSeparatorsBeta, StringSplitOptions.RemoveEmptyEntries);
                    if (strBufferz.Count() > 0)
                        bufferBusquedaText = strBufferz[0];

                    if (bufferBusquedaText.Trim().Length > 0)
                        texto = bufferBusquedaText.Trim();
                }

            }


            //ArrayList splitChars = new ArrayList();
            //splitChars.Add('*');
            //splitChars.Add('%');
            //string commandLine = texto;
            //ArrayList commandElemts = SplitCommandLine(commandLine, splitChars);
            //int prodIndex = -1, cantIndex = -1, /*descIndex = -1,*/ contIndex;

            //contIndex = 0;

            BuscarProducto(ref prod);

            costo = Decimal.Parse(this.TBCosto.Text.ToString());
            cantidad = Decimal.Parse(this.TBCantidad.Text.ToString());


            if ( prod != null && bEstaConfiguradoParaPiezasyCajas())
            {
                Decimal cajas = Decimal.Parse(this.TBCajas.Text.ToString());
                cantidad =cantidad + (cajas * (prod.IPZACAJA == 0 ? 1 : prod.IPZACAJA));
            }


            descuento = Decimal.Parse(this.TBDescuento.Text.ToString());


            /*foreach (Object objComm in commandElemts)
            {
                contIndex++;
                PVCommandElement pvComm = (PVCommandElement)objComm;
                if (pvComm.commandOper == '*' || pvComm.commandOper == ' ')
                {
                    prod = pvd.buscarPRODUCTOSPV(pvComm.commandText, null);
                    if (prod != null)
                    {
                        prodIndex = contIndex;
                        break;
                    }
                }

            }

            contIndex = 0;
            foreach (Object objComm in commandElemts)
            {
                contIndex++;
                if (contIndex == prodIndex)
                {
                    continue;
                }
                PVCommandElement pvComm = (PVCommandElement)objComm;
                if (pvComm.commandOper == '*' || pvComm.commandOper == ' ')
                {
                    Decimal buffCant;
                    if (Decimal.TryParse(pvComm.commandText, out buffCant))
                    {
                        cantidad = buffCant;
                        cantIndex = contIndex;
                        break;
                    }
                }

            }*/
        }





        private void SeleccionarSubProducto(long productoIdPadre, string strDescripcion)
        {

            WFSubProductos look;
            //if (strDescripcion == "")
            look = new WFSubProductos(productoIdPadre, "");
            //else
            //    look = new WFSubProductos(productoIdPadre, strDescripcion);
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                this.TBCommandLine.Text = dr["CLAVE"].ToString().Trim();
                TBCommandLine.Focus();
                TBCommandLine.Select(TBCommandLine.Text.Length, 0);
                //ProcessCommand();
            }
        }




        private bool ProcessCommand()
        {
            long? P_MOVTOID = null;
            return ProcessCommand(ref P_MOVTOID, null);
        }

        private bool ProcessCommand(ref long? P_MOVTOID, long? PREV_LOTEIMPORTADO)
        {
            return ProcessCommand(ref P_MOVTOID, PREV_LOTEIMPORTADO, null, null);
        }

        private bool ProcessCommand(ref long? P_MOVTOID, long? PREV_LOTEIMPORTADO, string strLoteParam, DateTime? fechaVenceParam)
        {

            if (m_manejaAlmacen)
            {
                if (this.ALMACENComboBox.SelectedIndex < 0)
                {
                    MessageBox.Show("por favor seleccione un almacen valido de la lista ");
                    return false;
                }
            }

            //if (this.PROVEEDORIDTextBox.Text == "")
            if(TBPROVEEDOR.Text == "")
            {
                MessageBox.Show("por favor seleccione un proveedor valido de la lista ");
                return false;
            }
            long proveedorId = this.m_iProveedorId;//long.Parse(this.PROVEEDORIDTextBox.DbValue.ToString());
            if (proveedorId <= 0)
            {
                MessageBox.Show("por favor seleccione un proveedor valido de la lista ");
                return false;
            }

            /*
            if (this.ComboProveedor.SelectedValue == null)
            {
                MessageBox.Show("por favor seleccione un proveedor valido de la lista ");
                return false;
            }*/

            CPRODUCTOBE prod = null;

            long? P_IDDOCTO = null;
            decimal? P_CANTIDAD = null;
            long? P_IDPRODUCTO = null;
            long? P_PERSONAID = proveedorId/*long.Parse(this.ComboProveedor.SelectedValue.ToString())*/;
            string P_LOTE = "";
            long? P_USERID = iPos.CurrentUserID.CurrentUser.IID;
            int? US_SUPERVISORID = null;
            int? ALMACENID = m_manejaAlmacen ? int.Parse(this.ALMACENComboBox.SelectedValue.ToString()) : (int)DBValues._DOCTO_ALMACEN_DEFAULT;/*CurrentUserID.CurrentUser.IUS_ALMACENID*/ ;
            long? SUCURSALID = CurrentUserID.CurrentParameters.ISUCURSALID;
            decimal? P_COSTO = null;
            decimal? P_DESCUENTO = null;
            DateTime P_FECHAVENCE = DateTime.MinValue;
            Decimal cantidad = 0;
            long? SUCURSALTID = 0;
            long? ALMACENTID = 0;

            Decimal costo = 0;
            Decimal descuento = 0;
            string P_REFERENCIA = TBReferencias.Text;
            string P_REFERENCIAS = TBObservaciones.Text;
            DateTime P_DOCTO_FECHA = DTPFecha.Value;
            DateTime P_DOCTO_FECHAVENCE = DTPFechaVence.Value;

            long? P_TIPODIFERENCIAINVENTARIOID = 0;

            long? P_MOVTOREFID = null;

            string strDescripcionComodin1 = "", strDescripcionComodin2 = "", strDescripcionComodin3 = "";
            bool bHayDescripcionComodin = false;

            long? P_LOTEIMPORTADO = null;
            bool bActualizarLoteImportadoEnDocto = false;

            bool bResult = true;
            long? P_DOCTOREFID = null;
            if (this.m_DoctoRef != null)
            {
                P_DOCTOREFID = this.m_DoctoRef.IID;
            }


            if (this.TBReferencias.Text == "" && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA)
            {
                MessageBox.Show("Porfavor llena el campo de referencia");
                this.TBReferencias.Focus();
                return false;
            }


            CComprasD pvd = new CComprasD();
            if (TBCommandLine.Text == "")
            {
                SeleccionarProducto();
                RefrescarEstatusBotones();
                return false;
            }

            DecifrarComando(TBCommandLine.Text, ref prod, ref  cantidad, ref pvd, ref costo, ref descuento);
            //P_CANTIDAD = (cantidad != 0) ? cantidad : 1;
            P_CANTIDAD = (cantidad != 0 || (P_MOVTOID.HasValue && P_MOVTOID.Value != 0)) ? cantidad : 1;
            P_COSTO = (costo == 0) ? (decimal)-0.01 : costo;
            P_DESCUENTO = descuento;

            if (!(bool)this.m_Docto.isnull["IID"])
            {
                P_IDDOCTO = m_Docto.IID;
            }
            if (prod != null)
            {
                P_IDPRODUCTO = prod.IID;
            }


            if (m_sucursalTID != 0)
                SUCURSALTID = m_sucursalTID;



            if (!(bool)prod.isnull["IDESCRIPCION_COMODIN"] && prod.IDESCRIPCION_COMODIN.Equals("S"))
            {

                DescripcionesDeProductoEnDataSet(prod.IID, ref strDescripcionComodin1, ref strDescripcionComodin2, ref strDescripcionComodin3);

                WFDescripcionComodin wfcom = new WFDescripcionComodin(strDescripcionComodin1, strDescripcionComodin2, strDescripcionComodin3);
                wfcom.ShowDialog();

                bHayDescripcionComodin = !wfcom.m_bCancelado;


                if (bHayDescripcionComodin)
                {
                    strDescripcionComodin1 = wfcom.m_descripcion1;
                    strDescripcionComodin2 = wfcom.m_descripcion2;
                    strDescripcionComodin3 = wfcom.m_descripcion3;
                }
                wfcom.Dispose();
                GC.SuppressFinalize(wfcom);
            }



            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            if (P_IDPRODUCTO == null)
            {
                SeleccionarProducto(TBCommandLine.Text);
                RefrescarEstatusBotones();
                return false;
            }


            if (prod.IESPRODUCTOPADRE == "S")
            {
                SeleccionarSubProducto(prod.IID, TBCommandLine.Text);
                return false;
            }


            if (prod.IMANEJALOTE == "S" && m_Docto.ITIPODOCTOID != DBValues._DOCTO_TIPO_ORDEN_COMPRA)
            {
                //condiciones para preguntar lote
                //int num_registros_inv = 0;
                //decimal cantidad_inv = 0;
                //string lote_inv = "";
                DateTime fechaVence = DateTime.MinValue;

                //pvd.GetExistencia(prod, ref num_registros_inv, ref cantidad_inv, ref lote_inv, ref fechaVence, null);
                //if (num_registros_inv > 1)
                //{


                if (strLoteParam != null && strLoteParam.Trim().Length > 0 && fechaVenceParam.HasValue)
                {

                    P_LOTE = strLoteParam;
                    P_FECHAVENCE = fechaVenceParam.Value;
                }
                else
                {
                    WFDefineLote pl_ = new WFDefineLote();
                    pl_.ShowDialog();
                    string lote = pl_.m_lote;
                    DateTime fechaVence_ = pl_.m_fechaVence;
                    pl_.Dispose();
                    GC.SuppressFinalize(pl_);

                    if (lote == null || lote.Trim().Length == 0)
                    {
                        MessageBox.Show("Debe definir un lote");
                        return false;
                    }

                    P_LOTE = lote;
                    P_FECHAVENCE = fechaVence_;
                }


                /*}
                else if (num_registros_inv == 1)
                {
                    P_LOTE = lote_inv;
                    P_FECHAVENCE = fechaVence;

                }*/
            }

            if(CurrentUserID.CurrentParameters.IMANEJARLOTEIMPORTACION == "S" && prod.IMANEJALOTEIMPORTADO == "S" )
            {

                if (m_proveedorEsImportador != "S")
                {
                    MessageBox.Show("No puede agregar productos que manejan lote de importacion si no es importador");
                    return false;
                }

                if (m_Docto.ITIPODOCTOID != DBValues._DOCTO_TIPO_ORDEN_COMPRA)
                {


                    if (m_Docto != null && m_Docto.ILOTEIMPORTADO > 0)
                    {
                        P_LOTEIMPORTADO = m_Docto.ILOTEIMPORTADO;
                    }
                    else if(PREV_LOTEIMPORTADO != null && PREV_LOTEIMPORTADO > 0)
                    {
                        P_LOTEIMPORTADO = PREV_LOTEIMPORTADO;
                        bActualizarLoteImportadoEnDocto = true;
                    }
                    else
                    {

                        WFDefineLoteImportado pl_ = new WFDefineLoteImportado();
                        pl_.ShowDialog();
                        CLOTESIMPORTADOSBE loteImportado = pl_.loteImportado;
                        pl_.Dispose();
                        GC.SuppressFinalize(pl_);

                        if (loteImportado == null || loteImportado.IID == 0)
                        {
                            MessageBox.Show("Debe definir un lote o pedimento de importacion");
                            return false;
                        }

                        P_LOTEIMPORTADO = loteImportado.IID;
                        bActualizarLoteImportadoEnDocto = true;
                    }
                }
            }

            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();

                if (pvd.EjecutarAddMOVTO(ref P_IDDOCTO, P_CANTIDAD, P_IDPRODUCTO, P_PERSONAID, P_USERID, P_LOTE, US_SUPERVISORID, ALMACENID, SUCURSALID, P_FECHAVENCE, m_Docto.ITIPODOCTOID, SUCURSALTID, ALMACENTID, "N", P_TIPODIFERENCIAINVENTARIOID, P_COSTO, P_REFERENCIA, P_REFERENCIAS, P_DOCTO_FECHA, P_DOCTO_FECHAVENCE, P_DESCUENTO, iPos.CurrentUserID.CurrentCompania.IEM_CAJA, P_DOCTOREFID, ref P_MOVTOID, P_MOVTOREFID, P_LOTEIMPORTADO, strDescripcionComodin1, strDescripcionComodin2, strDescripcionComodin3, fTrans))
                {
                    fTrans.Commit();
                    fConn.Close();
                    
                    ObtenerDoctoDeBD((long)P_IDDOCTO);

                    RefrescarGridTransaccions();
                    FormatGrid();
                    GetTotalesPagosTransaccion();
                    RefreshTotalesTransaccion();

                    if(CBMostrarUSD.Checked)
                    {
                        GetTotalesPagosUSD();
                        RefreshTotalesTransaccionUSD();
                    }

                    RefreshNumTransaccion();
                    //TBMensajesUser.Text = "";//"Exito"
                    //TBMensajesUser.BackColor = Color.Green;
                    this.TBCommandLine.Text = "";
                    this.TBCantidad.Text = bEstaConfiguradoParaPiezasyCajas() ? "0" : "1";
                    this.TBCajas.Text = "";
                    this.TBCosto.Text = "";
                    this.TBDescuento.Text = "";
                    this.TBStatus.Text = "";

                    this.LBIva.Text = "0.0";

                    this.TBCommandLine.Focus();

                    if (m_manejaAlmacen)
                    {
                        this.ALMACENComboBox.Enabled = false;
                    }

                    //actualizar lote importado en docto
                    if (bActualizarLoteImportadoEnDocto && P_LOTEIMPORTADO != null && P_LOTEIMPORTADO.HasValue)
                    {
                        ActualizarLoteImportadoEnDoctoActual(P_LOTEIMPORTADO.Value);
                    }

                    //fConn.Close();

                }
                else
                {
                    bResult = false;
                    fTrans.Rollback();
                    fConn.Close();
                    MessageBox.Show(pvd.IComentario);
                    //TBMensajesUser.Text = pvd.IComentario;
                    //TBMensajesUser.BackColor = Color.Red;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                fConn.Close();
            }
            finally
            {
                fConn.Close();
            }
            RefrescarEstatusBotones();

            return bResult;
        }



        private bool ActualizarLoteImportadoEnDoctoActual(long loteImportado)
        {
            CDOCTOD doctoD = new CDOCTOD();
            m_Docto.ILOTEIMPORTADO = loteImportado;
            return doctoD.CambiarLoteImportadoDOCTOD(m_Docto, null);
        }

        private void TBCommandLine_KeyDown(object sender, KeyEventArgs e)
        {

            if (m_estadoTransaccion == (int)estadoTransaccion.e_Cerrada || m_estadoTransaccion == (int)estadoTransaccion.e_Cancelada)
                return;

            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                ProcessCommand();
            }
            if (Control.ModifierKeys == Keys.Control)
            {
                if (e.KeyCode == Keys.S)
                {
                    ProcessCommand();
                }
            }
        }

        #endregion

        #region Cancelaciones
        private void BTCancelarTransaccion_Click(object sender, EventArgs e)
        {
            CancelarTransaccionActual();
        }
        private bool CancelarTransaccionActual()
        {
            CComprasD pvd = new CComprasD();

            if (m_estadoTransaccion == (int)estadoTransaccion.e_Cancelada)
                return false;

            if ((bool)m_Docto.isnull["IID"])
                return false;

           if (MessageBox.Show("Quiere cancelar la transaccion actual?", "Cancelar la transaccion actual", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return false;
           

        
            if (m_estadoTransaccion != (int)estadoTransaccion.e_SinIniciar)
            {
                WFPreguntaAutorizacion ps2 = new WFPreguntaAutorizacion();
                ps2.ShowDialog();
                CPERSONABE userBE = ps2.m_userBE;
                bool bPassValido = ps2.m_bPassValido;
                bool bIsSupervisor = ps2.m_bIsSupervisor;
                bool bIsAdministrador = ps2.m_bIsAdministrador;
                ps2.Dispose();
                GC.SuppressFinalize(ps2);

                if (!bPassValido)
                  return false;

              if (!bIsSupervisor)
              {
                  MessageBox.Show("El usuario no es un supervisor");
                  return false;
              }

              if (bIsSupervisor && m_Docto.IFECHA < DateTime.Today.AddDays(-1) && !bIsAdministrador)
              {
                  MessageBox.Show("Un supervisor solo puede eliminar transaccions del dia actual y anterior. Se requiere un administrador para borrar de fechas previas");
                  return false;
              }
            }


            switch (m_Docto.ITIPODOCTOID)
            {

                case DBValues._DOCTO_TIPO_COMPRA:
                case DBValues._DOCTO_TIPO_ORDEN_COMPRA:
                case DBValues._DOCTO_TIPO_TRASPASO_REC:
                case DBValues._DOCTO_TIPO_PEDIDO_COMPRA:
                    {
                        long statusDoctoId = m_Docto.IESTATUSDOCTOID;



                        pvd.CancelarCompra(m_Docto, CurrentUserID.CurrentUser, null);
                        if (pvd.IComentario == "" || pvd.IComentario == null)
                        {

                            HiloExistencias._IFLAGENVIAREXISTENCIASEVENTOS++;
                            MessageBox.Show("Transaccion cancelada");

                            if (statusDoctoId != DBValues._DOCTO_ESTATUS_BORRADOR)
                            {
                                ImprimirTicketCompra(1);
                                //PosPrinter.ImprimirTicket(m_Docto.IID, Ticket._OPCION_IMPRESION_COMPRA, false, false, 1, CBMostrarUSD.Checked);
                            }

                            PreguntaComentarioCancelacion(m_Docto.IID, CurrentUserID.CurrentUser.IID, null);
                            IrANuevaTransaccion();
                        }
                        else
                        {
                            MessageBox.Show("ERRORES: " + pvd.IComentario.Replace("%", "\n"));
                            return false;
                        }
                    }
                    break;




                case DBValues._DOCTO_TIPO_COMPRA_DEVO:
                    {

                        long statusDoctoId = m_Docto.IESTATUSDOCTOID;
                        long doctoIDCancelacion = 0;
                        if (pvd.CancelarCompraDevolucion(m_Docto, CurrentUserID.CurrentUser, ref doctoIDCancelacion, null))
                        {


                            /*this.m_tipoTransaccion = tipoTransaccionV.t_compracancelaciondevolucion;
                            this.m_DoctoRef = this.m_Docto;

                            m_Docto = new CDOCTOBE();
                            m_Docto.IID = doctoIDCancelacion;
                            CDOCTOD vData = new CDOCTOD();
                            m_Docto = vData.seleccionarDOCTO(m_Docto, null);

                            WFPagosBasico wp = new WFPagosBasico(m_Docto, m_Caja, false, 0, this.m_DoctoRef, this.m_tipoTransaccion, "N",false);
                            wp.ShowDialog();
                            if (wp.m_bPagoCompleto)
                            {
                                CerrarTransaccion();
                            }*/
                            IrANuevaTransaccion();
                        }
                        else
                        {
                            MessageBox.Show("ERRORES: " + pvd.IComentario.Replace("%", "\n"));
                            return false;
                        }
                    }
                    break;
            }
            return true;
        }

        #endregion

        #region Nueva transaccion
        private void IrANuevaTransaccion()
        {
            ResetearVariablesForm();
            ChecarActualizacionesPrecios();
            LimpiarTotalesPagosTransaccion();
            LimpiarTotalesPagosTransaccionUSD();
            RefreshTotalesTransaccion();
            RefreshNumTransaccion();
            this.dSEntradas.GridPV.Clear();
            FormatGrid();
            this.dSEntradas.DETALLE_DE_PAGO.Clear();
            this.TBCommandLine.Text = "";
            this.TBCosto.Text = "";
            this.TBCantidad.Text = bEstaConfiguradoParaPiezasyCajas() ? "0" : "1";
            this.TBCajas.Text = "";
            this.TBDescuento.Text = "";
            this.TBReferencias.Text = "";
            this.TBObservaciones.Text = "";
            this.TBStatus.Text = "";

            this.LBIva.Text = "0.0";

            //this.TBMensajesUser.Text = "";
            //this.TBMensajesUser.BackColor = Color.Green;
            this.LBOperacion.Text = "Compra";
            this.LBCliente.Text = "MOSTRADOR";
            this.lblClienteSuc.Text = "Proveedor:";
            this.LBTransaccion.Text = "...";
            LimpiarCurrentItemDisplay();
            this.TBCommandLine.Focus();
            this.TBCommandLine.Enabled = true;


            this.TBCosto.Enabled = true;
            this.TBCantidad.Enabled = true;

            if(m_enableDescuento)
                this.TBDescuento.Enabled = true;

            this.TBReferencias.Enabled = true;
            this.TBObservaciones.Enabled = true;

            //this.PROVEEDORIDTextBox.Enabled = true;
            //this.PROVEEDORButton.Enabled = true;

            this.TBPROVEEDOR.Enabled = true;
            this.BTPROVEEDOR.Enabled = true;
            //this.ComboProveedor.Enabled = true;

            this.DTPFecha.Enabled = false;
            this.DTPFecha.Value = DateTime.Today;

            this.DTPFechaVence.Enabled = true;
            this.DTPFechaVence.Value = DateTime.Today;

            this.BTEnviar.Enabled = true;

            this.DTPFechaFactura.Value = DateTime.Today;

            RefrescarEstatusBotones();



            if (CurrentUserID.CurrentParameters.IDIVIDIR_REM_FACT.Equals("N"))
            {
                this.CBOrigenFiscal.Enabled = true;//false;
                this.CBOrigenFiscal.SelectedIndex = 0;
            }
            else
            {
                this.CBOrigenFiscal.Enabled = true;
                this.CBOrigenFiscal.SelectedIndex = -1;
            }


            //this.PROVEEDORIDTextBox.Text = "";

            this.LBPROVEEDOR.Text = "...";
            this.TBPROVEEDOR.Text = "";
            //this.ComboProveedor.SelectedIndex = -1;

            this.BTCotizacion.Visible = false;
            lbTotalPiezas.Text = "0.00";
            
            NOTAPAGOTextBox.Text = "";

            if (m_manejaAlmacen)
            {
               // this.ALMACENComboBox.Enabled = true;
               // this.ALMACENComboBox.SelectedIndex = -1;
                SetDefaultAlmacenEstatus();
            }

            this.DTPFechaFactura.Enabled = true;
            btnGuardarCambios.Visible = false;
        }




        private void NuevoRegistro()
        {
            if ((!(bool)m_Docto.isnull["IID"]) && m_Docto.ICOTI_ENRUTADA != "S"
                && (m_estadoTransaccion != (int)estadoTransaccion.e_Cerrada && m_estadoTransaccion != (int)estadoTransaccion.e_Cancelada))
            {
                if (!CancelarTransaccionActual())
                    IrANuevaTransaccion();

            }
            else
                IrANuevaTransaccion();
        }



        private void BTPasarANueva_Click(object sender, EventArgs e)
        {
            NuevoRegistro();

        }

        #endregion

        #region Abrir Transaccions Pendientes
        private void BTAbrirTransaccion_Click(object sender, EventArgs e)
        {
            if (!(bool)m_Docto.isnull["IID"] && m_Docto.ICOTI_ENRUTADA != "S"
                && m_estadoTransaccion != (int)estadoTransaccion.e_Cancelada
                && m_estadoTransaccion != (int)estadoTransaccion.e_Cerrada)
            {
                CancelarTransaccionActual();
            }
            AbrirTransaccion();
            RefrescarEstatusBotones();
        }
        private void AbrirTransaccion()
        {
            IrANuevaTransaccion();
            //string strBuffer = "";
            //GeneralLookUp look = new GeneralLookUp("select * from VENTAS where GV_ESTATUS = '" + CVENTASD.strStatusAbierta + @"'", "VENTAS");
            WFLOOKUPCOMPRAS look = new WFLOOKUPCOMPRAS();
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                m_Docto.IID = int.Parse(dr[0].ToString());
                CDOCTOD vData = new CDOCTOD();
                m_Docto = vData.seleccionarDOCTO(m_Docto, null);
                RefrescarGridTransaccions();

                if (!(bool)m_Docto.isnull["IREFERENCIA"])
                    this.TBReferencias.Text = m_Docto.IREFERENCIA;

                if (!(bool)m_Docto.isnull["IREFERENCIAS"])
                    this.TBObservaciones.Text = m_Docto.IREFERENCIAS;

                if (!(bool)m_Docto.isnull["INOTAPAGO"])
                    this.NOTAPAGOTextBox.Text = m_Docto.INOTAPAGO;



                if (!(bool)m_Docto.isnull["IFECHA"])
                    this.DTPFecha.Value = m_Docto.IFECHA;


                if (!(bool)m_Docto.isnull["IVENCE"])
                    this.DTPFechaVence.Value = m_Docto.IVENCE;

                if (!(bool)m_Docto.isnull["IFECHAFACTURA"])
                    this.DTPFechaFactura.Value = m_Docto.IFECHAFACTURA;



                /*if (!(bool)m_Docto.isnull["IPERSONAID"])
                {
                    this.ComboProveedor.SelectedValue = m_Docto.IPERSONAID;
                }*/

                if (!(bool)m_Docto.isnull["IPERSONAID"])
                {
                    this.m_iProveedorId = m_Docto.IPERSONAID;
                    CPERSONABE provee = obtainCurrentProveedorPorId(m_Docto.IPERSONAID);
                    if(provee != null)
                    {
                        this.TBPROVEEDOR.Text = provee.ICLAVE;
                        this.LBPROVEEDOR.Text = provee.INOMBRE;
                        m_proveedorEsImportador = provee.IESIMPORTADOR;
                    }

                    /*
                    this.PROVEEDORIDTextBox.DbValue = m_Docto.IPERSONAID.ToString();
                    this.PROVEEDORIDTextBox.MostrarErrores = false;
                    this.PROVEEDORIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.PROVEEDORIDTextBox.MostrarErrores = true;
                     * */
                }


                if (!(bool)m_Docto.isnull["IORIGENFISCALID"])
                {
                    switch (m_Docto.IORIGENFISCALID)
                    {
                        case 2: this.CBOrigenFiscal.SelectedIndex = 0; break;
                        case 3: this.CBOrigenFiscal.SelectedIndex = 1; break;
                        default:

                            if (CurrentUserID.CurrentParameters.IDIVIDIR_REM_FACT.Equals("N"))
                            {
                                this.CBOrigenFiscal.SelectedIndex = 0;
                            }
                            else
                            {
                                this.CBOrigenFiscal.SelectedIndex = -1;
                            }
                            break;
                    }
                }




                if (m_manejaAlmacen)
                {
                    this.ALMACENComboBox.Enabled = false;
                    if (!(bool)m_Docto.isnull["IALMACENID"])
                        this.ALMACENComboBox.SelectedDataValue = m_Docto.IALMACENID;
                    else
                        this.ALMACENComboBox.SelectedIndex = -1;
                }

                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_ORDEN_COMPRA)
                {
                    this.LBOperacion.Text = "Orden de compra";
                }
                else if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA_SUC)
                {
                    this.LBOperacion.Text = "Compra de sucursal";
                }


            }



        }
        #endregion

        #region Seleccionar Cliente  ( no usado)
        private void SeleccionarCliente()
        {
            GeneralLookUp look = new GeneralLookUp("select * from CLIENTES", "CLIENTES");
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                this.TBCommandLine.Text = "CLIENTE::" + dr[0].ToString();
                TBCommandLine.Focus();
            }
        }
        #endregion

        #region Seleccionar Producto
        private void BTSeleccionarProducto_Click(object sender, EventArgs e)
        {
            SeleccionarProducto();
        }

        private void SeleccionarProducto()
        {
            
            SeleccionarProducto("");
        }
        private void SeleccionarProducto(string strDescripcion)
        {

            LOOKPROD look;
            if (strDescripcion == "")
                look = new LOOKPROD("",false,TipoProductoNivel.tp_hijos);
            else
                look = new LOOKPROD(strDescripcion, false, TipoProductoNivel.tp_hijos);


            if (this.m_manejaAlmacen)
            {
                try
                {
                    if (long.Parse(this.ALMACENComboBox.SelectedValue.ToString()) > 0)
                        look.m_almacenIdPredeterminado = long.Parse(this.ALMACENComboBox.SelectedValue.ToString());

                }
                catch
                {
                }
            }

            look.ShowDialog();
            
            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                this.TBCommandLine.Text = dr["CLAVE"].ToString().Trim();
                TBCommandLine.Focus();
                TBCommandLine.Select(TBCommandLine.Text.Length, 0);
                //ProcessCommand();
            }
            else
            {
                this.TBCommandLine.Text = strDescripcion;
                TBCommandLine.Focus();
            }
        }


        private void SeleccionaProveedor()
        {
            m_validateProveedorOn = false;

            iPos.Catalogos.WFProveedores look = new iPos.Catalogos.WFProveedores();
            look.m_bSelecionarRegistro = true;
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);


            if (dr != null)
            {
                this.TBPROVEEDOR.Text = dr["CLAVE"].ToString().Trim();
                this.m_iProveedorId = (long)dr["ID"];
                this.LBPROVEEDOR.Text = dr["NOMBRE"].ToString().Trim();

                //llenarDatosCliente();

                CPERSONABE provee = obtainCurrentProveedorPorClave(this.TBPROVEEDOR.Text);
                if (provee != null)
                {

                    this.DTPFechaVence.Value = DTPFecha.Value.AddDays(provee.IDIAS);
                    m_proveedorEsImportador = provee.IESIMPORTADOR;

                }

                

            }
            m_validateProveedorOn = true;
        }


        private CPERSONABE obtainCurrentProveedorPorClave(string strClave)
        {
            CPERSONAD provD = new CPERSONAD();
            
            CPERSONABE proveedorBE = new CPERSONABE();
            proveedorBE.ICLAVE = strClave;
            proveedorBE.ITIPOPERSONAID = 40;
            proveedorBE = provD.seleccionarPERSONAxCLAVEyTIPO(proveedorBE, null);

            return proveedorBE;
        }
        private CPERSONABE obtainCurrentProveedorPorId(long id)
        {
            CPERSONAD provD = new CPERSONAD();

            CPERSONABE proveedorBE = new CPERSONABE();
            proveedorBE.IID = id;
            proveedorBE = provD.seleccionarPERSONA(proveedorBE, null);

            return proveedorBE;
        }
       
       

        #endregion

        #region Pagar Cerrar Transaccion

        private void BTCerrarTransaccion_Click(object sender, EventArgs e)
        {
            if (m_estadoTransaccion == (int)estadoTransaccion.e_Cerrada || m_estadoTransaccion == (int)estadoTransaccion.e_Cancelada)
                return;

            PreguntarGastosAdicionalesSiAplica();

            PagarBasico();

        }

        private void PreguntarGastosAdicionalesSiAplica()
        {
            if(CurrentUserID.CurrentParameters.IMANEJAGASTOSADIC == "S" && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA)
            {
                CMOVTOGASTOSADICD movtoGastoD = new CMOVTOGASTOSADICD();
                int cuenta = movtoGastoD.cuentaGastosXDoctoID(m_Docto.IID, null);

                if(cuenta <= 0)
                {
                    if (MessageBox.Show("No ha agregado gastos adicionales . Desea hacerlo? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        AbrirGastosAdicionales();
                    }
                }
            }
        }




        private bool PreguntaComentarioCancelacion(long doctoId, long usuarioId, FbTransaction ftrans)
        {
            string comentarioAut = "";
            WFPreguntaComentario wf1_ = new WFPreguntaComentario();
            wf1_.m_labelText = "Comentario de la cancelación";
            wf1_.ShowDialog();
            comentarioAut = wf1_.m_comentario.Trim();
            wf1_.Dispose();
            GC.SuppressFinalize(wf1_);

            if (comentarioAut != null && comentarioAut.Trim().Length > 0)
            {
                CDOCTOD doctoD = new CDOCTOD();
                doctoD.CambiarDOCTONOTASET(doctoId, DBValues._TIPODOCTONOTA_CANCELACION, DateTime.Now, usuarioId, comentarioAut, ftrans);

                return true;
            }

            return false;

        }

        private void PagarBasico()
        {



            if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_ORDEN_COMPRA)
            {

                if (!Precierre())
                    return;

                if (m_Docto != null && m_Docto.IID > 0)
                {
                    ObtenerDoctoDeBD(m_Docto.IID);
                    ObtenerCaja();

                    string esapartado = "N";

                    if (m_Docto.ITIPODOCTOID != DBValues._DOCTO_TIPO_ORDEN_COMPRA)
                    {
                        WFPagosBasicoCompras wp = new WFPagosBasicoCompras(m_Docto, m_Caja, false, 0, this.m_DoctoRef, this.m_tipoTransaccion, esapartado, false);
                        wp.ShowDialog();
                        if (wp.m_bPagoCompleto)
                        {



                            this.CerrarTransaccion();



                            if (wp.DOCTOPAGOIDEFECTIVO > 0 || wp.DOCTOPAGOIDTARJETA > 0 || wp.DOCTOPAGOIDCHEQUE > 0)
                            {

                                if (MessageBox.Show("Desea imprimir recibo(s) de pago? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    if (wp.DOCTOPAGOIDEFECTIVO > 0)
                                        imprimirRecibo(wp.DOCTOPAGOIDEFECTIVO);

                                    if (wp.DOCTOPAGOIDTARJETA > 0)
                                        imprimirRecibo(wp.DOCTOPAGOIDTARJETA);


                                    if (wp.DOCTOPAGOIDCHEQUE > 0)
                                        imprimirRecibo(wp.DOCTOPAGOIDCHEQUE);

                                }
                            }

                        }
                        wp.Dispose();
                        GC.SuppressFinalize(wp);
                    }
                    else
                    {
                        this.CerrarTransaccion();
                    }

                    this.Focus();
                }
            }


        }
        private void CerrarTransaccion()
        {
            CComprasD pvd = new CComprasD();

            if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_ORDEN_COMPRA)
            {
                pvd.CerrarTransaccionOrdenDeCompra(m_Docto, null);
            }
            else
            {
                pvd.CerrarTransaccion(m_Docto, null);
            }
            
            
            if (pvd.IComentario == "" || pvd.IComentario == null)
            {
                //ImprimirTicket(false);
                //PosPrinter.ImprimirTicket(m_Docto.IID, Ticket._OPCION_IMPRESION_COMPRA, false, false, 1, CBMostrarUSD.Checked);
                ImprimirTicketCompra();

                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO)
                {
                    CDOCTOD vData = new CDOCTOD();
                    m_Docto = vData.seleccionarDOCTO(m_Docto, null);

                    ExportarTraslados(m_Docto.IFOLIO);
                }

                IrANuevaTransaccion();
                HiloExistencias._IFLAGENVIAREXISTENCIASEVENTOS++;
                this.TBCommandLine.Focus();
            }
            else
            {
                MessageBox.Show("ERRORES: " + pvd.IComentario.Replace("%", "\n"));
            }
        }




        public bool ImprimirTicketCompra(int cantidadCopias = 0)
        {
            int iCantidadTickets = cantidadCopias == 0 && CurrentUserID.CurrentParameters.ICANTTICKETCOMPRAS > 0 ? CurrentUserID.CurrentParameters.ICANTTICKETCOMPRAS : cantidadCopias > 0 ? cantidadCopias : 1;

            bool bTicketImpreso = false;
            for (int i = 0; i < iCantidadTickets; i++)
            {
                
                PosPrinter.ImprimirTicket(m_Docto.IID, Ticket._OPCION_IMPRESION_COMPRA, false, false, 1, CBMostrarUSD.Checked);
            }

            return bTicketImpreso;
        }




        private bool Precierre()
        {

            if (m_tipoTransaccion == tipoTransaccionV.t_compra)
            {

                if (this.CBOrigenFiscal.SelectedIndex < 0)
                {

                    MessageBox.Show("Debe seleccionar el origen fiscal (facturado o remisionado) ");
                    return false;
                }
                m_Docto.IORIGENFISCALID = (this.CBOrigenFiscal.SelectedIndex == 0) ? DBValues._ORIGENFISCAL_REMISIONADO : DBValues._ORIGENFISCAL_FACTURADO;
                m_Docto.IREFERENCIA = this.TBReferencias.Text;
                m_Docto.IREFERENCIAS = this.TBObservaciones.Text;
                m_Docto.IFECHAFACTURA = this.DTPFechaFactura.Value;
                m_Docto.IVENCE = this.DTPFechaVence.Value;
            }

            CComprasD pvd = new CComprasD();
            int errorCode = 0;
            if (!pvd.COMPRA_PRECIERRE(m_Docto, null, ref errorCode))
            {
                MessageBox.Show("ERRORES: " + pvd.IComentario.Replace("%", "\n"));
                if (errorCode == (int)DBValues._ERRORCODE_EXISTENCIAINSUFICIENTE)
                {
                    WFMovtosSinExistencia wf = new WFMovtosSinExistencia(m_Docto.IID);
                    wf.ShowDialog();
                    wf.Dispose();
                    GC.SuppressFinalize(wf);
                }
                return false;
            }
            return true;
        }

        #endregion

        #region Operaciones Eventos General

        private void WFPuntoDeTransaccion_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F6:
                    if (m_estadoTransaccion != (int)estadoTransaccion.e_Cerrada && m_estadoTransaccion != (int)estadoTransaccion.e_Cancelada)
                        PagarBasico();
                    break;
                case Keys.F5:
                    AbrirTransaccionsCerradasYDevoluciones();
                    break;
                case Keys.F4:
                    if (!e.Alt)
                        AbrirTransaccion();
                    break;
                case Keys.F2:
                    IrANuevaTransaccion();
                    break;
                case Keys.F3:
                    if (m_estadoTransaccion != (int)estadoTransaccion.e_Cancelada)
                        CancelarTransaccionActual();
                    break;
                case Keys.F8:
                    SeleccionarProducto();
                    break;

                case Keys.F9:
                    ModoTraslado();
                    break;

                case Keys.F10:
                    if (m_estadoTransaccion != (int)estadoTransaccion.e_Cerrada && m_estadoTransaccion != (int)estadoTransaccion.e_Cancelada)
                        EliminarDetalle();
                    break;

                case Keys.Escape:
                    this.Close();
                    break;

                default:
                    break;
            }
        }



        private void WFPuntoDeTransaccion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_bSalirSinPreguntar)
                return;

            CComprasD pvd = new CComprasD();
            DateTime fechaCorte = DateTime.MinValue;
            if (!pvd.HayCorteActivo(ref fechaCorte, iPos.CurrentUserID.CurrentUser.IID))
                return;

            if (!(bool)m_Docto.isnull["IID"] && m_Docto.ICOTI_ENRUTADA != "S"
                && m_estadoTransaccion != (int)estadoTransaccion.e_Cancelada
                && m_estadoTransaccion != (int)estadoTransaccion.e_Cerrada)
            {
                CancelarTransaccionActual();
            }


            if (MessageBox.Show("Realmente quiere salir de esta pantalla?", "Salir de esta pantalla", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;


        }
        #endregion

        #region Eliminar Detalle

        private void EliminarDetalle()
        {
            CComprasD pvd = new CComprasD();
            CMOVTOBE movtoBE = new CMOVTOBE();

            if (this.gridPVDataGridView.Rows.Count <= 0)
                return;

            //asegurarnos de que realmente se quiere eliminar el detalle y que el supervisor dio su aval
            if (MessageBox.Show("Realmente quiere eliminar el detalle de transaccion?", "Eliminar detalle de transaccion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (m_estadoTransaccion != (int)estadoTransaccion.e_SinIniciar)
                {
                    WFPreguntaAutorizacion ps2 = new WFPreguntaAutorizacion();
                    ps2.ShowDialog();
                    CPERSONABE userBE = ps2.m_userBE;
                    bool bPassValido = ps2.m_bPassValido;
                    bool bIsSupervisor = ps2.m_bIsSupervisor;
                    bool bIsAdministrador = ps2.m_bIsAdministrador;
                    ps2.Dispose();
                    GC.SuppressFinalize(ps2);

                    if (!bPassValido)
                        return;

                    if (!bIsSupervisor)
                    {
                        MessageBox.Show("El usuario no es un supervisor");
                        return;
                    }
                }
            }
            else
                return;


            LimpiarCurrentItemDisplay();

            if (this.gridPVDataGridView.CurrentRow.Index != this.gridPVDataGridView.NewRowIndex)
            {
                movtoBE.IID = (long)this.gridPVDataGridView.CurrentRow.Cells["MOVTOID"].Value;
                if (!pvd.BorrarMOVTOVENTAS(movtoBE, null))
                {
                    MessageBox.Show(pvd.IComentario);
                }
                RefrescarGridTransaccions();
            }
            RefrescarEstatusBotones();
            this.TBCommandLine.Focus();

        }

        private void BTEliminarDetalle_Click(object sender, EventArgs e)
        {

            if (m_estadoTransaccion == (int)estadoTransaccion.e_Cerrada || m_estadoTransaccion == (int)estadoTransaccion.e_Cancelada)
                return;

            EliminarDetalle();
        }


        #endregion

        #region Abrir transaccions cerradas

        private void AbrirTransaccionsCerradasYDevoluciones()
        {
            AbrirTransaccionsCerradasYDevoluciones(0);
        }
        private void AbrirTransaccionsCerradasYDevoluciones(long doctoId)
        {
            IrANuevaTransaccion();
            //string strBuffer = "";

            if (doctoId == 0)
            {
                WFLOOKUPCOMPRAS look = new WFLOOKUPCOMPRAS((int)DBValues._DOCTO_ESTATUS_COMPLETO, 0);
                look.ShowDialog();

                DataRow dr = look.m_rtnDataRow;

                if (dr != null)
                    doctoId = long.Parse(dr[0].ToString());

                look.Dispose();
                GC.SuppressFinalize(look);
            }

            if (doctoId > 0)
            {
                m_Docto.IID = doctoId;
                CDOCTOD vData = new CDOCTOD();
                m_Docto = vData.seleccionarDOCTO(m_Docto, null);
                RefrescarGridTransaccions();
                this.gridPVDataGridView.BackgroundColor = Color.Gainsboro;
                this.gridPVDataGridView.DefaultCellStyle.BackColor = Color.Gainsboro;
                this.TBCommandLine.Enabled = false;

                this.TBCosto.Enabled = false;
                this.TBCantidad.Enabled = false;

                if (m_enableDescuento)
                    this.TBDescuento.Enabled = false;

                //this.TBReferencias.Enabled = false;
                //this.TBObservaciones.Enabled = false;
                this.TBPROVEEDOR.Enabled = true;
                this.BTPROVEEDOR.Enabled = true;

                //this.PROVEEDORIDTextBox.Enabled = false;
                //this.PROVEEDORButton.Enabled = false;
                //this.ComboProveedor.Enabled = false;

                this.DTPFecha.Enabled = false;
                this.DTPFechaVence.Enabled = false;
                this.BTEnviar.Enabled = false;

                if (m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_CANCELADA || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_CANCELACION)
                {
                    m_estadoTransaccion = (int)estadoTransaccion.e_Cancelada;
                }
                else
                {
                    if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_ORDEN_COMPRA ||
                        m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_REC || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_PEDIDO_COMPRA )
                    {
                        this.BTCancelarTransaccion.Enabled = true;
                    }
                    else
                    {
                        this.BTCancelarTransaccion.Enabled = false;
                    }
                    m_estadoTransaccion = (int)estadoTransaccion.e_Cerrada;
                }

                this.BTPasarANueva.Enabled = true;
                this.BTEliminarDetalle.Enabled = false;
                this.BTCerrarTransaccion.Enabled = false;
                this.LBOperacion.Text = "Consulta";

                if(!(bool)m_Docto.isnull["IREFERENCIA"])
                     this.TBReferencias.Text = m_Docto.IREFERENCIA;

                if (!(bool)m_Docto.isnull["IREFERENCIAS"])
                    this.TBObservaciones.Text = m_Docto.IREFERENCIAS;

                if (!(bool)m_Docto.isnull["INOTAPAGO"])
                    this.NOTAPAGOTextBox.Text = m_Docto.INOTAPAGO;


                if (!(bool)m_Docto.isnull["IFECHA"])
                    this.DTPFecha.Value = m_Docto.IFECHA;


                if (!(bool)m_Docto.isnull["IVENCE"])
                    this.DTPFechaVence.Value = m_Docto.IVENCE;


                if (!(bool)m_Docto.isnull["IFECHAFACTURA"])
                    this.DTPFechaFactura.Value = m_Docto.IFECHAFACTURA;



                if (!(bool)m_Docto.isnull["IPERSONAID"])
                {


                    this.m_iProveedorId = m_Docto.IPERSONAID;
                    CPERSONABE provee = obtainCurrentProveedorPorId(m_Docto.IPERSONAID);
                    if (provee != null)
                    {
                        this.TBPROVEEDOR.Text = provee.ICLAVE;
                        this.LBPROVEEDOR.Text = provee.INOMBRE;
                        m_proveedorEsImportador = provee.IESIMPORTADOR;
                    }

                    /*
                    this.PROVEEDORIDTextBox.DbValue = m_Docto.IPERSONAID.ToString();
                    this.PROVEEDORIDTextBox.MostrarErrores = false;
                    this.PROVEEDORIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.PROVEEDORIDTextBox.MostrarErrores = true;*/
                }
                /*
                if (!(bool)m_Docto.isnull["IPERSONAID"])
                {
                    this.ComboProveedor.SelectedValue = m_Docto.IPERSONAID;
                }*/


                if (!(bool)m_Docto.isnull["IORIGENFISCALID"])
                {
                    switch (m_Docto.IORIGENFISCALID)
                    {
                        case 2: this.CBOrigenFiscal.SelectedIndex = 0; break;
                        case 3: this.CBOrigenFiscal.SelectedIndex = 1; break;
                        default: this.CBOrigenFiscal.SelectedIndex = -1; break;
                    }
                    this.CBOrigenFiscal.Enabled = false;
                }



                this.BTCotizacion.Visible = true;


                if (m_manejaAlmacen)
                {
                    this.ALMACENComboBox.Enabled = false;
                    if (!(bool)m_Docto.isnull["IALMACENID"])
                        this.ALMACENComboBox.SelectedDataValue = m_Docto.IALMACENID;
                    else
                        this.ALMACENComboBox.SelectedIndex = -1;
                }



                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA_SUC)
                {
                    this.CBOrigenFiscal.Enabled = true;// false;
                    this.DTPFechaFactura.Enabled = true;
                    btnGuardarCambios.Visible = true;
                    
                }
                else
                {

                    this.CBOrigenFiscal.Enabled = false;// false;
                    this.DTPFechaFactura.Enabled = false;
                    btnGuardarCambios.Visible = false;
                }


            }
        }

        private void BTAbrirCerradasYDevo_Click(object sender, EventArgs e)
        {
            AbrirTransaccionsCerradasYDevoluciones();
        }

        #endregion

        #region Traslados

        private bool SeleccionarSucursalTID(int p_sucursalId)
        {
            bool retorno = false;
            LookUpSucursales look;
            look = new LookUpSucursales(p_sucursalId);
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);


            if (dr != null)
            {
                m_sucursalTID = (long)dr[0];
                this.LBOperacion.Text = "Traslado";
                lblClienteSuc.Text = "SUC_DEST:";
                LBCliente.Text = dr[6].ToString();
                retorno = true;
            }

            return retorno;
        }




        private void ExportarTraslados(int folio)
        {


            ImportaDesdeFtp iDBF = new ImportaDesdeFtp();
            //string strResultado = "";
            ArrayList resultadosExportacion = new ArrayList();
            if (!iDBF.EnviarArchivosAFtpDeTraslados(ref resultadosExportacion, folio))
            {

                string strResultadoFinal = iDBF.IComentario + "\n";
                foreach (string strRes in resultadosExportacion)
                {
                    strResultadoFinal += strRes + "\n";
                }

                MessageBox.Show(strResultadoFinal);
            }
            else
                MessageBox.Show("La exportacion se ha realizado");


        }
        private void ModoTraslado()
        {

            NuevoRegistro();
            if (!SeleccionarSucursalTID(CurrentUserID.CurrentParameters.ISUCURSALID))
                return;

            m_Docto.ITIPODOCTOID = DBValues._DOCTO_TIPO_TRASPASO_ENVIO;
            this.BTPasarANueva.Enabled = true;
        }

        private void BTTraspaso_Click(object sender, EventArgs e)
        {
            ModoTraslado();
        }

        #endregion


        private bool BuscarProducto(ref CPRODUCTOBE prod)
        {


            //bool bLastAssigned = false; // ultima busqueda

            string texto = TBCommandLine.Text;
            string bufferBusquedaText = texto;
            if (bufferBusquedaText.Contains(" <(("))
            {
                string[] strSeparators = new string[] { " <((" };


                string[] strBuffert = bufferBusquedaText.Split(strSeparators, StringSplitOptions.RemoveEmptyEntries);
                if (strBuffert.Count() > 1)
                {

                    //ultima busqueda
                    //bLastAssigned = true;

                    bufferBusquedaText = strBuffert[strBuffert.Count() - 1];


                    string[] strSeparatorsBeta = new string[] { "))>" };

                    string[] strBufferz = bufferBusquedaText.Split(strSeparatorsBeta, StringSplitOptions.RemoveEmptyEntries);
                    if (strBufferz.Count() > 0)
                        bufferBusquedaText = strBufferz[0];

                    if (bufferBusquedaText.Trim().Length > 0)
                        texto = bufferBusquedaText.Trim();
                }

            }


                CComprasD pvd = new CComprasD();
                prod = pvd.buscarPRODUCTOSPV(texto, CurrentUserID.CurrentParameters, null);
                if (prod != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }

        private void TBCommandLine_Validating(object sender, CancelEventArgs e)
        {
            CPRODUCTOBE prod = new CPRODUCTOBE();
            if (ValidCommandLine(true, ref prod) == 0 )
            {
                e.Cancel = true;
                MessageBox.Show("Producto no valido");
            }


        }



        #endregion

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            ProcessCommand();
        }

        private void TBCommandLine_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                CPRODUCTOBE prod = new CPRODUCTOBE();
                int res = ValidCommandLine(false,ref prod);
                if (res == 0)
                {
                    string bufferCommandLine = this.TBCommandLine.Text;
                    this.TBCommandLine.Text = "";
                    SeleccionarProducto(bufferCommandLine);
                }
                else if (res == 1)
                {

                    //if (prod.IESPRODUCTOPADRE == "S")
                    //{
                    //    SeleccionarSubProducto(prod.IID, TBCommandLine.Text);
                    //    return;
                    //}

                    if (bEstaConfiguradoParaPiezasyCajas() && (prod.IUNIDAD == null || !prod.IUNIDAD.Trim().ToUpper().Equals("KG")))
                    {
                        TBCajas.Focus();
                    }
                    else
                    {
                        TBCantidad.Focus();
                    }
                }
                else if (res == 2)
                {

                    SeleccionarSubProducto(prod.IID, TBCommandLine.Text);
                }
            }
        }

        private void gridPVDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            if ((gridPVDataGridView.Columns["GVCANTIDAD"].Index != e.ColumnIndex && gridPVDataGridView.Columns["PRECIOUNIDAD"].Index != e.ColumnIndex && gridPVDataGridView.Columns["DESCUENTOPORCENTAJE"].Index != e.ColumnIndex && gridPVDataGridView.Columns["DGCOSTOENDOLAR"].Index != e.ColumnIndex)
                || (m_estadoTransaccion == (int)estadoTransaccion.e_Cancelada || m_estadoTransaccion == (int)estadoTransaccion.e_Cerrada))
                return;


            if (gridPVDataGridView.Columns["GVCANTIDAD"].Index == e.ColumnIndex)
            {

                try
                {
                    decimal dNuevaCantidad = decimal.Parse(e.FormattedValue.ToString());
                    decimal dViejaCantidad = decimal.Parse(gridPVDataGridView.Rows[e.RowIndex].Cells["GVCANTIDAD"].Value.ToString());
                    decimal dEntrada = dNuevaCantidad - dViejaCantidad;
                    if (dEntrada == 0)
                        return;


                    if (dNuevaCantidad <= 0)
                    {
                        MessageBox.Show("La cantidad  no puede ser menor o igual a cero, si requiere cancelar el detalle porfavor seleccione 'Eliminar detalle'");
                        e.Cancel = true;
                    }
                    else
                    {
                        TBCommandLine.Text = gridPVDataGridView.Rows[e.RowIndex].Cells["GVCLAVEPRODUCTO"].Value.ToString();


                        if (bEstaConfiguradoParaPiezasyCajas())
                        {
                            TBCajas.Text = "0";
                        }
                        
                        TBCantidad.Text = dEntrada.ToString("N0");
                        TBCajas.Text = "0.00";
                        TBCosto.Text = gridPVDataGridView.Rows[e.RowIndex].Cells["DGCOSTO"].Value.ToString();
                        try
                        {
                            TBDescuento.Text = gridPVDataGridView.Rows[e.RowIndex].Cells["DESCUENTOPORCENTAJE"].Value.ToString();
                        }
                        catch
                        {
                            TBDescuento.Text = "0.00";
                        }
                        LBIva.Text = gridPVDataGridView.Rows[e.RowIndex].Cells["TASAIVA"].Value.ToString();
                        long? P_MOVTOID = (long)gridPVDataGridView.Rows[e.RowIndex].Cells["MOVTOID"].Value;
                        if (!ProcessCommand(ref P_MOVTOID, null))
                        {
                            e.Cancel = true;
                        }
                    }
                    return;
                }
                catch
                {
                    MessageBox.Show("Cheque el formato de entrada del valor");
                    e.Cancel = true;
                }
            }
            else if (gridPVDataGridView.Columns["PRECIOUNIDAD"].Index == e.ColumnIndex)
            {
                try
                {
                    decimal dNuevoCosto = decimal.Parse(e.FormattedValue.ToString());
                    decimal dViejoCosto = decimal.Parse(gridPVDataGridView.Rows[e.RowIndex].Cells["PRECIOUNIDAD"].Value.ToString());

                    if (dNuevoCosto == dViejoCosto)
                        return;



                    if (dNuevoCosto < 0)
                    {

                        MessageBox.Show("El costo no puede ser menor que cero");
                        e.Cancel = true;
                    }
                    else
                    {
                        TBCommandLine.Text =  gridPVDataGridView.Rows[e.RowIndex].Cells["GVCLAVEPRODUCTO"].Value.ToString();

                        decimal dCostoSinImpuestos = 0;
                        decimal dTasaIva = 0;
                        try
                        {
                            dTasaIva = decimal.Parse(gridPVDataGridView.Rows[e.RowIndex].Cells["TASAIVA"].Value.ToString());
                        }
                        catch
                        {
                        }

                        decimal dTasaIeps = 0;
                        try
                        {
                            dTasaIeps = decimal.Parse(gridPVDataGridView.Rows[e.RowIndex].Cells["TASAIEPS"].Value.ToString());
                        }
                        catch
                        {
                        }

                        bool precioNetoEnGrids = !((bool)CurrentUserID.CurrentParameters.isnull["IPRECIONETOENGRIDS"] || !CurrentUserID.CurrentParameters.IPRECIONETOENGRIDS.Equals("S"));

                        if (precioNetoEnGrids)
                            dCostoSinImpuestos = calculaPrecioSinImpuestos(dNuevoCosto, dTasaIva, dTasaIeps);
                        else
                            dCostoSinImpuestos = dNuevoCosto;

                        TBCosto.Text = dCostoSinImpuestos.ToString("0.00");
                        TBCantidad.Text = "0.00";
                        TBCajas.Text = "0.00";
                        TBDescuento.Text = gridPVDataGridView.Rows[e.RowIndex].Cells["DESCUENTOPORCENTAJE"].Value.ToString();
                        LBIva.Text = gridPVDataGridView.Rows[e.RowIndex].Cells["TASAIVA"].Value.ToString();



                        long? P_MOVTOID = (long)gridPVDataGridView.Rows[e.RowIndex].Cells["MOVTOID"].Value;
                        if (!ProcessCommand( ref P_MOVTOID, null))
                        {
                            e.Cancel = true;
                        }
                        else
                        {
                            this.TBCommandLine.Focus();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error : Cheque el formato de entrada del valor \n" + ex.Message + ex.StackTrace);
                    e.Cancel = true;
                }
            }

            else if (gridPVDataGridView.Columns["DESCUENTOPORCENTAJE"].Index == e.ColumnIndex)
            {
                try
                {
                    decimal dNuevoDescuento = decimal.Parse(e.FormattedValue.ToString());
                    decimal dViejoDescuento = decimal.Parse(gridPVDataGridView.Rows[e.RowIndex].Cells["DESCUENTOPORCENTAJE"].Value.ToString());

                    if (dNuevoDescuento == dViejoDescuento)
                        return;



                    if (dNuevoDescuento < 0)
                    {

                        MessageBox.Show("El descuento no puede ser menor que cero");
                        e.Cancel = true;
                    }
                    else
                    {
                        TBCommandLine.Text = gridPVDataGridView.Rows[e.RowIndex].Cells["GVCLAVEPRODUCTO"].Value.ToString();

                        decimal dCostoSinImpuestos = 0;
                        decimal dTasaIva = 0;
                        try
                        {
                            dTasaIva = decimal.Parse(gridPVDataGridView.Rows[e.RowIndex].Cells["TASAIVA"].Value.ToString());
                        }
                        catch
                        {
                        }

                        decimal dTasaIeps = 0;
                        try
                        {
                            dTasaIeps = decimal.Parse(gridPVDataGridView.Rows[e.RowIndex].Cells["TASAIEPS"].Value.ToString());
                        }
                        catch
                        {
                        }

                        dCostoSinImpuestos = decimal.Parse(gridPVDataGridView.Rows[e.RowIndex].Cells["DGCOSTO"].Value.ToString());

                        //dCostoSinImpuestos = calculaPrecioSinImpuestos(dCosto, dTasaIva, dTasaIeps);

                        TBCosto.Text = dCostoSinImpuestos.ToString("0.00");
                        TBCantidad.Text = "0.00";
                        TBCajas.Text = "0.00";
                        TBDescuento.Text = dNuevoDescuento.ToString("0.00");
                        LBIva.Text = gridPVDataGridView.Rows[e.RowIndex].Cells["TASAIVA"].Value.ToString();



                        long? P_MOVTOID = (long)gridPVDataGridView.Rows[e.RowIndex].Cells["MOVTOID"].Value;
                        if (!ProcessCommand(ref P_MOVTOID, null))
                        {
                            e.Cancel = true;
                        }
                        else
                        {
                            this.TBCommandLine.Focus();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error : Cheque el formato de entrada del valor \n" + ex.Message + ex.StackTrace);
                    e.Cancel = true;
                }
            }
            else if (gridPVDataGridView.Columns["DGCOSTOENDOLAR"].Index == e.ColumnIndex)
            {
                try
                {
                    decimal dNuevoCostoEnDolar = decimal.Parse(e.FormattedValue.ToString());
                    decimal dViejoCostoEnDolar = decimal.Parse(gridPVDataGridView.Rows[e.RowIndex].Cells["DGCOSTOENDOLAR"].Value.ToString());
                    
                    long P_MOVTOID = (long)gridPVDataGridView.Rows[e.RowIndex].Cells["MOVTOID"].Value;

                    if (dNuevoCostoEnDolar == dViejoCostoEnDolar)
                        return;



                    if (dNuevoCostoEnDolar < 0)
                    {

                        MessageBox.Show("El costo en dolar no puede ser menor que cero");
                        e.Cancel = true;
                    }
                    else
                    {
                        CMOVTOD movtoD = new CMOVTOD();
                        if (!movtoD.CambiarCOSTOENDOLAR(P_MOVTOID, dNuevoCostoEnDolar, null))
                        {
        
                            MessageBox.Show("Ocurrio un error " + movtoD.IComentario);
                            e.Cancel = true;
                        }
                        else
                        {
                            ObtenerDoctoDeBD(m_Docto.IID);

                            RefrescarGridTransaccions();
                            FormatGrid();
                            GetTotalesPagosTransaccion();
                            RefreshTotalesTransaccion();

                            if (CBMostrarUSD.Checked)
                            {
                                GetTotalesPagosUSD();
                                RefreshTotalesTransaccionUSD();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error : Cheque el formato de entrada del valor \n" + ex.Message + ex.StackTrace);
                    e.Cancel = true;
                }
            }




            return;
        }




        private decimal calculaPrecioSinImpuestos(decimal precioConImpuestos, decimal dTasaIva, decimal dTasaIeps)
        {

            decimal dPrecioSinImpuestos = (precioConImpuestos / (1 + (dTasaIva / 100))) / (1 + (dTasaIeps / 100));
            return Math.Round(dPrecioSinImpuestos, 2);


        }
        private decimal calculaPrecioConImpuestos(decimal precioSinImpuestos, decimal dTasaIva, decimal dTasaIeps)
        {

            decimal precioConImpuesto = (precioSinImpuestos * (1 + (dTasaIeps / 100))) * (1 + (dTasaIva / 100));
            return Math.Round(precioConImpuesto, 2);


        }


        private void TBCommandLine_Validated(object sender, EventArgs e)
        {
            

        }



        private void reFormatearPiezasCajasPorUnidad(CPRODUCTOBE prod)
        {

            short numeroDecimales = 2;
            if (prod != null)
            {
                numeroDecimales = CUNIDADD.numerDecimalesPorClaveUnidad(prod.IUNIDAD);
            }
            TBCantidad.NumericScaleOnFocus = numeroDecimales;
            TBCantidad.NumericScaleOnLostFocus = numeroDecimales;

            if (prod.IUNIDAD != null && prod.IUNIDAD.Trim().ToUpper().Equals("KG"))
            {
                if (bEstaConfiguradoParaPiezasyCajas())
                {
                    formatCajasBotellasPiezas(false);
                }
                //TBCantidad.NumericScaleOnFocus = 3;
                //TBCantidad.NumericScaleOnLostFocus = 3;
            }
            else
            {
                if (bEstaConfiguradoParaPiezasyCajas())
                {
                    formatCajasBotellasPiezas(true);
                }
                //TBCantidad.NumericScaleOnFocus = 2;
                //TBCantidad.NumericScaleOnLostFocus = 2;
            }

        }

        private int ValidCommandLine(bool allowEmpty, ref CPRODUCTOBE prod)
        {
            if (this.TBCommandLine.Text == "")
            {

                this.TBDescuento.NumericValue = 0;
                this.TBCantidad.NumericValue = 0;
                this.TBCosto.NumericValue = 0;
                this.TBStatus.Text = "";
                if(!allowEmpty)
                    return 0;
            }
            else
            {
                if (BuscarProducto(ref prod))
                {

                    if (prod.IESPRODUCTOPADRE == "S")
                    {
                        return 2;
                    }


                    this.TBCantidad.Text = bEstaConfiguradoParaPiezasyCajas()  || (prod.IUNIDAD != null && prod.IUNIDAD.Equals("KG")) ? "0" : "1";
                    this.TBCajas.Text = "0.0";
                    this.TBDescuento.Text = "0";

                    if ((bool)prod.isnull["ICOSTOREPOSICION"] || prod.ICOSTOREPOSICION == 0)
                    {
                        if (!(bool)prod.isnull["ICOSTOULTIMO"])
                            this.TBCosto.Text = prod.ICOSTOULTIMO.ToString("N2");
                    }
                    else
                    {
                        this.TBCosto.Text = prod.ICOSTOREPOSICION.ToString("N2");
                    }

                    this.TBStatus.Text = prod.INOMBRE + " // " + prod.IDESCRIPCION + " // " + prod.IDESCRIPCION1;


                    if (!(bool)prod.isnull["ITASAIVA"])
                        this.LBIva.Text = prod.ITASAIVA.ToString("N1");
                    else
                        this.LBIva.Text = "0.0";

                    reFormatearPiezasCajasPorUnidad(prod);


                    if (prod.IUNIDAD != null && prod.IUNIDAD.Equals("KG") /*&& !bEstaConfiguradoParaPiezasyCajas()*/)
                    {
                        TBCantidad.Text = "0";
                    }

                }
                else
                {
                    return 0;
                }
            }

            return 1;
        }

        private void gridPVDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

            if (TBReferencias.Text.Trim().Length == 0 && m_Docto.ITIPODOCTOID != DBValues._DOCTO_TIPO_ORDEN_COMPRA)
            {
                MessageBox.Show("Antes de editar desde el grid, porfavor llene el campo de referencia");
                e.Cancel = true;
                return;
            }

        }

        private void BTCotizacion_Click(object sender, EventArgs e)
        {

            if (m_Docto != null)
            {
                if (!(bool)m_Docto.isnull["IID"])
                {



                    if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_REC )
                    {
                        PosPrinter.ImprimirTicket(m_Docto.IID, Ticket._OPCION_IMPRESION_TRASLADO_RECEPCION);
                        if (MessageBox.Show("Desea imprimir la devolucion que haya aplicado a este traslado/compra? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                                PosPrinter.ImprimirTicket(m_Docto.IID, Ticket._OPCION_IMPRESION_TRASLADO_DEVOLUCION);
                        }
                    }
                    //si es importacion de compra que la opcion sea de compra recepcion
                    else if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA &&
                        (m_Docto.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_COMPRAIMPORTADA ||
                         m_Docto.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_COMPRARECORDEN ||
                         m_Docto.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_COMPRAPEDIDO))
                    {
                        PosPrinter.ImprimirTicket(m_Docto.IID, Ticket._OPCION_IMPRESION_COMPRA_RECEPCION);
                        if (MessageBox.Show("Desea imprimir la devolucion que haya aplicado a este traslado/compra? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            PosPrinter.ImprimirTicket(m_Docto.IID, Ticket._OPCION_IMPRESION_COMPRA_DEVOLUCION);
                        }

                    }
                    else
                    {

                        ImprimirTicketCompra(1);
                        //PosPrinter.ImprimirTicket(m_Docto.IID, Ticket._OPCION_IMPRESION_COMPRA, false, false, 1, CBMostrarUSD.Checked);
                    }
                }
            }
        }

        private void btnOrdenCompra_Click(object sender, EventArgs e)
        {
            ModoOrdenCompra();
        }

        private void ModoOrdenCompra()
        {

            NuevoRegistro();

            m_Docto.ITIPODOCTOID = DBValues._DOCTO_TIPO_ORDEN_COMPRA;

            this.LBOperacion.Text = "Orden de compra";
            this.BTPasarANueva.Enabled = true;
        }

        private void BTPROVEEDOR_Click(object sender, EventArgs e)
        {
            this.SeleccionaProveedor();
        }

        private void TBPROVEEDOR_Validated(object sender, EventArgs e)
        {
            if(m_validateProveedorOn)
            {
                    if (this.TBPROVEEDOR.Text.Equals(""))
                    {

                        this.m_iProveedorId = 0;
                        this.LBPROVEEDOR.Text = "...";

                    }
                    else
                    {
                        CPERSONABE provee = obtainCurrentProveedorPorClave(this.TBPROVEEDOR.Text);
                        if (provee != null)
                        {
                            this.m_iProveedorId = provee.IID;
                            this.LBPROVEEDOR.Text = provee.INOMBRE;

                            this.DTPFechaVence.Value = DTPFecha.Value.AddDays(provee.IDIAS);
                            m_proveedorEsImportador = provee.IESIMPORTADOR;

                        }
                        else
                        {
                            this.m_iProveedorId = 0;
                            this.LBPROVEEDOR.Text = "...";
                            MessageBox.Show("Proveedor no existe , favor de verificar");
                        }
                    }

                    
            }
        }
        
        private void gridPVDataGridView_EnterKeyDownEvent(object sender, EventArgs e)
        {

            this.TBCommandLine.Focus();
        }

        private void btnCalculadora_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void TBCommandLine_Enter(object sender, EventArgs e)
        {

            if (CurrentUserID.CurrentParameters.IAUTOCOMPPROD.Equals("S"))
            {
                TBCommandLine.Width = 400;
            }
        }

        private void TBCommandLine_Leave(object sender, EventArgs e)
        {

            if (CurrentUserID.CurrentParameters.IAUTOCOMPPROD.Equals("S"))
            {
                TBCommandLine.Width = m_CommandLineWidth;
            }
        }

        private void gridPVDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (gridPVDataGridView.Columns["GVCANTIDAD"].Index == e.ColumnIndex)
            {
                if (bEstaConfiguradoParaPiezasyCajas())
                {
                    try
                    {
                        decimal dNuevaCantidad = 0;
                        decimal dViejaCantidad = decimal.Parse(gridPVDataGridView.Rows[e.RowIndex].Cells["GVCANTIDAD"].Value.ToString());

                        decimal dPiezaCaja = 1;

                        try
                        {
                            dPiezaCaja = decimal.Parse(gridPVDataGridView.Rows[e.RowIndex].Cells["DGPZACAJA"].Value.ToString());

                            if (dPiezaCaja < 1)
                                dPiezaCaja = 1;
                        }
                        catch
                        {
                            dPiezaCaja = 1;
                        }

                        TBCommandLine.Text = gridPVDataGridView.Rows[e.RowIndex].Cells["GVCLAVEPRODUCTO"].Value.ToString();

                        


                        string unidad = gridPVDataGridView.Rows[e.RowIndex].Cells["DGUNIDAD"].Value.ToString();
                        bool bHuboCambio = false;
                        decimal dCantidadTotalFinal = 0;


                        short numeroDecimales = 2;
                        if (unidad != null)
                        {
                            numeroDecimales = CUNIDADD.numerDecimalesPorClaveUnidad(unidad);
                        }
                        TBCantidad.NumericScaleOnFocus = numeroDecimales;
                        TBCantidad.NumericScaleOnLostFocus = numeroDecimales;


                        if (!unidad.Equals("PZA"))
                        {
                            WFRecargaCantidad rc = new WFRecargaCantidad(true, false, dViejaCantidad);
                            rc.ShowDialog();

                            dCantidadTotalFinal = rc.m_dMontoRecarga;
                            bHuboCambio = dViejaCantidad != dCantidadTotalFinal;

                            rc.Dispose();
                            GC.SuppressFinalize(rc);
                            //this.TBCantidad.NumericScaleOnFocus = 3;
                            //this.TBCantidad.NumericScaleOnLostFocus = 3;
                        }
                        else
                        {

                            WFDialogCajaPza dlg = new WFDialogCajaPza(dViejaCantidad, dPiezaCaja);
                            dlg.ShowDialog();
                            bHuboCambio = dlg.huboCambio;
                            dCantidadTotalFinal = dlg.dCantidadTotalFinal;
                            dlg.Dispose();
                            GC.SuppressFinalize(dlg);

                            //this.TBCantidad.NumericScaleOnFocus = 2;
                            //this.TBCantidad.NumericScaleOnLostFocus = 2;
                        }




                        if (bHuboCambio)
                        {

                            dNuevaCantidad = dCantidadTotalFinal;

                            decimal dEntrada = dNuevaCantidad - dViejaCantidad;
                            if (dEntrada == 0)
                                return;
                            if (dNuevaCantidad <= 0)
                            {
                                MessageBox.Show("La cantidad  no puede ser menor o igual a cero, si requiere cancelar el detalle porfavor seleccione 'Eliminar detalle'");
                                return;
                            }
                            else
                            {
                                if (bEstaConfiguradoParaPiezasyCajas())
                                {
                                    TBCajas.Text = "0";
                                }
                                TBCantidad.Text = dEntrada.ToString("N3"); 

                                TBCosto.Text = gridPVDataGridView.Rows[e.RowIndex].Cells["DGCOSTO"].Value.ToString();
                                try
                                {
                                    TBDescuento.Text = gridPVDataGridView.Rows[e.RowIndex].Cells["DESCUENTOPORCENTAJE"].Value.ToString();
                                }
                                catch
                                {
                                    TBDescuento.Text = "0.00";
                                }
                                LBIva.Text = gridPVDataGridView.Rows[e.RowIndex].Cells["TASAIVA"].Value.ToString();
                                long? P_MOVTOID = (long)gridPVDataGridView.Rows[e.RowIndex].Cells["MOVTOID"].Value;


                                bool bRes = ProcessCommand(ref P_MOVTOID, null);

                                if (!bRes)
                                {
                                    TBCommandLine.Text = "";
                                    TBCosto.Text = "";
                                    TBDescuento.Text = "";
                                    TBCantidad.Text = "0.00";
                                    TBCajas.Text = "0.00";

                                }
                                else
                                {
                                    this.TBCommandLine.Focus();
                                }
                            }
                            return;



                        }
                    }
                    catch
                    {
                        MessageBox.Show("Cheque el formato de entrada del valor");

                    }


                }
            }
        }




        private void DescripcionesDeProductoEnDataSet(long productoId, ref string desc1, ref string desc2, ref string desc3)
        {
            foreach (iPos.Entradas.DSEntradas.GridPVRow dr in dSEntradas.GridPV.Rows)
            {
                if (dr.PRODUCTOID == productoId)
                {
                    desc1 = dr.MOVTODESCRIPCION1;
                    desc2 = dr.MOVTODESCRIPCION2;
                    desc3 = dr.MOVTODESCRIPCION3;
                    break;
                }

            }
        }




        public void imprimirRecibo(long pagoId)
        {
            string strReporte = "";

            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("itemid", pagoId);

            strReporte = "ReciboPagoProveedor.frx";

            iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
            rp.ShowDialog();
            rp.Dispose();
            GC.SuppressFinalize(rp);
        }

        private void btnGastosAdic_Click(object sender, EventArgs e)
        {
            AbrirGastosAdicionales();
        }

        private void AbrirGastosAdicionales()
        {
            if (m_Docto != null && m_Docto.IID > 0 && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA)
            {
                WFReciboGastosAdicEdit wf = new WFReciboGastosAdicEdit(m_Docto.IID, "Cambiar");
                wf.ShowDialog();
                wf.Dispose();
                GC.SuppressFinalize(wf);

                GetTotalesPagosTransaccion();
                RefreshTotalesTransaccion();

            }
        }

        private void CBMostrarUSD_CheckedChanged(object sender, EventArgs e)
        {
            VisibilidadUSDInfo(CBMostrarUSD.Checked);


            if (CBMostrarUSD.Checked)
            {
                GetTotalesPagosUSD();
                RefreshTotalesTransaccionUSD();
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            WFImportarComprasDesdeExcel wf = new WFImportarComprasDesdeExcel();
            wf.ShowDialog();

            CPRODUCTOD prodD = new CPRODUCTOD();
            CPRODUCTOBE prod = new CPRODUCTOBE();

            CLOTESIMPORTADOSD loteProd = new CLOTESIMPORTADOSD();
            CLOTESIMPORTADOSBE loteProdBE = null;

            bool bHayProductosConLoteImpo = false;

            long? P_LOTEIMPORTADO = null;
            decimal tipoCambio = 1;


              if(TBPROVEEDOR.Text == "")
            {
                MessageBox.Show("por favor seleccione un proveedor valido de la lista ");
                return ;
            }
            long proveedorId = this.m_iProveedorId;//long.Parse(this.PROVEEDORIDTextBox.DbValue.ToString());
            if (proveedorId <= 0)
            {
                MessageBox.Show("por favor seleccione un proveedor valido de la lista ");
                return ;
            }


            List<CPRODUCTOBE> prodListFaltaLote = new List<CPRODUCTOBE>();

            if(wf.m_importacionExitosa)
            {
                //1ra vuelta
                foreach (Dictionary<string, object> item in wf.m_datos)
                {
                    string claveProducto = item["CLAVE"].ToString();
                    decimal cantidad = decimal.Parse(item["CANTIDAD"].ToString());
                    decimal precioUSD = decimal.Parse(item["PRECIOUSD"].ToString());

                    decimal? precioNormal = null;
                    string lote = null;
                    DateTime? fechaVence = null;

                    if (item.ContainsKey("PRECIONORMAL"))
                        precioNormal = decimal.Parse(item["PRECIONORMAL"].ToString());


                    if (item.ContainsKey("LOTE"))
                        lote = item["LOTE"].ToString();


                    if (item.ContainsKey("FECHAVENCE"))
                        fechaVence = (DateTime?)item["FECHAVENCE"];


                    prod.ICLAVE = claveProducto;
                    prod = prodD.seleccionarPRODUCTOxCLAVE(prod, null);

                    if(prod == null)
                    {
                        MessageBox.Show("Hay claves de producto no existen");
                        return ;
                    }



                    if (CurrentUserID.CurrentParameters.IMANEJARLOTEIMPORTACION == "S" && prod.IMANEJALOTEIMPORTADO == "S")
                    {

                        if (m_proveedorEsImportador != "S")
                        {

                            MessageBox.Show("Ha ingresado productos que manejan lote de importacion y el proveedor no es importador");
                            return;
                        }
                        bHayProductosConLoteImpo = true;
                    }


                    if(prod.IMANEJALOTE != null && prod.IMANEJALOTE.Equals("S"))
                    {
                        if(lote == null || lote.Trim().Length == 0 ||
                           fechaVence == null || !fechaVence.HasValue)
                        {
                            prodListFaltaLote.Add(prod);
                        }
                    }
                    

                }

                if(prodListFaltaLote.Count > 0)
                {

                    string str = "Los siguientes productos requieren de que se les defina el lote y fecha de vencimiento: ";

                    foreach(CPRODUCTOBE prodSinLote in prodListFaltaLote)
                    {
                        str +=  prodSinLote.ICLAVE + " , ";
                    }

                    MessageBox.Show(str);
                    return;
                }


                //pedir lote
                if(bHayProductosConLoteImpo)
                {
                    WFDefineLoteImportado pl_ = new WFDefineLoteImportado();
                    pl_.ShowDialog();
                    CLOTESIMPORTADOSBE loteImportado = pl_.loteImportado;
                    pl_.Dispose();
                    GC.SuppressFinalize(pl_);

                    if (loteImportado == null || loteImportado.IID == 0)
                    {
                        MessageBox.Show("Debe definir un lote o pedimento de importacion");
                        return ;
                    }

                    P_LOTEIMPORTADO = loteImportado.IID;

                    loteProdBE = new CLOTESIMPORTADOSBE();
                    loteProdBE.IID = P_LOTEIMPORTADO.Value;
                    loteProdBE = loteProd.seleccionarLOTESIMPORTADOS(loteProdBE, null);
                    if (loteProdBE != null)
                    {
                        tipoCambio = loteProdBE.ITIPOCAMBIO;
                    }

                }


                int iCount = 0;
                //2da vuelta
                foreach( Dictionary<string, object> item in wf.m_datos)
                {

                    iCount++;

                    string claveProducto = item["CLAVE"].ToString();
                    decimal cantidad = decimal.Parse( item["CANTIDAD"].ToString());
                    decimal precioUSD = decimal.Parse( item["PRECIOUSD"].ToString());


                    decimal? precioNormal = null;
                    string lote = null;
                    DateTime? fechaVence = null;

                    if (item.ContainsKey("PRECIONORMAL"))
                        precioNormal = decimal.Parse(item["PRECIONORMAL"].ToString());


                    if (item.ContainsKey("LOTE"))
                        lote = item["LOTE"].ToString();



                    if (item.ContainsKey("FECHAVENCE"))
                        fechaVence = (DateTime?)item["FECHAVENCE"];



                    decimal costo = 0;


                    prod.ICLAVE = claveProducto;
                    prod = prodD.seleccionarPRODUCTOxCLAVE(prod, null);

                    if (prod == null)
                    {
                        MessageBox.Show("Hay claves de producto no existen");
                        return;
                    }

                    if ((!precioNormal.HasValue || precioNormal.Value == 0) && prod.IMANEJALOTEIMPORTADO == "S")
                    {

                        costo = tipoCambio * precioUSD;
                    }
                    else if (precioNormal.HasValue && precioNormal.Value > 0)
                    {
                        costo = precioNormal.Value;
                    }
                    else
                    {
                        costo = prod.ICOSTOREPOSICION;

                    }

                     

                    TBCommandLine.Text = claveProducto;
                    TBCosto.Text = costo.ToString() ;
                    TBCantidad.Text = cantidad.ToString();

                    long? P_MOVTOID = null;


                    if (!ProcessCommand(ref P_MOVTOID, P_LOTEIMPORTADO, lote, fechaVence))
                    {
                        if (MessageBox.Show("Desea continuar importando?", "Seguir importando", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        {
                            return;
                        }
                    }

                    if(P_MOVTOID.HasValue && P_MOVTOID.Value > 0)
                    {

                        CMOVTOD movtoD = new CMOVTOD();
                        if (!movtoD.CambiarCOSTOENDOLAR(P_MOVTOID.Value, precioUSD, null))
                        {

                            if (MessageBox.Show("Ocurrio un error al poner el precio en dolar. Desea seguir importando?", "Seguir importando", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2) == DialogResult.No)
                            {
                                return;
                            }
                        }
                    }



                    
                }


                //3ra vuelta  Refrescar grid

                ObtenerDoctoDeBD(m_Docto.IID);

                RefrescarGridTransaccions();
                FormatGrid();
                GetTotalesPagosTransaccion();
                RefreshTotalesTransaccion();

                if (CBMostrarUSD.Checked)
                {
                    GetTotalesPagosUSD();
                    RefreshTotalesTransaccionUSD();
                }


            }
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {


            if (m_Docto != null && m_Docto.IID > 0 && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA_SUC
                && m_Docto.IESTATUSDOCTOID == 1  && this.m_iProveedorId > 0)
            {

                long ORIGENFISCALID = (this.CBOrigenFiscal.SelectedIndex == 0) ? DBValues._ORIGENFISCAL_REMISIONADO : DBValues._ORIGENFISCAL_FACTURADO;
                string REFERENCIA = this.TBReferencias.Text;
                DateTime FECHAFACTURA = this.DTPFechaFactura.Value;

                CComprasD pvd = new CComprasD();
                if (!pvd.COMPRA_REASIGNAR_DATOS(m_Docto.IID, this.m_iProveedorId, CurrentUserID.CurrentUser.IID,
                                                ORIGENFISCALID, FECHAFACTURA, REFERENCIA,null))
                {
                    MessageBox.Show(pvd.IComentario);
                }
                else
                {
                    MessageBox.Show("El registro se ha actualizado");
                }
            }
        }

        private void btnNoTransaccion_Click(object sender, EventArgs e)
        {

            WFSelectEntradaByFolio wf = new WFSelectEntradaByFolio();
            wf.ShowDialog();

            if (wf.m_selectedDocto != null && wf.m_selectedDocto.IID > 0)
            {
                AbrirTransaccionsCerradasYDevoluciones(wf.m_selectedDocto.IID);
            }
            wf.Dispose();
            GC.SuppressFinalize(wf);
        }

        private void btnNegociacion_Click(object sender, EventArgs e)
        {

            if(m_Docto == null || m_Docto.IID == 0)
            {
                MessageBox.Show("Ingrese al menos un item a la compra");
                return;
            }

            WFLogEventoTransaccion wf = new WFLogEventoTransaccion("Doctos", m_Docto.IID, DBValues._TIPOEVENTOTABLA_NOTACOMPRA);
            wf.ShowDialog();
            wf.Dispose();
            GC.SuppressFinalize(wf);
        }
    }
}