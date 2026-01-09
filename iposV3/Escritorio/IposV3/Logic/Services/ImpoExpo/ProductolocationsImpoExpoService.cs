
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



    public class ProductolocationsImpoExpoService : BaseImpoExpoService
    {



        public override bool ImportFromFirebirdReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               FbDataReader dataReader, ApplicationDbContext localContext)
        {

           // var clave = dataReader["clave"] != System.DBNull.Value ? ((string)dataReader["clave"]).Trim() : "";

	
	    var ProductoClave = dataReader["PRODUCTOCLAVE"] != System.DBNull.Value ? ((string)dataReader["PRODUCTOCLAVE"]).Trim() : "";
	
	    var AnaquelClave = dataReader["ANAQUELCLAVE"] != System.DBNull.Value ? ((string)dataReader["ANAQUELCLAVE"]).Trim() : "";
	
	    var AlmacenClave = dataReader["ALMACENCLAVE"] != System.DBNull.Value ? ((string)dataReader["ALMACENCLAVE"]).Trim() : "";


	
            var ProductoClave_obj = localContext.Producto.AsNoTracking()
                                        	.FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == ProductoClave);
	
            var AnaquelClave_obj = localContext.Anaquel.AsNoTracking()
                                        	.FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == AnaquelClave);
	
            var AlmacenClave_obj = localContext.Almacen.AsNoTracking()
                                        	.FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == AlmacenClave);

            if (ProductoClave_obj == null || AnaquelClave_obj == null )
                return false;


            var itemSaved = localContext.Productolocations
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Productoid == ProductoClave_obj.Id && i.Anaquelid == AnaquelClave_obj.Id && 
                                                             (AlmacenClave_obj == null || i.Almacenid == AlmacenClave_obj.Id));

            var item = itemSaved != null ? itemSaved : new Productolocations();
            var existItem = itemSaved != null;

            if (!existItem)
                item.CreadoPorId = usuarioId;

            item.EmpresaId = empresaId;
            item.SucursalId = sucursalId;
            item.ModificadoPorId = usuarioId;


            item.Localidad = dataReader["LOCALIDAD"] != System.DBNull.Value ? ((string)dataReader["LOCALIDAD"]).Trim() : ""; 
          	item.Activo = dataReader["ACTIVO"] != System.DBNull.Value && ((string)dataReader["ACTIVO"]).Trim() == "N" ? BoolCS.N : BoolCS.S;         
		
	
            if (ProductoClave_obj != null)
                item.Productoid = ProductoClave_obj.Id;
            else
                item.Productoid = null;
	
            if (AnaquelClave_obj != null)
                item.Anaquelid = AnaquelClave_obj.Id;
            else
                item.Anaquelid = null;
	
            if (AlmacenClave_obj != null)
                item.Almacenid = AlmacenClave_obj.Id;
            else
                item.Almacenid = null;



            if (existItem)
                localContext.Productolocations.Update(item);
            else
                localContext.Productolocations.Add(item);

            localContext.SaveChanges();

            return true;
        }



    }
}


