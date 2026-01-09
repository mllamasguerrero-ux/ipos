using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iPosBusinessEntity;
using iPosData;

namespace iPos
{
    public partial class WFReporteMovClientes : IposForm
    {

        public int TIPODOCTOID;
        public DateTime FECHAINI;
        public DateTime FECHAFIN;
        public int PERSONAID;
        public string ESFACTURA;
        public string CONSALDO;


        public string strTIPODOCTOID = "";
        public string strFECHAINI = "";
        public string strFECHAFIN = "";
        public string strPERSONAID = "";
        public string strESFACTURA = "";
        public string strCONSALDO = "";

        public WFReporteMovClientes()
        {
            InitializeComponent();
        }

        public WFReporteMovClientes(
         int P_TIPODOCTOID,
         DateTime P_FECHAINI,
         DateTime P_FECHAFIN,
         int P_PERSONAID,
         string P_ESFACTURA,
         string P_CONSALDO,
         string P_strTIPODOCTOID,
         string P_strPERSONAID)
            : this()
        {

            TIPODOCTOID = P_TIPODOCTOID;
            FECHAINI = P_FECHAINI;
            FECHAFIN = P_FECHAFIN;
            PERSONAID = P_PERSONAID;
            ESFACTURA = P_ESFACTURA;
            CONSALDO = P_CONSALDO;
            strTIPODOCTOID = P_strTIPODOCTOID;
            strPERSONAID = P_strPERSONAID;
        }


        private void WFReporteMovClientes_Load(object sender, EventArgs e)
        {

            RefreshReport();
        }


        private void RefreshReport()
        {
            if (ESFACTURA != null)
            {
                switch (ESFACTURA)
                {
                    case "S": strESFACTURA = "Mostrando Facturas"; break;
                    case "N": strESFACTURA = "Mostrando Remisiones"; break;
                    case "T":
                    default:
                        strESFACTURA = "Mostrando Todas"; break;

                }
            }

            if (CONSALDO != null)
            {
                switch (CONSALDO)
                {
                    case "S": strCONSALDO = "SI"; break;
                    default:
                        strCONSALDO = "NO"; break;

                }
            }

            if(FECHAINI != null)
            {
                strFECHAINI = FECHAINI.ToString("dd/MM/yyyy");
            }

            if (FECHAFIN != null)
            {
                strFECHAFIN = FECHAFIN.ToString("dd/MM/yyyy");
            }
            

           


            Microsoft.Reporting.WinForms.ReportParameter[] Param = new Microsoft.Reporting.WinForms.ReportParameter[6];

            Param[0] = new Microsoft.Reporting.WinForms.ReportParameter("tipoderegistro", strTIPODOCTOID);
            Param[1] = new Microsoft.Reporting.WinForms.ReportParameter("fechainicio", strFECHAINI);
            Param[2] = new Microsoft.Reporting.WinForms.ReportParameter("fechafin", strFECHAFIN);
            Param[3] = new Microsoft.Reporting.WinForms.ReportParameter("nombrecliente", strPERSONAID);
            Param[4] = new Microsoft.Reporting.WinForms.ReportParameter("consaldo", strCONSALDO);
            Param[5] = new Microsoft.Reporting.WinForms.ReportParameter("esfactura", strESFACTURA);
            
            
            this.reportViewer1.LocalReport.SetParameters(Param);

            LoadDataSource();
            this.reportViewer1.RefreshReport();
        }

        private void LoadDataSource()
        {
            try
            {
                this.mOVIMIENTOSTableAdapter.Fill(this.dSFastReports.MOVIMIENTOS, "N",
                                                    TIPODOCTOID,
                                                    FECHAINI,
                                                    FECHAFIN,
                                                    PERSONAID,
                                                    ESFACTURA,
                                                    CONSALDO);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }


    }
}
