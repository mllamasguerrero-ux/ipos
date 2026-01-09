

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



    public class CPERSONACUENTABANCOD
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


        public CPERSONACUENTABANCOBE AgregarPERSONACUENTABANCOD(CPERSONACUENTABANCOBE oCPERSONACUENTABANCO, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCPERSONACUENTABANCO.isnull["IACTIVO"])
                {
                    auxPar.Value = oCPERSONACUENTABANCO.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPERSONACUENTABANCO.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCPERSONACUENTABANCO.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPERSONACUENTABANCO.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCPERSONACUENTABANCO.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@BANCOID", FbDbType.BigInt);
                if (!(bool)oCPERSONACUENTABANCO.isnull["IBANCOID"])
                {
                    auxPar.Value = oCPERSONACUENTABANCO.IBANCOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOCUENTA", FbDbType.VarChar);
                if (!(bool)oCPERSONACUENTABANCO.isnull["INOCUENTA"])
                {
                    auxPar.Value = oCPERSONACUENTABANCO.INOCUENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (!(bool)oCPERSONACUENTABANCO.isnull["IPERSONAID"])
                {
                    auxPar.Value = oCPERSONACUENTABANCO.IPERSONAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO PERSONACUENTABANCO
      (
    
ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

BANCOID,

NOCUENTA,

PERSONAID
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@BANCOID,

@NOCUENTA,

@PERSONAID
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCPERSONACUENTABANCO;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarPERSONACUENTABANCOD(CPERSONACUENTABANCOBE oCPERSONACUENTABANCO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPERSONACUENTABANCO.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from PERSONACUENTABANCO
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


        public bool CambiarPERSONACUENTABANCOD(CPERSONACUENTABANCOBE oCPERSONACUENTABANCONuevo, CPERSONACUENTABANCOBE oCPERSONACUENTABANCOAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCPERSONACUENTABANCONuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCPERSONACUENTABANCONuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPERSONACUENTABANCONuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCPERSONACUENTABANCONuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPERSONACUENTABANCONuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCPERSONACUENTABANCONuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@BANCOID", FbDbType.BigInt);
                if (!(bool)oCPERSONACUENTABANCONuevo.isnull["IBANCOID"])
                {
                    auxPar.Value = oCPERSONACUENTABANCONuevo.IBANCOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOCUENTA", FbDbType.VarChar);
                if (!(bool)oCPERSONACUENTABANCONuevo.isnull["INOCUENTA"])
                {
                    auxPar.Value = oCPERSONACUENTABANCONuevo.INOCUENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (!(bool)oCPERSONACUENTABANCONuevo.isnull["IPERSONAID"])
                {
                    auxPar.Value = oCPERSONACUENTABANCONuevo.IPERSONAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCPERSONACUENTABANCOAnterior.isnull["IID"])
                {
                    auxPar.Value = oCPERSONACUENTABANCOAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  PERSONACUENTABANCO
  set

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

BANCOID=@BANCOID,

NOCUENTA=@NOCUENTA,

PERSONAID=@PERSONAID
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


        public CPERSONACUENTABANCOBE seleccionarPERSONACUENTABANCO(CPERSONACUENTABANCOBE oCPERSONACUENTABANCO, FbTransaction st)
        {




            CPERSONACUENTABANCOBE retorno = new CPERSONACUENTABANCOBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from PERSONACUENTABANCO where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPERSONACUENTABANCO.IID;
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

                    if (dr["NOCUENTA"] != System.DBNull.Value)
                    {
                        retorno.INOCUENTA = (string)(dr["NOCUENTA"]);
                    }

                    if (dr["PERSONAID"] != System.DBNull.Value)
                    {
                        retorno.IPERSONAID = (long)(dr["PERSONAID"]);
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







        public int CantidadCuentasCliente(long personaId, FbTransaction st)
        {




            int retorno = 0;
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select COUNT(*) CUENTA from PERSONACUENTABANCO where PERSONAID = @PERSONAID  ";


                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                auxPar.Value = personaId;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["CUENTA"] != System.DBNull.Value)
                    {
                        retorno = (int)(dr["CUENTA"]);
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




        public DataSet enlistarPERSONACUENTABANCO()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_PERSONACUENTABANCO_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public DataSet enlistarCortoPERSONACUENTABANCO()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_PERSONACUENTABANCO_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public int ExistePERSONACUENTABANCO(CPERSONACUENTABANCOBE oCPERSONACUENTABANCO, FbTransaction st)
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
                auxPar.Value = oCPERSONACUENTABANCO.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from PERSONACUENTABANCO where

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




        public CPERSONACUENTABANCOBE AgregarPERSONACUENTABANCO(CPERSONACUENTABANCOBE oCPERSONACUENTABANCO, FbTransaction st)
        {
            try
            {
                int iRes = ExistePERSONACUENTABANCO(oCPERSONACUENTABANCO, st);
                if (iRes == 1)
                {
                    this.IComentario = "El PERSONACUENTABANCO ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarPERSONACUENTABANCOD(oCPERSONACUENTABANCO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarPERSONACUENTABANCO(CPERSONACUENTABANCOBE oCPERSONACUENTABANCO, FbTransaction st)
        {
            try
            {
                int iRes = ExistePERSONACUENTABANCO(oCPERSONACUENTABANCO, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PERSONACUENTABANCO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarPERSONACUENTABANCOD(oCPERSONACUENTABANCO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarPERSONACUENTABANCO(CPERSONACUENTABANCOBE oCPERSONACUENTABANCONuevo, CPERSONACUENTABANCOBE oCPERSONACUENTABANCOAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExistePERSONACUENTABANCO(oCPERSONACUENTABANCOAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PERSONACUENTABANCO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarPERSONACUENTABANCOD(oCPERSONACUENTABANCONuevo, oCPERSONACUENTABANCOAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CPERSONACUENTABANCOD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
