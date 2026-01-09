
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



    public class CINCREMENTABLESD
    {
        private string sCadenaConexion;
        public const string _USER_ID = "USER_ID";
        public const string _PERFIL_ID = "PERFIL_ID";
        public const string _MOV_VENTAS = "MOV_VENTAS";
        public const string _MOV_RECIBIDOS = "MOV_RECIBIDOS";
        public const string _MOV_INVENTARIO = "MOV_INVENTARIO";
        public const string _PA_NUMERO = "PA_NUMERO";
        public const string _GV_VENTA = "GV_VENTA";
        public const string _CL_CLIENTE = "CL_CLIENTE";
        public const string _PD_IDPRODUCTO = "PD_IDPRODUCTO";
        public const string _KARDEX_ID = "KARDEX_ID";
        public const string _KARDEX_GROUP_ID = "KARDEX_GROUPID";
        public const string _EOC_COMPRA = "EOC_COMPRA";

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


        public CINCREMENTABLESBE AgregarINCREMENTABLESD(CINCREMENTABLESBE oCINCREMENTABLES, FbTransaction st)
        {


            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@NC_INCR", FbDbType.SmallInt);
                if (!(bool)oCINCREMENTABLES.isnull["INC_INCR"])
                {
                    auxPar.Value = oCINCREMENTABLES.INC_INCR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NC_DESC", FbDbType.VarChar);
                if (!(bool)oCINCREMENTABLES.isnull["INC_DESC"])
                {
                    auxPar.Value = oCINCREMENTABLES.INC_DESC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NC_NEXTID", FbDbType.BigInt);
                if (!(bool)oCINCREMENTABLES.isnull["INC_NEXTID"])
                {
                    auxPar.Value = oCINCREMENTABLES.INC_NEXTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                string commandText = @"
        INSERT INTO INCREMENTABLES
      (
    
NC_INCR,
NC_DESC,
NC_NEXTID
         )
Values (
@NC_INCR,
@NC_DESC,
@NC_NEXTID
); ";
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);
                return oCINCREMENTABLES;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }

        public bool BorrarINCREMENTABLESD(CINCREMENTABLESBE oCINCREMENTABLES, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@NC_INCR", FbDbType.SmallInt);
                auxPar.Value = oCINCREMENTABLES.INC_INCR;
                parts.Add(auxPar);
                string commandText = @"  Delete from INCREMENTABLES
  where
  NC_INCR=@NC_INCR
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

        public bool CambiarINCREMENTABLESD(CINCREMENTABLESBE oCINCREMENTABLESNuevo, CINCREMENTABLESBE oCINCREMENTABLESAnterior, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@NC_INCR", FbDbType.SmallInt);
                if (!(bool)oCINCREMENTABLESNuevo.isnull["INC_INCR"])
                {
                    auxPar.Value = oCINCREMENTABLESNuevo.INC_INCR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@NC_DESC", FbDbType.VarChar);
                if (!(bool)oCINCREMENTABLESNuevo.isnull["INC_DESC"])
                {
                    auxPar.Value = oCINCREMENTABLESNuevo.INC_DESC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@NC_NEXTID", FbDbType.BigInt);
                if (!(bool)oCINCREMENTABLESNuevo.isnull["INC_NEXTID"])
                {
                    auxPar.Value = oCINCREMENTABLESNuevo.INC_NEXTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@NC_INCRAnt", FbDbType.SmallInt);
                if (!(bool)oCINCREMENTABLESAnterior.isnull["INC_INCR"])
                {
                    auxPar.Value = oCINCREMENTABLESAnterior.INC_INCR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                string commandText = @"
  update  INCREMENTABLES
  set
NC_INCR=@NC_INCR,
NC_DESC=@NC_DESC,
NC_NEXTID=@NC_NEXTID
  where 
NC_INCR=@NC_INCRAnt
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

        public CINCREMENTABLESBE seleccionarINCREMENTABLES(CINCREMENTABLESBE oCINCREMENTABLES, FbTransaction st)
        {
            CINCREMENTABLESBE retorno = new CINCREMENTABLESBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                String CmdTxt = @"select * from INCREMENTABLES where
 NC_INCR=@NC_INCR  ";
                auxPar = new FbParameter("@NC_INCR", FbDbType.SmallInt);
                auxPar.Value = oCINCREMENTABLES.INC_INCR;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                if (dr.Read())
                {
                    if (dr["NC_DESC"] != System.DBNull.Value)
                    {
                        retorno.INC_DESC = (string)(dr["NC_DESC"]);
                    }
                    if (dr["NC_NEXTID"] != System.DBNull.Value)
                    {
                        retorno.INC_NEXTID = (long)(dr["NC_NEXTID"]);
                    }
                    if (dr["NC_INCR"] != System.DBNull.Value)
                    {
                        retorno.INC_INCR = short.Parse(dr["NC_INCR"].ToString());
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
        public DataSet enlistarINCREMENTABLES()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_INCREMENTABLES_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }

        }

        public DataSet enlistarCortoINCREMENTABLES()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_INCREMENTABLES_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }

        }
        public int ExisteINCREMENTABLES(CINCREMENTABLESBE oCINCREMENTABLES, FbTransaction st)
        {

            int retorno;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@NC_INCR", FbDbType.SmallInt);
                auxPar.Value = oCINCREMENTABLES.INC_INCR;
                parts.Add(auxPar);
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from INCREMENTABLES where
  NC_INCR=@NC_INCR  
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
        public CINCREMENTABLESBE AgregarINCREMENTABLES(CINCREMENTABLESBE oCINCREMENTABLES, FbTransaction st)
        {
            try
            {
                int iRes = ExisteINCREMENTABLES(oCINCREMENTABLES, st);
                if (iRes == 1)
                {
                    this.IComentario = "El INCREMENTABLES ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarINCREMENTABLESD(oCINCREMENTABLES, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }
        public bool BorrarINCREMENTABLES(CINCREMENTABLESBE oCINCREMENTABLES, FbTransaction st)
        {
            try
            {
                int iRes = ExisteINCREMENTABLES(oCINCREMENTABLES, st);
                if (iRes == 0)
                {
                    this.IComentario = "El INCREMENTABLES no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarINCREMENTABLESD(oCINCREMENTABLES, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }
        public bool CambiarINCREMENTABLES(CINCREMENTABLESBE oCINCREMENTABLESNuevo, CINCREMENTABLESBE oCINCREMENTABLESAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteINCREMENTABLES(oCINCREMENTABLESAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El INCREMENTABLES no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarINCREMENTABLESD(oCINCREMENTABLESNuevo, oCINCREMENTABLESAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }
        public bool IncrementarValorD(string key, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@NC_DESC", FbDbType.VarChar);
                auxPar.Value = key;

                parts.Add(auxPar);
                string commandText = @"
  update  INCREMENTABLES
  set
NC_NEXTID= NC_NEXTID + 1
  where 
NC_DESC=@NC_DESC
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

        public long seleccionarValorINCREMENTABLE(string key, FbTransaction st)
        {
            long retorno = -1;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                String CmdTxt = @"select * from INCREMENTABLES where
 NC_DESC=@NC_DESC  ";
                auxPar = new FbParameter("@NC_DESC", FbDbType.VarChar);
                auxPar.Value = key;
                parts.Add(auxPar);
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                if (dr.Read())
                {

                    if (dr["NC_NEXTID"] != System.DBNull.Value)
                    {
                        retorno = (long)(dr["NC_NEXTID"]);
                    }

                }
                else
                {
                    retorno = -1;
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
        public long POP_INCREMENTABLE(string key, FbTransaction st)
        {
            long retorno = seleccionarValorINCREMENTABLE(key, st);
            if (retorno == -1)
            {
                return retorno;
            }
            if (!IncrementarValorD(key, st))
            {
                return -1;
            }
            return retorno;
        }
        public CINCREMENTABLESD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();




        }
    }
}
