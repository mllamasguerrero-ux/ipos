
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

namespace IposV3.Services
{


    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public class TipodiferenciainventarioImpoExpoService : BaseImpoExpoService
    {






        public override IQueryable<List<ImpoExpoValor>>? ObtainImpoExpoValores(long empresaId, long sucursalId, ApplicationDbContext localContext)
        {
            var exportValores = localContext.Tipodiferenciainventario.AsNoTracking()
                                                 .Include(x => x.Grupodiferenciainventario)
                                                 .Select(x => new List<ImpoExpoValor>(){

                                                        new ImpoExpoValor("Activo", x.Activo, BoolCS.S),
                                                        new ImpoExpoValor("Clave", x.Clave, ""),
                                                        new ImpoExpoValor("Nombre", x.Nombre, ""),
                                                        new ImpoExpoValor("Descripcion", x.Descripcion, ""),
                                                        new ImpoExpoValor("Memo", x.Memo, ""),
                                                        new ImpoExpoValor("GrupodiferenciainventarioClave", x.Grupodiferenciainventario!.Clave, ""),
                                                        new ImpoExpoValor("GrupodiferenciainventarioNombre", x.Grupodiferenciainventario.Nombre, ""),

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
                new ImpoExpoField("GrupodiferenciainventarioClave","gpoclave",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("GrupodiferenciainventarioNombre","gponombre",128,0, NpgsqlDbType.Char, typeof(string)),
            };
        }

        public override bool ImportFromReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               OleDbDataReader dataReader, List<ImpoExpoField> fields, ApplicationDbContext localContext)
        {

            var clave = dataReader["clave"] != System.DBNull.Value ? ((string)dataReader["clave"]).Trim() : "";

            var bufferStr = "";

            var itemSaved = localContext.Tipodiferenciainventario
                                        .FirstOrDefault(i => i.Clave == clave);

            var item = itemSaved != null ? itemSaved : new Tipodiferenciainventario();
            var existItem = itemSaved != null;

	
          	item.Clave = dataReader["clave"] != System.DBNull.Value ? ((string)dataReader["clave"]).Trim() : ""; 
          	item.Nombre = dataReader["nombre"] != System.DBNull.Value ? ((string)dataReader["nombre"]).Trim() : ""; 
          	item.Descripcion = dataReader["descr"] != System.DBNull.Value ? ((string)dataReader["descr"]).Trim() : ""; 
          	item.Memo = dataReader["memo"] != System.DBNull.Value ? ((string)dataReader["memo"]).Trim() : "";



            bufferStr = dataReader["gpoclave"] != System.DBNull.Value ? ((string)dataReader["gpoclave"]).Trim() : "";
            var grupodiferenciainventario = bufferStr == "" ? null : localContext.Grupodiferenciainventario.AsNoTracking()
                                                                                  .FirstOrDefault(x => x.Clave == bufferStr);
            item.Grupodiferenciainventarioid = grupodiferenciainventario?.Id;

            
            item.Activo = dataReader["activo"] != System.DBNull.Value && ((string)dataReader["activo"]).Trim() == "N" ? BoolCS.N : BoolCS.S; 


            if (existItem)
                localContext.Tipodiferenciainventario.Update(item);
            else
                localContext.Tipodiferenciainventario.Add(item);

            localContext.SaveChanges();

            return true;
        }


        public override bool ImportFromFirebirdReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               FbDataReader dataReader, ApplicationDbContext localContext)
        {

            var clave = dataReader["CLAVE"] != System.DBNull.Value ? ((string)dataReader["CLAVE"]).Trim() : "";
            long id = dataReader["ID"] != System.DBNull.Value ? ((long)dataReader["ID"]) : -1;

            var grupodiferenciainventarioClave = dataReader["GRUPODIFERENCIAINVENTARIOCLAVE"] != System.DBNull.Value ? ((string)dataReader["GRUPODIFERENCIAINVENTARIOCLAVE"]).Trim() : "";


            var itemSaved = localContext.Tipodiferenciainventario.AsNoTracking()
                                        .FirstOrDefault(i => i.Id == id);

            var grupodiferenciainventario = localContext.Sat_tipopermiso.AsNoTracking()
                                        .FirstOrDefault(i => i.Clave == grupodiferenciainventarioClave);


            var item = itemSaved != null ? itemSaved : new Tipodiferenciainventario();
            var existItem = itemSaved != null;

            item.Clave = clave;
            if (!existItem)
                item.CreadoPorId = usuarioId;

            item.ModificadoPorId = usuarioId;
            item.Id = id;
            item.Activo = dataReader["ACTIVO"] != System.DBNull.Value && ((string)dataReader["ACTIVO"]).Trim() == "S" ? BoolCS.S : BoolCS.N;
            item.Nombre = dataReader["NOMBRE"] != System.DBNull.Value ? ((string)dataReader["NOMBRE"]).Trim() : "";
            item.Descripcion = dataReader["DESCRIPCION"] != System.DBNull.Value ? ((string)dataReader["DESCRIPCION"]).Trim() : "";


            if (grupodiferenciainventario != null)
                item.Grupodiferenciainventarioid = grupodiferenciainventario.Id;
            else
                item.Grupodiferenciainventarioid = null;

            if (existItem)
                localContext.Tipodiferenciainventario.Update(item);
            else
                localContext.Tipodiferenciainventario.Add(item);

            localContext.SaveChanges();

            return true;
        }

    }
}


