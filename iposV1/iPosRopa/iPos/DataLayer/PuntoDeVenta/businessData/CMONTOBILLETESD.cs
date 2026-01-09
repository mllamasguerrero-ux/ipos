

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


    public class CMONTOBILLETESD
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
        public CMONTOBILLETESBE AgregarMONTOBILLETESD(CMONTOBILLETESBE oCMONTOBILLETES, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCMONTOBILLETES.isnull["IID"])
                {
                    auxPar.Value = oCMONTOBILLETES.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCMONTOBILLETES.isnull["IACTIVO"])
                {
                    auxPar.Value = oCMONTOBILLETES.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMONTOBILLETES.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCMONTOBILLETES.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMONTOBILLETES.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCMONTOBILLETES.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CORTEID", FbDbType.BigInt);
                if (!(bool)oCMONTOBILLETES.isnull["ICORTEID"])
                {
                    auxPar.Value = oCMONTOBILLETES.ICORTEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPODECAMBIO", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["ITIPODECAMBIO"])
                {
                    auxPar.Value = oCMONTOBILLETES.ITIPODECAMBIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@P1000", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["IP1000"])
                {
                    auxPar.Value = oCMONTOBILLETES.IP1000;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@P500", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["IP500"])
                {
                    auxPar.Value = oCMONTOBILLETES.IP500;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@P200", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["IP200"])
                {
                    auxPar.Value = oCMONTOBILLETES.IP200;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@P100", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["IP100"])
                {
                    auxPar.Value = oCMONTOBILLETES.IP100;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@P50", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["IP50"])
                {
                    auxPar.Value = oCMONTOBILLETES.IP50;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@P20", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["IP20"])
                {
                    auxPar.Value = oCMONTOBILLETES.IP20;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@D100", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["ID100"])
                {
                    auxPar.Value = oCMONTOBILLETES.ID100;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@D50", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["ID50"])
                {
                    auxPar.Value = oCMONTOBILLETES.ID50;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@D20", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["ID20"])
                {
                    auxPar.Value = oCMONTOBILLETES.ID20;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@D10", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["ID10"])
                {
                    auxPar.Value = oCMONTOBILLETES.ID10;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@D5", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["ID5"])
                {
                    auxPar.Value = oCMONTOBILLETES.ID5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@D2", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["ID2"])
                {
                    auxPar.Value = oCMONTOBILLETES.ID2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@D1", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["ID1"])
                {
                    auxPar.Value = oCMONTOBILLETES.ID1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MORRALLAPESOS", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["IMORRALLAPESOS"])
                {
                    auxPar.Value = oCMONTOBILLETES.IMORRALLAPESOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MORRALLADOLARES", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["IMORRALLADOLARES"])
                {
                    auxPar.Value = oCMONTOBILLETES.IMORRALLADOLARES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MORRALLADEDOLARENPESOS", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["IMORRALLADEDOLARENPESOS"])
                {
                    auxPar.Value = oCMONTOBILLETES.IMORRALLADEDOLARENPESOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SALDOFINAL", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["ISALDOFINAL"])
                {
                    auxPar.Value = oCMONTOBILLETES.ISALDOFINAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CHEQUES", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["ICHEQUES"])
                {
                    auxPar.Value = oCMONTOBILLETES.ICHEQUES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VALES", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["IVALES"])
                {
                    auxPar.Value = oCMONTOBILLETES.IVALES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TARJETA", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["ITARJETA"])
                {
                    auxPar.Value = oCMONTOBILLETES.ITARJETA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREDITO", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["ICREDITO"])
                {
                    auxPar.Value = oCMONTOBILLETES.ICREDITO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONEDERO", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["IMONEDERO"])
                {
                    auxPar.Value = oCMONTOBILLETES.IMONEDERO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@TIPOMONTOBILLETESID", FbDbType.BigInt);
                if (!(bool)oCMONTOBILLETES.isnull["ITIPOMONTOBILLETESID"])
                {
                    auxPar.Value = oCMONTOBILLETES.ITIPOMONTOBILLETESID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if (!(bool)oCMONTOBILLETES.isnull["IDOCTOID"])
                {
                    auxPar.Value = oCMONTOBILLETES.IDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                

                auxPar = new FbParameter("@DEPOSITO", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["IDEPOSITO"])
                {
                    auxPar.Value = oCMONTOBILLETES.IDEPOSITO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DEPTERCERO", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["IDEPTERCERO"])
                {
                    auxPar.Value = oCMONTOBILLETES.IDEPTERCERO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
        INSERT INTO MONTOBILLETES
      (
    
ID,

ACTIVO,

CREADO,

CREADOPOR_USERID,

MODIFICADO,

MODIFICADOPOR_USERID,

CORTEID,

TIPODECAMBIO,

P1000,

P500,

P200,

P100,

P50,

P20,

D100,

D50,

D20,

D10,

D5,

D2,

D1,

MORRALLAPESOS,

MORRALLADOLARES,

MORRALLADEDOLARENPESOS,

SALDOFINAL,

CHEQUES,

VALES,

TARJETA,

CREDITO,

MONEDERO,

TIPOMONTOBILLETESID,

DOCTOID,

DEPOSITO,

DEPTERCERO
         )

Values (

@ID,

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@CORTEID,

@TIPODECAMBIO,

@P1000,

@P500,

@P200,

@P100,

@P50,

@P20,

@D100,

@D50,

@D20,

@D10,

@D5,

@D2,

@D1,

@MORRALLAPESOS,

@MORRALLADOLARES,

@MORRALLADEDOLARENPESOS,

@SALDOFINAL,

@CHEQUES,

@VALES,

@TARJETA,

@CREDITO,

@MONEDERO,

@TIPOMONTOBILLETESID,

@DOCTOID,

@DEPOSITO,

@DEPTERCERO
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCMONTOBILLETES;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarMONTOBILLETESD(CMONTOBILLETESBE oCMONTOBILLETES, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMONTOBILLETES.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from MONTOBILLETES
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
        public bool CambiarMONTOBILLETESD(CMONTOBILLETESBE oCMONTOBILLETESNuevo, CMONTOBILLETESBE oCMONTOBILLETESAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCMONTOBILLETESNuevo.isnull["IID"])
                {
                    auxPar.Value = oCMONTOBILLETESNuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCMONTOBILLETESNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCMONTOBILLETESNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMONTOBILLETESNuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCMONTOBILLETESNuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMONTOBILLETESNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCMONTOBILLETESNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CORTEID", FbDbType.BigInt);
                if (!(bool)oCMONTOBILLETESNuevo.isnull["ICORTEID"])
                {
                    auxPar.Value = oCMONTOBILLETESNuevo.ICORTEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPODECAMBIO", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETESNuevo.isnull["ITIPODECAMBIO"])
                {
                    auxPar.Value = oCMONTOBILLETESNuevo.ITIPODECAMBIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@P1000", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETESNuevo.isnull["IP1000"])
                {
                    auxPar.Value = oCMONTOBILLETESNuevo.IP1000;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@P500", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETESNuevo.isnull["IP500"])
                {
                    auxPar.Value = oCMONTOBILLETESNuevo.IP500;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@P200", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETESNuevo.isnull["IP200"])
                {
                    auxPar.Value = oCMONTOBILLETESNuevo.IP200;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@P100", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETESNuevo.isnull["IP100"])
                {
                    auxPar.Value = oCMONTOBILLETESNuevo.IP100;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@P50", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETESNuevo.isnull["IP50"])
                {
                    auxPar.Value = oCMONTOBILLETESNuevo.IP50;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@P20", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETESNuevo.isnull["IP20"])
                {
                    auxPar.Value = oCMONTOBILLETESNuevo.IP20;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@D100", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETESNuevo.isnull["ID100"])
                {
                    auxPar.Value = oCMONTOBILLETESNuevo.ID100;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@D50", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETESNuevo.isnull["ID50"])
                {
                    auxPar.Value = oCMONTOBILLETESNuevo.ID50;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@D20", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETESNuevo.isnull["ID20"])
                {
                    auxPar.Value = oCMONTOBILLETESNuevo.ID20;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@D10", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETESNuevo.isnull["ID10"])
                {
                    auxPar.Value = oCMONTOBILLETESNuevo.ID10;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@D5", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETESNuevo.isnull["ID5"])
                {
                    auxPar.Value = oCMONTOBILLETESNuevo.ID5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@D2", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETESNuevo.isnull["ID2"])
                {
                    auxPar.Value = oCMONTOBILLETESNuevo.ID2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@D1", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETESNuevo.isnull["ID1"])
                {
                    auxPar.Value = oCMONTOBILLETESNuevo.ID1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MORRALLAPESOS", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETESNuevo.isnull["IMORRALLAPESOS"])
                {
                    auxPar.Value = oCMONTOBILLETESNuevo.IMORRALLAPESOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MORRALLADOLARES", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETESNuevo.isnull["IMORRALLADOLARES"])
                {
                    auxPar.Value = oCMONTOBILLETESNuevo.IMORRALLADOLARES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MORRALLADEDOLARENPESOS", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETESNuevo.isnull["IMORRALLADEDOLARENPESOS"])
                {
                    auxPar.Value = oCMONTOBILLETESNuevo.IMORRALLADEDOLARENPESOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SALDOFINAL", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETESNuevo.isnull["ISALDOFINAL"])
                {
                    auxPar.Value = oCMONTOBILLETESNuevo.ISALDOFINAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CHEQUES", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETESNuevo.isnull["ICHEQUES"])
                {
                    auxPar.Value = oCMONTOBILLETESNuevo.ICHEQUES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@VALES", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETESNuevo.isnull["IVALES"])
                {
                    auxPar.Value = oCMONTOBILLETESNuevo.IVALES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TARJETA", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETESNuevo.isnull["ITARJETA"])
                {
                    auxPar.Value = oCMONTOBILLETESNuevo.ITARJETA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREDITO", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETESNuevo.isnull["ICREDITO"])
                {
                    auxPar.Value = oCMONTOBILLETESNuevo.ICREDITO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONEDERO", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETESNuevo.isnull["IMONEDERO"])
                {
                    auxPar.Value = oCMONTOBILLETESNuevo.IMONEDERO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOMONTOBILLETESID", FbDbType.BigInt);
                if (!(bool)oCMONTOBILLETESNuevo.isnull["ITIPOMONTOBILLETESID"])
                {
                    auxPar.Value = oCMONTOBILLETESNuevo.ITIPOMONTOBILLETESID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if (!(bool)oCMONTOBILLETESNuevo.isnull["IDOCTOID"])
                {
                    auxPar.Value = oCMONTOBILLETESNuevo.IDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DEPOSITO", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETESNuevo.isnull["IDEPOSITO"])
                {
                    auxPar.Value = oCMONTOBILLETESNuevo.IDEPOSITO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DEPTERCERO", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETESNuevo.isnull["IDEPTERCERO"])
                {
                    auxPar.Value = oCMONTOBILLETESNuevo.IDEPTERCERO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCMONTOBILLETESAnterior.isnull["IID"])
                {
                    auxPar.Value = oCMONTOBILLETESAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  MONTOBILLETES
  set

ID=@ID,

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

CORTEID=@CORTEID,

TIPODECAMBIO=@TIPODECAMBIO,

P1000=@P1000,

P500=@P500,

P200=@P200,

P100=@P100,

P50=@P50,

P20=@P20,

D100=@D100,

D50=@D50,

D20=@D20,

D10=@D10,

D5=@D5,

D2=@D2,

D1=@D1,

MORRALLAPESOS=@MORRALLAPESOS,

MORRALLADOLARES=@MORRALLADOLARES,

MORRALLADEDOLARENPESOS=@MORRALLADEDOLARENPESOS,

SALDOFINAL=@SALDOFINAL,

CHEQUES=@CHEQUES,

VALES=@VALES,

TARJETA=@TARJETA,

CREDITO = @CREDITO,

MONEDERO = @MONEDERO,

TIPOMONTOBILLETESID = @TIPOMONTOBILLETESID,

DOCTOID = @DOCTOID,

DEPOSITO = @DEPOSITO,

DEPTERCERO = @DEPTERCERO

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
        public CMONTOBILLETESBE seleccionarMONTOBILLETES(CMONTOBILLETESBE oCMONTOBILLETES, FbTransaction st)
        {




            CMONTOBILLETESBE retorno = new CMONTOBILLETESBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from MONTOBILLETES where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMONTOBILLETES.IID;
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

                    if (dr["CORTEID"] != System.DBNull.Value)
                    {
                        retorno.ICORTEID = (long)(dr["CORTEID"]);
                    }

                    if (dr["TIPODECAMBIO"] != System.DBNull.Value)
                    {
                        retorno.ITIPODECAMBIO = (decimal)(dr["TIPODECAMBIO"]);
                    }

                    if (dr["P1000"] != System.DBNull.Value)
                    {
                        retorno.IP1000 = (decimal)(dr["P1000"]);
                    }

                    if (dr["P500"] != System.DBNull.Value)
                    {
                        retorno.IP500 = (decimal)(dr["P500"]);
                    }

                    if (dr["P200"] != System.DBNull.Value)
                    {
                        retorno.IP200 = (decimal)(dr["P200"]);
                    }

                    if (dr["P100"] != System.DBNull.Value)
                    {
                        retorno.IP100 = (decimal)(dr["P100"]);
                    }

                    if (dr["P50"] != System.DBNull.Value)
                    {
                        retorno.IP50 = (decimal)(dr["P50"]);
                    }

                    if (dr["P20"] != System.DBNull.Value)
                    {
                        retorno.IP20 = (decimal)(dr["P20"]);
                    }

                    if (dr["D100"] != System.DBNull.Value)
                    {
                        retorno.ID100 = (decimal)(dr["D100"]);
                    }

                    if (dr["D50"] != System.DBNull.Value)
                    {
                        retorno.ID50 = (decimal)(dr["D50"]);
                    }

                    if (dr["D20"] != System.DBNull.Value)
                    {
                        retorno.ID20 = (decimal)(dr["D20"]);
                    }

                    if (dr["D10"] != System.DBNull.Value)
                    {
                        retorno.ID10 = (decimal)(dr["D10"]);
                    }

                    if (dr["D5"] != System.DBNull.Value)
                    {
                        retorno.ID5 = (decimal)(dr["D5"]);
                    }

                    if (dr["D2"] != System.DBNull.Value)
                    {
                        retorno.ID2 = (decimal)(dr["D2"]);
                    }

                    if (dr["D1"] != System.DBNull.Value)
                    {
                        retorno.ID1 = (decimal)(dr["D1"]);
                    }

                    if (dr["MORRALLAPESOS"] != System.DBNull.Value)
                    {
                        retorno.IMORRALLAPESOS = (decimal)(dr["MORRALLAPESOS"]);
                    }

                    if (dr["MORRALLADOLARES"] != System.DBNull.Value)
                    {
                        retorno.IMORRALLADOLARES = (decimal)(dr["MORRALLADOLARES"]);
                    }

                    if (dr["MORRALLADEDOLARENPESOS"] != System.DBNull.Value)
                    {
                        retorno.IMORRALLADEDOLARENPESOS = (decimal)(dr["MORRALLADEDOLARENPESOS"]);
                    }

                    if (dr["SALDOFINAL"] != System.DBNull.Value)
                    {
                        retorno.ISALDOFINAL = (decimal)(dr["SALDOFINAL"]);
                    }

                    if (dr["CHEQUES"] != System.DBNull.Value)
                    {
                        retorno.ICHEQUES = (decimal)(dr["CHEQUES"]);
                    }

                    if (dr["VALES"] != System.DBNull.Value)
                    {
                        retorno.IVALES = (decimal)(dr["VALES"]);
                    }

                    if (dr["TARJETA"] != System.DBNull.Value)
                    {
                        retorno.ITARJETA = (decimal)(dr["TARJETA"]);
                    }


                    if (dr["CREDITO"] != System.DBNull.Value)
                    {
                        retorno.ICREDITO = (decimal)(dr["CREDITO"]);
                    }

                    if (dr["MONEDERO"] != System.DBNull.Value)
                    {
                        retorno.IMONEDERO = (decimal)(dr["MONEDERO"]);
                    }

                    if (dr["TRANSFERENCIA"] != System.DBNull.Value)
                    {
                        retorno.ITRANSFERENCIA = (decimal)(dr["TRANSFERENCIA"]);
                    }

                    if (dr["INDEFINIDO"] != System.DBNull.Value)
                    {
                        retorno.IINDEFINIDO = (decimal)(dr["INDEFINIDO"]);
                    }


                    if (dr["TIPOMONTOBILLETESID"] != System.DBNull.Value)
                    {
                        retorno.ITIPOMONTOBILLETESID = (long)(dr["TIPOMONTOBILLETESID"]);
                    }



                    if (dr["DOCTOID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOID = (long)(dr["DOCTOID"]);
                    }


                    if (dr["DEPOSITO"] != System.DBNull.Value)
                    {
                        retorno.IDEPOSITO = (decimal)(dr["DEPOSITO"]);
                    }


                    if (dr["DEPTERCERO"] != System.DBNull.Value)
                    {
                        retorno.IDEPTERCERO = (decimal)(dr["DEPTERCERO"]);
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
        public DataSet enlistarMONTOBILLETES()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_MONTOBILLETES_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoMONTOBILLETES()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_MONTOBILLETES_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteMONTOBILLETES(CMONTOBILLETESBE oCMONTOBILLETES, FbTransaction st)
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
                auxPar.Value = oCMONTOBILLETES.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from MONTOBILLETES where

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




        public CMONTOBILLETESBE AgregarMONTOBILLETES(CMONTOBILLETESBE oCMONTOBILLETES, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMONTOBILLETES(oCMONTOBILLETES, st);
                if (iRes == 1)
                {
                    this.IComentario = "El MONTOBILLETES ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarMONTOBILLETESD(oCMONTOBILLETES, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarMONTOBILLETES(CMONTOBILLETESBE oCMONTOBILLETES, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMONTOBILLETES(oCMONTOBILLETES, st);
                if (iRes == 0)
                {
                    this.IComentario = "El MONTOBILLETES no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarMONTOBILLETESD(oCMONTOBILLETES, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarMONTOBILLETES(CMONTOBILLETESBE oCMONTOBILLETESNuevo, CMONTOBILLETESBE oCMONTOBILLETESAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMONTOBILLETES(oCMONTOBILLETESAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El MONTOBILLETES no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarMONTOBILLETESD(oCMONTOBILLETESNuevo, oCMONTOBILLETESAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }



        public bool CORTE_MONTOBILLETES_UPDATE(CMONTOBILLETESBE oCMONTOBILLETES, FbTransaction st, ref long montoBilletesId, decimal fondoDinamicoFinal)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@CORTEID", FbDbType.BigInt);
                if (!(bool)oCMONTOBILLETES.isnull["ICORTEID"])
                {
                    auxPar.Value = oCMONTOBILLETES.ICORTEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPODECAMBIO", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["ITIPODECAMBIO"])
                {
                    auxPar.Value = oCMONTOBILLETES.ITIPODECAMBIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@P1000", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["IP1000"])
                {
                    auxPar.Value = oCMONTOBILLETES.IP1000;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@P500", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["IP500"])
                {
                    auxPar.Value = oCMONTOBILLETES.IP500;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@P200", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["IP200"])
                {
                    auxPar.Value = oCMONTOBILLETES.IP200;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@P100", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["IP100"])
                {
                    auxPar.Value = oCMONTOBILLETES.IP100;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@P50", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["IP50"])
                {
                    auxPar.Value = oCMONTOBILLETES.IP50;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@P20", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["IP20"])
                {
                    auxPar.Value = oCMONTOBILLETES.IP20;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@D100", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["ID100"])
                {
                    auxPar.Value = oCMONTOBILLETES.ID100;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@D50", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["ID50"])
                {
                    auxPar.Value = oCMONTOBILLETES.ID50;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@D20", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["ID20"])
                {
                    auxPar.Value = oCMONTOBILLETES.ID20;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@D10", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["ID10"])
                {
                    auxPar.Value = oCMONTOBILLETES.ID10;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@D5", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["ID5"])
                {
                    auxPar.Value = oCMONTOBILLETES.ID5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@D2", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["ID2"])
                {
                    auxPar.Value = oCMONTOBILLETES.ID2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@D1", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["ID1"])
                {
                    auxPar.Value = oCMONTOBILLETES.ID1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MORRALLAPESOS", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["IMORRALLAPESOS"])
                {
                    auxPar.Value = oCMONTOBILLETES.IMORRALLAPESOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MORRALLADOLARES", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["IMORRALLADOLARES"])
                {
                    auxPar.Value = oCMONTOBILLETES.IMORRALLADOLARES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MORRALLADEDOLARENPESOS", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["IMORRALLADEDOLARENPESOS"])
                {
                    auxPar.Value = oCMONTOBILLETES.IMORRALLADEDOLARENPESOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SALDOFINAL", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["ISALDOFINAL"])
                {
                    auxPar.Value = oCMONTOBILLETES.ISALDOFINAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CHEQUES", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["ICHEQUES"])
                {
                    auxPar.Value = oCMONTOBILLETES.ICHEQUES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VALES", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["IVALES"])
                {
                    auxPar.Value = oCMONTOBILLETES.IVALES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TARJETA", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["ITARJETA"])
                {
                    auxPar.Value = oCMONTOBILLETES.ITARJETA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREDITO", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["ICREDITO"])
                {
                    auxPar.Value = oCMONTOBILLETES.ICREDITO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONEDERO", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["IMONEDERO"])
                {
                    auxPar.Value = oCMONTOBILLETES.IMONEDERO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TRANSFERENCIA", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["ITRANSFERENCIA"])
                {
                    auxPar.Value = oCMONTOBILLETES.ITRANSFERENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@INDEFINIDO", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["IINDEFINIDO"])
                {
                    auxPar.Value = oCMONTOBILLETES.IINDEFINIDO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@TIPOMONTOBILLETESID", FbDbType.BigInt);
                if (!(bool)oCMONTOBILLETES.isnull["ITIPOMONTOBILLETESID"])
                {
                    auxPar.Value = oCMONTOBILLETES.ITIPOMONTOBILLETESID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if (!(bool)oCMONTOBILLETES.isnull["IDOCTOID"])
                {
                    auxPar.Value = oCMONTOBILLETES.IDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@DEPOSITO", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["IDEPOSITO"])
                {
                    auxPar.Value = oCMONTOBILLETES.IDEPOSITO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@DEPTERCERO", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETES.isnull["IDEPTERCERO"])
                {
                    auxPar.Value = oCMONTOBILLETES.IDEPTERCERO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@FONDODINAMICOFINAL", FbDbType.Numeric);
                auxPar.Value = fondoDinamicoFinal;
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONTO_BILLETES_ID", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);



                string commandText = @"CORTE_MONTOBILLETES_UPDATE";

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
                        this.iComentario = "Hubo un error " + ((int)arParms[arParms.Length - 1].Value).ToString();
                        return false;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    montoBilletesId = (long)arParms[arParms.Length - 2].Value;
                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public CMONTOBILLETESBE seleccionarMONTOBILLETESxCorte(CMONTOBILLETESBE oCMONTOBILLETES, FbTransaction st)
        {




            CMONTOBILLETESBE retorno = new CMONTOBILLETESBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from MONTOBILLETES where CORTEID=@CORTEID  ";



                auxPar = new FbParameter("@CORTEID", FbDbType.BigInt);
                auxPar.Value = oCMONTOBILLETES.ICORTEID;
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

                    if (dr["CORTEID"] != System.DBNull.Value)
                    {
                        retorno.ICORTEID = (long)(dr["CORTEID"]);
                    }

                    if (dr["TIPODECAMBIO"] != System.DBNull.Value)
                    {
                        retorno.ITIPODECAMBIO = (decimal)(dr["TIPODECAMBIO"]);
                    }

                    if (dr["P1000"] != System.DBNull.Value)
                    {
                        retorno.IP1000 = (decimal)(dr["P1000"]);
                    }

                    if (dr["P500"] != System.DBNull.Value)
                    {
                        retorno.IP500 = (decimal)(dr["P500"]);
                    }

                    if (dr["P200"] != System.DBNull.Value)
                    {
                        retorno.IP200 = (decimal)(dr["P200"]);
                    }

                    if (dr["P100"] != System.DBNull.Value)
                    {
                        retorno.IP100 = (decimal)(dr["P100"]);
                    }

                    if (dr["P50"] != System.DBNull.Value)
                    {
                        retorno.IP50 = (decimal)(dr["P50"]);
                    }

                    if (dr["P20"] != System.DBNull.Value)
                    {
                        retorno.IP20 = (decimal)(dr["P20"]);
                    }

                    if (dr["D100"] != System.DBNull.Value)
                    {
                        retorno.ID100 = (decimal)(dr["D100"]);
                    }

                    if (dr["D50"] != System.DBNull.Value)
                    {
                        retorno.ID50 = (decimal)(dr["D50"]);
                    }

                    if (dr["D20"] != System.DBNull.Value)
                    {
                        retorno.ID20 = (decimal)(dr["D20"]);
                    }

                    if (dr["D10"] != System.DBNull.Value)
                    {
                        retorno.ID10 = (decimal)(dr["D10"]);
                    }

                    if (dr["D5"] != System.DBNull.Value)
                    {
                        retorno.ID5 = (decimal)(dr["D5"]);
                    }

                    if (dr["D2"] != System.DBNull.Value)
                    {
                        retorno.ID2 = (decimal)(dr["D2"]);
                    }

                    if (dr["D1"] != System.DBNull.Value)
                    {
                        retorno.ID1 = (decimal)(dr["D1"]);
                    }

                    if (dr["MORRALLAPESOS"] != System.DBNull.Value)
                    {
                        retorno.IMORRALLAPESOS = (decimal)(dr["MORRALLAPESOS"]);
                    }

                    if (dr["MORRALLADOLARES"] != System.DBNull.Value)
                    {
                        retorno.IMORRALLADOLARES = (decimal)(dr["MORRALLADOLARES"]);
                    }

                    if (dr["MORRALLADEDOLARENPESOS"] != System.DBNull.Value)
                    {
                        retorno.IMORRALLADEDOLARENPESOS = (decimal)(dr["MORRALLADEDOLARENPESOS"]);
                    }

                    if (dr["SALDOFINAL"] != System.DBNull.Value)
                    {
                        retorno.ISALDOFINAL = (decimal)(dr["SALDOFINAL"]);
                    }

                    if (dr["CHEQUES"] != System.DBNull.Value)
                    {
                        retorno.ICHEQUES = (decimal)(dr["CHEQUES"]);
                    }

                    if (dr["VALES"] != System.DBNull.Value)
                    {
                        retorno.IVALES = (decimal)(dr["VALES"]);
                    }

                    if (dr["TARJETA"] != System.DBNull.Value)
                    {
                        retorno.ITARJETA = (decimal)(dr["TARJETA"]);
                    }

                    if (dr["CREDITO"] != System.DBNull.Value)
                    {
                        retorno.ICREDITO = (decimal)(dr["CREDITO"]);
                    }
                    if (dr["MONEDERO"] != System.DBNull.Value)
                    {
                        retorno.IMONEDERO = (decimal)(dr["MONEDERO"]);
                    }

                    if (dr["TRANSFERENCIA"] != System.DBNull.Value)
                    {
                        retorno.ITRANSFERENCIA = (decimal)(dr["TRANSFERENCIA"]);
                    }

                    if (dr["INDEFINIDO"] != System.DBNull.Value)
                    {
                        retorno.IINDEFINIDO = (decimal)(dr["INDEFINIDO"]);
                    }


                    if (dr["TIPOMONTOBILLETESID"] != System.DBNull.Value)
                    {
                        retorno.ITIPOMONTOBILLETESID = (long)(dr["TIPOMONTOBILLETESID"]);
                    }



                    if (dr["DOCTOID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOID = (long)(dr["DOCTOID"]);
                    }

                    if (dr["DEPOSITO"] != System.DBNull.Value)
                    {
                        retorno.IDEPOSITO = (decimal)(dr["DEPOSITO"]);
                    }


                    if (dr["DEPTERCERO"] != System.DBNull.Value)
                    {
                        retorno.IDEPTERCERO = (decimal)(dr["DEPTERCERO"]);
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





        public CMONTOBILLETESBE seleccionarMONTOBILLETESxDoctoId(CMONTOBILLETESBE oCMONTOBILLETES, FbTransaction st)
        {




            CMONTOBILLETESBE retorno = new CMONTOBILLETESBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from MONTOBILLETES where DOCTOID=@DOCTOID  ";



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCMONTOBILLETES.IDOCTOID;
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

                    if (dr["CORTEID"] != System.DBNull.Value)
                    {
                        retorno.ICORTEID = (long)(dr["CORTEID"]);
                    }

                    if (dr["TIPODECAMBIO"] != System.DBNull.Value)
                    {
                        retorno.ITIPODECAMBIO = (decimal)(dr["TIPODECAMBIO"]);
                    }

                    if (dr["P1000"] != System.DBNull.Value)
                    {
                        retorno.IP1000 = (decimal)(dr["P1000"]);
                    }

                    if (dr["P500"] != System.DBNull.Value)
                    {
                        retorno.IP500 = (decimal)(dr["P500"]);
                    }

                    if (dr["P200"] != System.DBNull.Value)
                    {
                        retorno.IP200 = (decimal)(dr["P200"]);
                    }

                    if (dr["P100"] != System.DBNull.Value)
                    {
                        retorno.IP100 = (decimal)(dr["P100"]);
                    }

                    if (dr["P50"] != System.DBNull.Value)
                    {
                        retorno.IP50 = (decimal)(dr["P50"]);
                    }

                    if (dr["P20"] != System.DBNull.Value)
                    {
                        retorno.IP20 = (decimal)(dr["P20"]);
                    }

                    if (dr["D100"] != System.DBNull.Value)
                    {
                        retorno.ID100 = (decimal)(dr["D100"]);
                    }

                    if (dr["D50"] != System.DBNull.Value)
                    {
                        retorno.ID50 = (decimal)(dr["D50"]);
                    }

                    if (dr["D20"] != System.DBNull.Value)
                    {
                        retorno.ID20 = (decimal)(dr["D20"]);
                    }

                    if (dr["D10"] != System.DBNull.Value)
                    {
                        retorno.ID10 = (decimal)(dr["D10"]);
                    }

                    if (dr["D5"] != System.DBNull.Value)
                    {
                        retorno.ID5 = (decimal)(dr["D5"]);
                    }

                    if (dr["D2"] != System.DBNull.Value)
                    {
                        retorno.ID2 = (decimal)(dr["D2"]);
                    }

                    if (dr["D1"] != System.DBNull.Value)
                    {
                        retorno.ID1 = (decimal)(dr["D1"]);
                    }

                    if (dr["MORRALLAPESOS"] != System.DBNull.Value)
                    {
                        retorno.IMORRALLAPESOS = (decimal)(dr["MORRALLAPESOS"]);
                    }

                    if (dr["MORRALLADOLARES"] != System.DBNull.Value)
                    {
                        retorno.IMORRALLADOLARES = (decimal)(dr["MORRALLADOLARES"]);
                    }

                    if (dr["MORRALLADEDOLARENPESOS"] != System.DBNull.Value)
                    {
                        retorno.IMORRALLADEDOLARENPESOS = (decimal)(dr["MORRALLADEDOLARENPESOS"]);
                    }

                    if (dr["SALDOFINAL"] != System.DBNull.Value)
                    {
                        retorno.ISALDOFINAL = (decimal)(dr["SALDOFINAL"]);
                    }

                    if (dr["CHEQUES"] != System.DBNull.Value)
                    {
                        retorno.ICHEQUES = (decimal)(dr["CHEQUES"]);
                    }

                    if (dr["VALES"] != System.DBNull.Value)
                    {
                        retorno.IVALES = (decimal)(dr["VALES"]);
                    }

                    if (dr["TARJETA"] != System.DBNull.Value)
                    {
                        retorno.ITARJETA = (decimal)(dr["TARJETA"]);
                    }

                    if (dr["CREDITO"] != System.DBNull.Value)
                    {
                        retorno.ICREDITO = (decimal)(dr["CREDITO"]);
                    }
                    if (dr["MONEDERO"] != System.DBNull.Value)
                    {
                        retorno.IMONEDERO = (decimal)(dr["MONEDERO"]);
                    }

                    if (dr["TRANSFERENCIA"] != System.DBNull.Value)
                    {
                        retorno.ITRANSFERENCIA = (decimal)(dr["TRANSFERENCIA"]);
                    }

                    if (dr["INDEFINIDO"] != System.DBNull.Value)
                    {
                        retorno.IINDEFINIDO = (decimal)(dr["INDEFINIDO"]);
                    }


                    if (dr["TIPOMONTOBILLETESID"] != System.DBNull.Value)
                    {
                        retorno.ITIPOMONTOBILLETESID = (long)(dr["TIPOMONTOBILLETESID"]);
                    }



                    if (dr["DOCTOID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOID = (long)(dr["DOCTOID"]);
                    }


                    if (dr["DEPOSITO"] != System.DBNull.Value)
                    {
                        retorno.IDEPOSITO = (decimal)(dr["DEPOSITO"]);
                    }


                    if (dr["DEPTERCERO"] != System.DBNull.Value)
                    {
                        retorno.IDEPTERCERO = (decimal)(dr["DEPTERCERO"]);
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



        public CMONTOBILLETESD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
