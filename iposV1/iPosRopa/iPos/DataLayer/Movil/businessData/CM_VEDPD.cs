
using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Collections;
using ConexionesBD;
using System.Data.OleDb;
using DataLayer;

namespace iPosData
{
    public class CM_VEDPD
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

        /*public static string getFormattedCustomerKey(string value)
        {
            if (value == null || value.Length <= 6)
                return value;

            int firstNumeric = value.IndexOfAny("0123456789".ToCharArray()) ;

            if(firstNumeric < 0)
            {
                return value;
            }
 
        }*/

        public static CM_VEDPBE convertMovtoIntoVEDP(CMOVTOBE movto, CDOCTOBE docto, CPERSONABE persona)
        {
            string CLASIFICA = "";

            CPRODUCTOD prodD = new CPRODUCTOD();
            CPRODUCTOBE prodBE = new CPRODUCTOBE();
            prodBE.IID = movto.IPRODUCTOID;

            prodBE = prodD.seleccionarPRODUCTO(prodBE, null);
            if (prodBE != null && !(bool)prodBE.isnull["ICLASIFICA"])
            {
                CLASIFICA = prodBE.ICLASIFICA;
            }

            CMOVTOD movtoD = new CMOVTOD();
            //CMOVTOBE movtoRegalo = new CMOVTOBE();
            //movtoRegalo = movtoD.seleccionarMOVTOADJUNTO(movto,null);

            CMOVTOBE[] movtosRegalo = movtoD.seleccionarMOVTOSADJUNTO(movto, null);


            CMOVTOBE movtoMain = null;
            if(!(bool)movto.isnull["IMOVTOADJUNTOAID"] && movto.IMOVTOADJUNTOAID != 0)
            {
                movtoMain = new CMOVTOBE();
                movtoMain.IID = movto.IMOVTOADJUNTOAID;
                movtoMain = movtoD.seleccionarMOVTO(movtoMain, null);
            }



            CM_VEDPBE retorno = new CM_VEDPBE();
            retorno.IVENTA = docto.IFOLIO.ToString();
            retorno.ICLIENTE = persona.ICLAVE;
            retorno.IPRODUCTO = movto.ICLAVEPROD;
            retorno.IID_FECHA = docto.IFECHA;
            retorno.IID_HORA = docto.IFECHAHORA != null ? docto.IFECHAHORA.ToString("HH:mm:ss") : "";
            retorno.ICANTIDAD = movto.ICANTIDAD;
            retorno.IPRECIO = movto.IPRECIO;
            retorno.IDESCUENTO = movto.IDESCUENTOPORCENTAJE;
            retorno.ICLASIFICA = CLASIFICA;
            
            
            if(movtosRegalo != null && movtosRegalo.Length > 0)
            {
                retorno.IPROD2 = movtosRegalo[0].ICLAVEPROD;
                if(movtosRegalo.Length > 1)
                {
                    retorno.IPROD3 = movtosRegalo[1].ICLAVEPROD;
                }
            }
            else if(movtoMain != null)
            {
                retorno.IPROD2 = movtoMain.ICLAVEPROD;
                retorno.IOFERTA = "S";
            }

            

            return retorno;
            

        }





        public CM_VEDPBE AgregarM_VEDPD(CM_VEDPBE oCM_VEDP, string strTableName, OleDbTransaction st,string strOleDbConn)
        {

            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@VENTA", OleDbType.VarChar);
                if (!(bool)oCM_VEDP.isnull["IVENTA"])
                {
                    auxPar.Value = oCM_VEDP.IVENTA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CLIENTE", OleDbType.VarChar);
                if (!(bool)oCM_VEDP.isnull["ICLIENTE"])
                {
                    auxPar.Value = oCM_VEDP.ICLIENTE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRODUCTO", OleDbType.VarChar);
                if (!(bool)oCM_VEDP.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCM_VEDP.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESC1", OleDbType.VarChar);
                if (!(bool)oCM_VEDP.isnull["IDESC1"])
                {
                    auxPar.Value = oCM_VEDP.IDESC1;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Decimal);
                if (!(bool)oCM_VEDP.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCM_VEDP.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESCUENTO", OleDbType.Decimal);
                if (!(bool)oCM_VEDP.isnull["IDESCUENTO"])
                {
                    auxPar.Value = oCM_VEDP.IDESCUENTO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CLASIFICA", OleDbType.VarChar);
                if (!(bool)oCM_VEDP.isnull["ICLASIFICA"])
                {
                    auxPar.Value = oCM_VEDP.ICLASIFICA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@AUTORIZA", OleDbType.VarChar);
                if (!(bool)oCM_VEDP.isnull["IAUTORIZA"])
                {
                    auxPar.Value = oCM_VEDP.IAUTORIZA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SURTIDAS", OleDbType.Decimal);
                if (!(bool)oCM_VEDP.isnull["ISURTIDAS"])
                {
                    auxPar.Value = oCM_VEDP.ISURTIDAS;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PROD2", OleDbType.VarChar);
                if (!(bool)oCM_VEDP.isnull["IPROD2"])
                {
                    auxPar.Value = oCM_VEDP.IPROD2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@REQUERIDAS", OleDbType.Decimal);
                if (!(bool)oCM_VEDP.isnull["IREQUERIDAS"])
                {
                    auxPar.Value = oCM_VEDP.IREQUERIDAS;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@AUTOCRED", OleDbType.VarChar);
                if (!(bool)oCM_VEDP.isnull["IAUTOCRED"])
                {
                    auxPar.Value = oCM_VEDP.IAUTOCRED;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCM_VEDP.isnull["IID"])
                {
                    auxPar.Value = oCM_VEDP.IID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCM_VEDP.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_VEDP.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.Today;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCM_VEDP.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_VEDP.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO", OleDbType.Decimal);
                if (!(bool)oCM_VEDP.isnull["IPRECIO"])
                {
                    auxPar.Value = oCM_VEDP.IPRECIO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO '" + strTableName + @"' 
      (
    
VENTA,

CLIENTE,

PRODUCTO,

DESC1,

CANTIDAD,

DESCUENTO,

CLASIFICA,

AUTORIZA,

SURTIDAS,

PROD2,

REQUERIDAS,

AUTOCRED,

ID,

ID_FECHA,

ID_HORA,

PRECIO
         )

Values (

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?
); ";

                OleDbParameter[] arParms = new OleDbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    OleDbHelper.ExecuteNonQuery(strOleDbConn, CommandType.Text, commandText, arParms);
                else
                    OleDbHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCM_VEDP;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }

        
        public CM_VEDPD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
        }


    }
}
