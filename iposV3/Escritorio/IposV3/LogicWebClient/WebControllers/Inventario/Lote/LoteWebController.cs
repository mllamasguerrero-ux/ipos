
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

    public class LoteWebController : BaseGenericWebController
    {
        
        public LoteWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Lote_";
        }



        public async Task<List<V_movto_lote_seleccionWFBindingModel>?> MovtoLoteSeleccion(Int64 empresaId, Int64 sucursalId, Int64 productoId, Int64 almacenId, Int64? doctoId)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/MovtoLoteSeleccion";

            try
            {


                var contentJson = JsonSerializer.Serialize<Lote_MovtoLoteSeleccion_ApiParam>(new Lote_MovtoLoteSeleccion_ApiParam(){
                                        EmpresaId = empresaId, SucursalId = sucursalId, ProductoId = productoId, AlmacenId = almacenId, DoctoId = doctoId
                                    });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<List<V_movto_lote_seleccionWFBindingModel>?>();
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
    
        public async Task<List<V_movto_loteimpo_selWFBindingModel>?> MovtoLoteImportadoSeleccion(Int64 empresaId, Int64 sucursalId, Int64 productoId, Int64 almacenId, Int64? doctoId)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/MovtoLoteImportadoSeleccion";

            try
            {


                var contentJson = JsonSerializer.Serialize<Lote_MovtoLoteImportadoSeleccion_ApiParam>(new Lote_MovtoLoteImportadoSeleccion_ApiParam(){
                                        EmpresaId = empresaId, SucursalId = sucursalId, ProductoId = productoId, AlmacenId = almacenId, DoctoId = doctoId
                                    });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<List<V_movto_loteimpo_selWFBindingModel>?>();
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



