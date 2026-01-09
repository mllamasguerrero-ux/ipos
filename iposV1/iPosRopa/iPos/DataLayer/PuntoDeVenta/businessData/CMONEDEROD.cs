
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

    [Transaction(TransactionOption.Supported)]


    public class CMONEDEROD
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
        public CMONEDEROBE AgregarMONEDEROD(CMONEDEROBE oCMONEDERO, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCMONEDERO.isnull["IID"])
                {
                    auxPar.Value = oCMONEDERO.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCMONEDERO.isnull["IACTIVO"])
                {
                    auxPar.Value = oCMONEDERO.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMONEDERO.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCMONEDERO.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMONEDERO.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCMONEDERO.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCMONEDERO.isnull["ICLAVE"])
                {
                    auxPar.Value = oCMONEDERO.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCMONEDERO.isnull["INOMBRE"])
                {
                    auxPar.Value = oCMONEDERO.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SALDO", FbDbType.Numeric);
                if (!(bool)oCMONEDERO.isnull["ISALDO"])
                {
                    auxPar.Value = oCMONEDERO.ISALDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VIGENCIA", FbDbType.Date);
                if (!(bool)oCMONEDERO.isnull["IVIGENCIA"])
                {
                    auxPar.Value = oCMONEDERO.IVIGENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PERDIDO", FbDbType.Numeric);
                if (!(bool)oCMONEDERO.isnull["IPERDIDO"])
                {
                    auxPar.Value = oCMONEDERO.IPERDIDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO MONEDERO
      (
    
ID,

ACTIVO,

CREADO,

CREADOPOR_USERID,

MODIFICADO,

MODIFICADOPOR_USERID,

CLAVE,

NOMBRE,

SALDO,

VIGENCIA,

PERDIDO
         )

Values (

@ID,

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@CLAVE,

@NOMBRE,

@SALDO,

@VIGENCIA,

@PERDIDO
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCMONEDERO;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarMONEDEROD(CMONEDEROBE oCMONEDERO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMONEDERO.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from MONEDERO
  where

  ID=@ID
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
        public bool CambiarMONEDEROD(CMONEDEROBE oCMONEDERONuevo, CMONEDEROBE oCMONEDEROAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCMONEDERONuevo.isnull["IID"])
                {
                    auxPar.Value = oCMONEDERONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCMONEDERONuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCMONEDERONuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMONEDERONuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCMONEDERONuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMONEDERONuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCMONEDERONuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCMONEDERONuevo.isnull["ICLAVE"])
                {
                    auxPar.Value = oCMONEDERONuevo.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCMONEDERONuevo.isnull["INOMBRE"])
                {
                    auxPar.Value = oCMONEDERONuevo.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SALDO", FbDbType.Numeric);
                if (!(bool)oCMONEDERONuevo.isnull["ISALDO"])
                {
                    auxPar.Value = oCMONEDERONuevo.ISALDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@VIGENCIA", FbDbType.Date);
                if (!(bool)oCMONEDERONuevo.isnull["IVIGENCIA"])
                {
                    auxPar.Value = oCMONEDERONuevo.IVIGENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PERDIDO", FbDbType.Numeric);
                if (!(bool)oCMONEDERONuevo.isnull["IPERDIDO"])
                {
                    auxPar.Value = oCMONEDERONuevo.IPERDIDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCMONEDEROAnterior.isnull["IID"])
                {
                    auxPar.Value = oCMONEDEROAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  MONEDERO
  set

ID=@ID,

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

CLAVE=@CLAVE,

NOMBRE=@NOMBRE,

SALDO=@SALDO,

VIGENCIA=@VIGENCIA,

PERDIDO=@PERDIDO
  where 

ID=@IDAnt
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
        public CMONEDEROBE seleccionarMONEDERO(CMONEDEROBE oCMONEDERO, FbTransaction st)
        {




            CMONEDEROBE retorno = new CMONEDEROBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from MONEDERO where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMONEDERO.IID;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["ID"] != System.DBNull.Value)
                    {
                        retorno.IID = (long)(dr["ID"]);
                    }

                    if (dr["ACTIVO"] != System.DBNull.Value)
                    {
                        retorno.IACTIVO = (string)(dr["ACTIVO"]);
                    }

                    if (dr["CREADO"] != System.DBNull.Value)
                    {
                        retorno.ICREADO = (object)(dr["CREADO"]);
                    }

                    if (dr["CREADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.ICREADOPOR_USERID = (long)(dr["CREADOPOR_USERID"]);
                    }

                    if (dr["MODIFICADO"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADO = (object)(dr["MODIFICADO"]);
                    }

                    if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
                    }

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = (string)(dr["CLAVE"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (dr["SALDO"] != System.DBNull.Value)
                    {
                        retorno.ISALDO = (decimal)(dr["SALDO"]);
                    }

                    if (dr["VIGENCIA"] != System.DBNull.Value)
                    {
                        retorno.IVIGENCIA = (DateTime)(dr["VIGENCIA"]);
                    }

                    if (dr["PERDIDO"] != System.DBNull.Value)
                    {
                        retorno.IPERDIDO = (decimal)(dr["PERDIDO"]);
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









        [AutoComplete]
        public DataSet enlistarMONEDERO()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_MONEDERO_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoMONEDERO()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_MONEDERO_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteMONEDERO(CMONEDEROBE oCMONEDERO, FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMONEDERO.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from MONEDERO where

  ID=@ID  
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




        public CMONEDEROBE AgregarMONEDERO(CMONEDEROBE oCMONEDERO, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMONEDERO(oCMONEDERO, st);
                if (iRes == 1)
                {
                    this.IComentario = "El MONEDERO ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarMONEDEROD(oCMONEDERO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarMONEDERO(CMONEDEROBE oCMONEDERO, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMONEDERO(oCMONEDERO, st);
                if (iRes == 0)
                {
                    this.IComentario = "El MONEDERO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarMONEDEROD(oCMONEDERO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarMONEDERO(CMONEDEROBE oCMONEDERONuevo, CMONEDEROBE oCMONEDEROAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMONEDERO(oCMONEDEROAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El MONEDERO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarMONEDEROD(oCMONEDERONuevo, oCMONEDEROAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }






        /*
        public bool MONEDERO_CALCULARSALDO(CMONEDEROBE oCMONEDERO, DateTime fecha, ref decimal saldo, ref DateTime vigencia, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                auxPar.Value = fecha;
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONEDERO", FbDbType.BigInt);
                auxPar.Value = oCMONEDERO.IID;
                parts.Add(auxPar);



                auxPar = new FbParameter("@SALDO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@VIGENCIA", FbDbType.Date);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"MONEDERO_CALCULARSALDO";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);


                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        this.iComentario = "Hubo un error";
                        return false;
                    }
                }


                if (!(arParms[arParms.Length - 3].Value == System.DBNull.Value))
                {

                    saldo = (decimal)arParms[arParms.Length - 3].Value;
                }
                else
                {
                    this.iComentario = "Hubo un error";
                    return false;
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {

                    vigencia = (DateTime)arParms[arParms.Length - 2].Value;
                }
                else
                {
                    this.iComentario = "Hubo un error";
                    return false;
                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }
        */

        public decimal AbonoDisponibleDocto(CDOCTOBE oCDOCTO, FbTransaction st)
        {
            decimal retorno = 0;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);

                string commandText = @"select sum(coalesce(monederoabono,0))  MONEDERODISPONIBLE from movto where doctoid = @DOCTOID";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);




                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, commandText, arParms);



                if (dr.Read())
                {

                    if (dr["MONEDERODISPONIBLE"] != System.DBNull.Value)
                    {
                        retorno = (decimal)(dr["MONEDERODISPONIBLE"]);
                    }
                    else
                    {
                        retorno = 0;
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
                return 0;
            }
        }



        public CMONEDEROBE seleccionarMONEDEROXClave(CMONEDEROBE oCMONEDERO, FbTransaction st)
        {


            CMONEDEROBE retorno = new CMONEDEROBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from MONEDERO where CLAVE=@CLAVE  ";


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                auxPar.Value = oCMONEDERO.ICLAVE;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["ID"] != System.DBNull.Value)
                    {
                        retorno.IID = (long)(dr["ID"]);
                    }

                    if (dr["ACTIVO"] != System.DBNull.Value)
                    {
                        retorno.IACTIVO = (string)(dr["ACTIVO"]);
                    }

                    if (dr["CREADO"] != System.DBNull.Value)
                    {
                        retorno.ICREADO = (object)(dr["CREADO"]);
                    }

                    if (dr["CREADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.ICREADOPOR_USERID = (long)(dr["CREADOPOR_USERID"]);
                    }

                    if (dr["MODIFICADO"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADO = (object)(dr["MODIFICADO"]);
                    }

                    if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
                    }

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = (string)(dr["CLAVE"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (dr["SALDO"] != System.DBNull.Value)
                    {
                        retorno.ISALDO = (decimal)(dr["SALDO"]);
                    }

                    if (dr["VIGENCIA"] != System.DBNull.Value)
                    {
                        retorno.IVIGENCIA = (DateTime)(dr["VIGENCIA"]);
                    }

                    if (dr["PERDIDO"] != System.DBNull.Value)
                    {
                        retorno.IPERDIDO = (decimal)(dr["PERDIDO"]);
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





        public bool MONEDERO_APLICAR(CMONEDEROBE oCMONEDERO, CDOCTOBE oCDOCTO, decimal dMontoAAplicar, FbTransaction st)
        {

            FbTransaction ft = null;
            FbConnection fc = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONEDERO", FbDbType.BigInt);
                auxPar.Value = oCMONEDERO.IID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVEMONEDERO", FbDbType.VarChar);
                auxPar.Value = oCMONEDERO.ICLAVE;
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONTOAPLICAR", FbDbType.Numeric);
                auxPar.Value = dMontoAAplicar;
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTOAPLICADO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"MONEDERO_APLICAR";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                {
                    fc = new FbConnection(this.sCadenaConexion);
                    fc.Open();
                    ft = fc.BeginTransaction();
                    SqlHelper.ExecuteNonQuery(ft, CommandType.StoredProcedure, commandText, arParms);

                }
                /*
                SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);*/
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);


                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        this.iComentario = "Hubo un error";

                        if (ft != null)
                            ft.Rollback();
                        if (fc != null)
                            fc.Close();

                        return false;
                    }
                }

                /*
                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {

                    saldo = (decimal)arParms[arParms.Length - 2].Value;
                }
                else
                {
                    this.iComentario = "Hubo un error";
                    return false;
                }*/


                if (ft != null)
                    ft.Commit();
                if (fc != null)
                    fc.Close();

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;

                if (ft != null)
                    ft.Rollback();
                if (fc != null)
                    fc.Close();

                return false;
            }
            finally
            {/*
                if (ft != null)
                    ft.Rollback();
                if (fc != null)
                    fc.Close();*/
            }
        }



        public CMONEDEROD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
