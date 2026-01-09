

using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Collections;
using ConexionesBD;

namespace iPosData
{




    public class CSAT_CLAVEUNIDADPESOD
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



        public CSAT_CLAVEUNIDADPESOBE AgregarSAT_CLAVEUNIDADPESOD(CSAT_CLAVEUNIDADPESOBE oCSAT_CLAVEUNIDADPESO, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSAT_CLAVEUNIDADPESO.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSAT_CLAVEUNIDADPESO.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_CLAVEUNIDADPESO.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_CLAVEUNIDADPESO.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_CLAVEUNIDADPESO.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_CLAVEUNIDADPESO.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCSAT_CLAVEUNIDADPESO.isnull["ICLAVE"])
                {
                    auxPar.Value = oCSAT_CLAVEUNIDADPESO.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCSAT_CLAVEUNIDADPESO.isnull["INOMBRE"])
                {
                    auxPar.Value = oCSAT_CLAVEUNIDADPESO.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCSAT_CLAVEUNIDADPESO.isnull["IDESCRIPCION"])
                {
                    auxPar.Value = oCSAT_CLAVEUNIDADPESO.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOTA", FbDbType.VarChar);
                if (!(bool)oCSAT_CLAVEUNIDADPESO.isnull["INOTA"])
                {
                    auxPar.Value = oCSAT_CLAVEUNIDADPESO.INOTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAINICIO", FbDbType.Date);
                if (!(bool)oCSAT_CLAVEUNIDADPESO.isnull["IFECHAINICIO"])
                {
                    auxPar.Value = oCSAT_CLAVEUNIDADPESO.IFECHAINICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAFIN", FbDbType.Date);
                if (!(bool)oCSAT_CLAVEUNIDADPESO.isnull["IFECHAFIN"])
                {
                    auxPar.Value = oCSAT_CLAVEUNIDADPESO.IFECHAFIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SIMBOLO", FbDbType.VarChar);
                if (!(bool)oCSAT_CLAVEUNIDADPESO.isnull["ISIMBOLO"])
                {
                    auxPar.Value = oCSAT_CLAVEUNIDADPESO.ISIMBOLO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@BANDERA", FbDbType.VarChar);
                if (!(bool)oCSAT_CLAVEUNIDADPESO.isnull["IBANDERA"])
                {
                    auxPar.Value = oCSAT_CLAVEUNIDADPESO.IBANDERA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO SAT_CLAVEUNIDADPESO
      (
    

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

CLAVE,

NOMBRE,

DESCRIPCION,

NOTA,

FECHAINICIO,

FECHAFIN,

SIMBOLO,

BANDERA
         )

Values (


@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@CLAVE,

@NOMBRE,

@DESCRIPCION,

@NOTA,

@FECHAINICIO,

@FECHAFIN,

@SIMBOLO,

@BANDERA
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCSAT_CLAVEUNIDADPESO;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }



        public bool BorrarSAT_CLAVEUNIDADPESOD(CSAT_CLAVEUNIDADPESOBE oCSAT_CLAVEUNIDADPESO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSAT_CLAVEUNIDADPESO.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from SAT_CLAVEUNIDADPESO
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



        public bool CambiarSAT_CLAVEUNIDADPESOD(CSAT_CLAVEUNIDADPESOBE oCSAT_CLAVEUNIDADPESONuevo, CSAT_CLAVEUNIDADPESOBE oCSAT_CLAVEUNIDADPESOAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSAT_CLAVEUNIDADPESONuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSAT_CLAVEUNIDADPESONuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_CLAVEUNIDADPESONuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_CLAVEUNIDADPESONuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCSAT_CLAVEUNIDADPESONuevo.isnull["ICLAVE"])
                {
                    auxPar.Value = oCSAT_CLAVEUNIDADPESONuevo.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCSAT_CLAVEUNIDADPESONuevo.isnull["INOMBRE"])
                {
                    auxPar.Value = oCSAT_CLAVEUNIDADPESONuevo.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCSAT_CLAVEUNIDADPESONuevo.isnull["IDESCRIPCION"])
                {
                    auxPar.Value = oCSAT_CLAVEUNIDADPESONuevo.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOTA", FbDbType.VarChar);
                if (!(bool)oCSAT_CLAVEUNIDADPESONuevo.isnull["INOTA"])
                {
                    auxPar.Value = oCSAT_CLAVEUNIDADPESONuevo.INOTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAINICIO", FbDbType.Date);
                if (!(bool)oCSAT_CLAVEUNIDADPESONuevo.isnull["IFECHAINICIO"])
                {
                    auxPar.Value = oCSAT_CLAVEUNIDADPESONuevo.IFECHAINICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAFIN", FbDbType.Date);
                if (!(bool)oCSAT_CLAVEUNIDADPESONuevo.isnull["IFECHAFIN"])
                {
                    auxPar.Value = oCSAT_CLAVEUNIDADPESONuevo.IFECHAFIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SIMBOLO", FbDbType.VarChar);
                if (!(bool)oCSAT_CLAVEUNIDADPESONuevo.isnull["ISIMBOLO"])
                {
                    auxPar.Value = oCSAT_CLAVEUNIDADPESONuevo.ISIMBOLO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@BANDERA", FbDbType.VarChar);
                if (!(bool)oCSAT_CLAVEUNIDADPESONuevo.isnull["IBANDERA"])
                {
                    auxPar.Value = oCSAT_CLAVEUNIDADPESONuevo.IBANDERA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCSAT_CLAVEUNIDADPESOAnterior.isnull["IID"])
                {
                    auxPar.Value = oCSAT_CLAVEUNIDADPESOAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  SAT_CLAVEUNIDADPESO
  set


ACTIVO=@ACTIVO,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

CLAVE=@CLAVE,

NOMBRE=@NOMBRE,

DESCRIPCION=@DESCRIPCION,

NOTA=@NOTA,

FECHAINICIO=@FECHAINICIO,

FECHAFIN=@FECHAFIN,

SIMBOLO=@SIMBOLO,

BANDERA=@BANDERA
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



        public CSAT_CLAVEUNIDADPESOBE seleccionarSAT_CLAVEUNIDADPESO(CSAT_CLAVEUNIDADPESOBE oCSAT_CLAVEUNIDADPESO, FbTransaction st)
        {




            CSAT_CLAVEUNIDADPESOBE retorno = new CSAT_CLAVEUNIDADPESOBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SAT_CLAVEUNIDADPESO where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSAT_CLAVEUNIDADPESO.IID;
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

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = (string)(dr["CLAVE"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = (string)(dr["DESCRIPCION"]);
                    }

                    if (dr["NOTA"] != System.DBNull.Value)
                    {
                        retorno.INOTA = (string)(dr["NOTA"]);
                    }

                    if (dr["FECHAINICIO"] != System.DBNull.Value)
                    {
                        retorno.IFECHAINICIO = (DateTime)(dr["FECHAINICIO"]);
                    }

                    if (dr["FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.IFECHAFIN = (DateTime)(dr["FECHAFIN"]);
                    }

                    if (dr["SIMBOLO"] != System.DBNull.Value)
                    {
                        retorno.ISIMBOLO = (string)(dr["SIMBOLO"]);
                    }

                    if (dr["BANDERA"] != System.DBNull.Value)
                    {
                        retorno.IBANDERA = (string)(dr["BANDERA"]);
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





        public CSAT_CLAVEUNIDADPESOBE seleccionarSAT_CLAVEUNIDADPESO_X_CLAVE(CSAT_CLAVEUNIDADPESOBE oCSAT_CLAVEUNIDADPESO, FbTransaction st)
        {




            CSAT_CLAVEUNIDADPESOBE retorno = new CSAT_CLAVEUNIDADPESOBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SAT_CLAVEUNIDADPESO where
 CLAVE=@CLAVE  ";


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                auxPar.Value = oCSAT_CLAVEUNIDADPESO.ICLAVE;
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

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = (string)(dr["CLAVE"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = (string)(dr["DESCRIPCION"]);
                    }

                    if (dr["NOTA"] != System.DBNull.Value)
                    {
                        retorno.INOTA = (string)(dr["NOTA"]);
                    }

                    if (dr["FECHAINICIO"] != System.DBNull.Value)
                    {
                        retorno.IFECHAINICIO = (DateTime)(dr["FECHAINICIO"]);
                    }

                    if (dr["FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.IFECHAFIN = (DateTime)(dr["FECHAFIN"]);
                    }

                    if (dr["SIMBOLO"] != System.DBNull.Value)
                    {
                        retorno.ISIMBOLO = (string)(dr["SIMBOLO"]);
                    }

                    if (dr["BANDERA"] != System.DBNull.Value)
                    {
                        retorno.IBANDERA = (string)(dr["BANDERA"]);
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






        public DataSet enlistarSAT_CLAVEUNIDADPESO()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_SAT_CLAVEUNIDADPESO_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }





        public DataSet enlistarCortoSAT_CLAVEUNIDADPESO()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_SAT_CLAVEUNIDADPESO_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public int ExisteSAT_CLAVEUNIDADPESO(CSAT_CLAVEUNIDADPESOBE oCSAT_CLAVEUNIDADPESO, FbTransaction st)
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
                auxPar.Value = oCSAT_CLAVEUNIDADPESO.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from SAT_CLAVEUNIDADPESO where

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




        public CSAT_CLAVEUNIDADPESOBE AgregarSAT_CLAVEUNIDADPESO(CSAT_CLAVEUNIDADPESOBE oCSAT_CLAVEUNIDADPESO, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_CLAVEUNIDADPESO(oCSAT_CLAVEUNIDADPESO, st);
                if (iRes == 1)
                {
                    this.IComentario = "El SAT_CLAVEUNIDADPESO ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarSAT_CLAVEUNIDADPESOD(oCSAT_CLAVEUNIDADPESO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarSAT_CLAVEUNIDADPESO(CSAT_CLAVEUNIDADPESOBE oCSAT_CLAVEUNIDADPESO, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_CLAVEUNIDADPESO(oCSAT_CLAVEUNIDADPESO, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SAT_CLAVEUNIDADPESO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarSAT_CLAVEUNIDADPESOD(oCSAT_CLAVEUNIDADPESO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarSAT_CLAVEUNIDADPESO(CSAT_CLAVEUNIDADPESOBE oCSAT_CLAVEUNIDADPESONuevo, CSAT_CLAVEUNIDADPESOBE oCSAT_CLAVEUNIDADPESOAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_CLAVEUNIDADPESO(oCSAT_CLAVEUNIDADPESOAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SAT_CLAVEUNIDADPESO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarSAT_CLAVEUNIDADPESOD(oCSAT_CLAVEUNIDADPESONuevo, oCSAT_CLAVEUNIDADPESOAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }



        public CSAT_CLAVEUNIDADPESOD(string cadenaConexion)
        {
            this.sCadenaConexion = cadenaConexion;
        }


        public CSAT_CLAVEUNIDADPESOD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
