

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

    [Transaction(TransactionOption.Supported)]


    public class CSUCURSALD
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
        public CSUCURSALBE AgregarSUCURSALD(CSUCURSALBE oCSUCURSAL, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCSUCURSAL.isnull["ICLAVE"])
                {
                    auxPar.Value = oCSUCURSAL.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCSUCURSAL.isnull["INOMBRE"])
                {
                    auxPar.Value = oCSUCURSAL.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCSUCURSAL.isnull["IDESCRIPCION"])
                {
                    auxPar.Value = oCSUCURSAL.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@GRUPOSUCURSALID", FbDbType.BigInt);
                if (!(bool)oCSUCURSAL.isnull["IGRUPOSUCURSALID"])
                {
                    auxPar.Value = oCSUCURSAL.IGRUPOSUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LISTA_PRECIO_TRASPASO", FbDbType.VarChar);
                if (!(bool)oCSUCURSAL.isnull["ILISTA_PRECIO_TRASPASO"])
                {
                    auxPar.Value = oCSUCURSAL.ILISTA_PRECIO_TRASPASO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MAXDOCTOSPENDIENTES", FbDbType.Integer);
                if (!(bool)oCSUCURSAL.isnull["IMAXDOCTOSPENDIENTES"])
                {
                    auxPar.Value = oCSUCURSAL.IMAXDOCTOSPENDIENTES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                //auxPar = new FbParameter("@MEMO", FbDbType.Text);
                //if (!(bool)oCSUCURSAL.isnull["IMEMO"])
                //{
                //    auxPar.Value = oCSUCURSAL.IMEMO;
                //}
                //else
                //{
                //    auxPar.Value = System.DBNull.Value;
                //}
                //parts.Add(auxPar);


                auxPar = new FbParameter("@ESMATRIZ", FbDbType.VarChar);
                if (!(bool)oCSUCURSAL.isnull["IESMATRIZ"] && oCSUCURSAL.IESMATRIZ != null && oCSUCURSAL.IESMATRIZ.Trim().Length > 0)
                {
                    auxPar.Value = oCSUCURSAL.IESMATRIZ;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@PRECIORECEPCIONTRASLADO", FbDbType.BigInt);
                if (!(bool)oCSUCURSAL.isnull["IPRECIORECEPCIONTRASLADO"])
                {
                    auxPar.Value = oCSUCURSAL.IPRECIORECEPCIONTRASLADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MOSTRARPRECIOREAL", FbDbType.VarChar);
                if (!(bool)oCSUCURSAL.isnull["IMOSTRARPRECIOREAL"])
                {
                    auxPar.Value = oCSUCURSAL.IMOSTRARPRECIOREAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIOENVIOTRASLADO", FbDbType.BigInt);
                if (!(bool)oCSUCURSAL.isnull["IPRECIOENVIOTRASLADO"])
                {
                    auxPar.Value = oCSUCURSAL.IPRECIOENVIOTRASLADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CLIENTECLAVE", FbDbType.VarChar);
                if (!(bool)oCSUCURSAL.isnull["ICLIENTECLAVE"])
                {
                    auxPar.Value = oCSUCURSAL.ICLIENTECLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESFRANQUICIA", FbDbType.VarChar);
                if (!(bool)oCSUCURSAL.isnull["IESFRANQUICIA"])
                {
                    auxPar.Value = oCSUCURSAL.IESFRANQUICIA;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@POR_FACT_ELECT", FbDbType.VarChar);
                if (!(bool)oCSUCURSAL.isnull["IPOR_FACT_ELECT"])
                {
                    auxPar.Value = oCSUCURSAL.IPOR_FACT_ELECT;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@ENTREGACALLE", FbDbType.Char);
                if (!(bool)oCSUCURSAL.isnull["IENTREGACALLE"])
                {
                    auxPar.Value = oCSUCURSAL.IENTREGACALLE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@ENTREGANUMEROINTERIOR", FbDbType.Char);
                if (!(bool)oCSUCURSAL.isnull["IENTREGANUMEROINTERIOR"])
                {
                    auxPar.Value = oCSUCURSAL.IENTREGANUMEROINTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@ENTREGANUMEROEXTERIOR", FbDbType.Char);
                if (!(bool)oCSUCURSAL.isnull["IENTREGANUMEROEXTERIOR"])
                {
                    auxPar.Value = oCSUCURSAL.IENTREGANUMEROEXTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@ENTREGACOLONIA", FbDbType.Char);
                if (!(bool)oCSUCURSAL.isnull["IENTREGACOLONIA"])
                {
                    auxPar.Value = oCSUCURSAL.IENTREGACOLONIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@ENTREGAMUNICIPIO", FbDbType.Char);
                if (!(bool)oCSUCURSAL.isnull["IENTREGAMUNICIPIO"])
                {
                    auxPar.Value = oCSUCURSAL.IENTREGAMUNICIPIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@ENTREGAESTADO", FbDbType.Char);
                if (!(bool)oCSUCURSAL.isnull["IENTREGAESTADO"])
                {
                    auxPar.Value = oCSUCURSAL.IENTREGAESTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@ENTREGACODIGOPOSTAL", FbDbType.Char);
                if (!(bool)oCSUCURSAL.isnull["IENTREGACODIGOPOSTAL"])
                {
                    auxPar.Value = oCSUCURSAL.IENTREGACODIGOPOSTAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PROVEEDORCLAVE", FbDbType.VarChar);
                if (!(bool)oCSUCURSAL.isnull["IPROVEEDORCLAVE"])
                {
                    auxPar.Value = oCSUCURSAL.IPROVEEDORCLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SURTIDOR", FbDbType.VarChar);
                if (!(bool)oCSUCURSAL.isnull["ISURTIDOR"])
                {
                    auxPar.Value = oCSUCURSAL.ISURTIDOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PORC_AUMENTO_PRECIO", FbDbType.Numeric);
                if (!(bool)oCSUCURSAL.isnull["IPORC_AUMENTO_PRECIO"])
                {
                    auxPar.Value = oCSUCURSAL.IPORC_AUMENTO_PRECIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RUTARESPALDOORIGEN", FbDbType.VarChar);
                if (!(bool)oCSUCURSAL.isnull["IRUTARESPALDOORIGEN"])
                {
                    auxPar.Value = oCSUCURSAL.IRUTARESPALDOORIGEN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RUTARESPALDODESTINO", FbDbType.VarChar);
                if (!(bool)oCSUCURSAL.isnull["IRUTARESPALDODESTINO"])
                {
                    auxPar.Value = oCSUCURSAL.IRUTARESPALDODESTINO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@MANEJAPRECIOXDESCUENTO", FbDbType.VarChar);
                if (!(bool)oCSUCURSAL.isnull["IMANEJAPRECIOXDESCUENTO"] && oCSUCURSAL.IMANEJAPRECIOXDESCUENTO != null && oCSUCURSAL.IMANEJAPRECIOXDESCUENTO.Trim().Length > 0)
                {
                    auxPar.Value = oCSUCURSAL.IMANEJAPRECIOXDESCUENTO;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PREFIJOPRECIOXDESCUENTO", FbDbType.VarChar);
                if (!(bool)oCSUCURSAL.isnull["IPREFIJOPRECIOXDESCUENTO"])
                {
                    auxPar.Value = oCSUCURSAL.IPREFIJOPRECIOXDESCUENTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBRERESPALDOBD", FbDbType.VarChar);
                if (!(bool)oCSUCURSAL.isnull["INOMBRERESPALDOBD"])
                {
                    auxPar.Value = oCSUCURSAL.INOMBRERESPALDOBD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@BANCOCLAVE", FbDbType.VarChar);
                if (!(bool)oCSUCURSAL.isnull["IBANCOCLAVE"])
                {
                    auxPar.Value = oCSUCURSAL.IBANCOCLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CUENTAREFERENCIA", FbDbType.VarChar);
                if (!(bool)oCSUCURSAL.isnull["ICUENTAREFERENCIA"])
                {
                    auxPar.Value = oCSUCURSAL.ICUENTAREFERENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RUTARESPALDORED", FbDbType.VarChar);
                if (!(bool)oCSUCURSAL.isnull["IRUTARESPALDORED"])
                {
                    auxPar.Value = oCSUCURSAL.IRUTARESPALDORED;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CUENTAPOLIZA", FbDbType.VarChar);
                if (!(bool)oCSUCURSAL.isnull["ICUENTAPOLIZA"])
                {
                    auxPar.Value = oCSUCURSAL.ICUENTAPOLIZA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LISTAPRECIOCLAVE", FbDbType.VarChar);
                if (!(bool)oCSUCURSAL.isnull["ILISTAPRECIOCLAVE"])
                {
                    auxPar.Value = oCSUCURSAL.ILISTAPRECIOCLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@EMPPROV", FbDbType.VarChar);
                if (!(bool)oCSUCURSAL.isnull["IEMPPROV"])
                {
                    auxPar.Value = oCSUCURSAL.IEMPPROV;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@IMNUPROD", FbDbType.VarChar);
                if (!(bool)oCSUCURSAL.isnull["IIMNUPROD"])
                {
                    auxPar.Value = oCSUCURSAL.IIMNUPROD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@ENTREGA_SAT_COLONIAID", FbDbType.BigInt);
                if (!(bool)oCSUCURSAL.isnull["IENTREGA_SAT_COLONIAID"])
                {
                    auxPar.Value = oCSUCURSAL.IENTREGA_SAT_COLONIAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ENTREGA_SAT_LOCALIDADID", FbDbType.BigInt);
                if (!(bool)oCSUCURSAL.isnull["IENTREGA_SAT_LOCALIDADID"])
                {
                    auxPar.Value = oCSUCURSAL.IENTREGA_SAT_LOCALIDADID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ENTREGA_SAT_MUNICIPIOID", FbDbType.BigInt);
                if (!(bool)oCSUCURSAL.isnull["IENTREGA_SAT_MUNICIPIOID"])
                {
                    auxPar.Value = oCSUCURSAL.IENTREGA_SAT_MUNICIPIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ENTREGA_DISTANCIA", FbDbType.Numeric);
                if (!(bool)oCSUCURSAL.isnull["IENTREGA_DISTANCIA"])
                {
                    auxPar.Value = oCSUCURSAL.IENTREGA_DISTANCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ENTREGAREFERENCIADOM", FbDbType.VarChar);
                if (!(bool)oCSUCURSAL.isnull["IENTREGAREFERENCIADOM"])
                {
                    auxPar.Value = oCSUCURSAL.IENTREGAREFERENCIADOM;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                string commandText = @"
        INSERT INTO SUCURSAL
      (

CLAVE,

NOMBRE,

DESCRIPCION,

GRUPOSUCURSALID,

LISTA_PRECIO_TRASPASO,

MAXDOCTOSPENDIENTES,

ESMATRIZ,

PRECIORECEPCIONTRASLADO,

MOSTRARPRECIOREAL,
PRECIOENVIOTRASLADO,

CLIENTECLAVE,

ESFRANQUICIA,
POR_FACT_ELECT,

ENTREGACALLE,
ENTREGANUMEROINTERIOR,
ENTREGANUMEROEXTERIOR,
ENTREGACOLONIA,
ENTREGAMUNICIPIO,
ENTREGAESTADO,
ENTREGACODIGOPOSTAL,

PROVEEDORCLAVE,

SURTIDOR,

PORC_AUMENTO_PRECIO,

RUTARESPALDOORIGEN,

RUTARESPALDODESTINO,

MANEJAPRECIOXDESCUENTO,

PREFIJOPRECIOXDESCUENTO,

NOMBRERESPALDOBD,

BANCOCLAVE,

CUENTAREFERENCIA,

RUTARESPALDORED,

CUENTAPOLIZA,

LISTAPRECIOCLAVE,

EMPPROV,

IMNUPROD,

ENTREGA_SAT_COLONIAID,

ENTREGA_SAT_LOCALIDADID,

ENTREGA_SAT_MUNICIPIOID,

ENTREGA_DISTANCIA,

ENTREGAREFERENCIADOM

         )

Values (

@CLAVE,

@NOMBRE,

@DESCRIPCION,

@GRUPOSUCURSALID,

@LISTA_PRECIO_TRASPASO,

@MAXDOCTOSPENDIENTES,

@ESMATRIZ,

@PRECIORECEPCIONTRASLADO,

@MOSTRARPRECIOREAL,
@PRECIOENVIOTRASLADO,

@CLIENTECLAVE,

@ESFRANQUICIA,
@POR_FACT_ELECT,

@ENTREGACALLE,
@ENTREGANUMEROINTERIOR,
@ENTREGANUMEROEXTERIOR,
@ENTREGACOLONIA,
@ENTREGAMUNICIPIO,
@ENTREGAESTADO,
@ENTREGACODIGOPOSTAL,

@PROVEEDORCLAVE,

@SURTIDOR,

@PORC_AUMENTO_PRECIO,

@RUTARESPALDOORIGEN,

@RUTARESPALDODESTINO,

@MANEJAPRECIOXDESCUENTO,

@PREFIJOPRECIOXDESCUENTO,

@NOMBRERESPALDOBD,

@BANCOCLAVE,

@CUENTAREFERENCIA,

@RUTARESPALDORED,

@CUENTAPOLIZA,

@LISTAPRECIOCLAVE,

@EMPPROV,

@IMNUPROD,

@ENTREGA_SAT_COLONIAID,

@ENTREGA_SAT_LOCALIDADID,

@ENTREGA_SAT_MUNICIPIOID,

@ENTREGA_DISTANCIA,

@ENTREGAREFERENCIADOM

); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCSUCURSAL;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarSUCURSALD(CSUCURSALBE oCSUCURSAL, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSUCURSAL.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from SUCURSAL
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
        public bool CambiarSUCURSALD(CSUCURSALBE oCSUCURSALNuevo, CSUCURSALBE oCSUCURSALAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCSUCURSALNuevo.isnull["ICLAVE"])
                {
                    auxPar.Value = oCSUCURSALNuevo.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCSUCURSALNuevo.isnull["INOMBRE"])
                {
                    auxPar.Value = oCSUCURSALNuevo.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCSUCURSALNuevo.isnull["IDESCRIPCION"])
                {
                    auxPar.Value = oCSUCURSALNuevo.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@GRUPOSUCURSALID", FbDbType.BigInt);
                if (!(bool)oCSUCURSALNuevo.isnull["IGRUPOSUCURSALID"])
                {
                    auxPar.Value = oCSUCURSALNuevo.IGRUPOSUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LISTA_PRECIO_TRASPASO", FbDbType.VarChar);
                if (!(bool)oCSUCURSALNuevo.isnull["ILISTA_PRECIO_TRASPASO"])
                {
                    auxPar.Value = oCSUCURSALNuevo.ILISTA_PRECIO_TRASPASO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@MAXDOCTOSPENDIENTES", FbDbType.Integer);
                if (!(bool)oCSUCURSALNuevo.isnull["IMAXDOCTOSPENDIENTES"])
                {
                    auxPar.Value = oCSUCURSALNuevo.IMAXDOCTOSPENDIENTES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESMATRIZ", FbDbType.VarChar);
                if (!(bool)oCSUCURSALNuevo.isnull["IESMATRIZ"] && oCSUCURSALNuevo.IESMATRIZ != null && oCSUCURSALNuevo.IESMATRIZ.Trim().Length > 0)
                {
                    auxPar.Value = oCSUCURSALNuevo.IESMATRIZ;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@PRECIORECEPCIONTRASLADO", FbDbType.BigInt);
                if (!(bool)oCSUCURSALNuevo.isnull["IPRECIORECEPCIONTRASLADO"])
                {
                    auxPar.Value = oCSUCURSALNuevo.IPRECIORECEPCIONTRASLADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MOSTRARPRECIOREAL", FbDbType.VarChar);
                if (!(bool)oCSUCURSALNuevo.isnull["IMOSTRARPRECIOREAL"])
                {
                    auxPar.Value = oCSUCURSALNuevo.IMOSTRARPRECIOREAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PRECIOENVIOTRASLADO", FbDbType.BigInt);
                if (!(bool)oCSUCURSALNuevo.isnull["IPRECIOENVIOTRASLADO"])
                {
                    auxPar.Value = oCSUCURSALNuevo.IPRECIOENVIOTRASLADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLIENTECLAVE", FbDbType.VarChar);
                if (!(bool)oCSUCURSALNuevo.isnull["ICLIENTECLAVE"])
                {
                    auxPar.Value = oCSUCURSALNuevo.ICLIENTECLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESFRANQUICIA", FbDbType.VarChar);
                if (!(bool)oCSUCURSALNuevo.isnull["IESFRANQUICIA"])
                {
                    auxPar.Value = oCSUCURSALNuevo.IESFRANQUICIA;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@POR_FACT_ELECT", FbDbType.VarChar);
                if (!(bool)oCSUCURSALNuevo.isnull["IPOR_FACT_ELECT"])
                {
                    auxPar.Value = oCSUCURSALNuevo.IPOR_FACT_ELECT;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@ENTREGACALLE", FbDbType.Char);
                if (!(bool)oCSUCURSALNuevo.isnull["IENTREGACALLE"])
                {
                    auxPar.Value = oCSUCURSALNuevo.IENTREGACALLE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@ENTREGANUMEROINTERIOR", FbDbType.Char);
                if (!(bool)oCSUCURSALNuevo.isnull["IENTREGANUMEROINTERIOR"])
                {
                    auxPar.Value = oCSUCURSALNuevo.IENTREGANUMEROINTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@ENTREGANUMEROEXTERIOR", FbDbType.Char);
                if (!(bool)oCSUCURSALNuevo.isnull["IENTREGANUMEROEXTERIOR"])
                {
                    auxPar.Value = oCSUCURSALNuevo.IENTREGANUMEROEXTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@ENTREGACOLONIA", FbDbType.Char);
                if (!(bool)oCSUCURSALNuevo.isnull["IENTREGACOLONIA"])
                {
                    auxPar.Value = oCSUCURSALNuevo.IENTREGACOLONIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@ENTREGAMUNICIPIO", FbDbType.Char);
                if (!(bool)oCSUCURSALNuevo.isnull["IENTREGAMUNICIPIO"])
                {
                    auxPar.Value = oCSUCURSALNuevo.IENTREGAMUNICIPIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@ENTREGAESTADO", FbDbType.Char);
                if (!(bool)oCSUCURSALNuevo.isnull["IENTREGAESTADO"])
                {
                    auxPar.Value = oCSUCURSALNuevo.IENTREGAESTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@ENTREGACODIGOPOSTAL", FbDbType.Char);
                if (!(bool)oCSUCURSALNuevo.isnull["IENTREGACODIGOPOSTAL"])
                {
                    auxPar.Value = oCSUCURSALNuevo.IENTREGACODIGOPOSTAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PROVEEDORCLAVE", FbDbType.VarChar);
                if (!(bool)oCSUCURSALNuevo.isnull["IPROVEEDORCLAVE"])
                {
                    auxPar.Value = oCSUCURSALNuevo.IPROVEEDORCLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SURTIDOR", FbDbType.VarChar);
                if (!(bool)oCSUCURSALNuevo.isnull["ISURTIDOR"])
                {
                    auxPar.Value = oCSUCURSALNuevo.ISURTIDOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PORC_AUMENTO_PRECIO", FbDbType.Numeric);
                if (!(bool)oCSUCURSALNuevo.isnull["IPORC_AUMENTO_PRECIO"])
                {
                    auxPar.Value = oCSUCURSALNuevo.IPORC_AUMENTO_PRECIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RUTARESPALDOORIGEN", FbDbType.VarChar);
                if (!(bool)oCSUCURSALNuevo.isnull["IRUTARESPALDOORIGEN"])
                {
                    auxPar.Value = oCSUCURSALNuevo.IRUTARESPALDOORIGEN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RUTARESPALDODESTINO", FbDbType.VarChar);
                if (!(bool)oCSUCURSALNuevo.isnull["IRUTARESPALDODESTINO"])
                {
                    auxPar.Value = oCSUCURSALNuevo.IRUTARESPALDODESTINO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);





                auxPar = new FbParameter("@MANEJAPRECIOXDESCUENTO", FbDbType.VarChar);
                if (!(bool)oCSUCURSALNuevo.isnull["IMANEJAPRECIOXDESCUENTO"] && oCSUCURSALNuevo.IMANEJAPRECIOXDESCUENTO != null && oCSUCURSALNuevo.IMANEJAPRECIOXDESCUENTO.Trim().Length > 0)
                {
                    auxPar.Value = oCSUCURSALNuevo.IMANEJAPRECIOXDESCUENTO;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);





                auxPar = new FbParameter("@PREFIJOPRECIOXDESCUENTO", FbDbType.VarChar);
                if (!(bool)oCSUCURSALNuevo.isnull["IPREFIJOPRECIOXDESCUENTO"])
                {
                    auxPar.Value = oCSUCURSALNuevo.IPREFIJOPRECIOXDESCUENTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBRERESPALDOBD", FbDbType.VarChar);
                if (!(bool)oCSUCURSALNuevo.isnull["INOMBRERESPALDOBD"])
                {
                    auxPar.Value = oCSUCURSALNuevo.INOMBRERESPALDOBD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);





                auxPar = new FbParameter("@BANCOCLAVE", FbDbType.VarChar);
                if (!(bool)oCSUCURSALNuevo.isnull["IBANCOCLAVE"])
                {
                    auxPar.Value = oCSUCURSALNuevo.IBANCOCLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CUENTAREFERENCIA", FbDbType.VarChar);
                if (!(bool)oCSUCURSALNuevo.isnull["ICUENTAREFERENCIA"])
                {
                    auxPar.Value = oCSUCURSALNuevo.ICUENTAREFERENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RUTARESPALDORED", FbDbType.VarChar);
                if (!(bool)oCSUCURSALNuevo.isnull["IRUTARESPALDORED"])
                {
                    auxPar.Value = oCSUCURSALNuevo.IRUTARESPALDORED;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CUENTAPOLIZA", FbDbType.VarChar);
                if (!(bool)oCSUCURSALNuevo.isnull["ICUENTAPOLIZA"])
                {
                    auxPar.Value = oCSUCURSALNuevo.ICUENTAPOLIZA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@LISTAPRECIOCLAVE", FbDbType.VarChar);
                if (!(bool)oCSUCURSALNuevo.isnull["ILISTAPRECIOCLAVE"])
                {
                    auxPar.Value = oCSUCURSALNuevo.ILISTAPRECIOCLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@EMPPROV", FbDbType.VarChar);
                if (!(bool)oCSUCURSALNuevo.isnull["IEMPPROV"])
                {
                    auxPar.Value = oCSUCURSALNuevo.IEMPPROV;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMNUPROD", FbDbType.VarChar);
                if (!(bool)oCSUCURSALNuevo.isnull["IIMNUPROD"])
                {
                    auxPar.Value = oCSUCURSALNuevo.IIMNUPROD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@ENTREGA_SAT_COLONIAID", FbDbType.BigInt);
                if (!(bool)oCSUCURSALNuevo.isnull["IENTREGA_SAT_COLONIAID"])
                {
                    auxPar.Value = oCSUCURSALNuevo.IENTREGA_SAT_COLONIAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ENTREGA_SAT_LOCALIDADID", FbDbType.BigInt);
                if (!(bool)oCSUCURSALNuevo.isnull["IENTREGA_SAT_LOCALIDADID"])
                {
                    auxPar.Value = oCSUCURSALNuevo.IENTREGA_SAT_LOCALIDADID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ENTREGA_SAT_MUNICIPIOID", FbDbType.BigInt);
                if (!(bool)oCSUCURSALNuevo.isnull["IENTREGA_SAT_MUNICIPIOID"])
                {
                    auxPar.Value = oCSUCURSALNuevo.IENTREGA_SAT_MUNICIPIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ENTREGA_DISTANCIA", FbDbType.Numeric);
                if (!(bool)oCSUCURSALNuevo.isnull["IENTREGA_DISTANCIA"])
                {
                    auxPar.Value = oCSUCURSALNuevo.IENTREGA_DISTANCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                
                auxPar = new FbParameter("@ENTREGAREFERENCIADOM", FbDbType.VarChar);
                if (!(bool)oCSUCURSALNuevo.isnull["IENTREGAREFERENCIADOM"])
                {
                    auxPar.Value = oCSUCURSALNuevo.IENTREGAREFERENCIADOM;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCSUCURSALAnterior.isnull["IID"])
                {
                    auxPar.Value = oCSUCURSALAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  SUCURSAL
  set

CLAVE=@CLAVE,

NOMBRE=@NOMBRE,

DESCRIPCION=@DESCRIPCION,

GRUPOSUCURSALID=@GRUPOSUCURSALID,

LISTA_PRECIO_TRASPASO = @LISTA_PRECIO_TRASPASO,

MAXDOCTOSPENDIENTES = @MAXDOCTOSPENDIENTES,

ESMATRIZ = @ESMATRIZ,

PRECIORECEPCIONTRASLADO = @PRECIORECEPCIONTRASLADO,

MOSTRARPRECIOREAL = @MOSTRARPRECIOREAL,

PRECIOENVIOTRASLADO = @PRECIOENVIOTRASLADO,

CLIENTECLAVE = @CLIENTECLAVE,

ESFRANQUICIA = @ESFRANQUICIA,

POR_FACT_ELECT = @POR_FACT_ELECT,

ENTREGACALLE  = @ENTREGACALLE ,
ENTREGANUMEROINTERIOR  = @ENTREGANUMEROINTERIOR ,
ENTREGANUMEROEXTERIOR  = @ENTREGANUMEROEXTERIOR ,
ENTREGACOLONIA  = @ENTREGACOLONIA ,
ENTREGAMUNICIPIO  = @ENTREGAMUNICIPIO ,
ENTREGAESTADO  = @ENTREGAESTADO ,
ENTREGACODIGOPOSTAL  = @ENTREGACODIGOPOSTAL,

PROVEEDORCLAVE = @PROVEEDORCLAVE,

SURTIDOR = @SURTIDOR,

PORC_AUMENTO_PRECIO = @PORC_AUMENTO_PRECIO,

RUTARESPALDOORIGEN = @RUTARESPALDOORIGEN,

RUTARESPALDODESTINO = @RUTARESPALDODESTINO,

MANEJAPRECIOXDESCUENTO = @MANEJAPRECIOXDESCUENTO ,

PREFIJOPRECIOXDESCUENTO = @PREFIJOPRECIOXDESCUENTO,

NOMBRERESPALDOBD = @NOMBRERESPALDOBD,

BANCOCLAVE = @BANCOCLAVE,

CUENTAREFERENCIA = @CUENTAREFERENCIA,

RUTARESPALDORED = @RUTARESPALDORED,

CUENTAPOLIZA = @CUENTAPOLIZA,

LISTAPRECIOCLAVE = @LISTAPRECIOCLAVE,

EMPPROV = @EMPPROV,

IMNUPROD = @IMNUPROD,

ENTREGA_SAT_COLONIAID=@ENTREGA_SAT_COLONIAID,

ENTREGA_SAT_LOCALIDADID=@ENTREGA_SAT_LOCALIDADID,

ENTREGA_SAT_MUNICIPIOID=@ENTREGA_SAT_MUNICIPIOID,

ENTREGA_DISTANCIA=@ENTREGA_DISTANCIA,

ENTREGAREFERENCIADOM = @ENTREGAREFERENCIADOM


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
        public CSUCURSALBE seleccionarSUCURSAL(CSUCURSALBE oCSUCURSAL, FbTransaction st)
        {




            CSUCURSALBE retorno = new CSUCURSALBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SUCURSAL where ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSUCURSAL.IID;
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

                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = (string)(dr["DESCRIPCION"]);
                    }

                    if (dr["MEMO"] != System.DBNull.Value)
                    {
                        retorno.IMEMO = (object)(dr["MEMO"]);
                    }

                    if (dr["GRUPOSUCURSALID"] != System.DBNull.Value)
                    {
                        retorno.IGRUPOSUCURSALID = (long)(dr["GRUPOSUCURSALID"]);
                    }


                    if (dr["LISTA_PRECIO_TRASPASO"] != System.DBNull.Value)
                    {
                        retorno.ILISTA_PRECIO_TRASPASO = (string)(dr["LISTA_PRECIO_TRASPASO"]);
                    }

                    if (dr["MAXDOCTOSPENDIENTES"] != System.DBNull.Value)
                    {
                        retorno.IMAXDOCTOSPENDIENTES = (int)(dr["MAXDOCTOSPENDIENTES"]);
                    }


                    if (dr["ESMATRIZ"] != System.DBNull.Value)
                    {
                        retorno.IESMATRIZ = (string)(dr["ESMATRIZ"]);
                    }

                    if (dr["PRECIORECEPCIONTRASLADO"] != System.DBNull.Value)
                    {
                        retorno.IPRECIORECEPCIONTRASLADO = (long)(dr["PRECIORECEPCIONTRASLADO"]);
                    }


                    if (dr["MOSTRARPRECIOREAL"] != System.DBNull.Value)
                    {
                        retorno.IMOSTRARPRECIOREAL = (string)(dr["MOSTRARPRECIOREAL"]);
                    }


                    if (dr["PRECIOENVIOTRASLADO"] != System.DBNull.Value)
                    {
                        retorno.IPRECIOENVIOTRASLADO = (long)(dr["PRECIOENVIOTRASLADO"]);
                    }


                    if (dr["CLIENTECLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLIENTECLAVE = (string)(dr["CLIENTECLAVE"]);
                    }



                    if (dr["ESFRANQUICIA"] != System.DBNull.Value)
                    {
                        retorno.IESFRANQUICIA = (string)(dr["ESFRANQUICIA"]);
                    }
                    if (dr["POR_FACT_ELECT"] != System.DBNull.Value)
                    {
                        retorno.IPOR_FACT_ELECT = (string)(dr["POR_FACT_ELECT"]);
                    }

                    if (dr["ENTREGACALLE"] != System.DBNull.Value)
                    {
                        retorno.IENTREGACALLE = (string)(dr["ENTREGACALLE"]);
                    }
                    if (dr["ENTREGANUMEROINTERIOR"] != System.DBNull.Value)
                    {
                        retorno.IENTREGANUMEROINTERIOR = (string)(dr["ENTREGANUMEROINTERIOR"]);
                    }
                    if (dr["ENTREGANUMEROEXTERIOR"] != System.DBNull.Value)
                    {
                        retorno.IENTREGANUMEROEXTERIOR = (string)(dr["ENTREGANUMEROEXTERIOR"]);
                    }
                    if (dr["ENTREGACOLONIA"] != System.DBNull.Value)
                    {
                        retorno.IENTREGACOLONIA = (string)(dr["ENTREGACOLONIA"]);
                    }
                    if (dr["ENTREGAMUNICIPIO"] != System.DBNull.Value)
                    {
                        retorno.IENTREGAMUNICIPIO = (string)(dr["ENTREGAMUNICIPIO"]);
                    }
                    if (dr["ENTREGAESTADO"] != System.DBNull.Value)
                    {
                        retorno.IENTREGAESTADO = (string)(dr["ENTREGAESTADO"]);
                    }
                    if (dr["ENTREGACODIGOPOSTAL"] != System.DBNull.Value)
                    {
                        retorno.IENTREGACODIGOPOSTAL = (string)(dr["ENTREGACODIGOPOSTAL"]);
                    }

                    if (dr["PROVEEDORCLAVE"] != System.DBNull.Value)
                    {
                        retorno.IPROVEEDORCLAVE = (string)(dr["PROVEEDORCLAVE"]);
                    }

                    if (dr["SURTIDOR"] != System.DBNull.Value)
                    {
                        retorno.ISURTIDOR = (string)(dr["SURTIDOR"]);
                    }

                    if (dr["PORC_AUMENTO_PRECIO"] != System.DBNull.Value)
                    {
                        retorno.IPORC_AUMENTO_PRECIO = (decimal)(dr["PORC_AUMENTO_PRECIO"]);
                    }

                    if (dr["RUTARESPALDOORIGEN"] != System.DBNull.Value)
                    {
                        retorno.IRUTARESPALDOORIGEN = (string)(dr["RUTARESPALDOORIGEN"]);
                    }

                    if (dr["RUTARESPALDODESTINO"] != System.DBNull.Value)
                    {
                        retorno.IRUTARESPALDODESTINO = (string)(dr["RUTARESPALDODESTINO"]);
                    }



                    if (dr["MANEJAPRECIOXDESCUENTO"] != System.DBNull.Value)
                    {
                        retorno.IMANEJAPRECIOXDESCUENTO = (string)(dr["MANEJAPRECIOXDESCUENTO"]);
                    }


                    if (dr["PREFIJOPRECIOXDESCUENTO"] != System.DBNull.Value)
                    {
                        retorno.IPREFIJOPRECIOXDESCUENTO = (string)(dr["PREFIJOPRECIOXDESCUENTO"]);
                    }

                    if (dr["NOMBRERESPALDOBD"] != System.DBNull.Value)
                    {
                        retorno.INOMBRERESPALDOBD = (string)(dr["NOMBRERESPALDOBD"]);
                    }



                    if (dr["BANCOCLAVE"] != System.DBNull.Value)
                    {
                        retorno.IBANCOCLAVE = (string)(dr["BANCOCLAVE"]);
                    }


                    if (dr["CUENTAREFERENCIA"] != System.DBNull.Value)
                    {
                        retorno.ICUENTAREFERENCIA = (string)(dr["CUENTAREFERENCIA"]);
                    }


                    if (dr["RUTARESPALDORED"] != System.DBNull.Value)
                    {
                        retorno.IRUTARESPALDORED = (string)(dr["RUTARESPALDORED"]);
                    }

                    


                    if (dr["CUENTAPOLIZA"] != System.DBNull.Value)
                    {
                        retorno.ICUENTAPOLIZA = (string)(dr["CUENTAPOLIZA"]);
                    }



                    if (dr["LISTAPRECIOCLAVE"] != System.DBNull.Value)
                    {
                        retorno.ILISTAPRECIOCLAVE = (string)(dr["LISTAPRECIOCLAVE"]);
                    }

                    if (dr["EMPPROV"] != System.DBNull.Value)
                    {
                        retorno.IEMPPROV = (string)(dr["EMPPROV"]);
                    }



                    if (dr["IMNUPROD"] != System.DBNull.Value)
                    {
                        retorno.IIMNUPROD = (string)(dr["IMNUPROD"]);
                    }

                    if (dr["ENTREGA_SAT_COLONIAID"] != System.DBNull.Value)
                    {
                        retorno.IENTREGA_SAT_COLONIAID = (long)(dr["ENTREGA_SAT_COLONIAID"]);
                    }

                    if (dr["ENTREGA_SAT_LOCALIDADID"] != System.DBNull.Value)
                    {
                        retorno.IENTREGA_SAT_LOCALIDADID = (long)(dr["ENTREGA_SAT_LOCALIDADID"]);
                    }

                    if (dr["ENTREGA_SAT_MUNICIPIOID"] != System.DBNull.Value)
                    {
                        retorno.IENTREGA_SAT_MUNICIPIOID = (long)(dr["ENTREGA_SAT_MUNICIPIOID"]);
                    }

                    if (dr["ENTREGA_DISTANCIA"] != System.DBNull.Value)
                    {
                        retorno.IENTREGA_DISTANCIA = (decimal)(dr["ENTREGA_DISTANCIA"]);
                    }


                    if (dr["ENTREGAREFERENCIADOM"] != System.DBNull.Value)
                    {
                        retorno.IENTREGAREFERENCIADOM = (string)(dr["ENTREGAREFERENCIADOM"]);
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





        public CSUCURSALBE seleccionarSUCURSALMATRIZ(FbTransaction st)
        {




            CSUCURSALBE retorno = new CSUCURSALBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SUCURSAL where ESMATRIZ = 'S' AND (SURTIDOR IS NULL  or SURTIDOR = '')   ";





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

                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = (string)(dr["DESCRIPCION"]);
                    }

                    if (dr["MEMO"] != System.DBNull.Value)
                    {
                        retorno.IMEMO = (object)(dr["MEMO"]);
                    }

                    if (dr["GRUPOSUCURSALID"] != System.DBNull.Value)
                    {
                        retorno.IGRUPOSUCURSALID = (long)(dr["GRUPOSUCURSALID"]);
                    }


                    if (dr["LISTA_PRECIO_TRASPASO"] != System.DBNull.Value)
                    {
                        retorno.ILISTA_PRECIO_TRASPASO = (string)(dr["LISTA_PRECIO_TRASPASO"]);
                    }

                    if (dr["MAXDOCTOSPENDIENTES"] != System.DBNull.Value)
                    {
                        retorno.IMAXDOCTOSPENDIENTES = (int)(dr["MAXDOCTOSPENDIENTES"]);
                    }


                    if (dr["ESMATRIZ"] != System.DBNull.Value)
                    {
                        retorno.IESMATRIZ = (string)(dr["ESMATRIZ"]);
                    }

                    if (dr["PRECIORECEPCIONTRASLADO"] != System.DBNull.Value)
                    {
                        retorno.IPRECIORECEPCIONTRASLADO = (long)(dr["PRECIORECEPCIONTRASLADO"]);
                    }


                    if (dr["MOSTRARPRECIOREAL"] != System.DBNull.Value)
                    {
                        retorno.IMOSTRARPRECIOREAL = (string)(dr["MOSTRARPRECIOREAL"]);
                    }


                    if (dr["PRECIOENVIOTRASLADO"] != System.DBNull.Value)
                    {
                        retorno.IPRECIOENVIOTRASLADO = (long)(dr["PRECIOENVIOTRASLADO"]);
                    }


                    if (dr["CLIENTECLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLIENTECLAVE = (string)(dr["CLIENTECLAVE"]);
                    }



                    if (dr["ESFRANQUICIA"] != System.DBNull.Value)
                    {
                        retorno.IESFRANQUICIA = (string)(dr["ESFRANQUICIA"]);
                    }
                    if (dr["POR_FACT_ELECT"] != System.DBNull.Value)
                    {
                        retorno.IPOR_FACT_ELECT = (string)(dr["POR_FACT_ELECT"]);
                    }

                    if (dr["ENTREGACALLE"] != System.DBNull.Value)
                    {
                        retorno.IENTREGACALLE = (string)(dr["ENTREGACALLE"]);
                    }
                    if (dr["ENTREGANUMEROINTERIOR"] != System.DBNull.Value)
                    {
                        retorno.IENTREGANUMEROINTERIOR = (string)(dr["ENTREGANUMEROINTERIOR"]);
                    }
                    if (dr["ENTREGANUMEROEXTERIOR"] != System.DBNull.Value)
                    {
                        retorno.IENTREGANUMEROEXTERIOR = (string)(dr["ENTREGANUMEROEXTERIOR"]);
                    }
                    if (dr["ENTREGACOLONIA"] != System.DBNull.Value)
                    {
                        retorno.IENTREGACOLONIA = (string)(dr["ENTREGACOLONIA"]);
                    }
                    if (dr["ENTREGAMUNICIPIO"] != System.DBNull.Value)
                    {
                        retorno.IENTREGAMUNICIPIO = (string)(dr["ENTREGAMUNICIPIO"]);
                    }
                    if (dr["ENTREGAESTADO"] != System.DBNull.Value)
                    {
                        retorno.IENTREGAESTADO = (string)(dr["ENTREGAESTADO"]);
                    }
                    if (dr["ENTREGACODIGOPOSTAL"] != System.DBNull.Value)
                    {
                        retorno.IENTREGACODIGOPOSTAL = (string)(dr["ENTREGACODIGOPOSTAL"]);
                    }

                    if (dr["PROVEEDORCLAVE"] != System.DBNull.Value)
                    {
                        retorno.IPROVEEDORCLAVE = (string)(dr["PROVEEDORCLAVE"]);
                    }

                    if (dr["SURTIDOR"] != System.DBNull.Value)
                    {
                        retorno.ISURTIDOR = (string)(dr["SURTIDOR"]);
                    }

                    if (dr["PORC_AUMENTO_PRECIO"] != System.DBNull.Value)
                    {
                        retorno.IPORC_AUMENTO_PRECIO = (decimal)(dr["PORC_AUMENTO_PRECIO"]);
                    }

                    if (dr["RUTARESPALDOORIGEN"] != System.DBNull.Value)
                    {
                        retorno.IRUTARESPALDOORIGEN = (string)(dr["RUTARESPALDOORIGEN"]);
                    }

                    if (dr["RUTARESPALDODESTINO"] != System.DBNull.Value)
                    {
                        retorno.IRUTARESPALDODESTINO = (string)(dr["RUTARESPALDODESTINO"]);
                    }



                    if (dr["MANEJAPRECIOXDESCUENTO"] != System.DBNull.Value)
                    {
                        retorno.IMANEJAPRECIOXDESCUENTO = (string)(dr["MANEJAPRECIOXDESCUENTO"]);
                    }


                    if (dr["PREFIJOPRECIOXDESCUENTO"] != System.DBNull.Value)
                    {
                        retorno.IPREFIJOPRECIOXDESCUENTO = (string)(dr["PREFIJOPRECIOXDESCUENTO"]);
                    }

                    if (dr["NOMBRERESPALDOBD"] != System.DBNull.Value)
                    {
                        retorno.INOMBRERESPALDOBD = (string)(dr["NOMBRERESPALDOBD"]);
                    }



                    if (dr["BANCOCLAVE"] != System.DBNull.Value)
                    {
                        retorno.IBANCOCLAVE = (string)(dr["BANCOCLAVE"]);
                    }


                    if (dr["CUENTAREFERENCIA"] != System.DBNull.Value)
                    {
                        retorno.ICUENTAREFERENCIA = (string)(dr["CUENTAREFERENCIA"]);
                    }


                    if (dr["RUTARESPALDORED"] != System.DBNull.Value)
                    {
                        retorno.IRUTARESPALDORED = (string)(dr["RUTARESPALDORED"]);
                    }


                    if (dr["CUENTAPOLIZA"] != System.DBNull.Value)
                    {
                        retorno.ICUENTAPOLIZA = (string)(dr["CUENTAPOLIZA"]);
                    }


                    if (dr["LISTAPRECIOCLAVE"] != System.DBNull.Value)
                    {
                        retorno.ILISTAPRECIOCLAVE = (string)(dr["LISTAPRECIOCLAVE"]);
                    }

                    if (dr["EMPPROV"] != System.DBNull.Value)
                    {
                        retorno.IEMPPROV = (string)(dr["EMPPROV"]);
                    }


                    if (dr["IMNUPROD"] != System.DBNull.Value)
                    {
                        retorno.IIMNUPROD = (string)(dr["IMNUPROD"]);
                    }

                    if (dr["ENTREGA_SAT_COLONIAID"] != System.DBNull.Value)
                    {
                        retorno.IENTREGA_SAT_COLONIAID = (long)(dr["ENTREGA_SAT_COLONIAID"]);
                    }

                    if (dr["ENTREGA_SAT_LOCALIDADID"] != System.DBNull.Value)
                    {
                        retorno.IENTREGA_SAT_LOCALIDADID = (long)(dr["ENTREGA_SAT_LOCALIDADID"]);
                    }

                    if (dr["ENTREGA_SAT_MUNICIPIOID"] != System.DBNull.Value)
                    {
                        retorno.IENTREGA_SAT_MUNICIPIOID = (long)(dr["ENTREGA_SAT_MUNICIPIOID"]);
                    }

                    if (dr["ENTREGA_DISTANCIA"] != System.DBNull.Value)
                    {
                        retorno.IENTREGA_DISTANCIA = (decimal)(dr["ENTREGA_DISTANCIA"]);
                    }


                    if (dr["ENTREGAREFERENCIADOM"] != System.DBNull.Value)
                    {
                        retorno.IENTREGAREFERENCIADOM = (string)(dr["ENTREGAREFERENCIADOM"]);
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
        public DataSet enlistarSUCURSAL()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_SUCURSAL_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoSUCURSAL()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_SUCURSAL_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteSUCURSAL(CSUCURSALBE oCSUCURSAL, FbTransaction st)
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
                auxPar.Value = oCSUCURSAL.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from SUCURSAL where

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




        public CSUCURSALBE AgregarSUCURSAL(CSUCURSALBE oCSUCURSAL, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSUCURSAL(oCSUCURSAL, st);
                if (iRes == 1)
                {
                    this.IComentario = "El SUCURSAL ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarSUCURSALD(oCSUCURSAL, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarSUCURSAL(CSUCURSALBE oCSUCURSAL, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSUCURSAL(oCSUCURSAL, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SUCURSAL no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarSUCURSALD(oCSUCURSAL, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarSUCURSAL(CSUCURSALBE oCSUCURSALNuevo, CSUCURSALBE oCSUCURSALAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSUCURSAL(oCSUCURSALAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SUCURSAL no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarSUCURSALD(oCSUCURSALNuevo, oCSUCURSALAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }




        public CSUCURSALBE seleccionarSUCURSALPorClave(CSUCURSALBE oCSUCURSAL, FbTransaction st)
        {

            CSUCURSALBE retorno = new CSUCURSALBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SUCURSAL where CLAVE=@CLAVE  ";


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                auxPar.Value = oCSUCURSAL.ICLAVE;
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

                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = (string)(dr["DESCRIPCION"]);
                    }

                    if (dr["MEMO"] != System.DBNull.Value)
                    {
                        retorno.IMEMO = (object)(dr["MEMO"]);
                    }


                    if (dr["GRUPOSUCURSALID"] != System.DBNull.Value)
                    {
                        retorno.IGRUPOSUCURSALID = (long)(dr["GRUPOSUCURSALID"]);
                    }

                    if (dr["LISTA_PRECIO_TRASPASO"] != System.DBNull.Value)
                    {
                        retorno.ILISTA_PRECIO_TRASPASO = (string)(dr["LISTA_PRECIO_TRASPASO"]);
                    }

                    if (dr["MAXDOCTOSPENDIENTES"] != System.DBNull.Value)
                    {
                        retorno.IMAXDOCTOSPENDIENTES = (int)(dr["MAXDOCTOSPENDIENTES"]);
                    }

                    if (dr["ESMATRIZ"] != System.DBNull.Value)
                    {
                        retorno.IESMATRIZ = (string)(dr["ESMATRIZ"]);
                    }

                    if (dr["PRECIORECEPCIONTRASLADO"] != System.DBNull.Value)
                    {
                        retorno.IPRECIORECEPCIONTRASLADO = (long)(dr["PRECIORECEPCIONTRASLADO"]);
                    }


                    if (dr["MOSTRARPRECIOREAL"] != System.DBNull.Value)
                    {
                        retorno.IMOSTRARPRECIOREAL = (string)(dr["MOSTRARPRECIOREAL"]);
                    }


                    if (dr["PRECIOENVIOTRASLADO"] != System.DBNull.Value)
                    {
                        retorno.IPRECIOENVIOTRASLADO = (long)(dr["PRECIOENVIOTRASLADO"]);
                    }

                    if (dr["CLIENTECLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLIENTECLAVE = (string)(dr["CLIENTECLAVE"]);
                    }


                    if (dr["ESFRANQUICIA"] != System.DBNull.Value)
                    {
                        retorno.IESFRANQUICIA = (string)(dr["ESFRANQUICIA"]);
                    }
                    if (dr["POR_FACT_ELECT"] != System.DBNull.Value)
                    {
                        retorno.IPOR_FACT_ELECT = (string)(dr["POR_FACT_ELECT"]);
                    }

                    if (dr["ENTREGACALLE"] != System.DBNull.Value)
                    {
                        retorno.IENTREGACALLE = (string)(dr["ENTREGACALLE"]);
                    }
                    if (dr["ENTREGANUMEROINTERIOR"] != System.DBNull.Value)
                    {
                        retorno.IENTREGANUMEROINTERIOR = (string)(dr["ENTREGANUMEROINTERIOR"]);
                    }
                    if (dr["ENTREGANUMEROEXTERIOR"] != System.DBNull.Value)
                    {
                        retorno.IENTREGANUMEROEXTERIOR = (string)(dr["ENTREGANUMEROEXTERIOR"]);
                    }
                    if (dr["ENTREGACOLONIA"] != System.DBNull.Value)
                    {
                        retorno.IENTREGACOLONIA = (string)(dr["ENTREGACOLONIA"]);
                    }
                    if (dr["ENTREGAMUNICIPIO"] != System.DBNull.Value)
                    {
                        retorno.IENTREGAMUNICIPIO = (string)(dr["ENTREGAMUNICIPIO"]);
                    }
                    if (dr["ENTREGAESTADO"] != System.DBNull.Value)
                    {
                        retorno.IENTREGAESTADO = (string)(dr["ENTREGAESTADO"]);
                    }
                    if (dr["ENTREGACODIGOPOSTAL"] != System.DBNull.Value)
                    {
                        retorno.IENTREGACODIGOPOSTAL = (string)(dr["ENTREGACODIGOPOSTAL"]);
                    }

                    if (dr["PROVEEDORCLAVE"] != System.DBNull.Value)
                    {
                        retorno.IPROVEEDORCLAVE = (string)(dr["PROVEEDORCLAVE"]);
                    }

                    if (dr["SURTIDOR"] != System.DBNull.Value)
                    {
                        retorno.ISURTIDOR = (string)(dr["SURTIDOR"]);
                    }


                    if (dr["PORC_AUMENTO_PRECIO"] != System.DBNull.Value)
                    {
                        retorno.IPORC_AUMENTO_PRECIO = (decimal)(dr["PORC_AUMENTO_PRECIO"]);
                    }


                    if (dr["RUTARESPALDOORIGEN"] != System.DBNull.Value)
                    {
                        retorno.IRUTARESPALDOORIGEN = (string)(dr["RUTARESPALDOORIGEN"]);
                    }

                    if (dr["RUTARESPALDODESTINO"] != System.DBNull.Value)
                    {
                        retorno.IRUTARESPALDODESTINO = (string)(dr["RUTARESPALDODESTINO"]);
                    }


                    if (dr["MANEJAPRECIOXDESCUENTO"] != System.DBNull.Value)
                    {
                        retorno.IMANEJAPRECIOXDESCUENTO = (string)(dr["MANEJAPRECIOXDESCUENTO"]);
                    }


                    if (dr["PREFIJOPRECIOXDESCUENTO"] != System.DBNull.Value)
                    {
                        retorno.IPREFIJOPRECIOXDESCUENTO = (string)(dr["PREFIJOPRECIOXDESCUENTO"]);
                    }

                    if (dr["NOMBRERESPALDOBD"] != System.DBNull.Value)
                    {
                        retorno.INOMBRERESPALDOBD = (string)(dr["NOMBRERESPALDOBD"]);
                    }


                    if (dr["BANCOCLAVE"] != System.DBNull.Value)
                    {
                        retorno.IBANCOCLAVE = (string)(dr["BANCOCLAVE"]);
                    }


                    if (dr["CUENTAREFERENCIA"] != System.DBNull.Value)
                    {
                        retorno.ICUENTAREFERENCIA = (string)(dr["CUENTAREFERENCIA"]);
                    }


                    if (dr["RUTARESPALDORED"] != System.DBNull.Value)
                    {
                        retorno.IRUTARESPALDORED = (string)(dr["RUTARESPALDORED"]);
                    }

                    if (dr["CUENTAPOLIZA"] != System.DBNull.Value)
                    {
                        retorno.ICUENTAPOLIZA = (string)(dr["CUENTAPOLIZA"]);
                    }


                    if (dr["LISTAPRECIOCLAVE"] != System.DBNull.Value)
                    {
                        retorno.ILISTAPRECIOCLAVE = (string)(dr["LISTAPRECIOCLAVE"]);
                    }


                    if (dr["EMPPROV"] != System.DBNull.Value)
                    {
                        retorno.IEMPPROV = (string)(dr["EMPPROV"]);
                    }


                    if (dr["IMNUPROD"] != System.DBNull.Value)
                    {
                        retorno.IIMNUPROD = (string)(dr["IMNUPROD"]);
                    }

                    if (dr["ENTREGA_SAT_COLONIAID"] != System.DBNull.Value)
                    {
                        retorno.IENTREGA_SAT_COLONIAID = (long)(dr["ENTREGA_SAT_COLONIAID"]);
                    }

                    if (dr["ENTREGA_SAT_LOCALIDADID"] != System.DBNull.Value)
                    {
                        retorno.IENTREGA_SAT_LOCALIDADID = (long)(dr["ENTREGA_SAT_LOCALIDADID"]);
                    }

                    if (dr["ENTREGA_SAT_MUNICIPIOID"] != System.DBNull.Value)
                    {
                        retorno.IENTREGA_SAT_MUNICIPIOID = (long)(dr["ENTREGA_SAT_MUNICIPIOID"]);
                    }

                    if (dr["ENTREGA_DISTANCIA"] != System.DBNull.Value)
                    {
                        retorno.IENTREGA_DISTANCIA = (decimal)(dr["ENTREGA_DISTANCIA"]);
                    }


                    if (dr["ENTREGAREFERENCIADOM"] != System.DBNull.Value)
                    {
                        retorno.IENTREGAREFERENCIADOM = (string)(dr["ENTREGAREFERENCIADOM"]);
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


        ///Retorna arreglo de sucbe
        ///
        public CSUCURSALBE[] seleccionarSUCURSALES()
        {

            List<CSUCURSALBE> retorno = new List<CSUCURSALBE>();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();

                String CmdTxt = @"select * from SUCURSAL ";


                /*auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                auxPar.Value = oCSUCURSAL.ICLAVE;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);*/



                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt);
   

               while(dr.Read())
                {
                    CSUCURSALBE auxSuc = new CSUCURSALBE();

                    if (dr["ID"] != System.DBNull.Value)
                    {
                        auxSuc.IID = (long)(dr["ID"]);
                    }

                    if (dr["ACTIVO"] != System.DBNull.Value)
                    {
                        auxSuc.IACTIVO = (string)(dr["ACTIVO"]);
                    }

                    if (dr["CREADO"] != System.DBNull.Value)
                    {
                        auxSuc.ICREADO = (object)(dr["CREADO"]);
                    }

                    if (dr["CREADOPOR_USERID"] != System.DBNull.Value)
                    {
                        auxSuc.ICREADOPOR_USERID = (long)(dr["CREADOPOR_USERID"]);
                    }

                    if (dr["MODIFICADO"] != System.DBNull.Value)
                    {
                        auxSuc.IMODIFICADO = (object)(dr["MODIFICADO"]);
                    }

                    if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
                    {
                        auxSuc.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
                    }

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        auxSuc.ICLAVE = (string)(dr["CLAVE"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        auxSuc.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        auxSuc.IDESCRIPCION = (string)(dr["DESCRIPCION"]);
                    }

                    if (dr["MEMO"] != System.DBNull.Value)
                    {
                        auxSuc.IMEMO = (object)(dr["MEMO"]);
                    }


                    if (dr["GRUPOSUCURSALID"] != System.DBNull.Value)
                    {
                        auxSuc.IGRUPOSUCURSALID = (long)(dr["GRUPOSUCURSALID"]);
                    }

                    if (dr["LISTA_PRECIO_TRASPASO"] != System.DBNull.Value)
                    {
                        auxSuc.ILISTA_PRECIO_TRASPASO = (string)(dr["LISTA_PRECIO_TRASPASO"]);
                    }

                    if (dr["MAXDOCTOSPENDIENTES"] != System.DBNull.Value)
                    {
                        auxSuc.IMAXDOCTOSPENDIENTES = (int)(dr["MAXDOCTOSPENDIENTES"]);
                    }

                    if (dr["ESMATRIZ"] != System.DBNull.Value)
                    {
                        auxSuc.IESMATRIZ = (string)(dr["ESMATRIZ"]);
                    }

                    if (dr["PRECIORECEPCIONTRASLADO"] != System.DBNull.Value)
                    {
                        auxSuc.IPRECIORECEPCIONTRASLADO = (long)(dr["PRECIORECEPCIONTRASLADO"]);
                    }


                    if (dr["MOSTRARPRECIOREAL"] != System.DBNull.Value)
                    {
                        auxSuc.IMOSTRARPRECIOREAL = (string)(dr["MOSTRARPRECIOREAL"]);
                    }


                    if (dr["PRECIOENVIOTRASLADO"] != System.DBNull.Value)
                    {
                        auxSuc.IPRECIOENVIOTRASLADO = (long)(dr["PRECIOENVIOTRASLADO"]);
                    }

                    if (dr["CLIENTECLAVE"] != System.DBNull.Value)
                    {
                        auxSuc.ICLIENTECLAVE = (string)(dr["CLIENTECLAVE"]);
                    }


                    if (dr["ESFRANQUICIA"] != System.DBNull.Value)
                    {
                        auxSuc.IESFRANQUICIA = (string)(dr["ESFRANQUICIA"]);
                    }
                    if (dr["POR_FACT_ELECT"] != System.DBNull.Value)
                    {
                        auxSuc.IPOR_FACT_ELECT = (string)(dr["POR_FACT_ELECT"]);
                    }

                    if (dr["ENTREGACALLE"] != System.DBNull.Value)
                    {
                        auxSuc.IENTREGACALLE = (string)(dr["ENTREGACALLE"]);
                    }
                    if (dr["ENTREGANUMEROINTERIOR"] != System.DBNull.Value)
                    {
                        auxSuc.IENTREGANUMEROINTERIOR = (string)(dr["ENTREGANUMEROINTERIOR"]);
                    }
                    if (dr["ENTREGANUMEROEXTERIOR"] != System.DBNull.Value)
                    {
                        auxSuc.IENTREGANUMEROEXTERIOR = (string)(dr["ENTREGANUMEROEXTERIOR"]);
                    }
                    if (dr["ENTREGACOLONIA"] != System.DBNull.Value)
                    {
                        auxSuc.IENTREGACOLONIA = (string)(dr["ENTREGACOLONIA"]);
                    }
                    if (dr["ENTREGAMUNICIPIO"] != System.DBNull.Value)
                    {
                        auxSuc.IENTREGAMUNICIPIO = (string)(dr["ENTREGAMUNICIPIO"]);
                    }
                    if (dr["ENTREGAESTADO"] != System.DBNull.Value)
                    {
                        auxSuc.IENTREGAESTADO = (string)(dr["ENTREGAESTADO"]);
                    }
                    if (dr["ENTREGACODIGOPOSTAL"] != System.DBNull.Value)
                    {
                        auxSuc.IENTREGACODIGOPOSTAL = (string)(dr["ENTREGACODIGOPOSTAL"]);
                    }

                    if (dr["PROVEEDORCLAVE"] != System.DBNull.Value)
                    {
                        auxSuc.IPROVEEDORCLAVE = (string)(dr["PROVEEDORCLAVE"]);
                    }

                    if (dr["SURTIDOR"] != System.DBNull.Value)
                    {
                        auxSuc.ISURTIDOR = (string)(dr["SURTIDOR"]);
                    }


                    if (dr["PORC_AUMENTO_PRECIO"] != System.DBNull.Value)
                    {
                        auxSuc.IPORC_AUMENTO_PRECIO = (decimal)(dr["PORC_AUMENTO_PRECIO"]);
                    }


                    if (dr["RUTARESPALDOORIGEN"] != System.DBNull.Value)
                    {
                        auxSuc.IRUTARESPALDOORIGEN = (string)(dr["RUTARESPALDOORIGEN"]);
                    }

                    if (dr["RUTARESPALDODESTINO"] != System.DBNull.Value)
                    {
                        auxSuc.IRUTARESPALDODESTINO = (string)(dr["RUTARESPALDODESTINO"]);
                    }


                    if (dr["MANEJAPRECIOXDESCUENTO"] != System.DBNull.Value)
                    {
                        auxSuc.IMANEJAPRECIOXDESCUENTO = (string)(dr["MANEJAPRECIOXDESCUENTO"]);
                    }


                    if (dr["PREFIJOPRECIOXDESCUENTO"] != System.DBNull.Value)
                    {
                        auxSuc.IPREFIJOPRECIOXDESCUENTO = (string)(dr["PREFIJOPRECIOXDESCUENTO"]);
                    }

                    if (dr["NOMBRERESPALDOBD"] != System.DBNull.Value)
                    {
                        auxSuc.INOMBRERESPALDOBD = (string)(dr["NOMBRERESPALDOBD"]);
                    }



                    if (dr["BANCOCLAVE"] != System.DBNull.Value)
                    {
                        auxSuc.IBANCOCLAVE = (string)(dr["BANCOCLAVE"]);
                    }


                    if (dr["CUENTAREFERENCIA"] != System.DBNull.Value)
                    {
                        auxSuc.ICUENTAREFERENCIA = (string)(dr["CUENTAREFERENCIA"]);
                    }


                    if (dr["RUTARESPALDORED"] != System.DBNull.Value)
                    {
                        auxSuc.IRUTARESPALDORED = (string)(dr["RUTARESPALDORED"]);
                    }


                    if (dr["CUENTAPOLIZA"] != System.DBNull.Value)
                    {
                        auxSuc.ICUENTAPOLIZA = (string)(dr["CUENTAPOLIZA"]);
                    }


                    if (dr["LISTAPRECIOCLAVE"] != System.DBNull.Value)
                    {
                        auxSuc.ILISTAPRECIOCLAVE = (string)(dr["LISTAPRECIOCLAVE"]);
                    }

                    if (dr["EMPPROV"] != System.DBNull.Value)
                    {
                        auxSuc.IEMPPROV = (string)(dr["EMPPROV"]);
                    }



                    if (dr["IMNUPROD"] != System.DBNull.Value)
                    {
                        auxSuc.IIMNUPROD = (string)(dr["IMNUPROD"]);
                    }

                    if (dr["ENTREGA_SAT_COLONIAID"] != System.DBNull.Value)
                    {
                        auxSuc.IENTREGA_SAT_COLONIAID = (long)(dr["ENTREGA_SAT_COLONIAID"]);
                    }

                    if (dr["ENTREGA_SAT_LOCALIDADID"] != System.DBNull.Value)
                    {
                        auxSuc.IENTREGA_SAT_LOCALIDADID = (long)(dr["ENTREGA_SAT_LOCALIDADID"]);
                    }

                    if (dr["ENTREGA_SAT_MUNICIPIOID"] != System.DBNull.Value)
                    {
                        auxSuc.IENTREGA_SAT_MUNICIPIOID = (long)(dr["ENTREGA_SAT_MUNICIPIOID"]);
                    }

                    if (dr["ENTREGA_DISTANCIA"] != System.DBNull.Value)
                    {
                        auxSuc.IENTREGA_DISTANCIA = (decimal)(dr["ENTREGA_DISTANCIA"]);
                    }


                    if (dr["ENTREGAREFERENCIADOM"] != System.DBNull.Value)
                    {
                        auxSuc.IENTREGAREFERENCIADOM = (string)(dr["ENTREGAREFERENCIADOM"]);
                    }

                    retorno.Add(auxSuc);

                }
               Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                return retorno.ToArray();
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public CSUCURSALBE seleccionarSUCURSALPorClaveCliente(CSUCURSALBE oCSUCURSAL, FbTransaction st)
        {

            CSUCURSALBE retorno = new CSUCURSALBE();
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SUCURSAL where CLIENTECLAVE=@CLIENTECLAVE  ";


                auxPar = new FbParameter("@CLIENTECLAVE", FbDbType.VarChar);
                auxPar.Value = oCSUCURSAL.ICLIENTECLAVE;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {
                    retorno = getFromReader(dr);

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


        public CSUCURSALBE getFromReader(FbDataReader dr)
        {


            CSUCURSALBE retorno = new CSUCURSALBE();

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

            if (dr["DESCRIPCION"] != System.DBNull.Value)
            {
                retorno.IDESCRIPCION = (string)(dr["DESCRIPCION"]);
            }

            if (dr["MEMO"] != System.DBNull.Value)
            {
                retorno.IMEMO = (object)(dr["MEMO"]);
            }


            if (dr["GRUPOSUCURSALID"] != System.DBNull.Value)
            {
                retorno.IGRUPOSUCURSALID = (long)(dr["GRUPOSUCURSALID"]);
            }

            if (dr["LISTA_PRECIO_TRASPASO"] != System.DBNull.Value)
            {
                retorno.ILISTA_PRECIO_TRASPASO = (string)(dr["LISTA_PRECIO_TRASPASO"]);
            }

            if (dr["MAXDOCTOSPENDIENTES"] != System.DBNull.Value)
            {
                retorno.IMAXDOCTOSPENDIENTES = (int)(dr["MAXDOCTOSPENDIENTES"]);
            }

            if (dr["ESMATRIZ"] != System.DBNull.Value)
            {
                retorno.IESMATRIZ = (string)(dr["ESMATRIZ"]);
            }

            if (dr["PRECIORECEPCIONTRASLADO"] != System.DBNull.Value)
            {
                retorno.IPRECIORECEPCIONTRASLADO = (long)(dr["PRECIORECEPCIONTRASLADO"]);
            }


            if (dr["MOSTRARPRECIOREAL"] != System.DBNull.Value)
            {
                retorno.IMOSTRARPRECIOREAL = (string)(dr["MOSTRARPRECIOREAL"]);
            }


            if (dr["PRECIOENVIOTRASLADO"] != System.DBNull.Value)
            {
                retorno.IPRECIOENVIOTRASLADO = (long)(dr["PRECIOENVIOTRASLADO"]);
            }

            if (dr["CLIENTECLAVE"] != System.DBNull.Value)
            {
                retorno.ICLIENTECLAVE = (string)(dr["CLIENTECLAVE"]);
            }


            if (dr["ESFRANQUICIA"] != System.DBNull.Value)
            {
                retorno.IESFRANQUICIA = (string)(dr["ESFRANQUICIA"]);
            }
            if (dr["POR_FACT_ELECT"] != System.DBNull.Value)
            {
                retorno.IPOR_FACT_ELECT = (string)(dr["POR_FACT_ELECT"]);
            }

            if (dr["ENTREGACALLE"] != System.DBNull.Value)
            {
                retorno.IENTREGACALLE = (string)(dr["ENTREGACALLE"]);
            }
            if (dr["ENTREGANUMEROINTERIOR"] != System.DBNull.Value)
            {
                retorno.IENTREGANUMEROINTERIOR = (string)(dr["ENTREGANUMEROINTERIOR"]);
            }
            if (dr["ENTREGANUMEROEXTERIOR"] != System.DBNull.Value)
            {
                retorno.IENTREGANUMEROEXTERIOR = (string)(dr["ENTREGANUMEROEXTERIOR"]);
            }
            if (dr["ENTREGACOLONIA"] != System.DBNull.Value)
            {
                retorno.IENTREGACOLONIA = (string)(dr["ENTREGACOLONIA"]);
            }
            if (dr["ENTREGAMUNICIPIO"] != System.DBNull.Value)
            {
                retorno.IENTREGAMUNICIPIO = (string)(dr["ENTREGAMUNICIPIO"]);
            }
            if (dr["ENTREGAESTADO"] != System.DBNull.Value)
            {
                retorno.IENTREGAESTADO = (string)(dr["ENTREGAESTADO"]);
            }
            if (dr["ENTREGACODIGOPOSTAL"] != System.DBNull.Value)
            {
                retorno.IENTREGACODIGOPOSTAL = (string)(dr["ENTREGACODIGOPOSTAL"]);
            }

            if (dr["PROVEEDORCLAVE"] != System.DBNull.Value)
            {
                retorno.IPROVEEDORCLAVE = (string)(dr["PROVEEDORCLAVE"]);
            }

            if (dr["SURTIDOR"] != System.DBNull.Value)
            {
                retorno.ISURTIDOR = (string)(dr["SURTIDOR"]);
            }


            if (dr["PORC_AUMENTO_PRECIO"] != System.DBNull.Value)
            {
                retorno.IPORC_AUMENTO_PRECIO = (decimal)(dr["PORC_AUMENTO_PRECIO"]);
            }


            if (dr["RUTARESPALDOORIGEN"] != System.DBNull.Value)
            {
                retorno.IRUTARESPALDOORIGEN = (string)(dr["RUTARESPALDOORIGEN"]);
            }

            if (dr["RUTARESPALDODESTINO"] != System.DBNull.Value)
            {
                retorno.IRUTARESPALDODESTINO = (string)(dr["RUTARESPALDODESTINO"]);
            }


            if (dr["MANEJAPRECIOXDESCUENTO"] != System.DBNull.Value)
            {
                retorno.IMANEJAPRECIOXDESCUENTO = (string)(dr["MANEJAPRECIOXDESCUENTO"]);
            }


            if (dr["PREFIJOPRECIOXDESCUENTO"] != System.DBNull.Value)
            {
                retorno.IPREFIJOPRECIOXDESCUENTO = (string)(dr["PREFIJOPRECIOXDESCUENTO"]);
            }

            if (dr["NOMBRERESPALDOBD"] != System.DBNull.Value)
            {
                retorno.INOMBRERESPALDOBD = (string)(dr["NOMBRERESPALDOBD"]);
            }


            if (dr["BANCOCLAVE"] != System.DBNull.Value)
            {
                retorno.IBANCOCLAVE = (string)(dr["BANCOCLAVE"]);
            }


            if (dr["CUENTAREFERENCIA"] != System.DBNull.Value)
            {
                retorno.ICUENTAREFERENCIA = (string)(dr["CUENTAREFERENCIA"]);
            }


            if (dr["RUTARESPALDORED"] != System.DBNull.Value)
            {
                retorno.IRUTARESPALDORED = (string)(dr["RUTARESPALDORED"]);
            }

            if (dr["CUENTAPOLIZA"] != System.DBNull.Value)
            {
                retorno.ICUENTAPOLIZA = (string)(dr["CUENTAPOLIZA"]);
            }


            if (dr["LISTAPRECIOCLAVE"] != System.DBNull.Value)
            {
                retorno.ILISTAPRECIOCLAVE = (string)(dr["LISTAPRECIOCLAVE"]);
            }


            if (dr["EMPPROV"] != System.DBNull.Value)
            {
                retorno.IEMPPROV = (string)(dr["EMPPROV"]);
            }


            if (dr["IMNUPROD"] != System.DBNull.Value)
            {
                retorno.IIMNUPROD = (string)(dr["IMNUPROD"]);
            }

            if (dr["ENTREGA_SAT_COLONIAID"] != System.DBNull.Value)
            {
                retorno.IENTREGA_SAT_COLONIAID = (long)(dr["ENTREGA_SAT_COLONIAID"]);
            }

            if (dr["ENTREGA_SAT_LOCALIDADID"] != System.DBNull.Value)
            {
                retorno.IENTREGA_SAT_LOCALIDADID = (long)(dr["ENTREGA_SAT_LOCALIDADID"]);
            }

            if (dr["ENTREGA_SAT_MUNICIPIOID"] != System.DBNull.Value)
            {
                retorno.IENTREGA_SAT_MUNICIPIOID = (long)(dr["ENTREGA_SAT_MUNICIPIOID"]);
            }

            if (dr["ENTREGA_DISTANCIA"] != System.DBNull.Value)
            {
                retorno.IENTREGA_DISTANCIA = (decimal)(dr["ENTREGA_DISTANCIA"]);
            }


            if (dr["ENTREGAREFERENCIADOM"] != System.DBNull.Value)
            {
                retorno.IENTREGAREFERENCIADOM = (string)(dr["ENTREGAREFERENCIADOM"]);
            }

            return retorno;
            
        }

        public CSUCURSALD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();

            //
            // TODO: Add constructor logic here
            //
        }
    }
}
