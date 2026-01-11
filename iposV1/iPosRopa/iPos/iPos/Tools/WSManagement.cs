using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Net;
using System.IO;
using System.ComponentModel;
using System.Collections;
using System.Windows.Forms;
//using System.Net.NetworkInformation;
using System.Threading;
using iPos.FileTransferServiceReference;
using System.ServiceModel;

namespace iPos.Tools
{
    
    public class WSManagement
    {

        private static string m_strFTPHost = "abarrotesramos.servebeer.com";
        private static string m_strFTPUserName = "pocket";
        private static string m_strFTPPassword = "ron";

        public static string m_strFTPSucursal = "";
        public static string m_strFTPFolder = "";
        public static string m_strFTPFolderPass = "";
        public static string m_strFTPFolderWs = "";
        public static string m_strFTPFolderPassWs = "";

        private static string m_strFTPHostYFolder = "";




        public static ArrayList ObtenerArchivosNuevos(string strPath, DateTime minFecha)
        {
            ArrayList retorno = new ArrayList();
            FileItem itemFile;
            //WebResponse response;
            //StreamReader reader;

            string ftpAddress = /*"ftp://" +*/ m_strFTPHostYFolder + "/" + strPath;

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


                try
                {

                    ListRequest request = new ListRequest();
                    request.RemotePath = ftpAddress;
                    request.MinDate = minFecha;


                    //Specify the binding to be used for the client.

                    ITransferService1 clientUpload = null;
                    if(CurrentUserID.CurrentParameters.IWSDBF != null && CurrentUserID.CurrentParameters.IWSDBF.Length > 0)
                    {
                        clientUpload = new FileTransferServiceReference.TransferService1Client("BasicHttpBinding_ITransferService1", CurrentUserID.CurrentParameters.IWSDBF);
                    }
                    else
                    {
                        clientUpload = new FileTransferServiceReference.TransferService1Client();
                    }


                    //ListFileInfo ListDirectory(
                    System.IO.FileInfo fileInfo = new System.IO.FileInfo(ftpAddress);
                    ListFileInfo listFileInfo = clientUpload.ListDirectory(request);

                    if(listFileInfo != null && !listFileInfo.Result)
                    {
                        throw new Exception(listFileInfo.Message);
                    }


                    if(listFileInfo != null && listFileInfo.FileNameList != null &&  listFileInfo.FileLastWriteList != null 
                        && listFileInfo.FileLastWriteList.Count() > 0 && listFileInfo.FileNameList.Count() > 0 
                        && listFileInfo.FileLastWriteList.Count() == listFileInfo.FileNameList.Count())
                    {
                        for(int i = 0; i < listFileInfo.FileLastWriteList.Count(); i++)
                        {

                            itemFile = new FileItem();
                            itemFile.FECHA = listFileInfo.FileLastWriteList[i];
                            if (minFecha < itemFile.FECHA.AddSeconds(-1))
                            {
                                itemFile.FILEPATHNAME = strPath + "/" + listFileInfo.FileNameList[i];
                                retorno.Add(itemFile);
                            }
                        }
                    }



                }
                catch (Exception ex)
                {
                    ErrorLog.addLog(Environment.NewLine + DateTime.Now.ToString() + " Lectura, expecion :  " + ftpAddress + " despues de fecha " + minFecha.ToString() + " excepcion " + ex.Message);

                }
                finally
                {
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
            /*Ping pingSender = new Ping();
            PingOptions options = new PingOptions();

            // Use the default Ttl value which is 128,
            // but change the fragmentation behavior.
            options.DontFragment = true;

            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;
            PingReply reply = pingSender.Send(m_strFTPHost, timeout, buffer, options);
            int iCount = 0;
            while (reply.Status != IPStatus.Success && iCount < 20)
            {
                iCount++;
                Thread.Sleep(200);
                reply = pingSender.Send(m_strFTPHost, timeout, buffer, options);
            }

            return reply.Status == IPStatus.Success;*/
            return true;
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
            //FtpWebRequest reqFTP;
            bool bRetorno = true;



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
                    try
                    {


                        ITransferService1 clientDownload = null;
                        if (CurrentUserID.CurrentParameters.IWSDBF != null && CurrentUserID.CurrentParameters.IWSDBF.Length > 0)
                        {
                            clientDownload = new FileTransferServiceReference.TransferService1Client("BasicHttpBinding_ITransferService1", CurrentUserID.CurrentParameters.IWSDBF);
                        }
                        else
                        {
                            clientDownload = new FileTransferServiceReference.TransferService1Client();
                        }
                        
                        FileTransferServiceReference.DownloadRequest requestData = new DownloadRequest();

                        FileTransferServiceReference.RemoteFileInfo fileInfo = new RemoteFileInfo();
                        requestData.FileName = fileName;
                        requestData.Path = m_strFTPHostYFolder + "/" + fileFTPPath;
                        //requestData.Path = "Uploadfiles";

                        fileInfo = clientDownload.DownloadFile(requestData);

                        if (fileInfo != null && !fileInfo.Result)
                        {
                            throw new Exception(fileInfo.Message);
                        }

                        if(fileInfo == null)
                        {
                            throw new Exception(" el webservice retorno null");
                        }

                        using (var fileStream = new FileStream(fileLocalPath + "\\" + fileNameLocal, FileMode.Create, FileAccess.Write))
                        {
                            //fileInfo.FileByteStream.Seek(0, SeekOrigin.Begin);
                            fileInfo.FileByteStream.CopyTo(fileStream);
                        }

                        ErrorLog.addLog(Environment.NewLine + DateTime.Now.ToString() + " Download:  Se descargo " + fileFTPPath + "/" + fileFTPPath + " en " + fileLocalPath + "\\" + fileNameLocal);

                        bRetorno = true;
                        iError = false;

                        
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
            string filename = @"C:\GitHub\ipos\ipos\iposV1\iPosRopa\iPos\iPos\bin\Debug\sampdata\facturaelectronica\PDF\uploaded\A459_AAA010101AAA.pdf";


            try
            {



                ITransferService1 clientUpload = null;
                if (CurrentUserID.CurrentParameters.IWSDBF != null && CurrentUserID.CurrentParameters.IWSDBF.Length > 0)
                {
                    clientUpload = new FileTransferServiceReference.TransferService1Client("BasicHttpBinding_ITransferService1", CurrentUserID.CurrentParameters.IWSDBF);
                }
                else
                {
                    clientUpload = new FileTransferServiceReference.TransferService1Client();
                }

                System.IO.FileInfo fileInfo = new System.IO.FileInfo(filename);
                RemoteFileInfo uploadRequestInfo = new RemoteFileInfo();
                string strFileName = fileInfo.Name;

                FileTransferServiceReference.GenericResponse resp = new GenericResponse();

                using (System.IO.FileStream stream = new System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    uploadRequestInfo.FileName = strFileName;
                    uploadRequestInfo.Length = fileInfo.Length;
                    uploadRequestInfo.FileByteStream = stream;
                    uploadRequestInfo.Path = @"testws\upload\";
                    resp = clientUpload.UploadFile(uploadRequestInfo);
                    
                }

                if (resp != null && !resp.Result)
                {
                    throw new Exception(resp.Message);
                }
                if (resp == null)
                {
                    throw new Exception(" el webservice retorno null");
                }


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
            string uriPath = "";
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



            //FtpWebRequest reqFTP;

            // Create FtpWebRequest object from the Uri provided
            if (bEnFolderSucursal)
            {
                uri = /*"ftp://" +*/ m_strFTPHostYFolder + "/" + m_strFTPSucursal + "/" + fileFTPPath + "/" + filenameFtp;
                uriPath = m_strFTPHostYFolder + "/" + m_strFTPSucursal + "/" + fileFTPPath + "/";
            }
            else
            {
                uri = /*"ftp://" +*/ m_strFTPHostYFolder + fileFTPPath + "/" + filenameFtp;
                uriPath = m_strFTPHostYFolder + fileFTPPath + "/";
            }


            //if (filenameFtp.Contains("00010138"))
            //{
            //    MessageBox.Show("m_strFTPHostYFolder : " + m_strFTPHostYFolder + " - Uripath"  + uriPath );
            //}

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

            

            bool bReturn = false;
            try
            {


                ITransferService1 clientUpload = null;
                if (CurrentUserID.CurrentParameters.IWSDBF != null && CurrentUserID.CurrentParameters.IWSDBF.Length > 0)
                {
                    clientUpload = new FileTransferServiceReference.TransferService1Client("BasicHttpBinding_ITransferService1", CurrentUserID.CurrentParameters.IWSDBF);
                }
                else
                {
                    clientUpload = new FileTransferServiceReference.TransferService1Client();
                }
                
                RemoteFileInfo uploadRequestInfo = new RemoteFileInfo();

                FileTransferServiceReference.GenericResponse resp = new GenericResponse();

                using (System.IO.FileStream stream = new System.IO.FileStream(fileInf.FullName, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    uploadRequestInfo.FileName = filenameFtp;
                    uploadRequestInfo.Length = fileInf.Length;
                    uploadRequestInfo.FileByteStream = stream;
                    uploadRequestInfo.Path = uriPath;
                    resp = clientUpload.UploadFile(uploadRequestInfo);
                }

                if (resp != null && !resp.Result)
                {
                    throw new Exception(resp.Message);
                }
                if (resp == null)
                {
                    throw new Exception(" el webservice retorno null");
                }

                strResultado = "Archivo: " + filename + " Subido Exitosamente...";
                ErrorLog.addLog(Environment.NewLine + DateTime.Now.ToString() + " Upload:  Archivo subido exitosamente " + fileLocalPath + "\\" + filename + " a " + fileFTPPath);

                bReturn = true;

                
            }
            catch (Exception ex)
            {
                strResultado = ex.Message + " URL ";
                ErrorLog.addLog(Environment.NewLine + DateTime.Now.ToString() + " Upload:  Excepcion " + fileLocalPath + "\\" + filename + " a " + fileFTPPath + " Excepcion : " + ex.Message);
                bReturn = false;
            }
            finally
            {
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




                ITransferService1 clientDownload = null;
                if (CurrentUserID.CurrentParameters.IWSDBF != null && CurrentUserID.CurrentParameters.IWSDBF.Length > 0)
                {
                    clientDownload = new FileTransferServiceReference.TransferService1Client("BasicHttpBinding_ITransferService1", CurrentUserID.CurrentParameters.IWSDBF);
                }
                else
                {
                    clientDownload = new FileTransferServiceReference.TransferService1Client();
                }

                FileTransferServiceReference.DownloadRequest requestData = new DownloadRequest();

                FileTransferServiceReference.GenericResponse resp = new GenericResponse();
                requestData.FileName = filename;
                requestData.Path = m_strFTPHostYFolder + "/" + fileFTPPath;

                resp = clientDownload.DeleteFileInfo(requestData);

                if (resp != null && !resp.Result)
                {
                    throw new Exception(resp.Message);
                }
                if (resp == null)
                {
                    throw new Exception(" el webservice retorno null");
                }


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
            m_strFTPHostYFolder = /*m_strFTPHost +*/ ((m_strFTPFolder != null && !m_strFTPFolder.Equals("")) ? "/" + m_strFTPFolder : "");


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
        


    }
}
