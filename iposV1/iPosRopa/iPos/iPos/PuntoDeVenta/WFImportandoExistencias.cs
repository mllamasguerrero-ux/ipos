using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataLayer.Importaciones;
using System.Collections;
using iPosData;

namespace iPos
{
    public partial class WFImportandoExistencias : IposForm
    {
        string m_ProductoClave;


        public WFImportandoExistencias()
        {
            InitializeComponent();
        }
        public WFImportandoExistencias(string productoClave)
        {
            InitializeComponent();
            prBrExistencias.Style = ProgressBarStyle.Marquee;

            m_ProductoClave = productoClave;

            this.bgWorkExistencias.RunWorkerAsync();
        }

        private void bgWorkExistencias_DoWork(object sender, DoWorkEventArgs e)
        {

            //ImportarDBF iDBF = new ImportarDBF();
            //if (!iDBF.ImportarArchivosExistencias(CIMP_FILESD.FileType_ExistenciasGen, CurrentUserID.CurrentParameters, CurrentUserID.CurrentUser))
            //{
            //    MessageBox.Show(iDBF.IComentario);
            //}

            bool bVerExistenciasTodos = false;
            bool bVerExistenciasMatriz = false;
            CUSUARIOSD usersD = new CUSUARIOSD();
            if (usersD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_VEREXISTENCIAS_TODOS, null))
            {
                bVerExistenciasTodos = true;
            }

            if (usersD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_VEREXISTENCIAS_MATRIZ, null))
            {
                bVerExistenciasMatriz = true;
            }

            WebServiceIpos wsIpos = new WebServiceIpos();
            wsIpos.LeerExistencias( m_ProductoClave, bVerExistenciasTodos, bVerExistenciasMatriz);
        }

        private void bgWorkExistencias_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            this.Close();
        }
    }
}
