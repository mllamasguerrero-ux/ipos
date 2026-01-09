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


    public class CCUENTASPVCD
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

        public CCUENTASPVCBE AgregarCUENTASPVCD(CCUENTASPVCBE oCCUENTASPVC, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCCUENTASPVC.isnull["IID"])
                {
                    auxPar.Value = oCCUENTASPVC.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CUENTASUMAVENTAS", FbDbType.VarChar);
                if (!(bool)oCCUENTASPVC.isnull["ICUENTASUMAVENTAS"])
                {
                    auxPar.Value = oCCUENTASPVC.ICUENTASUMAVENTAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CUENTASUMNOTASCREDITO", FbDbType.VarChar);
                if (!(bool)oCCUENTASPVC.isnull["ICUENTASUMNOTASCREDITO"])
                {
                    auxPar.Value = oCCUENTASPVC.ICUENTASUMNOTASCREDITO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CUENTAIMPUESTOS", FbDbType.VarChar);
                if (!(bool)oCCUENTASPVC.isnull["ICUENTAIMPUESTOS"])
                {
                    auxPar.Value = oCCUENTASPVC.ICUENTAIMPUESTOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO CUENTASPVC
      (
    
ID,

CUENTASUMAVENTAS,

CUENTASUMNOTASCREDITO,

CUENTAIMPUESTOS
         )

Values (

@ID,

@CUENTASUMAVENTAS,

@CUENTASUMNOTASCREDITO,

@CUENTAIMPUESTOS
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCCUENTASPVC;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarCUENTASPVCD(CCUENTASPVCBE oCCUENTASPVC, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCCUENTASPVC.IID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CUENTASUMAVENTAS", FbDbType.VarChar);
                auxPar.Value = oCCUENTASPVC.ICUENTASUMAVENTAS;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CUENTASUMNOTASCREDITO", FbDbType.VarChar);
                auxPar.Value = oCCUENTASPVC.ICUENTASUMNOTASCREDITO;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CUENTAIMPUESTOS", FbDbType.VarChar);
                auxPar.Value = oCCUENTASPVC.ICUENTAIMPUESTOS;
                parts.Add(auxPar);



                string commandText = @"  Delete from CUENTASPVC
  where

  ID=@ID and 

  CUENTASUMAVENTAS=@CUENTASUMAVENTAS and 

  CUENTASUMNOTASCREDITO=@CUENTASUMNOTASCREDITO and 

  CUENTAIMPUESTOS=@CUENTAIMPUESTOS
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

        public bool CambiarCUENTASPVCD(CCUENTASPVCBE oCCUENTASPVCNuevo, CCUENTASPVCBE oCCUENTASPVCAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@CUENTASUMAVENTAS", FbDbType.VarChar);
                if (!(bool)oCCUENTASPVCNuevo.isnull["ICUENTASUMAVENTAS"])
                {
                    auxPar.Value = oCCUENTASPVCNuevo.ICUENTASUMAVENTAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CUENTASUMNOTASCREDITO", FbDbType.VarChar);
                if (!(bool)oCCUENTASPVCNuevo.isnull["ICUENTASUMNOTASCREDITO"])
                {
                    auxPar.Value = oCCUENTASPVCNuevo.ICUENTASUMNOTASCREDITO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CUENTAIMPUESTOS", FbDbType.VarChar);
                if (!(bool)oCCUENTASPVCNuevo.isnull["ICUENTAIMPUESTOS"])
                {
                    auxPar.Value = oCCUENTASPVCNuevo.ICUENTAIMPUESTOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCCUENTASPVCAnterior.isnull["IID"])
                {
                    auxPar.Value = oCCUENTASPVCAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                string commandText = @"
  update  CUENTASPVC
  set

CUENTASUMAVENTAS=@CUENTASUMAVENTAS,

CUENTASUMNOTASCREDITO=@CUENTASUMNOTASCREDITO,

CUENTAIMPUESTOS=@CUENTAIMPUESTOS
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
        public CCUENTASPVCBE seleccionarCUENTASPVC(CCUENTASPVCBE oCCUENTASPVC, FbTransaction st)
        {




            CCUENTASPVCBE retorno = new CCUENTASPVCBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from CUENTASPVC where
 ID=@ID";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCCUENTASPVC.IID;
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

                    if (dr["CUENTASUMAVENTAS"] != System.DBNull.Value)
                    {
                        retorno.ICUENTASUMAVENTAS = (string)(dr["CUENTASUMAVENTAS"]);
                    }

                    if (dr["CUENTASUMNOTASCREDITO"] != System.DBNull.Value)
                    {
                        retorno.ICUENTASUMNOTASCREDITO = (string)(dr["CUENTASUMNOTASCREDITO"]);
                    }

                    if (dr["CUENTAIMPUESTOS"] != System.DBNull.Value)
                    {
                        retorno.ICUENTAIMPUESTOS = (string)(dr["CUENTAIMPUESTOS"]);
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
        public DataSet enlistarCUENTASPVC()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_CUENTASPVC_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoCUENTASPVC()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_CUENTASPVC_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }


        public int ExisteCUENTASPVC(CCUENTASPVCBE oCCUENTASPVC, FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from CUENTASPVC 
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




        public CCUENTASPVCBE AgregarCUENTASPVC(CCUENTASPVCBE oCCUENTASPVC, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCUENTASPVC(oCCUENTASPVC, st);
                if (iRes == 1)
                {
                    this.IComentario = "El CUENTASPVC ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarCUENTASPVCD(oCCUENTASPVC, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarCUENTASPVC(CCUENTASPVCBE oCCUENTASPVC, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCUENTASPVC(oCCUENTASPVC, st);
                if (iRes == 0)
                {
                    this.IComentario = "El CUENTASPVC no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarCUENTASPVCD(oCCUENTASPVC, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarCUENTASPVC(CCUENTASPVCBE oCCUENTASPVCNuevo, CCUENTASPVCBE oCCUENTASPVCAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCUENTASPVC(oCCUENTASPVCAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El CUENTASPVC no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarCUENTASPVCD(oCCUENTASPVCNuevo, oCCUENTASPVCAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CCUENTASPVCD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
