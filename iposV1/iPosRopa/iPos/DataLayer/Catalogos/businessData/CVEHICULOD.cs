

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


    public class CVEHICULOD
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

        
        public CVEHICULOBE AgregarVEHICULOD(CVEHICULOBE oCVEHICULO, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCVEHICULO.isnull["IACTIVO"])
                {
                    auxPar.Value = oCVEHICULO.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCVEHICULO.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCVEHICULO.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCVEHICULO.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCVEHICULO.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_TIPOPERMISOID", FbDbType.BigInt);
                if (!(bool)oCVEHICULO.isnull["ISAT_TIPOPERMISOID"])
                {
                    auxPar.Value = oCVEHICULO.ISAT_TIPOPERMISOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUMPERMISOSCT", FbDbType.VarChar);
                if (!(bool)oCVEHICULO.isnull["INUMPERMISOSCT"])
                {
                    auxPar.Value = oCVEHICULO.INUMPERMISOSCT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_CONFIGAUTOTRANSPORTEID", FbDbType.BigInt);
                if (!(bool)oCVEHICULO.isnull["ISAT_CONFIGAUTOTRANSPORTEID"])
                {
                    auxPar.Value = oCVEHICULO.ISAT_CONFIGAUTOTRANSPORTEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PLACAVM", FbDbType.VarChar);
                if (!(bool)oCVEHICULO.isnull["IPLACAVM"])
                {
                    auxPar.Value = oCVEHICULO.IPLACAVM;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ANIOMODELOVM", FbDbType.VarChar);
                if (!(bool)oCVEHICULO.isnull["IANIOMODELOVM"])
                {
                    auxPar.Value = oCVEHICULO.IANIOMODELOVM;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ASEGURARESPCIVIL", FbDbType.VarChar);
                if (!(bool)oCVEHICULO.isnull["IASEGURARESPCIVIL"])
                {
                    auxPar.Value = oCVEHICULO.IASEGURARESPCIVIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@POLIZARESPCIVIL", FbDbType.VarChar);
                if (!(bool)oCVEHICULO.isnull["IPOLIZARESPCIVIL"])
                {
                    auxPar.Value = oCVEHICULO.IPOLIZARESPCIVIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ASEGURAMEDAMBIENTE", FbDbType.VarChar);
                if (!(bool)oCVEHICULO.isnull["IASEGURAMEDAMBIENTE"])
                {
                    auxPar.Value = oCVEHICULO.IASEGURAMEDAMBIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@POLIZAMEDAMBIENTE", FbDbType.VarChar);
                if (!(bool)oCVEHICULO.isnull["IPOLIZAMEDAMBIENTE"])
                {
                    auxPar.Value = oCVEHICULO.IPOLIZAMEDAMBIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ASEGURACARGA", FbDbType.VarChar);
                if (!(bool)oCVEHICULO.isnull["IASEGURACARGA"])
                {
                    auxPar.Value = oCVEHICULO.IASEGURACARGA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@POLIZACARGA", FbDbType.VarChar);
                if (!(bool)oCVEHICULO.isnull["IPOLIZACARGA"])
                {
                    auxPar.Value = oCVEHICULO.IPOLIZACARGA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRIMASEGURO", FbDbType.VarChar);
                if (!(bool)oCVEHICULO.isnull["IPRIMASEGURO"])
                {
                    auxPar.Value = oCVEHICULO.IPRIMASEGURO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_SUBTIPOREM1ID", FbDbType.BigInt);
                if (!(bool)oCVEHICULO.isnull["ISAT_SUBTIPOREM1ID"])
                {
                    auxPar.Value = oCVEHICULO.ISAT_SUBTIPOREM1ID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PLACA1", FbDbType.VarChar);
                if (!(bool)oCVEHICULO.isnull["IPLACA1"])
                {
                    auxPar.Value = oCVEHICULO.IPLACA1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_SUBTIPOREM2ID", FbDbType.BigInt);
                if (!(bool)oCVEHICULO.isnull["ISAT_SUBTIPOREM2ID"])
                {
                    auxPar.Value = oCVEHICULO.ISAT_SUBTIPOREM2ID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PLACA2", FbDbType.VarChar);
                if (!(bool)oCVEHICULO.isnull["IPLACA2"])
                {
                    auxPar.Value = oCVEHICULO.IPLACA2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DUENIOID", FbDbType.BigInt);
                if (!(bool)oCVEHICULO.isnull["IDUENIOID"])
                {
                    auxPar.Value = oCVEHICULO.IDUENIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PESOBRUTOVEHICULAR", FbDbType.BigInt);
                if (!(bool)oCVEHICULO.isnull["IPESOBRUTOVEHICULAR"])
                {
                    auxPar.Value = oCVEHICULO.IPESOBRUTOVEHICULAR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO VEHICULO
      (

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

SAT_TIPOPERMISOID,

NUMPERMISOSCT,

SAT_CONFIGAUTOTRANSPORTEID,

PLACAVM,

ANIOMODELOVM,

ASEGURARESPCIVIL,

POLIZARESPCIVIL,

ASEGURAMEDAMBIENTE,

POLIZAMEDAMBIENTE,

ASEGURACARGA,

POLIZACARGA,

PRIMASEGURO,

SAT_SUBTIPOREM1ID,

PLACA1,

SAT_SUBTIPOREM2ID,

PLACA2,

DUENIOID,

PESOBRUTOVEHICULAR

         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@SAT_TIPOPERMISOID,

@NUMPERMISOSCT,

@SAT_CONFIGAUTOTRANSPORTEID,

@PLACAVM,

@ANIOMODELOVM,

@ASEGURARESPCIVIL,

@POLIZARESPCIVIL,

@ASEGURAMEDAMBIENTE,

@POLIZAMEDAMBIENTE,

@ASEGURACARGA,

@POLIZACARGA,

@PRIMASEGURO,

@SAT_SUBTIPOREM1ID,

@PLACA1,

@SAT_SUBTIPOREM2ID,

@PLACA2,

@DUENIOID,

@PESOBRUTOVEHICULAR

); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCVEHICULO;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }

        
        public bool BorrarVEHICULOD(CVEHICULOBE oCVEHICULO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCVEHICULO.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from VEHICULO
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

        
        public bool CambiarVEHICULOD(CVEHICULOBE oCVEHICULONuevo, CVEHICULOBE oCVEHICULOAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCVEHICULONuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCVEHICULONuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCVEHICULONuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCVEHICULONuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_TIPOPERMISOID", FbDbType.BigInt);
                if (!(bool)oCVEHICULONuevo.isnull["ISAT_TIPOPERMISOID"])
                {
                    auxPar.Value = oCVEHICULONuevo.ISAT_TIPOPERMISOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMPERMISOSCT", FbDbType.VarChar);
                if (!(bool)oCVEHICULONuevo.isnull["INUMPERMISOSCT"])
                {
                    auxPar.Value = oCVEHICULONuevo.INUMPERMISOSCT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_CONFIGAUTOTRANSPORTEID", FbDbType.BigInt);
                if (!(bool)oCVEHICULONuevo.isnull["ISAT_CONFIGAUTOTRANSPORTEID"])
                {
                    auxPar.Value = oCVEHICULONuevo.ISAT_CONFIGAUTOTRANSPORTEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PLACAVM", FbDbType.VarChar);
                if (!(bool)oCVEHICULONuevo.isnull["IPLACAVM"])
                {
                    auxPar.Value = oCVEHICULONuevo.IPLACAVM;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ANIOMODELOVM", FbDbType.VarChar);
                if (!(bool)oCVEHICULONuevo.isnull["IANIOMODELOVM"])
                {
                    auxPar.Value = oCVEHICULONuevo.IANIOMODELOVM;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ASEGURARESPCIVIL", FbDbType.VarChar);
                if (!(bool)oCVEHICULONuevo.isnull["IASEGURARESPCIVIL"])
                {
                    auxPar.Value = oCVEHICULONuevo.IASEGURARESPCIVIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@POLIZARESPCIVIL", FbDbType.VarChar);
                if (!(bool)oCVEHICULONuevo.isnull["IPOLIZARESPCIVIL"])
                {
                    auxPar.Value = oCVEHICULONuevo.IPOLIZARESPCIVIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ASEGURAMEDAMBIENTE", FbDbType.VarChar);
                if (!(bool)oCVEHICULONuevo.isnull["IASEGURAMEDAMBIENTE"])
                {
                    auxPar.Value = oCVEHICULONuevo.IASEGURAMEDAMBIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@POLIZAMEDAMBIENTE", FbDbType.VarChar);
                if (!(bool)oCVEHICULONuevo.isnull["IPOLIZAMEDAMBIENTE"])
                {
                    auxPar.Value = oCVEHICULONuevo.IPOLIZAMEDAMBIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ASEGURACARGA", FbDbType.VarChar);
                if (!(bool)oCVEHICULONuevo.isnull["IASEGURACARGA"])
                {
                    auxPar.Value = oCVEHICULONuevo.IASEGURACARGA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@POLIZACARGA", FbDbType.VarChar);
                if (!(bool)oCVEHICULONuevo.isnull["IPOLIZACARGA"])
                {
                    auxPar.Value = oCVEHICULONuevo.IPOLIZACARGA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRIMASEGURO", FbDbType.VarChar);
                if (!(bool)oCVEHICULONuevo.isnull["IPRIMASEGURO"])
                {
                    auxPar.Value = oCVEHICULONuevo.IPRIMASEGURO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_SUBTIPOREM1ID", FbDbType.BigInt);
                if (!(bool)oCVEHICULONuevo.isnull["ISAT_SUBTIPOREM1ID"])
                {
                    auxPar.Value = oCVEHICULONuevo.ISAT_SUBTIPOREM1ID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PLACA1", FbDbType.VarChar);
                if (!(bool)oCVEHICULONuevo.isnull["IPLACA1"])
                {
                    auxPar.Value = oCVEHICULONuevo.IPLACA1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_SUBTIPOREM2ID", FbDbType.BigInt);
                if (!(bool)oCVEHICULONuevo.isnull["ISAT_SUBTIPOREM2ID"])
                {
                    auxPar.Value = oCVEHICULONuevo.ISAT_SUBTIPOREM2ID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PLACA2", FbDbType.VarChar);
                if (!(bool)oCVEHICULONuevo.isnull["IPLACA2"])
                {
                    auxPar.Value = oCVEHICULONuevo.IPLACA2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DUENIOID", FbDbType.BigInt);
                if (!(bool)oCVEHICULONuevo.isnull["IDUENIOID"])
                {
                    auxPar.Value = oCVEHICULONuevo.IDUENIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PESOBRUTOVEHICULAR", FbDbType.BigInt);
                if (!(bool)oCVEHICULONuevo.isnull["IPESOBRUTOVEHICULAR"])
                {
                    auxPar.Value = oCVEHICULONuevo.IPESOBRUTOVEHICULAR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCVEHICULOAnterior.isnull["IID"])
                {
                    auxPar.Value = oCVEHICULOAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  VEHICULO
  set

ACTIVO=@ACTIVO,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

SAT_TIPOPERMISOID=@SAT_TIPOPERMISOID,

NUMPERMISOSCT=@NUMPERMISOSCT,

SAT_CONFIGAUTOTRANSPORTEID=@SAT_CONFIGAUTOTRANSPORTEID,

PLACAVM=@PLACAVM,

ANIOMODELOVM=@ANIOMODELOVM,

ASEGURARESPCIVIL=@ASEGURARESPCIVIL,

POLIZARESPCIVIL=@POLIZARESPCIVIL,

ASEGURAMEDAMBIENTE=@ASEGURAMEDAMBIENTE,

POLIZAMEDAMBIENTE=@POLIZAMEDAMBIENTE,

ASEGURACARGA=@ASEGURACARGA,

POLIZACARGA=@POLIZACARGA,

PRIMASEGURO=@PRIMASEGURO,

SAT_SUBTIPOREM1ID=@SAT_SUBTIPOREM1ID,

PLACA1=@PLACA1,

SAT_SUBTIPOREM2ID=@SAT_SUBTIPOREM2ID,

PLACA2=@PLACA2,

DUENIOID = @DUENIOID,

PESOBRUTOVEHICULAR = @PESOBRUTOVEHICULAR

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

        
        public CVEHICULOBE seleccionarVEHICULO(CVEHICULOBE oCVEHICULO, FbTransaction st)
        {




            CVEHICULOBE retorno = new CVEHICULOBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from VEHICULO where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCVEHICULO.IID;
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

                    if (dr["SAT_TIPOPERMISOID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_TIPOPERMISOID = (long)(dr["SAT_TIPOPERMISOID"]);
                    }

                    if (dr["NUMPERMISOSCT"] != System.DBNull.Value)
                    {
                        retorno.INUMPERMISOSCT = (string)(dr["NUMPERMISOSCT"]);
                    }

                    if (dr["SAT_CONFIGAUTOTRANSPORTEID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CONFIGAUTOTRANSPORTEID = (long)(dr["SAT_CONFIGAUTOTRANSPORTEID"]);
                    }

                    if (dr["PLACAVM"] != System.DBNull.Value)
                    {
                        retorno.IPLACAVM = (string)(dr["PLACAVM"]);
                    }

                    if (dr["ANIOMODELOVM"] != System.DBNull.Value)
                    {
                        retorno.IANIOMODELOVM = (string)(dr["ANIOMODELOVM"]);
                    }

                    if (dr["ASEGURARESPCIVIL"] != System.DBNull.Value)
                    {
                        retorno.IASEGURARESPCIVIL = (string)(dr["ASEGURARESPCIVIL"]);
                    }

                    if (dr["POLIZARESPCIVIL"] != System.DBNull.Value)
                    {
                        retorno.IPOLIZARESPCIVIL = (string)(dr["POLIZARESPCIVIL"]);
                    }

                    if (dr["ASEGURAMEDAMBIENTE"] != System.DBNull.Value)
                    {
                        retorno.IASEGURAMEDAMBIENTE = (string)(dr["ASEGURAMEDAMBIENTE"]);
                    }

                    if (dr["POLIZAMEDAMBIENTE"] != System.DBNull.Value)
                    {
                        retorno.IPOLIZAMEDAMBIENTE = (string)(dr["POLIZAMEDAMBIENTE"]);
                    }

                    if (dr["ASEGURACARGA"] != System.DBNull.Value)
                    {
                        retorno.IASEGURACARGA = (string)(dr["ASEGURACARGA"]);
                    }

                    if (dr["POLIZACARGA"] != System.DBNull.Value)
                    {
                        retorno.IPOLIZACARGA = (string)(dr["POLIZACARGA"]);
                    }

                    if (dr["PRIMASEGURO"] != System.DBNull.Value)
                    {
                        retorno.IPRIMASEGURO = (string)(dr["PRIMASEGURO"]);
                    }

                    if (dr["SAT_SUBTIPOREM1ID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_SUBTIPOREM1ID = (long)(dr["SAT_SUBTIPOREM1ID"]);
                    }

                    if (dr["PLACA1"] != System.DBNull.Value)
                    {
                        retorno.IPLACA1 = (string)(dr["PLACA1"]);
                    }

                    if (dr["SAT_SUBTIPOREM2ID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_SUBTIPOREM2ID = (long)(dr["SAT_SUBTIPOREM2ID"]);
                    }

                    if (dr["PLACA2"] != System.DBNull.Value)
                    {
                        retorno.IPLACA2 = (string)(dr["PLACA2"]);
                    }

                    if (dr["DUENIOID"] != System.DBNull.Value)
                    {
                        retorno.IDUENIOID = (long)(dr["DUENIOID"]);
                    }

                    if (dr["PESOBRUTOVEHICULAR"] != System.DBNull.Value)
                    {
                        retorno.IPESOBRUTOVEHICULAR = (long)(dr["PESOBRUTOVEHICULAR"]);
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








        
        public DataSet enlistarVEHICULO()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_VEHICULO_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        
        public DataSet enlistarCortoVEHICULO()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_VEHICULO_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }


        
        public int ExisteVEHICULO(CVEHICULOBE oCVEHICULO, FbTransaction st)
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
                auxPar.Value = oCVEHICULO.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from VEHICULO where

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




        public CVEHICULOBE AgregarVEHICULO(CVEHICULOBE oCVEHICULO, FbTransaction st)
        {
            try
            {
                int iRes = ExisteVEHICULO(oCVEHICULO, st);
                if (iRes == 1)
                {
                    this.IComentario = "El VEHICULO ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarVEHICULOD(oCVEHICULO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarVEHICULO(CVEHICULOBE oCVEHICULO, FbTransaction st)
        {
            try
            {
                int iRes = ExisteVEHICULO(oCVEHICULO, st);
                if (iRes == 0)
                {
                    this.IComentario = "El VEHICULO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarVEHICULOD(oCVEHICULO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarVEHICULO(CVEHICULOBE oCVEHICULONuevo, CVEHICULOBE oCVEHICULOAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteVEHICULO(oCVEHICULOAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El VEHICULO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarVEHICULOD(oCVEHICULONuevo, oCVEHICULOAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CVEHICULOD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
