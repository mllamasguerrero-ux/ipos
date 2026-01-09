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
using FirebirdSql.Data.FirebirdClient;
using FlatTabControl;
using iPosReporting;
using System.Collections;
using iPos.PuntoDeVenta;

namespace iPos
{
    public partial class WFPagosDevoluciones : IposForm
    {
        CDOCTOBE m_Docto;
        CDOCTOBE m_DoctoRef;
        tipoTransaccionV m_tipoTransaccion;
        CPERSONABE m_persona;
        public bool m_afectarSaldosParciales = false;
        string m_esapartado = "N";
        CCAJABE m_Caja;
        bool m_bVale;
        decimal m_montoVale;
        public string m_numeroVale = "";
        public bool m_bPagoCompleto;
        decimal m_dMontoVenta;
        decimal m_dSumaAbonos;
        decimal m_dRestanteAPagar;

        decimal m_dCreditoAutomaticoDisponible = 0;
        public bool m_generarFacturaElectronica;

        public bool m_derechoDejarSaldoFavor = false;



          public WFPagosDevoluciones()
        {
            InitializeComponent();
            m_bPagoCompleto = false;
            m_generarFacturaElectronica = false;
        }
          public WFPagosDevoluciones(CDOCTOBE Docto, CCAJABE Caja, bool bVale, decimal montoVale, CDOCTOBE DoctoRef, tipoTransaccionV tipoTransaccion, string esapartado, bool afectarSaldosParciales)
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
        }
        public void GetTotalesPagosVenta()
        {
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            decimal dMontoVenta = 0;
            decimal dSumaAbonos = 0;
            decimal dRestanteAPagar = 0;
            dMontoVenta = m_Docto.ITOTAL;

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
            }
            else
            {
                MessageBox.Show("ERRORES: " + pvd.IComentario.Replace("%", "\n"));
                LimpiarTotalesPagosVenta();
            }
        }



        public void HabilitarFormasPago()
        {
            
        }

        public void RefreshTotalesVenta()
        {

            
            if (m_bVale)
            {
                this.TBPagosTotalVenta.Text = this.m_montoVale.ToString("N2");
            }
            else
            {
                this.TBPagosTotalVenta.Text = m_dMontoVenta.ToString("N2");
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

        private bool Confirma(string message, string leyendaAceptar, string leyendaCancelar)
        {
            bool boolAceptar = false;
            WFPreguntaConfirmacion frm = new WFPreguntaConfirmacion(message,  leyendaAceptar, leyendaCancelar );
            frm.ShowDialog();
            boolAceptar = frm.BoolAceptar;
            frm.Dispose();
            GC.SuppressFinalize(frm);
            return boolAceptar;
        }

        private void GuardarPago()
        {
            AsignarCambio();
            long formaPagoFE = 0;

            decimal dPagoTotal;
            decimal dPagoEfectivo = decimal.Parse(PA_ABONOTextBox.NumericValue.ToString());
            


            //decimal dCambioCheque = 0;
            decimal dPagoEfectivoRecibido = dPagoEfectivo;


            dPagoTotal = dPagoEfectivo;

            decimal dCreditoNoAplicado = 0;
            decimal dCreditoAutomatico = 0;




            //checar que no se pague de mas
            if (Math.Abs(dPagoTotal - m_dRestanteAPagar) > (decimal)0.02 &&  dPagoTotal >= m_dRestanteAPagar)
            {

                MessageBox.Show("No se puede pagar de mas , en este tipo de transacción no se manejan cambios. Por favor ingrese el monto exacto");
                return;
            }

            //checa si se ha pagado todo
            if (dPagoTotal < /*m_Docto.ITOTAL*/m_dRestanteAPagar)
            {
                decimal bufferAplicacionCredito = m_Docto.ITOTAL - dPagoTotal;

                if (this.CBCreditoAutomatico.Checked)
                {

                    dCreditoAutomatico = (this.m_dCreditoAutomaticoDisponible > bufferAplicacionCredito) ? bufferAplicacionCredito : this.m_dCreditoAutomaticoDisponible;
                    bufferAplicacionCredito = (this.m_dCreditoAutomaticoDisponible > bufferAplicacionCredito) ? 0 : bufferAplicacionCredito - this.m_dCreditoAutomaticoDisponible;

                }

                dCreditoNoAplicado = bufferAplicacionCredito;

                //dCreditoAutomatico = (this.CBCreditoAutomatico.Checked) ? (m_Docto.ITOTAL - dPagoTotal) : 0;
                //dCreditoNoAplicado = (!this.CBCreditoAutomatico.Checked) ? (m_Docto.ITOTAL - dPagoTotal) : 0;

                /*if (!(m_bVale && dPagoTotal>=m_montoVale))
                {
                    MessageBox.Show("no se ha pagado el monto total de la venta");
                    return;
                }*/
            }

            if(dCreditoNoAplicado > 0.02m )
            {
                if (!m_derechoDejarSaldoFavor)
                {
                    MessageBox.Show("No tiene derecho para dejar saldo a favor del cliente, llame a sistemas o pague el efectivo necesario");
                    return;
                }
                else
                {

                    if (!Confirma("EL cliente se quedara con Saldo a favor para aplicar en una venta diferente a la que se esta aplicando la nota de credito si estas de acuerdo da CLICK en 'Continuar con el pago' o de lo contrario da CLICK en el botón de 'Regresar' y pon la cantidad en el campo de efectivo y CLICK en el botón de guardar pago. "
                                   , "Continuar con el pago", "Regresar"))
                    {
                        return;
                    }
                }
            }

            if(m_derechoDejarSaldoFavor && m_dCreditoAutomaticoDisponible > dCreditoAutomatico + 0.02m)
            {


                if (!Confirma("La venta cuenta con saldo " + m_dCreditoAutomaticoDisponible.ToString("#.##") + " por lo que se sugiere que por lo menos ese saldo se aplique por la nota de credito , si falta para completar el monto de la nota de credito se puede regresar efectivo o dejarlo a credito no aplicado  , de ser este un error de CLICK en el botón de 'Regresar' y ponga una cantidad en el campo de efectivo menor o igual a " + (m_Docto.ITOTAL - m_dCreditoAutomaticoDisponible).ToString("#.##") +" y vuelva a darle CLICK en el boton de guardar,  en caso de que quiera continuar el pago aun sin aplicar el credito de la venta entonces dele CLICK en el botón de 'Continuar con el pago' . "
                               , "Continuar con el pago", "Regresar") )
                {
                    return;
                }
            }

            



            decimal dCambio = dPagoTotal - m_dRestanteAPagar;


            //FACTURA ELECTRONICA PRESELECCION
            m_generarFacturaElectronica = this.CBFacturaElectronica.Checked;

            if (m_generarFacturaElectronica)
            {
                if (!FacturaElectronica(null, dPagoEfectivo, 0, (dCreditoAutomatico + dCreditoNoAplicado), 0, 0, ref formaPagoFE, true))
                {
                    MessageBox.Show("No se pudo validar la factura electronica");
                    return;
                }



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


                    if (dCambio > 0)
                    {
                        dPagoEfectivo -= dCambio;
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

                        if ((!(bool)this.m_Docto.isnull["IDOCTOREFID"]  || m_Docto.IDOCTOREFID != 0 ) && m_DoctoRef == null )
                        {
                            MessageBox.Show("Hubo un error (no se tiene la referencia de la transaccion que se devuelve)");
                            fConn.Close();
                            return;
                        }

                        if(m_DoctoRef != null)
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

                        if ((!(bool)this.m_Docto.isnull["IDOCTOREFID"] || m_Docto.IDOCTOREFID != 0) && m_DoctoRef == null)
                        {
                            MessageBox.Show("Hubo un error (no se tiene la referencia de la transaccion que se devuelve)");
                            fConn.Close();
                            return;
                        }

                        if(this.m_DoctoRef != null)
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

                if (!pagoD.DOCTO_PAGO_SP(pagoBE, m_dRestanteAPagar, dPagoEfectivo, 0, 0, dCreditoNoAplicado, 0, dPagoEfectivoRecibido, 0, dCreditoAutomatico, 0, 0, CurrentUserID.CurrentUser.IID, 0, "", 0, "", 0, "", 0, 0, "", tarjetaFormaPagoSatId, 0, 0, fTrans))
                {
                    fTrans.Rollback();
                    MessageBox.Show(pagoD.IComentario);
                    throw new Exception();
                }



                if (m_generarFacturaElectronica)
                {
                    if (!pagoD.ASIGNARPAGO_FACTELECTRONICA(m_Docto.IID, formaPagoFE, fTrans))
                    {
                        fTrans.Rollback();
                        MessageBox.Show(pagoD.IComentario);
                        throw new Exception();
                    }
                }
              


                if (m_afectarSaldosParciales)
                {

                    if (!pagoD.AjustarSaldosPersona(m_Docto.IPERSONAID,fTrans))
                    {

                        fTrans.Rollback();
                        MessageBox.Show(pagoD.IComentario);
                        throw new Exception();
                    }
                }


                if (!GuardaNotaPago(fTrans))
                {

                    fTrans.Rollback();
                    MessageBox.Show("Hubo un problema al guardar la nota de pago");
                    throw new Exception();
                }



                fTrans.Commit();
                fConn.Close();
                this.m_bPagoCompleto = true;
                m_generarFacturaElectronica = this.CBFacturaElectronica.Checked;
                this.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show("hubo un error " + ex.Message + ex.StackTrace);
                try
                {
                    fTrans.Rollback();
                }
                catch
                {
                }
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



            dPagoTotal = dPagoEfectivo ;


            decimal dCambio = dPagoTotal - m_dRestanteAPagar;
            if (dCambio >= 0)
            {
                //TBCambioTextBox.Text = dCambio.ToString("N2");
                //LBFaltante.Text = "";
            }
            else
            {
                //TBCambioTextBox.Text = "0.00";
                //LBFaltante.Text = "Faltan : " + (dCambio * (-1)).ToString("N2") + " pesos ";
            }
        }
        private void PA_ABONOTextBox_Validated(object sender, EventArgs e)
        {
            AsignarCambio();
        }
        private void WFPagosBasico_Load(object sender, EventArgs e)
        {
           
            this.PA_ABONOTextBox.Focus();

            this.LBFaltante.Text = "";

            //cliente/proveedor
            m_persona = new CPERSONABE();
            m_persona.IID = m_Docto.IPERSONAID;
            CPERSONAD personaD = new CPERSONAD();
            m_persona = personaD.seleccionarPERSONA(m_persona,null);

            //derecho dejar saldo a favor
            CUSUARIOSD usuariosD = new CUSUARIOSD();
            m_derechoDejarSaldoFavor = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_DEJARSALDOFAVORCLIENTE, null);


            if (m_DoctoRef != null)
            {
                if (m_Docto.ITOTAL > m_DoctoRef.ISALDO)
                {
                    m_dCreditoAutomaticoDisponible = m_DoctoRef.ISALDO;
                    //this.PA_ABONOTextBox.Text = (m_Docto.ITOTAL - m_dCreditoAutomaticoDisponible).ToString("N2");
                }
                else
                {
                    m_dCreditoAutomaticoDisponible = m_Docto.ITOTAL;
                }
                this.CBCreditoAutomatico.Text = "Aplicacion automatica de credito (max: " + m_dCreditoAutomaticoDisponible.ToString("N2") + " )";

                PA_ABONOTextBox.Text = (m_Docto.ITOTAL - m_dCreditoAutomaticoDisponible).ToString("#.##");

                if (m_dCreditoAutomaticoDisponible <= 0)
                {
                    this.CBCreditoAutomatico.Enabled = false;
                }
                else
                {
                    this.CBCreditoAutomatico.Enabled = true;
                    this.CBCreditoAutomatico.Checked = true;
                }

                if (m_DoctoRef.IESFACTURAELECTRONICA == "S")
                {
                    this.CBFacturaElectronica.Checked = true;
                    this.CBFacturaElectronica.Enabled = false;
                }
                if (m_DoctoRef.IESFACTURAELECTRONICA == "N" || m_DoctoRef.IESFACTURAELECTRONICA == "")
                {
                    this.CBFacturaElectronica.Checked = false;
                    this.CBFacturaElectronica.Enabled = false;
                }


            }
            else
            {
                this.CBCreditoAutomatico.Checked = false;
                this.CBCreditoAutomatico.Enabled = false;
            }



            switch (this.m_tipoTransaccion)
            {
                case tipoTransaccionV.t_devolucion:
                    this.CBFacturaElectronica.Visible = true;
                    break;
                default:
                    this.CBFacturaElectronica.Checked = false;
                    this.CBFacturaElectronica.Visible = false;
                    break;
            }

            DesHabilitarCamposPorPPCSiAplica();

        }


        private void DesHabilitarCamposPorPPCSiAplica()
        {

            if (m_tipoTransaccion == tipoTransaccionV.t_devolucion)
            {
                return;
            }

            bool esMatrizPrincipal = CurrentUserID.EsMatrizPrincipal();
            if (!esMatrizPrincipal && CurrentUserID.CurrentParameters.IHABPPC != null && CurrentUserID.CurrentParameters.IHABPPC.Equals("S") && m_Docto != null && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA && m_Docto.ISUBTIPODOCTOID == 0)
            {
                PA_ABONOTextBox.ReadOnly = true;
            }
        }

        private void WFPagosBasico_Shown(object sender, EventArgs e)
        {
            
                this.PA_ABONOTextBox.Focus();
        }



        private void CompletarFaltante()
        {


            if (m_Docto != null && this.PA_ABONOTextBox.Enabled && this.PA_ABONOTextBox.Visible)
            {
                this.PA_ABONOTextBox.Text = (m_Docto.ITOTAL - m_dCreditoAutomaticoDisponible).ToString("N2");
            }
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

                default:
                    break;
            }
        }

        private void CBCreditoAutomatico_CheckedChanged(object sender, EventArgs e)
        {
            AsignarCambio();
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

            foreach (CDOCTOPAGOBE pagoBE in list)
            {
                CDOCTOPAGOD pagoD = new CDOCTOPAGOD();
                string strFormaPago = pagoD.obtenNombreFormaPagoSatXId(pagoBE.IFORMAPAGOSATID, fTrans);
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


       

        private bool FacturaElectronica(FbTransaction fTrans, decimal dPagoEfectivo, decimal dPagoTarjeta, decimal dPagoCredito, decimal dPagoCheque, decimal dPagoVale, ref long formaPagoFE, bool bSoloValidar)
        {

            CDOCTOPAGOBE pagoTemporal = new CDOCTOPAGOBE();
            string strFormaPagoSelected = "";
            string strFormaPagoSat = "";

            ArrayList formasPago = new ArrayList();
            if (dPagoEfectivo > 0)
                formasPago.Add("EFECTIVO");
            if (dPagoTarjeta > 0)
                formasPago.Add("TARJETA");
            if (dPagoCredito > 0)
                formasPago.Add("CREDITO");
            if (dPagoCheque > 0)
                formasPago.Add("CHEQUE");
            if (dPagoVale > 0)
                formasPago.Add("VALE");



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

            switch (strFormaPagoSelected)
            {
                case "EFECTIVO":
                    {
                        formaPagoFE = 1;
                        pagoTemporal.IFORMAPAGOID = formaPagoFE;
                        pagoTemporal.IREFERENCIABANCARIA = "";
                        break;
                    }
                case "CREDITO":
                    {
                        formaPagoFE = 4;
                        pagoTemporal.IFORMAPAGOID = formaPagoFE;
                        pagoTemporal.IREFERENCIABANCARIA = "";
                        break;
                    }
                default:
                    break;
            }


            long tarjetaFormaPagoSatId = DBValues._FORMA_PAGOSAT_TARJETACREDITO;
            tarjetaFormaPagoSatId = DBValues._FORMA_PAGOSAT_TARJETACREDITO;
            pagoTemporal.IFORMAPAGOSATID = tarjetaFormaPagoSatId;

            strFormaPagoSat = CALCULAR_TIMBRADOFORMAPAGOSAT_FROMCODE(fTrans, dPagoEfectivo, dPagoTarjeta, dPagoCredito, dPagoCheque, dPagoVale, 0.0m, tarjetaFormaPagoSatId);


            if (m_Docto != null && m_Docto.IID > 0)
            {

                CDOCTOD vData = new CDOCTOD();
                m_Docto = vData.seleccionarDOCTO(m_Docto, fTrans);
                bool retorno;
                

                if (ValidarDatosParaFacturaElectronica(this.m_Docto))
                {

                    if (bSoloValidar)
                        return true;

                    iPosReporting.WFFacturaElectronica fe = new iPosReporting.WFFacturaElectronica(this.m_Docto, CurrentUserID.CurrentParameters, WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_TIMBRAR, pagoTemporal, this.m_DoctoRef, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA, strFormaPagoSat);
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

    }
}
