
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
    
    public class CPERFILESD
    {
        public const string _PERFIL_ADMIN = "ADMINISTRADOR";
        public const string _PERFIL_SUPERVISOR = "SUPERVISOR";
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
 
        
        public CPERFILESBE AgregarPERFILESD(CPERFILESBE oCPERFILES, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@PF_PERFIL", FbDbType.Integer);
                if (!(bool)oCPERFILES.isnull["IPF_PERFIL"])
                {
                    auxPar.Value = oCPERFILES.IPF_PERFIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@PF_DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCPERFILES.isnull["IPF_DESCRIPCION"])
                {
                    auxPar.Value = oCPERFILES.IPF_DESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                string commandText = @"
        INSERT INTO PERFILES
      (
    
PF_PERFIL,
PF_DESCRIPCION
         )
Values (
@PF_PERFIL,
@PF_DESCRIPCION
); ";
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);
                
                return oCPERFILES;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }
        
        public bool BorrarPERFILESD(CPERFILESBE oCPERFILES, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@PF_PERFIL", FbDbType.Integer);
                auxPar.Value = oCPERFILES.IPF_PERFIL;
                parts.Add(auxPar);
                string commandText = @"  Delete from PERFILES
  where
  PF_PERFIL=@PF_PERFIL
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
        
        public bool CambiarPERFILESD(CPERFILESBE oCPERFILESNuevo, CPERFILESBE oCPERFILESAnterior, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@PF_PERFIL", FbDbType.Integer);
                if (!(bool)oCPERFILESNuevo.isnull["IPF_PERFIL"])
                {
                    auxPar.Value = oCPERFILESNuevo.IPF_PERFIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@PF_DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCPERFILESNuevo.isnull["IPF_DESCRIPCION"])
                {
                    auxPar.Value = oCPERFILESNuevo.IPF_DESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@PF_PERFILAnt", FbDbType.Integer);
                if (!(bool)oCPERFILESAnterior.isnull["IPF_PERFIL"])
                {
                    auxPar.Value = oCPERFILESAnterior.IPF_PERFIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                string commandText = @"
  update  PERFILES
  set
PF_DESCRIPCION=@PF_DESCRIPCION
  where 
PF_PERFIL=@PF_PERFILAnt
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
        
        public CPERFILESBE seleccionarPERFILES(CPERFILESBE oCPERFILES, FbTransaction st)
        {
            CPERFILESBE retorno = new CPERFILESBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                String CmdTxt = "select * from PERFILES where  PF_PERFIL=@PF_PERFIL  ";
                auxPar = new FbParameter("@PF_PERFIL", FbDbType.Integer);
                auxPar.Value = oCPERFILES.IPF_PERFIL;
                parts.Add(auxPar);
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                if (dr.Read())
                {
                    if (dr["PF_PERFIL"] != System.DBNull.Value)
                    {
                        retorno.IPF_PERFIL = (int)(dr["PF_PERFIL"]);
                    }
                    if (dr["PF_DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IPF_DESCRIPCION = (string)(dr["PF_DESCRIPCION"]);
                    }
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
        public CPERFILESBE seleccionarPERFILESPorNombre(CPERFILESBE oCPERFILES, FbTransaction st)
        {
            CPERFILESBE retorno = new CPERFILESBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                String CmdTxt = "select * from PERFILES where  PF_DESCRIPCION=@PF_DESCRIPCION  ";
                auxPar = new FbParameter("@PF_DESCRIPCION", FbDbType.VarChar);
                auxPar.Value = oCPERFILES.IPF_DESCRIPCION;
                parts.Add(auxPar);
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                if (dr.Read())
                {
                    if (dr["PF_PERFIL"] != System.DBNull.Value)
                    {
                        retorno.IPF_PERFIL = (int)(dr["PF_PERFIL"]);
                    }
                    if (dr["PF_DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IPF_DESCRIPCION = (string)(dr["PF_DESCRIPCION"]);
                    }
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
        
        public DataSet enlistarPERFILES()
        {
            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PERFILES_enlistar");
                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }
        
        public DataSet enlistarCortoPERFILES()
        {
            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PERFILES_enlistarCorto");
                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }
        
        
        
        
        
        public int ExistePERFILES(CPERFILESBE oCPERFILES, FbTransaction st)
        {

            int retorno;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@PF_PERFIL", FbDbType.Integer);
                auxPar.Value = oCPERFILES.IPF_PERFIL;
                parts.Add(auxPar);
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from PERFILES where
  PF_PERFIL=@PF_PERFIL  
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
        public CPERFILESBE AgregarPERFILES(CPERFILESBE oCPERFILES, FbTransaction st)
        {
            try
            {
                
                int PF_PERFIL_identity = GetPERFILESIdentity(st);
                if (PF_PERFIL_identity == -1)
                {
                    return null;
                }
                oCPERFILES.IPF_PERFIL = PF_PERFIL_identity;
                int iRes = ExistePERFILES(oCPERFILES, st);
                if (iRes == 1)
                {
                    this.IComentario = "El PERFILES ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarPERFILESD(oCPERFILES, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }
        public bool BorrarPERFILES(CPERFILESBE oCPERFILES, FbTransaction st)
        {
            try
            {
                int iRes = ExistePERFILES(oCPERFILES, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PERFILES no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarPERFILESD(oCPERFILES, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }
        public bool CambiarPERFILES(CPERFILESBE oCPERFILESNuevo, CPERFILESBE oCPERFILESAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExistePERFILES(oCPERFILESAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PERFILES no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarPERFILESD(oCPERFILESNuevo, oCPERFILESAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }
        public int GetPERFILESIdentity(FbTransaction st)
        {
            
            CINCREMENTABLESD incr = new CINCREMENTABLESD();
            int retorno = (int)incr.POP_INCREMENTABLE(CINCREMENTABLESD._PERFIL_ID, st);
            return retorno;
        }
        public CPERFILESD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            
            
            
            
        }
    }
}
