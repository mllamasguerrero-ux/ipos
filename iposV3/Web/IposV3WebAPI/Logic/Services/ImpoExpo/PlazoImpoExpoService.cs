
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
    public class PlazoImpoExpoService : BaseImpoExpoService
    {






        public override IQueryable<List<ImpoExpoValor>>? ObtainImpoExpoValores(long empresaId, long sucursalId, ApplicationDbContext localContext)
        {
            var exportValores = localContext.Plazo.AsNoTracking()
                                                 .Where(x => x.EmpresaId == empresaId && x.SucursalId == sucursalId)
                                                 .Select(x => new List<ImpoExpoValor>(){

                                                        new ImpoExpoValor("Activo", x.Activo, BoolCS.S),
                                                        new ImpoExpoValor("Clave", x.Clave, ""),
                                                        new ImpoExpoValor("Nombre", x.Nombre, ""),
                                                        new ImpoExpoValor("Comisionista", x.Comisionista, BoolCN.N),
                                                        new ImpoExpoValor("Leyenda", x.Leyenda, ""),
                                                        new ImpoExpoValor("Dias", x.Dias, ""),

                                                 });




            return exportValores;
        }

        public override List<ImpoExpoField> ObtainImpoExpoFields()
        {
            return new List<ImpoExpoField>() {

                new ImpoExpoField("Activo","activo",1,0, NpgsqlDbType.Varchar, typeof(BoolCS)),
                new ImpoExpoField("Clave","clave",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Nombre","nombre",127,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Comisionista","comista",254,0, NpgsqlDbType.Varchar, typeof(BoolCN)),
                new ImpoExpoField("Leyenda","leyenda",254,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Dias","dias",254,0, NpgsqlDbType.Integer, typeof(int)),
            };
        }

        public override bool ImportFromReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               OleDbDataReader dataReader, List<ImpoExpoField> fields, ApplicationDbContext localContext)
        {

            var clave = dataReader["clave"] != System.DBNull.Value ? ((string)dataReader["clave"]).Trim() : "";


            var itemSaved = localContext.Plazo
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == clave);

            var item = itemSaved != null ? itemSaved : new Plazo();
            var existItem = itemSaved != null;

	
          	item.Clave = dataReader["clave"] != System.DBNull.Value ? ((string)dataReader["clave"]).Trim() : ""; 
          	item.Nombre = dataReader["nombre"] != System.DBNull.Value ? ((string)dataReader["nombre"]).Trim() : ""; 
          	item.Leyenda = dataReader["leyenda"] != System.DBNull.Value ? ((string)dataReader["leyenda"]).Trim() : ""; 
		item.Comisionista = dataReader["comista"] != System.DBNull.Value && ((string)dataReader["comista"]).Trim() == "S" ? BoolCN.S : BoolCN.N; 
		item.Activo = dataReader["activo"] != System.DBNull.Value && ((string)dataReader["activo"]).Trim() == "N" ? BoolCS.N : BoolCS.S; 
		item.Dias = dataReader["dias"] != System.DBNull.Value ? int.Parse(dataReader["dias"].ToString()!) : (int?)null; 


            if (existItem)
                localContext.Plazo.Update(item);
            else
                localContext.Plazo.Add(item);

            localContext.SaveChanges();

            return true;
        }


        public override bool ImportFromFirebirdReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               FbDataReader dataReader, ApplicationDbContext localContext)
        {

            var clave = dataReader["CLAVE"] != System.DBNull.Value ? ((string)dataReader["CLAVE"]).Trim() : "";

            var almacenClave = dataReader["ALMACENCLAVE"] != System.DBNull.Value ? ((string)dataReader["ALMACENCLAVE"]).Trim() : "";


            var itemSaved = localContext.Plazo.AsNoTracking()
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == clave);

            var almacen = localContext.Almacen.AsNoTracking()
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == almacenClave);

            var item = itemSaved != null ? itemSaved : new Plazo();
            var existItem = itemSaved != null;

            item.Clave = clave;
            if (!existItem)
                item.CreadoPorId = usuarioId;

            item.EmpresaId = empresaId;
            item.SucursalId = sucursalId;
            item.ModificadoPorId = usuarioId;
            item.Activo = dataReader["ACTIVO"] != System.DBNull.Value && ((string)dataReader["ACTIVO"]).Trim() == "S" ? BoolCS.S : BoolCS.N;
            item.Nombre = dataReader["NOMBRE"] != System.DBNull.Value ? ((string)dataReader["NOMBRE"]).Trim() : "";


            item.Leyenda = dataReader["LEYENDA"] != System.DBNull.Value ? ((string)dataReader["LEYENDA"]).Trim() : "";
            item.Comisionista = dataReader["COMISIONISTA"] != System.DBNull.Value && ((string)dataReader["COMISIONISTA"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Dias = dataReader["DIAS"] != System.DBNull.Value ? int.Parse(dataReader["DIAS"].ToString()!) : (int?)null;


            if (almacen != null)
                item.Almacenid = almacen.Id;
            else
                item.Almacenid = null;

            if (existItem)
                localContext.Plazo.Update(item);
            else
                localContext.Plazo.Add(item);

            localContext.SaveChanges();

            return true;
        }

    }
}


