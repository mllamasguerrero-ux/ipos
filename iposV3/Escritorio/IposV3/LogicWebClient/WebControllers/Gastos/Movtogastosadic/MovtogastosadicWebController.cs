
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

    public class MovtogastosadicWebController : BaseWebController<MovtogastosadicBindingModel, MovtogastosadicParam>
    {
        
        public MovtogastosadicWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Movtogastosadic_";
        }



        public override string ContentJsonItem(MovtogastosadicBindingModel item)
        {
            return JsonSerializer.Serialize<MovtogastosadicBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<MovtogastosadicParam >>(new SearchListBindingModel<MovtogastosadicParam>((MovtogastosadicParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<MovtogastosadicParam >>(new SelectParamBindingModel<MovtogastosadicParam>((MovtogastosadicParam)param, search, fieldsSearching));
        }



        public async Task<List<MovtogastosadicBindingModel>?> SelectListByDocto(MovtogastosadicParam param, KendoParams kendoParams)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/SelectListByDocto";

            try
            {


                var contentJson = JsonSerializer.Serialize<Movtogastosadic_SelectListByDocto_ApiParam>(new Movtogastosadic_SelectListByDocto_ApiParam(){
                                        Param = param, KendoParams = kendoParams
                                    });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<List<MovtogastosadicBindingModel>?>();
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


        public async Task<MovtogastosadicWebBindingModel?> InsertMultiFuncional(MovtogastosadicBindingModel item)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/InsertMultiFuncional";

            try
            {


                var contentJson = ContentJsonItem(item);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<MovtogastosadicWebBindingModel>();
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


        public async Task<MovtogastosadicWebBindingModel?> DeleteMultiFuncional(MovtogastosadicBindingModel item)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/DeleteMultiFuncional";

            try
            {


                var contentJson = ContentJsonItem(item);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<MovtogastosadicWebBindingModel>();
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


    }

}



