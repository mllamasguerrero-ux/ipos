
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



    public class Perfil_derImpoExpoService : BaseImpoExpoService
    {



        public override bool ImportFromFirebirdReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               FbDataReader dataReader, ApplicationDbContext localContext)
        {

            //var clave = dataReader["clave"] != System.DBNull.Value ? ((string)dataReader["clave"]).Trim() : "";

	
	    var PerfilClave = dataReader["PERFILCLAVE"] != System.DBNull.Value ? ((string)dataReader["PERFILCLAVE"]).Trim() : "";
	
	    var DerechoClave = dataReader["DERECHOCLAVE"] != System.DBNull.Value ? ((string)dataReader["DERECHOCLAVE"]).Trim() : "";


	
            var PerfilClave_obj = localContext.Perfiles.AsNoTracking()
                                        	.FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Descripcion == PerfilClave);
	
            var DerechoClave_obj = localContext.Derechos.AsNoTracking()
                                        	.FirstOrDefault(i =>  i.Descripcion == DerechoClave);

            if (PerfilClave_obj == null || DerechoClave_obj == null)
                return false;

            var itemSaved = localContext.Perfil_der
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Perfilid == PerfilClave_obj.Id && i.Derechoid == DerechoClave_obj.Id);



            var item = itemSaved != null ? itemSaved : new Perfil_der();
            var existItem = itemSaved != null;

            if (!existItem)
                item.CreadoPorId = usuarioId;

            item.EmpresaId = empresaId;
            item.SucursalId = sucursalId;
            item.ModificadoPorId = usuarioId;

            item.Activo = BoolCS.S;         
		
	
            if (PerfilClave_obj != null)
                item.Perfilid = PerfilClave_obj.Id;
            else
                item.Perfilid = null;
	
            if (DerechoClave_obj != null)
                item.Derechoid = DerechoClave_obj.Id;
            else
                item.Derechoid = null;



            if (existItem)
                localContext.Perfil_der.Update(item);
            else
                localContext.Perfil_der.Add(item);

            localContext.SaveChanges();

            return true;
        }



    }
}


