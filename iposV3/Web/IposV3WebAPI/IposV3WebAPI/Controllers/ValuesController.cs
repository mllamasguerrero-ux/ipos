using Controllers.Controller;
using IposV3.Model;
using IposV3WebAPI.Services;
using IposV3WebAPI.Services.S3;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
//using System.IO;
using System.Threading.Tasks;

namespace IposV3WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly S3Service _s3Service;
        private readonly TestingService _testingService;
        private readonly UnidadController _unidadController;

        private readonly ApplicationDbContext _context;
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public ValuesController(IConfiguration configuration, 
            S3Service s3Service, 
            TestingService testingService,
            UnidadController unidadController,
            ApplicationDbContext context, IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            this._configuration = configuration;
            this._s3Service = s3Service;
            this._testingService = testingService;
            this._context = context;
            this._contextFactory = contextFactory;
            this._unidadController = unidadController;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var environmentName = this._configuration.GetValue<string>("EnvironmentNameExt");
            int test = 0;
            try
            {

                test = this._testingService.TestInPG();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
            return new string[] {"Manuel Llamas", environmentName, test.ToString() };
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> TestW()
        {
            var environmentName = this._configuration.GetValue<string>("EnvironmentNameExt");
            //var test = this._testingService.TestInPG();
            //return Ok(new string[] { "Manuel Llamas", environmentName, test.ToString() });

            //UnidadController uc = new UnidadController(_contextFactory, _context);
            var test2 = this._unidadController.GetAll();
            return Ok(test2);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetTestReplication()
        {
            return Ok();

        }


        //// GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}




        // POST api/values
        [HttpPost("{fileName}/[action]/{filePath}")]
        public async Task<IActionResult> UploadFile(string fileName, string filePath)
        {

            var file = Request.Form.Files[0];
            filePath = System.Net.WebUtility.UrlDecode(filePath);

            await _s3Service.UploadFile(file.OpenReadStream(), fileName, filePath);
            return Ok();

        }



        // GET api/values
        [HttpGet("{empresa}/[action]/{sucursal}/path/{filePath}")]
        public async Task<FileContentResult> DownloadFile(string empresa, string sucursal, string filePath)
        {
            filePath = System.Net.WebUtility.UrlDecode(empresa) + "/" + System.Net.WebUtility.UrlDecode(sucursal) + "/" + System.Net.WebUtility.UrlDecode(filePath);

            try
            {

                var bytes = await _s3Service.GetFileStream(filePath);
                var leng = bytes.Length;
                var fileName = System.IO.Path.GetFileName(filePath);

                return new FileContentResult(bytes, "application/octet-stream")
                {
                    FileDownloadName = fileName
                };

                //return File(fileStream, "application/octet-stream");

                //return new System.IO.File(fileStream, "application/octet-stream", fileName);

                //using (MemoryStream ms = new MemoryStream())
                //{
                //    fileStream.CopyTo(ms);
                //    var bytes = ms.ToArray();
                //    return new FileContentResult(bytes, "application/octet-stream")
                //    {
                //        FileDownloadName = fileName
                //    }; 
                //}


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        // POST api/values
        [HttpGet("{empresa}/[action]/{sucursal}/path/{path}/minDate/{minDate}")]
        public async Task<IActionResult> GetFileList(string empresa, string sucursal, string path, string minDate)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            var minDateDt = DateTime.ParseExact(minDate, "yyyy'-'MM'-'dd'T'HH':'mm':'ss", provider);

            path = System.Net.WebUtility.UrlDecode(empresa) + "/" + System.Net.WebUtility.UrlDecode(sucursal) + "/" + System.Net.WebUtility.UrlDecode(path);
            var lstFiles = await _s3Service.ListFilesInFolder(path, minDateDt);

            return Ok(lstFiles);

        }


        // POST api/values
        [HttpPost("{empresa}/[action]/{sucursal}/filePathFrom/{filePathFrom}/filePathTo/{filePathTo}")]
        public async Task<IActionResult> MoveFiles(string empresa, string sucursal, string filePathFrom, string filePathTo)
        {

            filePathFrom = System.Net.WebUtility.UrlDecode(empresa) + "/" + System.Net.WebUtility.UrlDecode(sucursal) + "/" + System.Net.WebUtility.UrlDecode(filePathFrom);
            filePathTo = System.Net.WebUtility.UrlDecode(empresa) + "/" + System.Net.WebUtility.UrlDecode(sucursal) + "/" + System.Net.WebUtility.UrlDecode(filePathTo);

            await _s3Service.MoveFile(filePathFrom, filePathTo);
            return Ok();

        }




        //https://darchuk.net/2019/05/31/asp-net-core-web-api-returning-a-filestream/
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
