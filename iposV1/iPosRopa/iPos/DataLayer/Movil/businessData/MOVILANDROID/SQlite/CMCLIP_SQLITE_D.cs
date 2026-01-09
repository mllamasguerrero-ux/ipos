using iPosBusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Collections;
using System.Data;

namespace iPosData
{
    public class CMCLIP_SQLITE_D: IMCLIPD
    {

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



        public bool CreateTableMCLIP_MOVIL(string strOleDbConn)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(strOleDbConn);
            try
            {

                m_dbConnection.Open();

                string sql = @"CREATE TABLE MCLIP ( 

                                CLIENTE TEXT,
                                NOMBRE TEXT,
                                SALDO NUMERIC,
                                SALDO_VENC NUMERIC,
                                LIMITE NUMERIC,
                                NUMERO NUMERIC,
                                SALDO_US NUMERIC,
                                ALTA TEXT,
                                ULT_COMPRA TEXT,
                                UC_CANT NUMERIC,
                                NOMBRE2 TEXT,
                                FACT_PERIO NUMERIC,
                                COMPRAS_P NUMERIC,
                                FACT_ACUM NUMERIC,
                                COMPRAS_A NUMERIC,
                                CHQ_DEVUEL NUMERIC,
                                F_VENCIDAS NUMERIC,
                                CALLE TEXT,
                                COLONIA TEXT,
                                ESTADO TEXT,
                                CIUDAD TEXT,
                                CP TEXT,
                                RFC TEXT,
                                TELEFONO TEXT,
                                TELEFONO2 TEXT,
                                CONTACTO TEXT,
                                CONTACTO2 TEXT,
                                VENDEDOR TEXT,
                                TIPO TEXT,
                                COMODIN TEXT,
                                DIAS NUMERIC,
                                DIASA NUMERIC,
                                DIASB NUMERIC,
                                REVISION TEXT,
                                PAGOS TEXT,
                                CLASIFICA TEXT,
                                DESCUENTO NUMERIC,
                                BLOQUEADO TEXT,
                                BLOQUEONOT TEXT,
                                EFECTIVO TEXT,
                                CORREO TEXT,
                                ULT_LLAMAD TEXT,
                                PROX_LLAMA TEXT,
                                ID TEXT,
                                ID_FECHA TEXT,
                                ID_HORA TEXT,
                                CALLE1 TEXT,
                                CRUZACON TEXT,
                                DESGIEPS TEXT,
                                ENDOLARES NUMERIC,
                                PLANO TEXT,
                                EMAIL TEXT,
                                EMAIL2 TEXT,
                                HOMEPAGE TEXT,
                                BWCOLOR TEXT,
                                MULVEN TEXT,
                                CTA_IEPS TEXT,
                                P_MOVIL TEXT,
                                ACUMULA TEXT,
                                SALDO_GLOB NUMERIC,
                                USERNAME TEXT,
                                PASSWORD TEXT,
                                ID_ALTA TEXT,
                                CLAVE_EDO TEXT,
                                COB_INTERE TEXT,
                                PLAZA NUMERIC,
                                COM_ESP TEXT,
                                POR_COME NUMERIC,
                                L_BLOQUEO TEXT,
                                VISITA TEXT,
                                RUTA TEXT,
                                L_DESC TEXT,
                                POCKET TEXT,
                                CLIEPOCK TEXT,
                                DESCI TEXT,
                                BLOQ2 TEXT,
                                DIASP TEXT,
                                DIASEXTR NUMERIC,
                                COBVENCIDA TEXT,
                                VENDEDOR2 TEXT,
                                CURP TEXT,
                                AUTORIZA TEXT,
                                TIPO_INTER TEXT,
                                ESTRATEGIC TEXT,
                                ESTATUS TEXT,
                                DIA NUMERIC,
                                MES NUMERIC,
                                BLOQXLIMIT TEXT,
                                COMPANIA TEXT,
                                CUENTA TEXT,
                                PATERNO TEXT,
                                MATERNO TEXT,
                                NOMBRES TEXT,
                                SERVDOMI TEXT,
                                LIMITE2 NUMERIC,
                                LIMITETEMP NUMERIC,
                                TEMPORADA TEXT,
                                LEFECTIVO TEXT,
                                SALDO_SISA NUMERIC,
                                EMPRE TEXT,
                                FENOMCL TEXT,
                                FELOCCL TEXT,
                                FEREFCL TEXT,
                                FENUECL TEXT,
                                FENUICL TEXT,
                                FEPAICL TEXT,
                                METPAGO TEXT,
                                CTAPAGO TEXT,
                                ENVIAXML TEXT,
                                GEOCODIGO TEXT,
                                POTENCIAL TEXT,
                                VALOR TEXT,
                                HORARIOVEN TEXT,
                                HORARIOTIE TEXT,
                                DESCANSO TEXT,
                                OBSERVA TEXT,
                                OTROSPROV TEXT,
                                AGIL TEXT,
                                SIXNOMBRE TEXT


); ";

                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                m_dbConnection.Close();
                m_dbConnection.Dispose();
                command.Dispose();

                GC.Collect();

            }
            catch { }
            finally { try { m_dbConnection.Close(); } catch { } }
            return true;
        }




        public bool AgregarM_CLIPD(CM_CLIPBE oCM_CLIP, string strFileName,
                                    string strOleDbConn)
        {


            try
            {





                System.Collections.ArrayList parts = new ArrayList();
                SQLiteParameter auxPar;



                auxPar = new SQLiteParameter("$CLIENTE", DbType.String);
                if (!(bool)oCM_CLIP.isnull["ICLIENTE"])
                {
                    auxPar.Value = oCM_CLIP.ICLIENTE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$NOMBRE", DbType.String);
                if (!(bool)oCM_CLIP.isnull["INOMBRE"])
                {
                    auxPar.Value = oCM_CLIP.INOMBRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$SALDO", DbType.Double);
                if (!(bool)oCM_CLIP.isnull["ISALDO"])
                {
                    auxPar.Value = oCM_CLIP.ISALDO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$SALDO_VENC", DbType.Double);
                if (!(bool)oCM_CLIP.isnull["ISALDO_VENC"])
                {
                    auxPar.Value = oCM_CLIP.ISALDO_VENC;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$LIMITE", DbType.Double);
                if (!(bool)oCM_CLIP.isnull["ILIMITE"])
                {
                    auxPar.Value = oCM_CLIP.ILIMITE;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$NUMERO", DbType.Double);
                if (!(bool)oCM_CLIP.isnull["INUMERO"])
                {
                    auxPar.Value = oCM_CLIP.INUMERO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$SALDO_US", DbType.Double);
                if (!(bool)oCM_CLIP.isnull["ISALDO_US"])
                {
                    auxPar.Value = oCM_CLIP.ISALDO_US;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$ALTA", DbType.Date);
                if (!(bool)oCM_CLIP.isnull["IALTA"])
                {
                    auxPar.Value = oCM_CLIP.IALTA;
                }
                else
                {
                    auxPar.Value = DateTime.Today;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$ULT_COMPRA", DbType.Date);
                if (!(bool)oCM_CLIP.isnull["IULT_COMPRA"])
                {
                    auxPar.Value = oCM_CLIP.IULT_COMPRA;
                }
                else
                {
                    auxPar.Value = DateTime.Today;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$UC_CANT", DbType.Double);
                if (!(bool)oCM_CLIP.isnull["IUC_CANT"])
                {
                    auxPar.Value = oCM_CLIP.IUC_CANT;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$NOMBRE2", DbType.String);
                if (!(bool)oCM_CLIP.isnull["INOMBRE2"])
                {
                    auxPar.Value = oCM_CLIP.INOMBRE2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$FACT_PERIO", DbType.Double);
                if (!(bool)oCM_CLIP.isnull["IFACT_PERIO"])
                {
                    auxPar.Value = oCM_CLIP.IFACT_PERIO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$COMPRAS_P", DbType.Double);
                if (!(bool)oCM_CLIP.isnull["ICOMPRAS_P"])
                {
                    auxPar.Value = oCM_CLIP.ICOMPRAS_P;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$FACT_ACUM", DbType.Double);
                if (!(bool)oCM_CLIP.isnull["IFACT_ACUM"])
                {
                    auxPar.Value = oCM_CLIP.IFACT_ACUM;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$COMPRAS_A", DbType.Double);
                if (!(bool)oCM_CLIP.isnull["ICOMPRAS_A"])
                {
                    auxPar.Value = oCM_CLIP.ICOMPRAS_A;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$CHQ_DEVUEL", DbType.Double);
                if (!(bool)oCM_CLIP.isnull["ICHQ_DEVUEL"])
                {
                    auxPar.Value = oCM_CLIP.ICHQ_DEVUEL;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$F_VENCIDAS", DbType.Double);
                if (!(bool)oCM_CLIP.isnull["IF_VENCIDAS"])
                {
                    auxPar.Value = oCM_CLIP.IF_VENCIDAS;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$CALLE", DbType.String);
                if (!(bool)oCM_CLIP.isnull["ICALLE"])
                {
                    auxPar.Value = oCM_CLIP.ICALLE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$COLONIA", DbType.String);
                if (!(bool)oCM_CLIP.isnull["ICOLONIA"])
                {
                    auxPar.Value = oCM_CLIP.ICOLONIA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$ESTADO", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IESTADO"])
                {
                    auxPar.Value = oCM_CLIP.IESTADO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$CIUDAD", DbType.String);
                if (!(bool)oCM_CLIP.isnull["ICIUDAD"])
                {
                    auxPar.Value = oCM_CLIP.ICIUDAD;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$CP", DbType.String);
                if (!(bool)oCM_CLIP.isnull["ICP"])
                {
                    auxPar.Value = oCM_CLIP.ICP;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$RFC", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IRFC"])
                {
                    auxPar.Value = oCM_CLIP.IRFC;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$TELEFONO", DbType.String);
                if (!(bool)oCM_CLIP.isnull["ITELEFONO"])
                {
                    auxPar.Value = oCM_CLIP.ITELEFONO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$TELEFONO2", DbType.String);
                if (!(bool)oCM_CLIP.isnull["ITELEFONO2"])
                {
                    auxPar.Value = oCM_CLIP.ITELEFONO2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$CONTACTO", DbType.String);
                if (!(bool)oCM_CLIP.isnull["ICONTACTO"])
                {
                    auxPar.Value = oCM_CLIP.ICONTACTO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$CONTACTO2", DbType.String);
                if (!(bool)oCM_CLIP.isnull["ICONTACTO2"])
                {
                    auxPar.Value = oCM_CLIP.ICONTACTO2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$VENDEDOR", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IVENDEDOR"])
                {
                    auxPar.Value = oCM_CLIP.IVENDEDOR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$TIPO", DbType.String);
                if (!(bool)oCM_CLIP.isnull["ITIPO"])
                {
                    auxPar.Value = oCM_CLIP.ITIPO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$COMODIN", DbType.String);
                if (!(bool)oCM_CLIP.isnull["ICOMODIN"])
                {
                    auxPar.Value = oCM_CLIP.ICOMODIN;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$DIAS", DbType.Double);
                if (!(bool)oCM_CLIP.isnull["IDIAS"])
                {
                    auxPar.Value = oCM_CLIP.IDIAS;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$DIASA", DbType.Double);
                if (!(bool)oCM_CLIP.isnull["IDIASA"])
                {
                    auxPar.Value = oCM_CLIP.IDIASA;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$DIASB", DbType.Double);
                if (!(bool)oCM_CLIP.isnull["IDIASB"])
                {
                    auxPar.Value = oCM_CLIP.IDIASB;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$REVISION", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IREVISION"])
                {
                    auxPar.Value = oCM_CLIP.IREVISION;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$PAGOS", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IPAGOS"])
                {
                    auxPar.Value = oCM_CLIP.IPAGOS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$CLASIFICA", DbType.String);
                if (!(bool)oCM_CLIP.isnull["ICLASIFICA"])
                {
                    auxPar.Value = oCM_CLIP.ICLASIFICA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$DESCUENTO", DbType.Double);
                if (!(bool)oCM_CLIP.isnull["IDESCUENTO"])
                {
                    auxPar.Value = oCM_CLIP.IDESCUENTO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$BLOQUEADO", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IBLOQUEADO"])
                {
                    auxPar.Value = oCM_CLIP.IBLOQUEADO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$BLOQUEONOT", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IBLOQUEONOT"])
                {
                    auxPar.Value = oCM_CLIP.IBLOQUEONOT;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$EFECTIVO", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IEFECTIVO"])
                {
                    auxPar.Value = oCM_CLIP.IEFECTIVO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$CORREO", DbType.String);
                if (!(bool)oCM_CLIP.isnull["ICORREO"])
                {
                    auxPar.Value = oCM_CLIP.ICORREO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$ULT_LLAMAD", DbType.Date);
                if (!(bool)oCM_CLIP.isnull["IULT_LLAMAD"])
                {
                    auxPar.Value = oCM_CLIP.IULT_LLAMAD;
                }
                else
                {
                    auxPar.Value = DateTime.Today;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$PROX_LLAMA", DbType.Date);
                if (!(bool)oCM_CLIP.isnull["IPROX_LLAMA"])
                {
                    auxPar.Value = oCM_CLIP.IPROX_LLAMA;
                }
                else
                {
                    auxPar.Value = DateTime.Today;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$ID", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IID"])
                {
                    auxPar.Value = oCM_CLIP.IID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$ID_FECHA", DbType.Date);
                if (!(bool)oCM_CLIP.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_CLIP.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.Today;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$ID_HORA", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_CLIP.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$CALLE1", DbType.String);
                if (!(bool)oCM_CLIP.isnull["ICALLE1"])
                {
                    auxPar.Value = oCM_CLIP.ICALLE1;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$CRUZACON", DbType.String);
                if (!(bool)oCM_CLIP.isnull["ICRUZACON"])
                {
                    auxPar.Value = oCM_CLIP.ICRUZACON;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$DESGIEPS", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IDESGIEPS"])
                {
                    auxPar.Value = oCM_CLIP.IDESGIEPS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$ENDOLARES", DbType.Double);
                if (!(bool)oCM_CLIP.isnull["IENDOLARES"])
                {
                    auxPar.Value = oCM_CLIP.IENDOLARES;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$PLANO", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IPLANO"])
                {
                    auxPar.Value = oCM_CLIP.IPLANO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$EMAIL", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IEMAIL"])
                {
                    auxPar.Value = oCM_CLIP.IEMAIL;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new SQLiteParameter("$HOMEPAGE", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IHOMEPAGE"])
                {
                    auxPar.Value = oCM_CLIP.IHOMEPAGE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$BWCOLOR", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IBWCOLOR"])
                {
                    auxPar.Value = oCM_CLIP.IBWCOLOR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$MULVEN", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IMULVEN"])
                {
                    auxPar.Value = oCM_CLIP.IMULVEN;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$CTA_IEPS", DbType.String);
                if (!(bool)oCM_CLIP.isnull["ICTA_IEPS"])
                {
                    auxPar.Value = oCM_CLIP.ICTA_IEPS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$P_MOVIL", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IP_MOVIL"])
                {
                    auxPar.Value = oCM_CLIP.IP_MOVIL;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$ACUMULA", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IACUMULA"])
                {
                    auxPar.Value = oCM_CLIP.IACUMULA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$SALDO_GLOB", DbType.Double);
                if (!(bool)oCM_CLIP.isnull["ISALDO_GLOB"])
                {
                    auxPar.Value = oCM_CLIP.ISALDO_GLOB;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$USERNAME", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IUSERNAME"])
                {
                    auxPar.Value = oCM_CLIP.IUSERNAME;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$PASSWORD", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IPASSWORD"])
                {
                    auxPar.Value = oCM_CLIP.IPASSWORD;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$ID_ALTA", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IID_ALTA"])
                {
                    auxPar.Value = oCM_CLIP.IID_ALTA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$CLAVE_EDO", DbType.String);
                if (!(bool)oCM_CLIP.isnull["ICLAVE_EDO"])
                {
                    auxPar.Value = oCM_CLIP.ICLAVE_EDO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$COB_INTERE", DbType.String);
                if (!(bool)oCM_CLIP.isnull["ICOB_INTERE"])
                {
                    auxPar.Value = oCM_CLIP.ICOB_INTERE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$PLAZA", DbType.Double);
                if (!(bool)oCM_CLIP.isnull["IPLAZA"])
                {
                    auxPar.Value = oCM_CLIP.IPLAZA;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$COM_ESP", DbType.String);
                if (!(bool)oCM_CLIP.isnull["ICOM_ESP"])
                {
                    auxPar.Value = oCM_CLIP.ICOM_ESP;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$POR_COME", DbType.Double);
                if (!(bool)oCM_CLIP.isnull["IPOR_COME"])
                {
                    auxPar.Value = oCM_CLIP.IPOR_COME;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$L_BLOQUEO", DbType.Boolean);
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


                auxPar = new SQLiteParameter("$VISITA", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IVISITA"])
                {
                    auxPar.Value = oCM_CLIP.IVISITA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$RUTA", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IRUTA"])
                {
                    auxPar.Value = oCM_CLIP.IRUTA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$L_DESC", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IL_DESC"])
                {
                    auxPar.Value = oCM_CLIP.IL_DESC;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$POCKET", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IPOCKET"])
                {
                    auxPar.Value = oCM_CLIP.IPOCKET;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$CLIEPOCK", DbType.String);
                if (!(bool)oCM_CLIP.isnull["ICLIEPOCK"])
                {
                    auxPar.Value = oCM_CLIP.ICLIEPOCK;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$DESCI", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IDESCI"])
                {
                    auxPar.Value = oCM_CLIP.IDESCI;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$BLOQ2", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IBLOQ2"])
                {
                    auxPar.Value = oCM_CLIP.IBLOQ2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$DIASP", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IDIASP"])
                {
                    auxPar.Value = oCM_CLIP.IDIASP;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$DIASEXTR", DbType.Double);
                if (!(bool)oCM_CLIP.isnull["IDIASEXTR"])
                {
                    auxPar.Value = oCM_CLIP.IDIASEXTR;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$COBVENCIDA", DbType.String);
                if (!(bool)oCM_CLIP.isnull["ICOBVENCIDA"])
                {
                    auxPar.Value = oCM_CLIP.ICOBVENCIDA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$VENDEDOR2", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IVENDEDOR2"])
                {
                    auxPar.Value = oCM_CLIP.IVENDEDOR2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$CURP", DbType.String);
                if (!(bool)oCM_CLIP.isnull["ICURP"])
                {
                    auxPar.Value = oCM_CLIP.ICURP;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$AUTORIZA", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IAUTORIZA"])
                {
                    auxPar.Value = oCM_CLIP.IAUTORIZA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$TIPO_INTER", DbType.String);
                if (!(bool)oCM_CLIP.isnull["ITIPO_INTER"])
                {
                    auxPar.Value = oCM_CLIP.ITIPO_INTER;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$ESTRATEGIC", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IESTRATEGIC"])
                {
                    auxPar.Value = oCM_CLIP.IESTRATEGIC;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$ESTATUS", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IESTATUS"])
                {
                    auxPar.Value = oCM_CLIP.IESTATUS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$DIA", DbType.Double);
                if (!(bool)oCM_CLIP.isnull["IDIA"])
                {
                    auxPar.Value = oCM_CLIP.IDIA;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$MES", DbType.Double);
                if (!(bool)oCM_CLIP.isnull["IMES"])
                {
                    auxPar.Value = oCM_CLIP.IMES;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$BLOQXLIMIT", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IBLOQXLIMIT"])
                {
                    auxPar.Value = oCM_CLIP.IBLOQXLIMIT;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$COMPANIA", DbType.String);
                if (!(bool)oCM_CLIP.isnull["ICOMPANIA"])
                {
                    auxPar.Value = oCM_CLIP.ICOMPANIA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$CUENTA", DbType.String);
                if (!(bool)oCM_CLIP.isnull["ICUENTA"])
                {
                    auxPar.Value = oCM_CLIP.ICUENTA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$PATERNO", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IPATERNO"])
                {
                    auxPar.Value = oCM_CLIP.IPATERNO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$MATERNO", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IMATERNO"])
                {
                    auxPar.Value = oCM_CLIP.IMATERNO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$NOMBRES", DbType.String);
                if (!(bool)oCM_CLIP.isnull["INOMBRES"])
                {
                    auxPar.Value = oCM_CLIP.INOMBRES;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$SERVDOMI", DbType.String);
                if (!(bool)oCM_CLIP.isnull["ISERVDOMI"])
                {
                    auxPar.Value = oCM_CLIP.ISERVDOMI;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$LIMITE2", DbType.Double);
                if (!(bool)oCM_CLIP.isnull["ILIMITE2"])
                {
                    auxPar.Value = oCM_CLIP.ILIMITE2;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$LIMITETEMP", DbType.Double);
                if (!(bool)oCM_CLIP.isnull["ILIMITETEMP"])
                {
                    auxPar.Value = oCM_CLIP.ILIMITETEMP;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$TEMPORADA", DbType.String);
                if (!(bool)oCM_CLIP.isnull["ITEMPORADA"])
                {
                    auxPar.Value = oCM_CLIP.ITEMPORADA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$LEFECTIVO", DbType.Boolean);
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


                auxPar = new SQLiteParameter("$SALDO_SISA", DbType.Double);
                if (!(bool)oCM_CLIP.isnull["ISALDO_SISA"])
                {
                    auxPar.Value = oCM_CLIP.ISALDO_SISA;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$EMPRE", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IEMPRE"])
                {
                    auxPar.Value = oCM_CLIP.IEMPRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$FENOMCL", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IFENOMCL"])
                {
                    auxPar.Value = oCM_CLIP.IFENOMCL;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$FELOCCL", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IFELOCCL"])
                {
                    auxPar.Value = oCM_CLIP.IFELOCCL;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$FEREFCL", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IFEREFCL"])
                {
                    auxPar.Value = oCM_CLIP.IFEREFCL;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$FENUECL", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IFENUECL"])
                {
                    auxPar.Value = oCM_CLIP.IFENUECL;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$FENUICL", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IFENUICL"])
                {
                    auxPar.Value = oCM_CLIP.IFENUICL;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$FEPAICL", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IFEPAICL"])
                {
                    auxPar.Value = oCM_CLIP.IFEPAICL;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$METPAGO", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IMETPAGO"])
                {
                    auxPar.Value = oCM_CLIP.IMETPAGO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$CTAPAGO", DbType.String);
                if (!(bool)oCM_CLIP.isnull["ICTAPAGO"])
                {
                    auxPar.Value = oCM_CLIP.ICTAPAGO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$ENVIAXML", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IENVIAXML"])
                {
                    auxPar.Value = oCM_CLIP.IENVIAXML;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$EMAIL2", DbType.String);
                if (!(bool)oCM_CLIP.isnull["IEMAIL2"])
                {
                    auxPar.Value = oCM_CLIP.IEMAIL2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);





                string commandText = @"
        INSERT INTO MCLIP
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
ENVIAXML,
EMAIL2

         )

Values (
$CLIENTE,
$NOMBRE,
$SALDO,
$SALDO_VENC,
$LIMITE,
$NUMERO,
$SALDO_US,
$ALTA,
$ULT_COMPRA,
$UC_CANT,
$NOMBRE2,
$FACT_PERIO,
$COMPRAS_P,
$FACT_ACUM,
$COMPRAS_A,
$CHQ_DEVUEL,
$F_VENCIDAS,
$CALLE,
$COLONIA,
$ESTADO,
$CIUDAD,
$CP,
$RFC,
$TELEFONO,
$TELEFONO2,
$CONTACTO,
$CONTACTO2,
$VENDEDOR,
$TIPO,
$COMODIN,
$DIAS,
$DIASA,
$DIASB,
$REVISION,
$PAGOS,
$CLASIFICA,
$DESCUENTO,
$BLOQUEADO,
$BLOQUEONOT,
$EFECTIVO,
$CORREO,
$ULT_LLAMAD,
$PROX_LLAMA,
$ID,
$ID_FECHA,
$ID_HORA,
$CALLE1,
$CRUZACON,
$DESGIEPS,
$ENDOLARES,
$PLANO,
$EMAIL,
$HOMEPAGE,
$BWCOLOR,
$MULVEN,
$CTA_IEPS,
$P_MOVIL,
$ACUMULA,
$SALDO_GLOB,
$USERNAME,
$PASSWORD,
$ID_ALTA,
$CLAVE_EDO,
$COB_INTERE,
$PLAZA,
$COM_ESP,
$POR_COME,
$L_BLOQUEO,
$VISITA,
$RUTA,
$L_DESC,
$POCKET,
$CLIEPOCK,
$DESCI,
$BLOQ2,
$DIASP,
$DIASEXTR,
$COBVENCIDA,
$VENDEDOR2,
$CURP,
$AUTORIZA,
$TIPO_INTER,
$ESTRATEGIC,
$ESTATUS,
$DIA,
$MES,
$BLOQXLIMIT,
$COMPANIA,
$CUENTA,
$PATERNO,
$MATERNO,
$NOMBRES,
$SERVDOMI,
$LIMITE2,
$LIMITETEMP,
$TEMPORADA,
$LEFECTIVO,
$SALDO_SISA,
$EMPRE,
$FENOMCL,
$FELOCCL,
$FEREFCL,
$FENUECL,
$FENUICL,
$FEPAICL,
$METPAGO,
$CTAPAGO,
$ENVIAXML,
$EMAIL2



); ";

                SQLiteParameter[] arParms = new SQLiteParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                using (SQLiteConnection conn = new SQLiteConnection(strOleDbConn))
                {
                    conn.Open();
                    using (var cmd = new SQLiteCommand(commandText, conn))
                    {
                        using (SQLiteHelper sq = new SQLiteHelper(cmd))
                        {
                            sq.Execute(commandText, arParms);
                        }
                    }
                    conn.Close();
                    conn.Dispose();
                    GC.Collect();
                }



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
