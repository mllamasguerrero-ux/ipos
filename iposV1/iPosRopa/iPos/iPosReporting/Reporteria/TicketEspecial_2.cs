using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Collections;
using System.Runtime.InteropServices;
using System.IO;
using iPosData;
using iPosBusinessEntity;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Globalization;
using FirebirdSql.Data.FirebirdClient;


namespace iPos
{
    public class TicketEspecial_2 : TicketEspecial_1
    {

        public new static string ImprimirTicket(long doctoId, long lOpcion1, bool enDolar,string impresoraEspecial)
        {

            CUSUARIOSD usuariosD = new CUSUARIOSD();
            Boolean usuarioTienePermisoDesgloseKit = usuariosD.UsuarioTienePermisos((int)ConexionesBD.ConexionBD.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null);

            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE doctoBE = new CDOCTOBE();
            doctoBE.IID = doctoId;
            doctoBE = doctoD.seleccionarDOCTO(doctoBE, null);
            if (doctoBE == null)
                return "Error al obtener los datos del documento";


            string tipoImpresionDetalle = "REMISION";
            decimal dCuentaCantidades = 0;

            try
            {

                CTICKET_DETAILD detailD = new CTICKET_DETAILD();
                CTICKET_FOOTERD footerD = new CTICKET_FOOTERD();
                CTICKET_HEADERD headerD = new CTICKET_HEADERD();
                CTICKET_FOOTERBE footerBE = new CTICKET_FOOTERBE();
                CTICKET_HEADERBE headerBE = new CTICKET_HEADERBE();
                CTICKET_DETAILBE[] ListaDetalles = detailD.seleccionarTICKET_DETAIL(doctoId, false, null);
                CSUCURSALBE sucursalBE = new CSUCURSALBE();



                string importeDescuento = "";

                string strReturn = "";


                string[] splitSeparator = new string[] { "\r\n" };

                int iXLetraRenglon = 0;
                string cantidadConLetra;

                footerBE.IDOCTOID = doctoId;
                headerBE.IDOCTOID = doctoId;

                headerBE = headerD.seleccionarTICKET_HEADER(headerBE, null);
                footerBE = footerD.seleccionarTICKET_FOOTER(footerBE, false, null);


                TicketEspecial_2 ticket = new TicketEspecial_2();


                ticket.AddHeaderLineInterlineado("Normal");

                
                ticket.AddHeaderLine("");

                
                
                ticket.AddHeaderLinePredefinedImage(false);
                //nombre de sucursal
                ticket.AddHeaderLine("".PadLeft(6) + headerBE.INOMBRE, "Grande2", false, false, false);

                ticket.AddHeaderLineInterlineado("Corto");

                ticket.AddHeaderLine(new string('_', TicketEspecial_1.maxCharLetraChica));
                //nombre de sucursal
                ticket.AddHeaderLine("TIENDA: " + headerBE.INOMBRE,"Grande",false,false,false);
                
                //fecha hora
                ticket.AddHeaderLine("FECHA: " + doctoBE.IFECHAHORA.ToString("dd/MM/yyyy") + "      HORA: " + doctoBE.IFECHAHORA.ToString("HH:mm:ss"), "Grande", false, false, false);

                //atendido por
                ticket.AddHeaderLine("ATENDIDO POR: " +  headerBE.IVENDEDOR, "Grande", false, false, false);

                ticket.AddHeaderLine(new string('_', TicketEspecial_1.maxCharLetraChica));


                //detalles
                
                

                decimal dCantidad = 0, dSubTotalItem = 0, dIvaItem = 0, dDescuentoItem = 0, dIepsItem = 0;
                decimal dSubTotalSumarizado = 0, dIvaSumarizado = 0, dIepsSumarizado = 0;
                decimal dDescuentoValeSumarizado = 0;
                decimal dTotalItem = 0, dPrecioConImpItem = 0;
                decimal dTotalSumarizado = 0;

                long lastMovtoId = 0;

                foreach (CTICKET_DETAILBE detailItem in ListaDetalles)
                {
                    


                    dCantidad = detailItem.ICANTIDAD;
                    dSubTotalItem = detailItem.ISUBTOTAL;



                    dIvaItem = dSubTotalItem *
                            (ConexionesBD.ConexionBD.CurrentParameters.IDESGLOSEIEPS != null && ConexionesBD.ConexionBD.CurrentParameters.IDESGLOSEIEPS == "S" ? (1 + (detailItem.ITASAIEPS / 100)) : 1) *
                            (detailItem.IIVA / 100);
                    dIepsItem = dSubTotalItem * (ConexionesBD.ConexionBD.CurrentParameters.IDESGLOSEIEPS != null && ConexionesBD.ConexionBD.CurrentParameters.IDESGLOSEIEPS == "S" ? ((detailItem.ITASAIEPS / 100)) : 0);
                    dTotalItem = dSubTotalItem + dIvaItem + dIepsItem;
                    dPrecioConImpItem = dCantidad > 0 ? dTotalItem / dCantidad : dTotalItem;


                    //esta variable nos dara el total sumarizado de los items
                    if (lastMovtoId != detailItem.IMOVTOID)
                    {
                        dSubTotalSumarizado += dSubTotalItem;
                        dIvaSumarizado += dIvaItem;
                        dIepsSumarizado += dIepsItem;
                        dTotalSumarizado += dTotalItem;
                    }



                    //importe descuento
                    //MessageBox.Show("Agragando importe descuento");
                    if (!(bool)detailItem.isnull["IIMPORTEDESCUENTO"])
                    {
                        if (detailItem.IIMPORTEDESCUENTO > 0)
                        {
                            importeDescuento = detailItem.IIMPORTEDESCUENTO.ToString("N2");
                            dDescuentoItem = detailItem.IIMPORTEDESCUENTO;
                        }
                        else
                        {
                            importeDescuento = "";
                            dDescuentoItem = 0;
                        }


                    }
                    else
                    {
                        importeDescuento = "";
                        dDescuentoItem = 0;
                    }


                    dDescuentoValeSumarizado += detailItem.IDESCUENTOVALE;

                    dCuentaCantidades += dCantidad;



                    if (dCantidad != 0)
                    {


                        if (lastMovtoId != detailItem.IMOVTOID)
                        {
                            

                                // Manejo de EMida (recargas y pago de servicios) Inicia
                                string nota = "";
                                string nota2 = "";
                                if (detailItem.IEMIDAREQUESTID > 0)
                                {
                                    if (!(bool)headerBE.isnull["ISUBTIPODOCTOID"] && headerBE.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_PAGOSERVICIO)
                                    {
                                        nota2 = "Pago de servicio . Ref : " + (detailItem.ILOTE != null ? detailItem.ILOTE : "") + " " + getNotaRecarga(detailItem.IEMIDAREQUESTID);
                                    }
                                    else
                                    {
                                        nota = "Recarga a : " + (detailItem.ILOTE != null ? detailItem.ILOTE : "") + " " + getNotaRecarga(detailItem.IEMIDAREQUESTID);
                                    }

                                }

                                decimal dTotal = detailItem.ITOTAL;
                                decimal dPrecioConIva = detailItem.IPRECIOCONIVA;

                                if (!(bool)headerBE.isnull["ISUBTIPODOCTOID"] && headerBE.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_PAGOSERVICIO)
                                {
                                    dTotal = dTotal - detailItem.IEMIDACOMISION;
                                    dPrecioConIva = dPrecioConIva - detailItem.IEMIDACOMISION;
                                }
                                // Manejo de EMida (recargas y pago de servicios) Fin


                                if (detailItem.ISTRPEDIMENTO != null)
                                {
                                    nota = nota + " " + detailItem.ISTRPEDIMENTO;
                                }



                                bool esKit = (detailItem.IESKIT != null && detailItem.IESKIT.Equals("S") && usuarioTienePermisoDesgloseKit);

                                if (!esKit)
                                {
                                    ticket.AddHeaderLine(dCantidad.ToString("N2").PadRight(10) + detailItem.IDESCRIPCION1, "Chica", false, false, false);
                                    ticket.AddHeaderLine(detailItem.IEAN.PadRight(15) + ("$" + dPrecioConImpItem.ToString("N2")).PadLeft(16) + ("$" + (dTotal).ToString("N2")).PadLeft(16), "Chica", false, false, false);

                                }
                                else
                                {
                                    ticket.AddHeaderLine("".PadRight(10) + detailItem.IDESCRIPCION1, "Chica", false, false, false);
                                ticket.AddHeaderLine(detailItem.IEAN.PadRight(15) + ("$" + dPrecioConImpItem.ToString("N2")).PadLeft(16) + ("$" + (dTotal).ToString("N2")).PadLeft(16), "Chica", false, false, false);

                            }

                                
                            
                        }


                        bool esParteKit = usuarioTienePermisoDesgloseKit && detailItem.IKITMOVTOID > 0;


                        if (esParteKit)
                        {

                            ticket.AddHeaderLine("".PadRight(5) + detailItem.IKITCANTIDAD.ToString("N0") + " " + detailItem.IKITPRODDESCRIPCION1, "Chica", false, false, false);
                            
                        }

                    }

                    lastMovtoId = detailItem.IMOVTOID;
                }


                ticket.AddHeaderLine(new string(' ', TicketEspecial_1.maxCharLetraChica));

                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("SUBTOTAL:".PadLeft(25) + ("$" + (footerBE.ITOTAL - footerBE.IIVA).ToString("N2")).PadLeft(15), "Grande", false, false, false);
                ticket.AddHeaderLine("IVA:".PadLeft(25) + ("$" + footerBE.IIVA.ToString("N2")).PadLeft(15), "Grande", false, false, false);
                ticket.AddHeaderLine("TOTAL:".PadLeft(25) + ("$" + footerBE.ITOTAL.ToString("N2")).PadLeft(15), "Grande", false, false, false);

                ticket.AddHeaderLine("DESCUENTO:".PadLeft(25) + ("$" + doctoBE.IMONTOREBAJA.ToString("N2")).PadLeft(15), "Grande", false, false, false);


                if (footerBE.IPAGOTARJETA > 0)
                    ticket.AddHeaderLine("TARJETA:".PadLeft(25) + ("$" + footerBE.IPAGOTARJETA.ToString("N2")).PadLeft(15), "Grande", false, false, false);
                if (footerBE.IPAGOCREDITO > 0)
                    ticket.AddHeaderLine("CREDITO:".PadLeft(25) + ("$" + footerBE.IPAGOCREDITO.ToString("N2")).PadLeft(15), "Grande", false, false, false);
                if (footerBE.IPAGOCHEQUE > 0)
                    ticket.AddHeaderLine("CHEQUE:".PadLeft(25) + ("$" + footerBE.IPAGOCHEQUE.ToString("N2")).PadLeft(15), "Grande", false, false, false);
                if (footerBE.IPAGOVALE > 0)
                    ticket.AddHeaderLine("VALE:".PadLeft(25) + ("$" + footerBE.IPAGOVALE.ToString("N2")).PadLeft(15), "Grande", false, false, false);
                if (footerBE.IPAGOMONEDERO > 0)
                    ticket.AddHeaderLine("MONEDERO:".PadLeft(25) + ("$" + footerBE.IPAGOMONEDERO.ToString("N2")).PadLeft(15), "Grande", false, false, false);
                if (footerBE.IPAGOTRANSFERENCIA > 0)
                    ticket.AddHeaderLine("TRANSFERENCIA:".PadLeft(25) + ("$" + footerBE.IPAGOTRANSFERENCIA.ToString("N2")).PadLeft(15), "Grande", false, false, false);


                if (footerBE.IPAGOEFECTIVO > 0)
                {
                    ticket.AddHeaderLine("DINERO RECIBIDO:".PadLeft(25) + (("$" + footerBE.IPAGOEFECTIVO.ToString("N2"))).PadLeft(15), "Grande", false, false, false);
                    ticket.AddHeaderLine("CAMBIO:".PadLeft(25) + ("$" + footerBE.ICAMBIO.ToString("N2")).PadLeft(15), "Grande", false, false, false);

                }




                ticket.AddHeaderLineInterlineado("Normal");


                //ticket

                ticket.AddHeaderLine(new string(' ', TicketEspecial_1.maxCharLetraChica));
                ticket.AddHeaderLineCodigoBarras(headerBE.ITICKET.ToString("N0"));

                ticket.AddHeaderLine("TICKET DE VENTA: " + headerBE.ITICKET.ToString("N0"), "Chica", true, false, false);

                ticket.AddHeaderLine(new string('_', TicketEspecial_1.maxCharLetraChica));

                ticket.AddHeaderLine("GRACIAS POR SU COMPRA", "Chica", true, false, false);
                ticket.AddHeaderLine("VISITA WWW.IMPORVINO.COM", "Chica", true, false, false);



                string nombreImpresora = impresoraEspecial != null && impresoraEspecial.Length > 0 ? impresoraEspecial :
                                            ConexionesBD.ConexionBD.currentPrinter;
                ticket.PrintTicketDirect(nombreImpresora);// ConexionesBD.ConexionBD.currentPrinter);
            }
            catch (Exception ex)
            {

            }



            return "";
        }

    }
}
