
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



    public class ListapreciodetalleImpoExpoService : BaseImpoExpoService
    {




        public override bool ImportFromFirebirdReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               FbDataReader dataReader, ApplicationDbContext localContext)
        {

            //var clave = dataReader["clave"] != System.DBNull.Value ? ((string)dataReader["clave"]).Trim() : "";

	
	    var ListaprecioClave = dataReader["LISTAPRECIOCLAVE"] != System.DBNull.Value ? ((string)dataReader["LISTAPRECIOCLAVE"]).Trim() : "";
	
	    var ProductoClave = dataReader["PRODUCTOCLAVE"] != System.DBNull.Value ? ((string)dataReader["PRODUCTOCLAVE"]).Trim() : "";


            var ListaprecioClave_obj = localContext.Listaprecio.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == ListaprecioClave);

            var ProductoClave_obj = localContext.Producto.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == ProductoClave);

            if (ListaprecioClave_obj == null || ProductoClave_obj == null)
                return false;


            var itemSaved = localContext.Listapreciodetalle.AsNoTracking()
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Listaprecioid == ListaprecioClave_obj.Id && i.Productoid == ProductoClave_obj.Id);

	

            var item = itemSaved != null ? itemSaved : new Listapreciodetalle();
            var existItem = itemSaved != null;

            if (!existItem)
                item.CreadoPorId = usuarioId;

            item.EmpresaId = empresaId;
            item.SucursalId = sucursalId;
            item.ModificadoPorId = usuarioId;

            item.Tienevig = dataReader["TIENEVIG"] != System.DBNull.Value && ((string)dataReader["TIENEVIG"]).Trim() == "S" ? BoolCN.S : BoolCN.N; 
		item.Activo = dataReader["ACTIVO"] != System.DBNull.Value && ((string)dataReader["ACTIVO"]).Trim() == "N" ? BoolCS.N : BoolCS.S;         
		item.Precio1 = dataReader["PRECIO1"] != System.DBNull.Value ? (decimal)dataReader["PRECIO1"] : 0;         
		item.Precio2 = dataReader["PRECIO2"] != System.DBNull.Value ? (decimal)dataReader["PRECIO2"] : 0;         
		item.Precio3 = dataReader["PRECIO3"] != System.DBNull.Value ? (decimal)dataReader["PRECIO3"] : 0;         
		item.Precio4 = dataReader["PRECIO4"] != System.DBNull.Value ? (decimal)dataReader["PRECIO4"] : 0;         
		item.Precio5 = dataReader["PRECIO5"] != System.DBNull.Value ? (decimal)dataReader["PRECIO5"] : 0;         
		item.Precio6 = dataReader["PRECIO6"] != System.DBNull.Value ? (decimal)dataReader["PRECIO6"] : 0;         
		item.Costoreposicion = dataReader["COSTOREPOSICION"] != System.DBNull.Value ? (decimal)dataReader["COSTOREPOSICION"] : 0;         
		item.Fechavig = dataReader["FECHAVIG"] != System.DBNull.Value ? (DateTimeOffset)dataReader["FECHAVIG"] : null; 
		
	
            if (ListaprecioClave_obj != null)
                item.Listaprecioid = ListaprecioClave_obj.Id;
            else
                item.Listaprecioid = null;
	
            if (ProductoClave_obj != null)
                item.Productoid = ProductoClave_obj.Id;
            else
                item.Productoid = null;



            if (existItem)
                localContext.Listapreciodetalle.Update(item);
            else
                localContext.Listapreciodetalle.Add(item);

            localContext.SaveChanges();

            return true;
        }



    }
}


