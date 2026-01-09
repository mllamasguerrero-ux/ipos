
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

    public class GuiaWebController : BaseWebController<GuiaBindingModel, GuiaParam>
    {
        
        public GuiaWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Guia_";
        }



        public override string ContentJsonItem(GuiaBindingModel item)
        {
            return JsonSerializer.Serialize<GuiaBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<GuiaParam >>(new SearchListBindingModel<GuiaParam>((GuiaParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<GuiaParam >>(new SelectParamBindingModel<GuiaParam>((GuiaParam)param, search, fieldsSearching));
        }



        public async Task<BaseResultBindingModel?> InsertHeaderAndDetail(GuiaBindingModel item, GuiadetalleBindingModel guiaDetalle, DoctoBindingModel docto)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/InsertHeaderAndDetail";

            try
            {


                var contentJson = JsonSerializer.Serialize<Guia_InsertHeaderAndDetail_ApiParam>(new Guia_InsertHeaderAndDetail_ApiParam(){
                                        Item = item, GuiaDetalle = guiaDetalle, Docto = docto
                                    });


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
    



  }

}



