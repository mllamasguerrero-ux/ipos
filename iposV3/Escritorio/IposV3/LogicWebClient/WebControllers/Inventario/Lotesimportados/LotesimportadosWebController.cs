
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

    public class LotesimportadosWebController : BaseWebController<LotesimportadosBindingModel, LotesimportadosParam>
    {
        
        public LotesimportadosWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Lotesimportados_";
        }



        public override string ContentJsonItem(LotesimportadosBindingModel item)
        {
            return JsonSerializer.Serialize<LotesimportadosBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<LotesimportadosParam >>(new SearchListBindingModel<LotesimportadosParam>((LotesimportadosParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<LotesimportadosParam >>(new SelectParamBindingModel<LotesimportadosParam>((LotesimportadosParam)param, search, fieldsSearching));
        }



        public async Task<LotesimportadosBindingModel?> AddOrReturn(LotesimportadosBindingModel item)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/AddOrReturn";

            try
            {

                var contentJson = JsonSerializer.Serialize<LotesimportadosBindingModel>(item);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<LotesimportadosBindingModel?>();
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



