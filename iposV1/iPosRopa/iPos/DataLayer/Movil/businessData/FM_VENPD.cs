

using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Collections;
using ConexionesBD;
using System.Collections.Generic;

namespace iPosData
{



    public class FM_VENPD
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


        public FM_VENPBE AgregarM_VENPD(FM_VENPBE oCM_VENP, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@VENTA", FbDbType.VarChar);
                if (!(bool)oCM_VENP.isnull["IVENTA"])
                {
                    auxPar.Value = oCM_VENP.IVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLIENTE", FbDbType.VarChar);
                if (!(bool)oCM_VENP.isnull["ICLIENTE"])
                {
                    auxPar.Value = oCM_VENP.ICLIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTATUS", FbDbType.VarChar);
                if (!(bool)oCM_VENP.isnull["IESTATUS"])
                {
                    auxPar.Value = oCM_VENP.IESTATUS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTATUS2", FbDbType.VarChar);
                if (!(bool)oCM_VENP.isnull["IESTATUS2"])
                {
                    auxPar.Value = oCM_VENP.IESTATUS2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOTA1", FbDbType.VarChar);
                if (!(bool)oCM_VENP.isnull["INOTA1"])
                {
                    auxPar.Value = oCM_VENP.INOTA1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOTA2", FbDbType.VarChar);
                if (!(bool)oCM_VENP.isnull["INOTA2"])
                {
                    auxPar.Value = oCM_VENP.INOTA2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PLAZOS", FbDbType.VarChar);
                if (!(bool)oCM_VENP.isnull["IPLAZOS"])
                {
                    auxPar.Value = oCM_VENP.IPLAZOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUGERIDOS", FbDbType.VarChar);
                if (!(bool)oCM_VENP.isnull["ISUGERIDOS"])
                {
                    auxPar.Value = oCM_VENP.ISUGERIDOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TOTAL", FbDbType.Numeric);
                if (!(bool)oCM_VENP.isnull["ITOTAL"])
                {
                    auxPar.Value = oCM_VENP.ITOTAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@AUTOCRED", FbDbType.VarChar);
                if (!(bool)oCM_VENP.isnull["IAUTOCRED"])
                {
                    auxPar.Value = oCM_VENP.IAUTOCRED;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CONTADO", FbDbType.VarChar);
                if (!(bool)oCM_VENP.isnull["ICONTADO"])
                {
                    auxPar.Value = oCM_VENP.ICONTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PROCESADO", FbDbType.VarChar);
                if (!(bool)oCM_VENP.isnull["IPROCESADO"])
                {
                    auxPar.Value = oCM_VENP.IPROCESADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ID_FECHA", FbDbType.Date);
                if (!(bool)oCM_VENP.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_VENP.IID_FECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ID_HORA", FbDbType.VarChar);
                if (!(bool)oCM_VENP.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_VENP.IID_HORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDCLAVE", FbDbType.VarChar);
                if (!(bool)oCM_VENP.isnull["IVENDCLAVE"])
                {
                    auxPar.Value = oCM_VENP.IVENDCLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO M_VENP
      (
    
VENTA,

CLIENTE,

ESTATUS,

ESTATUS2,

NOTA1,

NOTA2,

PLAZOS,

SUGERIDOS,

TOTAL,

AUTOCRED,

CONTADO,

PROCESADO,

ID_FECHA,

ID_HORA,

VENDCLAVE
         )

Values (

@VENTA,

@CLIENTE,

@ESTATUS,

@ESTATUS2,

@NOTA1,

@NOTA2,

@PLAZOS,

@SUGERIDOS,

@TOTAL,

@AUTOCRED,

@CONTADO,

@PROCESADO,

@ID_FECHA,

@ID_HORA,

@VENDCLAVE
) RETURNING ID; ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                Object result = null;
                

                if (st == null)
                    result = SqlHelper.ExecuteScalar(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    result = SqlHelper.ExecuteScalar(st, CommandType.Text, commandText, arParms);


                oCM_VENP.IID = (long)result;




                return oCM_VENP;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarM_VENPD(FM_VENPBE oCM_VENP, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCM_VENP.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from M_VENP
  where

  ID=@ID
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;




            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public bool CambiarM_VENPD(FM_VENPBE oCM_VENPNuevo, FM_VENPBE oCM_VENPAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@VENTA", FbDbType.VarChar);
                if (!(bool)oCM_VENPNuevo.isnull["IVENTA"])
                {
                    auxPar.Value = oCM_VENPNuevo.IVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLIENTE", FbDbType.VarChar);
                if (!(bool)oCM_VENPNuevo.isnull["ICLIENTE"])
                {
                    auxPar.Value = oCM_VENPNuevo.ICLIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESTATUS", FbDbType.VarChar);
                if (!(bool)oCM_VENPNuevo.isnull["IESTATUS"])
                {
                    auxPar.Value = oCM_VENPNuevo.IESTATUS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESTATUS2", FbDbType.VarChar);
                if (!(bool)oCM_VENPNuevo.isnull["IESTATUS2"])
                {
                    auxPar.Value = oCM_VENPNuevo.IESTATUS2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOTA1", FbDbType.VarChar);
                if (!(bool)oCM_VENPNuevo.isnull["INOTA1"])
                {
                    auxPar.Value = oCM_VENPNuevo.INOTA1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOTA2", FbDbType.VarChar);
                if (!(bool)oCM_VENPNuevo.isnull["INOTA2"])
                {
                    auxPar.Value = oCM_VENPNuevo.INOTA2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PLAZOS", FbDbType.VarChar);
                if (!(bool)oCM_VENPNuevo.isnull["IPLAZOS"])
                {
                    auxPar.Value = oCM_VENPNuevo.IPLAZOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SUGERIDOS", FbDbType.VarChar);
                if (!(bool)oCM_VENPNuevo.isnull["ISUGERIDOS"])
                {
                    auxPar.Value = oCM_VENPNuevo.ISUGERIDOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TOTAL", FbDbType.Numeric);
                if (!(bool)oCM_VENPNuevo.isnull["ITOTAL"])
                {
                    auxPar.Value = oCM_VENPNuevo.ITOTAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@AUTOCRED", FbDbType.VarChar);
                if (!(bool)oCM_VENPNuevo.isnull["IAUTOCRED"])
                {
                    auxPar.Value = oCM_VENPNuevo.IAUTOCRED;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CONTADO", FbDbType.VarChar);
                if (!(bool)oCM_VENPNuevo.isnull["ICONTADO"])
                {
                    auxPar.Value = oCM_VENPNuevo.ICONTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PROCESADO", FbDbType.VarChar);
                if (!(bool)oCM_VENPNuevo.isnull["IPROCESADO"])
                {
                    auxPar.Value = oCM_VENPNuevo.IPROCESADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ID_FECHA", FbDbType.Date);
                if (!(bool)oCM_VENPNuevo.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_VENPNuevo.IID_FECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ID_HORA", FbDbType.VarChar);
                if (!(bool)oCM_VENPNuevo.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_VENPNuevo.IID_HORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@VENDCLAVE", FbDbType.VarChar);
                if (!(bool)oCM_VENPNuevo.isnull["IVENDCLAVE"])
                {
                    auxPar.Value = oCM_VENPNuevo.IVENDCLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCM_VENPAnterior.isnull["IID"])
                {
                    auxPar.Value = oCM_VENPAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  M_VENP
  set

VENTA=@VENTA,

CLIENTE=@CLIENTE,

ESTATUS=@ESTATUS,

ESTATUS2=@ESTATUS2,

NOTA1=@NOTA1,

NOTA2=@NOTA2,

PLAZOS=@PLAZOS,

SUGERIDOS=@SUGERIDOS,

TOTAL=@TOTAL,

AUTOCRED=@AUTOCRED,

CONTADO=@CONTADO,

PROCESADO=@PROCESADO,

ID_FECHA=@ID_FECHA,

ID_HORA=@ID_HORA,

VENDCLAVE=@VENDCLAVE
  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public FM_VENPBE seleccionarM_VENP(FM_VENPBE oCM_VENP, FbTransaction st)
        {




            FM_VENPBE retorno = new FM_VENPBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from M_VENP where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCM_VENP.IID;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["VENTA"] != System.DBNull.Value)
                    {
                        retorno.IVENTA = (string)(dr["VENTA"]);
                    }

                    if (dr["CLIENTE"] != System.DBNull.Value)
                    {
                        retorno.ICLIENTE = (string)(dr["CLIENTE"]);
                    }

                    if (dr["ESTATUS"] != System.DBNull.Value)
                    {
                        retorno.IESTATUS = (string)(dr["ESTATUS"]);
                    }

                    if (dr["ESTATUS2"] != System.DBNull.Value)
                    {
                        retorno.IESTATUS2 = (string)(dr["ESTATUS2"]);
                    }

                    if (dr["NOTA1"] != System.DBNull.Value)
                    {
                        retorno.INOTA1 = (string)(dr["NOTA1"]);
                    }

                    if (dr["NOTA2"] != System.DBNull.Value)
                    {
                        retorno.INOTA2 = (string)(dr["NOTA2"]);
                    }

                    if (dr["PLAZOS"] != System.DBNull.Value)
                    {
                        retorno.IPLAZOS = (string)(dr["PLAZOS"]);
                    }

                    if (dr["SUGERIDOS"] != System.DBNull.Value)
                    {
                        retorno.ISUGERIDOS = (string)(dr["SUGERIDOS"]);
                    }

                    if (dr["TOTAL"] != System.DBNull.Value)
                    {
                        retorno.ITOTAL = (decimal)(dr["TOTAL"]);
                    }

                    if (dr["AUTOCRED"] != System.DBNull.Value)
                    {
                        retorno.IAUTOCRED = (string)(dr["AUTOCRED"]);
                    }

                    if (dr["CONTADO"] != System.DBNull.Value)
                    {
                        retorno.ICONTADO = (string)(dr["CONTADO"]);
                    }

                    if (dr["PROCESADO"] != System.DBNull.Value)
                    {
                        retorno.IPROCESADO = (string)(dr["PROCESADO"]);
                    }

                    if (dr["ID"] != System.DBNull.Value)
                    {
                        retorno.IID = (long)(dr["ID"]);
                    }

                    if (dr["ID_FECHA"] != System.DBNull.Value)
                    {
                        retorno.IID_FECHA = (DateTime)(dr["ID_FECHA"]);
                    }

                    if (dr["ID_HORA"] != System.DBNull.Value)
                    {
                        retorno.IID_HORA = (string)(dr["ID_HORA"]);
                    }

                    if (dr["VENDCLAVE"] != System.DBNull.Value)
                    {
                        retorno.IVENDCLAVE = (string)(dr["VENDCLAVE"]);
                    }

                }
                else
                {
                    retorno = null;
                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                return retorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }









        public DataSet enlistarM_VENP()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_M_VENP_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public DataSet enlistarCortoM_VENP()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_M_VENP_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public int ExisteM_VENP(FM_VENPBE oCM_VENP, FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCM_VENP.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from M_VENP where

  ID=@ID  
  );";






                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, commandText, arParms);



                if (dr.Read())
                {
                    retorno = 1;
                }
                else
                {
                    retorno = 0;
                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return retorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return -1;
            }
        }




        public FM_VENPBE AgregarM_VENP(FM_VENPBE oCM_VENP, FbTransaction st)
        {
            try
            {
                int iRes = ExisteM_VENP(oCM_VENP, st);
                if (iRes == 1)
                {
                    this.IComentario = "El M_VENP ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarM_VENPD(oCM_VENP, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarM_VENP(FM_VENPBE oCM_VENP, FbTransaction st)
        {
            try
            {
                int iRes = ExisteM_VENP(oCM_VENP, st);
                if (iRes == 0)
                {
                    this.IComentario = "El M_VENP no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarM_VENPD(oCM_VENP, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarM_VENP(FM_VENPBE oCM_VENPNuevo, FM_VENPBE oCM_VENPAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteM_VENP(oCM_VENPAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El M_VENP no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarM_VENPD(oCM_VENPNuevo, oCM_VENPAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public FM_VENPBE seleccionarM_VENP_XVENTA(string venta, string vendClave, FbTransaction st)
        {



            FbDataReader dr = null;

            FbConnection pcn = null;

            FM_VENPBE retorno = new FM_VENPBE();

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from M_VENP where VENTA = @VENTA AND VENDCLAVE = @VENDCLAVE   ";


                auxPar = new FbParameter("@VENTA", FbDbType.VarChar);
                auxPar.Value = venta;
                parts.Add(auxPar);

                auxPar = new FbParameter("@VENDCLAVE", FbDbType.VarChar);
                auxPar.Value = vendClave;
                parts.Add(auxPar);






                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                
                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["VENTA"] != System.DBNull.Value)
                    {
                        retorno.IVENTA = (string)(dr["VENTA"]);
                    }

                    if (dr["VENDCLAVE"] != System.DBNull.Value)
                    {
                        retorno.IVENDCLAVE = (string)(dr["VENTA"]);
                    }

                    if (dr["CLIENTE"] != System.DBNull.Value)
                    {
                        retorno.ICLIENTE = (string)(dr["CLIENTE"]);
                    }

                    if (dr["ESTATUS"] != System.DBNull.Value)
                    {
                        retorno.IESTATUS = (string)(dr["ESTATUS"]);
                    }

                    if (dr["ESTATUS2"] != System.DBNull.Value)
                    {
                        retorno.IESTATUS2 = (string)(dr["ESTATUS2"]);
                    }

                    if (dr["NOTA1"] != System.DBNull.Value)
                    {
                        retorno.INOTA1 = (string)(dr["NOTA1"]);
                    }

                    if (dr["NOTA2"] != System.DBNull.Value)
                    {
                        retorno.INOTA2 = (string)(dr["NOTA2"]);
                    }

                    if (dr["PLAZOS"] != System.DBNull.Value)
                    {
                        retorno.IPLAZOS = (string)(dr["PLAZOS"]);
                    }

                    if (dr["SUGERIDOS"] != System.DBNull.Value)
                    {
                        retorno.ISUGERIDOS = (string)(dr["SUGERIDOS"]);
                    }

                    if (dr["TOTAL"] != System.DBNull.Value)
                    {
                        retorno.ITOTAL = (Decimal)(dr["TOTAL"]);
                    }

                    if (dr["AUTOCRED"] != System.DBNull.Value)
                    {
                        retorno.IAUTOCRED = (string)(dr["AUTOCRED"]);
                    }

                    if (dr["CONTADO"] != System.DBNull.Value)
                    {
                        retorno.ICONTADO = (string)(dr["CONTADO"]);
                    }

                    if (dr["PROCESADO"] != System.DBNull.Value)
                    {
                        retorno.IPROCESADO = (string)(dr["PROCESADO"]);
                    }

                    if (dr["ID"] != System.DBNull.Value)
                    {
                        retorno.IID = (long)(dr["ID"]);
                    }

                    if (dr["ID_FECHA"] != System.DBNull.Value)
                    {
                        retorno.IID_FECHA = (DateTime)(dr["ID_FECHA"]);
                    }

                    if (dr["ID_HORA"] != System.DBNull.Value)
                    {
                        retorno.IID_HORA = (string)(dr["ID_HORA"]);
                    }

                }
                else
                {
                    retorno = null;
                }



                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);


                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }





        public List<FM_VENPBE> seleccionarM_VENP_X_ENVIAR(int cantidadReg, bool bConsiderarConError, FbTransaction st)
        {



            FbDataReader dr = null;

            FbConnection pcn = null;

            
            List<FM_VENPBE> retornoList = new List<FM_VENPBE>();

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                string adicionalEstado = bConsiderarConError ? ", 'E' " : "";

                String CmdTxt = @"select first " + cantidadReg.ToString() +  @" * from M_VENP where COALESCE(PROCESADO, '') IN ('','L'" + adicionalEstado + ") order by id ";

                

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                while (dr.Read())
                {
                    FM_VENPBE retorno = new FM_VENPBE();
                    if (dr["VENTA"] != System.DBNull.Value)
                    {
                        retorno.IVENTA = (string)(dr["VENTA"]);
                    }

                    if (dr["VENDCLAVE"] != System.DBNull.Value)
                    {
                        retorno.IVENDCLAVE = (string)(dr["VENTA"]);
                    }

                    if (dr["CLIENTE"] != System.DBNull.Value)
                    {
                        retorno.ICLIENTE = (string)(dr["CLIENTE"]);
                    }

                    if (dr["ESTATUS"] != System.DBNull.Value)
                    {
                        retorno.IESTATUS = (string)(dr["ESTATUS"]);
                    }

                    if (dr["ESTATUS2"] != System.DBNull.Value)
                    {
                        retorno.IESTATUS2 = (string)(dr["ESTATUS2"]);
                    }

                    if (dr["NOTA1"] != System.DBNull.Value)
                    {
                        retorno.INOTA1 = (string)(dr["NOTA1"]);
                    }

                    if (dr["NOTA2"] != System.DBNull.Value)
                    {
                        retorno.INOTA2 = (string)(dr["NOTA2"]);
                    }

                    if (dr["PLAZOS"] != System.DBNull.Value)
                    {
                        retorno.IPLAZOS = (string)(dr["PLAZOS"]);
                    }

                    if (dr["SUGERIDOS"] != System.DBNull.Value)
                    {
                        retorno.ISUGERIDOS = (string)(dr["SUGERIDOS"]);
                    }

                    if (dr["TOTAL"] != System.DBNull.Value)
                    {
                        retorno.ITOTAL = (Decimal)(dr["TOTAL"]);
                    }

                    if (dr["AUTOCRED"] != System.DBNull.Value)
                    {
                        retorno.IAUTOCRED = (string)(dr["AUTOCRED"]);
                    }

                    if (dr["CONTADO"] != System.DBNull.Value)
                    {
                        retorno.ICONTADO = (string)(dr["CONTADO"]);
                    }

                    if (dr["PROCESADO"] != System.DBNull.Value)
                    {
                        retorno.IPROCESADO = (string)(dr["PROCESADO"]);
                    }

                    if (dr["ID"] != System.DBNull.Value)
                    {
                        retorno.IID = (long)(dr["ID"]);
                    }

                    if (dr["ID_FECHA"] != System.DBNull.Value)
                    {
                        retorno.IID_FECHA = (DateTime)(dr["ID_FECHA"]);
                    }

                    if (dr["ID_HORA"] != System.DBNull.Value)
                    {
                        retorno.IID_HORA = (string)(dr["ID_HORA"]);
                    }

                    retornoList.Add(retorno);

                }



                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);


                return retornoList;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }


        public bool CambiarM_VENPD_PROCESADO(FM_VENPBE oCM_VENPNuevo, FM_VENPBE oCM_VENPAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                

                auxPar = new FbParameter("@PROCESADO", FbDbType.VarChar);
                if (!(bool)oCM_VENPNuevo.isnull["IPROCESADO"])
                {
                    auxPar.Value = oCM_VENPNuevo.IPROCESADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

               
                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCM_VENPAnterior.isnull["IID"])
                {
                    auxPar.Value = oCM_VENPAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  M_VENP
  set


PROCESADO=@PROCESADO

  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public FM_VENPD(string cadenaConexion)
        {
            this.sCadenaConexion = cadenaConexion;
        }
        public FM_VENPD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
