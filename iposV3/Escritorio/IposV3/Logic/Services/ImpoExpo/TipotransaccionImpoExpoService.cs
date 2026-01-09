
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



    public class TipotransaccionImpoExpoService : BaseImpoExpoService
    {


        public override bool ImportFromFirebirdReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               FbDataReader dataReader, ApplicationDbContext localContext)
        {

            var clave = dataReader["clave"] != System.DBNull.Value ? ((string)dataReader["clave"]).Trim() : "";

	

            var itemSaved = localContext.Tipotransaccion
                                        .FirstOrDefault(i => i.Clave == clave);

	

            var item = itemSaved != null ? itemSaved : new Tipotransaccion();
            var existItem = itemSaved != null;

            if (!existItem)
            {
                //item.Id = dataReader["ID"] != System.DBNull.Value ? (long)dataReader["ID"] : 0;
                item.CreadoPorId = usuarioId;
                item.EmpresaId = empresaId;
                item.SucursalId = sucursalId;
            }


            item.Clave = dataReader["CLAVE"] != System.DBNull.Value ? ((string)dataReader["CLAVE"]).Trim() : ""; 
          	item.Nombre = dataReader["NOMBRE"] != System.DBNull.Value ? ((string)dataReader["NOMBRE"]).Trim() : ""; 
		    item.Activo = dataReader["ACTIVO"] != System.DBNull.Value && ((string)dataReader["ACTIVO"]).Trim() == "N" ? BoolCS.N : BoolCS.S;
            //item.Creado = dataReader["CREADO"] != System.DBNull.Value ? (DateTimeOffset)dataReader["CREADO"] : DateTimeOffset.UtcNow;         
            //item.Modificado = dataReader["MODIFICADO"] != System.DBNull.Value ? (DateTimeOffset)dataReader["MODIFICADO"] : DateTimeOffset.UtcNow; 
            item.ModificadoPorId = usuarioId;
            item.Sentidoinventario = dataReader["SENTIDOINVENTARIO"] != System.DBNull.Value ? (short)dataReader["SENTIDOINVENTARIO"] : (short?)null; 
		    item.Sentidopago = dataReader["SENTIDOPAGO"] != System.DBNull.Value ? (short)dataReader["SENTIDOPAGO"] : (short?)null;



            if (existItem)
                localContext.Tipotransaccion.Update(item);
            else
                localContext.Tipotransaccion.Add(item);

            localContext.SaveChanges();

            return true;
        }



    }
}


