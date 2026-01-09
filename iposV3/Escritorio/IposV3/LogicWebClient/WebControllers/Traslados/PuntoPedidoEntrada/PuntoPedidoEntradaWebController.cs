
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

    public class PuntoPedidoEntradaWebController : BaseGenericWebController
    {

        public PuntoPedidoEntradaWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "PuntoPedidoEntrada_";
        }



        public async Task<List<Docto_pedido_entradaWFBindingModel>?> Select_docto_pedido_entrada_List(Docto_ped_entr_lstParamWFBindingModel param)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Select_docto_pedido_entrada_List";

            try
            {

                var contentJson = JsonSerializer.Serialize<Docto_ped_entr_lstParamWFBindingModel>(param);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<List<Docto_pedido_entradaWFBindingModel>?>();
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

        public async Task<List<Movto_pedido_entradaWFBindingModel>?> Select_movto_pedido_entrada_List(Movto_ped_entr_lstParamWFBindingModel param)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Select_movto_pedido_entrada_List";

            try
            {

                var contentJson = JsonSerializer.Serialize<Movto_ped_entr_lstParamWFBindingModel>(param);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<List<Movto_pedido_entradaWFBindingModel>?>();
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

        public async Task<BaseResultBindingModel?> Docto_pedido_entrada_insert(DoctoPedidoEntradaTrans doctoProvTrans)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Docto_pedido_entrada_insert";

            try
            {

                var contentJson = JsonSerializer.Serialize<DoctoPedidoEntradaTrans>(doctoProvTrans);


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

        public async Task<BaseResultBindingModel?> Movto_pedido_entrada_insert(MovtoPedidoEntradaTrans movtoProvTrans)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Movto_pedido_entrada_insert";

            try
            {

                var contentJson = JsonSerializer.Serialize<MovtoPedidoEntradaTrans>(movtoProvTrans);


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

        public async Task<BaseResultBindingModel?> Movto_pedido_entrada_ponercantidadsurtida(MovtoPedidoEntradaTrans movtoProvTrans)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Movto_pedido_entrada_ponercantidadsurtida";

            try
            {

                var contentJson = JsonSerializer.Serialize<MovtoPedidoEntradaTrans>(movtoProvTrans);


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

        public async Task<BaseResultBindingModel?> Docto_pedido_entrada_save(Int64 empresaId, Int64 sucursalId, Int64 id, Int64 estatusDoctoId)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Docto_pedido_entrada_save";

            try
            {


                var contentJson = JsonSerializer.Serialize<PuntoPedidoEntrada_Docto_pedido_entrada_save_ApiParam>(new PuntoPedidoEntrada_Docto_pedido_entrada_save_ApiParam() {
                    EmpresaId = empresaId, SucursalId = sucursalId, Id = id, EstatusDoctoId = estatusDoctoId
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

        public async Task<BaseResultBindingModel?> Movto_pedido_entrada_ajustarExistencias(Int64 empresaId, Int64 sucursalId, Int64 id, Int64 usuarioId, Int64? almacenId)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Movto_pedido_entrada_ajustarExistencias";

            try
            {


                var contentJson = JsonSerializer.Serialize<PuntoPedidoEntrada_Movto_pedido_entrada_ajustarExistencias_ApiParam>(new PuntoPedidoEntrada_Movto_pedido_entrada_ajustarExistencias_ApiParam() {
                    EmpresaId = empresaId, SucursalId = sucursalId, Id = id, UsuarioId = usuarioId, AlmacenId = almacenId
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


        //DONE2 MLG 2025 Migracion web out
        public async Task<BaseResultBindingModel?> Docto_surtir_pedido(long empresaId, long sucursalId, long id, long? usuarioId,
                                                          long? almacenId, string? referencias) //ref long? doctoSurtidoId)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Docto_surtir_pedido";

            try
            {


                var contentJson = JsonSerializer.Serialize<PuntoPedidoEntrada_Docto_surtir_pedido_ApiParam>(new PuntoPedidoEntrada_Docto_surtir_pedido_ApiParam()
                {
                    EmpresaId = empresaId,
                    SucursalId = sucursalId,
                    Id = id,
                    UsuarioId = usuarioId,
                    AlmacenId = almacenId,
                    Referencias = referencias
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

        public async Task<BaseResultBindingModel?> Docto_update_datos_ajustables(Int64 empresaId, Int64 sucursalId, Int64 id, Int64? usuarioId, Int64? almacenId, String referencias)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Docto_update_datos_ajustables";

            try
            {


                var contentJson = JsonSerializer.Serialize<PuntoPedidoEntrada_Docto_update_datos_ajustables_ApiParam>(new PuntoPedidoEntrada_Docto_update_datos_ajustables_ApiParam(){
                                        EmpresaId = empresaId, SucursalId = sucursalId, Id = id, UsuarioId = usuarioId, AlmacenId = almacenId, Referencias = referencias
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



