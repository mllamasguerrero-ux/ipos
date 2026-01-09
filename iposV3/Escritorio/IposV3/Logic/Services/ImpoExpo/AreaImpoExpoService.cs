
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



    public class AreaImpoExpoService : BaseImpoExpoService
    {




        public override bool ImportFromFirebirdReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               FbDataReader dataReader, ApplicationDbContext localContext)
        {

            var clave = dataReader["clave"] != System.DBNull.Value ? ((string)dataReader["clave"]).Trim() : "";

	

            var itemSaved = localContext.Area.AsNoTracking()
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == clave);

	

            var item = itemSaved != null ? itemSaved : new Area();
            var existItem = itemSaved != null;

            if (!existItem)
                item.CreadoPorId = usuarioId;

            item.EmpresaId = empresaId;
            item.SucursalId = sucursalId;
            item.ModificadoPorId = usuarioId;


            item.Nombrearea = dataReader["NOMBREAREA"] != System.DBNull.Value ? ((string)dataReader["NOMBREAREA"]).Trim() : ""; 
          	item.Clave = dataReader["CLAVE"] != System.DBNull.Value ? ((string)dataReader["CLAVE"]).Trim() : ""; 
		item.Activo = dataReader["ACTIVO"] != System.DBNull.Value && ((string)dataReader["ACTIVO"]).Trim() == "N" ? BoolCS.N : BoolCS.S;         
		


            if (existItem)
                localContext.Area.Update(item);
            else
                localContext.Area.Add(item);

            localContext.SaveChanges();

            return true;
        }



    }
}


