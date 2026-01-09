
using System;
using System.Collections;

namespace iPosBusinessEntity
{
	public class CRECEPCIONBE
	{
	public Hashtable isnull;

 	private string iVENTA;
        public string IVENTA
        { 
        	get
        	{
         		return this.iVENTA;
        	}
        	set
        	{
        		this.iVENTA= value;
        		this.isnull["IVENTA"]=false;
        	}
        }

 	private double iCOMPRA;
        public double ICOMPRA
        { 
        	get
        	{
         		return this.iCOMPRA;
        	}
        	set
        	{
        		this.iCOMPRA= value;
        		this.isnull["ICOMPRA"]=false;
        	}
        }

 	private string iPRODUCTO;
        public string IPRODUCTO
        { 
        	get
        	{
         		return this.iPRODUCTO;
        	}
        	set
        	{
        		this.iPRODUCTO= value;
        		this.isnull["IPRODUCTO"]=false;
        	}
        }

 	private string iDESC1;
        public string IDESC1
        { 
        	get
        	{
         		return this.iDESC1;
        	}
        	set
        	{
        		this.iDESC1= value;
        		this.isnull["IDESC1"]=false;
        	}
        }

 	private string iLINEA;
        public string ILINEA
        { 
        	get
        	{
         		return this.iLINEA;
        	}
        	set
        	{
        		this.iLINEA= value;
        		this.isnull["ILINEA"]=false;
        	}
        }

 	private string iMARCA;
        public string IMARCA
        { 
        	get
        	{
         		return this.iMARCA;
        	}
        	set
        	{
        		this.iMARCA= value;
        		this.isnull["IMARCA"]=false;
        	}
        }

 	private string iPROVEEDOR;
        public string IPROVEEDOR
        { 
        	get
        	{
         		return this.iPROVEEDOR;
        	}
        	set
        	{
        		this.iPROVEEDOR= value;
        		this.isnull["IPROVEEDOR"]=false;
        	}
        }

 	private double iCANTIDAD;
        public double ICANTIDAD
        { 
        	get
        	{
         		return this.iCANTIDAD;
        	}
        	set
        	{
        		this.iCANTIDAD= value;
        		this.isnull["ICANTIDAD"]=false;
        	}
        }

 	private double iSURTIDA;
        public double ISURTIDA
        { 
        	get
        	{
         		return this.iSURTIDA;
        	}
        	set
        	{
        		this.iSURTIDA= value;
        		this.isnull["ISURTIDA"]=false;
        	}
        }

 	private double iFALTANTE;
        public double IFALTANTE
        { 
        	get
        	{
         		return this.iFALTANTE;
        	}
        	set
        	{
        		this.iFALTANTE= value;
        		this.isnull["IFALTANTE"]=false;
        	}
        }

 	private double iCOSTO;
        public double ICOSTO
        { 
        	get
        	{
         		return this.iCOSTO;
        	}
        	set
        	{
        		this.iCOSTO= value;
        		this.isnull["ICOSTO"]=false;
        	}
        }

 	private double iCARGOS_U;
        public double ICARGOS_U
        { 
        	get
        	{
         		return this.iCARGOS_U;
        	}
        	set
        	{
        		this.iCARGOS_U= value;
        		this.isnull["ICARGOS_U"]=false;
        	}
        }

 	private double iIMPORTE;
        public double IIMPORTE
        { 
        	get
        	{
         		return this.iIMPORTE;
        	}
        	set
        	{
        		this.iIMPORTE= value;
        		this.isnull["IIMPORTE"]=false;
        	}
        }

 	private double iIMPORTNETO;
        public double IIMPORTNETO
        { 
        	get
        	{
         		return this.iIMPORTNETO;
        	}
        	set
        	{
        		this.iIMPORTNETO= value;
        		this.isnull["IIMPORTNETO"]=false;
        	}
        }

 	private DateTime iFECHA;
        public DateTime IFECHA
        { 
        	get
        	{
         		return this.iFECHA;
        	}
        	set
        	{
        		this.iFECHA= value;
        		this.isnull["IFECHA"]=false;
        	}
        }

 	private string iESTATUS;
        public string IESTATUS
        { 
        	get
        	{
         		return this.iESTATUS;
        	}
        	set
        	{
        		this.iESTATUS= value;
        		this.isnull["IESTATUS"]=false;
        	}
        }

 	private double iPIEZAS;
        public double IPIEZAS
        { 
        	get
        	{
         		return this.iPIEZAS;
        	}
        	set
        	{
        		this.iPIEZAS= value;
        		this.isnull["IPIEZAS"]=false;
        	}
        }

 	private double iPARTIDA;
        public double IPARTIDA
        { 
        	get
        	{
         		return this.iPARTIDA;
        	}
        	set
        	{
        		this.iPARTIDA= value;
        		this.isnull["IPARTIDA"]=false;
        	}
        }

 	private double iTRANSA;
        public double ITRANSA
        { 
        	get
        	{
         		return this.iTRANSA;
        	}
        	set
        	{
        		this.iTRANSA= value;
        		this.isnull["ITRANSA"]=false;
        	}
        }

 	private double iDESCUENTO;
        public double IDESCUENTO
        { 
        	get
        	{
         		return this.iDESCUENTO;
        	}
        	set
        	{
        		this.iDESCUENTO= value;
        		this.isnull["IDESCUENTO"]=false;
        	}
        }

 	private string iMONEDA;
        public string IMONEDA
        { 
        	get
        	{
         		return this.iMONEDA;
        	}
        	set
        	{
        		this.iMONEDA= value;
        		this.isnull["IMONEDA"]=false;
        	}
        }

 	private double iCOSTO_INI;
        public double ICOSTO_INI
        { 
        	get
        	{
         		return this.iCOSTO_INI;
        	}
        	set
        	{
        		this.iCOSTO_INI= value;
        		this.isnull["ICOSTO_INI"]=false;
        	}
        }

 	private string iID;
        public string IID
        { 
        	get
        	{
         		return this.iID;
        	}
        	set
        	{
        		this.iID= value;
        		this.isnull["IID"]=false;
        	}
        }

 	private DateTime iID_FECHA;
        public DateTime IID_FECHA
        { 
        	get
        	{
         		return this.iID_FECHA;
        	}
        	set
        	{
        		this.iID_FECHA= value;
        		this.isnull["IID_FECHA"]=false;
        	}
        }

 	private string iID_HORA;
        public string IID_HORA
        { 
        	get
        	{
         		return this.iID_HORA;
        	}
        	set
        	{
        		this.iID_HORA= value;
        		this.isnull["IID_HORA"]=false;
        	}
        }

 	private string iTRANS_LOTE;
        public string ITRANS_LOTE
        { 
        	get
        	{
         		return this.iTRANS_LOTE;
        	}
        	set
        	{
        		this.iTRANS_LOTE= value;
        		this.isnull["ITRANS_LOTE"]=false;
        	}
        }

 	private string iCLIENTE;
        public string ICLIENTE
        { 
        	get
        	{
         		return this.iCLIENTE;
        	}
        	set
        	{
        		this.iCLIENTE= value;
        		this.isnull["ICLIENTE"]=false;
        	}
        }

 	private string iLOTE;
        public string ILOTE
        { 
        	get
        	{
         		return this.iLOTE;
        	}
        	set
        	{
        		this.iLOTE= value;
        		this.isnull["ILOTE"]=false;
        	}
        }

 	private DateTime iF_CADUCA;
        public DateTime IF_CADUCA
        { 
        	get
        	{
         		return this.iF_CADUCA;
        	}
        	set
        	{
        		this.iF_CADUCA= value;
        		this.isnull["IF_CADUCA"]=false;
        	}
        }
		
               public CRECEPCIONBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IVENTA",true);
	

			isnull.Add("ICOMPRA",true);
	

			isnull.Add("IPRODUCTO",true);
	

			isnull.Add("IDESC1",true);
	

			isnull.Add("ILINEA",true);
	

			isnull.Add("IMARCA",true);
	

			isnull.Add("IPROVEEDOR",true);
	

			isnull.Add("ICANTIDAD",true);
	

			isnull.Add("ISURTIDA",true);
	

			isnull.Add("IFALTANTE",true);
	

			isnull.Add("ICOSTO",true);
	

			isnull.Add("ICARGOS_U",true);
	

			isnull.Add("IIMPORTE",true);
	

			isnull.Add("IIMPORTNETO",true);
	

			isnull.Add("IFECHA",true);
	

			isnull.Add("IESTATUS",true);
	

			isnull.Add("IPIEZAS",true);
	

			isnull.Add("IPARTIDA",true);
	

			isnull.Add("ITRANSA",true);
	

			isnull.Add("IDESCUENTO",true);
	

			isnull.Add("IMONEDA",true);
	

			isnull.Add("ICOSTO_INI",true);
	

			isnull.Add("IID",true);
	

			isnull.Add("IID_FECHA",true);
	

			isnull.Add("IID_HORA",true);
	

			isnull.Add("ITRANS_LOTE",true);
	

			isnull.Add("ICLIENTE",true);
	

			isnull.Add("ILOTE",true);
	

			isnull.Add("IF_CADUCA",true);
	
		}

		

	}
}
