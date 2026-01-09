

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



    public class CCUENTABANCOD
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


        public CCUENTABANCOBE AgregarCUENTABANCOD(CCUENTABANCOBE oCCUENTABANCO, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCCUENTABANCO.isnull["IACTIVO"])
                {
                    auxPar.Value = oCCUENTABANCO.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCCUENTABANCO.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCCUENTABANCO.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCCUENTABANCO.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCCUENTABANCO.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@BANCOID", FbDbType.BigInt);
                if (!(bool)oCCUENTABANCO.isnull["IBANCOID"])
                {
                    auxPar.Value = oCCUENTABANCO.IBANCOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCCUENTABANCO.isnull["INOMBRE"])
                {
                    auxPar.Value = oCCUENTABANCO.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RFC", FbDbType.VarChar);
                if (!(bool)oCCUENTABANCO.isnull["IRFC"])
                {
                    auxPar.Value = oCCUENTABANCO.IRFC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOCUENTA", FbDbType.VarChar);
                if (!(bool)oCCUENTABANCO.isnull["INOCUENTA"])
                {
                    auxPar.Value = oCCUENTABANCO.INOCUENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PREDETERMINADA", FbDbType.VarChar);
                if (!(bool)oCCUENTABANCO.isnull["IPREDETERMINADA"])
                {
                    auxPar.Value = oCCUENTABANCO.IPREDETERMINADA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                string commandText = @"
        INSERT INTO CUENTABANCO
      (
    
ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

BANCOID,

NOMBRE,

RFC,

NOCUENTA,

PREDETERMINADA
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@BANCOID,

@NOMBRE,

@RFC,

@NOCUENTA,

@PREDETERMINADA
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCCUENTABANCO;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarCUENTABANCOD(CCUENTABANCOBE oCCUENTABANCO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCCUENTABANCO.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from CUENTABANCO
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


        public bool CambiarCUENTABANCOD(CCUENTABANCOBE oCCUENTABANCONuevo, CCUENTABANCOBE oCCUENTABANCOAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCCUENTABANCONuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCCUENTABANCONuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCCUENTABANCONuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCCUENTABANCONuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCCUENTABANCONuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCCUENTABANCONuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@BANCOID", FbDbType.BigInt);
                if (!(bool)oCCUENTABANCONuevo.isnull["IBANCOID"])
                {
                    auxPar.Value = oCCUENTABANCONuevo.IBANCOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCCUENTABANCONuevo.isnull["INOMBRE"])
                {
                    auxPar.Value = oCCUENTABANCONuevo.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@RFC", FbDbType.VarChar);
                if (!(bool)oCCUENTABANCONuevo.isnull["IRFC"])
                {
                    auxPar.Value = oCCUENTABANCONuevo.IRFC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOCUENTA", FbDbType.VarChar);
                if (!(bool)oCCUENTABANCONuevo.isnull["INOCUENTA"])
                {
                    auxPar.Value = oCCUENTABANCONuevo.INOCUENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PREDETERMINADA", FbDbType.VarChar);
                if (!(bool)oCCUENTABANCONuevo.isnull["IPREDETERMINADA"])
                {
                    auxPar.Value = oCCUENTABANCONuevo.IPREDETERMINADA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCCUENTABANCOAnterior.isnull["IID"])
                {
                    auxPar.Value = oCCUENTABANCOAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  CUENTABANCO
  set

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

BANCOID=@BANCOID,

NOMBRE=@NOMBRE,

RFC=@RFC,

NOCUENTA=@NOCUENTA,

PREDETERMINADA = @PREDETERMINADA
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


        public CCUENTABANCOBE seleccionarCUENTABANCO(CCUENTABANCOBE oCCUENTABANCO, FbTransaction st)
        {




            CCUENTABANCOBE retorno = new CCUENTABANCOBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from CUENTABANCO where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCCUENTABANCO.IID;
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

                    if (dr["BANCOID"] != System.DBNull.Value)
                    {
                        retorno.IBANCOID = (long)(dr["BANCOID"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (dr["RFC"] != System.DBNull.Value)
                    {
                        retorno.IRFC = (string)(dr["RFC"]);
                    }

                    if (dr["NOCUENTA"] != System.DBNull.Value)
                    {
                        retorno.INOCUENTA = (string)(dr["NOCUENTA"]);
                    }

                    if (dr["PREDETERMINADA"] != System.DBNull.Value)
                    {
                        retorno.IPREDETERMINADA = (string)(dr["PREDETERMINADA"]);
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









        public DataSet enlistarCUENTABANCO()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_CUENTABANCO_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public DataSet enlistarCortoCUENTABANCO()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_CUENTABANCO_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public int ExisteCUENTABANCO(CCUENTABANCOBE oCCUENTABANCO, FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCCUENTABANCO.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from CUENTABANCO where

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




        public CCUENTABANCOBE AgregarCUENTABANCO(CCUENTABANCOBE oCCUENTABANCO, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCUENTABANCO(oCCUENTABANCO, st);
                if (iRes == 1)
                {
                    this.IComentario = "El CUENTABANCO ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarCUENTABANCOD(oCCUENTABANCO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarCUENTABANCO(CCUENTABANCOBE oCCUENTABANCO, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCUENTABANCO(oCCUENTABANCO, st);
                if (iRes == 0)
                {
                    this.IComentario = "El CUENTABANCO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarCUENTABANCOD(oCCUENTABANCO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarCUENTABANCO(CCUENTABANCOBE oCCUENTABANCONuevo, CCUENTABANCOBE oCCUENTABANCOAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCUENTABANCO(oCCUENTABANCOAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El CUENTABANCO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarCUENTABANCOD(oCCUENTABANCONuevo, oCCUENTABANCOAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CCUENTABANCOD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
