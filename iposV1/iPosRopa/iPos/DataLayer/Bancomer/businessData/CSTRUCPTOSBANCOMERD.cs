

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




    public class CSTRUCPTOSBANCOMERD
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



        public CSTRUCPTOSBANCOMERBE AgregarSTRUCPTOSBANCOMERD(CSTRUCPTOSBANCOMERBE oCSTRUCPTOSBANCOMER, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCSTRUCPTOSBANCOMER.isnull["IID"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMER.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSTRUCPTOSBANCOMER.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMER.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSTRUCPTOSBANCOMER.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMER.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSTRUCPTOSBANCOMER.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMER.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CARDREQUEST", FbDbType.VarChar);
                if (!(bool)oCSTRUCPTOSBANCOMER.isnull["ICARDREQUEST"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMER.ICARDREQUEST;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ECOUPNUMBER", FbDbType.VarChar);
                if (!(bool)oCSTRUCPTOSBANCOMER.isnull["IECOUPNUMBER"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMER.IECOUPNUMBER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FACTOREXP", FbDbType.VarChar);
                if (!(bool)oCSTRUCPTOSBANCOMER.isnull["IFACTOREXP"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMER.IFACTOREXP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PESOSREDIMIDOS", FbDbType.VarChar);
                if (!(bool)oCSTRUCPTOSBANCOMER.isnull["IPESOSREDIMIDOS"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMER.IPESOSREDIMIDOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PESOSSALDOANTERIOR", FbDbType.VarChar);
                if (!(bool)oCSTRUCPTOSBANCOMER.isnull["IPESOSSALDOANTERIOR"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMER.IPESOSSALDOANTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PESOSSALDODISPONIBLE", FbDbType.VarChar);
                if (!(bool)oCSTRUCPTOSBANCOMER.isnull["IPESOSSALDODISPONIBLE"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMER.IPESOSSALDODISPONIBLE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PESOSSALDODISPONINLEEXP", FbDbType.VarChar);
                if (!(bool)oCSTRUCPTOSBANCOMER.isnull["IPESOSSALDODISPONINLEEXP"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMER.IPESOSSALDODISPONINLEEXP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PESOSSALDOREDIMIDOSEXP", FbDbType.VarChar);
                if (!(bool)oCSTRUCPTOSBANCOMER.isnull["IPESOSSALDOREDIMIDOSEXP"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMER.IPESOSSALDOREDIMIDOSEXP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@POOLADJUSTTYPE", FbDbType.VarChar);
                if (!(bool)oCSTRUCPTOSBANCOMER.isnull["IPOOLADJUSTTYPE"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMER.IPOOLADJUSTTYPE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@POOLID", FbDbType.VarChar);
                if (!(bool)oCSTRUCPTOSBANCOMER.isnull["IPOOLID"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMER.IPOOLID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@POOLNUMBER", FbDbType.VarChar);
                if (!(bool)oCSTRUCPTOSBANCOMER.isnull["IPOOLNUMBER"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMER.IPOOLNUMBER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@POOLUNITLABEL", FbDbType.VarChar);
                if (!(bool)oCSTRUCPTOSBANCOMER.isnull["IPOOLUNITLABEL"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMER.IPOOLUNITLABEL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PUNTOSREDIMIDOS", FbDbType.VarChar);
                if (!(bool)oCSTRUCPTOSBANCOMER.isnull["IPUNTOSREDIMIDOS"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMER.IPUNTOSREDIMIDOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PUNTOSSALDOANTERIOR", FbDbType.VarChar);
                if (!(bool)oCSTRUCPTOSBANCOMER.isnull["IPUNTOSSALDOANTERIOR"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMER.IPUNTOSSALDOANTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PUNTOSSALDODISPONIBLE", FbDbType.VarChar);
                if (!(bool)oCSTRUCPTOSBANCOMER.isnull["IPUNTOSSALDODISPONIBLE"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMER.IPUNTOSSALDODISPONIBLE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PUNTOSSALDODISPONIBLEEXP", FbDbType.VarChar);
                if (!(bool)oCSTRUCPTOSBANCOMER.isnull["IPUNTOSSALDODISPONIBLEEXP"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMER.IPUNTOSSALDODISPONIBLEEXP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PUNTOSSALDOREDIMIDOEXP", FbDbType.VarChar);
                if (!(bool)oCSTRUCPTOSBANCOMER.isnull["IPUNTOSSALDOREDIMIDOEXP"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMER.IPUNTOSSALDOREDIMIDOEXP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SEGMENTNUMBER", FbDbType.VarChar);
                if (!(bool)oCSTRUCPTOSBANCOMER.isnull["ISEGMENTNUMBER"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMER.ISEGMENTNUMBER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOPOS", FbDbType.VarChar);
                if (!(bool)oCSTRUCPTOSBANCOMER.isnull["ITIPOPOS"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMER.ITIPOPOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VIGENCIAPROMOCIONEXP", FbDbType.VarChar);
                if (!(bool)oCSTRUCPTOSBANCOMER.isnull["IVIGENCIAPROMOCIONEXP"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMER.IVIGENCIAPROMOCIONEXP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO STRUCPTOSBANCOMER
      (
    
ID,

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

CARDREQUEST,

ECOUPNUMBER,

FACTOREXP,

PESOSREDIMIDOS,

PESOSSALDOANTERIOR,

PESOSSALDODISPONIBLE,

PESOSSALDODISPONINLEEXP,

PESOSSALDOREDIMIDOSEXP,

POOLADJUSTTYPE,

POOLID,

POOLNUMBER,

POOLUNITLABEL,

PUNTOSREDIMIDOS,

PUNTOSSALDOANTERIOR,

PUNTOSSALDODISPONIBLE,

PUNTOSSALDODISPONIBLEEXP,

PUNTOSSALDOREDIMIDOEXP,

SEGMENTNUMBER,

TIPOPOS,

VIGENCIAPROMOCIONEXP
         )

Values (

@ID,

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@CARDREQUEST,

@ECOUPNUMBER,

@FACTOREXP,

@PESOSREDIMIDOS,

@PESOSSALDOANTERIOR,

@PESOSSALDODISPONIBLE,

@PESOSSALDODISPONINLEEXP,

@PESOSSALDOREDIMIDOSEXP,

@POOLADJUSTTYPE,

@POOLID,

@POOLNUMBER,

@POOLUNITLABEL,

@PUNTOSREDIMIDOS,

@PUNTOSSALDOANTERIOR,

@PUNTOSSALDODISPONIBLE,

@PUNTOSSALDODISPONIBLEEXP,

@PUNTOSSALDOREDIMIDOEXP,

@SEGMENTNUMBER,

@TIPOPOS,

@VIGENCIAPROMOCIONEXP
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCSTRUCPTOSBANCOMER;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }



        public bool BorrarSTRUCPTOSBANCOMERD(CSTRUCPTOSBANCOMERBE oCSTRUCPTOSBANCOMER, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSTRUCPTOSBANCOMER.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from STRUCPTOSBANCOMER
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



        public bool CambiarSTRUCPTOSBANCOMERD(CSTRUCPTOSBANCOMERBE oCSTRUCPTOSBANCOMERNuevo, CSTRUCPTOSBANCOMERBE oCSTRUCPTOSBANCOMERAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCSTRUCPTOSBANCOMERNuevo.isnull["IID"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMERNuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSTRUCPTOSBANCOMERNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMERNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSTRUCPTOSBANCOMERNuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMERNuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSTRUCPTOSBANCOMERNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMERNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CARDREQUEST", FbDbType.VarChar);
                if (!(bool)oCSTRUCPTOSBANCOMERNuevo.isnull["ICARDREQUEST"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMERNuevo.ICARDREQUEST;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ECOUPNUMBER", FbDbType.VarChar);
                if (!(bool)oCSTRUCPTOSBANCOMERNuevo.isnull["IECOUPNUMBER"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMERNuevo.IECOUPNUMBER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FACTOREXP", FbDbType.VarChar);
                if (!(bool)oCSTRUCPTOSBANCOMERNuevo.isnull["IFACTOREXP"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMERNuevo.IFACTOREXP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PESOSREDIMIDOS", FbDbType.VarChar);
                if (!(bool)oCSTRUCPTOSBANCOMERNuevo.isnull["IPESOSREDIMIDOS"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMERNuevo.IPESOSREDIMIDOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PESOSSALDOANTERIOR", FbDbType.VarChar);
                if (!(bool)oCSTRUCPTOSBANCOMERNuevo.isnull["IPESOSSALDOANTERIOR"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMERNuevo.IPESOSSALDOANTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PESOSSALDODISPONIBLE", FbDbType.VarChar);
                if (!(bool)oCSTRUCPTOSBANCOMERNuevo.isnull["IPESOSSALDODISPONIBLE"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMERNuevo.IPESOSSALDODISPONIBLE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PESOSSALDODISPONINLEEXP", FbDbType.VarChar);
                if (!(bool)oCSTRUCPTOSBANCOMERNuevo.isnull["IPESOSSALDODISPONINLEEXP"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMERNuevo.IPESOSSALDODISPONINLEEXP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PESOSSALDOREDIMIDOSEXP", FbDbType.VarChar);
                if (!(bool)oCSTRUCPTOSBANCOMERNuevo.isnull["IPESOSSALDOREDIMIDOSEXP"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMERNuevo.IPESOSSALDOREDIMIDOSEXP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@POOLADJUSTTYPE", FbDbType.VarChar);
                if (!(bool)oCSTRUCPTOSBANCOMERNuevo.isnull["IPOOLADJUSTTYPE"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMERNuevo.IPOOLADJUSTTYPE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@POOLID", FbDbType.VarChar);
                if (!(bool)oCSTRUCPTOSBANCOMERNuevo.isnull["IPOOLID"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMERNuevo.IPOOLID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@POOLNUMBER", FbDbType.VarChar);
                if (!(bool)oCSTRUCPTOSBANCOMERNuevo.isnull["IPOOLNUMBER"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMERNuevo.IPOOLNUMBER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@POOLUNITLABEL", FbDbType.VarChar);
                if (!(bool)oCSTRUCPTOSBANCOMERNuevo.isnull["IPOOLUNITLABEL"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMERNuevo.IPOOLUNITLABEL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PUNTOSREDIMIDOS", FbDbType.VarChar);
                if (!(bool)oCSTRUCPTOSBANCOMERNuevo.isnull["IPUNTOSREDIMIDOS"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMERNuevo.IPUNTOSREDIMIDOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PUNTOSSALDOANTERIOR", FbDbType.VarChar);
                if (!(bool)oCSTRUCPTOSBANCOMERNuevo.isnull["IPUNTOSSALDOANTERIOR"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMERNuevo.IPUNTOSSALDOANTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PUNTOSSALDODISPONIBLE", FbDbType.VarChar);
                if (!(bool)oCSTRUCPTOSBANCOMERNuevo.isnull["IPUNTOSSALDODISPONIBLE"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMERNuevo.IPUNTOSSALDODISPONIBLE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PUNTOSSALDODISPONIBLEEXP", FbDbType.VarChar);
                if (!(bool)oCSTRUCPTOSBANCOMERNuevo.isnull["IPUNTOSSALDODISPONIBLEEXP"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMERNuevo.IPUNTOSSALDODISPONIBLEEXP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PUNTOSSALDOREDIMIDOEXP", FbDbType.VarChar);
                if (!(bool)oCSTRUCPTOSBANCOMERNuevo.isnull["IPUNTOSSALDOREDIMIDOEXP"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMERNuevo.IPUNTOSSALDOREDIMIDOEXP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SEGMENTNUMBER", FbDbType.VarChar);
                if (!(bool)oCSTRUCPTOSBANCOMERNuevo.isnull["ISEGMENTNUMBER"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMERNuevo.ISEGMENTNUMBER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPOPOS", FbDbType.VarChar);
                if (!(bool)oCSTRUCPTOSBANCOMERNuevo.isnull["ITIPOPOS"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMERNuevo.ITIPOPOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@VIGENCIAPROMOCIONEXP", FbDbType.VarChar);
                if (!(bool)oCSTRUCPTOSBANCOMERNuevo.isnull["IVIGENCIAPROMOCIONEXP"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMERNuevo.IVIGENCIAPROMOCIONEXP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCSTRUCPTOSBANCOMERAnterior.isnull["IID"])
                {
                    auxPar.Value = oCSTRUCPTOSBANCOMERAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  STRUCPTOSBANCOMER
  set

ID=@ID,

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

CARDREQUEST=@CARDREQUEST,

ECOUPNUMBER=@ECOUPNUMBER,

FACTOREXP=@FACTOREXP,

PESOSREDIMIDOS=@PESOSREDIMIDOS,

PESOSSALDOANTERIOR=@PESOSSALDOANTERIOR,

PESOSSALDODISPONIBLE=@PESOSSALDODISPONIBLE,

PESOSSALDODISPONINLEEXP=@PESOSSALDODISPONINLEEXP,

PESOSSALDOREDIMIDOSEXP=@PESOSSALDOREDIMIDOSEXP,

POOLADJUSTTYPE=@POOLADJUSTTYPE,

POOLID=@POOLID,

POOLNUMBER=@POOLNUMBER,

POOLUNITLABEL=@POOLUNITLABEL,

PUNTOSREDIMIDOS=@PUNTOSREDIMIDOS,

PUNTOSSALDOANTERIOR=@PUNTOSSALDOANTERIOR,

PUNTOSSALDODISPONIBLE=@PUNTOSSALDODISPONIBLE,

PUNTOSSALDODISPONIBLEEXP=@PUNTOSSALDODISPONIBLEEXP,

PUNTOSSALDOREDIMIDOEXP=@PUNTOSSALDOREDIMIDOEXP,

SEGMENTNUMBER=@SEGMENTNUMBER,

TIPOPOS=@TIPOPOS,

VIGENCIAPROMOCIONEXP=@VIGENCIAPROMOCIONEXP
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



        public CSTRUCPTOSBANCOMERBE seleccionarSTRUCPTOSBANCOMER(CSTRUCPTOSBANCOMERBE oCSTRUCPTOSBANCOMER, FbTransaction st)
        {




            CSTRUCPTOSBANCOMERBE retorno = new CSTRUCPTOSBANCOMERBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from STRUCPTOSBANCOMER where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSTRUCPTOSBANCOMER.IID;
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

                    if (dr["CARDREQUEST"] != System.DBNull.Value)
                    {
                        retorno.ICARDREQUEST = (string)(dr["CARDREQUEST"]);
                    }

                    if (dr["ECOUPNUMBER"] != System.DBNull.Value)
                    {
                        retorno.IECOUPNUMBER = (string)(dr["ECOUPNUMBER"]);
                    }

                    if (dr["FACTOREXP"] != System.DBNull.Value)
                    {
                        retorno.IFACTOREXP = (string)(dr["FACTOREXP"]);
                    }

                    if (dr["PESOSREDIMIDOS"] != System.DBNull.Value)
                    {
                        retorno.IPESOSREDIMIDOS = (string)(dr["PESOSREDIMIDOS"]);
                    }

                    if (dr["PESOSSALDOANTERIOR"] != System.DBNull.Value)
                    {
                        retorno.IPESOSSALDOANTERIOR = (string)(dr["PESOSSALDOANTERIOR"]);
                    }

                    if (dr["PESOSSALDODISPONIBLE"] != System.DBNull.Value)
                    {
                        retorno.IPESOSSALDODISPONIBLE = (string)(dr["PESOSSALDODISPONIBLE"]);
                    }

                    if (dr["PESOSSALDODISPONINLEEXP"] != System.DBNull.Value)
                    {
                        retorno.IPESOSSALDODISPONINLEEXP = (string)(dr["PESOSSALDODISPONINLEEXP"]);
                    }

                    if (dr["PESOSSALDOREDIMIDOSEXP"] != System.DBNull.Value)
                    {
                        retorno.IPESOSSALDOREDIMIDOSEXP = (string)(dr["PESOSSALDOREDIMIDOSEXP"]);
                    }

                    if (dr["POOLADJUSTTYPE"] != System.DBNull.Value)
                    {
                        retorno.IPOOLADJUSTTYPE = (string)(dr["POOLADJUSTTYPE"]);
                    }

                    if (dr["POOLID"] != System.DBNull.Value)
                    {
                        retorno.IPOOLID = (string)(dr["POOLID"]);
                    }

                    if (dr["POOLNUMBER"] != System.DBNull.Value)
                    {
                        retorno.IPOOLNUMBER = (string)(dr["POOLNUMBER"]);
                    }

                    if (dr["POOLUNITLABEL"] != System.DBNull.Value)
                    {
                        retorno.IPOOLUNITLABEL = (string)(dr["POOLUNITLABEL"]);
                    }

                    if (dr["PUNTOSREDIMIDOS"] != System.DBNull.Value)
                    {
                        retorno.IPUNTOSREDIMIDOS = (string)(dr["PUNTOSREDIMIDOS"]);
                    }

                    if (dr["PUNTOSSALDOANTERIOR"] != System.DBNull.Value)
                    {
                        retorno.IPUNTOSSALDOANTERIOR = (string)(dr["PUNTOSSALDOANTERIOR"]);
                    }

                    if (dr["PUNTOSSALDODISPONIBLE"] != System.DBNull.Value)
                    {
                        retorno.IPUNTOSSALDODISPONIBLE = (string)(dr["PUNTOSSALDODISPONIBLE"]);
                    }

                    if (dr["PUNTOSSALDODISPONIBLEEXP"] != System.DBNull.Value)
                    {
                        retorno.IPUNTOSSALDODISPONIBLEEXP = (string)(dr["PUNTOSSALDODISPONIBLEEXP"]);
                    }

                    if (dr["PUNTOSSALDOREDIMIDOEXP"] != System.DBNull.Value)
                    {
                        retorno.IPUNTOSSALDOREDIMIDOEXP = (string)(dr["PUNTOSSALDOREDIMIDOEXP"]);
                    }

                    if (dr["SEGMENTNUMBER"] != System.DBNull.Value)
                    {
                        retorno.ISEGMENTNUMBER = (string)(dr["SEGMENTNUMBER"]);
                    }

                    if (dr["TIPOPOS"] != System.DBNull.Value)
                    {
                        retorno.ITIPOPOS = (string)(dr["TIPOPOS"]);
                    }

                    if (dr["VIGENCIAPROMOCIONEXP"] != System.DBNull.Value)
                    {
                        retorno.IVIGENCIAPROMOCIONEXP = (string)(dr["VIGENCIAPROMOCIONEXP"]);
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










        public DataSet enlistarSTRUCPTOSBANCOMER()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_STRUCPTOSBANCOMER_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }





        public DataSet enlistarCortoSTRUCPTOSBANCOMER()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_STRUCPTOSBANCOMER_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public int ExisteSTRUCPTOSBANCOMER(CSTRUCPTOSBANCOMERBE oCSTRUCPTOSBANCOMER, FbTransaction st)
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
                auxPar.Value = oCSTRUCPTOSBANCOMER.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from STRUCPTOSBANCOMER where

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




        public CSTRUCPTOSBANCOMERBE AgregarSTRUCPTOSBANCOMER(CSTRUCPTOSBANCOMERBE oCSTRUCPTOSBANCOMER, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSTRUCPTOSBANCOMER(oCSTRUCPTOSBANCOMER, st);
                if (iRes == 1)
                {
                    this.IComentario = "El STRUCPTOSBANCOMER ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarSTRUCPTOSBANCOMERD(oCSTRUCPTOSBANCOMER, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarSTRUCPTOSBANCOMER(CSTRUCPTOSBANCOMERBE oCSTRUCPTOSBANCOMER, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSTRUCPTOSBANCOMER(oCSTRUCPTOSBANCOMER, st);
                if (iRes == 0)
                {
                    this.IComentario = "El STRUCPTOSBANCOMER no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarSTRUCPTOSBANCOMERD(oCSTRUCPTOSBANCOMER, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarSTRUCPTOSBANCOMER(CSTRUCPTOSBANCOMERBE oCSTRUCPTOSBANCOMERNuevo, CSTRUCPTOSBANCOMERBE oCSTRUCPTOSBANCOMERAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSTRUCPTOSBANCOMER(oCSTRUCPTOSBANCOMERAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El STRUCPTOSBANCOMER no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarSTRUCPTOSBANCOMERD(oCSTRUCPTOSBANCOMERNuevo, oCSTRUCPTOSBANCOMERAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CSTRUCPTOSBANCOMERD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
