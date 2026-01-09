
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
    
    public class CMENUITEMSD
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
        
        
        
        
        
        
        
        public CMENUITEMSBE AgregarMENUITEMSD(CMENUITEMSBE oCMENUITEMS, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@MN_ID", FbDbType.Integer);
                if (!(bool)oCMENUITEMS.isnull["IMN_ID"])
                {
                    auxPar.Value = oCMENUITEMS.IMN_ID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@MN_IDPARENT", FbDbType.Integer);
                if (!(bool)oCMENUITEMS.isnull["IMN_IDPARENT"])
                {
                    auxPar.Value = oCMENUITEMS.IMN_IDPARENT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@MN_ETIQUETA", FbDbType.VarChar);
                if (!(bool)oCMENUITEMS.isnull["IMN_ETIQUETA"])
                {
                    auxPar.Value = oCMENUITEMS.IMN_ETIQUETA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@MN_DESC", FbDbType.VarChar);
                if (!(bool)oCMENUITEMS.isnull["IMN_DESC"])
                {
                    auxPar.Value = oCMENUITEMS.IMN_DESC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@MN_DERECHO", FbDbType.Integer);
                if (!(bool)oCMENUITEMS.isnull["IMN_DERECHO"])
                {
                    auxPar.Value = oCMENUITEMS.IMN_DERECHO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@MN_LEVEL", FbDbType.SmallInt);
                if (!(bool)oCMENUITEMS.isnull["IMN_LEVEL"])
                {
                    auxPar.Value = oCMENUITEMS.IMN_LEVEL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                string commandText = @"
        INSERT INTO MENUITEMS
      (
    
MN_ID,
MN_IDPARENT,
MN_ETIQUETA,
MN_DESC,
MN_DERECHO,
MN_LEVEL
         )
Values (
@MN_ID,
@MN_IDPARENT,
@MN_ETIQUETA,
@MN_DESC,
@MN_DERECHO,
@MN_LEVEL
); ";
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);
                return oCMENUITEMS;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }
        
        public bool BorrarMENUITEMSD(CMENUITEMSBE oCMENUITEMS, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@MN_ID", FbDbType.Integer);
                auxPar.Value = oCMENUITEMS.IMN_ID;
                parts.Add(auxPar);
                string commandText = @"  Delete from MENUITEMS
  where
  MN_ID=@MN_ID
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
        
        public bool CambiarMENUITEMSD(CMENUITEMSBE oCMENUITEMSNuevo, CMENUITEMSBE oCMENUITEMSAnterior, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@MN_ID", FbDbType.Integer);
                if (!(bool)oCMENUITEMSNuevo.isnull["IMN_ID"])
                {
                    auxPar.Value = oCMENUITEMSNuevo.IMN_ID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@MN_IDPARENT", FbDbType.Integer);
                if (!(bool)oCMENUITEMSNuevo.isnull["IMN_IDPARENT"])
                {
                    auxPar.Value = oCMENUITEMSNuevo.IMN_IDPARENT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@MN_ETIQUETA", FbDbType.VarChar);
                if (!(bool)oCMENUITEMSNuevo.isnull["IMN_ETIQUETA"])
                {
                    auxPar.Value = oCMENUITEMSNuevo.IMN_ETIQUETA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@MN_DESC", FbDbType.VarChar);
                if (!(bool)oCMENUITEMSNuevo.isnull["IMN_DESC"])
                {
                    auxPar.Value = oCMENUITEMSNuevo.IMN_DESC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@MN_DERECHO", FbDbType.Integer);
                if (!(bool)oCMENUITEMSNuevo.isnull["IMN_DERECHO"])
                {
                    auxPar.Value = oCMENUITEMSNuevo.IMN_DERECHO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@MN_LEVEL", FbDbType.SmallInt);
                if (!(bool)oCMENUITEMSNuevo.isnull["IMN_LEVEL"])
                {
                    auxPar.Value = oCMENUITEMSNuevo.IMN_LEVEL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@MN_IDAnt", FbDbType.Integer);
                if (!(bool)oCMENUITEMSAnterior.isnull["IMN_ID"])
                {
                    auxPar.Value = oCMENUITEMSAnterior.IMN_ID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                string commandText = @"
  update  MENUITEMS
  set
MN_ID=@MN_ID,
MN_IDPARENT=@MN_IDPARENT,
MN_ETIQUETA=@MN_ETIQUETA,
MN_DESC=@MN_DESC,
MN_DERECHO=@MN_DERECHO,
MN_LEVEL=@MN_LEVEL
  where 
MN_ID=@MN_IDAnt
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
        
        public CMENUITEMSBE seleccionarMENUITEMS(CMENUITEMSBE oCMENUITEMS, FbTransaction st)
        {
            CMENUITEMSBE retorno = new CMENUITEMSBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                String CmdTxt = "select * from MENUITEMS where  MN_ID=@MN_ID  ";
                auxPar = new FbParameter("@MN_ID", FbDbType.Integer);
                auxPar.Value = oCMENUITEMS.IMN_ID;
                parts.Add(auxPar);
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                if (dr.Read())
                {
                    if (dr["MN_ID"] != System.DBNull.Value)
                    {
                        retorno.IMN_ID = (int)(dr["MN_ID"]);
                    }
                    if (dr["MN_IDPARENT"] != System.DBNull.Value)
                    {
                        retorno.IMN_IDPARENT = (int)(dr["MN_IDPARENT"]);
                    }
                    if (dr["MN_ETIQUETA"] != System.DBNull.Value)
                    {
                        retorno.IMN_ETIQUETA = (string)(dr["MN_ETIQUETA"]);
                    }
                    if (dr["MN_DESC"] != System.DBNull.Value)
                    {
                        retorno.IMN_DESC = (string)(dr["MN_DESC"]);
                    }
                    if (dr["MN_DERECHO"] != System.DBNull.Value)
                    {
                        retorno.IMN_DERECHO = (int)(dr["MN_DERECHO"]);
                    }
                    if (dr["MN_LEVEL"] != System.DBNull.Value)
                    {
                        retorno.IMN_LEVEL = (short)(dr["MN_LEVEL"]);
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
        
        public DataSet GetChild_MENUITEMS(int idParent, long idUser)
        {
            DataSet retorno;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                //String CmdTxt = "select MENUITEMS.* from MENUITEMS inner join USUARIO_DER on mn_derecho=ud_derecho and ud_userid=@US_USERID where  MN_IDPARENT=@MN_IDPARENT order by MN_ID  ";
                String CmdTxt = "select distinct MENUITEMS.* from MENUITEMS inner join PERFIL_DER on mn_derecho=pd_derecho inner join USUARIO_PERFIL on up_perfil = pd_perfil  where  MN_IDPARENT=@MN_IDPARENT and up_personaid=@US_PERSONAID order by MN_ORDEN  ";
                auxPar = new FbParameter("@US_PERSONAID", FbDbType.BigInt);
                auxPar.Value = idUser;
                parts.Add(auxPar);
                auxPar = new FbParameter("@MN_IDPARENT", FbDbType.Integer);
                auxPar.Value = idParent;
                parts.Add(auxPar);
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.Text, CmdTxt, arParms);
                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }
        
        public DataSet enlistarMENUITEMS()
        {
            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_MENUITEMS_enlistar");
                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }
        
        public DataSet enlistarCortoMENUITEMS()
        {
            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_MENUITEMS_enlistarCorto");
                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }
        
        
        
        
        
        public int ExisteMENUITEMS(CMENUITEMSBE oCMENUITEMS, FbTransaction st)
        {

            int retorno;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@MN_ID", FbDbType.Integer);
                auxPar.Value = oCMENUITEMS.IMN_ID;
                parts.Add(auxPar);
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from MENUITEMS where
  MN_ID=@MN_ID  
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
        public CMENUITEMSBE AgregarMENUITEMS(CMENUITEMSBE oCMENUITEMS, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMENUITEMS(oCMENUITEMS, st);
                if (iRes == 1)
                {
                    this.IComentario = "El MENUITEMS ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarMENUITEMSD(oCMENUITEMS, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }
        public bool BorrarMENUITEMS(CMENUITEMSBE oCMENUITEMS, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMENUITEMS(oCMENUITEMS, st);
                if (iRes == 0)
                {
                    this.IComentario = "El MENUITEMS no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarMENUITEMSD(oCMENUITEMS, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }
        public bool CambiarMENUITEMS(CMENUITEMSBE oCMENUITEMSNuevo, CMENUITEMSBE oCMENUITEMSAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMENUITEMS(oCMENUITEMSAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El MENUITEMS no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarMENUITEMSD(oCMENUITEMSNuevo, oCMENUITEMSAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }
        public CMENUITEMSD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();            
        }
    }
}
