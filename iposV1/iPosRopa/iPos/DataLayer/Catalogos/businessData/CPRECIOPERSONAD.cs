

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



    public class CPRECIOPERSONAD
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


        public CPRECIOPERSONABE AgregarPRECIOPERSONAD(CPRECIOPERSONABE oCPRECIOPERSONA, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCPRECIOPERSONA.isnull["IACTIVO"])
                {
                    auxPar.Value = oCPRECIOPERSONA.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPRECIOPERSONA.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCPRECIOPERSONA.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPRECIOPERSONA.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCPRECIOPERSONA.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (!(bool)oCPRECIOPERSONA.isnull["IPERSONAID"])
                {
                    auxPar.Value = oCPRECIOPERSONA.IPERSONAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                if (!(bool)oCPRECIOPERSONA.isnull["IPRODUCTOID"])
                {
                    auxPar.Value = oCPRECIOPERSONA.IPRODUCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO", FbDbType.Numeric);
                if (!(bool)oCPRECIOPERSONA.isnull["IPRECIO"])
                {
                    auxPar.Value = oCPRECIOPERSONA.IPRECIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO PRECIOPERSONA
      (
    

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

PERSONAID,

PRODUCTOID,

PRECIO
         )

Values (


@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@PERSONAID,

@PRODUCTOID,

@PRECIO
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCPRECIOPERSONA;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        
        public bool BorrarPRECIOPERSONAD(CPRECIOPERSONABE oCPRECIOPERSONA, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPRECIOPERSONA.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from PRECIOPERSONA
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


        
        public bool CambiarPRECIOPERSONAD(CPRECIOPERSONABE oCPRECIOPERSONANuevo, CPRECIOPERSONABE oCPRECIOPERSONAAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCPRECIOPERSONANuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCPRECIOPERSONANuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPRECIOPERSONANuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCPRECIOPERSONANuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (!(bool)oCPRECIOPERSONANuevo.isnull["IPERSONAID"])
                {
                    auxPar.Value = oCPRECIOPERSONANuevo.IPERSONAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                if (!(bool)oCPRECIOPERSONANuevo.isnull["IPRODUCTOID"])
                {
                    auxPar.Value = oCPRECIOPERSONANuevo.IPRODUCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRECIO", FbDbType.Numeric);
                if (!(bool)oCPRECIOPERSONANuevo.isnull["IPRECIO"])
                {
                    auxPar.Value = oCPRECIOPERSONANuevo.IPRECIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCPRECIOPERSONAAnterior.isnull["IID"])
                {
                    auxPar.Value = oCPRECIOPERSONAAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  PRECIOPERSONA
  set


ACTIVO=@ACTIVO,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

PERSONAID=@PERSONAID,

PRODUCTOID=@PRODUCTOID,

PRECIO=@PRECIO
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


        
        public CPRECIOPERSONABE seleccionarPRECIOPERSONA(CPRECIOPERSONABE oCPRECIOPERSONA, FbTransaction st)
        {




            CPRECIOPERSONABE retorno = new CPRECIOPERSONABE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from PRECIOPERSONA where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPRECIOPERSONA.IID;
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

                    if (dr["PERSONAID"] != System.DBNull.Value)
                    {
                        retorno.IPERSONAID = (long)(dr["PERSONAID"]);
                    }

                    if (dr["PRODUCTOID"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTOID = (long)(dr["PRODUCTOID"]);
                    }

                    if (dr["PRECIO"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO = (decimal)(dr["PRECIO"]);
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






        public CPRECIOPERSONABE seleccionarPRECIOPERSONAXPersonaYProd(CPRECIOPERSONABE oCPRECIOPERSONA, FbTransaction st)
        {




            CPRECIOPERSONABE retorno = new CPRECIOPERSONABE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from PRECIOPERSONA where PERSONAID=@PERSONAID AND PRODUCTOID = @PRODUCTOID  ";


                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                auxPar.Value = oCPRECIOPERSONA.IPERSONAID;
                parts.Add(auxPar);



                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                auxPar.Value = oCPRECIOPERSONA.IPRODUCTOID;
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

                    if (dr["PERSONAID"] != System.DBNull.Value)
                    {
                        retorno.IPERSONAID = (long)(dr["PERSONAID"]);
                    }

                    if (dr["PRODUCTOID"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTOID = (long)(dr["PRODUCTOID"]);
                    }

                    if (dr["PRECIO"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO = (decimal)(dr["PRECIO"]);
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




        
        public DataSet enlistarPRECIOPERSONA()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PRECIOPERSONA_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        
        public DataSet enlistarCortoPRECIOPERSONA()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PRECIOPERSONA_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        
        public int ExistePRECIOPERSONA(CPRECIOPERSONABE oCPRECIOPERSONA, FbTransaction st)
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
                auxPar.Value = oCPRECIOPERSONA.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from PRECIOPERSONA where

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




        public CPRECIOPERSONABE AgregarPRECIOPERSONA(CPRECIOPERSONABE oCPRECIOPERSONA, FbTransaction st)
        {
            try
            {
                int iRes = ExistePRECIOPERSONA(oCPRECIOPERSONA, st);
                if (iRes == 1)
                {
                    this.IComentario = "El PRECIOPERSONA ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarPRECIOPERSONAD(oCPRECIOPERSONA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarPRECIOPERSONA(CPRECIOPERSONABE oCPRECIOPERSONA, FbTransaction st)
        {
            try
            {
                int iRes = ExistePRECIOPERSONA(oCPRECIOPERSONA, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PRECIOPERSONA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarPRECIOPERSONAD(oCPRECIOPERSONA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarPRECIOPERSONA(CPRECIOPERSONABE oCPRECIOPERSONANuevo, CPRECIOPERSONABE oCPRECIOPERSONAAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExistePRECIOPERSONA(oCPRECIOPERSONAAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PRECIOPERSONA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarPRECIOPERSONAD(oCPRECIOPERSONANuevo, oCPRECIOPERSONAAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CPRECIOPERSONAD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
