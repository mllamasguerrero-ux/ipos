using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.ComponentModel;
using System.Collections;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Threading;

namespace iPos.Tools
{
    
    public class FTPRegularManagement
    {

        private static string m_strFTPHost = "abarrotesramos.servebeer.com";
        private static string m_strFTPUserName = "pocket";
        private static string m_strFTPPassword = "ron";

        public static string m_strFTPSucursal = "";
        //private static string m_strFTPPort     = "21";
        public static string m_strFTPFolder = "";
        public static string m_strFTPFolderPass = "";
        public static string m_strFTPFolderWs = "";
        public static string m_strFTPFolderPassWs = "";

        private static string m_strFTPHostYFolder = "";




        public static ArrayList ObtenerArchivosNuevos(string strPath, DateTime minFecha)
        {
            ArrayList retorno = new ArrayList();
            FileItem itemFile;
            WebResponse response;
            StreamReader reader;

            string ftpAddress = "ftp://" + m_strFTPHostYFolder + "/" + strPath;

            ErrorLog.addLog(Environment.NewLine + DateTime.Now.ToString() + " Lectura, se buscaran archivos nuevos en :  " + ftpAddress + " despues de fecha " + minFecha.ToString());


            try
            {
                if (!ValidateFtpConection())
                    return null;
            }
            catch
            {
                return null;
            }


            try
            {
                FtpWebRequest ftp, ftpFileRequest;
                FtpWebResponse responseItem;


                ftp = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpAddress));
                ftp.Credentials = new NetworkCredential(m_strFTPUserName, m_strFTPPassword);
                ftp.Method = WebRequestMethods.Ftp.ListDirectory;
                ftp.KeepAlive = false;

                response = (WebResponse)ftp.GetResponse();

                try
                {
                    reader = new StreamReader(response.GetResponseStream());
                    try
                    {
                        string line = reader.ReadLine();
                        while (line != null)
                        {
                            itemFile = new FileItem();
                            ftpFileRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + m_strFTPHostYFolder + "/" + strPath + "/" + line));
                            ftpFileRequest.Credentials = new NetworkCredential(m_strFTPUserName, m_strFTPPassword);
                            ftpFileRequest.Method = WebRequestMethods.Ftp.GetDateTimestamp;
                            ftpFileRequest.KeepAlive = false;
                            responseItem = (FtpWebResponse)ftpFileRequest.GetResponse();
                            itemFile.FECHA = responseItem.LastModified;
                            if (minFecha < itemFile.FECHA)
                            {
                                itemFile.FILEPATHNAME = strPath + "/" + line;
                                retorno.Add(itemFile);
                            }
                            responseItem.Close();
                            line = reader.ReadLine();
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog.addLog(Environment.NewLine + DateTime.Now.ToString() + " Lectura,Excepcion :  " + ftpAddress + " despues de fecha " + minFecha.ToString() + " excepcion " + ex.Message);
                    }
                    finally
                    {
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog.addLog(Environment.NewLine + DateTime.Now.ToString() + " Lectura, expecion :  " + ftpAddress + " despues de fecha " + minFecha.ToString() + " excepcion " + ex.Message);
                }
                finally
                {
                    response.Close();
                }

            }
            catch (Exception ex)
            {
                ErrorLog.addLog(Environment.NewLine + DateTime.Now.ToString() + " Lectura, excepcion :  " + ftpAddress + " despues de fecha " + minFecha.ToString() + " excepcion " + ex.Message);
                return null;
            }

            return retorno;

        }


        public static bool PingResult()
        {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();

            // Use the default Ttl value which is 128,
            // but change the fragmentation behavior.
            options.DontFragment = true;

            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 1200;
            string hostToTest = m_strFTPHost != null && m_strFTPHost.ToLower() == "abarrotesramos.ddns.net" ? "google.com" : m_strFTPHost;
            PingReply reply = pingSender.Send(hostToTest, timeout, buffer, options);
            int iCount = 0;
            while (reply.Status != IPStatus.Success && iCount < 20)
            {
                iCount++;
                Thread.Sleep(200);
                reply = pingSender.Send(m_strFTPHost, timeout, buffer, options);
            }

            return reply.Status == IPStatus.Success;
        }


        public static bool Download(string fileLocalPath, string fileFTPPath, string fileName)
        {
            return Download(fileLocalPath, fileFTPPath, fileName, true);
        }


        public static bool Download(string fileLocalPath, string fileFTPPath, string fileName, bool mostrarMensaje)
        {
            string comentario = "";
            return Download(fileLocalPath, fileFTPPath, fileName, mostrarMensaje, fileName, ref comentario);
        }


        public static bool Download(string fileLocalPath, string fileFTPPath, string fileName, bool mostrarMensaje, string fileNameLocal, ref string comentario)
        {
            FtpWebRequest reqFTP;
            bool bRetorno = true;
            FileStream outputStream;
            FtpWebResponse response;
            Stream ftpStream;



            try
            {
                if (!ValidateFtpConection())
                    return false;
            }
            catch
            {
                return false;
            }



            try
            {
                if (!PingResult())
                {
                    if (mostrarMensaje)
                        MessageBox.Show("No fue posible hacer ping al servidor");

                    ErrorLog.addLog(Environment.NewLine + DateTime.Now.ToString() + " Download:  No fue posible hacer ping al servidor");

                    return false;
                }
            }
            catch
            {
                return false;
            }

            int iTryCount = 0;
            bool iError = true;

            while (iTryCount < 5 && iError && (!mostrarMensaje || iTryCount == 0))
            {
                iTryCount++;
                iError = false;

                try
                {
                    outputStream = new FileStream(fileLocalPath + "\\" + fileNameLocal, FileMode.Create);
                    try
                    {

                        reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + m_strFTPHostYFolder + "/" + fileFTPPath + "/" + fileName));
                        reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                        reqFTP.UseBinary = true;
                        reqFTP.KeepAlive = false;
                        reqFTP.Credentials = new NetworkCredential(m_strFTPUserName, m_strFTPPassword);
                        reqFTP.Timeout = System.Threading.Timeout.Infinite;
                        reqFTP.Proxy = null;

                        response = (FtpWebResponse)reqFTP.GetResponse();


                        try
                        {
                            ftpStream = response.GetResponseStream();
                            bool bSeDescargo = false;
                            try
                            {
                                long cl = response.ContentLength;
                                int bufferSize = 2048;
                                int readCount;
                                byte[] buffer = new byte[bufferSize];

                                readCount = ftpStream.Read(buffer, 0, bufferSize);
                                while (readCount > 0)
                                {
                                    outputStream.Write(buffer, 0, readCount);
                                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                                }
                                bSeDescargo = true;

                            }
                            catch
                            {
                            }
                            finally
                            {
                                ftpStream.Close();
                            }

                            bRetorno = bSeDescargo;
                            iError = !bSeDescargo;
                            if (bSeDescargo)
                            {
                                ErrorLog.addLog(Environment.NewLine + DateTime.Now.ToString() + " Download:  Se descargo " + reqFTP.RequestUri + " en " + outputStream.Name);
                            }

                        }
                        catch
                        {
                        }
                        finally
                        {
                            response.Close();
                        }

                    }
                    catch (Exception ex)
                    {
                        if (mostrarMensaje)
                            System.Windows.Forms.MessageBox.Show("Error al importar archivo: " + "ftp://" + m_strFTPHostYFolder + "/" + fileFTPPath + "/" + fileName + "  -Excepcion- " + ex.Message);


                        ErrorLog.addLog(Environment.NewLine + DateTime.Now.ToString() + " Download: Error al importar archivo: " + "ftp://" + m_strFTPHostYFolder + "/" + fileFTPPath + "/" + fileName + "  -Excepcion- " + ex.Message + " Stack trace " + ex.StackTrace);

                        iError = true;
                        bRetorno = false;
                        Thread.Sleep(1000);
                    }
                    finally
                    {
                        outputStream.Close();
                    }

                }
                catch
                {
                }
                finally
                {
                }
            }
            return bRetorno;
        }




        public static void UploadTest()
        {
            string filename = "C:\\IposProject\\iPosRopa\\Ipos\\iPos\\bin\\Debug\\sampdata\\in\\uploaded\\A0000079.dbf";
            FileInfo fileInf = new FileInfo(filename);
            FtpWebRequest reqFTP;

            // Create FtpWebRequest object from the Uri provided
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://199.89.53.90/desarrollo/0009/in/" + fileInf.Name));

            // Provide the WebPermission Credintials
            reqFTP.Credentials = new NetworkCredential("pocket", "k@bu");

            //use proxy
            reqFTP.Proxy = null;

            // By default KeepAlive is true, where the control connection is
            // not closed after a command is executed.
            reqFTP.KeepAlive = false;

            // Specify the command to be executed.
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;

            // Specify the data transfer type.
            reqFTP.UseBinary = true;

            // Notify the server about the size of the uploaded file
            reqFTP.ContentLength = fileInf.Length;

            // The buffer size is set to 2kb
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;

            // Opens a file stream (System.IO.FileStream) to read
            //the file to be uploaded
            FileStream fs = fileInf.OpenRead();

            try
            {
                // Stream to which the file to be upload is written
                Stream strm = reqFTP.GetRequestStream();

                // Read from the file stream 2kb at a time
                contentLen = fs.Read(buff, 0, buffLength);

                // Till Stream content ends
                while (contentLen != 0)
                {
                    // Write Content from the file stream to the
                    // FTP Upload Stream
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }

                // Close the file stream and the Request Stream
                strm.Close();
                fs.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Upload Error");
                return;
            }
        }




        public static bool Upload(string fileLocalPath, string fileFTPPath, string filename, bool bEnFolderSucursal, ref string strResultado)
        {
            string uri = "";
            return Upload(fileLocalPath, fileFTPPath, filename, bEnFolderSucursal, ref strResultado, filename, ref uri);
        }

        /// <summary>
        /// Metodo para subir un archivo especificado al FTP Server
        /// </summary>
        /// <nombre de parametro="filename">archivo a ser cargado</param>
        public static bool Upload(string fileLocalPath, string fileFTPPath, string filename, bool bEnFolderSucursal, ref string strResultado, string filenameFtp, ref string uri)
        {

            FileInfo fileInf = new FileInfo(fileLocalPath + "\\" + filename);

            if (!fileInf.Exists)
            {
                strResultado = "El archivo local no existe";
                return false;
            }

            if (fileInf.Length <= 0)
            {
                strResultado = "El archivo local tiene extension 0 bytes";
                return false;
            }


            ErrorLog.addLog(Environment.NewLine + DateTime.Now.ToString() + " Upload:  Se intentara enviar " + fileLocalPath + "\\" + filename + " a " + fileFTPPath);



            FtpWebRequest reqFTP;

            // Create FtpWebRequest object from the Uri provided
            if (bEnFolderSucursal)
            {
                uri = "ftp://" + m_strFTPHostYFolder + "/" + m_strFTPSucursal + "/" + fileFTPPath + "/" + filenameFtp;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
            }
            else
            {
                uri = "ftp://" + m_strFTPHostYFolder + fileFTPPath + "/" + filenameFtp;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
            }
            // Provide the WebPermission Credentials
            reqFTP.Credentials = new NetworkCredential(m_strFTPUserName, m_strFTPPassword);

            // By default KeepAlive is true, where the control connection is not closed
            // after a command is executed.
            reqFTP.KeepAlive = false;

            // Specify the command to be executed.
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;

            // Specify the data transfer type.
            reqFTP.UseBinary = true;

            // Notify the server about the size of the uploaded file
            if (!fileInf.Exists)
            {
                return false;
            }

            reqFTP.ContentLength = fileInf.Length;

            // The buffer size is set to 2kb
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;
            FileStream fs;
            Stream strm;


            try
            {
                if (!ValidateFtpConection())
                    return false;
            }
            catch
            {
                ErrorLog.addLog(Environment.NewLine + DateTime.Now.ToString() + " Upload:  Validacion fallida : " + fileLocalPath + "\\" + filename + " a " + fileFTPPath);

                return false;
            }


            // Opens a file stream (System.IO.FileStream) to read the file to be uploaded
            fs = fileInf.OpenRead();

            bool bReturn = false;
            try
            {

                // Stream to which the file to be upload is written
                strm = reqFTP.GetRequestStream();
                try
                {

                    // Read from the file stream 2kb at a time
                    contentLen = fs.Read(buff, 0, buffLength);

                    // Till Stream content ends
                    while (contentLen != 0)
                    {
                        // Write Content from the file stream to the FTP Upload Stream
                        strm.Write(buff, 0, contentLen);
                        contentLen = fs.Read(buff, 0, buffLength);
                    }


                    strResultado = "Archivo: " + filename + " Subido Exitosamente...";
                    ErrorLog.addLog(Environment.NewLine + DateTime.Now.ToString() + " Upload:  Archivo subido exitosamente " + fileLocalPath + "\\" + filename + " a " + fileFTPPath);

                    bReturn = true;
                }
                catch (Exception ex)
                {
                    strResultado = ex.Message + " URL " + "ftp://" + m_strFTPHostYFolder + "/" + m_strFTPSucursal + "/" + fileFTPPath + "/" + filename;
                    ErrorLog.addLog(Environment.NewLine + DateTime.Now.ToString() + " Upload:  Excepcion " + fileLocalPath + "\\" + filename + " a " + fileFTPPath + " Excepcion : " + ex.Message);
                    bReturn = false;
                }
                finally
                {
                    // Close the file stream and the Request Stream
                    //reqFTP.GetResponse().Close();
                    strm.Close();
                }
            }
            catch (Exception ex)
            {
                strResultado = ex.Message + " URL ";
                ErrorLog.addLog(Environment.NewLine + DateTime.Now.ToString() + " Upload:  Excepcion " + fileLocalPath + "\\" + filename + " a " + fileFTPPath + " Excepcion : " + ex.Message);
                bReturn = false;
            }
            finally
            {
                fs.Close();
            }
            return bReturn;
        }

        public static bool DeleteFTP(string filename, string fileFTPPath)
        {
            ErrorLog.addLog(Environment.NewLine + DateTime.Now.ToString() + " Se intentara hacer delete a :  " + fileFTPPath + "//" + filename);


            try
            {
                if (!ValidateFtpConection())
                {
                    ErrorLog.addLog(Environment.NewLine + DateTime.Now.ToString() + " Delete validacion error :  " + fileFTPPath + "//" + filename);
                    return false;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.addLog(Environment.NewLine + DateTime.Now.ToString() + " Delete excepcion validacion :  " + fileFTPPath + "//" + filename + " excepcion " + ex.Message);
                return false;
            }


            try
            {

                string uri = "ftp://" + m_strFTPHostYFolder + "/" + fileFTPPath + "/" + filename;
                FtpWebRequest reqFTP;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + m_strFTPHostYFolder + "/" + fileFTPPath + "/" + filename));

                reqFTP.Credentials = new NetworkCredential(m_strFTPUserName, m_strFTPPassword);
                reqFTP.KeepAlive = false;
                reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;

                string result = String.Empty;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                long size = response.ContentLength;
                Stream datastream = response.GetResponseStream();
                StreamReader sr = new StreamReader(datastream);
                result = sr.ReadToEnd();
                sr.Close();
                datastream.Close();
                response.Close();
                ErrorLog.addLog(Environment.NewLine + DateTime.Now.ToString() + " Delete exito  a :  " + fileFTPPath + "//" + filename);

                //MessageBox.Show("Archivo: n" + filename + "Borrado con éxito!...", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.addLog(Environment.NewLine + DateTime.Now.ToString() + " Delete excepcion :  " + fileFTPPath + "//" + filename + " excepcion " + ex.Message);
                return false;
            }
        }

        public static bool ObtenerDatosConexionFTP()
        {
            m_strFTPHost = CurrentUserID.CurrentParameters.IUSARCONEXIONLOCAL.Equals("S") ? CurrentUserID.CurrentParameters.ILOCALFTPHOST : CurrentUserID.CurrentParameters.IFTPHOST;
            m_strFTPUserName = CurrentUserID.CurrentParameters.IFTPUSUARIO;
            m_strFTPPassword = CurrentUserID.CurrentParameters.IFTPPASSWORD;
            m_strFTPHostYFolder = m_strFTPHost + ((m_strFTPFolder != null && !m_strFTPFolder.Equals("")) ? "/" + m_strFTPFolder : "");


            return true;
        }

        public static bool ValidateFtpConection()
        {

            string passwordEncriptado = EncDec.Encrypt(m_strFTPFolder, EncDec.PasswordDefault());
            if (m_strFTPFolderPass.Equals(passwordEncriptado)
                || (m_strFTPFolder.Trim().Equals("") && !m_strFTPHost.Equals("199.89.53.90"))
                )
            {
                return true;
            }
            return false;
        }

        //public static bool ObtenerDatosConexionFTP()
        //{
        //    string archivoConn = System.AppDomain.CurrentDomain.BaseDirectory + "conexionFTP.txt";
        //    string strContenidoCifrado = obtenerContenidoArchivo(archivoConn);
        //    string strContenidoArchivo = EncDec.Decrypt(strContenidoCifrado, EncDec.PasswordDefault()); ;
        //    string[] strSeparator = new string[1];
        //    strSeparator[0] = ";";
        //    string[] strFtpDatos = strContenidoArchivo.Split(strSeparator,StringSplitOptions.None);

        //    if (strFtpDatos.Length < 3)
        //        return false;

        //    m_strFTPHost     = strFtpDatos[0];
        //    m_strFTPUserName = strFtpDatos[1];
        //    m_strFTPPassword = strFtpDatos[2];
        //    return true;

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



        //public static void ConexionFtpDefault()
        //{
        //    string strconn = "raam.servebeer.com; pocket;ron;";
        //    string archivoConn = System.AppDomain.CurrentDomain.BaseDirectory + "conexionFTP.txt";
        //    string cipherText = EncDec.Encrypt(strconn, EncDec.PasswordDefault());
        //    guardarArchivo(archivoConn, cipherText);
        //}
        //public static void guardarArchivo(string fileName, string contenido)
        //{
        //    StreamWriter sw = new StreamWriter(fileName);

        //    sw.Write(contenido);
        //    sw.Close();
        //}


    }
}
