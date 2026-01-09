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




    public class CPRODUCTOLOCATIONSD
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



        public bool AgregarPRODUCTOLOCATIONSD(CPRODUCTOLOCATIONSBE oCPRODUCTOLOCATIONS, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTOLOCATIONS.isnull["IPRODUCTOID"])
                {
                    auxPar.Value = oCPRODUCTOLOCATIONS.IPRODUCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ANAQUEL", FbDbType.VarChar);
                if (!(bool)oCPRODUCTOLOCATIONS.isnull["IANAQUEL"])
                {
                    auxPar.Value = oCPRODUCTOLOCATIONS.IANAQUEL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LOCALIDAD", FbDbType.VarChar);
                if (!(bool)oCPRODUCTOLOCATIONS.isnull["ILOCALIDAD"])
                {
                    auxPar.Value = oCPRODUCTOLOCATIONS.ILOCALIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ANAQUELID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTOLOCATIONS.isnull["IANAQUELID"])
                {
                    auxPar.Value = oCPRODUCTOLOCATIONS.IANAQUELID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ALMACENID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTOLOCATIONS.isnull["IALMACENID"])
                {
                    auxPar.Value = oCPRODUCTOLOCATIONS.IALMACENID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO PRODUCTOLOCATIONS
      (
    

PRODUCTOID,

ANAQUEL,

LOCALIDAD,

ANAQUELID,

ALMACENID
         )

Values (


@PRODUCTOID,

@ANAQUEL,

@LOCALIDAD,

@ANAQUELID,

@ALMACENID
); ";

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



        public bool BorrarPRODUCTOLOCATIONSD(CPRODUCTOLOCATIONSBE oCPRODUCTOLOCATIONS, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPRODUCTOLOCATIONS.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from PRODUCTOLOCATIONS
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



        public bool CambiarPRODUCTOLOCATIONSD(CPRODUCTOLOCATIONSBE oCPRODUCTOLOCATIONSNuevo, CPRODUCTOLOCATIONSBE oCPRODUCTOLOCATIONSAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTOLOCATIONSNuevo.isnull["IID"])
                {
                    auxPar.Value = oCPRODUCTOLOCATIONSNuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCPRODUCTOLOCATIONSNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCPRODUCTOLOCATIONSNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTOLOCATIONSNuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCPRODUCTOLOCATIONSNuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTOLOCATIONSNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCPRODUCTOLOCATIONSNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTOLOCATIONSNuevo.isnull["IPRODUCTOID"])
                {
                    auxPar.Value = oCPRODUCTOLOCATIONSNuevo.IPRODUCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ANAQUEL", FbDbType.VarChar);
                if (!(bool)oCPRODUCTOLOCATIONSNuevo.isnull["IANAQUEL"])
                {
                    auxPar.Value = oCPRODUCTOLOCATIONSNuevo.IANAQUEL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LOCALIDAD", FbDbType.VarChar);
                if (!(bool)oCPRODUCTOLOCATIONSNuevo.isnull["ILOCALIDAD"])
                {
                    auxPar.Value = oCPRODUCTOLOCATIONSNuevo.ILOCALIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@ANAQUELID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTOLOCATIONSNuevo.isnull["IANAQUELID"])
                {
                    auxPar.Value = oCPRODUCTOLOCATIONSNuevo.IANAQUELID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@ALMACENID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTOLOCATIONSNuevo.isnull["IALMACENID"])
                {
                    auxPar.Value = oCPRODUCTOLOCATIONSNuevo.IALMACENID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCPRODUCTOLOCATIONSAnterior.isnull["IID"])
                {
                    auxPar.Value = oCPRODUCTOLOCATIONSAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  PRODUCTOLOCATIONS
  set

ID=@ID,

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

PRODUCTOID=@PRODUCTOID,

ANAQUEL=@ANAQUEL,

LOCALIDAD=@LOCALIDAD,

ANAQUELID = @ANAQUELID,

ALMACENID = @ALMACENID
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



        public CPRODUCTOLOCATIONSBE seleccionarPRODUCTOLOCATIONS(CPRODUCTOLOCATIONSBE oCPRODUCTOLOCATIONS, FbTransaction st)
        {




            CPRODUCTOLOCATIONSBE retorno = new CPRODUCTOLOCATIONSBE();

            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from PRODUCTOLOCATIONS where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPRODUCTOLOCATIONS.IID;
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

                    if (dr["PRODUCTOID"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTOID = (long)(dr["PRODUCTOID"]);
                    }

                    if (dr["ANAQUEL"] != System.DBNull.Value)
                    {
                        retorno.IANAQUEL = (string)(dr["ANAQUEL"]);
                    }

                    if (dr["LOCALIDAD"] != System.DBNull.Value)
                    {
                        retorno.ILOCALIDAD = (string)(dr["LOCALIDAD"]);
                    }
                    if (dr["ANAQUELID"] != System.DBNull.Value)
                    {
                        retorno.IANAQUELID = (long)(dr["ANAQUELID"]);
                    }

                    if (dr["ALMACENID"] != System.DBNull.Value)
                    {
                        retorno.IALMACENID = (long)(dr["ALMACENID"]);
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






        public CPRODUCTOLOCATIONSBE seleccionarPRODUCTOLOCATIONSXINFO(CPRODUCTOLOCATIONSBE oCPRODUCTOLOCATIONS, FbTransaction st)
        {




            CPRODUCTOLOCATIONSBE retorno = new CPRODUCTOLOCATIONSBE();

            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from PRODUCTOLOCATIONS where PRODUCTOID = @PRODUCTOID AND ANAQUELID = @ANAQUELID AND LOCALIDAD = @LOCALIDAD AND COALESCE(ALMACENID,0) = COALESCE(@ALMACENID,0)";


                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                auxPar.Value = oCPRODUCTOLOCATIONS.IPRODUCTOID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ANAQUELID", FbDbType.BigInt);
                auxPar.Value = oCPRODUCTOLOCATIONS.IANAQUELID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@LOCALIDAD", FbDbType.VarChar);
                auxPar.Value = oCPRODUCTOLOCATIONS.ILOCALIDAD;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ALMACENID", FbDbType.BigInt);

                if (!(bool)oCPRODUCTOLOCATIONS.isnull["IALMACENID"])
                {
                    auxPar.Value = oCPRODUCTOLOCATIONS.IALMACENID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }

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

                    if (dr["PRODUCTOID"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTOID = (long)(dr["PRODUCTOID"]);
                    }

                    if (dr["ANAQUEL"] != System.DBNull.Value)
                    {
                        retorno.IANAQUEL = (string)(dr["ANAQUEL"]);
                    }

                    if (dr["LOCALIDAD"] != System.DBNull.Value)
                    {
                        retorno.ILOCALIDAD = (string)(dr["LOCALIDAD"]);
                    }
                    if (dr["ANAQUELID"] != System.DBNull.Value)
                    {
                        retorno.IANAQUELID = (long)(dr["ANAQUELID"]);
                    }

                    if (dr["ALMACENID"] != System.DBNull.Value)
                    {
                        retorno.IALMACENID = (long)(dr["ALMACENID"]);
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




        public DataSet enlistarPRODUCTOLOCATIONS()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PRODUCTOLOCATIONS_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }





        public DataSet enlistarCortoPRODUCTOLOCATIONS()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PRODUCTOLOCATIONS_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public int ExistePRODUCTOLOCATIONS(CPRODUCTOLOCATIONSBE oCPRODUCTOLOCATIONS, FbTransaction st)
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
                auxPar.Value = oCPRODUCTOLOCATIONS.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from PRODUCTOLOCATIONS where

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




        public bool AgregarPRODUCTOLOCATIONS(CPRODUCTOLOCATIONSBE oCPRODUCTOLOCATIONS, FbTransaction st)
        {
            try
            {
                int iRes = ExistePRODUCTOLOCATIONS(oCPRODUCTOLOCATIONS, st);
                if (iRes == 1)
                {
                    this.IComentario = "El PRODUCTOLOCATIONS ya existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return AgregarPRODUCTOLOCATIONSD(oCPRODUCTOLOCATIONS, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public bool BorrarPRODUCTOLOCATIONS(CPRODUCTOLOCATIONSBE oCPRODUCTOLOCATIONS, FbTransaction st)
        {
            try
            {
                int iRes = ExistePRODUCTOLOCATIONS(oCPRODUCTOLOCATIONS, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PRODUCTOLOCATIONS no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarPRODUCTOLOCATIONSD(oCPRODUCTOLOCATIONS, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarPRODUCTOLOCATIONS(CPRODUCTOLOCATIONSBE oCPRODUCTOLOCATIONSNuevo, CPRODUCTOLOCATIONSBE oCPRODUCTOLOCATIONSAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExistePRODUCTOLOCATIONS(oCPRODUCTOLOCATIONSAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PRODUCTOLOCATIONS no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarPRODUCTOLOCATIONSD(oCPRODUCTOLOCATIONSNuevo, oCPRODUCTOLOCATIONSAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CPRODUCTOLOCATIONSD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
