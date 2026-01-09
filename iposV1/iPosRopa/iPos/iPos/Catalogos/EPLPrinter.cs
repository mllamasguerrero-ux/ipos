using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;
using System.Drawing;

namespace iPos
{
    public class EPLPrinter
    {

        private string upc;

        public EPLPrinter(string upc)
        {
            if (upc == null)
            {
                throw new ArgumentNullException("upc");
            }

            this.upc = upc;
        }



        public static string PrintEtiquetaDoble(string printerName, string codigo, string strSuperior, string strInferior,
            string pLabelWidth, string pFormLength, string pFormLength2,
            string[] pTexto, string[] pBarCode,
            int numerocopias, string printerModel, string productPrice, bool anaquel)
        {
            try
            {
                StringBuilder sb;

                if (printerName == null)
                {
                    throw new ArgumentNullException("printerName");
                }

                sb = new StringBuilder();


                sb.AppendLine(string.Format(
                        CultureInfo.InvariantCulture,
                        "q{0}",
                        pLabelWidth));

                sb.AppendLine("rN" ); 
 if(printerModel == "ZDesigner GK420t")
 {
     sb.AppendLine("S1");
     sb.AppendLine("D7");
     sb.AppendLine("ZT");
     sb.AppendLine("JB");
     sb.AppendLine("OD");
     sb.AppendLine("R5,01");
     sb.AppendLine("N");
     sb.AppendLine("A51,6,0,1,2,2,N,\"COMERC. RAMOS       COMERC. RAMOS\"");
     sb.AppendLine("B60,32,0,1,2,3,80,B,\"" + codigo + "\"");
     sb.AppendLine("B490,32,0,1,2,3,80,B,\"" + codigo + "\"");
     sb.AppendLine("A6,143,0,1,1,2,N,\"" + strInferior + "\"");
     sb.AppendLine("A460,143,0,1,1,2,N,\"" + strInferior + "\"");
     sb.AppendLine("A6,170,0,1,1,2,N,\"" + strSuperior + "\"");
     sb.AppendLine("A460,170,0,1,1,2,N,\"" + strSuperior + "\""); 
 }
 else if (printerModel == "BIXOLON SLP-TX400")
 {
     /*sb.AppendLine("S1" ); 
     sb.AppendLine("D7" ); 
     sb.AppendLine("ZT" ); 
     sb.AppendLine("JB" ); 
     sb.AppendLine("OD" ); 
     sb.AppendLine("R5,01" );
     sb.AppendLine("N" );
     /*sb.AppendLine("T50,100,3,1,1,0,0,N,N,’ BIXOLON Label Printer’");
     sb.AppendLine("T50,100,3,1,1,0,0,N,N,’Manufacturer :’V00");
     sb.AppendLine("T50,100,3,1,1,0,0,N,N,V00");
     sb.AppendLine("T50,100,3,1,1,0,0,N,N,’Manufacturer :’C0");
     sb.AppendLine("T50,100,3,1,1,0,0,N,N,C0");*/
     sb.AppendLine("^XA^LH0,0^PW812");
     sb.AppendLine("SW812");
     sb.AppendLine("A26,15,0,3,0,0,0,0,N,N,\"COMERC. RAMOS                    COMERC. RAMOS\"");
     if (anaquel)
     {
         sb.AppendLine("A30,70,0,5,1,1,N,\"" + productPrice.Substring(7, productPrice.Length - 7) + "\"");
         sb.AppendLine("A430,70,0,5,1,1,N,\"" + productPrice.Substring(7, productPrice.Length - 7) + "\"");
     }
     else
     {
         sb.AppendLine("B126,40,1,2,6,80,0,1,'" + codigo + "'");
         sb.AppendLine("B1460,40,1,2,6,80,0,1,'" + codigo + "'");
     }
     sb.AppendLine("A6,150,0,1,1,2,N,\"" + strInferior + "\"");
     sb.AppendLine("A460,150,0,1,1,2,N,\"" + strInferior + "\"");
     sb.AppendLine("A6,90,170,1,1,2,N,\"" + strSuperior + "\"");
     sb.AppendLine("A460,170,0,1,1,2,N,\"" + strSuperior + "\"");
     sb.AppendLine("^XZ");
 }
 /*else if (printerModel=="Test Bixolon Grande")
 {
     sb.AppendLine("SW600");
     sb.AppendLine("SD10");
     sb.AppendLine("SOT");

     //sb.AppendLine("IR,120,10,\"RAMOS\"");
    
     //BD0,0,590,390,B,20   //PARA DIBUJAR UN CUADRO
     //sb.AppendLine("A120,75,U,135,60,0,B,N,N,3,\"Precio\"");
     sb.AppendLine("A120,305,3,5,0,0,N,\"" + productPrice + "\"");
     //sb.AppendLine("A75,75,U,135,60,0,B,N,N,1,'" + productPrice + "'");
     sb.AppendLine("BC455,40,3,1,120,120,3,B,'" + codigo + "'");
     //sb.Append("IS286,720,’ETIQUETA_PRECIOS’DATA OF *.PCX");
     //sb.Append("IR160,130,’ETIQUETA_PRECIOS’");
     /*sb.AppendLine("A95,50,U,135,60,0,B,N,N,0,\"COMERC. RAMOS\"");
     sb.AppendLine("B160,130,1,4,12,120,0,1,'" + codigo + "'");
     sb.AppendLine("A6,150,0,1,1,2,N,\"" + strInferior + "\"");

 }*/

                //sb.AppendLine(string.Format(
                //        CultureInfo.InvariantCulture,
                //        "Q{0},{1}",
                //        pFormLength, pFormLength2));



                //sb.AppendLine("P1,1");

                sb.AppendLine(string.Format(
                        CultureInfo.InvariantCulture,
                        "P{0},1",
                        numerocopias.ToString(), "1"));


                sb.AppendLine("Q0,18");

                RawPrinterHelper.SendStringToPrinter(printerName, sb.ToString());

                return sb.ToString()/*sb2.ToString()*/;
            }
            catch (Exception ex)
            {
                return "error " + ex.Message + ex.StackTrace;
            }
        }
        
        public static string PrintEtiqueta(string printerName, string codigo, string strSuperior, string strInferior,
            string pLabelWidth, string pFormLength, string pFormLength2,
            string[] pTexto, string[] pBarCode ,
            int numerocopias, bool anaquel)
        {
            if(anaquel)
            {
                StringBuilder sb;

                if (printerName == null)
                {
                    throw new ArgumentNullException("printerName");
                }

                sb = new StringBuilder();

                if (strInferior.Length > 19)
                {
                    int midleString = (strInferior.Length) / 2;
                    string strInferior2 = strInferior.Substring(18, (strInferior.Length - 18));
                    strInferior = strInferior.Substring(0, 18);

                    sb.AppendLine();
                    sb.AppendLine("N");

                    sb.AppendLine("S1");
                    sb.AppendLine("D7");
                    sb.AppendLine("ZT");
                    sb.AppendLine("JB");
                    sb.AppendLine("OD");
                    sb.AppendLine("R5,01");
                    sb.AppendLine("N");
                    sb.AppendLine("A5,8,0,1,2,2,N,\"" + strInferior + "\"");
                    sb.AppendLine("A5,35,0,1,2,2,N,\"" + strInferior2 + "\"");
                    sb.AppendLine("A430,8,0,1,2,2,N,\"" + strInferior + "\"");
                    sb.AppendLine("A430,35,0,1,2,2,N,\"" + strInferior2 + "\"");
                    sb.AppendLine("B70,68,0,1,2,3,80,N,\"" + codigo + "\"");
                    sb.AppendLine("B500,68,0,1,2,3,80,N,\"" + codigo + "\"");
                    //sb.AppendLine("A6,143,0,1,1,2,N,\"" + strInferior + "\"");
                    //sb.AppendLine("A460,143,0,1,1,2,N,\"" + strInferior + "\"");
                    sb.AppendLine("A52,160,0,4,1,2,N,\"" + strSuperior + "\"");
                    sb.AppendLine("A490,160,0,4,1,2,N,\"" + strSuperior + "\"");
                }
                else
                {

                    sb.AppendLine();
                    sb.AppendLine("N");

                    sb.AppendLine("S1");
                    sb.AppendLine("D7");
                    sb.AppendLine("ZT");
                    sb.AppendLine("JB");
                    sb.AppendLine("OD");
                    sb.AppendLine("R5,01");
                    sb.AppendLine("N");
                    sb.AppendLine("A5,6,0,1,2,2,N,\"" + strInferior + "\"");
                    sb.AppendLine("A430,6,0,1,2,2,N,\"" + strInferior + "\"");
                    sb.AppendLine("B60,32,0,1,2,3,80,B,\"" + codigo + "\"");
                    sb.AppendLine("B490,32,0,1,2,3,80,B,\"" + codigo + "\"");
                    //sb.AppendLine("A6,143,0,1,1,2,N,\"" + strInferior + "\"");
                    //sb.AppendLine("A460,143,0,1,1,2,N,\"" + strInferior + "\"");
                    sb.AppendLine("A52,150,0,4,1,2,N,\"" + strSuperior + "\"");
                    sb.AppendLine("A490,150,0,4,1,2,N,\"" + strSuperior + "\"");

                }

                sb.AppendLine(string.Format(
                CultureInfo.InvariantCulture,
                "P{0},1",
                numerocopias.ToString(), "1"));


                sb.AppendLine("Q0,18");

                RawPrinterHelper.SendStringToPrinter(printerName, sb.ToString());

                return sb.ToString()/*sb2.ToString()*/;
            }
            else
            {
                try
                {
                    StringBuilder sb;

                    if (printerName == null)
                    {
                        throw new ArgumentNullException("printerName");
                    }

                    sb = new StringBuilder();
                    sb.AppendLine();
                    sb.AppendLine("N");
                    //sb.AppendLine("q316");
                    //sb.AppendLine("Q203,26");


                    sb.AppendLine(string.Format(
                            CultureInfo.InvariantCulture,
                            "q{0}",
                            pLabelWidth));


                    //sb.AppendLine(string.Format(
                    //        CultureInfo.InvariantCulture,
                    //        "Q{0},{1}",
                    //        pFormLength, pFormLength2));





                    if (!strInferior.Trim().Equals(""))
                    {
                        sb.AppendLine(string.Format(
                            CultureInfo.InvariantCulture,
                            "A{0},{1},{2},{3},{4},{5},{6},\"{7}\"",
                            pTexto[0], pTexto[1], pTexto[2], pTexto[3], pTexto[4], pTexto[5], pTexto[6], strInferior));
                    }


                    if (!codigo.Trim().Equals(""))
                    {
                        sb.AppendLine(string.Format(
                            CultureInfo.InvariantCulture,
                            "B{0},{1},{2},{3},{4},{5},{6},{7},\"{8}\"",
                            pBarCode[0], pBarCode[1], pBarCode[2], pBarCode[3], pBarCode[4], pBarCode[5], pBarCode[6], pBarCode[7], codigo));
                    }

                    int iBarY = 0, iY = 0;
                    int iBarHeight = 0;
                    int.TryParse(pBarCode[6], out iBarHeight);
                    int.TryParse(pBarCode[1], out iBarY);
                    iY = iBarY + iBarHeight + 4;

                    if (!codigo.Trim().Equals(""))
                    {
                        sb.AppendLine(string.Format(
                            CultureInfo.InvariantCulture,
                            "A{0},{1},{2},{3},{4},{5},{6},\"{7}\"",
                            pTexto[0], iY.ToString(), pTexto[2], pTexto[3], pTexto[4], pTexto[5], pTexto[6], codigo));
                    }


                    if (!strSuperior.Trim().Equals(""))
                    {
                        sb.AppendLine(string.Format(
                            CultureInfo.InvariantCulture,
                            "A{0},{1},{2},{3},{4},{5},{6},\"{7}\"",
                            pTexto[0], (iY + iBarY + 4).ToString(), pTexto[2], pTexto[3], pTexto[4], pTexto[5], "N", strSuperior));
                    }




                    //sb.AppendLine("P1,1");

                    sb.AppendLine(string.Format(
                            CultureInfo.InvariantCulture,
                            "P{0},1",
                            numerocopias.ToString(), "1"));


                    //test


                     /*sb = new StringBuilder();
                     sb.AppendLine();
                     sb.AppendLine("N");
                     sb.AppendLine("A50,1,0,4,1,1,R,\"CAMISA DE DAMA HURLEY WILSON \"");

                     sb.AppendLine("P1,1");*/



                    //--test


                    RawPrinterHelper.SendStringToPrinterEPL(printerName, sb.ToString());

                    return sb.ToString()/*sb2.ToString()*/;
                }
                catch (Exception ex)
                {
                    return "error " + ex.Message + ex.StackTrace;
                }
            }

        }

        public void Print(string printerName)
        {
            StringBuilder sb;

            if (printerName == null)
            {
                throw new ArgumentNullException("printerName");
            }

            sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine("N");
            sb.AppendLine("q609");
            sb.AppendLine("Q203,26");
            sb.AppendLine(string.Format(
                CultureInfo.InvariantCulture,
                "B26,26,0,UA0,2,2,152,B,\"{0}\"",
                this.upc));
            sb.AppendLine("P1,1");

            RawPrinterHelperZebra.SendStringToPrinter(printerName, sb.ToString());
        }

        public static void PrintEtiquetaBixolonZPL(string printerName, string barCode,
            string productPrice, string productDescription, int peso, string unidad, string rutaImg, int numberOfCopies)
        {
            String strGuardarImagenEnImpresora = "";
            String strEliminarImagenEnImpresora = "";
            String strImprimirImagenEnImpresora = "";

            var baseStream = new MemoryStream();
            var tw = new StreamWriter(baseStream, Encoding.UTF8);

            using (var bmpSrc = new Bitmap(Image.FromFile(rutaImg)))
            {
                //bmpSrc.RotateFlip(RotateFlipType.Rotate90FlipY);
                strGuardarImagenEnImpresora = ZplImage.GetGrfStoreCommand("R:LBLRA2.GRF", bmpSrc);
            }
            strImprimirImagenEnImpresora = ZplImage.GetGrfPrintCommand("R:LBLRA2.GRF");
            strEliminarImagenEnImpresora = ZplImage.GetGrfDeleteCommand("R:LBLRA2.GRF");

            RawPrinterHelperZPL.SendStringToPrinter("ZDesigner GK420t", strGuardarImagenEnImpresora);

            double auxSpaceDescription = ((70 - (productDescription.Length*.875)) / 2)*6.10;
            double auxSpaceBarCode = ((70 - (barCode.Length*1.25)) / 2)*7.30;

            string str2ndLabel = unidad != null && unidad.ToUpper().Equals("KG") ? (peso/1000).ToString("###0.000") + " KG" :  productPrice;

            string s = "^XA^LH130,15^FO50, 250^ADN, 36, 10^FT" + auxSpaceDescription + ",^FS^FO50,150^ADN, 72, 10^FD" + productDescription + "^FS^ADN, 36, 10^FT180,280,^FD" + str2ndLabel + "^FS^FO350, 200^ADN, 11, 7 ^FO" + auxSpaceBarCode + ",320,^BY1,3,10^SD10^BCN, 60, Y, Y, N^FD" + barCode.Trim() + "^FS";
            s += strImprimirImagenEnImpresora;
            s += "^GB566,390,7,B,2";
            s += "^PQ" + numberOfCopies;
            s += "^XZ";


            RawPrinterHelperZPL.SendStringToPrinter("ZDesigner GK420t", s);

            RawPrinterHelperZPL.SendStringToPrinter("ZDesigner GK420t", strEliminarImagenEnImpresora);
        }
    }
}
