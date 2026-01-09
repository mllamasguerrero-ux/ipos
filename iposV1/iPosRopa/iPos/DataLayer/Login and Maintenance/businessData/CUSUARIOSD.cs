
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
    
    public class CUSUARIOSD
    {
        public const string  _PASSWORD_DEFAULT = "123";
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
        public CUSUARIOSBE AgregarUSUARIOS(CUSUARIOSBE oCUSUARIOS, FbTransaction st)
        {
            try
            {
                int US_USERID_identity = GetUSUARIOSIdentity(st);
                if (US_USERID_identity == -1)
                {
                    return null;
                }
                oCUSUARIOS.IUS_USERID = US_USERID_identity;
                
                oCUSUARIOS.IUS_PASSWORD = _PASSWORD_DEFAULT;
                oCUSUARIOS.IUS_R_PASSWORD = "1";
                int iRes = ExisteUSUARIOS(oCUSUARIOS, st);
                if (iRes == 1)
                {
                    this.IComentario = "El USUARIOS ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }

                return AgregarUSUARIOSD(oCUSUARIOS, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }
        public CUSUARIOSBE AgregarUSUARIOSD(CUSUARIOSBE oCUSUARIOS, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                
                auxPar = new FbParameter("@US_USERID", FbDbType.Integer);
                if (!(bool)oCUSUARIOS.isnull["IUS_USERID"])
                {
                    auxPar.Value = oCUSUARIOS.IUS_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@US_USUARIO", FbDbType.VarChar);
                if (!(bool)oCUSUARIOS.isnull["IUS_USUARIO"])
                {
                    auxPar.Value = oCUSUARIOS.IUS_USUARIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@US_PASSWORD", FbDbType.VarChar);
                if (!(bool)oCUSUARIOS.isnull["IUS_PASSWORD"])
                {
                    auxPar.Value = oCUSUARIOS.IUS_PASSWORD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@US_NOMBRE", FbDbType.VarChar);
                if (!(bool)oCUSUARIOS.isnull["IUS_NOMBRE"])
                {
                    auxPar.Value = oCUSUARIOS.IUS_NOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@US_VENDEDOR", FbDbType.VarChar);
                if (!(bool)oCUSUARIOS.isnull["IUS_VENDEDOR"])
                {
                    auxPar.Value = oCUSUARIOS.IUS_VENDEDOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@US_VIGENCIA", FbDbType.Date);
                if (!(bool)oCUSUARIOS.isnull["IUS_VIGENCIA"])
                {
                    auxPar.Value = oCUSUARIOS.IUS_VIGENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@US_EMPRESA", FbDbType.VarChar);
                if (!(bool)oCUSUARIOS.isnull["IUS_EMPRESA"])
                {
                    auxPar.Value = oCUSUARIOS.IUS_EMPRESA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@US_R_PASSWORD", FbDbType.VarChar);
                if (!(bool)oCUSUARIOS.isnull["IUS_R_PASSWORD"])
                {
                    auxPar.Value = oCUSUARIOS.IUS_R_PASSWORD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@US_LIMITE_CONEXIONES", FbDbType.BigInt);
                if (!(bool)oCUSUARIOS.isnull["IUS_LIMITE_CONEXIONES"])
                {
                    auxPar.Value = oCUSUARIOS.IUS_LIMITE_CONEXIONES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@US_CONEXIONES_ABIERTAS", FbDbType.BigInt);
                if (!(bool)oCUSUARIOS.isnull["IUS_CONEXIONES_ABIERTAS"])
                {
                    auxPar.Value = oCUSUARIOS.IUS_CONEXIONES_ABIERTAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@US_ALMACENID", FbDbType.Integer);
                if (!(bool)oCUSUARIOS.isnull["IUS_ALMACENID"])
                {
                    auxPar.Value = oCUSUARIOS.IUS_ALMACENID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                string commandText = @"
        INSERT INTO USUARIOS
      (
    
US_USERID,
US_USUARIO,
US_PASSWORD,
US_NOMBRE,
US_VENDEDOR,
US_VIGENCIA,
US_EMPRESA,
US_R_PASSWORD,
US_LIMITE_CONEXIONES,
US_CONEXIONES_ABIERTAS,
US_ALMACENID
         )
Values (
@US_USERID,
@US_USUARIO,
@US_PASSWORD,
@US_NOMBRE,
@US_VENDEDOR,
@US_VIGENCIA,
@US_EMPRESA,
@US_R_PASSWORD,
@US_LIMITE_CONEXIONES,
@US_CONEXIONES_ABIERTAS,
@US_ALMACENID
); ";
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);
                
                return oCUSUARIOS;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }
        
        public bool BorrarUSUARIOS(CUSUARIOSBE oCUSUARIOS, FbTransaction st)
        {
            try
            {
                int iRes = ExisteUSUARIOS(oCUSUARIOS, st);
                if (iRes == 0)
                {
                    this.IComentario = "El USUARIOS no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                //if (BorrarPerfilesDeUSUARIOS(oCUSUARIOS, st) == false)
                //{
                //    return false;
                //}
                if (BorrarDerechosDeUSUARIOS(oCUSUARIOS, st) == false)
                {
                    return false;
                }
                return BorrarUSUARIOSD(oCUSUARIOS, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }
        //public bool BorrarPerfilesDeUSUARIOS(CUSUARIOSBE oCUSUARIOS, FbTransaction st)
        //{
        //    CUSUARIO_PERFILBE usuarioPerfilBE = new CUSUARIO_PERFILBE();
        //    usuarioPerfilBE.IUP_PERSONAID = oCUSUARIOS.IUS_USERID;
        //    CUSUARIO_PERFILD usuarioPerfilD = new CUSUARIO_PERFILD();
        //    usuarioPerfilD.BorrarPerfilesDeUsuario(usuarioPerfilBE,st);
        //    if (!(usuarioPerfilD.IComentario == "" || usuarioPerfilD.IComentario == null))
        //    {
        //        this.IComentario = usuarioPerfilD.IComentario;
        //        return false;
        //    }
        //    return true;
        //}
        public bool BorrarDerechosDeUSUARIOS(CUSUARIOSBE oCUSUARIOS, FbTransaction st)
        {
            CUSUARIO_DERBE usuarioDerechoBE = new CUSUARIO_DERBE();
            usuarioDerechoBE.IUD_USERID = oCUSUARIOS.IUS_USERID;
            CUSUARIO_DERD usuarioDerechoD = new CUSUARIO_DERD();
            usuarioDerechoD.BorrarDerechosDeUsuario(usuarioDerechoBE,st);
            if (!(usuarioDerechoD.IComentario == "" || usuarioDerechoD.IComentario == null))
            {
                this.IComentario = usuarioDerechoD.IComentario;
                return false;
            }
            return true;
        }
        public bool BorrarUSUARIOSD(CUSUARIOSBE oCUSUARIOS, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@US_USERID", FbDbType.Integer);
                auxPar.Value = oCUSUARIOS.IUS_USERID;
                parts.Add(auxPar);
                string commandText = @"  Delete from USUARIOS
  where
  US_USERID=@US_USERID
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
        
        
        
        
        public bool CambiarUSUARIOS(CUSUARIOSBE oCUSUARIOSNuevo, CUSUARIOSBE oCUSUARIOSAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteUSUARIOS(oCUSUARIOSAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El USUARIOS no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarUSUARIOSD(oCUSUARIOSNuevo, oCUSUARIOSAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }
        public bool CambiarUSUARIOSD(CUSUARIOSBE oCUSUARIOSNuevo, CUSUARIOSBE oCUSUARIOSAnterior, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@US_NOMBRE", FbDbType.VarChar);
                if (!(bool)oCUSUARIOSNuevo.isnull["IUS_NOMBRE"])
                {
                    auxPar.Value = oCUSUARIOSNuevo.IUS_NOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@US_VENDEDOR", FbDbType.VarChar);
                if (!(bool)oCUSUARIOSNuevo.isnull["IUS_VENDEDOR"])
                {
                    auxPar.Value = oCUSUARIOSNuevo.IUS_VENDEDOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@US_VIGENCIA", FbDbType.Date);
                if (!(bool)oCUSUARIOSNuevo.isnull["IUS_VIGENCIA"])
                {
                    auxPar.Value = oCUSUARIOSNuevo.IUS_VIGENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@US_EMPRESA", FbDbType.VarChar);
                if (!(bool)oCUSUARIOSNuevo.isnull["IUS_EMPRESA"])
                {
                    auxPar.Value = oCUSUARIOSNuevo.IUS_EMPRESA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@US_ALMACENID", FbDbType.Integer);
                if (!(bool)oCUSUARIOSNuevo.isnull["IUS_ALMACENID"])
                {
                    auxPar.Value = oCUSUARIOSNuevo.IUS_ALMACENID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }

                parts.Add(auxPar);
                auxPar = new FbParameter("@US_USERIDAnt", FbDbType.Integer);
                if (!(bool)oCUSUARIOSAnterior.isnull["IUS_USERID"])
                {
                    auxPar.Value = oCUSUARIOSAnterior.IUS_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                string commandText = @"
  update  USUARIOS
  set
US_NOMBRE=@US_NOMBRE,
US_VENDEDOR=@US_VENDEDOR,
US_VIGENCIA=@US_VIGENCIA,
US_EMPRESA=@US_EMPRESA,
US_ALMACENID=@US_ALMACENID
  where 
US_USERID=@US_USERIDAnt
  ;;";
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
        public bool CambiarUSUARIOSPassword(CUSUARIOSBE oCUSUARIOSNuevo, CUSUARIOSBE oCUSUARIOSAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteUSUARIOS(oCUSUARIOSAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El USUARIOS no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarUSUARIOSPasswordD(oCUSUARIOSNuevo, oCUSUARIOSAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }
        public bool CambiarUSUARIOSPasswordD(CUSUARIOSBE oCUSUARIOSNuevo, CUSUARIOSBE oCUSUARIOSAnterior, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@US_USERID", FbDbType.Integer);
                if (!(bool)oCUSUARIOSNuevo.isnull["IUS_USERID"])
                {
                    auxPar.Value = oCUSUARIOSNuevo.IUS_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@US_PASSWORD", FbDbType.VarChar);
                if (!(bool)oCUSUARIOSNuevo.isnull["IUS_PASSWORD"])
                {
                    auxPar.Value = oCUSUARIOSNuevo.IUS_PASSWORD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@US_R_PASSWORD", FbDbType.VarChar);
                if (!(bool)oCUSUARIOSNuevo.isnull["IUS_R_PASSWORD"])
                {
                    auxPar.Value = oCUSUARIOSNuevo.IUS_R_PASSWORD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@US_PASSWORDAnt", FbDbType.VarChar);
                if (!(bool)oCUSUARIOSAnterior.isnull["IUS_PASSWORD"])
                {
                    auxPar.Value = oCUSUARIOSAnterior.IUS_PASSWORD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                string commandText = @" update  USUARIOS
                                       set
                                    US_PASSWORD=@US_PASSWORD,
                                    US_R_PASSWORD=@US_R_PASSWORD
                                    where 
                                    US_USERID=@US_USERID
                                    and US_PASSWORD=@US_PASSWORDAnt";
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
        
        public CUSUARIOSBE seleccionarUSUARIOS(CUSUARIOSBE oCUSUARIOS, FbTransaction st)
        {
            CUSUARIOSBE retorno = new CUSUARIOSBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                String CmdTxt = "select * from USUARIOS where  US_USERID=@US_USERID  ";
                auxPar = new FbParameter("@US_USERID", FbDbType.Integer);
                auxPar.Value = oCUSUARIOS.IUS_USERID;
                parts.Add(auxPar);
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                if (dr.Read())
                {
                    if (dr["US_USERID"] != System.DBNull.Value)
                    {
                        retorno.IUS_USERID = (int)(dr["US_USERID"]);
                    }
                    if (dr["US_USUARIO"] != System.DBNull.Value)
                    {
                        retorno.IUS_USUARIO = (string)(dr["US_USUARIO"]);
                    }
                    if (dr["US_PASSWORD"] != System.DBNull.Value)
                    {
                        retorno.IUS_PASSWORD = (string)(dr["US_PASSWORD"]);
                    }
                    if (dr["US_NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.IUS_NOMBRE = (string)(dr["US_NOMBRE"]);
                    }
                    if (dr["US_VENDEDOR"] != System.DBNull.Value)
                    {
                        retorno.IUS_VENDEDOR = (string)(dr["US_VENDEDOR"]);
                    }
                    if (dr["US_VIGENCIA"] != System.DBNull.Value)
                    {
                        retorno.IUS_VIGENCIA = (DateTime)(dr["US_VIGENCIA"]);
                    }
                    if (dr["US_EMPRESA"] != System.DBNull.Value)
                    {
                        retorno.IUS_EMPRESA = (string)(dr["US_EMPRESA"]);
                    }
                    if (dr["US_R_PASSWORD"] != System.DBNull.Value)
                    {
                        retorno.IUS_R_PASSWORD = (string)(dr["US_R_PASSWORD"]);
                    }
                    if (dr["US_LIMITE_CONEXIONES"] != System.DBNull.Value)
                    {
                        retorno.IUS_LIMITE_CONEXIONES = int.Parse(dr["US_LIMITE_CONEXIONES"].ToString());
                    }
                    if (dr["US_CONEXIONES_ABIERTAS"] != System.DBNull.Value)
                    {
                        retorno.IUS_CONEXIONES_ABIERTAS = int.Parse(dr["US_CONEXIONES_ABIERTAS"].ToString());
                    }
                    if (dr["US_ALMACENID"] != System.DBNull.Value)
                    {
                        retorno.IUS_ALMACENID = int.Parse(dr["US_ALMACENID"].ToString());
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
        public CUSUARIOSBE seleccionarUSUARIOSPorNombre(CUSUARIOSBE oCUSUARIOS, FbTransaction st)
        {
            CUSUARIOSBE retorno = new CUSUARIOSBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                String CmdTxt = "select * from USUARIOS where  US_USUARIO=@US_USUARIO  ";
                auxPar = new FbParameter("@US_USUARIO", FbDbType.VarChar);
                auxPar.Value = oCUSUARIOS.IUS_USUARIO;
                parts.Add(auxPar);
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                if (dr.Read())
                {
                    if (dr["US_USERID"] != System.DBNull.Value)
                    {
                        retorno.IUS_USERID = (int)(dr["US_USERID"]);
                    }
                    if (dr["US_USUARIO"] != System.DBNull.Value)
                    {
                        retorno.IUS_USUARIO = (string)(dr["US_USUARIO"]);
                    }
                    if (dr["US_PASSWORD"] != System.DBNull.Value)
                    {
                        retorno.IUS_PASSWORD = (string)(dr["US_PASSWORD"]);
                    }
                    if (dr["US_NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.IUS_NOMBRE = (string)(dr["US_NOMBRE"]);
                    }
                    if (dr["US_VENDEDOR"] != System.DBNull.Value)
                    {
                        retorno.IUS_VENDEDOR = (string)(dr["US_VENDEDOR"]);
                    }
                    if (dr["US_VIGENCIA"] != System.DBNull.Value)
                    {
                        retorno.IUS_VIGENCIA = (DateTime)(dr["US_VIGENCIA"]);
                    }
                    if (dr["US_EMPRESA"] != System.DBNull.Value)
                    {
                        retorno.IUS_EMPRESA = (string)(dr["US_EMPRESA"]);
                    }
                    if (dr["US_R_PASSWORD"] != System.DBNull.Value)
                    {
                        retorno.IUS_R_PASSWORD = (string)(dr["US_R_PASSWORD"]);
                    }
                    if (dr["US_LIMITE_CONEXIONES"] != System.DBNull.Value)
                    {
                        retorno.IUS_LIMITE_CONEXIONES = (long)(dr["US_LIMITE_CONEXIONES"]);
                    }
                    if (dr["US_CONEXIONES_ABIERTAS"] != System.DBNull.Value)
                    {
                        retorno.IUS_CONEXIONES_ABIERTAS = (long)(dr["US_CONEXIONES_ABIERTAS"]);
                    }
                    if (dr["US_ALMACENID"] != System.DBNull.Value)
                    {
                        retorno.IUS_ALMACENID = int.Parse(dr["US_ALMACENID"].ToString());
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
        
        public DataSet enlistarUSUARIOS()
        {
            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_USUARIOS_enlistar");
                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }



        public DataSet enlistarUSUARIOSVENDEDORESCONVENTAAUTOMATICA()
        {
            DataSet retorno;
            try
            {
                string query = @"SELECT p.vendedorid VENDEDORID, coalesce(v.email2,'')  IMPRESORA , p.id USUARIOID
FROM PERSONA  p
INNER JOIN  usuario_perfil up ON  up.up_personaid  = p.ID
 inner join perfil_der pd ON pd.pd_perfil = up.up_perfil
INNER JOIN PERSONA v on v.id = p.vendedorid
 where p.tipopersonaid = 20 and pd.pd_derecho = 10164 and coalesce(p.vendedorid,0) <> 0
 group by p.vendedorid, v.email2, p.id";

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.Text, query);
                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }



        public DataSet enlistarUSUARIOSVENDEDORESCONCOMPRAAUTOMATICA()
        {
            DataSet retorno;
            try
            {
                string query = @"SELECT p.vendedorid VENDEDORID, coalesce(v.email2,'')  IMPRESORA , p.id USUARIOID
FROM PERSONA  p
INNER JOIN  usuario_perfil up ON  up.up_personaid  = p.ID
 inner join perfil_der pd ON pd.pd_perfil = up.up_perfil
INNER JOIN PERSONA v on v.id = p.vendedorid
 where p.tipopersonaid = 20 and pd.pd_derecho = 10165 and coalesce(p.vendedorid,0) <> 0
 group by p.vendedorid, v.email2, p.id";

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.Text, query);
                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }




        public DataSet enlistarUSUARIOSVENDEDORESCONDERECHO(long derecho)
        {
            DataSet retorno;
            try
            {
                string query = @"SELECT p.vendedorid VENDEDORID, coalesce(p.email1,'')  EMAIL , p.id USUARIOID
FROM PERSONA  p
INNER JOIN  usuario_perfil up ON  up.up_personaid  = p.ID
 inner join perfil_der pd ON pd.pd_perfil = up.up_perfil
 where p.tipopersonaid = 20 and pd.pd_derecho = "  + derecho.ToString() +  @" 
 group by p.vendedorid, p.email1, p.id";

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.Text, query);
                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public DataSet enlistarCortoUSUARIOS()
        {
            DataSet retorno;
            try
            {
                String CmdTxt = "select US_USERID, US_USUARIO from USUARIOS  ";
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, CmdTxt);
                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }
        public int ExisteUSUARIOS(CUSUARIOSBE oCUSUARIOS, FbTransaction st)
        {

            int retorno;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@US_USERID", FbDbType.Integer);
                auxPar.Value = oCUSUARIOS.IUS_USERID;
                parts.Add(auxPar);
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from USUARIOS where
  US_USERID=@US_USERID  
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
        public int GetUSUARIOSIdentity(FbTransaction st)
        {
            
            CINCREMENTABLESD incr = new CINCREMENTABLESD();
            int retorno = (int)incr.POP_INCREMENTABLE(CINCREMENTABLESD._USER_ID, st);
            return retorno;
        }





        public bool UsuarioEsAdmin( int iUserId, FbTransaction st)
        {
            int iPerfilAdm = 0;
            bool retorno = false;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                String CmdTxt = "select count(*) perfilAdm from usuario_perfil where   up_perfil = 11 and up_userid = @US_USERID  ";
                auxPar = new FbParameter("@US_USERID", FbDbType.Integer);
                auxPar.Value = iUserId;
                parts.Add(auxPar);
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                if (dr.Read())
                {
                    if (dr["perfilAdm"] != System.DBNull.Value)
                    {
                        iPerfilAdm = (int)(dr["perfilAdm"]);
                        if (iPerfilAdm > 0)
                            retorno = true;
                    }
                }
                else
                {
                    retorno = false;
                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return retorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }





        public bool UsuarioEsSupervisor(int iUserId, FbTransaction st)
        {
            int iPerfilAdm = 0;
            bool retorno = false;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                String CmdTxt = "select count(*) perfilAdm from usuario_perfil where   up_perfil = 12 and up_userid = @US_USERID  ";
                auxPar = new FbParameter("@US_USERID", FbDbType.Integer);
                auxPar.Value = iUserId;
                parts.Add(auxPar);
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                if (dr.Read())
                {
                    if (dr["perfilAdm"] != System.DBNull.Value)
                    {
                        iPerfilAdm = (int)(dr["perfilAdm"]);
                        if (iPerfilAdm > 0)
                            retorno = true;
                    }
                }
                else
                {
                    retorno = false;
                } 
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return retorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool UsuarioTienePermisos(int iUserId, int iDerechoId, FbTransaction st)
        {
            int iPerfilAdm = 0;
            bool retorno = false;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                String CmdTxt = @"SELECT count(*) PERMISOS from  usuario_perfil inner join perfil_der ON pd_perfil = up_perfil 
                                  where  up_personaid = @USUARIOID and pd_derecho = @DERECHOID ";

                auxPar = new FbParameter("@USUARIOID", FbDbType.Integer);
                auxPar.Value = iUserId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@DERECHOID", FbDbType.Integer);
                auxPar.Value = iDerechoId;
                parts.Add(auxPar);



                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                if (dr.Read())
                {
                    if (dr["PERMISOS"] != System.DBNull.Value)
                    {
                        iPerfilAdm = (int)(dr["PERMISOS"]);
                        if (iPerfilAdm > 0)
                            retorno = true;
                    }
                }
                else
                {
                    retorno = false;
                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return retorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }
        


        public CUSUARIOSD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            
            
            
            
        }
    }
}
