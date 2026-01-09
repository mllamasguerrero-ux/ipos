
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
    public class GastoImpoExpoService : BaseImpoExpoService
    {






        public override IQueryable<List<ImpoExpoValor>>? ObtainImpoExpoValores(long empresaId, long sucursalId, ApplicationDbContext localContext)
        {
            var exportValores = localContext.Gasto.AsNoTracking()
                                                .Include(x => x.Cuenta)
                                                 .Where(x => x.EmpresaId == empresaId && x.SucursalId == sucursalId)
                                                 .Select(x => new List<ImpoExpoValor>(){

                                                        new ImpoExpoValor("Activo", x.Activo, BoolCS.S),
                                                        new ImpoExpoValor("Clave", x.Clave, ""),
                                                        new ImpoExpoValor("Nombre", x.Nombre, ""),
                                                        new ImpoExpoValor("CuentaClave", x.Cuenta != null ? x.Cuenta.Clave : null, ""),
                                                        new ImpoExpoValor("CuentaNombre", x.Cuenta != null ? x.Cuenta.Nombre : null, ""),

                                                 });




            return exportValores;
        }

        public override List<ImpoExpoField> ObtainImpoExpoFields()
        {
            return new List<ImpoExpoField>() {

                new ImpoExpoField("Activo","activo",1,0, NpgsqlDbType.Varchar, typeof(BoolCS)),
                new ImpoExpoField("Clave","clave",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Nombre","nombre",127,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("CuentaClave","ctaclave",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("CuentaNombre","ctanombre",128,0, NpgsqlDbType.Char, typeof(string)),
            };
        }

        public override bool ImportFromReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               OleDbDataReader dataReader, List<ImpoExpoField> fields, ApplicationDbContext localContext)
        {

            var clave = dataReader["clave"] != System.DBNull.Value ? ((string)dataReader["clave"]).Trim() : "";


            var bufferStr = "";

            var itemSaved = localContext.Gasto
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == clave);

            var item = itemSaved != null ? itemSaved : new Gasto();
            var existItem = itemSaved != null;

	
          	item.Clave = dataReader["clave"] != System.DBNull.Value ? ((string)dataReader["clave"]).Trim() : ""; 
          	item.Nombre = dataReader["nombre"] != System.DBNull.Value ? ((string)dataReader["nombre"]).Trim() : ""; 
		    item.Activo = dataReader["activo"] != System.DBNull.Value && ((string)dataReader["activo"]).Trim() == "N" ? BoolCS.N : BoolCS.S;



            bufferStr = dataReader["ctaclave"] != System.DBNull.Value ? ((string)dataReader["ctaclave"]).Trim() : "";
            var cuenta = bufferStr == "" ? null : localContext.Cuenta.AsNoTracking()
                                                                                  .FirstOrDefault(x => x.EmpresaId == empresaId &&
                                                                                                       x.SucursalId == sucursalId &&
                                                                                                       x.Clave == bufferStr);
            item.Cuentaid = cuenta?.Id;
            

            if (existItem)
                localContext.Gasto.Update(item);
            else
                localContext.Gasto.Add(item);

            localContext.SaveChanges();

            return true;
        }


        public override bool ImportFromFirebirdReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               FbDataReader dataReader, ApplicationDbContext localContext)
        {

            var clave = dataReader["CLAVE"] != System.DBNull.Value ? ((string)dataReader["CLAVE"]).Trim() : "";
            long id = dataReader["ID"] != System.DBNull.Value ? ((long)dataReader["ID"]) : -1;

            var cuentaClave = dataReader["CUENTACLAVE"] != System.DBNull.Value ? ((string)dataReader["CUENTACLAVE"]).Trim() : "";


            var itemSaved = localContext.Gasto
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Id == id);

            var cuenta = localContext.Cuenta.AsNoTracking()
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == cuentaClave);

            var item = itemSaved != null ? itemSaved : new Gasto();
            var existItem = itemSaved != null;

            item.Clave = clave;
            if (!existItem)
                item.CreadoPorId = usuarioId;

            item.EmpresaId = empresaId;
            item.SucursalId = sucursalId;
            //item.Id = id;
            item.ModificadoPorId = usuarioId;
            item.Activo = dataReader["ACTIVO"] != System.DBNull.Value && ((string)dataReader["ACTIVO"]).Trim() == "S" ? BoolCS.S : BoolCS.N;
            item.Nombre = dataReader["NOMBRE"] != System.DBNull.Value ? ((string)dataReader["NOMBRE"]).Trim() : "";

            if (cuenta != null)
                item.Cuentaid = cuenta.Id;
            else
                item.Cuentaid = null;

            if (existItem)
                localContext.Gasto.Update(item);
            else
                localContext.Gasto.Add(item);

            localContext.SaveChanges();

            return true;
        }

    }
}


