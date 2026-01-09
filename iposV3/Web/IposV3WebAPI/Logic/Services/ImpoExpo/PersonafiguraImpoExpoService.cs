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
    public class PersonafiguraImpoExpoService : BaseImpoExpoService
    {

        public override bool ImportFromFirebirdReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               FbDataReader dataReader, ApplicationDbContext localContext)
        {
            //long id = dataReader["ID"] != System.DBNull.Value ? ((long)dataReader["ID"]) : -1;

            var numlicencia = dataReader["NUMLICENCIA"] != System.DBNull.Value ? ((string)dataReader["NUMLICENCIA"]).Trim() : "";

            var usuarioClave = dataReader["USUARIOCLAVE"] != System.DBNull.Value ? ((string)dataReader["USUARIOCLAVE"]).Trim() : "";

            var sat_FiguratransporteClave = dataReader["SAT_FIGURATRANSPORTECLAVE"] != System.DBNull.Value ? ((string)dataReader["SAT_FIGURATRANSPORTECLAVE"]).Trim() : "";

            var sat_PartetransporteClave = dataReader["SAT_PARTETRANSPORTECLAVE"] != System.DBNull.Value ? ((string)dataReader["SAT_PARTETRANSPORTECLAVE"]).Trim() : "";



            var usuario = localContext.Usuario.AsNoTracking()
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.UsuarioNombre == usuarioClave);



            if (usuario == null)
                return false;

            var itemSaved = localContext.Personafigura.AsNoTracking()
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Personaid == usuario.Id);


            var sat_Figuratransporte = localContext.Sat_figuratransporte.AsNoTracking()
                                        .FirstOrDefault(i => i.Clave == sat_FiguratransporteClave);

            var sat_Partetransporte = localContext.Sat_partetransporte.AsNoTracking()
                                        .FirstOrDefault(i => i.Clave == sat_PartetransporteClave);


            var item = itemSaved != null ? itemSaved : new Personafigura();
            var existItem = itemSaved != null;

            item.Numlicencia = numlicencia;
            if (!existItem)
                item.CreadoPorId = usuarioId;

            item.EmpresaId = empresaId;
            item.SucursalId = sucursalId;
            //item.Id = id;
            item.ModificadoPorId = usuarioId;
            item.Activo = dataReader["ACTIVO"] != System.DBNull.Value && ((string)dataReader["ACTIVO"]).Trim() == "S" ? BoolCS.S : BoolCS.N;
            item.Numregidtrib = dataReader["NUMREGIDTRIB"] != System.DBNull.Value ? ((string)dataReader["NUMREGIDTRIB"]).Trim() : null;
            item.Residenciafiscal = dataReader["RESIDENCIAFISCAL"] != System.DBNull.Value ? ((string)dataReader["RESIDENCIAFISCAL"]).Trim() : null;


            if (usuario != null)
                item.Personaid = usuario.Id;
            else
                item.Personaid = null;

            if (sat_Figuratransporte != null)
                item.Sat_Figuratransporteid = sat_Figuratransporte.Id;
            else
                item.Sat_Figuratransporteid = null;

            if (sat_Partetransporte != null)
                item.Sat_Partetransporteid = sat_Partetransporte.Id;
            else
                item.Sat_Partetransporteid = null;


            if (existItem)
                localContext.Personafigura.Update(item);
            else
                localContext.Personafigura.Add(item);

            localContext.SaveChanges();

            return true;
        }
    }
}
