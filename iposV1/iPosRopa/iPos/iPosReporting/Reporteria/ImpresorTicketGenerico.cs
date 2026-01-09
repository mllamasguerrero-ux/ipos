using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Collections;
using System.IO;
using System.Drawing;
using iPosReporting;

namespace iPos
{


    public class TextoTicket
    {
        public string texto = "";
        public int tamanioLetra = 0;
        public bool saltarLinea = false;
        public bool centered = false;
        public int longitud = 0;
        public bool negrita = false;
        public string caracterRelleno = " ";
        public bool subrayado = false;
        public string alineacionHorz = "Izquierda";
        public bool esCodigoBarras = false;
        public bool esImagenPredefinida = false;
        public string interlineado = "";
        public bool esQRData = false;



        public TextoTicket()
        {
        }
        public TextoTicket(string _texto, int _tamanioLetra, bool _saltarLinea, bool _centered, int _longitud, bool _negrita, string _caracterRelleno, bool _subrayado, string _alineacionHorz)
        {
            texto = _texto;
            tamanioLetra = _tamanioLetra;
            saltarLinea = _saltarLinea;
            centered = _centered;
            longitud = _longitud;
            negrita = _negrita;
            caracterRelleno = _caracterRelleno;
            subrayado = _subrayado;
            alineacionHorz = _alineacionHorz;

            if (centered && longitud > 0 && texto != null)
            {
                texto = centerText(_texto, _longitud, caracterRelleno);
            }

            if (longitud > 0 && texto != null)
            {
                if (texto.Length < longitud)
                {

                    if (alineacionHorz != null && alineacionHorz == "Derecha")
                    {
                        texto = "".PadLeft(longitud - (texto.Length), caracterRelleno.ToCharArray()[0]) + texto;


                    }
                    else
                    {
                        texto = texto + "".PadLeft(longitud - (texto.Length), caracterRelleno.ToCharArray()[0]);
                    }
                }
                else if (texto.Length > longitud)
                {
                    texto = texto.Substring(longitud);
                }
            }
        }


        public TextoTicket(string _texto, int _tamanioLetra, bool _saltarLinea, bool _centered, int _longitud, bool _negrita, string _caracterRelleno, bool _subrayado, string _alineacionHorz, bool _esCodigoBarras) : 
            this(_texto, _tamanioLetra,  _saltarLinea,  _centered,  _longitud,  _negrita,  _caracterRelleno,  _subrayado,  _alineacionHorz)
        {
            

            esCodigoBarras = _esCodigoBarras;

        }


        public TextoTicket(string _texto, int _tamanioLetra, bool _saltarLinea, bool _centered, int _longitud, bool _negrita, string _caracterRelleno, bool _subrayado, string _alineacionHorz, bool _esCodigoBarras, bool _esImagenPredefinida) :
            this(_texto, _tamanioLetra, _saltarLinea, _centered, _longitud, _negrita, _caracterRelleno, _subrayado, _alineacionHorz, _esCodigoBarras)
        {


            esImagenPredefinida = _esImagenPredefinida;

        }


        public TextoTicket(string _texto, int _tamanioLetra, bool _saltarLinea, bool _centered, int _longitud, bool _negrita, string _caracterRelleno, bool _subrayado, string _alineacionHorz, bool _esCodigoBarras, bool _esImagenPredefinida, string _interlineado) :
            this(_texto, _tamanioLetra, _saltarLinea, _centered, _longitud, _negrita, _caracterRelleno, _subrayado, _alineacionHorz, _esCodigoBarras, _esImagenPredefinida)
        {


            interlineado = _interlineado;

        }


        public TextoTicket(string _texto, int _tamanioLetra, bool _saltarLinea, bool _centered, int _longitud, bool _negrita, string _caracterRelleno, bool _subrayado, string _alineacionHorz, bool _esCodigoBarras, bool _esImagenPredefinida, string _interlineado, bool _esQRData) :
            this(_texto, _tamanioLetra, _saltarLinea, _centered, _longitud, _negrita, _caracterRelleno, _subrayado, _alineacionHorz, _esCodigoBarras, _esImagenPredefinida, _interlineado)
        {


            esQRData = _esQRData;

        }

        private string centerText(string texto, int longitud, string relleno)
        {
            if (texto.Length >= longitud)
            {
                return texto;
            }

            int spaceLength = longitud - texto.Length;
            int spaceLengthSide = spaceLength / 2;

            string h = "".PadLeft(spaceLengthSide, relleno.ToCharArray()[0]);

            return h + texto;

        }

    }


    public class ImpresorTicketGenerico
    {
        const int ind_texto = 0;
        const int ind_tamanioLetra = 1;
        const int ind_saltarLinea = 2;
        const int ind_centered = 3;
        const int ind_longitud = 4;
        const int ind_negrita = 5;
        const int ind_caracterRelleno = 6;
        const int ind_subrayado = 7;
        const int ind_alineacionHorz = 8;
        const int ind_contexto = 9;


        static int numCaracteresPorLinea = 55;


        public static void testTicketGenerico()
        {

            string[][] defCadenasFactura = new string[][]
            {
                new string[]
                {
                    "centrada", "Grande", "S", "S",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    "subrayada ", "Chica", "N", "N",
                    "10", "N", " ", "S", "Izquierda", ""
                },
                new string[]
                {
                    "negrita", "Grande2", "S", "S",
                    "8", "S", " ", "N", "Izquierda", ""
                }
            };

            TextoTicket[] testArr = obtenTextoTicketDesdeDefiniciones(defCadenasFactura);
            ImpresorTicketGenerico.imprimir(testArr);
        }


        public static void AgregarLinea(ref List<TextoTicket> txtArray, string texto)
        {
            AgregarLinea(ref txtArray, texto, "Chica", false, false, false, "Izquierda", obtenerLongitudLineaXTamanio("Chica"), " ");

        }


        public static void AgregarLinea(ref List<TextoTicket> txtArray, string texto, string tamanioLetra)
        {
            AgregarLinea(ref txtArray, texto, tamanioLetra, false, false, false, "Izquierda", obtenerLongitudLineaXTamanio(tamanioLetra), " ");

        }

        public static void AgregarLinea(ref List<TextoTicket> txtArray, string texto, string tamanioLetra, bool centrado, bool negrita, bool subrayado)
        {
            AgregarLinea(ref txtArray, texto, tamanioLetra, centrado, negrita, subrayado, "Izquierda", obtenerLongitudLineaXTamanio(tamanioLetra), " ");
        }


        public static void AgregarLinea(ref List<TextoTicket> txtArray, string texto, string tamanioLetra, bool centrado, bool negrita, bool subrayado, string alineacionHorizontal)
        {
            AgregarLinea(ref txtArray, texto, tamanioLetra, centrado, negrita, subrayado, alineacionHorizontal, obtenerLongitudLineaXTamanio(tamanioLetra), " ");
        }


        public static int obtenerLongitudLineaXTamanio( string tamanioLetra)
        {
            int longitudEspacio = 56;

            switch (tamanioLetra)
            {
                case "Chica":
                    longitudEspacio = 56;
                    break;
                case "Grande":
                    longitudEspacio = 42;
                    break;
                case "Grande2":
                    longitudEspacio = 22;
                    break;
            }

            return longitudEspacio;
        }

            public static int obtenerLongitudTotalLineaCompleta(string line, string tamanioLetra, bool centrado)
        {

            int longitudEspacio = line.Length;

            if (centrado)
            {
                switch (tamanioLetra)
                {
                    case "Chica":
                        longitudEspacio = 56;
                        break;
                    case "Grande":
                        longitudEspacio = 42;
                        break;
                    case "Grande2":
                        longitudEspacio = 22;
                        break;
                }
            }

            return longitudEspacio;
        }
        

        public static void AgregarLinea(ref List<TextoTicket> txtArray, string texto, string tamanioLetra, bool centrado, bool negrita, bool subrayado, string alineacionHorizontal, int longLinea, string caracterRelleno)
        {

            if (texto.Length > longLinea)
            {
                int currentChar = 0;
                int textoLenght = texto.Length;
                string line = "";
                while (textoLenght > longLinea)
                {
                    line = texto.Substring(currentChar, longLinea);


                    TextoTicket txtTick = new TextoTicket();

                    int longitudEspacio = obtenerLongitudTotalLineaCompleta(line, tamanioLetra, centrado);

                    txtTick = new TextoTicket(
                            line,
                            tamanioLetra == "Chica" ? 1 : (tamanioLetra == "Grande2" ? 2 : 0),
                            true,
                            centrado,
                            longitudEspacio,
                            negrita,
                            caracterRelleno,
                            subrayado,
                            alineacionHorizontal
                    );

                    txtArray.Add(txtTick);


                    currentChar += longLinea;
                    textoLenght -= longLinea;
                }

                if (textoLenght > 0)
                {

                    TextoTicket txtTick = new TextoTicket();
                    line = texto.Substring(currentChar, textoLenght);

                    int longitudEspacio = obtenerLongitudTotalLineaCompleta(line, tamanioLetra, centrado);


                    txtTick = new TextoTicket(
                            line,
                            tamanioLetra == "Chica" ? 1 : (tamanioLetra == "Grande2" ? 2 : 0),
                            true,
                            centrado,
                            longitudEspacio,
                            negrita,
                            caracterRelleno,
                            subrayado,
                            alineacionHorizontal
                    );

                    txtArray.Add(txtTick);

                    //printingStr.Append(texto.Substring(currentChar, line.Length - currentChar) + Environment.NewLine);
                }


            }
            else
            {
                TextoTicket txtTick = new TextoTicket();

                int longitudEspacio = obtenerLongitudTotalLineaCompleta(texto, tamanioLetra, centrado);

                txtTick = new TextoTicket(
                            texto,
                            tamanioLetra == "Chica" ? 1 : (tamanioLetra == "Grande2" ? 2 : 0),
                            true,
                            centrado,
                            longitudEspacio,
                            negrita,
                            caracterRelleno,
                            subrayado,
                            alineacionHorizontal
                    );

                txtArray.Add(txtTick);
            }

        }


        public static void AgregarCodigoBarras(ref List<TextoTicket> txtArray, string texto, bool centered)
        {


            TextoTicket txtTick = new TextoTicket();
            txtTick = new TextoTicket(
                        texto,
                        0,
                        true,
                        centered,
                        texto.Length,
                        false,
                        " ",
                        false,
                        "Izquierda",
                        true
                );

            txtArray.Add(txtTick);

        }


        public static void AgregarImagenPredefinida(ref List<TextoTicket> txtArray, bool centered)
        {


            TextoTicket txtTick = new TextoTicket();
            txtTick = new TextoTicket(
                        "-",
                        0,
                        true,
                        centered,
                        1,
                        false,
                        " ",
                        false,
                        "Izquierda",
                        false,
                        true
                );

            txtArray.Add(txtTick);

        }


        public static void AgregarInterlineado(ref List<TextoTicket> txtArray, string interlineado)
        {


            TextoTicket txtTick = new TextoTicket();
            txtTick = new TextoTicket(
                        "-",
                        0,
                        true,
                        false,
                        1,
                        false,
                        " ",
                        false,
                        "Izquierda",
                        false,
                        false,
                        interlineado
                );

            txtArray.Add(txtTick);

        }

        public static void AgregarQRData(ref List<TextoTicket> txtArray, string data)
        {


            TextoTicket txtTick = new TextoTicket();
            txtTick = new TextoTicket(
                        data,
                        0,
                        true,
                        false,
                        1,
                        false,
                        " ",
                        false,
                        "Izquierda",
                        false,
                        false,
                        "",
                        true
                );

            txtArray.Add(txtTick);

        }


        public static byte[] StringToByteArrayFastest(string hex)
        {
            if (hex.Length % 2 == 1)
                throw new Exception("The binary key cannot have an odd number of digits");

            byte[] arr = new byte[hex.Length >> 1];

            for (int i = 0; i < (hex.Length >> 1); ++i)
            {
                arr[i] = (byte)((GetHexVal(hex[i << 1]) << 4) + (GetHexVal(hex[(i << 1) + 1])));
            }

            return arr;
        }

        public static int GetHexVal(char hex)
        {
            int val = (int)hex;
            //For uppercase A-F letters:
            return val - (val < 58 ? 48 : 55);
            //For lowercase a-f letters:
            //return val - (val < 58 ? 48 : 87);
            //Or the two combined, but a bit slower:
            //return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));
        }

        public static void testBarCode(string printer)
        {
            byte[] commands = StringToByteArrayFastest("1b28420d000502007d00003132414224252e");

            IntPtr pUnmanagedBytes3 = new IntPtr(0);
            int nLength3 = Convert.ToInt32(commands.Length);
            pUnmanagedBytes3 = Marshal.AllocCoTaskMem(nLength3);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(commands, 0, pUnmanagedBytes3, nLength3);
            // Send the unmanaged bytes to the printer.
            bool bSuccess3 = RawPrinterHelperR.SendBytesToPrinter(printer, pUnmanagedBytes3, nLength3);
            // Free the unmanaged memory that you allocated earlier.

            Marshal.FreeCoTaskMem(pUnmanagedBytes3);
        }


        public static bool PrintBarCode(string msg, string printer)
        {

            List<byte> getBarcode = PrintBarCode_Commands(msg,true);
            if (printer != null && printer != "")
            {

                // imprimirTicketFromData(commands , ipImpresora : ipImpresora!, puertoImpresora : puertoImpresora!)

                byte[] commands = getBarcode.ToArray();
                IntPtr pUnmanagedBytes3 = new IntPtr(0);
                int nLength3 = Convert.ToInt32(commands.Length);
                pUnmanagedBytes3 = Marshal.AllocCoTaskMem(nLength3);
                // Copy the managed byte array into the unmanaged array.
                Marshal.Copy(commands, 0, pUnmanagedBytes3, nLength3);
                // Send the unmanaged bytes to the printer.
                bool bSuccess3 = RawPrinterHelperR.SendBytesToPrinter(printer, pUnmanagedBytes3, nLength3);
                // Free the unmanaged memory that you allocated earlier.

                Marshal.FreeCoTaskMem(pUnmanagedBytes3);
            }
            return true;
        }

        public static List<byte> PrintBarCode_Commands(string msg, bool centered)
        {
            byte GS = 29;
            List<byte> getBarcode = new List<byte>();

            byte[] textoRaw;

            

            try
            {

                msg = msg != null ? msg : "";


                

                

                textoRaw = System.Text.Encoding.UTF8.GetBytes(
                                msg.ToUpper()
                                .Replace("Ñ", char.ConvertFromUtf32(165))
                                .Replace("ñ", char.ConvertFromUtf32(164))
                                .Replace("á", char.ConvertFromUtf32(160))
                                .Replace("Á", char.ConvertFromUtf32(181))
                                .Replace("é", char.ConvertFromUtf32(130))
                                .Replace("É", char.ConvertFromUtf32(144))
                                .Replace("í", char.ConvertFromUtf32(161))
                                .Replace("Í", char.ConvertFromUtf32(214))
                                .Replace("ó", char.ConvertFromUtf32(162))
                                .Replace("Ó", char.ConvertFromUtf32(224))
                                .Replace("ú", char.ConvertFromUtf32(163))
                                .Replace("Ú", char.ConvertFromUtf32(233))
                                //.Replace("-", char.ConvertFromUtf32(15))
                                );

                //textoRaw = System.Text.Encoding.Convert(System.Text.Encoding.UTF8, System.Text.Encoding.GetEncoding("ibm850"), textoRaw);

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("error " + ex.Message);
                return new List<byte>();
            }


            byte alineacion = centered ? (byte)1 : (byte)0;
            getBarcode.AddRange(new byte[] { 27, 97, alineacion });

            getBarcode.AddRange(new byte[] { GS, 76, 2, 2 });// left margin

            getBarcode.AddRange(new byte[] { GS, Convert.ToByte('h'), 80 });// Bardcode Hieght
            getBarcode.AddRange(new byte[] { GS, Convert.ToByte('w'), 1 });//Barcode Width
            getBarcode.AddRange(new byte[] { GS, Convert.ToByte('f'), 0 });//Font for HRI characters
            getBarcode.AddRange(new byte[] { GS, Convert.ToByte('H'), 10 });//Position of HRI characters
            

            getBarcode.AddRange(new byte[] { GS, Convert.ToByte('k'), 69, (byte)msg.Length });//Print Barcode Smb 39
            getBarcode.AddRange(textoRaw);
            getBarcode.AddRange(new byte[] { 0 , 13, 10});// & vbCrLf 'Print Text Under

            

            //getBarcode.AddRange(new byte[] { GS, Convert.ToByte('d'), 3, 13, 10 });// & vbCrLf
            getBarcode.AddRange(new byte[] { 27, Convert.ToByte('@') });//


            getBarcode.AddRange(new byte[] { GS, 76, 0, 0 });// left margin


            getBarcode.AddRange(new byte[] { 27, 97, 0 });


            return getBarcode;
        }



        public static List<byte> PrintPredefinedImage_Commands(bool centered)
        {
            byte alineacion = centered ? (byte)1 : (byte)0;
            return  new List<byte>() { 27, 97, alineacion, 28, 112, 1, 0 , 27, 97,  0};

          
        }


        public static List<byte> print_qr_code(String qrdata)
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
            byte[] startStoreQR = { (byte)0x1d, (byte)0x28, (byte)0x6b, store_pL, store_pH, (byte)0x31, (byte)0x50, (byte)0x30 };

            List<byte> bufferByte = new List<byte>();
            bufferByte.AddRange(startStoreQR);
            bufferByte.AddRange(qrByte);

            byte[] storeQR = bufferByte.ToArray();


            // QR Code: Print the symbol data in the symbol storage area
            // Hex      1D      28      6B      03      00      31      51      m
            // https://reference.epson-biz.com/modules/ref_escpos/index.php?content_id=144
            byte[] printQR = { (byte)0x1d, (byte)0x28, (byte)0x6b, (byte)0x03, (byte)0x00, (byte)0x31, (byte)0x51, (byte)0x30 };

            List<byte> retorno = new List<byte>();
            retorno.AddRange(modelQR);
            retorno.AddRange(sizeQR);
            retorno.AddRange(errorQR);
            retorno.AddRange(storeQR);
            retorno.AddRange(printQR);

            return retorno;
        }



            public static List<byte> LineSpacingShort_Commands()
        {
            return new List<byte>() { 27, 51, 60 };

            //return new List<byte>() { 27, 48 };
        }


        public static List<byte> LineSpacingMini_Commands()
        {
            return new List<byte>() { 27, 51, 50 };
        }

        public static List<byte> LineSpacingNormal_Commands()
        {
            return new List<byte>() { 27, 50 };


        }
        

        public static void testSavePredefinedImage(Bitmap img, string printer)
        {
            byte[] commands = SavePredefinedImage(img).ToArray();

            IntPtr pUnmanagedBytes3 = new IntPtr(0);
            int nLength3 = Convert.ToInt32(commands.Length);
            pUnmanagedBytes3 = Marshal.AllocCoTaskMem(nLength3);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(commands, 0, pUnmanagedBytes3, nLength3);
            // Send the unmanaged bytes to the printer.
            bool bSuccess3 = RawPrinterHelperR.SendBytesToPrinter(printer, pUnmanagedBytes3, nLength3);
            // Free the unmanaged memory that you allocated earlier.

            Marshal.FreeCoTaskMem(pUnmanagedBytes3);
        }

        public static List<byte> SavePredefinedImage(Bitmap img)
        {
            return  ImpresorTicketGenerico.GetLogo(img).ToList<byte>();
        }


        public static TextoTicket[] obtenTextoTicketDesdeDefiniciones(string[][] def)
        {

            TextoTicket txtTick = new TextoTicket();
            List<TextoTicket> txtArray = new List<TextoTicket>();

            for (int x = 0; x < def.Count(); x++)
            {

                txtTick = new TextoTicket(
                        def[x][ind_texto],
                        def[x][ind_tamanioLetra] == "Chica" ? 1 : (def[x][ind_tamanioLetra] == "Grande2" ? 2 : 0),
                        def[x][ind_saltarLinea] == "S" ? true : false,
                        def[x][ind_centered] == "S" ? true : false,
                        int.Parse(def[x][ind_longitud]),
                        def[x][ind_negrita] == "S" ? true : false,
                        def[x][ind_caracterRelleno],
                        def[x][ind_subrayado] == "S" ? true : false,
                        def[x][ind_alineacionHorz]
                );

                txtArray.Add(txtTick);
            }


            return txtArray.ToArray();
        }

        public static TextoTicket[] obtenTextoTicketDesdeDefiniciones(List<List<string>> definitions)
        {
            try
            {
                TextoTicket txtTick = new TextoTicket();
                List<TextoTicket> txtArray = new List<TextoTicket>();

                foreach (List<string> def in definitions)
                {
                    txtTick = new TextoTicket(
                            def[ind_texto],
                            def[ind_tamanioLetra] == "Chica" ? 1 : (def[ind_tamanioLetra] == "Grande2" ? 2 : 0),
                            def[ind_saltarLinea] == "S" ? true : false,
                            def[ind_centered] == "S" ? true : false,
                            int.Parse(def[ind_longitud]),
                            def[ind_negrita] == "S" ? true : false,
                            def[ind_caracterRelleno],
                            def[ind_subrayado] == "S" ? true : false,
                            def[ind_alineacionHorz]
                    );

                    txtArray.Add(txtTick);
                }

                return txtArray.ToArray();
            }
            catch(Exception e)
            {
                return null;
            }
        }


        public static bool imprimirTicket(TextoTicket[] textos, string printer)
        {
            try
            {
                //let commands = NSMutableData()
                List<byte> cmdAux = new List<byte>();

                foreach (TextoTicket textoTicket in textos)
                {
                    byte byteConfig = 0;

                    if(textoTicket.esCodigoBarras)
                    {

                        List<byte> getBarcode = PrintBarCode_Commands(textoTicket.texto, textoTicket.centered);
                        cmdAux.AddRange(getBarcode);

                        continue;
                    }

                    if(textoTicket.esImagenPredefinida)
                    {

                        //si es el simulador de impresora entonces ignora esta sentencia
                        if (printer != null && printer.StartsWith("Two"))
                            continue;


                        List<byte> getBarcode = PrintPredefinedImage_Commands(textoTicket.centered);
                        cmdAux.AddRange(getBarcode);
                        

                        continue;
                    }
                    if (textoTicket.esQRData)
                    {
                        List<byte> getBarcode = print_qr_code(textoTicket.texto);
                        cmdAux.AddRange(getBarcode);

                        continue;
                    }

                    if (textoTicket.interlineado != null && textoTicket.interlineado.Length > 0)
                    {
                        List<byte> interlineadoCommands = new List<byte>();

                        if(textoTicket.interlineado.Equals("Corto"))
                        {

                            interlineadoCommands = LineSpacingShort_Commands();
                            cmdAux.AddRange(interlineadoCommands);
                        }
                        if (textoTicket.interlineado.Equals("Mini"))
                        {

                            interlineadoCommands = LineSpacingMini_Commands();
                            cmdAux.AddRange(interlineadoCommands);
                        }
                        else
                        {
                            
                            interlineadoCommands = LineSpacingNormal_Commands();
                            cmdAux.AddRange(interlineadoCommands);
                        }

                        continue;
                    }


                    switch (textoTicket.tamanioLetra)
                    {
                        case 0:
                            byteConfig = 0;
                            break;
                        case 1:
                            byteConfig = 1;
                            break;
                        case 2:
                            byteConfig = 48;
                            break;
                        default:
                            byteConfig = 0;
                            break;
                    }


                    if (textoTicket.subrayado)
                    {
                        byteConfig += 128;
                    }


                    if (textoTicket.negrita)
                    {
                        byteConfig += 8;
                    }

                    cmdAux.AddRange(new byte[] { 0x1b, 0x21, byteConfig });



                   /* if (textoTicket.subrayado)
                    {
                        cmdAux.AddRange(new byte[] { 0x1b, 0x2d, 0x31 });
                    }
                    else
                    {
                        cmdAux.AddRange(new byte[] { 0x1b, 0x2d, 0x30 });
                    }*/

                    byte[] textoRaw;

                    try
                    {

                        textoTicket.texto = textoTicket.texto != null ? textoTicket.texto : "";

                        textoRaw = System.Text.Encoding.UTF32.GetBytes(
                                        textoTicket.texto
                                        .Replace("Ñ", char.ConvertFromUtf32(165))
                                        .Replace("ñ", char.ConvertFromUtf32(164))
                                        .Replace("á", char.ConvertFromUtf32(160))
                                        .Replace("Á", char.ConvertFromUtf32(181))
                                        .Replace("é", char.ConvertFromUtf32(130))
                                        .Replace("É", char.ConvertFromUtf32(144))
                                        .Replace("í", char.ConvertFromUtf32(161))
                                        .Replace("Í", char.ConvertFromUtf32(214))
                                        .Replace("ó", char.ConvertFromUtf32(162))
                                        .Replace("Ó", char.ConvertFromUtf32(224))
                                        .Replace("ú", char.ConvertFromUtf32(163))
                                        .Replace("Ú", char.ConvertFromUtf32(233))
                                        );

                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show("error " + ex.Message);
                        return false;
                    }

                    cmdAux.AddRange(textoRaw);

                    if (textoTicket.saltarLinea)
                    {
                        cmdAux.Add(0x0a);
                    }
                }

                cmdAux.AddRange(new byte[] { 0x0a, 0x1d, 0x56, 0x41, 0x03 });

                if (printer != null && printer != "")
                {

                    // imprimirTicketFromData(commands , ipImpresora : ipImpresora!, puertoImpresora : puertoImpresora!)

                    byte[] commands = cmdAux.ToArray();
                    IntPtr pUnmanagedBytes3 = new IntPtr(0);
                    int nLength3 = Convert.ToInt32(commands.Length);
                    pUnmanagedBytes3 = Marshal.AllocCoTaskMem(nLength3);
                    // Copy the managed byte array into the unmanaged array.
                    Marshal.Copy(commands, 0, pUnmanagedBytes3, nLength3);
                    // Send the unmanaged bytes to the printer.
                    bool bSuccess3 = RawPrinterHelperR.SendBytesToPrinter(printer, pUnmanagedBytes3, nLength3);
                    // Free the unmanaged memory that you allocated earlier.

                    Marshal.FreeCoTaskMem(pUnmanagedBytes3);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("error " + ex.Message);
                return false;
            }

            return true;


            //return hexadecimalString(commands)
        }




        public static bool imprimirTicketTexto(TextoTicket[] textos, string printer)
        {


            try
            {


                //let commands = NSMutableData()
                List<byte> cmdAux = new List<byte>();
                List<String> headerLines = new List<string>();



                string txtLinea = "";
                foreach (TextoTicket textoTicket in textos)
                {

                    textoTicket.texto = textoTicket.texto != null ? textoTicket.texto : "";
                    txtLinea += textoTicket.texto;

                    if (textoTicket.saltarLinea)
                    {
                        headerLines.Add(txtLinea);
                        txtLinea = "";
                    }


                }

                if (txtLinea != "")
                {
                    headerLines.Add(txtLinea);
                }

                if (printer != null && printer != "")
                {
                    PrintTicketDirect(printer, false, 1, headerLines, numCaracteresPorLinea);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("error " + ex.Message);
                return false;
            }

            return true;


            //return hexadecimalString(commands)
        }




        public static void PrintTicketDirect(string printer, bool abrirCajon, int letra, List<String> headerLines, int maxChar)
        {
            StringBuilder printingStr = new StringBuilder();

            // #if !DEBUG
            if (abrirCajon)
                OpenDrawer(printer);
            if (letra != 0)
                LetraPequena(printer);
            //#endif

            PrintReceiptHeader(headerLines, maxChar, ref printingStr);


            PrintText(printer, printingStr.ToString());

            //#if !DEBUG
            CutPaper(printer);
            if (letra != 0)
                LetraNormal(printer);
            //#endif

        }


        public static void OpenDrawer(string printer)
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

            int nLength2;
            byte[] toSend22; // 10 = line feed // 13 carriage return/form feed 
            toSend22 = new byte[7] { 27, 97, 1, 28, 112, 1, 0 };
            IntPtr pUnmanagedBytes22 = new IntPtr(0);
            nLength2 = Convert.ToInt32(toSend22.Length);
            pUnmanagedBytes22 = Marshal.AllocCoTaskMem(nLength2);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(toSend22, 0, pUnmanagedBytes22, nLength2);
            // Send the unmanaged bytes to the printer.
            bool bSuccess22 = RawPrinterHelperR.SendBytesToPrinter(printer, pUnmanagedBytes22, nLength2);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes22);


        }

        private static void CutPaper(string printer)
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
            bool bSuccess2 = RawPrinterHelperR.SendBytesToPrinter(printer, pUnmanagedBytes2, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes2);
        }



        private static void LetraPequena(string printer)
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
            bool bSuccess2 = RawPrinterHelperR.SendBytesToPrinter(printer, pUnmanagedBytes2, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes2);
        }


        private static void LetraNormal(string printer)
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
            bool bSuccess2 = RawPrinterHelperR.SendBytesToPrinter(printer, pUnmanagedBytes2, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes2);
        }

        private static void PrintReceiptHeader(List<String> headerLines, int maxChar, ref StringBuilder printingStr)
        {
            string line = "";
            int count = 0;

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

        private static void PrintText(string printer, string text)
        {
            SendStringToPrinter(printer, text); //Print text
        }


        public static bool SendStringToPrinter(string szPrinterName, string szString)
        {
            IntPtr pBytes;
            Int32 dwCount;
            // How many characters are in the string?
            dwCount = szString.Length;

#if !DEBUG
                szString = szString.Replace("Ñ", char.ConvertFromUtf32(165))
                                        .Replace("ñ", char.ConvertFromUtf32(164))
                                        .Replace("á", char.ConvertFromUtf32(160))
                                        .Replace("Á", char.ConvertFromUtf32(181))
                                        .Replace("é", char.ConvertFromUtf32(130))
                                        .Replace("É", char.ConvertFromUtf32(144))
                                        .Replace("í", char.ConvertFromUtf32(161))
                                        .Replace("Í", char.ConvertFromUtf32(214))
                                        .Replace("ó", char.ConvertFromUtf32(162))
                                        .Replace("Ó", char.ConvertFromUtf32(224))
                                        .Replace("ú", char.ConvertFromUtf32(163))
                                        .Replace("Ú", char.ConvertFromUtf32(233));
            
#endif
            // Assume that the printer is expecting ANSI text, and then convert
            // the string to ANSI text.
            pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            // Send the converted ANSI string to the printer.
            RawPrinterHelperR.SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
            return true;
        }


        public static void testImpresion()
        {

        }

        public static void imprimir(TextoTicket[] textos)
        {

            string printer = ConexionesBD.ConexionBD.currentPrinter;//IposPrinter3
            ImpresorTicketGenerico.imprimirTicket(textos, printer);
        }

        public static void imprimirTexto(TextoTicket[] textos)
        {

            string printer = ConexionesBD.ConexionBD.currentPrinter;//IposPrinter3
            ImpresorTicketGenerico.imprimirTicketTexto(textos, printer);
        }






        /** Guardar imagen predefinida**/
        public static byte[] GetLogo(Bitmap bmimage)
        {
            //string logo = "";
            //if (!File.Exists(@"C:\bitmap.bmp"))
            //    return null;
            //BitmapData data = GetBitmapData(@"C:\bitmap.bmp");
            BitmapData data = GetBitmapData(bmimage);
            BitArray dots = data.Dots;
            byte[] width = BitConverter.GetBytes(data.Width);

            int offset = 0;
            MemoryStream stream = new MemoryStream();
            BinaryWriter bw = new BinaryWriter(stream);

            bw.Write((char)0x1B);
            bw.Write('@');

            bw.Write((char)0x1B);
            bw.Write('3');
            bw.Write((byte)24);

            while (offset < data.Height)
            {
                bw.Write((char)0x1B);
                bw.Write('*');         // bit-image mode
                bw.Write((byte)33);    // 24-dot double-density
                bw.Write(width[0]);  // width low byte
                bw.Write(width[1]);  // width high byte

                for (int x = 0; x < data.Width; ++x)
                {
                    for (int k = 0; k < 3; ++k)
                    {
                        byte slice = 0;
                        for (int b = 0; b < 8; ++b)
                        {
                            int y = (((offset / 8) + k) * 8) + b;
                            // Calculate the location of the pixel we want in the bit array.
                            // It'll be at (y * width) + x.
                            int i = (y * data.Width) + x;

                            // If the image is shorter than 24 dots, pad with zero.
                            bool v = false;
                            if (i < dots.Length)
                            {
                                v = dots[i];
                            }
                            slice |= (byte)((v ? 1 : 0) << (7 - b));
                        }

                        bw.Write(slice);
                    }
                }
                offset += 24;
                bw.Write((char)0x0A);
            }
            // Restore the line spacing to the default of 30 dots.
            bw.Write((char)0x1B);
            bw.Write('3');
            bw.Write((byte)30);

            bw.Flush();
            byte[] bytes = stream.ToArray();
            return bytes;// Encoding.Default.GetString(bytes);
        }



        public static BitmapData GetBitmapData(Bitmap bitmap)
        {
            var threshold = 127;
            var index = 0;
            double multiplier = 570; // this depends on your printer model. for Beiyang you should use 1000
            double scale = (double)(multiplier / (double)bitmap.Width);
            int xheight = (int)(bitmap.Height * scale);
            int xwidth = (int)(bitmap.Width * scale);
            var dimensions = xwidth * xheight;
            var dots = new BitArray(dimensions);

            for (var y = 0; y < xheight; y++)
            {
                for (var x = 0; x < xwidth; x++)
                {
                    var _x = (int)(x / scale);
                    var _y = (int)(y / scale);
                    var color = bitmap.GetPixel(_x, _y);
                    var luminance = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                    dots[index] = (luminance < threshold);
                    index++;
                }
            }

            return new BitmapData()
            {
                Dots = dots,
                Height = (int)(bitmap.Height * scale),
                Width = (int)(bitmap.Width * scale)
            };
        }

            public BitmapData GetBitmapData(string bmpFileName)
        {
            using (var bitmap = (Bitmap)Bitmap.FromFile(bmpFileName))
            {
                return GetBitmapData(bitmap);
            }
        }

       

    }

    public class BitmapData
    {
        public BitArray Dots
        {
            get;
            set;
        }

        public int Height
        {
            get;
            set;
        }

        public int Width
        {
            get;
            set;
        }
    }

}
