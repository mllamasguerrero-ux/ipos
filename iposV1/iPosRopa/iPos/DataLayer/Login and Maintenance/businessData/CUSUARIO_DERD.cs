
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
    
    public class CUSUARIO_DERD
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
        
        
        public CUSUARIO_DERBE AgregarUSUARIO_DERD(CUSUARIO_DERBE oCUSUARIO_DER, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@UD_USERID", FbDbType.Integer);
                if (!(bool)oCUSUARIO_DER.isnull["IUD_USERID"])
                {
                    auxPar.Value = oCUSUARIO_DER.IUD_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@UD_DERECHO", FbDbType.Integer);
                if (!(bool)oCUSUARIO_DER.isnull["IUD_DERECHO"])
                {
                    auxPar.Value = oCUSUARIO_DER.IUD_DERECHO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                string commandText = @"
        INSERT INTO USUARIO_DER
      (
    
UD_USERID,
UD_DERECHO
         )
Values (
@UD_USERID,
@UD_DERECHO
); ";
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);
                return oCUSUARIO_DER;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }
        public bool BorrarUSUARIO_DERD(CUSUARIO_DERBE oCUSUARIO_DER, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@UD_USERID", FbDbType.Integer);
                auxPar.Value = oCUSUARIO_DER.IUD_USERID;
                parts.Add(auxPar);
                auxPar = new FbParameter("@UD_DERECHO", FbDbType.Integer);
                auxPar.Value = oCUSUARIO_DER.IUD_DERECHO;
                parts.Add(auxPar);
                string commandText = @"  Delete from USUARIO_DER
  where
  UD_USERID=@UD_USERID and 
  UD_DERECHO=@UD_DERECHO
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
        
        public bool CambiarUSUARIO_DERD(CUSUARIO_DERBE oCUSUARIO_DERNuevo, CUSUARIO_DERBE oCUSUARIO_DERAnterior, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@UD_USERID", FbDbType.Integer);
                if (!(bool)oCUSUARIO_DERNuevo.isnull["IUD_USERID"])
                {
                    auxPar.Value = oCUSUARIO_DERNuevo.IUD_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@UD_DERECHO", FbDbType.Integer);
                if (!(bool)oCUSUARIO_DERNuevo.isnull["IUD_DERECHO"])
                {
                    auxPar.Value = oCUSUARIO_DERNuevo.IUD_DERECHO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@UD_USERIDAnt", FbDbType.Integer);
                if (!(bool)oCUSUARIO_DERAnterior.isnull["IUD_USERID"])
                {
                    auxPar.Value = oCUSUARIO_DERAnterior.IUD_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@UD_DERECHOAnt", FbDbType.Integer);
                if (!(bool)oCUSUARIO_DERAnterior.isnull["IUD_DERECHO"])
                {
                    auxPar.Value = oCUSUARIO_DERAnterior.IUD_DERECHO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                string commandText = @"
  update  USUARIO_DER
  set
UD_USERID=@UD_USERID,
UD_DERECHO=@UD_DERECHO
  where 
UD_USERID=@UD_USERIDAnt and
UD_DERECHO=@UD_DERECHOAnt
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
        
        public CUSUARIO_DERBE seleccionarUSUARIO_DER(CUSUARIO_DERBE oCUSUARIO_DER, FbTransaction st)
        {
            CUSUARIO_DERBE retorno = new CUSUARIO_DERBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                String CmdTxt = "select * from USUARIO_DER where  UD_USERID=@UD_USERID  and UD_DERECHO=@UD_DERECHO  ";
                auxPar = new FbParameter("@UD_USERID", FbDbType.Integer);
                auxPar.Value = oCUSUARIO_DER.IUD_USERID;
                parts.Add(auxPar);
                auxPar = new FbParameter("@UD_DERECHO", FbDbType.Integer);
                auxPar.Value = oCUSUARIO_DER.IUD_DERECHO;
                parts.Add(auxPar);
				
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                if (dr.Read())
                {
                    if (dr["UD_USERID"] != System.DBNull.Value)
                    {
                        retorno.IUD_USERID = (int)(dr["UD_USERID"]);
                    }
                    if (dr["UD_DERECHO"] != System.DBNull.Value)
                    {
                        retorno.IUD_DERECHO = (int)(dr["UD_DERECHO"]);
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
        
        public bool BorrarDerechosDeUsuario(CUSUARIO_DERBE oCUSUARIO_DER, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@UD_USERID", FbDbType.Integer);
                auxPar.Value = oCUSUARIO_DER.IUD_USERID;
                parts.Add(auxPar);
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                string commandText = @"  Delete from USUARIO_DER
                where UD_USERID=@UD_USERID ;";
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
        
        public DataSet enlistarUSUARIO_DER()
        {
            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_USUARIO_DER_enlistar");
                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }
        
        public DataSet enlistarCortoUSUARIO_DER()
        {
            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_USUARIO_DER_enlistarCorto");
                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }
        
        
        
        
        
        public int ExisteUSUARIO_DER(CUSUARIO_DERBE oCUSUARIO_DER, FbTransaction st)
        {

            int retorno;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@UD_USERID", FbDbType.Integer);
                auxPar.Value = oCUSUARIO_DER.IUD_USERID;
                parts.Add(auxPar);
                auxPar = new FbParameter("@UD_DERECHO", FbDbType.Integer);
                auxPar.Value = oCUSUARIO_DER.IUD_DERECHO;
                parts.Add(auxPar);
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from USUARIO_DER where
  UD_USERID=@UD_USERID    and
  UD_DERECHO=@UD_DERECHO  
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
        public CUSUARIO_DERBE AgregarUSUARIO_DER(CUSUARIO_DERBE oCUSUARIO_DER, FbTransaction st)
        {
            try
            {
                int iRes = ExisteUSUARIO_DER(oCUSUARIO_DER, st);
                if (iRes == 1)
                {
                    this.IComentario = "El USUARIO_DER ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarUSUARIO_DERD(oCUSUARIO_DER, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }
        public bool BorrarUSUARIO_DER(CUSUARIO_DERBE oCUSUARIO_DER, FbTransaction st)
        {
            try
            {
                int iRes = ExisteUSUARIO_DER(oCUSUARIO_DER, st);
                if (iRes == 0)
                {
                    this.IComentario = "El USUARIO_DER no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarUSUARIO_DERD(oCUSUARIO_DER, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }
        public bool CambiarUSUARIO_DER(CUSUARIO_DERBE oCUSUARIO_DERNuevo, CUSUARIO_DERBE oCUSUARIO_DERAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteUSUARIO_DER(oCUSUARIO_DERAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El USUARIO_DER no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarUSUARIO_DERD(oCUSUARIO_DERNuevo, oCUSUARIO_DERAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }
        public CUSUARIO_DERD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            
            
            
            
        }
    }
}
