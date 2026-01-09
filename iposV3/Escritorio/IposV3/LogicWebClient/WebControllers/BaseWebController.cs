#define CONNECT_LOCAL
using BindingModels;
using IposV3.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;


namespace Controllers.Controller
{


#pragma warning disable 1998
    public class BaseWebController<T, U> : IWebControllerProvider<T> where T : class where U : class
    {


        protected IHttpClientFactory _httpClientFactory;

        protected string instanceDestination;

        protected string pathController = "";
        public BaseWebController(IHttpClientFactory httpClientFactory)
        {
            pathController = "";
            instanceDestination = "";

            _httpClientFactory = httpClientFactory;
        }


        public virtual string ContentJsonItem(T item )
        {
            //JsonSerializer.Serialize<UnidadBindingModel>(itemSelect);
            throw new NotImplementedException();
        }



        public virtual string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            //JsonSerializer.Serialize<SearchListBindingModel<U>>(new SearchListBindingModel<U>((U?)param, kendoParams));
            throw new NotImplementedException();
        }

        public virtual string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            //JsonSerializer.Serialize<SelectParamBindingModel<U>>(new SelectParamBindingModel<U>((U)param, search, fieldsSearching));
            throw new NotImplementedException();
        }


        public virtual async Task<List<T>> GetAll()
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/GetAll";

            try
            {


                var contentJson = "";


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<List<T>>();
                    return apiResponse ?? new List<T>();
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
                return new List<T>();
            }
        }


        public virtual async Task<T?> GetById(T itemSelect)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/GetById";

            try
            {


                var contentJson = ContentJsonItem(itemSelect);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<T?>();
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


        public virtual async Task<List<T>> SelectList(object? param, KendoParams? kendoParams)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/SelectList";

            try
            {


                var contentJson = ContentJsonSearchList(param,  kendoParams);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<List<T>?>();
                    return apiResponse ?? new List<T>();
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
                return new List<T>();
            }

        }





        public virtual async Task<bool> Insert(T item)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Insert";

            try
            {


                var contentJson = ContentJsonItem(item);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);


                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<bool?>();
                    return apiResponse ?? false;
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
                return false;
            }
        }

        public virtual async Task<List<T>> Select(object param, string search, string fieldsSearching)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Select";

            try
            {


                var contentJson = ContentJsonSelectParamList(param, search, fieldsSearching);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);


                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<List<T>>();
                    return apiResponse ?? new List<T>();
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
                return new List<T>();
            }
        }

        public virtual async Task<List<T>> SelectById(T itemSelect)
        {


            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/SelectById";

            try
            {


                var contentJson = ContentJsonItem(itemSelect);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<List<T>>();
                    return apiResponse ?? new List<T>();
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
                return new List<T>();
            }

        }

        public virtual async Task<bool> Update(T item)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Update";

            try
            {


                var contentJson = ContentJsonItem(item);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<bool?>();
                    return apiResponse ?? false;
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
                return false;
            }

        }

        public virtual async Task<bool> Delete(T item)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Delete";

            try
            {


                string? contentJson = ContentJsonItem(item); 


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadFromJsonAsync<bool?>();
                    return apiResponse ?? false;
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
                return false;
            }
        }


        public string GetDefaultBaseUrl()
        {

#if CONNECT_LOCAL
            return $"http://localhost:5001";
#else
            return $"http://iposbackend-staging.eba-puke9qrp.us-east-1.elasticbeanstalk.com";
#endif
        }

        //public virtual async Task <T?> GetById(T itemSelect)
        //{
        //    throw new Exception("not implemented");
        //}
        //public virtual async Task<List<T>> GetAll()
        //{
        //    throw new Exception("not implemented");
        //}

        //public virtual async Task<List<T>> SelectList(object? param, KendoParams? kendoParams)
        //{
        //    throw new Exception("not implemented");
        //}

        //public virtual async Task<bool> Insert(T item)
        //{
        //    throw new Exception("not implemented");
        //}
        //public virtual async Task<List<T>> Select(object param, string search, string fieldsSearching)
        //{
        //    throw new Exception("not implemented");
        //}
        //public virtual async Task<List<T>> SelectById(T itemSelect)
        //{
        //    throw new Exception("not implemented");
        //}
        //public virtual async Task<bool> Update(T item)
        //{
        //    throw new Exception("not implemented");
        //}
        //public virtual async Task<bool> Delete(T item)
        //{
        //    throw new Exception("not implemented");
        //}


        public virtual async Task<List<T>> Select(string search)
        {

            throw new Exception("not implemented");
        }

        public virtual List<KendoSort> FillDefaultSort()
        {
            return new List<KendoSort>(){ new KendoSort() {
                Field = "Creado",
                Dir = "asc"
            } };
        }



    }


    public class BaseGenericWebController 
    {


        protected IHttpClientFactory _httpClientFactory;

        protected string instanceDestination;

        protected string pathController = "";
        public BaseGenericWebController(IHttpClientFactory httpClientFactory)
        {
            pathController = "";
            instanceDestination = "";

            _httpClientFactory = httpClientFactory;
        }


        public string GetDefaultBaseUrl()
        {
#if CONNECT_LOCAL
            return $"http://localhost:5001";
#else
            return $"http://iposbackend-staging.eba-puke9qrp.us-east-1.elasticbeanstalk.com";
#endif
        }


    }

#pragma warning restore 1998
}
