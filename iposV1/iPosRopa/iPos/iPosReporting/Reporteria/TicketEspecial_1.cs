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
using FastReport.Export.Text;

namespace iPos
{
    public class TicketEspecial_1
    {


        List<TextoTicket> headerLines = new List<TextoTicket>();
        List<TextoTicket> subHeaderLines = new List<TextoTicket>();
        ArrayList items = new ArrayList();
        ArrayList totales = new ArrayList();
        List<TextoTicket> footerLines = new List<TextoTicket>();

        public static int maxChar = 39;
        
        public static int maxCharLetraChica = 56;
        public static int maxCharLetraGrande = 56;


        public void AddHeaderLine(string line)
        {


            ImpresorTicketGenerico.AgregarLinea(ref headerLines, line);
        }


        public void AddQRHeaderLine(string line)
        {
            ImpresorTicketGenerico.AgregarQRData(ref headerLines, line);
        }

        public void AddQRFooterLine(string line)
        {
            ImpresorTicketGenerico.AgregarQRData(ref footerLines, line);
        }


        public void AddHeaderLine(string line, bool bPuedeCrecer)
        {
            //if (!bPuedeCrecer)
                ImpresorTicketGenerico.AgregarLinea(ref headerLines, line);

           
        }


        public IEnumerable<string> SplitByLength(string str, int maxLength)
        {
            int index = 0;
            while (index + maxLength < str.Length)
            {
                yield return str.Substring(index, maxLength);
                index += maxLength;
            }

            yield return str.Substring(index);
        }


        public void AddHeaderLine(string line, string tamanioLetra, bool centrado, bool negrita, bool subrayado)
        {
            ImpresorTicketGenerico.AgregarLinea(ref headerLines, line, tamanioLetra, centrado, negrita, subrayado);

        }

        
        public void AddSubHeaderLine(string line)
        {
            ImpresorTicketGenerico.AgregarLinea(ref subHeaderLines, line);
        }


        public void AddHeaderLineCodigoBarras(string line)
        {
            AddHeaderLineCodigoBarras(line, true);
        }

        public void AddHeaderLineCodigoBarras(string line, bool centered)
        {
            ImpresorTicketGenerico.AgregarCodigoBarras(ref headerLines,line, centered);

        }


        public void AddHeaderLinePredefinedImage()
        {
            AddHeaderLinePredefinedImage(true);
        }

        public void AddHeaderLinePredefinedImage(bool centered)
        {
            ImpresorTicketGenerico.AgregarImagenPredefinida(ref headerLines,centered);

        }


        public void AddHeaderLineInterlineado(string interlineado)
        {
            ImpresorTicketGenerico.AgregarInterlineado(ref headerLines, interlineado);

        }

        public void AddFooterLineInterlineado(string interlineado)
        {
            ImpresorTicketGenerico.AgregarInterlineado(ref footerLines, interlineado);

        }


        public void AddSubHeaderLine(string line, string tamanioLetra, bool centrado, bool negrita, bool subrayado)
        {
            ImpresorTicketGenerico.AgregarLinea(ref subHeaderLines, line, tamanioLetra, centrado, negrita, subrayado);

        }
        public void AddItem(string cantidad, string item, string price, string costoUnitario, string impuesto, string lote, string fechacad, string importeDescuento, string tipoRecarga, string tipo, string nota, string clave, string cajas, string piezas)
        {
            OrderItem newItem = new OrderItem('?');
            items.Add(newItem.GenerateItem(cantidad, item, price, costoUnitario, impuesto, lote, fechacad, importeDescuento, tipoRecarga, tipo, nota, clave, cajas,  piezas));
        }
        public void AddItemWithFormat(string tamanioLetra, string cantidad, string item, string price, string costoUnitario, string impuesto, string lote, string fechacad, string importeDescuento, string tipoRecarga, string tipo, string nota, string clave, string cajas, string piezas)
        {
            OrderItem newItem = new OrderItem('?');
            items.Add(newItem.GenerateItem(cantidad, item, price, costoUnitario, impuesto, lote, fechacad, importeDescuento, tipoRecarga, tipo, nota, clave, cajas, piezas, tamanioLetra));
        }
        public void AddTotal(string name, string price)
        {
            OrderTotal newTotal = new OrderTotal('?');
            totales.Add(newTotal.GenerateTotal(name, price));
        }
        public void AddFooterLine(string line)
        {
            ImpresorTicketGenerico.AgregarLinea(ref footerLines, line);
        }

        public void AddFooterLine(string line, string tamanioLetra, bool centrado, bool negrita, bool subrayado)
        {
            ImpresorTicketGenerico.AgregarLinea(ref footerLines, line, tamanioLetra, centrado, negrita, subrayado);

        }



        /*************************/


        public void OpenDrawer(string printer)
        {

            int nLength;
            byte[] toSend2; // 10 = line feed // 13 carriage return/form feed 
            toSend2 = new byte[5] { 27, 112, 0, 64, 240 };
            IntPtr pUnmanagedBytes2 = new IntPtr(0);
            nLength = Convert.ToInt32(toSend2.Length);
            pUnmanagedBytes2 = Marshal.AllocCoTaskMem(nLength);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(toSend2, 0, pUnmanagedBytes2, nLength);
            // Send the unmanaged bytes to the printer.
            bool bSuccess2 = RawPrinterHelper.SendBytesToPrinter(printer, pUnmanagedBytes2, nLength);
            // Free the unmanaged memory that you allocated earlier.

            Marshal.FreeCoTaskMem(pUnmanagedBytes2);

            int nLength2;
            byte[] toSend22; // 10 = line feed // 13 carriage return/form feed 
            toSend22 = new byte[7] { 27, 97, 1, 28, 112, 1, 0 };
            IntPtr pUnmanagedBytes22 = new IntPtr(0);
            nLength2 = Convert.ToInt32(toSend22.Length);
            pUnmanagedBytes22 = Marshal.AllocCoTaskMem(nLength2);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(toSend22, 0, pUnmanagedBytes22, nLength2);
            // Send the unmanaged bytes to the printer.
            bool bSuccess22 = RawPrinterHelper.SendBytesToPrinter(printer, pUnmanagedBytes22, nLength2);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes22);


        }

        public void CutPaper(string printer)
        {
            int nLength;
            byte[] toSend2; // 10 = line feed // 13 carriage return/form feed 
            toSend2 = new byte[4] { /*13*/29, 86, 66, 0 };
            IntPtr pUnmanagedBytes2 = new IntPtr(0);
            nLength = Convert.ToInt32(toSend2.Length);
            pUnmanagedBytes2 = Marshal.AllocCoTaskMem(nLength);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(toSend2, 0, pUnmanagedBytes2, nLength);
            // Send the unmanaged bytes to the printer.
            bool bSuccess2 = RawPrinterHelper.SendBytesToPrinter(printer, pUnmanagedBytes2, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes2);
        }


        public void PrintItems(string printer,  ref List<TextoTicket> printingTextos)
        {
            OrderItem ordIt = new OrderItem('?');
            int currentChar = 0;
            int itemLenght;
            string name;

            string line = "";
            int count = 0;
            //bool bFirstDescLine;


            foreach (string item in items)
            {
                name = ordIt.GetItemName(item);
                itemLenght = name.Length;
                currentChar = 0;

                // imprime iva , costo unitario y precio

                string tipoImpresion = ordIt.GetItemTipo(item);
                string tamanioLetra = ordIt.GetItemTamanioLetra(item);



                switch (tipoImpresion)
                {
                    case "REMISION":
                        {

                            line = ordIt.GetItemClave(item).PadRight(16) + ordIt.GetItemCajas(item).PadLeft(7) + ordIt.GetItemPiezas(item).PadLeft(7) + ordIt.GetItemPrice(item).PadLeft(10);
                            ImpresorTicketGenerico.AgregarLinea(ref printingTextos, line, tamanioLetra);

                            line = name;
                            ImpresorTicketGenerico.AgregarLinea(ref printingTextos, line, tamanioLetra);
                            
                        }
                        break;
                    case "FACTURA":
                        {


                            line = ordIt.GetItemClave(item).PadRight(15) + ordIt.GetItemCajas(item).PadLeft(7) + ordIt.GetItemPiezas(item).PadLeft(7) + ordIt.GetCostoUnitarioPrice(item).PadLeft(8) + ordIt.GetImpuestoPrice(item).PadLeft(7) + ordIt.GetItemPrice(item).PadLeft(11);
                            ImpresorTicketGenerico.AgregarLinea(ref printingTextos, line, tamanioLetra);

                            line = name;
                            ImpresorTicketGenerico.AgregarLinea(ref printingTextos, line, tamanioLetra);
                        }
                        break;
                    case "KIT":
                        {
                            
                            line = name;
                            ImpresorTicketGenerico.AgregarLinea(ref printingTextos, line, tamanioLetra);
                        }
                        break;
                }



                if (ordIt.GetLote(item).Trim() != "")
                {
                    string tipoRecarga = ordIt.GetTipoRecarga(item).Trim();
                    if (tipoRecarga.Equals("SIMPLE") || tipoRecarga.Equals("MULTIPLE"))
                    {

                        line = FormatPrintField(ordIt.GetLote(item), 30, 0);
                    }
                    else
                    {
                        line = "  Lote: " + FormatPrintField(ordIt.GetLote(item), 11, 0);
                        line += "  Cad: " + FormatPrintField(ordIt.GetFechaCad(item), 9, 1);
                    }
                    
                    ImpresorTicketGenerico.AgregarLinea(ref printingTextos, line, tamanioLetra);

                }


                if (ordIt.GetItemNota(item).Trim() != "")
                {


                    line = "Nota: " + ordIt.GetItemNota(item);// FormatPrintField(ordIt.GetItemNota(item), 32, 1);

                    for (int i = 0; i <= (39 * 5); i = i + 39)
                    {
                        if (line.Length > i)
                        {

                            int longitud = line.Length - i > 39 ? 39 : line.Length - i;
                            ImpresorTicketGenerico.AgregarLinea(ref printingTextos, line.Substring(i, longitud), tamanioLetra);
                        }
                        else
                        {
                            break;
                        }


                    }


                }

                


                count++;
            }
            //line = DottedLine();
            //ImpresorTicketGenerico.AgregarLinea(ref printingTextos, line);
            count++;
            
        }

        public void PrintReceiptHeader(string printer, ref List<TextoTicket> printingTextos)
        {


            foreach (TextoTicket header in headerLines)
            {
                printingTextos.Add(header);
            }


            
        }

        public void PrintReceiptFooter(string printer, ref List<TextoTicket> printingTextos)
        {

            string line = "";
            int count = 0;

            OrderTotal ordTot = new OrderTotal('?');
            foreach (string total in totales)
            {


                line = FormatPrintField(ordTot.GetTotalName(total), 28, 0);
                line += FormatPrintField(ordTot.GetTotalCantidad(total), 11, 0);
                line = AlignRightText(line.Length) + line;
                ImpresorTicketGenerico.AgregarLinea(ref printingTextos, line);


                
                count++;
            }

            ImpresorTicketGenerico.AgregarLinea(ref printingTextos, String.Empty);
            ImpresorTicketGenerico.AgregarLinea(ref printingTextos, String.Empty);

            

            foreach (TextoTicket header in footerLines)
            {
                printingTextos.Add(header);
            }

            //Added in these blank lines because RecLinesToCut seems to be wrong on my printer and
            //these extra blank lines ensure the cut is after the footer ends.
            
            ImpresorTicketGenerico.AgregarLinea(ref printingTextos, String.Empty);
            ImpresorTicketGenerico.AgregarLinea(ref printingTextos, String.Empty);
            ImpresorTicketGenerico.AgregarLinea(ref printingTextos, String.Empty);
            ImpresorTicketGenerico.AgregarLinea(ref printingTextos, String.Empty);
            ImpresorTicketGenerico.AgregarLinea(ref printingTextos, String.Empty);
            

        }


        public void PrintText(string printer, string text)
        {
            RawPrinterHelper.SendStringToPrinter(printer, text); //Print text
        }



        public void PrintTicketDirect(string printer)
        {

            PrintTicketDirect(printer, true, (int)ConexionesBD.ConexionBD.CurrentParameters.ITAMANOLETRATICKET);
        }


        public void PrintTicketDirect(string printer, bool abrirCajon, int letra)
        {

            List<TextoTicket> printingTextos = new List<TextoTicket>();


//#if !DEBUG
           //if (abrirCajon)
           //     OpenDrawer(printer);
            //if (letra != 0)
            //    LetraPequena(printer);
//#endif

            PrintReceiptHeader(printer, ref printingTextos);

            PrintItems(printer, ref printingTextos);

            PrintReceiptFooter(printer, ref printingTextos);

            //ImpresorTicketGenerico.imprimirTicketTexto(printingTextos.ToArray(), printer);
            ImpresorTicketGenerico.imprimir(printingTextos.ToArray());

            //PrintText(printer, printingStr.ToString());

//#if !DEBUG
            //CutPaper(printer);
            //if (letra != 0)
            //    LetraNormal(printer);
//#endif

        }





        public static CSUCURSALBE DatosSucursal(long lSucursalTid)
        {

            CSUCURSALD sucursalD = new CSUCURSALD();
            CSUCURSALBE sucursalBE = new CSUCURSALBE();

            sucursalBE.IID = lSucursalTid;
            sucursalBE = sucursalD.seleccionarSUCURSAL(sucursalBE, null);

            return sucursalBE;

        }

        public static CPERSONABE DatosPersona(long lPersonaId)
        {

            CPERSONAD personaD = new CPERSONAD();
            CPERSONABE personaBE = new CPERSONABE();

            personaBE.IID = lPersonaId;
            personaBE = personaD.seleccionarPERSONA(personaBE, null);

            return personaBE;

        }


        public static void AddNombreDeFarmacia(ref TicketEspecial_1 ticket, CTICKET_HEADERBE headerBE)
        {
            if (!(bool)headerBE.isnull["INOMBRE"])
            {
                if (headerBE.INOMBRE.TrimEnd().Length > 39)
                {
                    ticket.AddHeaderLine(headerBE.INOMBRE.TrimEnd().Substring(0, 39));
                    if (headerBE.INOMBRE.TrimEnd().Length > 78)
                        ticket.AddHeaderLine(headerBE.INOMBRE.TrimEnd().Substring(39, 78));
                    else
                        ticket.AddHeaderLine(headerBE.INOMBRE.TrimEnd().Substring(39));
                }
                else
                    ticket.AddHeaderLine(headerBE.INOMBRE.TrimEnd());
            }
        }



        public static void AddDatosDeProveedor(ref TicketEspecial_1 ticket, CPERSONABE proveedorBE)
        {
            string bufferLine = "";
            if (proveedorBE != null)
            {
                ticket.AddHeaderLine("PROVEEDOR: " + proveedorBE.INOMBRE);
                if (proveedorBE.IDOMICILIO != null)
                    bufferLine = proveedorBE.IDOMICILIO.Trim();

                if (proveedorBE.INUMEROEXTERIOR != null)
                    if (proveedorBE.INUMEROEXTERIOR.Trim().Length > 0)
                        bufferLine += " No. " + proveedorBE.INUMEROEXTERIOR.Trim();

                if (proveedorBE.INUMEROINTERIOR != null)
                    if (proveedorBE.INUMEROINTERIOR.Trim().Length > 0)
                        bufferLine += " Int. " + proveedorBE.INUMEROINTERIOR.Trim();
                ticket.AddHeaderLine(bufferLine);



            }
        }


        public static void AddDatosEmpresa(ref TicketEspecial_1 ticket,  CPARAMETROBE empresa)
        {
            ticket.AddHeaderLine(empresa.IFISCALNOMBRE, "Chica", true, false, false);
            ticket.AddHeaderLine("R.F.C.: " + empresa.IRFC, "Chica", true, false, false);


            string bufferLine = ((!(bool)empresa.isnull["IFISCALCALLE"]) ? empresa.IFISCALCALLE.TrimEnd() : "") +
                           " " + ((!(bool)empresa.isnull["IFISCALNUMEROEXTERIOR"]) ? "No " + empresa.IFISCALNUMEROEXTERIOR.TrimEnd() : "") +
                           " " + ((!(bool)empresa.isnull["IFISCALNUMEROINTERIOR"]) ? "Int " + empresa.IFISCALNUMEROINTERIOR.TrimEnd() : "");

            ticket.AddHeaderLine(bufferLine, "Chica", true, false, false);


            if (!(bool)empresa.isnull["IFISCALCOLONIA"])
            {
                ticket.AddHeaderLine("Colonia : " + empresa.IFISCALCOLONIA.TrimEnd(), "Chica", true, false, false);

            }


            if (!(bool)empresa.isnull["IFISCALMUNICIPIO"])
            {
                ticket.AddHeaderLine("Ciudad : " + empresa.IFISCALMUNICIPIO.TrimEnd(), "Chica", true, false, false);

            }
        }


          public static void AddDatosTienda(ref TicketEspecial_1 ticket, CTICKET_HEADERBE headerBE)
        {
            //lugar de expedicion
            string buffer = "Expedido en: ";
            if (!(bool)headerBE.isnull["ICIUDAD"])
            {
                buffer += headerBE.ICIUDAD.TrimEnd();
            }
            if (!(bool)headerBE.isnull["IESTADO"])
            {
                buffer += " " + headerBE.IESTADO.TrimEnd();
            }
            if (!(bool)headerBE.isnull["ICODIGOPOSTAL"])
            {
                buffer += " CP " + headerBE.ICODIGOPOSTAL.TrimEnd();
            }
            ticket.AddHeaderLine(buffer, "Chica", true, false, false);


            // nombre de empresa
            ticket.AddHeaderLine(((!(bool)headerBE.isnull["INOMBRE"]) ? headerBE.INOMBRE.TrimEnd() : ""), "Chica", true, false, false);


            //domicilio y telefono

            string bufferLine = ((!(bool)headerBE.isnull["IDOMICICIO"]) ? headerBE.IDOMICICIO.TrimEnd() : "") +
                           " " + ((!(bool)headerBE.isnull["INUMEROEXTERIOR"]) ? " " + headerBE.INUMEROEXTERIOR.TrimEnd() : "") +
                           " " + ((!(bool)headerBE.isnull["INUMEROINTERIOR"]) ? " " + headerBE.INUMEROINTERIOR.TrimEnd() : "") +
                           " " + ((!(bool)headerBE.isnull["INUMEROINTERIOR"]) ? " TEL: " + headerBE.INUMEROINTERIOR.TrimEnd() : "");



            ticket.AddHeaderLine(bufferLine, "Chica", true, false, false);


            //rfc
            ticket.AddHeaderLine("R.F.C.: " + headerBE.IRFC, "Chica", true, false, false);

            
        }




        public static string getNotaRecarga(long EMIDAREQUESTID)
        {
            CEMIDAREQUESTD emidaRequestD = new CEMIDAREQUESTD();
            CEMIDAREQUESTBE emidaRequestBE = new CEMIDAREQUESTBE();
            emidaRequestBE.IID = EMIDAREQUESTID;
            emidaRequestBE = emidaRequestD.seleccionarEMIDAREQUEST(emidaRequestBE, null);

            string strReturn = "";

            if (emidaRequestBE != null)
            {
                strReturn += emidaRequestBE.IRESPONSEMESSAGE == null ? "" : emidaRequestBE.IRESPONSEMESSAGE;
                strReturn += emidaRequestBE.ICARRIERCONTROLNO == null ? "" : " - Autorización " + emidaRequestBE.ICARRIERCONTROLNO;
                strReturn += emidaRequestBE.ICONTROLNO == null ? "" : " - Control Id " + emidaRequestBE.ICONTROLNO;
                strReturn += emidaRequestBE.ITRANSACTIONDATETIME == null ? "" : " - Fecha/Hora " + emidaRequestBE.ITRANSACTIONDATETIME;

            }

            return strReturn;

        }



        public static void AddDatosCliente(ref TicketEspecial_1 ticket, CPERSONABE personaBE)
        {

            string bufferLine = "";

            if (!(bool)personaBE.isnull["ICLAVE"])
                bufferLine += personaBE.ICLAVE.Trim();


            if (!(bool)personaBE.isnull["INOMBRES"])
                bufferLine += " " + personaBE.INOMBRES.Trim();

            if (!(bool)personaBE.isnull["IAPELLIDOS"])
                bufferLine += " " + personaBE.IAPELLIDOS.Trim();

            
             ticket.AddHeaderLine("CTE: " + bufferLine.TrimEnd());


             bufferLine = ((!(bool)personaBE.isnull["IDOMICILIO"]) ? personaBE.IDOMICILIO.TrimEnd() : "") +
                           " " + ((!(bool)personaBE.isnull["INUMEROEXTERIOR"]) ? " " + personaBE.INUMEROEXTERIOR.TrimEnd() : "") +
                           " " + ((!(bool)personaBE.isnull["INUMEROINTERIOR"]) ? " " + personaBE.INUMEROINTERIOR.TrimEnd() : "") +
                           " " + ((!(bool)personaBE.isnull["INUMEROINTERIOR"]) ? " TEL: " + personaBE.INUMEROINTERIOR.TrimEnd() : "");
            
             ticket.AddHeaderLine(bufferLine);

            if (!(bool)personaBE.isnull["ICOLONIA"])
            {
               ticket.AddHeaderLine(personaBE.ICOLONIA.TrimEnd());
               
            }


            bufferLine = ((!(bool)personaBE.isnull["ICIUDAD"]) ? personaBE.ICIUDAD.TrimEnd() : "") +
                          " " + ((!(bool)personaBE.isnull["IESTADO"]) ? " " + personaBE.IESTADO.TrimEnd() : "") ;

            ticket.AddHeaderLine(bufferLine);



            bufferLine = ((!(bool)personaBE.isnull["ITELEFONO1"]) ? personaBE.ITELEFONO1.TrimEnd() : "").PadRight(16) +
                          " " + ((!(bool)personaBE.isnull["IRFC"]) ? "RFC: " + personaBE.IRFC.TrimEnd() : "RFC:").PadRight(16) +
                          " " + ((!(bool)personaBE.isnull["IPAGOS"]) ? "Pagos: " + personaBE.IPAGOS.TrimEnd() : "Pagos:").PadRight(16);

            ticket.AddHeaderLine(bufferLine);


            ticket.AddHeaderLine("Cruces: " );



        }




        public static void AddDatosClienteApartado(ref TicketEspecial_1 ticket, CPERSONAAPARTADOBE personaBE)
        {

            string bufferLine = "";



            if (!(bool)personaBE.isnull["INOMBRES"])
                bufferLine = personaBE.INOMBRES.Trim();

            if (!(bool)personaBE.isnull["IAPELLIDOS"])
                bufferLine += " " + personaBE.IAPELLIDOS.Trim();


            if (bufferLine.TrimEnd().Length > 32)
            {
                ticket.AddHeaderLine("Nombre: " + bufferLine.TrimEnd().Substring(0, 32));
                if (bufferLine.TrimEnd().Length > 64)
                    ticket.AddHeaderLine("       " + bufferLine.TrimEnd().Substring(32, 64));
                else
                    ticket.AddHeaderLine("       " + bufferLine.TrimEnd().Substring(32));
            }
            else
                ticket.AddHeaderLine("Nombre: " + bufferLine.TrimEnd());



            if (!(bool)personaBE.isnull["IDOMICILIO"])
            {
                if (personaBE.IDOMICILIO.TrimEnd().Length > 32)
                {
                    ticket.AddHeaderLine("Calle: " + personaBE.IDOMICILIO.TrimEnd().Substring(0, 32));
                    if (personaBE.IDOMICILIO.TrimEnd().Length > 64)
                        ticket.AddHeaderLine("       " + personaBE.IDOMICILIO.TrimEnd().Substring(32, 64));
                    else
                        ticket.AddHeaderLine("       " + personaBE.IDOMICILIO.TrimEnd().Substring(32));
                }
                else
                    ticket.AddHeaderLine("Calle: " + personaBE.IDOMICILIO.TrimEnd());
            }


            if (!(bool)personaBE.isnull["ICODIGOPOSTAL"])
            {
                if (personaBE.ICODIGOPOSTAL.TrimEnd().Length > 32)
                {
                    ticket.AddHeaderLine("CP.  : " + personaBE.ICODIGOPOSTAL.TrimEnd().Substring(0, 32));
                }
                else
                    ticket.AddHeaderLine("CP.  : " + personaBE.ICODIGOPOSTAL.TrimEnd());
            }


            if (!(bool)personaBE.isnull["ICOLONIA"])
            {
                if (personaBE.ICOLONIA.TrimEnd().Length > 32)
                {
                    ticket.AddHeaderLine("Col. : " + personaBE.ICOLONIA.TrimEnd().Substring(0, 32));
                }
                else
                {
                    ticket.AddHeaderLine("Col. : " + personaBE.ICOLONIA.TrimEnd());
                }
            }


            if (!(bool)personaBE.isnull["ITELEFONO1"])
            {
                if (personaBE.ITELEFONO1.TrimEnd().Length > 32)
                {
                    ticket.AddHeaderLine("Tel. : " + personaBE.ITELEFONO1.TrimEnd().Substring(0, 32));
                }
                else
                {
                    ticket.AddHeaderLine("Tel. : " + personaBE.ITELEFONO1.TrimEnd());
                }
            }
            else
            {
                ticket.AddHeaderLine("Tel. : ");
            }
        }


        public static string ImprimirTicket(long doctoId,  long lOpcion1, bool enDolar, string impresoraEspecial)
        {
            string retorno = ImprimirTicket_Copia(doctoId, true, lOpcion1, enDolar, impresoraEspecial);

            if(ConexionesBD.ConexionBD.CurrentParameters.IIMPRIMIRCOPIAALMACEN != null && ConexionesBD.ConexionBD.CurrentParameters.IIMPRIMIRCOPIAALMACEN.Equals("S"))
                ImprimirTicket_Copia(doctoId, false, lOpcion1, enDolar, impresoraEspecial);

            return retorno;
        }

            public static string ImprimirTicket_Copia(long doctoId, bool copiaCliente, long lOpcion1, bool enDolar,  string impresoraEspecial)
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
                CTICKET_DETAILBE[] ListaDetalles = detailD.seleccionarTICKET_DETAIL(doctoId,  false, null);
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


                TicketEspecial_1 ticket = new TicketEspecial_1();


                ticket.AddHeaderLineInterlineado("Normal");

                ticket.AddHeaderLine(copiaCliente ? "Copia Cliente" : "Copia Almacen","Grande2",true, true, false);
                //ticket.AddHeaderLine("");
                ticket.AddHeaderLinePredefinedImage();
                ticket.AddHeaderLineCodigoBarras(DateTime.Today.Day.ToString() + "." + DateTime.Today.Month.ToString() + "." + headerBE.ITICKET.ToString());
                //ticket.AddHeaderLine("");
                //ticket.AddHeaderLine(DateTime.Today.Day.ToString() + "-" + DateTime.Today.Month.ToString() + "-" + headerBE.ITICKET.ToString(), "Grande2", true, true, false);
                //ticket.AddHeaderLine("");
                //ticket.AddHeaderLine("");
                ticket.AddHeaderLineInterlineado("Corto");
                AddDatosEmpresa(ref ticket, ConexionesBD.ConexionBD.CurrentParameters);
                ticket.AddHeaderLine("");
                AddDatosTienda(ref ticket, headerBE);
                ticket.AddHeaderLine(new string('_', TicketEspecial_1.maxCharLetraChica));
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("FECHA: " + headerBE.IFECHA.ToString("dd/MM/yyyy") + "      FOLIO: " + headerBE.ITICKET.ToString(), "Chica", false, false, false);

                
                //ticket.AddHeaderLine("VENTA DE MOSTRADOR");
                //if (headerBE.IPERSONAID != DBValues._CLIENTEMOSTRADOR)
                //{
                    CPERSONABE clienteBE = DatosPersona(headerBE.IPERSONAID);
                    if (clienteBE != null)
                    {
                        AddDatosCliente(ref ticket, clienteBE);
                    }

                //}


                ticket.AddHeaderLine("VENDEDOR: " + headerBE.IVENDEDOR);
                ticket.AddHeaderLine("TIPO PAGO: " + (doctoBE.IPAGOACREDITO != null && doctoBE.IPAGOACREDITO.Equals("S") ? "Credito" : "Contado") );



                //ticket.AddHeaderLineInterlineado("Corto");

                ticket.AddHeaderLine(new string('_', TicketEspecial_1.maxCharLetraChica));
                ticket.AddHeaderLine("CLAVE           CAJAS   BOT    IMPORTE","Grande",false, false, false);
                ticket.AddHeaderLine("D E S C R I P C I O N", "Grande",true, false, false);
                ticket.AddHeaderLine(new string('_', TicketEspecial_1.maxCharLetraChica));


                decimal dCantidad = 0, dSubTotalItem = 0, dIvaItem = 0, dDescuentoItem = 0, dIepsItem = 0;
                decimal dSubTotalSumarizado = 0, dIvaSumarizado = 0, dIepsSumarizado = 0;
                decimal dDescuentoValeSumarizado = 0;
                decimal dTotalItem = 0, dPrecioConImpItem = 0;
                decimal dTotalSumarizado = 0;

                long lastMovtoId = 0;

                string plazoClave = "";
                bool tienePlazoClaveT = false;


                foreach (CTICKET_DETAILBE detailItem in ListaDetalles)
                {

                    plazoClave = detailItem.IPLAZOCLAVE != null ? detailItem.IPLAZOCLAVE : "" ;
                    if (plazoClave.Equals("T"))
                        tienePlazoClaveT = true;


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

                            if (lOpcion1 == Ticket._OPCION_IMPRESION_TRASLADO_RECEPCION || lOpcion1 == Ticket._OPCION_IMPRESION_TRASLADO_DEVOLUCION ||
                                lOpcion1 == Ticket._OPCION_IMPRESION_COMPRA_RECEPCION || lOpcion1 == Ticket._OPCION_IMPRESION_COMPRA_DEVOLUCION)
                            {

                                decimal dPiezas  = ((bool)detailItem.isnull["IPIEZAS"]) ? 0 : detailItem.IPIEZAS;
                                bool esKit = detailItem.IESKIT != null && detailItem.IESKIT.Equals("S");

                                ticket.AddItemWithFormat("Grande", 
                                                dCantidad.ToString("N3"),
                                                (detailItem.IES_COMODIN.Equals("S") ? detailItem.IDESCRIPCION1 + " " + detailItem.IDESCRIPCION2 + " " + detailItem.IDESCRIPCION3 : detailItem.IDESCRIPCION1),
                                                dTotalItem.ToString("N2"),
                                                 dPrecioConImpItem.ToString("N2"),
                                                "-",
                                                 detailItem.ILOTE,
                                                 ((bool)detailItem.isnull["IFECHAVENCE"]) ? "" : detailItem.IFECHAVENCE.ToString("dd/MM/yy"),
                                                "",
                                                 ((bool)detailItem.isnull["ITIPORECARGA"]) ? "" : detailItem.ITIPORECARGA,
                                                tipoImpresionDetalle,
                                                (lOpcion1 == Ticket._OPCION_IMPRESION_TRASLADO_DEVOLUCION || lOpcion1 == Ticket._OPCION_IMPRESION_COMPRA_DEVOLUCION) ? detailItem.IMOTIVODEVOLUCION : "",
                                                ((bool)detailItem.isnull["IPRODUCTOCLAVE"]) ? "" : detailItem.IPRODUCTOCLAVE,
                                                ((bool)detailItem.isnull["ICAJAS"]) ? "" : detailItem.ICAJAS.ToString("N0") + " CAJ",
                                                dPiezas > 0 ? (esKit ? dPiezas.ToString("N0") + " KIT" : dPiezas.ToString("N0") + " BOT") : "");

                            }
                            else
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

                                ticket.AddItemWithFormat("Grande",
                                                detailItem.IESKIT != null && detailItem.IESKIT.Equals("S") && usuarioTienePermisoDesgloseKit ? "" : dCantidad.ToString("N3"),
                                                 (detailItem.IES_COMODIN.Equals("S") ? detailItem.IDESCRIPCION1 + " " + detailItem.IDESCRIPCION2 + " " + detailItem.IDESCRIPCION3 : detailItem.IDESCRIPCION1),
                                                 enDolar ? detailItem.IIMPORTEENDOLAR.ToString("N3") : ((headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA) ? (dTotal).ToString("N2") : dTotal.ToString("N2")),
                                                 enDolar ? detailItem.ICOSTOENDOLAR.ToString("N3") : dPrecioConIva.ToString("N2"),
                                                 enDolar ? "" : detailItem.IIVA.ToString("N2"),
                                                 detailItem.ILOTE,
                                                 ((bool)detailItem.isnull["IFECHAVENCE"]) ? "" : detailItem.IFECHAVENCE.ToString("dd/MM/yy"),
                                                "",
                                                 detailItem.ITIPORECARGA,
                                                tipoImpresionDetalle,
                                                nota,
                                                ((bool)detailItem.isnull["IPRODUCTOCLAVE"]) ? "" : detailItem.IPRODUCTOCLAVE,
                                                ((bool)detailItem.isnull["ICAJAS"]) ? "" : detailItem.ICAJAS.ToString("N0") + " CAJ",
                                                ((bool)detailItem.isnull["IPIEZAS"]) ? "" : detailItem.IPIEZAS.ToString("N0") + " BOT");





                                // Manejo de EMida (recargas y pago de servicios) Inicia

                                if (!(bool)headerBE.isnull["ISUBTIPODOCTOID"] && headerBE.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_PAGOSERVICIO)
                                {
                                    ticket.AddItemWithFormat("Grande",
                                                    "",
                                                    "COMISION",
                                                     detailItem.IEMIDACOMISION.ToString("N2"),
                                                    "",
                                                    "-",
                                                    "",
                                                    "",
                                                    "",
                                                    "",
                                                    tipoImpresionDetalle,
                                                    nota2,
                                                    "",
                                                    "",
                                                    "");

                                }
                                // Manejo de EMida (recargas y pago de servicios) Fin


                            }
                        }


                        if (usuarioTienePermisoDesgloseKit && detailItem.IKITMOVTOID > 0)
                        {
                            
                            ticket.AddItemWithFormat("Chica",
                                             "  ",
                                             "  " + detailItem.IKITCANTIDAD.ToString("N0") + " " + detailItem.IKITPRODDESCRIPCION1,
                                             "",
                                             "",
                                             "",
                                             "",
                                             "",
                                            "",
                                            "",
                                            "KIT",
                                            "",
                                            "",
                                            "",
                                            "");

                        }

                    }
                    
                    lastMovtoId = detailItem.IMOVTOID;
                }


                ticket.AddFooterLine(new string('_', TicketEspecial_1.maxCharLetraChica));
                ticket.AddFooterLine("Cajas " + footerBE.ICAJAS.ToString("N0") + " Piezas " + footerBE.IPIEZAS.ToString("N0"),"Grande",false, false, false);
                ticket.AddFooterLine(new string('_', TicketEspecial_1.maxCharLetraChica));

                ticket.AddFooterLine("");
                ticket.AddFooterLine(    "       T O T A L       :" + footerBE.ITOTAL.ToString("N2").PadLeft(16), "Grande", false, false, false);

                ticket.AddFooterLine("");
                if (footerBE.IPAGOEFECTIVO > 0)
                    ticket.AddFooterLine("       E F E C T I V O :" + (footerBE.IPAGOEFECTIVO).ToString("N2").PadLeft(16), "Grande", false, false, false);

                if (footerBE.IPAGOTARJETA > 0)
                    ticket.AddFooterLine("Pago Tarjeta:      " + footerBE.IPAGOTARJETA.ToString("N2").PadLeft(19), "Grande", false, false, false);
                if (footerBE.IPAGOCREDITO > 0)
                    ticket.AddFooterLine("Pago Credito:      " + footerBE.IPAGOCREDITO.ToString("N2").PadLeft(19), "Grande", false, false, false);
                if (footerBE.IPAGOCHEQUE > 0)
                    ticket.AddFooterLine("Pago Cheque:       " + footerBE.IPAGOCHEQUE.ToString("N2").PadLeft(19), "Grande", false, false, false);
                if (footerBE.IPAGOVALE > 0)
                    ticket.AddFooterLine("Pago Vale:         " + footerBE.IPAGOVALE.ToString("N2").PadLeft(19), "Grande", false, false, false);
                if (footerBE.IPAGOMONEDERO > 0)
                    ticket.AddFooterLine("Pago Monedero:     " + footerBE.IPAGOMONEDERO.ToString("N2").PadLeft(19), "Grande", false, false, false);
                if (footerBE.IPAGOTRANSFERENCIA > 0)
                    ticket.AddFooterLine("Pago Transferencia:" + footerBE.IPAGOTRANSFERENCIA.ToString("N2").PadLeft(19), "Grande", false, false, false);

                ticket.AddFooterLine(    "       C A M B I O     :" +  footerBE.ICAMBIO.ToString("N2").PadLeft(16),"Grande",false, false, false);



                ticket.AddFooterLineInterlineado("Corto");

                ticket.AddFooterLine("");
                cantidadConLetra = "(" + Numalet.ToCardinal(footerBE.ITOTAL).ToUpper() + ")";
                ticket.AddFooterLine(cantidadConLetra.Substring((Ticket.maxChar * iXLetraRenglon)));
                ticket.AddFooterLine("");



                if (tienePlazoClaveT)
                {

                    ticket.AddFooterLine("VENTA REALIZADA POR CUENTA Y NOMBRE DE JORGE SALLE", "Chica", false, false, false);
                    ticket.AddFooterLine("CUERVO Y SUCESORES SA DE CV LEANDRO VALLE # 991 COLONIA", "Chica", false, false, false);
                    ticket.AddFooterLine("CENTRO GUADALAJARA JALISCO CP. 44100 RFC: JSC-781207-6Q3", "Chica", false, false, false);
                    ticket.AddFooterLine("EN CALIDAD DE COMISIONISTA", "Chica", false, false, false);
                    ticket.AddFooterLine("");
                }


                if (headerBE.IOBSERVACION != null && headerBE.IOBSERVACION.Trim().Length > 0)
                {
                    ticket.AddFooterLine("Observacion : " + headerBE.IOBSERVACION, "Chica", false, false, false);
                }


                if (doctoBE.INOTAPAGO != null && doctoBE.INOTAPAGO.Trim().Length > 0)
                {
                    ticket.AddFooterLine("Nota : " + doctoBE.INOTAPAGO, "Chica", false, false, false);
                }


                //footer
                if (!(bool)ConexionesBD.ConexionBD.CurrentParameters.isnull["IFOOTER"])
                {
                    if (ConexionesBD.ConexionBD.CurrentParameters.IFOOTER != "")
                    {
                        string[] splitFooter = ConexionesBD.ConexionBD.CurrentParameters.IFOOTER.Split(splitSeparator, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string strFtr in splitFooter)
                        {

                            string strBuffer = strFtr.Replace("[nombreVendedor]", headerBE.IVENDEDOR).Replace("[horaVenta]",doctoBE.IFECHAHORA.ToString("hh:mm:ss"));
                            ticket.AddFooterLine(strBuffer,"Chica",false,false,false);
                        }
                    }
                }

                AgregarLeyendaPlazoSiAplica(ref ticket, doctoBE.IPLAZOID);

                ticket.AddFooterLineInterlineado("Normal");


                string nombreImpresora = impresoraEspecial != null && impresoraEspecial.Length > 0 ? impresoraEspecial :
                                            ConexionesBD.ConexionBD.currentPrinter;

                ticket.PrintTicketDirect(nombreImpresora); //ConexionesBD.ConexionBD.currentPrinter);
            }
            catch(Exception ex)
            {

            }



            return "";
        }





        public static string ImprimirTicketFacturaElectronica(
            long doctoId, 
            FbTransaction m_fTrans,
            bool m_silentMode,
            ref string m_iComentario,
            string m_nombreFormaPago,
            CDOCTOPAGOBE m_doctoPago,
            CPARAMETROBE m_empresa,
            System.Data.DataRowCollection REP_FACTURAELECTRONICA_DETRows,
            CCLIENTEBE clienteBE,
            CPERSONABE usuarioBE,
            String referenciaCredito,
            string strCuentaPago
            )
        {


            string retorno = ImprimirTicketFacturaElectronica_Copia(
                                    doctoId, true, m_fTrans, m_silentMode, ref m_iComentario,
                                    m_nombreFormaPago, m_doctoPago, m_empresa, REP_FACTURAELECTRONICA_DETRows, 
                                    clienteBE, usuarioBE, referenciaCredito, strCuentaPago
                                );

            if (ConexionesBD.ConexionBD.CurrentParameters.IIMPRIMIRCOPIAALMACEN != null && ConexionesBD.ConexionBD.CurrentParameters.IIMPRIMIRCOPIAALMACEN.Equals("S"))
            {
                ImprimirTicketFacturaElectronica_Copia(
                                    doctoId, false, m_fTrans, m_silentMode, ref m_iComentario,
                                    m_nombreFormaPago, m_doctoPago, m_empresa, REP_FACTURAELECTRONICA_DETRows,
                                    clienteBE, usuarioBE, referenciaCredito, strCuentaPago
                                );
            }


            return retorno;

        }


         public static string ImprimirTicketFacturaElectronica_Copia(
            long doctoId, bool copiaCliente, 
            FbTransaction m_fTrans,
            bool m_silentMode,
            ref string m_iComentario,
            string m_nombreFormaPago,
            CDOCTOPAGOBE m_doctoPago,
            CPARAMETROBE m_empresa,
            System.Data.DataRowCollection REP_FACTURAELECTRONICA_DETRows,
            CCLIENTEBE clienteBE,
            CPERSONABE usuarioBE,
            String referenciaCredito,
            string strCuentaPago
            )
        {

            CUSUARIOSD usuariosD = new CUSUARIOSD();
            Boolean usuarioTienePermisoDesgloseKit = usuariosD.UsuarioTienePermisos((int)ConexionesBD.ConexionBD.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null);

            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE doctoBE = new CDOCTOBE();
            doctoBE.IID = doctoId;
            doctoBE = doctoD.seleccionarDOCTO(doctoBE, null);
            if (doctoBE == null)
                return "Error al obtener los datos del documento";


            string tipoImpresionDetalle = "FACTURA";
            decimal dCuentaCantidades = 0;

            try
            {

                CTICKET_DETAILD detailD = new CTICKET_DETAILD();
                CTICKET_FOOTERD footerD = new CTICKET_FOOTERD();
                CTICKET_HEADERD headerD = new CTICKET_HEADERD();
                CTICKET_FOOTERBE footerBE = new CTICKET_FOOTERBE();
                CTICKET_HEADERBE headerBE = new CTICKET_HEADERBE();
                //CTICKET_DETAILBE[] ListaDetalles = detailD.seleccionarTICKET_DETAIL(doctoId, false, null);
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


                string bufferNumCSD = Path.GetFileName(m_empresa.ITIMBRADOARCHIVOCERTIFICADO);
                decimal SubTotal = (clienteBE.m_PersonaBE.IDESGLOSEIEPS.Equals("S") && m_empresa.IDESGLOSEIEPS.Equals("S")) ? doctoBE.ISUBTOTAL : doctoBE.ISUBTOTAL + doctoBE.IIEPS;
                decimal Total = doctoBE.ITOTAL - doctoBE.IIVARETENIDO - doctoBE.IISRRETENIDO;
                string totalEnLetra = Numalet.ToCardinal(Total).ToUpper();


                TicketEspecial_1 ticket = new TicketEspecial_1();


                ticket.AddHeaderLineInterlineado("Normal");

                ticket.AddHeaderLine(copiaCliente ? "Copia Cliente" : "Copia Almacen", "Grande2", true, true, false);
                //ticket.AddHeaderLine("");
                ticket.AddHeaderLinePredefinedImage();
                ticket.AddHeaderLineCodigoBarras(DateTime.Today.Day.ToString() + "." + DateTime.Today.Month.ToString() + "." + headerBE.ITICKET.ToString());
                //ticket.AddHeaderLine("");
                ticket.AddHeaderLine("FACTURA: " + doctoBE.IFOLIOSAT.ToString("0") + doctoBE.ISERIESAT, "Grande2", true, true, false);
                //ticket.AddHeaderLine(DateTime.Today.Day.ToString() + "-" + DateTime.Today.Month.ToString() + "-" + headerBE.ITICKET.ToString(), "Grande2", true, true, false);
                //ticket.AddHeaderLine("");
                //ticket.AddHeaderLine("");
                ticket.AddHeaderLineInterlineado("Corto");
                AddDatosEmpresa(ref ticket, ConexionesBD.ConexionBD.CurrentParameters);
                ticket.AddHeaderLine("");
                AddDatosTienda(ref ticket, headerBE);
                //ticket.AddHeaderLine(new string('_', TicketEspecial_1.maxCharLetraChica));
                //ticket.AddHeaderLine("FECHA: " + headerBE.IFECHA.ToString("dd/MM/yyyy") + "      FOLIO: " + headerBE.ITICKET.ToString(), "Chica", false, false, false);



                
                ticket.AddHeaderLine(new string('_', TicketEspecial_1.maxCharLetraChica));

                ticket.AddHeaderLine("Met de pago: " + m_nombreFormaPago.PadRight(20) + "Cuen Pago: " + strCuentaPago, "Chica",false, false, false);
                ticket.AddHeaderLine("Fecha y hora cer: " + doctoBE.ITIMBRADOFECHAFACTURA.AddMinutes(-5).ToString("yyyy-MM-dd'T'HH:mm:ss"), "Chica", false, false, false);

                ticket.AddHeaderLine("FOLIO FISCAL : " + doctoBE.ITIMBRADOUUID, "Chica", false, false, false);
                ticket.AddHeaderLine("No. SERIE CER CSD: " + bufferNumCSD.Substring(0, bufferNumCSD.Length - 4).ToUpper(), "Chica", false, false, false);
                ticket.AddHeaderLine("No. SERIE CER SAT: " + doctoBE.ITIMBRADOCERTSAT, "Chica", false, false, false);
                ticket.AddHeaderLine("FACTURA: " + doctoBE.IFOLIOSAT.ToString("0") + " Serie: " + doctoBE.ISERIESAT + "  Venta " + doctoBE.IFOLIO.ToString("0"), "Chica", false, false, false);


                //ticket.AddHeaderLine("VENTA DE MOSTRADOR");
                //if (headerBE.IPERSONAID != DBValues._CLIENTEMOSTRADOR)
                //{
                //CPERSONABE clienteBE = DatosPersona(headerBE.IPERSONAID);
                if (clienteBE != null)
                {
                    AddDatosCliente(ref ticket, clienteBE.m_PersonaBE);
                }

                //}

                ticket.AddHeaderLine(new string('_', TicketEspecial_1.maxCharLetraChica));
                ticket.AddHeaderLine("COND: " + "CONTADO", "Chica", false, false, false);
                ticket.AddHeaderLine("COND: " , "Chica", false, false, false);
                ticket.AddHeaderLine(new string('_', TicketEspecial_1.maxCharLetraChica));

                ticket.AddHeaderLine("VENDEDOR: " + headerBE.IVENDEDOR);
                ticket.AddHeaderLine("TIPO PAGO: " + (doctoBE.IPAGOACREDITO != null && doctoBE.IPAGOACREDITO.Equals("S") ? "Credito" : "Contado"));



                //ticket.AddHeaderLineInterlineado("Corto");

                ticket.AddHeaderLine(new string('_', TicketEspecial_1.maxCharLetraChica));
                ticket.AddHeaderLine("CLAVE           CAJAS   BOT      P/U     IVA     IMPORTE", "Chica", false, false, false);
                ticket.AddHeaderLine("D E S C R I P C I O N", "Chica", true, false, false);
                ticket.AddHeaderLine(new string('_', TicketEspecial_1.maxCharLetraChica));


                decimal dCantidad = 0, dSubTotalItem = 0, dIvaItem = 0, dDescuentoItem = 0, dIepsItem = 0;
                decimal dSubTotalSumarizado = 0, dIvaSumarizado = 0, dIepsSumarizado = 0;
                decimal dDescuentoValeSumarizado = 0;
                decimal dTotalItem = 0, dPrecioConImpItem = 0, dPrecioItem = 0;
                decimal dTotalSumarizado = 0;

                decimal dPorcentajeIva = 0;
                decimal dPorcentajeIeps = 0;
                string strEsKit = "N";
                string strProductoDescripcion = "";
                string strLote = "";
                DateTime? fechaVence = null;
                string strProductoClave = "";
                decimal dPiezas = 0;
                decimal dCajas = 0;
                decimal KITCANTIDAD = 0 ;
                string KITPRODDESCRIPCION1 = "";
                long KITMOVTOID = 0;

                long lastMovtoId = 0;
                long movtoId = 0;

                string plazoClave = "";
                bool tienePlazoClaveT = false;

                Hashtable htIva = new Hashtable();
                Hashtable htIeps = new Hashtable();


                foreach (System.Data.DataRow dr in REP_FACTURAELECTRONICA_DETRows)
                {

                    movtoId = (long)dr["MOVTOID"];


                    dPorcentajeIva = dr["PORCENTAJEIVA"] != DBNull.Value ? (decimal)dr["PORCENTAJEIVA"] : 0;
                    dPorcentajeIeps = dr["PORCENTAJEIEPS"] != DBNull.Value ? (decimal)dr["PORCENTAJEIEPS"] : 0;
                    strEsKit = dr["ESKIT"] != DBNull.Value ? (string)dr["ESKIT"] : "N";
                    strProductoDescripcion = dr["PRODUCTODESCRIPCION"] != DBNull.Value ? (string)dr["PRODUCTODESCRIPCION"] : "";
                    strLote = "";
                    fechaVence = null;
                    strProductoClave = dr["PRODUCTOCLAVE"] != DBNull.Value ? (string)dr["PRODUCTOCLAVE"] : "";
                    dPiezas = dr["PIEZASSUELTAS"] != DBNull.Value ? (decimal)dr["PIEZASSUELTAS"] : 0;
                    dCajas = dr["CAJAS"] != DBNull.Value ? (decimal)dr["CAJAS"] : 0;
                    KITMOVTOID = dr["KITMOVTOID"] != DBNull.Value ? (long)dr["KITMOVTOID"] : 0;
                    KITCANTIDAD = dr["KITCANTIDAD"] != DBNull.Value ? (decimal)dr["KITCANTIDAD"] : 0;
                    KITPRODDESCRIPCION1 = dr["KITPRODDESCRIPCION1"] != DBNull.Value ? (string)dr["KITPRODDESCRIPCION1"] : "";

                    plazoClave = dr["PLAZOCLAVE"] != DBNull.Value ? (string)dr["PLAZOCLAVE"] : "";
                    if (plazoClave.Equals("T"))
                        tienePlazoClaveT = true;

                    dCantidad = (decimal)dr["CANTIDAD"];
                    dSubTotalItem = (decimal)dr["SUBTOTAL"];

                    dIvaItem = (decimal)dr["IVA"];
                    dIepsItem = (ConexionesBD.ConexionBD.CurrentParameters.IDESGLOSEIEPS != null && ConexionesBD.ConexionBD.CurrentParameters.IDESGLOSEIEPS == "S") ? (decimal)dr["IEPS"] : 0;
                    dTotalItem = (decimal)dr["TOTAL"];
                    dPrecioItem = (ConexionesBD.ConexionBD.CurrentParameters.IDESGLOSEIEPS != null && ConexionesBD.ConexionBD.CurrentParameters.IDESGLOSEIEPS == "S") ? (decimal)dr["PRECIO"] * (1 + (dPorcentajeIeps/100)) : (decimal)dr["PRECIO"] ;




                    //dIvaItem = dSubTotalItem *
                    //        (ConexionesBD.ConexionBD.CurrentParameters.IDESGLOSEIEPS != null && ConexionesBD.ConexionBD.CurrentParameters.IDESGLOSEIEPS == "S" ? (1 + (dPorcentajeIeps / 100)) : 1) *
                    //        (dPorcentajeIva / 100);
                    //dIepsItem = dSubTotalItem * (ConexionesBD.ConexionBD.CurrentParameters.IDESGLOSEIEPS != null && ConexionesBD.ConexionBD.CurrentParameters.IDESGLOSEIEPS == "S" ? ((dPorcentajeIeps / 100)) : 1);
                    //dTotalItem = dSubTotalItem + dIvaItem + dIepsItem;
                    //dPrecioConImpItem = dCantidad > 0 ? dTotalItem / dCantidad : dTotalItem;








                    //esta variable nos dara el total sumarizado de los items
                    if (lastMovtoId != movtoId)
                    {
                        dSubTotalSumarizado += dSubTotalItem;
                        dIvaSumarizado += dIvaItem;
                        dIepsSumarizado += dIepsItem;
                        dTotalSumarizado += dTotalItem;
                    }

                    

                    //*-dDescuentoValeSumarizado += detailItem.IDESCUENTOVALE;

                    dCuentaCantidades += dCantidad;



                    if (dCantidad != 0)
                    {


                        if (lastMovtoId != movtoId)
                        {


                            //calculating iva
                            if (htIva.Contains(dPorcentajeIva))
                                htIva[dPorcentajeIva] = (decimal)htIva[dPorcentajeIva] + dIvaItem;
                            else
                                htIva[dPorcentajeIva] = dIvaItem;


                            if (m_empresa.IDESGLOSEIEPS.Equals("S") && clienteBE.m_PersonaBE.IDESGLOSEIEPS.Equals("S"))
                            {
                                //calculating ieps
                                

                                if (htIeps.Contains(dPorcentajeIeps))
                                    htIeps[dPorcentajeIeps] = (decimal)htIeps[dPorcentajeIeps] + dIepsItem;
                                else
                                    htIeps[dPorcentajeIeps] = dIepsItem;
                            }
                            


                            // Manejo de EMida (recargas y pago de servicios) Inicia
                            string nota = "";
                                string nota2 = "";
                            



                                if (dr["STRPEDIMENTO"] != DBNull.Value)
                                {
                                    nota = nota + " " + (string)dr["STRPEDIMENTO"];
                                }

                                ticket.AddItemWithFormat("Chica",
                                                strEsKit != null && strEsKit.Equals("S") && usuarioTienePermisoDesgloseKit ? "" : dCantidad.ToString("N3"),
                                                 strProductoDescripcion,
                                                 dTotalItem.ToString("N2"),
                                                 dPrecioItem.ToString("N2"),
                                                 dPorcentajeIva.ToString("N2"),
                                                 strLote,
                                                 fechaVence != null ? fechaVence.Value.ToString("dd/MM/yy") : "",
                                                "",
                                                "",
                                                tipoImpresionDetalle,
                                                nota,
                                                strProductoClave,
                                                dCajas > 0 ? dCajas.ToString("N0") + " CAJ" : "",
                                                dPiezas > 0 ? (strEsKit != null && strEsKit.Equals("S") ? dPiezas.ToString("N0") + " KIT" : dPiezas.ToString("N0") + " BOT") : "" );




                            


                            
                        }


                        if (usuarioTienePermisoDesgloseKit && KITMOVTOID > 0)
                        {


                            ticket.AddItemWithFormat("Chica",
                                             "  " ,
                                             "  " + KITCANTIDAD.ToString("N0") +  " " + KITPRODDESCRIPCION1,
                                             "",
                                             "",
                                             "",
                                             "",
                                             "",
                                            "",
                                            "",
                                            "KIT",
                                            "",
                                            "",
                                            "",
                                            "");
                        }

                    }

                    lastMovtoId = movtoId;
                }


                ticket.AddFooterLine(new string('_', TicketEspecial_1.maxCharLetraChica));
                ticket.AddFooterLine("Cajas " + footerBE.ICAJAS.ToString("N0") + " Piezas " + footerBE.IPIEZAS.ToString("N0"), "Grande", false, false, false);
                ticket.AddFooterLine(new string('_', TicketEspecial_1.maxCharLetraChica));



                ticket.AddFooterLine(new string(' ', TicketEspecial_1.maxCharLetraChica));
                ticket.AddFooterLine("CADENA ORIGINAL DEL COMPLEMENTO DE CERTIF DEL SAT","Chica",false, false, false);
                ticket.AddFooterLine("||1.0|" + doctoBE.ITIMBRADOUUID + "|" + doctoBE.ITIMBRADOFECHA + "|" + doctoBE.ITIMBRADOSELLOCFDI + "|" + doctoBE.ITIMBRADOCERTSAT + "||", "Chica", false, false, false);

                ticket.AddFooterLine(new string(' ', TicketEspecial_1.maxCharLetraChica));
                ticket.AddFooterLine("SELLO SAT", "Chica", false, false, false);
                ticket.AddFooterLine(doctoBE.ITIMBRADOSELLOSAT, "Chica", false, false, false);

                ticket.AddFooterLine(new string(' ', TicketEspecial_1.maxCharLetraChica));
                ticket.AddFooterLine("SELLO DIGITAL DEL CFDI", "Chica", false, false, false);
                ticket.AddFooterLine(doctoBE.ITIMBRADOSELLOCFDI, "Chica", false, false, false);

                

                ticket.AddFooterLine("");
                ticket.AddFooterLine("       S U B T O T A L :" + SubTotal.ToString("N2").PadLeft(16), "Grande", false, false, false);


                foreach (DictionaryEntry entry in htIva)
                {

                    decimal tasaImp = (decimal)entry.Key;
                    decimal importeImp = (decimal)entry.Value;

                    ticket.AddFooterLine("");
                    ticket.AddFooterLine("       I V A      " +  tasaImp.ToString("##")+ "%  :" + importeImp.ToString("N2").PadLeft(16), "Grande", false, false, false);
                   
                }


                foreach (DictionaryEntry entry in htIeps)
                {

                    decimal tasaImp = (decimal)entry.Key;
                    decimal importeImp = (decimal)entry.Value;
                    


                    ticket.AddFooterLine("");
                    ticket.AddFooterLine("       I E P S  " + tasaImp.ToString("##.#") + "%  :" + importeImp.ToString("N2").PadLeft(16), "Grande", false, false, false);

                }
            




                ticket.AddFooterLine("");
                ticket.AddFooterLine("       T O T A L       :" + footerBE.ITOTAL.ToString("N2").PadLeft(16), "Grande", false, false, false);

                ticket.AddFooterLine("");
                if (footerBE.IPAGOEFECTIVO > 0)
                    ticket.AddFooterLine("       E F E C T I V O :" + (footerBE.IPAGOEFECTIVO).ToString("N2").PadLeft(16), "Grande", false, false, false);

                if (footerBE.IPAGOTARJETA > 0)
                    ticket.AddFooterLine("Pago Tarjeta:      " + footerBE.IPAGOTARJETA.ToString("N2").PadLeft(19), "Grande", false, false, false);
                if (footerBE.IPAGOCREDITO > 0)
                    ticket.AddFooterLine("Pago Credito:      " + footerBE.IPAGOCREDITO.ToString("N2").PadLeft(19), "Grande", false, false, false);
                if (footerBE.IPAGOCHEQUE > 0)
                    ticket.AddFooterLine("Pago Cheque:       " + footerBE.IPAGOCHEQUE.ToString("N2").PadLeft(19), "Grande", false, false, false);
                if (footerBE.IPAGOVALE > 0)
                    ticket.AddFooterLine("Pago Vale:         " + footerBE.IPAGOVALE.ToString("N2").PadLeft(19), "Grande", false, false, false);
                if (footerBE.IPAGOMONEDERO > 0)
                    ticket.AddFooterLine("Pago Monedero:     " + footerBE.IPAGOMONEDERO.ToString("N2").PadLeft(19), "Grande", false, false, false);
                if (footerBE.IPAGOTRANSFERENCIA > 0)
                    ticket.AddFooterLine("Pago Transferencia:" + footerBE.IPAGOTRANSFERENCIA.ToString("N2").PadLeft(19), "Grande", false, false, false);

                ticket.AddFooterLine("       C A M B I O     :" + footerBE.ICAMBIO.ToString("N2").PadLeft(16), "Grande", false, false, false);



                ticket.AddFooterLineInterlineado("Corto");

                ticket.AddFooterLine("");
                cantidadConLetra = "(" + Numalet.ToCardinal(footerBE.ITOTAL).ToUpper() + ")";
                ticket.AddFooterLine(cantidadConLetra.Substring((Ticket.maxChar * iXLetraRenglon)));
                ticket.AddFooterLine("");


                if(tienePlazoClaveT)
                {

                    ticket.AddFooterLine("VENTA REALIZADA POR CUENTA Y NOMBRE DE JORGE SALLE", "Chica", false, false, false);
                    ticket.AddFooterLine("CUERVO Y SUCESORES SA DE CV LEANDRO VALLE # 991 COLONIA", "Chica", false, false, false);
                    ticket.AddFooterLine("CENTRO GUADALAJARA JALISCO CP. 44100 RFC: JSC-781207-6Q3", "Chica", false, false, false);
                    ticket.AddFooterLine("EN CALIDAD DE COMISIONISTA", "Chica", false, false, false);
                }

                //footer
                if (!(bool)ConexionesBD.ConexionBD.CurrentParameters.isnull["IFOOTER"])
                {
                    if (ConexionesBD.ConexionBD.CurrentParameters.IFOOTER != "")
                    {
                        string[] splitFooter = ConexionesBD.ConexionBD.CurrentParameters.IFOOTER.Split(splitSeparator, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string strFtr in splitFooter)
                        {

                            string strBuffer = strFtr.Replace("[nombreVendedor]", headerBE.IVENDEDOR).Replace("[horaVenta]", doctoBE.IFECHAHORA.ToString("hh:mm:ss"));
                            ticket.AddFooterLine(strBuffer, "Chica", false, false, false);
                        }
                    }
                }

                AgregarLeyendaPlazoSiAplica(ref ticket, doctoBE.IPLAZOID);


                ticket.AddQRFooterLine("?re=" + m_empresa.IRFC + "&rr=" + clienteBE.m_PersonaBE.IRFC + "&tt=" + doctoBE.ITOTAL + "&id=" + doctoBE.ITIMBRADOUUID);



                ticket.AddFooterLineInterlineado("Normal");

                ticket.PrintTicketDirect(ConexionesBD.ConexionBD.currentPrinter);
            }
            catch (Exception ex)
            {

            }



            return "";
        }




        public static bool ImprimirTicketFacturaElectronica_Molde(
            long doctoId,
            FbTransaction m_fTrans,
            bool m_silentMode,
            ref string m_iComentario,
            string m_nombreFormaPago,
            CDOCTOPAGOBE m_doctoPago,
            CPARAMETROBE m_empresa,
            System.Data.DataRowCollection REP_FACTURAELECTRONICA_DETRows,
            CCLIENTEBE clienteBE,
            CPERSONABE usuarioBE,
            String referenciaCredito,
            string strCuentaPago 
            )
        {

            CultureInfo ci = CultureInfo.GetCultureInfo("en-US");
            NumberFormatInfo nfi = (NumberFormatInfo)ci.NumberFormat.Clone();
            //Now force thousand separator to be empty string
            nfi.NumberGroupSeparator = "";
            Hashtable htIva = new Hashtable();
            Hashtable htIeps = new Hashtable();


            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE m_Docto = new CDOCTOBE();
            m_Docto.IID = doctoId;
            m_Docto = doctoD.seleccionarDOCTO(m_Docto, null);
            if (m_Docto == null)
                return false; // "Error al obtener los datos del documento";


            //*-bool m_usaDatosDeEntregaCuandoExista = false;
            //*-string m_PREGUNTARDATOSENTREGA = "";

            //*-DefinirDatosEntrega(m_Docto, m_silentMode, ref m_iComentario, ref m_usaDatosDeEntregaCuandoExista, m_PREGUNTARDATOSENTREGA);
            //*-CSUCURSALBE sucursalDestino = TicketEspecial_1.getSucursalDestino(m_Docto);

            //tipo de cambio
            CMONEDABE monedaBE = new CMONEDABE();
            monedaBE.ICLAVE = "MN";

            if (m_Docto.IMONEDAID != DBValues._MONEDA_PESOS)
            {

                //tipo de cambio
                CMONEDAD monedaD = new CMONEDAD();
                monedaBE.IID = ((bool)m_Docto.isnull["IMONEDAID"] || m_Docto.IMONEDAID == 0) ? DBValues._MONEDA_PESOS : m_Docto.IMONEDAID;
                monedaBE = monedaD.seleccionarMONEDA(monedaBE, m_fTrans);
                if (monedaBE == null)
                {
                    monedaBE = new CMONEDABE();
                    monedaBE.ICLAVE = "MN";
                }
            }
            string moneda = monedaBE.ICLAVE;
            if (!moneda.Equals("MN"))
            {
                moneda = moneda + " T.C. " + monedaBE.ITIPOCAMBIO.ToString("#,##0.00");
            }


            //string strBuffer = "";


            try
            {

                decimal tipoCambio = (((bool)m_Docto.isnull["ITIPOCAMBIO"] || m_Docto.ITIPOCAMBIO == 0) ? 1 : m_Docto.ITIPOCAMBIO);


                //*-CCLIENTEBE clienteBE = new CCLIENTEBE();
                //*-CPERSONAD personaD = new CPERSONAD();
                //*-clienteBE.m_PersonaBE.IID = m_Docto.IPERSONAID;
                //*-clienteBE.m_PersonaBE = personaD.seleccionarPERSONA(clienteBE.m_PersonaBE, m_fTrans);


                //*-CPERSONABE usuarioBE = new CPERSONABE();
                //*-usuarioBE.IID = m_Docto.IVENDEDORID;
                //*-usuarioBE = personaD.seleccionarPERSONA(usuarioBE, m_fTrans);

                CMOVTOD movtoD = new CMOVTOD();
                ArrayList listIEPS = movtoD.DOCTOIEPSVIEW(m_Docto.IID, null);

                CTICKET_FOOTERD footerD = new CTICKET_FOOTERD();
                CTICKET_FOOTERBE footerBE = new CTICKET_FOOTERBE();
                footerBE.IDOCTOID = m_Docto.IID;
                footerBE = footerD.seleccionarTICKET_FOOTER(footerBE, false, null);




                ////////// forma de pago credito evitarla
                //*-String referenciaCredito = "";
                //*-string strCuentaPago = "N / A";
                //*m_nombreFormaPago = formaPagoTratandoEvitarPagoOtros(clienteBE, m_nombreFormaPago, m_doctoPago, ref referenciaCredito, m_fTrans);


                //*-if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_RECIBOELECTRONICO && m_doctoPago.ICUENTAPAGOCREDITO != null && m_doctoPago.ICUENTAPAGOCREDITO.Trim().Length > 0)
                //*-{
                //*- strCuentaPago = m_doctoPago.ICUENTAPAGOCREDITO;
                //*-}
                //*-else if (m_doctoPago.IFORMAPAGOID == DBValues._FORMA_PAGO_CHEQUE || m_doctoPago.IFORMAPAGOID == DBValues._FORMA_PAGO_TARJETA || m_doctoPago.IFORMAPAGOID == DBValues._FORMA_PAGO_TRANSFERENCIA)
                //*-{
                //*-strCuentaPago = m_doctoPago.IREFERENCIABANCARIA;
                //*-}
                //*-else if (m_doctoPago.IFORMAPAGOID == 4 && !referenciaCredito.Equals(""))
                //*-{
                //*-strCuentaPago = referenciaCredito;
                //*-}


                ////
                string bufferNumCSD = Path.GetFileName(m_empresa.ITIMBRADOARCHIVOCERTIFICADO);
                string subtotalfact = (clienteBE.m_PersonaBE.IDESGLOSEIEPS.Equals("S") && m_empresa.IDESGLOSEIEPS.Equals("S")) ? (m_Docto.ISUBTOTAL / tipoCambio).ToString("#,##0.00") : ((m_Docto.ISUBTOTAL + m_Docto.IIEPS) / tipoCambio).ToString("#,##0.00");
                decimal Total = m_Docto.ITOTAL - m_Docto.IIVARETENIDO - m_Docto.IISRRETENIDO;
                string totalEnLetra = Numalet.ToCardinal((Total / tipoCambio)).ToUpper();
                if (tipoCambio != 1)
                {
                    totalEnLetra = totalEnLetra.Replace("PESOS", "DOLARES");
                    totalEnLetra = totalEnLetra.Replace("M N", "USD");

                }

                string[] splitSeparator = new string[] { "\r\n" };



                TicketEspecial_1 ticket = new TicketEspecial_1();
                ticket.AddHeaderLine(" ");
                ticket.AddHeaderLine(new string('=', TicketEspecial_1.maxChar));

                ticket.AddQRHeaderLine("?re=" + m_empresa.IRFC + "&rr=" + clienteBE.m_PersonaBE.IRFC + "&tt=" + m_Docto.ITOTAL + "&id=" + m_Docto.ITIMBRADOUUID);

                ticket.AddHeaderLine("Factura: " + m_Docto.IFOLIOSAT.ToString("0") + m_Docto.ISERIESAT, true);



                ticket.AddHeaderLine(new string(' ', TicketEspecial_1.maxChar));
                ticket.AddHeaderLine((!(bool)m_empresa.isnull["IFISCALNOMBRE"]) ? m_empresa.IFISCALNOMBRE : m_empresa.INOMBRE, true);
                ticket.AddHeaderLine("R.F.C: " + m_empresa.IRFC, true);
                ticket.AddHeaderLine(m_empresa.IFISCALCALLE + " Ext. " + m_empresa.IFISCALNUMEROEXTERIOR
                                                            + (((bool)m_empresa.isnull["IFISCALNUMEROINTERIOR"] || m_empresa.IFISCALNUMEROINTERIOR.Trim() == "") ? "" : " , Int. " + m_empresa.IFISCALNUMEROINTERIOR), true);
                ticket.AddHeaderLine("Colona: " + m_empresa.IFISCALCOLONIA, true);
                ticket.AddHeaderLine("Ciudad: " + m_empresa.IFISCALMUNICIPIO + " " + m_empresa.IFISCALESTADO + " " + m_empresa.IFISCALCODIGOPOSTAL, true);

                ticket.AddHeaderLine(new string(' ', TicketEspecial_1.maxChar));
                ticket.AddHeaderLine(new string('-', TicketEspecial_1.maxChar));

                if (m_empresa.IUSARFISCALESENEXPEDICION == "S")
                {

                    ticket.AddHeaderLine("Expedido en: " + m_empresa.IFISCALMUNICIPIO + " " + m_empresa.IFISCALESTADO + " C.P. " + m_empresa.ICP, true);
                    ticket.AddHeaderLine((!(bool)m_empresa.isnull["IFISCALNOMBRE"]) ? m_empresa.IFISCALNOMBRE : m_empresa.INOMBRE, true);
                    ticket.AddHeaderLine(m_empresa.IFISCALCALLE + " Ext. " + m_empresa.IFISCALNUMEROEXTERIOR
                                                                + (((bool)m_empresa.isnull["IFISCALNUMEROINTERIOR"] || m_empresa.IFISCALNUMEROINTERIOR.Trim() == "") ? "" : " , Int. " + m_empresa.IFISCALNUMEROINTERIOR) + " Tel: (telefono de quien expide)", true);
                    ticket.AddHeaderLine("R.F.C. : " + m_empresa.IRFC, true);
                }
                else
                {

                    ticket.AddHeaderLine("Expedido en: " + m_empresa.ILOCALIDAD + " " + m_empresa.IESTADO + " C.P. " + m_empresa.IFISCALCODIGOPOSTAL, true);
                    ticket.AddHeaderLine((!(bool)m_empresa.isnull["IFISCALNOMBRE"]) ? m_empresa.IFISCALNOMBRE : m_empresa.INOMBRE, true);
                    ticket.AddHeaderLine(m_empresa.ICALLE + " Ext. " + m_empresa.INUMEROEXTERIOR
                                                          + (((bool)m_empresa.isnull["INUMEROINTERIOR"] || m_empresa.INUMEROINTERIOR.Trim() == "") ? "" : " , Int. " + m_empresa.INUMEROINTERIOR), true);
                    ticket.AddHeaderLine("R.F.C. : " + m_empresa.IRFC, true);
                }

                ticket.AddHeaderLine(new string(' ', TicketEspecial_1.maxChar));
                ticket.AddHeaderLine(new string('-', TicketEspecial_1.maxChar));

                ticket.AddHeaderLine("Met de pago: " + m_nombreFormaPago, true);
                ticket.AddHeaderLine("Cuen Pago: " + strCuentaPago, true);
                ticket.AddHeaderLine(" ");
                ticket.AddHeaderLine("FECHA FACTURA    : " + m_Docto.ITIMBRADOFECHAFACTURA.AddMinutes(-5).ToString("yyyy-MM-dd'T'HH:mm:ss"), true);
                ticket.AddHeaderLine("No. SERIE CER CSD: " + bufferNumCSD.Substring(0, bufferNumCSD.Length - 4).ToUpper(), true);
                ticket.AddHeaderLine("No. SERIE CER SAT: " + m_Docto.ITIMBRADOCERTSAT, true);
                ticket.AddHeaderLine("FACTURA: " + m_Docto.IFOLIOSAT.ToString("0") + " Serie: " + m_Docto.ISERIESAT + "  Venta " + m_Docto.IFOLIO.ToString("0"), true);

                ticket.AddHeaderLine(new string(' ', TicketEspecial_1.maxChar));
                ticket.AddHeaderLine(new string('-', TicketEspecial_1.maxChar));
                ticket.AddHeaderLine("CTE : " + clienteBE.m_PersonaBE.ICLAVE + " " + clienteBE.m_PersonaBE.INOMBRES + " " + clienteBE.m_PersonaBE.IAPELLIDOS, true);
                ticket.AddHeaderLine(clienteBE.m_PersonaBE.IDOMICILIO + " Ext. " + clienteBE.m_PersonaBE.INUMEROEXTERIOR
                                                                                 + (((bool)clienteBE.m_PersonaBE.isnull["INUMEROINTERIOR"] || clienteBE.m_PersonaBE.INUMEROINTERIOR.Trim() == "") ? "" : " , Int. " + clienteBE.m_PersonaBE.INUMEROINTERIOR), true);
                ticket.AddHeaderLine(clienteBE.m_PersonaBE.ICOLONIA, true);
                ticket.AddHeaderLine(clienteBE.m_PersonaBE.ICIUDAD + "  " + clienteBE.m_PersonaBE.IESTADO, true);
                ticket.AddHeaderLine("RFC:" + clienteBE.m_PersonaBE.IRFC, true);


                ticket.AddHeaderLine(new string(' ', TicketEspecial_1.maxChar));
                ticket.AddHeaderLine(new string('-', TicketEspecial_1.maxChar));
                ticket.AddHeaderLine("VENDEDOR: " + usuarioBE.INOMBRE, true);
                ticket.AddHeaderLine("TIPO PAGO: " + m_nombreFormaPago, true);

                ticket.AddHeaderLine(new string(' ', TicketEspecial_1.maxChar));
                ticket.AddHeaderLine(new string('=', TicketEspecial_1.maxChar));
                ticket.AddHeaderLine("CLAVE  CANTIDAD  P/U   IVA   IMPORTE", true);
                ticket.AddHeaderLine("DESCRIPCION               ");
                ticket.AddHeaderLine(new string('-', TicketEspecial_1.maxChar));
                ticket.AddHeaderLine(new string(' ', TicketEspecial_1.maxChar));



                if (m_empresa.IDESGLOSEIEPS.Equals("S") && clienteBE.m_PersonaBE.IDESGLOSEIEPS.Equals("S"))
                {
                    ticket.AddHeaderLine("CANTIDAD PRECIO   %IVA %IEPS IMPORTE   ");
                }
                else
                {
                    ticket.AddHeaderLine("CANTIDAD  PRECIO     %IVA   IMPORTE    ");
                }

                ticket.AddHeaderLine(new string('-', TicketEspecial_1.maxChar));


                foreach (System.Data.DataRow dr in REP_FACTURAELECTRONICA_DETRows)
                {



                    decimal porcentajeiva = 0;
                    decimal porcentajeieps = 0;
                    decimal iva = 0;
                    decimal ieps = 0;
                    decimal subtotal = 0;
                    decimal cantidad = 0;
                    decimal valorUnitario = 0;
                    string unidad = "PZA";
                    string productoClave = "";
                    string productoDescripcion = "";
                    string strPrecio = "";
                    string strImporte = "";
                    string strCantidad = "";
                    string strIva = "";
                    string strIeps = "";
                    if (dr["CANTIDAD"] != DBNull.Value)
                    {
                        cantidad = (decimal)dr["CANTIDAD"];
                        strCantidad = cantidad.ToString("N2", nfi);
                        //el.SetAttribute("cantidad", cantidad.ToString("N2", nfi));
                    }
                    else
                    {
                        continue;
                    }


                    if (dr["UNIDAD"] != DBNull.Value)
                        unidad = dr["UNIDAD"].ToString().Trim();
                    else
                        unidad = "PZA";


                    if (dr["PRODUCTOCLAVE"] != DBNull.Value)
                        productoClave = dr["PRODUCTOCLAVE"].ToString().Trim();
                    else
                        productoClave = "";


                    if (dr["PRODUCTODESCRIPCION"] != DBNull.Value)
                        productoDescripcion = dr["PRODUCTODESCRIPCION"].ToString().Trim();





                    if (dr["SUBTOTAL"] != DBNull.Value)
                    {
                        subtotal = (decimal)dr["SUBTOTAL"];
                    }


                    if (dr["PRECIO"] != DBNull.Value)
                    {
                        valorUnitario = (decimal)dr["PRECIO"];
                    }

                    if ((clienteBE.m_PersonaBE.IDESGLOSEIEPS.Equals("S") && m_empresa.IDESGLOSEIEPS.Equals("S")))
                    {

                        strPrecio = valorUnitario.ToString("N2", nfi);

                        strImporte = subtotal.ToString("N2", nfi);

                    }
                    else
                    {

                        if (dr["PORCENTAJEIEPS"] != DBNull.Value)
                        {
                            porcentajeieps = (decimal)dr["PORCENTAJEIEPS"];
                        }

                        if (dr["IEPS"] != DBNull.Value)
                        {
                            ieps = (decimal)dr["IEPS"];
                        }

                        strPrecio = (Math.Round((subtotal + ieps) / cantidad, 2)).ToString("N2", nfi);

                        strImporte = (subtotal + ieps).ToString("N2", nfi);
                    }




                    //calculating iva
                    if (dr["PORCENTAJEIVA"] != DBNull.Value)
                    {
                        porcentajeiva = (decimal)dr["PORCENTAJEIVA"];
                    }

                    if (dr["IVA"] != DBNull.Value)
                    {
                        iva = (decimal)dr["IVA"];
                    }

                    if (htIva.Contains(porcentajeiva))
                        htIva[porcentajeiva] = (decimal)htIva[porcentajeiva] + iva;
                    else
                        htIva[porcentajeiva] = iva;


                    if (m_empresa.IDESGLOSEIEPS.Equals("S") && clienteBE.m_PersonaBE.IDESGLOSEIEPS.Equals("S"))
                    {
                        //calculating ieps
                        if (dr["PORCENTAJEIEPS"] != DBNull.Value)
                        {
                            porcentajeieps = (decimal)dr["PORCENTAJEIEPS"];
                        }

                        if (dr["IEPS"] != DBNull.Value)
                        {
                            ieps = (decimal)dr["IEPS"];
                        }

                        if (htIeps.Contains(porcentajeieps))
                            htIeps[porcentajeieps] = (decimal)htIeps[porcentajeieps] + ieps;
                        else
                            htIeps[porcentajeieps] = ieps;
                    }

                    strIva = porcentajeiva.ToString("N2", nfi);
                    strIeps = porcentajeieps.ToString("N2", nfi);


                    if (m_empresa.IDESGLOSEIEPS.Equals("S") && clienteBE.m_PersonaBE.IDESGLOSEIEPS.Equals("S"))
                    {
                        ticket.AddHeaderLine(TicketEspecial_1.strFixedSize(strCantidad, 8, true) +
                                            TicketEspecial_1.strFixedSize(strPrecio, 10, true) +
                                            TicketEspecial_1.strFixedSize(strIva, 5, true) +
                                            TicketEspecial_1.strFixedSize(strIeps, 5, true) +
                                            TicketEspecial_1.strFixedSize(strImporte, 11, false), false);
                    }
                    else
                    {

                        ticket.AddHeaderLine(

                                            TicketEspecial_1.strFixedSize(strCantidad, 10, true) +
                                            TicketEspecial_1.strFixedSize(strPrecio, 11, true) +
                                            TicketEspecial_1.strFixedSize(strIva, 6, true) +
                                            TicketEspecial_1.strFixedSize(strImporte, 12, false), false);
                    }

                    ticket.AddHeaderLine(productoDescripcion, true);
                }


                ticket.AddHeaderLine(new string(' ', TicketEspecial_1.maxChar));
                ticket.AddHeaderLine(new string('-', TicketEspecial_1.maxChar));

                ticket.AddHeaderLine(new string(' ', TicketEspecial_1.maxChar));
                ticket.AddHeaderLine("CADENA ORIGINAL DEL COMPLEMENTO DE CERTIF DEL SAT", true);
                ticket.AddHeaderLine("||1.0|" + m_Docto.ITIMBRADOUUID + "|" + m_Docto.ITIMBRADOFECHA + "|" + m_Docto.ITIMBRADOSELLOCFDI + "|" + m_Docto.ITIMBRADOCERTSAT + "||", true);

                ticket.AddHeaderLine(new string(' ', TicketEspecial_1.maxChar));
                ticket.AddHeaderLine("SELLO SAT", true);
                ticket.AddHeaderLine(m_Docto.ITIMBRADOSELLOSAT, true);

                ticket.AddHeaderLine(new string(' ', TicketEspecial_1.maxChar));
                ticket.AddHeaderLine("SELLO DIGITAL DEL CFDI", true);
                ticket.AddHeaderLine(m_Docto.ITIMBRADOSELLOCFDI, true);

                ticket.AddHeaderLine(new string(' ', TicketEspecial_1.maxChar));
                ticket.AddHeaderLine(TicketEspecial_1.strFixedSize("SUB TOTAL: ", 18, false) + TicketEspecial_1.strFixedSize(subtotalfact, 20, false), true);



                foreach (DictionaryEntry entry in htIva)
                {

                    decimal tasaImp = (decimal)entry.Key;
                    decimal importeImp = (decimal)entry.Value;

                    ticket.AddHeaderLine(TicketEspecial_1.strFixedSize("IVA", 9, false) +
                                        TicketEspecial_1.strFixedSize("(" + tasaImp.ToString("N2", nfi), 6, false) + "%):" +
                                        TicketEspecial_1.strFixedSize(importeImp.ToString("N2", nfi), 20, false));
                }


                foreach (DictionaryEntry entry in htIeps)
                {

                    decimal tasaImp = (decimal)entry.Key;
                    decimal importeImp = (decimal)entry.Value;

                    ticket.AddHeaderLine(TicketEspecial_1.strFixedSize("IEPS", 9, false) +
                                        TicketEspecial_1.strFixedSize(tasaImp.ToString("N2", nfi), 6, false) + "%" +
                                        TicketEspecial_1.strFixedSize(importeImp.ToString("N2", nfi), 19, false));
                }



                ticket.AddHeaderLine(TicketEspecial_1.strFixedSize("TOTAL: ", 18, false) + TicketEspecial_1.strFixedSize((Total / tipoCambio).ToString("#,##0.00"), 20, false), true);

                ticket.AddHeaderLine(new string(' ', TicketEspecial_1.maxChar));
                ticket.AddHeaderLine(new string('-', TicketEspecial_1.maxChar));

                if (footerBE != null)
                {

                    if (footerBE.IPAGOTARJETA > 0)
                        ticket.AddHeaderLine(TicketEspecial_1.strFixedSize("Pago Tarjeta: ", 18, false) + TicketEspecial_1.strFixedSize(footerBE.IPAGOTARJETA.ToString("N2"), 20, false), false);
                    if (footerBE.IPAGOCREDITO > 0)
                        ticket.AddHeaderLine(TicketEspecial_1.strFixedSize("Pago Credito: ", 18, false) + TicketEspecial_1.strFixedSize(footerBE.IPAGOCREDITO.ToString("N2"), 20, false), false);
                    if (footerBE.IPAGOCHEQUE > 0)
                        ticket.AddHeaderLine(TicketEspecial_1.strFixedSize("Pago Cheque: ", 18, false) + TicketEspecial_1.strFixedSize(footerBE.IPAGOCHEQUE.ToString("N2"), 20, false), false);
                    if (footerBE.IPAGOVALE > 0)
                        ticket.AddHeaderLine(TicketEspecial_1.strFixedSize("Pago Vale: ", 18, false) + TicketEspecial_1.strFixedSize(footerBE.IPAGOVALE.ToString("N2"), 20, false), false);
                    if (footerBE.IPAGOMONEDERO > 0)
                        ticket.AddHeaderLine(TicketEspecial_1.strFixedSize("Pago Monedero: ", 18, false) + TicketEspecial_1.strFixedSize(footerBE.IPAGOMONEDERO.ToString("N2"), 20, false), false);
                    if (footerBE.IPAGOTRANSFERENCIA > 0)
                        ticket.AddHeaderLine(TicketEspecial_1.strFixedSize("Pago Transferencia: ", 18, false) + TicketEspecial_1.strFixedSize(footerBE.IPAGOTRANSFERENCIA.ToString("N2"), 20, false), false);
                    if (footerBE.IPAGOEFECTIVO > 0)
                        ticket.AddHeaderLine(TicketEspecial_1.strFixedSize("Pago Efectivo: ", 18, false) + TicketEspecial_1.strFixedSize(footerBE.IPAGOEFECTIVO.ToString("N2"), 20, false), false);

                    ticket.AddHeaderLine(TicketEspecial_1.strFixedSize("Cambio:", 18, false) + TicketEspecial_1.strFixedSize(footerBE.ICAMBIO.ToString("N2"), 20, false), false);
                }

                ticket.AddHeaderLine(new string('-', TicketEspecial_1.maxChar));
                ticket.AddHeaderLine(new string(' ', TicketEspecial_1.maxChar));


                ticket.AddHeaderLine("(" + totalEnLetra + ")", true);
                ticket.AddHeaderLine(new string(' ', TicketEspecial_1.maxChar));
                ticket.AddHeaderLine(new string('-', TicketEspecial_1.maxChar));

                if (!(bool)m_empresa.isnull["IFOOTER"])
                {
                    if (m_empresa.IFOOTER != "")
                    {
                        string[] splitFooter = m_empresa.IFOOTER.Split(splitSeparator, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string strFtr in splitFooter)
                        {
                            ticket.AddHeaderLine(strFtr, true);
                        }
                    }
                }

                ticket.AddHeaderLine(new string(' ', TicketEspecial_1.maxChar));
                ticket.AddHeaderLine("FORMA DE PAGO: " + (clienteBE.m_PersonaBE.IPAGOPARCIALIDADES.Equals("S") ? "PAGO EN PARCIALIDADES" : "PAGO EN UNA SOLA EXHIBICION"), true);
                ticket.AddHeaderLine(new string(' ', TicketEspecial_1.maxChar));
                ticket.AddHeaderLine("REGIMEN TRIBUTARIO: " + m_empresa.IFISCALREGIMEN, true);
                ticket.AddHeaderLine(new string(' ', TicketEspecial_1.maxChar));
                ticket.AddHeaderLine("ESTE DOCUMENTO ES UNA REPRESENTACION IMPRESA DE UN CFDI", true);

                ticket.AddHeaderLine(new string(' ', TicketEspecial_1.maxChar));
                ticket.AddHeaderLine("Lo atendio: " + usuarioBE.ICLAVE + " hora: " + m_Docto.IFECHAHORA.ToString("HH:mm:ss"), true);




                ticket.AddFooterLine("");

                String printer = ConexionesBD.ConexionBD.currentPrinter;//TicketEspecial_1.GetReceiptPrinter(m_empresa);//"IposPrinter3";//TicketEspecial_1.GetReceiptPrinter(this.m_compania);
                if (printer != "")
                    ticket.PrintTicketDirect(printer);




                return true;

            }
            catch (Exception ex)
            {

                if (!m_silentMode)
                {
                    MessageBox.Show("Error al procesar el pdf " + ex.Message + ex.StackTrace);
                }
                else
                {
                    m_iComentario = "Error al procesar el pdf " + ex.Message + ex.StackTrace;
                }
                return false;
            }





        }

        

        public static string ImprimirTicket_Molde(long doctoId, long lOpcion1,  bool enDolar)
        {

            CUSUARIOSD usuariosD = new CUSUARIOSD();
            Boolean usuarioTienePermisoDesgloseKit = usuariosD.UsuarioTienePermisos((int)ConexionesBD.ConexionBD.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null);

            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE doctoBE = new CDOCTOBE();
            doctoBE.IID = doctoId;
            doctoBE = doctoD.seleccionarDOCTO(doctoBE, null);
            if (doctoBE == null)
                return "Error al obtener los datos del documento";

            

            string bufferLine = "";

            string tipoImpresionDetalle = ((int)tipoImpresionItem.i_unalinea).ToString("N0");
            decimal dCuentaCantidades = 0;

            try
            {

                CTICKET_DETAILD detailD = new CTICKET_DETAILD();
                CTICKET_FOOTERD footerD = new CTICKET_FOOTERD();
                CTICKET_HEADERD headerD = new CTICKET_HEADERD();
                CTICKET_FOOTERBE footerBE = new CTICKET_FOOTERBE();
                CTICKET_HEADERBE headerBE = new CTICKET_HEADERBE();
                CTICKET_DETAILBE[] ListaDetalles = detailD.seleccionarTICKET_DETAIL(doctoId, ((lOpcion1 == Ticket._OPCION_IMPRESION_RECARGAS) ? true : false), null);
                CSUCURSALBE sucursalBE = new CSUCURSALBE();



                string importeDescuento = "";

                string strReturn = "";


                string[] splitSeparator = new string[] { "\r\n" };

                int iXLetraRenglon = 0;
                string cantidadConLetra;

                footerBE.IDOCTOID = doctoId;
                headerBE.IDOCTOID = doctoId;

                headerBE = headerD.seleccionarTICKET_HEADER(headerBE, null);
                footerBE = footerD.seleccionarTICKET_FOOTER(footerBE, ((lOpcion1 == Ticket._OPCION_IMPRESION_RECARGAS) ? true : false), null);


                TicketEspecial_1 ticket = new TicketEspecial_1();
                

                //si es una cancelacion
                if (headerBE.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_CANCELADA)
                    ticket.AddHeaderLine("CANCELACION DEL TICKET : " + headerBE.ITICKET);


                //header deacuerdo al tipo
                switch (headerBE.ITIPODOCTOID)
                {
                    case DBValues._DOCTO_TIPO_TRASPASO_REC:
                        {
                            sucursalBE = DatosSucursal(headerBE.ISUCURSALTID);
                            switch (lOpcion1)
                            {
                                case Ticket._OPCION_IMPRESION_TRASLADO_DEVOLUCION:
                                    ticket.AddHeaderLine("DEVOLUCION TRASLADO");
                                    break;
                                default:
                                    ticket.AddHeaderLine("RECEPCION TRASLADO");
                                    break;

                            }

                        }
                        break;


                    case DBValues._DOCTO_TIPO_TRASPASO_ENVIO_DEVO:
                        {
                            ticket.AddHeaderLine("REC. DE DEVOLUCION DE TRASLADO");
                        }
                        break;

                    case DBValues._DOCTO_TIPO_PEDIDO_ENVIO_DEVO:
                        {
                            ticket.AddHeaderLine("REC. DE DEVOLUCION DE PEDIDO");
                        }
                        break;

                    case DBValues._DOCTO_TIPO_COMPRA:
                        {
                            bufferLine = "";
                            switch (lOpcion1)
                            {
                                case Ticket._OPCION_IMPRESION_COMPRA_RECEPCION:
                                    //ticket.AddHeaderLine("RECEPCION COMPRA");
                                    bufferLine = "RECEPCION COMPRA";
                                    break;
                                case Ticket._OPCION_IMPRESION_COMPRA_DEVOLUCION:
                                    //ticket.AddHeaderLine("DEVOLUCION COMPRA");
                                    bufferLine = "DEVOLUCION COMPRA";
                                    break;
                                case Ticket._OPCION_IMPRESION_COMPRA:
                                    //ticket.AddHeaderLine("COMPRA");
                                    bufferLine = "COMPRA";
                                    break;
                                case Ticket._OPCION_IMPRESION_TRASLADO_RECEPCION:
                                    bufferLine = "RECEPCION DE TRASLADO";
                                    break;
                                case Ticket._OPCION_IMPRESION_TRASLADO_DEVOLUCION:
                                    bufferLine = "DEVOLUCION DE TRASLADO";
                                    break;

                            }
                            switch (headerBE.IORIGENFISCALID)
                            {
                                case 3:
                                    bufferLine += " DE REMISION";
                                    break;
                                default:
                                    bufferLine += " DE FACTURA";
                                    break;

                            }


                            ticket.AddHeaderLine(bufferLine);


                        }
                        break;

                    case DBValues._DOCTO_TIPO_TRASPASO_ENVIO:
                        {

                            sucursalBE = DatosSucursal(headerBE.ISUCURSALTID);
                            ticket.AddHeaderLine("TRASLADO");
                        }
                        break;


                    case DBValues._DOCTO_TIPO_PEDIDO_TRASPASO_SALIDA:
                        {

                            sucursalBE = DatosSucursal(headerBE.ISUCURSALTID);
                            ticket.AddHeaderLine("TRASPASO A SUCURSAL");
                        }
                        break;
                    case DBValues._DOCTO_TIPO_COMPRA_DEVO:
                        {
                            ticket.AddHeaderLine("DEVOLUCION DE COMPRA");
                        }
                        break;

                    case DBValues._DOCTO_TIPO_VENTA:
                        {
                            if (!(bool)headerBE.isnull["ISUBTIPODOCTOID"] && headerBE.ISUBTIPODOCTOID == 8)
                            {
                                sucursalBE = DatosSucursal(headerBE.ISUCURSALTID);
                                ticket.AddHeaderLine("TRASPASO A SUCURSAL");
                            }
                            else
                            {

                                if (headerBE.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_BORRADOR)
                                {
                                    ticket.AddHeaderLine("NOTA DE VENTA","Grande2", true, true, false);
                                }
                                else
                                {
                                    ticket.AddHeaderLine("COTIZACION");
                                }
                            }


                            //Nombre de farmacia
                            AddNombreDeFarmacia(ref ticket, headerBE);



                            ticket.AddHeaderLine("");
                            ticket.AddHeaderLine("");

                            ticket.AddHeaderLineCodigoBarras("manuel llamas");


                            ticket.AddHeaderLine("");
                            ticket.AddHeaderLine("");

                            ticket.AddHeaderLinePredefinedImage();

                            ticket.AddHeaderLine("");
                            ticket.AddHeaderLine("");


                            //custom header
                            /*if (!(bool)ConexionesBD.ConexionBD.CurrentParameters.isnull["IHEADER"])
                            {
                                if (ConexionesBD.ConexionBD.CurrentParameters.IHEADER != "")
                                {
                                    string[] splitHeader = ConexionesBD.ConexionBD.CurrentParameters.IHEADER.Split(splitSeparator, StringSplitOptions.RemoveEmptyEntries);
                                    foreach (string strHdr in splitHeader)
                                    {
                                        ticket.AddHeaderLine(strHdr);
                                    }
                                }
                            }*/
                            break;
                        }


                    case DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO:
                        {

                            ticket.AddHeaderLine("NOTA DE CREDITO");

                            //Nombre de farmacia
                            AddNombreDeFarmacia(ref ticket, headerBE);
                            break;
                        }


                    case DBValues._DOCTO_TIPO_VENTAAPARTADO:
                        {

                            ticket.AddHeaderLine("Operación: Apartado de mercancía");
                            ticket.AddHeaderLine("");

                            //Nombre de farmacia
                            AddNombreDeFarmacia(ref ticket, headerBE);
                            break;
                        }


                    default:
                        break;

                }


                if (!(headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA || headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_DEVOLUCION
                    || headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA_DEVO || headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO
                    || headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTAAPARTADO))
                {
                    ticket.AddHeaderLine("FOLIO NO.: " + headerBE.ITICKET);
                }

                ticket.AddHeaderLine("LUGAR Y FECHA DE EXPEDICION: ");

                try
                {
                    ticket.AddHeaderLine(headerBE.ICIUDAD.Trim() + " , " + headerBE.IESTADO.Trim());
                }
                catch
                {
                }


                ticket.AddHeaderLine("Fecha: " + DateTime.Now.ToShortDateString() + " Hora: " + DateTime.Now.ToShortTimeString());



                if (headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA || headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_DEVOLUCION
                    || headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA_DEVO || headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO
                    || headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTAAPARTADO)
                {
                    //custom header
                    ticket.AddHeaderLine(new string('-', Ticket.maxChar));

                    if (!(bool)ConexionesBD.ConexionBD.CurrentParameters.isnull["IHEADER"])
                    {
                        if (ConexionesBD.ConexionBD.CurrentParameters.IHEADER != "")
                        {
                            string[] splitHeader = ConexionesBD.ConexionBD.CurrentParameters.IHEADER.Split(splitSeparator, StringSplitOptions.RemoveEmptyEntries);
                            foreach (string strHdr in splitHeader)
                            {
                                ticket.AddHeaderLine(strHdr);
                            }
                        }
                    }
                }

                AddDatosTienda(ref ticket, headerBE);




                if (headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA || headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_DEVOLUCION
                    || headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO || headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTAAPARTADO)
                {
                    ticket.AddHeaderLine(new string('-', Ticket.maxChar));
                    bufferLine = "";
                    ticket.AddHeaderLine("Numero: " + bufferLine.Substring(0, Math.Min(12, bufferLine.Length)).PadRight(12) + " Fecha: " + headerBE.IFECHA.ToString("dd/MM/yyyy"));
                }


                ticket.AddHeaderLine(new string('-', Ticket.maxChar));



                CALMACENBE almacenBE = new CALMACENBE();
                CALMACEND almacenD = new CALMACEND();

                if (ConexionesBD.ConexionBD.CurrentParameters.IMANEJAALMACEN.Equals("S"))
                {
                    almacenBE.IID = headerBE.IALMACENID;
                    almacenBE = almacenD.seleccionarALMACEN(almacenBE, null);

                    if (almacenBE != null)
                    {
                        ticket.AddHeaderLine("DEL ALMACEN : " + almacenBE.ICLAVE);
                        ticket.AddHeaderLine("ALMACEN FUENTE: " + almacenBE.INOMBRE);
                    }
                }


                //
                switch (headerBE.ITIPODOCTOID)
                {
                    case DBValues._DOCTO_TIPO_TRASPASO_REC:
                        {
                            if (sucursalBE != null)
                            {
                                ticket.AddHeaderLine("TRASLADO DE SUCURSAL : " + sucursalBE.ICLAVE);
                                ticket.AddHeaderLine("SUCURSAL FUENTE: " + sucursalBE.INOMBRE);
                            }
                            tipoImpresionDetalle = ((int)tipoImpresionItem.i_doslineas).ToString("N0");
                        }
                        break;

                    case DBValues._DOCTO_TIPO_TRASPASO_ENVIO:
                    case DBValues._DOCTO_TIPO_PEDIDO_TRASPASO_SALIDA:
                        {

                            if (sucursalBE != null)
                            {
                                ticket.AddHeaderLine("TRASLADO A SUCURSAL : " + sucursalBE.ICLAVE);
                                ticket.AddHeaderLine("SUCURSAL DESTINO: " + sucursalBE.INOMBRE);
                            }
                        }
                        tipoImpresionDetalle = ((int)tipoImpresionItem.i_treslineas).ToString("N0");
                        break;


                    case DBValues._DOCTO_TIPO_TRASPASO_ENVIO_DEVO:
                        {
                            if (sucursalBE != null)
                            {
                                ticket.AddHeaderLine("REC. DE DEVO. TRASL. SUC. : " + sucursalBE.ICLAVE);
                                ticket.AddHeaderLine("SUCURSAL FUENTE: " + sucursalBE.INOMBRE);
                            }
                            tipoImpresionDetalle = ((int)tipoImpresionItem.i_doslineas).ToString("N0");
                        }
                        break;



                    case DBValues._DOCTO_TIPO_PEDIDO_ENVIO_DEVO:
                        {
                            if (sucursalBE != null)
                            {
                                ticket.AddHeaderLine("REC. DE DEVO. PEDIDO SUC. : " + sucursalBE.ICLAVE);
                                ticket.AddHeaderLine("SUCURSAL FUENTE: " + sucursalBE.INOMBRE);
                            }
                            tipoImpresionDetalle = ((int)tipoImpresionItem.i_doslineas).ToString("N0");
                        }
                        break;

                    case DBValues._DOCTO_TIPO_VENTA:
                        {

                            if (!(bool)headerBE.isnull["ISUBTIPODOCTOID"] && headerBE.ISUBTIPODOCTOID == 8 && sucursalBE != null)
                            {
                                ticket.AddHeaderLine("TRASLADO A SUCURSAL : " + sucursalBE.ICLAVE);
                                ticket.AddHeaderLine("SUCURSAL DESTINO: " + sucursalBE.INOMBRE);
                            }

                            ticket.AddHeaderLine("VENTA DE MOSTRADOR");
                            if (headerBE.IPERSONAID != DBValues._CLIENTEMOSTRADOR)
                            {
                                CPERSONABE clienteBE = DatosPersona(headerBE.IPERSONAID);
                                if (clienteBE != null)
                                {
                                    AddDatosCliente(ref ticket, clienteBE);
                                }

                            }

                            tipoImpresionDetalle = ((int)tipoImpresionItem.i_doslineas).ToString("N0");
                        }
                        break;

                    case DBValues._DOCTO_TIPO_VENTAAPARTADO:
                        {
                            ticket.AddHeaderLine("CLIENTE DE APARTADO");
                            CPERSONAAPARTADOD personaApartadoD = new CPERSONAAPARTADOD();
                            CPERSONAAPARTADOBE personaApartadoBE = new CPERSONAAPARTADOBE();
                            personaApartadoBE.IID = headerBE.IPERSONAAPARTADOID;
                            personaApartadoBE = personaApartadoD.seleccionarPERSONAAPARTADO(personaApartadoBE, null);
                            if (personaApartadoBE != null)
                            {

                                AddDatosClienteApartado(ref ticket, personaApartadoBE);
                            }
                            //tipoImpresionDetalle = ((int)tipoImpresionItem.i_doslineas).ToString("N0");
                        }
                        break;
                    case DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO:
                        {
                            ticket.AddHeaderLine("");
                            tipoImpresionDetalle = ((int)tipoImpresionItem.i_doslineas).ToString("N0");
                            
                            CPERSONABE clienteBE = DatosPersona(headerBE.IPERSONAID);
                            if (clienteBE != null)
                            {
                                    AddDatosCliente(ref ticket, clienteBE);
                            }

                        }
                        break;


                    case DBValues._DOCTO_TIPO_COMPRA:
                    case DBValues._DOCTO_TIPO_COMPRA_DEVO:
                        {
                            if (lOpcion1 == Ticket._OPCION_IMPRESION_COMPRA)
                            {
                                CPERSONABE proveedorBE = DatosPersona(headerBE.IPERSONAID);
                                if (proveedorBE != null)
                                {
                                    AddDatosDeProveedor(ref ticket, proveedorBE);

                                    if (headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA)
                                    {
                                        ticket.AddHeaderLine("#DOCUMENTO: " + headerBE.IREFERENCIA);

                                        if (!(bool)footerBE.isnull["IFECHAFACTURA"])
                                        {
                                            ticket.AddHeaderLine("FECHA FACTURA : " + footerBE.IFECHAFACTURA.ToString("dd/MM/yyyy"));
                                        }
                                    }


                                }
                            }
                            tipoImpresionDetalle = ((int)tipoImpresionItem.i_doslineas).ToString("N0");

                        }
                        break;



                    case DBValues._DOCTO_TIPO_TRASPASO_ALMACEN:
                        {

                            CALMACENBE almacenBEDestino = new CALMACENBE();
                            almacenBEDestino.IID = headerBE.IALMACENID;
                            almacenBEDestino = almacenD.seleccionarALMACEN(almacenBEDestino, null);

                            if (almacenBEDestino != null)
                            {
                                ticket.AddHeaderLine("TRASPASO AL ALMACEN : " + almacenBEDestino.ICLAVE);
                                ticket.AddHeaderLine("ALMACEN DESTINO: " + almacenBEDestino.INOMBRE);
                            }
                        }
                        tipoImpresionDetalle = ((int)tipoImpresionItem.i_treslineas).ToString("N0");
                        break;



                    default:
                        break;

                }


                ticket.AddHeaderLine(new string('-', Ticket.maxChar));
                bufferLine = (headerBE.IVENDEDOR == null) ? "" : headerBE.IVENDEDOR;
                if (headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA || headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_DEVOLUCION
                    || headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA_DEVO || headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO
                    || headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTAAPARTADO)
                {
                    ticket.AddHeaderLine("Cajero: " + bufferLine.Substring(0, Math.Min(12, bufferLine.Length)).PadRight(12) + " FOLIO NO.: " + headerBE.ITICKET);
                }
                else
                {
                    ticket.AddHeaderLine("Cajero: " + bufferLine);
                }


                if (headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA_DEVO)
                {
                    bufferLine = headerBE.IREFERENCIA;
                    ticket.AddHeaderLine("Numero: " + bufferLine.Substring(0, Math.Min(12, bufferLine.Length)).PadRight(12) + " Doc.: " + ((headerBE.IORIGENFISCALID == 3) ? "Remision" : "Factura"));

                    if (!(bool)headerBE.isnull["IDOCTOREF_FOLIO"])
                        ticket.AddHeaderLine("Del folio de compra: " + headerBE.IDOCTOREF_FOLIO);
                }


                if (headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO)
                {
                    if (!(bool)headerBE.isnull["IDOCTOREF_FOLIO"])
                        ticket.AddHeaderLine("Del folio de venta: " + headerBE.IDOCTOREF_FOLIO);
                }



                if (headerBE.IRUTAEMBARQUECLAVE != null && headerBE.IRUTAEMBARQUECLAVE.Trim().Length > 0)
                {

                    ticket.AddHeaderLine("Ruta embarque : " + headerBE.IRUTAEMBARQUECLAVE);
                }


                //if (headerBE.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_CANCELADA)
                //    ticket.AddHeaderLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                //else
                //    ticket.AddHeaderLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());


                if (enDolar)
                {
                    ticket.AddHeaderLine(new string('-', Ticket.maxChar));
                    ticket.AddHeaderLine("      EN DOLARES     ");
                    ticket.AddHeaderLine(new string('-', Ticket.maxChar));
                }

                ticket.AddHeaderLine(new string('=', Ticket.maxChar));

                ticket.AddHeaderLine("DESCRIPCION               ");

                if (headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA)
                    ticket.AddHeaderLine("CANTIDAD    COSTO       %IVA    IMPORTE");
                else
                    ticket.AddHeaderLine("CANTIDAD    PRECIO      %IVA    IMPORTE");

                ticket.AddHeaderLine(new string('-', Ticket.maxChar));

                decimal dCantidad = 0, dSubTotalItem = 0, dIvaItem = 0, dDescuentoItem = 0, dIepsItem = 0;
                decimal dSubTotalSumarizado = 0, dIvaSumarizado = 0, dIepsSumarizado = 0;
                decimal dDescuentoValeSumarizado = 0;
                decimal dTotalItem = 0, dPrecioConImpItem = 0;
                decimal dTotalSumarizado = 0;

                long lastMovtoId = 0;


                foreach (CTICKET_DETAILBE detailItem in ListaDetalles)
                {




                    //si estas en una impresion de compra, cuando estes imprimiendo las cantidaes recibidas ignora cuando no hayas recibido y
                    // lo mismo cuando estes imprimiendo devueltas, ignora cuando no haya devueltas
                    if (((headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA || headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_REC || headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO_DEVO || headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_PEDIDO_ENVIO_DEVO) && lOpcion1 == Ticket._OPCION_IMPRESION_COMPRA_RECEPCION && detailItem.ICANTIDAD == 0) ||
                       ((headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA || headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_REC || headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO_DEVO || headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_PEDIDO_ENVIO_DEVO) && lOpcion1 == Ticket._OPCION_IMPRESION_COMPRA_DEVOLUCION && detailItem.IFALTANTE == 0))
                        continue;

                    dCantidad = detailItem.ICANTIDAD;
                    dSubTotalItem = detailItem.ISUBTOTAL;



                    //si estamos en devolucion de compras , la cantidad esta en el campo "faltante" y el subtotal se multiplica x la cantidad faltante
                    if ((headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA || headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_REC || headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO_DEVO || headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_PEDIDO_ENVIO_DEVO || headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_PEDIDO_ENVIO_DEVO))
                    {
                        switch (lOpcion1)
                        {
                            case Ticket._OPCION_IMPRESION_COMPRA_RECEPCION:
                                dSubTotalItem = detailItem.ICANTIDAD * detailItem.IPRECIO;
                                break;
                            case Ticket._OPCION_IMPRESION_COMPRA_DEVOLUCION:
                                dCantidad = detailItem.IFALTANTE;
                                dSubTotalItem = detailItem.IFALTANTE * detailItem.IPRECIO;
                                break;
                            case Ticket._OPCION_IMPRESION_COMPRA:
                                dCantidad = detailItem.ICANTIDADNOMINAL;
                                dSubTotalItem = detailItem.ISUBTOTAL;
                                break;
                            case Ticket._OPCION_IMPRESION_TRASLADO_RECEPCION:
                                dSubTotalItem = detailItem.ICANTIDADSURTIDA * (detailItem.ISUBTOTAL / (detailItem.ICANTIDADNOMINAL == 0 ? 1 : detailItem.ICANTIDADNOMINAL));
                                break;
                            case Ticket._OPCION_IMPRESION_TRASLADO_DEVOLUCION:
                                dCantidad = detailItem.IFALTANTE;
                                dSubTotalItem = detailItem.IFALTANTE * (detailItem.ISUBTOTAL / (detailItem.ICANTIDADNOMINAL == 0 ? 1 : detailItem.ICANTIDADNOMINAL));
                                break;


                        }



                    }


                    dIvaItem = dSubTotalItem *
                            (ConexionesBD.ConexionBD.CurrentParameters.IDESGLOSEIEPS != null && ConexionesBD.ConexionBD.CurrentParameters.IDESGLOSEIEPS == "S" ? (1 + (detailItem.ITASAIEPS / 100)) : 1) *
                            (detailItem.IIVA / 100);
                    dIepsItem = dSubTotalItem * (ConexionesBD.ConexionBD.CurrentParameters.IDESGLOSEIEPS != null && ConexionesBD.ConexionBD.CurrentParameters.IDESGLOSEIEPS == "S" ? ((detailItem.ITASAIEPS / 100)) : 1);
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

                            if (lOpcion1 == Ticket._OPCION_IMPRESION_TRASLADO_RECEPCION || lOpcion1 == Ticket._OPCION_IMPRESION_TRASLADO_DEVOLUCION ||
                                lOpcion1 == Ticket._OPCION_IMPRESION_COMPRA_RECEPCION || lOpcion1 == Ticket._OPCION_IMPRESION_COMPRA_DEVOLUCION)
                            {

                                ticket.AddItem(dCantidad.ToString("N3"),
                                                (detailItem.IES_COMODIN.Equals("S") ? detailItem.IDESCRIPCION1 + " " + detailItem.IDESCRIPCION2 + " " + detailItem.IDESCRIPCION3 : detailItem.IDESCRIPCION1),
                                                dTotalItem.ToString("N2"),
                                                 dPrecioConImpItem.ToString("N2"),
                                                "-",
                                                 detailItem.ILOTE,
                                                 ((bool)detailItem.isnull["IFECHAVENCE"]) ? "" : detailItem.IFECHAVENCE.ToString("dd/MM/yy"),
                                                "",
                                                 ((bool)detailItem.isnull["ITIPORECARGA"]) ? "" : detailItem.ITIPORECARGA,
                                                tipoImpresionDetalle,
                                                (lOpcion1 == Ticket._OPCION_IMPRESION_TRASLADO_DEVOLUCION || lOpcion1 == Ticket._OPCION_IMPRESION_COMPRA_DEVOLUCION) ? detailItem.IMOTIVODEVOLUCION : "",
                                                ((bool)detailItem.isnull["IPRODUCTOCLAVE"]) ? "" : detailItem.IPRODUCTOCLAVE,
                                                ((bool)detailItem.isnull["ICAJAS"]) ? "" : detailItem.ICAJAS.ToString("N0"),
                                                ((bool)detailItem.isnull["IBOTELLAS"]) ? "" : detailItem.IPIEZAS.ToString("N0"));

                            }
                            else
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

                                ticket.AddItem(detailItem.IESKIT != null && detailItem.IESKIT.Equals("S") && usuarioTienePermisoDesgloseKit ? "" : dCantidad.ToString("N3"),
                                                 (detailItem.IES_COMODIN.Equals("S") ? detailItem.IDESCRIPCION1 + " " + detailItem.IDESCRIPCION2 + " " + detailItem.IDESCRIPCION3 : detailItem.IDESCRIPCION1),
                                                 enDolar ? detailItem.IIMPORTEENDOLAR.ToString("N3") : ((headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA) ? (dTotal).ToString("N2") : dTotal.ToString("N2")),
                                                 enDolar ? detailItem.ICOSTOENDOLAR.ToString("N3") : dPrecioConIva.ToString("N2"),
                                                 enDolar ? "" : detailItem.IIVA.ToString("N2"),
                                                 detailItem.ILOTE,
                                                 ((bool)detailItem.isnull["IFECHAVENCE"]) ? "" : detailItem.IFECHAVENCE.ToString("dd/MM/yy"),
                                                "",
                                                 detailItem.ITIPORECARGA,
                                                tipoImpresionDetalle,
                                                nota,
                                                "",
                                                "",
                                                "");





                                // Manejo de EMida (recargas y pago de servicios) Inicia

                                if (!(bool)headerBE.isnull["ISUBTIPODOCTOID"] && headerBE.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_PAGOSERVICIO)
                                {
                                    ticket.AddItem("",
                                                    "COMISION",
                                                     detailItem.IEMIDACOMISION.ToString("N2"),
                                                    "",
                                                    "-",
                                                    "",
                                                    "",
                                                    "",
                                                    "",
                                                    tipoImpresionDetalle,
                                                    nota2,
                                                    "",
                                                    "",
                                                    "");

                                }
                                // Manejo de EMida (recargas y pago de servicios) Fin


                            }
                        }


                        if (usuarioTienePermisoDesgloseKit && detailItem.IKITMOVTOID > 0)
                        {


                            ticket.AddItem("  " + detailItem.IKITCANTIDAD.ToString("N3"),
                                             "  " + detailItem.IKITPRODDESCRIPCION1,
                                             "",
                                             "",
                                             "-",
                                             "",
                                             "",
                                            "",
                                            "",
                                            tipoImpresionDetalle,
                                            "",
                                            "",
                                            "",
                                            "");
                        }

                    }

                    //MessageBox.Show("finalizando adding importe descuento");
                    lastMovtoId = detailItem.IMOVTOID;
                }







                decimal fFooterSubTotal, fFooterTotal, fFooterIva;
                fFooterSubTotal = footerBE.ISUBTOTAL;
                fFooterTotal = footerBE.ITOTAL;
                fFooterIva = footerBE.IIVA;

                //si estamos en una compra necesitamos usar el total sumarizado del loop de details
                if ((headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA || headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_REC || headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO_DEVO || headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_PEDIDO_ENVIO_DEVO))
                {

                    fFooterSubTotal = dSubTotalSumarizado;
                    fFooterIva = dIvaSumarizado;
                    fFooterTotal = dSubTotalSumarizado + dIvaSumarizado + dIepsSumarizado;
                }


                //El metodo AddTotal requiere 2 parametros, la descripcion del total, y el precio 
                //ticket.AddTotal("Sub-Total:", ((headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA) ? (fFooterSubTotal + fFooterIva + footerBE.IDESCUENTO_TOTAL).ToString("N2") : fFooterSubTotal.ToString("N2")));
                //ticket.AddTotal("Iva:", fFooterIva.ToString("N2"));
                //ticket.AddTotal("Descuento Total:", footerBE.IDESCUENTO_TOTAL.ToString("N2"));


                if (enDolar)
                {

                    ticket.AddTotal("Total(USD):", footerBE.IIMPORTEENDOLAR.ToString("N2"));
                }
                else
                {


                    if (dDescuentoValeSumarizado > 0)
                    {
                        ticket.AddTotal("Sub-Total:", (fFooterTotal + dDescuentoValeSumarizado).ToString("N2"));
                        ticket.AddTotal("Descuento Vale:", dDescuentoValeSumarizado.ToString("N2"));
                    }

                    ticket.AddTotal("Total:", fFooterTotal.ToString("N2"));

                    if (doctoBE.IMONTOREBAJA > 0)
                    {
                        ticket.AddTotal("Desc. pronto pago:", doctoBE.IMONTOREBAJA.ToString("N2"));
                        ticket.AddTotal("Total con desc.  :", doctoBE.ITOTALCONREBAJA.ToString("N2"));
                    }



                    if (lOpcion1 != Ticket._OPCION_IMPRESION_RECARGAS)
                    {
                        if (footerBE.IPAGOCREDITO == 0 && footerBE.IPAGOTARJETA == 0 && footerBE.IPAGOCHEQUE == 0 && footerBE.IPAGOVALE == 0 && footerBE.IPAGOMONEDERO == 0 && footerBE.IPAGOTRANSFERENCIA == 0 && footerBE.IPAGOEFECTIVO > 0)
                        {
                            ticket.AddTotal("Pago Efectivo:", (footerBE.ITOTAL + footerBE.ICAMBIO).ToString("N2"));

                            if (headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA_DEVO || headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO)
                            {
                                decimal t_aplicado = 0, t_pagado = 0;
                                if (doctoD.GET_DOCTO_MONTOTIPOAPLICACION(doctoId, ref t_aplicado, ref t_pagado, null))
                                {
                                    if (t_aplicado > 0)
                                    {
                                        ticket.AddTotal("Saldo aplicado:", t_aplicado.ToString("N2"));
                                    }
                                }
                                ticket.AddTotal("Saldo pendiente:", footerBE.ISALDO.ToString("N2"));
                            }
                            else
                            {
                                ticket.AddTotal("Cambio:", footerBE.ICAMBIO.ToString("N2")); //Ponemos un total en blanco que sirve de espacio 
                            }
                        }
                        else
                        {
                            if (footerBE.IPAGOEFECTIVO > 0)
                                ticket.AddTotal("Pago Efectivo: ", (footerBE.IPAGOEFECTIVO /*+ footerBE.ICAMBIO*/).ToString("N2"));

                            if (headerBE.ITIPODOCTOID != DBValues._DOCTO_TIPO_COMPRA_DEVO && headerBE.ITIPODOCTOID != DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO)
                            {
                                if (footerBE.IPAGOTARJETA > 0)
                                    ticket.AddTotal("Pago Tarjeta: ", footerBE.IPAGOTARJETA.ToString("N2"));
                                if (footerBE.IPAGOCREDITO > 0)
                                    ticket.AddTotal("Pago Credito: ", footerBE.IPAGOCREDITO.ToString("N2"));
                                if (footerBE.IPAGOCHEQUE > 0)
                                    ticket.AddTotal("Pago Cheque: ", footerBE.IPAGOCHEQUE.ToString("N2"));
                                if (footerBE.IPAGOVALE > 0)
                                    ticket.AddTotal("Pago Vale: ", footerBE.IPAGOVALE.ToString("N2"));
                                if (footerBE.IPAGOMONEDERO > 0)
                                    ticket.AddTotal("Pago Monedero: ", footerBE.IPAGOMONEDERO.ToString("N2"));
                                if (footerBE.IPAGOTRANSFERENCIA > 0)
                                    ticket.AddTotal("Pago Transferencia: ", footerBE.IPAGOTRANSFERENCIA.ToString("N2"));

                                ticket.AddTotal("Cambio:", footerBE.ICAMBIO.ToString("N2"));
                            }
                            else
                            {
                                decimal t_aplicado = 0, t_pagado = 0;
                                if (doctoD.GET_DOCTO_MONTOTIPOAPLICACION(doctoId, ref t_aplicado, ref t_pagado, null))
                                {
                                    if (t_aplicado > 0)
                                    {
                                        ticket.AddTotal("Saldo aplicado:", t_aplicado.ToString("N2"));
                                    }
                                }
                                ticket.AddTotal("Saldo pendiente:", footerBE.ISALDO.ToString("N2"));
                            }
                        }

                        if (headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA)
                        {
                            ticket.AddTotal("Anticipo/Abono:", footerBE.IABONO.ToString("N2"));
                            ticket.AddTotal("Saldo:", footerBE.ISALDO.ToString("N2"));
                        }


                    }
                }


                ticket.AddTotal("", "");

                if (headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA || headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA)
                {
                    if (ConexionesBD.ConexionBD.CurrentParameters.IIMPRIMIRNUMEROPIEZAS.Equals("S"))
                    {
                        ticket.AddTotal("No. Total de Piezas:", dCuentaCantidades.ToString("0.00"));
                    }
                }

                ticket.AddTotal("", "");
                ticket.AddTotal("", "");

                ticket.AddFooterLine(new string('-', Ticket.maxChar));

                cantidadConLetra = Numalet.ToCardinal(fFooterTotal).ToUpper();
                ticket.AddFooterLine(cantidadConLetra.Substring((Ticket.maxChar * iXLetraRenglon)));


                //ticket.AddFooterLine(footerBE.ICAJA + " Turno: " + footerBE.ITURNO);
                ticket.AddFooterLine(new string('-', Ticket.maxChar));



                if (headerBE.IORDENCOMPRA != null && headerBE.IORDENCOMPRA != "")
                {
                    ticket.AddFooterLine(new string('-', Ticket.maxChar));
                    ticket.AddFooterLine("Orden de compra : " + headerBE.IORDENCOMPRA);
                    ticket.AddFooterLine(new string('-', Ticket.maxChar));
                }



                //primero checa el ahorro total
                if (headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA && ConexionesBD.ConexionBD.CurrentParameters.IMOSTRARMONTOAHORRO.Equals("S"))
                {
                    if (!(bool)footerBE.isnull["IDESCUENTO_TOTAL"])
                    {
                        if (footerBE.IDESCUENTO_TOTAL > 0)
                        {

                            ticket.AddTotal("Ud se ahorro : ", footerBE.IDESCUENTO_TOTAL.ToString("N2"));
                        }

                    }
                }




                if (footerBE.INOTAPAGO != null && footerBE.INOTAPAGO.Trim().Length > 0)
                {

                    ticket.AddFooterLine("Nota : " + footerBE.INOTAPAGO);
                }

                if (headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA &&
                    (headerBE.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_VENDMOVIL || headerBE.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_COMPRAMOVIL) &&
                    (doctoBE.IOBSERVACION != null && doctoBE.IDESCRIPCION != null))
                {

                    ticket.AddFooterLine("Notas desde movil : ");
                    if (doctoBE.IOBSERVACION != null)
                        ticket.AddFooterLine(doctoBE.IOBSERVACION);

                    if (doctoBE.IDESCRIPCION != null)
                        ticket.AddFooterLine(doctoBE.IDESCRIPCION);
                }

                if (headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA)
                {


                    if (ConexionesBD.ConexionBD.CurrentParameters.IPROMOENTICKET != null && ConexionesBD.ConexionBD.CurrentParameters.IPROMOENTICKET.Equals("S"))
                    {
                        // checa las promociones
                        CTICKET_PROMOCIONESD promocionesD = new CTICKET_PROMOCIONESD();
                        CTICKET_PROMOCIONESBE[] ListaPromociones = promocionesD.seleccionarTICKET_PROMOCIONES(doctoId, null);

                        if (ListaPromociones.Length > 0)
                        {
                            ticket.AddFooterLine(new string('-', Ticket.maxChar));
                            ticket.AddFooterLine("PROMOCIONES");
                            ticket.AddFooterLine(new string('-', Ticket.maxChar));
                            ticket.AddFooterLine("PRODUCTO               ");
                            ticket.AddFooterLine("PIEZAS NORMAL     OFERTA     AHORRO    ");
                            ticket.AddFooterLine(new string('-', Ticket.maxChar));
                            foreach (CTICKET_PROMOCIONESBE promotionItem in ListaPromociones)
                            {

                                ticket.AddFooterLine(promotionItem.IDESCRIPCION1);

                                decimal cantidadPromo = promotionItem.ICANTIDAD == 0 ? 1 : promotionItem.ICANTIDAD;
                                string strLine = strFixedSize(cantidadPromo.ToString("N2"), 6, false) + " " +
                                                 strFixedSize((promotionItem.ITOTALSINDESCUENTO / cantidadPromo).ToString("N2"), 10, false) + " " +
                                                 strFixedSize((promotionItem.ITOTAL / cantidadPromo).ToString("N2"), 10, false) + " " +
                                                 strFixedSize((promotionItem.ITOTALSINDESCUENTO - promotionItem.ITOTAL).ToString("N2"), 9, false);


                                ticket.AddFooterLine(strLine);
                            }
                        }



                        if (!(bool)footerBE.isnull["IMONEDERO"])
                        {
                            if (footerBE.IMONEDERO != 0 && footerBE.IABONOMONEDERO > 0)
                            {

                                ticket.AddTotal("Ud acumulo en monedero: ", footerBE.IABONOMONEDERO.ToString("N2"));
                                ticket.AddTotal("Su saldo actual es: ", footerBE.ISALDOMONEDERO.ToString("N2"));
                                ticket.AddTotal("Su saldo vence en: ", footerBE.IVIGENCIAMONEDERO.ToString("dd/MM/yyyy"));
                            }
                        }
                    }



                    if (headerBE.IOBSERVACION != null && headerBE.IOBSERVACION.Trim().Length > 0)
                    {

                        ticket.AddFooterLine("Observacion : " + headerBE.IOBSERVACION);
                    }



                    //footer
                    if (!(bool)ConexionesBD.ConexionBD.CurrentParameters.isnull["IFOOTER"])
                    {
                        if (ConexionesBD.ConexionBD.CurrentParameters.IFOOTER != "")
                        {
                            string[] splitFooter = ConexionesBD.ConexionBD.CurrentParameters.IFOOTER.Split(splitSeparator, StringSplitOptions.RemoveEmptyEntries);
                            foreach (string strFtr in splitFooter)
                            {

                                string strBuffer = strFtr.Replace("[nombreVendedor]", headerBE.IVENDEDOR);
                                ticket.AddFooterLine(strBuffer);
                            }
                        }
                    }
                }


                if (headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA)
                {
                    CMOVTOGASTOSADICD movtoGastosAdicD = new CMOVTOGASTOSADICD();
                    CMOVTOGASTOSADICBE[] listaGastos = movtoGastosAdicD.seleccionarMOVTOGASTOSADIC(doctoId, null);

                    if (listaGastos != null && listaGastos.Length > 0)
                    {

                        ticket.AddFooterLine(new string('-', Ticket.maxChar));
                        ticket.AddFooterLine("Gastos Adicionales");
                        ticket.AddFooterLine(new string('-', Ticket.maxChar));

                        ticket.AddFooterLine("DESCRIPCION                  MONTO  ");
                        ticket.AddFooterLine(new string('-', Ticket.maxChar));
                        foreach (CMOVTOGASTOSADICBE gasto in listaGastos)
                        {


                            string strLine = strFixedSize(gasto.INOMBREGASTO, 24, true) + " " +
                                             strFixedSize(gasto.IMONTO.ToString("N2"), 14, false);


                            ticket.AddFooterLine(strLine);
                        }

                    }

                }




                if (headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTAAPARTADO)
                {
                    if (!(bool)ConexionesBD.ConexionBD.CurrentParameters.isnull["IFOOTERVENTAAPARTADO"])
                    {
                        if (ConexionesBD.ConexionBD.CurrentParameters.IFOOTERVENTAAPARTADO != "")
                        {
                            string[] splitFooter = ConexionesBD.ConexionBD.CurrentParameters.IFOOTERVENTAAPARTADO.Split(splitSeparator, StringSplitOptions.RemoveEmptyEntries);
                            foreach (string strFtr in splitFooter)
                            {
                                ticket.AddFooterLine(strFtr);
                            }
                        }
                    }

                    ticket.AddFooterLine("");
                    ticket.AddFooterLine("");
                    ticket.AddFooterLine("");
                    ticket.AddFooterLine("          ____________________");
                    ticket.AddFooterLine("                 firma");


                }



                //AgregarCuponesSiAplica(ref ticket, doctoId);

                if (lOpcion1 == Ticket._OPCION_IMPRESION_RECARGAS)
                {
                    ticket.PrintTicketDirect(ConexionesBD.ConexionBD.CurrentPrinterRecargas, false, (int)ConexionesBD.ConexionBD.CurrentParameters.ITAMANOLETRATICKET);//recargas
                }
                else
                {
                    ticket.PrintTicketDirect(ConexionesBD.ConexionBD.currentPrinter);//"IposPrinter3");
                }

                return strReturn;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message + ex.StackTrace);
                return "";
            }


        }





        public static string strFixedSize(string bufferLine, int iSize, bool padRight)
        {
            if (padRight)
                return bufferLine.Substring(0, Math.Min(iSize, bufferLine.Length)).PadRight(iSize);
            else
                return bufferLine.Substring(0, Math.Min(iSize, bufferLine.Length)).PadLeft(iSize);
        }



        public static string FormatPrintField(string strToFormat, int len, int side)
        {
            string retorno = strToFormat.TrimEnd();
            if (retorno.Length > len)
                retorno = retorno.Substring(0, len);
            else if (retorno.Length < len)
            {
                if (side == 0)
                    retorno = new string(' ', len - retorno.Length) + retorno;
                else
                    retorno = retorno + new string(' ', len - retorno.Length);

            }

            return retorno;
        }

         public string AlignRightText(int lenght)
        {
            string espacios = "";
            int spaces = maxChar - lenght;
            for (int x = 0; x < spaces; x++)
                espacios += " ";
            return espacios;
        }
        public string DottedLine()
        {
            string dotted = "";
            for (int x = 0; x < maxChar; x++)
                dotted += "=";
            return dotted;
        }
        public bool PrinterExists(string impresora)
        {
            foreach (String strPrinter in PrinterSettings.InstalledPrinters)
            {
                if (impresora == strPrinter)
                    return true;
            }
            return false;
        }



        public static string ImprimirTicketFR(long doctoId,  long tipoDoctoId, long lOpcion1, bool enDolar, string impresoraEspecial,long? filterByUserId)
        {

            Ticket ticket = new Ticket();
            ticket.OpenDrawer(ConexionesBD.ConexionBD.currentPrinter);//"IposPrinter3");

            string strTicketFrx = tipoDoctoId == DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO ? "TicketNC.frx" : "Ticket.frx"; 

            FastReport.Report report = new FastReport.Report();
            report.Load(FastReportsConfig.getPathForFile(strTicketFrx, FastReportsTipoFile.desistema) );
            FastReport.Utils.Config.ReportSettings.ShowProgress = false;

            report.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report.SetParameterValue("US_ID", ConexionesBD.ConexionBD.CurrentUser.IID);
            report.SetParameterValue("US_NAME", ConexionesBD.ConexionBD.CurrentUser.IID);

            //report.PrintSettings.ShowDialog = false;

            report.SetParameterValue("pdoctoid", doctoId);
            report.SetParameterValue("usaDatosDeEntregaCuandoExista", "N");
            report.SetParameterValue("desglosekits", "S");
            report.SetParameterValue("marcaAgua", "N");
            report.SetParameterValue("enDolar", "N");
            report.SetParameterValue("creadoPorUserId", filterByUserId == null || !filterByUserId.HasValue ? 0 : filterByUserId.Value);


            string nombreImpresora = impresoraEspecial != null && impresoraEspecial.Length > 0 ? impresoraEspecial :
                                        ConexionesBD.ConexionBD.currentPrinter;
            report.PrintSettings.Printer = nombreImpresora; //ConexionesBD.ConexionBD.currentPrinter


            report.PrintSettings.ShowDialog = false;
            report.Prepare();

            try
            {

                report.Print();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Cheque que la impresora este conectada " + ex.Message);
            }

            return "S";
        }



        public static string ImprimirTicketFRESC(long doctoId, long lOpcion1, bool enDolar)
        {

            Ticket ticket = new Ticket();
            ticket.OpenDrawer(ConexionesBD.ConexionBD.currentPrinter);//"IposPrinter3");

            FastReport.Report report = new FastReport.Report();
            report.Load(FastReportsConfig.getPathForFile(@"TicketESC.frx", FastReportsTipoFile.desistema));
            FastReport.Utils.Config.ReportSettings.ShowProgress = false;

            report.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report.SetParameterValue("US_ID", ConexionesBD.ConexionBD.CurrentUser.IID);
            report.SetParameterValue("US_NAME", ConexionesBD.ConexionBD.CurrentUser.IID);

            //report.PrintSettings.ShowDialog = false;

            report.SetParameterValue("pdoctoid", doctoId);
            report.SetParameterValue("usaDatosDeEntregaCuandoExista", "N");
            report.SetParameterValue("desglosekits", "S");
            report.SetParameterValue("marcaAgua", "N");
            report.SetParameterValue("enDolar", "N");

            report.PrintSettings.Printer = ConexionesBD.ConexionBD.currentPrinter;


            report.PrintSettings.ShowDialog = false;
            report.Prepare();

            try
            {


                TextExportPrinterType printer = new TextExportPrinterType();
                printer.Name = ConexionesBD.ConexionBD.currentPrinter;
                TextExportPrinterCommand command = new TextExportPrinterCommand();
                command.Name = "Reset";
                command.SequenceOn.Add(27);
                command.SequenceOn.Add(64);
                printer.Commands.Add(command);

                command = new TextExportPrinterCommand();
                command.Name = "Normal";
                command.SequenceOn.Add(27);
                command.SequenceOn.Add(33);
                command.SequenceOn.Add(1);
                printer.Commands.Add(command);



                command = new TextExportPrinterCommand();
                command.Name = "Condenced";
                command.SequenceOn.Add(15);
                command.SequenceOff.Add(18);
                printer.Commands.Add(command);

                /*
                command = new TextExportPrinterCommand();
                command.Name = "Pica";
                command.SequenceOn.Add(27);
                command.SequenceOn.Add(120);
                command.SequenceOn.Add(1);
                command.SequenceOn.Add(27);
                command.SequenceOn.Add(107);
                command.SequenceOn.Add(0);
                printer.Commands.Add(command);

                command = new TextExportPrinterCommand();
                command.Name = "Elite";
                command.SequenceOn.Add(27);
                command.SequenceOn.Add(120);
                command.SequenceOn.Add(1);
                command.SequenceOn.Add(27);
                command.SequenceOn.Add(107);
                command.SequenceOn.Add(1);
                printer.Commands.Add(command);

                command = new TextExportPrinterCommand();
                command.Name = "Condenced";
                command.SequenceOn.Add(15);
                command.SequenceOff.Add(18);
                printer.Commands.Add(command);

                command = new TextExportPrinterCommand();
                command.Name = "Bold";
                command.SequenceOn.Add(27);
                command.SequenceOn.Add(71);
                command.SequenceOff.Add(27);
                command.SequenceOff.Add(72);
                printer.Commands.Add(command);

                command = new TextExportPrinterCommand();
                command.Name = "Italic";
                command.SequenceOn.Add(27);
                command.SequenceOn.Add(52);
                command.SequenceOff.Add(27);
                command.SequenceOff.Add(53);
                printer.Commands.Add(command);

                command = new TextExportPrinterCommand();
                command.Name = "Wide";
                command.SequenceOn.Add(27);
                command.SequenceOn.Add(87);
                command.SequenceOn.Add(1);
                command.SequenceOff.Add(27);
                command.SequenceOff.Add(87);
                command.SequenceOff.Add(0);
                printer.Commands.Add(command);

                command = new TextExportPrinterCommand();
                command.Name = "12cpi";
                command.SequenceOn.Add(27);
                command.SequenceOn.Add(77);
                command.SequenceOff.Add(27);
                command.SequenceOff.Add(80);
                printer.Commands.Add(command);*/

                command = new TextExportPrinterCommand();
                command.Name = "Linefeed 1/8\"";
                command.SequenceOn.Add(27);
                command.SequenceOn.Add(48);
                printer.Commands.Add(command);

                command = new TextExportPrinterCommand();
                command.Name = "Linefeed 7/72\"";
                command.SequenceOn.Add(27);
                command.SequenceOn.Add(49);
                printer.Commands.Add(command);

                command = new TextExportPrinterCommand();
                command.Name = "Linefeed 1/6\"";
                command.SequenceOn.Add(27);
                command.SequenceOn.Add(50);
                printer.Commands.Add(command);
                




                TextExport export = new TextExport();
                export.PrinterTypes.Add(printer);
                export.PrinterType = 0;// export.PrinterTypes.Count - 1;


                Stream stream = new MemoryStream();
                export.Export(report, stream);
                TextExportPrint.PrintStream(ConexionesBD.ConexionBD.currentPrinter, "test", 1, stream);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cheque que la impresora este conectada " + ex.Message);
            }

            return "S";
        }


        private static void AgregarLeyendaPlazoSiAplica(ref TicketEspecial_1 ticket, long plazoId)
        {
            if (plazoId == 0)
                return;

            CPLAZOD plazoD = new CPLAZOD();
            CPLAZOBE plazoBE = new CPLAZOBE();
            plazoBE.IID = plazoId;
            plazoBE = plazoD.seleccionarPLAZO(plazoBE, null);

            if (plazoBE == null || plazoBE.ICOMISIONISTA == null || !plazoBE.ICOMISIONISTA.Equals("S"))
                return;

            ticket.AddFooterLine("");
            ticket.AddFooterLine(new string('-', Ticket.maxChar));


            ticket.AddFooterLine(plazoBE.ILEYENDA != null ? plazoBE.ILEYENDA : "");


            ticket.AddFooterLine(new string('-', Ticket.maxChar));
            ticket.AddFooterLine("");
        }

        


    }
}
