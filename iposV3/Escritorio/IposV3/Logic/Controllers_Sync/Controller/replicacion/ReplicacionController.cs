using BindingModels;
using IposV3.Model;
using DataAccess;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using IposV3.Services;
using Microsoft.EntityFrameworkCore;
using IposV3.Services.Extensions;
using BIPOS.Database.DAO;

namespace Controllers.Controller
{
    public class ReplicacionController
    {

        OperationsContextFactory _operationsContextFactory;
        ReplicacionService _replicacionService;



        public ReplicacionController(
            ReplicacionService replicacionService,
            OperationsContextFactory operationsContextFactory)
        {

            _replicacionService = replicacionService;
            _operationsContextFactory = operationsContextFactory;
        }


        public List<TablasAReplicarWFBindingModel> ListaTablasAReplicar(long empresaId, long sucursalId)
        {

            using (var operationsDbContext = this._operationsContextFactory.Create())
            {
                    try
                    {
                        var lstTablasAReplicar = _replicacionService.ListaTablasAReplicar(empresaId, sucursalId, operationsDbContext)
                                                                    .Select(r => TablasAReplicarWFBindingModel.CreateFromBasic(r))
                                                                    .ToList();
                        
                        return lstTablasAReplicar;

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        throw;
                        //return new List<TablasAReplicar>();

                    }
            }

        }




        public List<GrupoTablasAReplicarWFBindingModel> ListaGrupoTablasAReplicar(long empresaId, long sucursalId)
        {

            using (var operationsDbContext = this._operationsContextFactory.Create())
            {
                try
                {
                    var lstGrupoTablasAReplicarBuffer = _replicacionService.ListaGruposTablasAReplicar(empresaId, sucursalId, operationsDbContext);

                    var lstGrupoTablasAReplicar = lstGrupoTablasAReplicarBuffer.Select(r => GrupoTablasAReplicarWFBindingModel.CreateFromBasic(r))
                                                                .ToList();

                    return lstGrupoTablasAReplicar;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                    //return new List<TablasAReplicar>();

                }
            }

        }



        public BaseResultBindingModel Aplicar_cambios_tablas_a_replicar(long empresaId, long sucursalId, List<string> tablasAReplicar)
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
                        _replicacionService.Aplicar_cambios_tablas_a_replicar(empresaId,  sucursalId,  tablasAReplicar, operationsDbContext);
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



        public void ReplicateData(long empresaid, long sucursalid, string empresaClave, string sucursalFuenteClave, long? usuarioId, string localPath)
        {
            //var fieldList = this.tableinfoDaoProvider.Select_V_field_info_List(null, new V_field_infoParam(empresaid, sucursalid) { P_tablename = "linea", P_schemaname = "catalogos", P_activo = "S" }, null);

            //if(fieldList != null)
            //    Console.WriteLine(fieldList.Count().ToString());


            using (var operationsDbContext = this._operationsContextFactory.Create())
            {
                _replicacionService.ReplicateData(empresaid, sucursalid, empresaClave, sucursalFuenteClave, usuarioId, localPath, operationsDbContext);
            }
        }

    }



}
