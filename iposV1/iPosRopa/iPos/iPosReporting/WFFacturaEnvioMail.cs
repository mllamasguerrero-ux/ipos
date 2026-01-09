

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Data;
using System.Net.Mime;
using System.IO;
using iPosBusinessEntity;
using iPosData;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace iPosReporting
{
    public partial class WFFacturaEnvioMail : Form
    {

        string m_smtpServer;
         string m_mailFrom;
         string m_mailSubject;
         string m_body;
         int m_smtpPort;
         bool m_EnableSsl;
         string m_smtpuser;
         string m_smtpPass;
         string m_strArchivo;
         string m_strArchivo2;

         CPERSONABE m_clienteBE = null;

         public bool m_silentMode = false;


        public WFFacturaEnvioMail()
        {
            InitializeComponent();
        }


        public WFFacturaEnvioMail(string smtpServer,
                                  string mailFrom,
                                  string mailSubject,
                                  string body,
                                  int smtpPort,
                                  bool EnableSsl,
                                  string smtpuser,
                                  string smtpPass,
                                  string strArchivo,
                                  string strArchivo2,
                                    string mailTo,
                                CPERSONABE clienteBE)
        {
            InitializeComponent();
            m_smtpServer = smtpServer;
            m_mailFrom = mailFrom;
            m_mailSubject = mailSubject;
            m_body = body;
            m_smtpPort = smtpPort;
            m_EnableSsl = EnableSsl;
            m_smtpuser = smtpuser;
            m_smtpPass = smtpPass;
            m_strArchivo = strArchivo;
            m_strArchivo2 = strArchivo2;

            TBMail.Text = mailTo;

            m_clienteBE = clienteBE;
        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {

            string mailTo = TBMail.Text;

            if (RBCombo.Checked)
            {
                if (CBTodaListaCombo.Checked)
                {
                    mailTo = "";
                    int ix = 0;
                    foreach (string item in CBMailTo.Items)
                    {
                        mailTo = mailTo + (ix == 0 ? "" : ",") + item;
                        ix++;
                    }
                }
                else if (CBMailTo.SelectedIndex >= 0)
                {
                    mailTo = CBMailTo.SelectedItem.ToString();
                }
                else
                {
                    MessageBox.Show("Seleccione un email de la lista");
                }
            }


            if (EnviarMail(m_smtpServer, m_mailFrom, mailTo, m_mailSubject, TBBody.Text, m_smtpPort, m_EnableSsl, m_smtpuser, m_smtpPass, m_strArchivo, m_strArchivo2))
            {
                if (!m_silentMode)
                {
                    MessageBox.Show("El email se ha enviado");
                }
                this.Close();
            }

            if (m_silentMode)
                this.Close();
        }

        static bool ValidateCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }

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
         string p_strArchivo,
         string p_strArchivo2
         )
        {
            bool retorno = true;
            RemoteCertificateValidationCallback backDel = ServicePointManager.ServerCertificateValidationCallback;
                
            try
            {


                ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateCertificate);



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


                // Create  the file attachment for this e-mail message.
                Attachment data2 = new Attachment(p_strArchivo2, MediaTypeNames.Application.Octet);
                // Add time stamp information for the file.
                ContentDisposition disposition2 = data2.ContentDisposition;
                disposition2.CreationDate = System.IO.File.GetCreationTime(p_strArchivo2);
                disposition2.ModificationDate = System.IO.File.GetLastWriteTime(p_strArchivo2);
                disposition2.ReadDate = System.IO.File.GetLastAccessTime(p_strArchivo2);
                // Add the file attachment to this e-mail message.
                mail.Attachments.Add(data2);

                
                SmtpServer.Send(mail);
                data.Dispose();

                ServicePointManager.ServerCertificateValidationCallback = backDel;

                //MessageBox.Show("mail Send");
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                ServicePointManager.ServerCertificateValidationCallback = backDel;
                retorno = false;
            }
            return retorno;
        }

        private void BtnNoEnviar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void WFFacturaEnvioMail_Load(object sender, EventArgs e)
        {
            try
            {
                if (m_clienteBE != null)
                {
                    if ((!(bool)m_clienteBE.isnull["IEMAIL1"]) && (m_clienteBE.IEMAIL1.Length > 0))
                        CBMailTo.Items.Add(m_clienteBE.IEMAIL1);

                    if ((!(bool)m_clienteBE.isnull["IEMAIL2"]) && (m_clienteBE.IEMAIL2.Length > 0))
                        CBMailTo.Items.Add(m_clienteBE.IEMAIL2);

                    if ((!(bool)m_clienteBE.isnull["IEMAIL3"]) && (m_clienteBE.IEMAIL3.Length > 0))
                        CBMailTo.Items.Add(m_clienteBE.IEMAIL3);

                    if ((!(bool)m_clienteBE.isnull["IEMAIL4"]) && (m_clienteBE.IEMAIL4.Length > 0))
                        CBMailTo.Items.Add(m_clienteBE.IEMAIL4);
                }
                EnableDisableOptions();

                if (m_silentMode)
                {
                    this.BtnEnviar_Click(null, null);
                }
                else
                {
                    System.Diagnostics.Process.Start(m_strArchivo);
                }

                TBBody.Text = m_body;
            }
            catch
            {
                this.Close();
            }
        }

        private void RBTexto_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableOptions();
        }

        void EnableDisableOptions()
        {
            if (RBTexto.Checked)
            {
                TBMail.Enabled = true;
                CBMailTo.Enabled = false;
                CBTodaListaCombo.Enabled = false;
            }
            else
            {
                TBMail.Enabled = false;
                CBMailTo.Enabled = true;
                CBTodaListaCombo.Enabled = true;
            }
        }

        private void RBCombo_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableOptions();
        }

    }
}
