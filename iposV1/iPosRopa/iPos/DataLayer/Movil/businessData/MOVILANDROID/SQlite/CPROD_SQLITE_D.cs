using iPosBusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Collections;
using System.Data;

namespace iPosData
{
    public class CPROD_SQLITE_D: IPRODD
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



        public bool CreateTablePROD_MOVIL( string strOleDbConn)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(strOleDbConn);
            try
            {

                m_dbConnection.Open();

                string sql = @"CREATE TABLE PROD ( 

PRODUCTO TEXT,
DESC1 TEXT,
PRECIO1 NUMERIC,
DESCUENTO1 NUMERIC,
U_EMPAQUE NUMERIC,
MONEDA TEXT,
UNIDAD TEXT,
SERIE TEXT,
LOTE TEXT,
PROVEEDOR TEXT,
PROVEEDOR2 TEXT,
LINEA TEXT,
MARCA TEXT,
DESC2 TEXT,
DESC3 TEXT,
PRECIO2 NUMERIC,
PRECIO3 NUMERIC,
PRECIO4 NUMERIC,
PRECIO5 NUMERIC,
PRECIO6 NUMERIC,
PRECIO7 NUMERIC,
CODIGO TEXT,
CARGOS_U NUMERIC,
COSTO_REPO NUMERIC,
IMPRIMIR TEXT,
INVENTARIO TEXT,
IMPUESTO NUMERIC,
NEGATIVOS TEXT,
COMODIN TEXT,
LIMITE1 NUMERIC,
DESCUENTO2 NUMERIC,
LIMITE2 NUMERIC,
DESCUENTO3 NUMERIC,
KIT TEXT,
PIEZAS NUMERIC,
LPIEZAS TEXT,
COMISION NUMERIC,
COMISION_E NUMERIC,
PROMOCION TEXT,
ID TEXT,
ID_FECHA TEXT,
ID_HORA TEXT,
SUSTITUTO TEXT,
CBARRAS TEXT,
EMPAQUE NUMERIC,
PESO NUMERIC,
PRECIO8 NUMERIC,
PRECIO9 NUMERIC,
U_CAJA NUMERIC,
CUENTA TEXT,
RANKING NUMERIC,
TIPOABC TEXT,
TRAFICO TEXT,
UNIDAD2 TEXT,
U_VENTA2 NUMERIC,
VOLUMEN NUMERIC,
ABO NUMERIC,
LOC TEXT,
COSTO_ULTI NUMERIC,
COSTOULTUS NUMERIC,
C_P_I NUMERIC,
C_R_I NUMERIC,
C_U_I NUMERIC,
COSTOREPUS NUMERIC,
ORDEN NUMERIC,
FORDEN TEXT,
APARTAKIT NUMERIC,
FMAXDIA TEXT,
PZACAJA NUMERIC,
CEMPAQUE TEXT,
MAYOXKG TEXT,
FCAMBIO TEXT,
INIMAYO NUMERIC,
CVETASAIVA TEXT,
NOMBRE TEXT,
PRODPADRE TEXT,
TEXTO1 TEXT,
TEXTO2 TEXT,
TEXTO3 TEXT,
TEXTO4 TEXT,
TEXTO5 TEXT,
TEXTO6 TEXT,
NUMERO1 NUMERIC,
NUMERO2 NUMERIC,
NUMERO3 NUMERIC,
NUMERO4 NUMERIC,
FECHA1 TEXT,
FECHA2 TEXT,
ESPADRE TEXT,
ESFINAL TEXT,
ESSUBPROD TEXT,
PRECPADRE TEXT,
COMIPADRE TEXT,
OFEPADRE TEXT,
OFERTA NUMERIC,
[DESC] TEXT,
CAMBIARPRE TEXT,
PLUG TEXT,
COSTOPROUS NUMERIC,
TASAIEPS NUMERIC,
MINUTIL NUMERIC,
SPRECIO1 NUMERIC,
SPRECIO2 NUMERIC,
SPRECIO3 NUMERIC,
SPRECIO4 NUMERIC,
SPRECIO5 NUMERIC,
RRECETA TEXT,
PRECTOPE NUMERIC,
PRECIOMAT TEXT,
MENUDEO NUMERIC,
CLAVE_CONT TEXT,
CONTENIDO NUMERIC,
CLASIFICA TEXT,
CANTXPIEZA NUMERIC,
LOTEIMPO TEXT,
COSTOUSD NUMERIC,
PLAZO TEXT,
CLAVESAT TEXT,
ESPRODPROM TEXT,
BASEPROM TEXT,
VIGPROM TEXT,
EXIS1 NUMERIC,
VIGKIT TEXT,
KITCVIG TEXT,
VALXSUC TEXT,
DESGKIT TEXT,
PUPRECIO1 NUMERIC,
PUPRECIO2 NUMERIC,
PUPRECIO3 NUMERIC,
PUPRECIO4 NUMERIC,
PUPRECIO5 NUMERIC,
IMPCOM TEXT,
ULTIMACOMPRA DATE,
ULTIMAVENTA DATE,
LINEANOMBRE TEXT,
MARCANOMBRE TEXT,
PROVEEDORNOMBRE TEXT


); ";

                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                m_dbConnection.Close();
                m_dbConnection.Dispose();
                command.Dispose();

                GC.Collect();

            }
            catch { }
            finally { try { m_dbConnection.Close(); } catch { } }
            return true;
        }


        public bool AgregarPROD_MOVIL(CPRODBE oCPROD, string strFileName, /*SQLiteTransaction st,*/ string strOleDbConn)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                SQLiteParameter auxPar;



                auxPar = new SQLiteParameter("$PRODUCTO", DbType.String);
                if (!(bool)oCPROD.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCPROD.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$DESC1", DbType.String);
                if (!(bool)oCPROD.isnull["IDESC1"])
                {
                    auxPar.Value = oCPROD.IDESC1;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$PRECIO1", DbType.Double);
                if (!(bool)oCPROD.isnull["IPRECIO1"])
                {
                    auxPar.Value = oCPROD.IPRECIO1;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$DESCUENTO1", DbType.Double);
                if (!(bool)oCPROD.isnull["IDESCUENTO1"])
                {
                    auxPar.Value = oCPROD.IDESCUENTO1;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$U_EMPAQUE", DbType.Double);
                if (!(bool)oCPROD.isnull["IU_EMPAQUE"])
                {
                    auxPar.Value = oCPROD.IU_EMPAQUE;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$MONEDA", DbType.String);
                if (!(bool)oCPROD.isnull["IMONEDA"])
                {
                    auxPar.Value = oCPROD.IMONEDA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$UNIDAD", DbType.String);
                if (!(bool)oCPROD.isnull["IUNIDAD"])
                {
                    auxPar.Value = oCPROD.IUNIDAD;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$SERIE", DbType.String);
                if (!(bool)oCPROD.isnull["ISERIE"])
                {
                    auxPar.Value = oCPROD.ISERIE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$LOTE", DbType.String);
                if (!(bool)oCPROD.isnull["ILOTE"])
                {
                    auxPar.Value = oCPROD.ILOTE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$PROVEEDOR", DbType.String);
                if (!(bool)oCPROD.isnull["IPROVEEDOR"])
                {
                    auxPar.Value = oCPROD.IPROVEEDOR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$PROVEEDOR2", DbType.String);
                if (!(bool)oCPROD.isnull["IPROVEEDOR2"])
                {
                    auxPar.Value = oCPROD.IPROVEEDOR2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$LINEA", DbType.String);
                if (!(bool)oCPROD.isnull["ILINEA"])
                {
                    auxPar.Value = oCPROD.ILINEA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$MARCA", DbType.String);
                if (!(bool)oCPROD.isnull["IMARCA"])
                {
                    auxPar.Value = oCPROD.IMARCA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$DESC2", DbType.String);
                if (!(bool)oCPROD.isnull["IDESC2"])
                {
                    auxPar.Value = oCPROD.IDESC2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$DESC3", DbType.String);
                if (!(bool)oCPROD.isnull["IDESC3"])
                {
                    auxPar.Value = oCPROD.IDESC3;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$PRECIO2", DbType.Double);
                if (!(bool)oCPROD.isnull["IPRECIO2"])
                {
                    auxPar.Value = oCPROD.IPRECIO2;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$PRECIO3", DbType.Double);
                if (!(bool)oCPROD.isnull["IPRECIO3"])
                {
                    auxPar.Value = oCPROD.IPRECIO3;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$PRECIO4", DbType.Double);
                if (!(bool)oCPROD.isnull["IPRECIO4"])
                {
                    auxPar.Value = oCPROD.IPRECIO4;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$PRECIO5", DbType.Double);
                if (!(bool)oCPROD.isnull["IPRECIO5"])
                {
                    auxPar.Value = oCPROD.IPRECIO5;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$PRECIO6", DbType.Double);
                if (!(bool)oCPROD.isnull["IPRECIO6"])
                {
                    auxPar.Value = oCPROD.IPRECIO6;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$PRECIO7", DbType.Double);
                if (!(bool)oCPROD.isnull["IPRECIO7"])
                {
                    auxPar.Value = oCPROD.IPRECIO7;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$CODIGO", DbType.String);
                if (!(bool)oCPROD.isnull["ICODIGO"])
                {
                    auxPar.Value = oCPROD.ICODIGO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$CARGOS_U", DbType.Double);
                if (!(bool)oCPROD.isnull["ICARGOS_U"])
                {
                    auxPar.Value = oCPROD.ICARGOS_U;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$COSTO_REPO", DbType.Double);
                if (!(bool)oCPROD.isnull["ICOSTO_REPO"])
                {
                    auxPar.Value = oCPROD.ICOSTO_REPO;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$IMPRIMIR", DbType.String);
                if (!(bool)oCPROD.isnull["IIMPRIMIR"])
                {
                    auxPar.Value = oCPROD.IIMPRIMIR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$INVENTARIO", DbType.String);
                if (!(bool)oCPROD.isnull["IINVENTARIO"])
                {
                    auxPar.Value = oCPROD.IINVENTARIO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$IMPUESTO", DbType.Double);
                if (!(bool)oCPROD.isnull["IIMPUESTO"])
                {
                    auxPar.Value = oCPROD.IIMPUESTO;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$NEGATIVOS", DbType.String);
                if (!(bool)oCPROD.isnull["INEGATIVOS"])
                {
                    auxPar.Value = oCPROD.INEGATIVOS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$COMODIN", DbType.String);
                if (!(bool)oCPROD.isnull["ICOMODIN"])
                {
                    auxPar.Value = oCPROD.ICOMODIN;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$LIMITE1", DbType.Double);
                if (!(bool)oCPROD.isnull["ILIMITE1"])
                {
                    auxPar.Value = oCPROD.ILIMITE1;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$DESCUENTO2", DbType.Double);
                if (!(bool)oCPROD.isnull["IDESCUENTO2"])
                {
                    auxPar.Value = oCPROD.IDESCUENTO2;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$LIMITE2", DbType.Double);
                if (!(bool)oCPROD.isnull["ILIMITE2"])
                {
                    auxPar.Value = oCPROD.ILIMITE2;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$DESCUENTO3", DbType.Double);
                if (!(bool)oCPROD.isnull["IDESCUENTO3"])
                {
                    auxPar.Value = oCPROD.IDESCUENTO3;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$KIT", DbType.String);
                if (!(bool)oCPROD.isnull["IKIT"])
                {
                    auxPar.Value = oCPROD.IKIT;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$PIEZAS", DbType.Double);
                if (!(bool)oCPROD.isnull["IPIEZAS"])
                {
                    auxPar.Value = oCPROD.IPIEZAS;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$LPIEZAS", DbType.String);
                if (!(bool)oCPROD.isnull["ILPIEZAS"])
                {
                    auxPar.Value = oCPROD.ILPIEZAS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$COMISION", DbType.Double);
                if (!(bool)oCPROD.isnull["ICOMISION"])
                {
                    auxPar.Value = oCPROD.ICOMISION;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$COMISION_E", DbType.Double);
                if (!(bool)oCPROD.isnull["ICOMISION_E"])
                {
                    auxPar.Value = oCPROD.ICOMISION_E;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$PROMOCION", DbType.String);
                if (!(bool)oCPROD.isnull["IPROMOCION"])
                {
                    auxPar.Value = oCPROD.IPROMOCION;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$ID", DbType.String);
                if (!(bool)oCPROD.isnull["IID"])
                {
                    auxPar.Value = oCPROD.IID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$ID_FECHA", DbType.Date);
                if (!(bool)oCPROD.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCPROD.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$ID_HORA", DbType.String);
                if (!(bool)oCPROD.isnull["IID_HORA"])
                {
                    auxPar.Value = oCPROD.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$SUSTITUTO", DbType.String);
                if (!(bool)oCPROD.isnull["ISUSTITUTO"])
                {
                    auxPar.Value = oCPROD.ISUSTITUTO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$CBARRAS", DbType.String);
                if (!(bool)oCPROD.isnull["ICBARRAS"])
                {
                    auxPar.Value = oCPROD.ICBARRAS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$EMPAQUE", DbType.Double);
                if (!(bool)oCPROD.isnull["IEMPAQUE"])
                {
                    auxPar.Value = oCPROD.IEMPAQUE;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$PESO", DbType.Double);
                if (!(bool)oCPROD.isnull["IPESO"])
                {
                    auxPar.Value = oCPROD.IPESO;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$PRECIO8", DbType.Double);
                if (!(bool)oCPROD.isnull["IPRECIO8"])
                {
                    auxPar.Value = oCPROD.IPRECIO8;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$PRECIO9", DbType.Double);
                if (!(bool)oCPROD.isnull["IPRECIO9"])
                {
                    auxPar.Value = oCPROD.IPRECIO9;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$U_CAJA", DbType.Double);
                if (!(bool)oCPROD.isnull["IU_CAJA"])
                {
                    auxPar.Value = oCPROD.IU_CAJA;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$CUENTA", DbType.String);
                if (!(bool)oCPROD.isnull["ICUENTA"])
                {
                    auxPar.Value = oCPROD.ICUENTA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$RANKING", DbType.Double);
                if (!(bool)oCPROD.isnull["IRANKING"])
                {
                    auxPar.Value = oCPROD.IRANKING;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$TIPOABC", DbType.String);
                if (!(bool)oCPROD.isnull["ITIPOABC"])
                {
                    auxPar.Value = oCPROD.ITIPOABC;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$TRAFICO", DbType.String);
                if (!(bool)oCPROD.isnull["ITRAFICO"])
                {
                    auxPar.Value = oCPROD.ITRAFICO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$UNIDAD2", DbType.String);
                if (!(bool)oCPROD.isnull["IUNIDAD2"])
                {
                    auxPar.Value = oCPROD.IUNIDAD2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$U_VENTA2", DbType.Double);
                if (!(bool)oCPROD.isnull["IU_VENTA2"])
                {
                    auxPar.Value = oCPROD.IU_VENTA2;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$VOLUMEN", DbType.Double);
                if (!(bool)oCPROD.isnull["IVOLUMEN"])
                {
                    auxPar.Value = oCPROD.IVOLUMEN;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$ABO", DbType.Double);
                if (!(bool)oCPROD.isnull["IABO"])
                {
                    auxPar.Value = oCPROD.IABO;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$LOC", DbType.String);
                if (!(bool)oCPROD.isnull["ILOC"])
                {
                    auxPar.Value = oCPROD.ILOC;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$COSTO_ULTI", DbType.Double);
                if (!(bool)oCPROD.isnull["ICOSTO_ULTI"])
                {
                    auxPar.Value = oCPROD.ICOSTO_ULTI;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$COSTOULTUS", DbType.Double);
                if (!(bool)oCPROD.isnull["ICOSTOULTUS"])
                {
                    auxPar.Value = oCPROD.ICOSTOULTUS;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$C_P_I", DbType.Double);
                if (!(bool)oCPROD.isnull["IC_P_I"])
                {
                    auxPar.Value = oCPROD.IC_P_I;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$C_R_I", DbType.Double);
                if (!(bool)oCPROD.isnull["IC_R_I"])
                {
                    auxPar.Value = oCPROD.IC_R_I;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$C_U_I", DbType.Double);
                if (!(bool)oCPROD.isnull["IC_U_I"])
                {
                    auxPar.Value = oCPROD.IC_U_I;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$COSTOREPUS", DbType.Double);
                if (!(bool)oCPROD.isnull["ICOSTOREPUS"])
                {
                    auxPar.Value = oCPROD.ICOSTOREPUS;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$ORDEN", DbType.Double);
                if (!(bool)oCPROD.isnull["IORDEN"])
                {
                    auxPar.Value = oCPROD.IORDEN;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$FORDEN", DbType.Date);
                if (!(bool)oCPROD.isnull["IFORDEN"])
                {
                    auxPar.Value = oCPROD.IFORDEN;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$APARTAKIT", DbType.Double);
                if (!(bool)oCPROD.isnull["IAPARTAKIT"])
                {
                    auxPar.Value = oCPROD.IAPARTAKIT;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$FMAXDIA", DbType.Date);
                if (!(bool)oCPROD.isnull["IFMAXDIA"])
                {
                    auxPar.Value = oCPROD.IFMAXDIA;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$PZACAJA", DbType.Double);
                if (!(bool)oCPROD.isnull["IPZACAJA"])
                {
                    auxPar.Value = oCPROD.IPZACAJA;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$CEMPAQUE", DbType.String);
                if (!(bool)oCPROD.isnull["ICEMPAQUE"])
                {
                    auxPar.Value = oCPROD.ICEMPAQUE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$MAYOXKG", DbType.String);
                if (!(bool)oCPROD.isnull["IMAYOXKG"])
                {
                    auxPar.Value = oCPROD.IMAYOXKG;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$FCAMBIO", DbType.Date);
                if (!(bool)oCPROD.isnull["IFCAMBIO"])
                {
                    auxPar.Value = oCPROD.IFCAMBIO;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$INIMAYO", DbType.Double);
                if (!(bool)oCPROD.isnull["IINIMAYO"])
                {
                    auxPar.Value = oCPROD.IINIMAYO;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$CVETASAIVA", DbType.String);
                if (!(bool)oCPROD.isnull["ICVETASAIVA"])
                {
                    auxPar.Value = oCPROD.ICVETASAIVA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new SQLiteParameter("$NOMBRE", DbType.String);
                if (!(bool)oCPROD.isnull["INOMBRE"])
                {
                    auxPar.Value = oCPROD.INOMBRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$PRODPADRE", DbType.String);
                if (!(bool)oCPROD.isnull["IPRODPADRE"])
                {
                    auxPar.Value = oCPROD.IPRODPADRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);




                auxPar = new SQLiteParameter("$TEXTO1", DbType.String);
                if (!(bool)oCPROD.isnull["ITEXTO1"])
                {
                    auxPar.Value = oCPROD.ITEXTO1;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new SQLiteParameter("$TEXTO2", DbType.String);
                if (!(bool)oCPROD.isnull["ITEXTO2"])
                {
                    auxPar.Value = oCPROD.ITEXTO2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new SQLiteParameter("$TEXTO3", DbType.String);
                if (!(bool)oCPROD.isnull["ITEXTO3"])
                {
                    auxPar.Value = oCPROD.ITEXTO3;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new SQLiteParameter("$TEXTO4", DbType.String);
                if (!(bool)oCPROD.isnull["ITEXTO4"])
                {
                    auxPar.Value = oCPROD.ITEXTO4;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new SQLiteParameter("$TEXTO5", DbType.String);
                if (!(bool)oCPROD.isnull["ITEXTO5"])
                {
                    auxPar.Value = oCPROD.ITEXTO5;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new SQLiteParameter("$TEXTO6", DbType.String);
                if (!(bool)oCPROD.isnull["ITEXTO6"])
                {
                    auxPar.Value = oCPROD.ITEXTO6;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new SQLiteParameter("$NUMERO1", DbType.Double);
                if (!(bool)oCPROD.isnull["INUMERO1"])
                {
                    auxPar.Value = oCPROD.INUMERO1;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);



                auxPar = new SQLiteParameter("$NUMERO2", DbType.Double);
                if (!(bool)oCPROD.isnull["INUMERO2"])
                {
                    auxPar.Value = oCPROD.INUMERO2;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);




                auxPar = new SQLiteParameter("$NUMERO3", DbType.Double);
                if (!(bool)oCPROD.isnull["INUMERO3"])
                {
                    auxPar.Value = oCPROD.INUMERO3;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);



                auxPar = new SQLiteParameter("$NUMERO4", DbType.Double);
                if (!(bool)oCPROD.isnull["INUMERO4"])
                {
                    auxPar.Value = oCPROD.INUMERO4;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);





                auxPar = new SQLiteParameter("$FECHA1", DbType.Date);
                if (!(bool)oCPROD.isnull["IFECHA1"])
                {
                    auxPar.Value = oCPROD.IFECHA1;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$FECHA2", DbType.Date);
                if (!(bool)oCPROD.isnull["IFECHA2"])
                {
                    auxPar.Value = oCPROD.IFECHA2;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);



                auxPar = new SQLiteParameter("$ESPADRE", DbType.String);
                if (!(bool)oCPROD.isnull["IESPADRE"])
                {
                    auxPar.Value = oCPROD.IESPADRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new SQLiteParameter("$ESFINAL", DbType.String);
                if (!(bool)oCPROD.isnull["IESFINAL"])
                {
                    auxPar.Value = oCPROD.IESFINAL;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new SQLiteParameter("$ESSUBPROD", DbType.String);
                if (!(bool)oCPROD.isnull["IESSUBPROD"])
                {
                    auxPar.Value = oCPROD.IESSUBPROD;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new SQLiteParameter("$PRECPADRE", DbType.String);
                if (!(bool)oCPROD.isnull["IPRECPADRE"])
                {
                    auxPar.Value = oCPROD.IPRECPADRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new SQLiteParameter("$COMIPADRE", DbType.String);
                if (!(bool)oCPROD.isnull["ICOMIPADRE"])
                {
                    auxPar.Value = oCPROD.ICOMIPADRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new SQLiteParameter("$OFEPADRE", DbType.String);
                if (!(bool)oCPROD.isnull["IOFEPADRE"])
                {
                    auxPar.Value = oCPROD.IOFEPADRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$OFERTA", DbType.Double);
                if (!(bool)oCPROD.isnull["IOFERTA"])
                {
                    auxPar.Value = oCPROD.IOFERTA;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$DESC", DbType.String);
                if (!(bool)oCPROD.isnull["IDESC"])
                {
                    auxPar.Value = oCPROD.IDESC;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$CAMBIARPRE", DbType.String);
                if (!(bool)oCPROD.isnull["ICAMBIARPRE"])
                {
                    auxPar.Value = oCPROD.ICAMBIARPRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$PLUG", DbType.String);
                if (!(bool)oCPROD.isnull["IPLUG"])
                {
                    auxPar.Value = oCPROD.IPLUG;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$COSTOPROUS", DbType.Double);
                auxPar.Value = 0.00;
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$TASAIEPS", DbType.Double);
                if (!(bool)oCPROD.isnull["ITASAIEPS"])
                {
                    auxPar.Value = oCPROD.ITASAIEPS;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$MINUTIL", DbType.Double);
                if (!(bool)oCPROD.isnull["IMINUTIL"])
                {
                    auxPar.Value = oCPROD.IMINUTIL;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);



                auxPar = new SQLiteParameter("$SPRECIO1", DbType.Double);
                if (!(bool)oCPROD.isnull["ISPRECIO1"])
                {
                    auxPar.Value = oCPROD.ISPRECIO1;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);

                auxPar = new SQLiteParameter("$SPRECIO2", DbType.Double);
                if (!(bool)oCPROD.isnull["ISPRECIO2"])
                {
                    auxPar.Value = oCPROD.ISPRECIO2;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$SPRECIO3", DbType.Double);
                if (!(bool)oCPROD.isnull["ISPRECIO3"])
                {
                    auxPar.Value = oCPROD.ISPRECIO3;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$SPRECIO4", DbType.Double);
                if (!(bool)oCPROD.isnull["ISPRECIO4"])
                {
                    auxPar.Value = oCPROD.ISPRECIO4;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$SPRECIO5", DbType.Double);
                if (!(bool)oCPROD.isnull["ISPRECIO5"])
                {
                    auxPar.Value = oCPROD.ISPRECIO5;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);




                auxPar = new SQLiteParameter("$RRECETA", DbType.String);
                if (!(bool)oCPROD.isnull["IRRECETA"])
                {
                    auxPar.Value = oCPROD.IRRECETA;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new SQLiteParameter("$PRECTOPE", DbType.Double);
                if (!(bool)oCPROD.isnull["IPRECTOPE"])
                {
                    auxPar.Value = oCPROD.IPRECTOPE;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$PRECIOMAT", DbType.String);
                if (!(bool)oCPROD.isnull["IPRECIOMAT"])
                {
                    auxPar.Value = oCPROD.IPRECIOMAT;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new SQLiteParameter("$MENUDEO", DbType.Int32);
                if (!(bool)oCPROD.isnull["IMENUDEO"])
                {
                    auxPar.Value = oCPROD.IMENUDEO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$CLAVE_CONT", DbType.String);
                if (!(bool)oCPROD.isnull["ICLAVE_CONT"])
                {
                    auxPar.Value = oCPROD.ICLAVE_CONT;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$CONTENIDO", DbType.Double);
                if (!(bool)oCPROD.isnull["ICONTENIDO"])
                {
                    auxPar.Value = oCPROD.ICONTENIDO;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$CLASIFICA", DbType.String);
                if (!(bool)oCPROD.isnull["ICLASIFICA"])
                {
                    auxPar.Value = oCPROD.ICLASIFICA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$CANTXPIEZA", DbType.Double);
                if (!(bool)oCPROD.isnull["ICANTXPIEZA"])
                {
                    auxPar.Value = oCPROD.ICANTXPIEZA;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$LOTEIMPO", DbType.String);
                if (!(bool)oCPROD.isnull["ILOTEIMPO"])
                {
                    auxPar.Value = oCPROD.ILOTEIMPO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$COSTOUSD", DbType.Double);
                if (!(bool)oCPROD.isnull["ICOSTOUSD"])
                {
                    auxPar.Value = oCPROD.ICOSTOUSD;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);



                auxPar = new SQLiteParameter("$PLAZO", DbType.String);
                if (!(bool)oCPROD.isnull["IPLAZO"])
                {
                    auxPar.Value = oCPROD.IPLAZO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new SQLiteParameter("$CLAVESAT", DbType.String);
                if (!(bool)oCPROD.isnull["ICLAVESAT"])
                {
                    auxPar.Value = oCPROD.ICLAVESAT;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$ESPRODPROM", DbType.String);
                if (!(bool)oCPROD.isnull["IESPRODPROM"])
                {
                    auxPar.Value = oCPROD.IESPRODPROM;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$BASEPROM", DbType.String);
                if (!(bool)oCPROD.isnull["IBASEPROM"])
                {
                    auxPar.Value = oCPROD.IBASEPROM;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$VIGPROM", DbType.Date);
                if (!(bool)oCPROD.isnull["IVIGPROM"])
                {
                    auxPar.Value = oCPROD.IVIGPROM;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);



                auxPar = new SQLiteParameter("$EXIS1", DbType.Double);
                if (!(bool)oCPROD.isnull["IEXIS1"])
                {
                    auxPar.Value = oCPROD.IEXIS1;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);

                auxPar = new SQLiteParameter("$VIGKIT", DbType.Date);
                if (!(bool)oCPROD.isnull["IVIGKIT"])
                {
                    auxPar.Value = oCPROD.IVIGKIT;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);

                auxPar = new SQLiteParameter("$KITCVIG", DbType.String);
                if (!(bool)oCPROD.isnull["IKITCVIG"])
                {
                    auxPar.Value = oCPROD.IKITCVIG;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new SQLiteParameter("$VALXSUC", DbType.String);
                if (!(bool)oCPROD.isnull["IVALXSUC"])
                {
                    auxPar.Value = oCPROD.IVALXSUC;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new SQLiteParameter("$DESGKIT", DbType.Boolean);
                if (!(bool)oCPROD.isnull["IDESGKIT"])
                {
                    auxPar.Value = oCPROD.IDESGKIT;
                }
                else
                {
                    auxPar.Value = false;
                }
                parts.Add(auxPar);



                auxPar = new SQLiteParameter("$PUPRECIO1", DbType.Double);
                if (!(bool)oCPROD.isnull["IPUPRECIO1"])
                {
                    auxPar.Value = oCPROD.IPUPRECIO1;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);

                auxPar = new SQLiteParameter("$PUPRECIO2", DbType.Double);
                if (!(bool)oCPROD.isnull["IPUPRECIO2"])
                {
                    auxPar.Value = oCPROD.IPUPRECIO2;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$PUPRECIO3", DbType.Double);
                if (!(bool)oCPROD.isnull["IPUPRECIO3"])
                {
                    auxPar.Value = oCPROD.IPUPRECIO3;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$PUPRECIO4", DbType.Double);
                if (!(bool)oCPROD.isnull["IPUPRECIO4"])
                {
                    auxPar.Value = oCPROD.IPUPRECIO4;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$PUPRECIO5", DbType.Double);
                if (!(bool)oCPROD.isnull["IPUPRECIO5"])
                {
                    auxPar.Value = oCPROD.IPUPRECIO5;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$IMPCOM", DbType.String);
                if (!(bool)oCPROD.isnull["IIMPCOM"])
                {
                    auxPar.Value = oCPROD.IIMPCOM;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new SQLiteParameter("$ULTIMACOMPRA", DbType.Date);
                if (!(bool)oCPROD.isnull["IULTIMACOMPRA"])
                {
                    auxPar.Value = oCPROD.IULTIMACOMPRA;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$ULTIMAVENTA", DbType.Date);
                if (!(bool)oCPROD.isnull["IULTIMAVENTA"])
                {
                    auxPar.Value = oCPROD.IULTIMAVENTA;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$LINEANOMBRE", DbType.String);
                if (!(bool)oCPROD.isnull["ILINEANOMBRE"])
                {
                    auxPar.Value = oCPROD.ILINEANOMBRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$MARCANOMBRE", DbType.String);
                if (!(bool)oCPROD.isnull["IMARCANOMBRE"])
                {
                    auxPar.Value = oCPROD.IMARCANOMBRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$PROVEEDORNOMBRE", DbType.String);
                if (!(bool)oCPROD.isnull["IPROVEEDORNOMBRE"])
                {
                    auxPar.Value = oCPROD.IPROVEEDORNOMBRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);






                string commandText = @"
        INSERT INTO  PROD 
      (
    PRODUCTO,
DESC1,
PRECIO1,
DESCUENTO1,
U_EMPAQUE,
MONEDA,
UNIDAD,
SERIE,
LOTE,
PROVEEDOR,
PROVEEDOR2,
LINEA,
MARCA,
DESC2,
DESC3,
PRECIO2,
PRECIO3,
PRECIO4,
PRECIO5,
PRECIO6,
PRECIO7,
CODIGO,
CARGOS_U,
COSTO_REPO,
IMPRIMIR,
INVENTARIO,
IMPUESTO,
NEGATIVOS,
COMODIN,
LIMITE1,
DESCUENTO2,
LIMITE2,
DESCUENTO3,
KIT,
PIEZAS,
LPIEZAS,
COMISION,
COMISION_E,
PROMOCION,
ID,
ID_FECHA,
ID_HORA,
SUSTITUTO,
CBARRAS,
EMPAQUE,
PESO,
PRECIO8,
PRECIO9,
U_CAJA,
CUENTA,
RANKING,
TIPOABC,
TRAFICO,
UNIDAD2,
U_VENTA2,
VOLUMEN,
ABO,
LOC,
COSTO_ULTI,
COSTOULTUS,
C_P_I,
C_R_I,
C_U_I,
COSTOREPUS,
ORDEN,
FORDEN,
APARTAKIT,
FMAXDIA,
PZACAJA,
CEMPAQUE,
MAYOXKG,
FCAMBIO,
INIMAYO,
CVETASAIVA,
NOMBRE,
PRODPADRE,
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
ESPADRE,
ESFINAL,
ESSUBPROD,
PRECPADRE,
COMIPADRE,
OFEPADRE,
OFERTA,
DESC,
CAMBIARPRE,
PLUG,
COSTOPROUS,
TASAIEPS,
MINUTIL,
SPRECIO1,
SPRECIO2,
SPRECIO3,
SPRECIO4,
SPRECIO5,
RRECETA,
PRECTOPE,
PRECIOMAT,
MENUDEO,
CLAVE_CONT,
CONTENIDO,
CLASIFICA,
CANTXPIEZA,
LOTEIMPO,
COSTOUSD,
PLAZO,
CLAVESAT,
ESPRODPROM,
BASEPROM,
VIGPROM,
EXIS1,
VIGKIT,
KITCVIG,
VALXSUC,
DESGKIT,
PUPRECIO1,
PUPRECIO2,
PUPRECIO3,
PUPRECIO4,
PUPRECIO5,
IMPCOM,
ULTIMACOMPRA,
ULTIMAVENTA,
LINEANOMBRE,
MARCANOMBRE,
PROVEEDORNOMBRE


         )

Values (

$PRODUCTO,
$DESC1,
$PRECIO1,
$DESCUENTO1,
$U_EMPAQUE,
$MONEDA,
$UNIDAD,
$SERIE,
$LOTE,
$PROVEEDOR,
$PROVEEDOR2,
$LINEA,
$MARCA,
$DESC2,
$DESC3,
$PRECIO2,
$PRECIO3,
$PRECIO4,
$PRECIO5,
$PRECIO6,
$PRECIO7,
$CODIGO,
$CARGOS_U,
$COSTO_REPO,
$IMPRIMIR,
$INVENTARIO,
$IMPUESTO,
$NEGATIVOS,
$COMODIN,
$LIMITE1,
$DESCUENTO2,
$LIMITE2,
$DESCUENTO3,
$KIT,
$PIEZAS,
$LPIEZAS,
$COMISION,
$COMISION_E,
$PROMOCION,
$ID,
$ID_FECHA,
$ID_HORA,
$SUSTITUTO,
$CBARRAS,
$EMPAQUE,
$PESO,
$PRECIO8,
$PRECIO9,
$U_CAJA,
$CUENTA,
$RANKING,
$TIPOABC,
$TRAFICO,
$UNIDAD2,
$U_VENTA2,
$VOLUMEN,
$ABO,
$LOC,
$COSTO_ULTI,
$COSTOULTUS,
$C_P_I,
$C_R_I,
$C_U_I,
$COSTOREPUS,
$ORDEN,
$FORDEN,
$APARTAKIT,
$FMAXDIA,
$PZACAJA,
$CEMPAQUE,
$MAYOXKG,
$FCAMBIO,
$INIMAYO,
$CVETASAIVA,
$NOMBRE,
$PRODPADRE,
$TEXTO1,
$TEXTO2,
$TEXTO3,
$TEXTO4,
$TEXTO5,
$TEXTO6,
$NUMERO1,
$NUMERO2,
$NUMERO3,
$NUMERO4,
$FECHA1,
$FECHA2,
$ESPADRE,
$ESFINAL,
$ESSUBPROD,
$PRECPADRE,
$COMIPADRE,
$OFEPADRE,
$OFERTA,
$DESC,
$CAMBIARPRE,
$PLUG,
$COSTOPROUS,
$TASAIEPS,
$MINUTIL,
$SPRECIO1,
$SPRECIO2,
$SPRECIO3,
$SPRECIO4,
$SPRECIO5,
$RRECETA,
$PRECTOPE,
$PRECIOMAT,
$MENUDEO,
$CLAVE_CONT,
$CONTENIDO,
$CLASIFICA,
$CANTXPIEZA,
$LOTEIMPO,
$COSTOUSD,
$PLAZO,
$CLAVESAT,
$ESPRODPROM,
$BASEPROM,
$VIGPROM,
$EXIS1,
$VIGKIT,
$KITCVIG,
$VALXSUC,
$DESGKIT,
$PUPRECIO1,
$PUPRECIO2,
$PUPRECIO3,
$PUPRECIO4,
$PUPRECIO5,
$IMPCOM,
$ULTIMACOMPRA,
$ULTIMAVENTA,
$LINEANOMBRE,
$MARCANOMBRE,
$PROVEEDORNOMBRE

); ";

                SQLiteParameter[] arParms = new SQLiteParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                //if (st == null)
                //{
                    using (SQLiteConnection conn = new SQLiteConnection(strOleDbConn))
                    {
                        conn.Open();
                        using (var cmd = new SQLiteCommand(commandText, conn))
                        {
                            using (SQLiteHelper sq = new SQLiteHelper(cmd))
                            {
                                sq.Execute(commandText, arParms);
                            }
                        }
                        conn.Close();
                        conn.Dispose();
                        GC.Collect();
                }
                //}
                //else
                //{
                    
                //        using (SQLiteHelper sq = new SQLiteHelper(new SQLiteCommand(commandText,null,st)))
                //        {
                //            sq.Execute(commandText, arParms);
                //        }
                //}






                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public CPROD_SQLITE_D()
        {
        }

    }
}
