
using BindingModels;
using Controllers.Controller;
using IposV3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using ApiParam;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Collections.Generic;
using FastReport.Export.PdfSimple;
using FastReport;
using FastReport.Export.Image;
using FastReport.Export.Html;
using Microsoft.Extensions.Configuration;
using System.Data;
using FastReport.Data;

#pragma warning disable 1998
namespace IposV3WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class Reportes_Controller : Base_Controller<ReportesController, ReportesBindingModel, ReportesParam>
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public IConfiguration Configuration { get; }

        public Reportes_Controller(
            ReportesController logicController, 
            IWebHostEnvironment hostingEnvironment,
            IConfiguration configuration) : base(logicController)
        {
            _hostingEnvironment = hostingEnvironment;
            Configuration = configuration;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GenerateReport([FromBody] FastReportInfo fastReportInfo)
        {
            try
            {


                string mime = "application/" + fastReportInfo.Format; //MIME-header with default value
                                                                      // Find a report
                using (Report reportItem = new Report())
                {
                    if (reportItem != null)
                    {
                        string webRootPath = _hostingEnvironment.ContentRootPath; //Define the path to the wwwroot folder
                        string reportPath = (webRootPath + "/App_Data/" + fastReportInfo.RutaReporte); //Define the path to the report
                                                                                                       //string reportPath = "/app/App_Data/fastreportssistema/RECIBOLARGO.frx";

                        MemoryStream stream = new MemoryStream();                        

                            try
                            {
                                reportItem.Load(reportPath);

                                reportItem.Dictionary.Connections[0].ConnectionString = Configuration.GetConnectionString("DefaultConnection");

                                reportItem.SetParameterValue("US_ID", fastReportInfo.Userid);
                                reportItem.SetParameterValue("US_NAME", fastReportInfo.UserName);

                                if (fastReportInfo.DictionaryReporte != null)
                                {
                                    foreach (KeyValuePair<string, object> entry in fastReportInfo.DictionaryReporte)
                                    {
                                        reportItem.SetParameterValue(entry.Key, entry.Value);
                                    }
                                }


                                if (reportItem.Prepare())
                                {



                                    if (fastReportInfo.Format == "png")
                                    {
                                        ImageExport img = new ImageExport();
                                        img.ImageFormat = ImageExportFormat.Png;
                                        img.SeparateFiles = false;
                                        img.ResolutionX = 96;
                                        img.ResolutionY = 96;
                                        reportItem.Export(img, stream);
                                        mime = "image/" + fastReportInfo.Format; //redefine mime for png

                                    }
                                    else if (fastReportInfo.Format == "html")
                                    {
                                        //report export to HTML
                                        HTMLExport html = new HTMLExport();
                                        html.SinglePage = true; //report on the one page
                                        html.Navigator = false; //navigation panel on top
                                        html.EmbedPictures = true; //build in images to the document
                                        reportItem.Export(html, stream);
                                        mime = "text/" + fastReportInfo.Format; //redefine mime for html
                                    }
                                    else if (fastReportInfo.Format == "pdf")
                                    {
                                        //report export to HTML
                                        PDFSimpleExport pdf = new PDFSimpleExport();
                                        reportItem.Export(pdf, stream);
                                        mime = "application/" + fastReportInfo.Format; //redefine mime for html
                                    }
                                }


                            }
                            catch (Exception e)
                            {
                                return new BadRequestObjectResult(e.Message);
                            }





                            //Get the name of resulting report file with needed extension
                            var file = String.Concat(Path.GetFileNameWithoutExtension(reportPath), ".", fastReportInfo.Format);
                            stream.Seek(0, SeekOrigin.Begin);
                            return new FileStreamResult(stream, mime);
                        

                    }
                    else
                        return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost("[action]")]
        public async Task<IActionResult> GetReportData([FromBody] FastReportInfo fastReportInfo)
        {
            //try
            //{

            //    DSFactura ds = new DSFactura();
            //    var newRow = ds.Tables["Main"]!.NewRow();
            //    newRow["dato1"] = "testX1";
            //    newRow["dato2"] = "testX2";
            //    ds.Tables["Main"]!.Rows.Add(newRow);

            //    Dictionary<string, DataTable> dictTables = new Dictionary<string, DataTable>();
            //    dictTables.Add("Main", ds.Tables["Main"]!);

            //    var strSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(dictTables);

            //    return Ok(strSerialized);
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}




            try
            {


                string mime = "application/" + fastReportInfo.Format; //MIME-header with default value
                                                                      // Find a report
                using (Report reportItem = new Report())
                {
                    if (reportItem != null)
                    {
                        string webRootPath = _hostingEnvironment.ContentRootPath; //Define the path to the wwwroot folder
                        string reportPath = (webRootPath + "/App_Data/" + fastReportInfo.RutaReporte); //Define the path to the report
                                                                                                       //string reportPath = "/app/App_Data/fastreportssistema/RECIBOLARGO.frx";


                        try
                        {
                            reportItem.Load(reportPath);

                            Dictionary<string, DataTable> dictTables = this._logicController.GetDataForReport(reportItem, fastReportInfo);



                            var strSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(dictTables);

                            return Ok(strSerialized);

                        }
                        catch (Exception e)
                        {
                            return new BadRequestObjectResult(e.Message);
                        }


                    }
                    else
                        return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

    }

}



