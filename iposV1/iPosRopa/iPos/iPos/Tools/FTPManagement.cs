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

    public struct FileItem
    {
        public DateTime FECHA;
        public string   FILEPATHNAME;
        public string SUCURSALCLAVE;
        public long SUCURSALID;
    }
    public class FTPManagement
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
            if (CurrentUserID.CurrentParameters.IHABWSDBF != null && CurrentUserID.CurrentParameters.IHABWSDBF.Equals("S"))
                return WSManagement.ObtenerArchivosNuevos(strPath, minFecha);
            else
                return FTPRegularManagement.ObtenerArchivosNuevos(strPath, minFecha);
            

        }

        
        public static bool Download(string fileLocalPath, string fileFTPPath, string fileName)
        {
            if (CurrentUserID.CurrentParameters.IHABWSDBF != null && CurrentUserID.CurrentParameters.IHABWSDBF.Equals("S"))
                return WSManagement.Download(fileLocalPath, fileFTPPath, fileName);
            else
                return FTPRegularManagement.Download(fileLocalPath,  fileFTPPath,  fileName);
        }


        public static bool Download(string fileLocalPath, string fileFTPPath, string fileName, bool mostrarMensaje)
        {
            if (CurrentUserID.CurrentParameters.IHABWSDBF != null && CurrentUserID.CurrentParameters.IHABWSDBF.Equals("S"))
                return WSManagement.Download(fileLocalPath, fileFTPPath, fileName, mostrarMensaje);
            else
                return FTPRegularManagement.Download(fileLocalPath, fileFTPPath, fileName, mostrarMensaje);
        }


        public static bool Download(string fileLocalPath, string fileFTPPath, string fileName, bool mostrarMensaje, string fileNameLocal, ref string comentario)
        {
            if (CurrentUserID.CurrentParameters.IHABWSDBF != null && CurrentUserID.CurrentParameters.IHABWSDBF.Equals("S"))
                return WSManagement.Download(fileLocalPath, fileFTPPath, fileName, mostrarMensaje, fileNameLocal, ref comentario);
            else
                return FTPRegularManagement.Download(fileLocalPath, fileFTPPath, fileName, mostrarMensaje, fileNameLocal, ref comentario);
        }




         public static void UploadTest()
        {
            //if (CurrentUserID.CurrentParameters.IHABWSDBF != null && CurrentUserID.CurrentParameters.IHABWSDBF.Equals("S"))
                 WSManagement.UploadTest();
            //else
            //    FTPRegularManagement.UploadTest();
        }




         public static bool Upload(string fileLocalPath, string fileFTPPath, string filename, bool bEnFolderSucursal, ref string strResultado)
        {
            if (CurrentUserID.CurrentParameters.IHABWSDBF != null && CurrentUserID.CurrentParameters.IHABWSDBF.Equals("S"))
                return WSManagement.Upload(fileLocalPath, fileFTPPath, filename, bEnFolderSucursal, ref strResultado); 
            else
                return FTPRegularManagement.Upload(fileLocalPath,  fileFTPPath, filename, bEnFolderSucursal, ref  strResultado);
         }

         /// <summary>
        /// Metodo para subir un archivo especificado al FTP Server
        /// </summary>
        /// <nombre de parametro="filename">archivo a ser cargado</param>
        public static bool Upload(string fileLocalPath, string fileFTPPath, string filename, bool bEnFolderSucursal, ref string strResultado, string filenameFtp, ref string uri)
        {

            if (CurrentUserID.CurrentParameters.IHABWSDBF != null && CurrentUserID.CurrentParameters.IHABWSDBF.Equals("S"))
                return WSManagement.Upload(fileLocalPath, fileFTPPath, filename, bEnFolderSucursal, ref strResultado, filenameFtp, ref uri);
            else
                return FTPRegularManagement.Upload(fileLocalPath, fileFTPPath, filename, bEnFolderSucursal, ref strResultado, filenameFtp, ref uri);
        }

        public static bool DeleteFTP(string filename, string fileFTPPath)
        {
            if (CurrentUserID.CurrentParameters.IHABWSDBF != null && CurrentUserID.CurrentParameters.IHABWSDBF.Equals("S"))
                return WSManagement.DeleteFTP(filename, fileFTPPath);
            else
                return FTPRegularManagement.DeleteFTP( filename,  fileFTPPath);
        }

        public static bool ObtenerDatosConexionFTP()
        {
            
            m_strFTPHost = CurrentUserID.CurrentParameters.IUSARCONEXIONLOCAL.Equals("S") ? CurrentUserID.CurrentParameters.ILOCALFTPHOST : CurrentUserID.CurrentParameters.IFTPHOST;
            m_strFTPUserName = CurrentUserID.CurrentParameters.IFTPUSUARIO;
            m_strFTPPassword = CurrentUserID.CurrentParameters.IFTPPASSWORD;
            m_strFTPHostYFolder = /*m_strFTPHost +*/ ((m_strFTPFolder != null && !m_strFTPFolder.Equals("")) ? "/" + m_strFTPFolder : "");

            

            WSManagement.ObtenerDatosConexionFTP();
            return FTPRegularManagement.ObtenerDatosConexionFTP();


        }




        public static bool ValidateFtpConection()
        {

            if (CurrentUserID.CurrentParameters.IHABWSDBF != null && CurrentUserID.CurrentParameters.IHABWSDBF.Equals("S"))
                return WSManagement.ValidateFtpConection();
            else
                return FTPRegularManagement.ValidateFtpConection();
        }
        

    }
}
