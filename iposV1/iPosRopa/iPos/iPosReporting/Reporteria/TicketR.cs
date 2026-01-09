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

namespace iPosReporting
{




    enum tipoImpresionItemR { i_unalinea, i_doslineas, i_treslineas };
    public class RawPrinterHelperR
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





    public class TicketR
    {
        ArrayList qrData = new ArrayList();
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



        

        public const long _OPCION_IMPRESION_COMPRA_RECEPCION = 0;
        public const long _OPCION_IMPRESION_COMPRA_DEVOLUCION = 1;
        public const long _OPCION_IMPRESION_COMPRA = 2;
        public const long _OPCION_IMPRESION_RECARGAS = 3;


        public TicketR()
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

        public void AddQRLine(string line)
        {
            qrData.Add(line);
        }

        public void AddHeaderLine(string line)
        {
            headerLines.Add(line);
        }

        
        public void AddHeaderLine(string line, bool bPuedeCrecer)
        {
            if(!bPuedeCrecer)
                headerLines.Add(line);
            else
            {
                IEnumerable<string> bufferLines = SplitByLength(line, this.MaxChar);
                if(bufferLines != null)
                {
                    foreach(String str in bufferLines)
                    {
                        headerLines.Add(str);
                    }
                }
            }
        }
        
        
        public  IEnumerable<string> SplitByLength( string str, int maxLength)
        {
            int index = 0;
            while (index + maxLength < str.Length)
            {
                yield return str.Substring(index, maxLength);
                index += maxLength;
            }

            yield return str.Substring(index);
        }
        public void AddSubHeaderLine(string line)
        {
            subHeaderLines.Add(line);
        }
        public void AddItem(string cantidad, string item, string price, string costoUnitario, string impuesto, string lote, string fechacad, string importeDescuento, string tipoRecarga, string tipo)
        {
            OrderItem newItem = new OrderItem('?');
            items.Add(newItem.GenerateItem(cantidad, item, price, costoUnitario, impuesto, lote, fechacad, importeDescuento, tipoRecarga, tipo));
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




        public void PrintTicketDirect(string printer)
        {

            PrintTicketDirect(printer, true);
        }

        public void PrintTicketDirect(string printer, bool abrirCajon)
        {
            StringBuilder printingStr = new StringBuilder();

#if !DEBUG
                if (abrirCajon)
                    OpenDrawer(printer);
#endif
            PrintQR(printer);

            PrintReceiptHeader(printer, ref printingStr);

            PrintItems(printer, ref printingStr);

            PrintReceiptFooter(printer, ref printingStr);

            PrintText(printer, printingStr.ToString());

#if !DEBUG
                CutPaper(printer);
#endif

        }
        public static void DisconnectFromPrinter(string printer)
        {
        }

        public static void ConnectToPrinter(string printer)
        {
        }

        public static string GetReceiptPrinter(CPARAMETROBE parametro)
        {
            if(ConexionesBD.ConexionBD.CurrentCompania != null)
            {
                return GetReceiptPrinter(parametro, ConexionesBD.ConexionBD.CurrentCompania, ConexionesBD.ConexionBD.CurrentUser);
            }

            return parametro.ITICKETDEFAULTPRINTER;
        }

        public static string GetReceiptPrinter(CPARAMETROBE parametro, CEMPRESASBE currentCompania, CPERSONABE usuario )
        {

            if (usuario != null && usuario.INOMBREIMPRESORA != null && usuario.INOMBREIMPRESORA.Trim().Length == 0)
                return usuario.INOMBREIMPRESORA;

            CCAJAD cajaD = new CCAJAD();
            CCAJABE cajaBE = new CCAJABE();
            cajaBE.IID = currentCompania.IEM_CAJA;

            cajaBE = cajaD.seleccionarCAJA(cajaBE, null);

            if (cajaBE == null || cajaBE.INOMBREIMPRESORA == null || cajaBE.INOMBREIMPRESORA.Trim().Length == 0)
            {
                return parametro.ITICKETDEFAULTPRINTER;
            }

            return cajaBE.INOMBREIMPRESORA.Split('|')[0];
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

                tipoImpresionItemR tipoImpresion;
                try
                {
                    tipoImpresion = (tipoImpresionItemR)int.Parse(ordIt.GetItemTipo(item));
                }
                catch
                {
                    tipoImpresion = tipoImpresionItemR.i_unalinea;
                }

                switch (tipoImpresion)
                {
                    case tipoImpresionItemR.i_unalinea:
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
                    case tipoImpresionItemR.i_doslineas:
                    case tipoImpresionItemR.i_treslineas:
                        {

                            if (tipoImpresion == tipoImpresionItemR.i_treslineas)
                            {
                                line = name.Substring(0, name.Length < 39 ? name.Length : 39);
                                if (name.Length > 39)
                                {
                                    line += name.Substring(39, name.Length - 39);
                                }
                            }
                            else
                            {
                                line = name;
                            }

                            printingStr.Append(line + Environment.NewLine);

                            line = FormatPrintField(ordIt.GetItemCantidad(item), 7, 0) + " ";
                            line += FormatPrintField(ordIt.GetCostoUnitarioPrice(item), 13, 0) + "  ";
                            line += FormatPrintField(ordIt.GetImpuestoPrice(item), 2, 0) + "%";
                            line += FormatPrintField(ordIt.GetItemPrice(item), 13, 0);

                            line = AlignRightText(line.Length) + line;
                            printingStr.Append(line + Environment.NewLine);
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

                    printingStr.Append(line + Environment.NewLine);

                }




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
            RawPrinterHelperR.SendStringToPrinter(printer, text); //Print text
            //if (text.Length <= 60)
            //    RawPrinterHelperR.SendStringToPrinter(printer, text); //Print text
            //else if (text.Length > 60)
            //    RawPrinterHelperR.SendStringToPrinter(printer, TruncateAt(text, 60)); //Print exactly as many characters as the printer allows, truncating the rest.
        }


        public void print_qr_code(String qrdata, String printer)
        {
            int store_len = qrdata.Length + 3;
            byte store_pL = (byte)(store_len % 256);
            byte store_pH = (byte)(store_len / 256);

            IntPtr pUnmanagedBytes2 = new IntPtr(0);
            int nLength;
            bool bSuccess2;

            // QR Code: Select the model
            //              Hex     1D      28      6B      04      00      31      41      n1(x32)     n2(x00) - size of model
            // set n1 [49 x31, model 1] [50 x32, model 2] [51 x33, micro qr code]
            // https://reference.epson-biz.com/modules/ref_escpos/index.php?content_id=140
            byte[] modelQR = { (byte)0x1d, (byte)0x28, (byte)0x6b, (byte)0x04, (byte)0x00, (byte)0x31, (byte)0x41, (byte)0x32, (byte)0x00 };
            


            // QR Code: Set the size of module
            // Hex      1D      28      6B      03      00      31      43      n
            // n depends on the printer
            // https://reference.epson-biz.com/modules/ref_escpos/index.php?content_id=141
            byte[] sizeQR = { (byte)0x1d, (byte)0x28, (byte)0x6b, (byte)0x03, (byte)0x00, (byte)0x31, (byte)0x43, (byte)0x06 };


            //          Hex     1D      28      6B      03      00      31      45      n
            // Set n for error correction [48 x30 -> 7%] [49 x31-> 15%] [50 x32 -> 25%] [51 x33 -> 30%]
            // https://reference.epson-biz.com/modules/ref_escpos/index.php?content_id=142
            byte[] errorQR = { (byte)0x1d, (byte)0x28, (byte)0x6b, (byte)0x03, (byte)0x00, (byte)0x31, (byte)0x45, (byte)0x31 };


            // QR Code: Store the data in the symbol storage area
            // Hex      1D      28      6B      pL      pH      31      50      30      d1...dk
            // https://reference.epson-biz.com/modules/ref_escpos/index.php?content_id=143
            //                        1D          28          6B         pL          pH  cn(49->x31) fn(80->x50) m(48->x30) d1…dk
            byte[] qrByte = Encoding.ASCII.GetBytes(qrdata);
            byte[] startStoreQR = { (byte)0x1d, (byte)0x28, (byte)0x6b, store_pL, store_pH, (byte)0x31, (byte)0x50, (byte)0x30};

            List<byte> bufferByte = new List<byte>();
            bufferByte.AddRange(startStoreQR);
            bufferByte.AddRange(qrByte);

            byte[] storeQR = bufferByte.ToArray();

            
            // QR Code: Print the symbol data in the symbol storage area
            // Hex      1D      28      6B      03      00      31      51      m
            // https://reference.epson-biz.com/modules/ref_escpos/index.php?content_id=144
            byte[] printQR = { (byte)0x1d, (byte)0x28, (byte)0x6b, (byte)0x03, (byte)0x00, (byte)0x31, (byte)0x51, (byte)0x30 };



            nLength = Convert.ToInt32(modelQR.Length);
            pUnmanagedBytes2 = Marshal.AllocCoTaskMem(nLength);
            Marshal.Copy(modelQR, 0, pUnmanagedBytes2, nLength);
            bSuccess2 = RawPrinterHelperR.SendBytesToPrinter(printer, pUnmanagedBytes2, nLength);
            Marshal.FreeCoTaskMem(pUnmanagedBytes2);


            nLength = Convert.ToInt32(sizeQR.Length);
            pUnmanagedBytes2 = Marshal.AllocCoTaskMem(nLength);
            Marshal.Copy(sizeQR, 0, pUnmanagedBytes2, nLength);
            bSuccess2 = RawPrinterHelperR.SendBytesToPrinter(printer, pUnmanagedBytes2, nLength);
            Marshal.FreeCoTaskMem(pUnmanagedBytes2);


            nLength = Convert.ToInt32(errorQR.Length);
            pUnmanagedBytes2 = Marshal.AllocCoTaskMem(nLength);
            Marshal.Copy(errorQR, 0, pUnmanagedBytes2, nLength);
            bSuccess2 = RawPrinterHelperR.SendBytesToPrinter(printer, pUnmanagedBytes2, nLength);
            Marshal.FreeCoTaskMem(pUnmanagedBytes2);


            nLength = Convert.ToInt32(storeQR.Length);
            pUnmanagedBytes2 = Marshal.AllocCoTaskMem(nLength);
            Marshal.Copy(storeQR, 0, pUnmanagedBytes2, nLength);
            bSuccess2 = RawPrinterHelperR.SendBytesToPrinter(printer, pUnmanagedBytes2, nLength);
            Marshal.FreeCoTaskMem(pUnmanagedBytes2);


            byte[] byteData = System.Text.Encoding.UTF32.GetBytes(qrdata);
            nLength = Convert.ToInt32(byteData.Length);
            pUnmanagedBytes2 = Marshal.AllocCoTaskMem(nLength);
            Marshal.Copy(byteData, 0, pUnmanagedBytes2, nLength);
            bSuccess2 = RawPrinterHelperR.SendBytesToPrinter(printer, pUnmanagedBytes2, nLength);
            Marshal.FreeCoTaskMem(pUnmanagedBytes2);

            nLength = Convert.ToInt32(printQR.Length);
            pUnmanagedBytes2 = Marshal.AllocCoTaskMem(nLength);
            Marshal.Copy(printQR, 0, pUnmanagedBytes2, nLength);
            bSuccess2 = RawPrinterHelperR.SendBytesToPrinter(printer, pUnmanagedBytes2, nLength);
            Marshal.FreeCoTaskMem(pUnmanagedBytes2);


            // flush() runs the print job and clears out the print buffer
            /*flush();

            // write() simply appends the data to the buffer
            write(modelQR);

            write(sizeQR);
            write(errorQR);
            write(storeQR);
            write(qrdata.getBytes());
            write(printQR);
            flush();*/
        }


        private void PrintQR(string printer)
        {
            string str = "";
            foreach(string buffer in qrData)
            {
                str += buffer;
            }
            if(str != "")
            {
               // RawPrinterHelperR.SendStringToPrinter(printer, str);
                print_qr_code(str, printer);
                /*int nLength;
                byte[] toSend2; // 10 = line feed // 13 carriage return/form feed 
                toSend2 = new byte[4] { 29, 86, 66, 0 };
                IntPtr pUnmanagedBytes2 = new IntPtr(0);
                nLength = Convert.ToInt32(toSend2.Length);
                pUnmanagedBytes2 = Marshal.AllocCoTaskMem(nLength);
                // Copy the managed byte array into the unmanaged array.
                Marshal.Copy(toSend2, 0, pUnmanagedBytes2, nLength);
                // Send the unmanaged bytes to the printer.
                bool bSuccess2 = RawPrinterHelperR.SendBytesToPrinter(printer, pUnmanagedBytes2, nLength);
                // Free the unmanaged memory that you allocated earlier.
                Marshal.FreeCoTaskMem(pUnmanagedBytes2);*/

            }
           // RawPrinterHelperR.SendStringToPrinter(printer, text); 
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
            bool bSuccess3 = RawPrinterHelperR.SendBytesToPrinter(printer, pUnmanagedBytes3, nLength3);
            // Free the unmanaged memory that you allocated earlier.

            Marshal.FreeCoTaskMem(pUnmanagedBytes3);
        }

        private void PrintTextLine(string printer, string text)
        {

            if (text.Length > 60)
            {
                RawPrinterHelperR.SendStringToPrinter(printer, TruncateAt(text, 60));
                PrintNewLine(printer);
                //printer.PrintNormal(PrinterStation.Receipt, TruncateAt(text, printer.RecLineChars)); //Print exactly as many characters as the printer allows, truncating the rest, no new line character (printer will probably auto-feed for us)
            }
            else if (text.Length <= 60)
            {
                RawPrinterHelperR.SendStringToPrinter(printer, text);
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


        private void OpenDrawer(string printer)
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
            bool bSuccess2 = RawPrinterHelperR.SendBytesToPrinter(printer, pUnmanagedBytes2, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes2);
        }

        private void CutPaper(string printer)
        {
            int nLength;
            byte[] toSend2; // 10 = line feed // 13 carriage return/form feed 
            toSend2 = new byte[4] { 29, 86, 66, 0 };
            IntPtr pUnmanagedBytes2 = new IntPtr(0);
            nLength = Convert.ToInt32(toSend2.Length);
            pUnmanagedBytes2 = Marshal.AllocCoTaskMem(nLength);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(toSend2, 0, pUnmanagedBytes2, nLength);
            // Send the unmanaged bytes to the printer.
            bool bSuccess2 = RawPrinterHelperR.SendBytesToPrinter(printer, pUnmanagedBytes2, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes2);
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
        public string GenerateItem(string cantidad, string itemName, string price, string costoUnitario, string impuesto, string lote, string fechacad, string importeDescuento, string tipoRecarga, string tipo)
        {
            return cantidad + delimitador[0] + itemName + delimitador[0] + price + delimitador[0] + costoUnitario + delimitador[0] + impuesto + delimitador[0] + lote + delimitador[0] + fechacad + delimitador[0] + importeDescuento + delimitador[0] + tipoRecarga + delimitador[0] + tipo;
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

    public class PosPrinterR
    {
        /*
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



        private static void AddDatosClienteApartado(ref TicketR ticket, CPERSONAAPARTADOBE personaBE)
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




        private static void AddDatosCliente(ref TicketR ticket, CPERSONABE personaBE)
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




        private static void AddDatosTienda(ref TicketR ticket, CTICKET_HEADERBE headerBE)
        {


            ticket.AddHeaderLine("RFC: " + headerBE.IRFC);



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





        private static void AddNombreDeFarmacia(ref TicketR ticket, CTICKET_HEADERBE headerBE)
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



        private static void AddDatosDeProveedor(ref TicketR ticket, CPERSONABE proveedorBE)
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
        }*/
        
    }
}
