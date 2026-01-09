using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPos.Reportes.Ventas
{
    public partial class WFReporteConciliacionEmida : Form
    {
        private string esServicio;

        public WFReporteConciliacionEmida(string esServicio)
        {
            InitializeComponent();
            this.esServicio = esServicio;
        }

        private void btnGenerateConciliacion_Click(object sender, EventArgs e)
        {
            CrearPoliza();
        }

        private void CrearPoliza()
        {
            DateTime fechaInicial = this.dtpBegin.Value.Date;
            DateTime fechaFinal = this.dtpEnd.Value.Date;

            //string folderName = "";
            string pathAndName = "";

            //DialogResult result = this.folderBrowserDialog1.ShowDialog();

            saveFileDialog1.Filter = "Csv (.csv)|*.csv|All Files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.DefaultExt = "csv";
            saveFileDialog1.AddExtension = true;
            int result = (int)this.saveFileDialog1.ShowDialog();


            if (result == (int)System.Windows.Forms.FolderBrowserResult.OK)
            {
               // folderName = this.folderBrowserDialog1.SelectedPath;
                pathAndName = saveFileDialog1.FileName ;
            }
            else
            {
                return;
            }

            //for (DateTime date = fechaInicial; date.Date <= fechaFinal; date = date.AddDays(1))
            //{

            LlenarDatos(fechaInicial, fechaFinal);
            //LlenarDatosHdr(date);

            //string pathAndName = folderName + @"\Poliza" + ".csv";
            //string pathAndName = @"C:\temporal\polizas\test.txt";
            using (StreamWriter sw = new StreamWriter(pathAndName))
            {

                /*if (this.dSContabilidad1.POLIZALINEA_HDR.Rows.Count > 0)
                {
                    iPos.Contabilidad.DSContabilidad.POLIZALINEA_HDRRow drh = (iPos.Contabilidad.DSContabilidad.POLIZALINEA_HDRRow)this.dSContabilidad1.POLIZALINEA_HDR.Rows[0];
                    string strBufferHdr = "P " + date.ToString("yyyyMMdd") + " 1 " + drh.CUENTAEMPRESA + " 1 000 Poliza ventas del dia " + date.ToString("dd/MM/yyyy");
                    sw.WriteLine(strBufferHdr);
                }*/

                sw.WriteLine("Date_Time,Terminal_Id,ResponseTransaction_Id,Invoice_Id,Product_Id,Amount_Id,Account ID,ResponseCode");

                foreach (iPos.Contabilidad.DSContabilidad.REQUESTEMIDACONCILIACIONRow dr in this.dSContabilidad1.REQUESTEMIDACONCILIACION.Rows)
                {

                    decimal dAmount = 0;
                    string strResult = "";
                    try
                    {
                        dAmount = decimal.Parse(dr.AMOUNT);
                    }
                    catch
                    {

                    }

                    try
                    {
                        strResult = int.Parse(dr.RESPONSECODE).ToString();
                    }
                    catch
                    {

                    }



                    string strBuffer = dr.FECHA.ToString("MM/dd/yyyy HH:mm") + "," + dr.TERMINALID + "," + (dr.IsTRANSACTIONIDNull() ? "" : dr.TRANSACTIONID) + "," + dr.INVOICENO + "," + dr.PRODUCTID + "," +
                        dAmount.ToString("#.##") + "," + dr.ACCOUNTID + "," + strResult;
                    sw.WriteLine(strBuffer);
                }


            }
            MessageBox.Show("Se exportaron los archivos de conciliaión");
            // }


        }

        private void LlenarDatos(DateTime fechaini, DateTime fechafin)
        {
            try
            {
                this.rEQUESTEMIDACONCILIACIONTableAdapter.Fill(this.dSContabilidad1.REQUESTEMIDACONCILIACION, fechaini.Date, fechafin.Date.AddDays(1), esServicio);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void WFReporteConciliacionEmida_Load(object sender, EventArgs e)
        {
            if(esServicio.Equals("S"))
            {
                this.Text = "Reporte Conciliacion Servicios Emida";
                label1.Text = "Generar Reporte Conciliación Servicios Emida";
            }
        }



    }
}
