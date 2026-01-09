using System;
using System.Collections;
using System.Collections.Generic;

namespace iPosBusinessEntity
{
	public class CPAGOMOVILBE
	{
	public Hashtable isnull;

 	private long iID;
        public long IID
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

 	private string iACTIVO;
        public string IACTIVO
        { 
        	get
        	{
         		return this.iACTIVO;
        	}
        	set
        	{
        		this.iACTIVO= value;
        		this.isnull["IACTIVO"]=false;
        	}
        }

 	private object iCREADO;
        public object ICREADO
        { 
        	get
        	{
         		return this.iCREADO;
        	}
        	set
        	{
        		this.iCREADO= value;
        		this.isnull["ICREADO"]=false;
        	}
        }

 	private long iCREADOPOR_USERID;
        public long ICREADOPOR_USERID
        { 
        	get
        	{
         		return this.iCREADOPOR_USERID;
        	}
        	set
        	{
        		this.iCREADOPOR_USERID= value;
        		this.isnull["ICREADOPOR_USERID"]=false;
        	}
        }

 	private object iMODIFICADO;
        public object IMODIFICADO
        { 
        	get
        	{
         		return this.iMODIFICADO;
        	}
        	set
        	{
        		this.iMODIFICADO= value;
        		this.isnull["IMODIFICADO"]=false;
        	}
        }

 	private long iMODIFICADOPOR_USERID;
        public long IMODIFICADOPOR_USERID
        { 
        	get
        	{
         		return this.iMODIFICADOPOR_USERID;
        	}
        	set
        	{
        		this.iMODIFICADOPOR_USERID= value;
        		this.isnull["IMODIFICADOPOR_USERID"]=false;
        	}
        }

 	private long iTIPOPAGOID;
        public long ITIPOPAGOID
        { 
        	get
        	{
         		return this.iTIPOPAGOID;
        	}
        	set
        	{
        		this.iTIPOPAGOID= value;
        		this.isnull["ITIPOPAGOID"]=false;
        	}
        }

 	private long iESTATUS;
        public long IESTATUS
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

 	private long iUSUARIOID;
        public long IUSUARIOID
        { 
        	get
        	{
         		return this.iUSUARIOID;
        	}
        	set
        	{
        		this.iUSUARIOID= value;
        		this.isnull["IUSUARIOID"]=false;
        	}
        }

 	private long iPERSONAID;
        public long IPERSONAID
        { 
        	get
        	{
         		return this.iPERSONAID;
        	}
        	set
        	{
        		this.iPERSONAID= value;
        		this.isnull["IPERSONAID"]=false;
        	}
        }

 	private long iFORMAPAGOID;
        public long IFORMAPAGOID
        { 
        	get
        	{
         		return this.iFORMAPAGOID;
        	}
        	set
        	{
        		this.iFORMAPAGOID= value;
        		this.isnull["IFORMAPAGOID"]=false;
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

 	private object iFECHAHORA;
        public object IFECHAHORA
        { 
        	get
        	{
         		return this.iFECHAHORA;
        	}
        	set
        	{
        		this.iFECHAHORA= value;
        		this.isnull["IFECHAHORA"]=false;
        	}
        }

 	private long iCORTEID;
        public long ICORTEID
        { 
        	get
        	{
         		return this.iCORTEID;
        	}
        	set
        	{
        		this.iCORTEID= value;
        		this.isnull["ICORTEID"]=false;
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

 	private decimal iIMPORTERECIBIDO;
        public decimal IIMPORTERECIBIDO
        { 
        	get
        	{
         		return this.iIMPORTERECIBIDO;
        	}
        	set
        	{
        		this.iIMPORTERECIBIDO= value;
        		this.isnull["IIMPORTERECIBIDO"]=false;
        	}
        }

 	private decimal iIMPORTECAMBIO;
        public decimal IIMPORTECAMBIO
        { 
        	get
        	{
         		return this.iIMPORTECAMBIO;
        	}
        	set
        	{
        		this.iIMPORTECAMBIO= value;
        		this.isnull["IIMPORTECAMBIO"]=false;
        	}
        }

 	private long iBANCO;
        public long IBANCO
        { 
        	get
        	{
         		return this.iBANCO;
        	}
        	set
        	{
        		this.iBANCO= value;
        		this.isnull["IBANCO"]=false;
        	}
        }

 	private string iREFERENCIABANCARIA;
        public string IREFERENCIABANCARIA
        { 
        	get
        	{
         		return this.iREFERENCIABANCARIA;
        	}
        	set
        	{
        		this.iREFERENCIABANCARIA= value;
        		this.isnull["IREFERENCIABANCARIA"]=false;
        	}
        }

 	private string iNOTAS;
        public string INOTAS
        { 
        	get
        	{
         		return this.iNOTAS;
        	}
        	set
        	{
        		this.iNOTAS= value;
        		this.isnull["INOTAS"]=false;
        	}
        }

 	private DateTime iFECHAELABORACION;
        public DateTime IFECHAELABORACION
        { 
        	get
        	{
         		return this.iFECHAELABORACION;
        	}
        	set
        	{
        		this.iFECHAELABORACION= value;
        		this.isnull["IFECHAELABORACION"]=false;
        	}
        }

 	private DateTime iFECHARECEPCION;
        public DateTime IFECHARECEPCION
        { 
        	get
        	{
         		return this.iFECHARECEPCION;
        	}
        	set
        	{
        		this.iFECHARECEPCION= value;
        		this.isnull["IFECHARECEPCION"]=false;
        	}
        }

 	private long iPAGOMOVILREFID;
        public long IPAGOMOVILREFID
        { 
        	get
        	{
         		return this.iPAGOMOVILREFID;
        	}
        	set
        	{
        		this.iPAGOMOVILREFID= value;
        		this.isnull["IPAGOMOVILREFID"]=false;
        	}
        }

 	private string iPERSONACLAVE;
        public string IPERSONACLAVE
        { 
        	get
        	{
         		return this.iPERSONACLAVE;
        	}
        	set
        	{
        		this.iPERSONACLAVE= value;
        		this.isnull["IPERSONACLAVE"]=false;
        	}
        }


        private decimal iAPLICADO;
        public decimal IAPLICADO
        {
            get
            {
                return this.iAPLICADO;
            }
            set
            {
                this.iAPLICADO = value;
                this.isnull["IAPLICADO"] = false;
            }
        }


        private string iENVIADOWS;
        public string IENVIADOWS
        {
            get
            {
                return this.iENVIADOWS;
            }
            set
            {
                this.iENVIADOWS = value;
                this.isnull["IENVIADOWS"] = false;
            }
        }


        private string iBANCOTEXT;
        public string IBANCOTEXT
        {
            get
            {
                return this.iBANCOTEXT;
            }
            set
            {
                this.iBANCOTEXT = value;
                this.isnull["IBANCOTEXT"] = false;
            }
        }


        private string iTIPOTEXT;
        public string ITIPOTEXT
        {
            get
            {
                return this.iTIPOTEXT;
            }
            set
            {
                this.iTIPOTEXT = value;
                this.isnull["ITIPOTEXT"] = false;
            }
        }




        private List<CDOCTOPAGOMOVILBE> detalles;
        public List<CDOCTOPAGOMOVILBE> Detalles
        {
            get
            {
                return this.detalles;
            }
            set
            {
                this.detalles = value;
            }
        }




        public CPAGOMOVILBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IID",true);
	

			isnull.Add("IACTIVO",true);
	

			isnull.Add("ICREADO",true);
	

			isnull.Add("ICREADOPOR_USERID",true);
	

			isnull.Add("IMODIFICADO",true);
	

			isnull.Add("IMODIFICADOPOR_USERID",true);
	

			isnull.Add("ITIPOPAGOID",true);
	

			isnull.Add("IESTATUS",true);
	

			isnull.Add("IUSUARIOID",true);
	

			isnull.Add("IPERSONAID",true);
	

			isnull.Add("IFORMAPAGOID",true);
	

			isnull.Add("IFECHA",true);
	

			isnull.Add("IFECHAHORA",true);
	

			isnull.Add("ICORTEID",true);
	

			isnull.Add("IIMPORTE",true);
	

			isnull.Add("IIMPORTERECIBIDO",true);
	

			isnull.Add("IIMPORTECAMBIO",true);
	

			isnull.Add("IBANCO",true);
	

			isnull.Add("IREFERENCIABANCARIA",true);
	

			isnull.Add("INOTAS",true);
	

			isnull.Add("IFECHAELABORACION",true);
	

			isnull.Add("IFECHARECEPCION",true);
	

			isnull.Add("IPAGOMOVILREFID",true);
	

			isnull.Add("IPERSONACLAVE",true);

            isnull.Add("IAPLICADO", true);

            isnull.Add("IENVIADOWS", true);

            isnull.Add("IBANCOTEXT", true);

            isnull.Add("ITIPOTEXT", true);
	
		}

		

	}
}
