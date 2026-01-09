

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


    public class CRESPONSEBANCOMERD
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
        public CRESPONSEBANCOMERBE AgregarRESPONSEBANCOMERD(CRESPONSEBANCOMERBE oCRESPONSEBANCOMER, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCRESPONSEBANCOMER.isnull["IID"])
                {
                    auxPar.Value = oCRESPONSEBANCOMER.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCRESPONSEBANCOMER.isnull["IACTIVO"])
                {
                    auxPar.Value = oCRESPONSEBANCOMER.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCRESPONSEBANCOMER.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCRESPONSEBANCOMER.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCRESPONSEBANCOMER.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCRESPONSEBANCOMER.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CODTRANSACTION", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMER.isnull["ICODTRANSACTION"])
                {
                    auxPar.Value = oCRESPONSEBANCOMER.ICODTRANSACTION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TERMINAL", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMER.isnull["ITERMINAL"])
                {
                    auxPar.Value = oCRESPONSEBANCOMER.ITERMINAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SESSION", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMER.isnull["ISESSION"])
                {
                    auxPar.Value = oCRESPONSEBANCOMER.ISESSION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SECUENCIA", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMER.isnull["ISECUENCIA"])
                {
                    auxPar.Value = oCRESPONSEBANCOMER.ISECUENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CODIGORESPUESTA", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMER.isnull["ICODIGORESPUESTA"])
                {
                    auxPar.Value = oCRESPONSEBANCOMER.ICODIGORESPUESTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOAUTORIZACION", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMER.isnull["INOAUTORIZACION"])
                {
                    auxPar.Value = oCRESPONSEBANCOMER.INOAUTORIZACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@AFILIACION", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMER.isnull["IAFILIACION"])
                {
                    auxPar.Value = oCRESPONSEBANCOMER.IAFILIACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FILLER1", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMER.isnull["IFILLER1"])
                {
                    auxPar.Value = oCRESPONSEBANCOMER.IFILLER1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPORTE", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMER.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCRESPONSEBANCOMER.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FILLER2", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMER.isnull["IFILLER2"])
                {
                    auxPar.Value = oCRESPONSEBANCOMER.IFILLER2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TARJETA", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMER.isnull["ITARJETA"])
                {
                    auxPar.Value = oCRESPONSEBANCOMER.ITARJETA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CVEOPERADOR", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMER.isnull["ICVEOPERADOR"])
                {
                    auxPar.Value = oCRESPONSEBANCOMER.ICVEOPERADOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FILLER3", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMER.isnull["IFILLER3"])
                {
                    auxPar.Value = oCRESPONSEBANCOMER.IFILLER3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FOLIO", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMER.isnull["IFOLIO"])
                {
                    auxPar.Value = oCRESPONSEBANCOMER.IFOLIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LONGLEYENDA", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMER.isnull["ILONGLEYENDA"])
                {
                    auxPar.Value = oCRESPONSEBANCOMER.ILONGLEYENDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LEYENDA", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMER.isnull["ILEYENDA"])
                {
                    auxPar.Value = oCRESPONSEBANCOMER.ILEYENDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIAFINAN", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMER.isnull["IREFERENCIAFINAN"])
                {
                    auxPar.Value = oCRESPONSEBANCOMER.IREFERENCIAFINAN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LONGEMV", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMER.isnull["ILONGEMV"])
                {
                    auxPar.Value = oCRESPONSEBANCOMER.ILONGEMV;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DATOSEMV", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMER.isnull["IDATOSEMV"])
                {
                    auxPar.Value = oCRESPONSEBANCOMER.IDATOSEMV;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LONGLEALTAD", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMER.isnull["ILONGLEALTAD"])
                {
                    auxPar.Value = oCRESPONSEBANCOMER.ILONGLEALTAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DATOSLEALTAD", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMER.isnull["IDATOSLEALTAD"])
                {
                    auxPar.Value = oCRESPONSEBANCOMER.IDATOSLEALTAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REGISTRO1", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMER.isnull["IREGISTRO1"])
                {
                    auxPar.Value = oCRESPONSEBANCOMER.IREGISTRO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REGISTRO2", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMER.isnull["IREGISTRO2"])
                {
                    auxPar.Value = oCRESPONSEBANCOMER.IREGISTRO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REGISTRO3", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMER.isnull["IREGISTRO3"])
                {
                    auxPar.Value = oCRESPONSEBANCOMER.IREGISTRO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REGISTRO4", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMER.isnull["IREGISTRO4"])
                {
                    auxPar.Value = oCRESPONSEBANCOMER.IREGISTRO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REGISTRO5", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMER.isnull["IREGISTRO5"])
                {
                    auxPar.Value = oCRESPONSEBANCOMER.IREGISTRO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LONGMULTIPAGOS", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMER.isnull["ILONGMULTIPAGOS"])
                {
                    auxPar.Value = oCRESPONSEBANCOMER.ILONGMULTIPAGOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MULTIPAGOS", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMER.isnull["IMULTIPAGOS"])
                {
                    auxPar.Value = oCRESPONSEBANCOMER.IMULTIPAGOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LONGDATOSCIFRADOS", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMER.isnull["ILONGDATOSCIFRADOS"])
                {
                    auxPar.Value = oCRESPONSEBANCOMER.ILONGDATOSCIFRADOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DATOSCIFRADOS", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMER.isnull["IDATOSCIFRADOS"])
                {
                    auxPar.Value = oCRESPONSEBANCOMER.IDATOSCIFRADOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LONGCAMPANA", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMER.isnull["ILONGCAMPANA"])
                {
                    auxPar.Value = oCRESPONSEBANCOMER.ILONGCAMPANA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DATOSCAMPANA", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMER.isnull["IDATOSCAMPANA"])
                {
                    auxPar.Value = oCRESPONSEBANCOMER.IDATOSCAMPANA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDENCABEZADO", FbDbType.BigInt);
                if (!(bool)oCRESPONSEBANCOMER.isnull["IIDENCABEZADO"])
                {
                    auxPar.Value = oCRESPONSEBANCOMER.IIDENCABEZADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO RESPONSEBANCOMER
      (
    
ID,

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

CODTRANSACTION,

TERMINAL,

SESSION,

SECUENCIA,

CODIGORESPUESTA,

NOAUTORIZACION,

AFILIACION,

FILLER1,

IMPORTE,

FILLER2,

TARJETA,

CVEOPERADOR,

FILLER3,

FOLIO,

LONGLEYENDA,

LEYENDA,

REFERENCIAFINAN,

LONGEMV,

DATOSEMV,

LONGLEALTAD,

DATOSLEALTAD,

REGISTRO1,

REGISTRO2,

REGISTRO3,

REGISTRO4,

REGISTRO5,

LONGMULTIPAGOS,

MULTIPAGOS,

LONGDATOSCIFRADOS,

DATOSCIFRADOS,

LONGCAMPANA,

DATOSCAMPANA,

IDENCABEZADO
         )

Values (

@ID,

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@CODTRANSACTION,

@TERMINAL,

@SESSION,

@SECUENCIA,

@CODIGORESPUESTA,

@NOAUTORIZACION,

@AFILIACION,

@FILLER1,

@IMPORTE,

@FILLER2,

@TARJETA,

@CVEOPERADOR,

@FILLER3,

@FOLIO,

@LONGLEYENDA,

@LEYENDA,

@REFERENCIAFINAN,

@LONGEMV,

@DATOSEMV,

@LONGLEALTAD,

@DATOSLEALTAD,

@REGISTRO1,

@REGISTRO2,

@REGISTRO3,

@REGISTRO4,

@REGISTRO5,

@LONGMULTIPAGOS,

@MULTIPAGOS,

@LONGDATOSCIFRADOS,

@DATOSCIFRADOS,

@LONGCAMPANA,

@DATOSCAMPANA,

@IDENCABEZADO
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCRESPONSEBANCOMER;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarRESPONSEBANCOMERD(CRESPONSEBANCOMERBE oCRESPONSEBANCOMER, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCRESPONSEBANCOMER.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from RESPONSEBANCOMER
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
        public bool CambiarRESPONSEBANCOMERD(CRESPONSEBANCOMERBE oCRESPONSEBANCOMERNuevo, CRESPONSEBANCOMERBE oCRESPONSEBANCOMERAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCRESPONSEBANCOMERNuevo.isnull["IID"])
                {
                    auxPar.Value = oCRESPONSEBANCOMERNuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCRESPONSEBANCOMERNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCRESPONSEBANCOMERNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCRESPONSEBANCOMERNuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCRESPONSEBANCOMERNuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCRESPONSEBANCOMERNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCRESPONSEBANCOMERNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CODTRANSACTION", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMERNuevo.isnull["ICODTRANSACTION"])
                {
                    auxPar.Value = oCRESPONSEBANCOMERNuevo.ICODTRANSACTION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TERMINAL", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMERNuevo.isnull["ITERMINAL"])
                {
                    auxPar.Value = oCRESPONSEBANCOMERNuevo.ITERMINAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SESSION", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMERNuevo.isnull["ISESSION"])
                {
                    auxPar.Value = oCRESPONSEBANCOMERNuevo.ISESSION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SECUENCIA", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMERNuevo.isnull["ISECUENCIA"])
                {
                    auxPar.Value = oCRESPONSEBANCOMERNuevo.ISECUENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CODIGORESPUESTA", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMERNuevo.isnull["ICODIGORESPUESTA"])
                {
                    auxPar.Value = oCRESPONSEBANCOMERNuevo.ICODIGORESPUESTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOAUTORIZACION", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMERNuevo.isnull["INOAUTORIZACION"])
                {
                    auxPar.Value = oCRESPONSEBANCOMERNuevo.INOAUTORIZACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@AFILIACION", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMERNuevo.isnull["IAFILIACION"])
                {
                    auxPar.Value = oCRESPONSEBANCOMERNuevo.IAFILIACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FILLER1", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMERNuevo.isnull["IFILLER1"])
                {
                    auxPar.Value = oCRESPONSEBANCOMERNuevo.IFILLER1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IMPORTE", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMERNuevo.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCRESPONSEBANCOMERNuevo.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FILLER2", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMERNuevo.isnull["IFILLER2"])
                {
                    auxPar.Value = oCRESPONSEBANCOMERNuevo.IFILLER2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TARJETA", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMERNuevo.isnull["ITARJETA"])
                {
                    auxPar.Value = oCRESPONSEBANCOMERNuevo.ITARJETA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CVEOPERADOR", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMERNuevo.isnull["ICVEOPERADOR"])
                {
                    auxPar.Value = oCRESPONSEBANCOMERNuevo.ICVEOPERADOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FILLER3", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMERNuevo.isnull["IFILLER3"])
                {
                    auxPar.Value = oCRESPONSEBANCOMERNuevo.IFILLER3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FOLIO", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMERNuevo.isnull["IFOLIO"])
                {
                    auxPar.Value = oCRESPONSEBANCOMERNuevo.IFOLIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LONGLEYENDA", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMERNuevo.isnull["ILONGLEYENDA"])
                {
                    auxPar.Value = oCRESPONSEBANCOMERNuevo.ILONGLEYENDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LEYENDA", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMERNuevo.isnull["ILEYENDA"])
                {
                    auxPar.Value = oCRESPONSEBANCOMERNuevo.ILEYENDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@REFERENCIAFINAN", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMERNuevo.isnull["IREFERENCIAFINAN"])
                {
                    auxPar.Value = oCRESPONSEBANCOMERNuevo.IREFERENCIAFINAN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LONGEMV", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMERNuevo.isnull["ILONGEMV"])
                {
                    auxPar.Value = oCRESPONSEBANCOMERNuevo.ILONGEMV;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DATOSEMV", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMERNuevo.isnull["IDATOSEMV"])
                {
                    auxPar.Value = oCRESPONSEBANCOMERNuevo.IDATOSEMV;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LONGLEALTAD", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMERNuevo.isnull["ILONGLEALTAD"])
                {
                    auxPar.Value = oCRESPONSEBANCOMERNuevo.ILONGLEALTAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DATOSLEALTAD", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMERNuevo.isnull["IDATOSLEALTAD"])
                {
                    auxPar.Value = oCRESPONSEBANCOMERNuevo.IDATOSLEALTAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@REGISTRO1", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMERNuevo.isnull["IREGISTRO1"])
                {
                    auxPar.Value = oCRESPONSEBANCOMERNuevo.IREGISTRO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@REGISTRO2", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMERNuevo.isnull["IREGISTRO2"])
                {
                    auxPar.Value = oCRESPONSEBANCOMERNuevo.IREGISTRO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@REGISTRO3", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMERNuevo.isnull["IREGISTRO3"])
                {
                    auxPar.Value = oCRESPONSEBANCOMERNuevo.IREGISTRO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@REGISTRO4", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMERNuevo.isnull["IREGISTRO4"])
                {
                    auxPar.Value = oCRESPONSEBANCOMERNuevo.IREGISTRO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@REGISTRO5", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMERNuevo.isnull["IREGISTRO5"])
                {
                    auxPar.Value = oCRESPONSEBANCOMERNuevo.IREGISTRO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LONGMULTIPAGOS", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMERNuevo.isnull["ILONGMULTIPAGOS"])
                {
                    auxPar.Value = oCRESPONSEBANCOMERNuevo.ILONGMULTIPAGOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MULTIPAGOS", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMERNuevo.isnull["IMULTIPAGOS"])
                {
                    auxPar.Value = oCRESPONSEBANCOMERNuevo.IMULTIPAGOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LONGDATOSCIFRADOS", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMERNuevo.isnull["ILONGDATOSCIFRADOS"])
                {
                    auxPar.Value = oCRESPONSEBANCOMERNuevo.ILONGDATOSCIFRADOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DATOSCIFRADOS", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMERNuevo.isnull["IDATOSCIFRADOS"])
                {
                    auxPar.Value = oCRESPONSEBANCOMERNuevo.IDATOSCIFRADOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LONGCAMPANA", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMERNuevo.isnull["ILONGCAMPANA"])
                {
                    auxPar.Value = oCRESPONSEBANCOMERNuevo.ILONGCAMPANA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DATOSCAMPANA", FbDbType.VarChar);
                if (!(bool)oCRESPONSEBANCOMERNuevo.isnull["IDATOSCAMPANA"])
                {
                    auxPar.Value = oCRESPONSEBANCOMERNuevo.IDATOSCAMPANA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDENCABEZADO", FbDbType.BigInt);
                if (!(bool)oCRESPONSEBANCOMERNuevo.isnull["IIDENCABEZADO"])
                {
                    auxPar.Value = oCRESPONSEBANCOMERNuevo.IIDENCABEZADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCRESPONSEBANCOMERAnterior.isnull["IID"])
                {
                    auxPar.Value = oCRESPONSEBANCOMERAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  RESPONSEBANCOMER
  set

ID=@ID,

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

CODTRANSACTION=@CODTRANSACTION,

TERMINAL=@TERMINAL,

SESSION=@SESSION,

SECUENCIA=@SECUENCIA,

CODIGORESPUESTA=@CODIGORESPUESTA,

NOAUTORIZACION=@NOAUTORIZACION,

AFILIACION=@AFILIACION,

FILLER1=@FILLER1,

IMPORTE=@IMPORTE,

FILLER2=@FILLER2,

TARJETA=@TARJETA,

CVEOPERADOR=@CVEOPERADOR,

FILLER3=@FILLER3,

FOLIO=@FOLIO,

LONGLEYENDA=@LONGLEYENDA,

LEYENDA=@LEYENDA,

REFERENCIAFINAN=@REFERENCIAFINAN,

LONGEMV=@LONGEMV,

DATOSEMV=@DATOSEMV,

LONGLEALTAD=@LONGLEALTAD,

DATOSLEALTAD=@DATOSLEALTAD,

REGISTRO1=@REGISTRO1,

REGISTRO2=@REGISTRO2,

REGISTRO3=@REGISTRO3,

REGISTRO4=@REGISTRO4,

REGISTRO5=@REGISTRO5,

LONGMULTIPAGOS=@LONGMULTIPAGOS,

MULTIPAGOS=@MULTIPAGOS,

LONGDATOSCIFRADOS=@LONGDATOSCIFRADOS,

DATOSCIFRADOS=@DATOSCIFRADOS,

LONGCAMPANA=@LONGCAMPANA,

DATOSCAMPANA=@DATOSCAMPANA,

IDENCABEZADO=@IDENCABEZADO
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
        public CRESPONSEBANCOMERBE seleccionarRESPONSEBANCOMER(CRESPONSEBANCOMERBE oCRESPONSEBANCOMER, FbTransaction st)
        {




            CRESPONSEBANCOMERBE retorno = new CRESPONSEBANCOMERBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from RESPONSEBANCOMER where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCRESPONSEBANCOMER.IID;
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

                    if (dr["CODIGORESPUESTA"] != System.DBNull.Value)
                    {
                        retorno.ICODIGORESPUESTA = (string)(dr["CODIGORESPUESTA"]);
                    }

                    if (dr["NOAUTORIZACION"] != System.DBNull.Value)
                    {
                        retorno.INOAUTORIZACION = (string)(dr["NOAUTORIZACION"]);
                    }

                    if (dr["AFILIACION"] != System.DBNull.Value)
                    {
                        retorno.IAFILIACION = (string)(dr["AFILIACION"]);
                    }

                    if (dr["FILLER1"] != System.DBNull.Value)
                    {
                        retorno.IFILLER1 = (string)(dr["FILLER1"]);
                    }

                    if (dr["IMPORTE"] != System.DBNull.Value)
                    {
                        retorno.IIMPORTE = (string)(dr["IMPORTE"]);
                    }

                    if (dr["FILLER2"] != System.DBNull.Value)
                    {
                        retorno.IFILLER2 = (string)(dr["FILLER2"]);
                    }

                    if (dr["TARJETA"] != System.DBNull.Value)
                    {
                        retorno.ITARJETA = (string)(dr["TARJETA"]);
                    }

                    if (dr["CVEOPERADOR"] != System.DBNull.Value)
                    {
                        retorno.ICVEOPERADOR = (string)(dr["CVEOPERADOR"]);
                    }

                    if (dr["FILLER3"] != System.DBNull.Value)
                    {
                        retorno.IFILLER3 = (string)(dr["FILLER3"]);
                    }

                    if (dr["FOLIO"] != System.DBNull.Value)
                    {
                        retorno.IFOLIO = (string)(dr["FOLIO"]);
                    }

                    if (dr["LONGLEYENDA"] != System.DBNull.Value)
                    {
                        retorno.ILONGLEYENDA = (string)(dr["LONGLEYENDA"]);
                    }

                    if (dr["LEYENDA"] != System.DBNull.Value)
                    {
                        retorno.ILEYENDA = (string)(dr["LEYENDA"]);
                    }

                    if (dr["REFERENCIAFINAN"] != System.DBNull.Value)
                    {
                        retorno.IREFERENCIAFINAN = (string)(dr["REFERENCIAFINAN"]);
                    }

                    if (dr["LONGEMV"] != System.DBNull.Value)
                    {
                        retorno.ILONGEMV = (string)(dr["LONGEMV"]);
                    }

                    if (dr["DATOSEMV"] != System.DBNull.Value)
                    {
                        retorno.IDATOSEMV = (string)(dr["DATOSEMV"]);
                    }

                    if (dr["LONGLEALTAD"] != System.DBNull.Value)
                    {
                        retorno.ILONGLEALTAD = (string)(dr["LONGLEALTAD"]);
                    }

                    if (dr["DATOSLEALTAD"] != System.DBNull.Value)
                    {
                        retorno.IDATOSLEALTAD = (string)(dr["DATOSLEALTAD"]);
                    }

                    if (dr["REGISTRO1"] != System.DBNull.Value)
                    {
                        retorno.IREGISTRO1 = (string)(dr["REGISTRO1"]);
                    }

                    if (dr["REGISTRO2"] != System.DBNull.Value)
                    {
                        retorno.IREGISTRO2 = (string)(dr["REGISTRO2"]);
                    }

                    if (dr["REGISTRO3"] != System.DBNull.Value)
                    {
                        retorno.IREGISTRO3 = (string)(dr["REGISTRO3"]);
                    }

                    if (dr["REGISTRO4"] != System.DBNull.Value)
                    {
                        retorno.IREGISTRO4 = (string)(dr["REGISTRO4"]);
                    }

                    if (dr["REGISTRO5"] != System.DBNull.Value)
                    {
                        retorno.IREGISTRO5 = (string)(dr["REGISTRO5"]);
                    }

                    if (dr["LONGMULTIPAGOS"] != System.DBNull.Value)
                    {
                        retorno.ILONGMULTIPAGOS = (string)(dr["LONGMULTIPAGOS"]);
                    }

                    if (dr["MULTIPAGOS"] != System.DBNull.Value)
                    {
                        retorno.IMULTIPAGOS = (string)(dr["MULTIPAGOS"]);
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

                    if (dr["IDENCABEZADO"] != System.DBNull.Value)
                    {
                        retorno.IIDENCABEZADO = (long)(dr["IDENCABEZADO"]);
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
        public DataSet enlistarRESPONSEBANCOMER()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_RESPONSEBANCOMER_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoRESPONSEBANCOMER()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_RESPONSEBANCOMER_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteRESPONSEBANCOMER(CRESPONSEBANCOMERBE oCRESPONSEBANCOMER, FbTransaction st)
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
                auxPar.Value = oCRESPONSEBANCOMER.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from RESPONSEBANCOMER where

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




        public CRESPONSEBANCOMERBE AgregarRESPONSEBANCOMER(CRESPONSEBANCOMERBE oCRESPONSEBANCOMER, FbTransaction st)
        {
            try
            {
                int iRes = ExisteRESPONSEBANCOMER(oCRESPONSEBANCOMER, st);
                if (iRes == 1)
                {
                    this.IComentario = "El RESPONSEBANCOMER ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarRESPONSEBANCOMERD(oCRESPONSEBANCOMER, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarRESPONSEBANCOMER(CRESPONSEBANCOMERBE oCRESPONSEBANCOMER, FbTransaction st)
        {
            try
            {
                int iRes = ExisteRESPONSEBANCOMER(oCRESPONSEBANCOMER, st);
                if (iRes == 0)
                {
                    this.IComentario = "El RESPONSEBANCOMER no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarRESPONSEBANCOMERD(oCRESPONSEBANCOMER, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarRESPONSEBANCOMER(CRESPONSEBANCOMERBE oCRESPONSEBANCOMERNuevo, CRESPONSEBANCOMERBE oCRESPONSEBANCOMERAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteRESPONSEBANCOMER(oCRESPONSEBANCOMERAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El RESPONSEBANCOMER no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarRESPONSEBANCOMERD(oCRESPONSEBANCOMERNuevo, oCRESPONSEBANCOMERAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CRESPONSEBANCOMERD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
