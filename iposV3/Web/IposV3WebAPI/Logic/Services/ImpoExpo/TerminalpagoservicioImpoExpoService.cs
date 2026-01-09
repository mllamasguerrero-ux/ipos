
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
    public class TerminalpagoservicioImpoExpoService : BaseImpoExpoService
    {






        public override IQueryable<List<ImpoExpoValor>>? ObtainImpoExpoValores(long empresaId, long sucursalId, ApplicationDbContext localContext)
        {
            var exportValores = localContext.Terminalpagoservicio.AsNoTracking()
                                                 .Include(x => x.Sucursalinfo)
                                                 .Where(x => x.EmpresaId == empresaId && x.SucursalId == sucursalId)
                                                 .Select(x => new List<ImpoExpoValor>(){

                                                        new ImpoExpoValor("Activo", x.Activo, BoolCS.S),
                                                        new ImpoExpoValor("Terminal", x.Terminal, ""),
                                                        new ImpoExpoValor("Esservicio", x.Esservicio, ""),
                                                        new ImpoExpoValor("SucursalinfoClave", x.Sucursalinfo!.Clave, ""),
                                                        new ImpoExpoValor("SucursalinfoNombre", x.Sucursalinfo.Nombre, ""),
                                                        new ImpoExpoValor("Consecutivo", x.Consecutivo, ""),
                                                        new ImpoExpoValor("Clave", x.Clave, ""),
                                                        new ImpoExpoValor("Nombre", x.Nombre, ""),

                                                 });




            return exportValores;
        }

        public override List<ImpoExpoField> ObtainImpoExpoFields()
        {
            return new List<ImpoExpoField>() {

                new ImpoExpoField("Activo","activo",1,0, NpgsqlDbType.Varchar, typeof(BoolCS)),
                new ImpoExpoField("Terminal","terminal",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Esservicio","esservicio",254,0, NpgsqlDbType.Varchar, typeof(BoolCN)),
                new ImpoExpoField("SucursalinfoClave","succlave",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("SucursalinfoNombre","sucnombre",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Consecutivo","consec",254,0, NpgsqlDbType.Bigint, typeof(long)),
                new ImpoExpoField("Clave","clave",254,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Nombre","nombre",254,0, NpgsqlDbType.Char, typeof(string)),
            };
        }

        public override bool ImportFromReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               OleDbDataReader dataReader, List<ImpoExpoField> fields, ApplicationDbContext localContext)
        {

            var terminal = dataReader["terminal"] != System.DBNull.Value ? ((string)dataReader["terminal"]).Trim() : "";

            var bufferStr = "";

            var itemSaved = localContext.Terminalpagoservicio
                                        .Include(x => x.Sucursalinfo)
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Terminal == terminal);

            var item = itemSaved != null ? itemSaved : new Terminalpagoservicio();
            var existItem = itemSaved != null;

	
          	item.Terminal = dataReader["terminal"] != System.DBNull.Value ? ((string)dataReader["terminal"]).Trim() : ""; 
          	//item.Clave = dataReader["clave"] != System.DBNull.Value ? ((string)dataReader["clave"]).Trim() : ""; 
          	//item.Nombre = dataReader["nombre"] != System.DBNull.Value ? ((string)dataReader["nombre"]).Trim() : ""; 
		    item.Esservicio = dataReader["esservicio"] != System.DBNull.Value && ((string)dataReader["esservicio"]).Trim() == "S" ? BoolCN.S : BoolCN.N; 
		    item.Activo = dataReader["activo"] != System.DBNull.Value && ((string)dataReader["activo"]).Trim() == "N" ? BoolCS.N : BoolCS.S; 
		    item.Consecutivo = dataReader["consec"] != System.DBNull.Value ? long.Parse(dataReader["consec"].ToString()!) : (long?)null;


            bufferStr = dataReader["succlave"] != System.DBNull.Value ? ((string)dataReader["succlave"]).Trim() : "";
            var sucursalinfo = bufferStr == "" ? null : localContext.Sucursal_info.AsNoTracking()
                                                                                  .FirstOrDefault(x => x.EmpresaId == empresaId && 
                                                                                                       x.SucursalId == sucursalId && 
                                                                                                       x.Clave == bufferStr);
            item.Sucursalinfoid = sucursalinfo?.Id;


            if (existItem)
                localContext.Terminalpagoservicio.Update(item);
            else
                localContext.Terminalpagoservicio.Add(item);

            localContext.SaveChanges();

            return true;
        }


        public override bool ImportFromFirebirdReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               FbDataReader dataReader, ApplicationDbContext localContext)
        {

            var terminal = dataReader["TERMINAL"] != System.DBNull.Value ? ((string)dataReader["TERMINAL"]).Trim() : "";

            var sucursal_infoClave = dataReader["SUCURSALCLAVE"] != System.DBNull.Value ? ((string)dataReader["SUCURSALCLAVE"]).Trim() : "";


            var itemSaved = localContext.Terminalpagoservicio.AsNoTracking()
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Terminal == terminal);

            var sucursal_info = localContext.Sucursal_info.AsNoTracking()
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == sucursal_infoClave);

            var item = itemSaved != null ? itemSaved : new Terminalpagoservicio();
            var existItem = itemSaved != null;

            item.Terminal = terminal;
            if (!existItem)
                item.CreadoPorId = usuarioId;

            item.EmpresaId = empresaId;
            item.SucursalId = sucursalId;
            item.ModificadoPorId = usuarioId;
            item.Activo = dataReader["ACTIVO"] != System.DBNull.Value && ((string)dataReader["ACTIVO"]).Trim() == "S" ? BoolCS.S : BoolCS.N;
            item.Esservicio = dataReader["ESSERVICIO"] != System.DBNull.Value && ((string)dataReader["ESSERVICIO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;


            if (sucursal_info != null)
                item.Sucursalinfoid = sucursal_info.Id;
            else
                item.Sucursalinfoid = null;

            if (existItem)
                localContext.Terminalpagoservicio.Update(item);
            else
                localContext.Terminalpagoservicio.Add(item);

            localContext.SaveChanges();

            return true;
        }

    }
}


