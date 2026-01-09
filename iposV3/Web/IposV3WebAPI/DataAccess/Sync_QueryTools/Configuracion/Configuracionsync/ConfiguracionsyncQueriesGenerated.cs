using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryTools
{
    public class ConfiguracionsyncQueriesGenerated
    {


        public static string InsertQuery
        {
            get {
                return "configuracion.fnc_configuracionsync_insert";
            }
        }
        public static string UpdateQuery
        {
            get
            {
                return "configuracion.fnc_configuracionsync_update";
            }
        }
        public static string DeleteQuery
        {
            get
            {
                return "configuracion.fnc_configuracionsync_delete";
            }
        }
        public static string SelectQuery
        {
            get
            {
               return  @"configuracion.SelectConfiguracionsync";
            }
        }
        public static string Select_Query
        {
            get
            {
                return @"Select * from configuracion.v_Configuracionsync";
            }
        }
        public static string SelectByIdQuery
        {
            get
            {
                return @"configuracion.SelectConfiguracionsyncById";
            }
        }
        public static string Select_ByIdQuery
        {
            get
            {
                return @"Select * from configuracion.v_configuracionsync configuracionsync where 
						configuracionsync.empresaid = @p_empresaid and
						configuracionsync.sucursalid = @p_sucursalid and
						configuracionsync.id = @p_id";
            }
        }



        public static string SelectQueryList
        {
            get
            {
                return @"SELECT        *
                        FROM            configuracion.v_configuracionsync
                        WHERE        (empresaid = @p_empresaid) AND (sucursalid = @p_sucursalid)";
            }
        }

        public static string SelectQueryForSelector
        {
            get
            { 
		return @"SELECT   empresaid empresaid, sucursalid sucursalid, id id, clave clave, nombre nombre
                        FROM            configuracion.v_configuracionsync
                        WHERE        (empresaid = @p_empresaid) AND (sucursalid = @p_sucursalid)"; 
	    }
        }

    }
}

