
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
using IposV3.Services.FacturaElectronica;
using IposV3.Services.Extensions;
using System.Xml;


namespace Controllers.Controller
{

    public class CfdiWebController : BaseGenericWebController
    {


        public const string FileLocalLocation_FE_XML_Timbrados = "\\sampdata\\facturaelectronica\\XML\\Timbrados";
        public const string FileLocalLocation_FE_IMG = "\\sampdata\\facturaelectronica\\IMG";

        public const string FileLocalLocation_DE_XML_Timbrados = "\\sampdata\\devolucionelectronica\\XML\\Timbrados";
        public const string FileLocalLocation_DE_IMG = "\\sampdata\\devolucionelectronica\\IMG";

        public const string FileLocalLocation_AE_XML_Timbrados = "\\sampdata\\abonoselectronicos\\XML\\Timbrados";
        public const string FileLocalLocation_AE_IMG = "\\sampdata\\abonoselectronicos\\IMG";

        public const string FileLocalLocation_CT_XML_Timbrados = "\\sampdata\\comprobantetraslado\\XML\\Timbrados";
        public const string FileLocalLocation_CT_IMG = "\\sampdata\\comprobantetraslado\\IMG";

        DoctoWebController _doctoWebController;

        public CfdiWebController(IHttpClientFactory httpClientFactory, DoctoWebController doctoWebController) : base(httpClientFactory)
        {
            pathController = "Cfdi_";
            _doctoWebController = doctoWebController;
        }



        public async Task<BaseResultBindingModel?> GeneraFacturaElectronica(long empresaId, long sucursalId, long doctoId, string? tipocomprobanteespecial, bool generarcartaporte,
                                              ParametroBindingModel parametro,
                                              IposV3.Services.FacturaElectronica.VirtualXmlHelper.DispatcherDelegate? dispatcherMethodCall)
        {

            try
            {


                var resultBM = new BaseResultBindingModel();
                resultBM.Usermessage = "";
                resultBM.Devmessage = "";
                resultBM.Result = 0L;




                var resultPreparation = await Factura_Electronica_Generar(empresaId, sucursalId, doctoId, 
                                                                            parametro, true, true,
                                                                            tipocomprobanteespecial, generarcartaporte, dispatcherMethodCall);

                if(resultPreparation == null)
                {
                    resultBM.Result = -1;
                    resultBM.Usermessage =  "Fallo la preparacion de la factura";
                    resultBM.Devmessage = "Fallo la preparacion de la factura";
                    return resultBM;
                }
                else if(resultPreparation != null && resultPreparation.Result  < 0)
                {
                    return resultPreparation;
                }

                return new BaseResultBindingModel() { Result = 0 };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }


        }

        public async Task<BaseResultBindingModel?> Factura_Electronica_Generar(
                    long empresaId, long sucursalId, long doctoId,
                    ParametroBindingModel parametro, bool silentMode, bool overwritte, string? tipocomprobanteespecial, bool generarCartaPorte,
                    IposV3.Services.FacturaElectronica.VirtualXmlHelper.DispatcherDelegate? dispatcherMethodCall)
        {

            var resultBM = new BaseResultBindingModel();
            resultBM.Usermessage = "";
            resultBM.Devmessage = "";
            resultBM.Result = 0L;


            var prefixComprobante = obtainPrefixByTipoComprobante(tipocomprobanteespecial);




            TimbradoInfo timbradoInfo = new TimbradoInfo();
            timbradoInfo.EmpresaId = empresaId;
            timbradoInfo.SucursalId = sucursalId;
            timbradoInfo.DoctoId = doctoId;
            timbradoInfo.Tipocomprobanteespecial = tipocomprobanteespecial;
            timbradoInfo.Generarcartaporte = generarCartaPorte;

            bool seHizoPreparacion = false;

            try
            {

                resultBM = await this.Factura_Electronica_Preparar(timbradoInfo);
                if (resultBM == null || resultBM.Result < 0)
                {
                    return resultBM;
                }
                seHizoPreparacion = true;

                var doctoAFacturar = await _doctoWebController.GetById(new DoctoBindingModel()
                {
                    EmpresaId = empresaId,
                    SucursalId = sucursalId,
                    Id = doctoId

                });

                if (doctoAFacturar == null)
                {

                    resultBM.Usermessage = "No existe el documento a facturar";
                    resultBM.Devmessage = resultBM.Usermessage;
                    resultBM.Result = -1L;
                    return resultBM;
                }

                string documentoTimbrado = Facturacion_FileLocalLocation_XML_Timbrados(doctoAFacturar!.Tipodoctoid!.Value, parametro, tipocomprobanteespecial) + "\\" + prefixComprobante + (doctoAFacturar.Docto_fact_elect_Seriesat ?? "") + (doctoAFacturar.Docto_fact_elect_Foliosat?.ToString() ?? "") + ".xml";



                if (File.Exists(documentoTimbrado))
                {
                    if (overwritte)
                        File.Delete(documentoTimbrado);
                    else
                    {
                        resultBM.Usermessage = "Archivo timbrado existente en la carpeta";
                        resultBM.Devmessage = resultBM.Usermessage;
                        resultBM.Result = 0L;
                        return resultBM;
                    }
                }


                var virtualXmlHelperModel = await this.ObtenDatosParaFacturar(timbradoInfo);

                if (virtualXmlHelperModel == null)
                {

                    resultBM = await this.Facturacion_DeshacerPreparacion(timbradoInfo);
                    if (resultBM != null && resultBM.Result < 0) { return resultBM; }

                    resultBM = new BaseResultBindingModel();
                    resultBM.Usermessage = "No se pudieron obtener los datos para facturacion";
                    resultBM.Devmessage = resultBM.Usermessage;
                    resultBM.Result = -1L;
                    return resultBM;
                }

                virtualXmlHelperModel.RutaXml = documentoTimbrado;

                VirtualXmlHelper virtualXmlHelper = new VirtualXmlHelper(DBValues._VERSION_FACTURACION, dispatcherMethodCall, virtualXmlHelperModel);

                //virtualXmlHelper.ComprobanteInfo!.Fecha = (doctoAFacturar.Docto_fact_elect_Timbradofechafactura ?? DateTime.Now).AddMinutes(-5).ToLocalTime().ToDateTime().ToString("yyyy-MM-dd'T'HH:mm:ss");

                var resultGeneracion = "";
                if (virtualXmlHelper.ComprobanteInfo?.TipoComprobante == "P")
                    resultGeneracion = virtualXmlHelper.GenerarPago();
                else
                    resultGeneracion = virtualXmlHelper.GenerarDocumento();

                if(resultGeneracion != "")
                {
                    resultBM.Usermessage = "Error al generar la facturacion " + resultGeneracion;
                    resultBM.Devmessage = resultBM.Usermessage;
                    resultBM.Result = -1L;
                    return resultBM;
                }

                string messageGuardarInfoTimbrado = "";
                if(Facturacion_ObtenerDatosDeDocumentoTimbrado(ref timbradoInfo,
                                                      documentoTimbrado, ref messageGuardarInfoTimbrado))
                {
                    resultBM = await this.Facturacion_GuardarDatosTimbrado(timbradoInfo);
                    if (resultBM?.Result < 0)
                    {
                        return resultBM;
                    }
                }






                return resultBM;
            }
            catch (Exception ex)
            {
                if (seHizoPreparacion)
                {
                    resultBM = await this.Facturacion_DeshacerPreparacion(timbradoInfo);
                    if (resultBM != null && resultBM.Result < 0) { return resultBM; }
                }

                resultBM = new BaseResultBindingModel();
                resultBM.Usermessage = "No se pudieron obtener los datos para facturacion";
                resultBM.Devmessage = resultBM.Usermessage;
                resultBM.Result = -1L;
                return resultBM;
            }
        }



        //DONE2 MLG 2025 Migracion web out
        public async Task<BaseResultBindingModel?> Factura_Electronica_Preparar(TimbradoInfo timbradoInfo)
        {
            

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Factura_Electronica_Preparar";

            try
            {


                var contentJson = JsonSerializer.Serialize<Cfdi_ApiParam>(new Cfdi_ApiParam()
                {
                    TimbradoInfo = timbradoInfo
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



        public async Task<VirtualXmlHelperModel?> ObtenDatosParaFacturar(TimbradoInfo timbradoInfo)
        {


            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/ObtenDatosParaFacturar";

            try
            {


                var contentJson = JsonSerializer.Serialize<Cfdi_ApiParam>(new Cfdi_ApiParam()
                {
                    TimbradoInfo = timbradoInfo
                });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<VirtualXmlHelperModel?>();
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


        public async Task<BaseResultBindingModel?> Facturacion_GuardarDatosTimbrado(TimbradoInfo timbradoInfo)
        {


            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Facturacion_GuardarDatosTimbrado";

            try
            {


                var contentJson = JsonSerializer.Serialize<Cfdi_ApiParam>(new Cfdi_ApiParam()
                {
                    TimbradoInfo = timbradoInfo
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



        public async Task<BaseResultBindingModel?> Facturacion_DeshacerPreparacion(TimbradoInfo timbradoInfo)
        {


            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Facturacion_DeshacerPreparacion";

            try
            {


                var contentJson = JsonSerializer.Serialize<Cfdi_ApiParam>(new Cfdi_ApiParam()
                {
                    TimbradoInfo = timbradoInfo
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

        public string Facturacion_FileLocalLocation_XML_Timbrados(long tipoDoctoId, ParametroBindingModel parametro, string? tipocomprobanteespecial)
        {
            string factElectFolder = parametro.Fact_elect_folder ?? "";


            if (tipocomprobanteespecial != null && tipocomprobanteespecial.Equals("T"))
                return FileLocalLocation_CT_XML_Timbrados.Replace("\\sampdata", factElectFolder.Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location))); ;
            if (tipoDoctoId == DBValues._DOCTO_TIPO_RECIBOELECTRONICO)
                return FileLocalLocation_AE_XML_Timbrados.Replace("\\sampdata", factElectFolder.Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)));
            if (tipoDoctoId == DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO)
                return FileLocalLocation_DE_XML_Timbrados.Replace("\\sampdata", factElectFolder.Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location))); ;
            return FileLocalLocation_FE_XML_Timbrados.Replace("\\sampdata", factElectFolder.Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location))); ;
        }

        public string Facturacion_FileLocalLocation_FE_IMG(ParametroBindingModel parametro, long tipoDoctoId, string tipoComprobante = "")
        {
            if (tipoComprobante != null && tipoComprobante.Equals("T"))
                return FileLocalLocation_CT_IMG.Replace("\\sampdata", (parametro.Fact_elect_folder ?? "").Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)));
            if (tipoDoctoId == DBValues._DOCTO_TIPO_RECIBOELECTRONICO)
                return FileLocalLocation_AE_IMG.Replace("\\sampdata", (parametro.Fact_elect_folder ?? "").Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)));
            if (tipoDoctoId == DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO)
                return FileLocalLocation_DE_IMG.Replace("\\sampdata", (parametro.Fact_elect_folder ?? "").Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location))); ;
            return FileLocalLocation_FE_IMG.Replace("\\sampdata", (parametro.Fact_elect_folder ?? "").Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location))); ;
        }


        public static string obtainPrefixByTipoComprobante(string? tipoComprobante)
        {
            return tipoComprobante != null && tipoComprobante.Equals("T") ? "T_" : "";
        }


        public bool Facturacion_ObtenerDatosDeDocumentoTimbrado(ref TimbradoInfo timbradoInfo,
                                                      string documentoTimbrado, ref string message)
        {

            message = "";

            //create new instance of XmlDocument
            XmlDocument doc = new XmlDocument();
            //load from file
            doc.Load(documentoTimbrado);

            XmlNamespaceManager nsmRequest = new XmlNamespaceManager(doc.NameTable);
            nsmRequest.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/4");
            nsmRequest.AddNamespace("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital");
            //CiberSAT5
            XmlNode? TimbreFiscalNode = doc.SelectSingleNode("//cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital", nsmRequest);
            XmlElement? elmTimbreFiscalNode = (XmlElement?)TimbreFiscalNode;


            XmlNode? ComprobanteNode = doc.SelectSingleNode("//cfdi:Comprobante", nsmRequest);
            XmlElement? comprobanteNode = (XmlElement?)ComprobanteNode;

            if (elmTimbreFiscalNode == null || comprobanteNode == null)
            {
                message = "No hay suficientes datos";
                return false;
            }


            timbradoInfo.Timbradouuid = elmTimbreFiscalNode.GetAttribute("UUID");
            timbradoInfo.Timbradofecha = elmTimbreFiscalNode.GetAttribute("FechaTimbrado");
            timbradoInfo.Timbradocertsat = elmTimbreFiscalNode.GetAttribute("NoCertificadoSAT");
            timbradoInfo.Timbradosellosat = elmTimbreFiscalNode.GetAttribute("SelloSAT");
            timbradoInfo.Timbradosellocfdi = elmTimbreFiscalNode.GetAttribute("SelloCFD");
            timbradoInfo.Timbradoformapagosat = comprobanteNode.GetAttribute("FormaPago");




            return true;
        }



    }

}



