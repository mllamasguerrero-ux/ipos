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

namespace iPos
{
    public partial class WFPagoMovil : iPos.Tools.ScreenConfigurableForm
    {

        long CLIENTEID = 0;
        long COBRANZAID = 0;
        long PAGOMOVILID = 0;
        //string CLAVE;
        public CPERSONABE m_cliente = null;
        public CCOBRANZAMOVILBE m_cobranza = null; 
        public CPAGOMOVILBE m_doctoPago = null;

        decimal m_montoAAplicar = 0;

        bool m_bSaltar2doPaso = false;


        public string opc = "Agregar";

        public WFPagoMovil()
        {
            InitializeComponent();
        }
        public WFPagoMovil(long clienteid)
            : this()
        {
            CLIENTEID = clienteid;
        }
        public WFPagoMovil(long clienteid, long cobranzaid, decimal saldo)
            : this(clienteid)
        {
            COBRANZAID = cobranzaid;
            m_montoAAplicar = saldo;

            PA_ABONOTextBox.Text = saldo.ToString("N2");
        }

        public WFPagoMovil(string str, long pagoMovilId)
            : this()
        {
            PAGOMOVILID = pagoMovilId;
        }

        private void WFPagoMovil_Load(object sender, EventArgs e)
        {
            configuraLaPantalla(false, true);
            //string strBuffer = "";
            this.ComboBanco.llenarDatos();
            this.ComboBanco.SelectedIndex = -1;
            this.FormaPagoComboBox.SelectedIndex = 0;
            pnlBancario.Enabled = false; 


            if (PAGOMOVILID == 0)
            {

                if (CLIENTEID != 0)
                {
                    LlenarClienteParaNuevo(CLIENTEID);

                }
                if (COBRANZAID != 0)
                {
                    CCOBRANZAMOVILBE cobranzaBE = new CCOBRANZAMOVILBE();
                    cobranzaBE.IID = COBRANZAID;
                    CCOBRANZAMOVILD cobranzaD = new CCOBRANZAMOVILD();
                    cobranzaBE = cobranzaD.seleccionarCOBRANZAMOVIL(cobranzaBE, null);

                    if (cobranzaBE != null)
                        m_cobranza = cobranzaBE;

                }
                this.BTGuardar.Enabled = true;
                this.BTEliminar.Enabled = false;
                btnReenviar.Enabled = false;
            }
            else
            {
                opc = "Cambiar";
                LlenarDatosDeBase();

                this.BTGuardar.Enabled = false;

                prepare2doPaso(PAGOMOVILID);

                if(/*m_doctoPago.IENVIADOWS.Equals("S") ||*/ m_doctoPago.IESTATUS == DBValues._DOCTO_ESTATUS_CANCELADA || m_doctoPago.ITIPOPAGOID == DBValues._TIPOPAGOMOVIL_CANCELACION)
                {
                    cOBRANZAMOVILBYIDDataGridView.ReadOnly = true;
                    btnAplicar.Enabled = false;
                    btnReenviar.Enabled = true;
                    this.BTEliminar.Enabled = false;
                }
                else if (m_doctoPago.IESTATUS == DBValues._DOCTO_ESTATUS_COMPLETO)
                {
                    cOBRANZAMOVILBYIDDataGridView.ReadOnly = true;
                    btnAplicar.Enabled = false;
                    btnReenviar.Enabled = true;
                    this.BTEliminar.Enabled = true;
                }
                else {
                    this.BTEliminar.Enabled = true;
                    cOBRANZAMOVILBYIDDataGridView.ReadOnly = false;
                    btnAplicar.Enabled = true;
                    btnReenviar.Enabled = false;
                }

            }
        }


        private void LlenarClienteParaNuevo(long clienteId)
        {
            if (clienteId == 0)
            {
                return;
            }

            CPERSONABE personaBE = new CPERSONABE();
            personaBE.IID = CLIENTEID;
            CPERSONAD personaD = new CPERSONAD();
            personaBE = personaD.seleccionarPERSONA(personaBE, null);
            string strBuffer = "";

            if (personaBE != null)
            {
                m_cliente = personaBE;

                if (!(bool)m_cliente.isnull["IID"])
                {

                    this.CLIENTECLAVETextBox.DbValue = m_cliente.IID.ToString();
                    this.CLIENTECLAVETextBox.MostrarErrores = false;
                    this.CLIENTECLAVETextBox.MValidarEntrada(out strBuffer, 1);
                    this.CLIENTECLAVETextBox.MostrarErrores = true;
                }

            }
        }

        private bool LlenarDatosDeBase()
        {
            string strBuffer = "";
            CPAGOMOVILBE movilBE = new CPAGOMOVILBE();
            CPAGOMOVILD movilD = new CPAGOMOVILD();
            movilBE.IID = PAGOMOVILID;
            movilBE = movilD.seleccionarPAGOMOVIL(movilBE, null);

            m_doctoPago = movilBE;


            if (!(bool)m_doctoPago.isnull["IPERSONAID"])
            {

                this.CLIENTECLAVETextBox.DbValue = m_doctoPago.IPERSONAID.ToString();
                this.CLIENTECLAVETextBox.MostrarErrores = false;
                this.CLIENTECLAVETextBox.MValidarEntrada(out strBuffer, 1);
                this.CLIENTECLAVETextBox.MostrarErrores = true;
            }



            this.lblNumMovimiento.Text = PAGOMOVILID.ToString();
            this.PA_ABONOTextBox.Text = m_doctoPago.IIMPORTE.ToString("N2");

            if (m_doctoPago.IFORMAPAGOID < this.FormaPagoComboBox.Items.Count && m_doctoPago.IFORMAPAGOID > 0)
                this.FormaPagoComboBox.SelectedIndex = (int)m_doctoPago.IFORMAPAGOID - 1;
            

          

            if (!(bool)m_doctoPago.isnull["IBANCOTEXT"])
                this.ComboBanco.SelectedValue = m_doctoPago.IBANCOTEXT;
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

                /*if (!(bool)m_doctoPago.isnull["IFECHAELABORACION"])
                    this.DTPFechaElaboracion.Value = m_doctoPago.IFECHAELABORACION;
                else
                    this.DTPFechaElaboracion.Value = DateTime.Now*/


                if (!(bool)m_doctoPago.isnull["IFECHARECEPCION"])
                    this.DTPFechaRecepcion.Value = m_doctoPago.IFECHARECEPCION;
                else
                    this.DTPFechaRecepcion.Value = DateTime.Now;
            }
            catch
            {
            }


            return true;
        }

        private CPAGOMOVILBE Guardar()
        {

            decimal monto = decimal.Parse(PA_ABONOTextBox.NumericValue.ToString());
            int clienteId = 0;

            if (this.CLIENTECLAVETextBox.Text == "")
            {
                MessageBox.Show("Seleccione un cliente");
                return null;
            }
                
            clienteId = Int32.Parse(this.CLIENTECLAVETextBox.DbValue.ToString());
            
            if(clienteId <= 0)
            {
                
                MessageBox.Show("Cliente no valido");
                return null;
            }

            if (monto <= 0)
            {
                MessageBox.Show("El abono no puede ser igual o menor que cero");
                return null;
            }

            if (FormaPagoComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione una forma de pago");
                return null;
            }

            
            if ((FormaPagoComboBox.SelectedIndex == 1 || FormaPagoComboBox.SelectedIndex == 2 || FormaPagoComboBox.SelectedIndex == 6)
                 && (this.TBReferencia.Text.Trim().Length == 0 || this.ComboBanco.SelectedIndex < 0))
            {
                MessageBox.Show("Debe seleccionar el banco y la referencia si esta pagando con tarjeta , cheque o transferencia");
                return null;
            }

            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();


                CPAGOMOVILBE pagoBE = new CPAGOMOVILBE();
                CPAGOMOVILD pagoD = new CPAGOMOVILD();
                pagoBE.IFECHA = DateTime.Now;
                pagoBE.IFECHAHORA = DateTime.Now;
                pagoBE.ICORTEID = CurrentUserID.CurrentUser.ICORTEID;
                if (this.ComboBanco.SelectedIndex >= 0)
                {
                    pagoBE.IBANCOTEXT = this.ComboBanco.SelectedValue.ToString();
                }
                pagoBE.IREFERENCIABANCARIA = this.TBReferencia.Text;
                pagoBE.IIMPORTE = monto;
                pagoBE.IAPLICADO = 0;
                pagoBE.INOTAS = TBNotas.Text;

                pagoBE.IIMPORTERECIBIDO = monto;
                pagoBE.ITIPOPAGOID = DBValues._TIPOPAGOMOVIL_ENTRADA;
                pagoBE.IESTATUS = DBValues._DOCTO_ESTATUS_BORRADOR;
                pagoBE.IPERSONAID = clienteId;
                pagoBE.IPERSONACLAVE = this.CLIENTECLAVETextBox.Text;
                pagoBE.IFECHARECEPCION = DTPFechaRecepcion.Value;
                pagoBE.IFECHAELABORACION = pagoBE.IFECHA;/*DTPFechaElaboracion.Value;*/
                //pagoBE.IBANCOTEXT = this.ComboBanco.SelectedText;


                if (FormaPagoComboBox.SelectedIndex >= 0)
                    pagoBE.IFORMAPAGOID = FormaPagoComboBox.SelectedIndex + 1;
                else
                    pagoBE.IFORMAPAGOID = 1;



                /*switch (FormaPagoComboBox.SelectedIndex)
                {

                    case 0: pagoBE.IFORMAPAGOID = 1; break;
                    case 1: pagoBE.IFORMAPAGOID = 2; break;
                    case 2: pagoBE.IFORMAPAGOID = 3; break;
                    case 3: pagoBE.IFORMAPAGOID = 5; break;
                    case 4: pagoBE.IFORMAPAGOID = 15; break;
                    case 5: pagoBE.IFORMAPAGOID = 16; break;
                    default: pagoBE.IFORMAPAGOID = 1; break;
                }*/
                pagoBE = pagoD.AgregarPAGOMOVILD(pagoBE, fTrans);
                if (pagoBE == null)
                {
                    fTrans.Rollback();
                    MessageBox.Show(pagoD.IComentario);
                    throw new Exception();
                }


                fTrans.Commit();
                fConn.Close();
                prepare2doPaso(pagoBE.IID);

            }
            catch
            {
                fConn.Close();
            }
            finally
            {
                fConn.Close();
            }


            return null;
        }

        private void LlenarGridAplicacion(int personaId, int pagoMovilId)
        {
            try
            {
                this.cOBRANZAMOVILBYIDTableAdapter.Fill(this.dSMovil2.COBRANZAMOVILBYID, pagoMovilId, personaId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void prepare2doPaso(long pagoMovilId )
        {
            pnl2doPaso.Enabled = true;
            BTGuardar.Enabled = false;
            BTEliminar.Enabled = true;
            PAGOMOVILID = pagoMovilId;


            CPAGOMOVILBE pagoMovilBE = new CPAGOMOVILBE();
            CPAGOMOVILD pagoMovilD = new CPAGOMOVILD();

            pagoMovilBE.IID = PAGOMOVILID;
            pagoMovilBE = pagoMovilD.seleccionarPAGOMOVIL(pagoMovilBE, null);

            this.m_doctoPago = pagoMovilBE;

            if (pagoMovilBE == null)
            {
                MessageBox.Show("No se encontro el pago");
                return;
            }

            TBACuenta.Text = (pagoMovilBE.IIMPORTE - pagoMovilBE.IAPLICADO).ToString("N2");

            LlenarGridAplicacion((int)pagoMovilBE.IPERSONAID, (int)PAGOMOVILID);


            preAplicarPagoACobranzaIfApplies();
            SumaAbonos();

            if(m_bSaltar2doPaso)
            {
                m_bSaltar2doPaso = false;
                AplicarPagos(false);
            }


        }

        private void preAplicarPagoACobranzaIfApplies()
        {
            decimal montoAPreasignar = this.m_doctoPago.IIMPORTE ;

            if(m_doctoPago != null && m_doctoPago.IESTATUS == DBValues._DOCTO_ESTATUS_BORRADOR && this.COBRANZAID > 0)
            {
                foreach (DataGridViewRow row in cOBRANZAMOVILBYIDDataGridView.Rows)
                {
                    long recCobranzaId = long.Parse(row.Cells["DGID"].Value.ToString());

                    if(recCobranzaId == this.COBRANZAID)
                    {
                        decimal saldoAnterior = Decimal.Parse(row.Cells["DGSALDOMOVIL"].Value.ToString());

                        if (saldoAnterior >= montoAPreasignar)
                        {
                            row.Cells["DGPAGOACTUAL"].Value = montoAPreasignar;
                            m_bSaltar2doPaso = true;
                        }
                        else
                        {
                            row.Cells["DGPAGOACTUAL"].Value = saldoAnterior;

                        }
                        return;
                            
                    }
                }
            }
        }

        private void cOBRANZAMOVILBYIDDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
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

        private void BTGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }



        private void AplicarPagos(bool bExcedenteACambio)
        {
             FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            //bool bRes = false ;
            //int count = 0;

            CDOCTOPAGOMOVILD pagoMovilD = new CDOCTOPAGOMOVILD();
            

            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();


                decimal saldoPendienteAAplicar = this.m_doctoPago.IIMPORTE - m_montoAAplicar;

                int iLastRowIndexApplied = -1;
                foreach (DataGridViewRow row in cOBRANZAMOVILBYIDDataGridView.Rows)
                {
                  decimal  importe = Decimal.Parse(row.Cells["DGPAGOACTUAL"].Value.ToString());
                  if (importe > 0)
                      iLastRowIndexApplied = row.Index;
                }

                foreach (DataGridViewRow row in cOBRANZAMOVILBYIDDataGridView.Rows)
                {

                    if (row.Index == cOBRANZAMOVILBYIDDataGridView.NewRowIndex)
                    {
                        continue;
                    }

                    decimal saldoAnterior = 0, saldoNuevo = 0, importe = 0;
                    saldoAnterior = Decimal.Parse(row.Cells["DGSALDOMOVIL"].Value.ToString());
                    importe = Decimal.Parse(row.Cells["DGPAGOACTUAL"].Value.ToString());
                    saldoNuevo = saldoAnterior - importe;


                    CDOCTOPAGOMOVILBE objRecBE = new CDOCTOPAGOMOVILBE();
                    objRecBE.ICOBRANZAID = long.Parse(row.Cells["DGID"].Value.ToString());
                    objRecBE.IVENTACOBRANZA = row.Cells["DGVENTA"].Value.ToString();
                    objRecBE.IIMPORTE = importe;
                    objRecBE.IFECHA = DateTime.Today;
                    objRecBE.ICORTEID = CurrentUserID.CurrentUser.ICORTEID;
                    objRecBE.IPAGOMOVILID = m_doctoPago.IID;
                    objRecBE.ISALDOANTERIOR = saldoAnterior;
                    objRecBE.ISALDONUEVO = saldoNuevo;


                    if (iLastRowIndexApplied == row.Index && saldoPendienteAAplicar > 0)
                        objRecBE.ISALDOPAGO = saldoPendienteAAplicar;
                    else
                        objRecBE.ISALDOPAGO = 0;


                    if(!pagoMovilD.RegistrarPagoMovil(objRecBE,fTrans))
                    {
                        fTrans.Rollback();
                        fConn.Close();

                        MessageBox.Show(pagoMovilD.IComentario);
                        return ;
                    }
                }

                
                CPAGOMOVILBE pagoMovilBE = new CPAGOMOVILBE();
                CPAGOMOVILD pagoMovilDHdr = new CPAGOMOVILD();

                pagoMovilBE.IID = m_doctoPago.IID;
                pagoMovilBE.IESTATUS = DBValues._DOCTO_ESTATUS_COMPLETO;

                if (bExcedenteACambio)
                    pagoMovilBE.IIMPORTECAMBIO = m_montoAAplicar;
                else
                    pagoMovilBE.IIMPORTECAMBIO = 0;


                if (!pagoMovilDHdr.CambiarPARAAPLICARPAGOMOVILD(pagoMovilBE, pagoMovilBE, fTrans))
                {

                    fTrans.Rollback();
                    fConn.Close();

                    MessageBox.Show(pagoMovilDHdr.IComentario);
                    return;
                }

                    
                fTrans.Commit();
                fConn.Close();

                if(CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 3 || CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 4)
                {
                    WFEnvioPagoMovil_3 envioPagoProcess = new WFEnvioPagoMovil_3(m_doctoPago.IID);
                    envioPagoProcess.ShowDialog();
                    envioPagoProcess.Dispose();
                    GC.SuppressFinalize(envioPagoProcess);

                }
                else 
                {

                    WFEnvioPagoMovil envioPagoProcess = new WFEnvioPagoMovil(m_doctoPago.IID);
                    envioPagoProcess.ShowDialog();
                    envioPagoProcess.Dispose();
                    GC.SuppressFinalize(envioPagoProcess);
                }


                WFImportarPendientesMovilcs envioPendientes = new WFImportarPendientesMovilcs(false);
                envioPendientes.ShowDialog();
                envioPendientes.Dispose();
                GC.SuppressFinalize(envioPendientes);

                this.Close();

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
                MessageBox.Show(ex.Message);
                fConn.Close();
            }
            finally
            {
                fConn.Close();
            }

        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            bool bExcedenteACambio = false;

            if ((this.m_doctoPago.IIMPORTE - m_montoAAplicar) > 0)
            {
                WFMovilPagoRestante wf = new WFMovilPagoRestante();
                wf.ShowDialog();
                
                switch(wf.m_iRestanteSelection)
                {
                    case 0:
                    case 1:
                        //bExcedenteACambio = true;
                        break;
                    case 3:
                        break;
                    case 2:
                        {
                            if (wf.m_rtnDataRow != null)
                                AgregarPagoRowBasadoEnCobranzaRow(wf.m_rtnDataRow);
                        }
                        return;

                    default:
                        return;
                }
                wf.Dispose();
                GC.SuppressFinalize(wf);
            }

            AplicarPagos(bExcedenteACambio);
        }


        private void AgregarPagoRowBasadoEnCobranzaRow(DataRow row)
        {
            iPos.Movil.DSMovil2.COBRANZAMOVILRow dr = (iPos.Movil.DSMovil2.COBRANZAMOVILRow)row;
            iPos.Movil.DSMovil2.COBRANZAMOVILBYIDRow drNew = (iPos.Movil.DSMovil2.COBRANZAMOVILBYIDRow)dSMovil2.COBRANZAMOVILBYID.NewRow();

            drNew.ID = dr.ID;
            drNew.ACTIVO = dr.ACTIVO;
            drNew.CREADO = dr.CREADO;
            drNew.CREADOPOR_USERID = dr.CREADOPOR_USERID;
            drNew.MODIFICADO = dr.MODIFICADO;
            drNew.MODIFICADOPOR_USERID = dr.MODIFICADOPOR_USERID;
            drNew.COBRANZA = dr.COBRANZA;
            drNew.VENDEDOR = dr.VENDEDOR;
            drNew.VENTA = dr.VENTA;
            drNew.EMPRESA = dr.EMPRESA;
            drNew.CLIENTE = dr.CLIENTE;
            drNew.NOMBRE = dr.NOMBRE;
            drNew.FACTURA = dr.FACTURA;
            drNew.ESTATUS = dr.ESTATUS;
            drNew.OBS = dr.OBS;
            drNew.F_FACTURA = dr.F_FACTURA;
            drNew.F_PAGO = dr.F_PAGO;
            drNew.DIAS = dr.DIAS;
            drNew.TOTAL = dr.TOTAL;
            drNew.A_CUENTA = dr.A_CUENTA;
            drNew.SALDO = dr.SALDO;
            drNew.INT_COB = dr.INT_COB;
            drNew.INTERESES = dr.INTERESES;
            drNew.IMPOR_NETO = dr.IMPOR_NETO;
            drNew.PAGO = dr.PAGO;
            drNew.EFECTIVO = dr.EFECTIVO;
            drNew.DIFERENCIA = dr.DIFERENCIA;
            drNew.IMP_CHEQUE = dr.IMP_CHEQUE;
            drNew.BANCO = dr.BANCO;
            drNew.NUM_CHEQ = dr.NUM_CHEQ;
            drNew.INTERES = dr.INTERES;
            drNew.CAPITAL = dr.CAPITAL;
            drNew.OLLA = dr.OLLA;
            drNew.BLOQUEADO = dr.BLOQUEADO;
            drNew.FECHA = dr.FECHA;
            drNew.LLEVAR = dr.LLEVAR;
            drNew.SALDOMOVIL = dr.SALDOMOVIL;
            drNew.ABONOSMOVIL = dr.ABONOSMOVIL;
            drNew.PERSONAID = dr.PERSONAID;

            drNew.PAGOACTUAL = 0;
            drNew.SALDODESPUES = dr.SALDOMOVIL;

            dSMovil2.COBRANZAMOVILBYID.AddCOBRANZAMOVILBYIDRow(drNew);


        }

        private void SumaAbonos()
        {
            m_montoAAplicar = 0;
            DataRow dr;



            foreach (DataGridViewRow row in cOBRANZAMOVILBYIDDataGridView.Rows)
            {

                
                    decimal saldoAnterior = Decimal.Parse(row.Cells["DGSALDOMOVIL"].Value.ToString());
                    decimal dSaldoAAplicar = decimal.Parse(row.Cells["DGPAGOACTUAL"].Value.ToString());

                    if (dSaldoAAplicar > 0)
                    {
                        dr = (row.DataBoundItem as DataRowView).Row;
                        dr["PAGOACTUAL"] = dSaldoAAplicar;
                        dr["SALDODESPUES"] = saldoAnterior - dSaldoAAplicar;
                        m_montoAAplicar += dSaldoAAplicar;
                    }


               if (m_doctoPago.IESTATUS == DBValues._DOCTO_ESTATUS_BORRADOR)
               {
                    if (saldoAnterior - dSaldoAAplicar > 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                    }
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    dr = (row.DataBoundItem as DataRowView).Row;
                    dr["SALDODESPUES"] = 0;
                    dr["SALDOMOVIL"] = 0;
                }
            }



            this.TBACuenta.Text  =  (this.m_doctoPago.IIMPORTE - m_montoAAplicar).ToString("N2");

        }

        private void cOBRANZAMOVILBYIDDataGridView_Validated(object sender, DataGridViewCellEventArgs e)
        {
            SumaAbonos();
        }

        private void cOBRANZAMOVILBYIDDataGridView_Validating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string columnName = cOBRANZAMOVILBYIDDataGridView.Columns[e.ColumnIndex].Name;

            // Abort validation if cell is not in the CompanyName column.
            if (!columnName.Equals("DGPAGOACTUAL")) return;


            try
            {
                decimal dSaldoAnterior = 0;
                try
                {
                    dSaldoAnterior = decimal.Parse(cOBRANZAMOVILBYIDDataGridView.Rows[e.RowIndex].Cells["DGPAGOACTUAL"].Value.ToString());
                }
                catch
                {

                }
                

                decimal dSaldoAAplicar = decimal.Parse(e.FormattedValue.ToString());
                decimal dSaldo = decimal.Parse(cOBRANZAMOVILBYIDDataGridView.Rows[e.RowIndex].Cells["DGSALDOMOVIL"].Value.ToString());


                if (dSaldoAAplicar > dSaldo || dSaldoAAplicar < 0)
                {
                    MessageBox.Show("El saldo a aplicar no puede ser mayor que el saldo de la transaccion ni menor que cero");
                    e.Cancel = true;
                }

                decimal saldoDocto = m_doctoPago.IIMPORTE;

                if ((m_montoAAplicar - dSaldoAnterior + dSaldoAAplicar) > saldoDocto)
                {

                    MessageBox.Show("se excederia el saldo posible a aplicar");
                    e.Cancel = true;
                }


            }
            catch
            {
            }
        }

        private void cOBRANZAMOVILBYIDDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

            DataGridView view = (DataGridView)sender;
            MessageBox.Show("Dato invalido , porfavor ingrese un dato valido");
            e.ThrowException = false;
        }

        private void BTEliminar_Click(object sender, EventArgs e)
        {

            CPAGOMOVILD pagoMOVILD = new CPAGOMOVILD();
            CPAGOMOVILBE pagoBE = new CPAGOMOVILBE();
            pagoBE.IID = m_doctoPago.IID;
            pagoBE = pagoMOVILD.seleccionarPAGOMOVIL(pagoBE, null);


            if (pagoBE.IENVIADOWS.Equals("S"))
            {

                WFEliminacionPagoMovil envioPagoProcess = new WFEliminacionPagoMovil(m_doctoPago.IID);
                envioPagoProcess.ShowDialog();
                bool bEliminado = envioPagoProcess.bEliminado;
                envioPagoProcess.Dispose();
                GC.SuppressFinalize(envioPagoProcess);

                if (bEliminado)
                {

                    this.Close();
                }
            }
            else {

                pagoBE = new CPAGOMOVILBE();
                pagoBE.IID = m_doctoPago.IID;
                pagoBE.ICORTEID = CurrentUserID.CurrentUser.ICORTEID;
            
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            

            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                
                if(!pagoMOVILD.CancelarPAGOMOVILD(pagoBE, fTrans ))
                {

                    fTrans.Rollback();
                    fConn.Close();

                    MessageBox.Show(pagoMOVILD.IComentario);
                    return;
                }
                
                fTrans.Commit();
                fConn.Close();
                MessageBox.Show("Se cancelo el pago");

                this.Close();

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
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fConn.Close();
            }
            }

        }

        private void btnReenviar_Click(object sender, EventArgs e)
        {

            WFEnvioPagoMovil envioPagoProcess = new WFEnvioPagoMovil(m_doctoPago.IID);
            envioPagoProcess.ShowDialog();
            envioPagoProcess.Dispose();
            GC.SuppressFinalize(envioPagoProcess);



            WFImportarPendientesMovilcs envioPendientes = new WFImportarPendientesMovilcs(false);
            envioPendientes.ShowDialog();
            envioPendientes.Dispose();
            GC.SuppressFinalize(envioPendientes);

            this.Close();
        }

    }
}
