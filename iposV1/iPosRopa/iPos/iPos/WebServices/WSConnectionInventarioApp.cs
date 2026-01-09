using iPosBusinessEntity;
using iPosData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WSGetProducta4App.DAO.businessEntity;

namespace iPos.WebServices
{
    public class WSConnectionInventarioApp
    {
        ///InventarioWS
        private string urlWSInventarioPOST =  @"http://" +
                                      CurrentUserID.CurrentParameters.IIPWEBSERVICEAPPINV +
                                      "/InventarioWS/WSInventarioApp.svc/SetContainers";
        //@"http://localhost:56607/WSInventarioApp.svc/SetContainers";

        ///InventarioWS
        private string urlWSInventarioExistPOST = @"http://" +
                              CurrentUserID.CurrentParameters.IIPWEBSERVICEAPPINV +
                              "/InventarioWS/WSInventarioApp.svc/inventarioExist";

        ///InventarioWS
        private string urlWSGetInventarioContainer = /*@"http://localhost:56607/WSInventarioApp.svc/getContainers";*/@"http://" +
                      CurrentUserID.CurrentParameters.IIPWEBSERVICEAPPINV +
                      "/InventarioWS/WSInventarioApp.svc/getContainers";

        ///InventarioWS
        private string urlWSInventarioStatusPut = @"http://" +
                              CurrentUserID.CurrentParameters.IIPWEBSERVICEAPPINV +
                                             "/InventarioWS/WSInventarioApp.svc/UpdateStatusInventario";
                                             /*@"http://localhost:56607/WSInventarioApp.svc/UpdateStatusInventario";*/

        private HttpClient client;

        public bool setInventarioWithBody(Dictionary<string, object> datos, ref string resultSuccess)
        {
            client = new HttpClient();
            try
            {
                var serialized = JsonConvert.SerializeObject(datos);
                byte[] bSerialized = Encoding.UTF8.GetBytes(serialized);

                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, urlWSInventarioPOST);

                requestMessage.Content = new ByteArrayContent(bSerialized);

                //requestMessage.Headers.Add("UserName", CurrentUserID.CurrentUser.IUSERNAME);
                //requestMessage.Headers.Add("Password", "kabu"/*CurrentUserID.CurrentUser.ICLAVEACCESO*/);
                requestMessage.Headers.Add("SucursalClave", CurrentUserID.SUCURSAL_CLAVE);
                requestMessage.Headers.Add("rutaBaseDatos", CurrentUserID.CurrentParameters.IRUTABDAPPINVENTARO);

                HttpResponseMessage response = client.SendAsync(requestMessage).Result;
                if (response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;

                    string respuestaResult = JsonConvert.DeserializeObject<string>(content);

                    resultSuccess = respuestaResult;

                    response.Dispose();

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message == "Error: NameResolutionFailure")
                {
                    return false;
                }
                else
                {
                    MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK);
                    MessageBox.Show("Error", "No se pudo conectar al servidor", MessageBoxButtons.OK);
                }
            }

            return false;
        }

        public bool changeInventarioStatus(string status, long doctoId, string sucursalClave, string almacenClave)
        {
            string respuestaResult = "0";
            client = new HttpClient();
            try
            {
                EstatusInventario estatusInventario = new EstatusInventario();
                estatusInventario.DoctoId = int.Parse(doctoId.ToString());
                estatusInventario.SucursalClave = sucursalClave;
                estatusInventario.Status = status;
                var serialized = JsonConvert.SerializeObject(estatusInventario);
                byte[] bSerialized = Encoding.UTF8.GetBytes(serialized);

                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Put, urlWSInventarioStatusPut);

                requestMessage.Content = new ByteArrayContent(bSerialized);

                requestMessage.Headers.Add("UserName", "");
                requestMessage.Headers.Add("Password", "");
                requestMessage.Headers.Add("rutaBaseDatos", CurrentUserID.CurrentParameters.IRUTABDAPPINVENTARO);
                requestMessage.Headers.Add("dispositivo", "");
                requestMessage.Headers.Add("almacenClave", almacenClave);

                HttpResponseMessage response = client.SendAsync(requestMessage).Result;
                if (response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;

                    respuestaResult = JsonConvert.DeserializeObject<string>(content);

                    response.Dispose();

                    //return true;
                }
                return respuestaResult == "1";
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message == "Error: NameResolutionFailure")
                {
                    return false;
                }
                else
                {
                    MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK);
                    MessageBox.Show("Error", "No se pudo conectar al servidor", MessageBoxButtons.OK);
                }
            }

            return false;
        }

        public bool inventariosAbiertos(ref string result)
        {
            client = new HttpClient();
            try
            {

                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, urlWSInventarioExistPOST);

                requestMessage.Headers.Add("sucursalClave", CurrentUserID.SUCURSAL_CLAVE);
                requestMessage.Headers.Add("rutaBaseDatos", CurrentUserID.CurrentParameters.IRUTABDAPPINVENTARO);

                HttpResponseMessage response = client.SendAsync(requestMessage).Result;
                if (response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;

                    string respuestaResult = JsonConvert.DeserializeObject<string>(content);

                    result = respuestaResult;

                    response.Dispose();

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message == "Error: NameResolutionFailure")
                {
                    return false;
                }
                else
                {
                    MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK);
                    MessageBox.Show("Error", "No se pudo conectar al servidor", MessageBoxButtons.OK);
                }
            }

            return false;
        }


        public bool getLocationContainer(ref List<InvMovilContainerResponse> result)
        {
            client = new HttpClient();
            try
            {

                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, urlWSGetInventarioContainer);

                requestMessage.Headers.Add("sucursalClave", CurrentUserID.SUCURSAL_CLAVE);
                requestMessage.Headers.Add("rutaBaseDatos", CurrentUserID.CurrentParameters.IRUTABDAPPINVENTARO);

                HttpResponseMessage response = client.SendAsync(requestMessage).Result;
                if (response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;

                    List<InvMovilContainerResponse> respuestaResult = JsonConvert.DeserializeObject<List<InvMovilContainerResponse>>(content);

                    result = respuestaResult;

                    response.Dispose();

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message == "Error: NameResolutionFailure")
                {
                    return false;
                }
                else
                {
                    MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK);
                    MessageBox.Show("Error", "No se pudo conectar al servidor", MessageBoxButtons.OK);
                }
            }

            return false;
        }

    }
}
