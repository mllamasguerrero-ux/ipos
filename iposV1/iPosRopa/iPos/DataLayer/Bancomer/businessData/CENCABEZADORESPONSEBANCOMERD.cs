

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

   


    public class CENCABEZADORESPONSEBANCOMERD
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


        
        public CENCABEZADORESPONSEBANCOMERBE AgregarENCABEZADORESPONSEBANCOMERD(CENCABEZADORESPONSEBANCOMERBE oCENCABEZADORESPONSEBANCOMER, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCENCABEZADORESPONSEBANCOMER.isnull["IID"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMER.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCENCABEZADORESPONSEBANCOMER.isnull["IACTIVO"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMER.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCENCABEZADORESPONSEBANCOMER.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMER.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCENCABEZADORESPONSEBANCOMER.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMER.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ENCABEZADOIP", FbDbType.VarChar);
                if (!(bool)oCENCABEZADORESPONSEBANCOMER.isnull["IENCABEZADOIP"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMER.IENCABEZADOIP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MENSAJE", FbDbType.VarChar);
                if (!(bool)oCENCABEZADORESPONSEBANCOMER.isnull["IMENSAJE"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMER.IMENSAJE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOMENSAJE", FbDbType.VarChar);
                if (!(bool)oCENCABEZADORESPONSEBANCOMER.isnull["ITIPOMENSAJE"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMER.ITIPOMENSAJE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDSANDF", FbDbType.VarChar);
                if (!(bool)oCENCABEZADORESPONSEBANCOMER.isnull["IIDSANDF"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMER.IIDSANDF;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDSECUENCIAL", FbDbType.VarChar);
                if (!(bool)oCENCABEZADORESPONSEBANCOMER.isnull["IIDSECUENCIAL"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMER.IIDSECUENCIAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DIRECCIONIP", FbDbType.VarChar);
                if (!(bool)oCENCABEZADORESPONSEBANCOMER.isnull["IDIRECCIONIP"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMER.IDIRECCIONIP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ENCABEZADOVERSION", FbDbType.VarChar);
                if (!(bool)oCENCABEZADORESPONSEBANCOMER.isnull["IENCABEZADOVERSION"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMER.IENCABEZADOVERSION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MACADDRESS", FbDbType.VarChar);
                if (!(bool)oCENCABEZADORESPONSEBANCOMER.isnull["IMACADDRESS"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMER.IMACADDRESS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VERSIONDLL", FbDbType.VarChar);
                if (!(bool)oCENCABEZADORESPONSEBANCOMER.isnull["IVERSIONDLL"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMER.IVERSIONDLL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CONECTADOPINPAD", FbDbType.VarChar);
                if (!(bool)oCENCABEZADORESPONSEBANCOMER.isnull["ICONECTADOPINPAD"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMER.ICONECTADOPINPAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@USOPINPAD", FbDbType.VarChar);
                if (!(bool)oCENCABEZADORESPONSEBANCOMER.isnull["IUSOPINPAD"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMER.IUSOPINPAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LONGSEBEHPOS", FbDbType.VarChar);
                if (!(bool)oCENCABEZADORESPONSEBANCOMER.isnull["ILONGSEBEHPOS"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMER.ILONGSEBEHPOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MACADDALTERNATIVA", FbDbType.VarChar);
                if (!(bool)oCENCABEZADORESPONSEBANCOMER.isnull["IMACADDALTERNATIVA"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMER.IMACADDALTERNATIVA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PINPADDETECTADO", FbDbType.Char);
                if (!(bool)oCENCABEZADORESPONSEBANCOMER.isnull["IPINPADDETECTADO"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMER.IPINPADDETECTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@QPSENLONGMACADD", FbDbType.VarChar);
                if (!(bool)oCENCABEZADORESPONSEBANCOMER.isnull["IQPSENLONGMACADD"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMER.IQPSENLONGMACADD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TELECARGAPINPAD", FbDbType.VarChar);
                if (!(bool)oCENCABEZADORESPONSEBANCOMER.isnull["ITELECARGAPINPAD"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMER.ITELECARGAPINPAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO ENCABEZADORESPONSEBANCOMER
      (
    
ID,

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

ENCABEZADOIP,

MENSAJE,

TIPOMENSAJE,

IDSANDF,

IDSECUENCIAL,

DIRECCIONIP,

ENCABEZADOVERSION,

MACADDRESS,

VERSIONDLL,

CONECTADOPINPAD,

USOPINPAD,

LONGSEBEHPOS,

MACADDALTERNATIVA,

PINPADDETECTADO,

QPSENLONGMACADD,

TELECARGAPINPAD
         )

Values (

@ID,

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@ENCABEZADOIP,

@MENSAJE,

@TIPOMENSAJE,

@IDSANDF,

@IDSECUENCIAL,

@DIRECCIONIP,

@ENCABEZADOVERSION,

@MACADDRESS,

@VERSIONDLL,

@CONECTADOPINPAD,

@USOPINPAD,

@LONGSEBEHPOS,

@MACADDALTERNATIVA,

@PINPADDETECTADO,

@QPSENLONGMACADD,

@TELECARGAPINPAD
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCENCABEZADORESPONSEBANCOMER;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        
        public bool BorrarENCABEZADORESPONSEBANCOMERD(CENCABEZADORESPONSEBANCOMERBE oCENCABEZADORESPONSEBANCOMER, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCENCABEZADORESPONSEBANCOMER.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from ENCABEZADORESPONSEBANCOMER
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


        
        public bool CambiarENCABEZADORESPONSEBANCOMERD(CENCABEZADORESPONSEBANCOMERBE oCENCABEZADORESPONSEBANCOMERNuevo, CENCABEZADORESPONSEBANCOMERBE oCENCABEZADORESPONSEBANCOMERAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCENCABEZADORESPONSEBANCOMERNuevo.isnull["IID"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMERNuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCENCABEZADORESPONSEBANCOMERNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMERNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCENCABEZADORESPONSEBANCOMERNuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMERNuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCENCABEZADORESPONSEBANCOMERNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMERNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ENCABEZADOIP", FbDbType.VarChar);
                if (!(bool)oCENCABEZADORESPONSEBANCOMERNuevo.isnull["IENCABEZADOIP"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMERNuevo.IENCABEZADOIP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MENSAJE", FbDbType.VarChar);
                if (!(bool)oCENCABEZADORESPONSEBANCOMERNuevo.isnull["IMENSAJE"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMERNuevo.IMENSAJE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPOMENSAJE", FbDbType.VarChar);
                if (!(bool)oCENCABEZADORESPONSEBANCOMERNuevo.isnull["ITIPOMENSAJE"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMERNuevo.ITIPOMENSAJE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDSANDF", FbDbType.VarChar);
                if (!(bool)oCENCABEZADORESPONSEBANCOMERNuevo.isnull["IIDSANDF"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMERNuevo.IIDSANDF;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDSECUENCIAL", FbDbType.VarChar);
                if (!(bool)oCENCABEZADORESPONSEBANCOMERNuevo.isnull["IIDSECUENCIAL"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMERNuevo.IIDSECUENCIAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DIRECCIONIP", FbDbType.VarChar);
                if (!(bool)oCENCABEZADORESPONSEBANCOMERNuevo.isnull["IDIRECCIONIP"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMERNuevo.IDIRECCIONIP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ENCABEZADOVERSION", FbDbType.VarChar);
                if (!(bool)oCENCABEZADORESPONSEBANCOMERNuevo.isnull["IENCABEZADOVERSION"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMERNuevo.IENCABEZADOVERSION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MACADDRESS", FbDbType.VarChar);
                if (!(bool)oCENCABEZADORESPONSEBANCOMERNuevo.isnull["IMACADDRESS"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMERNuevo.IMACADDRESS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@VERSIONDLL", FbDbType.VarChar);
                if (!(bool)oCENCABEZADORESPONSEBANCOMERNuevo.isnull["IVERSIONDLL"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMERNuevo.IVERSIONDLL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CONECTADOPINPAD", FbDbType.VarChar);
                if (!(bool)oCENCABEZADORESPONSEBANCOMERNuevo.isnull["ICONECTADOPINPAD"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMERNuevo.ICONECTADOPINPAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@USOPINPAD", FbDbType.VarChar);
                if (!(bool)oCENCABEZADORESPONSEBANCOMERNuevo.isnull["IUSOPINPAD"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMERNuevo.IUSOPINPAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LONGSEBEHPOS", FbDbType.VarChar);
                if (!(bool)oCENCABEZADORESPONSEBANCOMERNuevo.isnull["ILONGSEBEHPOS"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMERNuevo.ILONGSEBEHPOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MACADDALTERNATIVA", FbDbType.VarChar);
                if (!(bool)oCENCABEZADORESPONSEBANCOMERNuevo.isnull["IMACADDALTERNATIVA"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMERNuevo.IMACADDALTERNATIVA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PINPADDETECTADO", FbDbType.Char);
                if (!(bool)oCENCABEZADORESPONSEBANCOMERNuevo.isnull["IPINPADDETECTADO"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMERNuevo.IPINPADDETECTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@QPSENLONGMACADD", FbDbType.VarChar);
                if (!(bool)oCENCABEZADORESPONSEBANCOMERNuevo.isnull["IQPSENLONGMACADD"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMERNuevo.IQPSENLONGMACADD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TELECARGAPINPAD", FbDbType.VarChar);
                if (!(bool)oCENCABEZADORESPONSEBANCOMERNuevo.isnull["ITELECARGAPINPAD"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMERNuevo.ITELECARGAPINPAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCENCABEZADORESPONSEBANCOMERAnterior.isnull["IID"])
                {
                    auxPar.Value = oCENCABEZADORESPONSEBANCOMERAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  ENCABEZADORESPONSEBANCOMER
  set

ID=@ID,

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

ENCABEZADOIP=@ENCABEZADOIP,

MENSAJE=@MENSAJE,

TIPOMENSAJE=@TIPOMENSAJE,

IDSANDF=@IDSANDF,

IDSECUENCIAL=@IDSECUENCIAL,

DIRECCIONIP=@DIRECCIONIP,

ENCABEZADOVERSION=@ENCABEZADOVERSION,

MACADDRESS=@MACADDRESS,

VERSIONDLL=@VERSIONDLL,

CONECTADOPINPAD=@CONECTADOPINPAD,

USOPINPAD=@USOPINPAD,

LONGSEBEHPOS=@LONGSEBEHPOS,

MACADDALTERNATIVA=@MACADDALTERNATIVA,

PINPADDETECTADO=@PINPADDETECTADO,

QPSENLONGMACADD=@QPSENLONGMACADD,

TELECARGAPINPAD=@TELECARGAPINPAD
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


        
        public CENCABEZADORESPONSEBANCOMERBE seleccionarENCABEZADORESPONSEBANCOMER(CENCABEZADORESPONSEBANCOMERBE oCENCABEZADORESPONSEBANCOMER, FbTransaction st)
        {




            CENCABEZADORESPONSEBANCOMERBE retorno = new CENCABEZADORESPONSEBANCOMERBE();
            /**/ FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from ENCABEZADORESPONSEBANCOMER where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCENCABEZADORESPONSEBANCOMER.IID;
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

                    if (dr["ENCABEZADOIP"] != System.DBNull.Value)
                    {
                        retorno.IENCABEZADOIP = (string)(dr["ENCABEZADOIP"]);
                    }

                    if (dr["MENSAJE"] != System.DBNull.Value)
                    {
                        retorno.IMENSAJE = (string)(dr["MENSAJE"]);
                    }

                    if (dr["TIPOMENSAJE"] != System.DBNull.Value)
                    {
                        retorno.ITIPOMENSAJE = (string)(dr["TIPOMENSAJE"]);
                    }

                    if (dr["IDSANDF"] != System.DBNull.Value)
                    {
                        retorno.IIDSANDF = (string)(dr["IDSANDF"]);
                    }

                    if (dr["IDSECUENCIAL"] != System.DBNull.Value)
                    {
                        retorno.IIDSECUENCIAL = (string)(dr["IDSECUENCIAL"]);
                    }

                    if (dr["DIRECCIONIP"] != System.DBNull.Value)
                    {
                        retorno.IDIRECCIONIP = (string)(dr["DIRECCIONIP"]);
                    }

                    if (dr["ENCABEZADOVERSION"] != System.DBNull.Value)
                    {
                        retorno.IENCABEZADOVERSION = (string)(dr["ENCABEZADOVERSION"]);
                    }

                    if (dr["MACADDRESS"] != System.DBNull.Value)
                    {
                        retorno.IMACADDRESS = (string)(dr["MACADDRESS"]);
                    }

                    if (dr["VERSIONDLL"] != System.DBNull.Value)
                    {
                        retorno.IVERSIONDLL = (string)(dr["VERSIONDLL"]);
                    }

                    if (dr["CONECTADOPINPAD"] != System.DBNull.Value)
                    {
                        retorno.ICONECTADOPINPAD = (string)(dr["CONECTADOPINPAD"]);
                    }

                    if (dr["USOPINPAD"] != System.DBNull.Value)
                    {
                        retorno.IUSOPINPAD = (string)(dr["USOPINPAD"]);
                    }

                    if (dr["LONGSEBEHPOS"] != System.DBNull.Value)
                    {
                        retorno.ILONGSEBEHPOS = (string)(dr["LONGSEBEHPOS"]);
                    }

                    if (dr["MACADDALTERNATIVA"] != System.DBNull.Value)
                    {
                        retorno.IMACADDALTERNATIVA = (string)(dr["MACADDALTERNATIVA"]);
                    }

                    if (dr["PINPADDETECTADO"] != System.DBNull.Value)
                    {
                        retorno.IPINPADDETECTADO = (string)(dr["PINPADDETECTADO"]);
                    }

                    if (dr["QPSENLONGMACADD"] != System.DBNull.Value)
                    {
                        retorno.IQPSENLONGMACADD = (string)(dr["QPSENLONGMACADD"]);
                    }

                    if (dr["TELECARGAPINPAD"] != System.DBNull.Value)
                    {
                        retorno.ITELECARGAPINPAD = (string)(dr["TELECARGAPINPAD"]);
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









        
        public DataSet enlistarENCABEZADORESPONSEBANCOMER()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_ENCABEZADORESPONSEBANCOMER_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        
        public DataSet enlistarCortoENCABEZADORESPONSEBANCOMER()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_ENCABEZADORESPONSEBANCOMER_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        
        public int ExisteENCABEZADORESPONSEBANCOMER(CENCABEZADORESPONSEBANCOMERBE oCENCABEZADORESPONSEBANCOMER, FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCENCABEZADORESPONSEBANCOMER.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from ENCABEZADORESPONSEBANCOMER where

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




        public CENCABEZADORESPONSEBANCOMERBE AgregarENCABEZADORESPONSEBANCOMER(CENCABEZADORESPONSEBANCOMERBE oCENCABEZADORESPONSEBANCOMER, FbTransaction st)
        {
            try
            {
                int iRes = ExisteENCABEZADORESPONSEBANCOMER(oCENCABEZADORESPONSEBANCOMER, st);
                if (iRes == 1)
                {
                    this.IComentario = "El ENCABEZADORESPONSEBANCOMER ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarENCABEZADORESPONSEBANCOMERD(oCENCABEZADORESPONSEBANCOMER, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarENCABEZADORESPONSEBANCOMER(CENCABEZADORESPONSEBANCOMERBE oCENCABEZADORESPONSEBANCOMER, FbTransaction st)
        {
            try
            {
                int iRes = ExisteENCABEZADORESPONSEBANCOMER(oCENCABEZADORESPONSEBANCOMER, st);
                if (iRes == 0)
                {
                    this.IComentario = "El ENCABEZADORESPONSEBANCOMER no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarENCABEZADORESPONSEBANCOMERD(oCENCABEZADORESPONSEBANCOMER, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarENCABEZADORESPONSEBANCOMER(CENCABEZADORESPONSEBANCOMERBE oCENCABEZADORESPONSEBANCOMERNuevo, CENCABEZADORESPONSEBANCOMERBE oCENCABEZADORESPONSEBANCOMERAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteENCABEZADORESPONSEBANCOMER(oCENCABEZADORESPONSEBANCOMERAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El ENCABEZADORESPONSEBANCOMER no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarENCABEZADORESPONSEBANCOMERD(oCENCABEZADORESPONSEBANCOMERNuevo, oCENCABEZADORESPONSEBANCOMERAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CENCABEZADORESPONSEBANCOMERD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
