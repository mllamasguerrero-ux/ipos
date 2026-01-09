
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

    [Transaction(TransactionOption.Supported)]


    public class CM_ENCCD
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


        [AutoComplete]
        public bool AgregarM_ENCCD(CM_ENCCBE oCM_ENCC, string strFileName, OleDbTransaction st, string strOleDbConn)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@PROVEEDOR", OleDbType.VarChar);
                if (!(bool)oCM_ENCC.isnull["IPROVEEDOR"])
                {
                    auxPar.Value = oCM_ENCC.IPROVEEDOR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                if (!(bool)oCM_ENCC.isnull["INOMBRE"])
                {
                    auxPar.Value = oCM_ENCC.INOMBRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOMBRE2", OleDbType.VarChar);
                if (!(bool)oCM_ENCC.isnull["INOMBRE2"])
                {
                    auxPar.Value = oCM_ENCC.INOMBRE2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SALDO", OleDbType.Double);
                if (!(bool)oCM_ENCC.isnull["ISALDO"])
                {
                    auxPar.Value = oCM_ENCC.ISALDO;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SALDO_VENC", OleDbType.Double);
                if (!(bool)oCM_ENCC.isnull["ISALDO_VENC"])
                {
                    auxPar.Value = oCM_ENCC.ISALDO_VENC;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@C_VENCIDAS", OleDbType.Double);
                if (!(bool)oCM_ENCC.isnull["IC_VENCIDAS"])
                {
                    auxPar.Value = oCM_ENCC.IC_VENCIDAS;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CALLE", OleDbType.VarChar);
                if (!(bool)oCM_ENCC.isnull["ICALLE"])
                {
                    auxPar.Value = oCM_ENCC.ICALLE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COLONIA", OleDbType.VarChar);
                if (!(bool)oCM_ENCC.isnull["ICOLONIA"])
                {
                    auxPar.Value = oCM_ENCC.ICOLONIA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CIUDAD", OleDbType.VarChar);
                if (!(bool)oCM_ENCC.isnull["ICIUDAD"])
                {
                    auxPar.Value = oCM_ENCC.ICIUDAD;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESTADO", OleDbType.VarChar);
                if (!(bool)oCM_ENCC.isnull["IESTADO"])
                {
                    auxPar.Value = oCM_ENCC.IESTADO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CP", OleDbType.VarChar);
                if (!(bool)oCM_ENCC.isnull["ICP"])
                {
                    auxPar.Value = oCM_ENCC.ICP;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TEL1", OleDbType.VarChar);
                if (!(bool)oCM_ENCC.isnull["ITEL1"])
                {
                    auxPar.Value = oCM_ENCC.ITEL1;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TEL2", OleDbType.VarChar);
                if (!(bool)oCM_ENCC.isnull["ITEL2"])
                {
                    auxPar.Value = oCM_ENCC.ITEL2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CONTACTO", OleDbType.VarChar);
                if (!(bool)oCM_ENCC.isnull["ICONTACTO"])
                {
                    auxPar.Value = oCM_ENCC.ICONTACTO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CONTACTO2", OleDbType.VarChar);
                if (!(bool)oCM_ENCC.isnull["ICONTACTO2"])
                {
                    auxPar.Value = oCM_ENCC.ICONTACTO2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TIPO", OleDbType.VarChar);
                if (!(bool)oCM_ENCC.isnull["ITIPO"])
                {
                    auxPar.Value = oCM_ENCC.ITIPO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@EMAIL", OleDbType.VarChar);
                if (!(bool)oCM_ENCC.isnull["IEMAIL"])
                {
                    auxPar.Value = oCM_ENCC.IEMAIL;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DIAS", OleDbType.Double);
                if (!(bool)oCM_ENCC.isnull["IDIAS"])
                {
                    auxPar.Value = oCM_ENCC.IDIAS;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);




                auxPar = new OleDbParameter("@ALTA", OleDbType.Date);
                if (!(bool)oCM_ENCC.isnull["IALTA"])
                {
                    auxPar.Value = oCM_ENCC.IALTA;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COMPRADOR", OleDbType.VarChar);
                if (!(bool)oCM_ENCC.isnull["ICOMPRADOR"])
                {
                    auxPar.Value = oCM_ENCC.ICOMPRADOR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@T_ENT", OleDbType.Double);
                if (!(bool)oCM_ENCC.isnull["IT_ENT"])
                {
                    auxPar.Value = oCM_ENCC.IT_ENT;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ULT_COMPRA", OleDbType.Date);
                if (!(bool)oCM_ENCC.isnull["IULT_COMPRA"])
                {
                    auxPar.Value = oCM_ENCC.IULT_COMPRA;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@UC_CANT", OleDbType.Double);
                if (!(bool)oCM_ENCC.isnull["IUC_CANT"])
                {
                    auxPar.Value = oCM_ENCC.IUC_CANT;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COM_PERIO", OleDbType.Double);
                if (!(bool)oCM_ENCC.isnull["ICOM_PERIO"])
                {
                    auxPar.Value = oCM_ENCC.ICOM_PERIO;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@VAL_PERIO", OleDbType.Double);
                if (!(bool)oCM_ENCC.isnull["IVAL_PERIO"])
                {
                    auxPar.Value = oCM_ENCC.IVAL_PERIO;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COM_ACUM", OleDbType.Double);
                if (!(bool)oCM_ENCC.isnull["ICOM_ACUM"])
                {
                    auxPar.Value = oCM_ENCC.ICOM_ACUM;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@VAL_ACUM", OleDbType.Double);
                if (!(bool)oCM_ENCC.isnull["IVAL_ACUM"])
                {
                    auxPar.Value = oCM_ENCC.IVAL_ACUM;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@BLOQUEADO", OleDbType.VarChar);
                if (!(bool)oCM_ENCC.isnull["IBLOQUEADO"])
                {
                    auxPar.Value = oCM_ENCC.IBLOQUEADO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@BLOQUEONOT", OleDbType.VarChar);
                if (!(bool)oCM_ENCC.isnull["IBLOQUEONOT"])
                {
                    auxPar.Value = oCM_ENCC.IBLOQUEONOT;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@RFC", OleDbType.VarChar);
                if (!(bool)oCM_ENCC.isnull["IRFC"])
                {
                    auxPar.Value = oCM_ENCC.IRFC;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FALTANTE", OleDbType.Double);
                if (!(bool)oCM_ENCC.isnull["IFALTANTE"])
                {
                    auxPar.Value = oCM_ENCC.IFALTANTE;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@X_RECIBIR", OleDbType.Double);
                if (!(bool)oCM_ENCC.isnull["IX_RECIBIR"])
                {
                    auxPar.Value = oCM_ENCC.IX_RECIBIR;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SOBRANTE", OleDbType.Double);
                if (!(bool)oCM_ENCC.isnull["ISOBRANTE"])
                {
                    auxPar.Value = oCM_ENCC.ISOBRANTE;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@EXISTENCIA", OleDbType.Double);
                if (!(bool)oCM_ENCC.isnull["IEXISTENCIA"])
                {
                    auxPar.Value = oCM_ENCC.IEXISTENCIA;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Double);
                if (!(bool)oCM_ENCC.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCM_ENCC.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPORTE", OleDbType.Double);
                if (!(bool)oCM_ENCC.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCM_ENCC.IIMPORTE;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PASSWORD", OleDbType.VarChar);
                if (!(bool)oCM_ENCC.isnull["IPASSWORD"])
                {
                    auxPar.Value = oCM_ENCC.IPASSWORD;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCM_ENCC.isnull["IID"])
                {
                    auxPar.Value = oCM_ENCC.IID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCM_ENCC.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_ENCC.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCM_ENCC.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_ENCC.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SURTIR", OleDbType.VarChar);
                if (!(bool)oCM_ENCC.isnull["ISURTIR"])
                {
                    auxPar.Value = oCM_ENCC.ISURTIR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ADESCPES", OleDbType.Double);
                if (!(bool)oCM_ENCC.isnull["IADESCPES"])
                {
                    auxPar.Value = oCM_ENCC.IADESCPES;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);




                string commandText = @"
        INSERT INTO M_ENCC
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

EMAIL,

DIAS,

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

FALTANTE,

X_RECIBIR,

SOBRANTE,

EXISTENCIA,

CANTIDAD,

IMPORTE,

PASSWORD,

ID,

ID_FECHA,

ID_HORA,

SURTIR,

ADESCPES

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


        [AutoComplete]
        public bool BorrarM_ENCCD(CM_ENCCBE oCM_ENCC, OleDbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@PROVEEDOR", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.IPROVEEDOR;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.INOMBRE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOMBRE2", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.INOMBRE2;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SALDO", OleDbType.Double);
                auxPar.Value = oCM_ENCC.ISALDO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SALDO_VENC", OleDbType.Double);
                auxPar.Value = oCM_ENCC.ISALDO_VENC;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@C_VENCIDAS", OleDbType.Double);
                auxPar.Value = oCM_ENCC.IC_VENCIDAS;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CALLE", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.ICALLE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COLONIA", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.ICOLONIA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CIUDAD", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.ICIUDAD;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESTADO", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.IESTADO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CP", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.ICP;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TEL1", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.ITEL1;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TEL2", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.ITEL2;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CONTACTO", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.ICONTACTO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CONTACTO2", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.ICONTACTO2;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TIPO", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.ITIPO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@EMAIL", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.IEMAIL;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DIAS", OleDbType.Double);
                auxPar.Value = oCM_ENCC.IDIAS;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CREDITO", OleDbType.Double);
                auxPar.Value = oCM_ENCC.ICREDITO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ALTA", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.IALTA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COMPRADOR", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.ICOMPRADOR;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@T_ENT", OleDbType.Double);
                auxPar.Value = oCM_ENCC.IT_ENT;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ULT_COMPRA", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.IULT_COMPRA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@UC_CANT", OleDbType.Double);
                auxPar.Value = oCM_ENCC.IUC_CANT;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COM_PERIO", OleDbType.Double);
                auxPar.Value = oCM_ENCC.ICOM_PERIO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@VAL_PERIO", OleDbType.Double);
                auxPar.Value = oCM_ENCC.IVAL_PERIO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COM_ACUM", OleDbType.Double);
                auxPar.Value = oCM_ENCC.ICOM_ACUM;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@VAL_ACUM", OleDbType.Double);
                auxPar.Value = oCM_ENCC.IVAL_ACUM;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@BLOQUEADO", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.IBLOQUEADO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@BLOQUEONOT", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.IBLOQUEONOT;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@RFC", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.IRFC;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FALTANTE", OleDbType.Double);
                auxPar.Value = oCM_ENCC.IFALTANTE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@X_RECIBIR", OleDbType.Double);
                auxPar.Value = oCM_ENCC.IX_RECIBIR;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SOBRANTE", OleDbType.Double);
                auxPar.Value = oCM_ENCC.ISOBRANTE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@EXISTENCIA", OleDbType.Double);
                auxPar.Value = oCM_ENCC.IEXISTENCIA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Double);
                auxPar.Value = oCM_ENCC.ICANTIDAD;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPORTE", OleDbType.Double);
                auxPar.Value = oCM_ENCC.IIMPORTE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PASSWORD", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.IPASSWORD;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.IID;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                auxPar.Value = oCM_ENCC.IID_FECHA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.IID_HORA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SURTIR", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.ISURTIR;
                parts.Add(auxPar);



                string commandText = @"  Delete from M_ENCC
  where

  PROVEEDOR=@PROVEEDOR and 

  NOMBRE=@NOMBRE and 

  NOMBRE2=@NOMBRE2 and 

  SALDO=@SALDO and 

  SALDO_VENC=@SALDO_VENC and 

  C_VENCIDAS=@C_VENCIDAS and 

  CALLE=@CALLE and 

  COLONIA=@COLONIA and 

  CIUDAD=@CIUDAD and 

  ESTADO=@ESTADO and 

  CP=@CP and 

  TEL1=@TEL1 and 

  TEL2=@TEL2 and 

  CONTACTO=@CONTACTO and 

  CONTACTO2=@CONTACTO2 and 

  TIPO=@TIPO and 

  EMAIL=@EMAIL and 

  DIAS=@DIAS and 

  CREDITO=@CREDITO and 

  ALTA=@ALTA and 

  COMPRADOR=@COMPRADOR and 

  T_ENT=@T_ENT and 

  ULT_COMPRA=@ULT_COMPRA and 

  UC_CANT=@UC_CANT and 

  COM_PERIO=@COM_PERIO and 

  VAL_PERIO=@VAL_PERIO and 

  COM_ACUM=@COM_ACUM and 

  VAL_ACUM=@VAL_ACUM and 

  BLOQUEADO=@BLOQUEADO and 

  BLOQUEONOT=@BLOQUEONOT and 

  RFC=@RFC and 

  FALTANTE=@FALTANTE and 

  X_RECIBIR=@X_RECIBIR and 

  SOBRANTE=@SOBRANTE and 

  EXISTENCIA=@EXISTENCIA and 

  CANTIDAD=@CANTIDAD and 

  IMPORTE=@IMPORTE and 

  PASSWORD=@PASSWORD and 

  ID=@ID and 

  ID_FECHA=@ID_FECHA and 

  ID_HORA=@ID_HORA and 

  SURTIR=@SURTIR
  ;";

                OleDbParameter[] arParms = new OleDbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    OleDbHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
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


        [AutoComplete]
        public bool CambiarM_ENCCD(CM_ENCCBE oCM_ENCCNuevo, CM_ENCCBE oCM_ENCCAnterior, OleDbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@PROVEEDOR", OleDbType.VarChar);
                if (!(bool)oCM_ENCCNuevo.isnull["IPROVEEDOR"])
                {
                    auxPar.Value = oCM_ENCCNuevo.IPROVEEDOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                if (!(bool)oCM_ENCCNuevo.isnull["INOMBRE"])
                {
                    auxPar.Value = oCM_ENCCNuevo.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@NOMBRE2", OleDbType.VarChar);
                if (!(bool)oCM_ENCCNuevo.isnull["INOMBRE2"])
                {
                    auxPar.Value = oCM_ENCCNuevo.INOMBRE2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@SALDO", OleDbType.Double);
                if (!(bool)oCM_ENCCNuevo.isnull["ISALDO"])
                {
                    auxPar.Value = oCM_ENCCNuevo.ISALDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@SALDO_VENC", OleDbType.Double);
                if (!(bool)oCM_ENCCNuevo.isnull["ISALDO_VENC"])
                {
                    auxPar.Value = oCM_ENCCNuevo.ISALDO_VENC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@C_VENCIDAS", OleDbType.Double);
                if (!(bool)oCM_ENCCNuevo.isnull["IC_VENCIDAS"])
                {
                    auxPar.Value = oCM_ENCCNuevo.IC_VENCIDAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CALLE", OleDbType.VarChar);
                if (!(bool)oCM_ENCCNuevo.isnull["ICALLE"])
                {
                    auxPar.Value = oCM_ENCCNuevo.ICALLE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COLONIA", OleDbType.VarChar);
                if (!(bool)oCM_ENCCNuevo.isnull["ICOLONIA"])
                {
                    auxPar.Value = oCM_ENCCNuevo.ICOLONIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CIUDAD", OleDbType.VarChar);
                if (!(bool)oCM_ENCCNuevo.isnull["ICIUDAD"])
                {
                    auxPar.Value = oCM_ENCCNuevo.ICIUDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ESTADO", OleDbType.VarChar);
                if (!(bool)oCM_ENCCNuevo.isnull["IESTADO"])
                {
                    auxPar.Value = oCM_ENCCNuevo.IESTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CP", OleDbType.VarChar);
                if (!(bool)oCM_ENCCNuevo.isnull["ICP"])
                {
                    auxPar.Value = oCM_ENCCNuevo.ICP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TEL1", OleDbType.VarChar);
                if (!(bool)oCM_ENCCNuevo.isnull["ITEL1"])
                {
                    auxPar.Value = oCM_ENCCNuevo.ITEL1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TEL2", OleDbType.VarChar);
                if (!(bool)oCM_ENCCNuevo.isnull["ITEL2"])
                {
                    auxPar.Value = oCM_ENCCNuevo.ITEL2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CONTACTO", OleDbType.VarChar);
                if (!(bool)oCM_ENCCNuevo.isnull["ICONTACTO"])
                {
                    auxPar.Value = oCM_ENCCNuevo.ICONTACTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CONTACTO2", OleDbType.VarChar);
                if (!(bool)oCM_ENCCNuevo.isnull["ICONTACTO2"])
                {
                    auxPar.Value = oCM_ENCCNuevo.ICONTACTO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TIPO", OleDbType.VarChar);
                if (!(bool)oCM_ENCCNuevo.isnull["ITIPO"])
                {
                    auxPar.Value = oCM_ENCCNuevo.ITIPO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@EMAIL", OleDbType.VarChar);
                if (!(bool)oCM_ENCCNuevo.isnull["IEMAIL"])
                {
                    auxPar.Value = oCM_ENCCNuevo.IEMAIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@DIAS", OleDbType.Double);
                if (!(bool)oCM_ENCCNuevo.isnull["IDIAS"])
                {
                    auxPar.Value = oCM_ENCCNuevo.IDIAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CREDITO", OleDbType.Double);
                if (!(bool)oCM_ENCCNuevo.isnull["ICREDITO"])
                {
                    auxPar.Value = oCM_ENCCNuevo.ICREDITO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ALTA", OleDbType.VarChar);
                if (!(bool)oCM_ENCCNuevo.isnull["IALTA"])
                {
                    auxPar.Value = oCM_ENCCNuevo.IALTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COMPRADOR", OleDbType.VarChar);
                if (!(bool)oCM_ENCCNuevo.isnull["ICOMPRADOR"])
                {
                    auxPar.Value = oCM_ENCCNuevo.ICOMPRADOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@T_ENT", OleDbType.Double);
                if (!(bool)oCM_ENCCNuevo.isnull["IT_ENT"])
                {
                    auxPar.Value = oCM_ENCCNuevo.IT_ENT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ULT_COMPRA", OleDbType.VarChar);
                if (!(bool)oCM_ENCCNuevo.isnull["IULT_COMPRA"])
                {
                    auxPar.Value = oCM_ENCCNuevo.IULT_COMPRA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@UC_CANT", OleDbType.Double);
                if (!(bool)oCM_ENCCNuevo.isnull["IUC_CANT"])
                {
                    auxPar.Value = oCM_ENCCNuevo.IUC_CANT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COM_PERIO", OleDbType.Double);
                if (!(bool)oCM_ENCCNuevo.isnull["ICOM_PERIO"])
                {
                    auxPar.Value = oCM_ENCCNuevo.ICOM_PERIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@VAL_PERIO", OleDbType.Double);
                if (!(bool)oCM_ENCCNuevo.isnull["IVAL_PERIO"])
                {
                    auxPar.Value = oCM_ENCCNuevo.IVAL_PERIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COM_ACUM", OleDbType.Double);
                if (!(bool)oCM_ENCCNuevo.isnull["ICOM_ACUM"])
                {
                    auxPar.Value = oCM_ENCCNuevo.ICOM_ACUM;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@VAL_ACUM", OleDbType.Double);
                if (!(bool)oCM_ENCCNuevo.isnull["IVAL_ACUM"])
                {
                    auxPar.Value = oCM_ENCCNuevo.IVAL_ACUM;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@BLOQUEADO", OleDbType.VarChar);
                if (!(bool)oCM_ENCCNuevo.isnull["IBLOQUEADO"])
                {
                    auxPar.Value = oCM_ENCCNuevo.IBLOQUEADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@BLOQUEONOT", OleDbType.VarChar);
                if (!(bool)oCM_ENCCNuevo.isnull["IBLOQUEONOT"])
                {
                    auxPar.Value = oCM_ENCCNuevo.IBLOQUEONOT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@RFC", OleDbType.VarChar);
                if (!(bool)oCM_ENCCNuevo.isnull["IRFC"])
                {
                    auxPar.Value = oCM_ENCCNuevo.IRFC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@FALTANTE", OleDbType.Double);
                if (!(bool)oCM_ENCCNuevo.isnull["IFALTANTE"])
                {
                    auxPar.Value = oCM_ENCCNuevo.IFALTANTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@X_RECIBIR", OleDbType.Double);
                if (!(bool)oCM_ENCCNuevo.isnull["IX_RECIBIR"])
                {
                    auxPar.Value = oCM_ENCCNuevo.IX_RECIBIR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@SOBRANTE", OleDbType.Double);
                if (!(bool)oCM_ENCCNuevo.isnull["ISOBRANTE"])
                {
                    auxPar.Value = oCM_ENCCNuevo.ISOBRANTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@EXISTENCIA", OleDbType.Double);
                if (!(bool)oCM_ENCCNuevo.isnull["IEXISTENCIA"])
                {
                    auxPar.Value = oCM_ENCCNuevo.IEXISTENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Double);
                if (!(bool)oCM_ENCCNuevo.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCM_ENCCNuevo.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@IMPORTE", OleDbType.Double);
                if (!(bool)oCM_ENCCNuevo.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCM_ENCCNuevo.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PASSWORD", OleDbType.VarChar);
                if (!(bool)oCM_ENCCNuevo.isnull["IPASSWORD"])
                {
                    auxPar.Value = oCM_ENCCNuevo.IPASSWORD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCM_ENCCNuevo.isnull["IID"])
                {
                    auxPar.Value = oCM_ENCCNuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCM_ENCCNuevo.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_ENCCNuevo.IID_FECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCM_ENCCNuevo.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_ENCCNuevo.IID_HORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@SURTIR", OleDbType.VarChar);
                if (!(bool)oCM_ENCCNuevo.isnull["ISURTIR"])
                {
                    auxPar.Value = oCM_ENCCNuevo.ISURTIR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PROVEEDORAnt", OleDbType.VarChar);
                if (!(bool)oCM_ENCCAnterior.isnull["IPROVEEDOR"])
                {
                    auxPar.Value = oCM_ENCCAnterior.IPROVEEDOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@NOMBREAnt", OleDbType.VarChar);
                if (!(bool)oCM_ENCCAnterior.isnull["INOMBRE"])
                {
                    auxPar.Value = oCM_ENCCAnterior.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@NOMBRE2Ant", OleDbType.VarChar);
                if (!(bool)oCM_ENCCAnterior.isnull["INOMBRE2"])
                {
                    auxPar.Value = oCM_ENCCAnterior.INOMBRE2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@SALDOAnt", OleDbType.Double);
                if (!(bool)oCM_ENCCAnterior.isnull["ISALDO"])
                {
                    auxPar.Value = oCM_ENCCAnterior.ISALDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@SALDO_VENCAnt", OleDbType.Double);
                if (!(bool)oCM_ENCCAnterior.isnull["ISALDO_VENC"])
                {
                    auxPar.Value = oCM_ENCCAnterior.ISALDO_VENC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@C_VENCIDASAnt", OleDbType.Double);
                if (!(bool)oCM_ENCCAnterior.isnull["IC_VENCIDAS"])
                {
                    auxPar.Value = oCM_ENCCAnterior.IC_VENCIDAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CALLEAnt", OleDbType.VarChar);
                if (!(bool)oCM_ENCCAnterior.isnull["ICALLE"])
                {
                    auxPar.Value = oCM_ENCCAnterior.ICALLE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COLONIAAnt", OleDbType.VarChar);
                if (!(bool)oCM_ENCCAnterior.isnull["ICOLONIA"])
                {
                    auxPar.Value = oCM_ENCCAnterior.ICOLONIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CIUDADAnt", OleDbType.VarChar);
                if (!(bool)oCM_ENCCAnterior.isnull["ICIUDAD"])
                {
                    auxPar.Value = oCM_ENCCAnterior.ICIUDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ESTADOAnt", OleDbType.VarChar);
                if (!(bool)oCM_ENCCAnterior.isnull["IESTADO"])
                {
                    auxPar.Value = oCM_ENCCAnterior.IESTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CPAnt", OleDbType.VarChar);
                if (!(bool)oCM_ENCCAnterior.isnull["ICP"])
                {
                    auxPar.Value = oCM_ENCCAnterior.ICP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TEL1Ant", OleDbType.VarChar);
                if (!(bool)oCM_ENCCAnterior.isnull["ITEL1"])
                {
                    auxPar.Value = oCM_ENCCAnterior.ITEL1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TEL2Ant", OleDbType.VarChar);
                if (!(bool)oCM_ENCCAnterior.isnull["ITEL2"])
                {
                    auxPar.Value = oCM_ENCCAnterior.ITEL2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CONTACTOAnt", OleDbType.VarChar);
                if (!(bool)oCM_ENCCAnterior.isnull["ICONTACTO"])
                {
                    auxPar.Value = oCM_ENCCAnterior.ICONTACTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CONTACTO2Ant", OleDbType.VarChar);
                if (!(bool)oCM_ENCCAnterior.isnull["ICONTACTO2"])
                {
                    auxPar.Value = oCM_ENCCAnterior.ICONTACTO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TIPOAnt", OleDbType.VarChar);
                if (!(bool)oCM_ENCCAnterior.isnull["ITIPO"])
                {
                    auxPar.Value = oCM_ENCCAnterior.ITIPO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@EMAILAnt", OleDbType.VarChar);
                if (!(bool)oCM_ENCCAnterior.isnull["IEMAIL"])
                {
                    auxPar.Value = oCM_ENCCAnterior.IEMAIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@DIASAnt", OleDbType.Double);
                if (!(bool)oCM_ENCCAnterior.isnull["IDIAS"])
                {
                    auxPar.Value = oCM_ENCCAnterior.IDIAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CREDITOAnt", OleDbType.Double);
                if (!(bool)oCM_ENCCAnterior.isnull["ICREDITO"])
                {
                    auxPar.Value = oCM_ENCCAnterior.ICREDITO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ALTAAnt", OleDbType.VarChar);
                if (!(bool)oCM_ENCCAnterior.isnull["IALTA"])
                {
                    auxPar.Value = oCM_ENCCAnterior.IALTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COMPRADORAnt", OleDbType.VarChar);
                if (!(bool)oCM_ENCCAnterior.isnull["ICOMPRADOR"])
                {
                    auxPar.Value = oCM_ENCCAnterior.ICOMPRADOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@T_ENTAnt", OleDbType.Double);
                if (!(bool)oCM_ENCCAnterior.isnull["IT_ENT"])
                {
                    auxPar.Value = oCM_ENCCAnterior.IT_ENT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ULT_COMPRAAnt", OleDbType.VarChar);
                if (!(bool)oCM_ENCCAnterior.isnull["IULT_COMPRA"])
                {
                    auxPar.Value = oCM_ENCCAnterior.IULT_COMPRA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@UC_CANTAnt", OleDbType.Double);
                if (!(bool)oCM_ENCCAnterior.isnull["IUC_CANT"])
                {
                    auxPar.Value = oCM_ENCCAnterior.IUC_CANT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COM_PERIOAnt", OleDbType.Double);
                if (!(bool)oCM_ENCCAnterior.isnull["ICOM_PERIO"])
                {
                    auxPar.Value = oCM_ENCCAnterior.ICOM_PERIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@VAL_PERIOAnt", OleDbType.Double);
                if (!(bool)oCM_ENCCAnterior.isnull["IVAL_PERIO"])
                {
                    auxPar.Value = oCM_ENCCAnterior.IVAL_PERIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COM_ACUMAnt", OleDbType.Double);
                if (!(bool)oCM_ENCCAnterior.isnull["ICOM_ACUM"])
                {
                    auxPar.Value = oCM_ENCCAnterior.ICOM_ACUM;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@VAL_ACUMAnt", OleDbType.Double);
                if (!(bool)oCM_ENCCAnterior.isnull["IVAL_ACUM"])
                {
                    auxPar.Value = oCM_ENCCAnterior.IVAL_ACUM;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@BLOQUEADOAnt", OleDbType.VarChar);
                if (!(bool)oCM_ENCCAnterior.isnull["IBLOQUEADO"])
                {
                    auxPar.Value = oCM_ENCCAnterior.IBLOQUEADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@BLOQUEONOTAnt", OleDbType.VarChar);
                if (!(bool)oCM_ENCCAnterior.isnull["IBLOQUEONOT"])
                {
                    auxPar.Value = oCM_ENCCAnterior.IBLOQUEONOT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@RFCAnt", OleDbType.VarChar);
                if (!(bool)oCM_ENCCAnterior.isnull["IRFC"])
                {
                    auxPar.Value = oCM_ENCCAnterior.IRFC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@FALTANTEAnt", OleDbType.Double);
                if (!(bool)oCM_ENCCAnterior.isnull["IFALTANTE"])
                {
                    auxPar.Value = oCM_ENCCAnterior.IFALTANTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@X_RECIBIRAnt", OleDbType.Double);
                if (!(bool)oCM_ENCCAnterior.isnull["IX_RECIBIR"])
                {
                    auxPar.Value = oCM_ENCCAnterior.IX_RECIBIR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@SOBRANTEAnt", OleDbType.Double);
                if (!(bool)oCM_ENCCAnterior.isnull["ISOBRANTE"])
                {
                    auxPar.Value = oCM_ENCCAnterior.ISOBRANTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@EXISTENCIAAnt", OleDbType.Double);
                if (!(bool)oCM_ENCCAnterior.isnull["IEXISTENCIA"])
                {
                    auxPar.Value = oCM_ENCCAnterior.IEXISTENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CANTIDADAnt", OleDbType.Double);
                if (!(bool)oCM_ENCCAnterior.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCM_ENCCAnterior.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@IMPORTEAnt", OleDbType.Double);
                if (!(bool)oCM_ENCCAnterior.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCM_ENCCAnterior.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PASSWORDAnt", OleDbType.VarChar);
                if (!(bool)oCM_ENCCAnterior.isnull["IPASSWORD"])
                {
                    auxPar.Value = oCM_ENCCAnterior.IPASSWORD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@IDAnt", OleDbType.VarChar);
                if (!(bool)oCM_ENCCAnterior.isnull["IID"])
                {
                    auxPar.Value = oCM_ENCCAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_FECHAAnt", OleDbType.Date);
                if (!(bool)oCM_ENCCAnterior.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_ENCCAnterior.IID_FECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_HORAAnt", OleDbType.VarChar);
                if (!(bool)oCM_ENCCAnterior.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_ENCCAnterior.IID_HORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@SURTIRAnt", OleDbType.VarChar);
                if (!(bool)oCM_ENCCAnterior.isnull["ISURTIR"])
                {
                    auxPar.Value = oCM_ENCCAnterior.ISURTIR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  M_ENCC
  set

PROVEEDOR=@PROVEEDOR,

NOMBRE=@NOMBRE,

NOMBRE2=@NOMBRE2,

SALDO=@SALDO,

SALDO_VENC=@SALDO_VENC,

C_VENCIDAS=@C_VENCIDAS,

CALLE=@CALLE,

COLONIA=@COLONIA,

CIUDAD=@CIUDAD,

ESTADO=@ESTADO,

CP=@CP,

TEL1=@TEL1,

TEL2=@TEL2,

CONTACTO=@CONTACTO,

CONTACTO2=@CONTACTO2,

TIPO=@TIPO,

EMAIL=@EMAIL,

DIAS=@DIAS,

CREDITO=@CREDITO,

ALTA=@ALTA,

COMPRADOR=@COMPRADOR,

T_ENT=@T_ENT,

ULT_COMPRA=@ULT_COMPRA,

UC_CANT=@UC_CANT,

COM_PERIO=@COM_PERIO,

VAL_PERIO=@VAL_PERIO,

COM_ACUM=@COM_ACUM,

VAL_ACUM=@VAL_ACUM,

BLOQUEADO=@BLOQUEADO,

BLOQUEONOT=@BLOQUEONOT,

RFC=@RFC,

FALTANTE=@FALTANTE,

X_RECIBIR=@X_RECIBIR,

SOBRANTE=@SOBRANTE,

EXISTENCIA=@EXISTENCIA,

CANTIDAD=@CANTIDAD,

IMPORTE=@IMPORTE,

PASSWORD=@PASSWORD,

ID=@ID,

ID_FECHA=@ID_FECHA,

ID_HORA=@ID_HORA,

SURTIR=@SURTIR
  where 

PROVEEDOR=@PROVEEDORAnt and

NOMBRE=@NOMBREAnt and

NOMBRE2=@NOMBRE2Ant and

SALDO=@SALDOAnt and

SALDO_VENC=@SALDO_VENCAnt and

C_VENCIDAS=@C_VENCIDASAnt and

CALLE=@CALLEAnt and

COLONIA=@COLONIAAnt and

CIUDAD=@CIUDADAnt and

ESTADO=@ESTADOAnt and

CP=@CPAnt and

TEL1=@TEL1Ant and

TEL2=@TEL2Ant and

CONTACTO=@CONTACTOAnt and

CONTACTO2=@CONTACTO2Ant and

TIPO=@TIPOAnt and

EMAIL=@EMAILAnt and

DIAS=@DIASAnt and

CREDITO=@CREDITOAnt and

ALTA=@ALTAAnt and

COMPRADOR=@COMPRADORAnt and

T_ENT=@T_ENTAnt and

ULT_COMPRA=@ULT_COMPRAAnt and

UC_CANT=@UC_CANTAnt and

COM_PERIO=@COM_PERIOAnt and

VAL_PERIO=@VAL_PERIOAnt and

COM_ACUM=@COM_ACUMAnt and

VAL_ACUM=@VAL_ACUMAnt and

BLOQUEADO=@BLOQUEADOAnt and

BLOQUEONOT=@BLOQUEONOTAnt and

RFC=@RFCAnt and

FALTANTE=@FALTANTEAnt and

X_RECIBIR=@X_RECIBIRAnt and

SOBRANTE=@SOBRANTEAnt and

EXISTENCIA=@EXISTENCIAAnt and

CANTIDAD=@CANTIDADAnt and

IMPORTE=@IMPORTEAnt and

PASSWORD=@PASSWORDAnt and

ID=@IDAnt and

ID_FECHA=@ID_FECHAAnt and

ID_HORA=@ID_HORAAnt and

SURTIR=@SURTIRAnt
  ;";

                OleDbParameter[] arParms = new OleDbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    OleDbHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
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


        [AutoComplete]
        public CM_ENCCBE seleccionarM_ENCC(CM_ENCCBE oCM_ENCC, OleDbTransaction st)
        {




            CM_ENCCBE retorno = new CM_ENCCBE();

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;

                String CmdTxt = @"select * from M_ENCC where
 PROVEEDOR=@PROVEEDOR    and
 NOMBRE=@NOMBRE    and
 NOMBRE2=@NOMBRE2    and
 SALDO=@SALDO    and
 SALDO_VENC=@SALDO_VENC    and
 C_VENCIDAS=@C_VENCIDAS    and
 CALLE=@CALLE    and
 COLONIA=@COLONIA    and
 CIUDAD=@CIUDAD    and
 ESTADO=@ESTADO    and
 CP=@CP    and
 TEL1=@TEL1    and
 TEL2=@TEL2    and
 CONTACTO=@CONTACTO    and
 CONTACTO2=@CONTACTO2    and
 TIPO=@TIPO    and
 EMAIL=@EMAIL    and
 DIAS=@DIAS    and
 CREDITO=@CREDITO    and
 ALTA=@ALTA    and
 COMPRADOR=@COMPRADOR    and
 T_ENT=@T_ENT    and
 ULT_COMPRA=@ULT_COMPRA    and
 UC_CANT=@UC_CANT    and
 COM_PERIO=@COM_PERIO    and
 VAL_PERIO=@VAL_PERIO    and
 COM_ACUM=@COM_ACUM    and
 VAL_ACUM=@VAL_ACUM    and
 BLOQUEADO=@BLOQUEADO    and
 BLOQUEONOT=@BLOQUEONOT    and
 RFC=@RFC    and
 FALTANTE=@FALTANTE    and
 X_RECIBIR=@X_RECIBIR    and
 SOBRANTE=@SOBRANTE    and
 EXISTENCIA=@EXISTENCIA    and
 CANTIDAD=@CANTIDAD    and
 IMPORTE=@IMPORTE    and
 PASSWORD=@PASSWORD    and
 ID=@ID    and
 ID_FECHA=@ID_FECHA    and
 ID_HORA=@ID_HORA    and
 SURTIR=@SURTIR  ";


                auxPar = new OleDbParameter("@PROVEEDOR", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.IPROVEEDOR;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.INOMBRE;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@NOMBRE2", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.INOMBRE2;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@SALDO", OleDbType.Double);
                auxPar.Value = oCM_ENCC.ISALDO;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@SALDO_VENC", OleDbType.Double);
                auxPar.Value = oCM_ENCC.ISALDO_VENC;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@C_VENCIDAS", OleDbType.Double);
                auxPar.Value = oCM_ENCC.IC_VENCIDAS;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@CALLE", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.ICALLE;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@COLONIA", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.ICOLONIA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@CIUDAD", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.ICIUDAD;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ESTADO", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.IESTADO;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@CP", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.ICP;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@TEL1", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.ITEL1;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@TEL2", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.ITEL2;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@CONTACTO", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.ICONTACTO;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@CONTACTO2", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.ICONTACTO2;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@TIPO", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.ITIPO;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@EMAIL", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.IEMAIL;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@DIAS", OleDbType.Double);
                auxPar.Value = oCM_ENCC.IDIAS;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@CREDITO", OleDbType.Double);
                auxPar.Value = oCM_ENCC.ICREDITO;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ALTA", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.IALTA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@COMPRADOR", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.ICOMPRADOR;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@T_ENT", OleDbType.Double);
                auxPar.Value = oCM_ENCC.IT_ENT;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ULT_COMPRA", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.IULT_COMPRA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@UC_CANT", OleDbType.Double);
                auxPar.Value = oCM_ENCC.IUC_CANT;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@COM_PERIO", OleDbType.Double);
                auxPar.Value = oCM_ENCC.ICOM_PERIO;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@VAL_PERIO", OleDbType.Double);
                auxPar.Value = oCM_ENCC.IVAL_PERIO;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@COM_ACUM", OleDbType.Double);
                auxPar.Value = oCM_ENCC.ICOM_ACUM;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@VAL_ACUM", OleDbType.Double);
                auxPar.Value = oCM_ENCC.IVAL_ACUM;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@BLOQUEADO", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.IBLOQUEADO;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@BLOQUEONOT", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.IBLOQUEONOT;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@RFC", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.IRFC;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@FALTANTE", OleDbType.Double);
                auxPar.Value = oCM_ENCC.IFALTANTE;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@X_RECIBIR", OleDbType.Double);
                auxPar.Value = oCM_ENCC.IX_RECIBIR;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@SOBRANTE", OleDbType.Double);
                auxPar.Value = oCM_ENCC.ISOBRANTE;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@EXISTENCIA", OleDbType.Double);
                auxPar.Value = oCM_ENCC.IEXISTENCIA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Double);
                auxPar.Value = oCM_ENCC.ICANTIDAD;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@IMPORTE", OleDbType.Double);
                auxPar.Value = oCM_ENCC.IIMPORTE;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@PASSWORD", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.IPASSWORD;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.IID;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.IID_FECHA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.IID_HORA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@SURTIR", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.ISURTIR;
                parts.Add(auxPar);




                OleDbParameter[] arParms = new OleDbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                OleDbDataReader dr;
                if (st == null)
                    dr = OleDbHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, arParms);
                else
                    dr = OleDbHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["PROVEEDOR"] != System.DBNull.Value)
                    {
                        retorno.IPROVEEDOR = (string)(dr["PROVEEDOR"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (dr["NOMBRE2"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE2 = (string)(dr["NOMBRE2"]);
                    }

                    if (dr["SALDO"] != System.DBNull.Value)
                    {
                        retorno.ISALDO = (double)(dr["SALDO"]);
                    }

                    if (dr["SALDO_VENC"] != System.DBNull.Value)
                    {
                        retorno.ISALDO_VENC = (double)(dr["SALDO_VENC"]);
                    }

                    if (dr["C_VENCIDAS"] != System.DBNull.Value)
                    {
                        retorno.IC_VENCIDAS = (double)(dr["C_VENCIDAS"]);
                    }

                    if (dr["CALLE"] != System.DBNull.Value)
                    {
                        retorno.ICALLE = (string)(dr["CALLE"]);
                    }

                    if (dr["COLONIA"] != System.DBNull.Value)
                    {
                        retorno.ICOLONIA = (string)(dr["COLONIA"]);
                    }

                    if (dr["CIUDAD"] != System.DBNull.Value)
                    {
                        retorno.ICIUDAD = (string)(dr["CIUDAD"]);
                    }

                    if (dr["ESTADO"] != System.DBNull.Value)
                    {
                        retorno.IESTADO = (string)(dr["ESTADO"]);
                    }

                    if (dr["CP"] != System.DBNull.Value)
                    {
                        retorno.ICP = (string)(dr["CP"]);
                    }

                    if (dr["TEL1"] != System.DBNull.Value)
                    {
                        retorno.ITEL1 = (string)(dr["TEL1"]);
                    }

                    if (dr["TEL2"] != System.DBNull.Value)
                    {
                        retorno.ITEL2 = (string)(dr["TEL2"]);
                    }

                    if (dr["CONTACTO"] != System.DBNull.Value)
                    {
                        retorno.ICONTACTO = (string)(dr["CONTACTO"]);
                    }

                    if (dr["CONTACTO2"] != System.DBNull.Value)
                    {
                        retorno.ICONTACTO2 = (string)(dr["CONTACTO2"]);
                    }

                    if (dr["TIPO"] != System.DBNull.Value)
                    {
                        retorno.ITIPO = (string)(dr["TIPO"]);
                    }

                    if (dr["EMAIL"] != System.DBNull.Value)
                    {
                        retorno.IEMAIL = (string)(dr["EMAIL"]);
                    }

                    if (dr["DIAS"] != System.DBNull.Value)
                    {
                        retorno.IDIAS = (double)(dr["DIAS"]);
                    }

                    if (dr["CREDITO"] != System.DBNull.Value)
                    {
                        retorno.ICREDITO = (double)(dr["CREDITO"]);
                    }

                    if (dr["ALTA"] != System.DBNull.Value)
                    {
                        retorno.IALTA = (DateTime)(dr["ALTA"]);
                    }

                    if (dr["COMPRADOR"] != System.DBNull.Value)
                    {
                        retorno.ICOMPRADOR = (string)(dr["COMPRADOR"]);
                    }

                    if (dr["T_ENT"] != System.DBNull.Value)
                    {
                        retorno.IT_ENT = (double)(dr["T_ENT"]);
                    }

                    if (dr["ULT_COMPRA"] != System.DBNull.Value)
                    {
                        retorno.IULT_COMPRA = (DateTime)(dr["ULT_COMPRA"]);
                    }

                    if (dr["UC_CANT"] != System.DBNull.Value)
                    {
                        retorno.IUC_CANT = (double)(dr["UC_CANT"]);
                    }

                    if (dr["COM_PERIO"] != System.DBNull.Value)
                    {
                        retorno.ICOM_PERIO = (double)(dr["COM_PERIO"]);
                    }

                    if (dr["VAL_PERIO"] != System.DBNull.Value)
                    {
                        retorno.IVAL_PERIO = (double)(dr["VAL_PERIO"]);
                    }

                    if (dr["COM_ACUM"] != System.DBNull.Value)
                    {
                        retorno.ICOM_ACUM = (double)(dr["COM_ACUM"]);
                    }

                    if (dr["VAL_ACUM"] != System.DBNull.Value)
                    {
                        retorno.IVAL_ACUM = (double)(dr["VAL_ACUM"]);
                    }

                    if (dr["BLOQUEADO"] != System.DBNull.Value)
                    {
                        retorno.IBLOQUEADO = (string)(dr["BLOQUEADO"]);
                    }

                    if (dr["BLOQUEONOT"] != System.DBNull.Value)
                    {
                        retorno.IBLOQUEONOT = (string)(dr["BLOQUEONOT"]);
                    }

                    if (dr["RFC"] != System.DBNull.Value)
                    {
                        retorno.IRFC = (string)(dr["RFC"]);
                    }

                    if (dr["FALTANTE"] != System.DBNull.Value)
                    {
                        retorno.IFALTANTE = (double)(dr["FALTANTE"]);
                    }

                    if (dr["X_RECIBIR"] != System.DBNull.Value)
                    {
                        retorno.IX_RECIBIR = (double)(dr["X_RECIBIR"]);
                    }

                    if (dr["SOBRANTE"] != System.DBNull.Value)
                    {
                        retorno.ISOBRANTE = (double)(dr["SOBRANTE"]);
                    }

                    if (dr["EXISTENCIA"] != System.DBNull.Value)
                    {
                        retorno.IEXISTENCIA = (double)(dr["EXISTENCIA"]);
                    }

                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDAD = (double)(dr["CANTIDAD"]);
                    }

                    if (dr["IMPORTE"] != System.DBNull.Value)
                    {
                        retorno.IIMPORTE = (double)(dr["IMPORTE"]);
                    }

                    if (dr["PASSWORD"] != System.DBNull.Value)
                    {
                        retorno.IPASSWORD = (string)(dr["PASSWORD"]);
                    }

                    if (dr["ID"] != System.DBNull.Value)
                    {
                        retorno.IID = (string)(dr["ID"]);
                    }

                    if (dr["ID_FECHA"] != System.DBNull.Value)
                    {
                        retorno.IID_FECHA = (DateTime)(dr["ID_FECHA"]);
                    }

                    if (dr["ID_HORA"] != System.DBNull.Value)
                    {
                        retorno.IID_HORA = (string)(dr["ID_HORA"]);
                    }

                    if (dr["SURTIR"] != System.DBNull.Value)
                    {
                        retorno.ISURTIR = (string)(dr["SURTIR"]);
                    }

                }
                else
                {
                    retorno = null;
                }




                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }









        [AutoComplete]
        public DataSet enlistarM_ENCC()
        {

            DataSet retorno;
            try
            {
                retorno = OleDbHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_M_ENCC_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoM_ENCC()
        {
            DataSet retorno;
            try
            {

                retorno = OleDbHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_M_ENCC_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteM_ENCC(CM_ENCCBE oCM_ENCC, OleDbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@PROVEEDOR", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.IPROVEEDOR;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.INOMBRE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOMBRE2", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.INOMBRE2;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SALDO", OleDbType.Double);
                auxPar.Value = oCM_ENCC.ISALDO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SALDO_VENC", OleDbType.Double);
                auxPar.Value = oCM_ENCC.ISALDO_VENC;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@C_VENCIDAS", OleDbType.Double);
                auxPar.Value = oCM_ENCC.IC_VENCIDAS;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CALLE", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.ICALLE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COLONIA", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.ICOLONIA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CIUDAD", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.ICIUDAD;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESTADO", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.IESTADO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CP", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.ICP;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TEL1", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.ITEL1;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TEL2", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.ITEL2;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CONTACTO", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.ICONTACTO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CONTACTO2", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.ICONTACTO2;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TIPO", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.ITIPO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@EMAIL", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.IEMAIL;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DIAS", OleDbType.Double);
                auxPar.Value = oCM_ENCC.IDIAS;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CREDITO", OleDbType.Double);
                auxPar.Value = oCM_ENCC.ICREDITO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ALTA", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.IALTA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COMPRADOR", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.ICOMPRADOR;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@T_ENT", OleDbType.Double);
                auxPar.Value = oCM_ENCC.IT_ENT;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ULT_COMPRA", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.IULT_COMPRA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@UC_CANT", OleDbType.Double);
                auxPar.Value = oCM_ENCC.IUC_CANT;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COM_PERIO", OleDbType.Double);
                auxPar.Value = oCM_ENCC.ICOM_PERIO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@VAL_PERIO", OleDbType.Double);
                auxPar.Value = oCM_ENCC.IVAL_PERIO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COM_ACUM", OleDbType.Double);
                auxPar.Value = oCM_ENCC.ICOM_ACUM;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@VAL_ACUM", OleDbType.Double);
                auxPar.Value = oCM_ENCC.IVAL_ACUM;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@BLOQUEADO", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.IBLOQUEADO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@BLOQUEONOT", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.IBLOQUEONOT;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@RFC", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.IRFC;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FALTANTE", OleDbType.Double);
                auxPar.Value = oCM_ENCC.IFALTANTE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@X_RECIBIR", OleDbType.Double);
                auxPar.Value = oCM_ENCC.IX_RECIBIR;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SOBRANTE", OleDbType.Double);
                auxPar.Value = oCM_ENCC.ISOBRANTE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@EXISTENCIA", OleDbType.Double);
                auxPar.Value = oCM_ENCC.IEXISTENCIA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Double);
                auxPar.Value = oCM_ENCC.ICANTIDAD;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPORTE", OleDbType.Double);
                auxPar.Value = oCM_ENCC.IIMPORTE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PASSWORD", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.IPASSWORD;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.IID;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.IID_FECHA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.IID_HORA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SURTIR", OleDbType.VarChar);
                auxPar.Value = oCM_ENCC.ISURTIR;
                parts.Add(auxPar);

                OleDbParameter[] arParms = new OleDbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from M_ENCC where

  PROVEEDOR=@PROVEEDOR    and

  NOMBRE=@NOMBRE    and

  NOMBRE2=@NOMBRE2    and

  SALDO=@SALDO    and

  SALDO_VENC=@SALDO_VENC    and

  C_VENCIDAS=@C_VENCIDAS    and

  CALLE=@CALLE    and

  COLONIA=@COLONIA    and

  CIUDAD=@CIUDAD    and

  ESTADO=@ESTADO    and

  CP=@CP    and

  TEL1=@TEL1    and

  TEL2=@TEL2    and

  CONTACTO=@CONTACTO    and

  CONTACTO2=@CONTACTO2    and

  TIPO=@TIPO    and

  EMAIL=@EMAIL    and

  DIAS=@DIAS    and

  CREDITO=@CREDITO    and

  ALTA=@ALTA    and

  COMPRADOR=@COMPRADOR    and

  T_ENT=@T_ENT    and

  ULT_COMPRA=@ULT_COMPRA    and

  UC_CANT=@UC_CANT    and

  COM_PERIO=@COM_PERIO    and

  VAL_PERIO=@VAL_PERIO    and

  COM_ACUM=@COM_ACUM    and

  VAL_ACUM=@VAL_ACUM    and

  BLOQUEADO=@BLOQUEADO    and

  BLOQUEONOT=@BLOQUEONOT    and

  RFC=@RFC    and

  FALTANTE=@FALTANTE    and

  X_RECIBIR=@X_RECIBIR    and

  SOBRANTE=@SOBRANTE    and

  EXISTENCIA=@EXISTENCIA    and

  CANTIDAD=@CANTIDAD    and

  IMPORTE=@IMPORTE    and

  PASSWORD=@PASSWORD    and

  ID=@ID    and

  ID_FECHA=@ID_FECHA    and

  ID_HORA=@ID_HORA    and

  SURTIR=@SURTIR  
  );";






                OleDbDataReader dr;
                if (st == null)
                    dr = OleDbHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    dr = OleDbHelper.ExecuteReader(st, CommandType.Text, commandText, arParms);



                if (dr.Read())
                {
                    retorno = 1;
                }
                else
                {
                    retorno = 0;
                }

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return -1;
            }
        }




        public CM_ENCCBE AgregarM_ENCC(CM_ENCCBE oCM_ENCC, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteM_ENCC(oCM_ENCC, st);
                if (iRes == 1)
                {
                    this.IComentario = "El M_ENCC ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return null;//AgregarM_ENCCD(oCM_ENCC, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarM_ENCC(CM_ENCCBE oCM_ENCC, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteM_ENCC(oCM_ENCC, st);
                if (iRes == 0)
                {
                    this.IComentario = "El M_ENCC no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarM_ENCCD(oCM_ENCC, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarM_ENCC(CM_ENCCBE oCM_ENCCNuevo, CM_ENCCBE oCM_ENCCAnterior, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteM_ENCC(oCM_ENCCAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El M_ENCC no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarM_ENCCD(oCM_ENCCNuevo, oCM_ENCCAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CM_ENCCD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
