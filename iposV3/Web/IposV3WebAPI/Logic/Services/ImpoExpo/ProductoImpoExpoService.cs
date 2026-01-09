
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Collections;
using System.Data.Common;
using IposV3.Model;
using Microsoft.EntityFrameworkCore;
using NpgsqlTypes;
using FirebirdSql.Data.FirebirdClient;
using Controllers.Controller;
using BindingModels;
using System.Data;

namespace IposV3.Services
{



    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public class ProductoImpoExpoService : BaseImpoExpoService
    {






        public override IQueryable<List<ImpoExpoValor>>? ObtainImpoExpoValores(long empresaId, long sucursalId, ApplicationDbContext localContext)
        {
            var exportValores = localContext.Producto.AsNoTracking()
                                                 .Include(x => x.Proveedor1)
                                                 .Include(x => x.Proveedor2)
                                                 .Include(x => x.Linea)
                                                 .Include(x => x.Marca)
                                                 .Include(x => x.Unidad)
                                                 .Include(x => x.Producto_comision)
                                                 .Include(x => x.Producto_comodin)
                                                 .Include(x => x.Producto_loteimportado)
                                                 .Include(x => x.Producto_inventario)
                                                 .Include(x => x.Producto_emida).ThenInclude(y => y!.Emidaproducto)
                                                 .Include(x => x.Producto_fact_elect).ThenInclude(y => y!.Sat_productoservicio)
                                                 .Include(x => x.Producto_fact_elect).ThenInclude(y => y!.Sat_Tipoembalaje)
                                                 .Include(x => x.Producto_fact_elect).ThenInclude(y => y!.Sat_Claveunidadpeso)
                                                 .Include(x => x.Producto_fact_elect).ThenInclude(y => y!.Sat_Matpeligroso)
                                                 .Include(x => x.Producto_farmacia)
                                                 .Include(x => x.Producto_kit)
                                                 .Include(x => x.Producto_poliza).ThenInclude(y => y!.Plazo)
                                                 .Include(x => x.Producto_precios).ThenInclude(y => y!.Listaprecmediomay)
                                                 .Include(x => x.Producto_precios).ThenInclude(y => y!.Listaprecmayoreo)
                                                 .Include(x => x.Producto_promocion)
                                                 .Include(x => x.Producto_miscelanea).ThenInclude(y => y!.Clasifica)
                                                 .Include(x => x.Producto_miscelanea).ThenInclude(y => y!.Contenido)
                                                 .Include(x => x.Producto_padre).ThenInclude(y => y!.Productopadre)
                                                 .Include(x => x.Producto_utilidad)
                                                 .Include(x => x.Productocaracteristicas)
                                                 .Where(x => x.EmpresaId == empresaId && x.SucursalId == sucursalId)
                                                 .Select(x => new List<ImpoExpoValor>(){

                                                        new ImpoExpoValor("Activo", x.Activo, BoolCS.S),
                                                        new ImpoExpoValor("Clave", x.Clave, ""),
                                                        new ImpoExpoValor("Nombre", x.Nombre, ""),
                                                        new ImpoExpoValor("Descripcion", x.Descripcion, ""),
                                                        new ImpoExpoValor("Ean", x.Ean, ""),
                                                        new ImpoExpoValor("Descripcion1", x.Descripcion1, ""),
                                                        new ImpoExpoValor("Descripcion2", x.Descripcion2, ""),
                                                        new ImpoExpoValor("Descripcion3", x.Descripcion3, ""),
                                                        new ImpoExpoValor("Cbarras", x.Cbarras, ""),
                                                        new ImpoExpoValor("Cempaque", x.Cempaque, ""),
                                                        new ImpoExpoValor("Plug", x.Plug, ""),
                                                        new ImpoExpoValor("Proveedor1Clave", x.Proveedor1!.Clave, ""),
                                                        new ImpoExpoValor("Proveedor1Nombre", x.Proveedor1!.Nombre, ""),
                                                        new ImpoExpoValor("Proveedor2Clave", x.Proveedor2!.Clave, ""),
                                                        new ImpoExpoValor("Proveedor2Nombre", x.Proveedor2!.Nombre, ""),
                                                        new ImpoExpoValor("LineaClave", x.Linea!.Clave, ""),
                                                        new ImpoExpoValor("LineaNombre", x.Linea!.Nombre, ""),
                                                        new ImpoExpoValor("MarcaClave", x.Marca!.Clave, ""),
                                                        new ImpoExpoValor("MarcaNombre", x.Marca!.Nombre, ""),
                                                        new ImpoExpoValor("UnidadClave", x.Unidad!.Clave, ""),
                                                        new ImpoExpoValor("UnidadNombre", x.Unidad!.Nombre, ""),
                                                        new ImpoExpoValor("Ivaimpuesto", x.Ivaimpuesto, 0),
                                                        new ImpoExpoValor("Iepsimpuesto", x.Iepsimpuesto, 0),
                                                        new ImpoExpoValor("Producto_comision_Comision", x.Producto_comision!.Comision, 0),
                                                        new ImpoExpoValor("Producto_comodin_Descripcion_comodin", x.Producto_comodin!.Descripcion_comodin, BoolCN.N),
                                                        new ImpoExpoValor("Producto_loteimportado_Loteimportadoaplicado", x.Producto_loteimportado!.Loteimportadoaplicado, BoolCN.N),
                                                        new ImpoExpoValor("Producto_loteimportado_Manejaloteimportado", x.Producto_loteimportado.Manejaloteimportado, BoolCN.N),
                                                        new ImpoExpoValor("Producto_emida_Emidaid", x.Producto_emida!.Emidaid, 0),
                                                        new ImpoExpoValor("Producto_emida_EmidaproductoClave", x.Producto_emida.Emidaproducto!.Clave, ""),
                                                        new ImpoExpoValor("Producto_emida_EmidaproductoNombre", x.Producto_emida.Emidaproducto!.Nombre, ""),
                                                        new ImpoExpoValor("Producto_fact_elect_Sat_productoservicioClave", x.Producto_fact_elect!.Sat_productoservicio!.Clave, ""),
                                                        new ImpoExpoValor("Producto_fact_elect_Sat_productoservicioNombre", x.Producto_fact_elect.Sat_productoservicio!.Nombre, ""),
                                                        new ImpoExpoValor("Producto_fact_elect_Generacomprobtrasl", x.Producto_fact_elect.Generacomprobtrasl, BoolCN.N),
                                                        new ImpoExpoValor("Producto_fact_elect_Generacartaporte", x.Producto_fact_elect.Generacartaporte, BoolCN.N),
                                                        new ImpoExpoValor("Producto_fact_elect_Sat_TipoembalajeClave", x.Producto_fact_elect.Sat_Tipoembalaje!.Clave, ""),
                                                        new ImpoExpoValor("Producto_fact_elect_Sat_TipoembalajeNombre", x.Producto_fact_elect.Sat_Tipoembalaje!.Nombre, ""),
                                                        new ImpoExpoValor("Producto_fact_elect_Sat_ClaveunidadpesoClave", x.Producto_fact_elect.Sat_Claveunidadpeso!.Clave, ""),
                                                        new ImpoExpoValor("Producto_fact_elect_Sat_ClaveunidadpesoNombre", x.Producto_fact_elect.Sat_Claveunidadpeso!.Nombre, ""),
                                                        new ImpoExpoValor("Producto_fact_elect_Peso", x.Producto_fact_elect.Peso, 0),
                                                        new ImpoExpoValor("Producto_fact_elect_Espeligroso", x.Producto_fact_elect.Espeligroso, BoolCN.N),
                                                        new ImpoExpoValor("Producto_fact_elect_Sat_MatpeligrosoClave", x.Producto_fact_elect!.Sat_Matpeligroso!.Clave, ""),
                                                        new ImpoExpoValor("Producto_fact_elect_Sat_MatpeligrosoNombre", x.Producto_fact_elect.Sat_Matpeligroso.Nombre, ""),
                                                        new ImpoExpoValor("Producto_farmacia_Requierereceta", x.Producto_farmacia!.Requierereceta, BoolCN.N),
                                                        new ImpoExpoValor("Producto_inventario_Inventariable", x.Producto_inventario!.Inventariable, BoolCS.S),
                                                        new ImpoExpoValor("Producto_inventario_Negativos", x.Producto_inventario.Negativos, BoolCN.N),
                                                        new ImpoExpoValor("Producto_inventario_Manejastock", x.Producto_inventario.Manejastock, BoolCN.N),
                                                        new ImpoExpoValor("Producto_inventario_Surtirporcaja", x.Producto_inventario.Surtirporcaja, BoolCN.N),
                                                        new ImpoExpoValor("Producto_inventario_Manejalote", x.Producto_inventario.Manejalote, BoolCN.N),
                                                        new ImpoExpoValor("Producto_inventario_Pzacaja", x.Producto_inventario.Pzacaja, 0),
                                                        new ImpoExpoValor("Producto_kit_Eskit", x.Producto_kit!.Eskit, BoolCN.N),
                                                        new ImpoExpoValor("Producto_kit_Kittienevig", x.Producto_kit.Kittienevig, BoolCN.N),
                                                        new ImpoExpoValor("Producto_kit_Kitimpfijo", x.Producto_kit.Kitimpfijo, BoolCN.N),
                                                        new ImpoExpoValor("Producto_kit_Vigenciaprodkit", x.Producto_kit.Vigenciaprodkit != null ? x.Producto_kit.Vigenciaprodkit!.Value.LocalDateTime : null, DateTime.Now),
                                                        new ImpoExpoValor("Producto_poliza_PlazoClave", x.Producto_poliza!.Plazo!.Clave, ""),
                                                        new ImpoExpoValor("Producto_poliza_PlazoNombre", x.Producto_poliza.Plazo.Nombre, ""),
                                                        new ImpoExpoValor("Producto_precios_Mayokgs", x.Producto_precios!.Mayokgs, BoolCN.N),
                                                        new ImpoExpoValor("Producto_precios_Tipoabc", x.Producto_precios.Tipoabc, BoolCN.N),
                                                        new ImpoExpoValor("Producto_precios_Precio1", x.Producto_precios.Precio1, 0m),
                                                        new ImpoExpoValor("Producto_precios_Precio2", x.Producto_precios.Precio2, 0m),
                                                        new ImpoExpoValor("Producto_precios_Precio3", x.Producto_precios.Precio3, 0m),
                                                        new ImpoExpoValor("Producto_precios_Precio4", x.Producto_precios.Precio4, 0m),
                                                        new ImpoExpoValor("Producto_precios_Precio5", x.Producto_precios.Precio5, 0m),
                                                        new ImpoExpoValor("Producto_precios_Precio6", x.Producto_precios.Precio6, 0m),
                                                        new ImpoExpoValor("Producto_precios_Costorepo", x.Producto_precios.Costorepo, 0m),
                                                        new ImpoExpoValor("Producto_precios_Superprecio1", x.Producto_precios.Superprecio1, 0m),
                                                        new ImpoExpoValor("Producto_precios_Superprecio2", x.Producto_precios.Superprecio2, 0m),
                                                        new ImpoExpoValor("Producto_precios_Superprecio3", x.Producto_precios.Superprecio3, 0m),
                                                        new ImpoExpoValor("Producto_precios_Superprecio4", x.Producto_precios.Superprecio4, 0m),
                                                        new ImpoExpoValor("Producto_precios_Superprecio5", x.Producto_precios.Superprecio5, 0m),
                                                        new ImpoExpoValor("Producto_precios_Ini_mayo", x.Producto_precios.Ini_mayo, 0m),
                                                        new ImpoExpoValor("Producto_precios_ListaprecmediomayClave", x.Producto_precios!.Listaprecmediomay!.Clave, ""),
                                                        new ImpoExpoValor("Producto_precios_ListaprecmediomayNombre", x.Producto_precios.Listaprecmediomay.Nombre, ""),
                                                        new ImpoExpoValor("Producto_precios_ListaprecmayoreoClave", x.Producto_precios!.Listaprecmayoreo!.Clave, ""),
                                                        new ImpoExpoValor("Producto_precios_ListaprecmayoreoNombre", x.Producto_precios.Listaprecmayoreo.Nombre, ""),
                                                        new ImpoExpoValor("Producto_precios_Cantmediomay", x.Producto_precios.Cantmediomay, 0m),
                                                        new ImpoExpoValor("Producto_precios_Cantmayoreo", x.Producto_precios.Cantmayoreo, 0m),
                                                        new ImpoExpoValor("Producto_promocion_Esprodpromo", x.Producto_promocion!.Esprodpromo, BoolCN.N),
                                                        new ImpoExpoValor("Producto_promocion_BaseprodpromoClave", x.Producto_promocion.Baseprodpromo!.Clave, ""),
                                                        new ImpoExpoValor("Producto_promocion_BaseprodpromoNombre", x.Producto_promocion.Baseprodpromo.Nombre, ""),
                                                        new ImpoExpoValor("Producto_promocion_Vigenciaprodpromo", x.Producto_promocion.Vigenciaprodpromo != null ? x.Producto_promocion.Vigenciaprodpromo!.Value.LocalDateTime : null, DateTime.Now),
                                                        new ImpoExpoValor("Producto_miscelanea_ClasificaClave", x.Producto_miscelanea!.Clasifica!.Clave, ""),
                                                        new ImpoExpoValor("Producto_miscelanea_ClasificaNombre", x.Producto_miscelanea.Clasifica.Nombre, ""),
                                                        new ImpoExpoValor("Producto_miscelanea_ContenidoClave", x.Producto_miscelanea.Contenido!.Clave, ""),
                                                        new ImpoExpoValor("Producto_miscelanea_ContenidoNombre", x.Producto_miscelanea.Contenido.Nombre, ""),
                                                        new ImpoExpoValor("Producto_padre_Esproductopadre", x.Producto_padre!.Esproductopadre, BoolCN.N),
                                                        new ImpoExpoValor("Producto_padre_Essubproducto", x.Producto_padre.Essubproducto, BoolCN.N),
                                                        new ImpoExpoValor("Producto_padre_Tomarpreciopadre", x.Producto_padre.Tomarpreciopadre, BoolCN.N),
                                                        new ImpoExpoValor("Producto_padre_Tomarcomisionpadre", x.Producto_padre.Tomarcomisionpadre, BoolCN.N),
                                                        new ImpoExpoValor("Producto_padre_Tomarofertapadre", x.Producto_padre.Tomarofertapadre, BoolCN.N),
                                                        new ImpoExpoValor("Producto_padre_ProductopadreClave", x.Producto_padre.Productopadre!.Clave, ""),
                                                        new ImpoExpoValor("Producto_padre_ProductopadreNombre", x.Producto_padre.Productopadre.Nombre, ""),
                                                        new ImpoExpoValor("Producto_utilidad_Minutilidad", x.Producto_utilidad!.Minutilidad, 0m),
                                                        new ImpoExpoValor("Producto_utilidad_Porcutilprecio1", x.Producto_utilidad.Porcutilprecio1, 0m),
                                                        new ImpoExpoValor("Producto_utilidad_Porcutilprecio2", x.Producto_utilidad.Porcutilprecio2, 0m),
                                                        new ImpoExpoValor("Producto_utilidad_Porcutilprecio3", x.Producto_utilidad.Porcutilprecio3, 0m),
                                                        new ImpoExpoValor("Producto_utilidad_Porcutilprecio4", x.Producto_utilidad.Porcutilprecio4, 0m),
                                                        new ImpoExpoValor("Producto_utilidad_Porcutilprecio5", x.Producto_utilidad.Porcutilprecio5, 0m),
                                                        //new ImpoExpoValor("Productocaracteristicas_Clave", x.Productocaracteristicas.Clave, ""),
                                                        new ImpoExpoValor("Productocaracteristicas_Texto1", x.Productocaracteristicas!.Texto1, ""),
                                                        new ImpoExpoValor("Productocaracteristicas_Texto2", x.Productocaracteristicas.Texto2, ""),
                                                        new ImpoExpoValor("Productocaracteristicas_Texto3", x.Productocaracteristicas.Texto3, ""),
                                                        new ImpoExpoValor("Productocaracteristicas_Texto4", x.Productocaracteristicas.Texto4, ""),
                                                        new ImpoExpoValor("Productocaracteristicas_Texto5", x.Productocaracteristicas.Texto5, ""),
                                                        new ImpoExpoValor("Productocaracteristicas_Texto6", x.Productocaracteristicas.Texto6, ""),
                                                        new ImpoExpoValor("Productocaracteristicas_Numero1", x.Productocaracteristicas.Numero1, 0m),
                                                        new ImpoExpoValor("Productocaracteristicas_Numero2", x.Productocaracteristicas.Numero2, 0m),
                                                        new ImpoExpoValor("Productocaracteristicas_Numero3", x.Productocaracteristicas.Numero3, 0m),
                                                        new ImpoExpoValor("Productocaracteristicas_Numero4", x.Productocaracteristicas.Numero4, 0m),
                                                        new ImpoExpoValor("Productocaracteristicas_Fecha1", x.Productocaracteristicas.Fecha1 != null ? x.Productocaracteristicas.Fecha1!.Value.LocalDateTime : null, DateTime.Now),
                                                        new ImpoExpoValor("Productocaracteristicas_Fecha2", x.Productocaracteristicas.Fecha2 != null ? x.Productocaracteristicas.Fecha2!.Value.LocalDateTime : null, DateTime.Now),

                                                 });




            return exportValores;
        }

        public override List<ImpoExpoField> ObtainImpoExpoFields()
        {
            return new List<ImpoExpoField>() {

                new ImpoExpoField("Activo","activo",1,0, NpgsqlDbType.Varchar, typeof(BoolCS)),
                new ImpoExpoField("Clave","clave",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Nombre","nombre",127,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Descripcion","descr",254,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Ean","ean",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Descripcion1","descr1",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Descripcion2","descr2",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Descripcion3","descr3",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Cbarras","cbarras",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Cempaque","cempaque",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Plug","plug",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Proveedor1Clave","prv1clave",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Proveedor1Nombre","prv1nomb",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Proveedor2Clave","prv2clave",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Proveedor2Nombre","prv2nomb",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("LineaClave","lineacve",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("LineaNombre","lineanom",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("MarcaClave","marcacve",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("MarcaNombre","marcanom",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("UnidadClave","unidadcve",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("UnidadNombre","unidadnom",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Ivaimpuesto","ivaimp",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Iepsimpuesto","iepsimp",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                //new ImpoExpoField("Producto_apartado_Existenciafacturadoapartado","existfacturadoapartado",254,4, NpgsqlDbType.Numeric, typeof(decimal)),
                //new ImpoExpoField("Producto_apartado_Existenciaremisionadoapartado","existremisionadoapartado",254,4, NpgsqlDbType.Numeric, typeof(decimal)),
                //new ImpoExpoField("Producto_apartado_Existenciaindefinidoapartado","existindefinidoapartado",254,4, NpgsqlDbType.Numeric, typeof(decimal)),
                //new ImpoExpoField("Producto_apartado_Existenciaapartado","existapartado",254,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Producto_comision_Comision","comision",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Producto_comodin_Descripcion_comodin","descrcom",1,0, NpgsqlDbType.Varchar, typeof(BoolCN)),
                new ImpoExpoField("Producto_loteimportado_Loteimportadoaplicado","loteimpap",1,0, NpgsqlDbType.Varchar, typeof(BoolCN)),
                new ImpoExpoField("Producto_loteimportado_Manejaloteimportado","lotimpman",1,0, NpgsqlDbType.Varchar, typeof(BoolCN)),
                new ImpoExpoField("Producto_emida_Emidaid","emdaid",127,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Producto_emida_EmidaproductoClave","emdaclave",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Producto_emida_EmidaproductoNombre","emdanom",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Producto_fact_elect_Sat_productoservicioClave","stprodcve",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Producto_fact_elect_Sat_productoservicioNombre","stprodnom",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Producto_fact_elect_Generacomprobtrasl","gctrasl",1,0, NpgsqlDbType.Varchar, typeof(BoolCN)),
                new ImpoExpoField("Producto_fact_elect_Generacartaporte","gcartapo",1,0, NpgsqlDbType.Varchar, typeof(BoolCN)),
                new ImpoExpoField("Producto_fact_elect_Sat_TipoembalajeClave","stembacla",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Producto_fact_elect_Sat_TipoembalajeNombre","stembanom",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Producto_fact_elect_Sat_ClaveunidadpesoClave","stupcve",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Producto_fact_elect_Sat_ClaveunidadpesoNombre","stupnom",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Producto_fact_elect_Peso","peso",18,0, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Producto_fact_elect_Espeligroso","espelig",1,0, NpgsqlDbType.Varchar, typeof(BoolCN)),
                new ImpoExpoField("Producto_fact_elect_Sat_MatpeligrosoClave","mpclave",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Producto_fact_elect_Sat_MatpeligrosoNombre","mpnombre",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Producto_farmacia_Requierereceta","reqreceta",1,0, NpgsqlDbType.Varchar, typeof(BoolCN)),
                new ImpoExpoField("Producto_inventario_Inventariable","invent",1,0, NpgsqlDbType.Varchar, typeof(BoolCS)),
                new ImpoExpoField("Producto_inventario_Negativos","negativ",1,0, NpgsqlDbType.Varchar, typeof(BoolCN)),
                new ImpoExpoField("Producto_inventario_Manejastock","manejast",1,0, NpgsqlDbType.Varchar, typeof(BoolCN)),
                new ImpoExpoField("Producto_inventario_Surtirporcaja","surporcaj",1,0, NpgsqlDbType.Varchar, typeof(BoolCN)),
                new ImpoExpoField("Producto_inventario_Manejalote","manejalot",1,0, NpgsqlDbType.Varchar, typeof(BoolCN)),
                new ImpoExpoField("Producto_inventario_Pzacaja","pzacaja",18,0, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Producto_kit_Eskit","eskit",1,0, NpgsqlDbType.Varchar, typeof(BoolCN)),
                new ImpoExpoField("Producto_kit_Kittienevig","kittinvig",1,0, NpgsqlDbType.Varchar, typeof(BoolCN)),
                new ImpoExpoField("Producto_kit_Kitimpfijo","kitimpfij",1,0, NpgsqlDbType.Varchar, typeof(BoolCN)),
                new ImpoExpoField("Producto_kit_Vigenciaprodkit","vigprokit",8,0, NpgsqlDbType.Date, typeof(DateTimeOffset)),
                new ImpoExpoField("Producto_poliza_PlazoClave","pzoclave",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Producto_poliza_PlazoNombre","pzonombre",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Producto_precios_Mayokgs","mayokgs",18,0, NpgsqlDbType.Varchar, typeof(BoolCN)),
                new ImpoExpoField("Producto_precios_Tipoabc","tipoabc",18,0, NpgsqlDbType.Varchar, typeof(BoolCN)),
                new ImpoExpoField("Producto_precios_Precio1","precio1",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Producto_precios_Precio2","precio2",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Producto_precios_Precio3","precio3",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Producto_precios_Precio4","precio4",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Producto_precios_Precio5","precio5",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Producto_precios_Precio6","precio6",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Producto_precios_Costorepo","costorepo",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Producto_precios_Superprecio1","spprecio1",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Producto_precios_Superprecio2","spprecio2",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Producto_precios_Superprecio3","spprecio3",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Producto_precios_Superprecio4","spprecio4",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Producto_precios_Superprecio5","spprecio5",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Producto_precios_Ini_mayo","inimayo",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Producto_precios_ListaprecmediomayClave","lpmmcve",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Producto_precios_ListaprecmediomayNombre","lpmmnom",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Producto_precios_ListaprecmayoreoClave","lpmcve",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Producto_precios_ListaprecmayoreoNombre","lpmnom",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Producto_precios_Cantmediomay","canmedmay",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Producto_precios_Cantmayoreo","cantmayo",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Producto_promocion_Esprodpromo","esprdprom",1,0, NpgsqlDbType.Varchar, typeof(BoolCN)),
                new ImpoExpoField("Producto_promocion_BaseprodpromoClave","bppromcve",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Producto_promocion_BaseprodpromoNombre","bppromnom",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Producto_promocion_Vigenciaprodpromo","vigpromo",8,0, NpgsqlDbType.Date, typeof(DateTimeOffset)),
                new ImpoExpoField("Producto_miscelanea_ClasificaClave","clascve",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Producto_miscelanea_ClasificaNombre","clasnom",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Producto_miscelanea_ContenidoClave","cntclave",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Producto_miscelanea_ContenidoNombre","cntnombre",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Producto_padre_Esproductopadre","esprdpad",1,0, NpgsqlDbType.Varchar, typeof(BoolCN)),
                new ImpoExpoField("Producto_padre_Essubproducto","essubprod",1,0, NpgsqlDbType.Varchar, typeof(BoolCN)),
                new ImpoExpoField("Producto_padre_Tomarpreciopadre","tomprepad",1,0, NpgsqlDbType.Varchar, typeof(BoolCN)),
                new ImpoExpoField("Producto_padre_Tomarcomisionpadre","tomcompad",1,0, NpgsqlDbType.Varchar, typeof(BoolCN)),
                new ImpoExpoField("Producto_padre_Tomarofertapadre","tomofpad",1,0, NpgsqlDbType.Varchar, typeof(BoolCN)),
                new ImpoExpoField("Producto_padre_ProductopadreClave","ppclave",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Producto_padre_ProductopadreNombre","ppnom",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Producto_utilidad_Minutilidad","minutil",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Producto_utilidad_Porcutilprecio1","puprec1",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Producto_utilidad_Porcutilprecio2","puprec2",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Producto_utilidad_Porcutilprecio3","puprec3",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Producto_utilidad_Porcutilprecio4","puprec4",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Producto_utilidad_Porcutilprecio5","puprec5",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                //new ImpoExpoField("Productocaracteristicas_Clave","prodcarclave",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Productocaracteristicas_Texto1","pctexto1",64,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Productocaracteristicas_Texto2","pctexto2",64,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Productocaracteristicas_Texto3","pctexto3",64,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Productocaracteristicas_Texto4","pctexto4",64,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Productocaracteristicas_Texto5","pctexto5",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Productocaracteristicas_Texto6","pctexto6",254,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Productocaracteristicas_Numero1","pcnum1",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Productocaracteristicas_Numero2","pcnum2",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Productocaracteristicas_Numero3","pcnum3",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Productocaracteristicas_Numero4","pcnum4",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Productocaracteristicas_Fecha1","pcfec1",8,0, NpgsqlDbType.Date, typeof(DateTimeOffset)),
                new ImpoExpoField("Productocaracteristicas_Fecha2","pcfec2",8,0, NpgsqlDbType.Date, typeof(DateTimeOffset)),
            };
        }

        public override bool ImportFromReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               OleDbDataReader dataReader, List<ImpoExpoField> fields, ApplicationDbContext localContext)
        {

            var clave = dataReader["clave"] != System.DBNull.Value ? ((string)dataReader["clave"]).Trim() : "";

            var bufferStr = "";

            var itemSaved = localContext.Producto
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == clave);

            var item = itemSaved != null ? itemSaved : new Producto();
            var existItem = itemSaved != null;

	
          	item.Clave = dataReader["clave"] != System.DBNull.Value ? ((string)dataReader["clave"]).Trim() : ""; 
          	item.Nombre = dataReader["nombre"] != System.DBNull.Value ? ((string)dataReader["nombre"]).Trim() : ""; 
          	item.Descripcion = dataReader["descr"] != System.DBNull.Value ? ((string)dataReader["descr"]).Trim() : ""; 
          	item.Ean = dataReader["ean"] != System.DBNull.Value ? ((string)dataReader["ean"]).Trim() : ""; 
          	item.Descripcion1 = dataReader["descr1"] != System.DBNull.Value ? ((string)dataReader["descr1"]).Trim() : ""; 
          	item.Descripcion2 = dataReader["descr2"] != System.DBNull.Value ? ((string)dataReader["descr2"]).Trim() : ""; 
          	item.Descripcion3 = dataReader["descr3"] != System.DBNull.Value ? ((string)dataReader["descr3"]).Trim() : ""; 
          	item.Cbarras = dataReader["cbarras"] != System.DBNull.Value ? ((string)dataReader["cbarras"]).Trim() : ""; 
          	item.Cempaque = dataReader["cempaque"] != System.DBNull.Value ? ((string)dataReader["cempaque"]).Trim() : ""; 
          	item.Plug = dataReader["plug"] != System.DBNull.Value ? ((string)dataReader["plug"]).Trim() : "";
            item.Activo = dataReader["activo"] != System.DBNull.Value && ((string)dataReader["activo"]).Trim() == "N" ? BoolCS.N : BoolCS.S;
            item.Ivaimpuesto = dataReader["ivaimp"] != System.DBNull.Value ? (decimal)dataReader["ivaimp"] : 0m;
            item.Iepsimpuesto = dataReader["iepsimp"] != System.DBNull.Value ? (decimal)dataReader["iepsimp"] : 0m;


            bufferStr = dataReader["lineacve"] != System.DBNull.Value ? ((string)dataReader["lineacve"]).Trim() : "";
            var linea = bufferStr == "" ? null : localContext.Linea.AsNoTracking()
                                                                                  .FirstOrDefault(x => x.EmpresaId == empresaId &&
                                                                                                       x.SucursalId == sucursalId &&
                                                                                                       x.Clave == bufferStr);
            item.Lineaid = linea?.Id;


            bufferStr = dataReader["marcacve"] != System.DBNull.Value ? ((string)dataReader["marcacve"]).Trim() : "";
            var marca = bufferStr == "" ? null : localContext.Marca.AsNoTracking()
                                                                                  .FirstOrDefault(x => x.EmpresaId == empresaId &&
                                                                                                       x.SucursalId == sucursalId &&
                                                                                                       x.Clave == bufferStr);
            item.Marcaid = marca?.Id;

            bufferStr = dataReader["unidadcve"] != System.DBNull.Value ? ((string)dataReader["unidadcve"]).Trim() : "";
            var unidad = bufferStr == "" ? null : localContext.Linea.AsNoTracking()
                                                                                  .FirstOrDefault(x => x.EmpresaId == empresaId &&
                                                                                                       x.SucursalId == sucursalId &&
                                                                                                       x.Clave == bufferStr);
            item.Unidadid = unidad?.Id;

            bufferStr = dataReader["prv1clave"] != System.DBNull.Value ? ((string)dataReader["prv1clave"]).Trim() : "";
            var proveedor1 = bufferStr == "" ? null : localContext.Proveedor.AsNoTracking()
                                                                                  .FirstOrDefault(x => x.EmpresaId == empresaId &&
                                                                                                       x.SucursalId == sucursalId &&
                                                                                                       x.Clave == bufferStr);
            item.Proveedor1id = proveedor1?.Id;

            bufferStr = dataReader["prv2clave"] != System.DBNull.Value ? ((string)dataReader["prv2clave"]).Trim() : "";
            var proveedor2 = bufferStr == "" ? null : localContext.Proveedor.AsNoTracking()
                                                                                  .FirstOrDefault(x => x.EmpresaId == empresaId &&
                                                                                                       x.SucursalId == sucursalId &&
                                                                                                       x.Clave == bufferStr);
            item.Proveedor2id = proveedor2?.Id;


            if (item.Producto_emida == null)
                item.Producto_emida = new Producto_emida() { EmpresaId = empresaId, SucursalId = sucursalId };

            item.Producto_emida.Emidaid = dataReader["emdaid"] != System.DBNull.Value ? ((string)dataReader["emdaid"]).Trim() : "";



            bufferStr = dataReader["emdaclave"] != System.DBNull.Value ? ((string)dataReader["emdaclave"]).Trim() : "";
            var emidaproducto = bufferStr == "" ? null : localContext.Emidaproduct.AsNoTracking()
                                                                                  .FirstOrDefault(x => x.EmpresaId == empresaId &&
                                                                                                       x.SucursalId == sucursalId &&
                                                                                                       x.Clave == bufferStr);
            item.Producto_emida.Emidaproductoid = emidaproducto?.Id;



            if (item.Producto_fact_elect == null)
                item.Producto_fact_elect = new Producto_fact_elect() { EmpresaId = empresaId, SucursalId = sucursalId };


            bufferStr = dataReader["stprodcve"] != System.DBNull.Value ? ((string)dataReader["stprodcve"]).Trim() : "";
            var sat_productoservicio = bufferStr == "" ? null : localContext.Sat_productoservicio.AsNoTracking()
                                                                                  .FirstOrDefault(x => x.Sat_claveprodserv == bufferStr);
            item.Producto_fact_elect.Sat_productoservicioid = sat_productoservicio?.Id;


            bufferStr = dataReader["stembacla"] != System.DBNull.Value ? ((string)dataReader["stembacla"]).Trim() : "";
            var sat_Tipoembalaje = bufferStr == "" ? null : localContext.Sat_tipoembalaje.AsNoTracking()
                                                                                  .FirstOrDefault(x => x.Clave == bufferStr);
            item.Producto_fact_elect.Sat_Tipoembalajeid = sat_Tipoembalaje?.Id;


            bufferStr = dataReader["stupcve"] != System.DBNull.Value ? ((string)dataReader["stupcve"]).Trim() : "";
            var sat_claveunidadpeso = bufferStr == "" ? null : localContext.Sat_claveunidadpeso.AsNoTracking()
                                                                                  .FirstOrDefault(x => x.Clave == bufferStr);
            item.Producto_fact_elect.Sat_Claveunidadpesoid = sat_claveunidadpeso?.Id;


            bufferStr = dataReader["mpclave"] != System.DBNull.Value ? ((string)dataReader["mpclave"]).Trim() : "";
            var sat_matpeligroso = bufferStr == "" ? null : localContext.Sat_matpeligroso.AsNoTracking()
                                                                                  .FirstOrDefault(x => x.Clave == bufferStr);
            item.Producto_fact_elect.Sat_Matpeligrosoid = sat_matpeligroso?.Id;

            item.Producto_fact_elect.Generacomprobtrasl = dataReader["gctrasl"] != System.DBNull.Value && ((string)dataReader["gctrasl"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Producto_fact_elect.Generacartaporte = dataReader["gcartapo"] != System.DBNull.Value && ((string)dataReader["gcartapo"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Producto_fact_elect.Espeligroso = dataReader["espelig"] != System.DBNull.Value && ((string)dataReader["espelig"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Producto_fact_elect.Peso = dataReader["peso"] != System.DBNull.Value ? (decimal)dataReader["peso"] : 0m;


            if (item.Producto_poliza == null)
                item.Producto_poliza = new Producto_poliza() { EmpresaId = empresaId, SucursalId = sucursalId };


            bufferStr = dataReader["pzoclave"] != System.DBNull.Value ? ((string)dataReader["pzoclave"]).Trim() : "";
            var plazo = bufferStr == "" ? null : localContext.Plazo.AsNoTracking()
                                                                                  .FirstOrDefault(x => x.EmpresaId == empresaId &&
                                                                                                       x.SucursalId == sucursalId &&
                                                                                                       x.Clave == bufferStr);
            item.Producto_poliza.Plazoid = plazo?.Id;


            if (item.Producto_precios == null)
                item.Producto_precios = new Producto_precios() { EmpresaId = empresaId, SucursalId = sucursalId };


            bufferStr = dataReader["lpmmcve"] != System.DBNull.Value ? ((string)dataReader["lpmmcve"]).Trim() : "";
            var listaprecmediomay = bufferStr == "" ? null : localContext.Camporeferenciaprecio.AsNoTracking()
                                                                                  .FirstOrDefault(x => x.Clave == bufferStr);
            item.Producto_precios.Listaprecmediomayid = listaprecmediomay?.Id;


            bufferStr = dataReader["lpmcve"] != System.DBNull.Value ? ((string)dataReader["lpmcve"]).Trim() : "";
            var listaprecmayoreo = bufferStr == "" ? null : localContext.Camporeferenciaprecio.AsNoTracking()
                                                                                  .FirstOrDefault(x => x.Clave == bufferStr);
            item.Producto_precios.Listaprecmayoreoid = listaprecmayoreo?.Id;
            
            item.Producto_precios.Mayokgs = dataReader["mayokgs"] != System.DBNull.Value && ((string)dataReader["mayokgs"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Producto_precios.Tipoabc = dataReader["tipoabc"] != System.DBNull.Value && ((string)dataReader["tipoabc"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Producto_precios.Precio1 = dataReader["precio1"] != System.DBNull.Value ? (decimal)dataReader["precio1"] : 0m;
            item.Producto_precios.Precio2 = dataReader["precio2"] != System.DBNull.Value ? (decimal)dataReader["precio2"] : 0m;
            item.Producto_precios.Precio3 = dataReader["precio3"] != System.DBNull.Value ? (decimal)dataReader["precio3"] : 0m;
            item.Producto_precios.Precio4 = dataReader["precio4"] != System.DBNull.Value ? (decimal)dataReader["precio4"] : 0m;
            item.Producto_precios.Precio5 = dataReader["precio5"] != System.DBNull.Value ? (decimal)dataReader["precio5"] : 0m;
            item.Producto_precios.Precio6 = dataReader["precio6"] != System.DBNull.Value ? (decimal)dataReader["precio6"] : 0m;
            item.Producto_precios.Costorepo = dataReader["costorepo"] != System.DBNull.Value ? (decimal)dataReader["costorepo"] : 0m;
            item.Producto_precios.Superprecio1 = dataReader["spprecio1"] != System.DBNull.Value ? (decimal)dataReader["spprecio1"] : 0m;
            item.Producto_precios.Superprecio2 = dataReader["spprecio2"] != System.DBNull.Value ? (decimal)dataReader["spprecio2"] : 0m;
            item.Producto_precios.Superprecio3 = dataReader["spprecio3"] != System.DBNull.Value ? (decimal)dataReader["spprecio3"] : 0m;
            item.Producto_precios.Superprecio4 = dataReader["spprecio4"] != System.DBNull.Value ? (decimal)dataReader["spprecio4"] : 0m;
            item.Producto_precios.Superprecio5 = dataReader["spprecio5"] != System.DBNull.Value ? (decimal)dataReader["spprecio5"] : 0m;
            item.Producto_precios.Ini_mayo = dataReader["inimayo"] != System.DBNull.Value ? (decimal)dataReader["inimayo"] : 0m;
            item.Producto_precios.Cantmediomay = dataReader["canmedmay"] != System.DBNull.Value ? (decimal)dataReader["canmedmay"] : 0m;
            item.Producto_precios.Cantmayoreo = dataReader["cantmayo"] != System.DBNull.Value ? (decimal)dataReader["cantmayo"] : 0m;


            if (item.Producto_promocion == null)
                item.Producto_promocion = new Producto_promocion() { EmpresaId = empresaId, SucursalId = sucursalId };

            bufferStr = dataReader["bppromcve"] != System.DBNull.Value ? ((string)dataReader["bppromcve"]).Trim() : "";
            var baseprodpromo = bufferStr == "" ? null : localContext.Producto.AsNoTracking()
                                                                                  .FirstOrDefault(x => x.EmpresaId == empresaId &&
                                                                                                       x.SucursalId == sucursalId &&
                                                                                                       x.Clave == bufferStr);
            item.Producto_promocion.Baseprodpromoid = baseprodpromo?.Id;

            item.Producto_promocion.Vigenciaprodpromo = dataReader["vigpromo"] != System.DBNull.Value ? (new DateTimeOffset((DateTime)dataReader["vigpromo"])).ToUniversalTime() : null;
            item.Producto_promocion.Esprodpromo = dataReader["esprdprom"] != System.DBNull.Value && ((string)dataReader["esprdprom"]).Trim() == "S" ? BoolCN.S : BoolCN.N;


            if (item.Producto_miscelanea == null)
                item.Producto_miscelanea = new Producto_miscelanea() { EmpresaId = empresaId, SucursalId = sucursalId };


            bufferStr = dataReader["clascve"] != System.DBNull.Value ? ((string)dataReader["clascve"]).Trim() : "";
            var clasifica = bufferStr == "" ? null : localContext.Clasifica.AsNoTracking()
                                                                                  .FirstOrDefault(x => x.EmpresaId == empresaId &&
                                                                                                       x.SucursalId == sucursalId &&
                                                                                                       x.Clave == bufferStr);
            item.Producto_miscelanea.Clasificaid = clasifica?.Id;



            bufferStr = dataReader["cntclave"] != System.DBNull.Value ? ((string)dataReader["cntclave"]).Trim() : "";
            var contenido = bufferStr == "" ? null : localContext.Contenido.AsNoTracking()
                                                                                  .FirstOrDefault(x => x.EmpresaId == empresaId &&
                                                                                                       x.SucursalId == sucursalId &&
                                                                                                       x.Clave == bufferStr);
            item.Producto_miscelanea.Contenidoid = contenido?.Id;


            if (item.Producto_padre == null)
                item.Producto_padre = new Producto_padre() { EmpresaId = empresaId, SucursalId = sucursalId };


            bufferStr = dataReader["ppclave"] != System.DBNull.Value ? ((string)dataReader["ppclave"]).Trim() : "";
            var productopadre = bufferStr == "" ? null : localContext.Producto.AsNoTracking()
                                                                                  .FirstOrDefault(x => x.EmpresaId == empresaId &&
                                                                                                       x.SucursalId == sucursalId &&
                                                                                                       x.Clave == bufferStr);
            item.Producto_padre.Productopadreid = productopadre?.Id;

            item.Producto_padre.Esproductopadre = dataReader["esprdpad"] != System.DBNull.Value && ((string)dataReader["esprdpad"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Producto_padre.Essubproducto = dataReader["essubprod"] != System.DBNull.Value && ((string)dataReader["essubprod"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Producto_padre.Tomarpreciopadre = dataReader["tomprepad"] != System.DBNull.Value && ((string)dataReader["tomprepad"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Producto_padre.Tomarcomisionpadre = dataReader["tomcompad"] != System.DBNull.Value && ((string)dataReader["tomcompad"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Producto_padre.Tomarofertapadre = dataReader["tomofpad"] != System.DBNull.Value && ((string)dataReader["tomofpad"]).Trim() == "S" ? BoolCN.S : BoolCN.N;


            if (item.Producto_comodin == null)
                item.Producto_comodin = new Producto_comodin() { EmpresaId = empresaId, SucursalId = sucursalId };

            item.Producto_comodin.Descripcion_comodin = dataReader["descrcom"] != System.DBNull.Value && ((string)dataReader["descrcom"]).Trim() == "S" ? BoolCN.S : BoolCN.N;


            if (item.Producto_loteimportado == null)
                item.Producto_loteimportado = new Producto_loteimportado() { EmpresaId = empresaId, SucursalId = sucursalId };

            item.Producto_loteimportado.Loteimportadoaplicado = dataReader["loteimpap"] != System.DBNull.Value && ((string)dataReader["loteimpap"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Producto_loteimportado.Manejaloteimportado = dataReader["lotimpman"] != System.DBNull.Value && ((string)dataReader["lotimpman"]).Trim() == "S" ? BoolCN.S : BoolCN.N;


            if (item.Producto_farmacia == null)
                item.Producto_farmacia = new Producto_farmacia() { EmpresaId = empresaId, SucursalId = sucursalId };

            item.Producto_farmacia.Requierereceta = dataReader["reqreceta"] != System.DBNull.Value && ((string)dataReader["reqreceta"]).Trim() == "S" ? BoolCN.S : BoolCN.N;


            if (item.Producto_inventario == null)
                item.Producto_inventario = new Producto_inventario() { EmpresaId = empresaId, SucursalId = sucursalId };

            item.Producto_inventario.Negativos = dataReader["negativ"] != System.DBNull.Value && ((string)dataReader["negativ"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Producto_inventario.Manejastock = dataReader["manejast"] != System.DBNull.Value && ((string)dataReader["manejast"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Producto_inventario.Surtirporcaja = dataReader["surporcaj"] != System.DBNull.Value && ((string)dataReader["surporcaj"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Producto_inventario.Manejalote = dataReader["manejalot"] != System.DBNull.Value && ((string)dataReader["manejalot"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Producto_inventario.Inventariable = dataReader["invent"] != System.DBNull.Value && ((string)dataReader["invent"]).Trim() == "N" ? BoolCS.N : BoolCS.S;
            item.Producto_inventario.Pzacaja = dataReader["pzacaja"] != System.DBNull.Value ? (decimal)dataReader["pzacaja"] : 0m;


            if (item.Producto_kit == null)
                item.Producto_kit = new Producto_kit() { EmpresaId = empresaId, SucursalId = sucursalId };

            item.Producto_kit.Eskit = dataReader["eskit"] != System.DBNull.Value && ((string)dataReader["eskit"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Producto_kit.Kittienevig = dataReader["kittinvig"] != System.DBNull.Value && ((string)dataReader["kittinvig"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Producto_kit.Kitimpfijo = dataReader["kitimpfij"] != System.DBNull.Value && ((string)dataReader["kitimpfij"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Producto_kit.Vigenciaprodkit = dataReader["vigprokit"] != System.DBNull.Value ? (new DateTimeOffset((DateTime)dataReader["vigprokit"])).ToUniversalTime() : null;
            

            //item.Producto_apartado.Existenciafacturadoapartado = dataReader["existfacturadoapartado"] != System.DBNull.Value ? (decimal)dataReader["existfacturadoapartado"] : 0m;         
            //item.Producto_apartado.Existenciaremisionadoapartado = dataReader["existremisionadoapartado"] != System.DBNull.Value ? (decimal)dataReader["existremisionadoapartado"] : 0m;         
            //item.Producto_apartado.Existenciaindefinidoapartado = dataReader["existindefinidoapartado"] != System.DBNull.Value ? (decimal)dataReader["existindefinidoapartado"] : 0m;         
            //item.Producto_apartado.Existenciaapartado = dataReader["existapartado"] != System.DBNull.Value ? (decimal)dataReader["existapartado"] : 0m;         


            if (item.Producto_comision == null)
                item.Producto_comision = new Producto_comision() { EmpresaId = empresaId, SucursalId = sucursalId };

            item.Producto_comision.Comision = dataReader["comision"] != System.DBNull.Value ? (decimal)dataReader["comision"] : 0m;



            if (item.Producto_utilidad == null)
                item.Producto_utilidad = new Producto_utilidad() { EmpresaId = empresaId, SucursalId = sucursalId };

            item.Producto_utilidad.Minutilidad = dataReader["minutil"] != System.DBNull.Value ? (decimal)dataReader["minutil"] : 0m;
            item.Producto_utilidad.Porcutilprecio1 = dataReader["puprec1"] != System.DBNull.Value ? (decimal)dataReader["puprec1"] : 0m;
            item.Producto_utilidad.Porcutilprecio2 = dataReader["puprec2"] != System.DBNull.Value ? (decimal)dataReader["puprec2"] : 0m;
            item.Producto_utilidad.Porcutilprecio3 = dataReader["puprec3"] != System.DBNull.Value ? (decimal)dataReader["puprec3"] : 0m;
            item.Producto_utilidad.Porcutilprecio4 = dataReader["puprec4"] != System.DBNull.Value ? (decimal)dataReader["puprec4"] : 0m;
            item.Producto_utilidad.Porcutilprecio5 = dataReader["puprec5"] != System.DBNull.Value ? (decimal)dataReader["puprec5"] : 0m;

            if (item.Productocaracteristicas == null)
                item.Productocaracteristicas = new Productocaracteristicas() { EmpresaId = empresaId, SucursalId = sucursalId };

            //item.Productocaracteristicas.Clave = dataReader["prodcarclave"] != System.DBNull.Value ? ((string)dataReader["prodcarclave"]).Trim() : ""; 
            item.Productocaracteristicas.Texto1 = dataReader["pctexto1"] != System.DBNull.Value ? ((string)dataReader["pctexto1"]).Trim() : "";
            item.Productocaracteristicas.Texto2 = dataReader["pctexto2"] != System.DBNull.Value ? ((string)dataReader["pctexto2"]).Trim() : "";
            item.Productocaracteristicas.Texto3 = dataReader["pctexto3"] != System.DBNull.Value ? ((string)dataReader["pctexto3"]).Trim() : "";
            item.Productocaracteristicas.Texto4 = dataReader["pctexto4"] != System.DBNull.Value ? ((string)dataReader["pctexto4"]).Trim() : "";
            item.Productocaracteristicas.Texto5 = dataReader["pctexto5"] != System.DBNull.Value ? ((string)dataReader["pctexto5"]).Trim() : "";
            item.Productocaracteristicas.Texto6 = dataReader["pctexto6"] != System.DBNull.Value ? ((string)dataReader["pctexto6"]).Trim() : "";
            item.Productocaracteristicas.Numero1 = dataReader["pcnum1"] != System.DBNull.Value ? (decimal)dataReader["pcnum1"] : 0m;
            item.Productocaracteristicas.Numero2 = dataReader["pcnum2"] != System.DBNull.Value ? (decimal)dataReader["pcnum2"] : 0m;
            item.Productocaracteristicas.Numero3 = dataReader["pcnum3"] != System.DBNull.Value ? (decimal)dataReader["pcnum3"] : 0m;
            item.Productocaracteristicas.Numero4 = dataReader["pcnum4"] != System.DBNull.Value ? (decimal)dataReader["pcnum4"] : 0m;
            item.Productocaracteristicas.Fecha1 = dataReader["pcfec1"] != System.DBNull.Value ? (new DateTimeOffset((DateTime)dataReader["pcfec1"])).ToUniversalTime() : null;
            item.Productocaracteristicas.Fecha1 = dataReader["pcfec2"] != System.DBNull.Value ? (new DateTimeOffset((DateTime)dataReader["pcfec2"])).ToUniversalTime() : null;


            if (existItem)
                localContext.Producto.Update(item);
            else
                localContext.Producto.Add(item);

            localContext.SaveChanges();

            return true;
        }




        public void ImportarDeTablaFirebird(
                          long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                          string fbCadenaConexion,
                          string? nombreTabla, string? queryPersonalizada,
                           ApplicationDbContext localContext, ProductoController productoController)
        {
            /**/
            FbDataReader? dr = null;
            FbConnection? pcn = null;

            var utf8 = new UTF8Encoding();

            try
            {

                System.Collections.ArrayList parts = new ArrayList();

                String CmdTxt = @"SELECT
      PRODUCTO.CLAVE as CLAVE, 
      PRODUCTO.NOMBRE as NOMBRE, 
      PRODUCTO.DESCRIPCION as DESCRIPCION, 
      PRODUCTO.EAN as EAN, 
      PRODUCTO.DESCRIPCION1 as DESCRIPCION1,
      PRODUCTO.DESCRIPCION2 as DESCRIPCION2, 
      PRODUCTO.DESCRIPCION3 as DESCRIPCION3, 
      PRODUCTO.CBARRAS as CBARRAS, 
      PRODUCTO.CEMPAQUE as CEMPAQUE,
      PRODUCTO.PLUG as PLUG, 
      PRODUCTO.IMAGEN as IMAGEN, 
      PRODUCTO.EMIDAID as PRODUCTO_EMIDA_EMIDAID, 
      PRODUCTO.CUENTAPREDIAL as PRODUCTO_POLIZA_CUENTAPREDIAL, 
      PRODUCTOCARACTERISTICAS.TEXTO1 as PRODUCTOCARACTERISTICAS_TEXTO1, 
      PRODUCTOCARACTERISTICAS.TEXTO2 as PRODUCTOCARACTERISTICAS_TEXTO2, 
      PRODUCTOCARACTERISTICAS.TEXTO3 as PRODUCTOCARACTERISTICAS_TEXTO3,
      PRODUCTOCARACTERISTICAS.TEXTO4 as PRODUCTOCARACTERISTICAS_TEXTO4, 
      PRODUCTOCARACTERISTICAS.TEXTO5 as PRODUCTOCARACTERISTICAS_TEXTO5, 
      PRODUCTOCARACTERISTICAS.TEXTO6 as PRODUCTOCARACTERISTICAS_TEXTO6, 
      PRODUCTO.DESCRIPCION_COMODIN as PRODUCTO_COMODIN_DESCRIPCION_COMODIN,
      PRODUCTO.LOTEIMPORTADOAPLICADO as PRODUCTO_LOTEIMPORTADO_LOTEIMPORTADOAPLICADO, 
      PRODUCTO.MANEJALOTEIMPORTADO as PRODUCTO_LOTEIMPORTADO_MANEJALOTEIMPORTADO,
      PRODUCTO.ESPELIGROSO as PRODUCTO_FACT_ELECT_ESPELIGROSO, 
      PRODUCTO.REQUIERERECETA as PRODUCTO_FARMACIA_REQUIERERECETA, 
      PRODUCTO.NEGATIVOS as PRODUCTO_INVENTARIO_NEGATIVOS, 
      PRODUCTO.MANEJASTOCK as PRODUCTO_INVENTARIO_MANEJASTOCK, 
      PRODUCTO.SURTIRPORCAJA as PRODUCTO_INVENTARIO_SURTIRPORCAJA, 
      PRODUCTO.MANEJALOTE as PRODUCTO_INVENTARIO_MANEJALOTE, 
      PRODUCTO.ESKIT as PRODUCTO_KIT_ESKIT, 
      PRODUCTO.KITTIENEVIG as PRODUCTO_KIT_KITTIENEVIG, 
      PRODUCTO.KITIMPFIJO as PRODUCTO_KIT_KITIMPFIJO, 
      PRODUCTO.VALXSUC as PRODUCTO_KIT_VALXSUC, 
      PRODUCTO.MAYOKGS as PRODUCTO_PRECIOS_MAYOKGS, 
      PRODUCTO.TIPOABC as PRODUCTO_PRECIOS_TIPOABC, 
      PRODUCTO.CAMBIARPRECIO as PRODUCTO_PRECIOS_CAMBIARPRECIO, 
      PRODUCTO.PRECIOMAT as PRODUCTO_PRECIOS_PRECIOMAT, 
      PRODUCTO.ESPRODPROMO as PRODUCTO_PROMOCION_ESPRODPROMO, 
      PRODUCTO.ESPRODUCTOPADRE as PRODUCTO_PADRE_ESPRODUCTOPADRE, 
      PRODUCTO.ESSUBPRODUCTO as PRODUCTO_PADRE_ESSUBPRODUCTO, 
      PRODUCTO.TOMARPRECIOPADRE as PRODUCTO_PADRE_TOMARPRECIOPADRE, 
      PRODUCTO.TOMARCOMISIONPADRE as PRODUCTO_PADRE_TOMARCOMISIONPADRE, 
      PRODUCTO.TOMAROFERTAPADRE as PRODUCTO_PADRE_TOMAROFERTAPADRE, 
      PRODUCTO.ACTIVO as ACTIVO, 
      PRODUCTO.INVENTARIABLE as PRODUCTO_INVENTARIO_INVENTARIABLE, 
      PRODUCTO.IMPRIMIR as PRODUCTO_MISCELANEA_IMPRIMIR, 
      PRODUCTO.IMPRIMIRCOMANDA as PRODUCTO_MISCELANEA_IMPRIMIRCOMANDA, 
      PRODUCTO.CREADO as CREADO, 
      PRODUCTO.MODIFICADO as MODIFICADO, 
      PRODUCTO.tasaiva as IVAIMPUESTO,
      PRODUCTO.TASAIEPS as IEPSIMPUESTO,
      PRODUCTO.TASAIMPUESTO as IMPUESTO,
      PRODUCTO.EXISTENCIAFACTURADOAPARTADO as PRODUCTO_APARTADO_EXISTENCIAFACTURADOAPARTADO, 
      PRODUCTO.EXISTENCIAREMISIONADOAPARTADO as PRODUCTO_APARTADO_EXISTENCIAREMISIONADOAPARTADO, 
      PRODUCTO.EXISTENCIAINDEFINIDOAPARTADO as PRODUCTO_APARTADO_EXISTENCIAINDEFINIDOAPARTADO, 
      PRODUCTO.EXISTENCIAAPARTADO as PRODUCTO_APARTADO_EXISTENCIAAPARTADO, 
      PRODUCTO.COMISION as PRODUCTO_COMISION_COMISION, 
      PRODUCTO.PESO as PRODUCTO_FACT_ELECT_PESO, 
      PRODUCTO.EXISTENCIA as PRODUCTO_EXISTENCIA_EXISTENCIA, 
      PRODUCTO.ENPROCESODESALIDA as PRODUCTO_EXISTENCIA_ENPROCESODESALIDA, 
      PRODUCTO.ULTIMOCAMBIOEXISTENCIA as PRODUCTO_EXISTENCIA_ULTIMOCAMBIOEXISTENCIA,
      PRODUCTO.STOCK as PRODUCTO_INVENTARIO_STOCK, 
      PRODUCTO.STOCKMAX as PRODUCTO_INVENTARIO_STOCKMAX, 
      PRODUCTO.STOCKMINCAJA as PRODUCTO_INVENTARIO_STOCKMINCAJA, 
      PRODUCTO.STOCKMAXCAJA as PRODUCTO_INVENTARIO_STOCKMAXCAJA, 
      PRODUCTO.STOCKMINPIEZA as PRODUCTO_INVENTARIO_STOCKMINPIEZA, 
      PRODUCTO.STOCKMAXPIEZA as PRODUCTO_INVENTARIO_STOCKMAXPIEZA, 
      PRODUCTO.PZACAJA as PRODUCTO_INVENTARIO_PZACAJA, 
      PRODUCTO.U_EMPAQUE as PRODUCTO_INVENTARIO_U_EMPAQUE, 
      PRODUCTO.CANTXPIEZA as PRODUCTO_INVENTARIO_CANTXPIEZA, 
      PRODUCTO.ENPROCESOPARTESSALIDA as PRODUCTO_KIT_ENPROCESOPARTESSALIDA, 
      PRODUCTO.VIGENCIAPRODKIT as PRODUCTO_KIT_VIGENCIAPRODKIT, 
      PRODUCTO.EXISTENCIAFACTURADO as PRODUCTO_ORIGENFISCAL_EXISTENCIAFACTURADO, 
      PRODUCTO.EXISTENCIAREMISIONADO as PRODUCTO_ORIGENFISCAL_EXISTENCIAREMISIONADO, 
      PRODUCTO.EXISTENCIAINDEFINIDO as PRODUCTO_ORIGENFISCAL_EXISTENCIAINDEFINIDO, 
      0.00 as PRODUCTO_ORIGENFISCAL_EXIST_FAC_INTERCAMBIO, 
      PRODUCTO.PRECIO1 as PRODUCTO_PRECIOS_PRECIO1, 
      PRODUCTO.PRECIO2 as PRODUCTO_PRECIOS_PRECIO2, 
      PRODUCTO.PRECIO3 as PRODUCTO_PRECIOS_PRECIO3, 
      PRODUCTO.PRECIO4 as PRODUCTO_PRECIOS_PRECIO4, 
      PRODUCTO.PRECIO5 as PRODUCTO_PRECIOS_PRECIO5, 
      PRODUCTO.PRECIO6 as PRODUCTO_PRECIOS_PRECIO6, 
      PRODUCTO.COSTOULTIMO as PRODUCTO_PRECIOS_COSTOULTIMO, 
      PRODUCTO.COSTOPROMEDIO as PRODUCTO_PRECIOS_COSTOPROMEDIO, 
      PRODUCTO.costoreposicion as PRODUCTO_PRECIOS_COSTOREPO,
      PRODUCTO.sprecio1 as PRODUCTO_PRECIOS_SUPERPRECIO1,
      PRODUCTO.SPRECIO2 as PRODUCTO_PRECIOS_SUPERPRECIO2,
      PRODUCTO.SPRECIO3 as PRODUCTO_PRECIOS_SUPERPRECIO3,
      PRODUCTO.SPRECIO4 as PRODUCTO_PRECIOS_SUPERPRECIO4,
      PRODUCTO.SPRECIO5 as PRODUCTO_PRECIOS_SUPERPRECIO5,
      PRODUCTO.INI_MAYO as PRODUCTO_PRECIOS_INI_MAYO, 
      PRODUCTO.LIMITEPRECIO2 as PRODUCTO_PRECIOS_LIMITEPRECIO2, 
      PRODUCTO.CANTMEDIOMAY as PRODUCTO_PRECIOS_CANTMEDIOMAY, 
      PRODUCTO.CANTMAYOREO as PRODUCTO_PRECIOS_CANTMAYOREO, 
      PRODUCTO.DESCUENTO as PRODUCTO_PRECIOS_DESCUENTO, 
      PRODUCTO.MENUDEO as PRODUCTO_PRECIOS_MENUDEO, 
      PRODUCTO.PRECIOMAXIMOPUBLICO as PRODUCTO_PRECIOS_PRECIOMAXIMOPUBLICO, 
      PRODUCTO.COSTOENDOLAR as PRODUCTO_PRECIOS_COSTOENDOLAR, 
      PRODUCTO.PRECIOSUGERIDO as PRODUCTO_PRECIOS_PRECIOSUGERIDO, 
      PRODUCTO.FECHACAMBIOPRECIO as PRODUCTO_PRECIOS_FECHACAMBIOPRECIO, 
      PRODUCTO.OFERTA as PRODUCTO_PRECIOS_OFERTA, 
      PRODUCTO.PRECIOTOPE as PRODUCTO_PRECIOS_PRECIOTOPE, 
      PRODUCTO.DESCTOPE as PRODUCTO_PRECIOS_DESCTOPE, 
      PRODUCTO.MARGEN as PRODUCTO_PRECIOS_MARGEN, 
      PRODUCTO.DESCPES as PRODUCTO_PRECIOS_DESCPES, 
      PRODUCTO.VIGENCIAPRODPROMO as PRODUCTO_PROMOCION_VIGENCIAPRODPROMO, 
      PRODUCTO.CONTENIDOVALOR as PRODUCTO_MISCELANEA_CONTENIDOVALOR, 
      PRODUCTO.MINUTILIDAD as PRODUCTO_UTILIDAD_MINUTILIDAD, 
      PRODUCTO.PORCUTILPRECIO1 as PRODUCTO_UTILIDAD_PORCUTILPRECIO1, 
      PRODUCTO.PORCUTILPRECIO2 as PRODUCTO_UTILIDAD_PORCUTILPRECIO2, 
      PRODUCTO.PORCUTILPRECIO3 as PRODUCTO_UTILIDAD_PORCUTILPRECIO3, 
      PRODUCTO.PORCUTILPRECIO4 as PRODUCTO_UTILIDAD_PORCUTILPRECIO4, 
      PRODUCTO.PORCUTILPRECIO5 as PRODUCTO_UTILIDAD_PORCUTILPRECIO5, 
      PRODUCTOCARACTERISTICAS.NUMERO1 as PRODUCTOCARACTERISTICAS_NUMERO1, 
      PRODUCTOCARACTERISTICAS.NUMERO2 as PRODUCTOCARACTERISTICAS_NUMERO2, 
      PRODUCTOCARACTERISTICAS.NUMERO3 as PRODUCTOCARACTERISTICAS_NUMERO3, 
      PRODUCTOCARACTERISTICAS.NUMERO4 as PRODUCTOCARACTERISTICAS_NUMERO4, 
      PRODUCTOCARACTERISTICAS.FECHA1 as PRODUCTOCARACTERISTICAS_FECHA1, 
      PRODUCTOCARACTERISTICAS.FECHA2 as PRODUCTOCARACTERISTICAS_FECHA2, 
      PRODUCTO.ULTIMOORIGENFISCALVENTA as PRODUCTO_ORIGENFISCAL_ULTIMOORIGENFISCALVENTA,
     PROVEEDOR1.CLAVE  PROVEEDOR1CLAVE  ,
     PROVEEDOR2.CLAVE PROVEEDOR2CLAVE ,
     LINEA.CLAVE LINEACLAVE  ,
     MARCA.CLAVE  MARCACLAVE ,
     PRODUCTO.UNIDAD UNIDADCLAVE  ,
     PRODUCTO.substituto  SUBSTITUTOCLAVE ,
     EMIDAPRODUCTO.clave  PRODUCTO_EMIDA_EMIDAPRODUCTOCLAVE ,
     SAT_PRODUCTOSERVICIO.sat_claveprodserv PRODUCTO_FACT_ELECT_SAT_PRODUCTOSERVICIOCLAVE ,
     SAT_TIPOEMBALAJE.clave  PRODUCTO_FACT_ELECT_SAT_TIPOEMBALAJECLAVE ,
     SAT_CLAVEUNIDADPESO.CLAVE PRODUCTO_FACT_ELECT_SAT_CLAVEUNIDADPESOCLAVE ,
     SAT_MATPELIGROSO.clave  PRODUCTO_FACT_ELECT_SAT_MATPELIGROSOCLAVE  ,
     ULTIMORIGENFISCALVENTA.clave  PRODUCTO_ORIGENFISCAL_ULTIMOORIGENFISCALVENTA_CLAVE  ,
     PLAZO.clave PRODUCTO_POLIZA_PLAZOCLAVE ,
     LISTAPRECMEDIOMAY.clave PRODUCTO_PRECIOS_LISTAPRECMEDIOMAYCLAVE  ,
     LISTAPRECMAYOREO.clave PRODUCTO_PRECIOS_LISTAPRECMAYOREOCLAVE ,
     MONEDA.clave PRODUCTO_PRECIOS_MONEDACLAVE  ,
     BASEPRODPROMO.clave PRODUCTO_PROMOCION_BASEPRODPROMOCLAVE,
     CLASIFICA.clave PRODUCTO_MISCELANEA_CLASIFICACLAVE  ,
     CONTENIDO.clave PRODUCTO_MISCELANEA_CONTENIDOCLAVE  ,
     PRODUCTO_PADRE.clave PRODUCTO_PADRE_PRODUCTOPADRECLAVE
  FROM PRODUCTO
     LEFT JOIN PRODUCTOCARACTERISTICAS ON PRODUCTOCARACTERISTICAS.productoid = PRODUCTO.ID
     LEFT JOIN PERSONA PROVEEDOR1 ON PRODUCTO.proveedor1id = PROVEEDOR1.id
     LEFT JOIN PERSONA PROVEEDOR2 ON PRODUCTO.proveedor2id = PROVEEDOR2.id
     LEFT JOIN LINEA ON LINEA.ID = PRODUCTO.LINEAID
     LEFT JOIN MARCA ON MARCA.ID = PRODUCTO.marcaid
     LEFT JOIN PRODUCTO  EMIDAPRODUCTO ON EMIDAPRODUCTO.ID = PRODUCTO.emidaproductoid
     LEFT JOIN SAT_PRODUCTOSERVICIO ON SAT_PRODUCTOSERVICIO.ID = PRODUCTO.SAT_PRODUCTOSERVICIOID
     LEFT JOIN SAT_TIPOEMBALAJE ON SAT_TIPOEMBALAJE.ID = PRODUCTO.SAT_TIPOEMBALAJEID
     LEFT JOIN SAT_CLAVEUNIDADPESO ON SAT_CLAVEUNIDADPESO.ID = PRODUCTO.SAT_CLAVEUNIDADPESOID
     LEFT JOIN SAT_MATPELIGROSO ON SAT_MATPELIGROSO.ID = PRODUCTO.SAT_MATPELIGROSOID
     LEFT JOIN ORIGENFISCAL ULTIMORIGENFISCALVENTA ON  ULTIMORIGENFISCALVENTA.id = PRODUCTO.ultimoorigenfiscalventa
     LEFT JOIN PLAZO ON PLAZO.ID = PRODUCTO.plazoid
     LEFT JOIN LISTAPRECIO LISTAPRECMEDIOMAY ON LISTAPRECMEDIOMAY.ID = PRODUCTO.listaprecmediomayid
     LEFT JOIN LISTAPRECIO LISTAPRECMAYOREO ON LISTAPRECMAYOREO.ID = PRODUCTO.listaprecmayoreoid
     LEFT JOIN MONEDA ON MONEDA.ID = PRODUCTO.MONEDAID
     LEFT JOIN PRODUCTO BASEPRODPROMO  ON BASEPRODPROMO.ID = PRODUCTO.baseprodpromoid
     LEFT JOIN CLASIFICA ON CLASIFICA.ID = PRODUCTO.CLASIFICAID
     LEFT JOIN CONTENIDO ON CONTENIDO.id = PRODUCTO.CONTENIDOID
     LEFT JOIN PRODUCTO PRODUCTO_PADRE  ON PRODUCTO_PADRE.ID = PRODUCTO.productopadre";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                dr = FbSqlHelper.ExecuteReader(fbCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);


                while (dr.Read())
                {

                    ImportFromFirebirdReader(empresaId, sucursalId, usuarioId, ref doctoId, tipoDoctoId,
                                             dr, localContext, productoController);
                }
                localContext.SaveChanges();
                FbSqlHelper.CloseReader(dr, pcn!);


            }
            catch (Exception e)
            {
                if (dr != null && pcn != null)
                    FbSqlHelper.CloseReader(dr, pcn);

                Console.WriteLine(e.Message);
            }

        }

        public bool ImportFromFirebirdReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               FbDataReader dataReader, ApplicationDbContext localContext, ProductoController controller)
        {
            var clave = dataReader["CLAVE"] != System.DBNull.Value ? ((string)dataReader["CLAVE"]).Trim() : "";


            var Proveedor1Clave = dataReader["PROVEEDOR1CLAVE"] != System.DBNull.Value ? ((string)dataReader["PROVEEDOR1CLAVE"]).Trim() : "";

            var Proveedor2Clave = dataReader["PROVEEDOR2CLAVE"] != System.DBNull.Value ? ((string)dataReader["PROVEEDOR2CLAVE"]).Trim() : "";

            var LineaClave = dataReader["LINEACLAVE"] != System.DBNull.Value ? ((string)dataReader["LINEACLAVE"]).Trim() : "";

            var MarcaClave = dataReader["MARCACLAVE"] != System.DBNull.Value ? ((string)dataReader["MARCACLAVE"]).Trim() : "";

            var UnidadClave = dataReader["UNIDADCLAVE"] != System.DBNull.Value ? ((string)dataReader["UNIDADCLAVE"]).Trim() : "";

            var SubstitutoClave = dataReader["SUBSTITUTOCLAVE"] != System.DBNull.Value ? ((string)dataReader["SUBSTITUTOCLAVE"]).Trim() : "";

            var Producto_emida_EmidaproductoClave = dataReader["PRODUCTO_EMIDA_EMIDAPRODUCTOCLAVE"] != System.DBNull.Value ? ((string)dataReader["PRODUCTO_EMIDA_EMIDAPRODUCTOCLAVE"]).Trim() : "";

            var Producto_fact_elect_Sat_productoservicioClave = dataReader["PRODUCTO_FACT_ELECT_SAT_PRODUCTOSERVICIOCLAVE"] != System.DBNull.Value ? ((string)dataReader["PRODUCTO_FACT_ELECT_SAT_PRODUCTOSERVICIOCLAVE"]).Trim() : "";

            var Producto_fact_elect_Sat_TipoembalajeClave = dataReader["PRODUCTO_FACT_ELECT_SAT_TIPOEMBALAJECLAVE"] != System.DBNull.Value ? ((string)dataReader["PRODUCTO_FACT_ELECT_SAT_TIPOEMBALAJECLAVE"]).Trim() : "";

            var Producto_fact_elect_Sat_ClaveunidadpesoClave = dataReader["PRODUCTO_FACT_ELECT_SAT_CLAVEUNIDADPESOCLAVE"] != System.DBNull.Value ? ((string)dataReader["PRODUCTO_FACT_ELECT_SAT_CLAVEUNIDADPESOCLAVE"]).Trim() : "";

            var Producto_fact_elect_Sat_MatpeligrosoClave = dataReader["PRODUCTO_FACT_ELECT_SAT_MATPELIGROSOCLAVE"] != System.DBNull.Value ? ((string)dataReader["PRODUCTO_FACT_ELECT_SAT_MATPELIGROSOCLAVE"]).Trim() : "";

            var Producto_origenfiscal_Ultimoorigenfiscalventa_Clave = dataReader["PRODUCTO_ORIGENFISCAL_ULTIMOORIGENFISCALVENTA_CLAVE"] != System.DBNull.Value ? ((string)dataReader["PRODUCTO_ORIGENFISCAL_ULTIMOORIGENFISCALVENTA_CLAVE"]).Trim() : "";

            var Producto_poliza_PlazoClave = dataReader["PRODUCTO_POLIZA_PLAZOCLAVE"] != System.DBNull.Value ? ((string)dataReader["PRODUCTO_POLIZA_PLAZOCLAVE"]).Trim() : "";

            var Producto_precios_ListaprecmediomayClave = dataReader["PRODUCTO_PRECIOS_LISTAPRECMEDIOMAYCLAVE"] != System.DBNull.Value ? ((string)dataReader["PRODUCTO_PRECIOS_LISTAPRECMEDIOMAYCLAVE"]).Trim() : "";

            var Producto_precios_ListaprecmayoreoClave = dataReader["PRODUCTO_PRECIOS_LISTAPRECMAYOREOCLAVE"] != System.DBNull.Value ? ((string)dataReader["PRODUCTO_PRECIOS_LISTAPRECMAYOREOCLAVE"]).Trim() : "";

            var Producto_precios_MonedaClave = dataReader["PRODUCTO_PRECIOS_MONEDACLAVE"] != System.DBNull.Value ? ((string)dataReader["PRODUCTO_PRECIOS_MONEDACLAVE"]).Trim() : "";

            var Producto_promocion_BaseprodpromoClave = dataReader["PRODUCTO_PROMOCION_BASEPRODPROMOCLAVE"] != System.DBNull.Value ? ((string)dataReader["PRODUCTO_PROMOCION_BASEPRODPROMOCLAVE"]).Trim() : "";

            var Producto_miscelanea_ClasificaClave = dataReader["PRODUCTO_MISCELANEA_CLASIFICACLAVE"] != System.DBNull.Value ? ((string)dataReader["PRODUCTO_MISCELANEA_CLASIFICACLAVE"]).Trim() : "";

            var Producto_miscelanea_ContenidoClave = dataReader["PRODUCTO_MISCELANEA_CONTENIDOCLAVE"] != System.DBNull.Value ? ((string)dataReader["PRODUCTO_MISCELANEA_CONTENIDOCLAVE"]).Trim() : "";

            var Producto_padre_ProductopadreClave = dataReader["PRODUCTO_PADRE_PRODUCTOPADRECLAVE"] != System.DBNull.Value ? ((string)dataReader["PRODUCTO_PADRE_PRODUCTOPADRECLAVE"]).Trim() : "";


            var itemSaved = localContext.Producto.AsNoTracking()
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == clave);


            var Proveedor1Clave_obj = localContext.Proveedor.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == Proveedor1Clave);

            var Proveedor2Clave_obj = localContext.Proveedor.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == Proveedor2Clave);

            var LineaClave_obj = localContext.Linea.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == LineaClave);

            var MarcaClave_obj = localContext.Marca.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == MarcaClave);

            var UnidadClave_obj = localContext.Unidad.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == UnidadClave);

            var SubstitutoClave_obj = localContext.Producto.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == SubstitutoClave);

            var Producto_emida_EmidaproductoClave_obj = localContext.Emidaproduct.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Shortdescription == Producto_emida_EmidaproductoClave);

            var Producto_fact_elect_Sat_productoservicioClave_obj = localContext.Sat_productoservicio.AsNoTracking()
                                            .FirstOrDefault(i => i.Sat_claveprodserv == Producto_fact_elect_Sat_productoservicioClave);

            var Producto_fact_elect_Sat_TipoembalajeClave_obj = localContext.Sat_tipoembalaje.AsNoTracking()
                                            .FirstOrDefault(i =>  i.Clave == Producto_fact_elect_Sat_TipoembalajeClave);

            var Producto_fact_elect_Sat_ClaveunidadpesoClave_obj = localContext.Sat_claveunidadpeso.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave == Producto_fact_elect_Sat_ClaveunidadpesoClave);

            var Producto_fact_elect_Sat_MatpeligrosoClave_obj = localContext.Sat_matpeligroso.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave == Producto_fact_elect_Sat_MatpeligrosoClave);

            var Producto_origenfiscal_Ultimoorigenfiscalventa_Clave_obj = localContext.Origenfiscal.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave == Producto_origenfiscal_Ultimoorigenfiscalventa_Clave);

            var Producto_poliza_PlazoClave_obj = localContext.Plazo.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == Producto_poliza_PlazoClave);

            var Producto_precios_ListaprecmediomayClave_obj = localContext.Camporeferenciaprecio.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave == Producto_precios_ListaprecmediomayClave);

            var Producto_precios_ListaprecmayoreoClave_obj = localContext.Camporeferenciaprecio.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave == Producto_precios_ListaprecmayoreoClave);

            var Producto_precios_MonedaClave_obj = localContext.Moneda.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave == Producto_precios_MonedaClave);

            var Producto_promocion_BaseprodpromoClave_obj = localContext.Producto.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == Producto_promocion_BaseprodpromoClave);

            var Producto_miscelanea_ClasificaClave_obj = localContext.Clasifica.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == Producto_miscelanea_ClasificaClave);

            var Producto_miscelanea_ContenidoClave_obj = localContext.Contenido.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == Producto_miscelanea_ContenidoClave);

            var Producto_padre_ProductopadreClave_obj = localContext.Producto.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == Producto_padre_ProductopadreClave);


            var item = itemSaved != null ? new ProductoBindingModel(itemSaved) : new ProductoBindingModel();
            var existItem = itemSaved != null;

            item.EmpresaId = empresaId;
            item.SucursalId = sucursalId;

            item.Clave = dataReader["CLAVE"] != System.DBNull.Value ? ((string)dataReader["CLAVE"]).Trim() : "";
            item.Nombre = dataReader["NOMBRE"] != System.DBNull.Value ? ((string)dataReader["NOMBRE"]).Trim() : "";
            item.Descripcion = dataReader["DESCRIPCION"] != System.DBNull.Value ? ((string)dataReader["DESCRIPCION"]).Trim() : "";
            item.Ean = dataReader["EAN"] != System.DBNull.Value ? ((string)dataReader["EAN"]).Trim() : "";
            item.Descripcion1 = dataReader["DESCRIPCION1"] != System.DBNull.Value ? ((string)dataReader["DESCRIPCION1"]).Trim() : "";
            item.Descripcion2 = dataReader["DESCRIPCION2"] != System.DBNull.Value ? ((string)dataReader["DESCRIPCION2"]).Trim() : "";
            item.Descripcion3 = dataReader["DESCRIPCION3"] != System.DBNull.Value ? ((string)dataReader["DESCRIPCION3"]).Trim() : "";
            item.Cbarras = dataReader["CBARRAS"] != System.DBNull.Value ? ((string)dataReader["CBARRAS"]).Trim() : "";
            item.Cempaque = dataReader["CEMPAQUE"] != System.DBNull.Value ? ((string)dataReader["CEMPAQUE"]).Trim() : "";
            item.Plug = dataReader["PLUG"] != System.DBNull.Value ? ((string)dataReader["PLUG"]).Trim() : "";
            item.Imagen = dataReader["IMAGEN"] != System.DBNull.Value ? ((string)dataReader["IMAGEN"]).Trim() : "";
            item.Producto_emida_Emidaid = dataReader["PRODUCTO_EMIDA_EMIDAID"] != System.DBNull.Value ? ((string)dataReader["PRODUCTO_EMIDA_EMIDAID"]).Trim() : "";
            item.Producto_poliza_Cuentapredial = dataReader["PRODUCTO_POLIZA_CUENTAPREDIAL"] != System.DBNull.Value ? ((string)dataReader["PRODUCTO_POLIZA_CUENTAPREDIAL"]).Trim() : "";
            item.Productocaracteristicas_Texto1 = dataReader["PRODUCTOCARACTERISTICAS_TEXTO1"] != System.DBNull.Value ? ((string)dataReader["PRODUCTOCARACTERISTICAS_TEXTO1"]).Trim() : "";
            item.Productocaracteristicas_Texto2 = dataReader["PRODUCTOCARACTERISTICAS_TEXTO2"] != System.DBNull.Value ? ((string)dataReader["PRODUCTOCARACTERISTICAS_TEXTO2"]).Trim() : "";
            item.Productocaracteristicas_Texto3 = dataReader["PRODUCTOCARACTERISTICAS_TEXTO3"] != System.DBNull.Value ? ((string)dataReader["PRODUCTOCARACTERISTICAS_TEXTO3"]).Trim() : "";
            item.Productocaracteristicas_Texto4 = dataReader["PRODUCTOCARACTERISTICAS_TEXTO4"] != System.DBNull.Value ? ((string)dataReader["PRODUCTOCARACTERISTICAS_TEXTO4"]).Trim() : "";
            item.Productocaracteristicas_Texto5 = dataReader["PRODUCTOCARACTERISTICAS_TEXTO5"] != System.DBNull.Value ? ((string)dataReader["PRODUCTOCARACTERISTICAS_TEXTO5"]).Trim() : "";
            item.Productocaracteristicas_Texto6 = dataReader["PRODUCTOCARACTERISTICAS_TEXTO6"] != System.DBNull.Value ? ((string)dataReader["PRODUCTOCARACTERISTICAS_TEXTO6"]).Trim() : "";
            item.Producto_comodin_Descripcion_comodin = dataReader["PRODUCTO_COMODIN_DESCRIPCION_COMODIN"] != System.DBNull.Value && ((string)dataReader["PRODUCTO_COMODIN_DESCRIPCION_COMODIN"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Producto_loteimportado_Loteimportadoaplicado = dataReader["PRODUCTO_LOTEIMPORTADO_LOTEIMPORTADOAPLICADO"] != System.DBNull.Value && ((string)dataReader["PRODUCTO_LOTEIMPORTADO_LOTEIMPORTADOAPLICADO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Producto_loteimportado_Manejaloteimportado = dataReader["PRODUCTO_LOTEIMPORTADO_MANEJALOTEIMPORTADO"] != System.DBNull.Value && ((string)dataReader["PRODUCTO_LOTEIMPORTADO_MANEJALOTEIMPORTADO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            //item.Producto_fact_elect_Generacomprobtrasl = dataReader["PRODUCTO_FACT_ELECT_GENERACOMPROBTRASL"] != System.DBNull.Value && ((string)dataReader["PRODUCTO_FACT_ELECT_GENERACOMPROBTRASL"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            //item.Producto_fact_elect_Generacartaporte = dataReader["PRODUCTO_FACT_ELECT_GENERACARTAPORTE"] != System.DBNull.Value && ((string)dataReader["PRODUCTO_FACT_ELECT_GENERACARTAPORTE"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Producto_fact_elect_Espeligroso = dataReader["PRODUCTO_FACT_ELECT_ESPELIGROSO"] != System.DBNull.Value && ((string)dataReader["PRODUCTO_FACT_ELECT_ESPELIGROSO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Producto_farmacia_Requierereceta = dataReader["PRODUCTO_FARMACIA_REQUIERERECETA"] != System.DBNull.Value && ((string)dataReader["PRODUCTO_FARMACIA_REQUIERERECETA"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Producto_inventario_Negativos = dataReader["PRODUCTO_INVENTARIO_NEGATIVOS"] != System.DBNull.Value && ((string)dataReader["PRODUCTO_INVENTARIO_NEGATIVOS"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Producto_inventario_Manejastock = dataReader["PRODUCTO_INVENTARIO_MANEJASTOCK"] != System.DBNull.Value && ((string)dataReader["PRODUCTO_INVENTARIO_MANEJASTOCK"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Producto_inventario_Surtirporcaja = dataReader["PRODUCTO_INVENTARIO_SURTIRPORCAJA"] != System.DBNull.Value && ((string)dataReader["PRODUCTO_INVENTARIO_SURTIRPORCAJA"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Producto_inventario_Manejalote = dataReader["PRODUCTO_INVENTARIO_MANEJALOTE"] != System.DBNull.Value && ((string)dataReader["PRODUCTO_INVENTARIO_MANEJALOTE"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Producto_kit_Eskit = dataReader["PRODUCTO_KIT_ESKIT"] != System.DBNull.Value && ((string)dataReader["PRODUCTO_KIT_ESKIT"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Producto_kit_Kittienevig = dataReader["PRODUCTO_KIT_KITTIENEVIG"] != System.DBNull.Value && ((string)dataReader["PRODUCTO_KIT_KITTIENEVIG"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Producto_kit_Kitimpfijo = dataReader["PRODUCTO_KIT_KITIMPFIJO"] != System.DBNull.Value && ((string)dataReader["PRODUCTO_KIT_KITIMPFIJO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Producto_kit_Valxsuc = dataReader["PRODUCTO_KIT_VALXSUC"] != System.DBNull.Value && ((string)dataReader["PRODUCTO_KIT_VALXSUC"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Producto_precios_Mayokgs = dataReader["PRODUCTO_PRECIOS_MAYOKGS"] != System.DBNull.Value && ((string)dataReader["PRODUCTO_PRECIOS_MAYOKGS"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Producto_precios_Tipoabc = dataReader["PRODUCTO_PRECIOS_TIPOABC"] != System.DBNull.Value && ((string)dataReader["PRODUCTO_PRECIOS_TIPOABC"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Producto_precios_Cambiarprecio = dataReader["PRODUCTO_PRECIOS_CAMBIARPRECIO"] != System.DBNull.Value && ((string)dataReader["PRODUCTO_PRECIOS_CAMBIARPRECIO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Producto_precios_Preciomat = dataReader["PRODUCTO_PRECIOS_PRECIOMAT"] != System.DBNull.Value && ((string)dataReader["PRODUCTO_PRECIOS_PRECIOMAT"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Producto_promocion_Esprodpromo = dataReader["PRODUCTO_PROMOCION_ESPRODPROMO"] != System.DBNull.Value && ((string)dataReader["PRODUCTO_PROMOCION_ESPRODPROMO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Producto_padre_Esproductopadre = dataReader["PRODUCTO_PADRE_ESPRODUCTOPADRE"] != System.DBNull.Value && ((string)dataReader["PRODUCTO_PADRE_ESPRODUCTOPADRE"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Producto_padre_Essubproducto = dataReader["PRODUCTO_PADRE_ESSUBPRODUCTO"] != System.DBNull.Value && ((string)dataReader["PRODUCTO_PADRE_ESSUBPRODUCTO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Producto_padre_Tomarpreciopadre = dataReader["PRODUCTO_PADRE_TOMARPRECIOPADRE"] != System.DBNull.Value && ((string)dataReader["PRODUCTO_PADRE_TOMARPRECIOPADRE"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Producto_padre_Tomarcomisionpadre = dataReader["PRODUCTO_PADRE_TOMARCOMISIONPADRE"] != System.DBNull.Value && ((string)dataReader["PRODUCTO_PADRE_TOMARCOMISIONPADRE"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Producto_padre_Tomarofertapadre = dataReader["PRODUCTO_PADRE_TOMAROFERTAPADRE"] != System.DBNull.Value && ((string)dataReader["PRODUCTO_PADRE_TOMAROFERTAPADRE"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Activo = dataReader["ACTIVO"] != System.DBNull.Value && ((string)dataReader["ACTIVO"]).Trim() == "N" ? BoolCS.N : BoolCS.S;
            item.Producto_inventario_Inventariable = dataReader["PRODUCTO_INVENTARIO_INVENTARIABLE"] != System.DBNull.Value && ((string)dataReader["PRODUCTO_INVENTARIO_INVENTARIABLE"]).Trim() == "N" ? BoolCS.N : BoolCS.S;
            item.Producto_miscelanea_Imprimir = dataReader["PRODUCTO_MISCELANEA_IMPRIMIR"] != System.DBNull.Value && ((string)dataReader["PRODUCTO_MISCELANEA_IMPRIMIR"]).Trim() == "N" ? BoolCS.N : BoolCS.S;
            item.Producto_miscelanea_Imprimircomanda = dataReader["PRODUCTO_MISCELANEA_IMPRIMIRCOMANDA"] != System.DBNull.Value && ((string)dataReader["PRODUCTO_MISCELANEA_IMPRIMIRCOMANDA"]).Trim() == "N" ? BoolCS.N : BoolCS.S;
            item.Creado = dataReader["CREADO"] != System.DBNull.Value ? new DateTimeOffset(((DateTime)dataReader["CREADO"]))  : DateTime.UtcNow;
            item.Modificado = dataReader["MODIFICADO"] != System.DBNull.Value ? new DateTimeOffset(((DateTime)dataReader["MODIFICADO"]))  : DateTime.UtcNow;
            item.Ivaimpuesto = dataReader["IVAIMPUESTO"] != System.DBNull.Value ? (decimal)dataReader["IVAIMPUESTO"] : 0;
            item.Iepsimpuesto = dataReader["IEPSIMPUESTO"] != System.DBNull.Value ? (decimal)dataReader["IEPSIMPUESTO"] : 0;
            item.Impuesto = dataReader["IMPUESTO"] != System.DBNull.Value ? (decimal)dataReader["IMPUESTO"] : 0;
            item.Producto_apartado_Existenciafacturadoapartado = dataReader["PRODUCTO_APARTADO_EXISTENCIAFACTURADOAPARTADO"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_APARTADO_EXISTENCIAFACTURADOAPARTADO"] : 0;
            item.Producto_apartado_Existenciaremisionadoapartado = dataReader["PRODUCTO_APARTADO_EXISTENCIAREMISIONADOAPARTADO"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_APARTADO_EXISTENCIAREMISIONADOAPARTADO"] : 0;
            item.Producto_apartado_Existenciaindefinidoapartado = dataReader["PRODUCTO_APARTADO_EXISTENCIAINDEFINIDOAPARTADO"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_APARTADO_EXISTENCIAINDEFINIDOAPARTADO"] : 0;
            item.Producto_apartado_Existenciaapartado = dataReader["PRODUCTO_APARTADO_EXISTENCIAAPARTADO"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_APARTADO_EXISTENCIAAPARTADO"] : 0;
            item.Producto_comision_Comision = dataReader["PRODUCTO_COMISION_COMISION"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_COMISION_COMISION"] : 0;
            item.Producto_fact_elect_Peso = dataReader["PRODUCTO_FACT_ELECT_PESO"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_FACT_ELECT_PESO"] : 0;
            item.Producto_existencia_Existencia = dataReader["PRODUCTO_EXISTENCIA_EXISTENCIA"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_EXISTENCIA_EXISTENCIA"] : 0;
            item.Producto_existencia_Enprocesodesalida = dataReader["PRODUCTO_EXISTENCIA_ENPROCESODESALIDA"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_EXISTENCIA_ENPROCESODESALIDA"] : 0;
            item.Producto_existencia_Ultimocambioexistencia = dataReader["PRODUCTO_EXISTENCIA_ULTIMOCAMBIOEXISTENCIA"] != System.DBNull.Value ?  new DateTimeOffset(((DateTime)dataReader["PRODUCTO_EXISTENCIA_ULTIMOCAMBIOEXISTENCIA"]))  : null;
            item.Producto_inventario_Stock = dataReader["PRODUCTO_INVENTARIO_STOCK"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_INVENTARIO_STOCK"] : 0;
            item.Producto_inventario_Stockmax = dataReader["PRODUCTO_INVENTARIO_STOCKMAX"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_INVENTARIO_STOCKMAX"] : 0;
            item.Producto_inventario_Stockmincaja = dataReader["PRODUCTO_INVENTARIO_STOCKMINCAJA"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_INVENTARIO_STOCKMINCAJA"] : 0;
            item.Producto_inventario_Stockmaxcaja = dataReader["PRODUCTO_INVENTARIO_STOCKMAXCAJA"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_INVENTARIO_STOCKMAXCAJA"] : 0;
            item.Producto_inventario_Stockminpieza = dataReader["PRODUCTO_INVENTARIO_STOCKMINPIEZA"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_INVENTARIO_STOCKMINPIEZA"] : 0;
            item.Producto_inventario_Stockmaxpieza = dataReader["PRODUCTO_INVENTARIO_STOCKMAXPIEZA"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_INVENTARIO_STOCKMAXPIEZA"] : 0;
            item.Producto_inventario_Pzacaja = dataReader["PRODUCTO_INVENTARIO_PZACAJA"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_INVENTARIO_PZACAJA"] : 0;
            item.Producto_inventario_U_empaque = dataReader["PRODUCTO_INVENTARIO_U_EMPAQUE"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_INVENTARIO_U_EMPAQUE"] : 0;
            item.Producto_inventario_Cantxpieza = dataReader["PRODUCTO_INVENTARIO_CANTXPIEZA"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_INVENTARIO_CANTXPIEZA"] : 0;
            item.Producto_kit_Enprocesopartessalida = dataReader["PRODUCTO_KIT_ENPROCESOPARTESSALIDA"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_KIT_ENPROCESOPARTESSALIDA"] : 0;
            item.Producto_kit_Vigenciaprodkit = dataReader["PRODUCTO_KIT_VIGENCIAPRODKIT"] != System.DBNull.Value ? new DateTimeOffset(((DateTime)dataReader["PRODUCTO_KIT_VIGENCIAPRODKIT"]))  : null;
            item.Producto_origenfiscal_Existenciafacturado = dataReader["PRODUCTO_ORIGENFISCAL_EXISTENCIAFACTURADO"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_ORIGENFISCAL_EXISTENCIAFACTURADO"] : 0;
            item.Producto_origenfiscal_Existenciaremisionado = dataReader["PRODUCTO_ORIGENFISCAL_EXISTENCIAREMISIONADO"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_ORIGENFISCAL_EXISTENCIAREMISIONADO"] : 0;
            item.Producto_origenfiscal_Existenciaindefinido = dataReader["PRODUCTO_ORIGENFISCAL_EXISTENCIAINDEFINIDO"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_ORIGENFISCAL_EXISTENCIAINDEFINIDO"] : 0;
            item.Producto_origenfiscal_Exist_fac_intercambio = dataReader["PRODUCTO_ORIGENFISCAL_EXIST_FAC_INTERCAMBIO"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_ORIGENFISCAL_EXIST_FAC_INTERCAMBIO"] : 0;
            item.Producto_precios_Precio1 = dataReader["PRODUCTO_PRECIOS_PRECIO1"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_PRECIOS_PRECIO1"] : 0;
            item.Producto_precios_Precio2 = dataReader["PRODUCTO_PRECIOS_PRECIO2"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_PRECIOS_PRECIO2"] : 0;
            item.Producto_precios_Precio3 = dataReader["PRODUCTO_PRECIOS_PRECIO3"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_PRECIOS_PRECIO3"] : 0;
            item.Producto_precios_Precio4 = dataReader["PRODUCTO_PRECIOS_PRECIO4"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_PRECIOS_PRECIO4"] : 0;
            item.Producto_precios_Precio5 = dataReader["PRODUCTO_PRECIOS_PRECIO5"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_PRECIOS_PRECIO5"] : 0;
            item.Producto_precios_Precio6 = dataReader["PRODUCTO_PRECIOS_PRECIO6"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_PRECIOS_PRECIO6"] : 0;
            item.Producto_precios_Costoultimo = dataReader["PRODUCTO_PRECIOS_COSTOULTIMO"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_PRECIOS_COSTOULTIMO"] : 0;
            item.Producto_precios_Costopromedio = dataReader["PRODUCTO_PRECIOS_COSTOPROMEDIO"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_PRECIOS_COSTOPROMEDIO"] : 0;
            item.Producto_precios_Costorepo = dataReader["PRODUCTO_PRECIOS_COSTOREPO"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_PRECIOS_COSTOREPO"] : 0;
            item.Producto_precios_Superprecio1 = dataReader["PRODUCTO_PRECIOS_SUPERPRECIO1"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_PRECIOS_SUPERPRECIO1"] : 0m;
            item.Producto_precios_Superprecio2 = dataReader["PRODUCTO_PRECIOS_SUPERPRECIO2"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_PRECIOS_SUPERPRECIO2"] : 0m;
            item.Producto_precios_Superprecio3 = dataReader["PRODUCTO_PRECIOS_SUPERPRECIO3"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_PRECIOS_SUPERPRECIO3"] : 0m;
            item.Producto_precios_Superprecio4 = dataReader["PRODUCTO_PRECIOS_SUPERPRECIO4"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_PRECIOS_SUPERPRECIO4"] : 0m;
            item.Producto_precios_Superprecio5 = dataReader["PRODUCTO_PRECIOS_SUPERPRECIO5"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_PRECIOS_SUPERPRECIO5"] : 0m;
            item.Producto_precios_Ini_mayo = dataReader["PRODUCTO_PRECIOS_INI_MAYO"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_PRECIOS_INI_MAYO"] : 0m;
            item.Producto_precios_Limiteprecio2 = dataReader["PRODUCTO_PRECIOS_LIMITEPRECIO2"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_PRECIOS_LIMITEPRECIO2"] : 0m;
            item.Producto_precios_Cantmediomay = dataReader["PRODUCTO_PRECIOS_CANTMEDIOMAY"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_PRECIOS_CANTMEDIOMAY"] : 0;
            item.Producto_precios_Cantmayoreo = dataReader["PRODUCTO_PRECIOS_CANTMAYOREO"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_PRECIOS_CANTMAYOREO"] : 0;
            item.Producto_precios_Descuento = dataReader["PRODUCTO_PRECIOS_DESCUENTO"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_PRECIOS_DESCUENTO"] : 0;
            item.Producto_precios_Menudeo = dataReader["PRODUCTO_PRECIOS_MENUDEO"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_PRECIOS_MENUDEO"] : 0;
            item.Producto_precios_Preciomaximopublico = dataReader["PRODUCTO_PRECIOS_PRECIOMAXIMOPUBLICO"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_PRECIOS_PRECIOMAXIMOPUBLICO"] : 0;
            item.Producto_precios_Costoendolar = dataReader["PRODUCTO_PRECIOS_COSTOENDOLAR"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_PRECIOS_COSTOENDOLAR"] : 0;
            item.Producto_precios_Preciosugerido = dataReader["PRODUCTO_PRECIOS_PRECIOSUGERIDO"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_PRECIOS_PRECIOSUGERIDO"] : 0;
            item.Producto_precios_Fechacambioprecio = dataReader["PRODUCTO_PRECIOS_FECHACAMBIOPRECIO"] != System.DBNull.Value ?  new DateTimeOffset(((DateTime)dataReader["PRODUCTO_PRECIOS_FECHACAMBIOPRECIO"])) : null;
            item.Producto_precios_Oferta = dataReader["PRODUCTO_PRECIOS_OFERTA"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_PRECIOS_OFERTA"] : 0;
            item.Producto_precios_Preciotope = dataReader["PRODUCTO_PRECIOS_PRECIOTOPE"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_PRECIOS_PRECIOTOPE"] : 0;
            item.Producto_precios_Desctope = dataReader["PRODUCTO_PRECIOS_DESCTOPE"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_PRECIOS_DESCTOPE"] : 0;
            item.Producto_precios_Margen = dataReader["PRODUCTO_PRECIOS_MARGEN"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_PRECIOS_MARGEN"] : 0;
            item.Producto_precios_Descpes = dataReader["PRODUCTO_PRECIOS_DESCPES"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_PRECIOS_DESCPES"] : 0;
            item.Producto_promocion_Vigenciaprodpromo = dataReader["PRODUCTO_PROMOCION_VIGENCIAPRODPROMO"] != System.DBNull.Value ?  new DateTimeOffset(((DateTime)dataReader["PRODUCTO_PROMOCION_VIGENCIAPRODPROMO"]))  : null;
            item.Producto_miscelanea_Contenidovalor = dataReader["PRODUCTO_MISCELANEA_CONTENIDOVALOR"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_MISCELANEA_CONTENIDOVALOR"] : 0;
            item.Producto_utilidad_Minutilidad = dataReader["PRODUCTO_UTILIDAD_MINUTILIDAD"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_UTILIDAD_MINUTILIDAD"] : 0;
            item.Producto_utilidad_Porcutilprecio1 = dataReader["PRODUCTO_UTILIDAD_PORCUTILPRECIO1"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_UTILIDAD_PORCUTILPRECIO1"] : 0;
            item.Producto_utilidad_Porcutilprecio2 = dataReader["PRODUCTO_UTILIDAD_PORCUTILPRECIO2"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_UTILIDAD_PORCUTILPRECIO2"] : 0;
            item.Producto_utilidad_Porcutilprecio3 = dataReader["PRODUCTO_UTILIDAD_PORCUTILPRECIO3"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_UTILIDAD_PORCUTILPRECIO3"] : 0;
            item.Producto_utilidad_Porcutilprecio4 = dataReader["PRODUCTO_UTILIDAD_PORCUTILPRECIO4"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_UTILIDAD_PORCUTILPRECIO4"] : 0;
            item.Producto_utilidad_Porcutilprecio5 = dataReader["PRODUCTO_UTILIDAD_PORCUTILPRECIO5"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTO_UTILIDAD_PORCUTILPRECIO5"] : 0;
            item.Productocaracteristicas_Numero1 = dataReader["PRODUCTOCARACTERISTICAS_NUMERO1"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTOCARACTERISTICAS_NUMERO1"] : null;
            item.Productocaracteristicas_Numero2 = dataReader["PRODUCTOCARACTERISTICAS_NUMERO2"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTOCARACTERISTICAS_NUMERO2"] : null;
            item.Productocaracteristicas_Numero3 = dataReader["PRODUCTOCARACTERISTICAS_NUMERO3"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTOCARACTERISTICAS_NUMERO3"] : null;
            item.Productocaracteristicas_Numero4 = dataReader["PRODUCTOCARACTERISTICAS_NUMERO4"] != System.DBNull.Value ? (decimal)dataReader["PRODUCTOCARACTERISTICAS_NUMERO4"] : null;
            item.Productocaracteristicas_Fecha1 = dataReader["PRODUCTOCARACTERISTICAS_FECHA1"] != System.DBNull.Value ?  new DateTimeOffset(((DateTime)dataReader["PRODUCTOCARACTERISTICAS_FECHA1"]))  : null;
            item.Productocaracteristicas_Fecha2 = dataReader["PRODUCTOCARACTERISTICAS_FECHA2"] != System.DBNull.Value ? new DateTimeOffset(((DateTime)dataReader["PRODUCTOCARACTERISTICAS_FECHA2"]))  : null;
            item.Producto_origenfiscal_Ultimoorigenfiscalventa = dataReader["PRODUCTO_ORIGENFISCAL_ULTIMOORIGENFISCALVENTA"] != System.DBNull.Value ? ((long)dataReader["PRODUCTO_ORIGENFISCAL_ULTIMOORIGENFISCALVENTA"]) : (long?)null;
            

            if (Proveedor1Clave_obj != null)
                item.Proveedor1id = Proveedor1Clave_obj.Id;
            else
                item.Proveedor1id = null;

            if (Proveedor2Clave_obj != null)
                item.Proveedor2id = Proveedor2Clave_obj.Id;
            else
                item.Proveedor2id = null;

            if (LineaClave_obj != null)
                item.Lineaid = LineaClave_obj.Id;
            else
                item.Lineaid = null;

            if (MarcaClave_obj != null)
                item.Marcaid = MarcaClave_obj.Id;
            else
                item.Marcaid = null;

            if (UnidadClave_obj != null)
                item.Unidadid = UnidadClave_obj.Id;
            else
                item.Unidadid = null;

            if (SubstitutoClave_obj != null)
                item.Substitutoid = SubstitutoClave_obj.Id;
            else
                item.Substitutoid = null;

            if (Producto_emida_EmidaproductoClave_obj != null)
                item.Producto_emida_Emidaproductoid = Producto_emida_EmidaproductoClave_obj.Id;
            else
                item.Producto_emida_Emidaproductoid = null;

            if (Producto_fact_elect_Sat_productoservicioClave_obj != null)
                item.Producto_fact_elect_Sat_productoservicioid = Producto_fact_elect_Sat_productoservicioClave_obj.Id;
            else
                item.Producto_fact_elect_Sat_productoservicioid = null;

            if (Producto_fact_elect_Sat_TipoembalajeClave_obj != null)
                item.Producto_fact_elect_Sat_Tipoembalajeid = Producto_fact_elect_Sat_TipoembalajeClave_obj.Id;
            else
                item.Producto_fact_elect_Sat_Tipoembalajeid = null;

            if (Producto_fact_elect_Sat_ClaveunidadpesoClave_obj != null)
                item.Producto_fact_elect_Sat_Claveunidadpesoid = Producto_fact_elect_Sat_ClaveunidadpesoClave_obj.Id;
            else
                item.Producto_fact_elect_Sat_Claveunidadpesoid = null;

            if (Producto_fact_elect_Sat_MatpeligrosoClave_obj != null)
                item.Producto_fact_elect_Sat_Matpeligrosoid = Producto_fact_elect_Sat_MatpeligrosoClave_obj.Id;
            else
                item.Producto_fact_elect_Sat_Matpeligrosoid = null;

            if (Producto_origenfiscal_Ultimoorigenfiscalventa_Clave_obj != null)
                item.Producto_origenfiscal_Ultimoorigenfiscalventa = Producto_origenfiscal_Ultimoorigenfiscalventa_Clave_obj.Id;
            else
                item.Producto_origenfiscal_Ultimoorigenfiscalventa = null;

            if (Producto_poliza_PlazoClave_obj != null)
                item.Producto_poliza_Plazoid = Producto_poliza_PlazoClave_obj.Id;
            else
                item.Producto_poliza_Plazoid = null;

            if (Producto_precios_ListaprecmediomayClave_obj != null)
                item.Producto_precios_Listaprecmediomayid = Producto_precios_ListaprecmediomayClave_obj.Id;
            else
                item.Producto_precios_Listaprecmediomayid = null;

            if (Producto_precios_ListaprecmayoreoClave_obj != null)
                item.Producto_precios_Listaprecmayoreoid = Producto_precios_ListaprecmayoreoClave_obj.Id;
            else
                item.Producto_precios_Listaprecmayoreoid = null;

            if (Producto_precios_MonedaClave_obj != null)
                item.Producto_precios_Monedaid = Producto_precios_MonedaClave_obj.Id;
            else
                item.Producto_precios_Monedaid = null;

            if (Producto_promocion_BaseprodpromoClave_obj != null)
                item.Producto_promocion_Baseprodpromoid = Producto_promocion_BaseprodpromoClave_obj.Id;
            else
                item.Producto_promocion_Baseprodpromoid = null;

            if (Producto_miscelanea_ClasificaClave_obj != null)
                item.Producto_miscelanea_Clasificaid = Producto_miscelanea_ClasificaClave_obj.Id;
            else
                item.Producto_miscelanea_Clasificaid = null;

            if (Producto_miscelanea_ContenidoClave_obj != null)
                item.Producto_miscelanea_Contenidoid = Producto_miscelanea_ContenidoClave_obj.Id;
            else
                item.Producto_miscelanea_Contenidoid = null;

            if (Producto_padre_ProductopadreClave_obj != null)
                item.Producto_padre_Productopadreid = Producto_padre_ProductopadreClave_obj.Id;
            else
                item.Producto_padre_Productopadreid = null;



            if (existItem)
                controller.Update(item);
            else
                controller.Insert(item);

            localContext.SaveChanges();

            return true;
        }

    }
}


