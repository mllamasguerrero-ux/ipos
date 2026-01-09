
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
using Microsoft.EntityFrameworkCore.Storage;

namespace Controllers.Controller
{

    public class ParametroController : BaseController<ParametroBindingModel>
    {

        private IDbContextFactory<ApplicationDbContext> _operationsContextFactory;

        public ParametroController(IDbContextFactory<ApplicationDbContext> operationsContextFactory)
        {
            this._operationsContextFactory = operationsContextFactory;
        }


        public override ParametroBindingModel? GetById(ParametroBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Parametro
                           .Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var item =
                  queryWithIncludes.Select(x => new ParametroBindingModel(x))
                            .FirstOrDefault();

            if (item != null)
            {

                var camposEnListaProducto = applicationDbContext.Lookup.AsNoTracking()
                    .Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId
                                 && x.Clave == "PRODUCTO").FirstOrDefault();

                if (camposEnListaProducto != null)
                    item.CamposEnListaProductos = CampoEnLista.CrearListadoDesdeLookup(camposEnListaProducto);
                else
                    item.CamposEnListaProductos = CampoEnLista.CrearListadoVacio();



                var camposEnListaVerificador = applicationDbContext.Lookup.AsNoTracking()
                    .Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId
                                 && x.Clave == "VERIFICADOR").FirstOrDefault();

                if (camposEnListaVerificador != null)
                    item.CamposEnListaVerificador = CampoEnLista.CrearListadoDesdeLookup(camposEnListaVerificador);
                else
                    item.CamposEnListaVerificador = CampoEnLista.CrearListadoVacio(TipoListado.Verificador);


                var comisionporlista = applicationDbContext.Comisionporlista.AsNoTracking()
                    .Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId).FirstOrDefault();
                if (comisionporlista != null)
                    item.Comisionporlista = new ComisionporlistaBindingModel(comisionporlista);
                else
                {
                    item.Comisionporlista = new ComisionporlistaBindingModel()
                    {
                        EmpresaId = itemSelect.EmpresaId!.Value,
                        SucursalId = itemSelect.SucursalId!.Value,
                        Activo = BoolCS.S,
                        Precio1 = 0m,
                        Precio2 = 0m,
                        Precio3 = 0m,
                        Precio4 = 0m,
                        Precio5 = 0m,
                        Preciootro = 0m
                    };
                }


            }

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

            return item;
        }

        public override List<ParametroBindingModel> GetAll()
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();


            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Parametro;

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var lst =
                  queryWithIncludes.Select(x => new ParametroBindingModel(x))
                            .ToList();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

            return lst;

        }



        public override List<ParametroBindingModel> SelectList(object? param, KendoParams? kendoParams)
        {
            if (param == null) throw new Exception("El campo de parametros es null y debe tener valor");

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            ParametroParam itemParam = (ParametroParam)param;

            List<ParametroBindingModel> listToReturn = new List<ParametroBindingModel>();

            try
            {

                if (kendoParams != null)
                {

                if (kendoParams!.GeneralFilter != null && kendoParams!.GeneralFilter!.Value != null && !kendoParams!.GeneralFilter!.Value.IsNullOrEmpty())
                    kendoParams!.AddGeneralFilterToFilters();

                    if (kendoParams!.Sort == null)
                        kendoParams!.Sort = FillDefaultSort();
                }

                applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;
                var basicQuery = applicationDbContext.Parametro
                                .Where(x => x.EmpresaId == itemParam.P_empresaid && x.SucursalId == itemParam.P_sucursalid);


                var queryWithIncludes = QueryableWithIncludes(basicQuery);

                var lstQuery = queryWithIncludes
                      .ToDataSourceResult(kendoParams?.Take ?? 0, kendoParams?.Skip ?? 0, kendoParams?.Sort?.Select(y => y.ToKendoNetEquivalent()), kendoParams!.Filter?.ToKendoNetEquivalent())
                      .Data.ToList<Parametro>()
                      .Select(x => new ParametroBindingModel(x));

                listToReturn.AddRange(lstQuery);

                applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

                return listToReturn;

            }
            catch
            {
                throw;
            }
        }


        public override bool Insert(ParametroBindingModel item)
        {

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            Parametro entityItem = new Parametro();
            item.FillEntityValues(ref entityItem);
            entityItem.Creado = DateTimeOffset.UtcNow;
            entityItem.Modificado = DateTimeOffset.UtcNow;
            applicationDbContext.Parametro.Add(entityItem);
            applicationDbContext.SaveChanges();
            return true;
        }


        public override List<ParametroBindingModel> Select(object param, string search, string fieldsSearching)
        {
            KendoParams kendoParams = new KendoParams();
            kendoParams.GeneralFilter = new KendoGeneralFilter("search", fieldsSearching);
            return SelectList(param, kendoParams);
        }

        public override List<ParametroBindingModel> SelectById(ParametroBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            ParametroBindingModel item = new ParametroBindingModel();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Parametro
                .Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId && x.Id == itemSelect.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var listItems = queryWithIncludes.Select(x => new ParametroBindingModel(x)).ToList();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;


            return listItems;
        }
        public override bool Update(ParametroBindingModel item)
        {
            if (item.HasErrors)
                throw new InvalidOperationException("Hay datos no validos en este registro");

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();



            var basicQuery = applicationDbContext.Parametro
                           .Where(x => x.EmpresaId == item.EmpresaId && x.SucursalId == item.SucursalId && x.Id == item.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var entityItem = queryWithIncludes.FirstOrDefault();

            if (entityItem == null)
                throw new Exception("No existe parametro");


            item.FillEntityValues(ref entityItem);

            item.Creado = DateTimeOffset.UtcNow;
            item.Modificado = DateTimeOffset.UtcNow;

            applicationDbContext.Parametro?.Update(entityItem);
            applicationDbContext.SaveChanges();



            if (item.CamposEnListaProductos != null)
            {
                var camposEnListaProducto = applicationDbContext.Lookup
                    .FirstOrDefault(x => x.EmpresaId == item.EmpresaId && x.SucursalId == item.SucursalId
                                 && x.Clave == "PRODUCTO");

                if (camposEnListaProducto != null)
                {
                    CampoEnLista.LlenarLookupDesdeListado(item.CamposEnListaProductos, ref camposEnListaProducto);
                    applicationDbContext.Update(camposEnListaProducto);
                }
                else
                {
                    camposEnListaProducto = new Lookup();
                    camposEnListaProducto.EmpresaId = item.EmpresaId!.Value;
                    camposEnListaProducto.SucursalId = item.SucursalId!.Value;
                    camposEnListaProducto.Clave = "PRODUCTO";
                    camposEnListaProducto.Nombre = "PRODUCTO";
                    camposEnListaProducto.Activo = BoolCS.S;

                    CampoEnLista.LlenarLookupDesdeListado(item.CamposEnListaProductos, ref camposEnListaProducto);
                    applicationDbContext.Add(camposEnListaProducto);
                }
                applicationDbContext.SaveChanges();
            }



            if (item.CamposEnListaVerificador != null)
            {
                var camposEnListaVerificador = applicationDbContext.Lookup
                    .FirstOrDefault(x => x.EmpresaId == item.EmpresaId && x.SucursalId == item.SucursalId
                                 && x.Clave == "VERIFICADOR");

                if (camposEnListaVerificador != null)
                {
                    CampoEnLista.LlenarLookupDesdeListado(item.CamposEnListaVerificador, ref camposEnListaVerificador);
                    applicationDbContext.Update(camposEnListaVerificador);
                }
                else
                {
                    camposEnListaVerificador = new Lookup();
                    camposEnListaVerificador.EmpresaId = item.EmpresaId!.Value;
                    camposEnListaVerificador.SucursalId = item.SucursalId!.Value;
                    camposEnListaVerificador.Clave = "VERIFICADOR";
                    camposEnListaVerificador.Nombre = "VERIFICADOR";
                    camposEnListaVerificador.Activo = BoolCS.S;

                    CampoEnLista.LlenarLookupDesdeListado(item.CamposEnListaVerificador, ref camposEnListaVerificador);
                    applicationDbContext.Add(camposEnListaVerificador);
                }
                applicationDbContext.SaveChanges();
            }


            if (item.Comisionporlista != null)
            {

                var comisionporlista = applicationDbContext.Comisionporlista
                    .FirstOrDefault(x => x.EmpresaId == item.EmpresaId && x.SucursalId == item.SucursalId);


                if (comisionporlista != null)
                {
                    item.Comisionporlista.FillEntityValues(ref comisionporlista);
                    applicationDbContext.Update(comisionporlista);
                }
                else
                {
                    comisionporlista = new Comisionporlista();
                    comisionporlista.EmpresaId = item.EmpresaId!.Value;
                    comisionporlista.SucursalId = item.SucursalId!.Value;
                    comisionporlista.Activo = BoolCS.S;
                    item.Comisionporlista.FillEntityValues(ref comisionporlista);

                    applicationDbContext.Add(comisionporlista);
                }
                applicationDbContext.SaveChanges();
            }




            return true;

        }
        public override bool Delete(ParametroBindingModel item)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            var entityItem = applicationDbContext.Parametro?
            .Single(m => m.EmpresaId == item.EmpresaId && m.SucursalId == item.SucursalId && m.Id == item.Id);

            if (entityItem != null)
            {
                applicationDbContext.Parametro?.Remove(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;
        }


#pragma warning disable CS8602
    public IQueryable<Parametro> QueryableWithIncludes(IQueryable<Parametro> itemBasicQuery)
        {
            return itemBasicQuery.Include(c => c.Lista_precio_def)
              .Include(c => c.Listaprecioinimayo_)
              .Include(c => c.Tipodescuentoprod)
              .Include(c => c.Agrupacionventa)
              .Include(c => c.Precioajustedifinv)
              .Include(c => c.Encargado)
              .Include(c => c.Listaprecioxuempaque_)
              .Include(c => c.Listaprecioxpzacaja_)
              .Include(c => c.Tipoutilidad)
              .Include(c => c.Listapreciominimo_)
              .Include(c => c.Almacenrecepcion)
              .Include(c => c.Campoimpocostorepo)
              .Include(c => c.Clienteconsolidado)
              .Include(c => c.Sat_metodopago)
              .Include(c => c.Sat_regimenfiscal)
              .Include(c => c.Monederolistaprecio)
              .Include(c => c.Vendedormovil)
              .Include(c => c.Emidarecargalinea)
              .Include(c => c.Emidarecargamarca)
              .Include(c => c.Emidarecargaproveedor)
              .Include(c => c.Emidaserviciolinea)
              .Include(c => c.Emidaserviciomarca)
              .Include(c => c.Emidaservicioproveedor)
              .Include(c => c.Ultmensaje)
              ;

        }  
#pragma warning restore CS8602

    }

}



