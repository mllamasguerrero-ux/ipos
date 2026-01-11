using FastReport.Export.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPos.Login_and_Maintenance
{
    public partial class WFReporteShowing : IposForm
    {

        private string m_rutaReporte = "";
        
        Dictionary<string, object> m_dictionary =
        new Dictionary<string, object>();

        public WFReporteShowing()
        {
            InitializeComponent();
        }
        public WFReporteShowing(string rutaReporte) : this()
        {
            m_rutaReporte = rutaReporte;
        }

        public WFReporteShowing(string rutaReporte, Dictionary<string, object> dictionary)
            : this(rutaReporte)
        {
            m_dictionary = dictionary;
        }

        private void WFReporteShowing_Load(object sender, EventArgs e)
        {


            report1.Load(m_rutaReporte);
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);


            foreach (KeyValuePair<string, object> entry in this.m_dictionary)
            {
                report1.SetParameterValue(entry.Key, entry.Value);
            }


            try
            {
                if (report1.Prepare())
                    report1.ShowPrepared();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }







        }
    }
}
