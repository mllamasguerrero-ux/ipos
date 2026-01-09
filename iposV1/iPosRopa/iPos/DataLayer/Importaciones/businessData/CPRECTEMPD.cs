

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



    public class CPRECTEMPD
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



        public bool AgregarPRECTEMPD(CPRECTEMPBE oCPRECTEMP,  string strFileName, OleDbTransaction st, string strOleDbConn)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@PRODUCTO", OleDbType.VarChar);
                if (!(bool)oCPRECTEMP.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCPRECTEMP.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO1", OleDbType.Double);
                if (!(bool)oCPRECTEMP.isnull["IPRECIO1"])
                {
                    auxPar.Value = oCPRECTEMP.IPRECIO1;
                }
                else
                {
                    auxPar.Value = 0.0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO2", OleDbType.Double);
                if (!(bool)oCPRECTEMP.isnull["IPRECIO2"])
                {
                    auxPar.Value = oCPRECTEMP.IPRECIO2;
                }
                else
                {
                    auxPar.Value = 0.0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO3", OleDbType.Double);
                if (!(bool)oCPRECTEMP.isnull["IPRECIO3"])
                {
                    auxPar.Value = oCPRECTEMP.IPRECIO3;
                }
                else
                {
                    auxPar.Value = 0.0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO4", OleDbType.Double);
                if (!(bool)oCPRECTEMP.isnull["IPRECIO4"])
                {
                    auxPar.Value = 0.0;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO5", OleDbType.Double);
                if (!(bool)oCPRECTEMP.isnull["IPRECIO5"])
                {
                    auxPar.Value = oCPRECTEMP.IPRECIO5;
                }
                else
                {
                    auxPar.Value = 0.0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SUGERIDO", OleDbType.Double);
                if (!(bool)oCPRECTEMP.isnull["ISUGERIDO"])
                {
                    auxPar.Value = oCPRECTEMP.ISUGERIDO;
                }
                else
                {
                    auxPar.Value = 0.0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCPRECTEMP.isnull["IID"])
                {
                    auxPar.Value = oCPRECTEMP.IID;
                }
                else
                {
                    auxPar.Value = ""; 
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCPRECTEMP.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCPRECTEMP.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCPRECTEMP.isnull["IID_HORA"])
                {
                    auxPar.Value = oCPRECTEMP.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO  " + strFileName + @"
      (
    
PRODUCTO,

PRECIO1,

PRECIO2,

PRECIO3,

PRECIO4,

PRECIO5,

SUGERIDO,

ID,

ID_FECHA,

ID_HORA
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



        public bool BorrarPRECTEMPD(CPRECTEMPBE oCPRECTEMP, OleDbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                auxPar.Value = oCPRECTEMP.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from PRECTEMP
  where

  ID=@ID
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



        public bool CambiarPRECTEMPD(CPRECTEMPBE oCPRECTEMPNuevo, CPRECTEMPBE oCPRECTEMPAnterior, OleDbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@PRODUCTO", OleDbType.VarChar);
                if (!(bool)oCPRECTEMPNuevo.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCPRECTEMPNuevo.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PRECIO1", OleDbType.Double);
                if (!(bool)oCPRECTEMPNuevo.isnull["IPRECIO1"])
                {
                    auxPar.Value = oCPRECTEMPNuevo.IPRECIO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PRECIO2", OleDbType.Double);
                if (!(bool)oCPRECTEMPNuevo.isnull["IPRECIO2"])
                {
                    auxPar.Value = oCPRECTEMPNuevo.IPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PRECIO3", OleDbType.Double);
                if (!(bool)oCPRECTEMPNuevo.isnull["IPRECIO3"])
                {
                    auxPar.Value = oCPRECTEMPNuevo.IPRECIO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PRECIO4", OleDbType.Double);
                if (!(bool)oCPRECTEMPNuevo.isnull["IPRECIO4"])
                {
                    auxPar.Value = oCPRECTEMPNuevo.IPRECIO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PRECIO5", OleDbType.Double);
                if (!(bool)oCPRECTEMPNuevo.isnull["IPRECIO5"])
                {
                    auxPar.Value = oCPRECTEMPNuevo.IPRECIO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@SUGERIDO", OleDbType.Double);
                if (!(bool)oCPRECTEMPNuevo.isnull["ISUGERIDO"])
                {
                    auxPar.Value = oCPRECTEMPNuevo.ISUGERIDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCPRECTEMPNuevo.isnull["IID"])
                {
                    auxPar.Value = oCPRECTEMPNuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCPRECTEMPNuevo.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCPRECTEMPNuevo.IID_FECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCPRECTEMPNuevo.isnull["IID_HORA"])
                {
                    auxPar.Value = oCPRECTEMPNuevo.IID_HORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@IDAnt", OleDbType.VarChar);
                if (!(bool)oCPRECTEMPAnterior.isnull["IID"])
                {
                    auxPar.Value = oCPRECTEMPAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  PRECTEMP
  set

PRODUCTO=@PRODUCTO,

PRECIO1=@PRECIO1,

PRECIO2=@PRECIO2,

PRECIO3=@PRECIO3,

PRECIO4=@PRECIO4,

PRECIO5=@PRECIO5,

SUGERIDO=@SUGERIDO,

ID=@ID,

ID_FECHA=@ID_FECHA,

ID_HORA=@ID_HORA
  where 

ID=@IDAnt
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



        public CPRECTEMPBE seleccionarPRECTEMP(CPRECTEMPBE oCPRECTEMP, OleDbTransaction st)
        {




            CPRECTEMPBE retorno = new CPRECTEMPBE();

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;

                String CmdTxt = @"select * from PRECTEMP where
 ID=@ID  ";


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                auxPar.Value = oCPRECTEMP.IID;
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

                    if (dr["PRODUCTO"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTO = (string)(dr["PRODUCTO"]);
                    }

                    if (dr["PRECIO1"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO1 = (double)(dr["PRECIO1"]);
                    }

                    if (dr["PRECIO2"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO2 = (double)(dr["PRECIO2"]);
                    }

                    if (dr["PRECIO3"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO3 = (double)(dr["PRECIO3"]);
                    }

                    if (dr["PRECIO4"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO4 = (double)(dr["PRECIO4"]);
                    }

                    if (dr["PRECIO5"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO5 = (double)(dr["PRECIO5"]);
                    }

                    if (dr["SUGERIDO"] != System.DBNull.Value)
                    {
                        retorno.ISUGERIDO = (double)(dr["SUGERIDO"]);
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










        public DataSet enlistarPRECTEMP()
        {

            DataSet retorno;
            try
            {
                retorno = OleDbHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PRECTEMP_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }





        public DataSet enlistarCortoPRECTEMP()
        {
            DataSet retorno;
            try
            {

                retorno = OleDbHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PRECTEMP_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public int ExistePRECTEMP(CPRECTEMPBE oCPRECTEMP, OleDbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                auxPar.Value = oCPRECTEMP.IID;
                parts.Add(auxPar);

                OleDbParameter[] arParms = new OleDbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from PRECTEMP where

  ID=@ID  
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


        /*

        public CPRECTEMPBE AgregarPRECTEMP(CPRECTEMPBE oCPRECTEMP, OleDbTransaction st)
        {
            try
            {
                int iRes = ExistePRECTEMP(oCPRECTEMP, st);
                if (iRes == 1)
                {
                    this.IComentario = "El PRECTEMP ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarPRECTEMPD(oCPRECTEMP, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }*/


        public bool BorrarPRECTEMP(CPRECTEMPBE oCPRECTEMP, OleDbTransaction st)
        {
            try
            {
                int iRes = ExistePRECTEMP(oCPRECTEMP, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PRECTEMP no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarPRECTEMPD(oCPRECTEMP, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarPRECTEMP(CPRECTEMPBE oCPRECTEMPNuevo, CPRECTEMPBE oCPRECTEMPAnterior, OleDbTransaction st)
        {
            try
            {
                int iRes = ExistePRECTEMP(oCPRECTEMPAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PRECTEMP no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarPRECTEMPD(oCPRECTEMPNuevo, oCPRECTEMPAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CPRECTEMPD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
