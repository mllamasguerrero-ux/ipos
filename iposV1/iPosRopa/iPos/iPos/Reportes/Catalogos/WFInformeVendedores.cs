using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPos.Reportes
{
    public partial class WFInformeVendedores : IposForm
    {
        public WFInformeVendedores()
        {
            InitializeComponent();
        }


        private void RecargarReport()
        {

            report1.Load(FastReportsConfig.getPathForFile("InformeVendedores.frx", FastReportsTipoFile.desistema));
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);


            if (report1.Prepare())
                report1.ShowPrepared();
        }

        private void WFInformeVendedores_Load(object sender, EventArgs e)
        {
            RecargarReport();
        }

        private void WFInformeVendedores_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                report1.Delete();
                report1.Dispose();
            }
            catch
            {
            }
        }


    }
}
