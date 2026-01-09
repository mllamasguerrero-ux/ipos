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
    //enum estadoVenta{ e_SinIniciar,e_Iniciado, e_Cerrada, e_Cancelada};
    public partial class WFVentaDevolucion : IposForm
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
        long   m_sucursalTID;
        bool m_bSalirSinPreguntar;

        bool m_focusInCommandLine = false;
        long m_ClienteId = 1;

        string m_strUltimoProductoIngresado = "";


        tipoTransaccionV m_tipoTransaccion;
        CDOCTOBE m_DoctoRef;

        bool m_bEntroAEdicion = false;

        bool m_bPermisoCambiarPrecio = false;
        bool m_bPermisoDevolverSinVenta = false;

        bool m_manejaAlmacen = false;
        bool m_bTienePermisosCambiarAlmacen = false;

        string m_strFileLog = "";


        long predoctoId = 0;
        bool m_bDoctoUnico = false;

        bool m_bTieneDerechoAsignarOtroCorteNC = false;

        bool m_bTieneDerechoAAbrirVentasCerradas = false;



        public WFVentaDevolucion()
        {
            InitializeComponent();
            ResetearVariablesForm();
            m_bSalirSinPreguntar = false;


            
        }

         public WFVentaDevolucion(long doctoId)
            : this()
        {
            predoctoId = doctoId;


        }


         public WFVentaDevolucion(long doctoId, bool bDoctoUnico)
            : this(doctoId)
        {
            m_bDoctoUnico = bDoctoUnico;
        }


        private void ResetearVariablesForm()
        {
            m_estadoVenta = (int)estadoVenta.e_SinIniciar;
            m_Docto = new CDOCTOBE();
            m_Caja = new CCAJABE();

            m_Docto.ITIPODOCTOID = DBValues._DOCTO_TIPO_VENTA;
            //m_Docto.ITIPODOCTOID = DBValues._DOCTO_TIPO_VENTAAPARTADO;
            
            m_dMontoVenta = 0;
            m_dSumaImporte = 0;
            m_dMontoIva = 0;
            m_dDescuento = 0;
            m_sucursalTID = 0;
            m_montoVentaConVale = 0;
            RefrescarEstatusBotones();

            m_tipoTransaccion = tipoTransaccionV.t_devolucion;
            //m_tipoTransaccion = tipoTransaccionV.t_ventaapartado;
            m_DoctoRef = null;
            //m_Cliente = null;
        }


        private void MostrarVendedorYTurno()
        {
        }


        private bool ChecarPermisos()
        {
            
            CPERSONAD personaD = new CPERSONAD();
            int iMenu = int.Parse(DBValues._MENUID_NOTACREDITO.ToString());
            if(!personaD.UsuarioTieneDerechoAMenu(CurrentUserID.CurrentUser.IID,iMenu,null))
            {
                MessageBox.Show("El usuario no tiene derecho a este form");
                return false;
            }

            CUSUARIOSD usuariosD = new CUSUARIOSD();
            if (usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_CAMBIARPRECIO_DEVOLUCION, null))
            {
                m_bPermisoCambiarPrecio = true;
            }

            if (usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_DEVOLUCIONSINVENTA, null))
            {
                m_bPermisoDevolverSinVenta = true;
            }

            return true;
        }

        private void WFVentaDevolucion_Load(object sender, EventArgs e)
        {

            CUSUARIOSD usuariosD = new CUSUARIOSD();

            if (!ChecarPermisos())
            {
                this.Close();
                return;
            }

            this.Text = "MODULO DE DEVOLUCIONES : BIENVENIDO  (OPERADOR: " + iPos.CurrentUserID.CurrentUser.INOMBRE + " ) ";

            //this.LBVendedor.Text = iPos.CurrentUserID.CurrentUser.INOMBRE;
            //this.LBSucursal.Text = iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO;
            this.LBFecha.Text = DateTime.Today.ToString("dd/MM/yyyy");
            MostrarVendedorYTurno();
            this.LBCliente.Text = "MOSTRADOR";
            this.gRIDPVTableAdapter1.SelectCommandTimeout = 100;
            m_printer = Ticket.GetReceiptPrinter();

            if (!ChecarFechaDelSistema())
                return;

            ChecarCorteActivo();
            ObtenerCaja();
            FormatTotalPiezas();

            //IrANuevaVenta();
            IrAEstadoInicial();

            HabilitarBotonesOpcionales();

            this.TBCommandLine.Focus();


            //asignar otro corte
            m_bTieneDerechoAsignarOtroCorteNC = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_APLICARNC_DIAANTERIOR, null);

            if (!m_bTieneDerechoAsignarOtroCorteNC)
                m_bTieneDerechoAsignarOtroCorteNC = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_APLICARNC_CUALQUIERDIAANTES, null);


             m_bTieneDerechoAAbrirVentasCerradas = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_ABRIR_VENTASCERRADAS, null);



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

                    m_bTienePermisosCambiarAlmacen = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_CAMBIARDEALMACEN, null);

                    if (m_bTienePermisosCambiarAlmacen)
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

            /*this.ComboVendedorFinal.llenarDatos();

            this.ComboVendedorFinal.SelectedIndex = -1;*/


            if (predoctoId != 0)
            {
                AbrirVentaXId(predoctoId);
                RefrescarEstatusBotones();
                predoctoId = 0;
            }

        }


        public void FormatGrid()
        {

            this.gridPVDataGridView.BackgroundColor = Color.White;
            this.gridPVDataGridView.DefaultCellStyle.BackColor = Color.White;

            this.gET_VENTA_DEVOLUCION_REFDataGridView.BackgroundColor = Color.White;
            this.gET_VENTA_DEVOLUCION_REFDataGridView.DefaultCellStyle.BackColor = Color.White;
            this.gET_VENTA_DEVOLUCION_REFDataGridView.Enabled = true;




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
                        if (iSplitIndex == 0 && numSplittedStr>1)
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





        private void DecifrarComando(string texto, ref CPRODUCTOBE prod, ref Decimal cantidad,ref bool bPreguntaCantidad, ref CPuntoDeVentaD pvd)
        {
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


            cantidad = cantidad * ((cantidadAux == 0)? 1 : cantidadAux);
        }


        private void ObtenerDoctoDeBD(long lDoctoID,FbTransaction st)
        {
            CDOCTOD vDocto = new CDOCTOD();
            m_Docto = new CDOCTOBE();
            m_Docto.IID = lDoctoID;
            m_Docto = vDocto.seleccionarDOCTO(m_Docto, st);
        }


        private bool ProcessCommand()
        {
            return ProcessCommand(true,true);
        }

        private bool ProcessCommand(bool bIgnorePrecio, bool preguntarOpcion)
        {

            long? P_MOVTOID = null;
            long? P_MOVTOREFID = null;
            return ProcessCommand(bIgnorePrecio, preguntarOpcion, P_MOVTOID, P_MOVTOREFID);
        }


        private bool ProcessCommand(bool bIgnorePrecio, bool preguntarOpcion, long? P_MOVTOID)
        {
            
            long? P_MOVTOREFID = null;
            return ProcessCommand(bIgnorePrecio, preguntarOpcion, P_MOVTOID, P_MOVTOREFID);
        }


        private bool ProcessCommandRef(bool bIgnorePrecio, bool preguntarOpcion, long? P_MOVTOREFID)
        {

            long? P_MOVTOID = null;
            return ProcessCommand(bIgnorePrecio, preguntarOpcion, P_MOVTOID, P_MOVTOREFID);
        }


        private bool ProcessCommand(bool bIgnorePrecio, bool preguntarOpcion, long? P_MOVTOID, long? P_MOVTOREFID)
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

            long?    P_IDDOCTO    = null;
            decimal? P_CANTIDAD   = null;
            long?    P_IDPRODUCTO = null;
            long?    P_PERSONAID = this.m_ClienteId;
            string   P_LOTE = "";
            long?    P_USERID = iPos.CurrentUserID.CurrentUser.IID;
            int?     US_SUPERVISORID = null;
            int? ALMACENID = m_manejaAlmacen ? int.Parse(this.ALMACENComboBox.SelectedValue.ToString()) : (int)DBValues._DOCTO_ALMACEN_DEFAULT;/*CurrentUserID.CurrentUser.IUS_ALMACENID*/ ;
            long?    SUCURSALID = CurrentUserID.CurrentParameters.ISUCURSALID;
            DateTime P_FECHAVENCE= DateTime.MinValue;
            Decimal  cantidad = 1;
            long?    SUCURSALTID = 0;
            long?    ALMACENTID = 0;
            
            long?    P_TIPODIFERENCIAINVENTARIOID = this.TIPODIFERENCIAINVENTARIOIDComboBox.SelectedValue != null ? long.Parse(this.TIPODIFERENCIAINVENTARIOIDComboBox.SelectedValue.ToString()) : -1;
            decimal? P_PRECIO = null;
            decimal? P_DESCUENTO = null;

            bool bResult = true;


            bool bPreguntaCantidad = false;

            CDOCTOD doctoD = new CDOCTOD();



            long? P_DOCTOREFID = null;
            bool bEsDevoSinVenta = false;
            if (this.m_DoctoRef != null)
            {
                if (!(bool)this.m_DoctoRef.isnull["IID"])
                {
                    P_DOCTOREFID = this.m_DoctoRef.IID;
                }
                else
                {
                    bEsDevoSinVenta = true;
                }
            }
            else
            {
                bEsDevoSinVenta = true;
            }

            if (bEsDevoSinVenta && !m_bPermisoDevolverSinVenta)
            {
                MessageBox.Show("No tiene derecho para hacer una devolucion sin una venta asociada");
                return false;
            }

            
            if(P_TIPODIFERENCIAINVENTARIOID < 0)
            {

                MessageBox.Show("Se debe de tener un motivo de devolucion seleccionado");
                return false;
            }


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
            P_CANTIDAD = (cantidad != 0) ? cantidad : 1;

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
                /*if (prod.ICLAVE.Trim() == "7401" || prod.ICLAVE.Trim() == "7402" ||
                    prod.ICLAVE.Trim() == "7418" || prod.ICLAVE.Trim() == "7419")
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

                    switch (prod.ICLAVE.Trim())
                    {
                        case "7401": P_LOTE = "Telcel: " + cel1; break;
                        case "7402": P_LOTE = "Movistar: " + cel1; break;
                        case "7418": P_LOTE = "Unefon: " + cel1; break;
                        case "7419": P_LOTE = "Iusacell: " + cel1; break;
                        default: P_LOTE = ""; break;
                    }


                    WFRecargaCantidad rc = new WFRecargaCantidad(true, false);
                    rc.ShowDialog();


                    if (rc.m_dMontoRecarga < 0)
                    {
                        MessageBox.Show("El monto debe ser mayor que cero");
                        return false;
                    }


                    P_CANTIDAD = rc.m_dMontoRecarga;
                }
                else if (prod.ICLAVE.Trim() == "7422")
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


                    WFRecargaCantidad rc = new WFRecargaCantidad(true, true);
                    rc.ShowDialog();


                    if (rc.m_dMontoRecarga < 0)
                    {
                        MessageBox.Show("El monto debe ser mayor que cero");
                        return false;
                    }


                    P_CANTIDAD = rc.m_dMontoRecarga;
                    P_LOTE = rc.m_compania + " - " + cel1;
                }

                else */if (bPreguntaCantidad)
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


            if (/*CurrentUserID.CurrentParameters.ICAMBIARPRECIO == "S" && prod.ICAMBIARPRECIO == "S" &&*/ !bIgnorePrecio && m_bPermisoCambiarPrecio)
            {
                    P_PRECIO = decimal.Parse(TBPrecio.Text);
                    P_DESCUENTO = decimal.Parse(TBDescuento.Text);
            }


            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            if (P_IDPRODUCTO == null)
            {
                SeleccionarProducto(TBCommandLine.Text);
                RefrescarEstatusBotones();
                return false;
            }
            if (prod.IMANEJALOTE == "S")
            {
            //condiciones para preguntar lote
            /*    int num_registros_inv = 0;
                decimal cantidad_inv = 0;
                string lote_inv = "";
                DateTime fechaVence = DateTime.MinValue;

                pvd.GetExistencia(prod, ref num_registros_inv, ref cantidad_inv, ref lote_inv, ref fechaVence,null);
                if (num_registros_inv > 1)
                {
                    WFPreguntaLote pl = new WFPreguntaLote(prod, P_CANTIDAD.Value,P_IDDOCTO.HasValue ? P_IDDOCTO.Value : 0);
                    pl.ShowDialog();
                    P_LOTE = pl.lote;
                    P_FECHAVENCE = pl.fechaVence;
                }
                else if (num_registros_inv == 1)
                {
                    P_LOTE = lote_inv;
                    P_FECHAVENCE = fechaVence;

                }*/
            }

            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();

                bool bExecutePostInicio = !P_IDDOCTO.HasValue;


                if (pvd.EjecutarAddMOVTO(ref P_IDDOCTO, P_CANTIDAD, P_IDPRODUCTO, P_PERSONAID, P_USERID, P_LOTE, US_SUPERVISORID, ALMACENID, SUCURSALID, P_FECHAVENCE, m_Docto.ITIPODOCTOID, SUCURSALTID, ALMACENTID, "N", P_TIPODIFERENCIAINVENTARIOID, P_PRECIO, P_DESCUENTO, iPos.CurrentUserID.CurrentCompania.IEM_CAJA, P_DOCTOREFID,ref P_MOVTOID, P_MOVTOREFID, null, null, null, null, fTrans))
                {
                   
                    
                    ObtenerDoctoDeBD((long)P_IDDOCTO,fTrans);

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

                    if (bExecutePostInicio)
                    {
                        /*if (this.m_DoctoRef != null)
                        {
                            m_Docto.IDOCTOREFID = this.m_DoctoRef.IID;
                            m_Docto.IPERSONAID = this.m_DoctoRef.IPERSONAID;
                        }*/

                        
                        

                        if(!pvd.DEVOLUCIONVENTA_POSTINICIO(m_Docto,fTrans))
                        {

                            bResult = false;
                            fTrans.Rollback();
                            MessageBox.Show(pvd.IComentario);
                            return false;
                        }
                    }

                    //if (bResult)
                    //{

                        fTrans.Commit();

                        RefrescarGridVentas();
                        FormatGrid();
                        GetTotalesPagosVenta();
                        RefreshTotalesVenta();
                        RefreshNumVenta();
                        //TBMensajesUser.Text = "";//"Exito"
                        //TBMensajesUser.BackColor = Color.Green;
                        this.TBCommandLine.Text = "";

                        this.TBPrecio.Text = "";
                        this.TBPrecio.ReadOnly = true;

                        this.TBDescuento.Text = "";
                        this.TBDescuento.ReadOnly = true;
                        this.m_strUltimoProductoIngresado = prod.ICLAVE;


                        if (m_manejaAlmacen)
                        {
                            this.ALMACENComboBox.Enabled = false;
                        }

                        if (this.m_estadoVenta == (int)estadoVenta.e_SinIniciar)
                            this.m_estadoVenta = (int)estadoVenta.e_Iniciado;
                    //}


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
                
                MessageBox.Show(ex.Message + ex.StackTrace);
                fConn.Close();
            }
            finally
            {
                fConn.Close();
            }
            RefrescarEstatusBotones();

            return bResult;
        }


        private void RefrescarGridSecundario()
        {
            this.gET_VENTA_DEVOLUCION_REFTableAdapter.Fill(this.dSPuntoDeVentaAux.GET_VENTA_DEVOLUCION_REF, m_Docto.IID, m_Docto.IDOCTOREFID);
           
        }

        private void RefrescarGridVentas()
        {

            RefrescarGridSecundario();
            this.gRIDPVTableAdapter1.Fill(this.dSPuntoDeVentaAux.GRIDPV, (int)m_Docto.IID);
            FormatGrid();

            if(gridPVDataGridView.Rows.Count > 0)
                gridPVDataGridView.CurrentCell = gridPVDataGridView.Rows[gridPVDataGridView.Rows.Count - 1].Cells["GVCANTIDAD"];

            GetTotalesPagosVenta();
            RefreshTotalesVenta();
            RefreshNumVenta();
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

            foreach (PuntoDeVenta.DSPuntoDeVentaAux.GRIDPVRow dr in this.dSPuntoDeVentaAux.GRIDPV.Rows)
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
            m_dSumaImporte= 0;
            m_dMontoIva = 0;
            m_dDescuento = 0;

            m_montoVentaConVale = 0;
        }
        public void GetTotalesPagosVenta()
        {
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            CDOCTOBE doctoBuffer = pvd.ObtenerVenta(m_Docto,null);

            if (pvd.IComentario == "" || pvd.IComentario == null)
            {
                m_Docto = doctoBuffer;
                m_dMontoVenta = m_Docto.ITOTAL;
                m_dSumaImporte = m_Docto.ISUBTOTAL;
                m_dMontoIva = m_Docto.IIVA;
                m_dDescuento = m_Docto.IDESCUENTO;


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
                            //this.m_montoVentaConVale += Decimal.Parse(row.Cells["IMPORTE"].Value.ToString());
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
            this.TBPagosTotalVentaBig.Text = m_dMontoVenta.ToString("N2");
            this.TBTotal.Text = m_dMontoVenta.ToString("N2");
            this.TBSumaTotal.Text = m_dSumaImporte.ToString("N2");
            this.TBIva.Text = m_dMontoIva.ToString("N2");

            //this.TBVale.Text = m_montoVentaConVale.ToString("N2");
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

            if (MessageBox.Show("Quiere cancelar la nota de credito actual?", "Cancelar la nota de credito actual", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return false;


            if ((int)estadoVenta.e_Iniciado != m_estadoVenta && (int)estadoVenta.e_SinIniciar != m_estadoVenta)
            {

                CUSUARIOSD usuariosD = new CUSUARIOSD();
                if (m_Docto.IFECHA < DateTime.Today.AddDays(-1))
                {
                    if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_ELIMINAR_VENTA_DIASATRAS, null) &&
               !usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_VERVENTAS_OTROSCORTES, null))
                    {
                        MessageBox.Show("Este usuario no puede eliminar devoluciones de dias anteriores al dia de ayer");
                        return false;
                    }
                }
                else
                {
                    if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_ELIMINAR_VENTA_DELDIA, null))
                    {

                        MessageBox.Show("Este usuario no puede eliminar notas de credito ");
                        return false;
                    }
                }
            }

            switch(m_Docto.ITIPODOCTOID)
            {
                case DBValues._DOCTO_TIPO_VENTA:
                    {
                        long statusDoctoId = m_Docto.IESTATUSDOCTOID;
                        pvd.CancelarVenta(m_Docto, CurrentUserID.CurrentUser, null);
                        if (pvd.IComentario == "" || pvd.IComentario == null)
                        {

                            HiloExistencias._IFLAGENVIAREXISTENCIASEVENTOS++;
                            MessageBox.Show("Trasaccion cancelada");

                            if (statusDoctoId != DBValues._DOCTO_ESTATUS_BORRADOR)
                            {
                                PosPrinter.ImprimirTicket(m_Docto.IID);
                            }

                            IrAEstadoInicial();
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
                                if (!facturacionCancelada)
                                {


                                    if (MessageBox.Show("No se pudo cancelar la factura electronica en el SAT desde el sistema. Como la devolución actual fue facturada electronicamente, tendra que cancelarla tambien en el SAT. Desea continuar con la cancelacion en el sistema?", "Cancelar la transaccion actual", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                                        return false;
                                }

                                //if (MessageBox.Show("Como la devolucion actual fue facturada electronicamente, tendra que cancelarla tambien en el SAT. Desea continuar?", "Cancelar la transaccion actual", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                                //    return false;
                            }

                        }

                        if (pvd.CancelarDevolucion(m_Docto, CurrentUserID.CurrentUser, ref doctoIDCancelacion, null))
                        {


                            HiloExistencias._IFLAGENVIAREXISTENCIASEVENTOS++;
                            MessageBox.Show("Nota de credito cancelada");

                            if (statusDoctoId != DBValues._DOCTO_ESTATUS_BORRADOR)
                            {
                                PosPrinter.ImprimirTicket(m_Docto.IID);
                            }
                            IrAEstadoInicial();
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


                            this.m_tipoTransaccion = tipoTransaccionV.t_cancelacionapartado;
                            this.m_DoctoRef = this.m_Docto;

                            m_Docto = new CDOCTOBE();
                            m_Docto.IID = doctoIDCancelacion;
                            CDOCTOD vData = new CDOCTOD();
                            m_Docto = vData.seleccionarDOCTO(m_Docto, null);

                            WFPagosBasico wp = new WFPagosBasico(m_Docto, m_Caja, false, 0, this.m_DoctoRef, this.m_tipoTransaccion, "S", null, false);
                            wp.ShowDialog();
                            if (wp.m_bPagoCompleto)
                            {
                                CerrarVenta(false);
                            }
                            wp.Dispose();
                            GC.SuppressFinalize(wp);
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



        private void IrAEstadoInicial()
        {
            bool bHayDoctoMostrandose = m_Docto != null && m_Docto.IID > 0;

            ResetearVariablesForm();
            ChecarActualizacionesPrecios();
            LimpiarTotalesPagosVenta();
            RefreshTotalesVenta();
            RefreshNumVenta();
            this.dSPuntoDeVentaAux.GRIDPV.Clear();
            FormatGrid();
            this.dSPuntoVenta.DETALLE_DE_PAGO.Clear();
            this.TBCommandLine.Text = "";
            this.LBOperacion.Text = "Devolución";
            this.LBCliente.Text = "MOSTRADOR";
            /*this.BTCliente.Text = "Cliente:";
            this.BTCliente.Enabled = true;*/
            m_ClienteId = 1;

            this.LBVenta.Text = "...";
            LimpiarCurrentItemDisplay();
            //this.TBCommandLine.Focus();
            this.TBCommandLine.Enabled = false;
            RefrescarEstatusBotones();
            this.TBPrecio.Text = "";
            this.TBPrecio.ReadOnly = true;

            this.TBDescuento.Text = "";
            this.TBDescuento.ReadOnly = true;

            lbClieCiudad.Text = "";
            lbClieColonia.Text = "";
            lbClieCP.Text = "";
            lbClieDom.Text = "";
            lbClieEstado.Text = "";
            lbClieNombre.Text = "";
            lbClieRFC.Text = "";
            lbClieTel.Text = "";

            LBDeLaVenta.Text = "...";


            this.gridPVDataGridView.BackgroundColor = Color.Gainsboro;
            this.gridPVDataGridView.DefaultCellStyle.BackColor = Color.Gainsboro;


            this.gET_VENTA_DEVOLUCION_REFDataGridView.BackgroundColor = Color.Gainsboro;
            this.gET_VENTA_DEVOLUCION_REFDataGridView.DefaultCellStyle.BackColor = Color.Gainsboro;
            this.gET_VENTA_DEVOLUCION_REFDataGridView.Enabled = false;


            this.dSPuntoDeVentaAux.GET_VENTA_DEVOLUCION_REF.Clear();

            this.BTSeleccionarProducto.Enabled = false;
            this.BTDevolver.Enabled = false;


            this.BTCotizacion.Enabled = false;

            this.m_bEntroAEdicion = false;
            lbTotalPiezas.Text = "0.00";

            this.TBTransacccion.Visible = true;
            this.TBTransacccion.Text = "";


            this.LBFolioFacturaElectronica.Text = "...";
            this.LBSerieFacturaElectronica.Text = "...";

            if (m_manejaAlmacen && m_bTienePermisosCambiarAlmacen)
            {
                this.ALMACENComboBox.Enabled = true;
                this.ALMACENComboBox.SelectedIndex = -1;
            }

            if (m_bDoctoUnico && bHayDoctoMostrandose)
            {
                this.Close();
            }
        }

        private void IrANuevaVenta()
         {


             ResetearVariablesForm();
             ChecarActualizacionesPrecios();
             LimpiarTotalesPagosVenta();
             RefreshTotalesVenta();
             RefreshNumVenta();
             this.dSPuntoVenta.GridPV.Clear();
             FormatGrid();
             this.dSPuntoVenta.DETALLE_DE_PAGO.Clear();
             this.TBCommandLine.Text = "";
             //this.TBMensajesUser.Text = "";
             //this.TBMensajesUser.BackColor = Color.Green;
             this.LBOperacion.Text = "Venta";
             this.LBCliente.Text = "MOSTRADOR";
             //this.lblClienteSuc.Text = "Cliente:";
             /*this.BTCliente.Text = "Cliente:";
             this.BTCliente.Enabled = true;*/
             m_ClienteId = 1;
             
             this.LBVenta.Text = "...";
             LimpiarCurrentItemDisplay();
             this.TBCommandLine.Focus();
             this.TBCommandLine.Enabled = true;
             RefrescarEstatusBotones();
             this.TBPrecio.Text = "";
             this.TBPrecio.ReadOnly = true;

             this.TBDescuento.Text = "";
             this.TBDescuento.ReadOnly = true;

             lbClieCiudad.Text = "";
             lbClieColonia.Text = "";
             lbClieCP.Text = "";
             lbClieDom.Text = "";
             lbClieEstado.Text = "";
             lbClieNombre.Text = "";
             lbClieRFC.Text = "";
             lbClieTel.Text = "";


             this.LBFolioFacturaElectronica.Text = "...";
             this.LBSerieFacturaElectronica.Text = "...";

             if (m_manejaAlmacen && m_bTienePermisosCambiarAlmacen)
             {
                 this.ALMACENComboBox.Enabled = true;
                 this.ALMACENComboBox.SelectedIndex = -1;
             }

            NOTAPAGOTextBox.Text = "";
            this.TIPODIFERENCIAINVENTARIOIDComboBox.SelectedIndex = -1;

            /*this.ComboVendedorFinal.Enabled = true;
            this.ComboVendedorFinal.SelectedIndex = -1;*/

            // tipo de transaccion default
            // m_tipoTransaccion = tipoTransaccionV.t_venta;
            // m_tipoTransaccion = tipoTransaccionV.t_ventaapartado;


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


        private void NuevoRegistro()
        {
            if ((!(bool)m_Docto.isnull["IID"]) 
                && (m_estadoVenta != (int)estadoVenta.e_Cerrada && m_estadoVenta != (int)estadoVenta.e_Cancelada))
            {
                    if (!CancelarVentaActual())
                        IrAEstadoInicial();

            }
            else
                IrAEstadoInicial();
        }



        private void BTPasarANueva_Click(object sender, EventArgs e)
        {
            AbrirVentasParaDevolucion();

        }

        private void AbrirVentasParaDevolucion()
        {


            if ((!(bool)m_Docto.isnull["IID"])
                && (m_estadoVenta != (int)estadoVenta.e_Cerrada && m_estadoVenta != (int)estadoVenta.e_Cancelada))
            {

                if (!CancelarVentaActual() && m_bEntroAEdicion)
                {
                    MessageBox.Show("Debe cancelar o terminar de editar la transaccion actual");
                    return;
                }

            }


            IrAEstadoInicial();

            if (m_bTieneDerechoAAbrirVentasCerradas)
            {
                WFSeleccionParaDevolucion look = new WFSeleccionParaDevolucion((int)DBValues._DOCTO_TIPO_VENTA, (int)DBValues._DOCTO_ESTATUS_COMPLETO, m_bPermisoDevolverSinVenta);
                look.ShowDialog();

                if (look.m_PersonaId == 0 && look.m_rtnDataRow == null)
                    return;

                if (look.m_rtnDataRow == null)
                    this.m_ClienteId = look.m_PersonaId;

                DataRow dr = look.m_rtnDataRow;

                look.Dispose();
                GC.SuppressFinalize(look);

                if (dr != null)
                {
                    m_Docto.IID = int.Parse(dr[0].ToString());
                    CDOCTOD vData = new CDOCTOD();
                    m_Docto = vData.seleccionarDOCTO(m_Docto, null);
                    TBTransacccion.Text = dr["FOLIO"].ToString();

                    //if (look.m_PersonaId == 0)
                    this.m_ClienteId = m_Docto.IPERSONAID;


                    if ((!(bool)m_Docto.isnull["IID"])
                        && (!(m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_CANCELADA || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_CANCELACION))
                        && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA || (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTAAPARTADO && m_Docto.IMERCANCIAENTREGADA == "S"))
                    {
                        NuevoDevolucion();

                        m_estadoVenta = (int)estadoVenta.e_SinIniciar;

                        RefrescarEstatusBotones();
                    }




                }
                else
                {
                    m_Docto = new CDOCTOBE();
                    NuevoDevolucion();
                    m_estadoVenta = (int)estadoVenta.e_SinIniciar;

                }
            }
            else
            {

                m_Docto = new CDOCTOBE();
                NuevoDevolucion();
                m_estadoVenta = (int)estadoVenta.e_SinIniciar;
            }
            llenarDatosCliente();

        }

        private void BTAbrirVenta_Click(object sender, EventArgs e)
        {
            
            AbrirVenta();
            RefrescarEstatusBotones();
        }
        private void AbrirVenta()
        {


            if (!(bool)m_Docto.isnull["IID"]
                && m_estadoVenta != (int)estadoVenta.e_Cancelada
                && m_estadoVenta != (int)estadoVenta.e_Cerrada)
            {

                if (!CancelarVentaActual() && m_bEntroAEdicion)
                {
                    MessageBox.Show("Debe cancelar o terminar de editar la transaccion actual");
                    return;
                }
            }

            IrAEstadoInicial();
            //GeneralLookUp look = new GeneralLookUp("select * from VENTAS where GV_ESTATUS = '" + CVENTASD.strStatusAbierta + @"'", "VENTAS");
           /* WFLOOKUPVENTAS look = new WFLOOKUPVENTAS();
            look.ShowDialog();*/


            WFSeleccionParaDevolucion look = new WFSeleccionParaDevolucion((int)DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO, (int)DBValues._DOCTO_ESTATUS_BORRADOR, m_bPermisoDevolverSinVenta);
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                AbrirVentaXId( int.Parse(dr[0].ToString()));

               
            } 
        }
        private void TBCommandLine_KeyDown(object sender, KeyEventArgs e)
        {

            if (m_estadoVenta == (int)estadoVenta.e_Cerrada || m_estadoVenta == (int)estadoVenta.e_Cancelada)
                return;

            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                ProcessCommand();
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
            
            LOOKPROD look;
            if (strDescripcion == "")
                look = new LOOKPROD("", true, TipoProductoNivel.tp_hijos);
            else
                look = new LOOKPROD(strDescripcion, true, TipoProductoNivel.tp_hijos);
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


        private void BTCerrarVenta_Click(object sender, EventArgs e)
        {
            if (m_estadoVenta == (int)estadoVenta.e_Cerrada || m_estadoVenta == (int)estadoVenta.e_Cancelada)
                return;

            PagarBasico(false);

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
                    MessageBox.Show(strBuffer.ToString()+ "\n");
            }
            else
                MessageBox.Show("La exportacion se ha realizado");


        }





        private void PagarBasico(bool bPagoConVale)
        {

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

                            WFPagosBasico wp = new WFPagosBasico(m_Docto, m_Caja, bPagoConVale, this.m_montoVentaConVale, this.m_DoctoRef, this.m_tipoTransaccion, esapartado, null, false);
                            wp.ShowDialog();
                            if (wp.m_bPagoCompleto)
                            {
                                //se añade para la funcionalidad del vale
                                if (bPagoConVale)
                                {
                                    this.m_Docto.IREFERENCIAS = wp.m_numeroVale;

                                    if (!AplicarDescuentoVale())
                                    {
                                        this.Focus();
                                        wp.Dispose();
                                        return;
                                    }
                                }
                                this.CerrarVenta(false);
                            }
                            wp.Dispose();
                            GC.SuppressFinalize(wp);
                        }
                        break;

                    case tipoTransaccionV.t_devolucion:
                        {

                            WFPagosDevoluciones wp = new WFPagosDevoluciones(m_Docto, m_Caja, bPagoConVale, this.m_montoVentaConVale, this.m_DoctoRef, this.m_tipoTransaccion, esapartado, false);
                            wp.ShowDialog();
                            if (wp.m_bPagoCompleto)
                            {
                                this.CerrarVenta(wp.m_generarFacturaElectronica);
                            }
                            wp.Dispose();
                            GC.SuppressFinalize(wp);
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

        private void CerrarVenta(bool generarFacturaElectronica)
        {
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            CDOCTOD doctoD = new CDOCTOD();

            /*
            if (generarFacturaElectronica)
            {
                if (!FacturaElectronica())
                {
                    CDOCTOPAGOD doctoD = new CDOCTOPAGOD();
                    doctoD.BorrarXDoctoIdDOCTOPAGOD(m_Docto, null);
                    return;
                }
            }*/

            bool bRes = false;
            long doctoConsDevId = 0;

            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            try
            {

                fConn.Open();
                fTrans = fConn.BeginTransaction();

                
                string esVentaCons = "N";
                CCONSOLIDADOD consolidadoD = new CCONSOLIDADOD();
                consolidadoD.CONSOLIDADO_ESVENTACONS(m_Docto.IDOCTOREFID, ref esVentaCons, fTrans);
                if (esVentaCons.Equals("S"))
                {
                    m_Docto.IESFACTURAELECTRONICA = "S";
                    doctoD.ACTUALIZARESFACTURAELECTRONICA(m_Docto, fTrans);
                    generarFacturaElectronica = true;
                }


                bRes = pvd.CerrarVenta(m_Docto, fTrans);

                if(!bRes)
                {
                    fTrans.Rollback();
                    fConn.Close();
                    MessageBox.Show("ERRORES: " + pvd.IComentario.Replace("%", "\n"));
                    return;
                }

                /*string esVentaCons = "N";
                CCONSOLIDADOD consolidadoD = new CCONSOLIDADOD();
                consolidadoD.CONSOLIDADO_ESVENTACONS(m_Docto.IDOCTOREFID, ref esVentaCons, fTrans);*/
                if(esVentaCons.Equals("S"))
                {
                    if(!consolidadoD.CONSOLIDADO_DEVOLVER(m_Docto.IID, CurrentUserID.CurrentUser.IID, ref doctoConsDevId, fTrans))
                    {

                        fTrans.Rollback();
                        fConn.Close();
                        MessageBox.Show("ERRORES: " + pvd.IComentario.Replace("%", "\n"));
                        return;
                    }


                //    string resComentario = "";
                //    if (!generarFacturaElectronicaPorId(doctoConsDevId, fTrans, ref resComentario))
                //    {

                //        fTrans.Rollback();
                //        fConn.Close();
                //        MessageBox.Show("No se pudo realizar la facturacion " + resComentario);
                //        if (m_strFileLog != null && m_strFileLog.Trim().Length > 0)
                //        {
                //            Process.Start("notepad.exe", m_strFileLog);
                //        }

                //        return;

                //    }

                    

                }

                fTrans.Commit();
                
                //if (esVentaCons.Equals("S"))
                //{
                //    imprimirFacturaElectronicaPorId(doctoConsDevId);
                //}
                fConn.Close();

            }
            catch
            {
                try
                {
                    fTrans.Rollback();
                }
                catch { }

                fConn.Close();
            }
            finally
            {
                fConn.Close();
            }




            if (bRes)
            {



                PosPrinter.ImprimirTicket(m_Docto.IID);

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


                if (generarFacturaElectronica)
                {
                    bool repetir = false;

                    do
                    {
                        repetir = false;

                        if (FacturaElectronica())
                        {
                            imprimirFacturaElectronica();
                        }
                        else
                        {
                            WFNoSePudoFacturarPregunta wf = new WFNoSePudoFacturarPregunta(true);
                            wf.ShowDialog();

                            if (wf.strRespuesta != null && wf.strRespuesta.Equals("Reintentar"))
                            {
                                repetir = true;
                            }
                            else 
                            {
                                
                                m_Docto.IESFACTURAELECTRONICA = "N";
                                doctoD.ACTUALIZARESFACTURAELECTRONICA(m_Docto, null);
                                CancelarVentaActual();
                                wf.Dispose();
                                GC.SuppressFinalize(wf);
                                return;
                            }
                            wf.Dispose();
                            GC.SuppressFinalize(wf);
                        }
                    } while (repetir);
                }

                ////if (pvd.ContieneRecargas(m_Docto, null))
                ////{

                ////    PosPrinter.ImprimirTicket(m_Docto.IID,Ticket._OPCION_IMPRESION_RECARGAS);
                ////}


                if (m_bTieneDerechoAsignarOtroCorteNC)
                {
                    if (MessageBox.Show("Desea asignar esta nota de credito a otro corte diferente?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        WFAsignarDevolucionACorte rp = new WFAsignarDevolucionACorte(m_Docto);
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                    }
                }


                IrAEstadoInicial();


                this.BTAbrirCerradasYDevo.Enabled = true;
                this.BTAbrirVenta.Enabled = true;

                HiloExistencias._IFLAGENVIAREXISTENCIASEVENTOS++;
                this.TBCommandLine.Focus();
            }
            else
            {
                MessageBox.Show("ERRORES: " + pvd.IComentario.Replace("%", "\n"));
            }
        }






        private bool Precierre()
        {
            if (this.m_tipoTransaccion == tipoTransaccionV.t_devolucion)
                return true;


            CPuntoDeVentaD pvd = new CPuntoDeVentaD();

            int errorCode = 0;
            m_Docto.IVENDEDORID = CurrentUserID.CurrentUser.IID;
            m_Docto.IVENDEDORFINAL = this.m_Docto.IVENDEDORID;
            if (!pvd.VENTA_PRECIERRE(m_Docto, null, ref errorCode))
            {
                MessageBox.Show("ERRORES: " + pvd.IComentario.Replace("%", "\n"));

                return false;
            }


            //marca la devolucion para que sea checada en almacen
            if (CurrentUserID.CurrentParameters.IHABSURTIDOPOSTPUESTO != null && CurrentUserID.CurrentParameters.IHABSURTIDOPOSTPUESTO.Equals("S"))
            {
                CDOCTOD doctoD = new CDOCTOD();
                m_Docto.IESTADOSURTIDOID = 2;
                if (!doctoD.CambiarESTADOSURTIDOID(m_Docto, null))
                {
                    MessageBox.Show("ERRORES: " + doctoD.IComentario.Replace("%", "\n"));
                    return false;
                }
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
        private void WFVentaDevolucion_KeyDown(object sender, KeyEventArgs e)
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
                    if(!e.Alt)
                        AbrirVenta();
                    break;
                case Keys.F2:
                    IrAEstadoInicial();
                    break;
                case Keys.F3:
                    if ( m_estadoVenta != (int)estadoVenta.e_Cancelada)
                            CancelarVentaActual();
                    break;
                case Keys.F8:
                    SeleccionarProducto();
                    break;

                case Keys.F9:
                    ModoTraslado();
                    break;

                case Keys.F10:
                    if(m_estadoVenta != (int)estadoVenta.e_Cerrada && m_estadoVenta != (int)estadoVenta.e_Cancelada)
                        EliminarDetalle();
                    break;

                case Keys.F11:
                    if (m_estadoVenta != (int)estadoVenta.e_Cerrada && m_estadoVenta != (int)estadoVenta.e_Cancelada)
                    {
                        CambiarPrecioDetalle();
                    }
                    break;


                case Keys.F12:
                    if (e.Modifiers == Keys.Control)
                    {
                        if (m_estadoVenta == (int)estadoVenta.e_Cerrada && m_estadoVenta != (int)estadoVenta.e_Cancelada)
                        {
                            if (this.generarFacturaElectronica(false))
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

                default :
                    break;
            }
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

            WFFacturaElectronica fe = new WFFacturaElectronica(this.m_Docto, CurrentUserID.CurrentParameters, WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_GENERARPDF,this.m_DoctoRef,CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
            CUSUARIOSD usuariosD = new CUSUARIOSD(); fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null)); 
            fe.ShowDialog();
            retorno = fe.m_facturacionRealizada;
            fe.Dispose();
            GC.SuppressFinalize(fe);
            return retorno;
        }



       /* private void GetSwfMovieSource()
        {


            var rand = new Random(); 
            string[] files = Directory.GetFiles(Application.StartupPath + "\\sampdata\\SWF", "*.swf");
            string newMovie = files[rand.Next(files.Length)];
   
            axShockwaveFlash1.Stop();
            axShockwaveFlash1.Movie = newMovie;
            axShockwaveFlash1.Play();

            string[] filesImgs = Directory.GetFiles(Application.StartupPath + "\\sampdata\\JPG", "*.jpg");
            string newImage = filesImgs[rand.Next(filesImgs.Length)];
            pictureBox1.BackgroundImage = Image.FromFile(newImage);


        }*/

        private void WFVentaDevolucion_Shown(object sender, EventArgs e)
        {
            this.TBCommandLine.Focus();
            //GetSwfMovieSource();


        }

        private void WFVentaDevolucion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_bSalirSinPreguntar)
                return;

            if (m_bEntroAEdicion)
            {
                MessageBox.Show("Por favor termine la edicion de la transaccion antes de salir. Recuerde que la transaccion original fue cancelada y si se sale en este momento la transaccion nueva quedara pendiente.");
                e.Cancel = true;
                return;
            }


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

            if(!m_bDoctoUnico)
            {
                if (MessageBox.Show("Realmente quiere salir de esta pantalla?", "Salir de esta pantalla", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
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
            //this.BTReenviarTraslados.Visible = false;

            this.BtnImprimirFE.Visible = false;

            if (!(bool)m_Docto.isnull["IID"] && gridPVDataGridView.Rows.Count > 0)
            {
                this.BTPasarANueva.Enabled = true;
                this.BTCancelarVenta.Enabled = true;
                this.BTCerrarVenta.Enabled = true;
                //this.BTPagarConVale.Enabled = true;
                this.gridPVDataGridView.Columns["TOTALVALE"].Visible = true;

                

            }
            else
            {
                this.BTPasarANueva.Enabled = /*false*/true;
                this.BTCancelarVenta.Enabled = false;
                this.BTCerrarVenta.Enabled = false;
                //this.BTPagarConVale.Enabled = false;
                this.gridPVDataGridView.Columns["TOTALVALE"].Visible = false;
            }

            if (gridPVDataGridView.Rows.Count > 0)
                this.BTEliminarDetalle.Enabled = true;
            else
                this.BTEliminarDetalle.Enabled = false;

            
            if(this.m_DoctoRef != null && m_DoctoRef.IID > 0)
            {
                this.btnDevolverDisp.Enabled = true;
            }
            else
            {
                this.btnDevolverDisp.Enabled = false;
            }
        }
        


        private void AbrirVentaXId(long docId)
        {

            IrAEstadoInicial();

            m_Docto.IID = docId;
            CDOCTOD vData = new CDOCTOD();
            m_Docto = vData.seleccionarDOCTO(m_Docto, null);

            if (m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_CANCELADA || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_CANCELACION)
                m_estadoVenta = (int)estadoVenta.e_Cancelada;
            else if(m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_BORRADOR )
            {
                m_estadoVenta = (int)estadoVenta.e_Iniciado;
            }
            else
            {
                this.BTCancelarVenta.Enabled = true;
                m_estadoVenta = (int)estadoVenta.e_Cerrada;
            }

            RefrescarGridVentas();

            if (m_estadoVenta != (int)estadoVenta.e_Iniciado)
            {
                this.gridPVDataGridView.BackgroundColor = Color.Gainsboro;
                this.gridPVDataGridView.DefaultCellStyle.BackColor = Color.Gainsboro;
                this.gET_VENTA_DEVOLUCION_REFDataGridView.BackgroundColor = Color.Gainsboro;
                this.gET_VENTA_DEVOLUCION_REFDataGridView.DefaultCellStyle.BackColor = Color.Gainsboro;
                this.gET_VENTA_DEVOLUCION_REFDataGridView.Enabled = false;
                this.TBCommandLine.Enabled = false;


                this.BTEliminarDetalle.Enabled = false;
                this.BTCerrarVenta.Enabled = false;

                this.gridPVDataGridView.Columns["TOTALVALE"].Visible = false;
                this.LBOperacion.Text = "Consulta";
                LimpiarCurrentItemDisplay();

                this.BTCotizacion.Enabled = true;


            }




           
            


            if ((bool)m_Docto.isnull["IFOLIOSAT"] || (bool)m_Docto.isnull["IESTATUSDOCTOID"]
                || m_Docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_COMPLETO || m_Docto.IFOLIOSAT <= 0)
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




            if (m_estadoVenta != (int)estadoVenta.e_Cancelada && m_estadoVenta != (int)estadoVenta.e_Iniciado)
                this.BTDevolver.Enabled = true;
            else
                this.BTDevolver.Enabled = false;

            //this.BTPagarConVale.Enabled = false;

            if (!(bool)m_Docto.isnull["IPERSONAID"])
            {
                this.m_ClienteId = m_Docto.IPERSONAID;
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

            llenarDatosGeneralesDocto();

            this.TBTransacccion.Visible = false;



            m_DoctoRef = new CDOCTOBE();
            this.m_DoctoRef.IID = m_Docto.IDOCTOREFID;
            m_DoctoRef = vData.seleccionarDOCTO(m_DoctoRef, null);


            if (m_DoctoRef != null)
            {
                if (!(bool)m_DoctoRef.isnull["IFOLIO"])
                {
                    this.LBDeLaVenta.Text = m_DoctoRef.IFOLIO.ToString("0");
                }
                else
                {
                    this.LBDeLaVenta.Text = "...";
                }
            }


            if (m_Docto.INOTAPAGO != "" && m_Docto.INOTAPAGO != null)
            {
                this.lblNotaDevolucion.Text = "Nota:" + m_Docto.INOTAPAGO;
            }

        }

        private void AbrirVentasCerradasYDevoluciones()
        {

            if (!(bool)m_Docto.isnull["IID"]
               && m_estadoVenta != (int)estadoVenta.e_Cancelada
               && m_estadoVenta != (int)estadoVenta.e_Cerrada)
            {
                if (!CancelarVentaActual() && m_bEntroAEdicion)
                {
                    MessageBox.Show("Debe cancelar o terminar de editar la transaccion actual");
                    return;
                }
            }

            IrAEstadoInicial();
            
            CUSUARIOSD usuariosD = new CUSUARIOSD();
            /*WFLOOKUPVENTAS look = new WFLOOKUPVENTAS((int)DBValues._DOCTO_ESTATUS_COMPLETO, (int)DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO);
            look.ShowDialog();*/


            WFSeleccionParaDevolucion look = new WFSeleccionParaDevolucion((int)DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO, -1 /*(int)DBValues._DOCTO_ESTATUS_COMPLETO*/, m_bPermisoDevolverSinVenta);
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                AbrirVentaXId(int.Parse(dr[0].ToString()));
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
                this.LBOperacion.Text = "Traslado";
                //lblClienteSuc.Text = "SUC_DEST:";
                /*this.BTCliente.Text = "SUC_DEST:";
                this.BTCliente.Enabled = false; */
                m_ClienteId = 1;

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
        }

        /*private void BTTraspaso_Click(object sender, EventArgs e)
        {
            ModoTraslado();
        }*/

        private void TimerImageSWF_Tick(object sender, EventArgs e)
        {
            //GetSwfMovieSource();
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

        private void TBCommandLine_Validated(object sender, EventArgs e)
        {
            PonerPrecioEnPantalla();

        }

        private void PonerPrecioEnPantalla()
        {

            if (/*CurrentUserID.CurrentParameters.ICAMBIARPRECIO == "N" ||*/ !m_bPermisoCambiarPrecio)
            {

                this.TBPrecio.Text = "";
                this.TBPrecio.ReadOnly = true;


                this.TBDescuento.Text = "";
                this.TBDescuento.ReadOnly = true;

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
                /*if (prod.ICAMBIARPRECIO == "N")
                {
                    this.TBPrecio.Text = "";
                    this.TBPrecio.ReadOnly = true;


                    this.TBDescuento.Text = "";
                    this.TBDescuento.ReadOnly = true;


                    return;
                }*/

                int? productoId = (int?)prod.IID;
                int? personaId = (int?)CurrentUserID.CurrentUser.IID;
                int? tipoDoctoId = (int?)m_Docto.ITIPODOCTOID;
                int? sucursalId = (int?)CurrentUserID.CurrentParameters.ISUCURSALID;
                int? sucursalTId = null;

                

                decimal? precioLista = null;
                decimal? precioTraspaso = null;
                decimal? precioMinimo = null;
                decimal? costo = null;

                if (cantidad == 0)
                    cantidad = 1;





                if (pvd.GET_PRECIOS_PRODUCTO_LISTA(productoId, personaId, cantidad, sucursalTId, ref  precioLista, ref precioTraspaso, ref  precioMinimo, ref  costo, null))
                {
                    if (precioLista.HasValue)
                    {
                        this.TBPrecio.Text = precioLista.ToString();
                    }
                    else
                    {
                        this.TBPrecio.Text = "";
                    }

                    this.TBPrecio.ReadOnly = false;

                    ListaPrecios.Items.Clear();
                    if (precioLista.HasValue)
                    {
                        ListaPrecios.Items.Add("Pr. Lista   : " + precioLista.Value.ToString("N2"));
                    }

                    if (precioTraspaso.HasValue)
                    {
                        ListaPrecios.Items.Add("Pr. Traspaso: " + precioTraspaso.Value.ToString("N2"));
                    }

                    if (precioMinimo.HasValue)
                    {
                        ListaPrecios.Items.Add("Pr. Minimo  : " + precioMinimo.Value.ToString("N2"));
                    }

                    if (costo.HasValue)
                    {
                        ListaPrecios.Items.Add("Costo       : " + costo.Value.ToString("N2"));
                    }



                    this.TBDescuento.Text = "";
                    this.TBDescuento.ReadOnly = false;


                }
                else
                {
                    this.TBPrecio.Text = "";
                    this.TBPrecio.ReadOnly = true;

                }


            }
        }

        

        private void TBPrecio_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (m_estadoVenta == (int)estadoVenta.e_Cerrada || m_estadoVenta == (int)estadoVenta.e_Cancelada)
                return;

            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                ProcessCommand(false,false);
                m_focusInCommandLine = true;
            }
            else if (e.KeyCode == System.Windows.Forms.Keys.L && TBPrecio.ReadOnly == false)
            {             
                 this.ListaPrecios.Height = 100;
                 this.ListaPrecios.Visible = true;
                 this.ListaPrecios.Focus();
            }
            if (Control.ModifierKeys == Keys.Control)
            {
                if (e.KeyCode == Keys.S)
                {
                    ProcessCommand(false,false);
                    m_focusInCommandLine = true;
                }
            }
        }

        private void TBPrecio_Validated(object sender, EventArgs e)
        {
            if (m_focusInCommandLine)
            {
                this.TBCommandLine.Focus();
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

                char[] cSeparator = new char[]{':'};
                 
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
                    TBCommandLine.Text = dEntrada.ToString("N3") + "*" + gridPVDataGridView.Rows[e.RowIndex].Cells["GVCLAVEPRODUCTO"].Value.ToString();
                    TBPrecio.Text = gridPVDataGridView.Rows[e.RowIndex].Cells["PRECIOUNIDAD"].Value.ToString();
                    TBDescuento.Text = gridPVDataGridView.Rows[e.RowIndex].Cells["TITULOSTOTALES"].Value.ToString();
                    long? P_MOVTOID = (long)gridPVDataGridView.Rows[e.RowIndex].Cells["MOVTOID"].Value;
                    if (!ProcessCommand(true, false,P_MOVTOID))
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

        private void TBDescuento_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (m_estadoVenta == (int)estadoVenta.e_Cerrada || m_estadoVenta == (int)estadoVenta.e_Cancelada)
                return;

            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                ProcessCommand(false,false);
                m_focusInCommandLine = true;
            }
        }

        /*private void BTCliente_Click(object sender, EventArgs e)
        {
            iPos.Catalogos.WFClientes look = new iPos.Catalogos.WFClientes();
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;
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
                            RefrescarGridVentas();
                    }
                }
            }
            look.Dispose();
        }*/

        private void BTCotizacion_Click(object sender, EventArgs e)
        {
            if (m_Docto != null)
            {
                if (!(bool)m_Docto.isnull["IID"])
                {
                    PosPrinter.ImprimirTicket(m_Docto.IID);
                }
            }
        }


        private void HabilitarBotonesOpcionales()
        {
            /*if (!(bool)CurrentUserID.CurrentParameters.isnull["IHAB_SEL_CLIENTE"])
            {
                this.BTCliente.Visible = (CurrentUserID.CurrentParameters.IHAB_SEL_CLIENTE == DBValues._DB_BOOLVALUE_SI);
            }
            else
            {
                this.BTCliente.Visible = false;
            }*/


            if (!(bool)CurrentUserID.CurrentParameters.isnull["IHAB_IMPR_COTIZACION"])
            {
                this.BTCotizacion.Visible = (CurrentUserID.CurrentParameters.IHAB_IMPR_COTIZACION == DBValues._DB_BOOLVALUE_SI);
            }
            else
            {
                this.BTCotizacion.Visible = false;
            }
        }

        private void gridPVDataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        /*private void BTReenviarTraslados_Click(object sender, EventArgs e)
        {
            PosPrinter.ImprimirTicket(m_Docto.IID);

            if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO)
            {
                CDOCTOD vData = new CDOCTOD();
                m_Docto = vData.seleccionarDOCTO(m_Docto, null);

                ExportarTraslados(m_Docto.IFOLIO);
            }
        }*/

        /*private void button1_Click(object sender, EventArgs e)
        {

            if (m_estadoVenta == (int)estadoVenta.e_Cerrada || m_estadoVenta == (int)estadoVenta.e_Cancelada)
                return;

            PagarBasico(true);
        }*/

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


        public void llenarDatosCliente()
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

                LBCliente.Text = clienteBE.ICLAVE;

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
            }

        }

        /*private void BTRecalcular_Click(object sender, EventArgs e)
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
        */


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
                decimal precio_ = pr_.m_precio;
                pr_.Dispose();
                GC.SuppressFinalize(pr_);

                if (!bProcesado)
                {
                    MessageBox.Show("El usuario cancelo la operacion");
                }
                else
                {
                    movtoBE.IPRECIO = precio_;
                    if (!pvd.CambiarPrecioMOVTOVENTAS(movtoBE, supervisorBE.IID, null))
                    {
                        MessageBox.Show(pvd.IComentario);
                    }
                }


                RefrescarGridVentas();
            }
            RefrescarEstatusBotones();
            this.TBCommandLine.Focus();

        }


        private void NuevoDevolucion()
        {



            if (((!(bool)m_Docto.isnull["IID"])
                && (!(m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_CANCELADA || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_CANCELACION)))
                 || ((bool)m_Docto.isnull["IID"]))
            {


                //cliente
                CPERSONAD clienteD = new CPERSONAD();
                CPERSONABE clienteBE = new CPERSONABE();
                clienteBE.IID = m_ClienteId;
                clienteBE = clienteD.seleccionarPERSONA(clienteBE, null);

                CDOCTOBE doctoBuffer = m_Docto;
                m_Docto = new CDOCTOBE();
                IrANuevaVenta();
                this.m_DoctoRef = doctoBuffer;
                this.m_tipoTransaccion = tipoTransaccionV.t_devolucion;


                this.m_ClienteId = clienteBE.IID;


                if (clienteBE != null)
                {
                    LBCliente.Text = clienteBE.ICLAVE;
                }

                //this.BTReenviarTraslados.Visible = false;
                //this.BTCliente.Enabled = false;
                //this.BTRecalcular.Enabled = true;

                this.BTPasarANueva.Enabled = true;
                this.BTEliminarDetalle.Enabled = true;
                this.BTCerrarVenta.Enabled = false;
                this.BTSeleccionarProducto.Enabled = true;
               // this.BTPagarConVale.Enabled = false;
                this.gridPVDataGridView.Columns["TOTALVALE"].Visible = false;
                this.LBOperacion.Text = "Devolución";




                if (!(bool)m_DoctoRef.isnull["IFOLIO"])
                {
                    this.LBDeLaVenta.Text = m_DoctoRef.IFOLIO.ToString("0");
                }
                else
                {
                    this.LBDeLaVenta.Text = "...";
                }
                

                m_Docto.ITIPODOCTOID = DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO;
                m_Docto.IPERSONAID = m_ClienteId;
                if (!(bool)m_DoctoRef.isnull["IID"])
                {
                    m_Docto.IDOCTOREFID = this.m_DoctoRef.IID;
                }
                RefrescarGridSecundario();


                this.TBTransacccion.Visible = !m_bTieneDerechoAAbrirVentasCerradas;


                if (m_manejaAlmacen)
                {
                    if (m_DoctoRef != null && !(bool)m_DoctoRef.isnull["IID"])
                    {
                        this.ALMACENComboBox.Enabled = m_bTienePermisosCambiarAlmacen;
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

            if (m_estadoVenta == (int)estadoVenta.e_Cancelada)
            {
                MessageBox.Show("No puede editar una transaccion cancelada");
                return;
            }


            if (MessageBox.Show("Para editar una devolucion ya terminada, se cancelara la transaccion original y se copiara su informacion en una nueva. Esta seguro que desea continuar?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            CPuntoDeVentaD pvd = new CPuntoDeVentaD();

            /*if ((!(bool)m_Docto.isnull["IID"])
                && (m_estadoVenta == (int)estadoVenta.e_Cerrada)
                && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA || (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTAAPARTADO && m_Docto.IMERCANCIAENTREGADA == "S"))
            {
                NuevoDevolucion();
            }
            else */if ((!(bool)m_Docto.isnull["IID"])
                && (m_estadoVenta == (int)estadoVenta.e_Cerrada)
                && (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO )   )
            {


                  if (m_Docto.IESFACTURAELECTRONICA != null)
                  {
                      if (m_Docto.IESFACTURAELECTRONICA == "S")
                      {
                          MessageBox.Show("No puede editar una nota de credito de la que se haya generado factura electronica");
                          return;
                      }

                 }

                   long doctoIDEdicion = 0;

                   if (pvd.EditarDevolucion(m_Docto, CurrentUserID.CurrentUser, ref doctoIDEdicion, CurrentUserID.CurrentUser.IID, null))
                   {
                       IrAEstadoInicial();
                       m_Docto = new CDOCTOBE();
                       m_Docto.IID = doctoIDEdicion;
                       CDOCTOD vData = new CDOCTOD();
                       m_Docto = vData.seleccionarDOCTO(m_Docto, null);


                       m_DoctoRef = new CDOCTOBE();
                       this.m_DoctoRef.IID = m_Docto.IDOCTOREFID;
                       m_DoctoRef = vData.seleccionarDOCTO(m_DoctoRef, null);

                       this.m_tipoTransaccion = tipoTransaccionV.t_devolucion;
                       RefrescarGridVentas();
                       this.BTCerrarVenta.Enabled = true;
                       this.BTSeleccionarProducto.Enabled = true;
                       this.TBCommandLine.Enabled = true;


                       m_bEntroAEdicion = true;

                       this.BTAbrirCerradasYDevo.Enabled = false;
                       this.BTAbrirVenta.Enabled = false;
                       this.BTPasarANueva.Enabled = false;

                       LimpiarCurrentItemDisplay();

                       if (!(bool)m_Docto.isnull["IPERSONAID"])
                       {
                           this.m_ClienteId = m_Docto.IPERSONAID;
                       }

                       llenarDatosGeneralesDocto();

                   }
            }
            else if ((!(bool)m_Docto.isnull["IID"])
                && (m_estadoVenta == (int)estadoVenta.e_Cerrada)
                && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTAAPARTADO && m_Docto.IMERCANCIAENTREGADA == "N")
            {
                long doctoIDEdicion = 0;

                if (pvd.EditarApartado(m_Docto, CurrentUserID.CurrentUser, ref doctoIDEdicion, CurrentUserID.CurrentUser.IID, null))
                {
                    IrAEstadoInicial();
                    m_Docto = new CDOCTOBE();
                    m_Docto.IID = doctoIDEdicion;
                    CDOCTOD vData = new CDOCTOD();
                    m_Docto = vData.seleccionarDOCTO(m_Docto, null);


                    m_DoctoRef = new CDOCTOBE();
                    this.m_DoctoRef.IID = m_Docto.IDOCTOREFID;
                    m_DoctoRef = vData.seleccionarDOCTO(m_DoctoRef, null);

                    this.m_tipoTransaccion = tipoTransaccionV.t_ventaapartado;
                    RefrescarGridVentas();
                    this.BTCerrarVenta.Enabled = true;
                    this.BTSeleccionarProducto.Enabled = true;
                    this.TBCommandLine.Enabled = true;

                    LimpiarCurrentItemDisplay();

                    if (!(bool)m_Docto.isnull["IPERSONAID"])
                    {
                        this.m_ClienteId = m_Docto.IPERSONAID;
                    }

                    llenarDatosGeneralesDocto();
                }
            }
        }

        private void gET_VENTA_DEVOLUCION_REFDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
            DataGridView view = (DataGridView)sender;
            MessageBox.Show("Dato invalido , porfavor ingrese un dato valido" + e.Exception.Message);
            e.ThrowException = false;
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
                    TBCommandLine.Text = dEntrada.ToString("N3") + "*" + gET_VENTA_DEVOLUCION_REFDataGridView.Rows[e.RowIndex].Cells["DGCLAVEPRODUCTO"].Value.ToString();

                    decimal montoRebajaEspecial = 0; 
                    decimal precioConRebaja = 0;
                    int estadoRebaja = 0;
                    Boolean ignorePrecio = true;

                    try
                    {
                        montoRebajaEspecial = decimal.Parse(gET_VENTA_DEVOLUCION_REFDataGridView.Rows[e.RowIndex].Cells["DGMONTOREBAJA"].Value.ToString());
                        precioConRebaja = decimal.Parse(gET_VENTA_DEVOLUCION_REFDataGridView.Rows[e.RowIndex].Cells["DGPRECIOCONREBAJA"].Value.ToString());
                        estadoRebaja = int.Parse(gET_VENTA_DEVOLUCION_REFDataGridView.Rows[e.RowIndex].Cells["DGESTADOREBAJA"].Value.ToString());
                    }
                    catch
                    {

                    }

                    if(montoRebajaEspecial > 0 && estadoRebaja == 2)
                    {
                        TBPrecio.Text = precioConRebaja.ToString();
                        TBDescuento.Text = "0.0";
                        ignorePrecio = false;

                    }
                    else
                    {
                        TBPrecio.Text = gET_VENTA_DEVOLUCION_REFDataGridView.Rows[e.RowIndex].Cells["DGPRECIOUNIDADREF"].Value.ToString();
                        TBDescuento.Text = gET_VENTA_DEVOLUCION_REFDataGridView.Rows[e.RowIndex].Cells["DGDESCUENTOREF"].Value.ToString();
                        ignorePrecio = true;
                    }
                   

                   
                    long? P_MOVTOREFID = (long)gET_VENTA_DEVOLUCION_REFDataGridView.Rows[e.RowIndex].Cells["DGMOVTOREFID"].Value;
                    if (!ProcessCommandRef(ignorePrecio, false,P_MOVTOREFID))
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

        private void gET_VENTA_DEVOLUCION_REFDataGridView_EnterKeyDownEvent(object sender, EventArgs e)
        {
            //this.TBCommandLine.Focus();
            //gET_VENTA_DEVOLUCION_REFDataGridView.Focus();
            //this.TBTransacccion.Focus();
            SendKeys.Send("+{Tab}");
        }


        private void llenarDatosGeneralesDocto()
        {

            if (!(bool)m_Docto.isnull["IPERSONAID"])
            {
                llenarDatosCliente();
            }

            if (!(bool)m_Docto.isnull["IFOLIO"])
            {
                this.LBVenta.Text = m_Docto.IFOLIO.ToString();
            }

            if (!(bool)m_Docto.isnull["INOTAPAGO"])
            {
                NOTAPAGOTextBox.Text = m_Docto.INOTAPAGO;
            }
            else
            {
                NOTAPAGOTextBox.Text = "";
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





        private bool generarFacturaElectronica(bool bIgnoreDerecho)
        {

            CDOCTOD doctoD = new CDOCTOD();
            m_Docto = doctoD.seleccionarDOCTO(m_Docto, null);
            if (m_Docto.IFACTCONSID > 0 || m_Docto.IDEVCONSID > 0)
            {

                MessageBox.Show("No se puede generar la factura electronica porque pertenece a una factura consolidada");
                return false;
            }

            if(m_Docto.ITIMBRADOUUID != null && m_Docto.ITIMBRADOUUID.Trim().Length > 0)
            {

                MessageBox.Show("No se puede generar la factura electronica porque ya fue timbrada");
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


        private bool generarFacturaElectronicaPorId(long doctoId, FbTransaction fTrans, ref string resComentario)
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

            CUSUARIOSD usuariosD = new CUSUARIOSD();
            if (docto.IFECHAHORA.Month != DateTime.Now.Month)
            {
                if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_FACTURARFUERADEMES, fTrans))
                {
                    resComentario = "No tiene derecho para facturar una remision fuera de este mes";
                    return false;
                }
            }



            bool retorno = false;





            iPosReporting.WFFacturaElectronica fe = new iPosReporting.WFFacturaElectronica(docto, CurrentUserID.CurrentParameters, WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_TIMBRAR, fTrans, null, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
            fe.m_silentMode = true;
            fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
            fe.ShowDialog();
            retorno = fe.m_facturacionRealizada;
            m_strFileLog = fe.m_strFileLog;
            fe.Dispose();
            GC.SuppressFinalize(fe);

            if (retorno)
            {
                docto.IESFACTURAELECTRONICA = "S";
                doctoD.ACTUALIZARESFACTURAELECTRONICA(docto, fTrans);
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
            return retorno;
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
                m_Docto.ITIPODOCTOID = (m_tipoTransaccion == tipoTransaccionV.t_compra) ? 11 : 0;
                m_Docto = vData.SeleccionarXTIPOYFOLIO(m_Docto, null);

                if (m_Docto != null)
                {
                    if (m_Docto.IESTADOSURTIDOID == DBValues._DOCTO_SURTIDOESTADO_PENDIENTE || m_Docto.IESTADOSURTIDOID == DBValues._DOCTO_SURTIDOESTADO_ERROR)
                    {
                        m_Docto = new CDOCTOBE();
                        NuevoDevolucion();
                        m_estadoVenta = (int)estadoVenta.e_SinIniciar;
                        MessageBox.Show("No puede hacer devoluciones de esta transaccion porque aun no se ha surtido o hubo problemas al surtir");
                        e.Cancel = true;
                        return;
                    }

                    m_ClienteId = m_Docto.IPERSONAID;
                    if ((!(bool)m_Docto.isnull["IID"])
                   && (!(m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_CANCELADA || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_CANCELACION))
                   && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA || (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTAAPARTADO && m_Docto.IMERCANCIAENTREGADA == "S"))
                    {
                        NuevoDevolucion();
                        m_estadoVenta = (int)estadoVenta.e_SinIniciar;
                    }
                    llenarDatosCliente();
                }
                else
                {
                    m_Docto = new CDOCTOBE();
                    NuevoDevolucion();
                    m_estadoVenta = (int)estadoVenta.e_SinIniciar;

                    MessageBox.Show("El registro no existe");

                    e.Cancel = true;
                }

            }
        }

        private void TBTransacccion_Validated(object sender, EventArgs e)
        {

            if (TBTransacccion.Text.Trim() == "")
            {
                m_Docto = new CDOCTOBE();
                NuevoDevolucion();
                m_estadoVenta = (int)estadoVenta.e_SinIniciar;
            }
        }

        private void TBTransacccion_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (TBTransacccion.Text.Trim() == "" && m_bTieneDerechoAAbrirVentasCerradas)
                {

                    AbrirVentasParaDevolucion();
                    
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

        private void BtnImprimirFE_Click(object sender, EventArgs e)
        {
            imprimirFacturaElectronica();
        }

        private void btnDevolverDisp_Click(object sender, EventArgs e)
        {
            if(m_DoctoRef == null || m_DoctoRef.IID == 0)
            {
                MessageBox.Show("Debe seleccionar una venta para devolver");
                return;
            }


            if (MessageBox.Show("Esto eliminara los detalles de devolucion que haya creado en este momento. Realmente desea hacerlo?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            CDOCTOD doctoD = new CDOCTOD();

            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();

                long? doctoDevolucionActual = null;
                 if( m_Docto != null && m_Docto.IID > 0)
                    doctoDevolucionActual = m_Docto.IID;
                if(!doctoD.NOTACREDITO_DEVOLVERTODAVENTA(m_DoctoRef.IID, CurrentUserID.CurrentUser.IID,ref doctoDevolucionActual, fTrans))
                {
                    fTrans.Rollback();
                    fConn.Close();
                    MessageBox.Show("Hubo un error " + doctoD.IComentario);
                }
                else
                {
                    fTrans.Commit();
                    fConn.Close();
                    
                    AbrirVentaXId(doctoDevolucionActual.Value);
                    RefrescarEstatusBotones();

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




        }

        private void btnNoTransaccion_Click(object sender, EventArgs e)
        {

            WFSelectTransByFolio wf = new WFSelectTransByFolio("NotaCredito");
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
                IrAEstadoInicial();
                AbrirVentaXId((int)wf.m_selectedDocto.IID);
            }
            wf.Dispose();
            GC.SuppressFinalize(wf);
        }
    }
}