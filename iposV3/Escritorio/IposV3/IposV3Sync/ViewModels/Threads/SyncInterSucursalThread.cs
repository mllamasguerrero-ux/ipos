using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO.Compression;
using System.Collections;
using System.Security.Permissions;
using System.Windows.Threading;
using Controllers.Controller;
using DataAccess;
using IposV3.Model;
using System.IO;
using Microsoft.EntityFrameworkCore;
using IposV3.Services;

namespace IposV3Sync.ViewModels.Threads
{
    public class SyncInterSucursalThread
    {

        private bool abort = false;
        private Thread p1;
        private Dispatcher dispatcher;

        ImpoExpoController? impoExpoProvider = null;

        private OperationsContextFactory _operationsContextFactory;


        //ISucursal_extControllerProvider sucursal_ExtProvider = null;
        //IEmpresaControllerProvider empresaProvider = null;
        //IUsuarioControllerProvider usuarioProvider = null;



        //IRepltablaControllerProvider repltablaControllerProvider = null;

        public SyncInterSucursalThread(ImpoExpoController impoExpoProvider,
                                        OperationsContextFactory operationsContextFactory
                                        //ISucursal_extControllerProvider sucursal_ExtProvider,
                                        //IEmpresaControllerProvider empresaProvider,
                                        //IUsuarioControllerProvider usuarioProvider,
                                        //IRepltablaControllerProvider repltablaControllerProvider
            )
        {
            dispatcher = Dispatcher.CurrentDispatcher;
            p1 = new Thread(new ThreadStart(ReplData));
            this.impoExpoProvider = impoExpoProvider;
            this._operationsContextFactory = operationsContextFactory;
            //this.sucursal_ExtProvider = sucursal_ExtProvider;
            //this.empresaProvider = empresaProvider;
            //this.usuarioProvider = usuarioProvider;
            //this.repltablaControllerProvider = repltablaControllerProvider;
        }


        public void ReplData()
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            //string refComentario = "";

            string importPath = ImpoExpoConstants.ImpoExpoBasePath;

            if (GlobalVariable.CurrentSession?.CurrentConfiguracionsync == null)
            {
                return;
            }
            else
            {
                int sleepTime = 1000 * 180;

                while (!abort)
                {




                    //var sucursal = this.sucursal_ExtProvider.SelectById(new BindingModels.Sucursal_extBindingModel()
                    //{
                    //    Empresaid = GlobalVariable.CurrentSession.CurrentConfiguracionsync.Empresaid.Value,
                    //    Sucursalid = GlobalVariable.CurrentSession.CurrentConfiguracionsync.Sucursalid.Value,
                    //    Id = GlobalVariable.CurrentSession.CurrentConfiguracionsync.Sucursalid.Value
                    //}).FirstOrDefault();

                    var sucursal = applicationDbContext.Sucursal.AsNoTracking().FirstOrDefault(x =>
                                    x.EmpresaId == GlobalVariable.CurrentSession.CurrentConfiguracionsync.Empresaid!.Value &&
                                    x.Id == GlobalVariable.CurrentSession.CurrentConfiguracionsync.Sucursalid!.Value);

                    //var empresa = this.empresaProvider.SelectById(new BindingModels.EmpresaBindingModel()
                    //{
                    //    Empresaid = GlobalVariable.CurrentSession.CurrentConfiguracionsync.Empresaid.Value,
                    //    Sucursalid = 0,
                    //    Id = GlobalVariable.CurrentSession.CurrentConfiguracionsync.Empresaid.Value
                    //}).FirstOrDefault();


                    if (sucursal == null)
                        throw new Exception("La sucursal no existe");

                    var empresa = applicationDbContext.Empresa.AsNoTracking().FirstOrDefault(
                                                    x => x.Id == GlobalVariable.CurrentSession.CurrentConfiguracionsync.Empresaid!.Value);

                    if (empresa == null)
                        throw new Exception("La empresa no existe");

                    //KendoParams usuarioParam = new KendoParams("", "",
                    //                                        new KendoFilters(new List<KendoFilter>() {
                    //                                        new KendoFilter(GlobalVariable.CurrentSession.CurrentConfiguracionsync.Usuarioiposlocal, "eq", "Username", "S") }, "and"));

                    //var usuario = this.usuarioProvider.SelectList(new UsuarioParam(GlobalVariable.CurrentSession.CurrentConfiguracionsync.Empresaid.Value,
                    //                                                                                    GlobalVariable.CurrentSession.CurrentConfiguracionsync.Sucursalid.Value), usuarioParam)?.FirstOrDefault();


                    var usuario = applicationDbContext.Usuario.AsNoTracking().FirstOrDefault(x =>
                                        x.EmpresaId == GlobalVariable.CurrentSession.CurrentConfiguracionsync.Empresaid!.Value &&
                                        x.SucursalId == GlobalVariable.CurrentSession.CurrentConfiguracionsync.Sucursalid!.Value &&
                                        x.UsuarioNombre == GlobalVariable.CurrentSession.CurrentConfiguracionsync.Usuarioiposlocal);

                    if (usuario == null)
                        throw new Exception("El usuario no existe");

                    impoExpoProvider?.ImportarArchivosPendientes(GlobalVariable.CurrentSession.CurrentConfiguracionsync.Empresaid!.Value,
                                                               GlobalVariable.CurrentSession.CurrentConfiguracionsync.Sucursalid!.Value,
                                                               empresa.Clave,
                                                               sucursal.Clave,
                                                               usuario.Id,
                                                               importPath).Wait();



                    //impoExpoProvider.ExportArchivosPendientes(GlobalVariable.CurrentSession.CurrentConfiguracionsync.Empresaid.Value,
                    //                                           GlobalVariable.CurrentSession.CurrentConfiguracionsync.Sucursalid.Value,
                    //                                           sucursal.Clave,
                    //                                           empresa.Clave);





                    /**Temporal*/
                    //this.repltablaControllerProvider.ReplicateData(GlobalVariable.CurrentSession.CurrentConfiguracionsync.Empresaid.Value,
                    //                                           GlobalVariable.CurrentSession.CurrentConfiguracionsync.Sucursalid.Value,
                    //                                           empresa.Clave,
                    //                                           sucursal.Clave,
                    //                                           usuario.Id,
                    //                                           impoBufferFullPath);
                    //abort = true;
                    /**Fin Temporal*/




                    Thread.Sleep(sleepTime);
                }

            }
        }

        public void StartThread()
        {
            p1.Start();
        }

        public void StopThread()
        {
            abort = true;

            if (!p1.Join(1000))
            {
                p1.Interrupt();
                //p1.Abort();
            }
        }

        public bool IsAlive()
        {
            return p1.IsAlive;
        }

    }
}
