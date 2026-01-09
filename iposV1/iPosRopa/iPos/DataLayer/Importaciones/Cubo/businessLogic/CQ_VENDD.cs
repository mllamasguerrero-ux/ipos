
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



    public class CQ_VENDD
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


        public bool AgregarQ_VENDD(CQ_VENDBE oCQ_VEND, string strFileName, OleDbTransaction st, string strOleDbConn)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@VENDEDOR", OleDbType.VarChar);
                if (!(bool)oCQ_VEND.isnull["IVENDEDOR"])
                {
                    auxPar.Value = oCQ_VEND.IVENDEDOR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                if (!(bool)oCQ_VEND.isnull["INOMBRE"])
                {
                    auxPar.Value = oCQ_VEND.INOMBRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CALLE", OleDbType.VarChar);
                if (!(bool)oCQ_VEND.isnull["ICALLE"])
                {
                    auxPar.Value = oCQ_VEND.ICALLE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COLONIA", OleDbType.VarChar);
                if (!(bool)oCQ_VEND.isnull["ICOLONIA"])
                {
                    auxPar.Value = oCQ_VEND.ICOLONIA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CIUDAD", OleDbType.VarChar);
                if (!(bool)oCQ_VEND.isnull["ICIUDAD"])
                {
                    auxPar.Value = oCQ_VEND.ICIUDAD;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESTADO", OleDbType.VarChar);
                if (!(bool)oCQ_VEND.isnull["IESTADO"])
                {
                    auxPar.Value = oCQ_VEND.IESTADO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TELEFONO", OleDbType.VarChar);
                if (!(bool)oCQ_VEND.isnull["ITELEFONO"])
                {
                    auxPar.Value = oCQ_VEND.ITELEFONO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PUESTO", OleDbType.VarChar);
                if (!(bool)oCQ_VEND.isnull["IPUESTO"])
                {
                    auxPar.Value = oCQ_VEND.IPUESTO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CP", OleDbType.VarChar);
                if (!(bool)oCQ_VEND.isnull["ICP"])
                {
                    auxPar.Value = oCQ_VEND.ICP;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@INGRESO", OleDbType.Date);
                if (!(bool)oCQ_VEND.isnull["IINGRESO"])
                {
                    auxPar.Value = oCQ_VEND.IINGRESO;
                }
                else
                {
                    auxPar.Value = DateTime.Today;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@RFC", OleDbType.VarChar);
                if (!(bool)oCQ_VEND.isnull["IRFC"])
                {
                    auxPar.Value = oCQ_VEND.IRFC;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COMI1", OleDbType.Double);
                if (!(bool)oCQ_VEND.isnull["ICOMI1"])
                {
                    auxPar.Value = oCQ_VEND.ICOMI1;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COMI2", OleDbType.Double);
                if (!(bool)oCQ_VEND.isnull["ICOMI2"])
                {
                    auxPar.Value = oCQ_VEND.ICOMI2;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COMI3", OleDbType.Double);
                if (!(bool)oCQ_VEND.isnull["ICOMI3"])
                {
                    auxPar.Value = oCQ_VEND.ICOMI3;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LIMITE1", OleDbType.Double);
                if (!(bool)oCQ_VEND.isnull["ILIMITE1"])
                {
                    auxPar.Value = oCQ_VEND.ILIMITE1;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LIMITE2", OleDbType.Double);
                if (!(bool)oCQ_VEND.isnull["ILIMITE2"])
                {
                    auxPar.Value = oCQ_VEND.ILIMITE2;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TIPO", OleDbType.VarChar);
                if (!(bool)oCQ_VEND.isnull["ITIPO"])
                {
                    auxPar.Value = oCQ_VEND.ITIPO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COMODIN", OleDbType.VarChar);
                if (!(bool)oCQ_VEND.isnull["ICOMODIN"])
                {
                    auxPar.Value = oCQ_VEND.ICOMODIN;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NO_FACTURA", OleDbType.Double);
                if (!(bool)oCQ_VEND.isnull["INO_FACTURA"])
                {
                    auxPar.Value = oCQ_VEND.INO_FACTURA;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CLIENTES", OleDbType.Double);
                if (!(bool)oCQ_VEND.isnull["ICLIENTES"])
                {
                    auxPar.Value = oCQ_VEND.ICLIENTES;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOATENDIDO", OleDbType.Double);
                if (!(bool)oCQ_VEND.isnull["INOATENDIDO"])
                {
                    auxPar.Value = oCQ_VEND.INOATENDIDO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@VENTAS", OleDbType.Double);
                if (!(bool)oCQ_VEND.isnull["IVENTAS"])
                {
                    auxPar.Value = oCQ_VEND.IVENTAS;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CUOTA_ENE", OleDbType.Double);
                if (!(bool)oCQ_VEND.isnull["ICUOTA_ENE"])
                {
                    auxPar.Value = oCQ_VEND.ICUOTA_ENE;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CUOTA_FEB", OleDbType.Double);
                if (!(bool)oCQ_VEND.isnull["ICUOTA_FEB"])
                {
                    auxPar.Value = oCQ_VEND.ICUOTA_FEB;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CUOTA_MAR", OleDbType.Double);
                if (!(bool)oCQ_VEND.isnull["ICUOTA_MAR"])
                {
                    auxPar.Value = oCQ_VEND.ICUOTA_MAR;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CUOTA_ABR", OleDbType.Double);
                if (!(bool)oCQ_VEND.isnull["ICUOTA_ABR"])
                {
                    auxPar.Value = oCQ_VEND.ICUOTA_ABR;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CUOTA_MAY", OleDbType.Double);
                if (!(bool)oCQ_VEND.isnull["ICUOTA_MAY"])
                {
                    auxPar.Value = oCQ_VEND.ICUOTA_MAY;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CUOTA_JUN", OleDbType.Double);
                if (!(bool)oCQ_VEND.isnull["ICUOTA_JUN"])
                {
                    auxPar.Value = oCQ_VEND.ICUOTA_JUN;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CUOTA_JUL", OleDbType.Double);
                if (!(bool)oCQ_VEND.isnull["ICUOTA_JUL"])
                {
                    auxPar.Value = oCQ_VEND.ICUOTA_JUL;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CUOTA_AGO", OleDbType.Double);
                if (!(bool)oCQ_VEND.isnull["ICUOTA_AGO"])
                {
                    auxPar.Value = oCQ_VEND.ICUOTA_AGO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CUOTA_SEP", OleDbType.Double);
                if (!(bool)oCQ_VEND.isnull["ICUOTA_SEP"])
                {
                    auxPar.Value = oCQ_VEND.ICUOTA_SEP;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CUOTA_OCT", OleDbType.Double);
                if (!(bool)oCQ_VEND.isnull["ICUOTA_OCT"])
                {
                    auxPar.Value = oCQ_VEND.ICUOTA_OCT;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CUOTA_NOV", OleDbType.Double);
                if (!(bool)oCQ_VEND.isnull["ICUOTA_NOV"])
                {
                    auxPar.Value = oCQ_VEND.ICUOTA_NOV;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CUOTA_DIC", OleDbType.Double);
                if (!(bool)oCQ_VEND.isnull["ICUOTA_DIC"])
                {
                    auxPar.Value = oCQ_VEND.ICUOTA_DIC;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ACUM_ENE", OleDbType.Double);
                if (!(bool)oCQ_VEND.isnull["IACUM_ENE"])
                {
                    auxPar.Value = oCQ_VEND.IACUM_ENE;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ACUM_FEB", OleDbType.Double);
                if (!(bool)oCQ_VEND.isnull["IACUM_FEB"])
                {
                    auxPar.Value = oCQ_VEND.IACUM_FEB;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ACUM_MAR", OleDbType.Double);
                if (!(bool)oCQ_VEND.isnull["IACUM_MAR"])
                {
                    auxPar.Value = oCQ_VEND.IACUM_MAR;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ACUM_ABR", OleDbType.Double);
                if (!(bool)oCQ_VEND.isnull["IACUM_ABR"])
                {
                    auxPar.Value = oCQ_VEND.IACUM_ABR;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ACUM_MAY", OleDbType.Double);
                if (!(bool)oCQ_VEND.isnull["IACUM_MAY"])
                {
                    auxPar.Value = oCQ_VEND.IACUM_MAY;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ACUM_JUN", OleDbType.Double);
                if (!(bool)oCQ_VEND.isnull["IACUM_JUN"])
                {
                    auxPar.Value = oCQ_VEND.IACUM_JUN;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ACUM_JUL", OleDbType.Double);
                if (!(bool)oCQ_VEND.isnull["IACUM_JUL"])
                {
                    auxPar.Value = oCQ_VEND.IACUM_JUL;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ACUM_AGO", OleDbType.Double);
                if (!(bool)oCQ_VEND.isnull["IACUM_AGO"])
                {
                    auxPar.Value = oCQ_VEND.IACUM_AGO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ACUM_SEP", OleDbType.Double);
                if (!(bool)oCQ_VEND.isnull["IACUM_SEP"])
                {
                    auxPar.Value = oCQ_VEND.IACUM_SEP;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ACUM_OCT", OleDbType.Double);
                if (!(bool)oCQ_VEND.isnull["IACUM_OCT"])
                {
                    auxPar.Value = oCQ_VEND.IACUM_OCT;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ACUM_NOV", OleDbType.Double);
                if (!(bool)oCQ_VEND.isnull["IACUM_NOV"])
                {
                    auxPar.Value = oCQ_VEND.IACUM_NOV;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ACUM_DIC", OleDbType.Double);
                if (!(bool)oCQ_VEND.isnull["IACUM_DIC"])
                {
                    auxPar.Value = oCQ_VEND.IACUM_DIC;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@VTAS_TOT", OleDbType.Double);
                if (!(bool)oCQ_VEND.isnull["IVTAS_TOT"])
                {
                    auxPar.Value = oCQ_VEND.IVTAS_TOT;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESTATUS", OleDbType.VarChar);
                if (!(bool)oCQ_VEND.isnull["IESTATUS"])
                {
                    auxPar.Value = oCQ_VEND.IESTATUS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCQ_VEND.isnull["IID"])
                {
                    auxPar.Value = oCQ_VEND.IID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@VENT_PERI", OleDbType.Double);
                if (!(bool)oCQ_VEND.isnull["IVENT_PERI"])
                {
                    auxPar.Value = oCQ_VEND.IVENT_PERI;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCQ_VEND.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCQ_VEND.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.Today;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCQ_VEND.isnull["IID_HORA"])
                {
                    auxPar.Value = oCQ_VEND.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@USUARIO", OleDbType.VarChar);
                if (!(bool)oCQ_VEND.isnull["IUSUARIO"])
                {
                    auxPar.Value = oCQ_VEND.IUSUARIO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PASSWORD", OleDbType.VarChar);
                if (!(bool)oCQ_VEND.isnull["IPASSWORD"])
                {
                    auxPar.Value = oCQ_VEND.IPASSWORD;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SUCURSAL", OleDbType.Double);
                if (!(bool)oCQ_VEND.isnull["ISUCURSAL"])
                {
                    auxPar.Value = oCQ_VEND.ISUCURSAL;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SOLIDARIO", OleDbType.VarChar);
                if (!(bool)oCQ_VEND.isnull["ISOLIDARIO"])
                {
                    auxPar.Value = oCQ_VEND.ISOLIDARIO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@POCKET", OleDbType.VarChar);
                if (!(bool)oCQ_VEND.isnull["IPOCKET"])
                {
                    auxPar.Value = oCQ_VEND.IPOCKET;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CLIENTE", OleDbType.VarChar);
                if (!(bool)oCQ_VEND.isnull["ICLIENTE"])
                {
                    auxPar.Value = oCQ_VEND.ICLIENTE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SUCU", OleDbType.VarChar);
                if (!(bool)oCQ_VEND.isnull["ISUCU"])
                {
                    auxPar.Value = oCQ_VEND.ISUCU;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@VEND_TIEN", OleDbType.VarChar);
                if (!(bool)oCQ_VEND.isnull["IVEND_TIEN"])
                {
                    auxPar.Value = oCQ_VEND.IVEND_TIEN;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESTRATEGIC", OleDbType.VarChar);
                if (!(bool)oCQ_VEND.isnull["IESTRATEGIC"])
                {
                    auxPar.Value = oCQ_VEND.IESTRATEGIC;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PCLIENTE", OleDbType.VarChar);
                if (!(bool)oCQ_VEND.isnull["IPCLIENTE"])
                {
                    auxPar.Value = oCQ_VEND.IPCLIENTE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PPRODUCTO", OleDbType.VarChar);
                if (!(bool)oCQ_VEND.isnull["IPPRODUCTO"])
                {
                    auxPar.Value = oCQ_VEND.IPPRODUCTO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PLINEA", OleDbType.VarChar);
                if (!(bool)oCQ_VEND.isnull["IPLINEA"])
                {
                    auxPar.Value = oCQ_VEND.IPLINEA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PMARCA", OleDbType.VarChar);
                if (!(bool)oCQ_VEND.isnull["IPMARCA"])
                {
                    auxPar.Value = oCQ_VEND.IPMARCA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PPROVEEDOR", OleDbType.VarChar);
                if (!(bool)oCQ_VEND.isnull["IPPROVEEDOR"])
                {
                    auxPar.Value = oCQ_VEND.IPPROVEEDOR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PCIUDAD", OleDbType.VarChar);
                if (!(bool)oCQ_VEND.isnull["IPCIUDAD"])
                {
                    auxPar.Value = oCQ_VEND.IPCIUDAD;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO " + strFileName + @"
      (
    
VENDEDOR,

NOMBRE,

CALLE,

COLONIA,

CIUDAD,

ESTADO,

TELEFONO,

PUESTO,

CP,

INGRESO,

RFC,

COMI1,

COMI2,

COMI3,

LIMITE1,

LIMITE2,

TIPO,

COMODIN,

NO_FACTURA,

CLIENTES,

NOATENDIDO,

VENTAS,

CUOTA_ENE,

CUOTA_FEB,

CUOTA_MAR,

CUOTA_ABR,

CUOTA_MAY,

CUOTA_JUN,

CUOTA_JUL,

CUOTA_AGO,

CUOTA_SEP,

CUOTA_OCT,

CUOTA_NOV,

CUOTA_DIC,

ACUM_ENE,

ACUM_FEB,

ACUM_MAR,

ACUM_ABR,

ACUM_MAY,

ACUM_JUN,

ACUM_JUL,

ACUM_AGO,

ACUM_SEP,

ACUM_OCT,

ACUM_NOV,

ACUM_DIC,

VTAS_TOT,

ESTATUS,

ID,

VENT_PERI,

ID_FECHA,

ID_HORA,

USUARIO,

PASSWORD,

SUCURSAL,

SOLIDARIO,

POCKET,

CLIENTE,

SUCU,

VEND_TIEN,

ESTRATEGIC,

PCLIENTE,

PPRODUCTO,

PLINEA,

PMARCA,

PPROVEEDOR,

PCIUDAD
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

        

        public CQ_VENDD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
