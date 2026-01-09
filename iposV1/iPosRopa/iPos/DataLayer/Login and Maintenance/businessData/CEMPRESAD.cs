
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



    public class CEMPRESAD
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


        public CEMPRESABE AgregarEMPRESAD(CEMPRESABE oCEMPRESA, FbTransaction st)
        {


            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@NOMBRE", FbDbType.Char);
                if (!(bool)oCEMPRESA.isnull["INOMBRE"])
                {
                    auxPar.Value = oCEMPRESA.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CALLE", FbDbType.Char);
                if (!(bool)oCEMPRESA.isnull["ICALLE"])
                {
                    auxPar.Value = oCEMPRESA.ICALLE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@COLONIA", FbDbType.Char);
                if (!(bool)oCEMPRESA.isnull["ICOLONIA"])
                {
                    auxPar.Value = oCEMPRESA.ICOLONIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LOCALIDAD", FbDbType.Char);
                if (!(bool)oCEMPRESA.isnull["ILOCALIDAD"])
                {
                    auxPar.Value = oCEMPRESA.ILOCALIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESTADO", FbDbType.Char);
                if (!(bool)oCEMPRESA.isnull["IESTADO"])
                {
                    auxPar.Value = oCEMPRESA.IESTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CP", FbDbType.Char);
                if (!(bool)oCEMPRESA.isnull["ICP"])
                {
                    auxPar.Value = oCEMPRESA.ICP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TELEFONO", FbDbType.Char);
                if (!(bool)oCEMPRESA.isnull["ITELEFONO"])
                {
                    auxPar.Value = oCEMPRESA.ITELEFONO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FAX", FbDbType.Char);
                if (!(bool)oCEMPRESA.isnull["IFAX"])
                {
                    auxPar.Value = oCEMPRESA.IFAX;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CORREOE", FbDbType.Char);
                if (!(bool)oCEMPRESA.isnull["ICORREOE"])
                {
                    auxPar.Value = oCEMPRESA.ICORREOE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PAGINAWEB", FbDbType.Char);
                if (!(bool)oCEMPRESA.isnull["IPAGINAWEB"])
                {
                    auxPar.Value = oCEMPRESA.IPAGINAWEB;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@RFC", FbDbType.Char);
                if (!(bool)oCEMPRESA.isnull["IRFC"])
                {
                    auxPar.Value = oCEMPRESA.IRFC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@LISTA_PRECIO_DEF", FbDbType.Char);
                if (!(bool)oCEMPRESA.isnull["ILISTA_PRECIO_DEF"])
                {
                    auxPar.Value = oCEMPRESA.ILISTA_PRECIO_DEF;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@IMP_PROD_DEF", FbDbType.Decimal);
                if (!(bool)oCEMPRESA.isnull["IIMP_PROD_DEF"])
                {
                    auxPar.Value = oCEMPRESA.IIMP_PROD_DEF;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@ESTADO_DEF", FbDbType.Char);
                if (!(bool)oCEMPRESA.isnull["IESTADO_DEF"])
                {
                    auxPar.Value = oCEMPRESA.IESTADO_DEF;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SUCURSAL", FbDbType.VarChar);
                if (!(bool)oCEMPRESA.isnull["ISUCURSAL"])
                {
                    auxPar.Value = oCEMPRESA.ISUCURSAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                string commandText = @"
        INSERT INTO EMPRESA
      (
    
NOMBRE,
CALLE,
COLONIA,
LOCALIDAD,
ESTADO,
CP,
TELEFONO,
FAX,
CORREOE,
PAGINAWEB,
RFC,
LISTA_PRECIO_DEF,
IMP_PROD_DEF,
ESTADO_DEF,

SUCURSAL
         )
Values (
@NOMBRE,
@CALLE,
@COLONIA,
@LOCALIDAD,
@ESTADO,
@CP,
@TELEFONO,
@FAX,
@CORREOE,
@PAGINAWEB,
@RFC,
@LISTA_PRECIO_DEF,
@IMP_PROD_DEF,
@ESTADO_DEF,

@SUCURSAL
); ";
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);
                return oCEMPRESA;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }

        public bool BorrarEMPRESAD(CEMPRESABE oCEMPRESA, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@NOMBRE", FbDbType.Char);
                auxPar.Value = oCEMPRESA.INOMBRE;
                parts.Add(auxPar);
                string commandText = @"  Delete from EMPRESA
  where
  NOMBRE=@NOMBRE
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

        public bool CambiarEMPRESAD(CEMPRESABE oCEMPRESANuevo, CEMPRESABE oCEMPRESAAnterior, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@NOMBRE", FbDbType.Char);
                if (!(bool)oCEMPRESANuevo.isnull["INOMBRE"])
                {
                    auxPar.Value = oCEMPRESANuevo.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@CALLE", FbDbType.Char);
                if (!(bool)oCEMPRESANuevo.isnull["ICALLE"])
                {
                    auxPar.Value = oCEMPRESANuevo.ICALLE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@COLONIA", FbDbType.Char);
                if (!(bool)oCEMPRESANuevo.isnull["ICOLONIA"])
                {
                    auxPar.Value = oCEMPRESANuevo.ICOLONIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@LOCALIDAD", FbDbType.Char);
                if (!(bool)oCEMPRESANuevo.isnull["ILOCALIDAD"])
                {
                    auxPar.Value = oCEMPRESANuevo.ILOCALIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@ESTADO", FbDbType.Char);
                if (!(bool)oCEMPRESANuevo.isnull["IESTADO"])
                {
                    auxPar.Value = oCEMPRESANuevo.IESTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@CP", FbDbType.Char);
                if (!(bool)oCEMPRESANuevo.isnull["ICP"])
                {
                    auxPar.Value = oCEMPRESANuevo.ICP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@TELEFONO", FbDbType.Char);
                if (!(bool)oCEMPRESANuevo.isnull["ITELEFONO"])
                {
                    auxPar.Value = oCEMPRESANuevo.ITELEFONO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@FAX", FbDbType.Char);
                if (!(bool)oCEMPRESANuevo.isnull["IFAX"])
                {
                    auxPar.Value = oCEMPRESANuevo.IFAX;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@CORREOE", FbDbType.Char);
                if (!(bool)oCEMPRESANuevo.isnull["ICORREOE"])
                {
                    auxPar.Value = oCEMPRESANuevo.ICORREOE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@PAGINAWEB", FbDbType.Char);
                if (!(bool)oCEMPRESANuevo.isnull["IPAGINAWEB"])
                {
                    auxPar.Value = oCEMPRESANuevo.IPAGINAWEB;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@RFC", FbDbType.Char);
                if (!(bool)oCEMPRESANuevo.isnull["IRFC"])
                {
                    auxPar.Value = oCEMPRESANuevo.IRFC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@LISTA_PRECIO_DEF", FbDbType.Char);
                if (!(bool)oCEMPRESANuevo.isnull["ILISTA_PRECIO_DEF"])
                {
                    auxPar.Value = oCEMPRESANuevo.ILISTA_PRECIO_DEF;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@IMP_PROD_DEF", FbDbType.Decimal);
                if (!(bool)oCEMPRESANuevo.isnull["IIMP_PROD_DEF"])
                {
                    auxPar.Value = oCEMPRESANuevo.IIMP_PROD_DEF;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@ESTADO_DEF", FbDbType.Char);
                if (!(bool)oCEMPRESANuevo.isnull["IESTADO_DEF"])
                {
                    auxPar.Value = oCEMPRESANuevo.IESTADO_DEF;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SUCURSAL", FbDbType.VarChar);
                if (!(bool)oCEMPRESANuevo.isnull["ISUCURSAL"])
                {
                    auxPar.Value = oCEMPRESANuevo.ISUCURSAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMBREAnt", FbDbType.Char);
                if (!(bool)oCEMPRESAAnterior.isnull["INOMBRE"])
                {
                    auxPar.Value = oCEMPRESAAnterior.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                string commandText = @"
  update  EMPRESA
  set
NOMBRE=@NOMBRE,
CALLE=@CALLE,
COLONIA=@COLONIA,
LOCALIDAD=@LOCALIDAD,
ESTADO=@ESTADO,
CP=@CP,
TELEFONO=@TELEFONO,
FAX=@FAX,
CORREOE=@CORREOE,
PAGINAWEB=@PAGINAWEB,
RFC=@RFC,
LISTA_PRECIO_DEF=@LISTA_PRECIO_DEF,
IMP_PROD_DEF=@IMP_PROD_DEF,
ESTADO_DEF=@ESTADO_DEF,

SUCURSAL=@SUCURSAL
  where 
NOMBRE=@NOMBREAnt
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

        public CEMPRESABE seleccionarEMPRESA(CEMPRESABE oCEMPRESA, FbTransaction st)
        {
            CEMPRESABE retorno = new CEMPRESABE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                String CmdTxt = @"select * from EMPRESA where
 NOMBRE=@NOMBRE  ";
                auxPar = new FbParameter("@NOMBRE", FbDbType.Char);
                auxPar.Value = oCEMPRESA.INOMBRE;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                if (dr.Read())
                {
                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = (string)(dr["NOMBRE"]);
                    }
                    if (dr["CALLE"] != System.DBNull.Value)
                    {
                        retorno.ICALLE = (string)(dr["CALLE"]);
                    }
                    if (dr["COLONIA"] != System.DBNull.Value)
                    {
                        retorno.ICOLONIA = (string)(dr["COLONIA"]);
                    }
                    if (dr["LOCALIDAD"] != System.DBNull.Value)
                    {
                        retorno.ILOCALIDAD = (string)(dr["LOCALIDAD"]);
                    }
                    if (dr["ESTADO"] != System.DBNull.Value)
                    {
                        retorno.IESTADO = (string)(dr["ESTADO"]);
                    }
                    if (dr["CP"] != System.DBNull.Value)
                    {
                        retorno.ICP = (string)(dr["CP"]);
                    }
                    if (dr["TELEFONO"] != System.DBNull.Value)
                    {
                        retorno.ITELEFONO = (string)(dr["TELEFONO"]);
                    }
                    if (dr["FAX"] != System.DBNull.Value)
                    {
                        retorno.IFAX = (string)(dr["FAX"]);
                    }
                    if (dr["CORREOE"] != System.DBNull.Value)
                    {
                        retorno.ICORREOE = (string)(dr["CORREOE"]);
                    }
                    if (dr["PAGINAWEB"] != System.DBNull.Value)
                    {
                        retorno.IPAGINAWEB = (string)(dr["PAGINAWEB"]);
                    }
                    if (dr["RFC"] != System.DBNull.Value)
                    {
                        retorno.IRFC = (string)(dr["RFC"]);
                    }
                    if (dr["LISTA_PRECIO_DEF"] != System.DBNull.Value)
                    {
                        retorno.ILISTA_PRECIO_DEF = (string)(dr["LISTA_PRECIO_DEF"]);
                    }
                    if (dr["IMP_PROD_DEF"] != System.DBNull.Value)
                    {
                        retorno.IIMP_PROD_DEF = (decimal)(dr["IMP_PROD_DEF"]);
                    }
                    if (dr["ESTADO_DEF"] != System.DBNull.Value)
                    {
                        retorno.IESTADO_DEF = (string)(dr["ESTADO_DEF"]);
                    }
                    if (dr["SUCURSAL"] != System.DBNull.Value)
                    {
                        retorno.ISUCURSAL = (string)(dr["SUCURSAL"]);
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
        public CEMPRESABE seleccionarEMPRESAActual(FbTransaction st)
        {
            CEMPRESABE retorno = new CEMPRESABE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                String CmdTxt = @"select * from EMPRESA";
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                if (dr.Read())
                {
                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = (string)(dr["NOMBRE"]);
                    }
                    if (dr["CALLE"] != System.DBNull.Value)
                    {
                        retorno.ICALLE = (string)(dr["CALLE"]);
                    }
                    if (dr["COLONIA"] != System.DBNull.Value)
                    {
                        retorno.ICOLONIA = (string)(dr["COLONIA"]);
                    }
                    if (dr["LOCALIDAD"] != System.DBNull.Value)
                    {
                        retorno.ILOCALIDAD = (string)(dr["LOCALIDAD"]);
                    }
                    if (dr["ESTADO"] != System.DBNull.Value)
                    {
                        retorno.IESTADO = (string)(dr["ESTADO"]);
                    }
                    if (dr["CP"] != System.DBNull.Value)
                    {
                        retorno.ICP = (string)(dr["CP"]);
                    }
                    if (dr["TELEFONO"] != System.DBNull.Value)
                    {
                        retorno.ITELEFONO = (string)(dr["TELEFONO"]);
                    }
                    if (dr["FAX"] != System.DBNull.Value)
                    {
                        retorno.IFAX = (string)(dr["FAX"]);
                    }
                    if (dr["CORREOE"] != System.DBNull.Value)
                    {
                        retorno.ICORREOE = (string)(dr["CORREOE"]);
                    }
                    if (dr["PAGINAWEB"] != System.DBNull.Value)
                    {
                        retorno.IPAGINAWEB = (string)(dr["PAGINAWEB"]);
                    }
                    if (dr["RFC"] != System.DBNull.Value)
                    {
                        retorno.IRFC = (string)(dr["RFC"]);
                    }
                    if (dr["LISTA_PRECIO_DEF"] != System.DBNull.Value)
                    {
                        retorno.ILISTA_PRECIO_DEF = (string)(dr["LISTA_PRECIO_DEF"]);
                    }
                    if (dr["IMP_PROD_DEF"] != System.DBNull.Value)
                    {
                        retorno.IIMP_PROD_DEF = (decimal)(dr["IMP_PROD_DEF"]);
                    }
                    if (dr["ESTADO_DEF"] != System.DBNull.Value)
                    {
                        retorno.IESTADO_DEF = (string)(dr["ESTADO_DEF"]);
                    }
                    if (dr["SUCURSAL"] != System.DBNull.Value)
                    {
                        retorno.ISUCURSAL = (string)(dr["SUCURSAL"]);
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
        public DataSet enlistarEMPRESA()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_EMPRESA_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }

        }

        public DataSet enlistarCortoEMPRESA()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_EMPRESA_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }

        }
        public int ExisteEMPRESA(CEMPRESABE oCEMPRESA, FbTransaction st)
        {

            int retorno;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@NOMBRE", FbDbType.Char);
                auxPar.Value = oCEMPRESA.INOMBRE;
                parts.Add(auxPar);
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from EMPRESA where
  NOMBRE=@NOMBRE  
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
        public CEMPRESABE AgregarEMPRESA(CEMPRESABE oCEMPRESA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteEMPRESA(oCEMPRESA, st);
                if (iRes == 1)
                {
                    this.IComentario = "El EMPRESA ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarEMPRESAD(oCEMPRESA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }
        public bool BorrarEMPRESA(CEMPRESABE oCEMPRESA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteEMPRESA(oCEMPRESA, st);
                if (iRes == 0)
                {
                    this.IComentario = "El EMPRESA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarEMPRESAD(oCEMPRESA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }
        public bool CambiarEMPRESA(CEMPRESABE oCEMPRESANuevo, CEMPRESABE oCEMPRESAAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteEMPRESA(oCEMPRESAAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El EMPRESA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarEMPRESAD(oCEMPRESANuevo, oCEMPRESAAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }
        public CEMPRESAD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();




        }
    }
}
