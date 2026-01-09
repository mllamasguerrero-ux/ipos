
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
    public class PuntoCompraDevoController
    {


        private IDbContextFactory<ApplicationDbContext> _operationsContextFactory;
        private ProvDevoService _provDevoService;

        public PuntoCompraDevoController(
            ProvDevoService provDevoService,
            IDbContextFactory<ApplicationDbContext> operationsContextFactory)
        {
            this._operationsContextFactory = operationsContextFactory;
            this._provDevoService = provDevoService;
        }

        public List<V_movto_provdevoWFBindingModel> Select_V_movto_provdevo_List(long empresaId, long sucursalId, long doctoId)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            return _provDevoService.Movto_provdevo(empresaId, sucursalId, doctoId, applicationDbContext)
                .Select(m => { return (V_movto_provdevoWFBindingModel)V_movto_provdevoWFBindingModel.CreateFromAnonymous(m); }).ToList();

        }



        public List<V_docto_provdevoWFBindingModel> Select_V_docto_provdevo_List(long empresaId, long sucursalId,
                                                long? usuarioId, long tipoDoctoId, long estatusDoctoId,
                                                DateTimeOffset fechaIni, DateTimeOffset fechaFin)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            return _provDevoService.Docto_provdevo(empresaId, sucursalId,
                                                        usuarioId, tipoDoctoId, estatusDoctoId,
                                                        fechaIni, fechaFin, applicationDbContext)
                .Select(m => { return (V_docto_provdevoWFBindingModel)V_docto_provdevoWFBindingModel.CreateFromAnonymous(m); }).ToList();

        }

        public List<V_docto_prov_to_devoWFBindingModel> Select_V_docto_prov_to_devo_List(long empresaId, long sucursalId,
                                                long? usuarioId, long tipoDoctoId, long estatusDoctoId,
                                                DateTimeOffset fechaIni, DateTimeOffset fechaFin)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            return _provDevoService.Docto_prov_to_devo(empresaId, sucursalId,
                                                        usuarioId, tipoDoctoId, estatusDoctoId,
                                                        fechaIni, fechaFin, applicationDbContext)
                .Select(m => { return (V_docto_prov_to_devoWFBindingModel)V_docto_prov_to_devoWFBindingModel.CreateFromAnonymous(m); }).ToList();

        }


        public List<V_movto_prov_to_devoWFBindingModel> Select_V_movto_prov_to_devo_List(long empresaId, long sucursalId, long? doctoId, long? doctoRefId)
        {

            using (var operationsDbContext = this._operationsContextFactory.CreateDbContext())
            {

                return _provDevoService.Movto_prov_to_devo(empresaId, sucursalId, doctoId, doctoRefId, operationsDbContext)
                .Select(m => { return (V_movto_prov_to_devoWFBindingModel)V_movto_prov_to_devoWFBindingModel.CreateFromAnonymous(m); }).ToList();
            }
        }



        public BaseResultBindingModel Docto_provdevo_insert(DoctoProvDevoTrans doctoProvDevoTrans)
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
                        _provDevoService.Docto_provdevo_insert(doctoProvDevoTrans, ref doctoId, operationsDbContext);
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

        public BaseResultBindingModel Docto_provdevo_save(long empresaId, long sucursalId, long id, long estatusDoctoId)
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

                        _provDevoService.Docto_provdevo_save(empresaId, sucursalId, id, estatusDoctoId, operationsDbContext);
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




        public BaseResultBindingModel Docto_provdevo_delete(long empresaId, long sucursalId, long id)
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

                        _provDevoService.Docto_provdevo_delete(empresaId, sucursalId, id, operationsDbContext);

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




        public BaseResultBindingModel Docto_provdevo_cancel(long empresaId, long sucursalId,
            long doctoId, long creadoPorId)
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
                        long? doctoCancelacionId = null;

                        _provDevoService.Docto_provdevo_cancel(empresaId, sucursalId, doctoId, creadoPorId,
                                                              ref doctoCancelacionId, operationsDbContext);
                        transaction.Commit();
                        resultBM.Result = doctoCancelacionId;
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




        public BaseResultBindingModel Movto_provdevo_insert(MovtoProvDevoTrans movtoProvDevoTrans)
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
                        _provDevoService.Movto_provdevo_insert(movtoProvDevoTrans, ref movtoId, operationsDbContext);
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





        public BaseResultBindingModel Movto_provdevo_delete(long empresaId, long sucursalId, long id)
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

                        _provDevoService.Movto_provdevo_delete(empresaId, sucursalId, id, operationsDbContext);
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



        public BaseResultBindingModel Docto_provdevo_and_payments_save(long empresaId, long sucursalId, long id,
            List<DoctoPagoDirect> listPagos)
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
                        _provDevoService.Docto_provdevo_and_payments_save(empresaId, sucursalId, id, DBValues._DOCTO_ESTATUS_COMPLETO,
                                                                         listPagos, operationsDbContext);

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
