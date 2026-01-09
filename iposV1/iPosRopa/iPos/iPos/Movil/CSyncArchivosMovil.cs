using DataLayer.Importaciones;
using DataLayer.Utilerias.Movil;
using iPosBusinessEntity;
using iPosData;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPos.Movil
{
    public class CSyncArchivosMovil
    {

        public static DateTime? fechaHoraBusy = null;

        public static bool ExportarArchivoConCobranzaAutomatico(string vendedorClave, DateTime fecha, ref string comentario)
        {
            bool m_importacionExitosa = true;
            try
            {

                CPERSONAD personaD = new CPERSONAD();

                CPERSONABE m_vendedor = new CPERSONABE();
                m_vendedor.ICLAVE = vendedorClave;
                m_vendedor.ITIPOPERSONAID = DBValues._TIPOPERSONA_VENDEDOR;

                m_vendedor = personaD.seleccionarPERSONAxCLAVEyTIPO(m_vendedor, null);
                if (m_vendedor == null)
                {

                    comentario = "No existe el vendedor. Seleccione un vendedor valido";
                    return false;
                }


                string message = "";
                bool error = false;
                CBITACOBRANZABE m_cobranzaALlevar = CSyncArchivosMovil.ObtenerCobranzaVendedorMovil(m_vendedor.IID, fecha, ref message, ref error);

                m_importacionExitosa = true;
                CSyncArchivosMovil.ExportarArchivoConCobranza(m_vendedor, fecha, m_cobranzaALlevar, ref comentario, ref m_importacionExitosa);


                
            }
            catch (Exception ex)
            {
                return false;
            }

            return m_importacionExitosa;
        }


        public static CBITACOBRANZABE ObtenerCobranzaVendedorMovil(long vendedorId, DateTime fecha, ref string message, ref bool error)
        {
            CBITACOBRANZAD cobranzaD = new CBITACOBRANZAD();
            CBITACOBRANZABE cobranzaBE = new CBITACOBRANZABE();
            cobranzaBE.IFECHA = fecha;
            cobranzaBE.ICOBRADORID = vendedorId;
            List<CBITACOBRANZABE> listaCobranzas = cobranzaD.seleccionarBITACOBRANZAXCOBRADORFECHA(cobranzaBE, null);

            error = false;


            if (listaCobranzas == null)
            {

                message = "Ocurrio un error al seleccionar las cobranzas del vendedor " + cobranzaD.IComentario;
                error = true;
                return null;
            }

            if (listaCobranzas.Count == 0)
            {
                message = "El vendedor no tiene asociada una lista de cobranzas... desea seguir el proceso de exportacion?";

            }
            else
            {

                return  listaCobranzas[0];
            }

            return null;
        }

        public static void ExportarArchivoConCobranza( CPERSONABE m_vendedor,  DateTime fechaCobranza, CBITACOBRANZABE m_cobranzaALlevar, ref string m_iComentario, ref bool m_importacionExitosa)
        {
            try
            {


                if (fechaHoraBusy != null &&   (DateTime.Now - fechaHoraBusy.Value).Minutes < 10 )
                {
                    m_iComentario = "se esta haciendo otra exportacion";
                    m_importacionExitosa = false;
                    return;
                }

                fechaHoraBusy = DateTime.Now;

                    ExportarDBF iDBF = new ExportarDBF();
                ArrayList strErrores = new ArrayList();
                DatosMovilFb datosMovilFb = new DatosMovilFb();


                var m_usuarioRelacionadoAlVendedor = ObtenerUsuarioRelacionadoAVendedor(m_vendedor);

                if (iDBF.ExportParaMovil(CurrentUserID.CurrentParameters, CurrentUserID.CurrentUser, DateTime.Now, m_vendedor, m_usuarioRelacionadoAlVendedor, m_cobranzaALlevar, false, ref strErrores))
                {
                    string zipFileName = "";
                    if (m_vendedor != null)
                        zipFileName = "PREC_" + m_vendedor.ICLAVE + ".ZIP";
                    else
                        zipFileName = "PREC_.ZIP";

                    string strPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_MovilPreciosZipLocalPath + zipFileName;

                    bool bRes = UploadFile(strPath, m_vendedor.ICLAVE, iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                           iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                           iPos.Tools.FTPManagement.m_strFTPFolderPassWs, ref m_iComentario);

                    m_importacionExitosa = bRes;

                    if (m_importacionExitosa)
                    {
                        if (m_vendedor != null)
                            cambiarSyncEstatusEnviar3(m_vendedor, 2, fechaCobranza);
                    }

                }
                else
                {
                    m_iComentario = iDBF.IComentario;
                }
            }
            catch(Exception ex)
            {
                fechaHoraBusy = null;
                m_iComentario = ex.Message;
                throw ex;
            }
            finally
            {
                fechaHoraBusy = null;
            }
            
        }



        private static CPERSONABE ObtenerUsuarioRelacionadoAVendedor(CPERSONABE m_vendedor)
        {
            CPERSONAD personaD = new CPERSONAD();
            CPERSONABE personaBE = new CPERSONABE();
            personaBE.IVENDEDORID = m_vendedor.IID;
            personaBE.ITIPOPERSONAID = DBValues._TIPOPERSONA_USUARIO;

            var lstPersonaUsuarios = personaD.seleccionarPERSONASxVENDEDOR(personaBE, null);
            if (lstPersonaUsuarios != null && lstPersonaUsuarios.Count() > 0)
                return lstPersonaUsuarios[0];

            return null;
        }


        private static string cambiarSyncEstatusEnviar3(CPERSONABE m_vendedor, long estatusEnvio, DateTime fecha)
        {
            /*
                */

            com.server.ipos.Service1 service1 = new com.server.ipos.Service1();
            string strWebService = CurrentUserID.CurrentParameters.IUSARCONEXIONLOCAL.Equals("S") ? (CurrentUserID.CurrentParameters.ILOCALWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.ILOCALWEBSERVICE.Trim()) : (CurrentUserID.CurrentParameters.IWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.IWEBSERVICE.Trim());
            if (strWebService.Trim().Length > 0)
            {
                service1.Url = strWebService.Trim();
            }

            CM_SYNCBE syncBE = new CM_SYNCBE();
            syncBE.IVENDCLAVE = m_vendedor.ICLAVE;
            syncBE.IESTATUSENVIOSUC = estatusEnvio;
            syncBE.IFECHAULTENVIOSUC = fecha;

            string syncJsonStr = JsonConvert.SerializeObject(syncBE, Formatting.Indented);

            string strRespuesta = service1.CambiarSyncEstatusEnviar3(
                    m_vendedor.ICLAVE,
                            syncJsonStr,
                            "S", "S",
                            iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                iPos.Tools.FTPManagement.m_strFTPFolderPassWs); ;

            if (!strRespuesta.Equals("exito"))
            {

                return " /No se pudo cerrar el corte de ventas" + strRespuesta;
            }
            else
            {

                return "La solicitud se envio correctamente ";
            }
        }



        /// <summary>
        /// Upload any file to the web service; this function may be
        /// used in any application where it is necessary to upload
        /// a file through a web service
        /// </summary>
        /// <param name="filename">Pass the file path to upload</param>
        private static bool UploadFile(string filename, string vendedor, string sucursal, string folder, string pass, ref string comm)
        {
            try
            {
                // get the exact file name from the path
                String strFile = System.IO.Path.GetFileName(filename);

                // create an instance fo the web service
                com.server.ipos.Service1 service1 = new com.server.ipos.Service1();

                string strWebService = CurrentUserID.CurrentParameters.IUSARCONEXIONLOCAL.Equals("S") ? (CurrentUserID.CurrentParameters.ILOCALWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.ILOCALWEBSERVICE.Trim()) : (CurrentUserID.CurrentParameters.IWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.IWEBSERVICE.Trim());
                if (strWebService.Trim().Length > 0)
                {
                    service1.Url = strWebService.Trim();
                }
                //quitar
                //service1.Url = "http://localhost:4012/Service1.asmx";

                // get the file information form the selected file
                FileInfo fInfo = new FileInfo(filename);

                // get the length of the file to see if it is possible
                // to upload it (with the standard 4 MB limit)
                long numBytes = fInfo.Length;
                double dLen = Convert.ToDouble(fInfo.Length / 1000000);

                // Default limit of 4 MB on web server
                // have to change the web.config to if
                // you want to allow larger uploads
                if (dLen < 4)
                {
                    // set up a file stream and binary reader for the 
                    // selected file
                    FileStream fStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fStream);

                    // convert the file to a byte array
                    byte[] data = br.ReadBytes((int)numBytes);
                    br.Close();

                    // pass the byte array (file) and file name to the web service
                    string sTmp = service1.UploadPrecZipMovil_3(data, vendedor, sucursal, folder, pass);
                    fStream.Close();
                    fStream.Dispose();

                    // this will always say OK unless an error occurs,
                    // if an error occurs, the service returns the error message
                    if (sTmp == "OK")
                        return true;

                    comm = "File Upload Status: " + sTmp + "File Upload";
                }
                else
                {
                    // Display message if the file was too large to upload
                    comm = "The file selected exceeds the size limit for uploads.";

                }
            }
            catch (Exception ex)
            {
                // display an error message to the user
                comm = ex.Message.ToString() + "Upload Error";
            }

            return false;
        }

    }
}
