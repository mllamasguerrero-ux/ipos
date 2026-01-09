
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
    public class ClerkpagoservicioImpoExpoService : BaseImpoExpoService
    {






        public override IQueryable<List<ImpoExpoValor>>? ObtainImpoExpoValores(long empresaId, long sucursalId, ApplicationDbContext localContext)
        {
            var exportValores = localContext.Clerkpagoservicio.AsNoTracking()
                                                 .Include(x => x.Sucursal_info)
                                                 .Where(x => x.EmpresaId == empresaId && x.SucursalId == sucursalId)
                                                 .Select(x => new List<ImpoExpoValor>(){

                                                        new ImpoExpoValor("Activo", x.Activo, BoolCS.S),
                                                        new ImpoExpoValor("Clerkid", x.Clerkid, ""),
                                                        new ImpoExpoValor("Esservicio", x.Esservicio, ""),
                                                        new ImpoExpoValor("Sucursal_infoClave", x.Sucursal_info!.Clave, ""),
                                                        new ImpoExpoValor("Sucursal_infoNombre", x.Sucursal_info!.Nombre, ""),

                                                 });




            return exportValores;
        }

        public override List<ImpoExpoField> ObtainImpoExpoFields()
        {
            return new List<ImpoExpoField>() {

                new ImpoExpoField("Activo","activo",1,0, NpgsqlDbType.Varchar, typeof(BoolCS)),
                new ImpoExpoField("Clerkid","clerkid",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Esservicio","esservicio",254,0, NpgsqlDbType.Varchar, typeof(BoolCN)),
                new ImpoExpoField("Sucursal_infoClave","succlave",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Sucursal_infoNombre","sucnombre",128,0, NpgsqlDbType.Char, typeof(string)),
            };
        }

        public override bool ImportFromReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               OleDbDataReader dataReader, List<ImpoExpoField> fields, ApplicationDbContext localContext)
        {

            var clerkid = dataReader["clerkid"] != System.DBNull.Value ? ((string)dataReader["clerkid"]).Trim() : "";

            var bufferStr = "";

            var itemSaved = localContext.Clerkpagoservicio
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clerkid == clerkid);

            var item = itemSaved != null ? itemSaved : new Clerkpagoservicio();
            var existItem = itemSaved != null;

	
          	item.Clerkid = dataReader["clerkid"] != System.DBNull.Value ? ((string)dataReader["clerkid"]).Trim() : ""; 
          	item.Sucursal_info!.Clave = dataReader["succlave"] != System.DBNull.Value ? ((string)dataReader["succlave"]).Trim() : ""; 
          	item.Sucursal_info!.Nombre = dataReader["sucnombre"] != System.DBNull.Value ? ((string)dataReader["sucnombre"]).Trim() : ""; 
		    item.Esservicio = dataReader["esservicio"] != System.DBNull.Value && ((string)dataReader["esservicio"]).Trim() == "S" ? BoolCN.S : BoolCN.N; 
		    item.Activo = dataReader["activo"] != System.DBNull.Value && ((string)dataReader["activo"]).Trim() == "N" ? BoolCS.N : BoolCS.S;

            bufferStr = dataReader["succlave"] != System.DBNull.Value ? ((string)dataReader["succlave"]).Trim() : "";
            var sucursalinfo = bufferStr == "" ? null : localContext.Sucursal_info.AsNoTracking()
                                                                                  .FirstOrDefault(x => x.EmpresaId == empresaId &&
                                                                                                       x.SucursalId == sucursalId &&
                                                                                                       x.Clave == bufferStr);
            item.Sucursal_id = sucursalinfo?.Id;

            if (existItem)
                localContext.Clerkpagoservicio.Update(item);
            else
                localContext.Clerkpagoservicio.Add(item);

            localContext.SaveChanges();

            return true;
        }


        public override bool ImportFromFirebirdReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               FbDataReader dataReader, ApplicationDbContext localContext)
        {

            var clerkid = dataReader["CLERKID"] != System.DBNull.Value ? ((string)dataReader["CLERKID"]).Trim() : "";

            var sucursal_infoClave = dataReader["SUCURSALCLAVE"] != System.DBNull.Value ? ((string)dataReader["SUCURSALCLAVE"]).Trim() : "";


            var itemSaved = localContext.Clerkpagoservicio.AsNoTracking()
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clerkid == clerkid);

            var sucursal_info = localContext.Sucursal_info.AsNoTracking()
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == sucursal_infoClave);

            var item = itemSaved != null ? itemSaved : new Clerkpagoservicio();
            var existItem = itemSaved != null;

            item.Clerkid = clerkid;
            if (!existItem)
                item.CreadoPorId = usuarioId;

            item.EmpresaId = empresaId;
            item.SucursalId = sucursalId;
            item.ModificadoPorId = usuarioId;
            item.Activo = dataReader["ACTIVO"] != System.DBNull.Value && ((string)dataReader["ACTIVO"]).Trim() == "S" ? BoolCS.S : BoolCS.N;
            item.Esservicio = dataReader["ESSERVICIO"] != System.DBNull.Value && ((string)dataReader["ESSERVICIO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;


            if (sucursal_info != null)
                item.Sucursal_id = sucursal_info.Id;
            else
                item.Sucursal_id = null;

            if (existItem)
                localContext.Clerkpagoservicio.Update(item);
            else
                localContext.Clerkpagoservicio.Add(item);

            localContext.SaveChanges();

            return true;
        }

    }
}


