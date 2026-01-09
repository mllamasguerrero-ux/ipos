using IposV3.Model;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;
using Npgsql;
using System.Data.Common;
using BIPOS.Database;
using IposV3.Services.Extensions;
using System.Data;
using BIPOS.Database.DAO;

namespace IposV3.Services
{
    public class ReplicacionService
    {

        TableinfoDao tableinfoDaoProvider;
        public ReplicacionService(TableinfoDao tableinfoDaoProvider)
        {
            this.tableinfoDaoProvider = tableinfoDaoProvider;
        }


        public List<TablasAReplicar> ListaTablasAReplicar(long empresaId, long sucursalId, ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            var lst = new List<TablasAReplicar>();

            try
            {
                var lstTablasAReplicar = localContext.Repltabla.AsNoTracking()
                                                    .Where(r => r.EmpresaId == empresaId && r.SucursalId == sucursalId && r.Activo == BoolCS.S)
                                                     .Select(r => new TablasAReplicar(r))
                                                     .ToList();

                var lstOtherTables = DBTableNames(localContext.ConnectionString!)
                                        .Select(n => new TablasAReplicar(n))
                                        .ToList()
                                        .Where(t => !lstTablasAReplicar.Any( l => l.Nombretabla == t.Nombretabla));


                lst.AddRange(lstTablasAReplicar);
                lst.AddRange(lstOtherTables);

                var lstGroupTablesBuffer = localContext.Repltablagroupdef.AsNoTracking().Include(g => g.Groupdef)
                    .ToList();

                var lstGroupTables = lstGroupTablesBuffer
                                                 .GroupBy(g => g.Nombretabla)
                                                 .Select(g => new
                                                 {
                                                     Nombretabla = g.Key ?? "",
                                                     Grupos = String.Join(", ", g.Select(n => n.Groupdef.Nombre))
                                                 }).ToList();
                foreach(var item in lst)
                {
                    var grupos = lstGroupTables?.FirstOrDefault(g => g.Nombretabla == item.Nombretabla)?.Grupos;
                    item.Grupos = grupos;
                }


                lst = lst.OrderBy(y => y.Nombretabla).ToList();

                return lst;


            }
            catch
            {
                throw;
            }
            finally
            {
                localContext.ChangeTracker.LazyLoadingEnabled = previousLazyLoadingEnabledValue;
            }

        }



        public List<GrupoTablasAReplicar> ListaGruposTablasAReplicar(long empresaId, long sucursalId, ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            var lst = new List<GrupoTablasAReplicar>();

            try
            {
                var lstGruposTablasAReplicar = localContext.Replgroup.AsNoTracking()
                                                    .Include(r => r.Groupdef).ThenInclude(g => g!.RepltablagroupdefSet)
                                                    .Where(r => r.EmpresaId == empresaId && r.SucursalId == sucursalId )
                                                     .Select(r => new GrupoTablasAReplicar(r))
                                                     .ToList();

                var lstOtrosGruposTablasAReplicar = localContext.Replgroupdef.AsNoTracking()
                                                     .Include(g => g.RepltablagroupdefSet)
                                                     .Select(r => new GrupoTablasAReplicar(empresaId, sucursalId, r))
                                                     .ToList()
                                                     .Where(y => !lstGruposTablasAReplicar.Any(l => l.Clave == y.Clave))
                                                     .ToList();


                lst.AddRange(lstGruposTablasAReplicar);
                lst.AddRange(lstOtrosGruposTablasAReplicar);

                lst = lst.OrderBy(y => y.Nombre).ToList();

                return lst;


            }
            catch
            {
                throw;
            }
            finally
            {
                localContext.ChangeTracker.LazyLoadingEnabled = previousLazyLoadingEnabledValue;
            }

        }


        private List<string> DBTableNames(string connectionString)
        {
            List<string> listToReturn = new List<string>();

            try
            {
                BaseDataAccess bda = new BaseDataAccess(connectionString);

                List<DbParameter> parameterList = new List<DbParameter>();

                string commandText = @"SELECT concat(schemaname , '.' , tablename) as tablename
		FROM pg_catalog.pg_tables where schemaname not in  ('pg_catalog','information_schema') and tablename not in ('__EFMigrationsHistory') ";

                using (DbDataReader dataReader = bda.GetDataReader( commandText, parameterList, System.Data.CommandType.Text))
                {
                    if (dataReader != null && dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            string item = dataReader["tablename"] != System.DBNull.Value ? (string)dataReader["tablename"] : ""; 
                            listToReturn.Add(item);
                        }
                    }
                }

                return listToReturn;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }


        public void Aplicar_cambios_tablas_a_replicar(long empresaId, long sucursalId, List<string> tablasAReplicar,
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {
                BaseDataAccess bda = new BaseDataAccess(localContext.ConnectionString);

                var arrayTablasAReplicar = tablasAReplicar.Select(t => t.Split('.').Last().ToLower()).ToArray();

                var lstGruposDefinicion = localContext.Replgroupdef.AsNoTracking()
                                                     .Include(g => g.RepltablagroupdefSet)
                                                     .ToList();


                var lstReplTablaSaved = localContext.Repltabla
                                                    .Where(r => r.EmpresaId == empresaId && r.SucursalId == sucursalId)
                                                    .ToList();

                var lstReplGroupTablaSaved = localContext.Replgroup
                                                    .Where(r => r.EmpresaId == empresaId && r.SucursalId == sucursalId)
                                                    .ToList();

                var lstReplTablaAInactivar = lstReplTablaSaved
                                                        .Where(r => r.Activo == BoolCS.S && r.Nombre != null && !r.Nombre.Split('.').Last().ToLower().In(arrayTablasAReplicar))
                                                        .ToList();
                var lstReplTablaAActivar = lstReplTablaSaved
                                                        .Where(r => r.Activo != BoolCS.S && r.Nombre != null && r.Nombre.Split('.').Last().ToLower().In(arrayTablasAReplicar))
                                                        .ToList();
                var lstReplTablaAInsertar = tablasAReplicar.Where(t => !t.In( lstReplTablaSaved
                                                                        .Select(r => r.Nombre)
                                                                        .ToArray())).ToList();

                var gruposSeleccionados  = lstGruposDefinicion.Where(g => g.RepltablagroupdefSet != null && g.RepltablagroupdefSet.All(t => t.Nombretabla!.Split('.').Last().ToLower().In(arrayTablasAReplicar)))
                                                            .Select(g => g.Id) 
                                                            .ToArray() ?? new long[0];

                var lstReplGroupTablaAInactivar = lstReplGroupTablaSaved
                                                        .Where(r => r.Activo == BoolCS.S && r.Idgroupdef != null && !r.Idgroupdef.Value.In<long>(gruposSeleccionados))
                                                        .ToList();

                var lstReplGroupTablaAActivar = lstReplGroupTablaSaved
                                                        .Where(r => r.Activo != BoolCS.S && r.Idgroupdef != null && r.Idgroupdef.Value.In(gruposSeleccionados))
                                                        .ToList();
                var lstReplGroupTablaAInsertar = gruposSeleccionados.Where(t => !t.In(lstReplGroupTablaSaved
                                                                        .Where(r => r.Idgroupdef != null)
                                                                        .Select(r => r.Idgroupdef != null ? r.Idgroupdef.Value : 0)
                                                                        .ToArray())).ToList();

                foreach(var item in lstReplTablaAActivar)
                {
                    item.Activo = BoolCS.S;
                    item.Replidinicio = 0;
                    item.Replidfin = MaxIdFromTable(item.Nombre ?? "", item.EmpresaId, item.SucursalId, ref  bda);
                    localContext.Update(item);
                }

                foreach (var item in lstReplTablaAInactivar)
                {
                    item.Activo = BoolCS.N;
                    localContext.Update(item);
                }


                foreach (var strItem in lstReplTablaAInsertar)
                {
                    var item = new Repltabla();
                    item.EmpresaId = empresaId;
                    item.SucursalId = sucursalId;
                    item.Creado = DateTimeOffset.UtcNow;
                    item.Modificado = DateTimeOffset.UtcNow;
                    item.Activo = BoolCS.S;
                    item.Nombre = strItem;
                    item.Replidinicio = 0;
                    item.Replidfin = MaxIdFromTable(item.Nombre ?? "", item.EmpresaId, item.SucursalId, ref bda);
                    localContext.Add(item);
                }


                foreach (var item in lstReplGroupTablaAActivar)
                {
                    item.Activo = BoolCS.S;
                    localContext.Update(item);
                }

                foreach (var item in lstReplGroupTablaAInactivar)
                {
                    item.Activo = BoolCS.N;
                    localContext.Update(item);
                }


                foreach (var idGrupo in lstReplGroupTablaAInsertar)
                {
                    var item = new Replgroup();
                    item.EmpresaId = empresaId;
                    item.SucursalId = sucursalId;
                    item.Creado = DateTimeOffset.UtcNow;
                    item.Modificado = DateTimeOffset.UtcNow;
                    item.Activo = BoolCS.S;
                    item.Idgroupdef = idGrupo;
                    localContext.Add(item);
                }


                localContext.SaveChanges();



                foreach (var tabla in lstReplTablaAInactivar)
                {
                    try
                    {
                        RemoveTableTriggers(tabla, ref bda);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }




                foreach (var tabla in lstReplTablaAActivar)
                {
                    try
                    {

                        var dictKeyFieldsPresent = new Dictionary<string, bool>();
                        dictKeyFieldsPresent.Add("EmpresaId", false);
                        dictKeyFieldsPresent.Add("SucursalId", false);
                        TableContainsFields(tabla.Nombre ?? "", ref bda, ref dictKeyFieldsPresent);

                        AddTableTriggers(tabla, ref bda, ref dictKeyFieldsPresent);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }


                foreach (var tablaNombre in lstReplTablaAInsertar)
                {
                    try
                    {
                        var tabla = localContext.Repltabla
                                                .FirstOrDefault(r => r.EmpresaId == empresaId && r.SucursalId == sucursalId &&
                                                                     r.Nombre == tablaNombre && r.Activo == BoolCS.S);

                        if (tabla != null)
                        {

                            var dictKeyFieldsPresent = new Dictionary<string, bool>();
                            dictKeyFieldsPresent.Add("EmpresaId", false);
                            dictKeyFieldsPresent.Add("SucursalId", false);
                            TableContainsFields(tabla.Nombre ?? "", ref bda, ref dictKeyFieldsPresent);

                            AddTableTriggers(tabla, ref bda, ref dictKeyFieldsPresent);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }




            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                localContext.ChangeTracker.LazyLoadingEnabled = previousLazyLoadingEnabledValue;
            }

        }


        public void TableContainsFields(string tableName, ref BaseDataAccess bda, ref Dictionary<string,bool> dictFields)
        {

            try
            {
                var splitedTableName = tableName.Split('.');
                string onlyTableName = splitedTableName.Last();
                string schemaName = splitedTableName.Count() > 1 ? splitedTableName.First() : "public";


                List<DbParameter> parameterList = new List<DbParameter>();

                string commandText = @$"SELECT column_name FROM information_schema.columns
                                        WHERE table_schema = '{schemaName}'
                                        AND table_name   = '{onlyTableName}'";

                foreach(var dictKey in dictFields.Keys)
                    dictFields[dictKey] = false;

                using (DbDataReader dataReader = bda.GetDataReader(commandText, parameterList, System.Data.CommandType.Text))
                {
                    if (dataReader != null && dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            string column_name = dataReader["column_name"] != System.DBNull.Value ? (string)dataReader["column_name"] : "";
                            if(dictFields.Keys.Contains(column_name))
                            {
                                dictFields[column_name] = true;
                            }
                        }
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw ;
            }
        }

        public long? MaxIdFromTable(string tableName, long empresaId, long sucursalId, ref BaseDataAccess bda)
        {
            long? maxId = 0;

            var dictKeyFieldsPresent = new Dictionary<string, bool>();
            dictKeyFieldsPresent.Add("EmpresaId", false);
            dictKeyFieldsPresent.Add("SucursalId", false);
            TableContainsFields(tableName, ref bda, ref dictKeyFieldsPresent);

            var commandText = @"select max(""Id"") id from """ + tableName.Replace(".", @""".""") + @"""";

            if (dictKeyFieldsPresent["EmpresaId"] && dictKeyFieldsPresent["SucursalId"])
                commandText += @" where ""EmpresaId"" = @empresaid and ""SucursalId"" = @sucursalid";
            else if (dictKeyFieldsPresent["EmpresaId"] && !dictKeyFieldsPresent["SucursalId"])
                commandText += @" where ""EmpresaId"" = @empresaid ";


            List<DbParameter> parameterList = new List<DbParameter>();
            parameterList.Add(bda.GetParameter("@sucursalid", sucursalId));
            parameterList.Add(bda.GetParameter("@empresaid", empresaId));

            using (DbDataReader dataReader = bda.GetDataReader(commandText, parameterList, CommandType.Text))
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    if (dataReader.Read())
                    {
                        maxId = dataReader["id"] != System.DBNull.Value ? (long?)dataReader["id"] : null;
                    }
                }
            }

            return maxId;
        }




        public bool AddTableTriggers(Repltabla tabla, ref BaseDataAccess bda, ref Dictionary<string, bool> camposClaveExistencia)
        {


            var commandText = RepltablaQueries.ReplicationInsert_Function(tabla.Nombre, tabla.Replcondinsert, ref camposClaveExistencia);

            List<DbParameter> parameterList = new List<DbParameter>();
            if (bda.ExecuteNonQuery(commandText, parameterList, CommandType.Text) >= -1)
            {
                commandText = RepltablaQueries.ReplicationInsert_Trigger(tabla.Nombre, tabla.Replcondinsert);
                if (bda.ExecuteNonQuery(commandText, parameterList, CommandType.Text) >= -1)
                {
                    commandText = RepltablaQueries.ReplicationUpdate_Function(tabla.Nombre, tabla.Replcondinsert, ref camposClaveExistencia);
                    if (bda.ExecuteNonQuery(commandText, parameterList, CommandType.Text) >= -1)
                    {
                        commandText = RepltablaQueries.ReplicationUpdate_Trigger(tabla.Nombre, tabla.Replcondinsert);
                        if (bda.ExecuteNonQuery(commandText, parameterList, CommandType.Text) >= -1)
                        {

                            commandText = RepltablaQueries.ReplicationDelete_Function(tabla.Nombre, tabla.Replcondinsert, ref camposClaveExistencia);
                            if (bda.ExecuteNonQuery(commandText, parameterList, CommandType.Text) >= -1)
                            {
                                commandText = RepltablaQueries.ReplicationDelete_Trigger(tabla.Nombre, tabla.Replcondinsert);
                                if (bda.ExecuteNonQuery(commandText, parameterList, CommandType.Text) >= -1)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }



        public bool RemoveTableTriggers(Repltabla tabla, ref BaseDataAccess bda)
        {


            var commandText = RepltablaQueries.Replication_Remove_Insert_Trigger(tabla.Nombre, tabla.Replcondinsert);

            List<DbParameter> parameterList = new List<DbParameter>();
            if (bda.ExecuteNonQuery(commandText, parameterList, CommandType.Text) >= -1)
            {
                commandText = RepltablaQueries.Replication_Remove_Insert_Function(tabla.Nombre, tabla.Replcondinsert);
                if (bda.ExecuteNonQuery(commandText, parameterList, CommandType.Text) >= -1)
                {
                    commandText = RepltablaQueries.Replication_Remove_Update_Trigger(tabla.Nombre, tabla.Replcondinsert);
                    if (bda.ExecuteNonQuery(commandText, parameterList, CommandType.Text) >= -1)
                    {
                        commandText = RepltablaQueries.Replication_Remove_Update_Function(tabla.Nombre, tabla.Replcondinsert);
                        if (bda.ExecuteNonQuery(commandText, parameterList, CommandType.Text) >= -1)
                        {

                            commandText = RepltablaQueries.Replication_Remove_Delete_Trigger(tabla.Nombre, tabla.Replcondinsert);
                            if (bda.ExecuteNonQuery(commandText, parameterList, CommandType.Text) >= -1)
                            {
                                commandText = RepltablaQueries.Replication_Remove_Delete_Function(tabla.Nombre, tabla.Replcondinsert);
                                if (bda.ExecuteNonQuery(commandText, parameterList, CommandType.Text) >= -1)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }

#pragma warning disable CA1416
        public void ReplicateData(long empresaid, long sucursalid, string empresaClave, 
                                    string sucursalFuenteClave, long? usuarioId, string localPath,
                                    ApplicationDbContext localContext)
        {
            //var fieldList = this.tableinfoDaoProvider.Select_V_field_info_List(null, new V_field_infoParam(empresaid, sucursalid) { P_tablename = "linea", P_schemaname = "catalogos", P_activo = "S" }, null);

            //if(fieldList != null)
            //    Console.WriteLine(fieldList.Count().ToString());

            this.tableinfoDaoProvider.ConnectionString = localContext.ConnectionString; 

            string filePath = ImpoExpoConstants.ImpoExpoBasePath + ImpoExpoConstants.FileLocalLocation_ReplTemp_Expo;
            this.tableinfoDaoProvider.ExportChangesToDBF(filePath, new List<string>() { @"public.""Linea""" });
        }
#pragma warning restore CA1416

    }

    public class TablasAReplicar : TransitionClass
    {
        public long Empresaid { get; set; }
        public long Sucursalid { get; set; }
        public long? Id { get; set; }
        public BoolCS Activo { get; set; }
        public string Nombretabla { get; set; } = "";
        public string? Replcondinsert { get; set; }
        public string? Replcondupdate { get; set; }
        public string? Replconddelete { get; set; }

        public string? Grupos { get; set; }

        public TablasAReplicar()
        {
        }


        public TablasAReplicar(string nombreTabla):this()
        {

            Empresaid = 0;
            Sucursalid = 0;
            Activo = BoolCS.N;
            Nombretabla = nombreTabla;
         }

        public TablasAReplicar(Repltabla replTabla) : this()
        {


            Empresaid = replTabla.EmpresaId;
            Sucursalid = replTabla.SucursalId;
            Id = replTabla.Id;
            Activo = replTabla.Activo;
            Nombretabla = replTabla.Nombre ?? "";
            Replcondinsert = replTabla.Replcondinsert;
            Replcondupdate = replTabla.Replcondupdate;
            Replconddelete = replTabla.Replconddelete;


        }

}

    public class GrupoTablasAReplicar : TransitionClass
    {
        public long Empresaid { get; set; }
        public long Sucursalid { get; set; }
        public long? Id { get; set; }
        public long? IdGroupDef { get; set; }
        public BoolCS Activo { get; set; }
        public string Nombre { get; set; } = "";
        public string Clave { get; set; } = "";

        public List<GrupoTablaItemAReplicar>? Tablas { get; set; }

        public GrupoTablasAReplicar()
        {
        }



        public GrupoTablasAReplicar(Replgroup replTabla) : this()
        {


            Empresaid = replTabla.EmpresaId;
            Sucursalid = replTabla.SucursalId;
            Id = replTabla.Id;
            Activo = replTabla.Activo;
            IdGroupDef = replTabla.Idgroupdef;
            Clave = replTabla.Groupdef?.Clave ?? "";
            Nombre = replTabla.Groupdef?.Nombre ?? "";

            Tablas = replTabla.Groupdef?.RepltablagroupdefSet?.Select(r => new GrupoTablaItemAReplicar(r)).ToList() ?? new List<GrupoTablaItemAReplicar>();


        }

        public GrupoTablasAReplicar(long empresaId, long sucursalId,Replgroupdef replDefTabla) : this()
        {


            Empresaid = empresaId;
            Sucursalid = sucursalId;
            Id = 0;
            Activo = BoolCS.N;
            IdGroupDef = replDefTabla.Id;
            Clave = replDefTabla.Clave ?? "";
            Nombre = replDefTabla.Nombre ?? "";

            Tablas = replDefTabla.RepltablagroupdefSet?.Select(r => new GrupoTablaItemAReplicar(r)).ToList() ?? new List<GrupoTablaItemAReplicar>();


        }

    }

    public class GrupoTablaItemAReplicar
    {

        public long? Id { get; set; }
        public BoolCS Activo { get; set; }
        public string? Nombretabla { get; set; } = "";

        public GrupoTablaItemAReplicar()
        {
            
        }


        public GrupoTablaItemAReplicar(Repltablagroupdef item)
        {
            Id = item.Id;
            Activo = item.Activo;
            Nombretabla = item.Nombretabla;
        }


    }

    public class RepltablaQueries
    {
        public static string Replication_CampoClaveValor(string campoClave, ref Dictionary<string, bool> camposClaveExistencia)
        {
            var realCampoClave = campoClave.Split('.').Last().Replace(@"""","");
            if (!camposClaveExistencia.Keys.Contains(realCampoClave))
                return campoClave;

            if (!camposClaveExistencia[realCampoClave])
            {
                switch(realCampoClave)
                {
                    default:
                        return "0";
                }
            }

            return campoClave;
        }

        public static string ReplicationInsert_Function(string? tableFullName, string? condition, ref Dictionary<string, bool> camposClaveExistencia)
        {
            if (tableFullName == null) throw new Exception("El nombre de la tabla no puede ser null");

            var buffer = tableFullName.Split('.');
            var schema = buffer.First();
            var tableName = buffer.Last();

            var strNewEmpresaId = Replication_CampoClaveValor(@"new.""EmpresaId""", ref camposClaveExistencia);
            var strNewSucursalId = Replication_CampoClaveValor(@"new.""SucursalId""", ref camposClaveExistencia);

            return $@"CREATE OR REPLACE FUNCTION {schema}.repl_fnc_{tableName}_insert()
RETURNS TRIGGER AS
$body$
 DECLARE
    v_repltablaid bigint DEFAULT 0;
    v_regcount bigint DEFAULT 0;
    v_count integer DEFAULT 0;
    _usermessage varchar DEFAULT '';
    _devmessage varchar DEFAULT '';
    _result bigint DEFAULT 0;
    
    
    
 BEGIN

	

    select ""Id"" id into v_repltablaid 
    from public.""Repltabla""
    where  ""EmpresaId"" = {strNewEmpresaId} and ""SucursalId"" = {strNewSucursalId} and ""Nombre"" = '{schema}.{tableName}'; 
    
    select count(*) into v_regcount
    from public.""Replmov"" m
    where ""EmpresaId"" = {strNewEmpresaId} and ""SucursalId"" = {strNewSucursalId} and new.""Id"" = m.""Idregistro"" and 
          m.""Repltablaid"" = v_repltablaid and 1 = m.""Tipomovid"";
          
    if(v_regcount = 0) then
    
    	select t.usermessage, t.devmessage, t.result into _usermessage, _devmessage, _result
        from public.fnc_replmov_insert(
        		{strNewEmpresaId}, 
                {strNewSucursalId},
                'S', --activo
  				new.""CreadoPorId"" ,
                1,--p_tipomovid public.d_fk,
  				v_repltablaid,
                new.""Id""
                ) t;
    
    end if;
    




	return null; 
	
      END;
$body$
LANGUAGE 'plpgsql'
VOLATILE
CALLED ON NULL INPUT
SECURITY INVOKER
COST 100;";
        }



        public static string ReplicationInsert_Trigger(string? tableFullName, string? condition)
        {
            if (tableFullName == null) throw new Exception("El nombre de la tabla no puede ser nulo");

            var buffer = tableFullName.Split('.');
            var schema = buffer.First();
            var tableName = buffer.Last();


            return $@"CREATE TRIGGER {tableName}_insert_repl AFTER INSERT ON {schema}.""{tableName}"" FOR EACH ROW EXECUTE PROCEDURE {schema}.repl_fnc_{tableName}_insert(); ";
        }


        public static string Replication_Remove_Insert_Function(string? tableFullName, string? condition)
        {
            if (tableFullName == null) throw new Exception("El nombre de la tabla no puede ser nulo");

            var buffer = tableFullName.Split('.');
            var schema = buffer.First();
            var tableName = buffer.Last();

            return $@"DROP FUNCTION  {schema}.repl_fnc_{tableName}_insert()";
        }


        public static string Replication_Remove_Insert_Trigger(string? tableFullName, string? condition)
        {
            if (tableFullName == null) throw new Exception("El nombre de la tabla no puede ser nulo");

            var buffer = tableFullName.Split('.');
            var schema = buffer.First();
            var tableName = buffer.Last();

            return $@"DROP TRIGGER {tableName}_insert_repl ON {schema}.""{tableName}"";";
        }

        public static string ReplicationUpdate_Function(string? tableFullName, string? condition, ref Dictionary<string, bool> camposClaveExistencia)
        {

            if (tableFullName == null) throw new Exception("El nombre de la tabla no puede ser nulo");

            var buffer = tableFullName.Split('.');
            var schema = buffer.First();
            var tableName = buffer.Last();

            var strNewEmpresaId = Replication_CampoClaveValor(@"new.""EmpresaId""", ref camposClaveExistencia);
            var strNewSucursalId = Replication_CampoClaveValor(@"new.""SucursalId""", ref camposClaveExistencia);

            return $@"CREATE OR REPLACE FUNCTION {schema}.repl_fnc_{tableName}_update()
RETURNS TRIGGER AS
$body$
 DECLARE
    v_repltablaid bigint DEFAULT 0;
    v_regcount bigint DEFAULT 0;
    v_count integer DEFAULT 0;
    _usermessage varchar DEFAULT '';
    _devmessage varchar DEFAULT '';
    _result bigint DEFAULT 0;
    
    
    
 BEGIN

	

    select  ""Id"" into v_repltablaid 
    from public.""Repltabla""
    where  ""EmpresaId"" = {strNewEmpresaId} and ""SucursalId"" = {strNewSucursalId} and ""Nombre"" = '{schema}.{tableName}'; 
    
    select count(*) into v_regcount
    from public.""Replmov"" m
    where ""EmpresaId"" = {strNewEmpresaId} and ""SucursalId"" = {strNewSucursalId} and new.""Id"" = m.""Idregistro"" and 
          m.""Repltablaid"" = v_repltablaid and 1 = m.""Tipomovid"";
          
    if(v_regcount = 0) then
    
    	select t.usermessage, t.devmessage, t.result into _usermessage, _devmessage, _result
        from public.fnc_replmov_insert(
        		{strNewEmpresaId}, 
                {strNewSucursalId},
                'S', --activo
  				new.""CreadoPorId"" ,
                1,--p_tipomovid public.d_fk,
  				v_repltablaid,
                new.""Id""
                ) t;
    
    end if;
    




	return null; 
	
      END;
$body$
LANGUAGE 'plpgsql'
VOLATILE
CALLED ON NULL INPUT
SECURITY INVOKER
COST 100;";
        }

        public static string ReplicationUpdate_Trigger(string? tableFullName, string? condition)
        {
            if (tableFullName == null) throw new Exception("El nombre de la tabla no puede ser nulo");

            var buffer = tableFullName.Split('.');
            var schema = buffer.First();
            var tableName = buffer.Last();


            return $@"CREATE TRIGGER {tableName}_update_repl AFTER UPDATE ON {schema}.""{tableName}"" FOR EACH ROW EXECUTE PROCEDURE {schema}.repl_fnc_{tableName}_update(); ";
        }


        public static string Replication_Remove_Update_Function(string? tableFullName, string? condition)
        {
            if (tableFullName == null) throw new Exception("El nombre de la tabla no puede ser nulo");

            var buffer = tableFullName.Split('.');
            var schema = buffer.First();
            var tableName = buffer.Last();

            return $@"DROP FUNCTION  {schema}.repl_fnc_{tableName}_update()";
        }


        public static string Replication_Remove_Update_Trigger(string? tableFullName, string? condition)
        {
            if (tableFullName == null) throw new Exception("El nombre de la tabla no puede ser nulo");

            var buffer = tableFullName.Split('.');
            var schema = buffer.First();
            var tableName = buffer.Last();

            return $@"DROP TRIGGER {tableName}_update_repl ON {schema}.""{tableName}"";";
        }

        public static string ReplicationDelete_Function(string? tableFullName, string? condition, ref Dictionary<string, bool> camposClaveExistencia)
        {
            if (tableFullName == null) throw new Exception("El nombre de la tabla no puede ser nulo");

            var buffer = tableFullName.Split('.');
            var schema = buffer.First();
            var tableName = buffer.Last();


            var strOldEmpresaId = Replication_CampoClaveValor(@"old.""EmpresaId""", ref camposClaveExistencia);
            var strOldSucursalId = Replication_CampoClaveValor(@"old.""SucursalId""", ref camposClaveExistencia);

            return $@"CREATE OR REPLACE FUNCTION {schema}.repl_fnc_{tableName}_delete()
RETURNS TRIGGER AS
$body$
 DECLARE
    v_repltablaid bigint DEFAULT 0;
    v_regcount bigint DEFAULT 0;
    v_count integer DEFAULT 0;
    _usermessage varchar DEFAULT '';
    _devmessage varchar DEFAULT '';
    _result bigint DEFAULT 0;
    
    
    
 BEGIN

	

    select ""Id"" into v_repltablaid 
    from public.""Repltabla""
    where  ""EmpresaId"" = {strOldEmpresaId} and ""SucursalId"" = {strOldSucursalId} and ""Nombre"" = '{schema}.{tableName}'; 
    
    select count(*) into v_regcount
    from public.""Replmov"" m
    where ""EmpresaId"" = {strOldEmpresaId} and ""SucursalId"" = {strOldSucursalId} and old.""Id"" = m.""Idregistro"" and 
          m.""Repltablaid"" = v_repltablaid and 2 = m.""Tipomovid"";
          
    if(v_regcount = 0) then
    
    	select t.usermessage, t.devmessage, t.result into _usermessage, _devmessage, _result
        from public.fnc_replmov_insert(
        		{strOldEmpresaId}, 
                {strOldSucursalId},
                'S', --activo
  				old.""CreadoPorId"" ,
                2,--p_tipomovid public.d_fk,
  				v_repltablaid,
                old.""Id""
                ) t;
    
    end if;
    




	return null; 
	
      END;
$body$
LANGUAGE 'plpgsql'
VOLATILE
CALLED ON NULL INPUT
SECURITY INVOKER
COST 100;";
        }

        public static string ReplicationDelete_Trigger(string? tableFullName, string? condition)
        {
            if (tableFullName == null) throw new Exception("El nombre de la tabla no puede ser nulo");

            var buffer = tableFullName.Split('.');
            var schema = buffer.First();
            var tableName = buffer.Last();


            return $@"CREATE TRIGGER {tableName}_delete_repl AFTER DELETE ON {schema}.""{tableName}"" FOR EACH ROW EXECUTE PROCEDURE {schema}.repl_fnc_{tableName}_delete(); ";
        }

        public static string Replication_Remove_Delete_Function(string? tableFullName, string? condition)
        {
            if (tableFullName == null) throw new Exception("El nombre de la tabla no puede ser nulo");

            var buffer = tableFullName.Split('.');
            var schema = buffer.First();
            var tableName = buffer.Last();

            return $@"DROP FUNCTION  {schema}.repl_fnc_{tableName}_delete()";
        }


        public static string Replication_Remove_Delete_Trigger(string? tableFullName, string? condition)
        {
            if (tableFullName == null) throw new Exception("El nombre de la tabla no puede ser nulo");

            var buffer = tableFullName.Split('.');
            var schema = buffer.First();
            var tableName = buffer.Last();

            return $@"DROP TRIGGER {tableName}_delete_repl ON {schema}.""{tableName}"";";
        }




    }


}
