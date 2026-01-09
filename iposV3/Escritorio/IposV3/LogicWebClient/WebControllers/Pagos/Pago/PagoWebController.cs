
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

    public class PagoWebController : BaseWebController<PagoBindingModel, PagoParam>
    {

        public PagoWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Pago_";
        }



        public override string ContentJsonItem(PagoBindingModel item)
        {
            return JsonSerializer.Serialize<PagoBindingModel>(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<PagoParam>>(new SearchListBindingModel<PagoParam>((PagoParam?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<PagoParam>>(new SelectParamBindingModel<PagoParam>((PagoParam)param, search, fieldsSearching));
        }



        public async Task<List<V_pago_compuestoWFBindingModel>?> PagoCompuestoList(V_pagos_compuestos_list_selWFBindingModel itemParam)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/PagoCompuestoList";

            try
            {

                var contentJson = JsonSerializer.Serialize<V_pagos_compuestos_list_selWFBindingModel>(itemParam);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<List<V_pago_compuestoWFBindingModel>?>();
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

        //DONE2 MLG 2025 Migracion web
        public async Task<List<V_docto_con_saldoWFBindingModel>?> DoctosConSaldoList(Int64 empresaId, Int64 sucursalId, Int64? tipodoctoid, Int64? clienteId, Int64? proveedorId, Boolean soloTimbrados, Int64? usuarioId, Boolean corteActivo, String referencia, DateTimeOffset? fechaInicial, DateTimeOffset? fechaFinal, Int64? estatusDoctoId)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/DoctosConSaldoList";

            try
            {


                var contentJson = JsonSerializer.Serialize<Pago_DoctosConSaldoList_ApiParam>(new Pago_DoctosConSaldoList_ApiParam()
                {
                    EmpresaId = empresaId,
                    SucursalId = sucursalId,
                    Tipodoctoid = tipodoctoid,
                    ClienteId = clienteId,
                    ProveedorId = proveedorId,
                    SoloTimbrados = soloTimbrados,
                    UsuarioId = usuarioId,
                    CorteActivo = corteActivo,
                    Referencia = referencia,
                    FechaInicial = fechaInicial
                });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<List<V_docto_con_saldoWFBindingModel>?>();
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


        //DONE2 MLG 2025 Migracion web
        public async Task<List<V_doctopago_aplicadoWFBindingModel>?> DoctoPagosAplicadosList(Int64 empresaId, Int64 sucursalId, Int64 pagoId)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/DoctoPagosAplicadosList";

            try
            {


                var contentJson = JsonSerializer.Serialize<Pago_DoctoPagosAplicadosList_ApiParam>(new Pago_DoctoPagosAplicadosList_ApiParam()
                {
                    EmpresaId = empresaId,
                    SucursalId = sucursalId,
                    PagoId = pagoId
                });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<List<V_doctopago_aplicadoWFBindingModel>?>();
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


        //DONE2 MLG 2025 Migracion web
        public async Task<List<V_DoctoPagoItemBindingModel>?> DoctoPagosList(Int64 empresaId, Int64 sucursalId, Int64 doctoId)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/DoctoPagosList";

            try
            {


                var contentJson = JsonSerializer.Serialize<Pago_DoctoPagosList_ApiParam>(new Pago_DoctoPagosList_ApiParam()
                {
                    EmpresaId = empresaId,
                    SucursalId = sucursalId,
                    DoctoId = doctoId
                });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<List<V_DoctoPagoItemBindingModel>?>();
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
        public async Task<BaseResultBindingModel?> GenerarReciboElectronico(long empresaId, long sucursalId, long pagoId,
                                             long vendedorId)
                                             //ref long? reciboElectronicoId)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/GenerarReciboElectronico";

            try
            {


                var contentJson = JsonSerializer.Serialize<Pago_GenerarReciboElectronico_ApiParam>(new Pago_GenerarReciboElectronico_ApiParam()
                {
                    EmpresaId = empresaId,
                    SucursalId = sucursalId,
                    PagoId = pagoId,
                    VendedorId = vendedorId
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
        public async Task<BaseResultBindingModel?> PagoCompuestoInsert(Pago_transaccion pagoTransaccion, List<DoctoPago_transaccion> doctoPagoTransacciones) //,ref long? pagoId)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/PagoCompuestoInsert";

            try
            {


                var contentJson = JsonSerializer.Serialize<Pago_PagoCompuestoInsert_ApiParam>(new Pago_PagoCompuestoInsert_ApiParam()
                {
                    PagoTransaccion = pagoTransaccion,
                    DoctoPagoTransacciones = doctoPagoTransacciones
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
        public async Task<BaseResultBindingModel?> PagoCompuestoRevertir(long empresaId, long sucursalId, long pagoARevertirId,
                                           long usuarioId, long corteId, string? notas) //ref long? pagoId)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/PagoCompuestoRevertir";

            try
            {


                var contentJson = JsonSerializer.Serialize<Pago_PagoCompuestoRevertir_ApiParam>(new Pago_PagoCompuestoRevertir_ApiParam()
                {
                    EmpresaId = empresaId,
                    SucursalId = sucursalId,
                    PagoARevertirId = pagoARevertirId,
                    UsuarioId = usuarioId,
                    CorteId = corteId,
                    Notas = notas
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



