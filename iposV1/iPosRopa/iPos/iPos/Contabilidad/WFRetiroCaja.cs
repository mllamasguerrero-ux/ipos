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
    public partial class WFRetiroCaja : IposForm
    {
        decimal m_saldoTotal = 0;
        //private CCORTEBE m_corteBE;
        CMONTOBILLETESBE m_montoBilletesBE;
        CPERSONABE m_personaBE = new CPERSONABE();
        long m_doctoId_reference = 0;
        public long m_montoBilletesId = 0;

        DateTime? m_fechaCorte_referencia = null;
        long m_vendedorid_referencia = 0;


        CDOCTOBE m_doctoBE = new CDOCTOBE();
        long m_corteId = 0;
        string m_modo = "Agregar";

        bool m_bSeleccionarCajero = false;
        long m_autorizoId = 0;

        bool m_bPermisoReimprimirTicketContabilidad = false;

        public WFRetiroCaja()
        {
            InitializeComponent();
            m_autorizoId = CurrentUserID.CurrentUser.IID;
        }


        public WFRetiroCaja(long doctoId_reference) : this()
        {
            m_doctoId_reference = doctoId_reference;
            m_modo = "Editar";
        }


        public WFRetiroCaja( bool bSeleccionarCajero, long autorizoId) : this()
        {

            m_autorizoId = autorizoId;
            m_bSeleccionarCajero = bSeleccionarCajero;
        }



        public WFRetiroCaja(long doctoId_reference, string modo) : this(doctoId_reference)
        {
            m_modo = modo;
        }


        


        private void WFRetiroCaja_Load(object sender, EventArgs e)
        {


            CUSUARIOSD usuariosD = new CUSUARIOSD();
            if (usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_REIMPRIMIRTICKET_CONT, null))
            {
                m_bPermisoReimprimirTicketContabilidad = true;
            }
            else
            {
                m_bPermisoReimprimirTicketContabilidad = false;
            }

            this.CBCajero.llenarDatos();
            this.CBCajero.SelectedDataValue = CurrentUserID.CurrentUser.IID.ToString();

            this.CBCajero.Enabled = m_bSeleccionarCajero;
            if (m_bSeleccionarCajero)
            {
                pnlCorteSeleccion.Visible = false;
                CBCorteActual.Checked = false;
            }



            Ticket ticket = new Ticket();
            ticket.OpenDrawer(CurrentUserID.currentPrinter);

            string strComentario = "";

            if (m_doctoId_reference == 0)
            {
                //if (!ChecarCorteActivo())
                //{
                //    MessageBox.Show("No hay corte activo para hoy");
                //    this.Close();
                //    return;
                //}

                m_montoBilletesBE = new CMONTOBILLETESBE();
                
                if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_AGREGARRETIRO_OTROCORTE, null))
                {
                    DTPFecha.Enabled = false;
                    pnlCorteSeleccion.Enabled = false;

                }
            }
            else
            {
                this.CBCorteActual.Checked = false;
                if (!this.ChecarReferencia(ref strComentario))
                {
                    MessageBox.Show(strComentario);
                    this.Close();
                    return;
                }
            }


           


            CPERSONAD personaD = new CPERSONAD();
            m_personaBE.IID = iPos.CurrentUserID.CurrentUser.IID;
            m_personaBE = personaD.seleccionarPERSONA(m_personaBE, null);

            /*CMONTOBILLETESD montoBilletesD = new CMONTOBILLETESD();
            m_montoBilletesBE.ICORTEID = m_personaBE.ICORTEID;
            m_montoBilletesBE = montoBilletesD.seleccionarMONTOBILLETESxCorte(m_montoBilletesBE, null);
            if (m_montoBilletesBE != null)
           {
               LlenaGUI(m_montoBilletesBE);
           }*/

            if(m_modo.Equals("Consultar"))
            {
                this.PonModoReadOnly();
                btnImprimir.Visible = m_bPermisoReimprimirTicketContabilidad;
            }

            if (m_modo.Equals("Cambiar"))
            {
                btnImprimir.Visible = m_bPermisoReimprimirTicketContabilidad;
            }


                TBCantPesos1000.Focus();





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
        }

        private void TBCantPesos1000_NumericValueChanged(object sender, EventArgs e)
        {
            this.LBImportePesos1000.Text = (Decimal.Parse(this.TBCantPesos1000.Text.ToString()) * 1000).ToString("N2");
            calcularTotal();
        }

        private void TBCantPesos500_NumericValueChanged(object sender, EventArgs e)
        {
            this.LBImportePesos500.Text = (Decimal.Parse(this.TBCantPesos500.Text.ToString()) * 500).ToString("N2");
            calcularTotal();
        }

        private void TBCantPesos200_NumericValueChanged(object sender, EventArgs e)
        {

            this.LBImportePesos200.Text = (Decimal.Parse(this.TBCantPesos200.Text.ToString()) * 200).ToString("N2");
            calcularTotal();
        }

        private void TBCantPesos100_NumericValueChanged(object sender, EventArgs e)
        {

            this.LBImportePesos100.Text = (Decimal.Parse(this.TBCantPesos100.Text.ToString()) * 100).ToString("N2");
            calcularTotal();
        }

        private void TBCantPesos50_NumericValueChanged(object sender, EventArgs e)
        {

            this.LBImportePesos50.Text = (Decimal.Parse(this.TBCantPesos50.Text.ToString()) * 50).ToString("N2");
            calcularTotal();
        }

        private void TBCantPesos20_NumericValueChanged(object sender, EventArgs e)
        {

            this.LBImportePesos20.Text = (Decimal.Parse(this.TBCantPesos20.Text.ToString()) * 20).ToString("N2");
            calcularTotal();
        }

        private void TBCantDolar100_NumericValueChanged(object sender, EventArgs e)
        {
            decimal tipoCambio = Decimal.Parse(this.TBTipoCambio.Text.ToString());
            this.LBImporteDolar100.Text = (Decimal.Parse(this.TBCantDolar100.Text.ToString()) * 100).ToString("N2");
            this.LBImporteDolar_Peso100.Text = (Decimal.Parse(this.TBCantDolar100.Text.ToString()) * 100 * tipoCambio).ToString("N2");
            calcularTotal();
        }




        private bool preparaIngresoDeRetiro(ref string strComentario, FbTransaction fTrans)
        {

            bool bRes = EliminarRetirosPendientesDelCorte(ref strComentario, fTrans);
            if (!bRes)
            { 
                return false;
            }

            if(m_doctoId_reference > 0 && m_modo.Equals("Editar"))
            {
                 if(!CancelarRetiroDeCaja(m_doctoId_reference, fTrans, ref  strComentario))
                 {
                     return false;
                 }
            }

            long? cajeroId = long.Parse(CBCajero.SelectedValue.ToString());
            string corteActual = CBCorteActual.Checked ? "S" : "N";
            DateTime? fechaCorte = CBCorteActual.Checked ? DateTime.Today : DTPFecha.Value;

            return CrearBorradorRetiro(ref strComentario, corteActual, fechaCorte, cajeroId, fTrans);
            
        }

        private bool CancelarRetiroDeCaja(long doctoId, FbTransaction fTrans, ref string strComentario)
        {
            CRETIRODECAJAD retiroD = new CRETIRODECAJAD();
            CDOCTOBE doctoBE = new CDOCTOBE();
            doctoBE.IID = doctoId;
            doctoBE.IVENDEDORID = CurrentUserID.CurrentUser.IID;
            if (!retiroD.RETIRO_CAJA_CANCEL(doctoBE, fTrans))
            {
                strComentario = retiroD.IComentario;
                return false;
            }
            return true;
        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {


            if (CBCajero.SelectedIndex < 0)
            {
                MessageBox.Show("Necesita seleccionar un cajero");
                return;
            }

            if (CBCorteActual.Checked && m_corteId == 0)
            {
                if (!ChecarCorteActivo())
                {
                    MessageBox.Show("Debe tener un corte activo si selecciona el corte actual");
                    return;
                }
            }


            CCORTEBE corteBE = obtenerCorteRelacionado(null);

                FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            string strComentario = "";




            calcularTotal();
            decimal importeEfectivo = Decimal.Parse(this.TBSumaEfectivo.Text.ToString());
            decimal importeCheque = Decimal.Parse(this.TBChequesImporte.Text.ToString());
            decimal importeVale = Decimal.Parse(this.TBValesImporte.Text.ToString());

            decimal total = importeEfectivo + importeCheque + importeVale;
            if (total <= 0)
            {

                MessageBox.Show("Ingrese un importe mayor de cero");
                fConn.Close();
                return;
            }

            bool bReimprimirCorte = false;
            string comentario = "";


            try
            {

                fConn.Open();
                fTrans = fConn.BeginTransaction();



                if (!preparaIngresoDeRetiro(ref strComentario, fTrans))
                {
                    fTrans.Rollback();
                    fConn.Close();
                    MessageBox.Show("Ocurrio un error al preparar el retiro " + strComentario);
                    return;
                }


                

                CMONTOBILLETESBE record = new CMONTOBILLETESBE();
                CMONTOBILLETESD dataOperador = new CMONTOBILLETESD();


                CPERSONAD personaD = new CPERSONAD();
                m_personaBE.IUSERNAME = iPos.CurrentUserID.CurrentUser.IUSERNAME;
                m_personaBE = personaD.seleccionarPERSONAxNOMBRE(m_personaBE, fTrans);


                record.ITIPOMONTOBILLETESID = DBValues._TIPOMONTOBILLETESID_RETIROCAJA;
                record.IDOCTOID = m_doctoBE.IID;


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


                record.ITARJETA = Decimal.Parse("0.0");
                record.ICREDITO = Decimal.Parse("0.0");
                record.IMONEDERO = Decimal.Parse("0.0");
                record.ITRANSFERENCIA = Decimal.Parse("0.0");

               

                long montoBilletesId = 0;
                if (dataOperador.CORTE_MONTOBILLETES_UPDATE(record, fTrans, ref montoBilletesId,corteBE.IFONDODINAMICOFINAL))
                {

                    m_montoBilletesId = montoBilletesId;

                    CRETIRODECAJAD doctoD = new CRETIRODECAJAD();
                    if (!doctoD.RETIRO_CAJA_COMPLETAR(ref this.m_doctoBE, importeEfectivo, importeCheque, importeVale, fTrans))
                    {

                        fTrans.Rollback();
                        fConn.Close();
                        MessageBox.Show("error " + doctoD.IComentario);
                        return;
                    }
                    else
                    {

                        if(!actualizarCorteRelacionado(fTrans, m_doctoBE.IID, ref comentario, ref bReimprimirCorte))
                        {

                            fTrans.Rollback();
                            fConn.Close();
                            MessageBox.Show("error " + comentario);
                            return;
                        }

                        fTrans.Commit();
                        fConn.Close();
                        MessageBox.Show("Se agrego el registro");


                        CBCorteActual.Enabled = false;
                        CBCajero.Enabled = false;
                        DTPFecha.Enabled = false;
                        
                       

                        bool bTicketImpreso = imprimirTicketRetiro();

                        if (bTicketImpreso)
                            MessageBox.Show("El ticket se imprimio");



                        //reimprimir corte si se requiere
                        if (bReimprimirCorte)
                        {
                            if (MessageBox.Show(" Desea reimprimir el corte?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {

                                WFImpresionCorte ic2 = new WFImpresionCorte(m_corteId);
                                ic2.m_aditionalFooter = "Corte modificado por gasto en " + DateTime.Today.ToString("dd/MM/yyyy") + " por " + CurrentUserID.CurrentUser.INOMBRE;
                                ic2.ShowDialog();
                                bool bTicketImpreso2 = ic2.m_bTicketImpreso;
                                ic2.Dispose();
                                GC.SuppressFinalize(ic2);

                                if (bTicketImpreso2)
                                    MessageBox.Show("El ticket de corte se imprimio");
                            }
                        }



                        this.Close();
                    }


                    
                    
                }
                else
                {

                    fTrans.Rollback();
                    fConn.Close();
                    MessageBox.Show("Ocurrio un error: " + dataOperador.IComentario);
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


        private bool imprimirTicketRetiro(int copias = 0)
        {
            bool bTicketImpreso = false;
            int cantidadCopias =  copias == 0 && CurrentUserID.CurrentParameters.ICANTTICKETRETIRO > 1 ? CurrentUserID.CurrentParameters.ICANTTICKETRETIRO : copias > 0 ? copias : 1;

            WFImpresionCorte ic_ = new WFImpresionCorte(m_corteId, m_doctoBE.IID, ImpresionCorteOption.MontoBilletesPorRetiro);
            ic_.m_numCopias = cantidadCopias;
            ic_.ShowDialog();
            bTicketImpreso = ic_.m_bTicketImpreso;
            ic_.Dispose();
            GC.SuppressFinalize(ic_);

            return bTicketImpreso;


        }


        private CCORTEBE obtenerCorteRelacionado(FbTransaction fTrans)
        {
            CCORTED corteD = new CCORTED();
            CCORTEBE corteBE = new CCORTEBE();
            corteBE.IID = m_corteId;
            corteBE = corteD.seleccionarCORTE(corteBE, fTrans);
            return corteBE;
        }

        private bool actualizarCorteRelacionado(FbTransaction fTrans, long doctoId, ref string comentario, ref bool bReimprimirCorte)
        {

            //checar si se necesita actualizar y reimiprimir el corte
            bReimprimirCorte = false;
            CCORTED corteD = new CCORTED();
            CCORTEBE corteBE = new CCORTEBE();
            corteBE.IID = m_corteId;
            corteBE = corteD.seleccionarCORTE(corteBE, fTrans);
            if (corteBE != null && !corteBE.IACTIVO.Equals("S"))
            {
                corteD.QueryObtenTotalesCORTE_PORID(corteBE, fTrans);
                //si ocurrio un error
                if (corteD.IComentario != "")
                {

                    comentario = "Error al actualizar el corte cerrado " + corteD.IComentario;
                    return false;
                }

                if (!corteD.CORTE_ACTUALIZAR_DIFERENCIA(corteBE, fTrans))
                {
                    
                    comentario = "Error al actualizar la diferencia del corte cerrado " + corteD.IComentario;
                    return false;
                }

                bReimprimirCorte = true;
            }

            
            comentario = "El registro se ha guardado";


            


            return true;

        }

        private void TBCantDolar50_NumericValueChanged(object sender, EventArgs e)
        {

            decimal tipoCambio = Decimal.Parse(this.TBTipoCambio.Text.ToString());
            this.LBImporteDolar50.Text = (Decimal.Parse(this.TBCantDolar50.Text.ToString()) * 50).ToString("N2");
            this.LBImporteDolar_Peso50.Text = (Decimal.Parse(this.TBCantDolar50.Text.ToString()) * 50 * tipoCambio).ToString("N2");
            calcularTotal();
        }

        private void TBCantDolar20_NumericValueChanged(object sender, EventArgs e)
        {

            decimal tipoCambio = Decimal.Parse(this.TBTipoCambio.Text.ToString());
            this.LBImporteDolar20.Text = (Decimal.Parse(this.TBCantDolar20.Text.ToString()) * 20).ToString("N2");
            this.LBImporteDolar_Peso20.Text = (Decimal.Parse(this.TBCantDolar20.Text.ToString()) * 20 * tipoCambio).ToString("N2");
            calcularTotal();
        }

        private void TBCantDolar10_NumericValueChanged(object sender, EventArgs e)
        {

            decimal tipoCambio = Decimal.Parse(this.TBTipoCambio.Text.ToString());
            this.LBImporteDolar10.Text = (Decimal.Parse(this.TBCantDolar10.Text.ToString()) * 10).ToString("N2");
            this.LBImporteDolar_Peso10.Text = (Decimal.Parse(this.TBCantDolar10.Text.ToString()) * 10 * tipoCambio).ToString("N2");
            calcularTotal();
        }

        private void TBCantDolar5_NumericValueChanged(object sender, EventArgs e)
        {

            decimal tipoCambio = Decimal.Parse(this.TBTipoCambio.Text.ToString());
            this.LBImporteDolar5.Text = (Decimal.Parse(this.TBCantDolar5.Text.ToString()) * 5).ToString("N2");
            this.LBImporteDolar_Peso5.Text = (Decimal.Parse(this.TBCantDolar5.Text.ToString()) * 5 * tipoCambio).ToString("N2");
            calcularTotal();
        }

        private void TBCantDolar2_NumericValueChanged(object sender, EventArgs e)
        {

            decimal tipoCambio = Decimal.Parse(this.TBTipoCambio.Text.ToString());
            this.LBImporteDolar2.Text = (Decimal.Parse(this.TBCantDolar2.Text.ToString()) * 2).ToString("N2");
            this.LBImporteDolar_Peso2.Text = (Decimal.Parse(this.TBCantDolar2.Text.ToString()) * 2 * tipoCambio).ToString("N2");
            calcularTotal();
        }

        private void TBCantDolar1_NumericValueChanged(object sender, EventArgs e)
        {

            decimal tipoCambio = Decimal.Parse(this.TBTipoCambio.Text.ToString());
            this.LBImporteDolar1.Text = (Decimal.Parse(this.TBCantDolar1.Text.ToString()) * 1).ToString("N2");
            this.LBImporteDolar_Peso1.Text = (Decimal.Parse(this.TBCantDolar1.Text.ToString()) * 1 * tipoCambio).ToString("N2");
            calcularTotal();
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
            calcularTotal();
        }

        private void TBImporteDolaresMorralla_NumericValueChanged(object sender, EventArgs e)
        {
            decimal tipoCambio = Decimal.Parse(this.TBTipoCambio.Text.ToString());
            LBImporteDolar_PesoMorralla.Text = (Decimal.Parse(this.TBImporteDolaresMorralla.Text.ToString()) * tipoCambio).ToString("N2");
            calcularTotal();
        }

        private void calcularTotal()
        {
            
            decimal tipoCambio = Decimal.Parse(this.TBTipoCambio.Text.ToString());
            decimal totalEfectivo = 0;

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


            totalEfectivo = buffer;

            buffer += Decimal.Parse(this.TBChequesImporte.Text.ToString());
            buffer += Decimal.Parse(this.TBValesImporte.Text.ToString());

            m_saldoTotal = buffer;

            this.LBSaldoTotal.Text = buffer.ToString("N2");
            TBSumaEfectivo.Text = totalEfectivo.ToString("N2");
        }

        private void TBChequesImporte_NumericValueChanged(object sender, EventArgs e)
        {

            calcularTotal();
        }

        private void TBValesImporte_NumericValueChanged(object sender, EventArgs e)
        {

            calcularTotal();
        }



        private void TBImportePesosMorralla_NumericValueChanged(object sender, EventArgs e)
        {
            calcularTotal();
        }




        private bool CrearBorradorRetiro(ref string strComentario, string corteActual, DateTime? fechaCorte, long? cajeroId, FbTransaction fTrans)
        {

            CDOCTOBE doctoBE = new CDOCTOBE();
            CRETIRODECAJAD retiroCajaD = new CRETIRODECAJAD();
            CDOCTOD doctoD = new CDOCTOD();

            doctoBE.IALMACENID = DBValues._DOCTO_ALMACEN_DEFAULT;
            doctoBE.ISUCURSALID = CurrentUserID.CurrentParameters.ISUCURSALID;
            doctoBE.IVENDEDORID = m_doctoId_reference == 0 ? iPos.CurrentUserID.CurrentUser.IID : m_vendedorid_referencia;
            doctoBE.IFECHA = m_doctoId_reference == 0 ? DateTime.Today : m_fechaCorte_referencia.Value;
            doctoBE.ICAJAID = iPos.CurrentUserID.CurrentCompania.IEM_CAJA;
            doctoBE.IPERSONAID = m_doctoId_reference == 0 ? iPos.CurrentUserID.CurrentUser.IID : m_vendedorid_referencia;
            doctoBE.ITIPODOCTOID = DBValues._DOCTO_TIPO_RETIRO_CAJA;

            doctoBE.IREFERENCIAS = TBObservaciones.Text;
            doctoBE.ICORTEID =  m_doctoId_reference == 0 ? 0 : m_corteId;

            if (!retiroCajaD.RETIRO_CAJA_INSERT(ref doctoBE, corteActual,  fechaCorte, cajeroId, fTrans))
            {
                strComentario = retiroCajaD.IComentario;
                return false;
            }
            else
            {
                doctoBE = doctoD.seleccionarDOCTO(doctoBE, fTrans);
                if (doctoBE != null)
                {
                    m_corteId = doctoBE.ICORTEID;
                    m_doctoBE = doctoBE;
                }

                return true;
            }
        }



        private bool EliminarRetirosPendientesDelCorte(ref string strComentario, FbTransaction trans)
        {

            CRETIRODECAJAD doctoD = new CRETIRODECAJAD();


            if (!doctoD.RETIRO_CAJA_DELETEPENDIENTES(this.m_corteId, trans))
            {
                strComentario = doctoD.IComentario;
                return false;
            }
            else
            {
                return true;
            }
        }


        private bool ChecarCorteActivo()
        {
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            DateTime fechaCorte = DateTime.MinValue;
            if (!pvd.HayCorteActivo(ref fechaCorte, iPos.CurrentUserID.CurrentUser.IID))
            {
                return false;
            }

            CCORTEBE corteBuffer = new CCORTEBE();
            CCORTED corteD = new CCORTED();
            corteBuffer.ICAJEROID = iPos.CurrentUserID.CurrentUser.IID;
            corteBuffer.IFECHACORTE = fechaCorte;
            corteBuffer = corteD.seleccionarCORTEXDIAyCAJERO(corteBuffer, null);


            if (corteBuffer == null)
            {
                return false;
            }

            if ((bool)corteBuffer.isnull["ITIPOCORTEID"] || corteBuffer.ITIPOCORTEID == DBValues._TIPO_CORTENORMAL)
            {


                TimeSpan ts = DateTime.Now - fechaCorte;
                if (fechaCorte != null && fechaCorte < DateTime.Today && ts.Hours > 6)
                {

                    return false;
                }

                
            }
            m_corteId = corteBuffer.IID;
            
            this.CBCajero.SelectedDataValue = CurrentUserID.CurrentUser.IID.ToString();
            this.LBFechaCorte.Text = fechaCorte.ToString("dd/MM/yyyy");
            return true;




        }



        private bool ChecarReferencia(ref string comentario)
        {
            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE doctoBE = new CDOCTOBE();
            doctoBE.IID = m_doctoId_reference;

            doctoBE = doctoD.seleccionarDOCTO(doctoBE, null);

            if(doctoBE == null)
            {
                comentario = "El retiro de referencia no se encontro";
                return false;
            }

            m_doctoBE = doctoBE;

            CCORTEBE corteBuffer = new CCORTEBE();
            CCORTED corteD = new CCORTED();
            corteBuffer.IID = doctoBE.ICORTEID;
            corteBuffer = corteD.seleccionarCORTE(corteBuffer, null);


            if (corteBuffer == null)
            {
                return false;
            }

            m_corteId = corteBuffer.IID;
            m_fechaCorte_referencia = corteBuffer.IFECHACORTE;

            this.CBCajero.SelectedDataValue = corteBuffer.ICAJEROID.ToString();
            this.LBFechaCorte.Text = m_fechaCorte_referencia.Value.ToString("dd/MM/yyyy");

            this.DTPFecha.Value = m_fechaCorte_referencia.Value;
            this.DTPFecha.Enabled = false;


            m_montoBilletesBE = new CMONTOBILLETESBE();
            CMONTOBILLETESD montoBilletesD = new CMONTOBILLETESD();
            m_montoBilletesBE.IDOCTOID = m_doctoId_reference;
            m_montoBilletesBE = montoBilletesD.seleccionarMONTOBILLETESxDoctoId(m_montoBilletesBE, null);
            if (m_montoBilletesBE != null)
            {
                LlenaGUI(m_montoBilletesBE);
                calcularTotal();
            }

            return true;




        }



        private void LBSaldoTotal_Click(object sender, EventArgs e)
        {

        }

    
        private void PonModoReadOnly()
        {

            this.TBCantPesos1000.ReadOnly = true;
            this.TBCantPesos500.ReadOnly = true;
            this.TBCantPesos200.ReadOnly = true;
            this.TBCantPesos100.ReadOnly = true;
            this.TBCantPesos50.ReadOnly = true;
            this.TBCantPesos20.ReadOnly = true;

            this.TBTipoCambio.ReadOnly = true;

            this.TBCantDolar100.ReadOnly = true;
            this.TBCantDolar50.ReadOnly = true;
            this.TBCantDolar20.ReadOnly = true;
            this.TBCantDolar10.ReadOnly = true;
            this.TBCantDolar5.ReadOnly = true;
            this.TBCantDolar2.ReadOnly = true;
            this.TBCantDolar1.ReadOnly = true;



            this.TBImportePesosMorralla.ReadOnly = true;
            this.TBImporteDolaresMorralla.ReadOnly = true;
            this.TBChequesImporte.ReadOnly = true;
            this.TBValesImporte.ReadOnly = true;

            this.BtnEnviar.Enabled = false;
        }

        private void DTPFecha_Validating(object sender, CancelEventArgs e)
        {

            if (DTPFecha.Value.Date > DateTime.Today)
            {
                MessageBox.Show("No puede seleccionar una fecha futura");
                e.Cancel = true;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            this.imprimirTicketRetiro(1);
        }
    }
}
