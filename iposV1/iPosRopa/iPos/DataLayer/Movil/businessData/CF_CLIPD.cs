

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
	   
	

	public class CF_CLIPD
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
				this.iComentario= value;
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

	
		public CF_CLIPBE  AgregarF_CLIPD(CF_CLIPBE oCF_CLIP,FbTransaction st)
		{
			
	
			try
			{
				


				System.Collections.ArrayList parts = new ArrayList();
				FbParameter auxPar;

				 
				
	auxPar= new FbParameter("@CLIENTE", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["ICLIENTE"])
                                    {
                                    auxPar.Value=oCF_CLIP.ICLIENTE;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@NOMBRE", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["INOMBRE"])
                                    {
                                    auxPar.Value=oCF_CLIP.INOMBRE;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@SALDO", FbDbType.Numeric);
                                    if(!(bool)oCF_CLIP.isnull["ISALDO"])
                                    {
                                    auxPar.Value=oCF_CLIP.ISALDO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@SALDO_VENC", FbDbType.Numeric);
                                    if(!(bool)oCF_CLIP.isnull["ISALDO_VENC"])
                                    {
                                    auxPar.Value=oCF_CLIP.ISALDO_VENC;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@LIMITE", FbDbType.Integer);
                                    if(!(bool)oCF_CLIP.isnull["ILIMITE"])
                                    {
                                    auxPar.Value=oCF_CLIP.ILIMITE;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@NUMERO", FbDbType.Integer);
                                    if(!(bool)oCF_CLIP.isnull["INUMERO"])
                                    {
                                    auxPar.Value=oCF_CLIP.INUMERO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@SALDO_US", FbDbType.Numeric);
                                    if(!(bool)oCF_CLIP.isnull["ISALDO_US"])
                                    {
                                    auxPar.Value=oCF_CLIP.ISALDO_US;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@ALTA", FbDbType.Date);
                                    if(!(bool)oCF_CLIP.isnull["IALTA"])
                                    {
                                    auxPar.Value=oCF_CLIP.IALTA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@ULT_COMPRA", FbDbType.Date);
                                    if(!(bool)oCF_CLIP.isnull["IULT_COMPRA"])
                                    {
                                    auxPar.Value=oCF_CLIP.IULT_COMPRA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@UC_CANT", FbDbType.Numeric);
                                    if(!(bool)oCF_CLIP.isnull["IUC_CANT"])
                                    {
                                    auxPar.Value=oCF_CLIP.IUC_CANT;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@NOMBRE2", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["INOMBRE2"])
                                    {
                                    auxPar.Value=oCF_CLIP.INOMBRE2;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@FACT_PERIO", FbDbType.Integer);
                                    if(!(bool)oCF_CLIP.isnull["IFACT_PERIO"])
                                    {
                                    auxPar.Value=oCF_CLIP.IFACT_PERIO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@COMPRAS_P", FbDbType.Numeric);
                                    if(!(bool)oCF_CLIP.isnull["ICOMPRAS_P"])
                                    {
                                    auxPar.Value=oCF_CLIP.ICOMPRAS_P;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@FACT_ACUM", FbDbType.Integer);
                                    if(!(bool)oCF_CLIP.isnull["IFACT_ACUM"])
                                    {
                                    auxPar.Value=oCF_CLIP.IFACT_ACUM;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@COMPRAS_A", FbDbType.Numeric);
                                    if(!(bool)oCF_CLIP.isnull["ICOMPRAS_A"])
                                    {
                                    auxPar.Value=oCF_CLIP.ICOMPRAS_A;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@CHQ_DEVUEL", FbDbType.Integer);
                                    if(!(bool)oCF_CLIP.isnull["ICHQ_DEVUEL"])
                                    {
                                    auxPar.Value=oCF_CLIP.ICHQ_DEVUEL;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@F_VENCIDAS", FbDbType.Integer);
                                    if(!(bool)oCF_CLIP.isnull["IF_VENCIDAS"])
                                    {
                                    auxPar.Value=oCF_CLIP.IF_VENCIDAS;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@CALLE", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["ICALLE"])
                                    {
                                    auxPar.Value=oCF_CLIP.ICALLE;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@COLONIA", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["ICOLONIA"])
                                    {
                                    auxPar.Value=oCF_CLIP.ICOLONIA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@ESTADO", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["IESTADO"])
                                    {
                                    auxPar.Value=oCF_CLIP.IESTADO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@CIUDAD", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["ICIUDAD"])
                                    {
                                    auxPar.Value=oCF_CLIP.ICIUDAD;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@CP", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["ICP"])
                                    {
                                    auxPar.Value=oCF_CLIP.ICP;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@RFC", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["IRFC"])
                                    {
                                    auxPar.Value=oCF_CLIP.IRFC;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@TELEFONO", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["ITELEFONO"])
                                    {
                                    auxPar.Value=oCF_CLIP.ITELEFONO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@TELEFONO2", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["ITELEFONO2"])
                                    {
                                    auxPar.Value=oCF_CLIP.ITELEFONO2;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@CONTACTO", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["ICONTACTO"])
                                    {
                                    auxPar.Value=oCF_CLIP.ICONTACTO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@CONTACTO2", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["ICONTACTO2"])
                                    {
                                    auxPar.Value=oCF_CLIP.ICONTACTO2;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@VENDEDOR", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["IVENDEDOR"])
                                    {
                                    auxPar.Value=oCF_CLIP.IVENDEDOR;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@TIPO", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["ITIPO"])
                                    {
                                    auxPar.Value=oCF_CLIP.ITIPO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@COMODIN", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["ICOMODIN"])
                                    {
                                    auxPar.Value=oCF_CLIP.ICOMODIN;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@DIAS", FbDbType.Integer);
                                    if(!(bool)oCF_CLIP.isnull["IDIAS"])
                                    {
                                    auxPar.Value=oCF_CLIP.IDIAS;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@DIASA", FbDbType.Integer);
                                    if(!(bool)oCF_CLIP.isnull["IDIASA"])
                                    {
                                    auxPar.Value=oCF_CLIP.IDIASA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@DIASB", FbDbType.Integer);
                                    if(!(bool)oCF_CLIP.isnull["IDIASB"])
                                    {
                                    auxPar.Value=oCF_CLIP.IDIASB;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@REVISION", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["IREVISION"])
                                    {
                                    auxPar.Value=oCF_CLIP.IREVISION;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@PAGOS", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["IPAGOS"])
                                    {
                                    auxPar.Value=oCF_CLIP.IPAGOS;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@CLASIFICA", FbDbType.Char);
                                    if(!(bool)oCF_CLIP.isnull["ICLASIFICA"])
                                    {
                                    auxPar.Value=oCF_CLIP.ICLASIFICA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@DESCUENTO", FbDbType.Numeric);
                                    if(!(bool)oCF_CLIP.isnull["IDESCUENTO"])
                                    {
                                    auxPar.Value=oCF_CLIP.IDESCUENTO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@BLOQUEADO", FbDbType.Char);
                                    if(!(bool)oCF_CLIP.isnull["IBLOQUEADO"])
                                    {
                                    auxPar.Value=oCF_CLIP.IBLOQUEADO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@BLOQUEONOT", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["IBLOQUEONOT"])
                                    {
                                    auxPar.Value=oCF_CLIP.IBLOQUEONOT;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@EFECTIVO", FbDbType.Char);
                                    if(!(bool)oCF_CLIP.isnull["IEFECTIVO"])
                                    {
                                    auxPar.Value=oCF_CLIP.IEFECTIVO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@CORREO", FbDbType.Char);
                                    if(!(bool)oCF_CLIP.isnull["ICORREO"])
                                    {
                                    auxPar.Value=oCF_CLIP.ICORREO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@ULT_LLAMAD", FbDbType.Date);
                                    if(!(bool)oCF_CLIP.isnull["IULT_LLAMAD"])
                                    {
                                    auxPar.Value=oCF_CLIP.IULT_LLAMAD;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@PROX_LLAMA", FbDbType.Date);
                                    if(!(bool)oCF_CLIP.isnull["IPROX_LLAMA"])
                                    {
                                    auxPar.Value=oCF_CLIP.IPROX_LLAMA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@ID", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["IID"])
                                    {
                                    auxPar.Value=oCF_CLIP.IID;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@ID_FECHA", FbDbType.Date);
                                    if(!(bool)oCF_CLIP.isnull["IID_FECHA"])
                                    {
                                    auxPar.Value=oCF_CLIP.IID_FECHA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@ID_HORA", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["IID_HORA"])
                                    {
                                    auxPar.Value=oCF_CLIP.IID_HORA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@CALLE1", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["ICALLE1"])
                                    {
                                    auxPar.Value=oCF_CLIP.ICALLE1;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@CRUZACON", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["ICRUZACON"])
                                    {
                                    auxPar.Value=oCF_CLIP.ICRUZACON;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@DESGIEPS", FbDbType.Char);
                                    if(!(bool)oCF_CLIP.isnull["IDESGIEPS"])
                                    {
                                    auxPar.Value=oCF_CLIP.IDESGIEPS;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@ENDOLARES", FbDbType.Numeric);
                                    if(!(bool)oCF_CLIP.isnull["IENDOLARES"])
                                    {
                                    auxPar.Value=oCF_CLIP.IENDOLARES;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@PLANO", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["IPLANO"])
                                    {
                                    auxPar.Value=oCF_CLIP.IPLANO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@EMAIL", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["IEMAIL"])
                                    {
                                    auxPar.Value=oCF_CLIP.IEMAIL;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@HOMEPAGE", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["IHOMEPAGE"])
                                    {
                                    auxPar.Value=oCF_CLIP.IHOMEPAGE;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@BWCOLOR", FbDbType.Char);
                                    if(!(bool)oCF_CLIP.isnull["IBWCOLOR"])
                                    {
                                    auxPar.Value=oCF_CLIP.IBWCOLOR;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@MULVEN", FbDbType.Char);
                                    if(!(bool)oCF_CLIP.isnull["IMULVEN"])
                                    {
                                    auxPar.Value=oCF_CLIP.IMULVEN;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@CTA_IEPS", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["ICTA_IEPS"])
                                    {
                                    auxPar.Value=oCF_CLIP.ICTA_IEPS;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@P_MOVIL", FbDbType.Char);
                                    if(!(bool)oCF_CLIP.isnull["IP_MOVIL"])
                                    {
                                    auxPar.Value=oCF_CLIP.IP_MOVIL;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@ACUMULA", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["IACUMULA"])
                                    {
                                    auxPar.Value=oCF_CLIP.IACUMULA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@SALDO_GLOB", FbDbType.Numeric);
                                    if(!(bool)oCF_CLIP.isnull["ISALDO_GLOB"])
                                    {
                                    auxPar.Value=oCF_CLIP.ISALDO_GLOB;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@USERNAME", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["IUSERNAME"])
                                    {
                                    auxPar.Value=oCF_CLIP.IUSERNAME;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@ID_ALTA", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["IID_ALTA"])
                                    {
                                    auxPar.Value=oCF_CLIP.IID_ALTA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@CLAVE_EDO", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["ICLAVE_EDO"])
                                    {
                                    auxPar.Value=oCF_CLIP.ICLAVE_EDO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@COB_INTERE", FbDbType.Char);
                                    if(!(bool)oCF_CLIP.isnull["ICOB_INTERE"])
                                    {
                                    auxPar.Value=oCF_CLIP.ICOB_INTERE;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@PLAZA", FbDbType.Integer);
                                    if(!(bool)oCF_CLIP.isnull["IPLAZA"])
                                    {
                                    auxPar.Value=oCF_CLIP.IPLAZA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@COM_ESP", FbDbType.Char);
                                    if(!(bool)oCF_CLIP.isnull["ICOM_ESP"])
                                    {
                                    auxPar.Value=oCF_CLIP.ICOM_ESP;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@POR_COME", FbDbType.Numeric);
                                    if(!(bool)oCF_CLIP.isnull["IPOR_COME"])
                                    {
                                    auxPar.Value=oCF_CLIP.IPOR_COME;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@L_BLOQUEO", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["IL_BLOQUEO"])
                                    {
                                    auxPar.Value=oCF_CLIP.IL_BLOQUEO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@VISITA", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["IVISITA"])
                                    {
                                    auxPar.Value=oCF_CLIP.IVISITA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@RUTA", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["IRUTA"])
                                    {
                                    auxPar.Value=oCF_CLIP.IRUTA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@L_DESC", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["IL_DESC"])
                                    {
                                    auxPar.Value=oCF_CLIP.IL_DESC;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@POCKET", FbDbType.Char);
                                    if(!(bool)oCF_CLIP.isnull["IPOCKET"])
                                    {
                                    auxPar.Value=oCF_CLIP.IPOCKET;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@CLIEPOCK", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["ICLIEPOCK"])
                                    {
                                    auxPar.Value=oCF_CLIP.ICLIEPOCK;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@DESCI", FbDbType.Char);
                                    if(!(bool)oCF_CLIP.isnull["IDESCI"])
                                    {
                                    auxPar.Value=oCF_CLIP.IDESCI;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@BLOQ2", FbDbType.Char);
                                    if(!(bool)oCF_CLIP.isnull["IBLOQ2"])
                                    {
                                    auxPar.Value=oCF_CLIP.IBLOQ2;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@DIASP", FbDbType.Char);
                                    if(!(bool)oCF_CLIP.isnull["IDIASP"])
                                    {
                                    auxPar.Value=oCF_CLIP.IDIASP;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@DIASEXTR", FbDbType.Integer);
                                    if(!(bool)oCF_CLIP.isnull["IDIASEXTR"])
                                    {
                                    auxPar.Value=oCF_CLIP.IDIASEXTR;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@COBVENCIDA", FbDbType.Char);
                                    if(!(bool)oCF_CLIP.isnull["ICOBVENCIDA"])
                                    {
                                    auxPar.Value=oCF_CLIP.ICOBVENCIDA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@VENDEDOR2", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["IVENDEDOR2"])
                                    {
                                    auxPar.Value=oCF_CLIP.IVENDEDOR2;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@CURP", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["ICURP"])
                                    {
                                    auxPar.Value=oCF_CLIP.ICURP;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@AUTORIZA", FbDbType.Char);
                                    if(!(bool)oCF_CLIP.isnull["IAUTORIZA"])
                                    {
                                    auxPar.Value=oCF_CLIP.IAUTORIZA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@TIPO_INTER", FbDbType.Char);
                                    if(!(bool)oCF_CLIP.isnull["ITIPO_INTER"])
                                    {
                                    auxPar.Value=oCF_CLIP.ITIPO_INTER;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@ESTRATEGIC", FbDbType.Char);
                                    if(!(bool)oCF_CLIP.isnull["IESTRATEGIC"])
                                    {
                                    auxPar.Value=oCF_CLIP.IESTRATEGIC;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@ESTATUS", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["IESTATUS"])
                                    {
                                    auxPar.Value=oCF_CLIP.IESTATUS;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@DIA", FbDbType.Integer);
                                    if(!(bool)oCF_CLIP.isnull["IDIA"])
                                    {
                                    auxPar.Value=oCF_CLIP.IDIA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@MES", FbDbType.Integer);
                                    if(!(bool)oCF_CLIP.isnull["IMES"])
                                    {
                                    auxPar.Value=oCF_CLIP.IMES;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@BLOQXLIMIT", FbDbType.Char);
                                    if(!(bool)oCF_CLIP.isnull["IBLOQXLIMIT"])
                                    {
                                    auxPar.Value=oCF_CLIP.IBLOQXLIMIT;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@COMPANIA", FbDbType.Char);
                                    if(!(bool)oCF_CLIP.isnull["ICOMPANIA"])
                                    {
                                    auxPar.Value=oCF_CLIP.ICOMPANIA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@CUENTA", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["ICUENTA"])
                                    {
                                    auxPar.Value=oCF_CLIP.ICUENTA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@PATERNO", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["IPATERNO"])
                                    {
                                    auxPar.Value=oCF_CLIP.IPATERNO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@MATERNO", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["IMATERNO"])
                                    {
                                    auxPar.Value=oCF_CLIP.IMATERNO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@NOMBRES", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["INOMBRES"])
                                    {
                                    auxPar.Value=oCF_CLIP.INOMBRES;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@SERVDOMI", FbDbType.Char);
                                    if(!(bool)oCF_CLIP.isnull["ISERVDOMI"])
                                    {
                                    auxPar.Value=oCF_CLIP.ISERVDOMI;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@LIMITE2", FbDbType.Integer);
                                    if(!(bool)oCF_CLIP.isnull["ILIMITE2"])
                                    {
                                    auxPar.Value=oCF_CLIP.ILIMITE2;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@LIMITETEMP", FbDbType.Integer);
                                    if(!(bool)oCF_CLIP.isnull["ILIMITETEMP"])
                                    {
                                    auxPar.Value=oCF_CLIP.ILIMITETEMP;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@TEMPORADA", FbDbType.Char);
                                    if(!(bool)oCF_CLIP.isnull["ITEMPORADA"])
                                    {
                                    auxPar.Value=oCF_CLIP.ITEMPORADA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@LEFECTIVO", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["ILEFECTIVO"])
                                    {
                                    auxPar.Value=oCF_CLIP.ILEFECTIVO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@SALDO_SISA", FbDbType.Numeric);
                                    if(!(bool)oCF_CLIP.isnull["ISALDO_SISA"])
                                    {
                                    auxPar.Value=oCF_CLIP.ISALDO_SISA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@EMPRE", FbDbType.Char);
                                    if(!(bool)oCF_CLIP.isnull["IEMPRE"])
                                    {
                                    auxPar.Value=oCF_CLIP.IEMPRE;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@FENOMCL", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["IFENOMCL"])
                                    {
                                    auxPar.Value=oCF_CLIP.IFENOMCL;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@FELOCCL", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["IFELOCCL"])
                                    {
                                    auxPar.Value=oCF_CLIP.IFELOCCL;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@FEREFCL", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["IFEREFCL"])
                                    {
                                    auxPar.Value=oCF_CLIP.IFEREFCL;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@FENUECL", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["IFENUECL"])
                                    {
                                    auxPar.Value=oCF_CLIP.IFENUECL;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@FENUICL", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["IFENUICL"])
                                    {
                                    auxPar.Value=oCF_CLIP.IFENUICL;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@FEPAICL", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["IFEPAICL"])
                                    {
                                    auxPar.Value=oCF_CLIP.IFEPAICL;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@METPAGO", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["IMETPAGO"])
                                    {
                                    auxPar.Value=oCF_CLIP.IMETPAGO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@CTAPAGO", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIP.isnull["ICTAPAGO"])
                                    {
                                    auxPar.Value=oCF_CLIP.ICTAPAGO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@ENVIAXML", FbDbType.Char);
                                    if(!(bool)oCF_CLIP.isnull["IENVIAXML"])
                                    {
                                    auxPar.Value=oCF_CLIP.IENVIAXML;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@PROCESADO", FbDbType.Char);
                                    if(!(bool)oCF_CLIP.isnull["IPROCESADO"])
                                    {
                                    auxPar.Value=oCF_CLIP.IPROCESADO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);


  string commandText = @"
        INSERT INTO F_CLIP
      (
    
CLIENTE,

NOMBRE,

SALDO,

SALDO_VENC,

LIMITE,

NUMERO,

SALDO_US,

ALTA,

ULT_COMPRA,

UC_CANT,

NOMBRE2,

FACT_PERIO,

COMPRAS_P,

FACT_ACUM,

COMPRAS_A,

CHQ_DEVUEL,

F_VENCIDAS,

CALLE,

COLONIA,

ESTADO,

CIUDAD,

CP,

RFC,

TELEFONO,

TELEFONO2,

CONTACTO,

CONTACTO2,

VENDEDOR,

TIPO,

COMODIN,

DIAS,

DIASA,

DIASB,

REVISION,

PAGOS,

CLASIFICA,

DESCUENTO,

BLOQUEADO,

BLOQUEONOT,

EFECTIVO,

CORREO,

ULT_LLAMAD,

PROX_LLAMA,

ID,

ID_FECHA,

ID_HORA,

CALLE1,

CRUZACON,

DESGIEPS,

ENDOLARES,

PLANO,

EMAIL,

HOMEPAGE,

BWCOLOR,

MULVEN,

CTA_IEPS,

P_MOVIL,

ACUMULA,

SALDO_GLOB,

USERNAME,

ID_ALTA,

CLAVE_EDO,

COB_INTERE,

PLAZA,

COM_ESP,

POR_COME,

L_BLOQUEO,

VISITA,

RUTA,

L_DESC,

POCKET,

CLIEPOCK,

DESCI,

BLOQ2,

DIASP,

DIASEXTR,

COBVENCIDA,

VENDEDOR2,

CURP,

AUTORIZA,

TIPO_INTER,

ESTRATEGIC,

ESTATUS,

DIA,

MES,

BLOQXLIMIT,

COMPANIA,

CUENTA,

PATERNO,

MATERNO,

NOMBRES,

SERVDOMI,

LIMITE2,

LIMITETEMP,

TEMPORADA,

LEFECTIVO,

SALDO_SISA,

EMPRE,

FENOMCL,

FELOCCL,

FEREFCL,

FENUECL,

FENUICL,

FEPAICL,

METPAGO,

CTAPAGO,

ENVIAXML,

PROCESADO
         )

Values (

@CLIENTE,

@NOMBRE,

@SALDO,

@SALDO_VENC,

@LIMITE,

@NUMERO,

@SALDO_US,

@ALTA,

@ULT_COMPRA,

@UC_CANT,

@NOMBRE2,

@FACT_PERIO,

@COMPRAS_P,

@FACT_ACUM,

@COMPRAS_A,

@CHQ_DEVUEL,

@F_VENCIDAS,

@CALLE,

@COLONIA,

@ESTADO,

@CIUDAD,

@CP,

@RFC,

@TELEFONO,

@TELEFONO2,

@CONTACTO,

@CONTACTO2,

@VENDEDOR,

@TIPO,

@COMODIN,

@DIAS,

@DIASA,

@DIASB,

@REVISION,

@PAGOS,

@CLASIFICA,

@DESCUENTO,

@BLOQUEADO,

@BLOQUEONOT,

@EFECTIVO,

@CORREO,

@ULT_LLAMAD,

@PROX_LLAMA,

@ID,

@ID_FECHA,

@ID_HORA,

@CALLE1,

@CRUZACON,

@DESGIEPS,

@ENDOLARES,

@PLANO,

@EMAIL,

@HOMEPAGE,

@BWCOLOR,

@MULVEN,

@CTA_IEPS,

@P_MOVIL,

@ACUMULA,

@SALDO_GLOB,

@USERNAME,

@ID_ALTA,

@CLAVE_EDO,

@COB_INTERE,

@PLAZA,

@COM_ESP,

@POR_COME,

@L_BLOQUEO,

@VISITA,

@RUTA,

@L_DESC,

@POCKET,

@CLIEPOCK,

@DESCI,

@BLOQ2,

@DIASP,

@DIASEXTR,

@COBVENCIDA,

@VENDEDOR2,

@CURP,

@AUTORIZA,

@TIPO_INTER,

@ESTRATEGIC,

@ESTATUS,

@DIA,

@MES,

@BLOQXLIMIT,

@COMPANIA,

@CUENTA,

@PATERNO,

@MATERNO,

@NOMBRES,

@SERVDOMI,

@LIMITE2,

@LIMITETEMP,

@TEMPORADA,

@LEFECTIVO,

@SALDO_SISA,

@EMPRE,

@FENOMCL,

@FELOCCL,

@FEREFCL,

@FENUECL,

@FENUICL,

@FEPAICL,

@METPAGO,

@CTAPAGO,

@ENVIAXML,

@PROCESADO
); ";

  FbParameter[] arParms= new FbParameter[parts.Count];
  parts.CopyTo(arParms,0);

  if(st==null)
  SqlHelper.ExecuteNonQuery(this.sCadenaConexion,CommandType.Text, commandText,arParms);
  else
  SqlHelper.ExecuteNonQuery(st,CommandType.Text, commandText,arParms);






  return oCF_CLIP;

  }
  catch (Exception e)
  {
  this.iComentario=e.Message + e.StackTrace;
  return null;
  }
  }


  public bool BorrarF_CLIPD(CF_CLIPBE oCF_CLIP,FbTransaction st)
  {


  try
  {
  System.Collections.ArrayList parts = new ArrayList();
  FbParameter auxPar;



				auxPar= new FbParameter("@IDD", FbDbType.BigInt);
                                auxPar.Value=oCF_CLIP.IIDD;
                                  parts.Add(auxPar);



  string commandText = @"  Delete from F_CLIP
  where

  IDD=@IDD
  ;";

  FbParameter[] arParms= new FbParameter[parts.Count];
  parts.CopyTo(arParms,0);

  if(st==null)
  SqlHelper.ExecuteNonQuery(this.sCadenaConexion,CommandType.Text, commandText,arParms);
  else
  SqlHelper.ExecuteNonQuery(st,CommandType.Text, commandText,arParms);


  return true;




  }
  catch (Exception e)
  {
  this.iComentario=e.Message + e.StackTrace;
  return false;
  }
  }


  public bool CambiarF_CLIPD(CF_CLIPBE oCF_CLIPNuevo,CF_CLIPBE oCF_CLIPAnterior,FbTransaction st)
  {


  try
  {
  System.Collections.ArrayList parts = new ArrayList();
  FbParameter auxPar;



				auxPar= new FbParameter("@CLIENTE", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["ICLIENTE"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.ICLIENTE;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@NOMBRE", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["INOMBRE"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.INOMBRE;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@SALDO", FbDbType.Numeric);
                                    if(!(bool)oCF_CLIPNuevo.isnull["ISALDO"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.ISALDO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@SALDO_VENC", FbDbType.Numeric);
                                    if(!(bool)oCF_CLIPNuevo.isnull["ISALDO_VENC"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.ISALDO_VENC;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@LIMITE", FbDbType.Integer);
                                    if(!(bool)oCF_CLIPNuevo.isnull["ILIMITE"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.ILIMITE;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@NUMERO", FbDbType.Integer);
                                    if(!(bool)oCF_CLIPNuevo.isnull["INUMERO"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.INUMERO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@SALDO_US", FbDbType.Numeric);
                                    if(!(bool)oCF_CLIPNuevo.isnull["ISALDO_US"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.ISALDO_US;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@ALTA", FbDbType.Date);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IALTA"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IALTA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@ULT_COMPRA", FbDbType.Date);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IULT_COMPRA"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IULT_COMPRA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@UC_CANT", FbDbType.Numeric);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IUC_CANT"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IUC_CANT;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@NOMBRE2", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["INOMBRE2"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.INOMBRE2;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@FACT_PERIO", FbDbType.Integer);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IFACT_PERIO"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IFACT_PERIO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@COMPRAS_P", FbDbType.Numeric);
                                    if(!(bool)oCF_CLIPNuevo.isnull["ICOMPRAS_P"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.ICOMPRAS_P;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@FACT_ACUM", FbDbType.Integer);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IFACT_ACUM"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IFACT_ACUM;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@COMPRAS_A", FbDbType.Numeric);
                                    if(!(bool)oCF_CLIPNuevo.isnull["ICOMPRAS_A"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.ICOMPRAS_A;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@CHQ_DEVUEL", FbDbType.Integer);
                                    if(!(bool)oCF_CLIPNuevo.isnull["ICHQ_DEVUEL"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.ICHQ_DEVUEL;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@F_VENCIDAS", FbDbType.Integer);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IF_VENCIDAS"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IF_VENCIDAS;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@CALLE", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["ICALLE"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.ICALLE;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@COLONIA", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["ICOLONIA"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.ICOLONIA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@ESTADO", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IESTADO"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IESTADO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@CIUDAD", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["ICIUDAD"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.ICIUDAD;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@CP", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["ICP"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.ICP;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@RFC", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IRFC"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IRFC;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@TELEFONO", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["ITELEFONO"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.ITELEFONO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@TELEFONO2", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["ITELEFONO2"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.ITELEFONO2;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@CONTACTO", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["ICONTACTO"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.ICONTACTO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@CONTACTO2", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["ICONTACTO2"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.ICONTACTO2;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@VENDEDOR", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IVENDEDOR"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IVENDEDOR;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@TIPO", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["ITIPO"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.ITIPO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@COMODIN", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["ICOMODIN"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.ICOMODIN;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@DIAS", FbDbType.Integer);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IDIAS"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IDIAS;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@DIASA", FbDbType.Integer);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IDIASA"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IDIASA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@DIASB", FbDbType.Integer);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IDIASB"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IDIASB;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@REVISION", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IREVISION"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IREVISION;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@PAGOS", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IPAGOS"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IPAGOS;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@CLASIFICA", FbDbType.Char);
                                    if(!(bool)oCF_CLIPNuevo.isnull["ICLASIFICA"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.ICLASIFICA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@DESCUENTO", FbDbType.Numeric);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IDESCUENTO"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IDESCUENTO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@BLOQUEADO", FbDbType.Char);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IBLOQUEADO"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IBLOQUEADO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@BLOQUEONOT", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IBLOQUEONOT"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IBLOQUEONOT;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@EFECTIVO", FbDbType.Char);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IEFECTIVO"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IEFECTIVO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@CORREO", FbDbType.Char);
                                    if(!(bool)oCF_CLIPNuevo.isnull["ICORREO"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.ICORREO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@ULT_LLAMAD", FbDbType.Date);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IULT_LLAMAD"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IULT_LLAMAD;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@PROX_LLAMA", FbDbType.Date);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IPROX_LLAMA"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IPROX_LLAMA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@ID", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IID"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IID;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@ID_FECHA", FbDbType.Date);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IID_FECHA"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IID_FECHA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@ID_HORA", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IID_HORA"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IID_HORA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@CALLE1", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["ICALLE1"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.ICALLE1;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@CRUZACON", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["ICRUZACON"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.ICRUZACON;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@DESGIEPS", FbDbType.Char);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IDESGIEPS"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IDESGIEPS;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@ENDOLARES", FbDbType.Numeric);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IENDOLARES"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IENDOLARES;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@PLANO", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IPLANO"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IPLANO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@EMAIL", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IEMAIL"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IEMAIL;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@HOMEPAGE", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IHOMEPAGE"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IHOMEPAGE;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@BWCOLOR", FbDbType.Char);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IBWCOLOR"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IBWCOLOR;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@MULVEN", FbDbType.Char);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IMULVEN"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IMULVEN;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@CTA_IEPS", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["ICTA_IEPS"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.ICTA_IEPS;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@P_MOVIL", FbDbType.Char);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IP_MOVIL"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IP_MOVIL;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@ACUMULA", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IACUMULA"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IACUMULA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@SALDO_GLOB", FbDbType.Numeric);
                                    if(!(bool)oCF_CLIPNuevo.isnull["ISALDO_GLOB"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.ISALDO_GLOB;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@USERNAME", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IUSERNAME"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IUSERNAME;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@ID_ALTA", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IID_ALTA"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IID_ALTA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@CLAVE_EDO", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["ICLAVE_EDO"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.ICLAVE_EDO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@COB_INTERE", FbDbType.Char);
                                    if(!(bool)oCF_CLIPNuevo.isnull["ICOB_INTERE"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.ICOB_INTERE;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@PLAZA", FbDbType.Integer);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IPLAZA"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IPLAZA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@COM_ESP", FbDbType.Char);
                                    if(!(bool)oCF_CLIPNuevo.isnull["ICOM_ESP"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.ICOM_ESP;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@POR_COME", FbDbType.Numeric);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IPOR_COME"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IPOR_COME;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@L_BLOQUEO", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IL_BLOQUEO"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IL_BLOQUEO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@VISITA", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IVISITA"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IVISITA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@RUTA", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IRUTA"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IRUTA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@L_DESC", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IL_DESC"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IL_DESC;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@POCKET", FbDbType.Char);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IPOCKET"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IPOCKET;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@CLIEPOCK", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["ICLIEPOCK"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.ICLIEPOCK;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@DESCI", FbDbType.Char);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IDESCI"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IDESCI;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@BLOQ2", FbDbType.Char);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IBLOQ2"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IBLOQ2;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@DIASP", FbDbType.Char);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IDIASP"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IDIASP;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@DIASEXTR", FbDbType.Integer);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IDIASEXTR"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IDIASEXTR;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@COBVENCIDA", FbDbType.Char);
                                    if(!(bool)oCF_CLIPNuevo.isnull["ICOBVENCIDA"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.ICOBVENCIDA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@VENDEDOR2", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IVENDEDOR2"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IVENDEDOR2;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@CURP", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["ICURP"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.ICURP;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@AUTORIZA", FbDbType.Char);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IAUTORIZA"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IAUTORIZA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@TIPO_INTER", FbDbType.Char);
                                    if(!(bool)oCF_CLIPNuevo.isnull["ITIPO_INTER"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.ITIPO_INTER;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@ESTRATEGIC", FbDbType.Char);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IESTRATEGIC"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IESTRATEGIC;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@ESTATUS", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IESTATUS"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IESTATUS;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@DIA", FbDbType.Integer);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IDIA"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IDIA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@MES", FbDbType.Integer);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IMES"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IMES;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@BLOQXLIMIT", FbDbType.Char);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IBLOQXLIMIT"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IBLOQXLIMIT;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@COMPANIA", FbDbType.Char);
                                    if(!(bool)oCF_CLIPNuevo.isnull["ICOMPANIA"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.ICOMPANIA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@CUENTA", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["ICUENTA"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.ICUENTA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@PATERNO", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IPATERNO"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IPATERNO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@MATERNO", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IMATERNO"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IMATERNO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@NOMBRES", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["INOMBRES"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.INOMBRES;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@SERVDOMI", FbDbType.Char);
                                    if(!(bool)oCF_CLIPNuevo.isnull["ISERVDOMI"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.ISERVDOMI;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@LIMITE2", FbDbType.Integer);
                                    if(!(bool)oCF_CLIPNuevo.isnull["ILIMITE2"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.ILIMITE2;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@LIMITETEMP", FbDbType.Integer);
                                    if(!(bool)oCF_CLIPNuevo.isnull["ILIMITETEMP"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.ILIMITETEMP;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@TEMPORADA", FbDbType.Char);
                                    if(!(bool)oCF_CLIPNuevo.isnull["ITEMPORADA"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.ITEMPORADA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@LEFECTIVO", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["ILEFECTIVO"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.ILEFECTIVO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@SALDO_SISA", FbDbType.Numeric);
                                    if(!(bool)oCF_CLIPNuevo.isnull["ISALDO_SISA"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.ISALDO_SISA;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@EMPRE", FbDbType.Char);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IEMPRE"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IEMPRE;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@FENOMCL", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IFENOMCL"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IFENOMCL;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@FELOCCL", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IFELOCCL"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IFELOCCL;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@FEREFCL", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IFEREFCL"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IFEREFCL;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@FENUECL", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IFENUECL"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IFENUECL;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@FENUICL", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IFENUICL"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IFENUICL;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@FEPAICL", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IFEPAICL"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IFEPAICL;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@METPAGO", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IMETPAGO"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IMETPAGO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@CTAPAGO", FbDbType.VarChar);
                                    if(!(bool)oCF_CLIPNuevo.isnull["ICTAPAGO"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.ICTAPAGO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@ENVIAXML", FbDbType.Char);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IENVIAXML"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IENVIAXML;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@PROCESADO", FbDbType.Char);
                                    if(!(bool)oCF_CLIPNuevo.isnull["IPROCESADO"])
                                    {
                                auxPar.Value=oCF_CLIPNuevo.IPROCESADO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@IDDAnt", FbDbType.BigInt);
                                    if(!(bool)oCF_CLIPAnterior.isnull["IIDD"])
                                    {
                                auxPar.Value=oCF_CLIPAnterior.IIDD;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);




string commandText = @"
  update  F_CLIP
  set

CLIENTE=@CLIENTE,

NOMBRE=@NOMBRE,

SALDO=@SALDO,

SALDO_VENC=@SALDO_VENC,

LIMITE=@LIMITE,

NUMERO=@NUMERO,

SALDO_US=@SALDO_US,

ALTA=@ALTA,

ULT_COMPRA=@ULT_COMPRA,

UC_CANT=@UC_CANT,

NOMBRE2=@NOMBRE2,

FACT_PERIO=@FACT_PERIO,

COMPRAS_P=@COMPRAS_P,

FACT_ACUM=@FACT_ACUM,

COMPRAS_A=@COMPRAS_A,

CHQ_DEVUEL=@CHQ_DEVUEL,

F_VENCIDAS=@F_VENCIDAS,

CALLE=@CALLE,

COLONIA=@COLONIA,

ESTADO=@ESTADO,

CIUDAD=@CIUDAD,

CP=@CP,

RFC=@RFC,

TELEFONO=@TELEFONO,

TELEFONO2=@TELEFONO2,

CONTACTO=@CONTACTO,

CONTACTO2=@CONTACTO2,

VENDEDOR=@VENDEDOR,

TIPO=@TIPO,

COMODIN=@COMODIN,

DIAS=@DIAS,

DIASA=@DIASA,

DIASB=@DIASB,

REVISION=@REVISION,

PAGOS=@PAGOS,

CLASIFICA=@CLASIFICA,

DESCUENTO=@DESCUENTO,

BLOQUEADO=@BLOQUEADO,

BLOQUEONOT=@BLOQUEONOT,

EFECTIVO=@EFECTIVO,

CORREO=@CORREO,

ULT_LLAMAD=@ULT_LLAMAD,

PROX_LLAMA=@PROX_LLAMA,

ID=@ID,

ID_FECHA=@ID_FECHA,

ID_HORA=@ID_HORA,

CALLE1=@CALLE1,

CRUZACON=@CRUZACON,

DESGIEPS=@DESGIEPS,

ENDOLARES=@ENDOLARES,

PLANO=@PLANO,

EMAIL=@EMAIL,

HOMEPAGE=@HOMEPAGE,

BWCOLOR=@BWCOLOR,

MULVEN=@MULVEN,

CTA_IEPS=@CTA_IEPS,

P_MOVIL=@P_MOVIL,

ACUMULA=@ACUMULA,

SALDO_GLOB=@SALDO_GLOB,

USERNAME=@USERNAME,

ID_ALTA=@ID_ALTA,

CLAVE_EDO=@CLAVE_EDO,

COB_INTERE=@COB_INTERE,

PLAZA=@PLAZA,

COM_ESP=@COM_ESP,

POR_COME=@POR_COME,

L_BLOQUEO=@L_BLOQUEO,

VISITA=@VISITA,

RUTA=@RUTA,

L_DESC=@L_DESC,

POCKET=@POCKET,

CLIEPOCK=@CLIEPOCK,

DESCI=@DESCI,

BLOQ2=@BLOQ2,

DIASP=@DIASP,

DIASEXTR=@DIASEXTR,

COBVENCIDA=@COBVENCIDA,

VENDEDOR2=@VENDEDOR2,

CURP=@CURP,

AUTORIZA=@AUTORIZA,

TIPO_INTER=@TIPO_INTER,

ESTRATEGIC=@ESTRATEGIC,

ESTATUS=@ESTATUS,

DIA=@DIA,

MES=@MES,

BLOQXLIMIT=@BLOQXLIMIT,

COMPANIA=@COMPANIA,

CUENTA=@CUENTA,

PATERNO=@PATERNO,

MATERNO=@MATERNO,

NOMBRES=@NOMBRES,

SERVDOMI=@SERVDOMI,

LIMITE2=@LIMITE2,

LIMITETEMP=@LIMITETEMP,

TEMPORADA=@TEMPORADA,

LEFECTIVO=@LEFECTIVO,

SALDO_SISA=@SALDO_SISA,

EMPRE=@EMPRE,

FENOMCL=@FENOMCL,

FELOCCL=@FELOCCL,

FEREFCL=@FEREFCL,

FENUECL=@FENUECL,

FENUICL=@FENUICL,

FEPAICL=@FEPAICL,

METPAGO=@METPAGO,

CTAPAGO=@CTAPAGO,

ENVIAXML=@ENVIAXML,

PROCESADO=@PROCESADO
  where 

IDD=@IDDAnt
  ;";

  FbParameter[] arParms= new FbParameter[parts.Count];
  parts.CopyTo(arParms,0);


  if(st==null)
  SqlHelper.ExecuteNonQuery(this.sCadenaConexion,CommandType.Text, commandText,arParms);
  else
  SqlHelper.ExecuteNonQuery(st,CommandType.Text, commandText,arParms);


  return true;


  }
  catch (Exception e)
  {
  this.iComentario=e.Message + e.StackTrace;
  return false;
  }
  }


  public CF_CLIPBE seleccionarF_CLIP(CF_CLIPBE oCF_CLIP,FbTransaction st)
  {




  CF_CLIPBE retorno = new CF_CLIPBE();
  FbDataReader dr = null;
            
  FbConnection pcn = null;

  try
  {

  System.Collections.ArrayList parts = new ArrayList();
  FbParameter auxPar;

  String CmdTxt = @"select * from F_CLIP where
 IDD=@IDD  ";


				auxPar= new FbParameter("@IDD", FbDbType.BigInt);
                                auxPar.Value=oCF_CLIP.IIDD;
                                  parts.Add(auxPar);
				



  FbParameter[] arParms= new FbParameter[parts.Count];
  parts.CopyTo(arParms,0);



  if(st==null)
  dr = SqlHelper.ExecuteReader(this.sCadenaConexion,CommandType.Text, CmdTxt, out pcn, arParms);
  else
  dr = SqlHelper.ExecuteReader(st,CommandType.Text, CmdTxt,arParms);


  if (dr.Read())
  {

                                      if( dr["CLIENTE"]!= System.DBNull.Value)
                                     {
                                     retorno.ICLIENTE=(string)(dr["CLIENTE"]);
                                    }

                                      if( dr["NOMBRE"]!= System.DBNull.Value)
                                     {
                                     retorno.INOMBRE=(string)(dr["NOMBRE"]);
                                    }

                                      if( dr["SALDO"]!= System.DBNull.Value)
                                     {
                                     retorno.ISALDO=(decimal)(dr["SALDO"]);
                                    }

                                      if( dr["SALDO_VENC"]!= System.DBNull.Value)
                                     {
                                     retorno.ISALDO_VENC=(decimal)(dr["SALDO_VENC"]);
                                    }

                                      if( dr["SALDO_US"]!= System.DBNull.Value)
                                     {
                                     retorno.ISALDO_US=(decimal)(dr["SALDO_US"]);
                                    }

                                      if( dr["ALTA"]!= System.DBNull.Value)
                                     {
                                     retorno.IALTA=(DateTime)(dr["ALTA"]);
                                    }

                                      if( dr["ULT_COMPRA"]!= System.DBNull.Value)
                                     {
                                     retorno.IULT_COMPRA=(DateTime)(dr["ULT_COMPRA"]);
                                    }

                                      if( dr["UC_CANT"]!= System.DBNull.Value)
                                     {
                                     retorno.IUC_CANT=(decimal)(dr["UC_CANT"]);
                                    }

                                      if( dr["NOMBRE2"]!= System.DBNull.Value)
                                     {
                                     retorno.INOMBRE2=(string)(dr["NOMBRE2"]);
                                    }

                                      if( dr["COMPRAS_P"]!= System.DBNull.Value)
                                     {
                                     retorno.ICOMPRAS_P=(decimal)(dr["COMPRAS_P"]);
                                    }

                                      if( dr["COMPRAS_A"]!= System.DBNull.Value)
                                     {
                                     retorno.ICOMPRAS_A=(decimal)(dr["COMPRAS_A"]);
                                    }

                                      if( dr["CALLE"]!= System.DBNull.Value)
                                     {
                                     retorno.ICALLE=(string)(dr["CALLE"]);
                                    }

                                      if( dr["COLONIA"]!= System.DBNull.Value)
                                     {
                                     retorno.ICOLONIA=(string)(dr["COLONIA"]);
                                    }

                                      if( dr["ESTADO"]!= System.DBNull.Value)
                                     {
                                     retorno.IESTADO=(string)(dr["ESTADO"]);
                                    }

                                      if( dr["CIUDAD"]!= System.DBNull.Value)
                                     {
                                     retorno.ICIUDAD=(string)(dr["CIUDAD"]);
                                    }

                                      if( dr["CP"]!= System.DBNull.Value)
                                     {
                                     retorno.ICP=(string)(dr["CP"]);
                                    }

                                      if( dr["RFC"]!= System.DBNull.Value)
                                     {
                                     retorno.IRFC=(string)(dr["RFC"]);
                                    }

                                      if( dr["TELEFONO"]!= System.DBNull.Value)
                                     {
                                     retorno.ITELEFONO=(string)(dr["TELEFONO"]);
                                    }

                                      if( dr["TELEFONO2"]!= System.DBNull.Value)
                                     {
                                     retorno.ITELEFONO2=(string)(dr["TELEFONO2"]);
                                    }

                                      if( dr["CONTACTO"]!= System.DBNull.Value)
                                     {
                                     retorno.ICONTACTO=(string)(dr["CONTACTO"]);
                                    }

                                      if( dr["CONTACTO2"]!= System.DBNull.Value)
                                     {
                                     retorno.ICONTACTO2=(string)(dr["CONTACTO2"]);
                                    }

                                      if( dr["VENDEDOR"]!= System.DBNull.Value)
                                     {
                                     retorno.IVENDEDOR=(string)(dr["VENDEDOR"]);
                                    }

                                      if( dr["TIPO"]!= System.DBNull.Value)
                                     {
                                     retorno.ITIPO=(string)(dr["TIPO"]);
                                    }

                                      if( dr["COMODIN"]!= System.DBNull.Value)
                                     {
                                     retorno.ICOMODIN=(string)(dr["COMODIN"]);
                                    }

                                      if( dr["REVISION"]!= System.DBNull.Value)
                                     {
                                     retorno.IREVISION=(string)(dr["REVISION"]);
                                    }

                                      if( dr["PAGOS"]!= System.DBNull.Value)
                                     {
                                     retorno.IPAGOS=(string)(dr["PAGOS"]);
                                    }

                                      if( dr["CLASIFICA"]!= System.DBNull.Value)
                                     {
                                     retorno.ICLASIFICA=(string)(dr["CLASIFICA"]);
                                    }

                                      if( dr["DESCUENTO"]!= System.DBNull.Value)
                                     {
                                     retorno.IDESCUENTO=(decimal)(dr["DESCUENTO"]);
                                    }

                                      if( dr["BLOQUEADO"]!= System.DBNull.Value)
                                     {
                                     retorno.IBLOQUEADO=(string)(dr["BLOQUEADO"]);
                                    }

                                      if( dr["BLOQUEONOT"]!= System.DBNull.Value)
                                     {
                                     retorno.IBLOQUEONOT=(string)(dr["BLOQUEONOT"]);
                                    }

                                      if( dr["EFECTIVO"]!= System.DBNull.Value)
                                     {
                                     retorno.IEFECTIVO=(string)(dr["EFECTIVO"]);
                                    }

                                      if( dr["CORREO"]!= System.DBNull.Value)
                                     {
                                     retorno.ICORREO=(string)(dr["CORREO"]);
                                    }

                                      if( dr["ULT_LLAMAD"]!= System.DBNull.Value)
                                     {
                                     retorno.IULT_LLAMAD=(DateTime)(dr["ULT_LLAMAD"]);
                                    }

                                      if( dr["PROX_LLAMA"]!= System.DBNull.Value)
                                     {
                                     retorno.IPROX_LLAMA=(DateTime)(dr["PROX_LLAMA"]);
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

                                      if( dr["CALLE1"]!= System.DBNull.Value)
                                     {
                                     retorno.ICALLE1=(string)(dr["CALLE1"]);
                                    }

                                      if( dr["CRUZACON"]!= System.DBNull.Value)
                                     {
                                     retorno.ICRUZACON=(string)(dr["CRUZACON"]);
                                    }

                                      if( dr["DESGIEPS"]!= System.DBNull.Value)
                                     {
                                     retorno.IDESGIEPS=(string)(dr["DESGIEPS"]);
                                    }

                                      if( dr["ENDOLARES"]!= System.DBNull.Value)
                                     {
                                     retorno.IENDOLARES=(decimal)(dr["ENDOLARES"]);
                                    }

                                      if( dr["PLANO"]!= System.DBNull.Value)
                                     {
                                     retorno.IPLANO=(string)(dr["PLANO"]);
                                    }

                                      if( dr["EMAIL"]!= System.DBNull.Value)
                                     {
                                     retorno.IEMAIL=(string)(dr["EMAIL"]);
                                    }

                                      if( dr["HOMEPAGE"]!= System.DBNull.Value)
                                     {
                                     retorno.IHOMEPAGE=(string)(dr["HOMEPAGE"]);
                                    }

                                      if( dr["BWCOLOR"]!= System.DBNull.Value)
                                     {
                                     retorno.IBWCOLOR=(string)(dr["BWCOLOR"]);
                                    }

                                      if( dr["MULVEN"]!= System.DBNull.Value)
                                     {
                                     retorno.IMULVEN=(string)(dr["MULVEN"]);
                                    }

                                      if( dr["CTA_IEPS"]!= System.DBNull.Value)
                                     {
                                     retorno.ICTA_IEPS=(string)(dr["CTA_IEPS"]);
                                    }

                                      if( dr["P_MOVIL"]!= System.DBNull.Value)
                                     {
                                     retorno.IP_MOVIL=(string)(dr["P_MOVIL"]);
                                    }

                                      if( dr["ACUMULA"]!= System.DBNull.Value)
                                     {
                                     retorno.IACUMULA=(string)(dr["ACUMULA"]);
                                    }

                                      if( dr["SALDO_GLOB"]!= System.DBNull.Value)
                                     {
                                     retorno.ISALDO_GLOB=(decimal)(dr["SALDO_GLOB"]);
                                    }

                                      if( dr["USERNAME"]!= System.DBNull.Value)
                                     {
                                     retorno.IUSERNAME=(string)(dr["USERNAME"]);
                                    }

                                      if( dr["ID_ALTA"]!= System.DBNull.Value)
                                     {
                                     retorno.IID_ALTA=(string)(dr["ID_ALTA"]);
                                    }

                                      if( dr["CLAVE_EDO"]!= System.DBNull.Value)
                                     {
                                     retorno.ICLAVE_EDO=(string)(dr["CLAVE_EDO"]);
                                    }

                                      if( dr["COB_INTERE"]!= System.DBNull.Value)
                                     {
                                     retorno.ICOB_INTERE=(string)(dr["COB_INTERE"]);
                                    }

                                      if( dr["COM_ESP"]!= System.DBNull.Value)
                                     {
                                     retorno.ICOM_ESP=(string)(dr["COM_ESP"]);
                                    }

                                      if( dr["POR_COME"]!= System.DBNull.Value)
                                     {
                                     retorno.IPOR_COME=(decimal)(dr["POR_COME"]);
                                    }

                                      if( dr["L_BLOQUEO"]!= System.DBNull.Value)
                                     {
                                     retorno.IL_BLOQUEO=(string)(dr["L_BLOQUEO"]);
                                    }

                                      if( dr["VISITA"]!= System.DBNull.Value)
                                     {
                                     retorno.IVISITA=(string)(dr["VISITA"]);
                                    }

                                      if( dr["RUTA"]!= System.DBNull.Value)
                                     {
                                     retorno.IRUTA=(string)(dr["RUTA"]);
                                    }

                                      if( dr["L_DESC"]!= System.DBNull.Value)
                                     {
                                     retorno.IL_DESC=(string)(dr["L_DESC"]);
                                    }

                                      if( dr["POCKET"]!= System.DBNull.Value)
                                     {
                                     retorno.IPOCKET=(string)(dr["POCKET"]);
                                    }

                                      if( dr["CLIEPOCK"]!= System.DBNull.Value)
                                     {
                                     retorno.ICLIEPOCK=(string)(dr["CLIEPOCK"]);
                                    }

                                      if( dr["DESCI"]!= System.DBNull.Value)
                                     {
                                     retorno.IDESCI=(string)(dr["DESCI"]);
                                    }

                                      if( dr["BLOQ2"]!= System.DBNull.Value)
                                     {
                                     retorno.IBLOQ2=(string)(dr["BLOQ2"]);
                                    }

                                      if( dr["DIASP"]!= System.DBNull.Value)
                                     {
                                     retorno.IDIASP=(string)(dr["DIASP"]);
                                    }

                                      if( dr["COBVENCIDA"]!= System.DBNull.Value)
                                     {
                                     retorno.ICOBVENCIDA=(string)(dr["COBVENCIDA"]);
                                    }

                                      if( dr["VENDEDOR2"]!= System.DBNull.Value)
                                     {
                                     retorno.IVENDEDOR2=(string)(dr["VENDEDOR2"]);
                                    }

                                      if( dr["CURP"]!= System.DBNull.Value)
                                     {
                                     retorno.ICURP=(string)(dr["CURP"]);
                                    }

                                      if( dr["AUTORIZA"]!= System.DBNull.Value)
                                     {
                                     retorno.IAUTORIZA=(string)(dr["AUTORIZA"]);
                                    }

                                      if( dr["TIPO_INTER"]!= System.DBNull.Value)
                                     {
                                     retorno.ITIPO_INTER=(string)(dr["TIPO_INTER"]);
                                    }

                                      if( dr["ESTRATEGIC"]!= System.DBNull.Value)
                                     {
                                     retorno.IESTRATEGIC=(string)(dr["ESTRATEGIC"]);
                                    }

                                      if( dr["ESTATUS"]!= System.DBNull.Value)
                                     {
                                     retorno.IESTATUS=(string)(dr["ESTATUS"]);
                                    }

                                      if( dr["BLOQXLIMIT"]!= System.DBNull.Value)
                                     {
                                     retorno.IBLOQXLIMIT=(string)(dr["BLOQXLIMIT"]);
                                    }

                                      if( dr["COMPANIA"]!= System.DBNull.Value)
                                     {
                                     retorno.ICOMPANIA=(string)(dr["COMPANIA"]);
                                    }

                                      if( dr["CUENTA"]!= System.DBNull.Value)
                                     {
                                     retorno.ICUENTA=(string)(dr["CUENTA"]);
                                    }

                                      if( dr["PATERNO"]!= System.DBNull.Value)
                                     {
                                     retorno.IPATERNO=(string)(dr["PATERNO"]);
                                    }

                                      if( dr["MATERNO"]!= System.DBNull.Value)
                                     {
                                     retorno.IMATERNO=(string)(dr["MATERNO"]);
                                    }

                                      if( dr["NOMBRES"]!= System.DBNull.Value)
                                     {
                                     retorno.INOMBRES=(string)(dr["NOMBRES"]);
                                    }

                                      if( dr["SERVDOMI"]!= System.DBNull.Value)
                                     {
                                     retorno.ISERVDOMI=(string)(dr["SERVDOMI"]);
                                    }

                                      if( dr["TEMPORADA"]!= System.DBNull.Value)
                                     {
                                     retorno.ITEMPORADA=(string)(dr["TEMPORADA"]);
                                    }

                                      if( dr["LEFECTIVO"]!= System.DBNull.Value)
                                     {
                                     retorno.ILEFECTIVO=(string)(dr["LEFECTIVO"]);
                                    }

                                      if( dr["SALDO_SISA"]!= System.DBNull.Value)
                                     {
                                     retorno.ISALDO_SISA=(decimal)(dr["SALDO_SISA"]);
                                    }

                                      if( dr["EMPRE"]!= System.DBNull.Value)
                                     {
                                     retorno.IEMPRE=(string)(dr["EMPRE"]);
                                    }

                                      if( dr["FENOMCL"]!= System.DBNull.Value)
                                     {
                                     retorno.IFENOMCL=(string)(dr["FENOMCL"]);
                                    }

                                      if( dr["FELOCCL"]!= System.DBNull.Value)
                                     {
                                     retorno.IFELOCCL=(string)(dr["FELOCCL"]);
                                    }

                                      if( dr["FEREFCL"]!= System.DBNull.Value)
                                     {
                                     retorno.IFEREFCL=(string)(dr["FEREFCL"]);
                                    }

                                      if( dr["FENUECL"]!= System.DBNull.Value)
                                     {
                                     retorno.IFENUECL=(string)(dr["FENUECL"]);
                                    }

                                      if( dr["FENUICL"]!= System.DBNull.Value)
                                     {
                                     retorno.IFENUICL=(string)(dr["FENUICL"]);
                                    }

                                      if( dr["FEPAICL"]!= System.DBNull.Value)
                                     {
                                     retorno.IFEPAICL=(string)(dr["FEPAICL"]);
                                    }

                                      if( dr["METPAGO"]!= System.DBNull.Value)
                                     {
                                     retorno.IMETPAGO=(string)(dr["METPAGO"]);
                                    }

                                      if( dr["CTAPAGO"]!= System.DBNull.Value)
                                     {
                                     retorno.ICTAPAGO=(string)(dr["CTAPAGO"]);
                                    }

                                      if( dr["ENVIAXML"]!= System.DBNull.Value)
                                     {
                                     retorno.IENVIAXML=(string)(dr["ENVIAXML"]);
                                    }

                                      if( dr["IDD"]!= System.DBNull.Value)
                                     {
                                     retorno.IIDD=(long)(dr["IDD"]);
                                    }

                                      if( dr["PROCESADO"]!= System.DBNull.Value)
                                     {
                                     retorno.IPROCESADO=(string)(dr["PROCESADO"]);
                                    }

                                      if( dr["LIMITE"]!= System.DBNull.Value)
                                     {
                                     retorno.ILIMITE=int.Parse(dr["LIMITE"].ToString());
                                    }

                                      if( dr["NUMERO"]!= System.DBNull.Value)
                                     {
                                     retorno.INUMERO=int.Parse(dr["NUMERO"].ToString());
                                    }

                                      if( dr["FACT_PERIO"]!= System.DBNull.Value)
                                     {
                                     retorno.IFACT_PERIO=int.Parse(dr["FACT_PERIO"].ToString());
                                    }

                                      if( dr["FACT_ACUM"]!= System.DBNull.Value)
                                     {
                                     retorno.IFACT_ACUM=int.Parse(dr["FACT_ACUM"].ToString());
                                    }

                                      if( dr["CHQ_DEVUEL"]!= System.DBNull.Value)
                                     {
                                     retorno.ICHQ_DEVUEL=int.Parse(dr["CHQ_DEVUEL"].ToString());
                                    }

                                      if( dr["F_VENCIDAS"]!= System.DBNull.Value)
                                     {
                                     retorno.IF_VENCIDAS=int.Parse(dr["F_VENCIDAS"].ToString());
                                    }

                                      if( dr["DIAS"]!= System.DBNull.Value)
                                     {
                                     retorno.IDIAS=int.Parse(dr["DIAS"].ToString());
                                    }

                                      if( dr["DIASA"]!= System.DBNull.Value)
                                     {
                                     retorno.IDIASA=int.Parse(dr["DIASA"].ToString());
                                    }

                                      if( dr["DIASB"]!= System.DBNull.Value)
                                     {
                                     retorno.IDIASB=int.Parse(dr["DIASB"].ToString());
                                    }

                                      if( dr["PLAZA"]!= System.DBNull.Value)
                                     {
                                     retorno.IPLAZA=int.Parse(dr["PLAZA"].ToString());
                                    }

                                      if( dr["DIASEXTR"]!= System.DBNull.Value)
                                     {
                                     retorno.IDIASEXTR=int.Parse(dr["DIASEXTR"].ToString());
                                    }

                                      if( dr["DIA"]!= System.DBNull.Value)
                                     {
                                     retorno.IDIA=int.Parse(dr["DIA"].ToString());
                                    }

                                      if( dr["MES"]!= System.DBNull.Value)
                                     {
                                     retorno.IMES=int.Parse(dr["MES"].ToString());
                                    }

                                      if( dr["LIMITE2"]!= System.DBNull.Value)
                                     {
                                     retorno.ILIMITE2=int.Parse(dr["LIMITE2"].ToString());
                                    }

                                      if( dr["LIMITETEMP"]!= System.DBNull.Value)
                                     {
                                     retorno.ILIMITETEMP=int.Parse(dr["LIMITETEMP"].ToString());
                                    }

				}
				else
				{
					retorno =null;
				}

				Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

				return retorno;
			}
			catch (Exception e)
			{
				Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
				this.iComentario=e.Message + e.StackTrace;
				return null;
			}


			
		}









		public DataSet enlistarF_CLIP()
		{
			
	DataSet retorno;
		try
			{
			retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion,CommandType.StoredProcedure, "iPos_F_CLIP_enlistar");
				
	return retorno;
			}
			catch (Exception e)
			{
				this.iComentario=e.Message + e.StackTrace;
				return null;
			}


			
		}




		public DataSet enlistarCortoF_CLIP()
		{
			DataSet retorno;
			try
			{
			
				retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion,CommandType.StoredProcedure, "iPos_F_CLIP_enlistarCorto");
				
				return retorno;
			}
			catch (Exception e)
			{
				this.iComentario=e.Message + e.StackTrace;
				return null;
			}


			
		}



		public int ExisteF_CLIP(CF_CLIPBE oCF_CLIP,FbTransaction st)
		{
			//1-EXISTE 0-NO EXISTE -1 ERROR
			int retorno;
			FbDataReader dr = null;
            
			FbConnection pcn = null;

			try
			{
				System.Collections.ArrayList parts = new ArrayList();
				FbParameter auxPar;



				auxPar= new FbParameter("@IDD", FbDbType.BigInt);
                                auxPar.Value=oCF_CLIP.IIDD;
                                  parts.Add(auxPar);

  FbParameter[] arParms= new FbParameter[parts.Count];
  parts.CopyTo(arParms,0);

  string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from F_CLIP where

  IDD=@IDD  
  );";






  if(st==null)
  dr = SqlHelper.ExecuteReader(this.sCadenaConexion,CommandType.Text, commandText, out pcn, arParms);
  else
  dr = SqlHelper.ExecuteReader(st,CommandType.Text, commandText,arParms);



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
  this.iComentario=e.Message + e.StackTrace;
  return -1;
  }
  }




  public CF_CLIPBE AgregarF_CLIP(CF_CLIPBE oCF_CLIP, FbTransaction st)
  {
  try
  {
  int iRes = ExisteF_CLIP(oCF_CLIP, st);
  if(iRes==1)
  {
  this.IComentario = "El F_CLIP ya existe";
  return null;
  }
  else if (iRes == -1)
  {
  return null;
  }
  return AgregarF_CLIPD(oCF_CLIP, st);
  }
  catch (Exception e)
  {
  this.iComentario=e.Message + e.StackTrace;
  return null;
  }
  }


  public bool BorrarF_CLIP(CF_CLIPBE oCF_CLIP, FbTransaction st)
  {
  try
  {
  int iRes = ExisteF_CLIP(oCF_CLIP, st);
  if(iRes==0)
  {
  this.IComentario = "El F_CLIP no existe";
  return false;
  }
  else if (iRes == -1)
  {
  return false;
  }
  return BorrarF_CLIPD(oCF_CLIP, st);
  }
  catch (Exception e)
  {
  this.iComentario=e.Message + e.StackTrace;
  return false;
  }

  }


  public bool CambiarF_CLIP(CF_CLIPBE oCF_CLIPNuevo, CF_CLIPBE oCF_CLIPAnterior, FbTransaction st)
  {
  try
  {
  int iRes = ExisteF_CLIP(oCF_CLIPAnterior, st);
  if (iRes == 0)
  {
  this.IComentario = "El F_CLIP no existe";
  return false;
  }
  else if (iRes == -1)
  {
  return false;
  }
  return CambiarF_CLIPD( oCF_CLIPNuevo,  oCF_CLIPAnterior,  st);
  }
  catch (Exception e)
  {
  this.iComentario = e.Message + e.StackTrace;
  return false;
  }

  }





  public CF_CLIPD()
  {
  this.sCadenaConexion=ConexionBD.ConexionString();
  //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


  //
  // TODO: Add constructor logic here
  //
  }
  }
  }
