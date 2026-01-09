using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Collections;
using ConexionesBD;
using System.Collections.Generic;
namespace iPosData
{


    public class CEMIDAPRODUCTD
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


        public CEMIDAPRODEXTBE AgregarEMIDAPRODUCTD(CEMIDAPRODEXTBE oCEMIDAPRODUCT, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;





                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCEMIDAPRODUCT.isnull["IACTIVO"])
                {
                    auxPar.Value = oCEMIDAPRODUCT.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCEMIDAPRODUCT.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCEMIDAPRODUCT.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCEMIDAPRODUCT.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCEMIDAPRODUCT.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTID", FbDbType.VarChar);
                if (!(bool)oCEMIDAPRODUCT.isnull["IPRODUCTID"])
                {
                    auxPar.Value = oCEMIDAPRODUCT.IPRODUCTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPTION", FbDbType.VarChar);
                if (!(bool)oCEMIDAPRODUCT.isnull["IDESCRIPTION"])
                {
                    auxPar.Value = oCEMIDAPRODUCT.IDESCRIPTION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SHORTDESCRIPTION", FbDbType.VarChar);
                if (!(bool)oCEMIDAPRODUCT.isnull["ISHORTDESCRIPTION"])
                {
                    auxPar.Value = oCEMIDAPRODUCT.ISHORTDESCRIPTION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@AMOUNT", FbDbType.VarChar);
                if (!(bool)oCEMIDAPRODUCT.isnull["IAMOUNT"])
                {
                    auxPar.Value = oCEMIDAPRODUCT.IAMOUNT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CARRIERID", FbDbType.VarChar);
                if (!(bool)oCEMIDAPRODUCT.isnull["ICARRIERID"])
                {
                    auxPar.Value = oCEMIDAPRODUCT.ICARRIERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CATEGORYID", FbDbType.VarChar);
                if (!(bool)oCEMIDAPRODUCT.isnull["ICATEGORYID"])
                {
                    auxPar.Value = oCEMIDAPRODUCT.ICATEGORYID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TRANSTIPOID", FbDbType.VarChar);
                if (!(bool)oCEMIDAPRODUCT.isnull["ITRANSTIPOID"])
                {
                    auxPar.Value = oCEMIDAPRODUCT.ITRANSTIPOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CURRENCYCODE", FbDbType.VarChar);
                if (!(bool)oCEMIDAPRODUCT.isnull["ICURRENCYCODE"])
                {
                    auxPar.Value = oCEMIDAPRODUCT.ICURRENCYCODE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CURRENCYSYMBOL", FbDbType.VarChar);
                if (!(bool)oCEMIDAPRODUCT.isnull["ICURRENCYSYMBOL"])
                {
                    auxPar.Value = oCEMIDAPRODUCT.ICURRENCYSYMBOL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DISCOUNTRATE", FbDbType.VarChar);
                if (!(bool)oCEMIDAPRODUCT.isnull["IDISCOUNTRATE"])
                {
                    auxPar.Value = oCEMIDAPRODUCT.IDISCOUNTRATE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@H2HRESULTCODE", FbDbType.VarChar);
                if (!(bool)oCEMIDAPRODUCT.isnull["IH2HRESULTCODE"])
                {
                    auxPar.Value = oCEMIDAPRODUCT.IH2HRESULTCODE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCE", FbDbType.VarChar);
                if (!(bool)oCEMIDAPRODUCT.isnull["IREFERENCE"])
                {
                    auxPar.Value = oCEMIDAPRODUCT.IREFERENCE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@ESSERVICIO", FbDbType.VarChar);
                if (!(bool)oCEMIDAPRODUCT.isnull["IESSERVICIO"])
                {
                    auxPar.Value = oCEMIDAPRODUCT.IESSERVICIO;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                string commandText = @"
        INSERT INTO EMIDAPRODUCT
      (

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

PRODUCTID,

DESCRIPTION,

SHORTDESCRIPTION,

AMOUNT,

CARRIERID,

CATEGORYID,

TRANSTIPOID,

CURRENCYCODE,

CURRENCYSYMBOL,

DISCOUNTRATE,

H2HRESULTCODE,

REFERENCE,

ESSERVICIO
         )

Values (


@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@PRODUCTID,

@DESCRIPTION,

@SHORTDESCRIPTION,

@AMOUNT,

@CARRIERID,

@CATEGORYID,

@TRANSTIPOID,

@CURRENCYCODE,

@CURRENCYSYMBOL,

@DISCOUNTRATE,

@H2HRESULTCODE,

@REFERENCE,

@ESSERVICIO
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCEMIDAPRODUCT;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarEMIDAPRODUCTD(CEMIDAPRODEXTBE oCEMIDAPRODUCT, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCEMIDAPRODUCT.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from EMIDAPRODUCT
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

        public bool CambiarEMIDAPRODUCTD(CEMIDAPRODEXTBE oCEMIDAPRODUCTNuevo, CEMIDAPRODEXTBE oCEMIDAPRODUCTAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCEMIDAPRODUCTNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCEMIDAPRODUCTNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCEMIDAPRODUCTNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCEMIDAPRODUCTNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRODUCTID", FbDbType.VarChar);
                if (!(bool)oCEMIDAPRODUCTNuevo.isnull["IPRODUCTID"])
                {
                    auxPar.Value = oCEMIDAPRODUCTNuevo.IPRODUCTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCRIPTION", FbDbType.VarChar);
                if (!(bool)oCEMIDAPRODUCTNuevo.isnull["IDESCRIPTION"])
                {
                    auxPar.Value = oCEMIDAPRODUCTNuevo.IDESCRIPTION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SHORTDESCRIPTION", FbDbType.VarChar);
                if (!(bool)oCEMIDAPRODUCTNuevo.isnull["ISHORTDESCRIPTION"])
                {
                    auxPar.Value = oCEMIDAPRODUCTNuevo.ISHORTDESCRIPTION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@AMOUNT", FbDbType.VarChar);
                if (!(bool)oCEMIDAPRODUCTNuevo.isnull["IAMOUNT"])
                {
                    auxPar.Value = oCEMIDAPRODUCTNuevo.IAMOUNT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CARRIERID", FbDbType.VarChar);
                if (!(bool)oCEMIDAPRODUCTNuevo.isnull["ICARRIERID"])
                {
                    auxPar.Value = oCEMIDAPRODUCTNuevo.ICARRIERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CATEGORYID", FbDbType.VarChar);
                if (!(bool)oCEMIDAPRODUCTNuevo.isnull["ICATEGORYID"])
                {
                    auxPar.Value = oCEMIDAPRODUCTNuevo.ICATEGORYID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TRANSTIPOID", FbDbType.VarChar);
                if (!(bool)oCEMIDAPRODUCTNuevo.isnull["ITRANSTIPOID"])
                {
                    auxPar.Value = oCEMIDAPRODUCTNuevo.ITRANSTIPOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CURRENCYCODE", FbDbType.VarChar);
                if (!(bool)oCEMIDAPRODUCTNuevo.isnull["ICURRENCYCODE"])
                {
                    auxPar.Value = oCEMIDAPRODUCTNuevo.ICURRENCYCODE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CURRENCYSYMBOL", FbDbType.VarChar);
                if (!(bool)oCEMIDAPRODUCTNuevo.isnull["ICURRENCYSYMBOL"])
                {
                    auxPar.Value = oCEMIDAPRODUCTNuevo.ICURRENCYSYMBOL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DISCOUNTRATE", FbDbType.VarChar);
                if (!(bool)oCEMIDAPRODUCTNuevo.isnull["IDISCOUNTRATE"])
                {
                    auxPar.Value = oCEMIDAPRODUCTNuevo.IDISCOUNTRATE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@H2HRESULTCODE", FbDbType.VarChar);
                if (!(bool)oCEMIDAPRODUCTNuevo.isnull["IH2HRESULTCODE"])
                {
                    auxPar.Value = oCEMIDAPRODUCTNuevo.IH2HRESULTCODE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@REFERENCE", FbDbType.VarChar);
                if (!(bool)oCEMIDAPRODUCTNuevo.isnull["IREFERENCE"])
                {
                    auxPar.Value = oCEMIDAPRODUCTNuevo.IREFERENCE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESSERVICIO", FbDbType.VarChar);
                if (!(bool)oCEMIDAPRODUCTNuevo.isnull["IESSERVICIO"])
                {
                    auxPar.Value = oCEMIDAPRODUCTNuevo.IESSERVICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCEMIDAPRODUCTAnterior.isnull["IID"])
                {
                    auxPar.Value = oCEMIDAPRODUCTAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  EMIDAPRODUCT
  set

ACTIVO=@ACTIVO,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

PRODUCTID=@PRODUCTID,

DESCRIPTION=@DESCRIPTION,

SHORTDESCRIPTION=@SHORTDESCRIPTION,

AMOUNT=@AMOUNT,

CARRIERID=@CARRIERID,

CATEGORYID=@CATEGORYID,

TRANSTIPOID=@TRANSTIPOID,

CURRENCYCODE=@CURRENCYCODE,

CURRENCYSYMBOL=@CURRENCYSYMBOL,

DISCOUNTRATE=@DISCOUNTRATE,

H2HRESULTCODE=@H2HRESULTCODE,

REFERENCE=@REFERENCE,

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


        public CEMIDAPRODEXTBE seleccionarEMIDAPRODUCT(CEMIDAPRODEXTBE oCEMIDAPRODUCT, FbTransaction st)
        {




            CEMIDAPRODEXTBE retorno = new CEMIDAPRODEXTBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from EMIDAPRODUCT where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCEMIDAPRODUCT.IID;
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

                    if (dr["PRODUCTID"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTID = (string)(dr["PRODUCTID"]);
                    }

                    if (dr["DESCRIPTION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPTION = (string)(dr["DESCRIPTION"]);
                    }

                    if (dr["SHORTDESCRIPTION"] != System.DBNull.Value)
                    {
                        retorno.ISHORTDESCRIPTION = (string)(dr["SHORTDESCRIPTION"]);
                    }

                    if (dr["AMOUNT"] != System.DBNull.Value)
                    {
                        retorno.IAMOUNT = (string)(dr["AMOUNT"]);
                    }

                    if (dr["CARRIERID"] != System.DBNull.Value)
                    {
                        retorno.ICARRIERID = (string)(dr["CARRIERID"]);
                    }

                    if (dr["CATEGORYID"] != System.DBNull.Value)
                    {
                        retorno.ICATEGORYID = (string)(dr["CATEGORYID"]);
                    }

                    if (dr["TRANSTIPOID"] != System.DBNull.Value)
                    {
                        retorno.ITRANSTIPOID = (string)(dr["TRANSTIPOID"]);
                    }

                    if (dr["CURRENCYCODE"] != System.DBNull.Value)
                    {
                        retorno.ICURRENCYCODE = (string)(dr["CURRENCYCODE"]);
                    }

                    if (dr["CURRENCYSYMBOL"] != System.DBNull.Value)
                    {
                        retorno.ICURRENCYSYMBOL = (string)(dr["CURRENCYSYMBOL"]);
                    }

                    if (dr["DISCOUNTRATE"] != System.DBNull.Value)
                    {
                        retorno.IDISCOUNTRATE = (string)(dr["DISCOUNTRATE"]);
                    }

                    if (dr["H2HRESULTCODE"] != System.DBNull.Value)
                    {
                        retorno.IH2HRESULTCODE = (string)(dr["H2HRESULTCODE"]);
                    }

                    if (dr["REFERENCE"] != System.DBNull.Value)
                    {
                        retorno.IREFERENCE = (string)(dr["REFERENCE"]);
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







        public List<CEMIDAPRODEXTBE> seleccionarEMIDAPRODUCTListPorESSERVICIO(string esServicio, FbTransaction st)
        {



            List<CEMIDAPRODEXTBE> retornoList = new List<CEMIDAPRODEXTBE>();
            CEMIDAPRODEXTBE retorno = new CEMIDAPRODEXTBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from EMIDAPRODUCT where ESSERVICIO = @ESSERVICIO OR (@ESSERVICIO = 'N' AND ESSERVICIO IS NULL)  ";


                auxPar = new FbParameter("@ESSERVICIO", FbDbType.VarChar);
                auxPar.Value = esServicio;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                while (dr.Read())
                {
                    retorno = new CEMIDAPRODEXTBE();
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

                    if (dr["PRODUCTID"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTID = (string)(dr["PRODUCTID"]);
                    }

                    if (dr["DESCRIPTION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPTION = (string)(dr["DESCRIPTION"]);
                    }

                    if (dr["SHORTDESCRIPTION"] != System.DBNull.Value)
                    {
                        retorno.ISHORTDESCRIPTION = (string)(dr["SHORTDESCRIPTION"]);
                    }

                    if (dr["AMOUNT"] != System.DBNull.Value)
                    {
                        retorno.IAMOUNT = (string)(dr["AMOUNT"]);
                    }

                    if (dr["CARRIERID"] != System.DBNull.Value)
                    {
                        retorno.ICARRIERID = (string)(dr["CARRIERID"]);
                    }

                    if (dr["CATEGORYID"] != System.DBNull.Value)
                    {
                        retorno.ICATEGORYID = (string)(dr["CATEGORYID"]);
                    }

                    if (dr["TRANSTIPOID"] != System.DBNull.Value)
                    {
                        retorno.ITRANSTIPOID = (string)(dr["TRANSTIPOID"]);
                    }

                    if (dr["CURRENCYCODE"] != System.DBNull.Value)
                    {
                        retorno.ICURRENCYCODE = (string)(dr["CURRENCYCODE"]);
                    }

                    if (dr["CURRENCYSYMBOL"] != System.DBNull.Value)
                    {
                        retorno.ICURRENCYSYMBOL = (string)(dr["CURRENCYSYMBOL"]);
                    }

                    if (dr["DISCOUNTRATE"] != System.DBNull.Value)
                    {
                        retorno.IDISCOUNTRATE = (string)(dr["DISCOUNTRATE"]);
                    }

                    if (dr["H2HRESULTCODE"] != System.DBNull.Value)
                    {
                        retorno.IH2HRESULTCODE = (string)(dr["H2HRESULTCODE"]);
                    }

                    if (dr["REFERENCE"] != System.DBNull.Value)
                    {
                        retorno.IREFERENCE = (string)(dr["REFERENCE"]);
                    }

                    if (dr["ESSERVICIO"] != System.DBNull.Value)
                    {
                        retorno.IESSERVICIO = (string)(dr["ESSERVICIO"]);
                    }

                    retornoList.Add(retorno);


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);


                return retornoList;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public DataSet enlistarEMIDAPRODUCT()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_EMIDAPRODUCT_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoEMIDAPRODUCT()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_EMIDAPRODUCT_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public int ExisteEMIDAPRODUCT(CEMIDAPRODEXTBE oCEMIDAPRODUCT, FbTransaction st)
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
                auxPar.Value = oCEMIDAPRODUCT.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from EMIDAPRODUCT where

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




        public CEMIDAPRODEXTBE AgregarEMIDAPRODUCT(CEMIDAPRODEXTBE oCEMIDAPRODUCT, FbTransaction st)
        {
            try
            {
                int iRes = ExisteEMIDAPRODUCT(oCEMIDAPRODUCT, st);
                if (iRes == 1)
                {
                    this.IComentario = "El EMIDAPRODUCT ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarEMIDAPRODUCTD(oCEMIDAPRODUCT, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarEMIDAPRODUCT(CEMIDAPRODEXTBE oCEMIDAPRODUCT, FbTransaction st)
        {
            try
            {
                int iRes = ExisteEMIDAPRODUCT(oCEMIDAPRODUCT, st);
                if (iRes == 0)
                {
                    this.IComentario = "El EMIDAPRODUCT no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarEMIDAPRODUCTD(oCEMIDAPRODUCT, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarEMIDAPRODUCT(CEMIDAPRODEXTBE oCEMIDAPRODUCTNuevo, CEMIDAPRODEXTBE oCEMIDAPRODUCTAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteEMIDAPRODUCT(oCEMIDAPRODUCTAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El EMIDAPRODUCT no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarEMIDAPRODUCTD(oCEMIDAPRODUCTNuevo, oCEMIDAPRODUCTAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CEMIDAPRODUCTD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }

        public bool DesactivarTodosEMIDAPRODUCTD(string esservicio, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;






                string commandText = @" update EMIDAPRODUCT SET ACTIVO = 'N' WHERE ESSERVICIO = @ESSERVICIO OR (ESSERVICIO IS NULL AND @ESSERVICIO = 'N');";


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

        public CEMIDAPRODEXTBE seleccionarEMIDAPRODUCTxEMIDAPRODUCTID(CEMIDAPRODEXTBE oCEMIDAPRODUCT, FbTransaction st)
        {




            CEMIDAPRODEXTBE retorno = new CEMIDAPRODEXTBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from EMIDAPRODUCT where PRODUCTID=@PRODUCTID AND (ESSERVICIO = @ESSERVICIO OR (ESSERVICIO IS NULL AND @ESSERVICIO = 'N')) ";


                auxPar = new FbParameter("@PRODUCTID", FbDbType.VarChar);
                auxPar.Value = oCEMIDAPRODUCT.IPRODUCTID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESSERVICIO", FbDbType.VarChar);
                auxPar.Value = oCEMIDAPRODUCT.IESSERVICIO;
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

                    if (dr["PRODUCTID"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTID = (string)(dr["PRODUCTID"]);
                    }

                    if (dr["DESCRIPTION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPTION = (string)(dr["DESCRIPTION"]);
                    }

                    if (dr["SHORTDESCRIPTION"] != System.DBNull.Value)
                    {
                        retorno.ISHORTDESCRIPTION = (string)(dr["SHORTDESCRIPTION"]);
                    }

                    if (dr["AMOUNT"] != System.DBNull.Value)
                    {
                        retorno.IAMOUNT = (string)(dr["AMOUNT"]);
                    }

                    if (dr["CARRIERID"] != System.DBNull.Value)
                    {
                        retorno.ICARRIERID = (string)(dr["CARRIERID"]);
                    }

                    if (dr["CATEGORYID"] != System.DBNull.Value)
                    {
                        retorno.ICATEGORYID = (string)(dr["CATEGORYID"]);
                    }

                    if (dr["TRANSTIPOID"] != System.DBNull.Value)
                    {
                        retorno.ITRANSTIPOID = (string)(dr["TRANSTIPOID"]);
                    }

                    if (dr["CURRENCYCODE"] != System.DBNull.Value)
                    {
                        retorno.ICURRENCYCODE = (string)(dr["CURRENCYCODE"]);
                    }

                    if (dr["CURRENCYSYMBOL"] != System.DBNull.Value)
                    {
                        retorno.ICURRENCYSYMBOL = (string)(dr["CURRENCYSYMBOL"]);
                    }

                    if (dr["DISCOUNTRATE"] != System.DBNull.Value)
                    {
                        retorno.IDISCOUNTRATE = (string)(dr["DISCOUNTRATE"]);
                    }

                    if (dr["H2HRESULTCODE"] != System.DBNull.Value)
                    {
                        retorno.IH2HRESULTCODE = (string)(dr["H2HRESULTCODE"]);
                    }

                    if (dr["REFERENCE"] != System.DBNull.Value)
                    {
                        retorno.IREFERENCE = (string)(dr["REFERENCE"]);
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

        public bool EMIDA_AJUSTARCAMPOSPRODUCTOS(FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"EMIDA_AJUSTARCAMPOSPRODUCTOS";

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
                        this.iComentario = "Hubo un error" + ((int)arParms[arParms.Length - 1].Value).ToString();
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

        public bool EMIDA_REAJUSTARUTILIDADES(DateTime fechaInicial,
                                              DateTime fechaFinal, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@FECHAINICIAL", FbDbType.Date);
                auxPar.Value = fechaInicial;
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAFINAL", FbDbType.Date);
                auxPar.Value = fechaFinal;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"EMIDA_REAJUSTARUTILIDADES";

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
                        this.iComentario = "Hubo un error" + ((int)arParms[arParms.Length - 1].Value).ToString();
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
    }
}
