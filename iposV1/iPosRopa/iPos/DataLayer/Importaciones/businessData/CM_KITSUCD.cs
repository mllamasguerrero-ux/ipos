using ConexionesBD;
using DataLayer.Importaciones.businessEntity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Importaciones.businessData
{
    public class CM_KITSUCD
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

        public CM_KITSUCD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
        }

        public bool AgregarM_KITSUCD(CM_KITSUCBE oCM_KITSUC, string strFileName, OleDbTransaction st, string strOleDbConn)
        {
            try
            {
                ArrayList parts = new ArrayList();
                OleDbParameter auxPar;

                auxPar = new OleDbParameter("@CLAVESUC", OleDbType.VarChar);
                if (!(bool)oCM_KITSUC.isnull["ICLAVESUC"])
                {
                    auxPar.Value = oCM_KITSUC.ICLAVESUC;
                }
                else
                {
                    auxPar.Value = String.Empty;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@KITID", OleDbType.VarChar);
                if (!(bool)oCM_KITSUC.isnull["IKITID"])
                {
                    auxPar.Value = oCM_KITSUC.IKITID;
                }
                else
                {
                    auxPar.Value = String.Empty;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO   " + strFileName + @" 
      (
    
CLAVESUC,

KITID
         )

Values (

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

        public bool BorrarM_KITSUCD(CM_KITSUCBE oCM_KITSUC, OleDbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@CLAVESUC", OleDbType.VarChar);
                auxPar.Value = oCM_KITSUC.ICLAVESUC;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@KITID", OleDbType.VarChar);
                auxPar.Value = oCM_KITSUC.IKITID;
                parts.Add(auxPar);


                string commandText = @"  Delete from M_KITSUC
  where

  CLAVESUC=@CLAVESUC and 

  KITID=@KITID

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

        public CM_KITSUCBE seleccionarM_KITSUC(CM_KITSUCBE oCM_KITSUC, OleDbTransaction st)
        {
            CM_KITSUCBE retorno = new CM_KITSUCBE();

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;

                String CmdTxt = @"select * from M_KITSUC";

                OleDbParameter[] arParms = new OleDbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                OleDbDataReader dr;
                if (st == null)
                    dr = OleDbHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, arParms);
                else
                    dr = OleDbHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["CLAVESUC"] != System.DBNull.Value)
                    {
                        retorno.ICLAVESUC = (string)(dr["CLAVESUC"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.IKITID = (string)(dr["KITID"]);
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
    }
}
