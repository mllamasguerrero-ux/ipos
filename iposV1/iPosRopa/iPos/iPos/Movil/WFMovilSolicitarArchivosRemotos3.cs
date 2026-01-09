using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using iPosBusinessEntity;
using iPosData;

using Newtonsoft.Json;

namespace iPos.Movil
{
    public partial class WFMovilSolicitarArchivosRemotos3 : IposForm
    {
        public WFMovilSolicitarArchivosRemotos3()
        {
            InitializeComponent();
        }

        private void btnSolicitarArchivos_Click(object sender, EventArgs e)
        {
            com.server.ipos.Service1 service1 = new com.server.ipos.Service1();
            string strWebService = CurrentUserID.CurrentParameters.IUSARCONEXIONLOCAL.Equals("S") ? (CurrentUserID.CurrentParameters.ILOCALWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.ILOCALWEBSERVICE.Trim()) : (CurrentUserID.CurrentParameters.IWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.IWEBSERVICE.Trim());
            if (strWebService.Trim().Length > 0)
            {
                service1.Url = strWebService.Trim();
            }
            
            string strRespuesta = service1.SolicitarArchivoRemoto(iPos.CurrentUserID.CurrentParameters.IVENDEDORMOVILCLAVE, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), "S",
                                iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                iPos.Tools.FTPManagement.m_strFTPFolderPassWs);


            if (!strRespuesta.Equals("exito"))
            {

                MessageBox.Show(" /No se pudo cerrar el corte de ventas" + strRespuesta);
            }
            else
            {

                MessageBox.Show("La solicitud se envio correctamente ");
            }
        }

        private void btnVerificarSolicitud_Click(object sender, EventArgs e)
        {



            com.server.ipos.Service1 service1 = new com.server.ipos.Service1();
            string strWebService = CurrentUserID.CurrentParameters.IUSARCONEXIONLOCAL.Equals("S") ? (CurrentUserID.CurrentParameters.ILOCALWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.ILOCALWEBSERVICE.Trim()) : (CurrentUserID.CurrentParameters.IWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.IWEBSERVICE.Trim());
            if (strWebService.Trim().Length > 0)
            {
                service1.Url = strWebService.Trim();
            }

            string strRespuesta = service1.GetSolicitudArchivoRemoto(iPos.CurrentUserID.CurrentParameters.IVENDEDORMOVILCLAVE,
                                iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                iPos.Tools.FTPManagement.m_strFTPFolderPassWs);

            if (strRespuesta.Equals(""))
            {

                MessageBox.Show(" No hay registros de la solicitud ");
            }
            else
            {
                try
                {
                    CM_SYNCBE item = JsonConvert.DeserializeObject<CM_SYNCBE>(strRespuesta);

                    if (item != null)
                    {
                        if (item.IESTATUSENVIOSUC > 1)
                            MessageBox.Show("La ruta YA se ha cargado - dia(" + item.IFECHAULTENVIOSUC.ToString("dd/MM/yyyy") + ")");
                        else if (item.IFECHAULTENVIOSUC != null)
                            MessageBox.Show("Aun no se ha recargado - ultimo dia(" + item.IFECHAULTENVIOSUC.ToString("dd/MM/yyyy") + ")");
                        else
                            MessageBox.Show("Ruta aun no enviada");

                    }
                    else
                    {

                        MessageBox.Show("Ruta aun no enviada");
                    }
                }
                catch
                {
                    MessageBox.Show("Mensaje " + strRespuesta);
                }
            }
        }
    }
}
