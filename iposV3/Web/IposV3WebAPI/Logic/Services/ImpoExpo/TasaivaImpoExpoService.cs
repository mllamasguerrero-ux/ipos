
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
    public class TasaivaImpoExpoService : BaseImpoExpoService
    {






        public override IQueryable<List<ImpoExpoValor>>? ObtainImpoExpoValores(long empresaId, long sucursalId, ApplicationDbContext localContext)
        {
            var exportValores = localContext.Tasaiva.AsNoTracking()
                                                 .Select(x => new List<ImpoExpoValor>(){

                                                        new ImpoExpoValor("Activo", x.Activo, BoolCS.S),
                                                        new ImpoExpoValor("Clave", x.Clave, ""),
                                                        new ImpoExpoValor("Nombre", x.Nombre, ""),
                                                        new ImpoExpoValor("Tasa", x.Tasa, 0),
                                                        new ImpoExpoValor("Fechainicia", x.Fechainicia != null ? x.Fechainicia!.Value.LocalDateTime : null, DateTime.Now),

                                                 });




            return exportValores;
        }

        public override List<ImpoExpoField> ObtainImpoExpoFields()
        {
            return new List<ImpoExpoField>() {

                new ImpoExpoField("Activo","activo",1,0, NpgsqlDbType.Varchar, typeof(BoolCS)),
                new ImpoExpoField("Clave","clave",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Nombre","nombre",127,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Tasa","tasa",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Fechainicia","fechaini",8,0, NpgsqlDbType.Date, typeof(DateTimeOffset)),
            };
        }

        public override bool ImportFromReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               OleDbDataReader dataReader, List<ImpoExpoField> fields, ApplicationDbContext localContext)
        {

            var clave = dataReader["clave"] != System.DBNull.Value ? ((string)dataReader["clave"]).Trim() : "";


            var itemSaved = localContext.Tasaiva
                                        .FirstOrDefault(i => i.Clave == clave);

            var item = itemSaved != null ? itemSaved : new Tasaiva();
            var existItem = itemSaved != null;

	
          	item.Clave = dataReader["clave"] != System.DBNull.Value ? ((string)dataReader["clave"]).Trim() : ""; 
          	item.Nombre = dataReader["nombre"] != System.DBNull.Value ? ((string)dataReader["nombre"]).Trim() : ""; 
		item.Activo = dataReader["activo"] != System.DBNull.Value && ((string)dataReader["activo"]).Trim() == "N" ? BoolCS.N : BoolCS.S;         
		item.Tasa = dataReader["tasa"] != System.DBNull.Value ? (decimal)dataReader["tasa"] : 0;         
		item.Fechainicia = dataReader["fechaini"] != System.DBNull.Value ? (new DateTimeOffset((DateTime)dataReader["fechaini"])).ToUniversalTime() : null; 


            if (existItem)
                localContext.Tasaiva.Update(item);
            else
                localContext.Tasaiva.Add(item);

            localContext.SaveChanges();

            return true;
        }


        public override bool ImportFromFirebirdReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               FbDataReader dataReader, ApplicationDbContext localContext)
        {

            var id = dataReader["ID"] != System.DBNull.Value ? (long)dataReader["ID"] : 0;


            var itemSaved = localContext.Tasaiva
                                        .FirstOrDefault(i => i.Id == id);

            var item = itemSaved != null ? itemSaved : new Tasaiva();
            var existItem = itemSaved != null;

            item.Id = id;
            if (!existItem)
                item.CreadoPorId = usuarioId;

            

            item.EmpresaId = empresaId;
            item.SucursalId = sucursalId;
            item.ModificadoPorId = usuarioId;
            item.Activo = dataReader["ACTIVO"] != System.DBNull.Value && ((string)dataReader["ACTIVO"]).Trim() == "S" ? BoolCS.S : BoolCS.N;
            item.Nombre = dataReader["NOMBRE"] != System.DBNull.Value ? ((string)dataReader["NOMBRE"]).Trim() : "";
            item.Tasa = dataReader["TASA"] != System.DBNull.Value ? (decimal)dataReader["TASA"] : 0M;
            item.Fechainicia = dataReader["FECHAINICIA"] != System.DBNull.Value ? new DateTimeOffset(DateTime.SpecifyKind(((DateTime)dataReader["FECHAINICIA"]), DateTimeKind.Local)) : DateTimeOffset.Now;
            item.Clave = dataReader["CLAVE"] != System.DBNull.Value ? ((string)dataReader["CLAVE"]).Trim() : "";

            if (existItem)
                localContext.Tasaiva.Update(item);
            else
                localContext.Tasaiva.Add(item);

            localContext.SaveChanges();

            return true;
        }

    }
}


