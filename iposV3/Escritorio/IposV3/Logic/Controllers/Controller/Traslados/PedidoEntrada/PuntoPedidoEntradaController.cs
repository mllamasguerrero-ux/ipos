
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
using Castle.Core.Internal;
using IposV3.Services;
using Castle.Core.Logging;

namespace Controllers.Controller
{
    public class PuntoPedidoEntradaController : BaseGenericController
    {


        private OperationsContextFactory _operationsContextFactory;
        private PedidoEntradaService _pedidoEntradaService;

        public PuntoPedidoEntradaController(
            PedidoEntradaService pedidoEntradaService,
            OperationsContextFactory operationsContextFactory)
        {
            this._operationsContextFactory = operationsContextFactory;
            this._pedidoEntradaService = pedidoEntradaService;
        }

        public List<Docto_pedido_entradaWFBindingModel> Select_docto_pedido_entrada_List(Docto_ped_entr_lstParamWFBindingModel param
            )
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            return _pedidoEntradaService.Docto_pedido_entrada((param.EmpresaId ?? 0), (param.SucursalId ?? 0), (param.Usuarioid ?? 0),
                                                                       (param.TipoDoctoId ?? 0), (param.SoloPendientes == BoolCS.S), (param.SubTipoDoctoId ?? 0),
                                                                       (param.FechaIni ?? DateTimeOffset.UtcNow.AddDays(-1)), (param.FechaFin ?? DateTimeOffset.UtcNow.AddDays(1)),
                                                                       applicationDbContext)
                .Select(m => { return Docto_pedido_entradaWFBindingModel.CreateFromAnonymous(m); }).ToList();

        }

        public List<Movto_pedido_entradaWFBindingModel> Select_movto_pedido_entrada_List(Movto_ped_entr_lstParamWFBindingModel param)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            return _pedidoEntradaService.Movto_pedido_entrada((param.EmpresaId ?? 0), (param.SucursalId ?? 0), (param.DoctoId ?? 0), applicationDbContext)
                .Select(m => { return Movto_pedido_entradaWFBindingModel.CreateFromAnonymous(m); }).ToList();

        }



        public BaseResultBindingModel Docto_pedido_entrada_insert(DoctoPedidoEntradaTrans doctoProvTrans)
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
                        long? doctoId = null;
                        _pedidoEntradaService.Docto_pedido_entrada_insert(doctoProvTrans, ref doctoId, operationsDbContext);
                        resultBM.Result = doctoId;
                        transaction.Commit();
                        return resultBM;

                    }
                    catch (Exception ex)
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

        public BaseResultBindingModel Movto_pedido_entrada_insert(MovtoPedidoEntradaTrans movtoProvTrans)
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
                        long? movtoId = null;
                        _pedidoEntradaService.Movto_pedido_entrada_insert(movtoProvTrans, ref movtoId, operationsDbContext);
                        resultBM.Result = movtoId;
                        transaction.Commit();
                        return resultBM;

                    }
                    catch (Exception ex)
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


        public BaseResultBindingModel Movto_pedido_entrada_ponercantidadsurtida(MovtoPedidoEntradaTrans movtoProvTrans)
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
                        _pedidoEntradaService.Movto_pedido_entrada_ponercantidadsurtida(movtoProvTrans,  operationsDbContext);
                        resultBM.Result = 1;
                        transaction.Commit();
                        return resultBM;

                    }
                    catch (Exception ex)
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


        public BaseResultBindingModel Docto_pedido_entrada_save(long empresaId, long sucursalId, long id, long estatusDoctoId)
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

                        _pedidoEntradaService.Docto_pedido_entrada_save(empresaId, sucursalId, id, estatusDoctoId, operationsDbContext);
                        transaction.Commit();
                        return resultBM;

                    }
                    catch (Exception ex)
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



        public BaseResultBindingModel Movto_pedido_entrada_ajustarExistencias(long empresaId, long sucursalId, long id, 
                                                                            long usuarioId, long? almacenId)
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

                        _pedidoEntradaService.Movto_pedido_entrada_ajustarExistencias(empresaId, sucursalId, id, usuarioId,  almacenId, operationsDbContext);
                        transaction.Commit();
                        return resultBM;

                    }
                    catch (Exception ex)
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


        public BaseResultBindingModel Docto_surtir_pedido(long empresaId, long sucursalId, long id, long? usuarioId,
                                                          long? almacenId, string? referencias,
                                                          ref long? doctoSurtidoId)
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

                        _pedidoEntradaService.Docto_surtir_pedido(empresaId, sucursalId, id, usuarioId,
                                                                  almacenId, referencias,
                                                                  ref doctoSurtidoId, operationsDbContext);
                        transaction.Commit();
                        return resultBM;

                    }
                    catch (Exception ex)
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


        public BaseResultBindingModel Docto_update_datos_ajustables(long empresaId, long sucursalId, long id, long? usuarioId,
                                                          long? almacenId, string? referencias)
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
                        var docto = operationsDbContext.Docto.FirstOrDefault(x => x.EmpresaId == empresaId && x.SucursalId == sucursalId &&
                                                                                  x.Id == id);  
                        if(docto != null)
                        {
                            docto.Almacenid = almacenId;
                            docto.Referencias = referencias;
                            operationsDbContext.Update(docto);
                            operationsDbContext.SaveChanges();
                        }
                        
                        transaction.Commit();
                        return resultBM;

                    }
                    catch (Exception ex)
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



    }
}