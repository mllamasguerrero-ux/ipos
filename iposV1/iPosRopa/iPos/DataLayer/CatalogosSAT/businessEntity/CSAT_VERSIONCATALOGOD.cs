using ConexionesBD;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.CatalogosSAT.businessEntity
{
    public class CSAT_VERSIONCATALOGOD
    {
        private string sCadenaConexion;

        private string iComentario;
        public string IComentario
        {
            get
            {
                return iComentario;
            }
            set
            {
                iComentario = value;
            }
        }

        public CSAT_VERSIONCATALOGOD()
        {
            sCadenaConexion = ConexionBD.ConexionString();
        }

        public CSAT_VERSIONCATALOGOD(string conexion)
        {
            sCadenaConexion = conexion;
        }

        public CSAT_VERSIONCATALOGOBE SeleccionarVersionInfo()
        {
            try
            {
                CSAT_VERSIONCATALOGOBE versionCatalogoInfo = new CSAT_VERSIONCATALOGOBE();

                FbDataReader dr = null;

                FbConnection pcn = null;

                ArrayList parts = new ArrayList();

                String CmdTxt = @"SELECT * FROM SAT_VERSIONCATALOGO";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                dr = SqlHelper.ExecuteReader(sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);


                if (dr.Read())
                {
                    versionCatalogoInfo.Date = (DateTime)dr["FECHA"];
                    versionCatalogoInfo.Version = (long)dr["VERSION_CATALOGO"];
                }

                SqlHelper.CloseReader(dr, pcn);

                return versionCatalogoInfo;
            }
            catch (Exception e)
            {
                iComentario = e.Message + " - " + e.StackTrace;
                return null;
            }
        }

        public bool ActualizarVersion(CSAT_VERSIONCATALOGOBE version, FbTransaction fbTransaction)
        {
            try
            {
                string query = "UPDATE SAT_VERSIONCATALOGO SET VERSION_CATALOGO = @VERSION, FECHA = @FECHA";

                ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@VERSION", FbDbType.BigInt);
                auxPar.Value = version.Version;
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                auxPar.Value = version.Date;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (fbTransaction == null)
                    SqlHelper.ExecuteNonQuery(sCadenaConexion, CommandType.Text, query, arParms);
                else
                    SqlHelper.ExecuteNonQuery(fbTransaction, CommandType.Text, query, arParms);

                return true;
            }
            catch(Exception e)
            {
                iComentario = e.Message;
                return false;
            }
        }
    }
}
