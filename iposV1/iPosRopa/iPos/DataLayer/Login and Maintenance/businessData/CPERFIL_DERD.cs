
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
    
    public class CPERFIL_DERD
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
        
        
        
        
        
        
        
        
        public CPERFIL_DERBE AgregarPERFIL_DERD(CPERFIL_DERBE oCPERFIL_DER, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@PD_PERFIL", FbDbType.Integer);
                if (!(bool)oCPERFIL_DER.isnull["IPD_PERFIL"])
                {
                    auxPar.Value = oCPERFIL_DER.IPD_PERFIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@PD_DERECHO", FbDbType.Integer);
                if (!(bool)oCPERFIL_DER.isnull["IPD_DERECHO"])
                {
                    auxPar.Value = oCPERFIL_DER.IPD_DERECHO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                string commandText = @"
        INSERT INTO PERFIL_DER
      (
    
PD_PERFIL,
PD_DERECHO
         )
Values (
@PD_PERFIL,
@PD_DERECHO
); ";
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);
                return oCPERFIL_DER;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }
        
        public bool BorrarPERFIL_DERD(CPERFIL_DERBE oCPERFIL_DER, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@PD_PERFIL", FbDbType.Integer);
                auxPar.Value = oCPERFIL_DER.IPD_PERFIL;
                parts.Add(auxPar);
                auxPar = new FbParameter("@PD_DERECHO", FbDbType.Integer);
                auxPar.Value = oCPERFIL_DER.IPD_DERECHO;
                parts.Add(auxPar);
                string commandText = @"  Delete from PERFIL_DER
  where
  PD_PERFIL=@PD_PERFIL and 
  PD_DERECHO=@PD_DERECHO
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
        
        public bool CambiarPERFIL_DERD(CPERFIL_DERBE oCPERFIL_DERNuevo, CPERFIL_DERBE oCPERFIL_DERAnterior, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@PD_PERFIL", FbDbType.Integer);
                if (!(bool)oCPERFIL_DERNuevo.isnull["IPD_PERFIL"])
                {
                    auxPar.Value = oCPERFIL_DERNuevo.IPD_PERFIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@PD_DERECHO", FbDbType.Integer);
                if (!(bool)oCPERFIL_DERNuevo.isnull["IPD_DERECHO"])
                {
                    auxPar.Value = oCPERFIL_DERNuevo.IPD_DERECHO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@PD_PERFILAnt", FbDbType.Integer);
                if (!(bool)oCPERFIL_DERAnterior.isnull["IPD_PERFIL"])
                {
                    auxPar.Value = oCPERFIL_DERAnterior.IPD_PERFIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@PD_DERECHOAnt", FbDbType.Integer);
                if (!(bool)oCPERFIL_DERAnterior.isnull["IPD_DERECHO"])
                {
                    auxPar.Value = oCPERFIL_DERAnterior.IPD_DERECHO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                string commandText = @"
  update  PERFIL_DER
  set
PD_PERFIL=@PD_PERFIL,
PD_DERECHO=@PD_DERECHO
  where 
PD_PERFIL=@PD_PERFILAnt and
PD_DERECHO=@PD_DERECHOAnt
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
        
        public CPERFIL_DERBE seleccionarPERFIL_DER(CPERFIL_DERBE oCPERFIL_DER, FbTransaction st)
        {
            CPERFIL_DERBE retorno = new CPERFIL_DERBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                String CmdTxt = "select * from PERFIL_DER where  PD_PERFIL=@PD_PERFIL    and PD_DERECHO=@PD_DERECHO  ";
                auxPar = new FbParameter("@PD_PERFIL", FbDbType.Integer);
                auxPar.Value = oCPERFIL_DER.IPD_PERFIL;
                parts.Add(auxPar);
                auxPar = new FbParameter("@PD_DERECHO", FbDbType.Integer);
                auxPar.Value = oCPERFIL_DER.IPD_DERECHO;
                parts.Add(auxPar);
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                if (dr.Read())
                {
                    if (dr["PD_PERFIL"] != System.DBNull.Value)
                    {
                        retorno.IPD_PERFIL = (int)(dr["PD_PERFIL"]);
                    }
                    if (dr["PD_DERECHO"] != System.DBNull.Value)
                    {
                        retorno.IPD_DERECHO = (int)(dr["PD_DERECHO"]);
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
        public bool BorrarDerechosDePerfil(CPERFIL_DERBE oCPERFIL_DER, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@PD_PERFIL", FbDbType.Integer);
                auxPar.Value = oCPERFIL_DER.IPD_PERFIL;
                parts.Add(auxPar);
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                string commandText = @"  Delete from PERFIL_DER
                                        where PD_PERFIL=@PD_PERFIL ;";
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
        
        public DataSet enlistarPERFIL_DER()
        {
            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PERFIL_DER_enlistar");
                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }
        
        public DataSet enlistarCortoPERFIL_DER()
        {
            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PERFIL_DER_enlistarCorto");
                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }
        
        
        
        
        
        
        public int ExistePERFIL_DER(CPERFIL_DERBE oCPERFIL_DER, FbTransaction st)
        {

            int retorno;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@PD_PERFIL", FbDbType.Integer);
                auxPar.Value = oCPERFIL_DER.IPD_PERFIL;
                parts.Add(auxPar);
                auxPar = new FbParameter("@PD_DERECHO", FbDbType.Integer);
                auxPar.Value = oCPERFIL_DER.IPD_DERECHO;
                parts.Add(auxPar);
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from PERFIL_DER where
  PD_PERFIL=@PD_PERFIL    and
  PD_DERECHO=@PD_DERECHO  
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
        public CPERFIL_DERBE AgregarPERFIL_DER(CPERFIL_DERBE oCPERFIL_DER, FbTransaction st)
        {
            try
            {
                int iRes = ExistePERFIL_DER(oCPERFIL_DER, st);
                if (iRes == 1)
                {
                    this.IComentario = "El PERFIL_DER ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarPERFIL_DERD(oCPERFIL_DER, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }
        public bool BorrarPERFIL_DER(CPERFIL_DERBE oCPERFIL_DER, FbTransaction st)
        {
            try
            {
                int iRes = ExistePERFIL_DER(oCPERFIL_DER, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PERFIL_DER no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarPERFIL_DERD(oCPERFIL_DER, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }
        public bool CambiarPERFIL_DER(CPERFIL_DERBE oCPERFIL_DERNuevo, CPERFIL_DERBE oCPERFIL_DERAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExistePERFIL_DER(oCPERFIL_DERAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PERFIL_DER no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarPERFIL_DERD(oCPERFIL_DERNuevo, oCPERFIL_DERAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }
        public CPERFIL_DERD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            
            
            
            
        }
    }
}
