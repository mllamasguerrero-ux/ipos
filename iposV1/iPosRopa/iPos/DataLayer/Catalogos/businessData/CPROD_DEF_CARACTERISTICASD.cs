

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


    public class CPROD_DEF_CARACTERISTICASD
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
        public CPROD_DEF_CARACTERISTICASBE AgregarPROD_DEF_CARACTERISTICASD(CPROD_DEF_CARACTERISTICASBE oCPROD_DEF_CARACTERISTICAS, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCPROD_DEF_CARACTERISTICAS.isnull["IID"])
                {
                    auxPar.Value = oCPROD_DEF_CARACTERISTICAS.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCPROD_DEF_CARACTERISTICAS.isnull["IACTIVO"])
                {
                    auxPar.Value = oCPROD_DEF_CARACTERISTICAS.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPROD_DEF_CARACTERISTICAS.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCPROD_DEF_CARACTERISTICAS.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPROD_DEF_CARACTERISTICAS.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCPROD_DEF_CARACTERISTICAS.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TEXTO1", FbDbType.VarChar);
                if (!(bool)oCPROD_DEF_CARACTERISTICAS.isnull["ITEXTO1"])
                {
                    auxPar.Value = oCPROD_DEF_CARACTERISTICAS.ITEXTO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TEXTO2", FbDbType.VarChar);
                if (!(bool)oCPROD_DEF_CARACTERISTICAS.isnull["ITEXTO2"])
                {
                    auxPar.Value = oCPROD_DEF_CARACTERISTICAS.ITEXTO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TEXTO3", FbDbType.VarChar);
                if (!(bool)oCPROD_DEF_CARACTERISTICAS.isnull["ITEXTO3"])
                {
                    auxPar.Value = oCPROD_DEF_CARACTERISTICAS.ITEXTO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TEXTO4", FbDbType.VarChar);
                if (!(bool)oCPROD_DEF_CARACTERISTICAS.isnull["ITEXTO4"])
                {
                    auxPar.Value = oCPROD_DEF_CARACTERISTICAS.ITEXTO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TEXTO5", FbDbType.VarChar);
                if (!(bool)oCPROD_DEF_CARACTERISTICAS.isnull["ITEXTO5"])
                {
                    auxPar.Value = oCPROD_DEF_CARACTERISTICAS.ITEXTO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TEXTO6", FbDbType.VarChar);
                if (!(bool)oCPROD_DEF_CARACTERISTICAS.isnull["ITEXTO6"])
                {
                    auxPar.Value = oCPROD_DEF_CARACTERISTICAS.ITEXTO6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUMERO1", FbDbType.VarChar);
                if (!(bool)oCPROD_DEF_CARACTERISTICAS.isnull["INUMERO1"])
                {
                    auxPar.Value = oCPROD_DEF_CARACTERISTICAS.INUMERO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUMERO2", FbDbType.VarChar);
                if (!(bool)oCPROD_DEF_CARACTERISTICAS.isnull["INUMERO2"])
                {
                    auxPar.Value = oCPROD_DEF_CARACTERISTICAS.INUMERO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUMERO3", FbDbType.VarChar);
                if (!(bool)oCPROD_DEF_CARACTERISTICAS.isnull["INUMERO3"])
                {
                    auxPar.Value = oCPROD_DEF_CARACTERISTICAS.INUMERO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUMERO4", FbDbType.VarChar);
                if (!(bool)oCPROD_DEF_CARACTERISTICAS.isnull["INUMERO4"])
                {
                    auxPar.Value = oCPROD_DEF_CARACTERISTICAS.INUMERO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHA1", FbDbType.VarChar);
                if (!(bool)oCPROD_DEF_CARACTERISTICAS.isnull["IFECHA1"])
                {
                    auxPar.Value = oCPROD_DEF_CARACTERISTICAS.IFECHA1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHA2", FbDbType.VarChar);
                if (!(bool)oCPROD_DEF_CARACTERISTICAS.isnull["IFECHA2"])
                {
                    auxPar.Value = oCPROD_DEF_CARACTERISTICAS.IFECHA2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO PROD_DEF_CARACTERISTICAS
      (
    
ID,

ACTIVO,

CREADO,

CREADOPOR_USERID,

MODIFICADO,

MODIFICADOPOR_USERID,

TEXTO1,

TEXTO2,

TEXTO3,

TEXTO4,

TEXTO5,

TEXTO6,

NUMERO1,

NUMERO2,

NUMERO3,

NUMERO4,

FECHA1,

FECHA2
         )

Values (

@ID,

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@TEXTO1,

@TEXTO2,

@TEXTO3,

@TEXTO4,

@TEXTO5,

@TEXTO6,

@NUMERO1,

@NUMERO2,

@NUMERO3,

@NUMERO4,

@FECHA1,

@FECHA2
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCPROD_DEF_CARACTERISTICAS;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarPROD_DEF_CARACTERISTICASD(CPROD_DEF_CARACTERISTICASBE oCPROD_DEF_CARACTERISTICAS, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPROD_DEF_CARACTERISTICAS.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from PROD_DEF_CARACTERISTICAS
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
        public bool CambiarPROD_DEF_CARACTERISTICASD(CPROD_DEF_CARACTERISTICASBE oCPROD_DEF_CARACTERISTICASNuevo, CPROD_DEF_CARACTERISTICASBE oCPROD_DEF_CARACTERISTICASAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@TEXTO1", FbDbType.VarChar);
                if (!(bool)oCPROD_DEF_CARACTERISTICASNuevo.isnull["ITEXTO1"])
                {
                    auxPar.Value = oCPROD_DEF_CARACTERISTICASNuevo.ITEXTO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TEXTO2", FbDbType.VarChar);
                if (!(bool)oCPROD_DEF_CARACTERISTICASNuevo.isnull["ITEXTO2"])
                {
                    auxPar.Value = oCPROD_DEF_CARACTERISTICASNuevo.ITEXTO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TEXTO3", FbDbType.VarChar);
                if (!(bool)oCPROD_DEF_CARACTERISTICASNuevo.isnull["ITEXTO3"])
                {
                    auxPar.Value = oCPROD_DEF_CARACTERISTICASNuevo.ITEXTO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TEXTO4", FbDbType.VarChar);
                if (!(bool)oCPROD_DEF_CARACTERISTICASNuevo.isnull["ITEXTO4"])
                {
                    auxPar.Value = oCPROD_DEF_CARACTERISTICASNuevo.ITEXTO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TEXTO5", FbDbType.VarChar);
                if (!(bool)oCPROD_DEF_CARACTERISTICASNuevo.isnull["ITEXTO5"])
                {
                    auxPar.Value = oCPROD_DEF_CARACTERISTICASNuevo.ITEXTO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TEXTO6", FbDbType.VarChar);
                if (!(bool)oCPROD_DEF_CARACTERISTICASNuevo.isnull["ITEXTO6"])
                {
                    auxPar.Value = oCPROD_DEF_CARACTERISTICASNuevo.ITEXTO6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMERO1", FbDbType.VarChar);
                if (!(bool)oCPROD_DEF_CARACTERISTICASNuevo.isnull["INUMERO1"])
                {
                    auxPar.Value = oCPROD_DEF_CARACTERISTICASNuevo.INUMERO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMERO2", FbDbType.VarChar);
                if (!(bool)oCPROD_DEF_CARACTERISTICASNuevo.isnull["INUMERO2"])
                {
                    auxPar.Value = oCPROD_DEF_CARACTERISTICASNuevo.INUMERO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMERO3", FbDbType.VarChar);
                if (!(bool)oCPROD_DEF_CARACTERISTICASNuevo.isnull["INUMERO3"])
                {
                    auxPar.Value = oCPROD_DEF_CARACTERISTICASNuevo.INUMERO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMERO4", FbDbType.VarChar);
                if (!(bool)oCPROD_DEF_CARACTERISTICASNuevo.isnull["INUMERO4"])
                {
                    auxPar.Value = oCPROD_DEF_CARACTERISTICASNuevo.INUMERO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHA1", FbDbType.VarChar);
                if (!(bool)oCPROD_DEF_CARACTERISTICASNuevo.isnull["IFECHA1"])
                {
                    auxPar.Value = oCPROD_DEF_CARACTERISTICASNuevo.IFECHA1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHA2", FbDbType.VarChar);
                if (!(bool)oCPROD_DEF_CARACTERISTICASNuevo.isnull["IFECHA2"])
                {
                    auxPar.Value = oCPROD_DEF_CARACTERISTICASNuevo.IFECHA2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  PROD_DEF_CARACTERISTICAS
  set

TEXTO1=@TEXTO1,

TEXTO2=@TEXTO2,

TEXTO3=@TEXTO3,

TEXTO4=@TEXTO4,

TEXTO5=@TEXTO5,

TEXTO6=@TEXTO6,

NUMERO1=@NUMERO1,

NUMERO2=@NUMERO2,

NUMERO3=@NUMERO3,

NUMERO4=@NUMERO4,

FECHA1=@FECHA1,

FECHA2=@FECHA2
  where 

1 = 1
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
        public CPROD_DEF_CARACTERISTICASBE seleccionarPROD_DEF_CARACTERISTICAS(CPROD_DEF_CARACTERISTICASBE oCPROD_DEF_CARACTERISTICAS, FbTransaction st)
        {




            CPROD_DEF_CARACTERISTICASBE retorno = new CPROD_DEF_CARACTERISTICASBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                //FbParameter auxPar;

                String CmdTxt = @"select * from PROD_DEF_CARACTERISTICAS ";


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

                    if (dr["TEXTO1"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO1 = (string)(dr["TEXTO1"]);
                    }

                    if (dr["TEXTO2"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO2 = (string)(dr["TEXTO2"]);
                    }

                    if (dr["TEXTO3"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO3 = (string)(dr["TEXTO3"]);
                    }

                    if (dr["TEXTO4"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO4 = (string)(dr["TEXTO4"]);
                    }

                    if (dr["TEXTO5"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO5 = (string)(dr["TEXTO5"]);
                    }

                    if (dr["TEXTO6"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO6 = (string)(dr["TEXTO6"]);
                    }

                    if (dr["NUMERO1"] != System.DBNull.Value)
                    {
                        retorno.INUMERO1 = (string)(dr["NUMERO1"]);
                    }

                    if (dr["NUMERO2"] != System.DBNull.Value)
                    {
                        retorno.INUMERO2 = (string)(dr["NUMERO2"]);
                    }

                    if (dr["NUMERO3"] != System.DBNull.Value)
                    {
                        retorno.INUMERO3 = (string)(dr["NUMERO3"]);
                    }

                    if (dr["NUMERO4"] != System.DBNull.Value)
                    {
                        retorno.INUMERO4 = (string)(dr["NUMERO4"]);
                    }

                    if (dr["FECHA1"] != System.DBNull.Value)
                    {
                        retorno.IFECHA1 = (string)(dr["FECHA1"]);
                    }

                    if (dr["FECHA2"] != System.DBNull.Value)
                    {
                        retorno.IFECHA2 = (string)(dr["FECHA2"]);
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
        public DataSet enlistarPROD_DEF_CARACTERISTICAS()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PROD_DEF_CARACTERISTICAS_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoPROD_DEF_CARACTERISTICAS()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PROD_DEF_CARACTERISTICAS_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExistePROD_DEF_CARACTERISTICAS(CPROD_DEF_CARACTERISTICASBE oCPROD_DEF_CARACTERISTICAS, FbTransaction st)
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
                auxPar.Value = oCPROD_DEF_CARACTERISTICAS.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from PROD_DEF_CARACTERISTICAS where

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




        public CPROD_DEF_CARACTERISTICASBE AgregarPROD_DEF_CARACTERISTICAS(CPROD_DEF_CARACTERISTICASBE oCPROD_DEF_CARACTERISTICAS, FbTransaction st)
        {
            try
            {
                int iRes = ExistePROD_DEF_CARACTERISTICAS(oCPROD_DEF_CARACTERISTICAS, st);
                if (iRes == 1)
                {
                    this.IComentario = "El PROD_DEF_CARACTERISTICAS ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarPROD_DEF_CARACTERISTICASD(oCPROD_DEF_CARACTERISTICAS, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarPROD_DEF_CARACTERISTICAS(CPROD_DEF_CARACTERISTICASBE oCPROD_DEF_CARACTERISTICAS, FbTransaction st)
        {
            try
            {
                int iRes = ExistePROD_DEF_CARACTERISTICAS(oCPROD_DEF_CARACTERISTICAS, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PROD_DEF_CARACTERISTICAS no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarPROD_DEF_CARACTERISTICASD(oCPROD_DEF_CARACTERISTICAS, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarPROD_DEF_CARACTERISTICAS(CPROD_DEF_CARACTERISTICASBE oCPROD_DEF_CARACTERISTICASNuevo, CPROD_DEF_CARACTERISTICASBE oCPROD_DEF_CARACTERISTICASAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExistePROD_DEF_CARACTERISTICAS(oCPROD_DEF_CARACTERISTICASAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PROD_DEF_CARACTERISTICAS no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarPROD_DEF_CARACTERISTICASD(oCPROD_DEF_CARACTERISTICASNuevo, oCPROD_DEF_CARACTERISTICASAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CPROD_DEF_CARACTERISTICASD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
