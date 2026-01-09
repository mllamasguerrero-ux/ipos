

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



    public class CPAGODOCTOSATD
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


        public CPAGODOCTOSATBE AgregarPAGODOCTOSATD(CPAGODOCTOSATBE oCPAGODOCTOSAT, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCPAGODOCTOSAT.isnull["IACTIVO"])
                {
                    auxPar.Value = oCPAGODOCTOSAT.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPAGODOCTOSAT.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCPAGODOCTOSAT.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPAGODOCTOSAT.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCPAGODOCTOSAT.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOPAGOID", FbDbType.BigInt);
                if (!(bool)oCPAGODOCTOSAT.isnull["IDOCTOPAGOID"])
                {
                    auxPar.Value = oCPAGODOCTOSAT.IDOCTOPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PAGOSATID", FbDbType.BigInt);
                if (!(bool)oCPAGODOCTOSAT.isnull["IPAGOSATID"])
                {
                    auxPar.Value = oCPAGODOCTOSAT.IPAGOSATID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDDOCUMENTO", FbDbType.VarChar);
                if (!(bool)oCPAGODOCTOSAT.isnull["IIDDOCUMENTO"])
                {
                    auxPar.Value = oCPAGODOCTOSAT.IIDDOCUMENTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SERIE", FbDbType.VarChar);
                if (!(bool)oCPAGODOCTOSAT.isnull["ISERIE"])
                {
                    auxPar.Value = oCPAGODOCTOSAT.ISERIE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FOLIO", FbDbType.VarChar);
                if (!(bool)oCPAGODOCTOSAT.isnull["IFOLIO"])
                {
                    auxPar.Value = oCPAGODOCTOSAT.IFOLIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONEDADR", FbDbType.VarChar);
                if (!(bool)oCPAGODOCTOSAT.isnull["IMONEDADR"])
                {
                    auxPar.Value = oCPAGODOCTOSAT.IMONEDADR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOCAMBIODR", FbDbType.VarChar);
                if (!(bool)oCPAGODOCTOSAT.isnull["ITIPOCAMBIODR"])
                {
                    auxPar.Value = oCPAGODOCTOSAT.ITIPOCAMBIODR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@METODODEPAGODR", FbDbType.VarChar);
                if (!(bool)oCPAGODOCTOSAT.isnull["IMETODODEPAGODR"])
                {
                    auxPar.Value = oCPAGODOCTOSAT.IMETODODEPAGODR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUMPARCIALIDAD", FbDbType.Integer);
                if (!(bool)oCPAGODOCTOSAT.isnull["INUMPARCIALIDAD"])
                {
                    auxPar.Value = oCPAGODOCTOSAT.INUMPARCIALIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPSALDOANT", FbDbType.Numeric);
                if (!(bool)oCPAGODOCTOSAT.isnull["IIMPSALDOANT"])
                {
                    auxPar.Value = oCPAGODOCTOSAT.IIMPSALDOANT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPPAGADO", FbDbType.Numeric);
                if (!(bool)oCPAGODOCTOSAT.isnull["IIMPPAGADO"])
                {
                    auxPar.Value = oCPAGODOCTOSAT.IIMPPAGADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPSALDOINSOLUTO", FbDbType.Numeric);
                if (!(bool)oCPAGODOCTOSAT.isnull["IIMPSALDOINSOLUTO"])
                {
                    auxPar.Value = oCPAGODOCTOSAT.IIMPSALDOINSOLUTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@OBJETOIMPDR", FbDbType.VarChar);
                if (!(bool)oCPAGODOCTOSAT.isnull["IOBJETOIMPDR"])
                {
                    auxPar.Value = oCPAGODOCTOSAT.IOBJETOIMPDR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO PAGODOCTOSAT
      (
    
ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

DOCTOPAGOID,

PAGOSATID,

IDDOCUMENTO,

SERIE,

FOLIO,

MONEDADR,

TIPOCAMBIODR,

METODODEPAGODR,

NUMPARCIALIDAD,

IMPSALDOANT,

IMPPAGADO,

IMPSALDOINSOLUTO,

OBJETOIMPDR
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@DOCTOPAGOID,

@PAGOSATID,

@IDDOCUMENTO,

@SERIE,

@FOLIO,

@MONEDADR,

@TIPOCAMBIODR,

@METODODEPAGODR,

@NUMPARCIALIDAD,

@IMPSALDOANT,

@IMPPAGADO,

@IMPSALDOINSOLUTO,

@OBJETOIMPDR
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCPAGODOCTOSAT;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarPAGODOCTOSATD(CPAGODOCTOSATBE oCPAGODOCTOSAT, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPAGODOCTOSAT.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from PAGODOCTOSAT
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


        public bool CambiarPAGODOCTOSATD(CPAGODOCTOSATBE oCPAGODOCTOSATNuevo, CPAGODOCTOSATBE oCPAGODOCTOSATAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCPAGODOCTOSATNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCPAGODOCTOSATNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPAGODOCTOSATNuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCPAGODOCTOSATNuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPAGODOCTOSATNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCPAGODOCTOSATNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOCTOPAGOID", FbDbType.BigInt);
                if (!(bool)oCPAGODOCTOSATNuevo.isnull["IDOCTOPAGOID"])
                {
                    auxPar.Value = oCPAGODOCTOSATNuevo.IDOCTOPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PAGOSATID", FbDbType.BigInt);
                if (!(bool)oCPAGODOCTOSATNuevo.isnull["IPAGOSATID"])
                {
                    auxPar.Value = oCPAGODOCTOSATNuevo.IPAGOSATID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDDOCUMENTO", FbDbType.VarChar);
                if (!(bool)oCPAGODOCTOSATNuevo.isnull["IIDDOCUMENTO"])
                {
                    auxPar.Value = oCPAGODOCTOSATNuevo.IIDDOCUMENTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SERIE", FbDbType.VarChar);
                if (!(bool)oCPAGODOCTOSATNuevo.isnull["ISERIE"])
                {
                    auxPar.Value = oCPAGODOCTOSATNuevo.ISERIE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FOLIO", FbDbType.VarChar);
                if (!(bool)oCPAGODOCTOSATNuevo.isnull["IFOLIO"])
                {
                    auxPar.Value = oCPAGODOCTOSATNuevo.IFOLIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONEDADR", FbDbType.VarChar);
                if (!(bool)oCPAGODOCTOSATNuevo.isnull["IMONEDADR"])
                {
                    auxPar.Value = oCPAGODOCTOSATNuevo.IMONEDADR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPOCAMBIODR", FbDbType.VarChar);
                if (!(bool)oCPAGODOCTOSATNuevo.isnull["ITIPOCAMBIODR"])
                {
                    auxPar.Value = oCPAGODOCTOSATNuevo.ITIPOCAMBIODR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@METODODEPAGODR", FbDbType.VarChar);
                if (!(bool)oCPAGODOCTOSATNuevo.isnull["IMETODODEPAGODR"])
                {
                    auxPar.Value = oCPAGODOCTOSATNuevo.IMETODODEPAGODR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMPARCIALIDAD", FbDbType.Integer);
                if (!(bool)oCPAGODOCTOSATNuevo.isnull["INUMPARCIALIDAD"])
                {
                    auxPar.Value = oCPAGODOCTOSATNuevo.INUMPARCIALIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IMPSALDOANT", FbDbType.Numeric);
                if (!(bool)oCPAGODOCTOSATNuevo.isnull["IIMPSALDOANT"])
                {
                    auxPar.Value = oCPAGODOCTOSATNuevo.IIMPSALDOANT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IMPPAGADO", FbDbType.Numeric);
                if (!(bool)oCPAGODOCTOSATNuevo.isnull["IIMPPAGADO"])
                {
                    auxPar.Value = oCPAGODOCTOSATNuevo.IIMPPAGADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IMPSALDOINSOLUTO", FbDbType.Numeric);
                if (!(bool)oCPAGODOCTOSATNuevo.isnull["IIMPSALDOINSOLUTO"])
                {
                    auxPar.Value = oCPAGODOCTOSATNuevo.IIMPSALDOINSOLUTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@OBJETOIMPDR", FbDbType.VarChar);
                if (!(bool)oCPAGODOCTOSATNuevo.isnull["IOBJETOIMPDR"])
                {
                    auxPar.Value = oCPAGODOCTOSATNuevo.IOBJETOIMPDR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCPAGODOCTOSATAnterior.isnull["IID"])
                {
                    auxPar.Value = oCPAGODOCTOSATAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  PAGODOCTOSAT
  set

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

DOCTOPAGOID=@DOCTOPAGOID,

PAGOSATID=@PAGOSATID,

IDDOCUMENTO=@IDDOCUMENTO,

SERIE=@SERIE,

FOLIO=@FOLIO,

MONEDADR=@MONEDADR,

TIPOCAMBIODR=@TIPOCAMBIODR,

METODODEPAGODR=@METODODEPAGODR,

NUMPARCIALIDAD=@NUMPARCIALIDAD,

IMPSALDOANT=@IMPSALDOANT,

IMPPAGADO=@IMPPAGADO,

IMPSALDOINSOLUTO=@IMPSALDOINSOLUTO,

OBJETOIMPDR = @OBJETOIMPDR
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


        public CPAGODOCTOSATBE seleccionarPAGODOCTOSAT(CPAGODOCTOSATBE oCPAGODOCTOSAT, FbTransaction st)
        {




            CPAGODOCTOSATBE retorno = new CPAGODOCTOSATBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from PAGODOCTOSAT where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPAGODOCTOSAT.IID;
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

                    if (dr["DOCTOPAGOID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOPAGOID = (long)(dr["DOCTOPAGOID"]);
                    }

                    if (dr["PAGOSATID"] != System.DBNull.Value)
                    {
                        retorno.IPAGOSATID = (long)(dr["PAGOSATID"]);
                    }

                    if (dr["IDDOCUMENTO"] != System.DBNull.Value)
                    {
                        retorno.IIDDOCUMENTO = (string)(dr["IDDOCUMENTO"]);
                    }

                    if (dr["SERIE"] != System.DBNull.Value)
                    {
                        retorno.ISERIE = (string)(dr["SERIE"]);
                    }

                    if (dr["FOLIO"] != System.DBNull.Value)
                    {
                        retorno.IFOLIO = (string)(dr["FOLIO"]);
                    }

                    if (dr["MONEDADR"] != System.DBNull.Value)
                    {
                        retorno.IMONEDADR = (string)(dr["MONEDADR"]);
                    }

                    if (dr["TIPOCAMBIODR"] != System.DBNull.Value)
                    {
                        retorno.ITIPOCAMBIODR = (string)(dr["TIPOCAMBIODR"]);
                    }

                    if (dr["METODODEPAGODR"] != System.DBNull.Value)
                    {
                        retorno.IMETODODEPAGODR = (string)(dr["METODODEPAGODR"]);
                    }

                    if (dr["IMPSALDOANT"] != System.DBNull.Value)
                    {
                        retorno.IIMPSALDOANT = (decimal)(dr["IMPSALDOANT"]);
                    }

                    if (dr["IMPPAGADO"] != System.DBNull.Value)
                    {
                        retorno.IIMPPAGADO = (decimal)(dr["IMPPAGADO"]);
                    }

                    if (dr["IMPSALDOINSOLUTO"] != System.DBNull.Value)
                    {
                        retorno.IIMPSALDOINSOLUTO = (decimal)(dr["IMPSALDOINSOLUTO"]);
                    }

                    if (dr["NUMPARCIALIDAD"] != System.DBNull.Value)
                    {
                        retorno.INUMPARCIALIDAD = int.Parse(dr["NUMPARCIALIDAD"].ToString());
                    }

                    if (dr["OBJETOIMPDR"] != System.DBNull.Value)
                    {
                        retorno.IOBJETOIMPDR = (string)(dr["OBJETOIMPDR"]);
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




        public List<CPAGODOCTOSATBE> seleccionarPAGODOCTOSATByPAGOSATID(long pagoSatId, FbTransaction st)
        {



            CPAGODOCTOSATBE auxItem = new CPAGODOCTOSATBE();
            List<CPAGODOCTOSATBE> retorno = new List<CPAGODOCTOSATBE>();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from PAGODOCTOSAT where
 PAGOSATID=@PAGOSATID  ";


                auxPar = new FbParameter("@PAGOSATID", FbDbType.BigInt);
                auxPar.Value = pagoSatId;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                while (dr.Read())
                {
                    auxItem = new CPAGODOCTOSATBE();

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

                    if (dr["DOCTOPAGOID"] != System.DBNull.Value)
                    {
                        auxItem.IDOCTOPAGOID = (long)(dr["DOCTOPAGOID"]);
                    }

                    if (dr["PAGOSATID"] != System.DBNull.Value)
                    {
                        auxItem.IPAGOSATID = (long)(dr["PAGOSATID"]);
                    }

                    if (dr["IDDOCUMENTO"] != System.DBNull.Value)
                    {
                        auxItem.IIDDOCUMENTO = (string)(dr["IDDOCUMENTO"]);
                    }

                    if (dr["SERIE"] != System.DBNull.Value)
                    {
                        auxItem.ISERIE = (string)(dr["SERIE"]);
                    }

                    if (dr["FOLIO"] != System.DBNull.Value)
                    {
                        auxItem.IFOLIO = (string)(dr["FOLIO"]);
                    }

                    if (dr["MONEDADR"] != System.DBNull.Value)
                    {
                        auxItem.IMONEDADR = (string)(dr["MONEDADR"]);
                    }

                    if (dr["TIPOCAMBIODR"] != System.DBNull.Value)
                    {
                        auxItem.ITIPOCAMBIODR = (string)(dr["TIPOCAMBIODR"]);
                    }

                    if (dr["METODODEPAGODR"] != System.DBNull.Value)
                    {
                        auxItem.IMETODODEPAGODR = (string)(dr["METODODEPAGODR"]);
                    }

                    if (dr["IMPSALDOANT"] != System.DBNull.Value)
                    {
                        auxItem.IIMPSALDOANT = (decimal)(dr["IMPSALDOANT"]);
                    }

                    if (dr["IMPPAGADO"] != System.DBNull.Value)
                    {
                        auxItem.IIMPPAGADO = (decimal)(dr["IMPPAGADO"]);
                    }

                    if (dr["IMPSALDOINSOLUTO"] != System.DBNull.Value)
                    {
                        auxItem.IIMPSALDOINSOLUTO = (decimal)(dr["IMPSALDOINSOLUTO"]);
                    }

                    if (dr["NUMPARCIALIDAD"] != System.DBNull.Value)
                    {
                        auxItem.INUMPARCIALIDAD = int.Parse(dr["NUMPARCIALIDAD"].ToString());
                    }

                    if (dr["OBJETOIMPDR"] != System.DBNull.Value)
                    {
                        auxItem.IOBJETOIMPDR= (string)(dr["OBJETOIMPDR"]);
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




        public DataSet enlistarPAGODOCTOSAT()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_PAGODOCTOSAT_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public DataSet enlistarCortoPAGODOCTOSAT()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_PAGODOCTOSAT_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public int ExistePAGODOCTOSAT(CPAGODOCTOSATBE oCPAGODOCTOSAT, FbTransaction st)
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
                auxPar.Value = oCPAGODOCTOSAT.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from PAGODOCTOSAT where

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




        public CPAGODOCTOSATBE AgregarPAGODOCTOSAT(CPAGODOCTOSATBE oCPAGODOCTOSAT, FbTransaction st)
        {
            try
            {
                int iRes = ExistePAGODOCTOSAT(oCPAGODOCTOSAT, st);
                if (iRes == 1)
                {
                    this.IComentario = "El PAGODOCTOSAT ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarPAGODOCTOSATD(oCPAGODOCTOSAT, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarPAGODOCTOSAT(CPAGODOCTOSATBE oCPAGODOCTOSAT, FbTransaction st)
        {
            try
            {
                int iRes = ExistePAGODOCTOSAT(oCPAGODOCTOSAT, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PAGODOCTOSAT no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarPAGODOCTOSATD(oCPAGODOCTOSAT, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarPAGODOCTOSAT(CPAGODOCTOSATBE oCPAGODOCTOSATNuevo, CPAGODOCTOSATBE oCPAGODOCTOSATAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExistePAGODOCTOSAT(oCPAGODOCTOSATAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PAGODOCTOSAT no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarPAGODOCTOSATD(oCPAGODOCTOSATNuevo, oCPAGODOCTOSATAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CPAGODOCTOSATD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
