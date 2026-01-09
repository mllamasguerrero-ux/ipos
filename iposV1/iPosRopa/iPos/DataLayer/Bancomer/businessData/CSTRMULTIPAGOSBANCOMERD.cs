

using System;
using Microsoft.ApplicationBlocks.Data;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Collections;
using ConexionesBD;
using iPosBusinessEntity;

namespace iPosData
{



    public class CSTRMULTIPAGOSBANCOMERD
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


        public CSTRMULTIPAGOSBANCOMERBE AgregarSTRMULTIPAGOSBANCOMERD(CSTRMULTIPAGOSBANCOMERBE oCSTRMULTIPAGOSBANCOMER, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCSTRMULTIPAGOSBANCOMER.isnull["IID"])
                {
                    auxPar.Value = oCSTRMULTIPAGOSBANCOMER.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSTRMULTIPAGOSBANCOMER.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSTRMULTIPAGOSBANCOMER.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSTRMULTIPAGOSBANCOMER.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCSTRMULTIPAGOSBANCOMER.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSTRMULTIPAGOSBANCOMER.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSTRMULTIPAGOSBANCOMER.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@GUIA_CIE", FbDbType.VarChar);
                if (!(bool)oCSTRMULTIPAGOSBANCOMER.isnull["IGUIA_CIE"])
                {
                    auxPar.Value = oCSTRMULTIPAGOSBANCOMER.IGUIA_CIE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPORTEUDIS", FbDbType.VarChar);
                if (!(bool)oCSTRMULTIPAGOSBANCOMER.isnull["IIMPORTEUDIS"])
                {
                    auxPar.Value = oCSTRMULTIPAGOSBANCOMER.IIMPORTEUDIS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUMTARJETAII", FbDbType.VarChar);
                if (!(bool)oCSTRMULTIPAGOSBANCOMER.isnull["INUMTARJETAII"])
                {
                    auxPar.Value = oCSTRMULTIPAGOSBANCOMER.INUMTARJETAII;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RAZON_SOCIAL", FbDbType.VarChar);
                if (!(bool)oCSTRMULTIPAGOSBANCOMER.isnull["IRAZON_SOCIAL"])
                {
                    auxPar.Value = oCSTRMULTIPAGOSBANCOMER.IRAZON_SOCIAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIA_RESPUESTA", FbDbType.VarChar);
                if (!(bool)oCSTRMULTIPAGOSBANCOMER.isnull["IREFERENCIA_RESPUESTA"])
                {
                    auxPar.Value = oCSTRMULTIPAGOSBANCOMER.IREFERENCIA_RESPUESTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO STRMULTIPAGOSBANCOMER
      (
    
ID,

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

GUIA_CIE,

IMPORTEUDIS,

NUMTARJETAII,

RAZON_SOCIAL,

REFERENCIA_RESPUESTA
         )

Values (

@ID,

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@GUIA_CIE,

@IMPORTEUDIS,

@NUMTARJETAII,

@RAZON_SOCIAL,

@REFERENCIA_RESPUESTA
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCSTRMULTIPAGOSBANCOMER;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }



        public bool BorrarSTRMULTIPAGOSBANCOMERD(CSTRMULTIPAGOSBANCOMERBE oCSTRMULTIPAGOSBANCOMER, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSTRMULTIPAGOSBANCOMER.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from STRMULTIPAGOSBANCOMER
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



        public bool CambiarSTRMULTIPAGOSBANCOMERD(CSTRMULTIPAGOSBANCOMERBE oCSTRMULTIPAGOSBANCOMERNuevo, CSTRMULTIPAGOSBANCOMERBE oCSTRMULTIPAGOSBANCOMERAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCSTRMULTIPAGOSBANCOMERNuevo.isnull["IID"])
                {
                    auxPar.Value = oCSTRMULTIPAGOSBANCOMERNuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSTRMULTIPAGOSBANCOMERNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSTRMULTIPAGOSBANCOMERNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSTRMULTIPAGOSBANCOMERNuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCSTRMULTIPAGOSBANCOMERNuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSTRMULTIPAGOSBANCOMERNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSTRMULTIPAGOSBANCOMERNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@GUIA_CIE", FbDbType.VarChar);
                if (!(bool)oCSTRMULTIPAGOSBANCOMERNuevo.isnull["IGUIA_CIE"])
                {
                    auxPar.Value = oCSTRMULTIPAGOSBANCOMERNuevo.IGUIA_CIE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IMPORTEUDIS", FbDbType.VarChar);
                if (!(bool)oCSTRMULTIPAGOSBANCOMERNuevo.isnull["IIMPORTEUDIS"])
                {
                    auxPar.Value = oCSTRMULTIPAGOSBANCOMERNuevo.IIMPORTEUDIS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMTARJETAII", FbDbType.VarChar);
                if (!(bool)oCSTRMULTIPAGOSBANCOMERNuevo.isnull["INUMTARJETAII"])
                {
                    auxPar.Value = oCSTRMULTIPAGOSBANCOMERNuevo.INUMTARJETAII;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@RAZON_SOCIAL", FbDbType.VarChar);
                if (!(bool)oCSTRMULTIPAGOSBANCOMERNuevo.isnull["IRAZON_SOCIAL"])
                {
                    auxPar.Value = oCSTRMULTIPAGOSBANCOMERNuevo.IRAZON_SOCIAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@REFERENCIA_RESPUESTA", FbDbType.VarChar);
                if (!(bool)oCSTRMULTIPAGOSBANCOMERNuevo.isnull["IREFERENCIA_RESPUESTA"])
                {
                    auxPar.Value = oCSTRMULTIPAGOSBANCOMERNuevo.IREFERENCIA_RESPUESTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCSTRMULTIPAGOSBANCOMERAnterior.isnull["IID"])
                {
                    auxPar.Value = oCSTRMULTIPAGOSBANCOMERAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  STRMULTIPAGOSBANCOMER
  set

ID=@ID,

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

GUIA_CIE=@GUIA_CIE,

IMPORTEUDIS=@IMPORTEUDIS,

NUMTARJETAII=@NUMTARJETAII,

RAZON_SOCIAL=@RAZON_SOCIAL,

REFERENCIA_RESPUESTA=@REFERENCIA_RESPUESTA
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



        public CSTRMULTIPAGOSBANCOMERBE seleccionarSTRMULTIPAGOSBANCOMER(CSTRMULTIPAGOSBANCOMERBE oCSTRMULTIPAGOSBANCOMER, FbTransaction st)
        {




            CSTRMULTIPAGOSBANCOMERBE retorno = new CSTRMULTIPAGOSBANCOMERBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from STRMULTIPAGOSBANCOMER where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSTRMULTIPAGOSBANCOMER.IID;
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

                    if (dr["GUIA_CIE"] != System.DBNull.Value)
                    {
                        retorno.IGUIA_CIE = (string)(dr["GUIA_CIE"]);
                    }

                    if (dr["IMPORTEUDIS"] != System.DBNull.Value)
                    {
                        retorno.IIMPORTEUDIS = (string)(dr["IMPORTEUDIS"]);
                    }

                    if (dr["NUMTARJETAII"] != System.DBNull.Value)
                    {
                        retorno.INUMTARJETAII = (string)(dr["NUMTARJETAII"]);
                    }

                    if (dr["RAZON_SOCIAL"] != System.DBNull.Value)
                    {
                        retorno.IRAZON_SOCIAL = (string)(dr["RAZON_SOCIAL"]);
                    }

                    if (dr["REFERENCIA_RESPUESTA"] != System.DBNull.Value)
                    {
                        retorno.IREFERENCIA_RESPUESTA = (string)(dr["REFERENCIA_RESPUESTA"]);
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










        public DataSet enlistarSTRMULTIPAGOSBANCOMER()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_STRMULTIPAGOSBANCOMER_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }





        public DataSet enlistarCortoSTRMULTIPAGOSBANCOMER()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_STRMULTIPAGOSBANCOMER_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public int ExisteSTRMULTIPAGOSBANCOMER(CSTRMULTIPAGOSBANCOMERBE oCSTRMULTIPAGOSBANCOMER, FbTransaction st)
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
                auxPar.Value = oCSTRMULTIPAGOSBANCOMER.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from STRMULTIPAGOSBANCOMER where

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




        public CSTRMULTIPAGOSBANCOMERBE AgregarSTRMULTIPAGOSBANCOMER(CSTRMULTIPAGOSBANCOMERBE oCSTRMULTIPAGOSBANCOMER, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSTRMULTIPAGOSBANCOMER(oCSTRMULTIPAGOSBANCOMER, st);
                if (iRes == 1)
                {
                    this.IComentario = "El STRMULTIPAGOSBANCOMER ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarSTRMULTIPAGOSBANCOMERD(oCSTRMULTIPAGOSBANCOMER, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarSTRMULTIPAGOSBANCOMER(CSTRMULTIPAGOSBANCOMERBE oCSTRMULTIPAGOSBANCOMER, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSTRMULTIPAGOSBANCOMER(oCSTRMULTIPAGOSBANCOMER, st);
                if (iRes == 0)
                {
                    this.IComentario = "El STRMULTIPAGOSBANCOMER no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarSTRMULTIPAGOSBANCOMERD(oCSTRMULTIPAGOSBANCOMER, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarSTRMULTIPAGOSBANCOMER(CSTRMULTIPAGOSBANCOMERBE oCSTRMULTIPAGOSBANCOMERNuevo, CSTRMULTIPAGOSBANCOMERBE oCSTRMULTIPAGOSBANCOMERAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSTRMULTIPAGOSBANCOMER(oCSTRMULTIPAGOSBANCOMERAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El STRMULTIPAGOSBANCOMER no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarSTRMULTIPAGOSBANCOMERD(oCSTRMULTIPAGOSBANCOMERNuevo, oCSTRMULTIPAGOSBANCOMERAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CSTRMULTIPAGOSBANCOMERD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
