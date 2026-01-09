

using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Data.OleDb;
using DataLayer;
using System.Collections;
using ConexionesBD;


namespace iPosData
{

    [Transaction(TransactionOption.Supported)]


    public class CVENMD
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
        public CVENMBE AgregarVENMD(CVENMBE oCVENM, string strTableName, OleDbTransaction st, string strOleDbConn)
		{
			
	
			try
			{
				


				System.Collections.ArrayList parts = new ArrayList();
				OleDbParameter auxPar;

				 
				
	auxPar= new OleDbParameter("@VENTA", OleDbType.VarChar);
                                    if(!(bool)oCVENM.isnull["IVENTA"])
                                    {
                                    auxPar.Value=oCVENM.IVENTA;
                                    }
                                    else
                                    {
                                        auxPar.Value = "";// System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@CLIENTE", OleDbType.VarChar);
                                    if(!(bool)oCVENM.isnull["ICLIENTE"])
                                    {
                                    auxPar.Value=oCVENM.ICLIENTE;
                                    }
                                    else
                                    {
                                        auxPar.Value = "";//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@ESTATUS", OleDbType.VarChar);
                                    if(!(bool)oCVENM.isnull["IESTATUS"])
                                    {
                                    auxPar.Value=oCVENM.IESTATUS;
                                    }
                                    else
                                    {
                                        auxPar.Value = "";//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@PEDIDO", OleDbType.Date);
                                    if(!(bool)oCVENM.isnull["IPEDIDO"])
                                    {
                                    auxPar.Value=oCVENM.IPEDIDO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@FACTURA", OleDbType.VarChar);
                                    if(!(bool)oCVENM.isnull["IFACTURA"])
                                    {
                                    auxPar.Value=oCVENM.IFACTURA;
                                    }
                                    else
                                    {
                                        auxPar.Value = "";//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@F_FACTURA", OleDbType.Date);
                                    if(!(bool)oCVENM.isnull["IF_FACTURA"])
                                    {
                                    auxPar.Value=oCVENM.IF_FACTURA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@VENDEDOR", OleDbType.VarChar);
                                    if(!(bool)oCVENM.isnull["IVENDEDOR"])
                                    {
                                    auxPar.Value=oCVENM.IVENDEDOR;
                                    }
                                    else
                                    {
                                        auxPar.Value = "";//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@SUMA", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["ISUMA"])
                                    {
                                    auxPar.Value=oCVENM.ISUMA;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@IMPUESTO", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["IIMPUESTO"])
                                    {
                                    auxPar.Value=oCVENM.IIMPUESTO;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@IMPUESTO2", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["IIMPUESTO2"])
                                    {
                                    auxPar.Value=oCVENM.IIMPUESTO2;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@TOTAL", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["ITOTAL"])
                                    {
                                    auxPar.Value=oCVENM.ITOTAL;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@SALDO", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["ISALDO"])
                                    {
                                    auxPar.Value=oCVENM.ISALDO;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@SUCURSAL", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["ISUCURSAL"])
                                    {
                                    auxPar.Value=oCVENM.ISUCURSAL;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@DESCUENTO", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["IDESCUENTO"])
                                    {
                                    auxPar.Value=oCVENM.IDESCUENTO;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@DESC_PPP1", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["IDESC_PPP1"])
                                    {
                                    auxPar.Value=oCVENM.IDESC_PPP1;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@DESC_PPP2", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["IDESC_PPP2"])
                                    {
                                    auxPar.Value=oCVENM.IDESC_PPP2;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@DESC_PPP3", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["IDESC_PPP3"])
                                    {
                                    auxPar.Value=oCVENM.IDESC_PPP3;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@DESCUENTO1", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["IDESCUENTO1"])
                                    {
                                    auxPar.Value=oCVENM.IDESCUENTO1;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@DESCUENTO2", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["IDESCUENTO2"])
                                    {
                                    auxPar.Value=oCVENM.IDESCUENTO2;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@DESCUENTO3", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["IDESCUENTO3"])
                                    {
                                    auxPar.Value=oCVENM.IDESCUENTO3;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@A_CUENTA", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["IA_CUENTA"])
                                    {
                                    auxPar.Value=oCVENM.IA_CUENTA;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@COMISION", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["ICOMISION"])
                                    {
                                    auxPar.Value=oCVENM.ICOMISION;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@COMISION_U", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["ICOMISION_U"])
                                    {
                                    auxPar.Value=oCVENM.ICOMISION_U;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@COMISION_E", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["ICOMISION_E"])
                                    {
                                    auxPar.Value=oCVENM.ICOMISION_E;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@PAGO", OleDbType.Date);
                                    if(!(bool)oCVENM.isnull["IPAGO"])
                                    {
                                    auxPar.Value=oCVENM.IPAGO;
                                    }
                                    else
                                    {
                                        auxPar.Value = DateTime.MinValue;// System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@TIPO_PAGO", OleDbType.VarChar);
                                    if(!(bool)oCVENM.isnull["ITIPO_PAGO"])
                                    {
                                    auxPar.Value=oCVENM.ITIPO_PAGO;
                                    }
                                    else
                                    {
                                        auxPar.Value = "";//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@NOTA1", OleDbType.VarChar);
                                    if(!(bool)oCVENM.isnull["INOTA1"])
                                    {
                                    auxPar.Value=oCVENM.INOTA1;
                                    }
                                    else
                                    {
                                        auxPar.Value = "";//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@NOTA2", OleDbType.VarChar);
                                    if(!(bool)oCVENM.isnull["INOTA2"])
                                    {
                                    auxPar.Value=oCVENM.INOTA2;
                                    }
                                    else
                                    {
                                        auxPar.Value = "";//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@NOTA3", OleDbType.VarChar);
                                    if(!(bool)oCVENM.isnull["INOTA3"])
                                    {
                                    auxPar.Value=oCVENM.INOTA3;
                                    }
                                    else
                                    {
                                        auxPar.Value = "";//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@CREDITO", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["ICREDITO"])
                                    {
                                    auxPar.Value=oCVENM.ICREDITO;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@MES", OleDbType.VarChar);
                                    if(!(bool)oCVENM.isnull["IMES"])
                                    {
                                    auxPar.Value=oCVENM.IMES;
                                    }
                                    else
                                    {
                                        auxPar.Value = "";//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@COSTO", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["ICOSTO"])
                                    {
                                    auxPar.Value=oCVENM.ICOSTO;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@COSTOUS", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["ICOSTOUS"])
                                    {
                                    auxPar.Value=oCVENM.ICOSTOUS;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@REMISION", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["IREMISION"])
                                    {
                                    auxPar.Value=oCVENM.IREMISION;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@F_REMISION", OleDbType.Date);
                                    if(!(bool)oCVENM.isnull["IF_REMISION"])
                                    {
                                    auxPar.Value=oCVENM.IF_REMISION;
                                    }
                                    else
                                    {
                                        auxPar.Value = DateTime.Now;// System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@TODOUS", OleDbType.VarChar);
                                    if(!(bool)oCVENM.isnull["ITODOUS"])
                                    {
                                    auxPar.Value=oCVENM.ITODOUS;
                                    }
                                    else
                                    {
                                        auxPar.Value = "";//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@ENDOLARES", OleDbType.VarChar);
                                    if(!(bool)oCVENM.isnull["IENDOLARES"])
                                    {
                                    auxPar.Value=oCVENM.IENDOLARES;
                                    }
                                    else
                                    {
                                        auxPar.Value = "";//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@TC", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["ITC"])
                                    {
                                    auxPar.Value=oCVENM.ITC;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@SUMAUS", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["ISUMAUS"])
                                    {
                                    auxPar.Value=oCVENM.ISUMAUS;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@IMPUESTOUS", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["IIMPUESTOUS"])
                                    {
                                    auxPar.Value=oCVENM.IIMPUESTOUS;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@TOTALUS", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["ITOTALUS"])
                                    {
                                    auxPar.Value=oCVENM.ITOTALUS;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@A_CUENTAUS", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["IA_CUENTAUS"])
                                    {
                                    auxPar.Value=oCVENM.IA_CUENTAUS;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@SALDO_US", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["ISALDO_US"])
                                    {
                                    auxPar.Value=oCVENM.ISALDO_US;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@ENTREGA", OleDbType.VarChar);
                                    if(!(bool)oCVENM.isnull["IENTREGA"])
                                    {
                                    auxPar.Value=oCVENM.IENTREGA;
                                    }
                                    else
                                    {
                                        auxPar.Value = "";//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@SURTIDO", OleDbType.VarChar);
                                    if(!(bool)oCVENM.isnull["ISURTIDO"])
                                    {
                                    auxPar.Value=oCVENM.ISURTIDO;
                                    }
                                    else
                                    {
                                        auxPar.Value = "";//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@CONDICION", OleDbType.VarChar);
                                    if(!(bool)oCVENM.isnull["ICONDICION"])
                                    {
                                    auxPar.Value=oCVENM.ICONDICION;
                                    }
                                    else
                                    {
                                        auxPar.Value = "";//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@CONDICION2", OleDbType.VarChar);
                                    if(!(bool)oCVENM.isnull["ICONDICION2"])
                                    {
                                    auxPar.Value=oCVENM.ICONDICION2;
                                    }
                                    else
                                    {
                                        auxPar.Value = "";//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@NUMERO", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["INUMERO"])
                                    {
                                    auxPar.Value=oCVENM.INUMERO;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@NCREDITOPP", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["INCREDITOPP"])
                                    {
                                    auxPar.Value=oCVENM.INCREDITOPP;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@NCIVA", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["INCIVA"])
                                    {
                                    auxPar.Value=oCVENM.INCIVA;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@NCTOTAL", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["INCTOTAL"])
                                    {
                                    auxPar.Value=oCVENM.INCTOTAL;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@ORIGEN", OleDbType.VarChar);
                                    if(!(bool)oCVENM.isnull["IORIGEN"])
                                    {
                                    auxPar.Value=oCVENM.IORIGEN;
                                    }
                                    else
                                    {
                                        auxPar.Value = "";//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@EXPORTADO", OleDbType.VarChar);
                                    if(!(bool)oCVENM.isnull["IEXPORTADO"])
                                    {
                                    auxPar.Value=oCVENM.IEXPORTADO;
                                    }
                                    else
                                    {
                                        auxPar.Value = "";//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@PLANO", OleDbType.VarChar);
                                    if(!(bool)oCVENM.isnull["IPLANO"])
                                    {
                                    auxPar.Value=oCVENM.IPLANO;
                                    }
                                    else
                                    {
                                        auxPar.Value = "";//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@MONEDA", OleDbType.VarChar);
                                    if(!(bool)oCVENM.isnull["IMONEDA"])
                                    {
                                    auxPar.Value=oCVENM.IMONEDA;
                                    }
                                    else
                                    {
                                        auxPar.Value = "";//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);


                                    auxPar = new OleDbParameter("@EXPORTADOC", OleDbType.Boolean);
                                    if (!(bool)oCVENM.isnull["IEXPORTADOC"])
                                    {
                                        auxPar.Value = true;
                                    }
                                    else
                                    {
                                        auxPar.Value = false;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@CAJERO", OleDbType.VarChar);
                                    if(!(bool)oCVENM.isnull["ICAJERO"])
                                    {
                                    auxPar.Value=oCVENM.ICAJERO;
                                    }
                                    else
                                    {
                                        auxPar.Value = "";//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@HORAFACT", OleDbType.VarChar);
                                    if(!(bool)oCVENM.isnull["IHORAFACT"])
                                    {
                                    auxPar.Value=oCVENM.IHORAFACT;
                                    }
                                    else
                                    {
                                        auxPar.Value = "";//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@SUMAX", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["ISUMAX"])
                                    {
                                    auxPar.Value=oCVENM.ISUMAX;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@IMPUESTOX", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["IIMPUESTOX"])
                                    {
                                    auxPar.Value=oCVENM.IIMPUESTOX;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@TOTALX", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["ITOTALX"])
                                    {
                                    auxPar.Value=oCVENM.ITOTALX;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;// System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@ID", OleDbType.VarChar);
                                    if(!(bool)oCVENM.isnull["IID"])
                                    {
                                    auxPar.Value=oCVENM.IID;
                                    }
                                    else
                                    {
                                        auxPar.Value = "";//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@ID_FECHA", OleDbType.Date);
                                    if(!(bool)oCVENM.isnull["IID_FECHA"])
                                    {
                                    auxPar.Value=oCVENM.IID_FECHA;
                                    }
                                    else
                                    {
                                        auxPar.Value = DateTime.MinValue;// System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                                    if(!(bool)oCVENM.isnull["IID_HORA"])
                                    {
                                    auxPar.Value=oCVENM.IID_HORA;
                                    }
                                    else
                                    {
                                        auxPar.Value = "";//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@V_PROMO", OleDbType.VarChar);
                                    if(!(bool)oCVENM.isnull["IV_PROMO"])
                                    {
                                    auxPar.Value=oCVENM.IV_PROMO;
                                    }
                                    else
                                    {
                                        auxPar.Value = "";//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@TOTAL2", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["ITOTAL2"])
                                    {
                                    auxPar.Value=oCVENM.ITOTAL2;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@VALE", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["IVALE"])
                                    {
                                    auxPar.Value=oCVENM.IVALE;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@EFECTIVO", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["IEFECTIVO"])
                                    {
                                    auxPar.Value=oCVENM.IEFECTIVO;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@CHEQUE", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["ICHEQUE"])
                                    {
                                    auxPar.Value=oCVENM.ICHEQUE;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@TARJETA", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["ITARJETA"])
                                    {
                                    auxPar.Value=oCVENM.ITARJETA;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@NUM_VALE", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["INUM_VALE"])
                                    {
                                    auxPar.Value=oCVENM.INUM_VALE;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@DESCUENTOV", OleDbType.Numeric);
                                    if(!(bool)oCVENM.isnull["IDESCUENTOV"])
                                    {
                                    auxPar.Value=oCVENM.IDESCUENTOV;
                                    }
                                    else
                                    {
                                        auxPar.Value = 0;//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@FECHA_2", OleDbType.Date);
                                    if(!(bool)oCVENM.isnull["IFECHA_2"])
                                    {
                                    auxPar.Value=oCVENM.IFECHA_2;
                                    }
                                    else
                                    {
                                        auxPar.Value = DateTime.MinValue;// System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new OleDbParameter("@VCOMISION", OleDbType.VarChar);
                                    if(!(bool)oCVENM.isnull["IVCOMISION"])
                                    {
                                    auxPar.Value=oCVENM.IVCOMISION;
                                    }
                                    else
                                    {
                                        auxPar.Value = "";//System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);


  string commandText = @"
        INSERT INTO '" + strTableName + @"' 
      (
    
VENTA,

CLIENTE,

ESTATUS,

PEDIDO,

FACTURA,

F_FACTURA,

VENDEDOR,

SUMA,

IMPUESTO,

IMPUESTO2,

TOTAL,

SALDO,

SUCURSAL,

DESCUENTO,

DESC_PPP1,

DESC_PPP2,

DESC_PPP3,

DESCUENTO1,

DESCUENTO2,

DESCUENTO3,

A_CUENTA,

COMISION,

COMISION_U,

COMISION_E,

PAGO,

TIPO_PAGO,

NOTA1,

NOTA2,

NOTA3,

CREDITO,

MES,

COSTO,

COSTOUS,

REMISION,

F_REMISION,

TODOUS,

ENDOLARES,

TC,

SUMAUS,

IMPUESTOUS,

TOTALUS,

A_CUENTAUS,

SALDO_US,

ENTREGA,

SURTIDO,

CONDICION,

CONDICION2,

NUMERO,

NCREDITOPP,

NCIVA,

NCTOTAL,

ORIGEN,

EXPORTADO,

PLANO,

MONEDA,

EXPORTADOC,

CAJERO,

HORAFACT,

SUMAX,

IMPUESTOX,

TOTALX,

ID,

ID_FECHA,

ID_HORA,

V_PROMO,

TOTAL2,

VALE,

EFECTIVO,

CHEQUE,

TARJETA,

NUM_VALE,

DESCUENTOV,

FECHA_2,

VCOMISION
         )

Values (

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?
); ";

  OleDbParameter[] arParms= new OleDbParameter[parts.Count];
  parts.CopyTo(arParms,0);

  if (strOleDbConn!= "")
      OleDbHelper.ExecuteNonQuery(strOleDbConn, CommandType.Text, commandText, arParms);
  else
  OleDbHelper.ExecuteNonQuery(st,CommandType.Text, commandText,arParms);






  return oCVENM;

  }
  catch (Exception e)
  {
  this.iComentario=e.Message + e.StackTrace;
  return null;
  }
  }


        [AutoComplete]
        public bool BorrarVENMD(CVENMBE oCVENM, OleDbTransaction st)
  {


  try
  {
  System.Collections.ArrayList parts = new ArrayList();
  OleDbParameter auxPar;



				auxPar= new OleDbParameter("@VENTA", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IVENTA;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@CLIENTE", OleDbType.VarChar);
                                auxPar.Value=oCVENM.ICLIENTE;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@ESTATUS", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IESTATUS;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@PEDIDO", OleDbType.Date);
                                auxPar.Value=oCVENM.IPEDIDO;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@FACTURA", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IFACTURA;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@F_FACTURA", OleDbType.Date);
                                auxPar.Value=oCVENM.IF_FACTURA;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@VENDEDOR", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IVENDEDOR;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@SUMA", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ISUMA;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@IMPUESTO", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IIMPUESTO;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@IMPUESTO2", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IIMPUESTO2;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@TOTAL", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ITOTAL;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@SALDO", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ISALDO;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@SUCURSAL", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ISUCURSAL;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@DESCUENTO", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IDESCUENTO;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@DESC_PPP1", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IDESC_PPP1;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@DESC_PPP2", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IDESC_PPP2;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@DESC_PPP3", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IDESC_PPP3;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@DESCUENTO1", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IDESCUENTO1;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@DESCUENTO2", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IDESCUENTO2;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@DESCUENTO3", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IDESCUENTO3;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@A_CUENTA", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IA_CUENTA;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@COMISION", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ICOMISION;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@COMISION_U", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ICOMISION_U;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@COMISION_E", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ICOMISION_E;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@PAGO", OleDbType.Date);
                                auxPar.Value=oCVENM.IPAGO;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@TIPO_PAGO", OleDbType.VarChar);
                                auxPar.Value=oCVENM.ITIPO_PAGO;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@NOTA1", OleDbType.VarChar);
                                auxPar.Value=oCVENM.INOTA1;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@NOTA2", OleDbType.VarChar);
                                auxPar.Value=oCVENM.INOTA2;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@NOTA3", OleDbType.VarChar);
                                auxPar.Value=oCVENM.INOTA3;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@CREDITO", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ICREDITO;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@MES", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IMES;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@COSTO", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ICOSTO;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@COSTOUS", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ICOSTOUS;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@REMISION", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IREMISION;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@F_REMISION", OleDbType.Date);
                                auxPar.Value=oCVENM.IF_REMISION;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@TODOUS", OleDbType.VarChar);
                                auxPar.Value=oCVENM.ITODOUS;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@ENDOLARES", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IENDOLARES;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@TC", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ITC;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@SUMAUS", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ISUMAUS;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@IMPUESTOUS", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IIMPUESTOUS;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@TOTALUS", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ITOTALUS;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@A_CUENTAUS", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IA_CUENTAUS;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@SALDO_US", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ISALDO_US;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@ENTREGA", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IENTREGA;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@SURTIDO", OleDbType.VarChar);
                                auxPar.Value=oCVENM.ISURTIDO;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@CONDICION", OleDbType.VarChar);
                                auxPar.Value=oCVENM.ICONDICION;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@CONDICION2", OleDbType.VarChar);
                                auxPar.Value=oCVENM.ICONDICION2;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@NUMERO", OleDbType.Numeric);
                                auxPar.Value=oCVENM.INUMERO;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@NCREDITOPP", OleDbType.Numeric);
                                auxPar.Value=oCVENM.INCREDITOPP;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@NCIVA", OleDbType.Numeric);
                                auxPar.Value=oCVENM.INCIVA;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@NCTOTAL", OleDbType.Numeric);
                                auxPar.Value=oCVENM.INCTOTAL;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@ORIGEN", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IORIGEN;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@EXPORTADO", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IEXPORTADO;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@PLANO", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IPLANO;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@MONEDA", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IMONEDA;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@EXPORTADOC", OleDbType.Char);
                                auxPar.Value=oCVENM.IEXPORTADOC;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@CAJERO", OleDbType.VarChar);
                                auxPar.Value=oCVENM.ICAJERO;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@HORAFACT", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IHORAFACT;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@SUMAX", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ISUMAX;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@IMPUESTOX", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IIMPUESTOX;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@TOTALX", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ITOTALX;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@ID", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IID;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@ID_FECHA", OleDbType.Date);
                                auxPar.Value=oCVENM.IID_FECHA;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IID_HORA;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@V_PROMO", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IV_PROMO;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@TOTAL2", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ITOTAL2;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@VALE", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IVALE;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@EFECTIVO", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IEFECTIVO;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@CHEQUE", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ICHEQUE;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@TARJETA", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ITARJETA;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@NUM_VALE", OleDbType.Numeric);
                                auxPar.Value=oCVENM.INUM_VALE;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@DESCUENTOV", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IDESCUENTOV;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@FECHA_2", OleDbType.Date);
                                auxPar.Value=oCVENM.IFECHA_2;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@VCOMISION", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IVCOMISION;
                                  parts.Add(auxPar);



  string commandText = @"  Delete from VENM
  where

  VENTA=@VENTA and 

  CLIENTE=@CLIENTE and 

  ESTATUS=@ESTATUS and 

  PEDIDO=@PEDIDO and 

  FACTURA=@FACTURA and 

  F_FACTURA=@F_FACTURA and 

  VENDEDOR=@VENDEDOR and 

  SUMA=@SUMA and 

  IMPUESTO=@IMPUESTO and 

  IMPUESTO2=@IMPUESTO2 and 

  TOTAL=@TOTAL and 

  SALDO=@SALDO and 

  SUCURSAL=@SUCURSAL and 

  DESCUENTO=@DESCUENTO and 

  DESC_PPP1=@DESC_PPP1 and 

  DESC_PPP2=@DESC_PPP2 and 

  DESC_PPP3=@DESC_PPP3 and 

  DESCUENTO1=@DESCUENTO1 and 

  DESCUENTO2=@DESCUENTO2 and 

  DESCUENTO3=@DESCUENTO3 and 

  A_CUENTA=@A_CUENTA and 

  COMISION=@COMISION and 

  COMISION_U=@COMISION_U and 

  COMISION_E=@COMISION_E and 

  PAGO=@PAGO and 

  TIPO_PAGO=@TIPO_PAGO and 

  NOTA1=@NOTA1 and 

  NOTA2=@NOTA2 and 

  NOTA3=@NOTA3 and 

  CREDITO=@CREDITO and 

  MES=@MES and 

  COSTO=@COSTO and 

  COSTOUS=@COSTOUS and 

  REMISION=@REMISION and 

  F_REMISION=@F_REMISION and 

  TODOUS=@TODOUS and 

  ENDOLARES=@ENDOLARES and 

  TC=@TC and 

  SUMAUS=@SUMAUS and 

  IMPUESTOUS=@IMPUESTOUS and 

  TOTALUS=@TOTALUS and 

  A_CUENTAUS=@A_CUENTAUS and 

  SALDO_US=@SALDO_US and 

  ENTREGA=@ENTREGA and 

  SURTIDO=@SURTIDO and 

  CONDICION=@CONDICION and 

  CONDICION2=@CONDICION2 and 

  NUMERO=@NUMERO and 

  NCREDITOPP=@NCREDITOPP and 

  NCIVA=@NCIVA and 

  NCTOTAL=@NCTOTAL and 

  ORIGEN=@ORIGEN and 

  EXPORTADO=@EXPORTADO and 

  PLANO=@PLANO and 

  MONEDA=@MONEDA and 

  EXPORTADOC=@EXPORTADOC and 

  CAJERO=@CAJERO and 

  HORAFACT=@HORAFACT and 

  SUMAX=@SUMAX and 

  IMPUESTOX=@IMPUESTOX and 

  TOTALX=@TOTALX and 

  ID=@ID and 

  ID_FECHA=@ID_FECHA and 

  ID_HORA=@ID_HORA and 

  V_PROMO=@V_PROMO and 

  TOTAL2=@TOTAL2 and 

  VALE=@VALE and 

  EFECTIVO=@EFECTIVO and 

  CHEQUE=@CHEQUE and 

  TARJETA=@TARJETA and 

  NUM_VALE=@NUM_VALE and 

  DESCUENTOV=@DESCUENTOV and 

  FECHA_2=@FECHA_2 and 

  VCOMISION=@VCOMISION
  ;";

  OleDbParameter[] arParms= new OleDbParameter[parts.Count];
  parts.CopyTo(arParms,0);

  if(st==null)
  OleDbHelper.ExecuteNonQuery(this.sCadenaConexion,CommandType.Text, commandText,arParms);
  else
  OleDbHelper.ExecuteNonQuery(st,CommandType.Text, commandText,arParms);


  return true;




  }
  catch (Exception e)
  {
  this.iComentario=e.Message + e.StackTrace;
  return false;
  }
  }


        [AutoComplete]
        public bool CambiarVENMD(CVENMBE oCVENMNuevo, CVENMBE oCVENMAnterior, OleDbTransaction st)
  {


  try
  {
  System.Collections.ArrayList parts = new ArrayList();
  OleDbParameter auxPar;



				auxPar= new OleDbParameter("@VENTA", OleDbType.VarChar);
                                    if(!(bool)oCVENMNuevo.isnull["IVENTA"])
                                    {
                                auxPar.Value=oCVENMNuevo.IVENTA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@CLIENTE", OleDbType.VarChar);
                                    if(!(bool)oCVENMNuevo.isnull["ICLIENTE"])
                                    {
                                auxPar.Value=oCVENMNuevo.ICLIENTE;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@ESTATUS", OleDbType.VarChar);
                                    if(!(bool)oCVENMNuevo.isnull["IESTATUS"])
                                    {
                                auxPar.Value=oCVENMNuevo.IESTATUS;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@PEDIDO", OleDbType.Date);
                                    if(!(bool)oCVENMNuevo.isnull["IPEDIDO"])
                                    {
                                auxPar.Value=oCVENMNuevo.IPEDIDO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@FACTURA", OleDbType.VarChar);
                                    if(!(bool)oCVENMNuevo.isnull["IFACTURA"])
                                    {
                                auxPar.Value=oCVENMNuevo.IFACTURA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@F_FACTURA", OleDbType.Date);
                                    if(!(bool)oCVENMNuevo.isnull["IF_FACTURA"])
                                    {
                                auxPar.Value=oCVENMNuevo.IF_FACTURA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@VENDEDOR", OleDbType.VarChar);
                                    if(!(bool)oCVENMNuevo.isnull["IVENDEDOR"])
                                    {
                                auxPar.Value=oCVENMNuevo.IVENDEDOR;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@SUMA", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["ISUMA"])
                                    {
                                auxPar.Value=oCVENMNuevo.ISUMA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@IMPUESTO", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["IIMPUESTO"])
                                    {
                                auxPar.Value=oCVENMNuevo.IIMPUESTO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@IMPUESTO2", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["IIMPUESTO2"])
                                    {
                                auxPar.Value=oCVENMNuevo.IIMPUESTO2;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@TOTAL", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["ITOTAL"])
                                    {
                                auxPar.Value=oCVENMNuevo.ITOTAL;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@SALDO", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["ISALDO"])
                                    {
                                auxPar.Value=oCVENMNuevo.ISALDO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@SUCURSAL", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["ISUCURSAL"])
                                    {
                                auxPar.Value=oCVENMNuevo.ISUCURSAL;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@DESCUENTO", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["IDESCUENTO"])
                                    {
                                auxPar.Value=oCVENMNuevo.IDESCUENTO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@DESC_PPP1", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["IDESC_PPP1"])
                                    {
                                auxPar.Value=oCVENMNuevo.IDESC_PPP1;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@DESC_PPP2", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["IDESC_PPP2"])
                                    {
                                auxPar.Value=oCVENMNuevo.IDESC_PPP2;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@DESC_PPP3", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["IDESC_PPP3"])
                                    {
                                auxPar.Value=oCVENMNuevo.IDESC_PPP3;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@DESCUENTO1", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["IDESCUENTO1"])
                                    {
                                auxPar.Value=oCVENMNuevo.IDESCUENTO1;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@DESCUENTO2", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["IDESCUENTO2"])
                                    {
                                auxPar.Value=oCVENMNuevo.IDESCUENTO2;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@DESCUENTO3", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["IDESCUENTO3"])
                                    {
                                auxPar.Value=oCVENMNuevo.IDESCUENTO3;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@A_CUENTA", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["IA_CUENTA"])
                                    {
                                auxPar.Value=oCVENMNuevo.IA_CUENTA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@COMISION", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["ICOMISION"])
                                    {
                                auxPar.Value=oCVENMNuevo.ICOMISION;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@COMISION_U", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["ICOMISION_U"])
                                    {
                                auxPar.Value=oCVENMNuevo.ICOMISION_U;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@COMISION_E", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["ICOMISION_E"])
                                    {
                                auxPar.Value=oCVENMNuevo.ICOMISION_E;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@PAGO", OleDbType.Date);
                                    if(!(bool)oCVENMNuevo.isnull["IPAGO"])
                                    {
                                auxPar.Value=oCVENMNuevo.IPAGO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@TIPO_PAGO", OleDbType.VarChar);
                                    if(!(bool)oCVENMNuevo.isnull["ITIPO_PAGO"])
                                    {
                                auxPar.Value=oCVENMNuevo.ITIPO_PAGO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@NOTA1", OleDbType.VarChar);
                                    if(!(bool)oCVENMNuevo.isnull["INOTA1"])
                                    {
                                auxPar.Value=oCVENMNuevo.INOTA1;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@NOTA2", OleDbType.VarChar);
                                    if(!(bool)oCVENMNuevo.isnull["INOTA2"])
                                    {
                                auxPar.Value=oCVENMNuevo.INOTA2;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@NOTA3", OleDbType.VarChar);
                                    if(!(bool)oCVENMNuevo.isnull["INOTA3"])
                                    {
                                auxPar.Value=oCVENMNuevo.INOTA3;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@CREDITO", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["ICREDITO"])
                                    {
                                auxPar.Value=oCVENMNuevo.ICREDITO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@MES", OleDbType.VarChar);
                                    if(!(bool)oCVENMNuevo.isnull["IMES"])
                                    {
                                auxPar.Value=oCVENMNuevo.IMES;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@COSTO", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["ICOSTO"])
                                    {
                                auxPar.Value=oCVENMNuevo.ICOSTO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@COSTOUS", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["ICOSTOUS"])
                                    {
                                auxPar.Value=oCVENMNuevo.ICOSTOUS;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@REMISION", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["IREMISION"])
                                    {
                                auxPar.Value=oCVENMNuevo.IREMISION;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@F_REMISION", OleDbType.Date);
                                    if(!(bool)oCVENMNuevo.isnull["IF_REMISION"])
                                    {
                                auxPar.Value=oCVENMNuevo.IF_REMISION;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@TODOUS", OleDbType.VarChar);
                                    if(!(bool)oCVENMNuevo.isnull["ITODOUS"])
                                    {
                                auxPar.Value=oCVENMNuevo.ITODOUS;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@ENDOLARES", OleDbType.VarChar);
                                    if(!(bool)oCVENMNuevo.isnull["IENDOLARES"])
                                    {
                                auxPar.Value=oCVENMNuevo.IENDOLARES;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@TC", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["ITC"])
                                    {
                                auxPar.Value=oCVENMNuevo.ITC;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@SUMAUS", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["ISUMAUS"])
                                    {
                                auxPar.Value=oCVENMNuevo.ISUMAUS;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@IMPUESTOUS", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["IIMPUESTOUS"])
                                    {
                                auxPar.Value=oCVENMNuevo.IIMPUESTOUS;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@TOTALUS", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["ITOTALUS"])
                                    {
                                auxPar.Value=oCVENMNuevo.ITOTALUS;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@A_CUENTAUS", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["IA_CUENTAUS"])
                                    {
                                auxPar.Value=oCVENMNuevo.IA_CUENTAUS;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@SALDO_US", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["ISALDO_US"])
                                    {
                                auxPar.Value=oCVENMNuevo.ISALDO_US;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@ENTREGA", OleDbType.VarChar);
                                    if(!(bool)oCVENMNuevo.isnull["IENTREGA"])
                                    {
                                auxPar.Value=oCVENMNuevo.IENTREGA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@SURTIDO", OleDbType.VarChar);
                                    if(!(bool)oCVENMNuevo.isnull["ISURTIDO"])
                                    {
                                auxPar.Value=oCVENMNuevo.ISURTIDO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@CONDICION", OleDbType.VarChar);
                                    if(!(bool)oCVENMNuevo.isnull["ICONDICION"])
                                    {
                                auxPar.Value=oCVENMNuevo.ICONDICION;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@CONDICION2", OleDbType.VarChar);
                                    if(!(bool)oCVENMNuevo.isnull["ICONDICION2"])
                                    {
                                auxPar.Value=oCVENMNuevo.ICONDICION2;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@NUMERO", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["INUMERO"])
                                    {
                                auxPar.Value=oCVENMNuevo.INUMERO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@NCREDITOPP", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["INCREDITOPP"])
                                    {
                                auxPar.Value=oCVENMNuevo.INCREDITOPP;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@NCIVA", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["INCIVA"])
                                    {
                                auxPar.Value=oCVENMNuevo.INCIVA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@NCTOTAL", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["INCTOTAL"])
                                    {
                                auxPar.Value=oCVENMNuevo.INCTOTAL;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@ORIGEN", OleDbType.VarChar);
                                    if(!(bool)oCVENMNuevo.isnull["IORIGEN"])
                                    {
                                auxPar.Value=oCVENMNuevo.IORIGEN;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@EXPORTADO", OleDbType.VarChar);
                                    if(!(bool)oCVENMNuevo.isnull["IEXPORTADO"])
                                    {
                                auxPar.Value=oCVENMNuevo.IEXPORTADO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@PLANO", OleDbType.VarChar);
                                    if(!(bool)oCVENMNuevo.isnull["IPLANO"])
                                    {
                                auxPar.Value=oCVENMNuevo.IPLANO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@MONEDA", OleDbType.VarChar);
                                    if(!(bool)oCVENMNuevo.isnull["IMONEDA"])
                                    {
                                auxPar.Value=oCVENMNuevo.IMONEDA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@EXPORTADOC", OleDbType.Char);
                                    if(!(bool)oCVENMNuevo.isnull["IEXPORTADOC"])
                                    {
                                auxPar.Value=oCVENMNuevo.IEXPORTADOC;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@CAJERO", OleDbType.VarChar);
                                    if(!(bool)oCVENMNuevo.isnull["ICAJERO"])
                                    {
                                auxPar.Value=oCVENMNuevo.ICAJERO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@HORAFACT", OleDbType.VarChar);
                                    if(!(bool)oCVENMNuevo.isnull["IHORAFACT"])
                                    {
                                auxPar.Value=oCVENMNuevo.IHORAFACT;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@SUMAX", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["ISUMAX"])
                                    {
                                auxPar.Value=oCVENMNuevo.ISUMAX;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@IMPUESTOX", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["IIMPUESTOX"])
                                    {
                                auxPar.Value=oCVENMNuevo.IIMPUESTOX;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@TOTALX", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["ITOTALX"])
                                    {
                                auxPar.Value=oCVENMNuevo.ITOTALX;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@ID", OleDbType.VarChar);
                                    if(!(bool)oCVENMNuevo.isnull["IID"])
                                    {
                                auxPar.Value=oCVENMNuevo.IID;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@ID_FECHA", OleDbType.Date);
                                    if(!(bool)oCVENMNuevo.isnull["IID_FECHA"])
                                    {
                                auxPar.Value=oCVENMNuevo.IID_FECHA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                                    if(!(bool)oCVENMNuevo.isnull["IID_HORA"])
                                    {
                                auxPar.Value=oCVENMNuevo.IID_HORA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@V_PROMO", OleDbType.VarChar);
                                    if(!(bool)oCVENMNuevo.isnull["IV_PROMO"])
                                    {
                                auxPar.Value=oCVENMNuevo.IV_PROMO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@TOTAL2", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["ITOTAL2"])
                                    {
                                auxPar.Value=oCVENMNuevo.ITOTAL2;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@VALE", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["IVALE"])
                                    {
                                auxPar.Value=oCVENMNuevo.IVALE;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@EFECTIVO", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["IEFECTIVO"])
                                    {
                                auxPar.Value=oCVENMNuevo.IEFECTIVO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@CHEQUE", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["ICHEQUE"])
                                    {
                                auxPar.Value=oCVENMNuevo.ICHEQUE;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@TARJETA", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["ITARJETA"])
                                    {
                                auxPar.Value=oCVENMNuevo.ITARJETA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@NUM_VALE", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["INUM_VALE"])
                                    {
                                auxPar.Value=oCVENMNuevo.INUM_VALE;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@DESCUENTOV", OleDbType.Numeric);
                                    if(!(bool)oCVENMNuevo.isnull["IDESCUENTOV"])
                                    {
                                auxPar.Value=oCVENMNuevo.IDESCUENTOV;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@FECHA_2", OleDbType.Date);
                                    if(!(bool)oCVENMNuevo.isnull["IFECHA_2"])
                                    {
                                auxPar.Value=oCVENMNuevo.IFECHA_2;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@VCOMISION", OleDbType.VarChar);
                                    if(!(bool)oCVENMNuevo.isnull["IVCOMISION"])
                                    {
                                auxPar.Value=oCVENMNuevo.IVCOMISION;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@VENTAAnt", OleDbType.VarChar);
                                    if(!(bool)oCVENMAnterior.isnull["IVENTA"])
                                    {
                                auxPar.Value=oCVENMAnterior.IVENTA;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@CLIENTEAnt", OleDbType.VarChar);
                                    if(!(bool)oCVENMAnterior.isnull["ICLIENTE"])
                                    {
                                auxPar.Value=oCVENMAnterior.ICLIENTE;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@ESTATUSAnt", OleDbType.VarChar);
                                    if(!(bool)oCVENMAnterior.isnull["IESTATUS"])
                                    {
                                auxPar.Value=oCVENMAnterior.IESTATUS;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@PEDIDOAnt", OleDbType.Date);
                                    if(!(bool)oCVENMAnterior.isnull["IPEDIDO"])
                                    {
                                auxPar.Value=oCVENMAnterior.IPEDIDO;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@FACTURAAnt", OleDbType.VarChar);
                                    if(!(bool)oCVENMAnterior.isnull["IFACTURA"])
                                    {
                                auxPar.Value=oCVENMAnterior.IFACTURA;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@F_FACTURAAnt", OleDbType.Date);
                                    if(!(bool)oCVENMAnterior.isnull["IF_FACTURA"])
                                    {
                                auxPar.Value=oCVENMAnterior.IF_FACTURA;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@VENDEDORAnt", OleDbType.VarChar);
                                    if(!(bool)oCVENMAnterior.isnull["IVENDEDOR"])
                                    {
                                auxPar.Value=oCVENMAnterior.IVENDEDOR;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@SUMAAnt", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["ISUMA"])
                                    {
                                auxPar.Value=oCVENMAnterior.ISUMA;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@IMPUESTOAnt", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["IIMPUESTO"])
                                    {
                                auxPar.Value=oCVENMAnterior.IIMPUESTO;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@IMPUESTO2Ant", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["IIMPUESTO2"])
                                    {
                                auxPar.Value=oCVENMAnterior.IIMPUESTO2;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@TOTALAnt", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["ITOTAL"])
                                    {
                                auxPar.Value=oCVENMAnterior.ITOTAL;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@SALDOAnt", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["ISALDO"])
                                    {
                                auxPar.Value=oCVENMAnterior.ISALDO;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@SUCURSALAnt", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["ISUCURSAL"])
                                    {
                                auxPar.Value=oCVENMAnterior.ISUCURSAL;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@DESCUENTOAnt", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["IDESCUENTO"])
                                    {
                                auxPar.Value=oCVENMAnterior.IDESCUENTO;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@DESC_PPP1Ant", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["IDESC_PPP1"])
                                    {
                                auxPar.Value=oCVENMAnterior.IDESC_PPP1;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@DESC_PPP2Ant", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["IDESC_PPP2"])
                                    {
                                auxPar.Value=oCVENMAnterior.IDESC_PPP2;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@DESC_PPP3Ant", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["IDESC_PPP3"])
                                    {
                                auxPar.Value=oCVENMAnterior.IDESC_PPP3;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@DESCUENTO1Ant", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["IDESCUENTO1"])
                                    {
                                auxPar.Value=oCVENMAnterior.IDESCUENTO1;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@DESCUENTO2Ant", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["IDESCUENTO2"])
                                    {
                                auxPar.Value=oCVENMAnterior.IDESCUENTO2;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@DESCUENTO3Ant", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["IDESCUENTO3"])
                                    {
                                auxPar.Value=oCVENMAnterior.IDESCUENTO3;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@A_CUENTAAnt", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["IA_CUENTA"])
                                    {
                                auxPar.Value=oCVENMAnterior.IA_CUENTA;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@COMISIONAnt", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["ICOMISION"])
                                    {
                                auxPar.Value=oCVENMAnterior.ICOMISION;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@COMISION_UAnt", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["ICOMISION_U"])
                                    {
                                auxPar.Value=oCVENMAnterior.ICOMISION_U;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@COMISION_EAnt", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["ICOMISION_E"])
                                    {
                                auxPar.Value=oCVENMAnterior.ICOMISION_E;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@PAGOAnt", OleDbType.Date);
                                    if(!(bool)oCVENMAnterior.isnull["IPAGO"])
                                    {
                                auxPar.Value=oCVENMAnterior.IPAGO;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@TIPO_PAGOAnt", OleDbType.VarChar);
                                    if(!(bool)oCVENMAnterior.isnull["ITIPO_PAGO"])
                                    {
                                auxPar.Value=oCVENMAnterior.ITIPO_PAGO;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@NOTA1Ant", OleDbType.VarChar);
                                    if(!(bool)oCVENMAnterior.isnull["INOTA1"])
                                    {
                                auxPar.Value=oCVENMAnterior.INOTA1;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@NOTA2Ant", OleDbType.VarChar);
                                    if(!(bool)oCVENMAnterior.isnull["INOTA2"])
                                    {
                                auxPar.Value=oCVENMAnterior.INOTA2;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@NOTA3Ant", OleDbType.VarChar);
                                    if(!(bool)oCVENMAnterior.isnull["INOTA3"])
                                    {
                                auxPar.Value=oCVENMAnterior.INOTA3;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@CREDITOAnt", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["ICREDITO"])
                                    {
                                auxPar.Value=oCVENMAnterior.ICREDITO;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@MESAnt", OleDbType.VarChar);
                                    if(!(bool)oCVENMAnterior.isnull["IMES"])
                                    {
                                auxPar.Value=oCVENMAnterior.IMES;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@COSTOAnt", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["ICOSTO"])
                                    {
                                auxPar.Value=oCVENMAnterior.ICOSTO;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@COSTOUSAnt", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["ICOSTOUS"])
                                    {
                                auxPar.Value=oCVENMAnterior.ICOSTOUS;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@REMISIONAnt", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["IREMISION"])
                                    {
                                auxPar.Value=oCVENMAnterior.IREMISION;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@F_REMISIONAnt", OleDbType.Date);
                                    if(!(bool)oCVENMAnterior.isnull["IF_REMISION"])
                                    {
                                auxPar.Value=oCVENMAnterior.IF_REMISION;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@TODOUSAnt", OleDbType.VarChar);
                                    if(!(bool)oCVENMAnterior.isnull["ITODOUS"])
                                    {
                                auxPar.Value=oCVENMAnterior.ITODOUS;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@ENDOLARESAnt", OleDbType.VarChar);
                                    if(!(bool)oCVENMAnterior.isnull["IENDOLARES"])
                                    {
                                auxPar.Value=oCVENMAnterior.IENDOLARES;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@TCAnt", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["ITC"])
                                    {
                                auxPar.Value=oCVENMAnterior.ITC;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@SUMAUSAnt", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["ISUMAUS"])
                                    {
                                auxPar.Value=oCVENMAnterior.ISUMAUS;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@IMPUESTOUSAnt", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["IIMPUESTOUS"])
                                    {
                                auxPar.Value=oCVENMAnterior.IIMPUESTOUS;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@TOTALUSAnt", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["ITOTALUS"])
                                    {
                                auxPar.Value=oCVENMAnterior.ITOTALUS;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@A_CUENTAUSAnt", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["IA_CUENTAUS"])
                                    {
                                auxPar.Value=oCVENMAnterior.IA_CUENTAUS;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@SALDO_USAnt", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["ISALDO_US"])
                                    {
                                auxPar.Value=oCVENMAnterior.ISALDO_US;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@ENTREGAAnt", OleDbType.VarChar);
                                    if(!(bool)oCVENMAnterior.isnull["IENTREGA"])
                                    {
                                auxPar.Value=oCVENMAnterior.IENTREGA;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@SURTIDOAnt", OleDbType.VarChar);
                                    if(!(bool)oCVENMAnterior.isnull["ISURTIDO"])
                                    {
                                auxPar.Value=oCVENMAnterior.ISURTIDO;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@CONDICIONAnt", OleDbType.VarChar);
                                    if(!(bool)oCVENMAnterior.isnull["ICONDICION"])
                                    {
                                auxPar.Value=oCVENMAnterior.ICONDICION;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@CONDICION2Ant", OleDbType.VarChar);
                                    if(!(bool)oCVENMAnterior.isnull["ICONDICION2"])
                                    {
                                auxPar.Value=oCVENMAnterior.ICONDICION2;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@NUMEROAnt", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["INUMERO"])
                                    {
                                auxPar.Value=oCVENMAnterior.INUMERO;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@NCREDITOPPAnt", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["INCREDITOPP"])
                                    {
                                auxPar.Value=oCVENMAnterior.INCREDITOPP;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@NCIVAAnt", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["INCIVA"])
                                    {
                                auxPar.Value=oCVENMAnterior.INCIVA;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@NCTOTALAnt", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["INCTOTAL"])
                                    {
                                auxPar.Value=oCVENMAnterior.INCTOTAL;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@ORIGENAnt", OleDbType.VarChar);
                                    if(!(bool)oCVENMAnterior.isnull["IORIGEN"])
                                    {
                                auxPar.Value=oCVENMAnterior.IORIGEN;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@EXPORTADOAnt", OleDbType.VarChar);
                                    if(!(bool)oCVENMAnterior.isnull["IEXPORTADO"])
                                    {
                                auxPar.Value=oCVENMAnterior.IEXPORTADO;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@PLANOAnt", OleDbType.VarChar);
                                    if(!(bool)oCVENMAnterior.isnull["IPLANO"])
                                    {
                                auxPar.Value=oCVENMAnterior.IPLANO;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@MONEDAAnt", OleDbType.VarChar);
                                    if(!(bool)oCVENMAnterior.isnull["IMONEDA"])
                                    {
                                auxPar.Value=oCVENMAnterior.IMONEDA;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@EXPORTADOCAnt", OleDbType.Char);
                                    if(!(bool)oCVENMAnterior.isnull["IEXPORTADOC"])
                                    {
                                auxPar.Value=oCVENMAnterior.IEXPORTADOC;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@CAJEROAnt", OleDbType.VarChar);
                                    if(!(bool)oCVENMAnterior.isnull["ICAJERO"])
                                    {
                                auxPar.Value=oCVENMAnterior.ICAJERO;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@HORAFACTAnt", OleDbType.VarChar);
                                    if(!(bool)oCVENMAnterior.isnull["IHORAFACT"])
                                    {
                                auxPar.Value=oCVENMAnterior.IHORAFACT;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@SUMAXAnt", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["ISUMAX"])
                                    {
                                auxPar.Value=oCVENMAnterior.ISUMAX;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@IMPUESTOXAnt", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["IIMPUESTOX"])
                                    {
                                auxPar.Value=oCVENMAnterior.IIMPUESTOX;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@TOTALXAnt", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["ITOTALX"])
                                    {
                                auxPar.Value=oCVENMAnterior.ITOTALX;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@IDAnt", OleDbType.VarChar);
                                    if(!(bool)oCVENMAnterior.isnull["IID"])
                                    {
                                auxPar.Value=oCVENMAnterior.IID;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@ID_FECHAAnt", OleDbType.Date);
                                    if(!(bool)oCVENMAnterior.isnull["IID_FECHA"])
                                    {
                                auxPar.Value=oCVENMAnterior.IID_FECHA;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@ID_HORAAnt", OleDbType.VarChar);
                                    if(!(bool)oCVENMAnterior.isnull["IID_HORA"])
                                    {
                                auxPar.Value=oCVENMAnterior.IID_HORA;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@V_PROMOAnt", OleDbType.VarChar);
                                    if(!(bool)oCVENMAnterior.isnull["IV_PROMO"])
                                    {
                                auxPar.Value=oCVENMAnterior.IV_PROMO;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@TOTAL2Ant", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["ITOTAL2"])
                                    {
                                auxPar.Value=oCVENMAnterior.ITOTAL2;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@VALEAnt", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["IVALE"])
                                    {
                                auxPar.Value=oCVENMAnterior.IVALE;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@EFECTIVOAnt", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["IEFECTIVO"])
                                    {
                                auxPar.Value=oCVENMAnterior.IEFECTIVO;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@CHEQUEAnt", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["ICHEQUE"])
                                    {
                                auxPar.Value=oCVENMAnterior.ICHEQUE;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@TARJETAAnt", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["ITARJETA"])
                                    {
                                auxPar.Value=oCVENMAnterior.ITARJETA;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@NUM_VALEAnt", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["INUM_VALE"])
                                    {
                                auxPar.Value=oCVENMAnterior.INUM_VALE;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@DESCUENTOVAnt", OleDbType.Numeric);
                                    if(!(bool)oCVENMAnterior.isnull["IDESCUENTOV"])
                                    {
                                auxPar.Value=oCVENMAnterior.IDESCUENTOV;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@FECHA_2Ant", OleDbType.Date);
                                    if(!(bool)oCVENMAnterior.isnull["IFECHA_2"])
                                    {
                                auxPar.Value=oCVENMAnterior.IFECHA_2;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new OleDbParameter("@VCOMISIONAnt", OleDbType.VarChar);
                                    if(!(bool)oCVENMAnterior.isnull["IVCOMISION"])
                                    {
                                auxPar.Value=oCVENMAnterior.IVCOMISION;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);




string commandText = @"
  update  VENM
  set

VENTA=@VENTA,

CLIENTE=@CLIENTE,

ESTATUS=@ESTATUS,

PEDIDO=@PEDIDO,

FACTURA=@FACTURA,

F_FACTURA=@F_FACTURA,

VENDEDOR=@VENDEDOR,

SUMA=@SUMA,

IMPUESTO=@IMPUESTO,

IMPUESTO2=@IMPUESTO2,

TOTAL=@TOTAL,

SALDO=@SALDO,

SUCURSAL=@SUCURSAL,

DESCUENTO=@DESCUENTO,

DESC_PPP1=@DESC_PPP1,

DESC_PPP2=@DESC_PPP2,

DESC_PPP3=@DESC_PPP3,

DESCUENTO1=@DESCUENTO1,

DESCUENTO2=@DESCUENTO2,

DESCUENTO3=@DESCUENTO3,

A_CUENTA=@A_CUENTA,

COMISION=@COMISION,

COMISION_U=@COMISION_U,

COMISION_E=@COMISION_E,

PAGO=@PAGO,

TIPO_PAGO=@TIPO_PAGO,

NOTA1=@NOTA1,

NOTA2=@NOTA2,

NOTA3=@NOTA3,

CREDITO=@CREDITO,

MES=@MES,

COSTO=@COSTO,

COSTOUS=@COSTOUS,

REMISION=@REMISION,

F_REMISION=@F_REMISION,

TODOUS=@TODOUS,

ENDOLARES=@ENDOLARES,

TC=@TC,

SUMAUS=@SUMAUS,

IMPUESTOUS=@IMPUESTOUS,

TOTALUS=@TOTALUS,

A_CUENTAUS=@A_CUENTAUS,

SALDO_US=@SALDO_US,

ENTREGA=@ENTREGA,

SURTIDO=@SURTIDO,

CONDICION=@CONDICION,

CONDICION2=@CONDICION2,

NUMERO=@NUMERO,

NCREDITOPP=@NCREDITOPP,

NCIVA=@NCIVA,

NCTOTAL=@NCTOTAL,

ORIGEN=@ORIGEN,

EXPORTADO=@EXPORTADO,

PLANO=@PLANO,

MONEDA=@MONEDA,

EXPORTADOC=@EXPORTADOC,

CAJERO=@CAJERO,

HORAFACT=@HORAFACT,

SUMAX=@SUMAX,

IMPUESTOX=@IMPUESTOX,

TOTALX=@TOTALX,

ID=@ID,

ID_FECHA=@ID_FECHA,

ID_HORA=@ID_HORA,

V_PROMO=@V_PROMO,

TOTAL2=@TOTAL2,

VALE=@VALE,

EFECTIVO=@EFECTIVO,

CHEQUE=@CHEQUE,

TARJETA=@TARJETA,

NUM_VALE=@NUM_VALE,

DESCUENTOV=@DESCUENTOV,

FECHA_2=@FECHA_2,

VCOMISION=@VCOMISION
  where 

VENTA=@VENTAAnt and

CLIENTE=@CLIENTEAnt and

ESTATUS=@ESTATUSAnt and

PEDIDO=@PEDIDOAnt and

FACTURA=@FACTURAAnt and

F_FACTURA=@F_FACTURAAnt and

VENDEDOR=@VENDEDORAnt and

SUMA=@SUMAAnt and

IMPUESTO=@IMPUESTOAnt and

IMPUESTO2=@IMPUESTO2Ant and

TOTAL=@TOTALAnt and

SALDO=@SALDOAnt and

SUCURSAL=@SUCURSALAnt and

DESCUENTO=@DESCUENTOAnt and

DESC_PPP1=@DESC_PPP1Ant and

DESC_PPP2=@DESC_PPP2Ant and

DESC_PPP3=@DESC_PPP3Ant and

DESCUENTO1=@DESCUENTO1Ant and

DESCUENTO2=@DESCUENTO2Ant and

DESCUENTO3=@DESCUENTO3Ant and

A_CUENTA=@A_CUENTAAnt and

COMISION=@COMISIONAnt and

COMISION_U=@COMISION_UAnt and

COMISION_E=@COMISION_EAnt and

PAGO=@PAGOAnt and

TIPO_PAGO=@TIPO_PAGOAnt and

NOTA1=@NOTA1Ant and

NOTA2=@NOTA2Ant and

NOTA3=@NOTA3Ant and

CREDITO=@CREDITOAnt and

MES=@MESAnt and

COSTO=@COSTOAnt and

COSTOUS=@COSTOUSAnt and

REMISION=@REMISIONAnt and

F_REMISION=@F_REMISIONAnt and

TODOUS=@TODOUSAnt and

ENDOLARES=@ENDOLARESAnt and

TC=@TCAnt and

SUMAUS=@SUMAUSAnt and

IMPUESTOUS=@IMPUESTOUSAnt and

TOTALUS=@TOTALUSAnt and

A_CUENTAUS=@A_CUENTAUSAnt and

SALDO_US=@SALDO_USAnt and

ENTREGA=@ENTREGAAnt and

SURTIDO=@SURTIDOAnt and

CONDICION=@CONDICIONAnt and

CONDICION2=@CONDICION2Ant and

NUMERO=@NUMEROAnt and

NCREDITOPP=@NCREDITOPPAnt and

NCIVA=@NCIVAAnt and

NCTOTAL=@NCTOTALAnt and

ORIGEN=@ORIGENAnt and

EXPORTADO=@EXPORTADOAnt and

PLANO=@PLANOAnt and

MONEDA=@MONEDAAnt and

EXPORTADOC=@EXPORTADOCAnt and

CAJERO=@CAJEROAnt and

HORAFACT=@HORAFACTAnt and

SUMAX=@SUMAXAnt and

IMPUESTOX=@IMPUESTOXAnt and

TOTALX=@TOTALXAnt and

ID=@IDAnt and

ID_FECHA=@ID_FECHAAnt and

ID_HORA=@ID_HORAAnt and

V_PROMO=@V_PROMOAnt and

TOTAL2=@TOTAL2Ant and

VALE=@VALEAnt and

EFECTIVO=@EFECTIVOAnt and

CHEQUE=@CHEQUEAnt and

TARJETA=@TARJETAAnt and

NUM_VALE=@NUM_VALEAnt and

DESCUENTOV=@DESCUENTOVAnt and

FECHA_2=@FECHA_2Ant and

VCOMISION=@VCOMISIONAnt
  ;";

  OleDbParameter[] arParms= new OleDbParameter[parts.Count];
  parts.CopyTo(arParms,0);


  if(st==null)
  OleDbHelper.ExecuteNonQuery(this.sCadenaConexion,CommandType.Text, commandText,arParms);
  else
  OleDbHelper.ExecuteNonQuery(st,CommandType.Text, commandText,arParms);


  return true;


  }
  catch (Exception e)
  {
  this.iComentario=e.Message + e.StackTrace;
  return false;
  }
  }


        [AutoComplete]
        public CVENMBE seleccionarVENM(CVENMBE oCVENM, OleDbTransaction st)
  {




  CVENMBE retorno = new CVENMBE();

  try
  {

  System.Collections.ArrayList parts = new ArrayList();
  OleDbParameter auxPar;

  String CmdTxt = @"select * from VENM where
 VENTA=@VENTA    and
 CLIENTE=@CLIENTE    and
 ESTATUS=@ESTATUS    and
 PEDIDO=@PEDIDO    and
 FACTURA=@FACTURA    and
 F_FACTURA=@F_FACTURA    and
 VENDEDOR=@VENDEDOR    and
 SUMA=@SUMA    and
 IMPUESTO=@IMPUESTO    and
 IMPUESTO2=@IMPUESTO2    and
 TOTAL=@TOTAL    and
 SALDO=@SALDO    and
 SUCURSAL=@SUCURSAL    and
 DESCUENTO=@DESCUENTO    and
 DESC_PPP1=@DESC_PPP1    and
 DESC_PPP2=@DESC_PPP2    and
 DESC_PPP3=@DESC_PPP3    and
 DESCUENTO1=@DESCUENTO1    and
 DESCUENTO2=@DESCUENTO2    and
 DESCUENTO3=@DESCUENTO3    and
 A_CUENTA=@A_CUENTA    and
 COMISION=@COMISION    and
 COMISION_U=@COMISION_U    and
 COMISION_E=@COMISION_E    and
 PAGO=@PAGO    and
 TIPO_PAGO=@TIPO_PAGO    and
 NOTA1=@NOTA1    and
 NOTA2=@NOTA2    and
 NOTA3=@NOTA3    and
 CREDITO=@CREDITO    and
 MES=@MES    and
 COSTO=@COSTO    and
 COSTOUS=@COSTOUS    and
 REMISION=@REMISION    and
 F_REMISION=@F_REMISION    and
 TODOUS=@TODOUS    and
 ENDOLARES=@ENDOLARES    and
 TC=@TC    and
 SUMAUS=@SUMAUS    and
 IMPUESTOUS=@IMPUESTOUS    and
 TOTALUS=@TOTALUS    and
 A_CUENTAUS=@A_CUENTAUS    and
 SALDO_US=@SALDO_US    and
 ENTREGA=@ENTREGA    and
 SURTIDO=@SURTIDO    and
 CONDICION=@CONDICION    and
 CONDICION2=@CONDICION2    and
 NUMERO=@NUMERO    and
 NCREDITOPP=@NCREDITOPP    and
 NCIVA=@NCIVA    and
 NCTOTAL=@NCTOTAL    and
 ORIGEN=@ORIGEN    and
 EXPORTADO=@EXPORTADO    and
 PLANO=@PLANO    and
 MONEDA=@MONEDA    and
 EXPORTADOC=@EXPORTADOC    and
 CAJERO=@CAJERO    and
 HORAFACT=@HORAFACT    and
 SUMAX=@SUMAX    and
 IMPUESTOX=@IMPUESTOX    and
 TOTALX=@TOTALX    and
 ID=@ID    and
 ID_FECHA=@ID_FECHA    and
 ID_HORA=@ID_HORA    and
 V_PROMO=@V_PROMO    and
 TOTAL2=@TOTAL2    and
 VALE=@VALE    and
 EFECTIVO=@EFECTIVO    and
 CHEQUE=@CHEQUE    and
 TARJETA=@TARJETA    and
 NUM_VALE=@NUM_VALE    and
 DESCUENTOV=@DESCUENTOV    and
 FECHA_2=@FECHA_2    and
 VCOMISION=@VCOMISION  ";


				auxPar= new OleDbParameter("@VENTA", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IVENTA;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@CLIENTE", OleDbType.VarChar);
                                auxPar.Value=oCVENM.ICLIENTE;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@ESTATUS", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IESTATUS;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@PEDIDO", OleDbType.Date);
                                auxPar.Value=oCVENM.IPEDIDO;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@FACTURA", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IFACTURA;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@F_FACTURA", OleDbType.Date);
                                auxPar.Value=oCVENM.IF_FACTURA;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@VENDEDOR", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IVENDEDOR;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@SUMA", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ISUMA;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@IMPUESTO", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IIMPUESTO;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@IMPUESTO2", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IIMPUESTO2;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@TOTAL", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ITOTAL;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@SALDO", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ISALDO;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@SUCURSAL", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ISUCURSAL;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@DESCUENTO", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IDESCUENTO;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@DESC_PPP1", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IDESC_PPP1;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@DESC_PPP2", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IDESC_PPP2;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@DESC_PPP3", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IDESC_PPP3;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@DESCUENTO1", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IDESCUENTO1;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@DESCUENTO2", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IDESCUENTO2;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@DESCUENTO3", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IDESCUENTO3;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@A_CUENTA", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IA_CUENTA;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@COMISION", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ICOMISION;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@COMISION_U", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ICOMISION_U;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@COMISION_E", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ICOMISION_E;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@PAGO", OleDbType.Date);
                                auxPar.Value=oCVENM.IPAGO;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@TIPO_PAGO", OleDbType.VarChar);
                                auxPar.Value=oCVENM.ITIPO_PAGO;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@NOTA1", OleDbType.VarChar);
                                auxPar.Value=oCVENM.INOTA1;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@NOTA2", OleDbType.VarChar);
                                auxPar.Value=oCVENM.INOTA2;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@NOTA3", OleDbType.VarChar);
                                auxPar.Value=oCVENM.INOTA3;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@CREDITO", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ICREDITO;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@MES", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IMES;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@COSTO", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ICOSTO;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@COSTOUS", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ICOSTOUS;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@REMISION", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IREMISION;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@F_REMISION", OleDbType.Date);
                                auxPar.Value=oCVENM.IF_REMISION;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@TODOUS", OleDbType.VarChar);
                                auxPar.Value=oCVENM.ITODOUS;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@ENDOLARES", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IENDOLARES;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@TC", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ITC;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@SUMAUS", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ISUMAUS;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@IMPUESTOUS", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IIMPUESTOUS;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@TOTALUS", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ITOTALUS;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@A_CUENTAUS", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IA_CUENTAUS;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@SALDO_US", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ISALDO_US;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@ENTREGA", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IENTREGA;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@SURTIDO", OleDbType.VarChar);
                                auxPar.Value=oCVENM.ISURTIDO;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@CONDICION", OleDbType.VarChar);
                                auxPar.Value=oCVENM.ICONDICION;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@CONDICION2", OleDbType.VarChar);
                                auxPar.Value=oCVENM.ICONDICION2;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@NUMERO", OleDbType.Numeric);
                                auxPar.Value=oCVENM.INUMERO;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@NCREDITOPP", OleDbType.Numeric);
                                auxPar.Value=oCVENM.INCREDITOPP;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@NCIVA", OleDbType.Numeric);
                                auxPar.Value=oCVENM.INCIVA;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@NCTOTAL", OleDbType.Numeric);
                                auxPar.Value=oCVENM.INCTOTAL;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@ORIGEN", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IORIGEN;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@EXPORTADO", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IEXPORTADO;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@PLANO", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IPLANO;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@MONEDA", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IMONEDA;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@EXPORTADOC", OleDbType.Char);
                                auxPar.Value=oCVENM.IEXPORTADOC;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@CAJERO", OleDbType.VarChar);
                                auxPar.Value=oCVENM.ICAJERO;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@HORAFACT", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IHORAFACT;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@SUMAX", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ISUMAX;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@IMPUESTOX", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IIMPUESTOX;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@TOTALX", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ITOTALX;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@ID", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IID;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@ID_FECHA", OleDbType.Date);
                                auxPar.Value=oCVENM.IID_FECHA;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IID_HORA;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@V_PROMO", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IV_PROMO;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@TOTAL2", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ITOTAL2;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@VALE", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IVALE;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@EFECTIVO", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IEFECTIVO;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@CHEQUE", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ICHEQUE;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@TARJETA", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ITARJETA;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@NUM_VALE", OleDbType.Numeric);
                                auxPar.Value=oCVENM.INUM_VALE;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@DESCUENTOV", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IDESCUENTOV;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@FECHA_2", OleDbType.Date);
                                auxPar.Value=oCVENM.IFECHA_2;
                                  parts.Add(auxPar);
				


				auxPar= new OleDbParameter("@VCOMISION", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IVCOMISION;
                                  parts.Add(auxPar);
				



  OleDbParameter[] arParms= new OleDbParameter[parts.Count];
  parts.CopyTo(arParms,0);



  OleDbDataReader dr;
  if(st==null)
  dr = OleDbHelper.ExecuteReader(this.sCadenaConexion,CommandType.Text, CmdTxt,arParms);
  else
  dr = OleDbHelper.ExecuteReader(st,CommandType.Text, CmdTxt,arParms);


  if (dr.Read())
  {

                                      if( dr["VENTA"]!= System.DBNull.Value)
                                     {
                                     retorno.IVENTA=(string)(dr["VENTA"]);
                                    }

                                      if( dr["CLIENTE"]!= System.DBNull.Value)
                                     {
                                     retorno.ICLIENTE=(string)(dr["CLIENTE"]);
                                    }

                                      if( dr["ESTATUS"]!= System.DBNull.Value)
                                     {
                                     retorno.IESTATUS=(string)(dr["ESTATUS"]);
                                    }

                                      if( dr["PEDIDO"]!= System.DBNull.Value)
                                     {
                                     retorno.IPEDIDO=(DateTime)(dr["PEDIDO"]);
                                    }

                                      if( dr["FACTURA"]!= System.DBNull.Value)
                                     {
                                     retorno.IFACTURA=(string)(dr["FACTURA"]);
                                    }

                                      if( dr["F_FACTURA"]!= System.DBNull.Value)
                                     {
                                     retorno.IF_FACTURA=(DateTime)(dr["F_FACTURA"]);
                                    }

                                      if( dr["VENDEDOR"]!= System.DBNull.Value)
                                     {
                                     retorno.IVENDEDOR=(string)(dr["VENDEDOR"]);
                                    }

                                      if( dr["SUMA"]!= System.DBNull.Value)
                                     {
                                     retorno.ISUMA=(decimal)(dr["SUMA"]);
                                    }

                                      if( dr["IMPUESTO"]!= System.DBNull.Value)
                                     {
                                     retorno.IIMPUESTO=(decimal)(dr["IMPUESTO"]);
                                    }

                                      if( dr["IMPUESTO2"]!= System.DBNull.Value)
                                     {
                                     retorno.IIMPUESTO2=(decimal)(dr["IMPUESTO2"]);
                                    }

                                      if( dr["TOTAL"]!= System.DBNull.Value)
                                     {
                                     retorno.ITOTAL=(decimal)(dr["TOTAL"]);
                                    }

                                      if( dr["SALDO"]!= System.DBNull.Value)
                                     {
                                     retorno.ISALDO=(decimal)(dr["SALDO"]);
                                    }

                                      if( dr["SUCURSAL"]!= System.DBNull.Value)
                                     {
                                     retorno.ISUCURSAL=(decimal)(dr["SUCURSAL"]);
                                    }

                                      if( dr["DESCUENTO"]!= System.DBNull.Value)
                                     {
                                     retorno.IDESCUENTO=(decimal)(dr["DESCUENTO"]);
                                    }

                                      if( dr["DESC_PPP1"]!= System.DBNull.Value)
                                     {
                                     retorno.IDESC_PPP1=(decimal)(dr["DESC_PPP1"]);
                                    }

                                      if( dr["DESC_PPP2"]!= System.DBNull.Value)
                                     {
                                     retorno.IDESC_PPP2=(decimal)(dr["DESC_PPP2"]);
                                    }

                                      if( dr["DESC_PPP3"]!= System.DBNull.Value)
                                     {
                                     retorno.IDESC_PPP3=(decimal)(dr["DESC_PPP3"]);
                                    }

                                      if( dr["DESCUENTO1"]!= System.DBNull.Value)
                                     {
                                     retorno.IDESCUENTO1=(decimal)(dr["DESCUENTO1"]);
                                    }

                                      if( dr["DESCUENTO2"]!= System.DBNull.Value)
                                     {
                                     retorno.IDESCUENTO2=(decimal)(dr["DESCUENTO2"]);
                                    }

                                      if( dr["DESCUENTO3"]!= System.DBNull.Value)
                                     {
                                     retorno.IDESCUENTO3=(decimal)(dr["DESCUENTO3"]);
                                    }

                                      if( dr["A_CUENTA"]!= System.DBNull.Value)
                                     {
                                     retorno.IA_CUENTA=(decimal)(dr["A_CUENTA"]);
                                    }

                                      if( dr["COMISION"]!= System.DBNull.Value)
                                     {
                                     retorno.ICOMISION=(decimal)(dr["COMISION"]);
                                    }

                                      if( dr["COMISION_U"]!= System.DBNull.Value)
                                     {
                                     retorno.ICOMISION_U=(decimal)(dr["COMISION_U"]);
                                    }

                                      if( dr["COMISION_E"]!= System.DBNull.Value)
                                     {
                                     retorno.ICOMISION_E=(decimal)(dr["COMISION_E"]);
                                    }

                                      if( dr["PAGO"]!= System.DBNull.Value)
                                     {
                                     retorno.IPAGO=(DateTime)(dr["PAGO"]);
                                    }

                                      if( dr["TIPO_PAGO"]!= System.DBNull.Value)
                                     {
                                     retorno.ITIPO_PAGO=(string)(dr["TIPO_PAGO"]);
                                    }

                                      if( dr["NOTA1"]!= System.DBNull.Value)
                                     {
                                     retorno.INOTA1=(string)(dr["NOTA1"]);
                                    }

                                      if( dr["NOTA2"]!= System.DBNull.Value)
                                     {
                                     retorno.INOTA2=(string)(dr["NOTA2"]);
                                    }

                                      if( dr["NOTA3"]!= System.DBNull.Value)
                                     {
                                     retorno.INOTA3=(string)(dr["NOTA3"]);
                                    }

                                      if( dr["CREDITO"]!= System.DBNull.Value)
                                     {
                                     retorno.ICREDITO=(decimal)(dr["CREDITO"]);
                                    }

                                      if( dr["MES"]!= System.DBNull.Value)
                                     {
                                     retorno.IMES=(string)(dr["MES"]);
                                    }

                                      if( dr["COSTO"]!= System.DBNull.Value)
                                     {
                                     retorno.ICOSTO=(decimal)(dr["COSTO"]);
                                    }

                                      if( dr["COSTOUS"]!= System.DBNull.Value)
                                     {
                                     retorno.ICOSTOUS=(decimal)(dr["COSTOUS"]);
                                    }

                                      if( dr["REMISION"]!= System.DBNull.Value)
                                     {
                                     retorno.IREMISION=(decimal)(dr["REMISION"]);
                                    }

                                      if( dr["F_REMISION"]!= System.DBNull.Value)
                                     {
                                     retorno.IF_REMISION=(DateTime)(dr["F_REMISION"]);
                                    }

                                      if( dr["TODOUS"]!= System.DBNull.Value)
                                     {
                                     retorno.ITODOUS=(string)(dr["TODOUS"]);
                                    }

                                      if( dr["ENDOLARES"]!= System.DBNull.Value)
                                     {
                                     retorno.IENDOLARES=(string)(dr["ENDOLARES"]);
                                    }

                                      if( dr["TC"]!= System.DBNull.Value)
                                     {
                                     retorno.ITC=(decimal)(dr["TC"]);
                                    }

                                      if( dr["SUMAUS"]!= System.DBNull.Value)
                                     {
                                     retorno.ISUMAUS=(decimal)(dr["SUMAUS"]);
                                    }

                                      if( dr["IMPUESTOUS"]!= System.DBNull.Value)
                                     {
                                     retorno.IIMPUESTOUS=(decimal)(dr["IMPUESTOUS"]);
                                    }

                                      if( dr["TOTALUS"]!= System.DBNull.Value)
                                     {
                                     retorno.ITOTALUS=(decimal)(dr["TOTALUS"]);
                                    }

                                      if( dr["A_CUENTAUS"]!= System.DBNull.Value)
                                     {
                                     retorno.IA_CUENTAUS=(decimal)(dr["A_CUENTAUS"]);
                                    }

                                      if( dr["SALDO_US"]!= System.DBNull.Value)
                                     {
                                     retorno.ISALDO_US=(decimal)(dr["SALDO_US"]);
                                    }

                                      if( dr["ENTREGA"]!= System.DBNull.Value)
                                     {
                                     retorno.IENTREGA=(string)(dr["ENTREGA"]);
                                    }

                                      if( dr["SURTIDO"]!= System.DBNull.Value)
                                     {
                                     retorno.ISURTIDO=(string)(dr["SURTIDO"]);
                                    }

                                      if( dr["CONDICION"]!= System.DBNull.Value)
                                     {
                                     retorno.ICONDICION=(string)(dr["CONDICION"]);
                                    }

                                      if( dr["CONDICION2"]!= System.DBNull.Value)
                                     {
                                     retorno.ICONDICION2=(string)(dr["CONDICION2"]);
                                    }

                                      if( dr["NUMERO"]!= System.DBNull.Value)
                                     {
                                     retorno.INUMERO=(decimal)(dr["NUMERO"]);
                                    }

                                      if( dr["NCREDITOPP"]!= System.DBNull.Value)
                                     {
                                     retorno.INCREDITOPP=(decimal)(dr["NCREDITOPP"]);
                                    }

                                      if( dr["NCIVA"]!= System.DBNull.Value)
                                     {
                                     retorno.INCIVA=(decimal)(dr["NCIVA"]);
                                    }

                                      if( dr["NCTOTAL"]!= System.DBNull.Value)
                                     {
                                     retorno.INCTOTAL=(decimal)(dr["NCTOTAL"]);
                                    }

                                      if( dr["ORIGEN"]!= System.DBNull.Value)
                                     {
                                     retorno.IORIGEN=(string)(dr["ORIGEN"]);
                                    }

                                      if( dr["EXPORTADO"]!= System.DBNull.Value)
                                     {
                                     retorno.IEXPORTADO=(string)(dr["EXPORTADO"]);
                                    }

                                      if( dr["PLANO"]!= System.DBNull.Value)
                                     {
                                     retorno.IPLANO=(string)(dr["PLANO"]);
                                    }

                                      if( dr["MONEDA"]!= System.DBNull.Value)
                                     {
                                     retorno.IMONEDA=(string)(dr["MONEDA"]);
                                    }

                                      if( dr["EXPORTADOC"]!= System.DBNull.Value)
                                     {
                                     retorno.IEXPORTADOC=(string)(dr["EXPORTADOC"]);
                                    }

                                      if( dr["CAJERO"]!= System.DBNull.Value)
                                     {
                                     retorno.ICAJERO=(string)(dr["CAJERO"]);
                                    }

                                      if( dr["HORAFACT"]!= System.DBNull.Value)
                                     {
                                     retorno.IHORAFACT=(string)(dr["HORAFACT"]);
                                    }

                                      if( dr["SUMAX"]!= System.DBNull.Value)
                                     {
                                     retorno.ISUMAX=(decimal)(dr["SUMAX"]);
                                    }

                                      if( dr["IMPUESTOX"]!= System.DBNull.Value)
                                     {
                                     retorno.IIMPUESTOX=(decimal)(dr["IMPUESTOX"]);
                                    }

                                      if( dr["TOTALX"]!= System.DBNull.Value)
                                     {
                                     retorno.ITOTALX=(decimal)(dr["TOTALX"]);
                                    }

                                      if( dr["ID"]!= System.DBNull.Value)
                                     {
                                     retorno.IID=(string)(dr["ID"]);
                                    }

                                      if( dr["ID_FECHA"]!= System.DBNull.Value)
                                     {
                                     retorno.IID_FECHA=(DateTime)(dr["ID_FECHA"]);
                                    }

                                      if( dr["ID_HORA"]!= System.DBNull.Value)
                                     {
                                     retorno.IID_HORA=(string)(dr["ID_HORA"]);
                                    }

                                      if( dr["V_PROMO"]!= System.DBNull.Value)
                                     {
                                     retorno.IV_PROMO=(string)(dr["V_PROMO"]);
                                    }

                                      if( dr["TOTAL2"]!= System.DBNull.Value)
                                     {
                                     retorno.ITOTAL2=(decimal)(dr["TOTAL2"]);
                                    }

                                      if( dr["VALE"]!= System.DBNull.Value)
                                     {
                                     retorno.IVALE=(decimal)(dr["VALE"]);
                                    }

                                      if( dr["EFECTIVO"]!= System.DBNull.Value)
                                     {
                                     retorno.IEFECTIVO=(decimal)(dr["EFECTIVO"]);
                                    }

                                      if( dr["CHEQUE"]!= System.DBNull.Value)
                                     {
                                     retorno.ICHEQUE=(decimal)(dr["CHEQUE"]);
                                    }

                                      if( dr["TARJETA"]!= System.DBNull.Value)
                                     {
                                     retorno.ITARJETA=(decimal)(dr["TARJETA"]);
                                    }

                                      if( dr["NUM_VALE"]!= System.DBNull.Value)
                                     {
                                     retorno.INUM_VALE=(decimal)(dr["NUM_VALE"]);
                                    }

                                      if( dr["DESCUENTOV"]!= System.DBNull.Value)
                                     {
                                     retorno.IDESCUENTOV=(decimal)(dr["DESCUENTOV"]);
                                    }

                                      if( dr["FECHA_2"]!= System.DBNull.Value)
                                     {
                                     retorno.IFECHA_2=(DateTime)(dr["FECHA_2"]);
                                    }

                                      if( dr["VCOMISION"]!= System.DBNull.Value)
                                     {
                                     retorno.IVCOMISION=(string)(dr["VCOMISION"]);
                                    }

				}
				else
				{
					retorno =null;
				}

		

				
				return retorno;
			}
			catch (Exception e)
			{
				this.iComentario=e.Message + e.StackTrace;
				return null;
			}


			
		}









        [AutoComplete]
        public DataSet enlistarVENM()
        {

            DataSet retorno;
            try
            {
                retorno = OleDbHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_VENM_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoVENM()
        {
            DataSet retorno;
            try
            {

                retorno = OleDbHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_VENM_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteVENM(CVENMBE oCVENM, OleDbTransaction st)
		{
			//1-EXISTE 0-NO EXISTE -1 ERROR
			int retorno;
			try
			{
				System.Collections.ArrayList parts = new ArrayList();
				OleDbParameter auxPar;



				auxPar= new OleDbParameter("@VENTA", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IVENTA;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@CLIENTE", OleDbType.VarChar);
                                auxPar.Value=oCVENM.ICLIENTE;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@ESTATUS", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IESTATUS;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@PEDIDO", OleDbType.Date);
                                auxPar.Value=oCVENM.IPEDIDO;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@FACTURA", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IFACTURA;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@F_FACTURA", OleDbType.Date);
                                auxPar.Value=oCVENM.IF_FACTURA;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@VENDEDOR", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IVENDEDOR;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@SUMA", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ISUMA;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@IMPUESTO", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IIMPUESTO;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@IMPUESTO2", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IIMPUESTO2;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@TOTAL", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ITOTAL;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@SALDO", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ISALDO;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@SUCURSAL", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ISUCURSAL;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@DESCUENTO", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IDESCUENTO;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@DESC_PPP1", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IDESC_PPP1;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@DESC_PPP2", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IDESC_PPP2;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@DESC_PPP3", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IDESC_PPP3;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@DESCUENTO1", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IDESCUENTO1;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@DESCUENTO2", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IDESCUENTO2;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@DESCUENTO3", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IDESCUENTO3;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@A_CUENTA", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IA_CUENTA;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@COMISION", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ICOMISION;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@COMISION_U", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ICOMISION_U;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@COMISION_E", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ICOMISION_E;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@PAGO", OleDbType.Date);
                                auxPar.Value=oCVENM.IPAGO;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@TIPO_PAGO", OleDbType.VarChar);
                                auxPar.Value=oCVENM.ITIPO_PAGO;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@NOTA1", OleDbType.VarChar);
                                auxPar.Value=oCVENM.INOTA1;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@NOTA2", OleDbType.VarChar);
                                auxPar.Value=oCVENM.INOTA2;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@NOTA3", OleDbType.VarChar);
                                auxPar.Value=oCVENM.INOTA3;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@CREDITO", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ICREDITO;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@MES", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IMES;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@COSTO", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ICOSTO;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@COSTOUS", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ICOSTOUS;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@REMISION", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IREMISION;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@F_REMISION", OleDbType.Date);
                                auxPar.Value=oCVENM.IF_REMISION;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@TODOUS", OleDbType.VarChar);
                                auxPar.Value=oCVENM.ITODOUS;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@ENDOLARES", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IENDOLARES;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@TC", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ITC;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@SUMAUS", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ISUMAUS;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@IMPUESTOUS", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IIMPUESTOUS;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@TOTALUS", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ITOTALUS;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@A_CUENTAUS", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IA_CUENTAUS;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@SALDO_US", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ISALDO_US;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@ENTREGA", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IENTREGA;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@SURTIDO", OleDbType.VarChar);
                                auxPar.Value=oCVENM.ISURTIDO;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@CONDICION", OleDbType.VarChar);
                                auxPar.Value=oCVENM.ICONDICION;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@CONDICION2", OleDbType.VarChar);
                                auxPar.Value=oCVENM.ICONDICION2;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@NUMERO", OleDbType.Numeric);
                                auxPar.Value=oCVENM.INUMERO;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@NCREDITOPP", OleDbType.Numeric);
                                auxPar.Value=oCVENM.INCREDITOPP;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@NCIVA", OleDbType.Numeric);
                                auxPar.Value=oCVENM.INCIVA;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@NCTOTAL", OleDbType.Numeric);
                                auxPar.Value=oCVENM.INCTOTAL;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@ORIGEN", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IORIGEN;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@EXPORTADO", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IEXPORTADO;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@PLANO", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IPLANO;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@MONEDA", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IMONEDA;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@EXPORTADOC", OleDbType.Char);
                                auxPar.Value=oCVENM.IEXPORTADOC;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@CAJERO", OleDbType.VarChar);
                                auxPar.Value=oCVENM.ICAJERO;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@HORAFACT", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IHORAFACT;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@SUMAX", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ISUMAX;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@IMPUESTOX", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IIMPUESTOX;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@TOTALX", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ITOTALX;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@ID", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IID;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@ID_FECHA", OleDbType.Date);
                                auxPar.Value=oCVENM.IID_FECHA;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IID_HORA;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@V_PROMO", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IV_PROMO;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@TOTAL2", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ITOTAL2;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@VALE", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IVALE;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@EFECTIVO", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IEFECTIVO;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@CHEQUE", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ICHEQUE;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@TARJETA", OleDbType.Numeric);
                                auxPar.Value=oCVENM.ITARJETA;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@NUM_VALE", OleDbType.Numeric);
                                auxPar.Value=oCVENM.INUM_VALE;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@DESCUENTOV", OleDbType.Numeric);
                                auxPar.Value=oCVENM.IDESCUENTOV;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@FECHA_2", OleDbType.Date);
                                auxPar.Value=oCVENM.IFECHA_2;
                                  parts.Add(auxPar);


				auxPar= new OleDbParameter("@VCOMISION", OleDbType.VarChar);
                                auxPar.Value=oCVENM.IVCOMISION;
                                  parts.Add(auxPar);

  OleDbParameter[] arParms= new OleDbParameter[parts.Count];
  parts.CopyTo(arParms,0);

  string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from VENM where

  VENTA=@VENTA    and

  CLIENTE=@CLIENTE    and

  ESTATUS=@ESTATUS    and

  PEDIDO=@PEDIDO    and

  FACTURA=@FACTURA    and

  F_FACTURA=@F_FACTURA    and

  VENDEDOR=@VENDEDOR    and

  SUMA=@SUMA    and

  IMPUESTO=@IMPUESTO    and

  IMPUESTO2=@IMPUESTO2    and

  TOTAL=@TOTAL    and

  SALDO=@SALDO    and

  SUCURSAL=@SUCURSAL    and

  DESCUENTO=@DESCUENTO    and

  DESC_PPP1=@DESC_PPP1    and

  DESC_PPP2=@DESC_PPP2    and

  DESC_PPP3=@DESC_PPP3    and

  DESCUENTO1=@DESCUENTO1    and

  DESCUENTO2=@DESCUENTO2    and

  DESCUENTO3=@DESCUENTO3    and

  A_CUENTA=@A_CUENTA    and

  COMISION=@COMISION    and

  COMISION_U=@COMISION_U    and

  COMISION_E=@COMISION_E    and

  PAGO=@PAGO    and

  TIPO_PAGO=@TIPO_PAGO    and

  NOTA1=@NOTA1    and

  NOTA2=@NOTA2    and

  NOTA3=@NOTA3    and

  CREDITO=@CREDITO    and

  MES=@MES    and

  COSTO=@COSTO    and

  COSTOUS=@COSTOUS    and

  REMISION=@REMISION    and

  F_REMISION=@F_REMISION    and

  TODOUS=@TODOUS    and

  ENDOLARES=@ENDOLARES    and

  TC=@TC    and

  SUMAUS=@SUMAUS    and

  IMPUESTOUS=@IMPUESTOUS    and

  TOTALUS=@TOTALUS    and

  A_CUENTAUS=@A_CUENTAUS    and

  SALDO_US=@SALDO_US    and

  ENTREGA=@ENTREGA    and

  SURTIDO=@SURTIDO    and

  CONDICION=@CONDICION    and

  CONDICION2=@CONDICION2    and

  NUMERO=@NUMERO    and

  NCREDITOPP=@NCREDITOPP    and

  NCIVA=@NCIVA    and

  NCTOTAL=@NCTOTAL    and

  ORIGEN=@ORIGEN    and

  EXPORTADO=@EXPORTADO    and

  PLANO=@PLANO    and

  MONEDA=@MONEDA    and

  EXPORTADOC=@EXPORTADOC    and

  CAJERO=@CAJERO    and

  HORAFACT=@HORAFACT    and

  SUMAX=@SUMAX    and

  IMPUESTOX=@IMPUESTOX    and

  TOTALX=@TOTALX    and

  ID=@ID    and

  ID_FECHA=@ID_FECHA    and

  ID_HORA=@ID_HORA    and

  V_PROMO=@V_PROMO    and

  TOTAL2=@TOTAL2    and

  VALE=@VALE    and

  EFECTIVO=@EFECTIVO    and

  CHEQUE=@CHEQUE    and

  TARJETA=@TARJETA    and

  NUM_VALE=@NUM_VALE    and

  DESCUENTOV=@DESCUENTOV    and

  FECHA_2=@FECHA_2    and

  VCOMISION=@VCOMISION  
  );";






  OleDbDataReader dr;
  if(st==null)
  dr = OleDbHelper.ExecuteReader(this.sCadenaConexion,CommandType.Text, commandText,arParms);
  else
  dr = OleDbHelper.ExecuteReader(st,CommandType.Text, commandText,arParms);



  if (dr.Read())
  {
  retorno = 1;
  }
  else
  {
  retorno = 0;
  }

  return retorno;
  }
  catch (Exception e)
  {
  this.iComentario=e.Message + e.StackTrace;
  return -1;
  }
  }




        //public CVENMBE AgregarVENM(CVENMBE oCVENM, OleDbTransaction st)
        //{
        //    try
        //    {
        //        int iRes = ExisteVENM(oCVENM, st);
        //        if (iRes == 1)
        //        {
        //            this.IComentario = "El VENM ya existe";
        //            return null;
        //        }
        //        else if (iRes == -1)
        //        {
        //            return null;
        //        }
        //        return AgregarVENMD(oCVENM, st);
        //    }
        //    catch (Exception e)
        //    {
        //        this.iComentario = e.Message + e.StackTrace;
        //        return null;
        //    }
        //}


        public bool BorrarVENM(CVENMBE oCVENM, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteVENM(oCVENM, st);
                if (iRes == 0)
                {
                    this.IComentario = "El VENM no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarVENMD(oCVENM, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarVENM(CVENMBE oCVENMNuevo, CVENMBE oCVENMAnterior, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteVENM(oCVENMAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El VENM no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarVENMD(oCVENMNuevo, oCVENMAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CVENMD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
