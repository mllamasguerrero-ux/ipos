using BindingModels;
using FastReport;
using FastReport.Export.PdfSimple;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IposV3WinForms.FastReport
{
    public partial class ReporteShowing : Form
    {

        //FastReport.Preview.PreviewControl prew = new FastReport.Preview.PreviewControl();
        //PdfViewerControl prew = new PdfViewerControl();

        MemoryStream ms = new MemoryStream();

        public ReporteShowing()
        {
            InitializeComponent();
        }


        public Task HandleAsync(FastReportInfo fastReportInfo, CancellationToken cancellationToken)
        {
            ShowReport(fastReportInfo);
            return Task.CompletedTask;
        }


        public void ShowReport(FastReportInfo fastReportInfo)
        {
            Report report = new Report();
            report.Load(fastReportInfo.RutaReporte);
            //report.Preview = prew;


            //report.Dictionary.Connections[0].ConnectionString = fastReportInfo.ConnectionString;
            report.SetParameterValue("US_ID", fastReportInfo.Userid);
            report.SetParameterValue("US_NAME", fastReportInfo.UserName);

            if (fastReportInfo.DictionaryReporte != null)
            {
                foreach (KeyValuePair<string, object> entry in fastReportInfo.DictionaryReporte)
                {
                    report.SetParameterValue(entry.Key, entry.Value);
                }
            }


            try
            {
                if (report.Prepare())
                {


                    // Export the report to PDF
                    PDFSimpleExport export = new PDFSimpleExport();
                    //using (MemoryStream ms = new MemoryStream())
                    //{
                    report.Export(export, ms);

                    ms.Seek(0, SeekOrigin.Begin);


                    //pdfViewer.RenderingEngine = PdfRenderingEngine.Pdfium;
                    //pdfViewer.ZoomTo(100);
                    pdfViewer.Load(ms);

                    //prew.Load(ms);

                    //HomeGrid.Children.Add(prew);

                    // Create a temporary file with .pdf extension
                    //string tempFilePath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid().ToString() + ".pdf");
                    //File.WriteAllBytes(tempFilePath, ms.ToArray());

                    //pdfViewer.Load(tempFilePath);

                    //// Attempt to open the temporary PDF file with the default application
                    //try
                    //{
                    //    Process.Start(new ProcessStartInfo
                    //    {
                    //        FileName = tempFilePath,
                    //        UseShellExecute = true
                    //    });
                    //}
                    //catch (Exception ex)
                    //{
                    //    MessageBox.Show($"Error opening PDF file: {ex.Message}");
                    //}
                    //}

                    //report.ShowPrepared();
                    //WindowsFormsHost1.Child = prew;
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            ms.Dispose();
        }
    }
}
