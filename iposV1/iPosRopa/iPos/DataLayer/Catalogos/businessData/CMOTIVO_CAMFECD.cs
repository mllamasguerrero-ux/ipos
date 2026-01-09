

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



    public class CMOTIVO_CAMFECD
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


        public CMOTIVO_CAMFECBE AgregarMOTIVO_CAMFECD(CMOTIVO_CAMFECBE oCMOTIVO_CAMFEC, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCMOTIVO_CAMFEC.isnull["IACTIVO"])
                {
                    auxPar.Value = oCMOTIVO_CAMFEC.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMOTIVO_CAMFEC.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCMOTIVO_CAMFEC.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMOTIVO_CAMFEC.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCMOTIVO_CAMFEC.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCMOTIVO_CAMFEC.isnull["ICLAVE"])
                {
                    auxPar.Value = oCMOTIVO_CAMFEC.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCMOTIVO_CAMFEC.isnull["IDESCRIPCION"])
                {
                    auxPar.Value = oCMOTIVO_CAMFEC.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO MOTIVO_CAMFEC
      (
    
ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

CLAVE,

DESCRIPCION
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@CLAVE,

@DESCRIPCION
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCMOTIVO_CAMFEC;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarMOTIVO_CAMFECD(CMOTIVO_CAMFECBE oCMOTIVO_CAMFEC, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMOTIVO_CAMFEC.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from MOTIVO_CAMFEC
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


        public bool CambiarMOTIVO_CAMFECD(CMOTIVO_CAMFECBE oCMOTIVO_CAMFECNuevo, CMOTIVO_CAMFECBE oCMOTIVO_CAMFECAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCMOTIVO_CAMFECNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCMOTIVO_CAMFECNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMOTIVO_CAMFECNuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCMOTIVO_CAMFECNuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMOTIVO_CAMFECNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCMOTIVO_CAMFECNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCMOTIVO_CAMFECNuevo.isnull["ICLAVE"])
                {
                    auxPar.Value = oCMOTIVO_CAMFECNuevo.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCMOTIVO_CAMFECNuevo.isnull["IDESCRIPCION"])
                {
                    auxPar.Value = oCMOTIVO_CAMFECNuevo.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCMOTIVO_CAMFECAnterior.isnull["IID"])
                {
                    auxPar.Value = oCMOTIVO_CAMFECAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  MOTIVO_CAMFEC
  set

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

CLAVE=@CLAVE,

DESCRIPCION=@DESCRIPCION
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


        public CMOTIVO_CAMFECBE seleccionarMOTIVO_CAMFEC(CMOTIVO_CAMFECBE oCMOTIVO_CAMFEC, FbTransaction st)
        {




            CMOTIVO_CAMFECBE retorno = new CMOTIVO_CAMFECBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from MOTIVO_CAMFEC where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMOTIVO_CAMFEC.IID;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {
                   retorno  =  ParseDataFromDb(ref dr);

                    
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



        public CMOTIVO_CAMFECBE seleccionarMOTIVO_CAMFEC_x_CLAVE(CMOTIVO_CAMFECBE oCMOTIVO_CAMFEC, FbTransaction st)
        {




            CMOTIVO_CAMFECBE retorno = new CMOTIVO_CAMFECBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from MOTIVO_CAMFEC where CLAVE = @CLAVE  ";


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                auxPar.Value = oCMOTIVO_CAMFEC.ICLAVE;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {
                    retorno = ParseDataFromDb(ref dr);


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


        public CMOTIVO_CAMFECBE ParseDataFromDb(ref FbDataReader dr)
        {
            CMOTIVO_CAMFECBE retorno = new CMOTIVO_CAMFECBE();

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

            if (dr["DESCRIPCION"] != System.DBNull.Value)
            {
                retorno.IDESCRIPCION = (string)(dr["DESCRIPCION"]);
            }

            return retorno;
        }





            public DataSet enlistarMOTIVO_CAMFEC()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_MOTIVO_CAMFEC_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public DataSet enlistarCortoMOTIVO_CAMFEC()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_MOTIVO_CAMFEC_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public int ExisteMOTIVO_CAMFEC(CMOTIVO_CAMFECBE oCMOTIVO_CAMFEC, FbTransaction st)
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
                auxPar.Value = oCMOTIVO_CAMFEC.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from MOTIVO_CAMFEC where

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




        public CMOTIVO_CAMFECBE AgregarMOTIVO_CAMFEC(CMOTIVO_CAMFECBE oCMOTIVO_CAMFEC, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMOTIVO_CAMFEC(oCMOTIVO_CAMFEC, st);
                if (iRes == 1)
                {
                    this.IComentario = "El MOTIVO_CAMFEC ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarMOTIVO_CAMFECD(oCMOTIVO_CAMFEC, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarMOTIVO_CAMFEC(CMOTIVO_CAMFECBE oCMOTIVO_CAMFEC, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMOTIVO_CAMFEC(oCMOTIVO_CAMFEC, st);
                if (iRes == 0)
                {
                    this.IComentario = "El MOTIVO_CAMFEC no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarMOTIVO_CAMFECD(oCMOTIVO_CAMFEC, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarMOTIVO_CAMFEC(CMOTIVO_CAMFECBE oCMOTIVO_CAMFECNuevo, CMOTIVO_CAMFECBE oCMOTIVO_CAMFECAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMOTIVO_CAMFEC(oCMOTIVO_CAMFECAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El MOTIVO_CAMFEC no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarMOTIVO_CAMFECD(oCMOTIVO_CAMFECNuevo, oCMOTIVO_CAMFECAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CMOTIVO_CAMFECD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
