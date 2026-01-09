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
    public partial class WFReportSending : IposForm
    {

        private string m_rutaReporte = "";
        private string m_mailEnvio = "";

        Dictionary<string, object> m_dictionary =
        new Dictionary<string, object>();

        private string m_formato = "CSV";
        private string m_asunto = "Inventario ";
        private string m_body = "";

        public bool m_silentMode = false;

        public WFReportSending()
        {
            InitializeComponent();
        }
        public WFReportSending(string rutaReporte) : this()
        {
            m_rutaReporte = rutaReporte;
        }
        public WFReportSending(string rutaReporte, String mailEnvio)
            : this(rutaReporte)
        {
            m_mailEnvio = mailEnvio;
        }

        public WFReportSending(string rutaReporte, String mailEnvio, Dictionary<string, object> dictionary)
            : this(rutaReporte, mailEnvio)
        {
            m_dictionary = dictionary;
        }


        public WFReportSending(string rutaReporte, String mailEnvio, Dictionary<string, object> dictionary, string asunto, string formato)
            : this(rutaReporte, mailEnvio,dictionary)
        {
            m_asunto = asunto;
            m_formato = formato;
        }



        public WFReportSending(string rutaReporte, String mailEnvio, Dictionary<string, object> dictionary, string asunto, string formato, string body)
            : this(rutaReporte, mailEnvio, dictionary, asunto, formato)
        {
            m_body = body;
        }



        private void WFReportSending_Load(object sender, EventArgs e)
        {
            try
            {

                report1.Load(m_rutaReporte);
                report1.Preview = this.previewControl1;
                report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;

                foreach (KeyValuePair<string, object> entry in this.m_dictionary)
                {
                    report1.SetParameterValue(entry.Key, entry.Value);
                }
                

                if (report1.Prepare())
                    report1.ShowPrepared();

                FastReport.Export.Csv.CSVExport csvExport = null ;
                csvExport  = new FastReport.Export.Csv.CSVExport();

                FastReport.Export.Pdf.PDFExport pdfExport = null;
                pdfExport = new FastReport.Export.Pdf.PDFExport();

                
                FastReport.Export.OoXML.Excel2007Export xlsExport = null;
                xlsExport = new FastReport.Export.OoXML.Excel2007Export();


                FastReport.Export.Email.EmailExport export = new FastReport.Export.Email.EmailExport();

                // set up Account properties...

                export.Account.Host = CurrentUserID.CurrentParameters.ISMTPHOST;
                export.Account.Address = CurrentUserID.CurrentParameters.ISMTPMAILFROM;
                export.Account.Port = CurrentUserID.CurrentParameters.ISMTPPORT;
                export.Account.UserName = CurrentUserID.CurrentParameters.ISMTPUSUARIO;
                export.Account.Password = CurrentUserID.CurrentParameters.ISMTPPASSWORD;
                export.Account.EnableSSL = true;


                // set up email properties...
                export.Address = m_mailEnvio == "" ? CurrentUserID.CurrentParameters.IMAILTOINVENTARIO : m_mailEnvio;
                export.Subject = m_body == "" ? "Exportacion de informacion" : m_asunto;
                export.MessageBody = m_body == "" ? "Exportacion de informacion" : m_asunto;

                if(export.Address.Contains(","))
                {
                    export.CC = export.Address.Split(',');
                }

                // send email
                if (this.m_formato == "CSV")
                    export.Export = csvExport;
                else if (this.m_formato == "XLS")
                    export.Export = xlsExport;
                else
                    export.Export = pdfExport;


                export.SendEmail(report1);

                this.Close();
            }
            catch(Exception ex)
            {
                if (!m_silentMode)
                    MessageBox.Show(ex.Message);
                else
                    this.Close();
            }

            

        }
    }
}
