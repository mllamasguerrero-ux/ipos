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
using EglobalBBVA;
namespace iPos
{
    public partial class WFPagosBasico : IposForm
    {
        CDOCTOBE m_Docto;
        CCAJABE m_Caja;
        decimal m_dMontoVenta;
        decimal m_dMontoVentaConTope;
        decimal m_dSumaAbonos;
        decimal m_dRestanteAPagar;
        public string m_numeroVale = "";
        public bool m_bPagoCompleto;

        bool m_bVale;
        decimal m_montoVale;

        CDOCTOBE m_DoctoRef;
        tipoTransaccionV m_tipoTransaccion;

        string m_esapartado = "N";

        CPERSONABE m_persona = null;
        CPERSONABE m_supervisor = null;

        public bool m_afectarSaldosParciales = false;

        bool m_convierteApartado = false;
        long m_personaApartadoId = 0;

        bool m_bPermitirCredito = false;

        public bool m_generarFacturaElectronica;
        public bool m_generarComprobanteTraslado;
        public bool m_generarCartaPorte;

        public decimal m_monederoAplicado;
        public CMONEDEROBE m_monedero;

        public bool m_bPagoPorxCredito = false;

        public bool m_bCerrarVenta = false;
        public bool m_bCerrarTraspasoSalida = false;

        public bool m_bCerrarVentaFuturoAplicada = false;
        public bool m_bMantenerVentaFuturoAbierta = false;

        public bool m_surtidoPostpuesto = false;
        public bool m_revisionFinal = false;

        public bool m_bExportarSiAplica = true;

        public long m_tipoDescuentoVale = 1;
        public string m_referenciaDescuentoVale = "";

        public bool m_closeAfterLoad = false;

        public decimal m_creditoAutomatico = 0;

        public bool esRecarga = false;

        long m_bancomerParamId = 0;
        bool m_cobroConPinPadYaAplicado = false;


        long m_verifonePaymentId = 0;

        private bool m_pagoConPinpadHabilitado = false;

        private bool m_siempreDeshabilitaPagoConTarjeta = false;
        private bool m_siempreDeshabilitaPagoACredito = false;


        private int m_intentosPagoTarjetaConPinPad = 0;
        public bool m_timbrarPagosAlTerminar = false;

        public bool m_bAutomatizaPagoEfectivo = false;

        public bool m_bPagoVerifoneHabilitado = false;
        

        CDOCTOBE m_DoctoCompra;

        iPos.PuntoDeVenta.DSPuntoDeVentaAux2.PAGOSAVANZADODataTable otrosPagos;

        public CGUIABE m_guiaBE = null;

        public WFPagosBasico()
        {
            InitializeComponent();
            m_bPagoCompleto = false;
            m_generarFacturaElectronica = false;
            m_generarComprobanteTraslado = false;
            m_monedero = null;
            m_monederoAplicado = 0;

            otrosPagos = new PuntoDeVenta.DSPuntoDeVentaAux2.PAGOSAVANZADODataTable();
        }

        public WFPagosBasico(CDOCTOBE Docto, CCAJABE Caja, bool bVale, decimal montoVale,
                           CDOCTOBE DoctoRef, tipoTransaccionV tipoTransaccion, string esapartado,
                           CPERSONABE supervisor,
                           bool afectarSaldosParciales):this(Docto,Caja,bVale, montoVale,
                            DoctoRef, tipoTransaccion, esapartado, supervisor, afectarSaldosParciales,false,0)
        {
        }

        public WFPagosBasico(CDOCTOBE Docto, CCAJABE Caja, bool bVale, decimal montoVale,
                           CDOCTOBE DoctoRef, tipoTransaccionV tipoTransaccion, string esapartado,
                           CPERSONABE supervisor,
                           bool afectarSaldosParciales,
                           bool convierteApartado, long personaApartadoId)
            : this(Docto, Caja, bVale, montoVale,
                DoctoRef, tipoTransaccion, esapartado, supervisor, afectarSaldosParciales, convierteApartado, personaApartadoId, 1)
        {

        }

        
        public WFPagosBasico(CDOCTOBE Docto, CCAJABE Caja, bool bVale, decimal montoVale,
                           CDOCTOBE DoctoRef, tipoTransaccionV tipoTransaccion, string esapartado,
                           CPERSONABE supervisor,
                           bool afectarSaldosParciales,
                           bool convierteApartado, long personaApartadoId, long tipoDescuentoVale)
            : this(Docto, Caja, bVale, montoVale,
                DoctoRef, tipoTransaccion, esapartado, supervisor, afectarSaldosParciales, convierteApartado, personaApartadoId, tipoDescuentoVale, false)
        {

        }

         public WFPagosBasico(CDOCTOBE Docto, CCAJABE Caja, bool bVale, decimal montoVale,
                           CDOCTOBE DoctoRef, tipoTransaccionV tipoTransaccion, string esapartado,
                           CPERSONABE supervisor,
                           bool afectarSaldosParciales,
                           bool convierteApartado, long personaApartadoId, long tipoDescuentoVale, bool siempreDeshabilitaPagoConTarjeta)
            : this(Docto, Caja, bVale, montoVale,
                DoctoRef, tipoTransaccion, esapartado, supervisor, afectarSaldosParciales, convierteApartado, personaApartadoId, tipoDescuentoVale, siempreDeshabilitaPagoConTarjeta, false)
        {

        }

        public WFPagosBasico(CDOCTOBE Docto, CCAJABE Caja, bool bVale, decimal montoVale,
                           CDOCTOBE DoctoRef, tipoTransaccionV tipoTransaccion, string esapartado,
                           CPERSONABE supervisor,
                           bool afectarSaldosParciales,
                           bool convierteApartado, long personaApartadoId, long tipoDescuentoVale, bool siempreDeshabilitaPagoConTarjeta, bool siempreDeshabilitaPagoACredito)
            : this()
        {
            m_Caja = Caja;
            m_Docto = Docto;

            m_bVale = bVale;
            m_montoVale = montoVale;


            m_siempreDeshabilitaPagoConTarjeta = siempreDeshabilitaPagoConTarjeta;
            m_siempreDeshabilitaPagoACredito = siempreDeshabilitaPagoACredito;

            GetTotalesPagosVenta();
            RefreshTotalesVenta();
            HabilitarFormasPago();
            m_bPagoCompleto = false;

            m_DoctoRef = DoctoRef;
            m_tipoTransaccion = tipoTransaccion;

            m_esapartado = esapartado;
            m_afectarSaldosParciales = afectarSaldosParciales;

            m_convierteApartado = convierteApartado;
            m_personaApartadoId = personaApartadoId;

            m_supervisor = supervisor;

            m_tipoDescuentoVale = tipoDescuentoVale;



        }
        public void LimpiarPago()
        {
            
            this.PA_ABONOTextBox.Text = "";
        }
        public bool LlenarPago()
        {
            return true;
        }
        public void LimpiarTotalesPagosVenta()
        {
            m_dMontoVenta = 0;
            m_dSumaAbonos = 0;
            m_dRestanteAPagar = 0;
            m_dMontoVentaConTope = 0;
        }
        public void GetTotalesPagosVenta()
        {
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            decimal dMontoVenta = 0;
            decimal dMontoVentaConTope = 0;
            decimal dSumaAbonos = 0;
            decimal dRestanteAPagar = 0;
            dMontoVenta = m_Docto.ITOTAL;
            dMontoVentaConTope = this.GetTotalConTope();

            if (m_bVale)
                dRestanteAPagar = m_montoVale;
            else
                dRestanteAPagar = m_Docto.ITOTAL;


            //pvd.TotalesPagosVENTAS(m_Venta.IGV_VENTA, null, ref dMontoVenta, ref dSumaAbonos, ref dRestanteAPagar);

            if (pvd.IComentario == "" || pvd.IComentario == null)
            {
                m_dMontoVenta = dMontoVenta;
                m_dSumaAbonos = dSumaAbonos;
                m_dRestanteAPagar = dRestanteAPagar;
                m_dMontoVentaConTope = dMontoVentaConTope;
            }
            else
            {
                MessageBox.Show("ERRORES: " + pvd.IComentario.Replace("%", "\n"));
                LimpiarTotalesPagosVenta();
            }
        }



        public void HabilitarFormasPago()
        {
            CCLIENTEBE clienteBE = new CCLIENTEBE();
            CCLIENTED clienteD = new CCLIENTED();
            clienteBE.m_PersonaBE.IID = m_Docto.IPERSONAID;

            clienteBE.m_PersonaBE = clienteD.seleccionarPERSONA(clienteBE.m_PersonaBE, null);

            if (clienteBE.m_PersonaBE != null)
            {
                
                
                if (!(bool)clienteBE.m_PersonaBE.isnull["IHAB_PAGOEFECTIVO"])
                {
                    this.PA_ABONOTextBox.Enabled = (clienteBE.m_PersonaBE.IHAB_PAGOEFECTIVO == DBValues._DB_BOOLVALUE_SI);
                }
                else
                {
                    this.PA_ABONOTextBox.Enabled = false;
                }

                if(m_siempreDeshabilitaPagoConTarjeta)
                {
                    this.TBMontoTarjeta.Enabled = false;
                }
                else
                {

                    if (!(bool)clienteBE.m_PersonaBE.isnull["IHAB_PAGOTARJETA"])
                    {
                        this.TBMontoTarjeta.Enabled = (clienteBE.m_PersonaBE.IHAB_PAGOTARJETA == DBValues._DB_BOOLVALUE_SI);
                    }
                    else
                    {
                        this.TBMontoTarjeta.Enabled = false;
                    }
                

                }


                if (!(bool)clienteBE.m_PersonaBE.isnull["IHAB_PAGOCHEQUE"])
                {
                    this.TBMontoCheque.Enabled = (clienteBE.m_PersonaBE.IHAB_PAGOCHEQUE == DBValues._DB_BOOLVALUE_SI);
                }
                else
                {
                    this.TBMontoCheque.Enabled = false;
                }


                if(this.m_siempreDeshabilitaPagoACredito)
                {
                    this.m_bPermitirCredito = false;
                }
                else
                {

                    if (!(bool)clienteBE.m_PersonaBE.isnull["IHAB_PAGOCREDITO"])
                    {
                        this.m_bPermitirCredito = (clienteBE.m_PersonaBE.IHAB_PAGOCREDITO == DBValues._DB_BOOLVALUE_SI);
                        //this.TBMontoCredito.Enabled = (clienteBE.m_PersonaBE.IHAB_PAGOCREDITO == DBValues._DB_BOOLVALUE_SI);
                    }
                    else
                    {
                        this.m_bPermitirCredito = false;
                        //this.TBMontoCredito.Enabled = false;
                    }
                }



                if (!(bool)clienteBE.m_PersonaBE.isnull["IHAB_PAGOTRANSFERENCIA"])
                {
                    this.TBMontoTransferencia.Enabled = (clienteBE.m_PersonaBE.IHAB_PAGOTRANSFERENCIA == DBValues._DB_BOOLVALUE_SI);
                }
                else
                {
                    this.TBMontoTransferencia.Enabled = true;
                }


            }
            else
            {
                this.TBMontoTarjeta.Enabled = !m_siempreDeshabilitaPagoConTarjeta;
                //this.TBMontoCredito.Enabled = true;
                this.TBMontoCheque.Enabled = true;
                //this.TBMontoVale.Enabled = true;
                this.TBMontoTransferencia.Enabled = true;
            }

            // si se especifico en al venta pago con tarjeta solo habilitar para el pago con tarjeta y efectivo
            if (!(bool)m_Docto.isnull["IPAGOCONTARJETA"] && m_Docto.IPAGOCONTARJETA != null && 
                (m_Docto.IPAGOCONTARJETA.Equals("S") || m_Docto.IPAGOCONTARJETA.Equals("C") ||  m_Docto.IPAGOCONTARJETA.Equals("D")))
            {
                if (!this.TBMontoTarjeta.Enabled)
                {
                    MessageBox.Show("Este usuario no tiene habilitado el pago con tarjeta, y la venta se aplico con comision de tarjeta, corriga");
                    m_closeAfterLoad = true;
                }
                else
                {
                    TBMontoCheque.Enabled = false;
                    TBMontoTransferencia.Enabled = false;
                }
            }

            this.pnlBancarioTarjeta.Enabled = this.TBMontoTarjeta.Enabled;
            this.pnlBancarioCheque.Enabled = this.TBMontoCheque.Enabled;
            this.pnlBancarioTransferencia.Enabled = this.TBMontoTransferencia.Enabled;


            BtnAvanzado.Enabled = !(!(bool)m_Docto.isnull["IPAGOCONTARJETA"] && m_Docto.IPAGOCONTARJETA != null &&
                       (m_Docto.IPAGOCONTARJETA.Equals("S") || m_Docto.IPAGOCONTARJETA.Equals("C") || m_Docto.IPAGOCONTARJETA.Equals("D"))) ;



        }

        public void RefreshTotalesVenta()
        {

            decimal tipoCambio = (((bool)m_Docto.isnull["ITIPOCAMBIO"] || m_Docto.ITIPOCAMBIO == 0) ? 1 : m_Docto.ITIPOCAMBIO);
            if (m_bVale)
            {
                this.TBPagosTotalVenta.Text = (this.m_montoVale / tipoCambio).ToString("N2");
                this.TBMontoVale.Enabled = true;
            }
            else
            {
                if(CurrentUserID.CurrentParameters.IVERSIONTOPEID == 2
                    && CurrentUserID.CurrentParameters.IREBAJAESPECIAL != null && CurrentUserID.CurrentParameters.IREBAJAESPECIAL.Equals("S")
                   && this.m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA 
                   && this.m_Docto.ISUBTIPODOCTOID != DBValues._DOCTO_SUBTIPO_TRASPASOFRANQUICIA 
                   && this.m_Docto.ISUBTIPODOCTOID != DBValues._DOCTO_SUBTIPO_TRASPASOFRANQUICIA_SALIDA
                    )
                {

                    this.TBPagosTotalVenta.Text = (this.m_dMontoVentaConTope / tipoCambio).ToString("N2");
                    this.TBMontoVale.Enabled = false;
                }
                else
                {

                    this.TBPagosTotalVenta.Text = (this.m_dMontoVenta / tipoCambio).ToString("N2");
                    this.TBMontoVale.Enabled = false;
                }

            }
            
        }
        private void dETALLE_DE_PAGODataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
            }
        }
        private void dETALLE_DE_PAGODataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            e.Cancel = true;
        }
        private void dETALLE_DE_PAGODataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
            }
        }

        private void GuardarPago()
        {
            AsignarCambio();
            long formaPagoFE = 0;


            decimal tipoCambio = (((bool)m_Docto.isnull["ITIPOCAMBIO"] || m_Docto.ITIPOCAMBIO == 0) ? 1 : m_Docto.ITIPOCAMBIO);

            decimal dPagoTotal;
            decimal dPagoEfectivo = decimal.Parse(PA_ABONOTextBox.NumericValue.ToString()) * tipoCambio;
            decimal dPagoTarjeta = decimal.Parse(this.TBMontoTarjeta.NumericValue.ToString()) * tipoCambio;
            decimal dPagoCredito = 0/*decimal.Parse(this.TBMontoCredito.NumericValue.ToString())*/;
            decimal dPagoCheque = decimal.Parse(this.TBMontoCheque.NumericValue.ToString()) * tipoCambio;
            decimal dPagoVale = decimal.Parse(this.TBMontoVale.NumericValue.ToString()) * tipoCambio;
            decimal dMonederoAplicado = decimal.Parse(this.TBMonederoAplicado.Text.ToString()) * tipoCambio;
            decimal dPagoTransferencia = decimal.Parse(this.TBMontoTransferencia.NumericValue.ToString()) * tipoCambio;
            decimal dPagoCreditoAutomatico = this.m_creditoAutomatico;
            decimal dSaldoCompraRelacionada = m_DoctoCompra != null ? m_DoctoCompra.ISALDO  * tipoCambio : 0;
            decimal dPagoOtros = decimal.Parse(this.lblOtros.Text) * tipoCambio;


            decimal dCambioCheque = 0;

            decimal dPagoEfectivoRecibido = dPagoEfectivo;

            decimal pagoAplicarCompra = 0;

            bool reimprimirPagosVerifone = false;
            CVERIFONEPAYMENTBE verifonePaymentBE = null;


            m_bPagoPorxCredito = false;

            dPagoTotal = dPagoEfectivo + dPagoTarjeta /*+ dPagoCredito*/ + dPagoCheque + dPagoVale + dPagoCreditoAutomatico /* + dPagoCreditoManual*/ + dMonederoAplicado + dPagoTransferencia + dPagoOtros;



            //compra relacionada
            if(dSaldoCompraRelacionada > 0)
            {
                if (m_Docto.ITOTAL - dPagoTotal > dSaldoCompraRelacionada)
                {
                    pagoAplicarCompra = dSaldoCompraRelacionada;
                }
                else
                {
                    pagoAplicarCompra = m_Docto.ITOTAL - dPagoTotal;
                }
                 dPagoTotal += pagoAplicarCompra;
                 dPagoCredito += pagoAplicarCompra;
            }


            //checa si se ha pagado todo
            if (dPagoTotal + dSaldoCompraRelacionada < Math.Round(m_Docto.ITOTAL,2))
            {
                if (!(m_bVale && dPagoTotal>=m_montoVale))
                {

                    if (m_bPermitirCredito)
                    {
                        WFPagoPreguntarCredito wf = new WFPagoPreguntarCredito();
                        wf.ShowDialog();
                        bool bAsignarCredito = wf.m_bAsignarCredito;
                        wf.Dispose();
                        GC.SuppressFinalize(wf);

                        if (bAsignarCredito)
                        {

                            dPagoCredito += m_dRestanteAPagar - dPagoTotal;

                            if (!ValidarCredito(dPagoCredito))
                            {
                                return;
                            }
                            m_bPagoPorxCredito = true;
                            dPagoTotal += dPagoCredito;
                        }
                        else
                        {
                            MessageBox.Show("no se ha pagado el monto total de la venta, el total minimo a pagar es: " + m_Docto.ITOTAL.ToString("N2"));
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("no se ha pagado el monto total de la venta, el total minimo a pagar es: " + m_Docto.ITOTAL.ToString("N2"));
                        return;
                    }

                }
            }



            if ( !(bool)m_Docto.isnull["IPAGOCONTARJETA"] && m_Docto.IPAGOCONTARJETA != null &&
                        (m_Docto.IPAGOCONTARJETA.Equals("S") || m_Docto.IPAGOCONTARJETA.Equals("C") || m_Docto.IPAGOCONTARJETA.Equals("D")))
            {
                if (dPagoTarjeta == 0)
                {
                    MessageBox.Show("necesita hacer algun pago con tarjeta pues se espefico en la venta que se pagaria con tarjeta");
                    return;
                }
                

                if (m_Docto.IPAGOCONTARJETA.Equals("D") && CBTIPOTARJETA.SelectedIndex != 1)
                {
                    MessageBox.Show("el pago debe ser con tarjeta de debito");
                    return;
                }

                if (m_Docto.IPAGOCONTARJETA.Equals("C") && (CBTIPOTARJETA.SelectedIndex != 0 && CBTIPOTARJETA.SelectedIndex <= 2))
                {
                    MessageBox.Show("el pago debe ser con tarjeta de credito");
                    return;
                }
            }

            if (dPagoTarjeta > Math.Ceiling(m_dRestanteAPagar))
            {

                MessageBox.Show("el monto de la tarjeta no puede superar el total de la venta");
                return;
            }



            // si se entro a pagar como vale, entonces el monto del vale no puede ser cero
            if (m_bVale && dPagoVale <= 0 && this.m_tipoDescuentoVale == 1)
            {
                MessageBox.Show("Debe ingresar un monto valido para el vale");
                return;
            }



            // si es vale pregunta el # de vale
            if (dPagoVale > 0)
            {
                

                    string numvale = "";
                    WFPreguntaVale wf1_ = new WFPreguntaVale();
                    wf1_.ShowDialog();
                    numvale = wf1_.m_vale.Trim();
                    wf1_.Dispose();
                    GC.SuppressFinalize(wf1_);

                    if (numvale != "")
                    {
                        this.m_numeroVale = numvale;
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar un numero de vale");
                        return;
                    }
            }


            if(this.m_tipoDescuentoVale > 1)
            {
                string numvale = "";
                WFPreguntaReferenciaDescuento wf1_ = new WFPreguntaReferenciaDescuento();
                wf1_.ShowDialog();
                numvale = wf1_.m_vale.Trim();
                wf1_.Dispose();
                GC.SuppressFinalize(wf1_);

                if (numvale != "")
                {
                    this.m_referenciaDescuentoVale = numvale;
                }
                else
                {
                    MessageBox.Show("Debe ingresar una referencia");
                    return;
                }
            }


            decimal dCambio = dPagoTotal - m_dRestanteAPagar;



            string strReferenciaTarjeta = "", strReferenciaCheque = "", strReferenciaTransferencia = "";
            long lBancoTarjeta = 0, lBancoCheque = 0, lBancoTransferencia = 0;

            if (dPagoTarjeta > 0)
            {
                //PAGO TERMINAL BANCOMER
                CUSUARIOSD usuariosD = new CUSUARIOSD();
                

                bool aplicarPagoConTarjetaSinPinPadDirecto = true;

                bool pagoBancomerHabilitado = CurrentUserID.CurrentParameters.IBANCOMERHABPINPAD != null && CurrentUserID.CurrentParameters.IBANCOMERHABPINPAD == "S" &&
                    usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_PAGO_TERMINAL_BANCOMER, null);
                
                if (pagoBancomerHabilitado || m_bPagoVerifoneHabilitado)
                {

                    aplicarPagoConTarjetaSinPinPadDirecto = false;

                    

                        /* if ((this.TBReferenciaTarjeta.Text.Trim().Length == 0 || this.ComboBancoTarjeta.SelectedIndex < 0))
                         {
                             MessageBox.Show("Debe seleccionar el banco y la referencia si esta pagando con tarjeta o cheque");
                             return;
                         }*/

                    if (this.ComboBancoTarjeta.SelectedIndex >= 0)
                        lBancoTarjeta = long.Parse(this.ComboBancoTarjeta.SelectedValue.ToString());

                    strReferenciaTarjeta = this.TBReferenciaTarjeta.Text;


                    if (!m_cobroConPinPadYaAplicado)
                    {

                        //si lleva varios intentos fallidos darle la opcion de solo registrar el pago sin pasar por el pinpad ( si tiene el derecho )
                        if (m_intentosPagoTarjetaConPinPad >= 2)
                        {
                            if (usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_OBVIAR_PAGO_TERMINAL_BANCOMER, null))
                            {
                                if (MessageBox.Show("Ya ha hecho 2 intentos o mas por usar la pinpad , desea usar la terminal alternativa y solo asignar la referencia bancaria?", "Intentos fallidos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    aplicarPagoConTarjetaSinPinPadDirecto = true;
                                }
                            }
                        }

                        if (!aplicarPagoConTarjetaSinPinPadDirecto)
                        {
                            if (pagoBancomerHabilitado)
                            {

                                if (!PagoBancomerHelper.Pagar(ref this.m_Docto, dPagoTarjeta, ref m_bancomerParamId, null))
                                {
                                    m_intentosPagoTarjetaConPinPad++;
                                    MessageBox.Show(PagoBancomerHelper.strResTransaccion);
                                    return;
                                }
                                m_cobroConPinPadYaAplicado = true;
                                TBMontoTarjeta.Enabled = false;
                                //los demas campos de tarjeta hay que deshabilitarlos


                                CBANCOMERPARAMBE bancomerParamBE = ObtenerPagoPorTarjetaPinPad(m_bancomerParamId);
                                CBANCOSBE bancoBE = ObtenerBancoDesdeClave("BANCOMER");


                                //referencia
                                TBReferenciaTarjeta.Text = bancomerParamBE.IREFERENCIAAFIN;

                                //tipo credito debito
                                if (bancomerParamBE.ICREDITODEBITO != null && bancomerParamBE.ICREDITODEBITO == "Debito")
                                {
                                    this.CBTIPOTARJETA.SelectedIndex = 1;
                                }
                                else
                                {
                                    this.CBTIPOTARJETA.SelectedIndex = 0;
                                }

                                //banco
                                //cuando se implemente lo de averiguar banco que se seleccione el banco
                                /*if (bancoBE != null && bancoBE.IID > 0)
                                {
                                    this.ComboBancoTarjeta.SelectedValue = bancoBE.IID;
                                }
                                else
                                {
                                    if (this.ComboBancoTarjeta.Items.Count > 0)
                                    {
                                        this.ComboBancoTarjeta.SelectedIndex = 0;
                                    }
                                }*/


                                PagoBancomerHelper.ImprimirVoucher(m_bancomerParamId, true, true);
                            }
                            else if (m_bPagoVerifoneHabilitado)
                            {
                                string strResTransaccionTarjeta = "";
                                if (!PagoVerifoneHelper.Pagar(ref this.m_Docto, dPagoTarjeta, ref m_verifonePaymentId, ref strResTransaccionTarjeta, ref reimprimirPagosVerifone, null))
                                {
                                    m_intentosPagoTarjetaConPinPad++;
                                    MessageBox.Show(strResTransaccionTarjeta);
                                    return;
                                }
                                m_cobroConPinPadYaAplicado = true;
                                TBMontoTarjeta.Enabled = false;
                                //los demas campos de tarjeta hay que deshabilitarlos


                                verifonePaymentBE = this.ObtenerVerifonePagoPorTarjetaPinPad(m_verifonePaymentId);


                                //asignar banco
                                CBANCOSBE bancoBE = ObtenerBancoDesdeClave("HSBC");
                                if (this.ComboBancoTarjeta.SelectedIndex < 0)
                                {
                                    if (bancoBE != null)
                                        this.ComboBancoTarjeta.SelectedDataValue = bancoBE.IID;
                                    else
                                        this.ComboBancoTarjeta.SelectedIndex = 0;
                                }

                                //referencia
                                TBReferenciaTarjeta.Text = verifonePaymentBE.IOPERACION;

                                //tipo credito debito
                                if (verifonePaymentBE.ICARDTYPE != null && verifonePaymentBE.ICARDTYPE== "DEBIT")
                                {
                                    this.CBTIPOTARJETA.SelectedIndex = 1;
                                }
                                else
                                {
                                    this.CBTIPOTARJETA.SelectedIndex = 0;
                                }



                            }


                            if (this.ComboBancoTarjeta.SelectedIndex >= 0)
                                lBancoTarjeta = long.Parse(this.ComboBancoTarjeta.SelectedValue.ToString());
                            strReferenciaTarjeta = this.TBReferenciaTarjeta.Text;
                        }
                    }




                }
                

                if(aplicarPagoConTarjetaSinPinPadDirecto)
                {

                    if ((this.TBReferenciaTarjeta.Text.Trim().Length == 0 || this.ComboBancoTarjeta.SelectedIndex < 0))
                    {
                        MessageBox.Show("Debe seleccionar el banco y la referencia si esta pagando con tarjeta o cheque");
                        return;
                    }

                    if (this.ComboBancoTarjeta.SelectedIndex >= 0)
                        lBancoTarjeta = long.Parse(this.ComboBancoTarjeta.SelectedValue.ToString());
                    strReferenciaTarjeta = this.TBReferenciaTarjeta.Text;
                }
            }


            if (dPagoCheque > 0)
            {

                if ((this.TBReferenciaCheque.Text.Trim().Length == 0 || this.ComboBancoCheque.SelectedIndex < 0))
                {
                    MessageBox.Show("Debe seleccionar el banco y la referencia si esta pagando con tarjeta o cheque");
                    return;
                }

                if (this.ComboBancoCheque.SelectedIndex >= 0)
                    lBancoCheque = long.Parse(this.ComboBancoCheque.SelectedValue.ToString());
                strReferenciaCheque = this.TBReferenciaCheque.Text;
            }



            if (dPagoTransferencia > 0)
            {

                if ((this.TBReferenciaTransferencia.Text.Trim().Length == 0 || this.ComboBancoTransferencia.SelectedIndex < 0))
                {
                    MessageBox.Show("Debe seleccionar el banco y la referencia si esta pagando con tarjeta ,cheque o transferencia");
                    return;
                }

                if (this.ComboBancoTransferencia.SelectedIndex >= 0)
                    lBancoTransferencia = long.Parse(this.ComboBancoTransferencia.SelectedValue.ToString());
                strReferenciaTransferencia = this.TBReferenciaTransferencia.Text;
            }


            //CARTA PORTE PRESELECCION
            m_generarComprobanteTraslado = this.CBComprobanteTraslado.Checked;
            m_generarCartaPorte = this.CBCartaPorte.Checked;
            if (m_generarCartaPorte && !m_generarComprobanteTraslado)
            {
                MessageBox.Show("Si requiere carta porte necesita seleccionar tambien la opcion de generar traslado");
                return;
            }
            
            if(m_generarCartaPorte)
            {
                iPos.Guia.WFGuiaPopUp ic_ = new Guia.WFGuiaPopUp();
                ic_.ShowDialog();
                m_guiaBE = ic_.m_guiaBE;
                ic_.Dispose();
                GC.SuppressFinalize(ic_);

                if(m_guiaBE == null)
                {

                    MessageBox.Show("Si requiere carta porte necesita ingresar la informacion de guia/vehiculo/fechas");
                    return;
                }
            }


            //FACTURA ELECTRONICA PRESELECCION
            m_generarFacturaElectronica = this.CBFacturaElectronica.Checked;

            m_surtidoPostpuesto = CBSurtidoPostpuesto.Checked;
            m_revisionFinal = CBRevisionFinal.Checked;

            if (m_generarFacturaElectronica &&
                CurrentUserID.CurrentParameters.IVERSIONCFDI != null &&
                (CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("3.3") || CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0")))
            {

                //si no esta seleccionado un cfdi tipo marca error
                //si esta seleccionado manda llamar a un metodo de doctod que solo actualize el usocfdi para este docto
                if (this.USOCFDITextBox.SelectedIndex >= 0)
                {
                    m_Docto.ISAT_USOCFDIID = long.Parse(this.USOCFDITextBox.SelectedValue.ToString());
                    CDOCTOD doctoDCFDI = new CDOCTOD();
                    if (!doctoDCFDI.CambiarSAT_USOCFDIIDD(m_Docto, null))
                    {
                        MessageBox.Show("Error!: No se pudo cambiar el Uso CFDI en el Docto!");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Debes asignar un Uso CFDI para poder facturar!");
                    this.USOCFDITextBox.Focus();
                    return;
                }
            }

            if (m_generarFacturaElectronica )
            {
                //if (!m_surtidoPostpuesto && false)
                //{


                //    if (!FacturaElectronica(null, dPagoEfectivo, dPagoTarjeta, dPagoCredito, dPagoCheque, dPagoVale, dPagoTransferencia, dPagoCreditoAutomatico, ref formaPagoFE, false))
                //    {
                //        MessageBox.Show("No se pudo generar la factura electronica");
                //        return;
                //    }
                //}
                //else
                //{
                    if (!FacturaElectronica(null, dPagoEfectivo, dPagoTarjeta, dPagoCredito, dPagoCheque, dPagoVale, dPagoTransferencia, dPagoCreditoAutomatico, ref formaPagoFE, true))
                    {
                        MessageBox.Show("No se pudo validar para factura electronica");
                        return;
                    }
                    CDOCTOD doctoD = new CDOCTOD();
                    m_Docto.IESFACTURAELECTRONICA = "S";
                    doctoD.ACTUALIZARESFACTURAELECTRONICA(m_Docto, null);



                //}
            }
            




            CDOCTOPAGOBE pagoBE;
            CDOCTOPAGOD pagoD = new CDOCTOPAGOD();

            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());

            FbTransaction fTrans = null;
            try
            {

                fConn.Open();
                fTrans = fConn.BeginTransaction();

                if(!AplicaPromocionRebajaSiAplica(fTrans))
                {

                    fTrans.Rollback();
                    MessageBox.Show("Ocurrio un error al promover la rebaja de precio");
                    throw new Exception();
                }





                pagoBE = new CDOCTOPAGOBE();
                pagoBE.IDOCTOID = m_Docto.IID;
                pagoBE.IFECHA = DateTime.Now;
                pagoBE.IFECHAHORA = DateTime.Now;
                pagoBE.ICORTEID = CurrentUserID.CurrentUser.ICORTEID;//m_Caja.ICORTEID;


                if(dPagoEfectivo>= dCambio)
                {
                    dPagoEfectivo -= dCambio;
                }
                else if (dCambio > dPagoEfectivo && (dPagoCheque + dPagoEfectivo) >= dCambio)
                {
                    dPagoEfectivo = 0;
                    dCambioCheque = dCambio - dPagoEfectivo;
                }
                else
                {
                    dPagoEfectivo -= dCambio;
                }

                if (!ConvierteApartadoSiAplica(fTrans))
                {

                    fTrans.Rollback();
                    MessageBox.Show("Ocurrio un error al asignar venta de apartado");
                    throw new Exception();
                }

                switch(this.m_tipoTransaccion)
                {
                    case tipoTransaccionV.t_venta:

                        pagoBE.IDOCTOID = m_Docto.IID;
                        pagoBE.ITIPOPAGOID = DBValues._TIPOPAGO_ENTRADA;
                        break;
                    case tipoTransaccionV.t_devolucion:
                        pagoBE.IDOCTOSALIDAID = m_Docto.IID;
                        pagoBE.ITIPOPAGOID = DBValues._TIPOPAGO_SALIDA;
                        pagoBE.IDOCTOID = this.m_DoctoRef.IID;
                        break;
                    case tipoTransaccionV.t_cancelaciondevolucion:
                        pagoBE.IDOCTOSALIDAID = this.m_DoctoRef.IID;
                        pagoBE.ITIPOPAGOID = DBValues._TIPOPAGO_ENTRADA;
                        pagoBE.IDOCTOID =  m_Docto.IID;
                        break;
                    case tipoTransaccionV.t_ventaapartado:

                        pagoBE.IDOCTOID = m_Docto.IID;
                        pagoBE.ITIPOPAGOID = DBValues._TIPOPAGO_ENTRADA;
                        break;
                    case tipoTransaccionV.t_cancelacionapartado:
                        pagoBE.IDOCTOSALIDAID = m_Docto.IID;
                        pagoBE.ITIPOPAGOID = DBValues._TIPOPAGO_SALIDA;
                        pagoBE.IDOCTOID = this.m_DoctoRef.IID;
                        break;

                    case tipoTransaccionV.t_compra:

                        pagoBE.IDOCTOSALIDAID = m_Docto.IID;
                        pagoBE.ITIPOPAGOID = DBValues._TIPOPAGO_SALIDA;
                        pagoBE.IDOCTOID = 0;
                        break;


                    case tipoTransaccionV.t_compradevolucion:
                        
                        pagoBE.IDOCTOSALIDAID = this.m_DoctoRef.IID;
                        pagoBE.ITIPOPAGOID = DBValues._TIPOPAGO_ENTRADA;
                        pagoBE.IDOCTOID = m_Docto.IID;
                        break;

                    case tipoTransaccionV.t_compracancelaciondevolucion:
                        pagoBE.IDOCTOSALIDAID = m_Docto.IID;
                        pagoBE.ITIPOPAGOID = DBValues._TIPOPAGO_SALIDA;
                        pagoBE.IDOCTOID = this.m_DoctoRef.IID;
                        break;

                }

                pagoBE.IESAPARTADO = m_esapartado;
                pagoBE.IESPAGOINICIAL = DBValues._DB_BOOLVALUE_SI;

                long tarjetaFormaPagoSatId = DBValues._FORMA_PAGOSAT_TARJETACREDITO;
                switch(CBTIPOTARJETA.SelectedIndex)
                {
                    case 0: tarjetaFormaPagoSatId = DBValues._FORMA_PAGOSAT_TARJETACREDITO; break;
                    case 1: tarjetaFormaPagoSatId = DBValues._FORMA_PAGOSAT_TARJETADEBITO; break;
                    case 2: tarjetaFormaPagoSatId = DBValues._FORMA_PAGOSAT_TARJETASERVICIO; break;
                    default: tarjetaFormaPagoSatId = DBValues._FORMA_PAGOSAT_TARJETACREDITO; break;
                }

                if (!pagoD.DOCTO_PAGO_SP(pagoBE, m_dRestanteAPagar, dPagoEfectivo, dPagoTarjeta, dPagoCheque, dPagoCredito, dPagoVale, dPagoEfectivoRecibido, dCambioCheque, dPagoCreditoAutomatico, 0, 0, CurrentUserID.CurrentUser.IID, lBancoTarjeta, strReferenciaTarjeta, lBancoCheque, strReferenciaCheque, dMonederoAplicado, TBNumeroMonedero.Text, dPagoTransferencia, lBancoTransferencia, strReferenciaTransferencia, tarjetaFormaPagoSatId, m_bancomerParamId, m_verifonePaymentId, fTrans))
                {
                    fTrans.Rollback();
                    MessageBox.Show("Error al ejecutar insercion de pagos " + pagoD.IComentario);
                    //fTrans.Commit();
                    throw new Exception();
                }



                if (dPagoOtros > 0 && otrosPagos.Rows.Count > 0)
                {
                    string comentarioOtrospagos = "";
                    if (!InsertarOtrosPagos(dPagoOtros, otrosPagos, ref comentarioOtrospagos, fTrans))
                    {

                        fTrans.Rollback();
                        MessageBox.Show("Error al aplicar los otros pagos " + comentarioOtrospagos);
                        throw new Exception();
                    }
                }

                //aplicar saldo de compra de proveedor relacionado si es que aplica
                if (m_DoctoCompra != null && pagoAplicarCompra > 0)
                {
                    string comentarioCompraSaldo = "";
                    if (!PagarConSaldoCompra(pagoAplicarCompra, ref comentarioCompraSaldo, fTrans))
                    {

                        fTrans.Rollback();
                        MessageBox.Show("Error al aplicar saldo de compra " +  comentarioCompraSaldo);
                        throw new Exception();
                    }
                }


                if (m_generarFacturaElectronica)
                {
                    if(!pagoD.ASIGNARPAGO_FACTELECTRONICA(m_Docto.IID, formaPagoFE, fTrans))
                    {
                        fTrans.Rollback();
                        MessageBox.Show(pagoD.IComentario);
                        throw new Exception();
                   }
                }
                else if((m_Docto.IESFACTURAELECTRONICA != null && m_Docto.IESFACTURAELECTRONICA.Equals("S")))
                {
                    CDOCTOD doctoD = new CDOCTOD();
                    m_Docto.IESFACTURAELECTRONICA = "N";
                    doctoD.CambiarESFACTURAELECTRONICA(m_Docto, fTrans);
                }





                    if (m_afectarSaldosParciales)
                {

                    if (m_Docto.ITIPODOCTOID != DBValues._DOCTO_TIPO_VENTAAPARTADO)
                    {
                        if (!pagoD.AjustarSaldosPersona(m_Docto.IPERSONAID, fTrans))
                        {

                            fTrans.Rollback();
                            MessageBox.Show("Error al ajustar saldos persona " +  pagoD.IComentario);
                            throw new Exception();
                        }
                    }
                    else
                    {
                        if (!pagoD.AjustarSaldosPersonaApartado(m_Docto.IPERSONAAPARTADOID, fTrans))
                        {

                            fTrans.Rollback();
                            MessageBox.Show("Error al ajustar apartado " + pagoD.IComentario);
                            throw new Exception();
                        }
                    }
                }

                if (m_bVale)
                {
                    if (!AplicarDescuentoVale(fTrans))
                    {
                        fTrans.Rollback();
                        MessageBox.Show("Error al aplicar descuento vale " +  pagoD.IComentario);
                        throw new Exception();
                    }
                }


                if (!GuardaNotaPago(fTrans))
                {

                    fTrans.Rollback();
                    MessageBox.Show("Hubo un problema al guardar la nota de pago");
                    throw new Exception();
                }


                CPuntoDeVentaD pvd = new CPuntoDeVentaD();
                /*if (CurrentUserID.CurrentParameters.IMANEJAKITS.Equals("S") && (m_bCerrarVenta || m_bCerrarTraspasoSalida))
                {
                    if(!AplicarKitEnsamblesSiAplica(fTrans))
                    {
                        fTrans.Rollback();
                        MessageBox.Show("ERRORES: " + pvd.IComentario.Replace("%", "\n"));
                        throw new Exception();
                    }
                }*/


                /* surtido estado */

                if (CurrentUserID.CurrentParameters.IHABSURTIDOPREVIO != null && CurrentUserID.CurrentParameters.IHABSURTIDOPREVIO.Equals("S"))
                {
                    CDOCTOD doctoD = new CDOCTOD();
                    m_Docto.IESTADOSURTIDOID = DBValues._DOCTO_SURTIDOESTADO_SURTIDO;
                    if (!doctoD.CambiarESTADOSURTIDOID(m_Docto, fTrans))
                    {
                        fTrans.Rollback();
                        MessageBox.Show("ERRORES al cambiar estado surtido : " + doctoD.IComentario.Replace("%", "\n"));
                        throw new Exception();
                    }
                }

                if (CurrentUserID.CurrentParameters.IHABSURTIDOPOSTPUESTO != null && CurrentUserID.CurrentParameters.IHABSURTIDOPOSTPUESTO.Equals("S")  )
                {
                    CDOCTOD doctoD = new CDOCTOD();
                    m_Docto.IESTADOSURTIDOID = CBSurtidoPostpuesto.Checked ? ( 
                         (( m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA &&
                                    ((CurrentUserID.CurrentParameters.ICXCVALIDARTRASLADOS != null && CurrentUserID.CurrentParameters.ICXCVALIDARTRASLADOS.Equals("S")) || (m_Docto.ISUBTIPODOCTOID != DBValues._DOCTO_SUBTIPO_TRASPASOFRANQUICIA && m_Docto.ISUBTIPODOCTOID != DBValues._DOCTO_SUBTIPO_TRASPASOFRANQUICIA_SALIDA))
                          ) ||
                          (CurrentUserID.CurrentParameters.ICXCVALIDARTRASLADOS != null && CurrentUserID.CurrentParameters.ICXCVALIDARTRASLADOS.Equals("S") && (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_PEDIDO_TRASPASO_SALIDA))
                         )  &&
                        CurrentUserID.CurrentParameters.IHABVERIFICACIONCXC != null && CurrentUserID.CurrentParameters.IHABVERIFICACIONCXC.Equals("S") ? DBValues._DOCTO_SURTIDOESTADO_CXC 
                        : DBValues._DOCTO_SURTIDOESTADO_PENDIENTE) 
                        : DBValues._DOCTO_SURTIDOESTADO_SURTIDO;

                    if (!doctoD.CambiarESTADOSURTIDOID(m_Docto, fTrans))
                    {

                        fTrans.Rollback();
                        MessageBox.Show("ERRORES al cambiar estado surtido : " + doctoD.IComentario.Replace("%", "\n"));
                        throw new Exception();
                    }
                    m_bExportarSiAplica = !CBSurtidoPostpuesto.Checked;
                }

                    /* revisado estado */
                    if (CurrentUserID.CurrentParameters.IHABREVISIONFINAL != null && CurrentUserID.CurrentParameters.IHABREVISIONFINAL.Equals("S"))
                {
                    CDOCTOD doctoD = new CDOCTOD();
                    m_Docto.IESTADOREVISADOID = this.CBRevisionFinal.Checked ? DBValues._DOCTO_REVISIONFINAL_PENDIENTE : DBValues._DOCTO_REVISIONFINAL_REVISADO;

                    if (!doctoD.CambiarESTADOREVISADOID(m_Docto, fTrans))
                    {

                        fTrans.Rollback();
                        MessageBox.Show("ERRORES al cambiar estado revision : " + doctoD.IComentario.Replace("%", "\n"));
                        throw new Exception();
                    }
                }


                if (m_bCerrarVenta)
                {
                    pvd.CerrarVenta(m_Docto, fTrans);
                    //pvd.IComentario = "Error";
                    if (!(pvd.IComentario == null || pvd.IComentario == "" ))
                    {
                        fTrans.Rollback();
                        MessageBox.Show("ERRORES al cerrar venta: " + pvd.IComentario.Replace("%", "\n"));
                        throw new Exception();
                    }
                }
                else if(m_bCerrarTraspasoSalida)
                {
                    pvd.TRASPASOSALIDA_CERRARDOCTO(m_Docto, fTrans);
                    if (!(pvd.IComentario == "" || pvd.IComentario == null))
                    {
                        fTrans.Rollback();
                        MessageBox.Show("ERRORES al cerrar el traspaso de salida: " + pvd.IComentario.Replace("%", "\n")); throw new Exception();
                        throw new Exception();
                    }
                }
                else if (this.m_bCerrarVentaFuturoAplicada)
                {
                    CDOCTOD objDoctoD = new CDOCTOD();
                    bool bRes = objDoctoD.VENTAFUTUROAPLICACION_COMPLETAR(m_Docto, m_bMantenerVentaFuturoAbierta, fTrans);

                    if (bRes == false)
                    {
                        fTrans.Rollback();
                        fConn.Close();

                        pvd.CancelarVenta(m_Docto, CurrentUserID.CurrentUser, null);

                        MessageBox.Show(objDoctoD.IComentario);
                        return;
                    }
                }


                fTrans.Commit();
                this.m_bPagoCompleto = true;
                fConn.Close();

                if (CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("3.3") || CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0"))
                {

                    CDOCTOD doctoD = new CDOCTOD();
                    string REQUIEREAPLICARPAGOS = "N";
                    if (doctoD.PAGO_MARCAR_SATPUE_SIAPLICA(m_Docto.IID, ref REQUIEREAPLICARPAGOS, null))
                    {
                        if(REQUIEREAPLICARPAGOS != null && REQUIEREAPLICARPAGOS.Equals("S"))
                        {
                            m_timbrarPagosAlTerminar = true;
                            //this.TimbrarPagosPorFacturaElectronica(m_Docto);
                        }
                    }
                    
                }


                if (reimprimirPagosVerifone && verifonePaymentBE != null)
                {
                    if (MessageBox.Show("Parece que hubo intermitencias al momento de hacer el pago. Quizas no se imprimieron los vouchers. " +
                                        "Desea imprimir/reimprimir los vouchers ",
                                        "Confirmacion",
                                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        PagoVerifoneHelper.ImprimirVoucher(verifonePaymentBE.IAPPSPECIFICDATA, false);
                        PagoVerifoneHelper.ImprimirVoucher(verifonePaymentBE.IAPPSPECIFICDATA, true);
                    }
                }

                this.Close();



            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrió un error. Por favor reintente. El siguiente tramo del mensaje es para soporte tecnico: " + ex.Message + ex.StackTrace);
                fConn.Close();
            }
            finally
            {
                fConn.Close();
            }



        }



        private bool InsertarOtrosPagos(decimal pagoOtros, iPos.PuntoDeVenta.DSPuntoDeVentaAux2.PAGOSAVANZADODataTable tableOtrosPagos,  ref string strComentario, FbTransaction fTrans)
        {
            if (tableOtrosPagos == null || tableOtrosPagos.Rows.Count == 0)
            {
                strComentario = "No hay otros pagos registrados";
                return true;
            }

            if (pagoOtros == 0)
            {
                strComentario = "No hay otros pagos registrados";
                return true;
            }


            foreach (iPos.PuntoDeVenta.DSPuntoDeVentaAux2.PAGOSAVANZADORow row in tableOtrosPagos.Rows)
            {

                CDOCTOPAGOBE pagoBE = new CDOCTOPAGOBE();
                CDOCTOPAGOD pagoD = new CDOCTOPAGOD();

                pagoBE.IFORMAPAGOID = row.FORMAPAGOID;
                pagoBE.IIMPORTE = row.MONTO;
                pagoBE.IIMPORTERECIBIDO = row.MONTO;
                pagoBE.IFECHAELABORACION = DateTime.Today;
                pagoBE.IFECHARECEPCION = DateTime.Today;
                pagoBE.INOTAS = "";
                pagoBE.IESAPARTADO = "N";
                pagoBE.IFECHAHORA = DateTime.Now;

                pagoBE.IDOCTOID = m_Docto.IID;
                pagoBE.IFECHA = DateTime.Today;
                pagoBE.ICORTEID = CurrentUserID.CurrentUser.ICORTEID;
                pagoBE.ITIPOPAGOID = DBValues._TIPOPAGO_ENTRADA;
                pagoBE.IESPAGOINICIAL = DBValues._DB_BOOLVALUE_NO;
                pagoBE.ITIPOABONOID = DBValues._TIPO_ABONO_INICIAL;
                pagoBE.IFORMAPAGOSATID = row.FORMAPAGOSATID;

                if (!row.IsBANCOIDNull())
                    pagoBE.IBANCO = row.BANCOID;

                if (!row.IsREFERENCIANull())
                    pagoBE.IREFERENCIABANCARIA = row.REFERENCIA;

                if (pagoD.InsertarDOCTOPAGOD(pagoBE, fTrans) == null)
                {
                    strComentario = "error al insertar otros pagos";
                    return false;
                }
            }

            return true;
        }



        private bool PagarConSaldoCompra(decimal pagoAplicarCompra, ref string strComentario, FbTransaction fTrans)
        {
            if (m_DoctoCompra == null)
            {
                strComentario = "Docto compra null";
                return true;
            }

            if (m_DoctoCompra.ISALDO == 0)
            {
                strComentario = "Docto compra no tiene saldo";
                return true;
            }



            CDOCTOPAGOBE pagoBE = new CDOCTOPAGOBE();
            CDOCTOPAGOD pagoD = new CDOCTOPAGOD();

            pagoBE.IFORMAPAGOID = DBValues._FORMA_PAGO_INTERCAMBIOMERCANCIACREDITO;
            pagoBE.IIMPORTE = pagoAplicarCompra;
            pagoBE.IIMPORTERECIBIDO = pagoAplicarCompra;
            pagoBE.IFECHAELABORACION = DateTime.Today;
            pagoBE.IFECHARECEPCION = DateTime.Today;
            pagoBE.INOTAS = "";
            pagoBE.IESAPARTADO = "N";
            pagoBE.IFECHAHORA = DateTime.Now;

            pagoBE.IDOCTOID = m_Docto.IID;
            pagoBE.IDOCTOSALIDAID = m_DoctoCompra.IID;
            pagoBE.IFECHA = DateTime.Today;
            pagoBE.ICORTEID = CurrentUserID.CurrentUser.ICORTEID;
            pagoBE.ITIPOPAGOID = DBValues._TIPOPAGO_ENTRADA;

            pagoBE.IESPAGOINICIAL = DBValues._DB_BOOLVALUE_NO;


            pagoBE.ITIPOABONOID = DBValues._TIPO_ABONO_ABONO;
            //pagoBE.IDOCTOPAGOREFID = m_doctoPago.IID;
            //pagoBE.IBANCOMERPARAMID = bancomerParamId;

            pagoBE.IFORMAPAGOSATID = DBValues._FORMA_PAGOSAT_COMPENSACION;

            if (pagoD.InsertarDOCTOPAGOD(pagoBE, fTrans) == null)
            {
                return false;
            }

            return true;
        }

        /*
        private bool AplicarKitEnsamblesSiAplica(FbTransaction fTrans)
        {
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();


            pvd.KIT_CREARALVUELOFALTANTE(m_Docto.IID, fTrans);
            if (pvd.IComentario == "" || pvd.IComentario == null)
            {
                return true;
            }
            else
            {
                if(fTrans != null)
                    fTrans.Rollback();

                MessageBox.Show("ERRORES: " + pvd.IComentario.Replace("%", "\n"));
                return false;
            }
        }
        */



        private bool AplicaPromocionRebajaSiAplica(FbTransaction ft)
        {
            if (CurrentUserID.CurrentParameters.IREBAJAESPECIAL == null || !CurrentUserID.CurrentParameters.IREBAJAESPECIAL.Equals("S")
                || this.m_Docto.ITIPODOCTOID != DBValues._DOCTO_TIPO_VENTA || this.m_Docto.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_TRASPASOFRANQUICIA || this.m_Docto.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_TRASPASOFRANQUICIA_SALIDA)
                return true;

            CDOCTOD doctoD = new CDOCTOD();
            return doctoD.DOCTO_PROMOVER_REBAJA(this.m_Docto, ft);

        }




        private bool AplicarDescuentoVale(FbTransaction fTrans)
        {
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();

            m_Docto.ITIPODESCUENTOVALE = this.m_tipoDescuentoVale;


            m_Docto.IREFERENCIAS = this.m_tipoDescuentoVale == 1 ? this.m_numeroVale : this.m_referenciaDescuentoVale;

            pvd.APLICAR_DESCUENTO_VALEVenta(m_Docto, fTrans);
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

        private void BTPaymentSave_Click(object sender, EventArgs e)
        {
            GuardarPago();
        }


        private void CompletarFaltante()
        {

            decimal tipoCambio = (((bool)m_Docto.isnull["ITIPOCAMBIO"] || m_Docto.ITIPOCAMBIO == 0) ? 1 : m_Docto.ITIPOCAMBIO);


            decimal dPagoTotal;
            decimal dPagoEfectivo = decimal.Parse(PA_ABONOTextBox.NumericValue.ToString()) * tipoCambio;
            decimal dPagoTarjeta = decimal.Parse(this.TBMontoTarjeta.NumericValue.ToString()) * tipoCambio;
            //decimal dPagoCredito = decimal.Parse(this.TBMontoCredito.NumericValue.ToString());
            decimal dPagoCheque = decimal.Parse(this.TBMontoCheque.NumericValue.ToString()) * tipoCambio;
            decimal dPagoVale = decimal.Parse(this.TBMontoVale.NumericValue.ToString()) * tipoCambio;
            decimal dMonederoAplicado = decimal.Parse(this.TBMonederoAplicado.Text.ToString()) * tipoCambio;
            decimal dPagoTransferencia = decimal.Parse(this.TBMontoTransferencia.NumericValue.ToString()) * tipoCambio;
            decimal dPagoCreditoAutomatico = this.m_creditoAutomatico;
            decimal dPagoOtros = decimal.Parse(this.lblOtros.Text) * tipoCambio;

            dPagoTotal = dPagoEfectivo + dPagoTarjeta /*+ dPagoCredito*/ + dPagoCheque + dPagoVale + dPagoCreditoAutomatico /*+ dPagoCreditoManual*/ + dMonederoAplicado + dPagoTransferencia + dPagoOtros;


            decimal dFalta = m_dRestanteAPagar - dPagoTotal  ;
            if (dFalta > 0 && this.PA_ABONOTextBox.Enabled && this.PA_ABONOTextBox.Visible)
            {
                this.PA_ABONOTextBox.Text = (dPagoEfectivo + dFalta).ToString();
            }
        }

        private void AsignarCambio()
        {

            decimal tipoCambio = (((bool)m_Docto.isnull["ITIPOCAMBIO"] || m_Docto.ITIPOCAMBIO == 0) ? 1 : m_Docto.ITIPOCAMBIO);


            decimal dPagoTotal;
            decimal dPagoEfectivo = decimal.Parse(PA_ABONOTextBox.NumericValue.ToString()) * tipoCambio;
            decimal dPagoTarjeta = decimal.Parse(this.TBMontoTarjeta.NumericValue.ToString()) * tipoCambio;
            //decimal dPagoCredito = decimal.Parse(this.TBMontoCredito.NumericValue.ToString());
            decimal dPagoCheque = decimal.Parse(this.TBMontoCheque.NumericValue.ToString()) * tipoCambio;
            decimal dPagoVale = decimal.Parse(this.TBMontoVale.NumericValue.ToString()) * tipoCambio;
            decimal dMonederoAplicado = decimal.Parse(this.TBMonederoAplicado.Text.ToString()) * tipoCambio;

            decimal dPagoTransferencia = decimal.Parse(this.TBMontoTransferencia.NumericValue.ToString()) * tipoCambio;
            decimal dPagoCreditoAutomatico = this.m_creditoAutomatico;

            decimal dPagoOtros = decimal.Parse(this.lblOtros.Text) * tipoCambio;


            dPagoTotal = dPagoEfectivo + dPagoTarjeta /*+ dPagoCredito*/ + dPagoCheque + dPagoVale + dPagoCreditoAutomatico /*+ dPagoCreditoManual*/ + dMonederoAplicado + dPagoTransferencia + dPagoOtros;


            decimal dCambio = dPagoTotal - m_dRestanteAPagar;
            if (dCambio >= 0)
            {
                TBCambioTextBox.Text = dCambio.ToString("N2");
                LBFaltante.Text = "";
            }
            else
            {
                TBCambioTextBox.Text = "0.00";
                LBFaltante.Text = "Faltan : " + (dCambio * (-1)).ToString("N2") + " pesos ";
            }
        }
        private void PA_ABONOTextBox_Validated(object sender, EventArgs e)
        {
            AsignarCambio();
        }


        private decimal GetTotalConTope()
        {
            decimal retorno = 0;

            CDOCTOD dOCTOD = new CDOCTOD();
            retorno = dOCTOD.TotalSinRebaja(m_Docto.IID, null);

            return retorno;


        }

        private void WFPagosBasico_Load(object sender, EventArgs e)
        {
            if (m_closeAfterLoad)
            {
                this.Close();
                return;
            }


            if (this.m_bVale && this.m_tipoDescuentoVale == 1)
            {
                this.TBMontoVale.Focus();
            }
            else
                this.PA_ABONOTextBox.Focus();

            this.LBFaltante.Text = "";

            m_persona = new CPERSONABE();
            m_persona.IID = m_Docto.IPERSONAID;
            CPERSONAD personaD = new CPERSONAD();
            m_persona = personaD.seleccionarPERSONA(m_persona,null);

            formatearPanelCompraRelacionada();

            if (CurrentUserID.CurrentParameters.IHAB_FACTURAELECTRONICA != "S")
            {
                this.CBFacturaElectronica.Checked = false;
                this.CBFacturaElectronica.Visible = false;
                this.CBComprobanteTraslado.Checked = false;
                this.CBComprobanteTraslado.Visible = false;
                this.CBCartaPorte.Checked = false;
                this.CBCartaPorte.Visible = false;

            }

            if (m_Docto.IMONEDAID != DBValues._MONEDA_PESOS)
            {

                //tipo de cambio
                CMONEDABE monedaBE = new CMONEDABE();
                CMONEDAD monedaD = new CMONEDAD();
                monedaBE.IID = ((bool)m_Docto.isnull["IMONEDAID"] || m_Docto.IMONEDAID == 0) ? DBValues._MONEDA_PESOS : m_Docto.IMONEDAID;
                monedaBE = monedaD.seleccionarMONEDA(monedaBE, null);
                if (monedaBE != null)
                {
                    LBMONEDA.Text = monedaBE.INOMBRE + " t.c. " + m_Docto.ITIPOCAMBIO.ToString(); 
                }
            }


            this.ComboBancoTarjeta.llenarDatos();
            this.ComboBancoTarjeta.SelectedIndex = -1;

            this.ComboBancoCheque.llenarDatos();
            this.ComboBancoCheque.SelectedIndex = -1;

            this.ComboBancoTransferencia.llenarDatos();
            this.ComboBancoTransferencia.SelectedIndex = -1;

            if (m_pagoConPinpadHabilitado)
            {
                this.TBReferenciaTarjeta.Enabled = false;
            }


            if (CurrentUserID.CurrentParameters.IHABSURTIDOPOSTPUESTO != null && CurrentUserID.CurrentParameters.IHABSURTIDOPOSTPUESTO.Equals("S"))
            {
                CBSurtidoPostpuesto.Visible = true;
                CBSurtidoPostpuesto.Checked = true;
            }
            else
                CBSurtidoPostpuesto.Visible = false;



            if (CurrentUserID.CurrentParameters.IHABREVISIONFINAL != null && CurrentUserID.CurrentParameters.IHABREVISIONFINAL.Equals("S"))
            {
                CBRevisionFinal.Visible = true;
                CBRevisionFinal.Checked = true;
            }
            else
                CBRevisionFinal.Visible = false;

            CBTIPOTARJETA.SelectedIndex = 0;

            calcularCreditoAutomatico();

            cargarPagosConTarjetaYaAplicados();

            CBFacturaElectronica.Checked = (m_Docto.IESFACTURAELECTRONICA != null && m_Docto.IESFACTURAELECTRONICA.Equals("S")) || CurrentUserID.CurrentParameters.IGENERARFE.Equals("S");

            CBComprobanteTraslado.Checked = m_persona != null && m_persona.IGENERACOMPROBTRASL  != null && m_persona.IGENERACOMPROBTRASL.Equals("S");

            CBCartaPorte.Checked = m_persona != null && m_persona.IGENERACARTAPORTE != null && m_persona.IGENERACARTAPORTE.Equals("S");

            if (CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("3.3") || CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0"))
            {
                USOCFDILabel.Visible = true;
                USOCFDITextBox.Visible = true;
                USOCFDITextBox.llenarDatos();

                USOCFDITextBox.SelectedDataDisplaying = "Por definir";


                if (m_Docto != null && m_Docto.ISAT_USOCFDIID > 0)
                    USOCFDITextBox.SelectedValue = m_Docto.ISAT_USOCFDIID.ToString();

               else  if (m_persona != null && m_persona.ISAT_USOCFDIID > 0)
                    USOCFDITextBox.SelectedValue = m_persona.ISAT_USOCFDIID.ToString();
            }



            CUSUARIOSD usuariosD = new CUSUARIOSD();
            if (usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_OPCIONESAVANZADASPAGOVENTAS, null))
            {
                pnlOtros.Visible = true;
            }
            else
            {
                pnlOtros.Visible = false;
            }

            this.m_bPagoVerifoneHabilitado = iPos.CurrentUserID.CurrentVerifoneCajaConfig.IACTIVO == "S" &&
                usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_PAGO_TERMINAL_VERIFONE, null);

            this.btnReinicializaVerifone.Visible = m_bPagoVerifoneHabilitado;

            if (m_bAutomatizaPagoEfectivo)
            {
                PA_ABONOTextBox.Text = Math.Round(m_Docto.ITOTAL, 2).ToString("N2");
                GuardarPago(); 
            }


        }

        private void WFPagosBasico_Shown(object sender, EventArgs e)
        {
            if (this.m_bVale && this.m_tipoDescuentoVale == 1)
            {
                this.TBMontoVale.Focus();
            }
            else
                this.PA_ABONOTextBox.Focus();
        }

        private void WFPagosBasico_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.F10:
                    CompletarFaltante();
                    GuardarPago();
                    break;

                case Keys.Escape:
                    this.Close();
                    break;


                case Keys.F:
                    if (e.Modifiers == Keys.Control)
                    {
                        CBFacturaElectronica.Checked = true;
                        GuardarPago();
                    }
                    break;

                case Keys.T:
                    if (e.Modifiers == Keys.Control)
                    {
                        CBComprobanteTraslado.Checked = true;
                        GuardarPago();
                    }
                    break;

                default:
                    break;
            }
        }

        private void TBMontoTarjeta_Validated(object sender, EventArgs e)
        {
            AsignarCambio();
        }


        private void TBMontoCheque_Validated(object sender, EventArgs e)
        {
            AsignarCambio();
        }

        private void TBMontoVale_Validated(object sender, EventArgs e)
        {
            AsignarCambio();
        }


        private bool ConvierteApartadoSiAplica(FbTransaction fTrans)
        {
            if (m_convierteApartado == true && m_personaApartadoId != 0  && this.m_tipoTransaccion == tipoTransaccionV.t_venta)
            {
                CPuntoDeVentaD pvd = new CPuntoDeVentaD();
                if (pvd.VentaConvierteApartado(m_Docto, m_personaApartadoId, fTrans))
                {
                    CDOCTOD doctoD = new CDOCTOD();
                    m_Docto = doctoD.seleccionarDOCTO(m_Docto, fTrans);
                    this.m_tipoTransaccion = tipoTransaccionV.t_ventaapartado;
                    m_esapartado = "S";
                    return true;
                }
                else
                    return false;

            }
                return true;
        }


        private string CambiarFormaPagoSat(FbTransaction fTrans, string formaPagoSat)
        {
            CDOCTOD doctoD = new CDOCTOD();
            m_Docto.ITIMBRADOFORMAPAGOSAT = formaPagoSat;
            if(!doctoD.CambiarTIMBRADODOCTOFORMAPAGOSATD(m_Docto, m_Docto,fTrans))
            {
                return doctoD.IComentario;
            }
            return "";
        }

        private string CALCULAR_TIMBRADOFORMAPAGOSAT_FROMCODE(FbTransaction fTrans, decimal dPagoEfectivo, decimal dPagoTarjeta, decimal dPagoCredito, decimal dPagoCheque, decimal dPagoVale, decimal dPagoTransferencia, long tarjetaFormaPagoSat)
        {
            string strRetorno = "";
            bool esPrimerFormaPago = true;

            ArrayList list = new ArrayList();
            

            if (dPagoEfectivo > 0)
            {
                CDOCTOPAGOBE doctoBE = new CDOCTOPAGOBE();
                doctoBE.IFORMAPAGOID = 1;
                doctoBE.IFORMAPAGOSATID = 1;
                list.Add(doctoBE);

            }

            if (dPagoCredito > 0)
            {
                CDOCTOPAGOBE doctoBE = new CDOCTOPAGOBE();
                doctoBE.IFORMAPAGOID = 4;
                doctoBE.IFORMAPAGOSATID = 99;
                list.Add(doctoBE);

            }
            if (dPagoCheque > 0)
            {
                CDOCTOPAGOBE doctoBE = new CDOCTOPAGOBE();
                doctoBE.IFORMAPAGOID = 3;
                doctoBE.IFORMAPAGOSATID = 2;
                list.Add(doctoBE);

            }
            if (dPagoVale > 0)
            {
                CDOCTOPAGOBE doctoBE = new CDOCTOPAGOBE();
                doctoBE.IFORMAPAGOID = 5;
                doctoBE.IFORMAPAGOSATID = 8;
                list.Add(doctoBE);

            }
            if (dPagoTransferencia > 0)
            {
                CDOCTOPAGOBE doctoBE = new CDOCTOPAGOBE();
                doctoBE.IFORMAPAGOID = 15;
                doctoBE.IFORMAPAGOSATID = 3;
                list.Add(doctoBE);

            }


            if (dPagoTarjeta > 0)
            {
                CDOCTOPAGOBE doctoBE = new CDOCTOPAGOBE();
                doctoBE.IFORMAPAGOID = 2;
                doctoBE.IFORMAPAGOSATID = tarjetaFormaPagoSat;
                list.Add(doctoBE);

            }

            list.Sort(new sortDoctoPagoPorMontoHelper());
            
            foreach(CDOCTOPAGOBE pagoBE in list)
            {
                CDOCTOPAGOD pagoD = new CDOCTOPAGOD();
                string strFormaPago =  pagoD.obtenNombreFormaPagoSatXId(pagoBE.IFORMAPAGOSATID, fTrans);
                if (esPrimerFormaPago)
                {
                    strRetorno = strFormaPago;
                    esPrimerFormaPago = false;
                }
                else
                {
                    strRetorno = strRetorno + "," + strFormaPago;
                }
            }
            return strRetorno;
        }

        private bool FacturaElectronica(FbTransaction fTrans, decimal dPagoEfectivo, decimal dPagoTarjeta,decimal dPagoCredito,decimal dPagoCheque,decimal dPagoVale, decimal dPagoTransferencia, decimal dPagoCreditoAutomatico, ref long formaPagoFE, bool bSoloValidar)
        {

            CDOCTOPAGOBE pagoTemporal = new CDOCTOPAGOBE();
            string strFormaPagoSelected = "";
            string strFormaPagoSat = "";
            string strFormaPagoSat33 = "";

            /**inicio de parte por 3.3 */
            ArrayList formasPago = new ArrayList();
            if(CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("3.3") || CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0"))
            {
                if (dPagoCredito > 0 || dPagoCreditoAutomatico > 0)
                {
                    formasPago.Add("CREDITO");
                }
                else
                {
                    decimal maxPagoAux = 0;
                    //string paymentTypeAux = "";

                    if (dPagoEfectivo > 0)
                    {
                        maxPagoAux = dPagoEfectivo;
                        formasPago.Add("EFECTIVO");
                    }
                    if(dPagoTarjeta > 0)
                    {
                        if(dPagoTarjeta > maxPagoAux)
                        {
                            maxPagoAux = dPagoTarjeta;
                            formasPago.Clear();
                            formasPago.Add("TARJETA");
                        }
                        else if(dPagoTarjeta == maxPagoAux)
                        {
                            formasPago.Add("TARJETA");
                        }

                    }
                    if (dPagoCheque > 0)
                    {
                        if (dPagoCheque > maxPagoAux)
                        {
                            maxPagoAux = dPagoCheque;
                            formasPago.Clear();
                            formasPago.Add("CHEQUE");
                        }
                        else if (dPagoCheque == maxPagoAux)
                        {
                            formasPago.Add("CHEQUE");
                        }
                    }
                    if (dPagoVale > 0)
                    {
                        if (dPagoVale > maxPagoAux)
                        {
                            maxPagoAux = dPagoVale;
                            formasPago.Clear();
                            formasPago.Add("VALE");
                        }
                        else if (dPagoVale == maxPagoAux)
                        {
                            formasPago.Add("VALE");
                        }
                    }
                    if (dPagoTransferencia > 0)
                    {
                        if (dPagoTransferencia > maxPagoAux)
                        {
                            maxPagoAux = dPagoTransferencia;
                            formasPago.Clear();
                            formasPago.Add("TRANSFERENCIA");
                        }
                        else if (dPagoTransferencia == maxPagoAux)
                        {
                            formasPago.Add("TRANSFERENCIA");
                        }
                    }
                }

                if (formasPago.Count > 1)
                {

                    iPos.WFSeleccionarFormaPagoFE frm = new iPos.WFSeleccionarFormaPagoFE(formasPago);
                    frm.ShowDialog();
                    frm.Dispose();
                    GC.SuppressFinalize(frm);

                    if (frm.m_formapagoselected == "")
                    {
                        return false;
                    }
                    strFormaPagoSelected = frm.m_formapagoselected;
                }
                else
                {
                    strFormaPagoSelected = formasPago[0].ToString();
                }
            }
            else
            {
                if (dPagoEfectivo > 0)
                    formasPago.Add("EFECTIVO");
                if (dPagoTarjeta > 0)
                    formasPago.Add("TARJETA");
                if (dPagoCredito > 0 || dPagoCreditoAutomatico > 0)
                    formasPago.Add("CREDITO");
                if (dPagoCheque > 0)
                    formasPago.Add("CHEQUE");
                if (dPagoVale > 0)
                    formasPago.Add("VALE");
                if (dPagoTransferencia > 0)
                    formasPago.Add("TRANSFERENCIA");



                if (formasPago.Count > 1)
                {

                    iPos.WFSeleccionarFormaPagoFE frm = new iPos.WFSeleccionarFormaPagoFE(formasPago);
                    frm.ShowDialog();
                    frm.Dispose();
                    GC.SuppressFinalize(frm);

                    if (frm.m_formapagoselected == "")
                    {
                        return false;
                    }
                    strFormaPagoSelected = frm.m_formapagoselected;
                }
                else
                {
                    strFormaPagoSelected = formasPago[0].ToString();
                }
            }
            

            /**fin de parte por 3.3 */



            switch (strFormaPagoSelected)
            {
                case "EFECTIVO":
                    {
                        formaPagoFE = 1;
                        strFormaPagoSat33 = "01";
                        pagoTemporal.IFORMAPAGOID = formaPagoFE;
                        pagoTemporal.IREFERENCIABANCARIA = "";
                        break;
                    }
                case "TARJETA":
                    {
                        formaPagoFE = 2;
                        strFormaPagoSat33 = "04";
                        pagoTemporal.IFORMAPAGOID = formaPagoFE;
                        pagoTemporal.IREFERENCIABANCARIA = TBReferenciaTarjeta.Text;
                        break;
                    }
                case "CHEQUE":
                    {
                        formaPagoFE = 3;
                        strFormaPagoSat33 = "02";
                        pagoTemporal.IFORMAPAGOID = formaPagoFE;
                        pagoTemporal.IREFERENCIABANCARIA = TBReferenciaCheque.Text;
                        break;
                    }
                case "CREDITO":
                    {
                        formaPagoFE = 4;
                        strFormaPagoSat33 = "99";
                        pagoTemporal.IFORMAPAGOID = formaPagoFE;
                        pagoTemporal.IREFERENCIABANCARIA = "";
                        break;
                    }
                case "VALE":
                    {
                        formaPagoFE = 5;
                        strFormaPagoSat33 = "08";
                        pagoTemporal.IFORMAPAGOID = formaPagoFE;
                        pagoTemporal.IREFERENCIABANCARIA = "";
                        break;
                    }

                case "TRANSFERENCIA":
                    {
                        formaPagoFE = 15;
                        strFormaPagoSat33 = "03";
                        pagoTemporal.IFORMAPAGOID = formaPagoFE;
                        pagoTemporal.IREFERENCIABANCARIA = TBReferenciaTransferencia.Text;
                        break;
                    }
                default:
                    break;
            }

            long tarjetaFormaPagoSatId = DBValues._FORMA_PAGOSAT_TARJETACREDITO;
            string tarjetaFormaPagoSatStr = "04";
            switch (CBTIPOTARJETA.SelectedIndex)
            {
                case 0: tarjetaFormaPagoSatId = DBValues._FORMA_PAGOSAT_TARJETACREDITO; tarjetaFormaPagoSatStr = "04";  break;
                case 1: tarjetaFormaPagoSatId = DBValues._FORMA_PAGOSAT_TARJETADEBITO; tarjetaFormaPagoSatStr = "28"; break;
                case 2: tarjetaFormaPagoSatId = DBValues._FORMA_PAGOSAT_TARJETASERVICIO; tarjetaFormaPagoSatStr = "29"; break;
                default: tarjetaFormaPagoSatId = DBValues._FORMA_PAGOSAT_TARJETACREDITO; tarjetaFormaPagoSatStr = "04"; break;
            }
            pagoTemporal.IFORMAPAGOSATID = tarjetaFormaPagoSatId;

            //si se selecciono tarjeta pero el subtipo de la tarjeta no es credito
            if (tarjetaFormaPagoSatStr != "04" && strFormaPagoSat33 == "04")
                strFormaPagoSat33 = tarjetaFormaPagoSatStr;//CALCULAR_TIMBRADOFORMAPAGOSAT_FROMCODE(fTrans, dPagoEfectivo, dPagoTarjeta, dPagoCredito, dPagoCheque, dPagoVale, dPagoTransferencia, tarjetaFormaPagoSatId);

            if (CurrentUserID.CurrentParameters.IVERSIONCFDI != null &&
                (CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("3.3") || CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0")))
            {
                if (CambiarFormaPagoSat(fTrans, strFormaPagoSat33) != "")
                {
                    return false;
                }
            }

            if (m_Docto != null && m_Docto.IID > 0)
            {

                CDOCTOD vData = new CDOCTOD();
                m_Docto = vData.seleccionarDOCTO(m_Docto, fTrans);
                bool retorno;
                

                if (ValidarDatosParaFacturaElectronica(this.m_Docto))
                {

                    if (bSoloValidar)
                        return true;

                    iPosReporting.WFFacturaElectronica fe = new iPosReporting.WFFacturaElectronica(this.m_Docto, CurrentUserID.CurrentParameters, WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_TIMBRAR, pagoTemporal, this.m_DoctoRef, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA, strFormaPagoSat33);
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


        private void TimbrarPagosPorFacturaElectronica(CDOCTOBE docto)
        {
            MessageBox.Show("Aqui se timbraran los pagos");
        }

        private bool ValidarDatosParaFacturaElectronica(CDOCTOBE docto)
        {
            CPuntoDeVentaD pd = new CPuntoDeVentaD();
            if (!pd.VALIDAR_PARAFACTURAELECTRONICA(docto, null))
            {
                MessageBox.Show("Errores " + pd.IComentario);
                if(pd.IComentario.Contains("HAY PRODUCTOS SIN CLAVE SAT"))
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

        private void BtnMonedero_Click(object sender, EventArgs e)
        {
            WFPreguntaMonedero wfMoned = new WFPreguntaMonedero(m_Docto, "MONEDERO DE DONDE SE DESCONTARA", this.TBNumeroMonedero.Text, 0);
            wfMoned.ShowDialog();

            if (wfMoned.m_monedero != null)
            {
                m_monederoAplicado = wfMoned.m_montoAAplicar;
                m_monedero = wfMoned.m_monedero;
                this.TBMonederoAplicado.Text = m_monederoAplicado.ToString("N2");
                this.TBNumeroMonedero.Text = m_monedero.ICLAVE;
                AsignarCambio();
            }
            else
            {
                m_monederoAplicado = 0;
                m_monedero = null;
                this.TBMonederoAplicado.Text = "0.00";
                this.TBNumeroMonedero.Text = "";

            }
            wfMoned.Dispose();
            GC.SuppressFinalize(wfMoned);

        }



        private bool ValidarCredito(decimal montoCredito)
        {

            if (m_persona == null)
                return false;

            if (m_persona.IID == 1)
                return true;

            if (!(bool)m_persona.isnull["IBLOQUEADO"])
                if (m_persona.IBLOQUEADO.Equals("S"))
                {

                    MessageBox.Show("El cliente esta  bloqueado");
                    return false;
                }


            decimal saldo = 0, limitecredito = 0;
            if (!(bool)m_persona.isnull["ISALDO"])
                saldo = m_persona.ISALDO;

            if (!(bool)m_persona.isnull["ILIMITECREDITO"])
                limitecredito = m_persona.ILIMITECREDITO;

            if (limitecredito == 0)
                return true;

            if (limitecredito + saldo - montoCredito >= 0)
                return true;

            //esta condicion es para tratar de evitar preguntar 2 veces el supervisor, cuando selecciona el cliente y cuando paga
            if (limitecredito + saldo < 0 && m_supervisor != null)
                return true;


            long autorizadorId = CurrentUserID.CurrentUser.IID;
            CUSUARIOSD usuariosD = new CUSUARIOSD();
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
                        return false;

                    //if (!bIsSupervisor)
                    if (!usuariosD.UsuarioTienePermisos((int)userBE.IID, (int)DBValues._DERECHO_VENDERCONCREDITOEXCEDIDO, null))
                    {
                        MessageBox.Show("El usuario ingresado no tiene el derecho");
                        return false;
                    }
                    m_supervisor = userBE;




                    CDOCTOD doctoD = new CDOCTOD();
                    m_Docto.ISUPERVISORID = m_supervisor.IID;
                    doctoD.CambiarSupervisorAutorizacionDOCTOD(m_Docto, null);
                    autorizadorId = m_supervisor.IID;


                }
                else
                {
                    return false;
                }
            }

            

            if (!PreguntaComentarioAutorizacion(m_Docto.IID, autorizadorId, null))
            {
                MessageBox.Show("Debe agregar un comentario de autorizacion");
                return false;
            }

            return true;
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


        private bool GuardaNotaPago(FbTransaction fTrans)
        {
            CDOCTOD doctoD = new CDOCTOD();
            m_Docto.INOTAPAGO = NOTAPAGOTextBox.Text;
            if (doctoD.CambiarNotaPago(m_Docto, m_Docto, fTrans))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private bool calcularCreditoAutomatico()
        {

            pnlCreditoAutomatico.Visible = false;
            this.m_creditoAutomatico = 0;

            if (m_Docto == null || m_Docto.IID == 0)
                return false;

            if(m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA && m_Docto.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_VENTAFUTUROAPLICADA
                && m_Docto.IVENTAFUTUID > 0)
            {
                decimal saldoAnticipos = 0;
                CDOCTOD doctoD = new CDOCTOD();
                if(!doctoD.VENTAFUTURO_SALDOANTICIPOS(m_Docto.IVENTAFUTUID, ref saldoAnticipos, null))
                {
                    return false;
                }


                if(saldoAnticipos < 0)
                {
                    m_creditoAutomatico = saldoAnticipos * -1;
                    pnlCreditoAutomatico.Visible =true;
                    lblCreditoAutomatico.Text = m_creditoAutomatico.ToString("N2");
                }
            }

            return true;

        }



        private decimal covertirDesdeFormatoPinPad(String str)
        {
            if (str == null)
                return 0;

            try
            {
                return decimal.Parse(str) / 100;
            }
            catch
            {
                return 0;
            }
        }

        private void ChecarPinPadHabilitado()
        {
            CUSUARIOSD usuariosD = new CUSUARIOSD();
            //agregar tambien a la validacion el parametro en parametro
            if (CurrentUserID.CurrentParameters.IBANCOMERHABPINPAD != null && CurrentUserID.CurrentParameters.IBANCOMERHABPINPAD == "S" && 
                (usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_PAGO_TERMINAL_BANCOMER, null)) )
            {
                m_pagoConPinpadHabilitado = true;
            }


        }

        private void cargarPagosConTarjetaYaAplicados()
        {
            if(m_Docto.IPAGOBANCOMERAPLICADO != null && m_Docto.IPAGOBANCOMERAPLICADO == "S")
            {
                CBANCOMERPARAMD bancomerParamD = new CBANCOMERPARAMD();
                CBANCOMERPARAMBE bancomerParamBE = new CBANCOMERPARAMBE();
                bancomerParamBE.IDOCTOID = m_Docto.IID;
                bancomerParamBE.IESTADOTRANSACCIONID = 1;
                bancomerParamBE.ITIPOTRANSACCION = "001";

                List<CBANCOMERPARAMBE> bancomerParamList = bancomerParamD.seleccionarBANCOMERPARAM_PORDOCTO_Simple(bancomerParamBE, null);
                if(bancomerParamList != null && bancomerParamList.Count > 0)
                {


                    CBANCOMERPARAMBE bancomerBECompuesto =  bancomerParamList[0];
                    bancomerBECompuesto = bancomerParamD.seleccionarBANCOMERPARAM_COMPUESTO(bancomerBECompuesto, null);
                    TBMontoTarjeta.Text = covertirDesdeFormatoPinPad(bancomerBECompuesto.ClsResponse.IIMPORTE).ToString();
                    ComboBancoTarjeta.SelectedIndex = 0;
                    TBReferenciaTarjeta.Text = "0000";


                    TBMontoTarjeta.ReadOnly = true;
                    ComboBancoTarjeta.Enabled = false;
                    TBReferenciaTarjeta.ReadOnly = true;



                    m_bancomerParamId = bancomerBECompuesto.IID;
                    m_cobroConPinPadYaAplicado = true;


                }
            }
        }



        private CBANCOMERPARAMBE ObtenerPagoPorTarjetaPinPad(long bancomerParamId)
        {

            CBANCOMERPARAMBE bancomerParamBE = new CBANCOMERPARAMBE();
            CBANCOMERPARAMD bancomerParamD = new CBANCOMERPARAMD();

            bancomerParamBE.IID = bancomerParamId;
            bancomerParamBE = bancomerParamD.seleccionarBANCOMERPARAM(bancomerParamBE, null);


            return bancomerParamBE;
        }


        private CVERIFONEPAYMENTBE ObtenerVerifonePagoPorTarjetaPinPad(long verifonePaymentId)
        {

            CVERIFONEPAYMENTBE verifonePaymentBE = new CVERIFONEPAYMENTBE();
            CVERIFONEPAYMENTD verifonePaymentD = new CVERIFONEPAYMENTD();

            verifonePaymentBE.IID = verifonePaymentId;
            verifonePaymentBE = verifonePaymentD.seleccionarVERIFONEPAYMENT(verifonePaymentBE, null);


            return verifonePaymentBE;
        }


        private CBANCOSBE ObtenerBancoDesdeClave(string clave)
        {

            CBANCOSBE bancosBE = new CBANCOSBE();
            CBANCOSD bancosD = new CBANCOSD();

            bancosBE.ICLAVE = clave;
            bancosBE = bancosD.seleccionarBANCOSxCLAVE(bancosBE, null);


            return bancosBE;
        }

        private void WFPagosBasico_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (esRecarga == true && !this.m_bPagoCompleto)
            {
                e.Cancel = true;
                MessageBox.Show("No se puede omitir el pago de una recarga una vez realizada, favor de ingresar el pago!");
            }
        }

       


        private void SeleccionarCompraRelacionada()
        {

            int tipoDoctoParaLista = (int)DBValues._DOCTO_TIPO_COMPRA;

            WFSaldosListaTransacciones look = new WFSaldosListaTransacciones((int)DBValues._DOCTO_ESTATUS_COMPLETO, tipoDoctoParaLista);
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                m_DoctoCompra = new CDOCTOBE();
                m_DoctoCompra.IID = int.Parse(dr[0].ToString());
                CDOCTOD vData = new CDOCTOD();
                m_DoctoCompra = vData.seleccionarDOCTO(m_DoctoCompra, null);

                if (m_DoctoCompra.IPERSONAID != m_persona.IPROVEECLIENTEID)
                {
                    MessageBox.Show("el proveedor de la compra no corresponde a este cliente");
                    m_DoctoCompra = null;
                    return;
                }
                
                if(m_DoctoCompra.ISALDO <= 0)
                {

                    MessageBox.Show("la transaccion ya no tiene saldo");
                    m_DoctoCompra = null;
                    return;
                }

                this.lblCompraRelacionada.Text = "Folio: " + m_DoctoCompra.IFOLIO.ToString() + " Saldo disponible: " + m_DoctoCompra.ISALDO.ToString("N2");
                

            }
        }

        private void BtnQuitarCompraRelacionada_Click(object sender, EventArgs e)
        {

            m_DoctoCompra = null;
            lblCompraRelacionada.Text = "...";
        }

        private void BtnCompraRelacionada_Click(object sender, EventArgs e)
        {
            SeleccionarCompraRelacionada();
        }


        private void formatearPanelCompraRelacionada()
        {
            if(m_persona == null || m_persona.IPROVEECLIENTEID == 0 )
            {
                pnlCompraRelacionada.Visible = false;
                return;
            }

            pnlCompraRelacionada.Visible = true;
        }

        private void CBSurtidoPostpuesto_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CBFacturaElectronica_CheckedChanged(object sender, EventArgs e)
        {
            if(CBFacturaElectronica.Checked)
            {

            }
        }

        private void ValidateSAT_ProductsKey()
        {

        }

        private void BtnAvanzado_Click(object sender, EventArgs e)
        {

            decimal tipoCambio = (((bool)m_Docto.isnull["ITIPOCAMBIO"] || m_Docto.ITIPOCAMBIO == 0) ? 1 : m_Docto.ITIPOCAMBIO);

            decimal dPagoEfectivo = decimal.Parse(PA_ABONOTextBox.NumericValue.ToString()) * tipoCambio;
            decimal dPagoTarjetaCredito = CBTIPOTARJETA.SelectedIndex <= 0 ? decimal.Parse(this.TBMontoTarjeta.NumericValue.ToString()) * tipoCambio : 0;
            decimal dPagoTarjetaDebito = CBTIPOTARJETA.SelectedIndex == 1 ? decimal.Parse(this.TBMontoTarjeta.NumericValue.ToString()) * tipoCambio : 0;
            decimal dPagoTarjetaServicio = CBTIPOTARJETA.SelectedIndex == 2 ? decimal.Parse(this.TBMontoTarjeta.NumericValue.ToString()) * tipoCambio : 0;
            decimal dPagoCheque = decimal.Parse(this.TBMontoCheque.NumericValue.ToString()) * tipoCambio;
            decimal dPagoVale = decimal.Parse(this.TBMontoVale.NumericValue.ToString()) * tipoCambio;
            decimal dMonederoAplicado = decimal.Parse(this.TBMonederoAplicado.Text.ToString()) * tipoCambio;
            decimal dPagoTransferencia = decimal.Parse(this.TBMontoTransferencia.NumericValue.ToString()) * tipoCambio;
            decimal dPagoCreditoAutomatico = this.m_creditoAutomatico;
            decimal dSaldoCompraRelacionada = m_DoctoCompra != null ? m_DoctoCompra.ISALDO * tipoCambio : 0;

            iPos.PuntoDeVenta.DSPuntoDeVentaAux2.PAGOSAVANZADODataTable table = new PuntoDeVenta.DSPuntoDeVentaAux2.PAGOSAVANZADODataTable();



            int iConsecutivo = 1;
            long formaPagoSeleccionada = 0;
            long formaPagoSatSeleccionada = 0;


            if (dPagoEfectivo > 0)
            {
                iPos.PuntoDeVenta.DSPuntoDeVentaAux2.PAGOSAVANZADORow rowTable = table.NewPAGOSAVANZADORow();
                rowTable.FORMAPAGOID = DBValues._FORMA_PAGO_EFECTIVO;
                rowTable.FORMAPAGONOMBRE = PagosAvanzadoFormas.Efectivo;
                rowTable.MONTO = dPagoEfectivo;
                formaPagoFromDescriptionAv(PagosAvanzadoFormas.Efectivo, out formaPagoSeleccionada, out formaPagoSatSeleccionada);
                rowTable.FORMAPAGOSATID = formaPagoSatSeleccionada;
                rowTable.CONSECUTIVO = iConsecutivo++;
                table.AddPAGOSAVANZADORow(rowTable);
            }

            if (dPagoTarjetaCredito > 0)
            {
                iPos.PuntoDeVenta.DSPuntoDeVentaAux2.PAGOSAVANZADORow rowTable = table.NewPAGOSAVANZADORow();
                rowTable.FORMAPAGOID = DBValues._FORMA_PAGO_TARJETA;
                rowTable.FORMAPAGONOMBRE = PagosAvanzadoFormas.Tarjeta_de_credito;
                rowTable.MONTO = dPagoTarjetaCredito;
                rowTable.BANCOID = this.ComboBancoTarjeta.SelectedValue != null ? long.Parse(this.ComboBancoTarjeta.SelectedValue.ToString()) : 0;
                rowTable.BANCONOMBRE = this.ComboBancoTarjeta.Text;
                rowTable.REFERENCIA = this.TBReferenciaTarjeta.Text;
                formaPagoFromDescriptionAv(PagosAvanzadoFormas.Tarjeta_de_credito, out formaPagoSeleccionada, out formaPagoSatSeleccionada);
                rowTable.FORMAPAGOSATID = formaPagoSatSeleccionada;
                rowTable.CONSECUTIVO = iConsecutivo++;
                table.AddPAGOSAVANZADORow(rowTable);
            }


            if (dPagoTarjetaDebito > 0)
            {
                iPos.PuntoDeVenta.DSPuntoDeVentaAux2.PAGOSAVANZADORow rowTable = table.NewPAGOSAVANZADORow();
                rowTable.FORMAPAGOID = DBValues._FORMA_PAGO_TARJETA;
                rowTable.FORMAPAGONOMBRE = PagosAvanzadoFormas.Tarjeta_de_debito;
                rowTable.MONTO = dPagoTarjetaDebito;
                rowTable.BANCOID = this.ComboBancoTarjeta.SelectedValue != null ? long.Parse(this.ComboBancoTarjeta.SelectedValue.ToString()) : 0;
                rowTable.BANCONOMBRE = this.ComboBancoTarjeta.Text;
                rowTable.REFERENCIA = this.TBReferenciaTarjeta.Text;
                formaPagoFromDescriptionAv(PagosAvanzadoFormas.Tarjeta_de_debito, out formaPagoSeleccionada, out formaPagoSatSeleccionada);
                rowTable.FORMAPAGOSATID = formaPagoSatSeleccionada;
                rowTable.CONSECUTIVO = iConsecutivo++;
                table.AddPAGOSAVANZADORow(rowTable);
            }

            if (dPagoTarjetaServicio > 0)
            {
                iPos.PuntoDeVenta.DSPuntoDeVentaAux2.PAGOSAVANZADORow rowTable = table.NewPAGOSAVANZADORow();
                rowTable.FORMAPAGOID = DBValues._FORMA_PAGO_TARJETA;
                rowTable.FORMAPAGONOMBRE = PagosAvanzadoFormas.Tarjeta_de_servicio;
                rowTable.MONTO = dPagoTarjetaServicio;
                rowTable.BANCOID = this.ComboBancoTarjeta.SelectedValue != null ? long.Parse(this.ComboBancoTarjeta.SelectedValue.ToString()): 0;
                rowTable.BANCONOMBRE = this.ComboBancoTarjeta.Text;
                rowTable.REFERENCIA = this.TBReferenciaTarjeta.Text;
                formaPagoFromDescriptionAv(PagosAvanzadoFormas.Tarjeta_de_servicio, out formaPagoSeleccionada, out formaPagoSatSeleccionada);
                rowTable.FORMAPAGOSATID = formaPagoSatSeleccionada;
                rowTable.CONSECUTIVO = iConsecutivo++;
                table.AddPAGOSAVANZADORow(rowTable);
            }

            if (dPagoCheque > 0)
            {
                iPos.PuntoDeVenta.DSPuntoDeVentaAux2.PAGOSAVANZADORow rowTable = table.NewPAGOSAVANZADORow();
                rowTable.FORMAPAGOID = DBValues._FORMA_PAGO_CHEQUE;
                rowTable.FORMAPAGONOMBRE = PagosAvanzadoFormas.Cheque_nominativo;
                rowTable.MONTO = dPagoCheque;
                rowTable.BANCOID = this.ComboBancoCheque.SelectedValue != null ?  long.Parse(this.ComboBancoCheque.SelectedValue.ToString()): 0;
                rowTable.BANCONOMBRE = this.ComboBancoCheque.Text;
                rowTable.REFERENCIA = this.TBReferenciaCheque.Text;
                formaPagoFromDescriptionAv(PagosAvanzadoFormas.Cheque_nominativo, out formaPagoSeleccionada, out formaPagoSatSeleccionada);
                rowTable.FORMAPAGOSATID = formaPagoSatSeleccionada;
                rowTable.CONSECUTIVO = iConsecutivo++;
                table.AddPAGOSAVANZADORow(rowTable);
            }


            if (dPagoVale > 0)
            {
                iPos.PuntoDeVenta.DSPuntoDeVentaAux2.PAGOSAVANZADORow rowTable = table.NewPAGOSAVANZADORow();
                rowTable.FORMAPAGOID = DBValues._FORMA_PAGO_VALE;
                rowTable.FORMAPAGONOMBRE = PagosAvanzadoFormas.Vales_de_despensa;
                rowTable.MONTO = dPagoVale;
                formaPagoFromDescriptionAv(PagosAvanzadoFormas.Vales_de_despensa, out formaPagoSeleccionada, out formaPagoSatSeleccionada);
                rowTable.FORMAPAGOSATID = formaPagoSatSeleccionada;
                rowTable.CONSECUTIVO = iConsecutivo++;
                table.AddPAGOSAVANZADORow(rowTable);
            }

            if (dMonederoAplicado > 0)
            {
                iPos.PuntoDeVenta.DSPuntoDeVentaAux2.PAGOSAVANZADORow rowTable = table.NewPAGOSAVANZADORow();
                rowTable.FORMAPAGOID = DBValues._FORMA_PAGO_NOIDENTIFICADO;
                rowTable.FORMAPAGONOMBRE = PagosAvanzadoFormas.Monedero;
                rowTable.MONTO = dMonederoAplicado;
                formaPagoFromDescriptionAv(PagosAvanzadoFormas.Efectivo, out formaPagoSeleccionada, out formaPagoSatSeleccionada);
                rowTable.FORMAPAGOSATID = formaPagoSatSeleccionada;
                rowTable.CONSECUTIVO = iConsecutivo++;
                table.AddPAGOSAVANZADORow(rowTable);
            }


            if (dPagoTransferencia > 0)
            {
                iPos.PuntoDeVenta.DSPuntoDeVentaAux2.PAGOSAVANZADORow rowTable = table.NewPAGOSAVANZADORow();
                rowTable.FORMAPAGOID = DBValues._FORMA_PAGO_TRANSFERENCIA;
                rowTable.FORMAPAGONOMBRE = PagosAvanzadoFormas.Transferencia_electronica_de_fondos;
                rowTable.MONTO = dPagoTransferencia;
                rowTable.BANCOID = this.ComboBancoTransferencia.SelectedValue != null ? long.Parse(this.ComboBancoTransferencia.SelectedValue.ToString()) : 0;
                rowTable.BANCONOMBRE = this.ComboBancoTransferencia.Text;
                rowTable.REFERENCIA = this.TBReferenciaTransferencia.Text;
                formaPagoFromDescriptionAv(PagosAvanzadoFormas.Transferencia_electronica_de_fondos, out formaPagoSeleccionada, out formaPagoSatSeleccionada);
                rowTable.FORMAPAGOSATID = formaPagoSatSeleccionada;
                rowTable.CONSECUTIVO = iConsecutivo++;
                table.AddPAGOSAVANZADORow(rowTable);
            }


            if (dPagoCreditoAutomatico > 0)
            {
                iPos.PuntoDeVenta.DSPuntoDeVentaAux2.PAGOSAVANZADORow rowTable = table.NewPAGOSAVANZADORow();
                rowTable.FORMAPAGOID = DBValues._FORMA_PAGO_NOIDENTIFICADO;
                rowTable.FORMAPAGONOMBRE = PagosAvanzadoFormas.CreditoAutomatico;
                rowTable.MONTO = dPagoCreditoAutomatico;
                formaPagoFromDescriptionAv(PagosAvanzadoFormas.Efectivo, out formaPagoSeleccionada, out formaPagoSatSeleccionada);
                rowTable.FORMAPAGOSATID = formaPagoSatSeleccionada;
                rowTable.CONSECUTIVO = iConsecutivo++;
                table.AddPAGOSAVANZADORow(rowTable);
            }

            if (dSaldoCompraRelacionada > 0)
            {
                iPos.PuntoDeVenta.DSPuntoDeVentaAux2.PAGOSAVANZADORow rowTable = table.NewPAGOSAVANZADORow();
                rowTable.FORMAPAGOID = DBValues._FORMA_PAGO_NOIDENTIFICADO;
                rowTable.FORMAPAGONOMBRE = PagosAvanzadoFormas.SaldoCompraRelacionada;
                rowTable.MONTO = dSaldoCompraRelacionada;
                formaPagoFromDescriptionAv(PagosAvanzadoFormas.Efectivo, out formaPagoSeleccionada, out formaPagoSatSeleccionada);
                rowTable.FORMAPAGOSATID = formaPagoSatSeleccionada;
                rowTable.CONSECUTIVO = iConsecutivo++;
                table.AddPAGOSAVANZADORow(rowTable);
            }


            foreach(iPos.PuntoDeVenta.DSPuntoDeVentaAux2.PAGOSAVANZADORow dr in otrosPagos.Rows)
            {


                iPos.PuntoDeVenta.DSPuntoDeVentaAux2.PAGOSAVANZADORow rowTable = table.NewPAGOSAVANZADORow();
                rowTable.FORMAPAGOID = dr.FORMAPAGOID;
                rowTable.FORMAPAGONOMBRE = dr.FORMAPAGONOMBRE;
                rowTable.MONTO = dr.MONTO;

                if (!dr.IsBANCOIDNull())
                    rowTable.BANCOID = dr.BANCOID;
                if (!dr.IsBANCONOMBRENull())
                    rowTable.BANCONOMBRE = dr.BANCONOMBRE;
                if (!dr.IsREFERENCIANull())
                    rowTable.REFERENCIA = dr.REFERENCIA;

                if (!dr.IsFORMAPAGOSATIDNull())
                    rowTable.FORMAPAGOSATID = dr.FORMAPAGOSATID;
                

                rowTable.CONSECUTIVO = iConsecutivo++;
                table.AddPAGOSAVANZADORow(rowTable);
            }
            


            List<String> formasPagoPermitidas = new List<string>();



            if (PA_ABONOTextBox.Enabled)
                formasPagoPermitidas.Add(PagosAvanzadoFormas.Efectivo);

            if (TBMontoTarjeta.Enabled)
            {

                formasPagoPermitidas.Add(PagosAvanzadoFormas.Tarjeta_de_credito);
                formasPagoPermitidas.Add(PagosAvanzadoFormas.Tarjeta_de_debito);
                formasPagoPermitidas.Add(PagosAvanzadoFormas.Tarjeta_de_servicio);
            }


            if (TBMontoCheque.Enabled)
                formasPagoPermitidas.Add(PagosAvanzadoFormas.Cheque_nominativo);

            if (TBMontoVale.Enabled)
                formasPagoPermitidas.Add(PagosAvanzadoFormas.Vales_de_despensa);

            if (TBMontoTransferencia.Enabled)
                formasPagoPermitidas.Add(PagosAvanzadoFormas.Transferencia_electronica_de_fondos);



            
            

            WFPagosAvanzado wf = new WFPagosAvanzado(table, formasPagoPermitidas, Math.Round(m_Docto.ITOTAL, 2));
            wf.ShowDialog();
            Boolean aplicarCambios = wf.AplicarCambios;
            iPos.PuntoDeVenta.DSPuntoDeVentaAux2.PAGOSAVANZADODataTable tablaPagos = wf.TablaPagos;
            wf.Dispose();
            GC.SuppressFinalize(wf);


            if(aplicarCambios)
            {
                otrosPagos.Clear();


                PA_ABONOTextBox.Text = "0.00";
                TBMontoTarjeta.Text = "0.00";
                ComboBancoTarjeta.SelectedIndex = -1;
                TBReferenciaTarjeta.Text = "";
                TBMontoCheque.Text = "0.00";
                ComboBancoCheque.SelectedIndex = -1;
                TBReferenciaCheque.Text = "";
                TBMontoTransferencia.Text = "0.00";
                ComboBancoTransferencia.SelectedIndex = -1;
                TBReferenciaTransferencia.Text = "";
                TBMontoVale.Text = "0.00";
                lblOtros.Text = "0.00";

                iConsecutivo = 1;
                foreach(iPos.PuntoDeVenta.DSPuntoDeVentaAux2.PAGOSAVANZADORow row in tablaPagos.Rows)
                {
                    switch(row.FORMAPAGONOMBRE)
                    {
                        case PagosAvanzadoFormas.Efectivo:
                            PA_ABONOTextBox.Text = row.MONTO.ToString("N2");
                            break;
                        case PagosAvanzadoFormas.Tarjeta_de_credito:
                        case PagosAvanzadoFormas.Tarjeta_de_debito:
                        case PagosAvanzadoFormas.Tarjeta_de_servicio:

                            if(decimal.Parse(this.TBMontoTarjeta.NumericValue.ToString()) > 0)
                            {
                                iPos.PuntoDeVenta.DSPuntoDeVentaAux2.PAGOSAVANZADORow rowTable = otrosPagos.NewPAGOSAVANZADORow();
                                rowTable.FORMAPAGOID = row.FORMAPAGOID;
                                rowTable.FORMAPAGONOMBRE = row.FORMAPAGONOMBRE;
                                rowTable.MONTO = row.MONTO;


                                if (!row.IsBANCOIDNull())
                                    rowTable.BANCOID = row.BANCOID;
                                if (!row.IsBANCONOMBRENull())
                                    rowTable.BANCONOMBRE = row.BANCONOMBRE;
                                if (!row.IsREFERENCIANull())
                                    rowTable.REFERENCIA = row.REFERENCIA;

                                if (!row.IsFORMAPAGOSATIDNull())
                                    rowTable.FORMAPAGOSATID = row.FORMAPAGOSATID;
                                rowTable.CONSECUTIVO = iConsecutivo++;
                                otrosPagos.AddPAGOSAVANZADORow(rowTable);

                            }
                            else
                            {
                                this.ComboBancoTarjeta.SelectedValue = row.BANCOID;
                                this.TBReferenciaTarjeta.Text = row.REFERENCIA;
                                TBMontoTarjeta.Text = row.MONTO.ToString("N2");

                                switch (row.FORMAPAGONOMBRE)
                                {

                                    case PagosAvanzadoFormas.Tarjeta_de_credito:
                                        CBTIPOTARJETA.SelectedIndex = 0;
                                        break;
                                    case PagosAvanzadoFormas.Tarjeta_de_debito:
                                        CBTIPOTARJETA.SelectedIndex = 1;
                                        break;
                                    case PagosAvanzadoFormas.Tarjeta_de_servicio:
                                        CBTIPOTARJETA.SelectedIndex = 2;
                                        break;
                                }
                            }

                            break;
                        case PagosAvanzadoFormas.Cheque_nominativo:

                            if (decimal.Parse(this.TBMontoCheque.NumericValue.ToString()) > 0)
                            {
                                iPos.PuntoDeVenta.DSPuntoDeVentaAux2.PAGOSAVANZADORow rowTable = otrosPagos.NewPAGOSAVANZADORow();
                                rowTable.FORMAPAGOID = row.FORMAPAGOID;
                                rowTable.FORMAPAGONOMBRE = row.FORMAPAGONOMBRE;
                                rowTable.MONTO = row.MONTO;
                                if (!row.IsBANCOIDNull())
                                    rowTable.BANCOID = row.BANCOID;
                                if (!row.IsBANCONOMBRENull())
                                    rowTable.BANCONOMBRE = row.BANCONOMBRE;
                                if (!row.IsREFERENCIANull())
                                    rowTable.REFERENCIA = row.REFERENCIA;
                                if (!row.IsFORMAPAGOSATIDNull())
                                    rowTable.FORMAPAGOSATID = row.FORMAPAGOSATID;
                                rowTable.CONSECUTIVO = iConsecutivo++;
                                otrosPagos.AddPAGOSAVANZADORow(rowTable);

                            }
                            else
                            {

                                this.ComboBancoCheque.SelectedValue = row.BANCOID;
                                this.TBReferenciaCheque.Text = row.REFERENCIA;
                                TBMontoCheque.Text = row.MONTO.ToString("N2");
                            }


                            break;
                        case PagosAvanzadoFormas.Vales_de_despensa:


                            if (decimal.Parse(this.TBMontoVale.NumericValue.ToString()) > 0)
                            {
                                iPos.PuntoDeVenta.DSPuntoDeVentaAux2.PAGOSAVANZADORow rowTable = otrosPagos.NewPAGOSAVANZADORow();
                                rowTable.FORMAPAGOID = row.FORMAPAGOID;
                                rowTable.FORMAPAGONOMBRE = row.FORMAPAGONOMBRE;
                                rowTable.MONTO = row.MONTO;
                                if (!row.IsBANCOIDNull())
                                    rowTable.BANCOID = row.BANCOID;
                                if (!row.IsBANCONOMBRENull())
                                    rowTable.BANCONOMBRE = row.BANCONOMBRE;
                                if (!row.IsREFERENCIANull())
                                    rowTable.REFERENCIA = row.REFERENCIA;
                                if (!row.IsFORMAPAGOSATIDNull())
                                    rowTable.FORMAPAGOSATID = row.FORMAPAGOSATID;
                                rowTable.CONSECUTIVO = iConsecutivo++;
                                otrosPagos.AddPAGOSAVANZADORow(rowTable);

                            }
                            else
                            {
                                TBMontoVale.Text = row.MONTO.ToString("N2");

                            }

                            break;
                        case PagosAvanzadoFormas.Transferencia_electronica_de_fondos:

                            if (decimal.Parse(this.TBMontoTransferencia.NumericValue.ToString()) > 0)
                            {
                                iPos.PuntoDeVenta.DSPuntoDeVentaAux2.PAGOSAVANZADORow rowTable = otrosPagos.NewPAGOSAVANZADORow();
                                rowTable.FORMAPAGOID = row.FORMAPAGOID;
                                rowTable.FORMAPAGONOMBRE = row.FORMAPAGONOMBRE;
                                rowTable.MONTO = row.MONTO;
                                if (!row.IsBANCOIDNull())
                                    rowTable.BANCOID = row.BANCOID;
                                if (!row.IsBANCONOMBRENull())
                                    rowTable.BANCONOMBRE = row.BANCONOMBRE;
                                if (!row.IsREFERENCIANull())
                                    rowTable.REFERENCIA = row.REFERENCIA;
                                if(!row.IsFORMAPAGOSATIDNull())
                                    rowTable.FORMAPAGOSATID = row.FORMAPAGOSATID;
                                rowTable.CONSECUTIVO = iConsecutivo++;
                                otrosPagos.AddPAGOSAVANZADORow(rowTable);

                            }
                            else
                            {
                                this.ComboBancoTransferencia.SelectedValue = row.BANCOID;
                                this.TBReferenciaTransferencia.Text = row.REFERENCIA;
                                TBMontoTransferencia.Text = row.MONTO.ToString("N2");
                                
                            }

                            break;
                        default:
                            break;
                    }
                }

                decimal montoOtros = 0m;
                foreach (iPos.PuntoDeVenta.DSPuntoDeVentaAux2.PAGOSAVANZADORow row in otrosPagos)
                {
                    montoOtros += row.MONTO;
                }

                lblOtros.Text = montoOtros.ToString("N2");
                AsignarCambio();


            }
        }



        private void formaPagoFromDescriptionAv(string formaPagoAvNombre, out long formaPagoSeleccionada, out long formaPagoSatSeleccionada)
        {

            formaPagoSeleccionada = 0;
            formaPagoSatSeleccionada = 0;


            switch (formaPagoAvNombre)
            {

                case PagosAvanzadoFormas.Efectivo: formaPagoSeleccionada = DBValues._FORMA_PAGO_EFECTIVO; formaPagoSatSeleccionada = DBValues._FORMA_PAGOSAT_EFECTIVO; break;
                case PagosAvanzadoFormas.Tarjeta_de_credito: formaPagoSeleccionada = DBValues._FORMA_PAGO_TARJETA; formaPagoSatSeleccionada = DBValues._FORMA_PAGOSAT_TARJETACREDITO; break;
                case PagosAvanzadoFormas.Tarjeta_de_debito: formaPagoSeleccionada = DBValues._FORMA_PAGO_TARJETA; formaPagoSatSeleccionada = DBValues._FORMA_PAGOSAT_TARJETADEBITO; break;
                case PagosAvanzadoFormas.Tarjeta_de_servicio: formaPagoSeleccionada = DBValues._FORMA_PAGO_TARJETA; formaPagoSatSeleccionada = DBValues._FORMA_PAGOSAT_TARJETASERVICIO; break;
                case PagosAvanzadoFormas.Cheque_nominativo: formaPagoSeleccionada = DBValues._FORMA_PAGO_CHEQUE; formaPagoSatSeleccionada = DBValues._FORMA_PAGOSAT_CHEQUE; break;
                case PagosAvanzadoFormas.Vales_de_despensa: formaPagoSeleccionada = DBValues._FORMA_PAGO_VALE; formaPagoSatSeleccionada = DBValues._FORMA_PAGOSAT_VALE; break;
                case PagosAvanzadoFormas.Transferencia_electronica_de_fondos: formaPagoSeleccionada = DBValues._FORMA_PAGO_TRANSFERENCIA; formaPagoSatSeleccionada = DBValues._FORMA_PAGOSAT_TRANSFERENCIA; break;
                case PagosAvanzadoFormas.Intercambio_de_mercancia: formaPagoSeleccionada = DBValues._FORMA_PAGO_INTERCAMBIOMERCANCIACREDITO; formaPagoSatSeleccionada = DBValues._FORMA_PAGOSAT_COMPENSACION; break;
                case PagosAvanzadoFormas.Otros: formaPagoSeleccionada = DBValues._FORMA_PAGO_NOIDENTIFICADO; formaPagoSatSeleccionada = DBValues._FORMA_PAGOSAT_OTRO; break;
                case PagosAvanzadoFormas.Deposito: formaPagoSeleccionada = DBValues._FORMA_PAGO_DEPOSITO; formaPagoSatSeleccionada = DBValues._FORMA_PAGOSAT_EFECTIVO; break;
                case PagosAvanzadoFormas.Deposito_a_terceros: formaPagoSeleccionada = DBValues._FORMA_PAGO_DEPOSITOTERCERO; formaPagoSatSeleccionada = DBValues._FORMA_PAGOSAT_EFECTIVO; break;
                default: formaPagoSeleccionada = DBValues._FORMA_PAGO_EFECTIVO; formaPagoSatSeleccionada = DBValues._FORMA_PAGOSAT_EFECTIVO;  break;
            }
            


        }

        private void TBMontoTransferencia_Validated(object sender, EventArgs e)
        {
            AsignarCambio();
        }

        private void btnReinicializaVerifone_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Realmente desea reinicializar la terminal verifone? .  ",
                                "Confirmacion",
                                MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }


            PagoVerifoneHelper.PreparaPinPad(true);
        }

     

    }

    class sortDoctoPagoPorMontoHelper : IComparer
    {
        int IComparer.Compare(object a, object b)
        {
            CDOCTOPAGOBE c1 = (CDOCTOPAGOBE)a;
            CDOCTOPAGOBE c2 = (CDOCTOPAGOBE)b;
            if (c1.IIMPORTE > c2.IIMPORTE)
                return -1;
            if (c1.IIMPORTE < c2.IIMPORTE)
                return 1;
            else
                return 0;
        }
    }

}
