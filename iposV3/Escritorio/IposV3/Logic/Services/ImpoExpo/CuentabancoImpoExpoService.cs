
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
using BindingModels;

namespace IposV3.Services
{



    public class CuentabancoImpoExpoService : BaseImpoExpoService
    {


        public override bool ImportFromFirebirdReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               FbDataReader dataReader, ApplicationDbContext localContext)
        {

            var clave = dataReader["clave"] != System.DBNull.Value ? ((string)dataReader["clave"]).Trim() : "";

	
	    var BancoClave = dataReader["BANCOCLAVE"] != System.DBNull.Value ? ((string)dataReader["BANCOCLAVE"]).Trim() : "";


            var itemSaved = localContext.Cuentabanco.AsNoTracking()
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == clave);

	
            var BancoClave_obj = localContext.Banco.AsNoTracking()
                                        	.FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == BancoClave);


            var item = itemSaved != null ? itemSaved : new Cuentabanco();
            var existItem = itemSaved != null;

            if (!existItem)
                item.CreadoPorId = usuarioId;

            item.EmpresaId = empresaId;
            item.SucursalId = sucursalId;
            item.ModificadoPorId = usuarioId;

            item.Clave = dataReader["CLAVE"] != System.DBNull.Value ? ((string)dataReader["CLAVE"]).Trim() : ""; 
          	item.Nombre = dataReader["NOMBRE"] != System.DBNull.Value ? ((string)dataReader["NOMBRE"]).Trim() : ""; 
          	item.Nocuenta = dataReader["NOCUENTA"] != System.DBNull.Value ? ((string)dataReader["NOCUENTA"]).Trim() : ""; 
          	item.Rfc = dataReader["RFC"] != System.DBNull.Value ? ((string)dataReader["RFC"]).Trim() : ""; 
          	item.Predeterminada = dataReader["PREDETERMINADA"] != System.DBNull.Value && ((string)dataReader["PREDETERMINADA"]).Trim() == "S" ? BoolCN.S : BoolCN.N; 
		    item.Activo = dataReader["ACTIVO"] != System.DBNull.Value && ((string)dataReader["ACTIVO"]).Trim() == "N" ? BoolCS.N : BoolCS.S;
          
	
            if (BancoClave_obj != null)
                item.Bancoid = BancoClave_obj.Id;
            else
                item.Bancoid = null;



            if (existItem)
                localContext.Cuentabanco.Update(item);
            else
                localContext.Cuentabanco.Add(item);

            localContext.SaveChanges();

            return true;
        }



    }
}


