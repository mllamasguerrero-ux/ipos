
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


    public class CM_PROVD : IMPROVD
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
        public bool AgregarM_PROVD(CM_PROVBE oCM_PROV, string strFileName, 
                                /*OleDbTransaction st,*/ 
                                string strOleDbConn)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@PROVEEDOR", OleDbType.VarChar);
                if (!(bool)oCM_PROV.isnull["IPROVEEDOR"])
                {
                    auxPar.Value = oCM_PROV.IPROVEEDOR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                if (!(bool)oCM_PROV.isnull["INOMBRE"])
                {
                    auxPar.Value = oCM_PROV.INOMBRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOMBRE2", OleDbType.VarChar);
                if (!(bool)oCM_PROV.isnull["INOMBRE2"])
                {
                    auxPar.Value = oCM_PROV.INOMBRE2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SALDO", OleDbType.Double);
                if (!(bool)oCM_PROV.isnull["ISALDO"])
                {
                    auxPar.Value = oCM_PROV.ISALDO;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SALDO_VENC", OleDbType.Double);
                if (!(bool)oCM_PROV.isnull["ISALDO_VENC"])
                {
                    auxPar.Value = oCM_PROV.ISALDO_VENC;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@C_VENCIDAS", OleDbType.Double);
                if (!(bool)oCM_PROV.isnull["IC_VENCIDAS"])
                {
                    auxPar.Value = oCM_PROV.IC_VENCIDAS;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CALLE", OleDbType.VarChar);
                if (!(bool)oCM_PROV.isnull["ICALLE"])
                {
                    auxPar.Value = oCM_PROV.ICALLE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COLONIA", OleDbType.VarChar);
                if (!(bool)oCM_PROV.isnull["ICOLONIA"])
                {
                    auxPar.Value = oCM_PROV.ICOLONIA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CIUDAD", OleDbType.VarChar);
                if (!(bool)oCM_PROV.isnull["ICIUDAD"])
                {
                    auxPar.Value = oCM_PROV.ICIUDAD;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESTADO", OleDbType.VarChar);
                if (!(bool)oCM_PROV.isnull["IESTADO"])
                {
                    auxPar.Value = oCM_PROV.IESTADO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CP", OleDbType.VarChar);
                if (!(bool)oCM_PROV.isnull["ICP"])
                {
                    auxPar.Value = oCM_PROV.ICP;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TEL1", OleDbType.VarChar);
                if (!(bool)oCM_PROV.isnull["ITEL1"])
                {
                    auxPar.Value = oCM_PROV.ITEL1;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TEL2", OleDbType.VarChar);
                if (!(bool)oCM_PROV.isnull["ITEL2"])
                {
                    auxPar.Value = oCM_PROV.ITEL2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CONTACTO", OleDbType.VarChar);
                if (!(bool)oCM_PROV.isnull["ICONTACTO"])
                {
                    auxPar.Value = oCM_PROV.ICONTACTO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CONTACTO2", OleDbType.VarChar);
                if (!(bool)oCM_PROV.isnull["ICONTACTO2"])
                {
                    auxPar.Value = oCM_PROV.ICONTACTO2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TIPO", OleDbType.VarChar);
                if (!(bool)oCM_PROV.isnull["ITIPO"])
                {
                    auxPar.Value = oCM_PROV.ITIPO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@EMAIL", OleDbType.VarChar);
                if (!(bool)oCM_PROV.isnull["IEMAIL"])
                {
                    auxPar.Value = oCM_PROV.IEMAIL;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DIAS", OleDbType.Double);
                if (!(bool)oCM_PROV.isnull["IDIAS"])
                {
                    auxPar.Value = oCM_PROV.IDIAS;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);




                auxPar = new OleDbParameter("@ALTA", OleDbType.Date);
                if (!(bool)oCM_PROV.isnull["IALTA"])
                {
                    auxPar.Value = oCM_PROV.IALTA;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COMPRADOR", OleDbType.VarChar);
                if (!(bool)oCM_PROV.isnull["ICOMPRADOR"])
                {
                    auxPar.Value = oCM_PROV.ICOMPRADOR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@T_ENT", OleDbType.Double);
                if (!(bool)oCM_PROV.isnull["IT_ENT"])
                {
                    auxPar.Value = oCM_PROV.IT_ENT;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ULT_COMPRA", OleDbType.Date);
                if (!(bool)oCM_PROV.isnull["IULT_COMPRA"])
                {
                    auxPar.Value = oCM_PROV.IULT_COMPRA;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@UC_CANT", OleDbType.Double);
                if (!(bool)oCM_PROV.isnull["IUC_CANT"])
                {
                    auxPar.Value = oCM_PROV.IUC_CANT;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COM_PERIO", OleDbType.Double);
                if (!(bool)oCM_PROV.isnull["ICOM_PERIO"])
                {
                    auxPar.Value = oCM_PROV.ICOM_PERIO;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@VAL_PERIO", OleDbType.Double);
                if (!(bool)oCM_PROV.isnull["IVAL_PERIO"])
                {
                    auxPar.Value = oCM_PROV.IVAL_PERIO;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COM_ACUM", OleDbType.Double);
                if (!(bool)oCM_PROV.isnull["ICOM_ACUM"])
                {
                    auxPar.Value = oCM_PROV.ICOM_ACUM;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@VAL_ACUM", OleDbType.Double);
                if (!(bool)oCM_PROV.isnull["IVAL_ACUM"])
                {
                    auxPar.Value = oCM_PROV.IVAL_ACUM;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@BLOQUEADO", OleDbType.VarChar);
                if (!(bool)oCM_PROV.isnull["IBLOQUEADO"])
                {
                    auxPar.Value = oCM_PROV.IBLOQUEADO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@BLOQUEONOT", OleDbType.VarChar);
                if (!(bool)oCM_PROV.isnull["IBLOQUEONOT"])
                {
                    auxPar.Value = oCM_PROV.IBLOQUEONOT;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@RFC", OleDbType.VarChar);
                if (!(bool)oCM_PROV.isnull["IRFC"])
                {
                    auxPar.Value = oCM_PROV.IRFC;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FALTANTE", OleDbType.Double);
                if (!(bool)oCM_PROV.isnull["IFALTANTE"])
                {
                    auxPar.Value = oCM_PROV.IFALTANTE;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@X_RECIBIR", OleDbType.Double);
                if (!(bool)oCM_PROV.isnull["IX_RECIBIR"])
                {
                    auxPar.Value = oCM_PROV.IX_RECIBIR;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SOBRANTE", OleDbType.Double);
                if (!(bool)oCM_PROV.isnull["ISOBRANTE"])
                {
                    auxPar.Value = oCM_PROV.ISOBRANTE;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@EXISTENCIA", OleDbType.Double);
                if (!(bool)oCM_PROV.isnull["IEXISTENCIA"])
                {
                    auxPar.Value = oCM_PROV.IEXISTENCIA;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Double);
                if (!(bool)oCM_PROV.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCM_PROV.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPORTE", OleDbType.Double);
                if (!(bool)oCM_PROV.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCM_PROV.IIMPORTE;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PASSWORD", OleDbType.VarChar);
                if (!(bool)oCM_PROV.isnull["IPASSWORD"])
                {
                    auxPar.Value = oCM_PROV.IPASSWORD;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCM_PROV.isnull["IID"])
                {
                    auxPar.Value = oCM_PROV.IID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCM_PROV.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_PROV.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCM_PROV.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_PROV.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SURTIR", OleDbType.VarChar);
                if (!(bool)oCM_PROV.isnull["ISURTIR"])
                {
                    auxPar.Value = oCM_PROV.ISURTIR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ADESCPES", OleDbType.Double);
                if (!(bool)oCM_PROV.isnull["IADESCPES"])
                {
                    auxPar.Value = oCM_PROV.IADESCPES;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);




                string commandText = @"
        INSERT INTO M_PROV
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


        [AutoComplete]
        public bool BorrarM_PROVD(CM_PROVBE oCM_PROV, OleDbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@PROVEEDOR", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.IPROVEEDOR;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.INOMBRE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOMBRE2", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.INOMBRE2;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SALDO", OleDbType.Double);
                auxPar.Value = oCM_PROV.ISALDO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SALDO_VENC", OleDbType.Double);
                auxPar.Value = oCM_PROV.ISALDO_VENC;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@C_VENCIDAS", OleDbType.Double);
                auxPar.Value = oCM_PROV.IC_VENCIDAS;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CALLE", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.ICALLE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COLONIA", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.ICOLONIA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CIUDAD", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.ICIUDAD;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESTADO", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.IESTADO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CP", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.ICP;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TEL1", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.ITEL1;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TEL2", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.ITEL2;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CONTACTO", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.ICONTACTO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CONTACTO2", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.ICONTACTO2;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TIPO", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.ITIPO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@EMAIL", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.IEMAIL;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DIAS", OleDbType.Double);
                auxPar.Value = oCM_PROV.IDIAS;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CREDITO", OleDbType.Double);
                auxPar.Value = oCM_PROV.ICREDITO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ALTA", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.IALTA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COMPRADOR", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.ICOMPRADOR;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@T_ENT", OleDbType.Double);
                auxPar.Value = oCM_PROV.IT_ENT;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ULT_COMPRA", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.IULT_COMPRA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@UC_CANT", OleDbType.Double);
                auxPar.Value = oCM_PROV.IUC_CANT;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COM_PERIO", OleDbType.Double);
                auxPar.Value = oCM_PROV.ICOM_PERIO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@VAL_PERIO", OleDbType.Double);
                auxPar.Value = oCM_PROV.IVAL_PERIO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COM_ACUM", OleDbType.Double);
                auxPar.Value = oCM_PROV.ICOM_ACUM;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@VAL_ACUM", OleDbType.Double);
                auxPar.Value = oCM_PROV.IVAL_ACUM;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@BLOQUEADO", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.IBLOQUEADO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@BLOQUEONOT", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.IBLOQUEONOT;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@RFC", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.IRFC;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FALTANTE", OleDbType.Double);
                auxPar.Value = oCM_PROV.IFALTANTE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@X_RECIBIR", OleDbType.Double);
                auxPar.Value = oCM_PROV.IX_RECIBIR;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SOBRANTE", OleDbType.Double);
                auxPar.Value = oCM_PROV.ISOBRANTE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@EXISTENCIA", OleDbType.Double);
                auxPar.Value = oCM_PROV.IEXISTENCIA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Double);
                auxPar.Value = oCM_PROV.ICANTIDAD;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPORTE", OleDbType.Double);
                auxPar.Value = oCM_PROV.IIMPORTE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PASSWORD", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.IPASSWORD;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.IID;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                auxPar.Value = oCM_PROV.IID_FECHA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.IID_HORA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SURTIR", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.ISURTIR;
                parts.Add(auxPar);



                string commandText = @"  Delete from M_PROV
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
        public bool CambiarM_PROVD(CM_PROVBE oCM_PROVNuevo, CM_PROVBE oCM_PROVAnterior, OleDbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@PROVEEDOR", OleDbType.VarChar);
                if (!(bool)oCM_PROVNuevo.isnull["IPROVEEDOR"])
                {
                    auxPar.Value = oCM_PROVNuevo.IPROVEEDOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                if (!(bool)oCM_PROVNuevo.isnull["INOMBRE"])
                {
                    auxPar.Value = oCM_PROVNuevo.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@NOMBRE2", OleDbType.VarChar);
                if (!(bool)oCM_PROVNuevo.isnull["INOMBRE2"])
                {
                    auxPar.Value = oCM_PROVNuevo.INOMBRE2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@SALDO", OleDbType.Double);
                if (!(bool)oCM_PROVNuevo.isnull["ISALDO"])
                {
                    auxPar.Value = oCM_PROVNuevo.ISALDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@SALDO_VENC", OleDbType.Double);
                if (!(bool)oCM_PROVNuevo.isnull["ISALDO_VENC"])
                {
                    auxPar.Value = oCM_PROVNuevo.ISALDO_VENC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@C_VENCIDAS", OleDbType.Double);
                if (!(bool)oCM_PROVNuevo.isnull["IC_VENCIDAS"])
                {
                    auxPar.Value = oCM_PROVNuevo.IC_VENCIDAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CALLE", OleDbType.VarChar);
                if (!(bool)oCM_PROVNuevo.isnull["ICALLE"])
                {
                    auxPar.Value = oCM_PROVNuevo.ICALLE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COLONIA", OleDbType.VarChar);
                if (!(bool)oCM_PROVNuevo.isnull["ICOLONIA"])
                {
                    auxPar.Value = oCM_PROVNuevo.ICOLONIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CIUDAD", OleDbType.VarChar);
                if (!(bool)oCM_PROVNuevo.isnull["ICIUDAD"])
                {
                    auxPar.Value = oCM_PROVNuevo.ICIUDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ESTADO", OleDbType.VarChar);
                if (!(bool)oCM_PROVNuevo.isnull["IESTADO"])
                {
                    auxPar.Value = oCM_PROVNuevo.IESTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CP", OleDbType.VarChar);
                if (!(bool)oCM_PROVNuevo.isnull["ICP"])
                {
                    auxPar.Value = oCM_PROVNuevo.ICP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TEL1", OleDbType.VarChar);
                if (!(bool)oCM_PROVNuevo.isnull["ITEL1"])
                {
                    auxPar.Value = oCM_PROVNuevo.ITEL1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TEL2", OleDbType.VarChar);
                if (!(bool)oCM_PROVNuevo.isnull["ITEL2"])
                {
                    auxPar.Value = oCM_PROVNuevo.ITEL2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CONTACTO", OleDbType.VarChar);
                if (!(bool)oCM_PROVNuevo.isnull["ICONTACTO"])
                {
                    auxPar.Value = oCM_PROVNuevo.ICONTACTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CONTACTO2", OleDbType.VarChar);
                if (!(bool)oCM_PROVNuevo.isnull["ICONTACTO2"])
                {
                    auxPar.Value = oCM_PROVNuevo.ICONTACTO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TIPO", OleDbType.VarChar);
                if (!(bool)oCM_PROVNuevo.isnull["ITIPO"])
                {
                    auxPar.Value = oCM_PROVNuevo.ITIPO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@EMAIL", OleDbType.VarChar);
                if (!(bool)oCM_PROVNuevo.isnull["IEMAIL"])
                {
                    auxPar.Value = oCM_PROVNuevo.IEMAIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@DIAS", OleDbType.Double);
                if (!(bool)oCM_PROVNuevo.isnull["IDIAS"])
                {
                    auxPar.Value = oCM_PROVNuevo.IDIAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CREDITO", OleDbType.Double);
                if (!(bool)oCM_PROVNuevo.isnull["ICREDITO"])
                {
                    auxPar.Value = oCM_PROVNuevo.ICREDITO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ALTA", OleDbType.VarChar);
                if (!(bool)oCM_PROVNuevo.isnull["IALTA"])
                {
                    auxPar.Value = oCM_PROVNuevo.IALTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COMPRADOR", OleDbType.VarChar);
                if (!(bool)oCM_PROVNuevo.isnull["ICOMPRADOR"])
                {
                    auxPar.Value = oCM_PROVNuevo.ICOMPRADOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@T_ENT", OleDbType.Double);
                if (!(bool)oCM_PROVNuevo.isnull["IT_ENT"])
                {
                    auxPar.Value = oCM_PROVNuevo.IT_ENT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ULT_COMPRA", OleDbType.VarChar);
                if (!(bool)oCM_PROVNuevo.isnull["IULT_COMPRA"])
                {
                    auxPar.Value = oCM_PROVNuevo.IULT_COMPRA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@UC_CANT", OleDbType.Double);
                if (!(bool)oCM_PROVNuevo.isnull["IUC_CANT"])
                {
                    auxPar.Value = oCM_PROVNuevo.IUC_CANT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COM_PERIO", OleDbType.Double);
                if (!(bool)oCM_PROVNuevo.isnull["ICOM_PERIO"])
                {
                    auxPar.Value = oCM_PROVNuevo.ICOM_PERIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@VAL_PERIO", OleDbType.Double);
                if (!(bool)oCM_PROVNuevo.isnull["IVAL_PERIO"])
                {
                    auxPar.Value = oCM_PROVNuevo.IVAL_PERIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COM_ACUM", OleDbType.Double);
                if (!(bool)oCM_PROVNuevo.isnull["ICOM_ACUM"])
                {
                    auxPar.Value = oCM_PROVNuevo.ICOM_ACUM;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@VAL_ACUM", OleDbType.Double);
                if (!(bool)oCM_PROVNuevo.isnull["IVAL_ACUM"])
                {
                    auxPar.Value = oCM_PROVNuevo.IVAL_ACUM;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@BLOQUEADO", OleDbType.VarChar);
                if (!(bool)oCM_PROVNuevo.isnull["IBLOQUEADO"])
                {
                    auxPar.Value = oCM_PROVNuevo.IBLOQUEADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@BLOQUEONOT", OleDbType.VarChar);
                if (!(bool)oCM_PROVNuevo.isnull["IBLOQUEONOT"])
                {
                    auxPar.Value = oCM_PROVNuevo.IBLOQUEONOT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@RFC", OleDbType.VarChar);
                if (!(bool)oCM_PROVNuevo.isnull["IRFC"])
                {
                    auxPar.Value = oCM_PROVNuevo.IRFC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@FALTANTE", OleDbType.Double);
                if (!(bool)oCM_PROVNuevo.isnull["IFALTANTE"])
                {
                    auxPar.Value = oCM_PROVNuevo.IFALTANTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@X_RECIBIR", OleDbType.Double);
                if (!(bool)oCM_PROVNuevo.isnull["IX_RECIBIR"])
                {
                    auxPar.Value = oCM_PROVNuevo.IX_RECIBIR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@SOBRANTE", OleDbType.Double);
                if (!(bool)oCM_PROVNuevo.isnull["ISOBRANTE"])
                {
                    auxPar.Value = oCM_PROVNuevo.ISOBRANTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@EXISTENCIA", OleDbType.Double);
                if (!(bool)oCM_PROVNuevo.isnull["IEXISTENCIA"])
                {
                    auxPar.Value = oCM_PROVNuevo.IEXISTENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Double);
                if (!(bool)oCM_PROVNuevo.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCM_PROVNuevo.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@IMPORTE", OleDbType.Double);
                if (!(bool)oCM_PROVNuevo.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCM_PROVNuevo.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PASSWORD", OleDbType.VarChar);
                if (!(bool)oCM_PROVNuevo.isnull["IPASSWORD"])
                {
                    auxPar.Value = oCM_PROVNuevo.IPASSWORD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCM_PROVNuevo.isnull["IID"])
                {
                    auxPar.Value = oCM_PROVNuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCM_PROVNuevo.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_PROVNuevo.IID_FECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCM_PROVNuevo.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_PROVNuevo.IID_HORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@SURTIR", OleDbType.VarChar);
                if (!(bool)oCM_PROVNuevo.isnull["ISURTIR"])
                {
                    auxPar.Value = oCM_PROVNuevo.ISURTIR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PROVEEDORAnt", OleDbType.VarChar);
                if (!(bool)oCM_PROVAnterior.isnull["IPROVEEDOR"])
                {
                    auxPar.Value = oCM_PROVAnterior.IPROVEEDOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@NOMBREAnt", OleDbType.VarChar);
                if (!(bool)oCM_PROVAnterior.isnull["INOMBRE"])
                {
                    auxPar.Value = oCM_PROVAnterior.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@NOMBRE2Ant", OleDbType.VarChar);
                if (!(bool)oCM_PROVAnterior.isnull["INOMBRE2"])
                {
                    auxPar.Value = oCM_PROVAnterior.INOMBRE2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@SALDOAnt", OleDbType.Double);
                if (!(bool)oCM_PROVAnterior.isnull["ISALDO"])
                {
                    auxPar.Value = oCM_PROVAnterior.ISALDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@SALDO_VENCAnt", OleDbType.Double);
                if (!(bool)oCM_PROVAnterior.isnull["ISALDO_VENC"])
                {
                    auxPar.Value = oCM_PROVAnterior.ISALDO_VENC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@C_VENCIDASAnt", OleDbType.Double);
                if (!(bool)oCM_PROVAnterior.isnull["IC_VENCIDAS"])
                {
                    auxPar.Value = oCM_PROVAnterior.IC_VENCIDAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CALLEAnt", OleDbType.VarChar);
                if (!(bool)oCM_PROVAnterior.isnull["ICALLE"])
                {
                    auxPar.Value = oCM_PROVAnterior.ICALLE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COLONIAAnt", OleDbType.VarChar);
                if (!(bool)oCM_PROVAnterior.isnull["ICOLONIA"])
                {
                    auxPar.Value = oCM_PROVAnterior.ICOLONIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CIUDADAnt", OleDbType.VarChar);
                if (!(bool)oCM_PROVAnterior.isnull["ICIUDAD"])
                {
                    auxPar.Value = oCM_PROVAnterior.ICIUDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ESTADOAnt", OleDbType.VarChar);
                if (!(bool)oCM_PROVAnterior.isnull["IESTADO"])
                {
                    auxPar.Value = oCM_PROVAnterior.IESTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CPAnt", OleDbType.VarChar);
                if (!(bool)oCM_PROVAnterior.isnull["ICP"])
                {
                    auxPar.Value = oCM_PROVAnterior.ICP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TEL1Ant", OleDbType.VarChar);
                if (!(bool)oCM_PROVAnterior.isnull["ITEL1"])
                {
                    auxPar.Value = oCM_PROVAnterior.ITEL1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TEL2Ant", OleDbType.VarChar);
                if (!(bool)oCM_PROVAnterior.isnull["ITEL2"])
                {
                    auxPar.Value = oCM_PROVAnterior.ITEL2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CONTACTOAnt", OleDbType.VarChar);
                if (!(bool)oCM_PROVAnterior.isnull["ICONTACTO"])
                {
                    auxPar.Value = oCM_PROVAnterior.ICONTACTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CONTACTO2Ant", OleDbType.VarChar);
                if (!(bool)oCM_PROVAnterior.isnull["ICONTACTO2"])
                {
                    auxPar.Value = oCM_PROVAnterior.ICONTACTO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TIPOAnt", OleDbType.VarChar);
                if (!(bool)oCM_PROVAnterior.isnull["ITIPO"])
                {
                    auxPar.Value = oCM_PROVAnterior.ITIPO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@EMAILAnt", OleDbType.VarChar);
                if (!(bool)oCM_PROVAnterior.isnull["IEMAIL"])
                {
                    auxPar.Value = oCM_PROVAnterior.IEMAIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@DIASAnt", OleDbType.Double);
                if (!(bool)oCM_PROVAnterior.isnull["IDIAS"])
                {
                    auxPar.Value = oCM_PROVAnterior.IDIAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CREDITOAnt", OleDbType.Double);
                if (!(bool)oCM_PROVAnterior.isnull["ICREDITO"])
                {
                    auxPar.Value = oCM_PROVAnterior.ICREDITO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ALTAAnt", OleDbType.VarChar);
                if (!(bool)oCM_PROVAnterior.isnull["IALTA"])
                {
                    auxPar.Value = oCM_PROVAnterior.IALTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COMPRADORAnt", OleDbType.VarChar);
                if (!(bool)oCM_PROVAnterior.isnull["ICOMPRADOR"])
                {
                    auxPar.Value = oCM_PROVAnterior.ICOMPRADOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@T_ENTAnt", OleDbType.Double);
                if (!(bool)oCM_PROVAnterior.isnull["IT_ENT"])
                {
                    auxPar.Value = oCM_PROVAnterior.IT_ENT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ULT_COMPRAAnt", OleDbType.VarChar);
                if (!(bool)oCM_PROVAnterior.isnull["IULT_COMPRA"])
                {
                    auxPar.Value = oCM_PROVAnterior.IULT_COMPRA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@UC_CANTAnt", OleDbType.Double);
                if (!(bool)oCM_PROVAnterior.isnull["IUC_CANT"])
                {
                    auxPar.Value = oCM_PROVAnterior.IUC_CANT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COM_PERIOAnt", OleDbType.Double);
                if (!(bool)oCM_PROVAnterior.isnull["ICOM_PERIO"])
                {
                    auxPar.Value = oCM_PROVAnterior.ICOM_PERIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@VAL_PERIOAnt", OleDbType.Double);
                if (!(bool)oCM_PROVAnterior.isnull["IVAL_PERIO"])
                {
                    auxPar.Value = oCM_PROVAnterior.IVAL_PERIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COM_ACUMAnt", OleDbType.Double);
                if (!(bool)oCM_PROVAnterior.isnull["ICOM_ACUM"])
                {
                    auxPar.Value = oCM_PROVAnterior.ICOM_ACUM;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@VAL_ACUMAnt", OleDbType.Double);
                if (!(bool)oCM_PROVAnterior.isnull["IVAL_ACUM"])
                {
                    auxPar.Value = oCM_PROVAnterior.IVAL_ACUM;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@BLOQUEADOAnt", OleDbType.VarChar);
                if (!(bool)oCM_PROVAnterior.isnull["IBLOQUEADO"])
                {
                    auxPar.Value = oCM_PROVAnterior.IBLOQUEADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@BLOQUEONOTAnt", OleDbType.VarChar);
                if (!(bool)oCM_PROVAnterior.isnull["IBLOQUEONOT"])
                {
                    auxPar.Value = oCM_PROVAnterior.IBLOQUEONOT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@RFCAnt", OleDbType.VarChar);
                if (!(bool)oCM_PROVAnterior.isnull["IRFC"])
                {
                    auxPar.Value = oCM_PROVAnterior.IRFC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@FALTANTEAnt", OleDbType.Double);
                if (!(bool)oCM_PROVAnterior.isnull["IFALTANTE"])
                {
                    auxPar.Value = oCM_PROVAnterior.IFALTANTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@X_RECIBIRAnt", OleDbType.Double);
                if (!(bool)oCM_PROVAnterior.isnull["IX_RECIBIR"])
                {
                    auxPar.Value = oCM_PROVAnterior.IX_RECIBIR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@SOBRANTEAnt", OleDbType.Double);
                if (!(bool)oCM_PROVAnterior.isnull["ISOBRANTE"])
                {
                    auxPar.Value = oCM_PROVAnterior.ISOBRANTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@EXISTENCIAAnt", OleDbType.Double);
                if (!(bool)oCM_PROVAnterior.isnull["IEXISTENCIA"])
                {
                    auxPar.Value = oCM_PROVAnterior.IEXISTENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CANTIDADAnt", OleDbType.Double);
                if (!(bool)oCM_PROVAnterior.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCM_PROVAnterior.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@IMPORTEAnt", OleDbType.Double);
                if (!(bool)oCM_PROVAnterior.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCM_PROVAnterior.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PASSWORDAnt", OleDbType.VarChar);
                if (!(bool)oCM_PROVAnterior.isnull["IPASSWORD"])
                {
                    auxPar.Value = oCM_PROVAnterior.IPASSWORD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@IDAnt", OleDbType.VarChar);
                if (!(bool)oCM_PROVAnterior.isnull["IID"])
                {
                    auxPar.Value = oCM_PROVAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_FECHAAnt", OleDbType.Date);
                if (!(bool)oCM_PROVAnterior.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_PROVAnterior.IID_FECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_HORAAnt", OleDbType.VarChar);
                if (!(bool)oCM_PROVAnterior.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_PROVAnterior.IID_HORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@SURTIRAnt", OleDbType.VarChar);
                if (!(bool)oCM_PROVAnterior.isnull["ISURTIR"])
                {
                    auxPar.Value = oCM_PROVAnterior.ISURTIR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  M_PROV
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
        public CM_PROVBE seleccionarM_PROV(CM_PROVBE oCM_PROV, OleDbTransaction st)
        {




            CM_PROVBE retorno = new CM_PROVBE();

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;

                String CmdTxt = @"select * from M_PROV where
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
                auxPar.Value = oCM_PROV.IPROVEEDOR;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.INOMBRE;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@NOMBRE2", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.INOMBRE2;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@SALDO", OleDbType.Double);
                auxPar.Value = oCM_PROV.ISALDO;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@SALDO_VENC", OleDbType.Double);
                auxPar.Value = oCM_PROV.ISALDO_VENC;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@C_VENCIDAS", OleDbType.Double);
                auxPar.Value = oCM_PROV.IC_VENCIDAS;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@CALLE", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.ICALLE;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@COLONIA", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.ICOLONIA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@CIUDAD", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.ICIUDAD;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ESTADO", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.IESTADO;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@CP", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.ICP;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@TEL1", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.ITEL1;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@TEL2", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.ITEL2;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@CONTACTO", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.ICONTACTO;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@CONTACTO2", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.ICONTACTO2;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@TIPO", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.ITIPO;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@EMAIL", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.IEMAIL;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@DIAS", OleDbType.Double);
                auxPar.Value = oCM_PROV.IDIAS;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@CREDITO", OleDbType.Double);
                auxPar.Value = oCM_PROV.ICREDITO;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ALTA", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.IALTA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@COMPRADOR", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.ICOMPRADOR;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@T_ENT", OleDbType.Double);
                auxPar.Value = oCM_PROV.IT_ENT;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ULT_COMPRA", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.IULT_COMPRA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@UC_CANT", OleDbType.Double);
                auxPar.Value = oCM_PROV.IUC_CANT;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@COM_PERIO", OleDbType.Double);
                auxPar.Value = oCM_PROV.ICOM_PERIO;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@VAL_PERIO", OleDbType.Double);
                auxPar.Value = oCM_PROV.IVAL_PERIO;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@COM_ACUM", OleDbType.Double);
                auxPar.Value = oCM_PROV.ICOM_ACUM;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@VAL_ACUM", OleDbType.Double);
                auxPar.Value = oCM_PROV.IVAL_ACUM;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@BLOQUEADO", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.IBLOQUEADO;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@BLOQUEONOT", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.IBLOQUEONOT;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@RFC", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.IRFC;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@FALTANTE", OleDbType.Double);
                auxPar.Value = oCM_PROV.IFALTANTE;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@X_RECIBIR", OleDbType.Double);
                auxPar.Value = oCM_PROV.IX_RECIBIR;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@SOBRANTE", OleDbType.Double);
                auxPar.Value = oCM_PROV.ISOBRANTE;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@EXISTENCIA", OleDbType.Double);
                auxPar.Value = oCM_PROV.IEXISTENCIA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Double);
                auxPar.Value = oCM_PROV.ICANTIDAD;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@IMPORTE", OleDbType.Double);
                auxPar.Value = oCM_PROV.IIMPORTE;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@PASSWORD", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.IPASSWORD;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.IID;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.IID_FECHA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.IID_HORA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@SURTIR", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.ISURTIR;
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
        public DataSet enlistarM_PROV()
        {

            DataSet retorno;
            try
            {
                retorno = OleDbHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_M_PROV_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoM_PROV()
        {
            DataSet retorno;
            try
            {

                retorno = OleDbHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_M_PROV_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteM_PROV(CM_PROVBE oCM_PROV, OleDbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@PROVEEDOR", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.IPROVEEDOR;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.INOMBRE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOMBRE2", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.INOMBRE2;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SALDO", OleDbType.Double);
                auxPar.Value = oCM_PROV.ISALDO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SALDO_VENC", OleDbType.Double);
                auxPar.Value = oCM_PROV.ISALDO_VENC;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@C_VENCIDAS", OleDbType.Double);
                auxPar.Value = oCM_PROV.IC_VENCIDAS;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CALLE", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.ICALLE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COLONIA", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.ICOLONIA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CIUDAD", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.ICIUDAD;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESTADO", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.IESTADO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CP", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.ICP;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TEL1", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.ITEL1;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TEL2", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.ITEL2;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CONTACTO", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.ICONTACTO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CONTACTO2", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.ICONTACTO2;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TIPO", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.ITIPO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@EMAIL", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.IEMAIL;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DIAS", OleDbType.Double);
                auxPar.Value = oCM_PROV.IDIAS;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CREDITO", OleDbType.Double);
                auxPar.Value = oCM_PROV.ICREDITO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ALTA", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.IALTA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COMPRADOR", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.ICOMPRADOR;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@T_ENT", OleDbType.Double);
                auxPar.Value = oCM_PROV.IT_ENT;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ULT_COMPRA", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.IULT_COMPRA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@UC_CANT", OleDbType.Double);
                auxPar.Value = oCM_PROV.IUC_CANT;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COM_PERIO", OleDbType.Double);
                auxPar.Value = oCM_PROV.ICOM_PERIO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@VAL_PERIO", OleDbType.Double);
                auxPar.Value = oCM_PROV.IVAL_PERIO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COM_ACUM", OleDbType.Double);
                auxPar.Value = oCM_PROV.ICOM_ACUM;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@VAL_ACUM", OleDbType.Double);
                auxPar.Value = oCM_PROV.IVAL_ACUM;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@BLOQUEADO", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.IBLOQUEADO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@BLOQUEONOT", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.IBLOQUEONOT;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@RFC", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.IRFC;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FALTANTE", OleDbType.Double);
                auxPar.Value = oCM_PROV.IFALTANTE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@X_RECIBIR", OleDbType.Double);
                auxPar.Value = oCM_PROV.IX_RECIBIR;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SOBRANTE", OleDbType.Double);
                auxPar.Value = oCM_PROV.ISOBRANTE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@EXISTENCIA", OleDbType.Double);
                auxPar.Value = oCM_PROV.IEXISTENCIA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Double);
                auxPar.Value = oCM_PROV.ICANTIDAD;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPORTE", OleDbType.Double);
                auxPar.Value = oCM_PROV.IIMPORTE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PASSWORD", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.IPASSWORD;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.IID;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.IID_FECHA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.IID_HORA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SURTIR", OleDbType.VarChar);
                auxPar.Value = oCM_PROV.ISURTIR;
                parts.Add(auxPar);

                OleDbParameter[] arParms = new OleDbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from M_PROV where

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




        public CM_PROVBE AgregarM_PROV(CM_PROVBE oCM_PROV, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteM_PROV(oCM_PROV, st);
                if (iRes == 1)
                {
                    this.IComentario = "El M_PROV ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return null;//AgregarM_PROVD(oCM_PROV, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarM_PROV(CM_PROVBE oCM_PROV, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteM_PROV(oCM_PROV, st);
                if (iRes == 0)
                {
                    this.IComentario = "El M_PROV no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarM_PROVD(oCM_PROV, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarM_PROV(CM_PROVBE oCM_PROVNuevo, CM_PROVBE oCM_PROVAnterior, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteM_PROV(oCM_PROVAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El M_PROV no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarM_PROVD(oCM_PROVNuevo, oCM_PROVAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CM_PROVD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
