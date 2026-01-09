
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


    public class CLOOKUPD
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
        public CLOOKUPBE AgregarLOOKUPD(CLOOKUPBE oCLOOKUP, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCLOOKUP.isnull["IID"])
                {
                    auxPar.Value = oCLOOKUP.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["IACTIVO"])
                {
                    auxPar.Value = oCLOOKUP.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCLOOKUP.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCLOOKUP.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCLOOKUP.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCLOOKUP.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ICLAVE"])
                {
                    auxPar.Value = oCLOOKUP.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["INOMBRE"])
                {
                    auxPar.Value = oCLOOKUP.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO1", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["ICAMPO1"])
                {
                    auxPar.Value = oCLOOKUP.ICAMPO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO2", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["ICAMPO2"])
                {
                    auxPar.Value = oCLOOKUP.ICAMPO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO3", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["ICAMPO3"])
                {
                    auxPar.Value = oCLOOKUP.ICAMPO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO4", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["ICAMPO4"])
                {
                    auxPar.Value = oCLOOKUP.ICAMPO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO5", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["ICAMPO5"])
                {
                    auxPar.Value = oCLOOKUP.ICAMPO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO6", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["ICAMPO6"])
                {
                    auxPar.Value = oCLOOKUP.ICAMPO6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO7", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["ICAMPO7"])
                {
                    auxPar.Value = oCLOOKUP.ICAMPO7;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO8", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["ICAMPO8"])
                {
                    auxPar.Value = oCLOOKUP.ICAMPO8;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO9", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["ICAMPO9"])
                {
                    auxPar.Value = oCLOOKUP.ICAMPO9;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO10", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["ICAMPO10"])
                {
                    auxPar.Value = oCLOOKUP.ICAMPO10;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO11", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["ICAMPO11"])
                {
                    auxPar.Value = oCLOOKUP.ICAMPO11;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO12", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["ICAMPO12"])
                {
                    auxPar.Value = oCLOOKUP.ICAMPO12;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO13", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["ICAMPO13"])
                {
                    auxPar.Value = oCLOOKUP.ICAMPO13;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO14", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["ICAMPO14"])
                {
                    auxPar.Value = oCLOOKUP.ICAMPO14;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO15", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["ICAMPO15"])
                {
                    auxPar.Value = oCLOOKUP.ICAMPO15;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO16", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["ICAMPO16"])
                {
                    auxPar.Value = oCLOOKUP.ICAMPO16;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO17", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["ICAMPO17"])
                {
                    auxPar.Value = oCLOOKUP.ICAMPO17;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO18", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["ICAMPO18"])
                {
                    auxPar.Value = oCLOOKUP.ICAMPO18;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO19", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["ICAMPO19"])
                {
                    auxPar.Value = oCLOOKUP.ICAMPO19;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO20", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["ICAMPO20"])
                {
                    auxPar.Value = oCLOOKUP.ICAMPO20;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO21", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["ICAMPO21"])
                {
                    auxPar.Value = oCLOOKUP.ICAMPO21;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO22", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["ICAMPO22"])
                {
                    auxPar.Value = oCLOOKUP.ICAMPO22;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO23", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["ICAMPO23"])
                {
                    auxPar.Value = oCLOOKUP.ICAMPO23;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CAMPO24", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["ICAMPO24"])
                {
                    auxPar.Value = oCLOOKUP.ICAMPO24;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO25", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["ICAMPO25"])
                {
                    auxPar.Value = oCLOOKUP.ICAMPO25;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO26", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["ICAMPO26"])
                {
                    auxPar.Value = oCLOOKUP.ICAMPO26;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO27", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["ICAMPO27"])
                {
                    auxPar.Value = oCLOOKUP.ICAMPO27;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO28", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["ICAMPO28"])
                {
                    auxPar.Value = oCLOOKUP.ICAMPO28;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO29", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["ICAMPO29"])
                {
                    auxPar.Value = oCLOOKUP.ICAMPO29;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO30", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["ICAMPO30"])
                {
                    auxPar.Value = oCLOOKUP.ICAMPO30;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO31", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["ICAMPO31"])
                {
                    auxPar.Value = oCLOOKUP.ICAMPO31;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO32", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["ICAMPO32"])
                {
                    auxPar.Value = oCLOOKUP.ICAMPO32;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO33", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["ICAMPO33"])
                {
                    auxPar.Value = oCLOOKUP.ICAMPO33;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO34", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["ICAMPO34"])
                {
                    auxPar.Value = oCLOOKUP.ICAMPO34;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO35", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["ICAMPO35"])
                {
                    auxPar.Value = oCLOOKUP.ICAMPO35;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO36", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["ICAMPO36"])
                {
                    auxPar.Value = oCLOOKUP.ICAMPO36;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO37", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["ICAMPO37"])
                {
                    auxPar.Value = oCLOOKUP.ICAMPO37;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO38", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["ICAMPO38"])
                {
                    auxPar.Value = oCLOOKUP.ICAMPO38;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO39", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["ICAMPO39"])
                {
                    auxPar.Value = oCLOOKUP.ICAMPO39;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO40", FbDbType.Char);
                if (!(bool)oCLOOKUP.isnull["ICAMPO40"])
                {
                    auxPar.Value = oCLOOKUP.ICAMPO40;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@LBL_CAMPO1", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ILBL_CAMPO1"])
                {
                    auxPar.Value = oCLOOKUP.ILBL_CAMPO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO2", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ILBL_CAMPO2"])
                {
                    auxPar.Value = oCLOOKUP.ILBL_CAMPO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO3", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ILBL_CAMPO3"])
                {
                    auxPar.Value = oCLOOKUP.ILBL_CAMPO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO4", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ILBL_CAMPO4"])
                {
                    auxPar.Value = oCLOOKUP.ILBL_CAMPO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO5", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ILBL_CAMPO5"])
                {
                    auxPar.Value = oCLOOKUP.ILBL_CAMPO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO6", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ILBL_CAMPO6"])
                {
                    auxPar.Value = oCLOOKUP.ILBL_CAMPO6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO7", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ILBL_CAMPO7"])
                {
                    auxPar.Value = oCLOOKUP.ILBL_CAMPO7;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO8", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ILBL_CAMPO8"])
                {
                    auxPar.Value = oCLOOKUP.ILBL_CAMPO8;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO9", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ILBL_CAMPO9"])
                {
                    auxPar.Value = oCLOOKUP.ILBL_CAMPO9;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO10", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ILBL_CAMPO10"])
                {
                    auxPar.Value = oCLOOKUP.ILBL_CAMPO10;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO11", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ILBL_CAMPO11"])
                {
                    auxPar.Value = oCLOOKUP.ILBL_CAMPO11;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO12", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ILBL_CAMPO12"])
                {
                    auxPar.Value = oCLOOKUP.ILBL_CAMPO12;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO13", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ILBL_CAMPO13"])
                {
                    auxPar.Value = oCLOOKUP.ILBL_CAMPO13;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO14", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ILBL_CAMPO14"])
                {
                    auxPar.Value = oCLOOKUP.ILBL_CAMPO14;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO15", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ILBL_CAMPO15"])
                {
                    auxPar.Value = oCLOOKUP.ILBL_CAMPO15;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO16", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ILBL_CAMPO16"])
                {
                    auxPar.Value = oCLOOKUP.ILBL_CAMPO16;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO17", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ILBL_CAMPO17"])
                {
                    auxPar.Value = oCLOOKUP.ILBL_CAMPO17;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO18", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ILBL_CAMPO18"])
                {
                    auxPar.Value = oCLOOKUP.ILBL_CAMPO18;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO19", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ILBL_CAMPO19"])
                {
                    auxPar.Value = oCLOOKUP.ILBL_CAMPO19;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO20", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ILBL_CAMPO20"])
                {
                    auxPar.Value = oCLOOKUP.ILBL_CAMPO20;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO21", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ILBL_CAMPO21"])
                {
                    auxPar.Value = oCLOOKUP.ILBL_CAMPO21;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO22", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ILBL_CAMPO22"])
                {
                    auxPar.Value = oCLOOKUP.ILBL_CAMPO22;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO23", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ILBL_CAMPO23"])
                {
                    auxPar.Value = oCLOOKUP.ILBL_CAMPO23;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@LBL_CAMPO24", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ILBL_CAMPO24"])
                {
                    auxPar.Value = oCLOOKUP.ILBL_CAMPO24;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO25", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ILBL_CAMPO25"])
                {
                    auxPar.Value = oCLOOKUP.ILBL_CAMPO25;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO26", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ILBL_CAMPO26"])
                {
                    auxPar.Value = oCLOOKUP.ILBL_CAMPO26;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO27", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ILBL_CAMPO27"])
                {
                    auxPar.Value = oCLOOKUP.ILBL_CAMPO27;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO28", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ILBL_CAMPO28"])
                {
                    auxPar.Value = oCLOOKUP.ILBL_CAMPO28;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO29", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ILBL_CAMPO29"])
                {
                    auxPar.Value = oCLOOKUP.ILBL_CAMPO29;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO30", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ILBL_CAMPO30"])
                {
                    auxPar.Value = oCLOOKUP.ILBL_CAMPO30;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO31", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ILBL_CAMPO31"])
                {
                    auxPar.Value = oCLOOKUP.ILBL_CAMPO31;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO32", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ILBL_CAMPO32"])
                {
                    auxPar.Value = oCLOOKUP.ILBL_CAMPO32;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO33", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ILBL_CAMPO33"])
                {
                    auxPar.Value = oCLOOKUP.ILBL_CAMPO33;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO34", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ILBL_CAMPO34"])
                {
                    auxPar.Value = oCLOOKUP.ILBL_CAMPO34;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO35", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ILBL_CAMPO35"])
                {
                    auxPar.Value = oCLOOKUP.ILBL_CAMPO35;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO36", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ILBL_CAMPO36"])
                {
                    auxPar.Value = oCLOOKUP.ILBL_CAMPO36;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO37", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ILBL_CAMPO37"])
                {
                    auxPar.Value = oCLOOKUP.ILBL_CAMPO37;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO38", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ILBL_CAMPO38"])
                {
                    auxPar.Value = oCLOOKUP.ILBL_CAMPO38;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO39", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ILBL_CAMPO39"])
                {
                    auxPar.Value = oCLOOKUP.ILBL_CAMPO39;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO40", FbDbType.VarChar);
                if (!(bool)oCLOOKUP.isnull["ILBL_CAMPO40"])
                {
                    auxPar.Value = oCLOOKUP.ILBL_CAMPO40;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO LOOKUP
      (
    
ID,

ACTIVO,

CREADO,

CREADOPOR_USERID,

MODIFICADO,

MODIFICADOPOR_USERID,

CLAVE,

NOMBRE,

CAMPO1,

CAMPO2,

CAMPO3,

CAMPO4,

CAMPO5,

CAMPO6,

CAMPO7,

CAMPO8,

CAMPO9,

CAMPO10,

CAMPO11,

CAMPO12,

CAMPO13,

CAMPO14,

CAMPO15,

CAMPO16,

CAMPO17,

CAMPO18,

CAMPO19,

CAMPO20,

CAMPO21,

CAMPO22,

CAMPO23,
CAMPO24,
CAMPO25,
CAMPO26,
CAMPO27,
CAMPO28,
CAMPO29,
CAMPO30,
CAMPO31,
CAMPO32,
CAMPO33,
CAMPO34,
CAMPO35,
CAMPO36,
CAMPO37,
CAMPO38,
CAMPO39,
CAMPO40,


LBL_CAMPO1,

LBL_CAMPO2,

LBL_CAMPO3,

LBL_CAMPO4,

LBL_CAMPO5,

LBL_CAMPO6,

LBL_CAMPO7,

LBL_CAMPO8,

LBL_CAMPO9,

LBL_CAMPO10,

LBL_CAMPO11,

LBL_CAMPO12,

LBL_CAMPO13,

LBL_CAMPO14,

LBL_CAMPO15,

LBL_CAMPO16,

LBL_CAMPO17,

LBL_CAMPO18,

LBL_CAMPO19,

LBL_CAMPO20,

LBL_CAMPO21,

LBL_CAMPO22,

LBL_CAMPO23,
LBL_CAMPO24,
LBL_CAMPO25,
LBL_CAMPO26,
LBL_CAMPO27,
LBL_CAMPO28,
LBL_CAMPO29,
LBL_CAMPO30,
LBL_CAMPO31,
LBL_CAMPO32,
LBL_CAMPO33,
LBL_CAMPO34,
LBL_CAMPO35,
LBL_CAMPO36,
LBL_CAMPO37,
LBL_CAMPO38,
LBL_CAMPO39,
LBL_CAMPO40


         )

Values (

@ID,

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@CLAVE,

@NOMBRE,

@CAMPO1,

@CAMPO2,

@CAMPO3,

@CAMPO4,

@CAMPO5,

@CAMPO6,

@CAMPO7,

@CAMPO8,

@CAMPO9,

@CAMPO10,

@CAMPO11,

@CAMPO12,

@CAMPO13,

@CAMPO14,

@CAMPO15,

@CAMPO16,

@CAMPO17,

@CAMPO18,

@CAMPO19,

@CAMPO20,

@CAMPO21,

@CAMPO22,

@CAMPO23,

@CAMPO24,
@CAMPO25,
@CAMPO26,
@CAMPO27,
@CAMPO28,
@CAMPO29,
@CAMPO30,
@CAMPO31,
@CAMPO32,
@CAMPO33,
@CAMPO34,
@CAMPO35,
@CAMPO36,
@CAMPO37,
@CAMPO38,
@CAMPO39,
@CAMPO40,
@LBL_CAMPO1,

@LBL_CAMPO2,

@LBL_CAMPO3,

@LBL_CAMPO4,

@LBL_CAMPO5,

@LBL_CAMPO6,

@LBL_CAMPO7,

@LBL_CAMPO8,

@LBL_CAMPO9,

@LBL_CAMPO10,

@LBL_CAMPO11,

@LBL_CAMPO12,

@LBL_CAMPO13,

@LBL_CAMPO14,

@LBL_CAMPO15,

@LBL_CAMPO16,

@LBL_CAMPO17,

@LBL_CAMPO18,

@LBL_CAMPO19,

@LBL_CAMPO20,

@LBL_CAMPO21,

@LBL_CAMPO22,

@LBL_CAMPO23,

@LBL_CAMPO24,
@LBL_CAMPO25,
@LBL_CAMPO26,
@LBL_CAMPO27,
@LBL_CAMPO28,
@LBL_CAMPO29,
@LBL_CAMPO30,
@LBL_CAMPO31,
@LBL_CAMPO32,
@LBL_CAMPO33,
@LBL_CAMPO34,
@LBL_CAMPO35,
@LBL_CAMPO36,
@LBL_CAMPO37,
@LBL_CAMPO38,
@LBL_CAMPO39,
@LBL_CAMPO40
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCLOOKUP;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarLOOKUPD(CLOOKUPBE oCLOOKUP, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCLOOKUP.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from LOOKUP
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
        public bool CambiarLOOKUPD(CLOOKUPBE oCLOOKUPNuevo, CLOOKUPBE oCLOOKUPAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCLOOKUPNuevo.isnull["IID"])
                {
                    auxPar.Value = oCLOOKUPNuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCLOOKUPNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCLOOKUPNuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCLOOKUPNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCLOOKUPNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ICLAVE"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["INOMBRE"])
                {
                    auxPar.Value = oCLOOKUPNuevo.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO1", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO1"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO2", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO2"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO3", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO3"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO4", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO4"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO5", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO5"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO6", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO6"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO7", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO7"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO7;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO8", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO8"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO8;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO9", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO9"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO9;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO10", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO10"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO10;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO11", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO11"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO11;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO12", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO12"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO12;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO13", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO13"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO13;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO14", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO14"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO14;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO15", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO15"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO15;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO16", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO16"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO16;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO17", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO17"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO17;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO18", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO18"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO18;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO19", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO19"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO19;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO20", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO20"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO20;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO21", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO21"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO21;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO22", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO22"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO22;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@CAMPO23", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO23"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO23;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@CAMPO24", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO24"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO24;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO25", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO25"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO25;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO26", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO26"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO26;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO27", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO27"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO27;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO28", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO28"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO28;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO29", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO29"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO29;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO30", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO30"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO30;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO31", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO31"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO31;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO32", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO32"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO32;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO33", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO33"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO33;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO34", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO34"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO34;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO35", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO35"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO35;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO36", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO36"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO36;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO37", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO37"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO37;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO38", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO38"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO38;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO39", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO39"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO39;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO40", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO40"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO40;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO1", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO1"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO2", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO2"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO3", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO3"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO4", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO4"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO5", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO5"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO6", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO6"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO7", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO7"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO7;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO8", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO8"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO8;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO9", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO9"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO9;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO10", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO10"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO10;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO11", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO11"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO11;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO12", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO12"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO12;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO13", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO13"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO13;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO14", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO14"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO14;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO15", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO15"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO15;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO16", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO16"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO16;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO17", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO17"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO17;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO18", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO18"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO18;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO19", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO19"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO19;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO20", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO20"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO20;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO21", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO21"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO21;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO22", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO22"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO22;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@LBL_CAMPO23", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO23"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO23;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@LBL_CAMPO24", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO24"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO24;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO25", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO25"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO25;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO26", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO26"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO26;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO27", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO27"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO27;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO28", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO28"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO28;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO29", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO29"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO29;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO30", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO30"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO30;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO31", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO31"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO31;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO32", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO32"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO32;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO33", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO33"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO33;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO34", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO34"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO34;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO35", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO35"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO35;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO36", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO36"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO36;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO37", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO37"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO37;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO38", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO38"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO38;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO39", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO39"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO39;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO40", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO40"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO40;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCLOOKUPAnterior.isnull["IID"])
                {
                    auxPar.Value = oCLOOKUPAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  LOOKUP
  set

ID=@ID,

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

CLAVE=@CLAVE,

NOMBRE=@NOMBRE,

CAMPO1=@CAMPO1,

CAMPO2=@CAMPO2,

CAMPO3=@CAMPO3,

CAMPO4=@CAMPO4,

CAMPO5=@CAMPO5,

CAMPO6=@CAMPO6,

CAMPO7=@CAMPO7,

CAMPO8=@CAMPO8,

CAMPO9=@CAMPO9,

CAMPO10=@CAMPO10,

CAMPO11=@CAMPO11,

CAMPO12=@CAMPO12,

CAMPO13=@CAMPO13,

CAMPO14=@CAMPO14,

CAMPO15=@CAMPO15,

CAMPO16=@CAMPO16,

CAMPO17=@CAMPO17,

CAMPO18=@CAMPO18,

CAMPO19=@CAMPO19,

CAMPO20=@CAMPO20,

CAMPO21=@CAMPO21,

CAMPO22=@CAMPO22,

CAMPO23=@CAMPO23,
CAMPO24=@CAMPO24,
CAMPO25=@CAMPO25,
CAMPO26=@CAMPO26,
CAMPO27=@CAMPO27,
CAMPO28=@CAMPO28,
CAMPO29=@CAMPO29,
CAMPO30=@CAMPO30,
CAMPO31=@CAMPO31,
CAMPO32=@CAMPO32,
CAMPO33=@CAMPO33,
CAMPO34=@CAMPO34,
CAMPO35=@CAMPO35,
CAMPO36=@CAMPO36,
CAMPO37=@CAMPO37,
CAMPO38=@CAMPO38,
CAMPO39=@CAMPO39,
CAMPO40=@CAMPO40,

LBL_CAMPO1=@LBL_CAMPO1,

LBL_CAMPO2=@LBL_CAMPO2,

LBL_CAMPO3=@LBL_CAMPO3,

LBL_CAMPO4=@LBL_CAMPO4,

LBL_CAMPO5=@LBL_CAMPO5,

LBL_CAMPO6=@LBL_CAMPO6,

LBL_CAMPO7=@LBL_CAMPO7,

LBL_CAMPO8=@LBL_CAMPO8,

LBL_CAMPO9=@LBL_CAMPO9,

LBL_CAMPO10=@LBL_CAMPO10,

LBL_CAMPO11=@LBL_CAMPO11,

LBL_CAMPO12=@LBL_CAMPO12,

LBL_CAMPO13=@LBL_CAMPO13,

LBL_CAMPO14=@LBL_CAMPO14,

LBL_CAMPO15=@LBL_CAMPO15,

LBL_CAMPO16=@LBL_CAMPO16,

LBL_CAMPO17=@LBL_CAMPO17,

LBL_CAMPO18=@LBL_CAMPO18,

LBL_CAMPO19=@LBL_CAMPO19,

LBL_CAMPO20=@LBL_CAMPO20,

LBL_CAMPO21=@LBL_CAMPO21,

LBL_CAMPO22=@LBL_CAMPO22,

LBL_CAMPO23=@LBL_CAMPO23,
LBL_CAMPO24=@LBL_CAMPO24,
LBL_CAMPO25=@LBL_CAMPO25,
LBL_CAMPO26=@LBL_CAMPO26,
LBL_CAMPO27=@LBL_CAMPO27,
LBL_CAMPO28=@LBL_CAMPO28,
LBL_CAMPO29=@LBL_CAMPO29,
LBL_CAMPO30=@LBL_CAMPO30,
LBL_CAMPO31=@LBL_CAMPO31,
LBL_CAMPO32=@LBL_CAMPO32,
LBL_CAMPO33=@LBL_CAMPO33,
LBL_CAMPO34=@LBL_CAMPO34,
LBL_CAMPO35=@LBL_CAMPO35,
LBL_CAMPO36=@LBL_CAMPO36,
LBL_CAMPO37=@LBL_CAMPO37,
LBL_CAMPO38=@LBL_CAMPO38,
LBL_CAMPO39=@LBL_CAMPO39,
LBL_CAMPO40=@LBL_CAMPO40


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





        public bool CambiarCamposLOOKUPD(CLOOKUPBE oCLOOKUPNuevo, CLOOKUPBE oCLOOKUPAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



              

                auxPar = new FbParameter("@CAMPO1", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO1"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO2", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO2"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO3", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO3"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO4", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO4"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO5", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO5"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO6", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO6"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO7", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO7"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO7;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO8", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO8"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO8;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO9", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO9"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO9;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO10", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO10"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO10;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO11", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO11"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO11;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO12", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO12"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO12;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO13", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO13"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO13;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO14", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO14"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO14;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO15", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO15"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO15;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO16", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO16"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO16;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO17", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO17"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO17;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO18", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO18"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO18;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO19", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO19"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO19;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO20", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO20"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO20;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPO21", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO21"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO21;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CAMPO22", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO22"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO22;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPO23", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO23"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO23;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);





                auxPar = new FbParameter("@CAMPO24", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO24"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO24;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CAMPO25", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO25"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO25;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CAMPO26", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO26"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO26;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CAMPO27", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO27"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO27;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CAMPO28", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO28"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO28;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CAMPO29", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO29"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO29;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CAMPO30", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO30"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO30;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CAMPO31", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO31"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO31;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CAMPO32", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO32"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO32;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CAMPO33", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO33"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO33;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CAMPO34", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO34"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO34;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CAMPO35", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO35"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO35;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CAMPO36", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO36"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO36;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CAMPO37", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO37"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO37;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CAMPO38", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO38"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO38;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CAMPO39", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO39"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO39;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CAMPO40", FbDbType.Char);
                if (!(bool)oCLOOKUPNuevo.isnull["ICAMPO40"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ICAMPO40;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@LBL_CAMPO1", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO1"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO2", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO2"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO3", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO3"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO4", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO4"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO5", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO5"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO6", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO6"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO7", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO7"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO7;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO8", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO8"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO8;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO9", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO9"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO9;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO10", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO10"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO10;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO11", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO11"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO11;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO12", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO12"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO12;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO13", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO13"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO13;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO14", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO14"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO14;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO15", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO15"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO15;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO16", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO16"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO16;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO17", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO17"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO17;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO18", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO18"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO18;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO19", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO19"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO19;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO20", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO20"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO20;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LBL_CAMPO21", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO21"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO21;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@LBL_CAMPO22", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO22"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO22;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LBL_CAMPO23", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO23"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO23;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);





                auxPar = new FbParameter("@LBL_CAMPO24", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO24"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO24;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@LBL_CAMPO25", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO25"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO25;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@LBL_CAMPO26", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO26"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO26;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@LBL_CAMPO27", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO27"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO27;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@LBL_CAMPO28", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO28"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO28;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@LBL_CAMPO29", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO29"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO29;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@LBL_CAMPO30", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO30"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO30;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@LBL_CAMPO31", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO31"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO31;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@LBL_CAMPO32", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO32"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO32;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@LBL_CAMPO33", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO33"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO33;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@LBL_CAMPO34", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO34"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO34;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@LBL_CAMPO35", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO35"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO35;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@LBL_CAMPO36", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO36"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO36;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@LBL_CAMPO37", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO37"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO37;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@LBL_CAMPO38", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO38"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO38;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@LBL_CAMPO39", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO39"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO39;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@LBL_CAMPO40", FbDbType.VarChar);
                if (!(bool)oCLOOKUPNuevo.isnull["ILBL_CAMPO40"])
                {
                    auxPar.Value = oCLOOKUPNuevo.ILBL_CAMPO40;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@CLAVEANT", FbDbType.VarChar);
                if (!(bool)oCLOOKUPAnterior.isnull["ICLAVE"])
                {
                    auxPar.Value = oCLOOKUPAnterior.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  LOOKUP
  set


CAMPO1=@CAMPO1,

CAMPO2=@CAMPO2,

CAMPO3=@CAMPO3,

CAMPO4=@CAMPO4,

CAMPO5=@CAMPO5,

CAMPO6=@CAMPO6,

CAMPO7=@CAMPO7,

CAMPO8=@CAMPO8,

CAMPO9=@CAMPO9,

CAMPO10=@CAMPO10,

CAMPO11=@CAMPO11,

CAMPO12=@CAMPO12,

CAMPO13=@CAMPO13,

CAMPO14=@CAMPO14,

CAMPO15=@CAMPO15,

CAMPO16=@CAMPO16,

CAMPO17=@CAMPO17,

CAMPO18=@CAMPO18,

CAMPO19=@CAMPO19,

CAMPO20=@CAMPO20,

CAMPO21=@CAMPO21,

CAMPO22=@CAMPO22,

CAMPO23=@CAMPO23,

CAMPO24=@CAMPO24,
CAMPO25=@CAMPO25,
CAMPO26=@CAMPO26,
CAMPO27=@CAMPO27,
CAMPO28=@CAMPO28,
CAMPO29=@CAMPO29,
CAMPO30=@CAMPO30,
CAMPO31=@CAMPO31,
CAMPO32=@CAMPO32,
CAMPO33=@CAMPO33,
CAMPO34=@CAMPO34,
CAMPO35=@CAMPO35,
CAMPO36=@CAMPO36,
CAMPO37=@CAMPO37,
CAMPO38=@CAMPO38,
CAMPO39=@CAMPO39,
CAMPO40=@CAMPO40,


LBL_CAMPO1=@LBL_CAMPO1,

LBL_CAMPO2=@LBL_CAMPO2,

LBL_CAMPO3=@LBL_CAMPO3,

LBL_CAMPO4=@LBL_CAMPO4,

LBL_CAMPO5=@LBL_CAMPO5,

LBL_CAMPO6=@LBL_CAMPO6,

LBL_CAMPO7=@LBL_CAMPO7,

LBL_CAMPO8=@LBL_CAMPO8,

LBL_CAMPO9=@LBL_CAMPO9,

LBL_CAMPO10=@LBL_CAMPO10,

LBL_CAMPO11=@LBL_CAMPO11,

LBL_CAMPO12=@LBL_CAMPO12,

LBL_CAMPO13=@LBL_CAMPO13,

LBL_CAMPO14=@LBL_CAMPO14,

LBL_CAMPO15=@LBL_CAMPO15,

LBL_CAMPO16=@LBL_CAMPO16,

LBL_CAMPO17=@LBL_CAMPO17,

LBL_CAMPO18=@LBL_CAMPO18,

LBL_CAMPO19=@LBL_CAMPO19,

LBL_CAMPO20=@LBL_CAMPO20,

LBL_CAMPO21=@LBL_CAMPO21,

LBL_CAMPO22=@LBL_CAMPO22,

LBL_CAMPO23=@LBL_CAMPO23,

LBL_CAMPO24=@LBL_CAMPO24,
LBL_CAMPO25=@LBL_CAMPO25,
LBL_CAMPO26=@LBL_CAMPO26,
LBL_CAMPO27=@LBL_CAMPO27,
LBL_CAMPO28=@LBL_CAMPO28,
LBL_CAMPO29=@LBL_CAMPO29,
LBL_CAMPO30=@LBL_CAMPO30,
LBL_CAMPO31=@LBL_CAMPO31,
LBL_CAMPO32=@LBL_CAMPO32,
LBL_CAMPO33=@LBL_CAMPO33,
LBL_CAMPO34=@LBL_CAMPO34,
LBL_CAMPO35=@LBL_CAMPO35,
LBL_CAMPO36=@LBL_CAMPO36,
LBL_CAMPO37=@LBL_CAMPO37,
LBL_CAMPO38=@LBL_CAMPO38,
LBL_CAMPO39=@LBL_CAMPO39,
LBL_CAMPO40=@LBL_CAMPO40

  where 

CLAVE=@CLAVEANT
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
        public CLOOKUPBE seleccionarLOOKUP(CLOOKUPBE oCLOOKUP, FbTransaction st)
        {




            CLOOKUPBE retorno = new CLOOKUPBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from LOOKUP where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCLOOKUP.IID;
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

                    if (dr["CAMPO1"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO1 = (string)(dr["CAMPO1"]);
                    }

                    if (dr["CAMPO2"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO2 = (string)(dr["CAMPO2"]);
                    }

                    if (dr["CAMPO3"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO3 = (string)(dr["CAMPO3"]);
                    }

                    if (dr["CAMPO4"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO4 = (string)(dr["CAMPO4"]);
                    }

                    if (dr["CAMPO5"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO5 = (string)(dr["CAMPO5"]);
                    }

                    if (dr["CAMPO6"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO6 = (string)(dr["CAMPO6"]);
                    }

                    if (dr["CAMPO7"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO7 = (string)(dr["CAMPO7"]);
                    }

                    if (dr["CAMPO8"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO8 = (string)(dr["CAMPO8"]);
                    }

                    if (dr["CAMPO9"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO9 = (string)(dr["CAMPO9"]);
                    }

                    if (dr["CAMPO10"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO10 = (string)(dr["CAMPO10"]);
                    }

                    if (dr["CAMPO11"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO11 = (string)(dr["CAMPO11"]);
                    }

                    if (dr["CAMPO12"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO12 = (string)(dr["CAMPO12"]);
                    }

                    if (dr["CAMPO13"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO13 = (string)(dr["CAMPO13"]);
                    }

                    if (dr["CAMPO14"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO14 = (string)(dr["CAMPO14"]);
                    }

                    if (dr["CAMPO15"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO15 = (string)(dr["CAMPO15"]);
                    }

                    if (dr["CAMPO16"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO16 = (string)(dr["CAMPO16"]);
                    }

                    if (dr["CAMPO17"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO17 = (string)(dr["CAMPO17"]);
                    }

                    if (dr["CAMPO18"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO18 = (string)(dr["CAMPO18"]);
                    }

                    if (dr["CAMPO19"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO19 = (string)(dr["CAMPO19"]);
                    }

                    if (dr["CAMPO20"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO20 = (string)(dr["CAMPO20"]);
                    }

                    if (dr["CAMPO21"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO21 = (string)(dr["CAMPO21"]);
                    }
                    if (dr["CAMPO22"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO22 = (string)(dr["CAMPO22"]);
                    }
                    if (dr["CAMPO23"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO23 = (string)(dr["CAMPO23"]);
                    }

                    if (dr["CAMPO24"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO24 = (string)(dr["CAMPO24"]);
                    }

                    if (dr["CAMPO25"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO25 = (string)(dr["CAMPO25"]);
                    }

                    if (dr["CAMPO26"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO26 = (string)(dr["CAMPO26"]);
                    }

                    if (dr["CAMPO27"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO27 = (string)(dr["CAMPO27"]);
                    }

                    if (dr["CAMPO28"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO28 = (string)(dr["CAMPO28"]);
                    }

                    if (dr["CAMPO29"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO29 = (string)(dr["CAMPO29"]);
                    }

                    if (dr["CAMPO30"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO30 = (string)(dr["CAMPO30"]);
                    }

                    if (dr["CAMPO31"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO31 = (string)(dr["CAMPO31"]);
                    }

                    if (dr["CAMPO32"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO32 = (string)(dr["CAMPO32"]);
                    }

                    if (dr["CAMPO33"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO33 = (string)(dr["CAMPO33"]);
                    }

                    if (dr["CAMPO34"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO34 = (string)(dr["CAMPO34"]);
                    }

                    if (dr["CAMPO35"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO35 = (string)(dr["CAMPO35"]);
                    }

                    if (dr["CAMPO36"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO36 = (string)(dr["CAMPO36"]);
                    }

                    if (dr["CAMPO37"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO37 = (string)(dr["CAMPO37"]);
                    }

                    if (dr["CAMPO38"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO38 = (string)(dr["CAMPO38"]);
                    }

                    if (dr["CAMPO39"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO39 = (string)(dr["CAMPO39"]);
                    }

                    if (dr["CAMPO40"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO40 = (string)(dr["CAMPO40"]);
                    }


                    if (dr["LBL_CAMPO1"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO1 = (string)(dr["LBL_CAMPO1"]);
                    }

                    if (dr["LBL_CAMPO2"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO2 = (string)(dr["LBL_CAMPO2"]);
                    }

                    if (dr["LBL_CAMPO3"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO3 = (string)(dr["LBL_CAMPO3"]);
                    }

                    if (dr["LBL_CAMPO4"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO4 = (string)(dr["LBL_CAMPO4"]);
                    }

                    if (dr["LBL_CAMPO5"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO5 = (string)(dr["LBL_CAMPO5"]);
                    }

                    if (dr["LBL_CAMPO6"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO6 = (string)(dr["LBL_CAMPO6"]);
                    }

                    if (dr["LBL_CAMPO7"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO7 = (string)(dr["LBL_CAMPO7"]);
                    }

                    if (dr["LBL_CAMPO8"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO8 = (string)(dr["LBL_CAMPO8"]);
                    }

                    if (dr["LBL_CAMPO9"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO9 = (string)(dr["LBL_CAMPO9"]);
                    }

                    if (dr["LBL_CAMPO10"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO10 = (string)(dr["LBL_CAMPO10"]);
                    }

                    if (dr["LBL_CAMPO11"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO11 = (string)(dr["LBL_CAMPO11"]);
                    }

                    if (dr["LBL_CAMPO12"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO12 = (string)(dr["LBL_CAMPO12"]);
                    }

                    if (dr["LBL_CAMPO13"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO13 = (string)(dr["LBL_CAMPO13"]);
                    }

                    if (dr["LBL_CAMPO14"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO14 = (string)(dr["LBL_CAMPO14"]);
                    }

                    if (dr["LBL_CAMPO15"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO15 = (string)(dr["LBL_CAMPO15"]);
                    }

                    if (dr["LBL_CAMPO16"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO16 = (string)(dr["LBL_CAMPO16"]);
                    }

                    if (dr["LBL_CAMPO17"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO17 = (string)(dr["LBL_CAMPO17"]);
                    }

                    if (dr["LBL_CAMPO18"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO18 = (string)(dr["LBL_CAMPO18"]);
                    }

                    if (dr["LBL_CAMPO19"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO19 = (string)(dr["LBL_CAMPO19"]);
                    }

                    if (dr["LBL_CAMPO20"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO20 = (string)(dr["LBL_CAMPO20"]);
                    }

                    if (dr["LBL_CAMPO21"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO21 = (string)(dr["LBL_CAMPO21"]);
                    }
                    if (dr["LBL_CAMPO22"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO22 = (string)(dr["LBL_CAMPO22"]);
                    }
                    if (dr["LBL_CAMPO23"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO23 = (string)(dr["LBL_CAMPO23"]);
                    }

                    if (dr["LBL_CAMPO24"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO24 = (string)(dr["LBL_CAMPO24"]);
                    }

                    if (dr["LBL_CAMPO25"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO25 = (string)(dr["LBL_CAMPO25"]);
                    }

                    if (dr["LBL_CAMPO26"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO26 = (string)(dr["LBL_CAMPO26"]);
                    }

                    if (dr["LBL_CAMPO27"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO27 = (string)(dr["LBL_CAMPO27"]);
                    }

                    if (dr["LBL_CAMPO28"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO28 = (string)(dr["LBL_CAMPO28"]);
                    }

                    if (dr["LBL_CAMPO29"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO29 = (string)(dr["LBL_CAMPO29"]);
                    }

                    if (dr["LBL_CAMPO30"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO30 = (string)(dr["LBL_CAMPO30"]);
                    }

                    if (dr["LBL_CAMPO31"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO31 = (string)(dr["LBL_CAMPO31"]);
                    }

                    if (dr["LBL_CAMPO32"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO32 = (string)(dr["LBL_CAMPO32"]);
                    }

                    if (dr["LBL_CAMPO33"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO33 = (string)(dr["LBL_CAMPO33"]);
                    }

                    if (dr["LBL_CAMPO34"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO34 = (string)(dr["LBL_CAMPO34"]);
                    }

                    if (dr["LBL_CAMPO35"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO35 = (string)(dr["LBL_CAMPO35"]);
                    }

                    if (dr["LBL_CAMPO36"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO36 = (string)(dr["LBL_CAMPO36"]);
                    }

                    if (dr["LBL_CAMPO37"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO37 = (string)(dr["LBL_CAMPO37"]);
                    }

                    if (dr["LBL_CAMPO38"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO38 = (string)(dr["LBL_CAMPO38"]);
                    }

                    if (dr["LBL_CAMPO39"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO39 = (string)(dr["LBL_CAMPO39"]);
                    }

                    if (dr["LBL_CAMPO40"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO40 = (string)(dr["LBL_CAMPO40"]);
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





        public CLOOKUPBE seleccionarLOOKUPXClave(CLOOKUPBE oCLOOKUP, FbTransaction st)
        {




            CLOOKUPBE retorno = new CLOOKUPBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from LOOKUP where
 CLAVE=@CLAVE  ";


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                auxPar.Value = oCLOOKUP.ICLAVE;
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

                    if (dr["CAMPO1"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO1 = (string)(dr["CAMPO1"]);
                    }

                    if (dr["CAMPO2"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO2 = (string)(dr["CAMPO2"]);
                    }

                    if (dr["CAMPO3"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO3 = (string)(dr["CAMPO3"]);
                    }

                    if (dr["CAMPO4"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO4 = (string)(dr["CAMPO4"]);
                    }

                    if (dr["CAMPO5"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO5 = (string)(dr["CAMPO5"]);
                    }

                    if (dr["CAMPO6"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO6 = (string)(dr["CAMPO6"]);
                    }

                    if (dr["CAMPO7"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO7 = (string)(dr["CAMPO7"]);
                    }

                    if (dr["CAMPO8"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO8 = (string)(dr["CAMPO8"]);
                    }

                    if (dr["CAMPO9"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO9 = (string)(dr["CAMPO9"]);
                    }

                    if (dr["CAMPO10"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO10 = (string)(dr["CAMPO10"]);
                    }

                    if (dr["CAMPO11"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO11 = (string)(dr["CAMPO11"]);
                    }

                    if (dr["CAMPO12"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO12 = (string)(dr["CAMPO12"]);
                    }

                    if (dr["CAMPO13"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO13 = (string)(dr["CAMPO13"]);
                    }

                    if (dr["CAMPO14"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO14 = (string)(dr["CAMPO14"]);
                    }

                    if (dr["CAMPO15"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO15 = (string)(dr["CAMPO15"]);
                    }

                    if (dr["CAMPO16"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO16 = (string)(dr["CAMPO16"]);
                    }

                    if (dr["CAMPO17"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO17 = (string)(dr["CAMPO17"]);
                    }

                    if (dr["CAMPO18"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO18 = (string)(dr["CAMPO18"]);
                    }

                    if (dr["CAMPO19"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO19 = (string)(dr["CAMPO19"]);
                    }

                    if (dr["CAMPO20"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO20 = (string)(dr["CAMPO20"]);
                    }

                    if (dr["CAMPO21"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO21 = (string)(dr["CAMPO21"]);
                    }
                    if (dr["CAMPO22"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO22 = (string)(dr["CAMPO22"]);
                    }
                    if (dr["CAMPO23"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO23 = (string)(dr["CAMPO23"]);
                    }

                    if (dr["CAMPO24"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO24 = (string)(dr["CAMPO24"]);
                    }

                    if (dr["CAMPO25"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO25 = (string)(dr["CAMPO25"]);
                    }

                    if (dr["CAMPO26"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO26 = (string)(dr["CAMPO26"]);
                    }

                    if (dr["CAMPO27"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO27 = (string)(dr["CAMPO27"]);
                    }

                    if (dr["CAMPO28"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO28 = (string)(dr["CAMPO28"]);
                    }

                    if (dr["CAMPO29"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO29 = (string)(dr["CAMPO29"]);
                    }

                    if (dr["CAMPO30"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO30 = (string)(dr["CAMPO30"]);
                    }

                    if (dr["CAMPO31"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO31 = (string)(dr["CAMPO31"]);
                    }

                    if (dr["CAMPO32"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO32 = (string)(dr["CAMPO32"]);
                    }

                    if (dr["CAMPO33"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO33 = (string)(dr["CAMPO33"]);
                    }

                    if (dr["CAMPO34"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO34 = (string)(dr["CAMPO34"]);
                    }

                    if (dr["CAMPO35"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO35 = (string)(dr["CAMPO35"]);
                    }

                    if (dr["CAMPO36"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO36 = (string)(dr["CAMPO36"]);
                    }

                    if (dr["CAMPO37"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO37 = (string)(dr["CAMPO37"]);
                    }

                    if (dr["CAMPO38"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO38 = (string)(dr["CAMPO38"]);
                    }

                    if (dr["CAMPO39"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO39 = (string)(dr["CAMPO39"]);
                    }

                    if (dr["CAMPO40"] != System.DBNull.Value)
                    {
                        retorno.ICAMPO40 = (string)(dr["CAMPO40"]);
                    }


                    if (dr["LBL_CAMPO1"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO1 = (string)(dr["LBL_CAMPO1"]);
                    }

                    if (dr["LBL_CAMPO2"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO2 = (string)(dr["LBL_CAMPO2"]);
                    }

                    if (dr["LBL_CAMPO3"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO3 = (string)(dr["LBL_CAMPO3"]);
                    }

                    if (dr["LBL_CAMPO4"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO4 = (string)(dr["LBL_CAMPO4"]);
                    }

                    if (dr["LBL_CAMPO5"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO5 = (string)(dr["LBL_CAMPO5"]);
                    }

                    if (dr["LBL_CAMPO6"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO6 = (string)(dr["LBL_CAMPO6"]);
                    }

                    if (dr["LBL_CAMPO7"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO7 = (string)(dr["LBL_CAMPO7"]);
                    }

                    if (dr["LBL_CAMPO8"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO8 = (string)(dr["LBL_CAMPO8"]);
                    }

                    if (dr["LBL_CAMPO9"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO9 = (string)(dr["LBL_CAMPO9"]);
                    }

                    if (dr["LBL_CAMPO10"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO10 = (string)(dr["LBL_CAMPO10"]);
                    }

                    if (dr["LBL_CAMPO11"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO11 = (string)(dr["LBL_CAMPO11"]);
                    }

                    if (dr["LBL_CAMPO12"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO12 = (string)(dr["LBL_CAMPO12"]);
                    }

                    if (dr["LBL_CAMPO13"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO13 = (string)(dr["LBL_CAMPO13"]);
                    }

                    if (dr["LBL_CAMPO14"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO14 = (string)(dr["LBL_CAMPO14"]);
                    }

                    if (dr["LBL_CAMPO15"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO15 = (string)(dr["LBL_CAMPO15"]);
                    }

                    if (dr["LBL_CAMPO16"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO16 = (string)(dr["LBL_CAMPO16"]);
                    }

                    if (dr["LBL_CAMPO17"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO17 = (string)(dr["LBL_CAMPO17"]);
                    }

                    if (dr["LBL_CAMPO18"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO18 = (string)(dr["LBL_CAMPO18"]);
                    }

                    if (dr["LBL_CAMPO19"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO19 = (string)(dr["LBL_CAMPO19"]);
                    }

                    if (dr["LBL_CAMPO20"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO20 = (string)(dr["LBL_CAMPO20"]);
                    }

                    if (dr["LBL_CAMPO21"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO21 = (string)(dr["LBL_CAMPO21"]);
                    }
                    if (dr["LBL_CAMPO22"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO22 = (string)(dr["LBL_CAMPO22"]);
                    }
                    if (dr["LBL_CAMPO23"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO23 = (string)(dr["LBL_CAMPO23"]);
                    }

                    if (dr["LBL_CAMPO24"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO24 = (string)(dr["LBL_CAMPO24"]);
                    }

                    if (dr["LBL_CAMPO25"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO25 = (string)(dr["LBL_CAMPO25"]);
                    }

                    if (dr["LBL_CAMPO26"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO26 = (string)(dr["LBL_CAMPO26"]);
                    }

                    if (dr["LBL_CAMPO27"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO27 = (string)(dr["LBL_CAMPO27"]);
                    }

                    if (dr["LBL_CAMPO28"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO28 = (string)(dr["LBL_CAMPO28"]);
                    }

                    if (dr["LBL_CAMPO29"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO29 = (string)(dr["LBL_CAMPO29"]);
                    }

                    if (dr["LBL_CAMPO30"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO30 = (string)(dr["LBL_CAMPO30"]);
                    }

                    if (dr["LBL_CAMPO31"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO31 = (string)(dr["LBL_CAMPO31"]);
                    }

                    if (dr["LBL_CAMPO32"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO32 = (string)(dr["LBL_CAMPO32"]);
                    }

                    if (dr["LBL_CAMPO33"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO33 = (string)(dr["LBL_CAMPO33"]);
                    }

                    if (dr["LBL_CAMPO34"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO34 = (string)(dr["LBL_CAMPO34"]);
                    }

                    if (dr["LBL_CAMPO35"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO35 = (string)(dr["LBL_CAMPO35"]);
                    }

                    if (dr["LBL_CAMPO36"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO36 = (string)(dr["LBL_CAMPO36"]);
                    }

                    if (dr["LBL_CAMPO37"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO37 = (string)(dr["LBL_CAMPO37"]);
                    }

                    if (dr["LBL_CAMPO38"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO38 = (string)(dr["LBL_CAMPO38"]);
                    }

                    if (dr["LBL_CAMPO39"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO39 = (string)(dr["LBL_CAMPO39"]);
                    }

                    if (dr["LBL_CAMPO40"] != System.DBNull.Value)
                    {
                        retorno.ILBL_CAMPO40 = (string)(dr["LBL_CAMPO40"]);
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
        public DataSet enlistarLOOKUP()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_LOOKUP_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoLOOKUP()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_LOOKUP_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteLOOKUP(CLOOKUPBE oCLOOKUP, FbTransaction st)
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
                auxPar.Value = oCLOOKUP.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from LOOKUP where

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




        public CLOOKUPBE AgregarLOOKUP(CLOOKUPBE oCLOOKUP, FbTransaction st)
        {
            try
            {
                int iRes = ExisteLOOKUP(oCLOOKUP, st);
                if (iRes == 1)
                {
                    this.IComentario = "El LOOKUP ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarLOOKUPD(oCLOOKUP, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarLOOKUP(CLOOKUPBE oCLOOKUP, FbTransaction st)
        {
            try
            {
                int iRes = ExisteLOOKUP(oCLOOKUP, st);
                if (iRes == 0)
                {
                    this.IComentario = "El LOOKUP no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarLOOKUPD(oCLOOKUP, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarLOOKUP(CLOOKUPBE oCLOOKUPNuevo, CLOOKUPBE oCLOOKUPAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteLOOKUP(oCLOOKUPAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El LOOKUP no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarLOOKUPD(oCLOOKUPNuevo, oCLOOKUPAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CLOOKUPD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
