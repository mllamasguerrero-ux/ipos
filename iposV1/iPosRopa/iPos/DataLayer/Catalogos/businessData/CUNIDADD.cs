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


    public class CUNIDADD
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
        public CUNIDADBE AgregarUNIDADD(CUNIDADBE oCUNIDAD, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;





                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCUNIDAD.isnull["IACTIVO"])
                {
                    auxPar.Value = oCUNIDAD.IACTIVO;
                }
                else
                {
                    auxPar.Value = "S";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCUNIDAD.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCUNIDAD.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCUNIDAD.isnull["ICLAVE"])
                {
                    auxPar.Value = oCUNIDAD.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCUNIDAD.isnull["INOMBRE"])
                {
                    auxPar.Value = oCUNIDAD.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADDECIMALES", FbDbType.Numeric);
                if (!(bool)oCUNIDAD.isnull["ICANTIDADDECIMALES"])
                {
                    auxPar.Value = oCUNIDAD.ICANTIDADDECIMALES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_UNIDADMEDIDAID", FbDbType.BigInt);
                if (!(bool)oCUNIDAD.isnull["ISAT_UNIDADMEDIDAID"])
                {
                    auxPar.Value = oCUNIDAD.ISAT_UNIDADMEDIDAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO UNIDAD
      (

ACTIVO,

CREADOPOR_USERID,

CLAVE,

NOMBRE,

CANTIDADDECIMALES,

SAT_UNIDADMEDIDAID
         )

Values (


@ACTIVO,

@CREADOPOR_USERID,

@CLAVE,

@NOMBRE,

@CANTIDADDECIMALES, 

@SAT_UNIDADMEDIDAID
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCUNIDAD;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarUNIDADD(CUNIDADBE oCUNIDAD, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCUNIDAD.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from UNIDAD
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
        public bool CambiarUNIDADD(CUNIDADBE oCUNIDADNuevo, CUNIDADBE oCUNIDADAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCUNIDADNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCUNIDADNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCUNIDADNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCUNIDADNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCUNIDADNuevo.isnull["ICLAVE"])
                {
                    auxPar.Value = oCUNIDADNuevo.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCUNIDADNuevo.isnull["INOMBRE"])
                {
                    auxPar.Value = oCUNIDADNuevo.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADDECIMALES", FbDbType.Numeric);
                if (!(bool)oCUNIDADNuevo.isnull["ICANTIDADDECIMALES"])
                {
                    auxPar.Value = oCUNIDADNuevo.ICANTIDADDECIMALES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_UNIDADMEDIDAID", FbDbType.BigInt);
                if (!(bool)oCUNIDADNuevo.isnull["ISAT_UNIDADMEDIDAID"])
                {
                    auxPar.Value = oCUNIDADNuevo.ISAT_UNIDADMEDIDAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCUNIDADAnterior.isnull["IID"])
                {
                    auxPar.Value = oCUNIDADAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  UNIDAD
  set

ACTIVO=@ACTIVO,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

CLAVE=@CLAVE,

NOMBRE = @NOMBRE,

CANTIDADDECIMALES = @CANTIDADDECIMALES, 

SAT_UNIDADMEDIDAID = @SAT_UNIDADMEDIDAID

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
        public CUNIDADBE seleccionarUNIDAD(CUNIDADBE oCUNIDAD, FbTransaction st)
        {




            CUNIDADBE retorno = new CUNIDADBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from UNIDAD where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCUNIDAD.IID;
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

                    if (dr["CANTIDADDECIMALES"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDADDECIMALES = (short)(dr["CANTIDADDECIMALES"]);
                    }

                    if (dr["SAT_UNIDADMEDIDAID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_UNIDADMEDIDAID = (long)(dr["SAT_UNIDADMEDIDAID"]);
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
        public CUNIDADBE seleccionarUNIDADxCLAVE(CUNIDADBE oCUNIDAD, FbTransaction st)
        {




            CUNIDADBE retorno = new CUNIDADBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from UNIDAD where
 CLAVE=@CLAVE  ";


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                auxPar.Value = oCUNIDAD.ICLAVE;
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

                    if (dr["CANTIDADDECIMALES"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDADDECIMALES = (short)(dr["CANTIDADDECIMALES"]);
                    }

                    if (dr["SAT_UNIDADMEDIDAID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_UNIDADMEDIDAID = (long)(dr["SAT_UNIDADMEDIDAID"]);
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
        public DataSet enlistarUNIDAD()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_UNIDAD_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoUNIDAD()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_UNIDAD_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteUNIDAD(CUNIDADBE oCUNIDAD, FbTransaction st)
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
                auxPar.Value = oCUNIDAD.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from UNIDAD where

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




        public CUNIDADBE AgregarUNIDAD(CUNIDADBE oCUNIDAD, FbTransaction st)
        {
            try
            {
                int iRes = ExisteUNIDAD(oCUNIDAD, st);
                if (iRes == 1)
                {
                    this.IComentario = "El UNIDAD ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarUNIDADD(oCUNIDAD, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarUNIDAD(CUNIDADBE oCUNIDAD, FbTransaction st)
        {
            try
            {
                int iRes = ExisteUNIDAD(oCUNIDAD, st);
                if (iRes == 0)
                {
                    this.IComentario = "El UNIDAD no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarUNIDADD(oCUNIDAD, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarUNIDAD(CUNIDADBE oCUNIDADNuevo, CUNIDADBE oCUNIDADAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteUNIDAD(oCUNIDADAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El UNIDAD no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarUNIDADD(oCUNIDADNuevo, oCUNIDADAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public static short numerDecimalesPorClaveUnidad(string clave)
        {
            short numeroDecimales = 2;

            if (clave != null)
            {

                CUNIDADD unidadD = new CUNIDADD();
                CUNIDADBE unidadBE = new CUNIDADBE();
                unidadBE.ICLAVE = clave;
                unidadBE = unidadD.seleccionarUNIDADxCLAVE(unidadBE, null);

                if (unidadBE != null && !(bool)unidadBE.isnull["ICANTIDADDECIMALES"])
                {
                    numeroDecimales = unidadBE.ICANTIDADDECIMALES;
                }
            }

            return numeroDecimales;
        }




        public CUNIDADD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
