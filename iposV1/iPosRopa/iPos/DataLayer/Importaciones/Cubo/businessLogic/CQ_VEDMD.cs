
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



    public class CQ_VEDMD
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


        public bool AgregarQ_VEDMD(CQ_VEDMBE oCQ_VEDM, string strFileName, OleDbTransaction st, string strOleDbConn)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@VENTA", OleDbType.VarChar);
                if (!(bool)oCQ_VEDM.isnull["IVENTA"])
                {
                    auxPar.Value = oCQ_VEDM.IVENTA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CLIENTE", OleDbType.VarChar);
                if (!(bool)oCQ_VEDM.isnull["ICLIENTE"])
                {
                    auxPar.Value = oCQ_VEDM.ICLIENTE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Double);
                if (!(bool)oCQ_VEDM.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCQ_VEDM.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRODUCTO", OleDbType.VarChar);
                if (!(bool)oCQ_VEDM.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCQ_VEDM.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PROVEEDOR", OleDbType.VarChar);
                if (!(bool)oCQ_VEDM.isnull["IPROVEEDOR"])
                {
                    auxPar.Value = oCQ_VEDM.IPROVEEDOR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LINEA", OleDbType.VarChar);
                if (!(bool)oCQ_VEDM.isnull["ILINEA"])
                {
                    auxPar.Value = oCQ_VEDM.ILINEA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MARCA", OleDbType.VarChar);
                if (!(bool)oCQ_VEDM.isnull["IMARCA"])
                {
                    auxPar.Value = oCQ_VEDM.IMARCA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@VENDEDOR", OleDbType.VarChar);
                if (!(bool)oCQ_VEDM.isnull["IVENDEDOR"])
                {
                    auxPar.Value = oCQ_VEDM.IVENDEDOR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TIPO", OleDbType.VarChar);
                if (!(bool)oCQ_VEDM.isnull["ITIPO"])
                {
                    auxPar.Value = oCQ_VEDM.ITIPO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CLASIFICA", OleDbType.VarChar);
                if (!(bool)oCQ_VEDM.isnull["ICLASIFICA"])
                {
                    auxPar.Value = oCQ_VEDM.ICLASIFICA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO", OleDbType.Double);
                if (!(bool)oCQ_VEDM.isnull["IPRECIO"])
                {
                    auxPar.Value = oCQ_VEDM.IPRECIO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PREC_LISTA", OleDbType.Double);
                if (!(bool)oCQ_VEDM.isnull["IPREC_LISTA"])
                {
                    auxPar.Value = oCQ_VEDM.IPREC_LISTA;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FECHA", OleDbType.Date);
                if (!(bool)oCQ_VEDM.isnull["IFECHA"])
                {
                    auxPar.Value = oCQ_VEDM.IFECHA;
                }
                else
                {
                    auxPar.Value = DateTime.Today;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESTATUS", OleDbType.VarChar);
                if (!(bool)oCQ_VEDM.isnull["IESTATUS"])
                {
                    auxPar.Value = oCQ_VEDM.IESTATUS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPORTE", OleDbType.Double);
                if (!(bool)oCQ_VEDM.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCQ_VEDM.IIMPORTE;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPORTNETO", OleDbType.Double);
                if (!(bool)oCQ_VEDM.isnull["IIMPORTNETO"])
                {
                    auxPar.Value = oCQ_VEDM.IIMPORTNETO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPORTOPE", OleDbType.Double);
                if (!(bool)oCQ_VEDM.isnull["IIMPORTOPE"])
                {
                    auxPar.Value = oCQ_VEDM.IIMPORTOPE;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TOTAL", OleDbType.Double);
                if (!(bool)oCQ_VEDM.isnull["ITOTAL"])
                {
                    auxPar.Value = oCQ_VEDM.ITOTAL;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@UTILIDAD", OleDbType.Double);
                if (!(bool)oCQ_VEDM.isnull["IUTILIDAD"])
                {
                    auxPar.Value = oCQ_VEDM.IUTILIDAD;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTO_PU", OleDbType.Double);
                if (!(bool)oCQ_VEDM.isnull["ICOSTO_PU"])
                {
                    auxPar.Value = oCQ_VEDM.ICOSTO_PU;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TIENDA", OleDbType.Double);
                if (!(bool)oCQ_VEDM.isnull["ITIENDA"])
                {
                    auxPar.Value = oCQ_VEDM.ITIENDA;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTOTAL", OleDbType.Double);
                if (!(bool)oCQ_VEDM.isnull["ICOSTOTAL"])
                {
                    auxPar.Value = oCQ_VEDM.ICOSTOTAL;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESCUENTO", OleDbType.Double);
                if (!(bool)oCQ_VEDM.isnull["IDESCUENTO"])
                {
                    auxPar.Value = oCQ_VEDM.IDESCUENTO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COMISION", OleDbType.Double);
                if (!(bool)oCQ_VEDM.isnull["ICOMISION"])
                {
                    auxPar.Value = oCQ_VEDM.ICOMISION;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCQ_VEDM.isnull["IID"])
                {
                    auxPar.Value = oCQ_VEDM.IID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCQ_VEDM.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCQ_VEDM.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.Today;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCQ_VEDM.isnull["IID_HORA"])
                {
                    auxPar.Value = oCQ_VEDM.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IVA", OleDbType.Double);
                if (!(bool)oCQ_VEDM.isnull["IIVA"])
                {
                    auxPar.Value = oCQ_VEDM.IIVA;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IEPS19", OleDbType.Double);
                if (!(bool)oCQ_VEDM.isnull["IIEPS19"])
                {
                    auxPar.Value = oCQ_VEDM.IIEPS19;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IEPS20", OleDbType.Double);
                if (!(bool)oCQ_VEDM.isnull["IIEPS20"])
                {
                    auxPar.Value = oCQ_VEDM.IIEPS20;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IEPS25", OleDbType.Double);
                if (!(bool)oCQ_VEDM.isnull["IIEPS25"])
                {
                    auxPar.Value = oCQ_VEDM.IIEPS25;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IEPS30", OleDbType.Double);
                if (!(bool)oCQ_VEDM.isnull["IIEPS30"])
                {
                    auxPar.Value = oCQ_VEDM.IIEPS30;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IEPS50", OleDbType.Double);
                if (!(bool)oCQ_VEDM.isnull["IIEPS50"])
                {
                    auxPar.Value = oCQ_VEDM.IIEPS50;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IEPS60", OleDbType.Double);
                if (!(bool)oCQ_VEDM.isnull["IIEPS60"])
                {
                    auxPar.Value = oCQ_VEDM.IIEPS60;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@EXPORTADOC", OleDbType.Boolean);
                if (!(bool)oCQ_VEDM.isnull["IEXPORTADOC"])
                {
                    auxPar.Value = oCQ_VEDM.IEXPORTADOC;
                }
                else
                {
                    auxPar.Value = false;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CGO_EXC", OleDbType.Double);
                if (!(bool)oCQ_VEDM.isnull["ICGO_EXC"])
                {
                    auxPar.Value = oCQ_VEDM.ICGO_EXC;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@OLLA", OleDbType.Double);
                if (!(bool)oCQ_VEDM.isnull["IOLLA"])
                {
                    auxPar.Value = oCQ_VEDM.IOLLA;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESCTOPE", OleDbType.Double);
                if (!(bool)oCQ_VEDM.isnull["IDESCTOPE"])
                {
                    auxPar.Value = oCQ_VEDM.IDESCTOPE;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PROMOCION", OleDbType.VarChar);
                if (!(bool)oCQ_VEDM.isnull["IPROMOCION"])
                {
                    auxPar.Value = oCQ_VEDM.IPROMOCION;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SUCU", OleDbType.VarChar);
                if (!(bool)oCQ_VEDM.isnull["ISUCU"])
                {
                    auxPar.Value = oCQ_VEDM.ISUCU;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TIPO_VEDE", OleDbType.VarChar);
                if (!(bool)oCQ_VEDM.isnull["ITIPO_VEDE"])
                {
                    auxPar.Value = oCQ_VEDM.ITIPO_VEDE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IEPS53", OleDbType.Double);
                if (!(bool)oCQ_VEDM.isnull["IIEPS53"])
                {
                    auxPar.Value = oCQ_VEDM.IIEPS53;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IEPS26", OleDbType.Double);
                if (!(bool)oCQ_VEDM.isnull["IIEPS26"])
                {
                    auxPar.Value = oCQ_VEDM.IIEPS26;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@UTL_VENT", OleDbType.Double);
                if (!(bool)oCQ_VEDM.isnull["IUTL_VENT"])
                {
                    auxPar.Value = oCQ_VEDM.IUTL_VENT;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IEPS8", OleDbType.Double);
                if (!(bool)oCQ_VEDM.isnull["IIEPS8"])
                {
                    auxPar.Value = oCQ_VEDM.IIEPS8;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTO_REPO", OleDbType.Double);
                if (!(bool)oCQ_VEDM.isnull["ICOSTO_REPO"])
                {
                    auxPar.Value = oCQ_VEDM.ICOSTO_REPO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO " + strFileName + @"
      (
    
VENTA,

CLIENTE,

CANTIDAD,

PRODUCTO,

PROVEEDOR,

LINEA,

MARCA,

VENDEDOR,

TIPO,

CLASIFICA,

PRECIO,

PREC_LISTA,

FECHA,

ESTATUS,

IMPORTE,

IMPORTNETO,

IMPORTOPE,

TOTAL,

UTILIDAD,

COSTO_PU,

TIENDA,

COSTOTAL,

DESCUENTO,

COMISION,

ID,

ID_FECHA,

ID_HORA,

IVA,

IEPS19,

IEPS20,

IEPS25,

IEPS30,

IEPS50,

IEPS60,

EXPORTADOC,

CGO_EXC,

OLLA,

DESCTOPE,

PROMOCION,

SUCU,

TIPO_VEDE,

IEPS53,

IEPS26,

UTL_VENT,

IEPS8,

COSTO_REPO
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

        



        public CQ_VEDMD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
