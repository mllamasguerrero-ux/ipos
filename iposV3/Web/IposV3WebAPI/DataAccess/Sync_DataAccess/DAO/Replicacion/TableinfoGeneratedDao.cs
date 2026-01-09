using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Npgsql;
using System.Linq;
using System.Threading.Tasks;
using BIPOS.Database;
using NpgsqlTypes;
using DataAccess;
using IposV3.Model.Syncr;
using IposV3.Model;

namespace BIPOS.Database.DAO
{
  public class TableinfoGeneratedDao : BaseDao<Tableinfo, TableinfoParam>
  {


    public TableinfoGeneratedDao(string connectionString) : base(connectionString) 
    {
    }


    public TableinfoGeneratedDao(NpgsqlConnection sqlConnection) : base(sqlConnection) { }

    public TableinfoGeneratedDao(Func<string> connectionMethod) : base(connectionMethod) { }


    protected override void putQueryStrings()
    {

      insertQuery = TableinfoQueries.InsertQuery;
      updateQuery = TableinfoQueries.UpdateQuery;
      deleteQuery = TableinfoQueries.DeleteQuery;
      selectQuery = TableinfoQueries.SelectQuery;
      select_Query = TableinfoQueries.Select_Query;
      selectByIdQuery = TableinfoQueries.SelectByIdQuery;
      select_ByIdQuery = TableinfoQueries.Select_ByIdQuery;
    }

    protected override NpgsqlDbType sqlDbTypeByField(string field)
    {
      switch(field)
      {
        case "Empresaid":
          return NpgsqlDbType.Bigint;
        case "Sucursalid":
          return NpgsqlDbType.Bigint;
        case "Id":
          return NpgsqlDbType.Bigint;
        case "Activo":
          return NpgsqlDbType.Varchar;
        case "Creado":
          return NpgsqlDbType.Timestamp;
        case "Creadopor_userid":
          return NpgsqlDbType.Bigint;
        case "Modificado":
          return NpgsqlDbType.Timestamp;
        case "Modificadopor_userid":
          return NpgsqlDbType.Bigint;
        case "Tablename":
          return NpgsqlDbType.Char;
        case "Schemaname":
          return NpgsqlDbType.Char;
      }


      throw new Exception("Field not in list");
    }



    protected override Object? objByField(string field, Tableinfo item)
    {
      switch (field)
      {
	
        case "Empresaid":
          return item.Empresaid;
        case "Sucursalid":
          return item.Sucursalid;
        case "Id":
          return item.Id;
        case "Creado":
          return item.Creado;
        case "Creadopor_userid":
          return item.Creadopor_userid;
        case "Modificado":
          return item.Modificado;
        case "Modificadopor_userid":
          return item.Modificadopor_userid;
        case "Tablename":
          return item.Tablename;
        case "Schemaname":
          return item.Schemaname;
        case "Activo":
          return item.Activo != null ? item.Activo: "N";
      }

      throw new Exception("Field not in list");
    }
    

    protected override void putValueFromReader(string field, DbDataReader dataReader, string prefix, ref Tableinfo item)
    {
      switch (field)
      {
	
        case "Activo":
          item.Activo = dataReader["activo"] != System.DBNull.Value ? (string)dataReader["activo"] : null; break;
        case "Tablename":
          item.Tablename = dataReader["tablename"] != System.DBNull.Value ? (string)dataReader["tablename"] : null; break;
        case "Schemaname":
          item.Schemaname = dataReader["schemaname"] != System.DBNull.Value ? (string)dataReader["schemaname"] : null; break;        
        case "Empresaid":
          item.Empresaid = dataReader["empresaid"] != System.DBNull.Value ? (long?)dataReader["empresaid"] : null; break;        
        case "Sucursalid":
          item.Sucursalid = dataReader["sucursalid"] != System.DBNull.Value ? (long?)dataReader["sucursalid"] : null; break;        
        case "Id":
          item.Id = dataReader["id"] != System.DBNull.Value ? (long?)dataReader["id"] : null; break;        
        case "Creado":
          item.Creado = dataReader["creado"] != System.DBNull.Value ? (DateTime?)dataReader["creado"] : null; break;        
        case "Creadopor_userid":
          item.Creadopor_userid = dataReader["creadopor_userid"] != System.DBNull.Value ? (long?)dataReader["creadopor_userid"] : null; break;        
        case "Modificado":
          item.Modificado = dataReader["modificado"] != System.DBNull.Value ? (DateTime?)dataReader["modificado"] : null; break;        
        case "Modificadopor_userid":
          item.Modificadopor_userid = dataReader["modificadopor_userid"] != System.DBNull.Value ? (long?)dataReader["modificadopor_userid"] : null; break;
        default: throw new Exception("Field not in list");
      }

      
    }




    /*Insert*/

    protected override List<DbParameter> fillStandardParametersForInsert(Tableinfo item)
    {
      List<string> fieldNames = new List<string>(new string[] {
        "Empresaid","Sucursalid","Activo","Creadopor_userid","Tablename","Schemaname"});

      return this.fillStandardParameters(fieldNames, item);
    }
    



    /*Update*/
    protected override List<DbParameter> fillStandardParametersForUpdate(Tableinfo item)
    {
      List<string> fieldNames = new List<string>(new string[] {
        "Empresaid","Sucursalid","Id","Activo","Modificadopor_userid","Tablename","Schemaname"});
      return this.fillStandardParameters(fieldNames, item);
    }


    /*Delete*/
    protected override List<DbParameter> fillStandardParametersForDelete(Tableinfo item)
    {
      List<string> fieldNames = new List<string>(new string[] {
        "Empresaid","Sucursalid","Id" });
      return this.fillStandardParameters(fieldNames, item);
    }



    /*Selects*/

    protected override List<DbParameter> fillStandardParametersForSelectByKey(Tableinfo item)
    {
      List<string> fieldNames = new List<string>(new string[] {
        "Empresaid","Sucursalid","Id" });
      return this.fillStandardParameters(fieldNames, item);
    }
    
    protected override Tableinfo fillEntityFromReader(DbDataReader dr)
    {
        Tableinfo item = new Tableinfo();
        List<string> fieldNames = new List<string>(new string[] {
        "Empresaid","Sucursalid","Id","Activo","Creado","Creadopor_userid","Modificado","Modificadopor_userid","Tablename","Schemaname" });
        fillEntityFromReader(fieldNames,dr, ref item);
        return item;
    }


     /*Select list region*/

    protected override void putQueryStringsList()
    {

            selectQueryList = TableinfoQueries.SelectQueryList;

            selectQueryForSelector = TableinfoQueries.SelectQueryForSelector;
        
    }

    protected override NpgsqlDbType sqlDbTypeByFieldParam(string field)
    {
      switch(field)
      {
        case "P_empresaid":
          return NpgsqlDbType.Bigint;
        case "P_sucursalid":
          return NpgsqlDbType.Bigint;
      }


      throw new Exception("Field not in list");
    }



    protected override Object? objByFieldParam(string field, TableinfoParam item)
    {
      switch (field)
      {
	
        case "P_empresaid":
          return item.P_empresaid;
        case "P_sucursalid":
          return item.P_sucursalid;
      }

      throw new Exception("Field not in list");
    }



    protected override List<DbParameter> fillStandardParametersForSelectList(TableinfoParam? item)
    {
      List<string> fieldNames = new List<string>(new string[] {
        "P_empresaid","P_sucursalid" });
      return this.fillStandardParametersList(fieldNames, item);
    }
    
    
     /*End select list region*/


        //views
	
        public List<V_field_infoResult> Select_V_field_info_List(NpgsqlTransaction? st, V_field_infoParam param, KendoParams? kendoParams)
        {
            V_field_infoGeneratedListDao dao = new V_field_infoGeneratedListDao(this.ConnectionString);//(this.ConnectionMethod);
            return dao.SelectList(st, param, kendoParams);
        }

        public V_field_infoResult? Select_V_field_info_First(NpgsqlTransaction st, V_field_infoParam param)
        {
            V_field_infoGeneratedListDao dao = new V_field_infoGeneratedListDao(this.ConnectionString);//(this.ConnectionMethod);
            return dao.SelectFirst(st, param);
        }


        //commands
	

        //impo-expo
	

  }


    public class TableinfoQueries
    {


        public static string InsertQuery
        {
            get
            {
                return "public.fnc_tableinfo_insert";
            }
        }
        public static string UpdateQuery
        {
            get
            {
                return "public.fnc_tableinfo_update";
            }
        }
        public static string DeleteQuery
        {
            get
            {
                return "public.fnc_tableinfo_delete";
            }
        }
        public static string SelectQuery
        {
            get
            {
                return @"public.SelectTableinfo";
            }
        }
        public static string Select_Query
        {
            get
            {
                return @"Select * from public.v_Tableinfo";
            }
        }
        public static string SelectByIdQuery
        {
            get
            {
                return @"public.SelectTableinfoById";
            }
        }
        public static string Select_ByIdQuery
        {
            get
            {
                return @"Select * from public.v_tableinfo tableinfo where 
						tableinfo.empresaid = @p_empresaid and
						tableinfo.sucursalid = @p_sucursalid and
						tableinfo.id = @p_id";
            }
        }



        public static string SelectQueryList
        {
            get
            {
                return @"SELECT        *
                        FROM            public.v_tableinfo
                        WHERE        (empresaid = @p_empresaid) AND (sucursalid = @p_sucursalid)";
            }
        }

        public static string SelectQueryForSelector
        {
            get
            {
                return @"SELECT   empresaid empresaid, sucursalid sucursalid, id id, tablename clave, tablename nombre
                        FROM            public.v_tableinfo
                        WHERE        (empresaid = @p_empresaid) AND (sucursalid = @p_sucursalid)";
            }
        }

    }
}
