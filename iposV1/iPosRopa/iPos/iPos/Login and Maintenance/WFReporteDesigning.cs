using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPos.Login_and_Maintenance
{
    public partial class WFReporteDesigning : IposForm
    {

        private string m_rutaReporte = "";
        public WFReporteDesigning()
        {
            InitializeComponent();
        }

        public WFReporteDesigning(string rutaReporte)
            : this()
        {
            m_rutaReporte = rutaReporte;
        }

        private void WFReporteDesigning_Load(object sender, EventArgs e)
        {
            try
            {
                report1.Load(m_rutaReporte);
                report1.Designer = this.designerControl1;

                report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
                report1.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
                report1.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);
                this.designerControl1.Report = report1;
            }
            catch
            {
                
            }
        }




    }
}
