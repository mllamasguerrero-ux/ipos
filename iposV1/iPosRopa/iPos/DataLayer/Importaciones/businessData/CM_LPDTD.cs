
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



    public class CM_LPDTD
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


        public bool AgregarM_LPDTD(CM_LPDTBE oCM_LPDT, string strFileName, OleDbTransaction st, string strOleDbConn)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@PRODUCTO", OleDbType.VarChar);
                if (!(bool)oCM_LPDT.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCM_LPDT.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LISTA", OleDbType.VarChar);
                if (!(bool)oCM_LPDT.isnull["ILISTA"])
                {
                    auxPar.Value = oCM_LPDT.ILISTA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);






                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCM_LPDT.isnull["IID"])
                {
                    auxPar.Value = oCM_LPDT.IID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCM_LPDT.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_LPDT.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCM_LPDT.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_LPDT.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO1", OleDbType.Decimal);
                if (!(bool)oCM_LPDT.isnull["IPRECIO1"])
                {
                    auxPar.Value = oCM_LPDT.IPRECIO1;
                }
                else
                {
                    auxPar.Value = 0.0m;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO2", OleDbType.Decimal);
                if (!(bool)oCM_LPDT.isnull["IPRECIO2"])
                {
                    auxPar.Value = oCM_LPDT.IPRECIO2;
                }
                else
                {
                    auxPar.Value = 0.0m;
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@PRECIO3", OleDbType.Decimal);
                if (!(bool)oCM_LPDT.isnull["IPRECIO3"])
                {
                    auxPar.Value = oCM_LPDT.IPRECIO3;
                }
                else
                {
                    auxPar.Value = 0.0m;
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@PRECIO4", OleDbType.Decimal);
                if (!(bool)oCM_LPDT.isnull["IPRECIO4"])
                {
                    auxPar.Value = oCM_LPDT.IPRECIO4;
                }
                else
                {
                    auxPar.Value = 0.0m;
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@PRECIO5", OleDbType.Decimal);
                if (!(bool)oCM_LPDT.isnull["IPRECIO5"])
                {
                    auxPar.Value = oCM_LPDT.IPRECIO5;
                }
                else
                {
                    auxPar.Value = 0.0m;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO6", OleDbType.Decimal);
                    auxPar.Value = 0.0m;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTOREP", OleDbType.Decimal);
                if (!(bool)oCM_LPDT.isnull["ICOSTOREP"])
                {
                    auxPar.Value = oCM_LPDT.ICOSTOREP;
                }
                else
                {
                    auxPar.Value = 0.0m;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TIENEVIG", OleDbType.VarChar);
                if (!(bool)oCM_LPDT.isnull["ITIENEVIG"])
                {
                    auxPar.Value = oCM_LPDT.ITIENEVIG;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FECHAVIG", OleDbType.Date);
                if (!(bool)oCM_LPDT.isnull["IFECHAVIG"])
                {
                    auxPar.Value = oCM_LPDT.IFECHAVIG;
                }
                else
                {
                    auxPar.Value = DateTime.Today.AddYears(10);
                }
                parts.Add(auxPar);




                string commandText = @"
        INSERT INTO   " + strFileName + @" 
      (
    
PRODUCTO,

LISTA,

ID,

ID_FECHA,

ID_HORA,

PRECIO1,

PRECIO2,

PRECIO3,

PRECIO4,

PRECIO5,

PRECIO6,

COSTOREP,

TIENEVIG,

FECHAVIG
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