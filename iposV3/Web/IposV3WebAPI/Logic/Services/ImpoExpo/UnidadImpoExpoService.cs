
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
    public class UnidadImpoExpoService : BaseImpoExpoService
    {






        public override IQueryable<List<ImpoExpoValor>>? ObtainImpoExpoValores(long empresaId, long sucursalId, ApplicationDbContext localContext)
        {
            var exportValores = localContext.Unidad.AsNoTracking()
                                                .Include(x => x.Sat_unidadmedida)
                                                 .Where(x => x.EmpresaId == empresaId && x.SucursalId == sucursalId)
                                                 .Select(x => new List<ImpoExpoValor>(){

                                                        new ImpoExpoValor("Activo", x.Activo, BoolCS.S),
                                                        new ImpoExpoValor("Clave", x.Clave, ""),
                                                        new ImpoExpoValor("Nombre", x.Nombre, ""),
                                                        new ImpoExpoValor("CantidadDecimales", x.CantidadDecimales, 0),
                                                        new ImpoExpoValor("Sat_unidadmedidaClave", x.Sat_unidadmedida!.Clave, ""),
                                                        new ImpoExpoValor("Sat_unidadmedidaNombre", x.Sat_unidadmedida!.Nombre, ""),

                                                 });




            return exportValores;
        }

        public override List<ImpoExpoField> ObtainImpoExpoFields()
        {
            return new List<ImpoExpoField>() {

                new ImpoExpoField("Activo","activo",1,0, NpgsqlDbType.Varchar, typeof(BoolCS)),
                new ImpoExpoField("Clave","clave",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Nombre","nombre",127,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("CantidadDecimales","cantdec",254,0, NpgsqlDbType.Smallint, typeof(short)),
                new ImpoExpoField("Sat_unidadmedidaClave","satmedcla",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Sat_unidadmedidaNombre","satmednom",128,0, NpgsqlDbType.Char, typeof(string)),
            };
        }

        public override bool ImportFromReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               OleDbDataReader dataReader, List<ImpoExpoField> fields, ApplicationDbContext localContext)
        {

            var clave = dataReader["clave"] != System.DBNull.Value ? ((string)dataReader["clave"]).Trim() : "";

            var bufferStr = "";

            var itemSaved = localContext.Unidad
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == clave);

            var item = itemSaved != null ? itemSaved : new Unidad();
            var existItem = itemSaved != null;

	
          	item.Clave = dataReader["clave"] != System.DBNull.Value ? ((string)dataReader["clave"]).Trim() : ""; 
          	item.Nombre = dataReader["nombre"] != System.DBNull.Value ? ((string)dataReader["nombre"]).Trim() : "";
            item.Activo = dataReader["activo"] != System.DBNull.Value && ((string)dataReader["activo"]).Trim() == "N" ? BoolCS.N : BoolCS.S;
            item.CantidadDecimales = dataReader["cantdec"] != System.DBNull.Value ? short.Parse(dataReader["cantdec"].ToString()!) : (short)0;

            bufferStr = dataReader["satmedcla"] != System.DBNull.Value ? ((string)dataReader["satmedcla"]).Trim() : "";
            var sat_unidadMedida = bufferStr == "" ? null : localContext.Sat_unidadmedida.AsNoTracking().FirstOrDefault(x => x.Sat_clave == bufferStr);
            item.Sat_unidadmedidaid = sat_unidadMedida?.Id;



            if (existItem)
                localContext.Unidad.Update(item);
            else
                localContext.Unidad.Add(item);

            localContext.SaveChanges();

            return true;
        }


        public override bool ImportFromFirebirdReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               FbDataReader dataReader, ApplicationDbContext localContext)
        {

            
            var clave = dataReader["CLAVE"] != System.DBNull.Value ? ((string)dataReader["CLAVE"]).Trim() : "";
            long id = dataReader["ID"] != System.DBNull.Value ? ((long)dataReader["ID"]) : -1;

            var sat_unidadClave = dataReader["SAT_UNIDADMEDIDACLAVE"] != System.DBNull.Value ? ((string)dataReader["SAT_UNIDADMEDIDACLAVE"]).Trim() : "";


            var itemSaved = localContext.Unidad.AsNoTracking()
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Id == id);
            try
            {

                var sat_unidad = localContext.Sat_unidadmedida.AsNoTracking()
                                            .FirstOrDefault(i => i.Sat_clave == sat_unidadClave);

                var item = itemSaved != null ? itemSaved : new Unidad();
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
                item.CantidadDecimales = dataReader["CANTIDADDECIMALES"] != System.DBNull.Value ? short.Parse(dataReader["CANTIDADDECIMALES"].ToString()!) : (short)0;


                if (sat_unidad != null)
                    item.Sat_unidadmedidaid = sat_unidad.Id;
                else
                    item.Sat_unidadmedidaid = null;

                if (existItem)
                    localContext.Unidad.Update(item);
                else
                    localContext.Unidad.Add(item);

                localContext.SaveChanges();

                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

    }
}


