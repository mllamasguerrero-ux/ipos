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
using System.Diagnostics;
using DataLayer.Importaciones;
using System.Collections;
using iPos.Abonos;

namespace iPos
{
    public partial class WFAbonos : IposForm
    {
        CDOCTOBE m_Docto;
        long m_ClienteId;
        tipoTransaccionV m_tipoTransaccion;
        //long m_pagoId = 0;
        CDOCTOPAGOBE m_doctoPago;

        private string m_strFileLog = "";

        private bool m_pagoConPinpadHabilitado = false;
        private bool m_obviarPagoConPinpadHabilitado = false;
        private bool m_tieneDerechoCondonarComision = false;
        private bool m_pagoConVerifoneHabilitado = false;

        private decimal m_montoAplicar = 0.0m;
        private decimal m_montoComision = 0.0m;
        private decimal m_montoTotal = 0.0m;

        CDOCTOBE m_DoctoCompra;

        CPERSONABE m_personaBE = null;

        private int m_intentosPagoTarjetaConPinPad = 0;
        private bool tieneCuentaPago = false;

        public WFAbonos()
        {
            InitializeComponent();
            m_tipoTransaccion = tipoTransaccionV.t_venta;
            m_doctoPago = new CDOCTOPAGOBE();
        }


        public WFAbonos(tipoTransaccionV tipoTransaccion)
            : this()
        {
            m_tipoTransaccion = tipoTransaccion;
        }

        private void WFAbonos_Load(object sender, EventArgs e)
        {

            if (!ChecarCorteActivo())
                return;

            ChecarPermisosParaCambiarFechas();

            this.ComboBanco.llenarDatos();
            this.ComboBanco.SelectedIndex = -1;

            this.CUENTABANCOEMPRESAIDComboBox.llenarDatos();
            this.CUENTABANCOEMPRESAIDComboBox.SelectedIndex = -1;

            m_Docto = new CDOCTOBE();
            m_ClienteId = 1;

            switch (m_tipoTransaccion)
            {
                case tipoTransaccionV.t_compra:
                    {
                        lblTitulo.Text = "Abonos de compras";
                        lblPersona.Text = "Proveedor";
                    }
                    break;
                case tipoTransaccionV.t_compraSucursal:
                    {
                        lblTitulo.Text = "Abonos de compras de sucursales";
                        lblPersona.Text = "Proveedor";
                    }
                    break;
                default:
                        lblTitulo.Text = "Abonos de ventas";  
                        lblPersona.Text = "Cliente";
                    break;

            }


            ChecarPinPadHabilitado();

            ponerTieneDerechoCondonar();

            visibilizaCamposDeComision();

            formatearPanelCompraRelacionada();

            if(CurrentUserID.CurrentParameters.IVERSIONCFDI != "3.3" && CurrentUserID.CurrentParameters.IVERSIONCFDI != "4.0")
            {
                lblCuentaRecep.Visible = false;
                CUENTABANCOEMPRESAIDComboBox.Visible = false;
                lblFechaAplicado.Visible = false;
                DTPFechaAplicado.Visible = false;
                CBAplicado.Visible = false;
            }

        }


        private void ponerTieneDerechoCondonar()
        {
             CUSUARIOSD usuariosD = new CUSUARIOSD();
             m_tieneDerechoCondonarComision = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_CONDONARCOMISION_TARJETA, null);
        }

        private void ChecarPinPadHabilitado()
        {
             CUSUARIOSD usuariosD = new CUSUARIOSD();
            //agregar tambien a la validacion el parametro en parametro
             if (CurrentUserID.CurrentParameters.IBANCOMERHABPINPAD != null && CurrentUserID.CurrentParameters.IBANCOMERHABPINPAD == "S" &&
                 (usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_PAGO_TERMINAL_BANCOMER, null)))
            {
                m_pagoConPinpadHabilitado = true;
            }

            m_pagoConVerifoneHabilitado = iPos.CurrentUserID.CurrentVerifoneCajaConfig.IACTIVO == "S" &&
                usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_PAGO_TERMINAL_VERIFONE, null);

            this.btnReinicializaVerifone.Visible = m_pagoConVerifoneHabilitado;

            if (CurrentUserID.CurrentParameters.IBANCOMERHABPINPAD != null && CurrentUserID.CurrentParameters.IBANCOMERHABPINPAD == "S" &&
               (usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_OBVIAR_PAGO_TERMINAL_BANCOMER, null)))
            {
                m_obviarPagoConPinpadHabilitado = true;
            }



        }

        private void ChecarPermisosParaCambiarFechas()
        {
            CUSUARIOSD usuariosD = new CUSUARIOSD();
            if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_ABONOSCAMBIARFECHAELABORACION, null))
            {
                DTPFechaElaboracion.Enabled = false;
                DTPFechaRecepcion.Enabled = false;
            }
        }

        private void SeleccionarTransaccion()
        {
            m_doctoPago = new CDOCTOPAGOBE();

            int tipoDoctoParaLista = getTipoDoctoIdPorTipoTransaccion();

            // int tipoDoctoParaLista = (m_tipoTransaccion == tipoTransaccionV.t_compra) ? 11 : 0;

            /*WFAbonoListaTransacciones look = new WFAbonoListaTransacciones((int)DBValues._DOCTO_ESTATUS_COMPLETO, tipoDoctoParaLista);
            look.ShowDialog();*/
            WFSaldosListaTransacciones look = new WFSaldosListaTransacciones((int)DBValues._DOCTO_ESTATUS_COMPLETO, tipoDoctoParaLista);
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                m_Docto.IID = int.Parse(dr[0].ToString());
                CDOCTOD vData = new CDOCTOD();
                m_Docto = vData.seleccionarDOCTO(m_Docto, null);
                m_ClienteId = m_Docto.IPERSONAID;
                llenarDatosPersona();
                llenarDatosTransaccion(false);
                LlenarGridAbono();
                


                this.TBTransacccion.Text = m_Docto.IFOLIO.ToString("N0");


                this.pnlAbono.Enabled = true;
                this.BTGuardar.Enabled = true;
                this.BTNuevo.Enabled = true;

                this.PA_ABONOTextBox.Focus();

                visibilizaCamposDeComision();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SeleccionarTransaccion();
        }


        public void llenarDatosPersonaApartado()
        {
            CPERSONAAPARTADOD personaD = new CPERSONAAPARTADOD();
            CPERSONAAPARTADOBE personaBE = new CPERSONAAPARTADOBE();
            personaBE.IID = m_Docto.IPERSONAAPARTADOID;
            personaBE = personaD.seleccionarPERSONAAPARTADO(personaBE, null);
            if (personaBE != null)
            {

                lbClieCiudad.Text = ((bool)personaBE.isnull["ICIUDAD"]) ? "" : personaBE.ICIUDAD;
                lbClieColonia.Text = ((bool)personaBE.isnull["ICOLONIA"]) ? "" : personaBE.ICOLONIA;
                lbClieCP.Text = ((bool)personaBE.isnull["ICODIGOPOSTAL"]) ? "" : personaBE.ICODIGOPOSTAL;
                lbClieDom.Text = ((bool)personaBE.isnull["IDOMICILIO"]) ? "" : personaBE.IDOMICILIO;
                lbClieEstado.Text = ((bool)personaBE.isnull["IESTADO"]) ? "" : personaBE.IESTADO;
                lbClieNombre.Text = ((bool)personaBE.isnull["INOMBRES"]) ? "" : personaBE.INOMBRES;
                //lbClieRFC.Text = ((bool)personaBE.isnull["IRFC"]) ? "" : personaBE.IRFC;
                lbClieTel.Text = ((bool)personaBE.isnull["ITELEFONO1"]) ? "" : personaBE.ITELEFONO1;


            }
        }


        public void llenarDatosPersona()
        {
            m_personaBE = null;

            limpiarDatosPersona();

            if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTAAPARTADO)
            {
                llenarDatosPersonaApartado();
                return;
            }

            if (m_tipoTransaccion == tipoTransaccionV.t_venta)
            {
                tieneCuentaPago = clienteTieneCuentas();
                btnCuentaPago.Visible = tieneCuentaPago;
            }
            else
            {
                tieneCuentaPago = false;
                btnCuentaPago.Visible = false;
            }


            CPERSONAD personaD = new CPERSONAD();
            CPERSONABE personaBE = new CPERSONABE();
            personaBE.IID = m_ClienteId;
            personaBE = personaD.seleccionarPERSONA(personaBE, null);
            if (personaBE != null)
            {

                lbClieCiudad.Text = ((bool)personaBE.isnull["ICIUDAD"]) ? "" : personaBE.ICIUDAD;
                lbClieColonia.Text = ((bool)personaBE.isnull["ICOLONIA"]) ? "" : personaBE.ICOLONIA;
                lbClieCP.Text = ((bool)personaBE.isnull["ICODIGOPOSTAL"]) ? "" : personaBE.ICODIGOPOSTAL;
                lbClieDom.Text = ((bool)personaBE.isnull["IDOMICILIO"]) ? "" : personaBE.IDOMICILIO;
                lbClieEstado.Text = ((bool)personaBE.isnull["IESTADO"]) ? "" : personaBE.IESTADO;
                lbClieNombre.Text = ((bool)personaBE.isnull["INOMBRE"]) ? "" : personaBE.INOMBRE;
                lbClieRFC.Text = ((bool)personaBE.isnull["IRFC"]) ? "" : personaBE.IRFC;
                lbClieTel.Text = ((bool)personaBE.isnull["ITELEFONO1"]) ? "" : personaBE.ITELEFONO1;

                LBCliente.Text = personaBE.ICLAVE;

                TBCuentaPago.Text = ((bool)personaBE.isnull["ICREDITOREFERENCIAABONOS"]) ? "" : personaBE.ICREDITOREFERENCIAABONOS;
               

                m_personaBE = personaBE;


                formatearPanelCompraRelacionada();
            }

        }



        public void limpiarDatosPersona()
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

        public void limpiarDatosTransaccion()
        {

            this.lblFolio.Text = "";
            this.lblFecha.Text = "";
            this.lblTotal.Text = "";
            this.lblSaldo.Text = "";
            this.lblFolioFacturado.Text = "";
            this.lblAbonosNoAplicados.Text = "";
            this.lblSaldoMenosNoAplicados.Text = "";

        }

        public void llenarDatosTransaccion(bool bGetfromdb)
        {
            limpiarDatosTransaccion();
            if (bGetfromdb)
            {
                CDOCTOD vData = new CDOCTOD();
                m_Docto = vData.seleccionarDOCTO(m_Docto, null);
            }

            decimal saldo = 0, abonosNoAplicados = 0;

            if (!(bool)m_Docto.isnull["IID"])
            {
                if (!(bool)m_Docto.isnull["IFOLIO"])
                {
                    this.lblFolio.Text = m_Docto.IFOLIO.ToString();
                }
                if (!(bool)m_Docto.isnull["IFECHA"])
                {
                    this.lblFecha.Text = m_Docto.IFECHA.ToString("dd/MM/yyyy");
                }
                if (!(bool)m_Docto.isnull["ITOTAL"])
                {
                    this.lblTotal.Text = m_Docto.ITOTAL.ToString("N2");
                }
                if (!(bool)m_Docto.isnull["ISALDO"])
                {
                    this.lblSaldo.Text = m_Docto.ISALDO.ToString();
                    saldo = m_Docto.ISALDO;
                }
                if (!(bool)m_Docto.isnull["IFOLIOORIGENFACTURADO"])
                {
                    this.lblFolioFacturado.Text = m_Docto.IFOLIOORIGENFACTURADO.ToString();
                }

                if (!(bool)m_Docto.isnull["IABONONOAPLICADO"])
                {
                    this.lblAbonosNoAplicados.Text = m_Docto.IABONONOAPLICADO.ToString();
                    abonosNoAplicados = m_Docto.IABONONOAPLICADO;
                }

                
                this.lblSaldoMenosNoAplicados.Text = (saldo -  abonosNoAplicados).ToString();


            }

        }

        private void LlenarGridAbono()
        {
            try
            {
                this.gET_LISTA_ABONOS_DOCTOTableAdapter.Fill(this.dSPuntoDeVentaAux.GET_LISTA_ABONOS_DOCTO, this.m_Docto.IID);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void GridFocusLastRow()
        {

            try
            {
                if (gET_LISTA_ABONOS_DOCTODataGridView.Rows.Count > 0)
                {
                    gET_LISTA_ABONOS_DOCTODataGridView.CurrentCell = gET_LISTA_ABONOS_DOCTODataGridView[1, gET_LISTA_ABONOS_DOCTODataGridView.Rows.Count - 1];
                }
            }
            catch
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void BTGuardar_Click(object sender, EventArgs e)
        {
            if (m_doctoPago == null)
            {
                if (GuardarPago())
                {

                    LimpiarManteniendoDocto();
                    LlenarGridAbono();
                    llenarDatosPersona();
                    llenarDatosTransaccion(true);
                    GridFocusLastRow();

                    /*if(m_Docto != null && m_Docto.ISALDO == 0)
                    {
                        TBTransacccion.Focus();
                        TBTransacccion.Text = "";
                    }*/
                }
            }
            else if (!(bool)m_doctoPago.isnull["IID"])
            {
                if (EditarPago())
                {
                    LimpiarManteniendoDocto();
                    LlenarGridAbono();
                    llenarDatosPersona();
                    llenarDatosTransaccion(true);
                    GridFocusLastRow();

                }

            }
            else
            {
                if (GuardarPago())
                {
                    LimpiarManteniendoDocto();
                    LlenarGridAbono();
                    llenarDatosPersona();
                    llenarDatosTransaccion(true);
                    GridFocusLastRow();

                    if (m_Docto != null && m_Docto.ISALDO == 0)
                    {
                        TBTransacccion.Focus();
                        TBTransacccion.Text = "";
                    }
                }
            }

        }

        private bool EditarPago()
        {
            bool retorno = false;
            if (MessageBox.Show("Esto revertira el pago anterior y agregara el nuevo pago modificado. Esta seguro de que desea hacerlo ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return retorno;
            }

            if (RevertirPago(false))
                if (GuardarPago())
                    retorno = true;

            return retorno;

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


        
        private bool validarCuentasPago(long formaPagoSatId, string cuentaOrdenante, long cuentaBancoId, ref string mensaje)
        {
            if (cuentaOrdenante == null || cuentaOrdenante.Trim().Length == 0 || cuentaBancoId == 0)
                return true;

            CFORMAPAGOSATBE formaPagoSatBE = new CFORMAPAGOSATBE();
            CFORMAPAGOSATD formaPagoSatD = new CFORMAPAGOSATD();
            formaPagoSatBE.IID = formaPagoSatId;
            formaPagoSatBE = formaPagoSatD.seleccionarFORMAPAGOSAT(formaPagoSatBE, null);

            CCUENTABANCOBE cuentaBancoBE = new CCUENTABANCOBE();
            CCUENTABANCOD cuentaBancoD = new CCUENTABANCOD();
            cuentaBancoBE.IID = cuentaBancoId;
            cuentaBancoBE = cuentaBancoD.seleccionarCUENTABANCO(cuentaBancoBE, null);

            

            mensaje = "";

            bool ordenanteValida = true;
            bool beneficiariaValida = true;

            if (formaPagoSatBE == null)
                return true;

            if ( formaPagoSatBE.ISAT_PATRONORDENANTE != null && cuentaOrdenante != null &&
                 formaPagoSatBE.ISAT_PATRONORDENANTE.Trim().Length > 0 && !formaPagoSatBE.ISAT_PATRONORDENANTE.Trim().ToUpper().Equals("NO") &&
                 !formaPagoSatBE.ISAT_PATRONORDENANTE.Trim().ToUpper().Equals("OPCIONAL"))
            {
                if (!iPosReporting.VirtualXml.VirtualXmlHelper.MatchPatronFormaPago(cuentaOrdenante, formaPagoSatBE.ISAT_PATRONORDENANTE, false))
                {
                    ordenanteValida = false;
                    mensaje += "La cuenta ordenante es invalida, favor de seguir el patron " + formaPagoSatBE.ISAT_PATRONORDENANTE;
                }
            }

            if (   cuentaBancoBE != null && formaPagoSatBE.ISAT_PATRONBENEFICIARIO != null && cuentaBancoBE.INOCUENTA != null &&
                 formaPagoSatBE.ISAT_PATRONBENEFICIARIO.Trim().Length > 0 && !formaPagoSatBE.ISAT_PATRONBENEFICIARIO.Trim().ToUpper().Equals("NO") &&
                 !formaPagoSatBE.ISAT_PATRONBENEFICIARIO.Trim().ToUpper().Equals("OPCIONAL"))
            {
                if (!iPosReporting.VirtualXml.VirtualXmlHelper.MatchPatronFormaPago(cuentaBancoBE.INOCUENTA, formaPagoSatBE.ISAT_PATRONBENEFICIARIO, false))
                {
                    beneficiariaValida = false;
                    mensaje += "La cuenta beneficiaria (del banco seleccionado) es invalida, favor de seguir el patron " + formaPagoSatBE.ISAT_PATRONBENEFICIARIO;
                }
            }

            return beneficiariaValida && ordenanteValida;

        }



        private void FormaPagoSeleccionada(out long formaPagoSeleccionada, out long formaPagoSatSeleccionada )
        {

            switch (FormaPagoComboBox.SelectedIndex)
            {

                case 0: formaPagoSeleccionada = DBValues._FORMA_PAGO_EFECTIVO; formaPagoSatSeleccionada = DBValues._FORMA_PAGOSAT_EFECTIVO; break;
                case 1: formaPagoSeleccionada = DBValues._FORMA_PAGO_TARJETA; formaPagoSatSeleccionada = DBValues._FORMA_PAGOSAT_TARJETACREDITO; break;
                case 2: formaPagoSeleccionada = DBValues._FORMA_PAGO_TARJETA; formaPagoSatSeleccionada = DBValues._FORMA_PAGOSAT_TARJETADEBITO; break;
                case 3: formaPagoSeleccionada = DBValues._FORMA_PAGO_TARJETA; formaPagoSatSeleccionada = DBValues._FORMA_PAGOSAT_TARJETASERVICIO; break;
                case 4: formaPagoSeleccionada = DBValues._FORMA_PAGO_CHEQUE; formaPagoSatSeleccionada = DBValues._FORMA_PAGOSAT_CHEQUE; break;
                case 5: formaPagoSeleccionada = DBValues._FORMA_PAGO_VALE; formaPagoSatSeleccionada = DBValues._FORMA_PAGOSAT_VALE; break;
                case 6: formaPagoSeleccionada = DBValues._FORMA_PAGO_TRANSFERENCIA; formaPagoSatSeleccionada = DBValues._FORMA_PAGOSAT_TRANSFERENCIA; break;
                case 7: formaPagoSeleccionada = DBValues._FORMA_PAGO_INTERCAMBIOMERCANCIACREDITO; formaPagoSatSeleccionada = DBValues._FORMA_PAGOSAT_COMPENSACION; break;
                case 8: formaPagoSeleccionada = DBValues._FORMA_PAGO_NOIDENTIFICADO; formaPagoSatSeleccionada = DBValues._FORMA_PAGOSAT_OTRO; break;
                case 9: formaPagoSeleccionada = DBValues._FORMA_PAGO_DEPOSITO; formaPagoSatSeleccionada = DBValues._FORMA_PAGOSAT_EFECTIVO; break;
                case 10: formaPagoSeleccionada = DBValues._FORMA_PAGO_DEPOSITOTERCERO; formaPagoSatSeleccionada = DBValues._FORMA_PAGOSAT_EFECTIVO; break;
                default: formaPagoSeleccionada = DBValues._FORMA_PAGO_EFECTIVO; formaPagoSatSeleccionada = DBValues._FORMA_PAGOSAT_EFECTIVO; break;
            }
        }
       

        private bool GuardarPago()
        {
            bool retorno = false;
            bool messageEntregarMercancia = false;
            bool messageRecibirMercancia = false;

            //decimal monto = decimal.Parse(PA_ABONOTextBox.NumericValue.ToString());
            
            CalcularMontosXCaptura();

            if (m_montoAplicar <= 0)
            {
                MessageBox.Show("El abono no puede ser igual o menor que cero");
            }
            if (m_Docto.ISALDO - m_Docto.IABONONOAPLICADO < m_montoAplicar)
            {
                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTAAPARTADO)
                {

                    MessageBox.Show("No se puede pagar de mas en la ventas de apartado");
                    return false;
                }
                else
                {
                    if (MessageBox.Show("Su pago superara el saldo actual de la transaccion. El excedente se podra utilizar para otra transaccion. Seguro que quiere realizar el abono de esta manera? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                        return false;
                }
            }


            if (FormaPagoComboBox.SelectedIndex < 0 || m_montoAplicar <= 0)
                return false;



            long bancomerParamId = 0;

            long verifonePaymentId = 0;

            bool aplicarPagoConTarjetaSinPinPadDirecto = true;

            bool reimprimirPagosVerifone = false;
            CVERIFONEPAYMENTBE verifonePaymentBE = null;





            //checar si la forma de pago es tarjeta y esta habilitado el pinpad
            if (
                (m_pagoConPinpadHabilitado || m_pagoConVerifoneHabilitado) && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA &&
                (FormaPagoComboBox.SelectedIndex == 1 || FormaPagoComboBox.SelectedIndex == 2 || FormaPagoComboBox.SelectedIndex == 3)

                )
            {

                aplicarPagoConTarjetaSinPinPadDirecto = false;

                //si lleva varios intentos fallidos darle la opcion de solo registrar el pago sin pasar por el pinpad ( si tiene el derecho )
                if (m_intentosPagoTarjetaConPinPad >= 2)
                {
                    if (m_obviarPagoConPinpadHabilitado)
                    {
                        if (MessageBox.Show("Ya ha hecho 2 intentos o mas por usar la pinpad , desea usar la terminal alternativa y solo asignar la referencia bancaria?", "Intentos fallidos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            aplicarPagoConTarjetaSinPinPadDirecto = true;
                        }
                    }
                }

                if (!aplicarPagoConTarjetaSinPinPadDirecto)
                {

                    if (m_pagoConPinpadHabilitado)
                    {

                        if (!PagoBancomerHelper.Pagar(ref this.m_Docto, m_montoTotal, ref bancomerParamId, null))
                        {
                            m_intentosPagoTarjetaConPinPad++;
                            MessageBox.Show("Error al procesar el pago en el pinpad" + PagoBancomerHelper.strResTransaccion);
                            return false;
                        }



                        CBANCOMERPARAMBE bancomerParamBE = ObtenerPagoPorTarjetaPinPad(bancomerParamId);
                        CBANCOSBE bancoBE = ObtenerBancoDesdeClave("BANCOMER");


                        //referencia
                        TBReferencia.Text = bancomerParamBE.IREFERENCIAAFIN;

                        //tipo credito debito
                        if (bancomerParamBE.ICREDITODEBITO != null && bancomerParamBE.ICREDITODEBITO == "Debito")
                        {
                            FormaPagoComboBox.SelectedIndex = 2;
                        }
                        else
                        {
                            FormaPagoComboBox.SelectedIndex = 1;
                        }

                        //banco
                        //cuando se implemente lo de averiguar banco que se seleccione el banco


                        PagoBancomerHelper.ImprimirVoucher(bancomerParamId, true, true);
                    }
                    else if (m_pagoConVerifoneHabilitado)
                    {
                        string strResTransaccionTarjeta = "";

                        if (!PagoVerifoneHelper.Pagar(ref this.m_Docto, m_montoTotal, ref verifonePaymentId, ref strResTransaccionTarjeta, ref reimprimirPagosVerifone, null))
                        {
                            m_intentosPagoTarjetaConPinPad++;
                            MessageBox.Show(strResTransaccionTarjeta) ;
                            return false;
                        }


                        verifonePaymentBE = this.ObtenerVerifonePagoPorTarjetaPinPad(verifonePaymentId);

                        //asignar banco
                        CBANCOSBE bancoBE = ObtenerBancoDesdeClave("HSBC");
                        if (this.ComboBanco.SelectedIndex < 0)
                        {
                            if (bancoBE != null)
                                this.ComboBanco.SelectedDataValue = bancoBE.IID;
                            else
                                this.ComboBanco.SelectedIndex = 0;
                        }

                        //referencia
                        TBReferencia.Text = verifonePaymentBE.IOPERACION;

                        //tipo credito debito
                        if (verifonePaymentBE.ICARDTYPE != null && verifonePaymentBE.ICARDTYPE == "DEBIT")
                        {
                            FormaPagoComboBox.SelectedIndex = 2;
                        }
                        else
                        {
                            FormaPagoComboBox.SelectedIndex = 1;
                        }


                    }

                }

            }
           

            if(aplicarPagoConTarjetaSinPinPadDirecto)
            {

                if ((FormaPagoComboBox.SelectedIndex == 1 || FormaPagoComboBox.SelectedIndex == 2 || FormaPagoComboBox.SelectedIndex == 3 || FormaPagoComboBox.SelectedIndex == 4 || FormaPagoComboBox.SelectedIndex == 6)
                     && (this.TBReferencia.Text.Trim().Length == 0 || this.ComboBanco.SelectedIndex < 0))
                {
                    MessageBox.Show("Debe seleccionar el banco y la referencia si esta pagando con tarjeta , cheque o transferencia");
                    return false;
                }
            }


            long formaPagoSeleccionada = 0;
            long formaPagoSatSeleccionada = 0;
            FormaPagoSeleccionada(out formaPagoSeleccionada, out formaPagoSatSeleccionada);


            if (FormaPagoComboBox.SelectedIndex > 0 && FormaPagoComboBox.SelectedIndex != 7 && m_tipoTransaccion == tipoTransaccionV.t_venta)
            {

                if (!ValidaListaDePagosConMismaReferencia(this.TBReferencia.Text, int.Parse(this.ComboBanco.SelectedValue.ToString()), m_montoTotal,formaPagoSeleccionada))
                {

                    MessageBox.Show("Hubo problemas por duplicidad de referencias bancarias");
                    return false;
                }
            }


            CDOCTOPAGOBE pagoBE;
            CDOCTOPAGOD pagoD = new CDOCTOPAGOD();

            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            try
            {

                pagoBE = new CDOCTOPAGOBE();
                pagoBE.IDOCTOID = m_Docto.IID;
                pagoBE.IFECHA = DateTime.Now;
                pagoBE.IFECHAHORA = DateTime.Now;
                pagoBE.ICORTEID = CurrentUserID.CurrentUser.ICORTEID;
                if(this.ComboBanco.SelectedIndex >= 0)
                    pagoBE.IBANCO = long.Parse(this.ComboBanco.SelectedValue.ToString());
                pagoBE.IREFERENCIABANCARIA = this.TBReferencia.Text;
                pagoBE.IIMPORTE = m_montoAplicar;
                pagoBE.INOTAS = TBNotas.Text;

                pagoBE.IIMPORTERECIBIDO = m_montoTotal;

                pagoBE.IFECHAELABORACION = DTPFechaElaboracion.Value;
                pagoBE.IFECHARECEPCION = DTPFechaRecepcion.Value;
                pagoBE.IFECHAAPLICADO = DTPFechaAplicado.Value;

                if ((CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("3.3") || CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0")) && this.CUENTABANCOEMPRESAIDComboBox.SelectedIndex >= 0)
                    pagoBE.ICUENTABANCOEMPRESAID = long.Parse(this.CUENTABANCOEMPRESAIDComboBox.SelectedValue.ToString());

                pagoBE.ICOMISION = m_montoComision;

                if (CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("3.3") || CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0"))
                {
                    pagoBE.IAPLICADO = CBAplicado.Checked ? "S" : "N";
                    //pagoBE.IFECHAAPLICADO = DTPFechaAplicado.Value;

                    
                }

                pagoBE.IFORMAPAGOID = formaPagoSeleccionada;
                pagoBE.IFORMAPAGOSATID = formaPagoSatSeleccionada;

                
                


                switch (this.m_tipoTransaccion)
                {
                    case tipoTransaccionV.t_venta:

                        pagoBE.IDOCTOID = m_Docto.IID;
                        pagoBE.ITIPOPAGOID = DBValues._TIPOPAGO_ENTRADA;
                        break;
                   
                    case tipoTransaccionV.t_ventaapartado:

                        pagoBE.IDOCTOID = m_Docto.IID;
                        pagoBE.ITIPOPAGOID = DBValues._TIPOPAGO_ENTRADA;
                        break;
                   

                    case tipoTransaccionV.t_compra:
                    case tipoTransaccionV.t_compraSucursal:

                        pagoBE.IDOCTOSALIDAID = m_Docto.IID;
                        pagoBE.ITIPOPAGOID = DBValues._TIPOPAGO_SALIDA;
                        break;



                }

                pagoBE.IESAPARTADO = (this.m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTAAPARTADO) ? "S": "N";
                pagoBE.IESPAGOINICIAL = DBValues._DB_BOOLVALUE_NO;

                pagoBE.ITIPOABONOID = DBValues._TIPO_ABONO_ABONO;

                pagoBE.IBANCOMERPARAMID = bancomerParamId;

                pagoBE.IVERIFONEPAYMENTID = verifonePaymentId;

                if (pagoBE.IFORMAPAGOID == DBValues._FORMA_PAGO_INTERCAMBIOMERCANCIACREDITO)
                {
                    if(m_DoctoCompra == null || m_DoctoCompra.IID == 0)
                    {
                        //fTrans.Rollback();
                        MessageBox.Show("No ha seleccionado la compra correspondiente para aplicar el saldo");
                        throw new Exception();
                    }

                    if (m_DoctoCompra.ISALDO < pagoBE.IIMPORTE)
                    {

                        //fTrans.Rollback();
                        MessageBox.Show("No hay saldo suficiente para hacer la aplicacion del saldo");
                        throw new Exception();
                    }

                    pagoBE.IDOCTOSALIDAID = m_DoctoCompra.IID;
                }




                if (CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("3.3") || CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0"))
                {
                    string mensajeValidacionCuentas = "";
                    if (!validarCuentasPago(pagoBE.IFORMAPAGOSATID, TBCuentaPago.Text, pagoBE.ICUENTABANCOEMPRESAID, ref mensajeValidacionCuentas))
                    {
                        if (MessageBox.Show("Al validar las cuentas para timbrado parece que hay posibles problemas \n" + mensajeValidacionCuentas + "\n Desea continuar con el pago ? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            throw new Exception();
                        }
                    }
                }



                fConn.Open();
                fTrans = fConn.BeginTransaction();

                pagoBE = pagoD.InsertarDOCTOPAGOD(pagoBE, fTrans);
                if (pagoBE == null)
                {
                    fTrans.Rollback();
                    MessageBox.Show(pagoD.IComentario);
                    throw new Exception();
                }
                m_doctoPago = pagoBE;

                if (TBCuentaPago.Text != "" && m_doctoPago.IFORMAPAGOID != DBValues._FORMA_PAGO_EFECTIVO)
                {
                    m_doctoPago.ICUENTAPAGOCREDITO = TBCuentaPago.Text;
                    if(!pagoD.CambiarCUENTAPAGOCREDITO_DOCTOPAGOD(m_doctoPago, m_doctoPago, fTrans))
                    {

                        fTrans.Rollback();
                        MessageBox.Show("Error al actualizar la cuenta pago " + pagoD.IComentario);
                        throw new Exception();
                    }
                }


                if (TBRefInterno.Text != "" && m_doctoPago.IFORMAPAGOID != DBValues._FORMA_PAGO_EFECTIVO)
                {
                    m_doctoPago.IREFINTERNO = TBRefInterno.Text;
                    if (!pagoD.CambiarREFINTERNO_DOCTOPAGOD(m_doctoPago, m_doctoPago, fTrans))
                    {

                        fTrans.Rollback();
                        MessageBox.Show("Error al actualizar la referencia interna " + pagoD.IComentario);
                        throw new Exception();
                    }
                }

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



                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTAAPARTADO)
                {
                    CDOCTOBE doctoBuffer = new CDOCTOBE();
                    CDOCTOD doctoD = new CDOCTOD();
                    CPuntoDeVentaD pvd = new CPuntoDeVentaD();
                    doctoBuffer.IID = m_Docto.IID;
                    doctoBuffer = doctoD.seleccionarDOCTO(doctoBuffer, fTrans);
                    if (doctoBuffer != null)
                    {

                        if (!(bool)doctoBuffer.isnull["IID"] && doctoBuffer.ISALDO <= 0)
                        {
                            if (!pvd.VENTA_ENTREGARMERCANCIA(m_Docto, fTrans))
                            {

                                fTrans.Rollback();
                                MessageBox.Show(pagoD.IComentario);
                                throw new Exception();
                            }
                            else
                            {
                                messageEntregarMercancia = true;
                            }
                        }
                    }
                }


                

                this.ChecarReapartamiento(fTrans, ref messageRecibirMercancia);



                fTrans.Commit();
                fConn.Close();
                retorno = true;


                if(reimprimirPagosVerifone && verifonePaymentBE != null)
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


                int iNumTickets = CurrentUserID.CurrentParameters.INUMTICKETSABONO;

                if(iNumTickets <= 1)
                    iNumTickets = 1;

                for(int i = 0; i < iNumTickets; i++)
                {

                    ImprimirTicket();
                }
                //this.Close();


                bool bPreguntarReciboElectronico = (((CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("3.3") || CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0")) && !CBAplicado.Checked && pagoBE.IFORMAPAGOID == DBValues._FORMA_PAGO_CHEQUE) ) ? false : true;

                if (bPreguntarReciboElectronico)
                {
                    long doctoReciboId = 0;
                    string strComentarioRecibo = "";
                    if (!ProcesarReciboElectronicoSiAplica(this.m_doctoPago.IID, ref doctoReciboId, ref strComentarioRecibo))
                    {
                        MessageBox.Show(strComentarioRecibo);
                    }
                    else
                    {
                        //imprimirFacturaElectronicaPorId(doctoReciboId);
                    }
                }

                if (MessageBox.Show("Desea imprimir el recibo? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    imprimirRecibo(this.m_doctoPago.IID);
                }


                
                

            }
            catch
            {
                fConn.Close();
            }
            finally
            {
                fConn.Close();
            }

            if (messageEntregarMercancia)
            {
                MessageBox.Show("La mercancia apartada debe entregarse");
            }

            if (messageRecibirMercancia)
            {
                MessageBox.Show("La mercancia apartada debe regresarse");
            }

            return retorno;


        }


        private void ImprimirTicket()
        {

            WFImpresionAbono wf = new WFImpresionAbono(this.m_doctoPago, this.m_Docto);
            wf.ShowDialog();
            wf.Dispose();
            GC.SuppressFinalize(wf);
        }


        private bool ProcesarReciboElectronicoSiAplica(long pagoId, ref long doctoReciboId, ref string comentario)
        {

            if (m_Docto == null || m_Docto.IID == 0 ||
                m_Docto.ITIPODOCTOID != DBValues._DOCTO_TIPO_VENTA ||
                m_Docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_COMPLETO ||
                ((bool)m_Docto.isnull["IESFACTURAELECTRONICA"] || m_Docto.IESFACTURAELECTRONICA == null || !m_Docto.IESFACTURAELECTRONICA.Equals("S")))
                return true;


            CDOCTOPAGOBE doctoPagoBE = new CDOCTOPAGOBE();
            CDOCTOPAGOD doctoPagoD = new CDOCTOPAGOD();
            doctoPagoBE.IID = pagoId;
            doctoPagoBE = doctoPagoD.seleccionarDOCTOPAGO(doctoPagoBE, null);
            if(doctoPagoBE == null)
            {
                comentario = "El pago no existe";
                return false;
            }

            if(doctoPagoBE.IRECIBOELECTRONICOID > 0)
            {
                doctoReciboId = doctoPagoBE.IRECIBOELECTRONICOID;
                comentario = "El registro ya tiene un recibo electronico";
                return false;

            }

            if(doctoPagoBE.IIMPORTE <= 0 || (doctoPagoBE.IREVERTIDO != null && doctoPagoBE.IREVERTIDO.Equals("S")) )
            {
                return true;
            }
           




            CDOCTOD doctoD = new CDOCTOD();

            CPERSONAD personaD = new CPERSONAD();
            CPERSONABE personaBE = new CPERSONABE();
            personaBE.IID = m_ClienteId;
            personaBE = personaD.seleccionarPERSONA(personaBE, null);


            if (personaBE != null)
            {
                

                    if (MessageBox.Show("Desea registrar un recibo electronico de este abono ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return true;
                    }



                    if (doctoPagoBE.IFORMAPAGOID != DBValues._FORMA_PAGO_EFECTIVO &&  (doctoPagoBE.ICUENTAPAGOCREDITO == null || doctoPagoBE.ICUENTAPAGOCREDITO.Trim().Equals("")))
                    {

                        WFCuentaPago cuentaPago = new WFCuentaPago(personaBE.ICREDITOREFERENCIAABONOS);
                        cuentaPago.ShowDialog();

                        string strCuentaPago = cuentaPago.strCuentaPago.Trim();

                        cuentaPago.Dispose();
                        GC.SuppressFinalize(cuentaPago);

                        if (strCuentaPago.Length == 0)
                        {

                            comentario = "Debe escribir la cuenta de pago para poder hacer el recibo electronico";
                            return false;
                        }

                        doctoPagoBE.ICUENTAPAGOCREDITO = strCuentaPago;

                        if (!doctoPagoD.CambiarCUENTAPAGOCREDITO_DOCTOPAGOD(doctoPagoBE, doctoPagoBE, null))
                        {

                            MessageBox.Show("Error al actualizar la cuenta pago " + doctoPagoD.IComentario);
                            return false;
                        }
                }



                    if (CurrentUserID.CurrentParameters.IVERSIONCFDI != null && (CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("3.3") || CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0")))
                    {
                        return procesarReciboElectronico33(pagoId, ref doctoReciboId, ref comentario);
                    }
                    else
                    {
                        return procesarReciboElectronico(pagoId, ref doctoReciboId, ref comentario);
                    }



                
            }

            return true;
        }


        private bool procesarReciboElectronico(long pagoId, ref long doctoReciboId, ref string comentario)
        {

            CDOCTOD doctoD = new CDOCTOD();

            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            try
            {

                fConn.Open();
                fTrans = fConn.BeginTransaction();

                if (!doctoD.RECIBOELECTRONICO_GENERAR(pagoId, CurrentUserID.CurrentUser.IID, ref doctoReciboId, fTrans))
                {
                    fTrans.Rollback();
                    fConn.Close();
                    comentario = "Error al generar el recibo electronico " + doctoD.IComentario;
                    return false;
                }



                if (!generarFacturaElectronicaPorId(doctoReciboId, fTrans, ref comentario))
                {
                    doctoReciboId = 0;
                    fTrans.Rollback();
                    fConn.Close();
                    comentario = "No se pudo realizar la facturacion " + comentario;
                    if (m_strFileLog != null && m_strFileLog.Trim().Length > 0)
                    {
                        Process.Start("notepad.exe", m_strFileLog);
                    }

                    return false;

                }

                fTrans.Commit();
                fConn.Close();


                imprimirFacturaElectronicaPorId(doctoReciboId);

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

            return true;
        }




        private bool procesarReciboElectronico33(long pagoId, ref long doctoReciboId, ref string comentario)
        {

            CDOCTOD doctoD = new CDOCTOD();

            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            try
            {

                fConn.Open();
                fTrans = fConn.BeginTransaction();

                if (!doctoD.RECIBOELECTRONICO_GENERAR_33(pagoId, CurrentUserID.CurrentUser.IID, ref doctoReciboId, fTrans))
                {
                    fTrans.Rollback();
                    fConn.Close();
                    comentario = "Error al generar el recibo electronico " + doctoD.IComentario;
                    return false;
                }



                if (!generarFacturaElectronicaPorId(doctoReciboId, fTrans, ref comentario))
                {
                    doctoReciboId = 0;
                    fTrans.Rollback();
                    fConn.Close();

                    comentario = "No se pudo realizar la facturacion " + comentario;
                    if (m_strFileLog != null && m_strFileLog.Trim().Length > 0)
                    {
                        Process.Start("notepad.exe", m_strFileLog);
                    }

                    return false;

                }

                fTrans.Commit();
                fConn.Close();


                imprimirFacturaElectronicaPorId(doctoReciboId);

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

            return true;
        }




        private bool CancelarReciboElectronicoSiAplica(long pagoId, ref long doctoCancelacionReciboId, ref string comentario)
        {

            if (m_Docto == null || m_Docto.IID == 0 ||
                m_Docto.ITIPODOCTOID != DBValues._DOCTO_TIPO_VENTA ||
                m_Docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_COMPLETO ||
                ((bool)m_Docto.isnull["IESFACTURAELECTRONICA"] || m_Docto.IESFACTURAELECTRONICA == null || !m_Docto.IESFACTURAELECTRONICA.Equals("S")))
                return true;


            CDOCTOPAGOBE doctoPagoBE = new CDOCTOPAGOBE();
            CDOCTOPAGOD doctoPagoD = new CDOCTOPAGOD();
            doctoPagoBE.IID = pagoId;
            doctoPagoBE = doctoPagoD.seleccionarDOCTOPAGO(doctoPagoBE, null);
            if (doctoPagoBE == null)
            {
                comentario = "El pago no existe";
                return false;
            }

            if (doctoPagoBE.IRECIBOELECTRONICOID <= 0)
            {
                doctoCancelacionReciboId = 0;
                comentario = "El registro no tiene recibo electornico";
                return true;

            }

            if (doctoPagoBE.IIMPORTE <= 0 || (doctoPagoBE.IREVERTIDO != null && doctoPagoBE.IREVERTIDO.Equals("S")))
            {
                return true;
            }





            CDOCTOD doctoD = new CDOCTOD();

            CDOCTOBE doctoBE = new CDOCTOBE();
            doctoBE.IID = doctoPagoBE.IRECIBOELECTRONICOID;

            doctoBE = doctoD.seleccionarDOCTO(doctoBE, null);
            if(doctoBE == null)
            {

                comentario = "El registro no tiene recibo electronico";
                return true;
            }

            if(doctoBE.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_COMPLETO)
            {

                comentario = "El registro ya fue cancelado";
                return true;
            }




                    FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
                    FbTransaction fTrans = null;
                    try
                    {

                        fConn.Open();
                        fTrans = fConn.BeginTransaction();



                        if (!cancelarFacturaElectronicaPorId(doctoPagoBE.IRECIBOELECTRONICOID, fTrans, ref comentario))
                        {
                            doctoCancelacionReciboId = 0;
                            fTrans.Rollback();
                            fConn.Close();
                            comentario = "No se pudo realizar la facturacion " + comentario;
                            if (m_strFileLog != null && m_strFileLog.Trim().Length > 0)
                            {
                                Process.Start("notepad.exe", m_strFileLog);
                            }

                            return false;

                        }
                        else
                        {

                            if (!doctoD.RECIBOELECTRONICO_CANCELAR(pagoId, CurrentUserID.CurrentUser.IID, ref doctoCancelacionReciboId, fTrans))
                            {
                                fTrans.Rollback();
                                fConn.Close();
                                comentario = "Error al generar el recibo electronico " + doctoD.IComentario;
                                return false;
                            }
                        }





                        fTrans.Commit();
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


            return true;
        }

        private bool ActualizarDoctoPagoSAT(long pagoId, long doctoId, ref string comentario)
        {
            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE doctoBE = new CDOCTOBE();
            doctoBE.IID = doctoId;
            doctoBE.IDOCTOPAGOSAT = pagoId;
            if(!doctoD.CambiarDOCTOPAGOSAT(doctoBE, doctoBE, null))
            {
                comentario = doctoD.IComentario;
                return false;
            }
            return true;
        }


        private void gET_LISTA_ABONOS_DOCTODataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                if (gET_LISTA_ABONOS_DOCTODataGridView.Columns[e.ColumnIndex].Name == "DGEDITAR")
                {
                    long formaPagoId = long.Parse(gET_LISTA_ABONOS_DOCTODataGridView.Rows[e.RowIndex].Cells["DGFORMAPAGOID"].Value.ToString());
                    long abonoId = long.Parse(gET_LISTA_ABONOS_DOCTODataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());
                    long tipoAbonoId = long.Parse(gET_LISTA_ABONOS_DOCTODataGridView.Rows[e.RowIndex].Cells["DGTIPOABONOID"].Value.ToString());
                    string revertido = gET_LISTA_ABONOS_DOCTODataGridView.Rows[e.RowIndex].Cells["DGREVERTIDO"].Value.ToString();
                    if (formaPagoId != 1 && formaPagoId != 2 && formaPagoId != 3 && formaPagoId != 5 && formaPagoId != 15 && formaPagoId != 16 && formaPagoId != 17 && formaPagoId != 18 && formaPagoId != 19 && formaPagoId != DBValues._FORMA_PAGO_DEPOSITO)
                    {
                        MessageBox.Show("Por la forma de pago no se puede mostrar");
                        return;
                    }
                    if (tipoAbonoId == DBValues._TIPO_ABONO_REVERSION )
                    {
                        MessageBox.Show("Este registro fue la cancelacion de otro abono hecho. Por lo tanto no se puede editar ");
                        return;
                    }
                    if (revertido == "S")
                    {
                        MessageBox.Show("Este registro ya fue cancelado por otro abono. Por lo tanto no se puede editar ");
                        return;
                    }
                    

                    MostrarRegistro(abonoId);

                    bool bEsPagoCompuesto = EsPagoCompuesto(m_doctoPago.IPAGOID);
                        
                    this.BTEliminar.Enabled = !bEsPagoCompuesto;
                    this.BTRecibo.Enabled = true;
                    this.btnReciboElectronico.Enabled = !bEsPagoCompuesto;



                    
                }
                else if (
                    gET_LISTA_ABONOS_DOCTODataGridView.Columns[e.ColumnIndex].Name == "DGIMPRIMIRVOUCHER" & 
                    gET_LISTA_ABONOS_DOCTODataGridView.Rows[e.RowIndex].Cells["DGESCONPINPADBANCOMER"].Value.ToString() == "S")
                {
                    PagoBancomerHelper.ImprimirVoucher(long.Parse(gET_LISTA_ABONOS_DOCTODataGridView.Rows[e.RowIndex].Cells["DGBANCOMERPARAMID"].Value.ToString()),true, true);
                }
            }
        }

        private void MostrarRegistro(long abonoId)
        {


            m_doctoPago = new CDOCTOPAGOBE();
            CDOCTOPAGOD doctoPagoD = new CDOCTOPAGOD();
            m_doctoPago.IID = abonoId;

            m_doctoPago = doctoPagoD.seleccionarDOCTOPAGO(m_doctoPago, null);



            this.lblNumMovimiento.Text = abonoId.ToString();


            //this.PA_ABONOTextBox.Text = m_doctoPago.IIMPORTE.ToString("N2");
            CalcularYMostrarMontosXDoctoPago();

            switch (m_doctoPago.IFORMAPAGOSATID)
            {

                case DBValues._FORMA_PAGOSAT_EFECTIVO:
                    FormaPagoComboBox.SelectedIndex = 0;

                    if(m_doctoPago.IFORMAPAGOID == DBValues._FORMA_PAGO_DEPOSITO)
                    {

                        FormaPagoComboBox.SelectedIndex = 9;
                    }
                    else if (m_doctoPago.IFORMAPAGOID == DBValues._FORMA_PAGO_DEPOSITOTERCERO)
                    {

                        FormaPagoComboBox.SelectedIndex = 10;
                    }


                        break;
                case DBValues._FORMA_PAGOSAT_TARJETACREDITO: FormaPagoComboBox.SelectedIndex = 1;  break;
                case DBValues._FORMA_PAGOSAT_TARJETADEBITO: FormaPagoComboBox.SelectedIndex = 2;  break;
                case DBValues._FORMA_PAGOSAT_TARJETASERVICIO: FormaPagoComboBox.SelectedIndex = 3;  break;
                case DBValues._FORMA_PAGOSAT_CHEQUE: FormaPagoComboBox.SelectedIndex = 4;  break;
                case DBValues._FORMA_PAGOSAT_VALE: FormaPagoComboBox.SelectedIndex = 5;  break;
                case DBValues._FORMA_PAGOSAT_TRANSFERENCIA: FormaPagoComboBox.SelectedIndex = 6;  break;
                case DBValues._FORMA_PAGOSAT_OTRO: FormaPagoComboBox.SelectedIndex = 7; break;
                default: FormaPagoComboBox.SelectedIndex = 0;  break;
               
            }

            if (!(bool)m_doctoPago.isnull["IBANCO"])
                this.ComboBanco.SelectedValue = m_doctoPago.IBANCO;
            else
                this.ComboBanco.SelectedIndex = -1;


            if (!(bool)m_doctoPago.isnull["IREFERENCIABANCARIA"])
                this.TBReferencia.Text = m_doctoPago.IREFERENCIABANCARIA;
            else
                this.TBReferencia.Text = "";

            if (!(bool)m_doctoPago.isnull["ICUENTAPAGOCREDITO"])
                this.TBCuentaPago.Text = m_doctoPago.ICUENTAPAGOCREDITO;
            else
                this.TBCuentaPago.Text = "";


            if (!(bool)m_doctoPago.isnull["IREFINTERNO"])
                this.TBRefInterno.Text = m_doctoPago.IREFINTERNO;
            else
                this.TBRefInterno.Text = "";


            if (!(bool)m_doctoPago.isnull["INOTAS"])
                this.TBNotas.Text = m_doctoPago.INOTAS;
            else
                this.TBNotas.Text = "";

            try
            {

                if (!(bool)m_doctoPago.isnull["IFECHAELABORACION"])
                    this.DTPFechaElaboracion.Value = m_doctoPago.IFECHAELABORACION;
                else
                    this.DTPFechaElaboracion.Value = DateTime.Now;


                if (!(bool)m_doctoPago.isnull["IFECHARECEPCION"])
                    this.DTPFechaRecepcion.Value = m_doctoPago.IFECHARECEPCION;
                else
                    this.DTPFechaRecepcion.Value = DateTime.Now;

                if (CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("3.3") || CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0"))
                {
                    DTPFechaAplicado.Value = m_doctoPago.IFECHAAPLICADO;
                    CBAplicado.Checked = m_doctoPago.IAPLICADO == "S";
                    if(FormaPagoComboBox.SelectedIndex == 4)
                    {
                        DTPFechaAplicado.Enabled = true;
                        CBAplicado.Enabled = true;
                    }
                    else
                    {
                        DTPFechaAplicado.Enabled = false;
                        CBAplicado.Enabled = false;
                    }
                }
            }
            catch
            {
            }


        }

        private ArrayList validarUsuarioParaRevertir(CDOCTOPAGOBE doctoPago, long usuarioId)
        {


            //verificacion de permisos
            CUSUARIOSD usersD = new CUSUARIOSD();
            Boolean bTieneDerechoARevertirMismoCajero = usersD.UsuarioTienePermisos((int)usuarioId, (int)DBValues._DERECHO_REVERTIR_ABONO_MISMOCAJERO, null);
            Boolean bTieneDerechoARevertirMismoDia = usersD.UsuarioTienePermisos((int)usuarioId, (int)DBValues._DERECHO_REVERTIR_ABONO_MISMODIA, null);
            Boolean bTieneDerechoARevertirOtroCajero = usersD.UsuarioTienePermisos((int)usuarioId, (int)DBValues._DERECHO_REVERTIR_ABONO_OTROCAJERO, null);
            Boolean bTieneDerechoARevertirOtroDia = usersD.UsuarioTienePermisos((int)usuarioId, (int)DBValues._DERECHO_REVERTIR_ABONO_OTRODIA, null);


            ArrayList erroresPermisos = new ArrayList();

            if (doctoPago.IFECHA != null)
            {
                if (doctoPago.IFECHA.Date == DateTime.Now.Date)
                {
                    if (!bTieneDerechoARevertirMismoDia)
                        erroresPermisos.Add("Permiso para revertir abonos hechos el mismo dia");
                }
                else
                {

                    if (!bTieneDerechoARevertirOtroDia)
                        erroresPermisos.Add("Permiso para revertir abonos hechos en otro dia");
                }
            }

            if (doctoPago.ICORTEID > 0)
            {
                CCORTEBE corteBE = new CCORTEBE();
                CCORTED corteD = new CCORTED();
                corteBE.IID = doctoPago.ICORTEID;

                corteBE = corteD.seleccionarCORTE(corteBE, null);

                if (corteBE != null)
                {
                    if (corteBE.ICAJEROID == usuarioId)
                    {
                        if (!bTieneDerechoARevertirMismoCajero)
                            erroresPermisos.Add("Permiso para revertir abonos hechos por usted");
                    }
                    else
                    {

                        if (!bTieneDerechoARevertirOtroCajero)
                            erroresPermisos.Add("Permiso para revertir abonos hechos por otro cajero");
                    }
                }

            }

            return erroresPermisos;

        }

        private bool RevertirPago(bool bChecarReapartamiento)
        {
            bool retorno = false;
            bool messageRecibirMercancia = false;


            if (m_doctoPago == null)
                return false;

            CDOCTOPAGOD pagoD = new CDOCTOPAGOD();
            CDOCTOPAGOBE pagoBE = new CDOCTOPAGOBE();

            if (!(bool)m_doctoPago.isnull["IID"])
            {
                if(m_doctoPago.IRECIBOELECTRONICOID > 0)
                {
                    if (MessageBox.Show("Este abono tiene un recibo electronico e intentaremos cancelar el abono en el portal de sat... Desea continuar? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return false;
                    }
                }


                if (m_doctoPago.IDEVUELTO != null && m_doctoPago.IDEVUELTO.Equals("S") &&
                    m_doctoPago.IFORMAPAGOID == DBValues._FORMA_PAGO_CHEQUE)
                {
                    MessageBox.Show("Es un pago de cheque devuelto asi que no se puede revertir ", "Nota");
                    return false;
                }


                //revision de permisos para revertir, (solo en abonos a clientes)
                if (m_tipoTransaccion == tipoTransaccionV.t_venta)
                {
                    ArrayList erroresPermisos = validarUsuarioParaRevertir(m_doctoPago, CurrentUserID.CurrentUser.IID);

                    if (erroresPermisos.Count > 0)
                    {
                        string strErrores = "No tiene el(los) siguiente(s) permiso(s): \n";
                        foreach (string str in erroresPermisos)
                        {
                            strErrores += "\n " + str;
                        }
                        strErrores += ". Desea ingresar las credenciales de otro usuario que si tenga los permisos necesarios ( y tenga abierto un corte)?";

                        if (MessageBox.Show(strErrores, "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            return false;
                        }

                        WFPreguntaAutorizacion ps2 = new WFPreguntaAutorizacion();
                        ps2.ShowDialog();
                        CPERSONABE userBE = ps2.m_userBE;
                        ps2.Dispose();
                        GC.SuppressFinalize(ps2);


                        if (userBE == null || userBE.IID == 0)
                        {
                            return false;
                        }

                        erroresPermisos = validarUsuarioParaRevertir(m_doctoPago, userBE.IID);


                        if (erroresPermisos != null && erroresPermisos.Count > 0)
                        {

                            string strErroresSeleccionado = "El usuario seleccionado no tiene el(los) siguiente(s) permiso(s): \n";
                            foreach (string str in erroresPermisos)
                            {
                                strErroresSeleccionado += "\n " + str;
                            }
                            strErroresSeleccionado += ". Desea ingresar las credenciales de otro usuario que si tenga los permisos necesarios ( y tenga abierto un corte)?";

                            if (MessageBox.Show(strErroresSeleccionado, "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                            {
                                return false;
                            }
                        }



                        CPuntoDeVentaD pvd = new CPuntoDeVentaD();
                        DateTime fechaCorte = DateTime.MinValue;
                        if (!pvd.HayCorteActivo(ref fechaCorte, userBE.IID))
                        {

                            if (MessageBox.Show("El usuario seleccionado no tiene corte activo, pidale que abra su corte en esta u otra maquina y reintente", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                            {
                                return false;
                            }
                        }
                        else
                        {

                            TimeSpan ts = DateTime.Now - fechaCorte/*((fechaCorte == null) ? DateTime.MinValue : fechaCorte)*/;
                            if (fechaCorte != null && fechaCorte < DateTime.Today && ts.Hours > 6)
                            {
                                if (MessageBox.Show("El usuario seleccionado tiene un corte activo pero de una fecha pasada, pidale que abra su corte actual en esta u otra maquina y reintente", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                                {
                                    return false;
                                }


                            }
                        }



                    }
                }


                string notaPago = preguntarNotaPago();


                long bancomerParamId = 0;
                if(m_doctoPago.IBANCOMERPARAMID != 0)
                {

                    //checar si la forma de pago es tarjeta y esta habilitado el pinpad
                    if (m_pagoConPinpadHabilitado && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA /*&&
                        (FormaPagoComboBox.SelectedIndex == 1 || FormaPagoComboBox.SelectedIndex == 2 || FormaPagoComboBox.SelectedIndex == 3)*/
                        )
                    {
                        if (!PagoBancomerHelper.Cancelar(ref this.m_Docto, m_doctoPago.IBANCOMERPARAMID, ref bancomerParamId, null))
                        {

                            MessageBox.Show("Error al procesar el pago en el pinpad" + PagoBancomerHelper.strResTransaccion);
                            return false;
                        }
                        PagoBancomerHelper.ImprimirVoucher(bancomerParamId, true, true);
                    }

                }



                long verifonePaymentId = 0;
                if (m_doctoPago.IVERIFONEPAYMENTID != 0)
                {

                    //checar si la forma de pago es tarjeta y esta habilitado el pinpad
                    if (m_pagoConVerifoneHabilitado && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA /*&&
                        (FormaPagoComboBox.SelectedIndex == 1 || FormaPagoComboBox.SelectedIndex == 2 || FormaPagoComboBox.SelectedIndex == 3)*/
                        )
                    {
                        string strResTransaction = "";
                        if (!PagoVerifoneHelper.Cancelar(ref this.m_Docto, m_doctoPago.IVERIFONEPAYMENTID, ref verifonePaymentId, ref strResTransaction, null))
                        {

                            MessageBox.Show("Error al procesar el pago en el pinpad" + PagoBancomerHelper.strResTransaccion);
                            return false;
                        }
                    }

                }


                long doctoCancelacionReciboId = 0;
                string comentarioRef = "";
                if (!CancelarReciboElectronicoSiAplica(m_doctoPago.IID, ref doctoCancelacionReciboId, ref comentarioRef))
                {
                    MessageBox.Show(comentarioRef);
                    return false;
                }


                FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
                FbTransaction fTrans = null;
                try
                {

                    fConn.Open();
                    fTrans = fConn.BeginTransaction();




                    if (!(bool)m_doctoPago.isnull["IBANCO"])
                        pagoBE.IBANCO = m_doctoPago.IBANCO;
                    pagoBE.IREFERENCIABANCARIA = m_doctoPago.IREFERENCIABANCARIA;
                    pagoBE.IFORMAPAGOID = m_doctoPago.IFORMAPAGOID;
                    pagoBE.IIMPORTE = m_doctoPago.IIMPORTE * -1;
                    pagoBE.IIMPORTERECIBIDO = m_doctoPago.IIMPORTERECIBIDO * -1;
                    pagoBE.IFECHAELABORACION = m_doctoPago.IFECHAELABORACION;
                    pagoBE.IFECHARECEPCION = m_doctoPago.IFECHARECEPCION;
                    pagoBE.INOTAS = notaPago; //m_doctoPago.INOTAS;
                    pagoBE.IESAPARTADO = m_doctoPago.IESAPARTADO;
                    pagoBE.IFECHAHORA = DateTime.Now;

                    pagoBE.IDOCTOID = m_doctoPago.IDOCTOID;
                    pagoBE.IDOCTOSALIDAID = m_doctoPago.IDOCTOSALIDAID;
                    pagoBE.IFECHA = DateTime.Today;
                    pagoBE.ICORTEID = CurrentUserID.CurrentUser.ICORTEID;
                    pagoBE.ITIPOPAGOID = m_doctoPago.ITIPOPAGOID;

                    pagoBE.IESPAGOINICIAL = DBValues._DB_BOOLVALUE_NO;


                    pagoBE.ITIPOABONOID = DBValues._TIPO_ABONO_REVERSION;
                    pagoBE.IDOCTOPAGOREFID = m_doctoPago.IID;
                    pagoBE.IBANCOMERPARAMID = bancomerParamId;
                    pagoBE.IAPLICADO = m_doctoPago.IAPLICADO;
                    pagoBE.IVERIFONEPAYMENTID = verifonePaymentId;
                    /*
                    if (m_doctoPago.ITIPOPAGOID == 1)
                        pagoBE.ITIPOPAGOID = 2;
                    else
                        pagoBE.ITIPOPAGOID = 1;*/


                    if (!(bool)m_doctoPago.isnull["IFORMAPAGOSATID"] && m_doctoPago.IFORMAPAGOSATID > 0)
                    {
                        pagoBE.IFORMAPAGOSATID = m_doctoPago.IFORMAPAGOSATID;
                    }


                    //caso de reversion de abono por intercambio de mercancia es especial
                    if(m_doctoPago.IFORMAPAGOID == DBValues._FORMA_PAGO_INTERCAMBIOMERCANCIACREDITO)
                    {

                        pagoBE.IFORMAPAGOID = DBValues._FORMA_PAGO_INTERCAMBIOMERCANCIADEBITO;
                        pagoBE.IIMPORTE = m_doctoPago.IIMPORTE ;
                        pagoBE.IIMPORTERECIBIDO = m_doctoPago.IIMPORTERECIBIDO ;
                        pagoBE.IFORMAPAGOSATID = DBValues._FORMA_PAGOSAT_COMPENSACION;
                        pagoBE.ITIPOABONOID = DBValues._TIPO_ABONO_ABONO;
                    }

                    pagoBE = pagoD.InsertarDOCTOPAGOD(pagoBE, fTrans);
                    if (pagoBE == null)
                    {
                        fTrans.Rollback();
                        MessageBox.Show(pagoD.IComentario);
                        throw new Exception();
                    }


                    //caso de reversion de abono por intercambio de mercancia es especial
                    if (m_doctoPago.IFORMAPAGOID == DBValues._FORMA_PAGO_INTERCAMBIOMERCANCIACREDITO)
                    {

                        m_doctoPago.IREVERTIDO = "S";
                       if(! pagoD.CambiarREVERTIDO(m_doctoPago, fTrans))
                       {

                           fTrans.Rollback();
                           MessageBox.Show(pagoD.IComentario);
                           throw new Exception();
                       }

                       pagoBE.IREVERTIDO = "S";
                       if (!pagoD.CambiarREVERTIDO(pagoBE, fTrans))
                       {

                           fTrans.Rollback();
                           MessageBox.Show(pagoD.IComentario);
                           throw new Exception();
                       }

                    }


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

                    if (bChecarReapartamiento)
                    {
                        this.ChecarReapartamiento(fTrans, ref messageRecibirMercancia);
                    }


                    fTrans.Commit();
                    fConn.Close();
                    retorno = true;


                    CDOCTOD vData = new CDOCTOD();
                    m_Docto = vData.seleccionarDOCTO(m_Docto, null);


                    if(doctoCancelacionReciboId != 0)
                    {
                        comentarioRef = "";
                        ActualizarDoctoPagoSAT(pagoBE.IID, doctoCancelacionReciboId, ref comentarioRef);
                    }

                    //this.Close();

                }
                catch
                {

                    fConn.Close();
                }
                finally
                {
                    fConn.Close();
                }


                if (messageRecibirMercancia)
                {
                    MessageBox.Show("La mercancia apartada debe regresarse");
                }
            }
            return retorno;
        }


        private string preguntarNotaPago()
        {


            WFNotaPago notaPago = new WFNotaPago();
            notaPago.ShowDialog();

            string strNotaPago = notaPago.strNotaPago.Trim();

            notaPago.Dispose();
            GC.SuppressFinalize(notaPago);

            return strNotaPago;
        }

        private void ChecarReapartamiento(FbTransaction fTrans, ref bool messageRecibirMercancia)
        {

            if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA && m_Docto.IESAPARTADO == "S")
            {
                CDOCTOBE doctoBuffer = new CDOCTOBE();
                CDOCTOD doctoD = new CDOCTOD();
                CPuntoDeVentaD pvd = new CPuntoDeVentaD();
                doctoBuffer.IID = m_Docto.IID;
                doctoBuffer = doctoD.seleccionarDOCTO(doctoBuffer, fTrans);
                if (doctoBuffer != null)
                {

                    if (!(bool)doctoBuffer.isnull["IID"] && doctoBuffer.ISALDO >= 0)
                    {
                        if (!pvd.VENTA_RETORNARMERCANCIA(m_Docto, fTrans))
                        {

                            if (fTrans != null)
                            {
                                fTrans.Rollback();
                            }
                            MessageBox.Show(pvd.IComentario);
                            throw new Exception();
                        }
                        else
                        {
                            messageRecibirMercancia = true;
                        }
                    }
                }
            }
        }


        private void BTEliminar_Click(object sender, EventArgs e)
        {





            if (RevertirPago(true))
            {
                LimpiarManteniendoDocto();
                LlenarGridAbono();
                llenarDatosPersona();
                llenarDatosTransaccion(true);
            }
        }

        private void BTNuevo_Click(object sender, EventArgs e)
        {
            LimpiarManteniendoDocto();
        }

        private void LimpiarManteniendoDocto()
        {
            m_doctoPago = new CDOCTOPAGOBE();
            m_intentosPagoTarjetaConPinPad = 0;
            this.lblNumMovimiento.Text = "";
            this.PA_ABONOTextBox.Text = "0";
            this.FormaPagoComboBox.SelectedIndex = -1;
                this.ComboBanco.SelectedIndex = -1;
                this.TBReferencia.Text = "";
                this.TBCuentaPago.Text = "";
                this.TBRefInterno.Text = "";
                this.TBNotas.Text = "";
                this.DTPFechaElaboracion.Value = DateTime.Now;
                this.DTPFechaRecepcion.Value = DateTime.Now;

                this.pnlAbono.Enabled = true;
                this.pnlBancario.Enabled = false;
                this.BTGuardar.Enabled = true;
                this.BTEliminar.Enabled = false;

                this.BTRecibo.Enabled = false;
                this.btnReciboElectronico.Enabled = false;

                this.lblCompraRelacionada.Text = "";
                this.m_DoctoCompra = null;

        }

        private void FormaPagoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (FormaPagoComboBox.SelectedIndex > 0 && FormaPagoComboBox.SelectedIndex != 7)
            {
                this.pnlBancario.Enabled = true;

                if (tieneCuentaPago)
                {

                    if (MessageBox.Show("Este cliente tiene cuentas de pago bancarias configuradas, desea seleccionar una cuenta? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        seleccionarCuentaPagoCliente();
                    }
                }
            }
            else
            {
                pnlBancario.Enabled = false; 
                this.ComboBanco.SelectedIndex = -1;
                this.TBReferencia.Text = "";
            }

            if (FormaPagoComboBox.Text == "Cheque nominativo")
            {
                DTPFechaAplicado.Enabled = true;
                CBAplicado.Enabled = true;
            }
            else
            {
                DTPFechaAplicado.Enabled = false;
                CBAplicado.Enabled = false;
                CBAplicado.Checked = true;
                DTPFechaAplicado.Value = DateTime.Today;//DTPFechaRecepcion.Value;
            }

            CalcularMontosXCaptura();
            formatearPanelCompraRelacionada();
        }

        private void btnNuevoPago_Click(object sender, EventArgs e)
        {

        }


        private int getTipoDoctoIdPorTipoTransaccion()
        {
            int tipoDoctoParaLista = 0;
            switch (m_tipoTransaccion)
            {
                case tipoTransaccionV.t_compra:
                    tipoDoctoParaLista = 11;
                    break;
                case tipoTransaccionV.t_compraSucursal:
                    tipoDoctoParaLista = 1011;
                    break;
                default: tipoDoctoParaLista = 0; break;
            }

            return tipoDoctoParaLista;
        }


        private void TBTransacccion_Validating(object sender, CancelEventArgs e)
        {
            if (TBTransacccion.Text.Trim() == "")
                return;

            int folio = 0;

            CDOCTOD vData = new CDOCTOD();
            if(int.TryParse(TBTransacccion.Text.Trim(),out folio))
            {
                m_Docto = new CDOCTOBE();
                m_Docto.IFOLIO = folio;
                //m_Docto.ITIPODOCTOID = (m_tipoTransaccion == tipoTransaccionV.t_compra) ? 11 : 0;
                m_Docto.ITIPODOCTOID = getTipoDoctoIdPorTipoTransaccion();


                m_Docto = vData.SeleccionarXTIPOYFOLIO(m_Docto, null);

                if (m_Docto != null)
                {

                    m_ClienteId = m_Docto.IPERSONAID;
                    llenarDatosPersona();
                    llenarDatosTransaccion(false);
                    LlenarGridAbono();


                    this.pnlAbono.Enabled = true;
                    this.BTGuardar.Enabled = true;
                    this.BTNuevo.Enabled = true;

                    this.PA_ABONOTextBox.Focus();

                    visibilizaCamposDeComision();
                }
                else
                {

                    MessageBox.Show("El registro no existe " + vData.IComentario);

                    e.Cancel = true;
                }

            }



        }

        private void TBTransacccion_Validated(object sender, EventArgs e)
        {

            if (TBTransacccion.Text.Trim() == "")
            {
                limpiarDatosPersona();
                limpiarDatosTransaccion();
                this.dSPuntoDeVentaAux.GET_LISTA_ABONOS_DOCTO.Clear();
            }
        }

        private void TBTransacccion_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TBTransacccion.Text.Trim() == "")
                {
                    SeleccionarTransaccion();
                }
                else
                {
                    this.gET_LISTA_ABONOS_DOCTODataGridView.Focus();
                }
            }
        }




        private bool ChecarCorteActivo()
        {
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            DateTime fechaCorte = DateTime.MinValue;
            if (!pvd.HayCorteActivo(ref fechaCorte, iPos.CurrentUserID.CurrentUser.IID))
            {
                MessageBox.Show("Necesita abrir un corte");
                this.Close();
                return false;
            }
            else
            {
                TimeSpan ts = DateTime.Now - fechaCorte/*((fechaCorte == null) ? DateTime.MinValue : fechaCorte)*/;
                if (fechaCorte != null && fechaCorte < DateTime.Today && ts.Hours > 6)
                {

                    MessageBox.Show("Se tiene abierto un corte de una fecha pasada porfavor cierrelo antes de continuar");
                    this.Close();
                    return false;
                }
                else
                    return true;
            }

            //return true;

        }

        private void TBFolioFactElectronica_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TBFolioFactElectronica.Text.Trim() == "")
                {
                    SeleccionarTransaccion();
                }
                else
                {
                    this.gET_LISTA_ABONOS_DOCTODataGridView.Focus();
                }
            }
        }

        

        

      

        private void BTBuscarXFactE_Click(object sender, EventArgs e)
        {
            if (TBFolioFactElectronica.Text.Trim() == "")
                return;

            int folio = 0;

            CDOCTOD vData = new CDOCTOD();
            if (int.TryParse(TBFolioFactElectronica.Text.Trim(), out folio))
            {
                m_Docto = new CDOCTOBE();
                try
                {
                    m_Docto.IFOLIOSAT = int.Parse(this.TBFolioFactElectronica.Text.ToString());
                }
                catch
                {
                    return;
                }
                m_Docto.ISERIESAT = this.TBSerieSAT.Text;
                //m_Docto.ITIPODOCTOID = (m_tipoTransaccion == tipoTransaccionV.t_compra) ? 11 : 0;
                m_Docto.ITIPODOCTOID = getTipoDoctoIdPorTipoTransaccion();
                m_Docto = vData.SeleccionarXTIPOYFOLIOFacturaElectronica(m_Docto, null);

                if (m_Docto != null)
                {

                    m_ClienteId = m_Docto.IPERSONAID;
                    llenarDatosPersona();
                    llenarDatosTransaccion(false);
                    LlenarGridAbono();


                    this.pnlAbono.Enabled = true;
                    this.BTGuardar.Enabled = true;
                    this.BTNuevo.Enabled = true;

                    this.PA_ABONOTextBox.Focus();
                }
                else
                {
                    MessageBox.Show("El registro no existe");

                }

            }
        }



        public void imprimirRecibo()
        {
           
            if (m_doctoPago == null)
                return;

            CDOCTOPAGOD pagoD = new CDOCTOPAGOD();

            if (!(bool)m_doctoPago.isnull["IID"])
            {
                imprimirRecibo(m_doctoPago.IID);
            }
        }

        public void imprimirRecibo(long pagoId)
        {
            string strReporte = "";

            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("itemid", pagoId);

            switch (m_tipoTransaccion)
            {
                case tipoTransaccionV.t_compra:
                case tipoTransaccionV.t_compraSucursal:
                    {
                        strReporte = "ReciboPagoProveedor.frx";
                    }
                    break;
                default:
                    strReporte = "ReciboPagoCliente.frx";
                    break;

            }

            

            iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
            rp.ShowDialog();
            rp.Dispose();
            GC.SuppressFinalize(rp);
        }

        private void BTRecibo_Click(object sender, EventArgs e)
        {
            imprimirRecibo();
           
        }

        private void WFAbonos_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.F10:
                    CompletarFaltante();
                    break;
            }
        }


        private void CompletarFaltante()
        {
            if(m_Docto != null )
            {
                this.PA_ABONOTextBox.Text = m_Docto.ISALDO.ToString();
            }
        }




        private bool generarFacturaElectronicaPorId(long doctoId, FbTransaction fTrans, ref string resComentario)
        {
            bool esVersion33 = (CurrentUserID.CurrentParameters.IVERSIONCFDI != null && (CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("3.3") || CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0")));
          

            CDOCTOBE docto = new CDOCTOBE();
            CDOCTOBE doctoRef = new CDOCTOBE();
            CDOCTOD doctoD = new CDOCTOD();
            docto.IID = doctoId;
            docto = doctoD.seleccionarDOCTO(docto, fTrans);


            if (docto == null)
            {

                resComentario = "No se encontro la factura electronica";
                return false;
            }


            doctoRef.IID = docto.IDOCTOREFID;
            doctoRef = doctoD.seleccionarDOCTO(doctoRef, fTrans);

            
            if (doctoRef == null && !esVersion33)
            {

                resComentario = "No se encontro la referencia de factura electronica";
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




            iPosReporting.WFFacturaElectronica fe = new iPosReporting.WFFacturaElectronica(docto, CurrentUserID.CurrentParameters, WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_TIMBRAR, fTrans, doctoRef, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
            fe.m_silentMode = true;
            fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
            fe.ShowDialog();
            retorno = fe.m_facturacionRealizada;
            if(!retorno)
            {
                resComentario = fe.m_iComentario;
            }
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
            CDOCTOBE doctoRef = new CDOCTOBE();
            CDOCTOBE docto = new CDOCTOBE();
            docto.IID = doctoId;
            docto = doctoD.seleccionarDOCTO(docto, null);

            if (docto == null)
            {

                MessageBox.Show("No se encontro la factura electronica");
                return false;
            }


            doctoRef.IID = docto.IDOCTOREFID;
            doctoRef = doctoD.seleccionarDOCTO(doctoRef, null);
            //if (doctoRef == null)
            //{

            //    MessageBox.Show("No se encontro la referencia de factura electronica");
            //    return false;
            //}


            if ((bool)docto.isnull["IFOLIOSAT"] || (bool)docto.isnull["IESTATUSDOCTOID"]
                || docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_COMPLETO || docto.IFOLIOSAT <= 0)
            {
                MessageBox.Show("No se puede imprimir la factura electronica , cheque que se haya generado la factura electronica de este registro");
                return false;
            }


            iPosReporting.WFFacturaElectronica fe = new iPosReporting.WFFacturaElectronica(docto, CurrentUserID.CurrentParameters, iPosReporting.WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_GENERARPDF, doctoRef, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
            CUSUARIOSD usuariosD = new CUSUARIOSD(); fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
            fe.ShowDialog();
            retorno = fe.m_facturacionRealizada;
            fe.Dispose();
            GC.SuppressFinalize(fe);
            return retorno;
        }




        private bool cancelarFacturaElectronicaPorId(long doctoId, FbTransaction fTrans, ref string resComentario)
        {

            CDOCTOBE docto = new CDOCTOBE();
            CDOCTOBE doctoRef = new CDOCTOBE();
            CDOCTOD doctoD = new CDOCTOD();
            docto.IID = doctoId;
            docto = doctoD.seleccionarDOCTO(docto, fTrans);


            if (docto == null)
            {

                resComentario = "No se encontro la factura electronica";
                return false;
            }

            /*
            doctoRef.IID = docto.IDOCTOREFID;
            doctoRef = doctoD.seleccionarDOCTO(doctoRef, fTrans);
            if (doctoRef == null)
            {

                resComentario = "No se encontro la referencia de factura electronica";
                return false;
            }*/


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




            iPosReporting.WFFacturaElectronica fe = new iPosReporting.WFFacturaElectronica(docto, CurrentUserID.CurrentParameters, WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_CANCELAR, fTrans, doctoRef, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
            fe.m_silentMode = false;
            fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
            fe.ShowDialog();
            retorno = fe.m_facturacionCancelada;
            if (!retorno)
            {
                resComentario = fe.m_iComentario;

                if (MessageBox.Show("No se pudo cancelar el recibo electronico en el SAT desde el sistema. Como el recibo actual fue firmado electronicamente, tendra que cancelarla tambien en el SAT. Desea continuar con la cancelacion en el sistema?", "Cancelar la transaccion actual", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                    retorno = false;
                else
                    retorno = true;

            }
            m_strFileLog = fe.m_strFileLog;

            fe.Dispose();
            GC.SuppressFinalize(fe);

            return retorno;
        }




        private bool GuardarAplicado(long folioPago, DateTime fechaAplicado)
        {
                CPAGOBE pagoAplicar = new CPAGOBE();
                CPAGOD daoPagoAplicar = new CPAGOD();

                pagoAplicar.IID = folioPago;

                pagoAplicar = daoPagoAplicar.seleccionarPAGO(pagoAplicar, null);
                if (pagoAplicar == null)
                    return false;

                pagoAplicar.IAPLICADO = "S";



            if (pagoAplicar.IFECHAAPLICADO != null && !pagoAplicar.IFECHAAPLICADO.Date.Equals(fechaAplicado.Date))
            {

                long motivoId = 0;
                DateTime nuevaFecha = DateTime.Today;

                WFMotivoCambioFecApl wf = new WFMotivoCambioFecApl(fechaAplicado);
                wf.ShowDialog();
                motivoId = wf.m_motivoId;
                nuevaFecha = wf.m_fechaAplicacion;
                wf.Dispose();
                GC.SuppressFinalize(wf);

                if (motivoId > 0)
                {
                    pagoAplicar.IFECHAAPLICADO = nuevaFecha;
                    pagoAplicar.IMOTIVO_CAMFEC_ID = motivoId;
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un motivo");
                    return false;
                }
            }

            if (!daoPagoAplicar.CambiarAPLICADO_PAGOD(pagoAplicar, pagoAplicar, null))
                {
                    MessageBox.Show(daoPagoAplicar.IComentario);
                    return false;
                }

            return true;
        }

        private void btnReciboElectronico_Click(object sender, EventArgs e)
        {




            if (m_doctoPago.IRECIBOELECTRONICOID > 0)
            {

                imprimirFacturaElectronicaPorId(m_doctoPago.IRECIBOELECTRONICOID);
                return;
            }



            //en el caso de la facturacion 3.3 , el cheque debe estar aplicado.. preguntar los datos de aplicado y fechaaplicado
            bool bPreguntarAplicado = (((CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("3.3") || CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0")) && (m_doctoPago.IAPLICADO == null || !m_doctoPago.IAPLICADO.Equals("S") ) && m_doctoPago != null && m_doctoPago.IFORMAPAGOID == DBValues._FORMA_PAGO_CHEQUE)) ? true : false;
            if(bPreguntarAplicado)
            {
                WFPreguntarAplicado wf = new WFPreguntarAplicado();
                wf.ShowDialog();
                try
                {
                    if (!wf.bAplicado)
                    {
                        return;
                    }

                    if (!GuardarAplicado(m_doctoPago.IPAGOID, wf.fechaAplicado))
                    {
                        return;
                    }
                }
                catch { }
                finally
                {

                    wf.Dispose();
                    GC.SuppressFinalize(wf);
                }
                
            }


            long doctoReciboId = 0;
            string strComentarioRecibo = "";
            bool bRes = ProcesarReciboElectronicoSiAplica(this.m_doctoPago.IID, ref  doctoReciboId, ref strComentarioRecibo); 
            if (!bRes && doctoReciboId == 0)
            {
                MessageBox.Show(strComentarioRecibo);
            }
            else
            {
                //imprimirFacturaElectronicaPorId(doctoReciboId);

                LimpiarManteniendoDocto();
                LlenarGridAbono();
                llenarDatosPersona();
                llenarDatosTransaccion(true);
            }
        }



        private void visibilizaCamposDeComision()
        {
            if(m_tipoTransaccion == tipoTransaccionV.t_venta && (CurrentUserID.CurrentParameters.ICOMISIONPORTARJETA > 0.0m || CurrentUserID.CurrentParameters.ICOMISIONDEBPORTARJETA > 0.0m) && (m_Docto.IPAGOCONTARJETA == null || !m_Docto.IPAGOCONTARJETA.Equals("S")) &&
                m_personaBE != null && m_personaBE.ICARGOXVENTACONTARJETA != null && m_personaBE.ICARGOXVENTACONTARJETA.Equals("S"))
            {


                RBDesgloseMonto.Visible = true;
                lblMontoAlternativo.Visible = true;
                lblComision.Visible = true;


                CBCondonarPagoComision.Visible = m_tieneDerechoCondonarComision;

            }
            else
            {

                RBDesgloseMonto.Visible = false;
                lblMontoAlternativo.Visible = false;
                lblComision.Visible = false;
                CBCondonarPagoComision.Visible = false;
            }

        }


        private void CalcularMontosXCaptura()
        {

            decimal monto = decimal.Parse(PA_ABONOTextBox.NumericValue.ToString());

            if (m_tipoTransaccion == tipoTransaccionV.t_venta && (CurrentUserID.CurrentParameters.ICOMISIONPORTARJETA > 0.0m || CurrentUserID.CurrentParameters.ICOMISIONDEBPORTARJETA > 0.0m) && (m_Docto.IPAGOCONTARJETA == null || !m_Docto.IPAGOCONTARJETA.Equals("S")) &&
                m_personaBE != null && m_personaBE.ICARGOXVENTACONTARJETA != null && m_personaBE.ICARGOXVENTACONTARJETA.Equals("S") &&
                !CBCondonarPagoComision.Checked && (FormaPagoComboBox.SelectedIndex == 1 || FormaPagoComboBox.SelectedIndex == 2))
            {
                decimal comisionPorTarjetaAplicar = FormaPagoComboBox.SelectedIndex == 2 ? CurrentUserID.CurrentParameters.ICOMISIONDEBPORTARJETA : CurrentUserID.CurrentParameters.ICOMISIONPORTARJETA;

                if (RBCapturaSinComision.Checked)
                {

                    
                    m_montoAplicar = monto;
                    m_montoComision = Math.Round(monto * (comisionPorTarjetaAplicar / 100.0m), 2);
                    m_montoTotal = m_montoAplicar + m_montoComision;

                    this.lblMontoAlternativo.Text = "Monto con comision: " + m_montoTotal;
                    this.lblComision.Text = "Comision: " + m_montoComision.ToString("N2");
                }
                else
                {
                    
                    m_montoAplicar = Math.Round(monto / (1.0m + (comisionPorTarjetaAplicar / 100.0m)),2);
                    m_montoComision = monto - m_montoAplicar;
                    m_montoTotal = monto;

                    this.lblMontoAlternativo.Text = "Monto sin comision: " + m_montoAplicar;
                    this.lblComision.Text = "Comision: " + m_montoComision.ToString("N2");
                }

            }
            else
            {
                m_montoAplicar = monto;
                m_montoComision = 0.0m;
                m_montoTotal = monto;


                this.lblMontoAlternativo.Text = "";
                this.lblComision.Text = "";
            }
           
        }



        private void CalcularYMostrarMontosXDoctoPago()
        {

            decimal monto = decimal.Parse(PA_ABONOTextBox.NumericValue.ToString());

            if (m_tipoTransaccion == tipoTransaccionV.t_venta && (CurrentUserID.CurrentParameters.ICOMISIONPORTARJETA > 0.0m || CurrentUserID.CurrentParameters.ICOMISIONDEBPORTARJETA > 0.0m) && (m_Docto.IPAGOCONTARJETA == null || !m_Docto.IPAGOCONTARJETA.Equals("S")) &&
                m_personaBE != null && m_personaBE.ICARGOXVENTACONTARJETA != null && m_personaBE.ICARGOXVENTACONTARJETA.Equals("S"))
            {

                m_montoAplicar = m_doctoPago.IIMPORTE;
                m_montoComision = m_doctoPago.ICOMISION;
                m_montoTotal = m_montoAplicar + m_montoComision;

                if (RBCapturaSinComision.Checked)
                {
                    this.PA_ABONOTextBox.Text = m_montoAplicar.ToString("N2");
                    this.lblMontoAlternativo.Text = "Monto con comision: " + m_montoTotal;
                    this.lblComision.Text = "Comision: " + m_montoComision.ToString("N2");
                }
                else
                {
                    this.PA_ABONOTextBox.Text = m_montoTotal.ToString("N2");
                    this.lblMontoAlternativo.Text = "Monto sin comision: " + m_montoAplicar;
                    this.lblComision.Text = "Comision: " + m_montoComision.ToString("N2");
                }

            }
            else
            {
                m_montoAplicar = m_doctoPago.IIMPORTE;
                m_montoComision = 0.0m;
                m_montoTotal = m_montoAplicar;
                this.PA_ABONOTextBox.Text = m_montoAplicar.ToString("N2");
                this.lblMontoAlternativo.Text = "";
                this.lblComision.Text = "";
            }

        }

        private void PA_ABONOTextBox_Validated(object sender, EventArgs e)
        {
            this.CalcularMontosXCaptura();
        }

        private void RBCapturaConComision_CheckedChanged(object sender, EventArgs e)
        {
            CalcularMontosXCaptura();
        }

        private void CBCondonarPagoComision_CheckedChanged(object sender, EventArgs e)
        {
            CalcularMontosXCaptura();
        }

        private void BtnCompraRelacionada_Click(object sender, EventArgs e)
        {
            SeleccionarCompraRelacionada();
        }


        private void SeleccionarCompraRelacionada()
        {

            int tipoDoctoParaLista = (int)DBValues._DOCTO_TIPO_COMPRA;

            if (m_Docto == null || m_Docto.IID == 0)
                return;

            long personaId = m_Docto.IPERSONAID;
            CPERSONAD personaD = new CPERSONAD();
            CPERSONABE personaBE = new CPERSONABE();
            personaBE.IID = personaId;
            personaBE = personaD.seleccionarPERSONA(personaBE, null);
            if(personaBE == null )
            {
                MessageBox.Show("No existe la persona");
                return;
            }

            if(personaBE.IPROVEECLIENTEID == 0)
            {

                MessageBox.Show("No hay proveedor asociado");
                return;
            }

            WFSaldosListaTransacciones look = new WFSaldosListaTransacciones((int)DBValues._DOCTO_ESTATUS_COMPLETO, tipoDoctoParaLista, personaBE.IPROVEECLIENTEID,false, false);
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

                if (m_DoctoCompra.IPERSONAID != m_personaBE.IPROVEECLIENTEID)
                {
                    MessageBox.Show("el proveedor de la compra no corresponde a este cliente");
                    m_DoctoCompra = null;
                    return;
                }

                if (m_DoctoCompra.ISALDO <= 0)
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


        private void formatearPanelCompraRelacionada()
        {

            if (m_tipoTransaccion != tipoTransaccionV.t_venta || m_personaBE == null || m_personaBE.IPROVEECLIENTEID == 0 || FormaPagoComboBox.SelectedIndex != 7)
            {
                pnlCompraRelacionada.Visible = false;
                return;
            }


            pnlCompraRelacionada.Visible = true;
        }

        private void btnSeleccionarXRef_Click(object sender, EventArgs e)
        {
            m_doctoPago = new CDOCTOPAGOBE();

            //int tipoDoctoParaLista = (m_tipoTransaccion == tipoTransaccionV.t_compra) ? 11 : 0;
            int tipoDoctoParaLista = getTipoDoctoIdPorTipoTransaccion();

            WFReferencia wf = new WFReferencia();
            wf.ShowDialog();

            if (wf.referenciaSeleccionada == null)
            {
                wf.Dispose();
                GC.SuppressFinalize(wf);
                return;
            }

            WFSaldosListaTransacciones look = new WFSaldosListaTransacciones((int)DBValues._DOCTO_ESTATUS_COMPLETO, tipoDoctoParaLista, null, false, false, wf.referenciaSeleccionada);
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                m_Docto.IID = int.Parse(dr[0].ToString());
                CDOCTOD vData = new CDOCTOD();
                m_Docto = vData.seleccionarDOCTO(m_Docto, null);
                m_ClienteId = m_Docto.IPERSONAID;
                llenarDatosPersona();
                llenarDatosTransaccion(false);
                LlenarGridAbono();



                this.TBTransacccion.Text = m_Docto.IFOLIO.ToString("N0");


                this.pnlAbono.Enabled = true;
                this.BTGuardar.Enabled = true;
                this.BTNuevo.Enabled = true;

                this.PA_ABONOTextBox.Focus();

                visibilizaCamposDeComision();

            }

            wf.Dispose();
            GC.SuppressFinalize(wf);
            
        }

        private void FormaPagoComboBox_Validating(object sender, CancelEventArgs e)
        {

            /*if (m_tipoTransaccion != tipoTransaccionV.t_venta)
            {
                if ((FormaPagoComboBox.SelectedIndex == 9 || FormaPagoComboBox.SelectedIndex == 10))
                {
                    MessageBox.Show("Aun no esta implementado esta forma de pago para compras");
                    e.Cancel = true;
                    return;

                }
            }*/

        }

        private bool EsPagoCompuesto(long pagoId)
        {

            CPAGOD pagoD = new CPAGOD();
            return pagoD.esPAGOCOMPUESTO(pagoId, null);
            
        }


        private void seleccionarCuentaPagoCliente()
        {

            Contabilidad.WFPersonaCuentasBancos wf = new Contabilidad.WFPersonaCuentasBancos(this.m_ClienteId,"");
            wf.ShowDialog();
            


            DataRow dr = wf.m_rtnDataRow;
            if (dr != null)
            {
                TBCuentaPago.Text = dr["NOCUENTA"].ToString().Trim();
                TBCuentaPago.Focus();
                TBCuentaPago.Select(TBCuentaPago.Text.Length, 0);

                this.ComboBanco.SelectedIndex = -1;

                try
                {

                    long bancoId = long.Parse(dr["BANCOID"].ToString());


                    if (bancoId > 0)
                        this.ComboBanco.SelectedValue = bancoId;
                    else
                        this.ComboBanco.SelectedIndex = -1;
                }
                catch
                {

                }


                //ProcessCommand();
            }
            wf.Dispose();
            GC.SuppressFinalize(wf);
        }

        private void btnCuentaPago_Click(object sender, EventArgs e)
        {
            seleccionarCuentaPagoCliente();
        }


        private bool clienteTieneCuentas()
        {
            CPERSONACUENTABANCOD cuentaBancoD = new CPERSONACUENTABANCOD();
            int cuenta = cuentaBancoD.CantidadCuentasCliente(this.m_ClienteId, null);
            return cuenta > 0;
        }

        private bool ValidaListaDePagosConMismaReferencia(string referenciaBancaria, int bancoId, decimal importe, long formaPagoSeleccionada)
        {
            try
            {
                this.pAGOSPORREFERENCIATableAdapter.Fill(this.dSAbonos3.PAGOSPORREFERENCIA, referenciaBancaria, bancoId, importe, formaPagoSeleccionada);
                if (this.dSAbonos3.PAGOSPORREFERENCIA.Rows.Count == 0)
                    return true;
                else
                {

                    WFPagosReferencias look = new WFPagosReferencias(referenciaBancaria, bancoId, importe, formaPagoSeleccionada);
                    look.ShowDialog();

                    bool aceptado = look.aceptado;

                    look.Dispose();
                    GC.SuppressFinalize(look);

                    return aceptado;
                }


            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

            return true;

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
}
