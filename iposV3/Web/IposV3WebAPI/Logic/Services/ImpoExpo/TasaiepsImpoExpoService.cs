
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
    public class TasaiepsImpoExpoService : BaseImpoExpoService
    {






        public override IQueryable<List<ImpoExpoValor>>? ObtainImpoExpoValores(long empresaId, long sucursalId, ApplicationDbContext localContext)
        {
            var exportValores = localContext.Tasaieps.AsNoTracking()
                                                 .Where(x => x.EmpresaId == empresaId && x.SucursalId == sucursalId)
                                                 .Select(x => new List<ImpoExpoValor>(){

                                                        new ImpoExpoValor("Activo", x.Activo, BoolCS.S),
                                                        new ImpoExpoValor("Clave", x.Clave, ""),
                                                        new ImpoExpoValor("Nombre", x.Nombre, ""),
                                                        new ImpoExpoValor("Tasa", x.Tasa, 0),
                                                        new ImpoExpoValor("Ultimafecha", x.Ultimafecha, DateTimeOffset.Now),
                                                        new ImpoExpoValor("Primerafecha", x.Primerafecha, DateTimeOffset.Now),

                                                 });




            return exportValores;
        }

        public override List<ImpoExpoField> ObtainImpoExpoFields()
        {
            return new List<ImpoExpoField>() {

                new ImpoExpoField("Activo","activo",1,0, NpgsqlDbType.Varchar, typeof(BoolCS)),
                new ImpoExpoField("Clave","clave",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Nombre","nombre",127,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Tasa","tasa",254,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Ultimafecha","ultimafecha",254,0, NpgsqlDbType.Varchar, typeof(DateTimeOffset)),
                new ImpoExpoField("Primerafecha","primerafecha",254,0, NpgsqlDbType.Varchar, typeof(DateTimeOffset)),
            };
        }

        public override bool ImportFromReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               OleDbDataReader dataReader, List<ImpoExpoField> fields, ApplicationDbContext localContext)
        {

            var clave = dataReader["clave"] != System.DBNull.Value ? ((string)dataReader["clave"]).Trim() : "";


            var itemSaved = localContext.Tasaieps.AsNoTracking()
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == clave);

            var item = itemSaved != null ? itemSaved : new Tasaieps();
            var existItem = itemSaved != null;

	
          	item.Clave = dataReader["clave"] != System.DBNull.Value ? ((string)dataReader["clave"]).Trim() : ""; 
          	item.Nombre = dataReader["nombre"] != System.DBNull.Value ? ((string)dataReader["nombre"]).Trim() : ""; 
		item.Activo = dataReader["activo"] != System.DBNull.Value && ((string)dataReader["activo"]).Trim() == "N" ? BoolCS.N : BoolCS.S;         
		item.Tasa = dataReader["tasa"] != System.DBNull.Value ? (decimal)dataReader["tasa"] : 0;         
		item.Ultimafecha = dataReader["ultimafecha"] != System.DBNull.Value ? (DateTimeOffset)dataReader["ultimafecha"] : DateTimeOffset.Now;         
		item.Primerafecha = dataReader["primerafecha"] != System.DBNull.Value ? (DateTimeOffset)dataReader["primerafecha"] : DateTimeOffset.Now; 


            if (existItem)
                localContext.Tasaieps.Update(item);
            else
                localContext.Tasaieps.Add(item);

            localContext.SaveChanges();

            return true;
        }


        public override bool ImportFromFirebirdReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               FbDataReader dataReader, ApplicationDbContext localContext)
        {

            var id = dataReader["ID"] != System.DBNull.Value ? (long)dataReader["ID"] : 0;
            var gpoImp = dataReader["GPOIMP"] != System.DBNull.Value ? ((string)dataReader["GPOIMP"]).Trim() : "";


            var itemSaved = localContext.Tasaieps
                                        .FirstOrDefault(i => i.Id == id);

            var item = itemSaved != null ? itemSaved : new Tasaieps();
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
            item.Gpoimp = dataReader["GPOIMP"] != System.DBNull.Value ? ((string)dataReader["GPOIMP"]).Trim() : null;
            item.Clave = dataReader["CLAVE"] != System.DBNull.Value ? ((string)dataReader["CLAVE"]).Trim() : "";
            item.Ultimafecha = dataReader["ULTIMAFECHA"] != System.DBNull.Value ? new DateTimeOffset(DateTime.SpecifyKind(((DateTime)dataReader["ULTIMAFECHA"]), DateTimeKind.Local)) : DateTimeOffset.Now;         
		    item.Primerafecha = dataReader["PRIMERAFECHA"] != System.DBNull.Value ? new DateTimeOffset(DateTime.SpecifyKind(((DateTime)dataReader["PRIMERAFECHA"]), DateTimeKind.Local)) : DateTimeOffset.Now; 


            if (existItem)
                localContext.Tasaieps.Update(item);
            else
                localContext.Tasaieps.Add(item);

            localContext.SaveChanges();

            return true;
        }

    }
}


