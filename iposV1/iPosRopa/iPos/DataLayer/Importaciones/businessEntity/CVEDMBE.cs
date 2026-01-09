
using System;
using System.Collections;

namespace iPosBusinessEntity
{
	public class CVEDMBE
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

 	private decimal iCANTIDAD;
        public decimal ICANTIDAD
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

 	private decimal iREQUERIDO;
        public decimal IREQUERIDO
        { 
        	get
        	{
         		return this.iREQUERIDO;
        	}
        	set
        	{
        		this.iREQUERIDO= value;
        		this.isnull["IREQUERIDO"]=false;
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

 	private string iVENDEDOR;
        public string IVENDEDOR
        { 
        	get
        	{
         		return this.iVENDEDOR;
        	}
        	set
        	{
        		this.iVENDEDOR= value;
        		this.isnull["IVENDEDOR"]=false;
        	}
        }

 	private string iTIPO;
        public string ITIPO
        { 
        	get
        	{
         		return this.iTIPO;
        	}
        	set
        	{
        		this.iTIPO= value;
        		this.isnull["ITIPO"]=false;
        	}
        }

 	private string iCLASIFICA;
        public string ICLASIFICA
        { 
        	get
        	{
         		return this.iCLASIFICA;
        	}
        	set
        	{
        		this.iCLASIFICA= value;
        		this.isnull["ICLASIFICA"]=false;
        	}
        }

 	private string iSERIE;
        public string ISERIE
        { 
        	get
        	{
         		return this.iSERIE;
        	}
        	set
        	{
        		this.iSERIE= value;
        		this.isnull["ISERIE"]=false;
        	}
        }

 	private decimal iPRECIO;
        public decimal IPRECIO
        { 
        	get
        	{
         		return this.iPRECIO;
        	}
        	set
        	{
        		this.iPRECIO= value;
        		this.isnull["IPRECIO"]=false;
        	}
        }

 	private decimal iPREC_LISTA;
        public decimal IPREC_LISTA
        { 
        	get
        	{
         		return this.iPREC_LISTA;
        	}
        	set
        	{
        		this.iPREC_LISTA= value;
        		this.isnull["IPREC_LISTA"]=false;
        	}
        }

 	private decimal iPRECIOUS;
        public decimal IPRECIOUS
        { 
        	get
        	{
         		return this.iPRECIOUS;
        	}
        	set
        	{
        		this.iPRECIOUS= value;
        		this.isnull["IPRECIOUS"]=false;
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

 	private decimal iIMPORTE;
        public decimal IIMPORTE
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

 	private decimal iIMPORTNETO;
        public decimal IIMPORTNETO
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

 	private decimal iCARGOS_U;
        public decimal ICARGOS_U
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

 	private decimal iCOSTO_PU;
        public decimal ICOSTO_PU
        { 
        	get
        	{
         		return this.iCOSTO_PU;
        	}
        	set
        	{
        		this.iCOSTO_PU= value;
        		this.isnull["ICOSTO_PU"]=false;
        	}
        }

 	private decimal iMIN1;
        public decimal IMIN1
        { 
        	get
        	{
         		return this.iMIN1;
        	}
        	set
        	{
        		this.iMIN1= value;
        		this.isnull["IMIN1"]=false;
        	}
        }

 	private decimal iMAX1;
        public decimal IMAX1
        { 
        	get
        	{
         		return this.iMAX1;
        	}
        	set
        	{
        		this.iMAX1= value;
        		this.isnull["IMAX1"]=false;
        	}
        }

 	private decimal iTIENDA;
        public decimal ITIENDA
        { 
        	get
        	{
         		return this.iTIENDA;
        	}
        	set
        	{
        		this.iTIENDA= value;
        		this.isnull["ITIENDA"]=false;
        	}
        }

 	private decimal iCOSTOTAL;
        public decimal ICOSTOTAL
        { 
        	get
        	{
         		return this.iCOSTOTAL;
        	}
        	set
        	{
        		this.iCOSTOTAL= value;
        		this.isnull["ICOSTOTAL"]=false;
        	}
        }

 	private decimal iIMPORTEUS;
        public decimal IIMPORTEUS
        { 
        	get
        	{
         		return this.iIMPORTEUS;
        	}
        	set
        	{
        		this.iIMPORTEUS= value;
        		this.isnull["IIMPORTEUS"]=false;
        	}
        }

 	private decimal iCOSTOTOTUS;
        public decimal ICOSTOTOTUS
        { 
        	get
        	{
         		return this.iCOSTOTOTUS;
        	}
        	set
        	{
        		this.iCOSTOTOTUS= value;
        		this.isnull["ICOSTOTOTUS"]=false;
        	}
        }

 	private decimal iPIEZAS;
        public decimal IPIEZAS
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

 	private decimal iDESCUENTO;
        public decimal IDESCUENTO
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

 	private decimal iCOMISION;
        public decimal ICOMISION
        { 
        	get
        	{
         		return this.iCOMISION;
        	}
        	set
        	{
        		this.iCOMISION= value;
        		this.isnull["ICOMISION"]=false;
        	}
        }

 	private string iPAGADO;
        public string IPAGADO
        { 
        	get
        	{
         		return this.iPAGADO;
        	}
        	set
        	{
        		this.iPAGADO= value;
        		this.isnull["IPAGADO"]=false;
        	}
        }

 	private string iORIGEN;
        public string IORIGEN
        { 
        	get
        	{
         		return this.iORIGEN;
        	}
        	set
        	{
        		this.iORIGEN= value;
        		this.isnull["IORIGEN"]=false;
        	}
        }

 	private decimal iSURTIDO;
        public decimal ISURTIDO
        { 
        	get
        	{
         		return this.iSURTIDO;
        	}
        	set
        	{
        		this.iSURTIDO= value;
        		this.isnull["ISURTIDO"]=false;
        	}
        }

 	private string iLOC;
        public string ILOC
        { 
        	get
        	{
         		return this.iLOC;
        	}
        	set
        	{
        		this.iLOC= value;
        		this.isnull["ILOC"]=false;
        	}
        }

 	private decimal iDEVUELTAS;
        public decimal IDEVUELTAS
        { 
        	get
        	{
         		return this.iDEVUELTAS;
        	}
        	set
        	{
        		this.iDEVUELTAS= value;
        		this.isnull["IDEVUELTAS"]=false;
        	}
        }

 	private decimal iPARTIDA;
        public decimal IPARTIDA
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

 	private decimal iTRANSA;
        public decimal ITRANSA
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

 	private decimal iTRANS_LOTE;
        public decimal ITRANS_LOTE
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

 	private string iEXPORTADO;
        public string IEXPORTADO
        { 
        	get
        	{
         		return this.iEXPORTADO;
        	}
        	set
        	{
        		this.iEXPORTADO= value;
        		this.isnull["IEXPORTADO"]=false;
        	}
        }

 	private decimal iSURTIR;
        public decimal ISURTIR
        { 
        	get
        	{
         		return this.iSURTIR;
        	}
        	set
        	{
        		this.iSURTIR= value;
        		this.isnull["ISURTIR"]=false;
        	}
        }

 	private short iEXPORTTADC;
        public short IEXPORTTADC
        { 
        	get
        	{
         		return this.iEXPORTTADC;
        	}
        	set
        	{
        		this.iEXPORTTADC= value;
        		this.isnull["IEXPORTTADC"]=false;
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

 	private string iPOLITICA;
        public string IPOLITICA
        { 
        	get
        	{
         		return this.iPOLITICA;
        	}
        	set
        	{
        		this.iPOLITICA= value;
        		this.isnull["IPOLITICA"]=false;
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

 	private string iPROMOCION;
        public string IPROMOCION
        { 
        	get
        	{
         		return this.iPROMOCION;
        	}
        	set
        	{
        		this.iPROMOCION= value;
        		this.isnull["IPROMOCION"]=false;
        	}
        }

 	private string iMOVIMIENTO;
        public string IMOVIMIENTO
        { 
        	get
        	{
         		return this.iMOVIMIENTO;
        	}
        	set
        	{
        		this.iMOVIMIENTO= value;
        		this.isnull["IMOVIMIENTO"]=false;
        	}
        }

 	private string iDESC2;
        public string IDESC2
        { 
        	get
        	{
         		return this.iDESC2;
        	}
        	set
        	{
        		this.iDESC2= value;
        		this.isnull["IDESC2"]=false;
        	}
        }

 	private decimal iPIEZA;
        public decimal IPIEZA
        { 
        	get
        	{
         		return this.iPIEZA;
        	}
        	set
        	{
        		this.iPIEZA= value;
        		this.isnull["IPIEZA"]=false;
        	}
        }

 	private decimal iCAJAS;
        public decimal ICAJAS
        { 
        	get
        	{
         		return this.iCAJAS;
        	}
        	set
        	{
        		this.iCAJAS= value;
        		this.isnull["ICAJAS"]=false;
        	}
        }

 	private string iPREC_MAYO;
        public string IPREC_MAYO
        { 
        	get
        	{
         		return this.iPREC_MAYO;
        	}
        	set
        	{
        		this.iPREC_MAYO= value;
        		this.isnull["IPREC_MAYO"]=false;
        	}
        }
		
               public CVEDMBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IVENTA",true);
	

			isnull.Add("ICLIENTE",true);
	

			isnull.Add("ICANTIDAD",true);
	

			isnull.Add("IPRODUCTO",true);
	

			isnull.Add("IREQUERIDO",true);
	

			isnull.Add("IPROVEEDOR",true);
	

			isnull.Add("ILINEA",true);
	

			isnull.Add("IMARCA",true);
	

			isnull.Add("IVENDEDOR",true);
	

			isnull.Add("ITIPO",true);
	

			isnull.Add("ICLASIFICA",true);
	

			isnull.Add("ISERIE",true);
	

			isnull.Add("IPRECIO",true);
	

			isnull.Add("IPREC_LISTA",true);
	

			isnull.Add("IPRECIOUS",true);
	

			isnull.Add("IFECHA",true);
	

			isnull.Add("IESTATUS",true);
	

			isnull.Add("IIMPORTE",true);
	

			isnull.Add("IIMPORTNETO",true);
	

			isnull.Add("ICARGOS_U",true);
	

			isnull.Add("ICOSTO_PU",true);
	

			isnull.Add("IMIN1",true);
	

			isnull.Add("IMAX1",true);
	

			isnull.Add("ITIENDA",true);
	

			isnull.Add("ICOSTOTAL",true);
	

			isnull.Add("IIMPORTEUS",true);
	

			isnull.Add("ICOSTOTOTUS",true);
	

			isnull.Add("IPIEZAS",true);
	

			isnull.Add("IDESCUENTO",true);
	

			isnull.Add("ICOMISION",true);
	

			isnull.Add("IPAGADO",true);
	

			isnull.Add("IORIGEN",true);
	

			isnull.Add("ISURTIDO",true);
	

			isnull.Add("ILOC",true);
	

			isnull.Add("IDEVUELTAS",true);
	

			isnull.Add("IPARTIDA",true);
	

			isnull.Add("ITRANSA",true);
	

			isnull.Add("ITRANS_LOTE",true);
	

			isnull.Add("IEXPORTADO",true);
	

			isnull.Add("ISURTIR",true);
	

			isnull.Add("IEXPORTTADC",true);
	

			isnull.Add("IMONEDA",true);
	

			isnull.Add("IPOLITICA",true);
	

			isnull.Add("IID",true);
	

			isnull.Add("IID_FECHA",true);
	

			isnull.Add("IID_HORA",true);
	

			isnull.Add("IPROMOCION",true);
	

			isnull.Add("IMOVIMIENTO",true);
	

			isnull.Add("IDESC2",true);
	

			isnull.Add("IPIEZA",true);
	

			isnull.Add("ICAJAS",true);
	

			isnull.Add("IPREC_MAYO",true);
	
		}

		

	}
}
