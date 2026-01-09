
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
using IposV3.Services;


namespace Controllers.Controller
{

    public class MovtoWebController : BaseWebController<MovtoBindingModel, MovtoParam>
    {
        
        public MovtoWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Movto_";
        }



        public override string ContentJsonItem(MovtoBindingModel item)
        {
            return JsonSerializer.Serialize<MovtoBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<MovtoParam >>(new SearchListBindingModel<MovtoParam>((MovtoParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<MovtoParam >>(new SelectParamBindingModel<MovtoParam>((MovtoParam)param, search, fieldsSearching));
        }



        public async Task<Movto_command_deciphered?> DecipherCommand(Int64 empresaId, Int64 sucursalId, String commandText)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/DecipherCommand";

            try
            {


                var contentJson = JsonSerializer.Serialize<Movto_DecipherCommand_ApiParam>(new Movto_DecipherCommand_ApiParam(){
                                        EmpresaId = empresaId, SucursalId = sucursalId, CommandText = commandText
                                    });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<Movto_command_deciphered?>();
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



