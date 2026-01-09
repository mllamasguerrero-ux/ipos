
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
    public class CPROMOCIOND
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

        public CPROMOCIONBE AgregarPROMOCIOND(CPROMOCIONBE oCPROMOCION, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCPROMOCION.isnull["IACTIVO"])
                {
                    auxPar.Value = oCPROMOCION.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPROMOCION.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCPROMOCION.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCPROMOCION.isnull["ICLAVE"])
                {
                    auxPar.Value = oCPROMOCION.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCPROMOCION.isnull["INOMBRE"])
                {
                    auxPar.Value = oCPROMOCION.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCPROMOCION.isnull["IDESCRIPCION"])
                {
                    auxPar.Value = oCPROMOCION.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MEMO", FbDbType.VarChar);
                if (!(bool)oCPROMOCION.isnull["IMEMO"])
                {
                    auxPar.Value = oCPROMOCION.IMEMO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                if (!(bool)oCPROMOCION.isnull["ISUCURSALID"])
                {
                    auxPar.Value = oCPROMOCION.ISUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PROMOCION", FbDbType.Char);
                if (!(bool)oCPROMOCION.isnull["IPROMOCION"])
                {
                    auxPar.Value = oCPROMOCION.IPROMOCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDAD", FbDbType.Numeric);
                if (!(bool)oCPROMOCION.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCPROMOCION.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                if (!(bool)oCPROMOCION.isnull["IPRODUCTOID"])
                {
                    auxPar.Value = oCPROMOCION.IPRODUCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@UTILIDAD", FbDbType.Numeric);
                if (!(bool)oCPROMOCION.isnull["IUTILIDAD"])
                {
                    auxPar.Value = oCPROMOCION.IUTILIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADLLEVATE", FbDbType.Numeric);
                if (!(bool)oCPROMOCION.isnull["ICANTIDADLLEVATE"])
                {
                    auxPar.Value = oCPROMOCION.ICANTIDADLLEVATE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPORTE", FbDbType.Numeric);
                if (!(bool)oCPROMOCION.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCPROMOCION.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PORCENTAJEDESCUENTO", FbDbType.Numeric);
                if (!(bool)oCPROMOCION.isnull["IPORCENTAJEDESCUENTO"])
                {
                    auxPar.Value = oCPROMOCION.IPORCENTAJEDESCUENTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOPROMOCIONID", FbDbType.BigInt);
                if (!(bool)oCPROMOCION.isnull["ITIPOPROMOCIONID"])
                {
                    auxPar.Value = oCPROMOCION.ITIPOPROMOCIONID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RANGOPROMOCIONID", FbDbType.BigInt);
                if (!(bool)oCPROMOCION.isnull["IRANGOPROMOCIONID"])
                {
                    auxPar.Value = oCPROMOCION.IRANGOPROMOCIONID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LINEAID", FbDbType.BigInt);
                if (!(bool)oCPROMOCION.isnull["ILINEAID"])
                {
                    auxPar.Value = oCPROMOCION.ILINEAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAINICIO", FbDbType.Date);
                if (!(bool)oCPROMOCION.isnull["IFECHAINICIO"])
                {
                    auxPar.Value = oCPROMOCION.IFECHAINICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAFIN", FbDbType.Date);
                if (!(bool)oCPROMOCION.isnull["IFECHAFIN"])
                {
                    auxPar.Value = oCPROMOCION.IFECHAFIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LUNES", FbDbType.Char);
                if (!(bool)oCPROMOCION.isnull["ILUNES"])
                {
                    auxPar.Value = oCPROMOCION.ILUNES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MARTES", FbDbType.Char);
                if (!(bool)oCPROMOCION.isnull["IMARTES"])
                {
                    auxPar.Value = oCPROMOCION.IMARTES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MIERCOLES", FbDbType.Char);
                if (!(bool)oCPROMOCION.isnull["IMIERCOLES"])
                {
                    auxPar.Value = oCPROMOCION.IMIERCOLES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@JUEVES", FbDbType.Char);
                if (!(bool)oCPROMOCION.isnull["IJUEVES"])
                {
                    auxPar.Value = oCPROMOCION.IJUEVES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VIERNES", FbDbType.Char);
                if (!(bool)oCPROMOCION.isnull["IVIERNES"])
                {
                    auxPar.Value = oCPROMOCION.IVIERNES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SABADO", FbDbType.Char);
                if (!(bool)oCPROMOCION.isnull["ISABADO"])
                {
                    auxPar.Value = oCPROMOCION.ISABADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOMINGO", FbDbType.Char);
                if (!(bool)oCPROMOCION.isnull["IDOMINGO"])
                {
                    auxPar.Value = oCPROMOCION.IDOMINGO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PORIMPORTE", FbDbType.Numeric);
                if (!(bool)oCPROMOCION.isnull["IPORIMPORTE"])
                {
                    auxPar.Value = oCPROMOCION.IPORIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ENMONEDERO", FbDbType.Char);
                if (!(bool)oCPROMOCION.isnull["IENMONEDERO"])
                {
                    auxPar.Value = oCPROMOCION.IENMONEDERO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@ENMONEDERO", FbDbType.Char);
                if (!(bool)oCPROMOCION.isnull["IENMONEDERO"])
                {
                    auxPar.Value = oCPROMOCION.IENMONEDERO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@IMAGEN", FbDbType.Char);
                if (!(bool)oCPROMOCION.isnull["IIMAGEN"])
                {
                    auxPar.Value = oCPROMOCION.IIMAGEN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@MOSTRARDATOSCLIENTE", FbDbType.Char);
                if (!(bool)oCPROMOCION.isnull["IMOSTRARDATOSCLIENTE"])
                {
                    auxPar.Value = oCPROMOCION.IMOSTRARDATOSCLIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESMULTIDETALLE", FbDbType.Char);
                if (!(bool)oCPROMOCION.isnull["IESMULTIDETALLE"])
                {
                    auxPar.Value = oCPROMOCION.IESMULTIDETALLE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCMULTIDETALLE", FbDbType.VarChar);
                if (!(bool)oCPROMOCION.isnull["IDESCMULTIDETALLE"])
                {
                    auxPar.Value = oCPROMOCION.IDESCMULTIDETALLE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO PROMOCION
      (

ACTIVO,

CLAVE,

NOMBRE,

DESCRIPCION,

MEMO,

SUCURSALID,

PROMOCION,

CANTIDAD,

PRODUCTOID,

UTILIDAD,

CANTIDADLLEVATE,

IMPORTE,

PORCENTAJEDESCUENTO,

TIPOPROMOCIONID,

RANGOPROMOCIONID,

LINEAID,

FECHAINICIO,

FECHAFIN,

LUNES,

MARTES,

MIERCOLES,

JUEVES,

VIERNES,

SABADO,

DOMINGO,

PORIMPORTE,

ENMONEDERO,

IMAGEN,

MOSTRARDATOSCLIENTE,

ESMULTIDETALLE,

DESCMULTIDETALLE
         )

Values (


@ACTIVO,

@CLAVE,

@NOMBRE,

@DESCRIPCION,

@MEMO,

@SUCURSALID,

@PROMOCION,

@CANTIDAD,

@PRODUCTOID,

@UTILIDAD,

@CANTIDADLLEVATE,

@IMPORTE,

@PORCENTAJEDESCUENTO,

@TIPOPROMOCIONID,

@RANGOPROMOCIONID,

@LINEAID,

@FECHAINICIO,

@FECHAFIN,

@LUNES,

@MARTES,

@MIERCOLES,

@JUEVES,

@VIERNES,

@SABADO,

@DOMINGO,

@PORIMPORTE,

@ENMONEDERO,

@IMAGEN,

@MOSTRARDATOSCLIENTE,

@ESMULTIDETALLE,

@DESCMULTIDETALLE
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return oCPROMOCION;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarPROMOCIOND(CPROMOCIONBE oCPROMOCION, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPROMOCION.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from PROMOCION
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

        public bool BorrarTodoPROMOCION(FbTransaction st)
        {
            try
            {
                string commandText = @"  Delete from PROMOCION;";

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText);


                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }

        public bool CambiarPROMOCIOND(CPROMOCIONBE oCPROMOCIONNuevo, CPROMOCIONBE oCPROMOCIONAnterior, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCPROMOCIONNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCPROMOCIONNuevo.isnull["INOMBRE"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCPROMOCIONNuevo.isnull["IDESCRIPCION"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MEMO", FbDbType.VarChar);
                if (!(bool)oCPROMOCIONNuevo.isnull["IMEMO"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.IMEMO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                if (!(bool)oCPROMOCIONNuevo.isnull["ISUCURSALID"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.ISUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PROMOCION", FbDbType.Char);
                if (!(bool)oCPROMOCIONNuevo.isnull["IPROMOCION"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.IPROMOCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CANTIDAD", FbDbType.Numeric);
                if (!(bool)oCPROMOCIONNuevo.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                if (!(bool)oCPROMOCIONNuevo.isnull["IPRODUCTOID"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.IPRODUCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@UTILIDAD", FbDbType.Numeric);
                if (!(bool)oCPROMOCIONNuevo.isnull["IUTILIDAD"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.IUTILIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CANTIDADLLEVATE", FbDbType.Numeric);
                if (!(bool)oCPROMOCIONNuevo.isnull["ICANTIDADLLEVATE"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.ICANTIDADLLEVATE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IMPORTE", FbDbType.Numeric);
                if (!(bool)oCPROMOCIONNuevo.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PORCENTAJEDESCUENTO", FbDbType.Numeric);
                if (!(bool)oCPROMOCIONNuevo.isnull["IPORCENTAJEDESCUENTO"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.IPORCENTAJEDESCUENTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPOPROMOCIONID", FbDbType.BigInt);
                if (!(bool)oCPROMOCIONNuevo.isnull["ITIPOPROMOCIONID"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.ITIPOPROMOCIONID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@RANGOPROMOCIONID", FbDbType.BigInt);
                if (!(bool)oCPROMOCIONNuevo.isnull["IRANGOPROMOCIONID"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.IRANGOPROMOCIONID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LINEAID", FbDbType.BigInt);
                if (!(bool)oCPROMOCIONNuevo.isnull["ILINEAID"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.ILINEAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAINICIO", FbDbType.Date);
                if (!(bool)oCPROMOCIONNuevo.isnull["IFECHAINICIO"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.IFECHAINICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAFIN", FbDbType.Date);
                if (!(bool)oCPROMOCIONNuevo.isnull["IFECHAFIN"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.IFECHAFIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LUNES", FbDbType.Char);
                if (!(bool)oCPROMOCIONNuevo.isnull["ILUNES"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.ILUNES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MARTES", FbDbType.Char);
                if (!(bool)oCPROMOCIONNuevo.isnull["IMARTES"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.IMARTES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MIERCOLES", FbDbType.Char);
                if (!(bool)oCPROMOCIONNuevo.isnull["IMIERCOLES"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.IMIERCOLES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@JUEVES", FbDbType.Char);
                if (!(bool)oCPROMOCIONNuevo.isnull["IJUEVES"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.IJUEVES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@VIERNES", FbDbType.Char);
                if (!(bool)oCPROMOCIONNuevo.isnull["IVIERNES"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.IVIERNES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SABADO", FbDbType.Char);
                if (!(bool)oCPROMOCIONNuevo.isnull["ISABADO"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.ISABADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOMINGO", FbDbType.Char);
                if (!(bool)oCPROMOCIONNuevo.isnull["IDOMINGO"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.IDOMINGO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PORIMPORTE", FbDbType.Numeric);
                if (!(bool)oCPROMOCIONNuevo.isnull["IPORIMPORTE"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.IPORIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ENMONEDERO", FbDbType.Char);
                if (!(bool)oCPROMOCIONNuevo.isnull["IENMONEDERO"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.IENMONEDERO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@IMAGEN", FbDbType.Char);
                if (!(bool)oCPROMOCIONNuevo.isnull["IIMAGEN"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.IIMAGEN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@MOSTRARDATOSCLIENTE", FbDbType.Char);
                if (!(bool)oCPROMOCIONNuevo.isnull["IMOSTRARDATOSCLIENTE"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.IMOSTRARDATOSCLIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESMULTIDETALLE", FbDbType.Char);
                if (!(bool)oCPROMOCIONNuevo.isnull["IESMULTIDETALLE"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.IESMULTIDETALLE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCMULTIDETALLE", FbDbType.VarChar);
                if (!(bool)oCPROMOCIONNuevo.isnull["IDESCMULTIDETALLE"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.IDESCMULTIDETALLE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCPROMOCIONAnterior.isnull["IID"])
                {
                    auxPar.Value = oCPROMOCIONAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  PROMOCION
  set


ACTIVO=@ACTIVO,


NOMBRE=@NOMBRE,

DESCRIPCION=@DESCRIPCION,

MEMO=@MEMO,

SUCURSALID=@SUCURSALID,

PROMOCION=@PROMOCION,

CANTIDAD=@CANTIDAD,

PRODUCTOID=@PRODUCTOID,

UTILIDAD=@UTILIDAD,

CANTIDADLLEVATE=@CANTIDADLLEVATE,

IMPORTE=@IMPORTE,

PORCENTAJEDESCUENTO=@PORCENTAJEDESCUENTO,

TIPOPROMOCIONID=@TIPOPROMOCIONID,

RANGOPROMOCIONID=@RANGOPROMOCIONID,

LINEAID=@LINEAID,

FECHAINICIO=@FECHAINICIO,

FECHAFIN=@FECHAFIN,

LUNES=@LUNES,

MARTES=@MARTES,

MIERCOLES=@MIERCOLES,

JUEVES=@JUEVES,

VIERNES=@VIERNES,

SABADO=@SABADO,

DOMINGO=@DOMINGO,

PORIMPORTE=@PORIMPORTE,

ENMONEDERO=@ENMONEDERO,

IMAGEN = @IMAGEN,

MOSTRARDATOSCLIENTE = @MOSTRARDATOSCLIENTE,

ESMULTIDETALLE = @ESMULTIDETALLE,

DESCMULTIDETALLE = @DESCMULTIDETALLE

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

        public bool CambiarActivo(long promoId, string activo, FbTransaction st)
        {
            try
            {
                int result = -1;
                ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!String.IsNullOrEmpty(activo))
                {
                    auxPar.Value = activo;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = promoId;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = "UPDATE PROMOCION SET ACTIVO = ? WHERE ID = ?";

                if (st == null)
                    result = SqlHelper.ExecuteNonQuery(sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    result = SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);

                return result > 0;
            }
            catch(Exception e)
            {
                iComentario = e.Message + " " + e.StackTrace;
                return false;
            }
        }

        public bool CambiarActivoPROMOCION(FbTransaction st)
        {

            try
            {

                string commandText = @"
  update  PROMOCION set ACTIVO= 'N';";

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText);


                return true;


            }
            catch (Exception e)
            {
                iComentario = e.Message + e.StackTrace;
                return false;
            }
        }

        public bool PROMOCIONEXISTEPARALINEA(CPROMOCIONBE oCPROMOCIONNuevo, ref string existe, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@PROMOCIONID", FbDbType.BigInt);
                if (!(bool)oCPROMOCIONNuevo.isnull["IID"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@LINEAID", FbDbType.BigInt);
                if (!(bool)oCPROMOCIONNuevo.isnull["ILINEAID"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.ILINEAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAINICIO", FbDbType.Date);
                if (!(bool)oCPROMOCIONNuevo.isnull["IFECHAINICIO"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.IFECHAINICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAFIN", FbDbType.Date);
                if (!(bool)oCPROMOCIONNuevo.isnull["IFECHAFIN"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.IFECHAFIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LUNES", FbDbType.Char);
                if (!(bool)oCPROMOCIONNuevo.isnull["ILUNES"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.ILUNES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MARTES", FbDbType.Char);
                if (!(bool)oCPROMOCIONNuevo.isnull["IMARTES"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.IMARTES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MIERCOLES", FbDbType.Char);
                if (!(bool)oCPROMOCIONNuevo.isnull["IMIERCOLES"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.IMIERCOLES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@JUEVES", FbDbType.Char);
                if (!(bool)oCPROMOCIONNuevo.isnull["IJUEVES"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.IJUEVES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@VIERNES", FbDbType.Char);
                if (!(bool)oCPROMOCIONNuevo.isnull["IVIERNES"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.IVIERNES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SABADO", FbDbType.Char);
                if (!(bool)oCPROMOCIONNuevo.isnull["ISABADO"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.ISABADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOMINGO", FbDbType.Char);
                if (!(bool)oCPROMOCIONNuevo.isnull["IDOMINGO"])
                {
                    auxPar.Value = oCPROMOCIONNuevo.IDOMINGO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@EXISTE", FbDbType.VarChar);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);



                string commandText = @"PROMOCIONEXISTEPARALINEA";

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


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    existe = (string)arParms[arParms.Length - 2].Value;
                }

                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        [AutoComplete]
        public CPROMOCIONBE seleccionarPROMOCION(CPROMOCIONBE oCPROMOCION, FbTransaction st)
        {




            CPROMOCIONBE retorno = new CPROMOCIONBE();
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from PROMOCION where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPROMOCION.IID;
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
                        retorno.IMEMO = (string)(dr["MEMO"]);
                    }

                    if (dr["SUCURSALID"] != System.DBNull.Value)
                    {
                        retorno.ISUCURSALID = (long)(dr["SUCURSALID"]);
                    }

                    if (dr["PROMOCION"] != System.DBNull.Value)
                    {
                        retorno.IPROMOCION = (string)(dr["PROMOCION"]);
                    }

                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDAD = (decimal)(dr["CANTIDAD"]);
                    }

                    if (dr["PRODUCTOID"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTOID = (long)(dr["PRODUCTOID"]);
                    }

                    if (dr["UTILIDAD"] != System.DBNull.Value)
                    {
                        retorno.IUTILIDAD = (decimal)(dr["UTILIDAD"]);
                    }

                    if (dr["CANTIDADLLEVATE"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDADLLEVATE = (decimal)(dr["CANTIDADLLEVATE"]);
                    }

                    if (dr["IMPORTE"] != System.DBNull.Value)
                    {
                        retorno.IIMPORTE = (decimal)(dr["IMPORTE"]);
                    }

                    if (dr["PORCENTAJEDESCUENTO"] != System.DBNull.Value)
                    {
                        retorno.IPORCENTAJEDESCUENTO = (decimal)(dr["PORCENTAJEDESCUENTO"]);
                    }

                    if (dr["TIPOPROMOCIONID"] != System.DBNull.Value)
                    {
                        retorno.ITIPOPROMOCIONID = (long)(dr["TIPOPROMOCIONID"]);
                    }

                    if (dr["RANGOPROMOCIONID"] != System.DBNull.Value)
                    {
                        retorno.IRANGOPROMOCIONID = (long)(dr["RANGOPROMOCIONID"]);
                    }

                    if (dr["LINEAID"] != System.DBNull.Value)
                    {
                        retorno.ILINEAID = (long)(dr["LINEAID"]);
                    }

                    if (dr["FECHAINICIO"] != System.DBNull.Value)
                    {
                        retorno.IFECHAINICIO = (DateTime)(dr["FECHAINICIO"]);
                    }

                    if (dr["FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.IFECHAFIN = (DateTime)(dr["FECHAFIN"]);
                    }

                    if (dr["LUNES"] != System.DBNull.Value)
                    {
                        retorno.ILUNES = (string)(dr["LUNES"]);
                    }

                    if (dr["MARTES"] != System.DBNull.Value)
                    {
                        retorno.IMARTES = (string)(dr["MARTES"]);
                    }

                    if (dr["MIERCOLES"] != System.DBNull.Value)
                    {
                        retorno.IMIERCOLES = (string)(dr["MIERCOLES"]);
                    }

                    if (dr["JUEVES"] != System.DBNull.Value)
                    {
                        retorno.IJUEVES = (string)(dr["JUEVES"]);
                    }

                    if (dr["VIERNES"] != System.DBNull.Value)
                    {
                        retorno.IVIERNES = (string)(dr["VIERNES"]);
                    }

                    if (dr["SABADO"] != System.DBNull.Value)
                    {
                        retorno.ISABADO = (string)(dr["SABADO"]);
                    }

                    if (dr["DOMINGO"] != System.DBNull.Value)
                    {
                        retorno.IDOMINGO = (string)(dr["DOMINGO"]);
                    }

                    if (dr["PORIMPORTE"] != System.DBNull.Value)
                    {
                        retorno.IPORIMPORTE = (decimal)(dr["PORIMPORTE"]);
                    }

                    if (dr["ENMONEDERO"] != System.DBNull.Value)
                    {
                        retorno.IENMONEDERO = (string)(dr["ENMONEDERO"]);
                    }

                    if (dr["IMAGEN"] != System.DBNull.Value)
                    {
                        retorno.IIMAGEN = (string)(dr["IMAGEN"]);
                    }

                    if (dr["MOSTRARDATOSCLIENTE"] != System.DBNull.Value)
                    {
                        retorno.IMOSTRARDATOSCLIENTE = (string)(dr["MOSTRARDATOSCLIENTE"]);
                    }

                    if (dr["ESMULTIDETALLE"] != System.DBNull.Value)
                    {
                        retorno.IESMULTIDETALLE = (string)(dr["ESMULTIDETALLE"]);
                    }

                    if (dr["DESCMULTIDETALLE"] != System.DBNull.Value)
                    {
                        retorno.IDESCMULTIDETALLE = (string)(dr["DESCMULTIDETALLE"]);
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



        public List<CPROMOCIONSUCURSALBE> seleccionarSUCURSALESxPROMOCION(CPROMOCIONBE oCPROMOCION, FbTransaction st)
        {
            List<CPROMOCIONSUCURSALBE> promocionSucursales = new List<CPROMOCIONSUCURSALBE>();

            FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@PROMOCIONID", FbDbType.BigInt);
                auxPar.Value = oCPROMOCION.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"SELECT * FROM  PROMOCIONSUCURSAL where PROMOCIONID = @PROMOCIONID;";

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, commandText, arParms);


                while (dr.Read())
                {
                    CPROMOCIONSUCURSALBE promSuc = new CPROMOCIONSUCURSALBE();

                    if (dr["PROMOCIONID"] != System.DBNull.Value)
                    {
                        promSuc.IPROMOCIONID = (long)dr["PROMOCIONID"];
                    }

                    if (dr["SUCURSALID"] != System.DBNull.Value)
                    {
                        promSuc.ISUCURSALID = (long)dr["SUCURSALID"];
                    }

                    promocionSucursales.Add(promSuc);
                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                return promocionSucursales;

            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                this.iComentario = ex.Message + ex.StackTrace;

                return null;
            }

        }


        public CPROMOCIONBE seleccionarPROMOCIONxCLAVE(CPROMOCIONBE oCPROMOCION, FbTransaction st)
        {




            CPROMOCIONBE retorno = new CPROMOCIONBE();
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from PROMOCION where CLAVE=@CLAVE  ";


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                auxPar.Value = oCPROMOCION.ICLAVE;
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
                        retorno.IMEMO = (string)(dr["MEMO"]);
                    }

                    if (dr["SUCURSALID"] != System.DBNull.Value)
                    {
                        retorno.ISUCURSALID = (long)(dr["SUCURSALID"]);
                    }

                    if (dr["PROMOCION"] != System.DBNull.Value)
                    {
                        retorno.IPROMOCION = (string)(dr["PROMOCION"]);
                    }

                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDAD = (decimal)(dr["CANTIDAD"]);
                    }

                    if (dr["PRODUCTOID"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTOID = (long)(dr["PRODUCTOID"]);
                    }

                    if (dr["UTILIDAD"] != System.DBNull.Value)
                    {
                        retorno.IUTILIDAD = (decimal)(dr["UTILIDAD"]);
                    }

                    if (dr["CANTIDADLLEVATE"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDADLLEVATE = (decimal)(dr["CANTIDADLLEVATE"]);
                    }

                    if (dr["IMPORTE"] != System.DBNull.Value)
                    {
                        retorno.IIMPORTE = (decimal)(dr["IMPORTE"]);
                    }

                    if (dr["PORCENTAJEDESCUENTO"] != System.DBNull.Value)
                    {
                        retorno.IPORCENTAJEDESCUENTO = (decimal)(dr["PORCENTAJEDESCUENTO"]);
                    }

                    if (dr["TIPOPROMOCIONID"] != System.DBNull.Value)
                    {
                        retorno.ITIPOPROMOCIONID = (long)(dr["TIPOPROMOCIONID"]);
                    }

                    if (dr["RANGOPROMOCIONID"] != System.DBNull.Value)
                    {
                        retorno.IRANGOPROMOCIONID = (long)(dr["RANGOPROMOCIONID"]);
                    }

                    if (dr["LINEAID"] != System.DBNull.Value)
                    {
                        retorno.ILINEAID = (long)(dr["LINEAID"]);
                    }

                    if (dr["FECHAINICIO"] != System.DBNull.Value)
                    {
                        retorno.IFECHAINICIO = (DateTime)(dr["FECHAINICIO"]);
                    }

                    if (dr["FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.IFECHAFIN = (DateTime)(dr["FECHAFIN"]);
                    }

                    if (dr["LUNES"] != System.DBNull.Value)
                    {
                        retorno.ILUNES = (string)(dr["LUNES"]);
                    }

                    if (dr["MARTES"] != System.DBNull.Value)
                    {
                        retorno.IMARTES = (string)(dr["MARTES"]);
                    }

                    if (dr["MIERCOLES"] != System.DBNull.Value)
                    {
                        retorno.IMIERCOLES = (string)(dr["MIERCOLES"]);
                    }

                    if (dr["JUEVES"] != System.DBNull.Value)
                    {
                        retorno.IJUEVES = (string)(dr["JUEVES"]);
                    }

                    if (dr["VIERNES"] != System.DBNull.Value)
                    {
                        retorno.IVIERNES = (string)(dr["VIERNES"]);
                    }

                    if (dr["SABADO"] != System.DBNull.Value)
                    {
                        retorno.ISABADO = (string)(dr["SABADO"]);
                    }

                    if (dr["DOMINGO"] != System.DBNull.Value)
                    {
                        retorno.IDOMINGO = (string)(dr["DOMINGO"]);
                    }

                    if (dr["PORIMPORTE"] != System.DBNull.Value)
                    {
                        retorno.IPORIMPORTE = (decimal)(dr["PORIMPORTE"]);
                    }

                    if (dr["ENMONEDERO"] != System.DBNull.Value)
                    {
                        retorno.IENMONEDERO = (string)(dr["ENMONEDERO"]);
                    }

                    if (dr["IMAGEN"] != System.DBNull.Value)
                    {
                        retorno.IIMAGEN = (string)(dr["IMAGEN"]);
                    }

                    if (dr["MOSTRARDATOSCLIENTE"] != System.DBNull.Value)
                    {
                        retorno.IMOSTRARDATOSCLIENTE = (string)(dr["MOSTRARDATOSCLIENTE"]);
                    }

                    if (dr["ESMULTIDETALLE"] != System.DBNull.Value)
                    {
                        retorno.IESMULTIDETALLE = (string)(dr["ESMULTIDETALLE"]);
                    }

                    if (dr["DESCMULTIDETALLE"] != System.DBNull.Value)
                    {
                        retorno.IDESCMULTIDETALLE = (string)(dr["DESCMULTIDETALLE"]);
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
        public DataSet enlistarPROMOCION()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PROMOCION_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoPROMOCION()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PROMOCION_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExistePROMOCION(CPROMOCIONBE oCPROMOCION, FbTransaction st)
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
                auxPar.Value = oCPROMOCION.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from PROMOCION where

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




        public CPROMOCIONBE AgregarPROMOCION(CPROMOCIONBE oCPROMOCION, FbTransaction st)
        {
            try
            {
                int iRes = ExistePROMOCION(oCPROMOCION, st);
                if (iRes == 1)
                {
                    this.IComentario = "El PROMOCION ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarPROMOCIOND(oCPROMOCION, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarPROMOCION(CPROMOCIONBE oCPROMOCION, FbTransaction st)
        {
            try
            {
                int iRes = ExistePROMOCION(oCPROMOCION, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PROMOCION no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarPROMOCIOND(oCPROMOCION, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }




        public bool CambiarPROMOCION(CPROMOCIONBE oCPROMOCIONNuevo, CPROMOCIONBE oCPROMOCIONAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExistePROMOCION(oCPROMOCIONAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PROMOCION no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarPROMOCIOND(oCPROMOCIONNuevo, oCPROMOCIONAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }

        public bool APLICAPROMOCIONESCUPONES(long doctoId, ref string hayCuponesAplicados, FbTransaction st)
        {
            try
            {
                ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if(doctoId != null)
                {
                    auxPar.Value = doctoId;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@HAYCUPONESAPLICADOS", FbDbType.VarChar);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"aplica_promociones_cupones";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);


                if (arParms[arParms.Length - 2].Value != DBNull.Value)
                {
                    hayCuponesAplicados = arParms[arParms.Length - 2].Value.ToString();
                }

                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        this.iComentario = "Hubo un error";
                        return false;
                    }
                }

                return true;


            }
            catch(Exception ex)
            {
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
        }


        public bool IMPORTARPROMOCIOND(CPROMOCIONBE promocionBE, string sucursalClave,
                                       string productoClave, string tipoPromocionClave,
                                       string rangoPromocionClave, string lineaClave, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (promocionBE.ICLAVE != null)
                {
                    auxPar.Value = promocionBE.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (promocionBE.INOMBRE != null)
                {
                    auxPar.Value = promocionBE.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                if (promocionBE.IDESCRIPCION != null)
                {
                    auxPar.Value = promocionBE.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUCURSALCLAVE", FbDbType.VarChar);
                if (sucursalClave != null)
                {
                    auxPar.Value = sucursalClave;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CANTIDAD", FbDbType.Numeric);
                if (promocionBE.ICANTIDAD != null)
                {
                    auxPar.Value = promocionBE.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PRODUCTOCLAVE", FbDbType.VarChar);
                if (productoClave != null)
                {
                    auxPar.Value = productoClave;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@UTILIDAD", FbDbType.Numeric);
                if (promocionBE.IUTILIDAD != null)
                {
                    auxPar.Value = promocionBE.IUTILIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CANTIDADLLEVATE", FbDbType.Numeric);
                if (promocionBE.ICANTIDADLLEVATE != null)
                {
                    auxPar.Value = promocionBE.ICANTIDADLLEVATE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IMPORTE", FbDbType.Numeric);
                if (promocionBE.IIMPORTE != null)
                {
                    auxPar.Value = promocionBE.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PORCENTAJEDESCUENTO", FbDbType.Numeric);
                if (promocionBE.IPORCENTAJEDESCUENTO != null)
                {
                    auxPar.Value = promocionBE.IPORCENTAJEDESCUENTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOPROMOCIONCLAVE", FbDbType.VarChar);
                if (tipoPromocionClave != null)
                {
                    auxPar.Value = tipoPromocionClave;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@RANGOPROMOCIONCLAVE", FbDbType.VarChar);
                if (rangoPromocionClave != null)
                {
                    auxPar.Value = rangoPromocionClave;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LINEACLAVE", FbDbType.VarChar);
                if (lineaClave != null)
                {
                    auxPar.Value = lineaClave;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@FECHAINICIO", FbDbType.Date);
                if (promocionBE.IFECHAINICIO != null)
                {
                    auxPar.Value = promocionBE.IFECHAINICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAFIN", FbDbType.Date);
                if (promocionBE.IFECHAFIN != null)
                {
                    auxPar.Value = promocionBE.IFECHAFIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LUNES", FbDbType.VarChar);
                if (promocionBE.ILUNES != null)
                {
                    auxPar.Value = promocionBE.ILUNES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MARTES", FbDbType.VarChar);
                if (promocionBE.IMARTES != null)
                {
                    auxPar.Value = promocionBE.IMARTES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MIERCOLES", FbDbType.VarChar);
                if (promocionBE.IMIERCOLES != null)
                {
                    auxPar.Value = promocionBE.IMIERCOLES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@JUEVES", FbDbType.VarChar);
                if (promocionBE.IJUEVES != null)
                {
                    auxPar.Value = promocionBE.IJUEVES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@VIERNES", FbDbType.VarChar);
                if (promocionBE.IVIERNES != null)
                {
                    auxPar.Value = promocionBE.IVIERNES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SABADO", FbDbType.VarChar);
                if (promocionBE.ISABADO != null)
                {
                    auxPar.Value = promocionBE.ISABADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOMINGO", FbDbType.VarChar);
                if (promocionBE.IDOMINGO != null)
                {
                    auxPar.Value = promocionBE.IDOMINGO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PORIMPORTE", FbDbType.Numeric);
                if (promocionBE.IPORIMPORTE != null)
                {
                    auxPar.Value = promocionBE.IPORIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ENMONEDERO", FbDbType.VarChar);
                if (promocionBE.IENMONEDERO != null)
                {
                    auxPar.Value = promocionBE.IENMONEDERO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@ACTIVO", FbDbType.VarChar);
                if (promocionBE.IACTIVO != null)
                {
                    auxPar.Value = promocionBE.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);





                auxPar = new FbParameter("@ESMULTIDETALLE", FbDbType.VarChar);
                if (promocionBE.IESMULTIDETALLE != null)
                {
                    auxPar.Value = promocionBE.IESMULTIDETALLE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                


                auxPar = new FbParameter("@DESCMULTIDETALLE", FbDbType.VarChar);
                if (promocionBE.IDESCMULTIDETALLE != null)
                {
                    auxPar.Value = promocionBE.IDESCMULTIDETALLE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"promocion_importar";

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
                        this.iComentario = "Hubo un error";
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




        public CPROMOCIOND()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
