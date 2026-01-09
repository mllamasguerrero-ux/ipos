using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BindingModels;
using Caliburn.Micro;
using IposV3.ViewModels;
using System.Threading;

using FastReport;
using FastReport.Export.PdfSimple;
using System.IO;
using Microsoft.Web.WebView2.Core;
using PDFtoPrinter;
//using Syncfusion.Windows.PdfViewer;

namespace IposV3.Views
{
    /// <summary>
    /// Interaction logic for WFReporteShowing.xaml
    /// </summary>
    public partial class ReportePrintingView : UserControl, IHandle<FastReportInfo>, IReportShowReport
    {

        string tempFilePath = ""; 


        public ReportePrintingView()
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
                    using (MemoryStream ms = new MemoryStream())
                    {
                        report.Export(export, ms);

                        ms.Seek(0, SeekOrigin.Begin);


                        // Create a temporary file with .pdf extension
                        tempFilePath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid().ToString() + ".pdf");
                        File.WriteAllBytes(tempFilePath, ms.ToArray());

                        var wrapper = new PDFtoPrinterPrinter();

                        //Print from file
                        wrapper
                            .Print(new PrintingOptions("Two Pilots Demo Printer", tempFilePath))
                            .Wait();
                       
                        


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            //ms.Dispose();
            try
            {
                if (!string.IsNullOrEmpty(tempFilePath))
                    File.Delete(tempFilePath);
            }
            catch
            {

            }
        }

    }
}
