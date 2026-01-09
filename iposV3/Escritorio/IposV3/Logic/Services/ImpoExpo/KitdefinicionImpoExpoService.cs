
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
using static IposV3.Services.BaseImpoExpoService;

using Z.EntityFramework.Plus;
using FirebirdSql.Data.FirebirdClient;
using Controllers.Controller;
using BindingModels;
using System.Data;

namespace IposV3.Services
{



    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public class KitdefinicionImpoExpoService : BaseImpoExpoService
    {






        public override IQueryable<List<ImpoExpoValor>>? ObtainImpoExpoValores(long empresaId, long sucursalId, ApplicationDbContext localContext)
        {
            var exportValores = localContext.Kitdefinicion.AsNoTracking()
                                            .Include(k => k.Productokit)
                                            .Include(k => k.Productoparte)
                                                 .Where(x => x.EmpresaId == empresaId && x.SucursalId == sucursalId)
                                                 .Select(x => new List<ImpoExpoValor>(){

                                                        new ImpoExpoValor("Activo", x.Activo, BoolCS.S),
                                                        new ImpoExpoValor("Productokitclave", x.Productokit!.Clave, ""),
                                                        new ImpoExpoValor("Productokitnombre", x.Productokit!.Nombre, ""),
                                                        new ImpoExpoValor("Productoparteclave", x.Productoparte!.Clave, ""),
                                                        new ImpoExpoValor("Productopartenombre", x.Productoparte!.Nombre, ""),
                                                        new ImpoExpoValor("Cantidadparte", x.Cantidadparte, 0m),
                                                        new ImpoExpoValor("Costoparte", x.Costoparte, 0m),

                                                 });




            return exportValores;
        }

        public override List<ImpoExpoField> ObtainImpoExpoFields()
        {
            return new List<ImpoExpoField>() {

                new ImpoExpoField("Activo","activo",1,0, NpgsqlDbType.Varchar, typeof(BoolCS)),
                new ImpoExpoField("Productokitclave","pkclave",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Productokitnombre","pknombre",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Productoparteclave","ppclave",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Productopartenombre","ppnombre",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Cantidadparte","cantparte",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Costoparte","costoparte",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
            };
        }

        


    public override void ImportFromDbf(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                      string fileName, string pathDB, List<ImpoExpoField> fields,
                                      ImportFromReaderDelegate importFromReaderDelegate, ApplicationDbContext localContext)
    {

        string selectSql = "select * from " + fileName;

        OleDbConnection con = new OleDbConnection(GetConnection(pathDB));

        try
        {
            OleDbCommand cmd = new OleDbCommand();

            cmd.Connection = con;

            con.Open();

            cmd.CommandText = selectSql;


            List<string> productoKitClaves = new List<string>();

            using (var dataReader = cmd.ExecuteReader())
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {

                            string pkClave = dataReader["pkclave"] != System.DBNull.Value ? ((string)dataReader["pkclave"]).Trim() : "";
                            if(!productoKitClaves.Contains( pkClave))
                            {
                                productoKitClaves.Add(pkClave);

                                var kitDefiniciones = localContext.Kitdefinicion.Where(k => k.EmpresaId == empresaId && k.SucursalId == sucursalId &&
                                                                      k.Productokit!.Clave == pkClave).ToList();

                                kitDefiniciones.ForEach(a => a.Activo = BoolCS.N);

                                localContext.SaveChanges();

                            }


                            importFromReaderDelegate(empresaId, sucursalId, usuarioId, ref doctoId, tipoDoctoId, 
                                                     dataReader, fields, localContext);


                    }



                        var kitDefinicionesAEliminar = localContext.Kitdefinicion.Where(k => k.EmpresaId == empresaId && k.SucursalId == sucursalId &&
                                                              k.Activo == BoolCS.N).ToList();

                        foreach( var kit in kitDefinicionesAEliminar)
                        {
                            localContext.Kitdefinicion.Remove(kit);
                        }

                        localContext.SaveChanges();


                    }
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw ;
        }
        finally
        {
            con.Close();
        }



    }


    public override bool ImportFromReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               OleDbDataReader dataReader, List<ImpoExpoField> fields, ApplicationDbContext localContext)
        {

            var productokitclave = dataReader["pkclave"] != System.DBNull.Value ? ((string)dataReader["pkclave"]).Trim() : "";
            var productoparteclave = dataReader["ppclave"] != System.DBNull.Value ? ((string)dataReader["ppclave"]).Trim() : "";


            var bufferStr = "";

            var itemSaved = localContext.Kitdefinicion
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Productokit!.Clave == productokitclave && i.Productoparte!.Clave == productoparteclave);

            var item = itemSaved != null ? itemSaved : new Kitdefinicion();
            var existItem =  itemSaved != null;

	
          	item.Productokitclave = dataReader["pkclave"] != System.DBNull.Value ? ((string)dataReader["pkclave"]).Trim() : ""; 
          	item.Productoparteclave = dataReader["ppclave"] != System.DBNull.Value ? ((string)dataReader["ppclave"]).Trim() : "";


            bufferStr = dataReader["pkclave"] != System.DBNull.Value ? ((string)dataReader["pkclave"]).Trim() : "";
            var productokit = bufferStr == "" ? null : localContext.Producto.AsNoTracking()
                                                                                  .FirstOrDefault(x => x.EmpresaId == empresaId &&
                                                                                                       x.SucursalId == sucursalId &&
                                                                                                       x.Clave == bufferStr);
            item.Productokitid = productokit?.Id;


            bufferStr = dataReader["ppclave"] != System.DBNull.Value ? ((string)dataReader["ppclave"]).Trim() : "";
            var productoparte = bufferStr == "" ? null : localContext.Producto.AsNoTracking()
                                                                                  .FirstOrDefault(x => x.EmpresaId == empresaId &&
                                                                                                       x.SucursalId == sucursalId &&
                                                                                                       x.Clave == bufferStr);
            item.Productoparteid = productoparte?.Id;


            item.Activo = dataReader["activo"] != System.DBNull.Value && ((string)dataReader["activo"]).Trim() == "N" ? BoolCS.N : BoolCS.S;         
		    item.Cantidadparte = dataReader["cantparte"] != System.DBNull.Value ? (decimal)dataReader["cantparte"] : 0;         
		    item.Costoparte = dataReader["costoparte"] != System.DBNull.Value ? (decimal)dataReader["costoparte"] : 0;


            if (existItem)
                localContext.Kitdefinicion.Update(item);
            else
                localContext.Kitdefinicion.Add(item);

            localContext.SaveChanges();

            return true;
        }





        public void ImportarDeTablaFirebird(
                          long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                          string fbCadenaConexion,
                          string? nombreTabla, string? queryPersonalizada,
                           ApplicationDbContext localContext, KitdefinicionController kitdefinicionController)
        {
            /**/
            FbDataReader? dr = null;
            FbConnection? pcn = null;

            var utf8 = new UTF8Encoding();

            try
            {

                System.Collections.ArrayList parts = new ArrayList();

                String CmdTxt = @"
select
R.ACTIVO, R.CREADO, R.MODIFICADO,
R.PRODUCTOKITCLAVE,
productoparte.clave PRODUCTOPARTECLAVE ,
SUM(COALESCE(R.CANTIDADPARTE,0)) CANTIDADPARTE,
SUM(COALESCE(R.COSTOPARTE,0)) COSTOPARTE

FROM
(
select
productoid ,
productoid produtokitid,
ACTIVO, CREADO, MODIFICADO,
PRODUCTOCLAVE PRODUCTOKITCLAVE,
case when coalesce(cantidadparteN10,0) > 0 then  productoparteidN10
     when coalesce(cantidadparteN9,0) > 0 then  productoparteidN9 
     when coalesce(cantidadparteN8,0) > 0 then  productoparteidN8
     when coalesce(cantidadparteN7,0) > 0 then  productoparteidN7
     when coalesce(cantidadparteN6,0) > 0 then  productoparteidN6
     when coalesce(cantidadparteN5,0) > 0 then  productoparteidN5
     when coalesce(cantidadparteN4,0) > 0 then  productoparteidN4
     when coalesce(cantidadparteN3,0) > 0 then  productoparteidN3
     when coalesce(cantidadparteN2,0) > 0 then  productoparteidN2
     when coalesce(cantidadparteN1,0) > 0 then  productoparteidN1
     else productoparteidN1  end productoparteid,
case when coalesce(cantidadparteN10,0) > 0 then  cast(coalesce(cantidadparteN10,0) as d_cantidad)
     when coalesce(cantidadparteN9,0) > 0 then  cast(coalesce(cantidadparteN9,0) as d_cantidad)
     when coalesce(cantidadparteN8,0) > 0 then  cast(coalesce(cantidadparteN8,0) as d_cantidad)
     when coalesce(cantidadparteN7,0) > 0 then  cast(coalesce(cantidadparteN7,0) as d_cantidad)
     when coalesce(cantidadparteN6,0) > 0 then  cast(coalesce(cantidadparteN6,0) as d_cantidad)
     when coalesce(cantidadparteN5,0) > 0 then  cast(coalesce(cantidadparteN5,0) as d_cantidad)
     when coalesce(cantidadparteN4,0) > 0 then  cast(coalesce(cantidadparteN4,0) as d_cantidad)
     when coalesce(cantidadparteN3,0) > 0 then  cast(coalesce(cantidadparteN3,0) as d_cantidad)
     when coalesce(cantidadparteN2,0) > 0 then  cast(coalesce(cantidadparteN2,0) as d_cantidad)
     when coalesce(cantidadparteN1,0) > 0 then  cast(coalesce(cantidadparteN1,0) as d_cantidad)
     else cast(coalesce(cantidadparteN1,0) as d_cantidad)  end cantidadparte ,
case when coalesce(costoparteN10,0) > 0 then  cast(coalesce(costoparteN10,0) as d_precio)
     when coalesce(costoparteN9,0) > 0 then  cast(coalesce(costoparteN9,0) as d_precio)
     when coalesce(costoparteN8,0) > 0 then  cast(coalesce(costoparteN8,0) as d_precio)
     when coalesce(costoparteN7,0) > 0 then  cast(coalesce(costoparteN7,0) as d_precio)
     when coalesce(costoparteN6,0) > 0 then  cast(coalesce(costoparteN6,0) as d_precio)
     when coalesce(costoparteN5,0) > 0 then  cast(coalesce(costoparteN5,0) as d_precio)
     when coalesce(costoparteN4,0) > 0 then  cast(coalesce(costoparteN4,0) as d_precio)
     when coalesce(costoparteN3,0) > 0 then  cast(coalesce(costoparteN3,0) as d_precio)
     when coalesce(costoparteN2,0) > 0 then  cast(coalesce(costoparteN2,0) as d_precio)
     when coalesce(costoparteN1,0) > 0 then  cast(coalesce(costoparteN1,0) as d_precio)
     else cast(coalesce(costoparteN1,0) as d_precio)  end costoparte

     from
     (



select producto.id productoid,
producto.ACTIVO,
producto.CREADO,
producto.MODIFICADO,
producto.clave PRODUCTOCLAVE,
KitN1.productokitid productokitidN1, KitN1.productoparteid productoparteidN1,
        KitN1.cantidadparte cantidadparteN1,
KitN2.productokitid productokitidN2, KitN2.productoparteid productoparteidN2,
        coalesce(KitN1.cantidadparte,0) * coalesce(KitN2.cantidadparte,0)  cantidadparteN2,
KitN3.productokitid productokitidN3, KitN3.productoparteid productoparteidN3,
        coalesce(KitN1.cantidadparte,0) * coalesce(KitN2.cantidadparte,0) *
        coalesce(KitN3.cantidadparte,0)    cantidadparteN3,
KitN4.productokitid productokitidN4, KitN4.productoparteid productoparteidN4,
        coalesce(KitN1.cantidadparte,0) * coalesce(KitN2.cantidadparte,0) *
        coalesce(KitN3.cantidadparte,0) * coalesce(KitN4.cantidadparte,0)  cantidadparteN4,
KitN5.productokitid productokitidN5, KitN5.productoparteid productoparteidN5,
        coalesce(KitN1.cantidadparte,0) * coalesce(KitN2.cantidadparte,0) *
        coalesce(KitN3.cantidadparte,0) * coalesce(KitN4.cantidadparte,0) *
        coalesce(KitN5.cantidadparte,0)  cantidadparteN5,
KitN6.productokitid productokitidN6, KitN6.productoparteid productoparteidN6,
        coalesce(KitN1.cantidadparte,0) * coalesce(KitN2.cantidadparte,0) *
        coalesce(KitN3.cantidadparte,0) * coalesce(KitN4.cantidadparte,0) *
        coalesce(KitN5.cantidadparte,0) * coalesce(KitN6.cantidadparte,0)  cantidadparteN6,
KitN7.productokitid productokitidN7, KitN7.productoparteid productoparteidN7,
        coalesce(KitN1.cantidadparte,0) * coalesce(KitN2.cantidadparte,0) *
        coalesce(KitN3.cantidadparte,0) * coalesce(KitN4.cantidadparte,0) *
        coalesce(KitN5.cantidadparte,0) * coalesce(KitN6.cantidadparte,0) *
        coalesce(KitN7.cantidadparte,0)  cantidadparteN7,
KitN8.productokitid productokitidN8, KitN8.productoparteid productoparteidN8,
        coalesce(KitN1.cantidadparte,0) * coalesce(KitN2.cantidadparte,0) *
        coalesce(KitN3.cantidadparte,0) * coalesce(KitN4.cantidadparte,0) *
        coalesce(KitN5.cantidadparte,0) * coalesce(KitN6.cantidadparte,0) *
        coalesce(KitN7.cantidadparte,0) * coalesce(KitN8.cantidadparte,0) cantidadparteN8,
KitN9.productokitid productokitidN9, KitN9.productoparteid productoparteidN9,
        coalesce(KitN1.cantidadparte,0) * coalesce(KitN2.cantidadparte,0) *
        coalesce(KitN3.cantidadparte,0) * coalesce(KitN4.cantidadparte,0) *
        coalesce(KitN5.cantidadparte,0) * coalesce(KitN6.cantidadparte,0) *
        coalesce(KitN7.cantidadparte,0) * coalesce(KitN8.cantidadparte,0) *
        coalesce(KitN9.cantidadparte,0)  cantidadparteN9 ,
KitN10.productokitid productokitidN10, KitN10.productoparteid productoparteidN10,
        coalesce(KitN1.cantidadparte,0) * coalesce(KitN2.cantidadparte,0) *
        coalesce(KitN3.cantidadparte,0) * coalesce(KitN4.cantidadparte,0) *
        coalesce(KitN5.cantidadparte,0) * coalesce(KitN6.cantidadparte,0) *
        coalesce(KitN7.cantidadparte,0) * coalesce(KitN8.cantidadparte,0) *
        coalesce(KitN9.cantidadparte,0) * coalesce(KitN10.cantidadparte,0) cantidadparteN10  ,


        KitN1.costoparte costoparteN1,
        coalesce(KitN1.cantidadparte,0) * coalesce(KitN2.costoparte,0)  costoparteN2,
        coalesce(KitN1.cantidadparte,0) * coalesce(KitN2.cantidadparte,0) *
        coalesce(KitN3.costoparte,0)    costoparteN3,
        coalesce(KitN1.cantidadparte,0) * coalesce(KitN2.cantidadparte,0) *
        coalesce(KitN3.cantidadparte,0) * coalesce(KitN4.costoparte,0)  costoparteN4,
        coalesce(KitN1.cantidadparte,0) * coalesce(KitN2.cantidadparte,0) *
        coalesce(KitN3.cantidadparte,0) * coalesce(KitN4.cantidadparte,0) *
        coalesce(KitN5.costoparte,0)  costoparteN5,
        coalesce(KitN1.cantidadparte,0) * coalesce(KitN2.cantidadparte,0) *
        coalesce(KitN3.cantidadparte,0) * coalesce(KitN4.cantidadparte,0) *
        coalesce(KitN5.cantidadparte,0) * coalesce(KitN6.costoparte,0)  costoparteN6,
        coalesce(KitN1.cantidadparte,0) * coalesce(KitN2.cantidadparte,0) *
        coalesce(KitN3.cantidadparte,0) * coalesce(KitN4.cantidadparte,0) *
        coalesce(KitN5.cantidadparte,0) * coalesce(KitN6.cantidadparte,0) *
        coalesce(KitN7.costoparte,0)  costoparteN7,
        coalesce(KitN1.cantidadparte,0) * coalesce(KitN2.cantidadparte,0) *
        coalesce(KitN3.cantidadparte,0) * coalesce(KitN4.cantidadparte,0) *
        coalesce(KitN5.cantidadparte,0) * coalesce(KitN6.cantidadparte,0) *
        coalesce(KitN7.cantidadparte,0) * coalesce(KitN8.costoparte,0) costoparteN8,
        coalesce(KitN1.cantidadparte,0) * coalesce(KitN2.cantidadparte,0) *
        coalesce(KitN3.cantidadparte,0) * coalesce(KitN4.cantidadparte,0) *
        coalesce(KitN5.cantidadparte,0) * coalesce(KitN6.cantidadparte,0) *
        coalesce(KitN7.cantidadparte,0) * coalesce(KitN8.cantidadparte,0) *
        coalesce(KitN9.costoparte,0)  costoparteN9 ,
        coalesce(KitN1.cantidadparte,0) * coalesce(KitN2.cantidadparte,0) *
        coalesce(KitN3.cantidadparte,0) * coalesce(KitN4.cantidadparte,0) *
        coalesce(KitN5.cantidadparte,0) * coalesce(KitN6.cantidadparte,0) *
        coalesce(KitN7.cantidadparte,0) * coalesce(KitN8.cantidadparte,0) *
        coalesce(KitN9.cantidadparte,0) * coalesce(KitN10.costoparte,0) costoparteN10
 from producto
 left join kitdefinicion KitN1 on KitN1.productokitid = producto.id  
 left join kitdefinicion KitN2 on KitN2.productokitid = KitN1.productoparteid  
 left join kitdefinicion KitN3 on KitN3.productokitid = KitN2.productoparteid
 left join kitdefinicion KitN4 on KitN4.productokitid = KitN3.productoparteid
 left join kitdefinicion KitN5 on KitN5.productokitid = KitN4.productoparteid
 left join kitdefinicion KitN6 on KitN6.productokitid = KitN5.productoparteid
 left join kitdefinicion KitN7 on KitN7.productokitid = KitN6.productoparteid
 left join kitdefinicion KitN8 on KitN8.productokitid = KitN7.productoparteid
 left join kitdefinicion KitN9 on KitN9.productokitid = KitN8.productoparteid
 left join kitdefinicion KitN10 on KitN10.productokitid = KitN9.productoparteid
 where producto.eskit = 'S'

 ) q
) r LEFT JOIN PRODUCTO PRODUCTOPARTE ON PRODUCTOPARTE.ID = r.productoparteid

GROUP BY 
R.ACTIVO, R.CREADO, R.MODIFICADO,
R.PRODUCTOKITCLAVE,
productoparte.clave
order by r.PRODUCTOKITCLAVE";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                dr = FbSqlHelper.ExecuteReader(fbCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);

                string? prevProductoKitClave = null;
                string? bufferProductoKitClave = null;

                while (dr.Read())
                {

                    bufferProductoKitClave = dr["PRODUCTOKITCLAVE"] != System.DBNull.Value ? ((string)dr["PRODUCTOKITCLAVE"]).Trim() : null;

                    

                    ImportFromFirebirdReader(empresaId, sucursalId, usuarioId, ref doctoId, tipoDoctoId,
                                             dr, localContext, kitdefinicionController,
                                             (bufferProductoKitClave != null && bufferProductoKitClave != prevProductoKitClave));
                    prevProductoKitClave = bufferProductoKitClave;

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
                                               FbDataReader dataReader, ApplicationDbContext localContext, KitdefinicionController controller,
                                               bool cleanKitAnterior)
        {

            //var clave = dataReader["clave"] != System.DBNull.Value ? ((string)dataReader["clave"]).Trim() : "";


            var ProductokitClave = dataReader["PRODUCTOKITCLAVE"] != System.DBNull.Value ? ((string)dataReader["PRODUCTOKITCLAVE"]).Trim() : "";

            var ProductoparteClave = dataReader["PRODUCTOPARTECLAVE"] != System.DBNull.Value ? ((string)dataReader["PRODUCTOPARTECLAVE"]).Trim() : "";


            if(cleanKitAnterior)
            {
                var lstCurrentProductoKitList = localContext.Kitdefinicion
                                                   .Include(k => k.Productokit)
                                                   .Where(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Productokit!.Clave == ProductokitClave)
                                                   .ToList();
                foreach(var productoKit in lstCurrentProductoKitList)
                {
                    localContext.Kitdefinicion.Remove(productoKit);
                }
                localContext.SaveChanges();
            }

            //var itemSaved = localContext.Kitdefinicion.AsNoTracking()
            //                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
            //                                                 i.Productokitclave == clave);


            var ProductokitClave_obj = localContext.Producto
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == ProductokitClave);

            var ProductoparteClave_obj = localContext.Producto.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == ProductoparteClave);


            //var item = itemSaved != null ? new KitdefinicionBindingModel(itemSaved) : new KitdefinicionBindingModel();
            //var existItem = itemSaved != null;
            var item = new KitdefinicionBindingModel();

            item.EmpresaId = empresaId;
            item.SucursalId = sucursalId;

            item.Activo = dataReader["ACTIVO"] != System.DBNull.Value && ((string)dataReader["ACTIVO"]).Trim() == "N" ? BoolCS.N : BoolCS.S;
            item.Creado = dataReader["CREADO"] != System.DBNull.Value ? new DateTimeOffset(((DateTime)dataReader["CREADO"])) : DateTime.UtcNow;
            item.Modificado = dataReader["MODIFICADO"] != System.DBNull.Value ? new DateTimeOffset(((DateTime)dataReader["MODIFICADO"])) : DateTime.UtcNow;
            item.Cantidadparte = dataReader["CANTIDADPARTE"] != System.DBNull.Value ? (decimal)dataReader["CANTIDADPARTE"] : 0;
            item.Costoparte = dataReader["COSTOPARTE"] != System.DBNull.Value ? (decimal)dataReader["COSTOPARTE"] : 0;


            if (ProductokitClave_obj != null)
            {
                item.Productokitid = ProductokitClave_obj.Id;
                item.Productokitclave = ProductokitClave_obj.Clave;
            }
            else
                item.Productokitid = null;

            if (ProductoparteClave_obj != null)
            {
                item.Productoparteid = ProductoparteClave_obj.Id;
                item.Productoparteclave = ProductoparteClave_obj.Clave;
            }
            else
                item.Productoparteid = null;



            //if (existItem)
            //    controller.Update(item);
            //else
            //    controller.Insert(item);


            IposV3.Services.ImpuestoKitDefinicion? impuestosKit = null;
            controller.InsertYModificarImpuestosSiAplica(item, out impuestosKit);

            if (impuestosKit != null)
            {
                ProductokitClave_obj!.Iepsimpuesto = impuestosKit.Ieps;
                ProductokitClave_obj!.Iepsimpuesto = impuestosKit.Ieps;
            }

            localContext.SaveChanges();

            return true;
        }


    }
}


