
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


    public class CM_KITSD: IMKITSD
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


        public bool AgregarM_KITSD(CM_KITSBE oCM_KITS, string strFileName, 
                                    //OleDbTransaction st, 
                                    string strOleDbConn)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@PRODUCTO", OleDbType.VarChar);
                if (!(bool)oCM_KITS.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCM_KITS.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PARTE", OleDbType.VarChar);
                if (!(bool)oCM_KITS.isnull["IPARTE"])
                {
                    auxPar.Value = oCM_KITS.IPARTE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Double);
                if (!(bool)oCM_KITS.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCM_KITS.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = 0.0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTO", OleDbType.Double);
                if (!(bool)oCM_KITS.isnull["ICOSTO"])
                {
                    auxPar.Value = oCM_KITS.ICOSTO;
                }
                else
                {
                    auxPar.Value = 0.0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCM_KITS.isnull["IID"])
                {
                    auxPar.Value = oCM_KITS.IID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCM_KITS.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_KITS.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue; 
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCM_KITS.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_KITS.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO M_KITS
      (
    
PRODUCTO,

PARTE,

CANTIDAD,

COSTO,

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
                return true;
            }
        }


        [AutoComplete]
        public bool BorrarM_KITSD(CM_KITSBE oCM_KITS, OleDbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@PRODUCTO", OleDbType.VarChar);
                auxPar.Value = oCM_KITS.IPRODUCTO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PARTE", OleDbType.VarChar);
                auxPar.Value = oCM_KITS.IPARTE;
                parts.Add(auxPar);



                string commandText = @"  Delete from M_KITS
  where

  PRODUCTO=@PRODUCTO and 

  PARTE=@PARTE
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
        public bool CambiarM_KITSD(CM_KITSBE oCM_KITSNuevo, CM_KITSBE oCM_KITSAnterior, OleDbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@PRODUCTO", OleDbType.VarChar);
                if (!(bool)oCM_KITSNuevo.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCM_KITSNuevo.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PARTE", OleDbType.VarChar);
                if (!(bool)oCM_KITSNuevo.isnull["IPARTE"])
                {
                    auxPar.Value = oCM_KITSNuevo.IPARTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Double);
                if (!(bool)oCM_KITSNuevo.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCM_KITSNuevo.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCM_KITSNuevo.isnull["IID"])
                {
                    auxPar.Value = oCM_KITSNuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCM_KITSNuevo.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_KITSNuevo.IID_FECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCM_KITSNuevo.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_KITSNuevo.IID_HORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PRODUCTOAnt", OleDbType.VarChar);
                if (!(bool)oCM_KITSAnterior.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCM_KITSAnterior.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PARTEAnt", OleDbType.VarChar);
                if (!(bool)oCM_KITSAnterior.isnull["IPARTE"])
                {
                    auxPar.Value = oCM_KITSAnterior.IPARTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  M_KITS
  set

PRODUCTO=@PRODUCTO,

PARTE=@PARTE,

CANTIDAD=@CANTIDAD,

ID=@ID,

ID_FECHA=@ID_FECHA,

ID_HORA=@ID_HORA
  where 

PRODUCTO=@PRODUCTOAnt and

PARTE=@PARTEAnt
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
        public CM_KITSBE seleccionarM_KITS(CM_KITSBE oCM_KITS, OleDbTransaction st)
        {




            CM_KITSBE retorno = new CM_KITSBE();

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;

                String CmdTxt = @"select * from M_KITS where
 PRODUCTO=@PRODUCTO    and
 PARTE=@PARTE  ";


                auxPar = new OleDbParameter("@PRODUCTO", OleDbType.VarChar);
                auxPar.Value = oCM_KITS.IPRODUCTO;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@PARTE", OleDbType.VarChar);
                auxPar.Value = oCM_KITS.IPARTE;
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

                    if (dr["PARTE"] != System.DBNull.Value)
                    {
                        retorno.IPARTE = (string)(dr["PARTE"]);
                    }

                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDAD = (double)(dr["CANTIDAD"]);
                    }

                    if (dr["COSTO"] != System.DBNull.Value)
                    {
                        retorno.ICOSTO = (double)(dr["COSTO"]);
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









        [AutoComplete]
        public DataSet enlistarM_KITS()
        {

            DataSet retorno;
            try
            {
                retorno = OleDbHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_M_KITS_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoM_KITS()
        {
            DataSet retorno;
            try
            {

                retorno = OleDbHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_M_KITS_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteM_KITS(CM_KITSBE oCM_KITS, OleDbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@PRODUCTO", OleDbType.VarChar);
                auxPar.Value = oCM_KITS.IPRODUCTO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PARTE", OleDbType.VarChar);
                auxPar.Value = oCM_KITS.IPARTE;
                parts.Add(auxPar);

                OleDbParameter[] arParms = new OleDbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from M_KITS where

  PRODUCTO=@PRODUCTO    and

  PARTE=@PARTE  
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
        public CM_KITSBE AgregarM_KITS(CM_KITSBE oCM_KITS, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteM_KITS(oCM_KITS, st);
                if (iRes == 1)
                {
                    this.IComentario = "El M_KITS ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarM_KITSD(oCM_KITS, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }*/


        public bool BorrarM_KITS(CM_KITSBE oCM_KITS, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteM_KITS(oCM_KITS, st);
                if (iRes == 0)
                {
                    this.IComentario = "El M_KITS no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarM_KITSD(oCM_KITS, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarM_KITS(CM_KITSBE oCM_KITSNuevo, CM_KITSBE oCM_KITSAnterior, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteM_KITS(oCM_KITSAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El M_KITS no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarM_KITSD(oCM_KITSNuevo, oCM_KITSAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CM_KITSD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
