
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
using IposV3.Services.FacturaElectronica;

namespace Controllers.Controller
{

    public class CfdiController 
    {






        FacturaElectronicaService _facturaElectronicaService;
        IDbContextFactory<ApplicationDbContext> _operationsContextFactory;
        public CfdiController(
            FacturaElectronicaService facturaElectronicaService,
            IDbContextFactory<ApplicationDbContext> operationsContextFactory)
        {
            _facturaElectronicaService = facturaElectronicaService;
            _operationsContextFactory = operationsContextFactory;
        }



        public bool Factura_Electronica_Preparar(TimbradoInfo timbradoInfo,
                                                out string resultMessage)
        {


            //bool bSuccess = true;
            resultMessage = "";

            using (var operationsDbContext = this._operationsContextFactory.CreateDbContext())
            {
                using (var transaction = operationsDbContext.Database.BeginTransaction())
                {

                    try
                    {

                        var doctoAFacturar = operationsDbContext.Docto.AsNoTracking()
                                                                 .Include(d => d.Docto_fact_elect)
                                                                 .Include(d => d.Docto_comprobantes)
                                                                 .FirstOrDefault(d => d.EmpresaId == timbradoInfo.EmpresaId && d.SucursalId == timbradoInfo.SucursalId &&
                                                                             d.Id == timbradoInfo.DoctoId);


                        if (doctoAFacturar == null)
                        {
                            resultMessage = "No se encontro el documento a facturar";
                            transaction.Rollback();
                            return false;
                        }

                        if (timbradoInfo.Tipocomprobanteespecial != "T" && doctoAFacturar.Docto_fact_elect?.Timbradouuid != null &&
                            doctoAFacturar.Docto_fact_elect?.Timbradouuid.Length > 2)
                        {

                            resultMessage = "El documento ya esta facturado";
                            transaction.Rollback();
                            return false;
                        }

                        if (timbradoInfo.Tipocomprobanteespecial == "T")
                        {

                            var doctoComprobante = doctoAFacturar?.Docto_comprobantes?.FirstOrDefault(y => y.Tipocomprobante == timbradoInfo.Tipocomprobanteespecial);

                            if (doctoComprobante != null)
                            {

                                resultMessage = "El documento de este tipo de comprobante ya esta facturado";
                                transaction.Rollback();
                                return false;
                            }
                        }

                        string messageOut = "";

                        var prefixComprobante = obtainPrefixByTipoComprobante(timbradoInfo.Tipocomprobanteespecial);
                        bool bSuccessPreparacion = _facturaElectronicaService.Factura_Electronica_Preparar(timbradoInfo.EmpresaId, timbradoInfo.SucursalId, timbradoInfo.DoctoId, timbradoInfo.Tipocomprobanteespecial,
                                                                                                            operationsDbContext, out messageOut);

                        doctoAFacturar = operationsDbContext.Docto.AsNoTracking()
                                                                 .Include(d => d.Docto_fact_elect)
                                                                 .FirstOrDefault(d => d.EmpresaId == timbradoInfo.EmpresaId && d.SucursalId == timbradoInfo.SucursalId &&
                                                                             d.Id == timbradoInfo.DoctoId);

                        if (doctoAFacturar == null)
                            throw new Exception("Docto no encontrado");


                        if (!bSuccessPreparacion)
                        {

                            resultMessage = "No se pudo preparar el resultado";
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


            }

            return true;

        }


        public bool ObtenDatosParaFacturar(TimbradoInfo timbradoInfo,
                                              out VirtualXmlHelperModel virtualXmlHelper,  out string resultMessage)
        {


            //bool bSuccess = true;
            resultMessage = "";
            virtualXmlHelper = new VirtualXmlHelperModel();

            using (var operationsDbContext = this._operationsContextFactory.CreateDbContext())
            {
                    try
                    {

                        if (!_facturaElectronicaService.Factura_Electronica_FillAll(timbradoInfo.EmpresaId, timbradoInfo.SucursalId, timbradoInfo.DoctoId,
                                "", true, timbradoInfo.Tipocomprobanteespecial, timbradoInfo.Generarcartaporte,
                                 operationsDbContext, out resultMessage, out virtualXmlHelper))
                        {
                            resultMessage = "No se pudo obtener la informacion de factura";
                            return false;

                        }



                    }
                    catch (Exception ex)
                    {
                        //bSuccess = false;
                        resultMessage = ex.Message;

                        return false;
                    }
                    finally
                    {
                    }



            }

            return true;

        }



        public bool Facturacion_GuardarDatosTimbrado(TimbradoInfo timbradoInfo,
                                                out string resultMessage)
        {


            //bool bSuccess = true;
            resultMessage = "";

            using (var operationsDbContext = this._operationsContextFactory.CreateDbContext())
            {
                using (var transaction = operationsDbContext.Database.BeginTransaction())
                {

                    try
                    {

                        string messageOut = "";

                        if (!_facturaElectronicaService.Facturacion_GuardarDatosTimbrado(timbradoInfo, operationsDbContext, out messageOut))

                        {

                            resultMessage = messageOut;
                            transaction.Rollback();
                            return false;

                        }

                        if (!_facturaElectronicaService.Factura_Electronica_GuardarCfdiInfo(timbradoInfo, operationsDbContext, out messageOut))

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


            }

            return true;

        }


        public bool Facturacion_DeshacerPreparacion(TimbradoInfo timbradoInfo,
                                                out string resultMessage)
        {


            resultMessage = "";
            return true;

        }

        public static string obtainPrefixByTipoComprobante(string? tipoComprobante)
        {
            return tipoComprobante != null && tipoComprobante.Equals("T") ? "T_" : "";
        }

        


    }
}

