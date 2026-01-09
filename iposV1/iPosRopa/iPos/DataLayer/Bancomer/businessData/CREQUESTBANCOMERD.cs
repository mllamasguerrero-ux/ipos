

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

    


    public class CREQUESTBANCOMERD
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


       
        public CREQUESTBANCOMERBE AgregarREQUESTBANCOMERD(CREQUESTBANCOMERBE oCREQUESTBANCOMER, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCREQUESTBANCOMER.isnull["IID"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCREQUESTBANCOMER.isnull["IACTIVO"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCREQUESTBANCOMER.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCREQUESTBANCOMER.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ISSINTJROPERADOR", FbDbType.Char);
                if (!(bool)oCREQUESTBANCOMER.isnull["IISSINTJROPERADOR"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.IISSINTJROPERADOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMAUTORIZACION", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["INOMAUTORIZACION"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.INOMAUTORIZACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["INOMBRE"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PAN", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["IPAN"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.IPAN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TOPERADOR", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["ITOPERADOR"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.ITOPERADOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CODTRANSACTION", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["ICODTRANSACTION"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.ICODTRANSACTION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TERMINAL", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["ITERMINAL"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.ITERMINAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SESSION", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["ISESSION"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.ISESSION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SECUENCIA", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["ISECUENCIA"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.ISECUENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPORTE", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PROPINA", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["IPROPINA"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.IPROPINA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FOLIO", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["IFOLIO"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.IFOLIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAPEMV", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["ICAPEMV"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.ICAPEMV;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOLECTOR", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["ITIPOLECTOR"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.ITIPOLECTOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAPCVV2", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["ICAPCVV2"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.ICAPCVV2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MESESFIN", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["IMESESFIN"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.IMESESFIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PARCIALIZACION", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["IPARCIALIZACION"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.IPARCIALIZACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PROMOCIONES", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["IPROMOCIONES"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.IPROMOCIONES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOMONEDA", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["ITIPOMONEDA"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.ITIPOMONEDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOAUTORIZACION", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["INOAUTORIZACION"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.INOAUTORIZACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODOINGRESO", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["IMODOINGRESO"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.IMODOINGRESO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CVV2", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["ICVV2"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.ICVV2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TRACK2", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["ITRACK2"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.ITRACK2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOSECUENCIA", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["INOSECUENCIA"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.INOSECUENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPORTECASH", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["IIMPORTECASH"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.IIMPORTECASH;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAHORACOMERCIO", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["IFECHAHORACOMERCIO"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.IFECHAHORACOMERCIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIACOMERCIO", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["IREFERENCIACOMERCIO"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.IREFERENCIACOMERCIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@OTROIMPORTE", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["IOTROIMPORTE"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.IOTROIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVEOPERADOR", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["ICLAVEOPERADOR"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.ICLAVEOPERADOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@AFILIACION", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["IAFILIACION"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.IAFILIACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUMEROCUARTO", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["INUMEROCUARTO"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.INUMEROCUARTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIAFINANCIERA", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["IREFERENCIAFINANCIERA"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.IREFERENCIAFINANCIERA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CODIGOCONDCHIP", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["ICODIGOCONDCHIP"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.ICODIGOCONDCHIP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LONGEMVFULL", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["ILONGEMVFULL"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.ILONGEMVFULL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DATOSEMVFULL", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["IDATOSEMVFULL"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.IDATOSEMVFULL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LONGLEALTAD", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["ILONGLEALTAD"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.ILONGLEALTAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DATOSLEALTAD", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["IDATOSLEALTAD"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.IDATOSLEALTAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LONGMULTIPAGOS", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["ILONGMULTIPAGOS"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.ILONGMULTIPAGOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DATOSMULTIPAGOS", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["IDATOSMULTIPAGOS"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.IDATOSMULTIPAGOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LONGDATOSCIFRADOS", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["ILONGDATOSCIFRADOS"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.ILONGDATOSCIFRADOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DATOSCIFRADOS", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["IDATOSCIFRADOS"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.IDATOSCIFRADOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LONGCAMPANA", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["ILONGCAMPANA"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.ILONGCAMPANA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DATOSCAMPANA", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["IDATOSCAMPANA"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.IDATOSCAMPANA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CONVENIOCIE", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["ICONVENIOCIE"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.ICONVENIOCIE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VERSION", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMER.isnull["IVERSION"])
                {
                    auxPar.Value = oCREQUESTBANCOMER.IVERSION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO REQUESTBANCOMER
      (
    
ID,

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

ISSINTJROPERADOR,

NOMAUTORIZACION,

NOMBRE,

PAN,

TOPERADOR,

CODTRANSACTION,

TERMINAL,

SESSION,

SECUENCIA,

IMPORTE,

PROPINA,

FOLIO,

CAPEMV,

TIPOLECTOR,

CAPCVV2,

MESESFIN,

PARCIALIZACION,

PROMOCIONES,

TIPOMONEDA,

NOAUTORIZACION,

MODOINGRESO,

CVV2,

TRACK2,

NOSECUENCIA,

IMPORTECASH,

FECHAHORACOMERCIO,

REFERENCIACOMERCIO,

OTROIMPORTE,

CLAVEOPERADOR,

AFILIACION,

NUMEROCUARTO,

REFERENCIAFINANCIERA,

CODIGOCONDCHIP,

LONGEMVFULL,

DATOSEMVFULL,

LONGLEALTAD,

DATOSLEALTAD,

LONGMULTIPAGOS,

DATOSMULTIPAGOS,

LONGDATOSCIFRADOS,

DATOSCIFRADOS,

LONGCAMPANA,

DATOSCAMPANA,

CONVENIOCIE,

VERSION
         )

Values (

@ID,

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@ISSINTJROPERADOR,

@NOMAUTORIZACION,

@NOMBRE,

@PAN,

@TOPERADOR,

@CODTRANSACTION,

@TERMINAL,

@SESSION,

@SECUENCIA,

@IMPORTE,

@PROPINA,

@FOLIO,

@CAPEMV,

@TIPOLECTOR,

@CAPCVV2,

@MESESFIN,

@PARCIALIZACION,

@PROMOCIONES,

@TIPOMONEDA,

@NOAUTORIZACION,

@MODOINGRESO,

@CVV2,

@TRACK2,

@NOSECUENCIA,

@IMPORTECASH,

@FECHAHORACOMERCIO,

@REFERENCIACOMERCIO,

@OTROIMPORTE,

@CLAVEOPERADOR,

@AFILIACION,

@NUMEROCUARTO,

@REFERENCIAFINANCIERA,

@CODIGOCONDCHIP,

@LONGEMVFULL,

@DATOSEMVFULL,

@LONGLEALTAD,

@DATOSLEALTAD,

@LONGMULTIPAGOS,

@DATOSMULTIPAGOS,

@LONGDATOSCIFRADOS,

@DATOSCIFRADOS,

@LONGCAMPANA,

@DATOSCAMPANA,

@CONVENIOCIE,

@VERSION
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCREQUESTBANCOMER;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        
        public bool BorrarREQUESTBANCOMERD(CREQUESTBANCOMERBE oCREQUESTBANCOMER, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCREQUESTBANCOMER.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from REQUESTBANCOMER
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


        
        public bool CambiarREQUESTBANCOMERD(CREQUESTBANCOMERBE oCREQUESTBANCOMERNuevo, CREQUESTBANCOMERBE oCREQUESTBANCOMERAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["IID"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ISSINTJROPERADOR", FbDbType.Char);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["IISSINTJROPERADOR"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.IISSINTJROPERADOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMAUTORIZACION", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["INOMAUTORIZACION"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.INOMAUTORIZACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["INOMBRE"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PAN", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["IPAN"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.IPAN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TOPERADOR", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["ITOPERADOR"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.ITOPERADOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CODTRANSACTION", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["ICODTRANSACTION"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.ICODTRANSACTION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TERMINAL", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["ITERMINAL"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.ITERMINAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SESSION", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["ISESSION"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.ISESSION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SECUENCIA", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["ISECUENCIA"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.ISECUENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IMPORTE", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PROPINA", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["IPROPINA"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.IPROPINA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FOLIO", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["IFOLIO"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.IFOLIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAPEMV", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["ICAPEMV"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.ICAPEMV;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPOLECTOR", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["ITIPOLECTOR"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.ITIPOLECTOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAPCVV2", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["ICAPCVV2"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.ICAPCVV2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MESESFIN", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["IMESESFIN"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.IMESESFIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PARCIALIZACION", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["IPARCIALIZACION"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.IPARCIALIZACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PROMOCIONES", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["IPROMOCIONES"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.IPROMOCIONES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPOMONEDA", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["ITIPOMONEDA"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.ITIPOMONEDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOAUTORIZACION", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["INOAUTORIZACION"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.INOAUTORIZACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODOINGRESO", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["IMODOINGRESO"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.IMODOINGRESO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CVV2", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["ICVV2"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.ICVV2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TRACK2", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["ITRACK2"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.ITRACK2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOSECUENCIA", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["INOSECUENCIA"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.INOSECUENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IMPORTECASH", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["IIMPORTECASH"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.IIMPORTECASH;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAHORACOMERCIO", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["IFECHAHORACOMERCIO"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.IFECHAHORACOMERCIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@REFERENCIACOMERCIO", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["IREFERENCIACOMERCIO"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.IREFERENCIACOMERCIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@OTROIMPORTE", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["IOTROIMPORTE"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.IOTROIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLAVEOPERADOR", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["ICLAVEOPERADOR"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.ICLAVEOPERADOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@AFILIACION", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["IAFILIACION"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.IAFILIACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMEROCUARTO", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["INUMEROCUARTO"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.INUMEROCUARTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@REFERENCIAFINANCIERA", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["IREFERENCIAFINANCIERA"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.IREFERENCIAFINANCIERA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CODIGOCONDCHIP", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["ICODIGOCONDCHIP"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.ICODIGOCONDCHIP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LONGEMVFULL", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["ILONGEMVFULL"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.ILONGEMVFULL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DATOSEMVFULL", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["IDATOSEMVFULL"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.IDATOSEMVFULL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LONGLEALTAD", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["ILONGLEALTAD"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.ILONGLEALTAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DATOSLEALTAD", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["IDATOSLEALTAD"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.IDATOSLEALTAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LONGMULTIPAGOS", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["ILONGMULTIPAGOS"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.ILONGMULTIPAGOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DATOSMULTIPAGOS", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["IDATOSMULTIPAGOS"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.IDATOSMULTIPAGOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LONGDATOSCIFRADOS", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["ILONGDATOSCIFRADOS"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.ILONGDATOSCIFRADOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DATOSCIFRADOS", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["IDATOSCIFRADOS"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.IDATOSCIFRADOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LONGCAMPANA", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["ILONGCAMPANA"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.ILONGCAMPANA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DATOSCAMPANA", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["IDATOSCAMPANA"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.IDATOSCAMPANA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CONVENIOCIE", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["ICONVENIOCIE"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.ICONVENIOCIE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@VERSION", FbDbType.VarChar);
                if (!(bool)oCREQUESTBANCOMERNuevo.isnull["IVERSION"])
                {
                    auxPar.Value = oCREQUESTBANCOMERNuevo.IVERSION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCREQUESTBANCOMERAnterior.isnull["IID"])
                {
                    auxPar.Value = oCREQUESTBANCOMERAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  REQUESTBANCOMER
  set

ID=@ID,

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

ISSINTJROPERADOR=@ISSINTJROPERADOR,

NOMAUTORIZACION=@NOMAUTORIZACION,

NOMBRE=@NOMBRE,

PAN=@PAN,

TOPERADOR=@TOPERADOR,

CODTRANSACTION=@CODTRANSACTION,

TERMINAL=@TERMINAL,

SESSION=@SESSION,

SECUENCIA=@SECUENCIA,

IMPORTE=@IMPORTE,

PROPINA=@PROPINA,

FOLIO=@FOLIO,

CAPEMV=@CAPEMV,

TIPOLECTOR=@TIPOLECTOR,

CAPCVV2=@CAPCVV2,

MESESFIN=@MESESFIN,

PARCIALIZACION=@PARCIALIZACION,

PROMOCIONES=@PROMOCIONES,

TIPOMONEDA=@TIPOMONEDA,

NOAUTORIZACION=@NOAUTORIZACION,

MODOINGRESO=@MODOINGRESO,

CVV2=@CVV2,

TRACK2=@TRACK2,

NOSECUENCIA=@NOSECUENCIA,

IMPORTECASH=@IMPORTECASH,

FECHAHORACOMERCIO=@FECHAHORACOMERCIO,

REFERENCIACOMERCIO=@REFERENCIACOMERCIO,

OTROIMPORTE=@OTROIMPORTE,

CLAVEOPERADOR=@CLAVEOPERADOR,

AFILIACION=@AFILIACION,

NUMEROCUARTO=@NUMEROCUARTO,

REFERENCIAFINANCIERA=@REFERENCIAFINANCIERA,

CODIGOCONDCHIP=@CODIGOCONDCHIP,

LONGEMVFULL=@LONGEMVFULL,

DATOSEMVFULL=@DATOSEMVFULL,

LONGLEALTAD=@LONGLEALTAD,

DATOSLEALTAD=@DATOSLEALTAD,

LONGMULTIPAGOS=@LONGMULTIPAGOS,

DATOSMULTIPAGOS=@DATOSMULTIPAGOS,

LONGDATOSCIFRADOS=@LONGDATOSCIFRADOS,

DATOSCIFRADOS=@DATOSCIFRADOS,

LONGCAMPANA=@LONGCAMPANA,

DATOSCAMPANA=@DATOSCAMPANA,

CONVENIOCIE=@CONVENIOCIE,

VERSION=@VERSION
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


       
        public CREQUESTBANCOMERBE seleccionarREQUESTBANCOMER(CREQUESTBANCOMERBE oCREQUESTBANCOMER, FbTransaction st)
        {




            CREQUESTBANCOMERBE retorno = new CREQUESTBANCOMERBE();
            /**/ FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from REQUESTBANCOMER where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCREQUESTBANCOMER.IID;
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

                    if (dr["ISSINTJROPERADOR"] != System.DBNull.Value)
                    {
                        retorno.IISSINTJROPERADOR = (string)(dr["ISSINTJROPERADOR"]);
                    }

                    if (dr["NOMAUTORIZACION"] != System.DBNull.Value)
                    {
                        retorno.INOMAUTORIZACION = (string)(dr["NOMAUTORIZACION"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (dr["PAN"] != System.DBNull.Value)
                    {
                        retorno.IPAN = (string)(dr["PAN"]);
                    }

                    if (dr["TOPERADOR"] != System.DBNull.Value)
                    {
                        retorno.ITOPERADOR = (string)(dr["TOPERADOR"]);
                    }

                    if (dr["CODTRANSACTION"] != System.DBNull.Value)
                    {
                        retorno.ICODTRANSACTION = (string)(dr["CODTRANSACTION"]);
                    }

                    if (dr["TERMINAL"] != System.DBNull.Value)
                    {
                        retorno.ITERMINAL = (string)(dr["TERMINAL"]);
                    }

                    if (dr["SESSION"] != System.DBNull.Value)
                    {
                        retorno.ISESSION = (string)(dr["SESSION"]);
                    }

                    if (dr["SECUENCIA"] != System.DBNull.Value)
                    {
                        retorno.ISECUENCIA = (string)(dr["SECUENCIA"]);
                    }

                    if (dr["IMPORTE"] != System.DBNull.Value)
                    {
                        retorno.IIMPORTE = (string)(dr["IMPORTE"]);
                    }

                    if (dr["PROPINA"] != System.DBNull.Value)
                    {
                        retorno.IPROPINA = (string)(dr["PROPINA"]);
                    }

                    if (dr["FOLIO"] != System.DBNull.Value)
                    {
                        retorno.IFOLIO = (string)(dr["FOLIO"]);
                    }

                    if (dr["CAPEMV"] != System.DBNull.Value)
                    {
                        retorno.ICAPEMV = (string)(dr["CAPEMV"]);
                    }

                    if (dr["TIPOLECTOR"] != System.DBNull.Value)
                    {
                        retorno.ITIPOLECTOR = (string)(dr["TIPOLECTOR"]);
                    }

                    if (dr["CAPCVV2"] != System.DBNull.Value)
                    {
                        retorno.ICAPCVV2 = (string)(dr["CAPCVV2"]);
                    }

                    if (dr["MESESFIN"] != System.DBNull.Value)
                    {
                        retorno.IMESESFIN = (string)(dr["MESESFIN"]);
                    }

                    if (dr["PARCIALIZACION"] != System.DBNull.Value)
                    {
                        retorno.IPARCIALIZACION = (string)(dr["PARCIALIZACION"]);
                    }

                    if (dr["PROMOCIONES"] != System.DBNull.Value)
                    {
                        retorno.IPROMOCIONES = (string)(dr["PROMOCIONES"]);
                    }

                    if (dr["TIPOMONEDA"] != System.DBNull.Value)
                    {
                        retorno.ITIPOMONEDA = (string)(dr["TIPOMONEDA"]);
                    }

                    if (dr["NOAUTORIZACION"] != System.DBNull.Value)
                    {
                        retorno.INOAUTORIZACION = (string)(dr["NOAUTORIZACION"]);
                    }

                    if (dr["MODOINGRESO"] != System.DBNull.Value)
                    {
                        retorno.IMODOINGRESO = (string)(dr["MODOINGRESO"]);
                    }

                    if (dr["CVV2"] != System.DBNull.Value)
                    {
                        retorno.ICVV2 = (string)(dr["CVV2"]);
                    }

                    if (dr["TRACK2"] != System.DBNull.Value)
                    {
                        retorno.ITRACK2 = (string)(dr["TRACK2"]);
                    }

                    if (dr["NOSECUENCIA"] != System.DBNull.Value)
                    {
                        retorno.INOSECUENCIA = (string)(dr["NOSECUENCIA"]);
                    }

                    if (dr["IMPORTECASH"] != System.DBNull.Value)
                    {
                        retorno.IIMPORTECASH = (string)(dr["IMPORTECASH"]);
                    }

                    if (dr["FECHAHORACOMERCIO"] != System.DBNull.Value)
                    {
                        retorno.IFECHAHORACOMERCIO = (string)(dr["FECHAHORACOMERCIO"]);
                    }

                    if (dr["REFERENCIACOMERCIO"] != System.DBNull.Value)
                    {
                        retorno.IREFERENCIACOMERCIO = (string)(dr["REFERENCIACOMERCIO"]);
                    }

                    if (dr["OTROIMPORTE"] != System.DBNull.Value)
                    {
                        retorno.IOTROIMPORTE = (string)(dr["OTROIMPORTE"]);
                    }

                    if (dr["CLAVEOPERADOR"] != System.DBNull.Value)
                    {
                        retorno.ICLAVEOPERADOR = (string)(dr["CLAVEOPERADOR"]);
                    }

                    if (dr["AFILIACION"] != System.DBNull.Value)
                    {
                        retorno.IAFILIACION = (string)(dr["AFILIACION"]);
                    }

                    if (dr["NUMEROCUARTO"] != System.DBNull.Value)
                    {
                        retorno.INUMEROCUARTO = (string)(dr["NUMEROCUARTO"]);
                    }

                    if (dr["REFERENCIAFINANCIERA"] != System.DBNull.Value)
                    {
                        retorno.IREFERENCIAFINANCIERA = (string)(dr["REFERENCIAFINANCIERA"]);
                    }

                    if (dr["CODIGOCONDCHIP"] != System.DBNull.Value)
                    {
                        retorno.ICODIGOCONDCHIP = (string)(dr["CODIGOCONDCHIP"]);
                    }

                    if (dr["LONGEMVFULL"] != System.DBNull.Value)
                    {
                        retorno.ILONGEMVFULL = (string)(dr["LONGEMVFULL"]);
                    }

                    if (dr["DATOSEMVFULL"] != System.DBNull.Value)
                    {
                        retorno.IDATOSEMVFULL = (string)(dr["DATOSEMVFULL"]);
                    }

                    if (dr["LONGLEALTAD"] != System.DBNull.Value)
                    {
                        retorno.ILONGLEALTAD = (string)(dr["LONGLEALTAD"]);
                    }

                    if (dr["DATOSLEALTAD"] != System.DBNull.Value)
                    {
                        retorno.IDATOSLEALTAD = (string)(dr["DATOSLEALTAD"]);
                    }

                    if (dr["LONGMULTIPAGOS"] != System.DBNull.Value)
                    {
                        retorno.ILONGMULTIPAGOS = (string)(dr["LONGMULTIPAGOS"]);
                    }

                    if (dr["DATOSMULTIPAGOS"] != System.DBNull.Value)
                    {
                        retorno.IDATOSMULTIPAGOS = (string)(dr["DATOSMULTIPAGOS"]);
                    }

                    if (dr["LONGDATOSCIFRADOS"] != System.DBNull.Value)
                    {
                        retorno.ILONGDATOSCIFRADOS = (string)(dr["LONGDATOSCIFRADOS"]);
                    }

                    if (dr["DATOSCIFRADOS"] != System.DBNull.Value)
                    {
                        retorno.IDATOSCIFRADOS = (string)(dr["DATOSCIFRADOS"]);
                    }

                    if (dr["LONGCAMPANA"] != System.DBNull.Value)
                    {
                        retorno.ILONGCAMPANA = (string)(dr["LONGCAMPANA"]);
                    }

                    if (dr["DATOSCAMPANA"] != System.DBNull.Value)
                    {
                        retorno.IDATOSCAMPANA = (string)(dr["DATOSCAMPANA"]);
                    }

                    if (dr["CONVENIOCIE"] != System.DBNull.Value)
                    {
                        retorno.ICONVENIOCIE = (string)(dr["CONVENIOCIE"]);
                    }

                    if (dr["VERSION"] != System.DBNull.Value)
                    {
                        retorno.IVERSION = (string)(dr["VERSION"]);
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









        
        public DataSet enlistarREQUESTBANCOMER()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_REQUESTBANCOMER_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




      
        public DataSet enlistarCortoREQUESTBANCOMER()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_REQUESTBANCOMER_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        
        public int ExisteREQUESTBANCOMER(CREQUESTBANCOMERBE oCREQUESTBANCOMER, FbTransaction st)
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
                auxPar.Value = oCREQUESTBANCOMER.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from REQUESTBANCOMER where

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




        public CREQUESTBANCOMERBE AgregarREQUESTBANCOMER(CREQUESTBANCOMERBE oCREQUESTBANCOMER, FbTransaction st)
        {
            try
            {
                int iRes = ExisteREQUESTBANCOMER(oCREQUESTBANCOMER, st);
                if (iRes == 1)
                {
                    this.IComentario = "El REQUESTBANCOMER ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarREQUESTBANCOMERD(oCREQUESTBANCOMER, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarREQUESTBANCOMER(CREQUESTBANCOMERBE oCREQUESTBANCOMER, FbTransaction st)
        {
            try
            {
                int iRes = ExisteREQUESTBANCOMER(oCREQUESTBANCOMER, st);
                if (iRes == 0)
                {
                    this.IComentario = "El REQUESTBANCOMER no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarREQUESTBANCOMERD(oCREQUESTBANCOMER, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarREQUESTBANCOMER(CREQUESTBANCOMERBE oCREQUESTBANCOMERNuevo, CREQUESTBANCOMERBE oCREQUESTBANCOMERAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteREQUESTBANCOMER(oCREQUESTBANCOMERAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El REQUESTBANCOMER no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarREQUESTBANCOMERD(oCREQUESTBANCOMERNuevo, oCREQUESTBANCOMERAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CREQUESTBANCOMERD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
