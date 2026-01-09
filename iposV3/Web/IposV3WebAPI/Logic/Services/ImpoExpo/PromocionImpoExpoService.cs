
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
    public class PromocionImpoExpoService : BaseImpoExpoService
    {






        public override IQueryable<List<ImpoExpoValor>>? ObtainImpoExpoValores(long empresaId, long sucursalId, ApplicationDbContext localContext)
        {
            var exportValores = localContext.Promocion.AsNoTracking()
                                                 .Include(p => p.Producto)
                                                 .Include(p => p.Tipopromocion)
                                                 .Include(p => p.Rangopromocion)
                                                 .Include(p => p.Linea)
                                                 .Where(x => x.EmpresaId == empresaId && x.SucursalId == sucursalId)
                                                 .Select(x => new List<ImpoExpoValor>(){

                                                        new ImpoExpoValor("Activo", x.Activo, BoolCS.S),
                                                        new ImpoExpoValor("Clave", x.Clave, ""),
                                                        new ImpoExpoValor("Nombre", x.Nombre, ""),
                                                        new ImpoExpoValor("Descripcion", x.Descripcion, ""),
                                                        new ImpoExpoValor("Memo", x.Memo, ""),
                                                        new ImpoExpoValor("EsPromocion", x.EsPromocion, BoolCN.N),
                                                        new ImpoExpoValor("Lunes", x.Lunes, BoolCS.S),
                                                        new ImpoExpoValor("Martes", x.Martes, BoolCS.S),
                                                        new ImpoExpoValor("Miercoles", x.Miercoles, BoolCS.S),
                                                        new ImpoExpoValor("Jueves", x.Jueves, BoolCS.S),
                                                        new ImpoExpoValor("Viernes", x.Viernes, BoolCS.S),
                                                        new ImpoExpoValor("Sabado", x.Sabado, BoolCS.S),
                                                        new ImpoExpoValor("Domingo", x.Domingo, BoolCS.S),
                                                        new ImpoExpoValor("Enmonedero", x.Enmonedero, BoolCN.N),
                                                        new ImpoExpoValor("Cantidad", x.Cantidad, 0m),
                                                        new ImpoExpoValor("ProductoClave", x.Producto!.Clave, ""),
                                                        new ImpoExpoValor("ProductoNombre", x.Producto.Nombre, ""),
                                                        new ImpoExpoValor("Utilidad", x.Utilidad, 0m),
                                                        new ImpoExpoValor("Cantidadllevate", x.Cantidadllevate, 0m),
                                                        new ImpoExpoValor("Importe", x.Importe, 0m),
                                                        new ImpoExpoValor("Porcentajedescuento", x.Porcentajedescuento, 0m),
                                                        new ImpoExpoValor("TipopromocionClave", x.Tipopromocion!.Clave, ""),
                                                        new ImpoExpoValor("TipopromocionNombre", x.Tipopromocion.Nombre, ""),
                                                        new ImpoExpoValor("RangopromocionClave", x.Rangopromocion!.Clave, ""),
                                                        new ImpoExpoValor("RangopromocionNombre", x.Rangopromocion.Nombre, ""),
                                                        new ImpoExpoValor("LineaClave", x.Linea!.Clave, ""),
                                                        new ImpoExpoValor("LineaNombre", x.Linea.Nombre, ""),
                                                        new ImpoExpoValor("Fechainicio", x.Fechainicio != null ? x.Fechainicio!.Value.LocalDateTime : null, DateTime.Now),
                                                        new ImpoExpoValor("Fechafin", x.Fechafin != null ? x.Fechafin!.Value.LocalDateTime : null, DateTime.Now),
                                                        new ImpoExpoValor("Porimporte", x.Porimporte, 0m),
                                                        new ImpoExpoValor("Imagen", x.Imagen, ""),
                                                        new ImpoExpoValor("Mostrardatoscliente", x.Mostrardatoscliente, BoolCN.N),

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
                new ImpoExpoField("Memo","memo",254,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("EsPromocion","espromo",1,0, NpgsqlDbType.Varchar, typeof(BoolCN)),
                new ImpoExpoField("Lunes","lunes",1,0, NpgsqlDbType.Varchar, typeof(BoolCS)),
                new ImpoExpoField("Martes","martes",1,0, NpgsqlDbType.Varchar, typeof(BoolCS)),
                new ImpoExpoField("Miercoles","miercoles",1,0, NpgsqlDbType.Varchar, typeof(BoolCS)),
                new ImpoExpoField("Jueves","jueves",1,0, NpgsqlDbType.Varchar, typeof(BoolCS)),
                new ImpoExpoField("Viernes","viernes",1,0, NpgsqlDbType.Varchar, typeof(BoolCS)),
                new ImpoExpoField("Sabado","sabado",1,0, NpgsqlDbType.Varchar, typeof(BoolCS)),
                new ImpoExpoField("Domingo","domingo",1,0, NpgsqlDbType.Varchar, typeof(BoolCS)),
                new ImpoExpoField("Enmonedero","enmoned",1,0, NpgsqlDbType.Varchar, typeof(BoolCN)),
                new ImpoExpoField("Cantidad","cant",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("ProductoClave","proclave",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("ProductoNombre","pronombre",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Utilidad","utilidad",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Cantidadllevate","cntlleva",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Importe","importe",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Porcentajedescuento","porcdesc",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("TipopromocionClave","tpclave",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("TipopromocionNombre","tpnombre",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("RangopromocionClave","rpclave",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("RangopromocionNombre","rpnombre",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("LineaClave","linclave",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("LineaNombre","linnombre",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Fechainicio","fechaini",8,0, NpgsqlDbType.Date, typeof(DateTimeOffset)),
                new ImpoExpoField("Fechafin","fechafin",8,0, NpgsqlDbType.Date, typeof(DateTimeOffset)),
                new ImpoExpoField("Porimporte","porimpo",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Imagen","imagen",254,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Mostrardatoscliente","mostrarda",1,0, NpgsqlDbType.Varchar, typeof(BoolCN)),
            };
        }

        public override bool ImportFromReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               OleDbDataReader dataReader, List<ImpoExpoField> fields, ApplicationDbContext localContext)
        {

            var clave = dataReader["clave"] != System.DBNull.Value ? ((string)dataReader["clave"]).Trim() : "";

            var bufferStr = "";

            var itemSaved = localContext.Promocion
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == clave);

            var item = itemSaved != null ? itemSaved : new Promocion();
            var existItem = itemSaved != null;

	
          	item.Clave = dataReader["clave"] != System.DBNull.Value ? ((string)dataReader["clave"]).Trim() : ""; 
          	item.Nombre = dataReader["nombre"] != System.DBNull.Value ? ((string)dataReader["nombre"]).Trim() : ""; 
          	item.Descripcion = dataReader["descr"] != System.DBNull.Value ? ((string)dataReader["descr"]).Trim() : ""; 
          	item.Memo = dataReader["memo"] != System.DBNull.Value ? ((string)dataReader["memo"]).Trim() : "";


            bufferStr = dataReader["proclave"] != System.DBNull.Value ? ((string)dataReader["proclave"]).Trim() : "";
            var producto = bufferStr == "" ? null : localContext.Producto.AsNoTracking()
                                                                                  .FirstOrDefault(x => x.EmpresaId == empresaId &&
                                                                                                       x.SucursalId == sucursalId &&
                                                                                                       x.Clave == bufferStr);
            item.Productoid = producto?.Id;


            bufferStr = dataReader["tpclave"] != System.DBNull.Value ? ((string)dataReader["tpclave"]).Trim() : "";
            var tipopromocion = bufferStr == "" ? null : localContext.Tipopromocion.AsNoTracking()
                                                                                  .FirstOrDefault(x => x.Clave == bufferStr);
            item.Tipopromocionid = tipopromocion?.Id;


            bufferStr = dataReader["rpclave"] != System.DBNull.Value ? ((string)dataReader["rpclave"]).Trim() : "";
            var rangopromocion = bufferStr == "" ? null : localContext.Rangopromocion.AsNoTracking()
                                                                                  .FirstOrDefault(x => x.Clave == bufferStr);
            item.Rangopromocionid = rangopromocion?.Id;


            bufferStr = dataReader["linclave"] != System.DBNull.Value ? ((string)dataReader["linclave"]).Trim() : "";
            var linea = bufferStr == "" ? null : localContext.Linea.AsNoTracking()
                                                                                  .FirstOrDefault(x => x.EmpresaId == empresaId &&
                                                                                                       x.SucursalId == sucursalId &&
                                                                                                       x.Clave == bufferStr);
            item.Lineaid = linea?.Id;


            item.Imagen = dataReader["imagen"] != System.DBNull.Value ? ((string)dataReader["imagen"]).Trim() : ""; 
		item.EsPromocion = dataReader["espromo"] != System.DBNull.Value && ((string)dataReader["espromo"]).Trim() == "S" ? BoolCN.S : BoolCN.N; 
		item.Enmonedero = dataReader["enmoned"] != System.DBNull.Value && ((string)dataReader["enmoned"]).Trim() == "S" ? BoolCN.S : BoolCN.N; 
		item.Mostrardatoscliente = dataReader["mostrarda"] != System.DBNull.Value && ((string)dataReader["mostrarda"]).Trim() == "S" ? BoolCN.S : BoolCN.N; 
		item.Activo = dataReader["activo"] != System.DBNull.Value && ((string)dataReader["activo"]).Trim() == "N" ? BoolCS.N : BoolCS.S; 
		item.Lunes = dataReader["lunes"] != System.DBNull.Value && ((string)dataReader["lunes"]).Trim() == "N" ? BoolCS.N : BoolCS.S; 
		item.Martes = dataReader["martes"] != System.DBNull.Value && ((string)dataReader["martes"]).Trim() == "N" ? BoolCS.N : BoolCS.S; 
		item.Miercoles = dataReader["miercoles"] != System.DBNull.Value && ((string)dataReader["miercoles"]).Trim() == "N" ? BoolCS.N : BoolCS.S; 
		item.Jueves = dataReader["jueves"] != System.DBNull.Value && ((string)dataReader["jueves"]).Trim() == "N" ? BoolCS.N : BoolCS.S; 
		item.Viernes = dataReader["viernes"] != System.DBNull.Value && ((string)dataReader["viernes"]).Trim() == "N" ? BoolCS.N : BoolCS.S; 
		item.Sabado = dataReader["sabado"] != System.DBNull.Value && ((string)dataReader["sabado"]).Trim() == "N" ? BoolCS.N : BoolCS.S; 
		item.Domingo = dataReader["domingo"] != System.DBNull.Value && ((string)dataReader["domingo"]).Trim() == "N" ? BoolCS.N : BoolCS.S;         
		item.Cantidad = dataReader["cant"] != System.DBNull.Value ? (decimal)dataReader["cant"] : 0m;         
		item.Utilidad = dataReader["utilidad"] != System.DBNull.Value ? (decimal)dataReader["utilidad"] : 0m;         
		item.Cantidadllevate = dataReader["cntlleva"] != System.DBNull.Value ? (decimal)dataReader["cntlleva"] : 0m;         
		item.Importe = dataReader["importe"] != System.DBNull.Value ? (decimal)dataReader["importe"] : 0m;         
		item.Porcentajedescuento = dataReader["porcdesc"] != System.DBNull.Value ? (decimal)dataReader["porcdesc"] : 0m;         
        item.Fechainicio = dataReader["fechaini"] != System.DBNull.Value ? (new DateTimeOffset((DateTime)dataReader["fechaini"])).ToUniversalTime() : null;
        item.Fechafin = dataReader["fechafin"] != System.DBNull.Value ? (new DateTimeOffset((DateTime)dataReader["fechafin"])).ToUniversalTime() : null;
		item.Porimporte = dataReader["porimpo"] != System.DBNull.Value ? (decimal)dataReader["porimpo"] : 0m; 


            if (existItem)
                localContext.Promocion.Update(item);
            else
                localContext.Promocion.Add(item);

            localContext.SaveChanges();

            return true;
        }



        public void ImportarDeTablaFirebird(
                          long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                          string fbCadenaConexion,
                          string? nombreTabla, string? queryPersonalizada,
                           ApplicationDbContext localContext, PromocionController promocionController)
        {
            /**/
            FbDataReader? dr = null;
            FbConnection? pcn = null;

            var utf8 = new UTF8Encoding();

            try
            {

                System.Collections.ArrayList parts = new ArrayList();

                String CmdTxt = @"SELECT
        PROMOCION.CLAVE as CLAVE,
        PROMOCION.NOMBRE as NOMBRE,
        PROMOCION.DESCRIPCION as DESCRIPCION,
        PROMOCION.MEMO as MEMO,
        PROMOCION.IMAGEN as IMAGEN,
        PROMOCION.DESCMULTIDETALLE as DESCMULTIDETALLE,
        PROMOCION.PROMOCION as ESPROMOCION,
        PROMOCION.ENMONEDERO as ENMONEDERO,
        PROMOCION.MOSTRARDATOSCLIENTE as MOSTRARDATOSCLIENTE,
        PROMOCION.ESMULTIDETALLE as ESMULTIDETALLE,
        PROMOCION.ACTIVO as ACTIVO, 
        PROMOCION.LUNES as LUNES,
        PROMOCION.MARTES as MARTES, 
        PROMOCION.MIERCOLES as MIERCOLES, 
        PROMOCION.JUEVES as JUEVES, 
        PROMOCION.VIERNES as VIERNES, 
        PROMOCION.SABADO as SABADO, 
        PROMOCION.DOMINGO as DOMINGO, 
        PROMOCION.CREADO as CREADO, 
        PROMOCION.MODIFICADO as MODIFICADO, 
        PROMOCION.CANTIDAD as CANTIDAD, 
        PROMOCION.UTILIDAD as UTILIDAD, 
        PROMOCION.CANTIDADLLEVATE as CANTIDADLLEVATE, 
        PROMOCION.IMPORTE as IMPORTE, 
        PROMOCION.PORCENTAJEDESCUENTO as PORCENTAJEDESCUENTO, 
        PROMOCION.FECHAINICIO as FECHAINICIO, 
        PROMOCION.FECHAFIN as FECHAFIN, 
        PROMOCION.PORIMPORTE as PORIMPORTE,
        PRODUCTO.CLAVE PRODUCTOCLAVE ,
        TIPOPROMOCION.CLAVE TIPOPROMOCIONCLAVE ,
        RANGOPROMOCION.CLAVE RANGOPROMOCIONCLAVE,
        LINEA.CLAVE LINEACLAVE
  FROM PROMOCION
     LEFT JOIN PRODUCTO ON PRODUCTO.ID = PROMOCION.productoid
     LEFT JOIN TIPOPROMOCION ON TIPOPROMOCION.ID = PROMOCION.TIPOPROMOCIONID
     LEFT JOIN RANGOPROMOCION ON RANGOPROMOCION.ID = PROMOCION.RANGOPROMOCIONID
     LEFT JOIN LINEA ON LINEA.ID = PROMOCION.LINEAID";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                dr = FbSqlHelper.ExecuteReader(fbCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);


                while (dr.Read())
                {

                    ImportFromFirebirdReader(empresaId, sucursalId, usuarioId, ref doctoId, tipoDoctoId,
                                             dr, localContext, promocionController);
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
                                               FbDataReader dataReader, ApplicationDbContext localContext, PromocionController controller)
        {

            var clave = dataReader["CLAVE"] != System.DBNull.Value ? ((string)dataReader["CLAVE"]).Trim() : "";


            var ProductoClave = dataReader["PRODUCTOCLAVE"] != System.DBNull.Value ? ((string)dataReader["PRODUCTOCLAVE"]).Trim() : "";

            var TipopromocionClave = dataReader["TIPOPROMOCIONCLAVE"] != System.DBNull.Value ? ((string)dataReader["TIPOPROMOCIONCLAVE"]).Trim() : "";

            var RangopromocionClave = dataReader["RANGOPROMOCIONCLAVE"] != System.DBNull.Value ? ((string)dataReader["RANGOPROMOCIONCLAVE"]).Trim() : "";

            var LineaClave = dataReader["LINEACLAVE"] != System.DBNull.Value ? ((string)dataReader["LINEACLAVE"]).Trim() : "";


            var itemSaved = localContext.Promocion.AsNoTracking()
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == clave);


            var ProductoClave_obj = localContext.Producto.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == ProductoClave);

            var TipopromocionClave_obj = localContext.Tipopromocion.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave == TipopromocionClave);

            var RangopromocionClave_obj = localContext.Rangopromocion.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave == RangopromocionClave);

            var LineaClave_obj = localContext.Linea.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == LineaClave);


            var item = itemSaved != null ? new PromocionBindingModel(itemSaved) : new PromocionBindingModel();
            var existItem = itemSaved != null;

            item.EmpresaId = empresaId;
            item.SucursalId = sucursalId;

            item.Clave = dataReader["CLAVE"] != System.DBNull.Value ? ((string)dataReader["CLAVE"]).Trim() : "";
            item.Nombre = dataReader["NOMBRE"] != System.DBNull.Value ? ((string)dataReader["NOMBRE"]).Trim() : "";
            item.Descripcion = dataReader["DESCRIPCION"] != System.DBNull.Value ? ((string)dataReader["DESCRIPCION"]).Trim() : "";
            item.Memo = dataReader["MEMO"] != System.DBNull.Value ? ((string)dataReader["MEMO"]).Trim() : "";
            item.Imagen = dataReader["IMAGEN"] != System.DBNull.Value ? ((string)dataReader["IMAGEN"]).Trim() : "";
            item.Descmultidetalle = dataReader["DESCMULTIDETALLE"] != System.DBNull.Value ? ((string)dataReader["DESCMULTIDETALLE"]).Trim() : "";
            item.EsPromocion = dataReader["ESPROMOCION"] != System.DBNull.Value && ((string)dataReader["ESPROMOCION"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Enmonedero = dataReader["ENMONEDERO"] != System.DBNull.Value && ((string)dataReader["ENMONEDERO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Mostrardatoscliente = dataReader["MOSTRARDATOSCLIENTE"] != System.DBNull.Value && ((string)dataReader["MOSTRARDATOSCLIENTE"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Esmultidetalle = dataReader["ESMULTIDETALLE"] != System.DBNull.Value && ((string)dataReader["ESMULTIDETALLE"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Activo = dataReader["ACTIVO"] != System.DBNull.Value && ((string)dataReader["ACTIVO"]).Trim() == "N" ? BoolCS.N : BoolCS.S;
            item.Lunes = dataReader["LUNES"] != System.DBNull.Value && ((string)dataReader["LUNES"]).Trim() == "N" ? BoolCS.N : BoolCS.S;
            item.Martes = dataReader["MARTES"] != System.DBNull.Value && ((string)dataReader["MARTES"]).Trim() == "N" ? BoolCS.N : BoolCS.S;
            item.Miercoles = dataReader["MIERCOLES"] != System.DBNull.Value && ((string)dataReader["MIERCOLES"]).Trim() == "N" ? BoolCS.N : BoolCS.S;
            item.Jueves = dataReader["JUEVES"] != System.DBNull.Value && ((string)dataReader["JUEVES"]).Trim() == "N" ? BoolCS.N : BoolCS.S;
            item.Viernes = dataReader["VIERNES"] != System.DBNull.Value && ((string)dataReader["VIERNES"]).Trim() == "N" ? BoolCS.N : BoolCS.S;
            item.Sabado = dataReader["SABADO"] != System.DBNull.Value && ((string)dataReader["SABADO"]).Trim() == "N" ? BoolCS.N : BoolCS.S;
            item.Domingo = dataReader["DOMINGO"] != System.DBNull.Value && ((string)dataReader["DOMINGO"]).Trim() == "N" ? BoolCS.N : BoolCS.S;
            item.Creado = dataReader["CREADO"] != System.DBNull.Value ? new DateTimeOffset(((DateTime)dataReader["CREADO"])) : DateTime.UtcNow;
            item.Modificado = dataReader["MODIFICADO"] != System.DBNull.Value ? new DateTimeOffset(((DateTime)dataReader["MODIFICADO"])) : DateTime.UtcNow;
            item.Cantidad = dataReader["CANTIDAD"] != System.DBNull.Value ? (decimal)dataReader["CANTIDAD"] : null;
            item.Utilidad = dataReader["UTILIDAD"] != System.DBNull.Value ? (decimal)dataReader["UTILIDAD"] : null;
            item.Cantidadllevate = dataReader["CANTIDADLLEVATE"] != System.DBNull.Value ? (decimal)dataReader["CANTIDADLLEVATE"] : null;
            item.Importe = dataReader["IMPORTE"] != System.DBNull.Value ? (decimal)dataReader["IMPORTE"] : null;
            item.Porcentajedescuento = dataReader["PORCENTAJEDESCUENTO"] != System.DBNull.Value ? (decimal)dataReader["PORCENTAJEDESCUENTO"] : null;
            item.Fechainicio = dataReader["FECHAINICIO"] != System.DBNull.Value ? new DateTimeOffset(((DateTime)dataReader["FECHAINICIO"]))  : null;
            item.Fechafin = dataReader["FECHAFIN"] != System.DBNull.Value ? new DateTimeOffset(((DateTime)dataReader["FECHAFIN"])) : null;
            item.Porimporte = dataReader["PORIMPORTE"] != System.DBNull.Value ? (decimal)dataReader["PORIMPORTE"] : 0;
            

            if (ProductoClave_obj != null)
                item.Productoid = ProductoClave_obj.Id;
            else
                item.Productoid = null;

            if (TipopromocionClave_obj != null)
                item.Tipopromocionid = TipopromocionClave_obj.Id;
            else
                item.Tipopromocionid = null;

            if (RangopromocionClave_obj != null)
                item.Rangopromocionid = RangopromocionClave_obj.Id;
            else
                item.Rangopromocionid = null;

            if (LineaClave_obj != null)
                item.Lineaid = LineaClave_obj.Id;
            else
                item.Lineaid = null;



            if (existItem)
                controller.Update(item);
            else
                controller.Insert(item);

            localContext.SaveChanges();

            return true;
        }

    }
}


