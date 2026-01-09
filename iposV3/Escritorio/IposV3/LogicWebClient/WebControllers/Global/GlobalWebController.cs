
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
using IposV3.BindingModel;


namespace Controllers.Controller
{

    public class GlobalWebController: BaseGenericWebController
    {



        public GlobalWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Global_";
        }




        //DONE MLG 2025 Migracion web
        public void llenarSesionPorConfiguracion(Configuracion config,
                                                 //OperationsContextFactory? operationsContextFactory,
                                                ref GlobalSession globalSession)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/llenarSesionPorConfiguracion";

            try
            {


                var contentJson = JsonSerializer.Serialize<Configuracion>(config);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");


                GlobalSession? apiResponse = null;

                bool bSuccess = false;
                string comentario = "";

                Task.Run(async () =>
                {
                    HttpResponseMessage response = await httpClient.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {

                        apiResponse = await response.Content.ReadFromJsonAsync<GlobalSession?>();
                        bSuccess = true;
                    }
                    else
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        comentario = responseText;
                        bSuccess = false;
                    }
                }).Wait();

                if(bSuccess)
                {

                    globalSession = apiResponse ?? globalSession;
                }
                else
                {

                    throw new Exception(comentario);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //if (operationsContextFactory != null)
            //    _operationsContextFactory = operationsContextFactory;

            //using var applicationDbContext = this._operationsContextFactory.Create();

            //if (config != null)
            //{
            //    globalSession.CurrentEmpresa = applicationDbContext.Empresa.FirstOrDefault(y => y.Id == config.Empresaid);
            //    globalSession.CurrentSucursal = applicationDbContext.Sucursal.FirstOrDefault(y => y.Id == config.Sucursalid && y.EmpresaId == config.Empresaid);
            //    globalSession.CurrentParametro = applicationDbContext.Parametro.FirstOrDefault(y => y.EmpresaId == config.Empresaid && y.SucursalId == config.Sucursalid);

            //    var claveSucursal = globalSession!.CurrentSucursal?.Clave;

            //    globalSession.CurrentSucursalInfo = applicationDbContext.Sucursal_info.Where(p => p.EmpresaId == config.Empresaid && p.SucursalId == config.Sucursalid &&
            //                                                        p.Clave == claveSucursal).FirstOrDefault();

            //    if (config.Cajaid != null)
            //        globalSession.CurrentCaja = applicationDbContext.Caja.FirstOrDefault(y => y.EmpresaId == config.Empresaid && y.SucursalId == config.Sucursalid && y.Id == config.Cajaid.Value);
            //    else
            //        globalSession.CurrentCaja = null;

            //    globalSession.CurrentConfiguracion = config;

            //    globalSession.CurrentLookups = applicationDbContext.Lookup.AsNoTracking().Where(y => y.EmpresaId == config.Empresaid && y.SucursalId == config.Sucursalid).ToList();


            //}

        }


        //DONE MLG 2025 Migracion web
        //public void llenarSesionPorConfiguracionsync(Configuracionsync configsync, ref GlobalSession globalSession)
        //{

        //    string url = $"{GetDefaultBaseUrl()}/api/{pathController}/llenarSesionPorConfiguracionsync";

        //    try
        //    {


        //        var contentJson = JsonSerializer.Serialize<Configuracionsync>(configsync);


        //        var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
        //        var content = new StringContent(contentJson, Encoding.UTF8, "application/json");


        //        GlobalSession? apiResponse = null;

        //        bool bSuccess = false;
        //        string comentario = "";

        //        Task.Run(async () =>
        //        {
        //            HttpResponseMessage response = await httpClient.PostAsync(url, content);

        //            if (response.IsSuccessStatusCode)
        //            {

        //                apiResponse = await response.Content.ReadFromJsonAsync<GlobalSession?>();
        //                bSuccess = true;
        //            }
        //            else
        //            {
        //                string responseText = await response.Content.ReadAsStringAsync();
        //                comentario = responseText;
        //                bSuccess = false;
        //            }
        //        }).Wait();

        //        if (bSuccess)
        //        {

        //            globalSession = apiResponse ?? globalSession;
        //        }
        //        else
        //        {

        //            throw new Exception(comentario);
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }

        //    //using var applicationDbContext = this._operationsContextFactory.Create();

        //    //if (configsync != null)
        //    //{
        //    //    globalSession.CurrentEmpresa = applicationDbContext.Empresa.FirstOrDefault(y => y.Id == configsync.EmpresaId);
        //    //    globalSession.CurrentSucursal = applicationDbContext.Sucursal.FirstOrDefault(y => y.Id == configsync.SucursalId && y.EmpresaId == configsync.EmpresaId);
        //    //    globalSession.CurrentParametro = applicationDbContext.Parametro.FirstOrDefault(y => y.EmpresaId == configsync.EmpresaId && y.SucursalId == configsync.SucursalId);

        //    //    var claveSucursal = globalSession!.CurrentSucursal?.Clave;

        //    //    globalSession.CurrentSucursalInfo = applicationDbContext.Sucursal_info.Where(p => p.EmpresaId == configsync.EmpresaId && p.SucursalId == configsync.SucursalId &&
        //    //                                                        p.Clave == claveSucursal).FirstOrDefault();

        //    //}

        //}




        //DONE MLG 2025 Migracion web
        public void llenarProductAutoCompleteList(ref GlobalSession? globalSession)
        {

            if (globalSession == null)
                return;

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/llenarProductAutoCompleteList";

            try
            {


                var contentJson = JsonSerializer.Serialize<BaseParam>(new BaseParam(globalSession!.Empresaid, globalSession!.Sucursalid));


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");


                GlobalSession? apiResponse = null;

                bool bSuccess = false;
                string comentario = "";

                Task.Run(async () =>
                {
                    HttpResponseMessage response = await httpClient.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {

                        apiResponse = await response.Content.ReadFromJsonAsync<GlobalSession?>();
                        bSuccess = true;
                    }
                    else
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        comentario = responseText;
                        bSuccess = false;
                    }
                }).Wait();

                if (bSuccess )
                {

                    globalSession.ListadoAutoCompleteProd = apiResponse?.ListadoAutoCompleteProd  ;
                }
                else
                {

                    throw new Exception(comentario);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //using var applicationDbContext = this._operationsContextFactory.Create();

            //if (globalSession == null)
            //    return;

            //if (globalSession.ListadoAutoCompleteProd != null && globalSession.ListadoAutoCompleteProd.Count > 0)
            //{
            //    return;
            //}

            //globalSession.ListadoAutoCompleteProd = applicationDbContext.Producto.Where(p => p.Activo == BoolCS.S)
            //                                       .AsNoTracking()
            //                                       .Select(y => new BindingModels.ProductoAutocompleteBindingModel(y)).ToList();


        }



        //DONE MLG 2025 Migracion web
        public void llenarClienteAutoCompleteList(ref GlobalSession? globalSession)
        {


            if (globalSession == null)
                return;

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/llenarClienteAutoCompleteList";

            try
            {


                var contentJson = JsonSerializer.Serialize<BaseParam>(new BaseParam(globalSession!.Empresaid, globalSession!.Sucursalid));


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");


                GlobalSession? apiResponse = null;

                bool bSuccess = false;
                string comentario = "";

                Task.Run(async () =>
                {
                    HttpResponseMessage response = await httpClient.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {

                        apiResponse = await response.Content.ReadFromJsonAsync<GlobalSession?>();
                        bSuccess = true;
                    }
                    else
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        comentario = responseText;
                        bSuccess = false;
                    }
                }).Wait();

                if (bSuccess)
                {

                    globalSession.ListadoAutoCompleteCliente = apiResponse?.ListadoAutoCompleteCliente;
                }
                else
                {

                    throw new Exception(comentario);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //using var applicationDbContext = this._operationsContextFactory.Create();

            //if (globalSession == null)
            //    return;

            //if (globalSession.ListadoAutoCompleteCliente != null && globalSession.ListadoAutoCompleteCliente.Count > 0)
            //{
            //    return;
            //}

            //globalSession.ListadoAutoCompleteCliente = applicationDbContext.Cliente.Where(p => p.Activo == BoolCS.S)
            //                                       .AsNoTracking()
            //                                       .Select(y => new BindingModels.ClienteAutocompleteBindingModel(y)).ToList();


        }



        //DONE MLG 2025 Migracion web
        public void llenarSesionUsuario(long? usuarioId, ref GlobalSession? globalSession)
        {


            if (globalSession == null || usuarioId == null)
                return;

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/llenarSesionUsuario";

            try
            {
                var configuracionBM = new ConfiguracionBindingModel(globalSession.CurrentConfiguracion!);
                configuracionBM.Usuarioid = usuarioId;


                var contentJson = JsonSerializer.Serialize<ConfiguracionBindingModel>(configuracionBM);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");


                GlobalSession? apiResponse = null;

                bool bSuccess = false;
                string comentario = "";

                Task.Run(async () =>
                {
                    HttpResponseMessage response = await httpClient.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {

                        apiResponse = await response.Content.ReadFromJsonAsync<GlobalSession?>();
                        bSuccess = true;
                    }
                    else
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        comentario = responseText;
                        bSuccess = false;
                    }
                }).Wait();

                if (bSuccess)
                {

                    globalSession.CurrentUsuario = apiResponse?.CurrentUsuario;
                }
                else
                {

                    throw new Exception(comentario);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }


    }
}
