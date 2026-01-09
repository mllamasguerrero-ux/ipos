
using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using System.Data;
using System.Data.OleDb;
using DataLayer;
using System.Collections;
using ConexionesBD;


namespace iPosData
{
    public class CM_PRMD
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

        public bool AgregarM_PRMD(CM_PRMBE oCM_PRM, string strFileName, OleDbTransaction st, string strOleDbConn)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;

                auxPar = new OleDbParameter("@CLAVE", OleDbType.VarChar);
                if (!(bool)oCM_PRM.isnull["ICLAVE"])
                {
                    auxPar.Value = oCM_PRM.ICLAVE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                if (!(bool)oCM_PRM.isnull["INOMBRE"])
                {
                    auxPar.Value = oCM_PRM.INOMBRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCM_PRM.isnull["IID"])
                {
                    auxPar.Value = oCM_PRM.IID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCM_PRM.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_PRM.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCM_PRM.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_PRM.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@DESCRIP", OleDbType.VarChar);
                if(!(bool)oCM_PRM.isnull["IDESCRIP"])
                {
                    auxPar.Value = oCM_PRM.IDESCRIP;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@SUCURSAL", OleDbType.VarChar);
                if(!(bool)oCM_PRM.isnull["ISUCURSAL"])
                {
                    auxPar.Value = oCM_PRM.ISUCURSAL;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Numeric);
                if (!(bool)oCM_PRM.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCM_PRM.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PRODUCTO", OleDbType.VarChar);
                if(!(bool)oCM_PRM.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCM_PRM.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@UTILIDAD", OleDbType.Numeric);
                if(!(bool)oCM_PRM.isnull["IUTILIDAD"])
                {
                    auxPar.Value = oCM_PRM.IUTILIDAD;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CANTLLEV", OleDbType.Numeric);
                if(!(bool)oCM_PRM.isnull["ICANTLLEV"])
                {
                    auxPar.Value = oCM_PRM.ICANTLLEV;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@IMPORTE", OleDbType.Numeric);
                if(!(bool)oCM_PRM.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCM_PRM.IIMPORTE;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PORCDESC", OleDbType.Numeric);
                if(!(bool)oCM_PRM.isnull["IPORCDESC"])
                {
                    auxPar.Value = oCM_PRM.IPORCDESC;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TIPOPROM", OleDbType.VarChar);
                if(!(bool)oCM_PRM.isnull["ITIPOPROM"])
                {
                    auxPar.Value = oCM_PRM.ITIPOPROM;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@RANGPROM", OleDbType.VarChar);
                if(!(bool)oCM_PRM.isnull["IRANGPROM"])
                {
                    auxPar.Value = oCM_PRM.IRANGPROM;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@LINEA", OleDbType.VarChar);
                if(!(bool)oCM_PRM.isnull["ILINEA"])
                {
                    auxPar.Value = oCM_PRM.ILINEA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@FECHAINI", OleDbType.Date);
                if (!(bool)oCM_PRM.isnull["IFECHAINI"])
                {
                    auxPar.Value = oCM_PRM.IFECHAINI;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@FECHAFIN", OleDbType.Date);
                if (!(bool)oCM_PRM.isnull["IFECHAFIN"])
                {
                    auxPar.Value = oCM_PRM.IFECHAFIN;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@LUNES", OleDbType.VarChar);
                if(!(bool)oCM_PRM.isnull["ILUNES"])
                {
                    auxPar.Value = oCM_PRM.ILUNES;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@MARTES", OleDbType.VarChar);
                if (!(bool)oCM_PRM.isnull["IMARTES"])
                {
                    auxPar.Value = oCM_PRM.IMARTES;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@MIERCOLES", OleDbType.VarChar);
                if (!(bool)oCM_PRM.isnull["IMIERCOLES"])
                {
                    auxPar.Value = oCM_PRM.IMIERCOLES;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@JUEVES", OleDbType.VarChar);
                if (!(bool)oCM_PRM.isnull["IJUEVES"])
                {
                    auxPar.Value = oCM_PRM.IJUEVES;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@VIERNES", OleDbType.VarChar);
                if (!(bool)oCM_PRM.isnull["IVIERNES"])
                {
                    auxPar.Value = oCM_PRM.IVIERNES;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@SABADO", OleDbType.VarChar);
                if (!(bool)oCM_PRM.isnull["ISABADO"])
                {
                    auxPar.Value = oCM_PRM.ISABADO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@DOMINGO", OleDbType.VarChar);
                if (!(bool)oCM_PRM.isnull["IDOMINGO"])
                {
                    auxPar.Value = oCM_PRM.IDOMINGO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);




                auxPar = new OleDbParameter("@PORIMPO", OleDbType.Numeric);
                if (!(bool)oCM_PRM.isnull["IPORIMPO"])
                {
                    auxPar.Value = oCM_PRM.IPORIMPO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MONEDERO", OleDbType.VarChar);
                if (!(bool)oCM_PRM.isnull["IMONEDERO"])
                {
                    auxPar.Value = oCM_PRM.IMONEDERO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ACTIVO", OleDbType.VarChar);
                if (!(bool)oCM_PRM.isnull["IACTIVO"])
                {
                    auxPar.Value = oCM_PRM.IACTIVO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MULTDET", OleDbType.VarChar);
                if (!(bool)oCM_PRM.isnull["IMULTDET"])
                {
                    auxPar.Value = oCM_PRM.IMULTDET;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESCMTD", OleDbType.VarChar);
                if (!(bool)oCM_PRM.isnull["IDESCMTD"])
                {
                    auxPar.Value = oCM_PRM.IDESCMTD;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO   " + strFileName + @" 
      (
    
CLAVE,

NOMBRE,

ID,

ID_FECHA,

ID_HORA,

DESCRIP,

SUCURSAL,

CANTIDAD,

PRODUCTO,

UTILIDAD,

CANTLLEV,

IMPORTE,

PORCDESC,

TIPOPROM,

RANGPROM,

LINEA,

FECHAINI,

FECHAFIN,

LUNES,

MARTES,

MIERCOLES,

JUEVES,

VIERNES,

SABADO,

DOMINGO,

PORIMPO,

MONEDERO,

ACTIVO,

MULTDET,

DESCMTD
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
