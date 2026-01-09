using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using System.Runtime.InteropServices;

using Microsoft.Reporting.WinForms;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Threading;

using System.Xml;
using System.IO;
using iPosData;
using iPosBusinessEntity;

using System.Security;
using System.Security.Permissions;

using System.Net.Mail;
using System.Net.Mime;

namespace iPos.Cortes
{
    public partial class CorteXMailTest : IposForm
    {

        long m_corteId = 0;
        CPARAMETROBE m_empresa;

        public CorteXMailTest()
        {
            InitializeComponent();
        }


        public CorteXMailTest(long corteId, CPARAMETROBE empresa)
            : this()
        {
            this.m_corteId = corteId;
            this.m_empresa = empresa;
        }

        private void EnvioMailTicket(long corteId)
        {

            //string bufferLine;
            int? iCorteId = (int)corteId;

             this.corteTicketB2TableAdapter.Fill(this.dSCortesB.CorteTicketB2, corteId);
            /* this.corteTrasladosTableAdapter.Fill(this.dSCortesB.CorteTraslados, corteId);
             this.cORTE_CALCULO_DETALLETableAdapter.Fill(this.dSCortesB.CORTE_CALCULO_DETALLE, iCorteId);

             this.reportViewer1.RefreshReport();



             Warning[] warnings;
             string[] streamIds;
             string mimeType = string.Empty;
             string encoding = string.Empty;
             string extension = string.Empty;
             string fileName = System.AppDomain.CurrentDomain.BaseDirectory + "//sampdata//cortes//" + corteId.ToString() + ".pdf";

             CultureInfo ci = Thread.CurrentThread.CurrentCulture;
             byte[] bytes = this.reportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
             Thread.CurrentThread.CurrentCulture = ci;

             //// Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
             FileStream fs = new FileStream(fileName,
            FileMode.Create);
             fs.Write(bytes, 0, bytes.Length);
             fs.Close();

             reportViewer1.Clear();
             reportViewer1.Dispose();
             GC.SuppressFinalize(reportViewer1);
             GC.SuppressFinalize(fs);
             corteTrasladosBindingSource = null;
             cORTE_CALCULO_DETALLEBindingSource = null;
             corteTicketB2BindingSource = null;
             reportViewer1 = null;


             DateTime fechacorte = (DateTime)this.dSCortesB.CorteTicketB2[0]["FECHACORTE"];
             string subject = "CORTE DE : " +  this.dSCortesB.CorteTicketB2[0]["CAJERO"].ToString() + " FECHA : " + fechacorte.ToString("dd/MM/yyyy");
             //MessageBox.Show("se intentara enviar");
             if (EnviarMail(m_empresa.ISMTPHOST, m_empresa.ISMTPMAILFROM, m_empresa.ISMTPMAILTO,  subject , subject, m_empresa.ISMTPPORT, m_empresa.ISMTPSSL.Equals("S"), m_empresa.ISMTPUSUARIO, m_empresa.ISMTPPASSWORD, fileName))
             {
                 MessageBox.Show("El email se ha enviado");
             }*/


            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("corteId", corteId);

            string strReporte =  "CorteSumarizadoPorCajero.frx";

            DateTime fechacorte = (DateTime)this.dSCortesB.CorteTicketB2[0]["FECHACORTE"];
            string stSubject = "CORTE DE : " + this.dSCortesB.CorteTicketB2[0]["CAJERO"].ToString() + " FECHA : " + fechacorte.ToString("dd/MM/yyyy");
            


            List<string> emailsToSend = new List<string>();
            if(m_empresa.ISMTPMAILTO != null && m_empresa.ISMTPMAILTO.Length > 0)
                emailsToSend.Add(m_empresa.ISMTPMAILTO.ToLower().Trim());

            CUSUARIOSD usuariosD = new CUSUARIOSD();
            DataSet dsUsuarios = usuariosD.enlistarUSUARIOSVENDEDORESCONDERECHO(DBValues._DERECHO_RECIBIREMAILCORTE);
            if (dsUsuarios != null && dsUsuarios.Tables[0] != null &&
                dsUsuarios.Tables[0].Rows != null && dsUsuarios.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsUsuarios.Tables[0].Rows)
                {

                    string email = dr["EMAIL"] == DBNull.Value || dr["EMAIL"].ToString().Trim().Length == 1 ? null : dr["EMAIL"].ToString();
                    if(email != null && email.Trim().Length > 0 && !emailsToSend.Contains(email.ToLower().Trim()))
                    {
                        emailsToSend.Add(email.ToLower().Trim());
                    }
                }
            }

            if(emailsToSend.Count > 0)
            {
                string strEmailTo = string.Join(",", emailsToSend);

                iPos.Login_and_Maintenance.WFReportSending rp = new Login_and_Maintenance.WFReportSending(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), strEmailTo, dictionary, stSubject, "PDF");
                rp.ShowDialog();
                rp.Dispose();
                GC.SuppressFinalize(rp);
            }


            this.Close();


        }


        /*
        public static bool EnviarMail(
         string p_smtpServer,
         string p_mailFrom,
         string p_mailTo,
         string p_mailSubject,
         string p_body,
         int p_smtpPort,
         bool p_EnableSsl,
         string p_smtpuser,
         string p_smtpPass,
         string p_strArchivo
         )
        {
            bool retorno = true;
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(p_smtpServer);

                mail.From = new MailAddress(p_mailFrom);
                mail.To.Add(p_mailTo);
                mail.Subject = p_mailSubject;
                mail.Body = p_body;
                SmtpServer.Port = p_smtpPort;
                SmtpServer.Credentials = new System.Net.NetworkCredential(p_smtpuser, p_smtpPass);
                SmtpServer.EnableSsl = p_EnableSsl;


                // Create  the file attachment for this e-mail message.
                Attachment data = new Attachment(p_strArchivo, MediaTypeNames.Application.Octet);
                // Add time stamp information for the file.
                ContentDisposition disposition = data.ContentDisposition;
                disposition.CreationDate = System.IO.File.GetCreationTime(p_strArchivo);
                disposition.ModificationDate = System.IO.File.GetLastWriteTime(p_strArchivo);
                disposition.ReadDate = System.IO.File.GetLastAccessTime(p_strArchivo);
                // Add the file attachment to this e-mail message.
                mail.Attachments.Add(data);




                SmtpServer.Send(mail);
                data.Dispose();
                //MessageBox.Show("mail Send");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                retorno = false;
            }
            return retorno;
        }*/

        private void CorteXMailTest_Load(object sender, EventArgs e)
        {

           EnvioMailTicket(m_corteId);
        }



    }
}
