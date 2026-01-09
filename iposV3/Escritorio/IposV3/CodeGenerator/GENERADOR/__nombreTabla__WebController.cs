|||||100+++++
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
|||||110+++++
    public class (nombreTabla)WebController : BaseWebController<(nombreTabla)BindingModel, (nombreTabla)Param>
    {
        
        public (nombreTabla)WebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "(nombreTabla)_";
        }



        public override string ContentJsonItem((nombreTabla)BindingModel item)
        {
            return JsonSerializer.Serialize<(nombreTabla)BindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<(nombreTabla)Param >>(new SearchListBindingModel<(nombreTabla)Param>(((nombreTabla)Param ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<(nombreTabla)Param >>(new SelectParamBindingModel<(nombreTabla)Param>(((nombreTabla)Param)param, search, fieldsSearching));
        }
    
|||||120+++++
    public class (nombreTabla)WebController : BaseGenericWebController
    {
        
        public (nombreTabla)WebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "(nombreTabla)_";
        }


|||||200+++++
        public async Task<(tipoCampoLenguaje3)?> (nombreCampo)((catalogocampoclave))
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/(nombreCampo)";

            try
            {

                var contentJson = JsonSerializer.Serialize<(catalogoselectobjectname)>((catalogoselectfieldtname));


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<(tipoCampoLenguaje3)?>();
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
    |||||210+++++
        public async Task<(tipoCampoLenguaje3)?> (nombreCampo)((catalogocampoclave))
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/(nombreCampo)";

            try
            {


                var contentJson = JsonSerializer.Serialize<(nombreTabla)_(nombreCampo)_ApiParam>(new (nombreTabla)_(nombreCampo)_ApiParam(){
                                        (catalogolistavmname)
                                    });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<(tipoCampoLenguaje3)?>();
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
    |||||300+++++



  }

}



!!!!!
100;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR
110;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;NO;IGNORAR;IGNORAR
120;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;SI;IGNORAR;IGNORAR
200;1;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;UNPARAMETRO;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR
210;1;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;VARIOSPARAMETROS;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR
300;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR
