

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



    public class FM_VEDPD
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


        public FM_VEDPBE AgregarM_VEDPD(FM_VEDPBE oCM_VEDP, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@VENTA", FbDbType.VarChar);
                if (!(bool)oCM_VEDP.isnull["IVENTA"])
                {
                    auxPar.Value = oCM_VEDP.IVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLIENTE", FbDbType.VarChar);
                if (!(bool)oCM_VEDP.isnull["ICLIENTE"])
                {
                    auxPar.Value = oCM_VEDP.ICLIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTO", FbDbType.VarChar);
                if (!(bool)oCM_VEDP.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCM_VEDP.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESC1", FbDbType.VarChar);
                if (!(bool)oCM_VEDP.isnull["IDESC1"])
                {
                    auxPar.Value = oCM_VEDP.IDESC1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDAD", FbDbType.Numeric);
                if (!(bool)oCM_VEDP.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCM_VEDP.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO", FbDbType.Numeric);
                if (!(bool)oCM_VEDP.isnull["IPRECIO"])
                {
                    auxPar.Value = oCM_VEDP.IPRECIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCUENTO", FbDbType.Numeric);
                if (!(bool)oCM_VEDP.isnull["IDESCUENTO"])
                {
                    auxPar.Value = oCM_VEDP.IDESCUENTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLASIFICA", FbDbType.VarChar);
                if (!(bool)oCM_VEDP.isnull["ICLASIFICA"])
                {
                    auxPar.Value = oCM_VEDP.ICLASIFICA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@AUTORIZA", FbDbType.VarChar);
                if (!(bool)oCM_VEDP.isnull["IAUTORIZA"])
                {
                    auxPar.Value = oCM_VEDP.IAUTORIZA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SURTIDAS", FbDbType.Numeric);
                if (!(bool)oCM_VEDP.isnull["ISURTIDAS"])
                {
                    auxPar.Value = oCM_VEDP.ISURTIDAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PROD2", FbDbType.VarChar);
                if (!(bool)oCM_VEDP.isnull["IPROD2"])
                {
                    auxPar.Value = oCM_VEDP.IPROD2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PROD3", FbDbType.VarChar);
                if (!(bool)oCM_VEDP.isnull["IPROD3"])
                {
                    auxPar.Value = oCM_VEDP.IPROD3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@OFERTA", FbDbType.VarChar);
                if (!(bool)oCM_VEDP.isnull["IOFERTA"])
                {
                    auxPar.Value = oCM_VEDP.IOFERTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQUERIDAS", FbDbType.Numeric);
                if (!(bool)oCM_VEDP.isnull["IREQUERIDAS"])
                {
                    auxPar.Value = oCM_VEDP.IREQUERIDAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@AUTOCRED", FbDbType.VarChar);
                if (!(bool)oCM_VEDP.isnull["IAUTOCRED"])
                {
                    auxPar.Value = oCM_VEDP.IAUTOCRED;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ID_FECHA", FbDbType.Date);
                if (!(bool)oCM_VEDP.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_VEDP.IID_FECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ID_HORA", FbDbType.VarChar);
                if (!(bool)oCM_VEDP.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_VEDP.IID_HORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENPID", FbDbType.BigInt);
                if (!(bool)oCM_VEDP.isnull["IVENPID"])
                {
                    auxPar.Value = oCM_VEDP.IVENPID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO M_VEDP
      (
    
VENTA,

CLIENTE,

PRODUCTO,

DESC1,

CANTIDAD,

PRECIO,

DESCUENTO,

CLASIFICA,

AUTORIZA,

SURTIDAS,

PROD2,

PROD3,

OFERTA,

REQUERIDAS,

AUTOCRED,

ID_FECHA,

ID_HORA,

VENPID
         )

Values (

@VENTA,

@CLIENTE,

@PRODUCTO,

@DESC1,

@CANTIDAD,

@PRECIO,

@DESCUENTO,

@CLASIFICA,

@AUTORIZA,

@SURTIDAS,

@PROD2,

@PROD3,

@OFERTA,

@REQUERIDAS,

@AUTOCRED,

@ID_FECHA,

@ID_HORA,

@VENPID
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCM_VEDP;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarM_VEDPD(FM_VEDPBE oCM_VEDP, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCM_VEDP.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from M_VEDP
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


        public bool CambiarM_VEDPD(FM_VEDPBE oCM_VEDPNuevo, FM_VEDPBE oCM_VEDPAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@VENTA", FbDbType.VarChar);
                if (!(bool)oCM_VEDPNuevo.isnull["IVENTA"])
                {
                    auxPar.Value = oCM_VEDPNuevo.IVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLIENTE", FbDbType.VarChar);
                if (!(bool)oCM_VEDPNuevo.isnull["ICLIENTE"])
                {
                    auxPar.Value = oCM_VEDPNuevo.ICLIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRODUCTO", FbDbType.VarChar);
                if (!(bool)oCM_VEDPNuevo.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCM_VEDPNuevo.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESC1", FbDbType.VarChar);
                if (!(bool)oCM_VEDPNuevo.isnull["IDESC1"])
                {
                    auxPar.Value = oCM_VEDPNuevo.IDESC1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CANTIDAD", FbDbType.Numeric);
                if (!(bool)oCM_VEDPNuevo.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCM_VEDPNuevo.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRECIO", FbDbType.Numeric);
                if (!(bool)oCM_VEDPNuevo.isnull["IPRECIO"])
                {
                    auxPar.Value = oCM_VEDPNuevo.IPRECIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCUENTO", FbDbType.Numeric);
                if (!(bool)oCM_VEDPNuevo.isnull["IDESCUENTO"])
                {
                    auxPar.Value = oCM_VEDPNuevo.IDESCUENTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLASIFICA", FbDbType.VarChar);
                if (!(bool)oCM_VEDPNuevo.isnull["ICLASIFICA"])
                {
                    auxPar.Value = oCM_VEDPNuevo.ICLASIFICA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@AUTORIZA", FbDbType.VarChar);
                if (!(bool)oCM_VEDPNuevo.isnull["IAUTORIZA"])
                {
                    auxPar.Value = oCM_VEDPNuevo.IAUTORIZA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SURTIDAS", FbDbType.Numeric);
                if (!(bool)oCM_VEDPNuevo.isnull["ISURTIDAS"])
                {
                    auxPar.Value = oCM_VEDPNuevo.ISURTIDAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PROD2", FbDbType.VarChar);
                if (!(bool)oCM_VEDPNuevo.isnull["IPROD2"])
                {
                    auxPar.Value = oCM_VEDPNuevo.IPROD2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PROD3", FbDbType.VarChar);
                if (!(bool)oCM_VEDPNuevo.isnull["IPROD3"])
                {
                    auxPar.Value = oCM_VEDPNuevo.IPROD3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@OFERTA", FbDbType.VarChar);
                if (!(bool)oCM_VEDPNuevo.isnull["IOFERTA"])
                {
                    auxPar.Value = oCM_VEDPNuevo.IOFERTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@REQUERIDAS", FbDbType.Numeric);
                if (!(bool)oCM_VEDPNuevo.isnull["IREQUERIDAS"])
                {
                    auxPar.Value = oCM_VEDPNuevo.IREQUERIDAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@AUTOCRED", FbDbType.VarChar);
                if (!(bool)oCM_VEDPNuevo.isnull["IAUTOCRED"])
                {
                    auxPar.Value = oCM_VEDPNuevo.IAUTOCRED;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ID_FECHA", FbDbType.Date);
                if (!(bool)oCM_VEDPNuevo.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_VEDPNuevo.IID_FECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ID_HORA", FbDbType.VarChar);
                if (!(bool)oCM_VEDPNuevo.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_VEDPNuevo.IID_HORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@VENPID", FbDbType.BigInt);
                if (!(bool)oCM_VEDPNuevo.isnull["IVENPID"])
                {
                    auxPar.Value = oCM_VEDPNuevo.IVENPID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCM_VEDPAnterior.isnull["IID"])
                {
                    auxPar.Value = oCM_VEDPAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  M_VEDP
  set

VENTA=@VENTA,

CLIENTE=@CLIENTE,

PRODUCTO=@PRODUCTO,

DESC1=@DESC1,

CANTIDAD=@CANTIDAD,

PRECIO=@PRECIO,

DESCUENTO=@DESCUENTO,

CLASIFICA=@CLASIFICA,

AUTORIZA=@AUTORIZA,

SURTIDAS=@SURTIDAS,

PROD2=@PROD2,

PROD3=@PROD3,

OFERTA=@OFERTA,

REQUERIDAS=@REQUERIDAS,

AUTOCRED=@AUTOCRED,

ID_FECHA=@ID_FECHA,

ID_HORA=@ID_HORA,

VENPID=@VENPID
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


        public FM_VEDPBE seleccionarM_VEDP(FM_VEDPBE oCM_VEDP, FbTransaction st)
        {




            FM_VEDPBE retorno = new FM_VEDPBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from M_VEDP where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCM_VEDP.IID;
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

                    if (dr["PRODUCTO"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTO = (string)(dr["PRODUCTO"]);
                    }

                    if (dr["DESC1"] != System.DBNull.Value)
                    {
                        retorno.IDESC1 = (string)(dr["DESC1"]);
                    }

                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDAD = (decimal)(dr["CANTIDAD"]);
                    }

                    if (dr["PRECIO"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO = (decimal)(dr["PRECIO"]);
                    }

                    if (dr["DESCUENTO"] != System.DBNull.Value)
                    {
                        retorno.IDESCUENTO = (decimal)(dr["DESCUENTO"]);
                    }

                    if (dr["CLASIFICA"] != System.DBNull.Value)
                    {
                        retorno.ICLASIFICA = (string)(dr["CLASIFICA"]);
                    }

                    if (dr["AUTORIZA"] != System.DBNull.Value)
                    {
                        retorno.IAUTORIZA = (string)(dr["AUTORIZA"]);
                    }

                    if (dr["SURTIDAS"] != System.DBNull.Value)
                    {
                        retorno.ISURTIDAS = (decimal)(dr["SURTIDAS"]);
                    }

                    if (dr["PROD2"] != System.DBNull.Value)
                    {
                        retorno.IPROD2 = (string)(dr["PROD2"]);
                    }

                    if (dr["PROD3"] != System.DBNull.Value)
                    {
                        retorno.IPROD3 = (string)(dr["PROD3"]);
                    }

                    if (dr["OFERTA"] != System.DBNull.Value)
                    {
                        retorno.IOFERTA = (string)(dr["OFERTA"]);
                    }

                    if (dr["REQUERIDAS"] != System.DBNull.Value)
                    {
                        retorno.IREQUERIDAS = (decimal)(dr["REQUERIDAS"]);
                    }

                    if (dr["AUTOCRED"] != System.DBNull.Value)
                    {
                        retorno.IAUTOCRED = (string)(dr["AUTOCRED"]);
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

                    if (dr["VENPID"] != System.DBNull.Value)
                    {
                        retorno.IVENPID = (long)(dr["VENPID"]);
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









        public DataSet enlistarM_VEDP()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_M_VEDP_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public DataSet enlistarCortoM_VEDP()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_M_VEDP_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public int ExisteM_VEDP(FM_VEDPBE oCM_VEDP, FbTransaction st)
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
                auxPar.Value = oCM_VEDP.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from M_VEDP where

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




        public FM_VEDPBE AgregarM_VEDP(FM_VEDPBE oCM_VEDP, FbTransaction st)
        {
            try
            {
                int iRes = ExisteM_VEDP(oCM_VEDP, st);
                if (iRes == 1)
                {
                    this.IComentario = "El M_VEDP ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarM_VEDPD(oCM_VEDP, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarM_VEDP(FM_VEDPBE oCM_VEDP, FbTransaction st)
        {
            try
            {
                int iRes = ExisteM_VEDP(oCM_VEDP, st);
                if (iRes == 0)
                {
                    this.IComentario = "El M_VEDP no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarM_VEDPD(oCM_VEDP, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarM_VEDP(FM_VEDPBE oCM_VEDPNuevo, FM_VEDPBE oCM_VEDPAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteM_VEDP(oCM_VEDPAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El M_VEDP no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarM_VEDPD(oCM_VEDPNuevo, oCM_VEDPAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }




        public bool BorrarM_VEDPDXVENPID(long venpId, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@VENPID", FbDbType.BigInt);
                auxPar.Value = venpId;
                parts.Add(auxPar);



                string commandText = @"  Delete from M_VEDP
  where

  VENPID = @VENPID
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




        public List<FM_VEDPBE> seleccionarM_VEDP_X_VENTA(long venpId, FbTransaction st)
        {


            List<FM_VEDPBE> retornoList = new List<FM_VEDPBE>();

            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from M_VEDP where VENPID = @VENPID  ";


                auxPar = new FbParameter("@VENPID", FbDbType.BigInt);
                auxPar.Value = venpId;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                while (dr.Read())
                {
                    FM_VEDPBE retorno = new FM_VEDPBE();

                    if (dr["VENTA"] != System.DBNull.Value)
                    {
                        retorno.IVENTA = (string)(dr["VENTA"]);
                    }

                    if (dr["CLIENTE"] != System.DBNull.Value)
                    {
                        retorno.ICLIENTE = (string)(dr["CLIENTE"]);
                    }

                    if (dr["PRODUCTO"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTO = (string)(dr["PRODUCTO"]);
                    }

                    if (dr["DESC1"] != System.DBNull.Value)
                    {
                        retorno.IDESC1 = (string)(dr["DESC1"]);
                    }

                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDAD = (decimal)(dr["CANTIDAD"]);
                    }

                    if (dr["PRECIO"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO = (decimal)(dr["PRECIO"]);
                    }

                    if (dr["DESCUENTO"] != System.DBNull.Value)
                    {
                        retorno.IDESCUENTO = (decimal)(dr["DESCUENTO"]);
                    }

                    if (dr["CLASIFICA"] != System.DBNull.Value)
                    {
                        retorno.ICLASIFICA = (string)(dr["CLASIFICA"]);
                    }

                    if (dr["AUTORIZA"] != System.DBNull.Value)
                    {
                        retorno.IAUTORIZA = (string)(dr["AUTORIZA"]);
                    }

                    if (dr["SURTIDAS"] != System.DBNull.Value)
                    {
                        retorno.ISURTIDAS = (decimal)(dr["SURTIDAS"]);
                    }

                    if (dr["PROD2"] != System.DBNull.Value)
                    {
                        retorno.IPROD2 = (string)(dr["PROD2"]);
                    }

                    if (dr["PROD3"] != System.DBNull.Value)
                    {
                        retorno.IPROD3 = (string)(dr["PROD3"]);
                    }

                    if (dr["OFERTA"] != System.DBNull.Value)
                    {
                        retorno.IOFERTA = (string)(dr["OFERTA"]);
                    }

                    if (dr["REQUERIDAS"] != System.DBNull.Value)
                    {
                        retorno.IREQUERIDAS = (decimal)(dr["REQUERIDAS"]);
                    }

                    if (dr["AUTOCRED"] != System.DBNull.Value)
                    {
                        retorno.IAUTOCRED = (string)(dr["AUTOCRED"]);
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

                    if (dr["VENPID"] != System.DBNull.Value)
                    {
                        retorno.IVENPID = (long)(dr["VENPID"]);
                    }
                    retornoList.Add(retorno);
                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                return retornoList;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public FM_VEDPD(string cadenaConexion)
        {
            this.sCadenaConexion = cadenaConexion;
        }

        public FM_VEDPD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
