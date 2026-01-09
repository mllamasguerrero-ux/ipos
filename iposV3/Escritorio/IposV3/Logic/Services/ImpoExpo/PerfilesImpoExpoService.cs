
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



    public class PerfilesImpoExpoService : BaseImpoExpoService
    {



        public override bool ImportFromFirebirdReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               FbDataReader dataReader, ApplicationDbContext localContext)
        {

            //var clave = dataReader["clave"] != System.DBNull.Value ? ((string)dataReader["clave"]).Trim() : "";

            var descripcion = dataReader["DESCRIPCION"] != System.DBNull.Value ? ((string)dataReader["DESCRIPCION"]).Trim() : "";

            var itemSaved = localContext.Perfiles.AsNoTracking()
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Descripcion == descripcion);

	

            var item = itemSaved != null ? itemSaved : new Perfiles();
            var existItem = itemSaved != null;

            if (!existItem)
                item.CreadoPorId = usuarioId;

            item.EmpresaId = empresaId;
            item.SucursalId = sucursalId;
            item.ModificadoPorId = usuarioId;


            item.Descripcion = descripcion;//dataReader["DESCRIPCION"] != System.DBNull.Value ? ((string)dataReader["DESCRIPCION"]).Trim() : ""; 
		item.Activo = dataReader["ACTIVO"] != System.DBNull.Value && ((string)dataReader["ACTIVO"]).Trim() == "N" ? BoolCS.N : BoolCS.S;         
		
	


            if (existItem)
                localContext.Perfiles.Update(item);
            else
                localContext.Perfiles.Add(item);

            localContext.SaveChanges();

            return true;
        }



    }
}


