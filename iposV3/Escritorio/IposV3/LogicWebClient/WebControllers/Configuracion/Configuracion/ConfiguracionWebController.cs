
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
using IposV3.DataAccess;


namespace Controllers.Controller
{

    public class ConfiguracionWebController : BaseWebController<ConfiguracionBindingModel, ConfiguracionParam>
    {

        protected ConfiguracionDao dao;
        public ConfiguracionWebController(ConfiguracionDao dao, IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Configuracion_";
            this.dao = dao;
        }



        public override string ContentJsonItem(ConfiguracionBindingModel item)
        {
            return JsonSerializer.Serialize<ConfiguracionBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<ConfiguracionParam >>(new SearchListBindingModel<ConfiguracionParam>((ConfiguracionParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<ConfiguracionParam >>(new SelectParamBindingModel<ConfiguracionParam>((ConfiguracionParam)param, search, fieldsSearching));
        }



        public override async Task<ConfiguracionBindingModel?> GetById(ConfiguracionBindingModel itemSelect)
        {

            if (itemSelect.Item == null)
                return null;

            ConfiguracionBindingModel item = new ConfiguracionBindingModel();
            item.Item = dao.Get_ById(itemSelect.Item, null);
            return item;
        }

        public override async Task<List<ConfiguracionBindingModel>> GetAll()
        {
            return dao.GetAll_(null).Select(x => new ConfiguracionBindingModel(x)).ToList();

        }


        public override async Task<List<ConfiguracionBindingModel>> SelectList(object? param, IposV3.Model.KendoParams? kendoParams)
        {
            return dao.SelectList(null, (ConfiguracionParam?)param, kendoParams).Select(x => new ConfiguracionBindingModel(x)).ToList();
        }



        public override async Task<bool> Insert(ConfiguracionBindingModel item)
        {
            if (item.Item == null)
                throw new InvalidOperationException("Hay datos no validos en este registro");

            return dao.Insert(item.Item, null);
        }

        public override async Task<List<ConfiguracionBindingModel>> Select(string search)
        {

            return dao.Select(null, search).Select(x => new ConfiguracionBindingModel(x)).ToList();
        }
        public override async Task<List<ConfiguracionBindingModel>> SelectById(ConfiguracionBindingModel itemSelect)
        {

            if (itemSelect.Item == null)
                throw new InvalidOperationException("No hay parametros correctos para hacer la seleccion");

            return dao.Select_ById(itemSelect.Item, null).Select(x => new ConfiguracionBindingModel(x)).ToList();
        }
        public override async Task<bool> Update(ConfiguracionBindingModel item)
        {
            if (item.HasErrors || item.Item == null)
                throw new InvalidOperationException("Hay datos no validos en este registro");

            return dao.Update(item.Item, null);

        }
        public override async Task<bool> Delete(ConfiguracionBindingModel item)
        {
            if (item.Item == null)
                throw new InvalidOperationException("Hay datos no validos en este registro");

            return dao.Delete(item.Item, null);
        }


        public async Task<Configuracion?> GetDefaultConfiguracion()
        {
            return dao.Select(null, "").Where(y => y.Esdefault == "S").FirstOrDefault();
        }



        public async Task<EmpresaBindingModel?> CrearEmpresa(EmpresaBindingModel empresaInfo)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/CrearEmpresa";

            try
            {

                var contentJson = JsonSerializer.Serialize<EmpresaBindingModel>(empresaInfo);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<EmpresaBindingModel?>();
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
    
        public async Task<Boolean?> UpdateEmpresa(EmpresaBindingModel item)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/UpdateEmpresa";

            try
            {

                var contentJson = JsonSerializer.Serialize<EmpresaBindingModel>(item);


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
    
        public async Task<SucursalBindingModel?> CrearSucursal(SucursalBindingModel sucursalInfo)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/CrearSucursal";

            try
            {

                var contentJson = JsonSerializer.Serialize<SucursalBindingModel>(sucursalInfo);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<SucursalBindingModel?>();
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
    
        public async Task CrearUnidadesDefault(SucursalBindingModel sucursalInfo)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/CrearUnidadesDefault";

            try
            {

                var contentJson = JsonSerializer.Serialize<SucursalBindingModel>(sucursalInfo);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    await response.Content.ReadAsStringAsync();
                    
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
            }
        }
    
        public async Task CrearAlmacenDefault(SucursalBindingModel sucursalInfo)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/CrearAlmacenDefault";

            try
            {

                var contentJson = JsonSerializer.Serialize<SucursalBindingModel>(sucursalInfo);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    await response.Content.ReadAsStringAsync();
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
            }
        }
    
        public async Task CrearClientesDefault(SucursalBindingModel sucursalInfo)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/CrearClientesDefault";

            try
            {

                var contentJson = JsonSerializer.Serialize<SucursalBindingModel>(sucursalInfo);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    await response.Content.ReadAsStringAsync();
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
            }
        }
    
        public async Task CrearProveedorDefault(SucursalBindingModel sucursalInfo)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/CrearProveedorDefault";

            try
            {

                var contentJson = JsonSerializer.Serialize<SucursalBindingModel>(sucursalInfo);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    await response.Content.ReadAsStringAsync();
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
            }
        }
    
        public async Task CrearLineaDefault(SucursalBindingModel sucursalInfo)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/CrearLineaDefault";

            try
            {

                var contentJson = JsonSerializer.Serialize<SucursalBindingModel>(sucursalInfo);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    await response.Content.ReadAsStringAsync();
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
            }
        }
    
        public async Task CrearMarcaDefault(SucursalBindingModel sucursalInfo)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/CrearMarcaDefault";

            try
            {

                var contentJson = JsonSerializer.Serialize<SucursalBindingModel>(sucursalInfo);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    await response.Content.ReadAsStringAsync();
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
            }
        }
    
        public async Task CrearProductoDefault(SucursalBindingModel sucursalInfo)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/CrearProductoDefault";

            try
            {

                var contentJson = JsonSerializer.Serialize<SucursalBindingModel>(sucursalInfo);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    await response.Content.ReadAsStringAsync();
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
            }
        }
    
        public async Task<CajaBindingModel?> CrearCaja(CajaBindingModel cajaInfo)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/CrearCaja";

            try
            {

                var contentJson = JsonSerializer.Serialize<CajaBindingModel>(cajaInfo);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<CajaBindingModel?>();
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
    
        public async Task<UsuarioBindingModel?> CrearUsuario(UsuarioBindingModel usuarioInfo)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/CrearUsuario";

            try
            {

                var contentJson = JsonSerializer.Serialize<UsuarioBindingModel>(usuarioInfo);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<UsuarioBindingModel?>();
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
    
        public async Task CrearParametroDefault(Int64 empresaId, Int64 sucursalId)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/CrearParametroDefault";

            try
            {


                var contentJson = JsonSerializer.Serialize<Configuracion_CrearParametroDefault_ApiParam>(new Configuracion_CrearParametroDefault_ApiParam(){
                                        EmpresaId = empresaId, SucursalId = sucursalId
                                    });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    await response.Content.ReadAsStringAsync();
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
            }
        }
    
        public async Task MigrateDataBase(Boolean createIfNotExist, String rutaInstalacionPostgresql, ConfiguracionBindingModel configuracion)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/MigrateDataBase";

            try
            {


                var contentJson = JsonSerializer.Serialize<Configuracion_MigrateDataBase_ApiParam>(new Configuracion_MigrateDataBase_ApiParam(){
                                        CreateIfNotExist = createIfNotExist, RutaInstalacionPostgresql = rutaInstalacionPostgresql, Configuracion = configuracion
                                    });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    await response.Content.ReadAsStringAsync();
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
            }
        }
    



  }

}



