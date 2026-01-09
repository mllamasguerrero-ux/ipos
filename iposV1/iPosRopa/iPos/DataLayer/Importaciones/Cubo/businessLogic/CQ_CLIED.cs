
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



    public class CQ_CLIED
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


        public bool AgregarQ_CLIED(CQ_CLIEBE oCQ_CLIE, string strFileName, OleDbTransaction st, string strOleDbConn)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@CLIENTE", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["ICLIENTE"])
                {
                    auxPar.Value = oCQ_CLIE.ICLIENTE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["INOMBRE"])
                {
                    auxPar.Value = oCQ_CLIE.INOMBRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SALDO", OleDbType.Double);
                if (!(bool)oCQ_CLIE.isnull["ISALDO"])
                {
                    auxPar.Value = oCQ_CLIE.ISALDO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SALDO_VENC", OleDbType.Double);
                if (!(bool)oCQ_CLIE.isnull["ISALDO_VENC"])
                {
                    auxPar.Value = oCQ_CLIE.ISALDO_VENC;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LIMITE", OleDbType.Double);
                if (!(bool)oCQ_CLIE.isnull["ILIMITE"])
                {
                    auxPar.Value = oCQ_CLIE.ILIMITE;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NUMERO", OleDbType.Double);
                if (!(bool)oCQ_CLIE.isnull["INUMERO"])
                {
                    auxPar.Value = oCQ_CLIE.INUMERO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SALDO_US", OleDbType.Double);
                if (!(bool)oCQ_CLIE.isnull["ISALDO_US"])
                {
                    auxPar.Value = oCQ_CLIE.ISALDO_US;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ALTA", OleDbType.Date);
                if (!(bool)oCQ_CLIE.isnull["IALTA"])
                {
                    auxPar.Value = oCQ_CLIE.IALTA;
                }
                else
                {
                    auxPar.Value = DateTime.Today;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ULT_COMPRA", OleDbType.Date);
                if (!(bool)oCQ_CLIE.isnull["IULT_COMPRA"])
                {
                    auxPar.Value = oCQ_CLIE.IULT_COMPRA;
                }
                else
                {
                    auxPar.Value = DateTime.Today;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@UC_CANT", OleDbType.Double);
                if (!(bool)oCQ_CLIE.isnull["IUC_CANT"])
                {
                    auxPar.Value = oCQ_CLIE.IUC_CANT;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOMBRE2", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["INOMBRE2"])
                {
                    auxPar.Value = oCQ_CLIE.INOMBRE2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FACT_PERIO", OleDbType.Double);
                if (!(bool)oCQ_CLIE.isnull["IFACT_PERIO"])
                {
                    auxPar.Value = oCQ_CLIE.IFACT_PERIO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COMPRAS_P", OleDbType.Double);
                if (!(bool)oCQ_CLIE.isnull["ICOMPRAS_P"])
                {
                    auxPar.Value = oCQ_CLIE.ICOMPRAS_P;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FACT_ACUM", OleDbType.Double);
                if (!(bool)oCQ_CLIE.isnull["IFACT_ACUM"])
                {
                    auxPar.Value = oCQ_CLIE.IFACT_ACUM;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COMPRAS_A", OleDbType.Double);
                if (!(bool)oCQ_CLIE.isnull["ICOMPRAS_A"])
                {
                    auxPar.Value = oCQ_CLIE.ICOMPRAS_A;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CHQ_DEVUEL", OleDbType.Double);
                if (!(bool)oCQ_CLIE.isnull["ICHQ_DEVUEL"])
                {
                    auxPar.Value = oCQ_CLIE.ICHQ_DEVUEL;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@F_VENCIDAS", OleDbType.Double);
                if (!(bool)oCQ_CLIE.isnull["IF_VENCIDAS"])
                {
                    auxPar.Value = oCQ_CLIE.IF_VENCIDAS;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CALLE", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["ICALLE"])
                {
                    auxPar.Value = oCQ_CLIE.ICALLE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COLONIA", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["ICOLONIA"])
                {
                    auxPar.Value = oCQ_CLIE.ICOLONIA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESTADO", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["IESTADO"])
                {
                    auxPar.Value = oCQ_CLIE.IESTADO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CIUDAD", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["ICIUDAD"])
                {
                    auxPar.Value = oCQ_CLIE.ICIUDAD;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CP", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["ICP"])
                {
                    auxPar.Value = oCQ_CLIE.ICP;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@RFC", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["IRFC"])
                {
                    auxPar.Value = oCQ_CLIE.IRFC;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TELEFONO", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["ITELEFONO"])
                {
                    auxPar.Value = oCQ_CLIE.ITELEFONO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TELEFONO2", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["ITELEFONO2"])
                {
                    auxPar.Value = oCQ_CLIE.ITELEFONO2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CONTACTO", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["ICONTACTO"])
                {
                    auxPar.Value = oCQ_CLIE.ICONTACTO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CONTACTO2", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["ICONTACTO2"])
                {
                    auxPar.Value = oCQ_CLIE.ICONTACTO2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@VENDEDOR", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["IVENDEDOR"])
                {
                    auxPar.Value = oCQ_CLIE.IVENDEDOR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TIPO", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["ITIPO"])
                {
                    auxPar.Value = oCQ_CLIE.ITIPO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COMODIN", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["ICOMODIN"])
                {
                    auxPar.Value = oCQ_CLIE.ICOMODIN;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DIAS", OleDbType.Double);
                if (!(bool)oCQ_CLIE.isnull["IDIAS"])
                {
                    auxPar.Value = oCQ_CLIE.IDIAS;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DIASA", OleDbType.Double);
                if (!(bool)oCQ_CLIE.isnull["IDIASA"])
                {
                    auxPar.Value = oCQ_CLIE.IDIASA;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DIASB", OleDbType.Double);
                if (!(bool)oCQ_CLIE.isnull["IDIASB"])
                {
                    auxPar.Value = oCQ_CLIE.IDIASB;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@REVISION", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["IREVISION"])
                {
                    auxPar.Value = oCQ_CLIE.IREVISION;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PAGOS", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["IPAGOS"])
                {
                    auxPar.Value = oCQ_CLIE.IPAGOS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CLASIFICA", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["ICLASIFICA"])
                {
                    auxPar.Value = oCQ_CLIE.ICLASIFICA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESCUENTO", OleDbType.Double);
                if (!(bool)oCQ_CLIE.isnull["IDESCUENTO"])
                {
                    auxPar.Value = oCQ_CLIE.IDESCUENTO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@BLOQUEADO", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["IBLOQUEADO"])
                {
                    auxPar.Value = oCQ_CLIE.IBLOQUEADO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@BLOQUEONOT", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["IBLOQUEONOT"])
                {
                    auxPar.Value = oCQ_CLIE.IBLOQUEONOT;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@EFECTIVO", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["IEFECTIVO"])
                {
                    auxPar.Value = oCQ_CLIE.IEFECTIVO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CORREO", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["ICORREO"])
                {
                    auxPar.Value = oCQ_CLIE.ICORREO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ULT_LLAMAD", OleDbType.Date);
                if (!(bool)oCQ_CLIE.isnull["IULT_LLAMAD"])
                {
                    auxPar.Value = oCQ_CLIE.IULT_LLAMAD;
                }
                else
                {
                    auxPar.Value = DateTime.Today;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PROX_LLAMA", OleDbType.Date);
                if (!(bool)oCQ_CLIE.isnull["IPROX_LLAMA"])
                {
                    auxPar.Value = oCQ_CLIE.IPROX_LLAMA;
                }
                else
                {
                    auxPar.Value = DateTime.Today;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["IID"])
                {
                    auxPar.Value = oCQ_CLIE.IID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCQ_CLIE.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCQ_CLIE.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.Today;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["IID_HORA"])
                {
                    auxPar.Value = oCQ_CLIE.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CALLE1", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["ICALLE1"])
                {
                    auxPar.Value = oCQ_CLIE.ICALLE1;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CRUZACON", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["ICRUZACON"])
                {
                    auxPar.Value = oCQ_CLIE.ICRUZACON;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESGIEPS", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["IDESGIEPS"])
                {
                    auxPar.Value = oCQ_CLIE.IDESGIEPS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ENDOLARES", OleDbType.Double);
                if (!(bool)oCQ_CLIE.isnull["IENDOLARES"])
                {
                    auxPar.Value = oCQ_CLIE.IENDOLARES;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PLANO", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["IPLANO"])
                {
                    auxPar.Value = oCQ_CLIE.IPLANO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@EMAIL", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["IEMAIL"])
                {
                    auxPar.Value = oCQ_CLIE.IEMAIL;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@HOMEPAGE", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["IHOMEPAGE"])
                {
                    auxPar.Value = oCQ_CLIE.IHOMEPAGE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@BWCOLOR", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["IBWCOLOR"])
                {
                    auxPar.Value = oCQ_CLIE.IBWCOLOR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MULVEN", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["IMULVEN"])
                {
                    auxPar.Value = oCQ_CLIE.IMULVEN;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CTA_IEPS", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["ICTA_IEPS"])
                {
                    auxPar.Value = oCQ_CLIE.ICTA_IEPS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@P_MOVIL", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["IP_MOVIL"])
                {
                    auxPar.Value = oCQ_CLIE.IP_MOVIL;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ACUMULA", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["IACUMULA"])
                {
                    auxPar.Value = oCQ_CLIE.IACUMULA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SALDO_GLOB", OleDbType.Double);
                if (!(bool)oCQ_CLIE.isnull["ISALDO_GLOB"])
                {
                    auxPar.Value = oCQ_CLIE.ISALDO_GLOB;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@USERNAME", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["IUSERNAME"])
                {
                    auxPar.Value = oCQ_CLIE.IUSERNAME;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PASSWORD", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["IPASSWORD"])
                {
                    auxPar.Value = oCQ_CLIE.IPASSWORD;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_ALTA", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["IID_ALTA"])
                {
                    auxPar.Value = oCQ_CLIE.IID_ALTA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CLAVE_EDO", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["ICLAVE_EDO"])
                {
                    auxPar.Value = oCQ_CLIE.ICLAVE_EDO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COB_INTERE", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["ICOB_INTERE"])
                {
                    auxPar.Value = oCQ_CLIE.ICOB_INTERE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PLAZA", OleDbType.Double);
                if (!(bool)oCQ_CLIE.isnull["IPLAZA"])
                {
                    auxPar.Value = oCQ_CLIE.IPLAZA;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COM_ESP", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["ICOM_ESP"])
                {
                    auxPar.Value = oCQ_CLIE.ICOM_ESP;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@POR_COME", OleDbType.Double);
                if (!(bool)oCQ_CLIE.isnull["IPOR_COME"])
                {
                    auxPar.Value = oCQ_CLIE.IPOR_COME;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@L_BLOQUEO", OleDbType.Boolean);
                if (!(bool)oCQ_CLIE.isnull["IL_BLOQUEO"])
                {
                    auxPar.Value = oCQ_CLIE.IL_BLOQUEO;
                }
                else
                {
                    auxPar.Value = false;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@RUTA", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["IRUTA"])
                {
                    auxPar.Value = oCQ_CLIE.IRUTA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@L_DESC", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["IL_DESC"])
                {
                    auxPar.Value = oCQ_CLIE.IL_DESC;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@POCKET", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["IPOCKET"])
                {
                    auxPar.Value = oCQ_CLIE.IPOCKET;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CLIEPOCK", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["ICLIEPOCK"])
                {
                    auxPar.Value = oCQ_CLIE.ICLIEPOCK;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESCI", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["IDESCI"])
                {
                    auxPar.Value = oCQ_CLIE.IDESCI;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@BLOQ2", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["IBLOQ2"])
                {
                    auxPar.Value = oCQ_CLIE.IBLOQ2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DIASP", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["IDIASP"])
                {
                    auxPar.Value = oCQ_CLIE.IDIASP;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DIASEXTR", OleDbType.Double);
                if (!(bool)oCQ_CLIE.isnull["IDIASEXTR"])
                {
                    auxPar.Value = oCQ_CLIE.IDIASEXTR;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COBVENCIDA", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["ICOBVENCIDA"])
                {
                    auxPar.Value = oCQ_CLIE.ICOBVENCIDA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@VENDEDOR2", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["IVENDEDOR2"])
                {
                    auxPar.Value = oCQ_CLIE.IVENDEDOR2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CURP", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["ICURP"])
                {
                    auxPar.Value = oCQ_CLIE.ICURP;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SUCU", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["ISUCU"])
                {
                    auxPar.Value = oCQ_CLIE.ISUCU;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESTRATEGIC", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["IESTRATEGIC"])
                {
                    auxPar.Value = oCQ_CLIE.IESTRATEGIC;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@AUTORIZA", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["IAUTORIZA"])
                {
                    auxPar.Value = oCQ_CLIE.IAUTORIZA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PPRODUCTO", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["IPPRODUCTO"])
                {
                    auxPar.Value = oCQ_CLIE.IPPRODUCTO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PVENDEDOR", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["IPVENDEDOR"])
                {
                    auxPar.Value = oCQ_CLIE.IPVENDEDOR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PLINEA", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["IPLINEA"])
                {
                    auxPar.Value = oCQ_CLIE.IPLINEA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PMARCA", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["IPMARCA"])
                {
                    auxPar.Value = oCQ_CLIE.IPMARCA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PPROVEEDOR", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["IPPROVEEDOR"])
                {
                    auxPar.Value = oCQ_CLIE.IPPROVEEDOR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PCIUDAD", OleDbType.VarChar);
                if (!(bool)oCQ_CLIE.isnull["IPCIUDAD"])
                {
                    auxPar.Value = oCQ_CLIE.IPCIUDAD;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO " + strFileName + @"
      (
    
CLIENTE,

NOMBRE,

SALDO,

SALDO_VENC,

LIMITE,

NUMERO,

SALDO_US,

ALTA,

ULT_COMPRA,

UC_CANT,

NOMBRE2,

FACT_PERIO,

COMPRAS_P,

FACT_ACUM,

COMPRAS_A,

CHQ_DEVUEL,

F_VENCIDAS,

CALLE,

COLONIA,

ESTADO,

CIUDAD,

CP,

RFC,

TELEFONO,

TELEFONO2,

CONTACTO,

CONTACTO2,

VENDEDOR,

TIPO,

COMODIN,

DIAS,

DIASA,

DIASB,

REVISION,

PAGOS,

CLASIFICA,

DESCUENTO,

BLOQUEADO,

BLOQUEONOT,

EFECTIVO,

CORREO,

ULT_LLAMAD,

PROX_LLAMA,

ID,

ID_FECHA,

ID_HORA,

CALLE1,

CRUZACON,

DESGIEPS,

ENDOLARES,

PLANO,

EMAIL,

HOMEPAGE,

BWCOLOR,

MULVEN,

CTA_IEPS,

P_MOVIL,

ACUMULA,

SALDO_GLOB,

USERNAME,

PASSWORD,

ID_ALTA,

CLAVE_EDO,

COB_INTERE,

PLAZA,

COM_ESP,

POR_COME,

L_BLOQUEO,

RUTA,

L_DESC,

POCKET,

CLIEPOCK,

DESCI,

BLOQ2,

DIASP,

DIASEXTR,

COBVENCIDA,

VENDEDOR2,

CURP,

SUCU,

ESTRATEGIC,

AUTORIZA,

PPRODUCTO,

PVENDEDOR,

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

        


        public CQ_CLIED()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
