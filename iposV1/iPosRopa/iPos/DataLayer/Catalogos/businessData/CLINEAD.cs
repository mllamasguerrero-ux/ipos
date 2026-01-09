
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

    [Transaction(TransactionOption.Supported)]


    public class CLINEAD
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
        public CLINEABE AgregarLINEAD(CLINEABE oCLINEA, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCLINEA.isnull["ICLAVE"])
                {
                    auxPar.Value = oCLINEA.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCLINEA.isnull["INOMBRE"])
                {
                    auxPar.Value = oCLINEA.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ACUMULAPROMOCION", FbDbType.VarChar);
                if (!(bool)oCLINEA.isnull["IACUMULAPROMOCION"])
                {
                    auxPar.Value = oCLINEA.IACUMULAPROMOCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ACTIVO", FbDbType.VarChar);
                if (!(bool)oCLINEA.isnull["IACTIVO"])
                {
                    auxPar.Value = oCLINEA.IACTIVO;
                }
                else
                {
                    auxPar.Value = "S";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPORECARGA", FbDbType.VarChar);
                if (!(bool)oCLINEA.isnull["ITIPORECARGA"])
                {
                    auxPar.Value = oCLINEA.ITIPORECARGA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@APLICAMAYOREOXLINEA", FbDbType.VarChar);
                if (!(bool)oCLINEA.isnull["IAPLICAMAYOREOXLINEA"])
                {
                    auxPar.Value = oCLINEA.IAPLICAMAYOREOXLINEA;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@GPOIMP", FbDbType.VarChar);
                if (!(bool)oCLINEA.isnull["IGPOIMP"])
                {
                    auxPar.Value = oCLINEA.IGPOIMP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                string commandText = @"
        INSERT INTO LINEA
      (



CLAVE,

NOMBRE,

ACUMULAPROMOCION,

ACTIVO,
TIPORECARGA,

APLICAMAYOREOXLINEA,

GPOIMP
         )

Values (



@CLAVE,

@NOMBRE,

@ACUMULAPROMOCION,

@ACTIVO,

@TIPORECARGA,

@APLICAMAYOREOXLINEA,

@GPOIMP
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCLINEA;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarLINEAD(CLINEABE oCLINEA, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCLINEA.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from LINEA
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
        public bool CambiarLINEAD(CLINEABE oCLINEANuevo, CLINEABE oCLINEAAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCLINEANuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCLINEANuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCLINEANuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCLINEANuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCLINEANuevo.isnull["ICLAVE"])
                {
                    auxPar.Value = oCLINEANuevo.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCLINEANuevo.isnull["INOMBRE"])
                {
                    auxPar.Value = oCLINEANuevo.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ACUMULAPROMOCION", FbDbType.VarChar);
                if (!(bool)oCLINEANuevo.isnull["IACUMULAPROMOCION"])
                {
                    auxPar.Value = oCLINEANuevo.IACUMULAPROMOCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@APLICAMAYOREOXLINEA", FbDbType.VarChar);
                if (!(bool)oCLINEANuevo.isnull["IAPLICAMAYOREOXLINEA"])
                {
                    auxPar.Value = oCLINEANuevo.IAPLICAMAYOREOXLINEA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                
                


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCLINEAAnterior.isnull["IID"])
                {
                    auxPar.Value = oCLINEAAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPORECARGA", FbDbType.VarChar);
                if (!(bool)oCLINEANuevo.isnull["ITIPORECARGA"])
                {
                    auxPar.Value = oCLINEANuevo.ITIPORECARGA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@GPOIMP", FbDbType.VarChar);
                if (!(bool)oCLINEANuevo.isnull["IGPOIMP"])
                {
                    auxPar.Value = oCLINEANuevo.IGPOIMP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);





                string commandText = @"
  update  LINEA
  set


ACTIVO=@ACTIVO,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

CLAVE=@CLAVE,

NOMBRE=@NOMBRE,

ACUMULAPROMOCION= @ACUMULAPROMOCION,

TIPORECARGA = @TIPORECARGA,

APLICAMAYOREOXLINEA = @APLICAMAYOREOXLINEA,

GPOIMP = @GPOIMP

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
        public CLINEABE seleccionarLINEA(CLINEABE oCLINEA, FbTransaction st)
        {




            CLINEABE retorno = new CLINEABE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from LINEA where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCLINEA.IID;
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


                    if (dr["ACUMULAPROMOCION"] != System.DBNull.Value)
                    {
                        retorno.IACUMULAPROMOCION = (string)(dr["ACUMULAPROMOCION"]);
                    }

                    if (dr["TIPORECARGA"] != System.DBNull.Value)
                    {
                        retorno.ITIPORECARGA = (string)(dr["TIPORECARGA"]);
                    }


                    if (dr["APLICAMAYOREOXLINEA"] != System.DBNull.Value)
                    {
                        retorno.IAPLICAMAYOREOXLINEA = (string)(dr["APLICAMAYOREOXLINEA"]);
                    }


                    if (dr["GPOIMP"] != System.DBNull.Value)
                    {
                        retorno.IGPOIMP = (string)(dr["GPOIMP"]);
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




        public CLINEABE seleccionarLINEAxCLAVE(CLINEABE oCLINEA, FbTransaction st)
        {

            CLINEABE retorno = new CLINEABE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from LINEA where CLAVE=@CLAVE  ";


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                auxPar.Value = oCLINEA.ICLAVE;
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

                    if (dr["ACUMULAPROMOCION"] != System.DBNull.Value)
                    {
                        retorno.IACUMULAPROMOCION = (string)(dr["ACUMULAPROMOCION"]);
                    }
                    if (dr["TIPORECARGA"] != System.DBNull.Value)
                    {
                        retorno.ITIPORECARGA = (string)(dr["TIPORECARGA"]);
                    }

                    if (dr["APLICAMAYOREOXLINEA"] != System.DBNull.Value)
                    {
                        retorno.IAPLICAMAYOREOXLINEA = (string)(dr["APLICAMAYOREOXLINEA"]);
                    }

                    if (dr["GPOIMP"] != System.DBNull.Value)
                    {
                        retorno.IGPOIMP = (string)(dr["GPOIMP"]);
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
        public DataSet enlistarLINEA()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_LINEA_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoLINEA()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_LINEA_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteLINEA(CLINEABE oCLINEA, FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCLINEA.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from LINEA where

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




        public CLINEABE AgregarLINEA(CLINEABE oCLINEA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteLINEA(oCLINEA, st);
                if (iRes == 1)
                {
                    this.IComentario = "El LINEA ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarLINEAD(oCLINEA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarLINEA(CLINEABE oCLINEA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteLINEA(oCLINEA, st);
                if (iRes == 0)
                {
                    this.IComentario = "El LINEA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarLINEAD(oCLINEA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarLINEA(CLINEABE oCLINEANuevo, CLINEABE oCLINEAAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteLINEA(oCLINEAAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El LINEA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarLINEAD(oCLINEANuevo, oCLINEAAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CLINEAD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
