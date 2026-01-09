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

namespace iPos
{
    public partial class WFMovilPuntoDeVenta : IposForm
    {
        int m_estadoVenta;
        CDOCTOBE m_Docto;
        CCAJABE m_Caja;

        decimal m_dMontoVenta;
        decimal m_dSumaImporte;
        decimal m_dMontoIva;
        decimal m_dDescuento;
        decimal m_montoVentaConVale;

        string m_printer = "";
        long m_sucursalTID;
        bool m_bSalirSinPreguntar;

        bool m_focusInCommandLine = false;
        long m_ClienteId = DBValues._CLIENTEMOSTRADOR;

        string m_strUltimoProductoIngresado = "";

        bool m_bPermisoCambiarPrecio = false;
        bool m_bPermisoCambiarPrecioxLista = false;
        bool m_bPermisoCambiarPrecioxDescuento = false;

        bool m_manejaAlmacen = false;


        tipoTransaccionV m_tipoTransaccion;
        CDOCTOBE m_DoctoRef;


        CPERSONABE m_supervisor = null;
        bool m_asignarsupervisor = false;


        long m_almacenTID = 0;

        //bool m_usuarioPuedeCambiarAlmacen = false;



        //int m_keyboardSize = 0;
        //private TextBox focusedTextbox = null;
        //bool m_teclaTouch = false;
        //int m_mainViewHeight = 0;

       double scaleFactor = 1;


       string strLastProductoSearch = "";

       WFPagosBasico m_formPagoVenta = null;



        public WFMovilPuntoDeVenta()
        {
            InitializeComponent();
            try
            {
                ResetearVariablesForm();
                m_bSalirSinPreguntar = false;
            }
            catch { }


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
            BTValidarExistencia.ForeColor = Color.Black;
            BTValidarExistencia.BackColor = Color.FromArgb(41, 121, 255);

            m_dMontoVenta = 0;
            m_dSumaImporte = 0;
            m_dMontoIva = 0;
            m_dDescuento = 0;
            m_sucursalTID = 0;
            m_montoVentaConVale = 0;
            RefrescarEstatusBotones();

            m_tipoTransaccion = CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S") ? tipoTransaccionV.t_ventaMovil : tipoTransaccionV.t_venta;
            m_DoctoRef = null;
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




            this.TBPrecio.ReadOnly = !this.m_bPermisoCambiarPrecio;
            this.TBDescuento.ReadOnly = !this.m_bPermisoCambiarPrecioxDescuento;
            try
            {
                this.gridPVDataGridView.Columns["PRECIOUNIDAD"].ReadOnly = !this.m_bPermisoCambiarPrecio;
                this.gridPVDataGridView.Columns["DESCUENTOPORCENTAJE"].ReadOnly = !this.m_bPermisoCambiarPrecioxDescuento;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return true;
        }

        private void WFMovilPuntoDeVenta_Load(object sender, EventArgs e)
        {            
            /**winforms only starts**/
            this.Location = new Point(0, 0);
            /**winforms only ends**/
            

            if (CurrentUserID.CurrentParameters.ITOUCH.Equals("S"))
            {

                this.AutoScroll = false;
                this.HorizontalScroll.Enabled = false;
                this.HorizontalScroll.Visible = false;
                this.VerticalScroll.Enabled = false;
                this.VerticalScroll.Visible = false;

                //RemoveAnchor(this);
            }

            if (CurrentUserID.CurrentParameters.ICAJASBOTELLAS.Equals("S") && CurrentUserID.CurrentUser.ICAJASBOTELLAS.Equals("S"))
            {
                TBCajas.Visible = true;
                lblCajas.Visible = true;
                lblCantidad.Text = "Botellas";

                gridPVDataGridView.Columns["GVCANTIDAD"].ReadOnly = true;

            }
            else
            {
                TBCajas.Visible = false;
                lblCajas.Visible = false;
                lblCantidad.Text = "Cantidad";
            }

            if (!ChecarPermisos())
            {
                this.Close();
                return;
            }

            this.Text = "BIENVENIDO  (CAJA: " + iPos.CurrentUserID.CurrentCompania.IEM_CAJA_NOMBRE + " ) ";

            this.LBVendedor.Text = iPos.CurrentUserID.CurrentUser.INOMBRE;
            MostrarVendedorYTurno();
            this.LBCliente.Text = "MOSTRADOR";
            this.gRIDPVTableAdapter1.SelectCommandTimeout = 100;
            m_printer = Ticket.GetReceiptPrinter();

            if (!ChecarFechaDelSistema())
                return;

            ChecarCorteActivo();
            ObtenerCaja();

            IrANuevaVenta();

            HabilitarBotonesOpcionales();

            this.TBCommandLine.Focus();

            m_manejaAlmacen = !((bool)CurrentUserID.CurrentParameters.isnull["IMANEJAALMACEN"] || !CurrentUserID.CurrentParameters.IMANEJAALMACEN.Equals("S"));
            

            if (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
            {

                if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL <= 1 || CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 4)
                    pnlInfoSaldos.Visible = true;
                else
                    pnlInfoSaldos.Visible = false;

                this.btnAdjunto.Visible = true;
                this.btnAdjunto.ForeColor = Color.Black;
                this.btnAdjunto.BackColor = Color.FromArgb(41, 121, 255);
                this.btnListaAdjuntos.Visible = true;
                this.btnListaAdjuntos.ForeColor = Color.Black;
                this.btnListaAdjuntos.BackColor = Color.FromArgb(41, 121, 255);
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


            if (CurrentUserID.CurrentParameters.ICAJASBOTELLAS.Equals("S") && CurrentUserID.CurrentUser.ICAJASBOTELLAS.Equals("S"))
            {
                this.TBCantidad.Enabled = true;
            }
            else
            {
                this.TBCantidad.Enabled = CurrentUserID.CurrentParameters.IUIVENTACONCANTIDAD.Equals("S");
            }

          
          if (CurrentUserID.CurrentParameters.IAUTOCOMPPROD.Equals("S")  /*&& CurrentUserID.CurrentParameters.ISCREENCONFIG != 1*/)
          {
              this.TBCommandLine.AutoCompleteMode = AutoCompleteMode.Suggest;
              this.TBCommandLine.AutoCompleteSource = AutoCompleteSource.CustomSource;
              this.TBCommandLine.AutoCompleteCustomSource = CurrentUserID.GetAutoSourceCollectionFromTable();
          }
            

           if (CurrentUserID.CurrentParameters.IPRECIOXCAJAENPV.Equals("S"))
            {
                this.pnlPrecioCaja.Visible = true;
            }
            else
            {
                this.pnlPrecioCaja.Visible = false;
            }


            foreach (DataGridViewColumn column in gridPVDataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

      }


       /* private void RemoveAnchor(Control parentCtrl)
        {
            //float currentSize;
            foreach (Control c in parentCtrl.Controls)
            {
                
                
                c.Size = new Size(c.Size.Width, (int)(c.Size.Height * scaleFactor));
                c.Location = new Point(c.Location.X, (int)(c.Location.Y * scaleFactor));


                RemoveAnchor(c);

            }
        }*/



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
                    prod = pvd.buscarPRODUCTOSPV(pvComm.commandText, ref cantidadAux, ref bPreguntaCantidad, CurrentUserID.CurrentParameters, null);
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


            cantidad = cantidad * ((cantidadAux == 0) ? 1 : cantidadAux);
        }


        private void ObtenerDoctoDeBD(long lDoctoID, FbTransaction st)
        {
            CDOCTOD vDocto = new CDOCTOD();
            m_Docto = new CDOCTOBE();
            m_Docto.IID = lDoctoID;
            m_Docto = vDocto.seleccionarDOCTO(m_Docto, st);
        }


        private bool SoloValidarProducto()
        {
            CPRODUCTOBE prod = null;
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

            DecifrarComando(TBCommandLine.Text, ref prod, ref  cantidad, ref bPreguntaCantidad, ref pvd);


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
            if( m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTAMOVIL  && m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_BORRADOR && CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S") &&  m_ClienteId == DBValues._CLIENTEMOSTRADOR)
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
            return ProcessCommand(bIgnorePrecio, preguntarOpcion, P_MOVTOID, bIgnoreDescuento);
        }

        private bool ProcessCommand(bool bIgnorePrecio, bool preguntarOpcion, long? P_MOVTOID, bool bIgnoreDescuento)
        {




            if(!validaCustomerIfNeeded())
            {
                return true;
            }


            CPRODUCTOBE prod = null;

            long? P_IDDOCTO = null;
            decimal? P_CANTIDAD = null;
            long? P_IDPRODUCTO = null;
            long? P_PERSONAID = this.m_ClienteId;
            string P_LOTE = "";
            long? P_USERID = iPos.CurrentUserID.CurrentUser.IID;

            int? US_SUPERVISORID = null;
            if (m_supervisor != null)
                US_SUPERVISORID = (int)m_supervisor.IID;

            int? ALMACENID =  (int)DBValues._DOCTO_ALMACEN_DEFAULT;;
            long? SUCURSALID = CurrentUserID.CurrentParameters.ISUCURSALID;
            DateTime P_FECHAVENCE = DateTime.MinValue;
            Decimal cantidad = 1;
            long? SUCURSALTID = 0;
            long? ALMACENTID = m_tipoTransaccion == tipoTransaccionV.t_traspasoalmacen ?  m_almacenTID : 0;

            long? P_TIPODIFERENCIAINVENTARIOID = 0;
            decimal? P_PRECIO = null;
            decimal? P_DESCUENTO = null;
            string razonPrecioDescuentoCajero = "";

            bool bResult = true;


            bool bPreguntaCantidad = false;


            decimal multiplicandocantidad = Decimal.Parse(this.TBCantidad.Text.ToString());




            long? P_DOCTOREFID = null;
            if (this.m_DoctoRef != null)
            {
                P_DOCTOREFID = this.m_DoctoRef.IID;
            }

            long? P_MOVTOREFID = null;

            string strDescripcionComodin1 = "", strDescripcionComodin2 = "", strDescripcionComodin3 = "";
            bool bHayDescripcionComodin = false;



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

            DecifrarComando(TBCommandLine.Text, ref prod, ref  cantidad, ref bPreguntaCantidad, ref pvd);

            if (CurrentUserID.CurrentParameters.ICAJASBOTELLAS.Equals("S") && CurrentUserID.CurrentUser.ICAJASBOTELLAS.Equals("S"))
            {
                Decimal cajas = Decimal.Parse(this.TBCajas.Text.ToString());
                multiplicandocantidad = multiplicandocantidad + (cajas * (prod.IPZACAJA == 0 ? 1 : prod.IPZACAJA));
            }


            P_CANTIDAD = (cantidad != 0 || (P_MOVTOID.HasValue && P_MOVTOID.Value != 0)) ? cantidad : 1;
            P_CANTIDAD *= multiplicandocantidad;


            if (P_CANTIDAD == 0 && (TBCommandLine.Text == null || !TBCommandLine.Text.StartsWith("0*")))
            {
                if (CurrentUserID.CurrentParameters.ICAJASBOTELLAS.Equals("S") && CurrentUserID.CurrentUser.ICAJASBOTELLAS.Equals("S"))
                {
                    this.TBCajas.Focus();
                }
                return true;
            }

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

                else if (bPreguntaCantidad)
                {
                    WFRecargaCantidad rc_ = new WFRecargaCantidad(true, false);
                    rc_.ShowDialog();
                    decimal dMontoRecarga = rc_.m_dMontoRecarga;
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
                    P_PRECIO = calculaPrecioSinImpuestos(decimal.Parse(TBPrecio.Text), prod.ITASAIVA, prod.ITASAIEPS) * tipoCambio;

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
            if (prod.IMANEJALOTE == "S" && (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL == null || !CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S")))
            {
                //condiciones para preguntar lote
                int num_registros_inv = 0;
                decimal cantidad_inv = 0;
                string lote_inv = "";
                DateTime fechaVence = DateTime.MinValue;

                long? ALMACENEXISTENCIA = null;

                pvd.GetExistencia(prod, ref num_registros_inv, ref cantidad_inv, ref lote_inv, ref fechaVence, ALMACENEXISTENCIA, null);
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
                       

                        if (!pvd.EjecutarAddMOVTO(ref P_IDDOCTO, bufferLote.cantidad, P_IDPRODUCTO, P_PERSONAID, P_USERID, P_LOTE, US_SUPERVISORID, ALMACENID, SUCURSALID, P_FECHAVENCE, m_Docto.ITIPODOCTOID, SUCURSALTID, ALMACENTID, "N", P_TIPODIFERENCIAINVENTARIOID, P_PRECIO, P_DESCUENTO, iPos.CurrentUserID.CurrentCompania.IEM_CAJA, P_DOCTOREFID, ref P_MOVTOID, P_MOVTOREFID, strDescripcionComodin1, strDescripcionComodin2, strDescripcionComodin3, null, fTrans))
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


                if (pvd.EjecutarAddMOVTO(ref P_IDDOCTO, P_CANTIDAD, P_IDPRODUCTO, P_PERSONAID, P_USERID, P_LOTE, US_SUPERVISORID, ALMACENID, SUCURSALID, P_FECHAVENCE, m_Docto.ITIPODOCTOID, SUCURSALTID, ALMACENTID, "N", P_TIPODIFERENCIAINVENTARIOID, P_PRECIO, P_DESCUENTO, iPos.CurrentUserID.CurrentCompania.IEM_CAJA, P_DOCTOREFID, ref P_MOVTOID, P_MOVTOREFID, strDescripcionComodin1, strDescripcionComodin2, strDescripcionComodin3, null , fTrans))
                {


                    ObtenerDoctoDeBD((long)P_IDDOCTO, fTrans);

                    if (razonPrecioDescuentoCajero != "")
                    {
                        pvd.AsignarRazonDescuentoCajero(razonPrecioDescuentoCajero, (int)P_MOVTOID, fTrans);
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
                    fConn.Close();

                    RefrescarGridVentas();
                    FormatGrid();
                    GetTotalesPagosVenta();
                    RefreshTotalesVenta();
                    RefreshNumVenta();
                    //TBMensajesUser.Text = "";//"Exito"
                    //TBMensajesUser.BackColor = Color.Green;
                    this.TBCommandLine.Text = "";
                    this.TBCantidad.Text = (CurrentUserID.CurrentParameters.ICAJASBOTELLAS.Equals("S") && CurrentUserID.CurrentUser.ICAJASBOTELLAS.Equals("S")) ? "0" : "1";
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

                MessageBox.Show(ex.Message + " " + ex.StackTrace);
                fConn.Close();
            }
            finally
            {
                fConn.Close();
            }
            RefrescarEstatusBotones();

            return bResult;
        }


        private void RefrescarGridVentas()
        {
            this.gRIDPVTableAdapter1.Fill(this.dSPuntoDeVentaAux.GRIDPV, (int)m_Docto.IID);
            FormatGrid();

            this.gRIDPVTableAdapter1.Fill(this.dSPuntoDeVentaAux.GRIDPV, (int)m_Docto.IID);
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
        }

        

        




        public void LimpiarTotalesPagosVenta()
        {
            m_dMontoVenta = 0;
            m_dSumaImporte = 0;
            m_dMontoIva = 0;
            m_dDescuento = 0;

            m_montoVentaConVale = 0;
        }
        public void GetTotalesPagosVenta()
        {
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            CDOCTOBE doctoBuffer = pvd.ObtenerVenta(m_Docto, null);

            decimal tipoCambio = (((bool)m_Docto.isnull["ITIPOCAMBIO"] || m_Docto.ITIPOCAMBIO == 0) ? 1 : m_Docto.ITIPOCAMBIO);

            if (pvd.IComentario == "" || pvd.IComentario == null)
            {
                m_Docto = doctoBuffer;
                m_dMontoVenta = m_Docto.ITOTAL / tipoCambio;
                m_dSumaImporte = (m_Docto.ISUBTOTAL + m_Docto.IIEPS) / tipoCambio;
                m_dMontoIva = m_Docto.IIVA / tipoCambio;
                m_dDescuento = m_Docto.IDESCUENTO / tipoCambio;


                this.m_montoVentaConVale = 0;
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

            this.TBTotal.Text = m_dMontoVenta.ToString("N2");
            this.TBSumaTotal.Text = m_dSumaImporte.ToString("N2");
            this.TBIva.Text = m_dMontoIva.ToString("N2");

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

        private void BTCancelarVenta_Click(object sender, EventArgs e)
        {
            CancelarVentaActual();
        }
        private bool CancelarVentaActual()
        {
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();

            if (m_estadoVenta == (int)estadoVenta.e_Cancelada)
                return false;

            if ((bool)m_Docto.isnull["IID"])
                return false;

            if (MessageBox.Show("Quiere cancelar la venta?", "Cancelar la venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
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
                    MessageBox.Show("Un supervisor solo puede eliminar ventas del dia actual y anterior. Se requiere un administrador para borrar de fechas previas");
                    return false;
                }

                /*CUSUARIOSD usuariosD = new CUSUARIOSD();
                if (m_Docto.IFECHA < DateTime.Today.AddDays(-1))
                {
                    if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_ELIMINAR_VENTA_DIASATRAS, null))
                    {
                        MessageBox.Show("Este usuario no puede eliminar ventas de dias anteriores al dia de ayer");
                        return false;
                    }
                }
                else
                {
                    if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_ELIMINAR_VENTA_DELDIA, null))
                    {

                        MessageBox.Show("Este usuario no puede eliminar ventas ");
                        return false;
                    }
                }*/
            }


            // antes de cancelar venta movil , cancelarla en el webservice


            if (m_Docto.ITRASLADOAFTP == DBValues._DB_BOOLVALUE_SI && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTAMOVIL )
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

            switch (m_Docto.ITIPODOCTOID)
            {
                case DBValues._DOCTO_TIPO_VENTA:
                case DBValues._DOCTO_TIPO_TRASPASO_ENVIO:
                case DBValues._DOCTO_TIPO_PEDIDO_TRASPASO_SALIDA:
                case DBValues._DOCTO_TIPO_VENTAMOVIL:
                    {
                        long statusDoctoId = m_Docto.IESTATUSDOCTOID;

                        if (m_Docto.IESFACTURAELECTRONICA != null)
                        {
                            if (m_Docto.IESFACTURAELECTRONICA == "S")
                            {


                                WFFacturaElectronica fe = new WFFacturaElectronica(this.m_Docto, CurrentUserID.CurrentParameters, WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_CANCELAR, this.m_DoctoRef, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
                                CUSUARIOSD usuariosD = new CUSUARIOSD(); fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
                                fe.ShowDialog();
                                bool facturacionCancelada = fe.m_facturacionCancelada;
                                fe.Dispose();
                                GC.SuppressFinalize(fe);
                                if (!fe.m_facturacionCancelada)
                                {


                                    if (MessageBox.Show("No se pudo cancelar la factura electronica en el SAT desde el sistema. Como la venta actual fue facturada electronicamente, tendra que cancelarla tambien en el SAT. Desea continuar con la cancelacion en el sistema?", "Cancelar la transaccion actual", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                                        return false;
                                }
                                /*
                                if (MessageBox.Show("Como la venta actual fue facturada electronicamente, tendra que cancelarla tambien en el SAT. Desea continuar?", "Cancelar la transaccion actual", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                                    return false;
                                 */
                            }

                        }




                        pvd.CancelarVenta(m_Docto, CurrentUserID.CurrentUser, null);
                        if (pvd.IComentario == "" || pvd.IComentario == null)
                        {

                            HiloExistencias._IFLAGENVIAREXISTENCIASEVENTOS++;
                            MessageBox.Show("Venta cancelada");

                            if (statusDoctoId != DBValues._DOCTO_ESTATUS_BORRADOR)
                            {
                                PosPrinter.ImprimirTicket(m_Docto.IID);
                            }

                            if (m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_BORRADOR && CurrentUserID.CurrentParameters.IESVENDEDORMOVIL != null && CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
                            {
                                  FinalizarVisitaPedido(true); // finaliza visita si es vendedor movil
                            }

                            IrANuevaVenta();
                        }
                        else
                        {
                            MessageBox.Show("ERRORES: " + pvd.IComentario.Replace("%", "\n"));
                            return false;
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


        private void IrANuevaVenta()
        {
            ResetearVariablesForm();
            ChecarActualizacionesPrecios();
            LimpiarTotalesPagosVenta();
            RefreshTotalesVenta();
            RefreshNumVenta();
            this.dSPuntoDeVentaAux.GRIDPV.Clear();
            FormatGrid();
            this.dSPuntoVenta.DETALLE_DE_PAGO.Clear();
            this.TBCommandLine.Text = "";
            this.LBCliente.Text = "MOSTRADOR";
            //this.lblClienteSuc.Text = "Cliente:";
            this.BTCliente.Text = "Cliente:";
            this.BTCliente.Enabled = true;
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


            lbClieNombre.Text = "";

            this.TBCantidad.Text = (CurrentUserID.CurrentParameters.ICAJASBOTELLAS.Equals("S") && CurrentUserID.CurrentUser.ICAJASBOTELLAS.Equals("S")) ? "0" : "1";
            this.TBCajas.Text = "0";


            /*
            if (m_manejaAlmacen)
            {
                this.ALMACENComboBox.Enabled = true;
                this.ALMACENComboBox.SelectedIndex = -1;
            }*/
            m_almacenTID = 0;


            checarCambiosPrecioMovil();

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


        private void NuevoRegistro()
        {
            if ((!(bool)m_Docto.isnull["IID"])
                && (m_estadoVenta != (int)estadoVenta.e_Cerrada && m_estadoVenta != (int)estadoVenta.e_Cancelada))
            {
                if (!CancelarVentaActual())
                    IrANuevaVenta();

            }
            else
                IrANuevaVenta();
        }



        private void BTPasarANueva_Click(object sender, EventArgs e)
        {
            NuevoRegistro();

        }

        private void BTAbrirVenta_Click(object sender, EventArgs e)
        {
            if (!(bool)m_Docto.isnull["IID"]
                && m_estadoVenta != (int)estadoVenta.e_Cancelada
                && m_estadoVenta != (int)estadoVenta.e_Cerrada)
            {
                CancelarVentaActual();
            }
            AbrirVenta();
            RefrescarEstatusBotones();
        }
        private void AbrirVenta()
        {
            IrANuevaVenta();
            //GeneralLookUp look = new GeneralLookUp("select * from VENTAS where GV_ESTATUS = '" + CVENTASD.strStatusAbierta + @"'", "VENTAS");
            WFLOOKUPVENTAS look = new WFLOOKUPVENTAS();
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                m_Docto.IID = int.Parse(dr[0].ToString());
                CDOCTOD vData = new CDOCTOD();
                m_Docto = vData.seleccionarDOCTO(m_Docto, null);
                RefrescarGridVentas();


                llenarDatosGeneralesDocto();
            }
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
                    if (SoloValidarProducto())
                    {
                        if (CurrentUserID.CurrentParameters.ICAJASBOTELLAS.Equals("S") && CurrentUserID.CurrentUser.ICAJASBOTELLAS.Equals("S"))
                        {
                            TBCajas.Focus();
                        }
                        else
                        {
                            TBCantidad.Focus();
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
       

        private void SeleccionarProducto()
        {
            SeleccionarProducto("");
        }
        private void SeleccionarProducto(string strDescripcion)
        {
            

            bool bBusquedaAnterior = strDescripcion == "" && this.strLastProductoSearch != null && this.strLastProductoSearch.Trim().Length > 0;
            string strLookUpDescripcion = (strDescripcion == "") ? ( (this.strLastProductoSearch != null && this.strLastProductoSearch.Trim().Length > 0 ) ?  this.strLastProductoSearch : "" ) : strDescripcion;

            this.strLastProductoSearch = strLookUpDescripcion;

            LOOKPROD look;
            look = new LOOKPROD(strLookUpDescripcion, !CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"), TipoProductoNivel.tp_hijos, m_ClienteId);
            
            
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


        private void BTCerrarVenta_Click(object sender, EventArgs e)
        {
            if (m_estadoVenta == (int)estadoVenta.e_Cerrada || m_estadoVenta == (int)estadoVenta.e_Cancelada)
                return;

            bool bEsVentaPendienteDesdeMovil = m_Docto != null && m_Docto.IID != 0 && m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_BORRADOR && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA && m_Docto.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_VENDMOVIL;
            if (bEsVentaPendienteDesdeMovil)
            {
                if (!VerificarValidezPrecios())
                    return;
            }

            PagarBasico(false);

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

            if (!eDBF.ExportarEnvioPedido(doctoid,CurrentUserID.CurrentUser,  null))
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
                                this.CerrarVenta(false, false,false);
                            }

                            wp.Dispose();
                            GC.SuppressFinalize(wp);
                        }
                        break;


                }

                this.Focus();
            }
        }




        private void PagarBasico(bool bPagoConVale)
        {


            //si hace falta asignar supervisor
            if (m_asignarsupervisor)
            {
                CDOCTOD doctoD = new CDOCTOD();
                m_Docto.ISUPERVISORID = m_supervisor.IID;
                doctoD.CambiarSupervisorAutorizacionDOCTOD(m_Docto, null);

                m_asignarsupervisor = false;
            }


            if(m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_BORRADOR)
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
                            if (m_Docto.ITOTAL > 0)
                            {

                                CDOCTOBE currentDocto = m_Docto;

                                //manejo de traspaso salida
                                long doctoVenta = 0;
                                bool bTraspasoFranquicia = false;
                                bool bResTraspasoFranquicia = false;
                                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO)
                                {
                                    CDOCTOD doctoD = new CDOCTOD();
                                    string esfranquicia = doctoD.GetFranquiciaSucursal(m_Docto, null);
                                    bTraspasoFranquicia  = esfranquicia.Equals("S");
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
                                }
                                // fin de manejo traspaso salida


                                WFPagosBasico wp;
                                if (m_formPagoVenta == null)
                                {
                                    wp = new WFPagosBasico(currentDocto, m_Caja, bPagoConVale, this.m_montoVentaConVale, this.m_DoctoRef, this.m_tipoTransaccion, esapartado, m_supervisor, false);
                                    wp.m_bCerrarVenta = !bTraspasoFranquicia;
                                    wp.m_bCerrarTraspasoSalida = bTraspasoFranquicia;
                                    wp.ShowDialog();
                                }
                                else
                                {
                                    wp = m_formPagoVenta;
                                }

                                if (wp.m_bPagoCompleto)
                                {
                                    m_Docto.IESTATUSDOCTOID = DBValues._DOCTO_ESTATUS_COMPLETO;
                                    if (m_formPagoVenta == null)
                                        m_formPagoVenta = wp;


                                    if (!ProcesarMonedero(wp.m_monedero, wp.m_monederoAplicado))
                                    {
                                        MessageBox.Show("Error al procesar el monedero");
                                        return;
                                    }


                                    if (bTraspasoFranquicia)
                                        CerrarTraspasoSalida(wp.m_generarFacturaElectronica, wp.m_bPagoPorxCredito, true);
                                    else
                                        this.CerrarVenta(wp.m_generarFacturaElectronica, wp.m_bPagoPorxCredito,true);
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
                                this.CerrarVenta(false, false,false);
                            }
                        }
                        break;

                    case tipoTransaccionV.t_devolucion:
                        {

                            WFPagosDevoluciones wp = new WFPagosDevoluciones(m_Docto, m_Caja, bPagoConVale, this.m_montoVentaConVale, this.m_DoctoRef, this.m_tipoTransaccion, esapartado, false);
                            wp.ShowDialog();
                            if (wp.m_bPagoCompleto)
                            {
                                this.CerrarVenta(false, false,false);
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
                            if(CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 2)
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

        private void CerrarVenta(bool generarFacturaElectronica, bool bEsCredito, bool bAlreadyClosedInDB)
        {
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();

            if(!bAlreadyClosedInDB)
                pvd.CerrarVenta(m_Docto, null);

            if (bAlreadyClosedInDB || pvd.IComentario == "" || pvd.IComentario == null)
            {


                if (generarFacturaElectronica)
                {
                    imprimirFacturaElectronica();
                }

                if (!generarFacturaElectronica || CurrentUserID.CurrentParameters.IRECIBOLARGOCONFACTURA.Equals("S"))
                {
                    PosPrinter.ImprimirTicket(m_Docto.IID);
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
                else if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA && !bEsCredito)
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


                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO)
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

                IrANuevaVenta();
                HiloExistencias._IFLAGENVIAREXISTENCIASEVENTOS++;
                this.TBCommandLine.Focus();
            }
            else
            {
                MessageBox.Show("ERRORES: " + pvd.IComentario.Replace("%", "\n"));
            }
        }




        private void CerrarTraspasoSalida(bool generarFacturaElectronica, bool bEsCredito, bool bAlreadyClosedInDB)
        {
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            CDOCTOD vData = new CDOCTOD();

            if (!bAlreadyClosedInDB)
                pvd.TRASPASOSALIDA_CERRARDOCTO(m_Docto, null);

            m_Docto = vData.seleccionarDOCTO(m_Docto, null);

            if (bAlreadyClosedInDB || pvd.IComentario == "" || pvd.IComentario == null)
            {


                if (generarFacturaElectronica)
                {
                    imprimirFacturaElectronicaPorId(m_Docto.IDOCTOREFID);
                }

                if (!generarFacturaElectronica || CurrentUserID.CurrentParameters.IRECIBOLARGOCONFACTURA.Equals("S"))
                {
                    PosPrinter.ImprimirTicket(m_Docto.IDOCTOREFID);
                }

                // imprimir segun el tipo
                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO)
                {

                    for (int iy = 0; iy < CurrentUserID.CurrentParameters.IDOBLECOPIATRASLADO - 1; iy++)
                    {
                        PosPrinter.ImprimirTicket(m_Docto.IDOCTOREFID);
                    }
                }



                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO)
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

            

            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            int errorCode = 0;
            m_Docto.IVENDEDORID = CurrentUserID.CurrentUser.IID;
            m_Docto.IVENDEDORFINAL = Int64.Parse(CurrentUserID.CurrentUser.IID.ToString());//long.Parse(this.ComboVendedorFinal.SelectedValue.ToString());
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
        private void WFMovilPuntoDeVenta_KeyDown(object sender, KeyEventArgs e)
        {
            
            switch (e.KeyCode)
            {
                case Keys.F6:
                    if (m_estadoVenta != (int)estadoVenta.e_Cerrada && m_estadoVenta != (int)estadoVenta.e_Cancelada)
                        PagarBasico(false);
                    break;
                case Keys.F5:
                    AbrirVentasCerradasYDevoluciones();
                    break;
                case Keys.F4:
                    if (!e.Alt)
                    {
                        AbrirVenta();
                        RefrescarEstatusBotones();
                    }
                    break;
                case Keys.F2:
                    IrANuevaVenta();
                    break;
                case Keys.F3:
                    if (m_estadoVenta != (int)estadoVenta.e_Cancelada)
                        CancelarVentaActual();
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
                    if(e.Modifiers == Keys.Control)
                    {
                        if (m_estadoVenta == (int)estadoVenta.e_Cerrada && m_estadoVenta != (int)estadoVenta.e_Cancelada)
                        {
                            if (generarFacturaElectronica())
                            {

                                MessageBox.Show("Se facturo");
                                imprimirFacturaElectronica();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo facturar");
                            }
                        }
                    }
                    break;


                case Keys.Escape:
                    this.Close();
                    break;

                default:
                    break;
            }
        }



        private bool generarFacturaElectronica()
        {

            
            CUSUARIOSD usuariosD = new CUSUARIOSD();
            if(!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_REMISIONAFACTURA , null))
            {
                MessageBox.Show("No tiene derecho para cambiar una remision ya hecha a factura");
                return false;
            }

            if(m_Docto.IFECHAHORA.Month != DateTime.Now.Month)
            {
                if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_FACTURARFUERADEMES, null))
                {
                    MessageBox.Show("No tiene derecho para facturar una remision fuera de este mes");
                    return false;
                }
            }
            
            

            bool retorno = false;


            CDOCTOPAGOBE pagoTemporal = new CDOCTOPAGOBE();
            CDOCTOPAGOD doctoPagoD = new CDOCTOPAGOD();

            pagoTemporal = doctoPagoD.seleccionarPrimerDOCTOPAGO(m_Docto, null);

            iPosReporting.WFFacturaElectronica fe = new iPosReporting.WFFacturaElectronica(this.m_Docto, CurrentUserID.CurrentParameters, WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_TIMBRAR, this.m_DoctoRef, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
            fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
            fe.ShowDialog();
            retorno = fe.m_facturacionRealizada;
            fe.Dispose();
            GC.SuppressFinalize(fe);

            if(retorno)
            {
                CDOCTOD doctoD =new CDOCTOD();
                m_Docto.IESFACTURAELECTRONICA = "S";
                doctoD.ACTUALIZARESFACTURAELECTRONICA(m_Docto, null);
            }

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
            CUSUARIOSD usuariosD = new CUSUARIOSD(); fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
            fe.ShowDialog();
            retorno = fe.m_facturacionRealizada;
            fe.Dispose();
            GC.SuppressFinalize(fe);
            return retorno;
        }


        private bool imprimirFacturaElectronicaPorId(long doctoId)
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


            WFFacturaElectronica fe = new WFFacturaElectronica(doctoBE, CurrentUserID.CurrentParameters, WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_GENERARPDF, this.m_Docto, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
            CUSUARIOSD usuariosD = new CUSUARIOSD(); fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
            fe.ShowDialog();
            retorno = fe.m_facturacionRealizada;
            fe.Dispose();
            GC.SuppressFinalize(fe);
            return retorno;

        }


        

        private void WFMovilPuntoDeVenta_Shown(object sender, EventArgs e)
        {
            this.TBCommandLine.Focus();



        }

        private void WFMovilPuntoDeVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_bSalirSinPreguntar)
                return;

            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            DateTime fechaCorte = DateTime.MinValue;
            if (!pvd.HayCorteActivo(ref fechaCorte, iPos.CurrentUserID.CurrentUser.IID))
                return;

            if (!(bool)m_Docto.isnull["IID"]
                && m_estadoVenta != (int)estadoVenta.e_Cancelada
                && m_estadoVenta != (int)estadoVenta.e_Cerrada)
            {
                CancelarVentaActual();
            }

            if (!CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
                if (MessageBox.Show("Realmente quiere salir de esta pantalla?", "Salir de esta pantalla", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    e.Cancel = true;


        }


        private void RefreshCurrentItemDisplay(int iRowIndex)
        {
            LimpiarCurrentItemDisplay();


            if (!(bool)CurrentUserID.CurrentParameters.isnull["IMOSTRARIMAGENENVENTA"] && CurrentUserID.CurrentParameters.IMOSTRARIMAGENENVENTA.Equals("S"))
            {
                string imagePath = "";
                if (this.gridPVDataGridView.Rows[iRowIndex].Cells["IMAGEN"].Value != null && this.gridPVDataGridView.Rows[iRowIndex].Cells["IMAGEN"].Value.ToString() != "")
                {
                    imagePath = CurrentUserID.CurrentParameters.IRUTAIMAGENESPRODUCTO + "\\" + this.gridPVDataGridView.Rows[iRowIndex].Cells["IMAGEN"].Value.ToString();
                }
                else
                {
                    imagePath = System.AppDomain.CurrentDomain.BaseDirectory + "\\sampdata\\facturaelectronica\\IMG\\logofarmafree.png";
                }

            }


            if (this.gridPVDataGridView.Rows[iRowIndex].Cells["DESCRIPCION2"].Value != null && this.gridPVDataGridView.Rows[iRowIndex].Cells["DESCRIPCION2"].Value.ToString() != "")
                this.tbCurrentItem.Text += this.gridPVDataGridView.Rows[iRowIndex].Cells["DESCRIPCION2"].Value.ToString();


            if (this.gridPVDataGridView.Rows[iRowIndex].Cells["LOTE"].Value != null && this.gridPVDataGridView.Rows[iRowIndex].Cells["LOTE"].Value.ToString() != "")
                this.tbCurrentItem.Text += this.gridPVDataGridView.Rows[iRowIndex].Cells["LOTE"].Value.ToString();

            if (this.gridPVDataGridView.Rows[iRowIndex].Cells["TEXTO1"].Value != null && 
                this.gridPVDataGridView.Rows[iRowIndex].Cells["TEXTO1"].Value.ToString() != "" &&
                 !(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO1"] &&
                !CurrentUserID.CurrentParameters.ITEXTO1.Trim().Equals("") )
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
                /*WFPreguntaAutorizacion ps = new WFPreguntaAutorizacion();
                ps.ShowDialog();
                if (!ps.m_bPassValido)
                    return;

                if (!ps.m_bIsSupervisor)
                {
                    MessageBox.Show("El usuario no es un supervisor");
                    return;
                }*/
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
                RefrescarGridVentas();
            }
            RefrescarEstatusBotones();
            this.TBCommandLine.Focus();

        }

        private void BTEliminarDetalle_Click(object sender, EventArgs e)
        {

            if (m_estadoVenta == (int)estadoVenta.e_Cerrada || m_estadoVenta == (int)estadoVenta.e_Cancelada)
                return;

            EliminarDetalle();
        }

        private void RefrescarEstatusBotones()
        {
            this.btEditarVenta.Visible = false;
            this.btEditarVenta.BackColor = Color.Gray;
            btnCobranzaMovil.Visible = false;
            btnCobranzaMovil.BackColor = Color.Gray;

            if (!(bool)m_Docto.isnull["IID"] && gridPVDataGridView.Rows.Count > 0)
            {
                this.BTPasarANueva.Enabled = true;
                this.BTPasarANueva.BackColor = Color.FromArgb(41, 121, 255);
                this.BTPasarANueva.ForeColor = Color.Black;
                this.BTCancelarVenta.Enabled = true;
                this.BTCancelarVenta.BackColor = Color.FromArgb(219, 44, 44);
                this.BTCancelarVenta.ForeColor = Color.Black;
                this.BTCerrarVenta.Enabled = true;
                this.BTCerrarVenta.BackColor = Color.FromArgb(74, 196, 77);
                this.BTCerrarVenta.ForeColor = Color.Black;
                this.BTRecalcular.Enabled = true;


                if (!(m_Docto.IPERSONAID == DBValues._CLIENTEMOSTRADOR || m_ClienteId == DBValues._CLIENTEMOSTRADOR)
                    && (m_Docto.IPERSONAID > 0 && m_ClienteId > 0) && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTAMOVIL)
                    btnCobranzaMovil.Visible = true;
                else
                {
                    btnCobranzaMovil.Visible = false;
                    btnCobranzaMovil.BackColor = Color.Gray;
                }
                    


                // 
                this.gridPVDataGridView.Columns["TOTALVALE"].Visible = true;



            }
            else
            {
                this.BTPasarANueva.Enabled = false;
                this.BTPasarANueva.BackColor = Color.Gray;
                this.BTCancelarVenta.Enabled = false;
                this.BTCancelarVenta.BackColor = Color.Gray;
                this.BTCerrarVenta.Enabled = false;
                this.BTCerrarVenta.BackColor = Color.Gray;
                this.BTRecalcular.Enabled = false;
                this.BTRecalcular.BackColor = Color.Gray;
                this.gridPVDataGridView.Columns["TOTALVALE"].Visible = false;
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
                this.btnListaAdjuntos.BackColor = Color.FromArgb(41, 121, 255);
                this.btnListaAdjuntos.ForeColor = Color.Black;
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

        }


        private void AbrirVentasCerradasYDevoluciones()
        {
            IrANuevaVenta();

            CUSUARIOSD usuariosD = new CUSUARIOSD();
            WFLOOKUPVENTAS look = new WFLOOKUPVENTAS((int)DBValues._DOCTO_ESTATUS_COMPLETO, 0);
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                m_Docto.IID = int.Parse(dr[0].ToString());
                CDOCTOD vData = new CDOCTOD();
                m_Docto = vData.seleccionarDOCTO(m_Docto, null);

                if (m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_CANCELADA || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_CANCELACION)
                    m_estadoVenta = (int)estadoVenta.e_Cancelada;
                else
                {
                    if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTAAPARTADO || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_PEDIDO_TRASPASO_SALIDA || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ALMACEN /*|| m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTAMOVIL*/)
                    {
                        this.BTCancelarVenta.Enabled = true;
                        this.BTCancelarVenta.ForeColor = Color.Black;
                        this.BTCancelarVenta.BackColor = Color.FromArgb(219, 44, 44);
                    }
                    else
                    {
                        this.BTCancelarVenta.Enabled = false;
                        this.BTCancelarVenta.BackColor = Color.Gray;
                    }
                    m_estadoVenta = (int)estadoVenta.e_Cerrada;
                }

                RefrescarGridVentas();

                this.gridPVDataGridView.BackgroundColor = Color.Gainsboro;
                this.gridPVDataGridView.DefaultCellStyle.BackColor = Color.Gainsboro;
                this.TBCommandLine.Enabled = false;




                //traslados
                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_PEDIDO_TRASPASO_SALIDA)
                {
                    try
                    {
                        LBCliente.Text = dr["SUCURSALDESTINO"].ToString();
                    }
                    catch
                    {
                    }
                }
                
                // boton cliente y recalculo
                if (m_Docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_BORRADOR)
                {
                    this.BTRecalcular.Enabled = false;
                    this.BTCliente.Enabled = false;
                }
                else
                {
                    this.BTRecalcular.Enabled = true;
                    this.BTCliente.Enabled = true;
                }




                


                this.BTPasarANueva.Enabled = true;
                this.BTPasarANueva.BackColor = Color.FromArgb(41, 121, 255);
                this.BTPasarANueva.ForeColor = Color.Black;
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
                this.gridPVDataGridView.Columns["TOTALVALE"].Visible = false;

                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTAMOVIL && 
                    m_Docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_CANCELADA /*&&
                    m_Docto.ITRASLADOAFTP != DBValues._DB_BOOLVALUE_SI*/)
                {
                    this.btEditarVenta.Visible = true;
                    this.btEditarVenta.ForeColor = Color.Black;
                    this.btEditarVenta.BackColor = Color.FromArgb(41, 121, 255);
                }
                else
                {
                    this.btEditarVenta.Visible = false;
                    this.btEditarVenta.BackColor = Color.Gray;
                }


                BTValidarExistencia.Visible = false;
                BTValidarExistencia.BackColor = Color.Gray;

                

                if ((m_Docto.ISUBTIPODOCTOID == 7 || m_Docto.ISUBTIPODOCTOID == 8) && (!(bool)m_Docto.isnull["IDOCTOREFID"]))
                {
                    CDOCTOD doctoDAux = new CDOCTOD();
                    CDOCTOBE doctoBEAux = new CDOCTOBE();

                    doctoBEAux.IID = m_Docto.IDOCTOREFID;
                    doctoBEAux = doctoDAux.seleccionarDOCTO(doctoBEAux, null);
                    
                }


                llenarDatosGeneralesDocto();


            }
        }

        private void llenarDatosGeneralesDocto()
        {


            if (!(bool)m_Docto.isnull["IPERSONAID"])
            {
                this.m_ClienteId = m_Docto.IPERSONAID;
                llenarDatosCliente();
            }

            if (!(bool)m_Docto.isnull["ITIPODOCTOID"] && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_PEDIDO_TRASPASO_SALIDA || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO)
            {
                llenarDatosSucursalDestino();
            }

            if (!(bool)m_Docto.isnull["IFOLIO"])
            {
                this.LBVenta.Text = m_Docto.IFOLIO.ToString();
            }

            
        }


        private void BTAbrirCerradasYDevo_Click(object sender, EventArgs e)
        {
            AbrirVentasCerradasYDevoluciones();
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
                this.BTCliente.Text = "SUC_DEST:";
                this.BTCliente.Enabled = false;
                m_ClienteId = DBValues._CLIENTEMOSTRADOR;

                LBCliente.Text = dr[6].ToString();
                retorno = true;
            }
            

            return retorno;
        }


        private void ModoTraslado()
        {

            CUSUARIOSD usuariosD = new CUSUARIOSD();
            if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_AGREGAR_TRASLADOS, null))
            {
                MessageBox.Show("No tiene permisos para hacer traslados");
                return;
            }

            NuevoRegistro();
            if (!SeleccionarSucursalTID(CurrentUserID.CurrentParameters.ISUCURSALID))
                return;

            m_Docto.ITIPODOCTOID = DBValues._DOCTO_TIPO_TRASPASO_ENVIO;
            this.BTPasarANueva.Enabled = true;
            this.BTPasarANueva.BackColor = Color.FromArgb(41, 121, 255);
            this.BTPasarANueva.ForeColor = Color.Black;

        }





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


        private decimal calculaPrecioSinImpuestos(decimal precioConImpuestos, decimal dTasaIva, decimal dTasaIeps)
        {

            decimal dPrecioSinImpuestos = (precioConImpuestos / (1 + (dTasaIva / 100))) / (1 + (dTasaIeps / 100));
            return Math.Round(dPrecioSinImpuestos,2);


        }
        private decimal calculaPrecioConImpuestos( decimal precioSinImpuestos, decimal dTasaIva, decimal dTasaIeps)
        {

            decimal precioConImpuesto = (precioSinImpuestos * ( 1 + (dTasaIeps / 100))) * (1 + (dTasaIva / 100));
            return Math.Round(precioConImpuesto,2);


        }

        private void TBCommandLine_Validated(object sender, EventArgs e)
        {
            TBDescuento.Text = "";
            TBPrecioCaja.Text = "";
            PonerPrecioEnPantalla();

        }

        private void PonerPrecioEnPantalla()
        {

            if ( !this.m_bPermisoCambiarPrecioxLista && !this.m_bPermisoCambiarPrecio)
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

            DecifrarComando(TBCommandLine.Text, ref prod, ref  cantidad, ref bPreguntaCantidad, ref pvd);

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





                    if (pvd.GET_PRECIOS_PRODUCTO_LISTA(productoId, clienteId, cantidad, sucursalTId, ref  precioLista, ref precioTraspaso, ref  precioMinimo, ref  costo, null))
                {
                    if (precioLista.HasValue)
                    {
                        if ((bool)CurrentUserID.CurrentParameters.isnull["IPRECIONETOENPV"] || !CurrentUserID.CurrentParameters.IPRECIONETOENPV.Equals("S"))
                        {
                            this.TBPrecio.Text = (precioLista / tipoCambio).ToString();
                            
                            try
                            {
                                this.TBPrecioCaja.Text = ((decimal)precioLista * pzaCaja / tipoCambio).ToString("N2");
                                this.TBDescuento.Text = (100 - ((100 * (decimal)precioLista) / prod.IPRECIO1)).ToString("N2");
                            }
                            catch
                            {

                            }
                        }
                        else
                        {
                            decimal dNuevoPrecio = calculaPrecioConImpuestos(precioLista.Value, prod.ITASAIVA, prod.ITASAIEPS);
                            decimal dPrecioBase = calculaPrecioConImpuestos(prod.IPRECIO1, prod.ITASAIVA, prod.ITASAIEPS);
                            this.TBPrecio.Text = (dNuevoPrecio / tipoCambio).ToString();

                            try
                            {
                                this.TBPrecioCaja.Text = (dNuevoPrecio * pzaCaja / tipoCambio).ToString("N2");
                                this.TBDescuento.Text = (100 - ((100 * dNuevoPrecio) / dPrecioBase)).ToString("N2");
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
                        ListaPrecios.Items.Add("Precio 1:" + (prod.IPRECIO1 / tipoCambio).ToString("N2"));
                    }
                    if (!(bool)prod.isnull["IPRECIO2"] && CurrentUserID.CurrentUser.ILISTAPRECIOID >= 2)
                    {
                        ListaPrecios.Items.Add("Precio 2:" + (prod.IPRECIO2 / tipoCambio).ToString("N2"));
                    }
                    if (!(bool)prod.isnull["IPRECIO3"] && CurrentUserID.CurrentUser.ILISTAPRECIOID >= 3)
                    {
                        ListaPrecios.Items.Add("Precio 3:" + (prod.IPRECIO3 / tipoCambio).ToString("N2"));
                    }
                    if (!(bool)prod.isnull["IPRECIO4"] && CurrentUserID.CurrentUser.ILISTAPRECIOID >= 4)
                    {
                        ListaPrecios.Items.Add("Precio 4:" + (prod.IPRECIO4 / tipoCambio).ToString("N2"));
                    }
                    if (!(bool)prod.isnull["IPRECIO5"] && CurrentUserID.CurrentUser.ILISTAPRECIOID >= 5)
                    {
                        ListaPrecios.Items.Add("Precio 5:" + (prod.IPRECIO5 / tipoCambio).ToString("N2"));
                    }

                }
                else
                {

                }


            }
        }



        private void TBPrecio_KeyDown(object sender, KeyEventArgs e)
        {

            if (m_estadoVenta == (int)estadoVenta.e_Cerrada || m_estadoVenta == (int)estadoVenta.e_Cancelada)
                return;

            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {

                ProcessCommand(false, false, true);
                TBCommandLine.Focus();

            }
            else if (e.KeyCode == System.Windows.Forms.Keys.Down && m_bPermisoCambiarPrecioxLista /*&& TBPrecio.ReadOnly == false*/ )
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

        private void TBPrecio_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

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
                    if (dEntrada == 0)
                        return;
                    if (dNuevaCantidad <= 0)
                    {
                        MessageBox.Show("La cantidad  no puede ser menor o igual a cero, si requiere cancelar el detalle porfavor seleccione 'Eliminar detalle'");
                        e.Cancel = true;
                    }
                    else
                    {


                        decimal dNuevoPrecio = decimal.Parse(gridPVDataGridView.Rows[e.RowIndex].Cells["PRECIOUNIDAD"].Value.ToString());
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

                        decimal dPrecioSinIva;
                        if ((bool)CurrentUserID.CurrentParameters.isnull["IPRECIONETOENPV"] || !CurrentUserID.CurrentParameters.IPRECIONETOENPV.Equals("S"))
                            dPrecioSinIva = calculaPrecioSinImpuestos(dNuevoPrecio, dTasaIva, dTasaIeps);//(dNuevoPrecio / (1 + (dTasaIva / 100))) / (1 + (dTasaIeps / 100));
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


                        if (CurrentUserID.CurrentParameters.ICAJASBOTELLAS.Equals("S") && CurrentUserID.CurrentUser.ICAJASBOTELLAS.Equals("S"))
                        {
                            TBCommandLine.Text =  gridPVDataGridView.Rows[e.RowIndex].Cells["GVCLAVEPRODUCTO"].Value.ToString();
                            TBCajas.Text = "0";
                            TBCantidad.Text = dEntrada.ToString("N3");
                        }
                        else
                        {
                            TBCommandLine.Text = dEntrada.ToString("N3") + "*" + gridPVDataGridView.Rows[e.RowIndex].Cells["GVCLAVEPRODUCTO"].Value.ToString();
                        }
                        
                        TBPrecio.Text = dPrecioSinIva.ToString("0.00");
                        TBDescuento.Text = gridPVDataGridView.Rows[e.RowIndex].Cells["DESCUENTOPORCENTAJE"].Value.ToString();


                        long? P_MOVTOID = (long)gridPVDataGridView.Rows[e.RowIndex].Cells["MOVTOID"].Value;

                        bool bRes = dDescuentoManual == 0 ? ProcessCommand(false, false, P_MOVTOID, true) : ProcessCommand(true, false, P_MOVTOID, false);

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
                    decimal dNuevoPrecio = decimal.Parse(e.FormattedValue.ToString());
                    decimal dViejoPrecio = decimal.Parse(gridPVDataGridView.Rows[e.RowIndex].Cells["PRECIOUNIDAD"].Value.ToString());


                    if (dNuevoPrecio == dViejoPrecio)
                        return;

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

                    decimal dPrecioSinIva;
                    if ((bool)CurrentUserID.CurrentParameters.isnull["IPRECIONETOENPV"] || !CurrentUserID.CurrentParameters.IPRECIONETOENPV.Equals("S"))
                        dPrecioSinIva = calculaPrecioSinImpuestos(dNuevoPrecio, dTasaIva, dTasaIeps);//(dNuevoPrecio / (1 + (dTasaIva / 100))) / (1 + (dTasaIeps / 100));
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
                        TBDescuento.Text = gridPVDataGridView.Rows[e.RowIndex].Cells["DESCUENTOPORCENTAJE"].Value.ToString();

                        long? P_MOVTOID = (long)gridPVDataGridView.Rows[e.RowIndex].Cells["MOVTOID"].Value;
                        if (!ProcessCommand(false, false, P_MOVTOID, true))
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
                    decimal dNuevoPrecio = decimal.Parse(gridPVDataGridView.Rows[e.RowIndex].Cells["PRECIOUNIDAD"].Value.ToString()); 
                    decimal dNuevoDescuento = decimal.Parse(e.FormattedValue.ToString());
                    decimal dViejoDescuento = decimal.Parse(gridPVDataGridView.Rows[e.RowIndex].Cells["DESCUENTOPORCENTAJE"].Value.ToString());


                    if (dNuevoDescuento == dViejoDescuento)
                        return;

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

                    decimal dPrecioSinIva;
                    if ((bool)CurrentUserID.CurrentParameters.isnull["IPRECIONETOENPV"] || !CurrentUserID.CurrentParameters.IPRECIONETOENPV.Equals("S"))
                        dPrecioSinIva = calculaPrecioSinImpuestos(dNuevoPrecio, dTasaIva, dTasaIeps);//(dNuevoPrecio / (1 + (dTasaIva / 100))) / (1 + (dTasaIeps / 100));
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
                        TBDescuento.Text = dNuevoDescuento.ToString("0.00");//gridPVDataGridView.Rows[e.RowIndex].Cells["TITULOSTOTALES"].Value.ToString();

                        long? P_MOVTOID = (long)gridPVDataGridView.Rows[e.RowIndex].Cells["MOVTOID"].Value;
                        if (!ProcessCommand(true, false, P_MOVTOID,false))
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



        private void SeleccionaCliente()
        {
            iPos.Catalogos.WFClientes look = new iPos.Catalogos.WFClientes();
            look.m_bSelecionarRegistro = true;
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            
            //validar credito
            if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTAMOVIL)
            {

                try
                {
                    if (dr["REFERENCIAMOVIL"] != DBNull.Value && dr["REFERENCIAMOVIL"].ToString().Trim() != "" && dr["REFERENCIAMOVIL"].ToString().Trim() != "N")
                    {
                        MessageBox.Show("Datos adicionales del cliente : "  + dr["REFERENCIAMOVIL"].ToString().Trim());
                    }
                }
                catch
                {
                }

                try
                {
                    if (dr["BLOQUEADO"].ToString().Trim().Equals("S") && (long)dr["ID"] > 1)
                    {
                        if (dr["BLOQUEONOT"] != DBNull.Value)
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


                if (dr != null)
                {
                    btnCobranzaMovil.Visible = true;
                }
                

            }
            else
            {

                try
                {
                    if (dr["STATUSSALDO"].ToString().Trim().Equals("BLOQUEADO") && (long)dr["ID"] > 1)
                    {
                        MessageBox.Show("No puede seleccionar un cliente que este bloqueado");
                        return;
                    }
                    else if (dr["STATUSSALDO"].ToString().Trim().Equals("EXCEDIDO") && (long)dr["ID"] > 1)
                    {

                        CUSUARIOSD usuariosD = new CUSUARIOSD();
                        long autorizadorId = CurrentUserID.CurrentUser.IID;
                        if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_VENDERCONCREDITOEXCEDIDO, null))
                        {
                            WFPreguntaAutorizacion ps2 = new WFPreguntaAutorizacion();
                            ps2.m_requiereAdminOrSupervisor = false;
                            if (MessageBox.Show("No tiene derecho para vender a un cliente con credito excedido. Quiere ingresar autorizacion de un supervisor?", "Credido excedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
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


                        if (m_Docto != null && (!(bool)m_Docto.isnull["IID"]))
                        {
                            if (!PreguntaComentarioAutorizacion(m_Docto.IID, autorizadorId, null))
                            {

                                MessageBox.Show("Debe agregar un comentario de autorizacion");
                                return;
                            }

                        }
                    }
                }
                catch
                {
                    return;
                }

            }




            if (dr != null)
            {
                this.LBCliente.Text = dr["CLAVE"].ToString().Trim();
                m_ClienteId = (long)dr["ID"];

                llenarDatosCliente();

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
                this.TBCommandLine.Focus();
            }
            look.Dispose();
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
                CDOCTOD doctoD = new CDOCTOD();
                doctoD.CambiarDOCTONOTASET(doctoId, DBValues._TIPODOCTONOTA_AUTORIZACION, DateTime.Now, usuarioId, comentarioAut, null);

                return true;
            }

            return false;

        }

        private void BTCliente_Click(object sender, EventArgs e)
        {
            SeleccionaCliente();
        }



        private void HabilitarBotonesOpcionales()
        {
            if (!(bool)CurrentUserID.CurrentParameters.isnull["IHAB_SEL_CLIENTE"])
            {
                this.BTCliente.Visible = (CurrentUserID.CurrentParameters.IHAB_SEL_CLIENTE == DBValues._DB_BOOLVALUE_SI);
            }
            else
            {
                this.BTCliente.Visible = false;
            }


        }

        private void gridPVDataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {

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

                LBCliente.Text = sucursalBE.ICLAVE;
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
                
                if(visitaBE == null || visitaBE.IPERSONAID != m_ClienteId)
                {
                    if(visitaBE != null)
                    {

                        bool bVisitaEliminada = false;
                       if(visitaD.cantidadDoctosEnVisita(visitaBE, null) == 0)
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
                    personaBE = personaD.seleccionarPERSONA(personaBE,null);

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
                    if(preguntar)
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
            CPERSONAD clienteD = new CPERSONAD();
            CPERSONABE clienteBE = new CPERSONABE();
            clienteBE.IID = m_ClienteId;
            clienteBE = clienteD.seleccionarPERSONA(clienteBE, null);

            
                if (clienteBE != null)
                {
                    LBCliente.Text = clienteBE.ICLAVE;
                    lbClieNombre.Text = ((bool)clienteBE.isnull["INOMBRE"]) ? "" : clienteBE.INOMBRE;
                    if (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL != null && CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S") &&
                        (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL <= 1 || CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 4))
                    {
                        lblSaldo.Text = ((bool)clienteBE.isnull["ISALDOMOVIL"]) ? "" : clienteBE.ISALDOMOVIL.ToString("N2");
                        lblSaldoVencido.Text = ((bool)clienteBE.isnull["ISALDOVENCIDOMOVIL"]) ? "" : clienteBE.ISALDOVENCIDOMOVIL.ToString("N2");
                        lblLimite.Text = ((bool)clienteBE.isnull["ILIMITECREDITO"]) ? "" : clienteBE.ILIMITECREDITO.ToString("N2");
                        lblAbonos.Text = clienteD.selectSumaPagoMovil(m_ClienteId, null).ToString();
                    }

                }
                else
                {

                    lbClieNombre.Text = "";
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
                    TBDescuento.Text = this.gridPVDataGridView.CurrentRow.Cells["DESCUENTOPORCENTAJE"].Value.ToString();

                    long? P_MOVTOID = (long)this.gridPVDataGridView.CurrentRow.Cells["MOVTOID"].Value;
                    if (!ProcessCommand(false, false, P_MOVTOID,true))
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
                    LBCliente.Text = clienteBE.ICLAVE;
                }

                this.BTCliente.Enabled = false;
                this.BTCliente.BackColor = Color.Gray;
                this.BTRecalcular.Enabled = false;
                this.BTRecalcular.BackColor = Color.Gray;

                this.BTPasarANueva.Enabled = true;
                this.BTPasarANueva.BackColor = Color.FromArgb(41, 121, 255);
                this.BTPasarANueva.ForeColor = Color.Black;
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
                this.BTRecalcular.BackColor = Color.Gray;
                this.gridPVDataGridView.Columns["TOTALVALE"].Visible = false;

                

                m_Docto.ITIPODOCTOID = DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO;
                m_Docto.IDOCTOREFID = this.m_DoctoRef.IID;
                m_Docto.IPERSONAID = this.m_DoctoRef.IPERSONAID;
                this.m_ClienteId = this.m_DoctoRef.IPERSONAID;



            }
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



        private void DescripcionesDeProductoEnDataSet(long productoId, ref string desc1, ref string desc2, ref string desc3)
        {
            foreach (iPos.PuntoDeVenta.DSPuntoDeVentaAux.GRIDPVRow dr in dSPuntoDeVentaAux.GRIDPV.Rows)
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
                    //this.label19.Focus();
                }
                else
                {
                    TBPrecio.Focus();
                }
            }
        }

        private void TBCantidad_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

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
                this.BTCliente.Text = "ALM_DEST:";
                this.BTCliente.Enabled = false;
                m_ClienteId = DBValues._CLIENTEMOSTRADOR;

                LBCliente.Text = look.m_destino;

            


                retorno = true;
            }

            look.Dispose();

            return retorno;
        }


        private void ModoTraspasoAlmacenes()
        {

            CUSUARIOSD usuariosD = new CUSUARIOSD();
            /*if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_AGREGAR_TRASLADOS, null))
            {
                MessageBox.Show("No tiene permisos para hacer traslados");
                return;
            }*/

            NuevoRegistro();
            if (!this.SeleccionarAlmacenTID())
                return;

            m_Docto.ITIPODOCTOID = DBValues._DOCTO_TIPO_TRASPASO_ALMACEN;
            this.BTPasarANueva.Enabled = true;
            this.BTPasarANueva.BackColor = Color.FromArgb(41, 121, 255);
            this.BTPasarANueva.ForeColor = Color.Black;


            m_tipoTransaccion = tipoTransaccionV.t_traspasoalmacen;
        }

        private void BTTraspasoAlmacenes_Click(object sender, EventArgs e)
        {
            ModoTraspasoAlmacenes();
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


        private void TBCajas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                TBCantidad.Focus();
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
                else if(CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 1)
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


                        //en caso de vendedor movil 3, actualiza la existencia
                        if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 3 || CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 4)
                        {
                            foreach (CM_PROPBE prod in prods)
                            {
                                CPRODUCTOBE prodBE = new CPRODUCTOBE();
                                CPRODUCTOD prodD = new CPRODUCTOD();
                                prodBE.ICLAVE = prod.IPRODUCTO;

                                prodBE = prodD.seleccionarPRODUCTOxCLAVE(prodBE, null);

                                if (prodBE == null)
                                    continue;

                                if (prod.IEXIS1 != prodBE.IEXISTENCIA)
                                {
                                    if (!prodD.CambiarExistenciaMovilPRODUCTOD(prodBE.IID, prod.IEXIS1, null))
                                        break;
                                }

                                string strCantidad = "";
                                if (prod.IBOTCAJA > 1)
                                {
                                    decimal bufferCajas = Math.Floor(prod.IEXIS1 / prod.IBOTCAJA);
                                    decimal bufferPzasSueltas = prod.IEXIS1 - (prod.IBOTCAJA * bufferCajas);

                                    strCantidad = bufferCajas.ToString("N0") + " CJA " + bufferPzasSueltas.ToString() + " PZA";
                                }
                                else
                                {
                                    strCantidad = prod.IEXIS1.ToString("N0") + " PZA";
                                }

                                CurrentUserID.UpdataAutoCompleteExistenceSingleProduct(prodBE.ICLAVE, strCantidad);
                            }
                        }




                        if (!productoHayado || flagFaltaExistencia)
                        {

                            WFValidacionExistenciasMovil form = new WFValidacionExistenciasMovil(m_Docto, TipoValidacionMovil.porExistencia, prods, null);
                            form.ShowDialog();
                            form.Dispose();
                            GC.SuppressFinalize(form);
                            bFormShown = true;


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


            CDOCTOD doctoD = new CDOCTOD();

            if (MessageBox.Show("¿Seguro quiere modificar la venta?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

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
                    DecifrarComando(TBCommandLine.Text, ref prod, ref  cantidad, ref bPreguntaCantidad, ref pvd);
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
                            descuento = 100 - ((100 * precioXPza)/precioLista);

                        }
                        else
                        {
                            decimal dNuevoPrecio = calculaPrecioConImpuestos(precioLista, prod.ITASAIVA, prod.ITASAIEPS);

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

            try
            {
                if (row.Cells["DGALERTA"].Value != DBNull.Value)
                {
                    color = row.Cells["DGALERTA"].Value.ToString().Trim();
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
                }

            }
            catch
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

            DecifrarComando(TBCommandLine.Text, ref prod, ref  cantidad, ref bPreguntaCantidad, ref pvd);

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
                            decimal dNuevoPrecio = calculaPrecioConImpuestos(precioLista.Value, prod.ITASAIVA, prod.ITASAIEPS);

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

            if (gridPVDataGridView.Columns["GVCANTIDAD"].Index == e.ColumnIndex)
            {
                if (CurrentUserID.CurrentParameters.ICAJASBOTELLAS.Equals("S") && CurrentUserID.CurrentUser.ICAJASBOTELLAS.Equals("S"))
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

                        /*if (dPiezaCaja == 1)
                            return;*/

                        WFDialogCajaPza dlg_ = new WFDialogCajaPza(dViejaCantidad, dPiezaCaja);
                        dlg_.ShowDialog();
                        bool huboCambio = dlg_.huboCambio;
                        decimal dCantidadTotalFinal = dlg_.dCantidadTotalFinal;
                        dlg_.Dispose();
                        GC.SuppressFinalize(dlg_);


                        if (huboCambio)
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


                                decimal dNuevoPrecio = decimal.Parse(gridPVDataGridView.Rows[e.RowIndex].Cells["PRECIOUNIDAD"].Value.ToString());
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

                                decimal dPrecioSinIva;
                                if ((bool)CurrentUserID.CurrentParameters.isnull["IPRECIONETOENPV"] || !CurrentUserID.CurrentParameters.IPRECIONETOENPV.Equals("S"))
                                    dPrecioSinIva = calculaPrecioSinImpuestos(dNuevoPrecio, dTasaIva, dTasaIeps);//(dNuevoPrecio / (1 + (dTasaIva / 100))) / (1 + (dTasaIeps / 100));
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


                                if (CurrentUserID.CurrentParameters.ICAJASBOTELLAS.Equals("S") && CurrentUserID.CurrentUser.ICAJASBOTELLAS.Equals("S"))
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
                                TBDescuento.Text = gridPVDataGridView.Rows[e.RowIndex].Cells["DESCUENTOPORCENTAJE"].Value.ToString();


                                long? P_MOVTOID = (long)gridPVDataGridView.Rows[e.RowIndex].Cells["MOVTOID"].Value;

                                bool bRes = dDescuentoManual == 0 ? ProcessCommand(false, false, P_MOVTOID, true) : ProcessCommand(true, false, P_MOVTOID, false);

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
            WFCobranzaMovil wf = new WFCobranzaMovil(false, LBCliente.Text);
            wf.ShowDialog();
        }

        private void btnClearCommand_Click(object sender, EventArgs e)
        { 
            this.TBCommandLine.Text = "";
            this.TBCantidad.Text = (CurrentUserID.CurrentParameters.ICAJASBOTELLAS.Equals("S") && CurrentUserID.CurrentUser.ICAJASBOTELLAS.Equals("S")) ? "0" : "1";
            this.TBCajas.Text = "0";
            this.TBPrecio.Text = "";
            this.TBDescuento.Text = "";
            this.TBPrecioCaja.Text = "";
            TBCommandLine.Focus();
        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LBCliente_Click(object sender, EventArgs e)
        {

        }

        private void lbClieNombre_Click(object sender, EventArgs e)
        {

        }







        private void TBCommandLine_KeyUp_1(object sender, KeyEventArgs e)
        {


            if (CurrentUserID.CurrentParameters.IAUTOCOMPPROD.Equals("S") && CurrentUserID.CurrentParameters.ISCREENCONFIG == 1)
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

        private void TBCommandLine_Leave(object sender, EventArgs e)
        {

        }


        /*
         
          
        private void TBCommandLine_KeyUp_1(object sender, KeyEventArgs e)
        {


            if (CurrentUserID.CurrentParameters.IAUTOCOMPPROD.Equals("S") && CurrentUserID.CurrentParameters.ISCREENCONFIG == 1)
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

        private void TBCommandLine_Leave(object sender, EventArgs e)
        {
            if (!lstProductoComplete.Focused)
            {
                lstProductoComplete.Visible = false;
                lstProductoComplete.Items.Clear();
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
                /*
                int iBinarySearch = CurrentUserID.BinarySearchForMatch(collection, delegate(string str)
                    {
                        if (str.StartsWith(strSearch, true, null))
                            return 0;
                        return str.CompareTo(strSearch);
                    });
                

                if (iBinarySearch >= 0)
                {

                    int iStartMatch = iBinarySearch;
                    while (iStartMatch > 0 && collection[iStartMatch - 1].StartsWith(strSearch, true, null))
                    {
                        --iStartMatch;
                    }


                    for (int i = iStartMatch; i < collection.Count && collection[i].StartsWith(strSearch, true, null); i++)
                    {
                        lstProductoComplete.Items.Add(collection[i]);
                    }
                }

                */

                
                foreach (String str in collection)
                {
                    if (str.StartsWith(strSearch, true, null))
                    {
                        lstProductoComplete.Items.Add(str);
                    }
                }
            }



            lstProductoComplete.Visible = (lstProductoComplete.Items.Count > 0);
            lstProductoComplete.Size = new Size(lstProductoComplete.Size.Width, (lstProductoComplete.Items.Count > 0) ? 400 : 0);
            

        }




        private void btnFecha_Click(object sender, EventArgs e)
        {

        }
        
        private void WFMovilPuntoDeVenta_SizeChanged(object sender, EventArgs e)
        {
            if (CurrentUserID.CurrentParameters.ISCREENCONFIG != 2)
                return;

            if(this.Height < 680 && this.Height > 405)
            {
                //No tocar
                this.Height = 405;
                this.Width = 1286;
                this.Size = new Size(this.Width, this.Height);
                panelRoot.Height = 405;
                panelRoot.Width = 1286;
                ////////////////////////////

                gridPVDataGridView.Width = 690; 
                gridPVDataGridView.Height = 200;
                gridPVDataGridView.Location = new Point(560, 130);
                lstProductoComplete.Location = new Point(680, 160);
                ListaPrecios.Location = new Point(485, 146);
                lblCajas.Location = new Point(610, 72);
                TBCajas.Location = new Point(610, 92);
                lblCantidad.Location = new Point(720, 72);
                TBCantidad.Location = new Point(720, 92);
                label20.Location = new Point(820, 72);
                TBPrecio.Location = new Point(820, 92);
                label24.Location = new Point(920, 72);
                TBDescuento.Location = new Point(920, 92);
                label11.Location = new Point(970, 100);
                panel2.Location = new Point(100, 170);
                pnlPrecioCaja.Location = new Point(1070, 72);
                btnCalculadora.Location = new Point(1170, 87);                
                label19.Location = new Point(610, 2);

                TBCommandLine.Location = new Point(610, 26); 
                TBCommandLine.Width = 613;
                btnClearCommand.Location = new Point(1220, 26);

                label5.Visible = false;
                TBSumaTotal.Visible = false;
                label6.Visible = false;
                TBIva.Visible = false;

                label8.Location = new Point(1026, 340);
                TBTotal.Location = new Point(1085, 335);                
            }
            if (this.Width < 1200 && this.Width > 609)
            {
                this.Height = 690;
                this.Width = 609;
                this.Size = new Size(this.Width, this.Height);
                panelRoot.Height = 690;
                panelRoot.Width = 609;
                gridPVDataGridView.Width = 577;
                gridPVDataGridView.Height = 362;
                gridPVDataGridView.Location = new Point(5, 181);
                ListaPrecios.Location = new Point(256, 165);

                TBCommandLine.Width = 501;

                label5.Visible = true;
                label5.Location = new Point(352, 553);
                TBSumaTotal.Visible = true;
                TBSumaTotal.Location = new Point(418, 547);
                label6.Visible = true;
                label6.Location = new Point(369, 582);
                TBIva.Visible = true;
                TBIva.Location = new Point(418, 576);
                label8.Location = new Point(359, 612);
                TBTotal.Location = new Point(418, 606);

                lstProductoComplete.Location = new Point(9, 123);
                lblCajas.Location = new Point(6, 124);
                TBCajas.Location = new Point(6, 137);
                lblCantidad.Location = new Point(96, 124);
                TBCantidad.Location = new Point(96, 137);
                label20.Location = new Point(193, 124);
                TBPrecio.Location = new Point(189, 137);
                label24.Location = new Point(284, 124);
                TBDescuento.Location = new Point(287, 137);
                label11.Location = new Point(337, 149);
                pnlPrecioCaja.Location = new Point(358, 124);
                btnCalculadora.Location = new Point(450, 128);

                panel2.Location = new Point(6, 539);

                label19.Location = new Point(11, 79);
                TBCommandLine.Location = new Point(9, 93);
                btnClearCommand.Location = new Point(516, 93);
            }
            
        }

        private void panelRoot_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}