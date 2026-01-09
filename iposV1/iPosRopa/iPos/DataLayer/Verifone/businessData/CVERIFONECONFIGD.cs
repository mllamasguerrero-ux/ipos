

using System;
using Microsoft.ApplicationBlocks.Data;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Collections;
using ConexionesBD;
using iPosBusinessEntity;
using System.Collections.Generic;

namespace iPosData
{

    public class CVERIFONECONFIGD
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
        public CVERIFONECONFIGBE AgregarVERIFONECONFIGD(CVERIFONECONFIGBE oCVERIFONECONFIG, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCVERIFONECONFIG.isnull["IID"])
                {
                    auxPar.Value = oCVERIFONECONFIG.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCVERIFONECONFIG.isnull["IACTIVO"])
                {
                    auxPar.Value = oCVERIFONECONFIG.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCVERIFONECONFIG.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCVERIFONECONFIG.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCVERIFONECONFIG.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCVERIFONECONFIG.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@USERID", FbDbType.VarChar);
                if (!(bool)oCVERIFONECONFIG.isnull["IUSERID"])
                {
                    auxPar.Value = oCVERIFONECONFIG.IUSERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CONTRASENA", FbDbType.VarChar);
                if (!(bool)oCVERIFONECONFIG.isnull["ICONTRASENA"])
                {
                    auxPar.Value = oCVERIFONECONFIG.ICONTRASENA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SHIFTNUMBER", FbDbType.VarChar);
                if (!(bool)oCVERIFONECONFIG.isnull["ISHIFTNUMBER"])
                {
                    auxPar.Value = oCVERIFONECONFIG.ISHIFTNUMBER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MERCHANTID", FbDbType.VarChar);
                if (!(bool)oCVERIFONECONFIG.isnull["IMERCHANTID"])
                {
                    auxPar.Value = oCVERIFONECONFIG.IMERCHANTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@OPERATORLOCALE", FbDbType.VarChar);
                if (!(bool)oCVERIFONECONFIG.isnull["IOPERATORLOCALE"])
                {
                    auxPar.Value = oCVERIFONECONFIG.IOPERATORLOCALE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO VERIFONECONFIG
      (
    
ID,

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

USERID,

CONTRASENA,

SHIFTNUMBER,

MERCHANTID,

OPERATORLOCALE
         )

Values (

@ID,

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@USERID,

@CONTRASENA,

@SHIFTNUMBER,

@MERCHANTID,

@OPERATORLOCALE
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCVERIFONECONFIG;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarVERIFONECONFIGD(CVERIFONECONFIGBE oCVERIFONECONFIG, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCVERIFONECONFIG.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from VERIFONECONFIG
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
        public bool CambiarVERIFONECONFIGD(CVERIFONECONFIGBE oCVERIFONECONFIGNuevo, CVERIFONECONFIGBE oCVERIFONECONFIGAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCVERIFONECONFIGNuevo.isnull["IID"])
                {
                    auxPar.Value = oCVERIFONECONFIGNuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCVERIFONECONFIGNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCVERIFONECONFIGNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCVERIFONECONFIGNuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCVERIFONECONFIGNuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCVERIFONECONFIGNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCVERIFONECONFIGNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@USERID", FbDbType.VarChar);
                if (!(bool)oCVERIFONECONFIGNuevo.isnull["IUSERID"])
                {
                    auxPar.Value = oCVERIFONECONFIGNuevo.IUSERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CONTRASENA", FbDbType.VarChar);
                if (!(bool)oCVERIFONECONFIGNuevo.isnull["ICONTRASENA"])
                {
                    auxPar.Value = oCVERIFONECONFIGNuevo.ICONTRASENA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SHIFTNUMBER", FbDbType.VarChar);
                if (!(bool)oCVERIFONECONFIGNuevo.isnull["ISHIFTNUMBER"])
                {
                    auxPar.Value = oCVERIFONECONFIGNuevo.ISHIFTNUMBER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MERCHANTID", FbDbType.VarChar);
                if (!(bool)oCVERIFONECONFIGNuevo.isnull["IMERCHANTID"])
                {
                    auxPar.Value = oCVERIFONECONFIGNuevo.IMERCHANTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@OPERATORLOCALE", FbDbType.VarChar);
                if (!(bool)oCVERIFONECONFIGNuevo.isnull["IOPERATORLOCALE"])
                {
                    auxPar.Value = oCVERIFONECONFIGNuevo.IOPERATORLOCALE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCVERIFONECONFIGAnterior.isnull["IID"])
                {
                    auxPar.Value = oCVERIFONECONFIGAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  VERIFONECONFIG
  set

ID=@ID,

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

USERID=@USERID,

CONTRASENA=@CONTRASENA,

SHIFTNUMBER=@SHIFTNUMBER,

MERCHANTID=@MERCHANTID,

OPERATORLOCALE=@OPERATORLOCALE
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
        public CVERIFONECONFIGBE seleccionarVERIFONECONFIG(CVERIFONECONFIGBE oCVERIFONECONFIG, FbTransaction st)
        {




            CVERIFONECONFIGBE retorno = new CVERIFONECONFIGBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from VERIFONECONFIG where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCVERIFONECONFIG.IID;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    retorno = ObtenerDeReader(dr);

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




        private CVERIFONECONFIGBE ObtenerDeReader(FbDataReader dr)
        {

            CVERIFONECONFIGBE retorno = new CVERIFONECONFIGBE();

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

            if (dr["USERID"] != System.DBNull.Value)
            {
                retorno.IUSERID = (string)(dr["USERID"]);
            }

            if (dr["CONTRASENA"] != System.DBNull.Value)
            {
                retorno.ICONTRASENA = (string)(dr["CONTRASENA"]);
            }

            if (dr["SHIFTNUMBER"] != System.DBNull.Value)
            {
                retorno.ISHIFTNUMBER = (string)(dr["SHIFTNUMBER"]);
            }

            if (dr["MERCHANTID"] != System.DBNull.Value)
            {
                retorno.IMERCHANTID = (string)(dr["MERCHANTID"]);
            }

            if (dr["OPERATORLOCALE"] != System.DBNull.Value)
            {
                retorno.IOPERATORLOCALE = (string)(dr["OPERATORLOCALE"]);
            }
            return retorno;
        }


        public CVERIFONECONFIGBE seleccionarVERIFONECONFIG_Unico(FbTransaction st)
        {




            CVERIFONECONFIGBE retorno = new CVERIFONECONFIGBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();

                String CmdTxt = @"select first 1 * from VERIFONECONFIG  ";
                




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {
                    retorno = ObtenerDeReader(dr);

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
        public DataSet enlistarVERIFONECONFIG()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_VERIFONECONFIG_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoVERIFONECONFIG()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_VERIFONECONFIG_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteVERIFONECONFIG(CVERIFONECONFIGBE oCVERIFONECONFIG, FbTransaction st)
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
                auxPar.Value = oCVERIFONECONFIG.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from VERIFONECONFIG where

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




        public CVERIFONECONFIGBE AgregarVERIFONECONFIG(CVERIFONECONFIGBE oCVERIFONECONFIG, FbTransaction st)
        {
            try
            {
                int iRes = ExisteVERIFONECONFIG(oCVERIFONECONFIG, st);
                if (iRes == 1)
                {
                    this.IComentario = "El VERIFONECONFIG ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarVERIFONECONFIGD(oCVERIFONECONFIG, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarVERIFONECONFIG(CVERIFONECONFIGBE oCVERIFONECONFIG, FbTransaction st)
        {
            try
            {
                int iRes = ExisteVERIFONECONFIG(oCVERIFONECONFIG, st);
                if (iRes == 0)
                {
                    this.IComentario = "El VERIFONECONFIG no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarVERIFONECONFIGD(oCVERIFONECONFIG, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarVERIFONECONFIG(CVERIFONECONFIGBE oCVERIFONECONFIGNuevo, CVERIFONECONFIGBE oCVERIFONECONFIGAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteVERIFONECONFIG(oCVERIFONECONFIGAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El VERIFONECONFIG no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarVERIFONECONFIGD(oCVERIFONECONFIGNuevo, oCVERIFONECONFIGAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CVERIFONECONFIGD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
