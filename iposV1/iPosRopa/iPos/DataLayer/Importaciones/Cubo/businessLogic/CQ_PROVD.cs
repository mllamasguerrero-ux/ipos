
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



    public class CQ_PROVD
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


        public bool AgregarQ_PROVD(CQ_PROVBE oCQ_PROV, string strFileName, OleDbTransaction st, string strOleDbConn)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@PROVEEDOR", OleDbType.VarChar);
                if (!(bool)oCQ_PROV.isnull["IPROVEEDOR"])
                {
                    auxPar.Value = oCQ_PROV.IPROVEEDOR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                if (!(bool)oCQ_PROV.isnull["INOMBRE"])
                {
                    auxPar.Value = oCQ_PROV.INOMBRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOMBRE2", OleDbType.VarChar);
                if (!(bool)oCQ_PROV.isnull["INOMBRE2"])
                {
                    auxPar.Value = oCQ_PROV.INOMBRE2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SALDO", OleDbType.Double);
                if (!(bool)oCQ_PROV.isnull["ISALDO"])
                {
                    auxPar.Value = oCQ_PROV.ISALDO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SALDO_VENC", OleDbType.Double);
                if (!(bool)oCQ_PROV.isnull["ISALDO_VENC"])
                {
                    auxPar.Value = oCQ_PROV.ISALDO_VENC;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@C_VENCIDAS", OleDbType.Double);
                if (!(bool)oCQ_PROV.isnull["IC_VENCIDAS"])
                {
                    auxPar.Value = oCQ_PROV.IC_VENCIDAS;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CALLE", OleDbType.VarChar);
                if (!(bool)oCQ_PROV.isnull["ICALLE"])
                {
                    auxPar.Value = oCQ_PROV.ICALLE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COLONIA", OleDbType.VarChar);
                if (!(bool)oCQ_PROV.isnull["ICOLONIA"])
                {
                    auxPar.Value = oCQ_PROV.ICOLONIA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CIUDAD", OleDbType.VarChar);
                if (!(bool)oCQ_PROV.isnull["ICIUDAD"])
                {
                    auxPar.Value = oCQ_PROV.ICIUDAD;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESTADO", OleDbType.VarChar);
                if (!(bool)oCQ_PROV.isnull["IESTADO"])
                {
                    auxPar.Value = oCQ_PROV.IESTADO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CP", OleDbType.VarChar);
                if (!(bool)oCQ_PROV.isnull["ICP"])
                {
                    auxPar.Value = oCQ_PROV.ICP;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TEL1", OleDbType.VarChar);
                if (!(bool)oCQ_PROV.isnull["ITEL1"])
                {
                    auxPar.Value = oCQ_PROV.ITEL1;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TEL2", OleDbType.VarChar);
                if (!(bool)oCQ_PROV.isnull["ITEL2"])
                {
                    auxPar.Value = oCQ_PROV.ITEL2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CONTACTO", OleDbType.VarChar);
                if (!(bool)oCQ_PROV.isnull["ICONTACTO"])
                {
                    auxPar.Value = oCQ_PROV.ICONTACTO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CONTACTO2", OleDbType.VarChar);
                if (!(bool)oCQ_PROV.isnull["ICONTACTO2"])
                {
                    auxPar.Value = oCQ_PROV.ICONTACTO2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TIPO", OleDbType.VarChar);
                if (!(bool)oCQ_PROV.isnull["ITIPO"])
                {
                    auxPar.Value = oCQ_PROV.ITIPO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DIAS", OleDbType.Double);
                if (!(bool)oCQ_PROV.isnull["IDIAS"])
                {
                    auxPar.Value = oCQ_PROV.IDIAS;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CREDITO", OleDbType.Double);
                if (!(bool)oCQ_PROV.isnull["ICREDITO"])
                {
                    auxPar.Value = oCQ_PROV.ICREDITO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ALTA", OleDbType.Date);
                if (!(bool)oCQ_PROV.isnull["IALTA"])
                {
                    auxPar.Value = oCQ_PROV.IALTA;
                }
                else
                {
                    auxPar.Value = DateTime.Today;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COMPRADOR", OleDbType.VarChar);
                if (!(bool)oCQ_PROV.isnull["ICOMPRADOR"])
                {
                    auxPar.Value = oCQ_PROV.ICOMPRADOR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@T_ENT", OleDbType.Double);
                if (!(bool)oCQ_PROV.isnull["IT_ENT"])
                {
                    auxPar.Value = oCQ_PROV.IT_ENT;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ULT_COMPRA", OleDbType.Date);
                if (!(bool)oCQ_PROV.isnull["IULT_COMPRA"])
                {
                    auxPar.Value = oCQ_PROV.IULT_COMPRA;
                }
                else
                {
                    auxPar.Value = DateTime.Today;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@UC_CANT", OleDbType.Double);
                if (!(bool)oCQ_PROV.isnull["IUC_CANT"])
                {
                    auxPar.Value = oCQ_PROV.IUC_CANT;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COM_PERIO", OleDbType.Double);
                if (!(bool)oCQ_PROV.isnull["ICOM_PERIO"])
                {
                    auxPar.Value = oCQ_PROV.ICOM_PERIO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@VAL_PERIO", OleDbType.Double);
                if (!(bool)oCQ_PROV.isnull["IVAL_PERIO"])
                {
                    auxPar.Value = oCQ_PROV.IVAL_PERIO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COM_ACUM", OleDbType.Double);
                if (!(bool)oCQ_PROV.isnull["ICOM_ACUM"])
                {
                    auxPar.Value = oCQ_PROV.ICOM_ACUM;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@VAL_ACUM", OleDbType.Double);
                if (!(bool)oCQ_PROV.isnull["IVAL_ACUM"])
                {
                    auxPar.Value = oCQ_PROV.IVAL_ACUM;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@BLOQUEADO", OleDbType.VarChar);
                if (!(bool)oCQ_PROV.isnull["IBLOQUEADO"])
                {
                    auxPar.Value = oCQ_PROV.IBLOQUEADO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@BLOQUEONOT", OleDbType.VarChar);
                if (!(bool)oCQ_PROV.isnull["IBLOQUEONOT"])
                {
                    auxPar.Value = oCQ_PROV.IBLOQUEONOT;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@RFC", OleDbType.VarChar);
                if (!(bool)oCQ_PROV.isnull["IRFC"])
                {
                    auxPar.Value = oCQ_PROV.IRFC;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCQ_PROV.isnull["IID"])
                {
                    auxPar.Value = oCQ_PROV.IID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCQ_PROV.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCQ_PROV.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.Today;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCQ_PROV.isnull["IID_HORA"])
                {
                    auxPar.Value = oCQ_PROV.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SAL1", OleDbType.Double);
                if (!(bool)oCQ_PROV.isnull["ISAL1"])
                {
                    auxPar.Value = oCQ_PROV.ISAL1;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SALANT", OleDbType.Double);
                if (!(bool)oCQ_PROV.isnull["ISALANT"])
                {
                    auxPar.Value = oCQ_PROV.ISALANT;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FALTANTE", OleDbType.Double);
                if (!(bool)oCQ_PROV.isnull["IFALTANTE"])
                {
                    auxPar.Value = oCQ_PROV.IFALTANTE;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@X_RECIBIR", OleDbType.Double);
                if (!(bool)oCQ_PROV.isnull["IX_RECIBIR"])
                {
                    auxPar.Value = oCQ_PROV.IX_RECIBIR;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MAIL1", OleDbType.VarChar);
                if (!(bool)oCQ_PROV.isnull["IMAIL1"])
                {
                    auxPar.Value = oCQ_PROV.IMAIL1;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MAIL2", OleDbType.VarChar);
                if (!(bool)oCQ_PROV.isnull["IMAIL2"])
                {
                    auxPar.Value = oCQ_PROV.IMAIL2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SOBRANTE", OleDbType.Double);
                if (!(bool)oCQ_PROV.isnull["ISOBRANTE"])
                {
                    auxPar.Value = oCQ_PROV.ISOBRANTE;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@EXISTENCIA", OleDbType.Double);
                if (!(bool)oCQ_PROV.isnull["IEXISTENCIA"])
                {
                    auxPar.Value = oCQ_PROV.IEXISTENCIA;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Double);
                if (!(bool)oCQ_PROV.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCQ_PROV.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@EMAIL", OleDbType.VarChar);
                if (!(bool)oCQ_PROV.isnull["IEMAIL"])
                {
                    auxPar.Value = oCQ_PROV.IEMAIL;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPORTE", OleDbType.Double);
                if (!(bool)oCQ_PROV.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCQ_PROV.IIMPORTE;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CLAVE_EDO", OleDbType.VarChar);
                if (!(bool)oCQ_PROV.isnull["ICLAVE_EDO"])
                {
                    auxPar.Value = oCQ_PROV.ICLAVE_EDO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CURP", OleDbType.VarChar);
                if (!(bool)oCQ_PROV.isnull["ICURP"])
                {
                    auxPar.Value = oCQ_PROV.ICURP;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESTRATEGIC", OleDbType.VarChar);
                if (!(bool)oCQ_PROV.isnull["IESTRATEGIC"])
                {
                    auxPar.Value = oCQ_PROV.IESTRATEGIC;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MAIL", OleDbType.VarChar);
                if (!(bool)oCQ_PROV.isnull["IMAIL"])
                {
                    auxPar.Value = oCQ_PROV.IMAIL;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PLAZO", OleDbType.VarChar);
                if (!(bool)oCQ_PROV.isnull["IPLAZO"])
                {
                    auxPar.Value = oCQ_PROV.IPLAZO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO " + strFileName + @"
      (
    
PROVEEDOR,

NOMBRE,

NOMBRE2,

SALDO,

SALDO_VENC,

C_VENCIDAS,

CALLE,

COLONIA,

CIUDAD,

ESTADO,

CP,

TEL1,

TEL2,

CONTACTO,

CONTACTO2,

TIPO,

DIAS,

CREDITO,

ALTA,

COMPRADOR,

T_ENT,

ULT_COMPRA,

UC_CANT,

COM_PERIO,

VAL_PERIO,

COM_ACUM,

VAL_ACUM,

BLOQUEADO,

BLOQUEONOT,

RFC,

ID,

ID_FECHA,

ID_HORA,

SAL1,

SALANT,

FALTANTE,

X_RECIBIR,

MAIL1,

MAIL2,

SOBRANTE,

EXISTENCIA,

CANTIDAD,

EMAIL,

IMPORTE,

CLAVE_EDO,

CURP,

ESTRATEGIC,

MAIL,

PLAZO
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

        

        public CQ_PROVD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
