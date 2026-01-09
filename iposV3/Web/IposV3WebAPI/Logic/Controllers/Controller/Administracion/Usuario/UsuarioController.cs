
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

namespace Controllers.Controller
{
    
    public class UsuarioController : BaseController<UsuarioBindingModel>
    {

        private IDbContextFactory<ApplicationDbContext> _operationsContextFactory;
        private UsuarioService _usuarioService;

        public UsuarioController(
            UsuarioService usuarioService,
            IDbContextFactory<ApplicationDbContext> operationsContextFactory)
        {
            this._operationsContextFactory = operationsContextFactory;
            this._usuarioService = usuarioService;

        }


        public override UsuarioBindingModel? GetById(UsuarioBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Usuario.AsNoTracking()
                           .Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId && x.Id == itemSelect.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var item =
                  queryWithIncludes.Select(x => new UsuarioBindingModel(x))
                            .FirstOrDefault();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

            return item;
        }

        public override List<UsuarioBindingModel> GetAll()
        {

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Usuario.AsNoTracking();

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var lst =
                  queryWithIncludes.Select(x => new UsuarioBindingModel(x))
                            .ToList();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

            return lst;

        }



        public override List<UsuarioBindingModel> SelectList(object? param, KendoParams? kendoParams)
        {
            if (param == null) throw new Exception("El campo de parametros es null y debe tener valor");

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            UsuarioParam itemParam = (UsuarioParam)param;

            List<UsuarioBindingModel> listToReturn = new List<UsuarioBindingModel>();

            try
            {

                if (kendoParams != null)
                {
                    kendoParams!.RemoveAllGeneralFilterFromFilters();

                    if (kendoParams!.GeneralFilter != null && kendoParams!.GeneralFilter!.Value != null && !kendoParams!.GeneralFilter!.Value.IsNullOrEmpty())
                        kendoParams!.AddGeneralFilterToFilters();

                    if (kendoParams!.Sort == null)
                        kendoParams!.Sort = FillDefaultSort();
                }

                applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;
                var basicQuery = applicationDbContext.Usuario.AsNoTracking()
                                .Where(x => x.EmpresaId == itemParam.P_empresaid && x.SucursalId == itemParam.P_sucursalid);


                var queryWithIncludes = QueryableWithIncludes(basicQuery);

                var lstQuery = queryWithIncludes
                      .ToDataSourceResult(kendoParams?.Take ?? 0, kendoParams?.Skip ?? 0, kendoParams?.Sort?.Select(y => y.ToKendoNetEquivalent()), kendoParams!.Filter?.ToKendoNetEquivalent())
                      .Data.ToList<Usuario>()
                      .Select(x => new UsuarioBindingModel(x));

                listToReturn.AddRange(lstQuery);

                applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

                return listToReturn;

            }
            catch
            {
                throw;
            }
        }


        public override bool Insert(UsuarioBindingModel item)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            Usuario entityItem = new Usuario();
            item.FillEntityValues(ref entityItem);
            entityItem.Creado = DateTimeOffset.UtcNow;
            entityItem.Modificado = DateTimeOffset.UtcNow;
            applicationDbContext.Usuario.Add(entityItem);
            applicationDbContext.SaveChanges();
            return true;
        }


        public override List<UsuarioBindingModel> Select(object param, string search, string fieldsSearching)
        {
            KendoParams kendoParams = new KendoParams();
            kendoParams.GeneralFilter = new KendoGeneralFilter("search", fieldsSearching);
            return SelectList(param, kendoParams);
        }

        public override List<UsuarioBindingModel> SelectById(UsuarioBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            UsuarioBindingModel item = new UsuarioBindingModel();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Usuario.AsNoTracking()
                .Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId && x.Id == itemSelect.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var listItems = queryWithIncludes.Select(x => new UsuarioBindingModel(x)).ToList();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;


            return listItems;
        }
        public override bool Update(UsuarioBindingModel item)
        {
            //if (item.HasErrors)
            //{
            //    throw new InvalidOperationException("Hay datos no validos en este registro");
            //}

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            var basicQuery = applicationDbContext.Usuario
                           .Where(x => x.EmpresaId == item.EmpresaId && x.SucursalId == item.SucursalId && x.Id == item.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var entityItem = queryWithIncludes.FirstOrDefault();

            if (entityItem != null)
            {
                item.FillEntityValues(ref entityItem);

                applicationDbContext.Usuario?.Update(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;

        }



        public bool UpdateContrasena(CambiocontrasenaWFBindingModel item)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            var basicQuery = applicationDbContext.Usuario
                           .Where(x => x.EmpresaId == item.EmpresaId && x.SucursalId == item.SucursalId && x.Id == item.Id);


            var entityItem = basicQuery.FirstOrDefault();

            if (entityItem != null)
            {
                entityItem.Contrasena = item.Contrasena!;
                entityItem.Reset_pass = BoolCN.N;
                entityItem.ModificadoPorId = item.ModificadoPorId;

                applicationDbContext.Usuario?.Update(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;

        }

        public override bool Delete(UsuarioBindingModel item)
        {

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            var entityItem = applicationDbContext.Usuario?
            .Single(m => m.EmpresaId == item.EmpresaId && m.SucursalId == item.SucursalId && m.Id == item.Id);

            if (entityItem != null)
            {
                applicationDbContext.Usuario?.Remove(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;
        }

        public WFLoginResultBindingModel ValidateLogin(WFLoginParamBindingModel param)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            var user = applicationDbContext.Usuario.FirstOrDefault(y => y.EmpresaId == param.P_empresaid && y.SucursalId == param.P_sucursalid &&  
                                                                         y.UsuarioNombre.ToLower() == param.P_username!.ToLower() && y.Contrasena == param.P_claveacceso);
            if(user != null)
            {
                return new WFLoginResultBindingModel() { Devmessage = "exito", Result = user.Id, Usermessage="" };
            }
            
            return new WFLoginResultBindingModel() { Devmessage = "No encontrado", Result = 0, Usermessage = "No valido" };
        }


#pragma warning disable CS8602
    public IQueryable<Usuario> QueryableWithIncludes(IQueryable<Usuario> itemBasicQuery)
        {
            return itemBasicQuery.Include(c => c.Saludo)
              .Include(c => c.Domicilio)
              .Include(c => c.Contacto1)
              .Include(c => c.Contacto1).ThenInclude(s => s.Domicilio)
              .Include(c => c.Contacto2)
              .Include(c => c.Contacto2).ThenInclude(s => s.Domicilio)
              .Include(c => c.Usuario_Preferencias).ThenInclude(d => d.Grupousuario)
              .Include(c => c.Usuario_Preferencias).ThenInclude(d => d.Almacen)
              .Include(c => c.Usuario_Preferencias).ThenInclude(d => d.Listaprecio)
              .Include(c => c.Usuario_Personafigura)
              .Include(c => c.Usuario_fact_elect).ThenInclude(f => f.Estado)
              .Include(c => c.Usuario_fact_elect).ThenInclude(f => f.Sat_pais)
              .Include(c => c.Usuario_fact_elect).ThenInclude(f => f.Sat_Colonia)
              .Include(c => c.Usuario_fact_elect).ThenInclude(f => f.Sat_Localidad)
              .Include(c => c.Usuario_fact_elect).ThenInclude(f => f.Sat_Municipio)
              .Include(c => c.Usuario_Personafigura).ThenInclude(f => f.Sat_Figuratransporte)
              .Include(c => c.Usuario_Personafigura).ThenInclude(f => f.Sat_Partetransporte)
              .Include(c => c.Usuario_emida)
              ;

        }
#pragma warning restore CS8602



        public List<UsuarioPerfilItemBindingModel> GetUsuariosPerfiles(
                UsuarioBindingModel itemSelect, KendoParams? kendoParams)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            var usuarios_perfiles = new List<UsuarioPerfilItemBindingModel>();

            try
            {

                if (kendoParams != null)
                {
                    kendoParams!.RemoveAllGeneralFilterFromFilters();

                    if (kendoParams!.GeneralFilter != null && kendoParams!.GeneralFilter!.Value != null && !kendoParams!.GeneralFilter!.Value.IsNullOrEmpty())
                        kendoParams!.AddGeneralFilterToFilters();

                    if (kendoParams!.Sort == null)
                        kendoParams!.Sort = FillDefaultSort();
                }

                applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;
                var usuarioPerfilList = applicationDbContext.Usuario_perfil.AsNoTracking()
                                .Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId && x.Usuarioid == itemSelect.Id!).ToList();


                var perfilesList = applicationDbContext.Perfiles.ToList();


                usuarios_perfiles = UsuarioPerfilItemBindingModel.GetUsuarioPefilList(perfilesList, usuarioPerfilList);


                applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

                return usuarios_perfiles;

            }
            catch
            {
                throw;
            }


        }


        public bool UpdateUsuariosPerfiles(
                UsuarioBindingModel itemSelect, List<UsuarioPerfilItemBindingModel> usuarios_perfiles)
        {

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            var usuarioPerfilList = applicationDbContext.Usuario_perfil
                            .Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId && x.Usuarioid == itemSelect.Id!).ToList();

            // primero eliminar los que estan en perfilderlist y no en la
            var usuarioPerfilListAEliminar = usuarioPerfilList.Where(y => !usuarios_perfiles.Any(x => (x.Permitido ?? false) && x.Perfilid == y.Perfilid)).ToList();
            usuarioPerfilList = usuarioPerfilList.Where(y => usuarios_perfiles.Any(x => (x.Permitido ?? false) && x.Perfilid == y.Perfilid)).ToList();

            // agregar los que no estan
            var usuarioPerfilListAAgregar = usuarios_perfiles.Where(pd => (pd.Permitido ?? false) && !usuarioPerfilList.Any(y => y.Perfilid == pd.Perfilid))
                .Select(pd => new Usuario_perfil() { EmpresaId = itemSelect.EmpresaId!.Value, SucursalId = itemSelect.SucursalId!.Value, Usuarioid = itemSelect.Id!.Value, Perfilid = pd.Perfilid })
                .ToList();

            foreach (var perfilderAEliminar in usuarioPerfilListAEliminar)
            {
                applicationDbContext.Usuario_perfil.Remove(perfilderAEliminar);
            }

            foreach (var perfilDerAAgregar in usuarioPerfilListAAgregar)
            {
                applicationDbContext.Usuario_perfil.Add(perfilDerAAgregar);
            }

            applicationDbContext.SaveChanges();


            return true;
        }



        public Dictionary<long, bool> Obtain_usuarios_derechos_List(long empresaid, long sucursalid, List<long> derechos, long usuarioId)
        {
            //Fnc_usuarios_derechosResultBindingModel

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            return _usuarioService.UsuariosDerechos(empresaid, sucursalid, usuarioId, derechos.Distinct().ToList(), applicationDbContext)
                                    .Select(p => new { p.Derechoid, p.Acceso  })
                                    .ToDictionary(keySelector: m => (long)m.Derechoid, elementSelector: m => (bool)m.Acceso);

        }


    }

}



