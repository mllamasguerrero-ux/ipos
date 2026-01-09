using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPos.Movil
{
    public partial class WFMovilReportes : IposForm
    {
        public WFMovilReportes()
        {
            InitializeComponent();
        }

        private void RecargarReport()
        {

            report1.Load(FastReportsConfig.getPathForFile("InformeMovilPagosSumarizado.frx", FastReportsTipoFile.desistema));
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);


            report2.Load(FastReportsConfig.getPathForFile("InformeMovilCobranza.frx", FastReportsTipoFile.desistema));
            report2.Preview = this.previewControl2;
            report2.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report2.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
            report2.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);
        }

        private void WFMovilReportes_Load(object sender, EventArgs e)
        {

            RecargarReport();

            if (report1.Prepare())
                report1.ShowPrepared();


            if (report2.Prepare())
                report2.ShowPrepared();
        }

    }
}
