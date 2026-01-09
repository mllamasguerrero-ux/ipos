

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



    public class CMOVILSESIOND
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


        public CMOVILSESIONBE AgregarMOVILSESIOND(CMOVILSESIONBE oCMOVILSESION, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCMOVILSESION.isnull["IACTIVO"])
                {
                    auxPar.Value = oCMOVILSESION.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMOVILSESION.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCMOVILSESION.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMOVILSESION.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCMOVILSESION.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORCLAVE", FbDbType.VarChar);
                if (!(bool)oCMOVILSESION.isnull["IVENDEDORCLAVE"])
                {
                    auxPar.Value = oCMOVILSESION.IVENDEDORCLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAINICIOVENTA", FbDbType.Date);
                if (!(bool)oCMOVILSESION.isnull["IFECHAINICIOVENTA"])
                {
                    auxPar.Value = oCMOVILSESION.IFECHAINICIOVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAINICIOCOBRA", FbDbType.Date);
                if (!(bool)oCMOVILSESION.isnull["IFECHAINICIOCOBRA"])
                {
                    auxPar.Value = oCMOVILSESION.IFECHAINICIOCOBRA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FOLIOINICIOVENTA", FbDbType.BigInt);
                if (!(bool)oCMOVILSESION.isnull["IFOLIOINICIOVENTA"])
                {
                    auxPar.Value = oCMOVILSESION.IFOLIOINICIOVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FOLIOINICIOCOBRA", FbDbType.BigInt);
                if (!(bool)oCMOVILSESION.isnull["IFOLIOINICIOCOBRA"])
                {
                    auxPar.Value = oCMOVILSESION.IFOLIOINICIOCOBRA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAFINVENTA", FbDbType.Date);
                if (!(bool)oCMOVILSESION.isnull["IFECHAFINVENTA"])
                {
                    auxPar.Value = oCMOVILSESION.IFECHAFINVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAFINCOBRA", FbDbType.Date);
                if (!(bool)oCMOVILSESION.isnull["IFECHAFINCOBRA"])
                {
                    auxPar.Value = oCMOVILSESION.IFECHAFINCOBRA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FOLIOFINVENTA", FbDbType.BigInt);
                if (!(bool)oCMOVILSESION.isnull["IFOLIOFINVENTA"])
                {
                    auxPar.Value = oCMOVILSESION.IFOLIOFINVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FOLIOFINCOBRA", FbDbType.BigInt);
                if (!(bool)oCMOVILSESION.isnull["IFOLIOFINCOBRA"])
                {
                    auxPar.Value = oCMOVILSESION.IFOLIOFINCOBRA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO MOVILSESION
      (
    
ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

VENDEDORCLAVE,

FECHAINICIOVENTA,

FECHAINICIOCOBRA,

FOLIOINICIOVENTA,

FOLIOINICIOCOBRA,

FECHAFINVENTA,

FECHAFINCOBRA,

FOLIOFINVENTA,

FOLIOFINCOBRA
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@VENDEDORCLAVE,

@FECHAINICIOVENTA,

@FECHAINICIOCOBRA,

@FOLIOINICIOVENTA,

@FOLIOINICIOCOBRA,

@FECHAFINVENTA,

@FECHAFINCOBRA,

@FOLIOFINVENTA,

@FOLIOFINCOBRA
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCMOVILSESION;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarMOVILSESIOND(CMOVILSESIONBE oCMOVILSESION, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMOVILSESION.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from MOVILSESION
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


        public bool CambiarMOVILSESIOND(CMOVILSESIONBE oCMOVILSESIONNuevo, CMOVILSESIONBE oCMOVILSESIONAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCMOVILSESIONNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCMOVILSESIONNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMOVILSESIONNuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCMOVILSESIONNuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMOVILSESIONNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCMOVILSESIONNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@VENDEDORCLAVE", FbDbType.VarChar);
                if (!(bool)oCMOVILSESIONNuevo.isnull["IVENDEDORCLAVE"])
                {
                    auxPar.Value = oCMOVILSESIONNuevo.IVENDEDORCLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAINICIOVENTA", FbDbType.Date);
                if (!(bool)oCMOVILSESIONNuevo.isnull["IFECHAINICIOVENTA"])
                {
                    auxPar.Value = oCMOVILSESIONNuevo.IFECHAINICIOVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAINICIOCOBRA", FbDbType.Date);
                if (!(bool)oCMOVILSESIONNuevo.isnull["IFECHAINICIOCOBRA"])
                {
                    auxPar.Value = oCMOVILSESIONNuevo.IFECHAINICIOCOBRA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FOLIOINICIOVENTA", FbDbType.BigInt);
                if (!(bool)oCMOVILSESIONNuevo.isnull["IFOLIOINICIOVENTA"])
                {
                    auxPar.Value = oCMOVILSESIONNuevo.IFOLIOINICIOVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FOLIOINICIOCOBRA", FbDbType.BigInt);
                if (!(bool)oCMOVILSESIONNuevo.isnull["IFOLIOINICIOCOBRA"])
                {
                    auxPar.Value = oCMOVILSESIONNuevo.IFOLIOINICIOCOBRA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAFINVENTA", FbDbType.Date);
                if (!(bool)oCMOVILSESIONNuevo.isnull["IFECHAFINVENTA"])
                {
                    auxPar.Value = oCMOVILSESIONNuevo.IFECHAFINVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAFINCOBRA", FbDbType.Date);
                if (!(bool)oCMOVILSESIONNuevo.isnull["IFECHAFINCOBRA"])
                {
                    auxPar.Value = oCMOVILSESIONNuevo.IFECHAFINCOBRA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FOLIOFINVENTA", FbDbType.BigInt);
                if (!(bool)oCMOVILSESIONNuevo.isnull["IFOLIOFINVENTA"])
                {
                    auxPar.Value = oCMOVILSESIONNuevo.IFOLIOFINVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FOLIOFINCOBRA", FbDbType.BigInt);
                if (!(bool)oCMOVILSESIONNuevo.isnull["IFOLIOFINCOBRA"])
                {
                    auxPar.Value = oCMOVILSESIONNuevo.IFOLIOFINCOBRA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCMOVILSESIONAnterior.isnull["IID"])
                {
                    auxPar.Value = oCMOVILSESIONAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  MOVILSESION
  set

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

VENDEDORCLAVE=@VENDEDORCLAVE,

FECHAINICIOVENTA=@FECHAINICIOVENTA,

FECHAINICIOCOBRA=@FECHAINICIOCOBRA,

FOLIOINICIOVENTA=@FOLIOINICIOVENTA,

FOLIOINICIOCOBRA=@FOLIOINICIOCOBRA,

FECHAFINVENTA=@FECHAFINVENTA,

FECHAFINCOBRA=@FECHAFINCOBRA,

FOLIOFINVENTA=@FOLIOFINVENTA,

FOLIOFINCOBRA=@FOLIOFINCOBRA
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


        public bool CambiarMOVILSESIOND_X_VEND(CMOVILSESIONBE oCMOVILSESIONNuevo, CMOVILSESIONBE oCMOVILSESIONAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCMOVILSESIONNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCMOVILSESIONNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMOVILSESIONNuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCMOVILSESIONNuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMOVILSESIONNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCMOVILSESIONNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAINICIOVENTA", FbDbType.Date);
                if (!(bool)oCMOVILSESIONNuevo.isnull["IFECHAINICIOVENTA"])
                {
                    auxPar.Value = oCMOVILSESIONNuevo.IFECHAINICIOVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAINICIOCOBRA", FbDbType.Date);
                if (!(bool)oCMOVILSESIONNuevo.isnull["IFECHAINICIOCOBRA"])
                {
                    auxPar.Value = oCMOVILSESIONNuevo.IFECHAINICIOCOBRA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FOLIOINICIOVENTA", FbDbType.BigInt);
                if (!(bool)oCMOVILSESIONNuevo.isnull["IFOLIOINICIOVENTA"])
                {
                    auxPar.Value = oCMOVILSESIONNuevo.IFOLIOINICIOVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FOLIOINICIOCOBRA", FbDbType.BigInt);
                if (!(bool)oCMOVILSESIONNuevo.isnull["IFOLIOINICIOCOBRA"])
                {
                    auxPar.Value = oCMOVILSESIONNuevo.IFOLIOINICIOCOBRA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAFINVENTA", FbDbType.Date);
                if (!(bool)oCMOVILSESIONNuevo.isnull["IFECHAFINVENTA"])
                {
                    auxPar.Value = oCMOVILSESIONNuevo.IFECHAFINVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAFINCOBRA", FbDbType.Date);
                if (!(bool)oCMOVILSESIONNuevo.isnull["IFECHAFINCOBRA"])
                {
                    auxPar.Value = oCMOVILSESIONNuevo.IFECHAFINCOBRA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FOLIOFINVENTA", FbDbType.BigInt);
                if (!(bool)oCMOVILSESIONNuevo.isnull["IFOLIOFINVENTA"])
                {
                    auxPar.Value = oCMOVILSESIONNuevo.IFOLIOFINVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FOLIOFINCOBRA", FbDbType.BigInt);
                if (!(bool)oCMOVILSESIONNuevo.isnull["IFOLIOFINCOBRA"])
                {
                    auxPar.Value = oCMOVILSESIONNuevo.IFOLIOFINCOBRA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                

                auxPar = new FbParameter("@VENDEDORCLAVEAnt", FbDbType.VarChar);
                if (!(bool)oCMOVILSESIONAnterior.isnull["IVENDEDORCLAVE"])
                {
                    auxPar.Value = oCMOVILSESIONAnterior.IVENDEDORCLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);





                string commandText = @"
  update  MOVILSESION
  set

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

FECHAINICIOVENTA=@FECHAINICIOVENTA,

FECHAINICIOCOBRA=@FECHAINICIOCOBRA,

FOLIOINICIOVENTA=@FOLIOINICIOVENTA,

FOLIOINICIOCOBRA=@FOLIOINICIOCOBRA,

FECHAFINVENTA=@FECHAFINVENTA,

FECHAFINCOBRA=@FECHAFINCOBRA,

FOLIOFINVENTA=@FOLIOFINVENTA,

FOLIOFINCOBRA=@FOLIOFINCOBRA
  where 

 VENDEDORCLAVE = @VENDEDORCLAVEAnt
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




        public CMOVILSESIONBE seleccionarMOVILSESION(CMOVILSESIONBE oCMOVILSESION, FbTransaction st)
        {




            CMOVILSESIONBE retorno = new CMOVILSESIONBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from MOVILSESION where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMOVILSESION.IID;
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

                    if (dr["VENDEDORCLAVE"] != System.DBNull.Value)
                    {
                        retorno.IVENDEDORCLAVE = (string)(dr["VENDEDORCLAVE"]);
                    }

                    if (dr["FECHAINICIOVENTA"] != System.DBNull.Value)
                    {
                        retorno.IFECHAINICIOVENTA = (DateTime)(dr["FECHAINICIOVENTA"]);
                    }

                    if (dr["FECHAINICIOCOBRA"] != System.DBNull.Value)
                    {
                        retorno.IFECHAINICIOCOBRA = (DateTime)(dr["FECHAINICIOCOBRA"]);
                    }

                    if (dr["FOLIOINICIOVENTA"] != System.DBNull.Value)
                    {
                        retorno.IFOLIOINICIOVENTA = (long)(dr["FOLIOINICIOVENTA"]);
                    }

                    if (dr["FOLIOINICIOCOBRA"] != System.DBNull.Value)
                    {
                        retorno.IFOLIOINICIOCOBRA = (long)(dr["FOLIOINICIOCOBRA"]);
                    }

                    if (dr["FECHAFINVENTA"] != System.DBNull.Value)
                    {
                        retorno.IFECHAFINVENTA = (DateTime)(dr["FECHAFINVENTA"]);
                    }

                    if (dr["FECHAFINCOBRA"] != System.DBNull.Value)
                    {
                        retorno.IFECHAFINCOBRA = (DateTime)(dr["FECHAFINCOBRA"]);
                    }

                    if (dr["FOLIOFINVENTA"] != System.DBNull.Value)
                    {
                        retorno.IFOLIOFINVENTA = (long)(dr["FOLIOFINVENTA"]);
                    }

                    if (dr["FOLIOFINCOBRA"] != System.DBNull.Value)
                    {
                        retorno.IFOLIOFINCOBRA = (long)(dr["FOLIOFINCOBRA"]);
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





        public CMOVILSESIONBE seleccionarMOVILSESION_X_VEND(CMOVILSESIONBE oCMOVILSESION, FbTransaction st)
        {
            CMOVILSESIONBE retorno = new CMOVILSESIONBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from MOVILSESION where VENDEDORCLAVE = @VENDEDORCLAVE  ";


                auxPar = new FbParameter("@VENDEDORCLAVE", FbDbType.VarChar);
                auxPar.Value = oCMOVILSESION.IVENDEDORCLAVE;
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

                    if (dr["VENDEDORCLAVE"] != System.DBNull.Value)
                    {
                        retorno.IVENDEDORCLAVE = (string)(dr["VENDEDORCLAVE"]);
                    }

                    if (dr["FECHAINICIOVENTA"] != System.DBNull.Value)
                    {
                        retorno.IFECHAINICIOVENTA = (DateTime)(dr["FECHAINICIOVENTA"]);
                    }

                    if (dr["FECHAINICIOCOBRA"] != System.DBNull.Value)
                    {
                        retorno.IFECHAINICIOCOBRA = (DateTime)(dr["FECHAINICIOCOBRA"]);
                    }

                    if (dr["FOLIOINICIOVENTA"] != System.DBNull.Value)
                    {
                        retorno.IFOLIOINICIOVENTA = (long)(dr["FOLIOINICIOVENTA"]);
                    }

                    if (dr["FOLIOINICIOCOBRA"] != System.DBNull.Value)
                    {
                        retorno.IFOLIOINICIOCOBRA = (long)(dr["FOLIOINICIOCOBRA"]);
                    }

                    if (dr["FECHAFINVENTA"] != System.DBNull.Value)
                    {
                        retorno.IFECHAFINVENTA = (DateTime)(dr["FECHAFINVENTA"]);
                    }

                    if (dr["FECHAFINCOBRA"] != System.DBNull.Value)
                    {
                        retorno.IFECHAFINCOBRA = (DateTime)(dr["FECHAFINCOBRA"]);
                    }

                    if (dr["FOLIOFINVENTA"] != System.DBNull.Value)
                    {
                        retorno.IFOLIOFINVENTA = (long)(dr["FOLIOFINVENTA"]);
                    }

                    if (dr["FOLIOFINCOBRA"] != System.DBNull.Value)
                    {
                        retorno.IFOLIOFINCOBRA = (long)(dr["FOLIOFINCOBRA"]);
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





        public DataSet enlistarMOVILSESION()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_MOVILSESION_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public DataSet enlistarCortoMOVILSESION()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_MOVILSESION_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public int ExisteMOVILSESION(CMOVILSESIONBE oCMOVILSESION, FbTransaction st)
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
                auxPar.Value = oCMOVILSESION.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from MOVILSESION where

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




        public CMOVILSESIONBE AgregarMOVILSESION(CMOVILSESIONBE oCMOVILSESION, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMOVILSESION(oCMOVILSESION, st);
                if (iRes == 1)
                {
                    this.IComentario = "El MOVILSESION ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarMOVILSESIOND(oCMOVILSESION, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarMOVILSESION(CMOVILSESIONBE oCMOVILSESION, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMOVILSESION(oCMOVILSESION, st);
                if (iRes == 0)
                {
                    this.IComentario = "El MOVILSESION no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarMOVILSESIOND(oCMOVILSESION, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarMOVILSESION(CMOVILSESIONBE oCMOVILSESIONNuevo, CMOVILSESIONBE oCMOVILSESIONAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMOVILSESION(oCMOVILSESIONAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El MOVILSESION no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarMOVILSESIOND(oCMOVILSESIONNuevo, oCMOVILSESIONAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }




        public CMOVILSESIOND(string conn)
        {
            this.sCadenaConexion = conn;
        }

            public CMOVILSESIOND()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
