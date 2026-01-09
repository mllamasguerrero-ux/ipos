using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iPosData;
using iPosBusinessEntity;
using ConexionesBD;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.ApplicationBlocks.Data;
using System.Collections;
using DataLayer.Importaciones;
using System.IO;
using DataLayer.Utilerias.Movil;
using iPos.WebServices;

namespace iPos.Movil
{
    public partial class WFGenerarDatosParaMovil : Form
    {
        private bool m_importacionExitosa;
        private string m_iComentario;
        CPERSONABE m_vendedor;
        CPERSONABE m_usuarioRelacionadoAlVendedor;
        CBITACOBRANZABE m_cobranzaALlevar;

        public WFGenerarDatosParaMovil()
        {
            InitializeComponent();
            m_importacionExitosa = false;
            m_iComentario = "";
            m_vendedor = null;
            m_cobranzaALlevar = null;
        }

        private void btnRecibir_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fecha = FECHATextBox.Value;
                int vendedorId = 0;
                try
                {
                    vendedorId = int.Parse(this.COBRADORIDTextBox.DbValue.ToString());

                }
                catch
                {
                    MessageBox.Show("Seleccione un vendedor valido");
                    return;
                }
                
                CPERSONAD personaD = new CPERSONAD();

                m_vendedor = new CPERSONABE();
                m_vendedor.IID = vendedorId;

                m_vendedor = personaD.seleccionarPERSONA(m_vendedor, null);
                if(m_vendedor == null)
                {

                    MessageBox.Show("No existe el vendedor. Seleccione un vendedor valido");
                    return;
                }




                CBITACOBRANZAD cobranzaD = new CBITACOBRANZAD();
                CBITACOBRANZABE cobranzaBE = new CBITACOBRANZABE();
                cobranzaBE.IFECHA = fecha;
                cobranzaBE.ICOBRADORID = vendedorId;
                List<CBITACOBRANZABE> listaCobranzas = cobranzaD.seleccionarBITACOBRANZAXCOBRADORFECHA(cobranzaBE, null);

                if(listaCobranzas == null)
                {

                    MessageBox.Show("Ocurrio un error al seleccionar las cobranzas del vendedor " +  cobranzaD.IComentario);
                    return;
                }

                if(listaCobranzas.Count == 0)
                {
                    if (MessageBox.Show("El vendedor no tiene asociada una lista de cobranzas... desea seguir el proceso de exportacion?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return ;
                    }

                }
                else
                {

                    m_cobranzaALlevar = listaCobranzas[0];
                }



                //hacer lo que hacemos con el zip normalmente
                //agregar la logica para agregar clientes, y credito y cobranza
                //exportar por ftp ..ver como lo hace o hacia el de vocero.. si no ponerlo en una carpeta particular

                


                progressBar1.Style = ProgressBarStyle.Marquee;
                backgroundWorker1.RunWorkerAsync();

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            ExportarDBF iDBF = new ExportarDBF();
            ArrayList strErrores = new ArrayList();
            DatosMovilFb datosMovilFb = new DatosMovilFb();
            string strVersion =  CBAndroid.Checked ? ExportacionesConstants.m_versionExportacionSQLite: ExportacionesConstants.m_versionExportacionDBF;
            string zipFileName = CBAndroid.Checked ? "PREC_" + m_vendedor.ICLAVE + "_ANDROID.ZIP" : "PREC_" + m_vendedor.ICLAVE + ".ZIP";

            m_usuarioRelacionadoAlVendedor = this.ObtenerUsuarioRelacionadoAVendedor();
            if (iDBF.ExportParaMovil(CurrentUserID.CurrentParameters, CurrentUserID.CurrentUser, DateTime.Now, m_vendedor, m_usuarioRelacionadoAlVendedor,  m_cobranzaALlevar, CBExpProdInactivos.Checked, ref strErrores, strVersion))
            {
                //string zipFileName = "PREC_" + m_vendedor.ICLAVE + ".ZIP";
                string strPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_MovilPreciosZipLocalPath + zipFileName;

                bool bRes = UploadFile(strPath, m_vendedor.ICLAVE, iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                       iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                       iPos.Tools.FTPManagement.m_strFTPFolderPassWs, ref m_iComentario);

                m_importacionExitosa = bRes;

            }
            else
            {
                m_iComentario = iDBF.IComentario;
            }

            /** Exportación Firebird **/
            /*List<CPERSONABE> clientes = ObtenerClientes();
            string manejaKits = CurrentUserID.CurrentParameters.IMANEJAKITS.Equals("S") ? "S" : "N";
            long cobranzaId = m_cobranzaALlevar != null ? m_cobranzaALlevar.IID : 0;
            long tipoVendedor = CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL;

            if (datosMovilFb.ExportarDatosAFb(clientes, 0, manejaKits, cobranzaId, m_vendedor.ICLAVE, tipoVendedor))
            {
                WSVenMovAndroid wsVendedorMovil = new WSVenMovAndroid();
                string path = @"C:\inetpub\ftproot\testburro\"; 
                string empresa = CurrentUserID.CurrentParameters.IFTPFOLDER; 
                string claveSucursal = CurrentUserID.CurrentParameters.ISUCURSALNUMERO;
                string destino = path + claveSucursal;
                string rutaOrigenArchivo = AppDomain.CurrentDomain.BaseDirectory + @"sampdata\VENMOVDROID.fdb";
                wsVendedorMovil.SubirArchivoVenMov(rutaOrigenArchivo, "VENMOV.FDB", destino);
            }
            else
            {
                m_iComentario = datosMovilFb.Comentario;
            }*/
        }

        private List<CPERSONABE> ObtenerClientes()
        {
            CPERSONAD personaD = new CPERSONAD();
            CPERSONABE personaBE = new CPERSONABE();
            personaBE.IVENDEDORID = m_vendedor.IID;
            personaBE.ITIPOPERSONAID = DBValues._TIPOPERSONA_CLIENTE;

            return personaD.seleccionarPERSONASxVENDEDOR(personaBE, null);
        }

        private CPERSONABE ObtenerUsuarioRelacionadoAVendedor()
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



        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Style = ProgressBarStyle.Blocks;
            if (m_importacionExitosa)
            {
                MessageBox.Show("Los archivos han sido exportados");
            }
            else
            {
                MessageBox.Show(m_iComentario);
            }
        }



        /// <summary>
        /// Upload any file to the web service; this function may be
        /// used in any application where it is necessary to upload
        /// a file through a web service
        /// </summary>
        /// <param name="filename">Pass the file path to upload</param>
        private bool UploadFile(string filename, string vendedor, string sucursal, string folder, string pass, ref string comm)
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

                    comm = "File Upload Status: " + sTmp +  "File Upload";
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
