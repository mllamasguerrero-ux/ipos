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

    public partial class WFDevolucionCompras : IposForm
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

        long m_PersonaId = 1;
        bool m_bEntroAEdicion = false;

        bool m_bPermisoDevolverSinCompra = false;

        bool m_manejaAlmacen = false;

        #endregion

        #region Apariencia e Inicializacion

        public WFDevolucionCompras()
        {
            InitializeComponent();
            ResetearVariablesForm();
            m_bSalirSinPreguntar = false;
        }

        private void ResetearVariablesForm()
        {
            m_estadoTransaccion = (int)estadoTransaccion.e_SinIniciar;
            m_Docto = new CDOCTOBE();
            m_Caja = new CCAJABE();
            m_Docto.ITIPODOCTOID = DBValues._DOCTO_TIPO_COMPRA;/*DBValues._DOCTO_TIPO_VENTA*/;
            m_dMontoTransaccion = 0;
            m_dSumaImporte = 0;
            m_dMontoIva = 0;
            m_dDescuento = 0;
            m_sucursalTID = 0;
            RefrescarEstatusBotones();

            m_tipoTransaccion = tipoTransaccionV.t_compradevolucion;
            m_DoctoRef = null;
        }


        private void MostrarVendedorYTurno()
        {
            //CCAJAD cajaD = new CCAJAD();
            //string strTurnoActual = cajaD.ObtenerNombreTurnoDeCaja(iPos.CurrentUserID.CurrentCompania.IEM_CAJA, null);
            //this.LBAtendiendo.Text = /*"USTED ESTA SIENDO ATENDIDO POR : " + iPos.CurrentUserID.CurrentUser.INOMBRE + " Turno " +*/ strTurnoActual;
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

            this.LBVendedor.Text = iPos.CurrentUserID.CurrentUser.INOMBRE;
            this.LBSucursal.Text = iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO;
            this.LBFecha.Text = DateTime.Today.ToString("dd/MM/yyyy");
            MostrarVendedorYTurno();
            this.LBCliente.Text = "";
            this.gridPVTableAdapter.SelectCommandTimeout = 100;
            m_printer = Ticket.GetReceiptPrinter();

            if (!ChecarFechaDelSistema())
                return;

            ChecarCorteActivo();
            ObtenerCaja();
            FormatTotalPiezas();
            //IrANuevaTransaccion();
            IrAEstadoInicial();
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

                    if (!(bool)CurrentUserID.CurrentUser.isnull["IALMACENID"])
                        this.ALMACENComboBox.SelectedDataValue = CurrentUserID.CurrentUser.IALMACENID;
                    else
                        this.ALMACENComboBox.SelectedDataValue = DBValues._ALMACEN_DEFAULT;

                    if (usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_CAMBIARDEALMACEN, null))
                        this.ALMACENComboBox.Enabled = true;
                    else
                        this.ALMACENComboBox.Enabled = false;

                }
                catch
                {
                }
            }

            this.TIPODIFERENCIAINVENTARIOIDComboBox.llenarDatos();
            this.TIPODIFERENCIAINVENTARIOIDComboBox.SelectedIndex = -1;

            //this.ComboProveedor.llenarDatos();
        }


        private void WFPuntoDeTransaccion_Shown(object sender, EventArgs e)
        {
            this.TBCommandLine.Focus();
        }


        public void FormatGrid()
        {

            this.gridPVDataGridView.BackgroundColor = Color.White;
            this.gridPVDataGridView.DefaultCellStyle.BackColor = Color.White;

            this.gET_VENTA_DEVOLUCION_REFDataGridView.BackgroundColor = Color.White;
            this.gET_VENTA_DEVOLUCION_REFDataGridView.DefaultCellStyle.BackColor = Color.White;
            this.gET_VENTA_DEVOLUCION_REFDataGridView.ReadOnly = false;

        }


        private void RefrescarGridTransaccions()
        {

            RefrescarGridSecundario();

            this.gridPVTableAdapter.Fill(this.dSEntradas.GridPV, (int)m_Docto.IID);
            FormatGrid();
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
        }


        private void LimpiarDatosDePersona()
        {

            lbClieCiudad.Text = "";
            lbClieColonia.Text = "";
            lbClieCP.Text = "";
            lbClieDom.Text = "";
            lbClieEstado.Text = "";
            lbClieNombre.Text = "";
            lbClieRFC.Text = "";
            lbClieTel.Text = "";
            LBCliente.Text = "";
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
                //this.BTCancelarTransaccion.Enabled = true;
                this.BTCerrarTransaccion.Enabled = true;

            }
            else
            {
                this.BTPasarANueva.Enabled = true;
                //this.BTCancelarTransaccion.Enabled = false;
                //this.BTCancelarTransaccion.Enabled = true;
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
            int iMenu = int.Parse(DBValues._MENUID_PUNTODEVENTA.ToString());
            if (!personaD.UsuarioTieneDerechoAMenu(CurrentUserID.CurrentUser.IID, iMenu, null))
            {
                MessageBox.Show("El usuario no tiene derecho a este form");
                return false;
            }

            CUSUARIOSD usuariosD = new CUSUARIOSD();
            if (usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_DEVOLUCIONSINCOMPRA, null))
            {
                m_bPermisoDevolverSinCompra = true;
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

            if (CurrentUserID.CurrentParameters.IHABILITAR_IMPEXP_AUT == DBValues._DB_BOOLVALUE_SI)
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
       

        private void ObtenerDoctoDeBD(long lDoctoID, FbTransaction st)
        {
            CDOCTOD vDocto = new CDOCTOD();
            m_Docto = new CDOCTOBE();
            m_Docto.IID = lDoctoID;
            m_Docto = vDocto.seleccionarDOCTO(m_Docto, st);
        }

        public void GetTotalesPagosTransaccion()
        {
            CComprasD pvd = new CComprasD();
            CDOCTOBE doctoBuffer = pvd.ObtenerTransaccion(m_Docto, null);

            if (pvd.IComentario == "" || pvd.IComentario == null)
            {
                m_Docto = doctoBuffer;
                m_dMontoTransaccion = m_Docto.ITOTAL;
                m_dSumaImporte = m_Docto.ISUBTOTAL;
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
            ArrayList splitChars = new ArrayList();
            splitChars.Add('*');
            splitChars.Add('%');
            string commandLine = texto;
            ArrayList commandElemts = SplitCommandLine(commandLine, splitChars);
            //int prodIndex = -1, cantIndex = -1, /*descIndex = -1,*/ contIndex;

            //int contIndex = 0;

            BuscarProducto(ref prod);

            costo = Decimal.Parse(this.TBCosto.Text.ToString());
            cantidad = Decimal.Parse(this.TBCantidad.Text.ToString());
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
            long? P_MOVTOREFID = null;
            return ProcessCommand(P_MOVTOID, P_MOVTOREFID);
        }

        private bool ProcessCommandRef(long? P_MOVTOREFID)
        {
            long? P_MOVTOID = null;
            return ProcessCommand(P_MOVTOID, P_MOVTOREFID);
        }

        private bool ProcessCommand(long? P_MOVTOID)
        {
            long? P_MOVTOREFID = null;
            return ProcessCommand(P_MOVTOID, P_MOVTOREFID);
        }

        private bool ProcessCommand(long? P_MOVTOID, long? P_MOVTOREFID)
        {
            if (m_manejaAlmacen)
            {
                if (this.ALMACENComboBox.SelectedIndex < 0)
                {
                    MessageBox.Show("por favor seleccione un almacen valido de la lista ");
                    return false;
                }
            }


            CPRODUCTOBE prod = null;

            long? P_IDDOCTO = null;
            decimal? P_CANTIDAD = null;
            long? P_IDPRODUCTO = null;
            long? P_PERSONAID = this.m_PersonaId;//long.Parse(this.ComboProveedor.SelectedValue.ToString());
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

            long? P_TIPODIFERENCIAINVENTARIOID = this.TIPODIFERENCIAINVENTARIOIDComboBox.SelectedValue != null ? long.Parse(this.TIPODIFERENCIAINVENTARIOIDComboBox.SelectedValue.ToString()) : -1;

            bool bResult = true;
            long? P_DOCTOREFID = null;
            bool bEsDevoSinCompra = false;
            if (this.m_DoctoRef != null)
            {
                if (!(bool)this.m_DoctoRef.isnull["IID"])
                {
                    P_DOCTOREFID = this.m_DoctoRef.IID;
                }
                else
                {
                    bEsDevoSinCompra = true;
                }
            }
            else
            {
                bEsDevoSinCompra = true;
            }

            if (bEsDevoSinCompra && !m_bPermisoDevolverSinCompra)
            {
                MessageBox.Show("No tiene derecho para hacer una devolucion sin una compra asociada");
                return false;
            }



            if (this.TBReferencias.Text == "")
            {
                MessageBox.Show("Porfavor llena el campo de referencia");
                this.TBReferencias.Focus();
                return false;
            }

            if (P_TIPODIFERENCIAINVENTARIOID < 0)
            {
                MessageBox.Show("Se debe de tener un motivo de devolucion seleccionado");
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
            P_CANTIDAD = (cantidad != 0) ? cantidad : 1;
            P_COSTO = costo;
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


            CDOCTOD doctoD = new CDOCTOD();

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





            if (prod.IMANEJALOTE == "S" && (!P_MOVTOREFID.HasValue || P_MOVTOREFID == 0 || P_MOVTOREFID == null) && (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL == null || !CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S")))
            {
                //condiciones para preguntar lote
                int num_registros_inv = 0;
                decimal cantidad_inv = 0;
                string lote_inv = "";
                DateTime fechaVence = DateTime.MinValue;


                long? ALMACENEXISTENCIA = null;
                if (m_manejaAlmacen)
                    ALMACENEXISTENCIA = long.Parse(this.ALMACENComboBox.SelectedValue.ToString());

                pvd.GetExistencia(prod, ref num_registros_inv, ref cantidad_inv, ref lote_inv, ref fechaVence, ALMACENEXISTENCIA, null);
                if (num_registros_inv > 1)
                {
                    WFPreguntaLote pl = new WFPreguntaLote(prod, P_CANTIDAD.Value, P_IDDOCTO.HasValue ? P_IDDOCTO.Value : 0, ALMACENEXISTENCIA);
                    pl.ShowDialog();
                    P_LOTE = pl.lote;
                    P_FECHAVENCE = pl.fechaVence;
                    pl.Dispose();
                    GC.SuppressFinalize(pl);
                }
                else if (num_registros_inv == 1)
                {
                    P_LOTE = lote_inv;
                    P_FECHAVENCE = fechaVence;

                }
            }

            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();

                if (pvd.EjecutarAddMOVTO(ref P_IDDOCTO, P_CANTIDAD, P_IDPRODUCTO, P_PERSONAID, P_USERID, P_LOTE, US_SUPERVISORID, ALMACENID, SUCURSALID, P_FECHAVENCE, m_Docto.ITIPODOCTOID, SUCURSALTID, ALMACENTID, "N", P_TIPODIFERENCIAINVENTARIOID, P_COSTO, P_REFERENCIA, P_REFERENCIAS, P_DOCTO_FECHA, P_DOCTO_FECHAVENCE, P_DESCUENTO, iPos.CurrentUserID.CurrentCompania.IEM_CAJA, P_DOCTOREFID, ref P_MOVTOID, P_MOVTOREFID,null, null, null, null, fTrans))
                {

                    ObtenerDoctoDeBD((long)P_IDDOCTO, fTrans);

                    if (m_Docto.ITIPODIFERENCIAINVENTARIOID != P_TIPODIFERENCIAINVENTARIOID.Value)
                    {
                        m_Docto.ITIPODIFERENCIAINVENTARIOID = P_TIPODIFERENCIAINVENTARIOID.Value;
                        if (!doctoD.CambiarTipoDiferenciaInventario(m_Docto, fTrans))
                        {

                            bResult = false;
                            fTrans.Rollback();
                            MessageBox.Show(doctoD.IComentario);
                            return false;
                        }
                    }

                    fTrans.Commit();



                    RefrescarGridTransaccions();
                    FormatGrid();
                    GetTotalesPagosTransaccion();
                    RefreshTotalesTransaccion();
                    RefreshNumTransaccion();
                    //TBMensajesUser.Text = "";//"Exito"
                    //TBMensajesUser.BackColor = Color.Green;
                    this.TBCommandLine.Text = "";
                    this.TBCantidad.Text = "";
                    this.TBCosto.Text = "";
                    this.TBDescuento.Text = "";
                    this.TBStatus.Text = "";

                    this.LBIva.Text = "0.0";

                    if (m_manejaAlmacen)
                    {
                        this.ALMACENComboBox.Enabled = false;
                    }

                    this.TBCommandLine.Focus();
                    fConn.Close();
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
            {
                IrAEstadoInicial();
                return false;
            }

            if (MessageBox.Show("Quiere cancelar la transaccion?", "Cancelar la transaccion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return false;


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


            switch (m_Docto.ITIPODOCTOID)
            {

                case DBValues._DOCTO_TIPO_COMPRA:
                    {
                        long statusDoctoId = m_Docto.IESTATUSDOCTOID;
                        pvd.CancelarTransaccion(m_Docto, CurrentUserID.CurrentUser.IID, null);
                        if (pvd.IComentario == "" || pvd.IComentario == null)
                        {

                            HiloExistencias._IFLAGENVIAREXISTENCIASEVENTOS++;
                            MessageBox.Show("Transaccion cancelada");

                            if (statusDoctoId != DBValues._DOCTO_ESTATUS_BORRADOR)
                            {
                                PosPrinter.ImprimirTicket(m_Docto.IID, Ticket._OPCION_IMPRESION_COMPRA);
                            }

                            //IrANuevaTransaccion();
                            IrAEstadoInicial(); ;
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
                            //IrANuevaTransaccion();
                            IrAEstadoInicial();
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



        private void IrAEstadoInicial()
        {
            ResetearVariablesForm();
            ChecarActualizacionesPrecios();
            LimpiarTotalesPagosTransaccion();
            RefreshTotalesTransaccion();
            RefreshNumTransaccion();
            this.dSEntradas.GridPV.Clear();
            FormatGrid();
            this.dSEntradas.DETALLE_DE_PAGO.Clear();
            this.TBCommandLine.Text = "";
            this.TBCosto.Text = "";
            this.TBCantidad.Text = "";
            this.TBDescuento.Text = "";
            this.TBReferencias.Text = "";
            this.TBObservaciones.Text = "";
            this.TBStatus.Text = "";

            this.LBIva.Text = "0.0";

            this.LBOperacion.Text = "Devolución";
            this.LBCliente.Text = "";
            this.LBTransaccion.Text = "...";
            LimpiarCurrentItemDisplay();
            this.TBCommandLine.Enabled = false;


            this.TBCosto.Enabled = false;
            this.TBCantidad.Enabled = false;
            this.TBDescuento.Enabled = false;

           /* if (m_enableDescuento)
                this.TBDescuento.Enabled = true;*/

            this.TBReferencias.Enabled = false;
            this.TBObservaciones.Enabled = false;

            this.DTPFecha.Enabled = false;
            this.DTPFecha.Value = DateTime.Today;

            this.DTPFechaVence.Enabled = false;
            this.DTPFechaVence.Value = DateTime.Today;

            this.BTEnviar.Enabled = false;
            this.BTSeleccionarProducto.Enabled = false;
            this.BTDevolver.Enabled = false;
            this.BTCancelarTransaccion.Enabled = false;

            RefrescarEstatusBotones();

            this.CBOrigenFiscal.Enabled = false;
            this.CBOrigenFiscal.SelectedIndex = -1;



            this.gridPVDataGridView.BackgroundColor = Color.Gainsboro;
            this.gridPVDataGridView.DefaultCellStyle.BackColor = Color.Gainsboro;


            this.gET_VENTA_DEVOLUCION_REFDataGridView.BackgroundColor = Color.Gainsboro;
            this.gET_VENTA_DEVOLUCION_REFDataGridView.DefaultCellStyle.BackColor = Color.Gainsboro;
            this.gET_VENTA_DEVOLUCION_REFDataGridView.ReadOnly = true;


            this.dSPuntoDeVentaAux.GET_VENTA_DEVOLUCION_REF.Clear();

            LimpiarDatosDePersona();

            this.m_bEntroAEdicion = false;

            lbTotalPiezas.Text = "0.00";

            LBDeLaCompra.Text = "...";


            this.TBTransacccion.Visible = true;
            this.TBTransacccion.Text = "";


            if (m_manejaAlmacen)
            {
                this.ALMACENComboBox.Enabled = true;
                this.ALMACENComboBox.SelectedIndex = -1;
            }
        
            this.TIPODIFERENCIAINVENTARIOIDComboBox.SelectedIndex = -1;

        }


        private void habilitarTextosEdicion()
        {
            this.TBCommandLine.Enabled = true;
            this.TBCosto.Enabled = true;
            this.TBCantidad.Enabled = true;
            if (m_enableDescuento)
                this.TBDescuento.Enabled = true;

            this.TBReferencias.Enabled = true;
            this.TBObservaciones.Enabled = true;
            this.DTPFecha.Enabled = false;
            this.DTPFechaVence.Enabled = true;
            this.BTEnviar.Enabled = true;
            this.BTSeleccionarProducto.Enabled = true;
        }

        private void IrANuevaTransaccion()
        {
            ResetearVariablesForm();
            ChecarActualizacionesPrecios();
            LimpiarTotalesPagosTransaccion();
            RefreshTotalesTransaccion();
            RefreshNumTransaccion();
            this.dSEntradas.GridPV.Clear();
            FormatGrid();
            this.dSEntradas.DETALLE_DE_PAGO.Clear();
            this.TBCommandLine.Text = "";
            this.TBCosto.Text = "";
            this.TBCantidad.Text = "";
            this.TBDescuento.Text = "";
            this.TBReferencias.Text = "";
            this.TBObservaciones.Text = "";
            this.TBStatus.Text = "";
            this.LBIva.Text = "0.0";
            this.LBOperacion.Text = "Devolución";
            this.LBCliente.Text = "";
            this.LBTransaccion.Text = "...";
            LimpiarCurrentItemDisplay();
            this.TBCommandLine.Focus();


            habilitarTextosEdicion();

            this.BTDevolver.Enabled = false;
            this.BTCancelarTransaccion.Enabled = false;

            RefrescarEstatusBotones();

            this.CBOrigenFiscal.SelectedIndex = -1;

            lbTotalPiezas.Text = "0.00";

            if (m_manejaAlmacen)
            {
                this.ALMACENComboBox.Enabled = true;
                this.ALMACENComboBox.SelectedIndex = -1;
            }
            this.TIPODIFERENCIAINVENTARIOIDComboBox.SelectedIndex = -1;

        }




        private void NuevoRegistro()
        {
            if ((!(bool)m_Docto.isnull["IID"])
                && (m_estadoTransaccion != (int)estadoTransaccion.e_Cerrada && m_estadoTransaccion != (int)estadoTransaccion.e_Cancelada))
            {
                if (!CancelarTransaccionActual())
                {
                    //IrANuevaTransaccion();
                    IrAEstadoInicial();
                }

            }
            else
            {
                //IrANuevaTransaccion();
                IrAEstadoInicial();
            }
        }



        private void BTPasarANueva_Click(object sender, EventArgs e)
        {
            //NuevoRegistro();
            AbrirVentasParaDevolucion();

        }


        private void AbrirVentasParaDevolucion()
        {


            if (!(bool)m_Docto.isnull["IID"]
                && m_estadoTransaccion != (int)estadoVenta.e_Cancelada
                && m_estadoTransaccion != (int)estadoVenta.e_Cerrada)
            {

                if (!CancelarTransaccionActual() && m_bEntroAEdicion)
                {
                    MessageBox.Show("Debe cancelar o terminar de editar la transaccion actual");
                    return;
                }
            }

            IrAEstadoInicial();

            CUSUARIOSD usuariosD = new CUSUARIOSD();

            WFSeleccionParaDevolucion look = new WFSeleccionParaDevolucion((int)DBValues._DOCTO_TIPO_COMPRA, (int)DBValues._DOCTO_ESTATUS_COMPLETO, m_bPermisoDevolverSinCompra);
            look.ShowDialog();

            if (look.m_PersonaId == 0 && look.m_rtnDataRow == null)
                return;

            if (look.m_rtnDataRow == null)
                this.m_PersonaId = look.m_PersonaId;



            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                m_Docto.IID = int.Parse(dr[0].ToString());
                CDOCTOD vData = new CDOCTOD();
                m_Docto = vData.seleccionarDOCTO(m_Docto, null);

                //if (look.m_PersonaId == 0)
                    this.m_PersonaId = m_Docto.IPERSONAID;

                if ((!(bool)m_Docto.isnull["IID"])
                    && (!(m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_CANCELADA || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA_CANCELACION))
                    && (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_RECEPCIONORDEN_COMPRA))
                {
                    NuevoDevolucion();

                    m_estadoTransaccion = (int)estadoVenta.e_SinIniciar;
                }



            }
            else
            {
                m_Docto = new CDOCTOBE();
                NuevoDevolucion();
                m_estadoTransaccion = (int)estadoVenta.e_SinIniciar;

            }
            llenarDatosPersona();

        }


        #endregion

        #region Abrir Transaccions Pendientes
        private void BTAbrirTransaccion_Click(object sender, EventArgs e)
        {
            //if (!(bool)m_Docto.isnull["IID"]
            //    && m_estadoTransaccion != (int)estadoTransaccion.e_Cancelada
            //    && m_estadoTransaccion != (int)estadoTransaccion.e_Cerrada)
            //{
            //    CancelarTransaccionActual();
            //}
            AbrirTransaccion();
            RefrescarEstatusBotones();
            
        }
        private void AbrirTransaccion()
        {


            if (!(bool)m_Docto.isnull["IID"]
                && m_estadoTransaccion != (int)estadoVenta.e_Cancelada
                && m_estadoTransaccion != (int)estadoVenta.e_Cerrada)
            {

                if (!CancelarTransaccionActual() && m_bEntroAEdicion)
                {
                    MessageBox.Show("Debe cancelar o terminar de editar la transaccion actual");
                    return;
                }
            }

            //IrANuevaTransaccion();
            IrAEstadoInicial();
            //GeneralLookUp look = new GeneralLookUp("select * from VENTAS where GV_ESTATUS = '" + CVENTASD.strStatusAbierta + @"'", "VENTAS");
            /*WFLOOKUPCOMPRAS look = new WFLOOKUPCOMPRAS((int)DBValues._DOCTO_ESTATUS_BORRADOR, (int)DBValues._DOCTO_TIPO_COMPRA_DEVO);
            look.ShowDialog();*/

            WFSeleccionParaDevolucion look = new WFSeleccionParaDevolucion((int)DBValues._DOCTO_TIPO_COMPRA_DEVO, (int)DBValues._DOCTO_ESTATUS_BORRADOR, m_bPermisoDevolverSinCompra);
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);


            if (dr != null)
            {
                m_Docto.IID = int.Parse(dr[0].ToString());
                CDOCTOD vData = new CDOCTOD();
                m_Docto = vData.seleccionarDOCTO(m_Docto, null);

                if (!(bool)m_Docto.isnull["IDOCTOREFID"])
                {
                    m_DoctoRef = new CDOCTOBE();
                    m_DoctoRef.IID = m_Docto.IDOCTOREFID;
                    m_DoctoRef = vData.seleccionarDOCTO(m_DoctoRef, null);
                }
                else
                {
                    m_DoctoRef = null;
                }


                if (m_manejaAlmacen)
                {
                    this.ALMACENComboBox.Enabled = false;
                    if (!(bool)m_Docto.isnull["IALMACENID"])
                        this.ALMACENComboBox.SelectedDataValue = m_Docto.IALMACENID;
                    else
                        this.ALMACENComboBox.SelectedIndex = -1;
                }


                if (!(bool)m_Docto.isnull["ITIPODIFERENCIAINVENTARIOID"])
                    this.TIPODIFERENCIAINVENTARIOIDComboBox.SelectedDataValue = m_Docto.ITIPODIFERENCIAINVENTARIOID;
                else
                    this.TIPODIFERENCIAINVENTARIOIDComboBox.SelectedIndex = -1;

                RefrescarGridTransaccions();

                this.TBTransacccion.Visible = false;

                llenarDatosGeneralesDocto();
                habilitarTextosEdicion();
                if((bool)m_Docto.isnull["IORIGENFISCALID"] || m_Docto.IORIGENFISCALID == 1)
                    this.CBOrigenFiscal.Enabled = true;
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
                look = new LOOKPROD("", false, TipoProductoNivel.tp_hijos);
            else
                look = new LOOKPROD(strDescripcion, false, TipoProductoNivel.tp_hijos);
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
            look.Dispose();
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
                ObtenerDoctoDeBD(m_Docto.IID, null);
                ObtenerCaja();

                string esapartado = "N";


                switch (m_tipoTransaccion)
                {
                    case tipoTransaccionV.t_compradevolucion:

                        WFPagosDevoluciones wp2 = new WFPagosDevoluciones(m_Docto, m_Caja, false, 0, this.m_DoctoRef, this.m_tipoTransaccion, esapartado, false);
                            wp2.ShowDialog();
                            if (wp2.m_bPagoCompleto)
                            {

                                this.CerrarTransaccion();
                            }

                            this.Focus();
                            wp2.Dispose();
                        break;
                    default:
                        {

                            WFPagosBasico wp = new WFPagosBasico(m_Docto, m_Caja, false, 0, this.m_DoctoRef, this.m_tipoTransaccion, esapartado, null,false);
                            wp.ShowDialog();
                            if (wp.m_bPagoCompleto)
                            {

                                this.CerrarTransaccion();
                            }

                            this.Focus();
                            wp.Dispose();
                        }
                        break;
              }








            }


        }
        private void CerrarTransaccion()
        {
            CComprasD pvd = new CComprasD();
            pvd.CerrarTransaccion(m_Docto, null);
            if (pvd.IComentario == "" || pvd.IComentario == null)
            {
                //ImprimirTicket(false);
                PosPrinter.ImprimirTicket(m_Docto.IID, Ticket._OPCION_IMPRESION_COMPRA);

                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO)
                {
                    CDOCTOD vData = new CDOCTOD();
                    m_Docto = vData.seleccionarDOCTO(m_Docto, null);

                    ExportarTraslados(m_Docto.IFOLIO);
                }

                //IrANuevaTransaccion();
                IrAEstadoInicial();
                HiloExistencias._IFLAGENVIAREXISTENCIASEVENTOS++;
                this.TBCommandLine.Focus();


                this.BTAbrirCerradasYDevo.Enabled = true;
                this.BTAbrirTransaccion.Enabled = true;
            }
            else
            {
                MessageBox.Show("ERRORES: " + pvd.IComentario.Replace("%", "\n"));
            }
        }





        private bool Precierre()
        {

            if (m_tipoTransaccion == tipoTransaccionV.t_compra || m_tipoTransaccion == tipoTransaccionV.t_compradevolucion)
            {

                if (this.CBOrigenFiscal.SelectedIndex < 0)
                {

                    MessageBox.Show("Debe seleccionar el origen fiscal (facturado o remisionado) ");
                    return false;
                }
                m_Docto.IORIGENFISCALID = (this.CBOrigenFiscal.SelectedIndex == 0) ? DBValues._ORIGENFISCAL_REMISIONADO : DBValues._ORIGENFISCAL_FACTURADO;
                m_Docto.IREFERENCIA = this.TBReferencias.Text;
                m_Docto.IREFERENCIAS = this.TBObservaciones.Text;
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
                    //IrANuevaTransaccion();
                    IrAEstadoInicial();
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


            if (m_bEntroAEdicion)
            {
                MessageBox.Show("Por favor termine la edicion de la transaccion antes de salir. Recuerde que la transaccion original fue cancelada y si se sale en este momento la transaccion nueva quedara pendiente.");
                e.Cancel = true;
                return;
            }


            CComprasD pvd = new CComprasD();
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
            CComprasD pvd = new CComprasD();
            CMOVTOBE movtoBE = new CMOVTOBE();

            if (this.gridPVDataGridView.Rows.Count <= 0)
                return;

            //asegurarnos de que realmente se quiere eliminar el detalle y que el supervisor dio su aval
            if (MessageBox.Show("Realmente quiere eliminar el detalle de transaccion?", "Eliminar detalle de transaccion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //WFPasswordSupervisor ps = new WFPasswordSupervisor();
                //ps.ShowDialog();
                //if (!ps.bPassValido)
                //    return;

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
            AbrirTransaccionsCerradasYDevoluciones(DBValues._DOCTO_TIPO_COMPRA_DEVO);
        }

        private void AbrirTransaccionsCerradasYDevoluciones(long tipoDoctoId)
        {


            if (!(bool)m_Docto.isnull["IID"]
                && m_estadoTransaccion != (int)estadoVenta.e_Cancelada
                && m_estadoTransaccion != (int)estadoVenta.e_Cerrada)
            {

                if (!CancelarTransaccionActual() && m_bEntroAEdicion)
                {
                    MessageBox.Show("Debe cancelar o terminar de editar la transaccion actual");
                    return;
                }
            }


            //IrANuevaTransaccion();
            IrAEstadoInicial();
            /*WFLOOKUPCOMPRAS look = new WFLOOKUPCOMPRAS((int)DBValues._DOCTO_ESTATUS_COMPLETO, (int)DBValues._DOCTO_TIPO_COMPRA_DEVO);
            look.ShowDialog();*/

            WFSeleccionParaDevolucion look = new WFSeleccionParaDevolucion((int)tipoDoctoId, -1 /*(int)DBValues._DOCTO_ESTATUS_COMPLETO*/, m_bPermisoDevolverSinCompra);
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
                this.gridPVDataGridView.BackgroundColor = Color.Gainsboro;
                this.gridPVDataGridView.DefaultCellStyle.BackColor = Color.Gainsboro;


                this.gET_VENTA_DEVOLUCION_REFDataGridView.BackgroundColor = Color.Gainsboro;
                this.gET_VENTA_DEVOLUCION_REFDataGridView.DefaultCellStyle.BackColor = Color.Gainsboro;
                this.gET_VENTA_DEVOLUCION_REFDataGridView.ReadOnly = true;

                this.TBCommandLine.Enabled = false;

                this.TBCosto.Enabled = false;
                this.TBCantidad.Enabled = false;
                this.TBDescuento.Enabled = false;

                /*if (m_enableDescuento)
                    this.TBDescuento.Enabled = false;*/

                this.TBReferencias.Enabled = false;
                this.TBObservaciones.Enabled = false;
                this.DTPFecha.Enabled = false;
                this.DTPFechaVence.Enabled = false;
                this.BTEnviar.Enabled = false;
                        

                

                if (m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_CANCELADA || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_CANCELACION)
                {
                    m_estadoTransaccion = (int)estadoTransaccion.e_Cancelada;
                    this.BTCancelarTransaccion.Enabled = false; 
                    this.BTDevolver.Enabled = false;
                }
                else
                {
                    this.BTCancelarTransaccion.Enabled = true;
                    this.BTDevolver.Enabled = true;
                    m_estadoTransaccion = (int)estadoTransaccion.e_Cerrada;
                }

                this.BTPasarANueva.Enabled = true;
                this.BTEliminarDetalle.Enabled = false;
                this.BTCerrarTransaccion.Enabled = false;
                this.LBOperacion.Text = "Consulta";


                this.TBTransacccion.Visible = false;


                if (m_manejaAlmacen)
                {
                    this.ALMACENComboBox.Enabled = false;
                    if (!(bool)m_Docto.isnull["IALMACENID"])
                        this.ALMACENComboBox.SelectedDataValue = m_Docto.IALMACENID;
                    else
                        this.ALMACENComboBox.SelectedIndex = -1;
                }

                if (!(bool)m_Docto.isnull["ITIPODIFERENCIAINVENTARIOID"])
                    this.TIPODIFERENCIAINVENTARIOIDComboBox.SelectedDataValue = m_Docto.ITIPODIFERENCIAINVENTARIOID;
                else
                    this.TIPODIFERENCIAINVENTARIOIDComboBox.SelectedIndex = -1;

                llenarDatosGeneralesDocto();

            }
        }


        private void llenarDatosGeneralesDocto()
        {

            if (!(bool)m_Docto.isnull["IREFERENCIA"])
                this.TBReferencias.Text = m_Docto.IREFERENCIA;

            if (!(bool)m_Docto.isnull["IREFERENCIAS"])
                this.TBObservaciones.Text = m_Docto.IREFERENCIAS;


            if (!(bool)m_Docto.isnull["IFECHA"])
                this.DTPFecha.Value = m_Docto.IFECHA;


            if (!(bool)m_Docto.isnull["IVENCE"])
                this.DTPFechaVence.Value = m_Docto.IVENCE;


            if (!(bool)m_Docto.isnull["IPERSONAID"])
            {
                //this.ComboProveedor.SelectedValue = m_Docto.IPERSONAID;
                llenarDatosPersona();
            }



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

        }

        public void llenarDatosPersona()
        {
            CPERSONAD clienteD = new CPERSONAD();
            CPERSONABE clienteBE = new CPERSONABE();
            clienteBE.IID = this.m_PersonaId;
            clienteBE = clienteD.seleccionarPERSONA(clienteBE, null);
            if (clienteBE != null)
            {

                lbClieCiudad.Text = ((bool)clienteBE.isnull["ICIUDAD"]) ? "" : clienteBE.ICIUDAD;
                lbClieColonia.Text = ((bool)clienteBE.isnull["ICOLONIA"]) ? "" : clienteBE.ICOLONIA;
                lbClieCP.Text = ((bool)clienteBE.isnull["ICODIGOPOSTAL"]) ? "" : clienteBE.ICODIGOPOSTAL;
                lbClieDom.Text = ((bool)clienteBE.isnull["IDOMICILIO"]) ? "" : clienteBE.IDOMICILIO;
                lbClieEstado.Text = ((bool)clienteBE.isnull["IESTADO"]) ? "" : clienteBE.IESTADO;
                lbClieNombre.Text = ((bool)clienteBE.isnull["INOMBRE"]) ? "" : clienteBE.INOMBRE;
                lbClieRFC.Text = ((bool)clienteBE.isnull["IRFC"]) ? "" : clienteBE.IRFC;
                lbClieTel.Text = ((bool)clienteBE.isnull["ITELEFONO1"]) ? "" : clienteBE.ITELEFONO1;

                LBCliente.Text = clienteBE.ICLAVE;

            }
            else
            {
                LimpiarDatosDePersona();
            }

        }


        private void BTAbrirCerradasYDevo_Click(object sender, EventArgs e)
        {

            //if (!(bool)m_Docto.isnull["IID"]
            //    && m_estadoTransaccion != (int)estadoVenta.e_Cancelada
            //    && m_estadoTransaccion != (int)estadoVenta.e_Cerrada)
            //{
            //    if (!CancelarTransaccionActual() && m_bEntroAEdicion)
            //    {
            //        MessageBox.Show("Debe cancelar o terminar de editar la transaccion actual");
            //        return;
            //    }
            //}

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
                //lblClienteSuc.Text = "SUC_DEST:";
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
                CComprasD pvd = new CComprasD();
                prod = pvd.buscarPRODUCTOSPV(this.TBCommandLine.Text, CurrentUserID.CurrentParameters, null);
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
                    this.TBCantidad.Focus();
                }
                else if (res == 2)
                {

                    SeleccionarSubProducto(prod.IID, TBCommandLine.Text);
                }
            }
        }

        private void gridPVDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (gridPVDataGridView.Columns["GVCANTIDAD"].Index != e.ColumnIndex)
                return;


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
                    TBCantidad.Text = dEntrada.ToString("N0");
                    TBCosto.Text = gridPVDataGridView.Rows[e.RowIndex].Cells["PRECIOUNIDAD"].Value.ToString();
                    TBDescuento.Text = gridPVDataGridView.Rows[e.RowIndex].Cells["DGDESC"].Value.ToString();
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

            return;
        }

        private void TBCommandLine_Validated(object sender, EventArgs e)
        {
            

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
                //CPRODUCTOBE prod = new CPRODUCTOBE();
                if (BuscarProducto(ref prod))
                {

                    if (prod.IESPRODUCTOPADRE == "S")
                    {
                        return 2;
                    }


                    this.TBCantidad.Text = "1";
                    this.TBDescuento.Text = "0";

                    if (!(bool)prod.isnull["ICOSTOULTIMO"])
                        this.TBCosto.Text = prod.ICOSTOULTIMO.ToString("N2");

                    this.TBStatus.Text = prod.INOMBRE + " // " + prod.IDESCRIPCION + " // " + prod.IDESCRIPCION1;


                    if (!(bool)prod.isnull["ITASAIVA"])
                        this.LBIva.Text = prod.ITASAIVA.ToString("N1");
                    else
                        this.LBIva.Text = "0.0";
                }
                else
                {
                    return 0;
                }
            }

            return 1;
        }





        private void NuevoDevolucion()
        {

                
            if (((!(bool)m_Docto.isnull["IID"])
                // && (m_estadoTransaccion == (int)estadoVenta.e_Cerrada)
                && (!(m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_CANCELADA || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA_CANCELACION)))
                 || ((bool)m_Docto.isnull["IID"]))
            {

                CDOCTOBE doctoBuffer = m_Docto;
                m_Docto = new CDOCTOBE();
                IrANuevaTransaccion();
                this.m_DoctoRef = doctoBuffer;
                this.m_tipoTransaccion = tipoTransaccionV.t_compradevolucion;



                this.BTPasarANueva.Enabled = true;
                this.BTEliminarDetalle.Enabled = false;
                this.BTCerrarTransaccion.Enabled = false;
                this.LBOperacion.Text = "Devolución";




                if (!(bool)m_Docto.isnull["IORIGENFISCALID"])
                {
                    switch (m_Docto.IORIGENFISCALID)
                    {
                        case 2: this.CBOrigenFiscal.SelectedIndex = 0; break;
                        case 3: this.CBOrigenFiscal.SelectedIndex = 1; break;
                        default: this.CBOrigenFiscal.SelectedIndex = -1; break;
                    }
                    if((bool)m_Docto.isnull["IID"])
                        this.CBOrigenFiscal.Enabled = true;
                    else
                        this.CBOrigenFiscal.Enabled = false;

                }




                m_Docto.ITIPODOCTOID = DBValues._DOCTO_TIPO_COMPRA_DEVO;
                m_Docto.IPERSONAID = this.m_PersonaId;

                if (this.m_DoctoRef != null)
                    if ((bool)this.m_DoctoRef.isnull["IID"])
                        this.m_DoctoRef = null;

                if (this.m_DoctoRef != null)
                {
                    m_Docto.IDOCTOREFID = this.m_DoctoRef.IID;
                    m_Docto.IORIGENFISCALID = this.m_DoctoRef.IORIGENFISCALID;

                    this.CBOrigenFiscal.SelectedIndex = (m_DoctoRef.IORIGENFISCALID == DBValues._ORIGENFISCAL_FACTURADO) ? 1 : 0;
                    this.CBOrigenFiscal.Enabled = false;

                    m_Docto.IREFERENCIA = this.m_DoctoRef.IREFERENCIA;
                    this.TBReferencias.Text = m_Docto.IREFERENCIA;
                    this.TBReferencias.Enabled = false;

                }
                else
                {
                    this.CBOrigenFiscal.Enabled = true;
                    this.TBReferencias.Enabled = true;
                }


                this.BTEnviar.Enabled = true;
                this.TBObservaciones.Enabled = true;
                this.DTPFechaVence.Enabled = true;
                this.BTSeleccionarProducto.Enabled = true;
                this.BTDevolver.Enabled = false;
                this.BTCancelarTransaccion.Enabled = true;




                if (!(bool)m_DoctoRef.isnull["IFOLIO"])
                {
                    this.LBDeLaCompra.Text = m_DoctoRef.IFOLIO.ToString("0");
                }
                else
                {
                    this.LBDeLaCompra.Text = "...";
                }



                //if (!(bool)m_DoctoRef.isnull["IPERSONAID"])
                //{
                //    //this.ComboProveedor.SelectedValue = this.m_DoctoRef.IPERSONAID;
                //}
                RefrescarGridSecundario();
                this.TBTransacccion.Visible = false;


                if (m_manejaAlmacen)
                {
                    if (m_DoctoRef != null && !(bool)m_DoctoRef.isnull["IID"])
                    {
                        this.ALMACENComboBox.Enabled = false;
                        if (!(bool)m_DoctoRef.isnull["IALMACENID"])
                            this.ALMACENComboBox.SelectedDataValue = m_DoctoRef.IALMACENID;
                        else
                            this.ALMACENComboBox.SelectedIndex = -1;
                    }
                }

                this.TIPODIFERENCIAINVENTARIOIDComboBox.SelectedIndex = -1;

            }
        }

        private void BTDevolver_Click(object sender, EventArgs e)
        {

            if (m_estadoTransaccion == (int)estadoVenta.e_Cancelada)
            {
                MessageBox.Show("No puede editar una transaccion cancelada");
                return;
            }

            if (MessageBox.Show("Para editar una devolucion ya terminada, se cancelara la transaccion original y se copiara su informacion en una nueva. Esta seguro que desea continuar?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            CComprasD pvd = new CComprasD();

            if ((!(bool)m_Docto.isnull["IID"])
                && (m_estadoTransaccion == (int)estadoVenta.e_Cerrada)
                && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA)
            {
                NuevoDevolucion();
            }
            else if ((!(bool)m_Docto.isnull["IID"])
                && (m_estadoTransaccion == (int)estadoVenta.e_Cerrada)
                && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA_DEVO)
            {
                long doctoIDEdicion = 0;

                if (pvd.EditarCompraDevolucion(m_Docto, CurrentUserID.CurrentUser, ref doctoIDEdicion, CurrentUserID.CurrentUser.IID, null))
                {
                    //IrANuevaTransaccion();
                    IrAEstadoInicial();
                    m_Docto = new CDOCTOBE();
                    m_Docto.IID = doctoIDEdicion;
                    CDOCTOD vData = new CDOCTOD();
                    m_Docto = vData.seleccionarDOCTO(m_Docto, null);


                    m_DoctoRef = new CDOCTOBE();
                    this.m_DoctoRef.IID = m_Docto.IDOCTOREFID;
                    m_DoctoRef = vData.seleccionarDOCTO(m_DoctoRef, null);

                    this.m_tipoTransaccion = tipoTransaccionV.t_compradevolucion;
                    RefrescarGridTransaccions();
                    this.BTCerrarTransaccion.Enabled = true;


                    this.BTDevolver.Enabled = false;
                    this.BTCancelarTransaccion.Enabled = true;
                    this.BTPasarANueva.Enabled = true;
                    this.BTEliminarDetalle.Enabled = false;


                    llenarDatosGeneralesDocto();
                    habilitarTextosEdicion();


                    m_bEntroAEdicion = true;

                    this.BTAbrirCerradasYDevo.Enabled = false;
                    this.BTAbrirTransaccion.Enabled = false;
                    this.BTPasarANueva.Enabled = false;


                }


              

            }
        }




        private void RefrescarGridSecundario()
        {
            this.gET_VENTA_DEVOLUCION_REFTableAdapter.Fill(this.dSPuntoDeVentaAux.GET_VENTA_DEVOLUCION_REF, m_Docto.IID, m_Docto.IDOCTOREFID);

        }

        private void gET_VENTA_DEVOLUCION_REFDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

            DataGridView view = (DataGridView)sender;
            MessageBox.Show("Dato invalido , porfavor ingrese un dato valido");
            e.ThrowException = false;
        }

        private void gET_VENTA_DEVOLUCION_REFDataGridView_EnterKeyDownEvent(object sender, EventArgs e)
        {
            this.TBCommandLine.Focus();
        }

        private void gET_VENTA_DEVOLUCION_REFDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (gET_VENTA_DEVOLUCION_REFDataGridView.Columns["DGCANTIDADDEVOLVER"].Index != e.ColumnIndex)
                return;


            try
            {
                decimal dNuevaCantidad = decimal.Parse(e.FormattedValue.ToString());
                decimal dViejaCantidad = decimal.Parse(gET_VENTA_DEVOLUCION_REFDataGridView.Rows[e.RowIndex].Cells["DGCANTIDADDEVOLVER"].Value.ToString());
                decimal dEntrada = dNuevaCantidad - dViejaCantidad;
                if (dEntrada == 0)
                    return;
                if (dNuevaCantidad < 0)
                {
                    MessageBox.Show("La cantidad  no puede ser menor  a cero, si requiere cancelar el detalle porfavor seleccione 'Eliminar detalle'");
                    e.Cancel = true;
                }
                else
                {

                    TBCommandLine.Text = gET_VENTA_DEVOLUCION_REFDataGridView.Rows[e.RowIndex].Cells["DGCLAVEPRODUCTO"].Value.ToString();
                    TBCantidad.Text = dEntrada.ToString("N3");
                    TBCosto.Text = gET_VENTA_DEVOLUCION_REFDataGridView.Rows[e.RowIndex].Cells["DGPRECIOUNIDADREF"].Value.ToString();
                    TBDescuento.Text = gET_VENTA_DEVOLUCION_REFDataGridView.Rows[e.RowIndex].Cells["DGDESCUENTOREF"].Value.ToString();
                    LBIva.Text = gET_VENTA_DEVOLUCION_REFDataGridView.Rows[e.RowIndex].Cells["DGTASAIVA"].Value.ToString();

                    long? P_MOVTOREFID = (long)gET_VENTA_DEVOLUCION_REFDataGridView.Rows[e.RowIndex].Cells["DGMOVTOREFID"].Value;


                    if (!ProcessCommandRef(P_MOVTOREFID))
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        this.TBCommandLine.Focus();
                    }
                }
                return;
            }
            catch
            {
                MessageBox.Show("Cheque el formato de entrada del valor");
                e.Cancel = true;
            }

            return;
        }

        private void gET_VENTA_DEVOLUCION_REFDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

            if (TBReferencias.Text.Trim().Length == 0)
            {
                MessageBox.Show("Antes de editar desde el grid, porfavor llene el campo de referencia");
                e.Cancel = true;
                return;
            }
        }

        private void gridPVDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

            if (TBReferencias.Text.Trim().Length == 0)
            {
                MessageBox.Show("Antes de editar desde el grid, porfavor llene el campo de referencia");
                e.Cancel = true;
                return;
            }
        }

        private void TBTransacccion_Validated(object sender, EventArgs e)
        {

            if (TBTransacccion.Text.Trim() == "")
            {
                m_Docto = new CDOCTOBE();
                NuevoDevolucion();
                m_estadoTransaccion = (int)estadoVenta.e_SinIniciar;
            }
        }

        private void TBTransacccion_Validating(object sender, CancelEventArgs e)
        {

            if (TBTransacccion.Text.Trim() == "")
                return;

            int folio = 0;

            CDOCTOD vData = new CDOCTOD();
            if (int.TryParse(TBTransacccion.Text.Trim(), out folio))
            {
                m_Docto = new CDOCTOBE();
                m_Docto.IFOLIO = folio;
                m_Docto.ITIPODOCTOID = DBValues._DOCTO_TIPO_COMPRA;
                m_Docto = vData.SeleccionarXTIPOYFOLIO(m_Docto, null);

                if (m_Docto != null)
                {

                    m_PersonaId = m_Docto.IPERSONAID;

                    if ((!(bool)m_Docto.isnull["IID"])
                        && (!(m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_CANCELADA || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA_CANCELACION))
                        && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA)
                    {
                        NuevoDevolucion();

                        m_estadoTransaccion = (int)estadoVenta.e_SinIniciar;
                    }
                }
                else
                {
                    m_Docto = new CDOCTOBE();
                    NuevoDevolucion();
                    m_estadoTransaccion = (int)estadoVenta.e_SinIniciar;

                    MessageBox.Show("El registro no existe");

                    e.Cancel = true;
                }

            }
        }

        private void TBTransacccion_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (TBTransacccion.Text.Trim() != "")
                {
                    this.BTPasarANueva.Focus();
                }
            }
        }

        private void TBTransacccion_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (TBTransacccion.Text.Trim() == "")
                {


                    WFSeleccionParaDevolucion look = new WFSeleccionParaDevolucion((int)DBValues._DOCTO_TIPO_COMPRA, (int)DBValues._DOCTO_ESTATUS_COMPLETO, m_bPermisoDevolverSinCompra);
                    look.ShowDialog();

                    DataRow dr = look.m_rtnDataRow;

                    look.Dispose();
                    GC.SuppressFinalize(look);

                    if (dr != null)
                    {
                        m_Docto.IID = int.Parse(dr[0].ToString());
                        CDOCTOD vData = new CDOCTOD();
                        m_Docto = vData.seleccionarDOCTO(m_Docto, null);
                        TBTransacccion.Text = dr["FOLIO"].ToString();
                    }
                }
            }
        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BTDeSucursales_Click(object sender, EventArgs e)
        {
            AbrirTransaccionsCerradasYDevoluciones(DBValues._DOCTO_TIPO_COMPRA_DEVO_SUC);
        }
    }
}