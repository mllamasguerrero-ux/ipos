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

namespace iPos
{
    public partial class WFAnticipos : IposForm
    {
        CDOCTOBE m_Docto;
        long m_ClienteId;
        tipoTransaccionV m_tipoTransaccion;
        //long m_pagoId = 0;
        CDOCTOPAGOBE m_doctoPago;
        long m_ventaFuturoId = 0;

        public WFAnticipos()
        {
            InitializeComponent();
            m_tipoTransaccion = tipoTransaccionV.t_venta;
            m_doctoPago = new CDOCTOPAGOBE();
        }


        public WFAnticipos(tipoTransaccionV tipoTransaccion)
            : this()
        {
            m_tipoTransaccion = tipoTransaccion;
        }


        public WFAnticipos(tipoTransaccionV tipoTransaccion, long ventaFuturoId)
            : this(tipoTransaccion)
        {
            m_ventaFuturoId = ventaFuturoId;
        }


        private void WFAnticipos_Load(object sender, EventArgs e)
        {

            if (!ChecarCorteActivo())
                return;

            ChecarPermisosParaCambiarFechas();

            this.ComboBanco.llenarDatos();
            this.ComboBanco.SelectedIndex = -1;

            m_Docto = new CDOCTOBE();
            m_ClienteId = 1;

            switch (m_tipoTransaccion)
            {
                case tipoTransaccionV.t_compra:
                    {
                        lblTitulo.Text = "Anticipos de compras";
                        pnlProveedor.Visible = true;
                        //lblPersona.Text = "Proveedor";
                    }
                    break;
                default:
                        lblTitulo.Text = "Anticipos de ventas";
                        pnlCliente.Visible = true;
                        //lblPersona.Text = "Cliente";
                    break;

            }

            HabilitacionesVentaFuturo();
            if(this.m_ventaFuturoId > 0)
            {

                cargarVentaFuturo(this.m_ventaFuturoId);
            }

        }

        private void HabilitacionesVentaFuturo()
        {
            if( CurrentUserID.CurrentParameters.IHABVENTASAFUTURO != null && CurrentUserID.CurrentParameters.IHABVENTASAFUTURO == "S")
            {

                pnlVentaFuturo.Enabled = false;
                pnlVentaFuturo.Visible = false;
                return;
            }

            if (m_tipoTransaccion != tipoTransaccionV.t_venta  || (m_Docto != null && m_Docto.IID > 0))
            {
                pnlVentaFuturo.Enabled = false;

                if(m_tipoTransaccion != tipoTransaccionV.t_venta)
                {
                    pnlVentaFuturo.Visible = false;
                }
                else
                {
                    pnlVentaFuturo.Visible = true;
                }
            }
            else
            {
                pnlVentaFuturo.Enabled = true;
                pnlVentaFuturo.Visible = true;
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
        /*
        private void SeleccionarTransaccion()
        {
            m_doctoPago = new CDOCTOPAGOBE();

            int tipoDoctoParaLista = (m_tipoTransaccion == tipoTransaccionV.t_compra) ? 11 : 0;

            WFSaldosListaTransacciones look = new WFSaldosListaTransacciones((int)DBValues._DOCTO_ESTATUS_COMPLETO, tipoDoctoParaLista);
            look.ShowDialog();


            DataRow dr = look.m_rtnDataRow;
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

            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            SeleccionarTransaccion();
        }*/


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
            limpiarDatosPersona();

            if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTAAPARTADO)
            {
                llenarDatosPersonaApartado();
                return;
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

                //LBCliente.Text = personaBE.ICLAVE;

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
            
        }

        public void llenarDatosTransaccion(bool bGetfromdb)
        {
            limpiarDatosTransaccion();
            if (bGetfromdb)
            {
                CDOCTOD vData = new CDOCTOD();
                m_Docto = vData.seleccionarDOCTO(m_Docto, null);
            }

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
                    this.lblSaldo.Text = (m_Docto.ISALDO * -1).ToString();
                }
                if (!(bool)m_Docto.isnull["IFOLIOORIGENFACTURADO"])
                {
                    this.lblFolioFacturado.Text = m_Docto.IFOLIOORIGENFACTURADO.ToString();
                }

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
                
            }
        }

        private void BTGuardar_Click(object sender, EventArgs e)
        {

            CDOCTOD doctoD = new CDOCTOD();
            if (m_doctoPago == null)
            {
                if (GuardarPago())
                {

                    if (doctoD.ActualizarTotalAnticipo(m_Docto, m_Docto, null))
                    {

                        LimpiarManteniendoDocto();
                        LlenarGridAbono();
                        llenarDatosPersona();
                        llenarDatosTransaccion(true);
                        GridFocusLastRow();

                        btnImprimir.Enabled = true;
                        btnCancelar.Enabled = true;
                    }
                }
            }
            else if (!(bool)m_doctoPago.isnull["IID"])
            {
                if (EditarPago())
                {
                    if (doctoD.ActualizarTotalAnticipo(m_Docto, m_Docto, null))
                    {
                        LimpiarManteniendoDocto();
                        LlenarGridAbono();
                        llenarDatosPersona();
                        llenarDatosTransaccion(true);
                        GridFocusLastRow();

                        btnImprimir.Enabled = true;
                        btnCancelar.Enabled = true;
                    }
                }

            }
            else
            {
                if (GuardarPago())
                {
                    if (doctoD.ActualizarTotalAnticipo(m_Docto, m_Docto, null))
                    {
                        LimpiarManteniendoDocto();
                        LlenarGridAbono();
                        llenarDatosPersona();
                        llenarDatosTransaccion(true);
                        GridFocusLastRow();

                        btnImprimir.Enabled = true;
                        btnCancelar.Enabled = true;
                    }
                }
            }

        }

        private bool EditarPago()
        {

            CDOCTOD doctoD = new CDOCTOD();
            bool retorno = false;
            if (MessageBox.Show("Esto revertira el pago anterior y agregara el nuevo pago modificado. Esta seguro de que desea hacerlo ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return retorno;
            }

            if (RevertirPago(false))
                if (GuardarPago())
                    if (doctoD.ActualizarTotalAnticipo(m_Docto, m_Docto, null))
                    {
                        retorno = true;
                    }

            return retorno;

        }


        private bool GuardarPago()
        {
            bool retorno = false;
            bool messageEntregarMercancia = false;
            bool messageRecibirMercancia = false;

            decimal monto = decimal.Parse(PA_ABONOTextBox.NumericValue.ToString());

            if (monto <= 0)
            {
                MessageBox.Show("El abono no puede ser igual o menor que cero");
            }
            /*if (m_Docto.ISALDO < monto)
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
            }*/



            if (FormaPagoComboBox.SelectedIndex < 0 || monto <= 0)
                return false;

            if ((FormaPagoComboBox.SelectedIndex == 1 || FormaPagoComboBox.SelectedIndex == 2 || FormaPagoComboBox.SelectedIndex == 3 || FormaPagoComboBox.SelectedIndex == 4 || FormaPagoComboBox.SelectedIndex == 6)
                 && (this.TBReferencia.Text.Trim().Length == 0 || this.ComboBanco.SelectedIndex < 0))
            {
                MessageBox.Show("Debe seleccionar el banco y la referencia si esta pagando con tarjeta , cheque o transferencia");
                return false;
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
                pagoBE.ICORTEID = CurrentUserID.CurrentUser.ICORTEID;
                if(this.ComboBanco.SelectedIndex >= 0)
                    pagoBE.IBANCO = long.Parse(this.ComboBanco.SelectedValue.ToString());
                pagoBE.IREFERENCIABANCARIA = this.TBReferencia.Text;
                pagoBE.IIMPORTE = monto;
                pagoBE.INOTAS = "";

                pagoBE.IIMPORTERECIBIDO = monto;


                switch (FormaPagoComboBox.SelectedIndex)
                {

                    case 0: pagoBE.IFORMAPAGOID = DBValues._FORMA_PAGO_EFECTIVO; pagoBE.IFORMAPAGOSATID = DBValues._FORMA_PAGOSAT_EFECTIVO; break;
                    case 1: pagoBE.IFORMAPAGOID = DBValues._FORMA_PAGO_TARJETA; pagoBE.IFORMAPAGOSATID = DBValues._FORMA_PAGOSAT_TARJETACREDITO; break;
                    case 2: pagoBE.IFORMAPAGOID = DBValues._FORMA_PAGO_TARJETA; pagoBE.IFORMAPAGOSATID = DBValues._FORMA_PAGOSAT_TARJETADEBITO; break;
                    case 3: pagoBE.IFORMAPAGOID = DBValues._FORMA_PAGO_TARJETA; pagoBE.IFORMAPAGOSATID = DBValues._FORMA_PAGOSAT_TARJETASERVICIO; break;
                    case 4: pagoBE.IFORMAPAGOID = DBValues._FORMA_PAGO_CHEQUE; pagoBE.IFORMAPAGOSATID = DBValues._FORMA_PAGOSAT_CHEQUE; break;
                    case 5: pagoBE.IFORMAPAGOID = DBValues._FORMA_PAGO_VALE; pagoBE.IFORMAPAGOSATID = DBValues._FORMA_PAGOSAT_VALE; break;
                    case 6: pagoBE.IFORMAPAGOID = DBValues._FORMA_PAGO_TRANSFERENCIA; pagoBE.IFORMAPAGOSATID = DBValues._FORMA_PAGOSAT_TRANSFERENCIA; break;
                    case 7: pagoBE.IFORMAPAGOID = DBValues._FORMA_PAGO_NOIDENTIFICADO; pagoBE.IFORMAPAGOSATID = DBValues._FORMA_PAGOSAT_OTRO; break;
                    default: pagoBE.IFORMAPAGOID = DBValues._FORMA_PAGO_EFECTIVO; pagoBE.IFORMAPAGOSATID = DBValues._FORMA_PAGOSAT_EFECTIVO; break;
                }
                


                switch (this.m_tipoTransaccion)
                {
                    case tipoTransaccionV.t_venta:

                        if (m_Docto == null || (bool)m_Docto.isnull["IID"])
                        {
                            CDOCTOD doctoD = new CDOCTOD();
                            m_Docto = new CDOCTOBE();
                            m_Docto.IALMACENID = DBValues._ALMACEN_DEFAULT;
                            m_Docto.ISUCURSALID  = CurrentUserID.CurrentParameters.ISUCURSALID;
                            m_Docto.ITIPODOCTOID = DBValues._DOCTO_TIPO_ANTICIPO_CLIENTES;
                            m_Docto.IVENDEDORID = CurrentUserID.CurrentUser.IID;
                            m_Docto.IPERSONAID = m_ClienteId;
                            m_Docto.ICAJAID = iPos.CurrentUserID.CurrentCompania.IEM_CAJA;
                            m_Docto.IREFERENCIA = "";
                            m_Docto.IREFERENCIAS = "";
                            m_Docto.IFECHA = DateTime.Now;
                            m_Docto.IVENCE = DateTime.Now;
                            
                            if(this.m_ventaFuturoId > 0)
                            {
                                m_Docto.IVENTAFUTUID = this.m_ventaFuturoId;
                            }

                            if (!doctoD.ANTICIPODOCTO_INSERTAR(ref m_Docto, fTrans))
                            {

                                fTrans.Rollback();
                                MessageBox.Show(doctoD.IComentario);
                                throw new Exception();
                            }

                            HabilitacionesVentaFuturo();
                        }


                        pagoBE.IDOCTOID = m_Docto.IID;
                        pagoBE.ITIPOPAGOID = DBValues._TIPOPAGO_ENTRADA;
                        break;
                   
                    /*case tipoTransaccionV.t_ventaapartado:

                        pagoBE.IDOCTOID = m_Docto.IID;
                        pagoBE.ITIPOPAGOID = DBValues._TIPOPAGO_ENTRADA;
                        break;*/
                   

                    case tipoTransaccionV.t_compra:

                        if (m_Docto == null || (bool)m_Docto.isnull["IID"])
                        {
                            CDOCTOD doctoD = new CDOCTOD();
                            m_Docto = new CDOCTOBE();
                            m_Docto.IALMACENID = DBValues._ALMACEN_DEFAULT;
                            m_Docto.ISUCURSALID = CurrentUserID.CurrentParameters.ISUCURSALID;
                            m_Docto.ITIPODOCTOID = DBValues._DOCTO_TIPO_ANTICIPO_PROVEEDORES;
                            m_Docto.IVENDEDORID = CurrentUserID.CurrentUser.IID;
                            m_Docto.IPERSONAID = m_ClienteId;
                            m_Docto.ICAJAID = iPos.CurrentUserID.CurrentCompania.IEM_CAJA;
                            m_Docto.IREFERENCIA = "";
                            m_Docto.IREFERENCIAS = "";
                            m_Docto.IFECHA = DateTime.Now;
                            m_Docto.IVENCE = DateTime.Now;

                            if (!doctoD.ANTICIPODOCTO_INSERTAR(ref m_Docto, fTrans))
                            {

                                fTrans.Rollback();
                                MessageBox.Show(doctoD.IComentario);
                                throw new Exception();
                            }
                        }

                        pagoBE.IDOCTOSALIDAID = m_Docto.IID;
                        pagoBE.ITIPOPAGOID = DBValues._TIPOPAGO_SALIDA;
                        break;



                }

                pagoBE.IESAPARTADO = (this.m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTAAPARTADO) ? "S": "N";
                pagoBE.IESPAGOINICIAL = DBValues._DB_BOOLVALUE_NO;

                pagoBE.ITIPOABONOID = DBValues._TIPO_ABONO_ABONO;

                pagoBE.IFECHAELABORACION = DTPFechaElaboracion.Value;
                pagoBE.IFECHARECEPCION = DTPFechaRecepcion.Value;

                pagoBE = pagoD.InsertarDOCTOPAGOD(pagoBE, fTrans);
                if (pagoBE == null)
                {
                    fTrans.Rollback();
                    MessageBox.Show(pagoD.IComentario);
                    throw new Exception();
                }
                m_doctoPago = pagoBE;

                /*if (m_Docto.ITIPODOCTOID != DBValues._DOCTO_TIPO_VENTAAPARTADO)
                {*/
                    if (!pagoD.AjustarSaldosPersona(m_Docto.IPERSONAID, fTrans))
                    {

                        fTrans.Rollback();
                        MessageBox.Show(pagoD.IComentario);
                        throw new Exception();
                    }
                //}
                /*else
                {
                    if (!pagoD.AjustarSaldosPersonaApartado(m_Docto.IPERSONAAPARTADOID, fTrans))
                    {

                        fTrans.Rollback();
                        MessageBox.Show(pagoD.IComentario);
                        throw new Exception();
                    }
                }*/



               /* if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTAAPARTADO)
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
                */


                fTrans.Commit();
                fConn.Close();
                retorno = true;
                ImprimirTicket();
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
                    if (formaPagoId != 1 && formaPagoId != 2 && formaPagoId != 3 && formaPagoId != 5 && formaPagoId != 15 && formaPagoId != 16)
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
                    this.BTEliminar.Enabled = true;
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
            this.PA_ABONOTextBox.Text = m_doctoPago.IIMPORTE.ToString("N2");

            switch (m_doctoPago.IFORMAPAGOSATID)
            {
                case DBValues._FORMA_PAGOSAT_EFECTIVO: FormaPagoComboBox.SelectedIndex = 0; break;
                case DBValues._FORMA_PAGOSAT_TARJETACREDITO: FormaPagoComboBox.SelectedIndex = 1; break;
                case DBValues._FORMA_PAGOSAT_TARJETADEBITO: FormaPagoComboBox.SelectedIndex = 2; break;
                case DBValues._FORMA_PAGOSAT_TARJETASERVICIO: FormaPagoComboBox.SelectedIndex = 3; break;
                case DBValues._FORMA_PAGOSAT_CHEQUE: FormaPagoComboBox.SelectedIndex = 4; break;
                case DBValues._FORMA_PAGOSAT_VALE: FormaPagoComboBox.SelectedIndex = 5; break;
                case DBValues._FORMA_PAGOSAT_TRANSFERENCIA: FormaPagoComboBox.SelectedIndex = 6; break;
                case DBValues._FORMA_PAGOSAT_OTRO: FormaPagoComboBox.SelectedIndex = 7; break;
                default: FormaPagoComboBox.SelectedIndex = 0; break;
            }

            if (!(bool)m_doctoPago.isnull["IBANCO"])
                this.ComboBanco.SelectedValue = m_doctoPago.IBANCO;
            else
                this.ComboBanco.SelectedIndex = -1;


            if (!(bool)m_doctoPago.isnull["IREFERENCIABANCARIA"])
                this.TBReferencia.Text = m_doctoPago.IREFERENCIABANCARIA;
            else
                this.TBReferencia.Text = "";

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
            }
            catch
            {
            }

        }

        private bool RevertirPago(bool bChecarReapartamiento)
        {
            bool retorno = false;
            bool messageRecibirMercancia = false;

            if (m_doctoPago == null)
                return false;

            CDOCTOPAGOD pagoD = new CDOCTOPAGOD();

            if (!(bool)m_doctoPago.isnull["IID"])
            {

                FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
                FbTransaction fTrans = null;
                try
                {

                    fConn.Open();
                    fTrans = fConn.BeginTransaction();
                    CDOCTOPAGOBE pagoBE = new CDOCTOPAGOBE();
                    if (!(bool)m_doctoPago.isnull["IBANCO"])
                        pagoBE.IBANCO = m_doctoPago.IBANCO;
                    pagoBE.IREFERENCIABANCARIA = m_doctoPago.IREFERENCIABANCARIA;
                    pagoBE.IFORMAPAGOID = m_doctoPago.IFORMAPAGOID;
                    pagoBE.IIMPORTE = m_doctoPago.IIMPORTE * -1;
                    pagoBE.IIMPORTERECIBIDO = m_doctoPago.IIMPORTERECIBIDO * -1;
                    pagoBE.IFECHAELABORACION = m_doctoPago.IFECHAELABORACION;
                    pagoBE.IFECHARECEPCION = m_doctoPago.IFECHARECEPCION;
                    pagoBE.INOTAS = m_doctoPago.INOTAS;
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
                    /*
                    if (m_doctoPago.ITIPOPAGOID == 1)
                        pagoBE.ITIPOPAGOID = 2;
                    else
                        pagoBE.ITIPOPAGOID = 1;*/


                    if (pagoD.InsertarDOCTOPAGOD(pagoBE, fTrans) == null)
                    {
                        fTrans.Rollback();
                        MessageBox.Show(pagoD.IComentario);
                        throw new Exception();
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
            this.lblNumMovimiento.Text = "";
            this.PA_ABONOTextBox.Text = "0";
            this.FormaPagoComboBox.SelectedIndex = -1;
                this.ComboBanco.SelectedIndex = -1;
                this.TBReferencia.Text = "";
                this.TBNotas.Text = "";
                this.DTPFechaElaboracion.Value = DateTime.Now;
                this.DTPFechaRecepcion.Value = DateTime.Now;

                this.pnlAbono.Enabled = true;
                this.pnlBancario.Enabled = false;
                this.BTGuardar.Enabled = true;
                this.BTEliminar.Enabled = false;

        }

        private void FormaPagoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FormaPagoComboBox.SelectedIndex > 0)
            {
                this.pnlBancario.Enabled = true;
            }
            else
            {
                pnlBancario.Enabled = false; 
                this.ComboBanco.SelectedIndex = -1;
                this.TBReferencia.Text = "";
            }
        }

        private void btnNuevoPago_Click(object sender, EventArgs e)
        {

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


        private void validarCliente()
        {
            if (this.CLIENTEIDTextBox.Text != "")
            {
                try
                {
                    m_ClienteId = Int32.Parse(this.CLIENTEIDTextBox.DbValue.ToString());
                }
                catch
                {
                }

                if (m_ClienteId != 0)
                {
                    llenarDatosPersona();
                    pnlAbono.Enabled = true;
                    this.BTGuardar.Enabled = true;
                    this.BTNuevo.Enabled = true;
                }
                else
                {
                    limpiarDatosPersona();
                    pnlAbono.Enabled = false;
                    this.BTGuardar.Enabled = false;
                    this.BTNuevo.Enabled = false;
                }

            }
            else
            {
                m_ClienteId = 0;
                limpiarDatosPersona();
                limpiarDatosTransaccion();
                m_Docto = new CDOCTOBE();
                pnlAbono.Enabled = false;
                this.BTGuardar.Enabled = false;
                this.BTNuevo.Enabled = false;
                LlenarGridAbono();

                btnImprimir.Enabled = false;
                btnCancelar.Enabled = false;
            }
        }

        private void CLIENTEIDTextBox_Validated(object sender, EventArgs e)
        {
            validarCliente();
            
        }

        private void PROVEEDOR1IDTextBox_Validated(object sender, EventArgs e)
        {
            if (this.PROVEEDOR1IDTextBox.Text != "")
            {
                try
                {
                    m_ClienteId = Int32.Parse(this.PROVEEDOR1IDTextBox.DbValue.ToString());
                }
                catch
                {
                }

                if (m_ClienteId != 0)
                {
                    llenarDatosPersona();
                    pnlAbono.Enabled = true;
                    this.BTGuardar.Enabled = true;
                    this.BTNuevo.Enabled = true;
                }
                else
                {
                    limpiarDatosPersona();
                    pnlAbono.Enabled = false;
                    this.BTGuardar.Enabled = false;
                    this.BTNuevo.Enabled = false;
                }

            }
            else
            {
                m_ClienteId = 0;
                limpiarDatosPersona();
                limpiarDatosTransaccion();
                m_Docto = new CDOCTOBE();
                pnlAbono.Enabled = false;
                this.BTGuardar.Enabled = false;
                this.BTNuevo.Enabled = false;
                LlenarGridAbono();

                btnImprimir.Enabled = false;
                btnCancelar.Enabled = false;
            }
        }

        private void btnSeleccionarAnticipo_Click(object sender, EventArgs e)
        {
            long tipoDocto = 0;
                switch (this.m_tipoTransaccion)
                {
                    case tipoTransaccionV.t_venta:
                        tipoDocto = DBValues._DOCTO_TIPO_ANTICIPO_CLIENTES;
                        break;
                    case tipoTransaccionV.t_compra:
                        tipoDocto = DBValues._DOCTO_TIPO_ANTICIPO_PROVEEDORES;
                        break;
                }
                WFAnticipoListaTransacciones look = new WFAnticipoListaTransacciones((int)DBValues._DOCTO_ESTATUS_COMPLETO, (int)tipoDocto);
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

                    //this.TBTransacccion.Text = m_Docto.IFOLIO.ToString("N0");

                    if (m_Docto.IESTATUSANTICIPOID == DBValues._DOCTO_ESTATUS_BORRADOR)
                    {
                        this.pnlAbono.Enabled = true;
                        this.BTGuardar.Enabled = true;
                        this.BTNuevo.Enabled = true;

                        

                        this.PA_ABONOTextBox.Focus();
                    }
                    else
                    {
                        this.pnlAbono.Enabled = false;
                        this.BTGuardar.Enabled = false;
                        this.BTNuevo.Enabled = false;
                    }

                    if (m_Docto.IESTATUSANTICIPOID == DBValues._DOCTO_ESTATUS_CANCELADA)
                    {
                        this.btnCancelar.Enabled = false;
                        this.btnImprimir.Enabled = false;
                    }
                    else
                    {

                        this.btnCancelar.Enabled = true;
                        this.btnImprimir.Enabled = true;
                    }
                    
                    if(m_Docto.IVENTAFUTUID > 0)
                    {
                        cargarVentaFuturo(m_Docto.IVENTAFUTUID);
                    }

                }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (m_Docto.IESTATUSANTICIPOID == DBValues._DOCTO_ESTATUS_BORRADOR)
            {
                CDOCTOD doctoD = new CDOCTOD();
                WFAnticipoConcepto wf = new WFAnticipoConcepto();
                wf.ShowDialog();
                m_Docto.IREFERENCIAS = wf.m_concepto;

                doctoD.CompletarAnticipo(m_Docto, m_Docto, null);

                wf.Dispose();
                GC.SuppressFinalize(wf);
            }

            WFImpresionReciboLargo wf2 = new WFImpresionReciboLargo(m_Docto.IID,m_Docto.ITIPODOCTOID);
            wf2.ShowDialog();
            wf2.Dispose();
            GC.SuppressFinalize(wf2);

            IrANueva();
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CancelarAnticipoActual();
        }


        private bool CancelarAnticipoActual()
        {
            CDOCTOD pvd = new CDOCTOD();
            
           CDOCTOPAGOD doctPago = new CDOCTOPAGOD();

            if (m_Docto.IESTATUSANTICIPOID == DBValues._DOCTO_ESTATUS_CANCELADA)
                return false;

            if ((bool)m_Docto.isnull["IID"])
                return false;

            if (MessageBox.Show("Quiere cancelar el anticipo actual?", "Cancelar el anticipo actual", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return false;


            switch (m_Docto.ITIPODOCTOID)
            {
                case DBValues._DOCTO_TIPO_ANTICIPO_CLIENTES:
                    {
                        long statusDoctoId = m_Docto.IESTATUSDOCTOID;
                        long doctoIDCancelacion = 0;

                        if (pvd.CancelarAnticipoCliente(m_Docto, CurrentUserID.CurrentUser, ref doctoIDCancelacion, null))
                        {

                            doctPago.AjustarSaldosPersona(m_Docto.IPERSONAID, null);
                            MessageBox.Show("Anticipo cancelado");
                            IrANueva();
                        }
                        else
                        {
                            MessageBox.Show("ERRORES: " + pvd.IComentario.Replace("%", "\n"));
                            return false;
                        }
                    }
                    break;

                case DBValues._DOCTO_TIPO_ANTICIPO_PROVEEDORES:
                    {
                        long statusDoctoId = m_Docto.IESTATUSDOCTOID;
                        long doctoIDCancelacion = 0;

                        if (pvd.CancelarAnticipoProveedor(m_Docto, CurrentUserID.CurrentUser, ref doctoIDCancelacion, null))
                        {

                            doctPago.AjustarSaldosPersona(m_Docto.IPERSONAID, null);
                            MessageBox.Show("Anticipo cancelado");
                            IrANueva();
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




        void IrANueva()
        {
            m_ClienteId = 0;
            limpiarDatosPersona();
            limpiarDatosTransaccion();
            m_Docto = new CDOCTOBE();
            pnlAbono.Enabled = false;
            this.BTGuardar.Enabled = false;
            this.BTNuevo.Enabled = false;
            LlenarGridAbono();
            PROVEEDOR1IDTextBox.Text = "";
            CLIENTEIDTextBox.Text = "";
            btnImprimir.Enabled = false;
            btnCancelar.Enabled = false;


            lblDetalleVentaAFuturo.Text = "...";
            m_ventaFuturoId = 0;
            HabilitacionesVentaFuturo();
        }

        private void btnNuevoAnticipo_Click(object sender, EventArgs e)
        {
            IrANueva();
        }

        private void cargarVentaFuturo(long doctoIdVentaFuturo)
        {
            if (doctoIdVentaFuturo != 0)
            {
                CDOCTOBE doctoBE = new CDOCTOBE();
                doctoBE.IID = doctoIdVentaFuturo;
                CDOCTOD vData = new CDOCTOD();
                doctoBE = vData.seleccionarDOCTO(doctoBE, null);


                if (doctoBE != null)
                {

                    
                    if(m_ClienteId > 1 &&  doctoBE.IPERSONAID != m_ClienteId)
                    {
                        limpiarDatosVentaFuturo();
                        MessageBox.Show("El cliente de la venta a futuro no corresponde con el cliente actual");
                    }
                    else
                    {
                        TBVentaFuturoFolio.Text = doctoBE.IFOLIO.ToString();
                        m_ventaFuturoId = doctoBE.IID;
                        lblDetalleVentaAFuturo.Text = "Fecha : " + doctoBE.IFECHA.ToString("dd/MM/yyyy") + " Total : " + doctoBE.ITOTAL.ToString("N2");
                        asignarCliente(doctoBE.IPERSONAID);
                    }

                   
                }
                else
                {
                    limpiarDatosVentaFuturo();
                }
            }
            else
            {
                limpiarDatosVentaFuturo();
            }
        }


        private void limpiarDatosVentaFuturo()
        {

            TBVentaFuturoFolio.Text = "";
            m_ventaFuturoId = 0;
        }
        

        private void btnSeleccionarVentaFuturo_Click(object sender, EventArgs e)
        {
            WFLOOKUPVENTAS look = new WFLOOKUPVENTAS((int)DBValues._DOCTO_ESTATUS_COMPLETO, (int)DBValues._DOCTO_TIPO_VENTA_FUTURO, true);
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                cargarVentaFuturo(long.Parse(dr[0].ToString()));
            }
        }

        private void asignarCliente(long clienteId)
        {
            string strBuffer = "";
            m_ClienteId = clienteId;
            this.CLIENTEIDTextBox.DbValue = this.m_ClienteId.ToString();
            this.CLIENTEIDTextBox.MostrarErrores = false;
            this.CLIENTEIDTextBox.MValidarEntrada(out strBuffer, 1);
            this.CLIENTEIDTextBox.MostrarErrores = true;
            this.validarCliente();
        }

        private void TBVentaFuturoFolio_Leave(object sender, EventArgs e)
        {

            if (TBVentaFuturoFolio.ReadOnly)
                return;

            if(TBVentaFuturoFolio.Text.Trim().Length == 0)
            {

                limpiarDatosVentaFuturo();
                return;
            }

            try
            {

                CDOCTOBE doctoBE = new CDOCTOBE();
                doctoBE.IFOLIO = int.Parse(TBVentaFuturoFolio.Text);
                CDOCTOD vData = new CDOCTOD();
                doctoBE = vData.seleccionarDOCTO(m_Docto, null);

                if (doctoBE != null)
                {
                    cargarVentaFuturo(doctoBE.IID);
                }
                else
                {
                    limpiarDatosVentaFuturo();
                }
            }
            catch
            {
                limpiarDatosVentaFuturo();
            }
        }

        
    }
}
