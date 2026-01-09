
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


    public class CZEBRACONFIGD
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
        public CZEBRACONFIGBE AgregarZEBRACONFIGD(CZEBRACONFIGBE oCZEBRACONFIG, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCZEBRACONFIG.isnull["IID"])
                {
                    auxPar.Value = oCZEBRACONFIG.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCZEBRACONFIG.isnull["IACTIVO"])
                {
                    auxPar.Value = oCZEBRACONFIG.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCZEBRACONFIG.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCZEBRACONFIG.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCZEBRACONFIG.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCZEBRACONFIG.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@A1_X_POSITION", FbDbType.VarChar);
                if (!(bool)oCZEBRACONFIG.isnull["IA1_X_POSITION"])
                {
                    auxPar.Value = oCZEBRACONFIG.IA1_X_POSITION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@A2_Y_POSITION", FbDbType.VarChar);
                if (!(bool)oCZEBRACONFIG.isnull["IA2_Y_POSITION"])
                {
                    auxPar.Value = oCZEBRACONFIG.IA2_Y_POSITION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@A3_ROTATION", FbDbType.VarChar);
                if (!(bool)oCZEBRACONFIG.isnull["IA3_ROTATION"])
                {
                    auxPar.Value = oCZEBRACONFIG.IA3_ROTATION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@A4_FONT_SELECTION", FbDbType.VarChar);
                if (!(bool)oCZEBRACONFIG.isnull["IA4_FONT_SELECTION"])
                {
                    auxPar.Value = oCZEBRACONFIG.IA4_FONT_SELECTION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@A5_X_MULTIPLIER", FbDbType.VarChar);
                if (!(bool)oCZEBRACONFIG.isnull["IA5_X_MULTIPLIER"])
                {
                    auxPar.Value = oCZEBRACONFIG.IA5_X_MULTIPLIER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@A6_Y_MULTIPLIER", FbDbType.VarChar);
                if (!(bool)oCZEBRACONFIG.isnull["IA6_Y_MULTIPLIER"])
                {
                    auxPar.Value = oCZEBRACONFIG.IA6_Y_MULTIPLIER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@A7_REVERSEIMAGE", FbDbType.VarChar);
                if (!(bool)oCZEBRACONFIG.isnull["IA7_REVERSEIMAGE"])
                {
                    auxPar.Value = oCZEBRACONFIG.IA7_REVERSEIMAGE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@B1_X_POSITION", FbDbType.VarChar);
                if (!(bool)oCZEBRACONFIG.isnull["IB1_X_POSITION"])
                {
                    auxPar.Value = oCZEBRACONFIG.IB1_X_POSITION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@B2_Y_POSITION", FbDbType.VarChar);
                if (!(bool)oCZEBRACONFIG.isnull["IB2_Y_POSITION"])
                {
                    auxPar.Value = oCZEBRACONFIG.IB2_Y_POSITION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@B3_ROTATION", FbDbType.VarChar);
                if (!(bool)oCZEBRACONFIG.isnull["IB3_ROTATION"])
                {
                    auxPar.Value = oCZEBRACONFIG.IB3_ROTATION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@B4_BARCODE_SELECTION", FbDbType.VarChar);
                if (!(bool)oCZEBRACONFIG.isnull["IB4_BARCODE_SELECTION"])
                {
                    auxPar.Value = oCZEBRACONFIG.IB4_BARCODE_SELECTION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@B5_NARROWBARWIDTH", FbDbType.VarChar);
                if (!(bool)oCZEBRACONFIG.isnull["IB5_NARROWBARWIDTH"])
                {
                    auxPar.Value = oCZEBRACONFIG.IB5_NARROWBARWIDTH;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@B6_WIDEBARWIDTH", FbDbType.VarChar);
                if (!(bool)oCZEBRACONFIG.isnull["IB6_WIDEBARWIDTH"])
                {
                    auxPar.Value = oCZEBRACONFIG.IB6_WIDEBARWIDTH;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@B7_BARCODEHEIGHT", FbDbType.VarChar);
                if (!(bool)oCZEBRACONFIG.isnull["IB7_BARCODEHEIGHT"])
                {
                    auxPar.Value = oCZEBRACONFIG.IB7_BARCODEHEIGHT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@B8_PRINTHUMANREADABLE", FbDbType.VarChar);
                if (!(bool)oCZEBRACONFIG.isnull["IB8_PRINTHUMANREADABLE"])
                {
                    auxPar.Value = oCZEBRACONFIG.IB8_PRINTHUMANREADABLE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@Q_LABELWIDTH", FbDbType.VarChar);
                if (!(bool)oCZEBRACONFIG.isnull["IQ_LABELWIDTH"])
                {
                    auxPar.Value = oCZEBRACONFIG.IQ_LABELWIDTH;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@Q_FORMLENGTH_1", FbDbType.VarChar);
                if (!(bool)oCZEBRACONFIG.isnull["IQ_FORMLENGTH_1"])
                {
                    auxPar.Value = oCZEBRACONFIG.IQ_FORMLENGTH_1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@Q_FORMLENGTH_2", FbDbType.VarChar);
                if (!(bool)oCZEBRACONFIG.isnull["IQ_FORMLENGTH_2"])
                {
                    auxPar.Value = oCZEBRACONFIG.IQ_FORMLENGTH_2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO ZEBRACONFIG
      (
    
ID,

ACTIVO,

CREADO,

CREADOPOR_USERID,

MODIFICADO,

MODIFICADOPOR_USERID,

A1_X_POSITION,

A2_Y_POSITION,

A3_ROTATION,

A4_FONT_SELECTION,

A5_X_MULTIPLIER,

A6_Y_MULTIPLIER,

A7_REVERSEIMAGE,

B1_X_POSITION,

B2_Y_POSITION,

B3_ROTATION,

B4_BARCODE_SELECTION,

B5_NARROWBARWIDTH,

B6_WIDEBARWIDTH,

B7_BARCODEHEIGHT,

B8_PRINTHUMANREADABLE,

Q_LABELWIDTH,

Q_FORMLENGTH_1,

Q_FORMLENGTH_2
         )

Values (

@ID,

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@A1_X_POSITION,

@A2_Y_POSITION,

@A3_ROTATION,

@A4_FONT_SELECTION,

@A5_X_MULTIPLIER,

@A6_Y_MULTIPLIER,

@A7_REVERSEIMAGE,

@B1_X_POSITION,

@B2_Y_POSITION,

@B3_ROTATION,

@B4_BARCODE_SELECTION,

@B5_NARROWBARWIDTH,

@B6_WIDEBARWIDTH,

@B7_BARCODEHEIGHT,

@B8_PRINTHUMANREADABLE,

@Q_LABELWIDTH,

@Q_FORMLENGTH_1,

@Q_FORMLENGTH_2
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCZEBRACONFIG;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarZEBRACONFIGD(CZEBRACONFIGBE oCZEBRACONFIG, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCZEBRACONFIG.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from ZEBRACONFIG
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
        public bool CambiarZEBRACONFIGD(CZEBRACONFIGBE oCZEBRACONFIGNuevo, CZEBRACONFIGBE oCZEBRACONFIGAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@A1_X_POSITION", FbDbType.VarChar);
                if (!(bool)oCZEBRACONFIGNuevo.isnull["IA1_X_POSITION"])
                {
                    auxPar.Value = oCZEBRACONFIGNuevo.IA1_X_POSITION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@A2_Y_POSITION", FbDbType.VarChar);
                if (!(bool)oCZEBRACONFIGNuevo.isnull["IA2_Y_POSITION"])
                {
                    auxPar.Value = oCZEBRACONFIGNuevo.IA2_Y_POSITION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@A3_ROTATION", FbDbType.VarChar);
                if (!(bool)oCZEBRACONFIGNuevo.isnull["IA3_ROTATION"])
                {
                    auxPar.Value = oCZEBRACONFIGNuevo.IA3_ROTATION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@A4_FONT_SELECTION", FbDbType.VarChar);
                if (!(bool)oCZEBRACONFIGNuevo.isnull["IA4_FONT_SELECTION"])
                {
                    auxPar.Value = oCZEBRACONFIGNuevo.IA4_FONT_SELECTION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@A5_X_MULTIPLIER", FbDbType.VarChar);
                if (!(bool)oCZEBRACONFIGNuevo.isnull["IA5_X_MULTIPLIER"])
                {
                    auxPar.Value = oCZEBRACONFIGNuevo.IA5_X_MULTIPLIER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@A6_Y_MULTIPLIER", FbDbType.VarChar);
                if (!(bool)oCZEBRACONFIGNuevo.isnull["IA6_Y_MULTIPLIER"])
                {
                    auxPar.Value = oCZEBRACONFIGNuevo.IA6_Y_MULTIPLIER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@A7_REVERSEIMAGE", FbDbType.VarChar);
                if (!(bool)oCZEBRACONFIGNuevo.isnull["IA7_REVERSEIMAGE"])
                {
                    auxPar.Value = oCZEBRACONFIGNuevo.IA7_REVERSEIMAGE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@B1_X_POSITION", FbDbType.VarChar);
                if (!(bool)oCZEBRACONFIGNuevo.isnull["IB1_X_POSITION"])
                {
                    auxPar.Value = oCZEBRACONFIGNuevo.IB1_X_POSITION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@B2_Y_POSITION", FbDbType.VarChar);
                if (!(bool)oCZEBRACONFIGNuevo.isnull["IB2_Y_POSITION"])
                {
                    auxPar.Value = oCZEBRACONFIGNuevo.IB2_Y_POSITION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@B3_ROTATION", FbDbType.VarChar);
                if (!(bool)oCZEBRACONFIGNuevo.isnull["IB3_ROTATION"])
                {
                    auxPar.Value = oCZEBRACONFIGNuevo.IB3_ROTATION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@B4_BARCODE_SELECTION", FbDbType.VarChar);
                if (!(bool)oCZEBRACONFIGNuevo.isnull["IB4_BARCODE_SELECTION"])
                {
                    auxPar.Value = oCZEBRACONFIGNuevo.IB4_BARCODE_SELECTION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@B5_NARROWBARWIDTH", FbDbType.VarChar);
                if (!(bool)oCZEBRACONFIGNuevo.isnull["IB5_NARROWBARWIDTH"])
                {
                    auxPar.Value = oCZEBRACONFIGNuevo.IB5_NARROWBARWIDTH;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@B6_WIDEBARWIDTH", FbDbType.VarChar);
                if (!(bool)oCZEBRACONFIGNuevo.isnull["IB6_WIDEBARWIDTH"])
                {
                    auxPar.Value = oCZEBRACONFIGNuevo.IB6_WIDEBARWIDTH;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@B7_BARCODEHEIGHT", FbDbType.VarChar);
                if (!(bool)oCZEBRACONFIGNuevo.isnull["IB7_BARCODEHEIGHT"])
                {
                    auxPar.Value = oCZEBRACONFIGNuevo.IB7_BARCODEHEIGHT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@B8_PRINTHUMANREADABLE", FbDbType.VarChar);
                if (!(bool)oCZEBRACONFIGNuevo.isnull["IB8_PRINTHUMANREADABLE"])
                {
                    auxPar.Value = oCZEBRACONFIGNuevo.IB8_PRINTHUMANREADABLE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@Q_LABELWIDTH", FbDbType.VarChar);
                if (!(bool)oCZEBRACONFIGNuevo.isnull["IQ_LABELWIDTH"])
                {
                    auxPar.Value = oCZEBRACONFIGNuevo.IQ_LABELWIDTH;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@Q_FORMLENGTH_1", FbDbType.VarChar);
                if (!(bool)oCZEBRACONFIGNuevo.isnull["IQ_FORMLENGTH_1"])
                {
                    auxPar.Value = oCZEBRACONFIGNuevo.IQ_FORMLENGTH_1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@Q_FORMLENGTH_2", FbDbType.VarChar);
                if (!(bool)oCZEBRACONFIGNuevo.isnull["IQ_FORMLENGTH_2"])
                {
                    auxPar.Value = oCZEBRACONFIGNuevo.IQ_FORMLENGTH_2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                //auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                //if (!(bool)oCZEBRACONFIGAnterior.isnull["IID"])
                //{
                //    auxPar.Value = oCZEBRACONFIGAnterior.IID;
                //}
                //else
                //{
                //    auxPar.Value = System.DBNull.Value;
                //}
                //parts.Add(auxPar);




                string commandText = @"
  update  ZEBRACONFIG
  set

A1_X_POSITION=@A1_X_POSITION,

A2_Y_POSITION=@A2_Y_POSITION,

A3_ROTATION=@A3_ROTATION,

A4_FONT_SELECTION=@A4_FONT_SELECTION,

A5_X_MULTIPLIER=@A5_X_MULTIPLIER,

A6_Y_MULTIPLIER=@A6_Y_MULTIPLIER,

A7_REVERSEIMAGE=@A7_REVERSEIMAGE,

B1_X_POSITION=@B1_X_POSITION,

B2_Y_POSITION=@B2_Y_POSITION,

B3_ROTATION=@B3_ROTATION,

B4_BARCODE_SELECTION=@B4_BARCODE_SELECTION,

B5_NARROWBARWIDTH=@B5_NARROWBARWIDTH,

B6_WIDEBARWIDTH=@B6_WIDEBARWIDTH,

B7_BARCODEHEIGHT=@B7_BARCODEHEIGHT,

B8_PRINTHUMANREADABLE=@B8_PRINTHUMANREADABLE,

Q_LABELWIDTH=@Q_LABELWIDTH,

Q_FORMLENGTH_1=@Q_FORMLENGTH_1,

Q_FORMLENGTH_2=@Q_FORMLENGTH_2

  ;";


                /*  where ID=@IDAnt*/

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
        public CZEBRACONFIGBE seleccionarZEBRACONFIG( FbTransaction st)
        {




            CZEBRACONFIGBE retorno = new CZEBRACONFIGBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                //FbParameter auxPar;

                String CmdTxt = @"select * from ZEBRACONFIG";






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

                    if (dr["A1_X_POSITION"] != System.DBNull.Value)
                    {
                        retorno.IA1_X_POSITION = (string)(dr["A1_X_POSITION"]);
                    }

                    if (dr["A2_Y_POSITION"] != System.DBNull.Value)
                    {
                        retorno.IA2_Y_POSITION = (string)(dr["A2_Y_POSITION"]);
                    }

                    if (dr["A3_ROTATION"] != System.DBNull.Value)
                    {
                        retorno.IA3_ROTATION = (string)(dr["A3_ROTATION"]);
                    }

                    if (dr["A4_FONT_SELECTION"] != System.DBNull.Value)
                    {
                        retorno.IA4_FONT_SELECTION = (string)(dr["A4_FONT_SELECTION"]);
                    }

                    if (dr["A5_X_MULTIPLIER"] != System.DBNull.Value)
                    {
                        retorno.IA5_X_MULTIPLIER = (string)(dr["A5_X_MULTIPLIER"]);
                    }

                    if (dr["A6_Y_MULTIPLIER"] != System.DBNull.Value)
                    {
                        retorno.IA6_Y_MULTIPLIER = (string)(dr["A6_Y_MULTIPLIER"]);
                    }

                    if (dr["A7_REVERSEIMAGE"] != System.DBNull.Value)
                    {
                        retorno.IA7_REVERSEIMAGE = (string)(dr["A7_REVERSEIMAGE"]);
                    }

                    if (dr["B1_X_POSITION"] != System.DBNull.Value)
                    {
                        retorno.IB1_X_POSITION = (string)(dr["B1_X_POSITION"]);
                    }

                    if (dr["B2_Y_POSITION"] != System.DBNull.Value)
                    {
                        retorno.IB2_Y_POSITION = (string)(dr["B2_Y_POSITION"]);
                    }

                    if (dr["B3_ROTATION"] != System.DBNull.Value)
                    {
                        retorno.IB3_ROTATION = (string)(dr["B3_ROTATION"]);
                    }

                    if (dr["B4_BARCODE_SELECTION"] != System.DBNull.Value)
                    {
                        retorno.IB4_BARCODE_SELECTION = (string)(dr["B4_BARCODE_SELECTION"]);
                    }

                    if (dr["B5_NARROWBARWIDTH"] != System.DBNull.Value)
                    {
                        retorno.IB5_NARROWBARWIDTH = (string)(dr["B5_NARROWBARWIDTH"]);
                    }

                    if (dr["B6_WIDEBARWIDTH"] != System.DBNull.Value)
                    {
                        retorno.IB6_WIDEBARWIDTH = (string)(dr["B6_WIDEBARWIDTH"]);
                    }

                    if (dr["B7_BARCODEHEIGHT"] != System.DBNull.Value)
                    {
                        retorno.IB7_BARCODEHEIGHT = (string)(dr["B7_BARCODEHEIGHT"]);
                    }

                    if (dr["B8_PRINTHUMANREADABLE"] != System.DBNull.Value)
                    {
                        retorno.IB8_PRINTHUMANREADABLE = (string)(dr["B8_PRINTHUMANREADABLE"]);
                    }

                    if (dr["Q_LABELWIDTH"] != System.DBNull.Value)
                    {
                        retorno.IQ_LABELWIDTH = (string)(dr["Q_LABELWIDTH"]);
                    }

                    if (dr["Q_FORMLENGTH_1"] != System.DBNull.Value)
                    {
                        retorno.IQ_FORMLENGTH_1 = (string)(dr["Q_FORMLENGTH_1"]);
                    }

                    if (dr["Q_FORMLENGTH_2"] != System.DBNull.Value)
                    {
                        retorno.IQ_FORMLENGTH_2 = (string)(dr["Q_FORMLENGTH_2"]);
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
        public DataSet enlistarZEBRACONFIG()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_ZEBRACONFIG_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoZEBRACONFIG()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_ZEBRACONFIG_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteZEBRACONFIG(CZEBRACONFIGBE oCZEBRACONFIG, FbTransaction st)
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
                auxPar.Value = oCZEBRACONFIG.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from ZEBRACONFIG where

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




        public CZEBRACONFIGBE AgregarZEBRACONFIG(CZEBRACONFIGBE oCZEBRACONFIG, FbTransaction st)
        {
            try
            {
                int iRes = ExisteZEBRACONFIG(oCZEBRACONFIG, st);
                if (iRes == 1)
                {
                    this.IComentario = "El ZEBRACONFIG ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarZEBRACONFIGD(oCZEBRACONFIG, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarZEBRACONFIG(CZEBRACONFIGBE oCZEBRACONFIG, FbTransaction st)
        {
            try
            {
                int iRes = ExisteZEBRACONFIG(oCZEBRACONFIG, st);
                if (iRes == 0)
                {
                    this.IComentario = "El ZEBRACONFIG no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarZEBRACONFIGD(oCZEBRACONFIG, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarZEBRACONFIG(CZEBRACONFIGBE oCZEBRACONFIGNuevo, CZEBRACONFIGBE oCZEBRACONFIGAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteZEBRACONFIG(oCZEBRACONFIGAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El ZEBRACONFIG no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarZEBRACONFIGD(oCZEBRACONFIGNuevo, oCZEBRACONFIGAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CZEBRACONFIGD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
