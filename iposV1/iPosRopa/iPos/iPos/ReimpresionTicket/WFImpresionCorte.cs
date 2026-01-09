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
using System.IO;
using static iPos.ReimpresionTicket.DSReimpresionTicket2;

namespace iPos
{

    public enum ImpresionCorteOption { PorCorte = 1, PorDia, SumarizadoDelDia, SumarizadoDelDiaXCajero, MontoBilletes, MontoBilletesPorRetiro, SumarizadoDelDiaXGrupoCajero, Apertura };
    public partial class WFImpresionCorte : IposForm
    {


        string m_printer = "";
        long m_corteId = 0;
        long m_doctoId = 0;
        public bool m_bTicketImpreso = false;

        public ImpresionCorteOption m_iOpcion;
        DateTime m_fecha;

        public bool m_envioMailExitoso = false;
        public DateTime m_currentFechaCorte = DateTime.Today;

        decimal m_ajusteIntercambioIva = 0, m_ajusteTasaIva = 0;

        public string m_aditionalFooter = "";

        

        bool m_sendToPrint = false;
        public int m_numCopias = 1;

        public WFImpresionCorte()
        {
            InitializeComponent();
        }


        public WFImpresionCorte(long corteId):this()
        {
            InitializeComponent();
            m_corteId = corteId;
            m_iOpcion = ImpresionCorteOption.PorCorte;
        }


        public WFImpresionCorte(long corteId, long doctoId, ImpresionCorteOption opcion)
            : this(corteId)
        {
            m_doctoId = doctoId;
            m_iOpcion = opcion;
        }


        public WFImpresionCorte(DateTime fecha, bool bSumarizado, ImpresionCorteOption opcion)
            : this()
        {
            m_fecha = fecha;

            if (bSumarizado)
                m_iOpcion = opcion;
            else
                m_iOpcion = ImpresionCorteOption.PorDia;

           
        }
        

        public WFImpresionCorte(DateTime fecha, bool bSumarizado, ImpresionCorteOption opcion, decimal ajusteIntercambioIva, decimal ajusteTasaIva)
            : this(fecha, bSumarizado,opcion)
        {
            m_ajusteIntercambioIva = ajusteIntercambioIva;
            m_ajusteTasaIva = ajusteTasaIva;
        }



        private void ImprimirTicket(long corteId)
        {
            if(CurrentUserID.CurrentParameters.IFORMATOTICKETCORTOID == 1)
            {
                ImprimirTicketOld(corteId);
                return;
            }

            string bufferLine;
            if (m_sendToPrint)
                return;

            m_sendToPrint = true;

                                                                                                                                                                                    this.corteTicketB2TableAdapter.Fill(this.dataSet1.CorteTicketB2, corteId);
            this.corteTrasladosTableAdapter.Fill(this.dSPuntoVenta.CorteTraslados, corteId);

            if (CurrentUserID.CurrentParameters.IDESGLOSEIEPS.Equals("S"))
              this.cORTEIEPSTableAdapter.Fill(this.dataSet1.CORTEIEPS, corteId);

            int? iCorteId = (int)corteId;
            this.cORTE_CALCULO_DETALLETableAdapter.Fill(this.dSCortesB.CORTE_CALCULO_DETALLE, iCorteId);
            //llenaCorteTotalesXLinea((int)corteId);

            decimal dVentasNetas = decimal.Parse(this.dataSet1.CorteTicketB2.Rows[0]["INGRESO"].ToString()) - decimal.Parse(this.dataSet1.CorteTicketB2.Rows[0]["DEVOLUCION"].ToString());

            Ticket ticket = new Ticket();


            ticket.AddHeaderLine("Numero De Corte : " + this.dataSet1.CorteTicketB2.Rows[0]["FOLIO"].ToString());
            ticket.AddHeaderLine("Sucursal        : " + this.dataSet1.CorteTicketB2.Rows[0]["SUCURSAL"].ToString());
            ticket.AddHeaderLine("Caja            : " + this.dataSet1.CorteTicketB2.Rows[0]["CAJA"].ToString());
            //ticket.AddHeaderLine("Turno           : " + this.dataSet1.CorteTicketB2.Rows[0]["TURNO"].ToString());
            ticket.AddHeaderLine("Cajero          : " + this.dataSet1.CorteTicketB2.Rows[0]["CAJERO"].ToString());
            ticket.AddHeaderLine("Fecha           : " + DateTime.Now.ToShortDateString());
            ticket.AddHeaderLine("Hora            : " + DateTime.Now.ToShortTimeString());


            ticket.AddHeaderLine(new string(' ', Ticket.maxChar));

            ticket.AddHeaderLine(new string('=', Ticket.maxChar));
            ticket.AddHeaderLine("Fecha inicio    : " + ((DateTime)this.dataSet1.CorteTicketB2.Rows[0]["INICIA"]).ToString("dd/MM/yyyy hh:mm"));
            ticket.AddHeaderLine("Fecha fin       : " + ((DateTime)this.dataSet1.CorteTicketB2.Rows[0]["TERMINA"]).ToString("dd/MM/yyyy hh:mm"));


            string line;


            /***Traslados**/
            ticket.AddHeaderLine("");
            ticket.AddHeaderLine(new string('=', Ticket.maxChar));
            ticket.AddHeaderLine("DESGLOSE POR TRASLADO");
            ticket.AddHeaderLine(new string('=', Ticket.maxChar));

            ticket.AddHeaderLine(" FOLIO     SUCURSAL               TOTAL");
            decimal dTrasladoItem = 0, dTrasladoTotal = 0;
            foreach (DataRow drTraslados in this.dSPuntoVenta.CorteTraslados.Rows)
            {

                dTrasladoItem = (decimal)drTraslados["TOTAL"];
                dTrasladoTotal += dTrasladoItem;
                line = "";
                line += Ticket.FormatPrintField(drTraslados["FOLIO"].ToString(), 10, 0) + " ";
                line += Ticket.FormatPrintField(drTraslados["SUCURSAL"].ToString(), 12, 0) + " ";
                line += Ticket.FormatPrintField(dTrasladoItem.ToString("N2"), 15, 0);
                ticket.AddHeaderLine(line);

            }
            /***Traslados**/


            ticket.AddHeaderLine(new string('-', Ticket.maxChar));


            ticket.AddHeaderLine("");
            ticket.AddHeaderLine(new string('=', Ticket.maxChar));
            ticket.AddHeaderLine("TOTALES");
            ticket.AddHeaderLine(new string('=', Ticket.maxChar));

            decimal saldoInicial = decimal.Parse(this.dataSet1.CorteTicketB2.Rows[0]["SALDOINICIAL"].ToString());
            bufferLine = saldoInicial.ToString("N2");
            ticket.AddHeaderLine("Saldo Inicial    : " + bufferLine.Substring(0, Math.Min(20, bufferLine.Length)).PadLeft(20) );
            ticket.AddHeaderLine(new string('-', Ticket.maxChar));
            ticket.AddHeaderLine("Por tipo transacción");
            ticket.AddHeaderLine(new string(' ', Ticket.maxChar));
            //ticket.AddTotal("Saldo Inicial    : ", decimal.Parse(this.dataSet1.CorteTicketB2.Rows[0]["SALDOINICIAL"].ToString()).ToString("N2"));
            //ticket.AddTotal(new string('-', Ticket.maxChar - 5), "");
            //ticket.AddTotal("Por tipo transacción", "");
            
            string strTipoTransaccion = "";
            decimal dTotalPorTipo = 0;
            decimal efectivototal = 0, creditototal = 0, valetotal = 0, chequetotal = 0, cambiochequetotal = 0, tarjetatotal = 0, monederototal = 0, transferenciatotal = 0;
            decimal saldototal = saldoInicial /*0*/;
            decimal bufferDecimal = 0;
            foreach (DataRow drTipoTrasaccion in this.dSCortesB.CORTE_CALCULO_DETALLE.Rows)
            {
                
                 try
                 {
                     dTotalPorTipo = (decimal)drTipoTrasaccion["TOTAL_APLICADO"];
                     saldototal += dTotalPorTipo;
                 }
                 catch
                 {
                 }


                 try
                 {
                     bufferDecimal = (decimal)drTipoTrasaccion["EFECTIVO_APLICADO"];
                     efectivototal += bufferDecimal;
                 }
                 catch
                 {
                 }


                 try
                 {
                     bufferDecimal = (decimal)drTipoTrasaccion["TARJETA_APLICADO"];
                     tarjetatotal += bufferDecimal;
                 }
                 catch
                 {
                 }

                 try
                 {
                     bufferDecimal = (decimal)drTipoTrasaccion["CHEQUE_APLICADO"];
                     chequetotal += bufferDecimal;
                 }
                 catch
                 {
                 }

                 try
                 {
                     bufferDecimal = (decimal)drTipoTrasaccion["CAMBIOCHEQUE_APLICADO"];
                     cambiochequetotal += bufferDecimal;
                 }
                 catch
                 {
                 }

                 try
                 {
                     bufferDecimal = (decimal)drTipoTrasaccion["VALE_APLICADO"];
                     valetotal += bufferDecimal;
                 }
                 catch
                 {
                 }

                 try
                 {
                     bufferDecimal = (decimal)drTipoTrasaccion["CREDITO_APLICADO"];
                     creditototal += bufferDecimal;
                 }
                 catch
                 {
                 }


                 try
                 {
                     bufferDecimal = (decimal)drTipoTrasaccion["MONEDERO_APLICADO"];
                     monederototal += bufferDecimal;
                 }
                 catch
                 {
                 }


                 try
                 {
                     bufferDecimal = (decimal)drTipoTrasaccion["TRANSFERENCIA_APLICADO"];
                     transferenciatotal += bufferDecimal;
                 }
                 catch
                 {
                 }

                 strTipoTransaccion = drTipoTrasaccion["TIPOCORTE"].ToString();
                 ticket.AddHeaderLine(strTipoTransaccion);
                 bufferLine = dTotalPorTipo.ToString("N2");
                 ticket.AddHeaderLine( bufferLine.Substring(0, Math.Min(39, bufferLine.Length)).PadLeft(39));
            
            }



            /*
            ticket.AddTotal("Ingresos Venta   : ", decimal.Parse(this.dataSet1.CorteTicketB2.Rows[0]["INGRESO"].ToString()).ToString("N2"));
            ticket.AddTotal("Devoluciones     : ", decimal.Parse(this.dataSet1.CorteTicketB2.Rows[0]["DEVOLUCION"].ToString()).ToString("N2"));
            ticket.AddTotal("Ventas Neta      : ", dVentasNetas.ToString("N2"));
            */
            //ticket.AddHeaderLine("");
            //ticket.AddHeaderLine("");
            ticket.AddHeaderLine(new string('-', Ticket.maxChar));
            ticket.AddHeaderLine("Por forma de pago");
            ticket.AddHeaderLine(new string(' ', Ticket.maxChar));

            /*ticket.AddTotal("Efectivo         : ", efectivototal.ToString("N2"));
            ticket.AddTotal("Tarjeta          : ", tarjetatotal.ToString("N2"));
            ticket.AddTotal("Credito          : ", creditototal.ToString("N2"));
            ticket.AddTotal("Cheque           : ", chequetotal.ToString("N2"));
            ticket.AddTotal("Cambio cheque    : ", cambiochequetotal.ToString("N2"));
            ticket.AddTotal("Vale             : ", valetotal.ToString("N2"));
            ticket.AddTotal("Monedero         : ", monederototal.ToString("N2"));
            ticket.AddTotal("Transferencia         : ", transferenciatotal.ToString("N2"));*/
            //ticket.AddTotal("Aportacion       : ", decimal.Parse(this.dataSet1.CorteTicketB2.Rows[0]["APORTACION"].ToString()).ToString("N2"));


            decimal dCorteEfectivoIngreso = decimal.Parse(this.dataSet1.CorteTicketB2.Rows[0]["INGRESOEFECTIVO"].ToString());
            decimal dCorteEfectivoTrasladosIngreso = decimal.Parse(this.dataSet1.CorteTicketB2.Rows[0]["INGRESOEFECTIVOVENTATRASLADO"].ToString());
            decimal dCorteTarjetaIngreso = decimal.Parse(this.dataSet1.CorteTicketB2.Rows[0]["INGRESOTARJETA"].ToString());
            decimal dCorteCreditoIngreso = decimal.Parse(this.dataSet1.CorteTicketB2.Rows[0]["INGRESOCREDITO"].ToString());
            decimal dCorteChequeIngreso = decimal.Parse(this.dataSet1.CorteTicketB2.Rows[0]["INGRESOCHEQUE"].ToString());
            decimal dCorteValeIngreso = decimal.Parse(this.dataSet1.CorteTicketB2.Rows[0]["INGRESOVALE"].ToString());
            decimal dCorteMonederoIngreso = decimal.Parse(this.dataSet1.CorteTicketB2.Rows[0]["INGRESOMONEDERO"].ToString());
            decimal dCorteTransferenciaIngreso = decimal.Parse(this.dataSet1.CorteTicketB2.Rows[0]["INGRESOTRANSFERENCIA"].ToString());

            decimal dCorteEfectivoEgreso = decimal.Parse(this.dataSet1.CorteTicketB2.Rows[0]["EGRESOEFECTIVO"].ToString());
            decimal dCorteEfectivoTrasladosEgreso = decimal.Parse(this.dataSet1.CorteTicketB2.Rows[0]["EGRESOEFEVENTATRASLADO"].ToString());
            decimal dCorteTarjetaEgreso = decimal.Parse(this.dataSet1.CorteTicketB2.Rows[0]["EGRESOTARJETA"].ToString());
            decimal dCorteCreditoEgreso = decimal.Parse(this.dataSet1.CorteTicketB2.Rows[0]["EGRESOCREDITO"].ToString());
            decimal dCorteChequeEgreso = decimal.Parse(this.dataSet1.CorteTicketB2.Rows[0]["EGRESOCHEQUE"].ToString());
            decimal dCorteValeEgreso = decimal.Parse(this.dataSet1.CorteTicketB2.Rows[0]["EGRESOVALE"].ToString());
            decimal dCorteMonederoEgreso = decimal.Parse(this.dataSet1.CorteTicketB2.Rows[0]["EGRESOMONEDERO"].ToString());
            decimal dCorteTransferenciaEgreso = decimal.Parse(this.dataSet1.CorteTicketB2.Rows[0]["EGRESOTRANSFERENCIA"].ToString());


            decimal dIntercambioMercancia = this.dataSet1.CorteTicketB2.Rows[0]["INTERCAMBIOMERCANCIA"] != null && this.dataSet1.CorteTicketB2.Rows[0]["INTERCAMBIOMERCANCIA"] != DBNull.Value ? decimal.Parse(this.dataSet1.CorteTicketB2.Rows[0]["INTERCAMBIOMERCANCIA"].ToString()) : 0.00m;


            decimal dCorteEfectivoTraslados = dCorteEfectivoTrasladosIngreso - dCorteEfectivoTrasladosEgreso;
            decimal dCorteEfectivo = dCorteEfectivoIngreso - dCorteEfectivoEgreso - dCorteEfectivoTraslados;
            decimal dCorteTarjeta = dCorteTarjetaIngreso - dCorteTarjetaEgreso;
            decimal dCorteCredito = dCorteCreditoIngreso - dCorteCreditoEgreso;
            decimal dCorteCheque = dCorteChequeIngreso - dCorteChequeEgreso;
            decimal dCorteVale = dCorteValeIngreso - dCorteValeEgreso;
            decimal dCorteMonedero = dCorteMonederoIngreso - dCorteMonederoEgreso;
            decimal dCorteTransferencia = dCorteTransferenciaIngreso - dCorteTransferenciaEgreso;


            
            
            ticket.AddTotal("Efectivo - saldo : ", dCorteEfectivo.ToString("N2"));
            ticket.AddTotal("Efe.Trasl. saldo : ", dCorteEfectivoTraslados.ToString("N2"));
            //ticket.AddTotal("Efectivo         : ", decimal.Parse(this.dataSet1.CorteTicketB2.Rows[0]["INGRESOEFECTIVO"].ToString()).ToString("N2"));
            ticket.AddTotal("Tarjeta - saldo  : ", dCorteTarjeta.ToString("N2"));
            ticket.AddTotal("Credito - saldo  : ", dCorteCredito.ToString("N2"));
            ticket.AddTotal("Cheque - saldo   : ", dCorteCheque.ToString("N2"));
            try
            {
                ticket.AddTotal("Cambio cheque    : ", (decimal.Parse(this.dataSet1.CorteTicketB2.Rows[0]["CAMBIOCHEQUE"].ToString()) * -1).ToString("N2"));
            }
            catch { }

            ticket.AddTotal("Vale - saldo     : ", dCorteVale.ToString("N2"));
            ticket.AddTotal("Monedero - saldo : ", dCorteMonedero.ToString("N2"));
            ticket.AddTotal("Transferencia    : ", dCorteTransferencia.ToString("N2"));

            try
            {
                ticket.AddTotal("Intercambio merc.: ", dIntercambioMercancia.ToString("N2"));
            }
            catch
            {

            }
            
            
            //ticket.AddTotal("Aportacion       : ", decimal.Parse(this.dataSet1.CorteTicketB2.Rows[0]["APORTACION"].ToString()).ToString("N2"));
            
            /*
            try
            {
                ticket.AddTotal("Retiro           : ", (decimal.Parse(this.dataSet1.CorteTicketB2.Rows[0]["RETIRO"].ToString()) * -1).ToString("N2"));
            }
            catch
            {
                ticket.AddTotal("Retiro           : ", "0.00");
            }
            try
            {
                ticket.AddTotal("Pago a Prov.     : ", (decimal.Parse(this.dataSet1.CorteTicketB2.Rows[0]["PAGOPROVEEDORES"].ToString()) * -1).ToString("N2"));
            }
            catch
            {
                ticket.AddTotal("Pago a Prov.     : ", "0.00");
            }
            */
            //ticket.AddTotal("Egreso           : ", (decimal.Parse(this.dataSet1.CorteTicketB2.Rows[0]["EGRESO"].ToString())*-1).ToString("N2"));


            ticket.AddTotal(new string(' ', Ticket.maxChar), "");
            ticket.AddTotal(new string('=', Ticket.maxChar), "");

            ticket.AddTotal("Saldo Final      : ", /*decimal.Parse(this.dataSet1.CorteTicketB2.Rows[0]["SALDOFINAL"].ToString())*/saldototal.ToString("N2"));

            decimal saldoRealCredito = 0;
            decimal saldoReal = 0;
            decimal saldoDiferencia = 0;
            decimal.TryParse(this.dataSet1.CorteTicketB2.Rows[0]["SALDOREALCREDITO"].ToString(), out saldoRealCredito);
            decimal.TryParse(this.dataSet1.CorteTicketB2.Rows[0]["SALDOREAL"].ToString(), out saldoReal);
            saldoDiferencia = (saldoReal + saldoRealCredito) - saldototal;

            ticket.AddTotal("Saldo Real       : ", saldoReal.ToString("N2"));
            ticket.AddTotal("Saldo Credito    : ", saldoRealCredito.ToString("N2"));

            ticket.AddTotal("Diferencia       : ", saldoDiferencia.ToString("N2")); 
            ticket.AddTotal(new string('-', Ticket.maxChar - 5), "");
            ticket.AddTotal("No. Tickets          : ", this.dataSet1.CorteTicketB2.Rows[0]["NUM_TICKETS"].ToString());
            ticket.AddTotal("No. Devoluciones     : ", this.dataSet1.CorteTicketB2.Rows[0]["NUM_DEVOLUCIONES"].ToString());

            /***Traslados**/
            ticket.AddTotal(new string('-', Ticket.maxChar - 5), "");
            ticket.AddTotal("Total Traslados          : ", dTrasladoTotal.ToString("N2"));
            /***Traslados**/


            /***IEPS**/
            if (CurrentUserID.CurrentParameters.IDESGLOSEIEPS.Equals("S"))
            {
                ticket.AddFooterLine("");
                ticket.AddFooterLine(new string('=', Ticket.maxChar));
                ticket.AddFooterLine("DESGLOSE POR IEPS");
                ticket.AddFooterLine(new string('=', Ticket.maxChar));

                ticket.AddFooterLine(" TASA                             TOTAL");
                decimal dIepsPorcentaje = 0, dIepsMonto = 0;
                foreach (DataRow drIeps in this.dataSet1.CORTEIEPS.Rows)
                {

                    dIepsPorcentaje = (decimal)drIeps["TASAIEPS"];
                    dIepsMonto = (decimal)drIeps["MONTO"];
                    line = "";
                    line += Ticket.FormatPrintField(dIepsPorcentaje.ToString("N2"), 10, 0) + " ";
                    line += Ticket.FormatPrintField("", 12, 0) + " ";
                    line += Ticket.FormatPrintField(dIepsMonto.ToString("N2"), 15, 0);
                    ticket.AddFooterLine(line);

                }
            }
            /***IEPS**/

            ticket.AddFooterLine("");
            ticket.AddFooterLine("==Corte regular==");

            if (m_printer != "")
                ticket.PrintTicketDirect(this.m_printer);

            m_bTicketImpreso = true;

            this.Close();


        }


        private void llenaCorteTotalesXLinea(int corteId)
        {
            try
            {
                this.cORTEXLINEATableAdapter.Fill(this.dSPuntoVenta.CORTEXLINEA, corteId);
            }
            catch
            {
            }

        }


        private void WFImpresionCorte_Load(object sender, EventArgs e)
        {

            m_printer = Ticket.GetReceiptPrinter();

            switch(m_iOpcion)
            {
                case ImpresionCorteOption.PorCorte:  ImprimirTicket(m_corteId); break;
                case ImpresionCorteOption.PorDia: ImprimirTicketCorto(m_fecha); break;
                case ImpresionCorteOption.SumarizadoDelDia: ImprimirTicketCortoSumarizado(m_fecha); break;
                case ImpresionCorteOption.SumarizadoDelDiaXCajero: ImprimirTicketSumarizadoXCajero(m_fecha); break;
                case ImpresionCorteOption.SumarizadoDelDiaXGrupoCajero: ImprimirTicketSumarizadoXGrupoCajero(m_fecha); break;
                case ImpresionCorteOption.MontoBilletes: ImprimirTicketCorteBilletes(m_corteId); break;
                case ImpresionCorteOption.Apertura: ImprimirTicketCorteApertura(m_corteId); break;
                case ImpresionCorteOption.MontoBilletesPorRetiro:
                    {
                        for( int i = 0; i < m_numCopias; i++)
                            ImprimirTicketCorteBilletesPorRetiro(m_doctoId);
                    }
                    break;
            }
        }



        private void ImprimirTicketOld(long corteId)
        {

            if (m_sendToPrint)
                return;

            m_sendToPrint = true;

            this.corteTicketNTableAdapter.Fill(this.dSReimpresionTicket2.CorteTicketN, corteId);
            this.corteTrasladosTableAdapter.Fill(this.dSPuntoVenta.CorteTraslados, corteId);
            llenaCorteTotalesXLinea((int)corteId);

            if (this.dSReimpresionTicket2.CorteTicketN.Rows.Count == 0)
                return;

            decimal dVentasNetas = decimal.Parse(this.dSReimpresionTicket2.CorteTicketN.Rows[0]["INGRESO"].ToString()) - decimal.Parse(this.dSReimpresionTicket2.CorteTicketN.Rows[0]["DEVOLUCION"].ToString());

            Ticket ticket = new Ticket();


            ticket.AddHeaderLine("Numero De Corte : " + this.dSReimpresionTicket2.CorteTicketN.Rows[0]["FOLIO"].ToString());
            ticket.AddHeaderLine("Sucursal        : " + this.dSReimpresionTicket2.CorteTicketN.Rows[0]["SUCURSAL"].ToString());
            ticket.AddHeaderLine("Caja            : " + this.dSReimpresionTicket2.CorteTicketN.Rows[0]["CAJA"].ToString());
            ticket.AddHeaderLine("Turno           : " + this.dSReimpresionTicket2.CorteTicketN.Rows[0]["TURNO"].ToString());
            ticket.AddHeaderLine("Cajero          : " + this.dSReimpresionTicket2.CorteTicketN.Rows[0]["CAJERO"].ToString());
            ticket.AddHeaderLine("Fecha           : " + DateTime.Now.ToShortDateString());
            ticket.AddHeaderLine("Hora            : " + DateTime.Now.ToShortTimeString());
            //ticket.AddHeaderLine(new string('-', Ticket.maxChar));


            ticket.AddHeaderLine(new string('=', Ticket.maxChar));
            ticket.AddHeaderLine("DESGLOSE POR LINEA");
            ticket.AddHeaderLine(new string('=', Ticket.maxChar));
            ticket.AddHeaderLine("LINEA               ");
            ticket.AddHeaderLine(" DEVOLUCIONES   VENTAS    TOTAL");

            ticket.AddHeaderLine(new string('-', Ticket.maxChar));

            string line;
            decimal d_devoluciones = 0, d_ventas = 0, d_total = 0, d_egreso = 0;
            decimal d_devoluciones_sum = 0, d_ventas_sum = 0, d_total_sum = 0;
            foreach (DataRow dr in this.dSPuntoVenta.CORTEXLINEA.Rows)
            {
                d_devoluciones = 0;
                d_ventas = 0;
                d_total = 0;
                d_egreso = 0;

                if (dr["DEVOLUCIONES"] != null && dr["DEVOLUCIONES"] != DBNull.Value)
                    d_devoluciones = (decimal)dr["DEVOLUCIONES"];


                if (dr["VENTAS"] != null && dr["VENTAS"] != DBNull.Value)
                    d_ventas = (decimal)dr["VENTAS"];



                d_total = d_ventas - d_devoluciones ;


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
            ticket.AddHeaderLine("");
            ticket.AddHeaderLine(new string('=', Ticket.maxChar));
            ticket.AddHeaderLine("DESGLOSE POR TRASLADO");
            ticket.AddHeaderLine(new string('=', Ticket.maxChar));

            ticket.AddHeaderLine(" FOLIO     SUCURSAL               TOTAL");
            decimal dTrasladoItem = 0, dTrasladoTotal = 0;
            foreach (DataRow drTraslados in this.dSPuntoVenta.CorteTraslados.Rows)
            {

                dTrasladoItem = (decimal)drTraslados["TOTAL"];
                dTrasladoTotal += dTrasladoItem;
                line = "";
                line += Ticket.FormatPrintField(drTraslados["FOLIO"].ToString(), 10, 0) + " ";
                line += Ticket.FormatPrintField(drTraslados["SUCURSAL"].ToString(), 12, 0) + " ";
                line += Ticket.FormatPrintField(dTrasladoItem.ToString("N2"), 15, 0);
                ticket.AddHeaderLine(line);

            }
            /***Traslados**/


            ticket.AddHeaderLine(new string('-', Ticket.maxChar));


            ticket.AddHeaderLine("");
            ticket.AddHeaderLine(new string('=', Ticket.maxChar));
            ticket.AddHeaderLine("TOTALES");

            ticket.AddTotal("Ingresos Venta   : ", decimal.Parse(this.dSReimpresionTicket2.CorteTicketN.Rows[0]["INGRESO"].ToString()).ToString("N2"));
            ticket.AddTotal("Devoluciones     : ", decimal.Parse(this.dSReimpresionTicket2.CorteTicketN.Rows[0]["DEVOLUCION"].ToString()).ToString("N2"));
            ticket.AddTotal("Ventas Neta      : ", dVentasNetas.ToString("N2"));
            ticket.AddTotal(new string('-', Ticket.maxChar - 5), "");
            ticket.AddTotal("Saldo Inicial    : ", decimal.Parse(this.dSReimpresionTicket2.CorteTicketN.Rows[0]["SALDOINICIAL"].ToString()).ToString("N2"));
            //ticket.AddTotal("Efectivo         : ", decimal.Parse(this.dSReimpresionTicket2.CorteTicketN.Rows[0]["INGRESO"].ToString()).ToString("N2"));
            //ticket.AddTotal("Tarjeta          : ", "0.00");

            decimal corteEfectivo = decimal.Parse(this.dSReimpresionTicket2.CorteTicketN.Rows[0]["INGRESOEFECTIVO"].ToString());
            decimal corteEfectivoTraslados = decimal.Parse(this.dSReimpresionTicket2.CorteTicketN.Rows[0]["INGRESOEFECTIVOVENTATRASLADO"].ToString());
            decimal corteEfectivoSinTraslados = corteEfectivo - corteEfectivoTraslados;
            ticket.AddTotal("Efectivo         : ", corteEfectivoSinTraslados.ToString("N2"));
            ticket.AddTotal("Efectivo Trasl.  : ", corteEfectivoTraslados.ToString("N2"));
            ticket.AddTotal("Tarjeta          : ", decimal.Parse(this.dSReimpresionTicket2.CorteTicketN.Rows[0]["INGRESOTARJETA"].ToString()).ToString("N2"));
            ticket.AddTotal("Credito          : ", decimal.Parse(this.dSReimpresionTicket2.CorteTicketN.Rows[0]["INGRESOCREDITO"].ToString()).ToString("N2"));
            ticket.AddTotal("Cheque           : ", decimal.Parse(this.dSReimpresionTicket2.CorteTicketN.Rows[0]["INGRESOCHEQUE"].ToString()).ToString("N2"));
            ticket.AddTotal("Monedero         : ", decimal.Parse(this.dSReimpresionTicket2.CorteTicketN.Rows[0]["INGRESOMONEDERO"].ToString()).ToString("N2"));
            ticket.AddTotal("Transferencia    : ", decimal.Parse(this.dSReimpresionTicket2.CorteTicketN.Rows[0]["INGRESOTRANSFERENCIA"].ToString()).ToString("N2"));


            ticket.AddTotal("Aportacion       : ", decimal.Parse(this.dSReimpresionTicket2.CorteTicketN.Rows[0]["APORTACION"].ToString()).ToString("N2"));
            ticket.AddTotal("Retiro           : ", (decimal.Parse(this.dSReimpresionTicket2.CorteTicketN.Rows[0]["RETIRO"].ToString()) * -1).ToString("N2"));

            if (CurrentUserID.CurrentParameters.IHABFONDODINAMICO != null && CurrentUserID.CurrentParameters.IHABFONDODINAMICO.Equals("S"))
                ticket.AddTotal("Fondo dinamico   : ", (decimal.Parse(this.dSReimpresionTicket2.CorteTicketN.Rows[0]["FONDODINAMICODIFERENCIA"].ToString())).ToString("N2"));

            ticket.AddTotal("Egreso           : ", (decimal.Parse(this.dSReimpresionTicket2.CorteTicketN.Rows[0]["EGRESO"].ToString()) * -1).ToString("N2"));

            try
            {
                ticket.AddTotal("Saldo Final      : ", decimal.Parse(this.dSReimpresionTicket2.CorteTicketN.Rows[0]["SALDOFINAL"].ToString()).ToString("N2"));

                ticket.AddTotal("Saldo Real       : ", decimal.Parse(this.dSReimpresionTicket2.CorteTicketN.Rows[0]["SALDOREAL"].ToString()).ToString("N2"));
                ticket.AddTotal("Diferencia       : ", (decimal.Parse(this.dSReimpresionTicket2.CorteTicketN.Rows[0]["SALDOREAL"].ToString()) - decimal.Parse(this.dSReimpresionTicket2.CorteTicketN.Rows[0]["SALDOFINAL"].ToString())).ToString("N2"));
                ticket.AddTotal(new string('-', Ticket.maxChar - 5), "");
                ticket.AddTotal("No. Tickets          : ", this.dSReimpresionTicket2.CorteTicketN.Rows[0]["NUM_TICKETS"].ToString());
                ticket.AddTotal("No. Devoluciones     : ", this.dSReimpresionTicket2.CorteTicketN.Rows[0]["NUM_DEVOLUCIONES"].ToString());

                /***Traslados**/
                ticket.AddTotal(new string('-', Ticket.maxChar - 5), "");
                ticket.AddTotal("Total Traslados          : ", dTrasladoTotal.ToString("N2"));
                /***Traslados**/
            }
            catch
            {

            }


            /*Intercambio mercancia*/
            try
            {
                ticket.AddTotal("Intercambio mercancia    : ", this.dSReimpresionTicket2.CorteTicketN.Rows[0]["INTERCAMBIOMERCANCIA"].ToString());
            }
            catch
            {

            }

            ticket.AddFooterLine("");
            ticket.AddFooterLine("==Corte por linea==");

            if (m_printer != "")
                ticket.PrintTicketDirect(this.m_printer);

            m_bTicketImpreso = true;

            this.Close();


        }


        /*private void ObtenerTotalesCorteActual()
        {
            CCORTED corteD = new CCORTED();
            CCORTEBE corteBE = new CCORTEBE();
            corteBE.ISUCURSALID = CurrentUserID.CurrentParameters.ISUCURSALID;
            corteBE.ICAJAID = iPos.CurrentUserID.CurrentCompania.IEM_CAJA;
            corteBE.ICAJEROID = iPos.CurrentUserID.CurrentUser.IID;
            corteBE = corteD.ObtenTotalesCORTE(corteBE, null);
        }*/

        private void ImprimirTicketCorto(DateTime fecha)
        {
            try
            {


                if (m_sendToPrint)
                    return;

                m_sendToPrint = true;

                //ObtenerTotalesCorteActual();
                this.corteFechaTableAdapter.Fill(this.dataSet1.CorteFecha, fecha);


               
                CSUCURSALD sucursalD = new CSUCURSALD();
                CSUCURSALBE sucursalBE = new CSUCURSALBE();
                sucursalBE.IID = iPos.CurrentUserID.CurrentParameters.ISUCURSALID;
                sucursalBE = sucursalD.seleccionarSUCURSAL(sucursalBE, null);
                if (sucursalBE == null)
                {
                    return;
                }


                Ticket ticket = new Ticket();


                ticket.AddHeaderLine("Sucursal        : " + sucursalBE.INOMBRE);
                //ticket.AddHeaderLine("Direccion       : " + iPos.CurrentUserID.CurrentParameters.ICALLE );
                //ticket.AddHeaderLine("Colonia         : " + iPos.CurrentUserID.CurrentParameters.ICOLONIA);
                ticket.AddHeaderLine("Cajero          : " + iPos.CurrentUserID.CurrentUser.INOMBRE);
                ticket.AddHeaderLine("Fecha Impresion : " + DateTime.Now.ToShortDateString());
                ticket.AddHeaderLine("Hora Impresion  : " + DateTime.Now.ToShortTimeString());
                //ticket.AddHeaderLine(new string('-', Ticket.maxChar));

                ticket.AddHeaderLine(new string(' ', Ticket.maxChar));

                ticket.AddHeaderLine(new string('=', Ticket.maxChar));
                ticket.AddHeaderLine("FECHA CORTES    : " + fecha.ToShortDateString());


                ticket.AddHeaderLine(new string('=', Ticket.maxChar));
                ticket.AddHeaderLine("CAJERO                    ");

                ticket.AddHeaderLine(new string('-', Ticket.maxChar));



                string line;
                decimal d_total = 0, d_devoluciones = 0, d_ventas = 0, d_egreso = 0, d_cancelaciones = 0 ;
                decimal dVentasNetasDia = 0;
                string strCajero = "";
                long corteId = 0;




                foreach (DataRow dr in this.dataSet1.CorteFecha.Rows)
                {
                    d_devoluciones = 0;
                    d_cancelaciones = 0;
                    d_ventas = 0;
                    d_egreso = 0;
                    d_total = 0;
                    strCajero = "";

                        
                    if (dr["FOLIO"] != null && dr["FOLIO"] != DBNull.Value)
                        corteId= (long)dr["FOLIO"];

                    if (dr["DEVOLUCION"] != null && dr["DEVOLUCION"] != DBNull.Value)
                        d_devoluciones = (decimal)dr["DEVOLUCION"];


                    if (dr["CANCELACION"] != null && dr["CANCELACION"] != DBNull.Value)
                        d_cancelaciones = (decimal)dr["CANCELACION"];


                    if (dr["INGRESO"] != null && dr["INGRESO"] != DBNull.Value)
                        d_ventas = (decimal)dr["INGRESO"];

                    if (dr["EGRESO"] != null && dr["EGRESO"] != DBNull.Value)
                        d_egreso = (decimal)dr["EGRESO"];


                    if (dr["CAJERO"] != null && dr["CAJERO"] != DBNull.Value)
                        strCajero = dr["CAJERO"].ToString();

                    d_total = d_ventas - d_egreso;

                    dVentasNetasDia += d_total;

                    line = strCajero;
                    //line += Ticket.FormatPrintField(strCajero, 15, 0) + "  ";
                    ticket.AddHeaderLine(line);


                    decimal corteEfectivo = 0;
                    decimal corteEfectivoTraslados = 0;
                    decimal corteEfectivoSinTraslados = 0;

                    if (dr["INGRESOEFECTIVO"] != null && dr["INGRESOEFECTIVO"] != DBNull.Value)
                        corteEfectivo = decimal.Parse(dr["INGRESOEFECTIVO"].ToString());

                    if (dr["INGRESOEFECTIVOVENTATRASLADO"] != null && dr["INGRESOEFECTIVOVENTATRASLADO"] != DBNull.Value)
                        corteEfectivoTraslados = decimal.Parse(dr["INGRESOEFECTIVOVENTATRASLADO"].ToString());

                    corteEfectivoSinTraslados = corteEfectivo - corteEfectivoTraslados;

                    //if (dr["INGRESOEFECTIVO"] != null && dr["INGRESOEFECTIVO"] != DBNull.Value)
                    ticket.AddHeaderLine("    +Efectivo      : " + Ticket.FormatPrintField(corteEfectivoSinTraslados.ToString("N2"), 13, 0));
                    ticket.AddHeaderLine("    +Efectivo Trasl: " + Ticket.FormatPrintField(corteEfectivoTraslados.ToString("N2"), 13, 0));



                    if (dr["INGRESOTARJETA"] != null && dr["INGRESOTARJETA"] != DBNull.Value)
                        ticket.AddHeaderLine("    +Tarjeta       : " + Ticket.FormatPrintField(decimal.Parse(dr["INGRESOTARJETA"].ToString()).ToString("N2"),13,0));


                    if (dr["INGRESOCREDITO"] != null && dr["INGRESOCREDITO"] != DBNull.Value)
                        ticket.AddHeaderLine("    +Credito       : " + Ticket.FormatPrintField(decimal.Parse(dr["INGRESOCREDITO"].ToString()).ToString("N2"), 13, 0));

                    if (dr["INGRESOCHEQUE"] != null && dr["INGRESOCHEQUE"] != DBNull.Value)
                        ticket.AddHeaderLine("    +Cheque        : " + Ticket.FormatPrintField(decimal.Parse(dr["INGRESOCHEQUE"].ToString()).ToString("N2"), 13, 0));

                    if (dr["INGRESOVALE"] != null && dr["INGRESOVALE"] != DBNull.Value)
                        ticket.AddHeaderLine("    +Vale          : " + Ticket.FormatPrintField(decimal.Parse(dr["INGRESOVALE"].ToString()).ToString("N2"), 13, 0));


                    if (dr["INGRESOMONEDERO"] != null && dr["INGRESOMONEDERO"] != DBNull.Value)
                        ticket.AddHeaderLine("    +Monedero      : " + Ticket.FormatPrintField(decimal.Parse(dr["INGRESOMONEDERO"].ToString()).ToString("N2"), 13, 0));

                    if (dr["INGRESOTRANSFERENCIA"] != null && dr["INGRESOTRANSFERENCIA"] != DBNull.Value)
                        ticket.AddHeaderLine("    +Transferencia      : " + Ticket.FormatPrintField(decimal.Parse(dr["INGRESOTRANSFERENCIA"].ToString()).ToString("N2"), 13, 0));


                    if (dr["EGRESO"] != null && dr["EGRESO"] != DBNull.Value)
                        ticket.AddHeaderLine("    -Egreso        : " + Ticket.FormatPrintField(decimal.Parse(dr["EGRESO"].ToString()).ToString("N2"), 13, 0));


                    ticket.AddHeaderLine("    ------------------------------");
                    line = "    Total          : ";
                    line += Ticket.FormatPrintField(d_total.ToString("N2"), 13, 0) + "  ";
                    ticket.AddHeaderLine(line);

                    ticket.AddHeaderLine("");


                    if (dr["INTERCAMBIOMERCANCIA"] != null && dr["INTERCAMBIOMERCANCIA"] != DBNull.Value)
                        ticket.AddHeaderLine("Intercambio Mercancia  : " + Ticket.FormatPrintField(decimal.Parse(dr["INTERCAMBIOMERCANCIA"].ToString()).ToString("N2"), 13, 0));


                    /***IEPS**/
                    if (CurrentUserID.CurrentParameters.IDESGLOSEIEPS.Equals("S"))
                    {
                        this.cORTEIEPSTableAdapter.Fill(this.dataSet1.CORTEIEPS, corteId);
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine(new string('=', Ticket.maxChar));
                        ticket.AddHeaderLine("DESGLOSE POR IEPS");
                        ticket.AddHeaderLine(new string('=', Ticket.maxChar));

                        ticket.AddHeaderLine(" TASA                             TOTAL");
                        decimal dIepsPorcentaje = 0, dIepsMonto = 0;
                        foreach (DataRow drIeps in this.dataSet1.CORTEIEPS.Rows)
                        {

                            dIepsPorcentaje = (decimal)drIeps["TASAIEPS"];
                            dIepsMonto = (decimal)drIeps["MONTO"];
                            line = "";
                            line += Ticket.FormatPrintField(dIepsPorcentaje.ToString("N2"), 10, 0) + " ";
                            line += Ticket.FormatPrintField("", 12, 0) + " ";
                            line += Ticket.FormatPrintField(dIepsMonto.ToString("N2"), 15, 0);
                            ticket.AddHeaderLine(line);

                        }
                    }
                    /***IEPS**/

                    


                }

                ticket.AddHeaderLine(new string('-', Ticket.maxChar));

                line = "Total del dia      : ";               
                line += Ticket.FormatPrintField(dVentasNetasDia.ToString("N2"), 13, 0) + "  ";
                ticket.AddHeaderLine(line);




                //ticket.AddHeaderLine(new string('-', Ticket.maxChar));

                





                ticket.AddHeaderLine("");
                ticket.AddHeaderLine(new string('=', Ticket.maxChar));

                ticket.AddFooterLine("");
                ticket.AddFooterLine("==Corte corto==");

                if (m_printer != "")
                    ticket.PrintTicketDirect(this.m_printer);

                m_bTicketImpreso = true;


                this.Close();

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }


        }








        private void ImprimirTicketCortoSumarizado(DateTime fecha)
        {
            try
            {


                if (m_sendToPrint)
                    return;

                m_sendToPrint = true;

                this.corteTicketSumarizadoTableAdapter.Fill(this.dSReimpresionTicket.CorteTicketSumarizado, fecha);

                if (CurrentUserID.CurrentParameters.IDESGLOSEIEPS.Equals("S"))
                    this.cORTEIEPSFECHATableAdapter.Fill(this.dataSet1.CORTEIEPSFECHA, fecha);
            



                CSUCURSALD sucursalD = new CSUCURSALD();
                CSUCURSALBE sucursalBE = new CSUCURSALBE();
                sucursalBE.IID = iPos.CurrentUserID.CurrentParameters.ISUCURSALID;
                sucursalBE = sucursalD.seleccionarSUCURSAL(sucursalBE, null);
                if (sucursalBE == null)
                {
                    return;
                }


                Ticket ticket = new Ticket();




                ticket.AddHeaderLine("Sucursal        : " + sucursalBE.INOMBRE);
                ticket.AddHeaderLine("Cajero          : " + iPos.CurrentUserID.CurrentUser.INOMBRE);
                ticket.AddHeaderLine("Fecha Impresion : " + DateTime.Now.ToShortDateString());
                ticket.AddHeaderLine("Hora Impresion  : " + DateTime.Now.ToShortTimeString());

                ticket.AddHeaderLine(new string(' ', Ticket.maxChar));

                ticket.AddHeaderLine(new string('=', Ticket.maxChar));
                ticket.AddHeaderLine("FECHA CORTES    : " + fecha.ToShortDateString());


                ticket.AddHeaderLine(new string('=', Ticket.maxChar));


                string line;
                

                ticket.AddHeaderLine(new string('-', Ticket.maxChar));



                if (this.dSReimpresionTicket.CorteTicketSumarizado.Rows.Count == 0)
                    return;

                DataRow dr = this.dSReimpresionTicket.CorteTicketSumarizado[0];



                ticket.AddHeaderLine(new string('=', Ticket.maxChar));

                if (dr["NUMEROTICKETS"] != null && dr["NUMEROTICKETS"] != DBNull.Value)
                    ticket.AddHeaderLine("    #Tickets      : " + Ticket.FormatPrintField(decimal.Parse(dr["NUMEROTICKETS"].ToString()).ToString("N0"), 13, 0));

                if (dr["NUMERODEVOLUCIONES"] != null && dr["NUMERODEVOLUCIONES"] != DBNull.Value)
                    ticket.AddHeaderLine("    #Devoluciones : " + Ticket.FormatPrintField(decimal.Parse(dr["NUMERODEVOLUCIONES"].ToString()).ToString("N0"), 13, 0));


                ticket.AddHeaderLine(new string('=', Ticket.maxChar));



                decimal cortesubtotal = 0, corteIva = 0, montoconiva = 0, montosiniva = 0, montoiva,
                      montomenossiniva = 0, montoadicionalconiva = 0, corteIeps = 0, montoieps = 0,
                      montosubtotalfinalconiva = 0, montosubtotalfinalsiniva = 0
                      ;
                if (m_ajusteIntercambioIva > 0)
                {
                    try
                    {
                        montoconiva = decimal.Parse(dr["SUBTOTALCONIVA"].ToString());
                    }
                    catch
                    {
                        montoconiva = 0;
                    }

                    try
                    {
                        montosiniva = decimal.Parse(dr["SUBTOTALSINIVA"].ToString());
                    }
                    catch
                    {
                        montosiniva = 0;
                    }

                    try
                    {
                        montoiva = decimal.Parse(dr["MONTOIVA"].ToString());
                    }
                    catch
                    {
                        montoiva = 0;
                    }


                    try
                    {
                        montoieps = decimal.Parse(dr["MONTOIEPS"].ToString());
                    }
                    catch
                    {
                        montoieps = 0;
                    }


                    montomenossiniva = montosiniva * (m_ajusteIntercambioIva / 100);
                    montoadicionalconiva = montomenossiniva / (1 + (m_ajusteTasaIva / 100));
                    cortesubtotal = montoconiva + montosiniva - montomenossiniva + montoadicionalconiva;
                    corteIva = montoiva + (montomenossiniva - montoadicionalconiva);
                    corteIeps = montoieps;


                    montosubtotalfinalconiva = montoconiva + montoadicionalconiva;
                    montosubtotalfinalsiniva = montosiniva - montomenossiniva;
                }
                else
                {

                    try
                    {
                        montoieps = decimal.Parse(dr["MONTOIEPS"].ToString());
                    }
                    catch
                    {
                        montoieps = 0;
                    }


                    if (dr["SUBTOTAL"] != null && dr["SUBTOTAL"] != DBNull.Value)
                        cortesubtotal = decimal.Parse(dr["SUBTOTAL"].ToString());

                    if (dr["IVA"] != null && dr["IVA"] != DBNull.Value)
                        corteIva = decimal.Parse(dr["IVA"].ToString());


                    try
                    {
                        montoconiva = decimal.Parse(dr["SUBTOTALCONIVA"].ToString());
                    }
                    catch
                    {
                        montoconiva = 0;
                    }

                    try
                    {
                        montosiniva = decimal.Parse(dr["SUBTOTALSINIVA"].ToString());
                    }
                    catch
                    {
                        montosiniva = 0;
                    }

                    montosubtotalfinalconiva = montoconiva ;
                    montosubtotalfinalsiniva = montosiniva ;


                    corteIeps = montoieps; 
                }



                /*
                if (dr["SUBTOTAL"] != null && dr["SUBTOTAL"] != DBNull.Value)
                    ticket.AddHeaderLine("    Subtotal       : " + Ticket.FormatPrintField(decimal.Parse(cortesubtotal.ToString()).ToString("N2"), 13, 0));
                */
                if (dr["SUBTOTAL"] != null && dr["SUBTOTAL"] != DBNull.Value)
                {
                    ticket.AddHeaderLine("Subtotal con iva   : " + Ticket.FormatPrintField(decimal.Parse(montosubtotalfinalconiva.ToString()).ToString("N2"), 13, 0));
                    ticket.AddHeaderLine("Subtotal sin iva   : " + Ticket.FormatPrintField(decimal.Parse(montosubtotalfinalsiniva.ToString()).ToString("N2"), 13, 0));
                }

                if (dr["IVA"] != null && dr["IVA"] != DBNull.Value)
                    ticket.AddHeaderLine("    Iva            : " + Ticket.FormatPrintField(decimal.Parse(corteIva.ToString()).ToString("N2"), 13, 0));

                /*
                if (dr["MONTOIEPS"] != null && dr["MONTOIEPS"] != DBNull.Value)
                    ticket.AddHeaderLine("    Ieps            : " + Ticket.FormatPrintField(decimal.Parse(corteIeps.ToString()).ToString("N2"), 13, 0));
                */
                decimal dIepsPorcentaje = 0, dIepsMonto; 
                /***IEPS**/
                    foreach (DataRow drIeps in this.dataSet1.CORTEIEPSFECHA)
                    {

                        dIepsPorcentaje = (decimal)drIeps["TASAIEPS"];
                        dIepsMonto = (decimal)drIeps["MONTO"];
                        line = "  IEPS ";
                        line += Ticket.FormatPrintField(dIepsPorcentaje.ToString("N2"), 10, 0) + " ";
                        line += Ticket.FormatPrintField(":", 2, 0) + " ";
                        line += Ticket.FormatPrintField(dIepsMonto.ToString("N2"), 13, 0);
                        ticket.AddHeaderLine(line);

                    }
                /***IEPS**/



                if (dr["TOTAL"] != null && dr["TOTAL"] != DBNull.Value)
                    ticket.AddHeaderLine("    Total          : " + Ticket.FormatPrintField(decimal.Parse(dr["TOTAL"].ToString()).ToString("N2"), 13, 0));


                ticket.AddHeaderLine(new string('=', Ticket.maxChar));

                if (dr["INGRESOEFECTIVO"] != null && dr["INGRESOEFECTIVO"] != DBNull.Value)
                    ticket.AddHeaderLine("    +Efectivo      : " + Ticket.FormatPrintField(decimal.Parse(dr["INGRESOEFECTIVO"].ToString()).ToString("N2"), 13, 0));

                if (dr["INGRESOTARJETA"] != null && dr["INGRESOTARJETA"] != DBNull.Value)
                    ticket.AddHeaderLine("    +Tarjeta       : " + Ticket.FormatPrintField(decimal.Parse(dr["INGRESOTARJETA"].ToString()).ToString("N2"), 13, 0));


                if (dr["INGRESOCREDITO"] != null && dr["INGRESOCREDITO"] != DBNull.Value)
                    ticket.AddHeaderLine("    +Credito       : " + Ticket.FormatPrintField(decimal.Parse(dr["INGRESOCREDITO"].ToString()).ToString("N2"), 13, 0));

                if (dr["INGRESOCHEQUE"] != null && dr["INGRESOCHEQUE"] != DBNull.Value)
                    ticket.AddHeaderLine("    +Cheque        : " + Ticket.FormatPrintField(decimal.Parse(dr["INGRESOCHEQUE"].ToString()).ToString("N2"), 13, 0));

                if (dr["INGRESOVALE"] != null && dr["INGRESOVALE"] != DBNull.Value)
                    ticket.AddHeaderLine("    +Vale          : " + Ticket.FormatPrintField(decimal.Parse(dr["INGRESOVALE"].ToString()).ToString("N2"), 13, 0));


                /*if (dr["PAGOPROVEEDORES"] != null && dr["PAGOPROVEEDORES"] != DBNull.Value)
                    ticket.AddHeaderLine("    -Pago a Prov.  : " + Ticket.FormatPrintField(decimal.Parse(dr["PAGOPROVEEDORES"].ToString()).ToString("N2"), 13, 0));

                
                if (dr["RETIRO"] != null && dr["RETIRO"] != DBNull.Value)
                    ticket.AddHeaderLine("    -Retiro        : " + Ticket.FormatPrintField(decimal.Parse(dr["RETIRO"].ToString()).ToString("N2"), 13, 0));
                */
                if (dr["EGRESO"] != null && dr["EGRESO"] != DBNull.Value)
                    ticket.AddHeaderLine("    -Egreso        : " + Ticket.FormatPrintField(decimal.Parse(dr["EGRESO"].ToString()).ToString("N2"), 13, 0));
                


                if (dr["CAMBIOCHEQUE"] != null && dr["CAMBIOCHEQUE"] != DBNull.Value)
                    ticket.AddHeaderLine("    -Cambio Cheque : " + Ticket.FormatPrintField(decimal.Parse(dr["CAMBIOCHEQUE"].ToString()).ToString("N2"), 13, 0));





                /***IEPS**/
                if (CurrentUserID.CurrentParameters.IDESGLOSEIEPS.Equals("S"))
                {
                    ticket.AddFooterLine("");
                    ticket.AddFooterLine(new string('=', Ticket.maxChar));
                    ticket.AddFooterLine("DESGLOSE POR IEPS");
                    ticket.AddFooterLine(new string('=', Ticket.maxChar));

                    ticket.AddFooterLine(" TASA                             TOTAL");
                    foreach (DataRow drIeps in this.dataSet1.CORTEIEPSFECHA)
                    {

                        dIepsPorcentaje = (decimal)drIeps["TASAIEPS"];
                        dIepsMonto = (decimal)drIeps["MONTO"];
                        line = "";
                        line += Ticket.FormatPrintField(dIepsPorcentaje.ToString("N2"), 10, 0) + " ";
                        line += Ticket.FormatPrintField("", 12, 0) + " ";
                        line += Ticket.FormatPrintField(dIepsMonto.ToString("N2"), 15, 0);
                        ticket.AddFooterLine(line);

                    }
                }
                /***IEPS**/



                //ticket.AddHeaderLine(new string('-', Ticket.maxChar));


                ticket.AddHeaderLine("");
                ticket.AddHeaderLine(new string('=', Ticket.maxChar));

                ticket.AddFooterLine("");

                if (m_printer != "")
                    ticket.PrintTicketDirect(this.m_printer);

                m_bTicketImpreso = true;

                m_envioMailExitoso = false;
                m_currentFechaCorte = fecha;
                progressBar1.Style = ProgressBarStyle.Marquee;
                bgEnvioMail.RunWorkerAsync();


               // this.Close();

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }


        }






        public void ImprimirTicketSumarizadoXCajero(DateTime fecha)
        {

            int iNumCortes = 0;
            Ticket ticket = new Ticket();
            decimal dVentasNetas;

            this.corteTicketFechaTableAdapter.Fill(this.dataSet1.CorteTicketFecha, fecha);
            iNumCortes = this.dataSet1.CorteTicketFecha.Rows.Count;

            if (iNumCortes < 1)
            {
                MessageBox.Show("No hay cortes a mostrar");
                this.Close();
                return;
            }

            ticket.AddHeaderLine("Sucursal        : " + this.dataSet1.CorteTicketFecha.Rows[0]["SUCURSAL"].ToString());
            //ticket.AddHeaderLine("Caja            : " + this.dataSet1.CorteTicketFecha.Rows[0]["CAJA"].ToString());
            ticket.AddHeaderLine("Fecha           : " + DateTime.Now.ToShortDateString());
            ticket.AddHeaderLine("Hora            : " + DateTime.Now.ToShortTimeString());
            ticket.AddHeaderLine("Fecha de corte  : " + fecha.ToShortDateString());

            ticket.AddHeaderLine("");



            for (int iX = 0; iX < iNumCortes; iX++)
            {



                int corteId = int.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["FOLIO"].ToString());
                this.corteTrasladosTableAdapter.Fill(this.dSPuntoVenta.CorteTraslados, corteId);






                dVentasNetas = decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["INGRESO"].ToString()) - decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["DEVOLUCION"].ToString());
                ticket.AddFooterLine(new string('*', Ticket.maxChar));
                ticket.AddFooterLine(new string('-', Ticket.maxChar));
                ticket.AddFooterLine("Numero De Corte : " + this.dataSet1.CorteTicketFecha.Rows[iX]["FOLIO"].ToString());
                //ticket.AddFooterLine("Turno           : " + this.dataSet1.CorteTicketFecha.Rows[iX]["TURNO"].ToString());
                ticket.AddFooterLine("Cajero          : " + this.dataSet1.CorteTicketFecha.Rows[iX]["CAJERO"].ToString());
                ticket.AddFooterLine(new string('-', Ticket.maxChar));


                decimal cortesubtotal = 0, corteIva = 0, montoconiva = 0, montosiniva = 0, montoiva,
                       montomenossiniva = 0, montoadicionalconiva = 0, corteIeps = 0, montoieps = 0;
                if (m_ajusteIntercambioIva > 0)
                {
                    try
                    {
                        montoconiva = decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["SUBTOTALCONIVA"].ToString());
                    }
                    catch
                    {
                        montoconiva = 0;
                    }

                    try
                    {
                        montosiniva = decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["SUBTOTALSINIVA"].ToString());
                    }
                    catch
                    {
                        montosiniva = 0;
                    }

                    try
                    {
                        montoiva = decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["MONTOIVA"].ToString());
                    }
                    catch
                    {
                        montoiva = 0;
                    }


                    try
                    {
                        montoieps = decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["MONTOIEPS"].ToString());
                    }
                    catch
                    {
                        montoieps = 0;
                    }

                    montomenossiniva = montosiniva * (m_ajusteIntercambioIva / 100);
                    montoadicionalconiva = montomenossiniva / (1 + (m_ajusteTasaIva / 100));
                    cortesubtotal = montoconiva + montosiniva - montomenossiniva + montoadicionalconiva;
                    corteIva = montoiva + (montomenossiniva - montoadicionalconiva);
                    corteIeps = montoieps;
                }
                else
                {

                    try
                    {
                        montoieps = decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["MONTOIEPS"].ToString());
                    }
                    catch
                    {
                        montoieps = 0;
                    }

                    cortesubtotal = decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["INGRESOSUBTOTAL"].ToString());
                    corteIva = decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["INGRESOPORIVA"].ToString());
                    corteIeps = montoieps;
                }
                

                ticket.AddFooterLine(formatTotalLine("Ingresos Subtotal: ", cortesubtotal.ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Ingresos IVA     : ", corteIva.ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Monto IEPS       : ", corteIeps.ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Ingresos Venta   : ", decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["INGRESO"].ToString()).ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Devoluciones     : ", decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["DEVOLUCION"].ToString()).ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Ventas Neta      : ", dVentasNetas.ToString("N2")));
                ticket.AddFooterLine(formatTotalLine(new string('-', Ticket.maxChar - 5), ""));
                ticket.AddFooterLine(formatTotalLine("Saldo Inicial    : ", decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["SALDOINICIAL"].ToString()).ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Efectivo         : ", decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["INGRESOEFECTIVO"].ToString()).ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Tarjeta          : ", decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["INGRESOTARJETA"].ToString()).ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Credito          : ", decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["INGRESOCREDITO"].ToString()).ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Cheque           : ", decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["INGRESOCHEQUE"].ToString()).ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Cambio cheque    : ", (decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["CAMBIOCHEQUE"].ToString()) * -1).ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Vale             : ", decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["INGRESOVALE"].ToString()).ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Aportacion       : ", decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["APORTACION"].ToString()).ToString("N2")));


                try
                {
                    ticket.AddFooterLine(formatTotalLine("Retiro           : ", (decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["RETIRO"].ToString()) * -1).ToString("N2")));
                }
                catch
                {
                    ticket.AddFooterLine(formatTotalLine("Retiro           : ", "0.00"));
                }

                try
                {
                    ticket.AddFooterLine(formatTotalLine("Retiros de caja  : ", (decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["RETIROSDECAJA"].ToString()) * -1).ToString("N2")));
                }
                catch
                {
                    ticket.AddFooterLine(formatTotalLine("Retiros de caja  : ", "0.00"));
                }

                if (CurrentUserID.CurrentParameters.IHABFONDODINAMICO != null && CurrentUserID.CurrentParameters.IHABFONDODINAMICO.Equals("S"))
                {

                    try
                    {
                        ticket.AddFooterLine(formatTotalLine("Fondo dinamico   : ", (decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["FONDODINAMICODIFERENCIA"].ToString()) * -1).ToString("N2")));
                    }
                    catch
                    {
                        ticket.AddFooterLine(formatTotalLine("Fondo dinamico   : ", "0.00"));
                    }
                }

                try
                {
                ticket.AddFooterLine(formatTotalLine("Pago Prov.       : ", (decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["PAGOPROVEEDORES"].ToString()) * -1).ToString("N2")));
                }
                catch{
                    ticket.AddFooterLine(formatTotalLine("Pago Prov.       : ", "0.00"));
                }

                try
                {
                    ticket.AddFooterLine(formatTotalLine("Intercambio merc  : ", (decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["INTERCAMBIOMERCANCIA"].ToString()) * -1).ToString("N2")));
                }
                catch
                {
                    ticket.AddFooterLine(formatTotalLine("Intercambio merc  : ", "0.00"));
                }


                //ticket.AddFooterLine(formatTotalLine("Egreso           : ", (decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["EGRESO"].ToString()) * -1).ToString("N2")));


                ticket.AddFooterLine(formatTotalLine("Saldo Final      : ", decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["SALDOFINAL"].ToString()).ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Saldo Real       : ", decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["SALDOREAL"].ToString()).ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Diferencia       : ", (decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["SALDOREAL"].ToString()) - decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["SALDOFINAL"].ToString())).ToString("N2")));
                ticket.AddFooterLine(formatTotalLine(new string('-', Ticket.maxChar - 5), ""));
                ticket.AddFooterLine(formatTotalLine("No. Tickets          : ", this.dataSet1.CorteTicketFecha.Rows[iX]["NUM_TICKETS"].ToString()));
                ticket.AddFooterLine(formatTotalLine("No. Devoluciones     : ", this.dataSet1.CorteTicketFecha.Rows[iX]["NUM_DEVOLUCIONES"].ToString()));


                ticket.AddFooterLine(new string('*', Ticket.maxChar));



                /***IEPS**/
                string line = "";
                if (CurrentUserID.CurrentParameters.IDESGLOSEIEPS.Equals("S"))
                {
                    this.cORTEIEPSTableAdapter.Fill(this.dataSet1.CORTEIEPS, corteId);
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine(new string('=', Ticket.maxChar));
                    ticket.AddHeaderLine("DESGLOSE POR IEPS");
                    ticket.AddHeaderLine(new string('=', Ticket.maxChar));

                    ticket.AddHeaderLine(" TASA                             TOTAL");
                    decimal dIepsPorcentaje = 0, dIepsMonto = 0;
                    foreach (DataRow drIeps in this.dataSet1.CORTEIEPS.Rows)
                    {

                        dIepsPorcentaje = (decimal)drIeps["TASAIEPS"];
                        dIepsMonto = (decimal)drIeps["MONTO"];
                        line = "";
                        line += Ticket.FormatPrintField(dIepsPorcentaje.ToString("N2"), 10, 0) + " ";
                        line += Ticket.FormatPrintField("", 12, 0) + " ";
                        line += Ticket.FormatPrintField(dIepsMonto.ToString("N2"), 15, 0);
                        ticket.AddHeaderLine(line);

                    }
                }
                /***IEPS**/


                ticket.AddFooterLine("");
                ticket.AddFooterLine("");



            }


            ticket.AddFooterLine("");

            if (m_printer != "")
            {
                ticket.PrintTicketDirect(this.m_printer);
                m_bTicketImpreso = true;

                m_envioMailExitoso = false;
                m_currentFechaCorte = fecha;
                progressBar1.Style = ProgressBarStyle.Marquee;
                bgEnvioMail.RunWorkerAsync();

                //this.Close();
            }


        }




        public void ImprimirTicketSumarizadoXGrupoCajero(DateTime fecha)
        {

            int iNumCortes = 0;
            Ticket ticket = new Ticket();
            //decimal dVentasNetas;

            this.rEP_CORTESUM_GRUPOFECHATableAdapter.Fill(this.dSReimpresionTicket2.REP_CORTESUM_GRUPOFECHA, fecha);
            iNumCortes = this.dSReimpresionTicket2.REP_CORTESUM_GRUPOFECHA.Rows.Count;

            if (iNumCortes < 1)
            {
                MessageBox.Show("No hay cortes a mostrar");
                this.Close();
                return;
            }

            iPos.ReimpresionTicket.DSReimpresionTicket2.REP_CORTESUM_GRUPOFECHARow rowFirst = (iPos.ReimpresionTicket.DSReimpresionTicket2.REP_CORTESUM_GRUPOFECHARow)this.dSReimpresionTicket2.REP_CORTESUM_GRUPOFECHA.Rows[0];

            ticket.AddHeaderLine("Sucursal        : " + rowFirst.SUCURSAL.ToString());
            //ticket.AddHeaderLine("Caja            : " + this.dataSet1.CorteTicketFecha.Rows[0]["CAJA"].ToString());
            ticket.AddHeaderLine("Fecha           : " + DateTime.Now.ToShortDateString());
            ticket.AddHeaderLine("Hora            : " + DateTime.Now.ToShortTimeString());
            ticket.AddHeaderLine("Fecha de corte  : " + fecha.ToShortDateString());

            ticket.AddHeaderLine("");

            string strLastHeaderKey = "";
            

            for (int iX = 0; iX < iNumCortes; iX++)
            {

                iPos.ReimpresionTicket.DSReimpresionTicket2.REP_CORTESUM_GRUPOFECHARow row = (iPos.ReimpresionTicket.DSReimpresionTicket2.REP_CORTESUM_GRUPOFECHARow)this.dSReimpresionTicket2.REP_CORTESUM_GRUPOFECHA.Rows[iX];

                string strCurrentKey = row.FECHACORTE.ToString() + "---" + (row.IsGRUPOUSUARIOIDNull() ? "" : row.GRUPOUSUARIOID.ToString());

                if(strCurrentKey == strLastHeaderKey)
                {
                    continue;
                }

                strLastHeaderKey = strCurrentKey;
               // dVentasNetas = decimal.Parse(row.INGRESO.ToString()) - decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["DEVOLUCION"].ToString());
                ticket.AddFooterLine(new string('*', Ticket.maxChar));
                ticket.AddFooterLine(new string('-', Ticket.maxChar));
                ticket.AddFooterLine("Fecha De Corte : " + row.FECHACORTE);
                ticket.AddFooterLine("Grupo          : " + row.NOMBREGRUPOUSUARIO);
                ticket.AddFooterLine(new string('-', Ticket.maxChar));




                ticket.AddFooterLine(formatTotalLine("Subtotal(Venta-Dev-Canc): ", row.SUBTOTAL.ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("IVA(Venta-Dev-Canc): ", row.IVA.ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("IEPS(Venta-Dev-Canc): ", row.MONTOIEPS.ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Total(Venta-Dev-Canc): ", row.TOTAL.ToString("N2")));
                 //ticket.AddFooterLine(formatTotalLine("Ventas Neta      : ", dVentasNetas.ToString("N2")));
                ticket.AddFooterLine(formatTotalLine(new string('-', Ticket.maxChar - 5), ""));
                ticket.AddFooterLine(formatTotalLine("Efectivo         : ", row.INGRESO_EFECTIVO.ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Tarjeta          : ", row.INGRESO_TARJETA.ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Credito          : ", row.INGRESO_CREDITO.ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Cheque           : ", row.INGRESO_CHEQUE.ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Cambio cheque    : ", row.CAMBIO_CHEQUE.ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Vale             : ", row.INGRESO_VALE.ToString("N2")));

                ticket.AddFooterLine(formatTotalLine(new string(' ', Ticket.maxChar - 5), ""));
                ticket.AddFooterLine(formatTotalLine(new string('-', Ticket.maxChar - 5), ""));
                ticket.AddFooterLine(formatTotalLine("Ingreso          : ", row.INGRESO.ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Egreso           : ", row.EGRESO.ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Saldo            : ", row.SALDOFINAL.ToString("N2")));
                ticket.AddFooterLine(formatTotalLine(new string('-', Ticket.maxChar - 5), ""));
                ticket.AddFooterLine(formatTotalLine(new string(' ', Ticket.maxChar - 5), ""));


                ticket.AddFooterLine(formatTotalLine("Subtotal con iva: ", row.SUBTOTALCONIVA.ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Subtotal sin iva: ", row.SUBTOTALSINIVA.ToString("N2")));



                //ticket.AddFooterLine(formatTotalLine("Egreso           : ", (decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["EGRESO"].ToString()) * -1).ToString("N2")));


                ticket.AddFooterLine(formatTotalLine(new string('-', Ticket.maxChar - 5), ""));
                ticket.AddFooterLine(formatTotalLine("No. Tickets          : ", row.NUMERO_TICKETS.ToString()));
                ticket.AddFooterLine(formatTotalLine("No. Devoluciones     : ", row.NUMERO_DEVOLUCIONES.ToString()));




                /***IEPS**/
                string line = "";
                if (CurrentUserID.CurrentParameters.IDESGLOSEIEPS.Equals("S"))
                {


                    ticket.AddFooterLine("");
                    ticket.AddFooterLine(new string('=', Ticket.maxChar));
                    ticket.AddFooterLine("DESGLOSE POR IEPS");
                    ticket.AddFooterLine(new string('=', Ticket.maxChar));

                    ticket.AddFooterLine(" TASA                             TOTAL");
                    decimal dIepsPorcentaje = 0, dIepsMonto = 0;
                    for (int iXIEPS = 0; iXIEPS < iNumCortes; iXIEPS++)
                    {

                        iPos.ReimpresionTicket.DSReimpresionTicket2.REP_CORTESUM_GRUPOFECHARow rowIEPS = (iPos.ReimpresionTicket.DSReimpresionTicket2.REP_CORTESUM_GRUPOFECHARow)this.dSReimpresionTicket2.REP_CORTESUM_GRUPOFECHA.Rows[iXIEPS];

                        string strCurrentKeyIEPS = rowIEPS.FECHACORTE.ToString() + "---" + (rowIEPS.IsGRUPOUSUARIOIDNull() ? "" : rowIEPS.GRUPOUSUARIOID.ToString());

                        if(strCurrentKey != strCurrentKeyIEPS)
                        {
                            continue;
                        }


                        dIepsPorcentaje = rowIEPS.TASAIEPS_;
                        dIepsMonto = rowIEPS.MONTOIEPS_;
                        line = "";
                        line += Ticket.FormatPrintField(dIepsPorcentaje.ToString("N2"), 10, 0) + " ";
                        line += Ticket.FormatPrintField("", 12, 0) + " ";
                        line += Ticket.FormatPrintField(dIepsMonto.ToString("N2"), 15, 0);
                        ticket.AddFooterLine(line);

                    }
                }
                /***IEPS**/

                ticket.AddFooterLine(new string('*', Ticket.maxChar));


                ticket.AddFooterLine("");
                ticket.AddFooterLine("");



            }


            ticket.AddFooterLine("");


            

            if (m_printer != "")
            {
                ticket.PrintTicketDirect(this.m_printer);
                m_bTicketImpreso = true;

                /*m_envioMailExitoso = false;
                m_currentFechaCorte = fecha;
                progressBar1.Style = ProgressBarStyle.Marquee;
                bgEnvioMail.RunWorkerAsync();*/

                //this.Close();
            }


        }

        private void ImprimirRefenciaBancaria(long corteId, long formaPagoId, ref Ticket ticket)
        {

            this.bANCOREFERENCIATableAdapter.Fill(this.dSReimpresionTicket2.BANCOREFERENCIA, corteId, formaPagoId);
            if (this.dSReimpresionTicket2.BANCOREFERENCIA.Rows.Count > 0)
            {
                ticket.AddFooterLine(new string('.', Ticket.maxChar));

                foreach (BANCOREFERENCIARow dr in this.dSReimpresionTicket2.BANCOREFERENCIA.Rows)
                {
                    string referenciaPago = dr.IsREFERENCIABANCARIANull() ? "" : dr.REFERENCIABANCARIA;
                    string bancoNombrePago = dr.IsNOMBRENull() ? "" : dr.NOMBRE;
                    decimal importePago = dr.IsIMPORTENull() ? 0 : dr.IMPORTE;

                    if (bancoNombrePago.Trim().Length > 13)
                        bancoNombrePago = bancoNombrePago.Trim().Substring(0, 13);

                    if (referenciaPago.Trim().Length > 13)
                        referenciaPago = referenciaPago.Trim().Substring(0, 13);


                    ticket.AddFooterLine(" " + bancoNombrePago.Trim().PadRight(13) + referenciaPago.Trim().PadRight(13) + " " + importePago.ToString("N2").PadLeft(11));
                }

                ticket.AddFooterLine(new string('.', Ticket.maxChar));

            }
        }




        public void ImprimirTicketCorteApertura(long corteId)
        {

            Ticket ticket = new Ticket();
            ticket.OpenDrawer(ConexionesBD.ConexionBD.currentPrinter);//"IposPrinter3");
            

            string strTicketFrx = "TicketAbrirCorte.frx";

            FastReport.Report report = new FastReport.Report();
            string pathFrx = FastReportsConfig.getPathForFile(strTicketFrx, FastReportsTipoFile.desistema);
            report.Load(pathFrx);
            FastReport.Utils.Config.ReportSettings.ShowProgress = false;

            report.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report.SetParameterValue("US_ID", ConexionesBD.ConexionBD.CurrentUser.IID);
            report.SetParameterValue("US_NAME", ConexionesBD.ConexionBD.CurrentUser.IID);

            //report.PrintSettings.ShowDialog = false;

            report.SetParameterValue("pdoctoid", corteId);

            report.PrintSettings.Printer = ConexionesBD.ConexionBD.currentPrinter;
            
            report.PrintSettings.ShowDialog = false;
            report.Prepare();

            try
            {
                report.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cheque que la impresora este conectada " + ex.Message);
            }
            
            this.Close();
        }


        private void ImprimirTicketCorteBilletes(long corteId)
        {

            if (m_sendToPrint)
                return;

            m_sendToPrint = true;
            this.corteBilletesTableAdapter.Fill(this.dataSet1.CorteBilletes, corteId);
            decimal dVentasNetas = decimal.Parse(this.dataSet1.CorteBilletes.Rows[0]["INGRESO"].ToString()) - decimal.Parse(this.dataSet1.CorteBilletes.Rows[0]["DEVOLUCION"].ToString());

            Ticket ticket = new Ticket();


            ticket.AddHeaderLine("Numero De Corte : " + this.dataSet1.CorteBilletes.Rows[0]["FOLIO"].ToString());
            ticket.AddHeaderLine("Sucursal        : " + this.dataSet1.CorteBilletes.Rows[0]["SUCURSAL"].ToString());
            ticket.AddHeaderLine("Caja            : " + this.dataSet1.CorteBilletes.Rows[0]["CAJA"].ToString());
            ticket.AddHeaderLine("Cajero          : " + this.dataSet1.CorteBilletes.Rows[0]["CAJERO"].ToString());
            ticket.AddHeaderLine("Fecha           : " + DateTime.Now.ToShortDateString());
            ticket.AddHeaderLine("Hora            : " + DateTime.Now.ToShortTimeString());


            ticket.AddHeaderLine(new string('-', Ticket.maxChar));


            ticket.AddHeaderLine("");
            ticket.AddHeaderLine(new string('=', Ticket.maxChar));
            ticket.AddHeaderLine("MONTO EN CAJA DESGLOSADO");

            decimal tipoDeCambio = decimal.Parse(this.dataSet1.CorteBilletes.Rows[0]["TIPODECAMBIO"].ToString());
            ticket.AddFooterLine(formatTotalLine("Tipo de cambio:", tipoDeCambio.ToString("N2")));
            ticket.AddFooterLine("");
            ticket.AddFooterLine(new string('-', Ticket.maxChar));

            decimal bill1000pesos = decimal.Parse(this.dataSet1.CorteBilletes.Rows[0]["P1000"].ToString());
            decimal bill500pesos = decimal.Parse(this.dataSet1.CorteBilletes.Rows[0]["P500"].ToString());
            decimal bill200pesos = decimal.Parse(this.dataSet1.CorteBilletes.Rows[0]["P200"].ToString());
            decimal bill100pesos = decimal.Parse(this.dataSet1.CorteBilletes.Rows[0]["P100"].ToString());
            decimal bill50pesos = decimal.Parse(this.dataSet1.CorteBilletes.Rows[0]["P50"].ToString());
            decimal bill20pesos = decimal.Parse(this.dataSet1.CorteBilletes.Rows[0]["P20"].ToString());

            decimal morrallapesos = decimal.Parse(this.dataSet1.CorteBilletes.Rows[0]["MORRALLAPESOS"].ToString());


            decimal bill100dolares = decimal.Parse(this.dataSet1.CorteBilletes.Rows[0]["D100"].ToString());
            decimal bill50dolares = decimal.Parse(this.dataSet1.CorteBilletes.Rows[0]["D50"].ToString());
            decimal bill20dolares = decimal.Parse(this.dataSet1.CorteBilletes.Rows[0]["D20"].ToString());
            decimal bill10dolares = decimal.Parse(this.dataSet1.CorteBilletes.Rows[0]["D10"].ToString());
            decimal bill5dolares = decimal.Parse(this.dataSet1.CorteBilletes.Rows[0]["D5"].ToString());
            decimal bill2dolares = decimal.Parse(this.dataSet1.CorteBilletes.Rows[0]["D2"].ToString());
            decimal bill1dolares = decimal.Parse(this.dataSet1.CorteBilletes.Rows[0]["D1"].ToString());

            decimal morralladolares = decimal.Parse(this.dataSet1.CorteBilletes.Rows[0]["MORRALLADOLARES"].ToString());
            decimal morralladolaresenpesos = decimal.Parse(this.dataSet1.CorteBilletes.Rows[0]["MORRALLADEDOLARENPESOS"].ToString());


            if(bill1000pesos > 0)
                ticket.AddFooterLine(formatTwoTotalLine("1000 Pesos    :", bill1000pesos.ToString("N0"), (bill1000pesos * 1000).ToString("N2")));
            if(bill500pesos > 0)
                ticket.AddFooterLine(formatTwoTotalLine(" 500 Pesos    :", bill500pesos.ToString("N0"), (bill500pesos * 500).ToString("N2")));
            if(bill200pesos > 0)
                ticket.AddFooterLine(formatTwoTotalLine(" 200 Pesos    :", bill200pesos.ToString("N0"), (bill200pesos * 200).ToString("N2")));
            if(bill100pesos > 0)
                ticket.AddFooterLine(formatTwoTotalLine(" 100 Pesos    :", bill100pesos.ToString("N0"), (bill100pesos * 100).ToString("N2")));
            if(bill50pesos > 0)
                ticket.AddFooterLine(formatTwoTotalLine("  50 Pesos    :", bill50pesos.ToString("N0"), (bill50pesos * 50).ToString("N2")));
            if(bill20pesos > 0)
                ticket.AddFooterLine(formatTwoTotalLine("  20 Pesos    :", bill20pesos.ToString("N0"), (bill20pesos * 20).ToString("N2")));
            
            if(morrallapesos > 0)
                ticket.AddFooterLine(formatTwoTotalLine("Morralla pesos:", "", morrallapesos.ToString("N2")));

            ticket.AddFooterLine(new string('-', Ticket.maxChar));

            if(bill100dolares > 0)
                ticket.AddFooterLine(formatTwoTotalLine("100 Dolares   :", bill100dolares.ToString("N0"), (bill100dolares * tipoDeCambio * 100).ToString("N2")));
            if (bill50dolares > 0)
                ticket.AddFooterLine(formatTwoTotalLine(" 50 Dolares   :", bill50dolares.ToString("N0"), (bill50dolares * tipoDeCambio * 50).ToString("N2")));
            if (bill20dolares > 0)
                ticket.AddFooterLine(formatTwoTotalLine(" 20 Dolares   :", bill20dolares.ToString("N0"), (bill20dolares * tipoDeCambio * 20).ToString("N2")));
            if (bill10dolares > 0)
                ticket.AddFooterLine(formatTwoTotalLine(" 10 Dolares   :", bill10dolares.ToString("N0"), (bill10dolares * tipoDeCambio * 10).ToString("N2")));
            if (bill5dolares > 0)
                ticket.AddFooterLine(formatTwoTotalLine("  5 Dolares   :", bill5dolares.ToString("N0"), (bill5dolares * tipoDeCambio * 5).ToString("N2")));
            if (bill2dolares > 0)
                ticket.AddFooterLine(formatTwoTotalLine("  2 Dolares   :", bill2dolares.ToString("N0"), (bill2dolares * tipoDeCambio * 2).ToString("N2")));
            if (bill1dolares > 0)
                ticket.AddFooterLine(formatTwoTotalLine("  1 Dolares   :", bill1dolares.ToString("N0"), (bill1dolares * tipoDeCambio * 1).ToString("N2")));

            if (morralladolares > 0)
                ticket.AddFooterLine(formatTwoTotalLine("Morralla dolar:", morralladolares.ToString("N2"), morralladolaresenpesos.ToString("N2")));


            decimal totalesMonedaBilletes = (bill1000pesos * 1000) +
                                            (bill500pesos * 500) +
                                            (bill200pesos * 200) +
                                            (bill100pesos * 100) +
                                            (bill50pesos * 50) +
                                            (bill20pesos * 20) +
                                            morrallapesos +
                                            (bill100dolares * tipoDeCambio * 100) +
                                            (bill50dolares * tipoDeCambio * 50) +
                                            (bill20dolares * tipoDeCambio * 20) +
                                            (bill10dolares * tipoDeCambio * 10) +
                                            (bill5dolares * tipoDeCambio * 5) +
                                            (bill2dolares * tipoDeCambio * 2) +
                                            (bill1dolares * tipoDeCambio * 1);


            ticket.AddFooterLine(new string('-', Ticket.maxChar));
            ticket.AddFooterLine(formatTwoTotalLine("TOTAL EFECTIVO:", "", totalesMonedaBilletes.ToString("N2")));
            ticket.AddFooterLine(new string(' ', Ticket.maxChar));

            ticket.AddFooterLine(new string('-', Ticket.maxChar));

            try
            {
                ticket.AddFooterLine(formatTwoTotalLine("Cheques       :", "", decimal.Parse(this.dataSet1.CorteBilletes.Rows[0]["CHEQUES"].ToString()).ToString("N2")));
                if (CurrentUserID.CurrentParameters.IIMPRIMIRBANCOSCORTE != null && CurrentUserID.CurrentParameters.IIMPRIMIRBANCOSCORTE.Equals("S"))
                {
                    ImprimirRefenciaBancaria(corteId, 3, ref ticket);
                }
            }
            catch{}

            ticket.AddFooterLine(formatTwoTotalLine("Vales         :", "", decimal.Parse(this.dataSet1.CorteBilletes.Rows[0]["VALES"].ToString()).ToString("N2")));
            ticket.AddFooterLine(formatTwoTotalLine("Tarjeta       :", "", decimal.Parse(this.dataSet1.CorteBilletes.Rows[0]["TARJETA"].ToString()).ToString("N2")));
            ticket.AddFooterLine(formatTwoTotalLine("Credito       :", "", decimal.Parse(this.dataSet1.CorteBilletes.Rows[0]["CREDITO"].ToString()).ToString("N2")));
            try
            {
                ticket.AddFooterLine(formatTwoTotalLine("Monedero       :", "", decimal.Parse(this.dataSet1.CorteBilletes.Rows[0]["MONEDERO"].ToString()).ToString("N2")));
            }
            catch
            {
            }
            try
            {
                ticket.AddFooterLine(formatTwoTotalLine("Transferencia:", "", decimal.Parse(this.dataSet1.CorteBilletes.Rows[0]["TRANSFERENCIA"].ToString()).ToString("N2"))); if (1 == 1)
                if (CurrentUserID.CurrentParameters.IIMPRIMIRBANCOSCORTE != null && CurrentUserID.CurrentParameters.IIMPRIMIRBANCOSCORTE.Equals("S"))
                {
                        ImprimirRefenciaBancaria(corteId, 15, ref ticket);
                }
            }
            catch
            {
            }

            try
            {
                ticket.AddFooterLine(formatTwoTotalLine("Interc. Merc.:", "", decimal.Parse(this.dataSet1.CorteBilletes.Rows[0]["INTERCAMBIOMERCANCIA"].ToString()).ToString("N2")));
            }
            catch
            {
            }


            decimal dCorteEfectivoTrasladosIngreso = 0;
            try { dCorteEfectivoTrasladosIngreso = decimal.Parse(this.dataSet1.CorteBilletes.Rows[0]["INGRESOEFECTIVOVENTATRASLADO"].ToString()); }
            catch { }

            decimal dCorteEfectivoTrasladosEgreso = 0;
            try { dCorteEfectivoTrasladosEgreso = decimal.Parse(this.dataSet1.CorteBilletes.Rows[0]["EGRESOEFEVENTATRASLADO"].ToString()); }
            catch { }

            decimal dCorteEfectivoTraslados = dCorteEfectivoTrasladosIngreso - dCorteEfectivoTrasladosEgreso;

            try
            {
                ticket.AddFooterLine(formatTwoTotalLine("Efect. Traslados:", "", dCorteEfectivoTraslados.ToString("N2")));
            }
            catch
            {
            }

            if (CurrentUserID.CurrentParameters.IHABFONDODINAMICO != null && CurrentUserID.CurrentParameters.IHABFONDODINAMICO.Equals("S"))
            {
                try
                {
                    ticket.AddFooterLine(formatTwoTotalLine("Fondo dinamico  :", "", decimal.Parse(this.dataSet1.CorteBilletes.Rows[0]["FONDODINAMICODIFERENCIA"].ToString()).ToString("N2")));
                }
                catch
                {
                }
            }


            ticket.AddFooterLine(new string('=', Ticket.maxChar));
            ticket.AddFooterLine(formatTwoTotalLine("Monto         :", "", decimal.Parse(this.dataSet1.CorteBilletes.Rows[0]["MB_SALDOFINAL"].ToString()).ToString("N2")));

            if (m_aditionalFooter != null && m_aditionalFooter.Length > 0)
            {
                ticket.AddFooterLine(m_aditionalFooter);

            }



            ticket.AddFooterLine("");
            ticket.AddFooterLine("");
            ticket.AddFooterLine("");
            ticket.AddFooterLine("          ____________________");
            ticket.AddFooterLine("                 Recibió");


            ticket.AddFooterLine("");
            ticket.AddFooterLine("");
            ticket.AddFooterLine("");
            ticket.AddFooterLine("          ____________________");
            ticket.AddFooterLine("                 Entregó");
            

            ticket.AddFooterLine("");
            ticket.AddFooterLine("==Corte billetes==");

            if (m_printer != "")
                ticket.PrintTicketDirect(this.m_printer);



            m_bTicketImpreso = true;


            // impresion de informacion de deposito si es que aplica
            ticket = new Ticket();
            CSUCURSALD sucD = new CSUCURSALD();
            CSUCURSALBE sucBE = new CSUCURSALBE();
            sucBE.IID = CurrentUserID.CurrentParameters.ISUCURSALID;

            sucBE = sucD.seleccionarSUCURSAL(sucBE, null);

            if (sucBE != null && sucBE.ICUENTAREFERENCIA != null && sucBE.ICUENTAREFERENCIA.Trim().Length > 0)
            {

                ticket.AddFooterLine("");
                ticket.AddFooterLine("*** Información deposito ***");
                ticket.AddFooterLine("");
                ticket.AddFooterLine("Empresa     : " + CurrentUserID.CurrentParameters.INOMBRE);
                ticket.AddFooterLine("Sucursal    : " + this.dataSet1.CorteBilletes.Rows[0]["SUCURSAL"].ToString());
                ticket.AddFooterLine("Cajero      : " + this.dataSet1.CorteBilletes.Rows[0]["CAJERO"].ToString());
                ticket.AddFooterLine("Fecha       : " + DateTime.Now.ToShortDateString());
                ticket.AddFooterLine("Hora        : " + DateTime.Now.ToShortTimeString());
                try
                {

                    ticket.AddFooterLine("Fecha Corte :" + this.dataSet1.CorteBilletes.Rows[0]["FECHACORTE"].ToString());
                }
                catch(Exception ex)
                {

                }
                ticket.AddFooterLine("Banco       :" + (sucBE.IBANCOCLAVE != null ? sucBE.IBANCOCLAVE : ""));
                ticket.AddFooterLine("Cuenta      :" + (sucBE.ICUENTAREFERENCIA != null ? sucBE.ICUENTAREFERENCIA : ""));


                ticket.AddFooterLine("");
                ticket.AddFooterLine(new string('-', Ticket.maxChar));
                ticket.AddFooterLine("");
                if (bill1000pesos > 0)
                    ticket.AddFooterLine(formatTwoTotalLine("1000 Pesos       :", bill1000pesos.ToString("N0"), (bill1000pesos * 1000).ToString("N2")));
                if (bill500pesos > 0)
                    ticket.AddFooterLine(formatTwoTotalLine(" 500 Pesos       :", bill500pesos.ToString("N0"), (bill500pesos * 500).ToString("N2")));
                if (bill200pesos > 0)
                    ticket.AddFooterLine(formatTwoTotalLine(" 200 Pesos       :", bill200pesos.ToString("N0"), (bill200pesos * 200).ToString("N2")));
                if (bill100pesos > 0)
                    ticket.AddFooterLine(formatTwoTotalLine(" 100 Pesos       :", bill100pesos.ToString("N0"), (bill100pesos * 100).ToString("N2")));
                if (bill50pesos > 0)
                    ticket.AddFooterLine(formatTwoTotalLine("  50 Pesos       :", bill50pesos.ToString("N0"), (bill50pesos * 50).ToString("N2")));
                if (bill20pesos > 0)
                    ticket.AddFooterLine(formatTwoTotalLine("  20 Pesos       :", bill20pesos.ToString("N0"), (bill20pesos * 20).ToString("N2")));
                if (morrallapesos > 0)
                    ticket.AddFooterLine(formatTwoTotalLine("Morralla pesos   :", "", morrallapesos.ToString("N2")));


                decimal sumaDepositar = (bill1000pesos * 1000) + (bill500pesos * 500) + (bill200pesos * 200) + (bill100pesos * 100) + (bill50pesos * 50) + (bill20pesos * 20) + morrallapesos;

                ticket.AddFooterLine("");
                ticket.AddFooterLine(new string('-', Ticket.maxChar));
                ticket.AddFooterLine(formatTwoTotalLine("TOTAL DEPOSITAR:", "", sumaDepositar.ToString("N2")));
                ticket.AddFooterLine(new string('-', Ticket.maxChar));

                ticket.AddFooterLine("");
                ticket.AddFooterLine("==Corte billetes deposito==");



                if (m_printer != "")
                    ticket.PrintTicketDirect(this.m_printer);
            }





            this.Close();


        }




        private void ImprimirTicketCorteBilletesPorRetiro(long doctoId)
        {

            if (m_sendToPrint)
                return;

            m_sendToPrint = true;
            this.mONTOBILLETESRETIROCAJATableAdapter.Fill(this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA, doctoId);
            decimal dVentasNetas = decimal.Parse(this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["INGRESO"].ToString()) - decimal.Parse(this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["DEVOLUCION"].ToString());

            Ticket ticket = new Ticket();


            ticket.AddHeaderLine("Numero De Retiro: " + this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["FOLIO"].ToString());
            ticket.AddHeaderLine("Sucursal        : " + this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["SUCURSAL"].ToString());
            ticket.AddHeaderLine("Caja            : " + this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["CAJA"].ToString());
            ticket.AddHeaderLine("Cajero          : " + this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["CAJERO"].ToString());
            ticket.AddHeaderLine("Fecha           : " + DateTime.Now.ToShortDateString());
            ticket.AddHeaderLine("Hora            : " + DateTime.Now.ToShortTimeString());


            ticket.AddHeaderLine(new string('-', Ticket.maxChar));


            ticket.AddHeaderLine("");
            ticket.AddHeaderLine(new string('=', Ticket.maxChar));
            ticket.AddHeaderLine("MONTO EN CAJA DESGLOSADO");

            decimal tipoDeCambio = decimal.Parse(this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["TIPODECAMBIO"].ToString());
            ticket.AddFooterLine(formatTotalLine("Tipo de cambio:", tipoDeCambio.ToString("N2")));
            ticket.AddFooterLine("");
            ticket.AddFooterLine(new string('-', Ticket.maxChar));

            decimal bill1000pesos = decimal.Parse(this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["P1000"].ToString());
            decimal bill500pesos = decimal.Parse(this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["P500"].ToString());
            decimal bill200pesos = decimal.Parse(this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["P200"].ToString());
            decimal bill100pesos = decimal.Parse(this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["P100"].ToString());
            decimal bill50pesos = decimal.Parse(this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["P50"].ToString());
            decimal bill20pesos = decimal.Parse(this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["P20"].ToString());

            decimal morrallapesos = decimal.Parse(this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["MORRALLAPESOS"].ToString());


            decimal bill100dolares = decimal.Parse(this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["D100"].ToString());
            decimal bill50dolares = decimal.Parse(this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["D50"].ToString());
            decimal bill20dolares = decimal.Parse(this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["D20"].ToString());
            decimal bill10dolares = decimal.Parse(this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["D10"].ToString());
            decimal bill5dolares = decimal.Parse(this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["D5"].ToString());
            decimal bill2dolares = decimal.Parse(this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["D2"].ToString());
            decimal bill1dolares = decimal.Parse(this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["D1"].ToString());

            decimal morralladolares = decimal.Parse(this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["MORRALLADOLARES"].ToString());
            decimal morralladolaresenpesos = decimal.Parse(this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["MORRALLADEDOLARENPESOS"].ToString());


            if (bill1000pesos > 0)
                ticket.AddFooterLine(formatTwoTotalLine("1000 Pesos    :", bill1000pesos.ToString("N0"), (bill1000pesos * 1000).ToString("N2")));
            if (bill500pesos > 0)
                ticket.AddFooterLine(formatTwoTotalLine(" 500 Pesos    :", bill500pesos.ToString("N0"), (bill500pesos * 500).ToString("N2")));
            if (bill200pesos > 0)
                ticket.AddFooterLine(formatTwoTotalLine(" 200 Pesos    :", bill200pesos.ToString("N0"), (bill200pesos * 200).ToString("N2")));
            if (bill100pesos > 0)
                ticket.AddFooterLine(formatTwoTotalLine(" 100 Pesos    :", bill100pesos.ToString("N0"), (bill100pesos * 100).ToString("N2")));
            if (bill50pesos > 0)
                ticket.AddFooterLine(formatTwoTotalLine("  50 Pesos    :", bill50pesos.ToString("N0"), (bill50pesos * 50).ToString("N2")));
            if (bill20pesos > 0)
                ticket.AddFooterLine(formatTwoTotalLine("  20 Pesos    :", bill20pesos.ToString("N0"), (bill20pesos * 20).ToString("N2")));

            if (morrallapesos > 0)
                ticket.AddFooterLine(formatTwoTotalLine("Morralla pesos:", "", morrallapesos.ToString("N2")));

            ticket.AddFooterLine(new string('-', Ticket.maxChar));

            if (bill100dolares > 0)
                ticket.AddFooterLine(formatTwoTotalLine("100 Dolares   :", bill100dolares.ToString("N0"), (bill100dolares * tipoDeCambio * 100).ToString("N2")));
            if (bill50dolares > 0)
                ticket.AddFooterLine(formatTwoTotalLine(" 50 Dolares   :", bill50dolares.ToString("N0"), (bill50dolares * tipoDeCambio * 50).ToString("N2")));
            if (bill20dolares > 0)
                ticket.AddFooterLine(formatTwoTotalLine(" 20 Dolares   :", bill20dolares.ToString("N0"), (bill20dolares * tipoDeCambio * 20).ToString("N2")));
            if (bill10dolares > 0)
                ticket.AddFooterLine(formatTwoTotalLine(" 10 Dolares   :", bill10dolares.ToString("N0"), (bill10dolares * tipoDeCambio * 10).ToString("N2")));
            if (bill5dolares > 0)
                ticket.AddFooterLine(formatTwoTotalLine("  5 Dolares   :", bill5dolares.ToString("N0"), (bill5dolares * tipoDeCambio * 5).ToString("N2")));
            if (bill2dolares > 0)
                ticket.AddFooterLine(formatTwoTotalLine("  2 Dolares   :", bill2dolares.ToString("N0"), (bill2dolares * tipoDeCambio * 2).ToString("N2")));
            if (bill1dolares > 0)
                ticket.AddFooterLine(formatTwoTotalLine("  1 Dolares   :", bill1dolares.ToString("N0"), (bill1dolares * tipoDeCambio * 1).ToString("N2")));

            if (morralladolares > 0)
                ticket.AddFooterLine(formatTwoTotalLine("Morralla dolar:", morralladolares.ToString("N2"), morralladolaresenpesos.ToString("N2")));

            decimal totalesMonedaBilletes = (bill1000pesos * 1000) +
                                            (bill500pesos * 500) +
                                            (bill200pesos * 200) +
                                            (bill100pesos * 100) +
                                            (bill50pesos * 50) +
                                            (bill20pesos * 20) +
                                            morrallapesos +
                                            (bill100dolares * tipoDeCambio * 100) +
                                            (bill50dolares * tipoDeCambio * 50) +
                                            (bill20dolares * tipoDeCambio * 20) +
                                            (bill10dolares * tipoDeCambio * 10) +
                                            (bill5dolares * tipoDeCambio * 5) +
                                            (bill2dolares * tipoDeCambio * 2) +
                                            (bill1dolares * tipoDeCambio * 1);


            ticket.AddFooterLine(new string('-', Ticket.maxChar));
            ticket.AddFooterLine(formatTwoTotalLine("TOTAL EFECTIVO:", "", totalesMonedaBilletes.ToString("N2")));
            ticket.AddFooterLine(new string(' ', Ticket.maxChar));



            ticket.AddFooterLine(new string('-', Ticket.maxChar));
            ticket.AddFooterLine(formatTwoTotalLine("Cheques       :", "", decimal.Parse(this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["CHEQUES"].ToString()).ToString("N2")));
            ticket.AddFooterLine(formatTwoTotalLine("Vales         :", "", decimal.Parse(this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["VALES"].ToString()).ToString("N2")));
            ticket.AddFooterLine(formatTwoTotalLine("Tarjeta       :", "", decimal.Parse(this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["TARJETA"].ToString()).ToString("N2")));
            ticket.AddFooterLine(formatTwoTotalLine("Credito       :", "", decimal.Parse(this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["CREDITO"].ToString()).ToString("N2")));
            try
            {
                ticket.AddFooterLine(formatTwoTotalLine("Monedero       :", "", decimal.Parse(this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["MONEDERO"].ToString()).ToString("N2")));
            }
            catch
            {
            }

            try
            {
                ticket.AddFooterLine(formatTwoTotalLine("Transferencia  :", "", decimal.Parse(this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["TRANSFERENCIA"].ToString()).ToString("N2")));
            }
            catch
            {
            }


            ticket.AddFooterLine(new string('=', Ticket.maxChar));
            ticket.AddFooterLine(formatTwoTotalLine("Monto         :", "", decimal.Parse(this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["MB_SALDOFINAL"].ToString()).ToString("N2")));

            if (this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["REFERENCIAS"] != null &&
                 this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["REFERENCIAS"] != DBNull.Value &&
                 this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["REFERENCIAS"].ToString().Trim().Length > 0)
            {
                ticket.AddFooterLine(new string('-', Ticket.maxChar));
                ticket.AddFooterLine("Observaciones");
                ticket.AddFooterLine(this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["REFERENCIAS"].ToString());
                ticket.AddFooterLine(new string(' ', Ticket.maxChar));
            }

            ticket.AddFooterLine("");
            ticket.AddFooterLine("==Corte billetes por retiro==");

            if (m_printer != "")
                ticket.PrintTicketDirect(this.m_printer);

            m_bTicketImpreso = true;




            // impresion de informacion de deposito si es que aplica
            ticket = new Ticket();
            CSUCURSALD sucD = new CSUCURSALD();
            CSUCURSALBE sucBE = new CSUCURSALBE();
            sucBE.IID = CurrentUserID.CurrentParameters.ISUCURSALID;

            sucBE = sucD.seleccionarSUCURSAL(sucBE, null);

            if (sucBE != null && sucBE.ICUENTAREFERENCIA != null && sucBE.ICUENTAREFERENCIA.Trim().Length > 0)
            {

                ticket.AddFooterLine("");
                ticket.AddFooterLine("*** Información deposito por retiro de caja ***");
                ticket.AddFooterLine("");
                ticket.AddFooterLine("Numero De Retiro: " + this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["FOLIO"].ToString());
                ticket.AddFooterLine("Sucursal        : " + this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["SUCURSAL"].ToString());
                ticket.AddFooterLine("Caja            : " + this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["CAJA"].ToString());
                ticket.AddFooterLine("Cajero          : " + this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["CAJERO"].ToString());
                ticket.AddFooterLine("Fecha           : " + DateTime.Now.ToShortDateString());
                ticket.AddFooterLine("Hora            : " + DateTime.Now.ToShortTimeString());

                ticket.AddFooterLine("Banco       :" + (sucBE.IBANCOCLAVE != null ? sucBE.IBANCOCLAVE : ""));
                ticket.AddFooterLine("Cuenta      :" + (sucBE.ICUENTAREFERENCIA != null ? sucBE.ICUENTAREFERENCIA : ""));


                ticket.AddFooterLine("");
                ticket.AddFooterLine(new string('-', Ticket.maxChar));
                ticket.AddFooterLine("");
                if (bill1000pesos > 0)
                    ticket.AddFooterLine(formatTwoTotalLine("1000 Pesos       :", bill1000pesos.ToString("N0"), (bill1000pesos * 1000).ToString("N2")));
                if (bill500pesos > 0)
                    ticket.AddFooterLine(formatTwoTotalLine(" 500 Pesos       :", bill500pesos.ToString("N0"), (bill500pesos * 500).ToString("N2")));
                if (bill200pesos > 0)
                    ticket.AddFooterLine(formatTwoTotalLine(" 200 Pesos       :", bill200pesos.ToString("N0"), (bill200pesos * 200).ToString("N2")));
                if (bill100pesos > 0)
                    ticket.AddFooterLine(formatTwoTotalLine(" 100 Pesos       :", bill100pesos.ToString("N0"), (bill100pesos * 100).ToString("N2")));
                if (bill50pesos > 0)
                    ticket.AddFooterLine(formatTwoTotalLine("  50 Pesos       :", bill50pesos.ToString("N0"), (bill50pesos * 50).ToString("N2")));
                if (bill20pesos > 0)
                    ticket.AddFooterLine(formatTwoTotalLine("  20 Pesos       :", bill20pesos.ToString("N0"), (bill20pesos * 20).ToString("N2")));
                if (morrallapesos > 0)
                    ticket.AddFooterLine(formatTwoTotalLine("Morralla pesos   :", "", morrallapesos.ToString("N2")));


                decimal sumaDepositar = (bill1000pesos * 1000) + (bill500pesos * 500) + (bill200pesos * 200) + (bill100pesos * 100) + (bill50pesos * 50) + (bill20pesos * 20) + morrallapesos;

                ticket.AddFooterLine("");
                ticket.AddFooterLine(new string('-', Ticket.maxChar));
                ticket.AddFooterLine(formatTwoTotalLine("TOTAL DEPOSITAR:", "", sumaDepositar.ToString("N2")));
                ticket.AddFooterLine(new string('-', Ticket.maxChar));


                if (this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["REFERENCIAS"] != null &&
                     this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["REFERENCIAS"] != DBNull.Value &&
                     this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["REFERENCIAS"].ToString().Trim().Length > 0)
                {
                    ticket.AddFooterLine(new string('-', Ticket.maxChar));
                    ticket.AddFooterLine("Observaciones");
                    ticket.AddFooterLine(this.dSReimpresionTicket2.MONTOBILLETESRETIROCAJA.Rows[0]["REFERENCIAS"].ToString());
                    ticket.AddFooterLine(new string(' ', Ticket.maxChar));
                }

                ticket.AddFooterLine("");
                ticket.AddFooterLine("==Información deposito por retiro de caja ==");

                if (m_printer != "")
                    ticket.PrintTicketDirect(this.m_printer);
            }


            this.Close();


        }


        private string formatTwoTotalLine(string name, string total1, string total2)
        {

            string line = Ticket.FormatPrintField(name, 15, 0);
            line += Ticket.FormatPrintField(total1, 12, 0);
            line += Ticket.FormatPrintField(total2, 12, 0);
            line = AlignRightText(line.Length) + line;
            return line;
        }


        private string formatTotalLine(string name, string total)
        {

            string line = Ticket.FormatPrintField(name, 28, 0);
            line += Ticket.FormatPrintField(total, 11, 0);
            line = AlignRightText(line.Length) + line;
            return line;
        }

        private string AlignRightText(int lenght)
        {
            string espacios = "";
            int spaces = 39 - lenght;
            for (int x = 0; x < spaces; x++)
                espacios += " ";
            return espacios;
        }



        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
             }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }



        private System.Data.DataTable GenerateTransposedTable(System.Data.DataTable inputTable)
        {
            System.Data.DataTable outputTable = new System.Data.DataTable();

            // Add columns by looping rows

            // Header row's first column is same as in inputTable
            outputTable.Columns.Add(inputTable.Columns[0].ColumnName.ToString());

            // Header row's second column onwards, 'inputTable's first column taken
            foreach (DataRow inRow in inputTable.Rows)
            {
                string newColName = inRow[0].ToString();
                outputTable.Columns.Add(newColName);
            }

            // Add rows by looping columns        
            for (int rCount = 1; rCount <= inputTable.Columns.Count - 1; rCount++)
            {
                DataRow newRow = outputTable.NewRow();

                // First column is inputTable's Header row's second column
                newRow[0] = inputTable.Columns[rCount].ColumnName.ToString();
                for (int cCount = 0; cCount <= inputTable.Rows.Count - 1; cCount++)
                {
                    string colValue = inputTable.Rows[cCount][rCount].ToString();
                    newRow[cCount + 1] = colValue;
                }
                outputTable.Rows.Add(newRow);
            }

            return outputTable;
        }

        private bool ConvertToXls(System.Data.DataTable table, string ExcelFileName)
        {
            try
            {

                //DataSet dsBook = GetGridViewDataSet();//Get the DataSet from your DataSource
                int rows = table.Rows.Count + 1;
                int cols = table.Columns.Count;

                // string ExcelFileName = Path.Combine(Request.PhysicalApplicationPath, fileName);
                if (File.Exists(ExcelFileName))
                {
                    File.Delete(ExcelFileName);
                }
                StreamWriter writer = new StreamWriter(ExcelFileName, false);
                writer.WriteLine("<?xml version=\"1.0\"?>");
                writer.WriteLine("<?mso-application progid=\"Excel.Sheet\"?>");
                writer.WriteLine("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"");
                writer.WriteLine(" xmlns:o=\"urn:schemas-microsoft-com:office:office\"");
                writer.WriteLine(" xmlns:x=\"urn:schemas-microsoft-com:office:excel\"");
                writer.WriteLine(" xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\"");
                writer.WriteLine(" xmlns:html=\"http://www.w3.org/TR/REC-html40/\">");
                writer.WriteLine(" <DocumentProperties xmlns=\"urn:schemas-microsoft-com:office:office\">;");
                writer.WriteLine("  <Author>Automated Report Generator Example</Author>");
                writer.WriteLine(string.Format("  <Created>{0}T{1}Z</Created>", DateTime.Now.ToString("yyyy-mm-dd"), DateTime.Now.ToString("HH:MM:SS")));
                writer.WriteLine("  <Company>51aspx.com</Company>");
                writer.WriteLine("  <Version>11.6408</Version>");
                writer.WriteLine(" </DocumentProperties>");
                writer.WriteLine(" <ExcelWorkbook xmlns=\"urn:schemas-microsoft-com:office:excel\">");
                writer.WriteLine("  <WindowHeight>8955</WindowHeight>");
                writer.WriteLine("  <WindowWidth>11355</WindowWidth>");
                writer.WriteLine("  <WindowTopX>480</WindowTopX>");
                writer.WriteLine("  <WindowTopY>15</WindowTopY>");
                writer.WriteLine("  <ProtectStructure>False</ProtectStructure>");
                writer.WriteLine("  <ProtectWindows>False</ProtectWindows>");
                writer.WriteLine(" </ExcelWorkbook>");
                writer.WriteLine(" <Styles>");
                writer.WriteLine("  <Style ss:ID=\"Default\" ss:Name=\"Normal\">");
                writer.WriteLine("   <Alignment ss:Vertical=\"Bottom\"/>");
                writer.WriteLine("   <Borders/>");
                writer.WriteLine("   <Font/>");
                writer.WriteLine("   <Interior/>");
                writer.WriteLine("   <Protection/>");
                writer.WriteLine("  </Style>");
                writer.WriteLine("  <Style ss:ID=\"s21\">");
                writer.WriteLine("   <Alignment ss:Vertical=\"Bottom\" ss:WrapText=\"1\"/>");
                writer.WriteLine("  </Style>");
                writer.WriteLine(" </Styles>");
                writer.WriteLine(" <Worksheet ss:Name=\"corte_sumarizado\">");
                writer.WriteLine(string.Format("  <Table ss:ExpandedColumnCount=\"{0}\" ss:ExpandedRowCount=\"{1}\" x:FullColumns=\"1\"", cols.ToString(), rows.ToString()));
                writer.WriteLine("   x:FullRows=\"1\">");

                //generate title
                writer.WriteLine("<Row>");
                foreach (DataColumn eachCloumn in table.Columns)  // you can write a half columns of table and put the remaining columns in sheet2
                {
                    writer.Write("<Cell ss:StyleID=\"s21\"><Data ss:Type=\"String\">");
                    writer.Write(eachCloumn.ColumnName.ToString());
                    writer.WriteLine("</Data></Cell>");
                }
                writer.WriteLine("</Row>");

                //generate data
                foreach (DataRow eachRow in table.Rows)
                {
                    writer.WriteLine("<Row>");
                    for (int currentRow = 0; currentRow != cols; currentRow++)
                    {
                        writer.Write("<Cell ss:StyleID=\"s21\"><Data ss:Type=\"String\">");
                        writer.Write(eachRow[currentRow].ToString());
                        writer.WriteLine("</Data></Cell>");
                    }
                    writer.WriteLine("</Row>");
                }
                writer.WriteLine("  </Table>");
                writer.WriteLine("  <WorksheetOptions xmlns=\"urn:schemas-microsoft-com:office:excel\">");
                writer.WriteLine("   <Selected/>");
                writer.WriteLine("   <Panes>");
                writer.WriteLine("    <Pane>");
                writer.WriteLine("     <Number>3</Number>");
                writer.WriteLine("     <ActiveRow>1</ActiveRow>");
                writer.WriteLine("    </Pane>");
                writer.WriteLine("   </Panes>");
                writer.WriteLine("   <ProtectObjects>False</ProtectObjects>");
                writer.WriteLine("   <ProtectScenarios>False</ProtectScenarios>");
                writer.WriteLine("  </WorksheetOptions>");
                writer.WriteLine(" </Worksheet>");
                writer.WriteLine(" <Worksheet ss:Name=\"Sheet2\">");
                writer.WriteLine("  <WorksheetOptions xmlns=\"urn:schemas-microsoft-com:office:excel\">");
                writer.WriteLine("   <ProtectObjects>False</ProtectObjects>");
                writer.WriteLine("   <ProtectScenarios>False</ProtectScenarios>");
                writer.WriteLine("  </WorksheetOptions>");
                writer.WriteLine(" </Worksheet>");
                writer.WriteLine(" <Worksheet ss:Name=\"Sheet3\">");
                writer.WriteLine("  <WorksheetOptions xmlns=\"urn:schemas-microsoft-com:office:excel\">");
                writer.WriteLine("   <ProtectObjects>False</ProtectObjects>");
                writer.WriteLine("   <ProtectScenarios>False</ProtectScenarios>");
                writer.WriteLine("  </WorksheetOptions>");
                writer.WriteLine(" </Worksheet>");
                writer.WriteLine("</Workbook>");
                writer.Close();
                //Response.Write("<script language=\"javascript\">" + "alert('" + "convert completed!')" + "</script>");
                return true;
            }
            catch
            {
                return false;
                //Response.Write("<script language=\"javascript\">" + "alert('" + "error! " + ex.Message + "')" + "</script>");
            }
        }

        private bool MandarCorteSumarizado(DateTime fecha)
        {
            try
            {
                string strArchivoSoloNombre = "Corte_Sumarizado_Suc_" + CurrentUserID.CurrentParameters.ISUCURSALNUMERO + "_Fecha_" + fecha.ToString("dd_MM_yyyy") + ".xls";
                string strArchivo = System.AppDomain.CurrentDomain.BaseDirectory + EnviosMail.FileLocalLocation_Excel + "\\" + strArchivoSoloNombre;


                this.corteTicketSumarizadoExcelTableAdapter.Fill(this.dSReimpresionTicket.CorteTicketSumarizadoExcel, fecha);

                if (CurrentUserID.CurrentParameters.IDESGLOSEIEPS.Equals("S") && this.dSReimpresionTicket.CorteTicketSumarizadoExcel.Rows.Count > 0)
                {
                    this.cORTEIEPSFECHATableAdapter.Fill(this.dataSet1.CORTEIEPSFECHA, fecha);

                    decimal dIepsPorcentaje = 0, dIepsMonto = 0;
                    int count = 0;
                    DataRow drExcel = this.dSReimpresionTicket.CorteTicketSumarizadoExcel.Rows[0];

                    foreach (DataRow drIeps in this.dataSet1.CORTEIEPSFECHA)
                    {
                        count++;
                        if (count > 10)
                            break;

                        dIepsPorcentaje = (decimal)drIeps["TASAIEPS"];
                        dIepsMonto = (decimal)drIeps["MONTO"];

                        string strCampoTasa = "TASAIEPS_" + count.ToString("N0");
                        string strCampoMonto = "MONTOIEPS_" + count.ToString("N0");

                        drExcel[strCampoTasa] = dIepsPorcentaje;
                        drExcel[strCampoMonto] = dIepsMonto;

                    }
                }




                if (ConvertToXls(GenerateTransposedTable(this.dSReimpresionTicket.CorteTicketSumarizadoExcel), strArchivo))
                {
                    if (EnviosMail.EnviarCorteSumarizado(fecha, strArchivo))
                    {
                        return true;
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            return false;

        }

        private void bgEnvioMail_DoWork(object sender, DoWorkEventArgs e)
        {
            switch (m_iOpcion)
            {
                case ImpresionCorteOption.SumarizadoDelDia: m_envioMailExitoso = MandarCorteSumarizado(m_currentFechaCorte);  break;
                case ImpresionCorteOption.SumarizadoDelDiaXCajero: m_envioMailExitoso = MandarCorteSumarizadoXCajero(m_currentFechaCorte); break;
            }

        }

        private void bgEnvioMail_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Style = ProgressBarStyle.Blocks;
            if (m_envioMailExitoso)
            {
                MessageBox.Show("Se envio el corte por mail");
                this.Close();
            }
            else
            {
                MessageBox.Show("El corte no fue enviado.. intentelo mas tarde");
                this.Close();
            }
        }

        

        private bool MandarCorteSumarizadoXCajero(DateTime fecha)
        {
            try
            {
                string strArchivoSoloNombre = "Corte_Sumarizado_x_cajero_Suc_" + CurrentUserID.CurrentParameters.ISUCURSALNUMERO + "_Fecha_" + fecha.ToString("dd_MM_yyyy") + ".xls";
                string strArchivo = System.AppDomain.CurrentDomain.BaseDirectory + EnviosMail.FileLocalLocation_Excel + "\\" + strArchivoSoloNombre;


                this.corteTicketFechaExcelTableAdapter.Fill(this.dataSet1.CorteTicketFechaExcel, fecha);



                if (CurrentUserID.CurrentParameters.IDESGLOSEIEPS.Equals("S"))
                {
                    long corteId = 0;
                    foreach (DataRow drExcel in this.dataSet1.CorteTicketFechaExcel)
                    {
                        
                        
                        if (drExcel["FOLIO"] != null && drExcel["FOLIO"] != DBNull.Value)
                            corteId= (long)drExcel["FOLIO"];
                        else
                        {
                            corteId = 0;
                            continue;
                        }

                        this.cORTEIEPSTableAdapter.Fill(this.dataSet1.CORTEIEPS, corteId);

                        decimal dIepsPorcentaje = 0, dIepsMonto = 0;
                        int count = 0;

                        foreach (DataRow drIeps in this.dataSet1.CORTEIEPS)
                        {
                            count++;
                            if (count > 10)
                                break;

                            dIepsPorcentaje = (decimal)drIeps["TASAIEPS"];
                            dIepsMonto = (decimal)drIeps["MONTO"];

                            string strCampoTasa = "TASAIEPS_" + count.ToString("N0");
                            string strCampoMonto = "MONTOIEPS_" + count.ToString("N0");

                            drExcel[strCampoTasa] = dIepsPorcentaje;
                            drExcel[strCampoMonto] = dIepsMonto;

                        }
                    }
                }



                if (ConvertToXls(this.dataSet1.CorteTicketFechaExcel, strArchivo))
                {
                    if (EnviosMail.EnviarCorteSumarizadoXCajero(fecha, strArchivo))
                    {
                        return true;
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            return false;

        }

       /* private void fillToolStripButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.rEP_CORTESUM_GRUPOFECHATableAdapter.Fill(this.dSReimpresionTicket2.REP_CORTESUM_GRUPOFECHA, new System.Nullable<System.DateTime>(((System.DateTime)(System.Convert.ChangeType(fECHAToolStripTextBox.Text, typeof(System.DateTime))))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }*/

       /* private void fillToolStripButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                object corteid = new object();
                this.corteTicketNTableAdapter.Fill(this.dSReimpresionTicket2.CorteTicketN, corteid);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }*/


       /* private void fillToolStripButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.cORTEIEPSFECHATableAdapter.Fill(this.dataSet1.CORTEIEPSFECHA, new System.Nullable<System.DateTime>(((System.DateTime)(System.Convert.ChangeType(fECHAToolStripTextBox.Text, typeof(System.DateTime))))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }*/
        /*
        private void fillToolStripButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                object CORTEID = new object();
                this.cORTEIEPSTableAdapter.Fill(this.dataSet1.CORTEIEPS, CORTEID);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }*/

        //private void fillToolStripButton_Click_1(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        object corteid = new object();
        //        this.corteTicketB2TableAdapter.Fill(this.dataSet1.CorteTicketB2, corteid);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(ex.Message);
        //    }

        //}






    }
}
