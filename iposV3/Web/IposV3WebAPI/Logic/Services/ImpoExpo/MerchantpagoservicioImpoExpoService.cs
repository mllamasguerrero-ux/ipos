
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
    public class MerchantpagoservicioImpoExpoService : BaseImpoExpoService
    {






        public override IQueryable<List<ImpoExpoValor>>? ObtainImpoExpoValores(long empresaId, long sucursalId, ApplicationDbContext localContext)
        {
            var exportValores = localContext.Merchantpagoservicio.AsNoTracking()
                                                 .Include(x => x.Sucursal_info)
                                                 .Where(x => x.EmpresaId == empresaId && x.SucursalId == sucursalId)
                                                 .Select(x => new List<ImpoExpoValor>(){

                                                        new ImpoExpoValor("Activo", x.Activo, BoolCS.S),
                                                        new ImpoExpoValor("Merchantid", x.Merchantid, ""),
                                                        new ImpoExpoValor("Esservicio", x.Esservicio, ""),
                                                        new ImpoExpoValor("Sucursal_infoClave", x.Sucursal_info!.Clave, ""),
                                                        new ImpoExpoValor("Sucursal_infoNombre", x.Sucursal_info.Nombre, ""),

                                                 });




            return exportValores;
        }

        public override List<ImpoExpoField> ObtainImpoExpoFields()
        {
            return new List<ImpoExpoField>() {

                new ImpoExpoField("Activo","activo",1,0, NpgsqlDbType.Varchar, typeof(BoolCS)),
                new ImpoExpoField("Merchantid","merchantid",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Esservicio","esservicio",254,0, NpgsqlDbType.Varchar, typeof(BoolCN)),
                new ImpoExpoField("Sucursal_infoClave","succlave",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Sucursal_infoNombre","sucnombre",128,0, NpgsqlDbType.Char, typeof(string)),
            };
        }

        public override bool ImportFromReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               OleDbDataReader dataReader, List<ImpoExpoField> fields, ApplicationDbContext localContext)
        {

            var merchantid = dataReader["merchantid"] != System.DBNull.Value ? ((string)dataReader["merchantid"]).Trim() : "";

            var bufferStr = "";

            var itemSaved = localContext.Merchantpagoservicio
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             merchantid == i.Merchantid);

            var item = itemSaved != null ? itemSaved : new Merchantpagoservicio();
            var existItem = itemSaved != null;


            item.Merchantid = dataReader["merchantid"] != System.DBNull.Value ? ((string)dataReader["merchantid"]).Trim() : ""; 
          	item.Esservicio = dataReader["esservicio"] != System.DBNull.Value && ((string)dataReader["esservicio"]).Trim() == "S" ? BoolCN.S : BoolCN.N; 
		    item.Activo = dataReader["activo"] != System.DBNull.Value && ((string)dataReader["activo"]).Trim() == "N" ? BoolCS.N : BoolCS.S;



            bufferStr = dataReader["succlave"] != System.DBNull.Value ? ((string)dataReader["succlave"]).Trim() : "";
            var sucursalinfo = bufferStr == "" ? null : localContext.Sucursal_info.AsNoTracking()
                                                                                  .FirstOrDefault(x => x.EmpresaId == empresaId &&
                                                                                                       x.SucursalId == sucursalId &&
                                                                                                       x.Clave == bufferStr);
            item.Sucursal_id = sucursalinfo?.Id;

            if (existItem)
                localContext.Merchantpagoservicio.Update(item);
            else
                localContext.Merchantpagoservicio.Add(item);

            localContext.SaveChanges();

            return true;
        }


        public override bool ImportFromFirebirdReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               FbDataReader dataReader, ApplicationDbContext localContext)
        {

            var merchantid = dataReader["MERCHANTID"] != System.DBNull.Value ? ((string)dataReader["MERCHANTID"]).Trim() : "";

            var sucursal_infoClave = dataReader["SUCURSALCLAVE"] != System.DBNull.Value ? ((string)dataReader["SUCURSALCLAVE"]).Trim() : "";


            var itemSaved = localContext.Merchantpagoservicio.AsNoTracking()
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Merchantid == merchantid);


            var sucursal_info = localContext.Sucursal_info.AsNoTracking()
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == sucursal_infoClave);

            var item = itemSaved != null ? itemSaved : new Merchantpagoservicio();
            var existItem = itemSaved != null;

            item.Merchantid = merchantid;
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
                localContext.Merchantpagoservicio.Update(item);
            else
                localContext.Merchantpagoservicio.Add(item);

            localContext.SaveChanges();

            return true;
        }

    }
}


