

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



    public class CCUENTAD
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


        public CCUENTABE AgregarCUENTAD(CCUENTABE oCCUENTA, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCCUENTA.isnull["IID"])
                {
                    auxPar.Value = oCCUENTA.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCCUENTA.isnull["IACTIVO"])
                {
                    auxPar.Value = oCCUENTA.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCCUENTA.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCCUENTA.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCCUENTA.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCCUENTA.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCCUENTA.isnull["ICLAVE"])
                {
                    auxPar.Value = oCCUENTA.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUMUCUENTA", FbDbType.VarChar);
                if (!(bool)oCCUENTA.isnull["INUMUCUENTA"])
                {
                    auxPar.Value = oCCUENTA.INUMUCUENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCCUENTA.isnull["IDESCRIPCION"])
                {
                    auxPar.Value = oCCUENTA.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@TIPOLINEAPOLIZAID", FbDbType.BigInt);
                if (!(bool)oCCUENTA.isnull["ITIPOLINEAPOLIZAID"])
                {
                    auxPar.Value = oCCUENTA.ITIPOLINEAPOLIZAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FORMAPAGOSATID", FbDbType.BigInt);
                if (!(bool)oCCUENTA.isnull["IFORMAPAGOSATID"])
                {
                    auxPar.Value = oCCUENTA.IFORMAPAGOSATID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESFACT", FbDbType.Char);
                if (!(bool)oCCUENTA.isnull["IESFACT"])
                {
                    auxPar.Value = oCCUENTA.IESFACT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TASA", FbDbType.Numeric);
                if (!(bool)oCCUENTA.isnull["ITASA"])
                {
                    auxPar.Value = oCCUENTA.ITASA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOLINEAPOLIZAESPECIALID", FbDbType.BigInt);
                if (!(bool)oCCUENTA.isnull["ITIPOLINEAPOLIZAESPECIALID"])
                {
                    auxPar.Value = oCCUENTA.ITIPOLINEAPOLIZAESPECIALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LEYENDA", FbDbType.VarChar);
                if (!(bool)oCCUENTA.isnull["ILEYENDA"])
                {
                    auxPar.Value = oCCUENTA.ILEYENDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ORDEN", FbDbType.Integer);
                if (!(bool)oCCUENTA.isnull["IORDEN"])
                {
                    auxPar.Value = oCCUENTA.IORDEN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
        INSERT INTO CUENTA
      (
    
ID,

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

CLAVE,

NUMUCUENTA,

DESCRIPCION,

TIPOLINEAPOLIZAID,

FORMAPAGOSATID,

ESFACT,

TASA,

TIPOLINEAPOLIZAESPECIALID,

LEYENDA,

ORDEN
        
         )

Values (

@ID,

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@CLAVE,

@NUMUCUENTA,

@DESCRIPCION,

@TIPOLINEAPOLIZAID,

@FORMAPAGOSATID,

@ESFACT,

@TASA,

@TIPOLINEAPOLIZAESPECIALID,

@LEYENDA,

@ORDEN
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCCUENTA;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarCUENTAD(CCUENTABE oCCUENTA, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCCUENTA.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from CUENTA
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


        public bool CambiarCUENTAD(CCUENTABE oCCUENTANuevo, CCUENTABE oCCUENTAAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCCUENTANuevo.isnull["IID"])
                {
                    auxPar.Value = oCCUENTANuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCCUENTANuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCCUENTANuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCCUENTANuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCCUENTANuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCCUENTANuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCCUENTANuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCCUENTANuevo.isnull["ICLAVE"])
                {
                    auxPar.Value = oCCUENTANuevo.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMUCUENTA", FbDbType.VarChar);
                if (!(bool)oCCUENTANuevo.isnull["INUMUCUENTA"])
                {
                    auxPar.Value = oCCUENTANuevo.INUMUCUENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCCUENTANuevo.isnull["IDESCRIPCION"])
                {
                    auxPar.Value = oCCUENTANuevo.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@TIPOLINEAPOLIZAID", FbDbType.BigInt);
                if (!(bool)oCCUENTANuevo.isnull["ITIPOLINEAPOLIZAID"])
                {
                    auxPar.Value = oCCUENTANuevo.ITIPOLINEAPOLIZAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FORMAPAGOSATID", FbDbType.BigInt);
                if (!(bool)oCCUENTANuevo.isnull["IFORMAPAGOSATID"])
                {
                    auxPar.Value = oCCUENTANuevo.IFORMAPAGOSATID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESFACT", FbDbType.Char);
                if (!(bool)oCCUENTANuevo.isnull["IESFACT"])
                {
                    auxPar.Value = oCCUENTANuevo.IESFACT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TASA", FbDbType.Numeric);
                if (!(bool)oCCUENTANuevo.isnull["ITASA"])
                {
                    auxPar.Value = oCCUENTANuevo.ITASA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPOLINEAPOLIZAESPECIALID", FbDbType.BigInt);
                if (!(bool)oCCUENTANuevo.isnull["ITIPOLINEAPOLIZAESPECIALID"])
                {
                    auxPar.Value = oCCUENTANuevo.ITIPOLINEAPOLIZAESPECIALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LEYENDA", FbDbType.VarChar);
                if (!(bool)oCCUENTANuevo.isnull["ILEYENDA"])
                {
                    auxPar.Value = oCCUENTANuevo.ILEYENDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ORDEN", FbDbType.Integer);
                if (!(bool)oCCUENTANuevo.isnull["IORDEN"])
                {
                    auxPar.Value = oCCUENTANuevo.IORDEN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCCUENTAAnterior.isnull["IID"])
                {
                    auxPar.Value = oCCUENTAAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  CUENTA
  set


ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

CLAVE=@CLAVE,

NUMUCUENTA=@NUMUCUENTA,

DESCRIPCION=@DESCRIPCION,

TIPOLINEAPOLIZAID=@TIPOLINEAPOLIZAID,

FORMAPAGOSATID=@FORMAPAGOSATID,

ESFACT=@ESFACT,

TASA=@TASA,

TIPOLINEAPOLIZAESPECIALID=@TIPOLINEAPOLIZAESPECIALID,

LEYENDA=@LEYENDA,

ORDEN=@ORDEN
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


        public CCUENTABE seleccionarCUENTA(CCUENTABE oCCUENTA, FbTransaction st)
        {




            CCUENTABE retorno = new CCUENTABE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from CUENTA where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCCUENTA.IID;
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
                        retorno.ICREADO = (DateTime)(dr["CREADO"]);
                    }

                    if (dr["CREADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.ICREADOPOR_USERID = (long)(dr["CREADOPOR_USERID"]);
                    }

                    if (dr["MODIFICADO"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADO = (DateTime)(dr["MODIFICADO"]);
                    }

                    if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
                    }

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = (string)(dr["CLAVE"]);
                    }

                    if (dr["NUMUCUENTA"] != System.DBNull.Value)
                    {
                        retorno.INUMUCUENTA = (string)(dr["NUMUCUENTA"]);
                    }

                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = (string)(dr["DESCRIPCION"]);
                    }

                    if (dr["TIPOLINEAPOLIZAID"] != System.DBNull.Value)
                    {
                        retorno.ITIPOLINEAPOLIZAID = (long)(dr["TIPOLINEAPOLIZAID"]);
                    }

                    if (dr["FORMAPAGOSATID"] != System.DBNull.Value)
                    {
                        retorno.IFORMAPAGOSATID = (long)(dr["FORMAPAGOSATID"]);
                    }

                    if (dr["ESFACT"] != System.DBNull.Value)
                    {
                        retorno.IESFACT = (string)(dr["ESFACT"]);
                    }

                    if (dr["TASA"] != System.DBNull.Value)
                    {
                        retorno.ITASA = (decimal)(dr["TASA"]);
                    }

                    if (dr["TIPOLINEAPOLIZAESPECIALID"] != System.DBNull.Value)
                    {
                        retorno.ITIPOLINEAPOLIZAESPECIALID = (long)(dr["TIPOLINEAPOLIZAESPECIALID"]);
                    }

                    if (dr["LEYENDA"] != System.DBNull.Value)
                    {
                        retorno.ILEYENDA = (string)(dr["LEYENDA"]);
                    }

                    if (dr["ORDEN"] != System.DBNull.Value)
                    {
                        retorno.IORDEN = int.Parse(dr["ORDEN"].ToString());
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






        public CCUENTABE seleccionarCUENTAxCLAVE(CCUENTABE oCCUENTA, FbTransaction st)
        {




            CCUENTABE retorno = new CCUENTABE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from CUENTA where CLAVE = @CLAVE  ";


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                auxPar.Value = oCCUENTA.ICLAVE;
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
                        retorno.ICREADO = (DateTime)(dr["CREADO"]);
                    }

                    if (dr["CREADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.ICREADOPOR_USERID = (long)(dr["CREADOPOR_USERID"]);
                    }

                    if (dr["MODIFICADO"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADO = (DateTime)(dr["MODIFICADO"]);
                    }

                    if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
                    }

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = (string)(dr["CLAVE"]);
                    }

                    if (dr["NUMUCUENTA"] != System.DBNull.Value)
                    {
                        retorno.INUMUCUENTA = (string)(dr["NUMUCUENTA"]);
                    }

                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = (string)(dr["DESCRIPCION"]);
                    }


                    if (dr["TIPOLINEAPOLIZAID"] != System.DBNull.Value)
                    {
                        retorno.ITIPOLINEAPOLIZAID = (long)(dr["TIPOLINEAPOLIZAID"]);
                    }

                    if (dr["FORMAPAGOSATID"] != System.DBNull.Value)
                    {
                        retorno.IFORMAPAGOSATID = (long)(dr["FORMAPAGOSATID"]);
                    }

                    if (dr["ESFACT"] != System.DBNull.Value)
                    {
                        retorno.IESFACT = (string)(dr["ESFACT"]);
                    }

                    if (dr["TASA"] != System.DBNull.Value)
                    {
                        retorno.ITASA = (decimal)(dr["TASA"]);
                    }

                    if (dr["TIPOLINEAPOLIZAESPECIALID"] != System.DBNull.Value)
                    {
                        retorno.ITIPOLINEAPOLIZAESPECIALID = (long)(dr["TIPOLINEAPOLIZAESPECIALID"]);
                    }

                    if (dr["LEYENDA"] != System.DBNull.Value)
                    {
                        retorno.ILEYENDA = (string)(dr["LEYENDA"]);
                    }

                    if (dr["ORDEN"] != System.DBNull.Value)
                    {
                        retorno.IORDEN = int.Parse(dr["ORDEN"].ToString());
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





        public DataSet enlistarCUENTA()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_CUENTA_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public DataSet enlistarCortoCUENTA()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_CUENTA_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public int ExisteCUENTA(CCUENTABE oCCUENTA, FbTransaction st)
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
                auxPar.Value = oCCUENTA.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from CUENTA where

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




        public CCUENTABE AgregarCUENTA(CCUENTABE oCCUENTA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCUENTA(oCCUENTA, st);
                if (iRes == 1)
                {
                    this.IComentario = "El CUENTA ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarCUENTAD(oCCUENTA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarCUENTA(CCUENTABE oCCUENTA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCUENTA(oCCUENTA, st);
                if (iRes == 0)
                {
                    this.IComentario = "El CUENTA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarCUENTAD(oCCUENTA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarCUENTA(CCUENTABE oCCUENTANuevo, CCUENTABE oCCUENTAAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCUENTA(oCCUENTAAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El CUENTA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarCUENTAD(oCCUENTANuevo, oCCUENTAAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CCUENTAD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
