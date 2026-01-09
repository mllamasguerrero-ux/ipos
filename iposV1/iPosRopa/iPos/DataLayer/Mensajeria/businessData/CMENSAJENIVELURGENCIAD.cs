

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

    


    public class CMENSAJENIVELURGENCIAD
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


        
        public CMENSAJENIVELURGENCIABE AgregarMENSAJENIVELURGENCIAD(CMENSAJENIVELURGENCIABE oCMENSAJENIVELURGENCIA, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;





                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCMENSAJENIVELURGENCIA.isnull["IACTIVO"])
                {
                    auxPar.Value = oCMENSAJENIVELURGENCIA.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMENSAJENIVELURGENCIA.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCMENSAJENIVELURGENCIA.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMENSAJENIVELURGENCIA.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCMENSAJENIVELURGENCIA.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCMENSAJENIVELURGENCIA.isnull["ICLAVE"])
                {
                    auxPar.Value = oCMENSAJENIVELURGENCIA.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCMENSAJENIVELURGENCIA.isnull["INOMBRE"])
                {
                    auxPar.Value = oCMENSAJENIVELURGENCIA.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO MENSAJENIVELURGENCIA
      (
    

ACTIVO,


CREADOPOR_USERID,


MODIFICADOPOR_USERID,

CLAVE,

NOMBRE
         )

Values (


@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@CLAVE,

@NOMBRE
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCMENSAJENIVELURGENCIA;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        
        public bool BorrarMENSAJENIVELURGENCIAD(CMENSAJENIVELURGENCIABE oCMENSAJENIVELURGENCIA, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMENSAJENIVELURGENCIA.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from MENSAJENIVELURGENCIA
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


        
        public bool CambiarMENSAJENIVELURGENCIAD(CMENSAJENIVELURGENCIABE oCMENSAJENIVELURGENCIANuevo, CMENSAJENIVELURGENCIABE oCMENSAJENIVELURGENCIAAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCMENSAJENIVELURGENCIANuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCMENSAJENIVELURGENCIANuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMENSAJENIVELURGENCIANuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCMENSAJENIVELURGENCIANuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMENSAJENIVELURGENCIANuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCMENSAJENIVELURGENCIANuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCMENSAJENIVELURGENCIANuevo.isnull["ICLAVE"])
                {
                    auxPar.Value = oCMENSAJENIVELURGENCIANuevo.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCMENSAJENIVELURGENCIANuevo.isnull["INOMBRE"])
                {
                    auxPar.Value = oCMENSAJENIVELURGENCIANuevo.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCMENSAJENIVELURGENCIAAnterior.isnull["IID"])
                {
                    auxPar.Value = oCMENSAJENIVELURGENCIAAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  MENSAJENIVELURGENCIA
  set

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

CLAVE=@CLAVE,

NOMBRE=@NOMBRE
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


        
        public CMENSAJENIVELURGENCIABE seleccionarMENSAJENIVELURGENCIA(CMENSAJENIVELURGENCIABE oCMENSAJENIVELURGENCIA, FbTransaction st)
        {




            CMENSAJENIVELURGENCIABE retorno = new CMENSAJENIVELURGENCIABE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from MENSAJENIVELURGENCIA where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMENSAJENIVELURGENCIA.IID;
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









        
        public DataSet enlistarMENSAJENIVELURGENCIA()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_MENSAJENIVELURGENCIA_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        
        public DataSet enlistarCortoMENSAJENIVELURGENCIA()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_MENSAJENIVELURGENCIA_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        
        public int ExisteMENSAJENIVELURGENCIA(CMENSAJENIVELURGENCIABE oCMENSAJENIVELURGENCIA, FbTransaction st)
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
                auxPar.Value = oCMENSAJENIVELURGENCIA.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from MENSAJENIVELURGENCIA where

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




        public CMENSAJENIVELURGENCIABE AgregarMENSAJENIVELURGENCIA(CMENSAJENIVELURGENCIABE oCMENSAJENIVELURGENCIA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMENSAJENIVELURGENCIA(oCMENSAJENIVELURGENCIA, st);
                if (iRes == 1)
                {
                    this.IComentario = "El MENSAJENIVELURGENCIA ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarMENSAJENIVELURGENCIAD(oCMENSAJENIVELURGENCIA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarMENSAJENIVELURGENCIA(CMENSAJENIVELURGENCIABE oCMENSAJENIVELURGENCIA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMENSAJENIVELURGENCIA(oCMENSAJENIVELURGENCIA, st);
                if (iRes == 0)
                {
                    this.IComentario = "El MENSAJENIVELURGENCIA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarMENSAJENIVELURGENCIAD(oCMENSAJENIVELURGENCIA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarMENSAJENIVELURGENCIA(CMENSAJENIVELURGENCIABE oCMENSAJENIVELURGENCIANuevo, CMENSAJENIVELURGENCIABE oCMENSAJENIVELURGENCIAAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMENSAJENIVELURGENCIA(oCMENSAJENIVELURGENCIAAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El MENSAJENIVELURGENCIA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarMENSAJENIVELURGENCIAD(oCMENSAJENIVELURGENCIANuevo, oCMENSAJENIVELURGENCIAAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CMENSAJENIVELURGENCIAD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
