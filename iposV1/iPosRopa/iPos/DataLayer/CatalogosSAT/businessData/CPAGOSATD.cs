

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



    public class CPAGOSATD
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


        public CPAGOSATBE AgregarPAGOSATD(CPAGOSATBE oCPAGOSAT, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCPAGOSAT.isnull["IACTIVO"])
                {
                    auxPar.Value = oCPAGOSAT.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPAGOSAT.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCPAGOSAT.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPAGOSAT.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCPAGOSAT.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOSATID", FbDbType.BigInt);
                if (!(bool)oCPAGOSAT.isnull["IDOCTOSATID"])
                {
                    auxPar.Value = oCPAGOSAT.IDOCTOSATID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FORMADEPAGOP", FbDbType.VarChar);
                if (!(bool)oCPAGOSAT.isnull["IFORMADEPAGOP"])
                {
                    auxPar.Value = oCPAGOSAT.IFORMADEPAGOP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONEDAP", FbDbType.VarChar);
                if (!(bool)oCPAGOSAT.isnull["IMONEDAP"])
                {
                    auxPar.Value = oCPAGOSAT.IMONEDAP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOCAMBIOP", FbDbType.Numeric);
                if (!(bool)oCPAGOSAT.isnull["ITIPOCAMBIOP"])
                {
                    auxPar.Value = oCPAGOSAT.ITIPOCAMBIOP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO", FbDbType.Numeric);
                if (!(bool)oCPAGOSAT.isnull["IMONTO"])
                {
                    auxPar.Value = oCPAGOSAT.IMONTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUMOPERACION", FbDbType.VarChar);
                if (!(bool)oCPAGOSAT.isnull["INUMOPERACION"])
                {
                    auxPar.Value = oCPAGOSAT.INUMOPERACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RFCEMISORCTAORD", FbDbType.VarChar);
                if (!(bool)oCPAGOSAT.isnull["IRFCEMISORCTAORD"])
                {
                    auxPar.Value = oCPAGOSAT.IRFCEMISORCTAORD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBANCOORDEXT", FbDbType.VarChar);
                if (!(bool)oCPAGOSAT.isnull["INOMBANCOORDEXT"])
                {
                    auxPar.Value = oCPAGOSAT.INOMBANCOORDEXT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CTAORDENANTE", FbDbType.VarChar);
                if (!(bool)oCPAGOSAT.isnull["ICTAORDENANTE"])
                {
                    auxPar.Value = oCPAGOSAT.ICTAORDENANTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RFCEMISORCTABEN", FbDbType.VarChar);
                if (!(bool)oCPAGOSAT.isnull["IRFCEMISORCTABEN"])
                {
                    auxPar.Value = oCPAGOSAT.IRFCEMISORCTABEN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CTABENEFICIARIO", FbDbType.VarChar);
                if (!(bool)oCPAGOSAT.isnull["ICTABENEFICIARIO"])
                {
                    auxPar.Value = oCPAGOSAT.ICTABENEFICIARIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOCADPAGO", FbDbType.VarChar);
                if (!(bool)oCPAGOSAT.isnull["ITIPOCADPAGO"])
                {
                    auxPar.Value = oCPAGOSAT.ITIPOCADPAGO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CERTPAGO", FbDbType.VarChar);
                if (!(bool)oCPAGOSAT.isnull["ICERTPAGO"])
                {
                    auxPar.Value = oCPAGOSAT.ICERTPAGO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CADPAGO", FbDbType.VarChar);
                if (!(bool)oCPAGOSAT.isnull["ICADPAGO"])
                {
                    auxPar.Value = oCPAGOSAT.ICADPAGO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SELLOPAGO", FbDbType.VarChar);
                if (!(bool)oCPAGOSAT.isnull["ISELLOPAGO"])
                {
                    auxPar.Value = oCPAGOSAT.ISELLOPAGO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO PAGOSAT
      (
    
ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

DOCTOSATID,

FORMADEPAGOP,

MONEDAP,

TIPOCAMBIOP,

MONTO,

NUMOPERACION,

RFCEMISORCTAORD,

NOMBANCOORDEXT,

CTAORDENANTE,

RFCEMISORCTABEN,

CTABENEFICIARIO,

TIPOCADPAGO,

CERTPAGO,

CADPAGO,

SELLOPAGO
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@DOCTOSATID,

@FORMADEPAGOP,

@MONEDAP,

@TIPOCAMBIOP,

@MONTO,

@NUMOPERACION,

@RFCEMISORCTAORD,

@NOMBANCOORDEXT,

@CTAORDENANTE,

@RFCEMISORCTABEN,

@CTABENEFICIARIO,

@TIPOCADPAGO,

@CERTPAGO,

@CADPAGO,

@SELLOPAGO
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCPAGOSAT;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarPAGOSATD(CPAGOSATBE oCPAGOSAT, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPAGOSAT.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from PAGOSAT
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


        public bool CambiarPAGOSATD(CPAGOSATBE oCPAGOSATNuevo, CPAGOSATBE oCPAGOSATAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCPAGOSATNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCPAGOSATNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPAGOSATNuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCPAGOSATNuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPAGOSATNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCPAGOSATNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOCTOSATID", FbDbType.BigInt);
                if (!(bool)oCPAGOSATNuevo.isnull["IDOCTOSATID"])
                {
                    auxPar.Value = oCPAGOSATNuevo.IDOCTOSATID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FORMADEPAGOP", FbDbType.VarChar);
                if (!(bool)oCPAGOSATNuevo.isnull["IFORMADEPAGOP"])
                {
                    auxPar.Value = oCPAGOSATNuevo.IFORMADEPAGOP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONEDAP", FbDbType.VarChar);
                if (!(bool)oCPAGOSATNuevo.isnull["IMONEDAP"])
                {
                    auxPar.Value = oCPAGOSATNuevo.IMONEDAP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPOCAMBIOP", FbDbType.Numeric);
                if (!(bool)oCPAGOSATNuevo.isnull["ITIPOCAMBIOP"])
                {
                    auxPar.Value = oCPAGOSATNuevo.ITIPOCAMBIOP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONTO", FbDbType.Numeric);
                if (!(bool)oCPAGOSATNuevo.isnull["IMONTO"])
                {
                    auxPar.Value = oCPAGOSATNuevo.IMONTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMOPERACION", FbDbType.VarChar);
                if (!(bool)oCPAGOSATNuevo.isnull["INUMOPERACION"])
                {
                    auxPar.Value = oCPAGOSATNuevo.INUMOPERACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@RFCEMISORCTAORD", FbDbType.VarChar);
                if (!(bool)oCPAGOSATNuevo.isnull["IRFCEMISORCTAORD"])
                {
                    auxPar.Value = oCPAGOSATNuevo.IRFCEMISORCTAORD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMBANCOORDEXT", FbDbType.VarChar);
                if (!(bool)oCPAGOSATNuevo.isnull["INOMBANCOORDEXT"])
                {
                    auxPar.Value = oCPAGOSATNuevo.INOMBANCOORDEXT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CTAORDENANTE", FbDbType.VarChar);
                if (!(bool)oCPAGOSATNuevo.isnull["ICTAORDENANTE"])
                {
                    auxPar.Value = oCPAGOSATNuevo.ICTAORDENANTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@RFCEMISORCTABEN", FbDbType.VarChar);
                if (!(bool)oCPAGOSATNuevo.isnull["IRFCEMISORCTABEN"])
                {
                    auxPar.Value = oCPAGOSATNuevo.IRFCEMISORCTABEN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CTABENEFICIARIO", FbDbType.VarChar);
                if (!(bool)oCPAGOSATNuevo.isnull["ICTABENEFICIARIO"])
                {
                    auxPar.Value = oCPAGOSATNuevo.ICTABENEFICIARIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPOCADPAGO", FbDbType.VarChar);
                if (!(bool)oCPAGOSATNuevo.isnull["ITIPOCADPAGO"])
                {
                    auxPar.Value = oCPAGOSATNuevo.ITIPOCADPAGO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CERTPAGO", FbDbType.VarChar);
                if (!(bool)oCPAGOSATNuevo.isnull["ICERTPAGO"])
                {
                    auxPar.Value = oCPAGOSATNuevo.ICERTPAGO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CADPAGO", FbDbType.VarChar);
                if (!(bool)oCPAGOSATNuevo.isnull["ICADPAGO"])
                {
                    auxPar.Value = oCPAGOSATNuevo.ICADPAGO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SELLOPAGO", FbDbType.VarChar);
                if (!(bool)oCPAGOSATNuevo.isnull["ISELLOPAGO"])
                {
                    auxPar.Value = oCPAGOSATNuevo.ISELLOPAGO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCPAGOSATAnterior.isnull["IID"])
                {
                    auxPar.Value = oCPAGOSATAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  PAGOSAT
  set

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

DOCTOSATID=@DOCTOSATID,

FORMADEPAGOP=@FORMADEPAGOP,

MONEDAP=@MONEDAP,

TIPOCAMBIOP=@TIPOCAMBIOP,

MONTO=@MONTO,

NUMOPERACION=@NUMOPERACION,

RFCEMISORCTAORD=@RFCEMISORCTAORD,

NOMBANCOORDEXT=@NOMBANCOORDEXT,

CTAORDENANTE=@CTAORDENANTE,

RFCEMISORCTABEN=@RFCEMISORCTABEN,

CTABENEFICIARIO=@CTABENEFICIARIO,

TIPOCADPAGO=@TIPOCADPAGO,

CERTPAGO=@CERTPAGO,

CADPAGO=@CADPAGO,

SELLOPAGO=@SELLOPAGO
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


        public CPAGOSATBE seleccionarPAGOSAT(CPAGOSATBE oCPAGOSAT, FbTransaction st)
        {




            CPAGOSATBE retorno = new CPAGOSATBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from PAGOSAT where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPAGOSAT.IID;
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

                    if (dr["DOCTOSATID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOSATID = (long)(dr["DOCTOSATID"]);
                    }

                    if (dr["FECHAPAGO"] != System.DBNull.Value)
                    {
                        retorno.IFECHAPAGO = (DateTime)(dr["FECHAPAGO"]);
                    }

                    if (dr["FORMADEPAGOP"] != System.DBNull.Value)
                    {
                        retorno.IFORMADEPAGOP = (string)(dr["FORMADEPAGOP"]);
                    }

                    if (dr["MONEDAP"] != System.DBNull.Value)
                    {
                        retorno.IMONEDAP = (string)(dr["MONEDAP"]);
                    }

                    if (dr["TIPOCAMBIOP"] != System.DBNull.Value)
                    {
                        retorno.ITIPOCAMBIOP = (decimal)(dr["TIPOCAMBIOP"]);
                    }

                    if (dr["MONTO"] != System.DBNull.Value)
                    {
                        retorno.IMONTO = (decimal)(dr["MONTO"]);
                    }

                    if (dr["NUMOPERACION"] != System.DBNull.Value)
                    {
                        retorno.INUMOPERACION = (string)(dr["NUMOPERACION"]);
                    }

                    if (dr["RFCEMISORCTAORD"] != System.DBNull.Value)
                    {
                        retorno.IRFCEMISORCTAORD = (string)(dr["RFCEMISORCTAORD"]);
                    }

                    if (dr["NOMBANCOORDEXT"] != System.DBNull.Value)
                    {
                        retorno.INOMBANCOORDEXT = (string)(dr["NOMBANCOORDEXT"]);
                    }

                    if (dr["CTAORDENANTE"] != System.DBNull.Value)
                    {
                        retorno.ICTAORDENANTE = (string)(dr["CTAORDENANTE"]);
                    }

                    if (dr["RFCEMISORCTABEN"] != System.DBNull.Value)
                    {
                        retorno.IRFCEMISORCTABEN = (string)(dr["RFCEMISORCTABEN"]);
                    }

                    if (dr["CTABENEFICIARIO"] != System.DBNull.Value)
                    {
                        retorno.ICTABENEFICIARIO = (string)(dr["CTABENEFICIARIO"]);
                    }

                    if (dr["TIPOCADPAGO"] != System.DBNull.Value)
                    {
                        retorno.ITIPOCADPAGO = (string)(dr["TIPOCADPAGO"]);
                    }

                    if (dr["CERTPAGO"] != System.DBNull.Value)
                    {
                        retorno.ICERTPAGO = (string)(dr["CERTPAGO"]);
                    }

                    if (dr["CADPAGO"] != System.DBNull.Value)
                    {
                        retorno.ICADPAGO = (string)(dr["CADPAGO"]);
                    }

                    if (dr["SELLOPAGO"] != System.DBNull.Value)
                    {
                        retorno.ISELLOPAGO = (string)(dr["SELLOPAGO"]);
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




        public CPAGOSATBE seleccionarPAGOSATByDOCTO(long doctoId, FbTransaction st)
        {




            CPAGOSATBE retorno = new CPAGOSATBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from PAGOSAT where
 DOCTOSATID=@DOCTOSATID  ";


                auxPar = new FbParameter("@DOCTOSATID", FbDbType.BigInt);
                auxPar.Value = doctoId;
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

                    if (dr["DOCTOSATID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOSATID = (long)(dr["DOCTOSATID"]);
                    }

                    if (dr["FECHAPAGO"] != System.DBNull.Value)
                    {
                        retorno.IFECHAPAGO = (DateTime)(dr["FECHAPAGO"]);
                    }

                    if (dr["FORMADEPAGOP"] != System.DBNull.Value)
                    {
                        retorno.IFORMADEPAGOP = (string)(dr["FORMADEPAGOP"]);
                    }

                    if (dr["MONEDAP"] != System.DBNull.Value)
                    {
                        retorno.IMONEDAP = (string)(dr["MONEDAP"]);
                    }

                    if (dr["TIPOCAMBIOP"] != System.DBNull.Value)
                    {
                        retorno.ITIPOCAMBIOP = (decimal)(dr["TIPOCAMBIOP"]);
                    }

                    if (dr["MONTO"] != System.DBNull.Value)
                    {
                        retorno.IMONTO = (decimal)(dr["MONTO"]);
                    }

                    if (dr["NUMOPERACION"] != System.DBNull.Value)
                    {
                        retorno.INUMOPERACION = (string)(dr["NUMOPERACION"]);
                    }

                    if (dr["RFCEMISORCTAORD"] != System.DBNull.Value)
                    {
                        retorno.IRFCEMISORCTAORD = (string)(dr["RFCEMISORCTAORD"]);
                    }

                    if (dr["NOMBANCOORDEXT"] != System.DBNull.Value)
                    {
                        retorno.INOMBANCOORDEXT = (string)(dr["NOMBANCOORDEXT"]);
                    }

                    if (dr["CTAORDENANTE"] != System.DBNull.Value)
                    {
                        retorno.ICTAORDENANTE = (string)(dr["CTAORDENANTE"]);
                    }

                    if (dr["RFCEMISORCTABEN"] != System.DBNull.Value)
                    {
                        retorno.IRFCEMISORCTABEN = (string)(dr["RFCEMISORCTABEN"]);
                    }

                    if (dr["CTABENEFICIARIO"] != System.DBNull.Value)
                    {
                        retorno.ICTABENEFICIARIO = (string)(dr["CTABENEFICIARIO"]);
                    }

                    if (dr["TIPOCADPAGO"] != System.DBNull.Value)
                    {
                        retorno.ITIPOCADPAGO = (string)(dr["TIPOCADPAGO"]);
                    }

                    if (dr["CERTPAGO"] != System.DBNull.Value)
                    {
                        retorno.ICERTPAGO = (string)(dr["CERTPAGO"]);
                    }

                    if (dr["CADPAGO"] != System.DBNull.Value)
                    {
                        retorno.ICADPAGO = (string)(dr["CADPAGO"]);
                    }

                    if (dr["SELLOPAGO"] != System.DBNull.Value)
                    {
                        retorno.ISELLOPAGO = (string)(dr["SELLOPAGO"]);
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




        public DataSet enlistarPAGOSAT()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_PAGOSAT_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public DataSet enlistarCortoPAGOSAT()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_PAGOSAT_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public int ExistePAGOSAT(CPAGOSATBE oCPAGOSAT, FbTransaction st)
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
                auxPar.Value = oCPAGOSAT.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from PAGOSAT where

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




        public CPAGOSATBE AgregarPAGOSAT(CPAGOSATBE oCPAGOSAT, FbTransaction st)
        {
            try
            {
                int iRes = ExistePAGOSAT(oCPAGOSAT, st);
                if (iRes == 1)
                {
                    this.IComentario = "El PAGOSAT ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarPAGOSATD(oCPAGOSAT, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarPAGOSAT(CPAGOSATBE oCPAGOSAT, FbTransaction st)
        {
            try
            {
                int iRes = ExistePAGOSAT(oCPAGOSAT, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PAGOSAT no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarPAGOSATD(oCPAGOSAT, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarPAGOSAT(CPAGOSATBE oCPAGOSATNuevo, CPAGOSATBE oCPAGOSATAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExistePAGOSAT(oCPAGOSATAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PAGOSAT no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarPAGOSATD(oCPAGOSATNuevo, oCPAGOSATAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CPAGOSATD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
