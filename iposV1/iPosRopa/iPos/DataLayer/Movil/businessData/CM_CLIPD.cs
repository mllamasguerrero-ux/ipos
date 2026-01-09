


using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using System.Data;
using System.Collections;
using ConexionesBD;
using System.Data.OleDb;
using DataLayer;

namespace iPosData
{



    public class CM_CLIPD:IMCLIPD
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



        public bool AgregarM_CLIPD(CM_CLIPBE oCM_CLIP, string strFileName, 
                                    //OleDbTransaction st, 
                                    string strOleDbConn)
        {


            try
            {





                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@CLIENTE", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["ICLIENTE"])
                {
                    auxPar.Value = oCM_CLIP.ICLIENTE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["INOMBRE"])
                {
                    auxPar.Value = oCM_CLIP.INOMBRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SALDO", OleDbType.Double);
                if (!(bool)oCM_CLIP.isnull["ISALDO"])
                {
                    auxPar.Value = oCM_CLIP.ISALDO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SALDO_VENC", OleDbType.Double);
                if (!(bool)oCM_CLIP.isnull["ISALDO_VENC"])
                {
                    auxPar.Value = oCM_CLIP.ISALDO_VENC;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LIMITE", OleDbType.Double);
                if (!(bool)oCM_CLIP.isnull["ILIMITE"])
                {
                    auxPar.Value = oCM_CLIP.ILIMITE;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NUMERO", OleDbType.Double);
                if (!(bool)oCM_CLIP.isnull["INUMERO"])
                {
                    auxPar.Value = oCM_CLIP.INUMERO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SALDO_US", OleDbType.Double);
                if (!(bool)oCM_CLIP.isnull["ISALDO_US"])
                {
                    auxPar.Value = oCM_CLIP.ISALDO_US;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ALTA", OleDbType.Date);
                if (!(bool)oCM_CLIP.isnull["IALTA"])
                {
                    auxPar.Value = oCM_CLIP.IALTA;
                }
                else
                {
                    auxPar.Value = DateTime.Today;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ULT_COMPRA", OleDbType.Date);
                if (!(bool)oCM_CLIP.isnull["IULT_COMPRA"])
                {
                    auxPar.Value = oCM_CLIP.IULT_COMPRA;
                }
                else
                {
                    auxPar.Value = DateTime.Today;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@UC_CANT", OleDbType.Double);
                if (!(bool)oCM_CLIP.isnull["IUC_CANT"])
                {
                    auxPar.Value = oCM_CLIP.IUC_CANT;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOMBRE2", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["INOMBRE2"])
                {
                    auxPar.Value = oCM_CLIP.INOMBRE2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FACT_PERIO", OleDbType.Double);
                if (!(bool)oCM_CLIP.isnull["IFACT_PERIO"])
                {
                    auxPar.Value = oCM_CLIP.IFACT_PERIO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COMPRAS_P", OleDbType.Double);
                if (!(bool)oCM_CLIP.isnull["ICOMPRAS_P"])
                {
                    auxPar.Value = oCM_CLIP.ICOMPRAS_P;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FACT_ACUM", OleDbType.Double);
                if (!(bool)oCM_CLIP.isnull["IFACT_ACUM"])
                {
                    auxPar.Value = oCM_CLIP.IFACT_ACUM;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COMPRAS_A", OleDbType.Double);
                if (!(bool)oCM_CLIP.isnull["ICOMPRAS_A"])
                {
                    auxPar.Value = oCM_CLIP.ICOMPRAS_A;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CHQ_DEVUEL", OleDbType.Double);
                if (!(bool)oCM_CLIP.isnull["ICHQ_DEVUEL"])
                {
                    auxPar.Value = oCM_CLIP.ICHQ_DEVUEL;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@F_VENCIDAS", OleDbType.Double);
                if (!(bool)oCM_CLIP.isnull["IF_VENCIDAS"])
                {
                    auxPar.Value = oCM_CLIP.IF_VENCIDAS;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CALLE", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["ICALLE"])
                {
                    auxPar.Value = oCM_CLIP.ICALLE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COLONIA", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["ICOLONIA"])
                {
                    auxPar.Value = oCM_CLIP.ICOLONIA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESTADO", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IESTADO"])
                {
                    auxPar.Value = oCM_CLIP.IESTADO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CIUDAD", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["ICIUDAD"])
                {
                    auxPar.Value = oCM_CLIP.ICIUDAD;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CP", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["ICP"])
                {
                    auxPar.Value = oCM_CLIP.ICP;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@RFC", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IRFC"])
                {
                    auxPar.Value = oCM_CLIP.IRFC;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TELEFONO", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["ITELEFONO"])
                {
                    auxPar.Value = oCM_CLIP.ITELEFONO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TELEFONO2", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["ITELEFONO2"])
                {
                    auxPar.Value = oCM_CLIP.ITELEFONO2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CONTACTO", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["ICONTACTO"])
                {
                    auxPar.Value = oCM_CLIP.ICONTACTO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CONTACTO2", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["ICONTACTO2"])
                {
                    auxPar.Value = oCM_CLIP.ICONTACTO2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@VENDEDOR", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IVENDEDOR"])
                {
                    auxPar.Value = oCM_CLIP.IVENDEDOR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TIPO", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["ITIPO"])
                {
                    auxPar.Value = oCM_CLIP.ITIPO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COMODIN", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["ICOMODIN"])
                {
                    auxPar.Value = oCM_CLIP.ICOMODIN;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DIAS", OleDbType.Double);
                if (!(bool)oCM_CLIP.isnull["IDIAS"])
                {
                    auxPar.Value = oCM_CLIP.IDIAS;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DIASA", OleDbType.Double);
                if (!(bool)oCM_CLIP.isnull["IDIASA"])
                {
                    auxPar.Value = oCM_CLIP.IDIASA;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DIASB", OleDbType.Double);
                if (!(bool)oCM_CLIP.isnull["IDIASB"])
                {
                    auxPar.Value = oCM_CLIP.IDIASB;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@REVISION", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IREVISION"])
                {
                    auxPar.Value = oCM_CLIP.IREVISION;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PAGOS", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IPAGOS"])
                {
                    auxPar.Value = oCM_CLIP.IPAGOS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CLASIFICA", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["ICLASIFICA"])
                {
                    auxPar.Value = oCM_CLIP.ICLASIFICA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESCUENTO", OleDbType.Double);
                if (!(bool)oCM_CLIP.isnull["IDESCUENTO"])
                {
                    auxPar.Value = oCM_CLIP.IDESCUENTO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@BLOQUEADO", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IBLOQUEADO"])
                {
                    auxPar.Value = oCM_CLIP.IBLOQUEADO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@BLOQUEONOT", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IBLOQUEONOT"])
                {
                    auxPar.Value = oCM_CLIP.IBLOQUEONOT;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@EFECTIVO", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IEFECTIVO"])
                {
                    auxPar.Value = oCM_CLIP.IEFECTIVO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CORREO", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["ICORREO"])
                {
                    auxPar.Value = oCM_CLIP.ICORREO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ULT_LLAMAD", OleDbType.Date);
                if (!(bool)oCM_CLIP.isnull["IULT_LLAMAD"])
                {
                    auxPar.Value = oCM_CLIP.IULT_LLAMAD;
                }
                else
                {
                    auxPar.Value = DateTime.Today;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PROX_LLAMA", OleDbType.Date);
                if (!(bool)oCM_CLIP.isnull["IPROX_LLAMA"])
                {
                    auxPar.Value = oCM_CLIP.IPROX_LLAMA;
                }
                else
                {
                    auxPar.Value = DateTime.Today;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IID"])
                {
                    auxPar.Value = oCM_CLIP.IID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCM_CLIP.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_CLIP.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.Today;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_CLIP.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CALLE1", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["ICALLE1"])
                {
                    auxPar.Value = oCM_CLIP.ICALLE1;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CRUZACON", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["ICRUZACON"])
                {
                    auxPar.Value = oCM_CLIP.ICRUZACON;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESGIEPS", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IDESGIEPS"])
                {
                    auxPar.Value = oCM_CLIP.IDESGIEPS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ENDOLARES", OleDbType.Double);
                if (!(bool)oCM_CLIP.isnull["IENDOLARES"])
                {
                    auxPar.Value = oCM_CLIP.IENDOLARES;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PLANO", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IPLANO"])
                {
                    auxPar.Value = oCM_CLIP.IPLANO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@EMAIL", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IEMAIL"])
                {
                    auxPar.Value = oCM_CLIP.IEMAIL;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                

                auxPar = new OleDbParameter("@HOMEPAGE", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IHOMEPAGE"])
                {
                    auxPar.Value = oCM_CLIP.IHOMEPAGE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@BWCOLOR", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IBWCOLOR"])
                {
                    auxPar.Value = oCM_CLIP.IBWCOLOR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MULVEN", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IMULVEN"])
                {
                    auxPar.Value = oCM_CLIP.IMULVEN;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CTA_IEPS", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["ICTA_IEPS"])
                {
                    auxPar.Value = oCM_CLIP.ICTA_IEPS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@P_MOVIL", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IP_MOVIL"])
                {
                    auxPar.Value = oCM_CLIP.IP_MOVIL;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ACUMULA", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IACUMULA"])
                {
                    auxPar.Value = oCM_CLIP.IACUMULA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SALDO_GLOB", OleDbType.Double);
                if (!(bool)oCM_CLIP.isnull["ISALDO_GLOB"])
                {
                    auxPar.Value = oCM_CLIP.ISALDO_GLOB;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@USERNAME", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IUSERNAME"])
                {
                    auxPar.Value = oCM_CLIP.IUSERNAME;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PASSWORD", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IPASSWORD"])
                {
                    auxPar.Value = oCM_CLIP.IPASSWORD;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_ALTA", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IID_ALTA"])
                {
                    auxPar.Value = oCM_CLIP.IID_ALTA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CLAVE_EDO", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["ICLAVE_EDO"])
                {
                    auxPar.Value = oCM_CLIP.ICLAVE_EDO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COB_INTERE", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["ICOB_INTERE"])
                {
                    auxPar.Value = oCM_CLIP.ICOB_INTERE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PLAZA", OleDbType.Double);
                if (!(bool)oCM_CLIP.isnull["IPLAZA"])
                {
                    auxPar.Value = oCM_CLIP.IPLAZA;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COM_ESP", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["ICOM_ESP"])
                {
                    auxPar.Value = oCM_CLIP.ICOM_ESP;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@POR_COME", OleDbType.Double);
                if (!(bool)oCM_CLIP.isnull["IPOR_COME"])
                {
                    auxPar.Value = oCM_CLIP.IPOR_COME;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@L_BLOQUEO", OleDbType.Boolean);
                /*if (!(bool)oCM_CLIP.isnull["IL_BLOQUEO"])
                {
                    auxPar.Value = oCM_CLIP.IL_BLOQUEO;
                }
                else
                {
                    auxPar.Value = "";
                }*/
                auxPar.Value = false;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@VISITA", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IVISITA"])
                {
                    auxPar.Value = oCM_CLIP.IVISITA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@RUTA", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IRUTA"])
                {
                    auxPar.Value = oCM_CLIP.IRUTA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@L_DESC", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IL_DESC"])
                {
                    auxPar.Value = oCM_CLIP.IL_DESC;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@POCKET", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IPOCKET"])
                {
                    auxPar.Value = oCM_CLIP.IPOCKET;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CLIEPOCK", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["ICLIEPOCK"])
                {
                    auxPar.Value = oCM_CLIP.ICLIEPOCK;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESCI", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IDESCI"])
                {
                    auxPar.Value = oCM_CLIP.IDESCI;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@BLOQ2", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IBLOQ2"])
                {
                    auxPar.Value = oCM_CLIP.IBLOQ2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DIASP", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IDIASP"])
                {
                    auxPar.Value = oCM_CLIP.IDIASP;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DIASEXTR", OleDbType.Double);
                if (!(bool)oCM_CLIP.isnull["IDIASEXTR"])
                {
                    auxPar.Value = oCM_CLIP.IDIASEXTR;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COBVENCIDA", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["ICOBVENCIDA"])
                {
                    auxPar.Value = oCM_CLIP.ICOBVENCIDA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@VENDEDOR2", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IVENDEDOR2"])
                {
                    auxPar.Value = oCM_CLIP.IVENDEDOR2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CURP", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["ICURP"])
                {
                    auxPar.Value = oCM_CLIP.ICURP;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@AUTORIZA", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IAUTORIZA"])
                {
                    auxPar.Value = oCM_CLIP.IAUTORIZA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TIPO_INTER", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["ITIPO_INTER"])
                {
                    auxPar.Value = oCM_CLIP.ITIPO_INTER;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESTRATEGIC", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IESTRATEGIC"])
                {
                    auxPar.Value = oCM_CLIP.IESTRATEGIC;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESTATUS", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IESTATUS"])
                {
                    auxPar.Value = oCM_CLIP.IESTATUS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DIA", OleDbType.Double);
                if (!(bool)oCM_CLIP.isnull["IDIA"])
                {
                    auxPar.Value = oCM_CLIP.IDIA;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MES", OleDbType.Double);
                if (!(bool)oCM_CLIP.isnull["IMES"])
                {
                    auxPar.Value = oCM_CLIP.IMES;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@BLOQXLIMIT", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IBLOQXLIMIT"])
                {
                    auxPar.Value = oCM_CLIP.IBLOQXLIMIT;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COMPANIA", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["ICOMPANIA"])
                {
                    auxPar.Value = oCM_CLIP.ICOMPANIA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CUENTA", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["ICUENTA"])
                {
                    auxPar.Value = oCM_CLIP.ICUENTA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PATERNO", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IPATERNO"])
                {
                    auxPar.Value = oCM_CLIP.IPATERNO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MATERNO", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IMATERNO"])
                {
                    auxPar.Value = oCM_CLIP.IMATERNO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOMBRES", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["INOMBRES"])
                {
                    auxPar.Value = oCM_CLIP.INOMBRES;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SERVDOMI", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["ISERVDOMI"])
                {
                    auxPar.Value = oCM_CLIP.ISERVDOMI;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LIMITE2", OleDbType.Double);
                if (!(bool)oCM_CLIP.isnull["ILIMITE2"])
                {
                    auxPar.Value = oCM_CLIP.ILIMITE2;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LIMITETEMP", OleDbType.Double);
                if (!(bool)oCM_CLIP.isnull["ILIMITETEMP"])
                {
                    auxPar.Value = oCM_CLIP.ILIMITETEMP;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TEMPORADA", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["ITEMPORADA"])
                {
                    auxPar.Value = oCM_CLIP.ITEMPORADA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LEFECTIVO", OleDbType.Boolean);
                /*if (!(bool)oCM_CLIP.isnull["ILEFECTIVO"])
                {
                    auxPar.Value = oCM_CLIP.ILEFECTIVO;
                }
                else
                {
                    auxPar.Value = "";
                }*/
                auxPar.Value = false;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SALDO_SISA", OleDbType.Double);
                if (!(bool)oCM_CLIP.isnull["ISALDO_SISA"])
                {
                    auxPar.Value = oCM_CLIP.ISALDO_SISA;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@EMPRE", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IEMPRE"])
                {
                    auxPar.Value = oCM_CLIP.IEMPRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FENOMCL", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IFENOMCL"])
                {
                    auxPar.Value = oCM_CLIP.IFENOMCL;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FELOCCL", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IFELOCCL"])
                {
                    auxPar.Value = oCM_CLIP.IFELOCCL;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FEREFCL", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IFEREFCL"])
                {
                    auxPar.Value = oCM_CLIP.IFEREFCL;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FENUECL", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IFENUECL"])
                {
                    auxPar.Value = oCM_CLIP.IFENUECL;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FENUICL", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IFENUICL"])
                {
                    auxPar.Value = oCM_CLIP.IFENUICL;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FEPAICL", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IFEPAICL"])
                {
                    auxPar.Value = oCM_CLIP.IFEPAICL;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@METPAGO", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IMETPAGO"])
                {
                    auxPar.Value = oCM_CLIP.IMETPAGO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CTAPAGO", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["ICTAPAGO"])
                {
                    auxPar.Value = oCM_CLIP.ICTAPAGO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ENVIAXML", OleDbType.VarChar);
                if (!(bool)oCM_CLIP.isnull["IENVIAXML"])
                {
                    auxPar.Value = oCM_CLIP.IENVIAXML;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                

                string commandText = @"
        INSERT INTO M_CLIP
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

VISITA,

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

AUTORIZA,

TIPO_INTER,

ESTRATEGIC,

ESTATUS,

DIA,

MES,

BLOQXLIMIT,

COMPANIA,

CUENTA,

PATERNO,

MATERNO,

NOMBRES,

SERVDOMI,

LIMITE2,

LIMITETEMP,

TEMPORADA,

LEFECTIVO,

SALDO_SISA,

EMPRE,

FENOMCL,

FELOCCL,

FEREFCL,

FENUECL,

FENUICL,

FEPAICL,

METPAGO,

CTAPAGO,

ENVIAXML
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

                //if (st == null)
                    OleDbHelper.ExecuteNonQuery(strOleDbConn, CommandType.Text, commandText, arParms);
                //else
                //    OleDbHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }







        public CM_CLIPD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
        }
    }
}
