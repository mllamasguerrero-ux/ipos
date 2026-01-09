using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using iPosData;
using iPosBusinessEntity;

namespace iPosReporting
{
    public partial class WFReportingShowing : Form
    {

        private string m_rutaReporte = "";
        
        Dictionary<string, object> m_dictionary =
        new Dictionary<string, object>();

        public WFReportingShowing()
        {
            InitializeComponent();
        }
        public WFReportingShowing(string rutaReporte) : this()
        {
            m_rutaReporte = rutaReporte;
        }

        public WFReportingShowing(string rutaReporte, Dictionary<string, object> dictionary)
            : this(rutaReporte)
        {
            m_dictionary = dictionary;
        }


        public static string getPathForFile(string strFile, string tipo)
        {
            CPARAMETROD parametro = new CPARAMETROD();
            CPARAMETROBE parametroBE = parametro.seleccionarPARAMETROActual(null);
            if (parametroBE == null)
            {
                return "";
            }
            


            if (parametroBE.IRUTAREPORTESSISTEMA != null && parametroBE.IRUTAREPORTESSISTEMA.Trim().Length > 0)
            {
                switch (tipo)
                {
                    case "desistema":
                        if (File.Exists(parametroBE.IRUTAREPORTESSISTEMA + "//repocustomized//fastreportssistema//" + strFile))
                            return parametroBE.IRUTAREPORTESSISTEMA + "//repocustomized//fastreportssistema//" + strFile;
                        if (File.Exists(parametroBE.IRUTAREPORTESSISTEMA + "//fastreportssistema//" + strFile))
                            return parametroBE.IRUTAREPORTESSISTEMA + "//fastreportssistema//" + strFile;
                        break;

                    case "deusuario":
                        if (File.Exists(parametroBE.IRUTAREPORTESSISTEMA + "//repocustomized//fastreports//" + strFile))
                            return parametroBE.IRUTAREPORTESSISTEMA + "//repocustomized//fastreports//" + strFile;
                        if (File.Exists(parametroBE.IRUTAREPORTESSISTEMA + "//fastreports//" + strFile))
                            return parametroBE.IRUTAREPORTESSISTEMA + "//fastreports//" + strFile;
                        break;
                }
            }

            switch (tipo)
            {
                case "desistema":
                    if (File.Exists(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "//sampdata//repocustomized//fastreportssistema//" + strFile))
                        return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "//sampdata//repocustomized//fastreportssistema//" + strFile;
                    else
                        return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "//sampdata//fastreportssistema//" + strFile;

                case "deusuario":
                    if (File.Exists(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "//sampdata//repocustomized//fastreports//" + strFile))
                        return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "//sampdata//repocustomized//fastreports//" + strFile;
                    else
                        return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "//sampdata//fastreports//" + strFile;
            }

            return "";

        }

        private void WFReportingShowing_Load(object sender, EventArgs e)
        {


            report1.Load(m_rutaReporte);
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", ConexionesBD.ConexionBD.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", ConexionesBD.ConexionBD.CurrentUser.IID);


            foreach (KeyValuePair<string, object> entry in this.m_dictionary)
            {
                report1.SetParameterValue(entry.Key, entry.Value);
            }

            if (report1.Prepare())
                report1.ShowPrepared();



        }
    }
}
