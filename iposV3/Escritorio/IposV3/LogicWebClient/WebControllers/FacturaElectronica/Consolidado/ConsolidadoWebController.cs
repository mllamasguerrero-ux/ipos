
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


namespace Controllers.Controller
{

    public class ConsolidadoWebController : BaseGenericWebController
    {
        
        public ConsolidadoWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Consolidado_";
        }



        public async Task<Tmp_info_porconsolidar?> ConsolidadoInfo(Tmp_config_porconsolidarWFBindingModel config)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/ConsolidadoInfo";

            try
            {

                var contentJson = JsonSerializer.Serialize<Tmp_config_porconsolidarWFBindingModel>(config);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<Tmp_info_porconsolidar?>();
                    return apiResponse;
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
    
        public async Task<BaseResultBindingModel?> Consolidar(Tmp_config_porconsolidarWFBindingModel config)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Consolidar";

            try
            {

                var contentJson = JsonSerializer.Serialize<Tmp_config_porconsolidarWFBindingModel>(config);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<BaseResultBindingModel?>();
                    return apiResponse;
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
    
        public async Task TestGeneral2(Int64 usuarioId)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/TestGeneral2";

            try
            {

                var contentJson = JsonSerializer.Serialize<Int64>(usuarioId);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    await response.Content.ReadAsStringAsync();
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
        }
    



  }

}



