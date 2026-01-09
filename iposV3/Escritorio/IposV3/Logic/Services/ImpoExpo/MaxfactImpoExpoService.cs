
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



    public class MaxfactImpoExpoService : BaseImpoExpoService
    {




        public override bool ImportFromFirebirdReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               FbDataReader dataReader, ApplicationDbContext localContext)
        {

            //var clave = dataReader["clave"] != System.DBNull.Value ? ((string)dataReader["clave"]).Trim() : "";


            var anio = dataReader["ANIO"] != System.DBNull.Value ? int.Parse((string)dataReader["ANIO"]) : (int?)null;
            var mes = dataReader["MES"] != System.DBNull.Value ? int.Parse((string)dataReader["MES"]) : (int?)null;

            var sucursalclave = dataReader["SUCURSALCLAVE"] != System.DBNull.Value ? ((string)dataReader["SUCURSALCLAVE"]).Trim() : "";

			if (anio == null || mes == null || sucursalclave == null)
				return false;

            var itemSaved = localContext.Maxfact.AsNoTracking()
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Sucursalclave == sucursalclave && i.Anio == anio && i.Mes == mes);

	

            var item = itemSaved != null ? itemSaved : new Maxfact();
            var existItem = itemSaved != null;

            if (!existItem)
                item.CreadoPorId = usuarioId;

            item.EmpresaId = empresaId;
            item.SucursalId = sucursalId;
            item.ModificadoPorId = usuarioId;


            item.Sucursalclave = dataReader["SUCURSALCLAVE"] != System.DBNull.Value ? ((string)dataReader["SUCURSALCLAVE"]).Trim() : ""; 
		item.Lun_hay = dataReader["LUN_HAY"] != System.DBNull.Value && ((string)dataReader["LUN_HAY"]).Trim() == "S" ? BoolCN.S : BoolCN.N; 
		item.Mar_hay = dataReader["MAR_HAY"] != System.DBNull.Value && ((string)dataReader["MAR_HAY"]).Trim() == "S" ? BoolCN.S : BoolCN.N; 
		item.Mie_hay = dataReader["MIE_HAY"] != System.DBNull.Value && ((string)dataReader["MIE_HAY"]).Trim() == "S" ? BoolCN.S : BoolCN.N; 
		item.Jue_hay = dataReader["JUE_HAY"] != System.DBNull.Value && ((string)dataReader["JUE_HAY"]).Trim() == "S" ? BoolCN.S : BoolCN.N; 
		item.Vie_hay = dataReader["VIE_HAY"] != System.DBNull.Value && ((string)dataReader["VIE_HAY"]).Trim() == "S" ? BoolCN.S : BoolCN.N; 
		item.Sab_hay = dataReader["SAB_HAY"] != System.DBNull.Value && ((string)dataReader["SAB_HAY"]).Trim() == "S" ? BoolCN.S : BoolCN.N; 
		item.Dom_hay = dataReader["DOM_HAY"] != System.DBNull.Value && ((string)dataReader["DOM_HAY"]).Trim() == "S" ? BoolCN.S : BoolCN.N; 
		item.Activo = dataReader["ACTIVO"] != System.DBNull.Value && ((string)dataReader["ACTIVO"]).Trim() == "N" ? BoolCS.N : BoolCS.S;         
		item.Lun_max = dataReader["LUN_MAX"] != System.DBNull.Value ? (decimal)dataReader["LUN_MAX"] : 0;         
		item.Mar_max = dataReader["MAR_MAX"] != System.DBNull.Value ? (decimal)dataReader["MAR_MAX"] : 0;         
		item.Mie_max = dataReader["MIE_MAX"] != System.DBNull.Value ? (decimal)dataReader["MIE_MAX"] : 0;         
		item.Jue_max = dataReader["JUE_MAX"] != System.DBNull.Value ? (decimal)dataReader["JUE_MAX"] : 0;         
		item.Vie_max = dataReader["VIE_MAX"] != System.DBNull.Value ? (decimal)dataReader["VIE_MAX"] : 0;         
		item.Sab_max = dataReader["SAB_MAX"] != System.DBNull.Value ? (decimal)dataReader["SAB_MAX"] : 0;         
		item.Dom_max = dataReader["DOM_MAX"] != System.DBNull.Value ? (decimal)dataReader["DOM_MAX"] : 0; 
		item.Anio = dataReader["ANIO"] != System.DBNull.Value ? int.Parse((string)dataReader["ANIO"]) : (int?)null; 
		item.Mes = dataReader["MES"] != System.DBNull.Value ? int.Parse((string)dataReader["MES"]) : (int?)null; 

	


            if (existItem)
                localContext.Maxfact.Update(item);
            else
                localContext.Maxfact.Add(item);

            localContext.SaveChanges();

            return true;
        }



    }
}


