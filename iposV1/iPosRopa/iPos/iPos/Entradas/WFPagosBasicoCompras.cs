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
namespace iPos
{
    public partial class WFPagosBasicoCompras : IposForm
    {
        CDOCTOBE m_Docto;
        CCAJABE m_Caja;
        decimal m_dMontoVenta;
        decimal m_dSumaAbonos;
        decimal m_dRestanteAPagar;
        decimal m_dGastosAdicAplicar;
        public string m_numeroVale = "";
        public bool m_bPagoCompleto;

        bool m_bVale;
        decimal m_montoVale;

        CDOCTOBE m_DoctoRef;
        tipoTransaccionV m_tipoTransaccion;

        string m_esapartado = "N";

        CPERSONABE m_persona;

        public bool m_afectarSaldosParciales = false;

        bool m_convierteApartado = false;
        long m_personaApartadoId = 0;


        public long DOCTOPAGOIDEFECTIVO = 0;
        public long DOCTOPAGOIDTARJETA = 0;
        public long DOCTOPAGOIDCHEQUE = 0;


        public WFPagosBasicoCompras()
        {
            InitializeComponent();
            m_bPagoCompleto = false;
        }

        public WFPagosBasicoCompras(CDOCTOBE Docto, CCAJABE Caja, bool bVale, decimal montoVale,
                           CDOCTOBE DoctoRef, tipoTransaccionV tipoTransaccion, string esapartado,
                           bool afectarSaldosParciales):this(Docto,Caja,bVale, montoVale,
                            DoctoRef, tipoTransaccion, esapartado, afectarSaldosParciales,false,0)
        {
        }

        public WFPagosBasicoCompras(CDOCTOBE Docto, CCAJABE Caja, bool bVale, decimal montoVale, 
                           CDOCTOBE DoctoRef, tipoTransaccionV tipoTransaccion,string esapartado, 
                           bool afectarSaldosParciales, 
                           bool convierteApartado, long personaApartadoId)
            : this()
        {
            m_Caja = Caja;
            m_Docto = Docto;

            m_bVale = bVale;
            m_montoVale = montoVale;

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


        }
        public void LimpiarPago()
        {
            
            this.PA_ABONOTextBox.Text = "";

            this.TBMontoTarjeta.Text = "";
            this.TBMontoCheque.Text = "";
            this.TBMontoTransferencia.Text = "";
            this.TBReferenciaCheque.Text = "";
            this.TBReferenciaTarjeta.Text = "";
            this.TBReferenciaTransferencia.Text = "";

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
            m_dGastosAdicAplicar = 0;
        }
        public void GetTotalesPagosVenta()
        {
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            decimal dMontoVenta = 0;
            decimal dSumaAbonos = 0;
            decimal dRestanteAPagar = 0;
            decimal dGastosAdicAplicar = 0;

            dGastosAdicAplicar = GetGastosAdicDocto();
            dMontoVenta = m_Docto.ITOTAL + dGastosAdicAplicar;

            if (m_bVale)
                dRestanteAPagar = m_montoVale;
            else
                dRestanteAPagar = dMontoVenta;


            //pvd.TotalesPagosVENTAS(m_Venta.IGV_VENTA, null, ref dMontoVenta, ref dSumaAbonos, ref dRestanteAPagar);

            if (pvd.IComentario == "" || pvd.IComentario == null)
            {
                m_dMontoVenta = dMontoVenta;
                m_dSumaAbonos = dSumaAbonos;
                m_dRestanteAPagar = dRestanteAPagar;
                m_dGastosAdicAplicar = dGastosAdicAplicar;
            }
            else
            {
                MessageBox.Show("ERRORES: " + pvd.IComentario.Replace("%", "\n"));
                LimpiarTotalesPagosVenta();
            }
        }


        public decimal GetGastosAdicDocto()
        {
            if (m_Docto != null && m_Docto.IID > 0 && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA)
            {
                CDOCTOD doctoD = new CDOCTOD();
                return doctoD.GetSumaGastosAdic(m_Docto, null);
            }
            else
            {
                return 0;
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
                /*if (!(bool)clienteBE.m_PersonaBE.isnull["IHAB_PAGOTARJETA"])
                {
                    this.TBMontoTarjeta.Enabled = (clienteBE.m_PersonaBE.IHAB_PAGOTARJETA == DBValues._DB_BOOLVALUE_SI);
                }
                else
                {
                    this.TBMontoTarjeta.Enabled = false;
                }*/


               /* if (!(bool)clienteBE.m_PersonaBE.isnull["IHAB_PAGOCREDITO"])
                {
                    this.TBMontoCredito.Enabled = (clienteBE.m_PersonaBE.IHAB_PAGOCREDITO == DBValues._DB_BOOLVALUE_SI);
                }
                else
                {
                    this.TBMontoCredito.Enabled = false;
                }*/


            }
            else
            {
                //this.TBMontoTarjeta.Enabled = true;
                //this.TBMontoCredito.Enabled = true;
                //this.TBMontoCheque.Enabled = true;
                //this.TBMontoVale.Enabled = true;
            }
        }

        public void RefreshTotalesVenta()
        {
            /*
            if (m_bVale)
            {
                this.TBPagosTotalVenta.Text = this.m_montoVale.ToString("N2");
                this.TBMontoVale.Enabled = true;
            }
            else
            {*/
                this.TBPagosTotalVenta.Text = m_dMontoVenta.ToString("N2");
               /* this.TBMontoVale.Enabled = false;
            }*/
            
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
            decimal dPagoTotal;
            decimal dPagoEfectivo = decimal.Parse(PA_ABONOTextBox.NumericValue.ToString());

            decimal dPagoTarjeta = decimal.Parse(this.TBMontoTarjeta.NumericValue.ToString()) ;
            decimal dPagoCheque = decimal.Parse(this.TBMontoCheque.NumericValue.ToString()) ;
            decimal dPagoTransferencia = decimal.Parse(this.TBMontoTransferencia.NumericValue.ToString()) ;


            decimal dPagoCredito = 0;
            decimal dCambioCheque = 0;
            decimal dPagoEfectivoRecibido = dPagoEfectivo;


            DOCTOPAGOIDEFECTIVO = 0;
            DOCTOPAGOIDTARJETA = 0;
            DOCTOPAGOIDCHEQUE = 0;
            

            dPagoTotal = dPagoEfectivo + dPagoTarjeta /*+ dPagoCredito*/  + dPagoCheque +  dPagoTransferencia/*+ dPagoVale*/ /*+ dPagoCreditoAutomatico + dPagoCreditoManual*/;


            //checar que no se pague de mas
            if (Math.Abs(dPagoTotal - m_dRestanteAPagar) > (decimal)0.02 && dPagoTotal >= m_dRestanteAPagar)
            {

                MessageBox.Show("No se puede pagar de mas , en este tipo de transacción no se manejan cambios. Por favor ingrese el monto exacto");
                return;
            }

            //checa si se ha pagado todo
            if (dPagoTotal < m_dRestanteAPagar)
            {
               /* if (!(m_bVale && dPagoTotal>=m_montoVale))
                {*/

                WFPagoPreguntarCredito wf = new WFPagoPreguntarCredito();
                wf.ShowDialog();
                bool bAsignarCredito = wf.m_bAsignarCredito;
                wf.Dispose();
                GC.SuppressFinalize(wf);


                if (bAsignarCredito)
                {
                    dPagoCredito = m_dRestanteAPagar - dPagoTotal;
                    dPagoTotal += dPagoCredito;
                }
                else
                {
                    MessageBox.Show("no se ha pagado el monto total de la venta");
                    return;
                }
               // }
            }

            if (dPagoTarjeta > Math.Ceiling(m_Docto.ITOTAL))
            {

                MessageBox.Show("el monto de la tarjeta no puede superar el total de la venta");
                return;
            }

            if (dPagoTransferencia > Math.Ceiling(m_Docto.ITOTAL))
            {

                MessageBox.Show("el monto de transferencia no puede superar el total de la venta");
                return;
            }



            decimal dCambio = dPagoTotal - m_dRestanteAPagar;


            string strReferenciaTarjeta = "", strReferenciaCheque = "", strReferenciaTransferencia = "";
            long lBancoTarjeta = 0, lBancoCheque = 0, lBancoTransferencia = 0;

            if (dPagoTarjeta > 0)
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




            CDOCTOPAGOBE pagoBE;
            CDOCTOPAGOD pagoD = new CDOCTOPAGOD();

            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            try
            {

                fConn.Open();
                fTrans = fConn.BeginTransaction();

                pagoBE = new CDOCTOPAGOBE();
                pagoBE.IDOCTOID = m_Docto.IID;
                pagoBE.IFECHA = DateTime.Now;
                pagoBE.IFECHAHORA = DateTime.Now;
                pagoBE.ICORTEID = CurrentUserID.CurrentUser.ICORTEID; ;


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
                    fConn.Close();
                    throw new Exception();
                }

                //prorrateo de gastos adicionales
                if (!ProrrateaGastosAdicionales(fTrans))
                {

                    fTrans.Rollback();
                    MessageBox.Show("Ocurrio un error al asignar venta de apartado");
                    fConn.Close();
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
                switch (CBTIPOTARJETA.SelectedIndex)
                {
                    case 0: tarjetaFormaPagoSatId = DBValues._FORMA_PAGOSAT_TARJETACREDITO; break;
                    case 1: tarjetaFormaPagoSatId = DBValues._FORMA_PAGOSAT_TARJETADEBITO; break;
                    case 2: tarjetaFormaPagoSatId = DBValues._FORMA_PAGOSAT_TARJETASERVICIO; break;
                    default: tarjetaFormaPagoSatId = DBValues._FORMA_PAGOSAT_TARJETACREDITO; break;
                }


                if (!pagoD.DOCTO_PAGO_SP(pagoBE, m_dRestanteAPagar, dPagoEfectivo, dPagoTarjeta, dPagoCheque, dPagoCredito, 0, dPagoEfectivoRecibido, dCambioCheque, 0, 0, 0, CurrentUserID.CurrentUser.IID, lBancoTarjeta, strReferenciaTarjeta, lBancoCheque, strReferenciaCheque, 0, "", dPagoTransferencia, lBancoTransferencia, strReferenciaTransferencia,tarjetaFormaPagoSatId, 0, 0,  ref DOCTOPAGOIDEFECTIVO, ref DOCTOPAGOIDTARJETA, ref DOCTOPAGOIDCHEQUE, fTrans))
                {
                    fTrans.Rollback();
                    MessageBox.Show(pagoD.IComentario);
                    throw new Exception();
                }



                if (m_afectarSaldosParciales)
                {

                    if (m_Docto.ITIPODOCTOID != DBValues._DOCTO_TIPO_VENTAAPARTADO)
                    {
                        if (!pagoD.AjustarSaldosPersona(m_Docto.IPERSONAID, fTrans))
                        {

                            fTrans.Rollback();
                            MessageBox.Show(pagoD.IComentario);
                            throw new Exception();
                        }
                    }
                    else
                    {
                        if (!pagoD.AjustarSaldosPersonaApartado(m_Docto.IPERSONAAPARTADOID, fTrans))
                        {

                            fTrans.Rollback();
                            MessageBox.Show(pagoD.IComentario);
                            throw new Exception();
                        }
                    }
                }


                if(!GuardaNotaPago(fTrans))
                {

                    fTrans.Rollback();
                    MessageBox.Show("Hubo un problema al guardar la nota de pago");
                    throw new Exception();
                }

                fTrans.Commit();
                this.m_bPagoCompleto = true;


                fConn.Close();


                this.Close();

            }
            catch
            {
                fConn.Close();
            }
            finally
            {
                fConn.Close();
            }



        }

        private void BTPaymentSave_Click(object sender, EventArgs e)
        {
            GuardarPago();
        }
        private void AsignarCambio()
        {
            decimal dPagoTotal;
            decimal dPagoEfectivo = decimal.Parse(PA_ABONOTextBox.NumericValue.ToString());
            decimal dPagoTarjeta = decimal.Parse(this.TBMontoTarjeta.NumericValue.ToString()) ;
            decimal dPagoCheque = decimal.Parse(this.TBMontoCheque.NumericValue.ToString()) ;
            decimal dPagoTransferencia = decimal.Parse(this.TBMontoTransferencia.NumericValue.ToString()) ;



            dPagoTotal = dPagoEfectivo + dPagoTarjeta /*+ dPagoCredito*/ + dPagoCheque + dPagoTransferencia /*+ dPagoVale*/ /*+ dPagoCreditoAutomatico + dPagoCreditoManual*/;


            decimal dCambio = dPagoTotal - m_dRestanteAPagar;
            if (dCambio >= 0)
            {
                //TBCambioTextBox.Text = dCambio.ToString("N2");
                LBFaltante.Text = "";
            }
            else
            {
                //TBCambioTextBox.Text = "0.00";
                LBFaltante.Text = "Faltan : " + (dCambio * (-1)).ToString("N2") + " pesos ";
            }
        }
        private void PA_ABONOTextBox_Validated(object sender, EventArgs e)
        {
            AsignarCambio();
        }

        private void TBMontoTarjeta_Validated(object sender, EventArgs e)
        {
            AsignarCambio();
        }


        private void TBMontoCheque_Validated(object sender, EventArgs e)
        {
            AsignarCambio();
        }

        private void TBMontoTransferencia_Validated(object sender, EventArgs e)
        {
            AsignarCambio();
        }


        private void WFPagosBasicoCompras_Load(object sender, EventArgs e)
        {
            //if (this.m_bVale)
            //{
            //    this.TBMontoVale.Focus();
            //}
            //else
                this.PA_ABONOTextBox.Focus();

            this.LBFaltante.Text = "";

            m_persona = new CPERSONABE();
            m_persona.IID = m_Docto.IPERSONAID;
            CPERSONAD personaD = new CPERSONAD();
            m_persona = personaD.seleccionarPERSONA(m_persona,null);



            this.ComboBancoTarjeta.llenarDatos();
            this.ComboBancoTarjeta.SelectedIndex = -1;

            this.ComboBancoCheque.llenarDatos();
            this.ComboBancoCheque.SelectedIndex = -1;

            this.ComboBancoTransferencia.llenarDatos();
            this.ComboBancoTransferencia.SelectedIndex = -1;

            CBTIPOTARJETA.SelectedIndex = 0;


            DesHabilitarCamposPorPPCSiAplica();

        }



        private void WFPagosBasicoCompras_Shown(object sender, EventArgs e)
        {
            //if (this.m_bVale)
            //{
            //    this.TBMontoVale.Focus();
            //}
            //else
                this.PA_ABONOTextBox.Focus();
        }

        private void WFPagosBasicoCompras_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.F10:
                    GuardarPago();
                    break;

                case Keys.Escape:
                    this.Close();
                    break;

                default:
                    break;
            }
        }



        private void DesHabilitarCamposPorPPCSiAplica()
        {

            bool esMatrizPrincipal = CurrentUserID.EsMatrizPrincipal();
            if (!esMatrizPrincipal && CurrentUserID.CurrentParameters.IHABPPC != null && CurrentUserID.CurrentParameters.IHABPPC.Equals("S") && m_Docto != null && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA && m_Docto.ISUBTIPODOCTOID == 0)
            {
                PA_ABONOTextBox.ReadOnly = true;
                CBTIPOTARJETA.Enabled = false;
                TBMontoTarjeta.ReadOnly = true;
                TBMontoCheque.ReadOnly = true;
                TBMontoTransferencia.ReadOnly = true;
                pnlBancarioTarjeta.Enabled = false;
                pnlBancarioCheque.Enabled = false;
                pnlBancarioTransferencia.Enabled = false;
            }
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

        private bool ProrrateaGastosAdicionales(FbTransaction fTrans)
        {
            if (m_dGastosAdicAplicar > 0)
            {
                CDOCTOD doctoD = new CDOCTOD();
                if (doctoD.DOCTO_RECALCULAR_GASTOSADIC(m_Docto,fTrans))
                {
                    return true;
                }
                else
                    return false;

            }
            return true;
        }

        private bool GuardaNotaPago(FbTransaction fTrans)
        {
            CDOCTOD doctoD = new CDOCTOD();
            m_Docto.INOTAPAGO = NOTAPAGOTextBox.Text;
            if(doctoD.CambiarNotaPago(m_Docto, m_Docto, fTrans))
            {
                return true;
            }
            else{
                return false;
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
