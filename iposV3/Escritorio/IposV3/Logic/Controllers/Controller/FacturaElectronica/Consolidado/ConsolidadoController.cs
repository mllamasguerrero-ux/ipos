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
using IposV3.Services;

namespace Controllers.Controller
{

    public class ConsolidadoController : BaseGenericController
    {


        private OperationsContextFactory _operationsContextFactory;
        private VendeduriaService _vendeduriaService;
        private ProveeduriaService _proveeduriaService;
        private FacturaElectronicaService _facturaElectronicaService;
        private InventarioOperativoService _inventarioOperativeService;

        private ConsolidacionService _consolidacionService;

        public ConsolidadoController(
            ProveeduriaService proveeduriaService,
            VendeduriaService vendeduriaService,
            FacturaElectronicaService facturaElectronicaService,
            InventarioOperativoService inventarioOperativeService,
            ConsolidacionService consolidacionService,
            OperationsContextFactory operationsContextFactory)
        {
            this._operationsContextFactory = operationsContextFactory;
            _vendeduriaService = vendeduriaService;
            _proveeduriaService = proveeduriaService;
            _facturaElectronicaService = facturaElectronicaService;

            _inventarioOperativeService = inventarioOperativeService;
            _consolidacionService = consolidacionService;
        }



        public Tmp_info_porconsolidar ConsolidadoInfo(
            Tmp_config_porconsolidarWFBindingModel config
            )
        {

            using var applicationDbContext = this._operationsContextFactory.Create();

            var lstDoctosPorConsolidar = this._consolidacionService.Docto_porconsolidar(
                                                                            config.EmpresaId!.Value, 
                                                                            config.SucursalId!.Value,
                                                                            config.FechaIni!.Value,
                                                                            config.FechaFin!.Value,
                                                                            config.OmitirVentasFranquicias ?? BoolCN.N,
                                                                            config.IncluirGastos ?? BoolCN.N,
                                                                            config.MaximoMonto ?? 0,
                                                                            config.OmitirVales ?? BoolCN.N,
                                                                            config.SumaCompletaVentas ?? BoolCN.N,
                                                                            config.GrupoUsuarioId,
                                                                            config.OmitirClientesRfc ?? BoolCN.N,
                                                                            config.MaximoPorcentaje ?? 0,
                                                                            config.OmitirPagoTarjeta ?? BoolCN.N,
                                                                            applicationDbContext);


            return new Tmp_info_porconsolidar(
                config.EmpresaId!.Value, 
                config.SucursalId!.Value, 
                config.AplicaMontoMaximoPorDia!.Value, 
                config.MontoMaximoPorDia!.Value, lstDoctosPorConsolidar);
        }



        public BaseResultBindingModel Consolidar(Tmp_config_porconsolidarWFBindingModel config)
        {
            var resultBM = new BaseResultBindingModel();
            resultBM.Usermessage = "";
            resultBM.Devmessage = "";
            resultBM.Result = 0L;

            using (var operationsDbContext = this._operationsContextFactory.Create())
            {

                using (var transaction = operationsDbContext.Database.BeginTransaction())
                {

                    try
                    {


                        long? doctoConsolidarId = null;
                        var resultadoConsolidacion = this._consolidacionService.Consolidar(
                                                                                        config.EmpresaId!.Value,
                                                                                        config.SucursalId!.Value,
                                                                                        config.FechaIni!.Value,
                                                                                        config.FechaFin!.Value,
                                                                                        config.OmitirVentasFranquicias ?? BoolCN.N,
                                                                                        config.IncluirGastos ?? BoolCN.N,
                                                                                        config.MaximoMonto ?? 0,
                                                                                        config.OmitirVales ?? BoolCN.N,
                                                                                        config.SumaCompletaVentas ?? BoolCN.N,
                                                                                        config.GrupoUsuarioId,
                                                                                        config.OmitirClientesRfc ?? BoolCN.N,
                                                                                        config.MaximoPorcentaje ?? 0,
                                                                                        config.OmitirPagoTarjeta ?? BoolCN.N,
                                                                                        config.UsuarioId ?? 0,
                                                                                        ref doctoConsolidarId,
                                                                                        operationsDbContext);


                        if (resultadoConsolidacion)
                        {
                            resultBM.Result = doctoConsolidarId;
                            transaction.Commit();
                            return resultBM;
                        }
                        else
                        {
                            transaction.Rollback();
                            throw new Exception("Ocurrio un error al consolidar");
                        }
                    }
                    catch(Exception ex)
                    {


                        transaction.Rollback();
                        resultBM.Usermessage = ex.Message;
                        resultBM.Devmessage = ex.Message;
                        resultBM.Result = -1L;
                        return resultBM;

                    }


                }
            }
        }

        public void TestGeneral2(long usuarioId)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            var testList = this._consolidacionService.Docto_porconsolidar(1, 1,
                                                                            DateTimeOffset.Now.AddDays(-6),
                                                                            DateTimeOffset.Now.AddDays(1),
                                                                            BoolCN.N,
                                                                            BoolCN.S,
                                                                            0,
                                                                            BoolCN.S,
                                                                            BoolCN.N,
                                                                            null,
                                                                            BoolCN.N,
                                                                            0,
                                                                            BoolCN.N,
                                                                            applicationDbContext);

            Console.WriteLine(testList.Count().ToString());

            //using var transaction = applicationDbContext.Database.BeginTransaction();

            //try
            //{


            //    long? doctoConsolidarId = null;
            //    var resultadoConsolidacion = this._consolidacionService.Consolidar(1, 1,
            //                                                                    DateTimeOffset.Now.AddDays(-6),
            //                                                                    DateTimeOffset.Now.AddDays(1),
            //                                                                    BoolCN.N,
            //                                                                    BoolCN.S,
            //                                                                    0,
            //                                                                    BoolCN.S,
            //                                                                    BoolCN.N,
            //                                                                    null,
            //                                                                    BoolCN.N,
            //                                                                    0,
            //                                                                    BoolCN.N,
            //                                                                    usuarioId,
            //                                                                    ref doctoConsolidarId,
            //                                                                    applicationDbContext);


            //    if (resultadoConsolidacion)
            //        transaction.Commit();
            //    else
            //        transaction.Rollback();
            //}
            //catch
            //{
            //    transaction.Rollback();
            //    throw;
            //}



        }
    }
}
