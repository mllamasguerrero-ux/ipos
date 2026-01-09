using iPos.Tools;
using iPosBusinessEntity;
using iPosData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos.Mensajeria
{
    public partial class WFLeerMensaje : Form
    {
        long mensajeId;
        CMENSAJEBE mensajeActual = new CMENSAJEBE();

        long usuarioId = CurrentUserID.CurrentUser.IID;
        long mensajeEstadoId = DBValues._ESTADO_MENSAJE_RECIBIDO;

        public WFLeerMensaje(long mensajeId, long usuarioId, long mensajeEstadoId)
        {
            InitializeComponent();
            this.mensajeId = mensajeId;
            this.usuarioId = usuarioId;
            this.mensajeEstadoId = mensajeEstadoId;

        }

        private void cargarDatos()
        {
            //Entidades para almacenar datos del mensaje
            CMENSAJED mensajeD = new CMENSAJED();
            CMENSAJEADJUNTOSD mensajeAdjuntosD = new CMENSAJEADJUNTOSD();
            CMENSAJEESTADOD mensajeEstadoD = new CMENSAJEESTADOD();


            CMENSAJEBE mensaje = new CMENSAJEBE();
            CMENSAJEESTADOBE mensajeEstado = new CMENSAJEESTADOBE();

            List<CMENSAJEADJUNTOSBE> mensajeAdjuntosList = new List<CMENSAJEADJUNTOSBE>();

            //Recuperar datos de BD
            try
            {
                mensaje.IID = mensajeId;
                mensaje = mensajeD.seleccionarMENSAJE(mensaje, null);

                if (mensaje == null)
                {
                    MessageBox.Show("Mensaje no encontrado");
                    return;
                }

                mensajeActual = mensaje;

                mensajeAdjuntosList = mensajeAdjuntosD.getMensajeAdj(mensajeId, null);

                mensajeEstado.IID = mensaje.IMENSAJEESTADOID;

                mensajeEstado = mensajeEstadoD.seleccionarMENSAJEESTADO(mensajeEstado, null);
            }
            catch (Exception ex)
            {


                MessageBox.Show("una excepcion ocurrio " + ex.Message);
            }
            finally
            {

            }

            //Fijar datos en interfaz
            this.LBLAsunto.Text += mensaje.IASUNTO;
            this.LBLFechaEnvio.Text += mensaje.IFECHAHORA.ToString();
            this.messageWebBrowser.DocumentText = mensaje.IMENSAJE;

            if (mensajeAdjuntosList != null && mensajeAdjuntosList.Count > 0)
            {

                foreach (CMENSAJEADJUNTOSBE adj in mensajeAdjuntosList)
                {

                    iPos.Mensajeria.DSMensajeria.DatosAdjuntosRow drNew = 
                        (iPos.Mensajeria.DSMensajeria.DatosAdjuntosRow)dSMensajeria.DatosAdjuntos.NewRow();

                    drNew.NOMBRE = adj.IRUTAADJUNTO;
                    drNew.RUTA = adj.IRUTAADJUNTO;
                    drNew.NOMBREFTP = adj.IFTPADJUNTO;

                    dSMensajeria.DatosAdjuntos.AddDatosAdjuntosRow(drNew);
                }
            }
        }

        private void WFLeerMensaje_Load(object sender, EventArgs e)
        {

            cargarDatos();
            MarcarComoLeido();
        }


        private void MarcarComoLeido()
        {

            if (mensajeEstadoId == DBValues._ESTADO_MENSAJE_LEIDO)
                return;


            CMENSAJEUSUARIOBE mensajeUsuario = new CMENSAJEUSUARIOBE();
            CMENSAJEUSUARIOD mensajeUsuarioD = new CMENSAJEUSUARIOD();
            mensajeUsuario.IIDMENSAJE = mensajeId;
            mensajeUsuario.IPERSONAID = usuarioId;
            mensajeUsuario.IMENSAJEESTADOID = DBValues._ESTADO_MENSAJE_LEIDO;

            mensajeUsuario = mensajeUsuarioD.AgregarMENSAJEUSUARIOD(mensajeUsuario, null);

            if(mensajeUsuario == null)
            {
                MessageBox.Show("No se pudo marcar como leido");
            }

            if(mensajeActual.ISOLOADMIN == "S")
            {
                CMENSAJED mensajeD = new CMENSAJED();
                mensajeActual.IMENSAJEESTADOID = DBValues._ESTADO_MENSAJE_LEIDO;

                if(!mensajeD.CambiarESTADOD(mensajeActual, mensajeActual, null))
                {
                    MessageBox.Show("No se pudo marcar como leido");
                }
            }
            
        }

        private void datosAdjuntosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (datosAdjuntosDataGridView.Columns[e.ColumnIndex].Name == "NOMBRE")
            {
                string nombreArchivo = datosAdjuntosDataGridView.Rows[e.RowIndex].Cells["NOMBRE"].Value.ToString();
                string nombreArchivoEnFtp = datosAdjuntosDataGridView.Rows[e.RowIndex].Cells["NOMBREFTP"].Value.ToString();
                string comentario = "";

                if (!DescargaArchivoDeFtp(nombreArchivoEnFtp, nombreArchivo, ref comentario))
                {
                    MessageBox.Show("Error " + comentario);
                }
                else
                {
                    MessageBox.Show("El archivo se ha descargado");
                }
            }
        }

        private bool DescargaArchivoDeFtp(string nombreArchivoEnFtp, string nombreArchivo, ref string comentario)
        {
            try
            {
                saveFileDialog1.FileName = Path.GetFileName(nombreArchivo);


                int result = (int)this.saveFileDialog1.ShowDialog();
                string pathAndName = "";

                if (result == (int)System.Windows.Forms.FolderBrowserResult.OK)
                {
                    // folderName = this.folderBrowserDialog1.SelectedPath;
                    pathAndName = saveFileDialog1.FileName;
                }
                else
                {
                    return false;
                }



                string fileLocalPath = Path.GetDirectoryName(pathAndName) + Path.DirectorySeparatorChar;
                string fileNameLocal = Path.GetFileName(pathAndName);


                if (!FTPManagement.Download(fileLocalPath, ImportaDesdeFtp.FtpMensajeriaUploaded, nombreArchivoEnFtp, false, fileNameLocal, ref comentario))
                {
                    comentario = "No se pudo enviar el archivo al ftp";
                    return false;
                }


            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}
