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
using iPos.Cortes;
using FirebirdSql.Data.FirebirdClient;

namespace iPos
{
    public partial class CorteBilletes : IposForm
    {
        decimal m_saldoTotal = 0;
        decimal m_saldoTotalAnterior = 0;
        private CCORTEBE m_corteBE;
        CMONTOBILLETESBE m_montoBilletesBE;
        CPERSONABE m_personaBE = new CPERSONABE();
        //long m_doctoId = 0;
        long m_tipoMontoBilletesId = DBValues._TIPOMONTOBILLETESID_CORTE;
        public long m_montoBilletesId = 0;
        public FMain Fm = new FMain();

        long m_corteId = 0;
        long m_personaCorteId = 0;
        bool m_bModoPostEdicion = false;
        string nota;

        public CorteBilletes()
        {
            InitializeComponent();
        }


        public CorteBilletes(long corteId, long personaCorteId, bool bModoPostEdicion)
            : this()
        {
            m_corteId = corteId;
            m_personaCorteId = corteId;
            m_bModoPostEdicion = bModoPostEdicion;
        }

        /*public CorteBilletes(long doctoId, long tipoMontoBilletesId) : this()
        {
            m_doctoId = doctoId;
            m_tipoMontoBilletesId = tipoMontoBilletesId;
        }*/

        private void CorteBilletes_Load(object sender, EventArgs e)
        {

            RecargarReport();

            if (CurrentUserID.CurrentParameters.IABRIRCAJONALFINCORTE != null && CurrentUserID.CurrentParameters.IABRIRCAJONALFINCORTE.Equals("S"))
            {
                AbrirCajon();
            }


            //si no hay corte activo , salir de la pantalla
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            DateTime fechaCorte = DateTime.MinValue;
            if (!pvd.HayCorteActivo(ref fechaCorte, iPos.CurrentUserID.CurrentUser.IID))
            {
                MessageBox.Show("No hay corte abierto");
                this.Close();
                return;
            }
            this.LBCajero.Text = iPos.CurrentUserID.CurrentUser.IUSERNAME;
            this.LBFechaCorte.Text = fechaCorte.ToString("dd/MM/yyyy");


            CPERSONAD personaD = new CPERSONAD();
            m_personaBE.IID = m_personaCorteId == 0 ? iPos.CurrentUserID.CurrentUser.IID : m_personaCorteId;
            m_personaBE = personaD.seleccionarPERSONA(m_personaBE, null);

            m_montoBilletesBE = new CMONTOBILLETESBE();
            CMONTOBILLETESD montoBilletesD = new CMONTOBILLETESD();
            m_montoBilletesBE.ICORTEID = m_corteId == 0 ? m_personaBE.ICORTEID : m_corteId;
            m_montoBilletesBE = montoBilletesD.seleccionarMONTOBILLETESxCorte(m_montoBilletesBE, null);
            if (m_montoBilletesBE != null)
           {
               m_saldoTotalAnterior = m_montoBilletesBE.ISALDOFINAL;
               LlenaGUI(m_montoBilletesBE);
           }

            //LlenarReporteDesglosado();
            ObtenerTotalesDeCorte(m_corteId == 0 ? m_personaBE.ICORTEID : m_corteId);

            TBCantPesos1000.Focus();



            if (CurrentUserID.CurrentParameters.IHABFONDODINAMICO != null &&
                CurrentUserID.CurrentParameters.IHABFONDODINAMICO.Equals("S"))
            {
                pnlFondoDinamico.Visible = true;
            }
            else
            {
                pnlFondoDinamico.Visible = false;
            }

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();


        }


        private void AbrirCajon()
        {

            Ticket ticket = new Ticket();
            ticket.OpenDrawer(CurrentUserID.currentPrinter);//"IposPrinter3");
        }


        private void LlenaGUI(CMONTOBILLETESBE montoBilletesBE)
        {
            this.TBCantPesos1000.Text = montoBilletesBE.IP1000.ToString("N2");
            this.TBCantPesos500.Text = montoBilletesBE.IP500.ToString("N2");
            this.TBCantPesos200.Text = montoBilletesBE.IP200.ToString("N2");
            this.TBCantPesos100.Text = montoBilletesBE.IP100.ToString("N2");
            this.TBCantPesos50.Text = montoBilletesBE.IP50.ToString("N2");
            this.TBCantPesos20.Text = montoBilletesBE.IP20.ToString("N2");

            this.TBTipoCambio.Text = montoBilletesBE.ITIPODECAMBIO.ToString("N2");

            this.TBCantDolar100.Text = montoBilletesBE.ID100.ToString("N2");
            this.TBCantDolar50.Text = montoBilletesBE.ID50.ToString("N2");
            this.TBCantDolar20.Text = montoBilletesBE.ID20.ToString("N2");
            this.TBCantDolar10.Text = montoBilletesBE.ID10.ToString("N2");
            this.TBCantDolar5.Text = montoBilletesBE.ID5.ToString("N2");
            this.TBCantDolar2.Text = montoBilletesBE.ID2.ToString("N2");
            this.TBCantDolar1.Text = montoBilletesBE.ID1.ToString("N2");



           this.TBImportePesosMorralla.Text = montoBilletesBE.IMORRALLAPESOS.ToString("N2");
           this.TBImporteDolaresMorralla.Text = montoBilletesBE.IMORRALLADOLARES.ToString("N2");
           this.TBChequesImporte.Text = montoBilletesBE.ICHEQUES.ToString("N2");
           this.TBValesImporte.Text = montoBilletesBE.IVALES.ToString("N2");
           this.TBTarjetaImporte.Text = montoBilletesBE.ITARJETA.ToString("N2");
           this.TBCreditoImporte.Text = montoBilletesBE.ICREDITO.ToString("N2");
           this.TBMonederoImporte.Text = montoBilletesBE.IMONEDERO.ToString("N2");
           this.TBTransferenciaImporte.Text = montoBilletesBE.ITRANSFERENCIA.ToString("N2");
           this.TBDepositoImporte.Text = montoBilletesBE.IDEPOSITO.ToString("N2");
           this.TBDepTerImporte.Text = montoBilletesBE.IDEPTERCERO.ToString("N2");
           this.TBIndefinidoImporte.Text = montoBilletesBE.IINDEFINIDO.ToString("N2");


        }

        private void Limpiar()
        {

            this.TBCantPesos1000.Text = "0.00";
            this.TBCantPesos500.Text = "0.00";
            this.TBCantPesos200.Text = "0.00";
            this.TBCantPesos100.Text = "0.00";
            this.TBCantPesos50.Text = "0.00";
            this.TBCantPesos20.Text = "0.00";

            this.TBTipoCambio.Text = "0.00";

            this.TBCantDolar100.Text = "0.00";
            this.TBCantDolar50.Text = "0.00";
            this.TBCantDolar20.Text = "0.00";
            this.TBCantDolar10.Text = "0.00";
            this.TBCantDolar5.Text = "0.00";
            this.TBCantDolar2.Text = "0.00";
            this.TBCantDolar1.Text = "0.00";



            this.TBImportePesosMorralla.Text = "0.00";
            this.TBImporteDolaresMorralla.Text = "0.00";
            this.TBChequesImporte.Text = "0.00";
            this.TBValesImporte.Text = "0.00";
            this.TBTarjetaImporte.Text = "0.00";
            this.TBCreditoImporte.Text = "0.00";
            this.TBMonederoImporte.Text = "0.00";
            this.TBTransferenciaImporte.Text = "0.00";

            this.TBDepositoImporte.Text = "0.00";
            this.TBDepTerImporte.Text = "0.00";
            this.TBIndefinidoImporte.Text = "0.00";
        }

        private void TBCantPesos1000_NumericValueChanged(object sender, EventArgs e)
        {
            this.LBImportePesos1000.Text = (Decimal.Parse(this.TBCantPesos1000.Text.ToString()) * 1000).ToString("N2");
            calcularSaldo();
        }

        private void TBCantPesos500_NumericValueChanged(object sender, EventArgs e)
        {
            this.LBImportePesos500.Text = (Decimal.Parse(this.TBCantPesos500.Text.ToString()) * 500).ToString("N2");
            calcularSaldo();
        }

        private void TBCantPesos200_NumericValueChanged(object sender, EventArgs e)
        {

            this.LBImportePesos200.Text = (Decimal.Parse(this.TBCantPesos200.Text.ToString()) * 200).ToString("N2");
            calcularSaldo();
        }

        private void TBCantPesos100_NumericValueChanged(object sender, EventArgs e)
        {

            this.LBImportePesos100.Text = (Decimal.Parse(this.TBCantPesos100.Text.ToString()) * 100).ToString("N2");
            calcularSaldo();
        }

        private void TBCantPesos50_NumericValueChanged(object sender, EventArgs e)
        {

            this.LBImportePesos50.Text = (Decimal.Parse(this.TBCantPesos50.Text.ToString()) * 50).ToString("N2");
            calcularSaldo();
        }

        private void TBCantPesos20_NumericValueChanged(object sender, EventArgs e)
        {

            this.LBImportePesos20.Text = (Decimal.Parse(this.TBCantPesos20.Text.ToString()) * 20).ToString("N2");
            calcularSaldo();
        }

        private void TBCantDolar100_NumericValueChanged(object sender, EventArgs e)
        {
            decimal tipoCambio = Decimal.Parse(this.TBTipoCambio.Text.ToString());
            this.LBImporteDolar100.Text = (Decimal.Parse(this.TBCantDolar100.Text.ToString()) * 100).ToString("N2");
            this.LBImporteDolar_Peso100.Text = (Decimal.Parse(this.TBCantDolar100.Text.ToString()) * 100 * tipoCambio).ToString("N2");
            calcularSaldo();
        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {

            calcularSaldo();

            CMONTOBILLETESBE record = new CMONTOBILLETESBE();
            CMONTOBILLETESD dataOperador = new CMONTOBILLETESD();
            decimal fondoDinamicoFinal = Decimal.Parse(this.NTBFondoFinal.Text.ToString());




            record.ITIPOMONTOBILLETESID = this.m_tipoMontoBilletesId;
            if(m_corteId == 0 )
            {
                    
                    CPERSONAD personaD = new CPERSONAD();
                    m_personaBE.IUSERNAME = iPos.CurrentUserID.CurrentUser.IUSERNAME;
                    m_personaBE = personaD.seleccionarPERSONAxNOMBRE(m_personaBE, null);

                    record.ICORTEID = m_personaBE.ICORTEID ;
             }
             else
             {
                    record.ICORTEID =  m_corteId;
             }
                
            


            record.ITIPODECAMBIO = Decimal.Parse(this.TBTipoCambio.Text.ToString());
            record.IP1000 = Decimal.Parse(this.TBCantPesos1000.Text.ToString());
            record.IP500 = Decimal.Parse(this.TBCantPesos500.Text.ToString());
            record.IP200 = Decimal.Parse(this.TBCantPesos200.Text.ToString());
            record.IP100 = Decimal.Parse(this.TBCantPesos100.Text.ToString());
            record.IP50 = Decimal.Parse(this.TBCantPesos50.Text.ToString());
            record.IP20 = Decimal.Parse(this.TBCantPesos20.Text.ToString());
            record.ID100 = Decimal.Parse(this.TBCantDolar100.Text.ToString());
            record.ID50 = Decimal.Parse(this.TBCantDolar50.Text.ToString());
            record.ID20 = Decimal.Parse(this.TBCantDolar20.Text.ToString());
            record.ID10 = Decimal.Parse(this.TBCantDolar10.Text.ToString());
            record.ID5 = Decimal.Parse(this.TBCantDolar5.Text.ToString());
            record.ID2 = Decimal.Parse(this.TBCantDolar2.Text.ToString());
            record.ID1 = Decimal.Parse(this.TBCantDolar1.Text.ToString());
            record.IMORRALLAPESOS = Decimal.Parse(this.TBImportePesosMorralla.Text.ToString());
            record.IMORRALLADOLARES = Decimal.Parse(this.TBImporteDolaresMorralla.Text.ToString());
            record.IMORRALLADEDOLARENPESOS = Decimal.Parse(this.LBImporteDolar_PesoMorralla.Text.ToString());
            record.ISALDOFINAL = this.m_saldoTotal;
            record.ICHEQUES = Decimal.Parse(this.TBChequesImporte.Text.ToString());
            record.IVALES = Decimal.Parse(this.TBValesImporte.Text.ToString());
            record.ITARJETA = Decimal.Parse(this.TBTarjetaImporte.Text.ToString());
            record.ICREDITO = Decimal.Parse(this.TBCreditoImporte.Text.ToString());
            record.IMONEDERO = Decimal.Parse(this.TBMonederoImporte.Text.ToString());
            record.ITRANSFERENCIA = Decimal.Parse(this.TBTransferenciaImporte.Text.ToString());

            record.IDEPOSITO = Decimal.Parse(this.TBDepositoImporte.Text.ToString());
            record.IDEPTERCERO = Decimal.Parse(this.TBDepTerImporte.Text.ToString());
            record.IINDEFINIDO = Decimal.Parse(this.TBIndefinidoImporte.Text.ToString());



            if (m_bModoPostEdicion)
            {
                //abrir una ventana para que el usuario ingrese la razon del cambio en el monto billetes
                // asegurarse de que no este vacia y darle la opcion al usuario de cancelarla operacion
                // si decide cancelar .. aqui ira un return;
                CorteBilletesRazonCambio corteBilletesRazonCambioForm_ = new CorteBilletesRazonCambio();
                corteBilletesRazonCambioForm_.ShowDialog();
                bool continuarEdicion = corteBilletesRazonCambioForm_.m_continuaredicion;
                string nota_ = corteBilletesRazonCambioForm_.m_nota;
                corteBilletesRazonCambioForm_.Dispose();
                GC.SuppressFinalize(corteBilletesRazonCambioForm_);

                if (continuarEdicion == true)
                {
                    nota = nota_;
                }
                else
                {
                    return;
                }
            }


            long montoBilletesId = 0;
            if (dataOperador.CORTE_MONTOBILLETES_UPDATE(record, null, ref montoBilletesId, fondoDinamicoFinal))
            {
                
                m_montoBilletesId = montoBilletesId;


                if (m_bModoPostEdicion)
                {
                    // Guarda en el registro de la nueva tabla de log de cortes billetes:
                    // currentparameter.currentuser.id, razon del cambio, this.m_saldoTotal, m_saldoTotalAnterior
                    CMONTOBILLETESLOGBE montoBilletesLog = new CMONTOBILLETESLOGBE();
                    CMONTOBILLETESLOGD montoBilletesLogDao = new CMONTOBILLETESLOGD();

                    montoBilletesLog.ICREADOPOR_USERID = CurrentUserID.CurrentUser.IID;
                    montoBilletesLog.ISALDOFINALNUEVO = this.m_saldoTotal;
                    montoBilletesLog.ISALDOFINALANTERIOR = this.m_saldoTotalAnterior;
                    montoBilletesLog.INOTA = this.nota;
                    montoBilletesLog.IFECHACAMBIO = DateTime.Now;
                    montoBilletesLog.IACTIVO = "S";
                    montoBilletesLog.IMONTOBILLETESID = montoBilletesId;
                    montoBilletesLog.IUSUARIOID = CurrentUserID.CurrentUser.IID;

                    if (montoBilletesLogDao.AgregarMONTOBILLETESLOGD(montoBilletesLog, null) == null)
                    {
                        montoBilletesLogDao.IComentario = "Error al agregar registro a la tabla";
                    }

                    
                }

                MessageBox.Show("Se ha actualizado el saldo en caja");


                bool bTicketImpreso = ImprimirCorteBilletes();


                if (bTicketImpreso)
                        MessageBox.Show("El ticket se imprimio");

                RetiroCajaSiAplica();


                this.Close();

                if (!m_bModoPostEdicion)
                {
                    if (MessageBox.Show("Desea cerrar el corte y la sesión?", "Cerrar Sesión", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        this.Fm.Close();
                    }
                }
                return;
            }
            else
            {

                MessageBox.Show("Ocurrio un error: " + dataOperador.IComentario);
            }


        }



        public bool ImprimirCorteBilletes()
        {
            int iCantidadTickets = CurrentUserID.CurrentParameters.ICANTTICKETCIERREBILLETES > 0 ? CurrentUserID.CurrentParameters.ICANTTICKETCIERREBILLETES : 1;

            bool bTicketImpreso = false;
            for (int i = 0; i < iCantidadTickets; i++)
            {


                WFImpresionCorte ic_ = new WFImpresionCorte(m_corteId == 0 ? m_personaBE.ICORTEID : m_corteId);

                ic_.m_iOpcion = ImpresionCorteOption.MontoBilletes;
                if (m_bModoPostEdicion)
                {
                    ic_.m_aditionalFooter = "Corte modificado en " + DateTime.Today.ToString("dd/MM/yyyy") + " por " + CurrentUserID.CurrentUser.INOMBRE;
                }
                ic_.ShowDialog();
                bTicketImpreso = ic_.m_bTicketImpreso;
                ic_.Dispose();
                GC.SuppressFinalize(ic_);

            }

            return bTicketImpreso;
        }


        private void RetiroCajaSiAplica()
        {
            if (CurrentUserID.CurrentParameters.IRETIROCAJAALCERRARCORTE == null || !CurrentUserID.CurrentParameters.IRETIROCAJAALCERRARCORTE.Equals("S"))
                return;

            if (MessageBox.Show("Desea hacer un retiro de lo que reporto en el corte?", "Retiro", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

                FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            CRETIRODECAJAD retiroCajaD = new CRETIRODECAJAD();

            try
            {

                fConn.Open();
                fTrans = fConn.BeginTransaction();

                long doctoId = 0;
                long montobilletesId = 0;

                if (!retiroCajaD.RETIRO_CAJA_DESDECORTE(this.m_corteBE.IID, CurrentUserID.CurrentUser.IID, CurrentUserID.CurrentCompania.IEM_CAJA, ref doctoId, ref  montobilletesId,  fTrans))
                 {
                    fTrans.Rollback();
                    fConn.Close();

                    return;
                }
                

                fTrans.Commit();
                fConn.Close();


                if (doctoId > 0)
                {
                    bool bTicketImpreso = imprimirTicketRetiro(doctoId);
                    
                    if (bTicketImpreso)
                        MessageBox.Show("El ticket se imprimio");
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

        }

        private bool imprimirTicketRetiro(long doctoId)
        {
            bool bTicketImpreso = false;
            int cantidadCopias = CurrentUserID.CurrentParameters.ICANTTICKETRETIRO > 1 ? CurrentUserID.CurrentParameters.ICANTTICKETRETIRO : 1;

            WFImpresionCorte ic_ = new WFImpresionCorte(m_corteId, doctoId, ImpresionCorteOption.MontoBilletesPorRetiro);
            ic_.m_numCopias = cantidadCopias;
            ic_.ShowDialog();
            bTicketImpreso = ic_.m_bTicketImpreso;
            ic_.Dispose();
            GC.SuppressFinalize(ic_);

            return bTicketImpreso;


        }

        private void TBCantDolar50_NumericValueChanged(object sender, EventArgs e)
        {

            decimal tipoCambio = Decimal.Parse(this.TBTipoCambio.Text.ToString());
            this.LBImporteDolar50.Text = (Decimal.Parse(this.TBCantDolar50.Text.ToString()) * 50).ToString("N2");
            this.LBImporteDolar_Peso50.Text = (Decimal.Parse(this.TBCantDolar50.Text.ToString()) * 50 * tipoCambio).ToString("N2");
            calcularSaldo();
        }

        private void TBCantDolar20_NumericValueChanged(object sender, EventArgs e)
        {

            decimal tipoCambio = Decimal.Parse(this.TBTipoCambio.Text.ToString());
            this.LBImporteDolar20.Text = (Decimal.Parse(this.TBCantDolar20.Text.ToString()) * 20).ToString("N2");
            this.LBImporteDolar_Peso20.Text = (Decimal.Parse(this.TBCantDolar20.Text.ToString()) * 20 * tipoCambio).ToString("N2");
            calcularSaldo();
        }

        private void TBCantDolar10_NumericValueChanged(object sender, EventArgs e)
        {

            decimal tipoCambio = Decimal.Parse(this.TBTipoCambio.Text.ToString());
            this.LBImporteDolar10.Text = (Decimal.Parse(this.TBCantDolar10.Text.ToString()) * 10).ToString("N2");
            this.LBImporteDolar_Peso10.Text = (Decimal.Parse(this.TBCantDolar10.Text.ToString()) * 10 * tipoCambio).ToString("N2");
            calcularSaldo();
        }

        private void TBCantDolar5_NumericValueChanged(object sender, EventArgs e)
        {

            decimal tipoCambio = Decimal.Parse(this.TBTipoCambio.Text.ToString());
            this.LBImporteDolar5.Text = (Decimal.Parse(this.TBCantDolar5.Text.ToString()) * 5).ToString("N2");
            this.LBImporteDolar_Peso5.Text = (Decimal.Parse(this.TBCantDolar5.Text.ToString()) * 5 * tipoCambio).ToString("N2");
            calcularSaldo();
        }

        private void TBCantDolar2_NumericValueChanged(object sender, EventArgs e)
        {

            decimal tipoCambio = Decimal.Parse(this.TBTipoCambio.Text.ToString());
            this.LBImporteDolar2.Text = (Decimal.Parse(this.TBCantDolar2.Text.ToString()) * 2).ToString("N2");
            this.LBImporteDolar_Peso2.Text = (Decimal.Parse(this.TBCantDolar2.Text.ToString()) * 2 * tipoCambio).ToString("N2");
            calcularSaldo();
        }

        private void TBCantDolar1_NumericValueChanged(object sender, EventArgs e)
        {

            decimal tipoCambio = Decimal.Parse(this.TBTipoCambio.Text.ToString());
            this.LBImporteDolar1.Text = (Decimal.Parse(this.TBCantDolar1.Text.ToString()) * 1).ToString("N2");
            this.LBImporteDolar_Peso1.Text = (Decimal.Parse(this.TBCantDolar1.Text.ToString()) * 1 * tipoCambio).ToString("N2");
            calcularSaldo();
        }

        private void TBTipoCambio_NumericValueChanged(object sender, EventArgs e)
        {
            decimal tipoCambio = Decimal.Parse(this.TBTipoCambio.Text.ToString());
            this.LBImporteDolar_Peso100.Text = (Decimal.Parse(this.TBCantDolar100.Text.ToString()) * 100 * tipoCambio).ToString("N2");
            this.LBImporteDolar_Peso50.Text = (Decimal.Parse(this.TBCantDolar50.Text.ToString()) * 50 * tipoCambio).ToString("N2");
            this.LBImporteDolar_Peso20.Text = (Decimal.Parse(this.TBCantDolar20.Text.ToString()) * 20 * tipoCambio).ToString("N2");
            this.LBImporteDolar_Peso10.Text = (Decimal.Parse(this.TBCantDolar10.Text.ToString()) * 10 * tipoCambio).ToString("N2");
            this.LBImporteDolar_Peso5.Text = (Decimal.Parse(this.TBCantDolar5.Text.ToString()) * 5 * tipoCambio).ToString("N2");
            this.LBImporteDolar_Peso2.Text = (Decimal.Parse(this.TBCantDolar2.Text.ToString()) * 2 * tipoCambio).ToString("N2");
            this.LBImporteDolar_Peso1.Text = (Decimal.Parse(this.TBCantDolar1.Text.ToString()) * 1 * tipoCambio).ToString("N2");
            LBImporteDolar_PesoMorralla.Text = (Decimal.Parse(this.TBImporteDolaresMorralla.Text.ToString()) * tipoCambio).ToString("N2");
            calcularSaldo();
        }

        private void TBImporteDolaresMorralla_NumericValueChanged(object sender, EventArgs e)
        {
            decimal tipoCambio = Decimal.Parse(this.TBTipoCambio.Text.ToString());
            LBImporteDolar_PesoMorralla.Text = (Decimal.Parse(this.TBImporteDolaresMorralla.Text.ToString()) * tipoCambio).ToString("N2");
            calcularSaldo();
        }

        private void calcularSaldo()
        {
            
            decimal tipoCambio = Decimal.Parse(this.TBTipoCambio.Text.ToString());

            decimal buffer = 0;
            buffer += Decimal.Parse(this.TBCantPesos1000.Text.ToString()) * 1000;
            buffer += Decimal.Parse(this.TBCantPesos500.Text.ToString()) * 500;
            buffer += Decimal.Parse(this.TBCantPesos200.Text.ToString()) * 200;
            buffer += Decimal.Parse(this.TBCantPesos100.Text.ToString()) * 100;
            buffer += Decimal.Parse(this.TBCantPesos50.Text.ToString()) * 50;
            buffer += Decimal.Parse(this.TBCantPesos20.Text.ToString()) * 20;
            buffer += Decimal.Parse(this.TBImportePesosMorralla.Text.ToString());

            buffer += Decimal.Parse(this.TBCantDolar100.Text.ToString()) * 100 * tipoCambio;
            buffer += Decimal.Parse(this.TBCantDolar50.Text.ToString()) * 50 * tipoCambio;
            buffer += Decimal.Parse(this.TBCantDolar20.Text.ToString()) * 20 * tipoCambio;

            buffer += Decimal.Parse(this.TBCantDolar10.Text.ToString()) * 10 * tipoCambio;
            buffer += Decimal.Parse(this.TBCantDolar5.Text.ToString()) * 5 * tipoCambio;
            buffer += Decimal.Parse(this.TBCantDolar2.Text.ToString()) * 2 * tipoCambio;
            buffer += Decimal.Parse(this.TBCantDolar1.Text.ToString()) * 1 * tipoCambio;
            buffer += Decimal.Parse(this.TBImporteDolaresMorralla.Text.ToString()) * tipoCambio;

            
            buffer += Decimal.Parse(this.TBChequesImporte.Text.ToString());
            buffer += Decimal.Parse(this.TBValesImporte.Text.ToString());
            buffer += Decimal.Parse(this.TBTarjetaImporte.Text.ToString());
            buffer += Decimal.Parse(this.TBCreditoImporte.Text.ToString());
            buffer += Decimal.Parse(this.TBMonederoImporte.Text.ToString());
            buffer += Decimal.Parse(this.TBTransferenciaImporte.Text.ToString());

            buffer += Decimal.Parse(this.TBTrasladosEfectivo.Text.ToString());

            buffer += Decimal.Parse(this.TBDepositoImporte.Text.ToString());
            buffer += Decimal.Parse(this.TBDepTerImporte.Text.ToString());

            buffer += Decimal.Parse(this.TBIndefinidoImporte.Text.ToString());

            m_saldoTotal = buffer;

            this.LBSaldoTotal.Text = buffer.ToString("N2");
        }

        private void TBChequesImporte_NumericValueChanged(object sender, EventArgs e)
        {

            calcularSaldo();
        }

        private void TBValesImporte_NumericValueChanged(object sender, EventArgs e)
        {

            calcularSaldo();
        }

        private void TBTarjetaImporte_NumericValueChanged(object sender, EventArgs e)
        {

            calcularSaldo();
        }


        private void TBCreditoImporte_NumericValueChanged(object sender, EventArgs e)
        {

            calcularSaldo();
        }


        private void TBImportePesosMorralla_NumericValueChanged(object sender, EventArgs e)
        {
            calcularSaldo();
        }


        private void TBMonederoImporte_NumericValueChanged(object sender, EventArgs e)
        {

            calcularSaldo();
        }


        private void TBTransferenciaImporte_NumericValueChanged(object sender, EventArgs e)
        {

            calcularSaldo();
        }

        private void TBTrasladosEfectivo_NumericValueChanged(object sender, EventArgs e)
        {
            calcularSaldo();
        }

        private void TBDepositoImporte_NumericValueChanged(object sender, EventArgs e)
        {
            calcularSaldo();
        }

        private void TBDepTerImporte_NumericValueChanged(object sender, EventArgs e)
        {
            calcularSaldo();
        }


        private void TBIndefinidoImporte_NumericValueChanged(object sender, EventArgs e)
        {

            calcularSaldo();
        }

        private void ObtenerTotalesDeCorte(long corteId)
        {


            CCORTED corteD = new CCORTED();
            m_corteBE = new CCORTEBE();
            m_corteBE.IID = corteId;
            m_corteBE = corteD.seleccionarCORTE(m_corteBE, null);
            if (m_corteBE == null)
            {
                MessageBox.Show("El corte seleccionado no se pudo obtener");
                return;
            }

            if(!m_bModoPostEdicion)
            {

                m_corteBE = corteD.ObtenTotalesCORTE(m_corteBE, null);
            }

            if (m_corteBE != null)
            {
                this.TBRetirosDeCaja.Text = m_corteBE.IRETIROSDECAJA.ToString();
                this.TBTarjetaImporte.Text = (m_corteBE.IINGRESOTARJETA - m_corteBE.IEGRESOTARJETA).ToString();
                this.TBChequesImporte.Text = (m_corteBE.IINGRESOCHEQUE - m_corteBE.IEGRESOCHEQUE).ToString();
                this.TBTransferenciaImporte.Text = (m_corteBE.IINGRESOTRANSFERENCIA - m_corteBE.IEGRESOTRANSFERENCIA).ToString();
                this.TBCreditoImporte.Text = (m_corteBE.IINGRESOCREDITO - m_corteBE.IEGRESOCREDITO).ToString();
                this.TBValesImporte.Text = (m_corteBE.IINGRESOVALE - m_corteBE.IEGRESOVALE).ToString();
                this.TBTrasladosEfectivo.Text = (m_corteBE.IINGRESOEFECTIVOVENTATRASLADO -  m_corteBE.IEGRESOEFEVENTATRASLADO).ToString();
                this.TBDepositoImporte.Text = (m_corteBE.IINGRESODEPOSITO - m_corteBE.IEGRESODEPOSITO).ToString();
                this.TBDepTerImporte.Text = (m_corteBE.IINGRESODEPTERCERO - m_corteBE.IEGRESODEPTERCERO).ToString();
                this.TBIndefinidoImporte.Text = (m_corteBE.IINGRESOINDEFINIDO - m_corteBE.IEGRESOINDEFINIDO).ToString();
            }
            LlenarReporteDesglosado();
            RefreshReportFormasPago(m_corteBE.IID);


        }

        public void LlenarReporteDesglosado()
        {

            this.CORTE_CALCULO_SIN_EFECTIVOTableAdapter.Fill(this.DSCortesB.CORTE_CALCULO_SIN_EFECTIVO, (int)m_corteBE.IID);
            this.CORTE_CALCULO_NOAPLICADOTableAdapter.Fill(this.DSCortesB.CORTE_CALCULO_NOAPLICADO, (int)m_corteBE.IID);

            Microsoft.Reporting.WinForms.ReportParameter[] Param = new Microsoft.Reporting.WinForms.ReportParameter[3];
            Param[0] = new Microsoft.Reporting.WinForms.ReportParameter("Fecha", m_corteBE.IFECHACORTE.ToString("dd/MM/yyyy"));
            Param[1] = new Microsoft.Reporting.WinForms.ReportParameter("Cajero", CurrentUserID.CurrentUser.INOMBRE);
            Param[2] = new Microsoft.Reporting.WinForms.ReportParameter("Corte", m_corteBE.IID.ToString("N0"));
            this.reportViewer1.LocalReport.SetParameters(Param);
            this.reportViewer1.RefreshReport();

            this.reportViewer2.LocalReport.SetParameters(Param);
            this.reportViewer2.RefreshReport();
        }


        private void RecargarReport()
        {

            report1.Load(FastReportsConfig.getPathForFile("InformeTransXCorteXFormaPago.frx", FastReportsTipoFile.desistema));
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);

        }

        private void RefreshReportFormasPago(long corteId)
        {



            report1.SetParameterValue("corteid", (Decimal)corteId);

            if (report1.Prepare())
                report1.ShowPrepared();
        }

  

        private void btnImprimirDetalles_Click_1(object sender, EventArgs e)
        {

            if (m_corteBE == null)
                return;


            FastReport.Report report = new FastReport.Report();
            report.Load(FastReportsConfig.getPathForFile(@"InformeTransXCorteXFormaPagoTicket.frx", FastReportsTipoFile.desistema));
            FastReport.Utils.Config.ReportSettings.ShowProgress = false;

            report.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;


            report.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
            report.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);
            report.SetParameterValue("corteid", (Decimal)m_corteBE.IID);


            report.PrintSettings.ShowDialog = false;
            report.Prepare();



            report.PrintSettings.Printer = ConexionesBD.ConexionBD.currentPrinter;

            try
            {

                report.Print();
                MessageBox.Show("Se imprimio");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al imprimir " + ex.Message);
            }
        }
    }
}
