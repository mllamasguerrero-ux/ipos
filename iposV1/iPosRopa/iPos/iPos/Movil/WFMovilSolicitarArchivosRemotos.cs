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

namespace iPos
{
    public partial class WFMovilSolicitarArchivosRemotos : IposForm
    {
        public WFMovilSolicitarArchivosRemotos()
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

            string strRespuesta = service1.SolicitarArchivoRemoto(iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO, CBDIAS.Text, "S",
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

            string strRespuesta = service1.GetSolicitudArchivoRemoto(iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO, 
                                iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                iPos.Tools.FTPManagement.m_strFTPFolderPassWs);

            if (strRespuesta.Equals(""))
            {

                MessageBox.Show(" No hay registros de la solicitud ");
            }
            else
            {
                CM_SYNCBE item = JsonConvert.DeserializeObject<CM_SYNCBE>(strRespuesta);

                if (item != null )
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
        }
    }
}
