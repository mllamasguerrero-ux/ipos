
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
    public class PuntoVentaController : BaseGenericController
    {


        private OperationsContextFactory _operationsContextFactory;
        private VendeduriaService _vendeduriaService;

        public PuntoVentaController(
            VendeduriaService vendeduriaService,
            OperationsContextFactory operationsContextFactory)
        {
            this._operationsContextFactory = operationsContextFactory;
            this._vendeduriaService = vendeduriaService;
        }

        public List<V_movto_vendeduriaWFBindingModel> Select_V_movto_vendeduria_List(long empresaId, long sucursalId, long doctoId)
        {

            using var applicationDbContext = this._operationsContextFactory.Create();

            return _vendeduriaService.Movto_vendeduria(empresaId, sucursalId, doctoId, applicationDbContext)
                .Select(m => { return (V_movto_vendeduriaWFBindingModel)V_movto_vendeduriaWFBindingModel.CreateFromAnonymous(m); }).ToList();
           
        }


        public List<V_docto_vendeduriaWFBindingModel> Select_V_docto_vendeduria_List(long empresaId, long sucursalId,
                                                long? usuarioId, long tipoDoctoId, long estatusDoctoId,
                                                DateTimeOffset fechaIni, DateTimeOffset fechaFin, BoolCS corteActual,
                                                long? almacenId, BoolCS todosAlmacenes, BoolCS porFecha, BoolCS todosUsuarios)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            return _vendeduriaService.Docto_vendeduria(empresaId, sucursalId,
                                                        usuarioId, tipoDoctoId, estatusDoctoId,
                                                        fechaIni, fechaFin, corteActual,
                                                        almacenId, todosAlmacenes, porFecha, todosUsuarios, applicationDbContext)
                .Select(m => { return (V_docto_vendeduriaWFBindingModel)V_docto_vendeduriaWFBindingModel.CreateFromAnonymous(m); }).ToList();

        }


        public V_preciosProd_RefBindingModel? Precioprod_ref_vend(long empresaId, long sucursalId,
                                                long productoId, long clienteId, decimal cantidad)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            return _vendeduriaService.Precioprod_ref_vend(empresaId, sucursalId, productoId, clienteId, cantidad, applicationDbContext)
                .Select(p => new V_preciosProd_RefBindingModel()
                {
                    Preciolista = p.PrecioLista,
                    Preciominimo = p.PrecioMinimo,
                    Preciotraspaso = p.PrecioTraspaso,
                    Costo = p.Costo,
                    Precio = p.Precio,
                    Espromocion = p.Espromocion,
                    Promocionid = p.Promocionid,
                    Promociondesglose = p.Promociondesglose,
                    Monederoabono = p.Monederoabono,
                    TipoMayoreoLineaIdAplicado = p.TipoMayoreoLineaIdAplicado

                })
                .FirstOrDefault();
        }






        public BaseResultBindingModel Docto_vend_insert(DoctoVendTrans doctoVendTrans)
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
                        _vendeduriaService.Docto_vend_insert(doctoVendTrans, ref doctoId, operationsDbContext);
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

        public BaseResultBindingModel Docto_vend_save(long empresaId, long sucursalId, long id, long estatusDoctoId)
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

                        _vendeduriaService.Docto_vend_save(empresaId, sucursalId, id, estatusDoctoId, operationsDbContext);
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




        public BaseResultBindingModel Docto_vend_delete(long empresaId, long sucursalId, long id)
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

                        _vendeduriaService.Docto_vend_delete(empresaId, sucursalId, id, operationsDbContext);

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




        public BaseResultBindingModel Docto_vend_cancel(long empresaId, long sucursalId,
            long doctoId, long creadoPorId)
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
                        long? doctoCancelacionId = null;

                        _vendeduriaService.Docto_vend_cancel(empresaId, sucursalId, doctoId, creadoPorId,
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




        public BaseResultBindingModel Movto_vend_insert(MovtoVendTrans movtoVendTrans)
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
                        _vendeduriaService.Movto_vend_insert(movtoVendTrans, ref movtoId, operationsDbContext);
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





        public BaseResultBindingModel Movto_vend_delete(long empresaId, long sucursalId, long id)
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

                        _vendeduriaService.Movto_vend_delete(empresaId, sucursalId, id, operationsDbContext);
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



        public BaseResultBindingModel Docto_vend_and_payments_save(long empresaId, long sucursalId, long id,
            List<DoctoPagoDirect> listPagos)
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
                        _vendeduriaService.Docto_vend_and_payments_save(empresaId, sucursalId, id, DBValues._DOCTO_ESTATUS_COMPLETO,
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




        //public void TestTransaction()
        //{

        //    using (var operationsDbContext = this._operationsContextFactory.Create())
        //    {

        //        using (var transaction = operationsDbContext.Database.BeginTransaction())
        //        {
        //            var testx = operationsDbContext.Productoalmacen
        //                                           .FirstOrDefault(x => x.EmpresaId == 5 && x.SucursalId == 4 && x.Productoid == 6);
        //            if(testx != null)
        //            {
        //                testx.Enprocesodesalida += 1;
        //                operationsDbContext.
        //            }
        //        }
        //    }
        //}

    }
}
