using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Npgsql;
using System.Linq;
using System.Threading.Tasks;
using IposV3.Model.Syncr;
using BIPOS.Database;
using NpgsqlTypes;
using DataAccess;

namespace BIPOS.Database.DAO
{
  public class ConfiguracionsyncGeneratedDao : BaseDao<Configuracionsync, ConfiguracionsyncParam>,IConfiguracionsyncDaoProviderGenerated
  {


    public ConfiguracionsyncGeneratedDao(string connectionString) : base(connectionString) 
    {
    }


    public ConfiguracionsyncGeneratedDao(NpgsqlConnection sqlConnection) : base(sqlConnection) { }

    public ConfiguracionsyncGeneratedDao(Func<string> connectionMethod) : base(connectionMethod) { }


    protected override void putQueryStrings()
    {

      insertQuery = QueryTools.ConfiguracionsyncQueries.InsertQuery;
      updateQuery = QueryTools.ConfiguracionsyncQueries.UpdateQuery;
      deleteQuery = QueryTools.ConfiguracionsyncQueries.DeleteQuery;
      selectQuery = QueryTools.ConfiguracionsyncQueries.SelectQuery;
      select_Query = QueryTools.ConfiguracionsyncQueries.Select_Query;
      selectByIdQuery = QueryTools.ConfiguracionsyncQueries.SelectByIdQuery;
      select_ByIdQuery = QueryTools.ConfiguracionsyncQueries.Select_ByIdQuery;
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
        case "Empresaclave":
          return NpgsqlDbType.Char;
        case "Empresanombre":
          return NpgsqlDbType.Char;
        case "Sucursalclave":
          return NpgsqlDbType.Char;
        case "Sucursalnombre":
          return NpgsqlDbType.Char;
        case "Dblocal":
          return NpgsqlDbType.Char;
        case "Usuariolocal":
          return NpgsqlDbType.Char;
        case "Passwordlocal":
          return NpgsqlDbType.Char;
        case "Dbdestino":
          return NpgsqlDbType.Char;
        case "Usuariodestino":
          return NpgsqlDbType.Char;
        case "Passworddestino":
          return NpgsqlDbType.Char;
        case "Dbtype":
          return NpgsqlDbType.Char;
        case "Logactivo":
          return NpgsqlDbType.Char;
        case "Lastlog":
          return NpgsqlDbType.Integer;
        case "Firstlog":
          return NpgsqlDbType.Integer;
        case "Correraliniciar":
          return NpgsqlDbType.Char;
        case "Limitarhora":
          return NpgsqlDbType.Char;
        case "Horainicial":
          return NpgsqlDbType.Char;
        case "Horafinal":
          return NpgsqlDbType.Char;
        case "Esperaentreenvios":
          return NpgsqlDbType.Integer;
        case "Timeformat":
          return NpgsqlDbType.Char;
        case "Nummaxregistros":
          return NpgsqlDbType.Char;
        case "Usuarioiposlocal":
          return NpgsqlDbType.Char;
        case "Passwordiposlocal":
          return NpgsqlDbType.Char;
        case "Activarreplicacion":
          return NpgsqlDbType.Char;
        case "Activarsyncsuc":
          return NpgsqlDbType.Char;
        case "Serverlocal":
          return NpgsqlDbType.Char;
        case "Serverdestino":
          return NpgsqlDbType.Char;
        case "Portlocal":
          return NpgsqlDbType.Char;
        case "Portdestino":
          return NpgsqlDbType.Char;
      }


      throw new Exception("Field not in list");
    }



    protected override Object? objByField(string field, Configuracionsync item)
    {
      switch (field)
      {
	
        case "Empresaid":
          return item.Empresaid;
        case "Sucursalid":
          return item.Sucursalid;
        case "Id":
          return item.Id;
        case "Activo":
          return item.Activo;
        case "Creado":
          return item.Creado;
        case "Creadopor_userid":
          return item.Creadopor_userid;
        case "Modificado":
          return item.Modificado;
        case "Modificadopor_userid":
          return item.Modificadopor_userid;
        case "Empresaclave":
          return item.Empresaclave;
        case "Empresanombre":
          return item.Empresanombre;
        case "Sucursalclave":
          return item.Sucursalclave;
        case "Sucursalnombre":
          return item.Sucursalnombre;
        case "Dblocal":
          return item.Dblocal;
        case "Usuariolocal":
          return item.Usuariolocal;
        case "Passwordlocal":
          return item.Passwordlocal;
        case "Dbdestino":
          return item.Dbdestino;
        case "Usuariodestino":
          return item.Usuariodestino;
        case "Passworddestino":
          return item.Passworddestino;
        case "Dbtype":
          return item.Dbtype;
        case "Lastlog":
          return item.Lastlog;
        case "Firstlog":
          return item.Firstlog;
        case "Limitarhora":
          return item.Limitarhora;
        case "Horainicial":
          return item.Horainicial;
        case "Horafinal":
          return item.Horafinal;
        case "Esperaentreenvios":
          return item.Esperaentreenvios;
        case "Timeformat":
          return item.Timeformat;
        case "Nummaxregistros":
          return item.Nummaxregistros;
        case "Usuarioiposlocal":
          return item.Usuarioiposlocal;
        case "Passwordiposlocal":
          return item.Passwordiposlocal;
        case "Serverlocal":
          return item.Serverlocal;
        case "Serverdestino":
          return item.Serverdestino;
        case "Portlocal":
          return item.Portlocal;
        case "Portdestino":
          return item.Portdestino;
        case "Logactivo":
          return item.Logactivo != null ? item.Logactivo: "N";
        case "Correraliniciar":
          return item.Correraliniciar != null ? item.Correraliniciar: "N";
        case "Activarreplicacion":
          return item.Activarreplicacion != null ? item.Activarreplicacion: "N";
        case "Activarsyncsuc":
          return item.Activarsyncsuc != null ? item.Activarsyncsuc: "N";
      }

      throw new Exception("Field not in list");
    }
    

    protected override void putValueFromReader(string field, DbDataReader dataReader, string prefix, ref Configuracionsync item)
    {
      switch (field)
      {
	
        case "Activo":
          item.Activo = dataReader["activo"] != System.DBNull.Value ? (string)dataReader["activo"] : null; break;
        case "Empresaclave":
          item.Empresaclave = dataReader["empresaclave"] != System.DBNull.Value ? (string)dataReader["empresaclave"] : null; break;
        case "Empresanombre":
          item.Empresanombre = dataReader["empresanombre"] != System.DBNull.Value ? (string)dataReader["empresanombre"] : null; break;
        case "Sucursalclave":
          item.Sucursalclave = dataReader["sucursalclave"] != System.DBNull.Value ? (string)dataReader["sucursalclave"] : null; break;
        case "Sucursalnombre":
          item.Sucursalnombre = dataReader["sucursalnombre"] != System.DBNull.Value ? (string)dataReader["sucursalnombre"] : null; break;
        case "Dblocal":
          item.Dblocal = dataReader["dblocal"] != System.DBNull.Value ? (string)dataReader["dblocal"] : null; break;
        case "Usuariolocal":
          item.Usuariolocal = dataReader["usuariolocal"] != System.DBNull.Value ? (string)dataReader["usuariolocal"] : null; break;
        case "Passwordlocal":
          item.Passwordlocal = dataReader["passwordlocal"] != System.DBNull.Value ? (string)dataReader["passwordlocal"] : null; break;
        case "Dbdestino":
          item.Dbdestino = dataReader["dbdestino"] != System.DBNull.Value ? (string)dataReader["dbdestino"] : null; break;
        case "Usuariodestino":
          item.Usuariodestino = dataReader["usuariodestino"] != System.DBNull.Value ? (string)dataReader["usuariodestino"] : null; break;
        case "Passworddestino":
          item.Passworddestino = dataReader["passworddestino"] != System.DBNull.Value ? (string)dataReader["passworddestino"] : null; break;
        case "Dbtype":
          item.Dbtype = dataReader["dbtype"] != System.DBNull.Value ? (string)dataReader["dbtype"] : null; break;
        case "Logactivo":
          item.Logactivo = dataReader["logactivo"] != System.DBNull.Value ? (string)dataReader["logactivo"] : null; break;
        case "Correraliniciar":
          item.Correraliniciar = dataReader["correraliniciar"] != System.DBNull.Value ? (string)dataReader["correraliniciar"] : null; break;
        case "Limitarhora":
          item.Limitarhora = dataReader["limitarhora"] != System.DBNull.Value ? (string)dataReader["limitarhora"] : null; break;
        case "Horainicial":
          item.Horainicial = dataReader["horainicial"] != System.DBNull.Value ? (string)dataReader["horainicial"] : null; break;
        case "Horafinal":
          item.Horafinal = dataReader["horafinal"] != System.DBNull.Value ? (string)dataReader["horafinal"] : null; break;
        case "Timeformat":
          item.Timeformat = dataReader["timeformat"] != System.DBNull.Value ? (string)dataReader["timeformat"] : null; break;
        case "Nummaxregistros":
          item.Nummaxregistros = dataReader["nummaxregistros"] != System.DBNull.Value ? (string)dataReader["nummaxregistros"] : null; break;
        case "Usuarioiposlocal":
          item.Usuarioiposlocal = dataReader["usuarioiposlocal"] != System.DBNull.Value ? (string)dataReader["usuarioiposlocal"] : null; break;
        case "Passwordiposlocal":
          item.Passwordiposlocal = dataReader["passwordiposlocal"] != System.DBNull.Value ? (string)dataReader["passwordiposlocal"] : null; break;
        case "Activarreplicacion":
          item.Activarreplicacion = dataReader["activarreplicacion"] != System.DBNull.Value ? (string)dataReader["activarreplicacion"] : null; break;
        case "Activarsyncsuc":
          item.Activarsyncsuc = dataReader["activarsyncsuc"] != System.DBNull.Value ? (string)dataReader["activarsyncsuc"] : null; break;
        case "Serverlocal":
          item.Serverlocal = dataReader["serverlocal"] != System.DBNull.Value ? (string)dataReader["serverlocal"] : null; break;
        case "Serverdestino":
          item.Serverdestino = dataReader["serverdestino"] != System.DBNull.Value ? (string)dataReader["serverdestino"] : null; break;
        case "Portlocal":
          item.Portlocal = dataReader["portlocal"] != System.DBNull.Value ? (string)dataReader["portlocal"] : null; break;
        case "Portdestino":
          item.Portdestino = dataReader["portdestino"] != System.DBNull.Value ? (string)dataReader["portdestino"] : null; break;        
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
        case "Lastlog":
          item.Lastlog = dataReader["lastlog"] != System.DBNull.Value ? (int?)dataReader["lastlog"] : null; break;        
        case "Firstlog":
          item.Firstlog = dataReader["firstlog"] != System.DBNull.Value ? (int?)dataReader["firstlog"] : null; break;        
        case "Esperaentreenvios":
          item.Esperaentreenvios = dataReader["esperaentreenvios"] != System.DBNull.Value ? (int?)dataReader["esperaentreenvios"] : null; break;
        default: throw new Exception("Field not in list");
      }

      
    }




    /*Insert*/

    protected override List<DbParameter> fillStandardParametersForInsert(Configuracionsync item)
    {
      List<string> fieldNames = new List<string>(new string[] {
        "Empresaid","Sucursalid","Id","Activo","Creado","Creadopor_userid","Empresaclave","Empresanombre","Sucursalclave","Sucursalnombre","Dblocal","Usuariolocal","Passwordlocal","Dbdestino","Usuariodestino","Passworddestino","Dbtype","Logactivo","Lastlog","Firstlog","Correraliniciar","Limitarhora","Horainicial","Horafinal","Esperaentreenvios","Timeformat","Nummaxregistros","Usuarioiposlocal","Passwordiposlocal","Activarreplicacion","Activarsyncsuc","Serverlocal","Serverdestino","Portlocal","Portdestino"});

      return this.fillStandardParameters(fieldNames, item);
    }
    



    /*Update*/
    protected override List<DbParameter> fillStandardParametersForUpdate(Configuracionsync item)
    {
      List<string> fieldNames = new List<string>(new string[] {
        "Empresaid","Sucursalid","Id","Activo","Modificado","Modificadopor_userid","Empresaclave","Empresanombre","Sucursalclave","Sucursalnombre","Dblocal","Usuariolocal","Passwordlocal","Dbdestino","Usuariodestino","Passworddestino","Dbtype","Logactivo","Lastlog","Firstlog","Correraliniciar","Limitarhora","Horainicial","Horafinal","Esperaentreenvios","Timeformat","Nummaxregistros","Usuarioiposlocal","Passwordiposlocal","Activarreplicacion","Activarsyncsuc","Serverlocal","Serverdestino","Portlocal","Portdestino"});
      return this.fillStandardParameters(fieldNames, item);
    }


    /*Delete*/
    protected override List<DbParameter> fillStandardParametersForDelete(Configuracionsync item)
    {
      List<string> fieldNames = new List<string>(new string[] {
        "Empresaid","Sucursalid","Id" });
      return this.fillStandardParameters(fieldNames, item);
    }



    /*Selects*/

    protected override List<DbParameter> fillStandardParametersForSelectByKey(Configuracionsync item)
    {
      List<string> fieldNames = new List<string>(new string[] {
        "Empresaid","Sucursalid","Id" });
      return this.fillStandardParameters(fieldNames, item);
    }
    
    protected override Configuracionsync fillEntityFromReader(DbDataReader dr)
    {
        Configuracionsync item = new Configuracionsync();
        List<string> fieldNames = new List<string>(new string[] {
        "Empresaid","Sucursalid","Id","Activo","Creado","Creadopor_userid","Modificado","Modificadopor_userid","Empresaclave","Empresanombre","Sucursalclave","Sucursalnombre","Dblocal","Usuariolocal","Passwordlocal","Dbdestino","Usuariodestino","Passworddestino","Dbtype","Logactivo","Lastlog","Firstlog","Correraliniciar","Limitarhora","Horainicial","Horafinal","Esperaentreenvios","Timeformat","Nummaxregistros","Usuarioiposlocal","Passwordiposlocal","Activarreplicacion","Activarsyncsuc","Serverlocal","Serverdestino","Portlocal","Portdestino" });
        fillEntityFromReader(fieldNames,dr, ref item);
        return item;
    }


     /*Select list region*/

    protected override void putQueryStringsList()
    {

            selectQueryList = QueryTools.ConfiguracionsyncQueries.SelectQueryList;

            selectQueryForSelector = QueryTools.ConfiguracionsyncQueries.SelectQueryForSelector;
        
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



    protected override Object? objByFieldParam(string field, ConfiguracionsyncParam item)
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



    protected override List<DbParameter> fillStandardParametersForSelectList(ConfiguracionsyncParam? item)
    {
      List<string> fieldNames = new List<string>(new string[] {
        "P_empresaid","P_sucursalid" });
      return this.fillStandardParametersList(fieldNames, item);
    }
    
    
     /*End select list region*/


        //views
	

        //commands
	

        //impo-expo
	

  }
}
