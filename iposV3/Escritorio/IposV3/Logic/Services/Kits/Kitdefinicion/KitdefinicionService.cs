
using IposV3.Model;
using Microsoft.EntityFrameworkCore;
//using Syncfusion.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IposV3.Services
{
    public class KitdefinicionService
    {
        private ImpuestosService _impuestoSevice;
        public KitdefinicionService( ImpuestosService impuestoService)
        {
            _impuestoSevice = impuestoService;
        }

        public ImpuestoKitDefinicion CalculateImpuestosKitDefinicion(long empresaId, long sucursalId, long productoKitId,
                                                                     ApplicationDbContext localContext)
        {
            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQueryNoTracking = localContext.Kitdefinicion.AsNoTracking().Include(y => y.Productoparte).
                  Where( y => y.EmpresaId == empresaId && y.SucursalId == sucursalId && y.Productokitid == productoKitId);
            
            var lstKitDefinitions = basicQueryNoTracking.ToList();


            var listaAProrreatear = lstKitDefinitions.Select(x => new Prorrateo()
            {
                Id = x.Id,
                Cantidad = x.Cantidadparte * x.Costoparte,
                CantidadProrrateada = 0
            }).ToList();

            decimal ivaTotalKit = 0m;
            decimal iepsTotalKit = 0m;

            try
            {
                MathIpos.Prorratear(100m,4, ref listaAProrreatear);

                foreach(var kitDefinition in lstKitDefinitions)
                {
                    var prorrateoInfo = listaAProrreatear.SingleOrDefault(y => y.Id == kitDefinition.Id);
                    if(prorrateoInfo != null)
                    {

                        ivaTotalKit +=  Decimal.Round(((kitDefinition.Productoparte?.Ivaimpuesto ?? 0) * (prorrateoInfo.CantidadProrrateada / 100m)), 2);
                        iepsTotalKit += Decimal.Round(((kitDefinition.Productoparte?.Iepsimpuesto ?? 0) * (prorrateoInfo.CantidadProrrateada / 100)), 2);
                    }
                }


            }
            catch {
                throw;
            }
            finally
            {
                localContext.ChangeTracker.LazyLoadingEnabled = previousLazyLoadingEnabledValue;
            }


            return new ImpuestoKitDefinicion() { Iva = ivaTotalKit, Ieps = iepsTotalKit };

        }


        public void ActualizaCalculoDeImpuestos(long empresaId, long sucursalId, long productoKitId, ApplicationDbContext localContext,  out ImpuestoKitDefinicion? impuestosKit)
        {
            impuestosKit = CalculateImpuestosKitDefinicion(empresaId, sucursalId, productoKitId, localContext);
            var producto = localContext.Producto.SingleOrDefault(y => y.EmpresaId == empresaId && y.SucursalId == sucursalId && y.Id == productoKitId);

            if (producto != null && impuestosKit != null)
            {
                producto.Ivaimpuesto = impuestosKit.Iva;
                producto.Iepsimpuesto = impuestosKit.Ieps;
                localContext.SaveChanges();
            }
        }



        public List<MovtoKitdefinicionBuffer> MovtoKitdefinicionBufferList(long empresaId, long sucursalId, long? movtorefid,
              long productoKitId, decimal cantidad, ApplicationDbContext localContext)
        {
            List<MovtoKitdefinicionBuffer> lstKitDefinitions = new List<MovtoKitdefinicionBuffer>();

            if (movtorefid != null && movtorefid != 0)
            {


                var basicQueryNoTracking = localContext.Movto_kit_def.AsNoTracking().Include(y => y.Productoparte)
                                    .Include(y => y.Movto)
                                    .Where(y => y.EmpresaId == empresaId && y.SucursalId == sucursalId &&
                                                y.Movtoid == movtorefid && y.Productokitid == productoKitId);

                lstKitDefinitions = basicQueryNoTracking.Select(y => new MovtoKitdefinicionBuffer(y)).ToList();

            }
            else
            {


                var basicQueryNoTracking = localContext.Kitdefinicion.AsNoTracking().Include(y => y.Productoparte).
                      Where(y => y.EmpresaId == empresaId && y.SucursalId == sucursalId && y.Productokitid == productoKitId);

                lstKitDefinitions = basicQueryNoTracking.Select(y => new MovtoKitdefinicionBuffer(y, cantidad)).ToList();

            }
            return lstKitDefinitions;
        }

        public void CalcularImpuestosTotalesKitMovto(
              long empresaId , long sucursalId , long productoKitId,
              decimal cantidad , decimal? precioconimp,
              long? movtorefid ,
              ref decimal? preciosinimp , ref decimal? totalamount ,
              out decimal? subtotalkit ,out decimal? ivakit ,
              out decimal? iepskit ,out List<MovtoKitdefinicionBuffer> movto_kit_def_arr, ApplicationDbContext localContext
            )
        {




            subtotalkit = 0m;
            ivakit = 0m;
            iepskit = 0m;
            movto_kit_def_arr = new List<MovtoKitdefinicionBuffer>();

            decimal? temp_precioconimp = null;
            decimal? temp_preciosinimp = null;
            decimal? temp_totalamount = null;
            decimal? temp_subtotalkit = null;
            decimal? temp_ivakit = null;
            decimal? temp_iepskit = null;


            
            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            List<Prorrateo> listaAProrreatear;
            List<MovtoKitdefinicionBuffer> lstKitDefinitions = MovtoKitdefinicionBufferList( empresaId, sucursalId,  movtorefid,
              productoKitId, cantidad, localContext);


            listaAProrreatear = lstKitDefinitions.Select(x => new Prorrateo()
            {
                Id = x.Id,
                Cantidad = x.Cantidadparte * x.Costoparte *
                  (1 + ((x.Iepsimpuesto ?? 0m) / 100m)) * (1 + (x.Ivaimpuesto ?? 0m) / 100m),
                CantidadProrrateada = 0
            }).ToList();


            try
            {

                if ((precioconimp != null && precioconimp != 0) || (totalamount != null && totalamount != 0))
                {
                    if (totalamount == 0 || totalamount == null)
                        totalamount = decimal.Round(precioconimp!.Value * cantidad, 2);

                    MathIpos.Prorratear(totalamount!.Value, 2, ref listaAProrreatear);

                    preciosinimp = 0m;
                    subtotalkit = 0m;
                    ivakit = 0m;
                    iepskit = 0m;
                    totalamount = 0m;

                    foreach (var kitDefinition in lstKitDefinitions)
                    {
                        var prorrateoInfo = listaAProrreatear.SingleOrDefault(y => y.Id == kitDefinition.Id);
                        if (prorrateoInfo != null)
                        {
                            temp_totalamount = prorrateoInfo.CantidadProrrateada;
                            temp_preciosinimp = null;
                            temp_precioconimp = null;
                            _impuestoSevice.CalcularImpuestos(kitDefinition!.Ivaimpuesto ?? 0m, kitDefinition!.Iepsimpuesto ?? 0m,
                                                              cantidad, ref temp_precioconimp, ref temp_preciosinimp,
                                                              ref temp_totalamount, out temp_ivakit, out temp_iepskit, out temp_subtotalkit);



                            preciosinimp += temp_preciosinimp;
                            subtotalkit += temp_subtotalkit;
                            ivakit += temp_ivakit;
                            iepskit += temp_iepskit;
                            totalamount += temp_totalamount;

                            //kitDefinition.Cantidad = 
                            kitDefinition.Preciosinimpuesto = Math.Round((temp_preciosinimp ?? 0m) / kitDefinition!.Cantidadparte, 4);
                            kitDefinition.Totalamount = temp_totalamount;
                            kitDefinition.Subtotalkit = temp_subtotalkit;
                            kitDefinition.Ivakit = temp_ivakit;
                            kitDefinition.Iepskit = temp_iepskit;
                            //kitDefinition.Cantidad = cantidad * kitDefinition!.Cantidad!.Value;


                        }
                    }
                    movto_kit_def_arr = lstKitDefinitions;


                }
                else
                {

                    MathIpos.Prorratear(preciosinimp!.Value, 2, ref listaAProrreatear);

                    preciosinimp = 0m;
                    subtotalkit = 0m;
                    ivakit = 0m;
                    iepskit = 0m;
                    totalamount = 0m;

                    foreach (var kitDefinition in lstKitDefinitions)
                    {
                        var prorrateoInfo = listaAProrreatear.SingleOrDefault(y => y.Id == kitDefinition.Id);
                        if (prorrateoInfo != null)
                        {
                            temp_preciosinimp = prorrateoInfo.CantidadProrrateada;
                            temp_totalamount = null;
                            temp_precioconimp = null;
                            _impuestoSevice.CalcularImpuestos(kitDefinition!.Ivaimpuesto ?? 0m, kitDefinition!.Iepsimpuesto ?? 0m,
                                                              cantidad, ref temp_precioconimp, ref temp_preciosinimp,
                                                              ref temp_totalamount, out temp_ivakit, out temp_iepskit, out temp_subtotalkit);



                            preciosinimp += temp_preciosinimp;
                            subtotalkit += temp_subtotalkit;
                            ivakit += temp_ivakit;
                            iepskit += temp_iepskit;
                            totalamount += temp_totalamount;

                            //kitDefinition.Cantidad = 
                            kitDefinition.Preciosinimpuesto = Math.Round((temp_preciosinimp ?? 0m) / kitDefinition!.Cantidadparte, 4);
                            kitDefinition.Totalamount = temp_totalamount;
                            kitDefinition.Subtotalkit = temp_subtotalkit;
                            kitDefinition.Ivakit = temp_ivakit;
                            kitDefinition.Iepskit = temp_iepskit;

                        }
                    }

                    movto_kit_def_arr = lstKitDefinitions;

                }
            }
            catch
            {
                throw;
            }
            finally
            {
                localContext.ChangeTracker.LazyLoadingEnabled = previousLazyLoadingEnabledValue;
            }


        }

        

    }

    public class MovtoKitdefinicionBuffer 
    {


        public MovtoKitdefinicionBuffer() : base()
        {
        }

        public MovtoKitdefinicionBuffer(Kitdefinicion kitdef, decimal cantidad) :this()
        {

            Id = kitdef.Id;
            Productokitid = kitdef.Productokitid;
            Productoparteid = kitdef.Productoparteid;
            Cantidadparte = kitdef.Cantidadparte;
            Cantidad = Math.Round(kitdef.Cantidadparte * cantidad, 4);
            Costoparte = kitdef.Costoparte;
            Iepsimpuesto = kitdef.Productoparte?.Iepsimpuesto;
            Ivaimpuesto = kitdef.Productoparte?.Ivaimpuesto;

        }

        public MovtoKitdefinicionBuffer(Movto_kit_def kitdef) : this()
        {

            Id = kitdef.Id;
            Productokitid = kitdef.Productokitid;
            Productoparteid = kitdef.Productoparteid;
            Cantidadparte = kitdef.Cantidadparte;
            Cantidad = Math.Round(kitdef.Cantidadparte * kitdef.Movto!.Cantidad, 4 );
            Costoparte = kitdef.Costoparte;
            Iepsimpuesto = kitdef.Productoparte?.Iepsimpuesto;
            Ivaimpuesto = kitdef.Productoparte?.Ivaimpuesto;

        }



        public long Id { get; set; }

        public long? Productokitid { get; set; }

        public long? Productoparteid { get; set; }


        public decimal Cantidadparte { get; set; } = 0m;

        public decimal Costoparte { get; set; } = 0m;

        public decimal? Iepsimpuesto { get; set; } 
        public decimal? Ivaimpuesto { get; set; }


        public decimal? Cantidad { get; set; } 
        public decimal? Preciosinimpuesto { get; set; }

        public decimal? Totalamount { get; set; }
        public decimal? Subtotalkit { get; set; }
        public decimal? Ivakit { get; set; }

        public decimal? Iepskit { get; set; }



}
}
