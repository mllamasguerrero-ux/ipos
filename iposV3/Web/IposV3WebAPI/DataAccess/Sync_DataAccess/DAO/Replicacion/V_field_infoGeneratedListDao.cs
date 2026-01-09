
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Npgsql;
using System.Linq;
using System.Threading.Tasks;
using IposV3.Model.Syncr;
using IposV3.Model;
using BIPOS.Database;
using NpgsqlTypes;

namespace BIPOS.Database.DAO
{
  public class V_field_infoGeneratedListDao : BaseListDao<V_field_infoResult, V_field_infoParam>
  {


    public V_field_infoGeneratedListDao(string? connectionString) : base(connectionString) 
    {
    }


    public V_field_infoGeneratedListDao(NpgsqlConnection sqlConnection) : base(sqlConnection) { }

    public V_field_infoGeneratedListDao(Func<string> connectionMethod) : base(connectionMethod) { }


    protected override void putQueryStringsList()
    {

            selectQueryList = V_field_infoVQueriesGenerated.SelectQueryList;
    }

    protected override NpgsqlDbType sqlDbTypeByFieldParam(string field)
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
        case "Table_name":
          return NpgsqlDbType.Char;
        case "Column_name":
          return NpgsqlDbType.Char;
        case "Is_nullable":
          return NpgsqlDbType.Char;
        case "Data_type":
          return NpgsqlDbType.Char;
        case "Identidad":
          return NpgsqlDbType.Char;
        case "Size":
          return NpgsqlDbType.Integer;
        case "Numeric_precision":
          return NpgsqlDbType.Integer;
        case "Numeric_scale":
          return NpgsqlDbType.Integer;
        case "Is_key":
          return NpgsqlDbType.Char;
        case "P_empresaid":
          return NpgsqlDbType.Bigint;
        case "P_sucursalid":
          return NpgsqlDbType.Bigint;
        case "P_tablename":
          return NpgsqlDbType.Char;
        case "P_schemaname":
          return NpgsqlDbType.Char;
      }


      throw new Exception("Field not in list");
    }



    protected override Object? objByFieldParam(string field, V_field_infoParam item)
    {
      switch (field)
      {
	
	
        case "P_empresaid":
          return item.P_empresaid;
        case "P_sucursalid":
          return item.P_sucursalid;
        case "P_tablename":
          return item.P_tablename;
        case "P_schemaname":
          return item.P_schemaname;
      }

      throw new Exception("Field not in list");
    }
    

    protected override void putValueFromReader(string field, DbDataReader dataReader, string prefix, ref V_field_infoResult item)
    {
      switch (field)
      {
	
	
        case "Activo":
          item.Activo = dataReader["activo"] != System.DBNull.Value ? (string)dataReader["activo"] : null; break;
        case "Table_name":
          item.Table_name = dataReader["table_name"] != System.DBNull.Value ? (string)dataReader["table_name"] : null; break;
        case "Column_name":
          item.Column_name = dataReader["column_name"] != System.DBNull.Value ? (string)dataReader["column_name"] : null; break;
        case "Is_nullable":
          item.Is_nullable = dataReader["is_nullable"] != System.DBNull.Value ? (string)dataReader["is_nullable"] : null; break;
        case "Data_type":
          item.Data_type = dataReader["data_type"] != System.DBNull.Value ? (string)dataReader["data_type"] : null; break;
        case "Identidad":
          item.Identidad = dataReader["identidad"] != System.DBNull.Value ? (string)dataReader["identidad"] : null; break;
        case "Is_key":
          item.Is_key = dataReader["is_key"] != System.DBNull.Value ? (string)dataReader["is_key"] : null; break;        
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
        case "Size":
          item.Size = dataReader["size"] != System.DBNull.Value ? (int?)dataReader["size"] : null; break;        
        case "Numeric_precision":
          item.Numeric_precision = dataReader["numeric_precision"] != System.DBNull.Value ? (int?)dataReader["numeric_precision"] : null; break;        
        case "Numeric_scale":
          item.Numeric_scale = dataReader["numeric_scale"] != System.DBNull.Value ? (int?)dataReader["numeric_scale"] : null; break;
        default: throw new Exception("Field not in list");
      }

      
    }





    /*Selects*/
    protected override List<DbParameter> fillStandardParametersForSelectList(V_field_infoParam? item)
    {//teet3
      List<string> fieldNames = new List<string>(new string[] {
        "P_empresaid","P_sucursalid","P_tablename","P_schemaname" });
      return this.fillStandardParametersList(fieldNames, item);
    }
    
    protected override V_field_infoResult fillEntityFromReader(DbDataReader dr)
    {
        V_field_infoResult item = new V_field_infoResult();
        List<string> fieldNames = new List<string>(new string[] {
        "Empresaid","Sucursalid","Id","Activo","Creado","Creadopor_userid","Modificado","Modificadopor_userid","Table_name","Column_name","Is_nullable","Data_type","Identidad","Size","Numeric_precision","Numeric_scale","Is_key" });
        fillEntityFromReader(fieldNames,dr, ref item);
        return item;

    }



  }


    public class V_field_infoVQueriesGenerated
    {

        public static string SelectQueryList
        {
            get
            {
                return @"SELECT 
    :p_empresaid  empresaid, 
    :p_sucursalid  sucursalid, 
    :p_empresaid  id,
      'S'  activo,
      CURRENT_TIMESTAMP creado,
      null   creadopor_userid,
      CURRENT_TIMESTAMP modificado,
      null   modificadopor_userid,
        
      tc.table_name,
      tc.column_name,
      tc.is_nullable,
      case when upper(tc.data_type) = 'CHARACTER VARYING' THEN 'VARCHAR' 
           when upper(tc.data_type) = 'CHARACTER' THEN 'CHAR' 
                ELSE upper(tc.data_type) END data_type, 
      'NO'  IDENTIDAD, 
      tc.CHARACTER_MAXIMUM_LENGTH SIZE, 
      tc.numeric_precision,
      tc.numeric_scale,
      coalesce(gc.IS_KEY, 'NO' ) IS_KEY
      
FROM information_schema.columns tc left join
(select ts.table_schema , ts.table_name, kc.column_name , 
  'YES'  IS_KEY
  from information_schema.table_constraints ts
  join information_schema.key_column_usage kc
    on kc.table_name = ts.table_name and kc.table_schema = ts.table_schema and kc.constraint_name = ts.constraint_name
where ts.constraint_type = 'PRIMARY KEY' 
  group by ts.table_schema , ts.table_name, kc.column_name) gc on
        gc.table_schema = tc.table_schema and
        gc.table_name = tc.table_name and
        gc.column_name = tc.column_name
       where   tc.table_name = :p_tablename
 and tc.table_schema = :p_schemaname
               ORDER BY tc.ordinal_position";
            }
        }
    }
}
