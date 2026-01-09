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

    public partial class WFOtrasSalidas : IposForm
    {

        #region Definición de variables y objetos de clase

        int m_estadoTransaccion;
        decimal m_dMontoTransaccion;
        decimal m_dSumaImporte;
        decimal m_dMontoIva;
        decimal m_dDescuento;
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


        int m_CommandLineWidth = 290;

        long m_default_tipodocto = DBValues._DOCTO_TIPO_OTRASENTRADAS;

        bool m_bPermisoCambiarPrecio = false;

        #endregion

        #region Apariencia e Inicializacion


        public WFOtrasSalidas()
        {
            InitializeComponent();
            ResetearVariablesForm();
            m_bSalirSinPreguntar = false;
        }


        public WFOtrasSalidas(long default_tipodocto) : this()
        {
            m_default_tipodocto = default_tipodocto;
        }

        private void ResetearVariablesForm()
        {
            m_estadoTransaccion = (int)estadoTransaccion.e_SinIniciar;
            m_Docto = new CDOCTOBE();
            m_Caja = new CCAJABE();
            m_Docto.ITIPODOCTOID = m_default_tipodocto;//DBValues._DOCTO_TIPO_OTRASENTRADAS;/*DBValues._DOCTO_TIPO_VENTA*/;
            m_dMontoTransaccion = 0;
            m_dSumaImporte = 0;
            m_dMontoIva = 0;
            m_dDescuento = 0;
            m_sucursalTID = 0;
            RefrescarEstatusBotones();

            m_tipoTransaccion = m_default_tipodocto == DBValues._DOCTO_TIPO_OTRASSALIDAS ? tipoTransaccionV.t_venta : tipoTransaccionV.t_compra;
            m_DoctoRef = null;
        }





        private void WFPuntoDeTransaccion_Load(object sender, EventArgs e)
        {

            if (!ChecarPermisos())
            {
                this.Close();
                return;
            }

            CUSUARIOSD usuariosD = new CUSUARIOSD();


            if (bEstaConfiguradoParaPiezasyCajas())
            {
                formatCajasBotellasPiezas(true);
                //gridPVDataGridView.Columns["GVCANTIDAD"].ReadOnly = true;

            }
            else
            {
                formatCajasBotellasPiezas(false);
            }

            if (usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_CAMBIARPRECIO_OTRASSALIDAS, null))
            {
                m_bPermisoCambiarPrecio = true;
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
                this.CBOrigenFiscal.Enabled = false;
                this.CBOrigenFiscal.SelectedIndex = 0;
            }


            if (CurrentUserID.CurrentParameters.IAUTOCOMPPROD.Equals("S"))
            {
                this.TBCommandLine.AutoCompleteMode = AutoCompleteMode.Suggest;
                this.TBCommandLine.AutoCompleteSource = AutoCompleteSource.CustomSource;
                this.TBCommandLine.AutoCompleteCustomSource = CurrentUserID.GetAutoSourceCollectionFromTable();
            }

            /*this.ComboProveedor.llenarDatos();
            this.ComboProveedor.SelectedIndex = -1;*/
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
            this.gridPVTableAdapter.Fill(this.dSInventarioFisico3.GRIDPV, (int)m_Docto.IID);
            FormatGrid();

            if (gridPVDataGridView.Rows.Count > 0)
                gridPVDataGridView.CurrentCell = gridPVDataGridView.Rows[gridPVDataGridView.Rows.Count - 1].Cells["GVCANTIDAD"];


            GetTotalesPagosTransaccion();
            RefreshTotalesTransaccion();
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

            foreach (iPos.Inventario.DSInventarioFisico3.GRIDPVRow dr in this.dSInventarioFisico3.GRIDPV.Rows)
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
        }


        public void RefreshTotalesTransaccion()
        {
            this.TBPagosTotalTransaccionBig.Text = m_dMontoTransaccion.ToString("N2");
            this.TBTotal.Text = m_dMontoTransaccion.ToString("N2");
            this.TBSumaTotal.Text = m_dSumaImporte.ToString("N2");
            this.TBIva.Text = m_dMontoIva.ToString("N2");
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

        }

        #endregion

        #region Seguridad y Validaciones Iniciales
        public bool ChecarFechaDelSistema()
        {

            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
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
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            CorteAbrir corteForm_;
            DateTime fechaCorte = DateTime.MinValue;
            if (!pvd.HayCorteActivo(ref fechaCorte, iPos.CurrentUserID.CurrentUser.IID))
            {
                corteForm_ = new CorteAbrir();
                corteForm_.ShowDialog();
                corteForm_.Dispose();
                GC.SuppressFinalize(corteForm_);
            }
            else
            {
                TimeSpan ts = DateTime.Now - fechaCorte/*((fechaCorte == null) ? DateTime.MinValue : fechaCorte)*/;
                if (fechaCorte != null && fechaCorte < DateTime.Today && ts.Hours > 6)
                {

                    MessageBox.Show("Se tiene abierto un corte de una fecha pasada porfavor cierrelo antes de continuar");
                    CorteCerrar cc_ = new CorteCerrar();
                    cc_.ShowDialog();
                    bool bCorteCerrado = cc_.m_bCorteCerrado;
                    cc_.Dispose();
                    GC.SuppressFinalize(cc_);

                    if (!bCorteCerrado)
                    {
                        m_bSalirSinPreguntar = true;
                        this.Close();
                    }
                    else
                    {
                        corteForm_ = new CorteAbrir();
                        corteForm_.ShowDialog();
                        corteForm_.Dispose();
                        GC.SuppressFinalize(corteForm_);
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
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            CDOCTOBE doctoBuffer = pvd.ObtenerVenta(m_Docto, null);

            if (pvd.IComentario == "" || pvd.IComentario == null)
            {
                m_Docto = doctoBuffer;
                m_dMontoTransaccion = m_Docto.ITOTAL;
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
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
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






        private void DecifrarComando(string texto, ref CPRODUCTOBE prod, ref Decimal cantidad, ref CPuntoDeVentaD pvd, ref Decimal costo, ref Decimal descuento)
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


            descuento = 0.0m;


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
            return ProcessCommand(P_MOVTOID);
        }

       


        private bool ProcessCommand(long? P_MOVTOID)
        {

            if (m_manejaAlmacen)
            {
                if (this.ALMACENComboBox.SelectedIndex < 0)
                {
                    MessageBox.Show("por favor seleccione un almacen valido de la lista ");
                    return false;
                }
            }


            if (this.TBReferencias.Text == "")
            {
                MessageBox.Show("Porfavor llena el campo de referencia");
                this.TBReferencias.Focus();
                return false;
            }

            CPRODUCTOBE prod = null;

            long? P_IDDOCTO = null;
            decimal? P_CANTIDAD = null;
            long? P_IDPRODUCTO = null;
            long? P_PERSONAID = DBValues._CLIENTEMOSTRADOR;/*long.Parse(this.ComboProveedor.SelectedValue.ToString())*/;
            string P_LOTE = "";
            long? P_USERID = iPos.CurrentUserID.CurrentUser.IID;
            int? US_SUPERVISORID = null;
            int? ALMACENID = m_manejaAlmacen ? int.Parse(this.ALMACENComboBox.SelectedValue.ToString()) : (int)DBValues._DOCTO_ALMACEN_DEFAULT;/*CurrentUserID.CurrentUser.IUS_ALMACENID*/ ;
            long? SUCURSALID = CurrentUserID.CurrentParameters.ISUCURSALID;
            decimal? P_PRECIO = null;
            decimal? P_DESCUENTO = null;
            DateTime P_FECHAVENCE = DateTime.MinValue;
            Decimal cantidad = 0;
            long? SUCURSALTID = 0;
            long? ALMACENTID = 0;

            Decimal precio = 0;
            Decimal descuento = 0;
            string P_REFERENCIA = TBReferencias.Text;
            string P_REFERENCIAS = TBObservaciones.Text;
            DateTime P_DOCTO_FECHA = DTPFecha.Value;
            DateTime P_DOCTO_FECHAVENCE = DTPFecha.Value; //DTPFechaVence.Value;

            long? P_TIPODIFERENCIAINVENTARIOID = 0;

            long? P_MOVTOREFID = null;

            string strDescripcionComodin1 = "", strDescripcionComodin2 = "", strDescripcionComodin3 = "";
            bool bHayDescripcionComodin = false;



            bool bResult = true;
            long? P_DOCTOREFID = null;
            if (this.m_DoctoRef != null)
            {
                P_DOCTOREFID = this.m_DoctoRef.IID;
            }





            CPuntoDeVentaD pvd = new CPuntoDeVentaD();


            if (TBCommandLine.Text == "")
            {
                SeleccionarProducto();
                RefrescarEstatusBotones();
                return false;
            }

            DecifrarComando(TBCommandLine.Text, ref prod, ref  cantidad, ref pvd, ref precio, ref descuento);
            //P_CANTIDAD = (cantidad != 0) ? cantidad : 1;
            P_CANTIDAD = (cantidad != 0 || (P_MOVTOID.HasValue && P_MOVTOID.Value != 0)) ? cantidad : 1;
            P_PRECIO = (precio == 0) ? (decimal)-0.01 : precio;
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


            ArrayList asignacionesLote = new ArrayList();
            if (prod.IMANEJALOTE == "S" && P_CANTIDAD > 0)
            {
                //condiciones para preguntar lote
                //int num_registros_inv = 0;
                //decimal cantidad_inv = 0;
                //string lote_inv = "";
                DateTime fechaVence = DateTime.MinValue;


                    //condiciones para preguntar lote
                    int num_registros_inv = 0;
                    decimal cantidad_inv = 0;
                    string lote_inv = "";
                    long? ALMACENEXISTENCIA = null;
                    if( m_manejaAlmacen )
                        ALMACENEXISTENCIA = long.Parse(this.ALMACENComboBox.SelectedValue.ToString());

                    pvd.GetExistencia(prod, ref num_registros_inv, ref cantidad_inv, ref lote_inv, ref fechaVence, ALMACENEXISTENCIA, null);
                    if (num_registros_inv > 1)
                    {
                        WFPreguntaLote pl_ = new WFPreguntaLote(prod, P_CANTIDAD.Value, P_IDDOCTO.HasValue ? P_IDDOCTO.Value : 0, ALMACENEXISTENCIA);
                        pl_.ShowDialog();
                        P_LOTE = pl_.lote;
                        P_FECHAVENCE = pl_.fechaVence;
                        ArrayList asignaciones_ = pl_.asignaciones;
                        pl_.Dispose();
                        GC.SuppressFinalize(pl_);

                    if (asignaciones_.Count <= 0)
                        {

                            RefrescarEstatusBotones();
                            MessageBox.Show("No se asignaron los lotes");
                            return false;
                        }
                        asignacionesLote = asignaciones_;
                    }
                    else if (num_registros_inv == 1)
                    {
                        P_LOTE = lote_inv;
                        P_FECHAVENCE = fechaVence;

                    }
                
            }


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


            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();



                // Cuando es por lotes se tienen que poner varios
                int iRegLote = 0;
                CAsignacionLote bufferLote;
                if (asignacionesLote.Count > 1)
                {
                    while (asignacionesLote.Count - 1 > iRegLote)
                    {
                        bufferLote = (CAsignacionLote)asignacionesLote[iRegLote];
                        P_LOTE = bufferLote.lote;
                        P_FECHAVENCE = bufferLote.fechaVence;


                        if (!pvd.EjecutarAddMOVTO(ref P_IDDOCTO, bufferLote.cantidad, P_IDPRODUCTO, P_PERSONAID, P_USERID, P_LOTE, US_SUPERVISORID, ALMACENID, SUCURSALID, P_FECHAVENCE, m_Docto.ITIPODOCTOID, SUCURSALTID, ALMACENTID, "N", P_TIPODIFERENCIAINVENTARIOID, P_PRECIO, P_DESCUENTO, iPos.CurrentUserID.CurrentCompania.IEM_CAJA, P_DOCTOREFID, ref P_MOVTOID, P_MOVTOREFID, strDescripcionComodin1, strDescripcionComodin2, strDescripcionComodin3, P_REFERENCIA, null, null, null, P_REFERENCIAS, fTrans))
                        {
                            fTrans.Rollback();
                            fConn.Close();
                            RefrescarEstatusBotones();
                            MessageBox.Show(pvd.IComentario);
                            return false;
                        }
                        P_MOVTOID = null;
                        iRegLote++;
                    }

                    bufferLote = (CAsignacionLote)asignacionesLote[iRegLote];
                    P_LOTE = bufferLote.lote;
                    P_FECHAVENCE = bufferLote.fechaVence;
                    P_CANTIDAD = bufferLote.cantidad;

                }
                else if (asignacionesLote.Count == 1)
                {
                    bufferLote = (CAsignacionLote)asignacionesLote[iRegLote];
                    P_LOTE = bufferLote.lote;
                    P_FECHAVENCE = bufferLote.fechaVence;
                    P_CANTIDAD = bufferLote.cantidad;
                }


                if (pvd.EjecutarAddMOVTO(ref P_IDDOCTO, P_CANTIDAD, P_IDPRODUCTO, P_PERSONAID, P_USERID, P_LOTE, US_SUPERVISORID, ALMACENID, SUCURSALID, P_FECHAVENCE, m_Docto.ITIPODOCTOID, SUCURSALTID, ALMACENTID, "N", P_TIPODIFERENCIAINVENTARIOID, P_PRECIO, P_DESCUENTO, iPos.CurrentUserID.CurrentCompania.IEM_CAJA, P_DOCTOREFID, ref P_MOVTOID, P_MOVTOREFID, strDescripcionComodin1, strDescripcionComodin2, strDescripcionComodin3, P_REFERENCIA, null,null,null,P_REFERENCIAS, fTrans))
                {
                    fTrans.Commit();
                    ObtenerDoctoDeBD((long)P_IDDOCTO);

                    RefrescarGridTransaccions();
                    FormatGrid();
                    GetTotalesPagosTransaccion();
                    RefreshTotalesTransaccion();
                    RefreshNumTransaccion();
                    //TBMensajesUser.Text = "";//"Exito"
                    //TBMensajesUser.BackColor = Color.Green;
                    this.TBCommandLine.Text = "";
                    this.TBCantidad.Text = bEstaConfiguradoParaPiezasyCajas() ? "0" : "1";
                    this.TBCajas.Text = "";
                    this.TBCosto.Text = "";
                    this.TBStatus.Text = "";

                    this.LBIva.Text = "0.0";

                    this.TBCommandLine.Focus();

                    if (m_manejaAlmacen)
                    {
                        this.ALMACENComboBox.Enabled = false;
                    }

                }
                else
                {
                    bResult = false;
                    fTrans.Rollback();
                    MessageBox.Show(pvd.IComentario);
                    fConn.Close();
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



                case DBValues._DOCTO_TIPO_OTRASSALIDAS:
                    {
                        long statusDoctoId = m_Docto.IESTATUSDOCTOID;


                        CPuntoDeVentaD pvd = new CPuntoDeVentaD();
                        pvd.CancelarVenta(m_Docto, CurrentUserID.CurrentUser, null);
                        if (pvd.IComentario == "" || pvd.IComentario == null)
                        {

                            HiloExistencias._IFLAGENVIAREXISTENCIASEVENTOS++;
                            MessageBox.Show("Transaccion cancelada");

                            if (statusDoctoId != DBValues._DOCTO_ESTATUS_BORRADOR)
                            {
                                PosPrinter.ImprimirTicket(m_Docto.IID, Ticket._OPCION_IMPRESION_COMPRA);
                            }

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
            RefreshTotalesTransaccion();
            RefreshNumTransaccion();
            this.dSInventarioFisico3.GRIDPV.Clear();
            FormatGrid();
            this.TBCommandLine.Text = "";
            this.TBCosto.Text = "";
            this.TBCantidad.Text = bEstaConfiguradoParaPiezasyCajas() ? "0" : "1";
            this.TBCajas.Text = "";
            this.TBReferencias.Text = "";
            this.REFERENCIASLabel.Text = "";
            this.TBObservaciones.Text = "";
            this.TBStatus.Text = "";

            this.LBIva.Text = "0.0";

            //this.TBMensajesUser.Text = "";
            //this.TBMensajesUser.BackColor = Color.Green;
            this.LBOperacion.Text = m_default_tipodocto == DBValues._DOCTO_TIPO_OTRASSALIDAS ? "O. Salidas" : "O. Entradas";
            this.LBCliente.Text = "MOSTRADOR";
            this.LBTransaccion.Text = "...";
            LimpiarCurrentItemDisplay();
            this.TBCommandLine.Focus();
            this.TBCommandLine.Enabled = true;

            
            this.TBCosto.ReadOnly = !this.m_bPermisoCambiarPrecio;
            this.TBCantidad.Enabled = true;


            this.TBReferencias.Enabled = true;
            this.TBObservaciones.Enabled = true;


            this.DTPFecha.Enabled = false;
            this.DTPFecha.Value = DateTime.Today;


            this.BTEnviar.Enabled = true;


            RefrescarEstatusBotones();



            if (CurrentUserID.CurrentParameters.IDIVIDIR_REM_FACT.Equals("N"))
            {
                this.CBOrigenFiscal.Enabled = false;
                this.CBOrigenFiscal.SelectedIndex = 0;
            }
            else
            {
                this.CBOrigenFiscal.Enabled = true;
                this.CBOrigenFiscal.SelectedIndex = -1;
            }


            //this.ComboProveedor.SelectedIndex = -1;

            this.BTCotizacion.Visible = false;
            lbTotalPiezas.Text = "0.00";


            if (m_manejaAlmacen)
            {
               // this.ALMACENComboBox.Enabled = true;
               // this.ALMACENComboBox.SelectedIndex = -1;
                SetDefaultAlmacenEstatus();
            }
        }




        private void NuevoRegistro()
        {
            if ((!(bool)m_Docto.isnull["IID"])
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
            if (!(bool)m_Docto.isnull["IID"]
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
            WFLOOKUPVENTAS look = new WFLOOKUPVENTAS((int)DBValues._DOCTO_ESTATUS_BORRADOR, (int)DBValues._DOCTO_TIPO_OTRASSALIDAS, true);
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
                {
                    string strBuffer = "";
                    this.TBReferencias.DbValue = m_Docto.IREFERENCIA;
                    this.TBReferencias.MostrarErrores = false;
                    this.TBReferencias.MValidarEntrada(out strBuffer, 1);
                    this.TBReferencias.MostrarErrores = true;
                }
                else
                {
                    this.TBReferencias.Text = "";
                }

                if (!(bool)m_Docto.isnull["IREFERENCIAS"])
                    this.TBObservaciones.Text = m_Docto.IREFERENCIAS;


                if (!(bool)m_Docto.isnull["IFECHA"])
                    this.DTPFecha.Value = m_Docto.IFECHA;



                /*if (!(bool)m_Docto.isnull["IPERSONAID"])
                {
                    this.ComboProveedor.SelectedValue = m_Docto.IPERSONAID;
                }*/

                


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

                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_OTRASSALIDAS)
                {
                    this.LBOperacion.Text = "Otras salidas";
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


       
       

        #endregion

        #region Pagar Cerrar Transaccion

        private void BTCerrarTransaccion_Click(object sender, EventArgs e)
        {
            if (m_estadoTransaccion == (int)estadoTransaccion.e_Cerrada || m_estadoTransaccion == (int)estadoTransaccion.e_Cancelada)
                return;

            PagarBasico();

        }


        private void PagarBasico()
        {




                if (!Precierre())
                    return;

                if (m_Docto != null && m_Docto.IID > 0)
                {
                    ObtenerDoctoDeBD(m_Docto.IID);
                    ObtenerCaja();

                    this.CerrarTransaccion();

                    this.Focus();
                }
           


        }
        private void CerrarTransaccion()
        {

            string strComentario = "";

            CPuntoDeVentaD pv = new CPuntoDeVentaD();

            pv.CerrarVenta(m_Docto, null);
            strComentario = pv.IComentario;


            if (strComentario == "" || strComentario == null)
            {
                //ImprimirTicket(false);
                PosPrinter.ImprimirTicket(m_Docto.IID, Ticket._OPCION_IMPRESION_COMPRA);

                
                IrANuevaTransaccion();
                HiloExistencias._IFLAGENVIAREXISTENCIASEVENTOS++;
                this.TBCommandLine.Focus();
            }
            else
            {
                MessageBox.Show("ERRORES: " + strComentario.Replace("%", "\n"));
            }
        }





        private bool Precierre()
        {

            if (m_tipoTransaccion == tipoTransaccionV.t_venta)
            {

                m_Docto.IORIGENFISCALID =  DBValues._ORIGENFISCAL_REMISIONADO ;
                m_Docto.IREFERENCIA = this.TBReferencias.Text;
                m_Docto.IREFERENCIAS = this.TBObservaciones.Text;
                m_Docto.IFECHAFACTURA = this.DTPFecha.Value;
                m_Docto.IVENCE = this.DTPFecha.Value;


                 CPuntoDeVentaD pvd = new CPuntoDeVentaD();
                int errorCode = 0;

                m_Docto.IVENDEDORID = CurrentUserID.CurrentUser.IID;
                if (!pvd.VENTA_PRECIERRE(m_Docto, null, ref errorCode))
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

            return false;
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
                    AbrirTransaccionsCerradasYDevoluciones(0);
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

            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            DateTime fechaCorte = DateTime.MinValue;
            if (!pvd.HayCorteActivo(ref fechaCorte, iPos.CurrentUserID.CurrentUser.IID))
                return;

            if (!(bool)m_Docto.isnull["IID"]
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
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
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
        private void AbrirTransaccionsCerradasYDevoluciones(int iDoctoSelectedId)
        {
            IrANuevaTransaccion();



            if (iDoctoSelectedId == 0)
            {
                WFLOOKUPVENTAS look = new WFLOOKUPVENTAS((int)DBValues._DOCTO_ESTATUS_COMPLETO, (int)DBValues._DOCTO_TIPO_OTRASSALIDAS, true);
                look.ShowDialog();

                DataRow dr = look.m_rtnDataRow;

                look.Dispose();
                GC.SuppressFinalize(look);

                if (dr != null)
                {
                    m_Docto.IID = int.Parse(dr[0].ToString());
                }
                else
                {
                    return;
                }
            }
            else
            {
                m_Docto.IID = iDoctoSelectedId;
            }



                CDOCTOD vData = new CDOCTOD();
                m_Docto = vData.seleccionarDOCTO(m_Docto, null);
                RefrescarGridTransaccions();
                this.gridPVDataGridView.BackgroundColor = Color.Gainsboro;
                this.gridPVDataGridView.DefaultCellStyle.BackColor = Color.Gainsboro;
                this.TBCommandLine.Enabled = false;

                this.TBCosto.ReadOnly = false;
                this.TBCantidad.Enabled = false;



                this.DTPFecha.Enabled = false;
                this.BTEnviar.Enabled = false;

                if (m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_CANCELADA || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_CANCELACION)
                {
                    m_estadoTransaccion = (int)estadoTransaccion.e_Cancelada;
                }
                else
                {
                    if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_OTRASSALIDAS)
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


                if (!(bool)m_Docto.isnull["IREFERENCIA"])
                {
                    string strBuffer = "";
                    this.TBReferencias.DbValue = m_Docto.IREFERENCIA;
                    this.TBReferencias.MostrarErrores = false;
                    this.TBReferencias.MValidarEntrada(out strBuffer, 1);
                    this.TBReferencias.MostrarErrores = true;
                }
                else
                {
                    this.TBReferencias.Text = "";
                }

                if (!(bool)m_Docto.isnull["IREFERENCIAS"])
                    this.TBObservaciones.Text = m_Docto.IREFERENCIAS;


                if (!(bool)m_Docto.isnull["IFECHA"])
                    this.DTPFecha.Value = m_Docto.IFECHA;




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


            
        }

        private void BTAbrirCerradasYDevo_Click(object sender, EventArgs e)
        {
            AbrirTransaccionsCerradasYDevoluciones(0);
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


                CPuntoDeVentaD pvd = new CPuntoDeVentaD();
                decimal cantidad = 0.0m;
                bool bPreguntaCantidad = false;
                prod = pvd.buscarPRODUCTOSPV(texto,ref cantidad, ref bPreguntaCantidad,CurrentUserID.CurrentParameters, null);
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

            if ((gridPVDataGridView.Columns["GVCANTIDAD"].Index != e.ColumnIndex && gridPVDataGridView.Columns["PRECIOUNIDAD"].Index != e.ColumnIndex && gridPVDataGridView.Columns["DESCUENTOPORCENTAJE"].Index != e.ColumnIndex)
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
                       
                        LBIva.Text = gridPVDataGridView.Rows[e.RowIndex].Cells["TASAIVA"].Value.ToString();
                        long? P_MOVTOID = (long)gridPVDataGridView.Rows[e.RowIndex].Cells["MOVTOID"].Value;
                        if (!ProcessCommand(P_MOVTOID))
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



                        dCostoSinImpuestos = calculaPrecioSinImpuestos(dNuevoCosto, dTasaIva, dTasaIeps);

                        TBCosto.Text = dCostoSinImpuestos.ToString("0.00");
                        TBCantidad.Text = "0.00";
                        TBCajas.Text = "0.00";
                        LBIva.Text = gridPVDataGridView.Rows[e.RowIndex].Cells["TASAIVA"].Value.ToString();



                        long? P_MOVTOID = (long)gridPVDataGridView.Rows[e.RowIndex].Cells["MOVTOID"].Value;
                        if (!ProcessCommand( P_MOVTOID))
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
                        LBIva.Text = gridPVDataGridView.Rows[e.RowIndex].Cells["TASAIVA"].Value.ToString();



                        long? P_MOVTOID = (long)gridPVDataGridView.Rows[e.RowIndex].Cells["MOVTOID"].Value;
                        if (!ProcessCommand(P_MOVTOID))
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


                    this.TBCantidad.Text = bEstaConfiguradoParaPiezasyCajas() ? "0" : "1";
                    this.TBCajas.Text = "0.0";

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

            if (TBReferencias.Text.Trim().Length == 0 )
            {
                MessageBox.Show("Antes de editar desde el grid, porfavor llene el campo de referencia");
                e.Cancel = true;
                return;
            }


            if (gridPVDataGridView.Columns["PRECIOUNIDAD"].Index == e.ColumnIndex && m_bPermisoCambiarPrecio)
            {
                MessageBox.Show("No tiene permisos para cambiar el precio unidad");
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
                    PosPrinter.ImprimirTicket(m_Docto.IID, Ticket._OPCION_IMPRESION_COMPRA);
                }
            }
        }

        
       /* private void ModoOtrasEntradas()
        {

            NuevoRegistro();

            m_Docto.ITIPODOCTOID = DBValues._DOCTO_TIPO_OTRASENTRADAS;

            this.LBOperacion.Text = "Orden de compra";
            this.BTPasarANueva.Enabled = true;
        }*/


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
                                
                                LBIva.Text = gridPVDataGridView.Rows[e.RowIndex].Cells["TASAIVA"].Value.ToString();
                                long? P_MOVTOID = (long)gridPVDataGridView.Rows[e.RowIndex].Cells["MOVTOID"].Value;


                                bool bRes = ProcessCommand(P_MOVTOID);

                                if (!bRes)
                                {
                                    TBCommandLine.Text = "";
                                    TBCosto.Text = "";
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


        private void DescripcionesDeProductoEnDataSet(long productoId, ref string desc1, ref string desc2, ref string desc3)
        {
            /*foreach (iPos.Inventario.DSInventarioFisico3.GRIDPVRow dr in dSEntradas.GridPV)
            {
                if (dr. == productoId)
                {
                    desc1 = dr.MOVTODESCRIPCION1;
                    desc2 = dr.MOVTODESCRIPCION2;
                    desc3 = dr.MOVTODESCRIPCION3;
                    break;
                }

            }*/
        }

        private void btnNoTransaccion_Click(object sender, EventArgs e)
        {
            WFSelectOtrosTransByFolio wf = new WFSelectOtrosTransByFolio(DBValues._DOCTO_TIPO_OTRASSALIDAS);
            wf.ShowDialog();
            string strSucDest = "";

            if (wf.m_selectedDocto != null && wf.m_selectedDocto.IID > 0)
            {
                
                AbrirTransaccionsCerradasYDevoluciones((int)wf.m_selectedDocto.IID);
            }
            wf.Dispose();
            GC.SuppressFinalize(wf);
        }

       

    }
}