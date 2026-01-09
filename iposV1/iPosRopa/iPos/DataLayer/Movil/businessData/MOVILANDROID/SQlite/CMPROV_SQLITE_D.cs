using iPosBusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Collections;
using System.Data;


namespace iPosData
{

    public class CMPROV_SQLITE_D : IMPROVD
    {

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



        public bool CreateTableMPROV_MOVIL(string strOleDbConn)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(strOleDbConn);
            try
            {

                m_dbConnection.Open();



                string sql = @"CREATE TABLE Proveedor ( 
                                                        Clave   TEXT,
                                                        Nombre   TEXT,
                                                        Domicilio   TEXT,
                                                        Colonia   TEXT,
                                                        Ciudad   TEXT,
                                                        Estado   TEXT,
                                                        CodigoPostal   TEXT,
                                                        Telefono1   TEXT,
                                                        Telefono2   TEXT,
                                                        Contacto1   TEXT,
                                                        Contacto2   TEXT,
                                                        Rfc   TEXT,
                                                        SucursalRel   TEXT

                            ); ";

                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                m_dbConnection.Close();
                m_dbConnection.Dispose();
                command.Dispose();

                GC.Collect();

            }
            catch { }
            finally { try { m_dbConnection.Close(); } catch { } }
            return true;
        }




        public bool AgregarM_PROVD(CM_PROVBE oCM_PROV, string strFileName,
                                    string strOleDbConn)
        {


            try
            {





                System.Collections.ArrayList parts = new ArrayList();
                SQLiteParameter auxPar;





                auxPar = new SQLiteParameter("$Clave", DbType.String);
                if (!(bool)oCM_PROV.isnull["IPROVEEDOR"])
                {
                    auxPar.Value = oCM_PROV.IPROVEEDOR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$Nombre", DbType.String);
                if (!(bool)oCM_PROV.isnull["INOMBRE"])
                {
                    auxPar.Value = oCM_PROV.INOMBRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$Domicilio", DbType.String);
                if (!(bool)oCM_PROV.isnull["ICALLE"])
                {
                    auxPar.Value = oCM_PROV.ICALLE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$Colonia", DbType.String);
                if (!(bool)oCM_PROV.isnull["ICOLONIA"])
                {
                    auxPar.Value = oCM_PROV.ICOLONIA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$Ciudad", DbType.String);
                if (!(bool)oCM_PROV.isnull["ICIUDAD"])
                {
                    auxPar.Value = oCM_PROV.ICIUDAD;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$Estado", DbType.String);
                if (!(bool)oCM_PROV.isnull["IESTADO"])
                {
                    auxPar.Value = oCM_PROV.IESTADO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$CodigoPostal", DbType.String);
                if (!(bool)oCM_PROV.isnull["ICP"])
                {
                    auxPar.Value = oCM_PROV.ICP;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$Telefono1", DbType.String);
                if (!(bool)oCM_PROV.isnull["ITEL1"])
                {
                    auxPar.Value = oCM_PROV.ITEL1;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$Telefono2", DbType.String);
                if (!(bool)oCM_PROV.isnull["ITEL2"])
                {
                    auxPar.Value = oCM_PROV.ITEL2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$Contacto1", DbType.String);
                if (!(bool)oCM_PROV.isnull["ICONTACTO"])
                {
                    auxPar.Value = oCM_PROV.ICONTACTO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$Contacto2", DbType.String);
                if (!(bool)oCM_PROV.isnull["ICONTACTO2"])
                {
                    auxPar.Value = oCM_PROV.ICONTACTO2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$Rfc", DbType.String);
                if (!(bool)oCM_PROV.isnull["IRFC"])
                {
                    auxPar.Value = oCM_PROV.IRFC;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$SucursalRel", DbType.String);
                auxPar.Value = "";
                parts.Add(auxPar);

                //auxPar = new SQLiteParameter("$SucursalRel", DbType.String);
                //if (!(bool)oCM_PROV.isnull["ISUCURSALREL"])
                //{
                //    auxPar.Value = oCM_PROV.ISUCURSALREL;
                //}
                //else
                //{
                //    auxPar.Value = "";
                //}
                //parts.Add(auxPar);





                string commandText = @"
        INSERT INTO Proveedor
      (
Clave,
Nombre,
Domicilio,
Colonia,
Ciudad,
Estado,
CodigoPostal,
Telefono1,
Telefono2,
Contacto1,
Contacto2,
Rfc,
SucursalRel

         )

Values (
$Clave,
$Nombre,
$Domicilio,
$Colonia,
$Ciudad,
$Estado,
$CodigoPostal,
$Telefono1,
$Telefono2,
$Contacto1,
$Contacto2,
$Rfc,
$SucursalRel



); ";

                SQLiteParameter[] arParms = new SQLiteParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                using (SQLiteConnection conn = new SQLiteConnection(strOleDbConn))
                {
                    conn.Open();
                    using (var cmd = new SQLiteCommand(commandText, conn))
                    {
                        using (SQLiteHelper sq = new SQLiteHelper(cmd))
                        {
                            sq.Execute(commandText, arParms);
                        }
                    }
                    conn.Close();
                }



                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


    }
}
