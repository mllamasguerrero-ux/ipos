
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
using Castle.Core.Logging;

namespace Controllers.Controller
{
    public class PuntoTrasladoRecepcionController : BaseGenericController
    {


        private OperationsContextFactory _operationsContextFactory;
        private TrasladoRecepcionService _trasladoRecepcionService;

        public PuntoTrasladoRecepcionController(
            TrasladoRecepcionService trasladoRecepcionService,
            OperationsContextFactory operationsContextFactory)
        {
            this._operationsContextFactory = operationsContextFactory;
            this._trasladoRecepcionService = trasladoRecepcionService;
        }

        public List<Docto_traslado_recWFBindingModel> Select_docto_traslado_rec_List(Docto_traslado_rec_lstParamWFBindingModel param
            )
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            return _trasladoRecepcionService.Docto_traslados_recibidos((param.EmpresaId ?? 0), (param.SucursalId ?? 0), (param.Usuarioid ?? 0), 
                                                                       (param.TipoDoctoId ?? 0), (param.EstatusDoctoId ?? 0), 
                                                                       (param.FechaIni ?? DateTimeOffset.UtcNow.AddDays(-1)), (param.FechaFin ?? DateTimeOffset.UtcNow.AddDays(1)), 
                                                                       applicationDbContext)
                .Select(m => { return Docto_traslado_recWFBindingModel.CreateFromAnonymous(m); }).ToList();

        }

        public List<Movto_traslado_recWFBindingModel> Select_movto_traslado_rec_List(Movto_traslado_rec_lstParamWFBindingModel param)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            return _trasladoRecepcionService.Movto_traslados_recibidos((param.EmpresaId ?? 0), (param.SucursalId ?? 0), (param.DoctoId ?? 0), applicationDbContext)
                .Select(m => { return Movto_traslado_recWFBindingModel.CreateFromAnonymous(m); }).ToList();

        }


        public BaseResultBindingModel Recibir_traslado(
                                            //long empresaId, long sucursalId, long doctoARecibirId, long usuarioId,
                                            //long? almacenId, string? referencias,
                                            Recibir_traslado_ParamWFBindingModel param,
                                            List<Recepcion_movto_traslado_impo> movtosARecibir,
                                            ref long? doctoDevolucionId)
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
                        _trasladoRecepcionService.Recibir_traslado((param.EmpresaId ?? 0),  (param.SucursalId ?? 0), (param.DoctoARecibirId ?? 0),
                                                                        (param.UsuarioId ?? 0), param.AlmacenId, param.Referencias, 
                                                                        movtosARecibir, ref doctoDevolucionId, operationsDbContext);
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
                        if (docto != null)
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
