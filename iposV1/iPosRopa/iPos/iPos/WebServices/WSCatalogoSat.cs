
using DataLayer.Utilerias.Respuestas.CatalogoSat;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos.WebServices
{
    public class WSCatalogoSat
    {
        private string urlObtenerUltimaVersion = @"http://bi-pos.servebeer.com:8080/WSCatalogoSAT/CatalogoSAT.svc/GetLastUpdate";

        private string urlObtenerInfo = @"http://bi-pos.servebeer.com:8080/WSCatalogoSAT/CatalogoSAT.svc/GetData/";

        private string urlObtenerInfoDeTabla = @"http://bi-pos.servebeer.com:8080/WSCatalogoSAT/CatalogoSAT.svc/GetDataFromTable/";

        private HttpClient client;

        public SatCatalogueInfo ObtenerUltimaVersion()
        {
            client = new HttpClient();
            try
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, urlObtenerUltimaVersion);

                HttpResponseMessage response = client.SendAsync(requestMessage).Result;
                if (response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;

                    CatalogoSatResponse<SatCatalogueInfo> respuestaResult = 
                        JsonConvert.DeserializeObject<CatalogoSatResponse<SatCatalogueInfo>>(content);

                    response.Dispose();

                    if (!respuestaResult.Message.Equals("SUCCESS"))
                    {
                        throw new Exception(respuestaResult.Message);
                    }

                    return respuestaResult.Data;
                }
                else
                {
                    throw new Exception("Status code: " + response.StatusCode + " Reason: " + response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK);
                MessageBox.Show("Error", "No se pudo conectar al servidor", MessageBoxButtons.OK);
#endif

                return null;
            }
        }

        public List<TableData> ObtenerCambios(long version, int pagina)
        {
            client = new HttpClient();
            try
            {
                string urlFinal = urlObtenerInfo + version.ToString() + "/" + pagina.ToString();

                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, urlFinal);

                HttpResponseMessage response = client.SendAsync(requestMessage).Result;
                if (response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;

                    CatalogoSatResponse<List<TableData>> respuestaResult = 
                        JsonConvert.DeserializeObject<CatalogoSatResponse<List<TableData>>>(content);

                    response.Dispose();

                    if (respuestaResult.Message.Equals("SUCCESS"))
                    {
                        return respuestaResult.Data;
                    }
                    else
                    {
                        throw new Exception(respuestaResult.Message);
                    }
                }
                else
                {
                    throw new Exception("Status code: " + response.StatusCode + " Reason: " + response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message + " - " + ex.InnerException, "ERROR", MessageBoxButtons.OK);
                //MessageBox.Show("Error", "No se pudo conectar al servidor", MessageBoxButtons.OK);
                Console.WriteLine(ex.Message + " - " + ex.InnerException);
                Console.WriteLine("Error");
                return null;
            }
        }

        public object ObtenerCambiosDeTabla(string tabla, long pagina, int version)
        {
            client = new HttpClient();
            try
            {
                string urlFinal = urlObtenerInfoDeTabla + version.ToString() + "/" + pagina.ToString() + "/" + tabla;

                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, urlFinal);

                HttpResponseMessage response = client.SendAsync(requestMessage).Result;
                if (response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;

                    CatalogoSatResponse<TableData> respuestaResult =
                        JsonConvert.DeserializeObject<CatalogoSatResponse<TableData>>(content);

                    response.Dispose();
                    

                    if (respuestaResult.Message.Equals("SUCCESS"))
                    {
                        return respuestaResult.Data;
                    }
                    else
                    {
                        throw new Exception(respuestaResult.Message);
                    }
                }
                else
                {
                    throw new Exception("Status code: " + response.StatusCode + " Reason: " + response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message == "Error: NameResolutionFailure")
                {
                    return false;
                }
                else
                {
                    MessageBox.Show(ex.Message + " - " + ex.InnerException, "ERROR", MessageBoxButtons.OK);
                    MessageBox.Show("Error", "No se pudo conectar al servidor", MessageBoxButtons.OK);
                }
            }

            return false;
        }
    }
}
