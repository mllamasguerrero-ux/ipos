
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

namespace IposV3.Services
{


    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public class TrasladoImpoExpoService : BaseImpoExpoService
    {




        private ProveeduriaService _proveeduriaService;

        public TrasladoImpoExpoService(
           ProveeduriaService proveeduriaService): base()
        {
            _proveeduriaService = proveeduriaService;
        }


        public override IQueryable<List<ImpoExpoValor>>? ObtainImpoExpoValores(long empresaId, long sucursalId, long? doctoId, ApplicationDbContext localContext)
        {
            var defaultDateVal = DateTime.Parse("1980-01-01");

            var exportValores = localContext.Movto.AsNoTracking()
                                                 .Include(m => m.Docto).ThenInclude(d => d!.Sucursal_info)
                                                 .Include(m => m.Producto).ThenInclude(p => p!.Linea)
                                                 .Include(m => m.Producto).ThenInclude(p => p!.Marca)
                                                 .Include(m => m.Producto).ThenInclude(p => p!.Producto_miscelanea).ThenInclude(m => m!.Clasifica)
                                                 .Include(m => m.Producto).ThenInclude(p => p!.Marca)
                                                 .Include(m => m.Movto_comodin)
                                                 .Include(m => m.Loteimportado_).ThenInclude( l => l!.Sataduana)
                                                 .Include(m => m.Movto_origenfiscal)
                                                 .Include(m => m.Movto_precio).ThenInclude(p => p!.Listaprecio)
                                                 .Include(m => m.Movto_traslado)
                                                 .Include(m => m.Docto).ThenInclude(d => d!.Docto_traslado)
                                                 .Where(x => x.EmpresaId == empresaId && x.SucursalId == sucursalId && x.Doctoid == doctoId)
                                                 .Select(x => new List<ImpoExpoValor>(){

                                                        new ImpoExpoValor("Serie", x.Docto!.Serie, ""),
                                                        new ImpoExpoValor("Referencia", x.Docto.Referencia, ""),
                                                        new ImpoExpoValor("Referencias", x.Docto.Referencias, ""),
                                                        new ImpoExpoValor("UsuarioNombre", x.Docto.Usuario!.Clave, ""),
                                                        new ImpoExpoValor("Fecha", x.Docto.Fecha != null ? x.Docto.Fecha!.Value.LocalDateTime : DateTime.Now, DateTime.Now),
                                                        new ImpoExpoValor("Fechahora", x.Docto.Fechahora != null ? x.Docto.Fechahora!.Value.LocalDateTime : DateTime.Now, DateTime.Now),
                                                        new ImpoExpoValor("Folio", x.Docto.Folio, 0),
                                                        new ImpoExpoValor("ClienteClave", x.Docto.Cliente!.Clave, "" ),
                                                        new ImpoExpoValor("ClienteNombre", x.Docto.Cliente.Nombre,"" ),
                                                        new ImpoExpoValor("TipodoctoClave", x.Docto.Tipodocto!.Clave, ""),
                                                        new ImpoExpoValor("Sucursal_infoClave", x.Docto.Sucursal_info!.Clave, ""),

                                                        new ImpoExpoValor("ProductoClave", x.Producto!.Clave, ""),
                                                        new ImpoExpoValor("LineaClave", x.Producto.Linea!.Clave, ""),
                                                        new ImpoExpoValor("MarcaClave", x.Producto.Marca!.Clave, ""),
                                                        new ImpoExpoValor("ClasificaClave", x.Producto.Producto_miscelanea!.Clasifica!.Clave, ""),
                                                        new ImpoExpoValor("Movto_comodin_Descripcion1", x.Movto_comodin!.Descripcion1, ""),
                                                        new ImpoExpoValor("Movto_comodin_Descripcion2", x.Movto_comodin.Descripcion2, ""),
                                                        new ImpoExpoValor("Lote", x.Lote, ""),
                                                        new ImpoExpoValor("Fechavence", x.Fechavence != null ? x.Fechavence.Value.LocalDateTime :  defaultDateVal, defaultDateVal),
                                                        new ImpoExpoValor("Loteimportado_Pedimento", x.Loteimportado_!.Pedimento, "" ),
                                                        new ImpoExpoValor("Loteimportado_Claveaduana", x.Loteimportado_.Sataduana!.Sat_claveaduana, ""  ),
                                                        new ImpoExpoValor("Loteimportado_Fechaimportacion", x.Loteimportado_.Fechaimportacion != null ? x.Loteimportado_.Fechaimportacion!.Value.LocalDateTime : defaultDateVal, defaultDateVal),
                                                        new ImpoExpoValor("Loteimportado_Tipocambio", x.Loteimportado_.Tipocambio, 0m ),
                                                        new ImpoExpoValor("Cantidad", x.Cantidad, 0m),
                                                        new ImpoExpoValor("Preciolista", x.Preciolista, 0m),
                                                        new ImpoExpoValor("Descuentoporcentaje", x.Descuentoporcentaje, 0m),
                                                        new ImpoExpoValor("Descuento", x.Descuento, 0m),
                                                        new ImpoExpoValor("Precio", x.Precio, 0m),
                                                        new ImpoExpoValor("Importe", x.Importe, 0m),
                                                        new ImpoExpoValor("Subtotal", x.Subtotal, 0m),
                                                        new ImpoExpoValor("Iva", x.Iva, 0m),
                                                        new ImpoExpoValor("Ieps", x.Ieps, 0m),
                                                        new ImpoExpoValor("Tasaiva", x.Tasaiva, 0m),
                                                        new ImpoExpoValor("Tasaieps", x.Tasaieps, 0m),
                                                        new ImpoExpoValor("Total", x.Total, 0m),
                                                        new ImpoExpoValor("Movto_origenfiscal_Cantidaddefactura", x.Movto_origenfiscal!.Cantidaddefactura, 0m),
                                                        new ImpoExpoValor("Movto_origenfiscal_Cantidadderemision", x.Movto_origenfiscal.Cantidadderemision, 0m),
                                                        new ImpoExpoValor("Movto_origenfiscal_Cantidaddeindefinido", x.Movto_origenfiscal.Cantidaddeindefinido, 0m),
                                                        //new ImpoExpoValor("Movto_precio_ListaprecioClave", x.Movto_precio.Listaprecio.Clave, ""),
                                                        new ImpoExpoValor("Movto_traslado_Preciovisibletraslado", x.Movto_traslado!.Preciovisibletraslado, 0m),
                                                        new ImpoExpoValor("Partida", x.Partida, 0),
                                                        new ImpoExpoValor("Docto_traslado_Foliosolicitudmercancia", x.Docto.Docto_traslado!.Foliosolicitudmercancia, ""),
                                                        new ImpoExpoValor("Docto_traslado_Foliotrasladooriginal", x.Docto.Docto_traslado.Foliotrasladooriginal, ""),
                                                        new ImpoExpoValor("Docto_traslado_Estraslado", x.Docto.Docto_traslado.Estraslado, BoolCN.N),
                                                        new ImpoExpoValor("Docto_traslado_Esdevolucion", x.Docto.Docto_traslado.Esdevolucion, BoolCN.N),
                                                        new ImpoExpoValor("Docto_traslado_Foliodevolucion", x.Docto.Docto_traslado.Foliodevolucion, ""),
                                                        new ImpoExpoValor("Docto_traslado_Essurtimientomerca", x.Docto.Docto_traslado.Essurtimientomerca, ""),
                                                        new ImpoExpoValor("Docto_traslado_SucursaltClave", x.Docto.Docto_traslado.Sucursalt!.Clave, ""),
                                                        new ImpoExpoValor("Docto_traslado_Idsolicitudmercancia", x.Docto.Docto_traslado.Idsolicitudmercancia, 0),
                                                        new ImpoExpoValor("Docto_traslado_Idtrasladooriginal", x.Docto.Docto_traslado.Idtrasladooriginal, 0),
                                                        new ImpoExpoValor("Docto_traslado_Iddevolucion", x.Docto.Docto_traslado.Iddevolucion, 0),
                                                        new ImpoExpoValor("Movto_traslado_Motivodevolucionid", x.Movto_traslado.Motivodevolucionid, 0),
                                                        new ImpoExpoValor("Movto_traslado_MotivodevolucionClave", x.Movto_traslado.Motivodevolucion!.Clave, ""),
                                                 });




            return exportValores;
        }

        public override List<ImpoExpoField> ObtainImpoExpoFields()
        {
            return new List<ImpoExpoField>() {

                new ImpoExpoField("Serie","serie",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Referencia","ref",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Referencias","refs",254,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("UsuarioNombre","username",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Fecha","fecha",8,0, NpgsqlDbType.Date, typeof(DateTimeOffset)),
                new ImpoExpoField("Fechahora","fechora",8,0, NpgsqlDbType.Date, typeof(DateTimeOffset)),
                new ImpoExpoField("Folio","folio",8,0, NpgsqlDbType.Integer, typeof(int)),
                new ImpoExpoField("ClienteClave","clientec",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("ClienteNombre","clienten",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("TipodoctoClave","tipodoc",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Sucursal_infoClave","succve",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("ProductoClave","producto",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("LineaClave","linea",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("MarcaClave","marca",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("ClasificaClave","clasif",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Movto_comodin_Descripcion1","desc1",254,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Movto_comodin_Descripcion2","desc2",254,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Lote","lote",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Fechavence","fecvence",8,0, NpgsqlDbType.Date, typeof(DateTimeOffset)),
                new ImpoExpoField("Loteimportado_Pedimento","lotepedi",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Loteimportado_Claveaduana","loteadu",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Loteimportado_Fechaimportacion","lotefec",8,0, NpgsqlDbType.Date, typeof(DateTimeOffset)),
                new ImpoExpoField("Loteimportado_Tipocambio","lotetc",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Cantidad","cantidad",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Preciolista","preclist",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Descuentoporcentaje","descporc",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Descuento","descto",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Precio","precio",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Importe","importe",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Subtotal","subtotal",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Iva","iva",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Ieps","ieps",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Tasaiva","tasaiva",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Tasaieps","tasaieps",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Total","total",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Movto_origenfiscal_Cantidaddefactura","cantfac",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Movto_origenfiscal_Cantidadderemision","cantrem",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Movto_origenfiscal_Cantidaddeindefinido","cantind",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
               // new ImpoExpoField("Movto_precio_ListaprecioClave","preclist",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Movto_traslado_Preciovisibletraslado","prectras",18,0, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Partida","partida",8,0, NpgsqlDbType.Integer, typeof(int)),
                new ImpoExpoField("Docto_traslado_Foliosolicitudmercancia","foliosm",32,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Docto_traslado_Foliotrasladooriginal","folioto",32,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Docto_traslado_Estraslado","estrasl",1,0, NpgsqlDbType.Varchar, typeof(BoolCN)),
                new ImpoExpoField("Docto_traslado_Esdevolucion","esdevo",1,0, NpgsqlDbType.Varchar, typeof(BoolCN)),
                new ImpoExpoField("Docto_traslado_Foliodevolucion","foliod",32,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Docto_traslado_Essurtimientomerca","essurt",32,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Docto_traslado_SucursaltClave","suctcve",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Docto_traslado_Idsolicitudmercancia","idsm",8,0, NpgsqlDbType.Bigint, typeof(long)),
                new ImpoExpoField("Docto_traslado_Idtrasladooriginal","idto",8,0, NpgsqlDbType.Bigint, typeof(long)),
                new ImpoExpoField("Docto_traslado_Iddevolucion","iddev",8,0, NpgsqlDbType.Bigint, typeof(long)),
                new ImpoExpoField("Movto_traslado_Motivodevolucionid","motdevid",8,0, NpgsqlDbType.Bigint, typeof(long)),
                new ImpoExpoField("Movto_traslado_MotivodevolucionClave","motdev",31,0, NpgsqlDbType.Char, typeof(string))
            };
        }

        

        public override bool ImportFromReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                              OleDbDataReader dataReader, List<ImpoExpoField> fields, 
                                              ApplicationDbContext localContext)
        {

            var bufferStr = "";
            var bufferId = doctoId;

            var sucorigenlabel = tipoDoctoId == DBValues._DOCTO_TIPO_TRASPASO_ENVIO_BORRADOR || tipoDoctoId == DBValues._DOCTO_TIPO_TRASPASO_REC ? "suctcve" : "succve";
            var sucdestinolabel = tipoDoctoId == DBValues._DOCTO_TIPO_TRASPASO_ENVIO_BORRADOR || tipoDoctoId == DBValues._DOCTO_TIPO_TRASPASO_REC ? "succve" : "suctcve";


            bufferStr = dataReader[sucorigenlabel] != System.DBNull.Value ? ((string)dataReader[sucorigenlabel]).Trim() : "";
            var sucursal_info = bufferStr == "" ? null : localContext.Sucursal_info.AsNoTracking()
                                                                                  .Include(s => s.Sucursal_info_opciones).ThenInclude(o => o!.Sucursal_traslado)
                                                                                  .FirstOrDefault(x => x.EmpresaId == empresaId &&
                                                                                                       x.SucursalId == sucursalId &&
                                                                                                       x.Clave == bufferStr);

            bufferStr = dataReader[sucdestinolabel] != System.DBNull.Value ? ((string)dataReader[sucdestinolabel]).Trim() : "";
            var sucursal_info_trasl = bufferStr == "" ? null : localContext.Sucursal_info.AsNoTracking()
                                                                                  .Include(s => s.Sucursal_info_opciones).ThenInclude(o => o!.Sucursal_traslado)
                                                                                  .FirstOrDefault(x => x.EmpresaId == empresaId &&
                                                                                                       x.SucursalId == sucursalId &&
                                                                                                       x.Clave == bufferStr);
            if (sucursal_info == null || sucursal_info_trasl == null)
                throw new Exception("La sucusal fuente o destino no esta definda");



            var doctoSaved = doctoId != null ?  localContext.Docto.AsNoTracking()
                                        .Include(d => d.Docto_traslado)
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Id == bufferId!.Value) : null;

            var docto_Id = doctoSaved != null ? doctoSaved.Id : (long?)null;


            if (docto_Id == null)
            {

                var doctoParam = new DoctoProvTrans();



                doctoParam.Referencia = dataReader["ref"] != System.DBNull.Value ? ((string)dataReader["ref"]).Trim() : ""; ;
                doctoParam.Referencias = dataReader["refs"] != System.DBNull.Value ? ((string)dataReader["refs"]).Trim() : "";
                doctoParam.Promocion = BoolCN.N;
                doctoParam.Empresaid = empresaId;
                doctoParam.Sucursalid = sucursalId;
                doctoParam.Estatusdoctoid = DBValues._DOCTO_ESTATUS_BORRADOR;
                doctoParam.Usuarioid = usuarioId!.Value;
                doctoParam.Creadopor_userid = usuarioId!.Value;
                doctoParam.Fecha = dataReader["fecha"] != System.DBNull.Value ? (new DateTimeOffset((DateTime)dataReader["fecha"])).ToUniversalTime() : DateTimeOffset.UtcNow;
                doctoParam.Cajaid = DBValues._CAJA_DEFAULT;
                doctoParam.Almacenid = DBValues._ALMACEN_DEFAULT;
                doctoParam.Origenfiscalid = DBValues._ORIGENFISCAL_REMISIONADO;
                doctoParam.Folio_c = dataReader["folio"] != System.DBNull.Value ? dataReader["folio"].ToString() : (string?)null;
                doctoParam.Factura_c = null;
                doctoParam.Fechafactura_c = doctoParam.Fecha;
                doctoParam.Fechavence_c = null; 
                doctoParam.Doctoparentid = null;
                doctoParam.Proveedorid = 0;
                doctoParam.Tipodoctoid = tipoDoctoId ?? DBValues._DOCTO_TIPO_TRASPASO_REC;
                doctoParam.Sucursal_id = sucursal_info!.Id;
                doctoParam.Sucursaltid = sucursal_info_trasl!.Id;
                doctoParam.Almacentid = DBValues._ALMACEN_DEFAULT;

                _proveeduriaService.Docto_prov_insert(doctoParam, ref docto_Id, localContext);


                var docto = localContext.Docto.FirstOrDefault(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId &&
                                                                   d.Id == docto_Id);

                if (docto == null)
                    throw new Exception("Docto es nulo");

                docto.Docto_traslado!.Foliosolicitudmercancia = dataReader["foliosm"] != System.DBNull.Value ? ((string)dataReader["foliosm"]).Trim() : "";
                docto.Docto_traslado!.Foliotrasladooriginal = dataReader["folioto"] != System.DBNull.Value ? ((string)dataReader["folioto"]).Trim() : "";
                docto.Docto_traslado!.Foliodevolucion = dataReader["foliod"] != System.DBNull.Value ? ((string)dataReader["foliod"]).Trim() : "";
                docto.Docto_traslado!.Essurtimientomerca = dataReader["essurt"] != System.DBNull.Value ? ((string)dataReader["essurt"]).Trim() : "";
                docto.Docto_traslado!.Estraslado = dataReader["estrasl"] != System.DBNull.Value && ((string)dataReader["estrasl"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
                docto.Docto_traslado!.Esdevolucion = dataReader["esdevo"] != System.DBNull.Value && ((string)dataReader["esdevo"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
                docto.Docto_traslado!.Idsolicitudmercancia = dataReader["idsm"] != System.DBNull.Value ? long.Parse(dataReader["idsm"].ToString()!) : (long?)null;
                docto.Docto_traslado!.Idtrasladooriginal = dataReader["idto"] != System.DBNull.Value ? long.Parse(dataReader["idto"].ToString()!) : (long?)null;
                docto.Docto_traslado!.Iddevolucion = dataReader["iddev"] != System.DBNull.Value ? long.Parse(dataReader["iddev"].ToString()!) : (long?)null;
               

                localContext.Update(docto.Docto_traslado!);
                localContext.SaveChanges();


            }


            doctoId = docto_Id;

            bufferStr = dataReader["producto"] != System.DBNull.Value ? ((string)dataReader["producto"]).Trim() : "";
            var productoSaved = bufferStr == "" ? null : localContext.Producto.AsNoTracking()
                                                                                  .Include(p => p.Producto_precios)
                                                                                  .FirstOrDefault(x => x.EmpresaId == empresaId &&
                                                                                                       x.SucursalId == sucursalId &&
                                                                                                       x.Clave == bufferStr);

            if (productoSaved == null)
                throw new Exception("producto no encontrado");


            bufferStr = dataReader["lotepedi"] != System.DBNull.Value ? ((string)dataReader["lotepedi"]).Trim() : "";
            var lotePedimento = bufferStr == "" ? null : localContext.Lotesimportados.AsNoTracking()
                                                                                  .FirstOrDefault(x => x.EmpresaId == empresaId &&
                                                                                                       x.SucursalId == sucursalId &&
                                                                                                       x.Pedimento == bufferStr);

            var precio = dataReader["precio"] != System.DBNull.Value ? (decimal)dataReader["precio"] : 0m;
            var precioyavalidado = BoolCN.N;
            if (precio == 0m  && tipoDoctoId == DBValues._DOCTO_TIPO_PEDIDO_TRASPASO_SALIDA)
            {
                var listaPrecio = (sucursal_info_trasl.Sucursal_info_opciones != null && sucursal_info_trasl.Sucursal_info_opciones.Sucursal_traslado != null &&
                                    sucursal_info_trasl.Sucursal_info_opciones.Sucursal_traslado.Precioenviotraslado != null) ?
                                    sucursal_info_trasl.Sucursal_info_opciones.Sucursal_traslado.Precioenviotraslado.Value :
                                    (sucursal_info.Sucursal_info_opciones != null && sucursal_info.Sucursal_info_opciones.Sucursal_traslado != null &&
                                    sucursal_info.Sucursal_info_opciones.Sucursal_traslado.Precioenviotraslado != null) ?
                                    sucursal_info.Sucursal_info_opciones.Sucursal_traslado.Precioenviotraslado.Value :
                                    3;

                
                switch(listaPrecio)
                {
                    case 1: precio = productoSaved.Producto_precios?.Precio1 ?? 0m; break;
                    case 2: precio = productoSaved.Producto_precios?.Precio2 ?? 0m; break;
                    case 3: precio = productoSaved.Producto_precios?.Precio3 ?? 0m; break;
                    case 4: precio = productoSaved.Producto_precios?.Precio4 ?? 0m; break;
                    case 5: precio = productoSaved.Producto_precios?.Precio5 ?? 0m; break;
                    case 6: precio = productoSaved.Producto_precios?.Precio6 ?? 0m; break;
                    default: precio = productoSaved.Producto_precios?.Precio3 ?? 0m; break;
                }
                precioyavalidado = BoolCN.S;

            }

            var movtoTrans = new MovtoProvTrans()
            {

                Empresaid = empresaId,
                Sucursalid = sucursalId,
                Doctoid = docto_Id!.Value,
                Partida = dataReader["partida"] != System.DBNull.Value ? int.Parse(dataReader["partida"].ToString()!) : 0,
                Estatusmovtoid = DBValues._MOVTO_ESTATUS_BORRADOR,
                Productoid = productoSaved.Id,
                Cantidad = dataReader["cantidad"] != System.DBNull.Value ? (decimal)dataReader["cantidad"] : 0,
                Descuentoporcentaje = dataReader["descporc"] != System.DBNull.Value ? (decimal)dataReader["descporc"] : 0,
                Precio = precio,
                Lote = dataReader["lote"] != System.DBNull.Value ? ((string)dataReader["lote"]).Trim() : "",
                Fechavence = dataReader["fecvence"] != System.DBNull.Value ? (new DateTimeOffset((DateTime)dataReader["fecvence"])).ToUniversalTime() : null,
                Loteimportado = lotePedimento?.Id,
                Movtoparentid = null,
                Localidad = null,
                Descripcion1 = dataReader["desc1"] != System.DBNull.Value ? ((string)dataReader["desc1"]).Trim() : "",
                Descripcion2 = dataReader["desc2"] != System.DBNull.Value ? ((string)dataReader["desc2"]).Trim() : "",
                Descripcion3 = null,
                Agrupaporparametro = null,
                Cargartarjetapreciomanual = null,
                Precioyavalidado = precioyavalidado,
                Usuarioid = usuarioId!.Value,
                Precioconimp = null,
                Anaquelid = null



            };

            var defaultDateVal = DateTime.Parse("1980-01-03");

            movtoTrans.Lote = movtoTrans.Lote == "" ? null : movtoTrans.Lote;
            movtoTrans.Fechavence = movtoTrans.Fechavence != null && movtoTrans.Fechavence < defaultDateVal ? movtoTrans.Fechavence : null;

            long? movtoId = null;
            _proveeduriaService.Movto_prov_insert(movtoTrans, ref movtoId, localContext);


            var movto = localContext.Movto.FirstOrDefault(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && 
                                                          m.Id == movtoId);

            if (movto == null)
                throw new Exception("Movto no insertado");

            if(movto.Movto_origenfiscal != null)
            {

                movto.Movto_origenfiscal.Cantidaddefactura = dataReader["cantfac"] != System.DBNull.Value ? (decimal)dataReader["cantfac"] : 0;
                movto.Movto_origenfiscal.Cantidadderemision = dataReader["cantrem"] != System.DBNull.Value ? (decimal)dataReader["cantrem"] : 0;
                movto.Movto_origenfiscal.Cantidaddeindefinido = dataReader["cantind"] != System.DBNull.Value ? (decimal)dataReader["cantind"] : 0;
                localContext.Update(movto.Movto_origenfiscal);
                localContext.SaveChanges();
            }
            else
            {
                movto.Movto_origenfiscal = new Movto_origenfiscal()
                {
                    EmpresaId = empresaId,
                    SucursalId = sucursalId,
                    Movtoid = movto.Id,
                    Cantidaddefactura = dataReader["cantfac"] != System.DBNull.Value ? (decimal)dataReader["cantfac"] : 0,
                    Cantidadderemision = dataReader["cantrem"] != System.DBNull.Value ? (decimal)dataReader["cantrem"] : 0,
                    Cantidaddeindefinido = dataReader["cantind"] != System.DBNull.Value ? (decimal)dataReader["cantind"] : 0

                };

                localContext.Add(movto.Movto_origenfiscal);
                localContext.SaveChanges();
            }


            bufferStr = dataReader["motdev"] != System.DBNull.Value ? ((string)dataReader["motdev"]).Trim() : "";
            var motdevSaved = bufferStr == "" ? null : localContext.Motivo_devolucion.AsNoTracking()
                                                                                  .FirstOrDefault(x => x.Clave == bufferStr);


            if (movto.Movto_traslado != null)
            {
                movto.Movto_traslado.Preciovisibletraslado = dataReader["prectras"] != System.DBNull.Value ? (decimal)dataReader["prectras"] : 0;
                movto.Movto_traslado.Motivodevolucionid = motdevSaved?.Id;

                localContext.Update(movto.Movto_traslado);
                localContext.SaveChanges();
            }
            else
            {
                movto.Movto_traslado = new Movto_traslado()
                {
                    EmpresaId = empresaId,
                    SucursalId = sucursalId,
                    Movtoid = movto.Id,
                    Preciovisibletraslado = dataReader["prectras"] != System.DBNull.Value ? (decimal)dataReader["prectras"] : 0,
                    Motivodevolucionid = motdevSaved?.Id

                };

                localContext.Add(movto.Movto_traslado);
                localContext.SaveChanges();
            }

            
            //item.Movto_traslado.Motivodevolucionid = dataReader["motdevid"] != System.DBNull.Value ? long.Parse(dataReader["motdevid"].ToString()) : (long?)null;
            //item.Movto_traslado.Motivodevolucion.Clave = dataReader["motdev"] != System.DBNull.Value ? ((string)dataReader["motdev"]).Trim() : ;



            //item.Serie = dataReader["serie"] != System.DBNull.Value ? ((string)dataReader["serie"]).Trim() : "";

            //item.Usuario.Clave = dataReader["username"] != System.DBNull.Value ? ((string)dataReader["username"]).Trim() : ;
            //item.Cliente.Clave = dataReader["clientec"] != System.DBNull.Value ? ((string)dataReader["clientec"]).Trim() : ;
            //item.Cliente.Nombre = dataReader["clienten"] != System.DBNull.Value ? ((string)dataReader["clienten"]).Trim() : ;
            //item.Tipodocto.Clave = dataReader["tipodoc"] != System.DBNull.Value ? ((string)dataReader["tipodoc"]).Trim() : ;

            //item.Producto.Linea.Clave.Clave = dataReader["linea"] != System.DBNull.Value ? ((string)dataReader["linea"]).Trim() : ;
            //item.Producto.Marca.Clave.Clave = dataReader["marca"] != System.DBNull.Value ? ((string)dataReader["marca"]).Trim() : ;
            //item.Producto.Clasifica.Clave.Clave = dataReader["clasif"] != System.DBNull.Value ? ((string)dataReader["clasif"]).Trim() : ;

            //item.Loteimportado..Pedimento = dataReader["lotepedi"] != System.DBNull.Value ? ((string)dataReader["lotepedi"]).Trim() : ;
            //item.Loteimportado..Claveaduana = dataReader["loteadu"] != System.DBNull.Value ? ((string)dataReader["loteadu"]).Trim() : ;
            //item.Loteimportado..Fechaimportacion = dataReader["lotefec"] != System.DBNull.Value ? ((string)dataReader["lotefec"]).Trim() : ;
            //item.Loteimportado..Tipocambio = dataReader["lotetc"] != System.DBNull.Value ? ((string)dataReader["lotetc"]).Trim() : ;
            //item.Movto_precio.Listaprecio.Clave = dataReader["preclist"] != System.DBNull.Value ? ((string)dataReader["preclist"]).Trim() : ;

            //item.Preciolista = dataReader["preclist"] != System.DBNull.Value ? (decimal)dataReader["preclist"] : 0;
            //item.Descuento = dataReader["descto"] != System.DBNull.Value ? (decimal)dataReader["descto"] : 0;
            //item.Importe = dataReader["importe"] != System.DBNull.Value ? (decimal)dataReader["importe"] : 0;
            //item.Subtotal = dataReader["subtotal"] != System.DBNull.Value ? (decimal)dataReader["subtotal"] : 0;
            //item.Iva = dataReader["iva"] != System.DBNull.Value ? (decimal)dataReader["iva"] : 0;
            //item.Ieps = dataReader["ieps"] != System.DBNull.Value ? (decimal)dataReader["ieps"] : 0;
            //item.Tasaiva = dataReader["tasaiva"] != System.DBNull.Value ? (decimal)dataReader["tasaiva"] : 0;
            //item.Tasaieps = dataReader["tasaieps"] != System.DBNull.Value ? (decimal)dataReader["tasaieps"] : 0;
            //item.Total = dataReader["total"] != System.DBNull.Value ? (decimal)dataReader["total"] : 0;


            //item.Movto_origenfiscal.Cantidaddefactura = dataReader["cantfac"] != System.DBNull.Value ? (decimal)dataReader["cantfac"] : 0;
            //item.Movto_origenfiscal.Cantidadderemision = dataReader["cantrem"] != System.DBNull.Value ? (decimal)dataReader["cantrem"] : 0;
            //item.Movto_origenfiscal.Cantidaddeindefinido = dataReader["cantind"] != System.DBNull.Value ? (decimal)dataReader["cantind"] : 0;
            //item.Movto_traslado.Preciovisibletraslado = dataReader["prectras"] != System.DBNull.Value ? (decimal)dataReader["prectras"] : 0;
            //item.Movto_traslado.Motivodevolucionid = dataReader["motdevid"] != System.DBNull.Value ? long.Parse(dataReader["motdevid"].ToString()) : (long?)null;
            //item.Movto_traslado.Motivodevolucion.Clave = dataReader["motdev"] != System.DBNull.Value ? ((string)dataReader["motdev"]).Trim() : ;



            //localContext.SaveChanges();

            return true;
        }

    }
}


