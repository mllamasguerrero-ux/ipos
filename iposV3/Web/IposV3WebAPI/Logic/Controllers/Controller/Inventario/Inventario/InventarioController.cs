
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
    public class InventarioController
    {


        private IDbContextFactory<ApplicationDbContext> _operationsContextFactory;
        private InventarioService _inventarioService;
        private InventarioOperativoService _inventarioOperativoService;

        public InventarioController(
            InventarioService inventarioService,
            IDbContextFactory<ApplicationDbContext> operationsContextFactory,
            InventarioOperativoService inventarioOperativoService)
        {
            this._operationsContextFactory = operationsContextFactory;
            this._inventarioService = inventarioService;
            this._inventarioOperativoService = inventarioOperativoService;
        }

        public Fnc_verify_existenceResult Verify_existence(Fnc_verify_existenceParam param)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

           var hayExistencia = BoolCS.N;
           var existencia = 0m;
           var existenciaParaArmarKit = 0m;
           var existenciaTotal = 0m;
           var enProcesoDeSalida = 0m;
            _inventarioService.VerificarExistencia(param.P_empresaid!.Value, param.P_sucursalid!.Value,
                                                param.P_productoid!.Value, param.P_cantidad!.Value,
                                                param.P_tipodoctoid!.Value, param.P_almacenid!.Value,
                                                param.P_lote, param.P_fechavence, param.P_ignorealmacen, param.P_ignorelote, param.P_ignoreenprocesosalida, param.P_ignoreparaarmar,
                                                param.P_onlyverify, param.P_movtorefid,
                                                out hayExistencia, out existencia, out existenciaParaArmarKit,
                                                out existenciaTotal, out enProcesoDeSalida, applicationDbContext);
            return new Fnc_verify_existenceResult()
            {

                Hayexistencia = hayExistencia,
                Usermessage = "",
                Devmessage = "",
                Existencia = existencia,
                Existenciaparaarmarkit = existenciaParaArmarKit,
                Existenciatotal = existenciaTotal,
                Enprocesodesalida = enProcesoDeSalida,
                Result = 0
            };

           
        }



        public List<V_inventario_doctoWFBindingModel> V_inventario_doctoList(V_inventario_doctoParamBindingModel itemParam)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            List<V_inventario_doctoWFBindingModel> listToReturn = new List<V_inventario_doctoWFBindingModel>();

            try
            {
                listToReturn = _inventarioOperativoService.InventariosHechosList(
                    itemParam.Empresaid!.Value, itemParam.Sucursalid!.Value, itemParam.Estatusdoctoid, itemParam.Activos, itemParam.Desde ?? DateTimeOffset.Now, applicationDbContext)
                                       .OrderByDescending(y => y.Fecha)
                                       .Select(V_inventario_doctoWFBindingModel.CreateFromAnonymous)
                                       .ToList();


                return listToReturn;

            }
            catch
            {
                throw;
            }
        }




        public List<V_inventario_movto_detalleWFBindingModel> V_inventario_movto_detallesList(V_inventario_movto_detalleParamBindingModel itemParam)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            List<V_inventario_movto_detalleWFBindingModel> listToReturn = new List<V_inventario_movto_detalleWFBindingModel>();

            try
            {
                listToReturn = _inventarioOperativoService.Inventario_movto_detalles(
                    itemParam.EmpresaId!.Value, itemParam.SucursalId!.Value, itemParam.AlmacenId, itemParam.DoctoId,
                                        itemParam.Solodiferencias, itemParam.Todoslosproductos,itemParam.KitDesglosado,
                                        applicationDbContext)
                                       .OrderByDescending(y => y.Productoclave)
                                       .Select(V_inventario_movto_detalleWFBindingModel.CreateFromAnonymous)
                                       .ToList();


                return listToReturn;

            }
            catch
            {
                throw;
            }
        }




        public List<Tmp_Inventario_movto_loteInfo> Inventario_movto_loteInfo(
                            long empresaId,
                            long sucursalId,
                            long productoId,
                            long? doctoId,
                            bool soloconexistencias)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            List<Tmp_Inventario_movto_loteInfo> listToReturn = new List<Tmp_Inventario_movto_loteInfo>();

            try
            {
                listToReturn = _inventarioOperativoService.Inventario_movto_loteInfo(
                                        empresaId,
                                        sucursalId,
                                        productoId,
                                        doctoId,
                                        soloconexistencias,
                                        applicationDbContext)
                                       .OrderBy(y => y.Lote).ToList();


                return listToReturn;

            }
            catch
            {
                throw;
            }
        }



        public List<V_inventario_movto_detalleWFBindingModel> V_inventario_movto_detalles_x_locList(V_inventario_movto_detalleParamBindingModel itemParam)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            List<V_inventario_movto_detalleWFBindingModel> listToReturn = new List<V_inventario_movto_detalleWFBindingModel>();

            try
            {
                listToReturn = _inventarioOperativoService.Inventario_movto_detalles_xloc(
                    itemParam.EmpresaId!.Value, itemParam.SucursalId!.Value, itemParam.AlmacenId, itemParam.DoctoId,
                                        itemParam.Solodiferencias, itemParam.Todoslosproductos, itemParam.KitDesglosado,
                                        applicationDbContext)
                                       .OrderByDescending(y => y.Productoclave)
                                       .Select(V_inventario_movto_detalleWFBindingModel.CreateFromAnonymous)
                                       .ToList();


                return listToReturn;

            }
            catch
            {
                throw;
            }
        }


        public List<V_inventario_movto_detalleWFBindingModel> V_inventario_movto_detalles_x_loc_groupedList(V_inventario_movto_detalleParamBindingModel itemParam)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            List<V_inventario_movto_detalleWFBindingModel> listToReturn = new List<V_inventario_movto_detalleWFBindingModel>();

            try
            {
                listToReturn = _inventarioOperativoService.Inventario_movto_detalles_x_loc_grouped(
                    itemParam.EmpresaId!.Value, itemParam.SucursalId!.Value, itemParam.AlmacenId, itemParam.DoctoId,
                                        itemParam.Solodiferencias, itemParam.Todoslosproductos, itemParam.KitDesglosado,
                                        applicationDbContext)
                                       .OrderByDescending(y => y.Productoclave)
                                       .Select(V_inventario_movto_detalleWFBindingModel.CreateFromAnonymous)
                                       .ToList();


                return listToReturn;

            }
            catch
            {
                throw;
            }
        }


        public V_inventario_movto_getInfoWFBindingModel? V_inventario_movto_getInfo(V_inventario_movto_getInfoParamWFBindingModel param)
        {

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            string? v_productonombre = null;
           string? v_productodescripcion = null;
            string? v_productolote = null;
            decimal? v_cantidadteorica = null;
            decimal? v_cantidadfisica = null;
            decimal? v_cantidaddiferencia = null;
            decimal? v_apartados = null;
            decimal? v_pzacaja = null;

            try
            {
                _inventarioOperativoService.Inventario_movto_getInfo(param.EmpresaId!.Value, param.SucursalId!.Value, param.Productoid!.Value, param.Lote,
                                                                     param.Fechavence, param.Doctoid, param.Almacenid, param.Kitdesglosado, param.Mododetalle,
                                                                        out v_productonombre, out v_productodescripcion, out v_productolote,
                                                                        out v_cantidadteorica, out v_cantidadfisica, out v_cantidaddiferencia, out v_apartados, out v_pzacaja,
                                                                        applicationDbContext
                                                                     );
                var movto_info = new V_inventario_movto_getInfoWFBindingModel()
                {


                    Productonombre = v_productonombre,
                    Productodescripcion = v_productodescripcion,
                    Productolote = v_productolote,
                    Cantidadteorica = v_cantidadteorica,
                    Cantidadfisica = v_cantidadfisica,
                    Cantidaddiferencia = v_cantidaddiferencia,
                    Apartados = v_apartados,
                    Pzacaja = v_pzacaja
                    };

                return movto_info;

            }
            catch
            {

                return null;
            }

        }


        public BaseResultBindingModel Docto_inventario_insert(DoctoInventarioTrans doctoTrans, ref long? doctoId)
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
                        doctoId = null;
                        _inventarioOperativoService.Docto_inventario_insert(doctoTrans, ref doctoId, operationsDbContext);
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




        public BaseResultBindingModel Docto_inventario_genCompleto(V_inventario_genComplParamWFBindingModel param)
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
                        _inventarioOperativoService.Docto_inventario_gencompleto(param.EmpresaId!.Value,param.SucursalId!.Value, param.Doctoid!.Value, param.Almacenid, param.Usuarioid!.Value, param.Subtipodoctoid!.Value, operationsDbContext);
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



        public BaseResultBindingModel Docto_inventario_delete(long empresaId, long sucursalId, long id)
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

                        _inventarioOperativoService.Docto_inventario_delete(empresaId, sucursalId, id, operationsDbContext);

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




        public BaseResultBindingModel Docto_inventario_finEdicion(V_inventario_finedicionParamWFBindingModel param)
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
                        _inventarioOperativoService.Docto_inventario_finedicion(param.EmpresaId!.Value, param.SucursalId!.Value, param.Doctoid!.Value,  operationsDbContext);
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


        public BaseResultBindingModel Docto_inventario_cambiarkitdesglosado(
            long empresaId, 
            long sucursalId, 
            long doctoId, 
            BoolCN kitDesglosado)
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
                        _inventarioOperativoService.Docto_inventario_cambiarkitdesglosado(
                            empresaId, sucursalId, doctoId, kitDesglosado, operationsDbContext);
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




        public BaseResultBindingModel Docto_inventario_aplicar(V_inventario_aplicarParamWFBindingModel param)
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
                        _inventarioOperativoService.Docto_inventario_aplicar(param.EmpresaId!.Value, param.SucursalId!.Value, param.Doctoid!.Value, param.Usuarioid!.Value, operationsDbContext);
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

        public BaseResultBindingModel Movto_inventario_insert(MovtoInventarioTrans movtoTrans)
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
                        _inventarioOperativoService.Movto_inventario_insert(movtoTrans, ref movtoId, operationsDbContext);
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


    }
}
