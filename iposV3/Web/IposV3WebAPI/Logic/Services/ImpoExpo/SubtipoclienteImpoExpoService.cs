
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
    public class SubtipoclienteImpoExpoService : BaseImpoExpoService
    {






        public override IQueryable<List<ImpoExpoValor>>? ObtainImpoExpoValores(long empresaId, long sucursalId, ApplicationDbContext localContext)
        {
            var exportValores = localContext.Subtipocliente.AsNoTracking()
                                                 .Select(x => new List<ImpoExpoValor>(){

                                                        new ImpoExpoValor("Activo", x.Activo, BoolCS.S),
                                                        new ImpoExpoValor("Clave", x.Clave, ""),
                                                        new ImpoExpoValor("Nombre", x.Nombre, ""),
                                                        new ImpoExpoValor("Descripcion", x.Descripcion, ""),
                                                        new ImpoExpoValor("Esmostrador", x.Esmostrador, BoolCN.N),

                                                 });




            return exportValores;
        }

        public override List<ImpoExpoField> ObtainImpoExpoFields()
        {
            return new List<ImpoExpoField>() {

                new ImpoExpoField("Activo","activo",1,0, NpgsqlDbType.Varchar, typeof(BoolCS)),
                new ImpoExpoField("Clave","clave",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Nombre","nombre",127,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Descripcion","descrip",254,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Esmostrador","esmostr",254,0, NpgsqlDbType.Varchar, typeof(BoolCN)),
            };
        }

        public override bool ImportFromReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               OleDbDataReader dataReader, List<ImpoExpoField> fields, ApplicationDbContext localContext)
        {

            var clave = dataReader["clave"] != System.DBNull.Value ? ((string)dataReader["clave"]).Trim() : "";


            var itemSaved = localContext.Subtipocliente
                                        .FirstOrDefault(i => i.Clave == clave);

            var item = itemSaved != null ? itemSaved : new Subtipocliente();
            var existItem = itemSaved != null;

	
          	item.Clave = dataReader["clave"] != System.DBNull.Value ? ((string)dataReader["clave"]).Trim() : ""; 
          	item.Nombre = dataReader["nombre"] != System.DBNull.Value ? ((string)dataReader["nombre"]).Trim() : ""; 
          	item.Descripcion = dataReader["descrip"] != System.DBNull.Value ? ((string)dataReader["descrip"]).Trim() : ""; 
		item.Esmostrador = dataReader["esmostr"] != System.DBNull.Value && ((string)dataReader["esmostr"]).Trim() == "S" ? BoolCN.S : BoolCN.N; 
		item.Activo = dataReader["activo"] != System.DBNull.Value && ((string)dataReader["activo"]).Trim() == "N" ? BoolCS.N : BoolCS.S; 


            if (existItem)
                localContext.Subtipocliente.Update(item);
            else
                localContext.Subtipocliente.Add(item);

            localContext.SaveChanges();

            return true;
        }


        public override bool ImportFromFirebirdReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               FbDataReader dataReader, ApplicationDbContext localContext)
        {

            var clave = dataReader["CLAVE"] != System.DBNull.Value ? ((string)dataReader["CLAVE"]).Trim() : "";


            var itemSaved = localContext.Subtipocliente.AsNoTracking()
                                        .FirstOrDefault(i => i.Clave == clave);

            var item = itemSaved != null ? itemSaved : new Subtipocliente();
            var existItem = itemSaved != null;

            item.Clave = clave;
            if (!existItem)
                item.CreadoPorId = usuarioId;

            item.ModificadoPorId = usuarioId;
            item.Activo = dataReader["ACTIVO"] != System.DBNull.Value && ((string)dataReader["ACTIVO"]).Trim() == "S" ? BoolCS.S : BoolCS.N;
            item.Nombre = dataReader["NOMBRE"] != System.DBNull.Value ? ((string)dataReader["NOMBRE"]).Trim() : "";
            item.Descripcion = dataReader["DESCRIPCION"] != System.DBNull.Value ? ((string)dataReader["DESCRIPCION"]).Trim() : "";
            //item.Esmostrador = dataReader["ESMOSTRADOR"] != System.DBNull.Value && ((string)dataReader["ESMOSTRADOR"]).Trim() == "S" ? BoolCN.S : BoolCN.N;

            if (existItem)
                localContext.Subtipocliente.Update(item);
            else
                localContext.Subtipocliente.Add(item);

            localContext.SaveChanges();

            return true;
        }

    }
}


