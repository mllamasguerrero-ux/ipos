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
    


    public class CPAGODOCTOSAT_IMPD
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

        
        public CPAGODOCTOSAT_IMPBE AgregarPAGODOCTOSAT_IMPD(CPAGODOCTOSAT_IMPBE oCPAGODOCTOSAT_IMP, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCPAGODOCTOSAT_IMP.isnull["IACTIVO"])
                {
                    auxPar.Value = oCPAGODOCTOSAT_IMP.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPAGODOCTOSAT_IMP.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCPAGODOCTOSAT_IMP.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPAGODOCTOSAT_IMP.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCPAGODOCTOSAT_IMP.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@BASEIMP", FbDbType.Numeric);
                if (!(bool)oCPAGODOCTOSAT_IMP.isnull["IBASEIMP"])
                {
                    auxPar.Value = oCPAGODOCTOSAT_IMP.IBASEIMP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOFACTOR", FbDbType.VarChar);
                if (!(bool)oCPAGODOCTOSAT_IMP.isnull["ITIPOFACTOR"])
                {
                    auxPar.Value = oCPAGODOCTOSAT_IMP.ITIPOFACTOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TASACUOTA", FbDbType.VarChar);
                if (!(bool)oCPAGODOCTOSAT_IMP.isnull["ITASACUOTA"])
                {
                    auxPar.Value = oCPAGODOCTOSAT_IMP.ITASACUOTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TASA", FbDbType.Numeric);
                if (!(bool)oCPAGODOCTOSAT_IMP.isnull["ITASA"])
                {
                    auxPar.Value = oCPAGODOCTOSAT_IMP.ITASA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPUESTO", FbDbType.VarChar);
                if (!(bool)oCPAGODOCTOSAT_IMP.isnull["IIMPUESTO"])
                {
                    auxPar.Value = oCPAGODOCTOSAT_IMP.IIMPUESTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPORTE", FbDbType.Numeric);
                if (!(bool)oCPAGODOCTOSAT_IMP.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCPAGODOCTOSAT_IMP.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PAGODOCTOSATID", FbDbType.BigInt);
                if (!(bool)oCPAGODOCTOSAT_IMP.isnull["IPAGODOCTOSATID"])
                {
                    auxPar.Value = oCPAGODOCTOSAT_IMP.IPAGODOCTOSATID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOIMPUESTO", FbDbType.VarChar);
                if (!(bool)oCPAGODOCTOSAT_IMP.isnull["ITIPOIMPUESTO"])
                {
                    auxPar.Value = oCPAGODOCTOSAT_IMP.ITIPOIMPUESTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO PAGODOCTOSAT_IMP
      (
    

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

BASEIMP,

TIPOFACTOR,

TASACUOTA,

TASA,

IMPUESTO,

IMPORTE,

PAGODOCTOSATID,

TIPOIMPUESTO
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@BASEIMP,

@TIPOFACTOR,

@TASACUOTA,

@TASA,

@IMPUESTO,

@IMPORTE,

@PAGODOCTOSATID,

@TIPOIMPUESTO
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCPAGODOCTOSAT_IMP;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }

        
        public bool BorrarPAGODOCTOSAT_IMPD(CPAGODOCTOSAT_IMPBE oCPAGODOCTOSAT_IMP, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPAGODOCTOSAT_IMP.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from PAGODOCTOSAT_IMP
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

        
        public bool CambiarPAGODOCTOSAT_IMPD(CPAGODOCTOSAT_IMPBE oCPAGODOCTOSAT_IMPNuevo, CPAGODOCTOSAT_IMPBE oCPAGODOCTOSAT_IMPAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCPAGODOCTOSAT_IMPNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCPAGODOCTOSAT_IMPNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPAGODOCTOSAT_IMPNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCPAGODOCTOSAT_IMPNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@BASEIMP", FbDbType.Numeric);
                if (!(bool)oCPAGODOCTOSAT_IMPNuevo.isnull["IBASEIMP"])
                {
                    auxPar.Value = oCPAGODOCTOSAT_IMPNuevo.IBASEIMP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPOFACTOR", FbDbType.VarChar);
                if (!(bool)oCPAGODOCTOSAT_IMPNuevo.isnull["ITIPOFACTOR"])
                {
                    auxPar.Value = oCPAGODOCTOSAT_IMPNuevo.ITIPOFACTOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TASACUOTA", FbDbType.VarChar);
                if (!(bool)oCPAGODOCTOSAT_IMPNuevo.isnull["ITASACUOTA"])
                {
                    auxPar.Value = oCPAGODOCTOSAT_IMPNuevo.ITASACUOTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TASA", FbDbType.Numeric);
                if (!(bool)oCPAGODOCTOSAT_IMPNuevo.isnull["ITASA"])
                {
                    auxPar.Value = oCPAGODOCTOSAT_IMPNuevo.ITASA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IMPUESTO", FbDbType.VarChar);
                if (!(bool)oCPAGODOCTOSAT_IMPNuevo.isnull["IIMPUESTO"])
                {
                    auxPar.Value = oCPAGODOCTOSAT_IMPNuevo.IIMPUESTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IMPORTE", FbDbType.Numeric);
                if (!(bool)oCPAGODOCTOSAT_IMPNuevo.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCPAGODOCTOSAT_IMPNuevo.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PAGODOCTOSATID", FbDbType.BigInt);
                if (!(bool)oCPAGODOCTOSAT_IMPNuevo.isnull["IPAGODOCTOSATID"])
                {
                    auxPar.Value = oCPAGODOCTOSAT_IMPNuevo.IPAGODOCTOSATID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOIMPUESTO", FbDbType.VarChar);
                if (!(bool)oCPAGODOCTOSAT_IMPNuevo.isnull["ITIPOIMPUESTO"])
                {
                    auxPar.Value = oCPAGODOCTOSAT_IMPNuevo.ITIPOIMPUESTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCPAGODOCTOSAT_IMPAnterior.isnull["IID"])
                {
                    auxPar.Value = oCPAGODOCTOSAT_IMPAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  PAGODOCTOSAT_IMP
  set


ACTIVO=@ACTIVO,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

BASEIMP=@BASEIMP,

TIPOFACTOR=@TIPOFACTOR,

TASACUOTA=@TASACUOTA,

TASA=@TASA,

IMPUESTO=@IMPUESTO,

IMPORTE=@IMPORTE,

PAGODOCTOSATID=@PAGODOCTOSATID,

TIPOIMPUESTO =  @TIPOIMPUESTO

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

        
        public CPAGODOCTOSAT_IMPBE seleccionarPAGODOCTOSAT_IMP(CPAGODOCTOSAT_IMPBE oCPAGODOCTOSAT_IMP, FbTransaction st)
        {




            CPAGODOCTOSAT_IMPBE retorno = new CPAGODOCTOSAT_IMPBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from PAGODOCTOSAT_IMP where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPAGODOCTOSAT_IMP.IID;
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

                    if (dr["BASEIMP"] != System.DBNull.Value)
                    {
                        retorno.IBASEIMP = (decimal)(dr["BASEIMP"]);
                    }

                    if (dr["TIPOFACTOR"] != System.DBNull.Value)
                    {
                        retorno.ITIPOFACTOR = (string)(dr["TIPOFACTOR"]);
                    }

                    if (dr["TASACUOTA"] != System.DBNull.Value)
                    {
                        retorno.ITASACUOTA = (string)(dr["TASACUOTA"]);
                    }

                    if (dr["TASA"] != System.DBNull.Value)
                    {
                        retorno.ITASA = (decimal)(dr["TASA"]);
                    }

                    if (dr["IMPUESTO"] != System.DBNull.Value)
                    {
                        retorno.IIMPUESTO = (string)(dr["IMPUESTO"]);
                    }

                    if (dr["IMPORTE"] != System.DBNull.Value)
                    {
                        retorno.IIMPORTE = (decimal)(dr["IMPORTE"]);
                    }

                    if (dr["PAGODOCTOSATID"] != System.DBNull.Value)
                    {
                        retorno.IPAGODOCTOSATID = (long)(dr["PAGODOCTOSATID"]);
                    }

                    if (dr["TIPOIMPUESTO"] != System.DBNull.Value)
                    {
                        retorno.ITIPOIMPUESTO = (string)(dr["TIPOIMPUESTO"]);
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





        public List<CPAGODOCTOSAT_IMPBE> seleccionarPAGODOCTOSAT_IMPByPAGOSATID(long doctoSatId, FbTransaction st)
        {

            CPAGODOCTOSAT_IMPBE auxItem = new CPAGODOCTOSAT_IMPBE();
            List<CPAGODOCTOSAT_IMPBE> retorno = new List<CPAGODOCTOSAT_IMPBE>();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select i.*, p.IDDOCUMENTO 
                                    from PAGODOCTOSAT_IMP i
                                    left join PAGODOCTOSAT p on p.id = i.PAGODOCTOSATID
                                    left join PAGOSAT ps on ps.id = p.pagosatid
                                    where ps.DOCTOSATID = @DOCTOSATID  ";


                auxPar = new FbParameter("@DOCTOSATID", FbDbType.BigInt);
                auxPar.Value = doctoSatId;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);



                while (dr.Read())
                {
                    auxItem = new CPAGODOCTOSAT_IMPBE();

                    if (dr["ID"] != System.DBNull.Value)
                    {
                        auxItem.IID = (long)(dr["ID"]);
                    }

                    if (dr["ACTIVO"] != System.DBNull.Value)
                    {
                        auxItem.IACTIVO = (string)(dr["ACTIVO"]);
                    }

                    if (dr["CREADO"] != System.DBNull.Value)
                    {
                        auxItem.ICREADO = (object)(dr["CREADO"]);
                    }

                    if (dr["CREADOPOR_USERID"] != System.DBNull.Value)
                    {
                        auxItem.ICREADOPOR_USERID = (long)(dr["CREADOPOR_USERID"]);
                    }

                    if (dr["MODIFICADO"] != System.DBNull.Value)
                    {
                        auxItem.IMODIFICADO = (object)(dr["MODIFICADO"]);
                    }

                    if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
                    {
                        auxItem.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
                    }

                    if (dr["BASEIMP"] != System.DBNull.Value)
                    {
                        auxItem.IBASEIMP = (decimal)(dr["BASEIMP"]);
                    }

                    if (dr["TIPOFACTOR"] != System.DBNull.Value)
                    {
                        auxItem.ITIPOFACTOR = (string)(dr["TIPOFACTOR"]);
                    }

                    if (dr["TASACUOTA"] != System.DBNull.Value)
                    {
                        auxItem.ITASACUOTA = (string)(dr["TASACUOTA"]);
                    }

                    if (dr["TASA"] != System.DBNull.Value)
                    {
                        auxItem.ITASA = (decimal)(dr["TASA"]);
                    }

                    if (dr["IMPUESTO"] != System.DBNull.Value)
                    {
                        auxItem.IIMPUESTO = (string)(dr["IMPUESTO"]);
                    }

                    if (dr["IMPORTE"] != System.DBNull.Value)
                    {
                        auxItem.IIMPORTE = (decimal)(dr["IMPORTE"]);
                    }

                    if (dr["PAGODOCTOSATID"] != System.DBNull.Value)
                    {
                        auxItem.IPAGODOCTOSATID = (long)(dr["PAGODOCTOSATID"]);
                    }

                    if (dr["IDDOCUMENTO"] != System.DBNull.Value)
                    {
                        auxItem.IIDDOCUMENTO = (string)(dr["IDDOCUMENTO"]);
                    }

                    if (dr["TIPOIMPUESTO"] != System.DBNull.Value)
                    {
                        auxItem.ITIPOIMPUESTO = (string)(dr["TIPOIMPUESTO"]);
                    }

                    retorno.Add(auxItem);
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
        public DataSet enlistarPAGODOCTOSAT_IMP()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PAGODOCTOSAT_IMP_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoPAGODOCTOSAT_IMP()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PAGODOCTOSAT_IMP_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExistePAGODOCTOSAT_IMP(CPAGODOCTOSAT_IMPBE oCPAGODOCTOSAT_IMP, FbTransaction st)
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
                auxPar.Value = oCPAGODOCTOSAT_IMP.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from PAGODOCTOSAT_IMP where

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




        public CPAGODOCTOSAT_IMPBE AgregarPAGODOCTOSAT_IMP(CPAGODOCTOSAT_IMPBE oCPAGODOCTOSAT_IMP, FbTransaction st)
        {
            try
            {
                int iRes = ExistePAGODOCTOSAT_IMP(oCPAGODOCTOSAT_IMP, st);
                if (iRes == 1)
                {
                    this.IComentario = "El PAGODOCTOSAT_IMP ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarPAGODOCTOSAT_IMPD(oCPAGODOCTOSAT_IMP, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarPAGODOCTOSAT_IMP(CPAGODOCTOSAT_IMPBE oCPAGODOCTOSAT_IMP, FbTransaction st)
        {
            try
            {
                int iRes = ExistePAGODOCTOSAT_IMP(oCPAGODOCTOSAT_IMP, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PAGODOCTOSAT_IMP no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarPAGODOCTOSAT_IMPD(oCPAGODOCTOSAT_IMP, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarPAGODOCTOSAT_IMP(CPAGODOCTOSAT_IMPBE oCPAGODOCTOSAT_IMPNuevo, CPAGODOCTOSAT_IMPBE oCPAGODOCTOSAT_IMPAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExistePAGODOCTOSAT_IMP(oCPAGODOCTOSAT_IMPAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PAGODOCTOSAT_IMP no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarPAGODOCTOSAT_IMPD(oCPAGODOCTOSAT_IMPNuevo, oCPAGODOCTOSAT_IMPAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CPAGODOCTOSAT_IMPD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
