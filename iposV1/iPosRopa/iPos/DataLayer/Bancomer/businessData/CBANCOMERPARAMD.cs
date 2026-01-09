

using System;
using Microsoft.ApplicationBlocks.Data;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Collections;
using ConexionesBD;
using iPosBusinessEntity;
using System.Collections.Generic;

namespace iPosData
{



    public class CBANCOMERPARAMD
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


        public CBANCOMERPARAMBE AgregarBANCOMERPARAMD(CBANCOMERPARAMBE oCBANCOMERPARAM, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCBANCOMERPARAM.isnull["IID"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAM.isnull["IACTIVO"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCBANCOMERPARAM.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCBANCOMERPARAM.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@AID", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IAID"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@AMEX", FbDbType.SmallInt);
                if (!(bool)oCBANCOMERPARAM.isnull["IAMEX"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IAMEX;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@BANCOMER", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAM.isnull["IBANCOMER"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IBANCOMER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@BITCAMPANAS", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAM.isnull["IBITCAMPANAS"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IBITCAMPANAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPANAAUTORIZACION", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICAMPANAAUTORIZACION"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICAMPANAAUTORIZACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPANAREFERENCIA", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICAMPANAREFERENCIA"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICAMPANAREFERENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPANAREFERENCIANUM", FbDbType.BigInt);
                if (!(bool)oCBANCOMERPARAM.isnull["ICAMPANAREFERENCIANUM"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICAMPANAREFERENCIANUM;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CARDREQUEST", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICARDREQUEST"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICARDREQUEST;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CARDTIPO", FbDbType.Integer);
                if (!(bool)oCBANCOMERPARAM.isnull["ICARDTIPO"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICARDTIPO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PROMOCIONES", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAM.isnull["IPROMOCIONES"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IPROMOCIONES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLIENTE_CMP_COMERCIO", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICLIENTE_CMP_COMERCIO"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICLIENTE_CMP_COMERCIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLIENTE_TDC_STOCK", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICLIENTE_TDC_STOCK"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICLIENTE_TDC_STOCK;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLSREQUESTID", FbDbType.BigInt);
                if (!(bool)oCBANCOMERPARAM.isnull["ICLSREQUESTID"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICLSREQUESTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLSRESPONSEID", FbDbType.BigInt);
                if (!(bool)oCBANCOMERPARAM.isnull["ICLSRESPONSEID"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICLSRESPONSEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CODIGO_BENEFICIO1", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICODIGO_BENEFICIO1"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICODIGO_BENEFICIO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CODIGO_BENEFICIO2", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICODIGO_BENEFICIO2"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICODIGO_BENEFICIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CODIGO_BENEFICIO3", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICODIGO_BENEFICIO3"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICODIGO_BENEFICIO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CODIGO_BENEFICIO4", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICODIGO_BENEFICIO4"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICODIGO_BENEFICIO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CODIGO_BENEFICIO5", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICODIGO_BENEFICIO5"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICODIGO_BENEFICIO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CODIGO_BENEFICIO6", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICODIGO_BENEFICIO6"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICODIGO_BENEFICIO6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CODIGO_BENEFICIO7", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICODIGO_BENEFICIO7"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICODIGO_BENEFICIO7;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COMERCIO_CMP_COMERCIO", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICOMERCIO_CMP_COMERCIO"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICOMERCIO_CMP_COMERCIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COMERCIO_TDC_STOCK", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICOMERCIO_TDC_STOCK"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICOMERCIO_TDC_STOCK;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COMISION1", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICOMISION1"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICOMISION1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COMISION2", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICOMISION2"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICOMISION2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COMISION3", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICOMISION3"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICOMISION3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COMISION4", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICOMISION4"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICOMISION4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COMISION5", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICOMISION5"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICOMISION5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COMISION6", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICOMISION6"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICOMISION6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COMISION7", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICOMISION7"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICOMISION7;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREDITODEBITO", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICREDITODEBITO"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICREDITODEBITO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CRIPTOGRAMA", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICRIPTOGRAMA"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICRIPTOGRAMA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ECOUPNUMBER", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IECOUPNUMBER"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IECOUPNUMBER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FACTOREXP", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IFACTOREXP"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IFACTOREXP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FIRMAAUTOGRAFA", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAM.isnull["IFIRMAAUTOGRAFA"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IFIRMAAUTOGRAFA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FIRMAELECTRONICA", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAM.isnull["IFIRMAELECTRONICA"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IFIRMAELECTRONICA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FIRMAQPS", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAM.isnull["IFIRMAQPS"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IFIRMAQPS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@GUIA_CIE", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IGUIA_CIE"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IGUIA_CIE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDTOKEN12", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAM.isnull["IIDTOKEN12"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IIDTOKEN12;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDTOKEN13", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAM.isnull["IIDTOKEN13"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IIDTOKEN13;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDTOKEN16", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAM.isnull["IIDTOKEN16"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IIDTOKEN16;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDTOKENR7", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAM.isnull["IIDTOKENR7"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IIDTOKENR7;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDTOKENR8", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAM.isnull["IIDTOKENR8"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IIDTOKENR8;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPORTE_BENEFICIO", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IIMPORTE_BENEFICIO"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IIMPORTE_BENEFICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPORTE_UDIS", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IIMPORTE_UDIS"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IIMPORTE_UDIS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@INDICADOR_CAMBIO_PLAZO", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IINDICADOR_CAMBIO_PLAZO"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IINDICADOR_CAMBIO_PLAZO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@INDICADOR_DE_AVISO", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IINDICADOR_DE_AVISO"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IINDICADOR_DE_AVISO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@INDICAODR_DE_BENEFICIO", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IINDICAODR_DE_BENEFICIO"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IINDICAODR_DE_BENEFICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ISFOLIO", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IISFOLIO"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IISFOLIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ISOFFLINE", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAM.isnull["IISOFFLINE"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IISOFFLINE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LEYENDA", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ILEYENDA"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ILEYENDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MACADDALTERNATIVA", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMACADDALTERNATIVA"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMACADDALTERNATIVA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MENSAJE_BASE_CHEQUE", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMENSAJE_BASE_CHEQUE"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMENSAJE_BASE_CHEQUE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MENSAJE_BASE_CONTINUOS", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMENSAJE_BASE_CONTINUOS"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMENSAJE_BASE_CONTINUOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MENSAJE_CLIENTE", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMENSAJE_CLIENTE"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMENSAJE_CLIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MENSAJE_CLIENTE_EMISRO", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMENSAJE_CLIENTE_EMISRO"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMENSAJE_CLIENTE_EMISRO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MENSAJE_COMERCIO", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMENSAJE_COMERCIO"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMENSAJE_COMERCIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODOINGRESO", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMODOINGRESO"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMODOINGRESO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO_BENEFICIO_MULTIPLE1", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMONTO_BENEFICIO_MULTIPLE1"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMONTO_BENEFICIO_MULTIPLE1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO_BENEFICIO_SIMPLE1", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMONTO_BENEFICIO_SIMPLE1"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMONTO_BENEFICIO_SIMPLE1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO_CHEQUE_ACTUAL", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMONTO_CHEQUE_ACTUAL"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMONTO_CHEQUE_ACTUAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO_CHEQUE_ANTERIOR", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMONTO_CHEQUE_ANTERIOR"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMONTO_CHEQUE_ANTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO_CHEQUE_REDIMIDOS", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMONTO_CHEQUE_REDIMIDOS"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMONTO_CHEQUE_REDIMIDOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO_CONTINUOS_ACTUAL", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMONTO_CONTINUOS_ACTUAL"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMONTO_CONTINUOS_ACTUAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO_CONTINUOS_ANTERIOR", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMONTO_CONTINUOS_ANTERIOR"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMONTO_CONTINUOS_ANTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO_CONTINUOS_REDIMIDOS", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMONTO_CONTINUOS_REDIMIDOS"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMONTO_CONTINUOS_REDIMIDOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO_MULTIPLE2", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMONTO_MULTIPLE2"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMONTO_MULTIPLE2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO_MULTIPLE3", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMONTO_MULTIPLE3"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMONTO_MULTIPLE3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO_MULTIPLE4", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMONTO_MULTIPLE4"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMONTO_MULTIPLE4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO_MULTIPLE5", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMONTO_MULTIPLE5"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMONTO_MULTIPLE5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO_MULTIPLE6", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMONTO_MULTIPLE6"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMONTO_MULTIPLE6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO_MULTIPLE7", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMONTO_MULTIPLE7"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMONTO_MULTIPLE7;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO_SIMPLE2", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMONTO_SIMPLE2"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMONTO_SIMPLE2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO_SIMPLE3", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMONTO_SIMPLE3"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMONTO_SIMPLE3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO_SIMPLE4", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMONTO_SIMPLE4"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMONTO_SIMPLE4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO_SIMPLE5", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMONTO_SIMPLE5"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMONTO_SIMPLE5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO_SIMPLE6", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMONTO_SIMPLE6"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMONTO_SIMPLE6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO_SIMPLE7", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMONTO_SIMPLE7"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMONTO_SIMPLE7;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOAUTORIZACION", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["INOAUTORIZACION"])
                {
                    auxPar.Value = oCBANCOMERPARAM.INOAUTORIZACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBREAPLICACION", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["INOMBREAPLICACION"])
                {
                    auxPar.Value = oCBANCOMERPARAM.INOMBREAPLICACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBRECLIENTE", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["INOMBRECLIENTE"])
                {
                    auxPar.Value = oCBANCOMERPARAM.INOMBRECLIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUMERO_DE_BENEFICIOS", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["INUMERO_DE_BENEFICIOS"])
                {
                    auxPar.Value = oCBANCOMERPARAM.INUMERO_DE_BENEFICIOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUMEROTARJETA", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["INUMEROTARJETA"])
                {
                    auxPar.Value = oCBANCOMERPARAM.INUMEROTARJETA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUMTARJETAII", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["INUMTARJETAII"])
                {
                    auxPar.Value = oCBANCOMERPARAM.INUMTARJETAII;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PAGOSMULTIPAGOSID", FbDbType.BigInt);
                if (!(bool)oCBANCOMERPARAM.isnull["IPAGOSMULTIPAGOSID"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IPAGOSMULTIPAGOSID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PESOSREDIMIDOS", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IPESOSREDIMIDOS"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IPESOSREDIMIDOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PESOSSALDOANTERIOR", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IPESOSSALDOANTERIOR"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IPESOSSALDOANTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PESOSSALDODISPONIBLE", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IPESOSSALDODISPONIBLE"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IPESOSSALDODISPONIBLE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PESOSSALDODISPONINLEEXP", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IPESOSSALDODISPONINLEEXP"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IPESOSSALDODISPONINLEEXP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PESOSSALDOREDIMIDOSEXP", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IPESOSSALDOREDIMIDOSEXP"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IPESOSSALDOREDIMIDOSEXP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PINPAD_USO", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAM.isnull["IPINPAD_USO"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IPINPAD_USO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@POOLADJUSTTYPE", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IPOOLADJUSTTYPE"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IPOOLADJUSTTYPE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@POOLID", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IPOOLID"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IPOOLID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@POOLNUMBER", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IPOOLNUMBER"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IPOOLNUMBER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@POOLUNITLABEL", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IPOOLUNITLABEL"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IPOOLUNITLABEL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PUNTOSID", FbDbType.BigInt);
                if (!(bool)oCBANCOMERPARAM.isnull["IPUNTOSID"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IPUNTOSID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PUNTOSREDIMIDOS", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IPUNTOSREDIMIDOS"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IPUNTOSREDIMIDOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PUNTOSSALDOANTERIOR", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IPUNTOSSALDOANTERIOR"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IPUNTOSSALDOANTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PUNTOSSALDODISPONIBLE", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IPUNTOSSALDODISPONIBLE"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IPUNTOSSALDODISPONIBLE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PUNTOSSALDODISPONIBLEEXP", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IPUNTOSSALDODISPONIBLEEXP"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IPUNTOSSALDODISPONIBLEEXP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PUNTOSSALDOREDIMIDOSEXP", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IPUNTOSSALDOREDIMIDOSEXP"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IPUNTOSSALDOREDIMIDOSEXP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@R8_CODIGO_LEYENDA", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IR8_CODIGO_LEYENDA"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IR8_CODIGO_LEYENDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@R8_LEYENDA", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IR8_LEYENDA"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IR8_LEYENDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RAZON_SOCIAL", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IRAZON_SOCIAL"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IRAZON_SOCIAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIA_RESPUESTA", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IREFERENCIA_RESPUESTA"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IREFERENCIA_RESPUESTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIAAFIN", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IREFERENCIAAFIN"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IREFERENCIAAFIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQUEST", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IREQUEST"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IREQUEST;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESPDLL", FbDbType.Integer);
                if (!(bool)oCBANCOMERPARAM.isnull["IRESPDLL"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IRESPDLL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESPONSE", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IRESPONSE"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IRESPONSE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SEGMENTNUMBER", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ISEGMENTNUMBER"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ISEGMENTNUMBER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TBINES", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ITBINES"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ITBINES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPO_BENEFICIO1", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ITIPO_BENEFICIO1"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ITIPO_BENEFICIO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPO_BENEFICIO2", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ITIPO_BENEFICIO2"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ITIPO_BENEFICIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPO_BENEFICIO3", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ITIPO_BENEFICIO3"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ITIPO_BENEFICIO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPO_BENEFICIO4", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ITIPO_BENEFICIO4"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ITIPO_BENEFICIO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPO_BENEFICIO5", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ITIPO_BENEFICIO5"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ITIPO_BENEFICIO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPO_BENEFICIO6", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ITIPO_BENEFICIO6"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ITIPO_BENEFICIO6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPO_BENEFICIO7", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ITIPO_BENEFICIO7"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ITIPO_BENEFICIO7;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPO_RESPUESTA1", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ITIPO_RESPUESTA1"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ITIPO_RESPUESTA1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPO_RESPUESTA2", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ITIPO_RESPUESTA2"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ITIPO_RESPUESTA2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPO_RESPUESTA3", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ITIPO_RESPUESTA3"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ITIPO_RESPUESTA3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPO_RESPUESTA4", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ITIPO_RESPUESTA4"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ITIPO_RESPUESTA4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPO_RESPUESTA5", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ITIPO_RESPUESTA5"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ITIPO_RESPUESTA5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPO_RESPUESTA6", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ITIPO_RESPUESTA6"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ITIPO_RESPUESTA6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPO_RESPUESTA7", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ITIPO_RESPUESTA7"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ITIPO_RESPUESTA7;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOPOS", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ITIPOPOS"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ITIPOPOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TNXCONPUNTOS", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAM.isnull["ITNXCONPUNTOS"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ITNXCONPUNTOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TOPERADOR", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ITOPERADOR"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ITOPERADOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VALTIPOCARD", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IVALTIPOCARD"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IVALTIPOCARD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VIGENCIAPROMOCIONESEXP", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IVIGENCIAPROMOCIONESEXP"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IVIGENCIAPROMOCIONESEXP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if (!(bool)oCBANCOMERPARAM.isnull["IDOCTOID"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@DOCTOPAGOID", FbDbType.BigInt);
                if (!(bool)oCBANCOMERPARAM.isnull["IDOCTOPAGOID"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IDOCTOPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOTRANSACCION", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ITIPOTRANSACCION"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ITIPOTRANSACCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTADOTRANSACCIONID", FbDbType.BigInt);
                if (!(bool)oCBANCOMERPARAM.isnull["IESTADOTRANSACCIONID"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IESTADOTRANSACCIONID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@REFID", FbDbType.BigInt);
                if (!(bool)oCBANCOMERPARAM.isnull["IREFID"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IREFID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO BANCOMERPARAM
      (
    
ID,

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

AID,

AMEX,

BANCOMER,

BITCAMPANAS,

CAMPANAAUTORIZACION,

CAMPANAREFERENCIA,

CAMPANAREFERENCIANUM,

CARDREQUEST,

CARDTIPO,

PROMOCIONES,

CLIENTE_CMP_COMERCIO,

CLIENTE_TDC_STOCK,

CLSREQUESTID,

CLSRESPONSEID,

CODIGO_BENEFICIO1,

CODIGO_BENEFICIO2,

CODIGO_BENEFICIO3,

CODIGO_BENEFICIO4,

CODIGO_BENEFICIO5,

CODIGO_BENEFICIO6,

CODIGO_BENEFICIO7,

COMERCIO_CMP_COMERCIO,

COMERCIO_TDC_STOCK,

COMISION1,

COMISION2,

COMISION3,

COMISION4,

COMISION5,

COMISION6,

COMISION7,

CREDITODEBITO,

CRIPTOGRAMA,

ECOUPNUMBER,

FACTOREXP,

FIRMAAUTOGRAFA,

FIRMAELECTRONICA,

FIRMAQPS,

GUIA_CIE,

IDTOKEN12,

IDTOKEN13,

IDTOKEN16,

IDTOKENR7,

IDTOKENR8,

IMPORTE_BENEFICIO,

IMPORTE_UDIS,

INDICADOR_CAMBIO_PLAZO,

INDICADOR_DE_AVISO,

INDICAODR_DE_BENEFICIO,

ISFOLIO,

ISOFFLINE,

LEYENDA,

MACADDALTERNATIVA,

MENSAJE_BASE_CHEQUE,

MENSAJE_BASE_CONTINUOS,

MENSAJE_CLIENTE,

MENSAJE_CLIENTE_EMISRO,

MENSAJE_COMERCIO,

MODOINGRESO,

MONTO_BENEFICIO_MULTIPLE1,

MONTO_BENEFICIO_SIMPLE1,

MONTO_CHEQUE_ACTUAL,

MONTO_CHEQUE_ANTERIOR,

MONTO_CHEQUE_REDIMIDOS,

MONTO_CONTINUOS_ACTUAL,

MONTO_CONTINUOS_ANTERIOR,

MONTO_CONTINUOS_REDIMIDOS,

MONTO_MULTIPLE2,

MONTO_MULTIPLE3,

MONTO_MULTIPLE4,

MONTO_MULTIPLE5,

MONTO_MULTIPLE6,

MONTO_MULTIPLE7,

MONTO_SIMPLE2,

MONTO_SIMPLE3,

MONTO_SIMPLE4,

MONTO_SIMPLE5,

MONTO_SIMPLE6,

MONTO_SIMPLE7,

NOAUTORIZACION,

NOMBREAPLICACION,

NOMBRECLIENTE,

NUMERO_DE_BENEFICIOS,

NUMEROTARJETA,

NUMTARJETAII,

PAGOSMULTIPAGOSID,

PESOSREDIMIDOS,

PESOSSALDOANTERIOR,

PESOSSALDODISPONIBLE,

PESOSSALDODISPONINLEEXP,

PESOSSALDOREDIMIDOSEXP,

PINPAD_USO,

POOLADJUSTTYPE,

POOLID,

POOLNUMBER,

POOLUNITLABEL,

PUNTOSID,

PUNTOSREDIMIDOS,

PUNTOSSALDOANTERIOR,

PUNTOSSALDODISPONIBLE,

PUNTOSSALDODISPONIBLEEXP,

PUNTOSSALDOREDIMIDOSEXP,

R8_CODIGO_LEYENDA,

R8_LEYENDA,

RAZON_SOCIAL,

REFERENCIA_RESPUESTA,

REFERENCIAAFIN,

REQUEST,

RESPDLL,

RESPONSE,

SEGMENTNUMBER,

TBINES,

TIPO_BENEFICIO1,

TIPO_BENEFICIO2,

TIPO_BENEFICIO3,

TIPO_BENEFICIO4,

TIPO_BENEFICIO5,

TIPO_BENEFICIO6,

TIPO_BENEFICIO7,

TIPO_RESPUESTA1,

TIPO_RESPUESTA2,

TIPO_RESPUESTA3,

TIPO_RESPUESTA4,

TIPO_RESPUESTA5,

TIPO_RESPUESTA6,

TIPO_RESPUESTA7,

TIPOPOS,

TNXCONPUNTOS,

TOPERADOR,

VALTIPOCARD,

VIGENCIAPROMOCIONESEXP,

DOCTOID,

DOCTOPAGOID,

TIPOTRANSACCION,

ESTADOTRANSACCIONID,

REFID

         )

Values (

@ID,

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@AID,

@AMEX,

@BANCOMER,

@BITCAMPANAS,

@CAMPANAAUTORIZACION,

@CAMPANAREFERENCIA,

@CAMPANAREFERENCIANUM,

@CARDREQUEST,

@CARDTIPO,

@PROMOCIONES,

@CLIENTE_CMP_COMERCIO,

@CLIENTE_TDC_STOCK,

@CLSREQUESTID,

@CLSRESPONSEID,

@CODIGO_BENEFICIO1,

@CODIGO_BENEFICIO2,

@CODIGO_BENEFICIO3,

@CODIGO_BENEFICIO4,

@CODIGO_BENEFICIO5,

@CODIGO_BENEFICIO6,

@CODIGO_BENEFICIO7,

@COMERCIO_CMP_COMERCIO,

@COMERCIO_TDC_STOCK,

@COMISION1,

@COMISION2,

@COMISION3,

@COMISION4,

@COMISION5,

@COMISION6,

@COMISION7,

@CREDITODEBITO,

@CRIPTOGRAMA,

@ECOUPNUMBER,

@FACTOREXP,

@FIRMAAUTOGRAFA,

@FIRMAELECTRONICA,

@FIRMAQPS,

@GUIA_CIE,

@IDTOKEN12,

@IDTOKEN13,

@IDTOKEN16,

@IDTOKENR7,

@IDTOKENR8,

@IMPORTE_BENEFICIO,

@IMPORTE_UDIS,

@INDICADOR_CAMBIO_PLAZO,

@INDICADOR_DE_AVISO,

@INDICAODR_DE_BENEFICIO,

@ISFOLIO,

@ISOFFLINE,

@LEYENDA,

@MACADDALTERNATIVA,

@MENSAJE_BASE_CHEQUE,

@MENSAJE_BASE_CONTINUOS,

@MENSAJE_CLIENTE,

@MENSAJE_CLIENTE_EMISRO,

@MENSAJE_COMERCIO,

@MODOINGRESO,

@MONTO_BENEFICIO_MULTIPLE1,

@MONTO_BENEFICIO_SIMPLE1,

@MONTO_CHEQUE_ACTUAL,

@MONTO_CHEQUE_ANTERIOR,

@MONTO_CHEQUE_REDIMIDOS,

@MONTO_CONTINUOS_ACTUAL,

@MONTO_CONTINUOS_ANTERIOR,

@MONTO_CONTINUOS_REDIMIDOS,

@MONTO_MULTIPLE2,

@MONTO_MULTIPLE3,

@MONTO_MULTIPLE4,

@MONTO_MULTIPLE5,

@MONTO_MULTIPLE6,

@MONTO_MULTIPLE7,

@MONTO_SIMPLE2,

@MONTO_SIMPLE3,

@MONTO_SIMPLE4,

@MONTO_SIMPLE5,

@MONTO_SIMPLE6,

@MONTO_SIMPLE7,

@NOAUTORIZACION,

@NOMBREAPLICACION,

@NOMBRECLIENTE,

@NUMERO_DE_BENEFICIOS,

@NUMEROTARJETA,

@NUMTARJETAII,

@PAGOSMULTIPAGOSID,

@PESOSREDIMIDOS,

@PESOSSALDOANTERIOR,

@PESOSSALDODISPONIBLE,

@PESOSSALDODISPONINLEEXP,

@PESOSSALDOREDIMIDOSEXP,

@PINPAD_USO,

@POOLADJUSTTYPE,

@POOLID,

@POOLNUMBER,

@POOLUNITLABEL,

@PUNTOSID,

@PUNTOSREDIMIDOS,

@PUNTOSSALDOANTERIOR,

@PUNTOSSALDODISPONIBLE,

@PUNTOSSALDODISPONIBLEEXP,

@PUNTOSSALDOREDIMIDOSEXP,

@R8_CODIGO_LEYENDA,

@R8_LEYENDA,

@RAZON_SOCIAL,

@REFERENCIA_RESPUESTA,

@REFERENCIAAFIN,

@REQUEST,

@RESPDLL,

@RESPONSE,

@SEGMENTNUMBER,

@TBINES,

@TIPO_BENEFICIO1,

@TIPO_BENEFICIO2,

@TIPO_BENEFICIO3,

@TIPO_BENEFICIO4,

@TIPO_BENEFICIO5,

@TIPO_BENEFICIO6,

@TIPO_BENEFICIO7,

@TIPO_RESPUESTA1,

@TIPO_RESPUESTA2,

@TIPO_RESPUESTA3,

@TIPO_RESPUESTA4,

@TIPO_RESPUESTA5,

@TIPO_RESPUESTA6,

@TIPO_RESPUESTA7,

@TIPOPOS,

@TNXCONPUNTOS,

@TOPERADOR,

@VALTIPOCARD,

@VIGENCIAPROMOCIONESEXP,

@DOCTOID,

@DOCTOPAGOID,

@TIPOTRANSACCION,

@ESTADOTRANSACCIONID,

@REFID
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCBANCOMERPARAM;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        
        public bool BorrarBANCOMERPARAMD(CBANCOMERPARAMBE oCBANCOMERPARAM, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCBANCOMERPARAM.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from BANCOMERPARAM
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


        
        public bool CambiarBANCOMERPARAMD(CBANCOMERPARAMBE oCBANCOMERPARAMNuevo, CBANCOMERPARAMBE oCBANCOMERPARAMAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IID"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@AID", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IAID"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@AMEX", FbDbType.SmallInt);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IAMEX"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IAMEX;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@BANCOMER", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IBANCOMER"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IBANCOMER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@BITCAMPANAS", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IBITCAMPANAS"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IBITCAMPANAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPANAAUTORIZACION", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ICAMPANAAUTORIZACION"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ICAMPANAAUTORIZACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPANAREFERENCIA", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ICAMPANAREFERENCIA"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ICAMPANAREFERENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMPANAREFERENCIANUM", FbDbType.BigInt);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ICAMPANAREFERENCIANUM"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ICAMPANAREFERENCIANUM;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CARDREQUEST", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ICARDREQUEST"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ICARDREQUEST;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CARDTIPO", FbDbType.Integer);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ICARDTIPO"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ICARDTIPO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PROMOCIONES", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IPROMOCIONES"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IPROMOCIONES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLIENTE_CMP_COMERCIO", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ICLIENTE_CMP_COMERCIO"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ICLIENTE_CMP_COMERCIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLIENTE_TDC_STOCK", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ICLIENTE_TDC_STOCK"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ICLIENTE_TDC_STOCK;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLSREQUESTID", FbDbType.BigInt);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ICLSREQUESTID"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ICLSREQUESTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLSRESPONSEID", FbDbType.BigInt);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ICLSRESPONSEID"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ICLSRESPONSEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CODIGO_BENEFICIO1", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ICODIGO_BENEFICIO1"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ICODIGO_BENEFICIO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CODIGO_BENEFICIO2", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ICODIGO_BENEFICIO2"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ICODIGO_BENEFICIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CODIGO_BENEFICIO3", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ICODIGO_BENEFICIO3"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ICODIGO_BENEFICIO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CODIGO_BENEFICIO4", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ICODIGO_BENEFICIO4"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ICODIGO_BENEFICIO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CODIGO_BENEFICIO5", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ICODIGO_BENEFICIO5"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ICODIGO_BENEFICIO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CODIGO_BENEFICIO6", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ICODIGO_BENEFICIO6"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ICODIGO_BENEFICIO6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CODIGO_BENEFICIO7", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ICODIGO_BENEFICIO7"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ICODIGO_BENEFICIO7;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@COMERCIO_CMP_COMERCIO", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ICOMERCIO_CMP_COMERCIO"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ICOMERCIO_CMP_COMERCIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@COMERCIO_TDC_STOCK", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ICOMERCIO_TDC_STOCK"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ICOMERCIO_TDC_STOCK;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@COMISION1", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ICOMISION1"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ICOMISION1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@COMISION2", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ICOMISION2"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ICOMISION2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@COMISION3", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ICOMISION3"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ICOMISION3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@COMISION4", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ICOMISION4"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ICOMISION4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@COMISION5", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ICOMISION5"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ICOMISION5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@COMISION6", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ICOMISION6"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ICOMISION6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@COMISION7", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ICOMISION7"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ICOMISION7;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREDITODEBITO", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ICREDITODEBITO"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ICREDITODEBITO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CRIPTOGRAMA", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ICRIPTOGRAMA"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ICRIPTOGRAMA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ECOUPNUMBER", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IECOUPNUMBER"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IECOUPNUMBER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FACTOREXP", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IFACTOREXP"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IFACTOREXP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FIRMAAUTOGRAFA", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IFIRMAAUTOGRAFA"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IFIRMAAUTOGRAFA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FIRMAELECTRONICA", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IFIRMAELECTRONICA"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IFIRMAELECTRONICA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FIRMAQPS", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IFIRMAQPS"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IFIRMAQPS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@GUIA_CIE", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IGUIA_CIE"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IGUIA_CIE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDTOKEN12", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IIDTOKEN12"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IIDTOKEN12;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDTOKEN13", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IIDTOKEN13"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IIDTOKEN13;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDTOKEN16", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IIDTOKEN16"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IIDTOKEN16;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDTOKENR7", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IIDTOKENR7"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IIDTOKENR7;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDTOKENR8", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IIDTOKENR8"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IIDTOKENR8;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IMPORTE_BENEFICIO", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IIMPORTE_BENEFICIO"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IIMPORTE_BENEFICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IMPORTE_UDIS", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IIMPORTE_UDIS"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IIMPORTE_UDIS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@INDICADOR_CAMBIO_PLAZO", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IINDICADOR_CAMBIO_PLAZO"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IINDICADOR_CAMBIO_PLAZO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@INDICADOR_DE_AVISO", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IINDICADOR_DE_AVISO"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IINDICADOR_DE_AVISO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@INDICAODR_DE_BENEFICIO", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IINDICAODR_DE_BENEFICIO"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IINDICAODR_DE_BENEFICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ISFOLIO", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IISFOLIO"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IISFOLIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ISOFFLINE", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IISOFFLINE"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IISOFFLINE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LEYENDA", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ILEYENDA"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ILEYENDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MACADDALTERNATIVA", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IMACADDALTERNATIVA"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IMACADDALTERNATIVA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MENSAJE_BASE_CHEQUE", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IMENSAJE_BASE_CHEQUE"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IMENSAJE_BASE_CHEQUE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MENSAJE_BASE_CONTINUOS", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IMENSAJE_BASE_CONTINUOS"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IMENSAJE_BASE_CONTINUOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MENSAJE_CLIENTE", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IMENSAJE_CLIENTE"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IMENSAJE_CLIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MENSAJE_CLIENTE_EMISRO", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IMENSAJE_CLIENTE_EMISRO"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IMENSAJE_CLIENTE_EMISRO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MENSAJE_COMERCIO", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IMENSAJE_COMERCIO"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IMENSAJE_COMERCIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODOINGRESO", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IMODOINGRESO"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IMODOINGRESO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONTO_BENEFICIO_MULTIPLE1", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IMONTO_BENEFICIO_MULTIPLE1"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IMONTO_BENEFICIO_MULTIPLE1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONTO_BENEFICIO_SIMPLE1", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IMONTO_BENEFICIO_SIMPLE1"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IMONTO_BENEFICIO_SIMPLE1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONTO_CHEQUE_ACTUAL", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IMONTO_CHEQUE_ACTUAL"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IMONTO_CHEQUE_ACTUAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONTO_CHEQUE_ANTERIOR", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IMONTO_CHEQUE_ANTERIOR"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IMONTO_CHEQUE_ANTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONTO_CHEQUE_REDIMIDOS", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IMONTO_CHEQUE_REDIMIDOS"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IMONTO_CHEQUE_REDIMIDOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONTO_CONTINUOS_ACTUAL", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IMONTO_CONTINUOS_ACTUAL"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IMONTO_CONTINUOS_ACTUAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONTO_CONTINUOS_ANTERIOR", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IMONTO_CONTINUOS_ANTERIOR"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IMONTO_CONTINUOS_ANTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONTO_CONTINUOS_REDIMIDOS", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IMONTO_CONTINUOS_REDIMIDOS"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IMONTO_CONTINUOS_REDIMIDOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONTO_MULTIPLE2", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IMONTO_MULTIPLE2"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IMONTO_MULTIPLE2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONTO_MULTIPLE3", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IMONTO_MULTIPLE3"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IMONTO_MULTIPLE3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONTO_MULTIPLE4", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IMONTO_MULTIPLE4"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IMONTO_MULTIPLE4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONTO_MULTIPLE5", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IMONTO_MULTIPLE5"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IMONTO_MULTIPLE5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONTO_MULTIPLE6", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IMONTO_MULTIPLE6"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IMONTO_MULTIPLE6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONTO_MULTIPLE7", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IMONTO_MULTIPLE7"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IMONTO_MULTIPLE7;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONTO_SIMPLE2", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IMONTO_SIMPLE2"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IMONTO_SIMPLE2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONTO_SIMPLE3", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IMONTO_SIMPLE3"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IMONTO_SIMPLE3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONTO_SIMPLE4", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IMONTO_SIMPLE4"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IMONTO_SIMPLE4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONTO_SIMPLE5", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IMONTO_SIMPLE5"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IMONTO_SIMPLE5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONTO_SIMPLE6", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IMONTO_SIMPLE6"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IMONTO_SIMPLE6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONTO_SIMPLE7", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IMONTO_SIMPLE7"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IMONTO_SIMPLE7;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOAUTORIZACION", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["INOAUTORIZACION"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.INOAUTORIZACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMBREAPLICACION", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["INOMBREAPLICACION"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.INOMBREAPLICACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMBRECLIENTE", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["INOMBRECLIENTE"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.INOMBRECLIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMERO_DE_BENEFICIOS", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["INUMERO_DE_BENEFICIOS"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.INUMERO_DE_BENEFICIOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMEROTARJETA", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["INUMEROTARJETA"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.INUMEROTARJETA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMTARJETAII", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["INUMTARJETAII"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.INUMTARJETAII;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PAGOSMULTIPAGOSID", FbDbType.BigInt);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IPAGOSMULTIPAGOSID"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IPAGOSMULTIPAGOSID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PESOSREDIMIDOS", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IPESOSREDIMIDOS"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IPESOSREDIMIDOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PESOSSALDOANTERIOR", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IPESOSSALDOANTERIOR"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IPESOSSALDOANTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PESOSSALDODISPONIBLE", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IPESOSSALDODISPONIBLE"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IPESOSSALDODISPONIBLE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PESOSSALDODISPONINLEEXP", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IPESOSSALDODISPONINLEEXP"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IPESOSSALDODISPONINLEEXP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PESOSSALDOREDIMIDOSEXP", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IPESOSSALDOREDIMIDOSEXP"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IPESOSSALDOREDIMIDOSEXP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PINPAD_USO", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IPINPAD_USO"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IPINPAD_USO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@POOLADJUSTTYPE", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IPOOLADJUSTTYPE"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IPOOLADJUSTTYPE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@POOLID", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IPOOLID"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IPOOLID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@POOLNUMBER", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IPOOLNUMBER"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IPOOLNUMBER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@POOLUNITLABEL", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IPOOLUNITLABEL"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IPOOLUNITLABEL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PUNTOSID", FbDbType.BigInt);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IPUNTOSID"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IPUNTOSID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PUNTOSREDIMIDOS", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IPUNTOSREDIMIDOS"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IPUNTOSREDIMIDOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PUNTOSSALDOANTERIOR", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IPUNTOSSALDOANTERIOR"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IPUNTOSSALDOANTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PUNTOSSALDODISPONIBLE", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IPUNTOSSALDODISPONIBLE"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IPUNTOSSALDODISPONIBLE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PUNTOSSALDODISPONIBLEEXP", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IPUNTOSSALDODISPONIBLEEXP"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IPUNTOSSALDODISPONIBLEEXP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PUNTOSSALDOREDIMIDOSEXP", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IPUNTOSSALDOREDIMIDOSEXP"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IPUNTOSSALDOREDIMIDOSEXP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@R8_CODIGO_LEYENDA", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IR8_CODIGO_LEYENDA"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IR8_CODIGO_LEYENDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@R8_LEYENDA", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IR8_LEYENDA"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IR8_LEYENDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@RAZON_SOCIAL", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IRAZON_SOCIAL"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IRAZON_SOCIAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@REFERENCIA_RESPUESTA", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IREFERENCIA_RESPUESTA"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IREFERENCIA_RESPUESTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@REFERENCIAAFIN", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IREFERENCIAAFIN"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IREFERENCIAAFIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@REQUEST", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IREQUEST"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IREQUEST;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@RESPDLL", FbDbType.Integer);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IRESPDLL"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IRESPDLL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@RESPONSE", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IRESPONSE"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IRESPONSE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SEGMENTNUMBER", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ISEGMENTNUMBER"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ISEGMENTNUMBER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TBINES", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ITBINES"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ITBINES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPO_BENEFICIO1", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ITIPO_BENEFICIO1"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ITIPO_BENEFICIO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPO_BENEFICIO2", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ITIPO_BENEFICIO2"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ITIPO_BENEFICIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPO_BENEFICIO3", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ITIPO_BENEFICIO3"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ITIPO_BENEFICIO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPO_BENEFICIO4", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ITIPO_BENEFICIO4"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ITIPO_BENEFICIO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPO_BENEFICIO5", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ITIPO_BENEFICIO5"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ITIPO_BENEFICIO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPO_BENEFICIO6", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ITIPO_BENEFICIO6"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ITIPO_BENEFICIO6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPO_BENEFICIO7", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ITIPO_BENEFICIO7"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ITIPO_BENEFICIO7;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPO_RESPUESTA1", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ITIPO_RESPUESTA1"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ITIPO_RESPUESTA1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPO_RESPUESTA2", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ITIPO_RESPUESTA2"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ITIPO_RESPUESTA2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPO_RESPUESTA3", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ITIPO_RESPUESTA3"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ITIPO_RESPUESTA3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPO_RESPUESTA4", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ITIPO_RESPUESTA4"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ITIPO_RESPUESTA4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPO_RESPUESTA5", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ITIPO_RESPUESTA5"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ITIPO_RESPUESTA5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPO_RESPUESTA6", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ITIPO_RESPUESTA6"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ITIPO_RESPUESTA6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPO_RESPUESTA7", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ITIPO_RESPUESTA7"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ITIPO_RESPUESTA7;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPOPOS", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ITIPOPOS"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ITIPOPOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TNXCONPUNTOS", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ITNXCONPUNTOS"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ITNXCONPUNTOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TOPERADOR", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ITOPERADOR"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ITOPERADOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@VALTIPOCARD", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IVALTIPOCARD"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IVALTIPOCARD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@VIGENCIAPROMOCIONESEXP", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IVIGENCIAPROMOCIONESEXP"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IVIGENCIAPROMOCIONESEXP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);





                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IDOCTOID"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@DOCTOPAGOID", FbDbType.BigInt);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IDOCTOPAGOID"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IDOCTOPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOTRANSACCION", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["ITIPOTRANSACCION"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.ITIPOTRANSACCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@ESTADOTRANSACCIONID", FbDbType.BigInt);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IESTADOTRANSACCIONID"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IESTADOTRANSACCIONID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFID", FbDbType.BigInt);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IREFID"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IREFID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCBANCOMERPARAMAnterior.isnull["IID"])
                {
                    auxPar.Value = oCBANCOMERPARAMAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  BANCOMERPARAM
  set

ID=@ID,

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

AID=@AID,

AMEX=@AMEX,

BANCOMER=@BANCOMER,

BITCAMPANAS=@BITCAMPANAS,

CAMPANAAUTORIZACION=@CAMPANAAUTORIZACION,

CAMPANAREFERENCIA=@CAMPANAREFERENCIA,

CAMPANAREFERENCIANUM=@CAMPANAREFERENCIANUM,

CARDREQUEST=@CARDREQUEST,

CARDTIPO=@CARDTIPO,

PROMOCIONES=@PROMOCIONES,

CLIENTE_CMP_COMERCIO=@CLIENTE_CMP_COMERCIO,

CLIENTE_TDC_STOCK=@CLIENTE_TDC_STOCK,

CLSREQUESTID=@CLSREQUESTID,

CLSRESPONSEID=@CLSRESPONSEID,

CODIGO_BENEFICIO1=@CODIGO_BENEFICIO1,

CODIGO_BENEFICIO2=@CODIGO_BENEFICIO2,

CODIGO_BENEFICIO3=@CODIGO_BENEFICIO3,

CODIGO_BENEFICIO4=@CODIGO_BENEFICIO4,

CODIGO_BENEFICIO5=@CODIGO_BENEFICIO5,

CODIGO_BENEFICIO6=@CODIGO_BENEFICIO6,

CODIGO_BENEFICIO7=@CODIGO_BENEFICIO7,

COMERCIO_CMP_COMERCIO=@COMERCIO_CMP_COMERCIO,

COMERCIO_TDC_STOCK=@COMERCIO_TDC_STOCK,

COMISION1=@COMISION1,

COMISION2=@COMISION2,

COMISION3=@COMISION3,

COMISION4=@COMISION4,

COMISION5=@COMISION5,

COMISION6=@COMISION6,

COMISION7=@COMISION7,

CREDITODEBITO=@CREDITODEBITO,

CRIPTOGRAMA=@CRIPTOGRAMA,

ECOUPNUMBER=@ECOUPNUMBER,

FACTOREXP=@FACTOREXP,

FIRMAAUTOGRAFA=@FIRMAAUTOGRAFA,

FIRMAELECTRONICA=@FIRMAELECTRONICA,

FIRMAQPS=@FIRMAQPS,

GUIA_CIE=@GUIA_CIE,

IDTOKEN12=@IDTOKEN12,

IDTOKEN13=@IDTOKEN13,

IDTOKEN16=@IDTOKEN16,

IDTOKENR7=@IDTOKENR7,

IDTOKENR8=@IDTOKENR8,

IMPORTE_BENEFICIO=@IMPORTE_BENEFICIO,

IMPORTE_UDIS=@IMPORTE_UDIS,

INDICADOR_CAMBIO_PLAZO=@INDICADOR_CAMBIO_PLAZO,

INDICADOR_DE_AVISO=@INDICADOR_DE_AVISO,

INDICAODR_DE_BENEFICIO=@INDICAODR_DE_BENEFICIO,

ISFOLIO=@ISFOLIO,

ISOFFLINE=@ISOFFLINE,

LEYENDA=@LEYENDA,

MACADDALTERNATIVA=@MACADDALTERNATIVA,

MENSAJE_BASE_CHEQUE=@MENSAJE_BASE_CHEQUE,

MENSAJE_BASE_CONTINUOS=@MENSAJE_BASE_CONTINUOS,

MENSAJE_CLIENTE=@MENSAJE_CLIENTE,

MENSAJE_CLIENTE_EMISRO=@MENSAJE_CLIENTE_EMISRO,

MENSAJE_COMERCIO=@MENSAJE_COMERCIO,

MODOINGRESO=@MODOINGRESO,

MONTO_BENEFICIO_MULTIPLE1=@MONTO_BENEFICIO_MULTIPLE1,

MONTO_BENEFICIO_SIMPLE1=@MONTO_BENEFICIO_SIMPLE1,

MONTO_CHEQUE_ACTUAL=@MONTO_CHEQUE_ACTUAL,

MONTO_CHEQUE_ANTERIOR=@MONTO_CHEQUE_ANTERIOR,

MONTO_CHEQUE_REDIMIDOS=@MONTO_CHEQUE_REDIMIDOS,

MONTO_CONTINUOS_ACTUAL=@MONTO_CONTINUOS_ACTUAL,

MONTO_CONTINUOS_ANTERIOR=@MONTO_CONTINUOS_ANTERIOR,

MONTO_CONTINUOS_REDIMIDOS=@MONTO_CONTINUOS_REDIMIDOS,

MONTO_MULTIPLE2=@MONTO_MULTIPLE2,

MONTO_MULTIPLE3=@MONTO_MULTIPLE3,

MONTO_MULTIPLE4=@MONTO_MULTIPLE4,

MONTO_MULTIPLE5=@MONTO_MULTIPLE5,

MONTO_MULTIPLE6=@MONTO_MULTIPLE6,

MONTO_MULTIPLE7=@MONTO_MULTIPLE7,

MONTO_SIMPLE2=@MONTO_SIMPLE2,

MONTO_SIMPLE3=@MONTO_SIMPLE3,

MONTO_SIMPLE4=@MONTO_SIMPLE4,

MONTO_SIMPLE5=@MONTO_SIMPLE5,

MONTO_SIMPLE6=@MONTO_SIMPLE6,

MONTO_SIMPLE7=@MONTO_SIMPLE7,

NOAUTORIZACION=@NOAUTORIZACION,

NOMBREAPLICACION=@NOMBREAPLICACION,

NOMBRECLIENTE=@NOMBRECLIENTE,

NUMERO_DE_BENEFICIOS=@NUMERO_DE_BENEFICIOS,

NUMEROTARJETA=@NUMEROTARJETA,

NUMTARJETAII=@NUMTARJETAII,

PAGOSMULTIPAGOSID=@PAGOSMULTIPAGOSID,

PESOSREDIMIDOS=@PESOSREDIMIDOS,

PESOSSALDOANTERIOR=@PESOSSALDOANTERIOR,

PESOSSALDODISPONIBLE=@PESOSSALDODISPONIBLE,

PESOSSALDODISPONINLEEXP=@PESOSSALDODISPONINLEEXP,

PESOSSALDOREDIMIDOSEXP=@PESOSSALDOREDIMIDOSEXP,

PINPAD_USO=@PINPAD_USO,

POOLADJUSTTYPE=@POOLADJUSTTYPE,

POOLID=@POOLID,

POOLNUMBER=@POOLNUMBER,

POOLUNITLABEL=@POOLUNITLABEL,

PUNTOSID=@PUNTOSID,

PUNTOSREDIMIDOS=@PUNTOSREDIMIDOS,

PUNTOSSALDOANTERIOR=@PUNTOSSALDOANTERIOR,

PUNTOSSALDODISPONIBLE=@PUNTOSSALDODISPONIBLE,

PUNTOSSALDODISPONIBLEEXP=@PUNTOSSALDODISPONIBLEEXP,

PUNTOSSALDOREDIMIDOSEXP=@PUNTOSSALDOREDIMIDOSEXP,

R8_CODIGO_LEYENDA=@R8_CODIGO_LEYENDA,

R8_LEYENDA=@R8_LEYENDA,

RAZON_SOCIAL=@RAZON_SOCIAL,

REFERENCIA_RESPUESTA=@REFERENCIA_RESPUESTA,

REFERENCIAAFIN=@REFERENCIAAFIN,

REQUEST=@REQUEST,

RESPDLL=@RESPDLL,

RESPONSE=@RESPONSE,

SEGMENTNUMBER=@SEGMENTNUMBER,

TBINES=@TBINES,

TIPO_BENEFICIO1=@TIPO_BENEFICIO1,

TIPO_BENEFICIO2=@TIPO_BENEFICIO2,

TIPO_BENEFICIO3=@TIPO_BENEFICIO3,

TIPO_BENEFICIO4=@TIPO_BENEFICIO4,

TIPO_BENEFICIO5=@TIPO_BENEFICIO5,

TIPO_BENEFICIO6=@TIPO_BENEFICIO6,

TIPO_BENEFICIO7=@TIPO_BENEFICIO7,

TIPO_RESPUESTA1=@TIPO_RESPUESTA1,

TIPO_RESPUESTA2=@TIPO_RESPUESTA2,

TIPO_RESPUESTA3=@TIPO_RESPUESTA3,

TIPO_RESPUESTA4=@TIPO_RESPUESTA4,

TIPO_RESPUESTA5=@TIPO_RESPUESTA5,

TIPO_RESPUESTA6=@TIPO_RESPUESTA6,

TIPO_RESPUESTA7=@TIPO_RESPUESTA7,

TIPOPOS=@TIPOPOS,

TNXCONPUNTOS=@TNXCONPUNTOS,

TOPERADOR=@TOPERADOR,

VALTIPOCARD=@VALTIPOCARD,

VIGENCIAPROMOCIONESEXP=@VIGENCIAPROMOCIONESEXP,

DOCTOID = @DOCTOID,

DOCTOPAGOID = @DOCTOPAGOID,

TIPOTRANSACCION = @TIPOTRANSACCION,

ESTADOTRANSACCIONID = @ESTADOTRANSACCIONID,

REFID = @REFID

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


        
        public CBANCOMERPARAMBE seleccionarBANCOMERPARAM(CBANCOMERPARAMBE oCBANCOMERPARAM, FbTransaction st)
        {




            CBANCOMERPARAMBE retorno = new CBANCOMERPARAMBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from BANCOMERPARAM where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCBANCOMERPARAM.IID;
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

                    if (dr["AID"] != System.DBNull.Value)
                    {
                        retorno.IAID = (string)(dr["AID"]);
                    }

                    if (dr["BANCOMER"] != System.DBNull.Value)
                    {
                        retorno.IBANCOMER = (string)(dr["BANCOMER"]);
                    }

                    if (dr["BITCAMPANAS"] != System.DBNull.Value)
                    {
                        retorno.IBITCAMPANAS = (string)(dr["BITCAMPANAS"]);
                    }

                    if (dr["CAMPANAAUTORIZACION"] != System.DBNull.Value)
                    {
                        retorno.ICAMPANAAUTORIZACION = (string)(dr["CAMPANAAUTORIZACION"]);
                    }

                    if (dr["CAMPANAREFERENCIA"] != System.DBNull.Value)
                    {
                        retorno.ICAMPANAREFERENCIA = (string)(dr["CAMPANAREFERENCIA"]);
                    }

                    if (dr["CAMPANAREFERENCIANUM"] != System.DBNull.Value)
                    {
                        retorno.ICAMPANAREFERENCIANUM = (long)(dr["CAMPANAREFERENCIANUM"]);
                    }

                    if (dr["CARDREQUEST"] != System.DBNull.Value)
                    {
                        retorno.ICARDREQUEST = (string)(dr["CARDREQUEST"]);
                    }

                    if (dr["PROMOCIONES"] != System.DBNull.Value)
                    {
                        retorno.IPROMOCIONES = (string)(dr["PROMOCIONES"]);
                    }

                    if (dr["CLIENTE_CMP_COMERCIO"] != System.DBNull.Value)
                    {
                        retorno.ICLIENTE_CMP_COMERCIO = (string)(dr["CLIENTE_CMP_COMERCIO"]);
                    }

                    if (dr["CLIENTE_TDC_STOCK"] != System.DBNull.Value)
                    {
                        retorno.ICLIENTE_TDC_STOCK = (string)(dr["CLIENTE_TDC_STOCK"]);
                    }

                    if (dr["CLSREQUESTID"] != System.DBNull.Value)
                    {
                        retorno.ICLSREQUESTID = (long)(dr["CLSREQUESTID"]);
                    }

                    if (dr["CLSRESPONSEID"] != System.DBNull.Value)
                    {
                        retorno.ICLSRESPONSEID = (long)(dr["CLSRESPONSEID"]);
                    }

                    if (dr["CODIGO_BENEFICIO1"] != System.DBNull.Value)
                    {
                        retorno.ICODIGO_BENEFICIO1 = (string)(dr["CODIGO_BENEFICIO1"]);
                    }

                    if (dr["CODIGO_BENEFICIO2"] != System.DBNull.Value)
                    {
                        retorno.ICODIGO_BENEFICIO2 = (string)(dr["CODIGO_BENEFICIO2"]);
                    }

                    if (dr["CODIGO_BENEFICIO3"] != System.DBNull.Value)
                    {
                        retorno.ICODIGO_BENEFICIO3 = (string)(dr["CODIGO_BENEFICIO3"]);
                    }

                    if (dr["CODIGO_BENEFICIO4"] != System.DBNull.Value)
                    {
                        retorno.ICODIGO_BENEFICIO4 = (string)(dr["CODIGO_BENEFICIO4"]);
                    }

                    if (dr["CODIGO_BENEFICIO5"] != System.DBNull.Value)
                    {
                        retorno.ICODIGO_BENEFICIO5 = (string)(dr["CODIGO_BENEFICIO5"]);
                    }

                    if (dr["CODIGO_BENEFICIO6"] != System.DBNull.Value)
                    {
                        retorno.ICODIGO_BENEFICIO6 = (string)(dr["CODIGO_BENEFICIO6"]);
                    }

                    if (dr["CODIGO_BENEFICIO7"] != System.DBNull.Value)
                    {
                        retorno.ICODIGO_BENEFICIO7 = (string)(dr["CODIGO_BENEFICIO7"]);
                    }

                    if (dr["COMERCIO_CMP_COMERCIO"] != System.DBNull.Value)
                    {
                        retorno.ICOMERCIO_CMP_COMERCIO = (string)(dr["COMERCIO_CMP_COMERCIO"]);
                    }

                    if (dr["COMERCIO_TDC_STOCK"] != System.DBNull.Value)
                    {
                        retorno.ICOMERCIO_TDC_STOCK = (string)(dr["COMERCIO_TDC_STOCK"]);
                    }

                    if (dr["COMISION1"] != System.DBNull.Value)
                    {
                        retorno.ICOMISION1 = (string)(dr["COMISION1"]);
                    }

                    if (dr["COMISION2"] != System.DBNull.Value)
                    {
                        retorno.ICOMISION2 = (string)(dr["COMISION2"]);
                    }

                    if (dr["COMISION3"] != System.DBNull.Value)
                    {
                        retorno.ICOMISION3 = (string)(dr["COMISION3"]);
                    }

                    if (dr["COMISION4"] != System.DBNull.Value)
                    {
                        retorno.ICOMISION4 = (string)(dr["COMISION4"]);
                    }

                    if (dr["COMISION5"] != System.DBNull.Value)
                    {
                        retorno.ICOMISION5 = (string)(dr["COMISION5"]);
                    }

                    if (dr["COMISION6"] != System.DBNull.Value)
                    {
                        retorno.ICOMISION6 = (string)(dr["COMISION6"]);
                    }

                    if (dr["COMISION7"] != System.DBNull.Value)
                    {
                        retorno.ICOMISION7 = (string)(dr["COMISION7"]);
                    }

                    if (dr["CREDITODEBITO"] != System.DBNull.Value)
                    {
                        retorno.ICREDITODEBITO = (string)(dr["CREDITODEBITO"]);
                    }

                    if (dr["CRIPTOGRAMA"] != System.DBNull.Value)
                    {
                        retorno.ICRIPTOGRAMA = (string)(dr["CRIPTOGRAMA"]);
                    }

                    if (dr["ECOUPNUMBER"] != System.DBNull.Value)
                    {
                        retorno.IECOUPNUMBER = (string)(dr["ECOUPNUMBER"]);
                    }

                    if (dr["FACTOREXP"] != System.DBNull.Value)
                    {
                        retorno.IFACTOREXP = (string)(dr["FACTOREXP"]);
                    }

                    if (dr["FIRMAAUTOGRAFA"] != System.DBNull.Value)
                    {
                        retorno.IFIRMAAUTOGRAFA = (string)(dr["FIRMAAUTOGRAFA"]);
                    }

                    if (dr["FIRMAELECTRONICA"] != System.DBNull.Value)
                    {
                        retorno.IFIRMAELECTRONICA = (string)(dr["FIRMAELECTRONICA"]);
                    }

                    if (dr["FIRMAQPS"] != System.DBNull.Value)
                    {
                        retorno.IFIRMAQPS = (string)(dr["FIRMAQPS"]);
                    }

                    if (dr["GUIA_CIE"] != System.DBNull.Value)
                    {
                        retorno.IGUIA_CIE = (string)(dr["GUIA_CIE"]);
                    }

                    if (dr["IDTOKEN12"] != System.DBNull.Value)
                    {
                        retorno.IIDTOKEN12 = (string)(dr["IDTOKEN12"]);
                    }

                    if (dr["IDTOKEN13"] != System.DBNull.Value)
                    {
                        retorno.IIDTOKEN13 = (string)(dr["IDTOKEN13"]);
                    }

                    if (dr["IDTOKEN16"] != System.DBNull.Value)
                    {
                        retorno.IIDTOKEN16 = (string)(dr["IDTOKEN16"]);
                    }

                    if (dr["IDTOKENR7"] != System.DBNull.Value)
                    {
                        retorno.IIDTOKENR7 = (string)(dr["IDTOKENR7"]);
                    }

                    if (dr["IDTOKENR8"] != System.DBNull.Value)
                    {
                        retorno.IIDTOKENR8 = (string)(dr["IDTOKENR8"]);
                    }

                    if (dr["IMPORTE_BENEFICIO"] != System.DBNull.Value)
                    {
                        retorno.IIMPORTE_BENEFICIO = (string)(dr["IMPORTE_BENEFICIO"]);
                    }

                    if (dr["IMPORTE_UDIS"] != System.DBNull.Value)
                    {
                        retorno.IIMPORTE_UDIS = (string)(dr["IMPORTE_UDIS"]);
                    }

                    if (dr["INDICADOR_CAMBIO_PLAZO"] != System.DBNull.Value)
                    {
                        retorno.IINDICADOR_CAMBIO_PLAZO = (string)(dr["INDICADOR_CAMBIO_PLAZO"]);
                    }

                    if (dr["INDICADOR_DE_AVISO"] != System.DBNull.Value)
                    {
                        retorno.IINDICADOR_DE_AVISO = (string)(dr["INDICADOR_DE_AVISO"]);
                    }

                    if (dr["INDICAODR_DE_BENEFICIO"] != System.DBNull.Value)
                    {
                        retorno.IINDICAODR_DE_BENEFICIO = (string)(dr["INDICAODR_DE_BENEFICIO"]);
                    }

                    if (dr["ISFOLIO"] != System.DBNull.Value)
                    {
                        retorno.IISFOLIO = (string)(dr["ISFOLIO"]);
                    }

                    if (dr["ISOFFLINE"] != System.DBNull.Value)
                    {
                        retorno.IISOFFLINE = (string)(dr["ISOFFLINE"]);
                    }

                    if (dr["LEYENDA"] != System.DBNull.Value)
                    {
                        retorno.ILEYENDA = (string)(dr["LEYENDA"]);
                    }

                    if (dr["MACADDALTERNATIVA"] != System.DBNull.Value)
                    {
                        retorno.IMACADDALTERNATIVA = (string)(dr["MACADDALTERNATIVA"]);
                    }

                    if (dr["MENSAJE_BASE_CHEQUE"] != System.DBNull.Value)
                    {
                        retorno.IMENSAJE_BASE_CHEQUE = (string)(dr["MENSAJE_BASE_CHEQUE"]);
                    }

                    if (dr["MENSAJE_BASE_CONTINUOS"] != System.DBNull.Value)
                    {
                        retorno.IMENSAJE_BASE_CONTINUOS = (string)(dr["MENSAJE_BASE_CONTINUOS"]);
                    }

                    if (dr["MENSAJE_CLIENTE"] != System.DBNull.Value)
                    {
                        retorno.IMENSAJE_CLIENTE = (string)(dr["MENSAJE_CLIENTE"]);
                    }

                    if (dr["MENSAJE_CLIENTE_EMISRO"] != System.DBNull.Value)
                    {
                        retorno.IMENSAJE_CLIENTE_EMISRO = (string)(dr["MENSAJE_CLIENTE_EMISRO"]);
                    }

                    if (dr["MENSAJE_COMERCIO"] != System.DBNull.Value)
                    {
                        retorno.IMENSAJE_COMERCIO = (string)(dr["MENSAJE_COMERCIO"]);
                    }

                    if (dr["MODOINGRESO"] != System.DBNull.Value)
                    {
                        retorno.IMODOINGRESO = (string)(dr["MODOINGRESO"]);
                    }

                    if (dr["MONTO_BENEFICIO_MULTIPLE1"] != System.DBNull.Value)
                    {
                        retorno.IMONTO_BENEFICIO_MULTIPLE1 = (string)(dr["MONTO_BENEFICIO_MULTIPLE1"]);
                    }

                    if (dr["MONTO_BENEFICIO_SIMPLE1"] != System.DBNull.Value)
                    {
                        retorno.IMONTO_BENEFICIO_SIMPLE1 = (string)(dr["MONTO_BENEFICIO_SIMPLE1"]);
                    }

                    if (dr["MONTO_CHEQUE_ACTUAL"] != System.DBNull.Value)
                    {
                        retorno.IMONTO_CHEQUE_ACTUAL = (string)(dr["MONTO_CHEQUE_ACTUAL"]);
                    }

                    if (dr["MONTO_CHEQUE_ANTERIOR"] != System.DBNull.Value)
                    {
                        retorno.IMONTO_CHEQUE_ANTERIOR = (string)(dr["MONTO_CHEQUE_ANTERIOR"]);
                    }

                    if (dr["MONTO_CHEQUE_REDIMIDOS"] != System.DBNull.Value)
                    {
                        retorno.IMONTO_CHEQUE_REDIMIDOS = (string)(dr["MONTO_CHEQUE_REDIMIDOS"]);
                    }

                    if (dr["MONTO_CONTINUOS_ACTUAL"] != System.DBNull.Value)
                    {
                        retorno.IMONTO_CONTINUOS_ACTUAL = (string)(dr["MONTO_CONTINUOS_ACTUAL"]);
                    }

                    if (dr["MONTO_CONTINUOS_ANTERIOR"] != System.DBNull.Value)
                    {
                        retorno.IMONTO_CONTINUOS_ANTERIOR = (string)(dr["MONTO_CONTINUOS_ANTERIOR"]);
                    }

                    if (dr["MONTO_CONTINUOS_REDIMIDOS"] != System.DBNull.Value)
                    {
                        retorno.IMONTO_CONTINUOS_REDIMIDOS = (string)(dr["MONTO_CONTINUOS_REDIMIDOS"]);
                    }

                    if (dr["MONTO_MULTIPLE2"] != System.DBNull.Value)
                    {
                        retorno.IMONTO_MULTIPLE2 = (string)(dr["MONTO_MULTIPLE2"]);
                    }

                    if (dr["MONTO_MULTIPLE3"] != System.DBNull.Value)
                    {
                        retorno.IMONTO_MULTIPLE3 = (string)(dr["MONTO_MULTIPLE3"]);
                    }

                    if (dr["MONTO_MULTIPLE4"] != System.DBNull.Value)
                    {
                        retorno.IMONTO_MULTIPLE4 = (string)(dr["MONTO_MULTIPLE4"]);
                    }

                    if (dr["MONTO_MULTIPLE5"] != System.DBNull.Value)
                    {
                        retorno.IMONTO_MULTIPLE5 = (string)(dr["MONTO_MULTIPLE5"]);
                    }

                    if (dr["MONTO_MULTIPLE6"] != System.DBNull.Value)
                    {
                        retorno.IMONTO_MULTIPLE6 = (string)(dr["MONTO_MULTIPLE6"]);
                    }

                    if (dr["MONTO_MULTIPLE7"] != System.DBNull.Value)
                    {
                        retorno.IMONTO_MULTIPLE7 = (string)(dr["MONTO_MULTIPLE7"]);
                    }

                    if (dr["MONTO_SIMPLE2"] != System.DBNull.Value)
                    {
                        retorno.IMONTO_SIMPLE2 = (string)(dr["MONTO_SIMPLE2"]);
                    }

                    if (dr["MONTO_SIMPLE3"] != System.DBNull.Value)
                    {
                        retorno.IMONTO_SIMPLE3 = (string)(dr["MONTO_SIMPLE3"]);
                    }

                    if (dr["MONTO_SIMPLE4"] != System.DBNull.Value)
                    {
                        retorno.IMONTO_SIMPLE4 = (string)(dr["MONTO_SIMPLE4"]);
                    }

                    if (dr["MONTO_SIMPLE5"] != System.DBNull.Value)
                    {
                        retorno.IMONTO_SIMPLE5 = (string)(dr["MONTO_SIMPLE5"]);
                    }

                    if (dr["MONTO_SIMPLE6"] != System.DBNull.Value)
                    {
                        retorno.IMONTO_SIMPLE6 = (string)(dr["MONTO_SIMPLE6"]);
                    }

                    if (dr["MONTO_SIMPLE7"] != System.DBNull.Value)
                    {
                        retorno.IMONTO_SIMPLE7 = (string)(dr["MONTO_SIMPLE7"]);
                    }

                    if (dr["NOAUTORIZACION"] != System.DBNull.Value)
                    {
                        retorno.INOAUTORIZACION = (string)(dr["NOAUTORIZACION"]);
                    }

                    if (dr["NOMBREAPLICACION"] != System.DBNull.Value)
                    {
                        retorno.INOMBREAPLICACION = (string)(dr["NOMBREAPLICACION"]);
                    }

                    if (dr["NOMBRECLIENTE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRECLIENTE = (string)(dr["NOMBRECLIENTE"]);
                    }

                    if (dr["NUMERO_DE_BENEFICIOS"] != System.DBNull.Value)
                    {
                        retorno.INUMERO_DE_BENEFICIOS = (string)(dr["NUMERO_DE_BENEFICIOS"]);
                    }

                    if (dr["NUMEROTARJETA"] != System.DBNull.Value)
                    {
                        retorno.INUMEROTARJETA = (string)(dr["NUMEROTARJETA"]);
                    }

                    if (dr["NUMTARJETAII"] != System.DBNull.Value)
                    {
                        retorno.INUMTARJETAII = (string)(dr["NUMTARJETAII"]);
                    }

                    if (dr["PAGOSMULTIPAGOSID"] != System.DBNull.Value)
                    {
                        retorno.IPAGOSMULTIPAGOSID = (long)(dr["PAGOSMULTIPAGOSID"]);
                    }

                    if (dr["PESOSREDIMIDOS"] != System.DBNull.Value)
                    {
                        retorno.IPESOSREDIMIDOS = (string)(dr["PESOSREDIMIDOS"]);
                    }

                    if (dr["PESOSSALDOANTERIOR"] != System.DBNull.Value)
                    {
                        retorno.IPESOSSALDOANTERIOR = (string)(dr["PESOSSALDOANTERIOR"]);
                    }

                    if (dr["PESOSSALDODISPONIBLE"] != System.DBNull.Value)
                    {
                        retorno.IPESOSSALDODISPONIBLE = (string)(dr["PESOSSALDODISPONIBLE"]);
                    }

                    if (dr["PESOSSALDODISPONINLEEXP"] != System.DBNull.Value)
                    {
                        retorno.IPESOSSALDODISPONINLEEXP = (string)(dr["PESOSSALDODISPONINLEEXP"]);
                    }

                    if (dr["PESOSSALDOREDIMIDOSEXP"] != System.DBNull.Value)
                    {
                        retorno.IPESOSSALDOREDIMIDOSEXP = (string)(dr["PESOSSALDOREDIMIDOSEXP"]);
                    }

                    if (dr["PINPAD_USO"] != System.DBNull.Value)
                    {
                        retorno.IPINPAD_USO = (string)(dr["PINPAD_USO"]);
                    }

                    if (dr["POOLADJUSTTYPE"] != System.DBNull.Value)
                    {
                        retorno.IPOOLADJUSTTYPE = (string)(dr["POOLADJUSTTYPE"]);
                    }

                    if (dr["POOLID"] != System.DBNull.Value)
                    {
                        retorno.IPOOLID = (string)(dr["POOLID"]);
                    }

                    if (dr["POOLNUMBER"] != System.DBNull.Value)
                    {
                        retorno.IPOOLNUMBER = (string)(dr["POOLNUMBER"]);
                    }

                    if (dr["POOLUNITLABEL"] != System.DBNull.Value)
                    {
                        retorno.IPOOLUNITLABEL = (string)(dr["POOLUNITLABEL"]);
                    }

                    if (dr["PUNTOSID"] != System.DBNull.Value)
                    {
                        retorno.IPUNTOSID = (long)(dr["PUNTOSID"]);
                    }

                    if (dr["PUNTOSREDIMIDOS"] != System.DBNull.Value)
                    {
                        retorno.IPUNTOSREDIMIDOS = (string)(dr["PUNTOSREDIMIDOS"]);
                    }

                    if (dr["PUNTOSSALDOANTERIOR"] != System.DBNull.Value)
                    {
                        retorno.IPUNTOSSALDOANTERIOR = (string)(dr["PUNTOSSALDOANTERIOR"]);
                    }

                    if (dr["PUNTOSSALDODISPONIBLE"] != System.DBNull.Value)
                    {
                        retorno.IPUNTOSSALDODISPONIBLE = (string)(dr["PUNTOSSALDODISPONIBLE"]);
                    }

                    if (dr["PUNTOSSALDODISPONIBLEEXP"] != System.DBNull.Value)
                    {
                        retorno.IPUNTOSSALDODISPONIBLEEXP = (string)(dr["PUNTOSSALDODISPONIBLEEXP"]);
                    }

                    if (dr["PUNTOSSALDOREDIMIDOSEXP"] != System.DBNull.Value)
                    {
                        retorno.IPUNTOSSALDOREDIMIDOSEXP = (string)(dr["PUNTOSSALDOREDIMIDOSEXP"]);
                    }

                    if (dr["R8_CODIGO_LEYENDA"] != System.DBNull.Value)
                    {
                        retorno.IR8_CODIGO_LEYENDA = (string)(dr["R8_CODIGO_LEYENDA"]);
                    }

                    if (dr["R8_LEYENDA"] != System.DBNull.Value)
                    {
                        retorno.IR8_LEYENDA = (string)(dr["R8_LEYENDA"]);
                    }

                    if (dr["RAZON_SOCIAL"] != System.DBNull.Value)
                    {
                        retorno.IRAZON_SOCIAL = (string)(dr["RAZON_SOCIAL"]);
                    }

                    if (dr["REFERENCIA_RESPUESTA"] != System.DBNull.Value)
                    {
                        retorno.IREFERENCIA_RESPUESTA = (string)(dr["REFERENCIA_RESPUESTA"]);
                    }

                    if (dr["REFERENCIAAFIN"] != System.DBNull.Value)
                    {
                        retorno.IREFERENCIAAFIN = (string)(dr["REFERENCIAAFIN"]);
                    }

                    if (dr["REQUEST"] != System.DBNull.Value)
                    {
                        retorno.IREQUEST = (string)(dr["REQUEST"]);
                    }

                    if (dr["RESPONSE"] != System.DBNull.Value)
                    {
                        retorno.IRESPONSE = (string)(dr["RESPONSE"]);
                    }

                    if (dr["SEGMENTNUMBER"] != System.DBNull.Value)
                    {
                        retorno.ISEGMENTNUMBER = (string)(dr["SEGMENTNUMBER"]);
                    }

                    if (dr["TBINES"] != System.DBNull.Value)
                    {
                        retorno.ITBINES = (string)(dr["TBINES"]);
                    }

                    if (dr["TIPO_BENEFICIO1"] != System.DBNull.Value)
                    {
                        retorno.ITIPO_BENEFICIO1 = (string)(dr["TIPO_BENEFICIO1"]);
                    }

                    if (dr["TIPO_BENEFICIO2"] != System.DBNull.Value)
                    {
                        retorno.ITIPO_BENEFICIO2 = (string)(dr["TIPO_BENEFICIO2"]);
                    }

                    if (dr["TIPO_BENEFICIO3"] != System.DBNull.Value)
                    {
                        retorno.ITIPO_BENEFICIO3 = (string)(dr["TIPO_BENEFICIO3"]);
                    }

                    if (dr["TIPO_BENEFICIO4"] != System.DBNull.Value)
                    {
                        retorno.ITIPO_BENEFICIO4 = (string)(dr["TIPO_BENEFICIO4"]);
                    }

                    if (dr["TIPO_BENEFICIO5"] != System.DBNull.Value)
                    {
                        retorno.ITIPO_BENEFICIO5 = (string)(dr["TIPO_BENEFICIO5"]);
                    }

                    if (dr["TIPO_BENEFICIO6"] != System.DBNull.Value)
                    {
                        retorno.ITIPO_BENEFICIO6 = (string)(dr["TIPO_BENEFICIO6"]);
                    }

                    if (dr["TIPO_BENEFICIO7"] != System.DBNull.Value)
                    {
                        retorno.ITIPO_BENEFICIO7 = (string)(dr["TIPO_BENEFICIO7"]);
                    }

                    if (dr["TIPO_RESPUESTA1"] != System.DBNull.Value)
                    {
                        retorno.ITIPO_RESPUESTA1 = (string)(dr["TIPO_RESPUESTA1"]);
                    }

                    if (dr["TIPO_RESPUESTA2"] != System.DBNull.Value)
                    {
                        retorno.ITIPO_RESPUESTA2 = (string)(dr["TIPO_RESPUESTA2"]);
                    }

                    if (dr["TIPO_RESPUESTA3"] != System.DBNull.Value)
                    {
                        retorno.ITIPO_RESPUESTA3 = (string)(dr["TIPO_RESPUESTA3"]);
                    }

                    if (dr["TIPO_RESPUESTA4"] != System.DBNull.Value)
                    {
                        retorno.ITIPO_RESPUESTA4 = (string)(dr["TIPO_RESPUESTA4"]);
                    }

                    if (dr["TIPO_RESPUESTA5"] != System.DBNull.Value)
                    {
                        retorno.ITIPO_RESPUESTA5 = (string)(dr["TIPO_RESPUESTA5"]);
                    }

                    if (dr["TIPO_RESPUESTA6"] != System.DBNull.Value)
                    {
                        retorno.ITIPO_RESPUESTA6 = (string)(dr["TIPO_RESPUESTA6"]);
                    }

                    if (dr["TIPO_RESPUESTA7"] != System.DBNull.Value)
                    {
                        retorno.ITIPO_RESPUESTA7 = (string)(dr["TIPO_RESPUESTA7"]);
                    }

                    if (dr["TIPOPOS"] != System.DBNull.Value)
                    {
                        retorno.ITIPOPOS = (string)(dr["TIPOPOS"]);
                    }

                    if (dr["TNXCONPUNTOS"] != System.DBNull.Value)
                    {
                        retorno.ITNXCONPUNTOS = (string)(dr["TNXCONPUNTOS"]);
                    }

                    if (dr["TOPERADOR"] != System.DBNull.Value)
                    {
                        retorno.ITOPERADOR = (string)(dr["TOPERADOR"]);
                    }

                    if (dr["VALTIPOCARD"] != System.DBNull.Value)
                    {
                        retorno.IVALTIPOCARD = (string)(dr["VALTIPOCARD"]);
                    }

                    if (dr["VIGENCIAPROMOCIONESEXP"] != System.DBNull.Value)
                    {
                        retorno.IVIGENCIAPROMOCIONESEXP = (string)(dr["VIGENCIAPROMOCIONESEXP"]);
                    }

                    if (dr["AMEX"] != System.DBNull.Value)
                    {
                        retorno.IAMEX = short.Parse(dr["AMEX"].ToString());
                    }

                    if (dr["CARDTIPO"] != System.DBNull.Value)
                    {
                        retorno.ICARDTIPO = int.Parse(dr["CARDTIPO"].ToString());
                    }

                    if (dr["RESPDLL"] != System.DBNull.Value)
                    {
                        retorno.IRESPDLL = int.Parse(dr["RESPDLL"].ToString());
                    }


                    if (dr["DOCTOID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOID = (long)(dr["DOCTOID"]);
                    }


                    if (dr["DOCTOPAGOID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOPAGOID = (long)(dr["DOCTOPAGOID"]);
                    }


                    if (dr["ESTADOTRANSACCIONID"] != System.DBNull.Value)
                    {
                        retorno.IESTADOTRANSACCIONID = (long)(dr["ESTADOTRANSACCIONID"]);
                    }



                    if (dr["TIPOTRANSACCION"] != System.DBNull.Value)
                    {
                        retorno.ITIPOTRANSACCION = (string)(dr["TIPOTRANSACCION"]);
                    }

                    if (dr["REFID"] != System.DBNull.Value)
                    {
                        retorno.IREFID = (long)(dr["REFID"]);
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





            
        public List<CBANCOMERPARAMBE> seleccionarBANCOMERPARAM_PORDOCTO_Simple(CBANCOMERPARAMBE oCBANCOMERPARAM, FbTransaction st)
        {



            List<CBANCOMERPARAMBE> lista = new List<CBANCOMERPARAMBE>();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from BANCOMERPARAM where DOCTOID = @DOCTOID AND ESTADOTRANSACCIONID = @ESTADOTRANSACCIONID AND TIPOTRANSACCION = @TIPOTRANSACCION  ";


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCBANCOMERPARAM.IDOCTOID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESTADOTRANSACCIONID", FbDbType.BigInt);
                auxPar.Value = oCBANCOMERPARAM.IESTADOTRANSACCIONID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPOTRANSACCION", FbDbType.VarChar);
                auxPar.Value = oCBANCOMERPARAM.ITIPOTRANSACCION;
                parts.Add(auxPar);



                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                while (dr.Read())
                {

                    CBANCOMERPARAMBE retorno = new CBANCOMERPARAMBE();

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

                    if (dr["AID"] != System.DBNull.Value)
                    {
                        retorno.IAID = (string)(dr["AID"]);
                    }

                    if (dr["BANCOMER"] != System.DBNull.Value)
                    {
                        retorno.IBANCOMER = (string)(dr["BANCOMER"]);
                    }

                    if (dr["BITCAMPANAS"] != System.DBNull.Value)
                    {
                        retorno.IBITCAMPANAS = (string)(dr["BITCAMPANAS"]);
                    }

                    if (dr["CAMPANAAUTORIZACION"] != System.DBNull.Value)
                    {
                        retorno.ICAMPANAAUTORIZACION = (string)(dr["CAMPANAAUTORIZACION"]);
                    }

                    if (dr["CAMPANAREFERENCIA"] != System.DBNull.Value)
                    {
                        retorno.ICAMPANAREFERENCIA = (string)(dr["CAMPANAREFERENCIA"]);
                    }

                    if (dr["CAMPANAREFERENCIANUM"] != System.DBNull.Value)
                    {
                        retorno.ICAMPANAREFERENCIANUM = (long)(dr["CAMPANAREFERENCIANUM"]);
                    }

                    if (dr["CARDREQUEST"] != System.DBNull.Value)
                    {
                        retorno.ICARDREQUEST = (string)(dr["CARDREQUEST"]);
                    }

                    if (dr["PROMOCIONES"] != System.DBNull.Value)
                    {
                        retorno.IPROMOCIONES = (string)(dr["PROMOCIONES"]);
                    }

                    if (dr["CLIENTE_CMP_COMERCIO"] != System.DBNull.Value)
                    {
                        retorno.ICLIENTE_CMP_COMERCIO = (string)(dr["CLIENTE_CMP_COMERCIO"]);
                    }

                    if (dr["CLIENTE_TDC_STOCK"] != System.DBNull.Value)
                    {
                        retorno.ICLIENTE_TDC_STOCK = (string)(dr["CLIENTE_TDC_STOCK"]);
                    }

                    if (dr["CLSREQUESTID"] != System.DBNull.Value)
                    {
                        retorno.ICLSREQUESTID = (long)(dr["CLSREQUESTID"]);
                    }

                    if (dr["CLSRESPONSEID"] != System.DBNull.Value)
                    {
                        retorno.ICLSRESPONSEID = (long)(dr["CLSRESPONSEID"]);
                    }

                    if (dr["CODIGO_BENEFICIO1"] != System.DBNull.Value)
                    {
                        retorno.ICODIGO_BENEFICIO1 = (string)(dr["CODIGO_BENEFICIO1"]);
                    }

                    if (dr["CODIGO_BENEFICIO2"] != System.DBNull.Value)
                    {
                        retorno.ICODIGO_BENEFICIO2 = (string)(dr["CODIGO_BENEFICIO2"]);
                    }

                    if (dr["CODIGO_BENEFICIO3"] != System.DBNull.Value)
                    {
                        retorno.ICODIGO_BENEFICIO3 = (string)(dr["CODIGO_BENEFICIO3"]);
                    }

                    if (dr["CODIGO_BENEFICIO4"] != System.DBNull.Value)
                    {
                        retorno.ICODIGO_BENEFICIO4 = (string)(dr["CODIGO_BENEFICIO4"]);
                    }

                    if (dr["CODIGO_BENEFICIO5"] != System.DBNull.Value)
                    {
                        retorno.ICODIGO_BENEFICIO5 = (string)(dr["CODIGO_BENEFICIO5"]);
                    }

                    if (dr["CODIGO_BENEFICIO6"] != System.DBNull.Value)
                    {
                        retorno.ICODIGO_BENEFICIO6 = (string)(dr["CODIGO_BENEFICIO6"]);
                    }

                    if (dr["CODIGO_BENEFICIO7"] != System.DBNull.Value)
                    {
                        retorno.ICODIGO_BENEFICIO7 = (string)(dr["CODIGO_BENEFICIO7"]);
                    }

                    if (dr["COMERCIO_CMP_COMERCIO"] != System.DBNull.Value)
                    {
                        retorno.ICOMERCIO_CMP_COMERCIO = (string)(dr["COMERCIO_CMP_COMERCIO"]);
                    }

                    if (dr["COMERCIO_TDC_STOCK"] != System.DBNull.Value)
                    {
                        retorno.ICOMERCIO_TDC_STOCK = (string)(dr["COMERCIO_TDC_STOCK"]);
                    }

                    if (dr["COMISION1"] != System.DBNull.Value)
                    {
                        retorno.ICOMISION1 = (string)(dr["COMISION1"]);
                    }

                    if (dr["COMISION2"] != System.DBNull.Value)
                    {
                        retorno.ICOMISION2 = (string)(dr["COMISION2"]);
                    }

                    if (dr["COMISION3"] != System.DBNull.Value)
                    {
                        retorno.ICOMISION3 = (string)(dr["COMISION3"]);
                    }

                    if (dr["COMISION4"] != System.DBNull.Value)
                    {
                        retorno.ICOMISION4 = (string)(dr["COMISION4"]);
                    }

                    if (dr["COMISION5"] != System.DBNull.Value)
                    {
                        retorno.ICOMISION5 = (string)(dr["COMISION5"]);
                    }

                    if (dr["COMISION6"] != System.DBNull.Value)
                    {
                        retorno.ICOMISION6 = (string)(dr["COMISION6"]);
                    }

                    if (dr["COMISION7"] != System.DBNull.Value)
                    {
                        retorno.ICOMISION7 = (string)(dr["COMISION7"]);
                    }

                    if (dr["CREDITODEBITO"] != System.DBNull.Value)
                    {
                        retorno.ICREDITODEBITO = (string)(dr["CREDITODEBITO"]);
                    }

                    if (dr["CRIPTOGRAMA"] != System.DBNull.Value)
                    {
                        retorno.ICRIPTOGRAMA = (string)(dr["CRIPTOGRAMA"]);
                    }

                    if (dr["ECOUPNUMBER"] != System.DBNull.Value)
                    {
                        retorno.IECOUPNUMBER = (string)(dr["ECOUPNUMBER"]);
                    }

                    if (dr["FACTOREXP"] != System.DBNull.Value)
                    {
                        retorno.IFACTOREXP = (string)(dr["FACTOREXP"]);
                    }

                    if (dr["FIRMAAUTOGRAFA"] != System.DBNull.Value)
                    {
                        retorno.IFIRMAAUTOGRAFA = (string)(dr["FIRMAAUTOGRAFA"]);
                    }

                    if (dr["FIRMAELECTRONICA"] != System.DBNull.Value)
                    {
                        retorno.IFIRMAELECTRONICA = (string)(dr["FIRMAELECTRONICA"]);
                    }

                    if (dr["FIRMAQPS"] != System.DBNull.Value)
                    {
                        retorno.IFIRMAQPS = (string)(dr["FIRMAQPS"]);
                    }

                    if (dr["GUIA_CIE"] != System.DBNull.Value)
                    {
                        retorno.IGUIA_CIE = (string)(dr["GUIA_CIE"]);
                    }

                    if (dr["IDTOKEN12"] != System.DBNull.Value)
                    {
                        retorno.IIDTOKEN12 = (string)(dr["IDTOKEN12"]);
                    }

                    if (dr["IDTOKEN13"] != System.DBNull.Value)
                    {
                        retorno.IIDTOKEN13 = (string)(dr["IDTOKEN13"]);
                    }

                    if (dr["IDTOKEN16"] != System.DBNull.Value)
                    {
                        retorno.IIDTOKEN16 = (string)(dr["IDTOKEN16"]);
                    }

                    if (dr["IDTOKENR7"] != System.DBNull.Value)
                    {
                        retorno.IIDTOKENR7 = (string)(dr["IDTOKENR7"]);
                    }

                    if (dr["IDTOKENR8"] != System.DBNull.Value)
                    {
                        retorno.IIDTOKENR8 = (string)(dr["IDTOKENR8"]);
                    }

                    if (dr["IMPORTE_BENEFICIO"] != System.DBNull.Value)
                    {
                        retorno.IIMPORTE_BENEFICIO = (string)(dr["IMPORTE_BENEFICIO"]);
                    }

                    if (dr["IMPORTE_UDIS"] != System.DBNull.Value)
                    {
                        retorno.IIMPORTE_UDIS = (string)(dr["IMPORTE_UDIS"]);
                    }

                    if (dr["INDICADOR_CAMBIO_PLAZO"] != System.DBNull.Value)
                    {
                        retorno.IINDICADOR_CAMBIO_PLAZO = (string)(dr["INDICADOR_CAMBIO_PLAZO"]);
                    }

                    if (dr["INDICADOR_DE_AVISO"] != System.DBNull.Value)
                    {
                        retorno.IINDICADOR_DE_AVISO = (string)(dr["INDICADOR_DE_AVISO"]);
                    }

                    if (dr["INDICAODR_DE_BENEFICIO"] != System.DBNull.Value)
                    {
                        retorno.IINDICAODR_DE_BENEFICIO = (string)(dr["INDICAODR_DE_BENEFICIO"]);
                    }

                    if (dr["ISFOLIO"] != System.DBNull.Value)
                    {
                        retorno.IISFOLIO = (string)(dr["ISFOLIO"]);
                    }

                    if (dr["ISOFFLINE"] != System.DBNull.Value)
                    {
                        retorno.IISOFFLINE = (string)(dr["ISOFFLINE"]);
                    }

                    if (dr["LEYENDA"] != System.DBNull.Value)
                    {
                        retorno.ILEYENDA = (string)(dr["LEYENDA"]);
                    }

                    if (dr["MACADDALTERNATIVA"] != System.DBNull.Value)
                    {
                        retorno.IMACADDALTERNATIVA = (string)(dr["MACADDALTERNATIVA"]);
                    }

                    if (dr["MENSAJE_BASE_CHEQUE"] != System.DBNull.Value)
                    {
                        retorno.IMENSAJE_BASE_CHEQUE = (string)(dr["MENSAJE_BASE_CHEQUE"]);
                    }

                    if (dr["MENSAJE_BASE_CONTINUOS"] != System.DBNull.Value)
                    {
                        retorno.IMENSAJE_BASE_CONTINUOS = (string)(dr["MENSAJE_BASE_CONTINUOS"]);
                    }

                    if (dr["MENSAJE_CLIENTE"] != System.DBNull.Value)
                    {
                        retorno.IMENSAJE_CLIENTE = (string)(dr["MENSAJE_CLIENTE"]);
                    }

                    if (dr["MENSAJE_CLIENTE_EMISRO"] != System.DBNull.Value)
                    {
                        retorno.IMENSAJE_CLIENTE_EMISRO = (string)(dr["MENSAJE_CLIENTE_EMISRO"]);
                    }

                    if (dr["MENSAJE_COMERCIO"] != System.DBNull.Value)
                    {
                        retorno.IMENSAJE_COMERCIO = (string)(dr["MENSAJE_COMERCIO"]);
                    }

                    if (dr["MODOINGRESO"] != System.DBNull.Value)
                    {
                        retorno.IMODOINGRESO = (string)(dr["MODOINGRESO"]);
                    }

                    if (dr["MONTO_BENEFICIO_MULTIPLE1"] != System.DBNull.Value)
                    {
                        retorno.IMONTO_BENEFICIO_MULTIPLE1 = (string)(dr["MONTO_BENEFICIO_MULTIPLE1"]);
                    }

                    if (dr["MONTO_BENEFICIO_SIMPLE1"] != System.DBNull.Value)
                    {
                        retorno.IMONTO_BENEFICIO_SIMPLE1 = (string)(dr["MONTO_BENEFICIO_SIMPLE1"]);
                    }

                    if (dr["MONTO_CHEQUE_ACTUAL"] != System.DBNull.Value)
                    {
                        retorno.IMONTO_CHEQUE_ACTUAL = (string)(dr["MONTO_CHEQUE_ACTUAL"]);
                    }

                    if (dr["MONTO_CHEQUE_ANTERIOR"] != System.DBNull.Value)
                    {
                        retorno.IMONTO_CHEQUE_ANTERIOR = (string)(dr["MONTO_CHEQUE_ANTERIOR"]);
                    }

                    if (dr["MONTO_CHEQUE_REDIMIDOS"] != System.DBNull.Value)
                    {
                        retorno.IMONTO_CHEQUE_REDIMIDOS = (string)(dr["MONTO_CHEQUE_REDIMIDOS"]);
                    }

                    if (dr["MONTO_CONTINUOS_ACTUAL"] != System.DBNull.Value)
                    {
                        retorno.IMONTO_CONTINUOS_ACTUAL = (string)(dr["MONTO_CONTINUOS_ACTUAL"]);
                    }

                    if (dr["MONTO_CONTINUOS_ANTERIOR"] != System.DBNull.Value)
                    {
                        retorno.IMONTO_CONTINUOS_ANTERIOR = (string)(dr["MONTO_CONTINUOS_ANTERIOR"]);
                    }

                    if (dr["MONTO_CONTINUOS_REDIMIDOS"] != System.DBNull.Value)
                    {
                        retorno.IMONTO_CONTINUOS_REDIMIDOS = (string)(dr["MONTO_CONTINUOS_REDIMIDOS"]);
                    }

                    if (dr["MONTO_MULTIPLE2"] != System.DBNull.Value)
                    {
                        retorno.IMONTO_MULTIPLE2 = (string)(dr["MONTO_MULTIPLE2"]);
                    }

                    if (dr["MONTO_MULTIPLE3"] != System.DBNull.Value)
                    {
                        retorno.IMONTO_MULTIPLE3 = (string)(dr["MONTO_MULTIPLE3"]);
                    }

                    if (dr["MONTO_MULTIPLE4"] != System.DBNull.Value)
                    {
                        retorno.IMONTO_MULTIPLE4 = (string)(dr["MONTO_MULTIPLE4"]);
                    }

                    if (dr["MONTO_MULTIPLE5"] != System.DBNull.Value)
                    {
                        retorno.IMONTO_MULTIPLE5 = (string)(dr["MONTO_MULTIPLE5"]);
                    }

                    if (dr["MONTO_MULTIPLE6"] != System.DBNull.Value)
                    {
                        retorno.IMONTO_MULTIPLE6 = (string)(dr["MONTO_MULTIPLE6"]);
                    }

                    if (dr["MONTO_MULTIPLE7"] != System.DBNull.Value)
                    {
                        retorno.IMONTO_MULTIPLE7 = (string)(dr["MONTO_MULTIPLE7"]);
                    }

                    if (dr["MONTO_SIMPLE2"] != System.DBNull.Value)
                    {
                        retorno.IMONTO_SIMPLE2 = (string)(dr["MONTO_SIMPLE2"]);
                    }

                    if (dr["MONTO_SIMPLE3"] != System.DBNull.Value)
                    {
                        retorno.IMONTO_SIMPLE3 = (string)(dr["MONTO_SIMPLE3"]);
                    }

                    if (dr["MONTO_SIMPLE4"] != System.DBNull.Value)
                    {
                        retorno.IMONTO_SIMPLE4 = (string)(dr["MONTO_SIMPLE4"]);
                    }

                    if (dr["MONTO_SIMPLE5"] != System.DBNull.Value)
                    {
                        retorno.IMONTO_SIMPLE5 = (string)(dr["MONTO_SIMPLE5"]);
                    }

                    if (dr["MONTO_SIMPLE6"] != System.DBNull.Value)
                    {
                        retorno.IMONTO_SIMPLE6 = (string)(dr["MONTO_SIMPLE6"]);
                    }

                    if (dr["MONTO_SIMPLE7"] != System.DBNull.Value)
                    {
                        retorno.IMONTO_SIMPLE7 = (string)(dr["MONTO_SIMPLE7"]);
                    }

                    if (dr["NOAUTORIZACION"] != System.DBNull.Value)
                    {
                        retorno.INOAUTORIZACION = (string)(dr["NOAUTORIZACION"]);
                    }

                    if (dr["NOMBREAPLICACION"] != System.DBNull.Value)
                    {
                        retorno.INOMBREAPLICACION = (string)(dr["NOMBREAPLICACION"]);
                    }

                    if (dr["NOMBRECLIENTE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRECLIENTE = (string)(dr["NOMBRECLIENTE"]);
                    }

                    if (dr["NUMERO_DE_BENEFICIOS"] != System.DBNull.Value)
                    {
                        retorno.INUMERO_DE_BENEFICIOS = (string)(dr["NUMERO_DE_BENEFICIOS"]);
                    }

                    if (dr["NUMEROTARJETA"] != System.DBNull.Value)
                    {
                        retorno.INUMEROTARJETA = (string)(dr["NUMEROTARJETA"]);
                    }

                    if (dr["NUMTARJETAII"] != System.DBNull.Value)
                    {
                        retorno.INUMTARJETAII = (string)(dr["NUMTARJETAII"]);
                    }

                    if (dr["PAGOSMULTIPAGOSID"] != System.DBNull.Value)
                    {
                        retorno.IPAGOSMULTIPAGOSID = (long)(dr["PAGOSMULTIPAGOSID"]);
                    }

                    if (dr["PESOSREDIMIDOS"] != System.DBNull.Value)
                    {
                        retorno.IPESOSREDIMIDOS = (string)(dr["PESOSREDIMIDOS"]);
                    }

                    if (dr["PESOSSALDOANTERIOR"] != System.DBNull.Value)
                    {
                        retorno.IPESOSSALDOANTERIOR = (string)(dr["PESOSSALDOANTERIOR"]);
                    }

                    if (dr["PESOSSALDODISPONIBLE"] != System.DBNull.Value)
                    {
                        retorno.IPESOSSALDODISPONIBLE = (string)(dr["PESOSSALDODISPONIBLE"]);
                    }

                    if (dr["PESOSSALDODISPONINLEEXP"] != System.DBNull.Value)
                    {
                        retorno.IPESOSSALDODISPONINLEEXP = (string)(dr["PESOSSALDODISPONINLEEXP"]);
                    }

                    if (dr["PESOSSALDOREDIMIDOSEXP"] != System.DBNull.Value)
                    {
                        retorno.IPESOSSALDOREDIMIDOSEXP = (string)(dr["PESOSSALDOREDIMIDOSEXP"]);
                    }

                    if (dr["PINPAD_USO"] != System.DBNull.Value)
                    {
                        retorno.IPINPAD_USO = (string)(dr["PINPAD_USO"]);
                    }

                    if (dr["POOLADJUSTTYPE"] != System.DBNull.Value)
                    {
                        retorno.IPOOLADJUSTTYPE = (string)(dr["POOLADJUSTTYPE"]);
                    }

                    if (dr["POOLID"] != System.DBNull.Value)
                    {
                        retorno.IPOOLID = (string)(dr["POOLID"]);
                    }

                    if (dr["POOLNUMBER"] != System.DBNull.Value)
                    {
                        retorno.IPOOLNUMBER = (string)(dr["POOLNUMBER"]);
                    }

                    if (dr["POOLUNITLABEL"] != System.DBNull.Value)
                    {
                        retorno.IPOOLUNITLABEL = (string)(dr["POOLUNITLABEL"]);
                    }

                    if (dr["PUNTOSID"] != System.DBNull.Value)
                    {
                        retorno.IPUNTOSID = (long)(dr["PUNTOSID"]);
                    }

                    if (dr["PUNTOSREDIMIDOS"] != System.DBNull.Value)
                    {
                        retorno.IPUNTOSREDIMIDOS = (string)(dr["PUNTOSREDIMIDOS"]);
                    }

                    if (dr["PUNTOSSALDOANTERIOR"] != System.DBNull.Value)
                    {
                        retorno.IPUNTOSSALDOANTERIOR = (string)(dr["PUNTOSSALDOANTERIOR"]);
                    }

                    if (dr["PUNTOSSALDODISPONIBLE"] != System.DBNull.Value)
                    {
                        retorno.IPUNTOSSALDODISPONIBLE = (string)(dr["PUNTOSSALDODISPONIBLE"]);
                    }

                    if (dr["PUNTOSSALDODISPONIBLEEXP"] != System.DBNull.Value)
                    {
                        retorno.IPUNTOSSALDODISPONIBLEEXP = (string)(dr["PUNTOSSALDODISPONIBLEEXP"]);
                    }

                    if (dr["PUNTOSSALDOREDIMIDOSEXP"] != System.DBNull.Value)
                    {
                        retorno.IPUNTOSSALDOREDIMIDOSEXP = (string)(dr["PUNTOSSALDOREDIMIDOSEXP"]);
                    }

                    if (dr["R8_CODIGO_LEYENDA"] != System.DBNull.Value)
                    {
                        retorno.IR8_CODIGO_LEYENDA = (string)(dr["R8_CODIGO_LEYENDA"]);
                    }

                    if (dr["R8_LEYENDA"] != System.DBNull.Value)
                    {
                        retorno.IR8_LEYENDA = (string)(dr["R8_LEYENDA"]);
                    }

                    if (dr["RAZON_SOCIAL"] != System.DBNull.Value)
                    {
                        retorno.IRAZON_SOCIAL = (string)(dr["RAZON_SOCIAL"]);
                    }

                    if (dr["REFERENCIA_RESPUESTA"] != System.DBNull.Value)
                    {
                        retorno.IREFERENCIA_RESPUESTA = (string)(dr["REFERENCIA_RESPUESTA"]);
                    }

                    if (dr["REFERENCIAAFIN"] != System.DBNull.Value)
                    {
                        retorno.IREFERENCIAAFIN = (string)(dr["REFERENCIAAFIN"]);
                    }

                    if (dr["REQUEST"] != System.DBNull.Value)
                    {
                        retorno.IREQUEST = (string)(dr["REQUEST"]);
                    }

                    if (dr["RESPONSE"] != System.DBNull.Value)
                    {
                        retorno.IRESPONSE = (string)(dr["RESPONSE"]);
                    }

                    if (dr["SEGMENTNUMBER"] != System.DBNull.Value)
                    {
                        retorno.ISEGMENTNUMBER = (string)(dr["SEGMENTNUMBER"]);
                    }

                    if (dr["TBINES"] != System.DBNull.Value)
                    {
                        retorno.ITBINES = (string)(dr["TBINES"]);
                    }

                    if (dr["TIPO_BENEFICIO1"] != System.DBNull.Value)
                    {
                        retorno.ITIPO_BENEFICIO1 = (string)(dr["TIPO_BENEFICIO1"]);
                    }

                    if (dr["TIPO_BENEFICIO2"] != System.DBNull.Value)
                    {
                        retorno.ITIPO_BENEFICIO2 = (string)(dr["TIPO_BENEFICIO2"]);
                    }

                    if (dr["TIPO_BENEFICIO3"] != System.DBNull.Value)
                    {
                        retorno.ITIPO_BENEFICIO3 = (string)(dr["TIPO_BENEFICIO3"]);
                    }

                    if (dr["TIPO_BENEFICIO4"] != System.DBNull.Value)
                    {
                        retorno.ITIPO_BENEFICIO4 = (string)(dr["TIPO_BENEFICIO4"]);
                    }

                    if (dr["TIPO_BENEFICIO5"] != System.DBNull.Value)
                    {
                        retorno.ITIPO_BENEFICIO5 = (string)(dr["TIPO_BENEFICIO5"]);
                    }

                    if (dr["TIPO_BENEFICIO6"] != System.DBNull.Value)
                    {
                        retorno.ITIPO_BENEFICIO6 = (string)(dr["TIPO_BENEFICIO6"]);
                    }

                    if (dr["TIPO_BENEFICIO7"] != System.DBNull.Value)
                    {
                        retorno.ITIPO_BENEFICIO7 = (string)(dr["TIPO_BENEFICIO7"]);
                    }

                    if (dr["TIPO_RESPUESTA1"] != System.DBNull.Value)
                    {
                        retorno.ITIPO_RESPUESTA1 = (string)(dr["TIPO_RESPUESTA1"]);
                    }

                    if (dr["TIPO_RESPUESTA2"] != System.DBNull.Value)
                    {
                        retorno.ITIPO_RESPUESTA2 = (string)(dr["TIPO_RESPUESTA2"]);
                    }

                    if (dr["TIPO_RESPUESTA3"] != System.DBNull.Value)
                    {
                        retorno.ITIPO_RESPUESTA3 = (string)(dr["TIPO_RESPUESTA3"]);
                    }

                    if (dr["TIPO_RESPUESTA4"] != System.DBNull.Value)
                    {
                        retorno.ITIPO_RESPUESTA4 = (string)(dr["TIPO_RESPUESTA4"]);
                    }

                    if (dr["TIPO_RESPUESTA5"] != System.DBNull.Value)
                    {
                        retorno.ITIPO_RESPUESTA5 = (string)(dr["TIPO_RESPUESTA5"]);
                    }

                    if (dr["TIPO_RESPUESTA6"] != System.DBNull.Value)
                    {
                        retorno.ITIPO_RESPUESTA6 = (string)(dr["TIPO_RESPUESTA6"]);
                    }

                    if (dr["TIPO_RESPUESTA7"] != System.DBNull.Value)
                    {
                        retorno.ITIPO_RESPUESTA7 = (string)(dr["TIPO_RESPUESTA7"]);
                    }

                    if (dr["TIPOPOS"] != System.DBNull.Value)
                    {
                        retorno.ITIPOPOS = (string)(dr["TIPOPOS"]);
                    }

                    if (dr["TNXCONPUNTOS"] != System.DBNull.Value)
                    {
                        retorno.ITNXCONPUNTOS = (string)(dr["TNXCONPUNTOS"]);
                    }

                    if (dr["TOPERADOR"] != System.DBNull.Value)
                    {
                        retorno.ITOPERADOR = (string)(dr["TOPERADOR"]);
                    }

                    if (dr["VALTIPOCARD"] != System.DBNull.Value)
                    {
                        retorno.IVALTIPOCARD = (string)(dr["VALTIPOCARD"]);
                    }

                    if (dr["VIGENCIAPROMOCIONESEXP"] != System.DBNull.Value)
                    {
                        retorno.IVIGENCIAPROMOCIONESEXP = (string)(dr["VIGENCIAPROMOCIONESEXP"]);
                    }

                    if (dr["AMEX"] != System.DBNull.Value)
                    {
                        retorno.IAMEX = short.Parse(dr["AMEX"].ToString());
                    }

                    if (dr["CARDTIPO"] != System.DBNull.Value)
                    {
                        retorno.ICARDTIPO = int.Parse(dr["CARDTIPO"].ToString());
                    }

                    if (dr["RESPDLL"] != System.DBNull.Value)
                    {
                        retorno.IRESPDLL = int.Parse(dr["RESPDLL"].ToString());
                    }


                    if (dr["DOCTOID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOID = (long)(dr["DOCTOID"]);
                    }


                    if (dr["DOCTOPAGOID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOPAGOID = (long)(dr["DOCTOPAGOID"]);
                    }


                    if (dr["ESTADOTRANSACCIONID"] != System.DBNull.Value)
                    {
                        retorno.IESTADOTRANSACCIONID = (long)(dr["ESTADOTRANSACCIONID"]);
                    }



                    if (dr["TIPOTRANSACCION"] != System.DBNull.Value)
                    {
                        retorno.ITIPOTRANSACCION = (string)(dr["TIPOTRANSACCION"]);
                    }


                    if (dr["REFID"] != System.DBNull.Value)
                    {
                        retorno.IREFID = (long)(dr["REFID"]);
                    }


                    if (lista != null)
                    {
                        lista.Add(retorno);
                    }

                }



                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return lista;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }





        
        public DataSet enlistarBANCOMERPARAM()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_BANCOMERPARAM_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        
        public DataSet enlistarCortoBANCOMERPARAM()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_BANCOMERPARAM_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        
        public int ExisteBANCOMERPARAM(CBANCOMERPARAMBE oCBANCOMERPARAM, FbTransaction st)
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
                auxPar.Value = oCBANCOMERPARAM.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from BANCOMERPARAM where

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




        public CBANCOMERPARAMBE AgregarBANCOMERPARAM(CBANCOMERPARAMBE oCBANCOMERPARAM, FbTransaction st)
        {
            try
            {
                int iRes = ExisteBANCOMERPARAM(oCBANCOMERPARAM, st);
                if (iRes == 1)
                {
                    this.IComentario = "El BANCOMERPARAM ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarBANCOMERPARAMD(oCBANCOMERPARAM, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarBANCOMERPARAM(CBANCOMERPARAMBE oCBANCOMERPARAM, FbTransaction st)
        {
            try
            {
                int iRes = ExisteBANCOMERPARAM(oCBANCOMERPARAM, st);
                if (iRes == 0)
                {
                    this.IComentario = "El BANCOMERPARAM no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarBANCOMERPARAMD(oCBANCOMERPARAM, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarBANCOMERPARAM(CBANCOMERPARAMBE oCBANCOMERPARAMNuevo, CBANCOMERPARAMBE oCBANCOMERPARAMAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteBANCOMERPARAM(oCBANCOMERPARAMAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El BANCOMERPARAM no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarBANCOMERPARAMD(oCBANCOMERPARAMNuevo, oCBANCOMERPARAMAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }







        public bool BANCOMER_GETCONSECUTIVO(DateTime fecha, ref long consecutivo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                auxPar.Value = fecha;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CONSECUTIVONUEVO", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"BANCOMER_GETCONSECUTIVO";

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
                        this.iComentario = "Hubo un error " + ((int)arParms[arParms.Length - 1].Value).ToString();
                        return false;
                    }
                }

                if ((long)arParms[arParms.Length - 2].Value != 0)
                {
                    consecutivo = (long)arParms[arParms.Length - 2].Value; 
                }


                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }







        public bool BANCOMERPARAM_GUARDAR(ref CBANCOMERPARAMBE oCBANCOMERPARAM, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@BANCOMERPARAMID_ORIG", FbDbType.BigInt);
                if (!(bool)oCBANCOMERPARAM.isnull["IID"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCBANCOMERPARAM.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCBANCOMERPARAM.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@AID", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IAID"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@AMEX", FbDbType.SmallInt);
                if (!(bool)oCBANCOMERPARAM.isnull["IAMEX"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IAMEX;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@BANCOMER", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAM.isnull["IBANCOMER"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IBANCOMER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@BITCAMPANAS", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAM.isnull["IBITCAMPANAS"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IBITCAMPANAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPANAAUTORIZACION", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICAMPANAAUTORIZACION"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICAMPANAAUTORIZACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPANAREFERENCIA", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICAMPANAREFERENCIA"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICAMPANAREFERENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPANAREFERENCIANUM", FbDbType.BigInt);
                if (!(bool)oCBANCOMERPARAM.isnull["ICAMPANAREFERENCIANUM"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICAMPANAREFERENCIANUM;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CARDREQUEST", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICARDREQUEST"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICARDREQUEST;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CARDTIPO", FbDbType.Integer);
                if (!(bool)oCBANCOMERPARAM.isnull["ICARDTIPO"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICARDTIPO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PROMOCIONES", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAM.isnull["IPROMOCIONES"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IPROMOCIONES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLIENTE_CMP_COMERCIO", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICLIENTE_CMP_COMERCIO"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICLIENTE_CMP_COMERCIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLIENTE_TDC_STOCK", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICLIENTE_TDC_STOCK"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICLIENTE_TDC_STOCK;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLSREQUESTID", FbDbType.BigInt);
                if (!(bool)oCBANCOMERPARAM.isnull["ICLSREQUESTID"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICLSREQUESTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLSRESPONSEID", FbDbType.BigInt);
                if (!(bool)oCBANCOMERPARAM.isnull["ICLSRESPONSEID"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICLSRESPONSEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CODIGO_BENEFICIO1", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICODIGO_BENEFICIO1"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICODIGO_BENEFICIO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CODIGO_BENEFICIO2", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICODIGO_BENEFICIO2"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICODIGO_BENEFICIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CODIGO_BENEFICIO3", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICODIGO_BENEFICIO3"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICODIGO_BENEFICIO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CODIGO_BENEFICIO4", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICODIGO_BENEFICIO4"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICODIGO_BENEFICIO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CODIGO_BENEFICIO5", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICODIGO_BENEFICIO5"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICODIGO_BENEFICIO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CODIGO_BENEFICIO6", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICODIGO_BENEFICIO6"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICODIGO_BENEFICIO6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CODIGO_BENEFICIO7", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICODIGO_BENEFICIO7"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICODIGO_BENEFICIO7;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COMERCIO_CMP_COMERCIO", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICOMERCIO_CMP_COMERCIO"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICOMERCIO_CMP_COMERCIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COMERCIO_TDC_STOCK", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICOMERCIO_TDC_STOCK"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICOMERCIO_TDC_STOCK;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COMISION1", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICOMISION1"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICOMISION1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COMISION2", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICOMISION2"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICOMISION2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COMISION3", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICOMISION3"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICOMISION3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COMISION4", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICOMISION4"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICOMISION4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COMISION5", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICOMISION5"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICOMISION5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COMISION6", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICOMISION6"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICOMISION6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COMISION7", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICOMISION7"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICOMISION7;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREDITODEBITO", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICREDITODEBITO"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICREDITODEBITO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CRIPTOGRAMA", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ICRIPTOGRAMA"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ICRIPTOGRAMA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ECOUPNUMBER", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IECOUPNUMBER"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IECOUPNUMBER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FACTOREXP", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IFACTOREXP"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IFACTOREXP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FIRMAAUTOGRAFA", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAM.isnull["IFIRMAAUTOGRAFA"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IFIRMAAUTOGRAFA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FIRMAELECTRONICA", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAM.isnull["IFIRMAELECTRONICA"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IFIRMAELECTRONICA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FIRMAQPS", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAM.isnull["IFIRMAQPS"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IFIRMAQPS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@GUIA_CIE", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IGUIA_CIE"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IGUIA_CIE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDTOKEN12", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAM.isnull["IIDTOKEN12"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IIDTOKEN12;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDTOKEN13", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAM.isnull["IIDTOKEN13"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IIDTOKEN13;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDTOKEN16", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAM.isnull["IIDTOKEN16"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IIDTOKEN16;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDTOKENR7", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAM.isnull["IIDTOKENR7"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IIDTOKENR7;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDTOKENR8", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAM.isnull["IIDTOKENR8"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IIDTOKENR8;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPORTE_BENEFICIO", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IIMPORTE_BENEFICIO"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IIMPORTE_BENEFICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPORTE_UDIS", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IIMPORTE_UDIS"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IIMPORTE_UDIS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@INDICADOR_CAMBIO_PLAZO", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IINDICADOR_CAMBIO_PLAZO"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IINDICADOR_CAMBIO_PLAZO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@INDICADOR_DE_AVISO", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IINDICADOR_DE_AVISO"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IINDICADOR_DE_AVISO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@INDICAODR_DE_BENEFICIO", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IINDICAODR_DE_BENEFICIO"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IINDICAODR_DE_BENEFICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ISFOLIO", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IISFOLIO"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IISFOLIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ISOFFLINE", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAM.isnull["IISOFFLINE"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IISOFFLINE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LEYENDA", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ILEYENDA"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ILEYENDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MACADDALTERNATIVA", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMACADDALTERNATIVA"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMACADDALTERNATIVA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MENSAJE_BASE_CHEQUE", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMENSAJE_BASE_CHEQUE"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMENSAJE_BASE_CHEQUE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MENSAJE_BASE_CONTINUOS", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMENSAJE_BASE_CONTINUOS"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMENSAJE_BASE_CONTINUOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MENSAJE_CLIENTE", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMENSAJE_CLIENTE"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMENSAJE_CLIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MENSAJE_CLIENTE_EMISRO", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMENSAJE_CLIENTE_EMISRO"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMENSAJE_CLIENTE_EMISRO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MENSAJE_COMERCIO", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMENSAJE_COMERCIO"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMENSAJE_COMERCIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODOINGRESO", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMODOINGRESO"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMODOINGRESO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO_BENEFICIO_MULTIPLE1", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMONTO_BENEFICIO_MULTIPLE1"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMONTO_BENEFICIO_MULTIPLE1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO_BENEFICIO_SIMPLE1", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMONTO_BENEFICIO_SIMPLE1"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMONTO_BENEFICIO_SIMPLE1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO_CHEQUE_ACTUAL", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMONTO_CHEQUE_ACTUAL"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMONTO_CHEQUE_ACTUAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO_CHEQUE_ANTERIOR", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMONTO_CHEQUE_ANTERIOR"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMONTO_CHEQUE_ANTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO_CHEQUE_REDIMIDOS", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMONTO_CHEQUE_REDIMIDOS"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMONTO_CHEQUE_REDIMIDOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO_CONTINUOS_ACTUAL", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMONTO_CONTINUOS_ACTUAL"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMONTO_CONTINUOS_ACTUAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO_CONTINUOS_ANTERIOR", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMONTO_CONTINUOS_ANTERIOR"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMONTO_CONTINUOS_ANTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO_CONTINUOS_REDIMIDOS", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMONTO_CONTINUOS_REDIMIDOS"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMONTO_CONTINUOS_REDIMIDOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO_MULTIPLE2", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMONTO_MULTIPLE2"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMONTO_MULTIPLE2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO_MULTIPLE3", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMONTO_MULTIPLE3"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMONTO_MULTIPLE3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO_MULTIPLE4", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMONTO_MULTIPLE4"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMONTO_MULTIPLE4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO_MULTIPLE5", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMONTO_MULTIPLE5"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMONTO_MULTIPLE5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO_MULTIPLE6", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMONTO_MULTIPLE6"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMONTO_MULTIPLE6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO_MULTIPLE7", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMONTO_MULTIPLE7"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMONTO_MULTIPLE7;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO_SIMPLE2", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMONTO_SIMPLE2"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMONTO_SIMPLE2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO_SIMPLE3", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMONTO_SIMPLE3"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMONTO_SIMPLE3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO_SIMPLE4", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMONTO_SIMPLE4"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMONTO_SIMPLE4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO_SIMPLE5", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMONTO_SIMPLE5"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMONTO_SIMPLE5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO_SIMPLE6", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMONTO_SIMPLE6"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMONTO_SIMPLE6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO_SIMPLE7", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IMONTO_SIMPLE7"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IMONTO_SIMPLE7;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOAUTORIZACION", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["INOAUTORIZACION"])
                {
                    auxPar.Value = oCBANCOMERPARAM.INOAUTORIZACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBREAPLICACION", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["INOMBREAPLICACION"])
                {
                    auxPar.Value = oCBANCOMERPARAM.INOMBREAPLICACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBRECLIENTE", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["INOMBRECLIENTE"])
                {
                    auxPar.Value = oCBANCOMERPARAM.INOMBRECLIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUMERO_DE_BENEFICIOS", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["INUMERO_DE_BENEFICIOS"])
                {
                    auxPar.Value = oCBANCOMERPARAM.INUMERO_DE_BENEFICIOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUMEROTARJETA", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["INUMEROTARJETA"])
                {
                    auxPar.Value = oCBANCOMERPARAM.INUMEROTARJETA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUMTARJETAII", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["INUMTARJETAII"])
                {
                    auxPar.Value = oCBANCOMERPARAM.INUMTARJETAII;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PAGOSMULTIPAGOSID", FbDbType.BigInt);
                if (!(bool)oCBANCOMERPARAM.isnull["IPAGOSMULTIPAGOSID"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IPAGOSMULTIPAGOSID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PESOSREDIMIDOS", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IPESOSREDIMIDOS"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IPESOSREDIMIDOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PESOSSALDOANTERIOR", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IPESOSSALDOANTERIOR"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IPESOSSALDOANTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PESOSSALDODISPONIBLE", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IPESOSSALDODISPONIBLE"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IPESOSSALDODISPONIBLE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PESOSSALDODISPONINLEEXP", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IPESOSSALDODISPONINLEEXP"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IPESOSSALDODISPONINLEEXP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PESOSSALDOREDIMIDOSEXP", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IPESOSSALDOREDIMIDOSEXP"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IPESOSSALDOREDIMIDOSEXP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PINPAD_USO", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAM.isnull["IPINPAD_USO"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IPINPAD_USO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@POOLADJUSTTYPE", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IPOOLADJUSTTYPE"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IPOOLADJUSTTYPE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@POOLID", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IPOOLID"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IPOOLID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@POOLNUMBER", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IPOOLNUMBER"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IPOOLNUMBER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@POOLUNITLABEL", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IPOOLUNITLABEL"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IPOOLUNITLABEL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PUNTOSID", FbDbType.BigInt);
                if (!(bool)oCBANCOMERPARAM.isnull["IPUNTOSID"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IPUNTOSID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PUNTOSREDIMIDOS", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IPUNTOSREDIMIDOS"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IPUNTOSREDIMIDOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PUNTOSSALDOANTERIOR", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IPUNTOSSALDOANTERIOR"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IPUNTOSSALDOANTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PUNTOSSALDODISPONIBLE", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IPUNTOSSALDODISPONIBLE"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IPUNTOSSALDODISPONIBLE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PUNTOSSALDODISPONIBLEEXP", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IPUNTOSSALDODISPONIBLEEXP"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IPUNTOSSALDODISPONIBLEEXP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PUNTOSSALDOREDIMIDOSEXP", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IPUNTOSSALDOREDIMIDOSEXP"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IPUNTOSSALDOREDIMIDOSEXP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@R8_CODIGO_LEYENDA", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IR8_CODIGO_LEYENDA"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IR8_CODIGO_LEYENDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@R8_LEYENDA", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IR8_LEYENDA"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IR8_LEYENDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RAZON_SOCIAL", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IRAZON_SOCIAL"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IRAZON_SOCIAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIA_RESPUESTA", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IREFERENCIA_RESPUESTA"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IREFERENCIA_RESPUESTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIAAFIN", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IREFERENCIAAFIN"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IREFERENCIAAFIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQUEST", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IREQUEST"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IREQUEST;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESPDLL", FbDbType.Integer);
                if (!(bool)oCBANCOMERPARAM.isnull["IRESPDLL"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IRESPDLL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESPONSE", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IRESPONSE"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IRESPONSE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SEGMENTNUMBER", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ISEGMENTNUMBER"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ISEGMENTNUMBER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TBINES", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ITBINES"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ITBINES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPO_BENEFICIO1", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ITIPO_BENEFICIO1"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ITIPO_BENEFICIO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPO_BENEFICIO2", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ITIPO_BENEFICIO2"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ITIPO_BENEFICIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPO_BENEFICIO3", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ITIPO_BENEFICIO3"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ITIPO_BENEFICIO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPO_BENEFICIO4", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ITIPO_BENEFICIO4"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ITIPO_BENEFICIO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPO_BENEFICIO5", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ITIPO_BENEFICIO5"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ITIPO_BENEFICIO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPO_BENEFICIO6", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ITIPO_BENEFICIO6"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ITIPO_BENEFICIO6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPO_BENEFICIO7", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ITIPO_BENEFICIO7"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ITIPO_BENEFICIO7;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPO_RESPUESTA1", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ITIPO_RESPUESTA1"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ITIPO_RESPUESTA1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPO_RESPUESTA2", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ITIPO_RESPUESTA2"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ITIPO_RESPUESTA2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPO_RESPUESTA3", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ITIPO_RESPUESTA3"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ITIPO_RESPUESTA3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPO_RESPUESTA4", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ITIPO_RESPUESTA4"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ITIPO_RESPUESTA4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPO_RESPUESTA5", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ITIPO_RESPUESTA5"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ITIPO_RESPUESTA5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPO_RESPUESTA6", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ITIPO_RESPUESTA6"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ITIPO_RESPUESTA6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPO_RESPUESTA7", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ITIPO_RESPUESTA7"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ITIPO_RESPUESTA7;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOPOS", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ITIPOPOS"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ITIPOPOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TNXCONPUNTOS", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAM.isnull["ITNXCONPUNTOS"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ITNXCONPUNTOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TOPERADOR", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ITOPERADOR"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ITOPERADOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VALTIPOCARD", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IVALTIPOCARD"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IVALTIPOCARD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VIGENCIAPROMOCIONESEXP", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["IVIGENCIAPROMOCIONESEXP"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IVIGENCIAPROMOCIONESEXP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if (!(bool)oCBANCOMERPARAM.isnull["IDOCTOID"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@DOCTOPAGOID", FbDbType.BigInt);
                if (!(bool)oCBANCOMERPARAM.isnull["IDOCTOPAGOID"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IDOCTOPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@TIPOTRANSACCION", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.isnull["ITIPOTRANSACCION"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ITIPOTRANSACCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@ESTADOTRANSACCIONID", FbDbType.BigInt);
                if (!(bool)oCBANCOMERPARAM.isnull["IESTADOTRANSACCIONID"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IESTADOTRANSACCIONID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFID", FbDbType.BigInt);
                if (!(bool)oCBANCOMERPARAM.isnull["IREFID"])
                {
                    auxPar.Value = oCBANCOMERPARAM.IREFID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);






                auxPar = new FbParameter("@REQ_ISSINTJROPERADOR", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["IISSINTJROPERADOR"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.IISSINTJROPERADOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_NOMAUTORIZACION", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["INOMAUTORIZACION"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.INOMAUTORIZACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_NOMBRE", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["INOMBRE"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_PAN", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["IPAN"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.IPAN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_TOPERADOR", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["ITOPERADOR"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.ITOPERADOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_CODTRANSACTION", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["ICODTRANSACTION"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.ICODTRANSACTION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_TERMINAL", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["ITERMINAL"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.ITERMINAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_SESSION", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["ISESSION"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.ISESSION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_SECUENCIA", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["ISECUENCIA"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.ISECUENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_IMPORTE", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_PROPINA", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["IPROPINA"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.IPROPINA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_FOLIO", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["IFOLIO"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.IFOLIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_CAPEMV", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["ICAPEMV"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.ICAPEMV;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_TIPOLECTOR", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["ITIPOLECTOR"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.ITIPOLECTOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_CAPCVV2", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["ICAPCVV2"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.ICAPCVV2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_MESESFIN", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["IMESESFIN"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.IMESESFIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_PARCIALIZACION", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["IPARCIALIZACION"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.IPARCIALIZACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_PROMOCIONES", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["IPROMOCIONES"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.IPROMOCIONES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_TIPOMONEDA", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["ITIPOMONEDA"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.ITIPOMONEDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_NOAUTORIZACION", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["INOAUTORIZACION"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.INOAUTORIZACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_MODOINGRESO", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["IMODOINGRESO"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.IMODOINGRESO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_CVV2", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["ICVV2"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.ICVV2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_TRACK2", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["ITRACK2"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.ITRACK2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_NOSECUENCIA", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["INOSECUENCIA"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.INOSECUENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_IMPORTECASH", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["IIMPORTECASH"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.IIMPORTECASH;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_FECHAHORACOMERCIO", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["IFECHAHORACOMERCIO"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.IFECHAHORACOMERCIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_REFERENCIACOMERCIO", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["IREFERENCIACOMERCIO"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.IREFERENCIACOMERCIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_OTROIMPORTE", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["IOTROIMPORTE"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.IOTROIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_CLAVEOPERADOR", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["ICLAVEOPERADOR"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.ICLAVEOPERADOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_AFILIACION", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["IAFILIACION"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.IAFILIACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_NUMEROCUARTO", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["INUMEROCUARTO"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.INUMEROCUARTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_REFERENCIAFINANCIERA", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["IREFERENCIAFINANCIERA"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.IREFERENCIAFINANCIERA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_CODIGOCONDCHIP", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["ICODIGOCONDCHIP"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.ICODIGOCONDCHIP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_LONGEMVFULL", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["ILONGEMVFULL"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.ILONGEMVFULL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_DATOSEMVFULL", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["IDATOSEMVFULL"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.IDATOSEMVFULL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_LONGLEALTAD", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["ILONGLEALTAD"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.ILONGLEALTAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_DATOSLEALTAD", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["IDATOSLEALTAD"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.IDATOSLEALTAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_LONGMULTIPAGOS", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["ILONGMULTIPAGOS"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.ILONGMULTIPAGOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_DATOSMULTIPAGOS", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["IDATOSMULTIPAGOS"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.IDATOSMULTIPAGOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_LONGDATOSCIFRADOS", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["ILONGDATOSCIFRADOS"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.ILONGDATOSCIFRADOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_DATOSCIFRADOS", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["IDATOSCIFRADOS"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.IDATOSCIFRADOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_LONGCAMPANA", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["ILONGCAMPANA"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.ILONGCAMPANA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_DATOSCAMPANA", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["IDATOSCAMPANA"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.IDATOSCAMPANA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_CONVENIOCIE", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["ICONVENIOCIE"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.ICONVENIOCIE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQ_VERSION", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsRequest.isnull["IVERSION"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsRequest.IVERSION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@RESP_CODTRANSACTION", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.isnull["ICODTRANSACTION"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.ICODTRANSACTION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESP_TERMINAL", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.isnull["ITERMINAL"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.ITERMINAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESP_SESSION", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.isnull["ISESSION"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.ISESSION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESP_SECUENCIA", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.isnull["ISECUENCIA"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.ISECUENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESP_CODIGORESPUESTA", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.isnull["ICODIGORESPUESTA"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.ICODIGORESPUESTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESP_NOAUTORIZACION", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.isnull["INOAUTORIZACION"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.INOAUTORIZACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESP_AFILIACION", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.isnull["IAFILIACION"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.IAFILIACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESP_FILLER1", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.isnull["IFILLER1"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.IFILLER1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESP_IMPORTE", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESP_FILLER2", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.isnull["IFILLER2"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.IFILLER2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESP_TARJETA", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.isnull["ITARJETA"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.ITARJETA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESP_CVEOPERADOR", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.isnull["ICVEOPERADOR"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.ICVEOPERADOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESP_FILLER3", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.isnull["IFILLER3"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.IFILLER3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESP_FOLIO", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.isnull["IFOLIO"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.IFOLIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESP_LONGLEYENDA", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.isnull["ILONGLEYENDA"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.ILONGLEYENDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESP_LEYENDA", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.isnull["ILEYENDA"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.ILEYENDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESP_REFERENCIAFINAN", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.isnull["IREFERENCIAFINAN"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.IREFERENCIAFINAN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESP_LONGEMV", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.isnull["ILONGEMV"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.ILONGEMV;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESP_DATOSEMV", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.isnull["IDATOSEMV"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.IDATOSEMV;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESP_LONGLEALTAD", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.isnull["ILONGLEALTAD"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.ILONGLEALTAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESP_DATOSLEALTAD", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.isnull["IDATOSLEALTAD"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.IDATOSLEALTAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESP_REGISTRO1", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.isnull["IREGISTRO1"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.IREGISTRO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESP_REGISTRO2", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.isnull["IREGISTRO2"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.IREGISTRO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESP_REGISTRO3", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.isnull["IREGISTRO3"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.IREGISTRO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESP_REGISTRO4", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.isnull["IREGISTRO4"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.IREGISTRO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESP_REGISTRO5", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.isnull["IREGISTRO5"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.IREGISTRO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESP_LONGMULTIPAGOS", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.isnull["ILONGMULTIPAGOS"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.ILONGMULTIPAGOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESP_MULTIPAGOS", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.isnull["IMULTIPAGOS"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.IMULTIPAGOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESP_LONGDATOSCIFRADOS", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.isnull["ILONGDATOSCIFRADOS"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.ILONGDATOSCIFRADOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESP_DATOSCIFRADOS", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.isnull["IDATOSCIFRADOS"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.IDATOSCIFRADOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESP_LONGCAMPANA", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.isnull["ILONGCAMPANA"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.ILONGCAMPANA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESP_DATOSCAMPANA", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.isnull["IDATOSCAMPANA"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.IDATOSCAMPANA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESP_IDENCABEZADO", FbDbType.BigInt);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.isnull["IIDENCABEZADO"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.IIDENCABEZADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@PTS_CARDREQUEST", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.Pts.isnull["ICARDREQUEST"])
                {
                    auxPar.Value = oCBANCOMERPARAM.Pts.ICARDREQUEST;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PTS_ECOUPNUMBER", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.Pts.isnull["IECOUPNUMBER"])
                {
                    auxPar.Value = oCBANCOMERPARAM.Pts.IECOUPNUMBER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PTS_FACTOREXP", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.Pts.isnull["IFACTOREXP"])
                {
                    auxPar.Value = oCBANCOMERPARAM.Pts.IFACTOREXP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PTS_PESOSREDIMIDOS", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.Pts.isnull["IPESOSREDIMIDOS"])
                {
                    auxPar.Value = oCBANCOMERPARAM.Pts.IPESOSREDIMIDOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PTS_PESOSSALDOANTERIOR", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.Pts.isnull["IPESOSSALDOANTERIOR"])
                {
                    auxPar.Value = oCBANCOMERPARAM.Pts.IPESOSSALDOANTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PTS_PESOSSALDODISPONIBLE", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.Pts.isnull["IPESOSSALDODISPONIBLE"])
                {
                    auxPar.Value = oCBANCOMERPARAM.Pts.IPESOSSALDODISPONIBLE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PTS_PESOSSALDODISPONINLEEXP", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.Pts.isnull["IPESOSSALDODISPONINLEEXP"])
                {
                    auxPar.Value = oCBANCOMERPARAM.Pts.IPESOSSALDODISPONINLEEXP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PTS_PESOSSALDOREDIMIDOSEXP", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.Pts.isnull["IPESOSSALDOREDIMIDOSEXP"])
                {
                    auxPar.Value = oCBANCOMERPARAM.Pts.IPESOSSALDOREDIMIDOSEXP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PTS_POOLADJUSTTYPE", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.Pts.isnull["IPOOLADJUSTTYPE"])
                {
                    auxPar.Value = oCBANCOMERPARAM.Pts.IPOOLADJUSTTYPE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PTS_POOLID", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.Pts.isnull["IPOOLID"])
                {
                    auxPar.Value = oCBANCOMERPARAM.Pts.IPOOLID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PTS_POOLNUMBER", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.Pts.isnull["IPOOLNUMBER"])
                {
                    auxPar.Value = oCBANCOMERPARAM.Pts.IPOOLNUMBER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PTS_POOLUNITLABEL", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.Pts.isnull["IPOOLUNITLABEL"])
                {
                    auxPar.Value = oCBANCOMERPARAM.Pts.IPOOLUNITLABEL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PTS_PUNTOSREDIMIDOS", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.Pts.isnull["IPUNTOSREDIMIDOS"])
                {
                    auxPar.Value = oCBANCOMERPARAM.Pts.IPUNTOSREDIMIDOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PTS_PUNTOSSALDOANTERIOR", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.Pts.isnull["IPUNTOSSALDOANTERIOR"])
                {
                    auxPar.Value = oCBANCOMERPARAM.Pts.IPUNTOSSALDOANTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PTS_PUNTOSSALDODISPONIBLE", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.Pts.isnull["IPUNTOSSALDODISPONIBLE"])
                {
                    auxPar.Value = oCBANCOMERPARAM.Pts.IPUNTOSSALDODISPONIBLE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PTS_PUNTOSSALDODISPONIBLEEXP", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.Pts.isnull["IPUNTOSSALDODISPONIBLEEXP"])
                {
                    auxPar.Value = oCBANCOMERPARAM.Pts.IPUNTOSSALDODISPONIBLEEXP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PTS_PUNTOSSALDOREDIMIDOEXP", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.Pts.isnull["IPUNTOSSALDOREDIMIDOEXP"])
                {
                    auxPar.Value = oCBANCOMERPARAM.Pts.IPUNTOSSALDOREDIMIDOEXP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PTS_SEGMENTNUMBER", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.Pts.isnull["ISEGMENTNUMBER"])
                {
                    auxPar.Value = oCBANCOMERPARAM.Pts.ISEGMENTNUMBER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PTS_TIPOPOS", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.Pts.isnull["ITIPOPOS"])
                {
                    auxPar.Value = oCBANCOMERPARAM.Pts.ITIPOPOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PTS_VIGENCIAPROMOCIONEXP", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.Pts.isnull["IVIGENCIAPROMOCIONEXP"])
                {
                    auxPar.Value = oCBANCOMERPARAM.Pts.IVIGENCIAPROMOCIONEXP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@ENC_ENCABEZADOIP", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.C00_Encabezado.isnull["IENCABEZADOIP"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.C00_Encabezado.IENCABEZADOIP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ENC_MENSAJE", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.C00_Encabezado.isnull["IMENSAJE"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.C00_Encabezado.IMENSAJE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ENC_TIPOMENSAJE", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.C00_Encabezado.isnull["ITIPOMENSAJE"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.C00_Encabezado.ITIPOMENSAJE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ENC_IDSANDF", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.C00_Encabezado.isnull["IIDSANDF"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.C00_Encabezado.IIDSANDF;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ENC_IDSECUENCIAL", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.C00_Encabezado.isnull["IIDSECUENCIAL"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.C00_Encabezado.IIDSECUENCIAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ENC_DIRECCIONIP", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.C00_Encabezado.isnull["IDIRECCIONIP"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.C00_Encabezado.IDIRECCIONIP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ENC_ENCABEZADOVERSION", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.C00_Encabezado.isnull["IENCABEZADOVERSION"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.C00_Encabezado.IENCABEZADOVERSION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ENC_MACADDRESS", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.C00_Encabezado.isnull["IMACADDRESS"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.C00_Encabezado.IMACADDRESS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ENC_VERSIONDLL", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.C00_Encabezado.isnull["IVERSIONDLL"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.C00_Encabezado.IVERSIONDLL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ENC_CONECTADOPINPAD", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.C00_Encabezado.isnull["ICONECTADOPINPAD"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.C00_Encabezado.ICONECTADOPINPAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ENC_USOPINPAD", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.C00_Encabezado.isnull["IUSOPINPAD"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.C00_Encabezado.IUSOPINPAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ENC_LONGSEBEHPOS", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.C00_Encabezado.isnull["ILONGSEBEHPOS"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.C00_Encabezado.ILONGSEBEHPOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ENC_MACADDALTERNATIVA", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.C00_Encabezado.isnull["IMACADDALTERNATIVA"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.C00_Encabezado.IMACADDALTERNATIVA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ENC_PINPADDETECTADO", FbDbType.Char);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.C00_Encabezado.isnull["IPINPADDETECTADO"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.C00_Encabezado.IPINPADDETECTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ENC_QPSENLONGMACADD", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.C00_Encabezado.isnull["IQPSENLONGMACADD"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.C00_Encabezado.IQPSENLONGMACADD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ENC_TELECARGAPINPAD", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAM.ClsResponse.C00_Encabezado.isnull["ITELECARGAPINPAD"])
                {
                    auxPar.Value = oCBANCOMERPARAM.ClsResponse.C00_Encabezado.ITELECARGAPINPAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@BANCOMERPARAMID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);



                string commandText = @"BANCOMERPARAM_GUARDAR";

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
                        this.iComentario = "Hubo un error ";
                        return false;
                    }
                }



                    if ((long)arParms[arParms.Length - 2].Value != 0)
                    {
                        oCBANCOMERPARAM.IID = (long)arParms[arParms.Length - 2].Value;
                        
                    }



                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }






        public CBANCOMERPARAMBE seleccionarBANCOMERPARAM_COMPUESTO(CBANCOMERPARAMBE oCBANCOMERPARAM, FbTransaction st)
        {




            CBANCOMERPARAMBE retorno = new CBANCOMERPARAMBE();

            try
            {
                retorno = this.seleccionarBANCOMERPARAM(oCBANCOMERPARAM, st);

                if(retorno.ICLSREQUESTID != 0)
                {
                    CREQUESTBANCOMERBE buffer = new CREQUESTBANCOMERBE();
                    CREQUESTBANCOMERD bufferD = new CREQUESTBANCOMERD();
                    buffer.IID = retorno.ICLSREQUESTID;
                    buffer = bufferD.seleccionarREQUESTBANCOMER(buffer, st);

                    if(buffer != null)
                    {
                        retorno.ClsRequest = buffer;
                    }
                }



                if (retorno.ICLSRESPONSEID != 0)
                {
                    CRESPONSEBANCOMERBE buffer = new CRESPONSEBANCOMERBE();
                    CRESPONSEBANCOMERD bufferD = new CRESPONSEBANCOMERD();
                    buffer.IID = retorno.ICLSRESPONSEID;
                    buffer = bufferD.seleccionarRESPONSEBANCOMER(buffer, st);

                    if (buffer != null)
                    {


                        if (buffer.IIDENCABEZADO != 0)
                        {
                            CENCABEZADORESPONSEBANCOMERBE buffer2 = new CENCABEZADORESPONSEBANCOMERBE();
                            CENCABEZADORESPONSEBANCOMERD buffer2D = new CENCABEZADORESPONSEBANCOMERD();
                            buffer2.IID = buffer.IIDENCABEZADO;
                            buffer2 = buffer2D.seleccionarENCABEZADORESPONSEBANCOMER(buffer2, st);

                            if (buffer2 != null)
                            {
                                buffer.C00_Encabezado = buffer2;
                            }
                        }

                        retorno.ClsResponse = buffer;


                    }
                }


                if (retorno.IPUNTOSID != 0)
                {
                    CSTRUCPTOSBANCOMERBE buffer = new CSTRUCPTOSBANCOMERBE();
                    CSTRUCPTOSBANCOMERD bufferD = new CSTRUCPTOSBANCOMERD();
                    buffer.IID = retorno.ICLSRESPONSEID;
                    buffer = bufferD.seleccionarSTRUCPTOSBANCOMER(buffer, st);

                    if (buffer != null)
                    {
                        retorno.Pts = buffer;
                    }
                }



                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }





        public bool CambiarBANCOMERPARM_ESTADO_Y_REFID(CBANCOMERPARAMBE oCBANCOMERPARAMNuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ESTADOTRANSACCIONID", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IESTADOTRANSACCIONID"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IESTADOTRANSACCIONID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@REFID", FbDbType.VarChar);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IREFID"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IREFID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCBANCOMERPARAMNuevo.isnull["IID"])
                {
                    auxPar.Value = oCBANCOMERPARAMNuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update BANCOMERPARAM
  set
ESTADOTRANSACCIONID = @ESTADOTRANSACCIONID,
REFID = @REFID
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





        public CBANCOMERPARAMD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
