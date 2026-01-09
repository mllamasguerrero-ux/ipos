

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



    public class CKITDEFTEMPD
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


        public CKITDEFTEMPBE AgregarKITDEFTEMPD(CKITDEFTEMPBE oCKITDEFTEMP, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;





                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCKITDEFTEMP.isnull["IACTIVO"])
                {
                    auxPar.Value = oCKITDEFTEMP.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PRODUCTOKITID", FbDbType.BigInt);
                if (!(bool)oCKITDEFTEMP.isnull["IPRODUCTOKITID"])
                {
                    auxPar.Value = oCKITDEFTEMP.IPRODUCTOKITID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTOPARTEID", FbDbType.BigInt);
                if (!(bool)oCKITDEFTEMP.isnull["IPRODUCTOPARTEID"])
                {
                    auxPar.Value = oCKITDEFTEMP.IPRODUCTOPARTEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADPARTE", FbDbType.Numeric);
                if (!(bool)oCKITDEFTEMP.isnull["ICANTIDADPARTE"])
                {
                    auxPar.Value = oCKITDEFTEMP.ICANTIDADPARTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTOKITCLAVE", FbDbType.VarChar);
                if (!(bool)oCKITDEFTEMP.isnull["IPRODUCTOKITCLAVE"])
                {
                    auxPar.Value = oCKITDEFTEMP.IPRODUCTOKITCLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTOPARTECLAVE", FbDbType.VarChar);
                if (!(bool)oCKITDEFTEMP.isnull["IPRODUCTOPARTECLAVE"])
                {
                    auxPar.Value = oCKITDEFTEMP.IPRODUCTOPARTECLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@COSTOPARTE", FbDbType.Numeric);
                if (!(bool)oCKITDEFTEMP.isnull["ICOSTOPARTE"])
                {
                    auxPar.Value = oCKITDEFTEMP.ICOSTOPARTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO KITDEFTEMP
      (
    

ACTIVO,

PRODUCTOKITID,

PRODUCTOPARTEID,

CANTIDADPARTE,

PRODUCTOKITCLAVE,

PRODUCTOPARTECLAVE,

COSTOPARTE
         )

Values (

@ACTIVO,

@PRODUCTOKITID,

@PRODUCTOPARTEID,

@CANTIDADPARTE,

@PRODUCTOKITCLAVE,

@PRODUCTOPARTECLAVE,

@COSTOPARTE
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCKITDEFTEMP;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarKITDEFTEMPD(CKITDEFTEMPBE oCKITDEFTEMP, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCKITDEFTEMP.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from KITDEFTEMP
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
        public bool CambiarKITDEFTEMPD(CKITDEFTEMPBE oCKITDEFTEMPNuevo, CKITDEFTEMPBE oCKITDEFTEMPAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCKITDEFTEMPNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCKITDEFTEMPNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTOKITID", FbDbType.BigInt);
                if (!(bool)oCKITDEFTEMPNuevo.isnull["IPRODUCTOKITID"])
                {
                    auxPar.Value = oCKITDEFTEMPNuevo.IPRODUCTOKITID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRODUCTOPARTEID", FbDbType.BigInt);
                if (!(bool)oCKITDEFTEMPNuevo.isnull["IPRODUCTOPARTEID"])
                {
                    auxPar.Value = oCKITDEFTEMPNuevo.IPRODUCTOPARTEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CANTIDADPARTE", FbDbType.Numeric);
                if (!(bool)oCKITDEFTEMPNuevo.isnull["ICANTIDADPARTE"])
                {
                    auxPar.Value = oCKITDEFTEMPNuevo.ICANTIDADPARTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRODUCTOKITCLAVE", FbDbType.VarChar);
                if (!(bool)oCKITDEFTEMPNuevo.isnull["IPRODUCTOKITCLAVE"])
                {
                    auxPar.Value = oCKITDEFTEMPNuevo.IPRODUCTOKITCLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRODUCTOPARTECLAVE", FbDbType.VarChar);
                if (!(bool)oCKITDEFTEMPNuevo.isnull["IPRODUCTOPARTECLAVE"])
                {
                    auxPar.Value = oCKITDEFTEMPNuevo.IPRODUCTOPARTECLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@COSTOPARTE", FbDbType.Numeric);
                if (!(bool)oCKITDEFTEMPNuevo.isnull["ICOSTOPARTE"])
                {
                    auxPar.Value = oCKITDEFTEMPNuevo.ICOSTOPARTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCKITDEFTEMPAnterior.isnull["IID"])
                {
                    auxPar.Value = oCKITDEFTEMPAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  KITDEFTEMP
  set


ACTIVO=@ACTIVO,

PRODUCTOKITID=@PRODUCTOKITID,

PRODUCTOPARTEID=@PRODUCTOPARTEID,

CANTIDADPARTE=@CANTIDADPARTE,

PRODUCTOKITCLAVE=@PRODUCTOKITCLAVE,

PRODUCTOPARTECLAVE=@PRODUCTOPARTECLAVE,

COSTOPARTE=@COSTOPARTE
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
        public CKITDEFTEMPBE seleccionarKITDEFTEMP(CKITDEFTEMPBE oCKITDEFTEMP, FbTransaction st)
        {




            CKITDEFTEMPBE retorno = new CKITDEFTEMPBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from KITDEFTEMP where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCKITDEFTEMP.IID;
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

                    if (dr["PRODUCTOKITID"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTOKITID = (long)(dr["PRODUCTOKITID"]);
                    }

                    if (dr["PRODUCTOPARTEID"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTOPARTEID = (long)(dr["PRODUCTOPARTEID"]);
                    }

                    if (dr["CANTIDADPARTE"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDADPARTE = (decimal)(dr["CANTIDADPARTE"]);
                    }

                    if (dr["PRODUCTOKITCLAVE"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTOKITCLAVE = (string)(dr["PRODUCTOKITCLAVE"]);
                    }

                    if (dr["PRODUCTOPARTECLAVE"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTOPARTECLAVE = (string)(dr["PRODUCTOPARTECLAVE"]);
                    }
                    if (dr["COSTOPARTE"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOPARTE = (decimal)(dr["COSTOPARTE"]);
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
        public DataSet enlistarKITDEFTEMP()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_KITDEFTEMP_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoKITDEFTEMP()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_KITDEFTEMP_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteKITDEFTEMP(CKITDEFTEMPBE oCKITDEFTEMP, FbTransaction st)
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
                auxPar.Value = oCKITDEFTEMP.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from KITDEFTEMP where

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






        public CKITDEFTEMPBE AgregarKITDEFTEMP(CKITDEFTEMPBE oCKITDEFTEMP, FbTransaction st)
        {
            try
            {
                int iRes = ExisteKITDEFTEMP(oCKITDEFTEMP, st);
                if (iRes == 1)
                {
                    this.IComentario = "El KITDEFTEMP ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarKITDEFTEMPD(oCKITDEFTEMP, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarKITDEFTEMP(CKITDEFTEMPBE oCKITDEFTEMP, FbTransaction st)
        {
            try
            {
                int iRes = ExisteKITDEFTEMP(oCKITDEFTEMP, st);
                if (iRes == 0)
                {
                    this.IComentario = "El KITDEFTEMP no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarKITDEFTEMPD(oCKITDEFTEMP, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarKITDEFTEMP(CKITDEFTEMPBE oCKITDEFTEMPNuevo, CKITDEFTEMPBE oCKITDEFTEMPAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteKITDEFTEMP(oCKITDEFTEMPAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El KITDEFTEMP no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarKITDEFTEMPD(oCKITDEFTEMPNuevo, oCKITDEFTEMPAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }






        public bool KIT_PREPARETEMPTABLE( FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);




                string commandText = @"KIT_PREPARETEMPTABLE";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);



                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        this.iComentario = "Hubo un error " + arParms[arParms.Length - 1].Value.ToString();
                        return false;
                    }
                }





                return true;




            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool KIT_APPLYTEMPTABLE(FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);




                string commandText = @"KIT_APPLYTEMPTABLE";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);



                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        this.iComentario = "Hubo un error " + arParms[arParms.Length - 1].Value.ToString();
                        return false;
                    }
                }





                return true;




            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public CKITDEFTEMPD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
