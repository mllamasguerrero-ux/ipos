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
using System.Data;
//using Syncfusion.Windows.PdfViewer;

namespace IposV3.Views
{
    /// <summary>
    /// Interaction logic for WFReporteFrxShowing.xaml
    /// </summary>
    public partial class ReporteFrxShowingView : UserControl, IHandle<FastReportInfo>, IReportShowReport
    {

        //FastReport.Preview.PreviewControl prew = new FastReport.Preview.PreviewControl();
        //PdfViewerControl prew = new PdfViewerControl();

        //MemoryStream ms = new MemoryStream();
        string tempFilePath = ""; 


        public ReporteFrxShowingView()
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



            


            if (fastReportInfo.DictionaryTables != null)
            {
                foreach (KeyValuePair<string, DataTable> entry in fastReportInfo.DictionaryTables)
                {
                    report.RegisterData(entry.Value, entry.Key);
                }
            }

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

                        
                        //pdfViewer.RenderingEngine = PdfRenderingEngine.SfPdf;
                        //pdfViewer.ZoomTo(100);
                        //pdfViewer.Load(ms);

                        //prew.Load(ms);

                        //HomeGrid.Children.Add(prew);

                        // Create a temporary file with .pdf extension
                        tempFilePath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid().ToString() + ".pdf");
                        File.WriteAllBytes(tempFilePath, ms.ToArray());

                        pdfViewer.Source = new System.Uri(tempFilePath);



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

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //void PrintToPrinter()
        //{
        //    string printerName = GetPrinterName();
        //    CoreWebView2PrintSettings printSettings = GetSelectedPrinterPrintSettings(printerName);
        //    string title = pdfViewer.CoreWebView2.DocumentTitle;
        //    try
        //    {
        //        //CoreWebView2PrintStatus printStatus =  pdfViewer.CoreWebView2.PrintAsync(printSettings);
        //        var task = Task.Run(async () => await pdfViewer.CoreWebView2.PrintAsync(printSettings));
        //        //var result = task.WaitAndUnwrapException();
        //        CoreWebView2PrintStatus printStatus = task.GetAwaiter().GetResult();

        //        if (printStatus == CoreWebView2PrintStatus.Succeeded)
        //        {
        //            MessageBox.Show("Printing " + title + " document to printer succeeded", "Print to printer");
        //        }
        //        else if (printStatus == CoreWebView2PrintStatus.PrinterUnavailable)
        //        {
        //            MessageBox.Show("Selected printer is not found, not available, offline or error state", "Print to printer");
        //        }
        //        else
        //        {
        //            MessageBox.Show("Printing " + title + " document to printer is failed", "Print");
        //        }
        //    }
        //    catch (ArgumentException)
        //    {
        //        MessageBox.Show("Invalid settings provided for the specified printer", "Print");
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("Printing " + title + " document already in progress", "Print");
        //    }
        //}

        //// Gets the printer name by displaying the list of installed printers to the user and
        //// returns the name of the user's selected printer.
        //string GetPrinterName()
        //{
        //    // Use GetPrintQueues() of LocalPrintServer from System.Printing to get the list of locally installed printers.
        //    // Display the list of printers to the user and get the desired printer to use.
        //    // Return the name of the selected printer.

        //    return "Two Pilots Demo Printer";
        //}

        //// Gets the print settings for the selected printer.
        //// You can also get the capabilities from the native printer API, and display them 
        //// to the user to get the print settings for the current webpage and for the selected printer.
        //CoreWebView2PrintSettings GetSelectedPrinterPrintSettings(string printerName)
        //{
        //    CoreWebView2PrintSettings printSettings = null;
        //    printSettings = pdfViewer.CoreWebView2.Environment.CreatePrintSettings();
        //    printSettings.ShouldPrintBackgrounds = true;
        //    printSettings.ShouldPrintHeaderAndFooter = true;

        //    return printSettings;

        //    // or
        //    // Get PrintQueue for the selected printer and use GetPrintCapabilities() of PrintQueue from System.Printing
        //    // to get the capabilities of the selected printer.
        //    // Display the printer capabilities to the user along with the page settings.
        //    // Return the user selected settings.
        //}

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
