

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


    public class CCUPONESAPLICADOSD
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


        public CCUPONESAPLICADOSBE AgregarCUPONESAPLICADOSD(CCUPONESAPLICADOSBE oCCUPONESAPLICADOS, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCCUPONESAPLICADOS.isnull["IACTIVO"])
                {
                    auxPar.Value = oCCUPONESAPLICADOS.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if (!(bool)oCCUPONESAPLICADOS.isnull["IDOCTOID"])
                {
                    auxPar.Value = oCCUPONESAPLICADOS.IDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PROMOCIONCUPONID", FbDbType.BigInt);
                if (!(bool)oCCUPONESAPLICADOS.isnull["IPROMOCIONCUPONID"])
                {
                    auxPar.Value = oCCUPONESAPLICADOS.IPROMOCIONCUPONID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDAD", FbDbType.Numeric);
                if (!(bool)oCCUPONESAPLICADOS.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCCUPONESAPLICADOS.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO CUPONESAPLICADOS
      (

ACTIVO,

CREADO,

DOCTOID,

PROMOCIONCUPONID,

CANTIDAD
         )

Values (

@ACTIVO,

@DOCTOID,

@PROMOCIONCUPONID,

@CANTIDAD
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);

                return oCCUPONESAPLICADOS;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }

        public bool BorrarCUPONESAPLICADOSD(CCUPONESAPLICADOSBE oCCUPONESAPLICADOS, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCCUPONESAPLICADOS.IID;
                parts.Add(auxPar);

                string commandText = @"  Delete from CUPONESAPLICADOS
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

        public bool CambiarCUPONESAPLICADOSD(CCUPONESAPLICADOSBE oCCUPONESAPLICADOSNuevo, CCUPONESAPLICADOSBE oCCUPONESAPLICADOSAnterior, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCCUPONESAPLICADOSNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCCUPONESAPLICADOSNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if (!(bool)oCCUPONESAPLICADOSNuevo.isnull["IDOCTOID"])
                {
                    auxPar.Value = oCCUPONESAPLICADOSNuevo.IDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PROMOCIONCUPONID", FbDbType.BigInt);
                if (!(bool)oCCUPONESAPLICADOSNuevo.isnull["IPROMOCIONCUPONID"])
                {
                    auxPar.Value = oCCUPONESAPLICADOSNuevo.IPROMOCIONCUPONID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CANTIDAD", FbDbType.Numeric);
                if (!(bool)oCCUPONESAPLICADOSNuevo.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCCUPONESAPLICADOSNuevo.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCCUPONESAPLICADOSAnterior.isnull["IID"])
                {
                    auxPar.Value = oCCUPONESAPLICADOSAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  CUPONESAPLICADOS
  set

ACTIVO=@ACTIVO,

DOCTOID=@DOCTOID,

PROMOCIONCUPONID=@PROMOCIONCUPONID,

CANTIDAD=@CANTIDAD
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


        public bool CambiarEstadoActivo(CCUPONESAPLICADOSBE oCCUPONESAPLICADOSNuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCCUPONESAPLICADOSNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCCUPONESAPLICADOSNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCCUPONESAPLICADOSNuevo.isnull["IID"])
                {
                    auxPar.Value = oCCUPONESAPLICADOSNuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update CUPONESAPLICADOS SET

ACTIVO=@ACTIVO

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

        public CCUPONESAPLICADOSBE seleccionarCUPONESAPLICADOS(CCUPONESAPLICADOSBE oCCUPONESAPLICADOS, FbTransaction st)
        {

            CCUPONESAPLICADOSBE retorno = new CCUPONESAPLICADOSBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from CUPONESAPLICADOS where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCCUPONESAPLICADOS.IID;
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

                    if (dr["DOCTOID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOID = (long)(dr["DOCTOID"]);
                    }

                    if (dr["PROMOCIONCUPONID"] != System.DBNull.Value)
                    {
                        retorno.IPROMOCIONCUPONID = (long)(dr["PROMOCIONCUPONID"]);
                    }

                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDAD = (decimal)(dr["CANTIDAD"]);
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

        public DataSet enlistarCUPONESAPLICADOS()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_CUPONESAPLICADOS_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }

        public DataSet enlistarCortoCUPONESAPLICADOS()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_CUPONESAPLICADOS_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }

        public int ExisteCUPONESAPLICADOS(CCUPONESAPLICADOSBE oCCUPONESAPLICADOS, FbTransaction st)
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
                auxPar.Value = oCCUPONESAPLICADOS.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from CUPONESAPLICADOS where

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

        public CCUPONESAPLICADOSBE AgregarCUPONESAPLICADOS(CCUPONESAPLICADOSBE oCCUPONESAPLICADOS, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCUPONESAPLICADOS(oCCUPONESAPLICADOS, st);
                if (iRes == 1)
                {
                    this.IComentario = "El CUPONESAPLICADOS ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarCUPONESAPLICADOSD(oCCUPONESAPLICADOS, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarCUPONESAPLICADOS(CCUPONESAPLICADOSBE oCCUPONESAPLICADOS, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCUPONESAPLICADOS(oCCUPONESAPLICADOS, st);
                if (iRes == 0)
                {
                    this.IComentario = "El CUPONESAPLICADOS no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarCUPONESAPLICADOSD(oCCUPONESAPLICADOS, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarCUPONESAPLICADOS(CCUPONESAPLICADOSBE oCCUPONESAPLICADOSNuevo, CCUPONESAPLICADOSBE oCCUPONESAPLICADOSAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCUPONESAPLICADOS(oCCUPONESAPLICADOSAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El CUPONESAPLICADOS no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarCUPONESAPLICADOSD(oCCUPONESAPLICADOSNuevo, oCCUPONESAPLICADOSAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }

        public List<CCUPONESAPLICADOSBE> SeleccionarCuponesXDocto(long doctoId, FbTransaction st)
        {
            FbDataReader dr = null;
            FbConnection pcn = null;
            CCUPONESAPLICADOSBE retorno = new CCUPONESAPLICADOSBE();
            List<CCUPONESAPLICADOSBE> listaRetorno = new List<CCUPONESAPLICADOSBE>();

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"SELECT CUPONESAPLICADOS.*, PROMOCION.DESCRIPCION FROM CUPONESAPLICADOS
                                  LEFT JOIN PROMOCION ON CUPONESAPLICADOS.PROMOCIONCUPONID = PROMOCION.ID 
                                  WHERE DOCTOID = @DOCTOID";


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                while(dr.Read())
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

                    if (dr["DOCTOID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOID = (long)(dr["DOCTOID"]);
                    }

                    if (dr["PROMOCIONCUPONID"] != System.DBNull.Value)
                    {
                        retorno.IPROMOCIONCUPONID = (long)(dr["PROMOCIONCUPONID"]);
                    }

                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDAD = (decimal)(dr["CANTIDAD"]);
                    }
                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.ILEYENDA = (string)(dr["DESCRIPCION"]);
                    }

                    listaRetorno.Add(retorno);
                }
                

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                return listaRetorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }

        }

        public CCUPONESAPLICADOSD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
