using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iPosData;
using iPosBusinessEntity;
using FirebirdSql.Data.FirebirdClient;
using System.Collections;
using iPos.Tools;
using DataLayer.Importaciones;
using System.Windows.Forms;
using System.IO;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using ConexionesBD;



namespace iPos
{
    struct FilesForImporting
    {
        public short TIPO;
        public ArrayList FILES;
    }

    public class ImportaDesdeFtp
    {
        public const string FileLocation_RecCompras = "/pedidos"; ///TestingManuel000085
        public const string FileLocation_Productos = "tiendas";
        public const string FileLocation_Traslados = "/TRASLA";

        public const string FileLocation_Existencias = "ExistenciasGeneral";
        public const string FileLocation_PedidoAMatriz = "/in";

        public const string FileLocation_RecComprasAux = "/pedidos_aux"; ///TestingManuel000085
        public const string FileLocation_TrasladosAux = "/TRASLA_aux";


        public const string FileLocation_TrasladosDevo = "/TRASLADEVO";
        public const string FileLocation_PedidosDevo = "/PEDIDODEVO";


        public const string FileLocation_SolicitudMercancia = "/solicitudMercancia";


        public const string FileSubLocationUploaded = "\\uploaded";
        public const string FileLocation_PreciosTemp = "tiendas/prectemp";


        public const string FtpMensajeriaUploaded = "/MensajesAdjuntos";

        public static bool m_Exporting = false;
        public static string m_UltimoExporting = "";


        private string iComentario;
        public string IComentario
        {
            get
            {
                return this.iComentario;
            }
            set
            {
                this.iComentario = value;
            }
        }


        public static string GetFtpFileLocation(short iTipo)
        {


            if (CurrentUserID.SUCURSAL_CLAVE == "")
            {

                MessageBox.Show("Define la clave de la sucursal");
                return "ERROR";
            }
            switch (iTipo)
            {
                case CIMP_FILESD.FileType_Producto: return FileLocation_Productos + "/";
                case CIMP_FILESD.FileType_RecCompras: return CurrentUserID.SUCURSAL_CLAVE + FileLocation_RecCompras + "/";
                case CIMP_FILESD.FileType_Traslados: return CurrentUserID.SUCURSAL_CLAVE + FileLocation_Traslados + "/";
                case CIMP_FILESD.FileType_ExistenciasGen: return FileLocation_Existencias + "/";
                case CIMP_FILESD.FileType_RecComprasAux: return CurrentUserID.SUCURSAL_CLAVE + FileLocation_RecComprasAux + "/";
                case CIMP_FILESD.FileType_TrasladosAux: return CurrentUserID.SUCURSAL_CLAVE + FileLocation_TrasladosAux + "/";
                case CIMP_FILESD.FileType_PreciosTemp: return FileLocation_PreciosTemp + "/";
                case CIMP_FILESD.FileType_TrasladosDevo: return CurrentUserID.SUCURSAL_CLAVE + FileLocation_TrasladosDevo + "/";
                case CIMP_FILESD.FileType_PedidosDevo: return CurrentUserID.SUCURSAL_CLAVE + FileLocation_PedidosDevo + "/";
                case CIMP_FILESD.FileType_SolicitudMercancia: return CurrentUserID.SUCURSAL_CLAVE + FileLocation_SolicitudMercancia + "/";
                default: return "";
            }

        }




        public static string GetFtpFileLocationParaMatriz(short iTipo, string claveMatriz)
        {


            if (CurrentUserID.SUCURSAL_CLAVE == "")
            {

                MessageBox.Show("Define la clave de la sucursal");
                return "ERROR";
            }
            switch (iTipo)
            {
                case CIMP_FILESD.FileType_MatrizPedidos: return claveMatriz + FileLocation_PedidoAMatriz;
                default: return "";
            }

        }



        public static ArrayList FilesToImportMatriz()
        {

            CIMP_FILESD imp_filesD = new CIMP_FILESD();
            ArrayList imp_filesSucursales = imp_filesD.ObtenerSucursalesABuscarArchivos(null, CurrentUserID.CurrentParameters.ISUCURSALID);

            ArrayList ArrFilesForImporting = new ArrayList();
            FilesForImporting fileForImport;
            DateTime fechaBuffer;

            foreach (CIMP_FILESBE imp_filebe in imp_filesSucursales)
            {

                fileForImport = new FilesForImporting();
                fileForImport.TIPO = CIMP_FILESD.FileType_MatrizPedidos;

                fechaBuffer = imp_filebe.IIF_FECHA;
                try
                {
                    if (imp_filebe.IIF_TIME > TimeSpan.MinValue)
                    {
                        fechaBuffer = fechaBuffer.Add(imp_filebe.IIF_TIME);
                    }
                }
                catch
                {
                    fechaBuffer = imp_filebe.IIF_FECHA;
                }

                fileForImport.FILES = new ArrayList();

                //fecha minima de pedidos
                if (fechaBuffer < CurrentUserID.CurrentParameters.IFECHAINICIOPEDIDO)
                    fechaBuffer = CurrentUserID.CurrentParameters.IFECHAINICIOPEDIDO;

                fechaBuffer = fechaBuffer.CompareTo(DateTime.Today.AddDays(-3)) > 0 ? DateTime.Today.AddDays(-3) : fechaBuffer;

                /*
                if(imp_filebe.IIF_SUCURSALCLAVE.Contains("0162"))
                {
                    MessageBox.Show(fechaBuffer.ToString());
                }*/


                ArrayList tempFiles = iPos.Tools.FTPManagement.ObtenerArchivosNuevos(GetFtpFileLocationParaMatriz(CIMP_FILESD.FileType_MatrizPedidos, imp_filebe.IIF_SUCURSALCLAVE), fechaBuffer);


                //String strBuffer = "";

                if (tempFiles != null)
                {
                    for (int i = 0; i < tempFiles.Count; i++)
                    {
                        FileItem bufferFile = (FileItem)tempFiles[i];
                        bufferFile.SUCURSALCLAVE = imp_filebe.IIF_SUCURSALCLAVE;
                        bufferFile.SUCURSALID = imp_filebe.IIF_SUCURSALID;

                        if (System.IO.Path.GetFileName(bufferFile.FILEPATHNAME).ToLower().StartsWith("vens") ||
                            System.IO.Path.GetFileName(bufferFile.FILEPATHNAME).ToLower().StartsWith("m_vens"))
                            continue;


                        //MessageBox.Show(bufferFile.FILEPATHNAME);
                        fileForImport.FILES.Add(bufferFile);


                    }
                    //MessageBox.Show(strBuffer);
                }


                ArrFilesForImporting.Add(fileForImport);
            }

            return ArrFilesForImporting;

        }

        public static ArrayList FilesToImport()
        {
            CIMP_FILESD imp_filesD = new CIMP_FILESD();
            ArrayList lastDownloaded = imp_filesD.ObtenerUltimosArchivosDescargados(null);

            LastDownloadedFiles[] ldf = new LastDownloadedFiles[lastDownloaded.Count];
            lastDownloaded.CopyTo(ldf, 0);

            int iProductos = -1, iCompras = -1, iTraslados = -1, iExistencias = -1, iComprasAux = -1, iTrasladosAux = -1, iPrecTemp = -1, iTrasladosDevo = -1, iPedidosDevo = -1, iSolicitudesMercancia = -1;
            DateTime fechaProductos, fechaCompras = DateTime.Parse("01/01/1900"), fechaTraslados,
                   fechaComprasAux = DateTime.Parse("01/01/1900"), fechaTrasladosAux = DateTime.Parse("01/01/1900"), fechaTrasladosDevo, fechaPedidosDevo, fechaSolicitudMercancia;
            //DateTime fechaExistencias;
            ArrayList ArrFilesForImporting = new ArrayList();
            FilesForImporting fileForImport = new FilesForImporting();

            for (int i = 0; i < lastDownloaded.Count; i++)
            {
                switch (ldf[i].TIPO)
                {
                    case CIMP_FILESD.FileType_Producto: iProductos = i; break;
                    case CIMP_FILESD.FileType_RecCompras: iCompras = i; break;
                    case CIMP_FILESD.FileType_Traslados: iTraslados = i; break;
                    case CIMP_FILESD.FileType_ExistenciasGen: iExistencias = i; break;
                    case CIMP_FILESD.FileType_RecComprasAux: iComprasAux = i; break;
                    case CIMP_FILESD.FileType_TrasladosAux: iTrasladosAux = i; break;
                    case CIMP_FILESD.FileType_PreciosTemp: iPrecTemp = i; break;
                    case CIMP_FILESD.FileType_TrasladosDevo: iTrasladosDevo = i; break;
                    case CIMP_FILESD.FileType_SolicitudMercancia: iSolicitudesMercancia = i; break;
                    default: break;
                }

            }


            bool bEsSucursaloMatrizSecundaria = true;
            if (CurrentUserID.CurrentCompania.IESMATRIZ == "S")
            {

                CSUCURSALD sucursalD = new CSUCURSALD();
                CSUCURSALBE sucursalBE = new CSUCURSALBE();
                sucursalBE.IID = CurrentUserID.CurrentParameters.ISUCURSALID;
                sucursalBE = sucursalD.seleccionarSUCURSAL(sucursalBE, null);

                bool bEsMatrizPrincipal = true;
                if (sucursalBE != null)
                {
                    if (!((bool)sucursalBE.isnull["ISURTIDOR"] || sucursalBE.ISURTIDOR == null || sucursalBE.ISURTIDOR.Trim().Length == 0))
                    {
                        bEsMatrizPrincipal = false;
                    }
                }

                bEsSucursaloMatrizSecundaria = !bEsMatrizPrincipal;
            }






            if (bEsSucursaloMatrizSecundaria)
            {

                //Productos
                fileForImport = new FilesForImporting();
                fileForImport.TIPO = CIMP_FILESD.FileType_Producto;
                if (iProductos == -1)
                    fechaProductos = DateTime.Parse("01/01/1900");
                else
                {
                    fechaProductos = ldf[iProductos].FECHA;
                    fechaProductos = fechaProductos.Add(ldf[iProductos].TIME);
                }

                fileForImport.FILES = iPos.Tools.FTPManagement.ObtenerArchivosNuevos(GetFtpFileLocation(CIMP_FILESD.FileType_Producto), fechaProductos);
                ArrFilesForImporting.Add(fileForImport);



                //Precios temp
                fileForImport = new FilesForImporting();
                fileForImport.TIPO = CIMP_FILESD.FileType_PreciosTemp;
                if (iPrecTemp == -1)
                    fechaProductos = DateTime.Parse("01/01/1900");
                else
                {
                    fechaProductos = ldf[iPrecTemp].FECHA;
                    fechaProductos = fechaProductos.Add(ldf[iPrecTemp].TIME);
                }

                fileForImport.FILES = iPos.Tools.FTPManagement.ObtenerArchivosNuevos(GetFtpFileLocation(CIMP_FILESD.FileType_PreciosTemp), fechaProductos);
                ArrFilesForImporting.Add(fileForImport);



            }



            //Compras
            fileForImport = new FilesForImporting();
            fileForImport.TIPO = CIMP_FILESD.FileType_RecCompras;
            if (iCompras == -1)
                fechaCompras = DateTime.Parse("01/01/1900");
            else
            {
                fechaCompras = ldf[iCompras].FECHA;
                fechaCompras = fechaCompras.Add(ldf[iCompras].TIME);
            }
            fechaCompras = fechaCompras.CompareTo(DateTime.Today.AddDays(-3)) > 0 ? DateTime.Today.AddDays(-3) : fechaCompras;
            fileForImport.FILES = iPos.Tools.FTPManagement.ObtenerArchivosNuevos(GetFtpFileLocation(CIMP_FILESD.FileType_RecCompras), fechaCompras);
            ArrFilesForImporting.Add(fileForImport);




            //ComprasAux
            fileForImport = new FilesForImporting();
            fileForImport.TIPO = CIMP_FILESD.FileType_RecComprasAux;
            if (iComprasAux == -1)
                fechaComprasAux = DateTime.Parse("01/01/1900");
            else
            {
                fechaComprasAux = ldf[iComprasAux].FECHA;
                fechaComprasAux = fechaComprasAux.Add(ldf[iComprasAux].TIME);
            }
            fechaComprasAux = fechaComprasAux.CompareTo(DateTime.Today.AddDays(-3)) > 0 ? DateTime.Today.AddDays(-3) : fechaComprasAux;
            fileForImport.FILES = iPos.Tools.FTPManagement.ObtenerArchivosNuevos(GetFtpFileLocation(CIMP_FILESD.FileType_RecComprasAux), fechaComprasAux);
            ArrFilesForImporting.Add(fileForImport);


            //traslados
            fileForImport = new FilesForImporting();
            fileForImport.TIPO = CIMP_FILESD.FileType_Traslados;
            if (iTraslados == -1)
                fechaTraslados = DateTime.Parse("01/01/1900");
            else
            {
                fechaTraslados = ldf[iTraslados].FECHA;
                fechaTraslados = fechaTraslados.Add(ldf[iTraslados].TIME);
            }
            fechaTraslados = fechaTraslados.CompareTo(DateTime.Today.AddDays(-3)) > 0 ? DateTime.Today.AddDays(-3) : fechaTraslados;

            fileForImport.FILES = iPos.Tools.FTPManagement.ObtenerArchivosNuevos(GetFtpFileLocation(CIMP_FILESD.FileType_Traslados), fechaTraslados);
            ArrFilesForImporting.Add(fileForImport);




            //trasladosAux
            fileForImport = new FilesForImporting();
            fileForImport.TIPO = CIMP_FILESD.FileType_TrasladosAux;
            if (iTrasladosAux == -1)
                fechaTrasladosAux = DateTime.Parse("01/01/1900");
            else
            {
                fechaTrasladosAux = ldf[iTrasladosAux].FECHA;
                fechaTrasladosAux = fechaTrasladosAux.Add(ldf[iTrasladosAux].TIME);
            }
            fechaTrasladosAux = fechaTrasladosAux.CompareTo(DateTime.Today.AddDays(-3)) > 0 ? DateTime.Today.AddDays(-3) : fechaTrasladosAux;

            fileForImport.FILES = iPos.Tools.FTPManagement.ObtenerArchivosNuevos(GetFtpFileLocation(CIMP_FILESD.FileType_TrasladosAux), fechaTrasladosAux);
            ArrFilesForImporting.Add(fileForImport);



            //trasladosDevo

            if (CurrentUserID.CurrentParameters.IHAB_DEVOLUCIONTRASLADO == "S")
            {
                fileForImport = new FilesForImporting();
                fileForImport.TIPO = CIMP_FILESD.FileType_TrasladosDevo;
                if (iTrasladosDevo == -1)
                    fechaTrasladosDevo = DateTime.Parse("01/01/1900");
                else
                {
                    fechaTrasladosDevo = ldf[iTrasladosDevo].FECHA;
                    fechaTrasladosDevo = fechaTrasladosDevo.Add(ldf[iTrasladosDevo].TIME);
                }
                fechaTrasladosDevo = fechaTrasladosDevo.CompareTo(DateTime.Today.AddDays(-3)) > 0 ? DateTime.Today.AddDays(-3) : fechaTrasladosDevo;

                fileForImport.FILES = iPos.Tools.FTPManagement.ObtenerArchivosNuevos(GetFtpFileLocation(CIMP_FILESD.FileType_TrasladosDevo), fechaTrasladosDevo);
                ArrFilesForImporting.Add(fileForImport);
            }



            //pedidosDevo

            if (CurrentUserID.CurrentParameters.IHAB_DEVOLUCIONSURTIDOSUC == "S")
            {
                fileForImport = new FilesForImporting();
                fileForImport.TIPO = CIMP_FILESD.FileType_PedidosDevo;
                if (iPedidosDevo == -1)
                    fechaPedidosDevo = DateTime.Parse("01/01/1900");
                else
                {
                    fechaPedidosDevo = ldf[iPedidosDevo].FECHA;
                    fechaPedidosDevo = fechaPedidosDevo.Add(ldf[iPedidosDevo].TIME);
                }

                fileForImport.FILES = iPos.Tools.FTPManagement.ObtenerArchivosNuevos(GetFtpFileLocation(CIMP_FILESD.FileType_PedidosDevo), fechaPedidosDevo);
                ArrFilesForImporting.Add(fileForImport);
            }



            //solicitudes mercancia
            fileForImport = new FilesForImporting();
            fileForImport.TIPO = CIMP_FILESD.FileType_SolicitudMercancia;
            if (iSolicitudesMercancia == -1)
                fechaSolicitudMercancia = DateTime.Parse("01/01/1900");
            else
            {
                fechaSolicitudMercancia = ldf[iSolicitudesMercancia].FECHA;
                fechaSolicitudMercancia = fechaTraslados.Add(ldf[iSolicitudesMercancia].TIME);
            }
            fechaSolicitudMercancia = fechaSolicitudMercancia.CompareTo(DateTime.Today.AddDays(-3)) > 0 ? DateTime.Today.AddDays(-3) : fechaSolicitudMercancia;

            fileForImport.FILES = iPos.Tools.FTPManagement.ObtenerArchivosNuevos(GetFtpFileLocation(CIMP_FILESD.FileType_SolicitudMercancia), fechaSolicitudMercancia);
            ArrFilesForImporting.Add(fileForImport);


            ////existencias
            //fileForImport = new FilesForImporting();
            //fileForImport.TIPO = CIMP_FILESD.FileType_ExistenciasGen;
            //if (iExistencias == -1)
            //    fechaExistencias = DateTime.Parse("01/01/1900");
            //else
            //{
            //    fechaExistencias = ldf[iExistencias].FECHA;
            //    fechaExistencias = fechaExistencias.Add(ldf[iExistencias].TIME);
            //}

            //fileForImport.FILES = iPos.Tools.FTPManagement.ObtenerArchivosNuevos(GetFtpFileLocation(CIMP_FILESD.FileType_ExistenciasGen), fechaExistencias);
            //ArrFilesForImporting.Add(fileForImport);


            return ArrFilesForImporting;
        }






        public bool DescargarArchivosDeFtpDeMatriz()
        {
            ArrayList ArrayErrors = new ArrayList();
            ArrayList groupFilesToImport = ImportaDesdeFtp.FilesToImportMatriz();
            bool bRetorno = true;
            ArrayList fileListToImport;
            foreach (FilesForImporting fileForImport in groupFilesToImport)
            {
                fileListToImport = fileForImport.FILES;
                if (fileListToImport == null)
                    continue;
                foreach (iPos.Tools.FileItem fileItem in fileListToImport)
                {
                    if (!DescargarArchivoMatriz(fileItem, null, CIMP_FILESD.FileType_MatrizPedidos))
                    {
                        ArrayErrors.Add("error al importar el archivo " + fileItem.FILEPATHNAME);
                        bRetorno = false;
                    }
                    else
                    {
                        if (!EliminarArchivo(fileItem, fileForImport.TIPO))
                        {

                            ArrayErrors.Add("error al eliminar el archivo " + fileItem.FILEPATHNAME);
                            bRetorno = false;
                        }
                    }
                }
            }
            return bRetorno;
        }


        public bool DescargarArchivosDeFtp()
        {
            ArrayList ArrayErrors = new ArrayList();
            ArrayList groupFilesToImport = ImportaDesdeFtp.FilesToImport();
            bool bRetorno = true;
            //StringBuilder result = new StringBuilder();
            ArrayList fileListToImport;
            foreach (FilesForImporting fileForImport in groupFilesToImport)
            {
                fileListToImport = fileForImport.FILES;
                if (fileListToImport == null)
                    continue;
                foreach (iPos.Tools.FileItem fileItem in fileListToImport)
                {
                    //no importar archivos de tipo productos precios etc que no se llamen prec.zip
                    if (fileForImport.TIPO == CIMP_FILESD.FileType_Producto && !fileItem.FILEPATHNAME.ToUpper().Contains("PREC.ZIP"))
                        continue;


                    //no importar archivos de tipo precios temporales que no se llamen precTEMP.zip
                    if (fileForImport.TIPO == CIMP_FILESD.FileType_PreciosTemp && !fileItem.FILEPATHNAME.ToUpper().Contains("PRECTEMP.ZIP"))
                        continue;

                    //descargar los archivos , se requiere la inforamacion del tipo para saber de donde se descargaran
                    //esta funcion tambien agrega los registros en imp_files( lo cual esta mal pero asi esta trabajando ahorita)
                    if (!DescargarArchivo(fileItem, null, fileForImport.TIPO))
                    {
                        ArrayErrors.Add("error al importar el archivo " + fileItem.FILEPATHNAME);
                        bRetorno = false;
                    }
                    else
                    {
                        DescomprimirArchivo(fileItem, fileForImport.TIPO);
                        CopiarArchivosAdicionales(fileItem, fileForImport.TIPO);

                        //Elimina los archivos que ya se hayan descargado de  compras y traslados
                        if (fileForImport.TIPO == CIMP_FILESD.FileType_RecCompras || fileForImport.TIPO == CIMP_FILESD.FileType_Traslados || fileForImport.TIPO == CIMP_FILESD.FileType_SolicitudMercancia
                             || fileForImport.TIPO == CIMP_FILESD.FileType_RecComprasAux || fileForImport.TIPO == CIMP_FILESD.FileType_TrasladosAux || fileForImport.TIPO == CIMP_FILESD.FileType_TrasladosDevo)
                        {
                            if (!EliminarArchivo(fileItem, fileForImport.TIPO))
                            {
                                ArrayErrors.Add("error al eliminar el archivo " + fileItem.FILEPATHNAME);
                                bRetorno = false;
                            }
                        }

                    }






                }
            }


            return bRetorno;
        }



        string GetFileName(string szPath)
        {
            string[] s_arr = szPath.Split(new char[] { '\\' });
            return s_arr[s_arr.Length - 1];
        }
        string GetPath(string szPath)
        {
            string[] s_arr = szPath.Split(new char[] { '/' });
            StringBuilder strBuilder = new StringBuilder();

            for(int i = 0; i< (s_arr.Length - 1);  i++)
             {
                strBuilder.Append(s_arr[i]);
                if(i<(s_arr.Length - 2))
                    strBuilder.Append("/");
             }
            return strBuilder.ToString();
        }





        public bool DescargarArchivoMatriz(iPos.Tools.FileItem fileItem, FbTransaction st, short iTipo)
        {

            CIMP_FILESD impFileD = new CIMP_FILESD();
            CIMP_FILESBE impFileBE = new CIMP_FILESBE();
            string strLocalFile;


            try
            {
                strLocalFile = System.IO.Path.GetFileName(fileItem.FILEPATHNAME);/*.Replace(".", "_") + ".dbf"*/;


                impFileBE.IIF_FECHA = fileItem.FECHA;
                impFileBE.IIF_TIME = fileItem.FECHA.TimeOfDay;
                impFileBE.IIF_REMOTE_FILE = fileItem.FILEPATHNAME;
                impFileBE.IIF_TIPO = iTipo;
                impFileBE.IIF_STATUS = CIMP_FILESD.Status_Bajado;
                impFileBE.IIF_FILE = strLocalFile;
                impFileBE.IIF_SUCURSALCLAVE = fileItem.SUCURSALCLAVE;
                impFileBE.IIF_SUCURSALID = fileItem.SUCURSALID;

                string fileToDelete = ImportarDBF.GetLocalLocationMatriz(iTipo,fileItem.SUCURSALCLAVE,CurrentUserID.CurrentParameters) + System.IO.Path.GetFileName(fileItem.FILEPATHNAME);
                string LocalFolder = ImportarDBF.GetLocalLocationMatriz(iTipo, fileItem.SUCURSALCLAVE, CurrentUserID.CurrentParameters);

                if (!Directory.Exists(LocalFolder ))
                    Directory.CreateDirectory(LocalFolder);
                if (File.Exists(fileToDelete))
                    File.Delete(fileToDelete);
                if (!iPos.Tools.FTPManagement.Download(LocalFolder, GetPath(fileItem.FILEPATHNAME), System.IO.Path.GetFileName(fileItem.FILEPATHNAME), false))
                    return false;





                int iRes = impFileD.YaSeAgregoAImpFiles(impFileBE, st);
                if (iRes == -1)
                {
                    this.IComentario = impFileD.IComentario;
                    return false;
                }
                if (iRes == 0)
                {
                    impFileBE = impFileD.MATRIZ_PED_IMP_FILES_INSERT(impFileBE, st);
                    if (impFileBE == null)
                    {
                        this.IComentario = impFileD.IComentario;
                        return false;
                    }
                }
            }
            catch(Exception ex)
            {
                //add exception to program log
                return false;
            }
            return true;

        }




        public long ObtenerIdSucursal(string sucursalClave)
        {
            CSUCURSALD sucD = new CSUCURSALD();
            CSUCURSALBE sucBE = new CSUCURSALBE();
            sucBE.ICLAVE = sucursalClave;
            sucBE = sucD.seleccionarSUCURSALPorClave(sucBE, null);

            return sucBE != null ? sucBE.IID : 0;
        }

        public bool DescargarArchivo(iPos.Tools.FileItem fileItem, FbTransaction st,short iTipo)
        {

            CIMP_FILESD impFileD = new CIMP_FILESD();
            CIMP_FILESBE impFileBE = new CIMP_FILESBE();
            string strLocalFile;


            try
            {

                if (iTipo != CIMP_FILESD.FileType_SolicitudMercancia && iTipo != CIMP_FILESD.FileType_Traslados && iTipo != CIMP_FILESD.FileType_ExistenciasGen && iTipo != CIMP_FILESD.FileType_TrasladosDevo)
                    strLocalFile = System.IO.Path.GetFileName(fileItem.FILEPATHNAME);
                else
                    strLocalFile = System.IO.Path.GetFileName(fileItem.FILEPATHNAME).Replace(".", "_") + ".dbf";


                impFileBE.IIF_FECHA = fileItem.FECHA;
                impFileBE.IIF_TIME = fileItem.FECHA.TimeOfDay;
                impFileBE.IIF_REMOTE_FILE = fileItem.FILEPATHNAME;
                impFileBE.IIF_TIPO = iTipo;
                impFileBE.IIF_STATUS = CIMP_FILESD.Status_Bajado;
                impFileBE.IIF_FILE = strLocalFile;

                //obtener la sucursal
                if (iTipo == CIMP_FILESD.FileType_SolicitudMercancia)
                {
                    string[] splBuffer = fileItem.FILEPATHNAME.Split('.');
                    if (splBuffer.Length > 0)
                    {
                        impFileBE.IIF_SUCURSALCLAVE = splBuffer[splBuffer.Length - 1];
                        impFileBE.IIF_SUCURSALID = ObtenerIdSucursal(impFileBE.IIF_SUCURSALCLAVE);
                    }
                }

                string fileToDelete = ImportarDBF.GetLocalLocation(iTipo) + System.IO.Path.GetFileName(fileItem.FILEPATHNAME);

                try
                {
                    string pathDownload = ImportarDBF.GetLocalLocation(iTipo);
                    bool exists = System.IO.Directory.Exists(pathDownload);
                    if (!exists)
                        System.IO.Directory.CreateDirectory(pathDownload);
                }
                catch
                {

                }


                if (File.Exists(fileToDelete))
                    File.Delete(fileToDelete);

                
                if (!iPos.Tools.FTPManagement.Download(ImportarDBF.GetLocalLocation(iTipo), GetPath(fileItem.FILEPATHNAME), System.IO.Path.GetFileName(fileItem.FILEPATHNAME),false))
                    return false;

                

                //necesitamos renombrar el archivo con extension dbf en el caso de traslados
                if (iTipo == CIMP_FILESD.FileType_SolicitudMercancia || iTipo == CIMP_FILESD.FileType_Traslados || iTipo == CIMP_FILESD.FileType_ExistenciasGen || iTipo == CIMP_FILESD.FileType_TrasladosDevo)
                {

                    string fileToRename = fileToDelete;

                    fileToDelete = ImportarDBF.GetLocalLocation(iTipo) + System.IO.Path.GetFileName(fileItem.FILEPATHNAME).Replace(".", "_") + ".dbf";
                    if (File.Exists(fileToDelete))
                        File.Delete(fileToDelete);

                    File.Move(fileToRename, fileToDelete);

                }


                int iRes = impFileD.YaSeAgregoAImpFiles(impFileBE, st);
                if (iRes == -1)
                {
                    this.IComentario = impFileD.IComentario;
                    return false;
                }
                if (iRes == 0)
                {
                    impFileBE = impFileD.AgregarIMP_FILES(impFileBE, st);
                    if (impFileBE == null)
                    {
                        this.IComentario = impFileD.IComentario;
                        return false;
                    }
                }
                else
                {
                    switch (iTipo)
                    {
                        case CIMP_FILESD.FileType_Producto:
                            if (!impFileD.CambiarIMP_FILES(impFileBE, impFileBE, st))
                                return false;
                            break;
                        default: break;
                    }

                }
            }
            catch
            {
                //add exception to program log
                return false;
            }
            return true;

        }






        public bool EliminarArchivo(iPos.Tools.FileItem fileItem, short iTipo)
        {

            CIMP_FILESD impFileD = new CIMP_FILESD();
            CIMP_FILESBE impFileBE = new CIMP_FILESBE();
            //string strLocalFile;


            try
            {

                if (!iPos.Tools.FTPManagement.DeleteFTP(System.IO.Path.GetFileName(fileItem.FILEPATHNAME), GetPath(fileItem.FILEPATHNAME)) )
                    return false;

            }
            catch
            {
                //add exception to program log
                return false;
            }
            return true;

        }




        public bool DescomprimirArchivo(iPos.Tools.FileItem fileItem,  short iTipo)
        {
            string strLocalFile = ImportarDBF.GetLocalLocation(iTipo) + "\\" + System.IO.Path.GetFileName(fileItem.FILEPATHNAME);
            //string strFileWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(fileItem.FILEPATHNAME);
            string strOutPutFolder = ImportarDBF.GetLocalLocation(iTipo) + "\\" + System.IO.Path.GetFileNameWithoutExtension(fileItem.FILEPATHNAME);
            string strFileExtension = System.IO.Path.GetExtension(fileItem.FILEPATHNAME).Trim().ToUpper();

            if (strFileExtension == ".ZIP" && (iTipo == CIMP_FILESD.FileType_Producto || iTipo == CIMP_FILESD.FileType_RecComprasAux || iTipo == CIMP_FILESD.FileType_TrasladosAux || iTipo == CIMP_FILESD.FileType_PreciosTemp))
            {
                if (Directory.Exists(strOutPutFolder))
                    Directory.Delete(strOutPutFolder, true);

                ZipUtil.UnZipFiles(strLocalFile, strOutPutFolder, null, false);
            }

            if (iTipo == CIMP_FILESD.FileType_RecComprasAux || iTipo == CIMP_FILESD.FileType_TrasladosAux)
            {
                File.Delete(strLocalFile);
            }
            return true;
        }

        public bool CopiarArchivosAdicionales(iPos.Tools.FileItem fileItem, short iTipo)
        {
            string strLocalFile = ImportarDBF.GetLocalLocation(iTipo) + "\\" + System.IO.Path.GetFileName(fileItem.FILEPATHNAME);
            string strOutPutFolder = ImportarDBF.GetLocalLocation(iTipo) + "\\" + System.IO.Path.GetFileNameWithoutExtension(fileItem.FILEPATHNAME);
            string strFileExtension = System.IO.Path.GetExtension(fileItem.FILEPATHNAME).Trim().ToUpper();
            if (strFileExtension == ".ZIP" && (iTipo == CIMP_FILESD.FileType_Producto || iTipo == CIMP_FILESD.FileType_RecComprasAux || iTipo == CIMP_FILESD.FileType_TrasladosAux))
                File.Copy("prod.fpt", strOutPutFolder + "\\" + "prod.fpt");
            return true;
        }




        public static bool SubirArchivos()
        {
            string localPath, ftpPath;
            string localTraslaFolders;

            ArrayList resultadosExportacion = new ArrayList();

            for (int iX = 1; iX <= 12; iX++)
            {
                localPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_Ventas + "\\" + iX.ToString();
                ftpPath = ExportarDBF.FileFTPLocation_Ventas + "/" + iX.ToString() + "/";
                SubirArchivosDeCarpeta(localPath, ftpPath, true, true, ref resultadosExportacion);

            }


            //Pedidos
            localPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_Pedidos;
            ftpPath = ExportarDBF.FileFTPLocation_Pedidos + "/" ;
            SubirArchivosDeCarpeta(localPath, ftpPath, true, true, ref resultadosExportacion);


            //existencias
            localPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_ExistenciasLocales;
            ftpPath = ExportarDBF.FileFTPLocation_Existencias + "/";
            SubirArchivosDeCarpeta(localPath, ftpPath, false, false, ref resultadosExportacion);


            

            localTraslaFolders = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_TrasladosEnvios;
            
            string[] traslaDirs = Directory.GetDirectories(localTraslaFolders);
            string dirName;
            foreach (string dir in traslaDirs)
            {

                dirName = new DirectoryInfo(dir).Name;

                if (dirName == "molde")
                    continue;

                localPath = localTraslaFolders + "\\" + dirName;
                ftpPath = ExportarDBF.FileFTPLocation_Traslados + "/" + dirName + "/";
                SubirArchivosDeCarpeta(localPath, ftpPath, false, false, ref resultadosExportacion);


                ftpPath = "/" + dirName + ExportarDBF.FileFTPLocation_Traslados + "/";
                SubirArchivosDeCarpeta(localPath, ftpPath, false, true, ref resultadosExportacion);
                

            }


            //RecepcionCompras
            localPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_RecepcionCompras;
            ftpPath = ExportarDBF.FileFTPLocation_RecepcionCompras + "/";
            SubirArchivosDeCarpeta(localPath, ftpPath, true, true, ref resultadosExportacion);


            string strResultadoFinal = "";
            foreach (string strRes in resultadosExportacion)
            {
                strResultadoFinal += strRes + "\n";
            }

            MessageBox.Show(strResultadoFinal);

                return true;
            
        }


        public static bool SubirArchivosDeCarpeta(string LocalFolder, string FtpFolder,bool bEnFolderSucursal,bool bMoveLocalFile, ref ArrayList resultados)
        {
            string strReference = "";

            if (!Directory.Exists(LocalFolder))
                return true;
          
            string[] filesToUpload = Directory.GetFiles(LocalFolder);
            foreach (string localFile in filesToUpload)
            {
                try
                {
                    if (FTPManagement.Upload(LocalFolder, FtpFolder, Path.GetFileName(localFile), bEnFolderSucursal, ref strReference))
                    {

                        if (!Directory.Exists(LocalFolder + FileSubLocationUploaded))
                            Directory.CreateDirectory(LocalFolder + FileSubLocationUploaded);

                        if (File.Exists(LocalFolder + FileSubLocationUploaded + "\\" + Path.GetFileName(localFile)))
                            File.Delete(LocalFolder + FileSubLocationUploaded + "\\" + Path.GetFileName(localFile));

                        if (bMoveLocalFile)
                            File.Move(localFile, LocalFolder + FileSubLocationUploaded + "\\" + Path.GetFileName(localFile));
                    }

                    resultados.Add(strReference);
                }
                catch(Exception ex)
                {
                    resultados.Add("Hubo un error : " +ex.Message);
                }
            }
            return false;
        }




        public static bool UploadFile(string localFile,string LocalFolder, string FtpFolder, bool bEnFolderSucursal, bool bMoveLocalFile, ref ArrayList resultados)
        {
            string strReference = "";
            bool retorno = false;

            if (!Directory.Exists(LocalFolder))
                return false;
            

            try
                {
                    if (FTPManagement.Upload(LocalFolder, FtpFolder, localFile, bEnFolderSucursal, ref strReference))
                    {

                        if (!Directory.Exists(LocalFolder + FileSubLocationUploaded))
                            Directory.CreateDirectory(LocalFolder + FileSubLocationUploaded);

                        if (File.Exists(LocalFolder + FileSubLocationUploaded + "\\" + localFile))
                            File.Delete(LocalFolder + FileSubLocationUploaded + "\\" + localFile);

                        if (bMoveLocalFile)
                            File.Move(LocalFolder + "\\" + localFile, LocalFolder + FileSubLocationUploaded + "\\" + Path.GetFileName(localFile));


                        retorno = true;

                    }

                    resultados.Add(strReference);
                }
                catch (Exception ex)
                {
                    resultados.Add("Hubo un error : (801)" + ex.Message + " " + LocalFolder + " " + localFile );
                    retorno = false;
                }

                return retorno;
        }






        public string ObtenerClaveSucursalDestino(int folio, long lTipoDoctoId)
        {

            CDOCTOBE doctoBE = new CDOCTOBE();
            CDOCTOD doctoD = new CDOCTOD();
            doctoBE.ITIPODOCTOID = lTipoDoctoId; ;
            doctoBE.IFOLIO = folio;
            return doctoD.ObtenerClaveSucDestXTIPOYFOLIO(doctoBE, null);

        }


        public string ObtenerClaveSucursalDestinoXId(long sucursalId)
        {

            CSUCURSALBE sucBE = new CSUCURSALBE();
            CSUCURSALD sucD = new CSUCURSALD();
            sucBE.IID = sucursalId;
            sucBE = sucD.seleccionarSUCURSAL(sucBE, null);

            if (sucBE != null)
                return sucBE.ICLAVE;

            return "";


        }

        public bool EnvirArchivosAFtp(ref  ArrayList resultadosExportacion)
        {
            bool bRetorno = true, bRes = true;

            if (m_Exporting)
            {
                resultadosExportacion.Add("Hay otro proceso de exportacion ejecutandose " + m_UltimoExporting);
                return false;
            }
            m_Exporting = true;
            m_UltimoExporting = "1- EnvirArchivosAFtp";


            CEXP_FILESD filesExpD = new CEXP_FILESD();
            CEXP_FILESBE filesExpBE = new CEXP_FILESBE();

            CPARAMETROBE parametroBE = new CPARAMETROBE();
            CPARAMETROD parametroD = new CPARAMETROD();
            CCAJAD cajaD = new CCAJAD();
            CCAJABE cajaBE = new CCAJABE();

            ExportarDBF exportDbf = new ExportarDBF();
            //ArrayList resultadosExportacion = new ArrayList();


            System.Collections.ArrayList parts = new ArrayList();
            //FbParameter auxPar;
            FbParameter[] arParms = new FbParameter[parts.Count];
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            

            bool bArchivoGenerado, bArchivoSubido;
            string localPath, ftpPath;
            string claveSucDest = "";

            

            //fase 1 agregar los registros en exp_files que se necesitan exportar
            bRes = filesExpD.UPDATE_EXP_FILES(null);


            //get data for the generation of the dbfs
            parametroBE = parametroD.seleccionarPARAMETROActual(null);
            if (parametroBE == null)
            {
                m_Exporting = false;
                m_UltimoExporting = "";
                return false;
            }
            if (parametroBE.ISUCURSALNUMERO == "")
            {
                m_Exporting = false;
                m_UltimoExporting = "";
                return false;
            }

            cajaBE.IID = iPos.CurrentUserID.CurrentCompania.IEM_CAJA;
            cajaBE = cajaD.seleccionarCAJA(cajaBE, null);
            if (cajaBE == null)
            {
                m_Exporting = false;
                m_UltimoExporting = "";
                return false;
            }




            //recorre la fila de archivos a exportar
            try
            {


                String CmdTxt = @"select * from EXP_FILES where ESTATUS = 'A'  ";
                parts.CopyTo(arParms, 0);


                if(parametroBE.IDIASMAXEXPFTP > 0)
                {
                    CmdTxt += "  and  FECHA >= dateadd( -"  + parametroBE.IDIASMAXEXPFTP + " day to current_date ) "   ;
                }


                dr = SqlHelper.ExecuteReader(ConexionesBD.ConexionBD.ConexionString(), CommandType.Text, CmdTxt, out pcn, arParms);


                while (dr.Read())
                {
                    filesExpBE = filesExpD.GET_EXP_FILE_FROM_DR(dr);
                    bArchivoGenerado = false;

                    //si es archivo auxiliar y no aplica por la configuracion continuar
                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_TRASLADOAUX && !parametroBE.IEXPORTCATALOGOAUX.Equals("S"))
                    {
                        continue;
                    }


                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_VENTA)
                    {
                        if (!exportDbf.ExportVentas(parametroBE, cajaBE, filesExpBE.IFECHA))
                            resultadosExportacion.Add("Error " + exportDbf.IComentario);
                        else
                            bArchivoGenerado = true;
                    }

                    /*
                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_PEDIDO)
                    {

                        string bufferFileName = "";
                        long lPedido = 0;
                        if (!exportDbf.ExportPedidos(parametroBE, cajaBE, filesExpBE.IFECHA, filesExpBE.IFECHATO, true, ref lPedido, ref bufferFileName))
                            resultadosExportacion.Add("Error " + exportDbf.IComentario);
                        else
                        {
                            bArchivoGenerado = true;

                            filesExpBE.INOMBRE = bufferFileName;
                            filesExpBE.IARCHIVOFTP = bufferFileName;
                            filesExpBE.IDOCTOID = lPedido;
                        }
                    }
                     */


                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_TRASLADO)
                    {

                            if (!exportDbf.ExportTrasladosEnvios(parametroBE, cajaBE, filesExpBE.IFECHA, filesExpBE.IDOCTOFOLIO, CurrentUserID.SUCURSAL_CLAVE))
                                resultadosExportacion.Add("Error " + exportDbf.IComentario);
                            else
                                bArchivoGenerado = true;
                    }

                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_TRASLADOAUX && parametroBE.IEXPORTCATALOGOAUX.Equals("S"))
                    {

                        if (!exportDbf.ExportTrasladosEnviosAux(parametroBE, cajaBE, filesExpBE.IFECHA, filesExpBE.IDOCTOFOLIO, parametroBE.ISUCURSALNUMERO, filesExpBE.IDOCTOID, CurrentUserID.CurrentUser, null)
                            )
                            resultadosExportacion.Add("Error " + exportDbf.IComentario);
                        else
                            bArchivoGenerado = true;
                    }



                        if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_TRASLADODEVO)
                    {

                        if (!exportDbf.ExportTrasladosDevoEnvios(parametroBE, cajaBE, filesExpBE.IFECHA, filesExpBE.IDOCTOFOLIO, CurrentUserID.SUCURSAL_CLAVE))
                            resultadosExportacion.Add("Error " + exportDbf.IComentario);
                        else
                            bArchivoGenerado = true;
                    }

                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_RECEPCIONCOMPRA)
                    {
                        if (!exportDbf.ExportRecepcionCompras(parametroBE, cajaBE, filesExpBE.IFECHA,filesExpBE.IDOCTOID))
                            resultadosExportacion.Add("Error " + exportDbf.IComentario);
                        else
                            bArchivoGenerado = true;
                    }


                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_PEDIDODEVO)
                    {

                        if (!exportDbf.ExportPedidosDevoEnvios(parametroBE, cajaBE, filesExpBE.IFECHA, filesExpBE.IDOCTOFOLIO, CurrentUserID.SUCURSAL_CLAVE))
                            resultadosExportacion.Add("Error " + exportDbf.IComentario);
                        else
                            bArchivoGenerado = true;
                    }


                    if (bArchivoGenerado)
                    {
                        filesExpBE.IESTATUS = DBValues._EXP_FILES_ESTATUS_GENERADO;
                        if (!filesExpD.CambiarEXP_FILESD(filesExpBE, filesExpBE, null))
                        {
                            resultadosExportacion.Add("Error " + filesExpD.IComentario);
                        }
                        resultadosExportacion.Add("Archivo " + filesExpBE.IARCHIVOFTP + " generado");
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                m_Exporting = false;
                m_UltimoExporting = "";
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return false;
            }


            ////generar archivo de existencias
            //if (!exportDbf.ExportExistencias(parametroBE, CurrentUserID.SUCURSAL_CLAVE))
            //    resultadosExportacion.Add("Error " + exportDbf.IComentario);
            //else
            //    resultadosExportacion.Add("El Archivo de existencias has sido generado");




            //recorre la lista de archivos a exportar para enviarlos al FTP
            try
            {


                String CmdTxt = @"select * from EXP_FILES where ESTATUS = 'G'  ";
                dr = SqlHelper.ExecuteReader(ConexionesBD.ConexionBD.ConexionString(), CommandType.Text, CmdTxt, out pcn, arParms);


                while (dr.Read())
                {
                    filesExpBE = filesExpD.GET_EXP_FILE_FROM_DR(dr);
                    bArchivoSubido = false;

                    //si es archivo auxiliar y no aplica por la configuracion continuar
                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_TRASLADOAUX && !parametroBE.IEXPORTCATALOGOAUX.Equals("S"))
                    {
                        continue;
                    }

                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_VENTA)
                    {
                        localPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_Ventas + "\\" + filesExpBE.IFECHA.Month.ToString();
                        ftpPath = ExportarDBF.FileFTPLocation_Ventas + "/" + filesExpBE.IFECHA.Month.ToString() + "/";

                        if (UploadFile(filesExpBE.INOMBRE, localPath, ftpPath, true, true, ref resultadosExportacion))
                             if (UploadFile(filesExpBE.INOMBRE.Replace(ExportarDBF.FileNameVentasDetalleFTP,ExportarDBF.FileNameVentasHeaderFTP), localPath, ftpPath, true, true, ref resultadosExportacion))
                                    bArchivoSubido = true;

                    }


                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_PEDIDO)
                    {


                        bool bEnFolderSucursal = true;

                        CDOCTOD doctoD = new CDOCTOD();
                        CDOCTOBE doctoBE = new CDOCTOBE();
                        doctoBE.IID = filesExpBE.IDOCTOID;

                        doctoBE = doctoD.seleccionarDOCTO(doctoBE, null);

                        if (doctoBE == null)
                        {
                            continue;
                        }

                        if (doctoBE.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_SOLICITUDMERCANCIA)
                        {

                            claveSucDest = "";
                            claveSucDest = ObtenerClaveSucursalDestinoXId(doctoBE.ISUCURSALTID);
                            localPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_SolicitudMercancia + '/' + claveSucDest + '/';

                            ftpPath = "/" + claveSucDest + ExportarDBF.FileFTPLocation_SolicitudMercancia + "/";
                            bEnFolderSucursal = false;
                        }
                        else
                        {

                            localPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_Pedidos;
                            ftpPath = ExportarDBF.FileFTPLocation_Pedidos + "\\";
                            bEnFolderSucursal = true;
                        }


                        //localPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_Pedidos;
                        //ftpPath = ExportarDBF.FileFTPLocation_Pedidos + "\\";

                        if (UploadFile(filesExpBE.INOMBRE, localPath, ftpPath, bEnFolderSucursal, true, ref resultadosExportacion))
                            //if (UploadFile(filesExpBE.INOMBRE.Replace(ExportarDBF.FileNamePedidosDetalleFTP, ExportarDBF.FileNamePedidosHeaderFTP), localPath, ftpPath, true, true, ref resultadosExportacion))
                                bArchivoSubido = true;
                    }


                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_TRASLADO)
                    {
                        claveSucDest = ObtenerClaveSucursalDestino(filesExpBE.IDOCTOFOLIO, DBValues._DOCTO_TIPO_TRASPASO_ENVIO);
                        localPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_TrasladosEnvios + '/' + claveSucDest + '/';

                        bArchivoSubido = true;

                        /*ftpPath = ExportarDBF.FileFTPLocation_Traslados + "/" + claveSucDest + "/";
                        if (!UploadFile(filesExpBE.INOMBRE, localPath, ftpPath, false, false, ref resultadosExportacion))
                            bArchivoSubido = false;*/

                        ftpPath = "/" + claveSucDest + ExportarDBF.FileFTPLocation_Traslados + "/";
                        if (!UploadFile(filesExpBE.INOMBRE, localPath, ftpPath, false, true, ref resultadosExportacion))
                            bArchivoSubido = false;

                    }


                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_TRASLADOAUX && parametroBE.IEXPORTCATALOGOAUX.Equals("S"))
                    {
                        claveSucDest = ObtenerClaveSucursalDestino(filesExpBE.IDOCTOFOLIO, DBValues._DOCTO_TIPO_TRASPASO_ENVIO);
                        localPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_TrasladosEnviosAux + '/' + claveSucDest + '/';

                        bArchivoSubido = true;


                        ftpPath = "/" + claveSucDest + ExportarDBF.FileFTPLocation_TrasladosAux + "/";
                        if (!UploadFile(filesExpBE.INOMBRE, localPath, ftpPath, false, true, ref resultadosExportacion))
                            bArchivoSubido = false;

                    }


                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_TRASLADODEVO)
                    {
                        claveSucDest = ObtenerClaveSucursalDestino(filesExpBE.IDOCTOFOLIO, DBValues._DOCTO_TIPO_TRASPASO_REC);
                        localPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_TrasladosDevoEnvios + '/' + claveSucDest + '/';

                        bArchivoSubido = true;


                        ftpPath = "/" + claveSucDest + ExportarDBF.FileFTPLocation_TrasladosDevo + "/";
                        if (!UploadFile(filesExpBE.INOMBRE, localPath, ftpPath, false, true, ref resultadosExportacion))
                            bArchivoSubido = false;

                    }


                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_RECEPCIONCOMPRA)
                    {
                        localPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_RecepcionCompras ;
                        ftpPath = ExportarDBF.FileFTPLocation_RecepcionCompras + "/";
                        if (UploadFile(filesExpBE.INOMBRE, localPath, ftpPath, true,  true, ref resultadosExportacion))
                            bArchivoSubido = true;

                    }


                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_PEDIDODEVO)
                    {
                        claveSucDest = ObtenerClaveSucursalDestino(filesExpBE.IDOCTOFOLIO, DBValues._DOCTO_TIPO_COMPRA);
                        localPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_PedidosDevoEnvios + '/' + claveSucDest + '/';

                        bArchivoSubido = true;


                        ftpPath = "/" + claveSucDest + ExportarDBF.FileFTPLocation_PedidosDevo + "/";
                        if (!UploadFile(filesExpBE.INOMBRE, localPath, ftpPath, false, true, ref resultadosExportacion))
                            bArchivoSubido = false;

                    }


                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_INVENTARIO)
                    {
                        localPath = System.AppDomain.CurrentDomain.BaseDirectory + EnviosMail.FileLocalLocation_Excel;
                        ftpPath = ExportarDBF.FileFTPLocation_Inventarios + "/";
                        if (UploadFile(filesExpBE.INOMBRE, localPath, ftpPath, true, false, ref resultadosExportacion))
                            bArchivoSubido = true;

                    }



                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_INV_MAIL)
                    {
                        string strArchivo = System.AppDomain.CurrentDomain.BaseDirectory + EnviosMail.FileLocalLocation_Excel + "\\" + filesExpBE.INOMBRE;
                        if (EnviosMail.EnviarInventario("", strArchivo))
                            bArchivoSubido = true;

                    }


                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_REC_ELIM_MAIL)
                    {
                        
                        if (filesExpBE.INOMBRE != null && filesExpBE.INOMBRE.Trim().Length > 0)
                        {
                            string strArchivo = System.AppDomain.CurrentDomain.BaseDirectory + EnviosMail.FileLocalLocation_Excel + "\\" + filesExpBE.INOMBRE;

                            if (EnviosMail.EnviarRecepcionEliminada("", strArchivo))
                                bArchivoSubido = true;
                        }
                        else
                        {
                            bArchivoSubido = true;
                        }

                    }



                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_MATRIZPEDIDO)
                    {
                        claveSucDest = ObtenerClaveSucursalDestino(filesExpBE.IDOCTOFOLIO, DBValues._DOCTO_TIPO_PEDIDO_TRASPASO_SALIDA);
                        localPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_MatrizEnviosSucursales + claveSucDest + '\\';

                        bArchivoSubido = true;

                        ftpPath = "/" + claveSucDest + ExportarDBF.FileFTPLocation_MatrizEnvioPedidos + "/";

                        if (!UploadFile(filesExpBE.INOMBRE, localPath, ftpPath, false, true, ref resultadosExportacion))
                            bArchivoSubido = false;

                    }

                    

                    if (bArchivoSubido)
                    {
                        filesExpBE.IESTATUS = DBValues._EXP_FILES_ESTADOS_ENVIADO;
                        if (!filesExpD.CambiarEXP_FILESD(filesExpBE, filesExpBE, null))
                        {
                            resultadosExportacion.Add("Error " + filesExpD.IComentario);
                        }
                        resultadosExportacion.Add("Archivo " + filesExpBE.IARCHIVOFTP + " enviado");



                        if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_TRASLADO)
                        {
                            CDOCTOD doctoD = new CDOCTOD();
                            CDOCTOBE doctoBE = new CDOCTOBE();
                            doctoBE.IID = filesExpBE.IDOCTOID;
                            doctoBE.ITRANREGSERVER = DBValues._DB_BOOLVALUE_NO;
                            doctoD.CambiarTranRegServerDOCTOD(doctoBE, null);

                            HiloExistencias._IFLAGENVIARREGISTROTRASLAEVENTOS++;
                        }
                         if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_PEDIDO)
                         {
                             CDOCTOD doctoD = new CDOCTOD();
                            CDOCTOBE doctoBE = new CDOCTOBE();
                            doctoBE.IID = filesExpBE.IDOCTOID;
                            doctoBE.ITRASLADOAFTP = DBValues._DB_BOOLVALUE_SI;
                            doctoD.CambiarEnviadoFTPDOCTOD(doctoBE, null);
                         }

                         if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_TRASLADODEVO)
                         {
                             CDOCTOD doctoD = new CDOCTOD();
                             CDOCTOBE doctoBE = new CDOCTOBE();
                             doctoBE.IID = filesExpBE.IDOCTOID;
                             doctoBE.ITRASLADOAFTP = DBValues._DB_BOOLVALUE_SI;
                             doctoD.CambiarEnviadoFTPDOCTOD(doctoBE, null);
                         }


                         if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_PEDIDODEVO)
                         {
                             CDOCTOD doctoD = new CDOCTOD();
                             CDOCTOBE doctoBE = new CDOCTOBE();
                             doctoBE.IID = filesExpBE.IDOCTOID;
                             doctoBE.ITRASLADOAFTP = DBValues._DB_BOOLVALUE_SI;
                             doctoD.CambiarEnviadoFTPDOCTOD(doctoBE, null);
                         }


                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                m_Exporting = false;
                m_UltimoExporting = "";
                return false;
            }



            ////existencias
            //string fileExistencias = ExportarDBF.FileNameExistenciasFTP + "." + CurrentUserID.SUCURSAL_CLAVE;
            //localPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_ExistenciasLocales;
            //ftpPath = ExportarDBF.FileFTPLocation_Existencias + "/";
            //UploadFile(fileExistencias, localPath, ftpPath, false, false, ref resultadosExportacion);


            m_Exporting = false;
            m_UltimoExporting = "";
            Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
            return bRetorno;
        }




        public bool EnviarArchivosAFtpDeTraslados(ref  ArrayList resultadosExportacion, int folio)
        {
            bool bRetorno = true, bRes = true;

            if (m_Exporting)
            {
                resultadosExportacion.Add("Hay otro proceso de exportacion ejecutandose " + m_UltimoExporting);
                return false;
            }
            m_Exporting = true;
            m_UltimoExporting = "2- EnviarArchivosAFtpDeTraslados";


            CEXP_FILESD filesExpD = new CEXP_FILESD();
            CEXP_FILESBE filesExpBE = new CEXP_FILESBE();

            CPARAMETROBE parametroBE = new CPARAMETROBE();
            CPARAMETROD parametroD = new CPARAMETROD();
            CCAJAD cajaD = new CCAJAD();
            CCAJABE cajaBE = new CCAJABE();

            ExportarDBF exportDbf = new ExportarDBF();
            //ArrayList resultadosExportacion = new ArrayList();


            System.Collections.ArrayList parts = new ArrayList();
            FbParameter auxPar;

            auxPar = new FbParameter("@FOLIO", FbDbType.Integer);
            auxPar.Value = folio;
            parts.Add(auxPar);

            FbParameter[] arParms = new FbParameter[parts.Count];
            parts.CopyTo(arParms, 0);


            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            bool bArchivoGenerado = false, bArchivoSubido = false;
            string localPath, ftpPath;
            string claveSucDest = "";



            //fase 1 agregar los registros en exp_files que se necesitan exportar
            bRes = filesExpD.UPD_EXP_FILES_TRA(folio, null);


            //get data for the generation of the dbfs
            parametroBE = parametroD.seleccionarPARAMETROActual(null);
            if (parametroBE == null)
            {
                m_Exporting = false;
                m_UltimoExporting = "";
                return false;
            }
            if (parametroBE.ISUCURSALNUMERO == "")
            {
                m_Exporting = false;
                m_UltimoExporting = "";
                return false;
            }

            cajaBE.IID = iPos.CurrentUserID.CurrentCompania.IEM_CAJA;
            cajaBE = cajaD.seleccionarCAJA(cajaBE, null);
            if (cajaBE == null)
            {
                m_Exporting = false;
                m_UltimoExporting = "";
                return false;
            }


            //recorre la fila de archivos a exportar
            try
            {


                String CmdTxt = @"select * from EXP_FILES where ESTATUS = 'A' and TIPO in ( 'T', 'U')  and DOCTOFOLIO = @FOLIO";
                parts.CopyTo(arParms, 0);


                dr = SqlHelper.ExecuteReader(ConexionesBD.ConexionBD.ConexionString(), CommandType.Text, CmdTxt, out pcn, arParms);


                while (dr.Read())
                {
                    filesExpBE = filesExpD.GET_EXP_FILE_FROM_DR(dr);
                    bArchivoGenerado = false;

                    //si es archivo auxiliar y no aplica por la configuracion continuar
                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_TRASLADOAUX && !parametroBE.IEXPORTCATALOGOAUX.Equals("S"))
                    {
                        continue;
                    }


                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_TRASLADO)
                    {
                        
                        if (!exportDbf.ExportTrasladosEnvios(parametroBE, cajaBE, filesExpBE.IFECHA, filesExpBE.IDOCTOFOLIO, parametroBE.ISUCURSALNUMERO)
                            )
                            resultadosExportacion.Add("Error " + exportDbf.IComentario);
                        else
                            bArchivoGenerado = true;
                    }

                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_TRASLADOAUX && parametroBE.IEXPORTCATALOGOAUX.Equals("S"))
                    {

                        if (!exportDbf.ExportTrasladosEnviosAux(parametroBE, cajaBE, filesExpBE.IFECHA, filesExpBE.IDOCTOFOLIO, parametroBE.ISUCURSALNUMERO, filesExpBE.IDOCTOID, CurrentUserID.CurrentUser,null)
                            )
                            resultadosExportacion.Add("Error " + exportDbf.IComentario);
                        else
                            bArchivoGenerado = true;
                    }



                    if (bArchivoGenerado)
                    {
                        filesExpBE.IESTATUS = DBValues._EXP_FILES_ESTATUS_GENERADO;
                        if (!filesExpD.CambiarEXP_FILESD(filesExpBE, filesExpBE, null))
                        {
                            resultadosExportacion.Add("Error " + filesExpD.IComentario);
                            bRetorno = false;
                        }
                        resultadosExportacion.Add("Archivo " + filesExpBE.IARCHIVOFTP + " generado");

                    }
                    else
                    {
                        resultadosExportacion.Add("Archivo " + filesExpBE.IARCHIVOFTP + " NO pudo ser generado");
                        bRetorno = false;
                    }



                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                m_Exporting = false;
                m_UltimoExporting = "";
                return false;
            }

            //recorre la lista de archivos a exportar para enviarlos al FTP
            try
            {


                String CmdTxt = @"select * from EXP_FILES where ESTATUS = 'G' and TIPO in ( 'T', 'U')  and DOCTOFOLIO = @FOLIO";
                dr = SqlHelper.ExecuteReader(ConexionesBD.ConexionBD.ConexionString(), CommandType.Text, CmdTxt, out pcn, arParms);


                while (dr.Read())
                {

                    filesExpBE = filesExpD.GET_EXP_FILE_FROM_DR(dr);
                    bArchivoSubido = false;

                    //si es archivo auxiliar y no aplica por la configuracion continuar
                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_TRASLADOAUX && !parametroBE.IEXPORTCATALOGOAUX.Equals("S"))
                    {
                        continue;
                    }

                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_TRASLADO)
                    {

                        claveSucDest = ObtenerClaveSucursalDestino(filesExpBE.IDOCTOFOLIO, DBValues._DOCTO_TIPO_TRASPASO_ENVIO);
                        localPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_TrasladosEnvios + '/' + claveSucDest + '/';

                        bArchivoSubido = true;

                        /*ftpPath = ExportarDBF.FileFTPLocation_Traslados + "/" + claveSucDest + "/";
                        if (!UploadFile(filesExpBE.INOMBRE, localPath, ftpPath, false, false, ref resultadosExportacion))
                            bArchivoSubido = false;*/

                        ftpPath = "/" + claveSucDest + ExportarDBF.FileFTPLocation_Traslados + "/";
                        if (!UploadFile(filesExpBE.INOMBRE, localPath, ftpPath, false, true, ref resultadosExportacion))
                        {
                            resultadosExportacion.Add("El archivo no pudo ser enviado a internet, se intentara enviar automaticamente cuando se reestablezca el internet");
                            bArchivoSubido = false;
                            bRetorno = false;
                        }
                    }



                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_TRASLADOAUX && parametroBE.IEXPORTCATALOGOAUX.Equals("S"))
                    {
                        claveSucDest = ObtenerClaveSucursalDestino(filesExpBE.IDOCTOFOLIO, DBValues._DOCTO_TIPO_TRASPASO_ENVIO);
                        localPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_TrasladosEnviosAux + '/' + claveSucDest + '/';

                        bArchivoSubido = true;


                        ftpPath = "/" + claveSucDest + ExportarDBF.FileFTPLocation_TrasladosAux + "/";
                        if (!UploadFile(filesExpBE.INOMBRE, localPath, ftpPath, false, true, ref resultadosExportacion))
                        {
                            bArchivoSubido = false;
                            bRetorno = false;
                        }

                    }



                    if (bArchivoSubido)
                    {
                        filesExpBE.IESTATUS = DBValues._EXP_FILES_ESTADOS_ENVIADO;
                        if (!filesExpD.CambiarEXP_FILESD(filesExpBE, filesExpBE, null))
                        {
                            resultadosExportacion.Add("Error " + filesExpD.IComentario);
                        }
                        resultadosExportacion.Add("Archivo " + filesExpBE.IARCHIVOFTP + " enviado");


                        if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_TRASLADO)
                        {

                            CDOCTOD doctoD = new CDOCTOD();
                            CDOCTOBE doctoBE = new CDOCTOBE();
                            doctoBE.IID = filesExpBE.IDOCTOID;
                            doctoBE.ITRANREGSERVER = DBValues._DB_BOOLVALUE_NO;
                            doctoD.CambiarTranRegServerDOCTOD(doctoBE, null);

                            HiloExistencias._IFLAGENVIARREGISTROTRASLAEVENTOS++;
                        }
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                m_Exporting = false;
                m_UltimoExporting = "";
                return false;
            }


            m_Exporting = false;
            m_UltimoExporting = "";
            Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
            return bRetorno;
        }





        public bool EnviarArchivosAFtpDeTrasladosDevo(ref  ArrayList resultadosExportacion, int folio)
        {
            bool bRetorno = true, bRes = true;

            //if (m_Exporting)
            //{
            //    resultadosExportacion.Add("Hay otro proceso de exportacion ejecutandose");
            //    return false;
            //}
            //m_Exporting = true;


            CEXP_FILESD filesExpD = new CEXP_FILESD();
            CEXP_FILESBE filesExpBE = new CEXP_FILESBE();

            CPARAMETROBE parametroBE = new CPARAMETROBE();
            CPARAMETROD parametroD = new CPARAMETROD();
            CCAJAD cajaD = new CCAJAD();
            CCAJABE cajaBE = new CCAJABE();

            ExportarDBF exportDbf = new ExportarDBF();
            //ArrayList resultadosExportacion = new ArrayList();


            System.Collections.ArrayList parts = new ArrayList();
            FbParameter auxPar;

            auxPar = new FbParameter("@FOLIO", FbDbType.Integer);
            auxPar.Value = folio;
            parts.Add(auxPar);

            FbParameter[] arParms = new FbParameter[parts.Count];
            parts.CopyTo(arParms, 0);


            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;
            bool bArchivoGenerado = false, bArchivoSubido = false;
            string localPath, ftpPath;
            string claveSucDest = "";



            //fase 1 agregar los registros en exp_files que se necesitan exportar
            bRes = filesExpD.UPD_EXP_FILES_TRADEVO(folio, null);


            //get data for the generation of the dbfs
            parametroBE = parametroD.seleccionarPARAMETROActual(null);
            if (parametroBE == null)
            {
                m_Exporting = false;
                m_UltimoExporting = "";
                return false;
            }
            if (parametroBE.ISUCURSALNUMERO == "")
            {
                m_Exporting = false;
                m_UltimoExporting = "";
                return false;
            }

            cajaBE.IID = iPos.CurrentUserID.CurrentCompania.IEM_CAJA;
            cajaBE = cajaD.seleccionarCAJA(cajaBE, null);
            if (cajaBE == null)
            {
                m_Exporting = false;
                m_UltimoExporting = "";
                return false;
            }


            //recorre la fila de archivos a exportar
            try
            {


                String CmdTxt = @"select * from EXP_FILES where ESTATUS = 'A' and TIPO in ( 'TD')  and DOCTOFOLIO = @FOLIO";
                parts.CopyTo(arParms, 0);


                dr = SqlHelper.ExecuteReader(ConexionesBD.ConexionBD.ConexionString(), CommandType.Text, CmdTxt, out pcn, arParms);


                while (dr.Read())
                {
                    filesExpBE = filesExpD.GET_EXP_FILE_FROM_DR(dr);
                    bArchivoGenerado = false;

                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_TRASLADODEVO)
                    {

                        if (!exportDbf.ExportTrasladosDevoEnvios(parametroBE, cajaBE, filesExpBE.IFECHA, filesExpBE.IDOCTOFOLIO, parametroBE.ISUCURSALNUMERO)
                            )
                            resultadosExportacion.Add("Error " + exportDbf.IComentario);
                        else
                            bArchivoGenerado = true;
                    }




                    if (bArchivoGenerado)
                    {
                        filesExpBE.IESTATUS = DBValues._EXP_FILES_ESTATUS_GENERADO;
                        if (!filesExpD.CambiarEXP_FILESD(filesExpBE, filesExpBE, null))
                        {
                            resultadosExportacion.Add("Error " + filesExpD.IComentario);
                            bRetorno = false;
                        }
                        resultadosExportacion.Add("Archivo " + filesExpBE.IARCHIVOFTP + " generado");

                    }
                    else
                    {

                        resultadosExportacion.Add("Archivo " + filesExpBE.IARCHIVOFTP + " NO pudo ser generado");
                        bRetorno = false;
                    }



                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                m_Exporting = false;
                m_UltimoExporting = "";
                return false;
            }

            //recorre la lista de archivos a exportar para enviarlos al FTP
            try
            {


                String CmdTxt = @"select * from EXP_FILES where ESTATUS = 'G' and TIPO in ( 'TD')  and DOCTOFOLIO = @FOLIO";
                dr = SqlHelper.ExecuteReader(ConexionesBD.ConexionBD.ConexionString(), CommandType.Text, CmdTxt, out pcn, arParms);


                while (dr.Read())
                {

                    filesExpBE = filesExpD.GET_EXP_FILE_FROM_DR(dr);
                    bArchivoSubido = false;

                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_TRASLADODEVO)
                    {

                        claveSucDest = ObtenerClaveSucursalDestino(filesExpBE.IDOCTOFOLIO, DBValues._DOCTO_TIPO_TRASPASO_REC);
                        localPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_TrasladosDevoEnvios + '/' + claveSucDest + '/';

                        bArchivoSubido = true;

                        /*ftpPath = ExportarDBF.FileFTPLocation_Traslados + "/" + claveSucDest + "/";
                        if (!UploadFile(filesExpBE.INOMBRE, localPath, ftpPath, false, false, ref resultadosExportacion))
                            bArchivoSubido = false;*/

                        ftpPath = "/" + claveSucDest + ExportarDBF.FileFTPLocation_TrasladosDevo + "/";
                        if (!UploadFile(filesExpBE.INOMBRE, localPath, ftpPath, false, true, ref resultadosExportacion))
                        {
                            resultadosExportacion.Add("El archivo no pudo ser enviado a internet, se intentara enviar automaticamente cuando se reestablezca el internet");
                            bArchivoSubido = false;
                            bRetorno = false;
                        }
                    }






                    if (bArchivoSubido)
                    {
                        filesExpBE.IESTATUS = DBValues._EXP_FILES_ESTADOS_ENVIADO;
                        if (!filesExpD.CambiarEXP_FILESD(filesExpBE, filesExpBE, null))
                        {
                            resultadosExportacion.Add("Error " + filesExpD.IComentario);
                        }
                        resultadosExportacion.Add("Archivo " + filesExpBE.IARCHIVOFTP + " enviado");


                        if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_TRASLADODEVO)
                        {

                            CDOCTOD doctoD = new CDOCTOD();
                            CDOCTOBE doctoBE = new CDOCTOBE();
                            doctoBE.IID = filesExpBE.IDOCTOID;
                            doctoBE.ITRANREGSERVER = DBValues._DB_BOOLVALUE_NO;
                            doctoD.CambiarTranRegServerDOCTOD(doctoBE, null);

                            HiloExistencias._IFLAGENVIARREGISTROTRASLAEVENTOS++;
                        }
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                m_Exporting = false;
                m_UltimoExporting = "";
                return false;
            }


            m_Exporting = false;
            m_UltimoExporting = "";
            Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
            return bRetorno;
        }





        public bool EnviarArchivosAFtpDePedidosDevo(ref  ArrayList resultadosExportacion, int folio)
        {
            bool bRetorno = true, bRes = true;

            if (m_Exporting)
            {
                resultadosExportacion.Add("Hay otro proceso de exportacion ejecutandose " + m_UltimoExporting);
                return false;
            }
            m_Exporting = true;
            m_UltimoExporting = "3- Enviar archivos a ftp de pedidos devo";


            CEXP_FILESD filesExpD = new CEXP_FILESD();
            CEXP_FILESBE filesExpBE = new CEXP_FILESBE();

            CPARAMETROBE parametroBE = new CPARAMETROBE();
            CPARAMETROD parametroD = new CPARAMETROD();
            CCAJAD cajaD = new CCAJAD();
            CCAJABE cajaBE = new CCAJABE();

            ExportarDBF exportDbf = new ExportarDBF();
            //ArrayList resultadosExportacion = new ArrayList();


            System.Collections.ArrayList parts = new ArrayList();
            FbParameter auxPar;

            auxPar = new FbParameter("@FOLIO", FbDbType.Integer);
            auxPar.Value = folio;
            parts.Add(auxPar);

            FbParameter[] arParms = new FbParameter[parts.Count];
            parts.CopyTo(arParms, 0);


            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;
            bool bArchivoGenerado = false, bArchivoSubido = false;
            string localPath, ftpPath;
            string claveSucDest = "";



            //fase 1 agregar los registros en exp_files que se necesitan exportar
            bRes = filesExpD.UPD_EXP_FILES_PEDIDODEVO(folio, null);


            //get data for the generation of the dbfs
            parametroBE = parametroD.seleccionarPARAMETROActual(null);
            if (parametroBE == null)
            {
                m_Exporting = false;
                m_UltimoExporting = "";
                return false;
            }
            if (parametroBE.ISUCURSALNUMERO == "")
            {
                m_Exporting = false;
                m_UltimoExporting = "";
                return false;
            }

            cajaBE.IID = iPos.CurrentUserID.CurrentCompania.IEM_CAJA;
            cajaBE = cajaD.seleccionarCAJA(cajaBE, null);
            if (cajaBE == null)
            {
                m_Exporting = false;
                m_UltimoExporting = "";
                return false;
            }


            //recorre la fila de archivos a exportar
            try
            {


                String CmdTxt = @"select * from EXP_FILES where ESTATUS = 'A' and TIPO in ( 'PD')  and DOCTOFOLIO = @FOLIO";
                parts.CopyTo(arParms, 0);


                dr = SqlHelper.ExecuteReader(ConexionesBD.ConexionBD.ConexionString(), CommandType.Text, CmdTxt, out pcn, arParms);


                while (dr.Read())
                {
                    filesExpBE = filesExpD.GET_EXP_FILE_FROM_DR(dr);
                    bArchivoGenerado = false;

                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_PEDIDODEVO)
                    {

                        if (!exportDbf.ExportPedidosDevoEnvios(parametroBE, cajaBE, filesExpBE.IFECHA, filesExpBE.IDOCTOFOLIO, parametroBE.ISUCURSALNUMERO)
                            )
                            resultadosExportacion.Add("Error " + exportDbf.IComentario);
                        else
                            bArchivoGenerado = true;
                    }




                    if (bArchivoGenerado)
                    {
                        filesExpBE.IESTATUS = DBValues._EXP_FILES_ESTATUS_GENERADO;
                        if (!filesExpD.CambiarEXP_FILESD(filesExpBE, filesExpBE, null))
                        {
                            resultadosExportacion.Add("Error " + filesExpD.IComentario);
                            bRetorno = false;
                        }
                        resultadosExportacion.Add("Archivo " + filesExpBE.IARCHIVOFTP + " generado");

                    }
                    else
                    {

                        resultadosExportacion.Add("Archivo " + filesExpBE.IARCHIVOFTP + " NO pudo ser generado");
                        bRetorno = false;
                    }



                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                m_Exporting = false;
                m_UltimoExporting = "";
                return false;
            }

            //recorre la lista de archivos a exportar para enviarlos al FTP
            try
            {


                String CmdTxt = @"select * from EXP_FILES where ESTATUS = 'G' and TIPO in ( 'PD')  and DOCTOFOLIO = @FOLIO";
                dr = SqlHelper.ExecuteReader(ConexionesBD.ConexionBD.ConexionString(), CommandType.Text, CmdTxt, out pcn, arParms);


                while (dr.Read())
                {

                    filesExpBE = filesExpD.GET_EXP_FILE_FROM_DR(dr);
                    bArchivoSubido = false;

                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_PEDIDODEVO)
                    {

                        claveSucDest = ObtenerClaveSucursalDestino(filesExpBE.IDOCTOFOLIO, DBValues._DOCTO_TIPO_COMPRA);
                        localPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_PedidosDevoEnvios + '/' + claveSucDest + '/';

                        bArchivoSubido = true;

                        /*ftpPath = ExportarDBF.FileFTPLocation_Traslados + "/" + claveSucDest + "/";
                        if (!UploadFile(filesExpBE.INOMBRE, localPath, ftpPath, false, false, ref resultadosExportacion))
                            bArchivoSubido = false;*/

                        ftpPath = "/" + claveSucDest + ExportarDBF.FileFTPLocation_PedidosDevo + "/";
                        if (!UploadFile(filesExpBE.INOMBRE, localPath, ftpPath, false, true, ref resultadosExportacion))
                        {
                            resultadosExportacion.Add("El archivo no pudo ser enviado a internet, se intentara enviar automaticamente cuando se reestablezca el internet");
                            bArchivoSubido = false;
                            bRetorno = false;
                        }
                    }






                    if (bArchivoSubido)
                    {
                        filesExpBE.IESTATUS = DBValues._EXP_FILES_ESTADOS_ENVIADO;
                        if (!filesExpD.CambiarEXP_FILESD(filesExpBE, filesExpBE, null))
                        {
                            resultadosExportacion.Add("Error " + filesExpD.IComentario);
                        }
                        resultadosExportacion.Add("Archivo " + filesExpBE.IARCHIVOFTP + " enviado");


                        if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_PEDIDODEVO)
                        {

                            CDOCTOD doctoD = new CDOCTOD();
                            CDOCTOBE doctoBE = new CDOCTOBE();
                            doctoBE.IID = filesExpBE.IDOCTOID;
                            doctoBE.ITRANREGSERVER = DBValues._DB_BOOLVALUE_NO;
                            doctoD.CambiarTranRegServerDOCTOD(doctoBE, null);

                            HiloExistencias._IFLAGENVIARREGISTROTRASLAEVENTOS++;
                        }
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                m_Exporting = false;
                m_UltimoExporting = "";
                return false;
            }


            m_Exporting = false;
            m_UltimoExporting = "";
            Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
            return bRetorno;
        }





        public bool EnviarArchivosAFtpDeMatrizPedidos(ref  ArrayList resultadosExportacion, int folio,FbTransaction st)
        {
            bool bRetorno = true, bRes = true;

            if (m_Exporting)
            {
                resultadosExportacion.Add("Hay otro proceso de exportacion ejecutandose " + m_UltimoExporting);
                return false;
            }
            m_Exporting = true;
            m_UltimoExporting = "4- EnviarArchivosAFtpDeMatrizPedidos";


            CEXP_FILESD filesExpD = new CEXP_FILESD();
            CEXP_FILESBE filesExpBE = new CEXP_FILESBE();

            CPARAMETROBE parametroBE = new CPARAMETROBE();
            CPARAMETROD parametroD = new CPARAMETROD();
            CCAJAD cajaD = new CCAJAD();
            CCAJABE cajaBE = new CCAJABE();

            ExportarDBF exportDbf = new ExportarDBF();
            //ArrayList resultadosExportacion = new ArrayList();


            System.Collections.ArrayList parts = new ArrayList();
            FbParameter auxPar;

            auxPar = new FbParameter("@FOLIO", FbDbType.Integer);
            auxPar.Value = folio;
            parts.Add(auxPar);

            FbParameter[] arParms = new FbParameter[parts.Count];
            parts.CopyTo(arParms, 0);


            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            //bool bArchivoGenerado = false;
            bool bArchivoSubido = false;
            string localPath, ftpPath;
            string claveSucDest = "";



            //fase 1 agregar los registros en exp_files que se necesitan exportar
            bRes = filesExpD.UPD_EXP_FILES_MATRIZPEDIDOS(folio, st);


            //get data for the generation of the dbfs
            parametroBE = parametroD.seleccionarPARAMETROActual(null);
            if (parametroBE == null)
            {
                m_Exporting = false;
                m_UltimoExporting = "";
                return false;
            }
            if (parametroBE.ISUCURSALNUMERO == "")
            {
                m_Exporting = false;
                m_UltimoExporting = "";
                return false;
            }

            cajaBE.IID = iPos.CurrentUserID.CurrentCompania.IEM_CAJA;
            cajaBE = cajaD.seleccionarCAJA(cajaBE, null);
            if (cajaBE == null)
            {
                m_Exporting = false;
                m_UltimoExporting = "";
                return false;
            }


         

            //recorre la lista de archivos a exportar para enviarlos al FTP
            try
            {


                String CmdTxt = @"select * from EXP_FILES where ESTATUS = 'G' and TIPO in ('Z','Y')  and DOCTOFOLIO = @FOLIO";
                dr = SqlHelper.ExecuteReader(ConexionesBD.ConexionBD.ConexionString(), CommandType.Text, CmdTxt, out pcn, arParms);


                while (dr.Read())
                {

                    filesExpBE = filesExpD.GET_EXP_FILE_FROM_DR(dr);
                    bArchivoSubido = false;
                    claveSucDest = ObtenerClaveSucursalDestino(filesExpBE.IDOCTOFOLIO, DBValues._DOCTO_TIPO_PEDIDO_TRASPASO_SALIDA);


                    if (filesExpBE.ITIPO.Equals(DBValues._EXP_FILES_TIPO_MATRIZPEDIDO))
                    {

                         localPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_MatrizEnviosSucursales + claveSucDest + '\\';

                        bArchivoSubido = true;

                        /*ftpPath = ExportarDBF.FileFTPLocation_Traslados + "/" + claveSucDest + "/";
                        if (!UploadFile(filesExpBE.INOMBRE, localPath, ftpPath, false, false, ref resultadosExportacion))
                            bArchivoSubido = false;*/

                        ftpPath = "/" + claveSucDest + ExportarDBF.FileFTPLocation_MatrizEnvioPedidos + "/";
                        if (!UploadFile(filesExpBE.INOMBRE, localPath, ftpPath, false, true, ref resultadosExportacion))
                        {
                            resultadosExportacion.Add("El archivo no pudo ser enviado a internet, se intentara enviar automaticamente cuando se reestablezca el internet");
                            bArchivoSubido = false;
                            bRetorno = false;
                        }
                    }
                    else if (filesExpBE.ITIPO.Equals(DBValues._EXP_FILES_TIPO_MATRIZPEDIDOAUX) && parametroBE.IEXPORTCATALOGOAUX.Equals("S"))
                    {
                        localPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_MatrizEnviosSucursalesAux + claveSucDest + '\\';


                        if (File.Exists(localPath + filesExpBE.INOMBRE))
                        {
                            bArchivoSubido = true;
                            ftpPath = "/" + claveSucDest + ExportarDBF.FileFTPLocation_MatrizEnvioPedidosAux + "/";
                            if (!UploadFile(filesExpBE.INOMBRE, localPath, ftpPath, false, true, ref resultadosExportacion))
                            {
                                resultadosExportacion.Add("El archivo no pudo ser enviado a internet, se intentara enviar automaticamente cuando se reestablezca el internet");
                                bArchivoSubido = false;
                                bRetorno = false;
                            }
                            else
                            {
                                if (File.Exists(localPath + filesExpBE.INOMBRE))
                                    File.Delete(localPath + filesExpBE.INOMBRE);
                            }
                        }
                    }





                    if (bArchivoSubido)
                    {
                        filesExpBE.IESTATUS = DBValues._EXP_FILES_ESTADOS_ENVIADO;
                        if (!filesExpD.CambiarEXP_FILESD(filesExpBE, filesExpBE, null))
                        {
                            resultadosExportacion.Add("Error " + filesExpD.IComentario);
                        }
                        resultadosExportacion.Add("Archivo " + filesExpBE.IARCHIVOFTP + " enviado");


                       /* if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_TRASLADO)
                        {

                            CDOCTOD doctoD = new CDOCTOD();
                            CDOCTOBE doctoBE = new CDOCTOBE();
                            doctoBE.IID = filesExpBE.IDOCTOID;
                            doctoBE.ITRANREGSERVER = DBValues._DB_BOOLVALUE_NO;
                            doctoD.CambiarTranRegServerDOCTOD(doctoBE, null);

                            HiloExistencias._IFLAGENVIARREGISTROTRASLAEVENTOS++;
                        }*/
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                m_Exporting = false;
                m_UltimoExporting = "";
                return false;
            }


            m_Exporting = false;
            m_UltimoExporting = "";
            Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
            return bRetorno;
        }




        public bool EnvirArchivosAFtpDePedidos(ref  ArrayList resultadosExportacion, DateTime dateFrom, DateTime dateTo, long lPedido)
        {
            bool bRetorno = true, bRes = true;

            if (m_Exporting)
            {
                resultadosExportacion.Add("Hay otro proceso de exportacion ejecutandose " + m_UltimoExporting);
                return false;
            }
            m_Exporting = true;
            m_UltimoExporting = "5- EnviarArchivosAFtpDePedidos";


            CEXP_FILESD filesExpD = new CEXP_FILESD();
            CEXP_FILESBE filesExpBE = new CEXP_FILESBE();

            CPARAMETROBE parametroBE = new CPARAMETROBE();
            CPARAMETROD parametroD = new CPARAMETROD();
            CCAJAD cajaD = new CCAJAD();
            CCAJABE cajaBE = new CCAJABE();

            ExportarDBF exportDbf = new ExportarDBF();

            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            bool bArchivoGenerado, bArchivoSubido;
            string localPath, ftpPath;
            //string claveSucDest = "";

            long exp_filesId = 0;

            System.Collections.ArrayList parts = new ArrayList();
            FbParameter[] arParms;
            FbParameter auxPar;



         
            //get data for the generation of the dbfs
            parametroBE = parametroD.seleccionarPARAMETROActual(null);
            if (parametroBE == null)
            {
                m_Exporting = false;
                m_UltimoExporting = "";
                return false;
            }
            if (parametroBE.ISUCURSALNUMERO == "")
            {
                m_Exporting = false;
                m_UltimoExporting = "";
                return false;
            }

            cajaBE.IID = iPos.CurrentUserID.CurrentCompania.IEM_CAJA;
            cajaBE = cajaD.seleccionarCAJA(cajaBE, null);
            if (cajaBE == null)
            {
                m_Exporting = false;
                m_UltimoExporting = "";
                return false;
            }



            //fase 1 agregar los registros en exp_files que se necesitan exportar

            parts = new ArrayList();

            auxPar = new FbParameter("@FECHAFROM", FbDbType.Date);
            auxPar.Value = dateFrom;
            parts.Add(auxPar);


            auxPar = new FbParameter("@FECHATO", FbDbType.Date);
            auxPar.Value = dateFrom;/*dateto*/
            parts.Add(auxPar);

            arParms = new FbParameter[parts.Count];
            parts.CopyTo(arParms, 0);


            bRes = filesExpD.UPD_EXP_FILES_PED(dateFrom, dateTo, ref exp_filesId, lPedido, null);



            //recorre la fila de archivos a exportar
            try
            {

                parts = new ArrayList();

                auxPar = new FbParameter("@EXP_FILESID", FbDbType.BigInt);
                auxPar.Value = exp_filesId;
                parts.Add(auxPar);

                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                String CmdTxt = @"select * from EXP_FILES where ESTATUS = 'A' and TIPO = 'P'  and id = @EXP_FILESID";


                dr = SqlHelper.ExecuteReader(ConexionesBD.ConexionBD.ConexionString(), CommandType.Text, CmdTxt, out pcn, arParms);


                if (dr.Read())
                {
                    filesExpBE = filesExpD.GET_EXP_FILE_FROM_DR(dr);
                    bArchivoGenerado = false;
                    string bufferFileName = "";

                    if (!exportDbf.ExportPedidos(parametroBE, cajaBE, filesExpBE.IFECHA, filesExpBE.IFECHATO, false, ref lPedido, ref bufferFileName, ref filesExpBE))
                    {
                        resultadosExportacion.Add("Error " + exportDbf.IComentario);
                    }
                    else
                    {
                        bArchivoGenerado = true;

                        filesExpBE.INOMBRE = bufferFileName + ".dbf";
                        filesExpBE.IARCHIVOFTP = bufferFileName + ".dbf";
                        
                    }


                    if (bArchivoGenerado || lPedido>0)
                    {
                        if(bArchivoGenerado)
                            filesExpBE.IESTATUS = DBValues._EXP_FILES_ESTATUS_GENERADO;
                        else
                            filesExpBE.IESTATUS = DBValues._EXP_FILES_ESTADOS_ENVIADO;


                        if (!filesExpD.CambiarEXP_FILESD(filesExpBE, filesExpBE, null))
                        {
                            resultadosExportacion.Add("Error " + filesExpD.IComentario);
                        }
                        if (bArchivoGenerado) // si se genero
                        {
                            resultadosExportacion.Add("Archivo " + filesExpBE.IARCHIVOFTP + " generado");
                        }
                    }



                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                m_Exporting = false;
                m_UltimoExporting = "";
                return false;
            }




            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE doctoBE = new CDOCTOBE();



            //recorre la lista de archivos a exportar para enviarlos al FTP
            try
            {


                String CmdTxt = @"select * from EXP_FILES where ESTATUS = 'G' and TIPO = 'P'  and id = @EXP_FILESID";// and (turnoid = @TURNOIDFROM))";
                dr = SqlHelper.ExecuteReader(ConexionesBD.ConexionBD.ConexionString(), CommandType.Text, CmdTxt, out pcn, arParms);


                if (dr.Read())
                {
                    filesExpBE = filesExpD.GET_EXP_FILE_FROM_DR(dr);
                    bArchivoSubido = false;


                    bool bEnFolderSucursal = true;
                    
                    
                    doctoBE = new CDOCTOBE();
                    doctoBE.IID = filesExpBE.IDOCTOID;

                    doctoBE = doctoD.seleccionarDOCTO(doctoBE, null);

                    if (doctoBE == null)
                    {
                        this.iComentario = "no se encontro el registro";
                        return false;
                    }

                    if (doctoBE.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_SOLICITUDMERCANCIA)
                    {

                        string claveSucDest  = "";

                        claveSucDest = ObtenerClaveSucursalDestinoXId(doctoBE.ISUCURSALTID);
                        localPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_SolicitudMercancia + '/' + claveSucDest + '/';

                        ftpPath = "/" + claveSucDest + ExportarDBF.FileFTPLocation_SolicitudMercancia + "/";
                        bEnFolderSucursal = false;
                    }
                    else
                    {

                        localPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_Pedidos;
                        ftpPath = ExportarDBF.FileFTPLocation_Pedidos + "\\";
                        bEnFolderSucursal = true;
                    }


                    //localPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_Pedidos;
                    //ftpPath = ExportarDBF.FileFTPLocation_Pedidos + "\\";

                    if (UploadFile(filesExpBE.INOMBRE, localPath, ftpPath, bEnFolderSucursal, true, ref resultadosExportacion))
                        bArchivoSubido = true;
                        //if (UploadFile(filesExpBE.INOMBRE.Replace(ExportarDBF.FileNamePedidosDetalleFTP, ExportarDBF.FileNamePedidosHeaderFTP), localPath, ftpPath, true, true, ref resultadosExportacion))
                            





                    if (bArchivoSubido)
                    {
                        filesExpBE.IESTATUS = DBValues._EXP_FILES_ESTADOS_ENVIADO;
                        if (!filesExpD.CambiarEXP_FILESD(filesExpBE, filesExpBE, null))
                        {
                            resultadosExportacion.Add("Error " + filesExpD.IComentario);
                        }
                        resultadosExportacion.Add("Archivo " + filesExpBE.IARCHIVOFTP + " enviado");

                        if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_PEDIDO)
                        {
                            doctoBE = new CDOCTOBE();
                            doctoBE.IID = filesExpBE.IDOCTOID;
                            doctoBE.ITRASLADOAFTP = DBValues._DB_BOOLVALUE_SI;
                            doctoD.CambiarEnviadoFTPDOCTOD(doctoBE, null);
                        }


                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                m_Exporting = false;
                return false;
            }


            m_Exporting = false;
            m_UltimoExporting = "";
            m_UltimoExporting = "";
            Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
            return bRetorno;
        }




        public bool ProcesoPedido(ref  ArrayList resultadosExportacion, DateTime dateFrom, DateTime dateTo, long lPedido, bool bIncluirApartado, long subTipoDoctoId, long exp_fileid)
        {
            //parametroBE.IID_DOSLETRAS
            string dbFileNameDetalle = "";
            CEXP_FILESBE expFilesBE = new CEXP_FILESBE();

            ExportarDBF exportarDBF = new ExportarDBF();
            bool bRes = true;
            if (lPedido == 0)
            {
                bRes = exportarDBF.PedidoGenerar(CurrentUserID.CurrentParameters.ISUCURSALID, CurrentUserID.CurrentUser.IID, dateFrom, dateTo, true, null, ref lPedido, bIncluirApartado, subTipoDoctoId, false,0 );
                if (!bRes)
                {
                    if (exportarDBF.IComentario.StartsWith("Observacion: No hay registros a procesar para el dia"))
                    {
                        if (MessageBox.Show("No hay registros para procesar . Quiere de todas maneras generar el registro?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            bRes = exportarDBF.PedidoGenerar(CurrentUserID.CurrentParameters.ISUCURSALID, CurrentUserID.CurrentUser.IID, dateFrom, dateTo, true, null, ref lPedido, bIncluirApartado, subTipoDoctoId, true,0);
                        }
                    }
                    

                    if(!bRes)
                    {
                        this.iComentario = exportarDBF.IComentario;
                        resultadosExportacion.Add(exportarDBF.IComentario);
                        return false;
                    }
                }
            }

            bRes = exportarDBF.PedidoEditarPorUsuario(lPedido);
            if (!bRes)
            {
                this.iComentario = exportarDBF.IComentario;
                resultadosExportacion.Add(exportarDBF.IComentario);
                return false;
            }

            bRes = exportarDBF.PedidoCrearDBF(CurrentUserID.CurrentParameters.IID_DOSLETRAS,null,lPedido, ref dbFileNameDetalle) ;
            if (!bRes)
            {
                this.iComentario = exportarDBF.IComentario;
                resultadosExportacion.Add(exportarDBF.IComentario);
                return false;
            }


            bRes = exportarDBF.PedidoAgregarEnListaExpo(dbFileNameDetalle, lPedido, ref expFilesBE, dateFrom, dateTo, exp_fileid);
            if (!bRes)
            {
                this.iComentario = exportarDBF.IComentario;
                resultadosExportacion.Add(exportarDBF.IComentario);
                return false;
            }


            bRes = exportarDBF.PedidoEnviarAFtp(expFilesBE,ref resultadosExportacion);
            if (!bRes)
            {
                this.iComentario = exportarDBF.IComentario;
                return false;
            }



            return true;
        }




        public bool EnvirDesdeDBFAFtpDePedidos(ref  ArrayList resultadosExportacion, DateTime date, long lReenviarPedidoExistente)
        {
            bool bRetorno = true, bRes = true;

            if (m_Exporting)
            {
                resultadosExportacion.Add("Hay otro proceso de exportacion ejecutandose " + m_UltimoExporting);
                return false;
            }
            m_Exporting = true;
            m_UltimoExporting = "6- Enviardesdedbfaftpdepedidos";


            CEXP_FILESD filesExpD = new CEXP_FILESD();
            CEXP_FILESBE filesExpBE = new CEXP_FILESBE();

            CPARAMETROBE parametroBE = new CPARAMETROBE();
            CPARAMETROD parametroD = new CPARAMETROD();
            CCAJAD cajaD = new CCAJAD();
            CCAJABE cajaBE = new CCAJABE();

            ExportarDBF exportDbf = new ExportarDBF();

            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            bool bArchivoGenerado, bArchivoSubido;
            string localPath, ftpPath;
            //string claveSucDest = "";

            long exp_filesId = 0;


            //get data for the generation of the dbfs
            parametroBE = parametroD.seleccionarPARAMETROActual(null);
            if (parametroBE == null)
            {
                m_Exporting = false;
                m_UltimoExporting = "";
                return false;
            }
            if (parametroBE.ISUCURSALNUMERO == "")
            {
                m_Exporting = false;
                m_UltimoExporting = "";
                return false;
            }

            cajaBE.IID = iPos.CurrentUserID.CurrentCompania.IEM_CAJA;
            cajaBE = cajaD.seleccionarCAJA(cajaBE, null);
            if (cajaBE == null)
            {
                m_Exporting = false;
                m_UltimoExporting = "";
                return false;
            }


            //fase 1 agregar los registros en exp_files que se necesitan exportar

            System.Collections.ArrayList parts = new ArrayList();
            FbParameter auxPar;

            auxPar = new FbParameter("@FECHAFROM", FbDbType.Date);
            auxPar.Value = date;
            parts.Add(auxPar);

            /*auxPar = new FbParameter("@TURNOIDFROM", FbDbType.BigInt);
            auxPar.Value = turnoIdFrom;
            parts.Add(auxPar);*/

            auxPar = new FbParameter("@FECHATO", FbDbType.Date);
            auxPar.Value = date;
            parts.Add(auxPar);

            FbParameter[] arParms = new FbParameter[parts.Count];
            parts.CopyTo(arParms, 0);


            bRes = filesExpD.UPD_EXP_FILES_PED(date, date, ref exp_filesId,0, null);



            //recorre la fila de archivos a exportar
            try
            {


                String CmdTxt = @"select * from EXP_FILES where ESTATUS = 'A' and TIPO = 'P'  and
                                                                ((fecha <= @FECHATO) and (fecha >= @FECHAFROM ))";// and (turnoid = @TURNOIDFROM))";
                parts.CopyTo(arParms, 0);


                dr = SqlHelper.ExecuteReader(ConexionesBD.ConexionBD.ConexionString(), CommandType.Text, CmdTxt, out pcn, arParms);


                while (dr.Read())
                {
                    filesExpBE = filesExpD.GET_EXP_FILE_FROM_DR(dr);
                    bArchivoGenerado = false;

                    if (!exportDbf.ExportPedidosDesdeDBF(parametroBE, cajaBE, filesExpBE.IFECHA, false, lReenviarPedidoExistente))
                        resultadosExportacion.Add("Error " + exportDbf.IComentario);
                    else
                        bArchivoGenerado = true;

                    /*if (!exportDbf.CopyFromDBFCrescendoTablesComprasYDevoluciones(filesExpBE.IFECHA))
                        resultadosExportacion.Add("Error " + exportDbf.IComentario);
                    else
                        bArchivoGenerado = true;*/


                    if (bArchivoGenerado || lReenviarPedidoExistente > 0)
                    {
                        if (bArchivoGenerado)
                            filesExpBE.IESTATUS = DBValues._EXP_FILES_ESTATUS_GENERADO;
                        else
                            filesExpBE.IESTATUS = DBValues._EXP_FILES_ESTADOS_ENVIADO;


                        if (!filesExpD.CambiarEXP_FILESD(filesExpBE, filesExpBE, null))
                        {
                            resultadosExportacion.Add("Error " + filesExpD.IComentario);
                        }
                        if (bArchivoGenerado) // si se genero
                        {
                            resultadosExportacion.Add("Archivo " + filesExpBE.IARCHIVOFTP + " generado");
                        }
                    }



                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                m_Exporting = false;
                m_UltimoExporting = "";
                return false;
            }







            //recorre la lista de archivos a exportar para enviarlos al FTP
            try
            {


                String CmdTxt = @"select * from EXP_FILES where ESTATUS = 'G' and TIPO = 'P' and
                                                                ((fecha <= @FECHATO) and (fecha >= @FECHAFROM ))";// and (turnoid = @TURNOIDFROM))";
                dr = SqlHelper.ExecuteReader(ConexionesBD.ConexionBD.ConexionString(), CommandType.Text, CmdTxt, out pcn, arParms);


                while (dr.Read())
                {
                    filesExpBE = filesExpD.GET_EXP_FILE_FROM_DR(dr);
                    bArchivoSubido = false;


                    CDOCTOD doctoD = new CDOCTOD();
                    CDOCTOBE doctoBE = new CDOCTOBE();
                    bool bEnFolderSucursal = true;


                    doctoBE = new CDOCTOBE();
                    doctoBE.IID = filesExpBE.IDOCTOID;

                    doctoBE = doctoD.seleccionarDOCTO(doctoBE, null);

                    if (doctoBE == null)
                    {
                        resultadosExportacion.Add("no se pudo encontrar el registro ");
                        continue;
                    }

                    if (doctoBE.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_SOLICITUDMERCANCIA)
                    {

                        string claveSucDest = "";
                        claveSucDest = ObtenerClaveSucursalDestinoXId(doctoBE.ISUCURSALTID);
                        localPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_SolicitudMercancia + '/' + claveSucDest + '/';

                        ftpPath = "/" + claveSucDest + ExportarDBF.FileFTPLocation_SolicitudMercancia + "/";
                        bEnFolderSucursal = false;
                    }
                    else
                    {

                        localPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_Pedidos;
                        ftpPath = ExportarDBF.FileFTPLocation_Pedidos + "\\";
                        bEnFolderSucursal = true;
                    }

                    //localPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_Pedidos;
                    //ftpPath = ExportarDBF.FileFTPLocation_Pedidos + "\\";

                    if (UploadFile(filesExpBE.INOMBRE, localPath, ftpPath, bEnFolderSucursal, true, ref resultadosExportacion))
                        if (UploadFile(filesExpBE.INOMBRE.Replace(ExportarDBF.FileNamePedidosDetalleFTP, ExportarDBF.FileNamePedidosHeaderFTP), localPath, ftpPath, true, true, ref resultadosExportacion))
                            bArchivoSubido = true;





                    if (bArchivoSubido)
                    {
                        filesExpBE.IESTATUS = DBValues._EXP_FILES_ESTADOS_ENVIADO;
                        if (!filesExpD.CambiarEXP_FILESD(filesExpBE, filesExpBE, null))
                        {
                            resultadosExportacion.Add("Error " + filesExpD.IComentario);
                        }
                        resultadosExportacion.Add("Archivo " + filesExpBE.IARCHIVOFTP + " enviado");
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                m_Exporting = false;
                m_UltimoExporting = "";
                return false;
            }


            m_Exporting = false;
            m_UltimoExporting = "";

            return bRetorno;
        }




        public bool EnvirArchivosYaGeneradosAFtp(ref  ArrayList resultadosExportacion)
        {
            bool bRetorno = true;
            //bool bRes = true;

            resultadosExportacion.Clear();

            if (m_Exporting)
            {
                resultadosExportacion.Add("Hay otro proceso de exportacion ejecutandose " + m_UltimoExporting);
                return false;
            }
            m_Exporting = true;
            m_UltimoExporting = "7- EnviarArchivosYageneradosAftp";


            CEXP_FILESD filesExpD = new CEXP_FILESD();
            CEXP_FILESBE filesExpBE = new CEXP_FILESBE();

            CPARAMETROBE parametroBE = new CPARAMETROBE();
            CPARAMETROD parametroD = new CPARAMETROD();
            CCAJAD cajaD = new CCAJAD();
            CCAJABE cajaBE = new CCAJABE();

            ExportarDBF exportDbf = new ExportarDBF();
            //ArrayList resultadosExportacion = new ArrayList();


            System.Collections.ArrayList parts = new ArrayList();
            //FbParameter auxPar;
            FbParameter[] arParms = new FbParameter[parts.Count];
            /**/FbDataReader dr = null;
            FbConnection pcn = null;


            bool  bArchivoSubido;
            string localPath, ftpPath;
            string claveSucDest = "";



            //int iCount = 0;
            //int iMaxCount = 10;

            //recorre la lista de archivos a exportar para enviarlos al FTP
            try
            {

                m_UltimoExporting = "7- EnviarArchivosYageneradosAftp A";

                String CmdTxt = @"select * from EXP_FILES where ESTATUS = 'G'  AND TIPO NOT IN ('M','L')  ";
                dr = SqlHelper.ExecuteReader(ConexionesBD.ConexionBD.ConexionString(), CommandType.Text, CmdTxt, out pcn, arParms);


                m_UltimoExporting = "7- EnviarArchivosYageneradosAftp B";

                while (dr.Read())
                {
                    //if (iCount > iMaxCount)
                    //    break;



                    m_UltimoExporting = "7- EnviarArchivosYageneradosAftp C";

                    filesExpBE = filesExpD.GET_EXP_FILE_FROM_DR(dr);
                    bArchivoSubido = false;



                    m_UltimoExporting = "7- EnviarArchivosYageneradosAftp D";

                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_VENTA)
                    {
                        localPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_Ventas + "\\" + filesExpBE.IFECHA.Month.ToString();
                        ftpPath = ExportarDBF.FileFTPLocation_Ventas + "/" + filesExpBE.IFECHA.Month.ToString() + "/";


                        m_UltimoExporting = "7- EnviarArchivosYageneradosAftp Local " + localPath + " Ftp " + ftpPath;

                        if (UploadFile(filesExpBE.INOMBRE, localPath, ftpPath, true, true, ref resultadosExportacion))
                            if (UploadFile(filesExpBE.INOMBRE.Replace(ExportarDBF.FileNameVentasDetalleFTP, ExportarDBF.FileNameVentasHeaderFTP), localPath, ftpPath, true, true, ref resultadosExportacion))
                                bArchivoSubido = true;

                    }


                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_PEDIDO)
                    {


                        CDOCTOD doctoD = new CDOCTOD();
                        CDOCTOBE doctoBE = new CDOCTOBE();
                        bool bEnFolderSucursal = true;


                        doctoBE = new CDOCTOBE();
                        doctoBE.IID = filesExpBE.IDOCTOID;

                        doctoBE = doctoD.seleccionarDOCTO(doctoBE, null);

                        if (doctoBE == null)
                        {
                            resultadosExportacion.Add("no se pudo encontrar el registro ");
                            continue;
                        }

                        if (doctoBE.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_SOLICITUDMERCANCIA)
                        {
                            
                            claveSucDest = ObtenerClaveSucursalDestino(filesExpBE.IDOCTOFOLIO, DBValues._DOCTO_TIPO_PEDIDO_COMPRA);
                            localPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_SolicitudMercancia + '/' + claveSucDest + '/';

                            ftpPath = "/" + claveSucDest + ExportarDBF.FileFTPLocation_SolicitudMercancia + "/";
                            bEnFolderSucursal = false;
                        }
                        else
                        {

                            localPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_Pedidos;
                            ftpPath = ExportarDBF.FileFTPLocation_Pedidos + "\\";
                            bEnFolderSucursal = true;
                        }

                        //localPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_Pedidos;
                        //ftpPath = ExportarDBF.FileFTPLocation_Pedidos + "\\";

                        m_UltimoExporting = "7- EnviarArchivosYageneradosAftp Local " + localPath + " Ftp " + ftpPath;

                        if (UploadFile(filesExpBE.INOMBRE, localPath, ftpPath, bEnFolderSucursal, true, ref resultadosExportacion))
                            //if (UploadFile(filesExpBE.INOMBRE.Replace(ExportarDBF.FileNamePedidosDetalleFTP, ExportarDBF.FileNamePedidosHeaderFTP), localPath, ftpPath, true, true, ref resultadosExportacion))
                                bArchivoSubido = true;
                    }


                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_TRASLADO)
                    {
                        claveSucDest = ObtenerClaveSucursalDestino(filesExpBE.IDOCTOFOLIO, DBValues._DOCTO_TIPO_TRASPASO_ENVIO);
                        localPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_TrasladosEnvios + '/' + claveSucDest + '/';
                        
                        bArchivoSubido = true;

                        ftpPath = "/" + claveSucDest + ExportarDBF.FileFTPLocation_Traslados + "/";
                        m_UltimoExporting = "7- EnviarArchivosYageneradosAftp Local " + localPath + " Ftp " + ftpPath;

                        if (!UploadFile(filesExpBE.INOMBRE, localPath, ftpPath, false, true, ref resultadosExportacion))
                            bArchivoSubido = false;

                    }


                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_TRASLADODEVO)
                    {
                        claveSucDest = ObtenerClaveSucursalDestino(filesExpBE.IDOCTOFOLIO, DBValues._DOCTO_TIPO_TRASPASO_REC);
                        localPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_TrasladosDevoEnvios + '/' + claveSucDest + '/';

                        bArchivoSubido = true;


                        ftpPath = "/" + claveSucDest + ExportarDBF.FileFTPLocation_TrasladosDevo + "/";
                        m_UltimoExporting = "7- EnviarArchivosYageneradosAftp Local " + localPath + " Ftp " + ftpPath;


                        if (!UploadFile(filesExpBE.INOMBRE, localPath, ftpPath, false, true, ref resultadosExportacion))
                            bArchivoSubido = false;

                    }


                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_RECEPCIONCOMPRA)
                    {
                        localPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_RecepcionCompras;
                        ftpPath = ExportarDBF.FileFTPLocation_RecepcionCompras + "/";

                        m_UltimoExporting = "7- EnviarArchivosYageneradosAftp Local " + localPath + " Ftp " + ftpPath;

                        if (UploadFile(filesExpBE.INOMBRE, localPath, ftpPath, true, true, ref resultadosExportacion))
                            bArchivoSubido = true;

                    }


                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_PEDIDODEVO)
                    {
                        claveSucDest = ObtenerClaveSucursalDestino(filesExpBE.IDOCTOFOLIO, DBValues._DOCTO_TIPO_COMPRA);
                        localPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_PedidosDevoEnvios + '/' + claveSucDest + '/';

                        bArchivoSubido = true;


                        ftpPath = "/" + claveSucDest + ExportarDBF.FileFTPLocation_PedidosDevo + "/";
                        m_UltimoExporting = "7- EnviarArchivosYageneradosAftp Local " + localPath + " Ftp " + ftpPath;

                        if (!UploadFile(filesExpBE.INOMBRE, localPath, ftpPath, false, true, ref resultadosExportacion))
                            bArchivoSubido = false;

                    }


                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_INVENTARIO)
                    {
                        localPath = System.AppDomain.CurrentDomain.BaseDirectory + EnviosMail.FileLocalLocation_Excel;
                        ftpPath = ExportarDBF.FileFTPLocation_Inventarios + "/";
                        m_UltimoExporting = "7- EnviarArchivosYageneradosAftp Local " + localPath + " Ftp " + ftpPath;

                        if (UploadFile(filesExpBE.INOMBRE, localPath, ftpPath, true, false, ref resultadosExportacion))
                            bArchivoSubido = true;

                    }


                    


                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_MATRIZPEDIDO)
                    {
                        claveSucDest = ObtenerClaveSucursalDestino(filesExpBE.IDOCTOFOLIO, DBValues._DOCTO_TIPO_PEDIDO_TRASPASO_SALIDA);
                        localPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_MatrizEnviosSucursales + claveSucDest + '\\';

                        bArchivoSubido = true;

                        ftpPath = "/" + claveSucDest + ExportarDBF.FileFTPLocation_MatrizEnvioPedidos + "/";

                        m_UltimoExporting = "7- EnviarArchivosYageneradosAftp Local " + localPath + " Ftp " + ftpPath;

                        if (!UploadFile(filesExpBE.INOMBRE, localPath, ftpPath, false, true, ref resultadosExportacion))
                            bArchivoSubido = false;

                    }


                    
                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_FACTURAELECTRONICA_PDF)
                    {
                        localPath =  iPosReporting.WFFacturaElectronica.getFileLocalLocation_FE_PDF(DBValues._DOCTO_TIPO_VENTA,CurrentUserID.CurrentParameters) + "\\";
                        ftpPath = ExportarDBF.FileFTPLocation_FacturaElectronicaPDF + "/";

                        m_UltimoExporting = "7- EnviarArchivosYageneradosAftp Local " + localPath + " Ftp " + ftpPath;


                        if (UploadFile(filesExpBE.INOMBRE, localPath, ftpPath, true, false, ref resultadosExportacion))
                            bArchivoSubido = true;
                    }
                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_FACTURAELECTRONICA_XML)
                    {
                        localPath =  iPosReporting.WFFacturaElectronica.getFileLocalLocation_FE_XML_Timbrados(DBValues._DOCTO_TIPO_VENTA, CurrentUserID.CurrentParameters) + "\\";
                        ftpPath = ExportarDBF.FileFTPLocation_FacturaElectronicaXML + "/";

                        m_UltimoExporting = "7- EnviarArchivosYageneradosAftp Local " + localPath + " Ftp " + ftpPath;

                        if (UploadFile(filesExpBE.INOMBRE, localPath, ftpPath, true, false, ref resultadosExportacion))
                            bArchivoSubido = true;
                    }


                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_DEVOLUCIONELECTRONICA_PDF)
                    {
                        localPath =  iPosReporting.WFFacturaElectronica.getFileLocalLocation_FE_PDF(DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO, CurrentUserID.CurrentParameters) + "\\";
                        ftpPath = ExportarDBF.FileFTPLocation_DevolucionElectronicaPDF + "/";

                        m_UltimoExporting = "7- EnviarArchivosYageneradosAftp Local " + localPath + " Ftp " + ftpPath;

                        if (UploadFile(filesExpBE.INOMBRE, localPath, ftpPath, true, false, ref resultadosExportacion))
                            bArchivoSubido = true;
                    }
                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_DEVOLUCIONELECTRONICA_XML)
                    {
                        localPath =  iPosReporting.WFFacturaElectronica.getFileLocalLocation_FE_XML_Timbrados(DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO, CurrentUserID.CurrentParameters) + "\\";
                        ftpPath = ExportarDBF.FileFTPLocation_DevolucionElectronicaXML + "/";

                        m_UltimoExporting = "7- EnviarArchivosYageneradosAftp Local " + localPath + " Ftp " + ftpPath;

                        if (UploadFile(filesExpBE.INOMBRE, localPath, ftpPath, true, false, ref resultadosExportacion))
                            bArchivoSubido = true;
                    }


                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_COMPROBANTETRASLADO_PDF)
                    {
                        localPath = iPosReporting.WFFacturaElectronica.getFileLocalLocation_FE_PDF(DBValues._DOCTO_TIPO_VENTA, CurrentUserID.CurrentParameters,"T") + "\\";
                        ftpPath = ExportarDBF.FileFTPLocation_ComprobanteTrasladoPDF + "/";

                        m_UltimoExporting = "7- EnviarArchivosYageneradosAftp Local " + localPath + " Ftp " + ftpPath;


                        if (UploadFile(filesExpBE.INOMBRE, localPath, ftpPath, true, false, ref resultadosExportacion))
                            bArchivoSubido = true;
                    }
                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_COMPROBANTETRASLADO_XML)
                    {
                        localPath = iPosReporting.WFFacturaElectronica.getFileLocalLocation_FE_XML_Timbrados(DBValues._DOCTO_TIPO_VENTA, CurrentUserID.CurrentParameters, "T") + "\\";
                        ftpPath = ExportarDBF.FileFTPLocation_ComprobanteTrasladoXML + "/";

                        m_UltimoExporting = "7- EnviarArchivosYageneradosAftp Local " + localPath + " Ftp " + ftpPath;

                        if (UploadFile(filesExpBE.INOMBRE, localPath, ftpPath, true, false, ref resultadosExportacion))
                            bArchivoSubido = true;
                    }


                    if (bArchivoSubido)
                    {


                        m_UltimoExporting = "7- EnviarArchivosYageneradosAftp F";

                        //iCount++;
                        filesExpBE.IESTATUS = DBValues._EXP_FILES_ESTADOS_ENVIADO;
                        if (!filesExpD.CambiarEXP_FILESD(filesExpBE, filesExpBE, null))
                        {
                            resultadosExportacion.Add("Error " + filesExpD.IComentario);
                        }
                        resultadosExportacion.Add("Archivo " + filesExpBE.IARCHIVOFTP + " enviado");



                        if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_TRASLADO)
                        {
                            CDOCTOD doctoD = new CDOCTOD();
                            CDOCTOBE doctoBE = new CDOCTOBE();
                            doctoBE.IID = filesExpBE.IDOCTOID;
                            doctoBE.ITRANREGSERVER = DBValues._DB_BOOLVALUE_NO;
                            doctoD.CambiarTranRegServerDOCTOD(doctoBE, null);

                            HiloExistencias._IFLAGENVIARREGISTROTRASLAEVENTOS++;
                        }

                        if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_TRASLADODEVO)
                        {
                            CDOCTOD doctoD = new CDOCTOD();
                            CDOCTOBE doctoBE = new CDOCTOBE();
                            doctoBE.IID = filesExpBE.IDOCTOID;
                            doctoBE.ITRANREGSERVER = DBValues._DB_BOOLVALUE_NO;
                            doctoD.CambiarTranRegServerDOCTOD(doctoBE, null);

                            HiloExistencias._IFLAGENVIARREGISTROTRASLAEVENTOS++;
                        }


                        if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_PEDIDODEVO)
                        {
                            CDOCTOD doctoD = new CDOCTOD();
                            CDOCTOBE doctoBE = new CDOCTOBE();
                            doctoBE.IID = filesExpBE.IDOCTOID;
                            doctoBE.ITRANREGSERVER = DBValues._DB_BOOLVALUE_NO;
                            doctoD.CambiarTranRegServerDOCTOD(doctoBE, null);

                            HiloExistencias._IFLAGENVIARREGISTROTRASLAEVENTOS++;
                        }

                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                m_Exporting = false;
                m_UltimoExporting = "";
                return false;
            }



            ////existencias
            //string fileExistencias = ExportarDBF.FileNameExistenciasFTP + "." + CurrentUserID.SUCURSAL_CLAVE;
            //localPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_ExistenciasLocales;
            //ftpPath = ExportarDBF.FileFTPLocation_Existencias + "/";
            //UploadFile(fileExistencias, localPath, ftpPath, false, false, ref resultadosExportacion);



            m_Exporting = false;
            m_UltimoExporting = "";


            EnvirArchivosYaGeneradosAFtpMail(ref resultadosExportacion);


            return bRetorno;
        }



        public bool EnvirArchivosYaGeneradosAFtpMail(ref ArrayList resultadosExportacion)
        {
            bool bRetorno = true;
            //bool bRes = true;
            


            CEXP_FILESD filesExpD = new CEXP_FILESD();
            CEXP_FILESBE filesExpBE = new CEXP_FILESBE();

            CPARAMETROBE parametroBE = new CPARAMETROBE();
            CPARAMETROD parametroD = new CPARAMETROD();
            CCAJAD cajaD = new CCAJAD();
            CCAJABE cajaBE = new CCAJABE();

            ExportarDBF exportDbf = new ExportarDBF();
            //ArrayList resultadosExportacion = new ArrayList();


            System.Collections.ArrayList parts = new ArrayList();
            //FbParameter auxPar;
            FbParameter[] arParms = new FbParameter[parts.Count];
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;


            bool bArchivoSubido = false;

            //recorre la lista de archivos a exportar para enviarlos al FTP
            try
            {
                

                String CmdTxt = @"select * from EXP_FILES where ESTATUS = 'G' AND TIPO IN ('M','L') ";
                dr = SqlHelper.ExecuteReader(ConexionesBD.ConexionBD.ConexionString(), CommandType.Text, CmdTxt, out pcn, arParms);

                

                while (dr.Read())
                {
                    //if (iCount > iMaxCount)
                    //    break;


                    


                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_INV_MAIL)
                    {

                        if (filesExpBE.INOMBRE != null && filesExpBE.INOMBRE.Trim().Length > 0)
                        {
                            string strArchivo = System.AppDomain.CurrentDomain.BaseDirectory + EnviosMail.FileLocalLocation_Excel + "\\" + filesExpBE.INOMBRE;
                            
                            if (EnviosMail.EnviarInventario("", strArchivo))
                                bArchivoSubido = true;
                        }
                        else
                        {
                            bArchivoSubido = true;
                        }

                    }


                    if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_REC_ELIM_MAIL)
                    {
                        string strArchivo = System.AppDomain.CurrentDomain.BaseDirectory + EnviosMail.FileLocalLocation_Excel + "\\" + filesExpBE.INOMBRE;
                        

                        if (EnviosMail.EnviarRecepcionEliminada("", strArchivo))
                            bArchivoSubido = true;

                    }

                    



                    if (bArchivoSubido)
                    {

                        

                        //iCount++;
                        filesExpBE.IESTATUS = DBValues._EXP_FILES_ESTADOS_ENVIADO;
                        if (!filesExpD.CambiarEXP_FILESD(filesExpBE, filesExpBE, null))
                        {
                            resultadosExportacion.Add("Error " + filesExpD.IComentario);
                        }
                        resultadosExportacion.Add("Archivo " + filesExpBE.IARCHIVOFTP + " enviado");

                        
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

            
            

            return bRetorno;
        }


        public bool ActualizarListadeExportacion()
        {
            return true;
        }


        

        public bool HayArchivoPreciosDeFtpADescargar()
        {
            return ArchivoPreciosDeFtpADescargar() != null;
        }


        public bool DescargarArchivoPreciosDeFtp()
        {

            FileItem? fileItem = ArchivoPreciosDeFtpADescargar();
            if (fileItem == null)
                return false;

            //esta funcion tambien agrega los registros en imp_files( lo cual esta mal pero asi esta trabajando ahorita)
            if (!DescargarArchivo(fileItem.Value, null, CIMP_FILESD.FileType_Producto))
            {
                return false;
            }
            else
            {
                DescomprimirArchivo(fileItem.Value, CIMP_FILESD.FileType_Producto);
                CopiarArchivosAdicionales(fileItem.Value, CIMP_FILESD.FileType_Producto);

               

            }

            return true;
        }


        public FileItem? ArchivoPreciosDeFtpADescargar()
        {
            CIMP_FILESD imp_filesD = new CIMP_FILESD();
            ArrayList lastDownloaded = imp_filesD.ObtenerUltimosArchivosDescargados(null);

            LastDownloadedFiles[] ldf = new LastDownloadedFiles[lastDownloaded.Count];
            lastDownloaded.CopyTo(ldf, 0);

            int iProductos = -1;
            DateTime fechaProductos;
            FilesForImporting fileForImport = new FilesForImporting();

            for (int i = 0; i < lastDownloaded.Count; i++)
            {
                switch (ldf[i].TIPO)
                {
                    case CIMP_FILESD.FileType_Producto: iProductos = i; break;
                    default: break;
                }

            }

            
                //Productos
                fileForImport = new FilesForImporting();
                fileForImport.TIPO = CIMP_FILESD.FileType_Producto;
                if (iProductos == -1)
                    fechaProductos = DateTime.Parse("01/01/1900");
                else
                {
                    fechaProductos = ldf[iProductos].FECHA;
                    fechaProductos = fechaProductos.Add(ldf[iProductos].TIME);
                }

                fileForImport.FILES = iPos.Tools.FTPManagement.ObtenerArchivosNuevos(GetFtpFileLocation(CIMP_FILESD.FileType_Producto), fechaProductos);

                foreach(FileItem fileItem in fileForImport.FILES)
                {

                    if (fileItem.FILEPATHNAME.ToUpper().Contains("PREC.ZIP"))
                        return fileItem;
                }

                
            
            return null;
        }





    }
}
