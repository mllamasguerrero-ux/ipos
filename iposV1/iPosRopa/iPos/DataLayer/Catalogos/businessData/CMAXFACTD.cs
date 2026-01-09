

using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Collections;
using ConexionesBD;
using System.Collections.Generic;

namespace iPosData
{



    public class CMAXFACTD
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


        public CMAXFACTBE AgregarMAXFACTD(CMAXFACTBE oCMAXFACT, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCMAXFACT.isnull["IACTIVO"])
                {
                    auxPar.Value = oCMAXFACT.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMAXFACT.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCMAXFACT.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMAXFACT.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCMAXFACT.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUCURSALCLAVE", FbDbType.VarChar);
                if (!(bool)oCMAXFACT.isnull["ISUCURSALCLAVE"])
                {
                    auxPar.Value = oCMAXFACT.ISUCURSALCLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ANIO", FbDbType.Integer);
                if (!(bool)oCMAXFACT.isnull["IANIO"])
                {
                    auxPar.Value = oCMAXFACT.IANIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MES", FbDbType.Integer);
                if (!(bool)oCMAXFACT.isnull["IMES"])
                {
                    auxPar.Value = oCMAXFACT.IMES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LUN_HAY", FbDbType.Char);
                if (!(bool)oCMAXFACT.isnull["ILUN_HAY"])
                {
                    auxPar.Value = oCMAXFACT.ILUN_HAY;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LUN_MAX", FbDbType.Numeric);
                if (!(bool)oCMAXFACT.isnull["ILUN_MAX"])
                {
                    auxPar.Value = oCMAXFACT.ILUN_MAX;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MAR_HAY", FbDbType.Char);
                if (!(bool)oCMAXFACT.isnull["IMAR_HAY"])
                {
                    auxPar.Value = oCMAXFACT.IMAR_HAY;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MAR_MAX", FbDbType.Numeric);
                if (!(bool)oCMAXFACT.isnull["IMAR_MAX"])
                {
                    auxPar.Value = oCMAXFACT.IMAR_MAX;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MIE_HAY", FbDbType.Char);
                if (!(bool)oCMAXFACT.isnull["IMIE_HAY"])
                {
                    auxPar.Value = oCMAXFACT.IMIE_HAY;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MIE_MAX", FbDbType.Numeric);
                if (!(bool)oCMAXFACT.isnull["IMIE_MAX"])
                {
                    auxPar.Value = oCMAXFACT.IMIE_MAX;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@JUE_HAY", FbDbType.Char);
                if (!(bool)oCMAXFACT.isnull["IJUE_HAY"])
                {
                    auxPar.Value = oCMAXFACT.IJUE_HAY;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@JUE_MAX", FbDbType.Numeric);
                if (!(bool)oCMAXFACT.isnull["IJUE_MAX"])
                {
                    auxPar.Value = oCMAXFACT.IJUE_MAX;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VIE_HAY", FbDbType.Char);
                if (!(bool)oCMAXFACT.isnull["IVIE_HAY"])
                {
                    auxPar.Value = oCMAXFACT.IVIE_HAY;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VIE_MAX", FbDbType.Numeric);
                if (!(bool)oCMAXFACT.isnull["IVIE_MAX"])
                {
                    auxPar.Value = oCMAXFACT.IVIE_MAX;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAB_HAY", FbDbType.Char);
                if (!(bool)oCMAXFACT.isnull["ISAB_HAY"])
                {
                    auxPar.Value = oCMAXFACT.ISAB_HAY;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAB_MAX", FbDbType.Numeric);
                if (!(bool)oCMAXFACT.isnull["ISAB_MAX"])
                {
                    auxPar.Value = oCMAXFACT.ISAB_MAX;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOM_HAY", FbDbType.Char);
                if (!(bool)oCMAXFACT.isnull["IDOM_HAY"])
                {
                    auxPar.Value = oCMAXFACT.IDOM_HAY;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOM_MAX", FbDbType.Numeric);
                if (!(bool)oCMAXFACT.isnull["IDOM_MAX"])
                {
                    auxPar.Value = oCMAXFACT.IDOM_MAX;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO MAXFACT
      (
    
ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

SUCURSALCLAVE,

ANIO,

MES,

LUN_HAY,

LUN_MAX,

MAR_HAY,

MAR_MAX,

MIE_HAY,

MIE_MAX,

JUE_HAY,

JUE_MAX,

VIE_HAY,

VIE_MAX,

SAB_HAY,

SAB_MAX,

DOM_HAY,

DOM_MAX
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@SUCURSALCLAVE,

@ANIO,

@MES,

@LUN_HAY,

@LUN_MAX,

@MAR_HAY,

@MAR_MAX,

@MIE_HAY,

@MIE_MAX,

@JUE_HAY,

@JUE_MAX,

@VIE_HAY,

@VIE_MAX,

@SAB_HAY,

@SAB_MAX,

@DOM_HAY,

@DOM_MAX
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCMAXFACT;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }



        public bool AgregarOModificarMAXFACTD(CMAXFACTBE oCMAXFACT, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCMAXFACT.isnull["IACTIVO"])
                {
                    auxPar.Value = oCMAXFACT.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMAXFACT.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCMAXFACT.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMAXFACT.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCMAXFACT.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUCURSALCLAVE", FbDbType.VarChar);
                if (!(bool)oCMAXFACT.isnull["ISUCURSALCLAVE"])
                {
                    auxPar.Value = oCMAXFACT.ISUCURSALCLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ANIO", FbDbType.Integer);
                if (!(bool)oCMAXFACT.isnull["IANIO"])
                {
                    auxPar.Value = oCMAXFACT.IANIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MES", FbDbType.Integer);
                if (!(bool)oCMAXFACT.isnull["IMES"])
                {
                    auxPar.Value = oCMAXFACT.IMES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LUN_HAY", FbDbType.Char);
                if (!(bool)oCMAXFACT.isnull["ILUN_HAY"])
                {
                    auxPar.Value = oCMAXFACT.ILUN_HAY;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LUN_MAX", FbDbType.Numeric);
                if (!(bool)oCMAXFACT.isnull["ILUN_MAX"])
                {
                    auxPar.Value = oCMAXFACT.ILUN_MAX;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MAR_HAY", FbDbType.Char);
                if (!(bool)oCMAXFACT.isnull["IMAR_HAY"])
                {
                    auxPar.Value = oCMAXFACT.IMAR_HAY;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MAR_MAX", FbDbType.Numeric);
                if (!(bool)oCMAXFACT.isnull["IMAR_MAX"])
                {
                    auxPar.Value = oCMAXFACT.IMAR_MAX;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MIE_HAY", FbDbType.Char);
                if (!(bool)oCMAXFACT.isnull["IMIE_HAY"])
                {
                    auxPar.Value = oCMAXFACT.IMIE_HAY;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MIE_MAX", FbDbType.Numeric);
                if (!(bool)oCMAXFACT.isnull["IMIE_MAX"])
                {
                    auxPar.Value = oCMAXFACT.IMIE_MAX;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@JUE_HAY", FbDbType.Char);
                if (!(bool)oCMAXFACT.isnull["IJUE_HAY"])
                {
                    auxPar.Value = oCMAXFACT.IJUE_HAY;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@JUE_MAX", FbDbType.Numeric);
                if (!(bool)oCMAXFACT.isnull["IJUE_MAX"])
                {
                    auxPar.Value = oCMAXFACT.IJUE_MAX;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VIE_HAY", FbDbType.Char);
                if (!(bool)oCMAXFACT.isnull["IVIE_HAY"])
                {
                    auxPar.Value = oCMAXFACT.IVIE_HAY;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VIE_MAX", FbDbType.Numeric);
                if (!(bool)oCMAXFACT.isnull["IVIE_MAX"])
                {
                    auxPar.Value = oCMAXFACT.IVIE_MAX;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAB_HAY", FbDbType.Char);
                if (!(bool)oCMAXFACT.isnull["ISAB_HAY"])
                {
                    auxPar.Value = oCMAXFACT.ISAB_HAY;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAB_MAX", FbDbType.Numeric);
                if (!(bool)oCMAXFACT.isnull["ISAB_MAX"])
                {
                    auxPar.Value = oCMAXFACT.ISAB_MAX;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOM_HAY", FbDbType.Char);
                if (!(bool)oCMAXFACT.isnull["IDOM_HAY"])
                {
                    auxPar.Value = oCMAXFACT.IDOM_HAY;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOM_MAX", FbDbType.Numeric);
                if (!(bool)oCMAXFACT.isnull["IDOM_MAX"])
                {
                    auxPar.Value = oCMAXFACT.IDOM_MAX;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        UPDATE OR INSERT INTO MAXFACT
      (
    
ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

SUCURSALCLAVE,

ANIO,

MES,

LUN_HAY,

LUN_MAX,

MAR_HAY,

MAR_MAX,

MIE_HAY,

MIE_MAX,

JUE_HAY,

JUE_MAX,

VIE_HAY,

VIE_MAX,

SAB_HAY,

SAB_MAX,

DOM_HAY,

DOM_MAX
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@SUCURSALCLAVE,

@ANIO,

@MES,

@LUN_HAY,

@LUN_MAX,

@MAR_HAY,

@MAR_MAX,

@MIE_HAY,

@MIE_MAX,

@JUE_HAY,

@JUE_MAX,

@VIE_HAY,

@VIE_MAX,

@SAB_HAY,

@SAB_MAX,

@DOM_HAY,

@DOM_MAX
) MATCHING (SUCURSALCLAVE, ANIO, MES); ";

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

        public bool BorrarMAXFACTD(CMAXFACTBE oCMAXFACT, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMAXFACT.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from MAXFACT
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




        public bool BorrarMAXFACTXSUCURSALANIO(string sucursalClave, long anio, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@SUCURSALCLAVE", FbDbType.VarChar);
                auxPar.Value = sucursalClave;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ANIO", FbDbType.Integer);
                auxPar.Value = anio;
                parts.Add(auxPar);


                string commandText = @"  Delete from MAXFACT where SUCURSALCLAVE = @SUCURSALCLAVE AND ANIO = @ANIO;";

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


        public bool CambiarMAXFACTD(CMAXFACTBE oCMAXFACTNuevo, CMAXFACTBE oCMAXFACTAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCMAXFACTNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCMAXFACTNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMAXFACTNuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCMAXFACTNuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMAXFACTNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCMAXFACTNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SUCURSALCLAVE", FbDbType.VarChar);
                if (!(bool)oCMAXFACTNuevo.isnull["ISUCURSALCLAVE"])
                {
                    auxPar.Value = oCMAXFACTNuevo.ISUCURSALCLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ANIO", FbDbType.Integer);
                if (!(bool)oCMAXFACTNuevo.isnull["IANIO"])
                {
                    auxPar.Value = oCMAXFACTNuevo.IANIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MES", FbDbType.Integer);
                if (!(bool)oCMAXFACTNuevo.isnull["IMES"])
                {
                    auxPar.Value = oCMAXFACTNuevo.IMES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LUN_HAY", FbDbType.Char);
                if (!(bool)oCMAXFACTNuevo.isnull["ILUN_HAY"])
                {
                    auxPar.Value = oCMAXFACTNuevo.ILUN_HAY;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LUN_MAX", FbDbType.Numeric);
                if (!(bool)oCMAXFACTNuevo.isnull["ILUN_MAX"])
                {
                    auxPar.Value = oCMAXFACTNuevo.ILUN_MAX;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MAR_HAY", FbDbType.Char);
                if (!(bool)oCMAXFACTNuevo.isnull["IMAR_HAY"])
                {
                    auxPar.Value = oCMAXFACTNuevo.IMAR_HAY;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MAR_MAX", FbDbType.Numeric);
                if (!(bool)oCMAXFACTNuevo.isnull["IMAR_MAX"])
                {
                    auxPar.Value = oCMAXFACTNuevo.IMAR_MAX;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MIE_HAY", FbDbType.Char);
                if (!(bool)oCMAXFACTNuevo.isnull["IMIE_HAY"])
                {
                    auxPar.Value = oCMAXFACTNuevo.IMIE_HAY;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MIE_MAX", FbDbType.Numeric);
                if (!(bool)oCMAXFACTNuevo.isnull["IMIE_MAX"])
                {
                    auxPar.Value = oCMAXFACTNuevo.IMIE_MAX;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@JUE_HAY", FbDbType.Char);
                if (!(bool)oCMAXFACTNuevo.isnull["IJUE_HAY"])
                {
                    auxPar.Value = oCMAXFACTNuevo.IJUE_HAY;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@JUE_MAX", FbDbType.Numeric);
                if (!(bool)oCMAXFACTNuevo.isnull["IJUE_MAX"])
                {
                    auxPar.Value = oCMAXFACTNuevo.IJUE_MAX;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@VIE_HAY", FbDbType.Char);
                if (!(bool)oCMAXFACTNuevo.isnull["IVIE_HAY"])
                {
                    auxPar.Value = oCMAXFACTNuevo.IVIE_HAY;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@VIE_MAX", FbDbType.Numeric);
                if (!(bool)oCMAXFACTNuevo.isnull["IVIE_MAX"])
                {
                    auxPar.Value = oCMAXFACTNuevo.IVIE_MAX;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAB_HAY", FbDbType.Char);
                if (!(bool)oCMAXFACTNuevo.isnull["ISAB_HAY"])
                {
                    auxPar.Value = oCMAXFACTNuevo.ISAB_HAY;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAB_MAX", FbDbType.Numeric);
                if (!(bool)oCMAXFACTNuevo.isnull["ISAB_MAX"])
                {
                    auxPar.Value = oCMAXFACTNuevo.ISAB_MAX;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOM_HAY", FbDbType.Char);
                if (!(bool)oCMAXFACTNuevo.isnull["IDOM_HAY"])
                {
                    auxPar.Value = oCMAXFACTNuevo.IDOM_HAY;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOM_MAX", FbDbType.Numeric);
                if (!(bool)oCMAXFACTNuevo.isnull["IDOM_MAX"])
                {
                    auxPar.Value = oCMAXFACTNuevo.IDOM_MAX;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCMAXFACTAnterior.isnull["IID"])
                {
                    auxPar.Value = oCMAXFACTAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  MAXFACT
  set

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

SUCURSALCLAVE=@SUCURSALCLAVE,

ANIO=@ANIO,

MES=@MES,

LUN_HAY=@LUN_HAY,

LUN_MAX=@LUN_MAX,

MAR_HAY=@MAR_HAY,

MAR_MAX=@MAR_MAX,

MIE_HAY=@MIE_HAY,

MIE_MAX=@MIE_MAX,

JUE_HAY=@JUE_HAY,

JUE_MAX=@JUE_MAX,

VIE_HAY=@VIE_HAY,

VIE_MAX=@VIE_MAX,

SAB_HAY=@SAB_HAY,

SAB_MAX=@SAB_MAX,

DOM_HAY=@DOM_HAY,

DOM_MAX=@DOM_MAX
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



        public bool DesactivarTodosMAXFACTD( FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                string commandText = @"  update maxfact set activo = 'N';";

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



        public CMAXFACTBE seleccionarMAXFACT(CMAXFACTBE oCMAXFACT, FbTransaction st)
        {




            CMAXFACTBE retorno = new CMAXFACTBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from MAXFACT where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMAXFACT.IID;
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

                    if (dr["SUCURSALCLAVE"] != System.DBNull.Value)
                    {
                        retorno.ISUCURSALCLAVE = (string)(dr["SUCURSALCLAVE"]);
                    }

                    if (dr["LUN_HAY"] != System.DBNull.Value)
                    {
                        retorno.ILUN_HAY = (string)(dr["LUN_HAY"]);
                    }

                    if (dr["LUN_MAX"] != System.DBNull.Value)
                    {
                        retorno.ILUN_MAX = (decimal)(dr["LUN_MAX"]);
                    }

                    if (dr["MAR_HAY"] != System.DBNull.Value)
                    {
                        retorno.IMAR_HAY = (string)(dr["MAR_HAY"]);
                    }

                    if (dr["MAR_MAX"] != System.DBNull.Value)
                    {
                        retorno.IMAR_MAX = (decimal)(dr["MAR_MAX"]);
                    }

                    if (dr["MIE_HAY"] != System.DBNull.Value)
                    {
                        retorno.IMIE_HAY = (string)(dr["MIE_HAY"]);
                    }

                    if (dr["MIE_MAX"] != System.DBNull.Value)
                    {
                        retorno.IMIE_MAX = (decimal)(dr["MIE_MAX"]);
                    }

                    if (dr["JUE_HAY"] != System.DBNull.Value)
                    {
                        retorno.IJUE_HAY = (string)(dr["JUE_HAY"]);
                    }

                    if (dr["JUE_MAX"] != System.DBNull.Value)
                    {
                        retorno.IJUE_MAX = (decimal)(dr["JUE_MAX"]);
                    }

                    if (dr["VIE_HAY"] != System.DBNull.Value)
                    {
                        retorno.IVIE_HAY = (string)(dr["VIE_HAY"]);
                    }

                    if (dr["VIE_MAX"] != System.DBNull.Value)
                    {
                        retorno.IVIE_MAX = (decimal)(dr["VIE_MAX"]);
                    }

                    if (dr["SAB_HAY"] != System.DBNull.Value)
                    {
                        retorno.ISAB_HAY = (string)(dr["SAB_HAY"]);
                    }

                    if (dr["SAB_MAX"] != System.DBNull.Value)
                    {
                        retorno.ISAB_MAX = (decimal)(dr["SAB_MAX"]);
                    }

                    if (dr["DOM_HAY"] != System.DBNull.Value)
                    {
                        retorno.IDOM_HAY = (string)(dr["DOM_HAY"]);
                    }

                    if (dr["DOM_MAX"] != System.DBNull.Value)
                    {
                        retorno.IDOM_MAX = (decimal)(dr["DOM_MAX"]);
                    }

                    if (dr["ANIO"] != System.DBNull.Value)
                    {
                        retorno.IANIO = int.Parse(dr["ANIO"].ToString());
                    }

                    if (dr["MES"] != System.DBNull.Value)
                    {
                        retorno.IMES = int.Parse(dr["MES"].ToString());
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


        
        public CMAXFACTBE seleccionarMAXFACTXSucursalYFecha(string sucursalClave, DateTime fecha, FbTransaction st)
        {




            CMAXFACTBE retorno = new CMAXFACTBE();
            FbDataReader dr = null;

            FbConnection pcn = null;


            int mes = fecha.Month;
            int anio = fecha.Year;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from MAXFACT where SUCURSALCLAVE = @SUCURSALCLAVE AND
                                    MES = @MES AND ANIO = @ANIO AND ACTIVO = 'S' ";


                auxPar = new FbParameter("@SUCURSALCLAVE", FbDbType.VarChar);
                auxPar.Value = sucursalClave;
                parts.Add(auxPar);


                auxPar = new FbParameter("@MES", FbDbType.Integer);
                auxPar.Value = mes;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ANIO", FbDbType.Integer);
                auxPar.Value = anio;
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

                    if (dr["SUCURSALCLAVE"] != System.DBNull.Value)
                    {
                        retorno.ISUCURSALCLAVE = (string)(dr["SUCURSALCLAVE"]);
                    }

                    if (dr["LUN_HAY"] != System.DBNull.Value)
                    {
                        retorno.ILUN_HAY = (string)(dr["LUN_HAY"]);
                    }

                    if (dr["LUN_MAX"] != System.DBNull.Value)
                    {
                        retorno.ILUN_MAX = (decimal)(dr["LUN_MAX"]);
                    }

                    if (dr["MAR_HAY"] != System.DBNull.Value)
                    {
                        retorno.IMAR_HAY = (string)(dr["MAR_HAY"]);
                    }

                    if (dr["MAR_MAX"] != System.DBNull.Value)
                    {
                        retorno.IMAR_MAX = (decimal)(dr["MAR_MAX"]);
                    }

                    if (dr["MIE_HAY"] != System.DBNull.Value)
                    {
                        retorno.IMIE_HAY = (string)(dr["MIE_HAY"]);
                    }

                    if (dr["MIE_MAX"] != System.DBNull.Value)
                    {
                        retorno.IMIE_MAX = (decimal)(dr["MIE_MAX"]);
                    }

                    if (dr["JUE_HAY"] != System.DBNull.Value)
                    {
                        retorno.IJUE_HAY = (string)(dr["JUE_HAY"]);
                    }

                    if (dr["JUE_MAX"] != System.DBNull.Value)
                    {
                        retorno.IJUE_MAX = (decimal)(dr["JUE_MAX"]);
                    }

                    if (dr["VIE_HAY"] != System.DBNull.Value)
                    {
                        retorno.IVIE_HAY = (string)(dr["VIE_HAY"]);
                    }

                    if (dr["VIE_MAX"] != System.DBNull.Value)
                    {
                        retorno.IVIE_MAX = (decimal)(dr["VIE_MAX"]);
                    }

                    if (dr["SAB_HAY"] != System.DBNull.Value)
                    {
                        retorno.ISAB_HAY = (string)(dr["SAB_HAY"]);
                    }

                    if (dr["SAB_MAX"] != System.DBNull.Value)
                    {
                        retorno.ISAB_MAX = (decimal)(dr["SAB_MAX"]);
                    }

                    if (dr["DOM_HAY"] != System.DBNull.Value)
                    {
                        retorno.IDOM_HAY = (string)(dr["DOM_HAY"]);
                    }

                    if (dr["DOM_MAX"] != System.DBNull.Value)
                    {
                        retorno.IDOM_MAX = (decimal)(dr["DOM_MAX"]);
                    }

                    if (dr["ANIO"] != System.DBNull.Value)
                    {
                        retorno.IANIO = int.Parse(dr["ANIO"].ToString());
                    }

                    if (dr["MES"] != System.DBNull.Value)
                    {
                        retorno.IMES = int.Parse(dr["MES"].ToString());
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



        public List<CMAXFACTBE> seleccionarMAXFACTxSucusalYAnio(string sucursalClave, int anio, FbTransaction st)
        {



            List<CMAXFACTBE> retornoList = new List<CMAXFACTBE>();

            CMAXFACTBE retorno = new CMAXFACTBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from MAXFACT where SUCURSALCLAVE = @SUCURSALCLAVE AND ANIO = @ANIO  ";


                auxPar = new FbParameter("@SUCURSALCLAVE", FbDbType.BigInt);
                auxPar.Value = sucursalClave;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ANIO", FbDbType.Integer);
                auxPar.Value = anio;
                parts.Add(auxPar);



                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                while (dr.Read())
                {
                    retorno = new CMAXFACTBE();

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

                    if (dr["SUCURSALCLAVE"] != System.DBNull.Value)
                    {
                        retorno.ISUCURSALCLAVE = (string)(dr["SUCURSALCLAVE"]);
                    }

                    if (dr["LUN_HAY"] != System.DBNull.Value)
                    {
                        retorno.ILUN_HAY = (string)(dr["LUN_HAY"]);
                    }

                    if (dr["LUN_MAX"] != System.DBNull.Value)
                    {
                        retorno.ILUN_MAX = (decimal)(dr["LUN_MAX"]);
                    }

                    if (dr["MAR_HAY"] != System.DBNull.Value)
                    {
                        retorno.IMAR_HAY = (string)(dr["MAR_HAY"]);
                    }

                    if (dr["MAR_MAX"] != System.DBNull.Value)
                    {
                        retorno.IMAR_MAX = (decimal)(dr["MAR_MAX"]);
                    }

                    if (dr["MIE_HAY"] != System.DBNull.Value)
                    {
                        retorno.IMIE_HAY = (string)(dr["MIE_HAY"]);
                    }

                    if (dr["MIE_MAX"] != System.DBNull.Value)
                    {
                        retorno.IMIE_MAX = (decimal)(dr["MIE_MAX"]);
                    }

                    if (dr["JUE_HAY"] != System.DBNull.Value)
                    {
                        retorno.IJUE_HAY = (string)(dr["JUE_HAY"]);
                    }

                    if (dr["JUE_MAX"] != System.DBNull.Value)
                    {
                        retorno.IJUE_MAX = (decimal)(dr["JUE_MAX"]);
                    }

                    if (dr["VIE_HAY"] != System.DBNull.Value)
                    {
                        retorno.IVIE_HAY = (string)(dr["VIE_HAY"]);
                    }

                    if (dr["VIE_MAX"] != System.DBNull.Value)
                    {
                        retorno.IVIE_MAX = (decimal)(dr["VIE_MAX"]);
                    }

                    if (dr["SAB_HAY"] != System.DBNull.Value)
                    {
                        retorno.ISAB_HAY = (string)(dr["SAB_HAY"]);
                    }

                    if (dr["SAB_MAX"] != System.DBNull.Value)
                    {
                        retorno.ISAB_MAX = (decimal)(dr["SAB_MAX"]);
                    }

                    if (dr["DOM_HAY"] != System.DBNull.Value)
                    {
                        retorno.IDOM_HAY = (string)(dr["DOM_HAY"]);
                    }

                    if (dr["DOM_MAX"] != System.DBNull.Value)
                    {
                        retorno.IDOM_MAX = (decimal)(dr["DOM_MAX"]);
                    }

                    if (dr["ANIO"] != System.DBNull.Value)
                    {
                        retorno.IANIO = int.Parse(dr["ANIO"].ToString());
                    }

                    if (dr["MES"] != System.DBNull.Value)
                    {
                        retorno.IMES = int.Parse(dr["MES"].ToString());
                    }

                    retornoList.Add(retorno);

                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                return retornoList;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }


        public bool actualizarListaMaxFact(List<CMAXFACTBE> lista , FbTransaction st)
        {
            foreach(CMAXFACTBE item in lista)
            {

                if(!AgregarOModificarMAXFACTD(item,st))
                {
                    return false;
                }
            }

            return true;

        }


        public DataSet enlistarMAXFACT()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_MAXFACT_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public DataSet enlistarCortoMAXFACT()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_MAXFACT_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public int ExisteMAXFACT(CMAXFACTBE oCMAXFACT, FbTransaction st)
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
                auxPar.Value = oCMAXFACT.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from MAXFACT where

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




        public CMAXFACTBE AgregarMAXFACT(CMAXFACTBE oCMAXFACT, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMAXFACT(oCMAXFACT, st);
                if (iRes == 1)
                {
                    this.IComentario = "El MAXFACT ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarMAXFACTD(oCMAXFACT, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarMAXFACT(CMAXFACTBE oCMAXFACT, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMAXFACT(oCMAXFACT, st);
                if (iRes == 0)
                {
                    this.IComentario = "El MAXFACT no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarMAXFACTD(oCMAXFACT, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarMAXFACT(CMAXFACTBE oCMAXFACTNuevo, CMAXFACTBE oCMAXFACTAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMAXFACT(oCMAXFACTAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El MAXFACT no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarMAXFACTD(oCMAXFACTNuevo, oCMAXFACTAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CMAXFACTD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
