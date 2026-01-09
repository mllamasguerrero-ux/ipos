using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iPosBusinessEntity;
using iPosData;
using FirebirdSql.Data.FirebirdClient;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using iPos.Tools;
using System.IO;

namespace iPos
{
    public partial class WFMensajeEnvio : Form
    {


        public string opc = "";
        public long mensajeId;

        public WFMensajeEnvio()
        {
            InitializeComponent();
        }

        public void ReCargar(string popc, long pMensajeId)
        {
            opc = popc;
            mensajeId = pMensajeId;

        }


        public bool bEsConsulta()
        {
            return opc.Equals("Consultar");
        }


        public void HabilitarEdicion(bool habilitar)
        {
            this.TBAsunto.Enabled = habilitar;
            this.BodyMessage.Enabled = habilitar;
            this.CBTodasAreas.Enabled = habilitar;
            this.CBTodasAreas.Enabled = habilitar;
            this.sUCURSALDataGridView.Enabled = habilitar;
            this.aREADataGridView.Enabled = habilitar;
            this.MENSAJENIVELURGENCIATextBox.Enabled = habilitar;
            this.CBRestrictivo.Enabled = habilitar;
            this.CBSoloAdministradores.Enabled = habilitar;
            this.btnAddFile.Enabled = habilitar;
            this.datosAdjuntosDataGridView.Columns["DGELIMINAR"].Visible = habilitar;
            //this.datosAdjuntosDataGridView.Enabled = habilitar;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {

            CMENSAJED mensajeD = new CMENSAJED();
            CMENSAJEAREAD mensajeAreaD = new CMENSAJEAREAD();
            CMENSAJESUCD mensajeSucD = new CMENSAJESUCD();
            CMENSAJEADJUNTOSD mensajeAdjuntosD = new CMENSAJEADJUNTOSD();


            CMENSAJEBE mensaje = new CMENSAJEBE();


            if (this.mensajeId == 0)
            {

                FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
                FbTransaction fTrans = null;
                try
                {

                    fConn.Open();
                    fTrans = fConn.BeginTransaction();

                    mensaje.IASUNTO = TBAsunto.Text;
                    mensaje.IACTIVO = "S";
                    mensaje.ICODIGOLECTURA = "";//TO-DO
                    mensaje.IFECHA = DateTime.Today;
                    mensaje.IFECHAHORA = DateTime.Now;
                    mensaje.IMENSAJE = BodyMessage.Html;
                    mensaje.IMENSAJEESTADOID = DBValues._ESTADO_MENSAJE_BORADOR;
                    mensaje.IMENSAJETIPOID = DBValues._TIPO_MENSAJE_SALIDA;

                    if (this.MENSAJENIVELURGENCIATextBox.Text != "")
                    {
                        mensaje.INIVELDEURGENCIAID = long.Parse(this.MENSAJENIVELURGENCIATextBox.SelectedValue.ToString());
                    }

                    mensaje.IPARATODASAREAS = CBTodasAreas.Checked ? "S" : "N";
                    mensaje.IPARATODASSUC = CBTodasSucursales.Checked ? "S" : "N";
                    mensaje.IRESTRICTIVO = CBRestrictivo.Checked ? "S" : "N";
                    mensaje.ISOLOADMIN = CBSoloAdministradores.Checked ? "S" : "N";
                    mensaje.ISUCURSALFUENTECLAVE = CurrentUserID.CurrentParameters.ISUCURSALNUMERO;


                    mensaje = mensajeD.AgregarMENSAJED(mensaje, fTrans);

                    if (mensaje == null)
                    {
                        fTrans.Rollback();
                        fConn.Close();
                        MessageBox.Show("un error ocurrio al insertar el mensaje " + mensajeD.IComentario);
                        return;
                    }

                    if (mensaje.IPARATODASSUC != "S")
                    {
                        foreach (DataGridViewRow dataRow in this.sUCURSALDataGridView.Rows)
                        {
                            if (
                                dataRow.Cells["DGENVIAR"].Value != null
                                && dataRow.Cells["DGENVIAR"].Value != DBNull.Value
                                && ((int)dataRow.Cells["DGENVIAR"].Value == 1)  )
                            {

                                long sucursalId = (long)dataRow.Cells["DGID"].Value;
                                string sucursalClave = dataRow.Cells["DGCLAVE"].Value.ToString();
                                CMENSAJESUCBE mensajeSucBE = new CMENSAJESUCBE();
                                mensajeSucBE.IIDMENSAJE = mensaje.IID;
                                mensajeSucBE.ISUCURSALID = sucursalId;
                                mensajeSucBE.ICLAVESUC = sucursalClave;


                                mensajeSucBE = mensajeSucD.AgregarMENSAJESUCD(mensajeSucBE, fTrans);
                                if (mensajeSucBE == null)
                                {
                                    fTrans.Rollback();
                                    fConn.Close();
                                    MessageBox.Show("un error ocurrio al insertar la sucursal del mensaje " + mensajeSucD.IComentario);
                                    return;
                                }



                            }
                        }
                    }



                    if (mensaje.IPARATODASAREAS != "S")
                    {
                        foreach (DataGridViewRow dataRow in this.aREADataGridView.Rows)
                        {
                            if (
                                dataRow.Cells["DGAREAENVIAR"].Value != null
                                && dataRow.Cells["DGAREAENVIAR"].Value != DBNull.Value
                                && ((int)dataRow.Cells["DGAREAENVIAR"].Value == 1))
                            {

                                long areaId = (long)dataRow.Cells["DGAREAID"].Value;
                                string areaClave = dataRow.Cells["DGAREACLAVE"].Value.ToString();
                                CMENSAJEAREABE mensajeAreaBE = new CMENSAJEAREABE();
                                mensajeAreaBE.IIDMENSAJE = mensaje.IID;
                                mensajeAreaBE.IIDAREA = areaId;
                                mensajeAreaBE.ICLAVEAREA = areaClave;

                                mensajeAreaBE = mensajeAreaD.AgregarMENSAJEAREAD(mensajeAreaBE, fTrans);
                                if (mensajeAreaBE == null)
                                {
                                    fTrans.Rollback();
                                    fConn.Close();
                                    MessageBox.Show("un error ocurrio al insertar el area del mensaje " + mensajeAreaD.IComentario);
                                    return;
                                }


                            }
                        }
                    }


                    if (this.datosAdjuntosDataGridView.RowCount > 0)
                    {
                        foreach (DataGridViewRow dataRow in this.datosAdjuntosDataGridView.Rows)
                        {

                            string nombreArchivo = dataRow.Cells["DGADJUNTONOMBRE"].Value.ToString();
                            string rutaArchivo = dataRow.Cells["DGADJUNTORUTA"].Value.ToString();
                            CMENSAJEADJUNTOSBE mensajeAdjuntosBE = new CMENSAJEADJUNTOSBE();
                            mensajeAdjuntosBE.IIDMENSAJE = mensaje.IID;


                            mensajeAdjuntosBE.IRUTAADJUNTO = rutaArchivo;
                            mensajeAdjuntosBE.INOMBREARCHIVO = nombreArchivo;

                            mensajeAdjuntosBE = mensajeAdjuntosD.AgregarMENSAJEADJUNTOSD(mensajeAdjuntosBE, fTrans);
                            if (mensajeAdjuntosBE == null)
                            {
                                fTrans.Rollback();
                                fConn.Close();
                                MessageBox.Show("un error ocurrio al insertar el adjunto del mensaje " + mensajeAdjuntosD.IComentario);
                                return;
                            }




                        }
                    }


                    this.mensajeId = mensaje.IID;
                    fTrans.Commit();

                    this.HabilitarEdicion(false);


                }
                catch (Exception ex)
                {
                    fTrans.Rollback();
                    fConn.Close();


                    MessageBox.Show("una excepcion ocurrio " + ex.Message);
                }
                finally
                {
                    fConn.Close();
                }

            }


            if (this.mensajeId != 0)
            {

                //to-do aqui se recorre la lista de mensajes adjuntos y se sube al ftp .. aqui tambien se cambia la ruta del adjunto a la ruta del ftp en la bd
                //to-do aqui se manda llamar al webservice y se envia la informacion 
                string comentario = "";



                if (!EnviarArchivosAFtp(mensaje.IID, ref comentario))
                {

                    MessageBox.Show("No se pudo enviar los datos adjuntos.. el mensaje quedara guardado y puede reintentar enviarlo mas tarde. \n\n Detalle del error: " + comentario);
                    return;
                }


                if (!EnviarAWebService(mensaje.IID, ref comentario))
                {
                    MessageBox.Show("No se pudo enviar.. el mensaje quedara guardado y puede reintentar enviarlo mas tarde. \n\n Detalle del error: " + comentario);
                    return;
                }


                MessageBox.Show("Se agrego el mensaje");
                this.Close();
            }







        }


        private bool EnviarArchivosAFtp(long mensajeId, ref string comentario)
        {

            List<CMENSAJEADJUNTOSBE> mensajeAdjuntosList = new List<CMENSAJEADJUNTOSBE>();
            CMENSAJEADJUNTOSD mensajeAdjuntosD = new CMENSAJEADJUNTOSD();


            mensajeAdjuntosList = mensajeAdjuntosD.getMensajeAdj(mensajeId, null);


            foreach (CMENSAJEADJUNTOSBE adjunto in mensajeAdjuntosList)
            {

                if (adjunto.IFTPADJUNTO != null && adjunto.IFTPADJUNTO != "")
                {
                    continue;
                }

                string fullFtpPath = "";
                string fileName = Path.GetFileName(adjunto.IRUTAADJUNTO);
                string filenameFtp = CurrentUserID.CurrentParameters.ISUCURSALNUMERO + "_" + adjunto.IID.ToString() + "_" + DateTime.Now.ToString("ddMMyyyyHHmmssfff") + "_" + fileName;
                if (!FTPManagement.Upload(Path.GetDirectoryName(adjunto.IRUTAADJUNTO) + Path.DirectorySeparatorChar, ImportaDesdeFtp.FtpMensajeriaUploaded, fileName, false, ref comentario, filenameFtp, ref fullFtpPath))
                {
                    comentario = "No se pudo enviar el archivo al ftp";
                    return false;
                }

                adjunto.IFTPADJUNTO = filenameFtp;
                if (!mensajeAdjuntosD.CambiarFTPADJUNTOD(adjunto, adjunto, null))
                {
                    comentario = "No se pudo cambiar el archivo ftp adjunto";
                    return false;
                }

            }

            return true;

        }


        private bool EnviarAWebService(long mensajeId, ref string comentario)
        {
            comentario = "";

            //string urlMensajeEnvio = @"http://localhost:51932/WcfMensajeriaWS.svc
            string urlMensajeEnvio = CurrentUserID.CurrentParameters.IWSMENSAJERIA != null ? 
                                    CurrentUserID.CurrentParameters.IWSMENSAJERIA + @"/SetMensaje" :
                                "";
            //string urlMensajeEnvio = CurrentUserID.CurrentParameters.IWSMENSAJERIA;
            HttpClient client = new HttpClient();

            CMENSAJEBE mensaje = new CMENSAJEBE();
            List<CMENSAJESUCBE> mensajeSucList = new List<CMENSAJESUCBE>();
            List<CMENSAJEAREABE> mensajeAreaList = new List<CMENSAJEAREABE>();
            List<CMENSAJEADJUNTOSBE> mensajeAdjuntosList = new List<CMENSAJEADJUNTOSBE>();

            CMENSAJEAREAD mensajeAreaD = new CMENSAJEAREAD();
            CMENSAJESUCD mensajeSucD = new CMENSAJESUCD();
            CMENSAJEADJUNTOSD mensajeAdjuntosD = new CMENSAJEADJUNTOSD();
            CMENSAJED mensajeD = new CMENSAJED();
            mensaje.IID = mensajeId;

            try
            {

                mensaje = mensajeD.seleccionarMENSAJE(mensaje, null);

                if (mensaje == null)
                {
                    comentario = "Mensaje no encontrado";
                    return false;
                }

                Dictionary<string, object> datos = new Dictionary<string, object>();



                datos["mensaje"] = mensaje;


                mensajeSucList = mensajeSucD.getMensajeSuc(mensajeId, null);
                mensajeAreaList = mensajeAreaD.getMensajeAdj(mensajeId, null);
                mensajeAdjuntosList = mensajeAdjuntosD.getMensajeAdj(mensajeId, null);


                datos["mensajesuc"] = mensajeSucList;
                datos["mensajeadj"] = mensajeAdjuntosList;
                datos["mensajearea"] = mensajeAreaList;


                var serialized = JsonConvert.SerializeObject(datos);
                byte[] bSerialized = Encoding.UTF8.GetBytes(serialized);

                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, urlMensajeEnvio);

                requestMessage.Content = new ByteArrayContent(bSerialized);

                requestMessage.Headers.Add("empresa", CurrentUserID.CurrentParameters.IFTPFOLDER);


                HttpResponseMessage response = client.SendAsync(requestMessage).Result;
                if (response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;

                    string strJsonRetorno = JsonConvert.DeserializeObject<string>(content);

                    Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(strJsonRetorno);
                    string res = values.ContainsKey("res") ? values["res"] : "";
                    string valor = values.ContainsKey("value") ? values["value"] : "";
                    string comentariows = values.ContainsKey("comentario") ? values["comentario"] : "";

                    response.Dispose();


                    if (res == "S" && valor != "")
                    {
                        try
                        {

                            long mensajeIdWS = long.Parse(valor);



                            mensaje.IMENSAJEID = mensajeIdWS;
                            if (!mensajeD.CambiarMENSAJEWSIDD(mensaje, mensaje, null))
                            {
                                comentario = "El mensaje se envio pero no se pudo asignar el id de mensaje localmente";
                                return false;
                            }



                            mensaje.IMENSAJEESTADOID = DBValues._ESTADO_MENSAJE_ENVIADO;

                            if (!mensajeD.CambiarESTADOD(mensaje, mensaje, null))
                            {
                                comentario += "El mensaje se envio pero no se pudo cambiar el estatus localmente";
                                return false;
                            }



                        }
                        catch
                        {

                        }
                    }
                    else
                    {
                        comentario = "Error de respuesta del ws " + comentariows;
                        return false;
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                comentario = "Excepcion " + ex.Message;
                return false;
            }



        }



        private void LlenarDatosDeBase()
        {


            CMENSAJED mensajeD = new CMENSAJED();
            CMENSAJEAREAD mensajeAreaD = new CMENSAJEAREAD();
            CMENSAJESUCD mensajeSucD = new CMENSAJESUCD();
            CMENSAJEADJUNTOSD mensajeAdjuntosD = new CMENSAJEADJUNTOSD();
            CMENSAJEESTADOD mensajeEstadoD = new CMENSAJEESTADOD();


            CMENSAJEBE mensaje = new CMENSAJEBE();

            CMENSAJEESTADOBE mensajeEstado = new CMENSAJEESTADOBE();

            List<CMENSAJESUCBE> mensajeSucList = new List<CMENSAJESUCBE>();
            List<CMENSAJEAREABE> mensajeAreaList = new List<CMENSAJEAREABE>();
            List<CMENSAJEADJUNTOSBE> mensajeAdjuntosList = new List<CMENSAJEADJUNTOSBE>();


            try
            {


                //obtener datos de la base de datos
                mensaje.IID = this.mensajeId;
                mensaje = mensajeD.seleccionarMENSAJE(mensaje, null);

                if (mensaje == null)
                {
                    MessageBox.Show("Mensaje no encontrado");
                    return;
                }


                mensajeSucList = mensajeSucD.getMensajeSuc(mensajeId, null);
                mensajeAreaList = mensajeAreaD.getMensajeAdj(mensajeId, null);
                mensajeAdjuntosList = mensajeAdjuntosD.getMensajeAdj(mensajeId, null);


                mensajeEstado.IID = mensaje.IMENSAJEESTADOID;
                mensajeEstado = mensajeEstadoD.seleccionarMENSAJEESTADO(mensajeEstado, null);




                //llena los datos en los campos correspondientes
                TBAsunto.Text = mensaje.IASUNTO;
                //mensaje.IFECHA = DateTime.Today; to-do poner un campo para mostrar la hora y fecha
                //mensaje.IFECHAHORA = DateTime.Now;
                this.LBLFechaEnvio.Text += mensaje.IFECHAHORA.ToString();
                BodyMessage.DocumentText = mensaje.IMENSAJE;

                if (this.MENSAJENIVELURGENCIATextBox.Text != "")
                {
                    mensaje.INIVELDEURGENCIAID = long.Parse(this.MENSAJENIVELURGENCIATextBox.SelectedValue.ToString());
                }

                CBTodasAreas.Checked = mensaje.IPARATODASAREAS == "S" ? true : false;
                CBTodasSucursales.Checked = mensaje.IPARATODASSUC == "S" ? true : false;
                CBRestrictivo.Checked = mensaje.IRESTRICTIVO == "S" ? true : false;
                CBSoloAdministradores.Checked = mensaje.ISOLOADMIN == "S" ? true : false;



                //llenar informacion de sucursales
                if (mensaje.IPARATODASSUC != "S" && mensajeSucList != null && mensajeSucList.Count > 0)
                {

                    foreach (CMENSAJESUCBE suc in mensajeSucList)
                    {

                        foreach (DataGridViewRow dataRow in this.sUCURSALDataGridView.Rows)
                        {
                            long sucIdGrid = dataRow.Cells["DGID"].Value != null && dataRow.Cells["DGID"].Value != DBNull.Value ?
                                            (long)dataRow.Cells["DGID"].Value : 0;

                            if (suc.ISUCURSALID == sucIdGrid)
                            {
                                dataRow.Cells["DGENVIAR"].Value = 1;
                                break;
                            }


                        }
                    }
                }


                //llenar informacion de sucursales
                if (mensaje.IPARATODASAREAS != "S" && mensajeAreaList != null && mensajeAreaList.Count > 0)
                {

                    foreach (CMENSAJEAREABE area in mensajeAreaList)
                    {

                        foreach (DataGridViewRow dataRow in this.aREADataGridView.Rows)
                        {
                            long areaIdGrid = dataRow.Cells["DGAREAID"].Value != null && dataRow.Cells["DGAREAID"].Value != DBNull.Value ?
                                            (long)dataRow.Cells["DGAREAID"].Value : 0;

                            if (area.IIDAREA == areaIdGrid)
                            {
                                dataRow.Cells["DGAREAENVIAR"].Value = 1;
                                break;
                            }


                        }
                    }
                }

                if (mensajeAdjuntosList != null && mensajeAdjuntosList.Count > 0)
                {

                    foreach (CMENSAJEADJUNTOSBE adj in mensajeAdjuntosList)
                    {

                        iPos.Mensajeria.DSMensajeria.DatosAdjuntosRow drNew = (iPos.Mensajeria.DSMensajeria.DatosAdjuntosRow)dSMensajeria.DatosAdjuntos.NewRow();

                        drNew.NOMBRE = adj.IRUTAADJUNTO;
                        drNew.RUTA = adj.IRUTAADJUNTO;
                        drNew.NOMBREFTP = adj.IFTPADJUNTO;

                        dSMensajeria.DatosAdjuntos.AddDatosAdjuntosRow(drNew);
                    }
                }



                if (mensajeEstado != null)
                {
                    this.LBLEstadoMensaje.Text += mensajeEstado.INOMBRE;
                }

            }
            catch (Exception ex)
            {


                MessageBox.Show("una excepcion ocurrio " + ex.Message);
            }
            finally
            {
            }





        }


        private void WFCrearMensaje_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSMensajeria.AREA' table. You can move, or remove it, as needed.
            this.aREATableAdapter.Fill(this.dSMensajeria.AREA);
            // TODO: This line of code loads data into the 'dSMensajeria.AREA' table. You can move, or remove it, as needed.
            this.aREATableAdapter.Fill(this.dSMensajeria.AREA);
            // TODO: This line of code loads data into the 'dSMensajeria.SUCURSAL' table. You can move, or remove it, as needed.
            this.sUCURSALTableAdapter.Fill(this.dSMensajeria.SUCURSAL);

            MENSAJENIVELURGENCIATextBox.llenarDatos();


            if (this.opc == "Consultar")
            {
                LlenarDatosDeBase();
                ModoConsulta();
            }
            else
            {
                ModoNuevoMensaje();
            }


            TBAsunto.Focus();
        }

        private void ModoConsulta()
        {

            HabilitarEdicion(false);
            this.Text = "Mensaje";
            this.LBLEstadoMensaje.Visible = true;
            this.LBLFechaEnvio.Visible = true;
        }

        private void ModoNuevoMensaje()
        {

            HabilitarEdicion(true);
            this.LBLEstadoMensaje.Visible = false;
            this.LBLFechaEnvio.Visible = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                iPos.Mensajeria.DSMensajeria.DatosAdjuntosRow drNew = (iPos.Mensajeria.DSMensajeria.DatosAdjuntosRow)dSMensajeria.DatosAdjuntos.NewRow();

                drNew.NOMBRE = openFileDialog1.SafeFileName;
                drNew.RUTA = openFileDialog1.FileName;

                dSMensajeria.DatosAdjuntos.AddDatosAdjuntosRow(drNew);



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

        private void datosAdjuntosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {

                if (datosAdjuntosDataGridView.Columns[e.ColumnIndex].Name == "DGELIMINAR")
                {
                    if (bEsConsulta())
                        return;

                    dSMensajeria.DatosAdjuntos.RemoveDatosAdjuntosRow((iPos.Mensajeria.DSMensajeria.DatosAdjuntosRow)dSMensajeria.DatosAdjuntos.Rows[e.RowIndex]);
                }
                if (datosAdjuntosDataGridView.Columns[e.ColumnIndex].Name == "DGADJUNTONOMBRE")
                {

                    if (!bEsConsulta())
                        return;

                    string nombreArchivo = datosAdjuntosDataGridView.Rows[e.RowIndex].Cells["DGADJUNTONOMBRE"].Value.ToString();
                    string nombreArchivoEnFtp = datosAdjuntosDataGridView.Rows[e.RowIndex].Cells["DGNOMBREFTP"].Value.ToString();
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
        }
    }
}
