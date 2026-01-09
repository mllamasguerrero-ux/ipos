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
    


    public class CCOMISIONPORLISTAD
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

        
        public CCOMISIONPORLISTABE AgregarCOMISIONPORLISTAD(CCOMISIONPORLISTABE oCCOMISIONPORLISTA, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCCOMISIONPORLISTA.isnull["IID"])
                {
                    auxPar.Value = oCCOMISIONPORLISTA.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCCOMISIONPORLISTA.isnull["IACTIVO"])
                {
                    auxPar.Value = oCCOMISIONPORLISTA.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCCOMISIONPORLISTA.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCCOMISIONPORLISTA.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCCOMISIONPORLISTA.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCCOMISIONPORLISTA.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO1", FbDbType.Numeric);
                if (!(bool)oCCOMISIONPORLISTA.isnull["IPRECIO1"])
                {
                    auxPar.Value = oCCOMISIONPORLISTA.IPRECIO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO2", FbDbType.Numeric);
                if (!(bool)oCCOMISIONPORLISTA.isnull["IPRECIO2"])
                {
                    auxPar.Value = oCCOMISIONPORLISTA.IPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO3", FbDbType.Numeric);
                if (!(bool)oCCOMISIONPORLISTA.isnull["IPRECIO3"])
                {
                    auxPar.Value = oCCOMISIONPORLISTA.IPRECIO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO4", FbDbType.Numeric);
                if (!(bool)oCCOMISIONPORLISTA.isnull["IPRECIO4"])
                {
                    auxPar.Value = oCCOMISIONPORLISTA.IPRECIO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO5", FbDbType.Numeric);
                if (!(bool)oCCOMISIONPORLISTA.isnull["IPRECIO5"])
                {
                    auxPar.Value = oCCOMISIONPORLISTA.IPRECIO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIOOTRO", FbDbType.Numeric);
                if (!(bool)oCCOMISIONPORLISTA.isnull["IPRECIOOTRO"])
                {
                    auxPar.Value = oCCOMISIONPORLISTA.IPRECIOOTRO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO COMISIONPORLISTA
      (

PRECIO1,

PRECIO2,

PRECIO3,

PRECIO4,

PRECIO5,

PRECIOOTRO
         )

Values (

@PRECIO1,

@PRECIO2,

@PRECIO3,

@PRECIO4,

@PRECIO5,

@PRECIOOTRO
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCCOMISIONPORLISTA;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }

        
        public bool BorrarCOMISIONPORLISTAD(CCOMISIONPORLISTABE oCCOMISIONPORLISTA, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCCOMISIONPORLISTA.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from COMISIONPORLISTA
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

        
        public bool CambiarCOMISIONPORLISTAD(CCOMISIONPORLISTABE oCCOMISIONPORLISTANuevo, CCOMISIONPORLISTABE oCCOMISIONPORLISTAAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                

                auxPar = new FbParameter("@PRECIO1", FbDbType.Numeric);
                if (!(bool)oCCOMISIONPORLISTANuevo.isnull["IPRECIO1"])
                {
                    auxPar.Value = oCCOMISIONPORLISTANuevo.IPRECIO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRECIO2", FbDbType.Numeric);
                if (!(bool)oCCOMISIONPORLISTANuevo.isnull["IPRECIO2"])
                {
                    auxPar.Value = oCCOMISIONPORLISTANuevo.IPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRECIO3", FbDbType.Numeric);
                if (!(bool)oCCOMISIONPORLISTANuevo.isnull["IPRECIO3"])
                {
                    auxPar.Value = oCCOMISIONPORLISTANuevo.IPRECIO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRECIO4", FbDbType.Numeric);
                if (!(bool)oCCOMISIONPORLISTANuevo.isnull["IPRECIO4"])
                {
                    auxPar.Value = oCCOMISIONPORLISTANuevo.IPRECIO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRECIO5", FbDbType.Numeric);
                if (!(bool)oCCOMISIONPORLISTANuevo.isnull["IPRECIO5"])
                {
                    auxPar.Value = oCCOMISIONPORLISTANuevo.IPRECIO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRECIOOTRO", FbDbType.Numeric);
                if (!(bool)oCCOMISIONPORLISTANuevo.isnull["IPRECIOOTRO"])
                {
                    auxPar.Value = oCCOMISIONPORLISTANuevo.IPRECIOOTRO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCCOMISIONPORLISTAAnterior.isnull["IID"])
                {
                    auxPar.Value = oCCOMISIONPORLISTAAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  COMISIONPORLISTA
  set


PRECIO1=@PRECIO1,

PRECIO2=@PRECIO2,

PRECIO3=@PRECIO3,

PRECIO4=@PRECIO4,

PRECIO5=@PRECIO5,

PRECIOOTRO=@PRECIOOTRO
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




        public bool SetCOMISIONPORLISTAD(CCOMISIONPORLISTABE oCCOMISIONPORLISTANuevo,  FbTransaction st)
        {
            CCOMISIONPORLISTABE oCCOMISIONPORLISTAAnterior = seleccionarCOMISIONPORLISTA(st);
            if(oCCOMISIONPORLISTAAnterior != null)
            {
                oCCOMISIONPORLISTANuevo.IID = oCCOMISIONPORLISTAAnterior.IID;
                return CambiarCOMISIONPORLISTAD(oCCOMISIONPORLISTANuevo, oCCOMISIONPORLISTAAnterior, st);
            }

            return (this.AgregarCOMISIONPORLISTAD(oCCOMISIONPORLISTANuevo, st) != null);
        }


            public CCOMISIONPORLISTABE seleccionarCOMISIONPORLISTA( FbTransaction st)
        {




            CCOMISIONPORLISTABE retorno = new CCOMISIONPORLISTABE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from COMISIONPORLISTA";

                



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

                    if (dr["PRECIO1"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO1 = (decimal)(dr["PRECIO1"]);
                    }

                    if (dr["PRECIO2"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO2 = (decimal)(dr["PRECIO2"]);
                    }

                    if (dr["PRECIO3"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO3 = (decimal)(dr["PRECIO3"]);
                    }

                    if (dr["PRECIO4"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO4 = (decimal)(dr["PRECIO4"]);
                    }

                    if (dr["PRECIO5"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO5 = (decimal)(dr["PRECIO5"]);
                    }

                    if (dr["PRECIOOTRO"] != System.DBNull.Value)
                    {
                        retorno.IPRECIOOTRO = (decimal)(dr["PRECIOOTRO"]);
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








        
        public DataSet enlistarCOMISIONPORLISTA()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_COMISIONPORLISTA_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        
        public DataSet enlistarCortoCOMISIONPORLISTA()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_COMISIONPORLISTA_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }


        
        public int ExisteCOMISIONPORLISTA(CCOMISIONPORLISTABE oCCOMISIONPORLISTA, FbTransaction st)
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
                auxPar.Value = oCCOMISIONPORLISTA.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from COMISIONPORLISTA where

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




        public CCOMISIONPORLISTABE AgregarCOMISIONPORLISTA(CCOMISIONPORLISTABE oCCOMISIONPORLISTA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCOMISIONPORLISTA(oCCOMISIONPORLISTA, st);
                if (iRes == 1)
                {
                    this.IComentario = "El COMISIONPORLISTA ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarCOMISIONPORLISTAD(oCCOMISIONPORLISTA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarCOMISIONPORLISTA(CCOMISIONPORLISTABE oCCOMISIONPORLISTA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCOMISIONPORLISTA(oCCOMISIONPORLISTA, st);
                if (iRes == 0)
                {
                    this.IComentario = "El COMISIONPORLISTA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarCOMISIONPORLISTAD(oCCOMISIONPORLISTA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarCOMISIONPORLISTA(CCOMISIONPORLISTABE oCCOMISIONPORLISTANuevo, CCOMISIONPORLISTABE oCCOMISIONPORLISTAAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCOMISIONPORLISTA(oCCOMISIONPORLISTAAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El COMISIONPORLISTA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarCOMISIONPORLISTAD(oCCOMISIONPORLISTANuevo, oCCOMISIONPORLISTAAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CCOMISIONPORLISTAD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
