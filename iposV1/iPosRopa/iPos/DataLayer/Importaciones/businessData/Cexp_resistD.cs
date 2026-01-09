
using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Data.OleDb;
using DataLayer;
using System.Collections;
using ConexionesBD;


namespace iPosData
{

    [Transaction(TransactionOption.Supported)]


    public class CEXP_EXISTD
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
        public bool AgregarEXP_EXISTD(CEXP_EXISTBE oCEXP_EXIST, string strTableName, OleDbTransaction st,string conn)
        {
            int iRowsInserted;
            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;

                auxPar = new OleDbParameter("@CLAVE", OleDbType.VarChar);
                if (!(bool)oCEXP_EXIST.isnull["ICLAVE"])
                {
                    auxPar.Value = oCEXP_EXIST.ICLAVE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@HORA", OleDbType.VarChar);
                if (!(bool)oCEXP_EXIST.isnull["IHORA"])
                {
                    auxPar.Value = oCEXP_EXIST.IHORA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FECHA", OleDbType.Date);
                if (!(bool)oCEXP_EXIST.isnull["IFECHA"])
                {
                    auxPar.Value = oCEXP_EXIST.IFECHA;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Double);
                if (!(bool)oCEXP_EXIST.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCEXP_EXIST.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO '" + strTableName + @"' 
      (
    
CLAVE,

HORA,

FECHA,

CANTIDAD
         )

Values (

?,

?,

?,

?
); ";

                OleDbParameter[] arParms = new OleDbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if(conn != "")
                    iRowsInserted = OleDbHelper.ExecuteNonQuery(conn, CommandType.Text, commandText, arParms);
                else
                iRowsInserted = OleDbHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);

                return (iRowsInserted > 0);

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        [AutoComplete]
        public bool BorrarEXP_EXISTD(CEXP_EXISTBE oCEXP_EXIST, OleDbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@CLAVE", OleDbType.VarChar);
                auxPar.Value = oCEXP_EXIST.ICLAVE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@HORA", OleDbType.VarChar);
                auxPar.Value = oCEXP_EXIST.IHORA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FECHA", OleDbType.Date);
                auxPar.Value = oCEXP_EXIST.IFECHA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Double);
                auxPar.Value = oCEXP_EXIST.ICANTIDAD;
                parts.Add(auxPar);



                string commandText = @"  Delete from EXP_EXIST
  where

  CLAVE=@CLAVE and 

  HORA=@HORA and 

  FECHA=@FECHA and 

  CANTIDAD=@CANTIDAD
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
        public bool CambiarEXP_EXISTD(CEXP_EXISTBE oCEXP_EXISTNuevo, CEXP_EXISTBE oCEXP_EXISTAnterior, OleDbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@CLAVE", OleDbType.VarChar);
                if (!(bool)oCEXP_EXISTNuevo.isnull["ICLAVE"])
                {
                    auxPar.Value = oCEXP_EXISTNuevo.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@HORA", OleDbType.VarChar);
                if (!(bool)oCEXP_EXISTNuevo.isnull["IHORA"])
                {
                    auxPar.Value = oCEXP_EXISTNuevo.IHORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@FECHA", OleDbType.Date);
                if (!(bool)oCEXP_EXISTNuevo.isnull["IFECHA"])
                {
                    auxPar.Value = oCEXP_EXISTNuevo.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Double);
                if (!(bool)oCEXP_EXISTNuevo.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCEXP_EXISTNuevo.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CLAVEAnt", OleDbType.VarChar);
                if (!(bool)oCEXP_EXISTAnterior.isnull["ICLAVE"])
                {
                    auxPar.Value = oCEXP_EXISTAnterior.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@HORAAnt", OleDbType.VarChar);
                if (!(bool)oCEXP_EXISTAnterior.isnull["IHORA"])
                {
                    auxPar.Value = oCEXP_EXISTAnterior.IHORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@FECHAAnt", OleDbType.Date);
                if (!(bool)oCEXP_EXISTAnterior.isnull["IFECHA"])
                {
                    auxPar.Value = oCEXP_EXISTAnterior.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CANTIDADAnt", OleDbType.Double);
                if (!(bool)oCEXP_EXISTAnterior.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCEXP_EXISTAnterior.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  EXP_EXIST
  set

CLAVE=@CLAVE,
HORA=@HORA,

FECHA=@FECHA,

CANTIDAD=@CANTIDAD
  where 

CLAVE=@CLAVEAnt and

LOTE=@LOTEAnt and

FECHA_CAD=@FECHA_CADAnt and

CANTIDAD=@CANTIDADAnt
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
        public CEXP_EXISTBE seleccionarEXP_EXIST(CEXP_EXISTBE oCEXP_EXIST, OleDbTransaction st)
        {




            CEXP_EXISTBE retorno = new CEXP_EXISTBE();

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;

                String CmdTxt = @"select * from EXP_EXIST where
 CLAVE=@CLAVE    and
 HORA=@HORA    and
 FECHA=@FECHA   and
 CANTIDAD=@CANTIDAD  ";


                auxPar = new OleDbParameter("@CLAVE", OleDbType.VarChar);
                auxPar.Value = oCEXP_EXIST.ICLAVE;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@HORA", OleDbType.VarChar);
                auxPar.Value = oCEXP_EXIST.IHORA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@FECHA", OleDbType.Date);
                auxPar.Value = oCEXP_EXIST.IFECHA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Double);
                auxPar.Value = oCEXP_EXIST.ICANTIDAD;
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

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = (string)(dr["CLAVE"]);
                    }

                    if (dr["HORA"] != System.DBNull.Value)
                    {
                        retorno.IHORA = (string)(dr["HORA"]);
                    }

                    if (dr["FECHA"] != System.DBNull.Value)
                    {
                        retorno.IFECHA = (DateTime)(dr["FECHA"]);
                    }

                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDAD = (double)(dr["CANTIDAD"]);
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
        public DataSet enlistarEXP_EXIST()
        {

            DataSet retorno;
            try
            {
                retorno = OleDbHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_EXP_EXIST_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoEXP_EXIST()
        {
            DataSet retorno;
            try
            {

                retorno = OleDbHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_EXP_EXIST_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteEXP_EXIST(CEXP_EXISTBE oCEXP_EXIST, OleDbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@CLAVE", OleDbType.VarChar);
                auxPar.Value = oCEXP_EXIST.ICLAVE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@HORA", OleDbType.VarChar);
                auxPar.Value = oCEXP_EXIST.IHORA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FECHA", OleDbType.Date);
                auxPar.Value = oCEXP_EXIST.IFECHA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Double);
                auxPar.Value = oCEXP_EXIST.ICANTIDAD;
                parts.Add(auxPar);

                OleDbParameter[] arParms = new OleDbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from EXP_EXIST where

  CLAVE=@CLAVE    and

  HORA=@HORA    and

  FECHA=@FECHA    and

  CANTIDAD=@CANTIDAD  
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




        public bool AgregarEXP_EXIST(CEXP_EXISTBE oCEXP_EXIST, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteEXP_EXIST(oCEXP_EXIST, st);
                if (iRes == 1)
                {
                    this.IComentario = "El EXP_EXIST ya existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return AgregarEXP_EXISTD(oCEXP_EXIST,"Existencias", st,"");
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public bool BorrarEXP_EXIST(CEXP_EXISTBE oCEXP_EXIST, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteEXP_EXIST(oCEXP_EXIST, st);
                if (iRes == 0)
                {
                    this.IComentario = "El EXP_EXIST no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarEXP_EXISTD(oCEXP_EXIST, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarEXP_EXIST(CEXP_EXISTBE oCEXP_EXISTNuevo, CEXP_EXISTBE oCEXP_EXISTAnterior, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteEXP_EXIST(oCEXP_EXISTAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El EXP_EXIST no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarEXP_EXISTD(oCEXP_EXISTNuevo, oCEXP_EXISTAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CEXP_EXISTD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
