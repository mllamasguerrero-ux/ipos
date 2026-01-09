

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
    public class CPARAMETROD
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

        public CPARAMETROBE AgregarPARAMETROD(CPARAMETROBE oCPARAMETRO, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@SUCURSALID", FbDbType.Integer);
                if (!(bool)oCPARAMETRO.isnull["ISUCURSALID"])
                {
                    auxPar.Value = oCPARAMETRO.ISUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUCURSALNUMERO", FbDbType.VarChar);
                if (!(bool)oCPARAMETRO.isnull["ISUCURSALNUMERO"])
                {
                    auxPar.Value = oCPARAMETRO.ISUCURSALNUMERO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CORTEACTUALID", FbDbType.Integer);
                if (!(bool)oCPARAMETRO.isnull["ICORTEACTUALID"])
                {
                    auxPar.Value = oCPARAMETRO.ICORTEACTUALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAJEROACTUALID", FbDbType.Integer);
                if (!(bool)oCPARAMETRO.isnull["ICAJEROACTUALID"])
                {
                    auxPar.Value = oCPARAMETRO.ICAJEROACTUALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBRE", FbDbType.Char);
                if (!(bool)oCPARAMETRO.isnull["INOMBRE"])
                {
                    auxPar.Value = oCPARAMETRO.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CALLE", FbDbType.Char);
                if (!(bool)oCPARAMETRO.isnull["ICALLE"])
                {
                    auxPar.Value = oCPARAMETRO.ICALLE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COLONIA", FbDbType.Char);
                if (!(bool)oCPARAMETRO.isnull["ICOLONIA"])
                {
                    auxPar.Value = oCPARAMETRO.ICOLONIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LOCALIDAD", FbDbType.Char);
                if (!(bool)oCPARAMETRO.isnull["ILOCALIDAD"])
                {
                    auxPar.Value = oCPARAMETRO.ILOCALIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTADO", FbDbType.Char);
                if (!(bool)oCPARAMETRO.isnull["IESTADO"])
                {
                    auxPar.Value = oCPARAMETRO.IESTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CP", FbDbType.Char);
                if (!(bool)oCPARAMETRO.isnull["ICP"])
                {
                    auxPar.Value = oCPARAMETRO.ICP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TELEFONO", FbDbType.Char);
                if (!(bool)oCPARAMETRO.isnull["ITELEFONO"])
                {
                    auxPar.Value = oCPARAMETRO.ITELEFONO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FAX", FbDbType.Char);
                if (!(bool)oCPARAMETRO.isnull["IFAX"])
                {
                    auxPar.Value = oCPARAMETRO.IFAX;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CORREOE", FbDbType.Char);
                if (!(bool)oCPARAMETRO.isnull["ICORREOE"])
                {
                    auxPar.Value = oCPARAMETRO.ICORREOE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PAGINAWEB", FbDbType.Char);
                if (!(bool)oCPARAMETRO.isnull["IPAGINAWEB"])
                {
                    auxPar.Value = oCPARAMETRO.IPAGINAWEB;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RFC", FbDbType.Char);
                if (!(bool)oCPARAMETRO.isnull["IRFC"])
                {
                    auxPar.Value = oCPARAMETRO.IRFC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LISTA_PRECIO_DEF", FbDbType.Char);
                if (!(bool)oCPARAMETRO.isnull["ILISTA_PRECIO_DEF"])
                {
                    auxPar.Value = oCPARAMETRO.ILISTA_PRECIO_DEF;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMP_PROD_DEF", FbDbType.Decimal);
                if (!(bool)oCPARAMETRO.isnull["IIMP_PROD_DEF"])
                {
                    auxPar.Value = oCPARAMETRO.IIMP_PROD_DEF;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTADO_DEF", FbDbType.Char);
                if (!(bool)oCPARAMETRO.isnull["IESTADO_DEF"])
                {
                    auxPar.Value = oCPARAMETRO.IESTADO_DEF;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CXCVALIDARTRASLADOS", FbDbType.VarChar);
                if (!(bool)oCPARAMETRO.isnull["ICXCVALIDARTRASLADOS"])
                {
                    auxPar.Value = oCPARAMETRO.IESTADO_DEF;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CADUCIDADMINIMA", FbDbType.BigInt);
                if (!(bool)oCPARAMETRO.isnull["ICADUCIDADMINIMA"])
                {
                    auxPar.Value = oCPARAMETRO.ICADUCIDADMINIMA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@UNICAVISITAPORDOCTO", FbDbType.VarChar);
                if (!(bool)oCPARAMETRO.isnull["IUNICAVISITAPORDOCTO"])
                {
                    auxPar.Value = oCPARAMETRO.IUNICAVISITAPORDOCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PLAZOXPRODUCTO", FbDbType.VarChar);
                if (!(bool)oCPARAMETRO.isnull["IPLAZOXPRODUCTO"])
                {
                    auxPar.Value = oCPARAMETRO.IPLAZOXPRODUCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@AUTOCOMPLETECONEXISENVENTA", FbDbType.VarChar);
                if (!(bool)oCPARAMETRO.isnull["IAUTOCOMPLETECONEXISENVENTA"])
                {
                    auxPar.Value = oCPARAMETRO.IAUTOCOMPLETECONEXISENVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@APLICARCAMBIOSPRECAUTO", FbDbType.VarChar);
                if (!(bool)oCPARAMETRO.isnull["IAPLICARCAMBIOSPRECAUTO"])
                {
                    auxPar.Value = oCPARAMETRO.IAPLICARCAMBIOSPRECAUTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO PARAMETRO
      (
    
SUCURSALID,

SUCURSALNUMERO,

CORTEACTUALID,

CAJEROACTUALID,

NOMBRE,

CALLE,

COLONIA,

LOCALIDAD,

ESTADO,

CP,

TELEFONO,

FAX,

CORREOE,

PAGINAWEB,

RFC,

LISTA_PRECIO_DEF,

IMP_PROD_DEF,

ESTADO_DEF,

PRECIOREALTRASLADOS,

FORMATOFACTELECT,

CXCVALIDARTRASLADOS,

CADUCIDADMINIMA,

UNICAVISITAPORDOCTO, 

PLAZOXPRODUCTO,

AUTOCOMPLETECONEXISENVENTA,

APLICARCAMBIOSPRECAUTO

         )

Values (

@SUCURSALID,

@SUCURSALNUMERO,

@CORTEACTUALID,

@CAJEROACTUALID,

@NOMBRE,

@CALLE,

@COLONIA,

@LOCALIDAD,

@ESTADO,

@CP,

@TELEFONO,

@FAX,

@CORREOE,

@PAGINAWEB,

@RFC,

@LISTA_PRECIO_DEF,

@IMP_PROD_DEF,

@ESTADO_DEF,

@PRECIOREALTRASLADOS,

@FORMATOFACTELECT,

@CXCVALIDARTRASLADOS,

@CADUCIDADMINIMA,

@UNICAVISITAPORDOCTO,

@PLAZOXPRODUCTO,

@AUTOCOMPLETECONEXISENVENTA,

@APLICARCAMBIOSPRECAUTO

); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCPARAMETRO;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarPARAMETROD(CPARAMETROBE oCPARAMETRO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@SUCURSALID", FbDbType.Integer);
                auxPar.Value = oCPARAMETRO.ISUCURSALID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUCURSALNUMERO", FbDbType.VarChar);
                auxPar.Value = oCPARAMETRO.ISUCURSALNUMERO;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CORTEACTUALID", FbDbType.Integer);
                auxPar.Value = oCPARAMETRO.ICORTEACTUALID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAJEROACTUALID", FbDbType.Integer);
                auxPar.Value = oCPARAMETRO.ICAJEROACTUALID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBRE", FbDbType.Char);
                auxPar.Value = oCPARAMETRO.INOMBRE;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CALLE", FbDbType.Char);
                auxPar.Value = oCPARAMETRO.ICALLE;
                parts.Add(auxPar);


                auxPar = new FbParameter("@COLONIA", FbDbType.Char);
                auxPar.Value = oCPARAMETRO.ICOLONIA;
                parts.Add(auxPar);


                auxPar = new FbParameter("@LOCALIDAD", FbDbType.Char);
                auxPar.Value = oCPARAMETRO.ILOCALIDAD;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTADO", FbDbType.Char);
                auxPar.Value = oCPARAMETRO.IESTADO;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CP", FbDbType.Char);
                auxPar.Value = oCPARAMETRO.ICP;
                parts.Add(auxPar);


                auxPar = new FbParameter("@TELEFONO", FbDbType.Char);
                auxPar.Value = oCPARAMETRO.ITELEFONO;
                parts.Add(auxPar);


                auxPar = new FbParameter("@FAX", FbDbType.Char);
                auxPar.Value = oCPARAMETRO.IFAX;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CORREOE", FbDbType.Char);
                auxPar.Value = oCPARAMETRO.ICORREOE;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PAGINAWEB", FbDbType.Char);
                auxPar.Value = oCPARAMETRO.IPAGINAWEB;
                parts.Add(auxPar);


                auxPar = new FbParameter("@RFC", FbDbType.Char);
                auxPar.Value = oCPARAMETRO.IRFC;
                parts.Add(auxPar);


                auxPar = new FbParameter("@LISTA_PRECIO_DEF", FbDbType.Char);
                auxPar.Value = oCPARAMETRO.ILISTA_PRECIO_DEF;
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMP_PROD_DEF", FbDbType.Decimal);
                auxPar.Value = oCPARAMETRO.IIMP_PROD_DEF;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTADO_DEF", FbDbType.Char);
                auxPar.Value = oCPARAMETRO.IESTADO_DEF;
                parts.Add(auxPar);



                string commandText = @"  Delete from PARAMETRO
  where

  SUCURSALID=@SUCURSALID and 

  SUCURSALNUMERO=@SUCURSALNUMERO and 

  CORTEACTUALID=@CORTEACTUALID and 

  CAJEROACTUALID=@CAJEROACTUALID and 

  NOMBRE=@NOMBRE and 

  CALLE=@CALLE and 

  COLONIA=@COLONIA and 

  LOCALIDAD=@LOCALIDAD and 

  ESTADO=@ESTADO and 

  CP=@CP and 

  TELEFONO=@TELEFONO and 

  FAX=@FAX and 

  CORREOE=@CORREOE and 

  PAGINAWEB=@PAGINAWEB and 

  RFC=@RFC and 

  LISTA_PRECIO_DEF=@LISTA_PRECIO_DEF and 

  IMP_PROD_DEF=@IMP_PROD_DEF and 

  ESTADO_DEF=@ESTADO_DEF
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
        public bool CambiarPARAMETROD(CPARAMETROBE oCPARAMETRONuevo, CPARAMETROBE oCPARAMETROAnterior, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@SUCURSALID", FbDbType.Integer);
                if (!(bool)oCPARAMETRONuevo.isnull["ISUCURSALID"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ISUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SUCURSALNUMERO", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["ISUCURSALNUMERO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ISUCURSALNUMERO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CORTEACTUALID", FbDbType.Integer);
                if (!(bool)oCPARAMETRONuevo.isnull["ICORTEACTUALID"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ICORTEACTUALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAJEROACTUALID", FbDbType.Integer);
                if (!(bool)oCPARAMETRONuevo.isnull["ICAJEROACTUALID"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ICAJEROACTUALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMBRE", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["INOMBRE"])
                {
                    auxPar.Value = oCPARAMETRONuevo.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CALLE", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["ICALLE"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ICALLE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@COLONIA", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["ICOLONIA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ICOLONIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LOCALIDAD", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["ILOCALIDAD"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ILOCALIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESTADO", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IESTADO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IESTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CP", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["ICP"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ICP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TELEFONO", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["ITELEFONO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ITELEFONO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FAX", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IFAX"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IFAX;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CORREOE", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["ICORREOE"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ICORREOE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PAGINAWEB", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IPAGINAWEB"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IPAGINAWEB;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@RFC", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IRFC"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IRFC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LISTA_PRECIO_DEF", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["ILISTA_PRECIO_DEF"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ILISTA_PRECIO_DEF;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IMP_PROD_DEF", FbDbType.Decimal);
                if (!(bool)oCPARAMETRONuevo.isnull["IIMP_PROD_DEF"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IIMP_PROD_DEF;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESTADO_DEF", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IESTADO_DEF"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IESTADO_DEF;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAULTIMA", FbDbType.Date);
                if (!(bool)oCPARAMETRONuevo.isnull["IFECHAULTIMA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IFECHAULTIMA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHARESPALDO", FbDbType.Date);
                if (!(bool)oCPARAMETRONuevo.isnull["IFECHARESPALDO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IFECHARESPALDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ID_DOSLETRAS", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IID_DOSLETRAS"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IID_DOSLETRAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@HABILITAR_IMPEXP_AUT", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IHABILITAR_IMPEXP_AUT"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IHABILITAR_IMPEXP_AUT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@FTPHOST", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IFTPHOST"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IFTPHOST;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FTPUSUARIO", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IFTPUSUARIO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IFTPUSUARIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FTPPASSWORD", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IFTPPASSWORD"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IFTPPASSWORD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SMTPHOST", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["ISMTPHOST"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ISMTPHOST;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SMTPUSUARIO", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["ISMTPUSUARIO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ISMTPUSUARIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SMTPPASSWORD", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["ISMTPPASSWORD"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ISMTPPASSWORD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@SMTPPORT", FbDbType.Integer);
                if (!(bool)oCPARAMETRONuevo.isnull["ISMTPPORT"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ISMTPPORT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SMTPMAILFROM", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["ISMTPMAILFROM"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ISMTPMAILFROM;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SMTPMAILTO", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["ISMTPMAILTO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ISMTPMAILTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMBIARPRECIO", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["ICAMBIARPRECIO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ICAMBIARPRECIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@HEADER", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IHEADER"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IHEADER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FOOTER", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IFOOTER"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IFOOTER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@HAB_SEL_CLIENTE", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IHAB_SEL_CLIENTE"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IHAB_SEL_CLIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@HAB_IMPR_COTIZACION", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IHAB_IMPR_COTIZACION"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IHAB_IMPR_COTIZACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COMISIONMEDICO", FbDbType.Decimal);
                if (!(bool)oCPARAMETRONuevo.isnull["ICOMISIONMEDICO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ICOMISIONMEDICO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COMISIONDEPENDIENTE", FbDbType.Decimal);
                if (!(bool)oCPARAMETRONuevo.isnull["ICOMISIONDEPENDIENTE"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ICOMISIONDEPENDIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@MOSTRAR_EXIS_SUC", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IMOSTRAR_EXIS_SUC"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IMOSTRAR_EXIS_SUC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@REQ_APROBACION_INV", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IREQ_APROBACION_INV"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IREQ_APROBACION_INV;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REABRIRCORTES", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IREABRIRCORTES"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IREABRIRCORTES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@DESCUENTOVALE", FbDbType.Numeric);
                if (!(bool)oCPARAMETRONuevo.isnull["IDESCUENTOVALE"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IDESCUENTOVALE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@IMP_PROD_TOTAL", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IIMP_PROD_TOTAL"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IIMP_PROD_TOTAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUMEROEXTERIOR", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["INUMEROEXTERIOR"])
                {
                    auxPar.Value = oCPARAMETRONuevo.INUMEROEXTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUMEROINTERIOR", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["INUMEROINTERIOR"])
                {
                    auxPar.Value = oCPARAMETRONuevo.INUMEROINTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FISCALCALLE", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IFISCALCALLE"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IFISCALCALLE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@FISCALNUMEROINTERIOR", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IFISCALNUMEROINTERIOR"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IFISCALNUMEROINTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@FISCALNUMEROEXTERIOR", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IFISCALNUMEROEXTERIOR"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IFISCALNUMEROEXTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@FISCALCOLONIA", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IFISCALCOLONIA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IFISCALCOLONIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@FISCALMUNICIPIO", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IFISCALMUNICIPIO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IFISCALMUNICIPIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@FISCALESTADO", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IFISCALESTADO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IFISCALESTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@FISCALCODIGOPOSTAL", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IFISCALCODIGOPOSTAL"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IFISCALCODIGOPOSTAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CERTIFICADOCSD", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["ICERTIFICADOCSD"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ICERTIFICADOCSD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@TIMBRADOUSER", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["ITIMBRADOUSER"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ITIMBRADOUSER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@TIMBRADOPASSWORD", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["ITIMBRADOPASSWORD"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ITIMBRADOPASSWORD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@TIMBRADOARCHIVOCERTIFICADO", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["ITIMBRADOARCHIVOCERTIFICADO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ITIMBRADOARCHIVOCERTIFICADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@TIMBRADOARCHIVOKEY", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["ITIMBRADOARCHIVOKEY"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ITIMBRADOARCHIVOKEY;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIMBRADOKEY", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["ITIMBRADOKEY"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ITIMBRADOKEY;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FISCALNOMBRE", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IFISCALNOMBRE"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IFISCALNOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SERIESAT", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["ISERIESAT"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ISERIESAT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@USARFISCALESENEXPEDICION", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IUSARFISCALESENEXPEDICION"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IUSARFISCALESENEXPEDICION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@HAB_FACTURAELECTRONICA", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IHAB_FACTURAELECTRONICA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IHAB_FACTURAELECTRONICA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FOOTERVENTAAPARTADO", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IFOOTERVENTAAPARTADO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IFOOTERVENTAAPARTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@ENCARGADOID", FbDbType.BigInt);
                if (!(bool)oCPARAMETRONuevo.isnull["IENCARGADOID"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IENCARGADOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PORC_COMISIONENCARGADO", FbDbType.Decimal);
                if (!(bool)oCPARAMETRONuevo.isnull["IPORC_COMISIONENCARGADO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IPORC_COMISIONENCARGADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PORC_COMISIONVENDEDOR", FbDbType.Decimal);
                if (!(bool)oCPARAMETRONuevo.isnull["IPORC_COMISIONVENDEDOR"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IPORC_COMISIONVENDEDOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FTPFOLDER", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IFTPFOLDER"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IFTPFOLDER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FTPFOLDERPASS", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IFTPFOLDERPASS"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IFTPFOLDERPASS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@SERIESATDEVOLUCION", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["ISERIESATDEVOLUCION"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ISERIESATDEVOLUCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMBIARPRECIOXUEMPAQUE", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["ICAMBIARPRECIOXUEMPAQUE"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ICAMBIARPRECIOXUEMPAQUE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMBIARPRECIOXPZACAJA", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["ICAMBIARPRECIOXPZACAJA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ICAMBIARPRECIOXPZACAJA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PREFIJOBASCULA", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IPREFIJOBASCULA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IPREFIJOBASCULA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LONGPRODBASCULA", FbDbType.SmallInt);
                if (!(bool)oCPARAMETRONuevo.isnull["ILONGPRODBASCULA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ILONGPRODBASCULA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@LONGPESOBASCULA", FbDbType.SmallInt);
                if (!(bool)oCPARAMETRONuevo.isnull["ILONGPESOBASCULA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ILONGPESOBASCULA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@LISTAPRECIOXUEMPAQUE", FbDbType.BigInt);
                if (!(bool)oCPARAMETRONuevo.isnull["ILISTAPRECIOXUEMPAQUE"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ILISTAPRECIOXUEMPAQUE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LISTAPRECIOXPZACAJA", FbDbType.BigInt);
                if (!(bool)oCPARAMETRONuevo.isnull["ILISTAPRECIOXPZACAJA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ILISTAPRECIOXPZACAJA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LISTAPRECIOINIMAYO", FbDbType.BigInt);
                if (!(bool)oCPARAMETRONuevo.isnull["ILISTAPRECIOINIMAYO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ILISTAPRECIOINIMAYO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@HAYVENDEDORPISO", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IHAYVENDEDORPISO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IHAYVENDEDORPISO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ENVIOAUTOMATICOEXISTENCIAS", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IENVIOAUTOMATICOEXISTENCIAS"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IENVIOAUTOMATICOEXISTENCIAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONEDEROMONTOMINIMO", FbDbType.Numeric);
                if (!(bool)oCPARAMETRONuevo.isnull["IMONEDEROMONTOMINIMO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IMONEDEROMONTOMINIMO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONEDEROAPLICAR", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IMONEDEROAPLICAR"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IMONEDEROAPLICAR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONEDEROCADUCIDAD", FbDbType.Integer);
                if (!(bool)oCPARAMETRONuevo.isnull["IMONEDEROCADUCIDAD"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IMONEDEROCADUCIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPRIMIRNUMEROPIEZAS", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IIMPRIMIRNUMEROPIEZAS"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IIMPRIMIRNUMEROPIEZAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PACNOMBRE", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IPACNOMBRE"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IPACNOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PACUSUARIO", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IPACUSUARIO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IPACUSUARIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CORTEPORMAIL", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["ICORTEPORMAIL"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ICORTEPORMAIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                //auxPar = new FbParameter("@PRECIOREALTRASLADOS", FbDbType.VarChar);
                //if (!(bool)oCPARAMETRONuevo.isnull["IPRECIOREALTRASLADOS"])
                //{
                //    auxPar.Value = oCPARAMETRONuevo.IPRECIOREALTRASLADOS;
                //}
                //else
                //{
                //    auxPar.Value = System.DBNull.Value;
                //}
                //parts.Add(auxPar);


                auxPar = new FbParameter("@RUTAREPORTES", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IRUTAREPORTES"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IRUTAREPORTES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RUTAREPORTESSISTEMA", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IRUTAREPORTESSISTEMA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IRUTAREPORTESSISTEMA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOBLECOPIACREDITO", FbDbType.Integer);
                if (!(bool)oCPARAMETRONuevo.isnull["IDOBLECOPIACREDITO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IDOBLECOPIACREDITO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@DOBLECOPIATRASLADO", FbDbType.Integer);
                if (!(bool)oCPARAMETRONuevo.isnull["IDOBLECOPIATRASLADO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IDOBLECOPIATRASLADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPOSCUSTOMALIMPORTAR", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["ICAMPOSCUSTOMALIMPORTAR"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ICAMPOSCUSTOMALIMPORTAR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@RECIBOLARGOPRINTER", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IRECIBOLARGOPRINTER"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IRECIBOLARGOPRINTER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RECIBOLARGOPREVIEW", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IRECIBOLARGOPREVIEW"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IRECIBOLARGOPREVIEW;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PREGUNTARRAZONPRECIOMENOR", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IPREGUNTARRAZONPRECIOMENOR"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IPREGUNTARRAZONPRECIOMENOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PREGUNTARDATOSENTREGA", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IPREGUNTARDATOSENTREGA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IPREGUNTARDATOSENTREGA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@FISCALREGIMEN", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IFISCALREGIMEN"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IFISCALREGIMEN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CORTACADUCIDAD", FbDbType.Integer);
                if (!(bool)oCPARAMETRONuevo.isnull["ICORTACADUCIDAD"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ICORTACADUCIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("RETENCIONIVA", FbDbType.Decimal);
                if (!(bool)oCPARAMETRONuevo.isnull["IRETENCIONIVA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IRETENCIONIVA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("RETENCIONISR", FbDbType.Decimal);
                if (!(bool)oCPARAMETRONuevo.isnull["IRETENCIONISR"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IRETENCIONISR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ARRENDATARIO", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IARRENDATARIO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IARRENDATARIO;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@RUTAIMAGENESPRODUCTO", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IRUTAIMAGENESPRODUCTO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IRUTAIMAGENESPRODUCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MOSTRARIMAGENENVENTA", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IMOSTRARIMAGENENVENTA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IMOSTRARIMAGENENVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@MOSTRARMONTOAHORRO", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IMOSTRARMONTOAHORRO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IMOSTRARMONTOAHORRO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SMTPSSL", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["ISMTPSSL"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ISMTPSSL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@MOSTRARDESCUENTOFACTURA", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IMOSTRARDESCUENTOFACTURA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IMOSTRARDESCUENTOFACTURA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@EXPORTCATALOGOAUX", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IEXPORTCATALOGOAUX"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IEXPORTCATALOGOAUX;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@UIVENTACONCANTIDAD", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IUIVENTACONCANTIDAD"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IUIVENTACONCANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FACT_ELECT_FOLDER", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IFACT_ELECT_FOLDER"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IFACT_ELECT_FOLDER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PEDIDOS_FOLDER", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IPEDIDOS_FOLDER"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IPEDIDOS_FOLDER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PREFIJOCLIENTE", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IPREFIJOCLIENTE"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IPREFIJOCLIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@RECIBOLARGOCONFACTURA", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IRECIBOLARGOCONFACTURA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IRECIBOLARGOCONFACTURA;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@MOSTRARPZACAJAENFACTURA", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IMOSTRARPZACAJAENFACTURA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IMOSTRARPZACAJAENFACTURA;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESGLOSEIEPS", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IDESGLOSEIEPS"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IDESGLOSEIEPS;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CUENTAIEPS", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["ICUENTAIEPS"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ICUENTAIEPS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@DIVIDIR_REM_FACT", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IDIVIDIR_REM_FACT"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IDIVIDIR_REM_FACT;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@WEBSERVICE", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IWEBSERVICE"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IWEBSERVICE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("MINUTILIDAD", FbDbType.Decimal);
                if (!(bool)oCPARAMETRONuevo.isnull["IMINUTILIDAD"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IMINUTILIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MANEJASUPERLISTAPRECIO", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IMANEJASUPERLISTAPRECIO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IMANEJASUPERLISTAPRECIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MANEJAALMACEN", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IMANEJAALMACEN"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IMANEJAALMACEN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPODESCUENTOPRODID", FbDbType.BigInt);
                if (!(bool)oCPARAMETRONuevo.isnull["ITIPODESCUENTOPRODID"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ITIPODESCUENTOPRODID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MANEJARECETA", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IMANEJARECETA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IMANEJARECETA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@TIPOUTILIDADID", FbDbType.BigInt);
                if (!(bool)oCPARAMETRONuevo.isnull["ITIPOUTILIDADID"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ITIPOUTILIDADID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@MANEJAQUOTA", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IMANEJAQUOTA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IMANEJAQUOTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TOUCH", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["ITOUCH"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ITOUCH;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESVENDEDORMOVIL", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IESVENDEDORMOVIL"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IESVENDEDORMOVIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAJASBOTELLAS", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["ICAJASBOTELLAS"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ICAJASBOTELLAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRECIONETOENPV", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IPRECIONETOENPV"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IPRECIONETOENPV;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@TIPOSYNCMOVIL", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["ITIPOSYNCMOVIL"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ITIPOSYNCMOVIL;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@AUTOCOMPPROD", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IAUTOCOMPPROD"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IAUTOCOMPPROD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@MOSTRARFLASH", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IMOSTRARFLASH"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IMOSTRARFLASH;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ORDENIMPRESION", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IORDENIMPRESION"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IORDENIMPRESION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@AUTOCOMPCLIENTE", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IAUTOCOMPCLIENTE"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IAUTOCOMPCLIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PRECIOXCAJAENPV", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IPRECIOXCAJAENPV"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IPRECIOXCAJAENPV;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LOCALFTPHOST", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["ILOCALFTPHOST"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ILOCALFTPHOST;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LOCALWEBSERVICE", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["ILOCALWEBSERVICE"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ILOCALWEBSERVICE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@USARCONEXIONLOCAL", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IUSARCONEXIONLOCAL"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IUSARCONEXIONLOCAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@MAILTOINVENTARIO", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IMAILTOINVENTARIO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IMAILTOINVENTARIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RUTARESPALDOSZIP", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IRUTARESPALDOSZIP"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IRUTARESPALDOSZIP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@SCREENCONFIG", FbDbType.BigInt);
                if (!(bool)oCPARAMETRONuevo.isnull["ISCREENCONFIG"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ISCREENCONFIG;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PROMOENTICKET", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IPROMOENTICKET"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IPROMOENTICKET;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TAMANOLETRATICKET", FbDbType.SmallInt);
                if (!(bool)oCPARAMETRONuevo.isnull["ITAMANOLETRATICKET"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ITAMANOLETRATICKET;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MANEJAKITS", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IMANEJAKITS"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IMANEJAKITS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMPOIMPOCOSTOREPO", FbDbType.BigInt);
                if (!(bool)oCPARAMETRONuevo.isnull["ICAMPOIMPOCOSTOREPO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ICAMPOIMPOCOSTOREPO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REBAJAESPECIAL", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IREBAJAESPECIAL"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IREBAJAESPECIAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LISTAPRECIOMINIMO", FbDbType.BigInt);
                if (!(bool)oCPARAMETRONuevo.isnull["ILISTAPRECIOMINIMO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ILISTAPRECIOMINIMO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@HABILITARREPL", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IHABILITARREPL"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IHABILITARREPL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@BDLOCALREPL", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IBDLOCALREPL"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IBDLOCALREPL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PENDMOVILANTESVENTA", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IPENDMOVILANTESVENTA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IPENDMOVILANTESVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIOSMOVILANTESVENTA", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IPRECIOSMOVILANTESVENTA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IPRECIOSMOVILANTESVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RECALCULARCAMBIOCLIENTE", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IRECALCULARCAMBIOCLIENTE"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IRECALCULARCAMBIOCLIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOVENDEDORMOVIL", FbDbType.BigInt);
                if (!(bool)oCPARAMETRONuevo.isnull["ITIPOVENDEDORMOVIL"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ITIPOVENDEDORMOVIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@BDSERVERWS", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IBDSERVERWS"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IBDSERVERWS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@BDMATRIZMOVIL", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IBDMATRIZMOVIL"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IBDMATRIZMOVIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@MOVILVERIFICARVENTA", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IMOVILVERIFICARVENTA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IMOVILVERIFICARVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@PENDMAXDIAS", FbDbType.Integer);
                if (!(bool)oCPARAMETRONuevo.isnull["IPENDMAXDIAS"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IPENDMAXDIAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@REQAUTCANCELARCOTI", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IREQAUTCANCELARCOTI"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IREQAUTCANCELARCOTI;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@REQAUTELIMDETALLECOTI", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IREQAUTELIMDETALLECOTI"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IREQAUTELIMDETALLECOTI;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ABRIRCAJONALFINCORTE", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IABRIRCAJONALFINCORTE"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IABRIRCAJONALFINCORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);





                auxPar = new FbParameter("@HABSURTIDOPOSTPUESTO", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IHABSURTIDOPOSTPUESTO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IHABSURTIDOPOSTPUESTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLIENTECONSOLIDADOID", FbDbType.BigInt);
                if (!(bool)oCPARAMETRONuevo.isnull["ICLIENTECONSOLIDADOID"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ICLIENTECONSOLIDADOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@DOBLECOPIAREMISION", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IDOBLECOPIAREMISION"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IDOBLECOPIAREMISION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@REIMPRESIONESCONMARCA", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IREIMPRESIONESCONMARCA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IREIMPRESIONESCONMARCA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@HABTOTALIZADOS", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IHABTOTALIZADOS"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IHABTOTALIZADOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@MULTIPLETIPOVALE", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IMULTIPLETIPOVALE"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IMULTIPLETIPOVALE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@DESCUENTOTIPO1TEXTO", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IDESCUENTOTIPO1TEXTO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IDESCUENTOTIPO1TEXTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCUENTOTIPO1PORC", FbDbType.Numeric);
                if (!(bool)oCPARAMETRONuevo.isnull["IDESCUENTOTIPO1PORC"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IDESCUENTOTIPO1PORC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCUENTOTIPO2TEXTO", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IDESCUENTOTIPO2TEXTO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IDESCUENTOTIPO2TEXTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCUENTOTIPO2PORC", FbDbType.Numeric);
                if (!(bool)oCPARAMETRONuevo.isnull["IDESCUENTOTIPO2PORC"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IDESCUENTOTIPO2PORC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCUENTOTIPO3TEXTO", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IDESCUENTOTIPO3TEXTO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IDESCUENTOTIPO3TEXTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCUENTOTIPO3PORC", FbDbType.Numeric);
                if (!(bool)oCPARAMETRONuevo.isnull["IDESCUENTOTIPO3PORC"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IDESCUENTOTIPO3PORC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCUENTOTIPO4TEXTO", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IDESCUENTOTIPO4TEXTO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IDESCUENTOTIPO4TEXTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCUENTOTIPO4PORC", FbDbType.Numeric);
                if (!(bool)oCPARAMETRONuevo.isnull["IDESCUENTOTIPO4PORC"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IDESCUENTOTIPO4PORC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@HABILITARLOG", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IHABILITARLOG"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IHABILITARLOG;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RUTARESPALDO", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IRUTARESPALDO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IRUTARESPALDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@MANEJARRETIRODECAJA", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IMANEJARRETIRODECAJA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IMANEJARRETIRODECAJA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTORETIROCAJA", FbDbType.Numeric);
                if (!(bool)oCPARAMETRONuevo.isnull["IMONTORETIROCAJA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IMONTORETIROCAJA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);






                auxPar = new FbParameter("@APLICARMAYOREOPORLINEA", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IAPLICARMAYOREOPORLINEA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IAPLICARMAYOREOPORLINEA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("COMISIONPORTARJETA", FbDbType.Numeric);
                if (!(bool)oCPARAMETRONuevo.isnull["ICOMISIONPORTARJETA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ICOMISIONPORTARJETA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PIEZASIGUALESMEDIOMAYOREO", FbDbType.Numeric);
                if (!(bool)oCPARAMETRONuevo.isnull["IPIEZASIGUALESMEDIOMAYOREO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IPIEZASIGUALESMEDIOMAYOREO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PIEZASDIFMEDIOMAYOREO", FbDbType.Numeric);
                if (!(bool)oCPARAMETRONuevo.isnull["IPIEZASDIFMEDIOMAYOREO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IPIEZASDIFMEDIOMAYOREO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PIEZASIGUALESMAYOREO", FbDbType.Numeric);
                if (!(bool)oCPARAMETRONuevo.isnull["IPIEZASIGUALESMAYOREO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IPIEZASIGUALESMAYOREO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PIEZASDIFMAYOREO", FbDbType.Numeric);
                if (!(bool)oCPARAMETRONuevo.isnull["IPIEZASDIFMAYOREO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IPIEZASDIFMAYOREO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COMISIONTARJETAEMPRESA", FbDbType.Numeric);
                if (!(bool)oCPARAMETRONuevo.isnull["ICOMISIONTARJETAEMPRESA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ICOMISIONTARJETAEMPRESA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IVACOMISIONTARJETAEMPRESA", FbDbType.Numeric);
                if (!(bool)oCPARAMETRONuevo.isnull["IIVACOMISIONTARJETAEMPRESA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IIVACOMISIONTARJETAEMPRESA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PREGUNTACANCELACOTIZACION", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IPREGUNTACANCELACOTIZACION"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IPREGUNTACANCELACOTIZACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@HABVERIFICACIONCXC", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IHABVERIFICACIONCXC"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IHABVERIFICACIONCXC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MAILEJECUTIVO", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IMAILEJECUTIVO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IMAILEJECUTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENTASXCORTEEMAIL", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IVENTASXCORTEEMAIL"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IVENTASXCORTEEMAIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@HABVENTASAFUTURO", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IHABVENTASAFUTURO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IHABVENTASAFUTURO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);





                auxPar = new FbParameter("@SERVICIOSEMIDA", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["ISERVICIOSEMIDA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ISERVICIOSEMIDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAACTUALIZACIONEMIDA", FbDbType.Date);
                if (!(bool)oCPARAMETRONuevo.isnull["IFECHAACTUALIZACIONEMIDA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IFECHAACTUALIZACIONEMIDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FORMATOTICKETCORTOID", FbDbType.BigInt);
                if (!(bool)oCPARAMETRONuevo.isnull["IFORMATOTICKETCORTOID"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IFORMATOTICKETCORTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@SERIESATABONO", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["ISERIESATABONO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ISERIESATABONO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                
                auxPar = new FbParameter("@HABIMPRESIONCORTECAJERO", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IHABIMPRESIONCORTECAJERO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IHABIMPRESIONCORTECAJERO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@HABTRASLADOPORAUTORIZACION", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IHABTRASLADOPORAUTORIZACION"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IHABTRASLADOPORAUTORIZACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@HABVENTASMOSTRADOR", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IHABVENTASMOSTRADOR"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IHABVENTASMOSTRADOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIMEOUTPINDISTSALE", FbDbType.Integer);
                if (!(bool)oCPARAMETRONuevo.isnull["ITIMEOUTPINDISTSALE"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ITIMEOUTPINDISTSALE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIMEOUTLOOKUP", FbDbType.Integer);
                if (!(bool)oCPARAMETRONuevo.isnull["ITIMEOUTLOOKUP"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ITIMEOUTLOOKUP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RUTAARCHIVOSADJUNTOS", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IRUTAARCHIVOSADJUNTOS"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IRUTAARCHIVOSADJUNTOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@TIMEOUTPINDISTSALESERV", FbDbType.Integer);
                if (!(bool)oCPARAMETRONuevo.isnull["ITIMEOUTPINDISTSALESERV"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ITIMEOUTPINDISTSALESERV;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@HABPAGOSERVEMIDA", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IHABPAGOSERVEMIDA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IHABPAGOSERVEMIDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@HABPROMOXMONTOMIN", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IHABPROMOXMONTOMIN"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IHABPROMOXMONTOMIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@FORMATOFACTELECT", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IFORMATOFACTELECT"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IFORMATOFACTELECT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONTOMAXSALDOMENOR", FbDbType.Decimal);
                if (!(bool)oCPARAMETRONuevo.isnull["IMONTOMAXSALDOMENOR"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IMONTOMAXSALDOMENOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@EMIDARECARGALINEAID", FbDbType.BigInt);
                if (!(bool)oCPARAMETRONuevo.isnull["IEMIDARECARGALINEAID"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IEMIDARECARGALINEAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@EMIDARECARGAMARCAID", FbDbType.BigInt);
                if (!(bool)oCPARAMETRONuevo.isnull["IEMIDARECARGAMARCAID"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IEMIDARECARGAMARCAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@EMIDARECARGAPROVEEDORID", FbDbType.BigInt);
                if (!(bool)oCPARAMETRONuevo.isnull["IEMIDARECARGAPROVEEDORID"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IEMIDARECARGAPROVEEDORID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@EMIDASERVICIOLINEAID", FbDbType.BigInt);
                if (!(bool)oCPARAMETRONuevo.isnull["IEMIDASERVICIOLINEAID"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IEMIDASERVICIOLINEAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@EMIDASERVICIOMARCAID", FbDbType.BigInt);
                if (!(bool)oCPARAMETRONuevo.isnull["IEMIDASERVICIOMARCAID"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IEMIDASERVICIOMARCAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@EMIDASERVICIOPROVEEDORID", FbDbType.BigInt);
                if (!(bool)oCPARAMETRONuevo.isnull["IEMIDASERVICIOPROVEEDORID"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IEMIDASERVICIOPROVEEDORID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("EMIDAPORCUTILIDADRECARGAS", FbDbType.Numeric);
                if (!(bool)oCPARAMETRONuevo.isnull["IEMIDAPORCUTILIDADRECARGAS"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IEMIDAPORCUTILIDADRECARGAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@EMIDAUTILIDADPAGOSERVICIOS", FbDbType.Numeric);
                if (!(bool)oCPARAMETRONuevo.isnull["IEMIDAUTILIDADPAGOSERVICIOS"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IEMIDAUTILIDADPAGOSERVICIOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PRECIOSORDENADOS", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IPRECIOSORDENADOS"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IPRECIOSORDENADOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@DECIMALESENCANTIDAD", FbDbType.Integer);
                if (!(bool)oCPARAMETRONuevo.isnull["IDECIMALESENCANTIDAD"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IDECIMALESENCANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@EANPUEDEREPETIRSE", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IEANPUEDEREPETIRSE"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IEANPUEDEREPETIRSE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@BANCOMERHABPINPAD", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IBANCOMERHABPINPAD"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IBANCOMERHABPINPAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@HAB_PRECIOSCLIENTE", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IHAB_PRECIOSCLIENTE"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IHAB_PRECIOSCLIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@CXCVALIDARTRASLADOS", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["ICXCVALIDARTRASLADOS"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ICXCVALIDARTRASLADOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PREGUNTARSIESACREDITO", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IPREGUNTARSIESACREDITO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IPREGUNTARSIESACREDITO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@HABMENSAJERIA", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IHABMENSAJERIA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IHABMENSAJERIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@WSMENSAJERIA", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IWSMENSAJERIA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IWSMENSAJERIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@HABDESCLINEAPERSONA", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IHABDESCLINEAPERSONA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IHABDESCLINEAPERSONA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MANEJARLOTEIMPORTACION", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IMANEJARLOTEIMPORTACION"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IMANEJARLOTEIMPORTACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@MANEJAGASTOSADIC", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IMANEJAGASTOSADIC"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IMANEJAGASTOSADIC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CADUCIDADMINIMA", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["ICADUCIDADMINIMA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ICADUCIDADMINIMA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIOAJUSTEDIFINV", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IPRECIOAJUSTEDIFINV"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IPRECIOAJUSTEDIFINV;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@HABBOTONPAGOVALE", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IHABBOTONPAGOVALE"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IHABBOTONPAGOVALE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@UNICAVISITAPORDOCTO", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IUNICAVISITAPORDOCTO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IUNICAVISITAPORDOCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PLAZOXPRODUCTO", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IPLAZOXPRODUCTO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IPLAZOXPRODUCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IPWEBSERVICEAPPINV", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IIPWEBSERVICEAPPINV"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IIPWEBSERVICEAPPINV;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RUTABDAPPINVENTARO", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IRUTABDAPPINVENTARO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IRUTABDAPPINVENTARO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@AUTOCOMPLETECONEXISENVENTA", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IAUTOCOMPLETECONEXISENVENTA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IAUTOCOMPLETECONEXISENVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@RUTADBFEXISTENCIASUC", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IRUTADBFEXISTENCIASUC"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IRUTADBFEXISTENCIASUC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@ALMACENRECEPCIONID", FbDbType.BigInt);
                if (!(bool)oCPARAMETRONuevo.isnull["IALMACENRECEPCIONID"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IALMACENRECEPCIONID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@APLICARCAMBIOSPRECAUTO", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IAPLICARCAMBIOSPRECAUTO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IAPLICARCAMBIOSPRECAUTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMCANCELACTAUTO", FbDbType.SmallInt);
                if (!(bool)oCPARAMETRONuevo.isnull["INUMCANCELACTAUTO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.INUMCANCELACTAUTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MANEJACUPONES", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IMANEJACUPONES"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IMANEJACUPONES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@HAB_DEVOLUCIONTRASLADO", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IHAB_DEVOLUCIONTRASLADO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IHAB_DEVOLUCIONTRASLADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@HAB_DEVOLUCIONSURTIDOSUC", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IHAB_DEVOLUCIONSURTIDOSUC"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IHAB_DEVOLUCIONSURTIDOSUC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VERSIONWSEXISTENCIAS", FbDbType.Integer);
                if (!(bool)oCPARAMETRONuevo.isnull["IVERSIONWSEXISTENCIAS"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IVERSIONWSEXISTENCIAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@MOSTRARINVINFOADICPROD", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IMOSTRARINVINFOADICPROD"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IMOSTRARINVINFOADICPROD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MANEJAPRODUCTOSPROMOCION", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IMANEJAPRODUCTOSPROMOCION"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IMANEJAPRODUCTOSPROMOCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_METODOPAGOID", FbDbType.BigInt);
                if (!(bool)oCPARAMETRONuevo.isnull["ISAT_METODOPAGOID"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ISAT_METODOPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_REGIMENFISCALID", FbDbType.BigInt);
                if (!(bool)oCPARAMETRONuevo.isnull["ISAT_REGIMENFISCALID"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ISAT_REGIMENFISCALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOSELECCIONCATALOGOSAT", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["ITIPOSELECCIONCATALOGOSAT"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ITIPOSELECCIONCATALOGOSAT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIONETOENGRIDS", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IPRECIONETOENGRIDS"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IPRECIONETOENGRIDS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PAGOSERVCONSOLIDADO", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["IPAGOSERVCONSOLIDADO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IPAGOSERVCONSOLIDADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@WSESPECIALEXISTMATRIZ", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IWSESPECIALEXISTMATRIZ"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IWSESPECIALEXISTMATRIZ;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@GENERARFE", FbDbType.VarChar);
                if(!(bool)oCPARAMETRONuevo.isnull["IGENERARFE"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IGENERARFE;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@RUTAREPLICADOREXE", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IRUTAREPLICADOREXE"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IRUTAREPLICADOREXE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@HAB_CONSOLIDADOAUTOMATICO", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IHAB_CONSOLIDADOAUTOMATICO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IHAB_CONSOLIDADOAUTOMATICO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@TICKETESPECIAL", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["ITICKETESPECIAL"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ITICKETESPECIAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@TICKETDEFAULTPRINTER", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["ITICKETDEFAULTPRINTER"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ITICKETDEFAULTPRINTER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RECARGASDEFAULTPRINTER", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IRECARGASDEFAULTPRINTER"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IRECARGASDEFAULTPRINTER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PIEZACAJAENTICKET", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IPIEZACAJAENTICKET"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IPIEZACAJAENTICKET;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUMTICKETSABONO", FbDbType.Integer);
                if (!(bool)oCPARAMETRONuevo.isnull["INUMTICKETSABONO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.INUMTICKETSABONO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PVCOLOREAR", FbDbType.Integer);
                if (!(bool)oCPARAMETRONuevo.isnull["IPVCOLOREAR"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IPVCOLOREAR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@INTENTOSRETIROCAJA", FbDbType.Integer);
                if (!(bool)oCPARAMETRONuevo.isnull["IINTENTOSRETIROCAJA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IINTENTOSRETIROCAJA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORMOVILCLAVE", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IVENDEDORMOVILCLAVE"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IVENDEDORMOVILCLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MOVIL_TIENEVENDEDORES", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IMOVIL_TIENEVENDEDORES"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IMOVIL_TIENEVENDEDORES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RUTACATALOGOSUPD", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IRUTACATALOGOSUPD"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IRUTACATALOGOSUPD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IMPRIMIRCOPIAALMACEN", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IIMPRIMIRCOPIAALMACEN"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IIMPRIMIRCOPIAALMACEN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MOVIL3_PREIMPORTAR", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IMOVIL3_PREIMPORTAR"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IMOVIL3_PREIMPORTAR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@RUTAIMPORTADATOS", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IRUTAIMPORTADATOS"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IRUTAIMPORTADATOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@BUSQUEDATIPO2", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IBUSQUEDATIPO2"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IBUSQUEDATIPO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@VERSIONCFDI", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IVERSIONCFDI"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IVERSIONCFDI;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);





                auxPar = new FbParameter("@AGRUPACIONVENTAID", FbDbType.BigInt);
                if (!(bool)oCPARAMETRONuevo.isnull["IAGRUPACIONVENTAID"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IAGRUPACIONVENTAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CONSFACTOMITIRVALES", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["ICONSFACTOMITIRVALES"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ICONSFACTOMITIRVALES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@DESTINOBDVENMOV", FbDbType.VarChar);
                if(!(bool)oCPARAMETRONuevo.isnull["IDESTINOBDVENMOV"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IDESTINOBDVENMOV;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@DOBLECOPIACONTADO", FbDbType.BigInt);
                if (!(bool)oCPARAMETRONuevo.isnull["IDOBLECOPIACONTADO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IDOBLECOPIACONTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESGLOSEIEPSFACTURA", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IDESGLOSEIEPSFACTURA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IDESGLOSEIEPSFACTURA;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RUTAPOLIZAPDF", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IRUTAPOLIZAPDF"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IRUTAPOLIZAPDF;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPRIMIRBANCOSCORTE", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IIMPRIMIRBANCOSCORTE"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IIMPRIMIRBANCOSCORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPR_CANC_VENTA", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IIMPR_CANC_VENTA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IIMPR_CANC_VENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@RETIROCAJAALCERRARCORTE", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IRETIROCAJAALCERRARCORTE"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IRETIROCAJAALCERRARCORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PAGOTARJMENORPRECIOLISTAALL", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IPAGOTARJMENORPRECIOLISTAALL"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IPAGOTARJMENORPRECIOLISTAALL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PREGUNTARSERVDOM", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IPREGUNTARSERVDOM"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IPREGUNTARSERVDOM;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@HABPPC", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IHABPPC"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IHABPPC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@SOLOABONOAPLICADO", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["ISOLOABONOAPLICADO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ISOLOABONOAPLICADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VERSIONTOPEID", FbDbType.BigInt);
                if (!(bool)oCPARAMETRONuevo.isnull["IVERSIONTOPEID"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IVERSIONTOPEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@VERSIONCOMISIONID", FbDbType.BigInt);
                if (!(bool)oCPARAMETRONuevo.isnull["IVERSIONCOMISIONID"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IVERSIONCOMISIONID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                
                auxPar = new FbParameter("MAXCOMISIONXCLIENTE", FbDbType.Numeric);
                if (!(bool)oCPARAMETRONuevo.isnull["IMAXCOMISIONXCLIENTE"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IMAXCOMISIONXCLIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@IMPRFORMAVENTATRASL", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IIMPRFORMAVENTATRASL"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IIMPRFORMAVENTATRASL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@HABREVISIONFINAL", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IHABREVISIONFINAL"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IHABREVISIONFINAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@RECIBOLARGOCOTIPRINTER", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IRECIBOLARGOCOTIPRINTER"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IRECIBOLARGOCOTIPRINTER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@HABFONDODINAMICO", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IHABFONDODINAMICO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IHABFONDODINAMICO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@HABVENTACLISUC", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IHABVENTACLISUC"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IHABVENTACLISUC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);







                auxPar = new FbParameter("@SEGUNDOSCICLOFTP", FbDbType.Integer);
                if (!(bool)oCPARAMETRONuevo.isnull["ISEGUNDOSCICLOFTP"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ISEGUNDOSCICLOFTP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@DIASMAXEXPFTP", FbDbType.Integer);
                if (!(bool)oCPARAMETRONuevo.isnull["IDIASMAXEXPFTP"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IDIASMAXEXPFTP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@DIASMAXIMPFTP", FbDbType.Integer);
                if (!(bool)oCPARAMETRONuevo.isnull["IDIASMAXIMPFTP"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IDIASMAXIMPFTP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@WSDBF", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IWSDBF"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IWSDBF;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@HABWSDBF", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IHABWSDBF"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IHABWSDBF;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@FISCALFECHACANCELACION2", FbDbType.Date);
                if (!(bool)oCPARAMETRONuevo.isnull["IFISCALFECHACANCELACION2"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IFISCALFECHACANCELACION2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTTICKETRETIRO", FbDbType.Integer);
                if (!(bool)oCPARAMETRONuevo.isnull["ICANTTICKETRETIRO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ICANTTICKETRETIRO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@COMISIONDEBPORTARJETA", FbDbType.Decimal);
                if (!(bool)oCPARAMETRONuevo.isnull["ICOMISIONDEBPORTARJETA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ICOMISIONDEBPORTARJETA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOBLECOPIATARJETA", FbDbType.Integer);
                if (!(bool)oCPARAMETRONuevo.isnull["IDOBLECOPIATARJETA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IDOBLECOPIATARJETA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FACTCONSMAXPOR", FbDbType.Decimal);
                if (!(bool)oCPARAMETRONuevo.isnull["IFACTCONSMAXPOR"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IFACTCONSMAXPOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@COMISIONDEBTARJETAEMPRESA", FbDbType.Decimal);
                if (!(bool)oCPARAMETRONuevo.isnull["ICOMISIONDEBTARJETAEMPRESA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ICOMISIONDEBTARJETAEMPRESA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CANTTICKETABRIRCORTE", FbDbType.Integer);
                if (!(bool)oCPARAMETRONuevo.isnull["ICANTTICKETABRIRCORTE"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ICANTTICKETABRIRCORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTTICKETCOMPRAS", FbDbType.Integer);
                if (!(bool)oCPARAMETRONuevo.isnull["ICANTTICKETCOMPRAS"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ICANTTICKETCOMPRAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTTICKETFONDOCAJA", FbDbType.Integer);
                if (!(bool)oCPARAMETRONuevo.isnull["ICANTTICKETFONDOCAJA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ICANTTICKETFONDOCAJA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTTICKETGASTOS", FbDbType.Integer);
                if (!(bool)oCPARAMETRONuevo.isnull["ICANTTICKETGASTOS"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ICANTTICKETGASTOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTTICKETDEPOSITOS", FbDbType.Integer);
                if (!(bool)oCPARAMETRONuevo.isnull["ICANTTICKETDEPOSITOS"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ICANTTICKETDEPOSITOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTTICKETCIERRECORTE", FbDbType.Integer);
                if (!(bool)oCPARAMETRONuevo.isnull["ICANTTICKETCIERRECORTE"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ICANTTICKETCIERRECORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTTICKETCIERREBILLETES", FbDbType.Integer);
                if (!(bool)oCPARAMETRONuevo.isnull["ICANTTICKETCIERREBILLETES"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ICANTTICKETCIERREBILLETES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MANEJAUTILIDADPRECIOS", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IMANEJAUTILIDADPRECIOS"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IMANEJAUTILIDADPRECIOS;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@HABMULTPLAZOCOMPRA", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IHABMULTPLAZOCOMPRA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IHABMULTPLAZOCOMPRA;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COSTOREPOIGUALCOSTOULT", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["ICOSTOREPOIGUALCOSTOULT"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ICOSTOREPOIGUALCOSTOULT;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TICKET_DESC_VALE_AL_FINAL", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["ITICKET_DESC_VALE_AL_FINAL"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ITICKET_DESC_VALE_AL_FINAL;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("MONEDEROLISTAPRECIOID", FbDbType.BigInt);
                if (!(bool)oCPARAMETRONuevo.isnull["IMONEDEROLISTAPRECIOID"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IMONEDEROLISTAPRECIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONEDEROCAMPOREF", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IMONEDEROCAMPOREF"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IMONEDEROCAMPOREF;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@HABSURTIDOPREVIO", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IHABSURTIDOPREVIO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IHABSURTIDOPREVIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUMTICKETSCOMANDA", FbDbType.Integer);
                if (!(bool)oCPARAMETRONuevo.isnull["INUMTICKETSCOMANDA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.INUMTICKETSCOMANDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RECIBOPREVIEWCOMANDA", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IRECIBOPREVIEWCOMANDA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IRECIBOPREVIEWCOMANDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPRESORACOMANDA", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IIMPRESORACOMANDA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IIMPRESORACOMANDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@TICKET_IMPR_DESC2", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["ITICKET_IMPR_DESC2"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ITICKET_IMPR_DESC2;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SERIECOMPRTRASLSAT", FbDbType.Char);
                if (!(bool)oCPARAMETRONuevo.isnull["ISERIECOMPRTRASLSAT"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ISERIECOMPRTRASLSAT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@HABSURTIDOPOSTMOVIL", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IHABSURTIDOPOSTMOVIL"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IHABSURTIDOPOSTMOVIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PORCUTILIDADLISTADO", FbDbType.Decimal);
                if (!(bool)oCPARAMETRONuevo.isnull["IPORCUTILIDADLISTADO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IPORCUTILIDADLISTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RUTAFIRMAIMAGENES", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IRUTAFIRMAIMAGENES"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IRUTAFIRMAIMAGENES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@LISTAPRECIOMAYLINEA", FbDbType.BigInt);
                if (!(bool)oCPARAMETRONuevo.isnull["ILISTAPRECIOMAYLINEA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ILISTAPRECIOMAYLINEA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LISTAPRECMEDMAYLINEA", FbDbType.BigInt);
                if (!(bool)oCPARAMETRONuevo.isnull["ILISTAPRECMEDMAYLINEA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ILISTAPRECMEDMAYLINEA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@AUTPRECIOLISTABAJO", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IAUTPRECIOLISTABAJO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IAUTPRECIOLISTABAJO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@PORCUTILMACROLISTADO", FbDbType.Decimal);
                if (!(bool)oCPARAMETRONuevo.isnull["IPORCUTILMACROLISTADO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IPORCUTILMACROLISTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                //NUMTICKETSCOMANDA = @NUMTICKETSCOMANDA
                //RECIBOPREVIEWCOMANDA = @RECIBOPREVIEWCOMANDA
                //IMPRESORACOMANDA = @IMPRESORACOMANDA


                string commandText = @"
  update  PARAMETRO
  set

SUCURSALID=@SUCURSALID,

SUCURSALNUMERO=@SUCURSALNUMERO,

CORTEACTUALID=@CORTEACTUALID,

CAJEROACTUALID=@CAJEROACTUALID,

NOMBRE=@NOMBRE,

CALLE=@CALLE,

COLONIA=@COLONIA,

LOCALIDAD=@LOCALIDAD,

ESTADO=@ESTADO,

CP=@CP,

TELEFONO=@TELEFONO,

FAX=@FAX,

CORREOE=@CORREOE,

PAGINAWEB=@PAGINAWEB,

RFC=@RFC,

LISTA_PRECIO_DEF=@LISTA_PRECIO_DEF,

IMP_PROD_DEF=@IMP_PROD_DEF,

ESTADO_DEF=@ESTADO_DEF,

FECHAULTIMA = @FECHAULTIMA,

ID_DOSLETRAS = @ID_DOSLETRAS,

HABILITAR_IMPEXP_AUT = @HABILITAR_IMPEXP_AUT,

FTPHOST= @FTPHOST ,

FTPUSUARIO= @FTPUSUARIO ,

FTPPASSWORD = @FTPPASSWORD ,

SMTPHOST = @SMTPHOST ,

SMTPUSUARIO = @SMTPUSUARIO ,

SMTPPASSWORD = @SMTPPASSWORD ,

SMTPPORT = @SMTPPORT ,

SMTPMAILFROM = @SMTPMAILFROM ,

SMTPMAILTO = @SMTPMAILTO ,

CAMBIARPRECIO = @CAMBIARPRECIO,

HEADER = @HEADER ,

FOOTER = @FOOTER,

HAB_SEL_CLIENTE = @HAB_SEL_CLIENTE,

HAB_IMPR_COTIZACION = @HAB_IMPR_COTIZACION,

COMISIONMEDICO = @COMISIONMEDICO,

COMISIONDEPENDIENTE = @COMISIONDEPENDIENTE,

MOSTRAR_EXIS_SUC = @MOSTRAR_EXIS_SUC,

REQ_APROBACION_INV = @REQ_APROBACION_INV,

REABRIRCORTES = @REABRIRCORTES,

DESCUENTOVALE = @DESCUENTOVALE,

IMP_PROD_TOTAL = @IMP_PROD_TOTAL,

NUMEROEXTERIOR = @NUMEROEXTERIOR,

NUMEROINTERIOR = @NUMEROINTERIOR,

FISCALCALLE  = @FISCALCALLE ,
FISCALNUMEROINTERIOR  = @FISCALNUMEROINTERIOR ,
FISCALNUMEROEXTERIOR  = @FISCALNUMEROEXTERIOR ,
FISCALCOLONIA  = @FISCALCOLONIA ,
FISCALMUNICIPIO  = @FISCALMUNICIPIO ,
FISCALESTADO  = @FISCALESTADO ,
FISCALCODIGOPOSTAL  = @FISCALCODIGOPOSTAL,

CERTIFICADOCSD  = @CERTIFICADOCSD ,
TIMBRADOUSER  = @TIMBRADOUSER ,
TIMBRADOPASSWORD  = @TIMBRADOPASSWORD ,
TIMBRADOARCHIVOCERTIFICADO  = @TIMBRADOARCHIVOCERTIFICADO ,
TIMBRADOARCHIVOKEY  = @TIMBRADOARCHIVOKEY ,

TIMBRADOKEY = @TIMBRADOKEY,
FISCALNOMBRE = @FISCALNOMBRE,

SERIESAT = @SERIESAT,
USARFISCALESENEXPEDICION = @USARFISCALESENEXPEDICION,

HAB_FACTURAELECTRONICA = @HAB_FACTURAELECTRONICA,

FOOTERVENTAAPARTADO = @FOOTERVENTAAPARTADO,

ENCARGADOID = @ENCARGADOID,

PORC_COMISIONENCARGADO = @PORC_COMISIONENCARGADO,

PORC_COMISIONVENDEDOR = @PORC_COMISIONVENDEDOR,

FTPFOLDER = @FTPFOLDER,

FTPFOLDERPASS = @FTPFOLDERPASS,

SERIESATDEVOLUCION = @SERIESATDEVOLUCION,

CAMBIARPRECIOXUEMPAQUE = @CAMBIARPRECIOXUEMPAQUE,

CAMBIARPRECIOXPZACAJA =@CAMBIARPRECIOXPZACAJA,

PREFIJOBASCULA = @PREFIJOBASCULA,

LONGPRODBASCULA = @LONGPRODBASCULA,

LONGPESOBASCULA = @LONGPESOBASCULA,


LISTAPRECIOXUEMPAQUE = @LISTAPRECIOXUEMPAQUE,
LISTAPRECIOXPZACAJA = @LISTAPRECIOXPZACAJA,
LISTAPRECIOINIMAYO = @LISTAPRECIOINIMAYO,

HAYVENDEDORPISO = @HAYVENDEDORPISO,
ENVIOAUTOMATICOEXISTENCIAS = @ENVIOAUTOMATICOEXISTENCIAS,

MONEDEROMONTOMINIMO=@MONEDEROMONTOMINIMO,

MONEDEROAPLICAR=@MONEDEROAPLICAR,

MONEDEROCADUCIDAD=@MONEDEROCADUCIDAD,

IMPRIMIRNUMEROPIEZAS = @IMPRIMIRNUMEROPIEZAS,

PACNOMBRE = @PACNOMBRE,
PACUSUARIO = @PACUSUARIO,

CORTEPORMAIL = @CORTEPORMAIL,

RUTAREPORTES = @RUTAREPORTES,

RUTAREPORTESSISTEMA = @RUTAREPORTESSISTEMA,

DOBLECOPIACREDITO = @DOBLECOPIACREDITO,
DOBLECOPIATRASLADO = @DOBLECOPIATRASLADO,
CAMPOSCUSTOMALIMPORTAR = @CAMPOSCUSTOMALIMPORTAR,

RECIBOLARGOPRINTER = @RECIBOLARGOPRINTER,

RECIBOLARGOPREVIEW = @RECIBOLARGOPREVIEW,

PREGUNTARRAZONPRECIOMENOR = @PREGUNTARRAZONPRECIOMENOR,

PREGUNTARDATOSENTREGA = @PREGUNTARDATOSENTREGA,

FISCALREGIMEN = @FISCALREGIMEN,

CORTACADUCIDAD = @CORTACADUCIDAD,

RETENCIONIVA = @RETENCIONIVA ,

RETENCIONISR = @RETENCIONISR ,

ARRENDATARIO = @ARRENDATARIO ,

RUTAIMAGENESPRODUCTO =@RUTAIMAGENESPRODUCTO,

MOSTRARIMAGENENVENTA = @MOSTRARIMAGENENVENTA,

MOSTRARMONTOAHORRO = @MOSTRARMONTOAHORRO,

SMTPSSL = @SMTPSSL,

MOSTRARDESCUENTOFACTURA = @MOSTRARDESCUENTOFACTURA,

EXPORTCATALOGOAUX = @EXPORTCATALOGOAUX,

UIVENTACONCANTIDAD = @UIVENTACONCANTIDAD,

FACT_ELECT_FOLDER = @FACT_ELECT_FOLDER,

PEDIDOS_FOLDER = @PEDIDOS_FOLDER,

PREFIJOCLIENTE = @PREFIJOCLIENTE,

RECIBOLARGOCONFACTURA = @RECIBOLARGOCONFACTURA,

MOSTRARPZACAJAENFACTURA = @MOSTRARPZACAJAENFACTURA,

DESGLOSEIEPS = @DESGLOSEIEPS,

CUENTAIEPS = @CUENTAIEPS,

DIVIDIR_REM_FACT = @DIVIDIR_REM_FACT,


WEBSERVICE = @WEBSERVICE,

MINUTILIDAD = @MINUTILIDAD,
MANEJASUPERLISTAPRECIO = @MANEJASUPERLISTAPRECIO,

MANEJAALMACEN = @MANEJAALMACEN,

TIPODESCUENTOPRODID = @TIPODESCUENTOPRODID,

MANEJARECETA = @MANEJARECETA,

AUTOCOMPPROD = @AUTOCOMPPROD,

MANEJAQUOTA = @MANEJAQUOTA,

TIPOUTILIDADID = @TIPOUTILIDADID,

TOUCH = @TOUCH,

ESVENDEDORMOVIL = @ESVENDEDORMOVIL,
CAJASBOTELLAS = @CAJASBOTELLAS,

PRECIONETOENPV = @PRECIONETOENPV,

TIPOSYNCMOVIL = @TIPOSYNCMOVIL,

MOSTRARFLASH = @MOSTRARFLASH,

ORDENIMPRESION = @ORDENIMPRESION,

AUTOCOMPCLIENTE = @AUTOCOMPCLIENTE,

PRECIOXCAJAENPV = @PRECIOXCAJAENPV,

LOCALFTPHOST = @LOCALFTPHOST,
LOCALWEBSERVICE = @LOCALWEBSERVICE,
USARCONEXIONLOCAL = @USARCONEXIONLOCAL,
MAILTOINVENTARIO = @MAILTOINVENTARIO,
RUTARESPALDOSZIP = @RUTARESPALDOSZIP,

SCREENCONFIG = @SCREENCONFIG,

PROMOENTICKET = @PROMOENTICKET,
TAMANOLETRATICKET = @TAMANOLETRATICKET,

MANEJAKITS = @MANEJAKITS,

CAMPOIMPOCOSTOREPO = @CAMPOIMPOCOSTOREPO,

REBAJAESPECIAL = @REBAJAESPECIAL,

LISTAPRECIOMINIMO = @LISTAPRECIOMINIMO,

HABILITARREPL = @HABILITARREPL,

BDLOCALREPL = @BDLOCALREPL,

PENDMOVILANTESVENTA = @PENDMOVILANTESVENTA,

PRECIOSMOVILANTESVENTA = @PRECIOSMOVILANTESVENTA,

RECALCULARCAMBIOCLIENTE = @RECALCULARCAMBIOCLIENTE,

BDSERVERWS = @BDSERVERWS,

BDMATRIZMOVIL = @BDMATRIZMOVIL,

TIPOVENDEDORMOVIL = @TIPOVENDEDORMOVIL,

MOVILVERIFICARVENTA = @MOVILVERIFICARVENTA,

PENDMAXDIAS = @PENDMAXDIAS,

REQAUTCANCELARCOTI = @REQAUTCANCELARCOTI,

REQAUTELIMDETALLECOTI = @REQAUTELIMDETALLECOTI,

ABRIRCAJONALFINCORTE = @ABRIRCAJONALFINCORTE,

HABSURTIDOPOSTPUESTO = @HABSURTIDOPOSTPUESTO,

CLIENTECONSOLIDADOID = @CLIENTECONSOLIDADOID,

DOBLECOPIAREMISION = @DOBLECOPIAREMISION,

REIMPRESIONESCONMARCA = @REIMPRESIONESCONMARCA,

HABTOTALIZADOS = @HABTOTALIZADOS,

MULTIPLETIPOVALE = @MULTIPLETIPOVALE,

DESCUENTOTIPO1TEXTO = @DESCUENTOTIPO1TEXTO,

DESCUENTOTIPO1PORC = @DESCUENTOTIPO1PORC,

DESCUENTOTIPO2TEXTO = @DESCUENTOTIPO2TEXTO,

DESCUENTOTIPO2PORC = @DESCUENTOTIPO2PORC,

DESCUENTOTIPO3TEXTO = @DESCUENTOTIPO3TEXTO,

DESCUENTOTIPO3PORC = @DESCUENTOTIPO3PORC,

DESCUENTOTIPO4TEXTO = @DESCUENTOTIPO4TEXTO,

DESCUENTOTIPO4PORC = @DESCUENTOTIPO4PORC,

HABILITARLOG = @HABILITARLOG,

RUTARESPALDO = @RUTARESPALDO,

FECHARESPALDO = @FECHARESPALDO,

MANEJARRETIRODECAJA = @MANEJARRETIRODECAJA,

MONTORETIROCAJA = @MONTORETIROCAJA,

APLICARMAYOREOPORLINEA = @APLICARMAYOREOPORLINEA,
COMISIONPORTARJETA = @COMISIONPORTARJETA,
PIEZASIGUALESMEDIOMAYOREO = @PIEZASIGUALESMEDIOMAYOREO,
PIEZASDIFMEDIOMAYOREO = @PIEZASDIFMEDIOMAYOREO ,
PIEZASIGUALESMAYOREO = @PIEZASIGUALESMAYOREO ,
PIEZASDIFMAYOREO = @PIEZASDIFMAYOREO ,
COMISIONTARJETAEMPRESA = @COMISIONTARJETAEMPRESA,
IVACOMISIONTARJETAEMPRESA = @IVACOMISIONTARJETAEMPRESA,
PREGUNTACANCELACOTIZACION = @PREGUNTACANCELACOTIZACION,

HABVERIFICACIONCXC = @HABVERIFICACIONCXC,

MAILEJECUTIVO = @MAILEJECUTIVO,

VENTASXCORTEEMAIL = @VENTASXCORTEEMAIL,

HABVENTASAFUTURO = @HABVENTASAFUTURO,

SERVICIOSEMIDA = @SERVICIOSEMIDA,

FECHAACTUALIZACIONEMIDA = @FECHAACTUALIZACIONEMIDA,

FORMATOTICKETCORTOID= @FORMATOTICKETCORTOID,

SERIESATABONO = @SERIESATABONO,

HABIMPRESIONCORTECAJERO = @HABIMPRESIONCORTECAJERO,

HABTRASLADOPORAUTORIZACION = @HABTRASLADOPORAUTORIZACION,

HABVENTASMOSTRADOR = @HABVENTASMOSTRADOR,

TIMEOUTPINDISTSALE = @TIMEOUTPINDISTSALE,

TIMEOUTLOOKUP = @TIMEOUTLOOKUP,

RUTAARCHIVOSADJUNTOS = @RUTAARCHIVOSADJUNTOS,

TIMEOUTPINDISTSALESERV = @TIMEOUTPINDISTSALESERV,

HABPAGOSERVEMIDA = @HABPAGOSERVEMIDA,

HABPROMOXMONTOMIN = @HABPROMOXMONTOMIN,

MONTOMAXSALDOMENOR = @MONTOMAXSALDOMENOR,

FORMATOFACTELECT = @FORMATOFACTELECT, 

EMIDARECARGALINEAID = @EMIDARECARGALINEAID,

EMIDARECARGAMARCAID = @EMIDARECARGAMARCAID,

EMIDARECARGAPROVEEDORID = @EMIDARECARGAPROVEEDORID,

EMIDASERVICIOLINEAID = @EMIDASERVICIOLINEAID, 

EMIDASERVICIOMARCAID = @EMIDASERVICIOMARCAID, 

EMIDASERVICIOPROVEEDORID = @EMIDASERVICIOPROVEEDORID,

EMIDAPORCUTILIDADRECARGAS = @EMIDAPORCUTILIDADRECARGAS,

EMIDAUTILIDADPAGOSERVICIOS = @EMIDAUTILIDADPAGOSERVICIOS,

BANCOMERHABPINPAD = @BANCOMERHABPINPAD,

PRECIOSORDENADOS = @PRECIOSORDENADOS,

DECIMALESENCANTIDAD = @DECIMALESENCANTIDAD ,

EANPUEDEREPETIRSE = @EANPUEDEREPETIRSE,

HAB_PRECIOSCLIENTE = @HAB_PRECIOSCLIENTE,

CXCVALIDARTRASLADOS = @CXCVALIDARTRASLADOS,

PREGUNTARSIESACREDITO = @PREGUNTARSIESACREDITO,

HABMENSAJERIA = @HABMENSAJERIA,

WSMENSAJERIA = @WSMENSAJERIA,

HABDESCLINEAPERSONA = @HABDESCLINEAPERSONA,

MANEJARLOTEIMPORTACION = @MANEJARLOTEIMPORTACION,

MANEJAGASTOSADIC = @MANEJAGASTOSADIC,

CADUCIDADMINIMA = @CADUCIDADMINIMA,

PRECIOAJUSTEDIFINV = @PRECIOAJUSTEDIFINV, 

HABBOTONPAGOVALE = @HABBOTONPAGOVALE,

UNICAVISITAPORDOCTO = @UNICAVISITAPORDOCTO,

PLAZOXPRODUCTO = @PLAZOXPRODUCTO,

AUTOCOMPLETECONEXISENVENTA = @AUTOCOMPLETECONEXISENVENTA, 

IPWEBSERVICEAPPINV = @IPWEBSERVICEAPPINV,

RUTABDAPPINVENTARO = @RUTABDAPPINVENTARO, 

RUTADBFEXISTENCIASUC = @RUTADBFEXISTENCIASUC,

APLICARCAMBIOSPRECAUTO = @APLICARCAMBIOSPRECAUTO,

NUMCANCELACTAUTO = @NUMCANCELACTAUTO,

ALMACENRECEPCIONID = @ALMACENRECEPCIONID,

MANEJACUPONES = @MANEJACUPONES,

HAB_DEVOLUCIONTRASLADO = @HAB_DEVOLUCIONTRASLADO,

HAB_DEVOLUCIONSURTIDOSUC = @HAB_DEVOLUCIONSURTIDOSUC,

VERSIONWSEXISTENCIAS = @VERSIONWSEXISTENCIAS,

MOSTRARINVINFOADICPROD = @MOSTRARINVINFOADICPROD, 

MANEJAPRODUCTOSPROMOCION = @MANEJAPRODUCTOSPROMOCION,

SAT_METODOPAGOID = @SAT_METODOPAGOID,

SAT_REGIMENFISCALID = @SAT_REGIMENFISCALID,

TIPOSELECCIONCATALOGOSAT = @TIPOSELECCIONCATALOGOSAT,

PRECIONETOENGRIDS = @PRECIONETOENGRIDS,

PAGOSERVCONSOLIDADO = @PAGOSERVCONSOLIDADO,

WSESPECIALEXISTMATRIZ = @WSESPECIALEXISTMATRIZ, 

RUTAREPLICADOREXE = @RUTAREPLICADOREXE,

HAB_CONSOLIDADOAUTOMATICO = @HAB_CONSOLIDADOAUTOMATICO,

TICKETESPECIAL = @TICKETESPECIAL,

TICKETDEFAULTPRINTER = @TICKETDEFAULTPRINTER,

RECARGASDEFAULTPRINTER = @RECARGASDEFAULTPRINTER,

PIEZACAJAENTICKET = @PIEZACAJAENTICKET,

NUMTICKETSABONO = @NUMTICKETSABONO,

PVCOLOREAR = @PVCOLOREAR,


GENERARFE = @GENERARFE,

INTENTOSRETIROCAJA = @INTENTOSRETIROCAJA,


VENDEDORMOVILCLAVE = @VENDEDORMOVILCLAVE,

MOVIL_TIENEVENDEDORES = @MOVIL_TIENEVENDEDORES,

RUTACATALOGOSUPD = @RUTACATALOGOSUPD,

IMPRIMIRCOPIAALMACEN = @IMPRIMIRCOPIAALMACEN, 

MOVIL3_PREIMPORTAR = @MOVIL3_PREIMPORTAR,

RUTAIMPORTADATOS = @RUTAIMPORTADATOS, 

BUSQUEDATIPO2 = @BUSQUEDATIPO2,

VERSIONCFDI = @VERSIONCFDI,

AGRUPACIONVENTAID = @AGRUPACIONVENTAID,

CONSFACTOMITIRVALES = @CONSFACTOMITIRVALES,

DESTINOBDVENMOV = @DESTINOBDVENMOV,

DOBLECOPIACONTADO = @DOBLECOPIACONTADO,

DESGLOSEIEPSFACTURA = @DESGLOSEIEPSFACTURA,

RUTAPOLIZAPDF = @RUTAPOLIZAPDF,

IMPRIMIRBANCOSCORTE = @IMPRIMIRBANCOSCORTE,

IMPR_CANC_VENTA = @IMPR_CANC_VENTA,

RETIROCAJAALCERRARCORTE = @RETIROCAJAALCERRARCORTE,

PAGOTARJMENORPRECIOLISTAALL = @PAGOTARJMENORPRECIOLISTAALL,

PREGUNTARSERVDOM = @PREGUNTARSERVDOM,

HABPPC = @HABPPC,

SOLOABONOAPLICADO = @SOLOABONOAPLICADO,

VERSIONTOPEID = @VERSIONTOPEID,

VERSIONCOMISIONID = @VERSIONCOMISIONID,

MAXCOMISIONXCLIENTE = @MAXCOMISIONXCLIENTE,

IMPRFORMAVENTATRASL = @IMPRFORMAVENTATRASL,

HABREVISIONFINAL = @HABREVISIONFINAL,

RECIBOLARGOCOTIPRINTER = @RECIBOLARGOCOTIPRINTER,

HABFONDODINAMICO = @HABFONDODINAMICO,

HABVENTACLISUC = @HABVENTACLISUC,


SEGUNDOSCICLOFTP = @SEGUNDOSCICLOFTP,
DIASMAXEXPFTP = @DIASMAXEXPFTP,
DIASMAXIMPFTP = @DIASMAXIMPFTP,
WSDBF = @WSDBF,
HABWSDBF = @HABWSDBF,

FISCALFECHACANCELACION2 = @FISCALFECHACANCELACION2,
CANTTICKETRETIRO = @CANTTICKETRETIRO,
COMISIONDEBPORTARJETA = @COMISIONDEBPORTARJETA,
DOBLECOPIATARJETA = @DOBLECOPIATARJETA,
FACTCONSMAXPOR = @FACTCONSMAXPOR,
COMISIONDEBTARJETAEMPRESA = @COMISIONDEBTARJETAEMPRESA,
CANTTICKETABRIRCORTE = @CANTTICKETABRIRCORTE,
CANTTICKETCOMPRAS = @CANTTICKETCOMPRAS,
CANTTICKETFONDOCAJA = @CANTTICKETFONDOCAJA,
CANTTICKETGASTOS = @CANTTICKETGASTOS,
CANTTICKETDEPOSITOS = @CANTTICKETDEPOSITOS,
CANTTICKETCIERRECORTE = @CANTTICKETCIERRECORTE,
CANTTICKETCIERREBILLETES = @CANTTICKETCIERREBILLETES,


MANEJAUTILIDADPRECIOS = @MANEJAUTILIDADPRECIOS,
HABMULTPLAZOCOMPRA = @HABMULTPLAZOCOMPRA,
COSTOREPOIGUALCOSTOULT = @COSTOREPOIGUALCOSTOULT,

TICKET_DESC_VALE_AL_FINAL = @TICKET_DESC_VALE_AL_FINAL,

MONEDEROCAMPOREF = @MONEDEROCAMPOREF,
MONEDEROLISTAPRECIOID = @MONEDEROLISTAPRECIOID,

HABSURTIDOPREVIO = @HABSURTIDOPREVIO,

NUMTICKETSCOMANDA = @NUMTICKETSCOMANDA,
RECIBOPREVIEWCOMANDA = @RECIBOPREVIEWCOMANDA,
IMPRESORACOMANDA = @IMPRESORACOMANDA,

TICKET_IMPR_DESC2 = @TICKET_IMPR_DESC2,

SERIECOMPRTRASLSAT = @SERIECOMPRTRASLSAT,

HABSURTIDOPOSTMOVIL = @HABSURTIDOPOSTMOVIL,

PORCUTILIDADLISTADO = @PORCUTILIDADLISTADO,

RUTAFIRMAIMAGENES = @RUTAFIRMAIMAGENES,


LISTAPRECIOMAYLINEA = @LISTAPRECIOMAYLINEA,
LISTAPRECMEDMAYLINEA = @LISTAPRECMEDMAYLINEA,
AUTPRECIOLISTABAJO = @AUTPRECIOLISTABAJO,

PORCUTILMACROLISTADO = @PORCUTILMACROLISTADO

"
                                     ;
                 
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                



                 parts = new ArrayList();

                auxPar = new FbParameter("@TEXTO1", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["ITEXTO1"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ITEXTO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TEXTO2", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["ITEXTO2"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ITEXTO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TEXTO3", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["ITEXTO3"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ITEXTO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TEXTO4", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["ITEXTO4"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ITEXTO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TEXTO5", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["ITEXTO5"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ITEXTO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TEXTO6", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["ITEXTO6"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ITEXTO6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMERO1", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["INUMERO1"])
                {
                    auxPar.Value = oCPARAMETRONuevo.INUMERO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMERO2", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["INUMERO2"])
                {
                    auxPar.Value = oCPARAMETRONuevo.INUMERO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMERO3", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["INUMERO3"])
                {
                    auxPar.Value = oCPARAMETRONuevo.INUMERO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMERO4", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["INUMERO4"])
                {
                    auxPar.Value = oCPARAMETRONuevo.INUMERO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHA1", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IFECHA1"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IFECHA1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHA2", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IFECHA2"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IFECHA2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                commandText = @"
  update  PROD_DEF_CARACTERISTICAS
set 
TEXTO1=@TEXTO1,

TEXTO2=@TEXTO2,

TEXTO3=@TEXTO3,

TEXTO4=@TEXTO4,

TEXTO5=@TEXTO5,

TEXTO6=@TEXTO6,

NUMERO1=@NUMERO1,

NUMERO2=@NUMERO2,

NUMERO3=@NUMERO3,

NUMERO4=@NUMERO4,

FECHA1=@FECHA1,

FECHA2=@FECHA2
 ";
                arParms = new FbParameter[parts.Count];
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



        public bool CambiarUltimaFechaCambioProdPARAMETROD(CPARAMETROBE oCPARAMETRONuevo, CPARAMETROBE oCPARAMETROAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ULT_FECHA_IMP_PROD", FbDbType.Date);
                if (!(bool)oCPARAMETRONuevo.isnull["IULT_FECHA_IMP_PROD"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IULT_FECHA_IMP_PROD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  PARAMETRO
  set ULT_FECHA_IMP_PROD = @ULT_FECHA_IMP_PROD
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



        public bool CambiarMOVIL_ULTCAM_SESION(CPARAMETROBE oCPARAMETRONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@MOVIL_ULTCAM_SESION", FbDbType.TimeStamp);
                if (!(bool)oCPARAMETRONuevo.isnull["IMOVIL_ULTCAM_SESION"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IMOVIL_ULTCAM_SESION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  PARAMETRO
  set MOVIL_ULTCAM_SESION = @MOVIL_ULTCAM_SESION
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



        public bool CambiarLASTCHANGEPRECIOPROD(CPARAMETROBE oCPARAMETRONuevo, CPARAMETROBE oCPARAMETROAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@LASTCHANGEPRECIOPROD", FbDbType.TimeStamp);
                if (!(bool)oCPARAMETRONuevo.isnull["ILASTCHANGEPRECIOPROD"])
                {
                    auxPar.Value = oCPARAMETRONuevo.ILASTCHANGEPRECIOPROD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  PARAMETRO
  set LASTCHANGEPRECIOPROD = @LASTCHANGEPRECIOPROD
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



        public bool CambiarMOVILPROCESOSURTIDO(CPARAMETROBE oCPARAMETRONuevo, CPARAMETROBE oCPARAMETROAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@MOVILPROCESOSURTIDO", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IMOVILPROCESOSURTIDO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IMOVILPROCESOSURTIDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  PARAMETRO
  set MOVILPROCESOSURTIDO = @MOVILPROCESOSURTIDO
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



        public bool CambiarULT_CONSOLIDADOAUTOMATICOPARAMETROD(CPARAMETROBE oCPARAMETRONuevo, CPARAMETROBE oCPARAMETROAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ULT_CONSOLIDADOAUTOMATICO", FbDbType.Date);
                if (!(bool)oCPARAMETRONuevo.isnull["IULT_CONSOLIDADOAUTOMATICO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IULT_CONSOLIDADOAUTOMATICO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  PARAMETRO
  set ULT_CONSOLIDADOAUTOMATICO = @ULT_CONSOLIDADOAUTOMATICO
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



        public bool MOVILPROCESOSURTIDOUPDATE(FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"MOVILPROCESOSURTIDOUPDATE";

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
                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), this.sCadenaConexion, null);
                        this.iComentario = "Hubo un error " + strMensajeErr;
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





        public bool CambiarUSARCONEXIONLOCALPARAMETROD(CPARAMETROBE oCPARAMETRONuevo, CPARAMETROBE oCPARAMETROAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@USARCONEXIONLOCAL", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IUSARCONEXIONLOCAL"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IUSARCONEXIONLOCAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  PARAMETRO
  set USARCONEXIONLOCAL = @USARCONEXIONLOCAL
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

       
        public CPARAMETROBE seleccionarPARAMETRO(CPARAMETROBE oCPARAMETRO, FbTransaction st)
        {
            CPARAMETROBE retorno = new CPARAMETROBE();
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from PARAMETRO where
 SUCURSALID=@SUCURSALID    and
 SUCURSALNUMERO=@SUCURSALNUMERO    and
 CORTEACTUALID=@CORTEACTUALID    and
 CAJEROACTUALID=@CAJEROACTUALID    and
 NOMBRE=@NOMBRE    and
 CALLE=@CALLE    and
 COLONIA=@COLONIA    and
 LOCALIDAD=@LOCALIDAD    and
 ESTADO=@ESTADO    and
 CP=@CP    and
 TELEFONO=@TELEFONO    and
 FAX=@FAX    and
 CORREOE=@CORREOE    and
 PAGINAWEB=@PAGINAWEB    and
 RFC=@RFC    and
 LISTA_PRECIO_DEF=@LISTA_PRECIO_DEF    and
 IMP_PROD_DEF=@IMP_PROD_DEF    and
 ESTADO_DEF=@ESTADO_DEF  ";


                auxPar = new FbParameter("@SUCURSALID", FbDbType.Integer);
                auxPar.Value = oCPARAMETRO.ISUCURSALID;
                parts.Add(auxPar);



                auxPar = new FbParameter("@SUCURSALNUMERO", FbDbType.VarChar);
                auxPar.Value = oCPARAMETRO.ISUCURSALNUMERO;
                parts.Add(auxPar);



                auxPar = new FbParameter("@CORTEACTUALID", FbDbType.Integer);
                auxPar.Value = oCPARAMETRO.ICORTEACTUALID;
                parts.Add(auxPar);



                auxPar = new FbParameter("@CAJEROACTUALID", FbDbType.Integer);
                auxPar.Value = oCPARAMETRO.ICAJEROACTUALID;
                parts.Add(auxPar);



                auxPar = new FbParameter("@NOMBRE", FbDbType.Char);
                auxPar.Value = oCPARAMETRO.INOMBRE;
                parts.Add(auxPar);



                auxPar = new FbParameter("@CALLE", FbDbType.Char);
                auxPar.Value = oCPARAMETRO.ICALLE;
                parts.Add(auxPar);



                auxPar = new FbParameter("@COLONIA", FbDbType.Char);
                auxPar.Value = oCPARAMETRO.ICOLONIA;
                parts.Add(auxPar);



                auxPar = new FbParameter("@LOCALIDAD", FbDbType.Char);
                auxPar.Value = oCPARAMETRO.ILOCALIDAD;
                parts.Add(auxPar);



                auxPar = new FbParameter("@ESTADO", FbDbType.Char);
                auxPar.Value = oCPARAMETRO.IESTADO;
                parts.Add(auxPar);



                auxPar = new FbParameter("@CP", FbDbType.Char);
                auxPar.Value = oCPARAMETRO.ICP;
                parts.Add(auxPar);



                auxPar = new FbParameter("@TELEFONO", FbDbType.Char);
                auxPar.Value = oCPARAMETRO.ITELEFONO;
                parts.Add(auxPar);



                auxPar = new FbParameter("@FAX", FbDbType.Char);
                auxPar.Value = oCPARAMETRO.IFAX;
                parts.Add(auxPar);



                auxPar = new FbParameter("@CORREOE", FbDbType.Char);
                auxPar.Value = oCPARAMETRO.ICORREOE;
                parts.Add(auxPar);



                auxPar = new FbParameter("@PAGINAWEB", FbDbType.Char);
                auxPar.Value = oCPARAMETRO.IPAGINAWEB;
                parts.Add(auxPar);



                auxPar = new FbParameter("@RFC", FbDbType.Char);
                auxPar.Value = oCPARAMETRO.IRFC;
                parts.Add(auxPar);



                auxPar = new FbParameter("@LISTA_PRECIO_DEF", FbDbType.Char);
                auxPar.Value = oCPARAMETRO.ILISTA_PRECIO_DEF;
                parts.Add(auxPar);



                auxPar = new FbParameter("@IMP_PROD_DEF", FbDbType.Decimal);
                auxPar.Value = oCPARAMETRO.IIMP_PROD_DEF;
                parts.Add(auxPar);



                auxPar = new FbParameter("@ESTADO_DEF", FbDbType.Char);
                auxPar.Value = oCPARAMETRO.IESTADO_DEF;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["SUCURSALNUMERO"] != System.DBNull.Value)
                    {
                        retorno.ISUCURSALNUMERO = (string)(dr["SUCURSALNUMERO"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (dr["CALLE"] != System.DBNull.Value)
                    {
                        retorno.ICALLE = (string)(dr["CALLE"]);
                    }

                    if (dr["COLONIA"] != System.DBNull.Value)
                    {
                        retorno.ICOLONIA = (string)(dr["COLONIA"]);
                    }

                    if (dr["LOCALIDAD"] != System.DBNull.Value)
                    {
                        retorno.ILOCALIDAD = (string)(dr["LOCALIDAD"]);
                    }

                    if (dr["ESTADO"] != System.DBNull.Value)
                    {
                        retorno.IESTADO = (string)(dr["ESTADO"]);
                    }

                    if (dr["CP"] != System.DBNull.Value)
                    {
                        retorno.ICP = (string)(dr["CP"]);
                    }

                    if (dr["TELEFONO"] != System.DBNull.Value)
                    {
                        retorno.ITELEFONO = (string)(dr["TELEFONO"]);
                    }

                    if (dr["FAX"] != System.DBNull.Value)
                    {
                        retorno.IFAX = (string)(dr["FAX"]);
                    }

                    if (dr["CORREOE"] != System.DBNull.Value)
                    {
                        retorno.ICORREOE = (string)(dr["CORREOE"]);
                    }

                    if (dr["PAGINAWEB"] != System.DBNull.Value)
                    {
                        retorno.IPAGINAWEB = (string)(dr["PAGINAWEB"]);
                    }

                    if (dr["RFC"] != System.DBNull.Value)
                    {
                        retorno.IRFC = (string)(dr["RFC"]);
                    }

                    if (dr["LISTA_PRECIO_DEF"] != System.DBNull.Value)
                    {
                        retorno.ILISTA_PRECIO_DEF = (string)(dr["LISTA_PRECIO_DEF"]);
                    }

                    if (dr["IMP_PROD_DEF"] != System.DBNull.Value)
                    {
                        retorno.IIMP_PROD_DEF = (decimal)(dr["IMP_PROD_DEF"]);
                    }

                    if (dr["ESTADO_DEF"] != System.DBNull.Value)
                    {
                        retorno.IESTADO_DEF = (string)(dr["ESTADO_DEF"]);
                    }

                    if (dr["SUCURSALID"] != System.DBNull.Value)
                    {
                        retorno.ISUCURSALID = int.Parse(dr["SUCURSALID"].ToString());
                    }

                    if (dr["CORTEACTUALID"] != System.DBNull.Value)
                    {
                        retorno.ICORTEACTUALID = int.Parse(dr["CORTEACTUALID"].ToString());
                    }

                    if (dr["CAJEROACTUALID"] != System.DBNull.Value)
                    {
                        retorno.ICAJEROACTUALID = int.Parse(dr["CAJEROACTUALID"].ToString());
                    }



                    if (dr["LISTAPRECIOMINIMO"] != System.DBNull.Value)
                    {
                        retorno.ILISTAPRECIOMINIMO = (long)(dr["LISTAPRECIOMINIMO"]);
                    }

                    if (dr["COMPRAENTIENDA"] != System.DBNull.Value)
                    {
                        retorno.ICOMPRAENTIENDA = (string)(dr["COMPRAENTIENDA"]);
                    }

                    if (dr["IPOS_TYPE"] != System.DBNull.Value)
                    {
                        retorno.IIPOS_TYPE = (long)(dr["IPOS_TYPE"]);
                    }


                    if (dr["HEADER"] != System.DBNull.Value)
                    {
                        retorno.IHEADER = (string)(dr["HEADER"]);
                    }

                    if (dr["FOOTER"] != System.DBNull.Value)
                    {
                        retorno.IFOOTER = (string)(dr["FOOTER"]);
                    }


                    if (dr["COMISIONMEDICO"] != System.DBNull.Value)
                    {
                        retorno.ICOMISIONMEDICO = (decimal)(dr["COMISIONMEDICO"]);
                    }

                    if (dr["COMISIONDEPENDIENTE"] != System.DBNull.Value)
                    {
                        retorno.ICOMISIONDEPENDIENTE = (decimal)(dr["COMISIONDEPENDIENTE"]);
                    }

                    if (dr["MOSTRAR_EXIS_SUC"] != System.DBNull.Value)
                    {
                        retorno.IMOSTRAR_EXIS_SUC = (string)(dr["MOSTRAR_EXIS_SUC"]);
                    }

                    if (dr["REQ_APROBACION_INV"] != System.DBNull.Value)
                    {
                        retorno.IREQ_APROBACION_INV = (string)(dr["REQ_APROBACION_INV"]);
                    }

                    if (dr["REABRIRCORTES"] != System.DBNull.Value)
                    {
                        retorno.IREABRIRCORTES = (string)(dr["REABRIRCORTES"]);
                    }

                    if (dr["ULT_FECHA_IMP_PROD"] != System.DBNull.Value)
                    {
                        retorno.IULT_FECHA_IMP_PROD = (DateTime)dr["ULT_FECHA_IMP_PROD"];
                    }

                    if (dr["IMP_PROD_TOTAL"] != System.DBNull.Value)
                    {
                        retorno.IIMP_PROD_TOTAL = (string)(dr["IMP_PROD_TOTAL"]);
                    }

                    if (dr["NUMEROINTERIOR"] != System.DBNull.Value)
                    {
                        retorno.INUMEROINTERIOR = (string)(dr["NUMEROINTERIOR"]);
                    }
                    if (dr["NUMEROEXTERIOR"] != System.DBNull.Value)
                    {
                        retorno.INUMEROEXTERIOR = (string)(dr["NUMEROEXTERIOR"]);
                    }


                    if (dr["FISCALCALLE"] != System.DBNull.Value)
                    {
                        retorno.IFISCALCALLE = (string)(dr["FISCALCALLE"]);
                    }
                    if (dr["FISCALNUMEROINTERIOR"] != System.DBNull.Value)
                    {
                        retorno.IFISCALNUMEROINTERIOR = (string)(dr["FISCALNUMEROINTERIOR"]);
                    }
                    if (dr["FISCALNUMEROEXTERIOR"] != System.DBNull.Value)
                    {
                        retorno.IFISCALNUMEROEXTERIOR = (string)(dr["FISCALNUMEROEXTERIOR"]);
                    }
                    if (dr["FISCALCOLONIA"] != System.DBNull.Value)
                    {
                        retorno.IFISCALCOLONIA = (string)(dr["FISCALCOLONIA"]);
                    }
                    if (dr["FISCALMUNICIPIO"] != System.DBNull.Value)
                    {
                        retorno.IFISCALMUNICIPIO = (string)(dr["FISCALMUNICIPIO"]);
                    }
                    if (dr["FISCALESTADO"] != System.DBNull.Value)
                    {
                        retorno.IFISCALESTADO = (string)(dr["FISCALESTADO"]);
                    }
                    if (dr["FISCALCODIGOPOSTAL"] != System.DBNull.Value)
                    {
                        retorno.IFISCALCODIGOPOSTAL = (string)(dr["FISCALCODIGOPOSTAL"]);
                    }
                    if (dr["CERTIFICADOCSD"] != System.DBNull.Value)
                    {
                        retorno.ICERTIFICADOCSD = (string)(dr["CERTIFICADOCSD"]);
                    }
                    if (dr["TIMBRADOUSER"] != System.DBNull.Value)
                    {
                        retorno.ITIMBRADOUSER = (string)(dr["TIMBRADOUSER"]);
                    }
                    if (dr["TIMBRADOPASSWORD"] != System.DBNull.Value)
                    {
                        retorno.ITIMBRADOPASSWORD = (string)(dr["TIMBRADOPASSWORD"]);
                    }
                    if (dr["TIMBRADOARCHIVOCERTIFICADO"] != System.DBNull.Value)
                    {
                        retorno.ITIMBRADOARCHIVOCERTIFICADO = (string)(dr["TIMBRADOARCHIVOCERTIFICADO"]);
                    }
                    if (dr["TIMBRADOARCHIVOKEY"] != System.DBNull.Value)
                    {
                        retorno.ITIMBRADOARCHIVOKEY = (string)(dr["TIMBRADOARCHIVOKEY"]);
                    }

                    if (dr["TIMBRADOKEY"] != System.DBNull.Value)
                    {
                        retorno.ITIMBRADOKEY = (string)(dr["TIMBRADOKEY"]);
                    }



                    if (dr["FISCALNOMBRE"] != System.DBNull.Value)
                    {
                        retorno.IFISCALNOMBRE = (string)(dr["FISCALNOMBRE"]);
                    }



                    if (dr["SERIESAT"] != System.DBNull.Value)
                    {
                        retorno.ISERIESAT = (string)(dr["SERIESAT"]);
                    }


                    if (dr["USARFISCALESENEXPEDICION"] != System.DBNull.Value)
                    {
                        retorno.IUSARFISCALESENEXPEDICION = (string)(dr["USARFISCALESENEXPEDICION"]);
                    }

                    if (dr["HAB_FACTURAELECTRONICA"] != System.DBNull.Value)
                    {
                        retorno.IHAB_FACTURAELECTRONICA = (string)(dr["HAB_FACTURAELECTRONICA"]);
                    }


                    if (dr["RECIBOLARGOPRINTER"] != System.DBNull.Value)
                    {
                        retorno.IRECIBOLARGOPRINTER = (string)(dr["RECIBOLARGOPRINTER"]);
                    }
                    if (dr["RECIBOLARGOPREVIEW"] != System.DBNull.Value)
                    {
                        retorno.IRECIBOLARGOPREVIEW = (string)(dr["RECIBOLARGOPREVIEW"]);
                    }


                    if (dr["PREGUNTARRAZONPRECIOMENOR"] != System.DBNull.Value)
                    {
                        retorno.IPREGUNTARRAZONPRECIOMENOR = (string)(dr["PREGUNTARRAZONPRECIOMENOR"]);
                    }
                    else
                    {
                        retorno.IPREGUNTARRAZONPRECIOMENOR = "N";
                    }


                    if (dr["FISCALREGIMEN"] != System.DBNull.Value)
                    {
                        retorno.IFISCALREGIMEN = (string)(dr["FISCALREGIMEN"]);
                    }
                    else
                    {
                        retorno.IFISCALREGIMEN = "";
                    }


                    if (dr["CORTACADUCIDAD"] != System.DBNull.Value)
                    {
                        retorno.ICORTACADUCIDAD = (int)(dr["CORTACADUCIDAD"]);
                    }
                    else
                    {
                        retorno.ICORTACADUCIDAD = 0;
                    }



                    if (dr["RETENCIONIVA"] != System.DBNull.Value)
                    {
                        retorno.IRETENCIONIVA = (decimal)(dr["RETENCIONIVA"]);
                    }

                    if (dr["RETENCIONISR"] != System.DBNull.Value)
                    {
                        retorno.IRETENCIONISR = (decimal)(dr["RETENCIONISR"]);
                    }


                    if (dr["ARRENDATARIO"] != System.DBNull.Value)
                    {
                        retorno.IARRENDATARIO = (string)(dr["ARRENDATARIO"]);
                    }
                    else
                    {
                        retorno.IFISCALREGIMEN = "N";
                    }


                    if (dr["RUTAIMAGENESPRODUCTO"] != System.DBNull.Value)
                    {
                        retorno.IRUTAIMAGENESPRODUCTO = (string)(dr["RUTAIMAGENESPRODUCTO"]);
                    }

                    if (dr["MOSTRARMONTOAHORRO"] != System.DBNull.Value)
                    {
                        retorno.IMOSTRARMONTOAHORRO = (string)(dr["MOSTRARMONTOAHORRO"]);
                    }


                    if (dr["MOSTRARDESCUENTOFACTURA"] != System.DBNull.Value)
                    {
                        retorno.IMOSTRARDESCUENTOFACTURA = (string)(dr["MOSTRARDESCUENTOFACTURA"]);
                    }

                    if (dr["EXPORTCATALOGOAUX"] != System.DBNull.Value)
                    {
                        retorno.IEXPORTCATALOGOAUX = (string)(dr["EXPORTCATALOGOAUX"]);
                    }

                    if (dr["DIVIDIR_REM_FACT"] != System.DBNull.Value)
                    {
                        retorno.IDIVIDIR_REM_FACT = (string)(dr["DIVIDIR_REM_FACT"]);
                    }


                    if (dr["MINUTILIDAD"] != System.DBNull.Value)
                    {
                        retorno.IMINUTILIDAD = (decimal)(dr["MINUTILIDAD"]);
                    }



                    if (dr["CLIENTECONSOLIDADOID"] != System.DBNull.Value)
                    {
                        retorno.ICLIENTECONSOLIDADOID = (long)(dr["CLIENTECONSOLIDADOID"]);
                    }
                    else
                    {
                        retorno.ICLIENTECONSOLIDADOID = 1;
                    }

                    if (dr["CADUCIDADMINIMA"] != System.DBNull.Value)
                    {
                        retorno.ICADUCIDADMINIMA = (int)(dr["CADUCIDADMINIMA"]);
                    }
                    else
                    {
                        retorno.ICADUCIDADMINIMA = 0;
                    }



                    if (dr["PRECIOAJUSTEDIFINV"] != System.DBNull.Value)
                    {
                        retorno.IPRECIOAJUSTEDIFINV = (string)(dr["PRECIOAJUSTEDIFINV"]);
                    }

                    if (dr["HABBOTONPAGOVALE"] != System.DBNull.Value)
                    {
                        retorno.IHABBOTONPAGOVALE = (string)(dr["HABBOTONPAGOVALE"]);
                    }

                    if (dr["UNICAVISITAPORDOCTO"] != System.DBNull.Value)
                    {
                        retorno.IUNICAVISITAPORDOCTO = (string)(dr["UNICAVISITAPORDOCTO"]);
                    }

                    if (dr["IPWEBSERVICEAPPINV"] != System.DBNull.Value)
                    {
                        retorno.IIPWEBSERVICEAPPINV = (string)(dr["IPWEBSERVICEAPPINV"]);
                    }

                    if (dr["RUTABDAPPINVENTARO"] != System.DBNull.Value)
                    {
                        retorno.IRUTABDAPPINVENTARO = (string)(dr["RUTABDAPPINVENTARO"]);
                    }

                    if (dr["AUTOCOMPLETECONEXISENVENTA"] != System.DBNull.Value)
                    {
                        retorno.IAUTOCOMPLETECONEXISENVENTA = (string)(dr["AUTOCOMPLETECONEXISENVENTA"]);
                    }

                    if (dr["APLICARCAMBIOSPRECAUTO"] != System.DBNull.Value)
                    {
                        retorno.IAPLICARCAMBIOSPRECAUTO = (string)(dr["APLICARCAMBIOSPRECAUTO"]);
                    }

                    if (dr["NUMCANCELACTAUTO"] != System.DBNull.Value)
                    {
                        retorno.INUMCANCELACTAUTO = (int)(dr["NUMCANCELACTAUTO"]);
                    }

                    if (dr["NUMCANCELACTAUTOUSUARIO"] != System.DBNull.Value)
                    {
                        retorno.INUMCANCELACTAUTOUSUARIO = (int)(dr["NUMCANCELACTAUTOUSUARIO"]);
                    }

                    if (dr["MANEJACUPONES"] != System.DBNull.Value)
                    {
                        retorno.IMANEJACUPONES = (string)(dr["MANEJACUPONES"]);
                    }

                    if (dr["RUTADBFEXISTENCIASUC"] != System.DBNull.Value)
                    {
                        retorno.IRUTADBFEXISTENCIASUC = (string)(dr["RUTADBFEXISTENCIASUC"]);
                    }



                    if (dr["ALMACENRECEPCIONID"] != System.DBNull.Value)
                    {
                        retorno.IALMACENRECEPCIONID = (long)(dr["ALMACENRECEPCIONID"]);
                    }

                    if (dr["TIPOSELECCIONCATALOGOSAT"] != System.DBNull.Value)
                    {
                        retorno.ITIPOSELECCIONCATALOGOSAT = dr["TIPOSELECCIONCATALOGOSAT"].ToString();
                    }


                    if (dr["SAT_METODOPAGOID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_METODOPAGOID = (long)(dr["SAT_METODOPAGOID"]);
                    }

                    if (dr["SAT_REGIMENFISCALID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_REGIMENFISCALID = (long)(dr["SAT_REGIMENFISCALID"]);
                    }


                    if (dr["SAT_METODOPAGOCLAVE"] != System.DBNull.Value)
                    {
                        retorno.ISAT_METODOPAGOCLAVE = (string)(dr["SAT_METODOPAGOCLAVE"]);
                    }

                    if (dr["SAT_REGIMENFISCALCLAVE"] != System.DBNull.Value)
                    {
                        retorno.ISAT_REGIMENFISCALCLAVE = (string)(dr["SAT_REGIMENFISCALCLAVE"]);
                    }


                    if (dr["PAGOSERVCONSOLIDADO"] != System.DBNull.Value)
                    {
                        retorno.IPAGOSERVCONSOLIDADO = (string)(dr["PAGOSERVCONSOLIDADO"]);

                    }



                    if (dr["WSESPECIALEXISTMATRIZ"] != System.DBNull.Value)
                    {
                        retorno.IWSESPECIALEXISTMATRIZ = (string)(dr["WSESPECIALEXISTMATRIZ"]);
                    }


                    if (dr["RUTAREPLICADOREXE"] != System.DBNull.Value)
                    {
                        retorno.IRUTAREPLICADOREXE = (string)(dr["RUTAREPLICADOREXE"]);
                    }

                    if (dr["HAB_CONSOLIDADOAUTOMATICO"] != System.DBNull.Value)
                    {
                        retorno.IHAB_CONSOLIDADOAUTOMATICO = (string)(dr["HAB_CONSOLIDADOAUTOMATICO"]);
                    }

                    if (dr["ULT_CONSOLIDADOAUTOMATICO"] != System.DBNull.Value)
                    {
                        retorno.IULT_CONSOLIDADOAUTOMATICO = (DateTime)dr["ULT_CONSOLIDADOAUTOMATICO"];
                    }

                    if (dr["TICKETESPECIAL"] != System.DBNull.Value)
                    {
                        retorno.ITICKETESPECIAL = (string)(dr["TICKETESPECIAL"]);
                    }


                    if (dr["TICKETDEFAULTPRINTER"] != System.DBNull.Value)
                    {
                        retorno.ITICKETDEFAULTPRINTER = (string)(dr["TICKETDEFAULTPRINTER"]);
                    }

                    if (dr["RECARGASDEFAULTPRINTER"] != System.DBNull.Value)
                    {
                        retorno.IRECARGASDEFAULTPRINTER = (string)(dr["RECARGASDEFAULTPRINTER"]);
                    }

                    if (dr["PIEZACAJAENTICKET"] != System.DBNull.Value)
                    {
                        retorno.IPIEZACAJAENTICKET = (string)(dr["PIEZACAJAENTICKET"]);
                    }

                    if (dr["NUMTICKETSABONO"] != System.DBNull.Value)
                    {
                        retorno.INUMTICKETSABONO = (int)(dr["NUMTICKETSABONO"]);
                    }

                    if (dr["PVCOLOREAR"] != System.DBNull.Value)
                    {
                        retorno.IPVCOLOREAR = (int)(dr["PVCOLOREAR"]);
                    }





                    if (dr["GENERARFE"] != DBNull.Value)
                    {
                        retorno.IGENERARFE = (string)(dr["GENERARFE"]);
                    }


                    if (dr["INTENTOSRETIROCAJA"] != System.DBNull.Value)
                    {
                        retorno.IINTENTOSRETIROCAJA = (int)(dr["INTENTOSRETIROCAJA"]);
                    }

                    if (dr["VENDEDORMOVILCLAVE"] != System.DBNull.Value)
                    {
                        retorno.IVENDEDORMOVILCLAVE = (string)(dr["VENDEDORMOVILCLAVE"]);
                    }


                    if (dr["MOVIL_ULTCAM_SESION"] != System.DBNull.Value)
                    {
                        retorno.IMOVIL_ULTCAM_SESION = (DateTime)(dr["MOVIL_ULTCAM_SESION"]);
                    }

                    if (dr["MOVIL_TIENEVENDEDORES"] != System.DBNull.Value)
                    {
                        retorno.IMOVIL_TIENEVENDEDORES = (string)(dr["MOVIL_TIENEVENDEDORES"]);
                    }

                    if (dr["RUTACATALOGOSUPD"] != System.DBNull.Value)
                    {
                        retorno.IRUTACATALOGOSUPD = (string)(dr["RUTACATALOGOSUPD"]);
                    }


                    if (dr["IMPRIMIRCOPIAALMACEN"] != System.DBNull.Value)
                    {
                        retorno.IIMPRIMIRCOPIAALMACEN = (string)(dr["IMPRIMIRCOPIAALMACEN"]);
                    }

                    if (dr["MOVIL3_PREIMPORTAR"] != System.DBNull.Value)
                    {
                        retorno.IMOVIL3_PREIMPORTAR = (string)(dr["MOVIL3_PREIMPORTAR"]);
                    }

                    if (dr["RUTAIMPORTADATOS"] != System.DBNull.Value)
                    {
                        retorno.IRUTAIMPORTADATOS = (string)(dr["RUTAIMPORTADATOS"]);
                    }

                    if (dr["BUSQUEDATIPO2"] != System.DBNull.Value)
                    {
                        retorno.IBUSQUEDATIPO2 = (string)(dr["BUSQUEDATIPO2"]);
                    }

                    if (dr["AGRUPACIONVENTAID"] != System.DBNull.Value)
                    {
                        retorno.IAGRUPACIONVENTAID = (long)(dr["AGRUPACIONVENTAID"]);
                    }


                    if (dr["CONSFACTOMITIRVALES"] != System.DBNull.Value)
                    {
                        retorno.ICONSFACTOMITIRVALES = (string)(dr["CONSFACTOMITIRVALES"]);
                    }


                    if (dr["DESTINOBDVENMOV"] != DBNull.Value)
                    {
                        retorno.IDESTINOBDVENMOV = dr["DESTINOBDVENMOV"].ToString();
                    }


                    if (dr["DOBLECOPIACONTADO"] != System.DBNull.Value)
                    {
                        retorno.IDOBLECOPIACONTADO = (int)(dr["DOBLECOPIACONTADO"]);
                    }

                    if (dr["DESGLOSEIEPSFACTURA"] != DBNull.Value)
                    {
                        retorno.IDESGLOSEIEPSFACTURA = dr["DESGLOSEIEPSFACTURA"].ToString();
                    }

                    if (dr["RUTAPOLIZAPDF"] != System.DBNull.Value)
                    {
                        retorno.IRUTAPOLIZAPDF = (string)(dr["RUTAPOLIZAPDF"]);
                    }

                    if (dr["IMPRIMIRBANCOSCORTE"] != System.DBNull.Value)
                    {
                        retorno.IIMPRIMIRBANCOSCORTE = (string)(dr["IMPRIMIRBANCOSCORTE"]);
                    }

                    if (dr["IMPR_CANC_VENTA"] != System.DBNull.Value)
                    {
                        retorno.IIMPR_CANC_VENTA = (string)(dr["IMPR_CANC_VENTA"]);
                    }

                    if (dr["RETIROCAJAALCERRARCORTE"] != System.DBNull.Value)
                    {
                        retorno.IRETIROCAJAALCERRARCORTE = (string)(dr["RETIROCAJAALCERRARCORTE"]);
                    }

                    if (dr["PAGOTARJMENORPRECIOLISTAALL"] != System.DBNull.Value)
                    {
                        retorno.IPAGOTARJMENORPRECIOLISTAALL = (string)(dr["PAGOTARJMENORPRECIOLISTAALL"]);
                    }


                    if (dr["PREGUNTARSERVDOM"] != System.DBNull.Value)
                    {
                        retorno.IPREGUNTARSERVDOM = (string)(dr["PREGUNTARSERVDOM"]);
                    }


                    if (dr["HABPPC"] != System.DBNull.Value)
                    {
                        retorno.IHABPPC = (string)(dr["HABPPC"]);
                    }

                    if (dr["SOLOABONOAPLICADO"] != System.DBNull.Value)
                    {
                        retorno.ISOLOABONOAPLICADO = (string)(dr["SOLOABONOAPLICADO"]);
                    }


                    if (dr["VERSIONTOPEID"] != System.DBNull.Value)
                    {
                        retorno.IVERSIONTOPEID = (long)(dr["VERSIONTOPEID"]);
                    }


                    if (dr["VERSIONCOMISIONID"] != System.DBNull.Value)
                    {
                        retorno.IVERSIONCOMISIONID = (long)(dr["VERSIONCOMISIONID"]);
                    }


                    if (dr["MAXCOMISIONXCLIENTE"] != System.DBNull.Value)
                    {
                        retorno.IMAXCOMISIONXCLIENTE = (decimal)(dr["MAXCOMISIONXCLIENTE"]);
                    }

                    if (dr["IMPRFORMAVENTATRASL"] != System.DBNull.Value)
                    {
                        retorno.IIMPRFORMAVENTATRASL = (string)(dr["IMPRFORMAVENTATRASL"]);
                    }


                    if (dr["HABREVISIONFINAL"] != System.DBNull.Value)
                    {
                        retorno.IHABREVISIONFINAL = (string)(dr["HABREVISIONFINAL"]);
                    }

                    if (dr["RECIBOLARGOCOTIPRINTER"] != System.DBNull.Value)
                    {
                        retorno.IRECIBOLARGOCOTIPRINTER = (string)(dr["RECIBOLARGOCOTIPRINTER"]);
                    }


                    if (dr["HABFONDODINAMICO"] != System.DBNull.Value)
                    {
                        retorno.IHABFONDODINAMICO = (string)(dr["HABFONDODINAMICO"]);
                    }


                    if (dr["HABVENTACLISUC"] != System.DBNull.Value)
                    {
                        retorno.IHABVENTACLISUC = (string)(dr["HABVENTACLISUC"]);
                    }



                    if (dr["SEGUNDOSCICLOFTP"] != System.DBNull.Value)
                    {
                        retorno.ISEGUNDOSCICLOFTP = (int)(dr["SEGUNDOSCICLOFTP"]);
                    }

                    if (dr["DIASMAXEXPFTP"] != System.DBNull.Value)
                    {
                        retorno.IDIASMAXEXPFTP = (int)(dr["DIASMAXEXPFTP"]);
                    }

                    if (dr["DIASMAXIMPFTP"] != System.DBNull.Value)
                    {
                        retorno.IDIASMAXIMPFTP = (int)(dr["DIASMAXIMPFTP"]);
                    }

                    if (dr["WSDBF"] != System.DBNull.Value)
                    {
                        retorno.IWSDBF = (string)(dr["WSDBF"]);
                    }

                    if (dr["HABWSDBF"] != System.DBNull.Value)
                    {
                        retorno.IHABWSDBF = (string)(dr["HABWSDBF"]);
                    }





                    if (dr["FISCALFECHACANCELACION2"] != System.DBNull.Value)
                    {
                        retorno.IFISCALFECHACANCELACION2 = (DateTime)(dr["FISCALFECHACANCELACION2"]);
                    }

                    if (dr["CANTTICKETRETIRO"] != System.DBNull.Value)
                    {
                        retorno.ICANTTICKETRETIRO = (int)(dr["CANTTICKETRETIRO"]);
                    }

                    if (dr["COMISIONDEBPORTARJETA"] != System.DBNull.Value)
                    {
                        retorno.ICOMISIONDEBPORTARJETA = (decimal)(dr["COMISIONDEBPORTARJETA"]);
                    }

                    if (dr["DOBLECOPIATARJETA"] != System.DBNull.Value)
                    {
                        retorno.IDOBLECOPIATARJETA = (int)(dr["DOBLECOPIATARJETA"]);
                    }

                    if (dr["FACTCONSMAXPOR"] != System.DBNull.Value)
                    {
                        retorno.IFACTCONSMAXPOR = (decimal)(dr["FACTCONSMAXPOR"]);
                    }

                    if (dr["COMISIONDEBTARJETAEMPRESA"] != System.DBNull.Value)
                    {
                        retorno.ICOMISIONDEBTARJETAEMPRESA = (decimal)(dr["COMISIONDEBTARJETAEMPRESA"]);
                    }


                    if (dr["CANTTICKETABRIRCORTE"] != System.DBNull.Value)
                    {
                        retorno.ICANTTICKETABRIRCORTE = (int)(dr["CANTTICKETABRIRCORTE"]);
                    }

                    if (dr["CANTTICKETCOMPRAS"] != System.DBNull.Value)
                    {
                        retorno.ICANTTICKETCOMPRAS = (int)(dr["CANTTICKETCOMPRAS"]);
                    }

                    if (dr["CANTTICKETFONDOCAJA"] != System.DBNull.Value)
                    {
                        retorno.ICANTTICKETFONDOCAJA = (int)(dr["CANTTICKETFONDOCAJA"]);
                    }

                    if (dr["CANTTICKETGASTOS"] != System.DBNull.Value)
                    {
                        retorno.ICANTTICKETGASTOS = (int)(dr["CANTTICKETGASTOS"]);
                    }

                    if (dr["CANTTICKETDEPOSITOS"] != System.DBNull.Value)
                    {
                        retorno.ICANTTICKETDEPOSITOS = (int)(dr["CANTTICKETDEPOSITOS"]);
                    }

                    if (dr["CANTTICKETCIERRECORTE"] != System.DBNull.Value)
                    {
                        retorno.ICANTTICKETCIERRECORTE = (int)(dr["CANTTICKETCIERRECORTE"]);
                    }

                    if (dr["CANTTICKETCIERREBILLETES"] != System.DBNull.Value)
                    {
                        retorno.ICANTTICKETCIERREBILLETES = (int)(dr["CANTTICKETCIERREBILLETES"]);
                    }


                    if (dr["MANEJAUTILIDADPRECIOS"] != System.DBNull.Value)
                    {
                        retorno.IMANEJAUTILIDADPRECIOS = (string)(dr["MANEJAUTILIDADPRECIOS"]);
                    }


                    if (dr["HABMULTPLAZOCOMPRA"] != System.DBNull.Value)
                    {
                        retorno.IHABMULTPLAZOCOMPRA = (string)(dr["HABMULTPLAZOCOMPRA"]);
                    }


                    if (dr["COSTOREPOIGUALCOSTOULT"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOREPOIGUALCOSTOULT = (string)(dr["COSTOREPOIGUALCOSTOULT"]);
                    }

                    if (dr["TICKET_DESC_VALE_AL_FINAL"] != System.DBNull.Value)
                    {
                        retorno.ITICKET_DESC_VALE_AL_FINAL = (string)(dr["TICKET_DESC_VALE_AL_FINAL"]);
                    }



                    if (dr["IMONEDEROLISTAPRECIOID"] != System.DBNull.Value)
                    {
                        retorno.IMONEDEROLISTAPRECIOID = (long)(dr["MONEDEROLISTAPRECIOID"]);
                    }


                    if (dr["MONEDEROCAMPOREF"] != System.DBNull.Value)
                    {
                        retorno.IMONEDEROCAMPOREF = (string)(dr["MONEDEROCAMPOREF"]);
                    }


                    if (dr["TICKET_IMPR_DESC2"] != System.DBNull.Value)
                    {
                        retorno.ITICKET_IMPR_DESC2 = (string)(dr["TICKET_IMPR_DESC2"]);
                    }

                    if (dr["SERIECOMPRTRASLSAT"] != System.DBNull.Value)
                    {
                        retorno.ISERIECOMPRTRASLSAT = (string)(dr["SERIECOMPRTRASLSAT"]);
                    }


                    if (dr["RUTAFIRMAIMAGENES"] != System.DBNull.Value)
                    {
                        retorno.IRUTAFIRMAIMAGENES = (string)(dr["RUTAFIRMAIMAGENES"]);
                    }


                    if (dr["LISTAPRECIOMAYLINEA"] != System.DBNull.Value)
                    {
                        retorno.ILISTAPRECIOMAYLINEA = (long)(dr["LISTAPRECIOMAYLINEA"]);
                    }

                    if (dr["LISTAPRECMEDMAYLINEA"] != System.DBNull.Value)
                    {
                        retorno.ILISTAPRECMEDMAYLINEA = (long)(dr["LISTAPRECMEDMAYLINEA"]);
                    }

                    if (dr["AUTPRECIOLISTABAJO"] != System.DBNull.Value)
                    {
                        retorno.IAUTPRECIOLISTABAJO = (string)(dr["AUTPRECIOLISTABAJO"]);
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





        public CPARAMETROBE seleccionarPARAMETROActual(FbTransaction st)
        {

            CPARAMETROBE retorno = new CPARAMETROBE();
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                String CmdTxt = @"select p.* ,c.texto1,c.texto2 ,c.texto3 , c.texto4, c.texto5, c.texto6,
                                             c.numero1, c.numero2 , c.numero3, c.numero4,
                                             c.fecha1, c.fecha2, t.id as DEFAULTTASAIVAID,
                                             sat_met.sat_clave SAT_METODOPAGOCLAVE,
                                             sat_reg.sat_clave SAT_REGIMENFISCALCLAVE
                                             from PARAMETRO p left join PROD_DEF_CARACTERISTICAS c on  c.id = 1
                                              left join tasaiva t on t.tasa = p.IMP_PROD_DEF
                                              left join sat_metodopago sat_met on sat_met.id = p.sat_metodopagoid
                                              left join sat_regimenfiscal sat_reg on sat_reg.id= p.sat_regimenfiscalid";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


               

                if (dr.Read())
                {

                    if (dr["SUCURSALNUMERO"] != System.DBNull.Value)
                    {
                        retorno.ISUCURSALNUMERO = (string)(dr["SUCURSALNUMERO"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (dr["CALLE"] != System.DBNull.Value)
                    {
                        retorno.ICALLE = (string)(dr["CALLE"]);
                    }

                    if (dr["COLONIA"] != System.DBNull.Value)
                    {
                        retorno.ICOLONIA = (string)(dr["COLONIA"]);
                    }

                    if (dr["LOCALIDAD"] != System.DBNull.Value)
                    {
                        retorno.ILOCALIDAD = (string)(dr["LOCALIDAD"]);
                    }

                    if (dr["ESTADO"] != System.DBNull.Value)
                    {
                        retorno.IESTADO = (string)(dr["ESTADO"]);
                    }

                    if (dr["CP"] != System.DBNull.Value)
                    {
                        retorno.ICP = (string)(dr["CP"]);
                    }

                    if (dr["TELEFONO"] != System.DBNull.Value)
                    {
                        retorno.ITELEFONO = (string)(dr["TELEFONO"]);
                    }

                    if (dr["FAX"] != System.DBNull.Value)
                    {
                        retorno.IFAX = (string)(dr["FAX"]);
                    }

                    if (dr["CORREOE"] != System.DBNull.Value)
                    {
                        retorno.ICORREOE = (string)(dr["CORREOE"]);
                    }

                    if (dr["PAGINAWEB"] != System.DBNull.Value)
                    {
                        retorno.IPAGINAWEB = (string)(dr["PAGINAWEB"]);
                    }

                    if (dr["RFC"] != System.DBNull.Value)
                    {
                        retorno.IRFC = (string)(dr["RFC"]);
                    }

                    if (dr["LISTA_PRECIO_DEF"] != System.DBNull.Value)
                    {
                        retorno.ILISTA_PRECIO_DEF = (string)(dr["LISTA_PRECIO_DEF"]);
                    }

                    if (dr["IMP_PROD_DEF"] != System.DBNull.Value)
                    {
                        retorno.IIMP_PROD_DEF = (decimal)(dr["IMP_PROD_DEF"]);
                    }

                    if (dr["ESTADO_DEF"] != System.DBNull.Value)
                    {
                        retorno.IESTADO_DEF = (string)(dr["ESTADO_DEF"]);
                    }

                    if (dr["SUCURSALID"] != System.DBNull.Value)
                    {
                        retorno.ISUCURSALID = int.Parse(dr["SUCURSALID"].ToString());
                    }

                    if (dr["CORTEACTUALID"] != System.DBNull.Value)
                    {
                        retorno.ICORTEACTUALID = int.Parse(dr["CORTEACTUALID"].ToString());
                    }

                    if (dr["CAJEROACTUALID"] != System.DBNull.Value)
                    {
                        retorno.ICAJEROACTUALID = int.Parse(dr["CAJEROACTUALID"].ToString());
                    }

                    /***Faltan campos*/

                    if (dr["FECHAULTIMA"] != System.DBNull.Value)
                    {
                        retorno.IFECHAULTIMA = (DateTime)dr["FECHAULTIMA"];
                    }


                    if (dr["MAX_INV_FIS_CANT"] != System.DBNull.Value)
                    {
                        retorno.IMAX_INV_FIS_CANT = decimal.Parse(dr["MAX_INV_FIS_CANT"].ToString());
                    }

                    if (dr["INVENTORY_EMAIL"] != System.DBNull.Value)
                    {
                        retorno.IINVENTORY_EMAIL = dr["INVENTORY_EMAIL"].ToString();
                    }


                    if (dr["ID_DOSLETRAS"] != System.DBNull.Value)
                    {
                        retorno.IID_DOSLETRAS = dr["ID_DOSLETRAS"].ToString();
                    }


                    if (dr["HABILITAR_IMPEXP_AUT"] != System.DBNull.Value)
                    {
                        retorno.IHABILITAR_IMPEXP_AUT = (string)(dr["HABILITAR_IMPEXP_AUT"]);
                    }



                    if (dr["FTPHOST"] != System.DBNull.Value)
                    {
                        retorno.IFTPHOST = (string)(dr["FTPHOST"]);
                    }
                    if (dr["FTPUSUARIO"] != System.DBNull.Value)
                    {
                        retorno.IFTPUSUARIO = (string)(dr["FTPUSUARIO"]);
                    }
                    if (dr["FTPPASSWORD"] != System.DBNull.Value)
                    {
                        retorno.IFTPPASSWORD = (string)(dr["FTPPASSWORD"]);
                    }
                    if (dr["SMTPHOST"] != System.DBNull.Value)
                    {
                        retorno.ISMTPHOST = (string)(dr["SMTPHOST"]);
                    }
                    if (dr["SMTPUSUARIO"] != System.DBNull.Value)
                    {
                        retorno.ISMTPUSUARIO = (string)(dr["SMTPUSUARIO"]);
                    }
                    if (dr["SMTPPASSWORD"] != System.DBNull.Value)
                    {
                        retorno.ISMTPPASSWORD = (string)(dr["SMTPPASSWORD"]);
                    }
                    if (dr["SMTPPORT"] != System.DBNull.Value)
                    {
                        retorno.ISMTPPORT = int.Parse(dr["SMTPPORT"].ToString());
                    }
                    if (dr["SMTPMAILFROM"] != System.DBNull.Value)
                    {
                        retorno.ISMTPMAILFROM = (string)(dr["SMTPMAILFROM"]);
                    }
                    if (dr["SMTPMAILTO"] != System.DBNull.Value)
                    {
                        retorno.ISMTPMAILTO = (string)(dr["SMTPMAILTO"]);
                    }

                    if (dr["CAMBIARPRECIO"] != System.DBNull.Value)
                    {
                        retorno.ICAMBIARPRECIO = (string)(dr["CAMBIARPRECIO"]);
                    }


                    if (dr["LISTAPRECIOMINIMO"] != System.DBNull.Value)
                    {
                        retorno.ILISTAPRECIOMINIMO = (long)(dr["LISTAPRECIOMINIMO"]);
                    }

                    if (dr["COMPRAENTIENDA"] != System.DBNull.Value)
                    {
                        retorno.ICOMPRAENTIENDA = (string)(dr["COMPRAENTIENDA"]);
                    }

                    if (dr["IPOS_TYPE"] != System.DBNull.Value)
                    {
                        retorno.IIPOS_TYPE = (long)(dr["IPOS_TYPE"]);
                    }


                    if (dr["HEADER"] != System.DBNull.Value)
                    {
                        retorno.IHEADER = (string)(dr["HEADER"]);
                    }

                    if (dr["FOOTER"] != System.DBNull.Value)
                    {
                        retorno.IFOOTER = (string)(dr["FOOTER"]);
                    }


                    if (dr["HAB_SEL_CLIENTE"] != System.DBNull.Value)
                    {
                        retorno.IHAB_SEL_CLIENTE = (string)(dr["HAB_SEL_CLIENTE"]);
                    }

                    if (dr["HAB_IMPR_COTIZACION"] != System.DBNull.Value)
                    {
                        retorno.IHAB_IMPR_COTIZACION = (string)(dr["HAB_IMPR_COTIZACION"]);
                    }

                    if (dr["COMISIONMEDICO"] != System.DBNull.Value)
                    {
                        retorno.ICOMISIONMEDICO = (decimal)(dr["COMISIONMEDICO"]);
                    }

                    if (dr["COMISIONDEPENDIENTE"] != System.DBNull.Value)
                    {
                        retorno.ICOMISIONDEPENDIENTE = (decimal)(dr["COMISIONDEPENDIENTE"]);
                    }


                    if (dr["MOSTRAR_EXIS_SUC"] != System.DBNull.Value)
                    {
                        retorno.IMOSTRAR_EXIS_SUC = (string)(dr["MOSTRAR_EXIS_SUC"]);
                    }

                    if (dr["REQ_APROBACION_INV"] != System.DBNull.Value)
                    {
                        retorno.IREQ_APROBACION_INV = (string)(dr["REQ_APROBACION_INV"]);
                    }

                    if (dr["REABRIRCORTES"] != System.DBNull.Value)
                    {
                        retorno.IREABRIRCORTES = (string)(dr["REABRIRCORTES"]);
                    }

                    if (dr["ULT_FECHA_IMP_PROD"] != System.DBNull.Value)
                    {
                        retorno.IULT_FECHA_IMP_PROD = (DateTime)dr["ULT_FECHA_IMP_PROD"];
                    }

                    if (dr["IMP_PROD_TOTAL"] != System.DBNull.Value)
                    {
                        retorno.IIMP_PROD_TOTAL = (string)(dr["IMP_PROD_TOTAL"]);
                    }


                    if (dr["TEXTO1"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO1 = (string)(dr["TEXTO1"]);
                    }

                    if (dr["TEXTO2"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO2 = (string)(dr["TEXTO2"]);
                    }

                    if (dr["TEXTO3"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO3 = (string)(dr["TEXTO3"]);
                    }

                    if (dr["TEXTO4"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO4 = (string)(dr["TEXTO4"]);
                    }

                    if (dr["TEXTO5"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO5 = (string)(dr["TEXTO5"]);
                    }

                    if (dr["TEXTO6"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO6 = (string)(dr["TEXTO6"]);
                    }

                    if (dr["NUMERO1"] != System.DBNull.Value)
                    {
                        retorno.INUMERO1 = (string)(dr["NUMERO1"]);
                    }

                    if (dr["NUMERO2"] != System.DBNull.Value)
                    {
                        retorno.INUMERO2 = (string)(dr["NUMERO2"]);
                    }

                    if (dr["NUMERO3"] != System.DBNull.Value)
                    {
                        retorno.INUMERO3 = (string)(dr["NUMERO3"]);
                    }

                    if (dr["NUMERO4"] != System.DBNull.Value)
                    {
                        retorno.INUMERO4 = (string)(dr["NUMERO4"]);
                    }

                    if (dr["FECHA1"] != System.DBNull.Value)
                    {
                        retorno.IFECHA1 = (string)(dr["FECHA1"]);
                    }

                    if (dr["FECHA2"] != System.DBNull.Value)
                    {
                        retorno.IFECHA2 = (string)(dr["FECHA2"]);
                    }
                    if (dr["NUMEROINTERIOR"] != System.DBNull.Value)
                    {
                        retorno.INUMEROINTERIOR = (string)(dr["NUMEROINTERIOR"]);
                    }
                    if (dr["NUMEROEXTERIOR"] != System.DBNull.Value)
                    {
                        retorno.INUMEROEXTERIOR = (string)(dr["NUMEROEXTERIOR"]);
                    }


                    if (dr["FISCALCALLE"] != System.DBNull.Value)
                    {
                        retorno.IFISCALCALLE = (string)(dr["FISCALCALLE"]);
                    }
                    if (dr["FISCALNUMEROINTERIOR"] != System.DBNull.Value)
                    {
                        retorno.IFISCALNUMEROINTERIOR = (string)(dr["FISCALNUMEROINTERIOR"]);
                    }
                    if (dr["FISCALNUMEROEXTERIOR"] != System.DBNull.Value)
                    {
                        retorno.IFISCALNUMEROEXTERIOR = (string)(dr["FISCALNUMEROEXTERIOR"]);
                    }
                    if (dr["FISCALCOLONIA"] != System.DBNull.Value)
                    {
                        retorno.IFISCALCOLONIA = (string)(dr["FISCALCOLONIA"]);
                    }
                    if (dr["FISCALMUNICIPIO"] != System.DBNull.Value)
                    {
                        retorno.IFISCALMUNICIPIO = (string)(dr["FISCALMUNICIPIO"]);
                    }
                    if (dr["FISCALESTADO"] != System.DBNull.Value)
                    {
                        retorno.IFISCALESTADO = (string)(dr["FISCALESTADO"]);
                    }
                    if (dr["FISCALCODIGOPOSTAL"] != System.DBNull.Value)
                    {
                        retorno.IFISCALCODIGOPOSTAL = (string)(dr["FISCALCODIGOPOSTAL"]);
                    }
                    if (dr["CERTIFICADOCSD"] != System.DBNull.Value)
                    {
                        retorno.ICERTIFICADOCSD = (string)(dr["CERTIFICADOCSD"]);
                    }
                    if (dr["TIMBRADOUSER"] != System.DBNull.Value)
                    {
                        retorno.ITIMBRADOUSER = (string)(dr["TIMBRADOUSER"]);
                    }
                    if (dr["TIMBRADOPASSWORD"] != System.DBNull.Value)
                    {
                        retorno.ITIMBRADOPASSWORD = (string)(dr["TIMBRADOPASSWORD"]);
                    }
                    if (dr["TIMBRADOARCHIVOCERTIFICADO"] != System.DBNull.Value)
                    {
                        retorno.ITIMBRADOARCHIVOCERTIFICADO = (string)(dr["TIMBRADOARCHIVOCERTIFICADO"]);
                    }
                    if (dr["TIMBRADOARCHIVOKEY"] != System.DBNull.Value)
                    {
                        retorno.ITIMBRADOARCHIVOKEY = (string)(dr["TIMBRADOARCHIVOKEY"]);
                    }

                    if (dr["TIMBRADOKEY"] != System.DBNull.Value)
                    {
                        retorno.ITIMBRADOKEY = (string)(dr["TIMBRADOKEY"]);
                    }



                    if (dr["FISCALNOMBRE"] != System.DBNull.Value)
                    {
                        retorno.IFISCALNOMBRE = (string)(dr["FISCALNOMBRE"]);
                    }



                    if (dr["SERIESAT"] != System.DBNull.Value)
                    {
                        retorno.ISERIESAT = (string)(dr["SERIESAT"]);
                    }


                    if (dr["USARFISCALESENEXPEDICION"] != System.DBNull.Value)
                    {
                        retorno.IUSARFISCALESENEXPEDICION = (string)(dr["USARFISCALESENEXPEDICION"]);
                    }

                    if (dr["HAB_FACTURAELECTRONICA"] != System.DBNull.Value)
                    {
                        retorno.IHAB_FACTURAELECTRONICA = (string)(dr["HAB_FACTURAELECTRONICA"]);
                    }

                    if (dr["FOOTERVENTAAPARTADO"] != System.DBNull.Value)
                    {
                        retorno.IFOOTERVENTAAPARTADO = (string)(dr["FOOTERVENTAAPARTADO"]);
                    }



                    if (dr["ENCARGADOID"] != System.DBNull.Value)
                    {
                        retorno.IENCARGADOID = long.Parse(dr["ENCARGADOID"].ToString());
                    }


                    if (dr["PORC_COMISIONENCARGADO"] != System.DBNull.Value)
                    {
                        retorno.IPORC_COMISIONENCARGADO = decimal.Parse(dr["PORC_COMISIONENCARGADO"].ToString());
                    }

                    if (dr["PORC_COMISIONVENDEDOR"] != System.DBNull.Value)
                    {
                        retorno.IPORC_COMISIONVENDEDOR = decimal.Parse(dr["PORC_COMISIONVENDEDOR"].ToString());
                    }
                    if (dr["FTPFOLDER"] != System.DBNull.Value)
                    {
                        retorno.IFTPFOLDER = (string)(dr["FTPFOLDER"]);
                    }
                    if (dr["FTPFOLDERPASS"] != System.DBNull.Value)
                    {
                        retorno.IFTPFOLDERPASS = (string)(dr["FTPFOLDERPASS"]);
                    }



                    if (dr["SERIESATDEVOLUCION"] != System.DBNull.Value)
                    {
                        retorno.ISERIESATDEVOLUCION = (string)(dr["SERIESATDEVOLUCION"]);
                    }


                    if (dr["CAMBIARPRECIOXUEMPAQUE"] != System.DBNull.Value)
                    {
                        retorno.ICAMBIARPRECIOXUEMPAQUE = (string)(dr["CAMBIARPRECIOXUEMPAQUE"]);
                    }

                    if (dr["CAMBIARPRECIOXPZACAJA"] != System.DBNull.Value)
                    {
                        retorno.ICAMBIARPRECIOXPZACAJA = (string)(dr["CAMBIARPRECIOXPZACAJA"]);
                    }


                    if (dr["PREFIJOBASCULA"] != System.DBNull.Value)
                    {
                        retorno.IPREFIJOBASCULA = (string)(dr["PREFIJOBASCULA"]);
                    }


                    if (dr["LONGPRODBASCULA"] != System.DBNull.Value)
                    {
                        retorno.ILONGPRODBASCULA = Int16.Parse(dr["LONGPRODBASCULA"].ToString());
                    }
                    if (dr["LONGPESOBASCULA"] != System.DBNull.Value)
                    {
                        retorno.ILONGPESOBASCULA = Int16.Parse(dr["LONGPESOBASCULA"].ToString());
                    }


                    if (dr["LISTAPRECIOXUEMPAQUE"] != System.DBNull.Value)
                    {
                        retorno.ILISTAPRECIOXUEMPAQUE = long.Parse(dr["LISTAPRECIOXUEMPAQUE"].ToString());
                    }

                    if (dr["LISTAPRECIOXPZACAJA"] != System.DBNull.Value)
                    {
                        retorno.ILISTAPRECIOXPZACAJA = long.Parse(dr["LISTAPRECIOXPZACAJA"].ToString());
                    }


                    if (dr["LISTAPRECIOINIMAYO"] != System.DBNull.Value)
                    {
                        retorno.ILISTAPRECIOINIMAYO = long.Parse(dr["LISTAPRECIOINIMAYO"].ToString());
                    }

                    if (dr["HAYVENDEDORPISO"] != System.DBNull.Value)
                    {
                        retorno.IHAYVENDEDORPISO = (string)(dr["HAYVENDEDORPISO"]);
                    }


                    if (dr["ENVIOAUTOMATICOEXISTENCIAS"] != System.DBNull.Value)
                    {
                        retorno.IENVIOAUTOMATICOEXISTENCIAS = (string)(dr["ENVIOAUTOMATICOEXISTENCIAS"]);
                    }


                    if (dr["MONEDEROCADUCIDAD"] != System.DBNull.Value)
                    {
                        retorno.IMONEDEROCADUCIDAD = int.Parse(dr["MONEDEROCADUCIDAD"].ToString());
                    }

                    if (dr["MONEDEROMONTOMINIMO"] != System.DBNull.Value)
                    {
                        retorno.IMONEDEROMONTOMINIMO = (decimal)(dr["MONEDEROMONTOMINIMO"]);
                    }

                    if (dr["MONEDEROAPLICAR"] != System.DBNull.Value)
                    {
                        retorno.IMONEDEROAPLICAR = (string)(dr["MONEDEROAPLICAR"]);
                    }

                    if (dr["IMPRIMIRNUMEROPIEZAS"] != System.DBNull.Value)
                    {
                        retorno.IIMPRIMIRNUMEROPIEZAS = (string)(dr["IMPRIMIRNUMEROPIEZAS"]);
                    }



                    if (dr["PACNOMBRE"] != System.DBNull.Value)
                    {
                        retorno.IPACNOMBRE = (string)(dr["PACNOMBRE"]);
                    }


                    if (dr["PACUSUARIO"] != System.DBNull.Value)
                    {
                        retorno.IPACUSUARIO = (string)(dr["PACUSUARIO"]);
                    }

                    if (dr["CORTEPORMAIL"] != System.DBNull.Value)
                    {
                        retorno.ICORTEPORMAIL = (string)(dr["CORTEPORMAIL"]);
                    }



                    if (dr["DEFAULTTASAIVAID"] != System.DBNull.Value)
                    {
                        retorno.IDEFAULTTASAIVAID = (long)(dr["DEFAULTTASAIVAID"]);
                    }


                    if (dr["RUTAREPORTES"] != System.DBNull.Value)
                    {
                        retorno.IRUTAREPORTES = (string)(dr["RUTAREPORTES"]);
                    }


                    if (dr["RUTAREPORTESSISTEMA"] != System.DBNull.Value)
                    {
                        retorno.IRUTAREPORTESSISTEMA = (string)(dr["RUTAREPORTESSISTEMA"]);
                    }


                    if (dr["DOBLECOPIACREDITO"] != System.DBNull.Value)
                    {
                        retorno.IDOBLECOPIACREDITO = (int)(dr["DOBLECOPIACREDITO"]);
                    }
                    if (dr["DOBLECOPIATRASLADO"] != System.DBNull.Value)
                    {
                        retorno.IDOBLECOPIATRASLADO = (int)(dr["DOBLECOPIATRASLADO"]);
                    }


                    if (dr["CAMPOSCUSTOMALIMPORTAR"] != System.DBNull.Value)
                    {
                        retorno.ICAMPOSCUSTOMALIMPORTAR = (string)(dr["CAMPOSCUSTOMALIMPORTAR"]);
                    }



                    if (dr["RECIBOLARGOPRINTER"] != System.DBNull.Value)
                    {
                        retorno.IRECIBOLARGOPRINTER = (string)(dr["RECIBOLARGOPRINTER"]);
                    }
                    if (dr["RECIBOLARGOPREVIEW"] != System.DBNull.Value)
                    {
                        retorno.IRECIBOLARGOPREVIEW = (string)(dr["RECIBOLARGOPREVIEW"]);
                    }

                    if (dr["PREGUNTARRAZONPRECIOMENOR"] != System.DBNull.Value)
                    {
                        retorno.IPREGUNTARRAZONPRECIOMENOR = (string)(dr["PREGUNTARRAZONPRECIOMENOR"]);
                    }
                    else
                    {
                        retorno.IPREGUNTARRAZONPRECIOMENOR = "N";
                    }

                    if (dr["PREGUNTARDATOSENTREGA"] != System.DBNull.Value)
                    {
                        retorno.IPREGUNTARDATOSENTREGA = (string)(dr["PREGUNTARDATOSENTREGA"]);
                    }
                    else
                    {
                        retorno.IPREGUNTARDATOSENTREGA = "N";
                    }


                    if (dr["FISCALREGIMEN"] != System.DBNull.Value)
                    {
                        retorno.IFISCALREGIMEN = (string)(dr["FISCALREGIMEN"]);
                    }
                    else
                    {
                        retorno.IFISCALREGIMEN = "";
                    }

                    if (dr["CORTACADUCIDAD"] != System.DBNull.Value)
                    {
                        retorno.ICORTACADUCIDAD = (int)(dr["CORTACADUCIDAD"]);
                    }
                    else
                    {
                        retorno.ICORTACADUCIDAD = 0;
                    }



                    if (dr["RETENCIONIVA"] != System.DBNull.Value)
                    {
                        retorno.IRETENCIONIVA = (decimal)(dr["RETENCIONIVA"]);
                    }

                    if (dr["RETENCIONISR"] != System.DBNull.Value)
                    {
                        retorno.IRETENCIONISR = (decimal)(dr["RETENCIONISR"]);
                    }


                    if (dr["ARRENDATARIO"] != System.DBNull.Value)
                    {
                        retorno.IARRENDATARIO = (string)(dr["ARRENDATARIO"]);
                    }
                    else
                    {
                        retorno.IFISCALREGIMEN = "N";
                    }


                    if (dr["RUTAIMAGENESPRODUCTO"] != System.DBNull.Value)
                    {
                        retorno.IRUTAIMAGENESPRODUCTO = (string)(dr["RUTAIMAGENESPRODUCTO"]);
                    }

                    if (dr["MOSTRARIMAGENENVENTA"] != System.DBNull.Value)
                    {
                        retorno.IMOSTRARIMAGENENVENTA = (string)(dr["MOSTRARIMAGENENVENTA"]);
                    }


                    if (dr["MOSTRARMONTOAHORRO"] != System.DBNull.Value)
                    {
                        retorno.IMOSTRARMONTOAHORRO = (string)(dr["MOSTRARMONTOAHORRO"]);
                    }


                    if (dr["SMTPSSL"] != System.DBNull.Value)
                    {
                        retorno.ISMTPSSL = (string)(dr["SMTPSSL"]);
                    }

                    if (dr["MOSTRARDESCUENTOFACTURA"] != System.DBNull.Value)
                    {
                        retorno.IMOSTRARDESCUENTOFACTURA = (string)(dr["MOSTRARDESCUENTOFACTURA"]);
                    }

                    if (dr["EXPORTCATALOGOAUX"] != System.DBNull.Value)
                    {
                        retorno.IEXPORTCATALOGOAUX = (string)(dr["EXPORTCATALOGOAUX"]);
                    }


                    if (dr["UIVENTACONCANTIDAD"] != System.DBNull.Value)
                    {
                        retorno.IUIVENTACONCANTIDAD = (string)(dr["UIVENTACONCANTIDAD"]);
                    }


                    if (dr["FACT_ELECT_FOLDER"] != System.DBNull.Value)
                    {
                        retorno.IFACT_ELECT_FOLDER = (string)(dr["FACT_ELECT_FOLDER"]);
                    }



                    if (dr["PEDIDOS_FOLDER"] != System.DBNull.Value)
                    {
                        retorno.IPEDIDOS_FOLDER = (string)(dr["PEDIDOS_FOLDER"]);
                    }




                    if (dr["PREFIJOCLIENTE"] != System.DBNull.Value)
                    {
                        retorno.IPREFIJOCLIENTE = (string)(dr["PREFIJOCLIENTE"]);
                    }


                    if (dr["FECHAINICIOPEDIDO"] != System.DBNull.Value)
                    {
                        retorno.IFECHAINICIOPEDIDO = (DateTime)dr["FECHAINICIOPEDIDO"];
                    }


                    if (dr["RECIBOLARGOCONFACTURA"] != System.DBNull.Value)
                    {
                        retorno.IRECIBOLARGOCONFACTURA = (string)(dr["RECIBOLARGOCONFACTURA"]);
                    }


                    if (dr["MOSTRARPZACAJAENFACTURA"] != System.DBNull.Value)
                    {
                        retorno.IMOSTRARPZACAJAENFACTURA = (string)(dr["MOSTRARPZACAJAENFACTURA"]);
                    }

                    if (dr["DESGLOSEIEPS"] != System.DBNull.Value)
                    {
                        retorno.IDESGLOSEIEPS = (string)(dr["DESGLOSEIEPS"]);
                    }

                    if (dr["CUENTAIEPS"] != System.DBNull.Value)
                    {
                        retorno.ICUENTAIEPS = (string)(dr["CUENTAIEPS"]);
                    }

                    if (dr["DIVIDIR_REM_FACT"] != System.DBNull.Value)
                    {
                        retorno.IDIVIDIR_REM_FACT = (string)(dr["DIVIDIR_REM_FACT"]);
                    }


                    if (dr["WEBSERVICE"] != System.DBNull.Value)
                    {
                        retorno.IWEBSERVICE = (string)(dr["WEBSERVICE"]);
                    }


                    if (dr["MINUTILIDAD"] != System.DBNull.Value)
                    {
                        retorno.IMINUTILIDAD = (decimal)(dr["MINUTILIDAD"]);
                    }


                    if (dr["MANEJASUPERLISTAPRECIO"] != System.DBNull.Value)
                    {
                        retorno.IMANEJASUPERLISTAPRECIO = (string)(dr["MANEJASUPERLISTAPRECIO"]);
                    }


                    if (dr["MANEJAALMACEN"] != System.DBNull.Value)
                    {
                        retorno.IMANEJAALMACEN = (string)(dr["MANEJAALMACEN"]);
                    }


                    if (dr["TIPODESCUENTOPRODID"] != System.DBNull.Value)
                    {
                        retorno.ITIPODESCUENTOPRODID = (long)(dr["TIPODESCUENTOPRODID"]);
                    }


                    if (dr["MANEJARECETA"] != System.DBNull.Value)
                    {
                        retorno.IMANEJARECETA = (string)(dr["MANEJARECETA"]);
                    }


                    if (dr["AUTOCOMPPROD"] != System.DBNull.Value)
                    {
                        retorno.IAUTOCOMPPROD = (string)(dr["AUTOCOMPPROD"]);
                    }


                    if (dr["LASTCHANGEPRODDESC"] != System.DBNull.Value)
                    {
                        retorno.ILASTCHANGEPRODDESC = (DateTime)dr["LASTCHANGEPRODDESC"];
                    }



                    if (dr["TIPOUTILIDADID"] != System.DBNull.Value)
                    {
                        retorno.ITIPOUTILIDADID = (long)(dr["TIPOUTILIDADID"]);
                    }

                    if (dr["MANEJAQUOTA"] != System.DBNull.Value)
                    {
                        retorno.IMANEJAQUOTA = (string)(dr["MANEJAQUOTA"]);
                    }

                    if (dr["TOUCH"] != System.DBNull.Value)
                    {
                        retorno.ITOUCH = (string)(dr["TOUCH"]);
                    }


                    if (dr["ESVENDEDORMOVIL"] != System.DBNull.Value)
                    {
                        retorno.IESVENDEDORMOVIL = (string)(dr["ESVENDEDORMOVIL"]);
                    }


                    if (dr["CAJASBOTELLAS"] != System.DBNull.Value)
                    {
                        retorno.ICAJASBOTELLAS = (string)(dr["CAJASBOTELLAS"]);
                    }

                    if (dr["PRECIONETOENPV"] != System.DBNull.Value)
                    {
                        retorno.IPRECIONETOENPV = (string)(dr["PRECIONETOENPV"]);
                    }



                    if (dr["TIPOSYNCMOVIL"] != System.DBNull.Value)
                    {
                        retorno.ITIPOSYNCMOVIL = (string)(dr["TIPOSYNCMOVIL"]);
                    }





                    if (dr["MOSTRARFLASH"] != System.DBNull.Value)
                    {
                        retorno.IMOSTRARFLASH = (string)(dr["MOSTRARFLASH"]);
                    }


                    if (dr["ORDENIMPRESION"] != System.DBNull.Value)
                    {
                        retorno.IORDENIMPRESION = (string)(dr["ORDENIMPRESION"]);
                    }


                    try
                    {
                        if (dr["AUTOCOMPCLIENTE"] != System.DBNull.Value)
                        {
                            retorno.IAUTOCOMPCLIENTE = (string)(dr["AUTOCOMPCLIENTE"]);
                        }

                        if (dr["LASTCHANGECLIENTENOMBRE"] != System.DBNull.Value)
                        {
                            retorno.ILASTCHANGECLIENTENOMBRE = (DateTime)dr["LASTCHANGECLIENTENOMBRE"];
                        }

                        if (dr["PRECIOXCAJAENPV"] != System.DBNull.Value)
                        {
                            retorno.IPRECIOXCAJAENPV = (string)(dr["PRECIOXCAJAENPV"]);
                        }



                        if (dr["LOCALFTPHOST"] != System.DBNull.Value)
                        {
                            retorno.ILOCALFTPHOST = (string)(dr["LOCALFTPHOST"]);
                        }
                        if (dr["LOCALWEBSERVICE"] != System.DBNull.Value)
                        {
                            retorno.ILOCALWEBSERVICE = (string)(dr["LOCALWEBSERVICE"]);
                        }

                        if (dr["USARCONEXIONLOCAL"] != System.DBNull.Value)
                        {
                            retorno.IUSARCONEXIONLOCAL = (string)(dr["USARCONEXIONLOCAL"]);
                        }

                        if (dr["MAILTOINVENTARIO"] != System.DBNull.Value)
                        {
                            retorno.IMAILTOINVENTARIO = (string)(dr["MAILTOINVENTARIO"]);
                        }


                        if (dr["LASTCHANGEPRECIOPROD"] != System.DBNull.Value)
                        {
                            retorno.ILASTCHANGEPRECIOPROD = (DateTime)dr["LASTCHANGEPRECIOPROD"];
                        }

                        if (dr["RUTARESPALDOSZIP"] != System.DBNull.Value)
                        {
                            retorno.IRUTARESPALDOSZIP = (string)(dr["RUTARESPALDOSZIP"]);
                        }

                        if (dr["SCREENCONFIG"] != System.DBNull.Value)
                        {
                            retorno.ISCREENCONFIG = (long)(dr["SCREENCONFIG"]);
                        }
                        else
                        {
                            retorno.ISCREENCONFIG = 0;
                        }

                        if (dr["PROMOENTICKET"] != System.DBNull.Value)
                        {
                            retorno.IPROMOENTICKET = (string)(dr["PROMOENTICKET"]);
                        }

                        if (dr["TAMANOLETRATICKET"] != System.DBNull.Value)
                        {
                            retorno.ITAMANOLETRATICKET = (short)(dr["TAMANOLETRATICKET"]);
                        }
                        else
                        {
                            retorno.ITAMANOLETRATICKET = 0;
                        }

                        if (dr["MANEJAKITS"] != System.DBNull.Value)
                        {
                            retorno.IMANEJAKITS = (string)(dr["MANEJAKITS"]);
                        }
                        else
                        {
                            retorno.IMANEJAKITS = "N";
                        }


                        if (dr["CAMPOIMPOCOSTOREPO"] != System.DBNull.Value)
                        {
                            retorno.ICAMPOIMPOCOSTOREPO = (long)(dr["CAMPOIMPOCOSTOREPO"]);
                        }
                        else
                        {
                            retorno.ICAMPOIMPOCOSTOREPO = 0;
                        }


                        if (dr["REBAJAESPECIAL"] != System.DBNull.Value)
                        {
                            retorno.IREBAJAESPECIAL = (string)(dr["REBAJAESPECIAL"]);
                        }
                        else
                        {
                            retorno.IREBAJAESPECIAL = "N";
                        }



                        if (dr["HABILITARREPL"] != System.DBNull.Value)
                        {
                            retorno.IHABILITARREPL = (string)(dr["HABILITARREPL"]);
                        }
                        else
                        {
                            retorno.IHABILITARREPL = "N";
                        }


                        if (dr["BDLOCALREPL"] != System.DBNull.Value)
                        {
                            retorno.IBDLOCALREPL = (string)(dr["BDLOCALREPL"]);
                        }
                        else
                        {
                            retorno.IBDLOCALREPL = "N";
                        }



                        if (dr["PENDMOVILANTESVENTA"] != System.DBNull.Value)
                        {
                            retorno.IPENDMOVILANTESVENTA = (string)(dr["PENDMOVILANTESVENTA"]);
                        }
                        else
                        {
                            retorno.IPENDMOVILANTESVENTA = "N";
                        }


                        if (dr["PRECIOSMOVILANTESVENTA"] != System.DBNull.Value)
                        {
                            retorno.IPRECIOSMOVILANTESVENTA = (string)(dr["PRECIOSMOVILANTESVENTA"]);
                        }
                        else
                        {
                            retorno.IPRECIOSMOVILANTESVENTA = "S";
                        }


                        if (dr["RECALCULARCAMBIOCLIENTE"] != System.DBNull.Value)
                        {
                            retorno.IRECALCULARCAMBIOCLIENTE = (string)(dr["RECALCULARCAMBIOCLIENTE"]);
                        }
                        else
                        {
                            retorno.IRECALCULARCAMBIOCLIENTE = "S";
                        }



                        if (dr["TIPOVENDEDORMOVIL"] != System.DBNull.Value)
                        {
                            retorno.ITIPOVENDEDORMOVIL = (long)(dr["TIPOVENDEDORMOVIL"]);
                        }
                        else
                        {
                            retorno.ITIPOVENDEDORMOVIL = 1;
                        }

                        


                        if (dr["BDSERVERWS"] != System.DBNull.Value)
                        {
                            retorno.IBDSERVERWS = (string)(dr["BDSERVERWS"]);
                        }
                        else
                        {
                            retorno.IBDSERVERWS = "";
                        }



                        if (dr["BDMATRIZMOVIL"] != System.DBNull.Value)
                        {
                            retorno.IBDMATRIZMOVIL = (string)(dr["BDMATRIZMOVIL"]);
                        }
                        else
                        {
                            retorno.IBDMATRIZMOVIL = "";
                        }



                        if (dr["PRODCAMBIOPARAMOVIL"] != System.DBNull.Value)
                        {
                            retorno.IPRODCAMBIOPARAMOVIL = (DateTime)(dr["PRODCAMBIOPARAMOVIL"]);
                        }
                        else
                        {
                            retorno.IBDMATRIZMOVIL = "";
                        }


                        if (dr["MOVILPROCESOSURTIDO"] != System.DBNull.Value)
                        {
                            retorno.IMOVILPROCESOSURTIDO = (string)(dr["MOVILPROCESOSURTIDO"]);
                        }
                        else
                        {
                            retorno.IMOVILPROCESOSURTIDO = "";
                        }


                        if (dr["MOVILVERIFICARVENTA"] != System.DBNull.Value)
                        {
                            retorno.IMOVILVERIFICARVENTA = (string)(dr["MOVILVERIFICARVENTA"]);
                        }
                        else
                        {
                            retorno.IMOVILVERIFICARVENTA = "";
                        }



                        if (dr["PENDMAXDIAS"] != System.DBNull.Value)
                        {
                            retorno.IPENDMAXDIAS = int.Parse(dr["PENDMAXDIAS"].ToString());
                        }


                        if (dr["REQAUTCANCELARCOTI"] != System.DBNull.Value)
                        {
                            retorno.IREQAUTCANCELARCOTI = (string)(dr["REQAUTCANCELARCOTI"]);
                        }
                        else
                        {
                            retorno.IREQAUTCANCELARCOTI = "N";
                        }



                        if (dr["REQAUTELIMDETALLECOTI"] != System.DBNull.Value)
                        {
                            retorno.IREQAUTELIMDETALLECOTI = (string)(dr["REQAUTELIMDETALLECOTI"]);
                        }
                        else
                        {
                            retorno.IREQAUTELIMDETALLECOTI = "N";
                        }



                        if (dr["ABRIRCAJONALFINCORTE"] != System.DBNull.Value)
                        {
                            retorno.IABRIRCAJONALFINCORTE = (string)(dr["ABRIRCAJONALFINCORTE"]);
                        }
                        else
                        {
                            retorno.IABRIRCAJONALFINCORTE = "N";
                        }



                        if (dr["HABSURTIDOPOSTPUESTO"] != System.DBNull.Value)
                        {
                            retorno.IHABSURTIDOPOSTPUESTO = (string)(dr["HABSURTIDOPOSTPUESTO"]);
                        }
                        else
                        {
                            retorno.IHABSURTIDOPOSTPUESTO = "N";
                        }



                        if (dr["CLIENTECONSOLIDADOID"] != System.DBNull.Value)
                        {
                            retorno.ICLIENTECONSOLIDADOID = (long)(dr["CLIENTECONSOLIDADOID"]);
                        }
                        else
                        {
                            retorno.ICLIENTECONSOLIDADOID = 1;
                        }



                        if (dr["DOBLECOPIAREMISION"] != System.DBNull.Value)
                        {
                            retorno.IDOBLECOPIAREMISION = (string)(dr["DOBLECOPIAREMISION"]);
                        }
                        else
                        {
                            retorno.IDOBLECOPIAREMISION = "N";
                        }


                        if (dr["REIMPRESIONESCONMARCA"] != System.DBNull.Value)
                        {
                            retorno.IREIMPRESIONESCONMARCA = (string)(dr["REIMPRESIONESCONMARCA"]);
                        }
                        else
                        {
                            retorno.IREIMPRESIONESCONMARCA = "N";
                        }

                        if (dr["HABTOTALIZADOS"] != System.DBNull.Value)
                        {
                            retorno.IHABTOTALIZADOS = (string)(dr["HABTOTALIZADOS"]);
                        }
                        else
                        {
                            retorno.IHABTOTALIZADOS = "N";
                        }



                        if (dr["MULTIPLETIPOVALE"] != System.DBNull.Value)
                        {
                            retorno.IMULTIPLETIPOVALE = (string)(dr["MULTIPLETIPOVALE"]);
                        }
                        else
                        {
                            retorno.IMULTIPLETIPOVALE = "N";
                        }


                        if (dr["DESCUENTOTIPO1TEXTO"] != System.DBNull.Value)
                        {
                            retorno.IDESCUENTOTIPO1TEXTO = (string)(dr["DESCUENTOTIPO1TEXTO"]);
                        }
                        else
                        {
                            retorno.IDESCUENTOTIPO1TEXTO = "";
                        }


                        if (dr["DESCUENTOTIPO1PORC"] != System.DBNull.Value)
                        {
                            retorno.IDESCUENTOTIPO1PORC = (decimal)(dr["DESCUENTOTIPO1PORC"]);
                        }




                        if (dr["DESCUENTOTIPO2TEXTO"] != System.DBNull.Value)
                        {
                            retorno.IDESCUENTOTIPO2TEXTO = (string)(dr["DESCUENTOTIPO2TEXTO"]);
                        }
                        else
                        {
                            retorno.IDESCUENTOTIPO2TEXTO = "";
                        }


                        if (dr["DESCUENTOTIPO2PORC"] != System.DBNull.Value)
                        {
                            retorno.IDESCUENTOTIPO2PORC = (decimal)(dr["DESCUENTOTIPO2PORC"]);
                        }



                        if (dr["DESCUENTOTIPO3TEXTO"] != System.DBNull.Value)
                        {
                            retorno.IDESCUENTOTIPO3TEXTO = (string)(dr["DESCUENTOTIPO3TEXTO"]);
                        }
                        else
                        {
                            retorno.IDESCUENTOTIPO3TEXTO = "";
                        }


                        if (dr["DESCUENTOTIPO3PORC"] != System.DBNull.Value)
                        {
                            retorno.IDESCUENTOTIPO3PORC = (decimal)(dr["DESCUENTOTIPO3PORC"]);
                        }



                        if (dr["DESCUENTOTIPO4TEXTO"] != System.DBNull.Value)
                        {
                            retorno.IDESCUENTOTIPO4TEXTO = (string)(dr["DESCUENTOTIPO4TEXTO"]);
                        }
                        else
                        {
                            retorno.IDESCUENTOTIPO4TEXTO = "";
                        }


                        if (dr["DESCUENTOTIPO4PORC"] != System.DBNull.Value)
                        {
                            retorno.IDESCUENTOTIPO4PORC = (decimal)(dr["DESCUENTOTIPO4PORC"]);
                        }




                        if (dr["HABILITARLOG"] != System.DBNull.Value)
                        {
                            retorno.IHABILITARLOG = (string)(dr["HABILITARLOG"]);
                        }
                        else
                        {
                            retorno.IHABILITARLOG = "N";
                        }


                        if (dr["RUTARESPALDO"] != System.DBNull.Value)
                        {
                            retorno.IRUTARESPALDO = (string)(dr["RUTARESPALDO"]);
                        }


                        if (dr["FECHARESPALDO"] != System.DBNull.Value)
                        {
                            retorno.IFECHARESPALDO = (DateTime)dr["FECHARESPALDO"];
                        }



                        if (dr["MANEJARRETIRODECAJA"] != System.DBNull.Value)
                        {
                            retorno.IMANEJARRETIRODECAJA = (string)(dr["MANEJARRETIRODECAJA"]);
                        }
                        else
                        {
                            retorno.IMANEJARRETIRODECAJA = "N";
                        }

                        if (dr["MONTORETIROCAJA"] != System.DBNull.Value)
                        {
                            retorno.IMONTORETIROCAJA = (decimal)(dr["MONTORETIROCAJA"]);
                        }



                        if (dr["APLICARMAYOREOPORLINEA"] != System.DBNull.Value)
                        {
                            retorno.IAPLICARMAYOREOPORLINEA = (string)(dr["APLICARMAYOREOPORLINEA"]);
                        }
                        else
                        {
                            retorno.IAPLICARMAYOREOPORLINEA = "N";
                        }


                        if (dr["COMISIONPORTARJETA"] != System.DBNull.Value)
                        {
                            retorno.ICOMISIONPORTARJETA = (decimal)(dr["COMISIONPORTARJETA"]);
                        }

                        if (dr["PIEZASIGUALESMEDIOMAYOREO"] != System.DBNull.Value)
                        {
                            retorno.IPIEZASIGUALESMEDIOMAYOREO = (decimal)(dr["PIEZASIGUALESMEDIOMAYOREO"]);
                        }

                        if (dr["PIEZASIGUALESMEDIOMAYOREO"] != System.DBNull.Value)
                        {
                            retorno.IPIEZASIGUALESMEDIOMAYOREO = (decimal)(dr["PIEZASIGUALESMEDIOMAYOREO"]);
                        }

                        if (dr["PIEZASDIFMEDIOMAYOREO"] != System.DBNull.Value)
                        {
                            retorno.IPIEZASDIFMEDIOMAYOREO = (decimal)(dr["PIEZASDIFMEDIOMAYOREO"]);
                        }

                        if (dr["PIEZASIGUALESMAYOREO"] != System.DBNull.Value)
                        {
                            retorno.IPIEZASIGUALESMAYOREO = (decimal)(dr["PIEZASIGUALESMAYOREO"]);
                        }

                        if (dr["COMISIONTARJETAEMPRESA"] != System.DBNull.Value)
                        {
                            retorno.ICOMISIONTARJETAEMPRESA = (decimal)(dr["COMISIONTARJETAEMPRESA"]);
                        }
                        if (dr["IVACOMISIONTARJETAEMPRESA"] != System.DBNull.Value)
                        {
                            retorno.IIVACOMISIONTARJETAEMPRESA = (decimal)(dr["IVACOMISIONTARJETAEMPRESA"]);
                        }


                        if (dr["PREGUNTACANCELACOTIZACION"] != System.DBNull.Value)
                        {
                            retorno.IPREGUNTACANCELACOTIZACION = (string)(dr["PREGUNTACANCELACOTIZACION"]);
                        }
                        else
                        {
                            retorno.IPREGUNTACANCELACOTIZACION = "N";
                        }



                        if (dr["HABVERIFICACIONCXC"] != System.DBNull.Value)
                        {
                            retorno.IHABVERIFICACIONCXC = (string)(dr["HABVERIFICACIONCXC"]);
                        }
                        else
                        {
                            retorno.IHABVERIFICACIONCXC = "N";
                        }

                        if (dr["SERVICIOSEMIDA"] != System.DBNull.Value)
                        {
                            retorno.ISERVICIOSEMIDA = (string)(dr["SERVICIOSEMIDA"]);
                        }



                        if (dr["MAILEJECUTIVO"] != System.DBNull.Value)
                        {
                            retorno.IMAILEJECUTIVO = (string)(dr["MAILEJECUTIVO"]);
                        }
                        else
                        {
                            retorno.IMAILEJECUTIVO = "";
                        }


                        if (dr["VENTASXCORTEEMAIL"] != System.DBNull.Value)
                        {
                            retorno.IVENTASXCORTEEMAIL = (string)(dr["VENTASXCORTEEMAIL"]);
                        }
                        else
                        {
                            retorno.IVENTASXCORTEEMAIL = "";
                        }



                        if (dr["HABVENTASAFUTURO"] != System.DBNull.Value)
                        {
                            retorno.IHABVENTASAFUTURO = (string)(dr["HABVENTASAFUTURO"]);
                        }
                        else
                        {
                            retorno.IHABVENTASAFUTURO = "";
                        }


                        if (dr["FECHAACTUALIZACIONEMIDA"] != System.DBNull.Value)
                        {
                            retorno.IFECHAACTUALIZACIONEMIDA = (DateTime)dr["FECHAACTUALIZACIONEMIDA"];
                        }



                        if (dr["FORMATOTICKETCORTOID"] != System.DBNull.Value)
                        {
                            retorno.IFORMATOTICKETCORTOID = long.Parse(dr["FORMATOTICKETCORTOID"].ToString());
                        }


                        if (dr["SERIESATABONO"] != System.DBNull.Value)
                        {
                            retorno.ISERIESATABONO = (string)(dr["SERIESATABONO"]);
                        }

                        if (dr["HABIMPRESIONCORTECAJERO"] != System.DBNull.Value)
                        {
                            retorno.IHABIMPRESIONCORTECAJERO = (string)(dr["HABIMPRESIONCORTECAJERO"]);
                        }


                        if (dr["HABTRASLADOPORAUTORIZACION"] != System.DBNull.Value)
                        {
                            retorno.IHABTRASLADOPORAUTORIZACION = (string)(dr["HABTRASLADOPORAUTORIZACION"]);
                        }


                        if (dr["HABVENTASMOSTRADOR"] != System.DBNull.Value)
                        {
                            retorno.IHABVENTASMOSTRADOR = (string)(dr["HABVENTASMOSTRADOR"]);
                        }

                        if (dr["TIMEOUTPINDISTSALE"] != System.DBNull.Value)
                        {
                            retorno.ITIMEOUTPINDISTSALE = (int)(dr["TIMEOUTPINDISTSALE"]);
                        }

                        if (dr["TIMEOUTLOOKUP"] != System.DBNull.Value)
                        {
                            retorno.ITIMEOUTLOOKUP = (int)(dr["TIMEOUTLOOKUP"]);
                        }


                        if (dr["RUTAARCHIVOSADJUNTOS"] != System.DBNull.Value)
                        {
                            retorno.IRUTAARCHIVOSADJUNTOS = (string)(dr["RUTAARCHIVOSADJUNTOS"]);
                        }


                        if (dr["TIMEOUTPINDISTSALESERV"] != System.DBNull.Value)
                        {
                            retorno.ITIMEOUTPINDISTSALESERV = (int)(dr["TIMEOUTPINDISTSALESERV"]);
                        }


                        if (dr["FECHAACTUALIZACIONEMIDASERV"] != System.DBNull.Value)
                        {
                            retorno.IFECHAACTUALIZACIONEMIDASERV = (DateTime)dr["FECHAACTUALIZACIONEMIDASERV"];
                        }

                        if (dr["HABPAGOSERVEMIDA"] != System.DBNull.Value)
                        {
                            retorno.IHABPAGOSERVEMIDA = (string)(dr["HABPAGOSERVEMIDA"]);
                        }



                        if (dr["HABPROMOXMONTOMIN"] != System.DBNull.Value)
                        {
                            retorno.IHABPROMOXMONTOMIN = (string)(dr["HABPROMOXMONTOMIN"]);
                        }


                        if (dr["FORMATOFACTELECT"] != System.DBNull.Value)
                        {
                            retorno.IFORMATOFACTELECT = (string)(dr["FORMATOFACTELECT"]);
                        }

                        if (dr["MONTOMAXSALDOMENOR"] != System.DBNull.Value)
                        {
                            retorno.IMONTOMAXSALDOMENOR = (decimal)(dr["MONTOMAXSALDOMENOR"]);
                        }


                        if (dr["EMIDARECARGALINEAID"] != System.DBNull.Value)
                        {
                            retorno.IEMIDARECARGALINEAID = long.Parse(dr["EMIDARECARGALINEAID"].ToString());
                        }


                        if (dr["EMIDARECARGAMARCAID"] != System.DBNull.Value)
                        {
                            retorno.IEMIDARECARGAMARCAID = long.Parse(dr["EMIDARECARGAMARCAID"].ToString());
                        }

                        if (dr["EMIDARECARGAPROVEEDORID"] != System.DBNull.Value)
                        {
                            retorno.IEMIDARECARGAPROVEEDORID = long.Parse(dr["EMIDARECARGAPROVEEDORID"].ToString());
                        }


                        if (dr["EMIDASERVICIOLINEAID"] != System.DBNull.Value)
                        {
                            retorno.IEMIDASERVICIOLINEAID = long.Parse(dr["EMIDASERVICIOLINEAID"].ToString());
                        }


                        if (dr["EMIDASERVICIOMARCAID"] != System.DBNull.Value)
                        {
                            retorno.IEMIDASERVICIOMARCAID = long.Parse(dr["EMIDASERVICIOMARCAID"].ToString());
                        }

                        if (dr["EMIDASERVICIOPROVEEDORID"] != System.DBNull.Value)
                        {
                            retorno.IEMIDASERVICIOPROVEEDORID = long.Parse(dr["EMIDASERVICIOPROVEEDORID"].ToString());
                        }

                        if (dr["EMIDAPORCUTILIDADRECARGAS"] != System.DBNull.Value)
                        {
                            retorno.IEMIDAPORCUTILIDADRECARGAS = (decimal)(dr["EMIDAPORCUTILIDADRECARGAS"]);
                        }

                        if (dr["EMIDAUTILIDADPAGOSERVICIOS"] != System.DBNull.Value)
                        {
                            retorno.IEMIDAUTILIDADPAGOSERVICIOS = (decimal)(dr["EMIDAUTILIDADPAGOSERVICIOS"]);
                        }


                        if (dr["PRECIOSORDENADOS"] != System.DBNull.Value)
                        {
                            retorno.IPRECIOSORDENADOS = (string)(dr["PRECIOSORDENADOS"]);
                        }


                        if (dr["DECIMALESENCANTIDAD"] != System.DBNull.Value)
                        {
                            retorno.IDECIMALESENCANTIDAD = (int)(dr["DECIMALESENCANTIDAD"]);
                        }


                        if (dr["EANPUEDEREPETIRSE"] != System.DBNull.Value)
                        {
                            retorno.IEANPUEDEREPETIRSE = (string)(dr["EANPUEDEREPETIRSE"]);
                        }


                        if (dr["BANCOMERHABPINPAD"] != System.DBNull.Value)
                        {
                            retorno.IBANCOMERHABPINPAD = (string)(dr["BANCOMERHABPINPAD"]);
                        }

                        if (dr["HAB_PRECIOSCLIENTE"] != System.DBNull.Value)
                        {
                            retorno.IHAB_PRECIOSCLIENTE = (string)(dr["HAB_PRECIOSCLIENTE"]);
                        }





                        if (dr["CXCVALIDARTRASLADOS"] != System.DBNull.Value)
                        {
                            retorno.ICXCVALIDARTRASLADOS = (string)(dr["CXCVALIDARTRASLADOS"]);
                        }

                        if (dr["PREGUNTARSIESACREDITO"] != System.DBNull.Value)
                        {
                            retorno.IPREGUNTARSIESACREDITO = (string)(dr["PREGUNTARSIESACREDITO"]);
                        }

                        if (dr["HABMENSAJERIA"] != System.DBNull.Value)
                        {
                            retorno.IHABMENSAJERIA = (string)(dr["HABMENSAJERIA"]);
                        }

                        if (dr["WSMENSAJERIA"] != System.DBNull.Value)
                        {
                            retorno.IWSMENSAJERIA = (string)(dr["WSMENSAJERIA"]);
                        }



                        if (dr["ULTMENSAJEID"] != System.DBNull.Value)
                        {
                            retorno.IULTMENSAJEID = long.Parse(dr["ULTMENSAJEID"].ToString());
                        }

                        if (dr["HABDESCLINEAPERSONA"] != System.DBNull.Value)
                        {
                            retorno.IHABDESCLINEAPERSONA = (string)(dr["HABDESCLINEAPERSONA"]);
                        }

                        if (dr["MANEJARLOTEIMPORTACION"] != System.DBNull.Value)
                        {
                            retorno.IMANEJARLOTEIMPORTACION = (string)(dr["MANEJARLOTEIMPORTACION"]);
                        }


                        if (dr["MANEJAGASTOSADIC"] != System.DBNull.Value)
                        {
                            retorno.IMANEJAGASTOSADIC = (string)(dr["MANEJAGASTOSADIC"]);
                        }

                        if (dr["CADUCIDADMINIMA"] != System.DBNull.Value)
                        {
                            retorno.ICADUCIDADMINIMA = (int)(dr["CADUCIDADMINIMA"]);
                        }
                        else
                        {
                            retorno.ICADUCIDADMINIMA = 0;
                        }



                        if (dr["PRECIOAJUSTEDIFINV"] != System.DBNull.Value)
                        {
                            retorno.IPRECIOAJUSTEDIFINV = (string)(dr["PRECIOAJUSTEDIFINV"]);
                        }

                        if (dr["HABBOTONPAGOVALE"] != System.DBNull.Value)
                        {
                            retorno.IHABBOTONPAGOVALE = (string)(dr["HABBOTONPAGOVALE"]);
                        }

                        if (dr["UNICAVISITAPORDOCTO"] != System.DBNull.Value)
                        {
                            retorno.IUNICAVISITAPORDOCTO = (string)(dr["UNICAVISITAPORDOCTO"]);
                        }


                        if (dr["PLAZOXPRODUCTO"] != System.DBNull.Value)
                        {
                            retorno.IPLAZOXPRODUCTO = (string)(dr["PLAZOXPRODUCTO"]);
                        }
                        
                        if (dr["IPWEBSERVICEAPPINV"] != System.DBNull.Value)
                        {
                            retorno.IIPWEBSERVICEAPPINV = (string)(dr["IPWEBSERVICEAPPINV"]);
                        }

                        if (dr["RUTABDAPPINVENTARO"] != System.DBNull.Value)
                        {
                            retorno.IRUTABDAPPINVENTARO = (string)(dr["RUTABDAPPINVENTARO"]);
                        }
                        
                        if (dr["AUTOCOMPLETECONEXISENVENTA"] != System.DBNull.Value)
                        {
                            retorno.IAUTOCOMPLETECONEXISENVENTA = (string)(dr["AUTOCOMPLETECONEXISENVENTA"]);
                        }
                        
                        if (dr["RUTADBFEXISTENCIASUC"] != System.DBNull.Value)
                        {
                            retorno.IRUTADBFEXISTENCIASUC = (string)(dr["RUTADBFEXISTENCIASUC"]);
                        }

                        if (dr["ALMACENRECEPCIONID"] != System.DBNull.Value)
                        {
                            retorno.IALMACENRECEPCIONID = (long)(dr["ALMACENRECEPCIONID"]);
                        }
                        
                        if (dr["APLICARCAMBIOSPRECAUTO"] != System.DBNull.Value)
                        {
                            retorno.IAPLICARCAMBIOSPRECAUTO = (string)(dr["APLICARCAMBIOSPRECAUTO"]);
                    }

                        if (dr["NUMCANCELACTAUTO"] != System.DBNull.Value)
                    {
                            retorno.INUMCANCELACTAUTO = (short)(dr["NUMCANCELACTAUTO"]);
                    }

                        if (dr["NUMCANCELACTAUTOUSUARIO"] != System.DBNull.Value)
                        {
                            retorno.INUMCANCELACTAUTOUSUARIO = (short)(dr["NUMCANCELACTAUTOUSUARIO"]);
                }

                        if (dr["MANEJACUPONES"] != System.DBNull.Value)
                        {
                            retorno.IMANEJACUPONES = (string)(dr["MANEJACUPONES"]);
                        }


                        if (dr["HAB_DEVOLUCIONTRASLADO"] != System.DBNull.Value)
                        {
                            retorno.IHAB_DEVOLUCIONTRASLADO = (string)(dr["HAB_DEVOLUCIONTRASLADO"]);
                        }


                        if (dr["HAB_DEVOLUCIONSURTIDOSUC"] != System.DBNull.Value)
                        {
                            retorno.IHAB_DEVOLUCIONSURTIDOSUC = (string)(dr["HAB_DEVOLUCIONSURTIDOSUC"]);
                        }


                        if (dr["VERSIONWSEXISTENCIAS"] != System.DBNull.Value)
                        {
                            retorno.IVERSIONWSEXISTENCIAS = (int)(dr["VERSIONWSEXISTENCIAS"]);
                        }


                        if (dr["MOSTRARINVINFOADICPROD"] != System.DBNull.Value)
                        {
                            retorno.IMOSTRARINVINFOADICPROD = (string)(dr["MOSTRARINVINFOADICPROD"]);
                        }

                        if(dr["TIPOSELECCIONCATALOGOSAT"] != System.DBNull.Value)
                        {
                            retorno.ITIPOSELECCIONCATALOGOSAT = dr["TIPOSELECCIONCATALOGOSAT"].ToString();
                        }


                        if (dr["PRECIONETOENGRIDS"] != System.DBNull.Value)
                        {
                            retorno.IPRECIONETOENGRIDS = (string)(dr["PRECIONETOENGRIDS"]);
                        }

                        

                        


                        if (dr["SAT_METODOPAGOID"] != System.DBNull.Value)
                        {
                            retorno.ISAT_METODOPAGOID = (long)(dr["SAT_METODOPAGOID"]);
                        }

                        if (dr["SAT_REGIMENFISCALID"] != System.DBNull.Value)
                        {
                            retorno.ISAT_REGIMENFISCALID = (long)(dr["SAT_REGIMENFISCALID"]);
                        }



                        if (dr["SAT_METODOPAGOCLAVE"] != System.DBNull.Value)
                        {
                            retorno.ISAT_METODOPAGOCLAVE = (string)(dr["SAT_METODOPAGOCLAVE"]);
                        }

                        if (dr["SAT_REGIMENFISCALCLAVE"] != System.DBNull.Value)
                        {
                            retorno.ISAT_REGIMENFISCALCLAVE = (string)(dr["SAT_REGIMENFISCALCLAVE"]);
                        }

                        if (dr["VERSIONCFDI"] != System.DBNull.Value)
                        {
                            retorno.IVERSIONCFDI = (string)(dr["VERSIONCFDI"]);
                        }

                        if (dr["PAGOSERVCONSOLIDADO"] != System.DBNull.Value)
                        {
                            retorno.IPAGOSERVCONSOLIDADO = (string)(dr["PAGOSERVCONSOLIDADO"]);
                        }

                        if (dr["MANEJAPRODUCTOSPROMOCION"] != System.DBNull.Value)
                        {
                            retorno.IMANEJAPRODUCTOSPROMOCION = (string)(dr["MANEJAPRODUCTOSPROMOCION"]);
                        }

                        if (dr["WSESPECIALEXISTMATRIZ"] != System.DBNull.Value)
                        {
                            retorno.IWSESPECIALEXISTMATRIZ = (string)(dr["WSESPECIALEXISTMATRIZ"]);
                        }

                        if (dr["GENERARFE"] != DBNull.Value)
                        {
                            retorno.IGENERARFE = (string)(dr["GENERARFE"]);
                        }

                        if (dr["RUTAREPLICADOREXE"] != System.DBNull.Value)
                        {
                            retorno.IRUTAREPLICADOREXE = (string)(dr["RUTAREPLICADOREXE"]);
                        }

                        if (dr["HAB_CONSOLIDADOAUTOMATICO"] != System.DBNull.Value)
                        {
                            retorno.IHAB_CONSOLIDADOAUTOMATICO = (string)(dr["HAB_CONSOLIDADOAUTOMATICO"]);
                        }


                        if (dr["ULT_CONSOLIDADOAUTOMATICO"] != System.DBNull.Value)
                        {
                            retorno.IULT_CONSOLIDADOAUTOMATICO = (DateTime)dr["ULT_CONSOLIDADOAUTOMATICO"];
                        }

                        if (dr["TICKETESPECIAL"] != System.DBNull.Value)
                        {
                            retorno.ITICKETESPECIAL = (string)(dr["TICKETESPECIAL"]);
                        }

                        if (dr["TICKETDEFAULTPRINTER"] != System.DBNull.Value)
                        {
                            retorno.ITICKETDEFAULTPRINTER = (string)(dr["TICKETDEFAULTPRINTER"]);
                        }

                        if (dr["RECARGASDEFAULTPRINTER"] != System.DBNull.Value)
                        {
                            retorno.IRECARGASDEFAULTPRINTER = (string)(dr["RECARGASDEFAULTPRINTER"]);
                        }

                        if (dr["PIEZACAJAENTICKET"] != System.DBNull.Value)
                        {
                            retorno.IPIEZACAJAENTICKET = (string)(dr["PIEZACAJAENTICKET"]);
                        }

                        if (dr["NUMTICKETSABONO"] != System.DBNull.Value)
                        {
                            retorno.INUMTICKETSABONO = (int)(dr["NUMTICKETSABONO"]);
                        }

                        if (dr["PVCOLOREAR"] != System.DBNull.Value)
                        {
                            retorno.IPVCOLOREAR = (int)(dr["PVCOLOREAR"]);
                        }

                        if (dr["INTENTOSRETIROCAJA"] != System.DBNull.Value)
                        {
                            retorno.IINTENTOSRETIROCAJA = (int)(dr["INTENTOSRETIROCAJA"]);
                        }

                        if (dr["VENDEDORMOVILCLAVE"] != System.DBNull.Value)
                        {
                            retorno.IVENDEDORMOVILCLAVE = (string)(dr["VENDEDORMOVILCLAVE"]);
                        }


                        if (dr["MOVIL_ULTCAM_SESION"] != System.DBNull.Value)
                        {
                            retorno.IMOVIL_ULTCAM_SESION = (DateTime)(dr["MOVIL_ULTCAM_SESION"]);
                        }

                        if (dr["MOVIL_TIENEVENDEDORES"] != System.DBNull.Value)
                        {
                            retorno.IMOVIL_TIENEVENDEDORES = (string)(dr["MOVIL_TIENEVENDEDORES"]);
                        }
                        if (dr["RUTACATALOGOSUPD"] != System.DBNull.Value)
                        {
                            retorno.IRUTACATALOGOSUPD = (string)(dr["RUTACATALOGOSUPD"]);
                        }

                        if (dr["IMPRIMIRCOPIAALMACEN"] != System.DBNull.Value)
                        {
                            retorno.IIMPRIMIRCOPIAALMACEN = (string)(dr["IMPRIMIRCOPIAALMACEN"]);
                        }

                        if (dr["MOVIL3_PREIMPORTAR"] != System.DBNull.Value)
                        {
                            retorno.IMOVIL3_PREIMPORTAR = (string)(dr["MOVIL3_PREIMPORTAR"]);
                        }
                        if (dr["RUTAIMPORTADATOS"] != System.DBNull.Value)
                        {
                            retorno.IRUTAIMPORTADATOS = (string)(dr["RUTAIMPORTADATOS"]);
                        }

                        if (dr["DESTINOBDVENMOV"] != DBNull.Value)
                        {
                            retorno.IDESTINOBDVENMOV = dr["DESTINOBDVENMOV"].ToString();
                        }

                        if (dr["BUSQUEDATIPO2"] != System.DBNull.Value)
                        {
                            retorno.IBUSQUEDATIPO2 = (string)(dr["BUSQUEDATIPO2"]);
                        }

                        if (dr["AGRUPACIONVENTAID"] != System.DBNull.Value)
                        {
                            retorno.IAGRUPACIONVENTAID = (long)(dr["AGRUPACIONVENTAID"]);
                        }


                        if (dr["CONSFACTOMITIRVALES"] != System.DBNull.Value)
                        {
                            retorno.ICONSFACTOMITIRVALES = (string)(dr["CONSFACTOMITIRVALES"]);
                        }


                        if (dr["DOBLECOPIACONTADO"] != System.DBNull.Value)
                        {
                            retorno.IDOBLECOPIACONTADO = (int)(dr["DOBLECOPIACONTADO"]);
                        }

                        if (dr["DESGLOSEIEPSFACTURA"] != DBNull.Value)
                        {
                            retorno.IDESGLOSEIEPSFACTURA = dr["DESGLOSEIEPSFACTURA"].ToString();
                        }
                        if (dr["RUTAPOLIZAPDF"] != System.DBNull.Value)
                        {
                            retorno.IRUTAPOLIZAPDF = (string)(dr["RUTAPOLIZAPDF"]);
                        }

                        if (dr["IMPRIMIRBANCOSCORTE"] != System.DBNull.Value)
                        {
                            retorno.IIMPRIMIRBANCOSCORTE = (string)(dr["IMPRIMIRBANCOSCORTE"]);
                        }

                        if (dr["IMPR_CANC_VENTA"] != System.DBNull.Value)
                        {
                            retorno.IIMPR_CANC_VENTA = (string)(dr["IMPR_CANC_VENTA"]);
                        }

                        if (dr["RETIROCAJAALCERRARCORTE"] != System.DBNull.Value)
                        {
                            retorno.IRETIROCAJAALCERRARCORTE = (string)(dr["RETIROCAJAALCERRARCORTE"]);
                        }

                        if (dr["PAGOTARJMENORPRECIOLISTAALL"] != System.DBNull.Value)
                        {
                            retorno.IPAGOTARJMENORPRECIOLISTAALL = (string)(dr["PAGOTARJMENORPRECIOLISTAALL"]);
                        }

                        if (dr["PREGUNTARSERVDOM"] != System.DBNull.Value)
                        {
                            retorno.IPREGUNTARSERVDOM = (string)(dr["PREGUNTARSERVDOM"]);
                        }

                        if (dr["HABPPC"] != System.DBNull.Value)
                        {
                            retorno.IHABPPC = (string)(dr["HABPPC"]);
                        }

                        if (dr["SOLOABONOAPLICADO"] != System.DBNull.Value)
                        {
                            retorno.ISOLOABONOAPLICADO = (string)(dr["SOLOABONOAPLICADO"]);
                        }

                        if (dr["VERSIONTOPEID"] != System.DBNull.Value)
                        {
                            retorno.IVERSIONTOPEID = (long)(dr["VERSIONTOPEID"]);
                        }

                        if (dr["VERSIONCOMISIONID"] != System.DBNull.Value)
                        {
                            retorno.IVERSIONCOMISIONID = (long)(dr["VERSIONCOMISIONID"]);
                        }


                        if (dr["MAXCOMISIONXCLIENTE"] != System.DBNull.Value)
                        {
                            retorno.IMAXCOMISIONXCLIENTE = (decimal)(dr["MAXCOMISIONXCLIENTE"]);
                        }

                        if (dr["IMPRFORMAVENTATRASL"] != System.DBNull.Value)
                        {
                            retorno.IIMPRFORMAVENTATRASL = (string)(dr["IMPRFORMAVENTATRASL"]);
                        }
                        if (dr["HABREVISIONFINAL"] != System.DBNull.Value)
                        {
                            retorno.IHABREVISIONFINAL = (string)(dr["HABREVISIONFINAL"]);
                        }

                        if (dr["RECIBOLARGOCOTIPRINTER"] != System.DBNull.Value)
                        {
                            retorno.IRECIBOLARGOCOTIPRINTER = (string)(dr["RECIBOLARGOCOTIPRINTER"]);
                        }

                        if (dr["HABFONDODINAMICO"] != System.DBNull.Value)
                        {
                            retorno.IHABFONDODINAMICO = (string)(dr["HABFONDODINAMICO"]);
                        }
                        if (dr["HABVENTACLISUC"] != System.DBNull.Value)
                        {
                            retorno.IHABVENTACLISUC = (string)(dr["HABVENTACLISUC"]);
                        }

                        if (dr["SEGUNDOSCICLOFTP"] != System.DBNull.Value)
                        {
                            retorno.ISEGUNDOSCICLOFTP = (int)(dr["SEGUNDOSCICLOFTP"]);
                        }

                        if (dr["DIASMAXEXPFTP"] != System.DBNull.Value)
                        {
                            retorno.IDIASMAXEXPFTP = (int)(dr["DIASMAXEXPFTP"]);
                        }

                        if (dr["DIASMAXIMPFTP"] != System.DBNull.Value)
                        {
                            retorno.IDIASMAXIMPFTP = (int)(dr["DIASMAXIMPFTP"]);
                        }

                        if (dr["WSDBF"] != System.DBNull.Value)
                        {
                            retorno.IWSDBF = (string)(dr["WSDBF"]);
                        }

                        if (dr["HABWSDBF"] != System.DBNull.Value)
                        {
                            retorno.IHABWSDBF = (string)(dr["HABWSDBF"]);
                        }



                        if (dr["FISCALFECHACANCELACION2"] != System.DBNull.Value)
                        {
                            retorno.IFISCALFECHACANCELACION2 = (DateTime)(dr["FISCALFECHACANCELACION2"]);
                        }

                        if (dr["CANTTICKETRETIRO"] != System.DBNull.Value)
                        {
                            retorno.ICANTTICKETRETIRO = (int)(dr["CANTTICKETRETIRO"]);
                        }

                        if (dr["COMISIONDEBPORTARJETA"] != System.DBNull.Value)
                        {
                            retorno.ICOMISIONDEBPORTARJETA = (decimal)(dr["COMISIONDEBPORTARJETA"]);
                        }

                        if (dr["DOBLECOPIATARJETA"] != System.DBNull.Value)
                        {
                            retorno.IDOBLECOPIATARJETA = (int)(dr["DOBLECOPIATARJETA"]);
                        }

                        if (dr["FACTCONSMAXPOR"] != System.DBNull.Value)
                        {
                            retorno.IFACTCONSMAXPOR = (decimal)(dr["FACTCONSMAXPOR"]);
                        }

                        if (dr["COMISIONDEBTARJETAEMPRESA"] != System.DBNull.Value)
                        {
                            retorno.ICOMISIONDEBTARJETAEMPRESA = (decimal)(dr["COMISIONDEBTARJETAEMPRESA"]);
                        }


                        if (dr["CANTTICKETABRIRCORTE"] != System.DBNull.Value)
                        {
                            retorno.ICANTTICKETABRIRCORTE = (int)(dr["CANTTICKETABRIRCORTE"]);
                        }

                        if (dr["CANTTICKETCOMPRAS"] != System.DBNull.Value)
                        {
                            retorno.ICANTTICKETCOMPRAS = (int)(dr["CANTTICKETCOMPRAS"]);
                        }

                        if (dr["CANTTICKETFONDOCAJA"] != System.DBNull.Value)
                        {
                            retorno.ICANTTICKETFONDOCAJA = (int)(dr["CANTTICKETFONDOCAJA"]);
                        }

                        if (dr["CANTTICKETGASTOS"] != System.DBNull.Value)
                        {
                            retorno.ICANTTICKETGASTOS = (int)(dr["CANTTICKETGASTOS"]);
                        }

                        if (dr["CANTTICKETDEPOSITOS"] != System.DBNull.Value)
                        {
                            retorno.ICANTTICKETDEPOSITOS = (int)(dr["CANTTICKETDEPOSITOS"]);
                        }

                        if (dr["CANTTICKETCIERRECORTE"] != System.DBNull.Value)
                        {
                            retorno.ICANTTICKETCIERRECORTE = (int)(dr["CANTTICKETCIERRECORTE"]);
                        }

                        if (dr["CANTTICKETCIERREBILLETES"] != System.DBNull.Value)
                        {
                            retorno.ICANTTICKETCIERREBILLETES = (int)(dr["CANTTICKETCIERREBILLETES"]);
                        }


                        if (dr["MANEJAUTILIDADPRECIOS"] != System.DBNull.Value)
                        {
                            retorno.IMANEJAUTILIDADPRECIOS = (string)(dr["MANEJAUTILIDADPRECIOS"]);
                        }

                        if (dr["HABMULTPLAZOCOMPRA"] != System.DBNull.Value)
                        {
                            retorno.IHABMULTPLAZOCOMPRA = (string)(dr["HABMULTPLAZOCOMPRA"]);
                        }

                        if (dr["COSTOREPOIGUALCOSTOULT"] != System.DBNull.Value)
                        {
                            retorno.ICOSTOREPOIGUALCOSTOULT = (string)(dr["COSTOREPOIGUALCOSTOULT"]);
                        }

                        if (dr["TICKET_DESC_VALE_AL_FINAL"] != System.DBNull.Value)
                        {
                            retorno.ITICKET_DESC_VALE_AL_FINAL = (string)(dr["TICKET_DESC_VALE_AL_FINAL"]);
                        }


                        if (dr["MONEDEROLISTAPRECIOID"] != System.DBNull.Value)
                        {
                            retorno.IMONEDEROLISTAPRECIOID = (long)(dr["MONEDEROLISTAPRECIOID"]);
                        }


                        if (dr["MONEDEROCAMPOREF"] != System.DBNull.Value)
                        {
                            retorno.IMONEDEROCAMPOREF = (string)(dr["MONEDEROCAMPOREF"]);
                        }


                        if (dr["HABSURTIDOPREVIO"] != System.DBNull.Value)
                        {
                            retorno.IHABSURTIDOPREVIO = (string)(dr["HABSURTIDOPREVIO"]);
                        }
                        else
                        {
                            retorno.IHABSURTIDOPREVIO = "N";
                        }


                        if (dr["NUMTICKETSCOMANDA"] != System.DBNull.Value)
                        {
                            retorno.INUMTICKETSCOMANDA = (int)(dr["NUMTICKETSCOMANDA"]);
                        }
                        else
                        {
                            retorno.INUMTICKETSCOMANDA = 1;
                        }


                        if (dr["TICKET_IMPR_DESC2"] != System.DBNull.Value)
                        {
                            retorno.ITICKET_IMPR_DESC2 = (string)(dr["TICKET_IMPR_DESC2"]);
                        }
                        else
                        {
                            retorno.IHABSURTIDOPREVIO = "N";
                        }


                        if (dr["SERIECOMPRTRASLSAT"] != System.DBNull.Value)
                        {
                            retorno.ISERIECOMPRTRASLSAT = (string)(dr["SERIECOMPRTRASLSAT"]);
                        }

                        if (dr["HABSURTIDOPOSTMOVIL"] != System.DBNull.Value)
                        {
                            retorno.IHABSURTIDOPOSTMOVIL = (string)(dr["HABSURTIDOPOSTMOVIL"]);
                        }
                        else
                        {
                            retorno.IHABSURTIDOPOSTMOVIL = "N";
                        }

                        if (dr["PORCUTILIDADLISTADO"] != System.DBNull.Value)
                        {
                            retorno.IPORCUTILIDADLISTADO = (decimal)(dr["PORCUTILIDADLISTADO"]);
                        }
                        else
                        {
                            retorno.IPORCUTILIDADLISTADO = 0m;
                        }


                        if (dr["RUTAFIRMAIMAGENES"] != System.DBNull.Value)
                        {
                            retorno.IRUTAFIRMAIMAGENES = (string)(dr["RUTAFIRMAIMAGENES"]);
                        }


                        if (dr["LISTAPRECIOMAYLINEA"] != System.DBNull.Value)
                        {
                            retorno.ILISTAPRECIOMAYLINEA = (long)(dr["LISTAPRECIOMAYLINEA"]);
                        }

                        if (dr["LISTAPRECMEDMAYLINEA"] != System.DBNull.Value)
                        {
                            retorno.ILISTAPRECMEDMAYLINEA = (long)(dr["LISTAPRECMEDMAYLINEA"]);
                        }

                        if (dr["AUTPRECIOLISTABAJO"] != System.DBNull.Value)
                        {
                            retorno.IAUTPRECIOLISTABAJO = (string)(dr["AUTPRECIOLISTABAJO"]);
                        }


                        if (dr["PORCUTILMACROLISTADO"] != System.DBNull.Value)
                        {
                            retorno.IPORCUTILMACROLISTADO = (decimal)(dr["PORCUTILMACROLISTADO"]);
                        }
                        else
                        {
                            retorno.IPORCUTILMACROLISTADO = 0m;
                        }


                    }
                    catch (Exception ex)
                    {
                        
                    }
                }
                else
                {
                    retorno = null;
                }

                SqlHelper.CloseReader(dr, pcn);

                return retorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public DateTime seleccionarLASTCHANGEPRODDESC(FbTransaction st)
        {

            DateTime retorno = DateTime.Now;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                String CmdTxt = @"select p.LASTCHANGEPRODDESC from PARAMETRO p";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                   

                    if (dr["LASTCHANGEPRODDESC"] != System.DBNull.Value)
                    {
                        retorno = (DateTime)dr["LASTCHANGEPRODDESC"];
                    }

                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);



                return retorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return retorno;
            }



        }


        public DateTime seleccionarLASTCHANGECLIENTENOMBRE(FbTransaction st)
        {

            DateTime retorno = DateTime.Now;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                String CmdTxt = @"select p.LASTCHANGECLIENTENOMBRE from PARAMETRO p";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {



                    if (dr["LASTCHANGECLIENTENOMBRE"] != System.DBNull.Value)
                    {
                        retorno = (DateTime)dr["LASTCHANGECLIENTENOMBRE"];
                    }

                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);



                return retorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return retorno;
            }



        }



        [AutoComplete]
        public DataSet enlistarPARAMETRO()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PARAMETRO_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoPARAMETRO()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PARAMETRO_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExistePARAMETRO(CPARAMETROBE oCPARAMETRO, FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                //FbParameter auxPar;

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @" select * from PARAMETRO ";



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




        public CPARAMETROBE AgregarPARAMETRO(CPARAMETROBE oCPARAMETRO, FbTransaction st)
        {
            try
            {
                int iRes = ExistePARAMETRO(oCPARAMETRO, st);
                if (iRes == 1)
                {
                    this.IComentario = "El PARAMETRO ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarPARAMETROD(oCPARAMETRO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarPARAMETRO(CPARAMETROBE oCPARAMETRO, FbTransaction st)
        {
            try
            {
                int iRes = ExistePARAMETRO(oCPARAMETRO, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PARAMETRO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarPARAMETROD(oCPARAMETRO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarPARAMETRO(CPARAMETROBE oCPARAMETRONuevo, CPARAMETROBE oCPARAMETROAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExistePARAMETRO(oCPARAMETROAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PARAMETRO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarPARAMETROD(oCPARAMETRONuevo, oCPARAMETROAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool SetIposInstallationType(CPARAMETROBE oCPARAMETRO, FbTransaction st)
        {

            DBValues._IPOSTYPE = oCPARAMETRO.IIPOS_TYPE;

            System.Collections.ArrayList excludedMenus = new ArrayList();
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;
 
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@IPOSTYPEID", FbDbType.BigInt);
                auxPar.Value = oCPARAMETRO.IIPOS_TYPE;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @" select * from IPOSNOMENU where IPOSTYPEID = @IPOSTYPEID ";



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, commandText, arParms);



                while (dr.Read())
                {

                    if (dr["MENUID"] != System.DBNull.Value)
                    {
                        excludedMenus.Add((int)(dr["MENUID"]));
                    }
                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                DBValues._MENUS_EXCLUDED = new int[excludedMenus.Count];
                excludedMenus.CopyTo(DBValues._MENUS_EXCLUDED, 0);

                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }






        public bool TESTING_RESETEARBD(FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"TESTING_RESETEARBD";

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




        public bool CambiarMOVILCIERRECOBRANZA(CPARAMETROBE oCPARAMETRONuevo, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@MOVILCIERRECOBRANZA", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IMOVILCIERRECOBRANZA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IMOVILCIERRECOBRANZA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
                                        update  PARAMETRO
                                        set MOVILCIERRECOBRANZA = @MOVILCIERRECOBRANZA
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



        public bool CambiarMOVILCIERREVENTA(CPARAMETROBE oCPARAMETRONuevo, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@MOVILCIERREVENTA", FbDbType.VarChar);
                if (!(bool)oCPARAMETRONuevo.isnull["IMOVILCIERREVENTA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IMOVILCIERREVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
                                        update  PARAMETRO
                                        set MOVILCIERREVENTA = @MOVILCIERREVENTA
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

        public bool CambiarFECHAACTUALIZACIONEMIDA(CPARAMETROBE oCPARAMETRONuevo, CPARAMETROBE oCPARAMETROAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@FECHAACTUALIZACIONEMIDA", FbDbType.Date);
                if (!(bool)oCPARAMETRONuevo.isnull["IFECHAACTUALIZACIONEMIDA"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IFECHAACTUALIZACIONEMIDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  PARAMETRO
  set FECHAACTUALIZACIONEMIDA = @FECHAACTUALIZACIONEMIDA
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








        public bool CambiarFECHAACTUALIZACIONEMIDASERV(CPARAMETROBE oCPARAMETRONuevo, CPARAMETROBE oCPARAMETROAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@FECHAACTUALIZACIONEMIDASERV", FbDbType.Date);
                if (!(bool)oCPARAMETRONuevo.isnull["IFECHAACTUALIZACIONEMIDASERV"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IFECHAACTUALIZACIONEMIDASERV;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  PARAMETRO
  set FECHAACTUALIZACIONEMIDASERV = @FECHAACTUALIZACIONEMIDASERV
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



        public bool CambiarULTMENSAJEID(CPARAMETROBE oCPARAMETRONuevo, CPARAMETROBE oCPARAMETROAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ULTMENSAJEID", FbDbType.BigInt);
                if (!(bool)oCPARAMETRONuevo.isnull["IULTMENSAJEID"])
                {
                    auxPar.Value = oCPARAMETRONuevo.IULTMENSAJEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  PARAMETRO
  set ULTMENSAJEID = @ULTMENSAJEID
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

        public bool CambiarNUMCANCELACTAUTOUSUARIO(CPARAMETROBE oCPARAMETRONuevo, CPARAMETROBE oCPARAMETROAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@NUMCANCELACTAUTOUSUARIO", FbDbType.BigInt);
                if (!(bool)oCPARAMETRONuevo.isnull["INUMCANCELACTAUTOUSUARIO"])
                {
                    auxPar.Value = oCPARAMETRONuevo.INUMCANCELACTAUTOUSUARIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  PARAMETRO
  set NUMCANCELACTAUTOUSUARIO = @NUMCANCELACTAUTOUSUARIO
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


        public CPARAMETROD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
        }
    }
}
