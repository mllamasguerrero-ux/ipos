
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

    public class PerfilesWebController : BaseWebController<PerfilesBindingModel, PerfilesParam>
    {
        
        public PerfilesWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Perfiles_";
        }



        public override string ContentJsonItem(PerfilesBindingModel item)
        {
            return JsonSerializer.Serialize<PerfilesBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<PerfilesParam >>(new SearchListBindingModel<PerfilesParam>((PerfilesParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<PerfilesParam >>(new SelectParamBindingModel<PerfilesParam>((PerfilesParam)param, search, fieldsSearching));
        }



        public async Task<List<PerfilDerechoItemBindingModel>?> GetPerfilesDerechos(PerfilesBindingModel itemSelect, KendoParams kendoParams)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/GetPerfilesDerechos";

            try
            {


                var contentJson = JsonSerializer.Serialize<Perfiles_GetPerfilesDerechos_ApiParam>(new Perfiles_GetPerfilesDerechos_ApiParam(){
                                        ItemSelect = itemSelect, KendoParams = kendoParams
                                    });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<List<PerfilDerechoItemBindingModel>?>();
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
    
        public async Task<Boolean?> UpdatePerfilesDerechos(PerfilesBindingModel itemSelect, List<PerfilDerechoItemBindingModel> perfiles_derechos)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/UpdatePerfilesDerechos";

            try
            {


                var contentJson = JsonSerializer.Serialize<Perfiles_UpdatePerfilesDerechos_ApiParam>(new Perfiles_UpdatePerfilesDerechos_ApiParam(){
                                        ItemSelect = itemSelect, Perfiles_derechos = perfiles_derechos
                                    });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<Boolean?>();
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



