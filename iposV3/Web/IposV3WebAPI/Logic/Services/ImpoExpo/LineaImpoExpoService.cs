
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
    public class LineaImpoExpoService : BaseImpoExpoService
    {






        public override IQueryable<List<ImpoExpoValor>>? ObtainImpoExpoValores(long empresaId, long sucursalId, ApplicationDbContext localContext)
        {
            var exportValores = localContext.Linea.AsNoTracking()
                                                 .Where(x => x.EmpresaId == empresaId && x.SucursalId == sucursalId)
                                                 .Select(x => new List<ImpoExpoValor>(){

                                                        new ImpoExpoValor("Activo", x.Activo, BoolCS.S),
                                                        new ImpoExpoValor("Clave", x.Clave, ""),
                                                        new ImpoExpoValor("Nombre", x.Nombre, ""),
                                                        new ImpoExpoValor("Acumulapromocion", x.Acumulapromocion, BoolCN.N),
                                                        new ImpoExpoValor("Aplicamayoreoxlinea", x.Aplicamayoreoxlinea, BoolCS.S),
                                                        new ImpoExpoValor("Gpoimp", x.Gpoimp, ""),
                                                        new ImpoExpoValor("Tiporecarga", x.Tiporecarga, ""),
                                                        new ImpoExpoValor("Descuentovale", x.Descuentovale, 0),

                                                 });




            return exportValores;
        }

        public override List<ImpoExpoField> ObtainImpoExpoFields()
        {
            return new List<ImpoExpoField>() {

                new ImpoExpoField("Activo","activo",1,0, NpgsqlDbType.Varchar, typeof(BoolCS)),
                new ImpoExpoField("Clave","clave",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Nombre","nombre",127,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Acumulapromocion","acumulapro",1,0, NpgsqlDbType.Varchar, typeof(BoolCN)),
                new ImpoExpoField("Aplicamayoreoxlinea","aplicamay",1,0, NpgsqlDbType.Varchar, typeof(BoolCS)),
                new ImpoExpoField("Gpoimp","gpoimp",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Tiporecarga","tiporecarg",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Descuentovale","descuentov",18,2, NpgsqlDbType.Numeric, typeof(decimal)),
            };
        }

        public override bool ImportFromReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               OleDbDataReader dataReader, List<ImpoExpoField> fields, ApplicationDbContext localContext)
        {

            var clave = dataReader["clave"] != System.DBNull.Value ? ((string)dataReader["clave"]).Trim() : "";


            var itemSaved = localContext.Linea.AsNoTracking()
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == clave);

            var item = itemSaved != null ? itemSaved : new Linea();
            var existItem = itemSaved != null;


            item.Clave = dataReader["clave"] != System.DBNull.Value ? ((string)dataReader["clave"]).Trim() : "";
            item.Nombre = dataReader["nombre"] != System.DBNull.Value ? ((string)dataReader["nombre"]).Trim() : "";
            item.Gpoimp = dataReader["gpoimp"] != System.DBNull.Value ? ((string)dataReader["gpoimp"]).Trim() : "";
            item.Tiporecarga = dataReader["tiporecarg"] != System.DBNull.Value ? ((string)dataReader["tiporecarg"]).Trim() : "";
            item.Acumulapromocion = dataReader["acumulapro"] != System.DBNull.Value && ((string)dataReader["acumulapro"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Activo = dataReader["activo"] != System.DBNull.Value && ((string)dataReader["activo"]).Trim() == "N" ? BoolCS.N : BoolCS.S;
            item.Aplicamayoreoxlinea = dataReader["aplicamay"] != System.DBNull.Value && ((string)dataReader["aplicamay"]).Trim() == "N" ? BoolCS.N : BoolCS.S;
            item.Descuentovale = dataReader["descuentov"] != System.DBNull.Value ? (decimal)dataReader["descuentov"] : 0;


            if (existItem)
                localContext.Linea.Update(item);
            else
                localContext.Linea.Add(item);

            localContext.SaveChanges();

            return true;
        }




        public override bool ImportFromFirebirdReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               FbDataReader dataReader, ApplicationDbContext localContext)
        {

            var clave = dataReader["CLAVE"] != System.DBNull.Value ? ((string)dataReader["CLAVE"]).Trim() : "";


            var itemSaved = localContext.Linea.AsNoTracking()
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == clave);

            var item = itemSaved != null ? itemSaved : new Linea();
            var existItem = itemSaved != null;

            item.Clave = clave;
            if (!existItem)
                item.CreadoPorId = usuarioId;

            item.EmpresaId = empresaId;
            item.SucursalId = sucursalId;
            item.ModificadoPorId = usuarioId;
            item.Activo = dataReader["ACTIVO"] != System.DBNull.Value && ((string)dataReader["ACTIVO"]).Trim() == "S" ? BoolCS.S : BoolCS.N;
            item.Nombre = dataReader["NOMBRE"] != System.DBNull.Value ? ((string)dataReader["NOMBRE"]).Trim() : "";

            item.Gpoimp = dataReader["GPOIMP"] != System.DBNull.Value ? ((string)dataReader["GPOIMP"]).Trim() : "";
            item.Tiporecarga = dataReader["TIPORECARGA"] != System.DBNull.Value ? ((string)dataReader["TIPORECARGA"]).Trim() : "";
            item.Acumulapromocion = dataReader["ACUMULAPROMOCION"] != System.DBNull.Value && ((string)dataReader["ACUMULAPROMOCION"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Aplicamayoreoxlinea = dataReader["APLICAMAYOREOXLINEA"] != System.DBNull.Value && ((string)dataReader["APLICAMAYOREOXLINEA"]).Trim() == "N" ? BoolCS.N : BoolCS.S;
            item.Descuentovale = dataReader["DESCUENTOVALE"] != System.DBNull.Value ? (decimal)dataReader["DESCUENTOVALE"] : 0;


            if (existItem)
                localContext.Linea.Update(item);
            else
                localContext.Linea.Add(item);

            localContext.SaveChanges();

            return true;
        }


    }
}


