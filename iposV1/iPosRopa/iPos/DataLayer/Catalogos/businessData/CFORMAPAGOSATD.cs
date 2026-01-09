

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

    public class CFORMAPAGOSATD
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


        public CFORMAPAGOSATBE AgregarFORMAPAGOSATD(CFORMAPAGOSATBE oCFORMAPAGOSAT, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCFORMAPAGOSAT.isnull["IID"])
                {
                    auxPar.Value = oCFORMAPAGOSAT.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCFORMAPAGOSAT.isnull["IACTIVO"])
                {
                    auxPar.Value = oCFORMAPAGOSAT.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCFORMAPAGOSAT.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCFORMAPAGOSAT.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCFORMAPAGOSAT.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCFORMAPAGOSAT.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCFORMAPAGOSAT.isnull["ICLAVE"])
                {
                    auxPar.Value = oCFORMAPAGOSAT.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCFORMAPAGOSAT.isnull["INOMBRE"])
                {
                    auxPar.Value = oCFORMAPAGOSAT.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FORMAPAGOID", FbDbType.BigInt);
                if (!(bool)oCFORMAPAGOSAT.isnull["IFORMAPAGOID"])
                {
                    auxPar.Value = oCFORMAPAGOSAT.IFORMAPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@SAT_BANCARIZADO", FbDbType.VarChar);
                if (!(bool)oCFORMAPAGOSAT.isnull["ISAT_BANCARIZADO"])
                {
                    auxPar.Value = oCFORMAPAGOSAT.ISAT_BANCARIZADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_NUMOPERACION", FbDbType.VarChar);
                if (!(bool)oCFORMAPAGOSAT.isnull["ISAT_NUMOPERACION"])
                {
                    auxPar.Value = oCFORMAPAGOSAT.ISAT_NUMOPERACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_RFCEMISORORDENANTE", FbDbType.VarChar);
                if (!(bool)oCFORMAPAGOSAT.isnull["ISAT_RFCEMISORORDENANTE"])
                {
                    auxPar.Value = oCFORMAPAGOSAT.ISAT_RFCEMISORORDENANTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_CUENTAORDENANTE", FbDbType.VarChar);
                if (!(bool)oCFORMAPAGOSAT.isnull["ISAT_CUENTAORDENANTE"])
                {
                    auxPar.Value = oCFORMAPAGOSAT.ISAT_CUENTAORDENANTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_PATRONORDENANTE", FbDbType.VarChar);
                if (!(bool)oCFORMAPAGOSAT.isnull["ISAT_PATRONORDENANTE"])
                {
                    auxPar.Value = oCFORMAPAGOSAT.ISAT_PATRONORDENANTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_RFCEMISORBENEFICIARIO", FbDbType.VarChar);
                if (!(bool)oCFORMAPAGOSAT.isnull["ISAT_RFCEMISORBENEFICIARIO"])
                {
                    auxPar.Value = oCFORMAPAGOSAT.ISAT_RFCEMISORBENEFICIARIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_CUENTABENEFICIARIO", FbDbType.VarChar);
                if (!(bool)oCFORMAPAGOSAT.isnull["ISAT_CUENTABENEFICIARIO"])
                {
                    auxPar.Value = oCFORMAPAGOSAT.ISAT_CUENTABENEFICIARIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_PATRONBENEFICIARIO", FbDbType.VarChar);
                if (!(bool)oCFORMAPAGOSAT.isnull["ISAT_PATRONBENEFICIARIO"])
                {
                    auxPar.Value = oCFORMAPAGOSAT.ISAT_PATRONBENEFICIARIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_TIPOCADENAPAGO", FbDbType.VarChar);
                if (!(bool)oCFORMAPAGOSAT.isnull["ISAT_TIPOCADENAPAGO"])
                {
                    auxPar.Value = oCFORMAPAGOSAT.ISAT_TIPOCADENAPAGO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_BANCOEMISOR", FbDbType.VarChar);
                if (!(bool)oCFORMAPAGOSAT.isnull["ISAT_BANCOEMISOR"])
                {
                    auxPar.Value = oCFORMAPAGOSAT.ISAT_BANCOEMISOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);





                string commandText = @"
        INSERT INTO FORMAPAGOSAT
      (
    
ID,

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

CLAVE,

NOMBRE,

FORMAPAGOID,

SAT_BANCARIZADO,

SAT_NUMOPERACION,

SAT_RFCEMISORORDENANTE,

SAT_CUENTAORDENANTE,

SAT_PATRONORDENANTE,

SAT_RFCEMISORBENEFICIARIO,

SAT_CUENTABENEFICIARIO,

SAT_PATRONBENEFICIARIO,

SAT_TIPOCADENAPAGO,

SAT_BANCOEMISOR
         )

Values (

@ID,

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@CLAVE,

@NOMBRE,

@FORMAPAGOID,

@SAT_BANCARIZADO,

@SAT_NUMOPERACION,

@SAT_RFCEMISORORDENANTE,

@SAT_CUENTAORDENANTE,

@SAT_PATRONORDENANTE,

@SAT_RFCEMISORBENEFICIARIO,

@SAT_CUENTABENEFICIARIO,

@SAT_PATRONBENEFICIARIO,

@SAT_TIPOCADENAPAGO,

@SAT_BANCOEMISOR
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCFORMAPAGOSAT;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarFORMAPAGOSATD(CFORMAPAGOSATBE oCFORMAPAGOSAT, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCFORMAPAGOSAT.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from FORMAPAGOSAT
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


        public bool CambiarFORMAPAGOSATD(CFORMAPAGOSATBE oCFORMAPAGOSATNuevo, CFORMAPAGOSATBE oCFORMAPAGOSATAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCFORMAPAGOSATNuevo.isnull["IID"])
                {
                    auxPar.Value = oCFORMAPAGOSATNuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCFORMAPAGOSATNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCFORMAPAGOSATNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCFORMAPAGOSATNuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCFORMAPAGOSATNuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCFORMAPAGOSATNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCFORMAPAGOSATNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCFORMAPAGOSATNuevo.isnull["ICLAVE"])
                {
                    auxPar.Value = oCFORMAPAGOSATNuevo.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCFORMAPAGOSATNuevo.isnull["INOMBRE"])
                {
                    auxPar.Value = oCFORMAPAGOSATNuevo.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FORMAPAGOID", FbDbType.BigInt);
                if (!(bool)oCFORMAPAGOSATNuevo.isnull["IFORMAPAGOID"])
                {
                    auxPar.Value = oCFORMAPAGOSATNuevo.IFORMAPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_BANCARIZADO", FbDbType.VarChar);
                if (!(bool)oCFORMAPAGOSATNuevo.isnull["ISAT_BANCARIZADO"])
                {
                    auxPar.Value = oCFORMAPAGOSATNuevo.ISAT_BANCARIZADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_NUMOPERACION", FbDbType.VarChar);
                if (!(bool)oCFORMAPAGOSATNuevo.isnull["ISAT_NUMOPERACION"])
                {
                    auxPar.Value = oCFORMAPAGOSATNuevo.ISAT_NUMOPERACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_RFCEMISORORDENANTE", FbDbType.VarChar);
                if (!(bool)oCFORMAPAGOSATNuevo.isnull["ISAT_RFCEMISORORDENANTE"])
                {
                    auxPar.Value = oCFORMAPAGOSATNuevo.ISAT_RFCEMISORORDENANTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_CUENTAORDENANTE", FbDbType.VarChar);
                if (!(bool)oCFORMAPAGOSATNuevo.isnull["ISAT_CUENTAORDENANTE"])
                {
                    auxPar.Value = oCFORMAPAGOSATNuevo.ISAT_CUENTAORDENANTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_PATRONORDENANTE", FbDbType.VarChar);
                if (!(bool)oCFORMAPAGOSATNuevo.isnull["ISAT_PATRONORDENANTE"])
                {
                    auxPar.Value = oCFORMAPAGOSATNuevo.ISAT_PATRONORDENANTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_RFCEMISORBENEFICIARIO", FbDbType.VarChar);
                if (!(bool)oCFORMAPAGOSATNuevo.isnull["ISAT_RFCEMISORBENEFICIARIO"])
                {
                    auxPar.Value = oCFORMAPAGOSATNuevo.ISAT_RFCEMISORBENEFICIARIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_CUENTABENEFICIARIO", FbDbType.VarChar);
                if (!(bool)oCFORMAPAGOSATNuevo.isnull["ISAT_CUENTABENEFICIARIO"])
                {
                    auxPar.Value = oCFORMAPAGOSATNuevo.ISAT_CUENTABENEFICIARIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_PATRONBENEFICIARIO", FbDbType.VarChar);
                if (!(bool)oCFORMAPAGOSATNuevo.isnull["ISAT_PATRONBENEFICIARIO"])
                {
                    auxPar.Value = oCFORMAPAGOSATNuevo.ISAT_PATRONBENEFICIARIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_TIPOCADENAPAGO", FbDbType.VarChar);
                if (!(bool)oCFORMAPAGOSATNuevo.isnull["ISAT_TIPOCADENAPAGO"])
                {
                    auxPar.Value = oCFORMAPAGOSATNuevo.ISAT_TIPOCADENAPAGO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_BANCOEMISOR", FbDbType.VarChar);
                if (!(bool)oCFORMAPAGOSATNuevo.isnull["ISAT_BANCOEMISOR"])
                {
                    auxPar.Value = oCFORMAPAGOSATNuevo.ISAT_BANCOEMISOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCFORMAPAGOSATAnterior.isnull["IID"])
                {
                    auxPar.Value = oCFORMAPAGOSATAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  FORMAPAGOSAT
  set

ID=@ID,

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

CLAVE=@CLAVE,

NOMBRE=@NOMBRE,

FORMAPAGOID=@FORMAPAGOID,

SAT_BANCARIZADO=@SAT_BANCARIZADO,

SAT_NUMOPERACION=@SAT_NUMOPERACION,

SAT_RFCEMISORORDENANTE=@SAT_RFCEMISORORDENANTE,

SAT_CUENTAORDENANTE=@SAT_CUENTAORDENANTE,

SAT_PATRONORDENANTE=@SAT_PATRONORDENANTE,

SAT_RFCEMISORBENEFICIARIO=@SAT_RFCEMISORBENEFICIARIO,

SAT_CUENTABENEFICIARIO=@SAT_CUENTABENEFICIARIO,

SAT_PATRONBENEFICIARIO=@SAT_PATRONBENEFICIARIO,

SAT_TIPOCADENAPAGO=@SAT_TIPOCADENAPAGO,

SAT_BANCOEMISOR=@SAT_BANCOEMISOR
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


        public CFORMAPAGOSATBE seleccionarFORMAPAGOSATXClave(CFORMAPAGOSATBE oCFORMAPAGOSAT, FbTransaction st)
        {




            CFORMAPAGOSATBE retorno = new CFORMAPAGOSATBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from FORMAPAGOSAT where CLAVE=@CLAVE  ";


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                auxPar.Value = oCFORMAPAGOSAT.ICLAVE;
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

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = (string)(dr["CLAVE"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (dr["FORMAPAGOID"] != System.DBNull.Value)
                    {
                        retorno.IFORMAPAGOID = (long)(dr["FORMAPAGOID"]);
                    }


                    if (dr["SAT_BANCARIZADO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_BANCARIZADO = (string)(dr["SAT_BANCARIZADO"]);
                    }

                    if (dr["SAT_NUMOPERACION"] != System.DBNull.Value)
                    {
                        retorno.ISAT_NUMOPERACION = (string)(dr["SAT_NUMOPERACION"]);
                    }

                    if (dr["SAT_RFCEMISORORDENANTE"] != System.DBNull.Value)
                    {
                        retorno.ISAT_RFCEMISORORDENANTE = (string)(dr["SAT_RFCEMISORORDENANTE"]);
                    }

                    if (dr["SAT_CUENTAORDENANTE"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CUENTAORDENANTE = (string)(dr["SAT_CUENTAORDENANTE"]);
                    }

                    if (dr["SAT_PATRONORDENANTE"] != System.DBNull.Value)
                    {
                        retorno.ISAT_PATRONORDENANTE = (string)(dr["SAT_PATRONORDENANTE"]);
                    }

                    if (dr["SAT_RFCEMISORBENEFICIARIO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_RFCEMISORBENEFICIARIO = (string)(dr["SAT_RFCEMISORBENEFICIARIO"]);
                    }

                    if (dr["SAT_CUENTABENEFICIARIO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CUENTABENEFICIARIO = (string)(dr["SAT_CUENTABENEFICIARIO"]);
                    }

                    if (dr["SAT_PATRONBENEFICIARIO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_PATRONBENEFICIARIO = (string)(dr["SAT_PATRONBENEFICIARIO"]);
                    }

                    if (dr["SAT_TIPOCADENAPAGO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_TIPOCADENAPAGO = (string)(dr["SAT_TIPOCADENAPAGO"]);
                    }

                    if (dr["SAT_BANCOEMISOR"] != System.DBNull.Value)
                    {
                        retorno.ISAT_BANCOEMISOR = (string)(dr["SAT_BANCOEMISOR"]);
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



        public CFORMAPAGOSATBE seleccionarFORMAPAGOSAT(CFORMAPAGOSATBE oCFORMAPAGOSAT, FbTransaction st)
        {




            CFORMAPAGOSATBE retorno = new CFORMAPAGOSATBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from FORMAPAGOSAT where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCFORMAPAGOSAT.IID;
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

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = (string)(dr["CLAVE"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (dr["FORMAPAGOID"] != System.DBNull.Value)
                    {
                        retorno.IFORMAPAGOID = (long)(dr["FORMAPAGOID"]);
                    }


                    if (dr["SAT_BANCARIZADO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_BANCARIZADO = (string)(dr["SAT_BANCARIZADO"]);
                    }

                    if (dr["SAT_NUMOPERACION"] != System.DBNull.Value)
                    {
                        retorno.ISAT_NUMOPERACION = (string)(dr["SAT_NUMOPERACION"]);
                    }

                    if (dr["SAT_RFCEMISORORDENANTE"] != System.DBNull.Value)
                    {
                        retorno.ISAT_RFCEMISORORDENANTE = (string)(dr["SAT_RFCEMISORORDENANTE"]);
                    }

                    if (dr["SAT_CUENTAORDENANTE"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CUENTAORDENANTE = (string)(dr["SAT_CUENTAORDENANTE"]);
                    }

                    if (dr["SAT_PATRONORDENANTE"] != System.DBNull.Value)
                    {
                        retorno.ISAT_PATRONORDENANTE = (string)(dr["SAT_PATRONORDENANTE"]);
                    }

                    if (dr["SAT_RFCEMISORBENEFICIARIO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_RFCEMISORBENEFICIARIO = (string)(dr["SAT_RFCEMISORBENEFICIARIO"]);
                    }

                    if (dr["SAT_CUENTABENEFICIARIO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CUENTABENEFICIARIO = (string)(dr["SAT_CUENTABENEFICIARIO"]);
                    }

                    if (dr["SAT_PATRONBENEFICIARIO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_PATRONBENEFICIARIO = (string)(dr["SAT_PATRONBENEFICIARIO"]);
                    }

                    if (dr["SAT_TIPOCADENAPAGO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_TIPOCADENAPAGO = (string)(dr["SAT_TIPOCADENAPAGO"]);
                    }

                    if (dr["SAT_BANCOEMISOR"] != System.DBNull.Value)
                    {
                        retorno.ISAT_BANCOEMISOR = (string)(dr["SAT_BANCOEMISOR"]);
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


        public DataSet enlistarFORMAPAGOSAT()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_FORMAPAGOSAT_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public DataSet enlistarCortoFORMAPAGOSAT()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_FORMAPAGOSAT_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public int ExisteFORMAPAGOSAT(CFORMAPAGOSATBE oCFORMAPAGOSAT, FbTransaction st)
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
                auxPar.Value = oCFORMAPAGOSAT.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from FORMAPAGOSAT where

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




        public CFORMAPAGOSATBE AgregarFORMAPAGOSAT(CFORMAPAGOSATBE oCFORMAPAGOSAT, FbTransaction st)
        {
            try
            {
                int iRes = ExisteFORMAPAGOSAT(oCFORMAPAGOSAT, st);
                if (iRes == 1)
                {
                    this.IComentario = "El FORMAPAGOSAT ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarFORMAPAGOSATD(oCFORMAPAGOSAT, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarFORMAPAGOSAT(CFORMAPAGOSATBE oCFORMAPAGOSAT, FbTransaction st)
        {
            try
            {
                int iRes = ExisteFORMAPAGOSAT(oCFORMAPAGOSAT, st);
                if (iRes == 0)
                {
                    this.IComentario = "El FORMAPAGOSAT no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarFORMAPAGOSATD(oCFORMAPAGOSAT, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarFORMAPAGOSAT(CFORMAPAGOSATBE oCFORMAPAGOSATNuevo, CFORMAPAGOSATBE oCFORMAPAGOSATAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteFORMAPAGOSAT(oCFORMAPAGOSATAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El FORMAPAGOSAT no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarFORMAPAGOSATD(oCFORMAPAGOSATNuevo, oCFORMAPAGOSATAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }




        public CFORMAPAGOSATD(string cadenaConexion)
        {
            this.sCadenaConexion = cadenaConexion;
        }


        public CFORMAPAGOSATD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
