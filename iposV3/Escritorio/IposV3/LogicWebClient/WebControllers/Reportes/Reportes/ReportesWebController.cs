
using BindingModels;
using IposV3.Model;
using System;
using IposV3.Extensions;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using ApiParam;
using System.Net.Http.Json;
using System.Data;


namespace Controllers.Controller
{

    public class ReportesWebController : BaseWebController<ReportesBindingModel, ReportesParam>
    {
        
        public ReportesWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Reportes_";
        }



        public override string ContentJsonItem(ReportesBindingModel item)
        {
            return JsonSerializer.Serialize<ReportesBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<ReportesParam >>(new SearchListBindingModel<ReportesParam>((ReportesParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<ReportesParam >>(new SelectParamBindingModel<ReportesParam>((ReportesParam)param, search, fieldsSearching));
        }


        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
        public async Task<string?> GenerateReport(FastReportInfo fastReportInfo)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/GenerateReport";
            string? tempFilePath = null;
            try
            {


                var contentJson = JsonSerializer.Serialize<FastReportInfo>(fastReportInfo);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    using (Stream ms = await response.Content.ReadAsStreamAsync())
                    {
                        tempFilePath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid().ToString() + ".pdf");
                        File.WriteAllBytes(tempFilePath, ReadFully(ms));
                    }

                }
                else
                {
                    string responseText = await response.Content.ReadAsStringAsync();
                    throw new Exception(responseText);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return tempFilePath;
        }



        public async Task<Dictionary<string, DataTable>?> GetReportData(FastReportInfo fastReportInfo)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/GetReportData";
            string? tempFilePath = null;
            try
            {


                var contentJson = JsonSerializer.Serialize<FastReportInfo>(fastReportInfo);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);


                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    //var apiResponse = await response.Content.ReadFromJsonAsync<string>();
                    if (apiResponse != null)
                    {

                        var dictTables = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, DataTable>>(apiResponse);
                        return dictTables;
                    }
                    return null;
                }
                else
                {
                    string responseText = await response.Content.ReadAsStringAsync();
                    throw new Exception(responseText);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


    }

}



