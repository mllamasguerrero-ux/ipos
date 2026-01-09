
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



    public class CCARRIERD
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


        public CCARRIERBE AgregarCARRIERD(CCARRIERBE oCCARRIER, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;





                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCCARRIER.isnull["IACTIVO"])
                {
                    auxPar.Value = oCCARRIER.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCCARRIER.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCCARRIER.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCCARRIER.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCCARRIER.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CARRIERID", FbDbType.VarChar);
                if (!(bool)oCCARRIER.isnull["ICARRIERID"])
                {
                    auxPar.Value = oCCARRIER.ICARRIERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPTION", FbDbType.VarChar);
                if (!(bool)oCCARRIER.isnull["IDESCRIPTION"])
                {
                    auxPar.Value = oCCARRIER.IDESCRIPTION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTCOUNT", FbDbType.VarChar);
                if (!(bool)oCCARRIER.isnull["IPRODUCTCOUNT"])
                {
                    auxPar.Value = oCCARRIER.IPRODUCTCOUNT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@ESSERVICIO", FbDbType.VarChar);
                if (!(bool)oCCARRIER.isnull["IESSERVICIO"])
                {
                    auxPar.Value = oCCARRIER.IESSERVICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
        INSERT INTO CARRIER
      (
    

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

CARRIERID,

DESCRIPTION,

PRODUCTCOUNT,

ESSERVICIO
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@CARRIERID,

@DESCRIPTION,

@PRODUCTCOUNT,

@ESSERVICIO
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCCARRIER;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarCARRIERD(CCARRIERBE oCCARRIER, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCCARRIER.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from CARRIER
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



        public bool DesactivarTodosCARRIERD(string esservicio, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;






                string commandText = @" update CARRIER SET ACTIVO = 'N' WHERE ESSERVICIO = @ESSERVICIO OR (ESSERVICIO IS NULL AND @ESSERVICIO = 'N');";


                auxPar = new FbParameter("@ESSERVICIO", FbDbType.VarChar);
                auxPar.Value = esservicio;
                parts.Add(auxPar);

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
        public bool CambiarCARRIERD(CCARRIERBE oCCARRIERNuevo, CCARRIERBE oCCARRIERAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCCARRIERNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCCARRIERNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCCARRIERNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCCARRIERNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CARRIERID", FbDbType.VarChar);
                if (!(bool)oCCARRIERNuevo.isnull["ICARRIERID"])
                {
                    auxPar.Value = oCCARRIERNuevo.ICARRIERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCRIPTION", FbDbType.VarChar);
                if (!(bool)oCCARRIERNuevo.isnull["IDESCRIPTION"])
                {
                    auxPar.Value = oCCARRIERNuevo.IDESCRIPTION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRODUCTCOUNT", FbDbType.VarChar);
                if (!(bool)oCCARRIERNuevo.isnull["IPRODUCTCOUNT"])
                {
                    auxPar.Value = oCCARRIERNuevo.IPRODUCTCOUNT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@ESSERVICIO", FbDbType.VarChar);
                if (!(bool)oCCARRIERNuevo.isnull["IESSERVICIO"])
                {
                    auxPar.Value = oCCARRIERNuevo.IESSERVICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCCARRIERAnterior.isnull["IID"])
                {
                    auxPar.Value = oCCARRIERAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  CARRIER
  set


ACTIVO=@ACTIVO,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

CARRIERID=@CARRIERID,

DESCRIPTION=@DESCRIPTION,

PRODUCTCOUNT=@PRODUCTCOUNT,

ESSERVICIO = @ESSERVICIO

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
        public CCARRIERBE seleccionarCARRIER(CCARRIERBE oCCARRIER, FbTransaction st)
        {




            CCARRIERBE retorno = new CCARRIERBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from CARRIER where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCCARRIER.IID;
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

                    if (dr["CARRIERID"] != System.DBNull.Value)
                    {
                        retorno.ICARRIERID = (string)(dr["CARRIERID"]);
                    }

                    if (dr["DESCRIPTION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPTION = (string)(dr["DESCRIPTION"]);
                    }

                    if (dr["PRODUCTCOUNT"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTCOUNT = (string)(dr["PRODUCTCOUNT"]);
                    }


                    if (dr["ESSERVICIO"] != System.DBNull.Value)
                    {
                        retorno.IESSERVICIO = (string)(dr["ESSERVICIO"]);
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




        public CCARRIERBE seleccionarCARRIERxCARRIERID(CCARRIERBE oCCARRIER, FbTransaction st)
        {




            CCARRIERBE retorno = new CCARRIERBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from CARRIER where CARRIERID = @CARRIERID AND (ESSERVICIO = @ESSERVICIO OR (ESSERVICIO IS NULL AND @ESSERVICIO = 'N')) ";


                auxPar = new FbParameter("@CARRIERID", FbDbType.VarChar);
                auxPar.Value = oCCARRIER.ICARRIERID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESSERVICIO", FbDbType.VarChar);
                auxPar.Value = oCCARRIER.IESSERVICIO;
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

                    if (dr["CARRIERID"] != System.DBNull.Value)
                    {
                        retorno.ICARRIERID = (string)(dr["CARRIERID"]);
                    }

                    if (dr["DESCRIPTION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPTION = (string)(dr["DESCRIPTION"]);
                    }

                    if (dr["PRODUCTCOUNT"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTCOUNT = (string)(dr["PRODUCTCOUNT"]);
                    }

                    if (dr["ESSERVICIO"] != System.DBNull.Value)
                    {
                        retorno.IESSERVICIO = (string)(dr["ESSERVICIO"]);
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
        public DataSet enlistarCARRIER()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_CARRIER_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoCARRIER()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_CARRIER_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteCARRIER(CCARRIERBE oCCARRIER, FbTransaction st)
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
                auxPar.Value = oCCARRIER.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from CARRIER where

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




        public CCARRIERBE AgregarCARRIER(CCARRIERBE oCCARRIER, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCARRIER(oCCARRIER, st);
                if (iRes == 1)
                {
                    this.IComentario = "El CARRIER ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarCARRIERD(oCCARRIER, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarCARRIER(CCARRIERBE oCCARRIER, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCARRIER(oCCARRIER, st);
                if (iRes == 0)
                {
                    this.IComentario = "El CARRIER no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarCARRIERD(oCCARRIER, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarCARRIER(CCARRIERBE oCCARRIERNuevo, CCARRIERBE oCCARRIERAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCARRIER(oCCARRIERAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El CARRIER no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarCARRIERD(oCCARRIERNuevo, oCCARRIERAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CCARRIERD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
