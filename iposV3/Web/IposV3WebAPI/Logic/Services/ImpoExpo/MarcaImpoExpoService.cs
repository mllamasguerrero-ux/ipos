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
using FirebirdSql.Data.FirebirdClient;

namespace IposV3.Services
{


    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public class MarcaImpoExpoService : BaseImpoExpoService
    {


        public override IQueryable<List<ImpoExpoValor>>? ObtainImpoExpoValores(long empresaId, long sucursalId, ApplicationDbContext localContext)
        {
            var exportValores = localContext.Marca.AsNoTracking()
                                                 .Where(x => x.EmpresaId == empresaId && x.SucursalId == sucursalId)
                                                 .Select(x => new List<ImpoExpoValor>(){
                                                        new ImpoExpoValor("Activo", x.Activo, 0),
                                                        new ImpoExpoValor("Clave", x.Clave, ""),
                                                        new ImpoExpoValor("Nombre", x.Nombre, ""),
                                                        new ImpoExpoValor("Descontinuado", x.Descontinuado, 0)
                                                 });




            return exportValores;
        }

        public override List<ImpoExpoField> ObtainImpoExpoFields()
        {
            return new List<ImpoExpoField>() {

                new ImpoExpoField("Activo","activo",1,0, OleDbType.Char, typeof(BoolCS), "char(1)"),
                new ImpoExpoField("Clave","clave",Domains.ClaveLength,0, OleDbType.Char, typeof(string), "char(" + Domains.ClaveLength.ToString() + ")"),
                new ImpoExpoField("Nombre","nombre",Domains.NombreLength,0, OleDbType.Char, typeof(string), "char(" + Domains.NombreLength.ToString() + ")"),
                new ImpoExpoField("Descontinuado","descont",1,0, OleDbType.Char, typeof(BoolCN), "char(1)")

            };
        }

        public override bool ImportFromReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               OleDbDataReader dataReader, List<ImpoExpoField> fields, ApplicationDbContext localContext)
        {

            var clave = dataReader["clave"] != System.DBNull.Value ? ((string)dataReader["clave"]).Trim() : "";


            var itemSaved = localContext.Marca.AsNoTracking()
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == clave);

            var item = itemSaved != null ? itemSaved : new Marca();
            var existItem = itemSaved != null;

            item.Clave = clave;
            if (!existItem)
                item.CreadoPorId = usuarioId;

            item.EmpresaId = empresaId;
            item.SucursalId = sucursalId;
            item.Activo = dataReader["activo"] != System.DBNull.Value && ((string)dataReader["activo"]).Trim() == "S" ? BoolCS.S : BoolCS.N;
            item.Nombre = dataReader["nombre"] != System.DBNull.Value ? ((string)dataReader["nombre"]).Trim() : "";
            item.Descontinuado = dataReader["descont"] != System.DBNull.Value && ((string)dataReader["descont"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            //item.Tiporecargaid = dataReader["tiporecarg"] != System.DBNull.Value ? long.Parse(dataReader["tiporecarg"].ToString()) : (long?)null; break;

            if (existItem)
                localContext.Marca.Update(item);
            else
                localContext.Marca.Add(item);

            localContext.SaveChanges();

            return true;
        }



        public override bool ImportFromFirebirdReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId, 
                                               FbDataReader dataReader, ApplicationDbContext localContext)
        {

            var clave = dataReader["CLAVE"] != System.DBNull.Value ? ((string)dataReader["CLAVE"]).Trim() : "";


            var itemSaved = localContext.Marca.AsNoTracking()
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == clave);

            var item = itemSaved != null ? itemSaved : new Marca();
            var existItem = itemSaved != null;

            item.Clave = clave;
            if (!existItem)
                item.CreadoPorId = usuarioId;

            item.EmpresaId = empresaId;
            item.SucursalId = sucursalId;
            item.ModificadoPorId = usuarioId;
            item.Activo = dataReader["ACTIVO"] != System.DBNull.Value && ((string)dataReader["ACTIVO"]).Trim() == "S" ? BoolCS.S : BoolCS.N;
            item.Nombre = dataReader["NOMBRE"] != System.DBNull.Value ? ((string)dataReader["NOMBRE"]).Trim() : "";
            item.Descontinuado = dataReader["DESCONTINUADO"] != System.DBNull.Value && ((string)dataReader["DESCONTINUADO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            
            if (existItem)
                localContext.Marca.Update(item);
            else
                localContext.Marca.Add(item);

            localContext.SaveChanges();

            return true;
        }

    }
}
