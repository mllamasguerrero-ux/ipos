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

namespace iPos
{
    public partial class CorteCerrar : IposForm
    {
        private CCORTEBE m_corteBE;
        string m_printer = "";
        public bool m_bCorteCerrado;

        long m_cajaid=0, m_cajeroid=0;

        CPERSONABE m_cajeroBE;

        public CorteCerrar()
        {
            InitializeComponent();
            m_corteBE = new CCORTEBE();
            m_bCorteCerrado = false;
            m_cajeroBE = new CPERSONABE();
        }

        private void CorteCerrar_Load(object sender, EventArgs e)
        {
            if (!ChecarPermisos())
            {
                this.Close();
                return;
            }

            if (CurrentUserID.CurrentParameters.IHABFONDODINAMICO != null &&
                CurrentUserID.CurrentParameters.IHABFONDODINAMICO.Equals("S"))
            {
                pnlFondoDinamico.Visible = true;
            }
            else
            {
                pnlFondoDinamico.Visible = false;
            }


            CPERSONAD userD = new CPERSONAD();
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            DateTime fechaCorte = DateTime.MinValue;
            if (userD.UsuarioEsAdmin(CurrentUserID.CurrentUser.IID, null) || CurrentUserID.CurrentParameters.ICORTEPORMAIL != "S")
            {


                
                WFPreguntaAutorizacion ps2 = new WFPreguntaAutorizacion();
                ps2.ShowDialog();
                CPERSONABE userBE = ps2.m_userBE;
                bool bPassValido = ps2.m_bPassValido;
                bool bIsSupervisor = ps2.m_bIsSupervisor;
                bool bIsAdministrador = ps2.m_bIsAdministrador;
                ps2.Dispose();
                GC.SuppressFinalize(ps2);

                if (!bPassValido)
                {
                    this.Close();
                    return;
                }

                if (!bIsSupervisor)
                {
                    MessageBox.Show("El usuario no es un supervisor");
                    this.Close();
                    return;
                }

                //si no hay corte activo , salir de la pantalla
                m_printer = Ticket.GetReceiptPrinter();
                if (!pvd.HayCorteActivo(ref fechaCorte, iPos.CurrentUserID.CurrentUser.IID))
                {
                    /*MessageBox.Show("No hay corte abierto");
                    this.Close();
                    return;*/
                    SeleccionarCorte();
                }
                else
                {

                        ObtenerTotalesUsuarioActual();

                }

                this.reportViewer2.RefreshReport();
            }
            else
            {
                if (!pvd.HayCorteActivo(ref fechaCorte, iPos.CurrentUserID.CurrentUser.IID))
                {
                    MessageBox.Show("No hay corte abierto");
                    this.Close();
                    return;
                }

                // checar que ya hayan regsitrado la cantidad de billetes
                CCORTED corteD = new CCORTED();
                CCORTEBE corteBuffer = new CCORTEBE();
                corteBuffer.IFECHACORTE = fechaCorte;
                corteBuffer.ICAJEROID = iPos.CurrentUserID.CurrentUser.IID;
                corteBuffer = corteD.seleccionarCORTEXDIAyCAJERO(corteBuffer, null);
                CMONTOBILLETESBE montoBilletesBE = new CMONTOBILLETESBE();
                CMONTOBILLETESD montoBilletesD = new CMONTOBILLETESD();
                montoBilletesBE.ICORTEID = corteBuffer.IID;
                montoBilletesBE = montoBilletesD.seleccionarMONTOBILLETESxCorte(montoBilletesBE, null);
                if (montoBilletesBE == null)
                {
                    MessageBox.Show("Debe hacer el corte de billetes antes de cerrar el corte");
                    this.Close();
                    return;
                }



                if (MessageBox.Show("Seguro que desea cerrar el corte?  ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CerrarCorteYEnviarPorMail();
                }
            }
        }





        private void GetCajero()
        {
            CPERSONAD personaD = new CPERSONAD();
            m_cajeroBE = new CPERSONABE();
            m_cajeroBE.IID = m_cajeroid;
            m_cajeroBE = personaD.seleccionarPERSONA(m_cajeroBE, null);

        }

        private void ObtenerTotalesUsuarioActual()
        {
            CCORTED corteD = new CCORTED();
            m_corteBE.ISUCURSALID = CurrentUserID.CurrentParameters.ISUCURSALID;
            m_corteBE.ICAJEROID = iPos.CurrentUserID.CurrentUser.IID;
            m_corteBE.ICAJAID = iPos.CurrentUserID.CurrentCompania.IEM_CAJA;
            m_corteBE = corteD.ObtenTotalesCORTE(m_corteBE, null);


            m_cajaid = iPos.CurrentUserID.CurrentCompania.IEM_CAJA;
            m_cajeroid = iPos.CurrentUserID.CurrentUser.IID;
            GetCajero();
           
            if (m_corteBE == null)
            {
                MessageBox.Show(corteD.IComentario);
                VaciarTotales();
                return;
            }
            else
            {
                LlenaTotales();
            }
            llenaCorteTotalesXLinea((int)m_corteBE.IID);
            LlenarReporteDesglosado();
        }


        private void CerrarCorteYEnviarPorMail()
        {




            CCORTED corteD = new CCORTED();
            m_corteBE.ISUCURSALID = CurrentUserID.CurrentParameters.ISUCURSALID;
            m_corteBE.ICAJEROID = iPos.CurrentUserID.CurrentUser.IID;
            m_corteBE.ICAJAID = iPos.CurrentUserID.CurrentCompania.IEM_CAJA;
            m_corteBE = corteD.ObtenTotalesCORTE(m_corteBE, null);
                

            if (m_corteBE == null)
            {
                MessageBox.Show(corteD.IComentario);
                this.Close();
                return;
            }
                
            long corteId = m_corteBE.IID;


            m_corteBE.ICAJEROID = iPos.CurrentUserID.CurrentUser.IID;
            m_corteBE.IDIFERENCIA = m_corteBE.ISALDOFINAL - m_corteBE.ISALDOREAL - m_corteBE.ISALDOREALCREDITO;

            int errorCode = 0;

            if (corteD.CerrarCORTED(m_corteBE, ref errorCode, null) == null)
            {
                MessageBox.Show(corteD.IComentario);
                if(errorCode == 5011)
                {
                    WFVentasConErrorEmida corteEmida = new WFVentasConErrorEmida();
                    corteEmida.ShowDialog();
                    corteEmida.Dispose();
                    GC.SuppressFinalize(corteEmida);
                }
                this.Close();
                return;
            }
            else
            {
                //MessageBox.Show("El corte se ha cerrado con exito");
                m_bCorteCerrado = true;
            }


            if ((CurrentUserID.ES_SUPERVISOR || CurrentUserID.ES_ADMINISTRADOR) ||
                (iPos.CurrentUserID.CurrentParameters.IHABIMPRESIONCORTECAJERO != null && iPos.CurrentUserID.CurrentParameters.IHABIMPRESIONCORTECAJERO == "S"))
            {
                WFImpresionCorte ic2 = new WFImpresionCorte(corteId);
                ic2.ShowDialog();
                bool bTicketImpreso = ic2.m_bTicketImpreso;
                ic2.Dispose();
                GC.SuppressFinalize(ic2);

                if (bTicketImpreso)
                    MessageBox.Show("El ticket se imprimio");

            }

            
            iPos.Cortes.CorteXMailTest ic = new iPos.Cortes.CorteXMailTest((int)m_corteBE.IID, CurrentUserID.CurrentParameters);
            ic.ShowDialog();
            ic.Dispose();
            GC.SuppressFinalize(ic);


            EnviarVentasDeCorteSiAplica(corteId);

            this.Close();
        }


        private  void EnviarVentasDeCorteSiAplica(long corteId)
        {
            if (CurrentUserID.CurrentParameters.IVENTASXCORTEEMAIL != null && CurrentUserID.CurrentParameters.IVENTASXCORTEEMAIL.Equals("S")
                && CurrentUserID.CurrentParameters.IMAILEJECUTIVO != null )
            {
                try
                {

                    CCORTED corteD = new CCORTED();
                    CCORTEBE corteBE = new CCORTEBE();
                    corteBE.IID = corteId;
                    corteBE = corteD.seleccionarCORTE(corteBE, null);

                    if(corteBE == null)
                    {
                        MessageBox.Show("No se encontro el corte");
                        return;
                    }

                    CPERSONABE cajeroBE = new CPERSONABE();
                    CPERSONAD personaD = new CPERSONAD();

                    cajeroBE.IID = m_corteBE.ICAJEROID;
                    cajeroBE = personaD.seleccionarPERSONA(cajeroBE, null);
                    if (cajeroBE == null)
                    {
                        MessageBox.Show("No se encontro el cajero");
                        return;
                    }

                    CSUCURSALD sucursalD = new CSUCURSALD();
                    CSUCURSALBE sucursalBE = new CSUCURSALBE();
                    sucursalBE.IID = CurrentUserID.CurrentParameters.ISUCURSALID;

                    sucursalBE = sucursalD.seleccionarSUCURSAL(sucursalBE, null);

                    if (sucursalBE == null)
                    {
                        MessageBox.Show("No se encontro la sucursal");
                        return;
                    }

                    //enviasr
                    Dictionary<string, object> dictionary = new Dictionary<string, object>();
                    dictionary.Add("corteid", corteId);
                    string strReporte = "InformeProductoVendidosXCorte.frx";
                    string stSubject = "Corte de la fecha " + corteBE.IFECHACORTE.ToString("dd/MM/yyyy") + " " + (cajeroBE != null ? "Cajero " + cajeroBE.INOMBRE : "") + " " + (sucursalBE != null ? "Sucursal " +  sucursalBE.INOMBRE  : "");
                    string stBody = "Corte de la fecha " + corteBE.IFECHACORTE.ToString("dd/MM/yyyy") + " " + (cajeroBE != null ? "Cajero " + cajeroBE.INOMBRE : "") + " " + (sucursalBE != null ? "Sucursal " + sucursalBE.INOMBRE : "");

                    string strCorreo = CurrentUserID.CurrentParameters.IMAILEJECUTIVO;
                    iPos.Login_and_Maintenance.WFReportSending rp = new Login_and_Maintenance.WFReportSending(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), strCorreo, dictionary, stSubject, "XLS",stBody);
                    rp.ShowDialog();
                    rp.Dispose();
                    GC.SuppressFinalize(rp);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ObtenerTotalesDeCorte( long corteId)
        {
            CCORTED corteD = new CCORTED();
            m_corteBE.IID = corteId;

            m_corteBE = corteD.seleccionarCORTE(m_corteBE, null);
            if (m_corteBE == null)
            {
                MessageBox.Show("El corte seleccionado no se pudo obtener");
                return;
            }


            m_cajaid = m_corteBE.ICAJAID;
            m_cajeroid = m_corteBE.ICAJEROID;
            GetCajero();

            m_corteBE = corteD.ObtenTotalesCORTE(m_corteBE, null);
            if (m_corteBE == null)
            {
                MessageBox.Show(corteD.IComentario);
                VaciarTotales();
                return;
            }
            else
            {
                LlenaTotales();
            }
            llenaCorteTotalesXLinea((int)m_corteBE.IID);
            LlenarReporteDesglosado();



        }

        public void LlenarReporteDesglosado()
        {

            this.CORTE_CALCULO_DETALLETableAdapter.Fill(this.DSCortesB.CORTE_CALCULO_DETALLE, (int)m_corteBE.IID);

            this.CORTE_CALCULO_NOAPLICADOTableAdapter.Fill(this.DSCortesB.CORTE_CALCULO_NOAPLICADO, (int)m_corteBE.IID);

            try
            {
                Microsoft.Reporting.WinForms.ReportParameter[] Param = new Microsoft.Reporting.WinForms.ReportParameter[3];
                Param[0] = new Microsoft.Reporting.WinForms.ReportParameter("Fecha", m_corteBE.IFECHACORTE.ToString("dd/MM/yyyy"));
                Param[1] = new Microsoft.Reporting.WinForms.ReportParameter("Cajero", (m_cajeroBE == null) ? "" : m_cajeroBE.INOMBRE);
                Param[2] = new Microsoft.Reporting.WinForms.ReportParameter("Corte", m_corteBE.IID.ToString("N0"));
                this.reportViewer1.LocalReport.SetParameters(Param);
                this.reportViewer1.RefreshReport();

                this.reportViewer2.LocalReport.SetParameters(Param);
                this.reportViewer2.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " -- " + ex.StackTrace);
            }

        }

        private void LlenaTotales()
        {
            LBAportacion.Text = m_corteBE.IAPORTACION.ToString("N2");
            LBPagoProveedores.Text = m_corteBE.IPAGOPROVEEDORES.ToString("N2");
            LBIngreso.Text = m_corteBE.IINGRESO.ToString("N2");
            LBRetiro.Text = m_corteBE.IRETIRO.ToString("N2");
            LBSaldoFinal.Text = m_corteBE.ISALDOFINAL.ToString("N2");
            LBSaldoInicial.Text = m_corteBE.ISALDOINICIAL.ToString("N2");
            NTBSaldoReal.Text = m_corteBE.ISALDOREAL.ToString("N2");


            NTBFondoFinal.Text = m_corteBE.IFONDODINAMICOFINAL.ToString("N2");

            LBFondeoDeCaja.Text = m_corteBE.IFONDEOSDECAJA.ToString("N2");

            LBIngresoEfectivo.Text = m_corteBE.IINGRESOEFECTIVO.ToString("N2");
            LBIngresoTarjeta.Text = m_corteBE.IINGRESOTARJETA.ToString("N2");
            LBIngresoCredito.Text = m_corteBE.IINGRESOCREDITO.ToString("N2");
            LBIngresoCheque.Text = m_corteBE.IINGRESOCHEQUE.ToString("N2");
            LBIngresoVale.Text = m_corteBE.IINGRESOVALE.ToString("N2");
            LBCambioCheque.Text = m_corteBE.ICAMBIOCHEQUE.ToString("N2");
            LBIngresoMonedero.Text = m_corteBE.IINGRESOMONEDERO.ToString("N2");
            LBIngresoTransferencia.Text = m_corteBE.IINGRESOTRANSFERENCIA.ToString("N2");



            LBEgresoEfectivo.Text = m_corteBE.IEGRESOEFECTIVO.ToString("N2");
            LBEgresoTarjeta.Text = m_corteBE.IEGRESOTARJETA.ToString("N2");
            LBEgresoCredito.Text = m_corteBE.IEGRESOCREDITO.ToString("N2");
            LBEgresoCheque.Text = m_corteBE.IEGRESOCHEQUE.ToString("N2");
            LBEgresoVale.Text = m_corteBE.IEGRESOVALE.ToString("N2");
            LBEgresoMonedero.Text = m_corteBE.IEGRESOMONEDERO.ToString("N2");
            LBEgresoTransferencia.Text = m_corteBE.IEGRESOTRANSFERENCIA.ToString("N2");


           

            LBSaldoInicialTotal.Text = m_corteBE.ISALDOINICIAL.ToString("N2");
            LBCambioChequeTotal.Text = m_corteBE.ICAMBIOCHEQUE.ToString("N2");
            LBTotalVale.Text = m_corteBE.IINGRESOVALE.ToString("N2");
            LBAportacionTotal.Text = m_corteBE.IAPORTACION.ToString("N2");
            LBRetiroTotal.Text = (m_corteBE.IRETIRO * -1).ToString("N2");

            LBFondeoDeCajaTotal.Text = (m_corteBE.IFONDEOSDECAJA ).ToString("N2");

            LBTotalEfectivo.Text = (m_corteBE.IINGRESOEFECTIVO -  m_corteBE.IEGRESOEFECTIVO).ToString("N2");
            LBTotalTarjeta.Text = (m_corteBE.IINGRESOTARJETA - m_corteBE.IEGRESOTARJETA).ToString("N2");
            LBTotalCredito.Text = (m_corteBE.IINGRESOCREDITO - m_corteBE.IEGRESOCREDITO).ToString("N2");
            LBTotalCheque.Text = (m_corteBE.IINGRESOCHEQUE - m_corteBE.IEGRESOCHEQUE).ToString("N2");

            LBTotalMonedero.Text = (m_corteBE.IINGRESOMONEDERO - m_corteBE.IEGRESOMONEDERO).ToString("N2");
            LBTotalTransferencia.Text = (m_corteBE.IINGRESOTRANSFERENCIA - m_corteBE.IEGRESOTRANSFERENCIA).ToString("N2");

            LBPagoProveedoresTotales.Text = (m_corteBE.IPAGOPROVEEDORES * -1).ToString("N2");


            LBEgreso.Text = m_corteBE.IEGRESO.ToString("N2");


        }

        private void VaciarTotales()
        {
            LBAportacion.Text = "";
            LBPagoProveedores.Text = "";
            LBIngreso.Text = "";
            LBRetiro.Text = "";
            LBSaldoFinal.Text = "";
            LBSaldoInicial.Text = "";
            NTBSaldoReal.Text = "0.00";

            NTBFondoFinal.Text = "0.00";

            LBFondeoDeCaja.Text = "";

            LBIngresoCredito.Text = "";

            LBCambioCheque.Text = "";

            LBIngresoEfectivo.Text = "";
            LBIngresoTarjeta.Text = "";
            LBIngresoCheque.Text = "";
            LBIngresoVale.Text = "";
            LBIngresoMonedero.Text = "";
            LBIngresoTransferencia.Text = "";


            LBEgresoEfectivo.Text = "";
            LBEgresoTarjeta.Text = "";
            LBEgresoCheque.Text = "";
            //LBEgresoValeContado.Text = "";
            LBEgresoVale.Text = "";
            LBEgresoMonedero.Text = "";
            LBEgresoTransferencia.Text = "";

        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            CCORTED corteD = new CCORTED();
            long corteId = m_corteBE.IID;

            m_corteBE.ISALDOREAL = decimal.Parse(NTBSaldoReal.Text.ToString()); 
            m_corteBE.ISALDOREALCREDITO = decimal.Parse(NTBSaldoRealCredito.Text.ToString());
            m_corteBE.IDIFERENCIA = m_corteBE.ISALDOFINAL - m_corteBE.ISALDOREAL - m_corteBE.ISALDOREALCREDITO;
            m_corteBE.ICAJAID = m_cajaid;
            m_corteBE.ICAJEROID = m_cajeroid;



            //guardar fondo dinamico si aplica
            if (CurrentUserID.CurrentParameters.IHABFONDODINAMICO != null && CurrentUserID.CurrentParameters.IHABFONDODINAMICO.Equals("S"))
            {
                decimal fondoDinamicoFinal = decimal.Parse(NTBFondoFinal.Text.ToString());
                decimal fondoDinamicoAnterior = m_corteBE.IFONDODINAMICOFINAL;

                if (fondoDinamicoFinal != fondoDinamicoAnterior)
                { 
                    if (!corteD.CORTE_CAMBIARFONDODINAMICOFINAL(m_corteBE.IID, fondoDinamicoFinal, null))
                    {

                        MessageBox.Show(corteD.IComentario);
                        return;
                    }
                    m_corteBE.IFONDODINAMICOFINAL = fondoDinamicoFinal;
                    ObtenerTotalesDeCorte(corteId);

                }
            }


            long cantidadBanc = 0;
            corteD.GET_VENTASPEND_PAGOS_BANCOMER(corteId, ref cantidadBanc, null);
            if(cantidadBanc > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Tiene Ventas Pendientes con Pagos terminal Bancomer ya procesados, Primero debe pasar a remisionarlos y despues reintentar.. desea ir a pasar esas ventas a remisiones?", "Advertencia!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        corteD.CORTE_REMISIONAR_PEND_BANCOMER(corteId, null);
                    }
                    catch(Exception exc)
                    {
                        MessageBox.Show("No se pudo realizar el proceso algo salio mal!" + exc);
                        return;
                    }


                    ObtenerTotalesDeCorte(corteId);
                    this.reportViewer2.RefreshReport();


                    return;
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }

            int errorCode = 0;

            if (corteD.CerrarCORTED(m_corteBE, ref errorCode, null) == null)
            {
                MessageBox.Show(corteD.IComentario);
                if (errorCode == 5011)
                {
                    WFVentasConErrorEmida corteEmida = new WFVentasConErrorEmida();
                    corteEmida.ShowDialog();
                    corteEmida.Dispose();
                    GC.SuppressFinalize(corteEmida);


                    ObtenerTotalesDeCorte(corteId);
                    this.reportViewer2.RefreshReport();
                }
                return;
            }
            else
            {
                MessageBox.Show("El corte se ha cerrado con exito");
                m_bCorteCerrado = true;
                   

                if (CurrentUserID.ES_SUPERVISOR || CurrentUserID.ES_ADMINISTRADOR)
                {
                    


                    bool bTicketImpreso = ImprimirCorte(corteId);
                    if (bTicketImpreso)
                        MessageBox.Show("El ticket se imprimio");

                }

                iPos.Cortes.CorteXMailTest ic = new iPos.Cortes.CorteXMailTest((int)m_corteBE.IID, CurrentUserID.CurrentParameters);
                ic.ShowDialog();
                ic.Dispose();
                GC.SuppressFinalize(ic);

                EnviarVentasDeCorteSiAplica(corteId);

                this.Close();
            }
            

        }


        public static bool ImprimirCorte(long corteId)
        {
            int iCantidadTickets = CurrentUserID.CurrentParameters.ICANTTICKETCIERRECORTE > 0 ? CurrentUserID.CurrentParameters.ICANTTICKETCIERRECORTE : 1;
            for (int i = 0; i < iCantidadTickets; i++)
            {


                WFImpresionCorte ic = new WFImpresionCorte(corteId);
                ic.ShowDialog();
                bool bTicketImpreso = ic.m_bTicketImpreso;
                ic.Dispose();
                GC.SuppressFinalize(ic);

            }

            return true;
        }


        public void ImprimirTicket(long corteId)
        {

            //int iXLetraRenglon = 0;
            this.corteTicketBTableAdapter.Fill(this.dSReimpresionTicket.CorteTicketB, corteId);
            this.corteTrasladosTableAdapter.Fill(this.dSPuntoVenta.CorteTraslados, corteId);

            decimal dVentasNetas = decimal.Parse(this.dSReimpresionTicket.CorteTicketB.Rows[0]["INGRESO"].ToString()) - decimal.Parse(this.dSReimpresionTicket.CorteTicketB.Rows[0]["DEVOLUCION"].ToString());

            Ticket ticket = new Ticket();


            ticket.AddHeaderLine("Numero De Corte : " + this.dSReimpresionTicket.CorteTicketB.Rows[0]["FOLIO"].ToString());
            ticket.AddHeaderLine("Sucursal        : " + this.dSReimpresionTicket.CorteTicketB.Rows[0]["SUCURSAL"].ToString());
            ticket.AddHeaderLine("Caja            : " + this.dSReimpresionTicket.CorteTicketB.Rows[0]["CAJA"].ToString());
            //ticket.AddHeaderLine("Turno           : " + this.dSReimpresionTicket.CorteTicketB.Rows[0]["TURNO"].ToString());
            ticket.AddHeaderLine("Cajero          : " + this.dSReimpresionTicket.CorteTicketB.Rows[0]["CAJERO"].ToString());
            ticket.AddHeaderLine("Fecha           : " + DateTime.Now.ToShortDateString());
            ticket.AddHeaderLine("Hora            : " + DateTime.Now.ToShortTimeString());
            //ticket.AddHeaderLine(new string('-', Ticket.maxChar));



            ticket.AddHeaderLine("LINEA               ");
            ticket.AddHeaderLine(" DEVOLUCIONES   VENTAS    TOTAL");

            ticket.AddHeaderLine(new string('-', Ticket.maxChar));

            string line;
            decimal d_devoluciones = 0, d_ventas = 0, d_total = 0;
            decimal d_devoluciones_sum = 0, d_ventas_sum = 0, d_total_sum = 0;
            foreach (DataRow dr in this.dSPuntoVenta.CORTEXLINEA.Rows)
            {
                d_devoluciones = 0;
                d_ventas = 0;
                d_total = 0;

                if (dr["DEVOLUCIONES"] != null && dr["DEVOLUCIONES"] != DBNull.Value)
                    d_devoluciones = (decimal)dr["DEVOLUCIONES"];


                if (dr["VENTAS"] != null && dr["VENTAS"] != DBNull.Value)
                    d_ventas = (decimal)dr["VENTAS"];

                d_total = d_ventas - d_devoluciones;


                d_devoluciones_sum += d_devoluciones;
                d_ventas_sum += d_ventas;
                d_total_sum += d_total;

                if (dr["NOMBRE"] != null && dr["NOMBRE"] != DBNull.Value)
                    ticket.AddHeaderLine(dr["NOMBRE"].ToString().Trim());


                    line = "";
                    line += Ticket.FormatPrintField(d_devoluciones.ToString("N2"), 11, 0) + "  ";
                    line += Ticket.FormatPrintField(d_ventas.ToString("N2"), 11, 0) + "  ";
                    line += Ticket.FormatPrintField(d_total.ToString("N2"), 11, 0) + "  ";
                    ticket.AddHeaderLine(line);

                ticket.AddHeaderLine("");

            }

            ticket.AddHeaderLine(new string('-', Ticket.maxChar));

            line = "";
            line += Ticket.FormatPrintField(d_devoluciones_sum.ToString("N2"), 11, 0) + "  ";
            line += Ticket.FormatPrintField(d_ventas_sum.ToString("N2"), 11, 0) + "  ";
            line += Ticket.FormatPrintField(d_total_sum.ToString("N2"), 11, 0) + "  ";
            ticket.AddHeaderLine(line);



            /***Traslados**/
            ticket.AddHeaderLine(new string('-', Ticket.maxChar));
            ticket.AddHeaderLine(" FOLIO     SUCURSAL                 TOTAL");
            decimal dTrasladoItem = 0, dTrasladoTotal = 0;
            foreach (DataRow drTraslados in this.dSPuntoVenta.CorteTraslados.Rows)
            {

                dTrasladoItem = (decimal) drTraslados["TOTAL"];
                dTrasladoTotal += dTrasladoItem;
                line = "";
                line += Ticket.FormatPrintField(drTraslados["FOLIO"].ToString(), 10, 0) + " ";
                line += Ticket.FormatPrintField(drTraslados["SUCURSAL"].ToString(), 12, 0) + " ";
                line += Ticket.FormatPrintField(dTrasladoItem.ToString("N2"), 15, 0);
                ticket.AddHeaderLine(line);

            }
            /***Traslados**/


            ticket.AddHeaderLine(new string('-', Ticket.maxChar));

            ticket.AddTotal("Ventas          : " , decimal.Parse(this.dSReimpresionTicket.CorteTicketB.Rows[0]["INGRESO"].ToString()).ToString("N2"));
            ticket.AddTotal("Devoluciones    : " , decimal.Parse(this.dSReimpresionTicket.CorteTicketB.Rows[0]["DEVOLUCION"].ToString()).ToString("N2"));
            ticket.AddTotal("Ventas Neta     : " , dVentasNetas.ToString("N2"));
            ticket.AddTotal(new string('-', Ticket.maxChar - 5),"");
            ticket.AddTotal("Saldo Inicial   : " , decimal.Parse(this.dSReimpresionTicket.CorteTicketB.Rows[0]["SALDOINICIAL"].ToString()).ToString("N2"));
            ticket.AddTotal("Efectivo        : ", decimal.Parse(this.dSReimpresionTicket.CorteTicketB.Rows[0]["INGRESO"].ToString()).ToString("N2"));
            ticket.AddTotal("Tarjeta         : " , "0.00");
            ticket.AddTotal("Aportacion      : ", decimal.Parse(this.dSReimpresionTicket.CorteTicketB.Rows[0]["APORTACION"].ToString()).ToString("N2"));
            ticket.AddTotal("Pago a prov.    : ", decimal.Parse(this.dSReimpresionTicket.CorteTicketB.Rows[0]["PAGOPROVEEDORES"].ToString()).ToString("N2"));
            //ticket.AddTotal("Intercambio merc: ", decimal.Parse(this.dSReimpresionTicket.CorteTicketB.Rows[0]["INTERCAMBIOMERCANCIA"].ToString()).ToString("N2"));
            ticket.AddTotal("Retiro          : " , decimal.Parse(this.dSReimpresionTicket.CorteTicketB.Rows[0]["RETIRO"].ToString()).ToString("N2"));

            if (CurrentUserID.CurrentParameters.IHABFONDODINAMICO != null && CurrentUserID.CurrentParameters.IHABFONDODINAMICO.Equals("S"))
                ticket.AddTotal("Fondo dinamico  : ", decimal.Parse(this.dSReimpresionTicket.CorteTicketB.Rows[0]["FONDODINAMICODIFERENCIA"].ToString()).ToString("N2"));

            ticket.AddTotal("Saldo Final     : ", decimal.Parse(this.dSReimpresionTicket.CorteTicketB.Rows[0]["SALDOFINAL"].ToString()).ToString("N2"));
            ticket.AddTotal("Saldo Real      : ", decimal.Parse(this.dSReimpresionTicket.CorteTicketB.Rows[0]["SALDOREAL"].ToString()).ToString("N2"));
            ticket.AddTotal("Diferencia      : ",( decimal.Parse(this.dSReimpresionTicket.CorteTicketB.Rows[0]["SALDOREAL"].ToString()) - decimal.Parse(this.dSReimpresionTicket.CorteTicketB.Rows[0]["SALDOFINAL"].ToString())).ToString("N2")); 
            ticket.AddTotal(new string('-', Ticket.maxChar - 5), "");
            ticket.AddTotal("No. Tickets          : " , this.dSReimpresionTicket.CorteTicketB.Rows[0]["NUM_TICKETS"].ToString());
            ticket.AddTotal("No. Devoluciones     : ", this.dSReimpresionTicket.CorteTicketB.Rows[0]["NUM_DEVOLUCIONES"].ToString());

            /***Traslados**/
            ticket.AddTotal(new string('-', Ticket.maxChar - 5), "");
            ticket.AddTotal("Total Traslados          : ", dTrasladoTotal.ToString("N2"));
            /***Traslados**/
            
            ticket.AddFooterLine("");

            if (m_printer != "")
                ticket.PrintTicketDirect(this.m_printer);


        }

        private void llenaCorteTotalesXLinea(int corteId)
        {
            try
            {
                this.cORTEXLINEATableAdapter.Fill(this.dSPuntoVenta.CORTEXLINEA,corteId);
            }
            catch
            {
            }

        }


        private bool ChecarPermisos()
        {

            CPERSONAD personaD = new CPERSONAD();
            int iMenu = int.Parse(DBValues._MENUID_CORTECERRAR.ToString());
            if (!personaD.UsuarioTieneDerechoAMenu(CurrentUserID.CurrentUser.IID, iMenu, null))
            {
                MessageBox.Show("El usuario no tiene derecho a este form");
                return false;
            }
            return true;
        }

        private void btnSeleccionarCorte_Click(object sender, EventArgs e)
        {
            SeleccionarCorte();
        }

        private void btnImprimirDetalles_Click(object sender, EventArgs e)
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

        private void SeleccionarCorte()
        {
            iPos.PuntoDeVenta.CortesAbiertos ca = new PuntoDeVenta.CortesAbiertos();
            ca.ShowDialog();

            DataRow dr = ca.m_rtnDataRow;
            
            ca.Dispose();
            GC.SuppressFinalize(ca);

            if (dr != null)
            {
               long corteId = long.Parse(dr["FOLIO"].ToString());
                ObtenerTotalesDeCorte( corteId);
            }
            else
            {
                this.Close();
            }
        }

       

    }
}
