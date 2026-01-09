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
using System.Linq;

namespace iPos
{
    public enum tipoImpresionItem { i_unalinea, i_doslineas, i_treslineas , i_doslineas_pzacaja, i_treslineas_pzacaja };
    public class RawPrinterHelper
    {
        // Structure and API declarions:
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }
        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);


        // SendBytesToPrinter()
        // When the function is given a printer name and an unmanaged array
        // of bytes, the function sends those bytes to the print queue.
        // Returns true on success, false on failure.
        public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            Int32 dwError = 0, dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool bSuccess = false; // Assume failure unless you specifically succeed.

            di.pDocName = "My C#.NET RAW Document";
            di.pDataType = "RAW";

            // Open the printer.
            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                // Start a document.
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    // Start a page.
                    if (StartPagePrinter(hPrinter))
                    {
                        // Write your bytes.
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            // If you did not succeed, GetLastError may give more information
            // about why not.
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
            }
            return bSuccess;
        }

        public static bool SendFileToPrinter(string szPrinterName, string szFileName)
        {
            // Open the file.
            FileStream fs = new FileStream(szFileName, FileMode.Open);
            // Create a BinaryReader on the file.
            BinaryReader br = new BinaryReader(fs);
            // Dim an array of bytes big enough to hold the file's contents.
            Byte[] bytes = new Byte[fs.Length];
            bool bSuccess = false;
            // Your unmanaged pointer.
            IntPtr pUnmanagedBytes = new IntPtr(0);
            int nLength;

            nLength = Convert.ToInt32(fs.Length);
            // Read the contents of the file into the array.
            bytes = br.ReadBytes(nLength);
            // Allocate some unmanaged memory for those bytes.
            pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
            // Send the unmanaged bytes to the printer.
            bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes);
            return bSuccess;
        }
        public static bool SendStringToPrinter(string szPrinterName, string szString)
        {
            IntPtr pBytes;
            Int32 dwCount;
            // How many characters are in the string?
            dwCount = szString.Length;

            //szString.Replace("Ñ", char.ConvertFromUtf32(165)).Replace("ñ", char.ConvertFromUtf32(164));
            
            // Assume that the printer is expecting ANSI text, and then convert
            // the string to ANSI text.
            pBytes = Marshal.StringToCoTaskMemAnsi(szString.Replace("Ñ", char.ConvertFromUtf32(165)).Replace("ñ", char.ConvertFromUtf32(164)));
            // Send the converted ANSI string to the printer.
            SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
            return true;
        }


        public static bool SendStringToPrinterEPL(string szPrinterName, string szString)
        {
            IntPtr pBytes;
            Int32 dwCount;
            // How many characters are in the string?
            dwCount = (szString.Length + 1) * Marshal.SystemMaxDBCSCharSize;

            //szString.Replace("Ñ", char.ConvertFromUtf32(165)).Replace("ñ", char.ConvertFromUtf32(164));

            // Assume that the printer is expecting ANSI text, and then convert
            // the string to ANSI text.
            pBytes = Marshal.StringToCoTaskMemAnsi(szString.Replace("Ñ", char.ConvertFromUtf32(165)).Replace("ñ", char.ConvertFromUtf32(164)));
            // Send the converted ANSI string to the printer.
            SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
            return true;
        }
    }




    
    public class OrderItem
    {
        char[] delimitador = new char[] { '?' };
        public OrderItem(char delimit)
        {
            delimitador = new char[] { delimit };
        }
        public string GetItemCantidad(string orderItem)
        {
            string[] delimitado = orderItem.Split(delimitador);
            return delimitado[0];
        }
        public string GetItemName(string orderItem)
        {
            string[] delimitado = orderItem.Split(delimitador);
            return delimitado[1].TrimEnd();
        }
        
        public string GetItemClave(string orderItem)
        {
            string[] delimitado = orderItem.Split(delimitador);
            return delimitado[11].TrimEnd();
        }


        public string GetItemCajas(string orderItem)
        {
            string[] delimitado = orderItem.Split(delimitador);
            return delimitado[12].TrimEnd();
        }


        public string GetItemPiezas(string orderItem)
        {
            string[] delimitado = orderItem.Split(delimitador);
            return delimitado[13].TrimEnd();
        }
        public string GetItemPrice(string orderItem)
        {
            string[] delimitado = orderItem.Split(delimitador);
            return delimitado[2].TrimEnd();
        }
        public string GetCostoUnitarioPrice(string orderItem)
        {
            string[] delimitado = orderItem.Split(delimitador);
            return delimitado[3].TrimEnd();
        }
        public string GetImpuestoPrice(string orderItem)
        {
            string[] delimitado = orderItem.Split(delimitador);
            return delimitado[4].TrimEnd();
        }

        public string GetLote(string orderItem)
        {
            string[] delimitado = orderItem.Split(delimitador);
            return delimitado[5].TrimEnd();
        }


        public string GetFechaCad(string orderItem)
        {
            string[] delimitado = orderItem.Split(delimitador);
            return delimitado[6].TrimEnd();
        }

        public string GetImporteDescuento(string orderItem)
        {
            string[] delimitado = orderItem.Split(delimitador);
            return delimitado[7].TrimEnd();
        }


        public string GetTipoRecarga(string orderItem)
        {
            string[] delimitado = orderItem.Split(delimitador);
            return delimitado[8].TrimEnd();
        }

        public string GetItemTipo(string orderItem)
        {
            string[] delimitado = orderItem.Split(delimitador);
            return delimitado[9].TrimEnd();
        }
        public string GetItemNota(string orderItem)
        {
            string[] delimitado = orderItem.Split(delimitador);
            return delimitado[10].TrimEnd();
        }

        public string GetItemTamanioLetra(string orderItem)
        {
            string[] delimitado = orderItem.Split(delimitador);
            if (delimitado.Length >= 15)
            {
                return delimitado[14].TrimEnd();
            }
            else
            {
                return "Normal";
            }
        }


        public string GenerateItem(string cantidad, string itemName, string price, string costoUnitario, string impuesto, string lote, string fechacad, string importeDescuento, string tipoRecarga, string tipo, string nota)
        {
            return cantidad + delimitador[0] + itemName + delimitador[0] + price + delimitador[0] + costoUnitario + delimitador[0] + impuesto + delimitador[0] + lote + delimitador[0] + fechacad + delimitador[0] + importeDescuento + delimitador[0] + tipoRecarga + delimitador[0] + tipo + delimitador[0] + nota;
        }

        public string GenerateItem(string cantidad, string itemName, string price, string costoUnitario,string impuesto,string lote,string fechacad,string importeDescuento,string tipoRecarga,string tipo, string nota, string clave, string cajas, string piezas)
        {
            return cantidad + delimitador[0] + itemName + delimitador[0] + price + delimitador[0] + costoUnitario + delimitador[0] + impuesto + delimitador[0] + lote + delimitador[0] + fechacad + delimitador[0] + importeDescuento + delimitador[0] + tipoRecarga + delimitador[0] + tipo + delimitador[0] + nota + delimitador[0] + clave + delimitador[0] + cajas + delimitador[0] + piezas;
        }
        public string GenerateItem(string cantidad, string itemName, string price, string costoUnitario, string impuesto, string lote, string fechacad, string importeDescuento, string tipoRecarga, string tipo, string nota, string clave, string cajas, string piezas, string tamanioLetra)
        {
            return cantidad + delimitador[0] + itemName + delimitador[0] + price + delimitador[0] + costoUnitario + delimitador[0] + impuesto + delimitador[0] + lote + delimitador[0] + fechacad + delimitador[0] + importeDescuento + delimitador[0] + tipoRecarga + delimitador[0] + tipo + delimitador[0] + nota + delimitador[0] + clave + delimitador[0] + cajas + delimitador[0] + piezas + delimitador[0] + tamanioLetra;
        }

    }
    public class OrderTotal
    {
        char[] delimitador = new char[] { '?' };
        public OrderTotal(char delimit)
        {
            delimitador = new char[] { delimit };
        }
        public string GetTotalName(string totalItem)
        {
            string[] delimitado = totalItem.Split(delimitador);
            return delimitado[0];
        }
        public string GetTotalCantidad(string totalItem)
        {
            string[] delimitado = totalItem.Split(delimitador);
            return delimitado[1];
        }
        public string GenerateTotal(string totalName, string price)
        {
            return totalName + delimitador[0] + price;
        }

    }




    public class Ticket
    {
        ArrayList headerLines = new ArrayList();
        ArrayList subHeaderLines = new ArrayList();
        ArrayList items = new ArrayList();
        ArrayList totales = new ArrayList();
        ArrayList footerLines = new ArrayList();
        ArrayList itemLines = new ArrayList();
        private Image headerImage = null;
        int count = 0;
        public static int maxChar = 39;
        int maxCharDescription = maxChar;
        int imageHeight = 0;
        float leftMargin = 0;
        float topMargin = 0;
        string fontName = "Lucida Console";
        int fontSize = 8;
        Font printFont = null;
        SolidBrush myBrush = new SolidBrush(Color.Black);
        Graphics gfx = null;
        string line = null;




        public const long _OPCION_IMPRESION_NINGUNO = 0;
        public const long _OPCION_IMPRESION_COMPRA_RECEPCION = 6;
        public const long _OPCION_IMPRESION_COMPRA_DEVOLUCION = 1;
        public const long _OPCION_IMPRESION_COMPRA = 2;
        public const long _OPCION_IMPRESION_RECARGAS = 3;
        public const long _OPCION_IMPRESION_TRASLADO_RECEPCION = 4;
        public const long _OPCION_IMPRESION_TRASLADO_DEVOLUCION = 5;


        public Ticket()
        {
        }
        public Image HeaderImage
        {
            get { return headerImage; }
            set { if (headerImage != value) headerImage = value; }
        }
        public int MaxChar
        {
            get { return maxChar; }
            set { if (value != maxChar) maxChar = value; }
        }
        public int MaxCharDescription
        {
            get { return maxCharDescription; }
            set { if (value != maxCharDescription) maxCharDescription = value; }
        }
        public int FontSize
        {
            get { return fontSize; }
            set { if (value != fontSize) fontSize = value; }
        }
        public string FontName
        {
            get { return fontName; }
            set { if (value != fontName) fontName = value; }
        }
        public void AddHeaderLine(string line)
        {
            headerLines.Add(line);
        }
        public void AddSubHeaderLine(string line)
        {
            subHeaderLines.Add(line);
        }
        public void AddItem(string cantidad, string item, string price, string costoUnitario, string impuesto, string lote, string fechacad, string importeDescuento, string tipoRecarga, string tipo, string nota)
        {
            OrderItem newItem = new OrderItem('?');
            items.Add(newItem.GenerateItem(cantidad, item, price, costoUnitario, impuesto, lote, fechacad, importeDescuento, tipoRecarga, tipo, nota));
        }
        public void AddTotal(string name, string price)
        {
            OrderTotal newTotal = new OrderTotal('?');
            totales.Add(newTotal.GenerateTotal(name, price));
        }
        public void AddFooterLine(string line)
        {
            footerLines.Add(line);
        }
        private string AlignRightText(int lenght)
        {
            string espacios = "";
            int spaces = maxChar - lenght;
            for (int x = 0; x < spaces; x++)
                espacios += " ";
            return espacios;
        }
        private string DottedLine()
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
        public void PrintTicket(string impresora)
        {
            printFont = new Font(fontName, fontSize, FontStyle.Regular);
            PrintDocument pr = new PrintDocument();
            pr.PrinterSettings.PrinterName = impresora;
            pr.PrintPage += new PrintPageEventHandler(pr_PrintPage);
            pr.Print();
        }


        private void pr_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            gfx = e.Graphics;
            DrawImage();
            DrawHeader();
            DrawSubHeader();
            DrawItems();
            DrawTotales();
            DrawFooter();
            if (headerImage != null)
            {
                HeaderImage.Dispose();
                headerImage.Dispose();
            }
        }
        private float YPosition()
        {
            return topMargin + (count * printFont.GetHeight(gfx) + imageHeight);
        }
        private void DrawImage()
        {
            if (headerImage != null)
            {
                try
                {
                    gfx.DrawImage(headerImage, new Point((int)leftMargin, (int)YPosition()));
                    double height = ((double)headerImage.Height / 58) * 15;
                    imageHeight = (int)Math.Round(height) + 3;
                }
                catch (Exception)
                {
                }
            }
        }
        private void DrawHeader()
        {
            foreach (string header in headerLines)
            {
                if (header.Length > maxChar)
                {
                    int currentChar = 0;
                    int headerLenght = header.Length;
                    while (headerLenght > maxChar)
                    {
                        line = header.Substring(currentChar, maxChar);
                        gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                        count++;
                        currentChar += maxChar;
                        headerLenght -= maxChar;
                    }
                    line = header;
                    gfx.DrawString(line.Substring(currentChar, line.Length - currentChar), printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                    count++;
                }
                else
                {
                    line = header;
                    gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                    count++;
                }
            }
            DrawEspacio();
        }
        private void DrawSubHeader()
        {
            foreach (string subHeader in subHeaderLines)
            {
                if (subHeader.Length > maxChar)
                {
                    int currentChar = 0;
                    int subHeaderLenght = subHeader.Length;
                    while (subHeaderLenght > maxChar)
                    {
                        line = subHeader;
                        gfx.DrawString(line.Substring(currentChar, maxChar), printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                        count++;
                        currentChar += maxChar;
                        subHeaderLenght -= maxChar;
                    }
                    line = subHeader;
                    gfx.DrawString(line.Substring(currentChar, line.Length - currentChar), printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                    count++;
                }
                else
                {
                    line = subHeader;
                    gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                    count++;
                    line = DottedLine();
                    gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                    count++;
                }
            }
            DrawEspacio();
        }
        private void DrawItems()
        {
            OrderItem ordIt = new OrderItem('?');
            gfx.DrawString("CANT  DESCRIPCION           ", printFont, myBrush, leftMargin, YPosition(), new StringFormat());
            count++;
            gfx.DrawString("      %IVA     PRECIO          IMPORTE", printFont, myBrush, leftMargin, YPosition(), new StringFormat());
            count++;
            DrawEspacio();
            foreach (string item in items)
            {
                line = ordIt.GetItemCantidad(item);
                gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                string name = ordIt.GetItemName(item);
                leftMargin = 0;
                if (name.Length > maxCharDescription)
                {
                    int currentChar = 0;
                    int itemLenght = name.Length;
                    while (itemLenght > maxCharDescription)
                    {
                        line = ordIt.GetItemName(item);
                        gfx.DrawString("      " + line.Substring(currentChar, maxCharDescription), printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                        count++;
                        currentChar += maxCharDescription;
                        itemLenght -= maxCharDescription;
                    }
                    line = ordIt.GetItemName(item);
                    gfx.DrawString("      " + line.Substring(currentChar, line.Length - currentChar), printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                    count++;
                }
                else
                {
                    gfx.DrawString("      " + ordIt.GetItemName(item), printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                    count++;
                }
                // imprime iva , costo unitario y precio
                line = ordIt.GetImpuestoPrice(item);
                gfx.DrawString("      " + line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                line = ordIt.GetCostoUnitarioPrice(item);
                gfx.DrawString("               " + line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                line = ordIt.GetItemPrice(item);
                line = AlignRightText(line.Length) + line;
                gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                count++;
            }
            leftMargin = 0;
            DrawEspacio();
            line = DottedLine();
            gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
            count++;
            DrawEspacio();
        }
        private void DrawTotales()
        {
            OrderTotal ordTot = new OrderTotal('?');
            foreach (string total in totales)
            {
                line = ordTot.GetTotalCantidad(total);
                line = AlignRightText(line.Length) + line;
                gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                leftMargin = 0;
                line = "      " + ordTot.GetTotalName(total);
                gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                count++;
            }
            leftMargin = 0;
            DrawEspacio();
            DrawEspacio();
        }
        private void DrawFooter()
        {
            foreach (string footer in footerLines)
            {
                if (footer.Length > maxChar)
                {
                    int currentChar = 0;
                    int footerLenght = footer.Length;
                    while (footerLenght > maxChar)
                    {
                        line = footer;
                        gfx.DrawString(line.Substring(currentChar, maxChar), printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                        count++;
                        currentChar += maxChar;
                        footerLenght -= maxChar;
                    }
                    line = footer;
                    gfx.DrawString(line.Substring(currentChar, line.Length - currentChar), printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                    count++;
                }
                else
                {
                    line = footer;
                    gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                    count++;
                }
            }
            leftMargin = 0;
            DrawEspacio();
        }
        private void DrawEspacio()
        {
            line = "";
            gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
            count++;
        }



        /****/

        public void PrintTicketDirect(string printer)
        {

            PrintTicketDirect(printer, true, (int)ConexionesBD.ConexionBD.CurrentParameters.ITAMANOLETRATICKET);
        }

        public void PrintTicketDirect(string printer, bool abrirCajon, int letra)
        {
            StringBuilder printingStr = new StringBuilder();

            // #if !DEBUG
            if (abrirCajon)
                OpenDrawer(printer);
            if (letra != 0)
                LetraPequena(printer);
            //#endif

            PrintReceiptHeader(printer, ref printingStr);

            PrintItems(printer, ref printingStr);

            PrintReceiptFooter(printer, ref printingStr);

            PrintText(printer, printingStr.ToString());

            //#if !DEBUG
            CutPaper(printer);
            if (letra != 0)
                LetraNormal(printer);
            //#endif

        }
        public static void DisconnectFromPrinter(string printer)
        {
        }

        public static void ConnectToPrinter(string printer)
        {
        }

        public static string GetReceiptPrinter()
        {
            CPERSONABE usuario = ConexionesBD.ConexionBD.CurrentUser;

            if (usuario != null && usuario.INOMBREIMPRESORA != null && usuario.INOMBREIMPRESORA.Trim().Length > 0)
                return usuario.INOMBREIMPRESORA;

            CCAJAD cajaD = new CCAJAD();
            CCAJABE cajaBE = new CCAJABE();
            cajaBE.IID = ConexionesBD.ConexionBD.CurrentCompania.IEM_CAJA;

            cajaBE = cajaD.seleccionarCAJA(cajaBE, null);

            if (cajaBE == null || cajaBE.INOMBREIMPRESORA == null || cajaBE.INOMBREIMPRESORA.Trim().Length == 0)
            {
                return ConexionesBD.ConexionBD.CurrentParameters.ITICKETDEFAULTPRINTER;
            }

            return cajaBE.INOMBREIMPRESORA.Split('|')[0];
        }

        public static string GetReceiptPrinterRecargas()
        {
            CCAJAD cajaD = new CCAJAD();
            CCAJABE cajaBE = new CCAJABE();
            cajaBE.IID = ConexionesBD.ConexionBD.CurrentCompania.IEM_CAJA;

            cajaBE = cajaD.seleccionarCAJA(cajaBE, null);

            if (cajaBE == null || cajaBE.INOMBREIMPRESORA == null || cajaBE.INOMBREIMPRESORA.Trim().Length == 0)
            {
                return ConexionesBD.ConexionBD.CurrentParameters.IRECARGASDEFAULTPRINTER;
            }


            if (cajaBE.INOMBREIMPRESORA.Split('|').Length > 1)
            {
                return cajaBE.INOMBREIMPRESORA.Split('|')[1];
            }
            else
                return ConexionesBD.ConexionBD.CurrentParameters.IRECARGASDEFAULTPRINTER;//"recargas";
        }

        private void PrintReceiptFooter(string printer, ref StringBuilder printingStr)
        {

            OrderTotal ordTot = new OrderTotal('?');
            foreach (string total in totales)
            {
                //line = "      " + ordTot.GetTotalName(total);
                //printingStr.Append(line + "\r");


                line = FormatPrintField(ordTot.GetTotalName(total), 28, 0);
                line += FormatPrintField(ordTot.GetTotalCantidad(total), 11, 0);
                line = AlignRightText(line.Length) + line;
                printingStr.Append(line + Environment.NewLine);



                //line = ordTot.GetTotalCantidad(total);
                //line = AlignRightText(line.Length) + line;
                //printingStr.Append(line + "\r");
                //printingStr.Append(Environment.NewLine);
                count++;
            }
            //PrintTextLine(printer, String.Empty);
            printingStr.Append(Environment.NewLine);
            //PrintTextLine(printer, String.Empty);
            printingStr.Append(Environment.NewLine);


            foreach (string header in footerLines)
            {

                if (header.Length > maxChar)
                {
                    int currentChar = 0;
                    int headerLenght = header.Length;
                    while (headerLenght > maxChar)
                    {
                        line = header.Substring(currentChar, maxChar);
                        //PrintTextLine(printer, line);
                        printingStr.Append(line + Environment.NewLine);
                        count++;
                        currentChar += maxChar;
                        headerLenght -= maxChar;
                    }
                    line = header;
                    //PrintTextLine(printer, line.Substring(currentChar, line.Length - currentChar));
                    printingStr.Append(line.Substring(currentChar, line.Length - currentChar) + Environment.NewLine);
                    count++;
                }
                else
                {
                    line = header;
                    //PrintTextLine(printer, line);
                    printingStr.Append(line + Environment.NewLine);
                    count++;
                }
            }

            //Added in these blank lines because RecLinesToCut seems to be wrong on my printer and
            //these extra blank lines ensure the cut is after the footer ends.
            //PrintTextLine(printer, String.Empty);
            //PrintTextLine(printer, String.Empty);
            //PrintTextLine(printer, String.Empty);
            //PrintTextLine(printer, String.Empty);
            //PrintTextLine(printer, String.Empty);
            printingStr.Append(Environment.NewLine);
            printingStr.Append(Environment.NewLine);
            printingStr.Append(Environment.NewLine);
            printingStr.Append(Environment.NewLine);
            printingStr.Append(Environment.NewLine);

            ////Print 'advance and cut' escape command.
            ////PrintTextLine(printer, System.Text.ASCIIEncoding.ASCII.GetString(new byte[] { 27, (byte)'|', (byte)'1', (byte)'0', (byte)'0', (byte)'P', (byte)'f', (byte)'P' }));

            //CutPaper(printer);

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

        private void PrintItems(string printer, ref StringBuilder printingStr)
        {
            OrderItem ordIt = new OrderItem('?');
            int currentChar = 0;
            int itemLenght;
            string name;
            //bool bFirstDescLine;


            foreach (string item in items)
            {
                //line = ordIt.GetItemCantidad(item);
                //PrintText(printer, line + "\r");
                name = ordIt.GetItemName(item);
                itemLenght = name.Length;
                currentChar = 0;
                //bFirstDescLine = true;



                // imprime iva , costo unitario y precio

                tipoImpresionItem tipoImpresion;
                try
                {
                    tipoImpresion = (tipoImpresionItem)int.Parse(ordIt.GetItemTipo(item));
                }
                catch
                {
                    tipoImpresion = tipoImpresionItem.i_unalinea;
                }

                switch (tipoImpresion)
                {
                    case tipoImpresionItem.i_unalinea:
                        {


                            line = FormatPrintField(ordIt.GetItemCantidad(item), 7, 0) + " ";
                            line += FormatPrintField(name, 15, 0) + " ";
                            //line += FormatPrintField(ordIt.GetCostoUnitarioPrice(item), 10, 0) + "  ";
                            line += FormatPrintField(ordIt.GetImpuestoPrice(item), 2, 0) + "%";
                            line += FormatPrintField(ordIt.GetItemPrice(item), 12, 0);

                            line = AlignRightText(line.Length) + line;
                            //PrintText(printer,line + Environment.NewLine);
                            printingStr.Append(line + Environment.NewLine);
                        }
                        break;
                    case tipoImpresionItem.i_doslineas:
                    case tipoImpresionItem.i_treslineas:
                        {

                            if (tipoImpresion == tipoImpresionItem.i_treslineas)
                            {
                                line = name.Substring(0, name.Length < 39 ? name.Length : 39);
                                printingStr.Append(line + Environment.NewLine);
                                if (name.Length > 39)
                                {
                                    line = name.Substring(39, name.Length - 39);
                                    printingStr.Append(line + Environment.NewLine);
                                }
                            }
                            else
                            {
                                line = name;
                                printingStr.Append(line + Environment.NewLine);
                            }

                            //printingStr.Append(line + Environment.NewLine);


                            line = FormatPrintField(ordIt.GetItemCantidad(item), 10, 0) + " ";
                            line += FormatPrintField(ordIt.GetCostoUnitarioPrice(item), 12, 0) + " ";
                            line += FormatPrintField(ordIt.GetImpuestoPrice(item), 2, 0) + "%";
                            line += FormatPrintField(ordIt.GetItemPrice(item), 12, 0);

                            line = AlignRightText(line.Length) + line;
                            printingStr.Append(line + Environment.NewLine);
                        }
                        break;
                    case tipoImpresionItem.i_doslineas_pzacaja:
                    case tipoImpresionItem.i_treslineas_pzacaja:
                        {

                            if (tipoImpresion == tipoImpresionItem.i_treslineas_pzacaja)
                            {
                                line = name.Substring(0, name.Length < 39 ? name.Length : 39);
                                printingStr.Append(line + Environment.NewLine);
                                if (name.Length > 39)
                                {
                                    line = name.Substring(39, name.Length - 39);
                                    printingStr.Append(line + Environment.NewLine);
                                }
                            }
                            else
                            {
                                line = name;
                                printingStr.Append(line + Environment.NewLine);
                            }

                            //printingStr.Append(line + Environment.NewLine);

                            line = FormatPrintField(ordIt.GetItemCantidad(item), 14, 0) + "";
                            line += FormatPrintField(ordIt.GetCostoUnitarioPrice(item), 12, 0) + " ";
                            line += FormatPrintField(ordIt.GetItemPrice(item), 12, 0);

                            line = AlignRightText(line.Length) + line;
                            printingStr.Append(line + Environment.NewLine);
                        }
                        break;
                }



                if (ordIt.GetLote(item).Trim() != "")
                {
                    /*if (ordIt.GetLote(item).ToUpper().StartsWith("TELCEL") ||
                        ordIt.GetLote(item).ToUpper().StartsWith("MOVISTAR") ||
                        ordIt.GetLote(item).ToUpper().StartsWith("UNEFON") ||
                        ordIt.GetLote(item).ToUpper().StartsWith("IUSACELL"))
                        */
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

                    printingStr.Append(line + Environment.NewLine);

                }


                if (ordIt.GetItemNota(item).Trim() != "")
                {


                    line = "Nota: " + ordIt.GetItemNota(item);// FormatPrintField(ordIt.GetItemNota(item), 32, 1);

                    for (int i = 0; i <= (39 * 5); i = i + 39)
                    {
                        if (line.Length > i)
                        {

                            int longitud = line.Length - i > 39 ? 39 : line.Length - i;
                            printingStr.Append(line.Substring(i, longitud) + Environment.NewLine);
                        }
                        else
                        {
                            break;
                        }


                    }


                }


                /* if (ordIt.GetImporteDescuento(item).Trim() != "")
                 {

                     line = " Imp. Desc.: " + FormatPrintField(ordIt.GetImporteDescuento(item), 11, 0);
                     printingStr.Append(line + Environment.NewLine);
                 }*/


                count++;
            }
            line = DottedLine();
            //PrintTextLine(printer,line);
            printingStr.Append(line + Environment.NewLine);
            count++;


            foreach (string header in itemLines)
            {
                if (header.Length > maxChar)
                {
                    currentChar = 0;
                    int headerLenght = header.Length;
                    while (headerLenght > maxChar)
                    {
                        line = header.Substring(currentChar, maxChar);
                        //PrintTextLine(printer, line);
                        printingStr.Append(line + Environment.NewLine);
                        count++;
                        currentChar += maxChar;
                        headerLenght -= maxChar;
                    }
                    line = header;
                    //PrintTextLine(printer, line.Substring(currentChar, line.Length - currentChar));
                    printingStr.Append(line.Substring(currentChar, line.Length - currentChar) + Environment.NewLine);
                    count++;
                }
                else
                {
                    line = header;
                    //PrintTextLine(printer, line);
                    printingStr.Append(line + Environment.NewLine);
                    count++;
                }
            }

        }

        private void PrintReceiptHeader(string printer, ref StringBuilder printingStr)
        {
            foreach (string header in headerLines)
            {
                if (header.Length > maxChar)
                {
                    int currentChar = 0;
                    int headerLenght = header.Length;
                    while (headerLenght > maxChar)
                    {
                        line = header.Substring(currentChar, maxChar);

                        //PrintTextLine(printer, line);
                        printingStr.Append(line + Environment.NewLine);

                        count++;
                        currentChar += maxChar;
                        headerLenght -= maxChar;
                    }
                    line = header;

                    //PrintTextLine(printer, line.Substring(currentChar, line.Length - currentChar));
                    printingStr.Append(line.Substring(currentChar, line.Length - currentChar) + Environment.NewLine);

                    count++;
                }
                else
                {
                    line = header;
                    //PrintTextLine(printer, line);
                    printingStr.Append(line + Environment.NewLine);

                    count++;
                }
            }
        }

        private void PrintText(string printer, string text)
        {
            RawPrinterHelper.SendStringToPrinter(printer, text); //Print text
            //if (text.Length <= 60)
            //    RawPrinterHelper.SendStringToPrinter(printer, text); //Print text
            //else if (text.Length > 60)
            //    RawPrinterHelper.SendStringToPrinter(printer, TruncateAt(text, 60)); //Print exactly as many characters as the printer allows, truncating the rest.
        }

        private void PrintNewLine(string printer)
        {
            byte[] toSend3; // 10 = line feed // 13 carriage return/form feed 
            toSend3 = new byte[2] { 10, 13 };
            IntPtr pUnmanagedBytes3 = new IntPtr(0);
            int nLength3 = Convert.ToInt32(toSend3.Length);
            pUnmanagedBytes3 = Marshal.AllocCoTaskMem(nLength3);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(toSend3, 0, pUnmanagedBytes3, nLength3);
            // Send the unmanaged bytes to the printer.
            bool bSuccess3 = RawPrinterHelper.SendBytesToPrinter(printer, pUnmanagedBytes3, nLength3);
            // Free the unmanaged memory that you allocated earlier.

            Marshal.FreeCoTaskMem(pUnmanagedBytes3);
        }

        private void PrintTextLine(string printer, string text)
        {

            /*if (text.Length < printer.RecLineChars || printer.RecLineChars == 0)
                printer.PrintNormal(PrinterStation.Receipt, text + Environment.NewLine); //Print text, then a new line character.
            else*/
            if (text.Length > 60)
            {
                RawPrinterHelper.SendStringToPrinter(printer, TruncateAt(text, 60));
                PrintNewLine(printer);
                //printer.PrintNormal(PrinterStation.Receipt, TruncateAt(text, printer.RecLineChars)); //Print exactly as many characters as the printer allows, truncating the rest, no new line character (printer will probably auto-feed for us)
            }
            else if (text.Length <= 60)
            {
                RawPrinterHelper.SendStringToPrinter(printer, text);
                PrintNewLine(printer);
                //printer.PrintNormal(PrinterStation.Receipt, text + Environment.NewLine); //Print text, no new line character, printer will probably auto-feed for us.
            }
        }

        private string TruncateAt(string text, int maxWidth)
        {
            string retVal = text;
            if (text.Length > maxWidth)
                retVal = text.Substring(0, maxWidth);

            return retVal;
        }


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

        private void CutPaper(string printer)
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



        private void LetraPequena(string printer)
        {
            int nLength;
            byte[] toSend2; // 10 = line feed // 13 carriage return/form feed 
            toSend2 = new byte[3] { /*13*/27, 33, 1 };
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


        private void LetraNormal(string printer)
        {
            int nLength;
            byte[] toSend2; // 10 = line feed // 13 carriage return/form feed 
            toSend2 = new byte[3] { /*13*/27, 33, 0 };
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


        /****/


    }


    public class PosPrinter
    {
        private static CSUCURSALBE DatosSucursal(long lSucursalTid)
        {

            CSUCURSALD sucursalD = new CSUCURSALD();
            CSUCURSALBE sucursalBE = new CSUCURSALBE();

            sucursalBE.IID = lSucursalTid;
            sucursalBE = sucursalD.seleccionarSUCURSAL(sucursalBE, null);

            return sucursalBE;

        }

        private static CPERSONABE DatosPersona(long lPersonaId)
        {

            CPERSONAD personaD = new CPERSONAD();
            CPERSONABE personaBE = new CPERSONABE();

            personaBE.IID = lPersonaId;
            personaBE = personaD.seleccionarPERSONA(personaBE, null);

            return personaBE;

        }


        public static string ImprimirTicket(long doctoId)
        {
            return ImprimirTicket(doctoId, 0);
        }


        public static string ImprimirTicket(long doctoId, long lOpcion1)
        {
            return ImprimirTicket(doctoId, lOpcion1, false);
        }


        public static string ImprimirTicket(long doctoId, long lOpcion1, bool bForceTicket)
        {
            return ImprimirTicket(doctoId, lOpcion1, false, false, 1);
        }

        public static string ImprimirTicket(long doctoId, long lOpcion1, bool bForceTicket, bool bMarcaAguaCopia, int copias)
        {
            return ImprimirTicket(doctoId, lOpcion1, false, bMarcaAguaCopia, copias, false);
        }
        public static string ImprimirTicket(long doctoId, long lOpcion1, bool bForceTicket, bool bMarcaAguaCopia, int copias, bool enDolar)
        {
            return ImprimirTicket(doctoId, lOpcion1, false, bMarcaAguaCopia, copias, enDolar, false, false, null);
        }

        public static string ImprimirTicket(long doctoId, long lOpcion1, bool bForceTicket, bool bMarcaAguaCopia, int copias, bool enDolar, bool conTopes, bool bImpresionDirecta, string impresoraEspecial)
        {
            CUSUARIOSD usuariosD = new CUSUARIOSD();
            Boolean usuarioTienePermisoDesgloseKit = usuariosD.UsuarioTienePermisos((int)ConexionesBD.ConexionBD.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null);

            string bufferReturn = "";

            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE doctoBE = new CDOCTOBE();
            doctoBE.IID = doctoId;
            doctoBE = doctoD.seleccionarDOCTO(doctoBE, null);
            if (doctoBE == null)
                return "Error al obtener los datos del documento";

            long? filterByUserId = doctoBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA &&
                                         doctoBE.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_BORRADOR &&
                                         doctoBE.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_STAND ?
                                         ConexionesBD.ConexionBD.CurrentUser.IID : (long?)null;



            if (!bForceTicket && (
                (doctoBE.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_BORRADOR && ConexionesBD.ConexionBD.CurrentUser.ITICKETLARGOCOTIZACION != null && ConexionesBD.ConexionBD.CurrentUser.ITICKETLARGOCOTIZACION.Equals("S")) ||
                (doctoBE.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_BORRADOR && doctoBE.ISALDO == 0 && ConexionesBD.ConexionBD.CurrentUser.ITICKETLARGO.Equals("S")) ||
                (doctoBE.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_BORRADOR && doctoBE.ISALDO != 0 && ConexionesBD.ConexionBD.CurrentUser.ITICKETLARGOCREDITO.Equals("S"))))
            {
                WFImpresionReciboLargo wf = new WFImpresionReciboLargo(doctoId, 0, bMarcaAguaCopia, copias, enDolar, conTopes, bImpresionDirecta, impresoraEspecial, filterByUserId);
                if ((lOpcion1 == Ticket._OPCION_IMPRESION_TRASLADO_DEVOLUCION && doctoBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_REC) )
                {
                    wf.m_imprimirRecDevolucion = true;
                }
                if (  (lOpcion1 == Ticket._OPCION_IMPRESION_COMPRA_DEVOLUCION && doctoBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA))
                {

                    wf.m_imprimirRecCompDevolucion = true;
                }
                wf.ShowDialog();
                wf.Dispose();
                GC.SuppressFinalize(wf);

                ImprimirCuponesSiAplica(doctoBE.IID, impresoraEspecial);

                return "";

            }


            //tickets especuales
            if (ConexionesBD.ConexionBD.CurrentParameters.ITICKETESPECIAL != null && ConexionesBD.ConexionBD.CurrentParameters.ITICKETESPECIAL.Equals("VG") &&
                (doctoBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA))
            {
                  bufferReturn = TicketEspecial_1.ImprimirTicket(doctoId,  lOpcion1, enDolar, impresoraEspecial);//, lOpcion1,enDolar) ;
                  ImprimirCuponesSiAplica(doctoBE.IID, impresoraEspecial);
                  return bufferReturn;
            }


            //tickets especuales
            if (ConexionesBD.ConexionBD.CurrentParameters.ITICKETESPECIAL != null && ConexionesBD.ConexionBD.CurrentParameters.ITICKETESPECIAL.Equals("VA") &&
                (doctoBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA))
            {
                bufferReturn = TicketEspecial_2.ImprimirTicket(doctoId, lOpcion1, enDolar, impresoraEspecial);
                ImprimirCuponesSiAplica(doctoBE.IID, impresoraEspecial);
                return bufferReturn;
            }


            //tickets especuales
            if (ConexionesBD.ConexionBD.CurrentParameters.ITICKETESPECIAL != null && ConexionesBD.ConexionBD.CurrentParameters.ITICKETESPECIAL.Equals("VAF") &&
                (doctoBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA))
            {
                bufferReturn = TicketEspecial_1.ImprimirTicketFR(doctoId, doctoBE.ITIPODOCTOID, lOpcion1, enDolar, impresoraEspecial, filterByUserId);
                ImprimirCuponesSiAplica(doctoBE.IID, impresoraEspecial);
                return bufferReturn;
            }




            string bufferLine = "";

            string tipoImpresionDetalle = ((int)tipoImpresionItem.i_unalinea).ToString("N0");
            decimal dCuentaCantidades = 0;

            bool bCantidadEnPzaCaja = ConexionesBD.ConexionBD.CurrentParameters.IPIEZACAJAENTICKET != null && ConexionesBD.ConexionBD.CurrentParameters.IPIEZACAJAENTICKET.Equals("S");

            try
            {



                CTICKET_DETAILD detailD = new CTICKET_DETAILD();
                CTICKET_FOOTERD footerD = new CTICKET_FOOTERD();
                CTICKET_HEADERD headerD = new CTICKET_HEADERD();
                CTICKET_FOOTERBE footerBE = new CTICKET_FOOTERBE();
                CTICKET_HEADERBE headerBE = new CTICKET_HEADERBE();
                CTICKET_DETAILBE[] ListaDetalles = detailD.seleccionarTICKET_DETAIL(doctoId, ((lOpcion1 == Ticket._OPCION_IMPRESION_RECARGAS) ? true : false), filterByUserId, null);
                CSUCURSALBE sucursalBE = new CSUCURSALBE();



                string importeDescuento = "";

                string strReturn = "";


                string[] splitSeparator = new string[] { "\r\n" };

                int iXLetraRenglon = 0;
                string cantidadConLetra;
                decimal doctoKilogramos = 0.0m, doctoPiezas = 0.0m, doctoCajas = 0.0m;

                footerBE.IDOCTOID = doctoId;
                headerBE.IDOCTOID = doctoId;

                headerBE = headerD.seleccionarTICKET_HEADER(headerBE, null);
                footerBE = footerD.seleccionarTICKET_FOOTER(footerBE, ((lOpcion1 == Ticket._OPCION_IMPRESION_RECARGAS) ? true : false), null);

                if(filterByUserId != null && filterByUserId.HasValue && filterByUserId.Value != 0)
                    AjustarHeaderFooterADetalles(ListaDetalles, ref footerBE, ref headerBE);


                headerD.seleccionarTICKET_CAJASPIEZAS(headerBE, ref doctoKilogramos, ref doctoPiezas, ref doctoCajas, null);

                Ticket ticket = new Ticket();

                // MessageBox.Show("entra 1");

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
                                    sucursalBE = DatosSucursal(headerBE.ISUCURSALTID);
                                    bufferLine = "RECEPCION COMPRA";
                                    break;
                                case Ticket._OPCION_IMPRESION_COMPRA_DEVOLUCION:
                                    //ticket.AddHeaderLine("DEVOLUCION COMPRA");
                                    sucursalBE = DatosSucursal(headerBE.ISUCURSALTID);
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
                                    ticket.AddHeaderLine("NOTA DE VENTA");
                                }
                                else
                                {
                                    ticket.AddHeaderLine("COTIZACION");
                                }
                            }


                            //Nombre de farmacia
                            AddNombreDeFarmacia(ref ticket, headerBE);


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
                    case DBValues._DOCTO_TIPO_VENTA_FUTURO:
                        {

                            if (!(bool)headerBE.isnull["ISUBTIPODOCTOID"] && headerBE.ISUBTIPODOCTOID == 8 && sucursalBE != null)
                            {
                                ticket.AddHeaderLine("TRASLADO A SUCURSAL : " + sucursalBE.ICLAVE);
                                ticket.AddHeaderLine("SUCURSAL DESTINO: " + sucursalBE.INOMBRE);
                            }

                            if (headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA_FUTURO)
                            {
                                ticket.AddHeaderLine("VENTA A FUTURO");
                            }
                            else
                            {
                                ticket.AddHeaderLine("VENTA DE MOSTRADOR");
                            }


                            if (headerBE.IPERSONAID != DBValues._CLIENTEMOSTRADOR)
                            {
                                CPERSONABE clienteBE = DatosPersona(headerBE.IPERSONAID);
                                if (clienteBE != null)
                                {
                                    AddDatosCliente(ref ticket, clienteBE);
                                }

                            }

                            bool ticketImpresionDesc2 = ConexionesBD.ConexionBD.CurrentParameters.ITICKET_IMPR_DESC2 != null && ConexionesBD.ConexionBD.CurrentParameters.ITICKET_IMPR_DESC2.Equals("S");

                            if (ConexionesBD.ConexionBD.CurrentParameters.IPIEZACAJAENTICKET != null && ConexionesBD.ConexionBD.CurrentParameters.IPIEZACAJAENTICKET.Equals("S"))
                            {
                                tipoImpresionDetalle = ticketImpresionDesc2 ? ((int)tipoImpresionItem.i_treslineas_pzacaja).ToString("N0") : ((int)tipoImpresionItem.i_doslineas_pzacaja).ToString("N0");
                            }
                            else
                            {
                                tipoImpresionDetalle = ticketImpresionDesc2 ? ((int)tipoImpresionItem.i_treslineas).ToString("N0") : ((int)tipoImpresionItem.i_doslineas).ToString("N0");
                            }


                        }
                        break;


                    case DBValues._DOCTO_TIPO_PEDIDOMOVIL:
                        if (ConexionesBD.ConexionBD.CurrentParameters.IPIEZACAJAENTICKET != null && ConexionesBD.ConexionBD.CurrentParameters.IPIEZACAJAENTICKET.Equals("S"))
                        {
                            tipoImpresionDetalle = ((int)tipoImpresionItem.i_doslineas_pzacaja).ToString("N0");
                        }
                        else
                        {
                            tipoImpresionDetalle = ((int)tipoImpresionItem.i_doslineas).ToString("N0");
                        }

                        if (headerBE.IPERSONAID != DBValues._CLIENTEMOSTRADOR)
                        {
                            CPERSONABE clienteBE = DatosPersona(headerBE.IPERSONAID);
                            if (clienteBE != null)
                            {
                                AddDatosCliente(ref ticket, clienteBE, true);
                            }

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
                            else if(lOpcion1 == Ticket._OPCION_IMPRESION_COMPRA_RECEPCION ||
                                    lOpcion1 == Ticket._OPCION_IMPRESION_COMPRA_DEVOLUCION)
                            {

                                ticket.AddHeaderLine("#DOCUMENTO: " + headerBE.IREFERENCIA);
                                if (sucursalBE != null)
                                {
                                    ticket.AddHeaderLine("SUC. ORIGEN : " + sucursalBE.INOMBRE);
                                }
                                if (!(bool)footerBE.isnull["IFECHAFACTURA"])
                                {
                                    ticket.AddHeaderLine("FECHA FACTURA : " + footerBE.IFECHAFACTURA.ToString("dd/MM/yyyy"));
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


                //referencia a 
                if((headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA ||
                   headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA) && 
                   lOpcion1 == Ticket._OPCION_IMPRESION_COMPRA_RECEPCION)
                {

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
                if (headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA_FUTURO)
                {
                    ticket.AddHeaderLine("VENTA A FUTURO");
                }

                ticket.AddHeaderLine(new string('=', Ticket.maxChar));

                ticket.AddHeaderLine("DESCRIPCION               ");

                if (headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA)
                    ticket.AddHeaderLine("CANTIDAD      COSTO     %IVA    IMPORTE");
                else
                {

                    if (tipoImpresionDetalle == ((int)tipoImpresionItem.i_doslineas_pzacaja).ToString("N0"))
                    {
                        ticket.AddHeaderLine("CANTIDAD          PRECIO        IMPORTE");
                    }
                    else
                    {
                        ticket.AddHeaderLine("CANTIDAD      PRECIO    %IVA    IMPORTE");
                    }
                }

                ticket.AddHeaderLine(new string('-', Ticket.maxChar));

                decimal dCantidad = 0, dSubTotalItem = 0, dIvaItem = 0, dDescuentoItem = 0, dIepsItem = 0;
                decimal dSubTotalSumarizado = 0, dIvaSumarizado = 0, dIepsSumarizado = 0;
                decimal dDescuentoValeSumarizado = 0;
                decimal dTotalItem = 0, dPrecioConImpItem = 0;
                decimal dTotalSumarizado = 0;

                long lastMovtoId = 0;
                bool bImprimirDescripcion2 = ConexionesBD.ConexionBD.CurrentParameters.ITICKET_IMPR_DESC2 != null &&
                                            ConexionesBD.ConexionBD.CurrentParameters.ITICKET_IMPR_DESC2.Equals("S");



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
                                if (headerBE.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_COMPRAIMPORTADA)
                                {

                                    dCantidad = detailItem.ICANTIDADSURTIDA;
                                    dSubTotalItem = detailItem.ICANTIDADSURTIDA * (detailItem.ISUBTOTAL / (detailItem.ICANTIDADNOMINAL == 0 ? 1 : detailItem.ICANTIDADNOMINAL));
                                }
                                else
                                {
                                    dSubTotalItem = detailItem.ICANTIDAD * detailItem.IPRECIO;
                                }
                                break;
                            case Ticket._OPCION_IMPRESION_COMPRA_DEVOLUCION:
                                dCantidad = detailItem.IFALTANTE;
                                dSubTotalItem = detailItem.IFALTANTE * detailItem.IPRECIO;
                                break;
                            case Ticket._OPCION_IMPRESION_COMPRA:

                                if(headerBE.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_COMPRAIMPORTADA )
                                {
                                    dCantidad = detailItem.ICANTIDADSURTIDA;
                                    dSubTotalItem = detailItem.ICANTIDADSURTIDA * (detailItem.ISUBTOTAL / (detailItem.ICANTIDADNOMINAL == 0 ? 1 : detailItem.ICANTIDADNOMINAL));
                                }
                                else
                                {
                                    dCantidad = detailItem.ICANTIDADNOMINAL;
                                    dSubTotalItem = detailItem.ISUBTOTAL;

                                }

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

                                ticket.AddItem(bCantidadEnPzaCaja && detailItem.IDESCPZACAJA != null && detailItem.IDESCPZACAJA.Length > 0 ? detailItem.IDESCPZACAJA : dCantidad.ToString("N3"),
                                                (detailItem.IES_COMODIN.Equals("S") ? detailItem.IDESCRIPCION1 + " " + detailItem.IDESCRIPCION2 + " " + detailItem.IDESCRIPCION3 : detailItem.IDESCRIPCION1 + (bImprimirDescripcion2 && detailItem.IDESCRIPCION2 != null ? " " + detailItem.IDESCRIPCION2 : "")),
                                                dTotalItem.ToString("N2"),
                                                 dPrecioConImpItem.ToString("N2"),
                                                "-",
                                                 detailItem.ILOTE,
                                                 ((bool)detailItem.isnull["IFECHAVENCE"]) ? "" : detailItem.IFECHAVENCE.ToString("dd/MM/yy"),
                                                "",
                                                 ((bool)detailItem.isnull["ITIPORECARGA"]) ? "" : detailItem.ITIPORECARGA,
                                                tipoImpresionDetalle,
                                                (lOpcion1 == Ticket._OPCION_IMPRESION_TRASLADO_DEVOLUCION || lOpcion1 == Ticket._OPCION_IMPRESION_COMPRA_DEVOLUCION) ? detailItem.IMOTIVODEVOLUCION : "");

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

                                //compras recepcion
                                if (!(bool)headerBE.isnull["ISUBTIPODOCTOID"] && headerBE.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_COMPRAIMPORTADA)
                                {
                                    dTotal = dTotalItem;
                                }


                                if (detailItem.ISTRPEDIMENTO != null)
                                {
                                    nota = nota + " " + detailItem.ISTRPEDIMENTO;
                                }


                                if ((headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA &&
                                    ConexionesBD.ConexionBD.CurrentParameters.ITICKET_DESC_VALE_AL_FINAL != null &&
                                    ConexionesBD.ConexionBD.CurrentParameters.ITICKET_DESC_VALE_AL_FINAL.Equals("S")) &&
                                    detailItem.IDESCUENTOVALE > 0)
                                {
                                    nota = nota + " Usted ahorro " + detailItem.IDESCUENTOVALE.ToString();

                                    dTotal = Decimal.Round(detailItem.ITOTAL + detailItem.IDESCUENTOVALE, 2);
                                    dPrecioConIva = Decimal.Round(dTotal / dCantidad, 2);
                                }


                                ticket.AddItem(detailItem.IESKIT != null && detailItem.IESKIT.Equals("S") && usuarioTienePermisoDesgloseKit ? "" : (bCantidadEnPzaCaja && detailItem.IDESCPZACAJA != null && detailItem.IDESCPZACAJA.Length > 0 ? detailItem.IDESCPZACAJA : dCantidad.ToString("N3")),
                                                 (detailItem.IES_COMODIN.Equals("S") ? detailItem.IDESCRIPCION1 + " " + detailItem.IDESCRIPCION2 + " " + detailItem.IDESCRIPCION3 : detailItem.IDESCRIPCION1 + (bImprimirDescripcion2 && detailItem.IDESCRIPCION2 != null ? " " + detailItem.IDESCRIPCION2 : "")),
                                                 enDolar ? detailItem.IIMPORTEENDOLAR.ToString("N3") : ((headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA) ? (dTotal).ToString("N2") : dTotal.ToString("N2")),
                                                 enDolar ? detailItem.ICOSTOENDOLAR.ToString("N3") : dPrecioConIva.ToString("N2"),
                                                 enDolar ? "" : detailItem.IIVA.ToString("N2"),
                                                 detailItem.ILOTE,
                                                 ((bool)detailItem.isnull["IFECHAVENCE"]) ? "" : detailItem.IFECHAVENCE.ToString("dd/MM/yy"),
                                                "",
                                                 detailItem.ITIPORECARGA,
                                                tipoImpresionDetalle,
                                                nota);





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
                                                    nota2);

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


                            if (headerBE.ISUBTIPODOCTOID != DBValues._DOCTO_SUBTIPO_COMPRAIMPORTADA)
                            {
                                ticket.AddTotal("Saldo:", footerBE.ISALDO.ToString("N2"));
                            }
                            
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


                if (ConexionesBD.ConexionBD.CurrentParameters.IPIEZACAJAENTICKET != null && ConexionesBD.ConexionBD.CurrentParameters.IPIEZACAJAENTICKET.Equals("S"))
                {
                    ticket.AddFooterLine(new string('-', Ticket.maxChar));
                    ticket.AddFooterLine("Cajas: " + doctoCajas.ToString("N0") + "    Piezas: " + doctoPiezas.ToString("N2"));
                    ticket.AddFooterLine(new string('-', Ticket.maxChar));
                }

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

                            ticket.AddTotal("Ud se ahorro sin/imp. : ", footerBE.IDESCUENTO_TOTAL.ToString("N2"));
                        }

                    }
                }


                //si estamos en una devolucion agregar el motivo de devolucion
                if (doctoBE.ITIPODIFERENCIAINVENTARIOID > 0 && headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO || headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA_DEVO)
                {
                    CTIPODIFERENCIAINVENTARIOD tipoDifD = new CTIPODIFERENCIAINVENTARIOD();
                    CTIPODIFERENCIAINVENTARIOBE tipoDifBE = new CTIPODIFERENCIAINVENTARIOBE();
                    tipoDifBE.IID = doctoBE.ITIPODIFERENCIAINVENTARIOID;
                    tipoDifBE = tipoDifD.seleccionarTIPODIFERENCIAINVENTARIO(tipoDifBE, null);
                    if(tipoDifBE != null)
                        ticket.AddFooterLine("Motivo:"  + (tipoDifBE.IDESCRIPCION != null ? tipoDifBE.IDESCRIPCION : tipoDifBE.INOMBRE));
                }



                if (footerBE.INOTAPAGO != null && footerBE.INOTAPAGO.Trim().Length > 0)
                {

                    ticket.AddFooterLine("Nota : " + footerBE.INOTAPAGO);
                }



                if (headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA && 
                    (headerBE.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_VENDMOVIL || headerBE.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_COMPRAMOVIL) &&
                    (doctoBE.IOBSERVACION != null && doctoBE.IDESCRIPCION != null))
                {

                    ticket.AddFooterLine("Notas desde movil : " );
                    if(doctoBE.IOBSERVACION != null)
                        ticket.AddFooterLine(doctoBE.IOBSERVACION);

                    if(doctoBE.IDESCRIPCION != null)
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


                AgregarLeyendaPlazoSiAplica(ref ticket, doctoBE.IPLAZOID);

                



                string nombreImpresora = impresoraEspecial != null && impresoraEspecial.Length > 0 ? impresoraEspecial :
                                            ConexionesBD.ConexionBD.currentPrinter;

                if (lOpcion1 == Ticket._OPCION_IMPRESION_RECARGAS)
                {
                    ticket.PrintTicketDirect(ConexionesBD.ConexionBD.CurrentPrinterRecargas, false, (int)ConexionesBD.ConexionBD.CurrentParameters.ITAMANOLETRATICKET);//"recargas"
                }
                else
                {
                    ticket.PrintTicketDirect(nombreImpresora);//ConexionesBD.ConexionBD.currentPrinter);
                }

                ImprimirCuponesSiAplica(doctoBE.IID, impresoraEspecial);

                return strReturn;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message + ex.StackTrace);
                return "";
            }


        }

        private static void AjustarHeaderFooterADetalles(CTICKET_DETAILBE[] listaDetalles, ref CTICKET_FOOTERBE footerBE, 
                        ref CTICKET_HEADERBE headerBE)
        {
            footerBE.ISUBTOTAL = listaDetalles.Sum(y => y.ISUBTOTAL);
            footerBE.ITOTAL = listaDetalles.Sum(y => y.ITOTAL);
            footerBE.ITOTAL_CON_LETRA = "";

            headerBE.IVENDEDOR = ConexionesBD.ConexionBD.CurrentUser.INOMBRE;
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


        public static string strFixedSize(string bufferLine, int iSize, bool padRight)
        {
            if (padRight)
                return bufferLine.Substring(0, Math.Min(iSize, bufferLine.Length)).PadRight(iSize);
            else
                return bufferLine.Substring(0, Math.Min(iSize, bufferLine.Length)).PadLeft(iSize);
        }


        private static void AddDatosClienteApartado(ref Ticket ticket, CPERSONAAPARTADOBE personaBE)
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




        private static void AddDatosCliente(ref Ticket ticket, CPERSONABE personaBE, bool soloNombre = false)
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


            if (soloNombre)
                return;


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




        private static void AddDatosTienda(ref Ticket ticket, CTICKET_HEADERBE headerBE)
        {


            ticket.AddHeaderLine("RFC: " + headerBE.IRFC);


            /*if (!(bool)headerBE.isnull["IDOMICICIO"])
            {
                if (headerBE.IDOMICICIO.TrimEnd().Length > 32)
                {
                    ticket.AddHeaderLine("Calle: " + headerBE.IDOMICICIO.TrimEnd().Substring(0, 32));
                    if (headerBE.IDOMICICIO.TrimEnd().Length > 66)
                        ticket.AddHeaderLine("       " + headerBE.IDOMICICIO.TrimEnd().Substring(32, 66));
                    else
                        ticket.AddHeaderLine("       " + headerBE.IDOMICICIO.TrimEnd().Substring(32));
                }
                else
                    ticket.AddHeaderLine("Calle: " + headerBE.IDOMICICIO.TrimEnd());
            }*/

            string bufferLine = ((!(bool)headerBE.isnull["IDOMICICIO"]) ? headerBE.IDOMICICIO.TrimEnd() : "") +
                           " " + ((!(bool)headerBE.isnull["INUMEROEXTERIOR"]) ? headerBE.INUMEROEXTERIOR.TrimEnd() : "") +
                           " " + ((!(bool)headerBE.isnull["INUMEROINTERIOR"]) ? headerBE.INUMEROINTERIOR.TrimEnd() : "");


            if (bufferLine.TrimEnd().Length >= 0)
            {
                if (bufferLine.TrimEnd().Length > 32)
                {
                    ticket.AddHeaderLine("Calle: " + bufferLine.TrimEnd().Substring(0, 32));
                    if (bufferLine.TrimEnd().Length > 64)
                        ticket.AddHeaderLine("       " + bufferLine.TrimEnd().Substring(32, 64));
                    else
                        ticket.AddHeaderLine("       " + bufferLine.TrimEnd().Substring(32));
                }
                else
                    ticket.AddHeaderLine("Calle: " + bufferLine.TrimEnd());
            }



            if (!(bool)headerBE.isnull["ICODIGOPOSTAL"])
            {
                if (headerBE.ICODIGOPOSTAL.TrimEnd().Length > 32)
                {
                    ticket.AddHeaderLine("CP.  : " + headerBE.ICODIGOPOSTAL.TrimEnd().Substring(0, 32));
                }
                else
                    ticket.AddHeaderLine("CP.  : " + headerBE.ICODIGOPOSTAL.TrimEnd());
            }


            if (!(bool)headerBE.isnull["ICOLONIA"])
            {
                if (headerBE.ICOLONIA.TrimEnd().Length > 32)
                {
                    ticket.AddHeaderLine("Col. : " + headerBE.ICOLONIA.TrimEnd().Substring(0, 32));
                }
                else
                {
                    ticket.AddHeaderLine("Col. : " + headerBE.ICOLONIA.TrimEnd());
                }
            }


            if (!(bool)headerBE.isnull["ITELEFONO"])
            {
                if (headerBE.ITELEFONO.TrimEnd().Length > 32)
                {
                    ticket.AddHeaderLine("Tel. : " + headerBE.ITELEFONO.TrimEnd().Substring(0, 32));
                }
                else
                {
                    ticket.AddHeaderLine("Tel. : " + headerBE.ITELEFONO.TrimEnd());
                }
            }
            else
            {
                ticket.AddHeaderLine("Tel. : ");
            }
        }





        private static void AddNombreDeFarmacia(ref Ticket ticket, CTICKET_HEADERBE headerBE)
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



        private static void AddDatosDeProveedor(ref Ticket ticket, CPERSONABE proveedorBE)
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



        public static void ImprimirCuponesSiAplica(long doctoId,string impresoraEspecial)
        {

            if (ConexionesBD.ConexionBD.CurrentParameters.IMANEJACUPONES.Equals("N"))
                return;

            CPROMOCIOND promocionD = new CPROMOCIOND();

            CCUPONESAPLICADOSD cuponesAplicadosDao = new CCUPONESAPLICADOSD();
            List<CCUPONESAPLICADOSBE> cuponesAplicados = cuponesAplicadosDao.SeleccionarCuponesXDocto(doctoId, null);

            if (cuponesAplicados == null || cuponesAplicados.Count == 0)
                return;

            if(cuponesAplicados.First().IACTIVO != "S")
            {

                if (MessageBox.Show("Los cupones de este documento ya fueron impresos. Desea reimprimirlos? ",
                                    "Confirmacion",
                                    MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return ;
                }
            }


            string strTicketFrx = "Coupon.frx";

            FastReport.Report report = new FastReport.Report();
            report.Load(FastReportsConfig.getPathForFile(strTicketFrx, FastReportsTipoFile.desistema));
            FastReport.Utils.Config.ReportSettings.ShowProgress = false;

            report.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;

            //report.PrintSettings.ShowDialog = false;

            report.SetParameterValue("pdoctoid", doctoId);

            string nombreImpresora = impresoraEspecial != null && impresoraEspecial.Length > 0 ? impresoraEspecial :
                                        ConexionesBD.ConexionBD.currentPrinter;
            report.PrintSettings.Printer = nombreImpresora; //ConexionesBD.ConexionBD.currentPrinter


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

            try
            {
                foreach (CCUPONESAPLICADOSBE cupon in cuponesAplicados)
                {

                    cupon.IACTIVO = "N";
                    cuponesAplicadosDao.CambiarEstadoActivo(cupon, null);
                }
            }
            catch  { }


        }


        //private static void AgregarCuponesSiAplica(ref Ticket ticket, long personaId,  long doctoId)
        //{
        //    if (ConexionesBD.ConexionBD.CurrentParameters.IMANEJACUPONES.Equals("N"))
        //        return;

        //    CCUPONESAPLICADOSD cuponesAplicadosDao = new CCUPONESAPLICADOSD();
        //    List<CCUPONESAPLICADOSBE> cuponesAplicados = cuponesAplicadosDao.SeleccionarCuponesXDocto(doctoId, null);

        //    if (cuponesAplicados == null || cuponesAplicados.Count == 0)
        //        return;

        //    CPERSONABE personaBE = DatosPersona(personaId);


        //    CPROMOCIOND promocionD = new CPROMOCIOND();

        //    foreach (CCUPONESAPLICADOSBE cupon in cuponesAplicados)
        //    {
        //        bool bMostrarDatosCliente = false;

        //        CPROMOCIONBE promocionBE = new CPROMOCIONBE();
        //        if (cupon.IPROMOCIONCUPONID > 0)
        //        {
        //            promocionBE.IID = cupon.IPROMOCIONCUPONID;
        //            promocionBE = promocionD.seleccionarPROMOCION(promocionBE, null);
        //            if (promocionBE != null)
        //                bMostrarDatosCliente = promocionBE.IMOSTRARDATOSCLIENTE == "S";

        //        }


        //        for (int i = 0; i < cupon.ICANTIDAD; i++)
        //        {
        //            ticket.AddFooterLine("");
        //            ticket.AddFooterLine(new string('-', Ticket.maxChar));


        //            ticket.AddFooterLine("CUPON");
        //            ticket.AddFooterLine(cupon.ILEYENDA != null ? cupon.ILEYENDA : "");

        //            if (bMostrarDatosCliente && personaBE != null)
        //            {

        //                string bufferLine = "";

        //                if (!(bool)personaBE.isnull["INOMBRES"])
        //                    bufferLine = personaBE.INOMBRES.Trim();

        //                if (!(bool)personaBE.isnull["IAPELLIDOS"])
        //                    bufferLine += " " + personaBE.IAPELLIDOS.Trim();


        //                if (bufferLine.TrimEnd().Length > 32)
        //                {
        //                    ticket.AddFooterLine("Nombre: " + bufferLine.TrimEnd().Substring(0, 32));
        //                    if (bufferLine.TrimEnd().Length > 64)
        //                        ticket.AddFooterLine("       " + bufferLine.TrimEnd().Substring(32, 64));
        //                    else
        //                        ticket.AddFooterLine("       " + bufferLine.TrimEnd().Substring(32));
        //                }
        //                else
        //                    ticket.AddFooterLine("Nombre: " + bufferLine.TrimEnd());
        //            }


        //            ticket.AddFooterLine(new string('-', Ticket.maxChar));
        //            ticket.AddFooterLine("");
        //        }
        //    }
        //}



        private static void AgregarLeyendaPlazoSiAplica(ref Ticket ticket, long plazoId)
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




        public static string GetReceiptPrinter()
        {

            CPERSONABE usuario = ConexionesBD.ConexionBD.CurrentUser;

            if (usuario != null && usuario.INOMBREIMPRESORA != null && usuario.INOMBREIMPRESORA.Trim().Length == 0)
                return usuario.INOMBREIMPRESORA;

            CCAJAD cajaD = new CCAJAD();
            CCAJABE cajaBE = new CCAJABE();
            cajaBE.IID = ConexionesBD.ConexionBD.CurrentCompania.IEM_CAJA;

            cajaBE = cajaD.seleccionarCAJA(cajaBE, null);

            if (cajaBE == null || cajaBE.INOMBREIMPRESORA == null || cajaBE.INOMBREIMPRESORA.Trim().Length == 0)
            {
                return ConexionesBD.ConexionBD.CurrentParameters.ITICKETDEFAULTPRINTER;
            }

            return cajaBE.INOMBREIMPRESORA.Split('|')[0];
        }




        public static string GetReceiptComandaPrinter()
        {

            CCAJAD cajaD = new CCAJAD();
            CCAJABE cajaBE = new CCAJABE();
            cajaBE.IID = ConexionesBD.ConexionBD.CurrentCompania.IEM_CAJA;

            cajaBE = cajaD.seleccionarCAJA(cajaBE, null);

            if (cajaBE == null || cajaBE.IIMPRESORACOMANDA == null || cajaBE.IIMPRESORACOMANDA.Trim().Length == 0)
            {
                return ConexionesBD.ConexionBD.CurrentParameters.IIMPRESORACOMANDA;
            }

            return cajaBE.IIMPRESORACOMANDA.Split('|')[0];
        }

        public static string ImprimirTicketFromFastReport(string rutaReporte, 
                                                        Dictionary<string, object> dictionary, 
                                                            int iNumCopias, 
                                                            string impresora)
        {
            
            FastReport.Report report = new FastReport.Report();
            report.Load(rutaReporte);
            FastReport.Utils.Config.ReportSettings.ShowProgress = false;

            report.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report.SetParameterValue("US_ID", ConexionesBD.ConexionBD.CurrentUser.IID);
            report.SetParameterValue("US_NAME", ConexionesBD.ConexionBD.CurrentUser.INOMBRE);


            foreach (KeyValuePair<string, object> entry in dictionary)
            {
                report.SetParameterValue(entry.Key, entry.Value);
            }

            report.PrintSettings.Printer = impresora;


            report.PrintSettings.ShowDialog = false;
            report.Prepare();

            try
            {
                for (int i = 0; i < iNumCopias; i++)
                {
                    report.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cheque que la impresora este conectada " + ex.Message);
            }

            return "S";
        }

    }

}
