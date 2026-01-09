

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


    public class CMARCAD
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
        public CMARCABE AgregarMARCAD(CMARCABE oCMARCA, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCMARCA.isnull["ICLAVE"])
                {
                    auxPar.Value = oCMARCA.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCMARCA.isnull["INOMBRE"])
                {
                    auxPar.Value = oCMARCA.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@ACTIVO", FbDbType.VarChar);
                if (!(bool)oCMARCA.isnull["IACTIVO"])
                {
                    auxPar.Value = oCMARCA.IACTIVO;
                }
                else
                {
                    auxPar.Value = "S";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCONTINUADO", FbDbType.VarChar);
                if (!(bool)oCMARCA.isnull["IDESCONTINUADO"])
                {
                    auxPar.Value = oCMARCA.IDESCONTINUADO;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO MARCA
      (


CLAVE,

NOMBRE,

ACTIVO,

DESCONTINUADO
         )

Values (


@CLAVE,

@NOMBRE,

@ACTIVO,

@DESCONTINUADO
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCMARCA;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarMARCAD(CMARCABE oCMARCA, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMARCA.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from MARCA
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
        public bool CambiarMARCAD(CMARCABE oCMARCANuevo, CMARCABE oCMARCAAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCMARCANuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCMARCANuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMARCANuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCMARCANuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCMARCANuevo.isnull["ICLAVE"])
                {
                    auxPar.Value = oCMARCANuevo.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCMARCANuevo.isnull["INOMBRE"])
                {
                    auxPar.Value = oCMARCANuevo.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@DESCONTINUADO", FbDbType.Char);
                if (!(bool)oCMARCANuevo.isnull["IDESCONTINUADO"])
                {
                    auxPar.Value = oCMARCANuevo.IDESCONTINUADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCMARCAAnterior.isnull["IID"])
                {
                    auxPar.Value = oCMARCAAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  MARCA
  set

ACTIVO=@ACTIVO,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

CLAVE=@CLAVE,

NOMBRE=@NOMBRE,

DESCONTINUADO = @DESCONTINUADO
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
        public CMARCABE seleccionarMARCA(CMARCABE oCMARCA, FbTransaction st)
        {
            CMARCABE retorno = new CMARCABE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from MARCA where ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMARCA.IID;
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

                    if (dr["DESCONTINUADO"] != System.DBNull.Value)
                    {
                        retorno.IDESCONTINUADO = (string)(dr["DESCONTINUADO"]);
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





        public CMARCABE seleccionarMARCAXCLAVE(CMARCABE oCMARCA, FbTransaction st)
        {
            CMARCABE retorno = new CMARCABE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from MARCA where CLAVE=@CLAVE  ";


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                auxPar.Value = oCMARCA.ICLAVE;
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

                    if (dr["DESCONTINUADO"] != System.DBNull.Value)
                    {
                        retorno.IDESCONTINUADO = (string)(dr["DESCONTINUADO"]);
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
        public DataSet enlistarMARCA()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_MARCA_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoMARCA()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_MARCA_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteMARCA(CMARCABE oCMARCA, FbTransaction st)
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
                auxPar.Value = oCMARCA.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from MARCA where

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




        public CMARCABE AgregarMARCA(CMARCABE oCMARCA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMARCA(oCMARCA, st);
                if (iRes == 1)
                {
                    this.IComentario = "El MARCA ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarMARCAD(oCMARCA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarMARCA(CMARCABE oCMARCA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMARCA(oCMARCA, st);
                if (iRes == 0)
                {
                    this.IComentario = "El MARCA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarMARCAD(oCMARCA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarMARCA(CMARCABE oCMARCANuevo, CMARCABE oCMARCAAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMARCA(oCMARCAAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El MARCA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarMARCAD(oCMARCANuevo, oCMARCAAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CMARCAD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
