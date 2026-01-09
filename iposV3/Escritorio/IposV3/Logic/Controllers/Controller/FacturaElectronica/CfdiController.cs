
using BindingModels;
using Controllers.Controller;
using IposV3.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Npgsql;
//--using Syncfusion.Data.Extensions;
using System;
using IposV3.Extensions;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Npgsql.PostgresTypes.PostgresCompositeType;
using KendoNET.DynamicLinq;
//--using Syncfusion.Windows.Shared;
using Castle.Core.Internal;
using IposV3.Services;
using System.Xml;

namespace Controllers.Controller
{

    public class CfdiController : BaseGenericController
    {

        public const string FileLocalLocation_FE_XML_Timbrados = "\\sampdata\\facturaelectronica\\XML\\Timbrados";
        public const string FileLocalLocation_FE_IMG = "\\sampdata\\facturaelectronica\\IMG";

        public const string FileLocalLocation_DE_XML_Timbrados = "\\sampdata\\devolucionelectronica\\XML\\Timbrados";
        public const string FileLocalLocation_DE_IMG = "\\sampdata\\devolucionelectronica\\IMG";

        public const string FileLocalLocation_AE_XML_Timbrados = "\\sampdata\\abonoselectronicos\\XML\\Timbrados";
        public const string FileLocalLocation_AE_IMG = "\\sampdata\\abonoselectronicos\\IMG";

        public const string FileLocalLocation_CT_XML_Timbrados = "\\sampdata\\comprobantetraslado\\XML\\Timbrados";
        public const string FileLocalLocation_CT_IMG = "\\sampdata\\comprobantetraslado\\IMG";





        FacturaElectronicaService _facturaElectronicaService;
        OperationsContextFactory _operationsContextFactory;
        public CfdiController(
            FacturaElectronicaService facturaElectronicaService,
            OperationsContextFactory operationsContextFactory)
        {
            _facturaElectronicaService = facturaElectronicaService;
            _operationsContextFactory = operationsContextFactory;
        }


        public bool GenerarFacturaElectronica(long empresaId, long sucursalId, long doctoId, string? tipocomprobanteespecial, bool generarcartaporte,
                                              IposV3.Services.FacturaElectronica.VirtualXmlHelper.DispatcherDelegate? dispatcherMethodCall, out string resultMessage)
        {


            //bool bSuccess = true;
            resultMessage = "";

            using (var operationsDbContext = this._operationsContextFactory.Create())
            {
                using (var transaction = operationsDbContext.Database.BeginTransaction())
                {

                    try
                    {
                        var parametro = operationsDbContext.Parametro.AsNoTracking()
                                                                 .FirstOrDefault(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId);

                        if (parametro == null)
                        {
                            resultMessage = "No se encontro el parametro a facturar";
                            transaction.Rollback();
                            return false;
                        }

                        var doctoAFacturar = operationsDbContext.Docto.AsNoTracking()
                                                                 .Include(d => d.Docto_fact_elect)
                                                                 .Include(d => d.Docto_comprobantes)
                                                                 .FirstOrDefault(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId &&
                                                                             d.Id == doctoId);


                        if (doctoAFacturar == null)
                        {
                            resultMessage = "No se encontro el documento a facturar";
                            transaction.Rollback();
                            return false;
                        }

                        if(tipocomprobanteespecial != "T" && doctoAFacturar.Docto_fact_elect?.Timbradouuid != null &&
                            doctoAFacturar.Docto_fact_elect?.Timbradouuid.Length > 2)
                        {

                            resultMessage = "El documento ya esta facturado";
                            transaction.Rollback();
                            return false;
                        }

                        if (tipocomprobanteespecial == "T")
                        {

                            var doctoComprobante = doctoAFacturar?.Docto_comprobantes?.FirstOrDefault(y => y.Tipocomprobante == tipocomprobanteespecial);

                            if (doctoComprobante != null)
                            {

                                resultMessage = "El documento de este tipo de comprobante ya esta facturado";
                                transaction.Rollback();
                                return false;
                            }
                        }

                        string messageOut = "";

                        var prefixComprobante = obtainPrefixByTipoComprobante(tipocomprobanteespecial);
                        bool bSuccessPreparacion = _facturaElectronicaService.Factura_Electronica_Preparar(empresaId, sucursalId, doctoId, tipocomprobanteespecial,
                                                                                                            operationsDbContext, out messageOut);

                        doctoAFacturar = operationsDbContext.Docto.AsNoTracking()
                                                                 .Include(d => d.Docto_fact_elect)
                                                                 .FirstOrDefault(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId &&
                                                                             d.Id == doctoId);

                        if (doctoAFacturar == null)
                            throw new Exception("Docto no encontrado");


                        string documentoTimbrado = Facturacion_FileLocalLocation_XML_Timbrados(doctoAFacturar.Tipodoctoid!.Value, parametro, tipocomprobanteespecial) + "\\" + prefixComprobante + (doctoAFacturar.Docto_fact_elect?.Seriesat ?? "") + (doctoAFacturar.Docto_fact_elect?.Foliosat?.ToString() ?? "") + ".xml";

                        if (documentoTimbrado == null || documentoTimbrado.Trim().Length == 0)
                        {

                            resultMessage = "No se pudo obtener la locacion del timbrado";
                            transaction.Rollback();
                            return false;
                        }


                        if(!bSuccessPreparacion)
                        {

                            resultMessage = "No se pudo preparar el resultado";
                            transaction.Rollback();
                            return false;
                        }


                        bool bSuccessFacturacion = _facturaElectronicaService.Factura_Electronica_Generar(empresaId, sucursalId, doctoId,
                                                    documentoTimbrado, true, true, tipocomprobanteespecial, generarcartaporte,
                                                    operationsDbContext, 
                                                    dispatcherMethodCall, 
                                                    out messageOut);


                        if (!bSuccessFacturacion)
                        {

                            resultMessage = messageOut == null ? "No se pudo concretar la facturacion electronica" :
                                            messageOut;
                            transaction.Rollback();
                            return false;
                        }


                        if (!_facturaElectronicaService.Facturacion_GuardarDatosTimbrado(empresaId, sucursalId, doctoId,
                                                             documentoTimbrado, tipocomprobanteespecial, operationsDbContext, out messageOut))
                            
                        {

                            resultMessage = messageOut;
                            transaction.Rollback();
                            return false;

                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        //bSuccess = false;
                        resultMessage = ex.Message;
                        //error handling ...
                        if (transaction != null) transaction.Rollback();

                        return false;
                    }
                    finally
                    {
                    }


                }


                using (var transaction = operationsDbContext.Database.BeginTransaction())
                {

                    try
                    {
                        string messageOut = "";
                        if (!_facturaElectronicaService.Factura_Electronica_GuardarCfdiInfo(empresaId, sucursalId, doctoId,
                            false, tipocomprobanteespecial, generarcartaporte, operationsDbContext,
                            dispatcherMethodCall,
                            out messageOut))

                        {

                            resultMessage = messageOut;
                            transaction.Rollback();
                            return false;

                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        //bSuccess = false;
                        resultMessage = ex.Message;
                        //error handling ...
                        if (transaction != null) transaction.Rollback();
                    }
                    finally
                    {
                    }
                }





            }

            return true;

        }


        public string Facturacion_FileLocalLocation_XML_Timbrados(long tipoDoctoId, Parametro parametro , string? tipocomprobanteespecial)
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

        public string Facturacion_FileLocalLocation_FE_IMG(Parametro parametro, long tipoDoctoId, string tipoComprobante = "")
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

        


    }
}

