

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



    public class CVERIFONECAJACONFIGD
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



        public CVERIFONECAJACONFIGBE AgregarVERIFONECAJACONFIGD(CVERIFONECAJACONFIGBE oCVERIFONECAJACONFIG, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCVERIFONECAJACONFIG.isnull["IID"])
                {
                    auxPar.Value = oCVERIFONECAJACONFIG.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCVERIFONECAJACONFIG.isnull["IACTIVO"])
                {
                    auxPar.Value = oCVERIFONECAJACONFIG.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCVERIFONECAJACONFIG.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCVERIFONECAJACONFIG.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCVERIFONECAJACONFIG.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCVERIFONECAJACONFIG.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAJAID", FbDbType.BigInt);
                if (!(bool)oCVERIFONECAJACONFIG.isnull["ICAJAID"])
                {
                    auxPar.Value = oCVERIFONECAJACONFIG.ICAJAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@USERID", FbDbType.VarChar);
                if (!(bool)oCVERIFONECAJACONFIG.isnull["IUSERID"])
                {
                    auxPar.Value = oCVERIFONECAJACONFIG.IUSERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CONTRASENA", FbDbType.VarChar);
                if (!(bool)oCVERIFONECAJACONFIG.isnull["ICONTRASENA"])
                {
                    auxPar.Value = oCVERIFONECAJACONFIG.ICONTRASENA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SHIFTNUMBER", FbDbType.VarChar);
                if (!(bool)oCVERIFONECAJACONFIG.isnull["ISHIFTNUMBER"])
                {
                    auxPar.Value = oCVERIFONECAJACONFIG.ISHIFTNUMBER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MERCHANTID", FbDbType.VarChar);
                if (!(bool)oCVERIFONECAJACONFIG.isnull["IMERCHANTID"])
                {
                    auxPar.Value = oCVERIFONECAJACONFIG.IMERCHANTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@OPERATORLOCALE", FbDbType.VarChar);
                if (!(bool)oCVERIFONECAJACONFIG.isnull["IOPERATORLOCALE"])
                {
                    auxPar.Value = oCVERIFONECAJACONFIG.IOPERATORLOCALE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DEVICECONNECTIONTYPEKEY", FbDbType.VarChar);
                if (!(bool)oCVERIFONECAJACONFIG.isnull["IDEVICECONNECTIONTYPEKEY"])
                {
                    auxPar.Value = oCVERIFONECAJACONFIG.IDEVICECONNECTIONTYPEKEY;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DEVICEADDRESSKEY", FbDbType.VarChar);
                if (!(bool)oCVERIFONECAJACONFIG.isnull["IDEVICEADDRESSKEY"])
                {
                    auxPar.Value = oCVERIFONECAJACONFIG.IDEVICEADDRESSKEY;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO VERIFONECAJACONFIG
      (
    
ID,

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

CAJAID,

USERID,

CONTRASENA,

SHIFTNUMBER,

MERCHANTID,

OPERATORLOCALE,

DEVICECONNECTIONTYPEKEY,

DEVICEADDRESSKEY
         )

Values (

@ID,

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@CAJAID,

@USERID,

@CONTRASENA,

@SHIFTNUMBER,

@MERCHANTID,

@OPERATORLOCALE,

@DEVICECONNECTIONTYPEKEY,

@DEVICEADDRESSKEY
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCVERIFONECAJACONFIG;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }



        public bool BorrarVERIFONECAJACONFIGD(CVERIFONECAJACONFIGBE oCVERIFONECAJACONFIG, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCVERIFONECAJACONFIG.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from VERIFONECAJACONFIG
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



        public bool CambiarVERIFONECAJACONFIGD(CVERIFONECAJACONFIGBE oCVERIFONECAJACONFIGNuevo, CVERIFONECAJACONFIGBE oCVERIFONECAJACONFIGAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCVERIFONECAJACONFIGNuevo.isnull["IID"])
                {
                    auxPar.Value = oCVERIFONECAJACONFIGNuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCVERIFONECAJACONFIGNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCVERIFONECAJACONFIGNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCVERIFONECAJACONFIGNuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCVERIFONECAJACONFIGNuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCVERIFONECAJACONFIGNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCVERIFONECAJACONFIGNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAJAID", FbDbType.BigInt);
                if (!(bool)oCVERIFONECAJACONFIGNuevo.isnull["ICAJAID"])
                {
                    auxPar.Value = oCVERIFONECAJACONFIGNuevo.ICAJAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@USERID", FbDbType.VarChar);
                if (!(bool)oCVERIFONECAJACONFIGNuevo.isnull["IUSERID"])
                {
                    auxPar.Value = oCVERIFONECAJACONFIGNuevo.IUSERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CONTRASENA", FbDbType.VarChar);
                if (!(bool)oCVERIFONECAJACONFIGNuevo.isnull["ICONTRASENA"])
                {
                    auxPar.Value = oCVERIFONECAJACONFIGNuevo.ICONTRASENA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SHIFTNUMBER", FbDbType.VarChar);
                if (!(bool)oCVERIFONECAJACONFIGNuevo.isnull["ISHIFTNUMBER"])
                {
                    auxPar.Value = oCVERIFONECAJACONFIGNuevo.ISHIFTNUMBER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MERCHANTID", FbDbType.VarChar);
                if (!(bool)oCVERIFONECAJACONFIGNuevo.isnull["IMERCHANTID"])
                {
                    auxPar.Value = oCVERIFONECAJACONFIGNuevo.IMERCHANTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@OPERATORLOCALE", FbDbType.VarChar);
                if (!(bool)oCVERIFONECAJACONFIGNuevo.isnull["IOPERATORLOCALE"])
                {
                    auxPar.Value = oCVERIFONECAJACONFIGNuevo.IOPERATORLOCALE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DEVICECONNECTIONTYPEKEY", FbDbType.VarChar);
                if (!(bool)oCVERIFONECAJACONFIGNuevo.isnull["IDEVICECONNECTIONTYPEKEY"])
                {
                    auxPar.Value = oCVERIFONECAJACONFIGNuevo.IDEVICECONNECTIONTYPEKEY;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DEVICEADDRESSKEY", FbDbType.VarChar);
                if (!(bool)oCVERIFONECAJACONFIGNuevo.isnull["IDEVICEADDRESSKEY"])
                {
                    auxPar.Value = oCVERIFONECAJACONFIGNuevo.IDEVICEADDRESSKEY;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCVERIFONECAJACONFIGAnterior.isnull["IID"])
                {
                    auxPar.Value = oCVERIFONECAJACONFIGAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  VERIFONECAJACONFIG
  set

ID=@ID,

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

CAJAID=@CAJAID,

USERID=@USERID,

CONTRASENA=@CONTRASENA,

SHIFTNUMBER=@SHIFTNUMBER,

MERCHANTID=@MERCHANTID,

OPERATORLOCALE=@OPERATORLOCALE,

DEVICECONNECTIONTYPEKEY=@DEVICECONNECTIONTYPEKEY,

DEVICEADDRESSKEY=@DEVICEADDRESSKEY
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


        private CVERIFONECAJACONFIGBE ObtenerDeReader(FbDataReader dr)
        {

            CVERIFONECAJACONFIGBE retorno = new CVERIFONECAJACONFIGBE();

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

            if (dr["CAJAID"] != System.DBNull.Value)
            {
                retorno.ICAJAID = (long)(dr["CAJAID"]);
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

            if (dr["DEVICECONNECTIONTYPEKEY"] != System.DBNull.Value)
            {
                retorno.IDEVICECONNECTIONTYPEKEY = (string)(dr["DEVICECONNECTIONTYPEKEY"]);
            }

            if (dr["DEVICEADDRESSKEY"] != System.DBNull.Value)
            {
                retorno.IDEVICEADDRESSKEY = (string)(dr["DEVICEADDRESSKEY"]);
            }

            return retorno;
        }



        public CVERIFONECAJACONFIGBE seleccionarVERIFONECAJACONFIG(CVERIFONECAJACONFIGBE oCVERIFONECAJACONFIG, FbTransaction st)
        {




            CVERIFONECAJACONFIGBE retorno = new CVERIFONECAJACONFIGBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from VERIFONECAJACONFIG where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCVERIFONECAJACONFIG.IID;
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







        public CVERIFONECAJACONFIGBE seleccionarVERIFONECAJACONFIG_x_CAJAID(CVERIFONECAJACONFIGBE oCVERIFONECAJACONFIG, FbTransaction st)
        {




            CVERIFONECAJACONFIGBE retorno = new CVERIFONECAJACONFIGBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from VERIFONECAJACONFIG where CAJAID = @CAJAID";


                auxPar = new FbParameter("@CAJAID", FbDbType.BigInt);
                auxPar.Value = oCVERIFONECAJACONFIG.ICAJAID;
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




        public DataSet enlistarVERIFONECAJACONFIG()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_VERIFONECAJACONFIG_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }





        public DataSet enlistarCortoVERIFONECAJACONFIG()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_VERIFONECAJACONFIG_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public int ExisteVERIFONECAJACONFIG(CVERIFONECAJACONFIGBE oCVERIFONECAJACONFIG, FbTransaction st)
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
                auxPar.Value = oCVERIFONECAJACONFIG.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from VERIFONECAJACONFIG where

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




        public CVERIFONECAJACONFIGBE AgregarVERIFONECAJACONFIG(CVERIFONECAJACONFIGBE oCVERIFONECAJACONFIG, FbTransaction st)
        {
            try
            {
                int iRes = ExisteVERIFONECAJACONFIG(oCVERIFONECAJACONFIG, st);
                if (iRes == 1)
                {
                    this.IComentario = "El VERIFONECAJACONFIG ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarVERIFONECAJACONFIGD(oCVERIFONECAJACONFIG, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarVERIFONECAJACONFIG(CVERIFONECAJACONFIGBE oCVERIFONECAJACONFIG, FbTransaction st)
        {
            try
            {
                int iRes = ExisteVERIFONECAJACONFIG(oCVERIFONECAJACONFIG, st);
                if (iRes == 0)
                {
                    this.IComentario = "El VERIFONECAJACONFIG no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarVERIFONECAJACONFIGD(oCVERIFONECAJACONFIG, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarVERIFONECAJACONFIG(CVERIFONECAJACONFIGBE oCVERIFONECAJACONFIGNuevo, CVERIFONECAJACONFIGBE oCVERIFONECAJACONFIGAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteVERIFONECAJACONFIG(oCVERIFONECAJACONFIGAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El VERIFONECAJACONFIG no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarVERIFONECAJACONFIGD(oCVERIFONECAJACONFIGNuevo, oCVERIFONECAJACONFIGAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CVERIFONECAJACONFIGD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
