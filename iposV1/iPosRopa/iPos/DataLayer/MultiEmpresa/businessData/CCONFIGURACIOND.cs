
using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Collections;
using ConexionesBD;
namespace iPosData
{
    public class CCONFIGURACIOND
    {
        private string sCadenaConexion;
        private string iComentario;
        public string IComentario
        {
            get
            {
                return this.iComentario;
            }
            set
            {
                this.iComentario = value;
            }
        }
        protected string iComentarioAdicional;
        public string IComentarioAdicional
        {
            get
            {
                return this.iComentarioAdicional;
            }
            set
            {
                this.iComentarioAdicional = value;
            }
        }
        [AutoComplete]
        public CCONFIGURACIONBE AgregarCONFIGURACIOND(CCONFIGURACIONBE oCCONFIGURACION, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@CF_ID", FbDbType.SmallInt);
                if (!(bool)oCCONFIGURACION.isnull["ICF_ID"])
                {
                    auxPar.Value = oCCONFIGURACION.ICF_ID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@CF_DEFAULT_DB", FbDbType.VarChar);
                if (!(bool)oCCONFIGURACION.isnull["ICF_DEFAULT_DB"])
                {
                    auxPar.Value = oCCONFIGURACION.ICF_DEFAULT_DB;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                string commandText = @"
        INSERT INTO CONFIGURACION
      (
    
CF_ID,
CF_DEFAULT_DB
         )
Values (
@CF_ID,
@CF_DEFAULT_DB
); ";
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);
                return oCCONFIGURACION;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }
        [AutoComplete]
        public bool BorrarCONFIGURACIOND(CCONFIGURACIONBE oCCONFIGURACION, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@CF_ID", FbDbType.SmallInt);
                auxPar.Value = oCCONFIGURACION.ICF_ID;
                parts.Add(auxPar);
                string commandText = @"  Delete from CONFIGURACION
  where
  CF_ID=@CF_ID
  ;";
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);
                return true;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }
        [AutoComplete]
        public bool CambiarCONFIGURACIOND(CCONFIGURACIONBE oCCONFIGURACIONNuevo, CCONFIGURACIONBE oCCONFIGURACIONAnterior, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@CF_ID", FbDbType.SmallInt);
                if (!(bool)oCCONFIGURACIONNuevo.isnull["ICF_ID"])
                {
                    auxPar.Value = oCCONFIGURACIONNuevo.ICF_ID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@CF_DEFAULT_DB", FbDbType.VarChar);
                if (!(bool)oCCONFIGURACIONNuevo.isnull["ICF_DEFAULT_DB"])
                {
                    auxPar.Value = oCCONFIGURACIONNuevo.ICF_DEFAULT_DB;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@CF_IDAnt", FbDbType.SmallInt);
                if (!(bool)oCCONFIGURACIONAnterior.isnull["ICF_ID"])
                {
                    auxPar.Value = oCCONFIGURACIONAnterior.ICF_ID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                string commandText = @"
  update  CONFIGURACION
  set
CF_ID=@CF_ID,
CF_DEFAULT_DB=@CF_DEFAULT_DB
  where 
CF_ID=@CF_IDAnt
  ;";
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);
                return true;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool CambiarCONFIGURACION_DE_ACTUALIZACION(CCONFIGURACIONBE oCCONFIGURACIONNuevo, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@CF_LLAVE_EMPRESA", FbDbType.VarChar);
                if (!(bool)oCCONFIGURACIONNuevo.isnull["ICF_LLAVE_EMPRESA"])
                {
                    auxPar.Value = oCCONFIGURACIONNuevo.ICF_LLAVE_EMPRESA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CF_IS_SERVER", FbDbType.VarChar);
                if (!(bool)oCCONFIGURACIONNuevo.isnull["ICF_IS_SERVER"])
                {
                    auxPar.Value = oCCONFIGURACIONNuevo.ICF_IS_SERVER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CF_SERVER_NAME", FbDbType.VarChar);
                if (!(bool)oCCONFIGURACIONNuevo.isnull["ICF_SERVER_NAME"])
                {
                    auxPar.Value = oCCONFIGURACIONNuevo.ICF_SERVER_NAME;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CF_PATH_IPOS_SERVER", FbDbType.VarChar);
                if (!(bool)oCCONFIGURACIONNuevo.isnull["ICF_PATH_IPOS_SERVER"])
                {
                    auxPar.Value = oCCONFIGURACIONNuevo.ICF_PATH_IPOS_SERVER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CF_MACHINE_NAME", FbDbType.VarChar);
                if (!(bool)oCCONFIGURACIONNuevo.isnull["ICF_MACHINE_NAME"])
                {
                    auxPar.Value = oCCONFIGURACIONNuevo.ICF_MACHINE_NAME;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CF_SERVER_PATH", FbDbType.VarChar);
                if (!(bool)oCCONFIGURACIONNuevo.isnull["ICF_SERVER_PATH"])
                {
                    auxPar.Value = oCCONFIGURACIONNuevo.ICF_SERVER_PATH;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                
                string commandText = @"
  update  CONFIGURACION
  set
     CF_LLAVE_EMPRESA = @CF_LLAVE_EMPRESA,
     CF_IS_SERVER = @CF_IS_SERVER,
     CF_SERVER_NAME = @CF_SERVER_NAME,
     CF_PATH_IPOS_SERVER = @CF_PATH_IPOS_SERVER,
     CF_MACHINE_NAME = @CF_MACHINE_NAME,
     CF_SERVER_PATH = @CF_SERVER_PATH
  ;";
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);
                return true;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        [AutoComplete]
        public CCONFIGURACIONBE seleccionarCONFIGURACION(CCONFIGURACIONBE oCCONFIGURACION, FbTransaction st)
        {
            CCONFIGURACIONBE retorno = new CCONFIGURACIONBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                String CmdTxt = @"select * from CONFIGURACION where
 CF_ID=@CF_ID  ";
                auxPar = new FbParameter("@CF_ID", FbDbType.SmallInt);
                auxPar.Value = oCCONFIGURACION.ICF_ID;
                parts.Add(auxPar);
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                if (dr.Read())
                {
                    if (dr["CF_DEFAULT_DB"] != System.DBNull.Value)
                    {
                        retorno.ICF_DEFAULT_DB = (string)(dr["CF_DEFAULT_DB"]);
                    }
                    if (dr["CF_ID"] != System.DBNull.Value)
                    {
                        retorno.ICF_ID = short.Parse(dr["CF_ID"].ToString());
                    }
                  /*  if (dr["CF_LLAVE_EMPRESA"] != System.DBNull.Value)
                    {
                        retorno.ICF_LLAVE_EMPRESA = (string)(dr["CF_LLAVE_EMPRESA"]);
                    }
                    if (dr["CF_IS_SERVER"] != System.DBNull.Value)
                    {
                        retorno.ICF_IS_SERVER = (string)(dr["CF_IS_SERVER"]);
                    }
                    if (dr["CF_SERVER_NAME"] != System.DBNull.Value)
                    {
                        retorno.ICF_SERVER_NAME = (string)(dr["CF_SERVER_NAME"]);
                    }
                    if (dr["CF_PATH_IPOS_SERVER"] != System.DBNull.Value)
                    {
                        retorno.ICF_PATH_IPOS_SERVER = (string)(dr["CF_PATH_IPOS_SERVER"]);
                    }
                    if (dr["CF_MACHINE_NAME"] != System.DBNull.Value)
                    {
                        retorno.ICF_MACHINE_NAME = (string)(dr["CF_MACHINE_NAME"]);
                    }
                    if (dr["CF_SERVER_PATH"] != System.DBNull.Value)
                    {
                        retorno.ICF_SERVER_PATH = (string)(dr["CF_SERVER_PATH"]);
                    }*/
                }
                else
                {
                    retorno = null;
                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return retorno;
            }
            catch (Exception e)
            {

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }
        [AutoComplete]
        public DataSet enlistarCONFIGURACION()
        {
            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_CONFIGURACION_enlistar");
                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }
        [AutoComplete]
        public DataSet enlistarCortoCONFIGURACION()
        {
            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_CONFIGURACION_enlistarCorto");
                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }
        [AutoComplete]
        public int ExisteCONFIGURACION(CCONFIGURACIONBE oCCONFIGURACION, FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@CF_ID", FbDbType.SmallInt);
                auxPar.Value = oCCONFIGURACION.ICF_ID;
                parts.Add(auxPar);
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from CONFIGURACION where
  CF_ID=@CF_ID  
  );";
                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, commandText, arParms);
                if (dr.Read())
                {
                    retorno = 1;
                }
                else
                {
                    retorno = 0;
                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return retorno;
            }
            catch (Exception e)
            {

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return -1;
            }
        }
        public CCONFIGURACIONBE AgregarCONFIGURACION(CCONFIGURACIONBE oCCONFIGURACION, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCONFIGURACION(oCCONFIGURACION, st);
                if (iRes == 1)
                {
                    this.IComentario = "El CONFIGURACION ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarCONFIGURACIOND(oCCONFIGURACION, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }
        public bool BorrarCONFIGURACION(CCONFIGURACIONBE oCCONFIGURACION, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCONFIGURACION(oCCONFIGURACION, st);
                if (iRes == 0)
                {
                    this.IComentario = "El CONFIGURACION no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarCONFIGURACIOND(oCCONFIGURACION, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }
        public bool CambiarCONFIGURACION(CCONFIGURACIONBE oCCONFIGURACIONNuevo, CCONFIGURACIONBE oCCONFIGURACIONAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCONFIGURACION(oCCONFIGURACIONAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El CONFIGURACION no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarCONFIGURACIOND(oCCONFIGURACIONNuevo, oCCONFIGURACIONAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }
        public CCONFIGURACIONBE seleccionarCONFIGURACIONGen(FbTransaction st)
        {
            CCONFIGURACIONBE retorno = new CCONFIGURACIONBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                String CmdTxt = @"select * from CONFIGURACION ";
                //auxPar = new FbParameter("@CF_ID", FbDbType.SmallInt);
                //auxPar.Value = oCCONFIGURACION.ICF_ID;
                //parts.Add(auxPar);
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                if (dr.Read())
                {
                    if (dr["CF_DEFAULT_DB"] != System.DBNull.Value)
                    {
                        retorno.ICF_DEFAULT_DB = (string)(dr["CF_DEFAULT_DB"]);
                    }
                    if (dr["CF_ID"] != System.DBNull.Value)
                    {
                        retorno.ICF_ID = short.Parse(dr["CF_ID"].ToString());
                    }
                   /* if (dr["CF_LLAVE_EMPRESA"] != System.DBNull.Value)
                    {
                        retorno.ICF_LLAVE_EMPRESA = (string)(dr["CF_LLAVE_EMPRESA"]);
                    }
                    if (dr["CF_IS_SERVER"] != System.DBNull.Value)
                    {
                        retorno.ICF_IS_SERVER = (string)(dr["CF_IS_SERVER"]);
                    }
                    if (dr["CF_SERVER_NAME"] != System.DBNull.Value)
                    {
                        retorno.ICF_SERVER_NAME = (string)(dr["CF_SERVER_NAME"]);
                    }
                    if (dr["CF_PATH_IPOS_SERVER"] != System.DBNull.Value)
                    {
                        retorno.ICF_PATH_IPOS_SERVER = (string)(dr["CF_PATH_IPOS_SERVER"]);
                    }
                    if (dr["CF_MACHINE_NAME"] != System.DBNull.Value)
                    {
                        retorno.ICF_MACHINE_NAME = (string)(dr["CF_MACHINE_NAME"]);
                    }
                    if (dr["CF_SERVER_PATH"] != System.DBNull.Value)
                    {
                        retorno.ICF_SERVER_PATH = (string)(dr["CF_SERVER_PATH"]);
                    }*/
                }
                else
                {
                    retorno = null;
                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return retorno;
            }
            catch (Exception e)
            {

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }
        public bool CambiarBasePorDefault(string strBasePorDefault, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@CF_DEFAULT_DB", FbDbType.VarChar);
                auxPar.Value = strBasePorDefault;
               
                parts.Add(auxPar);
                
                string commandText = @"
  update  CONFIGURACION
  set
CF_DEFAULT_DB=@CF_DEFAULT_DB
  ;";
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);
                return true;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public void ChecarActualizaciones(string strVersionApp)
        {
            string[] separadores = new string[]{"."};
            string[] strVersionParts = strVersionApp.Split( separadores, StringSplitOptions.None);

            int iVersionApp = int.Parse(strVersionParts[0]);


            if(iVersionApp > 688)
            {
                if(existeCampo("EMPRESAS","HAB_POOLING") == 0)
                {
                    agregarCampo("EMPRESAS", "HAB_POOLING", "CHAR(1)");
                }
            }


            if (iVersionApp > 815)
            {
                if (existeCampo("EMPRESAS", "REPLICADOR") == 0)
                {
                    agregarCampo("EMPRESAS", "REPLICADOR", "CHAR(1)");
                }
            }



            if (iVersionApp >= DBValues._VERSION_DE_SYSTEMDATA_NETWORK)
            {
                if(!existeTabla(null, "SINCCONFIG"))
                {
                    agregarTablaSincConfig(null);
                    agregarRegistroUnicoDefaultSincronizacion(null);
                    agregarTriggerInsercionSincronizacion(null);
                    agregarTriggerActualizacionSincronizacion(null);
                }
            }

        }




        private bool agregarTriggerInsercionSincronizacion(FbTransaction st)
        {
            try
            {
                string query = @"CREATE OR ALTER trigger empresas_ai0 for empresas
active after insert position 0
AS
declare variable O_FECHACAMBIOMANUAL varchar(1);
begin
  select FIRST 1 sincconfig.o_fechacambiomanual as fechaCambioManual
    from sincconfig into :O_FECHACAMBIOMANUAL;

    if(:O_FECHACAMBIOMANUAL = 'N') then
    begin
        update sincconfig
        set sincconfig.o_ultifechacambio = current_time;
    end
end";

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, query);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, query);

                return true;
            }
            catch (Exception ex)
            {
                this.IComentario = ex.Message + ex.StackTrace;

                return false;
            }

        }




        private bool agregarTriggerActualizacionSincronizacion(FbTransaction st)
        {
            try
            {
                string query = @"CREATE OR ALTER trigger empresas_au_0 for empresas
active after update position 0
AS
declare variable O_FECHACAMBIOMANUAL varchar(1);
begin
    select FIRST 1 sincconfig.o_fechacambiomanual as fechaCambioManual
    from sincconfig into :O_FECHACAMBIOMANUAL;

    if(:O_FECHACAMBIOMANUAL = 'N' and
     (old.em_database <> new.em_database or
      old.em_usuario <> new.em_usuario or
      old.em_password <> new.em_password)) then
    begin
        update sincconfig
        set sincconfig.o_ultifechacambio = current_time;
    end
end";

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, query);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, query);

                return true;
            }
            catch (Exception ex)
            {
                this.IComentario = ex.Message + ex.StackTrace;

                return false;
            }

        }

        private bool agregarRegistroUnicoDefaultSincronizacion(FbTransaction st)
        {
            try
            {
                string query = @"INSERT INTO SINCCONFIG DEFAULT VALUES";

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, query);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, query);

                return true;
            }
            catch(Exception ex)
            {
                this.IComentario = ex.Message + ex.StackTrace;

                return false;
            }
            
        }

        private bool agregarTablaSincConfig(FbTransaction st)
        {
            try
            {
                string query = @"CREATE TABLE SINCCONFIG (
                                    HAB_SINC             CHAR(1) DEFAULT 'N' NOT NULL,
                                    ES_COPIA             CHAR(1) DEFAULT 'N' NOT NULL,
                                    C_CONEXORIG          VARCHAR(255) DEFAULT NULL,
                                    C_SINCAUTO           CHAR(1) DEFAULT 'N' NOT NULL,
                                    C_FECHAULTISINC      TIMESTAMP DEFAULT NULL,
                                    C_LIMPNOSINC         CHAR(1) DEFAULT 'N' NOT NULL,
                                    O_ULTIFECHACAMBIO    TIMESTAMP DEFAULT NULL,
                                    O_FECHACAMBIOMANUAL  CHAR(1) DEFAULT 'N' NOT NULL,
                                    O_RUTASYSTEMDATA_ENRED  VARCHAR(255) DEFAULT NULL);";
                if (st == null)
                {
                    SqlHelper.ExecuteNonQuery(sCadenaConexion, CommandType.Text, query);
                }
                else
                {
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, query);
                }


                return true;
            }
            catch(Exception ex)
            {
                this.iComentario = ex.Message + ex.StackTrace;

                return false;
            }
        }

        private bool existeTabla(FbTransaction st, string tabla)
        {
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                string query = @"SELECT RDB$RELATION_NAME FROM RDB$RELATIONS
                                 WHERE RDB$RELATION_NAME = '" + tabla + "'";

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, query, out pcn);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, query);

                if(dr.Read())
                {
                    Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                    return true;
                }
                else
                {
                    Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                    return false;
                }
            }
            catch(Exception ex)
            {
                this.iComentario = ex.Message + ex.StackTrace;

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                return false;
            }
        }


        public bool agregarCampo(string nombreTabla, string nombreCampo, string tipoCampo)
        {




            try
            {
                System.Collections.ArrayList parts = new ArrayList();
               
                string commandText = @" ALTER TABLE " + nombreTabla + " ADD " + nombreCampo  + " "  + tipoCampo  +  " ;" ;
                SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, null);

                return true;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }

        public  int existeCampo(string nombreTabla, string nombreCampo)
        {

            
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno = 0;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@TABLE_NAME", FbDbType.SmallInt);
                auxPar.Value = nombreTabla;
                parts.Add(auxPar);


                auxPar = new FbParameter("@FIELD_NAME", FbDbType.SmallInt);
                auxPar.Value = nombreCampo;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                string commandText = @"
                            SELECT
                                COUNT(*) CUENTA
                            FROM
                                RDB$RELATION_FIELDS
                            WHERE
                                RDB$RELATION_FIELDS.RDB$RELATION_NAME = UPPER(@TABLE_NAME)
                                AND RDB$RELATION_FIELDS.RDB$FIELD_NAME = UPPER(@FIELD_NAME)";
                
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, out pcn, arParms);




                if (dr.Read())
                {

                    if (dr["CUENTA"] != System.DBNull.Value)
                    {
                        int buffer  = (int)(dr["CUENTA"]);
                        retorno = buffer > 0 ? 1 : 0;
                    }
                    
                }
                else
                {
                    retorno = 0;
                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return retorno;
            }
            catch (Exception e)
            {

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return -1;
            }


        }

        public CCONFIGURACIOND()
        {
            this.sCadenaConexion = ConexionMEBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
