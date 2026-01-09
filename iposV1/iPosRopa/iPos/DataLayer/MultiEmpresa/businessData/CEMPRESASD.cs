
using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Collections;
using ConexionesBD;
using System.IO;
using System.Collections.Generic;
namespace iPos
{
    public class CEMPRESASD
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

        public CEMPRESASBE AgregarEMPRESASD(CEMPRESASBE oCEMPRESAS, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@EM_NOMBRE", FbDbType.VarChar);
                if (!(bool)oCEMPRESAS.isnull["IEM_NOMBRE"])
                {
                    auxPar.Value = oCEMPRESAS.IEM_NOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@EM_DATABASE", FbDbType.VarChar);
                if (!(bool)oCEMPRESAS.isnull["IEM_DATABASE"])
                {
                    auxPar.Value = oCEMPRESAS.IEM_DATABASE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@EM_USUARIO", FbDbType.VarChar);
                if (!(bool)oCEMPRESAS.isnull["IEM_USUARIO"])
                {
                    auxPar.Value = oCEMPRESAS.IEM_USUARIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@EM_PASSWORD", FbDbType.VarChar);
                if (!(bool)oCEMPRESAS.isnull["IEM_PASSWORD"])
                {
                    auxPar.Value = oCEMPRESAS.IEM_PASSWORD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@EM_SERVER", FbDbType.VarChar);
                if (!(bool)oCEMPRESAS.isnull["IEM_SERVER"])
                {
                    auxPar.Value = oCEMPRESAS.IEM_SERVER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@EM_CAJA", FbDbType.BigInt);
                if (!(bool)oCEMPRESAS.isnull["IEM_CAJA"])
                {
                    auxPar.Value = oCEMPRESAS.IEM_CAJA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@HABILITAR_IMPEXP_AUT", FbDbType.VarChar);
                if (!(bool)oCEMPRESAS.isnull["IHABILITAR_IMPEXP_AUT"])
                {
                    auxPar.Value = oCEMPRESAS.IHABILITAR_IMPEXP_AUT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@EM_CAJA_NOMBRE", FbDbType.VarChar);
                if (!(bool)oCEMPRESAS.isnull["IEM_CAJA_NOMBRE"])
                {
                    auxPar.Value = oCEMPRESAS.IEM_CAJA_NOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@ESMATRIZ", FbDbType.VarChar);
                if (!(bool)oCEMPRESAS.isnull["IESMATRIZ"])
                {
                    auxPar.Value = oCEMPRESAS.IESMATRIZ;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RED", FbDbType.Integer);
                if (!(bool)oCEMPRESAS.isnull["IRED"])
                {
                    auxPar.Value = oCEMPRESAS.IRED;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@GREEN", FbDbType.Integer);
                if (!(bool)oCEMPRESAS.isnull["IGREEN"])
                {
                    auxPar.Value = oCEMPRESAS.IGREEN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@BLUE", FbDbType.Integer);
                if (!(bool)oCEMPRESAS.isnull["IBLUE"])
                {
                    auxPar.Value = oCEMPRESAS.IBLUE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@HAB_POOLING", FbDbType.VarChar);
                if (!(bool)oCEMPRESAS.isnull["IHAB_POOLING"])
                {
                    auxPar.Value = oCEMPRESAS.IHAB_POOLING;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REPLICADOR", FbDbType.VarChar);
                if (!(bool)oCEMPRESAS.isnull["IREPLICADOR"])
                {
                    auxPar.Value = oCEMPRESAS.IREPLICADOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO EMPRESAS
      (
    
EM_NOMBRE,
EM_DATABASE,
EM_USUARIO,
EM_PASSWORD,
EM_SERVER,
EM_CAJA,
HABILITAR_IMPEXP_AUT,
EM_CAJA_NOMBRE,
ESMATRIZ,
RED,
GREEN,
BLUE,
HAB_POOLING, 
REPLICADOR
         )
Values (
@EM_NOMBRE,
@EM_DATABASE,
@EM_USUARIO,
@EM_PASSWORD,
@EM_SERVER,
@EM_CAJA,
@HABILITAR_IMPEXP_AUT,
@EM_CAJA_NOMBRE,
@ESMATRIZ,
@RED,
@GREEN,
@BLUE,
@HAB_POOLING,
@REPLICADOR
); ";
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);
                return oCEMPRESAS;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }
        [AutoComplete]
        public bool BorrarEMPRESASD(CEMPRESASBE oCEMPRESAS, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@EM_NOMBRE", FbDbType.VarChar);
                auxPar.Value = oCEMPRESAS.IEM_NOMBRE;
                parts.Add(auxPar);
                string commandText = @"  Delete from EMPRESAS
  where
  EM_NOMBRE=@EM_NOMBRE
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
        [AutoComplete]
        public bool CambiarEMPRESASD(CEMPRESASBE oCEMPRESASNuevo, CEMPRESASBE oCEMPRESASAnterior, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@EM_NOMBRE", FbDbType.VarChar);
                if (!(bool)oCEMPRESASNuevo.isnull["IEM_NOMBRE"])
                {
                    auxPar.Value = oCEMPRESASNuevo.IEM_NOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@EM_DATABASE", FbDbType.VarChar);
                if (!(bool)oCEMPRESASNuevo.isnull["IEM_DATABASE"])
                {
                    auxPar.Value = oCEMPRESASNuevo.IEM_DATABASE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@EM_USUARIO", FbDbType.VarChar);
                if (!(bool)oCEMPRESASNuevo.isnull["IEM_USUARIO"])
                {
                    auxPar.Value = oCEMPRESASNuevo.IEM_USUARIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@EM_PASSWORD", FbDbType.VarChar);
                if (!(bool)oCEMPRESASNuevo.isnull["IEM_PASSWORD"])
                {
                    auxPar.Value = oCEMPRESASNuevo.IEM_PASSWORD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@EM_SERVER", FbDbType.VarChar);
                if (!(bool)oCEMPRESASNuevo.isnull["IEM_SERVER"])
                {
                    auxPar.Value = oCEMPRESASNuevo.IEM_SERVER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);







                auxPar = new FbParameter("@EM_CAJA", FbDbType.BigInt);
                if (!(bool)oCEMPRESASNuevo.isnull["IEM_CAJA"])
                {
                    auxPar.Value = oCEMPRESASNuevo.IEM_CAJA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@HABILITAR_IMPEXP_AUT", FbDbType.VarChar);
                if (!(bool)oCEMPRESASNuevo.isnull["IHABILITAR_IMPEXP_AUT"])
                {
                    auxPar.Value = oCEMPRESASNuevo.IHABILITAR_IMPEXP_AUT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@EM_CAJA_NOMBRE", FbDbType.VarChar);
                if (!(bool)oCEMPRESASNuevo.isnull["IEM_CAJA_NOMBRE"])
                {
                    auxPar.Value = oCEMPRESASNuevo.IEM_CAJA_NOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@ESMATRIZ", FbDbType.VarChar);
                if (!(bool)oCEMPRESASNuevo.isnull["IESMATRIZ"])
                {
                    auxPar.Value = oCEMPRESASNuevo.IESMATRIZ;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@RED", FbDbType.Integer);
                if (!(bool)oCEMPRESASNuevo.isnull["IRED"])
                {
                    auxPar.Value = oCEMPRESASNuevo.IRED;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@GREEN", FbDbType.Integer);
                if (!(bool)oCEMPRESASNuevo.isnull["IGREEN"])
                {
                    auxPar.Value = oCEMPRESASNuevo.IGREEN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@BLUE", FbDbType.Integer);
                if (!(bool)oCEMPRESASNuevo.isnull["IBLUE"])
                {
                    auxPar.Value = oCEMPRESASNuevo.IBLUE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@HAB_POOLING", FbDbType.VarChar);
                if (!(bool)oCEMPRESASNuevo.isnull["IHAB_POOLING"])
                {
                    auxPar.Value = oCEMPRESASNuevo.IHAB_POOLING;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REPLICADOR", FbDbType.VarChar);
                if (!(bool)oCEMPRESASNuevo.isnull["IREPLICADOR"])
                {
                    auxPar.Value = oCEMPRESASNuevo.IREPLICADOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@EM_NOMBREAnt", FbDbType.VarChar);
                if (!(bool)oCEMPRESASAnterior.isnull["IEM_NOMBRE"])
                {
                    auxPar.Value = oCEMPRESASAnterior.IEM_NOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                string commandText = @"
  update  EMPRESAS
  set
EM_NOMBRE=@EM_NOMBRE,
EM_DATABASE=@EM_DATABASE,
EM_USUARIO=@EM_USUARIO,
EM_PASSWORD=@EM_PASSWORD,
EM_SERVER=@EM_SERVER,
EM_CAJA = @EM_CAJA,
HABILITAR_IMPEXP_AUT = @HABILITAR_IMPEXP_AUT,
EM_CAJA_NOMBRE =  @EM_CAJA_NOMBRE,
ESMATRIZ = @ESMATRIZ,
RED = @RED,
BLUE = @BLUE,
GREEN = @GREEN,
HAB_POOLING = @HAB_POOLING, 
REPLICADOR = @REPLICADOR
  where 
EM_NOMBRE=@EM_NOMBREAnt
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



        public bool AddBaseDirectoryColumn(FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                string commandText = @"  ALTER TABLE EMPRESAS ADD BASEDIRECTORY VARCHAR(255);";


                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);



                System.Collections.ArrayList parts2 = new ArrayList();
                string commandText2 = @" UPDATE EMPRESAS SET BASEDIRECTORY = @BASEDIRECTORY";
                FbParameter auxPar;
                auxPar = new FbParameter("@BASEDIRECTORY", FbDbType.VarChar);
                auxPar.Value = System.AppDomain.CurrentDomain.BaseDirectory;
                parts2.Add(auxPar);

                FbParameter[] arParms2 = new FbParameter[parts2.Count];
                parts2.CopyTo(arParms2, 0);
                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText2, arParms2);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText2, arParms2);


                return true;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool AddColorColumn(FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                string commandText = @"  ALTER TABLE EMPRESAS ADD RED INTEGER, ADD GREEN INTEGER, ADD BLUE INTEGER;";


                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);



                System.Collections.ArrayList parts2 = new ArrayList();
                string commandText2 = @" UPDATE EMPRESAS SET RED = @RED , GREEN = @GREEN , BLUE = @BLUE";
                FbParameter auxPar;
                auxPar = new FbParameter("@RED", FbDbType.Numeric);
                auxPar.Value = 50;
                parts2.Add(auxPar);
                auxPar = new FbParameter("@GREEN", FbDbType.Numeric);
                auxPar.Value = 120;
                parts2.Add(auxPar);
                auxPar = new FbParameter("@BLUE", FbDbType.Numeric);
                auxPar.Value = 180;
                parts2.Add(auxPar);

                FbParameter[] arParms2 = new FbParameter[parts2.Count];
                parts2.CopyTo(arParms2, 0);
                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText2, arParms2);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText2, arParms2);


                return true;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        [AutoComplete]
        public CEMPRESASBE seleccionarEMPRESAS(CEMPRESASBE oCEMPRESAS, FbTransaction st)
        {
            bool bAddBASEDIRECTORYCOLUMN = false;
            bool bAddCOLORCOLUMN = false;
            CEMPRESASBE retorno = new CEMPRESASBE();
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                String CmdTxt = @"select * from EMPRESAS where EM_NOMBRE=@EM_NOMBRE  ";
                auxPar = new FbParameter("@EM_NOMBRE", FbDbType.VarChar);
                auxPar.Value = oCEMPRESAS.IEM_NOMBRE;
                parts.Add(auxPar);
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                if (dr.Read())
                {
                    retorno = FromDataReaderToEmpresas(ref dr, ref bAddCOLORCOLUMN, ref bAddBASEDIRECTORYCOLUMN);
                }
                else
                {
                    retorno = null;
                }

                if (bAddBASEDIRECTORYCOLUMN)
                {
                    AddBaseDirectoryColumn(st);
                }

                if (bAddCOLORCOLUMN)
                {
                    AddColorColumn(st);
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
        [AutoComplete]
        public DataSet enlistarEMPRESAS()
        {
            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_EMPRESAS_enlistar");
                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }
        [AutoComplete]
        public DataSet enlistarCortoEMPRESAS()
        {
            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_EMPRESAS_enlistarCorto");
                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }
        [AutoComplete]
        public int ExisteEMPRESAS(CEMPRESASBE oCEMPRESAS, FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@EM_NOMBRE", FbDbType.VarChar);
                auxPar.Value = oCEMPRESAS.IEM_NOMBRE;
                parts.Add(auxPar);
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from EMPRESAS where
  EM_NOMBRE=@EM_NOMBRE  
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
        public CEMPRESASBE AgregarEMPRESAS(CEMPRESASBE oCEMPRESAS, FbTransaction st)
        {
            try
            {
                int iRes = ExisteEMPRESAS(oCEMPRESAS, st);
                if (iRes == 1)
                {
                    this.IComentario = "El EMPRESAS ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                CEMPRESASBE retorno;
                retorno = AgregarEMPRESASD(oCEMPRESAS, st);
                string dataLocation = retorno.IEM_DATABASE.Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
                string dataBasePath = Path.GetDirectoryName(dataLocation);
                if (!Directory.Exists(dataBasePath))
                {
                    Directory.CreateDirectory(dataBasePath);
                }
                if (!File.Exists(dataLocation))
                {
                    File.Copy(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\EmptyData\\IPOSDB",
                             dataLocation);
                }
                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }
        public bool BorrarEMPRESAS(CEMPRESASBE oCEMPRESAS, FbTransaction st)
        {
            try
            {
                int iRes = ExisteEMPRESAS(oCEMPRESAS, st);
                if (iRes == 0)
                {
                    this.IComentario = "El EMPRESAS no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarEMPRESASD(oCEMPRESAS, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }
        public bool CambiarEMPRESAS(CEMPRESASBE oCEMPRESASNuevo, CEMPRESASBE oCEMPRESASAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteEMPRESAS(oCEMPRESASAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El EMPRESAS no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarEMPRESASD(oCEMPRESASNuevo, oCEMPRESASAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }

        public List<CEMPRESASBE> SeleccionarTodasEmpresas(FbTransaction st)
        {
            FbDataReader dr = null;
            FbConnection pcn = null;
            bool bAddBASEDIRECTORYCOLUMN = false;
            bool bAddCOLORCOLUMN = false;
            List<CEMPRESASBE> retorno = new List<CEMPRESASBE>();

            try
            {
                string query = @"SELECT * FROM EMPRESAS";

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, query, out pcn);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, query);
                
                while(dr.Read())
                {
                    CEMPRESASBE empresasBE = FromDataReaderToEmpresas(ref dr, ref bAddCOLORCOLUMN, ref bAddBASEDIRECTORYCOLUMN);

                    if (bAddBASEDIRECTORYCOLUMN)
                    {
                        AddBaseDirectoryColumn(st);
                    }

                    if (bAddCOLORCOLUMN)
                    {
                        AddColorColumn(st);
                    }

                    retorno.Add(empresasBE);
                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                return retorno;
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                this.iComentario = ex.Message + " " + ex.StackTrace;

                return null;
            }
        }

        public CEMPRESASBE FromDataReaderToEmpresas(ref FbDataReader dr,
                                                   ref bool bAddCOLORCOLUMN,
                                                   ref bool bAddBASEDIRECTORYCOLUMN)
        {
            CEMPRESASBE retorno = new CEMPRESASBE();

            if (dr["EM_NOMBRE"] != System.DBNull.Value)
            {
                retorno.IEM_NOMBRE = (string)(dr["EM_NOMBRE"]);
            }
            if (dr["EM_DATABASE"] != System.DBNull.Value)
            {
                retorno.IEM_DATABASE = (string)(dr["EM_DATABASE"]);
            }
            if (dr["EM_USUARIO"] != System.DBNull.Value)
            {
                retorno.IEM_USUARIO = (string)(dr["EM_USUARIO"]);
            }
            if (dr["EM_PASSWORD"] != System.DBNull.Value)
            {
                retorno.IEM_PASSWORD = (string)(dr["EM_PASSWORD"]);
            }
            if (dr["EM_SERVER"] != System.DBNull.Value)
            {
                retorno.IEM_SERVER = (string)(dr["EM_SERVER"]);
            }

            try
            {
                if (dr["EM_CAJA"] != System.DBNull.Value)
                {
                    retorno.IEM_CAJA = int.Parse(dr["EM_CAJA"].ToString());
                }
            }
            catch
            {
            }

            if (dr["HABILITAR_IMPEXP_AUT"] != System.DBNull.Value)
            {
                retorno.IHABILITAR_IMPEXP_AUT = (string)(dr["HABILITAR_IMPEXP_AUT"]);
            }

            if (dr["EM_CAJA_NOMBRE"] != System.DBNull.Value)
            {
                retorno.IEM_CAJA_NOMBRE = (string)(dr["EM_CAJA_NOMBRE"]);
            }

            if (dr["ESMATRIZ"] != System.DBNull.Value)
            {
                retorno.IESMATRIZ = (string)(dr["ESMATRIZ"]);
            }

            try
            {

                if (dr["BASEDIRECTORY"] != System.DBNull.Value)
                {
                    retorno.IESMATRIZ = (string)(dr["ESMATRIZ"]);
                }

            }
            catch
            {
                bAddBASEDIRECTORYCOLUMN = true;
                retorno.IBASEDIRECTORY = System.AppDomain.CurrentDomain.BaseDirectory;

            }



            try
            {

                if (dr["RED"] != System.DBNull.Value)
                {
                    retorno.IRED = (int)(dr["RED"]);
                    retorno.IGREEN = (int)(dr["GREEN"]);
                    retorno.IBLUE = (int)(dr["BLUE"]);
                }

            }
            catch
            {
                bAddCOLORCOLUMN = true;
                retorno.IRED = 50;
                retorno.IGREEN = 120;
                retorno.IBLUE = 180;

            }

            try
            {
                if (dr["HAB_POOLING"] != System.DBNull.Value)
                {
                    retorno.IHAB_POOLING = (string)(dr["HAB_POOLING"]);
                }
                else
                {
                    retorno.IHAB_POOLING = "N";
                }
            }
            catch
            {
                retorno.IHAB_POOLING = "N";
            }

            try
            {
                if (dr["REPLICADOR"] != System.DBNull.Value)
                {
                    retorno.IREPLICADOR = (string)(dr["REPLICADOR"]);
                }
                else
                {
                    retorno.IREPLICADOR = "N";
                }
            }
            catch
            {
                retorno.IREPLICADOR = "N";
            }

            return retorno;
        }

        public CEMPRESASD()
        {
            this.sCadenaConexion = ConexionMEBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";
            //
            // TODO: Add constructor logic here
            //
        }

        public CEMPRESASD(string cadenaConexion)
        {
            this.sCadenaConexion = cadenaConexion;
        }
    }
}
