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
    public class CSINCCONFIGD
    {
        private string sCadenaConexion;

        public static string ComentarioSincConfig = "";

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

        public CSINCCONFIGBE AgregarSINCCONFIGD(CSINCCONFIGBE oCSINCCONFIG, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@HAB_SINC", FbDbType.Char);
                if (!(bool)oCSINCCONFIG.isnull["IHAB_SINC"])
                {
                    auxPar.Value = oCSINCCONFIG.IHAB_SINC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ES_COPIA", FbDbType.Char);
                if (!(bool)oCSINCCONFIG.isnull["IES_COPIA"])
                {
                    auxPar.Value = oCSINCCONFIG.IES_COPIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@C_CONEXORIG", FbDbType.VarChar);
                if (!(bool)oCSINCCONFIG.isnull["IC_CONEXORIG"])
                {
                    auxPar.Value = oCSINCCONFIG.IC_CONEXORIG;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@C_SINCAUTO", FbDbType.Char);
                if (!(bool)oCSINCCONFIG.isnull["IC_SINCAUTO"])
                {
                    auxPar.Value = oCSINCCONFIG.IC_SINCAUTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@C_FECHAULTISINC", FbDbType.Date);
                if (!(bool)oCSINCCONFIG.isnull["IC_FECHAULTISINC"])
                {
                    auxPar.Value = oCSINCCONFIG.IC_FECHAULTISINC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@C_LIMPNOSINC", FbDbType.Char);
                if (!(bool)oCSINCCONFIG.isnull["IC_LIMPNOSINC"])
                {
                    auxPar.Value = oCSINCCONFIG.IC_LIMPNOSINC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@O_ULTIFECHACAMBIO", FbDbType.Date);
                if (!(bool)oCSINCCONFIG.isnull["IO_ULTIFECHACAMBIO"])
                {
                    auxPar.Value = oCSINCCONFIG.IO_ULTIFECHACAMBIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@O_FECHACAMBIOMANUAL", FbDbType.Char);
                if (!(bool)oCSINCCONFIG.isnull["IO_FECHACAMBIOMANUAL"])
                {
                    auxPar.Value = oCSINCCONFIG.IO_FECHACAMBIOMANUAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO SINCCONFIG
      (
    
HAB_SINC,

ES_COPIA,

C_CONEXORIG,

C_SINCAUTO,

C_FECHAULTISINC,

C_LIMPNOSINC,

O_ULTIFECHACAMBIO,

O_FECHACAMBIOMANUAL
         )

Values (

@HAB_SINC,

@ES_COPIA,

@C_CONEXORIG,

@C_SINCAUTO,

@C_FECHAULTISINC,

@C_LIMPNOSINC,

@O_ULTIFECHACAMBIO,

@O_FECHACAMBIOMANUAL
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);

                return oCSINCCONFIG;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }

        public bool BorrarSINCCONFIGD(CSINCCONFIGBE oCSINCCONFIG, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@HAB_SINC", FbDbType.Char);
                auxPar.Value = oCSINCCONFIG.IHAB_SINC;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ES_COPIA", FbDbType.Char);
                auxPar.Value = oCSINCCONFIG.IES_COPIA;
                parts.Add(auxPar);


                auxPar = new FbParameter("@C_CONEXORIG", FbDbType.VarChar);
                auxPar.Value = oCSINCCONFIG.IC_CONEXORIG;
                parts.Add(auxPar);


                auxPar = new FbParameter("@C_SINCAUTO", FbDbType.Char);
                auxPar.Value = oCSINCCONFIG.IC_SINCAUTO;
                parts.Add(auxPar);


                auxPar = new FbParameter("@C_FECHAULTISINC", FbDbType.Date);
                auxPar.Value = oCSINCCONFIG.IC_FECHAULTISINC;
                parts.Add(auxPar);


                auxPar = new FbParameter("@C_LIMPNOSINC", FbDbType.Char);
                auxPar.Value = oCSINCCONFIG.IC_LIMPNOSINC;
                parts.Add(auxPar);


                auxPar = new FbParameter("@O_ULTIFECHACAMBIO", FbDbType.Date);
                auxPar.Value = oCSINCCONFIG.IO_ULTIFECHACAMBIO;
                parts.Add(auxPar);


                auxPar = new FbParameter("@O_FECHACAMBIOMANUAL", FbDbType.Char);
                auxPar.Value = oCSINCCONFIG.IO_FECHACAMBIOMANUAL;
                parts.Add(auxPar);



                string commandText = @"  Delete from SINCCONFIG
  where

  HAB_SINC=@HAB_SINC and 

  ES_COPIA=@ES_COPIA and 

  C_CONEXORIG=@C_CONEXORIG and 

  C_SINCAUTO=@C_SINCAUTO and 

  C_FECHAULTISINC=@C_FECHAULTISINC and 

  C_LIMPNOSINC=@C_LIMPNOSINC and 

  O_ULTIFECHACAMBIO=@O_ULTIFECHACAMBIO and 

  O_FECHACAMBIOMANUAL=@O_FECHACAMBIOMANUAL
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

        public bool CambiarSINCCONFIGD(CSINCCONFIGBE oCSINCCONFIGNuevo, CSINCCONFIGBE oCSINCCONFIGAnterior, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@HAB_SINC", FbDbType.Char);
                if (!(bool)oCSINCCONFIGNuevo.isnull["IHAB_SINC"])
                {
                    auxPar.Value = oCSINCCONFIGNuevo.IHAB_SINC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ES_COPIA", FbDbType.Char);
                if (!(bool)oCSINCCONFIGNuevo.isnull["IES_COPIA"])
                {
                    auxPar.Value = oCSINCCONFIGNuevo.IES_COPIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@C_CONEXORIG", FbDbType.VarChar);
                if (!(bool)oCSINCCONFIGNuevo.isnull["IC_CONEXORIG"])
                {
                    auxPar.Value = oCSINCCONFIGNuevo.IC_CONEXORIG;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@C_SINCAUTO", FbDbType.Char);
                if (!(bool)oCSINCCONFIGNuevo.isnull["IC_SINCAUTO"])
                {
                    auxPar.Value = oCSINCCONFIGNuevo.IC_SINCAUTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                //auxPar = new FbParameter("@C_FECHAULTISINC", FbDbType.Date);
                //if (!(bool)oCSINCCONFIGNuevo.isnull["IC_FECHAULTISINC"])
                //{
                //    auxPar.Value = oCSINCCONFIGNuevo.IC_FECHAULTISINC;
                //}
                //else
                //{
                //    auxPar.Value = System.DBNull.Value;
                //}
                //parts.Add(auxPar);

                auxPar = new FbParameter("@C_LIMPNOSINC", FbDbType.Char);
                if (!(bool)oCSINCCONFIGNuevo.isnull["IC_LIMPNOSINC"])
                {
                    auxPar.Value = oCSINCCONFIGNuevo.IC_LIMPNOSINC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                //auxPar = new FbParameter("@O_ULTIFECHACAMBIO", FbDbType.Date);
                //if (!(bool)oCSINCCONFIGNuevo.isnull["IO_ULTIFECHACAMBIO"])
                //{
                //    auxPar.Value = oCSINCCONFIGNuevo.IO_ULTIFECHACAMBIO;
                //}
                //else
                //{
                //    auxPar.Value = System.DBNull.Value;
                //}
                //parts.Add(auxPar);

                auxPar = new FbParameter("@O_FECHACAMBIOMANUAL", FbDbType.Char);
                if (!(bool)oCSINCCONFIGNuevo.isnull["IO_FECHACAMBIOMANUAL"])
                {
                    auxPar.Value = oCSINCCONFIGNuevo.IO_FECHACAMBIOMANUAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);





                auxPar = new FbParameter("@O_RUTASYSTEMDATA_ENRED", FbDbType.VarChar);
                if (!(bool)oCSINCCONFIGNuevo.isnull["IO_RUTASYSTEMDATA_ENRED"])
                {
                    auxPar.Value = oCSINCCONFIGNuevo.IO_RUTASYSTEMDATA_ENRED;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
  update  SINCCONFIG
  set

HAB_SINC=@HAB_SINC,

ES_COPIA=@ES_COPIA,

C_CONEXORIG=@C_CONEXORIG,

C_SINCAUTO=@C_SINCAUTO,

C_LIMPNOSINC=@C_LIMPNOSINC,

O_FECHACAMBIOMANUAL=@O_FECHACAMBIOMANUAL,

O_RUTASYSTEMDATA_ENRED = @O_RUTASYSTEMDATA_ENRED
 
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

        public CSINCCONFIGBE seleccionarSINCCONFIG(CSINCCONFIGBE oCSINCCONFIG, FbTransaction st)
        {
            CSINCCONFIGBE retorno = new CSINCCONFIGBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SINCCONFIG where
 HAB_SINC=@HAB_SINC    and
 ES_COPIA=@ES_COPIA    and
 C_CONEXORIG=@C_CONEXORIG    and
 C_SINCAUTO=@C_SINCAUTO    and
 C_FECHAULTISINC=@C_FECHAULTISINC    and
 C_LIMPNOSINC=@C_LIMPNOSINC    and
 O_ULTIFECHACAMBIO=@O_ULTIFECHACAMBIO    and
 O_FECHACAMBIOMANUAL=@O_FECHACAMBIOMANUAL  ";


                auxPar = new FbParameter("@HAB_SINC", FbDbType.Char);
                auxPar.Value = oCSINCCONFIG.IHAB_SINC;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ES_COPIA", FbDbType.Char);
                auxPar.Value = oCSINCCONFIG.IES_COPIA;
                parts.Add(auxPar);

                auxPar = new FbParameter("@C_CONEXORIG", FbDbType.VarChar);
                auxPar.Value = oCSINCCONFIG.IC_CONEXORIG;
                parts.Add(auxPar);

                auxPar = new FbParameter("@C_SINCAUTO", FbDbType.Char);
                auxPar.Value = oCSINCCONFIG.IC_SINCAUTO;
                parts.Add(auxPar);

                auxPar = new FbParameter("@C_FECHAULTISINC", FbDbType.Date);
                auxPar.Value = oCSINCCONFIG.IC_FECHAULTISINC;
                parts.Add(auxPar);

                auxPar = new FbParameter("@C_LIMPNOSINC", FbDbType.Char);
                auxPar.Value = oCSINCCONFIG.IC_LIMPNOSINC;
                parts.Add(auxPar);

                auxPar = new FbParameter("@O_ULTIFECHACAMBIO", FbDbType.Date);
                auxPar.Value = oCSINCCONFIG.IO_ULTIFECHACAMBIO;
                parts.Add(auxPar);

                auxPar = new FbParameter("@O_FECHACAMBIOMANUAL", FbDbType.Char);
                auxPar.Value = oCSINCCONFIG.IO_FECHACAMBIOMANUAL;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["HAB_SINC"] != System.DBNull.Value)
                    {
                        retorno.IHAB_SINC = (string)(dr["HAB_SINC"]);
                    }

                    if (dr["ES_COPIA"] != System.DBNull.Value)
                    {
                        retorno.IES_COPIA = (string)(dr["ES_COPIA"]);
                    }

                    if (dr["C_CONEXORIG"] != System.DBNull.Value)
                    {
                        retorno.IC_CONEXORIG = (string)(dr["C_CONEXORIG"]);
                    }

                    if (dr["C_SINCAUTO"] != System.DBNull.Value)
                    {
                        retorno.IC_SINCAUTO = (string)(dr["C_SINCAUTO"]);
                    }

                    if (dr["C_FECHAULTISINC"] != System.DBNull.Value)
                    {
                        retorno.IC_FECHAULTISINC = (DateTime)(dr["C_FECHAULTISINC"]);
                    }

                    if (dr["C_LIMPNOSINC"] != System.DBNull.Value)
                    {
                        retorno.IC_LIMPNOSINC = (string)(dr["C_LIMPNOSINC"]);
                    }

                    if (dr["O_ULTIFECHACAMBIO"] != System.DBNull.Value)
                    {
                        retorno.IO_ULTIFECHACAMBIO = (DateTime)(dr["O_ULTIFECHACAMBIO"]);
                    }

                    if (dr["O_FECHACAMBIOMANUAL"] != System.DBNull.Value)
                    {
                        retorno.IO_FECHACAMBIOMANUAL = (string)(dr["O_FECHACAMBIOMANUAL"]);
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

        public DataSet enlistarSINCCONFIG()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_SINCCONFIG_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }

        public DataSet enlistarCortoSINCCONFIG()
        {
            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_SINCCONFIG_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }

        public int ExisteSINCCONFIG(CSINCCONFIGBE oCSINCCONFIG, FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@HAB_SINC", FbDbType.Char);
                auxPar.Value = oCSINCCONFIG.IHAB_SINC;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ES_COPIA", FbDbType.Char);
                auxPar.Value = oCSINCCONFIG.IES_COPIA;
                parts.Add(auxPar);

                auxPar = new FbParameter("@C_CONEXORIG", FbDbType.VarChar);
                auxPar.Value = oCSINCCONFIG.IC_CONEXORIG;
                parts.Add(auxPar);

                auxPar = new FbParameter("@C_SINCAUTO", FbDbType.Char);
                auxPar.Value = oCSINCCONFIG.IC_SINCAUTO;
                parts.Add(auxPar);

                auxPar = new FbParameter("@C_FECHAULTISINC", FbDbType.Date);
                auxPar.Value = oCSINCCONFIG.IC_FECHAULTISINC;
                parts.Add(auxPar);

                auxPar = new FbParameter("@C_LIMPNOSINC", FbDbType.Char);
                auxPar.Value = oCSINCCONFIG.IC_LIMPNOSINC;
                parts.Add(auxPar);

                auxPar = new FbParameter("@O_ULTIFECHACAMBIO", FbDbType.Date);
                auxPar.Value = oCSINCCONFIG.IO_ULTIFECHACAMBIO;
                parts.Add(auxPar);

                auxPar = new FbParameter("@O_FECHACAMBIOMANUAL", FbDbType.Char);
                auxPar.Value = oCSINCCONFIG.IO_FECHACAMBIOMANUAL;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from SINCCONFIG where

  HAB_SINC=@HAB_SINC    and

  ES_COPIA=@ES_COPIA    and

  C_CONEXORIG=@C_CONEXORIG    and

  C_SINCAUTO=@C_SINCAUTO    and

  C_FECHAULTISINC=@C_FECHAULTISINC    and

  C_LIMPNOSINC=@C_LIMPNOSINC    and

  O_ULTIFECHACAMBIO=@O_ULTIFECHACAMBIO    and

  O_FECHACAMBIOMANUAL=@O_FECHACAMBIOMANUAL  
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

        public CSINCCONFIGBE AgregarSINCCONFIG(CSINCCONFIGBE oCSINCCONFIG, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSINCCONFIG(oCSINCCONFIG, st);
                if (iRes == 1)
                {
                    this.IComentario = "El SINCCONFIG ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarSINCCONFIGD(oCSINCCONFIG, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }

        public bool BorrarSINCCONFIG(CSINCCONFIGBE oCSINCCONFIG, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSINCCONFIG(oCSINCCONFIG, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SINCCONFIG no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarSINCCONFIGD(oCSINCCONFIG, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }

        public bool CambiarSINCCONFIG(CSINCCONFIGBE oCSINCCONFIGNuevo, CSINCCONFIGBE oCSINCCONFIGAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSINCCONFIG(oCSINCCONFIGAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SINCCONFIG no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarSINCCONFIGD(oCSINCCONFIGNuevo, oCSINCCONFIGAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public static bool SincInfoConfig()
        {
            try
            {
                CSINCCONFIGD configLocalD = new CSINCCONFIGD(ConexionMEBD.ConexionString());
                CSINCCONFIGD configRemotaD = null;

                CSINCCONFIGBE configLocalBE = configLocalD.SeleccionarSincConfigLocal(null);
                CSINCCONFIGBE configRemotaBE = null;

                if (configLocalBE != null)
                {
                    if (configLocalBE.IHAB_SINC.Equals("S") && configLocalBE.IES_COPIA.Equals("S")
                        && !String.IsNullOrEmpty(configLocalBE.IC_CONEXORIG))
                    {
                        string cadenaConexionRemota = configLocalBE.IC_CONEXORIG;

                        configRemotaD = new CSINCCONFIGD(cadenaConexionRemota);
                        configRemotaBE = configRemotaD.SeleccionarSincConfigLocal(null);

                        if (configRemotaBE == null || configRemotaBE.IES_COPIA.Equals("S") || configLocalBE.IC_FECHAULTISINC >= configRemotaBE.IO_ULTIFECHACAMBIO)
                        {
                            return true;
                        }
                        else
                        {

                            if(configLocalBE.IC_SINCAUTO != null && !configLocalBE.IC_SINCAUTO.Equals("S"))
                            {
                                if(System.Windows.Forms.MessageBox.Show("Hay cambios en la configuracion de las empresas , desea aplicar esos cambios?","Confirmacion",System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                                {
                                    return true;
                                }
                            }

                            CEMPRESASD empresasLocalD = new CEMPRESASD(ConexionMEBD.ConexionString());
                            CEMPRESASD empresasRemotaD = new CEMPRESASD(cadenaConexionRemota);

                            List<CEMPRESASBE> listaEmpresasLocal = empresasLocalD.SeleccionarTodasEmpresas(null);
                            List<CEMPRESASBE> listaEmpresasRemota = empresasRemotaD.SeleccionarTodasEmpresas(null);

                            if (listaEmpresasRemota.Count == 0) return false;

                            foreach (CEMPRESASBE empresasRemotas in listaEmpresasRemota)
                            {
                                bool bExisteEnLocal = false;
                                foreach (CEMPRESASBE empresasLocales in listaEmpresasLocal)
                                {
                                    if (empresasRemotas.IEM_NOMBRE == empresasLocales.IEM_NOMBRE)
                                    {
                                        empresasLocales.IEM_SERVER = empresasRemotas.IEM_SERVER;
                                        empresasLocales.IEM_USUARIO = empresasRemotas.IEM_USUARIO;
                                        empresasLocales.IEM_PASSWORD = empresasRemotas.IEM_PASSWORD;
                                        empresasLocales.IEM_DATABASE = empresasRemotas.IEM_DATABASE;

                                        if (!empresasLocalD.CambiarEMPRESASD(empresasLocales, empresasLocales, null))
                                        {
                                            ComentarioSincConfig = "No se cambio los datos de EmpresasLocales.";
                                            return false;
                                        }

                                        bExisteEnLocal = true;
                                        break;
                                    }
                                }


                                if (!bExisteEnLocal)
                                {
                                    //hacer insert
                                    CEMPRESASBE empresasLocales = new CEMPRESASBE();
                                    empresasLocales.IEM_NOMBRE = empresasRemotas.IEM_NOMBRE;
                                    empresasLocales.IEM_SERVER = empresasRemotas.IEM_SERVER;
                                    empresasLocales.IEM_USUARIO = empresasRemotas.IEM_USUARIO;
                                    empresasLocales.IEM_PASSWORD = empresasRemotas.IEM_PASSWORD;
                                    empresasLocales.IEM_DATABASE = empresasRemotas.IEM_DATABASE;

                                    if (empresasLocalD.AgregarEMPRESASD(empresasLocales, null) == null)
                                    {
                                        ComentarioSincConfig = "No se pudo insertar los datos de EmpresasLocales";
                                        return false;
                                    }

                                }
                            }

                            if (configLocalBE.IC_LIMPNOSINC.Equals("S"))
                            {
                                foreach (CEMPRESASBE empresaLocal in listaEmpresasLocal)
                                {
                                    bool bExisteEnRemoto = false;

                                    foreach (CEMPRESASBE empresaRemota in listaEmpresasRemota)
                                    {
                                        if (empresaLocal.IEM_NOMBRE == empresaRemota.IEM_NOMBRE)
                                        {
                                            bExisteEnRemoto = true;
                                            break;
                                        }
                                    }

                                    if (!bExisteEnRemoto)
                                    {
                                        if (!empresasLocalD.BorrarEMPRESASD(empresaLocal, null))
                                        {
                                            ComentarioSincConfig = "No se pudo borar Empresa local";
                                            return false;
                                        }
                                    }
                                }
                            }

                            configLocalBE.IC_FECHAULTISINC = configRemotaBE.IO_ULTIFECHACAMBIO;
                           if(! configLocalD.CambiarSINCCONFIGD(configLocalBE,configLocalBE, null))
                           {

                               ComentarioSincConfig = "No se pudo actualizar la fecha local de sincronizacion";
                               return false;
                           }

                            return true;
                        }


                    }
                    else
                    {

                        return true;
                    }
                }
                else
                {
                    ComentarioSincConfig = configLocalD.IComentario;
                    return false;
                }
            }
            catch (Exception ex)
            {
                ComentarioSincConfig = ex.Message + ex.StackTrace;

                return false;
            }
        }

        public CSINCCONFIGBE SeleccionarSincConfigLocal(FbTransaction st)
        {
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                string query = @"SELECT * FROM SINCCONFIG";

                CSINCCONFIGBE retorno = null;

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, query, out pcn);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, query);

                if (dr.Read())
                {
                    retorno = FromReaderToSincConfig(ref dr);
                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                return retorno;
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.IComentario = ex.Message + ex.StackTrace;

                return null;
            }
        }

        private CSINCCONFIGBE FromReaderToSincConfig(ref FbDataReader dr)
        {
            CSINCCONFIGBE retorno = new CSINCCONFIGBE();


            if (dr["HAB_SINC"] != System.DBNull.Value)
            {
                retorno.IHAB_SINC = (string)(dr["HAB_SINC"]);
            }

            if (dr["ES_COPIA"] != System.DBNull.Value)
            {
                retorno.IES_COPIA = (string)(dr["ES_COPIA"]);
            }

            if (dr["C_CONEXORIG"] != System.DBNull.Value)
            {
                retorno.IC_CONEXORIG = (string)(dr["C_CONEXORIG"]);
            }

            if (dr["C_SINCAUTO"] != System.DBNull.Value)
            {
                retorno.IC_SINCAUTO = (string)(dr["C_SINCAUTO"]);
            }

            if (dr["C_FECHAULTISINC"] != System.DBNull.Value)
            {
                retorno.IC_FECHAULTISINC = (DateTime)(dr["C_FECHAULTISINC"]);
            }

            if (dr["C_LIMPNOSINC"] != System.DBNull.Value)
            {
                retorno.IC_LIMPNOSINC = (string)(dr["C_LIMPNOSINC"]);
            }

            if (dr["O_ULTIFECHACAMBIO"] != System.DBNull.Value)
            {
                retorno.IO_ULTIFECHACAMBIO = (DateTime)(dr["O_ULTIFECHACAMBIO"]);
            }

            if (dr["O_FECHACAMBIOMANUAL"] != System.DBNull.Value)
            {
                retorno.IO_FECHACAMBIOMANUAL = (string)(dr["O_FECHACAMBIOMANUAL"]);
            }


            if (dr["O_RUTASYSTEMDATA_ENRED"] != System.DBNull.Value)
            {
                retorno.IO_RUTASYSTEMDATA_ENRED = (string)(dr["O_RUTASYSTEMDATA_ENRED"]);
            }

            return retorno;
        }

        public CSINCCONFIGD()
        {
            this.sCadenaConexion = ConexionMEBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }

        public CSINCCONFIGD(string cadenaConexion)
        {
            this.sCadenaConexion = cadenaConexion;
        }
    }
}
