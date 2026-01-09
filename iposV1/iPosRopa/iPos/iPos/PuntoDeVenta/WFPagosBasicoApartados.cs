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
    public partial class WFPagosBasicoApartados : IposForm
    {
        CDOCTOBE m_Docto;
        CCAJABE m_Caja;
        decimal m_dMontoVenta;
        decimal m_dSumaAbonos;
        decimal m_dRestanteAPagar;
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

        public bool m_bPagoPorxCredito = false;
      

        public WFPagosBasicoApartados()
        {
            InitializeComponent();
            m_bPagoCompleto = false;
        }

        public WFPagosBasicoApartados(CDOCTOBE Docto, CCAJABE Caja, bool bVale, decimal montoVale,
                           CDOCTOBE DoctoRef, tipoTransaccionV tipoTransaccion, string esapartado,
                           bool afectarSaldosParciales):this(Docto,Caja,bVale, montoVale,
                            DoctoRef, tipoTransaccion, esapartado, afectarSaldosParciales,false,0)
        {
        }

        public WFPagosBasicoApartados(CDOCTOBE Docto, CCAJABE Caja, bool bVale, decimal montoVale, 
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
            CCLIENTEBE clienteBE = new CCLIENTEBE();
            CCLIENTED clienteD = new CCLIENTED();
            clienteBE.m_PersonaBE.IID = m_Docto.IPERSONAID;

            clienteBE.m_PersonaBE = clienteD.seleccionarPERSONA(clienteBE.m_PersonaBE, null);

            if (clienteBE.m_PersonaBE != null)
            {
                if (!(bool)clienteBE.m_PersonaBE.isnull["IHAB_PAGOTARJETA"])
                {
                    this.TBMontoTarjeta.Enabled = (clienteBE.m_PersonaBE.IHAB_PAGOTARJETA == DBValues._DB_BOOLVALUE_SI);
                }
                else
                {
                    this.TBMontoTarjeta.Enabled = false;
                }



                /*
                if (!(bool)clienteBE.m_PersonaBE.isnull["IHAB_PAGOCREDITO"])
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
                this.TBMontoTarjeta.Enabled = true;
                //this.TBMontoCredito.Enabled = true;
                this.TBMontoCheque.Enabled = true;
                //this.TBMontoVale.Enabled = true;
            }
        }

        public void RefreshTotalesVenta()
        {

            
            if (m_bVale)
            {
                this.TBPagosTotalVenta.Text = this.m_montoVale.ToString("N2");
                this.TBMontoVale.Enabled = true;
            }
            else
            {
                this.TBPagosTotalVenta.Text = m_dMontoVenta.ToString("N2");
                this.TBMontoVale.Enabled = false;
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


            if (this.NOMBRESTextBox.Text.Length == 0 || this.DOMICILIOTextBox.Text.Length == 0)
            {
                MessageBox.Show("Por favor ingrese por lo menos nombre y domicilio del cliente de apartado");
                return ;
            }

            AsignarCambio();
            decimal dPagoTotal;
            decimal dPagoEfectivo = decimal.Parse(PA_ABONOTextBox.NumericValue.ToString());
            decimal dPagoTarjeta = decimal.Parse(this.TBMontoTarjeta.NumericValue.ToString());
            decimal dPagoCredito = 0/*decimal.Parse(this.TBMontoCredito.NumericValue.ToString())*/;
            decimal dPagoCheque = decimal.Parse(this.TBMontoCheque.NumericValue.ToString());
            decimal dPagoVale = decimal.Parse(this.TBMontoVale.NumericValue.ToString());



            decimal dCambioCheque = 0;

            decimal dPagoEfectivoRecibido = dPagoEfectivo;

            m_bPagoPorxCredito = false;

            dPagoTotal = dPagoEfectivo + dPagoTarjeta + dPagoCredito + dPagoCheque + dPagoVale /*+ dPagoCreditoAutomatico + dPagoCreditoManual*/;

            //checa si se ha pagado todo
            if (dPagoTotal < m_Docto.ITOTAL )
            {
                if (!(m_bVale && dPagoTotal>=m_montoVale))
                {

                        WFPagoPreguntarCredito wf = new WFPagoPreguntarCredito();
                        wf.ShowDialog();
                        bool bAsignarCredito = wf.m_bAsignarCredito;
                        wf.Dispose();
                        GC.SuppressFinalize(wf);

                        if (bAsignarCredito)
                        {
                            dPagoCredito = m_dRestanteAPagar - dPagoTotal;
                            dPagoTotal += dPagoCredito;
                            m_bPagoPorxCredito = true;
                        }
                        else
                        {
                            MessageBox.Show("no se ha pagado el monto total de la venta");
                            return;
                        }

                }
            }

            if (dPagoTarjeta > Math.Ceiling(m_dRestanteAPagar))
            {

                MessageBox.Show("el monto de la tarjeta no puede superar el total de la venta");
                return;
            }



            // si se entro a pagar como vale, entonces el monto del vale no puede ser cero
            if (m_bVale && dPagoVale <= 0)
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



            decimal dCambio = dPagoTotal - m_dRestanteAPagar;


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

                if (!pagoD.DOCTO_PAGO_SP(pagoBE, m_dRestanteAPagar, dPagoEfectivo, dPagoTarjeta, dPagoCheque, dPagoCredito, dPagoVale, dPagoEfectivoRecibido, dCambioCheque, 0, 0, 0, CurrentUserID.CurrentUser.IID, 0, "", 0, "", 0, "", 0, 0, "", tarjetaFormaPagoSatId, 0 , 0, fTrans))
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
            decimal dPagoTarjeta = decimal.Parse(this.TBMontoTarjeta.NumericValue.ToString());
            //decimal dPagoCredito = decimal.Parse(this.TBMontoCredito.NumericValue.ToString());
            decimal dPagoCheque = decimal.Parse(this.TBMontoCheque.NumericValue.ToString());
            decimal dPagoVale = decimal.Parse(this.TBMontoVale.NumericValue.ToString());



            dPagoTotal = dPagoEfectivo + dPagoTarjeta /*+ dPagoCredito*/ + dPagoCheque + dPagoVale /*+ dPagoCreditoAutomatico + dPagoCreditoManual*/;


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
        private void WFPagosBasicoApartados_Load(object sender, EventArgs e)
        {
            if (this.m_bVale)
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

            CBTIPOTARJETA.SelectedIndex = 0;

        }

        private void WFPagosBasicoApartados_Shown(object sender, EventArgs e)
        {
            if (this.m_bVale)
            {
                this.TBMontoVale.Focus();
            }
            else
                this.PA_ABONOTextBox.Focus();
        }

        private void WFPagosBasicoApartados_KeyDown(object sender, KeyEventArgs e)
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


        private long AgregaPersonaApartado()
        {
            CPERSONAAPARTADOBE personaBE = new CPERSONAAPARTADOBE();
            CPERSONAAPARTADOD personaD = new CPERSONAAPARTADOD();


            if (this.NOMBRESTextBox.Text != "")
            {
                personaBE.INOMBRES = this.NOMBRESTextBox.Text.ToString();
            }

            if (this.DOMICILIOTextBox.Text != "")
            {
                personaBE.IDOMICILIO = this.DOMICILIOTextBox.Text.ToString();
            }

            if (this.CIUDADTextBox.Text != "")
            {
                personaBE.ICIUDAD = this.CIUDADTextBox.Text.ToString();
            }

            if (this.TELEFONO1TextBox.Text != "")
            {
                personaBE.ITELEFONO1 = this.TELEFONO1TextBox.Text.ToString();
            }

            if (this.CELULARTextBox.Text != "")
            {
                personaBE.ICELULAR = this.CELULARTextBox.Text.ToString();
            }

            if (this.EMAIL1TextBox.Text != "")
            {
                personaBE.IEMAIL1 = this.EMAIL1TextBox.Text.ToString();
            }

            CPERSONAAPARTADOD personaApartadoD = new CPERSONAAPARTADOD();
            personaBE = personaApartadoD.AgregarPERSONAAPARTADOD(personaBE, null);

            if (personaBE == null)
            {
                return 0;
            }
            else
            {
                return personaBE.IID;
            }

        }


        private bool ConvierteApartadoSiAplica(FbTransaction fTrans)
        {

            if(m_personaApartadoId == 0)
            {


                m_personaApartadoId = AgregaPersonaApartado();
                if (m_personaApartadoId == 0)
                {
                    return false;
                }
                
            }

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

        private void BTSeleccionar_Click(object sender, EventArgs e)
        {
            iPos.Catalogos.WFClientesApartado look = new iPos.Catalogos.WFClientesApartado();
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            CPERSONAAPARTADOD personaApartadoD = new CPERSONAAPARTADOD();
             CPERSONAAPARTADOBE personaApartadoBE = new CPERSONAAPARTADOBE();

             if (dr != null)
             {
                 pnlEdicionCliente.Enabled = false;

                 m_personaApartadoId = (long)dr["ID"];
                 personaApartadoBE.IID = m_personaApartadoId;

                 personaApartadoBE = personaApartadoD.seleccionarPERSONAAPARTADO(personaApartadoBE, null);

                 if (!(bool)personaApartadoBE.isnull["INOMBRES"])
                 {
                     this.NOMBRESTextBox.Text = personaApartadoBE.INOMBRES.ToString();
                 }
                 else
                 {
                     this.NOMBRESTextBox.Text = "";
                 }


                 if (!(bool)personaApartadoBE.isnull["IDOMICILIO"])
                 {
                     this.DOMICILIOTextBox.Text = personaApartadoBE.IDOMICILIO.ToString();
                 }
                 else
                 {
                     this.DOMICILIOTextBox.Text = "";
                 }

                 if (!(bool)personaApartadoBE.isnull["ICIUDAD"])
                 {
                     this.CIUDADTextBox.Text = personaApartadoBE.ICIUDAD.ToString();
                 }
                 else
                 {
                     this.CIUDADTextBox.Text = "";
                 }


                 if (!(bool)personaApartadoBE.isnull["ITELEFONO1"])
                 {
                     this.TELEFONO1TextBox.Text = personaApartadoBE.ITELEFONO1.ToString();
                 }
                 else
                 {
                     this.TELEFONO1TextBox.Text = "";
                 }

                 if (!(bool)personaApartadoBE.isnull["ICELULAR"])
                 {
                     this.CELULARTextBox.Text = personaApartadoBE.ICELULAR.ToString();
                 }
                 else
                 {
                     this.CELULARTextBox.Text = "";
                 }

                 if (!(bool)personaApartadoBE.isnull["IEMAIL1"])
                 {
                     this.EMAIL1TextBox.Text = personaApartadoBE.IEMAIL1.ToString();
                 }
                 else
                 {
                     this.EMAIL1TextBox.Text = "";
                 }




             }
        }

        private void BTNNuevo_Click(object sender, EventArgs e)
        {
            this.pnlEdicionCliente.Enabled = true;
                     this.NOMBRESTextBox.Text = "";
                     this.DOMICILIOTextBox.Text = "";
                     this.CIUDADTextBox.Text = "";
                     this.TELEFONO1TextBox.Text = "";
                     this.CELULARTextBox.Text = "";
                     this.EMAIL1TextBox.Text = "";
                     this.m_personaApartadoId = 0;

        }

       
    }
}
