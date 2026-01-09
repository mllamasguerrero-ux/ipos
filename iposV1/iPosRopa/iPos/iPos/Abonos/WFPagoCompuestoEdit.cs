using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iPosBusinessEntity;
using iPosData;
using System.Collections;
using FirebirdSql.Data.FirebirdClient;
using iPosReporting;
using iPos.Abonos;

namespace iPos
{
    public partial class WFPagoCompuestoEdit : IposForm
    {


        private bool m_pagoConPinpadHabilitado = false;
        private bool m_obviarPagoConPinpadHabilitado = false;
        private bool m_tieneDerechoCondonarComision = false;

        private Boolean m_bTieneDerechoAplicarCheque = false;
        private Boolean m_bTieneDerechoDesAplicarCheque = false;


        //private decimal m_montoAplicar = 0.0m;
        //private decimal m_montoComision = 0.0m;


        private decimal m_montoTotal = 0.0m;
        private decimal m_montoAAplicar = 0.0m;

        private long m_clienteId = 0;
        private long folioPago = 0;

        private string m_strFileLog = "";

        private bool nuevoPagoTarjeta = false;

        private bool saveAplicado = false;

        private bool tieneCuentaPago = false;

        private bool bInformacionCargandose = false;


        public WFPagoCompuestoEdit()
        {
            InitializeComponent();
        }

        public WFPagoCompuestoEdit(long folioPago) : this()
        {
            this.folioPago = folioPago; 
        }

        public void llenarDatosPersona(long clienteId)
        {
            m_clienteId = clienteId;

            tieneCuentaPago = clienteTieneCuentas();
            btnCuentaPago.Visible = tieneCuentaPago;


            LlenarGridSaldos();

            CPERSONAD personaD = new CPERSONAD();
            CPERSONABE personaBE = personaD.SeleccionarPersonaPorId(clienteId, null);

            if(personaBE != null)
                llenarDatosPersona(personaBE);
            else
                limpiarDatosPersona();

        }


        public void llenarDatosPersona(CPERSONABE personaBE)
        {
            limpiarDatosPersona();

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

                //LBCliente.Text = personaBE.ICLAVE;

                if(folioPago == 0)
                {

                    TBCuentaPago.Text = ((bool)personaBE.isnull["ICREDITOREFERENCIAABONOS"]) ? "" : personaBE.ICREDITOREFERENCIAABONOS;
                }

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

            //LBCliente.Text = "";
        }
        
        

        private void WFPagoCompuestoEdit_Load(object sender, EventArgs e)
        {

            if (!ChecarCorteActivo())
                return;


            this.ComboBanco.llenarDatos();
            this.ComboBanco.SelectedIndex = -1;


            this.CUENTABANCOEMPRESAIDComboBox.llenarDatos();
            this.CUENTABANCOEMPRESAIDComboBox.SelectedIndex = -1;

            HabilitarPagoEdicion();

            ChecarPinPadHabilitado();

            ponerTieneDerechoCondonar();

            visibilizaCamposDeComision();

            if (folioPago > 0)
            {
                tabControl1.TabPages.Remove(tabPage1);
                LlenarDatosDeBase();
                DeshabilitarCamposCreacion();
                nuevoPagoTarjeta = true;
            }
            else
            {
                TBIdPago.Visible = false;
                label7.Visible = false;
                tabControl1.TabPages.Remove(tabPage2);
            }

            if (CurrentUserID.CurrentParameters.IVERSIONCFDI != "3.3" && CurrentUserID.CurrentParameters.IVERSIONCFDI != "4.0")
            {
                lblCuentaRecep.Visible = false;
                CUENTABANCOEMPRESAIDComboBox.Visible = false;
                lblFechaAplicado.Visible = false;
                DTPFechaAplicado.Visible = false;
                CBAplicado.Visible = false;
            }
            else
            {
                if (FormaPagoComboBox.Text == "Cheque nominativo" && !CBAplicado.Checked)
                {
                    BTGuardar.Enabled = true;
                    saveAplicado = true;
                }
            }
        }

        private void LlenarDatosDeBase()
        {
            CPAGOBE pago = new CPAGOBE();
            CPAGOD pagoDao = new CPAGOD();
            bInformacionCargandose = true;


            pago.IID = folioPago;
            pago = pagoDao.seleccionarPAGO(pago, null);

            TBIdPago.Text = pago.IID.ToString();
            //.DbValue = pago.IPERSONAID.ToString();

            if (CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("3.3") || CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0"))
            {
                btnReciboElectronico.Enabled = true;
                if (pago.IRECIBOELECTRONICOID != 0)
                {
                    lblTimbrado.Visible = true;
                    imgTimbrado.Visible = true;
                }
                //else
                //{
                //    btnReciboElectronico.Enabled = true;
                //}

            }

            if(pago.IREVERTIDO == null || !pago.IREVERTIDO.Equals("S"))
            {
                BTEliminar.Enabled = true;
            }
            else
            {

                BTEliminar.Enabled = false;
            }

            if (!(bool)pago.isnull["IBANCO"])
            {
                ComboBanco.SelectedValue = pago.IBANCO;
            }
            else
            {
                ComboBanco.SelectedValue = -1;
            }

            if (!(bool)pago.isnull["ICUENTABANCOEMPRESAID"])
            {
                CUENTABANCOEMPRESAIDComboBox.SelectedValue = pago.ICUENTABANCOEMPRESAID;
            }
            else
            {
                CUENTABANCOEMPRESAIDComboBox.SelectedValue = -1;
            }

            string strBuffer = "";
            if (!(bool)pago.isnull["IPERSONAID"])
            {
                this.ITEMIDTextBox.DbValue = pago.IPERSONAID.ToString();
                this.ITEMIDTextBox.MostrarErrores = false;
                this.ITEMIDTextBox.MValidarEntrada(out strBuffer, 1);
                this.ITEMIDTextBox.MostrarErrores = true;

                llenarDatosPersona(pago.IPERSONAID);
            }

            PA_ABONOTextBox.Text = pago.IIMPORTE.ToString();
            DTPFechaElaboracion.Value = pago.IFECHAELABORACION;
            DTPFechaRecepcion.Value = pago.IFECHARECEPCION;

            int formaPagoIndex = ObtenerFormaPagoIndex(pago.IFORMAPAGOID, pago.IFORMAPAGOSATID);

            if (formaPagoIndex >= 0) FormaPagoComboBox.SelectedIndex = formaPagoIndex;

            TBNotas.Text = pago.INOTAS;

            TBReferencia.Text = pago.IREFERENCIABANCARIA;
            TBCuentaPago.Text = pago.ICUENTAPAGOCREDITO;

            TBRefInterno.Text = pago.IREFINTERNO ;

            if (CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("3.3") || CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0"))
            {
                if(pago.IAPLICADO == "S")
                {

                    DTPFechaAplicado.Value = pago.IFECHAAPLICADO;
                    CBAplicado.Checked = true;
                }
                else
                {

                    DTPFechaAplicado.Value = DateTime.Today;
                    CBAplicado.Checked = false;
                }

            }

            pAGOSAPLICADOSTableAdapter.Fill(dSAbonos.PAGOSAPLICADOS, pago.IID);
            bInformacionCargandose = false;

        }
        private void ponerTieneDerechoCondonar()
        {
            CUSUARIOSD usuariosD = new CUSUARIOSD();
            m_tieneDerechoCondonarComision = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_CONDONARCOMISION_TARJETA, null);
            m_bTieneDerechoAplicarCheque = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_APLICAR_CHEQUES, null);
            m_bTieneDerechoDesAplicarCheque = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_DESAPLICAR_CHEQUES, null);


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

            if (CurrentUserID.CurrentParameters.IBANCOMERHABPINPAD != null && CurrentUserID.CurrentParameters.IBANCOMERHABPINPAD == "S" &&
               (usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_OBVIAR_PAGO_TERMINAL_BANCOMER, null)))
            {
                m_obviarPagoConPinpadHabilitado = true;
            }



        }

        private void DeshabilitarCamposCreacion()
        {
            TBIdPago.Enabled = false;
            ITEMIDTextBox.Enabled = false;
            ITEMButton.Enabled = false;
            FormaPagoComboBox.Enabled = false;
            TBNotas.Enabled = false;
            TBReferencia.Enabled = false;
            ComboBanco.Enabled = false;
            TBCuentaPago.Enabled = false;
            CUENTABANCOEMPRESAIDComboBox.Enabled = false;
            PA_ABONOTextBox.Enabled = false;
            DTPFechaElaboracion.Enabled = false;
            DTPFechaRecepcion.Enabled = false;
            BTGuardar.Enabled = false;
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


        private void SeleccionaCliente()
        {
            iPos.Catalogos.WFClientes look = new iPos.Catalogos.WFClientes();
            look.m_bSelecionarRegistro = true;
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                string strBuffer = "";
                this.ITEMIDTextBox.DbValue = ((long)dr["ID"]).ToString();
                this.ITEMIDTextBox.MostrarErrores = false;
                this.ITEMIDTextBox.MValidarEntrada(out strBuffer, 1);
                this.ITEMIDTextBox.MostrarErrores = true;

                llenarDatosPersona((long)dr["ID"]);
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

        private void ITEMButton_Click(object sender, EventArgs e)
        {
            this.SeleccionaCliente();
        }

        private void ITEMIDTextBox_Validated(object sender, EventArgs e)
        {

            try
            {
                long clienteId = Int64.Parse(this.ITEMIDTextBox.DbValue.ToString());
                llenarDatosPersona(clienteId);
            }
            catch
            {
            
                return;
            }
        }



        private void HabilitarPagoEdicion()
        {
            this.PA_ABONOTextBox.Text = "0";
            this.FormaPagoComboBox.SelectedIndex = 0;// -1;
            this.ComboBanco.SelectedIndex = -1;
            this.TBReferencia.Text = "";
            this.TBCuentaPago.Text = "";
            this.TBNotas.Text = "";
            this.DTPFechaElaboracion.Value = DateTime.Now;
            this.DTPFechaRecepcion.Value = DateTime.Now;

            this.pnlAbono.Enabled = true;
            this.pnlBancario.Enabled = false;
            this.BTGuardar.Enabled = true;

            this.BTRecibo.Enabled = true;// false;
            this.btnReciboElectronico.Enabled = false;
            

        }

        private void FormaPagoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bInformacionCargandose)
                return;

            if (FormaPagoComboBox.SelectedIndex > 0 && FormaPagoComboBox.SelectedIndex != 7)
            {
                this.pnlBancario.Enabled = true;

                if(tieneCuentaPago)
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

            if(FormaPagoComboBox.SelectedIndex == 4)
            {
                this.CBAplicado.Checked = false;
                this.CBAplicado.Enabled = true;

            }
            else
            {
                this.CBAplicado.Checked = true;
                this.CBAplicado.Enabled = false;
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
                DTPFechaAplicado.Value = DTPFechaRecepcion.Value;
            }

            if (CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("3.3") || CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0"))
            {
                if((FormaPagoComboBox.SelectedIndex == 1 || FormaPagoComboBox.SelectedIndex == 2) && !nuevoPagoTarjeta)
                {
                    MessageBox.Show("No puedes realizar pagos compuestos con tarjeta con cfdi 3.3, dirigete a la ventana de abonos!");
                    FormaPagoComboBox.SelectedIndex = 0;
                    FormaPagoComboBox.Focus();
                }
            }

            CalcularMontosXCaptura();
        }



        private void visibilizaCamposDeComision()
        {
            

        }


        private void CalcularMontosXCaptura()
        {

            m_montoTotal = decimal.Parse(PA_ABONOTextBox.NumericValue.ToString());
            

           
        }

        

        private void PA_ABONOTextBox_Validated(object sender, EventArgs e)
        {

            this.CalcularMontosXCaptura();
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


            if(pagoAplicar.IFECHAAPLICADO != null && !pagoAplicar.IFECHAAPLICADO.Date.Equals(fechaAplicado.Date) )
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

        private bool GuardarAplicado()
        {
            if(CBAplicado.Checked)
            {
                CPAGOBE pagoAplicar = new CPAGOBE();
                CPAGOD daoPagoAplicar = new CPAGOD();

                pagoAplicar.IID = folioPago;

                pagoAplicar = daoPagoAplicar.seleccionarPAGO(pagoAplicar, null);
                if (pagoAplicar == null)
                    return false;


                pagoAplicar.IAPLICADO = "S";
                pagoAplicar.IFECHAAPLICADO = DTPFechaAplicado.Value;

                if(!daoPagoAplicar.CambiarAPLICADO_PAGOD(pagoAplicar, pagoAplicar, null))
                {
                    return false;
                }
            }

            return true;
        }

        private void BTGuardar_Click(object sender, EventArgs e)
        {
            if(saveAplicado)
            {
                if(GuardarAplicado())
                {
                    if(CBAplicado.Checked)
                    {
                        MessageBox.Show("Pago Aplicado con exito!");
                        preguntarReciboElectronico(folioPago);
                    }
                    Close();
                    return;
                }
            }

            if (GuardarPago())
            {
                Close();
            }
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


            bool validarCuentas = false;
            if ((formaPagoSatBE.ISAT_PATRONORDENANTE != null && cuentaOrdenante != null && cuentaOrdenante.Trim().Length > 0 &&
                 formaPagoSatBE.ISAT_PATRONORDENANTE.Trim().Length > 0 && !formaPagoSatBE.ISAT_PATRONORDENANTE.Trim().ToUpper().Equals("NO") &&
                 !formaPagoSatBE.ISAT_PATRONORDENANTE.Trim().ToUpper().Equals("OPCIONAL")) ||
                 (cuentaBancoBE != null && formaPagoSatBE.ISAT_PATRONBENEFICIARIO != null && cuentaBancoBE.INOCUENTA != null && cuentaBancoBE.INOCUENTA.Trim().Length > 0 &&
                 formaPagoSatBE.ISAT_PATRONBENEFICIARIO.Trim().Length > 0 && !formaPagoSatBE.ISAT_PATRONBENEFICIARIO.Trim().ToUpper().Equals("NO") &&
                 !formaPagoSatBE.ISAT_PATRONBENEFICIARIO.Trim().ToUpper().Equals("OPCIONAL"))
                 )
            {
                validarCuentas = true;
            }


            //if ( formaPagoSatBE.ISAT_PATRONORDENANTE != null && cuentaOrdenante != null && cuentaOrdenante.Trim().Length > 0 && 
            //     formaPagoSatBE.ISAT_PATRONORDENANTE.Trim().Length > 0 && !formaPagoSatBE.ISAT_PATRONORDENANTE.Trim().ToUpper().Equals("NO") &&
            //     !formaPagoSatBE.ISAT_PATRONORDENANTE.Trim().ToUpper().Equals("OPCIONAL"))
            if(validarCuentas)
                {
                    if (!iPosReporting.VirtualXml.VirtualXmlHelper.MatchPatronFormaPago(cuentaOrdenante, formaPagoSatBE.ISAT_PATRONORDENANTE, false))
                    {
                        ordenanteValida = false;
                        mensaje += "La cuenta ordenante es invalida, favor de seguir el patron " + formaPagoSatBE.ISAT_PATRONORDENANTE;
                    }
                }

            //if (   cuentaBancoBE != null  && formaPagoSatBE.ISAT_PATRONBENEFICIARIO != null && cuentaBancoBE.INOCUENTA != null && cuentaBancoBE.INOCUENTA.Trim().Length > 0 &&
            //     formaPagoSatBE.ISAT_PATRONBENEFICIARIO.Trim().Length > 0 && !formaPagoSatBE.ISAT_PATRONBENEFICIARIO.Trim().ToUpper().Equals("NO") &&
            //     !formaPagoSatBE.ISAT_PATRONBENEFICIARIO.Trim().ToUpper().Equals("OPCIONAL"))

            if (validarCuentas)
            {
                
                if (!iPosReporting.VirtualXml.VirtualXmlHelper.MatchPatronFormaPago(cuentaBancoBE.INOCUENTA, formaPagoSatBE.ISAT_PATRONBENEFICIARIO, false))
                {
                    beneficiariaValida = false;
                    mensaje += "La cuenta beneficiaria (del banco seleccionado) es invalida, favor de seguir el patron " + formaPagoSatBE.ISAT_PATRONBENEFICIARIO;
                }
            }

            return beneficiariaValida && ordenanteValida;

        }



        private CBANCOMERPARAMBE ObtenerPagoPorTarjetaPinPad(long bancomerParamId)
        {

            CBANCOMERPARAMBE bancomerParamBE = new CBANCOMERPARAMBE();
            CBANCOMERPARAMD bancomerParamD = new CBANCOMERPARAMD();

            bancomerParamBE.IID = bancomerParamId;
            bancomerParamBE = bancomerParamD.seleccionarBANCOMERPARAM(bancomerParamBE, null);


            return bancomerParamBE;
        }


        private CBANCOSBE ObtenerBancoDesdeClave(string clave)
        {

            CBANCOSBE bancosBE = new CBANCOSBE();
            CBANCOSD bancosD = new CBANCOSD();

            bancosBE.ICLAVE = clave;
            bancosBE = bancosD.seleccionarBANCOSxCLAVE(bancosBE, null);


            return bancosBE;
        }

        private int ObtenerFormaPagoIndex(long formaPagoId, long formaPagoSatId)
        {

            if (formaPagoId == DBValues._FORMA_PAGO_EFECTIVO && formaPagoSatId == DBValues._FORMA_PAGOSAT_EFECTIVO)
                return 0;
            else if (formaPagoId == DBValues._FORMA_PAGO_TARJETA && formaPagoSatId == DBValues._FORMA_PAGOSAT_TARJETACREDITO)
                return 1;
            else if (formaPagoId == DBValues._FORMA_PAGO_TARJETA && formaPagoSatId == DBValues._FORMA_PAGOSAT_TARJETADEBITO)
                return 2;
            else if (formaPagoId == DBValues._FORMA_PAGO_TARJETA && formaPagoSatId == DBValues._FORMA_PAGOSAT_TARJETASERVICIO)
                return 3;
            else if (formaPagoId == DBValues._FORMA_PAGO_CHEQUE && formaPagoSatId == DBValues._FORMA_PAGOSAT_CHEQUE)
                return 4;
            else if (formaPagoId == DBValues._FORMA_PAGO_VALE && formaPagoSatId == DBValues._FORMA_PAGOSAT_VALE)
                return 5;
            else if (formaPagoId == DBValues._FORMA_PAGO_TRANSFERENCIA && formaPagoSatId == DBValues._FORMA_PAGOSAT_TRANSFERENCIA)
                return 6;
            else if (formaPagoId == DBValues._FORMA_PAGO_INTERCAMBIOMERCANCIACREDITO && (formaPagoSatId == DBValues._FORMA_PAGOSAT_COMPENSACION || formaPagoSatId == DBValues._FORMA_PAGOSAT_OTRO))
                return 7;
            else if (formaPagoId == DBValues._FORMA_PAGO_NOIDENTIFICADO && formaPagoSatId == DBValues._FORMA_PAGOSAT_OTRO)
                return 8;
            else if (formaPagoId == DBValues._FORMA_PAGO_DEPOSITO && formaPagoSatId == DBValues._FORMA_PAGOSAT_EFECTIVO)
                return 9;
            else if (formaPagoId == DBValues._FORMA_PAGO_DEPOSITOTERCERO && formaPagoSatId == DBValues._FORMA_PAGOSAT_EFECTIVO)
                return 10;
            else if (formaPagoId == DBValues._FORMA_PAGO_EFECTIVO && formaPagoSatId == DBValues._FORMA_PAGOSAT_EFECTIVO)
                return 11;

            else return -1;
        }



        private void FormaPagoSeleccionada(out long formaPagoSeleccionada, out long formaPagoSatSeleccionada)
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

        private void FijarFormaPago(ref CPAGOBE pagoBE)
        {
            long formaPagoSeleccionada = 0;
            long formaPagoSatSeleccionada = 0;
            FormaPagoSeleccionada(out formaPagoSeleccionada, out formaPagoSatSeleccionada);
            pagoBE.IFORMAPAGOID = formaPagoSeleccionada;
            pagoBE.IFORMAPAGOSATID = formaPagoSatSeleccionada;


            /*switch (FormaPagoComboBox.SelectedIndex)
            {

                case 0:
                    pagoBE.IFORMAPAGOID = DBValues._FORMA_PAGO_EFECTIVO;
                    pagoBE.IFORMAPAGOSATID = DBValues._FORMA_PAGOSAT_EFECTIVO;
                    break;
                case 1:
                    pagoBE.IFORMAPAGOID = DBValues._FORMA_PAGO_TARJETA;
                    pagoBE.IFORMAPAGOSATID = DBValues._FORMA_PAGOSAT_TARJETACREDITO;
                    break;
                case 2:
                    pagoBE.IFORMAPAGOID = DBValues._FORMA_PAGO_TARJETA;
                    pagoBE.IFORMAPAGOSATID = DBValues._FORMA_PAGOSAT_TARJETADEBITO;
                    break;
                case 3:
                    pagoBE.IFORMAPAGOID = DBValues._FORMA_PAGO_TARJETA;
                    pagoBE.IFORMAPAGOSATID = DBValues._FORMA_PAGOSAT_TARJETASERVICIO;
                    break;
                case 4:
                    pagoBE.IFORMAPAGOID = DBValues._FORMA_PAGO_CHEQUE;
                    pagoBE.IFORMAPAGOSATID = DBValues._FORMA_PAGOSAT_CHEQUE;
                    break;
                case 5:
                    pagoBE.IFORMAPAGOID = DBValues._FORMA_PAGO_VALE;
                    pagoBE.IFORMAPAGOSATID = DBValues._FORMA_PAGOSAT_VALE;
                    break;
                case 6:
                    pagoBE.IFORMAPAGOID = DBValues._FORMA_PAGO_TRANSFERENCIA;
                    pagoBE.IFORMAPAGOSATID = DBValues._FORMA_PAGOSAT_TRANSFERENCIA;
                    break;
                case 7:
                    pagoBE.IFORMAPAGOID = DBValues._FORMA_PAGO_INTERCAMBIOMERCANCIACREDITO;
                    pagoBE.IFORMAPAGOSATID = DBValues._FORMA_PAGOSAT_OTRO;
                    break;
                case 8:
                    pagoBE.IFORMAPAGOID = DBValues._FORMA_PAGO_NOIDENTIFICADO;
                    pagoBE.IFORMAPAGOSATID = DBValues._FORMA_PAGOSAT_OTRO;
                    break;
                case 9:
                    pagoBE.IFORMAPAGOID = DBValues._FORMA_PAGO_DEPOSITO;
                    pagoBE.IFORMAPAGOSATID = DBValues._FORMA_PAGOSAT_EFECTIVO;
                    break;
                case 10:
                    pagoBE.IFORMAPAGOID = DBValues._FORMA_PAGO_DEPOSITOTERCERO;
                    pagoBE.IFORMAPAGOSATID = DBValues._FORMA_PAGOSAT_EFECTIVO;
                    break;
                default:
                    pagoBE.IFORMAPAGOID = DBValues._FORMA_PAGO_EFECTIVO;
                    pagoBE.IFORMAPAGOSATID = DBValues._FORMA_PAGOSAT_EFECTIVO;
                    break;
            }*/
        }

        private bool GuardarPago()
        {

            this.lblSumaAAplicar.Text = SumaAbonos().ToString("N2");

            if(m_montoAAplicar != m_montoTotal)
            {
                MessageBox.Show(" el pago debe estar aplicado para que pueda guardarse");
                return false;
            }


            if ((FormaPagoComboBox.SelectedIndex == 1 || FormaPagoComboBox.SelectedIndex == 2 || FormaPagoComboBox.SelectedIndex == 3 || FormaPagoComboBox.SelectedIndex == 4 || FormaPagoComboBox.SelectedIndex == 6)
                 && (this.TBReferencia.Text.Trim().Length == 0 || this.ComboBanco.SelectedIndex < 0))
            {
                MessageBox.Show("Debe seleccionar el banco y la referencia si esta pagando con tarjeta , cheque o transferencia");
                return false;
            }





            long formaPagoSeleccionada = 0;
            long formaPagoSatSeleccionada = 0;
            FormaPagoSeleccionada(out formaPagoSeleccionada, out formaPagoSatSeleccionada);

            if (FormaPagoComboBox.SelectedIndex > 0 && FormaPagoComboBox.SelectedIndex != 7)
            {

                if (!ValidaListaDePagosConMismaReferencia(this.TBReferencia.Text, int.Parse(this.ComboBanco.SelectedValue.ToString()), m_montoTotal, formaPagoSeleccionada))
                {

                    MessageBox.Show("Hubo problemas por duplicidad de referencias bancarias");
                    return false;
                }
            }


            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            CPAGOBE pagoBE = new CPAGOBE();
            CPAGOD pagoD = new CPAGOD();
            CDOCTOPAGOD doctoPagoD = new CDOCTOPAGOD();

            try
            {





                pagoBE = new CPAGOBE();
                pagoBE.IFECHA = DateTime.Now;
                pagoBE.IFECHAHORA = DateTime.Now;
                pagoBE.ICORTEID = CurrentUserID.CurrentUser.ICORTEID;
                if (this.ComboBanco.SelectedIndex >= 0)
                    pagoBE.IBANCO = long.Parse(this.ComboBanco.SelectedValue.ToString());
                pagoBE.IREFERENCIABANCARIA = this.TBReferencia.Text;
                pagoBE.IIMPORTE = m_montoTotal;
                pagoBE.INOTAS = TBNotas.Text;

                pagoBE.IIMPORTERECIBIDO = m_montoTotal;

                pagoBE.IFECHAELABORACION = DTPFechaElaboracion.Value;
                pagoBE.IFECHARECEPCION = DTPFechaRecepcion.Value;

                if ((CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("3.3") || CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0")) && this.CUENTABANCOEMPRESAIDComboBox.SelectedIndex >= 0)
                    pagoBE.ICUENTABANCOEMPRESAID = long.Parse(this.CUENTABANCOEMPRESAIDComboBox.SelectedValue.ToString());
                else if ((CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("3.3") || CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0")) && pnlBancario.Enabled)
                    pagoBE.ICUENTABANCOEMPRESAID = -1;


                FijarFormaPago(ref pagoBE);

                //pagoBE.ICOMISION = m_montoComision;

                
                pagoBE.ITIPOPAGOID = DBValues._TIPOPAGO_ENTRADA;
                  

                pagoBE.IESAPARTADO = "N";
                pagoBE.IESPAGOINICIAL = DBValues._DB_BOOLVALUE_NO;

                pagoBE.ITIPOABONOID = DBValues._TIPO_ABONO_ABONO;
                pagoBE.ICUENTAPAGOCREDITO = TBCuentaPago.Text;


                //pagoBE.IBANCOMERPARAMID = bancomerParamId;

                pagoBE.IPERSONAID = long.Parse(ITEMIDTextBox.DbValue);



                if (CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("3.3") || CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0"))
                {
                    pagoBE.IAPLICADO = CBAplicado.Checked ? "S" : "N";
                    pagoBE.IFECHAAPLICADO = FormaPagoComboBox.Text == "Cheque nominativo" ?  DTPFechaAplicado.Value : DTPFechaRecepcion.Value;


                    string mensajeValidacionCuentas = "";
                    if (!validarCuentasPago(pagoBE.IFORMAPAGOSATID, pagoBE.ICUENTAPAGOCREDITO, pagoBE.ICUENTABANCOEMPRESAID, ref mensajeValidacionCuentas))
                    {
                        if (MessageBox.Show("Al validar las cuentas para timbrado parece que hay posibles problemas \n" + mensajeValidacionCuentas +  "\n Desea continuar con el pago ? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            throw new Exception();
                        }
                    }

                }

                pagoBE.IREFINTERNO = TBRefInterno.Text;


                fConn.Open();
                fTrans = fConn.BeginTransaction();

                pagoBE = pagoD.InsertarPAGOD(pagoBE, fTrans);
                if (pagoBE == null)
                {
                    fTrans.Rollback();
                    fConn.Close();
                    MessageBox.Show(pagoD.IComentario);
                    throw new Exception();
                }

                

                DataRow dr;


                foreach (DataGridViewRow row in dOCTOSCONSALDODataGridView.Rows)
                {
                    decimal dSaldoAAplicar = decimal.Parse(row.Cells["DGSALDOAAPLICAR"].Value.ToString());

                    if (dSaldoAAplicar > 0)
                    {

                        dr = (row.DataBoundItem as DataRowView).Row;
                        /*dr["SALDOAAPLICAR"] = dSaldoAAplicar;
                        m_montoAAplicar += dSaldoAAplicar;*/




                        CDOCTOPAGOBE pagoManual = new CDOCTOPAGOBE();




                        pagoManual.IDOCTOID = long.Parse(dr["CONSECUTIVO"].ToString());
                        pagoManual.ITIPOPAGOID = pagoBE.ITIPOPAGOID;
                        pagoManual.IFORMAPAGOID = pagoBE.IFORMAPAGOID;
                        pagoManual.IFORMAPAGOSATID = pagoBE.IFORMAPAGOSATID;
                        //pagoManual.IDOCTOSALIDAID = long.Parse(dr["DOCTOIDAPLICAR"].ToString());
                        pagoManual.IFECHA = pagoBE.IFECHA;
                        pagoManual.IFECHAHORA = pagoBE.IFECHAHORA;
                        pagoManual.ICORTEID = pagoBE.ICORTEID;
                        pagoManual.IIMPORTE = dSaldoAAplicar;
                        pagoManual.IIMPORTECAMBIO = 0.00m;
                        pagoManual.IIMPORTERECIBIDO = dSaldoAAplicar;
                        pagoManual.IESAPARTADO = pagoBE.IESAPARTADO;

                        pagoManual.IESPAGOINICIAL = DBValues._DB_BOOLVALUE_NO;
                        pagoManual.ITIPOABONOID = pagoBE.ITIPOABONOID;
                        pagoManual.IPAGOID = pagoBE.IID;


                        pagoManual.ICUENTABANCOEMPRESAID = pagoBE.ICUENTABANCOEMPRESAID;
                        


                        pagoManual.IAPLICADO = CBAplicado.Checked ? "S" : "N";
                        pagoManual.IFECHAAPLICADO = pagoBE.IFECHAAPLICADO;

                        pagoManual.IFECHAELABORACION = DTPFechaElaboracion.Value;
                        pagoManual.IFECHARECEPCION = DTPFechaRecepcion.Value;

                        if(pagoBE.IBANCO > 0)
                            pagoManual.IBANCO = pagoBE.IBANCO;

                        pagoManual.IREFERENCIABANCARIA = pagoBE.IREFERENCIABANCARIA;
                        pagoManual.ICUENTAPAGOCREDITO = pagoBE.ICUENTAPAGOCREDITO;
                        pagoManual.INOTAS = pagoBE.INOTAS;

                        if (doctoPagoD.InsertarDOCTOPAGOD(pagoManual, fTrans) == null)
                        {

                            fTrans.Rollback();
                            MessageBox.Show(pagoD.IComentario);
                            throw new Exception();
                        }



                    }

                }




                if (!doctoPagoD.AjustarSaldosPersona(m_clienteId, fTrans))
                {

                    fTrans.Rollback();
                    MessageBox.Show(pagoD.IComentario);
                    throw new Exception();
                }


                fTrans.Commit();
                fConn.Close();

                folioPago = pagoBE.IID;

                preguntarReciboElectronico(pagoBE.IID);


                if (MessageBox.Show("Desea imprimir el recibo? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    imprimirRecibo(pagoBE.IID);
                }


                //bool bPreguntarReciboElectronico = (((CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("3.3") || CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0")) && !CBAplicado.Checked && pagoBE.IFORMAPAGOID == DBValues._FORMA_PAGO_CHEQUE) ||
                //                                       ((CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("3.3") || CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0")) && !checkTimbradoParaReciboElectronico()))? false : true;

                //long doctoReciboId = 0;
                //string strComentarioRecibo = "";


                //if (bPreguntarReciboElectronico)
                //{
                //    if (!ProcesarReciboElectronicoSiAplica(pagoBE.IID, ref doctoReciboId, ref strComentarioRecibo))
                //    {
                //        MessageBox.Show(strComentarioRecibo);
                //    }
                //    else
                //    {
                //        //imprimirFacturaElectronicaPorId(doctoReciboId);
                //    }
                //}

                //if (MessageBox.Show("Desea imprimir el recibo? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                //{
                //    imprimirRecibo(pagoBE.IID);
                //}

            }
            catch (Exception ex)
            {
                //fTrans.Rollback();
                fConn.Close();
                return false;
            }
            finally
            {

                fConn.Close();
            }

            return true;
        }
        

        private void preguntarReciboElectronico(long pagoId)
        {
            CPAGOD pagoD = new CPAGOD();   
            CPAGOBE pagoBE = new CPAGOBE();
            pagoBE.IID = pagoId;
            pagoBE = pagoD.seleccionarPAGO(pagoBE, null);


            bool bPreguntarReciboElectronico = (((CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("3.3") || CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0")) && !CBAplicado.Checked && pagoBE.IFORMAPAGOID == DBValues._FORMA_PAGO_CHEQUE) ||
                                                   ((CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("3.3") || CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0")) && !checkTimbradoParaReciboElectronico())) ? false : true;

            long doctoReciboId = 0;
            string strComentarioRecibo = "";


            if (bPreguntarReciboElectronico)
            {
                if (!ProcesarReciboElectronicoSiAplica(pagoBE.IID, ref doctoReciboId, ref strComentarioRecibo))
                {
                    MessageBox.Show(strComentarioRecibo);
                }
                else
                {
                    //imprimirFacturaElectronicaPorId(doctoReciboId);
                }
            }
        }

        private void LlenarGridSaldos()
        {
            string soloTimbrados = timbradosCheckBox.Checked ? "S" : "N";

            try
            {
                this.dOCTOSCONSALDOTableAdapter.Fill(this.dSAbonos.DOCTOSCONSALDO, 
                                                     DBValues._DOCTO_TIPO_VENTA, 
                                                     m_clienteId,
                                                     soloTimbrados);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }





        private bool ProcesarReciboElectronicoSiAplica(long pagoId, ref long doctoReciboId, ref string comentario)
        {

            CPAGOBE pagoBE = new CPAGOBE();
            CPAGOD pagoD = new CPAGOD();
            pagoBE.IID = pagoId;    
            pagoBE = pagoD.seleccionarPAGO(pagoBE, null);
            if (pagoBE == null)
            {
                comentario = "El pago no existe";
                return false;
            }

            if (pagoBE.IRECIBOELECTRONICOID > 0)
            {
                doctoReciboId = pagoBE.IRECIBOELECTRONICOID;
                comentario = "El registro ya tiene un recibo electronico";
                return false;

            }

            if (pagoBE.IIMPORTE <= 0 || (pagoBE.IREVERTIDO != null && pagoBE.IREVERTIDO.Equals("S")))
            {
                return true;
            }


            

            CDOCTOD doctoD = new CDOCTOD();

            CPERSONAD personaD = new CPERSONAD();
            CPERSONABE personaBE = new CPERSONABE();
            personaBE.IID = m_clienteId;
            personaBE = personaD.seleccionarPERSONA(personaBE, null);


            if (personaBE != null)
            {
                

                    if (MessageBox.Show("Desea registrar un recibo electronico de este abono ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return true;
                    }



                    if (pagoBE.IFORMAPAGOID != DBValues._FORMA_PAGO_EFECTIVO &&  (pagoBE.ICUENTAPAGOCREDITO == null || pagoBE.ICUENTAPAGOCREDITO.Trim().Equals("")) && pagoBE.ICUENTABANCOEMPRESAID > 0)
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

                        pagoBE.ICUENTAPAGOCREDITO = strCuentaPago;

                        if (!pagoD.CambiarCUENTAPAGOCREDITO_PAGOD(pagoBE, pagoBE, null))
                        {

                            MessageBox.Show("Error al actualizar la cuenta pago " + pagoD.IComentario);
                            return false;
                        }
                    }



                    if (CurrentUserID.CurrentParameters.IVERSIONCFDI != null && (CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("3.3") || CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0")))
                    {
                        return procesarReciboElectronico33(pagoId, ref doctoReciboId, ref comentario);
                    }
                    else
                    {
                        //return procesarReciboElectronico(pagoId, ref doctoReciboId, ref comentario);
                    }


                    
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

                if (!doctoD.RECIBOELECTRONICO_P_GENERAR_33(pagoId, CurrentUserID.CurrentUser.IID, ref doctoReciboId, fTrans))
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


        
        public void imprimirRecibo()
        {

            CPAGOBE pagoActual = new CPAGOBE();
            CPAGOD pagoD = new CPAGOD();
            pagoActual.IID = folioPago;
            pagoActual = pagoD.seleccionarPAGO(pagoActual, null);

            if (pagoActual == null)
                return;

            imprimirRecibo(pagoActual.IID);
        }


        public void imprimirRecibo(long pagoId)
        {
            string strReporte = "";

            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("itemid", pagoId);
            
            strReporte = "ReciboPagoClienteMultiple.frx";



            iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
            rp.ShowDialog();
            rp.Dispose();
            GC.SuppressFinalize(rp);
        }




        private bool generarFacturaElectronicaPorId(long doctoId, FbTransaction fTrans, ref string resComentario)
        {
            bool esVersion33 = (CurrentUserID.CurrentParameters.IVERSIONCFDI != null && CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("3.3"));
            bool esVersion40 = (CurrentUserID.CurrentParameters.IVERSIONCFDI != null && CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0"));

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


            if (doctoRef == null && !(esVersion33 || esVersion40))
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
            if (!retorno)
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





        private decimal SumaAbonos()
        {
            m_montoAAplicar = 0;
            DataRow dr;
            foreach (DataGridViewRow row in dOCTOSCONSALDODataGridView.Rows)
            {
                decimal dSaldoAAplicar = decimal.Parse(row.Cells["DGSALDOAAPLICAR"].Value.ToString());

                if (dSaldoAAplicar > 0)
                {
                    dr = (row.DataBoundItem as DataRowView).Row;
                    dr["MONTOAPLICAR"] = dSaldoAAplicar;
                    m_montoAAplicar += dSaldoAAplicar;
                }
            }

            return m_montoAAplicar;
        }

        private decimal ObtenerSaldo()
        {
            return decimal.Parse(PA_ABONOTextBox.Text) - SumaAbonos();
        }

        private void dOCTOSCONSALDODataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            decimal sumaAbonos = SumaAbonos();
            decimal saldo = decimal.Parse(PA_ABONOTextBox.Text);
            this.lblSumaAAplicar.Text = sumaAbonos.ToString("N2");
            lblSaldo.Text = (saldo-sumaAbonos).ToString("N2");
        }

        private void dOCTOSCONSALDODataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            string columnName = dOCTOSCONSALDODataGridView.Columns[e.ColumnIndex].Name;
            

            // Abort validation if cell is not in the CompanyName column.
            if (!columnName.Equals("DGSALDOAAPLICAR")) return;


            try
            {
                decimal dSaldoAAplicar = decimal.Parse(e.FormattedValue.ToString());
                decimal dSaldo = decimal.Parse(dOCTOSCONSALDODataGridView.Rows[e.RowIndex].Cells["DGSALDO"].Value.ToString());
                decimal dOldValue = decimal.Parse(dOCTOSCONSALDODataGridView.Rows[e.RowIndex].Cells["DGSALDOAAPLICAR"].Value.ToString());

                if (dSaldoAAplicar > dSaldo || dSaldoAAplicar < 0)
                {
                    MessageBox.Show("El saldo a aplicar no puede ser mayor que el saldo de la transaccion ni menor que cero");
                    e.Cancel = true;
                }

                

                if ((m_montoAAplicar - dOldValue + dSaldoAAplicar) > m_montoTotal)
                {

                    MessageBox.Show("se excederia el saldo posible a aplicar");
                    e.Cancel = true;
                }


            }
            catch
            {
            }
        }

        private void dOCTOSCONSALDODataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

            DataGridView view = (DataGridView)sender;
            MessageBox.Show("Dato invalido , porfavor ingrese un dato valido");
            e.ThrowException = false;
        }

        private void timbradosCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            LlenarGridSaldos();
        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                object pagoid = new object();
                this.pAGOSAPLICADOSTableAdapter.Fill(this.dSAbonos.PAGOSAPLICADOS, pagoid);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private bool checkTimbradoParaReciboElectronico()
        {
            foreach (DataGridViewRow row in pAGOSAPLICADOSDataGridView.Rows)
            {
                if(!row.Cells["ESTATIMBRADO"].Value.ToString().Equals("S"))
                {
                    return false;
                }
                //More code here
            }

            return true;
        }

        private void btnReciboElectronico_Click(object sender, EventArgs e)
        {

            

            long doctoReciboId = 0;
            string strComentarioRecibo = "";

            CPAGOBE pagoActual = new CPAGOBE();
            CPAGOD pagoD = new CPAGOD();
            pagoActual.IID = folioPago;
            pagoActual = pagoD.seleccionarPAGO(pagoActual, null);


            if(pagoActual == null)
            {
                MessageBox.Show("el pago ya no existe");
                return;
            }


            if(pagoActual.IRECIBOELECTRONICOID > 0)
            {

                imprimirFacturaElectronicaPorId(pagoActual.IRECIBOELECTRONICOID);
                return;
            }

            
            bool bPreguntarAplicado = (((CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("3.3") || CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0")) && (pagoActual.IAPLICADO == null || !pagoActual.IAPLICADO.Equals("S")) && pagoActual != null && pagoActual.IFORMAPAGOID == DBValues._FORMA_PAGO_CHEQUE)) ? true : false;
            if (bPreguntarAplicado)
            {
                WFPreguntarAplicado wf = new WFPreguntarAplicado();
                wf.ShowDialog();
                try
                {
                    if (!wf.bAplicado)
                    {
                        return;
                    }

                    if (!GuardarAplicado(pagoActual.IID, wf.fechaAplicado))
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



            //if ((CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("3.3") || CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0")) && !CBAplicado.Checked && pagoActual.IFORMAPAGOID == DBValues._FORMA_PAGO_CHEQUE)
            //{

            //    MessageBox.Show("El pago necesita estar aplicado.");
            //    return;
            //}

            if ((CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("3.3") || CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0")) && !checkTimbradoParaReciboElectronico())
            {
                MessageBox.Show("No se puede generar el recibo electronico porque hay ventas sin timbrar!.");
                return;
            }

            if (!ProcesarReciboElectronicoSiAplica(folioPago, ref doctoReciboId, ref strComentarioRecibo))
            {
                MessageBox.Show(strComentarioRecibo);
            }
            else
            {
                //imprimirFacturaElectronicaPorId(doctoReciboId);
            }
        }

        private void pnlAbono_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }


        private ArrayList validarUsuarioParaRevertir(CPAGOBE doctoPago, long usuarioId)
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
            long pagoRevertidoId = 0;


            CPAGOBE pagoActual = new CPAGOBE();
            CPAGOD pagoD = new CPAGOD();
            pagoActual.IID = folioPago;
            pagoActual = pagoD.seleccionarPAGO(pagoActual, null);

            if (pagoActual == null)
                return false;

            if (pagoActual.IRECIBOELECTRONICOID > 0)
            {
                if (MessageBox.Show("Este abono tiene un recibo electronico e intentaremos cancelar el abono en el portal de sat... Desea continuar? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return false;
                }
            }


            if (pagoActual.IDEVUELTO != null && pagoActual.IDEVUELTO.Equals("S") &&
                pagoActual.IFORMAPAGOID == DBValues._FORMA_PAGO_CHEQUE)
            {
                MessageBox.Show("Es un pago de cheque devuelto asi que no se puede revertir ", "Nota");
                return false;
            }

            //revision de permisos para revertir, (solo en abonos a clientes)
            ArrayList erroresPermisos = validarUsuarioParaRevertir(pagoActual, CurrentUserID.CurrentUser.IID);

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
                        return false;

                    erroresPermisos = validarUsuarioParaRevertir(pagoActual, userBE.IID);

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



            string notaPago = preguntarNotaPago();


            long doctoCancelacionReciboId = 0;
            string comentarioRef = "";
            if (!CancelarReciboElectronicoSiAplica(pagoActual.IID, ref doctoCancelacionReciboId, ref comentarioRef))
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


                if(!pagoD.RevertirPAGOD(folioPago, CurrentUserID.CurrentUser.IID, bChecarReapartamiento, notaPago,ref pagoRevertidoId, fTrans))
                {

                    fTrans.Rollback();
                    MessageBox.Show(pagoD.IComentario);
                    throw new Exception();
                }
                   
                


                fTrans.Commit();
                fConn.Close();
                retorno = true;

                

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


            //if (messageRecibirMercancia)
            //{
            //    MessageBox.Show("La mercancia apartada debe regresarse");
            //}
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
            try
            {
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
            }
            catch { }
            finally
            {
                fe.Dispose();
                GC.SuppressFinalize(fe);

            }

            return retorno;
        }


        private bool CancelarReciboElectronicoSiAplica(long pagoId, ref long doctoCancelacionReciboId, ref string comentario)
        {
            

            

            CPAGOBE doctoPagoBE = new CPAGOBE();
            CPAGOD doctoPagoD = new CPAGOD();
            doctoPagoBE.IID = pagoId;
            doctoPagoBE = doctoPagoD.seleccionarPAGO(doctoPagoBE, null);
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
            if (doctoBE == null)
            {

                comentario = "El registro no tiene recibo electronico";
                return true;
            }

            if (doctoBE.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_COMPLETO)
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

                    if (!doctoD.RECIBOELECTRONICO_P_CANCELAR(pagoId, CurrentUserID.CurrentUser.IID, ref doctoCancelacionReciboId, fTrans))
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
        



        private void BTEliminar_Click(object sender, EventArgs e)
        {


            if (MessageBox.Show("Esta seguro que desea revertir el abono? ", "Confirmacion", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            if (RevertirPago(true))
            {
                MessageBox.Show("El pago se ha revertido");
            }
          
        }


        private void seleccionarCuentaPagoCliente()
        {

            Contabilidad.WFPersonaCuentasBancos wf = new Contabilidad.WFPersonaCuentasBancos(m_clienteId,"");
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
            int cuenta = cuentaBancoD.CantidadCuentasCliente(m_clienteId, null);
            return cuenta > 0;
        }

        private void BTRecibo_Click(object sender, EventArgs e)
        {
            imprimirRecibo();
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
        
    }
}
