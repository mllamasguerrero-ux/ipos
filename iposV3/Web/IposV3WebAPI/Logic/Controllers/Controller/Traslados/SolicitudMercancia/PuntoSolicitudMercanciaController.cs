
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
    public class PuntoSolicitudMercanciaController
    {


        private IDbContextFactory<ApplicationDbContext> _operationsContextFactory;
        private SolicitudMercanciaService _solicitudMercanciaService;

        public PuntoSolicitudMercanciaController(
            SolicitudMercanciaService solicitudMercanciaService,
            IDbContextFactory<ApplicationDbContext> operationsContextFactory)
        {
            this._operationsContextFactory = operationsContextFactory;
            this._solicitudMercanciaService = solicitudMercanciaService;
        }

        public List<Docto_solicitud_mercanciaWFBindingModel> Select_docto_traslado_rec_List(Docto_solic_merc_lstParamWFBindingModel param
            )
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            return _solicitudMercanciaService.Docto_solicitud_mercancia((param.EmpresaId ?? 0), (param.SucursalId ?? 0), (param.Usuarioid ?? 0),
                                                                       (param.TipoDoctoId ?? 0), (param.SoloPendientes == BoolCS.S), (param.SubTipoDoctoId ?? 0),
                                                                       (param.FechaIni ?? DateTimeOffset.UtcNow.AddDays(-1)), (param.FechaFin ?? DateTimeOffset.UtcNow.AddDays(1)),
                                                                       applicationDbContext)
                .Select(m => { return Docto_solicitud_mercanciaWFBindingModel.CreateFromAnonymous(m); }).ToList();

        }

        public List<Movto_solicitud_mercanciaWFBindingModel> Select_movto_solicitud_mercancia_List(Movto_solic_merc_lstParamWFBindingModel param)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            return _solicitudMercanciaService.Movto_solicitud_mercancia((param.EmpresaId ?? 0), (param.SucursalId ?? 0), (param.DoctoId ?? 0), applicationDbContext)
                .Select(m => { return Movto_solicitud_mercanciaWFBindingModel.CreateFromAnonymous(m); }).ToList();

        }



        public BaseResultBindingModel Docto_solicitud_mercancia_insert(DoctoSolicitudMercanciaTrans doctoProvTrans)
        {
            var resultBM = new BaseResultBindingModel();
            resultBM.Usermessage = "";
            resultBM.Devmessage = "";
            resultBM.Result = 0L;

            using (var operationsDbContext = this._operationsContextFactory.CreateDbContext())
            {
                using (var transaction = operationsDbContext.Database.BeginTransaction())
                {
                    try
                    {
                        long? doctoId = null;
                        _solicitudMercanciaService.Docto_solicitud_mercancia_insert(doctoProvTrans, ref doctoId, operationsDbContext);
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



        public BaseResultBindingModel Movto_solicitud_mercancia_insert(MovtoSolicitudMercanciaTrans movtoProvTrans)
        {
            var resultBM = new BaseResultBindingModel();
            resultBM.Usermessage = "";
            resultBM.Devmessage = "";
            resultBM.Result = 0L;

            using (var operationsDbContext = this._operationsContextFactory.CreateDbContext())
            {

                using (var transaction = operationsDbContext.Database.BeginTransaction())
                {

                    try
                    {
                        long? movtoId = null;
                        _solicitudMercanciaService.Movto_solicitud_mercancia_insert(movtoProvTrans, ref movtoId, operationsDbContext);
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



        public BaseResultBindingModel Docto_solicitud_mercancia_save(long empresaId, long sucursalId, long id, long estatusDoctoId)
        {

            var resultBM = new BaseResultBindingModel();
            resultBM.Usermessage = "";
            resultBM.Devmessage = "";
            resultBM.Result = 0L;

            using (var operationsDbContext = this._operationsContextFactory.CreateDbContext())
            {
                using (var transaction = operationsDbContext.Database.BeginTransaction())
                {
                    try
                    {

                        _solicitudMercanciaService.Docto_solicitud_mercancia_save(empresaId, sucursalId, id, estatusDoctoId, operationsDbContext);
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
