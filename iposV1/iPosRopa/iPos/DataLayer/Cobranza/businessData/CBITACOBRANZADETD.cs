

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


    public class CBITACOBRANZADETD
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


        [AutoComplete]
        public CBITACOBRANZADETBE AgregarBITACOBRANZADETD(CBITACOBRANZADETBE oCBITACOBRANZADET, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@BITCOBRANZAID", FbDbType.BigInt);
                if (!(bool)oCBITACOBRANZADET.isnull["IBITCOBRANZAID"])
                {
                    auxPar.Value = oCBITACOBRANZADET.IBITCOBRANZAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCBITACOBRANZADET.isnull["IFECHA"])
                {
                    auxPar.Value = oCBITACOBRANZADET.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COBRADORID", FbDbType.BigInt);
                if (!(bool)oCBITACOBRANZADET.isnull["ICOBRADORID"])
                {
                    auxPar.Value = oCBITACOBRANZADET.ICOBRADORID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (!(bool)oCBITACOBRANZADET.isnull["IPERSONAID"])
                {
                    auxPar.Value = oCBITACOBRANZADET.IPERSONAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if (!(bool)oCBITACOBRANZADET.isnull["IDOCTOID"])
                {
                    auxPar.Value = oCBITACOBRANZADET.IDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SALDO", FbDbType.Numeric);
                if (!(bool)oCBITACOBRANZADET.isnull["ISALDO"])
                {
                    auxPar.Value = oCBITACOBRANZADET.ISALDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAVENCE", FbDbType.Date);
                if (!(bool)oCBITACOBRANZADET.isnull["IFECHAVENCE"])
                {
                    auxPar.Value = oCBITACOBRANZADET.IFECHAVENCE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DIAPAGOS", FbDbType.VarChar);
                if (!(bool)oCBITACOBRANZADET.isnull["IDIAPAGOS"])
                {
                    auxPar.Value = oCBITACOBRANZADET.IDIAPAGOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ABONO", FbDbType.Numeric);
                if (!(bool)oCBITACOBRANZADET.isnull["IABONO"])
                {
                    auxPar.Value = oCBITACOBRANZADET.IABONO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOPAGOID", FbDbType.BigInt);
                if (!(bool)oCBITACOBRANZADET.isnull["IDOCTOPAGOID"])
                {
                    auxPar.Value = oCBITACOBRANZADET.IDOCTOPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTADO", FbDbType.BigInt);
                if (!(bool)oCBITACOBRANZADET.isnull["IESTADO"])
                {
                    auxPar.Value = oCBITACOBRANZADET.IESTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@OBSERVACIONES", FbDbType.VarChar);
                if (!(bool)oCBITACOBRANZADET.isnull["IOBSERVACIONES"])
                {
                    auxPar.Value = oCBITACOBRANZADET.IOBSERVACIONES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUEVAFECHACOBRO", FbDbType.Date);
                if (!(bool)oCBITACOBRANZADET.isnull["INUEVAFECHACOBRO"])
                {
                    auxPar.Value = oCBITACOBRANZADET.INUEVAFECHACOBRO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO BITACOBRANZADET
      (
    


BITCOBRANZAID,

FECHA,

COBRADORID,

PERSONAID,

DOCTOID,

SALDO,

FECHAVENCE,

DIAPAGOS,

ABONO,

DOCTOPAGOID,

ESTADO,

OBSERVACIONES,

NUEVAFECHACOBRO
         )

Values (



@BITCOBRANZAID,

@FECHA,

@COBRADORID,

@PERSONAID,

@DOCTOID,

@SALDO,

@FECHAVENCE,

@DIAPAGOS,

@ABONO,

@DOCTOPAGOID,

@ESTADO,

@OBSERVACIONES,

@NUEVAFECHACOBRO
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCBITACOBRANZADET;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarBITACOBRANZADETD(CBITACOBRANZADETBE oCBITACOBRANZADET, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCBITACOBRANZADET.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from BITACOBRANZADET
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


        [AutoComplete]
        public bool CambiarBITACOBRANZADETD(CBITACOBRANZADETBE oCBITACOBRANZADETNuevo, CBITACOBRANZADETBE oCBITACOBRANZADETAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@BITCOBRANZAID", FbDbType.BigInt);
                if (!(bool)oCBITACOBRANZADETNuevo.isnull["IBITCOBRANZAID"])
                {
                    auxPar.Value = oCBITACOBRANZADETNuevo.IBITCOBRANZAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCBITACOBRANZADETNuevo.isnull["IFECHA"])
                {
                    auxPar.Value = oCBITACOBRANZADETNuevo.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@COBRADORID", FbDbType.BigInt);
                if (!(bool)oCBITACOBRANZADETNuevo.isnull["ICOBRADORID"])
                {
                    auxPar.Value = oCBITACOBRANZADETNuevo.ICOBRADORID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (!(bool)oCBITACOBRANZADETNuevo.isnull["IPERSONAID"])
                {
                    auxPar.Value = oCBITACOBRANZADETNuevo.IPERSONAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if (!(bool)oCBITACOBRANZADETNuevo.isnull["IDOCTOID"])
                {
                    auxPar.Value = oCBITACOBRANZADETNuevo.IDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SALDO", FbDbType.Numeric);
                if (!(bool)oCBITACOBRANZADETNuevo.isnull["ISALDO"])
                {
                    auxPar.Value = oCBITACOBRANZADETNuevo.ISALDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAVENCE", FbDbType.Date);
                if (!(bool)oCBITACOBRANZADETNuevo.isnull["IFECHAVENCE"])
                {
                    auxPar.Value = oCBITACOBRANZADETNuevo.IFECHAVENCE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DIAPAGOS", FbDbType.VarChar);
                if (!(bool)oCBITACOBRANZADETNuevo.isnull["IDIAPAGOS"])
                {
                    auxPar.Value = oCBITACOBRANZADETNuevo.IDIAPAGOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ABONO", FbDbType.Numeric);
                if (!(bool)oCBITACOBRANZADETNuevo.isnull["IABONO"])
                {
                    auxPar.Value = oCBITACOBRANZADETNuevo.IABONO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOCTOPAGOID", FbDbType.BigInt);
                if (!(bool)oCBITACOBRANZADETNuevo.isnull["IDOCTOPAGOID"])
                {
                    auxPar.Value = oCBITACOBRANZADETNuevo.IDOCTOPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESTADO", FbDbType.BigInt);
                if (!(bool)oCBITACOBRANZADETNuevo.isnull["IESTADO"])
                {
                    auxPar.Value = oCBITACOBRANZADETNuevo.IESTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@OBSERVACIONES", FbDbType.VarChar);
                if (!(bool)oCBITACOBRANZADETNuevo.isnull["IOBSERVACIONES"])
                {
                    auxPar.Value = oCBITACOBRANZADETNuevo.IOBSERVACIONES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUEVAFECHACOBRO", FbDbType.Date);
                if (!(bool)oCBITACOBRANZADETNuevo.isnull["INUEVAFECHACOBRO"])
                {
                    auxPar.Value = oCBITACOBRANZADETNuevo.INUEVAFECHACOBRO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCBITACOBRANZADETAnterior.isnull["IID"])
                {
                    auxPar.Value = oCBITACOBRANZADETAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  BITACOBRANZADET
  set


BITCOBRANZAID=@BITCOBRANZAID,

FECHA=@FECHA,

COBRADORID=@COBRADORID,

PERSONAID=@PERSONAID,

DOCTOID=@DOCTOID,

SALDO=@SALDO,

FECHAVENCE=@FECHAVENCE,

DIAPAGOS=@DIAPAGOS,

ABONO=@ABONO,

DOCTOPAGOID=@DOCTOPAGOID,

ESTADO=@ESTADO,

OBSERVACIONES=@OBSERVACIONES,

NUEVAFECHACOBRO=@NUEVAFECHACOBRO
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


        [AutoComplete]
        public CBITACOBRANZADETBE seleccionarBITACOBRANZADET(CBITACOBRANZADETBE oCBITACOBRANZADET, FbTransaction st)
        {




            CBITACOBRANZADETBE retorno = new CBITACOBRANZADETBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from BITACOBRANZADET where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCBITACOBRANZADET.IID;
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

                    if (dr["BITCOBRANZAID"] != System.DBNull.Value)
                    {
                        retorno.IBITCOBRANZAID = (long)(dr["BITCOBRANZAID"]);
                    }

                    if (dr["FECHA"] != System.DBNull.Value)
                    {
                        retorno.IFECHA = (DateTime)(dr["FECHA"]);
                    }

                    if (dr["COBRADORID"] != System.DBNull.Value)
                    {
                        retorno.ICOBRADORID = (long)(dr["COBRADORID"]);
                    }

                    if (dr["PERSONAID"] != System.DBNull.Value)
                    {
                        retorno.IPERSONAID = (long)(dr["PERSONAID"]);
                    }

                    if (dr["DOCTOID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOID = (long)(dr["DOCTOID"]);
                    }

                    if (dr["SALDO"] != System.DBNull.Value)
                    {
                        retorno.ISALDO = (decimal)(dr["SALDO"]);
                    }

                    if (dr["FECHAVENCE"] != System.DBNull.Value)
                    {
                        retorno.IFECHAVENCE = (DateTime)(dr["FECHAVENCE"]);
                    }

                    if (dr["DIAPAGOS"] != System.DBNull.Value)
                    {
                        retorno.IDIAPAGOS = (string)(dr["DIAPAGOS"]);
                    }

                    if (dr["ABONO"] != System.DBNull.Value)
                    {
                        retorno.IABONO = (decimal)(dr["ABONO"]);
                    }

                    if (dr["DOCTOPAGOID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOPAGOID = (long)(dr["DOCTOPAGOID"]);
                    }

                    if (dr["ESTADO"] != System.DBNull.Value)
                    {
                        retorno.IESTADO = (long)(dr["ESTADO"]);
                    }

                    if (dr["OBSERVACIONES"] != System.DBNull.Value)
                    {
                        retorno.IOBSERVACIONES = (string)(dr["OBSERVACIONES"]);
                    }

                    if (dr["NUEVAFECHACOBRO"] != System.DBNull.Value)
                    {
                        retorno.INUEVAFECHACOBRO = (DateTime)(dr["NUEVAFECHACOBRO"]);
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









        [AutoComplete]
        public DataSet enlistarBITACOBRANZADET()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_BITACOBRANZADET_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoBITACOBRANZADET()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_BITACOBRANZADET_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteBITACOBRANZADET(CBITACOBRANZADETBE oCBITACOBRANZADET, FbTransaction st)
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



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCBITACOBRANZADET.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from BITACOBRANZADET where

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




        public CBITACOBRANZADETBE AgregarBITACOBRANZADET(CBITACOBRANZADETBE oCBITACOBRANZADET, FbTransaction st)
        {
            try
            {
                int iRes = ExisteBITACOBRANZADET(oCBITACOBRANZADET, st);
                if (iRes == 1)
                {
                    this.IComentario = "El BITACOBRANZADET ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarBITACOBRANZADETD(oCBITACOBRANZADET, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarBITACOBRANZADET(CBITACOBRANZADETBE oCBITACOBRANZADET, FbTransaction st)
        {
            try
            {
                int iRes = ExisteBITACOBRANZADET(oCBITACOBRANZADET, st);
                if (iRes == 0)
                {
                    this.IComentario = "El BITACOBRANZADET no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarBITACOBRANZADETD(oCBITACOBRANZADET, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarBITACOBRANZADET(CBITACOBRANZADETBE oCBITACOBRANZADETNuevo, CBITACOBRANZADETBE oCBITACOBRANZADETAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteBITACOBRANZADET(oCBITACOBRANZADETAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El BITACOBRANZADET no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarBITACOBRANZADETD(oCBITACOBRANZADETNuevo, oCBITACOBRANZADETAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CBITACOBRANZADETBE BITACOBRANZAAGREGARDETALLE(CBITACOBRANZADETBE oCBITACOBRANZADET, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@BITCOBRANZAID", FbDbType.BigInt);
                if (!(bool)oCBITACOBRANZADET.isnull["IBITCOBRANZAID"])
                {
                    auxPar.Value = oCBITACOBRANZADET.IBITCOBRANZAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                

                auxPar = new FbParameter("@COBRADORID", FbDbType.BigInt);
                if (!(bool)oCBITACOBRANZADET.isnull["ICOBRADORID"])
                {
                    auxPar.Value = oCBITACOBRANZADET.ICOBRADORID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCBITACOBRANZADET.isnull["IFECHA"])
                {
                    auxPar.Value = oCBITACOBRANZADET.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if (!(bool)oCBITACOBRANZADET.isnull["IDOCTOID"])
                {
                    auxPar.Value = oCBITACOBRANZADET.IDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (!(bool)oCBITACOBRANZADET.isnull["IPERSONAID"])
                {
                    auxPar.Value = oCBITACOBRANZADET.IPERSONAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SALDO", FbDbType.Numeric);
                if (!(bool)oCBITACOBRANZADET.isnull["ISALDO"])
                {
                    auxPar.Value = oCBITACOBRANZADET.ISALDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAVENCE", FbDbType.Date);
                if (!(bool)oCBITACOBRANZADET.isnull["IFECHAVENCE"])
                {
                    auxPar.Value = oCBITACOBRANZADET.IFECHAVENCE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DIAPAGOS", FbDbType.VarChar);
                if (!(bool)oCBITACOBRANZADET.isnull["IDIAPAGOS"])
                {
                    auxPar.Value = oCBITACOBRANZADET.IDIAPAGOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ABONO", FbDbType.Numeric);
                if (!(bool)oCBITACOBRANZADET.isnull["IABONO"])
                {
                    auxPar.Value = oCBITACOBRANZADET.IABONO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOPAGOID", FbDbType.BigInt);
                if (!(bool)oCBITACOBRANZADET.isnull["IDOCTOPAGOID"])
                {
                    auxPar.Value = oCBITACOBRANZADET.IDOCTOPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTADO", FbDbType.BigInt);
                if (!(bool)oCBITACOBRANZADET.isnull["IESTADO"])
                {
                    auxPar.Value = oCBITACOBRANZADET.IESTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@OBSERVACIONES", FbDbType.VarChar);
                if (!(bool)oCBITACOBRANZADET.isnull["IOBSERVACIONES"])
                {
                    auxPar.Value = oCBITACOBRANZADET.IOBSERVACIONES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUEVAFECHACOBRO", FbDbType.Date);
                if (!(bool)oCBITACOBRANZADET.isnull["INUEVAFECHACOBRO"])
                {
                    auxPar.Value = oCBITACOBRANZADET.INUEVAFECHACOBRO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@IDRETORNO", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"BITACOBRANZAAGREGARDETALLE";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);



                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        int errorvalue = (int)arParms[arParms.Length - 1].Value;
                        this.iComentario = "Hubo un error " + errorvalue.ToString();
                        return null;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    long retorno = (long)arParms[arParms.Length - 2].Value;
                    oCBITACOBRANZADET.IID = retorno;
                }




                return oCBITACOBRANZADET;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }



        public bool BITACOBRANZAELIMINARDETALLE(CBITACOBRANZADETBE oCBITACOBRANZADET, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@BITCOBRANZAID", FbDbType.BigInt);
                auxPar.Value = oCBITACOBRANZADET.IID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);



                string commandText = @"BITACOBRANZAELIMINARDETALLE";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);



                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        int errorvalue = (int)arParms[arParms.Length - 1].Value;
                        this.iComentario = "Hubo un error " + errorvalue.ToString();
                        return false;
                    }
                }

                return true;




            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public CBITACOBRANZADETD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
