
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
    public class PuntoCompraController
    {


        private IDbContextFactory<ApplicationDbContext> _operationsContextFactory;
        private ProveeduriaService _proveeduriaService;

        public PuntoCompraController(
            ProveeduriaService proveeduriaService,
            IDbContextFactory<ApplicationDbContext> operationsContextFactory)
        {
            this._operationsContextFactory = operationsContextFactory;
            this._proveeduriaService = proveeduriaService;
        }

        public List<V_movto_proveeduriaWFBindingModel> Select_V_movto_proveeduria_List(long empresaId, long sucursalId, long doctoId)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            return _proveeduriaService.Movto_proveeduria(empresaId, sucursalId, doctoId, applicationDbContext)
                .Select(m => { return (V_movto_proveeduriaWFBindingModel)V_movto_proveeduriaWFBindingModel.CreateFromAnonymous(m); }).ToList();
           
        }


        public List<V_docto_proveeduriaWFBindingModel> Select_V_docto_proveeduria_List(long empresaId, long sucursalId,
                                                long? usuarioId, long tipoDoctoId, long estatusDoctoId,
                                                DateTimeOffset fechaIni, DateTimeOffset fechaFin, BoolCS corteActual,
                                                long? almacenId, BoolCS todosAlmacenes, BoolCS porFecha, BoolCS todosUsuarios)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            return _proveeduriaService.Docto_proveeduria(empresaId, sucursalId,
                                                        usuarioId, tipoDoctoId, estatusDoctoId,
                                                        fechaIni, fechaFin, corteActual,
                                                        almacenId, todosAlmacenes, porFecha, todosUsuarios, applicationDbContext)
                .Select(m => { return (V_docto_proveeduriaWFBindingModel)V_docto_proveeduriaWFBindingModel.CreateFromAnonymous(m); }).ToList();

        }


        public V_preciosProd_RefBindingModel? Precioprod_ref_prov(long empresaId, long sucursalId,
                                                long productoId, long proveedorId, decimal cantidad)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            return _proveeduriaService.Precioprod_ref_prov(empresaId, sucursalId, productoId, proveedorId, cantidad, applicationDbContext)
                .Select(p => new V_preciosProd_RefBindingModel()
                {
                    Preciolista = p.PrecioLista,
                    Preciominimo = p.PrecioMinimo,
                    Preciotraspaso = p.PrecioTraspaso,
                    Costo = p.Costo

                })
                .FirstOrDefault();
        }






        public BaseResultBindingModel Docto_prov_insert(DoctoProvTrans doctoProvTrans)
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
                        _proveeduriaService.Docto_prov_insert(doctoProvTrans, ref doctoId, operationsDbContext);
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

        public BaseResultBindingModel Docto_prov_save(long empresaId, long sucursalId, long id, long estatusDoctoId)
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

                        _proveeduriaService.Docto_prov_save(empresaId, sucursalId, id, estatusDoctoId, operationsDbContext);
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




        public BaseResultBindingModel Docto_prov_delete(long empresaId, long sucursalId, long id)
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

                        _proveeduriaService.Docto_prov_delete(empresaId, sucursalId, id, operationsDbContext);

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




        public BaseResultBindingModel Docto_prov_cancel(long empresaId, long sucursalId,
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

                        _proveeduriaService.Docto_prov_cancel(empresaId, sucursalId, doctoId, creadoPorId,
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




        public BaseResultBindingModel Movto_prov_insert(MovtoProvTrans movtoProvTrans)
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
                        _proveeduriaService.Movto_prov_insert(movtoProvTrans, ref movtoId, operationsDbContext);
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





        public BaseResultBindingModel Movto_prov_delete(long empresaId, long sucursalId, long id)
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

                        _proveeduriaService.Movto_prov_delete(empresaId, sucursalId, id, operationsDbContext);
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



        public BaseResultBindingModel Docto_prov_and_payments_save(long empresaId, long sucursalId, long id,
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
                        _proveeduriaService.Docto_prov_and_payments_save(empresaId, sucursalId, id, DBValues._DOCTO_ESTATUS_COMPLETO,
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
