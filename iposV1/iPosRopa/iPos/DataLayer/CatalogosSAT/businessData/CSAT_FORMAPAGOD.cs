

//using System;
//using Microsoft.ApplicationBlocks.Data;
//using iPosBusinessEntity;
//using System.EnterpriseServices;
//using System.Runtime.InteropServices;
//using FirebirdSql.Data.FirebirdClient;
//using System.Data;
//using System.Collections;
//using ConexionesBD;

//namespace iPosData
//{



//    public class CSAT_FORMAPAGOD
//    {
//        private string sCadenaConexion;

//        private string iComentario;
//        public string IComentario
//        {
//            get
//            {
//                return this.iComentario;
//            }
//            set
//            {
//                this.iComentario = value;
//            }
//        }

//        protected string iComentarioAdicional;
//        public string IComentarioAdicional
//        {
//            get
//            {
//                return this.iComentarioAdicional;
//            }
//            set
//            {
//                this.iComentarioAdicional = value;
//            }
//        }


//        public CSAT_FORMAPAGOBE AgregarSAT_FORMAPAGOD(CSAT_FORMAPAGOBE oCSAT_FORMAPAGO, FbTransaction st)
//        {


//            try
//            {



//                System.Collections.ArrayList parts = new ArrayList();
//                FbParameter auxPar;



//                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
//                if (!(bool)oCSAT_FORMAPAGO.isnull["IACTIVO"])
//                {
//                    auxPar.Value = oCSAT_FORMAPAGO.IACTIVO;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);


//                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
//                if (!(bool)oCSAT_FORMAPAGO.isnull["ICREADOPOR_USERID"])
//                {
//                    auxPar.Value = oCSAT_FORMAPAGO.ICREADOPOR_USERID;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);


//                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
//                if (!(bool)oCSAT_FORMAPAGO.isnull["IMODIFICADOPOR_USERID"])
//                {
//                    auxPar.Value = oCSAT_FORMAPAGO.IMODIFICADOPOR_USERID;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);


//                auxPar = new FbParameter("@SAT_CLAVE", FbDbType.VarChar);
//                if (!(bool)oCSAT_FORMAPAGO.isnull["ISAT_CLAVE"])
//                {
//                    auxPar.Value = oCSAT_FORMAPAGO.ISAT_CLAVE;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);


//                auxPar = new FbParameter("@SAT_DESCRIPCION", FbDbType.VarChar);
//                if (!(bool)oCSAT_FORMAPAGO.isnull["ISAT_DESCRIPCION"])
//                {
//                    auxPar.Value = oCSAT_FORMAPAGO.ISAT_DESCRIPCION;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);


//                auxPar = new FbParameter("@SAT_BANCARIZADO", FbDbType.VarChar);
//                if (!(bool)oCSAT_FORMAPAGO.isnull["ISAT_BANCARIZADO"])
//                {
//                    auxPar.Value = oCSAT_FORMAPAGO.ISAT_BANCARIZADO;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);


//                auxPar = new FbParameter("@SAT_NUMOPERACION", FbDbType.VarChar);
//                if (!(bool)oCSAT_FORMAPAGO.isnull["ISAT_NUMOPERACION"])
//                {
//                    auxPar.Value = oCSAT_FORMAPAGO.ISAT_NUMOPERACION;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);


//                auxPar = new FbParameter("@SAT_RFCEMISORORDENANTE", FbDbType.VarChar);
//                if (!(bool)oCSAT_FORMAPAGO.isnull["ISAT_RFCEMISORORDENANTE"])
//                {
//                    auxPar.Value = oCSAT_FORMAPAGO.ISAT_RFCEMISORORDENANTE;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);


//                auxPar = new FbParameter("@SAT_CUENTAORDENANTE", FbDbType.VarChar);
//                if (!(bool)oCSAT_FORMAPAGO.isnull["ISAT_CUENTAORDENANTE"])
//                {
//                    auxPar.Value = oCSAT_FORMAPAGO.ISAT_CUENTAORDENANTE;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);


//                auxPar = new FbParameter("@SAT_PATRONORDENANTE", FbDbType.VarChar);
//                if (!(bool)oCSAT_FORMAPAGO.isnull["ISAT_PATRONORDENANTE"])
//                {
//                    auxPar.Value = oCSAT_FORMAPAGO.ISAT_PATRONORDENANTE;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);


//                auxPar = new FbParameter("@SAT_RFCEMISORBENEFICIARIO", FbDbType.VarChar);
//                if (!(bool)oCSAT_FORMAPAGO.isnull["ISAT_RFCEMISORBENEFICIARIO"])
//                {
//                    auxPar.Value = oCSAT_FORMAPAGO.ISAT_RFCEMISORBENEFICIARIO;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);


//                auxPar = new FbParameter("@SAT_CUENTABENEFICIARIO", FbDbType.VarChar);
//                if (!(bool)oCSAT_FORMAPAGO.isnull["ISAT_CUENTABENEFICIARIO"])
//                {
//                    auxPar.Value = oCSAT_FORMAPAGO.ISAT_CUENTABENEFICIARIO;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);


//                auxPar = new FbParameter("@SAT_PATRONBENEFICIARIO", FbDbType.VarChar);
//                if (!(bool)oCSAT_FORMAPAGO.isnull["ISAT_PATRONBENEFICIARIO"])
//                {
//                    auxPar.Value = oCSAT_FORMAPAGO.ISAT_PATRONBENEFICIARIO;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);


//                auxPar = new FbParameter("@SAT_TIPOCADENAPAGO", FbDbType.VarChar);
//                if (!(bool)oCSAT_FORMAPAGO.isnull["ISAT_TIPOCADENAPAGO"])
//                {
//                    auxPar.Value = oCSAT_FORMAPAGO.ISAT_TIPOCADENAPAGO;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);


//                auxPar = new FbParameter("@SAT_BANCOEMISOR", FbDbType.VarChar);
//                if (!(bool)oCSAT_FORMAPAGO.isnull["ISAT_BANCOEMISOR"])
//                {
//                    auxPar.Value = oCSAT_FORMAPAGO.ISAT_BANCOEMISOR;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);


//                string commandText = @"
//        INSERT INTO SAT_FORMAPAGO
//      (
//    
//ACTIVO,
//
//CREADOPOR_USERID,
//
//MODIFICADOPOR_USERID,
//
//SAT_CLAVE,
//
//SAT_DESCRIPCION,
//
//SAT_BANCARIZADO,
//
//SAT_NUMOPERACION,
//
//SAT_RFCEMISORORDENANTE,
//
//SAT_CUENTAORDENANTE,
//
//SAT_PATRONORDENANTE,
//
//SAT_RFCEMISORBENEFICIARIO,
//
//SAT_CUENTABENEFICIARIO,
//
//SAT_PATRONBENEFICIARIO,
//
//SAT_TIPOCADENAPAGO,
//
//SAT_BANCOEMISOR
//         )
//
//Values (
//
//@ACTIVO,
//
//@CREADOPOR_USERID,
//
//@MODIFICADOPOR_USERID,
//
//@SAT_CLAVE,
//
//@SAT_DESCRIPCION,
//
//@SAT_BANCARIZADO,
//
//@SAT_NUMOPERACION,
//
//@SAT_RFCEMISORORDENANTE,
//
//@SAT_CUENTAORDENANTE,
//
//@SAT_PATRONORDENANTE,
//
//@SAT_RFCEMISORBENEFICIARIO,
//
//@SAT_CUENTABENEFICIARIO,
//
//@SAT_PATRONBENEFICIARIO,
//
//@SAT_TIPOCADENAPAGO,
//
//@SAT_BANCOEMISOR
//); ";

//                FbParameter[] arParms = new FbParameter[parts.Count];
//                parts.CopyTo(arParms, 0);

//                if (st == null)
//                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
//                else
//                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






//                return oCSAT_FORMAPAGO;

//            }
//            catch (Exception e)
//            {
//                this.iComentario = e.Message + e.StackTrace;
//                return null;
//            }
//        }


//        public bool BorrarSAT_FORMAPAGOD(CSAT_FORMAPAGOBE oCSAT_FORMAPAGO, FbTransaction st)
//        {


//            try
//            {
//                System.Collections.ArrayList parts = new ArrayList();
//                FbParameter auxPar;



//                auxPar = new FbParameter("@ID", FbDbType.BigInt);
//                auxPar.Value = oCSAT_FORMAPAGO.IID;
//                parts.Add(auxPar);



//                string commandText = @"  Delete from SAT_FORMAPAGO
//  where
//
//  ID=@ID
//  ;";

//                FbParameter[] arParms = new FbParameter[parts.Count];
//                parts.CopyTo(arParms, 0);

//                if (st == null)
//                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
//                else
//                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


//                return true;




//            }
//            catch (Exception e)
//            {
//                this.iComentario = e.Message + e.StackTrace;
//                return false;
//            }
//        }


//        public bool CambiarSAT_FORMAPAGOD(CSAT_FORMAPAGOBE oCSAT_FORMAPAGONuevo, CSAT_FORMAPAGOBE oCSAT_FORMAPAGOAnterior, FbTransaction st)
//        {


//            try
//            {
//                System.Collections.ArrayList parts = new ArrayList();
//                FbParameter auxPar;



//                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
//                if (!(bool)oCSAT_FORMAPAGONuevo.isnull["IACTIVO"])
//                {
//                    auxPar.Value = oCSAT_FORMAPAGONuevo.IACTIVO;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);

//                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
//                if (!(bool)oCSAT_FORMAPAGONuevo.isnull["ICREADOPOR_USERID"])
//                {
//                    auxPar.Value = oCSAT_FORMAPAGONuevo.ICREADOPOR_USERID;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);

//                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
//                if (!(bool)oCSAT_FORMAPAGONuevo.isnull["IMODIFICADOPOR_USERID"])
//                {
//                    auxPar.Value = oCSAT_FORMAPAGONuevo.IMODIFICADOPOR_USERID;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);

//                auxPar = new FbParameter("@SAT_CLAVE", FbDbType.VarChar);
//                if (!(bool)oCSAT_FORMAPAGONuevo.isnull["ISAT_CLAVE"])
//                {
//                    auxPar.Value = oCSAT_FORMAPAGONuevo.ISAT_CLAVE;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);

//                auxPar = new FbParameter("@SAT_DESCRIPCION", FbDbType.VarChar);
//                if (!(bool)oCSAT_FORMAPAGONuevo.isnull["ISAT_DESCRIPCION"])
//                {
//                    auxPar.Value = oCSAT_FORMAPAGONuevo.ISAT_DESCRIPCION;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);

//                auxPar = new FbParameter("@SAT_BANCARIZADO", FbDbType.VarChar);
//                if (!(bool)oCSAT_FORMAPAGONuevo.isnull["ISAT_BANCARIZADO"])
//                {
//                    auxPar.Value = oCSAT_FORMAPAGONuevo.ISAT_BANCARIZADO;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);

//                auxPar = new FbParameter("@SAT_NUMOPERACION", FbDbType.VarChar);
//                if (!(bool)oCSAT_FORMAPAGONuevo.isnull["ISAT_NUMOPERACION"])
//                {
//                    auxPar.Value = oCSAT_FORMAPAGONuevo.ISAT_NUMOPERACION;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);

//                auxPar = new FbParameter("@SAT_RFCEMISORORDENANTE", FbDbType.VarChar);
//                if (!(bool)oCSAT_FORMAPAGONuevo.isnull["ISAT_RFCEMISORORDENANTE"])
//                {
//                    auxPar.Value = oCSAT_FORMAPAGONuevo.ISAT_RFCEMISORORDENANTE;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);

//                auxPar = new FbParameter("@SAT_CUENTAORDENANTE", FbDbType.VarChar);
//                if (!(bool)oCSAT_FORMAPAGONuevo.isnull["ISAT_CUENTAORDENANTE"])
//                {
//                    auxPar.Value = oCSAT_FORMAPAGONuevo.ISAT_CUENTAORDENANTE;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);

//                auxPar = new FbParameter("@SAT_PATRONORDENANTE", FbDbType.VarChar);
//                if (!(bool)oCSAT_FORMAPAGONuevo.isnull["ISAT_PATRONORDENANTE"])
//                {
//                    auxPar.Value = oCSAT_FORMAPAGONuevo.ISAT_PATRONORDENANTE;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);

//                auxPar = new FbParameter("@SAT_RFCEMISORBENEFICIARIO", FbDbType.VarChar);
//                if (!(bool)oCSAT_FORMAPAGONuevo.isnull["ISAT_RFCEMISORBENEFICIARIO"])
//                {
//                    auxPar.Value = oCSAT_FORMAPAGONuevo.ISAT_RFCEMISORBENEFICIARIO;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);

//                auxPar = new FbParameter("@SAT_CUENTABENEFICIARIO", FbDbType.VarChar);
//                if (!(bool)oCSAT_FORMAPAGONuevo.isnull["ISAT_CUENTABENEFICIARIO"])
//                {
//                    auxPar.Value = oCSAT_FORMAPAGONuevo.ISAT_CUENTABENEFICIARIO;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);

//                auxPar = new FbParameter("@SAT_PATRONBENEFICIARIO", FbDbType.VarChar);
//                if (!(bool)oCSAT_FORMAPAGONuevo.isnull["ISAT_PATRONBENEFICIARIO"])
//                {
//                    auxPar.Value = oCSAT_FORMAPAGONuevo.ISAT_PATRONBENEFICIARIO;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);

//                auxPar = new FbParameter("@SAT_TIPOCADENAPAGO", FbDbType.VarChar);
//                if (!(bool)oCSAT_FORMAPAGONuevo.isnull["ISAT_TIPOCADENAPAGO"])
//                {
//                    auxPar.Value = oCSAT_FORMAPAGONuevo.ISAT_TIPOCADENAPAGO;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);

//                auxPar = new FbParameter("@SAT_BANCOEMISOR", FbDbType.VarChar);
//                if (!(bool)oCSAT_FORMAPAGONuevo.isnull["ISAT_BANCOEMISOR"])
//                {
//                    auxPar.Value = oCSAT_FORMAPAGONuevo.ISAT_BANCOEMISOR;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);

//                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
//                if (!(bool)oCSAT_FORMAPAGOAnterior.isnull["IID"])
//                {
//                    auxPar.Value = oCSAT_FORMAPAGOAnterior.IID;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);




//                string commandText = @"
//  update  SAT_FORMAPAGO
//  set
//
//ACTIVO=@ACTIVO,
//
//CREADOPOR_USERID=@CREADOPOR_USERID,
//
//MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,
//
//SAT_CLAVE=@SAT_CLAVE,
//
//SAT_DESCRIPCION=@SAT_DESCRIPCION,
//
//SAT_BANCARIZADO=@SAT_BANCARIZADO,
//
//SAT_NUMOPERACION=@SAT_NUMOPERACION,
//
//SAT_RFCEMISORORDENANTE=@SAT_RFCEMISORORDENANTE,
//
//SAT_CUENTAORDENANTE=@SAT_CUENTAORDENANTE,
//
//SAT_PATRONORDENANTE=@SAT_PATRONORDENANTE,
//
//SAT_RFCEMISORBENEFICIARIO=@SAT_RFCEMISORBENEFICIARIO,
//
//SAT_CUENTABENEFICIARIO=@SAT_CUENTABENEFICIARIO,
//
//SAT_PATRONBENEFICIARIO=@SAT_PATRONBENEFICIARIO,
//
//SAT_TIPOCADENAPAGO=@SAT_TIPOCADENAPAGO,
//
//SAT_BANCOEMISOR=@SAT_BANCOEMISOR
//  where 
//
//ID=@IDAnt
//  ;";

//                FbParameter[] arParms = new FbParameter[parts.Count];
//                parts.CopyTo(arParms, 0);


//                if (st == null)
//                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
//                else
//                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


//                return true;


//            }
//            catch (Exception e)
//            {
//                this.iComentario = e.Message + e.StackTrace;
//                return false;
//            }
//        }


//        public CSAT_FORMAPAGOBE seleccionarSAT_FORMAPAGO(CSAT_FORMAPAGOBE oCSAT_FORMAPAGO, FbTransaction st)
//        {




//            CSAT_FORMAPAGOBE retorno = new CSAT_FORMAPAGOBE();
//            FbDataReader dr = null;

//            FbConnection pcn = null;

//            try
//            {

//                System.Collections.ArrayList parts = new ArrayList();
//                FbParameter auxPar;

//                String CmdTxt = @"select * from SAT_FORMAPAGO where
// ID=@ID  ";


//                auxPar = new FbParameter("@ID", FbDbType.BigInt);
//                auxPar.Value = oCSAT_FORMAPAGO.IID;
//                parts.Add(auxPar);




//                FbParameter[] arParms = new FbParameter[parts.Count];
//                parts.CopyTo(arParms, 0);



//                if (st == null)
//                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
//                else
//                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


//                if (dr.Read())
//                {

//                    if (dr["ID"] != System.DBNull.Value)
//                    {
//                        retorno.IID = (long)(dr["ID"]);
//                    }

//                    if (dr["ACTIVO"] != System.DBNull.Value)
//                    {
//                        retorno.IACTIVO = (string)(dr["ACTIVO"]);
//                    }

//                    if (dr["CREADO"] != System.DBNull.Value)
//                    {
//                        retorno.ICREADO = (object)(dr["CREADO"]);
//                    }

//                    if (dr["CREADOPOR_USERID"] != System.DBNull.Value)
//                    {
//                        retorno.ICREADOPOR_USERID = (long)(dr["CREADOPOR_USERID"]);
//                    }

//                    if (dr["MODIFICADO"] != System.DBNull.Value)
//                    {
//                        retorno.IMODIFICADO = (object)(dr["MODIFICADO"]);
//                    }

//                    if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
//                    {
//                        retorno.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
//                    }

//                    if (dr["SAT_CLAVE"] != System.DBNull.Value)
//                    {
//                        retorno.ISAT_CLAVE = (string)(dr["SAT_CLAVE"]);
//                    }

//                    if (dr["SAT_DESCRIPCION"] != System.DBNull.Value)
//                    {
//                        retorno.ISAT_DESCRIPCION = (string)(dr["SAT_DESCRIPCION"]);
//                    }

//                    if (dr["SAT_BANCARIZADO"] != System.DBNull.Value)
//                    {
//                        retorno.ISAT_BANCARIZADO = (string)(dr["SAT_BANCARIZADO"]);
//                    }

//                    if (dr["SAT_NUMOPERACION"] != System.DBNull.Value)
//                    {
//                        retorno.ISAT_NUMOPERACION = (string)(dr["SAT_NUMOPERACION"]);
//                    }

//                    if (dr["SAT_RFCEMISORORDENANTE"] != System.DBNull.Value)
//                    {
//                        retorno.ISAT_RFCEMISORORDENANTE = (string)(dr["SAT_RFCEMISORORDENANTE"]);
//                    }

//                    if (dr["SAT_CUENTAORDENANTE"] != System.DBNull.Value)
//                    {
//                        retorno.ISAT_CUENTAORDENANTE = (string)(dr["SAT_CUENTAORDENANTE"]);
//                    }

//                    if (dr["SAT_PATRONORDENANTE"] != System.DBNull.Value)
//                    {
//                        retorno.ISAT_PATRONORDENANTE = (string)(dr["SAT_PATRONORDENANTE"]);
//                    }

//                    if (dr["SAT_RFCEMISORBENEFICIARIO"] != System.DBNull.Value)
//                    {
//                        retorno.ISAT_RFCEMISORBENEFICIARIO = (string)(dr["SAT_RFCEMISORBENEFICIARIO"]);
//                    }

//                    if (dr["SAT_CUENTABENEFICIARIO"] != System.DBNull.Value)
//                    {
//                        retorno.ISAT_CUENTABENEFICIARIO = (string)(dr["SAT_CUENTABENEFICIARIO"]);
//                    }

//                    if (dr["SAT_PATRONBENEFICIARIO"] != System.DBNull.Value)
//                    {
//                        retorno.ISAT_PATRONBENEFICIARIO = (string)(dr["SAT_PATRONBENEFICIARIO"]);
//                    }

//                    if (dr["SAT_TIPOCADENAPAGO"] != System.DBNull.Value)
//                    {
//                        retorno.ISAT_TIPOCADENAPAGO = (string)(dr["SAT_TIPOCADENAPAGO"]);
//                    }

//                    if (dr["SAT_BANCOEMISOR"] != System.DBNull.Value)
//                    {
//                        retorno.ISAT_BANCOEMISOR = (string)(dr["SAT_BANCOEMISOR"]);
//                    }

//                }
//                else
//                {
//                    retorno = null;
//                }

//                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

//                return retorno;
//            }
//            catch (Exception e)
//            {
//                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
//                this.iComentario = e.Message + e.StackTrace;
//                return null;
//            }



//        }







//        public CSAT_FORMAPAGOBE seleccionarSAT_FORMAPAGO_X_CLAVE(CSAT_FORMAPAGOBE oCSAT_FORMAPAGO, FbTransaction st)
//        {




//            CSAT_FORMAPAGOBE retorno = new CSAT_FORMAPAGOBE();
//            FbDataReader dr = null;

//            FbConnection pcn = null;

//            try
//            {

//                System.Collections.ArrayList parts = new ArrayList();
//                FbParameter auxPar;

//                String CmdTxt = @"select * from SAT_FORMAPAGO where SAT_CLAVE = @SAT_CLAVE  ";


//                auxPar = new FbParameter("@SAT_CLAVE", FbDbType.VarChar);
//                auxPar.Value = oCSAT_FORMAPAGO.ISAT_CLAVE;
//                parts.Add(auxPar);




//                FbParameter[] arParms = new FbParameter[parts.Count];
//                parts.CopyTo(arParms, 0);



//                if (st == null)
//                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
//                else
//                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


//                if (dr.Read())
//                {

//                    if (dr["ID"] != System.DBNull.Value)
//                    {
//                        retorno.IID = (long)(dr["ID"]);
//                    }

//                    if (dr["ACTIVO"] != System.DBNull.Value)
//                    {
//                        retorno.IACTIVO = (string)(dr["ACTIVO"]);
//                    }

//                    if (dr["CREADO"] != System.DBNull.Value)
//                    {
//                        retorno.ICREADO = (object)(dr["CREADO"]);
//                    }

//                    if (dr["CREADOPOR_USERID"] != System.DBNull.Value)
//                    {
//                        retorno.ICREADOPOR_USERID = (long)(dr["CREADOPOR_USERID"]);
//                    }

//                    if (dr["MODIFICADO"] != System.DBNull.Value)
//                    {
//                        retorno.IMODIFICADO = (object)(dr["MODIFICADO"]);
//                    }

//                    if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
//                    {
//                        retorno.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
//                    }

//                    if (dr["SAT_CLAVE"] != System.DBNull.Value)
//                    {
//                        retorno.ISAT_CLAVE = (string)(dr["SAT_CLAVE"]);
//                    }

//                    if (dr["SAT_DESCRIPCION"] != System.DBNull.Value)
//                    {
//                        retorno.ISAT_DESCRIPCION = (string)(dr["SAT_DESCRIPCION"]);
//                    }

//                    if (dr["SAT_BANCARIZADO"] != System.DBNull.Value)
//                    {
//                        retorno.ISAT_BANCARIZADO = (string)(dr["SAT_BANCARIZADO"]);
//                    }

//                    if (dr["SAT_NUMOPERACION"] != System.DBNull.Value)
//                    {
//                        retorno.ISAT_NUMOPERACION = (string)(dr["SAT_NUMOPERACION"]);
//                    }

//                    if (dr["SAT_RFCEMISORORDENANTE"] != System.DBNull.Value)
//                    {
//                        retorno.ISAT_RFCEMISORORDENANTE = (string)(dr["SAT_RFCEMISORORDENANTE"]);
//                    }

//                    if (dr["SAT_CUENTAORDENANTE"] != System.DBNull.Value)
//                    {
//                        retorno.ISAT_CUENTAORDENANTE = (string)(dr["SAT_CUENTAORDENANTE"]);
//                    }

//                    if (dr["SAT_PATRONORDENANTE"] != System.DBNull.Value)
//                    {
//                        retorno.ISAT_PATRONORDENANTE = (string)(dr["SAT_PATRONORDENANTE"]);
//                    }

//                    if (dr["SAT_RFCEMISORBENEFICIARIO"] != System.DBNull.Value)
//                    {
//                        retorno.ISAT_RFCEMISORBENEFICIARIO = (string)(dr["SAT_RFCEMISORBENEFICIARIO"]);
//                    }

//                    if (dr["SAT_CUENTABENEFICIARIO"] != System.DBNull.Value)
//                    {
//                        retorno.ISAT_CUENTABENEFICIARIO = (string)(dr["SAT_CUENTABENEFICIARIO"]);
//                    }

//                    if (dr["SAT_PATRONBENEFICIARIO"] != System.DBNull.Value)
//                    {
//                        retorno.ISAT_PATRONBENEFICIARIO = (string)(dr["SAT_PATRONBENEFICIARIO"]);
//                    }

//                    if (dr["SAT_TIPOCADENAPAGO"] != System.DBNull.Value)
//                    {
//                        retorno.ISAT_TIPOCADENAPAGO = (string)(dr["SAT_TIPOCADENAPAGO"]);
//                    }

//                    if (dr["SAT_BANCOEMISOR"] != System.DBNull.Value)
//                    {
//                        retorno.ISAT_BANCOEMISOR = (string)(dr["SAT_BANCOEMISOR"]);
//                    }

//                }
//                else
//                {
//                    retorno = null;
//                }

//                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

//                return retorno;
//            }
//            catch (Exception e)
//            {
//                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
//                this.iComentario = e.Message + e.StackTrace;
//                return null;
//            }



//        }







//        public DataSet enlistarSAT_FORMAPAGO()
//        {

//            DataSet retorno;
//            try
//            {
//                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_SAT_FORMAPAGO_enlistar");

//                return retorno;
//            }
//            catch (Exception e)
//            {
//                this.iComentario = e.Message + e.StackTrace;
//                return null;
//            }



//        }




//        public DataSet enlistarCortoSAT_FORMAPAGO()
//        {
//            DataSet retorno;
//            try
//            {

//                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_SAT_FORMAPAGO_enlistarCorto");

//                return retorno;
//            }
//            catch (Exception e)
//            {
//                this.iComentario = e.Message + e.StackTrace;
//                return null;
//            }



//        }



//        public int ExisteSAT_FORMAPAGO(CSAT_FORMAPAGOBE oCSAT_FORMAPAGO, FbTransaction st)
//        {
//            //1-EXISTE 0-NO EXISTE -1 ERROR
//            int retorno;
//            FbDataReader dr = null;

//            FbConnection pcn = null;

//            try
//            {
//                System.Collections.ArrayList parts = new ArrayList();
//                FbParameter auxPar;



//                auxPar = new FbParameter("@ID", FbDbType.BigInt);
//                auxPar.Value = oCSAT_FORMAPAGO.IID;
//                parts.Add(auxPar);

//                FbParameter[] arParms = new FbParameter[parts.Count];
//                parts.CopyTo(arParms, 0);

//                string commandText = @"select 1 EXISTE
//  from RDB$DATABASE
//  where exists(
//  select * from SAT_FORMAPAGO where
//
//  ID=@ID  
//  );";






//                if (st == null)
//                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, out pcn, arParms);
//                else
//                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, commandText, arParms);



//                if (dr.Read())
//                {
//                    retorno = 1;
//                }
//                else
//                {
//                    retorno = 0;
//                }

//                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
//                return retorno;
//            }
//            catch (Exception e)
//            {
//                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
//                this.iComentario = e.Message + e.StackTrace;
//                return -1;
//            }
//        }




//        public CSAT_FORMAPAGOBE AgregarSAT_FORMAPAGO(CSAT_FORMAPAGOBE oCSAT_FORMAPAGO, FbTransaction st)
//        {
//            try
//            {
//                int iRes = ExisteSAT_FORMAPAGO(oCSAT_FORMAPAGO, st);
//                if (iRes == 1)
//                {
//                    this.IComentario = "El SAT_FORMAPAGO ya existe";
//                    return null;
//                }
//                else if (iRes == -1)
//                {
//                    return null;
//                }
//                return AgregarSAT_FORMAPAGOD(oCSAT_FORMAPAGO, st);
//            }
//            catch (Exception e)
//            {
//                this.iComentario = e.Message + e.StackTrace;
//                return null;
//            }
//        }


//        public bool BorrarSAT_FORMAPAGO(CSAT_FORMAPAGOBE oCSAT_FORMAPAGO, FbTransaction st)
//        {
//            try
//            {
//                int iRes = ExisteSAT_FORMAPAGO(oCSAT_FORMAPAGO, st);
//                if (iRes == 0)
//                {
//                    this.IComentario = "El SAT_FORMAPAGO no existe";
//                    return false;
//                }
//                else if (iRes == -1)
//                {
//                    return false;
//                }
//                return BorrarSAT_FORMAPAGOD(oCSAT_FORMAPAGO, st);
//            }
//            catch (Exception e)
//            {
//                this.iComentario = e.Message + e.StackTrace;
//                return false;
//            }

//        }


//        public bool CambiarSAT_FORMAPAGO(CSAT_FORMAPAGOBE oCSAT_FORMAPAGONuevo, CSAT_FORMAPAGOBE oCSAT_FORMAPAGOAnterior, FbTransaction st)
//        {
//            try
//            {
//                int iRes = ExisteSAT_FORMAPAGO(oCSAT_FORMAPAGOAnterior, st);
//                if (iRes == 0)
//                {
//                    this.IComentario = "El SAT_FORMAPAGO no existe";
//                    return false;
//                }
//                else if (iRes == -1)
//                {
//                    return false;
//                }
//                return CambiarSAT_FORMAPAGOD(oCSAT_FORMAPAGONuevo, oCSAT_FORMAPAGOAnterior, st);
//            }
//            catch (Exception e)
//            {
//                this.iComentario = e.Message + e.StackTrace;
//                return false;
//            }

//        }


//        public CSAT_FORMAPAGOD(string cadenaConexion)
//        {
//            this.sCadenaConexion = cadenaConexion;
//        }


//        public CSAT_FORMAPAGOD()
//        {
//            this.sCadenaConexion = ConexionBD.ConexionString();
//            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


//            //
//            // TODO: Add constructor logic here
//            //
//        }
//    }
//}
