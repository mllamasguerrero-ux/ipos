

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



    public class CLISTAPRECIODETALLED
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


        public CLISTAPRECIODETALLEBE AgregarLISTAPRECIODETALLED(CLISTAPRECIODETALLEBE oCLISTAPRECIODETALLE, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCLISTAPRECIODETALLE.isnull["IACTIVO"])
                {
                    auxPar.Value = oCLISTAPRECIODETALLE.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCLISTAPRECIODETALLE.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCLISTAPRECIODETALLE.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCLISTAPRECIODETALLE.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCLISTAPRECIODETALLE.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LISTAPRECIOID", FbDbType.BigInt);
                if (!(bool)oCLISTAPRECIODETALLE.isnull["ILISTAPRECIOID"])
                {
                    auxPar.Value = oCLISTAPRECIODETALLE.ILISTAPRECIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO1", FbDbType.Numeric);
                if (!(bool)oCLISTAPRECIODETALLE.isnull["IPRECIO1"])
                {
                    auxPar.Value = oCLISTAPRECIODETALLE.IPRECIO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO2", FbDbType.Numeric);
                if (!(bool)oCLISTAPRECIODETALLE.isnull["IPRECIO2"])
                {
                    auxPar.Value = oCLISTAPRECIODETALLE.IPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO3", FbDbType.Numeric);
                if (!(bool)oCLISTAPRECIODETALLE.isnull["IPRECIO3"])
                {
                    auxPar.Value = oCLISTAPRECIODETALLE.IPRECIO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO4", FbDbType.Numeric);
                if (!(bool)oCLISTAPRECIODETALLE.isnull["IPRECIO4"])
                {
                    auxPar.Value = oCLISTAPRECIODETALLE.IPRECIO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO5", FbDbType.Numeric);
                if (!(bool)oCLISTAPRECIODETALLE.isnull["IPRECIO5"])
                {
                    auxPar.Value = oCLISTAPRECIODETALLE.IPRECIO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO6", FbDbType.Numeric);
                if (!(bool)oCLISTAPRECIODETALLE.isnull["IPRECIO6"])
                {
                    auxPar.Value = oCLISTAPRECIODETALLE.IPRECIO6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                if (!(bool)oCLISTAPRECIODETALLE.isnull["IPRODUCTOID"])
                {
                    auxPar.Value = oCLISTAPRECIODETALLE.IPRODUCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO LISTAPRECIODETALLE
      (
    
ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

LISTAPRECIOID,

PRECIO1,

PRECIO2,

PRECIO3,

PRECIO4,

PRECIO5,

PRECIO6,

PRODUCTOID
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@LISTAPRECIOID,

@PRECIO1,

@PRECIO2,

@PRECIO3,

@PRECIO4,

@PRECIO5,

@PRECIO6,

@PRODUCTOID
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCLISTAPRECIODETALLE;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }




        public CLISTAPRECIODETALLEBE AgregarOCambiarLISTAPRECIODETALLED(CLISTAPRECIODETALLEBE oCLISTAPRECIODETALLE, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCLISTAPRECIODETALLE.isnull["IACTIVO"])
                {
                    auxPar.Value = oCLISTAPRECIODETALLE.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCLISTAPRECIODETALLE.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCLISTAPRECIODETALLE.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCLISTAPRECIODETALLE.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCLISTAPRECIODETALLE.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LISTAPRECIOID", FbDbType.BigInt);
                if (!(bool)oCLISTAPRECIODETALLE.isnull["ILISTAPRECIOID"])
                {
                    auxPar.Value = oCLISTAPRECIODETALLE.ILISTAPRECIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO1", FbDbType.Numeric);
                if (!(bool)oCLISTAPRECIODETALLE.isnull["IPRECIO1"])
                {
                    auxPar.Value = oCLISTAPRECIODETALLE.IPRECIO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO2", FbDbType.Numeric);
                if (!(bool)oCLISTAPRECIODETALLE.isnull["IPRECIO2"])
                {
                    auxPar.Value = oCLISTAPRECIODETALLE.IPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO3", FbDbType.Numeric);
                if (!(bool)oCLISTAPRECIODETALLE.isnull["IPRECIO3"])
                {
                    auxPar.Value = oCLISTAPRECIODETALLE.IPRECIO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO4", FbDbType.Numeric);
                if (!(bool)oCLISTAPRECIODETALLE.isnull["IPRECIO4"])
                {
                    auxPar.Value = oCLISTAPRECIODETALLE.IPRECIO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO5", FbDbType.Numeric);
                if (!(bool)oCLISTAPRECIODETALLE.isnull["IPRECIO5"])
                {
                    auxPar.Value = oCLISTAPRECIODETALLE.IPRECIO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO6", FbDbType.Numeric);
                if (!(bool)oCLISTAPRECIODETALLE.isnull["IPRECIO6"])
                {
                    auxPar.Value = oCLISTAPRECIODETALLE.IPRECIO6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COSTOREPOSICION", FbDbType.Numeric);
                if (!(bool)oCLISTAPRECIODETALLE.isnull["ICOSTOREPOSICION"])
                {
                    auxPar.Value = oCLISTAPRECIODETALLE.ICOSTOREPOSICION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIENEVIG", FbDbType.VarChar);
                if (!(bool)oCLISTAPRECIODETALLE.isnull["ITIENEVIG"])
                {
                    auxPar.Value = oCLISTAPRECIODETALLE.ITIENEVIG;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAVIG", FbDbType.Date);
                if (!(bool)oCLISTAPRECIODETALLE.isnull["IFECHAVIG"])
                {
                    auxPar.Value = oCLISTAPRECIODETALLE.IFECHAVIG;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                if (!(bool)oCLISTAPRECIODETALLE.isnull["IPRODUCTOID"])
                {
                    auxPar.Value = oCLISTAPRECIODETALLE.IPRODUCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        UPDATE OR INSERT INTO LISTAPRECIODETALLE
      (
    
ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

LISTAPRECIOID,

PRECIO1,

PRECIO2,

PRECIO3,

PRECIO4,

PRECIO5,

PRECIO6,

COSTOREPOSICION,

PRODUCTOID,

TIENEVIG,

FECHAVIG
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@LISTAPRECIOID,

@PRECIO1,

@PRECIO2,

@PRECIO3,

@PRECIO4,

@PRECIO5,

@PRECIO6,

@COSTOREPOSICION,

@PRODUCTOID,

@TIENEVIG,

@FECHAVIG
)
MATCHING (LISTAPRECIOID, PRODUCTOID); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCLISTAPRECIODETALLE;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }



        public bool BorrarLISTAPRECIODETALLED(CLISTAPRECIODETALLEBE oCLISTAPRECIODETALLE, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCLISTAPRECIODETALLE.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from LISTAPRECIODETALLE
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




        public List<CLISTAPRECIODETALLEBE> seleccionarRegistrosLISTAPRECIODETALLE(long listaPrecioId, FbTransaction st)
        {



            List<CLISTAPRECIODETALLEBE> retornoList = new List<CLISTAPRECIODETALLEBE>();

            CLISTAPRECIODETALLEBE retorno = new CLISTAPRECIODETALLEBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from LISTAPRECIODETALLE where LISTAPRECIOID = @LISTAPRECIOID  ";


                auxPar = new FbParameter("@LISTAPRECIOID", FbDbType.BigInt);
                auxPar.Value = listaPrecioId;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                while (dr.Read())
                {
                    retorno = new CLISTAPRECIODETALLEBE();

                    if (dr["ID"] != System.DBNull.Value)
                    {
                        retorno.IID = (long)(dr["ID"]);
                    }

                    if (dr["ACTIVO"] != System.DBNull.Value)
                    {
                        retorno.IACTIVO = (string)(dr["ACTIVO"]);
                    }

                    if (dr["CREADO"] != System.DBNull.Value)
                    {
                        retorno.ICREADO = (object)(dr["CREADO"]);
                    }

                    if (dr["CREADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.ICREADOPOR_USERID = (long)(dr["CREADOPOR_USERID"]);
                    }

                    if (dr["MODIFICADO"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADO = (object)(dr["MODIFICADO"]);
                    }

                    if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
                    }

                    if (dr["LISTAPRECIOID"] != System.DBNull.Value)
                    {
                        retorno.ILISTAPRECIOID = (long)(dr["LISTAPRECIOID"]);
                    }

                    if (dr["PRECIO1"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO1 = (decimal)(dr["PRECIO1"]);
                    }

                    if (dr["PRECIO2"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO2 = (decimal)(dr["PRECIO2"]);
                    }

                    if (dr["PRECIO3"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO3 = (decimal)(dr["PRECIO3"]);
                    }

                    if (dr["PRECIO4"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO4 = (decimal)(dr["PRECIO4"]);
                    }

                    if (dr["PRECIO5"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO5 = (decimal)(dr["PRECIO5"]);
                    }

                    if (dr["PRECIO6"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO6 = (decimal)(dr["PRECIO6"]);
                    }


                    if (dr["COSTOREPOSICION"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOREPOSICION = (decimal)(dr["COSTOREPOSICION"]);
                    }

                    if (dr["TIENEVIG"] != System.DBNull.Value)
                    {
                        retorno.ITIENEVIG = dr["TIENEVIG"].ToString();
                    }
                    
                    if (dr["FECHAVIG"] != System.DBNull.Value)
                    {
                        retorno.IFECHAVIG = (DateTime)dr["FECHAVIG"];
                    }

                    if (dr["PRODUCTOID"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTOID = (long)(dr["PRODUCTOID"]);
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



        public CLISTAPRECIODETALLEBE seleccionarRegistrosLISTAPRECIODETALLEXListaYProducto(long listaPrecioId, long productoId, FbTransaction st)
        {

            

            CLISTAPRECIODETALLEBE retorno = null;
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from LISTAPRECIODETALLE where LISTAPRECIOID = @LISTAPRECIOID and PRODUCTOID = @PRODUCTOID  ";


                auxPar = new FbParameter("@LISTAPRECIOID", FbDbType.BigInt);
                auxPar.Value = listaPrecioId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                auxPar.Value = productoId;
                parts.Add(auxPar);



                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {
                    retorno = new CLISTAPRECIODETALLEBE();

                    if (dr["ID"] != System.DBNull.Value)
                    {
                        retorno.IID = (long)(dr["ID"]);
                    }

                    if (dr["ACTIVO"] != System.DBNull.Value)
                    {
                        retorno.IACTIVO = (string)(dr["ACTIVO"]);
                    }

                    if (dr["CREADO"] != System.DBNull.Value)
                    {
                        retorno.ICREADO = (object)(dr["CREADO"]);
                    }

                    if (dr["CREADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.ICREADOPOR_USERID = (long)(dr["CREADOPOR_USERID"]);
                    }

                    if (dr["MODIFICADO"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADO = (object)(dr["MODIFICADO"]);
                    }

                    if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
                    }

                    if (dr["LISTAPRECIOID"] != System.DBNull.Value)
                    {
                        retorno.ILISTAPRECIOID = (long)(dr["LISTAPRECIOID"]);
                    }

                    if (dr["PRECIO1"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO1 = (decimal)(dr["PRECIO1"]);
                    }

                    if (dr["PRECIO2"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO2 = (decimal)(dr["PRECIO2"]);
                    }

                    if (dr["PRECIO3"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO3 = (decimal)(dr["PRECIO3"]);
                    }

                    if (dr["PRECIO4"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO4 = (decimal)(dr["PRECIO4"]);
                    }

                    if (dr["PRECIO5"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO5 = (decimal)(dr["PRECIO5"]);
                    }

                    if (dr["PRECIO6"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO6 = (decimal)(dr["PRECIO6"]);
                    }


                    if (dr["COSTOREPOSICION"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOREPOSICION = (decimal)(dr["COSTOREPOSICION"]);
                    }

                    if (dr["TIENEVIG"] != System.DBNull.Value)
                    {
                        retorno.ITIENEVIG = dr["TIENEVIG"].ToString();
                    }

                    if (dr["FECHAVIG"] != System.DBNull.Value)
                    {
                        retorno.IFECHAVIG = (DateTime)dr["FECHAVIG"];
                    }

                    if (dr["PRODUCTOID"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTOID = (long)(dr["PRODUCTOID"]);
                    }
                    

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




        public bool DesactivarxListaPrecio(long listaPrecioId, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@LISTAPRECIOID", FbDbType.BigInt);
                auxPar.Value = listaPrecioId;
                parts.Add(auxPar);



                string commandText = @"  UPDATE  LISTAPRECIODETALLE SET ACTIVO = 'N' WHERE LISTAPRECIOID = @LISTAPRECIOID;";

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


        public bool BorrarInactivosxListaPrecio(long listaPrecioId, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@LISTAPRECIOID", FbDbType.BigInt);
                auxPar.Value = listaPrecioId;
                parts.Add(auxPar);



                string commandText = @"  DELETE FROM  LISTAPRECIODETALLE  WHERE LISTAPRECIOID = @LISTAPRECIOID AND ACTIVO = 'N';";

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



        public bool BorrarxListaPrecio(long listaPrecioId, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@LISTAPRECIOID", FbDbType.BigInt);
                auxPar.Value = listaPrecioId;
                parts.Add(auxPar);



                string commandText = @"  DELETE FROM  LISTAPRECIODETALLE  WHERE LISTAPRECIOID = @LISTAPRECIOID;";

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


        public bool LISTAPRECIO_CARGARTODOS(long listaPrecioId, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                

                auxPar = new FbParameter("@LISTAPRECIOID", FbDbType.BigInt);
                auxPar.Value = listaPrecioId;
                parts.Add(auxPar);

               

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"LISTAPRECIO_CARGARTODOS";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);


                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        this.iComentario = "Hubo un error";
                        return false;
                    }
                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        //public bool ActualizarDetallesLista(List<CLISTAPRECIODETALLEBE> lista, long listaPrecioId, FbTransaction st)
        //{

        //    List<CLISTAPRECIODETALLEBE> listaGuardados = seleccionarRegistrosLISTAPRECIODETALLE(listaPrecioId, st);


        //    foreach (CLISTAPRECIODETALLEBE item in lista)
        //    {
        //        if(item.IPRODUCTOID == 0)
        //        {
        //            CPRODUCTOBE prod = new CPRODUCTOBE();
        //            CPRODUCTOD prodD = new CPRODUCTOD();
        //            prod.ICLAVE = item.IPRODUCTOCLAVE;
        //            prod = prodD.seleccionarPRODUCTOPorClave(prod, st);

        //            if(prod == null)
        //            {
        //                this.IComentario = "hay productos inexistentes";
        //                return false;
        //            }

        //            item.IPRODUCTOID = prod.IID;
        //        }
        //    }


        //    foreach (CLISTAPRECIODETALLEBE itemGuardado in listaGuardados)
        //    {
        //        CLISTAPRECIODETALLEBE itemNuevo = lista.FindLast(x => x.IPRODUCTOID == itemGuardado.IPRODUCTOID);
        //        if(itemNuevo == null)
        //        {
        //            if(!this.BorrarLISTAPRECIODETALLED(itemGuardado, st))
        //            {
        //                return false;
        //            }
        //        }
        //    }



        //    foreach (CLISTAPRECIODETALLEBE item in lista)
        //    {

        //        if(AgregarOCambiarLISTAPRECIODETALLED(item,  st) == null)
        //        {
        //            return false;
        //        }

        //    }



        //    return true;
        //}








        public bool CambiarLISTAPRECIODETALLED(CLISTAPRECIODETALLEBE oCLISTAPRECIODETALLENuevo, CLISTAPRECIODETALLEBE oCLISTAPRECIODETALLEAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCLISTAPRECIODETALLENuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCLISTAPRECIODETALLENuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCLISTAPRECIODETALLENuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCLISTAPRECIODETALLENuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCLISTAPRECIODETALLENuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCLISTAPRECIODETALLENuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LISTAPRECIOID", FbDbType.BigInt);
                if (!(bool)oCLISTAPRECIODETALLENuevo.isnull["ILISTAPRECIOID"])
                {
                    auxPar.Value = oCLISTAPRECIODETALLENuevo.ILISTAPRECIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRECIO1", FbDbType.Numeric);
                if (!(bool)oCLISTAPRECIODETALLENuevo.isnull["IPRECIO1"])
                {
                    auxPar.Value = oCLISTAPRECIODETALLENuevo.IPRECIO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRECIO2", FbDbType.Numeric);
                if (!(bool)oCLISTAPRECIODETALLENuevo.isnull["IPRECIO2"])
                {
                    auxPar.Value = oCLISTAPRECIODETALLENuevo.IPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRECIO3", FbDbType.Numeric);
                if (!(bool)oCLISTAPRECIODETALLENuevo.isnull["IPRECIO3"])
                {
                    auxPar.Value = oCLISTAPRECIODETALLENuevo.IPRECIO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRECIO4", FbDbType.Numeric);
                if (!(bool)oCLISTAPRECIODETALLENuevo.isnull["IPRECIO4"])
                {
                    auxPar.Value = oCLISTAPRECIODETALLENuevo.IPRECIO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRECIO5", FbDbType.Numeric);
                if (!(bool)oCLISTAPRECIODETALLENuevo.isnull["IPRECIO5"])
                {
                    auxPar.Value = oCLISTAPRECIODETALLENuevo.IPRECIO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRECIO6", FbDbType.Numeric);
                if (!(bool)oCLISTAPRECIODETALLENuevo.isnull["IPRECIO6"])
                {
                    auxPar.Value = oCLISTAPRECIODETALLENuevo.IPRECIO6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                if (!(bool)oCLISTAPRECIODETALLENuevo.isnull["IPRODUCTOID"])
                {
                    auxPar.Value = oCLISTAPRECIODETALLENuevo.IPRODUCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCLISTAPRECIODETALLEAnterior.isnull["IID"])
                {
                    auxPar.Value = oCLISTAPRECIODETALLEAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  LISTAPRECIODETALLE
  set

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

LISTAPRECIOID=@LISTAPRECIOID,

PRECIO1=@PRECIO1,

PRECIO2=@PRECIO2,

PRECIO3=@PRECIO3,

PRECIO4=@PRECIO4,

PRECIO5=@PRECIO5,

PRECIO6=@PRECIO6,

PRODUCTOID=@PRODUCTOID
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




        public int cuentaListasConProducto(long productoId, FbTransaction st)
        {




            CLISTAPRECIODETALLEBE retorno = new CLISTAPRECIODETALLEBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            int iCuenta = 0;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select count(*) CUENTA from LISTAPRECIODETALLE where PRODUCTOID = @PRODUCTOID  ";


                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                auxPar.Value = productoId;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["CUENTA"] != System.DBNull.Value)
                    {
                        iCuenta = (int)(dr["CUENTA"]);
                    }

                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                return iCuenta;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return -1;
            }



        }



        public CLISTAPRECIODETALLEBE seleccionarLISTAPRECIODETALLE(CLISTAPRECIODETALLEBE oCLISTAPRECIODETALLE, FbTransaction st)
        {




            CLISTAPRECIODETALLEBE retorno = new CLISTAPRECIODETALLEBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from LISTAPRECIODETALLE where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCLISTAPRECIODETALLE.IID;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["ID"] != System.DBNull.Value)
                    {
                        retorno.IID = (long)(dr["ID"]);
                    }

                    if (dr["ACTIVO"] != System.DBNull.Value)
                    {
                        retorno.IACTIVO = (string)(dr["ACTIVO"]);
                    }

                    if (dr["CREADO"] != System.DBNull.Value)
                    {
                        retorno.ICREADO = (object)(dr["CREADO"]);
                    }

                    if (dr["CREADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.ICREADOPOR_USERID = (long)(dr["CREADOPOR_USERID"]);
                    }

                    if (dr["MODIFICADO"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADO = (object)(dr["MODIFICADO"]);
                    }

                    if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
                    }

                    if (dr["LISTAPRECIOID"] != System.DBNull.Value)
                    {
                        retorno.ILISTAPRECIOID = (long)(dr["LISTAPRECIOID"]);
                    }

                    if (dr["PRECIO1"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO1 = (decimal)(dr["PRECIO1"]);
                    }

                    if (dr["PRECIO2"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO2 = (decimal)(dr["PRECIO2"]);
                    }

                    if (dr["PRECIO3"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO3 = (decimal)(dr["PRECIO3"]);
                    }

                    if (dr["PRECIO4"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO4 = (decimal)(dr["PRECIO4"]);
                    }

                    if (dr["PRECIO5"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO5 = (decimal)(dr["PRECIO5"]);
                    }

                    if (dr["PRECIO6"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO6 = (decimal)(dr["PRECIO6"]);
                    }



                    if (dr["COSTOREPOSICION"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOREPOSICION = (decimal)(dr["COSTOREPOSICION"]);
                    }

                    if (dr["TIENEVIG"] != System.DBNull.Value)
                    {
                        retorno.ITIENEVIG = dr["TIENEVIG"].ToString();
                    }

                    if (dr["FECHAVIG"] != System.DBNull.Value)
                    {
                        retorno.IFECHAVIG = (DateTime)dr["FECHAVIG"];
                    }

                    if (dr["PRODUCTOID"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTOID = (long)(dr["PRODUCTOID"]);
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









        public DataSet enlistarLISTAPRECIODETALLE()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_LISTAPRECIODETALLE_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public DataSet enlistarCortoLISTAPRECIODETALLE()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_LISTAPRECIODETALLE_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public int ExisteLISTAPRECIODETALLE(CLISTAPRECIODETALLEBE oCLISTAPRECIODETALLE, FbTransaction st)
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
                auxPar.Value = oCLISTAPRECIODETALLE.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from LISTAPRECIODETALLE where

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




        public CLISTAPRECIODETALLEBE AgregarLISTAPRECIODETALLE(CLISTAPRECIODETALLEBE oCLISTAPRECIODETALLE, FbTransaction st)
        {
            try
            {
                int iRes = ExisteLISTAPRECIODETALLE(oCLISTAPRECIODETALLE, st);
                if (iRes == 1)
                {
                    this.IComentario = "El LISTAPRECIODETALLE ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarLISTAPRECIODETALLED(oCLISTAPRECIODETALLE, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarLISTAPRECIODETALLE(CLISTAPRECIODETALLEBE oCLISTAPRECIODETALLE, FbTransaction st)
        {
            try
            {
                int iRes = ExisteLISTAPRECIODETALLE(oCLISTAPRECIODETALLE, st);
                if (iRes == 0)
                {
                    this.IComentario = "El LISTAPRECIODETALLE no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarLISTAPRECIODETALLED(oCLISTAPRECIODETALLE, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarLISTAPRECIODETALLE(CLISTAPRECIODETALLEBE oCLISTAPRECIODETALLENuevo, CLISTAPRECIODETALLEBE oCLISTAPRECIODETALLEAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteLISTAPRECIODETALLE(oCLISTAPRECIODETALLEAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El LISTAPRECIODETALLE no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarLISTAPRECIODETALLED(oCLISTAPRECIODETALLENuevo, oCLISTAPRECIODETALLEAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CLISTAPRECIODETALLED()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
