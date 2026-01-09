
using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
//using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Data.OleDb;
using DataLayer;
using System.Collections;
using ConexionesBD;


namespace iPosData
{



    public class CM_MXFTD
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


        public bool AgregarM_MXFTD(CM_MXFTBE oCM_MXFT, string strFileName, OleDbTransaction st, string strOleDbConn)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@SUCURSAL", OleDbType.VarChar);
                if (!(bool)oCM_MXFT.isnull["ISUCURSAL"])
                {
                    auxPar.Value = oCM_MXFT.ISUCURSAL;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);





                auxPar = new OleDbParameter("@ANIO", OleDbType.Integer);
                if (!(bool)oCM_MXFT.isnull["IANIO"])
                {
                    auxPar.Value = oCM_MXFT.IANIO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@MES", OleDbType.Integer);
                if (!(bool)oCM_MXFT.isnull["IMES"])
                {
                    auxPar.Value = oCM_MXFT.IMES;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@LUN_HAY", OleDbType.VarChar);
                if (!(bool)oCM_MXFT.isnull["ILUN_HAY"])
                {
                    auxPar.Value = oCM_MXFT.ILUN_HAY;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@LUN_MAX", OleDbType.Decimal);
                if (!(bool)oCM_MXFT.isnull["ILUN_MAX"])
                {
                    auxPar.Value = oCM_MXFT.ILUN_MAX;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);




                auxPar = new OleDbParameter("@MAR_HAY", OleDbType.VarChar);
                if (!(bool)oCM_MXFT.isnull["IMAR_HAY"])
                {
                    auxPar.Value = oCM_MXFT.IMAR_HAY;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@MAR_MAX", OleDbType.Decimal);
                if (!(bool)oCM_MXFT.isnull["IMAR_MAX"])
                {
                    auxPar.Value = oCM_MXFT.IMAR_MAX;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@MIE_HAY", OleDbType.VarChar);
                if (!(bool)oCM_MXFT.isnull["IMIE_HAY"])
                {
                    auxPar.Value = oCM_MXFT.IMIE_HAY;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@MIE_MAX", OleDbType.Decimal);
                if (!(bool)oCM_MXFT.isnull["IMIE_MAX"])
                {
                    auxPar.Value = oCM_MXFT.IMIE_MAX;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@JUE_HAY", OleDbType.VarChar);
                if (!(bool)oCM_MXFT.isnull["IJUE_HAY"])
                {
                    auxPar.Value = oCM_MXFT.IJUE_HAY;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@JUE_MAX", OleDbType.Decimal);
                if (!(bool)oCM_MXFT.isnull["IJUE_MAX"])
                {
                    auxPar.Value = oCM_MXFT.IJUE_MAX;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@VIE_HAY", OleDbType.VarChar);
                if (!(bool)oCM_MXFT.isnull["IVIE_HAY"])
                {
                    auxPar.Value = oCM_MXFT.IVIE_HAY;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@VIE_MAX", OleDbType.Decimal);
                if (!(bool)oCM_MXFT.isnull["IVIE_MAX"])
                {
                    auxPar.Value = oCM_MXFT.IVIE_MAX;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@SAB_HAY", OleDbType.VarChar);
                if (!(bool)oCM_MXFT.isnull["ISAB_HAY"])
                {
                    auxPar.Value = oCM_MXFT.ISAB_HAY;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@SAB_MAX", OleDbType.Decimal);
                if (!(bool)oCM_MXFT.isnull["ISAB_MAX"])
                {
                    auxPar.Value = oCM_MXFT.ISAB_MAX;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@DOM_HAY", OleDbType.VarChar);
                if (!(bool)oCM_MXFT.isnull["IDOM_HAY"])
                {
                    auxPar.Value = oCM_MXFT.IDOM_HAY;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@DOM_MAX", OleDbType.Decimal);
                if (!(bool)oCM_MXFT.isnull["IDOM_MAX"])
                {
                    auxPar.Value = oCM_MXFT.IDOM_MAX;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);






                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCM_MXFT.isnull["IID"])
                {
                    auxPar.Value = oCM_MXFT.IID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCM_MXFT.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_MXFT.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCM_MXFT.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_MXFT.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                


                string commandText = @"
        INSERT INTO   " + strFileName + @" 
      (
    
SUCURSAL,

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

DOM_MAX,

ID,

ID_FECHA,

ID_HORA
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






                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }
    }
}