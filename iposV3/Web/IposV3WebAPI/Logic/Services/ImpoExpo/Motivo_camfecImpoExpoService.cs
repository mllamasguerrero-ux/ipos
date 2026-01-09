
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



    public class Motivo_camfecImpoExpoService : BaseImpoExpoService
    {




        public override bool ImportFromFirebirdReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               FbDataReader dataReader, ApplicationDbContext localContext)
        {

            var clave = dataReader["clave"] != System.DBNull.Value ? ((string)dataReader["clave"]).Trim() : "";

	

            var itemSaved = localContext.Motivo_camfec.AsNoTracking()
                                        .FirstOrDefault(i => i.Clave == clave);

	

            var item = itemSaved != null ? itemSaved : new Motivo_camfec();
            var existItem = itemSaved != null;

            if (!existItem)
            {
                item.Id = dataReader["ID"] != System.DBNull.Value ? (long)dataReader["ID"] : 0;
                item.CreadoPorId = usuarioId;
            }

            //item.EmpresaId = empresaId;
            //item.SucursalId = sucursalId;
            item.ModificadoPorId = usuarioId;


            item.Clave = dataReader["CLAVE"] != System.DBNull.Value ? ((string)dataReader["CLAVE"]).Trim() : ""; 
          	item.Nombre = dataReader["NOMBRE"] != System.DBNull.Value ? ((string)dataReader["NOMBRE"]).Trim() : ""; 
          	item.Descripcion = dataReader["DESCRIPCION"] != System.DBNull.Value ? ((string)dataReader["DESCRIPCION"]).Trim() : ""; 
		item.Activo = dataReader["ACTIVO"] != System.DBNull.Value && ((string)dataReader["ACTIVO"]).Trim() == "N" ? BoolCS.N : BoolCS.S;         

	


            if (existItem)
                localContext.Motivo_camfec.Update(item);
            else
                localContext.Motivo_camfec.Add(item);

            localContext.SaveChanges();

            return true;
        }



    }
}


