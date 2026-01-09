

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



    public class CCACHE_PRODMOVILD
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


        public CCACHE_PRODMOVILBE AgregarCACHE_PRODMOVILD(CCACHE_PRODMOVILBE oCCACHE_PRODMOVIL, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["IACTIVO"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ICLAVE"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["INOMBRE"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["IDESCRIPCION"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@EAN", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["IEAN"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.IEAN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION1", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["IDESCRIPCION1"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.IDESCRIPCION1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION2", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["IDESCRIPCION2"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.IDESCRIPCION2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION3", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["IDESCRIPCION3"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.IDESCRIPCION3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PROVEEDOR1ID", FbDbType.Integer);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["IPROVEEDOR1ID"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.IPROVEEDOR1ID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PROVEEDOR2ID", FbDbType.Integer);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["IPROVEEDOR2ID"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.IPROVEEDOR2ID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE_LINEA", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ICLAVE_LINEA"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ICLAVE_LINEA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE_MARCA", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ICLAVE_MARCA"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ICLAVE_MARCA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO1", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["IPRECIO1"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.IPRECIO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO2", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["IPRECIO2"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.IPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO3", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["IPRECIO3"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.IPRECIO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO4", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["IPRECIO4"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.IPRECIO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO5", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["IPRECIO5"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.IPRECIO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TASAIVAID", FbDbType.BigInt);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ITASAIVAID"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ITASAIVAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TASAIVA", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ITASAIVA"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ITASAIVA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE_MONEDA", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ICLAVE_MONEDA"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ICLAVE_MONEDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COSTOREPOSICION", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ICOSTOREPOSICION"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ICOSTOREPOSICION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COSTOULTIMO", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ICOSTOULTIMO"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ICOSTOULTIMO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COSTOPROMEDIO", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ICOSTOPROMEDIO"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ICOSTOPROMEDIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE_SUSTITUTO", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ICLAVE_SUSTITUTO"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ICLAVE_SUSTITUTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MANEJALOTE", FbDbType.Char);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["IMANEJALOTE"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.IMANEJALOTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESKIT", FbDbType.Char);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["IESKIT"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.IESKIT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPRIMIR", FbDbType.Char);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["IIMPRIMIR"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.IIMPRIMIR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@INVENTARIABLE", FbDbType.Char);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["IINVENTARIABLE"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.IINVENTARIABLE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NEGATIVOS", FbDbType.Char);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["INEGATIVOS"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.INEGATIVOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LIMITEPRECIO2", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ILIMITEPRECIO2"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ILIMITEPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIOMAXIMOPUBLICO", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["IPRECIOMAXIMOPUBLICO"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.IPRECIOMAXIMOPUBLICO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE_PROVEEDOR1", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ICLAVE_PROVEEDOR1"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ICLAVE_PROVEEDOR1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE_PROVEEDOR2", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ICLAVE_PROVEEDOR2"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ICLAVE_PROVEEDOR2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMBIARPRECIO", FbDbType.Char);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ICAMBIARPRECIO"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ICAMBIARPRECIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUBSTITUTO", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ISUBSTITUTO"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ISUBSTITUTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CBARRAS", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ICBARRAS"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ICBARRAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CEMPAQUE", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ICEMPAQUE"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ICEMPAQUE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PZACAJA", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["IPZACAJA"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.IPZACAJA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@U_EMPAQUE", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["IU_EMPAQUE"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.IU_EMPAQUE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@UNIDAD", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["IUNIDAD"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.IUNIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@INI_MAYO", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["IINI_MAYO"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.IINI_MAYO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MAYOKGS", FbDbType.Char);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["IMAYOKGS"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.IMAYOKGS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOABC", FbDbType.Char);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ITIPOABC"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ITIPOABC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE_TASAIVA", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ICLAVE_TASAIVA"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ICLAVE_TASAIVA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TEXTO1", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ITEXTO1"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ITEXTO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TEXTO2", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ITEXTO2"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ITEXTO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TEXTO3", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ITEXTO3"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ITEXTO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TEXTO4", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ITEXTO4"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ITEXTO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TEXTO5", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ITEXTO5"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ITEXTO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TEXTO6", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ITEXTO6"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ITEXTO6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUMERO1", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["INUMERO1"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.INUMERO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUMERO2", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["INUMERO2"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.INUMERO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUMERO3", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["INUMERO3"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.INUMERO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUMERO4", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["INUMERO4"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.INUMERO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHA1", FbDbType.Date);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["IFECHA1"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.IFECHA1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHA2", FbDbType.Date);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["IFECHA2"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.IFECHA2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE_PRODUCTOPADRE", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ICLAVE_PRODUCTOPADRE"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ICLAVE_PRODUCTOPADRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESPRODUCTOPADRE", FbDbType.Char);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["IESPRODUCTOPADRE"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.IESPRODUCTOPADRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESPRODUCTOFINAL", FbDbType.Char);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["IESPRODUCTOFINAL"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.IESPRODUCTOFINAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESSUBPRODUCTO", FbDbType.Char);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["IESSUBPRODUCTO"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.IESSUBPRODUCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TOMARPRECIOPADRE", FbDbType.Char);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ITOMARPRECIOPADRE"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ITOMARPRECIOPADRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TOMARCOMISIONPADRE", FbDbType.Char);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ITOMARCOMISIONPADRE"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ITOMARCOMISIONPADRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TOMAROFERTAPADRE", FbDbType.Char);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ITOMAROFERTAPADRE"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ITOMAROFERTAPADRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COMISION", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ICOMISION"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ICOMISION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@OFERTA", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["IOFERTA"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.IOFERTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PLUG", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["IPLUG"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.IPLUG;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TASAIEPS", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ITASAIEPS"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ITASAIEPS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MINUTILIDAD", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["IMINUTILIDAD"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.IMINUTILIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@AUTO_INSERT_FK", FbDbType.Char);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["IAUTO_INSERT_FK"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.IAUTO_INSERT_FK;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SPRECIO1", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ISPRECIO1"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ISPRECIO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SPRECIO2", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ISPRECIO2"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ISPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SPRECIO3", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ISPRECIO3"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ISPRECIO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SPRECIO4", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ISPRECIO4"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ISPRECIO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SPRECIO5", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ISPRECIO5"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ISPRECIO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQUIERERECETA", FbDbType.Char);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["IREQUIERERECETA"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.IREQUIERERECETA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLASIFICA", FbDbType.Char);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ICLASIFICA"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ICLASIFICA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PROMOMOVIL", FbDbType.Char);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["IPROMOMOVIL"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.IPROMOMOVIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MARGENMOVIL", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["IMARGENMOVIL"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.IMARGENMOVIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MPRECIO4MOVIL", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["IMPRECIO4MOVIL"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.IMPRECIO4MOVIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CPRECIO4MOVIL", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ICPRECIO4MOVIL"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ICPRECIO4MOVIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TPRECIO4MOVIL", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ITPRECIO4MOVIL"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ITPRECIO4MOVIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@APRECIO4MOVIL", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["IAPRECIO4MOVIL"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.IAPRECIO4MOVIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDAD", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LOTE", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["ILOTE"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.ILOTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAVENCE", FbDbType.Date);
                if (!(bool)oCCACHE_PRODMOVIL.isnull["IFECHAVENCE"])
                {
                    auxPar.Value = oCCACHE_PRODMOVIL.IFECHAVENCE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO CACHE_PRODMOVIL
      (
    
ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

CLAVE,

NOMBRE,

DESCRIPCION,

EAN,

DESCRIPCION1,

DESCRIPCION2,

DESCRIPCION3,

PROVEEDOR1ID,

PROVEEDOR2ID,

CLAVE_LINEA,

CLAVE_MARCA,

PRECIO1,

PRECIO2,

PRECIO3,

PRECIO4,

PRECIO5,

TASAIVAID,

TASAIVA,

CLAVE_MONEDA,

COSTOREPOSICION,

COSTOULTIMO,

COSTOPROMEDIO,

CLAVE_SUSTITUTO,

MANEJALOTE,

ESKIT,

IMPRIMIR,

INVENTARIABLE,

NEGATIVOS,

LIMITEPRECIO2,

PRECIOMAXIMOPUBLICO,

CLAVE_PROVEEDOR1,

CLAVE_PROVEEDOR2,

CAMBIARPRECIO,

SUBSTITUTO,

CBARRAS,

CEMPAQUE,

PZACAJA,

U_EMPAQUE,

UNIDAD,

INI_MAYO,

MAYOKGS,

TIPOABC,

CLAVE_TASAIVA,

TEXTO1,

TEXTO2,

TEXTO3,

TEXTO4,

TEXTO5,

TEXTO6,

NUMERO1,

NUMERO2,

NUMERO3,

NUMERO4,

FECHA1,

FECHA2,

CLAVE_PRODUCTOPADRE,

ESPRODUCTOPADRE,

ESPRODUCTOFINAL,

ESSUBPRODUCTO,

TOMARPRECIOPADRE,

TOMARCOMISIONPADRE,

TOMAROFERTAPADRE,

COMISION,

OFERTA,

PLUG,

TASAIEPS,

MINUTILIDAD,

AUTO_INSERT_FK,

SPRECIO1,

SPRECIO2,

SPRECIO3,

SPRECIO4,

SPRECIO5,

REQUIERERECETA,

CLASIFICA,

PROMOMOVIL,

MARGENMOVIL,

MPRECIO4MOVIL,

CPRECIO4MOVIL,

TPRECIO4MOVIL,

APRECIO4MOVIL,

CANTIDAD,

LOTE,

FECHAVENCE
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@CLAVE,

@NOMBRE,

@DESCRIPCION,

@EAN,

@DESCRIPCION1,

@DESCRIPCION2,

@DESCRIPCION3,

@PROVEEDOR1ID,

@PROVEEDOR2ID,

@CLAVE_LINEA,

@CLAVE_MARCA,

@PRECIO1,

@PRECIO2,

@PRECIO3,

@PRECIO4,

@PRECIO5,

@TASAIVAID,

@TASAIVA,

@CLAVE_MONEDA,

@COSTOREPOSICION,

@COSTOULTIMO,

@COSTOPROMEDIO,

@CLAVE_SUSTITUTO,

@MANEJALOTE,

@ESKIT,

@IMPRIMIR,

@INVENTARIABLE,

@NEGATIVOS,

@LIMITEPRECIO2,

@PRECIOMAXIMOPUBLICO,

@CLAVE_PROVEEDOR1,

@CLAVE_PROVEEDOR2,

@CAMBIARPRECIO,

@SUBSTITUTO,

@CBARRAS,

@CEMPAQUE,

@PZACAJA,

@U_EMPAQUE,

@UNIDAD,

@INI_MAYO,

@MAYOKGS,

@TIPOABC,

@CLAVE_TASAIVA,

@TEXTO1,

@TEXTO2,

@TEXTO3,

@TEXTO4,

@TEXTO5,

@TEXTO6,

@NUMERO1,

@NUMERO2,

@NUMERO3,

@NUMERO4,

@FECHA1,

@FECHA2,

@CLAVE_PRODUCTOPADRE,

@ESPRODUCTOPADRE,

@ESPRODUCTOFINAL,

@ESSUBPRODUCTO,

@TOMARPRECIOPADRE,

@TOMARCOMISIONPADRE,

@TOMAROFERTAPADRE,

@COMISION,

@OFERTA,

@PLUG,

@TASAIEPS,

@MINUTILIDAD,

@AUTO_INSERT_FK,

@SPRECIO1,

@SPRECIO2,

@SPRECIO3,

@SPRECIO4,

@SPRECIO5,

@REQUIERERECETA,

@CLASIFICA,

@PROMOMOVIL,

@MARGENMOVIL,

@MPRECIO4MOVIL,

@CPRECIO4MOVIL,

@TPRECIO4MOVIL,

@APRECIO4MOVIL,

@CANTIDAD,

@LOTE,

@FECHAVENCE
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCCACHE_PRODMOVIL;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }





        public bool CACHEPROD_IMPORTAR_MOVIL(FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"CACHEPROD_IMPORTAR_MOVIL";

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



        public bool importarCACHE_PRODUCTODMOVIL(CPRODUCTOBE oCPRODUCTO, string p_claveLinea, string p_claveMarca, string p_claveMoneda, string p_claveSustituto, string p_proveedor1, string p_proveedor2, string p_claveTasaIva, string p_claveProductoPadre, decimal cantidad, string lote, DateTime fechavence, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ICLAVE"])
                {
                    auxPar.Value = oCPRODUCTO.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["INOMBRE"])
                {
                    auxPar.Value = oCPRODUCTO.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IDESCRIPCION"])
                {
                    auxPar.Value = oCPRODUCTO.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@EAN", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IEAN"])
                {
                    auxPar.Value = oCPRODUCTO.IEAN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION1", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IDESCRIPCION1"])
                {
                    auxPar.Value = oCPRODUCTO.IDESCRIPCION1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION2", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IDESCRIPCION2"])
                {
                    auxPar.Value = oCPRODUCTO.IDESCRIPCION2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION3", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IDESCRIPCION3"])
                {
                    auxPar.Value = oCPRODUCTO.IDESCRIPCION3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PROVEEDOR1ID", FbDbType.Integer);
                if (!(bool)oCPRODUCTO.isnull["IPROVEEDOR1ID"])
                {
                    auxPar.Value = oCPRODUCTO.IPROVEEDOR1ID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PROVEEDOR2ID", FbDbType.Integer);
                if (!(bool)oCPRODUCTO.isnull["IPROVEEDOR2ID"])
                {
                    auxPar.Value = oCPRODUCTO.IPROVEEDOR2ID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE_LINEA", FbDbType.VarChar);
                auxPar.Value = p_claveLinea;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE_MARCA", FbDbType.VarChar);
                auxPar.Value = p_claveMarca;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO1", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIO1"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO2", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIO2"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO3", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIO3"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO4", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIO4"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO5", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIO5"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TASAIVAID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTO.isnull["ITASAIVAID"])
                {
                    auxPar.Value = oCPRODUCTO.ITASAIVAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TASAIVA", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ITASAIVA"])
                {
                    auxPar.Value = oCPRODUCTO.ITASAIVA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE_MONEDA", FbDbType.VarChar);
                auxPar.Value = p_claveMoneda;
                parts.Add(auxPar);


                auxPar = new FbParameter("@COSTOREPOSICION", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ICOSTOREPOSICION"])
                {
                    auxPar.Value = oCPRODUCTO.ICOSTOREPOSICION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COSTOULTIMO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ICOSTOULTIMO"])
                {
                    auxPar.Value = oCPRODUCTO.ICOSTOULTIMO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COSTOPROMEDIO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ICOSTOPROMEDIO"])
                {
                    auxPar.Value = oCPRODUCTO.ICOSTOPROMEDIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE_SUSTITUTO", FbDbType.VarChar);
                auxPar.Value = p_claveSustituto;
                parts.Add(auxPar);


                auxPar = new FbParameter("@MANEJALOTE", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IMANEJALOTE"] && oCPRODUCTO.IMANEJALOTE.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.IMANEJALOTE;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESKIT", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IESKIT"] && oCPRODUCTO.IESKIT.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.IESKIT;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPRIMIR", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IIMPRIMIR"] && oCPRODUCTO.IIMPRIMIR.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.IIMPRIMIR;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@INVENTARIABLE", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IINVENTARIABLE"] && oCPRODUCTO.IINVENTARIABLE.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.IINVENTARIABLE;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NEGATIVOS", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["INEGATIVOS"] && oCPRODUCTO.INEGATIVOS.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.INEGATIVOS;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LIMITEPRECIO2", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ILIMITEPRECIO2"])
                {
                    auxPar.Value = oCPRODUCTO.ILIMITEPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIOMAXIMOPUBLICO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIOMAXIMOPUBLICO"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIOMAXIMOPUBLICO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE_PROVEEDOR1", FbDbType.VarChar);
                auxPar.Value = p_proveedor1;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE_PROVEEDOR2", FbDbType.VarChar);
                auxPar.Value = p_proveedor2;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMBIARPRECIO", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["ICAMBIARPRECIO"] && oCPRODUCTO.ICAMBIARPRECIO.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.ICAMBIARPRECIO;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUBSTITUTO", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ISUBSTITUTO"])
                {
                    auxPar.Value = oCPRODUCTO.ISUBSTITUTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CBARRAS", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ICBARRAS"])
                {
                    auxPar.Value = oCPRODUCTO.ICBARRAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CEMPAQUE", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ICEMPAQUE"])
                {
                    auxPar.Value = oCPRODUCTO.ICEMPAQUE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PZACAJA", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPZACAJA"])
                {
                    auxPar.Value = oCPRODUCTO.IPZACAJA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@U_EMPAQUE", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IU_EMPAQUE"])
                {
                    auxPar.Value = oCPRODUCTO.IU_EMPAQUE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@UNIDAD", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IUNIDAD"])
                {
                    auxPar.Value = oCPRODUCTO.IUNIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@INI_MAYO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IINI_MAYO"])
                {
                    auxPar.Value = oCPRODUCTO.IINI_MAYO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MAYOKGS", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IMAYOKGS"])
                {
                    auxPar.Value = oCPRODUCTO.IMAYOKGS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOABC", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["ITIPOABC"])
                {
                    auxPar.Value = oCPRODUCTO.ITIPOABC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@CLAVE_TASAIVA", FbDbType.VarChar);
                auxPar.Value = p_claveTasaIva;
                parts.Add(auxPar);





                auxPar = new FbParameter("@TEXTO1", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ITEXTO1"])
                {
                    auxPar.Value = oCPRODUCTO.ITEXTO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TEXTO2", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ITEXTO2"])
                {
                    auxPar.Value = oCPRODUCTO.ITEXTO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TEXTO3", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ITEXTO3"])
                {
                    auxPar.Value = oCPRODUCTO.ITEXTO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TEXTO4", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ITEXTO4"])
                {
                    auxPar.Value = oCPRODUCTO.ITEXTO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TEXTO5", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ITEXTO5"])
                {
                    auxPar.Value = oCPRODUCTO.ITEXTO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TEXTO6", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ITEXTO6"])
                {
                    auxPar.Value = oCPRODUCTO.ITEXTO6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUMERO1", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["INUMERO1"])
                {
                    auxPar.Value = oCPRODUCTO.INUMERO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMERO2", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["INUMERO2"])
                {
                    auxPar.Value = oCPRODUCTO.INUMERO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMERO3", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["INUMERO3"])
                {
                    auxPar.Value = oCPRODUCTO.INUMERO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMERO4", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["INUMERO4"])
                {
                    auxPar.Value = oCPRODUCTO.INUMERO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHA1", FbDbType.Date);
                if (!(bool)oCPRODUCTO.isnull["IFECHA1"])
                {
                    auxPar.Value = oCPRODUCTO.IFECHA1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHA2", FbDbType.Date);
                if (!(bool)oCPRODUCTO.isnull["IFECHA2"])
                {
                    auxPar.Value = oCPRODUCTO.IFECHA2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@CLAVE_PRODUCTOPADRE", FbDbType.VarChar);
                auxPar.Value = p_claveProductoPadre;
                parts.Add(auxPar);




                auxPar = new FbParameter("@ESPRODUCTOPADRE", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IESPRODUCTOPADRE"])
                {
                    auxPar.Value = oCPRODUCTO.IESPRODUCTOPADRE;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESPRODUCTOFINAL", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IESPRODUCTOFINAL"])
                {
                    auxPar.Value = oCPRODUCTO.IESPRODUCTOFINAL;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESSUBPRODUCTO", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IESSUBPRODUCTO"])
                {
                    auxPar.Value = oCPRODUCTO.IESSUBPRODUCTO;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@TOMARPRECIOPADRE", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["ITOMARPRECIOPADRE"])
                {
                    auxPar.Value = oCPRODUCTO.ITOMARPRECIOPADRE;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TOMARCOMISIONPADRE", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["ITOMARCOMISIONPADRE"])
                {
                    if (oCPRODUCTO.ITOMARCOMISIONPADRE.Trim().Length > 0)
                        auxPar.Value = oCPRODUCTO.ITOMARCOMISIONPADRE;
                    else
                        auxPar.Value = "N";

                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TOMAROFERTAPADRE", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["ITOMAROFERTAPADRE"])
                {
                    auxPar.Value = oCPRODUCTO.ITOMAROFERTAPADRE;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@COMISION", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ICOMISION"])
                {
                    auxPar.Value = oCPRODUCTO.ICOMISION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@OFERTA", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IOFERTA"])
                {
                    auxPar.Value = oCPRODUCTO.IOFERTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PLUG", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IPLUG"])
                {
                    auxPar.Value = oCPRODUCTO.IPLUG;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@TASAIEPS", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ITASAIEPS"])
                {
                    auxPar.Value = oCPRODUCTO.ITASAIEPS;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MINUTILIDAD", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IMINUTILIDAD"])
                {
                    auxPar.Value = oCPRODUCTO.IMINUTILIDAD;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@AUTO_INSERT_FK", FbDbType.Char);
                auxPar.Value = DBValues._DB_BOOLVALUE_SI;
                parts.Add(auxPar);


                auxPar = new FbParameter("@SPRECIO1", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ISPRECIO1"])
                {
                    auxPar.Value = oCPRODUCTO.ISPRECIO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SPRECIO2", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ISPRECIO2"])
                {
                    auxPar.Value = oCPRODUCTO.ISPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SPRECIO3", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ISPRECIO3"])
                {
                    auxPar.Value = oCPRODUCTO.ISPRECIO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SPRECIO4", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ISPRECIO4"])
                {
                    auxPar.Value = oCPRODUCTO.ISPRECIO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SPRECIO5", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ISPRECIO5"])
                {
                    auxPar.Value = oCPRODUCTO.ISPRECIO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQUIERERECETA", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IREQUIERERECETA"])
                {
                    auxPar.Value = oCPRODUCTO.IREQUIERERECETA;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLASIFICA", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["ICLASIFICA"])
                {
                    auxPar.Value = oCPRODUCTO.ICLASIFICA;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@PROMOMOVIL", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IPROMOMOVIL"])
                {
                    auxPar.Value = oCPRODUCTO.IPROMOMOVIL;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MARGENMOVIL", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IMARGENMOVIL"])
                {
                    auxPar.Value = oCPRODUCTO.IMARGENMOVIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MPRECIO4MOVIL", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IMPRECIO4MOVIL"])
                {
                    auxPar.Value = oCPRODUCTO.IMPRECIO4MOVIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CPRECIO4MOVIL", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ICPRECIO4MOVIL"])
                {
                    auxPar.Value = oCPRODUCTO.ICPRECIO4MOVIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TPRECIO4MOVIL", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ITPRECIO4MOVIL"])
                {
                    auxPar.Value = oCPRODUCTO.ITPRECIO4MOVIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@APRECIO4MOVIL", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IAPRECIO4MOVIL"])
                {
                    auxPar.Value = oCPRODUCTO.IAPRECIO4MOVIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDAD", FbDbType.Numeric);
                auxPar.Value = cantidad;
                parts.Add(auxPar);



                auxPar = new FbParameter("@LOTE", FbDbType.VarChar);
                if (lote == null || lote.Equals(""))
                    auxPar.Value = DBNull.Value;
                else
                    auxPar.Value = lote;
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAVENCE", FbDbType.Date);
                if (fechavence == DateTime.MinValue)
                {
                    auxPar.Value = DBNull.Value;
                }
                else
                {
                    auxPar.Value = fechavence;
                }
                parts.Add(auxPar);




                /*auxPar = new FbParameter("@SAT_PRODUCTOSERVICIOID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTO.isnull["ISAT_PRODUCTOSERVICIOID"])
                {
                    auxPar.Value = oCPRODUCTO.ISAT_PRODUCTOSERVICIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);*/

                /*auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);*/




                string commandText = @"
        INSERT INTO CACHE_PRODMOVIL
      (

CLAVE,

NOMBRE,

DESCRIPCION,

EAN,

DESCRIPCION1,

DESCRIPCION2,

DESCRIPCION3,

PROVEEDOR1ID,

PROVEEDOR2ID,

CLAVE_LINEA,

CLAVE_MARCA,

PRECIO1,

PRECIO2,

PRECIO3,

PRECIO4,

PRECIO5,

TASAIVAID,

TASAIVA,

CLAVE_MONEDA,

COSTOREPOSICION,

COSTOULTIMO,

COSTOPROMEDIO,

CLAVE_SUSTITUTO,

MANEJALOTE,

ESKIT,

IMPRIMIR,

INVENTARIABLE,

NEGATIVOS,

LIMITEPRECIO2,

PRECIOMAXIMOPUBLICO,

CLAVE_PROVEEDOR1,

CLAVE_PROVEEDOR2,

CAMBIARPRECIO,

SUBSTITUTO,

CBARRAS,

CEMPAQUE,

PZACAJA,

U_EMPAQUE,

UNIDAD,

INI_MAYO,

MAYOKGS,

TIPOABC,

CLAVE_TASAIVA,

TEXTO1,

TEXTO2,

TEXTO3,

TEXTO4,

TEXTO5,

TEXTO6,

NUMERO1,

NUMERO2,

NUMERO3,

NUMERO4,

FECHA1,

FECHA2,

CLAVE_PRODUCTOPADRE,

ESPRODUCTOPADRE,

ESPRODUCTOFINAL,

ESSUBPRODUCTO,

TOMARPRECIOPADRE,

TOMARCOMISIONPADRE,

TOMAROFERTAPADRE,

COMISION,

OFERTA,

PLUG,

TASAIEPS,

MINUTILIDAD,

AUTO_INSERT_FK,

SPRECIO1,

SPRECIO2,

SPRECIO3,

SPRECIO4,

SPRECIO5,

REQUIERERECETA,

CLASIFICA,

PROMOMOVIL,

MARGENMOVIL,

MPRECIO4MOVIL,

CPRECIO4MOVIL,

TPRECIO4MOVIL,

APRECIO4MOVIL,

CANTIDAD,

LOTE,

FECHAVENCE
         )

SELECT

@CLAVE,

@NOMBRE,

@DESCRIPCION,

@EAN,

@DESCRIPCION1,

@DESCRIPCION2,

@DESCRIPCION3,

@PROVEEDOR1ID,

@PROVEEDOR2ID,

@CLAVE_LINEA,

@CLAVE_MARCA,

@PRECIO1,

@PRECIO2,

@PRECIO3,

@PRECIO4,

@PRECIO5,

@TASAIVAID,

@TASAIVA,

@CLAVE_MONEDA,

@COSTOREPOSICION,

@COSTOULTIMO,

@COSTOPROMEDIO,

@CLAVE_SUSTITUTO,

@MANEJALOTE,

@ESKIT,

@IMPRIMIR,

@INVENTARIABLE,

@NEGATIVOS,

@LIMITEPRECIO2,

@PRECIOMAXIMOPUBLICO,

@CLAVE_PROVEEDOR1,

@CLAVE_PROVEEDOR2,

@CAMBIARPRECIO,

@SUBSTITUTO,

@CBARRAS,

@CEMPAQUE,

@PZACAJA,

@U_EMPAQUE,

@UNIDAD,

@INI_MAYO,

@MAYOKGS,

@TIPOABC,

@CLAVE_TASAIVA,

@TEXTO1,

@TEXTO2,

@TEXTO3,

@TEXTO4,

@TEXTO5,

@TEXTO6,

@NUMERO1,

@NUMERO2,

@NUMERO3,

@NUMERO4,

@FECHA1,

@FECHA2,

@CLAVE_PRODUCTOPADRE,

@ESPRODUCTOPADRE,

@ESPRODUCTOFINAL,

@ESSUBPRODUCTO,

@TOMARPRECIOPADRE,

@TOMARCOMISIONPADRE,

@TOMAROFERTAPADRE,

@COMISION,

@OFERTA,

@PLUG,

@TASAIEPS,

@MINUTILIDAD,

@AUTO_INSERT_FK,

@SPRECIO1,

@SPRECIO2,

@SPRECIO3,

@SPRECIO4,

@SPRECIO5,

@REQUIERERECETA,

@CLASIFICA,

@PROMOMOVIL,

@MARGENMOVIL,

@MPRECIO4MOVIL,

@CPRECIO4MOVIL,

@TPRECIO4MOVIL,

@APRECIO4MOVIL,

@CANTIDAD,

@LOTE,

@FECHAVENCE
FROM  rdb$database ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                Console.WriteLine("In" + DateTime.Now.ToString("HH:mm:ss.fff"));
                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                Console.WriteLine("Fn" + DateTime.Now.ToString("HH:mm:ss.fff"));





                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool importarCACHE_PRODUCTODMOVIL_MULTIPLE(List<CACHEIMPOBUFFER> listaReg, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                int iCount = 0;
                foreach(CACHEIMPOBUFFER item in listaReg)
                {
                    CPRODUCTOBE oCPRODUCTO = item.OCPRODUCTO;
                    string p_claveLinea = item.P_claveLinea;
                    string p_claveMarca = item.P_claveMarca;
                    string p_claveMoneda = item.P_claveMoneda;
                    string p_claveSustituto = item.P_claveSustituto;
                    string p_proveedor1 = item.P_proveedor1;
                    string p_proveedor2 = item.P_proveedor2;
                    string p_claveTasaIva = item.P_claveTasaIva;
                    string p_claveProductoPadre = item.P_claveProductoPadre;
                    decimal cantidad = item.Cantidad;
                    string lote = item.Lote;
                    DateTime fechavence = item.Fechavence;

                    string postFijo = "_" + iCount.ToString();

                    auxPar = new FbParameter("@CLAVE" + postFijo, FbDbType.VarChar);
                    if (!(bool)oCPRODUCTO.isnull["ICLAVE"])
                    {
                        auxPar.Value = oCPRODUCTO.ICLAVE;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@NOMBRE" + postFijo, FbDbType.VarChar);
                    if (!(bool)oCPRODUCTO.isnull["INOMBRE"])
                    {
                        auxPar.Value = oCPRODUCTO.INOMBRE;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@DESCRIPCION" + postFijo, FbDbType.VarChar);
                    if (!(bool)oCPRODUCTO.isnull["IDESCRIPCION"])
                    {
                        auxPar.Value = oCPRODUCTO.IDESCRIPCION;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@EAN" + postFijo, FbDbType.VarChar);
                    if (!(bool)oCPRODUCTO.isnull["IEAN"])
                    {
                        auxPar.Value = oCPRODUCTO.IEAN;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@DESCRIPCION1" + postFijo, FbDbType.VarChar);
                    if (!(bool)oCPRODUCTO.isnull["IDESCRIPCION1"])
                    {
                        auxPar.Value = oCPRODUCTO.IDESCRIPCION1;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@DESCRIPCION2" + postFijo, FbDbType.VarChar);
                    if (!(bool)oCPRODUCTO.isnull["IDESCRIPCION2"])
                    {
                        auxPar.Value = oCPRODUCTO.IDESCRIPCION2;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@DESCRIPCION3" + postFijo, FbDbType.VarChar);
                    if (!(bool)oCPRODUCTO.isnull["IDESCRIPCION3"])
                    {
                        auxPar.Value = oCPRODUCTO.IDESCRIPCION3;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@PROVEEDOR1ID" + postFijo, FbDbType.Integer);
                    if (!(bool)oCPRODUCTO.isnull["IPROVEEDOR1ID"])
                    {
                        auxPar.Value = oCPRODUCTO.IPROVEEDOR1ID;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@PROVEEDOR2ID" + postFijo, FbDbType.Integer);
                    if (!(bool)oCPRODUCTO.isnull["IPROVEEDOR2ID"])
                    {
                        auxPar.Value = oCPRODUCTO.IPROVEEDOR2ID;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@CLAVE_LINEA" + postFijo, FbDbType.VarChar);
                    auxPar.Value = p_claveLinea;
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@CLAVE_MARCA" + postFijo, FbDbType.VarChar);
                    auxPar.Value = p_claveMarca;
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@PRECIO1" + postFijo, FbDbType.Numeric);
                    if (!(bool)oCPRODUCTO.isnull["IPRECIO1"])
                    {
                        auxPar.Value = oCPRODUCTO.IPRECIO1;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@PRECIO2" + postFijo, FbDbType.Numeric);
                    if (!(bool)oCPRODUCTO.isnull["IPRECIO2"])
                    {
                        auxPar.Value = oCPRODUCTO.IPRECIO2;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@PRECIO3" + postFijo, FbDbType.Numeric);
                    if (!(bool)oCPRODUCTO.isnull["IPRECIO3"])
                    {
                        auxPar.Value = oCPRODUCTO.IPRECIO3;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@PRECIO4" + postFijo, FbDbType.Numeric);
                    if (!(bool)oCPRODUCTO.isnull["IPRECIO4"])
                    {
                        auxPar.Value = oCPRODUCTO.IPRECIO4;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@PRECIO5" + postFijo, FbDbType.Numeric);
                    if (!(bool)oCPRODUCTO.isnull["IPRECIO5"])
                    {
                        auxPar.Value = oCPRODUCTO.IPRECIO5;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@TASAIVAID" + postFijo, FbDbType.BigInt);
                    if (!(bool)oCPRODUCTO.isnull["ITASAIVAID"])
                    {
                        auxPar.Value = oCPRODUCTO.ITASAIVAID;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@TASAIVA" + postFijo, FbDbType.Numeric);
                    if (!(bool)oCPRODUCTO.isnull["ITASAIVA"])
                    {
                        auxPar.Value = oCPRODUCTO.ITASAIVA;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@CLAVE_MONEDA" + postFijo, FbDbType.VarChar);
                    auxPar.Value = p_claveMoneda;
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@COSTOREPOSICION" + postFijo, FbDbType.Numeric);
                    if (!(bool)oCPRODUCTO.isnull["ICOSTOREPOSICION"])
                    {
                        auxPar.Value = oCPRODUCTO.ICOSTOREPOSICION;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@COSTOULTIMO" + postFijo, FbDbType.Numeric);
                    if (!(bool)oCPRODUCTO.isnull["ICOSTOULTIMO"])
                    {
                        auxPar.Value = oCPRODUCTO.ICOSTOULTIMO;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@COSTOPROMEDIO" + postFijo, FbDbType.Numeric);
                    if (!(bool)oCPRODUCTO.isnull["ICOSTOPROMEDIO"])
                    {
                        auxPar.Value = oCPRODUCTO.ICOSTOPROMEDIO;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@CLAVE_SUSTITUTO" + postFijo, FbDbType.VarChar);
                    auxPar.Value = p_claveSustituto;
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@MANEJALOTE" + postFijo, FbDbType.Char);
                    if (!(bool)oCPRODUCTO.isnull["IMANEJALOTE"] && oCPRODUCTO.IMANEJALOTE.Trim() != "")
                    {
                        auxPar.Value = oCPRODUCTO.IMANEJALOTE;
                    }
                    else
                    {
                        auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@ESKIT" + postFijo, FbDbType.Char);
                    if (!(bool)oCPRODUCTO.isnull["IESKIT"] && oCPRODUCTO.IESKIT.Trim() != "")
                    {
                        auxPar.Value = oCPRODUCTO.IESKIT;
                    }
                    else
                    {
                        auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@IMPRIMIR" + postFijo, FbDbType.Char);
                    if (!(bool)oCPRODUCTO.isnull["IIMPRIMIR"] && oCPRODUCTO.IIMPRIMIR.Trim() != "")
                    {
                        auxPar.Value = oCPRODUCTO.IIMPRIMIR;
                    }
                    else
                    {
                        auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@INVENTARIABLE" + postFijo, FbDbType.Char);
                    if (!(bool)oCPRODUCTO.isnull["IINVENTARIABLE"] && oCPRODUCTO.IINVENTARIABLE.Trim() != "")
                    {
                        auxPar.Value = oCPRODUCTO.IINVENTARIABLE;
                    }
                    else
                    {
                        auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@NEGATIVOS" + postFijo, FbDbType.Char);
                    if (!(bool)oCPRODUCTO.isnull["INEGATIVOS"] && oCPRODUCTO.INEGATIVOS.Trim() != "")
                    {
                        auxPar.Value = oCPRODUCTO.INEGATIVOS;
                    }
                    else
                    {
                        auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@LIMITEPRECIO2" + postFijo, FbDbType.Numeric);
                    if (!(bool)oCPRODUCTO.isnull["ILIMITEPRECIO2"])
                    {
                        auxPar.Value = oCPRODUCTO.ILIMITEPRECIO2;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@PRECIOMAXIMOPUBLICO" + postFijo, FbDbType.Numeric);
                    if (!(bool)oCPRODUCTO.isnull["IPRECIOMAXIMOPUBLICO"])
                    {
                        auxPar.Value = oCPRODUCTO.IPRECIOMAXIMOPUBLICO;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@CLAVE_PROVEEDOR1" + postFijo, FbDbType.VarChar);
                    auxPar.Value = p_proveedor1;
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@CLAVE_PROVEEDOR2" + postFijo, FbDbType.VarChar);
                    auxPar.Value = p_proveedor2;
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@CAMBIARPRECIO" + postFijo, FbDbType.Char);
                    if (!(bool)oCPRODUCTO.isnull["ICAMBIARPRECIO"] && oCPRODUCTO.ICAMBIARPRECIO.Trim() != "")
                    {
                        auxPar.Value = oCPRODUCTO.ICAMBIARPRECIO;
                    }
                    else
                    {
                        auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@SUBSTITUTO" + postFijo, FbDbType.VarChar);
                    if (!(bool)oCPRODUCTO.isnull["ISUBSTITUTO"])
                    {
                        auxPar.Value = oCPRODUCTO.ISUBSTITUTO;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@CBARRAS" + postFijo, FbDbType.VarChar);
                    if (!(bool)oCPRODUCTO.isnull["ICBARRAS"])
                    {
                        auxPar.Value = oCPRODUCTO.ICBARRAS;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@CEMPAQUE" + postFijo, FbDbType.VarChar);
                    if (!(bool)oCPRODUCTO.isnull["ICEMPAQUE"])
                    {
                        auxPar.Value = oCPRODUCTO.ICEMPAQUE;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@PZACAJA" + postFijo, FbDbType.Numeric);
                    if (!(bool)oCPRODUCTO.isnull["IPZACAJA"])
                    {
                        auxPar.Value = oCPRODUCTO.IPZACAJA;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@U_EMPAQUE" + postFijo, FbDbType.Numeric);
                    if (!(bool)oCPRODUCTO.isnull["IU_EMPAQUE"])
                    {
                        auxPar.Value = oCPRODUCTO.IU_EMPAQUE;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@UNIDAD" + postFijo, FbDbType.VarChar);
                    if (!(bool)oCPRODUCTO.isnull["IUNIDAD"])
                    {
                        auxPar.Value = oCPRODUCTO.IUNIDAD;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@INI_MAYO" + postFijo, FbDbType.Numeric);
                    if (!(bool)oCPRODUCTO.isnull["IINI_MAYO"])
                    {
                        auxPar.Value = oCPRODUCTO.IINI_MAYO;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@MAYOKGS" + postFijo, FbDbType.Char);
                    if (!(bool)oCPRODUCTO.isnull["IMAYOKGS"])
                    {
                        auxPar.Value = oCPRODUCTO.IMAYOKGS;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@TIPOABC" + postFijo, FbDbType.Char);
                    if (!(bool)oCPRODUCTO.isnull["ITIPOABC"])
                    {
                        auxPar.Value = oCPRODUCTO.ITIPOABC;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);




                    auxPar = new FbParameter("@CLAVE_TASAIVA" + postFijo, FbDbType.VarChar);
                    auxPar.Value = p_claveTasaIva;
                    parts.Add(auxPar);





                    auxPar = new FbParameter("@TEXTO1" + postFijo, FbDbType.VarChar);
                    if (!(bool)oCPRODUCTO.isnull["ITEXTO1"])
                    {
                        auxPar.Value = oCPRODUCTO.ITEXTO1;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@TEXTO2" + postFijo, FbDbType.VarChar);
                    if (!(bool)oCPRODUCTO.isnull["ITEXTO2"])
                    {
                        auxPar.Value = oCPRODUCTO.ITEXTO2;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);

                    auxPar = new FbParameter("@TEXTO3" + postFijo, FbDbType.VarChar);
                    if (!(bool)oCPRODUCTO.isnull["ITEXTO3"])
                    {
                        auxPar.Value = oCPRODUCTO.ITEXTO3;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@TEXTO4" + postFijo, FbDbType.VarChar);
                    if (!(bool)oCPRODUCTO.isnull["ITEXTO4"])
                    {
                        auxPar.Value = oCPRODUCTO.ITEXTO4;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@TEXTO5" + postFijo, FbDbType.VarChar);
                    if (!(bool)oCPRODUCTO.isnull["ITEXTO5"])
                    {
                        auxPar.Value = oCPRODUCTO.ITEXTO5;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@TEXTO6" + postFijo, FbDbType.VarChar);
                    if (!(bool)oCPRODUCTO.isnull["ITEXTO6"])
                    {
                        auxPar.Value = oCPRODUCTO.ITEXTO6;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@NUMERO1" + postFijo, FbDbType.Numeric);
                    if (!(bool)oCPRODUCTO.isnull["INUMERO1"])
                    {
                        auxPar.Value = oCPRODUCTO.INUMERO1;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);

                    auxPar = new FbParameter("@NUMERO2" + postFijo, FbDbType.Numeric);
                    if (!(bool)oCPRODUCTO.isnull["INUMERO2"])
                    {
                        auxPar.Value = oCPRODUCTO.INUMERO2;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);

                    auxPar = new FbParameter("@NUMERO3" + postFijo, FbDbType.Numeric);
                    if (!(bool)oCPRODUCTO.isnull["INUMERO3"])
                    {
                        auxPar.Value = oCPRODUCTO.INUMERO3;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);

                    auxPar = new FbParameter("@NUMERO4" + postFijo, FbDbType.Numeric);
                    if (!(bool)oCPRODUCTO.isnull["INUMERO4"])
                    {
                        auxPar.Value = oCPRODUCTO.INUMERO4;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@FECHA1" + postFijo, FbDbType.Date);
                    if (!(bool)oCPRODUCTO.isnull["IFECHA1"])
                    {
                        auxPar.Value = oCPRODUCTO.IFECHA1;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@FECHA2" + postFijo, FbDbType.Date);
                    if (!(bool)oCPRODUCTO.isnull["IFECHA2"])
                    {
                        auxPar.Value = oCPRODUCTO.IFECHA2;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);




                    auxPar = new FbParameter("@CLAVE_PRODUCTOPADRE" + postFijo, FbDbType.VarChar);
                    auxPar.Value = p_claveProductoPadre;
                    parts.Add(auxPar);




                    auxPar = new FbParameter("@ESPRODUCTOPADRE" + postFijo, FbDbType.Char);
                    if (!(bool)oCPRODUCTO.isnull["IESPRODUCTOPADRE"])
                    {
                        auxPar.Value = oCPRODUCTO.IESPRODUCTOPADRE;
                    }
                    else
                    {
                        auxPar.Value = "N";
                    }
                    parts.Add(auxPar);

                    auxPar = new FbParameter("@ESPRODUCTOFINAL" + postFijo, FbDbType.Char);
                    if (!(bool)oCPRODUCTO.isnull["IESPRODUCTOFINAL"])
                    {
                        auxPar.Value = oCPRODUCTO.IESPRODUCTOFINAL;
                    }
                    else
                    {
                        auxPar.Value = "N";
                    }
                    parts.Add(auxPar);

                    auxPar = new FbParameter("@ESSUBPRODUCTO" + postFijo, FbDbType.Char);
                    if (!(bool)oCPRODUCTO.isnull["IESSUBPRODUCTO"])
                    {
                        auxPar.Value = oCPRODUCTO.IESSUBPRODUCTO;
                    }
                    else
                    {
                        auxPar.Value = "N";
                    }
                    parts.Add(auxPar);



                    auxPar = new FbParameter("@TOMARPRECIOPADRE" + postFijo, FbDbType.Char);
                    if (!(bool)oCPRODUCTO.isnull["ITOMARPRECIOPADRE"])
                    {
                        auxPar.Value = oCPRODUCTO.ITOMARPRECIOPADRE;
                    }
                    else
                    {
                        auxPar.Value = "N";
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@TOMARCOMISIONPADRE" + postFijo, FbDbType.Char);
                    if (!(bool)oCPRODUCTO.isnull["ITOMARCOMISIONPADRE"])
                    {
                        if (oCPRODUCTO.ITOMARCOMISIONPADRE.Trim().Length > 0)
                            auxPar.Value = oCPRODUCTO.ITOMARCOMISIONPADRE;
                        else
                            auxPar.Value = "N";

                    }
                    else
                    {
                        auxPar.Value = "N";
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@TOMAROFERTAPADRE" + postFijo, FbDbType.Char);
                    if (!(bool)oCPRODUCTO.isnull["ITOMAROFERTAPADRE"])
                    {
                        auxPar.Value = oCPRODUCTO.ITOMAROFERTAPADRE;
                    }
                    else
                    {
                        auxPar.Value = "N";
                    }
                    parts.Add(auxPar);



                    auxPar = new FbParameter("@COMISION" + postFijo, FbDbType.Numeric);
                    if (!(bool)oCPRODUCTO.isnull["ICOMISION"])
                    {
                        auxPar.Value = oCPRODUCTO.ICOMISION;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);

                    auxPar = new FbParameter("@OFERTA" + postFijo, FbDbType.Numeric);
                    if (!(bool)oCPRODUCTO.isnull["IOFERTA"])
                    {
                        auxPar.Value = oCPRODUCTO.IOFERTA;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);



                    auxPar = new FbParameter("@PLUG" + postFijo, FbDbType.VarChar);
                    if (!(bool)oCPRODUCTO.isnull["IPLUG"])
                    {
                        auxPar.Value = oCPRODUCTO.IPLUG;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);



                    auxPar = new FbParameter("@TASAIEPS" + postFijo, FbDbType.Numeric);
                    if (!(bool)oCPRODUCTO.isnull["ITASAIEPS"])
                    {
                        auxPar.Value = oCPRODUCTO.ITASAIEPS;
                    }
                    else
                    {
                        auxPar.Value = 0;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@MINUTILIDAD" + postFijo, FbDbType.Numeric);
                    if (!(bool)oCPRODUCTO.isnull["IMINUTILIDAD"])
                    {
                        auxPar.Value = oCPRODUCTO.IMINUTILIDAD;
                    }
                    else
                    {
                        auxPar.Value = 0;
                    }
                    parts.Add(auxPar);

                    auxPar = new FbParameter("@AUTO_INSERT_FK" + postFijo, FbDbType.Char);
                    auxPar.Value = DBValues._DB_BOOLVALUE_SI;
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@SPRECIO1" + postFijo, FbDbType.Numeric);
                    if (!(bool)oCPRODUCTO.isnull["ISPRECIO1"])
                    {
                        auxPar.Value = oCPRODUCTO.ISPRECIO1;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@SPRECIO2" + postFijo, FbDbType.Numeric);
                    if (!(bool)oCPRODUCTO.isnull["ISPRECIO2"])
                    {
                        auxPar.Value = oCPRODUCTO.ISPRECIO2;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@SPRECIO3" + postFijo, FbDbType.Numeric);
                    if (!(bool)oCPRODUCTO.isnull["ISPRECIO3"])
                    {
                        auxPar.Value = oCPRODUCTO.ISPRECIO3;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@SPRECIO4" + postFijo, FbDbType.Numeric);
                    if (!(bool)oCPRODUCTO.isnull["ISPRECIO4"])
                    {
                        auxPar.Value = oCPRODUCTO.ISPRECIO4;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@SPRECIO5" + postFijo, FbDbType.Numeric);
                    if (!(bool)oCPRODUCTO.isnull["ISPRECIO5"])
                    {
                        auxPar.Value = oCPRODUCTO.ISPRECIO5;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@REQUIERERECETA" + postFijo, FbDbType.Char);
                    if (!(bool)oCPRODUCTO.isnull["IREQUIERERECETA"])
                    {
                        auxPar.Value = oCPRODUCTO.IREQUIERERECETA;
                    }
                    else
                    {
                        auxPar.Value = "N";
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@CLASIFICA" + postFijo, FbDbType.Char);
                    if (!(bool)oCPRODUCTO.isnull["ICLASIFICA"])
                    {
                        auxPar.Value = oCPRODUCTO.ICLASIFICA;
                    }
                    else
                    {
                        auxPar.Value = DBNull.Value;
                    }
                    parts.Add(auxPar);




                    auxPar = new FbParameter("@PROMOMOVIL" + postFijo, FbDbType.Char);
                    if (!(bool)oCPRODUCTO.isnull["IPROMOMOVIL"])
                    {
                        auxPar.Value = oCPRODUCTO.IPROMOMOVIL;
                    }
                    else
                    {
                        auxPar.Value = "N";
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@MARGENMOVIL" + postFijo, FbDbType.Numeric);
                    if (!(bool)oCPRODUCTO.isnull["IMARGENMOVIL"])
                    {
                        auxPar.Value = oCPRODUCTO.IMARGENMOVIL;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@MPRECIO4MOVIL" + postFijo, FbDbType.Numeric);
                    if (!(bool)oCPRODUCTO.isnull["IMPRECIO4MOVIL"])
                    {
                        auxPar.Value = oCPRODUCTO.IMPRECIO4MOVIL;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@CPRECIO4MOVIL" + postFijo, FbDbType.Numeric);
                    if (!(bool)oCPRODUCTO.isnull["ICPRECIO4MOVIL"])
                    {
                        auxPar.Value = oCPRODUCTO.ICPRECIO4MOVIL;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);

                    auxPar = new FbParameter("@TPRECIO4MOVIL" + postFijo, FbDbType.Numeric);
                    if (!(bool)oCPRODUCTO.isnull["ITPRECIO4MOVIL"])
                    {
                        auxPar.Value = oCPRODUCTO.ITPRECIO4MOVIL;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);

                    auxPar = new FbParameter("@APRECIO4MOVIL" + postFijo, FbDbType.Numeric);
                    if (!(bool)oCPRODUCTO.isnull["IAPRECIO4MOVIL"])
                    {
                        auxPar.Value = oCPRODUCTO.IAPRECIO4MOVIL;
                    }
                    else
                    {
                        auxPar.Value = System.DBNull.Value;
                    }
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@CANTIDAD" + postFijo, FbDbType.Numeric);
                    auxPar.Value = cantidad;
                    parts.Add(auxPar);



                    auxPar = new FbParameter("@LOTE" + postFijo, FbDbType.VarChar);
                    if (lote == null || lote.Equals(""))
                        auxPar.Value = DBNull.Value;
                    else
                        auxPar.Value = lote;
                    parts.Add(auxPar);

                    auxPar = new FbParameter("@FECHAVENCE" + postFijo, FbDbType.Date);
                    if (fechavence == DateTime.MinValue)
                    {
                        auxPar.Value = DBNull.Value;
                    }
                    else
                    {
                        auxPar.Value = fechavence;
                    }
                    parts.Add(auxPar);



                    iCount++;

                }


                /*auxPar = new FbParameter("@SAT_PRODUCTOSERVICIOID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTO.isnull["ISAT_PRODUCTOSERVICIOID"])
                {
                    auxPar.Value = oCPRODUCTO.ISAT_PRODUCTOSERVICIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);*/

                /*auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);*/




                string commandText = @"
        INSERT INTO CACHE_PRODMOVIL
      (

CLAVE,

NOMBRE,

DESCRIPCION,

EAN,

DESCRIPCION1,

DESCRIPCION2,

DESCRIPCION3,

PROVEEDOR1ID,

PROVEEDOR2ID,

CLAVE_LINEA,

CLAVE_MARCA,

PRECIO1,

PRECIO2,

PRECIO3,

PRECIO4,

PRECIO5,

TASAIVAID,

TASAIVA,

CLAVE_MONEDA,

COSTOREPOSICION,

COSTOULTIMO,

COSTOPROMEDIO,

CLAVE_SUSTITUTO,

MANEJALOTE,

ESKIT,

IMPRIMIR,

INVENTARIABLE,

NEGATIVOS,

LIMITEPRECIO2,

PRECIOMAXIMOPUBLICO,

CLAVE_PROVEEDOR1,

CLAVE_PROVEEDOR2,

CAMBIARPRECIO,

SUBSTITUTO,

CBARRAS,

CEMPAQUE,

PZACAJA,

U_EMPAQUE,

UNIDAD,

INI_MAYO,

MAYOKGS,

TIPOABC,

CLAVE_TASAIVA,

TEXTO1,

TEXTO2,

TEXTO3,

TEXTO4,

TEXTO5,

TEXTO6,

NUMERO1,

NUMERO2,

NUMERO3,

NUMERO4,

FECHA1,

FECHA2,

CLAVE_PRODUCTOPADRE,

ESPRODUCTOPADRE,

ESPRODUCTOFINAL,

ESSUBPRODUCTO,

TOMARPRECIOPADRE,

TOMARCOMISIONPADRE,

TOMAROFERTAPADRE,

COMISION,

OFERTA,

PLUG,

TASAIEPS,

MINUTILIDAD,

AUTO_INSERT_FK,

SPRECIO1,

SPRECIO2,

SPRECIO3,

SPRECIO4,

SPRECIO5,

REQUIERERECETA,

CLASIFICA,

PROMOMOVIL,

MARGENMOVIL,

MPRECIO4MOVIL,

CPRECIO4MOVIL,

TPRECIO4MOVIL,

APRECIO4MOVIL,

CANTIDAD,

LOTE,

FECHAVENCE
         )";


                for (int i = 0; i < iCount; i++)
                {

                    if (i != 0)
                    {
                        commandText += @" UNION ALL ";
                    }

                    string postFijo = "_" + i.ToString();

                    commandText += @" 
                    SELECT

                    CAST(@CLAVE" + postFijo + @" AS VARCHAR(255)) CLAVE,

                    CAST(@NOMBRE" + postFijo + @" AS VARCHAR(255))  NOMBRE,

                    CAST(@DESCRIPCION" + postFijo + @" AS VARCHAR(255))  DESCRIPCION,

                    CAST(@EAN" + postFijo + @" AS VARCHAR(255))  EAN,

                    CAST(@DESCRIPCION1" + postFijo + @" AS VARCHAR(255))  DESCRIPCION1,

                    CAST(@DESCRIPCION2" + postFijo + @" AS VARCHAR(255))  DESCRIPCION2,

                    CAST(@DESCRIPCION3" + postFijo + @" AS VARCHAR(255))  DESCRIPCION3,

                    CAST(@PROVEEDOR1ID" + postFijo + @" AS INTEGER)  PROVEEDOR1ID,

                    CAST(@PROVEEDOR2ID" + postFijo + @" AS INTEGER)  PROVEEDOR2ID,

                    CAST(@CLAVE_LINEA" + postFijo + @" AS VARCHAR(255))  CLAVE_LINEA,

                    CAST(@CLAVE_MARCA" + postFijo + @" AS VARCHAR(255))  CLAVE_MARCA,

                   CAST( @PRECIO1" + postFijo + @" AS NUMERIC(18,4))  PRECIO1,

                    CAST(@PRECIO2" + postFijo + @" AS NUMERIC(18,4))  PRECIO2,

                    CAST(@PRECIO3" + postFijo + @" AS NUMERIC(18,4))  PRECIO3,

                    CAST(@PRECIO4" + postFijo + @" AS NUMERIC(18,4))  PRECIO4,

                    CAST(@PRECIO5" + postFijo + @" AS NUMERIC(18,4))  PRECIO5,

                    CAST(@TASAIVAID" + postFijo + @" AS BIGINT)  TASAIVAID,

                    CAST(@TASAIVA" + postFijo + @" AS NUMERIC(18,2))  TASAIVA,

                    CAST(@CLAVE_MONEDA" + postFijo + @" AS VARCHAR(255))  CLAVE_MONEDA,

                    CAST(@COSTOREPOSICION" + postFijo + @" AS NUMERIC(18,4))  COSTOREPOSICION,

                    CAST(@COSTOULTIMO" + postFijo + @" AS NUMERIC(18,4))  COSTOULTIMO,

                    CAST(@COSTOPROMEDIO" + postFijo + @" AS NUMERIC(18,4))  COSTOPROMEDIO,

                    CAST(@CLAVE_SUSTITUTO" + postFijo + @" AS VARCHAR(255))  CLAVE_SUSTITUTO,

                    CAST(@MANEJALOTE" + postFijo + @" AS VARCHAR(255))  MANEJALOTE,

                    CAST(@ESKIT" + postFijo + @" AS VARCHAR(255))  ESKIT,

                    CAST(@IMPRIMIR" + postFijo + @" AS VARCHAR(255))  IMPRIMIR,

                   CAST( @INVENTARIABLE" + postFijo + @" AS VARCHAR(255))  INVENTARIABLE,

                    CAST(@NEGATIVOS" + postFijo + @" AS VARCHAR(255))  NEGATIVOS,

                    CAST(@LIMITEPRECIO2" + postFijo + @" AS NUMERIC(18,4))  LIMITEPRECIO2,

                    CAST(@PRECIOMAXIMOPUBLICO" + postFijo + @" AS NUMERIC(18,4))  PRECIOMAXIMOPUBLICO,

                    CAST(@CLAVE_PROVEEDOR1" + postFijo + @" AS VARCHAR(255))  CLAVE_PROVEEDOR1,

                    CAST(@CLAVE_PROVEEDOR2" + postFijo + @" AS VARCHAR(255))  CLAVE_PROVEEDOR2,

                    CAST(@CAMBIARPRECIO" + postFijo + @" AS VARCHAR(255))  CAMBIARPRECIO,

                    CAST(@SUBSTITUTO" + postFijo + @" AS VARCHAR(255))  SUBSTITUTO,

                    CAST(@CBARRAS" + postFijo + @" AS VARCHAR(255))  CBARRAS,

                    CAST(@CEMPAQUE" + postFijo + @" AS VARCHAR(255))  CEMPAQUE,

                    CAST(@PZACAJA" + postFijo + @" AS NUMERIC(18,4))  PZACAJA,

                    CAST(@U_EMPAQUE" + postFijo + @" AS NUMERIC(18,4))  U_EMPAQUE,

                    CAST(@UNIDAD" + postFijo + @" AS VARCHAR(255))  UNIDAD,

                    CAST(@INI_MAYO" + postFijo + @" AS NUMERIC(18,4))  INI_MAYO,

                    CAST(@MAYOKGS" + postFijo + @" AS VARCHAR(255))  MAYOKGS,

                    CAST(@TIPOABC" + postFijo + @" AS VARCHAR(255))  TIPOABC,

                    CAST(@CLAVE_TASAIVA" + postFijo + @" AS VARCHAR(255))  CLAVE_TASAIVA,

                    CAST(@TEXTO1" + postFijo + @" AS VARCHAR(255))  TEXTO1,

                    CAST(@TEXTO2" + postFijo + @" AS VARCHAR(255))  TEXTO2,

                    CAST(@TEXTO3" + postFijo + @" AS VARCHAR(255))  TEXTO3,

                    CAST(@TEXTO4" + postFijo + @" AS VARCHAR(255))  TEXTO4,

                    CAST(@TEXTO5" + postFijo + @" AS VARCHAR(255))  TEXTO5,

                    CAST(@TEXTO6" + postFijo + @" AS VARCHAR(255))  TEXTO6,

                    CAST(@NUMERO1" + postFijo + @" AS NUMERIC(18,4))  NUMERO1,

                    CAST(@NUMERO2" + postFijo + @" AS NUMERIC(18,4))  NUMERO2,

                    CAST(@NUMERO3" + postFijo + @" AS NUMERIC(18,4))  NUMERO3,

                    CAST(@NUMERO4" + postFijo + @" AS NUMERIC(18,4))  NUMERO4,

                    CAST(@FECHA1" + postFijo + @" AS DATE)  FECHA1,

                    CAST(@FECHA2" + postFijo + @" AS DATE)  FECHA2,

                    CAST(@CLAVE_PRODUCTOPADRE" + postFijo + @" AS VARCHAR(255))  CLAVE_PRODUCTOPADRE,

                    CAST(@ESPRODUCTOPADRE" + postFijo + @" AS VARCHAR(255))  ESPRODUCTOPADRE,

                    CAST(@ESPRODUCTOFINAL" + postFijo + @" AS VARCHAR(255))  ESPRODUCTOFINAL,

                    CAST(@ESSUBPRODUCTO" + postFijo + @" AS VARCHAR(255))  ESSUBPRODUCTO,

                    CAST(@TOMARPRECIOPADRE" + postFijo + @" AS VARCHAR(255))  TOMARPRECIOPADRE,

                    CAST(@TOMARCOMISIONPADRE" + postFijo + @" AS VARCHAR(255))  TOMARCOMISIONPADRE,

                    CAST(@TOMAROFERTAPADRE" + postFijo + @" AS VARCHAR(255))  TOMAROFERTAPADRE,

                    CAST(@COMISION" + postFijo + @" AS NUMERIC(18,2))  COMISION,

                    CAST(@OFERTA" + postFijo + @" AS NUMERIC(18,2))  OFERTA,

                    CAST(@PLUG" + postFijo + @" AS VARCHAR(255))  PLUG,

                    CAST(@TASAIEPS" + postFijo + @" AS NUMERIC(18,2))  TASAIEPS,

                    CAST(@MINUTILIDAD" + postFijo + @" AS NUMERIC(18,2))  MINUTILIDAD,

                    CAST(@AUTO_INSERT_FK" + postFijo + @" AS VARCHAR(255))  AUTO_INSERT_FK,

                    CAST(@SPRECIO1" + postFijo + @" AS NUMERIC(18,4))  SPRECIO1,

                    CAST(@SPRECIO2" + postFijo + @" AS NUMERIC(18,4))  SPRECIO2,

                    CAST(@SPRECIO3" + postFijo + @" AS NUMERIC(18,4))  SPRECIO3,

                    CAST(@SPRECIO4" + postFijo + @" AS NUMERIC(18,4))  SPRECIO4,

                    CAST(@SPRECIO5" + postFijo + @" AS NUMERIC(18,4))  SPRECIO5,

                    CAST(@REQUIERERECETA" + postFijo + @" AS VARCHAR(255))  REQUIERERECETA,

                   CAST( @CLASIFICA" + postFijo + @" AS VARCHAR(255))  CLASIFICA,

                    CAST(@PROMOMOVIL" + postFijo + @" AS VARCHAR(255))  PROMOMOVIL,

                    CAST(@MARGENMOVIL" + postFijo + @" AS NUMERIC(18,4))  MARGENMOVIL,

                    CAST(@MPRECIO4MOVIL" + postFijo + @" AS NUMERIC(18,4))  MPRECIO4MOVIL,

                    CAST(@CPRECIO4MOVIL" + postFijo + @" AS NUMERIC(18,4))  CPRECIO4MOVIL,

                    CAST(@TPRECIO4MOVIL" + postFijo + @" AS NUMERIC(18,4))  TPRECIO4MOVIL,

                    CAST(@APRECIO4MOVIL" + postFijo + @" AS NUMERIC(18,4))  APRECIO4MOVIL,

                    CAST(@CANTIDAD" + postFijo + @" AS NUMERIC(18,4))  CANTIDAD,

                    CAST(@LOTE" + postFijo + @" AS VARCHAR(255))  LOTE,

                    CAST(@FECHAVENCE" + postFijo + @" AS DATE)  FECHAVENCE
            FROM rdb$database ";
        }

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                Console.WriteLine("In" + DateTime.Now.ToString("HH:mm:ss.fff"));
                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                Console.WriteLine("Fn" + DateTime.Now.ToString("HH:mm:ss.fff"));





                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool BorrarCACHE_PRODMOVILD(CCACHE_PRODMOVILBE oCCACHE_PRODMOVIL, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCCACHE_PRODMOVIL.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from CACHE_PRODMOVIL
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


        public bool BorrarTodosCACHE_PRODMOVILD(FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                string commandText = @"  Delete from CACHE_PRODMOVIL;";

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


        public bool CambiarCACHE_PRODMOVILD(CCACHE_PRODMOVILBE oCCACHE_PRODMOVILNuevo, CCACHE_PRODMOVILBE oCCACHE_PRODMOVILAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ICLAVE"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["INOMBRE"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["IDESCRIPCION"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@EAN", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["IEAN"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.IEAN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCRIPCION1", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["IDESCRIPCION1"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.IDESCRIPCION1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCRIPCION2", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["IDESCRIPCION2"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.IDESCRIPCION2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCRIPCION3", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["IDESCRIPCION3"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.IDESCRIPCION3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PROVEEDOR1ID", FbDbType.Integer);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["IPROVEEDOR1ID"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.IPROVEEDOR1ID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PROVEEDOR2ID", FbDbType.Integer);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["IPROVEEDOR2ID"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.IPROVEEDOR2ID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLAVE_LINEA", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ICLAVE_LINEA"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ICLAVE_LINEA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLAVE_MARCA", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ICLAVE_MARCA"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ICLAVE_MARCA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRECIO1", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["IPRECIO1"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.IPRECIO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRECIO2", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["IPRECIO2"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.IPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRECIO3", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["IPRECIO3"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.IPRECIO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRECIO4", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["IPRECIO4"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.IPRECIO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRECIO5", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["IPRECIO5"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.IPRECIO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TASAIVAID", FbDbType.BigInt);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ITASAIVAID"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ITASAIVAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TASAIVA", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ITASAIVA"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ITASAIVA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLAVE_MONEDA", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ICLAVE_MONEDA"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ICLAVE_MONEDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@COSTOREPOSICION", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ICOSTOREPOSICION"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ICOSTOREPOSICION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@COSTOULTIMO", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ICOSTOULTIMO"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ICOSTOULTIMO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@COSTOPROMEDIO", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ICOSTOPROMEDIO"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ICOSTOPROMEDIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLAVE_SUSTITUTO", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ICLAVE_SUSTITUTO"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ICLAVE_SUSTITUTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MANEJALOTE", FbDbType.Char);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["IMANEJALOTE"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.IMANEJALOTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESKIT", FbDbType.Char);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["IESKIT"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.IESKIT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IMPRIMIR", FbDbType.Char);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["IIMPRIMIR"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.IIMPRIMIR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@INVENTARIABLE", FbDbType.Char);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["IINVENTARIABLE"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.IINVENTARIABLE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NEGATIVOS", FbDbType.Char);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["INEGATIVOS"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.INEGATIVOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LIMITEPRECIO2", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ILIMITEPRECIO2"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ILIMITEPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRECIOMAXIMOPUBLICO", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["IPRECIOMAXIMOPUBLICO"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.IPRECIOMAXIMOPUBLICO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLAVE_PROVEEDOR1", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ICLAVE_PROVEEDOR1"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ICLAVE_PROVEEDOR1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLAVE_PROVEEDOR2", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ICLAVE_PROVEEDOR2"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ICLAVE_PROVEEDOR2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMBIARPRECIO", FbDbType.Char);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ICAMBIARPRECIO"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ICAMBIARPRECIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SUBSTITUTO", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ISUBSTITUTO"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ISUBSTITUTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CBARRAS", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ICBARRAS"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ICBARRAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CEMPAQUE", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ICEMPAQUE"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ICEMPAQUE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PZACAJA", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["IPZACAJA"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.IPZACAJA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@U_EMPAQUE", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["IU_EMPAQUE"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.IU_EMPAQUE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@UNIDAD", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["IUNIDAD"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.IUNIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@INI_MAYO", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["IINI_MAYO"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.IINI_MAYO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MAYOKGS", FbDbType.Char);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["IMAYOKGS"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.IMAYOKGS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPOABC", FbDbType.Char);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ITIPOABC"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ITIPOABC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLAVE_TASAIVA", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ICLAVE_TASAIVA"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ICLAVE_TASAIVA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TEXTO1", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ITEXTO1"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ITEXTO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TEXTO2", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ITEXTO2"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ITEXTO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TEXTO3", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ITEXTO3"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ITEXTO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TEXTO4", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ITEXTO4"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ITEXTO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TEXTO5", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ITEXTO5"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ITEXTO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TEXTO6", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ITEXTO6"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ITEXTO6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMERO1", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["INUMERO1"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.INUMERO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMERO2", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["INUMERO2"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.INUMERO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMERO3", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["INUMERO3"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.INUMERO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMERO4", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["INUMERO4"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.INUMERO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHA1", FbDbType.Date);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["IFECHA1"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.IFECHA1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHA2", FbDbType.Date);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["IFECHA2"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.IFECHA2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLAVE_PRODUCTOPADRE", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ICLAVE_PRODUCTOPADRE"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ICLAVE_PRODUCTOPADRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESPRODUCTOPADRE", FbDbType.Char);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["IESPRODUCTOPADRE"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.IESPRODUCTOPADRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESPRODUCTOFINAL", FbDbType.Char);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["IESPRODUCTOFINAL"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.IESPRODUCTOFINAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESSUBPRODUCTO", FbDbType.Char);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["IESSUBPRODUCTO"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.IESSUBPRODUCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TOMARPRECIOPADRE", FbDbType.Char);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ITOMARPRECIOPADRE"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ITOMARPRECIOPADRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TOMARCOMISIONPADRE", FbDbType.Char);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ITOMARCOMISIONPADRE"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ITOMARCOMISIONPADRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TOMAROFERTAPADRE", FbDbType.Char);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ITOMAROFERTAPADRE"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ITOMAROFERTAPADRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@COMISION", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ICOMISION"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ICOMISION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@OFERTA", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["IOFERTA"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.IOFERTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PLUG", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["IPLUG"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.IPLUG;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TASAIEPS", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ITASAIEPS"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ITASAIEPS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MINUTILIDAD", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["IMINUTILIDAD"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.IMINUTILIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@AUTO_INSERT_FK", FbDbType.Char);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["IAUTO_INSERT_FK"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.IAUTO_INSERT_FK;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SPRECIO1", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ISPRECIO1"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ISPRECIO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SPRECIO2", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ISPRECIO2"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ISPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SPRECIO3", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ISPRECIO3"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ISPRECIO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SPRECIO4", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ISPRECIO4"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ISPRECIO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SPRECIO5", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ISPRECIO5"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ISPRECIO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@REQUIERERECETA", FbDbType.Char);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["IREQUIERERECETA"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.IREQUIERERECETA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLASIFICA", FbDbType.Char);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ICLASIFICA"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ICLASIFICA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PROMOMOVIL", FbDbType.Char);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["IPROMOMOVIL"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.IPROMOMOVIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MARGENMOVIL", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["IMARGENMOVIL"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.IMARGENMOVIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MPRECIO4MOVIL", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["IMPRECIO4MOVIL"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.IMPRECIO4MOVIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CPRECIO4MOVIL", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ICPRECIO4MOVIL"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ICPRECIO4MOVIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TPRECIO4MOVIL", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ITPRECIO4MOVIL"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ITPRECIO4MOVIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@APRECIO4MOVIL", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["IAPRECIO4MOVIL"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.IAPRECIO4MOVIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CANTIDAD", FbDbType.Numeric);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LOTE", FbDbType.VarChar);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["ILOTE"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.ILOTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAVENCE", FbDbType.Date);
                if (!(bool)oCCACHE_PRODMOVILNuevo.isnull["IFECHAVENCE"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILNuevo.IFECHAVENCE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCCACHE_PRODMOVILAnterior.isnull["IID"])
                {
                    auxPar.Value = oCCACHE_PRODMOVILAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  CACHE_PRODMOVIL
  set

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

CLAVE=@CLAVE,

NOMBRE=@NOMBRE,

DESCRIPCION=@DESCRIPCION,

EAN=@EAN,

DESCRIPCION1=@DESCRIPCION1,

DESCRIPCION2=@DESCRIPCION2,

DESCRIPCION3=@DESCRIPCION3,

PROVEEDOR1ID=@PROVEEDOR1ID,

PROVEEDOR2ID=@PROVEEDOR2ID,

CLAVE_LINEA=@CLAVE_LINEA,

CLAVE_MARCA=@CLAVE_MARCA,

PRECIO1=@PRECIO1,

PRECIO2=@PRECIO2,

PRECIO3=@PRECIO3,

PRECIO4=@PRECIO4,

PRECIO5=@PRECIO5,

TASAIVAID=@TASAIVAID,

TASAIVA=@TASAIVA,

CLAVE_MONEDA=@CLAVE_MONEDA,

COSTOREPOSICION=@COSTOREPOSICION,

COSTOULTIMO=@COSTOULTIMO,

COSTOPROMEDIO=@COSTOPROMEDIO,

CLAVE_SUSTITUTO=@CLAVE_SUSTITUTO,

MANEJALOTE=@MANEJALOTE,

ESKIT=@ESKIT,

IMPRIMIR=@IMPRIMIR,

INVENTARIABLE=@INVENTARIABLE,

NEGATIVOS=@NEGATIVOS,

LIMITEPRECIO2=@LIMITEPRECIO2,

PRECIOMAXIMOPUBLICO=@PRECIOMAXIMOPUBLICO,

CLAVE_PROVEEDOR1=@CLAVE_PROVEEDOR1,

CLAVE_PROVEEDOR2=@CLAVE_PROVEEDOR2,

CAMBIARPRECIO=@CAMBIARPRECIO,

SUBSTITUTO=@SUBSTITUTO,

CBARRAS=@CBARRAS,

CEMPAQUE=@CEMPAQUE,

PZACAJA=@PZACAJA,

U_EMPAQUE=@U_EMPAQUE,

UNIDAD=@UNIDAD,

INI_MAYO=@INI_MAYO,

MAYOKGS=@MAYOKGS,

TIPOABC=@TIPOABC,

CLAVE_TASAIVA=@CLAVE_TASAIVA,

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

FECHA2=@FECHA2,

CLAVE_PRODUCTOPADRE=@CLAVE_PRODUCTOPADRE,

ESPRODUCTOPADRE=@ESPRODUCTOPADRE,

ESPRODUCTOFINAL=@ESPRODUCTOFINAL,

ESSUBPRODUCTO=@ESSUBPRODUCTO,

TOMARPRECIOPADRE=@TOMARPRECIOPADRE,

TOMARCOMISIONPADRE=@TOMARCOMISIONPADRE,

TOMAROFERTAPADRE=@TOMAROFERTAPADRE,

COMISION=@COMISION,

OFERTA=@OFERTA,

PLUG=@PLUG,

TASAIEPS=@TASAIEPS,

MINUTILIDAD=@MINUTILIDAD,

AUTO_INSERT_FK=@AUTO_INSERT_FK,

SPRECIO1=@SPRECIO1,

SPRECIO2=@SPRECIO2,

SPRECIO3=@SPRECIO3,

SPRECIO4=@SPRECIO4,

SPRECIO5=@SPRECIO5,

REQUIERERECETA=@REQUIERERECETA,

CLASIFICA=@CLASIFICA,

PROMOMOVIL=@PROMOMOVIL,

MARGENMOVIL=@MARGENMOVIL,

MPRECIO4MOVIL=@MPRECIO4MOVIL,

CPRECIO4MOVIL=@CPRECIO4MOVIL,

TPRECIO4MOVIL=@TPRECIO4MOVIL,

APRECIO4MOVIL=@APRECIO4MOVIL,

CANTIDAD=@CANTIDAD,

LOTE=@LOTE,

FECHAVENCE=@FECHAVENCE
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


        public CCACHE_PRODMOVILBE seleccionarCACHE_PRODMOVIL(CCACHE_PRODMOVILBE oCCACHE_PRODMOVIL, FbTransaction st)
        {




            CCACHE_PRODMOVILBE retorno = new CCACHE_PRODMOVILBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from CACHE_PRODMOVIL where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCCACHE_PRODMOVIL.IID;
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

                    if (dr["EAN"] != System.DBNull.Value)
                    {
                        retorno.IEAN = (string)(dr["EAN"]);
                    }

                    if (dr["DESCRIPCION1"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION1 = (string)(dr["DESCRIPCION1"]);
                    }

                    if (dr["DESCRIPCION2"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION2 = (string)(dr["DESCRIPCION2"]);
                    }

                    if (dr["DESCRIPCION3"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION3 = (string)(dr["DESCRIPCION3"]);
                    }

                    if (dr["CLAVE_LINEA"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE_LINEA = (string)(dr["CLAVE_LINEA"]);
                    }

                    if (dr["CLAVE_MARCA"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE_MARCA = (string)(dr["CLAVE_MARCA"]);
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

                    if (dr["TASAIVAID"] != System.DBNull.Value)
                    {
                        retorno.ITASAIVAID = (long)(dr["TASAIVAID"]);
                    }

                    if (dr["TASAIVA"] != System.DBNull.Value)
                    {
                        retorno.ITASAIVA = (decimal)(dr["TASAIVA"]);
                    }

                    if (dr["CLAVE_MONEDA"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE_MONEDA = (string)(dr["CLAVE_MONEDA"]);
                    }

                    if (dr["COSTOREPOSICION"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOREPOSICION = (decimal)(dr["COSTOREPOSICION"]);
                    }

                    if (dr["COSTOULTIMO"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOULTIMO = (decimal)(dr["COSTOULTIMO"]);
                    }

                    if (dr["COSTOPROMEDIO"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOPROMEDIO = (decimal)(dr["COSTOPROMEDIO"]);
                    }

                    if (dr["CLAVE_SUSTITUTO"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE_SUSTITUTO = (string)(dr["CLAVE_SUSTITUTO"]);
                    }

                    if (dr["MANEJALOTE"] != System.DBNull.Value)
                    {
                        retorno.IMANEJALOTE = (string)(dr["MANEJALOTE"]);
                    }

                    if (dr["ESKIT"] != System.DBNull.Value)
                    {
                        retorno.IESKIT = (string)(dr["ESKIT"]);
                    }

                    if (dr["IMPRIMIR"] != System.DBNull.Value)
                    {
                        retorno.IIMPRIMIR = (string)(dr["IMPRIMIR"]);
                    }

                    if (dr["INVENTARIABLE"] != System.DBNull.Value)
                    {
                        retorno.IINVENTARIABLE = (string)(dr["INVENTARIABLE"]);
                    }

                    if (dr["NEGATIVOS"] != System.DBNull.Value)
                    {
                        retorno.INEGATIVOS = (string)(dr["NEGATIVOS"]);
                    }

                    if (dr["LIMITEPRECIO2"] != System.DBNull.Value)
                    {
                        retorno.ILIMITEPRECIO2 = (decimal)(dr["LIMITEPRECIO2"]);
                    }

                    if (dr["PRECIOMAXIMOPUBLICO"] != System.DBNull.Value)
                    {
                        retorno.IPRECIOMAXIMOPUBLICO = (decimal)(dr["PRECIOMAXIMOPUBLICO"]);
                    }

                    if (dr["CLAVE_PROVEEDOR1"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE_PROVEEDOR1 = (string)(dr["CLAVE_PROVEEDOR1"]);
                    }

                    if (dr["CLAVE_PROVEEDOR2"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE_PROVEEDOR2 = (string)(dr["CLAVE_PROVEEDOR2"]);
                    }

                    if (dr["CAMBIARPRECIO"] != System.DBNull.Value)
                    {
                        retorno.ICAMBIARPRECIO = (string)(dr["CAMBIARPRECIO"]);
                    }

                    if (dr["SUBSTITUTO"] != System.DBNull.Value)
                    {
                        retorno.ISUBSTITUTO = (string)(dr["SUBSTITUTO"]);
                    }

                    if (dr["CBARRAS"] != System.DBNull.Value)
                    {
                        retorno.ICBARRAS = (string)(dr["CBARRAS"]);
                    }

                    if (dr["CEMPAQUE"] != System.DBNull.Value)
                    {
                        retorno.ICEMPAQUE = (string)(dr["CEMPAQUE"]);
                    }

                    if (dr["PZACAJA"] != System.DBNull.Value)
                    {
                        retorno.IPZACAJA = (decimal)(dr["PZACAJA"]);
                    }

                    if (dr["U_EMPAQUE"] != System.DBNull.Value)
                    {
                        retorno.IU_EMPAQUE = (decimal)(dr["U_EMPAQUE"]);
                    }

                    if (dr["UNIDAD"] != System.DBNull.Value)
                    {
                        retorno.IUNIDAD = (string)(dr["UNIDAD"]);
                    }

                    if (dr["INI_MAYO"] != System.DBNull.Value)
                    {
                        retorno.IINI_MAYO = (decimal)(dr["INI_MAYO"]);
                    }

                    if (dr["MAYOKGS"] != System.DBNull.Value)
                    {
                        retorno.IMAYOKGS = (string)(dr["MAYOKGS"]);
                    }

                    if (dr["TIPOABC"] != System.DBNull.Value)
                    {
                        retorno.ITIPOABC = (string)(dr["TIPOABC"]);
                    }

                    if (dr["CLAVE_TASAIVA"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE_TASAIVA = (string)(dr["CLAVE_TASAIVA"]);
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
                        retorno.INUMERO1 = (decimal)(dr["NUMERO1"]);
                    }

                    if (dr["NUMERO2"] != System.DBNull.Value)
                    {
                        retorno.INUMERO2 = (decimal)(dr["NUMERO2"]);
                    }

                    if (dr["NUMERO3"] != System.DBNull.Value)
                    {
                        retorno.INUMERO3 = (decimal)(dr["NUMERO3"]);
                    }

                    if (dr["NUMERO4"] != System.DBNull.Value)
                    {
                        retorno.INUMERO4 = (decimal)(dr["NUMERO4"]);
                    }

                    if (dr["FECHA1"] != System.DBNull.Value)
                    {
                        retorno.IFECHA1 = (DateTime)(dr["FECHA1"]);
                    }

                    if (dr["FECHA2"] != System.DBNull.Value)
                    {
                        retorno.IFECHA2 = (DateTime)(dr["FECHA2"]);
                    }

                    if (dr["CLAVE_PRODUCTOPADRE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE_PRODUCTOPADRE = (string)(dr["CLAVE_PRODUCTOPADRE"]);
                    }

                    if (dr["ESPRODUCTOPADRE"] != System.DBNull.Value)
                    {
                        retorno.IESPRODUCTOPADRE = (string)(dr["ESPRODUCTOPADRE"]);
                    }

                    if (dr["ESPRODUCTOFINAL"] != System.DBNull.Value)
                    {
                        retorno.IESPRODUCTOFINAL = (string)(dr["ESPRODUCTOFINAL"]);
                    }

                    if (dr["ESSUBPRODUCTO"] != System.DBNull.Value)
                    {
                        retorno.IESSUBPRODUCTO = (string)(dr["ESSUBPRODUCTO"]);
                    }

                    if (dr["TOMARPRECIOPADRE"] != System.DBNull.Value)
                    {
                        retorno.ITOMARPRECIOPADRE = (string)(dr["TOMARPRECIOPADRE"]);
                    }

                    if (dr["TOMARCOMISIONPADRE"] != System.DBNull.Value)
                    {
                        retorno.ITOMARCOMISIONPADRE = (string)(dr["TOMARCOMISIONPADRE"]);
                    }

                    if (dr["TOMAROFERTAPADRE"] != System.DBNull.Value)
                    {
                        retorno.ITOMAROFERTAPADRE = (string)(dr["TOMAROFERTAPADRE"]);
                    }

                    if (dr["COMISION"] != System.DBNull.Value)
                    {
                        retorno.ICOMISION = (decimal)(dr["COMISION"]);
                    }

                    if (dr["OFERTA"] != System.DBNull.Value)
                    {
                        retorno.IOFERTA = (decimal)(dr["OFERTA"]);
                    }

                    if (dr["PLUG"] != System.DBNull.Value)
                    {
                        retorno.IPLUG = (string)(dr["PLUG"]);
                    }

                    if (dr["TASAIEPS"] != System.DBNull.Value)
                    {
                        retorno.ITASAIEPS = (decimal)(dr["TASAIEPS"]);
                    }

                    if (dr["MINUTILIDAD"] != System.DBNull.Value)
                    {
                        retorno.IMINUTILIDAD = (decimal)(dr["MINUTILIDAD"]);
                    }

                    if (dr["AUTO_INSERT_FK"] != System.DBNull.Value)
                    {
                        retorno.IAUTO_INSERT_FK = (string)(dr["AUTO_INSERT_FK"]);
                    }

                    if (dr["SPRECIO1"] != System.DBNull.Value)
                    {
                        retorno.ISPRECIO1 = (decimal)(dr["SPRECIO1"]);
                    }

                    if (dr["SPRECIO2"] != System.DBNull.Value)
                    {
                        retorno.ISPRECIO2 = (decimal)(dr["SPRECIO2"]);
                    }

                    if (dr["SPRECIO3"] != System.DBNull.Value)
                    {
                        retorno.ISPRECIO3 = (decimal)(dr["SPRECIO3"]);
                    }

                    if (dr["SPRECIO4"] != System.DBNull.Value)
                    {
                        retorno.ISPRECIO4 = (decimal)(dr["SPRECIO4"]);
                    }

                    if (dr["SPRECIO5"] != System.DBNull.Value)
                    {
                        retorno.ISPRECIO5 = (decimal)(dr["SPRECIO5"]);
                    }

                    if (dr["REQUIERERECETA"] != System.DBNull.Value)
                    {
                        retorno.IREQUIERERECETA = (string)(dr["REQUIERERECETA"]);
                    }

                    if (dr["CLASIFICA"] != System.DBNull.Value)
                    {
                        retorno.ICLASIFICA = (string)(dr["CLASIFICA"]);
                    }

                    if (dr["PROMOMOVIL"] != System.DBNull.Value)
                    {
                        retorno.IPROMOMOVIL = (string)(dr["PROMOMOVIL"]);
                    }

                    if (dr["MARGENMOVIL"] != System.DBNull.Value)
                    {
                        retorno.IMARGENMOVIL = (decimal)(dr["MARGENMOVIL"]);
                    }

                    if (dr["MPRECIO4MOVIL"] != System.DBNull.Value)
                    {
                        retorno.IMPRECIO4MOVIL = (decimal)(dr["MPRECIO4MOVIL"]);
                    }

                    if (dr["CPRECIO4MOVIL"] != System.DBNull.Value)
                    {
                        retorno.ICPRECIO4MOVIL = (decimal)(dr["CPRECIO4MOVIL"]);
                    }

                    if (dr["TPRECIO4MOVIL"] != System.DBNull.Value)
                    {
                        retorno.ITPRECIO4MOVIL = (decimal)(dr["TPRECIO4MOVIL"]);
                    }

                    if (dr["APRECIO4MOVIL"] != System.DBNull.Value)
                    {
                        retorno.IAPRECIO4MOVIL = (decimal)(dr["APRECIO4MOVIL"]);
                    }

                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDAD = (decimal)(dr["CANTIDAD"]);
                    }

                    if (dr["LOTE"] != System.DBNull.Value)
                    {
                        retorno.ILOTE = (string)(dr["LOTE"]);
                    }

                    if (dr["FECHAVENCE"] != System.DBNull.Value)
                    {
                        retorno.IFECHAVENCE = (DateTime)(dr["FECHAVENCE"]);
                    }

                    if (dr["PROVEEDOR1ID"] != System.DBNull.Value)
                    {
                        retorno.IPROVEEDOR1ID = int.Parse(dr["PROVEEDOR1ID"].ToString());
                    }

                    if (dr["PROVEEDOR2ID"] != System.DBNull.Value)
                    {
                        retorno.IPROVEEDOR2ID = int.Parse(dr["PROVEEDOR2ID"].ToString());
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









        public DataSet enlistarCACHE_PRODMOVIL()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_CACHE_PRODMOVIL_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public DataSet enlistarCortoCACHE_PRODMOVIL()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_CACHE_PRODMOVIL_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public int ExisteCACHE_PRODMOVIL(CCACHE_PRODMOVILBE oCCACHE_PRODMOVIL, FbTransaction st)
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
                auxPar.Value = oCCACHE_PRODMOVIL.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from CACHE_PRODMOVIL where

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




        public CCACHE_PRODMOVILBE AgregarCACHE_PRODMOVIL(CCACHE_PRODMOVILBE oCCACHE_PRODMOVIL, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCACHE_PRODMOVIL(oCCACHE_PRODMOVIL, st);
                if (iRes == 1)
                {
                    this.IComentario = "El CACHE_PRODMOVIL ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarCACHE_PRODMOVILD(oCCACHE_PRODMOVIL, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarCACHE_PRODMOVIL(CCACHE_PRODMOVILBE oCCACHE_PRODMOVIL, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCACHE_PRODMOVIL(oCCACHE_PRODMOVIL, st);
                if (iRes == 0)
                {
                    this.IComentario = "El CACHE_PRODMOVIL no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarCACHE_PRODMOVILD(oCCACHE_PRODMOVIL, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarCACHE_PRODMOVIL(CCACHE_PRODMOVILBE oCCACHE_PRODMOVILNuevo, CCACHE_PRODMOVILBE oCCACHE_PRODMOVILAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCACHE_PRODMOVIL(oCCACHE_PRODMOVILAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El CACHE_PRODMOVIL no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarCACHE_PRODMOVILD(oCCACHE_PRODMOVILNuevo, oCCACHE_PRODMOVILAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CCACHE_PRODMOVILD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }



    public class CACHEIMPOBUFFER
    {

        CPRODUCTOBE oCPRODUCTO;
        string p_claveLinea;
        string p_claveMarca;
        string p_claveMoneda;
        string p_claveSustituto;
        string p_proveedor1;
        string p_proveedor2;
        string p_claveTasaIva;
        string p_claveProductoPadre;
        decimal cantidad;
        string lote;
        DateTime fechavence;

        public CPRODUCTOBE OCPRODUCTO { get => oCPRODUCTO; set => oCPRODUCTO = value; }
        public string P_claveLinea { get => p_claveLinea; set => p_claveLinea = value; }
        public string P_claveMarca { get => p_claveMarca; set => p_claveMarca = value; }
        public string P_claveMoneda { get => p_claveMoneda; set => p_claveMoneda = value; }
        public string P_claveSustituto { get => p_claveSustituto; set => p_claveSustituto = value; }
        public string P_proveedor1 { get => p_proveedor1; set => p_proveedor1 = value; }
        public string P_proveedor2 { get => p_proveedor2; set => p_proveedor2 = value; }
        public string P_claveTasaIva { get => p_claveTasaIva; set => p_claveTasaIva = value; }
        public string P_claveProductoPadre { get => p_claveProductoPadre; set => p_claveProductoPadre = value; }
        public decimal Cantidad { get => cantidad; set => cantidad = value; }
        public string Lote { get => lote; set => lote = value; }
        public DateTime Fechavence { get => fechavence; set => fechavence = value; }
         
        public CACHEIMPOBUFFER(CPRODUCTOBE oCPRODUCTO, string p_claveLinea, string p_claveMarca, string p_claveMoneda, string p_claveSustituto, string p_proveedor1, string p_proveedor2, string p_claveTasaIva, string p_claveProductoPadre, decimal cantidad, string lote, DateTime fechavence)
        {

            this.oCPRODUCTO = oCPRODUCTO;
            this.p_claveLinea = p_claveLinea;
            this.p_claveMarca = p_claveMarca;
            this.p_claveMoneda = p_claveMoneda;
            this.p_claveSustituto = p_claveSustituto;
            this.p_proveedor1 = p_proveedor1;
            this.p_proveedor2 = p_proveedor2;
            this.p_claveTasaIva = p_claveTasaIva;
            this.p_claveProductoPadre = p_claveProductoPadre;
            this.cantidad = cantidad;
            this.lote = lote;
            this.fechavence = fechavence;
        }





    }
}
