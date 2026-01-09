using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Odbc;
using System.IO;
using iPosData;
using iPosBusinessEntity;
using FirebirdSql.Data.FirebirdClient;
using System.Collections;
using Microsoft.ApplicationBlocks.Data;
using ConexionesBD;
using System.Data.OleDb;
using System.ComponentModel;


namespace iPos
{
    public class WebServiceIpos
    {


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




        public bool EnviarExistencias(FbTransaction st)
        {

            //bool retorno = true;
            this.iComentario = "";
            //FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            bool bRes = true;
            com.server.ipos.Service1 service1 = new com.server.ipos.Service1();
            string productoClave = "";
            decimal productoCantidad = 0;

            
            string pLOTE = "";
            DateTime pFECHAVENCE = DateTime.MinValue;
            string pLINEACLAVE = "";
            string pMARCACLAVE = "";
            string pPROVEEDORCLAVE = "";
            string pPEDIMENTO = "";
            DateTime pFECHAIMPORTACION = DateTime.MinValue;
            string pADUANA = "";
            decimal pTIPOCAMBIO = 1;
            string pALMACENCLAVE = "";


            CSUCURSALD sucursalD = new CSUCURSALD();
            CSUCURSALBE sucursalBE = new CSUCURSALBE();
            
            CGRUPOSUCURSALBE grupoSucursalBE = new CGRUPOSUCURSALBE();
            CGRUPOSUCURSALD grupoSucursalD = new CGRUPOSUCURSALD();

            CMOVTOD movtoD = new CMOVTOD();
            CMOVTOBE movtoBE = new CMOVTOBE();


            sucursalBE.IID = iPos.CurrentUserID.CurrentParameters.ISUCURSALID;
            sucursalBE = sucursalD.seleccionarSUCURSAL(sucursalBE, null);
            if (sucursalBE == null)
            {
                return false;
            }

            
            grupoSucursalBE.IID = sucursalBE.IGRUPOSUCURSALID;
            grupoSucursalBE = grupoSucursalD.seleccionarGRUPOSUCURSAL(grupoSucursalBE, null);
            if (grupoSucursalBE == null)
            {
                return false;
            }


            try
            {
                parts = new ArrayList();

                /*CmdTxt = @"select movto.id  MOVTOID,
                                  inventario.productoid productoId,
                                  producto.clave CLAVE,
                                  sum(inventario.cantidad) CANTIDAD
                           from movto inner join 
                            inventario on inventario.productoid = movto.productoid
                            inner join producto on producto.id = inventario.productoid
                             where EXISTENCIASEXPORTADAS = 'N'
                            group by movto.id,inventario.productoid, producto.clave 
                            order by movto.id";*/

                CmdTxt = @"select inventario.productoid PRODUCTOID,
                                  producto.clave CLAVE,
                                  sum(inventario.cantidad) CANTIDAD ,
                                  INVENTARIO.LOTE,
                                  INVENTARIO.FECHAVENCE,
                                  linea.CLAVE LINEACLAVE ,
                                  marca.CLAVE MARCACLAVE,
                                  provee.CLAVE PROVEEDORCLAVE,
                                  LOTESIMPORTADOS.PEDIMENTO,
                                  LOTESIMPORTADOS.FECHAIMPORTACION,
                                  LOTESIMPORTADOS.ADUANA,
                                  LOTESIMPORTADOS.TIPOCAMBIO,
                                  almacen.clave  ALMACENCLAVE


                           from producto inner join 
                            inventario  on producto.id = inventario.productoid  left join
                            linea on linea.id = producto.lineaid  left join
                            marca on marca.id = producto.marcaid left join
                            persona provee on provee.id = producto.proveedor1id left join
                            lotesimportados on lotesimportados.id = inventario.loteimportado left join
                            almacen on almacen.id = coalesce(inventario.almacenid,1)
                             where producto.EXISTENCIASEXPORTADAS = 'N'
                            group by inventario.productoid,
                                  producto.clave ,
                                  INVENTARIO.LOTE,
                                  INVENTARIO.FECHAVENCE,
                                  linea.CLAVE  ,
                                  marca.CLAVE ,
                                  provee.CLAVE ,
                                  LOTESIMPORTADOS.pedimento,
                                  LOTESIMPORTADOS.fechaimportacion,
                                  LOTESIMPORTADOS.aduana,
                                  LOTESIMPORTADOS.tipocambio,
                                  almacen.clave
                            order by inventario.productoid";

                
                             


                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null && pcn == null)
                    dr = SqlHelper.ExecuteReader(ConexionBD.ConexionString(), CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);

                while (dr.Read())
                {

                    //limpiar valores
                    movtoBE = new CMOVTOBE();
                    productoClave = "";
                    productoCantidad = 0;
                    pLOTE = "";
                    pFECHAVENCE = DateTime.MinValue;
                    pLINEACLAVE = "";
                    pMARCACLAVE = "";
                    pPROVEEDORCLAVE = "";
                    pPEDIMENTO = "";
                    pFECHAIMPORTACION = DateTime.MinValue;
                    pADUANA = "";
                    pTIPOCAMBIO = 1;
                    pALMACENCLAVE = "";



                    if (dr["CLAVE"] != System.DBNull.Value)
                    {

                        if (dr["CLAVE"].ToString() == "")
                            continue;

                        productoClave = dr["CLAVE"].ToString();
                    }
                    else
                        continue;


                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        productoCantidad = (decimal)(dr["CANTIDAD"]);
                    }
                    else
                        productoCantidad = 0;


                     if (dr["PRODUCTOID"] != System.DBNull.Value)
                    {
                        movtoBE.IPRODUCTOID = (long)(dr["PRODUCTOID"]);
                    }
                    else
                         continue;


                    //para la version 2

                     if (dr["LOTE"] != System.DBNull.Value)
                     {
                         pLOTE = dr["LOTE"].ToString();
                     }
                     if (dr["FECHAVENCE"] != System.DBNull.Value)
                     {
                         pFECHAVENCE = (DateTime)dr["FECHAVENCE"];
                     }
                     if (dr["LINEACLAVE"] != System.DBNull.Value)
                     {
                         pLINEACLAVE = dr["LINEACLAVE"].ToString();
                     }
                     if (dr["MARCACLAVE"] != System.DBNull.Value)
                     {
                         pMARCACLAVE = dr["MARCACLAVE"].ToString();
                     }
                     if (dr["PROVEEDORCLAVE"] != System.DBNull.Value)
                     {
                         pPROVEEDORCLAVE = dr["PROVEEDORCLAVE"].ToString();
                     }
                     if (dr["PEDIMENTO"] != System.DBNull.Value)
                     {
                         pPEDIMENTO = dr["PEDIMENTO"].ToString();
                     }
                     if (dr["FECHAIMPORTACION"] != System.DBNull.Value)
                     {
                         pFECHAIMPORTACION = (DateTime)dr["FECHAIMPORTACION"];
                     }
                     if (dr["ADUANA"] != System.DBNull.Value)
                     {
                         pADUANA = dr["ADUANA"].ToString();
                     }
                    
                    if (dr["TIPOCAMBIO"] != System.DBNull.Value)
                    {
                        pTIPOCAMBIO = (decimal)(dr["TIPOCAMBIO"]);
                    }
                    else
                        pTIPOCAMBIO = 0;


                    if (dr["ALMACENCLAVE"] != System.DBNull.Value)
                    {
                        pALMACENCLAVE = dr["ALMACENCLAVE"].ToString();
                    }
                    pALMACENCLAVE = pALMACENCLAVE != null && pALMACENCLAVE.Trim().Count() > 0 ? pALMACENCLAVE : DBValues._DOCTO_ALMACEN_CLAVE_DEFAULT;

                    string strRespuesta = "";

                     string strWebService = CurrentUserID.CurrentParameters.IUSARCONEXIONLOCAL.Equals("S") ? (CurrentUserID.CurrentParameters.ILOCALWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.ILOCALWEBSERVICE.Trim()) : (CurrentUserID.CurrentParameters.IWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.IWEBSERVICE.Trim());
                     if (strWebService.Trim().ToLower().Trim().ToLower().Equals(DBValues._HOSTS_KIKOLERIA))
                     {

                         com.servebeer.kikoleria.Service1 serviceA = new com.servebeer.kikoleria.Service1();
                        strRespuesta = serviceA.CambiarExistenciasBD(iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                           grupoSucursalBE.ICLAVE,
                           pALMACENCLAVE,
                            productoClave,
                            productoCantidad,
                            0,
                            DateTime.Today,
                            iPos.Tools.FTPManagement.m_strFTPFolderWs,
                            iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                     }
                     else
                     {
                         if (strWebService.Trim().Length > 0)
                         {
                             service1.Url = strWebService.Trim();
                         }

                         if (iPos.CurrentUserID.CurrentParameters.IVERSIONWSEXISTENCIAS == 2)
                         {

                             strRespuesta = service1.CambiarExistenciasBD2(iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                grupoSucursalBE.ICLAVE,
                                pALMACENCLAVE,
                                productoClave,
                                productoCantidad,
                                0,
                                DateTime.Today,
                                pLOTE,
                                pFECHAVENCE,
                                pPROVEEDORCLAVE,
                                pLINEACLAVE,
                                pMARCACLAVE,
                                pPEDIMENTO,
                                pFECHAIMPORTACION,
                                pADUANA,
                                pTIPOCAMBIO,
                                iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                         }
                         else
                         {
                             strRespuesta = service1.CambiarExistenciasBD(iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                grupoSucursalBE.ICLAVE,
                                pALMACENCLAVE,
                                productoClave,
                                productoCantidad,
                                0,
                                DateTime.Today,
                                iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                         }
                     }

                     bRes = strRespuesta.Equals("exito");

                    if (bRes)
                    {
                        //actualiza movto
                        movtoBE.IEXISTENCIASEXPORTADAS = "S";
                        movtoD.CambiarExistenciasExport(movtoBE, null);
                    }

                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }






        public bool EnviarInventarioExist(FbTransaction st)
        {

            //bool retorno = true;
            this.iComentario = "";
            //FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            bool bRes = true;
            com.server.ipos.Service1 service1 = new com.server.ipos.Service1();

            string productoClave = "";
            decimal productoCantidad = 0;

            string pLOTE = "";
            DateTime pFECHAVENCE = DateTime.MinValue;
            string pLINEACLAVE = "";
            string pMARCACLAVE = "";
            string pPROVEEDORCLAVE = "";
            string pPEDIMENTO = "";
            DateTime pFECHAIMPORTACION = DateTime.MinValue;
            string pADUANA = "";
            decimal pTIPOCAMBIO = 1;
            string pALMACENCLAVE = "";


            CSUCURSALD sucursalD = new CSUCURSALD();
            CSUCURSALBE sucursalBE = new CSUCURSALBE();

            CGRUPOSUCURSALBE grupoSucursalBE = new CGRUPOSUCURSALBE();
            CGRUPOSUCURSALD grupoSucursalD = new CGRUPOSUCURSALD();

            CMOVTOD movtoD = new CMOVTOD();
            CMOVTOBE movtoBE = new CMOVTOBE();


            sucursalBE.IID = iPos.CurrentUserID.CurrentParameters.ISUCURSALID;
            sucursalBE = sucursalD.seleccionarSUCURSAL(sucursalBE, null);
            if (sucursalBE == null)
            {
                return false;
            }


            grupoSucursalBE.IID = sucursalBE.IGRUPOSUCURSALID;
            grupoSucursalBE = grupoSucursalD.seleccionarGRUPOSUCURSAL(grupoSucursalBE, null);
            if (grupoSucursalBE == null)
            {
                return false;
            }


            try
            {
                parts = new ArrayList();

                CmdTxt = @"select producto.id productoId,
                                  producto.clave CLAVE,
                                  sum(inventario.cantidad) CANTIDAD ,
                                  INVENTARIO.LOTE,
                                  INVENTARIO.FECHAVENCE,
                                  linea.CLAVE LINEACLAVE ,
                                  marca.CLAVE MARCACLAVE,
                                  provee.CLAVE PROVEEDORCLAVE,
                                  LOTESIMPORTADOS.PEDIMENTO,
                                  LOTESIMPORTADOS.FECHAIMPORTACION,
                                  LOTESIMPORTADOS.ADUANA,
                                  LOTESIMPORTADOS.TIPOCAMBIO,
                                  almacen.clave  ALMACENCLAVE
                           from  
                            producto left join inventario on inventario.productoid = producto.id left join
                            linea on linea.id = producto.lineaid  left join
                            marca on marca.id = producto.marcaid left join
                            persona provee on provee.id = producto.proveedor1id left join
                            lotesimportados on lotesimportados.id = inventario.loteimportado left join
                            almacen on almacen.id = coalesce(inventario.almacenid,1)
                            group by producto.id, producto.clave ,
                                  INVENTARIO.LOTE,
                                  INVENTARIO.FECHAVENCE,
                                  linea.CLAVE  ,
                                  marca.CLAVE ,
                                  provee.CLAVE ,
                                  LOTESIMPORTADOS.pedimento,
                                  LOTESIMPORTADOS.fechaimportacion,
                                  LOTESIMPORTADOS.aduana,
                                  LOTESIMPORTADOS.tipocambio,
                                  almacen.clave
                            order by producto.id";


                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(ConexionBD.ConexionString(), CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);

                while (dr.Read())
                {
                    //resetear valores
                    movtoBE = new CMOVTOBE();

                    productoClave = "";
                    productoCantidad = 0;

                    pLOTE = "";
                    pFECHAVENCE = DateTime.MinValue;
                    pLINEACLAVE = "";
                    pMARCACLAVE = "";
                    pPROVEEDORCLAVE = "";
                    pPEDIMENTO = "";
                    pFECHAIMPORTACION = DateTime.MinValue;
                    pADUANA = "";
                    pTIPOCAMBIO = 1;
                    pALMACENCLAVE = "";

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {

                        if (dr["CLAVE"].ToString() == "")
                            continue;

                        productoClave = dr["CLAVE"].ToString();
                    }
                    else
                        continue;


                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        productoCantidad = (decimal)(dr["CANTIDAD"]);
                    }
                    else
                        productoCantidad = 0;
                    //para la version 2

                    if (dr["LOTE"] != System.DBNull.Value)
                    {
                        pLOTE = dr["LOTE"].ToString();
                    }
                    if (dr["FECHAVENCE"] != System.DBNull.Value)
                    {
                        pFECHAVENCE = (DateTime)dr["FECHAVENCE"];
                    }
                    if (dr["LINEACLAVE"] != System.DBNull.Value)
                    {
                        pLINEACLAVE = dr["LINEACLAVE"].ToString();
                    }
                    if (dr["MARCACLAVE"] != System.DBNull.Value)
                    {
                        pMARCACLAVE = dr["MARCACLAVE"].ToString();
                    }
                    if (dr["PROVEEDORCLAVE"] != System.DBNull.Value)
                    {
                        pPROVEEDORCLAVE = dr["PROVEEDORCLAVE"].ToString();
                    }
                    if (dr["PEDIMENTO"] != System.DBNull.Value)
                    {
                        pPEDIMENTO = dr["PEDIMENTO"].ToString();
                    }
                    if (dr["FECHAIMPORTACION"] != System.DBNull.Value)
                    {
                        pFECHAIMPORTACION = (DateTime)dr["FECHAIMPORTACION"];
                    }
                    if (dr["ADUANA"] != System.DBNull.Value)
                    {
                        pADUANA = dr["ADUANA"].ToString();
                    }

                    if (dr["TIPOCAMBIO"] != System.DBNull.Value)
                    {
                        pTIPOCAMBIO = (decimal)(dr["TIPOCAMBIO"]);
                    }
                    else
                        pTIPOCAMBIO = 0;



                    if (dr["ALMACENCLAVE"] != System.DBNull.Value)
                    {
                        pALMACENCLAVE = dr["ALMACENCLAVE"].ToString();
                    }
                    pALMACENCLAVE = pALMACENCLAVE != null && pALMACENCLAVE.Trim().Count() > 0 ? pALMACENCLAVE : DBValues._DOCTO_ALMACEN_CLAVE_DEFAULT;




                    string strRespuesta = "";

                    string strWebService = CurrentUserID.CurrentParameters.IUSARCONEXIONLOCAL.Equals("S") ? CurrentUserID.CurrentParameters.ILOCALWEBSERVICE.Trim() : CurrentUserID.CurrentParameters.IWEBSERVICE.Trim();
                    if (strWebService.Trim().ToLower().Equals(DBValues._HOSTS_KIKOLERIA))
                    {

                        com.servebeer.kikoleria.Service1 serviceA = new com.servebeer.kikoleria.Service1();

                        strRespuesta = serviceA.CambiarExistenciasBD(iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                            grupoSucursalBE.ICLAVE,
                            pALMACENCLAVE,
                            productoClave,
                            productoCantidad,
                            0,
                            DateTime.Today,
                            iPos.Tools.FTPManagement.m_strFTPFolderWs,
                            iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                    }
                    else
                    {
                        if (strWebService.Trim().Length > 0)
                        {
                            service1.Url = strWebService.Trim();
                        }


                        if (iPos.CurrentUserID.CurrentParameters.IVERSIONWSEXISTENCIAS == 2)
                        {

                            strRespuesta = service1.CambiarExistenciasBD2(iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                               grupoSucursalBE.ICLAVE,
                               pALMACENCLAVE,
                               productoClave,
                               productoCantidad,
                               0,
                               DateTime.Today,
                               pLOTE,
                               pFECHAVENCE,
                               pPROVEEDORCLAVE,
                               pLINEACLAVE,
                               pMARCACLAVE,
                               pPEDIMENTO,
                               pFECHAIMPORTACION,
                               pADUANA,
                               pTIPOCAMBIO,
                               iPos.Tools.FTPManagement.m_strFTPFolderWs,
                               iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                        }
                        else
                        {
                            strRespuesta = service1.CambiarExistenciasBD(iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                grupoSucursalBE.ICLAVE,
                                pALMACENCLAVE,
                                productoClave,
                                productoCantidad,
                                0,
                                DateTime.Today,
                                iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                        }

                    }


                    bRes = strRespuesta.Equals("exito");
                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }





        public bool EnviarInventarioTest(FbTransaction st)
        {

            //bool retorno = true;
            this.iComentario = "";
            //FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            bool bRes = true;
            com.server.ipos.Service1 service1 = new com.server.ipos.Service1();

            string productoClave = "";
            decimal productoCantidad = 0;

            string pLOTE = "";
            DateTime pFECHAVENCE = DateTime.MinValue;
            string pLINEACLAVE = "";
            string pMARCACLAVE = "";
            string pPROVEEDORCLAVE = "";
            string pPEDIMENTO = "";
            DateTime pFECHAIMPORTACION = DateTime.MinValue;
            string pADUANA = "";
            decimal pTIPOCAMBIO = 1;


            CSUCURSALD sucursalD = new CSUCURSALD();
            CSUCURSALBE sucursalBE = new CSUCURSALBE();

            CGRUPOSUCURSALBE grupoSucursalBE = new CGRUPOSUCURSALBE();
            CGRUPOSUCURSALD grupoSucursalD = new CGRUPOSUCURSALD();

            CMOVTOD movtoD = new CMOVTOD();
            CMOVTOBE movtoBE = new CMOVTOBE();


            sucursalBE.IID = iPos.CurrentUserID.CurrentParameters.ISUCURSALID;
            sucursalBE = sucursalD.seleccionarSUCURSAL(sucursalBE, null);
            if (sucursalBE == null)
            {
                return false;
            }


            grupoSucursalBE.IID = sucursalBE.IGRUPOSUCURSALID;
            grupoSucursalBE = grupoSucursalD.seleccionarGRUPOSUCURSAL(grupoSucursalBE, null);
            if (grupoSucursalBE == null)
            {
                return false;
            }


            try
            {
                parts = new ArrayList();

                CmdTxt = @"select producto.id productoId,
                                  producto.clave CLAVE,
                                  sum(inventario.cantidad) CANTIDAD,
                                  INVENTARIO.LOTE,
                                  INVENTARIO.FECHAVENCE,
                                  linea.CLAVE LINEACLAVE ,
                                  marca.CLAVE MARCACLAVE,
                                  provee.CLAVE PROVEEDORCLAVE,
                                  LOTESIMPORTADOS.PEDIMENTO,
                                  LOTESIMPORTADOS.FECHAIMPORTACION,
                                  LOTESIMPORTADOS.ADUANA,
                                  LOTESIMPORTADOS.TIPOCAMBIO
                           from  
                            producto left join inventario on inventario.productoid = producto.id left join
                            linea on linea.id = producto.lineaid  left join
                            marca on marca.id = producto.marcaid left join
                            persona provee on provee.id = producto.proveedor1id left join
                            lotesimportados on lotesimportados.id = inventario.loteimportado
                            group by producto.id, producto.clave ,
                                  INVENTARIO.LOTE,
                                  INVENTARIO.FECHAVENCE,
                                  linea.CLAVE  ,
                                  marca.CLAVE ,
                                  provee.CLAVE ,
                                  LOTESIMPORTADOS.pedimento,
                                  LOTESIMPORTADOS.fechaimportacion,
                                  LOTESIMPORTADOS.aduana,
                                  LOTESIMPORTADOS.tipocambio
                            order by producto.id";


                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(ConexionBD.ConexionString(), CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);

                while (dr.Read())
                {

                    //limpiar valores
                    movtoBE = new CMOVTOBE();
                    productoClave = "";
                    productoCantidad = 0;
                    pLOTE = "";
                    pFECHAVENCE = DateTime.MinValue;
                    pLINEACLAVE = "";
                    pMARCACLAVE = "";
                    pPROVEEDORCLAVE = "";
                    pPEDIMENTO = "";
                    pFECHAIMPORTACION = DateTime.MinValue;
                    pADUANA = "";
                    pTIPOCAMBIO = 1;


                    if (dr["CLAVE"] != System.DBNull.Value)
                    {

                        if (dr["CLAVE"].ToString() == "")
                            continue;

                        productoClave = dr["CLAVE"].ToString();
                    }
                    else
                        continue;


                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        productoCantidad = (decimal)(dr["CANTIDAD"]);
                    }
                    else
                        productoCantidad = 0;

                    //para la version 2

                    if (dr["LOTE"] != System.DBNull.Value)
                    {
                        pLOTE = dr["LOTE"].ToString();
                    }
                    if (dr["FECHAVENCE"] != System.DBNull.Value)
                    {
                        pFECHAVENCE = (DateTime)dr["FECHAVENCE"];
                    }
                    if (dr["LINEACLAVE"] != System.DBNull.Value)
                    {
                        pLINEACLAVE = dr["LINEACLAVE"].ToString();
                    }
                    if (dr["MARCACLAVE"] != System.DBNull.Value)
                    {
                        pMARCACLAVE = dr["MARCACLAVE"].ToString();
                    }
                    if (dr["PROVEEDORCLAVE"] != System.DBNull.Value)
                    {
                        pPROVEEDORCLAVE = dr["PROVEEDORCLAVE"].ToString();
                    }
                    if (dr["PEDIMENTO"] != System.DBNull.Value)
                    {
                        pPEDIMENTO = dr["PEDIMENTO"].ToString();
                    }
                    if (dr["FECHAIMPORTACION"] != System.DBNull.Value)
                    {
                        pFECHAIMPORTACION = (DateTime)dr["FECHAIMPORTACION"];
                    }
                    if (dr["ADUANA"] != System.DBNull.Value)
                    {
                        pADUANA = dr["ADUANA"].ToString();
                    }

                    if (dr["TIPOCAMBIO"] != System.DBNull.Value)
                    {
                        pTIPOCAMBIO = (decimal)(dr["TIPOCAMBIO"]);
                    }
                    else
                        pTIPOCAMBIO = 0;



                    string strRespuesta = "";

                    string strWebService = CurrentUserID.CurrentParameters.IUSARCONEXIONLOCAL.Equals("S") ? CurrentUserID.CurrentParameters.ILOCALWEBSERVICE.Trim() : CurrentUserID.CurrentParameters.IWEBSERVICE.Trim();
                    if (strWebService.Trim().ToLower().Equals(DBValues._HOSTS_KIKOLERIA))
                    {

                        com.servebeer.kikoleria.Service1 serviceA = new com.servebeer.kikoleria.Service1();

                        strRespuesta = serviceA.CambiarExistenciasBD(iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                            grupoSucursalBE.ICLAVE,
                            DBValues._DOCTO_ALMACEN_CLAVE_DEFAULT,
                            productoClave,
                            productoCantidad,
                            0,
                            DateTime.Today,
                            iPos.Tools.FTPManagement.m_strFTPFolderWs,
                            iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                    }
                    else
                    {
                        if (strWebService.Trim().Length > 0)
                        {
                            service1.Url = strWebService.Trim();
                        }

                        if (iPos.CurrentUserID.CurrentParameters.IVERSIONWSEXISTENCIAS == 2)
                        {

                            strRespuesta = service1.CambiarExistenciasBD2(iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                               grupoSucursalBE.ICLAVE,
                               DBValues._DOCTO_ALMACEN_CLAVE_DEFAULT,
                               productoClave,
                               productoCantidad,
                               0,
                               DateTime.Today,
                               pLOTE,
                               pFECHAVENCE,
                               pPROVEEDORCLAVE,
                               pLINEACLAVE,
                               pMARCACLAVE,
                               pPEDIMENTO,
                               pFECHAIMPORTACION,
                               pADUANA,
                               pTIPOCAMBIO,
                               iPos.Tools.FTPManagement.m_strFTPFolderWs,
                               iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                        }
                        else
                        {


                            strRespuesta = service1.CambiarExistenciasBD(iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                grupoSucursalBE.ICLAVE,
                                DBValues._DOCTO_ALMACEN_CLAVE_DEFAULT,
                                productoClave,
                                productoCantidad,
                                0,
                                DateTime.Today,
                                iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                        }

                    }


                    bRes = strRespuesta.Equals("exito");


                    if (iPos.CurrentUserID.CurrentParameters.IVERSIONWSEXISTENCIAS == 2)
                    {
                        service1.LeerExistenciasBDV2(grupoSucursalBE.ICLAVE, productoClave, iPos.Tools.FTPManagement.m_strFTPFolderWs, iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                    }
                    else
                    {
                        service1.LeerExistenciasBD(grupoSucursalBE.ICLAVE, productoClave, iPos.Tools.FTPManagement.m_strFTPFolderWs, iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                    }
                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }



        public bool LeerExistencias(string productoClave, bool bVerTodasLasSucursales, bool bVerMatriz)
        {


            CSUCURSALD sucursalD = new CSUCURSALD();
            CSUCURSALBE sucursalBE = new CSUCURSALBE();

            CGRUPOSUCURSALBE grupoSucursalBE = new CGRUPOSUCURSALBE();
            CGRUPOSUCURSALD grupoSucursalD = new CGRUPOSUCURSALD();

            CMOVTOD movtoD = new CMOVTOD();
            CMOVTOBE movtoBE = new CMOVTOBE();



            sucursalBE.IID = iPos.CurrentUserID.CurrentParameters.ISUCURSALID;
            sucursalBE = sucursalD.seleccionarSUCURSAL(sucursalBE, null);
            if (sucursalBE == null)
            {
                return false;
            }


            String strGrupo = "";


            if (!bVerTodasLasSucursales)
            {
                grupoSucursalBE.IID = sucursalBE.IGRUPOSUCURSALID;
                grupoSucursalBE = grupoSucursalD.seleccionarGRUPOSUCURSAL(grupoSucursalBE, null);
                if (grupoSucursalBE == null)
                {
                    return false;
                }

                strGrupo = grupoSucursalBE.ICLAVE;


                if(bVerMatriz)
                {
                    CSUCURSALBE sucursalMatrizBE = sucursalD.seleccionarSUCURSALMATRIZ(null);
                    if (sucursalMatrizBE != null)
                    {
                        strGrupo += "+++" + sucursalMatrizBE.ICLAVE;
                    }
                }
            }


            string strWebService = CurrentUserID.CurrentParameters.IUSARCONEXIONLOCAL.Equals("S") ? (CurrentUserID.CurrentParameters.ILOCALWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.ILOCALWEBSERVICE.Trim()) : (CurrentUserID.CurrentParameters.IWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.IWEBSERVICE.Trim());
            if (strWebService.Trim().ToLower().Equals(DBValues._HOSTS_KIKOLERIA))
            {

                com.servebeer.kikoleria.Service1 serviceA = new com.servebeer.kikoleria.Service1();

                com.servebeer.kikoleria.CEXIST_SUCURSALBE[] existSuc = serviceA.LeerExistenciasBD(strGrupo, productoClave,
                            iPos.Tools.FTPManagement.m_strFTPFolderWs,
                            iPos.Tools.FTPManagement.m_strFTPFolderPassWs);

                return ImportarExistenciasBD_A(existSuc);
            }
            else
            {

                com.server.ipos.Service1 service1 = new com.server.ipos.Service1();
                if (strWebService.Trim().Length > 0)
                {
                    service1.Url = strWebService.Trim();
                }

                com.server.ipos.CEXIST_SUCURSALBE[] existSuc = null;
                if (iPos.CurrentUserID.CurrentParameters.IVERSIONWSEXISTENCIAS == 2)
                {
                    existSuc = service1.LeerExistenciasBDV2(strGrupo, productoClave,
                                iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                }
                else
                {

                    existSuc = service1.LeerExistenciasBD(strGrupo, productoClave,
                                iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                }

                return ImportarExistenciasBD(existSuc);
            }
         }


        

        public bool ImportarExistenciasBD(com.server.ipos.CEXIST_SUCURSALBE[] existSuc)
        {
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            CINVENTARIOSUCURSALD importExistD = new CINVENTARIOSUCURSALD();
            CINVENTARIOSUCURSALBE importExistBE;


            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                foreach (com.server.ipos.CEXIST_SUCURSALBE existencia in existSuc)
                {

                    if (existencia.ISUCURSALCLAVE == "0000  ")
                        continue;

                    importExistBE = new CINVENTARIOSUCURSALBE();

                    importExistBE.IPRODUCTOCLAVE = existencia.IPRODUCTOCLAVE;
                    //importExistBE.IHORA = TimeSpan.Parse(existencia.);
                    importExistBE.ICANTIDAD = existencia.ICANTIDAD;
                    importExistBE.IFECHA = existencia.IFECHA;

                    importExistBE.ISUCURSALCLAVE = existencia.ISUCURSALCLAVE;

                    importExistBE.IALMACENCLAVE = existencia.IALMACENCLAVE != null && existencia.IALMACENCLAVE.Trim().Length > 0 ? 
                                                                    existencia.IALMACENCLAVE : 
                                                   (existencia.IGRUPOCLAVE != null && existencia.IGRUPOCLAVE.Trim().Length > 0 ?
                                                                    existencia.IGRUPOCLAVE : DBValues._DOCTO_ALMACEN_CLAVE_DEFAULT);


                    if (importExistD.AgregarINVENTARIOSUCURSAL(importExistBE, fTrans) == false)
                    {
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }

                }

                fTrans.Commit();
                fConn.Close();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }




        public bool ImportarExistenciasBD_A(com.servebeer.kikoleria.CEXIST_SUCURSALBE[] existSuc)
        {
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            CINVENTARIOSUCURSALD importExistD = new CINVENTARIOSUCURSALD();
            CINVENTARIOSUCURSALBE importExistBE;


            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                foreach (com.servebeer.kikoleria.CEXIST_SUCURSALBE existencia in existSuc)
                {

                    if (existencia.ISUCURSALCLAVE == "0000  ")
                        continue;

                    importExistBE = new CINVENTARIOSUCURSALBE();

                    importExistBE.IPRODUCTOCLAVE = existencia.IPRODUCTOCLAVE;
                    //importExistBE.IHORA = TimeSpan.Parse(existencia.);
                    importExistBE.ICANTIDAD = existencia.ICANTIDAD;
                    importExistBE.IFECHA = existencia.IFECHA;

                    importExistBE.ISUCURSALCLAVE = existencia.ISUCURSALCLAVE;

                    importExistBE.IALMACENCLAVE = existencia.IALMACENCLAVE != null && existencia.IALMACENCLAVE.Trim().Length > 0 ?
                                                                    existencia.IALMACENCLAVE :
                                                   (existencia.IGRUPOCLAVE != null && existencia.IGRUPOCLAVE.Trim().Length > 0 ?
                                                                    existencia.IGRUPOCLAVE : DBValues._DOCTO_ALMACEN_CLAVE_DEFAULT);
                    


                    if (importExistD.AgregarINVENTARIOSUCURSAL(importExistBE, fTrans) == false)
                    {
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }

                }

                fTrans.Commit();

            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }


        
        public bool RegistrarTralsados(FbTransaction st)
        {

            //bool retorno = true;
            this.iComentario = "";
            //FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            bool bRes = true;
            com.server.ipos.Service1 service1 = new com.server.ipos.Service1();

            string sucursalE = "";
            string traslado = "";
            string sucursalD = "";
            string folioE = "";
            string id = "";
            DateTime fecha = DateTime.Today;
            string hora = "00:00";


            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE doctoBE = new CDOCTOBE();

            
            try
            {
                parts = new ArrayList();


                CmdTxt = @"select 
                            sucursalE.clave SUCURSALE,
                            docto.id TRASLADO,
                            sucursalD.clave SUCURSALD,
                            docto.folio FOLIOE,
                            persona.username ID,
                            docto.fecha FECHA,
                            docto.hora  HORA
                             from docto
                        inner join sucursal sucursalE on sucursalE.id = docto.sucursalid
                        left join sucursal sucursalD on sucursalD.id = docto.sucursaltid
                        left join persona on docto.creadopor_userid = persona.id
                        where tipodoctoid = 31  and   TRANREGSERVER = 'N'  and docto.estatusdoctoid = 1";


                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(ConexionBD.ConexionString(), CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);

                while (dr.Read())
                {
                    doctoBE = new CDOCTOBE();
                    if (dr["SUCURSALE"] != System.DBNull.Value)
                    {

                        if (dr["SUCURSALE"].ToString() == "")
                            continue;

                        sucursalE = dr["SUCURSALE"].ToString();
                    }
                    else
                        continue;


                    if (dr["TRASLADO"] != System.DBNull.Value)
                    {
                        traslado = (dr["TRASLADO"]).ToString();
                        doctoBE.IID = (long)dr["TRASLADO"];
                    }
                    else
                        traslado = "";


                    if (dr["SUCURSALD"] != System.DBNull.Value)
                    {
                        sucursalD = dr["SUCURSALD"].ToString();
                    }
                    else
                        continue;


                    if (dr["FOLIOE"] != System.DBNull.Value)
                    {
                        folioE = dr["FOLIOE"].ToString();
                    }
                    else
                        continue;


                    if (dr["ID"] != System.DBNull.Value)
                    {
                        id = dr["ID"].ToString();
                    }
                    else
                        continue;


                    if (dr["FECHA"] != System.DBNull.Value)
                    {
                        fecha = (DateTime)(dr["FECHA"]);
                    }
                    else
                        fecha = DateTime.MinValue;


                    if (dr["HORA"] != System.DBNull.Value)
                    {
                        hora = dr.GetDateTime(6).ToString("hh:mm"); // ((DateTime)dr["HORA"]).ToString("hh:mm");
                    }
                    else
                        hora = "00:00";





                    string strWebService = CurrentUserID.CurrentParameters.IUSARCONEXIONLOCAL.Equals("S") ? (CurrentUserID.CurrentParameters.ILOCALWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.ILOCALWEBSERVICE.Trim()) : (CurrentUserID.CurrentParameters.IWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.IWEBSERVICE.Trim());
                    if (strWebService.Trim().ToLower().Equals(DBValues._HOSTS_KIKOLERIA))
                    {

                        com.servebeer.kikoleria.Service1 serviceA = new com.servebeer.kikoleria.Service1();
                        bRes = serviceA.AgregarTrasladoBD(sucursalE, traslado, sucursalD, "", "", id, folioE, "", fecha, hora,
                            iPos.Tools.FTPManagement.m_strFTPFolderWs,
                            iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                    }
                    else
                    {

                        if (strWebService.Trim().Length > 0)
                        {
                            service1.Url = strWebService.Trim();
                        }

                        bRes = service1.AgregarTrasladoBD(sucursalE, traslado, sucursalD, "", "", id, folioE, "", fecha, hora,
                            iPos.Tools.FTPManagement.m_strFTPFolderWs,
                            iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                    }







                    if (bRes)
                    {
                        //actualiza docto
                        doctoBE.ITRANREGSERVER = "S";
                        doctoD.CambiarTranRegServerDOCTOD(doctoBE, null);
                    }

                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }




        public bool RegistrarRecepcionTralsados(FbTransaction st)
        {
            

            //bool retorno = true;
            this.iComentario = "";
            FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            bool bRes = true;
            com.server.ipos.Service1 service1 = new com.server.ipos.Service1();

            string sucursalE = "";
            string traslado = "";
            string sucursalD = "";
            string folioD = "";
            string recepcion = "";
            string recibio = "";


            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE doctoBE = new CDOCTOBE();


            try
            {
                parts = new ArrayList();


                CmdTxt = @"select 
                            sucursalE.clave SUCURSALE,
                            docto.referencia TRASLADO,
                            sucursalD.clave SUCURSALD,
                            docto.folio FOLIOD,
                            persona.username RECIBIO,
                            docto.id  RECEPCION
                             from docto
                        inner join sucursal sucursalE on sucursalE.id = docto.sucursaltid
                        left join sucursal sucursalD on sucursalD.id = docto.sucursalid
                        left join persona on docto.creadopor_userid = persona.id
                        where tipodoctoid = 41  and   (TRANREGSERVER = 'N' or (TRANREGSERVER IS NULL)) and docto.estatusdoctoid = 1
                              and docto.fecha > @fechalimite";



                auxPar = new FbParameter("@fechalimite", FbDbType.Date);
                auxPar.Value = DateTime.Today.AddDays(-3);
                parts.Add(auxPar);

                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(ConexionBD.ConexionString(), CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);

                while (dr.Read())
                {
                    doctoBE = new CDOCTOBE();
                    if (dr["SUCURSALE"] != System.DBNull.Value)
                    {

                        if (dr["SUCURSALE"].ToString() == "")
                            continue;

                        sucursalE = dr["SUCURSALE"].ToString();
                    }
                    else
                        continue;


                    if (dr["TRASLADO"] != System.DBNull.Value)
                    {
                        traslado = (dr["TRASLADO"]).ToString();
                    }
                    else
                        traslado = "";


                    if (dr["SUCURSALD"] != System.DBNull.Value)
                    {
                        sucursalD = dr["SUCURSALD"].ToString();
                    }
                    else
                        continue;


                    if (dr["FOLIOD"] != System.DBNull.Value)
                    {
                        folioD = dr["FOLIOD"].ToString();
                    }
                    else
                        continue;



                    if (dr["RECEPCION"] != System.DBNull.Value)
                    {
                        recepcion = (dr["RECEPCION"]).ToString();
                        doctoBE.IID = (long)(dr["RECEPCION"]);
                    }
                    else
                        recepcion = "";


                    if (dr["RECIBIO"] != System.DBNull.Value)
                    {
                        recibio = (dr["RECIBIO"]).ToString();
                    }
                    else
                        recibio = "";




                    string strWebService = CurrentUserID.CurrentParameters.IUSARCONEXIONLOCAL.Equals("S") ? (CurrentUserID.CurrentParameters.ILOCALWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.ILOCALWEBSERVICE.Trim()) : (CurrentUserID.CurrentParameters.IWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.IWEBSERVICE.Trim());
                    if (strWebService.Trim().ToLower().Equals(DBValues._HOSTS_KIKOLERIA))
                    {

                        com.servebeer.kikoleria.Service1 serviceA = new com.servebeer.kikoleria.Service1();
                        bRes = serviceA.CambiarTrasladoBD(sucursalE, traslado, sucursalD, recepcion, recibio, folioD,
                            iPos.Tools.FTPManagement.m_strFTPFolderWs,
                            iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                    }
                    else
                    {
                        if (strWebService.Trim().Length > 0)
                        {
                            service1.Url = strWebService.Trim();
                        }

                        bRes = service1.CambiarTrasladoBD(sucursalE, traslado, sucursalD, recepcion, recibio, folioD,
                            iPos.Tools.FTPManagement.m_strFTPFolderWs,
                            iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                    }

                    if (bRes)
                    {
                        //actualiza docto
                        doctoBE.ITRANREGSERVER = "S";
                        doctoD.CambiarTranRegServerDOCTOD(doctoBE, null);
                    }

                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }




        public bool RegistrarIgnoramientoTralsados(FbTransaction st)
        {

            //bool retorno = true;
            this.iComentario = "";
            //FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            bool bRes = true;
            com.server.ipos.Service1 service1 = new com.server.ipos.Service1();

            string sucursalE = "";
            string traslado = "";
            string sucursalD = "";
            string folioD = "";
            string recepcion = "";
            string recibio = "";


            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE doctoBE = new CDOCTOBE();


            try
            {
                parts = new ArrayList();


                CmdTxt = @"select 
                            sucursalE.clave SUCURSALE,
                            docto.referencia TRASLADO,
                            sucursalD.clave SUCURSALD,
                            persona.username RECIBIO,
                            docto.id  RECEPCION
                             from docto
                        inner join sucursal sucursalE on sucursalE.id = docto.sucursaltid
                        left join sucursal sucursalD on sucursalD.id = docto.sucursalid
                        left join persona on docto.creadopor_userid = persona.id
                        where tipodoctoid = 44  and   (TRANREGSERVER = 'N' or (TRANREGSERVER IS NULL))  and docto.estatusdoctoid = 4";


                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(ConexionBD.ConexionString(), CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);

                while (dr.Read())
                {
                    doctoBE = new CDOCTOBE();
                    if (dr["SUCURSALE"] != System.DBNull.Value)
                    {

                        if (dr["SUCURSALE"].ToString() == "")
                            continue;

                        sucursalE = dr["SUCURSALE"].ToString();
                    }
                    else
                        continue;


                    if (dr["TRASLADO"] != System.DBNull.Value)
                    {
                        traslado = (dr["TRASLADO"]).ToString();
                    }
                    else
                        traslado = "";


                    if (dr["SUCURSALD"] != System.DBNull.Value)
                    {
                        sucursalD = dr["SUCURSALD"].ToString();
                    }
                    else
                        continue;


                    /*if (dr["FOLIOD"] != System.DBNull.Value)
                    {
                        folioD = dr["FOLIOD"].ToString();
                    }
                    else
                        continue;*/

                    folioD = "999999";



                    if (dr["RECEPCION"] != System.DBNull.Value)
                    {
                        recepcion = (dr["RECEPCION"]).ToString();
                        doctoBE.IID = (long)(dr["RECEPCION"]);
                    }
                    else
                        recepcion = "";


                    if (dr["RECIBIO"] != System.DBNull.Value)
                    {
                        recibio = (dr["RECIBIO"]).ToString();
                    }
                    else
                        recibio = "";


                    string strWebService = CurrentUserID.CurrentParameters.IUSARCONEXIONLOCAL.Equals("S") ? (CurrentUserID.CurrentParameters.ILOCALWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.ILOCALWEBSERVICE.Trim()) : (CurrentUserID.CurrentParameters.IWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.IWEBSERVICE.Trim());
                    if (strWebService.Trim().ToLower().Equals(DBValues._HOSTS_KIKOLERIA))
                    {

                        com.servebeer.kikoleria.Service1 serviceA = new com.servebeer.kikoleria.Service1();
                        bRes = serviceA.CambiarTrasladoBD(sucursalE, traslado, sucursalD, recepcion, recibio, folioD,
                            iPos.Tools.FTPManagement.m_strFTPFolderWs,
                            iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                    }
                    else
                    {

                        if (strWebService.Trim().Length > 0)
                        {
                            service1.Url = strWebService.Trim();
                        }

                        bRes = service1.CambiarTrasladoBD(sucursalE, traslado, sucursalD, recepcion, recibio, folioD,
                            iPos.Tools.FTPManagement.m_strFTPFolderWs,
                            iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                    }

                    if (bRes)
                    {
                        //actualiza docto
                        doctoBE.ITRANREGSERVER = "S";
                        doctoD.CambiarTranRegServerDOCTOD(doctoBE, null);
                    }

                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }



    }
}
