using IposV3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace IposV3.Services
{
    public class DoctoMovtoService
    {

        private MovtoService _movtoService;
        private DoctoService _doctoService;
        private KitdefinicionService _kitDefinicionService;
        private ImpuestosService _impuestoSevice;
        private InventarioService _inventarioService;
        private MaestroConsecutivoService _maestroConsecutivoService;
        private PagoService _pagoService;
        private CorteService _corteService;
        public DoctoMovtoService(
                            KitdefinicionService kitDefinicionService,
                            ImpuestosService impuestoService,
                            InventarioService inventarioService,
                            MaestroConsecutivoService maestroConsecutivoService,
                            PagoService pagoService,
                            MovtoService movtoService,
                            DoctoService doctoService,
                            CorteService corteService)
        {
            _kitDefinicionService = kitDefinicionService;
            _impuestoSevice = impuestoService;
            _inventarioService = inventarioService;
            _maestroConsecutivoService = maestroConsecutivoService;
            _pagoService = pagoService;
            _movtoService = movtoService;
            _doctoService = doctoService;
            _corteService = corteService;
        }





        #region Docto operations


        public void Docto_ensamble_update_status(long empresaId, long sucursalId, long id, long estatusDoctoId,
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {

                Docto_update_status(empresaId, sucursalId, id, estatusDoctoId, localContext);

                var movtoIds = localContext.Movto.AsNoTracking()
                                  .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Doctoid == id)
                                  .Select(m => m.Id).ToList();


                foreach (var movtoId in movtoIds)
                {
                    _movtoService.MovtoUpdateStatus(empresaId, sucursalId, movtoId, estatusDoctoId, localContext);
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



        public void Ensamble_kit_completar(long empresaId, long sucursalId, long doctoId,
            ApplicationDbContext localContext)
        {


            BoolCS hayExistencia = BoolCS.S;
            decimal existencia = 0m;
            decimal existenciaParaArmarKit = 0m;
            decimal existenciaTotal = 0m;
            decimal enProcesoDeSalida = 0m;



            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;


            long? doctoIdKitDesglose = null;
            long? movtoIdKitDesglose = null;

            try
            {
                var docto = localContext.Docto.AsNoTracking()
                                              .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && d.Id == doctoId)
                                              .FirstOrDefault();

                if (docto == null)
                    throw new Exception("Docto no encontrado");

                if (docto.Tipodoctoid != 501)
                    throw new Exception("este tipo de documento no puede completar ensamble de  kits");

                if (docto.Estatusdoctoid != 0)
                    throw new Exception("este estatus de documento no puede completar ensamble de  kits");



                var movtoKitDesgloses = localContext.Movto_kit_def.AsNoTracking()
                                            .Include(m => m.Movto)
                                            .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Movto!.Doctoid == doctoId)
                                            .Select(mkd => new {
                                                mkd.Movtoid,
                                                Productoid = mkd.Productoparteid,
                                                Cantidad = mkd.Cantidadpartetotal,
                                                Precio = mkd.Precioporunidad,
                                                mkd.Tasaieps,
                                                mkd.Tasaiva
                                            })
                                            .ToList();

                foreach (var movKitDef in movtoKitDesgloses)
                {
                    hayExistencia = BoolCS.N;
                    existencia = 0m;
                    existenciaParaArmarKit = 0m;
                    existenciaTotal = 0m;
                    enProcesoDeSalida = 0m;
                    _inventarioService.VerificarExistencia(empresaId, sucursalId,
                                                        movKitDef!.Productoid!.Value, movKitDef.Cantidad,
                                                        docto!.Tipodoctoid!.Value, docto!.Almacenid!.Value,
                                                        null, null, BoolCN.N, BoolCN.S, BoolCN.S, BoolCN.S,
                                                        BoolCN.N, movKitDef.Movtoid,
                                                        out hayExistencia, out existencia, out existenciaParaArmarKit,
                                                        out existenciaTotal, out enProcesoDeSalida, localContext);


                    if (existencia < movKitDef.Cantidad)
                        throw new Exception("No hay existencia suficiente");

                    //MLG TODO revisar lo de la generacion de ids
                    if (doctoIdKitDesglose == null)
                    {
                        var doctoTrans = new DoctoTransaction()
                        {
                            Empresaid = empresaId,
                            Sucursalid = sucursalId,
                            //Id = null,
                            Activo = BoolCS.S,
                            Creado = DateTimeOffset.Now,
                            Creadopor_userid = docto.Usuarioid,
                            Estatusdoctoid = 0,
                            Usuarioid = docto.Usuarioid,
                            Corteid = docto.Corteid,
                            Fecha = docto.Fecha ?? DateTimeOffset.Now,
                            Fechahora = docto.Fechahora ?? DateTimeOffset.Now,
                            Serie = null,
                            Folio = null,
                            Importe = 0m,
                            Descuento = 0m,
                            Subtotal = 0m,
                            Iva = 0m,
                            Ieps = 0m,
                            Total = 0m,
                            Cargo = 0m,
                            Abono = 0m,
                            Saldo = 0m,
                            Cajaid = docto.Cajaid,
                            Almacenid = docto.Almacenid,
                            Origenfiscalid = docto.Origenfiscalid,
                            Esapartado = docto.Esapartado,
                            Doctoparentid = doctoId,
                            Clienteid = docto.Clienteid,
                            Tipodoctoid = 503,
                            Proveedorid = docto.Proveedorid,
                            Sucursal_id = docto.Sucursal_id,
                            Referencia = null,
                            Referencias = null,
                            Fechavence = null

                        };
                        _doctoService.DoctoInsert(doctoTrans, ref doctoIdKitDesglose, localContext);
                    }

                    movtoIdKitDesglose = null;

                    var movtoTrans = new MovtoTransaccion()
                    {

                        Empresaid = empresaId,
                        Sucursalid = sucursalId,
                        //Id = null,
                        Activo = BoolCS.S,
                        Creado = DateTimeOffset.Now,
                        Creadopor_userid = docto.Usuarioid,
                        Partida = null,
                        Estatusmovtoid = 0,
                        Fecha = DateTimeOffset.UtcNow.Date,
                        Fechahora = DateTimeOffset.UtcNow,
                        Productoid = movKitDef.Productoid,
                        Cantidad = movKitDef.Cantidad,
                        Preciolista = movKitDef.Precio,
                        Descuentoporcentaje = 0m,
                        Descuento = 0m,
                        Precio = movKitDef.Precio,
                        Importe = 0m,
                        Subtotal = 0m,
                        Iva = 0m,
                        Ieps = 0m,
                        Tasaiva = movKitDef.Tasaiva,
                        Tasaieps = movKitDef.Tasaieps,
                        Total = 0m,
                        Lote = null,
                        Fechavence = null,
                        Loteimportado = null,
                        Movtoparentid = movKitDef.Movtoid,
                        Movtonivel = 0,
                        Afectainventario = BoolCS.S,
                        Afectatotales = BoolCS.S,
                        Eskit = BoolCN.N,
                        Kitimpfijo = BoolCN.N,
                        Doctoid = doctoIdKitDesglose,
                        Cargo = 0m,
                        Abono = 0m,
                        Saldo = 0m,
                        Preciomanual = 0m,
                        Preciomaximopublico = 0m,
                        Isrretenido = 0m,
                        Ivaretenido = 0m,
                        Orden = 0,
                        Tasaisrretenido = 0m,
                        Tasaivaretenido = 0m,
                        Calc_imp_de_total = BoolCN.N,
                        Localidad = null,
                        Descripcion1 = null,
                        Descripcion2 = null,
                        Descripcion3 = null,
                        Agrupaporparametro = null,
                        Cargartarjetapreciomanual = null,
                        Precioyavalidado = null,
                        Usuarioid = null,
                        Precioconimp = null,
                        Anaquelid = null,
                        Movtoadevolverid = null

                    };
                    MovtoInsert(movtoTrans, ref movtoIdKitDesglose, localContext);

                    var movto_precio = new Movto_precio()
                    {
                        EmpresaId = empresaId,
                        SucursalId = sucursalId,
                        //Id = null,
                        Activo = BoolCS.S,
                        Creado = DateTimeOffset.Now,
                        CreadoPorId = docto.Usuarioid,
                        Razondescuentocajero = "",
                        Preciomanualmasbajo = BoolCN.N,
                        Descuentovale = 0m,
                        Descuentovaleporcentaje = 0m,
                        Movtoid = movtoIdKitDesglose,
                        Ingresopreciomanual = BoolCN.N,
                        Porcentajedescuentomanual = 0m,
                        Precioclasificacion = null,
                        Precioconimp = 0m,
                        Calc_imp_de_total = BoolCN.N
                    };
                    localContext.Add(movto_precio);


                }

                if (doctoIdKitDesglose != null)
                {
                    this.Docto_ensamble_update_status(empresaId, sucursalId, doctoIdKitDesglose!.Value, 1, localContext);

                    //MLG TODO checar si se requiere hacer esto aqui
                    this.Docto_ensamble_update_status(empresaId, sucursalId, doctoId, 1, localContext);
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



        public void Ensamble_kit_al_vuelo(long empresaId, long sucursalId, long doctoId,
            ApplicationDbContext localContext)
        {

            BoolCS hayExistencia = BoolCS.S;
            decimal existencia = 0m;
            decimal existenciaParaArmarKit = 0m;
            decimal existenciaTotal = 0m;
            decimal enProcesoDeSalida = 0m;


            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            long? doctoIdKitDesglose = null;
            long? movtoIdKitDesglose = null;

            decimal cantidadAArmar = 0;




            try
            {
                var docto = localContext.Docto.AsNoTracking()
                                              .Include(d => d.Tipodocto)
                                              .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && d.Id == doctoId)
                                              .FirstOrDefault();

                if (docto == null)
                    throw new Exception("Docto no encontrado");

                if (docto.Tipodocto == null || docto.Tipodocto.Sentidoinventario >= 0 || docto.Tipodocto.Ensamblarkits != BoolCN.S)
                    return;


                var movtosConKits = localContext.Movto.AsNoTracking()
                                            .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Doctoid == doctoId && m.Eskit == BoolCN.S)
                                            .Select(movto => new {
                                                Movtoid = movto.Id,
                                                Productoid = movto.Productoid,
                                                Cantidad = movto.Cantidad,
                                                movto.Preciolista,
                                                movto.Descuentoporcentaje,
                                                Precio = movto.Precio,
                                                movto.Tasaieps,
                                                movto.Tasaiva,
                                                movto.Lote,
                                                movto.Fechavence,
                                                movto.Loteimportado,
                                                movto.Eskit,
                                                movto.Kitimpfijo

                                            })
                                            .ToList();

                foreach (var movKitDef in movtosConKits)
                {
                    hayExistencia = BoolCS.N;
                    existencia = 0m;
                    existenciaParaArmarKit = 0m;
                    existenciaTotal = 0m;
                    enProcesoDeSalida = 0m;

                    cantidadAArmar = 0;

                    _inventarioService.VerificarExistencia(empresaId, sucursalId,
                                                        movKitDef!.Productoid!.Value, movKitDef.Cantidad,
                                                        docto!.Tipodoctoid!.Value, docto!.Almacenid!.Value,
                                                        null, null, BoolCN.N, BoolCN.S, BoolCN.S, BoolCN.N,
                                                        BoolCN.N, movKitDef.Movtoid,
                                                        out hayExistencia, out existencia, out existenciaParaArmarKit,
                                                        out existenciaTotal, out enProcesoDeSalida, localContext);


                    if (existencia + existenciaParaArmarKit < movKitDef.Cantidad)
                        throw new Exception("No hay existencia suficiente");

                    if (existencia >= movKitDef.Cantidad)
                        continue;

                    cantidadAArmar = movKitDef.Cantidad - existencia;

                    //MLG TODO revisar lo de la generacion de ids
                    if (doctoIdKitDesglose == null)
                    {
                        var doctoTrans = new DoctoTransaction()
                        {
                            Empresaid = empresaId,
                            Sucursalid = sucursalId,
                            //Id = null,
                            Activo = docto.Activo,
                            Creado = DateTimeOffset.Now,
                            Creadopor_userid = docto.Usuarioid,
                            Estatusdoctoid = 0,
                            Usuarioid = docto.Usuarioid,
                            Corteid = docto.Corteid,
                            Fecha = docto.Fecha ?? DateTimeOffset.Now,
                            Fechahora = docto.Fechahora ?? DateTimeOffset.Now,
                            Serie = null,
                            Folio = null,
                            Importe = 0m,
                            Descuento = 0m,
                            Subtotal = 0m,
                            Iva = 0m,
                            Ieps = 0m,
                            Total = 0m,
                            Cargo = 0m,
                            Abono = 0m,
                            Saldo = 0m,
                            Cajaid = docto.Cajaid,
                            Almacenid = docto.Almacenid,
                            Origenfiscalid = docto.Origenfiscalid,
                            Esapartado = docto.Esapartado,
                            Doctoparentid = doctoId,
                            Clienteid = docto.Clienteid,
                            Tipodoctoid = 501,
                            Proveedorid = docto.Proveedorid,
                            Sucursal_id = docto.Sucursal_id,
                            Referencia = null,
                            Referencias = null,
                            Fechavence = null

                        };
                        _doctoService.DoctoInsert(doctoTrans, ref doctoIdKitDesglose, localContext);
                    }

                    movtoIdKitDesglose = null;

                    var movtoTrans = new MovtoTransaccion()
                    {

                        Empresaid = empresaId,
                        Sucursalid = sucursalId,
                        //Id = null,
                        Activo = BoolCS.S,
                        Creado = DateTimeOffset.Now,
                        Creadopor_userid = docto.Usuarioid,
                        Partida = null,
                        Estatusmovtoid = 0,
                        Fecha = DateTimeOffset.UtcNow.Date,
                        Fechahora = DateTimeOffset.UtcNow,
                        Productoid = movKitDef.Productoid,
                        Cantidad = cantidadAArmar,
                        Preciolista = movKitDef.Preciolista,
                        Descuentoporcentaje = movKitDef.Descuentoporcentaje,
                        Descuento = 0m,
                        Precio = movKitDef.Precio,
                        Importe = 0m,
                        Subtotal = 0m,
                        Iva = 0m,
                        Ieps = 0m,
                        Tasaiva = movKitDef.Tasaiva,
                        Tasaieps = movKitDef.Tasaieps,
                        Total = 0m,
                        Lote = movKitDef.Lote,
                        Fechavence = movKitDef.Fechavence,
                        Loteimportado = movKitDef.Loteimportado,
                        Movtoparentid = movKitDef.Movtoid,
                        Movtonivel = 0,
                        Afectainventario = BoolCS.S,
                        Afectatotales = BoolCS.S,
                        Eskit = movKitDef.Eskit,
                        Kitimpfijo = movKitDef.Kitimpfijo,
                        Doctoid = doctoIdKitDesglose,
                        Cargo = 0m,
                        Abono = 0m,
                        Saldo = 0m,
                        Preciomanual = 0m,
                        Preciomaximopublico = 0m,
                        Isrretenido = 0m,
                        Ivaretenido = 0m,
                        Orden = 0,
                        Tasaisrretenido = 0m,
                        Tasaivaretenido = 0m,
                        Calc_imp_de_total = BoolCN.N,
                        Localidad = null,
                        Descripcion1 = null,
                        Descripcion2 = null,
                        Descripcion3 = null,
                        Agrupaporparametro = null,
                        Cargartarjetapreciomanual = null,
                        Precioyavalidado = null,
                        Usuarioid = null,
                        Precioconimp = null,
                        Anaquelid = null,
                        Movtoadevolverid = null

                    };
                    MovtoInsert(movtoTrans, ref movtoIdKitDesglose, localContext);

                    var movto_precio = new Movto_precio()
                    {
                        EmpresaId = empresaId,
                        SucursalId = sucursalId,
                        //Id = null,
                        Activo = BoolCS.S,
                        Creado = DateTimeOffset.Now,
                        CreadoPorId = docto.Usuarioid,
                        Razondescuentocajero = "",
                        Preciomanualmasbajo = BoolCN.N,
                        Descuentovale = 0m,
                        Descuentovaleporcentaje = 0m,
                        Movtoid = movtoIdKitDesglose,
                        Ingresopreciomanual = BoolCN.N,
                        Porcentajedescuentomanual = 0m,
                        Precioclasificacion = null,
                        Precioconimp = 0m,
                        Calc_imp_de_total = BoolCN.N
                    };
                    localContext.Add(movto_precio);


                }


                if (doctoIdKitDesglose != null)
                {
                    this.Ensamble_kit_completar(empresaId, sucursalId, doctoIdKitDesglose!.Value, localContext);

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



        public void DesEnsamble_kit_completar(long empresaId, long sucursalId, long doctoId,
            ApplicationDbContext localContext)
        {




            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;


            long? doctoIdKitDesglose = null;
            long? movtoIdKitDesglose = null;

            try
            {
                var docto = localContext.Docto.AsNoTracking()
                                              .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && d.Id == doctoId)
                                              .FirstOrDefault();

                if (docto == null)
                    throw new Exception("Docto no encontrado");

                if (docto.Tipodoctoid != 502)
                    throw new Exception("este tipo de documento no puede completar ensamble de  kits");

                if (docto.Estatusdoctoid != 0)
                    throw new Exception("este estatus de documento no puede completar ensamble de  kits");



                var movtoKitDesgloses = localContext.Movto_kit_def.AsNoTracking()
                                            .Include(m => m.Movto)
                                            .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Movto!.Doctoid == doctoId)
                                            .Select(mkd => new {
                                                mkd.Movtoid,
                                                Productoid = mkd.Productoparteid,
                                                Cantidad = mkd.Cantidadpartetotal,
                                                Precio = mkd.Precioporunidad,
                                                mkd.Tasaieps,
                                                mkd.Tasaiva
                                            })
                                            .ToList();

                foreach (var movKitDef in movtoKitDesgloses)
                {

                    //MLG TODO revisar lo de la generacion de ids
                    if (doctoIdKitDesglose == null)
                    {
                        var doctoTrans = new DoctoTransaction()
                        {
                            Empresaid = empresaId,
                            Sucursalid = sucursalId,
                            //Id = null,
                            Activo = BoolCS.S,
                            Creado = DateTimeOffset.Now,
                            Creadopor_userid = docto.Usuarioid,
                            Estatusdoctoid = 0,
                            Usuarioid = docto.Usuarioid,
                            Corteid = docto.Corteid,
                            Fecha = docto.Fecha ?? DateTimeOffset.Now,
                            Fechahora = docto.Fechahora ?? DateTimeOffset.Now,
                            Serie = null,
                            Folio = null,
                            Importe = 0m,
                            Descuento = 0m,
                            Subtotal = 0m,
                            Iva = 0m,
                            Ieps = 0m,
                            Total = 0m,
                            Cargo = 0m,
                            Abono = 0m,
                            Saldo = 0m,
                            Cajaid = docto.Cajaid,
                            Almacenid = docto.Almacenid,
                            Origenfiscalid = docto.Origenfiscalid,
                            Esapartado = docto.Esapartado,
                            Doctoparentid = doctoId,
                            Clienteid = docto.Clienteid,
                            Tipodoctoid = 504,
                            Proveedorid = docto.Proveedorid,
                            Sucursal_id = docto.Sucursal_id,
                            Referencia = null,
                            Referencias = null,
                            Fechavence = null

                        };
                        _doctoService.DoctoInsert(doctoTrans, ref doctoIdKitDesglose, localContext);
                    }

                    movtoIdKitDesglose = null;

                    var movtoTrans = new MovtoTransaccion()
                    {

                        Empresaid = empresaId,
                        Sucursalid = sucursalId,
                        //Id = null,
                        Activo = BoolCS.S,
                        Creado = DateTimeOffset.Now,
                        Creadopor_userid = docto.Usuarioid,
                        Partida = null,
                        Estatusmovtoid = 0,
                        Fecha = DateTimeOffset.UtcNow.Date,
                        Fechahora = DateTimeOffset.UtcNow,
                        Productoid = movKitDef.Productoid,
                        Cantidad = movKitDef.Cantidad,
                        Preciolista = movKitDef.Precio,
                        Descuentoporcentaje = 0m,
                        Descuento = 0m,
                        Precio = movKitDef.Precio,
                        Importe = 0m,
                        Subtotal = 0m,
                        Iva = 0m,
                        Ieps = 0m,
                        Tasaiva = movKitDef.Tasaiva,
                        Tasaieps = movKitDef.Tasaieps,
                        Total = 0m,
                        Lote = null,
                        Fechavence = null,
                        Loteimportado = null,
                        Movtoparentid = movKitDef.Movtoid,
                        Movtonivel = 0,
                        Afectainventario = BoolCS.S,
                        Afectatotales = BoolCS.S,
                        Eskit = BoolCN.N,
                        Kitimpfijo = BoolCN.N,
                        Doctoid = doctoIdKitDesglose,
                        Cargo = 0m,
                        Abono = 0m,
                        Saldo = 0m,
                        Preciomanual = 0m,
                        Preciomaximopublico = 0m,
                        Isrretenido = 0m,
                        Ivaretenido = 0m,
                        Orden = 0,
                        Tasaisrretenido = 0m,
                        Tasaivaretenido = 0m,
                        Calc_imp_de_total = BoolCN.N,
                        Localidad = null,
                        Descripcion1 = null,
                        Descripcion2 = null,
                        Descripcion3 = null,
                        Agrupaporparametro = null,
                        Cargartarjetapreciomanual = null,
                        Precioyavalidado = null,
                        Usuarioid = null,
                        Precioconimp = null,
                        Anaquelid = null,
                        Movtoadevolverid = null

                    };
                    MovtoInsert(movtoTrans, ref movtoIdKitDesglose, localContext);

                    var movto_precio = new Movto_precio()
                    {
                        EmpresaId = empresaId,
                        SucursalId = sucursalId,
                        //Id = null,
                        Activo = BoolCS.S,
                        Creado = DateTimeOffset.Now,
                        CreadoPorId = docto.Usuarioid,
                        Razondescuentocajero = "",
                        Preciomanualmasbajo = BoolCN.N,
                        Descuentovale = 0m,
                        Descuentovaleporcentaje = 0m,
                        Movtoid = movtoIdKitDesglose,
                        Ingresopreciomanual = BoolCN.N,
                        Porcentajedescuentomanual = 0m,
                        Precioclasificacion = null,
                        Precioconimp = 0m,
                        Calc_imp_de_total = BoolCN.N
                    };
                    localContext.Add(movto_precio);


                }

                if (doctoIdKitDesglose != null)
                {
                    this.Docto_ensamble_update_status(empresaId, sucursalId, doctoIdKitDesglose!.Value, 1, localContext);

                    //MLG TODO checar si se requiere hacer esto aqui
                    this.Docto_ensamble_update_status(empresaId, sucursalId, doctoId, 1, localContext);
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

        public void Docto_delete(long empresaId, long sucursalId, long id,
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {
                var doctoInfo = localContext.Docto.AsNoTracking()
                                            .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && d.Id == id)
                                            .Select(d => new { d.Estatusdoctoid })
                                            .FirstOrDefault();

                if (doctoInfo == null)
                    throw new Exception("El docto no fue encontrado");

                if (doctoInfo.Estatusdoctoid != 0)
                    throw new Exception("No se puede eliminar un registro que no este en borrador");

                var movtoIds = localContext.Movto.AsNoTracking()
                                           .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Doctoid == id)
                                           .Select(m => m.Id)
                                           .ToList();

                if (movtoIds != null && movtoIds.Count() > 0)
                {
                    foreach (var movtoid in movtoIds)
                    {
                        Movto_delete(empresaId, sucursalId, movtoid, localContext);
                    }
                }

                localContext.Docto_kit
                    .Where(f => f.EmpresaId == empresaId && f.SucursalId == sucursalId && f.Doctoid == id)
                    .Delete();

                localContext.Docto_fact_elect
                    .Where(f => f.EmpresaId == empresaId && f.SucursalId == sucursalId && f.Doctoid == id)
                    .Delete();


                localContext.Docto_compra
                    .Where(f => f.EmpresaId == empresaId && f.SucursalId == sucursalId && f.Doctoid == id)
                    .Delete();

                localContext.Docto_traslado
                    .Where(f => f.EmpresaId == empresaId && f.SucursalId == sucursalId && f.Doctoid == id)
                    .Delete();

                localContext.Docto_poliza
                    .Where(f => f.EmpresaId == empresaId && f.SucursalId == sucursalId && f.Doctoid == id)
                    .Delete();

                localContext.Docto_apartado
                    .Where(f => f.EmpresaId == empresaId && f.SucursalId == sucursalId && f.Doctoid == id)
                    .Delete();

                localContext.Docto_devolucion
                    .Where(f => f.EmpresaId == empresaId && f.SucursalId == sucursalId && f.Doctoid == id)
                    .Delete();

                localContext.Docto_surtido
                    .Where(f => f.EmpresaId == empresaId && f.SucursalId == sucursalId && f.Doctoid == id)
                    .Delete();


                localContext.Docto_precio
                    .Where(f => f.EmpresaId == empresaId && f.SucursalId == sucursalId && f.Doctoid == id)
                    .Delete();



                localContext.Docto
                    .Where(f => f.EmpresaId == empresaId && f.SucursalId == sucursalId && f.Id == id)
                    .Delete();


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


        public void Docto_update_status(long empresaId, long sucursalId, long id, long estatusDoctoId,
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {

                var docto = localContext.Docto
                                        .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && d.Id == id)
                                        .FirstOrDefault();
                if (docto == null)
                    throw new Exception("No existe el documento");

                var previoEstatusdoctoid = docto.Estatusdoctoid;

                docto.Estatusdoctoid = estatusDoctoId;
                localContext.Update(docto);


                if (estatusDoctoId == 1 && (docto.Folio == null || docto.Folio == 0))
                {
                    long folioDocto = 0;
                    _maestroConsecutivoService.GenerarConsecutivo(empresaId, sucursalId, Tipo_consecutivo.FolioDocto, docto.Tipodoctoid,
                                                                    "Docto", "Folio", "public", "Serie", docto.Serie, "Tipodoctoid",
                                                                    out folioDocto, localContext);

                    if (folioDocto > 0)
                    {
                        docto.Folio = (int)folioDocto;
                        localContext.Update(docto);
                    }

                    var tipoDocto = localContext.Tipodocto.AsNoTracking()
                                                .Where(t => t.Id == docto.Tipodoctoid)
                                                .Select(t => new { t.Sentidoabonocliente, t.Sentidoabonoproveedor, t.Sentidopago })
                                                .FirstOrDefault();

                    if (tipoDocto == null)
                        return;
                    //throw new Exception("Tipo docto no encontrado");

                    if (tipoDocto.Sentidoabonocliente != 0 || tipoDocto.Sentidoabonoproveedor != 0)
                    {
                        Kardex_abono_transaccion kat = new Kardex_abono_transaccion()
                        {

                            Empresaid = empresaId,
                            Sucursalid = sucursalId,
                            Activo = BoolCS.S,
                            Creado = DateTimeOffset.Now,
                            Creadopor_userid = docto.Usuarioid,
                            Tipomovimientokardexabonoid = 1,
                            Fechahora = DateTimeOffset.Now,
                            Importe = docto.Total,
                            Importecambio = 0m,
                            Clienteid = docto.Clienteid,
                            Proveedorid = docto.Proveedorid,
                            Pagoid = null,
                            Doctopagoid = null,
                            Formapagoid = null,
                            Doctoid = id,
                            Tipodoctoid = docto.Tipodoctoid,
                            Corteid = docto.Corteid,
                            Sentidoabonodocto = 0,
                            Sentidoabonocliente = tipoDocto.Sentidoabonocliente,
                            Sentidoabonoproveedor = tipoDocto.Sentidoabonoproveedor,
                            Sentidoabonocorte = 0
                        };

                        _pagoService.Kardex_abono_insert_basico(kat, localContext);
                    }

                    if (tipoDocto.Sentidopago != 0 && docto.Usuarioid != null)
                    {
                        _pagoService.Pago_completar_by_docto(empresaId, sucursalId, id, docto.Usuarioid!.Value, localContext);

                    }



                    _pagoService.Docto_recalcular_saldos(empresaId, sucursalId, id, localContext);

                    if (docto.Clienteid != null)
                        _pagoService.Cliente_recalcular_saldos(empresaId, sucursalId, docto.Clienteid.Value, localContext);

                    if (docto.Proveedorid != null)
                        _pagoService.Proveedor_recalcular_saldos(empresaId, sucursalId, docto.Proveedorid.Value, localContext);


                    Ensamble_kit_al_vuelo(empresaId, sucursalId, id, localContext);


                }


            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                localContext.ChangeTracker.LazyLoadingEnabled = previousLazyLoadingEnabledValue;
            }

        }


        public void Docto_general_update_status(
            long empresaId, long sucursalId,
            long doctoId,  long estatusDoctoId ,
            ApplicationDbContext localContext)
        {


            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {


                Docto_update_status(empresaId, sucursalId, doctoId, estatusDoctoId, localContext);

                var movtoInfo_list = localContext.Movto.AsNoTracking()
                                                    .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Doctoid == doctoId)
                                                    .Select(m => new { m.Id })
                                                    .ToList();
                foreach (var movtoInfo in movtoInfo_list)
                {
                    _movtoService.MovtoUpdateStatus(empresaId, sucursalId, movtoInfo.Id, estatusDoctoId, localContext);
                }

                localContext.SaveChanges();

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


        public void Docto_cancel(long empresaId, long sucursalId, 
            long doctoId,long creadoPorId , ref long? doctoCancelacionId,
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            long? corteid;
            BoolCS? corte_activo;
            DateTimeOffset? fechacorte;
            DateTimeOffset? corte_inicia;
            DateTimeOffset? corte_termina;


            try
            {
                _corteService.HayCorteActivo(empresaId, sucursalId, creadoPorId,
                                               out corteid, out corte_activo, out fechacorte, out corte_inicia, out corte_termina, localContext);

                if (corteid == null || corteid == 0)
                {
                    throw new Exception("No hay corte activo");
                }

                var doctoInfo = localContext.Docto.AsNoTracking()
                                            .Include(d => d.Tipodocto)
                                            .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && d.Id == doctoId)
                                            .Select(d => new { d.Estatusdoctoid, d.Tipodoctoid, d.Tipodocto!.Tipodoctocancelacionid })
                                            .FirstOrDefault();

                if(doctoInfo == null )
                    throw new Exception("No hay docto");

                if ((doctoInfo.Estatusdoctoid ?? 0) != 1) 
                    throw new Exception("Solo se pueden cancelar documentos que esten en estado activo");

                if((doctoInfo.Tipodoctocancelacionid ?? 0) == 0)
                    throw new Exception("Este tipo de documento no se puede cancelar");

                doctoCancelacionId = null;
                DoctoCopy(empresaId, sucursalId, doctoId, DateTimeOffset.UtcNow, creadoPorId, doctoInfo.Tipodoctocancelacionid!.Value, 0, 0, ref doctoCancelacionId, localContext);

                if (doctoCancelacionId == null)
                    throw new Exception("El documento no se pudo cancelar");

                _pagoService.Pago_copiar_para_cancelar(empresaId, sucursalId, doctoId, doctoCancelacionId!.Value, creadoPorId, corteid!.Value, localContext);


                Docto_general_update_status(empresaId, sucursalId, doctoCancelacionId!.Value, 1, localContext);

                Docto_general_update_status(empresaId, sucursalId, doctoId, 2, localContext);

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




        public void DoctoCopy(
              long empresaId, long sucursalId, long doctoIdACopiar,
              DateTimeOffset creado, long creadoPorId,
              long tipoDoctoId, long estatusDoctoId, long estatusMovtoId,
              ref long? doctoId, ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {

                var doctoACopiar = localContext.Docto.AsNoTracking()
                                         .Include(d => d.Docto_traslado)
                                         .Include(d => d.Docto_apartado)
                                         .Include(d => d.Docto_farmacia)
                                         .Include(d => d.Docto_loteimportado)
                                         .Include(d => d.Docto_compra)
                                         .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && d.Id == doctoIdACopiar)
                                         .FirstOrDefault();

                if (doctoACopiar == null)
                    throw new Exception("El docto no existe");



                var doctoTrans = new DoctoTransaction()
                {
                    Empresaid = doctoACopiar.EmpresaId,
                    Sucursalid = doctoACopiar.SucursalId,
                    Activo = BoolCS.S,
                    Creado = DateTimeOffset.Now,
                    Creadopor_userid = creadoPorId,
                    Estatusdoctoid = estatusDoctoId,
                    Usuarioid = creadoPorId,
                    Corteid = null,
                    Fecha = DateTimeOffset.Now.Date,
                    Fechahora = DateTimeOffset.Now,
                    Serie = null,
                    Folio = doctoACopiar.Folio,
                    Importe = 0m,
                    Descuento = 0m,
                    Subtotal = 0m,
                    Iva = 0m,
                    Ieps = 0m,
                    Total = 0m,
                    Cargo = 0m,
                    Abono = 0m,
                    Saldo = 0m,
                    Cajaid = doctoACopiar.Cajaid,
                    Almacenid = doctoACopiar.Almacenid,
                    Origenfiscalid = doctoACopiar.Origenfiscalid,
                    Esapartado = doctoACopiar.Esapartado,
                    Doctoparentid = doctoIdACopiar,
                    Clienteid = doctoACopiar.Clienteid,
                    Tipodoctoid = tipoDoctoId,
                    Proveedorid = doctoACopiar.Proveedorid,
                    Sucursal_id = doctoACopiar.Sucursal_id,
                    Referencia = doctoACopiar.Referencia,
                    Referencias = doctoACopiar.Referencias,
                    Fechavence = doctoACopiar.Fechavence

            };

                long? doctoCopiaId = null;
                _doctoService.DoctoInsert(doctoTrans, ref doctoCopiaId, localContext);

                doctoId = doctoCopiaId;

                doctoTrans.Id = doctoCopiaId!.Value;

                var movtosACopiar = localContext.Movto.AsNoTracking()
                                                .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Doctoid == doctoIdACopiar)
                                                .ToList();
                long? movtoBufferId = null;
                foreach( var movto in movtosACopiar)
                {
                    MovtoCopy(empresaId, sucursalId, movto.Id, creado, creadoPorId, doctoCopiaId!.Value, estatusMovtoId, ref movtoBufferId, localContext);
                }


                bool bufferIsNewRecord = false;

                //if (doctoACopiar.Docto_traslado != null)
                //{

                //    //docto_traslado
                //    var docto_traslado = localContext.Docto_traslado
                //                                   .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && d.Doctoid == doctoCopiaId)
                //                                   .FirstOrDefault();

                //    if (docto_traslado == null)
                //    {
                //        docto_traslado = new Docto_traslado();
                //        docto_traslado.EmpresaId = doctoACopiar.Docto_traslado.EmpresaId;
                //        docto_traslado.SucursalId = doctoACopiar.Docto_traslado.SucursalId;
                //        docto_traslado.Creado = DateTimeOffset.UtcNow;
                //        docto_traslado.Modificado = DateTimeOffset.UtcNow;
                //        docto_traslado.CreadoPorId = creadoPorId;
                //        docto_traslado.ModificadoPorId = creadoPorId;
                //        docto_traslado.Doctoid = doctoCopiaId;

                //        bufferIsNewRecord = true;
                //    }
                //    else
                //        bufferIsNewRecord = false;

                //    docto_traslado.Foliosolicitudmercancia = doctoACopiar.Docto_traslado.Foliosolicitudmercancia;
                //    docto_traslado.Foliotrasladooriginal = doctoACopiar.Docto_traslado.Foliotrasladooriginal;
                //    docto_traslado.Estraslado = doctoACopiar.Docto_traslado.Estraslado;
                //    docto_traslado.Esdevolucion = doctoACopiar.Docto_traslado.Esdevolucion;
                //    docto_traslado.Foliodevolucion = doctoACopiar.Docto_traslado.Foliodevolucion;
                //    docto_traslado.Essurtimientomerca = doctoACopiar.Docto_traslado.Essurtimientomerca;
                //    docto_traslado.Sucursaltid = doctoACopiar.Docto_traslado.Sucursaltid;
                //    docto_traslado.Almacentid = doctoACopiar.Docto_traslado.Almacentid;
                //    docto_traslado.Doctoimportadoid = doctoACopiar.Docto_traslado.Doctoimportadoid;
                //    docto_traslado.Idsolicitudmercancia = doctoACopiar.Docto_traslado.Idsolicitudmercancia;
                //    docto_traslado.Idtrasladooriginal = doctoACopiar.Docto_traslado.Idtrasladooriginal;
                //    docto_traslado.Iddevolucion = doctoACopiar.Docto_traslado.Iddevolucion;

                //    if (bufferIsNewRecord)
                //        localContext.Add(docto_traslado);
                //    else
                //        localContext.Update(docto_traslado);
                //}


                if (doctoACopiar.Docto_apartado != null)
                {

                    //docto_apartado
                    var docto_apartado = localContext.Docto_apartado
                                                   .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && d.Doctoid == doctoCopiaId)
                                                   .FirstOrDefault();

                    if (docto_apartado == null)
                    {
                        docto_apartado = new Docto_apartado();
                        docto_apartado.EmpresaId = doctoACopiar.Docto_apartado.EmpresaId;
                        docto_apartado.SucursalId = doctoACopiar.Docto_apartado.SucursalId;
                        docto_apartado.Creado = DateTimeOffset.UtcNow;
                        docto_apartado.Modificado = DateTimeOffset.UtcNow;
                        docto_apartado.CreadoPorId = creadoPorId;
                        docto_apartado.ModificadoPorId = creadoPorId;
                        docto_apartado.Doctoid = doctoCopiaId;

                        bufferIsNewRecord = true;
                    }
                    else
                        bufferIsNewRecord = false;

                    docto_apartado.Mercanciaentregada = doctoACopiar.Docto_apartado.Mercanciaentregada;
                    docto_apartado.Personaapartadoid = doctoACopiar.Docto_apartado.Personaapartadoid;


                    if (bufferIsNewRecord)
                        localContext.Add(docto_apartado);
                    else
                        localContext.Update(docto_apartado);
                }


                if (doctoACopiar.Docto_farmacia != null)
                {

                    //docto_farmacia
                    var docto_farmacia = localContext.Docto_farmacia
                                                   .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && d.Doctoid == doctoCopiaId)
                                                   .FirstOrDefault();

                    if (docto_farmacia == null)
                    {
                        docto_farmacia = new Docto_farmacia();
                        docto_farmacia.EmpresaId = doctoACopiar.Docto_farmacia.EmpresaId;
                        docto_farmacia.SucursalId = doctoACopiar.Docto_farmacia.SucursalId;
                        docto_farmacia.Creado = DateTimeOffset.UtcNow;
                        docto_farmacia.Modificado = DateTimeOffset.UtcNow;
                        docto_farmacia.CreadoPorId = creadoPorId;
                        docto_farmacia.ModificadoPorId = creadoPorId;
                        docto_farmacia.Doctoid = doctoCopiaId;

                        bufferIsNewRecord = true;
                    }
                    else
                        bufferIsNewRecord = false;

                    docto_farmacia.Manejoreceta = doctoACopiar.Docto_farmacia.Manejoreceta;

                    if (bufferIsNewRecord)
                        localContext.Add(docto_farmacia);
                    else
                        localContext.Update(docto_farmacia);
                }

                if (doctoACopiar.Docto_loteimportado != null)
                {

                    //docto_loteimportado
                    var docto_loteimportado = localContext.Docto_loteimportado
                                                   .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && d.Doctoid == doctoCopiaId)
                                                   .FirstOrDefault();

                    if (docto_loteimportado == null)
                    {
                        docto_loteimportado = new Docto_loteimportado();
                        docto_loteimportado.EmpresaId = doctoACopiar.Docto_loteimportado.EmpresaId;
                        docto_loteimportado.SucursalId = doctoACopiar.Docto_loteimportado.SucursalId;
                        docto_loteimportado.Creado = DateTimeOffset.UtcNow;
                        docto_loteimportado.Modificado = DateTimeOffset.UtcNow;
                        docto_loteimportado.CreadoPorId = creadoPorId;
                        docto_loteimportado.ModificadoPorId = creadoPorId;
                        docto_loteimportado.Doctoid = doctoCopiaId;

                        bufferIsNewRecord = true;
                    }
                    else
                        bufferIsNewRecord = false;

                    docto_loteimportado.Loteimportadodoctoid = doctoACopiar.Docto_loteimportado.Loteimportadodoctoid;

                    if (bufferIsNewRecord)
                        localContext.Add(docto_loteimportado);
                    else
                        localContext.Update(docto_loteimportado);
                }



                if (doctoACopiar.Docto_compra != null)
                {

                    //docto_compra
                    var docto_compra = localContext.Docto_compra
                                                   .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && d.Doctoid == doctoCopiaId)
                                                   .FirstOrDefault();

                    if (docto_compra == null)
                    {
                        docto_compra = new Docto_compra();
                        docto_compra.EmpresaId = doctoACopiar.Docto_compra.EmpresaId;
                        docto_compra.SucursalId = doctoACopiar.Docto_compra.SucursalId;
                        docto_compra.Creado = DateTimeOffset.UtcNow;
                        docto_compra.Modificado = DateTimeOffset.UtcNow;
                        docto_compra.CreadoPorId = creadoPorId;
                        docto_compra.ModificadoPorId = creadoPorId;
                        docto_compra.Doctoid = doctoCopiaId;

                        bufferIsNewRecord = true;
                    }
                    else
                        bufferIsNewRecord = false;

                    docto_compra.Folio = doctoACopiar.Docto_compra.Folio;
                    docto_compra.Factura = doctoACopiar.Docto_compra.Factura;
                    docto_compra.Fechafactura = doctoACopiar.Docto_compra.Fechafactura;

                    if (bufferIsNewRecord)
                        localContext.Add(docto_compra);
                    else
                        localContext.Update(docto_compra);
                }


                localContext.SaveChanges();





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


        #endregion


        #region Movto operations
        public void MovtoInsert(MovtoTransaccion movtoTrans, ref long? movtoId, ApplicationDbContext localContext)
        {

            long? clienteId;
            long? almacenId;
            long? tipoDoctoId;



            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {
                movtoTrans.Tasaiva = movtoTrans.Tasaiva != null ? movtoTrans.Tasaiva : 0m;
                movtoTrans.Tasaieps = movtoTrans.Tasaieps != null ? movtoTrans.Tasaieps : 0m;

                var doctoInfo = localContext.Docto.AsNoTracking()
                                            .Where(d => d.EmpresaId == movtoTrans.Empresaid && d.SucursalId == movtoTrans.Sucursalid &&
                                                        d.Id == movtoTrans.Doctoid)
                                            .Select(d => new { d.Clienteid, d.Almacenid, d.Tipodoctoid })
                                            .FirstOrDefault();

                if (doctoInfo == null)
                    throw new Exception("Docto no encontrado");

                clienteId = doctoInfo.Clienteid;
                almacenId = doctoInfo.Almacenid;
                tipoDoctoId = doctoInfo.Tipodoctoid;

                decimal? precio = movtoTrans.Precio;
                decimal? precioconimp = movtoTrans.Precioconimp;
                decimal? total = movtoTrans.Total;
                decimal? importe = movtoTrans.Importe;
                decimal? subtotal = movtoTrans.Subtotal;
                decimal? iva = movtoTrans.Iva;
                decimal? ieps = movtoTrans.Ieps;
                decimal? impuesto = 0m;
                decimal? descuento = movtoTrans.Descuento;
                decimal? ivaRetenido = movtoTrans.Ivaretenido;
                decimal? isrRetenido = movtoTrans.Isrretenido;
                decimal? tasaIvaRetenido = movtoTrans.Tasaivaretenido;
                decimal? tasaIsrRetenido = movtoTrans.Tasaisrretenido;

                BoolCN esKit = movtoTrans.Eskit ?? BoolCN.N;
                BoolCN kitimpfijo = movtoTrans.Kitimpfijo ?? BoolCN.N;
                BoolCN calc_imp_de_total = movtoTrans.Calc_imp_de_total ?? BoolCN.N;

                decimal cantidad = movtoTrans.Cantidad ?? 0m;

                List<MovtoKitdefinicionBuffer> movto_kit_def_arr = new List<MovtoKitdefinicionBuffer>();

                _movtoService.CalcularImpuestosTotalesMovto(movtoTrans.Empresaid, movtoTrans.Sucursalid, movtoTrans.Productoid!.Value,
                  cantidad, movtoTrans.Preciolista!.Value,
                  movtoTrans.Tasaiva, movtoTrans.Tasaieps,
                  esKit, kitimpfijo, calc_imp_de_total,
                  movtoTrans.Id, clienteId,
                  ref precio, ref precioconimp, ref total,
                  out importe, out subtotal, out iva, out ieps,
                  out impuesto, out descuento,
                  out ivaRetenido, out isrRetenido,
                  out tasaIvaRetenido, out tasaIsrRetenido,
                  out movto_kit_def_arr, localContext
                );





                Movto movtoItem = new Movto();
                movtoItem.Modificado = DateTimeOffset.UtcNow;
                movtoItem.ModificadoPorId = movtoTrans.Creadopor_userid;
                movtoItem.EmpresaId = movtoTrans.Empresaid;
                movtoItem.SucursalId = movtoTrans.Sucursalid;
                movtoItem.Id = movtoTrans.Id;
                movtoItem.Activo = movtoTrans.Activo ?? BoolCS.S;
                movtoItem.Creado = DateTimeOffset.UtcNow;
                movtoItem.CreadoPorId = movtoTrans.Creadopor_userid;
                movtoItem.Partida = movtoTrans.Partida ?? 1;
                movtoItem.Estatusmovtoid = movtoTrans.Estatusmovtoid;
                movtoItem.Fecha = movtoTrans.Fecha;
                movtoItem.Fechahora = movtoTrans.Fechahora;
                movtoItem.Productoid = movtoTrans.Productoid;
                movtoItem.Cantidad = cantidad;
                movtoItem.Preciolista = movtoTrans.Preciolista ?? 0m;
                movtoItem.Descuentoporcentaje = movtoTrans.Descuentoporcentaje ?? 0m;
                movtoItem.Descuento = descuento ?? 0m;
                movtoItem.Precio = precio ?? 0m;
                movtoItem.Importe = importe ?? 0m;
                movtoItem.Subtotal = subtotal ?? 0m;
                movtoItem.Iva = iva ?? 0m;
                movtoItem.Ieps = ieps ?? 0m;
                movtoItem.Tasaiva = movtoTrans.Tasaiva ?? 0m;
                movtoItem.Tasaieps = movtoTrans.Tasaieps ?? 0m;
                movtoItem.Total = total ?? 0m;
                movtoItem.Lote = movtoTrans.Lote;
                movtoItem.Fechavence = movtoTrans.Fechavence;
                movtoItem.Loteimportado = movtoTrans.Loteimportado;
                movtoItem.Movtoparentid = movtoTrans.Movtoparentid;
                movtoItem.Movtonivel = movtoTrans.Movtonivel ?? 0;
                movtoItem.Afectainventario = movtoTrans.Afectainventario ?? BoolCS.S;
                movtoItem.Afectatotales = movtoTrans.Afectatotales ?? BoolCS.S;
                movtoItem.Eskit = movtoTrans.Eskit ?? BoolCN.N;
                movtoItem.Kitimpfijo = movtoTrans.Kitimpfijo ?? BoolCN.N;
                movtoItem.Doctoid = movtoTrans.Doctoid;
                movtoItem.Cargo = movtoTrans.Cargo ?? 0m;
                movtoItem.Abono = movtoTrans.Abono ?? 0m;
                movtoItem.Saldo = movtoTrans.Saldo ?? 0m;
                movtoItem.Preciomanual = movtoTrans.Preciomanual ?? 0m;
                movtoItem.Preciomaximopublico = movtoTrans.Preciomaximopublico ?? 0m;
                movtoItem.Isrretenido = isrRetenido ?? 0m;
                movtoItem.Ivaretenido = ivaRetenido ?? 0m;
                movtoItem.Orden = movtoTrans.Orden ?? 0;
                movtoItem.Tasaisrretenido = tasaIsrRetenido ?? 0m;
                movtoItem.Tasaivaretenido = tasaIvaRetenido ?? 0m;

                localContext.Movto.Add(movtoItem);

                localContext.SaveChanges();

                movtoId = movtoItem.Id;

                //kit
                if (esKit == BoolCN.S)
                {
                    _movtoService.ProcesarMovtoKitDefFromArray(movtoTrans.Empresaid, movtoTrans.Sucursalid, movtoItem.Id,
                                                movto_kit_def_arr, localContext);
                }


                //en proceso salida
                if (movtoTrans.Estatusmovtoid == 0)
                {
                    _inventarioService.MovtoAplicarEnProcesoSalida(movtoTrans.Empresaid, movtoTrans.Sucursalid, movtoItem.Id, cantidad, localContext);
                }

                _doctoService.SincronizarTotales(movtoTrans.Empresaid, movtoTrans.Sucursalid, movtoTrans.Doctoid!.Value, localContext);

                localContext.SaveChanges();

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



        public void MovtoUpdate(MovtoTransaccion movtoTrans, ApplicationDbContext localContext)
        {

            long? clienteId;
            long? almacenId;
            long? tipoDoctoId;

            decimal cantidadAnterior = 0m;
            long? estatusMovtoIdAnterior = null;



            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {
                movtoTrans.Tasaiva = movtoTrans.Tasaiva != null ? movtoTrans.Tasaiva : 0m;
                movtoTrans.Tasaieps = movtoTrans.Tasaieps != null ? movtoTrans.Tasaieps : 0m;

                var doctoInfo = localContext.Docto.AsNoTracking()
                                            .Where(d => d.EmpresaId == movtoTrans.Empresaid && d.SucursalId == movtoTrans.Sucursalid &&
                                                        d.Id == movtoTrans.Doctoid)
                                            .Select(d => new { d.Clienteid, d.Almacenid, d.Tipodoctoid })
                                            .FirstOrDefault();

                if (doctoInfo == null)
                    throw new Exception("Docto no encontrado");

                clienteId = doctoInfo.Clienteid;
                almacenId = doctoInfo.Almacenid;
                tipoDoctoId = doctoInfo.Tipodoctoid;



                var movtoInfoActual = localContext.Movto.AsNoTracking()
                                                    .Where(m => m.EmpresaId == movtoTrans.Empresaid && m.SucursalId == movtoTrans.Sucursalid &&
                                                                m.Id == movtoTrans.Id)
                                                    .Select(m => new { m.Cantidad, m.Estatusmovtoid })
                                                    .FirstOrDefault();

                if (movtoInfoActual == null)
                    throw new Exception("No se encontro el movto");


                cantidadAnterior = movtoInfoActual.Cantidad;
                estatusMovtoIdAnterior = movtoInfoActual.Estatusmovtoid;


                decimal? precio = movtoTrans.Precio;
                decimal? precioconimp = movtoTrans.Precioconimp;
                decimal? total = movtoTrans.Total;
                decimal? importe = movtoTrans.Importe;
                decimal? subtotal = movtoTrans.Subtotal;
                decimal? iva = movtoTrans.Iva;
                decimal? ieps = movtoTrans.Ieps;
                decimal? impuesto = 0m;
                decimal? descuento = movtoTrans.Descuento;
                decimal? ivaRetenido = movtoTrans.Ivaretenido;
                decimal? isrRetenido = movtoTrans.Isrretenido;
                decimal? tasaIvaRetenido = movtoTrans.Tasaivaretenido;
                decimal? tasaIsrRetenido = movtoTrans.Tasaisrretenido;

                BoolCN esKit = movtoTrans.Eskit ?? BoolCN.N;
                BoolCN kitimpfijo = movtoTrans.Kitimpfijo ?? BoolCN.N;
                BoolCN calc_imp_de_total = movtoTrans.Calc_imp_de_total ?? BoolCN.N;

                decimal cantidad = movtoTrans.Cantidad ?? 0m;


                var movtoItem = localContext.Movto.FirstOrDefault(m => m.EmpresaId == movtoTrans.Empresaid && m.SucursalId == movtoTrans.Sucursalid &&
                                                                m.Id == movtoTrans.Id);
                if (movtoItem == null)
                    throw new Exception("El movto no fue encontrado");

                precio = precio != null ? precio : movtoItem.Precio;

                List<MovtoKitdefinicionBuffer> movto_kit_def_arr = new List<MovtoKitdefinicionBuffer>();

                _movtoService.CalcularImpuestosTotalesMovto(movtoTrans.Empresaid, movtoTrans.Sucursalid, movtoTrans.Productoid!.Value,
                  cantidad, movtoTrans.Preciolista!.Value,
                  movtoTrans.Tasaiva, movtoTrans.Tasaieps,
                  esKit, kitimpfijo, calc_imp_de_total,
                  movtoTrans.Id, clienteId,
                  ref precio, ref precioconimp, ref total,
                  out importe, out subtotal, out iva, out ieps,
                  out impuesto, out descuento,
                  out ivaRetenido, out isrRetenido,
                  out tasaIvaRetenido, out tasaIsrRetenido,
                  out movto_kit_def_arr, localContext
                );






                movtoItem.Modificado = DateTimeOffset.UtcNow;
                movtoItem.ModificadoPorId = movtoTrans.Creadopor_userid;
                movtoItem.Activo = movtoTrans.Activo ?? BoolCS.S;

                movtoItem.Partida = movtoTrans.Partida ?? 1;
                movtoItem.Estatusmovtoid = movtoTrans.Estatusmovtoid;
                movtoItem.Fecha = movtoTrans.Fecha;
                movtoItem.Fechahora = movtoTrans.Fechahora;
                movtoItem.Productoid = movtoTrans.Productoid;
                movtoItem.Cantidad = cantidad;
                movtoItem.Preciolista = movtoTrans.Preciolista ?? 0m;
                movtoItem.Descuentoporcentaje = movtoTrans.Descuentoporcentaje ?? 0m;
                movtoItem.Descuento = descuento ?? 0m;
                movtoItem.Precio = precio ?? 0m;
                movtoItem.Importe = importe ?? 0m;
                movtoItem.Subtotal = subtotal ?? 0m;
                movtoItem.Iva = iva ?? 0m;
                movtoItem.Ieps = ieps ?? 0m;
                movtoItem.Tasaiva = movtoTrans.Tasaiva ?? 0m;
                movtoItem.Tasaieps = movtoTrans.Tasaieps ?? 0m;
                movtoItem.Total = total ?? 0m;
                movtoItem.Lote = movtoTrans.Lote;
                movtoItem.Fechavence = movtoTrans.Fechavence;
                movtoItem.Loteimportado = movtoTrans.Loteimportado;
                movtoItem.Movtoparentid = movtoTrans.Movtoparentid;
                movtoItem.Movtonivel = movtoTrans.Movtonivel ?? 0;
                movtoItem.Afectainventario = movtoTrans.Afectainventario ?? BoolCS.S;
                movtoItem.Afectatotales = movtoTrans.Afectatotales ?? BoolCS.S;
                movtoItem.Eskit = movtoTrans.Eskit ?? BoolCN.N;
                movtoItem.Kitimpfijo = movtoTrans.Kitimpfijo ?? BoolCN.N;
                movtoItem.Doctoid = movtoTrans.Doctoid;
                movtoItem.Cargo = movtoTrans.Cargo ?? 0m;
                movtoItem.Abono = movtoTrans.Abono ?? 0m;
                movtoItem.Saldo = movtoTrans.Saldo ?? 0m;
                movtoItem.Preciomanual = movtoTrans.Preciomanual ?? 0m;
                movtoItem.Preciomaximopublico = movtoTrans.Preciomaximopublico ?? 0m;
                movtoItem.Isrretenido = isrRetenido ?? 0m;
                movtoItem.Ivaretenido = ivaRetenido ?? 0m;
                movtoItem.Orden = movtoTrans.Orden ?? 0;
                movtoItem.Tasaisrretenido = tasaIsrRetenido ?? 0m;
                movtoItem.Tasaivaretenido = tasaIvaRetenido ?? 0m;

                localContext.Movto.Update(movtoItem);

                localContext.SaveChanges();


                //kit
                if (esKit == BoolCN.S)
                {
                    _movtoService.ProcesarMovtoKitDefFromArray(movtoTrans.Empresaid, movtoTrans.Sucursalid, movtoItem.Id,
                                                movto_kit_def_arr, localContext);
                }


                //en proceso salida
                if (movtoTrans.Estatusmovtoid == 0)
                {
                    _inventarioService.MovtoAplicarEnProcesoSalida(movtoTrans.Empresaid, movtoTrans.Sucursalid, movtoItem.Id, cantidad - cantidadAnterior, localContext);
                }

                _doctoService.SincronizarTotales(movtoTrans.Empresaid, movtoTrans.Sucursalid, movtoTrans.Doctoid!.Value, localContext);

                //localContext.SaveChanges();

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


        public void Movto_delete(long empresaId, long sucursalId, long id,
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {
                var movtoInfo = localContext.Movto.AsNoTracking()
                                            .Include(m => m.Docto)
                                            .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Id == id)
                                            .Select(m => new
                                            {
                                                m.Estatusmovtoid,
                                                m.Doctoid,
                                                m.Cantidad,
                                                m.Productoid,
                                                m.Docto!.Clienteid,
                                                m.Docto!.Proveedorid,
                                                m.Docto!.Almacenid,
                                                m.Docto!.Tipodoctoid
                                            })
                                            .FirstOrDefault();

                if (movtoInfo == null)
                    throw new Exception("el movto no fue encontrado");

                if (movtoInfo.Estatusmovtoid != 0)
                    throw new Exception("un movto que no este en estado brorado no puede eliminarse");


                _inventarioService.MovtoAplicarEnProcesoSalida(empresaId, sucursalId, id, (movtoInfo.Cantidad * -1), localContext);

                localContext.SaveChanges();

                localContext.Movto_promocion
                    .Where(f => f.EmpresaId == empresaId && f.SucursalId == sucursalId && f.Movtoid == id)
                    .Delete();

                localContext.Movto_monedero
                    .Where(f => f.EmpresaId == empresaId && f.SucursalId == sucursalId && f.Movtoid == id)
                    .Delete();

                localContext.Movto_precio
                    .Where(f => f.EmpresaId == empresaId && f.SucursalId == sucursalId && f.Movtoid == id)
                    .Delete();

                localContext.SaveChanges();

                localContext.Movto_utilidad
                    .Where(f => f.EmpresaId == empresaId && f.SucursalId == sucursalId && f.Movtoid == id)
                    .Delete();

                localContext.Movto_devolucion
                    .Where(f => f.EmpresaId == empresaId && f.SucursalId == sucursalId && f.Movtoid == id)
                    .Delete();

                localContext.Movto_inventario
                    .Where(f => f.EmpresaId == empresaId && f.SucursalId == sucursalId && f.Movtoid == id)
                    .Delete();


                localContext.Movto_comodin
                    .Where(f => f.EmpresaId == empresaId && f.SucursalId == sucursalId && f.Movtoid == id)
                    .Delete();

                localContext.Movto_monedero
                    .Where(f => f.EmpresaId == empresaId && f.SucursalId == sucursalId && f.Movtoid == id)
                    .Delete();

                localContext.Movto_kit_def
                    .Where(f => f.EmpresaId == empresaId && f.SucursalId == sucursalId && f.Movtoid == id)
                    .Delete();


                localContext.Movto_kit
                    .Where(f => f.EmpresaId == empresaId && f.SucursalId == sucursalId && f.Movtoid == id)
                    .Delete();

                localContext.Movto
                    .Where(f => f.EmpresaId == empresaId && f.SucursalId == sucursalId && f.Id == id)
                    .Delete();

                localContext.SaveChanges();


                _doctoService.SincronizarTotales(empresaId, sucursalId, movtoInfo.Doctoid!.Value, localContext);


            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                localContext.ChangeTracker.LazyLoadingEnabled = previousLazyLoadingEnabledValue;
            }

        }



        public void MovtoCopy(
              long empresaId, long sucursalId, long movtoIdACopiar,
              DateTimeOffset creado, long creadoPorId,
              long doctoId, long estatusmovtoid,
              ref long? movtoId, ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {
                var movtoACopiar = localContext.Movto.AsNoTracking()
                                         .Include(m => m.Movto_precio)
                                         .Include(m => m.Movto_utilidad)
                                         .Include(m => m.Movto_devolucion)
                                         .Include(m => m.Movto_inventario)
                                         .Include(m => m.Movto_promocion)
                                         .Include(m => m.Movto_comodin)
                                         .Include(m => m.Movto_comision)
                                         .Include(m => m.Movto_monedero)
                                         .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Id == movtoIdACopiar)
                                         .FirstOrDefault();

                if (movtoACopiar == null)
                    throw new Exception("El movto no existe");



                var movtoTrans = new MovtoTransaccion()
                {

                    Empresaid = empresaId,
                    Sucursalid = sucursalId,
                    //Id = null,
                    Activo = BoolCS.S,
                    Creado = DateTimeOffset.Now,
                    Creadopor_userid = creadoPorId,
                    Partida = null,
                    Estatusmovtoid = estatusmovtoid,
                    Fecha = DateTimeOffset.UtcNow.Date,
                    Fechahora = DateTimeOffset.UtcNow,
                    Productoid = movtoACopiar.Productoid,
                    Cantidad = movtoACopiar.Cantidad,
                    Preciolista = movtoACopiar.Preciolista,
                    Descuentoporcentaje = movtoACopiar.Descuentoporcentaje,
                    Descuento = movtoACopiar.Descuento,
                    Precio = movtoACopiar.Precio,
                    Importe = movtoACopiar.Importe,
                    Subtotal = movtoACopiar.Subtotal,
                    Iva = movtoACopiar.Iva,
                    Ieps = movtoACopiar.Ieps,
                    Tasaiva = movtoACopiar.Tasaiva,
                    Tasaieps = movtoACopiar.Tasaieps,
                    Total = movtoACopiar.Total,
                    Lote = movtoACopiar.Lote,
                    Fechavence = movtoACopiar.Fechavence,
                    Loteimportado = movtoACopiar.Loteimportado,
                    Movtoparentid = movtoACopiar.Id,
                    Movtonivel = 0,
                    Afectainventario = movtoACopiar.Afectainventario,
                    Afectatotales = movtoACopiar.Afectatotales,
                    Eskit = movtoACopiar.Eskit,
                    Kitimpfijo = movtoACopiar.Kitimpfijo,
                    Doctoid = doctoId,
                    Cargo = movtoACopiar.Cargo,
                    Abono = movtoACopiar.Abono,
                    Saldo = movtoACopiar.Saldo,
                    Preciomanual = movtoACopiar.Preciomanual,
                    Preciomaximopublico =  movtoACopiar.Preciomaximopublico,
                    Isrretenido = movtoACopiar.Isrretenido,
                    Ivaretenido = movtoACopiar.Ivaretenido,
                    Orden = movtoACopiar.Orden,
                    Tasaisrretenido = movtoACopiar.Tasaisrretenido,
                    Tasaivaretenido = movtoACopiar.Tasaivaretenido,
                    Calc_imp_de_total = movtoACopiar.Movto_precio != null ? movtoACopiar.Movto_precio.Calc_imp_de_total : null,
                    Localidad = movtoACopiar.Movto_inventario != null ? movtoACopiar.Movto_inventario.Localidad : null,
                    Descripcion1 = movtoACopiar.Movto_comodin != null ? movtoACopiar.Movto_comodin.Descripcion1 : null,
                    Descripcion2 = movtoACopiar.Movto_comodin != null ? movtoACopiar.Movto_comodin.Descripcion2 : null,
                    Descripcion3 = movtoACopiar.Movto_comodin != null ? movtoACopiar.Movto_comodin.Descripcion3 : null,
                    Agrupaporparametro = BoolCN.N,
                    Cargartarjetapreciomanual = BoolCN.N,
                    Precioyavalidado = BoolCN.S,
                    Usuarioid = movtoACopiar.CreadoPorId,
                    Precioconimp = movtoACopiar.Movto_precio != null ? movtoACopiar.Movto_precio.Precioconimp : null,
                    Anaquelid = movtoACopiar.Movto_inventario != null ? movtoACopiar.Movto_inventario.Anaquelid : null,
                    Movtoadevolverid = movtoACopiar.Movto_devolucion != null ? movtoACopiar.Movto_devolucion.Movtorefid : null

                };

                long? movtoCopiaId = null;
                MovtoInsert(movtoTrans, ref movtoCopiaId, localContext);

                movtoId = movtoCopiaId;

                bool bufferIsNewRecord = false;

                if (movtoACopiar.Movto_precio != null)
                {

                    //movto_precio
                    var movto_precio = localContext.Movto_precio
                                                   .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Movtoid == movtoCopiaId)
                                                   .FirstOrDefault();

                    if (movto_precio == null)
                    {
                        movto_precio = new Movto_precio();
                        movto_precio.EmpresaId = movtoACopiar.Movto_precio.EmpresaId;
                        movto_precio.SucursalId = movtoACopiar.Movto_precio.SucursalId;
                        movto_precio.Creado = DateTimeOffset.UtcNow;
                        movto_precio.Modificado = DateTimeOffset.UtcNow;
                        movto_precio.CreadoPorId = creadoPorId;
                        movto_precio.ModificadoPorId = creadoPorId;
                        movto_precio.Movtoid = movtoCopiaId;

                        bufferIsNewRecord = true;
                    }
                    else
                        bufferIsNewRecord = false;

                    movto_precio.Razondescuentocajero = movtoACopiar.Movto_precio.Razondescuentocajero;
                    movto_precio.Preciomanualmasbajo = movtoACopiar.Movto_precio.Preciomanualmasbajo;
                    movto_precio.Ingresopreciomanual = movtoACopiar.Movto_precio.Ingresopreciomanual;
                    movto_precio.Calc_imp_de_total = movtoACopiar.Movto_precio.Calc_imp_de_total;
                    movto_precio.Descuentovale = movtoACopiar.Movto_precio.Descuentovale;
                    movto_precio.Descuentovaleporcentaje = movtoACopiar.Movto_precio.Descuentovaleporcentaje;
                    //movto_precio.Movtoid = movtoACopiar.Movto_precio.Movtoid;
                    movto_precio.Porcentajedescuentomanual = movtoACopiar.Movto_precio.Porcentajedescuentomanual;
                    movto_precio.Listaprecioid = movtoACopiar.Movto_precio.Listaprecioid;
                    movto_precio.Precioclasificacion = movtoACopiar.Movto_precio.Precioclasificacion;
                    movto_precio.Precioconimp = movtoACopiar.Movto_precio.Precioconimp;

                    if (bufferIsNewRecord)
                        localContext.Add(movto_precio);
                    else
                        localContext.Update(movto_precio);
                }





                //movto_utilidad

                if (movtoACopiar.Movto_utilidad != null)
                {
                    var movto_utilidad = localContext.Movto_utilidad
                                                   .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Movtoid == movtoCopiaId)
                                                   .FirstOrDefault();

                    if (movto_utilidad == null)
                    {
                        movto_utilidad = new Movto_utilidad();
                        movto_utilidad.EmpresaId = movtoACopiar.Movto_utilidad.EmpresaId;
                        movto_utilidad.SucursalId = movtoACopiar.Movto_utilidad.SucursalId;
                        movto_utilidad.Creado = DateTimeOffset.UtcNow;
                        movto_utilidad.Modificado = DateTimeOffset.UtcNow;
                        movto_utilidad.CreadoPorId = creadoPorId;
                        movto_utilidad.ModificadoPorId = creadoPorId;
                        movto_utilidad.Movtoid = movtoCopiaId;

                        bufferIsNewRecord = true;
                    }
                    else
                        bufferIsNewRecord = false;

                    movto_utilidad.Utilidad = movtoACopiar.Movto_utilidad.Utilidad;
                    movto_utilidad.Costoreposicion = movtoACopiar.Movto_utilidad.Costoreposicion;
                    movto_utilidad.Costopromedio = movtoACopiar.Movto_utilidad.Costopromedio;
                    movto_utilidad.Costoimporte = movtoACopiar.Movto_utilidad.Costoimporte;

                    if (bufferIsNewRecord)
                        localContext.Add(movto_utilidad);
                    else
                        localContext.Update(movto_utilidad);
                }



                //movto_devolucion

                if (movtoACopiar.Movto_devolucion != null)
                {
                    var movto_devolucion = localContext.Movto_devolucion
                                                   .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Movtoid == movtoCopiaId)
                                                   .FirstOrDefault();

                    if (movto_devolucion == null)
                    {
                        movto_devolucion = new Movto_devolucion();
                        movto_devolucion.EmpresaId = movtoACopiar.Movto_devolucion.EmpresaId;
                        movto_devolucion.SucursalId = movtoACopiar.Movto_devolucion.SucursalId;
                        movto_devolucion.Creado = DateTimeOffset.UtcNow;
                        movto_devolucion.Modificado = DateTimeOffset.UtcNow;
                        movto_devolucion.CreadoPorId = creadoPorId;
                        movto_devolucion.ModificadoPorId = creadoPorId;
                        movto_devolucion.Movtoid = movtoCopiaId;

                        bufferIsNewRecord = true;
                    }
                    else
                        bufferIsNewRecord = false;

                    movto_devolucion.Movtorefid = movtoACopiar.Movto_devolucion.Movtorefid;
                    movto_devolucion.Cantidadsurtida = movtoACopiar.Movto_devolucion.Cantidadsurtida;
                    movto_devolucion.Cantidadfaltante = movtoACopiar.Movto_devolucion.Cantidadfaltante;
                    movto_devolucion.Cantidaddevuelta = movtoACopiar.Movto_devolucion.Cantidaddevuelta;
                    movto_devolucion.Cantidadsaldo = movtoACopiar.Movto_devolucion.Cantidadsaldo;
                    movto_devolucion.Razondiferenciaid = movtoACopiar.Movto_devolucion.Razondiferenciaid;
                    movto_devolucion.Otrarazondiferencia = movtoACopiar.Movto_devolucion.Otrarazondiferencia;

                    if (bufferIsNewRecord)
                        localContext.Add(movto_devolucion);
                    else
                        localContext.Update(movto_devolucion);

                }



                //movto_inventario

                if (movtoACopiar.Movto_inventario != null)
                {
                    var movto_inventario = localContext.Movto_inventario
                                                   .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Movtoid == movtoCopiaId)
                                                   .FirstOrDefault();

                    if (movto_inventario == null)
                    {
                        movto_inventario = new Movto_inventario();
                        movto_inventario.EmpresaId = movtoACopiar.Movto_inventario.EmpresaId;
                        movto_inventario.SucursalId = movtoACopiar.Movto_inventario.SucursalId;
                        movto_inventario.Creado = DateTimeOffset.UtcNow;
                        movto_inventario.Modificado = DateTimeOffset.UtcNow;
                        movto_inventario.CreadoPorId = creadoPorId;
                        movto_inventario.ModificadoPorId = creadoPorId;
                        movto_inventario.Movtoid = movtoCopiaId;

                        bufferIsNewRecord = true;
                    }
                    else
                        bufferIsNewRecord = false;

                    movto_inventario.Localidad = movtoACopiar.Movto_inventario.Localidad;
                    movto_inventario.Registroprocesosalida = movtoACopiar.Movto_inventario.Registroprocesosalida;
                    movto_inventario.Tipodiferenciainventarioid = movtoACopiar.Movto_inventario.Tipodiferenciainventarioid;
                    movto_inventario.Anaquelid = movtoACopiar.Movto_inventario.Anaquelid;
                    movto_inventario.Cantidad_real = movtoACopiar.Movto_inventario.Cantidad_real;
                    movto_inventario.Cantidad_teorica = movtoACopiar.Movto_inventario.Cantidad_teorica;
                    movto_inventario.Cantidad_diferencia = movtoACopiar.Movto_inventario.Cantidad_diferencia;

                    if (bufferIsNewRecord)
                        localContext.Add(movto_inventario);
                    else
                        localContext.Update(movto_inventario);

                }



                //movto_promocion

                if (movtoACopiar.Movto_promocion != null)
                {
                    var movto_promocion = localContext.Movto_promocion
                                                   .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Movtoid == movtoCopiaId)
                                                   .FirstOrDefault();

                    if (movto_promocion == null)
                    {
                        movto_promocion = new Movto_promocion();
                        movto_promocion.EmpresaId = movtoACopiar.Movto_promocion.EmpresaId;
                        movto_promocion.SucursalId = movtoACopiar.Movto_promocion.SucursalId;
                        movto_promocion.Creado = DateTimeOffset.UtcNow;
                        movto_promocion.Modificado = DateTimeOffset.UtcNow;
                        movto_promocion.CreadoPorId = creadoPorId;
                        movto_promocion.ModificadoPorId = creadoPorId;
                        movto_promocion.Movtoid = movtoCopiaId;

                        bufferIsNewRecord = true;
                    }
                    else
                        bufferIsNewRecord = false;

                    movto_promocion.Promocion = movtoACopiar.Movto_promocion.Promocion;
                    movto_promocion.Promociondesglose = movtoACopiar.Movto_promocion.Promociondesglose;
                    movto_promocion.Aplicopromoxmontomin = movtoACopiar.Movto_promocion.Aplicopromoxmontomin;
                    movto_promocion.Promocionid = movtoACopiar.Movto_promocion.Promocionid;

                    if (bufferIsNewRecord)
                        localContext.Add(movto_promocion);
                    else
                        localContext.Update(movto_promocion);

                }


                //movto_comodin

                if (movtoACopiar.Movto_comodin != null)
                {
                    var movto_comodin = localContext.Movto_comodin
                                                   .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Movtoid == movtoCopiaId)
                                                   .FirstOrDefault();

                    if (movto_comodin == null)
                    {
                        movto_comodin = new Movto_comodin();
                        movto_comodin.EmpresaId = movtoACopiar.Movto_comodin.EmpresaId;
                        movto_comodin.SucursalId = movtoACopiar.Movto_comodin.SucursalId;
                        movto_comodin.Creado = DateTimeOffset.UtcNow;
                        movto_comodin.Modificado = DateTimeOffset.UtcNow;
                        movto_comodin.CreadoPorId = creadoPorId;
                        movto_comodin.ModificadoPorId = creadoPorId;
                        movto_comodin.Movtoid = movtoCopiaId;

                        bufferIsNewRecord = true;
                    }
                    else
                        bufferIsNewRecord = false;

                    movto_comodin.Descripcion1 = movtoACopiar.Movto_comodin.Descripcion1;
                    movto_comodin.Descripcion2 = movtoACopiar.Movto_comodin.Descripcion2;
                    movto_comodin.Descripcion3 = movtoACopiar.Movto_comodin.Descripcion3;
                    movto_comodin.Claveprod = movtoACopiar.Movto_comodin.Claveprod;

                    if (bufferIsNewRecord)
                        localContext.Add(movto_comodin);
                    else
                        localContext.Update(movto_comodin);

                }



                //movto_comision

                if (movtoACopiar.Movto_comision != null)
                {
                    var movto_comision = localContext.Movto_comision
                                                   .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Movtoid == movtoCopiaId)
                                                   .FirstOrDefault();

                    if (movto_comision == null)
                    {
                        movto_comision = new Movto_comision();
                        movto_comision.EmpresaId = movtoACopiar.Movto_comision.EmpresaId;
                        movto_comision.SucursalId = movtoACopiar.Movto_comision.SucursalId;
                        movto_comision.Creado = DateTimeOffset.UtcNow;
                        movto_comision.Modificado = DateTimeOffset.UtcNow;
                        movto_comision.CreadoPorId = creadoPorId;
                        movto_comision.ModificadoPorId = creadoPorId;
                        movto_comision.Movtoid = movtoCopiaId;

                        bufferIsNewRecord = true;
                    }
                    else
                        bufferIsNewRecord = false;

                    movto_comision.Comisionxunidad = movtoACopiar.Movto_comision.Comisionxunidad;
                    movto_comision.Comision = movtoACopiar.Movto_comision.Comision;
                    movto_comision.Comisionporc = movtoACopiar.Movto_comision.Comisionporc;

                    if (bufferIsNewRecord)
                        localContext.Add(movto_comision);
                    else
                        localContext.Update(movto_comision);

                }



                //movto_monedero

                if (movtoACopiar.Movto_monedero != null)
                {
                    var movto_monedero = localContext.Movto_monedero
                                                   .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Movtoid == movtoCopiaId)
                                                   .FirstOrDefault();

                    if (movto_monedero == null)
                    {
                        movto_monedero = new Movto_monedero();
                        movto_monedero.EmpresaId = movtoACopiar.Movto_monedero.EmpresaId;
                        movto_monedero.SucursalId = movtoACopiar.Movto_monedero.SucursalId;
                        movto_monedero.Creado = DateTimeOffset.UtcNow;
                        movto_monedero.Modificado = DateTimeOffset.UtcNow;
                        movto_monedero.CreadoPorId = creadoPorId;
                        movto_monedero.ModificadoPorId = creadoPorId;
                        movto_monedero.Movtoid = movtoCopiaId;

                        bufferIsNewRecord = true;
                    }
                    else
                        bufferIsNewRecord = false;

                    movto_monedero.Monederoabono = movtoACopiar.Movto_monedero.Monederoabono;

                    if (bufferIsNewRecord)
                        localContext.Add(movto_monedero);
                    else
                        localContext.Update(movto_monedero);

                }

                localContext.SaveChanges();

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

        #endregion



        public void Docto_generic_update_estatus(long empresaId, long sucursalId, long id, long estatusDoctoId,
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {

                Docto_update_status(empresaId, sucursalId, id, estatusDoctoId, localContext);

                var movtoInfo_list = localContext.Movto.AsNoTracking()
                                                    .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Doctoid == id)
                                                    .Select(m => new { m.Id })
                                                    .ToList();
                foreach (var movtoInfo in movtoInfo_list)
                {
                   _movtoService.MovtoUpdateStatus(empresaId, sucursalId, movtoInfo.Id, estatusDoctoId, localContext);
                }

                localContext.SaveChanges();


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


        public void Docto_generic_save(long empresaId, long sucursalId, long id, long estatusDoctoId,
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {
                Docto_generic_update_estatus(empresaId, sucursalId, id, estatusDoctoId, localContext);




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
}
