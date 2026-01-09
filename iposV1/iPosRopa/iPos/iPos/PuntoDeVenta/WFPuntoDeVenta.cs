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
using Newtonsoft.Json;
using iPos.PuntoDeVenta;
using iPos.Utilerias.Procesos;
using iPos.Abonos;
using iPos.Entradas;

namespace iPos
{
    struct PVCommandElement
    {
        public string commandText;
        public char commandOper;
    }
    enum estadoVenta { e_SinIniciar, e_Iniciado, e_Cerrada, e_Cancelada };
    public enum tipoTransaccionV { t_venta, t_devolucion, t_cancelaciondevolucion, t_ventaapartado, t_cancelacionapartado, t_compra, t_compradevolucion, t_compracancelaciondevolucion, t_traspasoalmacen, t_ventaMovil , t_compraSucursal, t_compraDevoSucursal };
    public partial class WFPuntoDeVenta : IposForm
    {
        int m_estadoVenta;
        CDOCTOBE m_Docto;
        CCAJABE m_Caja;
        List<string> loadedFiles = new List<string>();
        DateTime loadedFilesDate = new DateTime();
        int loadedFilesWorkHours;
        bool loadedFilesCerrada = false;

        DateTime localFechaLastLlenadoAutocompleteProdConExis = new DateTime();

        decimal m_dMontoVenta;
        decimal m_dSumaImporte;
        decimal m_dMontoIva;
        decimal m_dDescuento;
        decimal m_montoVentaConVale;
        decimal m_montoVentaConValePorc1;
        decimal m_montoVentaConValePorc2;
        decimal m_montoVentaConValePorc3;
        decimal m_montoVentaConValePorc4;
        long m_tipoDescuentoVale;

        string m_printer = "";
        long m_sucursalTID;
        bool m_bSalirSinPreguntar;

        bool m_focusInCommandLine = false;
        long m_ClienteId = DBValues._CLIENTEMOSTRADOR;

        string m_strUltimoProductoIngresado = "";

        bool m_bPermisoCambiarPrecio = false;
        bool m_bPermisoCambiarPrecioxLista = false;
        bool m_bPermisoCambiarPrecioxDescuento = false;

        bool m_bPermisoImprimirTicketFacturaDirecto = false;
        bool m_bPermisoImprimirCotizacionSinTope = false;

        bool m_bPermisoActualizarFechaAutomaticamente = false;

        bool m_busuarioTienePermisoPonerNota = false;

        bool m_busuarioTienePermisoMarcarCotiEnrutada = false;

        bool m_bMostrarAlertasCompras = false;

        bool m_manejaAlmacen = false;

        long m_rutaEmbarqueId = 0;

        bool m_bPermisoPagarVenta = false;

        bool m_bPermisoVentaStand = false;

        bool m_bPermisoVerUtilidad = false;


        tipoTransaccionV m_tipoTransaccion;
        CDOCTOBE m_DoctoRef;


        CPERSONABE m_supervisor = null;
        bool m_asignarsupervisor = false;


        long m_almacenTID = 0;

        bool m_usuarioPuedeCambiarAlmacen = false;



        //int m_keyboardSize = 0;
        //private TextBox focusedTextbox = null;
        //bool m_teclaTouch = false;
        //int m_mainViewHeight = 0;

        double scaleFactor = 1;

        int m_CommandLineWidth = 334;

        string strLastProductoSearch = "";

        WFPagosBasico m_formPagoVenta = null;

        long predoctoId = 0;

        bool bTieneDerechoARetirosDeCaja = false;

        bool bActualizarPrecioDespuesDeCrearDocto = false;
        bool bActualizarPrecioPorCreditoDespuesDeCrearDocto = false;


        bool bActualizarObservacionesDespuesDeCrearDocto = false;
        bool bActualizarContadoDespuesDeCrearDocto = false;
        bool bActualizarFacturaElectronicaDespuesDeCrearDocto = false;

        bool bActualizarVentaEspecialDespuesDeCrearDocto = false;

        bool bActualizarCotizacionEnrutadaDespuesDeCrearDocto = false;

        bool m_bLlenandoDoctoDatosGenerales = false;


        bool bTieneDerechoAVentasAFuturo = false;

        bool bTieneDerechoRutaEmbarque = false;

        bool bTieneDerechoAsignarVendedorEjecutivo = false;


        bool bTieneDerechoOrdenarPorDescripcion = false;

        long m_vendedorEjecutivoId = 0;

        bool m_bDoctoUnico = false;
        bool m_bAutomatizaPagoEfectivo = false;
        public bool m_bPagoAutomaticoHecho = false;

        bool? m_pagoConTarjetaClienteMostrador = null;

        bool m_bAsignarOrdenCompraAlProcess = false;
        bool m_bAsignarRutaEmbarqueAlProcess = false;
        string m_ordenCompraAAsignar = null;
        long m_rutaEmbarqueAAsignar = 0;

        long m_AUTORIZOALERTAID = 0;

        long m_doctoSustitutoId = 0;

        bool m_bTieneDerechoAsignarOtroCorteCanc = false;

        bool m_vigilarPagoConTarjeta = false;

        bool m_bTieneDerechoBloquearF6 = false;


        //autorizador credito
        bool m_bActualizarComentarioAutorizacionCredito = false;
        string m_strComentarioAutorizacionCredito = "";
        long m_lAutorizadorCredito = 0;


        public WFPuntoDeVenta()
        {
            InitializeComponent();
            try
            {
                ResetearVariablesForm();
                m_bSalirSinPreguntar = false;
            }
            catch
            {

            }
        }


        public WFPuntoDeVenta(long doctoId)
            : this()
        {
            predoctoId = doctoId;


        }


        public WFPuntoDeVenta(long doctoId, bool bDoctoUnico)
            : this(doctoId)
        {
            m_bDoctoUnico = bDoctoUnico;
        }

        public WFPuntoDeVenta(long doctoId, bool bDoctoUnico, bool bAutomatizaPagoEfectivo)
           : this(doctoId, bDoctoUnico)
        {
            m_bAutomatizaPagoEfectivo = bAutomatizaPagoEfectivo;
        }

        


        private void ResetearVariablesForm()
        {


            if (m_formPagoVenta != null)
            {
                try
                {
                    m_formPagoVenta.Dispose();
                    m_formPagoVenta = null;
                }
                catch
                {

                }
            }


            strLastProductoSearch = "";

            m_estadoVenta = (int)estadoVenta.e_SinIniciar;
            m_Docto = new CDOCTOBE();
            m_Caja = new CCAJABE();

            m_supervisor = null;

            m_Docto.ITIPODOCTOID = CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S") ? DBValues._DOCTO_TIPO_VENTAMOVIL : DBValues._DOCTO_TIPO_VENTA;
            BTValidarExistencia.Visible = CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S");

            m_dMontoVenta = 0;
            m_dSumaImporte = 0;
            m_dMontoIva = 0;
            m_dDescuento = 0;
            m_sucursalTID = 0;
            m_montoVentaConVale = 0;
            m_montoVentaConValePorc1 = 0;
            m_montoVentaConValePorc2 = 0;
            m_montoVentaConValePorc3 = 0;
            m_montoVentaConValePorc4 = 0;
            m_tipoDescuentoVale = -1;
            RefrescarEstatusBotones();

            m_tipoTransaccion = CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S") ? tipoTransaccionV.t_ventaMovil : tipoTransaccionV.t_venta;
            m_DoctoRef = null;

            m_vendedorEjecutivoId = 0;


            m_bAsignarOrdenCompraAlProcess = false;
            m_bAsignarRutaEmbarqueAlProcess = false;
            m_ordenCompraAAsignar = null;
            m_rutaEmbarqueAAsignar = 0;

            m_AUTORIZOALERTAID = 0;


            //autorizador credito
            m_bActualizarComentarioAutorizacionCredito = false;
            m_strComentarioAutorizacionCredito = "";
            m_lAutorizadorCredito = 0;

        }


        private void MostrarVendedorYTurno()
        {
        }


        private bool ChecarPermisos()
        {

            CPERSONAD personaD = new CPERSONAD();
            int iMenu = int.Parse(DBValues._MENUID_PUNTODEVENTA.ToString());
            if (!personaD.UsuarioTieneDerechoAMenu(CurrentUserID.CurrentUser.IID, iMenu, null))
            {
                m_bSalirSinPreguntar = true;
                MessageBox.Show("El usuario no tiene derecho a este form");
                return false;
            }

            CUSUARIOSD usuariosD = new CUSUARIOSD();
            if (usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_CAMBIARPRECIO_VENTA, null))
            {
                m_bPermisoCambiarPrecio = true;
            }

            if (usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_CAMBIARPRECIOXLISTA_VENTA, null))
            {
                m_bPermisoCambiarPrecioxLista = true;
            }


            if (usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_CAMBIARDESCUENTO_VENTA, null))
            {
                m_bPermisoCambiarPrecioxDescuento = true;
            }



            if (usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_VENTASFUTURO_GRABAR, null))
                bTieneDerechoAVentasAFuturo = true;
            else
                bTieneDerechoAVentasAFuturo = false;




            if (usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_ASIGNAR_VENDEDOR_EJECUTIVO, null))
                bTieneDerechoAsignarVendedorEjecutivo = true;
            else
                bTieneDerechoAsignarVendedorEjecutivo = false;




            if (usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_ORDENARXDESC_VENTA, null))
                bTieneDerechoOrdenarPorDescripcion = true;
            else
                bTieneDerechoOrdenarPorDescripcion = false;



            if (usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_IMPRIMIRDIRECTO_TICKETFACT, null))
            {
                m_bPermisoImprimirTicketFacturaDirecto = true;
            }
            else
            {
                m_bPermisoImprimirTicketFacturaDirecto = false;
            }


            if (usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_IMPRIMIR_COTISINTOPE, null))
            {
                m_bPermisoImprimirCotizacionSinTope = true;
            }
            else
            {
                m_bPermisoImprimirCotizacionSinTope = false;
            }

            
            if (usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_ALERTARCOMPRA_NUEVOSPROD, null))
            {
                m_bMostrarAlertasCompras = true;
            }
            else
            {
                m_bMostrarAlertasCompras = false;
            }

            if (usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_ACTUALIZAR_AUTOM_FECHA, null))
            {
                m_bPermisoActualizarFechaAutomaticamente = true;
            }
            else
            {
                m_bPermisoActualizarFechaAutomaticamente = false;
            }


            m_busuarioTienePermisoPonerNota = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_PONERNOTA_Y_CONTADOFACT_ENCOTI, null);

            m_busuarioTienePermisoMarcarCotiEnrutada = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_ENRUTAR_COTIZACION, null);
            

            this.TBPrecio.ReadOnly = !this.m_bPermisoCambiarPrecio;
            this.TBDescuento.ReadOnly = !this.m_bPermisoCambiarPrecioxDescuento;
            try
            {
                this.gridPVDataGridView.Columns["PRECIOUNIDAD"].ReadOnly = !this.m_bPermisoCambiarPrecio;
                this.gridPVDataGridView.Columns["DESCUENTOPORCENTAJE"].ReadOnly = !this.m_bPermisoCambiarPrecioxDescuento;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            foreach (DataGridViewColumn column in gridPVDataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            if (bTieneDerechoOrdenarPorDescripcion)
            {

                DGDESCRIPCION.SortMode = DataGridViewColumnSortMode.Automatic;
            }
            else
            {
                DGDESCRIPCION.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            this.m_bPermisoVerUtilidad = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_VER_UTILIDAD_VENTAS, null);


            if (usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_VER_UTILIDAD_VENTAS, null))
            {
                this.DGPORC_UTILIDAD.Visible = true;
            }


            return true;
        }

        private void WFPuntoDeVenta_Load(object sender, EventArgs e)
        {
            bool bPrecargoDocto = false;

            //m_mainViewHeight = 672;// this.Size.Height;

            /*if (CurrentUserID.CurrentParameters.ITOUCH.Equals("S"))
            {
                this.Location = new Point(0, 0);
                this.Size = Screen.PrimaryScreen.WorkingArea.Size;
                m_keyboardSize = 295;
            }
            else
            {
                this.Size = new Size(980, 658);
                this.keyboardcontrol1.Visible = false;
            }*/

            CUSUARIOSD usersD = new CUSUARIOSD();

            BorrarVisitasViejasPorCaja((long)CurrentUserID.CurrentCompania.IEM_CAJA);

            if (CurrentUserID.CurrentParameters.IBANCOMERHABPINPAD != null && CurrentUserID.CurrentParameters.IBANCOMERHABPINPAD == "S")
            {
                BTPuntosBancomer.Visible = true;
            }
            else
            {
                BTPuntosBancomer.Visible = false;
            }
            if (CurrentUserID.CurrentParameters.IRUTAARCHIVOSADJUNTOS != null && CurrentUserID.CurrentParameters.IRUTAARCHIVOSADJUNTOS != "")
            {
                btnAdjuntarArchivo.Visible = true;
            }

            if (CurrentUserID.CurrentParameters.ISERVICIOSEMIDA != null && CurrentUserID.CurrentParameters.ISERVICIOSEMIDA == "S")
            {
                btnRecargasEmida.Visible = true;
            }
            else
            {
                btnRecargasEmida.Visible = false;
            }


            if (!CurrentUserID.CurrentParameters.IHABBOTONPAGOVALE.Equals("S"))
            {
                this.BTPagarConVale.Enabled = false;
                this.BTPagarConVale.Visible = false;
            }


            if (CurrentUserID.CurrentParameters.IHABPAGOSERVEMIDA != null && CurrentUserID.CurrentParameters.IHABPAGOSERVEMIDA == "S")
            {
                btnPagoServicios.Visible = true;
            }
            else
            {
                btnPagoServicios.Visible = false;
            }



            if (usersD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_RETIROCAJA_REGISTRO, null))
                bTieneDerechoARetirosDeCaja = true;
            else
                bTieneDerechoARetirosDeCaja = false;




            if (CurrentUserID.CurrentParameters.ITOUCH.Equals("S"))
            {

                /*this.Location = new Point(this.Location.X, 0);
                this.scaleFactor = 0.75;;
                this.Size = new Size(1050, (int)(658 * scaleFactor) + 10 + 50);*/
                this.Size = new Size(1050, this.Size.Height);
                pnlHideRight.Visible = true;
                pnlHideRight.BringToFront();
                this.AutoScroll = false;
                this.HorizontalScroll.Enabled = false;
                this.HorizontalScroll.Visible = false;
                this.VerticalScroll.Enabled = false;
                this.VerticalScroll.Visible = false;

                //RemoveAnchor(this);
            }

            if (bEstaConfiguradoParaPiezasyCajas())
            {
                formatCajasBotellasPiezas(true);

                gridPVDataGridView.Columns["GVCANTIDAD"].ReadOnly = true;

            }
            else
            {
                formatCajasBotellasPiezas(false);
            }

            if (!ChecarPermisos())
            {
                this.Close();
                return;
            }

            this.Text = "BIENVENIDO  (CAJA: " + iPos.CurrentUserID.CurrentCompania.IEM_CAJA_NOMBRE + " ) ";

            this.LBVendedor.Text = iPos.CurrentUserID.CurrentUser.INOMBRE;
            this.LBSucursal.Text = iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO;
            this.LBFecha.Text = DateTime.Today.ToString("dd/MM/yyyy");
            MostrarVendedorYTurno();
            this.TBCliente.Text = "mostrador";
            this.gRIDPVTableAdapter2.SelectCommandTimeout = 100;
            m_printer = Ticket.GetReceiptPrinter();

            if (!ChecarFechaDelSistema())
                return;

            ChecarCorteActivo();
            ObtenerCaja();
            FormatTotalPiezas();

            IrANuevaVenta();

            HabilitarBotonesOpcionales();

            this.TBCommandLine.Focus();

            m_manejaAlmacen = !((bool)CurrentUserID.CurrentParameters.isnull["IMANEJAALMACEN"] || !CurrentUserID.CurrentParameters.IMANEJAALMACEN.Equals("S"));
            if (!m_manejaAlmacen)
            {
                this.ALMACENComboBox.Visible = false;
                this.lblAlmacen.Visible = false;
                this.btnTraspasoAlmacenes.Visible = false;
            }
            else
            {

                this.ALMACENComboBox.Visible = true;
                this.lblAlmacen.Visible = true;
                this.btnTraspasoAlmacenes.Visible = true;

                this.ALMACENComboBox.llenarDatos();
                try
                {
                    this.ALMACENComboBox.SelectedIndex = -1;


                    CUSUARIOSD usuariosD = new CUSUARIOSD();

                    m_usuarioPuedeCambiarAlmacen = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_CAMBIARDEALMACEN, null);

                    SetDefaultAlmacenEstatus();


                    if (usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_TRASPASOENTREALMACENES, null))
                        this.btnTraspasoAlmacenes.Enabled = true;
                    else
                        this.btnTraspasoAlmacenes.Enabled = false;





                    if (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
                    {
                        this.BTTraspaso.Enabled = false;
                        btnNuevaApartado.Enabled = false;
                    }



                }
                catch
                {
                }
            }



            if (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
            {
                this.BTTraspaso.Visible = false;
                btnNuevaApartado.Visible = false;

                this.BTPagarConVale.Visible = false;
                TBVale.Visible = false;
                lblvale.Visible = false;

                this.btnAdjunto.Visible = true;
                this.btnAdjunto.ForeColor = Color.Black;
                this.btnAdjunto.BackColor = Color.FromArgb(41, 121, 255);
                this.btnListaAdjuntos.Visible = true;
                this.btnListaAdjuntos.ForeColor = Color.Black;
                this.btnListaAdjuntos.BackColor = Color.FromArgb(41, 121, 255);


                if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL <= 1 || CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 4)
                    pnlInfoSaldos.Visible = true;
                else
                    pnlInfoSaldos.Visible = false;


            }
            else
            {
                pnlInfoSaldos.Visible = false;
                this.btnAdjunto.Visible = false;
                this.btnAdjunto.BackColor = Color.Gray;
                this.btnListaAdjuntos.Visible = false;
                this.btnListaAdjuntos.BackColor = Color.Gray;
            }

            //this.ComboVendedorFinal.llenarDatos();

            //this.ComboVendedorFinal.SelectedIndex = -1;
            this.VENDEDORIDTextBox.Text = "";


            if (bEstaConfiguradoParaPiezasyCajas())
            {
                this.TBCantidad.Enabled = true;
            }
            else
            {
                this.TBCantidad.Enabled = CurrentUserID.CurrentParameters.IUIVENTACONCANTIDAD.Equals("S");
            }


            if (CurrentUserID.CurrentParameters.IAUTOCOMPPROD.Equals("S"))
            {
                this.TBCommandLine.AutoCompleteMode = AutoCompleteMode.Suggest;
                this.TBCommandLine.AutoCompleteSource = AutoCompleteSource.CustomSource;
                if (CurrentUserID.CurrentParameters.IAUTOCOMPLETECONEXISENVENTA.Equals("S"))
                {
                    this.TBCommandLine.AutoCompleteCustomSource = CurrentUserID.GetAutoSourceProductoConExis();
                }
                else
                {
                    this.TBCommandLine.AutoCompleteCustomSource = CurrentUserID.GetAutoSourceCollectionFromTable();
                }
            }
            else
            {
                //this.TBCommandLine.AutoCompleteCustomSource = CurrentUserID.GetAutoSourceCollectionFromTable();
            }

            if (CurrentUserID.CurrentParameters.IPRECIOXCAJAENPV.Equals("S"))
            {
                this.pnlPrecioCaja.Visible = true;
            }
            else
            {
                this.pnlPrecioCaja.Visible = false;
            }





            Boolean bConsultaXFolio = usersD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_CONSULTARTRANPORFOLIO, null);
            this.btnNoTransaccion.Visible = bConsultaXFolio;




            

            if (predoctoId != 0)
            {
                AbrirVentaXId(predoctoId);
                RefrescarEstatusBotones();
                bPrecargoDocto = true;
                predoctoId = 0;
                
            }




            if (CurrentUserID.CurrentParameters.IPREGUNTARSIESACREDITO != null && CurrentUserID.CurrentParameters.IPREGUNTARSIESACREDITO.Equals("S"))
            {
                CBACredito.Visible = true;
            }
            else
            {
                CBACredito.Visible = false;
            }



            if (!usersD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._PONER_RUTA_EMBARQUE_EN_VENTA, null))
            {
                btnRutaEmbarque.Visible = false;
                lblRutaEmbarque.Visible = false;
                bTieneDerechoRutaEmbarque = false;
            }
            else
            {

                btnRutaEmbarque.Visible = true;
                lblRutaEmbarque.Visible = true;
                bTieneDerechoRutaEmbarque = true;
            }

            //asignar otro corte
            m_bTieneDerechoAsignarOtroCorteCanc = usersD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_APLICARCANC_OTROCORTE, null);

            //
            m_bTieneDerechoBloquearF6 = usersD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_BLOQUEAR_F6, null);

            m_bPermisoPagarVenta = true;
            if (CurrentUserID.CurrentParameters.IHABSURTIDOPREVIO == "S")
            {
                if (!usersD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_PAGARVENTAPRESURTIDO, null))
                    m_bPermisoPagarVenta = false;
            }

            m_bPermisoVentaStand = false;
            if (usersD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_VENTA_STAND, null))
                m_bPermisoVentaStand = true;

            PreFormatGrid();

            if (bPrecargoDocto && m_bAutomatizaPagoEfectivo)
            {
                this.PagarTransaccion();
            }

            
                BTEnviarASurtir.Visible = CurrentUserID.CurrentParameters.IHABSURTIDOPREVIO == "S";
                BTVerASurtir.Visible = CurrentUserID.CurrentParameters.IHABSURTIDOPREVIO == "S";


            PonerHabilitacionObservacionesContadoFactura();

            this.lblUtilidad.Visible = m_bPermisoVerUtilidad;


        }


        private void PonerHabilitacionObservacionesContadoFactura()
        {

            var doctoEnBorrador = m_Docto == null || m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_BORRADOR;

            ObservacionesTextBox.ReadOnly = !(m_busuarioTienePermisoPonerNota && doctoEnBorrador);
            CBContado.Enabled = (m_busuarioTienePermisoPonerNota && doctoEnBorrador);
            CBFactura.Enabled = (m_busuarioTienePermisoPonerNota && doctoEnBorrador);
        }


        private void PonerHabilitacionPagoTarjeta()
        {

            if (!(CurrentUserID.CurrentParameters.ICOMISIONPORTARJETA > 0.0m || CurrentUserID.CurrentParameters.ICOMISIONDEBPORTARJETA > 0.0m) && 
                !(CurrentUserID.CurrentParameters.IPAGOTARJMENORPRECIOLISTAALL != null && CurrentUserID.CurrentParameters.IPAGOTARJMENORPRECIOLISTAALL.Equals("S")
                    ))
            {

                CBXPagoConTarjeta.Visible = false;
                return;
            }

            
                //esto es para evitar buscar este valor cada  vez que se va a una nueva venta ,,, cuando ya se sabe si el cliente de mostrador
                // tiene o no el cargo habilitado se presupone el valor
                if ( m_ClienteId == DBValues._CLIENTEMOSTRADOR && m_pagoConTarjetaClienteMostrador != null)
                {
                    CBXPagoConTarjeta.Visible = m_pagoConTarjetaClienteMostrador.Value;
                    return;
                }

                CPERSONAD personaD = new CPERSONAD();
                CPERSONABE personaBE = new CPERSONABE();
                personaBE.IID = m_ClienteId;
                personaBE = personaD.seleccionarPERSONA(personaBE, null);

                if (personaBE != null &&  ((personaBE.ICARGOXVENTACONTARJETA.Equals("S") ) ||
                        (       personaBE.IHAB_PAGOTARJETA != null && personaBE.IHAB_PAGOTARJETA.Equals("S") && 
                            CurrentUserID.CurrentParameters.IPAGOTARJMENORPRECIOLISTAALL != null && CurrentUserID.CurrentParameters.IPAGOTARJMENORPRECIOLISTAALL.Equals("S")
                        )
                    )
                   )
                {

                    CBXPagoConTarjeta.Visible = true;
                }
                else
                {
                    CBXPagoConTarjeta.Visible = false;
                }

                if (m_ClienteId == DBValues._CLIENTEMOSTRADOR)
                {
                    m_pagoConTarjetaClienteMostrador = CBXPagoConTarjeta.Visible;
                }
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
                m_CommandLineWidth = 252;
                TBCommandLine.Width = 252;
                TBCajas.Visible = true;
                lblCajas.Visible = true;
                lblCantidad.Text = "Botellas";
                TBCajas.Text = "0";
                TBCantidad.Text = "0";



            }
            else
            {
                m_CommandLineWidth = 334;
                TBCommandLine.Width = 334;
                TBCajas.Visible = false;
                lblCajas.Visible = false;
                lblCantidad.Text = "Cantidad";
                TBCajas.Text = "0";
                TBCantidad.Text = "1";
            }

        }


        /* private void RemoveAnchor(Control parentCtrl)
         {
             //float currentSize;
             foreach (Control c in parentCtrl.Controls)
             {


                 c.Size = new Size(c.Size.Width, (int)(c.Size.Height * scaleFactor));
                 c.Location = new Point( c.Location.X, (int)(c.Location.Y * scaleFactor));

                 RemoveAnchor(c);

             }
         }*/


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


        public void PreFormatGrid()
        {
            GVCANTIDAD.DefaultCellStyle.Format = "N" + CurrentUserID.CurrentParameters.IDECIMALESENCANTIDAD.ToString();
        }
        public void FormatGrid()
        {

            this.gridPVDataGridView.BackgroundColor = Color.White;
            this.gridPVDataGridView.DefaultCellStyle.BackColor = Color.White;

        }
        public ArrayList SplitCommandLine(string commandLine, ArrayList splitChars)
        {
            ArrayList commandElemts = new ArrayList();
            PVCommandElement elemInicial = new PVCommandElement();
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
                        PVCommandElement bufferElem = new PVCommandElement();
                        bufferElem.commandText = splittedComm[iSplitIndex];
                        if (iSplitIndex == 0 && numSplittedStr > 1)
                        {
                            bufferElem.commandOper = cSep[0]/*pvComm.commandOper*/;
                        }
                        else
                        {
                            bufferElem.commandOper = pvComm.commandOper/*cSep[0]*/;
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



        private void DecifrarComando(string texto, ref CPRODUCTOBE prod, ref Decimal cantidad, ref bool bPreguntaCantidad, ref CPuntoDeVentaD pvd)
        {

            bool esEmpaque = false;
            bool esCaja = false;

            DecifrarComando(texto, ref prod, ref cantidad, ref bPreguntaCantidad, ref pvd, ref esEmpaque, ref esCaja);
        }

        private void DecifrarComando(string texto, ref CPRODUCTOBE prod, ref Decimal cantidad, ref bool bPreguntaCantidad, ref CPuntoDeVentaD pvd, ref bool esEmpaque, ref bool esCaja)
        {
            bool bTienePrefijoBascula = false;
            DecifrarComando(texto, ref prod, ref cantidad, ref bPreguntaCantidad, ref pvd, ref esEmpaque, ref esCaja, true, ref bTienePrefijoBascula);
        }

        private void DecifrarComando(string texto, ref CPRODUCTOBE prod, ref Decimal cantidad, ref bool bPreguntaCantidad, ref CPuntoDeVentaD pvd, ref bool esEmpaque, ref bool esCaja, bool sustituirProdPromCaducado, ref bool tienePrefijoBascula)
        {

            bool bLastAssigned = false; // ultima busqueda

            string bufferBusquedaText = texto;
            if (bufferBusquedaText.Contains(" <(("))
            {
                string[] strSeparators = new string[] { " <((" };


                string[] strBuffert = bufferBusquedaText.Split(strSeparators, StringSplitOptions.RemoveEmptyEntries);
                if (strBuffert.Count() > 1)
                {

                    //ultima busqueda
                    bLastAssigned = true;
                    //this.strLastProductoSearch = strBuffert[0];


                    bufferBusquedaText = strBuffert[strBuffert.Count() - 1];


                    string[] strSeparatorsBeta = new string[] { "))>" };

                    string[] strBufferz = bufferBusquedaText.Split(strSeparatorsBeta, StringSplitOptions.RemoveEmptyEntries);
                    if (strBufferz.Count() > 0)
                        bufferBusquedaText = strBufferz[0];

                    if (bufferBusquedaText.Trim().Length > 0)
                        texto = bufferBusquedaText.Trim();
                }

            }

            ArrayList splitChars = new ArrayList();
            splitChars.Add('*');
            splitChars.Add('%');
            string commandLine = texto;
            ArrayList commandElemts = SplitCommandLine(commandLine, splitChars);
            int prodIndex = -1, cantIndex = -1, /*descIndex = -1,*/ contIndex;

            decimal cantidadAux = 1;


            contIndex = 0;
            foreach (Object objComm in commandElemts)
            {
                contIndex++;
                PVCommandElement pvComm = (PVCommandElement)objComm;
                if (/*pvComm.commandOper == '*' ||*/ pvComm.commandOper == ' ')
                {
                    prod = pvd.buscarPRODUCTOSPV(pvComm.commandText, ref cantidadAux, ref bPreguntaCantidad, CurrentUserID.CurrentParameters, ref esEmpaque, ref esCaja, ref tienePrefijoBascula, null);
                    if (prod != null)
                    {
                        //ultima busqueda
                        if (!bLastAssigned)
                        {
                            bLastAssigned = true;
                            //this.strLastProductoSearch = pvComm.commandText;
                        }


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

            }


            if (sustituirProdPromCaducado && prod != null &&
                (prod.IEXISTENCIA <= 0) &&
                CurrentUserID.CurrentParameters.IMANEJAPRODUCTOSPROMOCION != null && CurrentUserID.CurrentParameters.IMANEJAPRODUCTOSPROMOCION.Equals("S") &&
                prod.IBASEPRODPROMOID > 0)
            {
                CPRODUCTOD prodD = new CPRODUCTOD();
                CPRODUCTOBE prodBE = new CPRODUCTOBE();
                prodBE.IID = prod.IBASEPRODPROMOID;
                prodBE = prodD.seleccionarPRODUCTO(prodBE, null);

                if (prodBE != null)
                {
                    prod = prodBE;
                }
            }

            cantidad = cantidad * ((cantidadAux == 0) ? 1 : cantidadAux);
        }


        private void ObtenerDoctoDeBD(long lDoctoID, FbTransaction st)
        {
            CDOCTOD vDocto = new CDOCTOD();
            m_Docto = new CDOCTOBE();
            m_Docto.IID = lDoctoID;
            m_Docto = vDocto.seleccionarDOCTO(m_Docto, st);
            
        }


        private bool SoloValidarProducto(ref CPRODUCTOBE prod)
        {
            prod = null;
            long? P_PERSONAID = this.m_ClienteId;
            long? P_USERID = iPos.CurrentUserID.CurrentUser.IID;

            int? US_SUPERVISORID = null;
            if (m_supervisor != null)
                US_SUPERVISORID = (int)m_supervisor.IID;

            long? SUCURSALID = CurrentUserID.CurrentParameters.ISUCURSALID;
            DateTime P_FECHAVENCE = DateTime.MinValue;
            Decimal cantidad = 1;


            bool bPreguntaCantidad = false;


            //decimal multiplicandocantidad = Decimal.Parse(this.TBCantidad.Text.ToString());



            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            if (TBCommandLine.Text == "")
            {
                SeleccionarProducto();
                RefrescarEstatusBotones();
                return false;
            }
            else if (TBCommandLine.Text == "+" && this.m_strUltimoProductoIngresado != "")
            {
                TBCommandLine.Text = this.m_strUltimoProductoIngresado;
            }

            DecifrarComando(TBCommandLine.Text, ref prod, ref cantidad, ref bPreguntaCantidad, ref pvd);


            if (prod == null)
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

            return true;

        }


        private Boolean validaCustomerIfNeeded()
        {
            if (((m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTAMOVIL && CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S")) || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA_FUTURO ||
                (CurrentUserID.CurrentParameters.IHABVENTASMOSTRADOR != null && CurrentUserID.CurrentParameters.IHABVENTASMOSTRADOR == "N" && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA))
                && m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_BORRADOR && m_ClienteId == DBValues._CLIENTEMOSTRADOR)
            {
                MessageBox.Show("Por favor asigne un cliente a la venta distinto a mostrador");
                return false;
            }


            return true;
        }

        private bool ProcessCommand()
        {
            return ProcessCommand(true, true);
        }

        private bool ProcessCommand(bool bIgnorePrecio, bool preguntarOpcion)
        {

            return ProcessCommand(bIgnorePrecio, preguntarOpcion, bIgnorePrecio);
        }

        private bool ProcessCommand(bool bIgnorePrecio, bool preguntarOpcion, bool bIgnoreDescuento)
        {
            long? P_MOVTOID = null;
            return ProcessCommand(bIgnorePrecio, preguntarOpcion, P_MOVTOID, bIgnoreDescuento, false,false);
        }

        

        private bool ProcessCommand(bool bIgnorePrecio, bool preguntarOpcion, long? P_MOVTOID, bool bIgnoreDescuento, bool bIgnoreCargoTarjetaPrecManual, bool bMantenPosicion)
        {


            if ((m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_COMPLETO || m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_BORRADOR) && (m_Docto.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_RECARGA || m_Docto.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_PAGOSERVICIO))
            {
                MessageBox.Show("Las recargas y pago de servicios no se pueden editarse desde aqui");
                return false;
            }

            if (m_manejaAlmacen)
            {
                if (this.ALMACENComboBox.SelectedIndex < 0)
                {
                    MessageBox.Show("por favor seleccione un almacen valido de la lista ");
                    return false;
                }
            }


            if (!validaCustomerIfNeeded())
            {
                return true;
            }


            CPRODUCTOBE prod = null;
            CPRODUCTOD prodD = new CPRODUCTOD();

            long? P_IDDOCTO = null;
            decimal? P_CANTIDAD = null;
            long? P_IDPRODUCTO = null;
            long? P_PERSONAID = this.m_ClienteId;
            string P_LOTE = "";
            long? P_USERID = iPos.CurrentUserID.CurrentUser.IID;

            int? US_SUPERVISORID = null;
            if (m_supervisor != null)
                US_SUPERVISORID = (int)m_supervisor.IID;

            int? ALMACENID = m_manejaAlmacen ? int.Parse(this.ALMACENComboBox.SelectedValue.ToString()) : (int)DBValues._DOCTO_ALMACEN_DEFAULT;/*CurrentUserID.CurrentUser.IUS_ALMACENID*/ ;
            long? SUCURSALID = CurrentUserID.CurrentParameters.ISUCURSALID;
            DateTime P_FECHAVENCE = DateTime.MinValue;
            Decimal cantidad = 1;
            long? SUCURSALTID = 0;
            long? ALMACENTID = m_tipoTransaccion == tipoTransaccionV.t_traspasoalmacen ? m_almacenTID : 0;

            long? P_TIPODIFERENCIAINVENTARIOID = 0;
            decimal? P_PRECIO = null;
            decimal? P_DESCUENTO = null;
            string razonPrecioDescuentoCajero = "";
            string P_CARGOTARJPRECIOMANUAL = bIgnoreCargoTarjetaPrecManual ? "N" : "S";

            bool bResult = true;


            bool bPreguntaCantidad = false;


            decimal multiplicandocantidad = Decimal.Parse(this.TBCantidad.Text.ToString());


            bool esEmpaque = false;
            bool esCaja = false;



            long? P_DOCTOREFID = null;
            if (this.m_DoctoRef != null)
            {
                P_DOCTOREFID = this.m_DoctoRef.IID;
            }

            long? P_MOVTOREFID = null;

            string strDescripcionComodin1 = "", strDescripcionComodin2 = "", strDescripcionComodin3 = "";
            bool bHayDescripcionComodin = false;

            bool bDoctoExistentePreviamente = false;

            m_AUTORIZOALERTAID = 0;



            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            if (TBCommandLine.Text == "")
            {
                SeleccionarProducto();
                RefrescarEstatusBotones();
                return false;
            }
            else if (TBCommandLine.Text == "+" && this.m_strUltimoProductoIngresado != "")
            {
                TBCommandLine.Text = this.m_strUltimoProductoIngresado;
            }

            bool bTienePrefijoBascula = false;

            DecifrarComando(TBCommandLine.Text, ref prod, ref cantidad, ref bPreguntaCantidad, ref pvd, ref esEmpaque, ref esCaja, true, ref bTienePrefijoBascula);

            if (prod == null)
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


            if (prod.IEMIDAPRODUCTOID > 0 && prod.IEMIDAID != null)
            {
                MessageBox.Show("No se pueden registrar recargas emida desde aqui");
                return false;
            }

            //si el producto es kit y tiene validez x sucursal , verificar que este activo
            if(prod.IESKIT != null && prod.IESKIT.Equals("S") && prod.IVALXSUC != null && prod.IVALXSUC.Equals("S") &&
                (prod.IACTIVO == null || !prod.IACTIVO.Equals("S")))
            {
                MessageBox.Show("No se puede vender este kit en esta sucursal");
                return false;
            }


            if (prod.IESKIT != null && prod.IESKIT.Equals("S") && prod.IKITTIENEVIG != null && prod.IKITTIENEVIG.Equals("S") &&
               (prod.IVIGENCIAPRODKIT != null && prod.IVIGENCIAPRODKIT.CompareTo(DateTime.Today) < 0))
            {
                MessageBox.Show("Este kit no esta vigente");
                return false;
            }

            if (bEstaConfiguradoParaPiezasyCajas() && !bProductoSoloManejaKG(prod)/*(prod.IUNIDAD == null || !prod.IUNIDAD.Trim().ToUpper().Equals("KG"))*/)
            {
                Decimal cajas = Decimal.Parse(this.TBCajas.Text.ToString());
                multiplicandocantidad = multiplicandocantidad + (cajas * (prod.IPZACAJA == 0 ? 1 : prod.IPZACAJA));
            }

            if (bTienePrefijoBascula)
                multiplicandocantidad = 1;


            P_CANTIDAD = (cantidad != 0 || (P_MOVTOID.HasValue && P_MOVTOID.Value != 0)) ? cantidad : 1;
            P_CANTIDAD *= multiplicandocantidad;

            if(P_CANTIDAD >= 1000000)
            {
                if (MessageBox.Show("parece ser una cantidad grande.. realmente desea vender esa cantidad?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return false;
                }
            }


            if (P_CANTIDAD == 0 && (TBCommandLine.Text == null || !TBCommandLine.Text.StartsWith("0*")))
            {
                if (bEstaConfiguradoParaPiezasyCajas() && !bProductoSoloManejaKG(prod)/*(prod.IUNIDAD == null || !prod.IUNIDAD.Trim().ToUpper().Equals("KG"))*/)
                {
                    reFormatearPiezasCajasPorUnidad(prod, false, false);
                    this.TBCajas.Focus();
                    return true;
                }
                else if (bProductoSoloManejaKG(prod) /*(prod.IUNIDAD != null && prod.IUNIDAD.Trim().ToUpper().Equals("KG"))*/)
                {
                    this.TBCantidad.Focus();
                    return true;
                }

            }

            //menudeo
            if (!(bool)prod.isnull["IMENUDEO"] && prod.IMENUDEO > 0 && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA)
            {
                decimal cantidadActualEnDocto = CantidadActualDeProductoEnVenta(prod.IID);
                if (cantidadActualEnDocto + P_CANTIDAD > prod.IMENUDEO)
                {

                    MessageBox.Show("para este producto la cantidad maxima a vender por venta es " + prod.IMENUDEO.ToString());
                    return false;
                }

            }


            //recargas
            if (preguntarOpcion)
            {
                CLINEABE lineaBE = new CLINEABE();
                CLINEAD lineaD = new CLINEAD();
                lineaBE.IID = prod.ILINEAID;
                lineaBE = lineaD.seleccionarLINEA(lineaBE, null);

                string lineaTipoRecarga = "NO";
                if (lineaBE != null)
                    if (lineaBE.ITIPORECARGA != null)
                        lineaTipoRecarga = lineaBE.ITIPORECARGA;

                if (/*prod.ICLAVE.Trim() == "7401" || prod.ICLAVE.Trim() == "7402" ||
                    prod.ICLAVE.Trim() == "7418" || prod.ICLAVE.Trim() == "7419"*/ lineaTipoRecarga.Equals("SIMPLE"))
                {

                    string cel1 = "", cel2 = "";

                    WFRecarga wf1 = new WFRecarga();
                    wf1.ShowDialog();
                    cel1 = wf1.m_cel.Trim();
                    if (cel1 == "" || cel1.Length != 10)
                    {
                        MessageBox.Show("Porfavor ingrese un numero de 10 digitos , no vacio");
                        wf1.ShowDialog();
                        cel1 = wf1.m_cel.Trim();
                        if (cel1 == "" || cel1.Length != 10)
                        {
                            MessageBox.Show("Numero no valido");
                            return false;
                        }
                    }

                    WFRecarga wf2 = new WFRecarga();
                    wf2.ShowDialog();
                    cel2 = wf2.m_cel.Trim();
                    if (cel2 != cel1)
                    {
                        MessageBox.Show("No se reingreso el mismo numero");
                        wf2.ShowDialog();
                        cel2 = wf2.m_cel.Trim();
                        if (cel2 != cel1)
                        {
                            MessageBox.Show("No se reingreso el mismo numero");
                            return false;
                        }

                    }

                    P_LOTE = prod.IDESCRIPCION3.Trim() + " : " + cel1;
                    /*
                    switch (prod.ICLAVE.Trim())
                    {
                        case "7401": P_LOTE = "Telcel: " + cel1; break;
                        case "7402": P_LOTE = "Movistar: " + cel1; break;
                        case "7418": P_LOTE = "Unefon: " + cel1; break;
                        case "7419": P_LOTE = "Iusacell: " + cel1; break;
                        default: P_LOTE = ""; break;
                    }*/




                    WFRecargaCantidad rc_ = new WFRecargaCantidad(true, false);
                    rc_.ShowDialog();
                    decimal dMontoRecarga = rc_.m_dMontoRecarga;
                    rc_.Dispose();
                    GC.SuppressFinalize(rc_);



                    if (dMontoRecarga < 0)
                    {
                        MessageBox.Show("El monto debe ser mayor que cero");
                        return false;
                    }


                    P_CANTIDAD = dMontoRecarga;


                }
                else if (/*prod.ICLAVE.Trim() == "7422"*/lineaTipoRecarga.Equals("MULTIPLE"))
                {
                    string cel1 = "", cel2 = "";

                    WFRecarga wf1 = new WFRecarga();
                    wf1.ShowDialog();
                    cel1 = wf1.m_cel.Trim();
                    if (cel1 == "" || cel1.Length != 10)
                    {
                        MessageBox.Show("Porfavor ingrese un numero de 10 digitos , no vacio");
                        wf1.ShowDialog();
                        cel1 = wf1.m_cel.Trim();
                        if (cel1 == "" || cel1.Length != 10)
                        {
                            MessageBox.Show("Numero no valido");
                            return false;
                        }
                    }

                    WFRecarga wf2 = new WFRecarga();
                    wf2.ShowDialog();
                    cel2 = wf2.m_cel.Trim();
                    if (cel2 != cel1)
                    {
                        MessageBox.Show("No se reingreso el mismo numero");
                        wf2.ShowDialog();
                        cel2 = wf2.m_cel.Trim();
                        if (cel2 != cel1)
                        {
                            MessageBox.Show("No se reingreso el mismo numero");
                            return false;
                        }

                    }


                    WFRecargaCantidad rc_ = new WFRecargaCantidad(true, true);
                    rc_.ShowDialog();
                    decimal dMontoRecarga = rc_.m_dMontoRecarga;
                    string compania_ = rc_.m_compania;
                    rc_.Dispose();
                    GC.SuppressFinalize(rc_);


                    if (dMontoRecarga < 0)
                    {
                        MessageBox.Show("El monto debe ser mayor que cero");
                        return false;
                    }


                    P_CANTIDAD = dMontoRecarga;
                    P_LOTE = compania_.Trim() + " - " + cel1;
                }

                else if (bPreguntaCantidad && (!bEstaConfiguradoParaPiezasyCajas() || !this.TBCantidad.Enabled))
                {
                    WFRecargaCantidad rc_ = new WFRecargaCantidad(true, false);
                    rc_.ShowDialog();
                    decimal dMontoRecarga = rc_.m_dMontoRecarga;
                    string compania_ = rc_.m_compania;
                    rc_.Dispose();
                    GC.SuppressFinalize(rc_);


                    if (dMontoRecarga < 0)
                    {
                        MessageBox.Show("El peso debe ser mayor que cero");
                        return false;
                    }


                    P_CANTIDAD = dMontoRecarga;
                }

            }


            if (!(bool)this.m_Docto.isnull["IID"])
            {
                P_IDDOCTO = m_Docto.IID;
                bDoctoExistentePreviamente = true;
            }
            if (prod != null)
            {
                P_IDPRODUCTO = prod.IID;
            }


            if (m_sucursalTID != 0)
                SUCURSALTID = m_sucursalTID;



            decimal tipoCambio = (((bool)m_Docto.isnull["ITIPOCAMBIO"] || m_Docto.ITIPOCAMBIO == 0) ? 1 : m_Docto.ITIPOCAMBIO);

            if (m_bPermisoCambiarPrecioxDescuento && !bIgnoreDescuento)
            {
                P_DESCUENTO = decimal.Parse(TBDescuento.Text) * tipoCambio;
            }

            if (/*CurrentUserID.CurrentParameters.ICAMBIARPRECIO == "S" && prod.ICAMBIARPRECIO == "S" &&*/ !bIgnorePrecio && (m_bPermisoCambiarPrecio || m_bPermisoCambiarPrecioxLista || m_bPermisoCambiarPrecioxDescuento))
            {
                if ((bool)CurrentUserID.CurrentParameters.isnull["IPRECIONETOENPV"] || !CurrentUserID.CurrentParameters.IPRECIONETOENPV.Equals("S"))
                    P_PRECIO = decimal.Parse(TBPrecio.Text) * tipoCambio;
                else
                {
                    P_PRECIO = calculaPrecioSinImpuestos(decimal.Parse(TBPrecio.Text), prod) * tipoCambio;

                }
                //P_DESCUENTO = decimal.Parse(TBDescuento.Text) * tipoCambio;


                if (P_PRECIO < prod.IPRECIO1 - (decimal)0.1)
                {
                    if (CurrentUserID.CurrentParameters.IPREGUNTARRAZONPRECIOMENOR != null && CurrentUserID.CurrentParameters.IPREGUNTARRAZONPRECIOMENOR == "S")
                    {
                        WFRazonDescuentoCajero wfrd_ = new WFRazonDescuentoCajero();
                        wfrd_.ShowDialog();
                        string strRazon = wfrd_.m_strRazon;
                        wfrd_.Dispose();
                        GC.SuppressFinalize(wfrd_);

                        if (strRazon.Trim().Length == 0)
                        {
                            MessageBox.Show("Debe escribir la razon por la cual esta dando un precio menor al precio 1");
                            return false;
                        }
                        else
                        {
                            razonPrecioDescuentoCajero = strRazon.Trim();
                        }
                    }
                    else
                    {
                        razonPrecioDescuentoCajero = "Razón no especificada";
                    }
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


            ArrayList asignacionesLote = new ArrayList();


            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            if (P_IDPRODUCTO == null)
            {
                SeleccionarProducto(TBCommandLine.Text);
                RefrescarEstatusBotones();
                return false;
            }
            if (prod.IMANEJALOTE == "S" && (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL == null || !CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
                && m_Docto.ITIPODOCTOID != DBValues._DOCTO_TIPO_VENTA_FUTURO)
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

                decimal dEnProcesodeSalida = prod.IENPROCESODESALIDA;
                if (m_manejaAlmacen)
                    dEnProcesodeSalida = prodD.GetProcesoSalidaByAlmacen(prod.IID, (ALMACENEXISTENCIA != null ? ALMACENEXISTENCIA.Value : DBValues._ALMACEN_DEFAULT), null);



                if ((cantidad_inv - dEnProcesodeSalida) < P_CANTIDAD.Value && prod.IINVENTARIABLE == "S" && prod.INEGATIVOS != "S")
                {
                    MessageBox.Show("No hay existencia suficientes en la sucursal y almacen actual (considerando las que estan en proceso de salida)");
                    return false;
                }

                if (num_registros_inv > 1)
                {
                    WFPreguntaLote pl_ = new WFPreguntaLote(prod, P_CANTIDAD.Value, P_IDDOCTO.HasValue ? P_IDDOCTO.Value : 0, ALMACENEXISTENCIA);
                    pl_.ShowDialog();
                    P_LOTE = pl_.lote;
                    P_FECHAVENCE = pl_.fechaVence;
                    ArrayList asignaciones_ = pl_.asignaciones;

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


            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();

                //fTrans = null;


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


                        if (!pvd.EjecutarAddMOVTO(ref P_IDDOCTO, bufferLote.cantidad, P_IDPRODUCTO, P_PERSONAID, P_USERID, P_LOTE, US_SUPERVISORID, ALMACENID, SUCURSALID, P_FECHAVENCE, m_Docto.ITIPODOCTOID, SUCURSALTID, ALMACENTID, "N", P_TIPODIFERENCIAINVENTARIOID, P_PRECIO, P_DESCUENTO, iPos.CurrentUserID.CurrentCompania.IEM_CAJA, P_DOCTOREFID, ref P_MOVTOID, P_MOVTOREFID, strDescripcionComodin1, strDescripcionComodin2, strDescripcionComodin3, null, null, P_CARGOTARJPRECIOMANUAL, "S", fTrans))
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


                if (pvd.EjecutarAddMOVTO(ref P_IDDOCTO, P_CANTIDAD, P_IDPRODUCTO, P_PERSONAID, P_USERID, P_LOTE, US_SUPERVISORID, ALMACENID, SUCURSALID, P_FECHAVENCE, m_Docto.ITIPODOCTOID, SUCURSALTID, ALMACENTID, "N", P_TIPODIFERENCIAINVENTARIOID, P_PRECIO, P_DESCUENTO, iPos.CurrentUserID.CurrentCompania.IEM_CAJA, P_DOCTOREFID, ref P_MOVTOID, P_MOVTOREFID, strDescripcionComodin1, strDescripcionComodin2, strDescripcionComodin3, null,null, P_CARGOTARJPRECIOMANUAL, "S", fTrans))
                {

                    ObtenerDoctoDeBD((long)P_IDDOCTO, fTrans);

                    string strComentarioPromocionMontoMin = "";
                    if (!RecalcularPromocionMontoMinSiAplica(ref strComentarioPromocionMontoMin, fTrans))
                    {
                        fTrans.Rollback();
                        fConn.Close();
                        RefrescarEstatusBotones();
                        MessageBox.Show(strComentarioPromocionMontoMin);
                        return false;
                    }


                    if (razonPrecioDescuentoCajero != "")
                    {
                        pvd.AsignarRazonDescuentoCajero(razonPrecioDescuentoCajero, (int)P_MOVTOID, fTrans);
                    }

                    if(m_bActualizarComentarioAutorizacionCredito)
                    {
                        ProcesarCambioAutorizacion();
                    }

                    /*if (bHayDescripcionComodin)
                    {
                        pvd.CambiarDescripcionesComodin((long)P_MOVTOID, strDescripcionComodin1, strDescripcionComodin2, strDescripcionComodin3, fTrans);
                    }*/

                    /* if (bExecutePostInicio)
                     {
                         if (this.m_DoctoRef != null)
                         {
                             m_Docto.IDOCTOREFID = this.m_DoctoRef.IID;
                             m_Docto.IPERSONAID = this.m_DoctoRef.IPERSONAID;
                         }
                        

                         if(!pvd.VENTA_POSTINICIO(m_Docto,fTrans))
                         {

                             bResult = false;
                             fTrans.Rollback();
                             MessageBox.Show(pvd.IComentario);
                         }
                     }*/

                    //if (bResult)
                    //{


                    fTrans.Commit();


                    if (bActualizarPrecioDespuesDeCrearDocto)
                    {
                        bActualizarPrecioDespuesDeCrearDocto = false;

                        string strCambioPagoTarj = CambiarEnDoctoPagoConTarjeta();
                        if (!strCambioPagoTarj.Equals("S"))
                        {
                            MessageBox.Show(strCambioPagoTarj);
                        }
                    }

                    if (bActualizarPrecioPorCreditoDespuesDeCrearDocto)
                    {

                        bActualizarPrecioPorCreditoDespuesDeCrearDocto = false;

                        string strCambioPagoACredito = this.CambiarPAGOACREDITO();
                        if (!strCambioPagoACredito.Equals("S"))
                        {
                            MessageBox.Show(strCambioPagoACredito);
                        }
                    }



                    if(bActualizarObservacionesDespuesDeCrearDocto)
                    {

                        bActualizarObservacionesDespuesDeCrearDocto = false;

                        string strResultCambio = this.CambiarObservaciones();
                        if (!strResultCambio.Equals("S"))
                        {
                            MessageBox.Show(strResultCambio);
                        }
                    }
                    if(bActualizarContadoDespuesDeCrearDocto)
                    {
                        bActualizarContadoDespuesDeCrearDocto = false;

                        string strResultCambio = this.CambiarContado();
                        if (!strResultCambio.Equals("S"))
                        {
                            MessageBox.Show(strResultCambio);
                        }

                    }
                    if(bActualizarVentaEspecialDespuesDeCrearDocto)
                    {
                        bActualizarVentaEspecialDespuesDeCrearDocto = false;

                        string strResultCambio = this.CambiarEsVentaEspecial();
                        if (!strResultCambio.Equals("S"))
                        {
                            MessageBox.Show(strResultCambio);
                        }

                    }

                    bool cambioCotizacionEnrutada = false;
                    if (bActualizarCotizacionEnrutadaDespuesDeCrearDocto)
                    {
                        bActualizarCotizacionEnrutadaDespuesDeCrearDocto = false;

                        string strResultCambio = this.CambiarCotiEnrutada();
                        if (!strResultCambio.Equals("S"))
                        {
                            MessageBox.Show(strResultCambio);
                        }
                        cambioCotizacionEnrutada = true;
                    }
                    if (bActualizarFacturaElectronicaDespuesDeCrearDocto)
                    {

                        bActualizarFacturaElectronicaDespuesDeCrearDocto = false;

                        string strResultCambio = this.CambiarEsFacturaElectronica();
                        if (!strResultCambio.Equals("S"))
                        {
                            MessageBox.Show(strResultCambio);
                        }
                    }

                    if(m_Docto.ICOTI_ENRUTADA == "S")
                    {

                        string strResultCambio = this.SETESTADOREBAJA_COTIENRUTADA(cambioCotizacionEnrutada ? 0 : P_MOVTOID.Value);
                        if (!strResultCambio.Equals("S"))
                        {
                            MessageBox.Show(strResultCambio);
                        }
                        
                    }



                    if (!bDoctoExistentePreviamente)
                    {
                        AgregarVisitaDoctoSiEsNecesario((long)P_IDDOCTO, (long)CurrentUserID.CurrentCompania.IEM_CAJA, CurrentUserID.CurrentUser.IID);

                        if (m_bPermisoVentaStand && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA)
                            CambiarASubtipoDoctoStandSiEsNecesario(null);
                    }
                    


                    RefrescarGridVentas(bMantenPosicion);
                    FormatGrid();
                    GetTotalesPagosVenta();
                    RefreshTotalesVenta();
                    RefreshNumVenta();
                    //TBMensajesUser.Text = "";//"Exito"
                    //TBMensajesUser.BackColor = Color.Green;

                    //si se cambio la configuracion por empaque o caja y estan cajas/botellas
                    if (esEmpaque || esCaja)
                    {
                        formatCajasBotellasPiezasPorParametro();
                    }


                    this.TBCommandLine.Text = "";
                    this.TBCantidad.Text = (bEstaConfiguradoParaPiezasyCajas()) ? "0" : "1";
                    this.TBCajas.Text = "0";

                    this.TBPrecio.Text = "";
                    this.TBPrecioCaja.Text = "";
                    //this.TBPrecio.ReadOnly = !this.m_bPermisoCambiarPrecio;

                    this.TBDescuento.Text = "";
                    this.TBDescuento.ReadOnly = !this.m_bPermisoCambiarPrecioxDescuento;// true;
                    this.m_strUltimoProductoIngresado = prod.ICLAVE;


                    //si hace falta asignar supervisor
                    if (m_asignarsupervisor)
                    {
                        CDOCTOD doctoD = new CDOCTOD();
                        m_Docto.ISUPERVISORID = m_supervisor.IID;
                        doctoD.CambiarSupervisorAutorizacionDOCTOD(m_Docto, null);
                        

                        m_asignarsupervisor = false;
                    }
                    //}

                    if (m_manejaAlmacen)
                        this.ALMACENComboBox.Enabled = false;

                    postAsignarOrdenCompraSiAplica();
                    postAsignarRutaEmbarqueSiAplica();
                }
                else
                {
                    bResult = false;
                    fTrans.Rollback();
                    MessageBox.Show(pvd.IComentario);
                    //TBMensajesUser.Text = pvd.IComentario;
                    //TBMensajesUser.BackColor = Color.Red;
                }
                fConn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
            finally
            {
                fConn.Close();
            }
            RefrescarEstatusBotones();
            return bResult;
        }



        private decimal CantidadActualDeProductoEnVenta(long productoId)
        {
            decimal cantidad = 0;
            foreach (iPos.PuntoDeVenta.DSPuntoDeVentaAux2.GRIDPVRow row in dSPuntoDeVentaAux2.GRIDPV)
            {
                if (!row.IsPRODUCTOIDNull() && !row.IsCANTIDADNull() && row.PRODUCTOID == productoId)
                {
                    cantidad += row.CANTIDAD;
                }
            }

            return cantidad;
        }

        private void RefrescarGridVentas()
        {
            RefrescarGridVentas(false);
        }
        private void RefrescarGridVentas(bool mantenPosicion)
        {

            int iCurrentFirstRowIndex = gridPVDataGridView.FirstDisplayedScrollingRowIndex;


            this.gRIDPVTableAdapter2.Fill(this.dSPuntoDeVentaAux2.GRIDPV, (int)m_Docto.IID);
            FormatGrid();


            bool bEsVentaPendienteDesdeMovil = m_Docto != null && m_Docto.IID != 0 && m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_BORRADOR && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA && m_Docto.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_VENDMOVIL;
            if (bEsVentaPendienteDesdeMovil)
            {
                ColoreaPendienteMovilConPreciosAAutorizar();
            }

            if (gridPVDataGridView.Rows.Count > 0)
                gridPVDataGridView.CurrentCell = gridPVDataGridView.Rows[gridPVDataGridView.Rows.Count - 1].Cells["GVCANTIDAD"];

            GetTotalesPagosVenta();
            RefreshTotalesVenta();
            RefreshNumVenta();
            RefrescarTotalPiezas();

            //manten a posicion del grid si asi se requiere
            try
            {
                if (mantenPosicion && iCurrentFirstRowIndex >= 0)
                {
                    if (iCurrentFirstRowIndex < gridPVDataGridView.RowCount)
                    {
                        gridPVDataGridView.FirstDisplayedScrollingRowIndex = iCurrentFirstRowIndex;
                    }

                }
            }
            catch
            {

            }
            //fin manten

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

            foreach (PuntoDeVenta.DSPuntoDeVentaAux2.GRIDPVRow dr in this.dSPuntoDeVentaAux2.GRIDPV.Rows)
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





        public void LimpiarTotalesPagosVenta()
        {
            m_dMontoVenta = 0;
            m_dSumaImporte = 0;
            m_dMontoIva = 0;
            m_dDescuento = 0;

            m_montoVentaConVale = 0;
            m_montoVentaConValePorc1 = 0;
            m_montoVentaConValePorc2 = 0;
            m_montoVentaConValePorc3 = 0;
            m_montoVentaConValePorc4 = 0;
        }
        public void GetTotalesPagosVenta()
        {
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            CDOCTOBE doctoBuffer = pvd.ObtenerVenta(m_Docto, null);

            decimal tipoCambio = (((bool)m_Docto.isnull["ITIPOCAMBIO"] || m_Docto.ITIPOCAMBIO == 0) ? 1 : m_Docto.ITIPOCAMBIO);

            if (pvd.IComentario == "" || pvd.IComentario == null)
            {
                m_Docto = doctoBuffer;

                if (m_estadoVenta == (int)estadoVenta.e_Cerrada || m_estadoVenta == (int)estadoVenta.e_Cancelada ||
                   CurrentUserID.CurrentParameters.IVERSIONTOPEID != 2 || m_tipoTransaccion != tipoTransaccionV.t_venta )
                {
                    m_dMontoVenta = m_Docto.ITOTAL / tipoCambio;
                    m_dSumaImporte = (m_Docto.ISUBTOTAL + m_Docto.IIEPS) / tipoCambio;
                    m_dMontoIva = m_Docto.IIVA / tipoCambio;
                    m_dDescuento = m_Docto.IDESCUENTO / tipoCambio;
                }
                else
                {

                    m_dMontoVenta = 0;
                    m_dSumaImporte = 0;
                    m_dMontoIva = 0;
                    m_dDescuento = 0;
                    foreach (DataGridViewRow row in gridPVDataGridView.Rows)
                    {
                        if (row.Index == gridPVDataGridView.NewRowIndex)
                        {
                            continue;
                        }


                        try
                        {
                            this.m_dMontoVenta += Decimal.Parse(row.Cells["TOTALCONTOPE"].Value.ToString());
                        }
                        catch
                        {
                        }


                        try
                        {
                            this.m_dMontoIva += Decimal.Parse(row.Cells["IVACONTOPE"].Value.ToString());
                        }
                        catch
                        {
                        }


                        try
                        {
                            this.m_dSumaImporte += Decimal.Parse(row.Cells["IMPORTECONTOPESINIMP"].Value.ToString());
                        }
                        catch
                        {
                        }


                        try
                        {
                            this.m_dDescuento += Decimal.Parse(row.Cells["DESCUENTOCONTOPE"].Value.ToString());
                        }
                        catch
                        {
                        }
                    }
                }


                this.m_montoVentaConVale = 0;
                m_montoVentaConValePorc1 = 0;
                m_montoVentaConValePorc2 = 0;
                m_montoVentaConValePorc3 = 0;
                m_montoVentaConValePorc4 = 0;
                if (m_estadoVenta == (int)estadoVenta.e_Cerrada || m_estadoVenta == (int)estadoVenta.e_Cancelada)
                {
                    this.m_montoVentaConVale = m_Docto.ITOTAL;
                }
                else
                {

                    foreach (DataGridViewRow row in gridPVDataGridView.Rows)
                    {
                        if (row.Index == gridPVDataGridView.NewRowIndex)
                        {
                            continue;
                        }


                        try
                        {
                            this.m_montoVentaConVale += Decimal.Parse(row.Cells["TOTALVALE"].Value.ToString());
                        }
                        catch
                        {
                            try
                            {
                                this.m_montoVentaConVale += Decimal.Parse(row.Cells["IMPORTE"].Value.ToString());
                            }
                            catch
                            {
                            }
                        }


                        try
                        {
                            this.m_montoVentaConValePorc1 += Decimal.Parse(row.Cells["TOTALVALEDESC1"].Value.ToString());
                        }
                        catch
                        {
                            try
                            {
                                this.m_montoVentaConValePorc1 += Decimal.Parse(row.Cells["IMPORTE"].Value.ToString());
                            }
                            catch
                            {
                            }
                        }


                        try
                        {
                            this.m_montoVentaConValePorc2 += Decimal.Parse(row.Cells["TOTALVALEDESC2"].Value.ToString());
                        }
                        catch
                        {
                            try
                            {
                                this.m_montoVentaConValePorc2 += Decimal.Parse(row.Cells["IMPORTE"].Value.ToString());
                            }
                            catch
                            {
                            }
                        }


                        try
                        {
                            this.m_montoVentaConValePorc3 += Decimal.Parse(row.Cells["TOTALVALEDESC3"].Value.ToString());
                        }
                        catch
                        {
                            try
                            {
                                this.m_montoVentaConValePorc3 += Decimal.Parse(row.Cells["IMPORTE"].Value.ToString());
                            }
                            catch
                            {
                            }
                        }


                        try
                        {
                            this.m_montoVentaConValePorc4 += Decimal.Parse(row.Cells["TOTALVALEDESC4"].Value.ToString());
                        }
                        catch
                        {
                            try
                            {
                                this.m_montoVentaConValePorc4 += Decimal.Parse(row.Cells["IMPORTE"].Value.ToString());
                            }
                            catch
                            {
                            }
                        }



                    }
                }

            }
            else
            {
                MessageBox.Show("ERRORES: " + pvd.IComentario.Replace("%", "\n"));
                LimpiarTotalesPagosVenta();
            }


        }
        public void RefreshTotalesVenta()
        {

            decimal tipoCambio = (((bool)m_Docto.isnull["ITIPOCAMBIO"] || m_Docto.ITIPOCAMBIO == 0) ? 1 : m_Docto.ITIPOCAMBIO);

            this.TBPagosTotalVentaBig.Text = m_dMontoVenta.ToString("N2");
            this.TBTotal.Text = m_dMontoVenta.ToString("N2");
            this.TBSumaTotal.Text = m_dSumaImporte.ToString("N2");
            this.TBIva.Text = m_dMontoIva.ToString("N2");

            this.TBVale.Text = (m_montoVentaConVale / tipoCambio).ToString("N2");

            llenarUtilidad();
        }
        public void RefreshNumVenta()
        {
            if (this.m_Docto != null)
            {
                if (!(bool)this.m_Docto.isnull["IFOLIO"] == false)
                {
                    this.LBVenta.Text = m_Docto.IFOLIO.ToString();
                }
                else
                {
                    this.LBVenta.Text = "...";
                }
            }
            else
            {
                this.LBVenta.Text = "...";
            }
        }



        private bool CancelarPagosConPinPadHechosCurrentDocto(FbTransaction st)
        {
            if (!CancelarPagosConPinPadHechosCurrentDocto_Bancomer(st))
                return false;

            if (!CancelarPagosConPinPadHechosCurrentDocto_Verifone(st))
                return false;

            return true;
        }

        private bool CancelarPagosConPinPadHechosCurrentDocto_Bancomer(FbTransaction st)
        {

            if (m_Docto.IPAGOBANCOMERAPLICADO == null || m_Docto.IPAGOBANCOMERAPLICADO != "S")
            {
                return true;
            }

            CBANCOMERPARAMD bancomerParamD = new CBANCOMERPARAMD();
            CBANCOMERPARAMBE bancomerParamBE = new CBANCOMERPARAMBE();
            bancomerParamBE.IDOCTOID = m_Docto.IID;
            bancomerParamBE.IESTADOTRANSACCIONID = 1;
            bancomerParamBE.ITIPOTRANSACCION = "001";

            List<CBANCOMERPARAMBE> listaPagosSimple = bancomerParamD.seleccionarBANCOMERPARAM_PORDOCTO_Simple(bancomerParamBE, st);

            if (listaPagosSimple == null || listaPagosSimple.Count == 0)
            {
                //MessageBox.Show("No se pudo traer la lista de pagos con tarjeta por pinpad");
                return true;
            }

            if (listaPagosSimple.Count > 1)
            {
                MessageBox.Show("Como es mas de un pago con tarjeta primero vaya a la seccion de abonos con este numero de folio y cancela manualmente los pagos con tarjeta hechos con pinpad");
                return false;
            }

            long bancomerParamIdCancelacion = 0;
            if (!PagoBancomerHelper.Cancelar(ref m_Docto, listaPagosSimple[0].IID, ref bancomerParamIdCancelacion, st))
            {
                MessageBox.Show("Hubo un error al intentar cancelar el pago por pin pad " + PagoBancomerHelper.strResTransaccion);
                return false;

            }
            PagoBancomerHelper.ImprimirVoucher(bancomerParamIdCancelacion, true, true);


            return true;
        }


        private bool CancelarPagosConPinPadHechosCurrentDocto_Verifone(FbTransaction st)
        {

            CVERIFONEPAYMENTD verifonePaymentD = new CVERIFONEPAYMENTD();
            CVERIFONEPAYMENTBE verifonePaymentBE = new CVERIFONEPAYMENTBE();
            verifonePaymentBE.IDOCTOID = m_Docto.IID;
            verifonePaymentBE.IESTADOTRANSACCIONID = 1;
            verifonePaymentBE.ITIPOTRANSACCION = "001";

            List<CVERIFONEPAYMENTBE> listaPagosSimple = verifonePaymentD.seleccionarVERIFONEPAYMENT_PORDOCTO_Simple(verifonePaymentBE, st);

            if (listaPagosSimple == null || listaPagosSimple.Count == 0)
            {
                //MessageBox.Show("No se pudo traer la lista de pagos con tarjeta por pinpad");
                return true;
            }

            if (listaPagosSimple.Count > 1)
            {
                MessageBox.Show("Como es mas de un pago con tarjeta primero vaya a la seccion de abonos con este numero de folio y cancela manualmente los pagos con tarjeta hechos con pinpad");
                return false;
            }

            long verifonePaymentIdCancelacion = 0;
            string strResTransaction = "";
            if (!PagoVerifoneHelper.Cancelar(ref m_Docto, listaPagosSimple[0].IID, ref verifonePaymentIdCancelacion, ref strResTransaction, st))
            {
                MessageBox.Show("Hubo un error al intentar cancelar el pago por pin pad " + PagoBancomerHelper.strResTransaccion);
                return false;

            }

            return true;
        }

        private bool MandarReasignarCorteCancelacionSiAplica()
        {

            if (m_bTieneDerechoAsignarOtroCorteCanc && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA  && m_Docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_BORRADOR)
            {
                if (MessageBox.Show("Desea asignar esta cancelacion a otro corte diferente?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CDOCTOD doctoD = new CDOCTOD();
                    CDOCTOBE doctoBECanc = new CDOCTOBE();
                    doctoBECanc.ITIPODOCTOID = DBValues._DOCTO_TIPO_CANCELACION;
                    doctoBECanc.IDOCTOREFID = m_Docto.IID;

                    doctoBECanc = doctoD.SeleccionarXTIPOYREFID(doctoBECanc, null);

                    if (doctoBECanc != null)
                    {
                        WFAsignarDevolucionACorte rp = new WFAsignarDevolucionACorte(doctoBECanc);
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                    }
                }
            }

            return true;
        }

        private void BTCancelarVenta_Click(object sender, EventArgs e)
        {
            CancelarVentaActual(false,true);
        }
        private bool CancelarVentaActual(bool bAlternativeCancelation = false, bool bCancelacionExplicita = false)
        {

            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            CUSUARIOSD usersD = new CUSUARIOSD();

            //esto es por el caso de sustituciones
            m_doctoSustitutoId = 0;

            if (m_estadoVenta == (int)estadoVenta.e_Cancelada)
                return false;

            if ((bool)m_Docto.isnull["IID"])
                return false;




            if ((m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_COMPLETO || m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_BORRADOR) && (m_Docto.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_RECARGA || m_Docto.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_PAGOSERVICIO))
            {
                MessageBox.Show("Las recargas y pago de servicios no se pueden cancelar ni borrar");
                return false;
            }


            bool bVentaVacia = false;
            if(gridPVDataGridView.Rows.Count == 0)
            {
                bVentaVacia = true;
            }

            bool bCancelarVenta = bVentaVacia;

            if(!bVentaVacia && (m_Docto.ICOTI_ENRUTADA != "S" || bCancelacionExplicita))
            {
                if (MessageBox.Show("Quiere cancelar la venta?", "Cancelar la venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bCancelarVenta = true;
                }
           }



            if (!bCancelarVenta)
            {

                //movil
                if (m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_BORRADOR && CurrentUserID.CurrentParameters.IESVENDEDORMOVIL != null && CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
                {
                    FinalizarVisitaPedido(false); // finaliza visita si es vendedor movil
                }

                return false;
            }


            if ((int)estadoVenta.e_Iniciado != m_estadoVenta && (int)estadoVenta.e_SinIniciar != m_estadoVenta)
            {

                WFPreguntaAutorizacion ps2 = new WFPreguntaAutorizacion();
                ps2.ShowDialog();
                CPERSONABE userBE = ps2.m_userBE;
                CPERSONABE supervisorBE = ps2.m_supervisorBE;
                bool bPassValido = ps2.m_bPassValido;
                //bool bIsSupervisor = ps2.m_bIsSupervisor;
                //bool bIsAdministrador = ps2.m_bIsAdministrador;
                ps2.Dispose();
                GC.SuppressFinalize(ps2);

                if (!bPassValido)
                    return false;



                Boolean bTieneDerechoCancelarUnMismoDia = usersD.UsuarioTienePermisos((int)userBE.IID, (int)DBValues._DERECHO_APLICARCANC_MISMODIA, null) || usersD.UsuarioTienePermisos((int)userBE.IID, (int)DBTN.DERECHO_ELIMINAR_VENTA_DELDIA, null) ;
                Boolean bTieneDerechoCancelarUnDiaAnterior = usersD.UsuarioTienePermisos((int)userBE.IID, (int)DBValues._DERECHO_APLICARCANC_DIAANTERIOR, null) || usersD.UsuarioTienePermisos((int)userBE.IID, (int)DBTN.DERECHO_ELIMINAR_VENTA_DIASATRAS, null);
                Boolean bTieneDerechoCancelarCualquierDiaAnterior = usersD.UsuarioTienePermisos((int)userBE.IID, (int)DBValues._DERECHO_APLICARCANC_CUALQUIERDIAANTES, null) || usersD.UsuarioTienePermisos((int)userBE.IID, (int)DBTN.DERECHO_ELIMINAR_VENTA_DIASATRAS, null);


                if (m_Docto.IFECHA == DateTime.Today && !bTieneDerechoCancelarUnMismoDia)
                {
                    MessageBox.Show("Ese usuario no tiene permiso para cancelar esta transaccion ");
                    return false;
                }

                if (m_Docto.IFECHA == DateTime.Today.AddDays(-1) && !bTieneDerechoCancelarUnDiaAnterior && !bTieneDerechoCancelarCualquierDiaAnterior)
                {
                    MessageBox.Show("No tiene permiso para cancelar esta transaccion de la fecha de ayer");
                    return false;
                }

                if (m_Docto.IFECHA < DateTime.Today.AddDays(-1) && !bTieneDerechoCancelarCualquierDiaAnterior)
                {

                    MessageBox.Show("No tiene permiso para cancelar esta transaccion una fecha anterior a ayer");
                    return false;
                }


                //if (!bIsSupervisor)
                //{
                //    MessageBox.Show("El usuario no es un supervisor");
                //    return false;
                //}


                //if (bIsSupervisor && m_Docto.IFECHA < DateTime.Today.AddDays(-1) && !bIsAdministrador)
                //{
                //    MessageBox.Show("Un supervisor solo puede eliminar ventas del dia actual y anterior. Se requiere un administrador para borrar de fechas previas");
                //    return false;
                //}

                //CUSUARIOSD usuariosD = new CUSUARIOSD();
                //if (m_Docto.IFECHA < DateTime.Today.AddDays(-1))
                //{
                //    if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_ELIMINAR_VENTA_DIASATRAS, null))
                //    {
                //        MessageBox.Show("Este usuario no puede eliminar ventas de dias anteriores al dia de ayer");
                //        return false;
                //    }
                //}
                //else
                //{
                //    if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_ELIMINAR_VENTA_DELDIA, null))
                //    {

                //        MessageBox.Show("Este usuario no puede eliminar ventas ");
                //        return false;
                //    }
                //}
            }
            else
            {

                if ( !bVentaVacia && CurrentUserID.CurrentParameters.IREQAUTCANCELARCOTI != null && CurrentUserID.CurrentParameters.IREQAUTCANCELARCOTI.Equals("S"))
                {
                    Boolean bTieneDerechoAEliminarCotizacion = usersD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_CANCELAR_COTI, null);

                    if (!bTieneDerechoAEliminarCotizacion)
                    {
                        WFPreguntaAutorizacion ps2 = new WFPreguntaAutorizacion(false);
                        ps2.ShowDialog();
                        CPERSONABE userBE = ps2.m_userBE;
                        CPERSONABE supervisorBE = ps2.m_supervisorBE;
                        bool bPassValido = ps2.m_bPassValido;
                        bool bIsSupervisor = ps2.m_bIsSupervisor;
                        bool bIsAdministrador = ps2.m_bIsAdministrador;
                        ps2.Dispose();
                        GC.SuppressFinalize(ps2);

                        if (!bPassValido)
                            return false;

                        bTieneDerechoAEliminarCotizacion = usersD.UsuarioTienePermisos((int)supervisorBE.IID, (int)DBValues._DERECHO_CANCELAR_COTI, null);

                        if (!bTieneDerechoAEliminarCotizacion)
                        {
                            MessageBox.Show("El usuario para supervisar ingresado no tiene derecho a aprobar eliminaciones de cotizaciones");
                            return false;
                        }

                    }
                }
            }


            // antes de cancelar venta movil , cancelarla en el webservice


            if (m_Docto.ITRASLADOAFTP == DBValues._DB_BOOLVALUE_SI && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTAMOVIL)
            {

                if (!MovilCancelVenta())
                    return false;

                CDOCTOD doctoD = new CDOCTOD();
                m_Docto.ITRASLADOAFTP = DBValues._DB_BOOLVALUE_NO;
                doctoD.CambiarEnviadoFTPDOCTOD(m_Docto, null);
            }



            CDOCTOD vData = new CDOCTOD();
            m_Docto = vData.seleccionarDOCTO(m_Docto, null);



            // si es un traspaso de tipo franquicia pedir que se cancele la venta
            if ((m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_PEDIDO_TRASPASO_SALIDA) &&
                (m_Docto.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_TRASPASOFRANQUICIA || m_Docto.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_TRASPASOFRANQUICIA_SALIDA))
            {
                CDOCTOBE doctoRefBE = new CDOCTOBE();
                doctoRefBE.IID = m_Docto.IDOCTOREFID;
                doctoRefBE = vData.seleccionarDOCTO(doctoRefBE, null);

                string strCancelar = "Debe cancelar la venta relacionada con este traslado. ";

                if (doctoRefBE != null)
                {
                    strCancelar += "Folio : " + doctoRefBE.IFOLIO.ToString();
                }
                MessageBox.Show(strCancelar);

                return false;
            }

            if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA_FUTURO && m_Docto.IVENTAFUTUID > 0)
            {
                MessageBox.Show("Una venta a futuro que ya fue aplicada aunque sea parcialmente solo puede finalizarse ( en el listado de pendientes) , mas no cancelarse");
                return false;
            }

            

            switch (m_Docto.ITIPODOCTOID)
            {
                case DBValues._DOCTO_TIPO_VENTA:
                case DBValues._DOCTO_TIPO_TRASPASO_ENVIO:
                case DBValues._DOCTO_TIPO_PEDIDO_TRASPASO_SALIDA:
                case DBValues._DOCTO_TIPO_VENTAMOVIL:
                case DBValues._DOCTO_TIPO_VENTA_FUTURO:
                    {






                        long statusDoctoId = m_Docto.IESTATUSDOCTOID;
                        bool bManejoAlternativoCancelacion = false;
                        bool bCancelacionXSustitucion = false;

                        if (m_Docto.IESFACTURAELECTRONICA != null)
                        {
                            if (m_Docto.IESFACTURAELECTRONICA == "S" && m_Docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_BORRADOR)
                            {

                                if (CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("3.3") || CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0"))
                                {

                                    if (!vData.PreCancelarVentaD(m_Docto, CurrentUserID.CurrentUser, null))
                                    {
                                        MessageBox.Show(vData.IComentario);
                                        return false;
                                    }

                                    decimal limiteCancelacion = CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0") ? DBValues._LIMITE_CANCELACION_40 : DBValues._LIMITE_CANCELACION_33;

                                    if ((m_Docto.ITOTAL > limiteCancelacion && m_Docto.ITIMBRADOFECHAFACTURA.AddDays(DBValues._LIMITE_DIASCANCELACION_33).CompareTo(DateTime.Today) < 0) || m_Docto.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_SUSTITUCION || bAlternativeCancelation)
                                    {
                                        bManejoAlternativoCancelacion = true;

                                        WFCancelacionAltSeleccion wfc = new WFCancelacionAltSeleccion();
                                        wfc.ShowDialog();
                                        string strSeleccionCancelacion = wfc.strSeleccionCancelacion;
                                        wfc.Dispose();
                                        GC.SuppressFinalize(wfc);

                                        switch (strSeleccionCancelacion)
                                        {
                                            case "NotaCredito":
                                                CancelaFacturaXNotaCredito();
                                                return true;
                                            case "Sustitucion":
                                                bCancelacionXSustitucion = true;
                                                break;
                                            case "Salir":
                                                return false;
                                        }

                                        //MessageBox.Show("La cancelacion alternativa se haria aqui, pero aun no esta implementada");
                                        //return false;
                                    }
                                }


                                if (!bManejoAlternativoCancelacion)
                                {
                                    WFFacturaElectronica fe = new WFFacturaElectronica(this.m_Docto, CurrentUserID.CurrentParameters, WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_CANCELAR, this.m_DoctoRef, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
                                    CUSUARIOSD usuariosD = new CUSUARIOSD(); fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
                                    fe.ShowDialog();
                                    bool facturacionCancelada = fe.m_facturacionCancelada;
                                    fe.Dispose();
                                    GC.SuppressFinalize(fe);
                                    if (!facturacionCancelada)
                                    {


                                        if (MessageBox.Show("No se pudo cancelar la factura electronica en el SAT desde el sistema. Como la venta actual fue facturada electronicamente, tendra que cancelarla tambien en el SAT. Desea continuar con la cancelacion en el sistema?", "Cancelar la transaccion actual", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                                            return false;
                                    }
                                }
                                /*
                                if (MessageBox.Show("Como la venta actual fue facturada electronicamente, tendra que cancelarla tambien en el SAT. Desea continuar?", "Cancelar la transaccion actual", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                                    return false;
                                 */
                            }

                        }



                        try
                        {


                            //mandar cancelar el pago con tarjeta pinpad ( si es mas de uno, tendra que ir a cancelarlos uno por uno a la seccion de abonos)
                            if (!CancelarPagosConPinPadHechosCurrentDocto(null))
                            {
                                return false;
                            }

                            if ((CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("3.3") || CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0")) && bCancelacionXSustitucion )
                            {
                                if (!CancelaFacturaXSustitucion())
                                {
                                    return false;
                                }
                            }
                            else
                                pvd.CancelarVenta(m_Docto, CurrentUserID.CurrentUser, null);




                            if (pvd.IComentario == "" || pvd.IComentario == null)
                            {
                                HiloExistencias._IFLAGENVIAREXISTENCIASEVENTOS++;
                                MessageBox.Show("Venta cancelada");

                                if (statusDoctoId != DBValues._DOCTO_ESTATUS_BORRADOR && 
                                    (CurrentUserID.CurrentParameters.IIMPR_CANC_VENTA == null || !CurrentUserID.CurrentParameters.IIMPR_CANC_VENTA.Equals("N") ||
                                      m_Docto.IESFACTURAELECTRONICA == "S")  )
                                {
                                    PosPrinter.ImprimirTicket(m_Docto.IID);
                                }

                                MandarReasignarCorteCancelacionSiAplica();


                                //movil
                                if (m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_BORRADOR && CurrentUserID.CurrentParameters.IESVENDEDORMOVIL != null && CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
                                {
                                    FinalizarVisitaPedido(true); // finaliza visita si es vendedor movil
                                }


                                if (loadedFiles.Count > 0 && loadedFilesCerrada)
                                {
                                    CARCHIVOSADJUNTOSBE adjDel = new CARCHIVOSADJUNTOSBE();
                                    CARCHIVOSADJUNTOSD adjuntarDel = new CARCHIVOSADJUNTOSD();
                                    adjDel.IDOCTOID = m_Docto.IID;
                                    if (adjuntarDel.BorrarARCHIVOSADJUNTOSDPorDOCTOID(adjDel, null))
                                    {
                                        foreach (string laodF in loadedFiles)
                                        {
                                            File.Delete(laodF);
                                        }
                                        limpiarLoadedFiles();
                                    }
                                }
                                else if (loadedFiles.Count > 0 && !loadedFilesCerrada)
                                {
                                    loadedFiles.Clear();
                                }

                                PreguntaComentarioCancelacion(m_Docto.IID, CurrentUserID.CurrentUser.IID, null);
                                IrANuevaVenta();

                                if((CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("3.3") || CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0")) && m_doctoSustitutoId != 0)
                                {

                                    if (MessageBox.Show("Se hizo una sustitucion. Desea abrir la venta que sustituyo a la anterior? ",
                                                        "Confirmacion",
                                                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                                    {

                                        
                                        AbrirVentasCerradasYDevoluciones((int)m_doctoSustitutoId, "");
                                    }
                                    m_doctoSustitutoId = 0;
                                }
                            }
                            else
                            {
                                MessageBox.Show("ERRORES: " + pvd.IComentario.Replace("%", "\n"));
                                return false;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ocurrio un error " + ex.Message + ex.StackTrace);
                            return false;
                        }
                        finally
                        {
                        }

                    }
                    break;

                case DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO:
                    {
                        long statusDoctoId = m_Docto.IESTATUSDOCTOID;
                        long doctoIDCancelacion = 0;
                        //pvd.CancelarDevolucion(m_Docto, ref doctoIDCancelacion,null);
                        if (pvd.CancelarDevolucion(m_Docto, CurrentUserID.CurrentUser, ref doctoIDCancelacion, null))
                        {


                            /*this.m_tipoTransaccion = tipoTransaccionV.t_cancelaciondevolucion;
                            this.m_DoctoRef = this.m_Docto;

                            m_Docto = new CDOCTOBE();
                            m_Docto.IID = doctoIDCancelacion;
                            CDOCTOD vData = new CDOCTOD();
                            m_Docto = vData.seleccionarDOCTO(m_Docto, null);
                            
                            WFPagosBasico wp = new WFPagosBasico(m_Docto,m_Caja,false,0,this.m_DoctoRef,this.m_tipoTransaccion,"N",false);
                            wp.ShowDialog();
                            if (wp.m_bPagoCompleto)
                            {
                                CerrarVenta();
                            }*/
                            IrANuevaVenta();
                        }
                        else
                        {
                            MessageBox.Show("ERRORES: " + pvd.IComentario.Replace("%", "\n"));
                            return false;
                        }
                    }
                    break;

                case DBValues._DOCTO_TIPO_VENTAAPARTADO:
                    {
                        long statusDoctoId = m_Docto.IESTATUSDOCTOID;
                        long doctoIDCancelacion = 0;
                        if (pvd.CancelarApartado(m_Docto, CurrentUserID.CurrentUser, ref doctoIDCancelacion, null))
                        {


                            /*this.m_tipoTransaccion = tipoTransaccionV.t_cancelacionapartado;
                            this.m_DoctoRef = this.m_Docto;

                            m_Docto = new CDOCTOBE();
                            m_Docto.IID = doctoIDCancelacion;
                            CDOCTOD vData = new CDOCTOD();
                            m_Docto = vData.seleccionarDOCTO(m_Docto, null);

                            WFPagosBasico wp = new WFPagosBasico(m_Docto, m_Caja, false, 0, this.m_DoctoRef, this.m_tipoTransaccion, "S",false);
                            wp.ShowDialog();
                            if (wp.m_bPagoCompleto)
                            {
                                CerrarVenta();
                            }*/
                            IrANuevaVenta();
                        }
                        else
                        {
                            MessageBox.Show("ERRORES: " + pvd.IComentario.Replace("%", "\n"));
                            return false;
                        }
                    }
                    break;





                case DBValues._DOCTO_TIPO_TRASPASO_ALMACEN:
                    {
                        long statusDoctoId = m_Docto.IESTATUSDOCTOID;
                        if (pvd.CancelarTraspasoAlmacenD(m_Docto, null))
                        {
                            IrANuevaVenta();
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



        private void ChecarAvisoRetiroCaja()
        {
            if (bTieneDerechoARetirosDeCaja && CurrentUserID.CurrentParameters.IMANEJARRETIRODECAJA == "S" && CurrentUserID.CurrentParameters.IMONTORETIROCAJA > 0 && CurrentUserID.CurrentParameters.IINTENTOSRETIROCAJA > 0)
            {
                CRETIRODECAJAD retiroD = new CRETIRODECAJAD();
                decimal totalCaja = 0.0m;
                if (retiroD.RETIRO_MONTOSUPEROMAXIMO(CurrentUserID.CurrentUser.IID, ref totalCaja, null))
                {
                    if (totalCaja >= CurrentUserID.CurrentParameters.IMONTORETIROCAJA * 2)
                        CurrentUserID.RechazoRetiroCajaCuenta = CurrentUserID.CurrentParameters.IINTENTOSRETIROCAJA;
                    do
                    {

                        if (MessageBox.Show("Parece que ya hay mas dinero del recomendado en caja, ¿Quiere hacer retiro de caja? ",
                                            "Confirmacion",
                                            MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            WFRetiroCaja wf = new WFRetiroCaja();
                            wf.ShowDialog();
                            wf.Dispose();
                            GC.SuppressFinalize(wf);
                        }

                        if (retiroD.RETIRO_MONTOSUPEROMAXIMO(CurrentUserID.CurrentUser.IID, ref totalCaja, null))
                        {
                            CurrentUserID.RechazoRetiroCajaCuenta++;
                        }
                        else
                        {
                            CurrentUserID.RechazoRetiroCajaCuenta = 0;
                        }

                    }
                    while (CurrentUserID.RechazoRetiroCajaCuenta >= CurrentUserID.CurrentParameters.IINTENTOSRETIROCAJA);


                }
                else
                {
                    CurrentUserID.RechazoRetiroCajaCuenta = 0;
                }
            }
        }





        private void ChecarRecargasServiciosInconclusos()
        {
            if (CurrentUserID.CurrentParameters.ISERVICIOSEMIDA == "S" && CurrentUserID.CurrentParameters.IHABPAGOSERVEMIDA == "S")
            {
                int iCuentaInconclusos = 0;
                CEMIDAREQUESTD emidaD = new CEMIDAREQUESTD();
                if (emidaD.EMIDA_VENTASCORTE_INCONCLUSAS(CurrentUserID.CurrentUser.IID, ref iCuentaInconclusos, null))
                {

                    if (iCuentaInconclusos > 0)
                    {
                        MessageBox.Show("Hay " + iCuentaInconclusos.ToString() + " recargas y/o pago de servicios inconclusos en su corte? Por favor vaya a ventas pendientes y terminelos de pagar");

                    }
                }
            }

        }

        private void IrANuevaVenta()
        {
            bool bHayDoctoMostrandose = m_Docto != null && m_Docto.IID > 0;

            FinalizarVisitaDoctoActual();

            ResetearVariablesForm();
            ChecarActualizacionesPrecios();
            LimpiarTotalesPagosVenta();
            RefreshTotalesVenta();
            RefreshNumVenta();
            this.dSPuntoDeVentaAux2.GRIDPV.Clear();
            FormatGrid();
            this.dSPuntoVenta.DETALLE_DE_PAGO.Clear();
            this.TBCommandLine.Text = "";
            //this.TBMensajesUser.Text = "";
            //this.TBMensajesUser.BackColor = Color.Green;
            this.LBOperacion.Text = "Venta";
            this.TBCliente.Text = "mostrador";
            //this.lblClienteSuc.Text = "Cliente:";
            this.BTCliente.Text = "Cliente:";
            this.BTCliente.Enabled = true;
            this.TBCliente.Enabled = true;
            m_ClienteId = DBValues._CLIENTEMOSTRADOR;
            m_supervisor = null;

            this.LBVenta.Text = "...";
            LimpiarCurrentItemDisplay();
            this.TBCommandLine.Focus();
            this.TBCommandLine.Enabled = true;
            RefrescarEstatusBotones();
            this.TBPrecio.Text = "";
            this.TBPrecioCaja.Text = "";
            //this.TBPrecio.ReadOnly = !this.m_bPermisoCambiarPrecio;

            this.TBDescuento.Text = "";
            this.TBDescuento.ReadOnly = !this.m_bPermisoCambiarPrecioxDescuento;//true;

            lbClieCiudad.Text = "";
            lbClieColonia.Text = "";
            lbClieCP.Text = "";
            lbClieDom.Text = "";
            lbClieEstado.Text = "";
            lbClieNombre.Text = "";
            lbClieRFC.Text = "";
            lbClieTel.Text = "";


            //this.ComboVendedorFinal.Enabled = true;
            //this.ComboVendedorFinal.SelectedIndex = -1;

            this.VENDEDORIDTextBox.Enabled = true;
            this.VENDEDORIDTextBox.Text = "";




            lbTotalPiezas.Text = "0.00";

            this.LBFolioFacturaElectronica.Text = "...";
            this.LBSerieFacturaElectronica.Text = "...";


            this.TBCantidad.Text = (bEstaConfiguradoParaPiezasyCajas()) ? "0" : "1";
            this.TBCajas.Text = "0";

            LBMONEDA.Text = "Moneda nacional";

            this.lblTextoAuxiliar.Text = "";
            NOTAPAGOTextBox.Text = "";

            /*
            if (m_manejaAlmacen)
            {
                this.ALMACENComboBox.Enabled = true;
                this.ALMACENComboBox.SelectedIndex = -1;
            }*/
            SetDefaultAlmacenEstatus();
            m_almacenTID = 0;
            CBXPagoConTarjeta.SelectedIndex = 0;
            CBACredito.Checked = false;

            m_rutaEmbarqueId = 0;
            lblRutaEmbarque.Text = "...";


            checarCambiosPrecioMovil();

            ChecarAvisoRetiroCaja();

            ChecarRecargasServiciosInconclusos();

            btDomicilioEntrega.Enabled = false;

            if (m_bDoctoUnico && bHayDoctoMostrandose)
            {
                this.Close();
            }


            this.PonerHabilitacionPagoTarjeta();
            MostrarAlertaNuevosComprasSiAplica();

            this.btnVentaAFuturo.Text = "Venta a futuro";



            PonerHabilitacionObservacionesContadoFactura();
            this.CBFactura.Checked = false;
            this.CBContado.Checked = false;
            this.CBEspecial.Checked = false;
            this.CBCotizacionEnrutada.Checked = false;
            this.CBCotizacionEnrutada.Enabled = true;
            ObservacionesTextBox.Text = "";
            bActualizarObservacionesDespuesDeCrearDocto = false;
            bActualizarContadoDespuesDeCrearDocto = false;
            bActualizarFacturaElectronicaDespuesDeCrearDocto = false;

            this.CBCotizacionEnrutada.Visible = m_busuarioTienePermisoMarcarCotiEnrutada;

        }



        private void checarCambiosPrecioMovil()
        {

            if (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
            {
                if (ImportaFtpMovil.ConexionAInternet())
                {
                    try
                    {

                        if (CurrentUserID.CurrentParameters.IPRECIOSMOVILANTESVENTA.Equals("S"))
                        {
                            if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 3 || CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 4)
                            {
                                ImportaDesdeFtp iftp = new ImportaDesdeFtp();

                                if (iftp.HayArchivoPreciosDeFtpADescargar())
                                {

                                    if (MessageBox.Show("Hay cambio de precios. Desea actualizar los precios?", "Actualizacion de precios", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        WFImportarPreciosNuevosMovil3 wf = new WFImportarPreciosNuevosMovil3(true);
                                        wf.ShowDialog();
                                        wf.Dispose();
                                        GC.SuppressFinalize(wf);
                                    }
                                }
                            }
                            else
                            {
                                if (ImportaFtpMovil.GetUltimaModificacionPrecioMovil().AddMilliseconds(-999) > CurrentUserID.CurrentParameters.ILASTCHANGEPRECIOPROD)
                                {
                                    if (MessageBox.Show("Hay cambio de precios. Desea actualizar los precios?", "Actualizacion de precios", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {

                                        WFImportarPreciosNuevosMovil wf = new WFImportarPreciosNuevosMovil(true);
                                        wf.ShowDialog();
                                        wf.Dispose();
                                        GC.SuppressFinalize(wf);
                                    }
                                }
                            }
                        }


                        if (CurrentUserID.CurrentParameters.IPENDMOVILANTESVENTA.Equals("S"))
                        {


                            WFImportarPendientesMovilcs envioPendientes = new WFImportarPendientesMovilcs(false);
                            envioPendientes.ShowDialog();
                            envioPendientes.Dispose();
                            GC.SuppressFinalize(envioPendientes);
                        }


                    }
                    catch
                    {

                    }
                }
            }
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

        private void limpiarLoadedFiles()
        {
            loadedFiles.Clear();
            loadedFilesDate = new DateTime();
            loadedFilesWorkHours = 0;
            loadedFilesCerrada = false;
        }

        private void NuevoRegistro()
        {
            if ((!(bool)m_Docto.isnull["IID"])
                && (m_estadoVenta != (int)estadoVenta.e_Cerrada && m_estadoVenta != (int)estadoVenta.e_Cancelada)
                )
            {

                if (CurrentUserID.CurrentParameters.IPREGUNTACANCELACOTIZACION != null && CurrentUserID.CurrentParameters.IPREGUNTACANCELACOTIZACION.Equals("S"))
                {
                    if (!CancelarVentaActual())
                        IrANuevaVenta();
                }
                else if (gridPVDataGridView.Rows.Count == 0)
                {
                    CPuntoDeVentaD pvd = new CPuntoDeVentaD();
                    pvd.CancelarVenta(m_Docto, CurrentUserID.CurrentUser, null);
                    IrANuevaVenta();
                }
                else
                {
                    IrANuevaVenta();
                }


            }
            else
            {
                IrANuevaVenta();
            }


            limpiarLoadedFiles();
        }



        private void BTPasarANueva_Click(object sender, EventArgs e)
        {
            PasarANueva();
        }

        private void PasarANueva()
        {
            if (BTPasarANueva.Enabled)
            {
                this.btnReimprimirVoucherBanc.Enabled = false;
                this.btnReimprimirVoucherBanc.Visible = false;
                NuevoRegistro();
            }
        }

        private void BTAbrirVenta_Click(object sender, EventArgs e)
        {



            PrepararAbrirOtraPantalla();

            AbrirVenta();
            RefrescarEstatusBotones();
        }


        private void AbrirVentaXId(long docId)
        {

            m_Docto.IID = docId;
            CDOCTOD vData = new CDOCTOD();
            m_Docto = vData.seleccionarDOCTO(m_Docto, null);



            RefrescarGridVentas();
            limpiarLoadedFiles();

            if (m_manejaAlmacen)
            {
                this.ALMACENComboBox.Enabled = false;
                if (!(bool)m_Docto.isnull["IALMACENID"])
                    this.ALMACENComboBox.SelectedDataValue = m_Docto.IALMACENID;
                else
                    this.ALMACENComboBox.SelectedIndex = -1;
            }

            llenarDatosGeneralesDocto();

            this.CBCotizacionEnrutada.Visible = m_busuarioTienePermisoMarcarCotiEnrutada &&
                                                m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA;
            this.CBCotizacionEnrutada.Enabled = m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_BORRADOR;

            if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ALMACEN)
                ModoTraspasoAlmacen();
        }

        private void AbrirVenta(bool porSurtir = false)
        {
            IrANuevaVenta();
            //GeneralLookUp look = new GeneralLookUp("select * from VENTAS where GV_ESTATUS = '" + CVENTASD.strStatusAbierta + @"'", "VENTAS");
            WFLOOKUPVENTAS look = new WFLOOKUPVENTAS();
            look.m_soloPorSurtir = porSurtir;
            look.ShowDialog();
            DataRow dr = look.m_rtnDataRow;
            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                long iDoctoSelectedId = long.Parse(dr[0].ToString());
                if (!VerificarUnicaVisitaXDocto(iDoctoSelectedId, (long)CurrentUserID.CurrentCompania.IEM_CAJA, CurrentUserID.CurrentUser.IID))
                {
                    return;
                }

                AbrirVentaXId(int.Parse(dr[0].ToString()));


            }
        }



        private bool bProductoSoloManejaKG(CPRODUCTOBE prod)
        {
            return prod != null && prod.IPZACAJA == 0 && prod.IUNIDAD != null && prod.IUNIDAD.Trim().ToUpper().Equals("KG");
        }

        private bool bProductoManejaKG(CPRODUCTOBE prod)
        {
            return prod != null && prod.IUNIDAD != null && prod.IUNIDAD.Trim().ToUpper().Equals("KG");
        }



        private void TBCommandLine_KeyDown(object sender, KeyEventArgs e)
        {

            if (m_estadoVenta == (int)estadoVenta.e_Cerrada || m_estadoVenta == (int)estadoVenta.e_Cancelada)
                return;

            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                lstProductoComplete.Visible = false;
                if (CurrentUserID.CurrentParameters.IUIVENTACONCANTIDAD.Equals("S") &&
                    !TBCommandLine.Text.Equals(""))
                {
                    CPRODUCTOBE prod = new CPRODUCTOBE();
                    if (SoloValidarProducto(ref prod))
                    {
                        if (bEstaConfiguradoParaPiezasyCajas() && !bProductoSoloManejaKG(prod) /*prod != null && (prod.IUNIDAD == null || !prod.IUNIDAD.Trim().ToUpper().Equals("KG"))*/)
                        {
                            formatCajasBotellasPiezas(true);
                            TBCajas.Focus();
                        }
                        else
                        {
                            formatCajasBotellasPiezas(false);
                            TBCantidad.Focus();

                            if (bProductoManejaKG(prod))
                            {
                                TBCantidad.Text = "0";
                                TBCantidad.SelectAllText();
                            }
                        }
                    }
                }
                else
                {
                    ProcessCommand();
                }
            }

            /*if (Control.ModifierKeys == Keys.Control)
            {
                if (e.KeyCode == Keys.S)
                {
                    ProcessCommand();
                }
            }*/
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {
        }
        //private void BTSelCliente_Click(object sender, EventArgs e)
        //{
        //    SeleccionarCliente();

        //}
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

            TBCommandLine.Focus();
        }
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


            bool bBusquedaAnterior = strDescripcion == "" && this.strLastProductoSearch != null && this.strLastProductoSearch.Trim().Length > 0;
            string strLookUpDescripcion = (strDescripcion == "") ? ((this.strLastProductoSearch != null && this.strLastProductoSearch.Trim().Length > 0) ? this.strLastProductoSearch : "") : strDescripcion;

            this.strLastProductoSearch = strLookUpDescripcion;

            LOOKPROD look;
            look = new LOOKPROD(strLookUpDescripcion, !CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"), TipoProductoNivel.tp_hijos, m_ClienteId, true);

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

                if (dr["DESCRIPCION1"] != null)
                {
                    this.TBCommandLine.Text = dr["DESCRIPCION1"].ToString().Trim() + " <((" + dr["CLAVE"].ToString().Trim() + "))>" + " ";
                }
                else
                {
                    this.TBCommandLine.Text = dr["CLAVE"].ToString().Trim();
                }
                TBCommandLine.Focus();
                TBCommandLine.Select(TBCommandLine.Text.Length, 0);

                if (bEstaConfiguradoParaPiezasyCajas())
                {
                    TBCajas.Focus();
                }



                //ProcessCommand();
            }
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



        private bool VerificarValidezPrecios()
        {

            string strRef = "";
            string strValido = "";
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();

            if (pvd.VALIDAR_PRECIOS_DOCTO(m_Docto.IID, CurrentUserID.CurrentUser.IID, null, ref strRef, ref strValido))
            {
                if (strValido.Equals("N"))
                {
                    MessageBox.Show("Por favor revise los precios, parece que hay algunos por debajo de lo que tiene permitido");
                    return false;
                }

            }

            return true;
        }


        private void procesarDivisionVentaXPlazoSiProcede(ref bool bContinuarAPagar)
        {
            bContinuarAPagar = true;

            if (m_Docto != null && m_Docto.IID > 0 && m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_BORRADOR &&
                (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO) 
                && CurrentUserID.CurrentParameters.IPLAZOXPRODUCTO == "S"
                )
            {
                bool bHayPlazosMezclados = false;
                CDOCTOD doctoD = new CDOCTOD();
                if (!doctoD.PLAZO_HAYPLAZOSMEZCLADOS(m_Docto.IID, ref bHayPlazosMezclados, null))
                {
                    MessageBox.Show("Ocurrio un error al checar si hay plazos de productos mezclados " + doctoD.IComentario);
                    bContinuarAPagar = false;
                }

                if (bHayPlazosMezclados)
                {
                    bContinuarAPagar = false;

                    if (MessageBox.Show("Hay productos con plazo mezclado en esta venta... desea que se separen en varias ventas?", " Aviso de situacion ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        long doctoPlazoOrigenId = 0;


                        FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
                        FbTransaction fTrans = null;



                        try
                        {
                            fConn.Open();
                            fTrans = fConn.BeginTransaction();



                            if (!doctoD.PLAZO_DIVIDIRPLAZOSMEZCLADOS(m_Docto.IID, ref doctoPlazoOrigenId, fTrans))
                            {
                                fTrans.Rollback();
                                fConn.Close();
                                MessageBox.Show("Ocurrio un error al dividir los productos mezclados " + doctoD.IComentario);
                                return;
                            }


                            fTrans.Commit();
                            fConn.Close();


                            //MessageBox.Show("Se ha hecho la division de ventas. A continuacion le mostraremos una pantalla donde podra verlas una por una e ir a pagarlas " + doctoD.IComentario);


                            IrANuevaVenta();
                            WFVentasDivididasXPlazo wf = new WFVentasDivididasXPlazo(doctoPlazoOrigenId);
                            wf.ShowDialog();
                            wf.Dispose();
                            GC.SuppressFinalize(wf);

                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message + " " + ex.StackTrace);
                        }
                        finally
                        {
                            fConn.Close();
                        }

                    }

                }
            }
        }


        private void PagarTransaccion()
        {
            if (!validaCustomerIfNeeded())
            {
                return;
            }

            if(this.m_bTieneDerechoBloquearF6)
            {

                MessageBox.Show("Tiene bloqueado la posibilidad de cerrar venta");
                return;
            }

            if(!m_bPermisoPagarVenta)
            {
                MessageBox.Show("No se tiene permiso para pagar venta , se tiene configurado presurtido antes de concretar la venta");
                return;
            }

            if (m_estadoVenta == (int)estadoVenta.e_Cerrada || m_estadoVenta == (int)estadoVenta.e_Cancelada)
                return;

            PreguntarSiEsServDomSiAplica();


            if (CurrentUserID.CurrentParameters.IRUTAARCHIVOSADJUNTOS != null && CurrentUserID.CurrentParameters.IRUTAARCHIVOSADJUNTOS != "" && loadedFiles.Count > 0)
            {
                bool esPago = true;
                WFAdjuntarArchivos adjuntar = new WFAdjuntarArchivos(ref loadedFiles, m_Docto.IID, esPago, loadedFilesCerrada, loadedFilesWorkHours, loadedFilesDate);
                adjuntar.ShowDialog();
                adjuntar.Dispose();
                GC.SuppressFinalize(adjuntar);
                //loadedFiles = new List<string>();
            }

            bool bEsVentaPendienteDesdeMovil = m_Docto != null && m_Docto.IID != 0 && m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_BORRADOR && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA && m_Docto.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_VENDMOVIL;
            if (bEsVentaPendienteDesdeMovil)
            {
                if (!VerificarValidezPrecios())
                    return;
            }


            bool bContinuarAPagar = false;
            procesarDivisionVentaXPlazoSiProcede(ref bContinuarAPagar);
            if (!bContinuarAPagar)
                return;


            /*if (!VerificarExistenciasFinales())
                return;*/

            if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA && m_Docto.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_VENTAFUTUROAPLICADA)
            {
                PagarBasicoVentaFuturoAplicada();
                return;
            }


                


            PagarBasico(false);
        }

        private void BTCerrarVenta_Click(object sender, EventArgs e)
        {

            PagarTransaccion();
        }



        private void ColoreaPendienteMovilConPreciosAAutorizar()
        {
            bool bEsVentaPendienteDesdeMovil = m_Docto != null && m_Docto.IID != 0 && m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_BORRADOR && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA && m_Docto.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_VENDMOVIL;
            if (!bEsVentaPendienteDesdeMovil)
                return;



            foreach (DataGridViewRow row in gridPVDataGridView.Rows)
            {
                row.Cells["DGALERTA"].Value = "BLANCO";

            }

            string strRef = "";
            string strRefValido = "";
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();

            //por el vendedor original
            if (pvd.VALIDAR_PRECIOS_DOCTO(m_Docto.IID, m_Docto.IVENDEDORID, null, ref strRef, ref strRefValido))
            {

                if (strRef != "")
                {
                    string[] strSeparators = new string[] { "|" };
                    string[] strBuffer = strRef.Split(strSeparators, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string strMovtoId in strBuffer)
                    {
                        long movtoId = 0;
                        try
                        {
                            movtoId = long.Parse(strMovtoId);
                        }
                        catch
                        {
                            continue;
                        }

                        foreach (DataGridViewRow row in gridPVDataGridView.Rows)
                        {
                            long rowMovtoId = (long)row.Cells["MOVTOID"].Value;
                            if (rowMovtoId == movtoId)
                            {
                                row.Cells["DGALERTA"].Value = "AMARILLO";

                            }

                        }
                    }
                }
            }
            else
            {

                MessageBox.Show(pvd.IComentario);
            }



            // por el vendedor logueado
            strRef = "";
            if (pvd.VALIDAR_PRECIOS_DOCTO(m_Docto.IID, CurrentUserID.CurrentUser.IID, null, ref strRef, ref strRefValido))
            {
                if (strRef != "")
                {
                    string[] strSeparators = new string[] { "|" };
                    string[] strBuffer = strRef.Split(strSeparators, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string strMovtoId in strBuffer)
                    {
                        long movtoId = 0;
                        try
                        {
                            movtoId = long.Parse(strMovtoId);
                        }
                        catch
                        {
                            continue;
                        }

                        foreach (DataGridViewRow row in gridPVDataGridView.Rows)
                        {
                            long rowMovtoId = (long)row.Cells["MOVTOID"].Value;
                            if (rowMovtoId == movtoId)
                            {

                                row.Cells["DGALERTA"].Value = "ROJO";

                            }

                        }
                    }
                }
            }






        }




        /*private bool VerificarExistenciasFinales()
        {
            if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA)
            {
                CPuntoDeVentaD puntoVenta = new CPuntoDeVentaD();
                bool bKitExist = puntoVenta.KIT_HAYEXISALVUELOPARAENSAMBLE(m_Docto.IID, null);
                if(bKitExist)
                {
                    MessageBox.Show("No hay existencias para armar kits faltantes");

                    WFListaFaltanteKitAlVuelo listaEnsamble = new WFListaFaltanteKitAlVuelo((int)m_Docto.IID);
                    listaEnsamble.ShowDialog();

                    return false;
                }
            }

            return true;
        }*/







        private CSUCURSALBE DatosSucursalDestino()
        {

            CSUCURSALD sucursalD = new CSUCURSALD();
            CSUCURSALBE sucursalBE = new CSUCURSALBE();

            sucursalBE.IID = m_sucursalTID;
            sucursalBE = sucursalD.seleccionarSUCURSAL(sucursalBE, null);

            return sucursalBE;

        }


        private void ExportarTraslados(int folio)
        {


            ImportaDesdeFtp iDBF = new ImportaDesdeFtp();
            //string strResultado = "";

            ArrayList resultadosExportacion = new ArrayList();
            if (!iDBF.EnviarArchivosAFtpDeTraslados(ref resultadosExportacion, folio))
            {

                StringBuilder strBuffer = new StringBuilder("");
                strBuffer.Append(iDBF.IComentario + "\n");
                foreach (string str in resultadosExportacion)
                {
                    strBuffer.Append(str);
                }
                MessageBox.Show(strBuffer.ToString() + "\n");
            }
            else
                MessageBox.Show("La exportacion se ha realizado");


        }




        private void ExportarTrasladosPedidosMatriz(int folio, long doctoid)
        {


            ImportaDesdeFtp iDBF = new ImportaDesdeFtp();
            //string strResultado = "";
            ExportarDBF eDBF = new ExportarDBF();

            if (!eDBF.ExportarEnvioPedido(doctoid, CurrentUserID.CurrentUser, null))
            {
                return;
            }


            ArrayList resultadosExportacion = new ArrayList();
            if (iDBF.EnviarArchivosAFtpDeMatrizPedidos(ref resultadosExportacion, folio, null))
            {

                StringBuilder strBuffer = new StringBuilder("");
                strBuffer.Append(iDBF.IComentario + "\n");
                foreach (string str in resultadosExportacion)
                {
                    strBuffer.Append(str);
                }
                MessageBox.Show(strBuffer.ToString() + "\n");
            }
            else
            {
                MessageBox.Show("Hubo problemas al realizar al exportacion");
                if (resultadosExportacion.Count > 0)
                {

                    StringBuilder strBuffer = new StringBuilder("");
                    strBuffer.Append(iDBF.IComentario + "\n");
                    foreach (string str in resultadosExportacion)
                    {
                        strBuffer.Append(str);
                    }
                    MessageBox.Show(strBuffer.ToString() + "\n");
                }
            }


        }



        private void PagarBasicoApartado()
        {

            if (!Precierre())
                return;

            if (m_Docto != null && m_Docto.IID > 0)
            {
                ObtenerDoctoDeBD(m_Docto.IID, null);
                ObtenerCaja();

                switch (m_tipoTransaccion)
                {
                    case tipoTransaccionV.t_venta:
                    case tipoTransaccionV.t_ventaapartado:
                        {

                            WFPagosBasicoApartados wp = new WFPagosBasicoApartados(m_Docto, m_Caja, false, this.m_montoVentaConVale, this.m_DoctoRef, this.m_tipoTransaccion, "N", false, true, 0);
                            wp.ShowDialog();
                            if (wp.m_bPagoCompleto)
                            {


                                this.m_Docto.ITIPODOCTOID = DBValues._DOCTO_TIPO_VENTAAPARTADO;
                                this.CerrarVenta(false, false, false, false, false, false,false,null);
                            }

                            wp.Dispose();
                            GC.SuppressFinalize(wp);
                        }
                        break;


                }

                this.Focus();
            }
        }

        private bool preAsignarOrdenCompraSiAplica()
        {

            long personaId = m_Docto != null && m_Docto.IID > 0 ? m_Docto.IPERSONAID : m_ClienteId;
            long doctoId = m_Docto != null ? m_Docto.IID : 0;

            m_bAsignarOrdenCompraAlProcess = false;
            m_ordenCompraAAsignar = null;

            if (doctoId > 0)
            {
                CDOCTOD doctoD = new CDOCTOD();
                CDOCTOBE doctoBE = new CDOCTOBE();
                doctoBE.IID = doctoId;
                doctoBE = doctoD.seleccionarDOCTO(doctoBE, null);

                if (doctoBE != null && doctoBE.IORDENCOMPRA != null && doctoBE.IORDENCOMPRA.Trim().Length > 0)
                {
                    doctoBE.IORDENCOMPRA = null;
                    doctoBE.isnull["IORDENCOMPRA"] = true;
                    doctoD.CAMBIARORDENCOMPRA(doctoBE, null);
                }
            }

            return true;

        }


        private bool asignarOrdenCompraSiAplica()
        {
            long personaId = m_Docto != null && m_Docto.IID > 0 ? m_Docto.IPERSONAID : m_ClienteId;
            long doctoId = m_Docto != null ? m_Docto.IID : 0;

            //si ya tiene una orden de compra aplicada salir
            if (m_Docto != null && m_Docto.IORDENCOMPRA != null && m_Docto.IORDENCOMPRA.Trim().Length > 0)
                return true;

            CPERSONAD daoPersona = new CPERSONAD();
            CPERSONABE cliente = new CPERSONABE();
            cliente.IID = personaId;
            cliente = daoPersona.seleccionarPERSONA(cliente, null);

            if (cliente != null && cliente.ISOLICITAORDENCOMPRA == "S")
            {
                WFSeleccionarOrdenCompra wfSeleccionarOrdenCompra = new WFSeleccionarOrdenCompra(doctoId);
                wfSeleccionarOrdenCompra.ShowDialog();

                if (doctoId == 0 && wfSeleccionarOrdenCompra.ordenCompra != null)
                {

                    m_bAsignarOrdenCompraAlProcess = true;
                    m_ordenCompraAAsignar = wfSeleccionarOrdenCompra.ordenCompra;
                }

                wfSeleccionarOrdenCompra.Dispose();
                GC.SuppressFinalize(wfSeleccionarOrdenCompra);
            }

            return true;
        }

        private bool postAsignarOrdenCompraSiAplica()
        {
            long personaId = m_Docto != null && m_Docto.IID > 0 ? m_Docto.IPERSONAID : m_ClienteId;
            long doctoId = m_Docto != null ? m_Docto.IID : 0;

            if (m_bAsignarOrdenCompraAlProcess)
            {



                if (doctoId > 0)
                {
                    CDOCTOD daoDocto = new CDOCTOD();
                    CDOCTOBE docto = new CDOCTOBE();
                    docto.IID = doctoId;
                    docto.IORDENCOMPRA = m_ordenCompraAAsignar;
                    if (!daoDocto.CAMBIARORDENCOMPRA(docto, null))
                    {
                        MessageBox.Show("Algo salio mal, no se pudo agregar la orden de compra!");
                        return false;
                    }

                    m_bAsignarOrdenCompraAlProcess = false;
                    m_ordenCompraAAsignar = null;
                    this.m_Docto.IORDENCOMPRA = docto.IORDENCOMPRA;
                }


            }

            return true;
        }



        private bool preAsignarRutaEmbarqueSiAplica()
        {

            long personaId = m_Docto != null && m_Docto.IID > 0 ? m_Docto.IPERSONAID : m_ClienteId;
            long doctoId = m_Docto != null ? m_Docto.IID : 0;

            m_bAsignarRutaEmbarqueAlProcess = false;
            m_rutaEmbarqueAAsignar = 0;
            m_Docto.IRUTAEMBARQUEID = 0;



            if (doctoId > 0 && bTieneDerechoRutaEmbarque)
            {
                CDOCTOD doctoD = new CDOCTOD();
                CDOCTOBE doctoBE = new CDOCTOBE();
                doctoBE.IID = doctoId;
                doctoBE = doctoD.seleccionarDOCTO(doctoBE, null);

                if (doctoBE != null && doctoBE.IRUTAEMBARQUEID != null && doctoBE.IRUTAEMBARQUEID > 0)
                {
                    doctoBE.IRUTAEMBARQUEID = 0;
                    doctoBE.isnull["IRUTAEMBARQUEID"] = true;
                    doctoD.CambiarRutaEmbarqueDOCTOD(doctoBE, null);
                }
            }

            return true;

        }



        private bool asignarRutaEmbarqueSiAplica(bool bOpcional, bool bAccesoRapido, bool canExit)
        {

            long personaId = m_Docto != null && m_Docto.IID > 0 ? m_Docto.IPERSONAID : m_ClienteId;
            long doctoId = m_Docto != null ? m_Docto.IID : 0;

            if (m_bAutomatizaPagoEfectivo)
                return true;

            //Si a) tiene derecho a ruta de embarque, b) el cliente es diferente de mostrador o tiene definido un cliente de entrega 
            //( en las ventas normales se usa el campo personapartadoid para designar al cliente de entrega)
            // y c) nos aseguramos de que sean solo ventas
            if (bTieneDerechoRutaEmbarque &&
                (personaId != DBValues._CLIENTEMOSTRADOR || m_Docto.IPERSONAAPARTADOID != 0) && (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA_FUTURO))
            {


                m_Docto.IRUTAEMBARQUEID = m_rutaEmbarqueId;


                if (!bOpcional || (bool)m_Docto.isnull["IRUTAEMBARQUEID"] || m_Docto.IRUTAEMBARQUEID == 0)
                {

                    long reId = 0;

                    if (!bAccesoRapido)
                    {
                        iPos.PuntoDeVenta.WFSeleccionarRutaEmbarque sre = new PuntoDeVenta.WFSeleccionarRutaEmbarque(canExit, personaId);
                        sre.ShowDialog();
                        reId = sre.rutaEmbarqueId;
                        sre.Dispose();
                        GC.SuppressFinalize(sre);
                    }
                    else
                    {
                        iPos.Catalogos.WFRutasEmbarque look = new iPos.Catalogos.WFRutasEmbarque();
                        look.ShowDialog();

                        DataRow dr = look.m_rtnDataRow;

                        look.Dispose();
                        GC.SuppressFinalize(look);


                        if (dr != null)
                        {
                            reId = (long)dr["ID"];
                        }
                    }

                    if (reId != 0 && reId != null)
                    {
                        m_Docto.IRUTAEMBARQUEID = reId;

                        if (doctoId > 0)
                        {
                            CDOCTOD doctoD = new CDOCTOD();
                            if (!doctoD.CambiarRutaEmbarqueDOCTOD(m_Docto, null))
                            {
                                MessageBox.Show("No se pudo cambiar la ruta de embarque");

                                lblRutaEmbarque.Text = "...";
                                m_rutaEmbarqueId = 0;

                                return false;
                            }
                            llenarDatosRutaEmbarque();
                        }
                        else
                        {

                            m_bAsignarRutaEmbarqueAlProcess = true;
                            m_rutaEmbarqueAAsignar = reId;
                            llenarDatosRutaEmbarque();
                        }
                    }
                }
            }

            return true;
        }



        private bool postAsignarRutaEmbarqueSiAplica()
        {
            if (m_bAsignarRutaEmbarqueAlProcess && bTieneDerechoRutaEmbarque)
            {

                long personaId = m_Docto != null && m_Docto.IID > 0 ? m_Docto.IPERSONAID : m_ClienteId;
                long doctoId = m_Docto != null ? m_Docto.IID : 0;
                if (doctoId > 0)
                {
                    CDOCTOD doctoD = new CDOCTOD();
                    m_Docto.IRUTAEMBARQUEID = m_rutaEmbarqueAAsignar;
                    if (!doctoD.CambiarRutaEmbarqueDOCTOD(m_Docto, null))
                    {
                        MessageBox.Show("No se pudo cambiar la ruta de embarque");

                        lblRutaEmbarque.Text = "...";
                        m_rutaEmbarqueId = 0;

                        return false;
                    }

                    m_bAsignarRutaEmbarqueAlProcess = false;
                    m_rutaEmbarqueAAsignar = 0;
                    llenarDatosRutaEmbarque();
                }

            }

            return true;
        }

        private void PagarBasico(bool bPagoConVale)
        {
            //
            CUSUARIOSD userD = new CUSUARIOSD();


            if (!asignarRutaEmbarqueSiAplica(true, false, false))
                return;


            if (!asignarOrdenCompraSiAplica())
                return;

            //si hace falta asignar supervisor
            if (m_asignarsupervisor)
            {
                CDOCTOD doctoD = new CDOCTOD();
                m_Docto.ISUPERVISORID = m_supervisor.IID;
                doctoD.CambiarSupervisorAutorizacionDOCTOD(m_Docto, null);

                m_asignarsupervisor = false;
            }


            if (m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_BORRADOR)
                if (!Precierre())
                    return;





           

            if (m_Docto != null && m_Docto.IID > 0)
            {
                ObtenerDoctoDeBD(m_Docto.IID, null);
                ObtenerCaja();

                string esapartado = "N";
                if (this.m_tipoTransaccion == tipoTransaccionV.t_ventaapartado)
                {
                    esapartado = "S";
                }

                switch (m_tipoTransaccion)
                {
                    case tipoTransaccionV.t_venta:
                    case tipoTransaccionV.t_ventaapartado:
                        {
                            if (m_Docto.ITOTAL > 0 && m_Docto.ITIPODOCTOID != DBValues._DOCTO_TIPO_VENTA_FUTURO)
                            {

                                if (!PideAutorizacionXAlertaPreciosSiAplica())
                                {
                                    return;
                                }

                                CDOCTOBE currentDocto = m_Docto;

                                //manejo de traspaso salida


                                bool bDefaultFactura = false;
                                bool bPrepagoHecho = false;

                                long doctoVenta = 0;
                                bool bTraspasoFranquicia = false;
                                bool bResTraspasoFranquicia = false;
                                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO)
                                {
                                    CDOCTOD doctoD = new CDOCTOD();
                                    string esfranquicia = doctoD.GetFranquiciaSucursal(m_Docto, null);
                                    bTraspasoFranquicia = esfranquicia.Equals("S");
                                    if (bTraspasoFranquicia)
                                    {
                                        bResTraspasoFranquicia = doctoD.TRASPASOSALIDA_COMPLETAR(m_Docto, ref doctoVenta, null);
                                        if (bResTraspasoFranquicia)
                                        {

                                            currentDocto = new CDOCTOBE();
                                            currentDocto.IID = doctoVenta;
                                            currentDocto = doctoD.seleccionarDOCTO(currentDocto, null);

                                            if (currentDocto == null)
                                            {
                                                MessageBox.Show("Error al convertir el traspaso a venta");
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Error al convertir el traspaso a venta");
                                            return;
                                        }
                                    }

                                    // aqui es donde se ve si se prepaga porque las sucursales tienen empresas asignadas y son de una misma empresa
                                    CPuntoDeVentaD pvd = new CPuntoDeVentaD();
                                    if (!pvd.TRASPASOSALIDA_PRECIERRE(m_Docto, ref bPrepagoHecho, ref bDefaultFactura, null))
                                    {
                                        MessageBox.Show("Error " + pvd.IComentario);
                                        return;
                                    }


                                    if (bPrepagoHecho)
                                    {



                                        if (bTraspasoFranquicia)
                                        {

                                            string comentarioFact = "";
                                            bool bImprimirFacturaPorTraslado = false;
                                            if (bDefaultFactura)
                                            {
                                                if (!generarFacturaElectronicaPorId(currentDocto.IID, null, ref comentarioFact, true))
                                                {
                                                    MessageBox.Show("No se pudo generar la factura electronica");
                                                    return;
                                                }

                                                bImprimirFacturaPorTraslado = true;
                                            }


                                            CerrarTraspasoSalida(false, true, false, true, false,false, null);

                                            if(bImprimirFacturaPorTraslado)
                                            {

                                                imprimirFacturaElectronicaPorId(currentDocto.IID);
                                            }
                                        }
                                        else
                                        {
                                            this.CerrarVenta(false, false, false, false, false, false, false, null);

                                        }

                                        break;
                                    }
                                    //fin aqui


                                }
                                // fin de manejo traspaso salida




                                WFPagosBasico wp;
                                if (m_formPagoVenta == null)
                                {
                                    decimal montoConVale = this.m_montoVentaConVale;
                                    long tipoDescuentoVale = 1;

                                    if (bPagoConVale && CurrentUserID.CurrentParameters.IMULTIPLETIPOVALE != null && CurrentUserID.CurrentParameters.IMULTIPLETIPOVALE.Equals("S"))
                                    {

                                        WFSeleccionTipoDescuento wf = new WFSeleccionTipoDescuento();
                                        wf.ShowDialog();

                                        if (wf.lDescuentoSeleccionado != -1)
                                        {
                                            switch (wf.lDescuentoSeleccionado)
                                            {
                                                case 101: montoConVale = this.m_montoVentaConValePorc1; break;
                                                case 102: montoConVale = this.m_montoVentaConValePorc2; break;
                                                case 103: montoConVale = this.m_montoVentaConValePorc3; break;
                                                case 104: montoConVale = this.m_montoVentaConValePorc4; break;
                                            }
                                            tipoDescuentoVale = wf.lDescuentoSeleccionado;
                                        }
                                        wf.Dispose();
                                        GC.SuppressFinalize(wf);
                                    }

                                    bool siempreDeshabilitaPagoConTarjeta = false;
                                    siempreDeshabilitaPagoConTarjeta = (CurrentUserID.CurrentParameters.ICOMISIONPORTARJETA > 0.0m || CurrentUserID.CurrentParameters.ICOMISIONDEBPORTARJETA > 0.0m) && CBXPagoConTarjeta.SelectedIndex == 0 && CBXPagoConTarjeta.Visible;


                                    bool siempreDeshabilitaPagoACredito = false;
                                    siempreDeshabilitaPagoACredito = (CurrentUserID.CurrentParameters.IPREGUNTARSIESACREDITO != null && CurrentUserID.CurrentParameters.IPREGUNTARSIESACREDITO.Equals("S")) && !CBACredito.Checked;


                                    wp = new WFPagosBasico(currentDocto, m_Caja, bPagoConVale, montoConVale, this.m_DoctoRef, this.m_tipoTransaccion, esapartado, m_supervisor, false, false, 0, tipoDescuentoVale, siempreDeshabilitaPagoConTarjeta, siempreDeshabilitaPagoACredito);
                                    wp.m_bCerrarVenta = bTraspasoFranquicia || !(m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO);
                                    wp.m_bCerrarTraspasoSalida = !wp.m_bCerrarVenta; //!bTraspasoFranquicia && (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO);
                                    wp.m_bAutomatizaPagoEfectivo = m_bAutomatizaPagoEfectivo;
                                    wp.ShowDialog();
                                }
                                else
                                {
                                    wp = m_formPagoVenta;
                                }

                                if (wp.m_bPagoCompleto)
                                {
                                    if (m_bAutomatizaPagoEfectivo)
                                        m_bPagoAutomaticoHecho = true;

                                    m_Docto.IESTATUSDOCTOID = DBValues._DOCTO_ESTATUS_COMPLETO;
                                    if (m_formPagoVenta == null)
                                        m_formPagoVenta = wp;


                                    if (!ProcesarMonedero(wp.m_monedero, wp.m_monederoAplicado))
                                    {
                                        MessageBox.Show("Error al procesar el monedero");
                                        return;
                                    }


                                    if (bTraspasoFranquicia)
                                    {
                                        CerrarTraspasoSalida((wp.m_generarFacturaElectronica && !wp.m_surtidoPostpuesto), wp.m_bPagoPorxCredito, false, wp.m_bExportarSiAplica, wp.m_generarComprobanteTraslado, wp.m_generarCartaPorte, wp.m_guiaBE);
                                    }
                                    else
                                    {
                                        bool bImprimirDoble = m_Docto.IMONTOREBAJA > 0;
                                        this.CerrarVenta((wp.m_generarFacturaElectronica && !wp.m_surtidoPostpuesto), wp.m_bPagoPorxCredito, true, bImprimirDoble, wp.m_timbrarPagosAlTerminar, wp.m_generarComprobanteTraslado, wp.m_generarCartaPorte, wp.m_guiaBE);

                                    }

                                    
                                }

                                if (wp != null)
                                {
                                    try
                                    {
                                        wp.Dispose();
                                        wp = null;
                                    }
                                    catch
                                    {

                                    }
                                }
                            }
                            else
                            {
                                long doctoId = m_Docto.IID;
                                long tipoDoctoId = m_Docto.ITIPODOCTOID;


                                //si esta en ceros y es venta solicitar autorizacion
                                if (m_Docto.ITOTAL == 0 && tipoDoctoId == DBValues._DOCTO_TIPO_VENTA)
                                {
                                    MessageBox.Show("Tendra que ingresar credenciales de supervisor ");

                                    WFPreguntaAutorizacion ps2 = new WFPreguntaAutorizacion();
                                    ps2.m_requiereAdminOrSupervisor = true;
                                    ps2.ShowDialog();
                                    CPERSONABE userBE = ps2.m_userBE;
                                    CPERSONABE supervisorBE = ps2.m_supervisorBE;
                                    bool bPassValido = ps2.m_bPassValido;
                                    bool bIsSupervisor = ps2.m_bIsSupervisor;
                                    bool bIsAdministrador = ps2.m_bIsAdministrador;
                                    ps2.Dispose();
                                    GC.SuppressFinalize(ps2);

                                    if (!bPassValido || userBE == null)
                                    {
                                        MessageBox.Show("Credenciales invalidas ");
                                        return;
                                    }
                                }

                                
                                this.CerrarVenta(false, false, false, false, false,false, false, null);


                                if (tipoDoctoId == DBValues._DOCTO_TIPO_VENTA_FUTURO)
                                {

                                    if (MessageBox.Show("Quiere realizar algun anticipo de esta venta a futuro?", "Anticipo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        WFAnticipos wf = new WFAnticipos(tipoTransaccionV.t_venta, doctoId);
                                        wf.ShowDialog();
                                        wf.Dispose();
                                        GC.SuppressFinalize(wf);
                                    }
                                }

                            }
                        }
                        break;

                    case tipoTransaccionV.t_devolucion:
                        {

                            WFPagosDevoluciones wp = new WFPagosDevoluciones(m_Docto, m_Caja, bPagoConVale, this.m_montoVentaConVale, this.m_DoctoRef, this.m_tipoTransaccion, esapartado, false);
                            wp.ShowDialog();
                            if (wp.m_bPagoCompleto)
                            {
                                this.CerrarVenta(false, false, false, false, false, false, false, null);
                            }
                            wp.Dispose();
                            GC.SuppressFinalize(wp);
                        }
                        break;



                    case tipoTransaccionV.t_traspasoalmacen:
                        {
                            CompletarTraspasoAlmacen();
                            break;
                        }

                    case tipoTransaccionV.t_ventaMovil:
                        {
                            if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 2)
                            {

                                WFEnvioMovilProcess_2 wp = new WFEnvioMovilProcess_2(m_Docto);
                                wp.ShowDialog();
                                if (wp.m_procesoCerrado)
                                {
                                    PosPrinter.ImprimirTicket(m_Docto.IID);
                                    IrANuevaVenta();
                                    this.TBCommandLine.Focus();
                                }
                                wp.Dispose();
                                GC.SuppressFinalize(wp);
                            }
                            else
                            {

                                //WFEnvioMovilProcess wp = new WFEnvioMovilProcess(m_Docto);
                                //wp.ShowDialog();
                                //if (wp.m_procesoCerrado)
                                //{
                                //    PosPrinter.ImprimirTicket(m_Docto.IID);
                                //    IrANuevaVenta();
                                //    this.TBCommandLine.Focus();
                                //}

                                if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 2)
                                {

                                    WFEnvioMovilProcess_2 wp = new WFEnvioMovilProcess_2(m_Docto);
                                    wp.ShowDialog();
                                    if (wp.m_procesoCerrado)
                                    {
                                        PosPrinter.ImprimirTicket(m_Docto.IID);
                                        IrANuevaVenta();
                                        this.TBCommandLine.Focus();
                                    }
                                    wp.Dispose();
                                    GC.SuppressFinalize(wp);
                                }
                                else if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 1)
                                {

                                    WFEnvioMovilProcess wp = new WFEnvioMovilProcess(m_Docto);
                                    wp.ShowDialog();
                                    if (wp.m_procesoCerrado)
                                    {
                                        PosPrinter.ImprimirTicket(m_Docto.IID);
                                        IrANuevaVenta();
                                        this.TBCommandLine.Focus();
                                    }
                                    wp.Dispose();
                                    GC.SuppressFinalize(wp);
                                }
                                else if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 3 || CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 4)
                                {

                                    WFEnvioMovilProcess_3 wp = new WFEnvioMovilProcess_3(m_Docto);
                                    wp.ShowDialog();
                                    if (wp.m_procesoCerrado)
                                    {
                                        PosPrinter.ImprimirTicket(m_Docto.IID);
                                        IrANuevaVenta();
                                        this.TBCommandLine.Focus();
                                    }
                                    wp.Dispose();
                                    GC.SuppressFinalize(wp);
                                }

                            }
                            //this.CerrarVenta(false, false);
                        }
                        break;




                }

                this.Focus();
            }
        }



        private bool AplicarDescuentoVale()
        {
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();


            pvd.APLICAR_DESCUENTO_VALEVenta(m_Docto, null);
            if (pvd.IComentario == "" || pvd.IComentario == null)
            {
                return true;
            }
            else
            {
                MessageBox.Show("ERRORES: " + pvd.IComentario.Replace("%", "\n"));
                return false;
            }
        }



        private void CompletarTraspasoAlmacen()
        {

            CPuntoDeVentaD pvd = new CPuntoDeVentaD();


            if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ALMACEN)
            {
                pvd.CompletarTraspasoAlmacen(m_Docto, null);
            }

            if (pvd.IComentario == "" || pvd.IComentario == null)
            {
                PosPrinter.ImprimirTicket(m_Docto.IID);
                IrANuevaVenta();
                HiloExistencias._IFLAGENVIAREXISTENCIASEVENTOS++;
                this.TBCommandLine.Focus();
            }
            else
            {
                MessageBox.Show("ERRORES: " + pvd.IComentario.Replace("%", "\n"));
            }
        }

        private void CerrarVenta(bool generarFacturaElectronica, bool bEsCredito, bool bAlreadyClosedInDB, bool bImprimirDoble, bool timbrarPagos, bool bGenerarComprobanteTraslado, bool generarCartaPorte, CGUIABE guiaBE)
        {

            CPuntoDeVentaD pvd = new CPuntoDeVentaD();

            Boolean bImprimirDoblePorParametroYTipo = CurrentUserID.CurrentParameters.IDOBLECOPIAREMISION != null && CurrentUserID.CurrentParameters.IDOBLECOPIAREMISION.Equals("S") &&
                                                      m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA && !generarFacturaElectronica && CurrentUserID.CurrentUser.ITICKETLARGO.Equals("S");

            Boolean bReimpresionesConMarca = CurrentUserID.CurrentParameters.IREIMPRESIONESCONMARCA != null && CurrentUserID.CurrentParameters.IREIMPRESIONESCONMARCA.Equals("S");

            if (!bAlreadyClosedInDB)
                pvd.CerrarVenta(m_Docto, null);


            if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA)
            {
                APLICARCUPONES_SIESNECESARIO(m_Docto.IID, null);
            }

            if (bAlreadyClosedInDB || pvd.IComentario == "" || pvd.IComentario == null)
            {


                if (generarFacturaElectronica)
                {
                    bool repetir = false;

                    do
                    {
                        repetir = false;
                        if (this.generarFacturaElectronica(true))
                        {

                            //MessageBox.Show("Se facturo");

                            if (!m_bPermisoImprimirTicketFacturaDirecto)
                            {
                                imprimirFacturaElectronica();

                                if (bImprimirDoble)
                                    imprimirFacturaElectronica();

                            }
                        }
                        else
                        {
                            //MessageBox.Show("No se pudo facturar");
                            WFNoSePudoFacturarPregunta wf = new WFNoSePudoFacturarPregunta();
                            wf.ShowDialog();
                            string strRespuesta = wf.strRespuesta;
                            wf.Dispose();
                            GC.SuppressFinalize(wf);

                            if (strRespuesta != null && strRespuesta.Equals("Reintentar"))
                            {
                                repetir = true;
                            }
                            else if (strRespuesta != null && strRespuesta.Equals("Cancelar"))
                            {
                                CDOCTOD doctoD = new CDOCTOD();
                                m_Docto.IESFACTURAELECTRONICA = "N";
                                doctoD.ACTUALIZARESFACTURAELECTRONICA(m_Docto, null);
                                CancelarVentaActual();
                                return;
                            }
                            else
                            {
                                generarFacturaElectronica = false;
                            }


                        }
                    } while (repetir);



                }


                if(bGenerarComprobanteTraslado)
                {
                    if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA)
                    {
                        if(generarCartaPorte)
                        {
                            if (!GuardarGuia(guiaBE, m_Docto))
                                return;
                        }

                        if(this.generarComprobanteTraslado(generarCartaPorte))
                        {
                            this.imprimirComprobanteTraslado();
                        }
                    }
                }

                if (!generarFacturaElectronica)
                {

                    if ((bImprimirDoble || bImprimirDoblePorParametroYTipo) && CurrentUserID.CurrentUser.ITICKETLARGO.Equals("S"))
                    {
                        PosPrinter.ImprimirTicket(m_Docto.IID, 0, false, false, 2);
                    }
                    else
                    {
                        PosPrinter.ImprimirTicket(m_Docto.IID);
                    }



                    if ((bImprimirDoble || bImprimirDoblePorParametroYTipo) && !CurrentUserID.CurrentUser.ITICKETLARGO.Equals("S"))
                        PosPrinter.ImprimirTicket(m_Docto.IID, 0, false, bReimpresionesConMarca, 1);
                }
                else if (CurrentUserID.CurrentParameters.IRECIBOLARGOCONFACTURA.Equals("S") || m_bPermisoImprimirTicketFacturaDirecto)
                {

                    imprimirTicketFacturaElectronica();
                }


                if ((CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("3.3") || CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0")) && timbrarPagos)
                {
                    //MessageBox.Show("Timbrar pagos aqui");
                    ReciboElectronicoHelper reciboElectronicoHelper = new ReciboElectronicoHelper();
                    CDOCTOPAGOD doctoPagoDao = new CDOCTOPAGOD();
                    List<long> pagosPendientes = doctoPagoDao.SeleccionarPagosPendientesPorDoctoId(m_Docto.IID, null);

                    if (pagosPendientes != null)
                    {
                        foreach (long pagoId in pagosPendientes)
                        {
                            if (!reciboElectronicoHelper.Procesar(pagoId, m_Docto.IPERSONAID))
                            {
                                string mensajeError = "Problema con pago " + pagoId.ToString() + ": " +
                                                   reciboElectronicoHelper.Mensaje +
                                                  "\n¿Desea continuar?";

                                if (!(MessageBox.Show(mensajeError, "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                                {
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error al recueprar pagos pendientes: " + doctoPagoDao.IComentario);
                    }
                }


                // imprimir segun el tipo
                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO)
                {

                    for (int iy = 0; iy < CurrentUserID.CurrentParameters.IDOBLECOPIATRASLADO - 1; iy++)
                    {
                        PosPrinter.ImprimirTicket(m_Docto.IID);
                    }
                }
                else if ((bEsCredito || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTAAPARTADO) && (CurrentUserID.CurrentUser.ITICKETLARGOCREDITO == null || !CurrentUserID.CurrentUser.ITICKETLARGOCREDITO.Equals("S")))
                {
                    for (int iv = 0; iv < CurrentUserID.CurrentParameters.IDOBLECOPIACREDITO - 1; iv++)
                    {
                        PosPrinter.ImprimirTicket(m_Docto.IID);
                    }
                }
                else if(m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA && !bEsCredito)
                {

                    for (int iv = 0; iv < CurrentUserID.CurrentParameters.IDOBLECOPIACONTADO - 1; iv++)
                    {
                        PosPrinter.ImprimirTicket(m_Docto.IID);
                    }
                }


                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA &&
                        m_Docto.IPAGOCONTARJETA != null && (m_Docto.IPAGOCONTARJETA.Equals("S") || m_Docto.IPAGOCONTARJETA.Equals("D") || m_Docto.IPAGOCONTARJETA.Equals("C")))
                {

                    for (int iv = 0; iv < CurrentUserID.CurrentParameters.IDOBLECOPIATARJETA - 1; iv++)
                    {
                        PosPrinter.ImprimirTicket(m_Docto.IID);
                    }
                }

                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO && m_Docto.IESTADOSURTIDOID != DBValues._DOCTO_SURTIDOESTADO_PENDIENTE)
                {
                    CDOCTOD vData = new CDOCTOD();
                    m_Docto = vData.seleccionarDOCTO(m_Docto, null);

                    ExportarTraslados(m_Docto.IFOLIO);
                }


                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTAAPARTADO)
                {

                    CDOCTOD vData = new CDOCTOD();
                    m_Docto = vData.seleccionarDOCTO(m_Docto, null);
                    if (m_Docto.ISALDO <= 0)
                    {
                        pvd.VENTA_ENTREGARMERCANCIA(m_Docto, null);
                    }
                }


                if (m_Docto.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_VENDMOVIL)
                {
                    CDOCTOBE doctoPedido = new CDOCTOBE();
                    doctoPedido.IID = m_Docto.IDOCTOREFID;
                    pvd.CerrarVenta(doctoPedido, null);
                }




                if (pvd.ContieneRecargas(m_Docto, null))
                {

                    PosPrinter.ImprimirTicket(m_Docto.IID, Ticket._OPCION_IMPRESION_RECARGAS);
                }

                CambiaAutorizacionXAlertaPreciosSiAplica();
                IrANuevaVenta();
                HiloExistencias._IFLAGENVIAREXISTENCIASEVENTOS++;
                this.TBCommandLine.Focus();
            }
            else
            {
                MessageBox.Show("ERRORES: " + pvd.IComentario.Replace("%", "\n"));
            }
        }




        private void CerrarTraspasoSalida(bool generarFacturaElectronica, bool bEsCredito, bool bAlreadyClosedInDB, bool bExportar, bool generarComprobanteTraslado, bool generarCartaPorte, CGUIABE guiaBE)
        {
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            CDOCTOD vData = new CDOCTOD();

            m_Docto = vData.seleccionarDOCTO(m_Docto, null);

            if (!bAlreadyClosedInDB)
                pvd.TRASPASOSALIDA_CERRARDOCTO(m_Docto, null);

            m_Docto = vData.seleccionarDOCTO(m_Docto, null);

            if (bAlreadyClosedInDB || pvd.IComentario == "" || pvd.IComentario == null)
            {


                if (generarFacturaElectronica)
                {
                    imprimirFacturaElectronicaPorId(m_Docto.IDOCTOREFID);
                }

                if (!generarFacturaElectronica)
                {
                    PosPrinter.ImprimirTicket(m_Docto.IDOCTOREFID);
                }
                else if (CurrentUserID.CurrentParameters.IRECIBOLARGOCONFACTURA.Equals("S"))
                {
                    imprimirTicketFacturaElectronicaPorId(m_Docto.IDOCTOREFID);
                }

                // imprimir segun el tipo
                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO)
                {

                    for (int iy = 0; iy < CurrentUserID.CurrentParameters.IDOBLECOPIATRASLADO - 1; iy++)
                    {
                        PosPrinter.ImprimirTicket(m_Docto.IDOCTOREFID);
                    }
                }


                if(generarComprobanteTraslado)
                {
                     //&& generarCartaPorte, CGUIABE guiaBE
                    //, CGUIABE guiaBE
                }


                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO && m_Docto.IESTADOSURTIDOID != DBValues._DOCTO_SURTIDOESTADO_PENDIENTE && bExportar)
                {
                    m_Docto = vData.seleccionarDOCTO(m_Docto, null);

                    ExportarTraslados(m_Docto.IFOLIO);
                }


                IrANuevaVenta();
                HiloExistencias._IFLAGENVIAREXISTENCIASEVENTOS++;
                this.TBCommandLine.Focus();
            }
            else
            {
                MessageBox.Show("ERRORES: " + pvd.IComentario.Replace("%", "\n"));
            }
        }



        private bool AsignarReceta()
        {
            WFAsignarReceta asignarForm = new WFAsignarReceta(m_Docto.IID);
            asignarForm.ShowDialog();

            bool receta_asignada = asignarForm.m_receta_asignada;

            asignarForm.Dispose();
            GC.SuppressFinalize(asignarForm);

            return receta_asignada;
        }

        private bool AsignarRecetaSiSeNecesita()
        {
            if (CurrentUserID.CurrentParameters.IMANEJARECETA == null || !CurrentUserID.CurrentParameters.IMANEJARECETA.Equals("S")
                || CurrentUserID.CurrentCompania.IESMATRIZ.Equals("S"))
                return true;

            if (m_Docto == null)
                return true;
            if (!(bool)m_Docto.isnull["IMANEJORECETA"])
            {
                if (!m_Docto.IMANEJORECETA.Equals("N"))
                    return true;
            }


            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            bool bRequiereReceta = pvd.REQUIERERECETA(m_Docto, null);

            if (bRequiereReceta)
            {
                /*if (MessageBox.Show("Hay productos que necesitan documento adjunto, ¿ desea registrarlo ?", "Requerimiento", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {*/
                return AsignarReceta();
                /* }
                 else
                 {
                    CDOCTOD doctoD = new CDOCTOD();
                     m_Docto.IMANEJORECETA = @"R";
                     doctoD.CAMBIARMANEJORECETA(m_Docto, null);
                 }*/
            }


            return true;
        }


        private bool Precierre()
        {
            if (this.m_tipoTransaccion == tipoTransaccionV.t_devolucion)
                return true;

            if (m_tipoTransaccion == tipoTransaccionV.t_traspasoalmacen)
                return true;


            /*if (this.ComboVendedorFinal.SelectedIndex < 0 )*/
            if (!AsignarRecetaSiSeNecesita())
            {
                MessageBox.Show("Parece que la venta requiere receta y no se proporciono ");
                return false;
            }

            if (this.VENDEDORIDTextBox.Text == "" || Int64.Parse(this.VENDEDORIDTextBox.DbValue.ToString()) == 0)
            {


                if (CurrentUserID.CurrentParameters.IHAYVENDEDORPISO.Equals("N"))
                {
                    this.VENDEDORIDTextBox.DbValue = CurrentUserID.CurrentUser.IID.ToString();
                }
                else
                {
                    /*
                    MessageBox.Show("Debe seleccionar el vendedor final ");
                    this.VENDEDORIDTextBox.Focus();*/
                    WFSeleccionVendedor wfv = new WFSeleccionVendedor(CurrentUserID.CurrentUser.IID, CurrentUserID.CurrentUser.ICLAVE);
                    wfv.ShowDialog();
                    bool bseleccionado = wfv.m_bseleccionado;
                    string clavevendedor = wfv.m_clavevendedor;
                    long bufferVendedor = wfv.m_vendedorfinal;
                    wfv.Dispose();
                    GC.SuppressFinalize(wfv);


                    if (bseleccionado)
                    {
                        this.VENDEDORIDTextBox.Text = clavevendedor;
                        this.VENDEDORIDTextBox.DbValue = bufferVendedor.ToString();
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            int errorCode = 0;

            m_Docto.IVENDEDORID = CurrentUserID.CurrentUser.IID;
            m_Docto.IVENDEDORFINAL = Int64.Parse(this.VENDEDORIDTextBox.DbValue.ToString());//long.Parse(this.ComboVendedorFinal.SelectedValue.ToString());

            if (m_vendedorEjecutivoId != 0)
            {
                m_Docto.IVENDEDOREJECUTIVOID = m_vendedorEjecutivoId;
            }

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

        private void gridPVBindingSource_CurrentChanged(object sender, EventArgs e)
        {
        }
        //private void BTPagar_Click(object sender, EventArgs e)
        //{
        //    PagarAvanzado();
        //}
        private void PagarAvanzado()
        {
            //WFPagos wp = new WFPagos(this.m_Cliente, this.m_Docto);
            //wp.ShowDialog();
            //if (wp.m_bPagoCompleto)
            //{
            //    this.CerrarVenta();
            //}
            //wp.Dispose();
        }
        private void WFPuntoDeVenta_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                /*case Keys.F1:
                    WFChecadorPrecio wf = new WFChecadorPrecio();
                    wf.ShowDialog();
                    wf.Dispose();
                    GC.SuppressFinalize(wf);
                    break;*/
                case Keys.F6:
                    if (m_estadoVenta != (int)estadoVenta.e_Cerrada && m_estadoVenta != (int)estadoVenta.e_Cancelada)
                        PagarTransaccion();
                    break;
                case Keys.F5:

                    if (this.BTAbrirCerradasYDevo.Enabled)
                    {
                        AbrirVentasCerradasYDevoluciones(0, "");
                    }
                    break;
                case Keys.F4:
                    if (!e.Alt)
                    {
                        AbrirVenta();
                        RefrescarEstatusBotones();
                    }
                    break;
                case Keys.F2:
                    //IrANuevaVenta();
                    PasarANueva();
                    break;
                case Keys.F3:
                    if (m_estadoVenta != (int)estadoVenta.e_Cancelada)
                            CancelarVentaActual(e.Alt, true);
                    break;
                case Keys.F8:
                    SeleccionarProducto();
                    break;

                case Keys.F9:
                    ModoTraslado();
                    break;

                case Keys.F10:
                    if (m_estadoVenta != (int)estadoVenta.e_Cerrada && m_estadoVenta != (int)estadoVenta.e_Cancelada)
                        EliminarDetalle();
                    break;

                case Keys.F11:
                    if (m_estadoVenta != (int)estadoVenta.e_Cerrada && m_estadoVenta != (int)estadoVenta.e_Cancelada)
                    {
                        CambiarPrecioDetalle();
                    }
                    break;

                case Keys.F7:

                    if (m_estadoVenta != (int)estadoVenta.e_Cerrada && m_estadoVenta != (int)estadoVenta.e_Cancelada)
                    {
                        SeleccionaCliente();
                    }
                    break;

                case Keys.F12:
                    if (e.Modifiers == Keys.Control)
                    {
                        if (m_estadoVenta == (int)estadoVenta.e_Cerrada && m_estadoVenta != (int)estadoVenta.e_Cancelada)
                        {
                            if (generarFacturaElectronica(false))
                            {

                                MessageBox.Show("Se facturo");
                                imprimirFacturaElectronica();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo facturar");
                            }
                        }
                        //this.imprimirComprobanteTraslado();
                        //imprimirFacturaElectronica();
                        //imprimirTicketFacturaElectronica();
                    }


                    if (e.Modifiers == Keys.Shift)
                    {
                        if (m_estadoVenta == (int)estadoVenta.e_Cerrada && m_estadoVenta != (int)estadoVenta.e_Cancelada)
                        {
                            if (generarComprobanteTraslado(false))
                            {

                                MessageBox.Show("Se genero el comprobante");
                                imprimirComprobanteTraslado();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo generar el comprobante");
                            }
                        }
                    }

                    break;
                    


                case Keys.Escape:
                    this.Close();
                    break;


                case Keys.P:
                    if (e.Modifiers == Keys.Control)
                    {
                        CUSUARIOSD usersD = new CUSUARIOSD();
                        Boolean bTieneDerechoAImprimirCotizacion = usersD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_IMPRIMIRCOTIZACION, null);

                        if (((!(bool)CurrentUserID.CurrentParameters.isnull["IHAB_IMPR_COTIZACION"]) && CurrentUserID.CurrentParameters.IHAB_IMPR_COTIZACION == DBValues._DB_BOOLVALUE_SI) && bTieneDerechoAImprimirCotizacion)
                        {

                            if (m_Docto != null)
                            {
                                if (!(bool)m_Docto.isnull["IID"])
                                {
                                    PosPrinter.ImprimirTicket(m_Docto.IID);

                                    Boolean bAtajoANuevaVenta = usersD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_ATAJOCONTROLP_IRANUEVAVENTA, null);
                                    if (bAtajoANuevaVenta)
                                    {
                                        IrANuevaVenta();
                                    }
                                }
                            }
                        }

                    }
                    break;

                default:
                    break;
            }
        }


        bool generandoFacturaElectronica = false;
        private bool generarFacturaElectronica(bool bIgnoreDerecho)
        {
            if (generandoFacturaElectronica)
                return false;
            try
            {
                generandoFacturaElectronica = true;

                CDOCTOD doctoD = new CDOCTOD();
                m_Docto = doctoD.seleccionarDOCTO(m_Docto, null);
                if (m_Docto.IFACTCONSID > 0 || m_Docto.IDEVCONSID > 0)
                {

                    MessageBox.Show("No se puede generar la factura electronica porque pertenece a una factura consolidada");
                    return false;
                }

                if(m_Docto.IESFACTURAELECTRONICA == "S" && m_Docto.ITIMBRADOUUID != null && m_Docto.ITIMBRADOUUID.Trim().Length > 0)
                {
                    MessageBox.Show("La factura electronica ya fue generada");
                    return false;
                }

                if (CurrentUserID.CurrentParameters.IVERSIONCFDI != null &&
                    (CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("3.3") || CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0")))
                {

                    if (m_Docto.ISAT_USOCFDIID == 0)
                    {
                        WFUsoCfdiSeleccionar wf = new WFUsoCfdiSeleccionar(m_Docto.IID);
                        wf.ShowDialog();
                        wf.Dispose();
                        GC.SuppressFinalize(wf);

                        m_Docto = doctoD.seleccionarDOCTO(m_Docto, null);
                        if (m_Docto.ISAT_USOCFDIID == 0)
                        {
                            MessageBox.Show("Debe seleccionar un uso cfdi");
                            return false;
                        }

                    }
                }


                CUSUARIOSD usuariosD = new CUSUARIOSD();
                if (!bIgnoreDerecho)
                {
                    if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_REMISIONAFACTURA, null))
                    {
                        MessageBox.Show("No tiene derecho para cambiar una remision ya hecha a factura");
                        return false;
                    }

                    if (m_Docto.IFECHAHORA.Month != DateTime.Now.Month)
                    {
                        if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_FACTURARFUERADEMES, null))
                        {
                            MessageBox.Show("No tiene derecho para facturar una remision fuera de este mes");
                            return false;
                        }
                    }

                }

                if (m_Docto.ITIMBRADOFECHAFACTURA != null && m_Docto.ITIMBRADOFECHAFACTURA.AddHours(48).CompareTo(DateTime.Now) <= 0)
                {
                    m_Docto.ITIMBRADOFECHAFACTURA = DateTime.Now;
                    doctoD.ACTUALIZARFECHASAT(m_Docto, null);
                }


                bool retorno = false;


                CDOCTOPAGOBE pagoTemporal = new CDOCTOPAGOBE();
                CDOCTOPAGOD doctoPagoD = new CDOCTOPAGOD();

                pagoTemporal = doctoPagoD.seleccionarPrimerDOCTOPAGO(m_Docto, null);

                iPosReporting.WFFacturaElectronica fe = new iPosReporting.WFFacturaElectronica(this.m_Docto, CurrentUserID.CurrentParameters, WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_TIMBRAR, this.m_DoctoRef, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
                fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
                fe.m_vendedorId = CurrentUserID.CurrentUser.IID;
                fe.ShowDialog();
                retorno = fe.m_facturacionRealizada;
                fe.Dispose();
                GC.SuppressFinalize(fe);

                if (retorno)
                {
                    m_Docto.IESFACTURAELECTRONICA = "S";
                    doctoD.ACTUALIZARESFACTURAELECTRONICA(m_Docto, null);
                }


                return retorno;

            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrio una excepcion");
                return false;
            }
            finally {

                generandoFacturaElectronica = false;
            }
        }




        private bool generarComprobanteTraslado(bool bGenerarCartaPorte)
        {

            bool retorno = false;

            CUSUARIOSD usuariosD = new CUSUARIOSD();

            CDOCTOPAGOBE pagoTemporal = new CDOCTOPAGOBE();
            CDOCTOPAGOD doctoPagoD = new CDOCTOPAGOD();

            pagoTemporal = doctoPagoD.seleccionarPrimerDOCTOPAGO(m_Docto, null);

            iPosReporting.WFFacturaElectronica fe = new iPosReporting.WFFacturaElectronica(this.m_Docto, CurrentUserID.CurrentParameters, WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_COMPROBTRASL, this.m_DoctoRef, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
            fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
            fe.m_vendedorId = CurrentUserID.CurrentUser.IID;
            fe.m_generarCartaPorte = bGenerarCartaPorte;
            fe.ShowDialog();
            retorno = fe.m_facturacionRealizada;
            fe.Dispose();
            GC.SuppressFinalize(fe);

            return retorno;

        }



        private bool imprimirComprobanteTraslado()
        {

            bool retorno = false;

            CUSUARIOSD usuariosD = new CUSUARIOSD();

            CDOCTOPAGOBE pagoTemporal = new CDOCTOPAGOBE();
            CDOCTOPAGOD doctoPagoD = new CDOCTOPAGOD();

            pagoTemporal = doctoPagoD.seleccionarPrimerDOCTOPAGO(m_Docto, null);

            iPosReporting.WFFacturaElectronica fe = new iPosReporting.WFFacturaElectronica(this.m_Docto, CurrentUserID.CurrentParameters, WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_GENPDF_COMPROBTRASL, this.m_DoctoRef, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
            fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
            fe.m_vendedorId = CurrentUserID.CurrentUser.IID;
            fe.ShowDialog();
            retorno = fe.m_facturacionRealizada;
            fe.Dispose();
            GC.SuppressFinalize(fe);

            return retorno;

        }


        private bool imprimirFacturaElectronica()
        {

            bool retorno;

            CDOCTOD doctoD = new CDOCTOD();
            m_Docto = doctoD.seleccionarDOCTO(m_Docto, null);



            if ((bool)m_Docto.isnull["IFOLIOSAT"] || (bool)m_Docto.isnull["IESTATUSDOCTOID"]
                || m_Docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_COMPLETO || m_Docto.IFOLIOSAT <= 0)
            {
                MessageBox.Show("No se puede imprimir la factura electronica , cheque que se haya generado la factura electronica de este registro");
                return false;
            }




            WFFacturaElectronica fe = new WFFacturaElectronica(this.m_Docto, CurrentUserID.CurrentParameters, WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_GENERARPDF, this.m_DoctoRef, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
            CUSUARIOSD usuariosD = new CUSUARIOSD();
            fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
            fe.ShowDialog();
            retorno = fe.m_facturacionRealizada;
            fe.Dispose();
            GC.SuppressFinalize(fe);
            return retorno;






        }





        private bool generarFacturaElectronicaPorId(long doctoId, FbTransaction fTrans, ref string resComentario, bool bIgnoreDerecho)
        {

            CDOCTOBE docto = new CDOCTOBE();
            CDOCTOD doctoD = new CDOCTOD();
            docto.IID = doctoId;
            docto = doctoD.seleccionarDOCTO(docto, fTrans);

            if (docto == null)
            {

                resComentario = "No se encontro la factura electronica";
                return false;
            }

            if (docto.IFACTCONSID > 0 || docto.IDEVCONSID > 0)
            {

                MessageBox.Show("No se puede generar la factura electronica porque pertenece a una factura consolidada");
                return false;
            }


            CUSUARIOSD usuariosD = new CUSUARIOSD();
            if (!bIgnoreDerecho)
            {
                if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_REMISIONAFACTURA, null))
                {
                    MessageBox.Show("No tiene derecho para cambiar una remision ya hecha a factura");
                    return false;
                }

                if (m_Docto.IFECHAHORA.Month != DateTime.Now.Month)
                {
                    if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_FACTURARFUERADEMES, null))
                    {
                        MessageBox.Show("No tiene derecho para facturar una remision fuera de este mes");
                        return false;
                    }
                }

            }





            bool retorno = false;

            
            CDOCTOPAGOBE pagoTemporal = new CDOCTOPAGOBE();
            CDOCTOPAGOD doctoPagoD = new CDOCTOPAGOD();

            pagoTemporal = doctoPagoD.seleccionarPrimerDOCTOPAGO(docto, null);

            iPosReporting.WFFacturaElectronica fe = new iPosReporting.WFFacturaElectronica(docto, CurrentUserID.CurrentParameters, WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_TIMBRAR, fTrans, null, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
            fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
            fe.m_vendedorId = CurrentUserID.CurrentUser.IID;
            fe.ShowDialog();
            retorno = fe.m_facturacionRealizada;
            fe.Dispose();
            GC.SuppressFinalize(fe);

            if (retorno)
            {
                docto.IESFACTURAELECTRONICA = "S";
                doctoD.ACTUALIZARESFACTURAELECTRONICA(m_Docto, null);
            }


            return retorno;
        }



        private bool imprimirFacturaElectronicaPorId(long doctoId)
        {

            bool retorno;

            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE docto = new CDOCTOBE();
            docto.IID = doctoId;
            docto = doctoD.seleccionarDOCTO(docto, null);

            if (docto == null)
            {

                MessageBox.Show("No se encontro la factura electronica");
                return false;
            }


            if ((bool)docto.isnull["IFOLIOSAT"] || (bool)docto.isnull["IESTATUSDOCTOID"]
                || docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_COMPLETO || docto.IFOLIOSAT <= 0)
            {
                MessageBox.Show("No se puede imprimir la factura electronica , cheque que se haya generado la factura electronica de este registro");
                return false;
            }


            iPosReporting.WFFacturaElectronica fe = new iPosReporting.WFFacturaElectronica(docto, CurrentUserID.CurrentParameters, iPosReporting.WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_GENERARPDF, null, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
            CUSUARIOSD usuariosD = new CUSUARIOSD(); fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
            fe.ShowDialog();
            retorno = fe.m_facturacionRealizada;
            fe.Dispose();
            GC.SuppressFinalize(fe);


            PosPrinter.ImprimirCuponesSiAplica(m_Docto.IID, null);

            return retorno;
        }


        private bool imprimirTicketFacturaElectronica()
        {

            bool retorno;

            CDOCTOD doctoD = new CDOCTOD();
            m_Docto = doctoD.seleccionarDOCTO(m_Docto, null);


            if ((bool)m_Docto.isnull["IFOLIOSAT"] || (bool)m_Docto.isnull["IESTATUSDOCTOID"]
                || m_Docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_COMPLETO || m_Docto.IFOLIOSAT <= 0)
            {
                MessageBox.Show("No se puede imprimir la factura electronica , cheque que se haya generado la factura electronica de este registro");
                return false;
            }


            WFFacturaElectronica fe = new WFFacturaElectronica(this.m_Docto, CurrentUserID.CurrentParameters, WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_IMPRIMIRTICKET, this.m_DoctoRef, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
            CUSUARIOSD usuariosD = new CUSUARIOSD(); fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
            fe.ShowDialog();
            retorno = fe.m_facturacionRealizada;
            fe.Dispose();
            GC.SuppressFinalize(fe);
            return retorno;
        }


        

        private bool imprimirTicketFacturaElectronicaPorId(long doctoId)
        {
            bool retorno;

            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE doctoBE = new CDOCTOBE();
            doctoBE.IID = doctoId;
            doctoBE = doctoD.seleccionarDOCTO(doctoBE, null);

            if ((bool)doctoBE.isnull["IFOLIOSAT"] || (bool)doctoBE.isnull["IESTATUSDOCTOID"]
               || doctoBE.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_COMPLETO || doctoBE.IFOLIOSAT <= 0)
            {
                MessageBox.Show("No se puede imprimir la factura electronica , cheque que se haya generado la factura electronica de este registro");
                return false;
            }


            WFFacturaElectronica fe = new WFFacturaElectronica(doctoBE, CurrentUserID.CurrentParameters, WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_IMPRIMIRTICKET, this.m_Docto, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
            CUSUARIOSD usuariosD = new CUSUARIOSD(); fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
            fe.ShowDialog();
            retorno = fe.m_facturacionRealizada;
            fe.Dispose();
            GC.SuppressFinalize(fe);
            return retorno;

        }


        private void GetSwfMovieSource()
        {


            var rand = new Random();


            /*if (CurrentUserID.CurrentParameters.IMOSTRARFLASH.Equals("S"))
            {
                string[] files = Directory.GetFiles(Application.StartupPath + "\\sampdata\\SWF", "*.swf");
                string newMovie = files[rand.Next(files.Length)];

                axShockwaveFlash1.Stop();
                axShockwaveFlash1.Movie = newMovie;
                axShockwaveFlash1.Play();
            }
            else
            {
                axShockwaveFlash1.Visible = false;
            }
            */


            if ((bool)CurrentUserID.CurrentParameters.isnull["IMOSTRARIMAGENENVENTA"] || !CurrentUserID.CurrentParameters.IMOSTRARIMAGENENVENTA.Equals("S"))
            {
                string[] filesImgs = Directory.GetFiles(Application.StartupPath + "\\sampdata\\JPG", "*.jpg");
                string newImage = filesImgs[rand.Next(filesImgs.Length)];
                pictureBox1.BackgroundImage = Image.FromFile(newImage);
            }
            else if (pictureBox1.BackgroundImage == null)
            {
                try
                {

                    if (File.Exists(CurrentUserID.CurrentParameters.IFACT_ELECT_FOLDER + "\\facturaelectronica\\IMG\\logofarmafree.png"))
                    {
                        pictureBox1.BackgroundImage = Image.FromFile(CurrentUserID.CurrentParameters.IFACT_ELECT_FOLDER + "\\facturaelectronica\\IMG\\logofarmafree.png");
                    }
                }
                catch
                {
                }
            }


        }

        private void WFPuntoDeVenta_Shown(object sender, EventArgs e)
        {
            this.TBCommandLine.Focus();


            GetSwfMovieSource();


        }

        private void WFPuntoDeVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            FinalizarVisitaDoctoActual();

            if (m_bSalirSinPreguntar)
                return;

            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            DateTime fechaCorte = DateTime.MinValue;
            if (!pvd.HayCorteActivo(ref fechaCorte, iPos.CurrentUserID.CurrentUser.IID))
                return;

            if (!(bool)m_Docto.isnull["IID"]
                && m_estadoVenta != (int)estadoVenta.e_Cancelada
                && m_estadoVenta != (int)estadoVenta.e_Cerrada
                && CurrentUserID.CurrentParameters.IPREGUNTACANCELACOTIZACION != null && CurrentUserID.CurrentParameters.IPREGUNTACANCELACOTIZACION.Equals("S"))
            {
                CancelarVentaActual();
            }

            if (!CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S") && !m_bDoctoUnico)
                if (MessageBox.Show("Realmente quiere salir de esta pantalla?", "Salir de esta pantalla", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    e.Cancel = true;


        }


        private void RefreshCurrentItemDisplay(int iRowIndex)
        {
            LimpiarCurrentItemDisplay();
            /* CPARAMETROD parametro = new CPARAMETROD();
             CPARAMETROBE parametroBE = parametro.seleccionarPARAMETROActual(null);

             if(parametroBE.IRUTAREPORTESSISTEMA != null && parametroBE.IRUTAREPORTESSISTEMA.Trim().Length > 0)
             {

             }*/

            if (!(bool)CurrentUserID.CurrentParameters.isnull["IMOSTRARIMAGENENVENTA"] && CurrentUserID.CurrentParameters.IMOSTRARIMAGENENVENTA.Equals("S"))
            {
                string imagePath = "";
                if (this.gridPVDataGridView.Rows[iRowIndex].Cells["IMAGEN"].Value != null && this.gridPVDataGridView.Rows[iRowIndex].Cells["IMAGEN"].Value.ToString() != "")
                {
                    imagePath = CurrentUserID.CurrentParameters.IRUTAIMAGENESPRODUCTO + "\\" + this.gridPVDataGridView.Rows[iRowIndex].Cells["IMAGEN"].Value.ToString();
                }
                else
                {
                    imagePath = CurrentUserID.CurrentParameters.IFACT_ELECT_FOLDER.Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)) + "\\facturaelectronica\\IMG\\logofarmafree.png";
                }
                try
                {
                    if (File.Exists(imagePath))
                    {
                        pictureBox1.BackgroundImage = Image.FromFile(imagePath);
                    }
                }
                catch
                {
                }

            }


            if (this.gridPVDataGridView.Rows[iRowIndex].Cells["DESCRIPCION2"].Value != null && this.gridPVDataGridView.Rows[iRowIndex].Cells["DESCRIPCION2"].Value.ToString() != "")
                this.tbCurrentItem.Text += " " + this.gridPVDataGridView.Rows[iRowIndex].Cells["DESCRIPCION2"].Value.ToString();


            if (this.gridPVDataGridView.Rows[iRowIndex].Cells["LOTE"].Value != null && this.gridPVDataGridView.Rows[iRowIndex].Cells["LOTE"].Value.ToString() != "")
                this.tbCurrentItem.Text += " " + this.gridPVDataGridView.Rows[iRowIndex].Cells["LOTE"].Value.ToString();

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

        private void ChecarCorteActivo()
        {

            if (m_bDoctoUnico)
                return;

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


                CCORTEBE corteBuffer = new CCORTEBE();
                CCORTED corteD = new CCORTED();
                corteBuffer.ICAJEROID = iPos.CurrentUserID.CurrentUser.IID;
                corteBuffer.IFECHACORTE = fechaCorte;
                corteBuffer = corteD.seleccionarCORTEXDIAyCAJERO(corteBuffer, null);

                if (corteBuffer == null)
                {
                    MessageBox.Show("No se pudo obtener la informacion del corte actual");
                    this.Close();
                }

                if ((bool)corteBuffer.isnull["ITIPOCORTEID"] || corteBuffer.ITIPOCORTEID == DBValues._TIPO_CORTENORMAL)
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
                else
                {
                    return;
                }
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

        private void ObtenerCaja()
        {
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            m_Caja = pvd.ObtenerDatosCaja(iPos.CurrentUserID.CurrentCompania.IEM_CAJA);
        }


        private void LimpiarCurrentItemDisplay()
        {
            this.tbCurrentItem.Text = "";
        }

        private bool checarAutorizacionEliminarODisminuirDetalle()
        {

            if (CurrentUserID.CurrentParameters.IREQAUTELIMDETALLECOTI != null && CurrentUserID.CurrentParameters.IREQAUTELIMDETALLECOTI.Equals("S"))
            {
                CUSUARIOSD usersD = new CUSUARIOSD();
                Boolean bTieneDerechoAEliminarDetalleCotizacion = usersD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_ELIM_DETALLE_COTI, null);

                if (!bTieneDerechoAEliminarDetalleCotizacion)
                {
                    WFPreguntaAutorizacion ps2 = new WFPreguntaAutorizacion(false);
                    ps2.ShowDialog();
                    CPERSONABE userBE = ps2.m_userBE;
                    CPERSONABE supervisorBE = ps2.m_supervisorBE;
                    bool bPassValido = ps2.m_bPassValido;
                    bool bIsSupervisor = ps2.m_bIsSupervisor;
                    bool bIsAdministrador = ps2.m_bIsAdministrador;
                    ps2.Dispose();
                    GC.SuppressFinalize(ps2);

                    if (!bPassValido)
                        return false;

                    bTieneDerechoAEliminarDetalleCotizacion = usersD.UsuarioTienePermisos((int)supervisorBE.IID, (int)DBValues._DERECHO_ELIM_DETALLE_COTI, null);

                    if (!bTieneDerechoAEliminarDetalleCotizacion)
                    {
                        MessageBox.Show("El usuario para supervisar ingresado no tiene derecho a aprobar eliminaciones o disminuciones de detalle en cotizacion");
                        return false;
                    }

                }
            }

            return true;
        }

        private void EliminarDetalle()
        {
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            CMOVTOBE movtoBE = new CMOVTOBE();

            if (this.gridPVDataGridView.Rows.Count <= 0)
                return;



            

            //asegurarnos de que realmente se quiere eliminar el detalle y que el supervisor dio su aval
            if (MessageBox.Show("Realmente quiere eliminar el detalle de venta?", "Eliminar detalle de venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //WFPasswordSupervisor ps = new WFPasswordSupervisor();
                //ps.ShowDialog();
                //if (!ps.bPassValido)
                //    return;

                if (!checarAutorizacionEliminarODisminuirDetalle())
                    return;




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

                //recalcula promocion por monto si aplica
                string comentario = "";
                RecalcularPromocionMontoMinSiAplica(ref comentario, null);

                
                RefrescarGridVentas(true);
                
            }
            RefrescarEstatusBotones();
            this.TBCommandLine.Focus();



        }

        private void BTEliminarDetalle_Click(object sender, EventArgs e)
        {
            if (m_estadoVenta == (int)estadoVenta.e_Cerrada || m_estadoVenta == (int)estadoVenta.e_Cancelada)
                return;

            if ((m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_COMPLETO || m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_BORRADOR) && (m_Docto.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_RECARGA || m_Docto.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_PAGOSERVICIO))
            {
                MessageBox.Show("Las recargas y pago de servicios no se pueden cancelar ni borrar");
                return;
            }



            EliminarDetalle();



                
        }

        private void RefrescarEstatusBotones()
        {
            this.BTReenviarTraslados.Visible = false;
            this.BtnImprimirFE.Visible = false;
            this.btEditarVenta.Visible = false;
            btnCobranzaMovil.Visible = false;

            if (!(bool)m_Docto.isnull["IID"] && gridPVDataGridView.Rows.Count > 0)
            {
                this.BTPasarANueva.Enabled = true;
                this.BTPasarANueva.ForeColor = Color.Black;
                this.BTPasarANueva.BackColor = Color.FromArgb(41, 121, 255);
                this.BTCancelarVenta.Enabled = true;
                this.BTCancelarVenta.ForeColor = Color.Black;
                this.BTCancelarVenta.BackColor = Color.FromArgb(219, 44, 44);
                this.BTCotizacion.Enabled = true;

                if (!m_bTieneDerechoBloquearF6)
                {
                    this.BTCerrarVenta.Enabled = true;
                    this.BTCerrarVenta.ForeColor = Color.Black;
                    this.BTCerrarVenta.BackColor = Color.FromArgb(74, 196, 77);
                }
                else
                {
                    this.BTCerrarVenta.Enabled = false;
                    this.BTCerrarVenta.BackColor = Color.Gray;
                }


                if (m_Docto.ITIPODOCTOID != DBValues._DOCTO_TIPO_TRASPASO_ENVIO)
                    this.BTRecalcular.Enabled = true;
                else
                    this.BTRecalcular.Enabled = false;

                if (m_Docto.IPERSONAID == DBValues._CLIENTEMOSTRADOR || m_ClienteId == DBValues._CLIENTEMOSTRADOR)
                    this.btnNuevaApartado.Enabled = true;
                else
                    this.btnNuevaApartado.Enabled = false;

                if (!(m_Docto.IPERSONAID == DBValues._CLIENTEMOSTRADOR || m_ClienteId == DBValues._CLIENTEMOSTRADOR)
                    && (m_Docto.IPERSONAID > 0 && m_ClienteId > 0) && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTAMOVIL)
                    btnCobranzaMovil.Visible = true;
                else
                    btnCobranzaMovil.Visible = false;


                this.BTPagarConVale.Enabled = true;
                // 
                this.gridPVDataGridView.Columns["TOTALVALE"].Visible = true;


                if (!(bool)m_Docto.isnull["ITIPODOCTOID"])
                {
                    if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO)
                    {
                        this.BTPagarConVale.Enabled = false;
                        this.btnNuevaApartado.Enabled = false;
                    }
                }


                if (CurrentUserID.CurrentParameters.IHABSURTIDOPREVIO == "S")
                {

                    this.BTEnviarASurtir.Enabled = true;
                    this.BTEnviarASurtir.ForeColor = Color.Black;
                    this.BTEnviarASurtir.BackColor = Color.FromArgb(0, 192, 192);
                }

                this.btnDomicilioEntrega.Visible = ((m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTAMOVIL || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA) && m_ClienteId != DBValues._CLIENTEMOSTRADOR && m_ClienteId != 0);

            }
            else
            {
                this.BTPasarANueva.Enabled = false;
                this.BTPasarANueva.BackColor = Color.Gray;
                this.BTCancelarVenta.Enabled = false;
                this.BTCancelarVenta.BackColor = Color.Gray;
                this.BTCotizacion.Enabled = false;
                this.BTCerrarVenta.Enabled = false;
                this.BTCerrarVenta.BackColor = Color.Gray;
                this.BTRecalcular.Enabled = false;
                this.btnNuevaApartado.Enabled = false;
                this.BTPagarConVale.Enabled = false;
                this.gridPVDataGridView.Columns["TOTALVALE"].Visible = false;
                this.BTEnviarASurtir.Enabled = false;
                this.BTEnviarASurtir.BackColor = Color.Gray;


                this.btnCobranzaMovil.Visible = (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTAMOVIL && m_ClienteId != DBValues._CLIENTEMOSTRADOR && m_ClienteId != 0);

                this.btnDomicilioEntrega.Visible = false;
            }

            if (gridPVDataGridView.Rows.Count > 0)
            {
                this.BTEliminarDetalle.Enabled = true;
                this.BTEliminarDetalle.ForeColor = Color.Black;
                this.BTEliminarDetalle.BackColor = Color.FromArgb(219, 44, 44);
                this.btnAdjunto.Enabled = true;
                this.btnAdjunto.ForeColor = Color.Black;
                this.btnAdjunto.BackColor = Color.FromArgb(41, 121, 255);
                this.btnListaAdjuntos.Enabled = true;
                this.btnListaAdjuntos.ForeColor = Color.Black;
                this.btnListaAdjuntos.BackColor = Color.FromArgb(41, 121, 255);
            }
            else
            {
                this.BTEliminarDetalle.Enabled = false;
                this.BTEliminarDetalle.BackColor = Color.Gray;
                this.btnAdjunto.Enabled = false;
                this.btnAdjunto.BackColor = Color.Gray;
                this.btnListaAdjuntos.Enabled = false;
                this.btnListaAdjuntos.BackColor = Color.Gray;
            }

            if (bTieneDerechoAVentasAFuturo && CurrentUserID.CurrentParameters.IHABVENTASAFUTURO != null && CurrentUserID.CurrentParameters.IHABVENTASAFUTURO == "S")
            {
                this.btnVentaAFuturo.Visible = true;
            }
            else
            {
                this.btnVentaAFuturo.Visible = false;
            }


            this.btnVendedorEjecutivo.Visible = bTieneDerechoAsignarVendedorEjecutivo && (m_Docto != null && m_Docto.IID > 0 && m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_BORRADOR);


        }

        private void CargarArchivosAdjuntos(long doctoid)
        {
            loadedFiles.Clear();
            CARCHIVOSADJUNTOSD adjuntar = new CARCHIVOSADJUNTOSD();
            CARCHIVOSADJUNTOSBE[] adjuntos = adjuntar.seleccionarARCHIVOSADJUNTOSPorDOCTOID(doctoid);
            if (adjuntos.Length == 0)
            {
                return;
            }

            foreach (CARCHIVOSADJUNTOSBE adj in adjuntos)
            {
                loadedFilesDate = adj.IFECHA;
                loadedFilesWorkHours = adj.IHORASDETRABAJO;
                loadedFiles.Add(adj.IRUTAARCHIVO);
            }
            loadedFilesCerrada = true;
        }


        private void AbrirVentasCerradasYDevoluciones(int iDoctoSelectedId, string sucursalDestinoSelected)
        {
            IrANuevaVenta();

            CUSUARIOSD usuariosD = new CUSUARIOSD();


            if (iDoctoSelectedId == 0)
            {
                WFLOOKUPVENTAS look = new WFLOOKUPVENTAS((int)DBValues._DOCTO_ESTATUS_COMPLETO, 0);
                look.ShowDialog();

                DataRow dr = look.m_rtnDataRow;

                look.Dispose();
                GC.SuppressFinalize(look);

                if (dr != null)
                    iDoctoSelectedId = int.Parse(dr[0].ToString());
            }

            if (iDoctoSelectedId != 0)
            {


                if (!VerificarUnicaVisitaXDocto(iDoctoSelectedId, (long)CurrentUserID.CurrentCompania.IEM_CAJA, CurrentUserID.CurrentUser.IID))
                {
                    return;
                }


                m_Docto.IID = iDoctoSelectedId;
                CDOCTOD vData = new CDOCTOD();
                m_Docto = vData.seleccionarDOCTO(m_Docto, null);

                this.btnReimprimirVoucherBanc.Enabled = false;
                this.btnReimprimirVoucherBanc.Visible = false;


                if (m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_CANCELADA || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_CANCELACION)
                    m_estadoVenta = (int)estadoVenta.e_Cancelada;
                else
                {
                    if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTAAPARTADO || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO ||
                        (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_PEDIDO_TRASPASO_SALIDA && m_Docto.ISUBTIPODOCTOID != DBValues._DOCTO_SUBTIPO_TRASPASOFRANQUICIA) ||
                        m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ALMACEN || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA_FUTURO /*|| m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTAMOVIL*/)
                    {
                        this.BTCancelarVenta.Enabled = true;
                        this.BTCancelarVenta.ForeColor = Color.Black;
                        this.BTCancelarVenta.BackColor = Color.FromArgb(219, 44, 44);
                        if (m_Docto.IPAGOBANCOMERAPLICADO == "S")
                        {
                            this.btnReimprimirVoucherBanc.Enabled = true;
                            this.btnReimprimirVoucherBanc.Visible = true;
                        }
                        else
                        {
                            this.btnReimprimirVoucherBanc.Enabled = false;
                            this.btnReimprimirVoucherBanc.Visible = false;
                        }
                    }
                    else
                    {
                        this.BTCancelarVenta.Enabled = false;
                        this.BTCancelarVenta.BackColor = Color.Gray;
                    }
                    this.BTCotizacion.Enabled = true;
                    m_estadoVenta = (int)estadoVenta.e_Cerrada;
                }

                RefrescarGridVentas();
                CargarArchivosAdjuntos(m_Docto.IID);

                this.gridPVDataGridView.BackgroundColor = Color.Gainsboro;
                this.gridPVDataGridView.DefaultCellStyle.BackColor = Color.Gainsboro;
                this.TBCommandLine.Enabled = false;




                //traslados
                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_PEDIDO_TRASPASO_SALIDA)
                {
                    try
                    {

                        TBCliente.Text = sucursalDestinoSelected;
                    }
                    catch
                    {
                    }
                }
                //bOTON ENVIAR TRASLADOS
                if (m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_COMPLETO &&
                    ((m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_PEDIDO_TRASPASO_SALIDA)
                        || (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA && (m_Docto.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_TRASPASOFRANQUICIA || m_Docto.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_TRASPASOFRANQUICIA_SALIDA)))
                    )
                {
                    if (usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_REENVIAR_TRASLADOS, null))
                    {
                        this.BTReenviarTraslados.Visible = true;
                    }
                }
                else
                    this.BTReenviarTraslados.Visible = false;


                // boton cliente y recalculo
                if (m_Docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_BORRADOR)
                {
                    this.BTRecalcular.Enabled = false;
                    this.BTCliente.Enabled = false;
                    this.TBCliente.Enabled = false;
                }
                else
                {


                    if (m_Docto.ITIPODOCTOID != DBValues._DOCTO_TIPO_TRASPASO_ENVIO)
                        this.BTRecalcular.Enabled = true;
                    else
                        this.BTRecalcular.Enabled = false;

                    this.BTCliente.Enabled = true;
                    this.TBCliente.Enabled = true;
                }

                bool bContieneTraslado = vData.ContieneComprobante(m_Docto, "T", null);

                if (!bContieneTraslado && ((bool)m_Docto.isnull["IFOLIOSAT"] || (bool)m_Docto.isnull["IESTATUSDOCTOID"]
                    || m_Docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_COMPLETO || m_Docto.IFOLIOSAT <= 0
                     || m_Docto.ITIMBRADOUUID == null || m_Docto.ITIMBRADOUUID.Length == 0))
                    this.BtnImprimirFE.Visible = false;
                else
                    this.BtnImprimirFE.Visible = true;

                if (!(bool)m_Docto.isnull["IFOLIOSAT"] && m_Docto.IFOLIOSAT > 0)
                {
                    this.LBFolioFacturaElectronica.Text = m_Docto.IFOLIOSAT.ToString();
                    this.LBSerieFacturaElectronica.Text = m_Docto.ISERIESAT.ToString();
                }
                else
                {
                    this.LBFolioFacturaElectronica.Text = "...";
                    this.LBSerieFacturaElectronica.Text = "...";
                }


                this.BTPasarANueva.Enabled = true;
                this.BTPasarANueva.ForeColor = Color.Black;
                this.BTPasarANueva.BackColor = Color.FromArgb(41, 121, 255);
                this.BTEliminarDetalle.Enabled = false;
                this.BTEliminarDetalle.BackColor = Color.Gray;
                this.btnAdjunto.Enabled = true;
                this.btnAdjunto.ForeColor = Color.Black;
                this.btnAdjunto.BackColor = Color.FromArgb(41, 121, 255);
                this.btnListaAdjuntos.Enabled = true;
                this.btnListaAdjuntos.ForeColor = Color.Black;
                this.btnListaAdjuntos.BackColor = Color.FromArgb(41, 121, 255);
                this.BTCerrarVenta.Enabled = false;
                this.BTCerrarVenta.BackColor = Color.Gray;
                this.btnNuevaApartado.Enabled = false;
                this.BTPagarConVale.Enabled = false;
                this.gridPVDataGridView.Columns["TOTALVALE"].Visible = false;
                this.LBOperacion.Text = "Consulta";
                this.BTEnviarASurtir.Enabled = false;
                this.BTEnviarASurtir.BackColor = Color.Gray;

                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTAMOVIL &&
                    m_Docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_CANCELADA /*&&
                    m_Docto.ITRASLADOAFTP != DBValues._DB_BOOLVALUE_SI*/)
                {
                    this.btEditarVenta.Visible = true;
                }
                else
                {
                    this.btEditarVenta.Visible = false;
                }

                //this.ComboVendedorFinal.Enabled = false;
                this.VENDEDORIDTextBox.Enabled = false;

                BTValidarExistencia.Visible = false;

                /*if (!(bool)m_Docto.isnull["IVENDEDORFINAL"])
                {
                    this.ComboVendedorFinal.SelectedValue = m_Docto.IVENDEDORFINAL;
                }*/

                if (!(bool)m_Docto.isnull["IVENDEDORFINAL"])
                {

                    string strBuffer = "";
                    this.VENDEDORIDTextBox.DbValue = m_Docto.IVENDEDORFINAL.ToString();
                    this.VENDEDORIDTextBox.MostrarErrores = false;
                    this.VENDEDORIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.VENDEDORIDTextBox.MostrarErrores = true;
                }
                else
                {
                    this.VENDEDORIDTextBox.Text = "";
                }

                // vendedor ejecutivo
                if (!(bool)m_Docto.isnull["IVENDEDOREJECUTIVOID"])
                {

                    LlenarDatosVendedorEjecutivo(m_Docto.IVENDEDOREJECUTIVOID);
                }
                else
                {
                    this.m_vendedorEjecutivoId = 0;
                    lblVendedorEjecutivo.Text = "";
                }

                if ((m_Docto.ISUBTIPODOCTOID == 7 || m_Docto.ISUBTIPODOCTOID == 8 || m_Docto.ISUBTIPODOCTOID == 15) && (!(bool)m_Docto.isnull["IDOCTOREFID"]))
                {
                    CDOCTOD doctoDAux = new CDOCTOD();
                    CDOCTOBE doctoBEAux = new CDOCTOBE();

                    doctoBEAux.IID = m_Docto.IDOCTOREFID;
                    doctoBEAux = doctoDAux.seleccionarDOCTO(doctoBEAux, null);
                    if (doctoBEAux != null)
                    {
                        if (m_Docto.ITIPODOCTOID == 21)
                        {
                            if (m_Docto.ISUBTIPODOCTOID == 7)
                                this.lblTextoAuxiliar.Text = "Venta por surtimiento a franquicia folio : # " + doctoBEAux.IFOLIO.ToString();
                            else if (m_Docto.ISUBTIPODOCTOID == 8)
                                this.lblTextoAuxiliar.Text = "Venta por traslado a franquicia folio : # " + doctoBEAux.IFOLIO.ToString();
                            else if (m_Docto.ISUBTIPODOCTOID == 15)
                                this.lblTextoAuxiliar.Text = "Nota Movil 1 : " + doctoBEAux.IOBSERVACION + ". Notas Movil 2 : " + doctoBEAux.IDESCRIPCION;
                        }
                        else if (m_Docto.ITIPODOCTOID == 81)
                        {

                            if (m_Docto.ISUBTIPODOCTOID == 7)
                                this.lblTextoAuxiliar.Text = "Surtimiento a franquicia relacionada a la venta folio #" + doctoBEAux.IFOLIO.ToString();
                            else if (m_Docto.ISUBTIPODOCTOID == 8)
                                this.lblTextoAuxiliar.Text = "Surtimiento a traslado relacionada a la venta folio #" + doctoBEAux.IFOLIO.ToString();
                        }
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

                llenarDatosGeneralesDocto();


            }
        }

        private void llenarDatosGeneralesDocto()
        {
            m_bLlenandoDoctoDatosGenerales = true;

            if (!(bool)m_Docto.isnull["IPERSONAID"])
            {
                this.m_ClienteId = m_Docto.IPERSONAID;
                llenarDatosCliente();
                PonerHabilitacionPagoTarjeta();
            }

            if (!(bool)m_Docto.isnull["ITIPODOCTOID"] && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_PEDIDO_TRASPASO_SALIDA || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO)
            {

                this.LBOperacion.Text = "Traslado";
                this.BTCliente.Text = "SUC_DEST:";
                this.BTCliente.Enabled = false;
                this.TBCliente.Enabled = false;
                m_ClienteId = DBValues._CLIENTEMOSTRADOR;
                PonerHabilitacionPagoTarjeta();

                llenarDatosSucursalDestino();



            }
            if (!(bool)m_Docto.isnull["ITIPODOCTOID"] && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA_FUTURO)
            {
                PonerVariablesModoVentaAFuturo();
            }



            if (!(bool)m_Docto.isnull["IFOLIO"])
            {
                this.LBVenta.Text = m_Docto.IFOLIO.ToString();
            }

            /*if (!(bool)m_Docto.isnull["IVENDEDORFINAL"])
            {
                this.ComboVendedorFinal.SelectedValue = m_Docto.IVENDEDORFINAL;
            }*/
            if (!(bool)m_Docto.isnull["IVENDEDORFINAL"])
            {

                string strBuffer = "";
                this.VENDEDORIDTextBox.DbValue = m_Docto.IVENDEDORFINAL.ToString();
                this.VENDEDORIDTextBox.MostrarErrores = false;
                this.VENDEDORIDTextBox.MValidarEntrada(out strBuffer, 1);
                this.VENDEDORIDTextBox.MostrarErrores = true;
            }
            else
            {
                this.VENDEDORIDTextBox.Text = "";
            }


            // vendedor ejecutivo
            if (!(bool)m_Docto.isnull["IVENDEDOREJECUTIVOID"])
            {

                LlenarDatosVendedorEjecutivo(m_Docto.IVENDEDOREJECUTIVOID);
            }
            else
            {
                this.m_vendedorEjecutivoId = 0;
                lblVendedorEjecutivo.Text = "";
            }



            if (!(bool)m_Docto.isnull["INOTAPAGO"])
            {
                NOTAPAGOTextBox.Text = m_Docto.INOTAPAGO;
            }
            else
            {
                NOTAPAGOTextBox.Text = "";
            }

            CBXPagoConTarjeta.SelectedIndex = (m_Docto.IPAGOCONTARJETA == "S") ? 1 : 
                                                    (m_Docto.IPAGOCONTARJETA == "C") ? 2 :
                                                        (m_Docto.IPAGOCONTARJETA == "D") ? 3 : 0;
            CBACredito.Checked = (m_Docto.IPAGOACREDITO == "S") ? true : false;
            llenarDatosRutaEmbarque();


            PonerHabilitacionObservacionesContadoFactura();
            CBContado.Checked = (m_Docto.IMOVILCONTADO == "S") ? true : false;
            CBFactura.Checked = (m_Docto.IESFACTURAELECTRONICA == "S") ? true : false;
            ObservacionesTextBox.Text = m_Docto.IOBSERVACIONES;

            CBEspecial.Checked = (m_Docto.IESVENTAESPECIAL == "S") ? true : false;

            CBCotizacionEnrutada.Checked = (m_Docto.ICOTI_ENRUTADA == "S") ? true : false;

            llenarUtilidad();

            m_bLlenandoDoctoDatosGenerales = false;




        }


        private void llenarUtilidad()
        {
            if (m_Docto != null)
            {
                decimal porcentajeUtilidad = m_Docto.ISUBTOTAL  != 0 ?
                                                              m_Docto.IUTILIDAD / (m_Docto.ISUBTOTAL ) :
                                                              0;
                porcentajeUtilidad = (porcentajeUtilidad > 0 ? porcentajeUtilidad : 0) * 100.00m;
                this.lblUtilidad.Text = "Utilidad: " + porcentajeUtilidad.ToString("#,##0.00") +  " %";
            }
            else
            {
                this.lblUtilidad.Text = "";
            }

        }


        private void llenarDatosRutaEmbarque()
        {
            if (!(bool)m_Docto.isnull["IRUTAEMBARQUEID"] && m_Docto.IRUTAEMBARQUEID > 0)
            {
                CRUTAEMBARQUED rutaEmbarqueD = new CRUTAEMBARQUED();
                CRUTAEMBARQUEBE rutaEmbarqueBE = new CRUTAEMBARQUEBE();
                rutaEmbarqueBE.IID = m_Docto.IRUTAEMBARQUEID > 0 ? m_Docto.IRUTAEMBARQUEID : m_rutaEmbarqueAAsignar;
                rutaEmbarqueBE = rutaEmbarqueD.seleccionarRUTAEMBARQUE(rutaEmbarqueBE, null);
                if (rutaEmbarqueBE != null)
                {
                    lblRutaEmbarque.Text = rutaEmbarqueBE.INOMBRE;
                    m_rutaEmbarqueId = m_Docto.IRUTAEMBARQUEID;
                }
            }
        }


        private void BTAbrirCerradasYDevo_Click(object sender, EventArgs e)
        {
            AbrirVentasCerradasYDevoluciones(0, "");
        }




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
                this.BTCliente.Text = "SUC_DEST:";
                this.BTCliente.Enabled = false;
                this.TBCliente.Enabled = false;
                m_ClienteId = DBValues._CLIENTEMOSTRADOR;
                PonerHabilitacionPagoTarjeta();

                TBCliente.Text = dr[6].ToString();
                retorno = true;
            }
            

            return retorno;
        }


        private void ModoTraslado()
        {

            CUSUARIOSD usuariosD = new CUSUARIOSD();
            if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_AGREGAR_TRASLADOS, null))
            {
                if (CurrentUserID.CurrentParameters.IHABTRASLADOPORAUTORIZACION != null && CurrentUserID.CurrentParameters.IHABTRASLADOPORAUTORIZACION.Equals("S"))
                {
                    WFPreguntaAutorizacion ps2 = new WFPreguntaAutorizacion(false);
                    ps2.ShowDialog();
                    CPERSONABE userBE = ps2.m_userBE;
                    CPERSONABE supervisorBE = ps2.m_supervisorBE;
                    bool bPassValido = ps2.m_bPassValido;
                    bool bIsSupervisor = ps2.m_bIsSupervisor;
                    bool bIsAdministrador = ps2.m_bIsAdministrador;
                    ps2.Dispose();
                    GC.SuppressFinalize(ps2);

                    if (!bPassValido)
                        return;


                    if (!usuariosD.UsuarioTienePermisos((int)userBE.IID, DBTN.DERECHO_AGREGAR_TRASLADOS, null))
                    {
                        MessageBox.Show("No tiene permisos para hacer traslados");
                        return;
                    }
                }


            }

            NuevoRegistro();
            if (!SeleccionarSucursalTID(CurrentUserID.CurrentParameters.ISUCURSALID))
                return;

            m_Docto.ITIPODOCTOID = DBValues._DOCTO_TIPO_TRASPASO_ENVIO;
            this.BTPasarANueva.Enabled = true;
            this.BTPasarANueva.ForeColor = Color.Black;
            this.BTPasarANueva.BackColor = Color.FromArgb(41, 121, 255);

            this.btnNuevaApartado.Enabled = false;
            this.BTPagarConVale.Enabled = false;

            this.CBCotizacionEnrutada.Visible = false;
        }

        private void BTTraspaso_Click(object sender, EventArgs e)
        {
            ModoTraslado();
        }

        private void TimerImageSWF_Tick(object sender, EventArgs e)
        {
            //GetSwfMovieSource();
        }


        public bool ActualizarFechaSistema()
        {

            CPARAMETROD parametroD = new CPARAMETROD();
            CPARAMETROBE parametroBE = new CPARAMETROBE();
            parametroBE = parametroD.seleccionarPARAMETROActual(null);
            parametroBE.IFECHAULTIMA = DateTime.Today;
            if (!parametroD.CambiarPARAMETROD(parametroBE, parametroBE, null))
            {
                return false;
            }
            CurrentUserID.CurrentParameters.IFECHAULTIMA = DateTime.Today;
            return true;
        }


        public bool ChecarFechaDelSistema()
        {

            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            if (!pvd.ValidarFechaSistema(null))
            {
                if(m_bPermisoActualizarFechaAutomaticamente)
                {
                    if(ActualizarFechaSistema())
                        return true;
                }


                MessageBox.Show(pvd.IComentario);
                m_bSalirSinPreguntar = true;
                this.Close();
                return false;
            }
            return true;
        }


        private decimal calculaPrecioSinImpuestos(decimal precioConImpuestos, CPRODUCTOBE prod)
        {

            decimal dTasaIva = prod.IESKIT != null && prod.IESKIT.Equals("S") && prod.ITASAIVAEXT > 0.0m ? prod.ITASAIVAEXT : prod.ITASAIVA;
            decimal dTasaIeps = prod.IESKIT != null && prod.IESKIT.Equals("S") && prod.ITASAIEPSEXT > 0.0m ? prod.ITASAIEPSEXT : prod.ITASAIEPS;
            decimal dPrecioSinImpuestos = (precioConImpuestos / (1 + (dTasaIva / 100))) / (1 + (dTasaIeps / 100));
            return Math.Round(dPrecioSinImpuestos, 2);


        }
        private decimal calculaPrecioConImpuestos(decimal precioSinImpuestos, CPRODUCTOBE prod)
        {
            decimal dTasaIva = prod.IESKIT != null && prod.IESKIT.Equals("S") && prod.ITASAIVAEXT > 0.0m ? prod.ITASAIVAEXT : prod.ITASAIVA;
            decimal dTasaIeps = prod.IESKIT != null && prod.IESKIT.Equals("S") && prod.ITASAIEPSEXT > 0.0m ? prod.ITASAIEPSEXT : prod.ITASAIEPS;
            decimal precioConImpuesto = (precioSinImpuestos * (1 + (dTasaIeps / 100))) * (1 + (dTasaIva / 100));
            return Math.Round(precioConImpuesto, 2);


        }

        private void TBCommandLine_Validated(object sender, EventArgs e)
        {
            TBDescuento.Text = "";
            TBPrecioCaja.Text = "";

            PonerPrecioEnPantalla();

        }

        private void reFormatearPiezasCajasPorUnidad(CPRODUCTOBE prod, bool esEmpaque, bool esCaja)
        {



            if (/*(prod.IUNIDAD != null && prod.IUNIDAD.Trim().ToUpper().Equals("KG"))*/
                bProductoSoloManejaKG(prod) || esEmpaque || esCaja)
            {
                if (bEstaConfiguradoParaPiezasyCajas())
                {
                    if (TBCajas.Focused)
                    {
                        TBCantidad.Focus();
                    }

                    formatCajasBotellasPiezas(false);
                    TBCantidad.Text = "0";
                    TBCantidad.SelectAllText();
                }

            }
            else
            {
                if (bEstaConfiguradoParaPiezasyCajas())
                {
                    formatCajasBotellasPiezas(true);
                }

            }



            short numeroDecimales = 2;
            if (prod != null)
            {
                numeroDecimales = CUNIDADD.numerDecimalesPorClaveUnidad(prod.IUNIDAD);
            }
            TBCantidad.NumericScaleOnFocus = numeroDecimales;
            TBCantidad.NumericScaleOnLostFocus = numeroDecimales;

            //if (bProductoManejaKG(prod))
            //{
            //    TBCantidad.NumericScaleOnFocus = 3;
            //    TBCantidad.NumericScaleOnLostFocus = 3;
            //}
            //else
            //{

            //    TBCantidad.NumericScaleOnFocus = 2;
            //    TBCantidad.NumericScaleOnLostFocus = 2;
            //}

        }


        private string formateaDescuento(decimal descuento)
        {
            if (!m_bPermisoCambiarPrecioxDescuento && descuento < 0)
                descuento = 0;

            return descuento.ToString("N2");
        }

        private string formateaDescuento(string strDescuento)
        {
            try
            {
                return formateaDescuento(decimal.Parse(strDescuento));
            }
            catch
            {
                return formateaDescuento(0M);
            }
        }

        private void PonerPrecioEnPantalla()
        {

            if (!this.m_bPermisoCambiarPrecioxLista && !this.m_bPermisoCambiarPrecio)
            {
                return;
            }


            CPRODUCTOBE prod = null;
            decimal cantidad = 0;

            bool bPreguntaCantidad = false;


            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            if (TBCommandLine.Text == "")
            {
                return;
            }

            bool esEmpaque = false;
            bool esCaja = false;
            DecifrarComando(TBCommandLine.Text, ref prod, ref cantidad, ref bPreguntaCantidad, ref pvd, ref esEmpaque, ref esCaja);

            if (prod != null)
            {

                int? productoId = (int?)prod.IID;
                int? clienteId = (int?)this.m_ClienteId;
                int? personaId = (int?)CurrentUserID.CurrentUser.IID;
                int? tipoDoctoId = (int?)m_Docto.ITIPODOCTOID;
                int? sucursalId = (int?)CurrentUserID.CurrentParameters.ISUCURSALID;
                int? sucursalTId = null;



                decimal? precioLista = null;
                decimal? precioTraspaso = null;
                decimal? precioMinimo = null;
                decimal? costo = null;

                decimal pzaCaja = prod.IPZACAJA == 0 ? 1 : prod.IPZACAJA;

                decimal tipoCambio = (((bool)m_Docto.isnull["ITIPOCAMBIO"] || m_Docto.ITIPOCAMBIO == 0) ? 1 : m_Docto.ITIPOCAMBIO);

                if (cantidad == 0)
                    cantidad = 1;


                reFormatearPiezasCajasPorUnidad(prod, esEmpaque, esCaja);


                if (pvd.GET_PRECIOS_PRODUCTO_LISTA(productoId, clienteId, cantidad, sucursalTId, ref precioLista, ref precioTraspaso, ref precioMinimo, ref costo, null))
                {
                    if (precioLista.HasValue)
                    {

                        decimal dPrecioBaseSinImpuestos = prod.IPRECIO1;
                        if ((bool)CurrentUserID.CurrentParameters.isnull["ITIPODESCUENTOPRODID"] || CurrentUserID.CurrentParameters.ITIPODESCUENTOPRODID == 2)
                            dPrecioBaseSinImpuestos = precioLista.Value;

                        if ((bool)CurrentUserID.CurrentParameters.isnull["IPRECIONETOENPV"] || !CurrentUserID.CurrentParameters.IPRECIONETOENPV.Equals("S"))
                        {




                            this.TBPrecio.Text = (precioLista / tipoCambio).ToString();

                            try
                            {
                                this.TBPrecioCaja.Text = ((decimal)precioLista * pzaCaja / tipoCambio).ToString("N2");
                                this.TBDescuento.Text = formateaDescuento(100.00m - ((100.00m * (decimal)precioLista) / dPrecioBaseSinImpuestos));
                            }
                            catch
                            {

                            }
                        }
                        else
                        {


                            decimal dNuevoPrecio = calculaPrecioConImpuestos(precioLista.Value, prod);
                            decimal dPrecioBase = calculaPrecioConImpuestos(dPrecioBaseSinImpuestos, prod);
                            this.TBPrecio.Text = (dNuevoPrecio / tipoCambio).ToString();

                            try
                            {
                                this.TBPrecioCaja.Text = (dNuevoPrecio * pzaCaja / tipoCambio).ToString("N2");
                                this.TBDescuento.Text = formateaDescuento(100 - ((100 * dNuevoPrecio) / dPrecioBase));
                            }
                            catch
                            {

                            }
                        }



                    }
                    else
                    {
                        this.TBPrecio.Text = "";
                    }


                    ListaPrecios.Items.Clear();



                    if (!(bool)prod.isnull["IPRECIO1"] && CurrentUserID.CurrentUser.ILISTAPRECIOID >= 1)
                    {
                        ListaPrecios.Items.Add("Precio 1:" + calculaPrecioConImpuestos((prod.IPRECIO1 / tipoCambio), prod).ToString("N2"));
                    }
                    if (!(bool)prod.isnull["IPRECIO2"] && CurrentUserID.CurrentUser.ILISTAPRECIOID >= 2)
                    {
                        ListaPrecios.Items.Add("Precio 2:" + calculaPrecioConImpuestos((prod.IPRECIO2 / tipoCambio), prod).ToString("N2"));
                    }
                    if (!(bool)prod.isnull["IPRECIO3"] && CurrentUserID.CurrentUser.ILISTAPRECIOID >= 3)
                    {
                        ListaPrecios.Items.Add("Precio 3:" + calculaPrecioConImpuestos((prod.IPRECIO3 / tipoCambio), prod).ToString("N2"));
                    }
                    if (!(bool)prod.isnull["IPRECIO4"] && CurrentUserID.CurrentUser.ILISTAPRECIOID >= 4)
                    {
                        ListaPrecios.Items.Add("Precio 4:" + calculaPrecioConImpuestos((prod.IPRECIO4 / tipoCambio), prod).ToString("N2"));
                    }
                    if (!(bool)prod.isnull["IPRECIO5"] && CurrentUserID.CurrentUser.ILISTAPRECIOID >= 5)
                    {
                        ListaPrecios.Items.Add("Precio 5:" + calculaPrecioConImpuestos((prod.IPRECIO5 / tipoCambio), prod).ToString("N2"));
                    }

                }
                else
                {

                }

                TBStatus.Text = prod.INOMBRE + " // " + prod.IDESCRIPCION + " // " + prod.IDESCRIPCION1 + " // " + prod.IEXISTENCIA;

                if (bProductoSoloManejaKG(prod) /*prod.IUNIDAD != null && prod.IUNIDAD.Equals("KG")*/ /*&& !bEstaConfiguradoParaPiezasyCajas()*/)
                {
                    TBCantidad.Text = "0";
                }
            }
        }



        private void TBPrecio_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {


        }


        private void TBPrecio_KeyDown(object sender, KeyEventArgs e)
        {
            if (m_estadoVenta == (int)estadoVenta.e_Cerrada || m_estadoVenta == (int)estadoVenta.e_Cancelada)
                return;

            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {

                ProcessCommand(false, false, true);
                TBCommandLine.Focus();

            }//&& TBPrecio.ReadOnly == false
            else if (e.KeyCode == System.Windows.Forms.Keys.Down && m_bPermisoCambiarPrecioxLista)
            {
                this.ListaPrecios.Height = 100;
                this.ListaPrecios.Visible = true;
                this.ListaPrecios.Focus();
            }
            if (Control.ModifierKeys == Keys.Control)
            {
                if (e.KeyCode == Keys.S)
                {
                    ProcessCommand(false, false);
                    TBCommandLine.Focus();
                }
            }
        }

        private void TBPrecio_Validated(object sender, EventArgs e)
        {
            if (m_focusInCommandLine)
            {
                //if (m_keyboardSize == 0)
                this.TBCommandLine.Focus();
                /*else
                    this.gridPVDataGridView.Focus();*/
                m_focusInCommandLine = false;
            }
        }

        private void listBox1_Leave(object sender, EventArgs e)
        {
            ListaPrecios.Visible = false;
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {

                ListaPrecios.Visible = false;

                char[] cSeparator = new char[] { ':' };

                string stValue = ListaPrecios.Items[ListaPrecios.SelectedIndex].ToString();
                string[] stValueSplitted = stValue.Split(cSeparator);
                if (stValueSplitted.Length >= 2)
                {
                    this.TBPrecio.Text = stValueSplitted[1];
                }
                this.TBPrecio.Focus();
            }
        }

        private void gridPVDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if ((gridPVDataGridView.Columns["GVCANTIDAD"].Index != e.ColumnIndex && gridPVDataGridView.Columns["PRECIOUNIDAD"].Index != e.ColumnIndex && gridPVDataGridView.Columns["DESCUENTOPORCENTAJE"].Index != e.ColumnIndex)
                || (m_estadoVenta == (int)estadoVenta.e_Cancelada || m_estadoVenta == (int)estadoVenta.e_Cerrada))
                return;

            if (gridPVDataGridView.Columns["GVCANTIDAD"].Index == e.ColumnIndex)
            {
                try
                {
                    decimal dNuevaCantidad = decimal.Parse(e.FormattedValue.ToString());
                    decimal dViejaCantidad = decimal.Parse(gridPVDataGridView.Rows[e.RowIndex].Cells["GVCANTIDAD"].Value.ToString());
                    decimal dEntrada = dNuevaCantidad - dViejaCantidad;

                    string unidad = gridPVDataGridView.Rows[e.RowIndex].Cells["DGUNIDAD"].Value.ToString();
                    
                    short numeroDecimales = 2;
                    if (unidad != null)
                    {
                        numeroDecimales = CUNIDADD.numerDecimalesPorClaveUnidad(unidad);
                    }
                    
                    if (dEntrada == 0)
                        return;
                    if (/*dNuevaCantidad <= 0*/ Math.Round(dNuevaCantidad, numeroDecimales) <= 0)
                    {
                        MessageBox.Show("La cantidad  no puede ser menor o igual a cero, si requiere cancelar el detalle porfavor seleccione 'Eliminar detalle'");
                        e.Cancel = true;
                    }
                    else
                    {

                        CPRODUCTOBE prodBE = new CPRODUCTOBE();
                        CPRODUCTOD prodD = new CPRODUCTOD();
                        prodBE.IID = long.Parse(gridPVDataGridView.Rows[e.RowIndex].Cells["DGPRODUCTOID"].Value.ToString());
                        prodBE = prodD.seleccionarPRODUCTO(prodBE, null);

                        decimal dNuevoPrecio = decimal.Parse(gridPVDataGridView.Rows[e.RowIndex].Cells["PRECIOUNIDAD"].Value.ToString());
                        /*decimal dTasaIva = 0;
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
                        }*/


                        decimal dPrecioSinIva;

                        if ((bool)CurrentUserID.CurrentParameters.isnull["IPRECIONETOENPV"] || !CurrentUserID.CurrentParameters.IPRECIONETOENPV.Equals("S"))
                            dPrecioSinIva = calculaPrecioSinImpuestos(dNuevoPrecio, prodBE);//(dNuevoPrecio / (1 + (dTasaIva / 100))) / (1 + (dTasaIeps / 100));
                        else
                            dPrecioSinIva = dNuevoPrecio;

                        decimal dDescuentoManual = 0;
                        try
                        {
                            dDescuentoManual = decimal.Parse(gridPVDataGridView.Rows[e.RowIndex].Cells["PORCENTAJEDESCUENTOMANUAL"].Value.ToString());
                        }
                        catch
                        {
                            dDescuentoManual = 0;
                        }

                        bool bHaIngresadoPrecioManual = true;
                        try
                        {
                            string strHaIngresadoPrecioManual = gridPVDataGridView.Rows[e.RowIndex].Cells["DGINGRESOPRECIOMANUAL"].Value.ToString();
                            bHaIngresadoPrecioManual = strHaIngresadoPrecioManual != null && strHaIngresadoPrecioManual.Trim().ToUpper().Equals("S");

                        }
                        catch
                        {
                            bHaIngresadoPrecioManual = true;
                        }



                        if (bEstaConfiguradoParaPiezasyCajas())
                        {
                            TBCommandLine.Text = gridPVDataGridView.Rows[e.RowIndex].Cells["GVCLAVEPRODUCTO"].Value.ToString();
                            TBCajas.Text = "0";
                            TBCantidad.Text = dEntrada.ToString("N3");
                        }
                        else
                        {
                            TBCommandLine.Text = dEntrada.ToString("N3") + "*" + gridPVDataGridView.Rows[e.RowIndex].Cells["GVCLAVEPRODUCTO"].Value.ToString();
                        }

                        TBPrecio.Text = dPrecioSinIva.ToString("0.00");
                        TBDescuento.Text = formateaDescuento(gridPVDataGridView.Rows[e.RowIndex].Cells["DESCUENTOPORCENTAJE"].Value.ToString());


                        long? P_MOVTOID = (long)gridPVDataGridView.Rows[e.RowIndex].Cells["MOVTOID"].Value;

                        bool bRes = false;

                        if (!bHaIngresadoPrecioManual)
                            bRes = ProcessCommand(true, false, P_MOVTOID, (dDescuentoManual == 0), true, true);
                        else
                            bRes = dDescuentoManual == 0 ? ProcessCommand(false, false, P_MOVTOID, true, true, true) : ProcessCommand(true, false, P_MOVTOID, false, true, true);



                        if (!bRes)
                        {
                            //gridPVDataGridView.Rows[e.RowIndex].Cells["GVCANTIDAD"].Value = dViejaCantidad;
                            //gridPVDataGridView.EditingControl.Text = Convert.ToString(dViejaCantidad);
                            e.Cancel = true;
                            TBCommandLine.Text = "";
                            TBPrecio.Text = "";
                            TBDescuento.Text = "";
                            this.TBPrecioCaja.Text = "";

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
            }
            else if (gridPVDataGridView.Columns["PRECIOUNIDAD"].Index == e.ColumnIndex)
            {
                if (!m_bPermisoCambiarPrecio)
                    return;

                try
                {


                    CPRODUCTOBE prodBE = new CPRODUCTOBE();
                    CPRODUCTOD prodD = new CPRODUCTOD();
                    prodBE.IID = long.Parse(gridPVDataGridView.Rows[e.RowIndex].Cells["DGPRODUCTOID"].Value.ToString());
                    prodBE = prodD.seleccionarPRODUCTO(prodBE, null);

                    decimal dNuevoPrecio = decimal.Parse(e.FormattedValue.ToString());
                    decimal dViejoPrecio = decimal.Parse(gridPVDataGridView.Rows[e.RowIndex].Cells["PRECIOUNIDAD"].Value.ToString());


                    if (dNuevoPrecio == dViejoPrecio)
                        return;

                    /*decimal dTasaIva = 0;
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
                    }*/

                    decimal dPrecioSinIva;

                    bool precioNetoEnPV = !((bool)CurrentUserID.CurrentParameters.isnull["IPRECIONETOENPV"] || !CurrentUserID.CurrentParameters.IPRECIONETOENPV.Equals("S"));
                    bool precioNetoEnGrids = !((bool)CurrentUserID.CurrentParameters.isnull["IPRECIONETOENGRIDS"] || !CurrentUserID.CurrentParameters.IPRECIONETOENGRIDS.Equals("S"));


                    //if ((bool)CurrentUserID.CurrentParameters.isnull["IPRECIONETOENPV"] || !CurrentUserID.CurrentParameters.IPRECIONETOENPV.Equals("S"))
                    if (!precioNetoEnPV && precioNetoEnGrids)
                        dPrecioSinIva = calculaPrecioSinImpuestos(dNuevoPrecio, prodBE);//(dNuevoPrecio / (1 + (dTasaIva / 100))) / (1 + (dTasaIeps / 100));
                    else if (precioNetoEnPV && !precioNetoEnGrids)
                        dPrecioSinIva = calculaPrecioConImpuestos(dNuevoPrecio, prodBE);
                    else
                        dPrecioSinIva = dNuevoPrecio;




                    if (dNuevoPrecio < 0)
                    {

                        MessageBox.Show("El precio no puede ser menor que cero");
                        e.Cancel = true;
                    }
                    else
                    {
                        TBCommandLine.Text = "0" + "*" + gridPVDataGridView.Rows[e.RowIndex].Cells["GVCLAVEPRODUCTO"].Value.ToString();
                        TBPrecio.Text = dPrecioSinIva.ToString("0.00");
                        TBDescuento.Text = formateaDescuento(gridPVDataGridView.Rows[e.RowIndex].Cells["DESCUENTOPORCENTAJE"].Value.ToString());

                        long? P_MOVTOID = (long)gridPVDataGridView.Rows[e.RowIndex].Cells["MOVTOID"].Value;
                        if (!ProcessCommand(false, false, P_MOVTOID, true,false, true))
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

                    CPRODUCTOBE prodBE = new CPRODUCTOBE();
                    CPRODUCTOD prodD = new CPRODUCTOD();
                    prodBE.IID = long.Parse(gridPVDataGridView.Rows[e.RowIndex].Cells["DGPRODUCTOID"].Value.ToString());
                    prodBE = prodD.seleccionarPRODUCTO(prodBE, null);

                    decimal dNuevoPrecio = decimal.Parse(gridPVDataGridView.Rows[e.RowIndex].Cells["PRECIOUNIDAD"].Value.ToString());
                    decimal dNuevoDescuento = decimal.Parse(e.FormattedValue.ToString());
                    decimal dViejoDescuento = decimal.Parse(gridPVDataGridView.Rows[e.RowIndex].Cells["DESCUENTOPORCENTAJE"].Value.ToString());


                    if (dNuevoDescuento == dViejoDescuento)
                        return;

                    /*decimal dTasaIva = 0;
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
                    }*/

                    decimal dPrecioSinIva;
                    if ((bool)CurrentUserID.CurrentParameters.isnull["IPRECIONETOENPV"] || !CurrentUserID.CurrentParameters.IPRECIONETOENPV.Equals("S"))
                        dPrecioSinIva = calculaPrecioSinImpuestos(dNuevoPrecio, prodBE);//(dNuevoPrecio / (1 + (dTasaIva / 100))) / (1 + (dTasaIeps / 100));
                    else
                        dPrecioSinIva = dNuevoPrecio;

                    if (dNuevoPrecio < 0)
                    {

                        MessageBox.Show("El precio no puede ser menor que cero");
                        e.Cancel = true;
                    }
                    else
                    {
                        TBCommandLine.Text = "0" + "*" + gridPVDataGridView.Rows[e.RowIndex].Cells["GVCLAVEPRODUCTO"].Value.ToString();
                        TBPrecio.Text = dPrecioSinIva.ToString("0.00");
                        TBDescuento.Text = formateaDescuento(dNuevoDescuento);//gridPVDataGridView.Rows[e.RowIndex].Cells["TITULOSTOTALES"].Value.ToString();

                        long? P_MOVTOID = (long)gridPVDataGridView.Rows[e.RowIndex].Cells["MOVTOID"].Value;
                        if (!ProcessCommand(true, false, P_MOVTOID, false, false, true))
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


        private void TBDescuento_KeyDown(object sender, KeyEventArgs e)
        {

            if (m_estadoVenta == (int)estadoVenta.e_Cerrada || m_estadoVenta == (int)estadoVenta.e_Cancelada)
                return;

            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                ProcessCommand(true, false, false);
                TBCommandLine.Focus();
            }
            else if (e.KeyCode == System.Windows.Forms.Keys.Space)
            {
                PonerPrecioPorDescuento();
            }
        }

        private void TBDescuento_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }
        private void TBDescuento_Validated(object sender, EventArgs e)
        {

            if (m_focusInCommandLine)
            {
                this.TBCommandLine.Focus();
                m_focusInCommandLine = false;
            }
        }


        private void ProcesaCambioCliente(DataRow dr)
        {


            try
            {
                btDomicilioEntrega.Enabled = false;

                //resetea need to update autorization comment
                m_bActualizarComentarioAutorizacionCredito = false;
                m_strComentarioAutorizacionCredito = "";
                m_lAutorizadorCredito = 0;



                if (dr["SERVICIOADOMICILIO"] != DBNull.Value && dr["SERVICIOADOMICILIO"].ToString().Trim().Equals("S"))
                {
                    btDomicilioEntrega.Enabled = true;
                }
            }
            catch
            {

            }


            try
            {

                //validar credito
                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTAMOVIL)
                {


                    try
                    {
                        if (dr["REFERENCIAMOVIL"] != DBNull.Value && dr["REFERENCIAMOVIL"].ToString().Trim() != "")
                        {
                            MessageBox.Show("Datos adicionales del cliente : " + dr["REFERENCIAMOVIL"].ToString().Trim());
                        }
                    }
                    catch
                    {
                    }

                    try
                    {
                        if (dr["BLOQUEADO"].ToString().Trim().Equals("S") && (long)dr["ID"] > 1)
                        {
                            if (dr["BLOQUEONOT"] != DBNull.Value && dr["REFERENCIAMOVIL"].ToString().Trim() != "")
                            {
                                MessageBox.Show(dr["BLOQUEONOT"].ToString().Trim());
                            }
                            else
                            {
                                MessageBox.Show("Observación : el cliente aparece bloqueado");
                            }
                        }
                    }
                    catch
                    {
                    }




                    try
                    {
                        if (dr["LIMITECREDITO"] != DBNull.Value)
                        {
                            decimal dLimiteCredito = (decimal)dr["LIMITECREDITO"];
                            if (dLimiteCredito == 0)
                            {
                                iPos.Movil.WFBigMessageBox bm = new Movil.WFBigMessageBox();
                                bm.ShowDialog();
                                bm.Dispose();
                                GC.SuppressFinalize(bm);
                            }

                        }
                        else
                        {

                            iPos.Movil.WFBigMessageBox bm = new Movil.WFBigMessageBox();
                            bm.ShowDialog();
                            bm.Dispose();
                            GC.SuppressFinalize(bm);
                        }
                    }
                    catch
                    {
                    }

                    /*if (dr != null)
                    {
                        btnCobranzaMovil.Visible = true;
                    }*/


                }
                //checar si esta asignado una venta a un cliente de sucursal y si es permitido
                else if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA &&
                    (CurrentUserID.CurrentParameters.IHABVENTACLISUC != null && CurrentUserID.CurrentParameters.IHABVENTACLISUC.Equals("N")))
                {
                    CCLIENTED clienteD = new CCLIENTED();
                    string claveCliente = dr["CLAVE"].ToString().Trim();
                    if (clienteD.esClienteAsignadoASuc(claveCliente, null))
                    {

                        MessageBox.Show("El cliente esta asignado a una sucursal y el sistema no deja asignarlo directamente a una venta, haga un traslado a la sucursal correspondiente");
                        return;
                    }
                }
                else
                {

                    try
                    {



                        if (dr["STATUSSALDO"].ToString().Trim().Equals("BLOQUEADO") && (long)dr["ID"] > 1 && !CBCotizacionEnrutada.Checked )
                        {
                            MessageBox.Show("No puede seleccionar un cliente que este bloqueado");
                            return;
                        }
                        else if (dr["STATUSSALDO"].ToString().Trim().Equals("EXCEDIDO") && (long)dr["ID"] > 1)
                        {
                            long autorizadorId = CurrentUserID.CurrentUser.IID;
                            CUSUARIOSD usuariosD = new CUSUARIOSD();
                            if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_VENDERCONCREDITOEXCEDIDO, null))
                            {
                                if (MessageBox.Show("No tiene derecho para vender a un cliente con credito excedido. Quiere ingresar autorizacion de un supervisor?", "Credido excedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    WFPreguntaAutorizacion ps2 = new WFPreguntaAutorizacion();
                                    ps2.m_requiereAdminOrSupervisor = false;
                                    ps2.ShowDialog();
                                    CPERSONABE userBE = ps2.m_userBE;
                                    CPERSONABE supervisorBE = ps2.m_supervisorBE;
                                    bool bPassValido = ps2.m_bPassValido;
                                    bool bIsSupervisor = ps2.m_bIsSupervisor;
                                    bool bIsAdministrador = ps2.m_bIsAdministrador;
                                    ps2.Dispose();
                                    GC.SuppressFinalize(ps2);

                                    if (!bPassValido)
                                        return;

                                    //if (!bIsSupervisor)
                                    if (!usuariosD.UsuarioTienePermisos((int)userBE.IID, (int)DBValues._DERECHO_VENDERCONCREDITOEXCEDIDO, null))
                                    {
                                        MessageBox.Show("El usuario no tiene el derecho");
                                        return;
                                    }



                                    m_supervisor = userBE;
                                    if (m_Docto != null && (!(bool)m_Docto.isnull["IID"]))
                                    {

                                        CDOCTOD doctoD = new CDOCTOD();
                                        m_Docto.ISUPERVISORID = m_supervisor.IID;
                                        doctoD.CambiarSupervisorAutorizacionDOCTOD(m_Docto, null);

                                        autorizadorId = m_supervisor.IID;
                                    }
                                    else
                                    {
                                        m_asignarsupervisor = true;
                                    }


                                }
                                else
                                {
                                    return;
                                }
                            }
                            
                            long doctoToAutorize = (m_Docto != null && (!(bool)m_Docto.isnull["IID"])) ? m_Docto.IID : 0;
                            if (!PreguntaComentarioAutorizacion(doctoToAutorize, autorizadorId, null))
                            {
                                    MessageBox.Show("Debe agregar un comentario de autorizacion");
                                    return;
                            }

                        }
                    }
                    catch
                    {
                        return;
                    }

                }


            }
            catch { }


            try
            {
                if (dr != null)
            {
                this.TBCliente.Text = dr["CLAVE"].ToString().Trim();
                m_ClienteId = (long)dr["ID"];

                this.btnCobranzaMovil.Visible = (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTAMOVIL && m_ClienteId != DBValues._CLIENTEMOSTRADOR && m_ClienteId != 0);

                llenarDatosCliente();
                PonerHabilitacionPagoTarjeta();

                if (m_Docto != null)
                {
                    if (!(bool)m_Docto.isnull["IID"])
                    {
                        CPuntoDeVentaD pvd = new CPuntoDeVentaD();
                        m_Docto.IPERSONAID = this.m_ClienteId;
                        if (!pvd.ActualizarClienteDOCTO(m_Docto, null))
                            MessageBox.Show(pvd.IComentario);
                        else
                        {
                            RefrescarGridVentas();
                            RefrescarEstatusBotones();

                        }
                    }
                }



                checarVisita();


                preAsignarOrdenCompraSiAplica();
                preAsignarRutaEmbarqueSiAplica();
                asignarOrdenCompraSiAplica();
                asignarRutaEmbarqueSiAplica(true, false, true);

                TBCommandLine.Focus();
            }


            }
            catch { }

        }


        private void ProcesarCambioAutorizacion()
        {

            //autorizador credito
            if(m_bActualizarComentarioAutorizacionCredito && m_strComentarioAutorizacionCredito != null && m_strComentarioAutorizacionCredito.Trim().Length > 0)
            {

                CDOCTOD doctoD = new CDOCTOD();
                doctoD.CambiarDOCTONOTASET(m_Docto.IID, DBValues._TIPODOCTONOTA_AUTORIZACION, DateTime.Now, m_lAutorizadorCredito, m_strComentarioAutorizacionCredito, null);

                m_bActualizarComentarioAutorizacionCredito = false;
                m_strComentarioAutorizacionCredito = "";
                m_lAutorizadorCredito = 0;
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


        private bool PreguntaComentarioAutorizacion(long doctoId, long usuarioId, FbTransaction ftrans)
        {
            string comentarioAut = "";
            WFPreguntaComentario wf1_ = new WFPreguntaComentario();
            wf1_.ShowDialog();
            comentarioAut = wf1_.m_comentario.Trim();
            wf1_.Dispose();
            GC.SuppressFinalize(wf1_);

            if (comentarioAut != null && comentarioAut.Trim().Length > 0)
            {
                m_bActualizarComentarioAutorizacionCredito = true;
                m_strComentarioAutorizacionCredito = comentarioAut;
                m_lAutorizadorCredito = usuarioId;

                if(doctoId > 0)
                {
                    ProcesarCambioAutorizacion();
                }

                //CDOCTOD doctoD = new CDOCTOD();
                //doctoD.CambiarDOCTONOTASET(doctoId, DBValues._TIPODOCTONOTA_AUTORIZACION, DateTime.Now, usuarioId, comentarioAut, null);

                return true;
            }

            return false;

        }

        private void SeleccionaCliente()
        {
            iPos.Catalogos.WFClientes look = new iPos.Catalogos.WFClientes();
            look.m_bSelecionarRegistro = true;
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            ProcesaCambioCliente(dr);

            //asignarRutaEmbarqueSiAplica(false, false, false);
        }

        private void BTCliente_Click(object sender, EventArgs e)
        {
            SeleccionaCliente();
        }


        private void EnviarCotizacionPorEmail()
        {

            string strEmail = "";

            CPERSONABE personaBE = new CPERSONABE();
            CPERSONAD personaD = new CPERSONAD();
            personaBE.IID = m_ClienteId;
            personaBE = personaD.seleccionarPERSONA(personaBE, null);

            if (personaBE == null)
            {
                MessageBox.Show("No se pudo obtener el cliente");
                return;
            }

            strEmail = personaBE.IEMAIL1;

            if (m_Docto.IPERSONAID == 1 && m_Docto.IPERSONAAPARTADOID != 0)
            {

                CPERSONAAPARTADOBE personaAPARTADOBE = new CPERSONAAPARTADOBE();
                CPERSONAAPARTADOD personaAPARTADOD = new CPERSONAAPARTADOD();
                personaAPARTADOBE.IID = m_Docto.IPERSONAAPARTADOID;
                personaAPARTADOBE = personaAPARTADOD.seleccionarPERSONAAPARTADO(personaAPARTADOBE, null);
                if (personaAPARTADOBE != null)
                {
                    strEmail = personaAPARTADOBE.IEMAIL1;
                }

            }


            WFPreguntaCorreo wf = new WFPreguntaCorreo(strEmail);
            wf.ShowDialog();

            if (wf.boolEnviar && wf.strCorreo != null && wf.strCorreo.Contains("@"))
            {

                CUSUARIOSD usuariosD = new CUSUARIOSD();
                Boolean usuarioTienePermisoDesgloseKit = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null);

                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("pdoctoid", m_Docto.IID);
                dictionary.Add("usaDatosDeEntregaCuandoExista", "N");
                dictionary.Add("desglosekits", usuarioTienePermisoDesgloseKit ? "S" : "N");
                dictionary.Add("creadoPorUserId", 0);
                string strReporte = "recibolargo.frx";
                string stSubject = "Cotización";


                iPos.Login_and_Maintenance.WFReportSending rp = new Login_and_Maintenance.WFReportSending(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.deusuario), wf.strCorreo, dictionary, stSubject, "PDF");
                rp.ShowDialog();
                rp.Dispose();
                GC.SuppressFinalize(rp);
            }

            wf.Dispose();
            GC.SuppressFinalize(wf);


        }

        
        private bool HayRebajaTope()
        {
            if(dSPuntoDeVentaAux2.GRIDPV.Rows.Count > 0)
            {
               foreach( DSPuntoDeVentaAux2.GRIDPVRow row in dSPuntoDeVentaAux2.GRIDPV.Rows)
                {
                    if (row.REBAJACOLOR != null && row.REBAJACOLOR.Equals("AMARILLO"))
                        return true;
                }
            }
            return false;
        }


        private void BTCotizacion_Click(object sender, EventArgs e)
        {
            Boolean bReimpresionesConMarca = CurrentUserID.CurrentParameters.IREIMPRESIONESCONMARCA != null && CurrentUserID.CurrentParameters.IREIMPRESIONESCONMARCA.Equals("S");

            if (m_Docto != null)
            {
                if (!(bool)m_Docto.isnull["IID"])
                {
                    bool conTopes = false;
                    if( CurrentUserID.CurrentParameters.IVERSIONTOPEID == 2  && m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_BORRADOR)
                    {
                        if (HayRebajaTope())
                        {
                            if (!m_bPermisoImprimirCotizacionSinTope)
                                conTopes = true;
                            else
                            {

                                WFTipoCotizacionTope wf = new WFTipoCotizacionTope();
                                wf.ShowDialog();
                                conTopes = wf.m_conTopes;
                                wf.Dispose();
                                GC.SuppressFinalize(wf);

                            }
                        }
                        
                    }

                    long doctoId = m_Docto.IID;

                    //en el caso de traslado , imprimir la venta si existe y es la opcion preferida en parametros
                    if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO && m_Docto.IDOCTOREFID != 0 && CurrentUserID.CurrentParameters.IIMPRFORMAVENTATRASL != null &&
                        CurrentUserID.CurrentParameters.IIMPRFORMAVENTATRASL.Equals("S"))
                    {
                        doctoId = m_Docto.IDOCTOREFID;
                    }

                    if(CurrentUserID.CurrentParameters.IHABSURTIDOPREVIO == "S" && m_Docto.IESTADOSURTIDOID == DBValues._DOCTO_SURTIDOESTADO_PENDIENTE &&
                        m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA && m_Docto.IESTATUSDOCTOID  == DBValues._DOCTO_ESTATUS_BORRADOR)
                    {
                        if (MessageBox.Show("Desea imprimir cotizacion de comanda? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            //aqui se imprimiria la comanda
                            imprimirReciboComanda(doctoId, 0, false);
                        }
                    }

                    PosPrinter.ImprimirTicket(doctoId, 0, false, bReimpresionesConMarca, 1, false, conTopes, false, null);

                    if (MessageBox.Show("Desea enviar la cotizacion por correo electronico? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        EnviarCotizacionPorEmail();
                    }

                }
            }
        }




        public void imprimirReciboComanda(long doctoId, long lOpcion1, bool enDolar)
        {
            string strReporte = "";

            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("US_ID", ConexionesBD.ConexionBD.CurrentUser.IID);
            dictionary.Add("US_NAME", ConexionesBD.ConexionBD.CurrentUser.IID);
            dictionary.Add("pdoctoid", doctoId);
            dictionary.Add("usaDatosDeEntregaCuandoExista", "N");
            dictionary.Add("desglosekits", "S");
            dictionary.Add("marcaAgua", "N");
            dictionary.Add("enDolar", "N");

            strReporte = "TicketComanda.frx";

            if(CurrentUserID.CurrentParameters.IRECIBOPREVIEWCOMANDA == "S")
            {

                iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
                rp.ShowDialog();
                rp.Dispose();
                GC.SuppressFinalize(rp);
            }
            else
            {
                PosPrinter.ImprimirTicketFromFastReport(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema),
                                                        dictionary,
                                                        CurrentUserID.CurrentParameters.INUMTICKETSCOMANDA == 0 ? 1 : CurrentUserID.CurrentParameters.INUMTICKETSCOMANDA,
                                                        PosPrinter.GetReceiptComandaPrinter());
            }


        }


        private void HabilitarBotonesOpcionales()
        {
            if (!(bool)CurrentUserID.CurrentParameters.isnull["IHAB_SEL_CLIENTE"])
            {
                this.BTCliente.Visible = (CurrentUserID.CurrentParameters.IHAB_SEL_CLIENTE == DBValues._DB_BOOLVALUE_SI);
                this.TBCliente.Enabled = true;
            }
            else
            {
                this.BTCliente.Visible = false;
                this.TBCliente.Enabled = false;
            }


            CUSUARIOSD usersD = new CUSUARIOSD();
            Boolean bTieneDerechoAImprimirCotizacion = usersD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_IMPRIMIRCOTIZACION, null);


            if (((!(bool)CurrentUserID.CurrentParameters.isnull["IHAB_IMPR_COTIZACION"]) && CurrentUserID.CurrentParameters.IHAB_IMPR_COTIZACION == DBValues._DB_BOOLVALUE_SI) && bTieneDerechoAImprimirCotizacion)
            {
                this.BTCotizacion.Visible = true;
            }
            else
            {
                this.BTCotizacion.Visible = false;
            }


            Boolean bTieneDerechoAAbrirVentasCerradas = usersD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_ABRIR_VENTASCERRADAS, null);


            if (bTieneDerechoAAbrirVentasCerradas)
            {
                this.BTAbrirCerradasYDevo.Enabled = true;
                this.BTAbrirCerradasYDevo.ForeColor = Color.Black;
                this.BTAbrirCerradasYDevo.BackColor = Color.FromArgb(238, 170, 25);
            }
            else
            {
                this.BTAbrirCerradasYDevo.Enabled = false;
                this.BTAbrirCerradasYDevo.BackColor = Color.Gray;
            }




        }

        private void gridPVDataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void BTReenviarTraslados_Click(object sender, EventArgs e)
        {

            if (m_Docto.IESTADOSURTIDOID == DBValues._DOCTO_SURTIDOESTADO_PENDIENTE)
            {
                MessageBox.Show("No se puede aun enviar porque se marco como pendiente de surtido");
                return;
            }

            if (MessageBox.Show("¿Desea reimprimir el ticket de traslado?", "Confirmacion de re impresion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                if(m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO && m_Docto.IDOCTOREFID != 0 && CurrentUserID.CurrentParameters.IIMPRFORMAVENTATRASL != null &&
                    CurrentUserID.CurrentParameters.IIMPRFORMAVENTATRASL.Equals("S"))
                {
                    PosPrinter.ImprimirTicket(m_Docto.IDOCTOREFID);
                }
                else
                {

                    PosPrinter.ImprimirTicket(m_Docto.IID);
                }
            }



            if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO)
            {
                CDOCTOD vData = new CDOCTOD();
                m_Docto = vData.seleccionarDOCTO(m_Docto, null);

                ExportarTraslados(m_Docto.IFOLIO);
            }

            if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_PEDIDO_TRASPASO_SALIDA)
            {
                CDOCTOD vData = new CDOCTOD();
                m_Docto = vData.seleccionarDOCTO(m_Docto, null);

                ExportarTrasladosPedidosMatriz(m_Docto.IFOLIO, m_Docto.IID);
            }


            if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA && m_Docto.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_TRASPASOFRANQUICIA_SALIDA)
            {

                CDOCTOD vData = new CDOCTOD();
                m_Docto = vData.seleccionarDOCTO(m_Docto, null);
                CDOCTOBE doctoBEAux = new CDOCTOBE();
                doctoBEAux.IID = m_Docto.IDOCTOREFID;
                doctoBEAux = vData.seleccionarDOCTO(doctoBEAux, null);

                ExportarTraslados(doctoBEAux.IFOLIO);
            }


            if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA && m_Docto.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_TRASPASOFRANQUICIA)
            {

                CDOCTOD vData = new CDOCTOD();
                m_Docto = vData.seleccionarDOCTO(m_Docto, null);
                CDOCTOBE doctoBEAux = new CDOCTOBE();
                doctoBEAux.IID = m_Docto.IDOCTOREFID;
                doctoBEAux = vData.seleccionarDOCTO(doctoBEAux, null);

                ExportarTrasladosPedidosMatriz(doctoBEAux.IFOLIO, doctoBEAux.IID);
            }




        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!validaCustomerIfNeeded())
            {
                return;
            }
            if (m_estadoVenta == (int)estadoVenta.e_Cerrada || m_estadoVenta == (int)estadoVenta.e_Cancelada)
                return;


            PagarBasico(true);
        }

        private void gridPVDataGridView_EnterKeyDownEvent(object sender, EventArgs e)
        {
            this.TBCommandLine.Focus();
        }

        private void TBCommandLine_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Oemplus || e.KeyCode == System.Windows.Forms.Keys.Add)
            {
                ProcessCommand();
            }

        }



        public void llenarDatosSucursalDestino()
        {
            CSUCURSALD sucursalD = new CSUCURSALD();
            CSUCURSALBE sucursalBE = new CSUCURSALBE();

            sucursalBE.IID = m_Docto.ISUCURSALTID;
            sucursalBE = sucursalD.seleccionarSUCURSAL(sucursalBE, null);
            if (sucursalBE != null)
            {
                TBCliente.Text = sucursalBE.ICLAVE;
                this.lbClieNombre.Text = sucursalBE.INOMBRE;
            }

        }




        public void checarVisita()
        {
            if (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL == null || !CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S") ||
                this.m_ClienteId == DBValues._CLIENTEMOSTRADOR || m_ClienteId == 0 || CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 2 || CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 3)
                return;

            CVISITAD visitaD = new CVISITAD();
            CVISITABE visitaBE = new CVISITABE();
            visitaBE = visitaD.seleccionarULTIMAVISITA(null);

            if (visitaBE == null || visitaBE.IPERSONAID != m_ClienteId)
            {
                if (visitaBE != null)
                {

                    bool bVisitaEliminada = false;
                    if (visitaD.cantidadDoctosEnVisita(visitaBE, null) == 0)
                    {
                        if (MessageBox.Show("No registro movimiento para el cliente seleccionado anteriormente : " + visitaBE.IPERSONACLAVE + "Desea cancelar esa visita?", "Cancelar visita", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            visitaD.BorrarVISITAD(visitaBE, null);
                            bVisitaEliminada = true;
                        }
                    }

                    if (!bVisitaEliminada)
                    {
                        visitaD.MOVILVISITA_ASIGNARHIZOPEDIDO(visitaBE, null);
                        visitaBE = visitaD.seleccionarVISITA(visitaBE, null);
                        if (!visitaD.finalizarVISITAD(visitaBE, visitaBE, null))
                        {
                            MessageBox.Show("No se pudo finalizar la visita anterior");
                        }
                    }
                }

                CPERSONABE personaBE = new CPERSONABE();
                CPERSONAD personaD = new CPERSONAD();
                personaBE.IID = m_ClienteId;
                personaBE = personaD.seleccionarPERSONA(personaBE, null);

                if (personaBE == null)
                {
                    MessageBox.Show("No se pudo obtener el cliente");
                }

                visitaBE = new CVISITABE();
                visitaBE.IFECHA = DateTime.Today;
                visitaBE.IHORAINICIO = DateTime.Now;
                visitaBE.IPERSONAID = m_ClienteId;
                visitaBE.IPERSONACLAVE = personaBE == null ? "" : personaBE.ICLAVE;
                visitaBE.IACTIVO = "S";
                visitaBE.IHIZOPEDIDO = "N";
                visitaBE.IENVIADOWS = "N";
                

                visitaD.AgregarVISITAD(visitaBE, null);
                if (visitaBE == null)
                {
                    MessageBox.Show("Ocurrio un error : " + visitaD.IComentario);
                }

            }



        }


        private void FinalizarVisitaPedido(Boolean preguntar)
        {

            if (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL != null && CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
            {
                CVISITAD visitaD = new CVISITAD();
                CVISITABE visitaBE = new CVISITABE();
                visitaBE = visitaD.seleccionarULTIMAVISITA(null);

                if (visitaBE != null && visitaBE.IPERSONAID == m_Docto.IPERSONAID)
                {
                    string strOption = "Finalizar";
                    if (preguntar)
                    {
                        if (MessageBox.Show("Desea guardar la ultima visita aunque no haya hecho registros?", "Guardar visita", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                        {
                            strOption = "Eliminar";
                        }
                    }

                    if (strOption.Equals("Finalizar"))
                    {
                        visitaBE.IHORAFIN = DateTime.Now;
                        visitaBE.IHIZOPEDIDO = "P";
                        visitaD.finalizarVISITAD(visitaBE, visitaBE, null);
                    }
                    else
                    {
                        visitaD.BorrarVISITAD(visitaBE, null);
                    }
                }
            }
        }


        public void llenarDatosCliente()
        {

            if (m_ClienteId != 0 && m_ClienteId != 1)
            {

                CPERSONAD clienteD = new CPERSONAD();
                CPERSONABE clienteBE = new CPERSONABE();
                clienteBE.IID = m_ClienteId;
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

                    TBCliente.Text = clienteBE.ICLAVE;

                    if ((!(bool)clienteBE.isnull["IMONEDAID"]) && clienteBE.IMONEDAID != 0 && clienteBE.IMONEDAID != DBValues._MONEDA_PESOS)
                    {
                        //tipo de cambio
                        CMONEDABE monedaBE = new CMONEDABE();
                        CMONEDAD monedaD = new CMONEDAD();
                        monedaBE.IID = ((bool)clienteBE.isnull["IMONEDAID"] || clienteBE.IMONEDAID == 0) ? DBValues._MONEDA_PESOS : clienteBE.IMONEDAID;
                        monedaBE = monedaD.seleccionarMONEDA(monedaBE, null);
                        if (monedaBE != null)
                        {
                            LBMONEDA.Text = monedaBE.INOMBRE;
                        }
                        else
                        {
                            LBMONEDA.Text = "Moneda Nacional";
                        }

                    }
                    else
                    {
                        LBMONEDA.Text = "Moneda Nacional";
                    }

                    if (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL != null && CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S") &&
                        (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL <= 1 || CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 4))
                    {
                        lblSaldo.Text = ((bool)clienteBE.isnull["ISALDOMOVIL"]) ? "" : clienteBE.ISALDOMOVIL.ToString("N2");
                        lblSaldoVencido.Text = ((bool)clienteBE.isnull["ISALDOVENCIDOMOVIL"]) ? "" : clienteBE.ISALDOVENCIDOMOVIL.ToString("N2");
                        lblLimite.Text = ((bool)clienteBE.isnull["ILIMITECREDITO"]) ? "" : clienteBE.ILIMITECREDITO.ToString("N2");
                        lblAbonos.Text = clienteD.selectSumaPagoMovil(m_ClienteId, null).ToString();
                    }


                    if (!(bool)clienteBE.isnull["ISERVICIOADOMICILIO"] && clienteBE.ISERVICIOADOMICILIO != null && clienteBE.ISERVICIOADOMICILIO.Equals("S"))
                    {
                        if (m_estadoVenta != (int)estadoVenta.e_Cancelada)
                        {
                            this.btDomicilioEntrega.Enabled = true;
                        }
                    }

                }
                else
                {

                    lbClieCiudad.Text = "";
                    lbClieColonia.Text = "";
                    lbClieCP.Text = "";
                    lbClieDom.Text = "";
                    lbClieEstado.Text = "";
                    lbClieNombre.Text = "";
                    lbClieRFC.Text = "";
                    lbClieTel.Text = "";
                    LBMONEDA.Text = "Moneda Nacional";

                    if (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL != null && CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S") &&
                        (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL <= 1 || CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 4))
                    {
                        lblSaldo.Text = "";
                        lblSaldoVencido.Text = "";
                        lblLimite.Text = "";
                        lblAbonos.Text = "";
                    }
                }
            }
            else if (m_Docto != null && m_Docto.IID != 0 && m_Docto.IPERSONAID == 1 && m_Docto.IESTATUSDOCTOID == 0 && m_Docto.IPERSONAAPARTADOID > 0)
            {

                CPERSONAAPARTADOD personaApartadoD = new CPERSONAAPARTADOD();
                CPERSONAAPARTADOBE personaApartadoBE = new CPERSONAAPARTADOBE();

                personaApartadoBE.IID = m_Docto.IPERSONAAPARTADOID;
                personaApartadoBE = personaApartadoD.seleccionarPERSONAAPARTADO(personaApartadoBE, null);

                if (personaApartadoBE != null)
                {


                    lbClieCiudad.Text = personaApartadoBE.ICIUDAD;
                    lbClieColonia.Text = personaApartadoBE.ICOLONIA;
                    lbClieCP.Text = personaApartadoBE.ICODIGOPOSTAL;
                    lbClieDom.Text = personaApartadoBE.IDOMICILIO;
                    lbClieEstado.Text = personaApartadoBE.IESTADO;
                    lbClieNombre.Text = personaApartadoBE.INOMBRES;
                    lbClieRFC.Text = "";
                    lbClieTel.Text = personaApartadoBE.ITELEFONO1;
                    LBMONEDA.Text = "Moneda Nacional";
                }
                else
                {

                    lbClieCiudad.Text = "";
                    lbClieColonia.Text = "";
                    lbClieCP.Text = "";
                    lbClieDom.Text = "";
                    lbClieEstado.Text = "";
                    lbClieNombre.Text = "";
                    lbClieRFC.Text = "";
                    lbClieTel.Text = "";
                    LBMONEDA.Text = "Moneda Nacional";
                }
            }
            else
            {

                lbClieCiudad.Text = "";
                lbClieColonia.Text = "";
                lbClieCP.Text = "";
                lbClieDom.Text = "";
                lbClieEstado.Text = "";
                lbClieNombre.Text = "";
                lbClieRFC.Text = "";
                lbClieTel.Text = "";
                LBMONEDA.Text = "Moneda Nacional";
            }

        }

        private void BTRecalcular_Click(object sender, EventArgs e)
        {

            if (m_Docto != null)
            {
                if (!(bool)m_Docto.isnull["IID"])
                {
                    CPuntoDeVentaD pvd = new CPuntoDeVentaD();
                    m_Docto.IPERSONAID = this.m_ClienteId;
                    if (!pvd.ActualizarClienteDOCTO(m_Docto, null))
                        MessageBox.Show(pvd.IComentario);
                    else
                        RefrescarGridVentas();
                }
            }
        }



        private void CambiarPrecioDetalle()
        {
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            CMOVTOBE movtoBE = new CMOVTOBE();
            WFPreguntaAutorizacion ps2 = new WFPreguntaAutorizacion();
            CPERSONABE supervisorBE = null;

            if (this.gridPVDataGridView.Rows.Count <= 0)
                return;

            //asegurarnos de que realmente se quiere eliminar el detalle y que el supervisor dio su aval
            if (MessageBox.Show("Realmente quiere cambiar el precio del detalle de venta?", "Cambiar precio del detalle de venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ps2.ShowDialog();
                CPERSONABE userBE = ps2.m_userBE;
                supervisorBE = ps2.m_supervisorBE;
                bool bPassValido = ps2.m_bPassValido;
                bool bIsSupervisor = ps2.m_bIsSupervisor;
                bool bIsAdministrador = ps2.m_bIsAdministrador;
                ps2.Dispose();
                GC.SuppressFinalize(ps2);
                if (!ps2.m_bPassValido)
                    return;

                if (!ps2.m_bIsSupervisor)
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

                WFPreguntaPrecio pr_ = new WFPreguntaPrecio();
                pr_.ShowDialog();
                bool bProcesado = pr_.m_bProcesado;
                decimal precio_ = pr_.M_precio;
                pr_.Dispose();
                GC.SuppressFinalize(pr_);

                if (!bProcesado)
                {
                    MessageBox.Show("El usuario cancelo la operacion");
                }
                else
                {


                    TBCommandLine.Text = "0" + "*" + this.gridPVDataGridView.CurrentRow.Cells["GVCLAVEPRODUCTO"].Value.ToString();
                    TBPrecio.Text = precio_.ToString("0.00");
                    TBDescuento.Text = formateaDescuento(this.gridPVDataGridView.CurrentRow.Cells["DESCUENTOPORCENTAJE"].Value.ToString());

                    long? P_MOVTOID = (long)this.gridPVDataGridView.CurrentRow.Cells["MOVTOID"].Value;
                    if (!ProcessCommand(false, false, P_MOVTOID, true, false, true))
                    {
                    }
                    else
                    {
                        m_supervisor = supervisorBE;

                        CDOCTOD doctoD = new CDOCTOD();
                        m_Docto.ISUPERVISORID = m_supervisor.IID;
                        doctoD.CambiarSupervisorAutorizacionDOCTOD(m_Docto, null);

                        this.TBCommandLine.Focus();
                    }

                }


                RefrescarGridVentas();
            }
            RefrescarEstatusBotones();
            this.TBCommandLine.Focus();

        }


        private void NuevoDevolucion()
        {



            if ((!(bool)m_Docto.isnull["IID"])
                && (m_estadoVenta == (int)estadoVenta.e_Cerrada))
            {

                CDOCTOBE doctoBuffer = m_Docto;
                m_Docto = new CDOCTOBE();
                IrANuevaVenta();
                this.m_DoctoRef = doctoBuffer;
                this.m_tipoTransaccion = tipoTransaccionV.t_devolucion;



                //cliente
                CPERSONAD clienteD = new CPERSONAD();
                CPERSONABE clienteBE = new CPERSONABE();
                clienteBE.IID = m_ClienteId;
                clienteBE = clienteD.seleccionarPERSONA(clienteBE, null);


                if (clienteBE != null)
                {
                    TBCliente.Text = clienteBE.ICLAVE;
                }

                this.BTReenviarTraslados.Visible = false;
                this.BTCliente.Enabled = false;
                this.TBCliente.Enabled = false;
                this.BTRecalcular.Enabled = false;

                this.BTPasarANueva.Enabled = true;
                this.BTPasarANueva.ForeColor = Color.Black;
                this.BTPasarANueva.BackColor = Color.FromArgb(41, 121, 255);
                this.BTEliminarDetalle.Enabled = true;
                this.BTEliminarDetalle.ForeColor = Color.Black;
                this.BTEliminarDetalle.BackColor = Color.FromArgb(219, 44, 44);
                this.btnAdjunto.Enabled = true;
                this.btnAdjunto.ForeColor = Color.Black;
                this.btnAdjunto.BackColor = Color.FromArgb(41, 121, 255);
                this.btnListaAdjuntos.Enabled = true;
                this.btnListaAdjuntos.ForeColor = Color.Black;
                this.btnListaAdjuntos.BackColor = Color.FromArgb(41, 121, 255);
                this.BTCerrarVenta.Enabled = false;
                this.BTCerrarVenta.BackColor = Color.Gray;
                this.BTRecalcular.Enabled = false;
                this.btnNuevaApartado.Enabled = false;
                this.BTPagarConVale.Enabled = false;
                this.gridPVDataGridView.Columns["TOTALVALE"].Visible = false;
                this.LBOperacion.Text = "Devolución";
                this.BTEnviarASurtir.Enabled = false;
                this.BTEnviarASurtir.BackColor = Color.Gray;

                /*this.ComboVendedorFinal.Enabled = false;

                if (!(bool)m_Docto.isnull["IVENDEDORFINAL"])
                {
                    this.ComboVendedorFinal.SelectedValue = m_Docto.IVENDEDORFINAL;
                }*/
                this.VENDEDORIDTextBox.Enabled = false;
                if (!(bool)m_Docto.isnull["IVENDEDORFINAL"])
                {

                    string strBuffer = "";
                    this.VENDEDORIDTextBox.DbValue = m_Docto.IVENDEDORFINAL.ToString();
                    this.VENDEDORIDTextBox.MostrarErrores = false;
                    this.VENDEDORIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.VENDEDORIDTextBox.MostrarErrores = true;
                }
                else
                {
                    this.VENDEDORIDTextBox.Text = "";
                }

                // vendedor ejecutivo
                if (!(bool)m_Docto.isnull["IVENDEDOREJECUTIVOID"])
                {

                    LlenarDatosVendedorEjecutivo(m_Docto.IVENDEDOREJECUTIVOID);
                }
                else
                {
                    this.m_vendedorEjecutivoId = 0;
                    lblVendedorEjecutivo.Text = "";
                }

                m_Docto.ITIPODOCTOID = DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO;
                m_Docto.IDOCTOREFID = this.m_DoctoRef.IID;
                m_Docto.IPERSONAID = this.m_DoctoRef.IPERSONAID;
                this.m_ClienteId = this.m_DoctoRef.IPERSONAID;
                PonerHabilitacionPagoTarjeta();



            }
        }

        private void LlenarDatosVendedorEjecutivo(long vendedorEjecutivoId)
        {


            this.m_vendedorEjecutivoId = vendedorEjecutivoId;
            CPERSONABE vendBE = new CPERSONABE();
            CPERSONAD vendD = new CPERSONAD();
            vendBE.IID = this.m_vendedorEjecutivoId;
            vendBE = vendD.seleccionarPERSONA(vendBE, null);
            if (vendBE != null)
                lblVendedorEjecutivo.Text = vendBE.ICLAVE;

        }

        private void BTDevolver_Click(object sender, EventArgs e)
        {


            CPuntoDeVentaD pvd = new CPuntoDeVentaD();

            if ((!(bool)m_Docto.isnull["IID"])
                && (m_estadoVenta == (int)estadoVenta.e_Cerrada)
                && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA || (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTAAPARTADO && m_Docto.IMERCANCIAENTREGADA == "S"))
            {
                NuevoDevolucion();
            }
            else if ((!(bool)m_Docto.isnull["IID"])
                && (m_estadoVenta == (int)estadoVenta.e_Cerrada)
                && (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO))
            {
                long doctoIDEdicion = 0;

                if (pvd.EditarDevolucion(m_Docto, CurrentUserID.CurrentUser, ref doctoIDEdicion, CurrentUserID.CurrentUser.IID, null))
                {
                    IrANuevaVenta();
                    m_Docto = new CDOCTOBE();
                    m_Docto.IID = doctoIDEdicion;
                    CDOCTOD vData = new CDOCTOD();
                    m_Docto = vData.seleccionarDOCTO(m_Docto, null);


                    m_DoctoRef = new CDOCTOBE();
                    this.m_DoctoRef.IID = m_Docto.IDOCTOREFID;
                    m_DoctoRef = vData.seleccionarDOCTO(m_DoctoRef, null);

                    this.m_tipoTransaccion = tipoTransaccionV.t_devolucion;
                    RefrescarGridVentas();
                    if (!m_bTieneDerechoBloquearF6)
                    {
                        this.BTCerrarVenta.Enabled = true;
                        this.BTCerrarVenta.ForeColor = Color.Black;
                        this.BTCerrarVenta.BackColor = Color.FromArgb(74, 196, 77);
                    }
                    else
                    {
                        this.BTCerrarVenta.Enabled = false;
                        this.BTCerrarVenta.BackColor = Color.Gray;
                    }
                    this.BTRecalcular.Enabled = true;
                    this.btnNuevaApartado.Enabled = true;
                }
            }
            else if ((!(bool)m_Docto.isnull["IID"])
                && (m_estadoVenta == (int)estadoVenta.e_Cerrada)
                && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTAAPARTADO && m_Docto.IMERCANCIAENTREGADA == "N")
            {
                long doctoIDEdicion = 0;

                if (pvd.EditarApartado(m_Docto, CurrentUserID.CurrentUser, ref doctoIDEdicion, CurrentUserID.CurrentUser.IID, null))
                {
                    IrANuevaVenta();
                    m_Docto = new CDOCTOBE();
                    m_Docto.IID = doctoIDEdicion;
                    CDOCTOD vData = new CDOCTOD();
                    m_Docto = vData.seleccionarDOCTO(m_Docto, null);


                    m_DoctoRef = new CDOCTOBE();
                    this.m_DoctoRef.IID = m_Docto.IDOCTOREFID;
                    m_DoctoRef = vData.seleccionarDOCTO(m_DoctoRef, null);

                    this.m_tipoTransaccion = tipoTransaccionV.t_ventaapartado;
                    RefrescarGridVentas();
                    if (!m_bTieneDerechoBloquearF6)
                    {
                        this.BTCerrarVenta.Enabled = true;
                        this.BTCerrarVenta.ForeColor = Color.Black;
                        this.BTCerrarVenta.BackColor = Color.FromArgb(74, 196, 77);
                    }
                    else
                    {
                        this.BTCerrarVenta.Enabled = false;
                        this.BTCerrarVenta.BackColor = Color.Gray;
                    }

                    this.BTRecalcular.Enabled = true;
                    this.btnNuevaApartado.Enabled = true;
                }
            }
        }

        private void btnNuevaApartado_Click(object sender, EventArgs e)
        {
            if (!validaCustomerIfNeeded())
            {
                return;
            }


            if (m_estadoVenta == (int)estadoVenta.e_Cerrada || m_estadoVenta == (int)estadoVenta.e_Cancelada)
                return;


            PagarBasicoApartado();
        }





        private bool FacturaElectronica()
        {
            if (m_Docto != null && m_Docto.IID > 0)
            {


                CDOCTOD vData = new CDOCTOD();
                m_Docto = vData.seleccionarDOCTO(m_Docto, null);
                bool retorno;

                if (ValidarDatosParaFacturaElectronica(this.m_Docto))
                {
                    iPosReporting.WFFacturaElectronica fe = new iPosReporting.WFFacturaElectronica(this.m_Docto, CurrentUserID.CurrentParameters, WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_TIMBRAR, this.m_DoctoRef, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
                    CUSUARIOSD usuariosD = new CUSUARIOSD(); fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
                    fe.ShowDialog();
                    retorno = fe.m_facturacionRealizada;
                    fe.Dispose();
                    GC.SuppressFinalize(fe);
                }
                else
                {
                    retorno = false;
                }
                return retorno;


            }
            return false;
        }


        private bool ValidarDatosParaFacturaElectronica(CDOCTOBE docto)
        {
            CPuntoDeVentaD pd = new CPuntoDeVentaD();
            if (!pd.VALIDAR_PARAFACTURAELECTRONICA(docto, null))
            {
                MessageBox.Show("Errores " + pd.IComentario);
                if (pd.IComentario.Contains("HAY PRODUCTOS SIN CLAVE SAT"))
                {
                    PuntoDeVenta.WFProductosSinClaveSat wfProdSat = new PuntoDeVenta.WFProductosSinClaveSat(docto.IID);
                    wfProdSat.ShowDialog();
                    wfProdSat.Dispose();
                    GC.SuppressFinalize(wfProdSat);
                }
                return false;
            }
            return true;
        }





        private bool ProcesarMonedero(CMONEDEROBE monederoBE, decimal montoAAplicar)
        {
            CMONEDEROBE bufferMonedero = monederoBE;
            if (bufferMonedero == null)
            {
                CMONEDEROD monederoD = new CMONEDEROD();
                if (monederoD.AbonoDisponibleDocto(m_Docto, null) > 0)
                {
                    WFPreguntaMonedero wfMoned = new WFPreguntaMonedero(m_Docto, "MONEDERO EN DONDE SE ABONARA", "", 1);
                    wfMoned.ShowDialog();
                    bufferMonedero = wfMoned.m_monedero;
                    wfMoned.Dispose();
                    GC.SuppressFinalize(wfMoned);
                }
            }

            if (bufferMonedero == null)
            {
                bufferMonedero = new CMONEDEROBE();
                bufferMonedero.IID = 0;
                bufferMonedero.ICLAVE = "";
            }

            if (!AplicarMonedero(bufferMonedero, montoAAplicar))
            {
                return false;
            }
            return true;

        }


        private bool AplicarMonedero(CMONEDEROBE monederoBE, decimal montoAAplicar)
        {
            CMONEDEROD monederoD = new CMONEDEROD();

            if (!monederoD.MONEDERO_APLICAR(monederoBE, this.m_Docto, montoAAplicar, null))
            {
                MessageBox.Show(monederoD.IComentario);
                return false;
            }
            return true;
        }

        private void BtnImprimirFE_Click(object sender, EventArgs e)
        {
            if(!(bool)m_Docto.isnull["IFOLIOSAT"])
            {
                imprimirFacturaElectronica();
                if (CurrentUserID.CurrentParameters.IRECIBOLARGOCONFACTURA.Equals("S"))
                {
                    imprimirTicketFacturaElectronica();
                }
            }

            reimprimirTrasladoIfContains();
        }

        private void reimprimirTrasladoIfContains()
        {
            CDOCTOD doctoD = new CDOCTOD();
            bool containsTraslado = doctoD.ContieneComprobante(m_Docto, "T", null);
            if(containsTraslado)
            {
                this.imprimirComprobanteTraslado();
            }
        }


        private void DescripcionesDeProductoEnDataSet(long productoId, ref string desc1, ref string desc2, ref string desc3)
        {
            foreach (iPos.PuntoDeVenta.DSPuntoDeVentaAux2.GRIDPVRow dr in dSPuntoDeVentaAux2.GRIDPV.Rows)
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

        private void gridPVDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (m_estadoVenta == (int)estadoVenta.e_Cancelada || m_estadoVenta == (int)estadoVenta.e_Cerrada)
                return;

            if (e.RowIndex != gridPVDataGridView.NewRowIndex && e.ColumnIndex == 8)
            {
                try
                {
                    CUSUARIOSD usuariosD = new CUSUARIOSD();
                    if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_CAMBIARTASAIVAENVENTAS, null))
                    {
                        return;
                    }

                    long P_MOVTOID = (long)gridPVDataGridView.Rows[e.RowIndex].Cells["MOVTOID"].Value;
                    WFCambiarTASAIVA wfc = new WFCambiarTASAIVA(P_MOVTOID, this.m_ClienteId);
                    wfc.ShowDialog();

                    if (wfc.m_cambiotasa)
                    {
                        RefrescarGridVentas();
                        FormatGrid();
                        GetTotalesPagosVenta();
                        RefreshTotalesVenta();
                        RefreshNumVenta();
                    }
                    wfc.Dispose();
                    GC.SuppressFinalize(wfc);
                }
                catch
                {
                }
            }
        }



        private void TBCantidad_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            /*if (m_estadoVenta == (int)estadoVenta.e_Cerrada || m_estadoVenta == (int)estadoVenta.e_Cancelada)
                return;

            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                if (!CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
                {
                    ProcessCommand();
                    this.label19.Focus();
                    
                }
            }*/
        }

        private void TBCajas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TBCantidad.Focus();
            }


        }

        private void TBCantidad_KeyDown(object sender, KeyEventArgs e)
        {


            if (m_estadoVenta == (int)estadoVenta.e_Cerrada || m_estadoVenta == (int)estadoVenta.e_Cancelada)
                return;

            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                if (!CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
                {
                    ProcessCommand();
                    this.TBCommandLine.Focus();
                    //m_focusInCommandLine = true;
                    //this.label19.Focus();

                }
                else
                {
                    if (TBPrecio.Enabled)
                    {
                        TBPrecio.Focus();
                    }
                    else if (TBDescuento.Enabled)
                    {
                        TBDescuento.Focus();
                    }
                }
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            bool retorno;

            CDOCTOD doctoD = new CDOCTOD();
            m_Docto = doctoD.seleccionarDOCTO(m_Docto, null);



            iPosReporting.WFFacturaElectronica fe = new iPosReporting.WFFacturaElectronica(this.m_Docto, CurrentUserID.CurrentParameters, WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_TIMBRAR, this.m_DoctoRef, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
            CUSUARIOSD usuariosD = new CUSUARIOSD(); fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
            fe.ShowDialog();
            retorno = fe.m_facturacionRealizada;
            fe.Dispose();
            GC.SuppressFinalize(fe);

            /* WFFacturaElectronica fe = new WFFacturaElectronica(this.m_Docto, CurrentUserID.CurrentParameters, WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_GENERARPDF, this.m_DoctoRef, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
             fe.ShowDialog();
             retorno = fe.m_facturacionRealizada;
             fe.Dispose();
             GC.SuppressFinalize(fe);*/
            return;

        }




        private bool SeleccionarAlmacenTID()
        {
            bool retorno = false;
            WFPreguntaAlmacen look;
            look = new WFPreguntaAlmacen();
            look.ShowDialog();



            if (look.m_almacenorigenid != 0 && look.m_almacendestinoid != 0)
            {
                m_almacenTID = look.m_almacendestinoid;
                //this.LBOperacion.Text = "Tras. almacenes";
                //this.BTCliente.Text = "ALM_DEST:";
                //this.BTCliente.Enabled = false;
                //this.TBCliente.Enabled = false;
                m_ClienteId = DBValues._CLIENTEMOSTRADOR;
                PonerHabilitacionPagoTarjeta();

                TBCliente.Text = look.m_destino;


                //this.ALMACENComboBox.Enabled = false;
                this.ALMACENComboBox.SelectedDataValue = look.m_almacenorigenid;


                retorno = true;
            }

            
            look.Dispose();
            GC.SuppressFinalize(look);


            return retorno;
        }


        private void ModoNuevoTraspasoAlmacenes()
        {

            //CUSUARIOSD usuariosD = new CUSUARIOSD();
            //if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_AGREGAR_TRASLADOS, null))
            //{
            //    MessageBox.Show("No tiene permisos para hacer traslados");
            //    return;
            //}

            NuevoRegistro();
            if (!this.SeleccionarAlmacenTID())
                return;

            m_Docto.ITIPODOCTOID = DBValues._DOCTO_TIPO_TRASPASO_ALMACEN;

            ModoTraspasoAlmacen();
        }

        private void ModoTraspasoAlmacen()
        {

            this.BTPasarANueva.Enabled = true;
            this.BTPasarANueva.ForeColor = Color.Black;
            this.BTPasarANueva.BackColor = Color.FromArgb(41, 121, 255);

            this.btnNuevaApartado.Enabled = false;
            this.BTPagarConVale.Enabled = false;

            m_tipoTransaccion = tipoTransaccionV.t_traspasoalmacen;
            
            this.LBOperacion.Text = "Tras. almacenes";
            this.BTCliente.Text = "ALM_DEST:";
            this.BTCliente.Enabled = false;
            this.TBCliente.Enabled = false;
            m_ClienteId = DBValues._CLIENTEMOSTRADOR;

            this.ALMACENComboBox.Enabled = false;

            if(this.m_Docto != null && this.m_Docto.IID > 0 && this.m_Docto.IALMACENTID > 0)
            {

                CALMACENBE almacenBE = new CALMACENBE();
                CALMACEND almacenD = new CALMACEND();
                almacenBE.IID = m_Docto.IALMACENTID;
                almacenBE = almacenD.seleccionarALMACEN(almacenBE, null);
                if(almacenBE != null)
                    TBCliente.Text = almacenBE.INOMBRE;
            }


            this.CBCotizacionEnrutada.Visible = false;
        }

        private void BTTraspasoAlmacenes_Click(object sender, EventArgs e)
        {
            ModoNuevoTraspasoAlmacenes();
        }

        private void btnCambiarDocumento_Click(object sender, EventArgs e)
        {

            if (m_Docto == null)
                return;

            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            bool bRequiereReceta = pvd.REQUIERERECETA(m_Docto, null);

            if (bRequiereReceta)
            {
                AsignarReceta();
            }
            else
            {
                MessageBox.Show("Esta venta no tiene productos que requieran documento");
            }
        }


        /*void MoverPanelPorKeyBoard(object sender)
        {


            TextBox textsender = (TextBox)sender;
            if (m_keyboardSize > 0)
            {
                if (focusedTextbox == textsender)
                    return;

                focusedTextbox = (TextBox)sender;
                int hei = m_mainViewHeight - m_keyboardSize - 30;
                keyboardcontrol1.Location = new Point(0, hei);
                //keyboardcontrol1.Size = new Size(993, 282);
                keyboardcontrol1.Size = new Size(634, 180);
                keyboardcontrol1.BringToFront();

                Point location = textsender.PointToScreen(Point.Empty);
                if (location.Y > m_mainViewHeight - m_keyboardSize)
                {
                    int movimiento = 0;

                    int middleLeftSpace = (m_mainViewHeight - m_keyboardSize) / 2;


                    movimiento -= location.Y - middleLeftSpace;

                    //movimiento -= middleLeftSpace;

                    panelRoot.Location = new Point(panelRoot.Location.X, movimiento);
                }


            }
        }

        void RestaurarPosicionPanel()
        {

            if (m_keyboardSize > 0)
            {

                if (!m_teclaTouch)
                {
                    panelRoot.Location = new Point(panelRoot.Location.X, 0);

                    keyboardcontrol1.Location = new Point(0, m_mainViewHeight);
                    keyboardcontrol1.Size = new Size(993, 1);
                    keyboardcontrol1.SendToBack();
                    focusedTextbox = null;
                }
                else
                {
                    m_teclaTouch = false;
                }
            }
        }


        */



        private void TBCommandLine_Enter(object sender, EventArgs e)
        {
            // MoverPanelPorKeyBoard(sender);

            if (CurrentUserID.CurrentParameters.IAUTOCOMPPROD.Equals("S"))
            {
                TBCommandLine.Width = 500;
            }

        }

        private void TBCommandLine_Leave(object sender, EventArgs e)
        {

            //   RestaurarPosicionPanel();
            if (CurrentUserID.CurrentParameters.IAUTOCOMPPROD.Equals("S"))
            {
                TBCommandLine.Width = m_CommandLineWidth;
            }

            /*if (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S") && !lstProductoComplete.Focused)
            {
                lstProductoComplete.Visible = false;
                lstProductoComplete.Items.Clear();
            }*/


        }

        private void gridPVDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //MoverPanelPorKeyBoard(sender);
        }

        private void gridPVDataGridView_EditingControlShowing(object sender,
    DataGridViewEditingControlShowingEventArgs e)
        {
            //MoverPanelPorKeyBoard(e.Control);
        }

        private void gridPVDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // RestaurarPosicionPanel();
        }

        private void keyboardcontrol1_UserKeyPressed(object sender, KeyboardClassLibrary.KeyboardEventArgs e)
        {

            //focusedTextbox.Focus();
            //SendKeys.Send(e.KeyboardKeyPressed);
        }

        private void TBCajas_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            /*if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                TBCantidad.Focus();*/
        }

        private void BTValidarExistencia_Click(object sender, EventArgs e)
        {
            PreValidar();
        }

        private void PreValidar()
        {


            com.server.ipos.Service1 service1 = new com.server.ipos.Service1();
            string strWebService = CurrentUserID.CurrentParameters.IUSARCONEXIONLOCAL.Equals("S") ? (CurrentUserID.CurrentParameters.ILOCALWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.ILOCALWEBSERVICE.Trim()) : (CurrentUserID.CurrentParameters.IWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.IWEBSERVICE.Trim());
            if (strWebService.Trim().Length > 0)
            {
                service1.Url = strWebService.Trim();
            }

            CMOVTOD movtoD = new CMOVTOD();
            CMOVTOBE[] movtos = movtoD.seleccionarMOVTOSDEDOCTO(m_Docto.IID, null);



            if (movtos == null)
            {

                MessageBox.Show("No se pudo obtener los detalles de la venta");
                return;
            }




            CPERSONABE cliente = new CPERSONABE();
            CPERSONAD clienteD = new CPERSONAD();
            cliente.IID = m_Docto.IPERSONAID;
            cliente = clienteD.seleccionarPERSONA(cliente, null);

            if (cliente == null)
            {
                MessageBox.Show("No se pudo obtener el cliente");
                return;
            }


            ArrayList vedps = new ArrayList();
            foreach (CMOVTOBE movto in movtos)
            {


                if (movto.IMOVTOADJUNTOAID > 0)
                    continue;


                if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL != 2 && CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL != 3 && CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL != 4)
                {
                    if (cliente != null && cliente.ICLAVE != null && cliente.ICLAVE.Trim().Length > 6)
                        cliente.ICLAVE = ImportaFtpMovil.convertCustomerClaveToClipClave(cliente.ICLAVE);
                }

                CM_VEDPBE vedpbe = CM_VEDPD.convertMovtoIntoVEDP(movto, m_Docto, cliente);
                if (vedpbe == null)
                {

                    MessageBox.Show("No se pudieron convertir algunso detalles para enviarlos");
                    return;
                }

                vedps.Add(vedpbe);
            }


            CM_VEDPBE[] vedpbes = new CM_VEDPBE[vedps.Count];
            vedps.CopyTo(vedpbes, 0);
            string jsonStr = JsonConvert.SerializeObject(vedpbes, Formatting.Indented);

            string strRespuesta = "";
            try
            {


                if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 2)
                {
                    strRespuesta = service1.ValidarVentaMovil_2(jsonStr, iPos.CurrentUserID.CurrentParameters.IBDSERVERWS, iPos.CurrentUserID.CurrentUser.IUSERNAME,
                                    iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                    iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                }
                else if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 3 || CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 4)
                {
                    strRespuesta = service1.ValidarVentaMovil_3(jsonStr, iPos.CurrentUserID.CurrentParameters.IVENDEDORMOVILCLAVE, iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                    iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                    iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                }
                else if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 1)
                {
                    strRespuesta = service1.ValidarVentaMovil(jsonStr, iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                    iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                    iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                }

                if (!strRespuesta.StartsWith("["))
                {
                    MessageBox.Show("No se pudo validar la venta: " + strRespuesta);
                }



                List<CM_PROPBE> prods = JsonConvert.DeserializeObject<List<CM_PROPBE>>(strRespuesta);
                if (/*prods.Count > 0*/ prods != null)
                {
                    bool bFormShown = false;
                    foreach (CM_VEDPBE detalle in vedpbes)
                    {
                        bool productoHayado = false;
                        bool flagFaltaExistencia = false;
                        foreach (CM_PROPBE prod in prods)
                        {
                            if (detalle.IPRODUCTO.Trim().Equals(prod.IPRODUCTO.Trim()))
                            {
                                if (detalle.ICANTIDAD > prod.IEXIS1)
                                {
                                    //flagFaltaExistencia = true;
                                    //MessageBox.Show("Falta existencia - insuficiente");
                                    //return;

                                    flagFaltaExistencia = true;

                                }
                                productoHayado = true;
                                break;
                            }
                        }
                        if (!productoHayado || flagFaltaExistencia)
                        {

                            WFValidacionExistenciasMovil form = new WFValidacionExistenciasMovil(m_Docto, TipoValidacionMovil.porExistencia, prods, null);
                            form.ShowDialog();
                            bFormShown = true;
                            form.Dispose();
                            GC.SuppressFinalize(form);


                        }

                    }

                    if (!bFormShown)
                    {
                        MessageBox.Show("Parece que hay existencias suficiente para todos los productos de esta venta");
                    }
                }

            }
            catch
            {
                MessageBox.Show("No se pudo validar las existencias");
                return;
            }




        }



        private bool MovilCancelVenta()
        {


            com.server.ipos.Service1 service1 = new com.server.ipos.Service1();
            string strWebService = CurrentUserID.CurrentParameters.IUSARCONEXIONLOCAL.Equals("S") ? (CurrentUserID.CurrentParameters.ILOCALWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.ILOCALWEBSERVICE.Trim()) : (CurrentUserID.CurrentParameters.IWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.IWEBSERVICE.Trim());
            if (strWebService.Length > 0)
            {
                service1.Url = strWebService.Trim();
            }





            string strRespuesta = "";
            try
            {

                if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 1)
                {
                    strRespuesta = service1.EliminarVentaMovil(m_Docto.IFOLIO.ToString(), "", "", "", "", iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                }
                else if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 3 || CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 4)
                {
                    strRespuesta = service1.EliminarVentaMovil_3(m_Docto.IFOLIO.ToString(), "", "", "", "", iPos.CurrentUserID.CurrentParameters.IVENDEDORMOVILCLAVE, iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                }


                if (!strRespuesta.Equals("exito"))
                {
                    MessageBox.Show("No se pudo eliminar la venta movil en el servicio web: " + strRespuesta);
                    return false;
                }


                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar la venta movil en el servicio web  " + ex.Message);
                return false;
            }




        }


        private bool MovilPreeditarVenta()
        {


            com.server.ipos.Service1 service1 = new com.server.ipos.Service1();
            string strWebService = CurrentUserID.CurrentParameters.IUSARCONEXIONLOCAL.Equals("S") ? (CurrentUserID.CurrentParameters.ILOCALWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.ILOCALWEBSERVICE.Trim()) : (CurrentUserID.CurrentParameters.IWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.IWEBSERVICE.Trim());
            if (strWebService.Trim().Length > 0)
            {
                service1.Url = strWebService.Trim();
            }





            string strRespuesta = "";
            try
            {

                if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 2)
                {

                    strRespuesta = service1.PreEditarVentaMovil_2(getLastNChars(m_Docto.IID.ToString(), 10), m_Docto.IFOLIO.ToString(), m_Docto.IFECHA, iPos.CurrentUserID.CurrentParameters.IBDSERVERWS, iPos.CurrentUserID.CurrentUser.IUSERNAME,
                                    iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                    iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                }
                else if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 3 || CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 4)
                {

                    strRespuesta = service1.PreEditarVentaMovil_3(m_Docto.IFOLIO.ToString(), "", "", "", "", iPos.CurrentUserID.CurrentParameters.IVENDEDORMOVILCLAVE, iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                    iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                    iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                }
                else
                {

                    strRespuesta = service1.PreEditarVentaMovil(m_Docto.IFOLIO.ToString(), "", "", "", "", iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                    iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                    iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                }


                if (!strRespuesta.Equals("exito") && !strRespuesta.Equals("La venta ya no aparece en el servidor"))
                {
                    MessageBox.Show("No se pudo habilitar la venta movil en el servicio web para edicion: " + strRespuesta);
                    return false;
                }

                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo habilitar la venta movil en el servicio web para edicion  " + ex.Message);
                return false;
            }




        }



        private string getLastNChars(string sValue, int iMaxLength)
        { //Check if the value is valid
            if (string.IsNullOrEmpty(sValue))
            {
                //Set valid empty string as string could be null
                sValue = string.Empty;
            }
            else if (sValue.Length > iMaxLength)
            {
                //Make the string no longer than the max length
                sValue = sValue.Substring(sValue.Length - iMaxLength, iMaxLength);
            }

            //Return the string
            return sValue;
        }

        private void btEditarVenta_Click(object sender, EventArgs e)
        {

            if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 2)
            {
                MessageBox.Show("Aun no esta implementada esta caracteristica");
                return;
            }

            if (MessageBox.Show("¿Seguro quiere modificar la venta?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }


            CDOCTOD doctoD = new CDOCTOD();

            if (m_Docto.ITRASLADOAFTP == DBValues._DB_BOOLVALUE_SI)
            {
                if (!MovilPreeditarVenta())
                    return;

                m_Docto.ITRASLADOAFTP = DBValues._DB_BOOLVALUE_NO;

                if (!doctoD.CambiarEnviadoFTPDOCTOD(m_Docto, null))
                {
                    MessageBox.Show("No se pudo cambiar el estadus de enviado " + doctoD.IComentario);
                    return;
                }
            }

            if (doctoD.ReabrirDOCTOD(m_Docto, null))
            {

                CDOCTOBE doctoBuffer = m_Docto;
                IrANuevaVenta();

                CDOCTOD vData = new CDOCTOD();
                m_Docto = vData.seleccionarDOCTO(doctoBuffer, null);
                RefrescarGridVentas();

                if (m_manejaAlmacen)
                {
                    this.ALMACENComboBox.Enabled = false;
                    if (!(bool)m_Docto.isnull["IALMACENID"])
                        this.ALMACENComboBox.SelectedDataValue = m_Docto.IALMACENID;
                    else
                        this.ALMACENComboBox.SelectedIndex = -1;
                }

                llenarDatosGeneralesDocto();

                RefrescarEstatusBotones();
            }

        }

        private void btnCalculadora_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void TBPrecioCaja_KeyDown(object sender, KeyEventArgs e)
        {



        }

        private void TBPrecioCaja_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {

                CPRODUCTOBE prod = new CPRODUCTOBE();
                decimal cantidad = 0;
                bool bPreguntaCantidad = false;
                decimal precioCaja = 0;

                try
                {

                    precioCaja = Decimal.Parse(this.TBPrecioCaja.Text.ToString());
                    if (precioCaja <= 0)
                        return;
                }
                catch
                {
                    return;
                }


                CPuntoDeVentaD pvd = new CPuntoDeVentaD();
                if (TBCommandLine.Text != "")
                {
                    DecifrarComando(TBCommandLine.Text, ref prod, ref cantidad, ref bPreguntaCantidad, ref pvd);
                }
                if (prod == null)
                {
                    TBPrecioCaja.Text = "0.00";
                    return;
                }

                if (/*prod.IPZACAJA == null ||*/ prod.IPZACAJA <= 0)
                {
                    TBPrecioCaja.Text = "0.00";
                    return;
                }

                Decimal precioXPza = precioCaja / prod.IPZACAJA;
                TBPrecio.Text = precioXPza.ToString("N2");
                TBPrecioCaja.Text = "0.00";
                TBCantidad.Focus();

                TBDescuento.Text = "";

                try
                {
                    if (prod.IPRECIO1 > 0)
                    {
                        decimal precioLista = prod.IPRECIO1;
                        decimal descuento = 0;

                        if ((bool)CurrentUserID.CurrentParameters.isnull["IPRECIONETOENPV"] || !CurrentUserID.CurrentParameters.IPRECIONETOENPV.Equals("S"))
                        {
                            descuento = 100 - ((100 * precioXPza) / precioLista);

                        }
                        else
                        {
                            decimal dNuevoPrecio = calculaPrecioConImpuestos(precioLista, prod);

                            descuento = 100 - ((100 * precioXPza) / dNuevoPrecio);

                        }

                        TBDescuento.Text = descuento.ToString("N2");

                    }
                }
                catch
                {

                }


            }
        }


        private void coloreaRow(DataGridViewRow row)
        {
            string color = "";
            string color2 = "";
            

            bool bEsVentaPendienteDesdeMovil = m_Docto != null && m_Docto.IID != 0 && m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_BORRADOR && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA && m_Docto.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_VENDMOVIL;


            //if ((CurrentUserID.CurrentParameters.IESVENDEDORMOVIL == null || !CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
            //    && !bEsVentaPendienteDesdeMovil)
            //    return;
            


            if ((CurrentUserID.CurrentParameters.IESVENDEDORMOVIL != null && CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
                || bEsVentaPendienteDesdeMovil)
            {

                try
                {
                    if (row.Cells["DGALERTA"].Value != DBNull.Value)
                    {
                        color = row.Cells["DGALERTA"].Value.ToString().Trim();
                    }

                    if (row.Cells["DGALERTA2"].Value != DBNull.Value)
                    {
                        string buffer1 = row.Cells["DGALERTA2"].Value.ToString().Trim();

                        if (buffer1 == "PRECIO MAYOR A PRECIO1 Y PRECIO LISTA")
                            color2 = "NARANJA";
                        else if (buffer1 == "PRECIO MENOR A PRECIO MINIMO")
                            color2 = "ROJO";
                        else
                            color2 = "BLANCO";

                    }
                    

                    if (color == "ROJO")
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                    else if (color == "AMARILLO")
                    {
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else if (color == "MAGENTA")
                    {
                        row.DefaultCellStyle.BackColor = Color.DarkMagenta;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                    else if (color == "GRIS")
                    {
                        row.DefaultCellStyle.BackColor = Color.Gray;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = this.gridPVDataGridView.DefaultCellStyle.BackColor;
                        row.DefaultCellStyle.ForeColor = Color.Black;

                        if (color2 == "NARANJA")
                            row.Cells["DESCUENTOPORCENTAJE"].Style.ForeColor = Color.DarkOrange;
                        else if (color2 == "ROJO")
                            row.Cells["DESCUENTOPORCENTAJE"].Style.ForeColor = Color.DarkRed;
                        else
                            row.Cells["DESCUENTOPORCENTAJE"].Style.ForeColor = Color.Black;



                    }

                }
                catch
                {
                    row.DefaultCellStyle.BackColor = this.gridPVDataGridView.DefaultCellStyle.BackColor;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
            else if (m_Docto != null && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA && CurrentUserID.CurrentParameters.IPVCOLOREAR == DBValues._PVCOLOREAR_PRECIOMINIMO_COSTO)
            {
                try
                {
                    if (row.Cells["DGALERTA3COLOR"].Value != DBNull.Value)
                    {
                        color = row.Cells["DGALERTA3COLOR"].Value.ToString().Trim();
                    }

                    ponColorRowStandar(color, row);
                }
                catch
                {

                    row.DefaultCellStyle.BackColor = this.gridPVDataGridView.DefaultCellStyle.BackColor;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
            else if (m_Docto != null && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA_FUTURO)
            {

                try
                {
                    string colorCantidad = "";

                    bool bHayColorPorCantidad = false;

                    Color backC = this.gridPVDataGridView.DefaultCellStyle.BackColor;
                    Color foreC = this.gridPVDataGridView.DefaultCellStyle.ForeColor;


                    if (row.Cells["DGALERTAEXISTENCIACOLOR"].Value != DBNull.Value)
                    {
                        colorCantidad = row.Cells["DGALERTAEXISTENCIACOLOR"].Value.ToString().Trim();
                    }

                    if (colorCantidad == "ROJO")
                    {
                        backC = Color.FromArgb(255, 182, 102, 210);
                        foreC = Color.White;
                        bHayColorPorCantidad = true;
                    }
                    else if (colorCantidad == "AMARILLO")
                    {
                        backC = Color.Yellow;
                        foreC = Color.Black;
                        bHayColorPorCantidad = true;
                    }
                    else
                    {

                        backC = this.gridPVDataGridView.DefaultCellStyle.BackColor;
                        foreC = this.gridPVDataGridView.DefaultCellStyle.ForeColor;
                    }



                    string colorPrecio = "";

                    if (row.Cells["DGALERTA3COLOR"].Value != DBNull.Value)
                    {
                        colorPrecio = row.Cells["DGALERTA3COLOR"].Value.ToString().Trim();
                    }

                    if (colorPrecio == "ROJO")
                    {
                        if (bHayColorPorCantidad)
                        {
                            row.Cells["PRECIOUNIDAD"].Style.BackColor = Color.Red;
                            row.Cells["PRECIOUNIDAD"].Style.ForeColor = Color.White;
                            row.Cells["IMPORTE"].Style.BackColor = Color.Red;
                            row.Cells["IMPORTE"].Style.ForeColor = Color.White;
                        }
                        else
                        {

                            backC = Color.Red;
                            foreC = Color.White;

                            row.Cells["PRECIOUNIDAD"].Style.BackColor = backC;
                            row.Cells["PRECIOUNIDAD"].Style.ForeColor = foreC;
                            row.Cells["IMPORTE"].Style.BackColor = backC;
                            row.Cells["IMPORTE"].Style.ForeColor = foreC;
                        }
                    }
                    else if (colorPrecio == "AMARILLO")
                    {
                        if (bHayColorPorCantidad)
                        {
                            row.Cells["PRECIOUNIDAD"].Style.BackColor = Color.Yellow;
                            row.Cells["PRECIOUNIDAD"].Style.ForeColor = Color.Black;
                            row.Cells["IMPORTE"].Style.BackColor = Color.Yellow;
                            row.Cells["IMPORTE"].Style.ForeColor = Color.Black;
                        }
                        else
                        {

                            backC = Color.Yellow;
                            foreC = Color.Black;

                            row.Cells["PRECIOUNIDAD"].Style.BackColor = backC;
                            row.Cells["PRECIOUNIDAD"].Style.ForeColor = foreC;
                            row.Cells["IMPORTE"].Style.BackColor = backC;
                            row.Cells["IMPORTE"].Style.ForeColor = foreC;
                        }
                    }
                    else
                    {

                        if (bHayColorPorCantidad)
                        {
                            row.Cells["PRECIOUNIDAD"].Style.BackColor = backC;
                            row.Cells["PRECIOUNIDAD"].Style.ForeColor = foreC;
                            row.Cells["IMPORTE"].Style.BackColor = backC;
                            row.Cells["IMPORTE"].Style.ForeColor = foreC;
                        }
                        else
                        {


                            backC = this.gridPVDataGridView.DefaultCellStyle.BackColor;
                            foreC = this.gridPVDataGridView.DefaultCellStyle.ForeColor;

                            row.Cells["PRECIOUNIDAD"].Style.BackColor = backC;
                            row.Cells["PRECIOUNIDAD"].Style.ForeColor = foreC;
                            row.Cells["IMPORTE"].Style.BackColor = backC;
                            row.Cells["IMPORTE"].Style.ForeColor = foreC;
                        }
                    }


                    row.DefaultCellStyle.BackColor = backC;
                    row.DefaultCellStyle.ForeColor = foreC;



                }
                catch
                {

                    row.DefaultCellStyle.BackColor = this.gridPVDataGridView.DefaultCellStyle.BackColor;
                    row.DefaultCellStyle.ForeColor = this.gridPVDataGridView.DefaultCellStyle.ForeColor;
                }
            }




            //esto ocasiona un loop infinito por doble asignacion de color me imagino en el mismo evento
            /*if( CurrentUserID.CurrentParameters.IVERSIONTOPEID == 2 &&  
                (row.DefaultCellStyle.BackColor == this.gridPVDataGridView.DefaultCellStyle.BackColor ||
                 (color == null || color.Trim().Equals("") || color.Trim().ToUpper().Equals("BLANCO"))
                )
             )
            {

                try
                {
                    if (row.Cells["DGREBAJACOLOR"].Value != DBNull.Value)
                    {
                        color = row.Cells["DGREBAJACOLOR"].Value.ToString().Trim();
                    }
                    ponColorRowStandar(color, row);
                }
                catch
                {

                }
            }*/
        }

        private void ponColorRowStandar(string color , DataGridViewRow row)
        {
            if (color == "ROJO")
            {
                row.DefaultCellStyle.BackColor = Color.Red;
                row.DefaultCellStyle.ForeColor = Color.White;
            }
            else if (color == "AMARILLO")
            {
                row.DefaultCellStyle.BackColor = Color.Yellow;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }
            else
            {

                row.DefaultCellStyle.BackColor = this.gridPVDataGridView.DefaultCellStyle.BackColor;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void gridPVDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            coloreaRow(gridPVDataGridView.Rows[e.RowIndex]);
        }

        private void gridPVDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
            {
                if (e.RowIndex != gridPVDataGridView.NewRowIndex)
                {
                    string strDescripcion = gridPVDataGridView.Rows[e.RowIndex].Cells["DGDESCRIPCION"].Value.ToString();

                    if (strDescripcion == null)
                        strDescripcion = "";
                    if (strDescripcion.Length > 12)
                        strDescripcion = strDescripcion.Substring(0, 12);

                    TBCommandLine.Text = strDescripcion;

                    if (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
                    {
                        TBCommandLine.Focus();
                        if (TBCommandLine.Text.Length > 0)
                        {
                            TBCommandLine.SelectionStart = TBCommandLine.Text.Length - 1;
                            TBCommandLine.SelectionLength = 0;
                        }
                    }

                }
            }
        }





        private void PonerPrecioPorDescuento()
        {

            if (!this.m_bPermisoCambiarPrecioxLista && !this.m_bPermisoCambiarPrecio)
            {
                return;
            }


            CPRODUCTOBE prod = null;
            decimal cantidad = 0;

            bool bPreguntaCantidad = false;


            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            if (TBCommandLine.Text == "")
            {
                return;
            }

            DecifrarComando(TBCommandLine.Text, ref prod, ref cantidad, ref bPreguntaCantidad, ref pvd);

            if (prod != null)
            {

                int? productoId = (int?)prod.IID;
                int? clienteId = (int?)this.m_ClienteId;
                int? personaId = (int?)CurrentUserID.CurrentUser.IID;
                int? tipoDoctoId = (int?)m_Docto.ITIPODOCTOID;
                int? sucursalId = (int?)CurrentUserID.CurrentParameters.ISUCURSALID;
                //int? sucursalTId = null;



                decimal? precioLista = null;
                //decimal? precioTraspaso = null;
                //decimal? precioMinimo = null;
                //decimal? costo = null;

                decimal tipoCambio = (((bool)m_Docto.isnull["ITIPOCAMBIO"] || m_Docto.ITIPOCAMBIO == 0) ? 1 : m_Docto.ITIPOCAMBIO);
                decimal P_DESCUENTO = decimal.Parse(TBDescuento.Text);

                decimal precioXPza = 0;

                if (cantidad == 0)
                    cantidad = 1;

                /*if (pvd.GET_PRECIOS_PRODUCTO_LISTA(productoId, clienteId, cantidad, sucursalTId, ref  precioLista, ref precioTraspaso, ref  precioMinimo, ref  costo, null))
                {*/
                if (prod.IPRECIO1 > 0)
                {
                    precioLista = prod.IPRECIO1;

                    if ((bool)CurrentUserID.CurrentParameters.isnull["IPRECIONETOENPV"] || !CurrentUserID.CurrentParameters.IPRECIONETOENPV.Equals("S"))
                    {

                        precioXPza = ((precioLista.Value / tipoCambio) * ((100 - P_DESCUENTO) / 100));
                        TBPrecioCaja.Text = (precioXPza * prod.IPZACAJA).ToString("N2");

                        this.TBPrecio.Text = precioXPza.ToString();
                    }
                    else
                    {
                        decimal dNuevoPrecio = calculaPrecioConImpuestos(precioLista.Value, prod);

                        precioXPza = ((dNuevoPrecio / tipoCambio) * ((100 - P_DESCUENTO) / 100));
                        TBPrecioCaja.Text = (precioXPza * prod.IPZACAJA).ToString("N2"); ;

                        this.TBPrecio.Text = ((dNuevoPrecio / tipoCambio) * ((100 - P_DESCUENTO) / 100)).ToString("N2");
                    }



                }
                else
                {
                    this.TBPrecio.Text = "0";
                    TBPrecioCaja.Text = "0";
                }

                /*

                        }
                        else
                        {

                        }*/


            }
        }


       

        private void gridPVDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((m_estadoVenta == (int)estadoVenta.e_Cancelada || m_estadoVenta == (int)estadoVenta.e_Cerrada))
                return;

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

                        if (!unidad.Equals("PZA") && !unidad.Equals("BOT"))
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

                            TBCommandLine.Focus();
                        }


                        if (bHuboCambio)
                        {

                            dNuevaCantidad = dCantidadTotalFinal;

                            decimal dEntrada = dNuevaCantidad - dViejaCantidad;
                            if (dEntrada == 0)
                                return;

                            if(dEntrada < 0)
                            {
                                if (!checarAutorizacionEliminarODisminuirDetalle())
                                    return;
                            }

                            if (/*dNuevaCantidad <= 0*/ Math.Round(dNuevaCantidad, numeroDecimales) <= 0)
                            {
                                MessageBox.Show("La cantidad  no puede ser menor o igual a cero, si requiere cancelar el detalle porfavor seleccione 'Eliminar detalle'");
                                TBCommandLine.Focus();
                                return;
                            }
                            else
                            {


                                CPRODUCTOBE prodBE = new CPRODUCTOBE();
                                CPRODUCTOD prodD = new CPRODUCTOD();
                                prodBE.IID = long.Parse(gridPVDataGridView.Rows[e.RowIndex].Cells["DGPRODUCTOID"].Value.ToString());
                                prodBE = prodD.seleccionarPRODUCTO(prodBE, null);
                                decimal dNuevoPrecio = decimal.Parse(gridPVDataGridView.Rows[e.RowIndex].Cells["PRECIOUNIDAD"].Value.ToString());
                                /*decimal dTasaIva = 0;
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
                                }*/

                                decimal dPrecioSinIva;
                                if ((bool)CurrentUserID.CurrentParameters.isnull["IPRECIONETOENPV"] || !CurrentUserID.CurrentParameters.IPRECIONETOENPV.Equals("S"))
                                    dPrecioSinIva = calculaPrecioSinImpuestos(dNuevoPrecio, prodBE);//(dNuevoPrecio / (1 + (dTasaIva / 100))) / (1 + (dTasaIeps / 100));
                                else
                                    dPrecioSinIva = dNuevoPrecio;

                                decimal dDescuentoManual = 0;
                                try
                                {
                                    dDescuentoManual = decimal.Parse(gridPVDataGridView.Rows[e.RowIndex].Cells["PORCENTAJEDESCUENTOMANUAL"].Value.ToString());
                                }
                                catch
                                {
                                    dDescuentoManual = 0;
                                }


                                bool bHaIngresadoPrecioManual = true;
                                try
                                {
                                    string strHaIngresadoPrecioManual = gridPVDataGridView.Rows[e.RowIndex].Cells["DGINGRESOPRECIOMANUAL"].Value.ToString();
                                    bHaIngresadoPrecioManual = strHaIngresadoPrecioManual != null && strHaIngresadoPrecioManual.Trim().ToUpper().Equals("S");

                                }
                                catch
                                {
                                    bHaIngresadoPrecioManual = true;
                                }



                                if (bEstaConfiguradoParaPiezasyCajas())
                                {
                                    TBCommandLine.Text = gridPVDataGridView.Rows[e.RowIndex].Cells["GVCLAVEPRODUCTO"].Value.ToString();
                                    TBCajas.Text = "0";
                                    TBCantidad.Text = dEntrada.ToString("N3");
                                }
                                else
                                {
                                    TBCommandLine.Text = dEntrada.ToString("N3") + "*" + gridPVDataGridView.Rows[e.RowIndex].Cells["GVCLAVEPRODUCTO"].Value.ToString();
                                }

                                TBPrecio.Text = dPrecioSinIva.ToString("0.00");
                                TBDescuento.Text = formateaDescuento(gridPVDataGridView.Rows[e.RowIndex].Cells["DESCUENTOPORCENTAJE"].Value.ToString());


                                long? P_MOVTOID = (long)gridPVDataGridView.Rows[e.RowIndex].Cells["MOVTOID"].Value;




                                bool bRes = false;

                                if (!bHaIngresadoPrecioManual)
                                    bRes = ProcessCommand(true, false, P_MOVTOID, (dDescuentoManual == 0), true,true);
                                else
                                    bRes = dDescuentoManual == 0 ? ProcessCommand(false, false, P_MOVTOID, true, true, true) : ProcessCommand(true, false, P_MOVTOID, false, true, true);





                                //  bool bRes = dDescuentoManual == 0 ? ProcessCommand(false, false, P_MOVTOID, true) : ProcessCommand(true, false, P_MOVTOID, false);

                                if (!bRes)
                                {
                                    //gridPVDataGridView.Rows[e.RowIndex].Cells["GVCANTIDAD"].Value = dViejaCantidad;
                                    //gridPVDataGridView.EditingControl.Text = Convert.ToString(dViejaCantidad);

                                    TBCommandLine.Text = "";
                                    TBPrecio.Text = "";
                                    TBDescuento.Text = "";
                                    this.TBPrecioCaja.Text = "";

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

        private void btnAdjunto_Click(object sender, EventArgs e)
        {


            AdjuntarDetalle();

        }

        private void AdjuntarDetalle()
        {
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            CMOVTOBE movtoBE = new CMOVTOBE();

            if (this.gridPVDataGridView.Rows.Count <= 0)
                return;



            if (this.gridPVDataGridView.CurrentRow.Index != this.gridPVDataGridView.NewRowIndex)
            {
                DataGridViewRow dr = this.gridPVDataGridView.CurrentRow;
                DataRow movtoDataRow = (dr.DataBoundItem as DataRowView).Row;


                bool bPermitirCambios = !(m_estadoVenta == (int)estadoVenta.e_Cerrada || m_estadoVenta == (int)estadoVenta.e_Cancelada);

                WFAdjuntarProductos wf = new WFAdjuntarProductos(movtoDataRow, bPermitirCambios);
                wf.ShowDialog();
                wf.Dispose();
                GC.SuppressFinalize(wf);

                RefrescarGridVentas();
            }
            RefrescarEstatusBotones();
            this.TBCommandLine.Focus();

        }

        private void btnListaAdjuntos_Click(object sender, EventArgs e)
        {
            bool bPermitirEliminaciones = !(m_estadoVenta == (int)estadoVenta.e_Cerrada || m_estadoVenta == (int)estadoVenta.e_Cancelada);
            iPos.Movil.WFListaAdjuntos wf = new Movil.WFListaAdjuntos(m_Docto.IID, bPermitirEliminaciones);
            wf.ShowDialog();
            wf.Dispose();
            GC.SuppressFinalize(wf);
        }

        private void btnCobranzaMovil_Click(object sender, EventArgs e)
        {
            WFCobranzaMovil wf = new WFCobranzaMovil(false, TBCliente.Text);
            wf.ShowDialog();
            wf.Dispose();
            GC.SuppressFinalize(wf);
        }

        private void btnClearCommand_Click(object sender, EventArgs e)
        {
            this.TBCommandLine.Text = "";
            this.TBCantidad.Text = (bEstaConfiguradoParaPiezasyCajas()) ? "0" : "1";
            this.TBCajas.Text = "0";
            this.TBPrecio.Text = "";
            this.TBDescuento.Text = "";
            this.TBPrecioCaja.Text = "";
            TBCommandLine.Focus();
        }





        /*
         * 
         * 
         *
        private void TBCommandLine_KeyUp_1(object sender, KeyEventArgs e)
        {


            if (CurrentUserID.CurrentParameters.IAUTOCOMPPROD.Equals("S") && CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
            {
                if (e.KeyCode != System.Windows.Forms.Keys.Tab && e.KeyCode != System.Windows.Forms.Keys.Enter && e.KeyCode != System.Windows.Forms.Keys.Down)
                    fillAutoCompleteProducto();
                else if (e.KeyCode == System.Windows.Forms.Keys.Down)
                {
                    if (lstProductoComplete.Items.Count > 0)
                    {
                        lstProductoComplete.SelectedIndex = 0;
                        lstProductoComplete.Visible = true;
                        lstProductoComplete.Focus();

                    }
                }

            }
            else
            {
                lstProductoComplete.Visible = false;
            }
        }


         */


        private void lstProductoComplete_MouseClick(object sender, MouseEventArgs e)
        {
            int index = this.lstProductoComplete.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                TBCommandLine.Text = this.lstProductoComplete.Items[index].ToString();
                TBCommandLine.Focus();
                this.lstProductoComplete.Visible = false;
            }
        }

        private void lstProductoComplete_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                if (this.lstProductoComplete.SelectedIndex >= 0)
                {
                    TBCommandLine.Text = this.lstProductoComplete.SelectedItem.ToString();
                    TBCommandLine.Focus();
                    this.lstProductoComplete.Visible = false;
                }
            }
        }


        private void lstProductoComplete_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 40;
        }


        private void lstProductoComplete_DrawItem(object sender, DrawItemEventArgs e)
        {
            // If the item is the selected item, then draw the rectangle 
            // filled in blue. The item is selected when a bitwise And   
            // of the State property and the DrawItemState.Selected  
            // property is true. 
            Boolean bSelected = false;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.Bounds);
                bSelected = true;
            }
            else
            {
                // Otherwise, draw the rectangle filled in beige.
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);
            }

            // Draw a rectangle in blue around each item.
            //e.Graphics.DrawRectangle(Pens.Blue, e.Bounds);

            // Draw the text in the item.
            e.Graphics.DrawString(this.lstProductoComplete.Items[e.Index].ToString(),
                this.lstProductoComplete.Font, bSelected ? Brushes.White : Brushes.Black, e.Bounds.X, e.Bounds.Y);

            // Draw the focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }



        private void fillAutoCompleteProducto()
        {
            lstProductoComplete.Items.Clear();

            if (TBCommandLine.Text.Trim().Length != 0)
            {

                String strSearch = TBCommandLine.Text.Trim();
                AutoCompleteStringCollection collection = CurrentUserID.GetAutoSourceCollectionFromTable();
                foreach (String str in collection)
                {
                    if (str.StartsWith(strSearch, true, null))
                    {
                        lstProductoComplete.Items.Add(str);
                    }
                }
            }

            lstProductoComplete.Visible = (lstProductoComplete.Items.Count > 0);
            lstProductoComplete.Size = new Size(lstProductoComplete.Size.Width, (lstProductoComplete.Items.Count > 0) ? 300 : 0);

        }

        private void btnNoTransaccion_Click(object sender, EventArgs e)
        {
            WFSelectTransByFolio wf = new WFSelectTransByFolio();
            wf.ShowDialog();
            string strSucDest = "";

            if (wf.m_selectedDocto != null && wf.m_selectedDocto.IID > 0)
            {
                if (wf.m_selectedDocto.ISUCURSALTID > 0 && wf.m_selectedDocto.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO || wf.m_selectedDocto.ITIPODOCTOID == DBValues._DOCTO_TIPO_PEDIDO_TRASPASO_SALIDA)
                {
                    CSUCURSALD sucursalD = new CSUCURSALD();
                    CSUCURSALBE sucursalBE = new CSUCURSALBE();

                    sucursalBE.IID = wf.m_selectedDocto.ISUCURSALTID;
                    sucursalBE = sucursalD.seleccionarSUCURSAL(sucursalBE, null);

                    if (sucursalBE != null)
                        strSucDest = sucursalBE.ICLAVE;
                }
                AbrirVentasCerradasYDevoluciones((int)wf.m_selectedDocto.IID, strSucDest);
            }
            wf.Dispose();
            GC.SuppressFinalize(wf);
        }

        private void btDomicilioEntrega_Click(object sender, EventArgs e)
        {
            if (m_Docto != null && m_Docto.IID != 0 /*&& m_Docto.IPERSONAID == 1*/ && m_Docto.IESTATUSDOCTOID == 0)
            {
                WFClienteEntrega wf = new WFClienteEntrega(m_Docto.IPERSONAAPARTADOID);
                wf.ShowDialog();

                if (wf.m_bAplicar && wf.m_personaApartadoId != 0)
                {
                    CDOCTOD doctoD = new CDOCTOD();
                    m_Docto.IPERSONAAPARTADOID = wf.m_personaApartadoId;
                    if (!doctoD.CambiarPersonaApartadoId(m_Docto, m_Docto, null))
                    {
                        m_Docto.IPERSONAAPARTADOID = 0;
                        MessageBox.Show("No se pudo asignar los datos de entrega " + doctoD.IComentario);
                    }
                    else
                    {
                        m_Docto.IESSERVDOMICILIO = "S";
                        if(!doctoD.CambiarESSERVDOMICILIO(m_Docto,null))
                        {
                            m_Docto.IESSERVDOMICILIO = "N";
                            MessageBox.Show("No se pudo asignar como servicio a domicilio " + doctoD.IComentario);
                        }


                        llenarDatosCliente();
                      
                    }
                }
                wf.Dispose();
                GC.SuppressFinalize(wf);

            }
        }

        private void btnFecha_Click(object sender, EventArgs e)
        {
            if (m_Docto != null && m_Docto.IID != 0)
            {
                WFCambiarFechaPendMax wf = new WFCambiarFechaPendMax(m_Docto);
                wf.ShowDialog();

                if (wf.bCambioFechaPendMax)
                {
                    m_Docto.IPENDMAXFECHA = wf.m_DoctoBE.IPENDMAXFECHA;
                }
                wf.Dispose();
                GC.SuppressFinalize(wf);
            }
        }

        private void TBCliente_Validating(object sender, CancelEventArgs e)
        {


        }

        private void TBCliente_Validated(object sender, EventArgs e)
        {
            if (TBCliente.Text.Trim().Length == 0)
                return;

            CPERSONAD personaD = new CPERSONAD();
            CPERSONABE personaBE = new CPERSONABE();
            personaBE.ITIPOPERSONAID = DBValues._TIPOPERSONA_CLIENTE;
            personaBE.ICLAVE = TBCliente.Text;

            personaBE = personaD.seleccionarPERSONAxCLAVEyTIPO(personaBE, null);
            if (personaBE == null)
            {
                MessageBox.Show("No existe ese cliente");
                TBCliente.Focus();
                return;
            }

            Catalogos.DSCatalogos dscat = new Catalogos.DSCatalogos();
            Catalogos.DSCatalogos.CLIENTE_VIEWRow row = dscat.CLIENTE_VIEW.NewCLIENTE_VIEWRow();
            row.ID = personaBE.IID;
            row.BLOQUEADO = personaBE.IBLOQUEADO;
            row.BLOQUEONOT = personaBE.IBLOQUEONOT;
            row.LIMITECREDITO = personaBE.ILIMITECREDITO;
            row.STATUSSALDO = personaBE.IBLOQUEADO == "N" && personaBE.ILIMITECREDITO + personaBE.ISALDO < 0 ? "EXCEDIDO" : "DISPONIBLE";
            row.CLAVE = personaBE.ICLAVE;
            row.ID = personaBE.IID;

            ProcesaCambioCliente(row);
            dscat.Dispose();
        }

        private void TBCommandLine_Validating(object sender, CancelEventArgs e)
        {
            CPRODUCTOBE prod = new CPRODUCTOBE();
            this.TBStatus.Text = prod.INOMBRE + " // " + prod.IDESCRIPCION + " // " + prod.IDESCRIPCION1;

        }

        private void gridPVDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }



        private string CambiarPAGOACREDITO()
        {
            if (m_Docto == null || (bool)m_Docto.isnull["IID"])
                return "No hay docto activo";

            CDOCTOD doctoD = new CDOCTOD();
            m_Docto.IPAGOACREDITO = CBACredito.Checked ? "S" : "N";

            if (!doctoD.CambiarPAGOACREDITO(m_Docto, null))
            {
                return doctoD.IComentario;
            }

            RecalcularDetalles();
            return "S";

        }


        private string CambiarContado()
        {
            if (m_Docto == null || (bool)m_Docto.isnull["IID"] )
                return "No hay docto activo";

            if (m_Docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_BORRADOR)
                return "El docto debe estar en estatus borrador";

            CDOCTOD doctoD = new CDOCTOD();
            m_Docto.IMOVILCONTADO = CBContado.Checked ? "S" : "N";

            if (!doctoD.CambiarMOVILCONTADO(m_Docto, null))
            {
                return doctoD.IComentario;
            }
            
            return "S";

        }


        private string CambiarEsVentaEspecial()
        {
            if (m_Docto == null || (bool)m_Docto.isnull["IID"])
                return "No hay docto activo";

            if (m_Docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_BORRADOR)
                return "El docto debe estar en estatus borrador";

            CDOCTOD doctoD = new CDOCTOD();
            m_Docto.IESVENTAESPECIAL = CBEspecial.Checked ? "S" : "N";

            if (!doctoD.CambiarESVENTAESPECIAL(m_Docto, null))
            {
                return doctoD.IComentario;
            }

            return "S";

        }


        private string CambiarCotiEnrutada()
        {
            if (m_Docto == null || (bool)m_Docto.isnull["IID"])
                return "No hay docto activo";

            if (m_Docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_BORRADOR)
                return "El docto debe estar en estatus borrador";

            CDOCTOD doctoD = new CDOCTOD();
            m_Docto.ICOTI_ENRUTADA = CBCotizacionEnrutada.Checked ? "S" : "N";

            if (!doctoD.CambiarCOTI_ENRUTADA(m_Docto, null))
            {
                return doctoD.IComentario;
            }


            if (!(bool)CurrentUserID.CurrentParameters.isnull["IHABSURTIDOPOSTMOVIL"] && CurrentUserID.CurrentParameters.IHABSURTIDOPOSTMOVIL.Equals("S"))
            {
                if(CBCotizacionEnrutada.Checked)
                {
                    m_Docto.IESTADOSURTIDOID = DBValues._DOCTO_SURTIDOESTADO_CXC;
                }
                else
                {
                    m_Docto.IESTADOSURTIDOID = 0;
                }
                if (!doctoD.CambiarESTADOSURTIDOID(m_Docto, null))
                {
                    return doctoD.IComentario;
                }

            }

            return "S";

        }


        private string SETESTADOREBAJA_COTIENRUTADA(long movtoId)
        {
            if (m_Docto == null || (bool)m_Docto.isnull["IID"])
                return "No hay docto activo";

            if (m_Docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_BORRADOR)
                return "El docto debe estar en estatus borrador";

            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            

            if (!pvd.SETESTADOREBAJA_COTIENRUTADA(m_Docto.IID, movtoId, null))
            {
                return pvd.IComentario;
            }

            
            return "S";

        }

        private string CambiarASubtipoDoctoStandSiEsNecesario(FbTransaction trans)
        {
            if (m_Docto == null || (bool)m_Docto.isnull["IID"])
                return "No hay docto activo";

            if (m_Docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_BORRADOR)
                return "El docto debe estar en estatus borrador";

            if(m_Docto.ITIPODOCTOID != DBValues._DOCTO_TIPO_VENTA)
                return "El docto debe ser tipo venta";

            CDOCTOD doctoD = new CDOCTOD();


            if (!doctoD.DOCTO_ASIGNAR_FOLIO(m_Docto, trans))
            {
                return  "Hubo un error al asignar el folio ";
            }

            m_Docto.ISUBTIPODOCTOID = DBValues._DOCTO_SUBTIPO_STAND;

            if (!doctoD.CambiarSubtipoDoctoD(m_Docto, trans))
            {
                return doctoD.IComentario;
            }

            return "S";

        }




        private string CambiarEsFacturaElectronica()
        {
            if (m_Docto == null || (bool)m_Docto.isnull["IID"])
                return "No hay docto activo";

            if (m_Docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_BORRADOR)
                return "El docto debe estar en estatus borrador";

            CDOCTOD doctoD = new CDOCTOD();
            m_Docto.IESFACTURAELECTRONICA = CBFactura.Checked ? "S" : "N";

            if (!doctoD.CambiarESFACTURAELECTRONICA(m_Docto, null))
            {
                return doctoD.IComentario;
            }

            return "S";

        }

        private string CambiarObservaciones()
        {
            if (m_Docto == null || (bool)m_Docto.isnull["IID"])
                return "No hay docto activo";

            if (m_Docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_BORRADOR)
                return "El docto debe estar en estatus borrador";

            CDOCTOD doctoD = new CDOCTOD();
            m_Docto.IOBSERVACIONES = ObservacionesTextBox.Text;

            if (!doctoD.CambiarObservaciones(m_Docto, m_Docto, null))
            {
                return doctoD.IComentario;
            }

            return "S";

        }



        private string CambiarEnDoctoPagoConTarjeta()
        {
            if (m_Docto == null || (bool)m_Docto.isnull["IID"])
                return "No hay docto activo";

            CDOCTOD doctoD = new CDOCTOD();
            m_Docto.IPAGOCONTARJETA = CBXPagoConTarjeta.SelectedIndex == 1  ? "S" :
                                            CBXPagoConTarjeta.SelectedIndex == 2 ? "C":
                                                CBXPagoConTarjeta.SelectedIndex == 3 ? "D" : "N";
            m_Docto.ICOMISIONPAGOTARJETA = CurrentUserID.CurrentParameters.ICOMISIONPORTARJETA;
            m_Docto.ICOMISIONPAGOTARJETADEB = CurrentUserID.CurrentParameters.ICOMISIONDEBPORTARJETA;

            if (!doctoD.CambiarPAGOCONTARJETADOCTOD(m_Docto, null))
            {
                return doctoD.IComentario;
            }

            RecalcularDetalles();
            return "S";

        }

        private void CBPagoConTarjeta_CheckedChanged(object sender, EventArgs e)
        {

            if (m_bLlenandoDoctoDatosGenerales)
                return;

            if (CBXPagoConTarjeta.SelectedIndex == 0 && (m_Docto == null || (bool)m_Docto.isnull["IID"]))
                return;

            m_vigilarPagoConTarjeta = false;

            if (CBXPagoConTarjeta.SelectedIndex == 1 && 
                        CurrentUserID.CurrentParameters.ICOMISIONDEBPORTARJETA != CurrentUserID.CurrentParameters.ICOMISIONPORTARJETA)
            {
                MessageBox.Show("Como la comision por tarjeta es diferente en debito y credito, debe especificar si la tarjeta es de credito o debito");
                m_vigilarPagoConTarjeta = true;
                CBXPagoConTarjeta.Focus();
                return;
            }


            if (m_Docto == null || (bool)m_Docto.isnull["IID"])
                bActualizarPrecioDespuesDeCrearDocto = true;
            else
            {
                string strCambioPagoTarj = CambiarEnDoctoPagoConTarjeta();
                if (!strCambioPagoTarj.Equals("S"))
                {
                    MessageBox.Show(strCambioPagoTarj);
                }
            }


        }


        private void CBACredito_CheckedChanged(object sender, EventArgs e)
        {

            if (m_bLlenandoDoctoDatosGenerales)
                return;

            if (!CBACredito.Checked && (m_Docto == null || (bool)m_Docto.isnull["IID"]))
                return;

            if (m_Docto == null || (bool)m_Docto.isnull["IID"])
                bActualizarPrecioPorCreditoDespuesDeCrearDocto = true;

            else
            {
                string strCambioPagoACredito = this.CambiarPAGOACREDITO();
                if (!strCambioPagoACredito.Equals("S"))
                {
                    MessageBox.Show(strCambioPagoACredito);
                }
            }


        }

        private void RecalcularDetalles()
        {

            CDOCTOD doctoD = new CDOCTOD();
            if (!doctoD.DOCTO_RECALCULAR_DETALLES(m_Docto, null))
                MessageBox.Show(doctoD.IComentario);
            else
            {
                //recalcula promocion por monto si aplica
                string comentario = "";
                RecalcularPromocionMontoMinSiAplica(ref comentario, null);


                RefrescarGridVentas();
            }
        }


        private bool RecalcularPromocionMontoMinSiAplica(ref string comentario, FbTransaction fTrans)
        {

            if (CurrentUserID.CurrentParameters.IHABPROMOXMONTOMIN != null && CurrentUserID.CurrentParameters.IHABPROMOXMONTOMIN.Equals("S") &&
                m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA && m_Docto.ISUBTIPODOCTOID == 0)
            {

                string huboMovimientos = "N";
                CDOCTOD doctoD = new CDOCTOD();
                if (!doctoD.DOCTO_RECALCULAR_PROMOMONTOMIN(m_Docto, ref huboMovimientos, fTrans))
                {
                    comentario = doctoD.IComentario;
                    return false;
                }

                if (huboMovimientos.Equals("S"))
                {
                    this.ObtenerDoctoDeBD(m_Docto.IID, fTrans);
                }
            }

            return true;
        }

        private void btnVentaAFuturo_Click(object sender, EventArgs e)
        {

            if (btnVentaAFuturo.Text == "Venta a futuro")
            {
                ModoVentaAFuturo();
            }
            else if (btnVentaAFuturo.Text == "Convertir a venta")
            {
                ConvertirACotizacion();
            }
        }


        private void ModoVentaAFuturo()
        {

            NuevoRegistro();

            m_Docto.ITIPODOCTOID = DBValues._DOCTO_TIPO_VENTA_FUTURO;
            PonerVariablesModoVentaAFuturo();
        }

        private void PonerVariablesModoVentaAFuturo()
        {

            this.LBOperacion.Text = "Venta a futuro";
            this.BTPasarANueva.Enabled = true;
            this.BTPasarANueva.ForeColor = Color.Black;
            this.BTPasarANueva.BackColor = Color.FromArgb(41, 121, 255);

            this.btnNuevaApartado.Enabled = false;
            this.BTPagarConVale.Enabled = false;

            btnVentaAFuturo.Text = "Convertir a venta";

            this.CBCotizacionEnrutada.Visible = false;
        }





        private void ConvertirACotizacion()
        {

            CMOVTOD objRecD = new CMOVTOD();
            CMOVTOBE objRecBE = new CMOVTOBE();

            CDOCTOD objDoctoD = new CDOCTOD();
            CDOCTOBE objDoctoBE = new CDOCTOBE();


            CPRODUCTOD objProductoD = new CPRODUCTOD();
            CPRODUCTOBE objProductoBE = new CPRODUCTOBE();

            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            bool bRes = false;

            long newDoctoId = 0;

            string strProductosSinExistenciaSuficiente = "";

            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                foreach (DSPuntoDeVentaAux2.GRIDPVRow row in dSPuntoDeVentaAux2.GRIDPV)
                {

                    objRecBE = new CMOVTOBE();
                    objRecBE.IID = row.MOVTOID;

                    decimal existencia = (row.IsEXISTENCIANull() ? 0 : row.EXISTENCIA);
                    decimal cantidad = (row.IsCANTIDADNull() ? 0 : row.CANTIDAD);
                    decimal cantidadSurtida = (row.IsCANTIDADSURTIDANull() ? 0 : row.CANTIDADSURTIDA);
                    decimal cantidadRequerida = cantidad - cantidadSurtida;


                    objRecBE.ICANTIDADSURTIDA = existencia > cantidadRequerida ? cantidadRequerida : existencia;

                    if (objRecBE.ICANTIDADSURTIDA <= 0)
                        continue;

                    objRecBE.IPRODUCTOID = row.PRODUCTOID;
                    //objRecBE.ICANTIDAD = Decimal.Parse(row.Cells["GC_CANTIDAD"].Value.ToString());

                    if (newDoctoId > 0)
                    {
                        objRecBE.IDOCTOID = newDoctoId;
                    }


                    objProductoBE = new CPRODUCTOBE();
                    objProductoBE.IID = objRecBE.IPRODUCTOID;
                    objProductoBE = objProductoD.seleccionarPRODUCTO(objProductoBE, null);

                    if (objRecBE == null)
                    {
                        continue;
                    }



                    if (objProductoBE.IMANEJALOTE != null && objProductoBE.IMANEJALOTE.Equals("S"))
                    {
                        try
                        {
                            objRecBE.ILOTE = row.IsLOTENull() ? "" : row.LOTE;
                        }
                        catch
                        {
                            objRecBE.ILOTE = "";
                        }


                        try
                        {
                            if (!row.IsFECHAVENCENull())
                                objRecBE.IFECHAVENCE = row.FECHAVENCE;
                        }
                        catch
                        {
                        }

                        if (objRecBE.ILOTE.Trim().Length == 0 && objRecBE.ICANTIDADSURTIDA > 0)
                        {
                            MessageBox.Show("Debe asignar lote al producto " + row.DESCRIPCION);
                            fConn.Close();
                            return;
                        }
                    }



                    objRecBE.ITIPODIFERENCIAINVENTARIOID = 0;


                    if (objRecBE.ICANTIDADSURTIDA != 0)
                    {
                        long movtoRefId = row.IsMOVTOIDNull() ? 0 : row.MOVTOID;
                        string sProblemaConExis = "N";
                        if (objDoctoD.VENTAFUTUROAPLICAR_COPYMOVTO(ref objRecBE, movtoRefId, CurrentUserID.CurrentUser.IID, m_Docto.IID, ref sProblemaConExis, fTrans) == false)
                        {

                            fTrans.Rollback();
                            fConn.Close();
                            MessageBox.Show(objDoctoD.IComentario);
                            return;
                        }

                        if (sProblemaConExis == "S")
                        {
                            strProductosSinExistenciaSuficiente += " " + row.DESCRIPCION + " ";
                        }

                        newDoctoId = objRecBE.IDOCTOID;



                    }
                }

                if (strProductosSinExistenciaSuficiente != null && strProductosSinExistenciaSuficiente.Trim().Length > 0)
                {
                    fTrans.Rollback();
                    fConn.Close();
                    MessageBox.Show("Hay problemas con existencias en los siguientes productos : " + strProductosSinExistenciaSuficiente);
                    return;
                }


                fTrans.Commit();
                fConn.Close();

                if (newDoctoId != 0)
                {

                    IrANuevaVenta();
                    AbrirVentaXId(newDoctoId);
                    RefrescarEstatusBotones();
                    predoctoId = 0;
                }


                /*
                objDoctoBE.IID = newDoctoId;
                if (!objDoctoD.VENTAFUTUAPL_PRECOMPLETAR(objDoctoBE, fTrans))
                {


                    fTrans.Rollback();
                    fConn.Close();
                    MessageBox.Show(objDoctoD.IComentario);
                    return;
                }

                fTrans.Commit();
                fConn.Close();


                

                objDoctoBE.IID = newDoctoId;
                objDoctoBE = objDoctoD.seleccionarDOCTO(objDoctoBE, null);

                if (objDoctoBE == null)
                {
                    MessageBox.Show("La venta no fue guardada");
                    return;
                }


                CPuntoDeVentaD pvd = new CPuntoDeVentaD();
                CCAJABE caja = pvd.ObtenerDatosCaja(iPos.CurrentUserID.CurrentCompania.IEM_CAJA);

                WFPagosBasico wp = new WFPagosBasico(objDoctoBE, caja, false, 0, null, tipoTransaccionV.t_venta, "N", null, false, false, 0, 0);
                wp.m_bCerrarVentaFuturoAplicada = true;
                wp.m_bCerrarTraspasoSalida = false;
                wp.m_bCerrarVenta = false;
                wp.m_bMantenerVentaFuturoAbierta = CBMantenerAbierta.Checked;
                wp.ShowDialog();

                bool bAlreadyClosedInDB = true;
                bool generarFacturaElectronica = (wp.m_generarFacturaElectronica && !wp.m_surtidoPostpuesto);


                if (wp.m_bPagoCompleto)
                {



                    objDoctoBE.IID = newDoctoId;
                    objDoctoBE.IOBSERVACION = TBObservaciones.Text;

                    objDoctoBE.IREFERENCIAS = "";
                    objDoctoBE.IVENDEDORID = CurrentUserID.CurrentUser.IID;



                    if (!bAlreadyClosedInDB)
                    {


                        fConn.Open();
                        fTrans = fConn.BeginTransaction();

                        bRes = objDoctoD.VENTAFUTUROAPLICACION_COMPLETAR(objDoctoBE, CBMantenerAbierta.Checked, fTrans);

                        if (bRes == false)
                        {
                            fTrans.Rollback();
                            fConn.Close();

                            pvd.CancelarVenta(objDoctoBE, CurrentUserID.CurrentUser, null);

                            MessageBox.Show(objDoctoD.IComentario);
                            return;
                        }
                        fTrans.Commit();
                        fConn.Close();

                    }




                    if (generarFacturaElectronica)
                    {
                        imprimirFacturaElectronica(newDoctoId);
                        if (CurrentUserID.CurrentParameters.IRECIBOLARGOCONFACTURA.Equals("S"))
                        {
                            PosPrinter.ImprimirTicket(newDoctoId);
                        }
                    }
                    else
                    {
                        PosPrinter.ImprimirTicket(newDoctoId);
                    }







                    //iPos.PosPrinter.ImprimirTicket(m_doctoId, Ticket._OPCION_IMPRESION_COMPRA_DEVOLUCION);

                    MessageBox.Show("Se han confirmado con exito la recepción de mercancía");

                    m_recepcionProcesada = true;

                    this.Close();
                    this.Dispose();
                }
                else
                {

                    pvd.CancelarVenta(objDoctoBE, CurrentUserID.CurrentUser, null);
                }


    */
            }
            catch (Exception ex)
            {
                try
                {
                    fTrans.Rollback();
                }
                catch
                {
                }

                CPuntoDeVentaD pvd = new CPuntoDeVentaD();
                pvd.CancelarVenta(objDoctoBE, CurrentUserID.CurrentUser, null);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fConn.Close();
            }


        }


        private void PagarBasicoVentaFuturoAplicada()
        {

            if (m_Docto == null || m_Docto.IID == 0)
                return;

            CDOCTOD objDoctoD = new CDOCTOD();
            CDOCTOBE objDoctoBE = new CDOCTOBE();
            objDoctoBE.IID = m_Docto.IID;
            objDoctoBE = objDoctoD.seleccionarDOCTO(objDoctoBE, null);

            if (objDoctoBE == null)
            {
                MessageBox.Show("La venta no fue guardada");
                return;
            }


            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            CCAJABE caja = pvd.ObtenerDatosCaja(iPos.CurrentUserID.CurrentCompania.IEM_CAJA);


            bool bMantenerAbierta = true;

            if (MessageBox.Show("Desea que la venta a futuro de la que viene esta venta se mantenga abierta con el restante que falta por surtir? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                bMantenerAbierta = false;
            }


            WFPagosBasico wp = new WFPagosBasico(objDoctoBE, caja, false, 0, null, tipoTransaccionV.t_venta, "N", null, false, false, 0, 0);
            wp.m_bCerrarVentaFuturoAplicada = true;
            wp.m_bCerrarTraspasoSalida = false;
            wp.m_bCerrarVenta = false;
            wp.m_bMantenerVentaFuturoAbierta = bMantenerAbierta;
            wp.ShowDialog();

            bool bAlreadyClosedInDB = true;
            bool generarFacturaElectronica = (wp.m_generarFacturaElectronica && !wp.m_surtidoPostpuesto);


            if (wp.m_bPagoCompleto)
            {



                objDoctoBE.IID = m_Docto.IID;
                objDoctoBE.IOBSERVACION = "";

                objDoctoBE.IREFERENCIAS = "";
                objDoctoBE.IVENDEDORID = CurrentUserID.CurrentUser.IID;


                FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
                FbTransaction fTrans = null;
                bool bRes;

                if (!bAlreadyClosedInDB)
                {


                    fConn.Open();
                    fTrans = fConn.BeginTransaction();

                    bRes = objDoctoD.VENTAFUTUROAPLICACION_COMPLETAR(objDoctoBE, bMantenerAbierta, fTrans);

                    if (bRes == false)
                    {
                        fTrans.Rollback();
                        fConn.Close();

                        pvd.CancelarVenta(objDoctoBE, CurrentUserID.CurrentUser, null);

                        MessageBox.Show(objDoctoD.IComentario);


                        wp.Dispose();
                        GC.SuppressFinalize(wp);

                        return;
                    }
                    fTrans.Commit();
                    fConn.Close();

                }


                bool bImprimirDoble = m_Docto.IMONTOREBAJA > 0;
                this.CerrarVenta((wp.m_generarFacturaElectronica && !wp.m_surtidoPostpuesto), wp.m_bPagoPorxCredito, true, bImprimirDoble, wp.m_timbrarPagosAlTerminar, false, false, null);




            }

            wp.Dispose();
            GC.SuppressFinalize(wp);
        }


        private void btnRecargasEmida_Click(object sender, EventArgs e)
        {

            WFRecargaCantidadEmida wfRecargaEmida = new WFRecargaCantidadEmida();
            wfRecargaEmida.ShowDialog();

            wfRecargaEmida.Dispose();
            GC.SuppressFinalize(wfRecargaEmida);
        }

        private void TBCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRutaEmbarque_Click(object sender, EventArgs e)
        {
            if (!(bool)m_Docto.isnull["IID"] && gridPVDataGridView.Rows.Count > 0)
            {
                asignarRutaEmbarqueSiAplica(false, false, true);
            }
            else
            {
                MessageBox.Show("Primero seleccione un producto en la venta.");
            }
        }

        private void btnAdjuntarArchivo_Click(object sender, EventArgs e)
        {
            if (!(bool)m_Docto.isnull["IID"] && gridPVDataGridView.Rows.Count > 0)
            {
                bool esPago = false;
                if (CurrentUserID.CurrentParameters.IRUTAARCHIVOSADJUNTOS != null && CurrentUserID.CurrentParameters.IRUTAARCHIVOSADJUNTOS != "")
                {
                    WFAdjuntarArchivos adjuntar = new WFAdjuntarArchivos(ref loadedFiles, m_Docto.IID, esPago, loadedFilesCerrada, loadedFilesWorkHours, loadedFilesDate);
                    adjuntar.ShowDialog();
                    adjuntar.Dispose();
                    GC.SuppressFinalize(adjuntar);
                    //loadedFiles = new List<string>();
                }
            }
            else
            {
                MessageBox.Show("Primero seleccione un producto en la venta.");
            }

        }

        private void btnPagoServicios_Click(object sender, EventArgs e)
        {

            WFPagoServiciosEmida wfPagoServiciosEmida = new WFPagoServiciosEmida();
            wfPagoServiciosEmida.ShowDialog();
            wfPagoServiciosEmida.Dispose();
            GC.SuppressFinalize(wfPagoServiciosEmida);
        }

        private void btnVendedorEjecutivo_Click(object sender, EventArgs e)
        {
            WFSeleccionaVendedorEjecutivo wfv = new WFSeleccionaVendedorEjecutivo(CurrentUserID.CurrentUser.IID, CurrentUserID.CurrentUser.ICLAVE);
            wfv.ShowDialog();
            if (wfv.m_bseleccionado)
            {
                this.m_vendedorEjecutivoId = wfv.m_vendedorfinal;
                this.lblVendedorEjecutivo.Text = wfv.m_clavevendedor;
            }
            wfv.Dispose();
            GC.SuppressFinalize(wfv);
        }

        private void BTPuntosBancomer_Click(object sender, EventArgs e)
        {
            WFObtenerPuntosBancomer wf = new WFObtenerPuntosBancomer(false);

            wf.Show();
        }

        private bool AgregarVisitaDoctoSiEsNecesario(long doctoId, long cajaId, long usuarioId)
        {
            CDOCTOVISITABE doctoVisita = new CDOCTOVISITABE();
            CDOCTOVISITAD daoDoctoVisita = new CDOCTOVISITAD();

            if (CurrentUserID.CurrentParameters.IUNICAVISITAPORDOCTO == "S")
            {
                doctoVisita.IUSUARIOID = usuarioId;
                doctoVisita.ICAJAID = cajaId;
                doctoVisita.IDOCTOID = doctoId;
                doctoVisita.IFECHAHORA = DateTime.Now;

                daoDoctoVisita.AgregarDOCTOVISITA(doctoVisita, null);

                return true;
            }

            return false;
        }

        private bool VerificarUnicaVisitaXDocto(long doctoId, long cajaId, long usuarioId)
        {
            if (CurrentUserID.CurrentParameters.IUNICAVISITAPORDOCTO == "N")
                return true;

            CDOCTOVISITABE doctoVisita = new CDOCTOVISITABE();
            CDOCTOVISITAD daoDoctoVisita = new CDOCTOVISITAD();

            doctoVisita = daoDoctoVisita.SeleccionarXDoctoCaja_DespuesFechaHora(doctoId, cajaId, DateTime.Now.AddMinutes(-30), null);

            if (doctoVisita != null)
            {
                doctoVisita.IFECHAHORA = DateTime.Now;
                doctoVisita.IUSUARIOID = usuarioId;

                daoDoctoVisita.CambiarDOCTOVISITA(doctoVisita, doctoVisita, null);

                return true;
            }
            else
            {
                int numRegistros = 0;

                numRegistros = daoDoctoVisita.CuentaXDocto_NoCaja_DespuesFechaHora(doctoId, cajaId, DateTime.Now.AddMinutes(-30), null);

                if (numRegistros > 0)
                {
                    DialogResult visitarDoctoResult = MessageBox.Show("La venta está siendo vista por otro usuario, desea continuar?",
                                                          "Advertencia",
                                                          MessageBoxButtons.YesNo);

                    if (visitarDoctoResult == DialogResult.Yes)
                    {
                        CUSUARIOSD daoUsuarios = new CUSUARIOSD();

                        if (daoUsuarios.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_CONSULTAR_DOCTO_EN_PARALELO, null))
                        {
                            PreguntaBorrarVisita(ref daoDoctoVisita, ref doctoId);
                        }
                        else
                        {

                            WFPreguntaAutorizacion ps2 = new WFPreguntaAutorizacion();
                            ps2.m_requiereAdminOrSupervisor = false;
                            ps2.ShowDialog();
                            CPERSONABE userBE = ps2.m_userBE;
                            CPERSONABE supervisorBE = ps2.m_supervisorBE;
                            bool bPassValido = ps2.m_bPassValido;
                            bool bIsSupervisor = ps2.m_bIsSupervisor;
                            bool bIsAdministrador = ps2.m_bIsAdministrador;
                            ps2.Dispose();
                            GC.SuppressFinalize(ps2);

                            if (!bPassValido || userBE != null)
                            {
                                if (daoUsuarios.UsuarioTienePermisos((int)userBE.IID, (int)DBValues._DERECHO_CONSULTAR_DOCTO_EN_PARALELO, null))
                                {
                                    PreguntaBorrarVisita(ref daoDoctoVisita, ref doctoId);
                                }
                                else
                                {
                                    MessageBox.Show("El usuario no tiene permisos para abrir un docto en paralelo");
                                    return false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("El usuario no tiene permisos para abrir un docto en paralelo");
                                return false;
                            }
                        }

                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return AgregarVisitaDoctoSiEsNecesario(doctoId, cajaId, usuarioId);
        }

        private bool FinalizarVisitaDoctoActual()
        {

            if (m_Docto != null && m_Docto.IID > 0)
            {
                return FinalizarVisitaDocto(m_Docto.IID, (long)CurrentUserID.CurrentCompania.IEM_CAJA);
            }

            return true;
        }

        private bool FinalizarVisitaDocto(long doctoId, long cajaId)
        {
            if (CurrentUserID.CurrentParameters.IUNICAVISITAPORDOCTO == "N")
            {
                return true;
            }

            CDOCTOVISITAD daoDoctoVisita = new CDOCTOVISITAD();

            return daoDoctoVisita.BorrarXDoctoCaja(doctoId, cajaId, null);
        }

        private bool BorrarVisitasViejasPorCaja(long cajaId)
        {
            if (CurrentUserID.CurrentParameters.IUNICAVISITAPORDOCTO == "N")
            {
                return true;
            }

            CDOCTOVISITAD daoDoctoVisita = new CDOCTOVISITAD();

            return daoDoctoVisita.BorrarXCaja_AntesFechaHora(cajaId, DateTime.Now.AddHours(-24), null);
        }

        private void PreguntaBorrarVisita(ref CDOCTOVISITAD daoDoctoVisita, ref long doctoId)
        {
            DialogResult desbloquearVisitaResult = MessageBox.Show("Desea desbloquear la visita de la venta para los demás usuarios?",
                                                                                   "Advertencia",
                                                                                    MessageBoxButtons.YesNo);

            if (desbloquearVisitaResult == DialogResult.Yes)
            {
                daoDoctoVisita.BorrarXDocto(doctoId, null);
            }
        }


        private void btnReimprimirVoucherBanc_Click(object sender, EventArgs e)
        {
            CUSUARIOSD usuariosD = new CUSUARIOSD();
            if (usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_REIMPRIMIR_VOUCHER, null))
            {
                CDOCTOD doctoD = new CDOCTOD();
                CDOCTOBE doctoBE = new CDOCTOBE();

                try
                {
                    doctoBE.IFOLIO = m_Docto.IFOLIO;
                    doctoBE.ITIPODOCTOID = DBValues._DOCTO_TIPO_VENTA;
                    doctoBE = doctoD.SeleccionarXTIPOYFOLIO(doctoBE, null);

                    if (doctoBE == null)
                    {
                        MessageBox.Show("Folio no encontrado");
                        return;
                    }

                    CBANCOMERPARAMBE bufferBanc = new CBANCOMERPARAMBE();
                    CBANCOMERPARAMD bancomerParamD = new CBANCOMERPARAMD();

                    bufferBanc.IDOCTOID = doctoBE.IID;
                    bufferBanc.ITIPOTRANSACCION = "001";
                    bufferBanc.IESTADOTRANSACCIONID = 1;
                    List<CBANCOMERPARAMBE> listaPagosSimple =
                        bancomerParamD.seleccionarBANCOMERPARAM_PORDOCTO_Simple(bufferBanc, null);
                    if (listaPagosSimple == null || listaPagosSimple.Count == 0)
                    {
                        MessageBox.Show("No se encontró el voucher en la base de datos");
                    }
                    else
                    {
                        for (int i = 0; i < listaPagosSimple.Count; i++)
                        {
                            PagoBancomerHelper.ImprimirVoucher(listaPagosSimple.ElementAt(i).IID, true, true);
                        }
                    }

                }
                catch
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("No cuenta con el permiso de reimpresión de vouchers");
            }
        }

        private bool APLICARCUPONES_SIESNECESARIO(long doctoId, FbTransaction fTrans)
        {
            if (CurrentUserID.CurrentParameters.IMANEJACUPONES.Equals("N"))
            {
                return true;
            }
            else
            {
                CPROMOCIOND promocionDao = new CPROMOCIOND();
                string hayCuponesAplicados = "";
                try
                {
                    return promocionDao.APLICAPROMOCIONESCUPONES(doctoId, ref hayCuponesAplicados, fTrans);
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool PideAutorizacionXAlertaPreciosSiAplica()
        {

            if (CurrentUserID.CurrentParameters.IPVCOLOREAR != DBValues._PVCOLOREAR_PRECIOMINIMO_COSTO ||
                m_Docto == null || m_Docto.ITIPODOCTOID != DBValues._DOCTO_TIPO_VENTA)
            {
                return true;
            }

            if (HayAlertaPrecios())
            {
                WFPreguntaCodigoAutorizacion wf = new WFPreguntaCodigoAutorizacion();
                wf.ShowDialog();

                if (wf.m_supervisorBE == null)
                {
                    MessageBox.Show("El codigo de autorizacion no existe");
                    wf.Dispose();
                    GC.SuppressFinalize(wf);
                    return false;
                }

                m_AUTORIZOALERTAID = wf.m_supervisorBE.IID;

                wf.Dispose();
                GC.SuppressFinalize(wf);

            }

            return true;

        }

        private bool CambiaAutorizacionXAlertaPreciosSiAplica()
        {
            if (m_AUTORIZOALERTAID == 0)
            {
                return true;
            }

            if (CurrentUserID.CurrentParameters.IPVCOLOREAR != DBValues._PVCOLOREAR_PRECIOMINIMO_COSTO ||
                m_Docto == null || m_Docto.ITIPODOCTOID != DBValues._DOCTO_TIPO_VENTA)
            {
                return true;
            }


            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE doctoBE = new CDOCTOBE();
            doctoBE.IID = m_Docto.IID;
            doctoBE.IAUTORIZOALERTAID = m_AUTORIZOALERTAID;
            if (!doctoD.CambiarAUTORIZOALERTAIDD(doctoBE, null))
            {
                return false;
            }
            m_AUTORIZOALERTAID = 0;
            return true;
        }



        private bool HayAlertaPrecios()
        {
             var autPrecioListaBajo = (!(bool)CurrentUserID.CurrentParameters.isnull["IAUTPRECIOLISTABAJO"]) &&
                CurrentUserID.CurrentParameters.IAUTPRECIOLISTABAJO.Equals("S");
            

                foreach (iPos.PuntoDeVenta.DSPuntoDeVentaAux2.GRIDPVRow row in dSPuntoDeVentaAux2.GRIDPV)
            {
                if (row.ALERTA3COLOR != null && 
                        (row.ALERTA3COLOR.Trim().Equals("AMARILLO") || row.ALERTA3COLOR.Trim().Equals("ROJO")) &&
                        ((row.INGRESOPRECIOMANUAL == "S") || autPrecioListaBajo) &&
                    ((row.PROMOCION != "S") && (row.ESMAYOREO != "S") && (row.ESMEDIOMAYOREO != "S") && (row.TIPOMAYOREOLINEAID <= 1)))
                {
                    return true;
                }
            }

            return false;
        }

        private bool CancelaFacturaXSustitucion()
        {
            CDOCTOD doctoD = new CDOCTOD();

            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();

                long doctoSustitucionActual = 0;
                if (!doctoD.SUSTITUCION_CREAR(m_Docto.IID, CurrentUserID.CurrentUser.IID, ref doctoSustitucionActual, fTrans))
                {
                    fTrans.Rollback();
                    fConn.Close();
                    MessageBox.Show("Hubo un error " + doctoD.IComentario);
                    return false;
                }
                else
                {
                    fTrans.Commit();
                    fConn.Close();

                    string comentarioFact = "";
                    if(!generarFacturaElectronicaPorId(doctoSustitucionActual, null, ref comentarioFact, true))
                    {
                        MessageBox.Show("No se pudo generar la factura electronica de la sustitucion. A continuacion se abrira el documento .. puede volver a intentar facturar con ctrl+f12");
                    }

                    m_doctoSustitutoId = doctoSustitucionActual;
                    //AbrirVentaXId(doctoSustitucionActual);
                    //RefrescarEstatusBotones();

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
                fConn.Close();
            }
            finally
            {
                fConn.Close();
            }
            
            return true;
        }

        private bool CancelaFacturaXNotaCredito()
        {
            //MessageBox.Show("Cancelacion x nota de credito");

            CDOCTOD doctoD = new CDOCTOD();

            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();

                long? doctoDevolucionActual = null;
                if (!doctoD.NOTACREDITO_DEVOLVERTODAVENTA(m_Docto.IID, CurrentUserID.CurrentUser.IID, ref doctoDevolucionActual, fTrans))
                {
                    fTrans.Rollback();
                    fConn.Close();
                    MessageBox.Show("Hubo un error " + doctoD.IComentario);
                }
                else
                {
                    fTrans.Commit();
                    fConn.Close();


                    WFVentaDevolucion ventaDev = new WFVentaDevolucion(doctoDevolucionActual.Value, true);
                    ventaDev.ShowDialog();
                    ventaDev.Dispose();
                    GC.SuppressFinalize(ventaDev);

                    //AbrirVentaXId(doctoDevolucionActual.Value);
                    //RefrescarEstatusBotones();

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
                fConn.Close();
            }
            finally
            {
                fConn.Close();
            }

            return true;
        }


        private bool PreguntarSiEsServDomSiAplica()
        {

            if (m_bAutomatizaPagoEfectivo || m_estadoVenta == (int)estadoVenta.e_Cerrada || m_estadoVenta == (int)estadoVenta.e_Cancelada ||
                CurrentUserID.CurrentParameters.IPREGUNTARSERVDOM == null || !CurrentUserID.CurrentParameters.IPREGUNTARSERVDOM.Equals("S") ||
                m_Docto == null || m_Docto.IID == 0 ||  m_Docto.ITIPODOCTOID != DBValues._DOCTO_TIPO_VENTA ||
                (m_Docto.IESSERVDOMICILIO != null && m_Docto.IESSERVDOMICILIO.Equals("S")) )
                return true;


            CPERSONAD daoPersona = new CPERSONAD();
            CPERSONABE cliente = new CPERSONABE();
            cliente.IID = m_Docto.IPERSONAID;
            cliente = daoPersona.seleccionarPERSONA(cliente, null);

            if (cliente == null || cliente.ISERVICIOADOMICILIO == null || !cliente.ISERVICIOADOMICILIO.Equals("S"))
                return true;

            if (MessageBox.Show("Es esta una venta a domicilio?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return true;
            }


                CDOCTOD doctoD = new CDOCTOD();
            m_Docto.IESSERVDOMICILIO = "S";
            if (!doctoD.CambiarESSERVDOMICILIO(m_Docto, null))
            {
                m_Docto.IESSERVDOMICILIO = "N";
                MessageBox.Show("No se pudo asignar como servicio a domicilio " + doctoD.IComentario);
                return false;
            }

            return true;

        }


        private void MostrarAlertaNuevosComprasSiAplica()
        {
            if (!m_bMostrarAlertasCompras)
            {
                btnAlertaNuevasCompras.Visible = false;
                return;
            }



            btnAlertaNuevasCompras.Visible = true;

            CPERSONAVISTACOMPRAD objD = new CPERSONAVISTACOMPRAD();
            CPERSONAVISTACOMPRABE objBE = new CPERSONAVISTACOMPRABE();
            objBE.IPERSONAID = CurrentUserID.CurrentUser.IID;
            objBE = objD.seleccionarPERSONAVISTACOMPRAxPERSONAID(objBE, null);

            DateTime fechaUltimoAcceso = DateTime.Today.AddDays(-3);
            if (objBE != null)
                fechaUltimoAcceso = objBE.IULTIMAVISTA;

            int cuentaCambiosDespuesUltimoAcceso = objD.CuentaComprasDespuesUltimoAcceso(fechaUltimoAcceso, null);
            int cuentaCambiosRecientes = objD.CuentaComprasRecientes(fechaUltimoAcceso, null);

            if (cuentaCambiosDespuesUltimoAcceso > 0 || cuentaCambiosRecientes > 0)
                btnAlertaNuevasCompras.BackColor = Color.OrangeRed;
            else
                btnAlertaNuevasCompras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));

            if(cuentaCambiosDespuesUltimoAcceso > 0)
            {
                MessageBox.Show("Hay compras recientes o nuevos productos ... se le dirigira a la pantalla para que los vea");
                abrirProductosCompradosRecientes();
            }

        }


        private void abrirProductosCompradosRecientes()
        {
            WFComprasRecientes wf = new WFComprasRecientes();
            wf.ShowDialog();

            wf.Dispose();
            GC.SuppressFinalize(wf);


            CPERSONAVISTACOMPRAD objD = new CPERSONAVISTACOMPRAD();
            CPERSONAVISTACOMPRABE objBE = new CPERSONAVISTACOMPRABE();
            objBE.IPERSONAID = CurrentUserID.CurrentUser.IID;
            objBE = objD.seleccionarPERSONAVISTACOMPRAxPERSONAID(objBE, null);

            if(objBE != null)
            {

                objBE.IULTIMAVISTA = DateTime.Now;
                objD.CambiarPERSONAVISTACOMPRAD(objBE, objBE, null);
            }
            else
            {
                objBE = new CPERSONAVISTACOMPRABE();
                objBE.IPERSONAID = CurrentUserID.CurrentUser.IID;
                objBE.IULTIMAVISTA = DateTime.Now;
                objD.AgregarPERSONAVISTACOMPRAD( objBE, null);
            }

        }

        private void btnAlertaNuevasCompras_Click(object sender, EventArgs e)
        {
            abrirProductosCompradosRecientes();
        }

        private void CBXPagoConTarjeta_Leave(object sender, EventArgs e)
        {
            if (!m_vigilarPagoConTarjeta)
                return;

            if (CBXPagoConTarjeta.SelectedIndex == 1 &&
                        CurrentUserID.CurrentParameters.ICOMISIONDEBPORTARJETA != CurrentUserID.CurrentParameters.ICOMISIONPORTARJETA)
            {
                this.CBXPagoConTarjeta.Focus();
            }
        }


        private void PrepararAbrirOtraPantalla()
        {

            if ((!(bool)m_Docto.isnull["IID"])
                && (m_estadoVenta != (int)estadoVenta.e_Cerrada && m_estadoVenta != (int)estadoVenta.e_Cancelada)
                )
            {

                if (CurrentUserID.CurrentParameters.IPREGUNTACANCELACOTIZACION != null && CurrentUserID.CurrentParameters.IPREGUNTACANCELACOTIZACION.Equals("S"))
                {
                    CancelarVentaActual();
                }
                else if (gridPVDataGridView.Rows.Count == 0)
                {
                    CPuntoDeVentaD pvd = new CPuntoDeVentaD();
                    pvd.CancelarVenta(m_Docto, CurrentUserID.CurrentUser, null);
                }


            }
        }

        private void BTVerASurtir_Click(object sender, EventArgs e)
        {

            PrepararAbrirOtraPantalla();
            AbrirVenta(true);
            RefrescarEstatusBotones();
        }

        private void BTSurtir_Click(object sender, EventArgs e)
        {
            if (CurrentUserID.CurrentParameters.IHABSURTIDOPREVIO != "S")
            {
                MessageBox.Show("no se puede enviar a surtir en esta area porque no se tiene configurado el surtido previo");
                return;
            }

             if (m_Docto != null && m_Docto.IID > 0 &&
                m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA &&
                m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_BORRADOR &&
                CurrentUserID.CurrentParameters.IHABSURTIDOPREVIO != null && CurrentUserID.CurrentParameters.IHABSURTIDOPREVIO.Equals("S"))
            {
                CDOCTOD doctoD = new CDOCTOD();
                m_Docto.IESTADOSURTIDOID = DBValues._DOCTO_SURTIDOESTADO_PENDIENTE;
                if (!doctoD.CambiarESTADOSURTIDOID(m_Docto, null))
                {
                    MessageBox.Show("ERRORES al cambiar estado surtido : " + doctoD.IComentario.Replace("%", "\n"));
                    throw new Exception();
                }

                MessageBox.Show("Se realizo el envio a surtir");
                IrANuevaVenta();
            }
            else
            {
                MessageBox.Show("No estan las condiciones para enviar a surtido esta transaccion");
            }
        }




        private bool GuardarGuia(CGUIABE guiaBE, CDOCTOBE dOCTOBE)
        {
            CGUIADETALLED guiaDETD = new CGUIADETALLED();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            try
            {

                fConn.Open();
                fTrans = fConn.BeginTransaction();
                CGUIADETALLEBE guiaDetBE = new CGUIADETALLEBE();
                guiaDetBE.IDOCTOID = dOCTOBE.IID;
                guiaDetBE.IESTADOGUIAID = DBValues._ESTADO_GUIA_ENVIADA;

                //ante cualquier return o error
                if (!guiaDETD.GUIADETALLE_INSERT(ref guiaDetBE, ref guiaBE, fTrans))
                {
                    fTrans.Rollback();
                    fConn.Close();

                    MessageBox.Show("Ocurrio un eror al agregar la guia. No se puede generar la carta porte " + guiaDETD.IComentario);
                    return false;
                }


                //en caso de exito
                fTrans.Commit();
                fConn.Close();

                return true;

            }
            catch
            {
                try
                {
                    fTrans.Rollback();
                }
                catch { }

                fConn.Close();

                MessageBox.Show("Ocurrio un eror al agregar la guia. No se puede generar la carta porte ");
                return false;
            }
            finally
            {
                fConn.Close();
            }

        }

        private void CBContado_CheckedChanged(object sender, EventArgs e)
        {

            if (m_bLlenandoDoctoDatosGenerales)
                return;

            if (!CBContado.Checked && 
                    (m_Docto == null || (bool)m_Docto.isnull["IID"] ))
                return;

            if ( m_Docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_BORRADOR)
                MessageBox.Show("Este dato solo puede ser cambiado en estatus borrador ");


            if (m_Docto == null || (bool)m_Docto.isnull["IID"])
                bActualizarContadoDespuesDeCrearDocto = true;

            else
            {
                string strCambioResult = this.CambiarContado();
                if (!strCambioResult.Equals("S"))
                {
                    MessageBox.Show(strCambioResult);
                }
            }
        }


        private void CBEspecial_CheckedChanged(object sender, EventArgs e)
        {

            if (m_bLlenandoDoctoDatosGenerales)
                return;

            if (!CBEspecial.Checked &&
                    (m_Docto == null || (bool)m_Docto.isnull["IID"]))
                return;

            if (m_Docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_BORRADOR)
                MessageBox.Show("Este dato solo puede ser cambiado en estatus borrador ");


            if (m_Docto == null || (bool)m_Docto.isnull["IID"])
                bActualizarVentaEspecialDespuesDeCrearDocto = true;

            else
            {
                string strCambioResult = this.CambiarEsVentaEspecial();
                if (!strCambioResult.Equals("S"))
                {
                    MessageBox.Show(strCambioResult);
                }
            }
        }


        private void CBCotizacionEnrutada_CheckedChanged(object sender, EventArgs e)
        {

            if (m_bLlenandoDoctoDatosGenerales)
                return;

            if (!CBCotizacionEnrutada.Checked &&
                    (m_Docto == null || (bool)m_Docto.isnull["IID"]))
                return;

            if (m_Docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_BORRADOR)
                MessageBox.Show("Este dato solo puede ser cambiado en estatus borrador ");


            if (m_Docto == null || (bool)m_Docto.isnull["IID"])
                bActualizarCotizacionEnrutadaDespuesDeCrearDocto = true;

            else
            {
                string strCambioResult = this.CambiarCotiEnrutada();
                if (!strCambioResult.Equals("S"))
                {
                    MessageBox.Show(strCambioResult);
                }
                else
                {
                    this.SETESTADOREBAJA_COTIENRUTADA(0);
                }
            }
        }

        private void CBFactura_CheckedChanged(object sender, EventArgs e)
        {

            if (m_bLlenandoDoctoDatosGenerales)
                return;

            if (!CBFactura.Checked &&
                    (m_Docto == null || (bool)m_Docto.isnull["IID"]))
                return;

            if (m_Docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_BORRADOR)
                MessageBox.Show("Este dato solo puede ser cambiado en estatus borrador ");


            if (m_Docto == null || (bool)m_Docto.isnull["IID"])
                bActualizarFacturaElectronicaDespuesDeCrearDocto = true;

            else
            {
                string strCambioResult = this.CambiarEsFacturaElectronica();
                if (!strCambioResult.Equals("S"))
                {
                    MessageBox.Show(strCambioResult);
                }
            }
        }
        

        private void ObservacionesTextBox_Validated(object sender, EventArgs e)
        {

            if (m_bLlenandoDoctoDatosGenerales)
                return;

            if ((ObservacionesTextBox.Text == null || ObservacionesTextBox.Text.Length == 0) &&
                    (m_Docto == null || (bool)m_Docto.isnull["IID"]))
                return;

            if (m_Docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_BORRADOR)
                MessageBox.Show("Este dato solo puede ser cambiado en estatus borrador ");


            if (m_Docto == null || (bool)m_Docto.isnull["IID"])
                bActualizarObservacionesDespuesDeCrearDocto = true;

            else
            {
                string strCambioResult = this.CambiarObservaciones();
                if (!strCambioResult.Equals("S"))
                {
                    MessageBox.Show(strCambioResult);
                }
            }
        }

        private void btnDomicilioEntrega_Click(object sender, EventArgs e)
        {


            WFSeleccionarDomicilioEntrega rc_ = new WFSeleccionarDomicilioEntrega(this.m_Docto.IPERSONAID, "Por favor seleccione un domicilio de entrega o eliga usar los datos del cliente." , this.m_Docto.IDOM_ENTREGAID);
            rc_.ShowDialog();

            if(rc_.DomicilioSeleccionadoId != this.m_Docto.IDOM_ENTREGAID)
            {

                CDOCTOD doctoD = new CDOCTOD();
                CDOCTOBE doctoBE = new CDOCTOBE();
                doctoBE.IID = m_Docto.IID;

                if (rc_.DomicilioSeleccionadoId != null)
                    doctoBE.IDOM_ENTREGAID = rc_.DomicilioSeleccionadoId.Value;

                if(doctoD.CambiarDomicilioEntrega(doctoBE, null))
                {
                    MessageBox.Show("Se actualizo el domicilio de entrega");
                    this.m_Docto.IDOM_ENTREGAID = doctoBE.IDOM_ENTREGAID;
                }
                else
                {
                    MessageBox.Show("Ocurrio un error " + doctoD.IComentario);
                }
            }


            rc_.Dispose();
            GC.SuppressFinalize(rc_);
        }
    }
}