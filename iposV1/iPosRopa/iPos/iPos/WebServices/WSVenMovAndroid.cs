using iPos.WebServices.VendedorMovilAndroid;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace iPos.WebServices
{
    public class WSVenMovAndroid
    {
        //File transfer service
        private string urlDescargarArchivo = @"http://localhost:56991/WSFileTransfer.svc/DownloadFile";
        private string urlSubirArchivo = @"http://localhost:53472/ServiceContract/Implementation/WSFileTransfer.svc/UploadFile";

        private HttpClient client;

        public bool SubirArchivoVenMov(string rutaOrigenArchivo, string fileName, string filePath)
        {
            client = new HttpClient();

            string destinoCopia = AppDomain.CurrentDomain.BaseDirectory + @"sampdata\VENMOVDROIDCOPY.fdb";

            try
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, urlSubirArchivo);

                File.Copy(rutaOrigenArchivo, destinoCopia);

                var stream = new FileStream(destinoCopia, FileMode.Open, FileAccess.Read);
                requestMessage.Content = new StreamContent(stream);

                requestMessage.Headers.Add("fileName", fileName);
                requestMessage.Headers.Add("filePath", filePath);

                HttpResponseMessage response = client.SendAsync(requestMessage).Result;
                if (response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;

                    XmlDocument respuesta = new XmlDocument();
                    respuesta.LoadXml(content);

                    XmlNodeList nodeList = respuesta.GetElementsByTagName("Message");
                    string mensaje = nodeList[0].InnerText;

                    response.Dispose();

                    if (mensaje.Equals("SUCCESS"))
                    {
                        return true;
                    }
                    else
                    {
                        throw new Exception(mensaje);
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
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                }
            }
            finally
            {
                File.Delete(destinoCopia);
            }

            return false;
        }
    }
}
