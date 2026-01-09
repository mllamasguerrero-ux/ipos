using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail; 
using System.Data;
using Microsoft.Office.Interop;
using System.Net.Mime;
using System.IO;
using iPosBusinessEntity;
using iPosData;
using Microsoft.Office.Interop.Excel;
using System.Web;
using System.Security.Permissions;
using System.Security;



namespace iPos
{
    public class EnviosMail
    {

        public static string str_smtpServer = "smtp.gmail.com";
        public static string str_mailFrom = "IposEmailService@gmail.com";
        public static string str_mailTo = "IposEmailService@gmail.com";
        public static string str_mailSubject = "Inventario Fisico ";
        public static string str_body = "This is for testing SMTP mail from GMAIL";
        public static int    int_smtpPort = 587;
        public static bool bool_EnableSsl = true;
        public static string str_smtpuser = "IposEmailService";
        public static string str_smtpPass = "Twincept.l";
        public static string str_FileExcelName = "InventarioFisico.csv";
        public const string FileLocalLocation_Excel = "sampdata\\excel";
        public static string str_FileExcelNameEliminarRec = "RecepcionEliminada.csv";



        public EnviosMail()
        {
        }


        public static bool EnviarInventario(string str_TipoInv,string strArchivo)
        {
            ObtenerDatosConexionSMTP();
            string stSubject = "Suc. " + CurrentUserID.SUCURSAL_CLAVE + " Archivo : " + strArchivo;
            
            return EnviarMail(str_smtpServer, str_mailFrom, str_mailTo,
               stSubject,
               stSubject,
                int_smtpPort,
                bool_EnableSsl, str_smtpuser, str_smtpPass, strArchivo);
            }



        public static bool EnviarCorteSumarizado(DateTime fecha, string strArchivo)
        {
            ObtenerDatosConexionSMTP();
            string stSubject = "Corte Sumarizado de Suc. " + CurrentUserID.SUCURSAL_CLAVE + " Fecha : " + fecha.ToString("dd/MM/yyyy");

            return EnviarMail(str_smtpServer, str_mailFrom, str_mailTo,
               stSubject,
               stSubject,
                int_smtpPort,
                bool_EnableSsl, str_smtpuser, str_smtpPass, strArchivo);
        }

        public static bool EnviarCorteSumarizadoXCajero(DateTime fecha, string strArchivo)
        {
            ObtenerDatosConexionSMTP();
            string stSubject = "Corte Sumarizado por cajero de Suc. " + CurrentUserID.SUCURSAL_CLAVE + " Fecha : " + fecha.ToString("dd/MM/yyyy");

            return EnviarMail(str_smtpServer, str_mailFrom, str_mailTo,
               stSubject,
               stSubject,
                int_smtpPort,
                bool_EnableSsl, str_smtpuser, str_smtpPass, strArchivo);
        }


        public static bool EnviarRecepcionEliminada(string str_TipoInv, string strArchivo)
        {
            ObtenerDatosConexionSMTP();
            string stSubject = "Recepcion(compra o traslado) Eliminada Suc. " + CurrentUserID.SUCURSAL_CLAVE + " Archivo : " + strArchivo;

            return EnviarMail(str_smtpServer, str_mailFrom, str_mailTo,
               stSubject,
               stSubject,
                int_smtpPort,
                bool_EnableSsl, str_smtpuser, str_smtpPass, strArchivo);
        }


        public static bool EnviarMail(
            string p_smtpServer,
            string p_mailFrom,
            string p_mailTo,
            string p_mailSubject,
            string p_body ,
            int    p_smtpPort,
            bool   p_EnableSsl,
            string p_smtpuser ,
            string p_smtpPass,
            string p_strArchivo
            )
        {
            bool retorno = true;
             try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(p_smtpServer);

                mail.From = new MailAddress(p_mailFrom);
                mail.To.Add(p_mailTo);
                mail.Subject = p_mailSubject;
                mail.Body = p_body;
                SmtpServer.Port = p_smtpPort;
                SmtpServer.Credentials = new System.Net.NetworkCredential(p_smtpuser, p_smtpPass);
                SmtpServer.EnableSsl = p_EnableSsl;

                 if(!File.Exists(p_strArchivo))
                 {
                     return false;
                 }

                // Create  the file attachment for this e-mail message.
                Attachment data = new Attachment(p_strArchivo, MediaTypeNames.Application.Octet);
                // Add time stamp information for the file.
                ContentDisposition disposition = data.ContentDisposition;
                disposition.CreationDate = System.IO.File.GetCreationTime(p_strArchivo);
                disposition.ModificationDate = System.IO.File.GetLastWriteTime(p_strArchivo);
                disposition.ReadDate = System.IO.File.GetLastAccessTime(p_strArchivo);
                // Add the file attachment to this e-mail message.
                mail.Attachments.Add(data);


                SmtpServer.Send(mail);
                data.Dispose();
                //MessageBox.Show("mail Send");
            }
            catch
            {
                //MessageBox.Show(ex.ToString());
                retorno = false;
            }
             return retorno;
        }



        // TO USE:
        // 1) include COM reference to Microsoft Excel Object library
        // add namespace...
        // 2) using Excel = Microsoft.Office.Interop.Excel;
        public static bool Excel_FromDataTable(System.Data.DataTable dt, string fileName, string[] columnNames, CSUCURSALBE sucursalBE)
        {
            return Excel_FromDataTable( dt,fileName,columnNames,sucursalBE, false);
        }



        
    // Export DataTable into an excel file with field names in the header line
    // - Save excel file without ever making it visible if filepath is given
    // - Don't save excel file, just make it visible if no filepath is given
    public static bool Excel_FromDataTable(System.Data.DataTable dt, string fileName,string[] columnNames,CSUCURSALBE sucursalBE, Boolean silentMode) {
        try
        {
            // Create the CSV file to which grid data will be exported.
            StreamWriter sw = new StreamWriter(fileName , false);
            // First we will write the headers.
            //DataTable dt = m_dsProducts.Tables[0];


            sw.Write("SUCURSAL NUMERO;");
            sw.Write(sucursalBE.ICLAVE + ";");
            sw.Write(sw.NewLine);


            sw.Write("SUCURSAL;");
            sw.Write(sucursalBE.INOMBRE + ";");
            sw.Write(sw.NewLine);

            sw.Write("FECHA;");
            sw.Write(DateTime.Today.ToString("dd/MM/yyyy") + ";");
            sw.Write(sw.NewLine);




            int iColCount = dt.Columns.Count;
            

            // Now write all the rows.

            string strColName = "";

            // Add column headings...
            int iX = 0;
            foreach (DataColumn c in dt.Columns)
            {
                strColName = columnNames[iX];
                iX++;
                if (strColName == "")
                    continue;


                sw.Write(strColName + ";");

            }
            sw.Write(sw.NewLine);

            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < iColCount; i++)
                {

                    strColName = columnNames[i];
                    iX++;
                    if (strColName == null || strColName == "" || strColName.Trim().Length == 0)
                        continue;

                    if (!Convert.IsDBNull(dr[i]))
                    {
                        sw.Write(dr[i].ToString());
                    }
                    if (i < iColCount - 1)
                    {
                        sw.Write(";");
                    }
                }

                sw.Write(sw.NewLine);
            }
            sw.Close();

            return true;
        }
        catch (Exception ex)
        {
            //throw ex;

            if (!silentMode)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + ex.StackTrace);
            }

            return false;
        }
    }

    

    public static bool Excel_FromDataTableInterop(System.Data.DataTable dt, string fileName, string[] columnNames, CSUCURSALBE sucursalBE, Boolean silentMode)
    {
        try
        {
            string strColName = "";
            // Create an Excel object and add workbook..
            Application excel = new Application();
            try
            {
                if (File.Exists(fileName))
                    File.Delete(fileName);

                Workbook workbook = excel.Workbooks.Add(); // true for object template???

                // Add column headings...
                int iCol = 0;
                int iX = 0;
                int iRow = 1;


                excel.Cells[iRow, 1] = "SUCURSAL NUMERO:";
                excel.Cells[iRow, 2] = sucursalBE.ICLAVE;
                iRow++;
                excel.Cells[iRow, 1] = "SUCURSAL:";
                excel.Cells[iRow, 2] = sucursalBE.INOMBRE;
                iRow++;
                excel.Cells[iRow, 1] = "FECHA:";
                excel.Cells[iRow, 2] = DateTime.Today.ToString("dd/MM/yyyy");
                iRow++;

                foreach (DataColumn c in dt.Columns)
                {
                    strColName = columnNames[iX];
                    iX++;
                    if (strColName == "")
                        continue;

                    iCol++;
                    excel.Cells[iRow, iCol] = strColName;
                }


                // for each row of data...
                //int iRow = 2;
                foreach (DataRow r in dt.Rows)
                {

                    // add each row's cell data...
                    iCol = 0;
                    iX = 0;
                    foreach (DataColumn c in dt.Columns)
                    {
                        strColName = columnNames[iX];
                        iX++;
                        if (strColName == "")
                            continue;

                        iCol++;
                        excel.Cells[iRow + 1, iCol] = r[c.ColumnName];
                    }
                    iRow++;
                }

                // Global missing reference for objects we are not defining...
                object missing = System.Reflection.Missing.Value;

                // If wanting to Save the workbook...
                workbook.SaveAs(fileName,
                XlFileFormat.xlXMLSpreadsheet, missing, missing,
                false, false, XlSaveAsAccessMode.xlNoChange,
                missing, missing, missing, missing, missing);

                // If wanting to make Excel visible and activate the worksheet...
                excel.Visible = true;
                Worksheet worksheet = (Worksheet)excel.ActiveSheet;
                ((_Worksheet)worksheet).Activate();

                // If wanting excel to shutdown...
                ((_Application)excel).Quit();

                excel = null;

                return true;
            }
            catch (Exception ex)
            {

                if (!silentMode)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message + ex.StackTrace);
                }

                ((_Application)excel).Quit();
                return false;
            }

            return true;
        }
        catch
        {
            return false;
        }
    }



        public static bool ObtenerDatosConexionSMTP()
        {
            str_smtpServer = CurrentUserID.CurrentParameters.ISMTPHOST;
            str_mailFrom = CurrentUserID.CurrentParameters.ISMTPMAILFROM;
            str_mailTo = CurrentUserID.CurrentParameters.ISMTPMAILTO;
            int_smtpPort = CurrentUserID.CurrentParameters.ISMTPPORT;
            str_smtpuser = CurrentUserID.CurrentParameters.ISMTPUSUARIO;
            str_smtpPass = CurrentUserID.CurrentParameters.ISMTPPASSWORD;

            bool_EnableSsl = CurrentUserID.CurrentParameters.ISMTPSSL.Equals("S");

            return true;
         }

        //public static bool ObtenerDatosConexionSMTP()
        //{
        //    string archivoConn = System.AppDomain.CurrentDomain.BaseDirectory + "conexionSMTP.txt";
        //    string strContenidoCifrado = obtenerContenidoArchivo(archivoConn);
        //    string strContenidoArchivo = EncDec.Decrypt(strContenidoCifrado, EncDec.PasswordDefault()); ;
        //    string[] strSeparator = new string[1];
        //    strSeparator[0] = ";";
        //    string[] strSmtpDatos = strContenidoArchivo.Split(strSeparator, StringSplitOptions.None);

        //    if (strSmtpDatos.Length < 3)
        //        return false;

        //    str_smtpServer = strSmtpDatos[0];
        //    str_mailFrom = strSmtpDatos[1];
        //    str_mailTo = strSmtpDatos[2];
        //    str_mailSubject = strSmtpDatos[3];
        //    str_body = strSmtpDatos[4];
        //    int_smtpPort = int.Parse(strSmtpDatos[5]);
        //    bool_EnableSsl = bool.Parse(strSmtpDatos[6]); 
        //    str_smtpuser = strSmtpDatos[7]; 
        //    str_smtpPass = strSmtpDatos[8];

        //    return true;

        //}


        //public static void ConexionSmtpDefault()
        //{
        //    string strconn = "smtp.gmail.com;IposEmailService@gmail.com;IposEmailService@gmail.com;Inventario Fisico ;This is for testing SMTP mail from GMAIL; 587;true;IposEmailService;Twincept.l;InventarioFisico.xls;sampdata\\excel";


        //    string archivoConn = System.AppDomain.CurrentDomain.BaseDirectory + "conexionSMTP.txt";
        //    string cipherText = EncDec.Encrypt(strconn, EncDec.PasswordDefault());
        //    guardarArchivo(archivoConn, cipherText);
        //}


        //public static string obtenerContenidoArchivo(string fileName)
        //{
        //    string retorno = "";
        //    if (!File.Exists(fileName))
        //    {
        //        return "";
        //    }
        //    StreamReader r = File.OpenText(fileName);
        //    string line;
        //    line = r.ReadLine();
        //    while (line != null)
        //    {
        //        retorno = line;
        //        line = r.ReadLine();
        //    }
        //    r.Close();
        //    return retorno;
        //}


        //public static void guardarArchivo(string fileName, string contenido)
        //{
        //    StreamWriter sw = new StreamWriter(fileName);

        //    sw.Write(contenido);
        //    sw.Close();
        //}

    }
}
