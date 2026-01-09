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
    


    public class CDOMICILIOD
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
        public CDOMICILIOBE AgregarDOMICILIOD(CDOMICILIOBE oCDOMICILIO, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCDOMICILIO.isnull["IACTIVO"])
                {
                    auxPar.Value = oCDOMICILIO.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCDOMICILIO.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCDOMICILIO.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCDOMICILIO.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCDOMICILIO.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CALLE", FbDbType.VarChar);
                if (!(bool)oCDOMICILIO.isnull["ICALLE"])
                {
                    auxPar.Value = oCDOMICILIO.ICALLE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUMEROEXTERIOR", FbDbType.VarChar);
                if (!(bool)oCDOMICILIO.isnull["INUMEROEXTERIOR"])
                {
                    auxPar.Value = oCDOMICILIO.INUMEROEXTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUMEROINTERIOR", FbDbType.VarChar);
                if (!(bool)oCDOMICILIO.isnull["INUMEROINTERIOR"])
                {
                    auxPar.Value = oCDOMICILIO.INUMEROINTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COLONIA", FbDbType.VarChar);
                if (!(bool)oCDOMICILIO.isnull["ICOLONIA"])
                {
                    auxPar.Value = oCDOMICILIO.ICOLONIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MUNICIPIO", FbDbType.VarChar);
                if (!(bool)oCDOMICILIO.isnull["IMUNICIPIO"])
                {
                    auxPar.Value = oCDOMICILIO.IMUNICIPIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTADO", FbDbType.VarChar);
                if (!(bool)oCDOMICILIO.isnull["IESTADO"])
                {
                    auxPar.Value = oCDOMICILIO.IESTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CODIGOPOSTAL", FbDbType.VarChar);
                if (!(bool)oCDOMICILIO.isnull["ICODIGOPOSTAL"])
                {
                    auxPar.Value = oCDOMICILIO.ICODIGOPOSTAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_COLONIAID", FbDbType.BigInt);
                if (!(bool)oCDOMICILIO.isnull["ISAT_COLONIAID"])
                {
                    auxPar.Value = oCDOMICILIO.ISAT_COLONIAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_LOCALIDADID", FbDbType.BigInt);
                if (!(bool)oCDOMICILIO.isnull["ISAT_LOCALIDADID"])
                {
                    auxPar.Value = oCDOMICILIO.ISAT_LOCALIDADID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_MUNICIPIOID", FbDbType.BigInt);
                if (!(bool)oCDOMICILIO.isnull["ISAT_MUNICIPIOID"])
                {
                    auxPar.Value = oCDOMICILIO.ISAT_MUNICIPIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DISTANCIA", FbDbType.Numeric);
                if (!(bool)oCDOMICILIO.isnull["IDISTANCIA"])
                {
                    auxPar.Value = oCDOMICILIO.IDISTANCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIADOM", FbDbType.VarChar);
                if (!(bool)oCDOMICILIO.isnull["IREFERENCIADOM"])
                {
                    auxPar.Value = oCDOMICILIO.IREFERENCIADOM;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LATITUD", FbDbType.Double);
                if (!(bool)oCDOMICILIO.isnull["ILATITUD"])
                {
                    auxPar.Value = oCDOMICILIO.ILATITUD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LONGITUD", FbDbType.Double);
                if (!(bool)oCDOMICILIO.isnull["ILONGITUD"])
                {
                    auxPar.Value = oCDOMICILIO.ILONGITUD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (!(bool)oCDOMICILIO.isnull["IPERSONAID"])
                {
                    auxPar.Value = oCDOMICILIO.IPERSONAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ORDEN", FbDbType.Integer);
                if (!(bool)oCDOMICILIO.isnull["IORDEN"])
                {
                    auxPar.Value = oCDOMICILIO.IORDEN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PREDETERMINADO", FbDbType.Char);
                if (!(bool)oCDOMICILIO.isnull["IPREDETERMINADO"])
                {
                    auxPar.Value = oCDOMICILIO.IPREDETERMINADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO DOMICILIO
      (
ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

CALLE,

NUMEROEXTERIOR,

NUMEROINTERIOR,

COLONIA,

MUNICIPIO,

ESTADO,

CODIGOPOSTAL,

SAT_COLONIAID,

SAT_LOCALIDADID,

SAT_MUNICIPIOID,

DISTANCIA,

REFERENCIADOM,

LATITUD,

LONGITUD,

PERSONAID,

ORDEN,

PREDETERMINADO
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@CALLE,

@NUMEROEXTERIOR,

@NUMEROINTERIOR,

@COLONIA,

@MUNICIPIO,

@ESTADO,

@CODIGOPOSTAL,

@SAT_COLONIAID,

@SAT_LOCALIDADID,

@SAT_MUNICIPIOID,

@DISTANCIA,

@REFERENCIADOM,

@LATITUD,

@LONGITUD,

@PERSONAID,

@ORDEN,

@PREDETERMINADO
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCDOMICILIO;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarDOMICILIOD(CDOMICILIOBE oCDOMICILIO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCDOMICILIO.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from DOMICILIO
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
        public bool CambiarDOMICILIOD(CDOMICILIOBE oCDOMICILIONuevo, CDOMICILIOBE oCDOMICILIOAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCDOMICILIONuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCDOMICILIONuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCDOMICILIONuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCDOMICILIONuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CALLE", FbDbType.VarChar);
                if (!(bool)oCDOMICILIONuevo.isnull["ICALLE"])
                {
                    auxPar.Value = oCDOMICILIONuevo.ICALLE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMEROEXTERIOR", FbDbType.VarChar);
                if (!(bool)oCDOMICILIONuevo.isnull["INUMEROEXTERIOR"])
                {
                    auxPar.Value = oCDOMICILIONuevo.INUMEROEXTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMEROINTERIOR", FbDbType.VarChar);
                if (!(bool)oCDOMICILIONuevo.isnull["INUMEROINTERIOR"])
                {
                    auxPar.Value = oCDOMICILIONuevo.INUMEROINTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@COLONIA", FbDbType.VarChar);
                if (!(bool)oCDOMICILIONuevo.isnull["ICOLONIA"])
                {
                    auxPar.Value = oCDOMICILIONuevo.ICOLONIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MUNICIPIO", FbDbType.VarChar);
                if (!(bool)oCDOMICILIONuevo.isnull["IMUNICIPIO"])
                {
                    auxPar.Value = oCDOMICILIONuevo.IMUNICIPIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESTADO", FbDbType.VarChar);
                if (!(bool)oCDOMICILIONuevo.isnull["IESTADO"])
                {
                    auxPar.Value = oCDOMICILIONuevo.IESTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CODIGOPOSTAL", FbDbType.VarChar);
                if (!(bool)oCDOMICILIONuevo.isnull["ICODIGOPOSTAL"])
                {
                    auxPar.Value = oCDOMICILIONuevo.ICODIGOPOSTAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_COLONIAID", FbDbType.BigInt);
                if (!(bool)oCDOMICILIONuevo.isnull["ISAT_COLONIAID"])
                {
                    auxPar.Value = oCDOMICILIONuevo.ISAT_COLONIAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_LOCALIDADID", FbDbType.BigInt);
                if (!(bool)oCDOMICILIONuevo.isnull["ISAT_LOCALIDADID"])
                {
                    auxPar.Value = oCDOMICILIONuevo.ISAT_LOCALIDADID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_MUNICIPIOID", FbDbType.BigInt);
                if (!(bool)oCDOMICILIONuevo.isnull["ISAT_MUNICIPIOID"])
                {
                    auxPar.Value = oCDOMICILIONuevo.ISAT_MUNICIPIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DISTANCIA", FbDbType.Numeric);
                if (!(bool)oCDOMICILIONuevo.isnull["IDISTANCIA"])
                {
                    auxPar.Value = oCDOMICILIONuevo.IDISTANCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@REFERENCIADOM", FbDbType.VarChar);
                if (!(bool)oCDOMICILIONuevo.isnull["IREFERENCIADOM"])
                {
                    auxPar.Value = oCDOMICILIONuevo.IREFERENCIADOM;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LATITUD", FbDbType.Double);
                if (!(bool)oCDOMICILIONuevo.isnull["ILATITUD"])
                {
                    auxPar.Value = oCDOMICILIONuevo.ILATITUD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LONGITUD", FbDbType.Double);
                if (!(bool)oCDOMICILIONuevo.isnull["ILONGITUD"])
                {
                    auxPar.Value = oCDOMICILIONuevo.ILONGITUD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (!(bool)oCDOMICILIONuevo.isnull["IPERSONAID"])
                {
                    auxPar.Value = oCDOMICILIONuevo.IPERSONAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ORDEN", FbDbType.Integer);
                if (!(bool)oCDOMICILIONuevo.isnull["IORDEN"])
                {
                    auxPar.Value = oCDOMICILIONuevo.IORDEN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PREDETERMINADO", FbDbType.Char);
                if (!(bool)oCDOMICILIONuevo.isnull["IPREDETERMINADO"])
                {
                    auxPar.Value = oCDOMICILIONuevo.IPREDETERMINADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOMICILIOAnterior.isnull["IID"])
                {
                    auxPar.Value = oCDOMICILIOAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOMICILIO
  set


ACTIVO=@ACTIVO,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

CALLE=@CALLE,

NUMEROEXTERIOR=@NUMEROEXTERIOR,

NUMEROINTERIOR=@NUMEROINTERIOR,

COLONIA=@COLONIA,

MUNICIPIO=@MUNICIPIO,

ESTADO=@ESTADO,

CODIGOPOSTAL=@CODIGOPOSTAL,

SAT_COLONIAID=@SAT_COLONIAID,

SAT_LOCALIDADID=@SAT_LOCALIDADID,

SAT_MUNICIPIOID=@SAT_MUNICIPIOID,

DISTANCIA=@DISTANCIA,

REFERENCIADOM=@REFERENCIADOM,

LATITUD=@LATITUD,

LONGITUD=@LONGITUD,

PERSONAID=@PERSONAID,

ORDEN=@ORDEN,

PREDETERMINADO=@PREDETERMINADO
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
        public CDOMICILIOBE seleccionarDOMICILIO(CDOMICILIOBE oCDOMICILIO, FbTransaction st)
        {




            CDOMICILIOBE retorno = new CDOMICILIOBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from DOMICILIO where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCDOMICILIO.IID;
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

                    if (dr["CALLE"] != System.DBNull.Value)
                    {
                        retorno.ICALLE = (string)(dr["CALLE"]);
                    }

                    if (dr["NUMEROEXTERIOR"] != System.DBNull.Value)
                    {
                        retorno.INUMEROEXTERIOR = (string)(dr["NUMEROEXTERIOR"]);
                    }

                    if (dr["NUMEROINTERIOR"] != System.DBNull.Value)
                    {
                        retorno.INUMEROINTERIOR = (string)(dr["NUMEROINTERIOR"]);
                    }

                    if (dr["COLONIA"] != System.DBNull.Value)
                    {
                        retorno.ICOLONIA = (string)(dr["COLONIA"]);
                    }

                    if (dr["MUNICIPIO"] != System.DBNull.Value)
                    {
                        retorno.IMUNICIPIO = (string)(dr["MUNICIPIO"]);
                    }

                    if (dr["ESTADO"] != System.DBNull.Value)
                    {
                        retorno.IESTADO = (string)(dr["ESTADO"]);
                    }

                    if (dr["CODIGOPOSTAL"] != System.DBNull.Value)
                    {
                        retorno.ICODIGOPOSTAL = (string)(dr["CODIGOPOSTAL"]);
                    }

                    if (dr["SAT_COLONIAID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_COLONIAID = (long)(dr["SAT_COLONIAID"]);
                    }

                    if (dr["SAT_LOCALIDADID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_LOCALIDADID = (long)(dr["SAT_LOCALIDADID"]);
                    }

                    if (dr["SAT_MUNICIPIOID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_MUNICIPIOID = (long)(dr["SAT_MUNICIPIOID"]);
                    }

                    if (dr["DISTANCIA"] != System.DBNull.Value)
                    {
                        retorno.IDISTANCIA = (decimal)(dr["DISTANCIA"]);
                    }

                    if (dr["REFERENCIADOM"] != System.DBNull.Value)
                    {
                        retorno.IREFERENCIADOM = (string)(dr["REFERENCIADOM"]);
                    }

                    if (dr["LATITUD"] != System.DBNull.Value)
                    {
                        retorno.ILATITUD = (double)(dr["LATITUD"]);
                    }

                    if (dr["LONGITUD"] != System.DBNull.Value)
                    {
                        retorno.ILONGITUD = (double)(dr["LONGITUD"]);
                    }

                    if (dr["PERSONAID"] != System.DBNull.Value)
                    {
                        retorno.IPERSONAID = (long)(dr["PERSONAID"]);
                    }

                    if (dr["PREDETERMINADO"] != System.DBNull.Value)
                    {
                        retorno.IPREDETERMINADO = (string)(dr["PREDETERMINADO"]);
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









        [AutoComplete]
        public DataSet enlistarDOMICILIO()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_DOMICILIO_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoDOMICILIO()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_DOMICILIO_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteDOMICILIO(CDOMICILIOBE oCDOMICILIO, FbTransaction st)
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
                auxPar.Value = oCDOMICILIO.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from DOMICILIO where

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



        public int ExisteDOMICILIOParaPersona(long personaId, FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                auxPar.Value = personaId;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from DOMICILIO where PERSONAID = @PERSONAID AND ACTIVO = 'S'
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



        public CDOMICILIOBE AgregarDOMICILIO(CDOMICILIOBE oCDOMICILIO, FbTransaction st)
        {
            try
            {
                int iRes = ExisteDOMICILIO(oCDOMICILIO, st);
                if (iRes == 1)
                {
                    this.IComentario = "El DOMICILIO ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarDOMICILIOD(oCDOMICILIO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarDOMICILIO(CDOMICILIOBE oCDOMICILIO, FbTransaction st)
        {
            try
            {
                int iRes = ExisteDOMICILIO(oCDOMICILIO, st);
                if (iRes == 0)
                {
                    this.IComentario = "El DOMICILIO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarDOMICILIOD(oCDOMICILIO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarDOMICILIO(CDOMICILIOBE oCDOMICILIONuevo, CDOMICILIOBE oCDOMICILIOAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteDOMICILIO(oCDOMICILIOAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El DOMICILIO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarDOMICILIOD(oCDOMICILIONuevo, oCDOMICILIOAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }

        



        public CDOMICILIOD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
