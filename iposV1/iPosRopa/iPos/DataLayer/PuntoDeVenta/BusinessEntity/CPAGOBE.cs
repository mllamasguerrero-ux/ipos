
using System;
using System.Collections;

namespace iPosBusinessEntity
{
	public class CPAGOBE
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

 	private string iESAPARTADO;
        public string IESAPARTADO
        { 
        	get
        	{
         		return this.iESAPARTADO;
        	}
        	set
        	{
        		this.iESAPARTADO= value;
        		this.isnull["IESAPARTADO"]=false;
        	}
        }

 	private long iTIPOAPLICACIONCREDITOID;
        public long ITIPOAPLICACIONCREDITOID
        { 
        	get
        	{
         		return this.iTIPOAPLICACIONCREDITOID;
        	}
        	set
        	{
        		this.iTIPOAPLICACIONCREDITOID= value;
        		this.isnull["ITIPOAPLICACIONCREDITOID"]=false;
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

 	private string iESPAGOINICIAL;
        public string IESPAGOINICIAL
        { 
        	get
        	{
         		return this.iESPAGOINICIAL;
        	}
        	set
        	{
        		this.iESPAGOINICIAL= value;
        		this.isnull["IESPAGOINICIAL"]=false;
        	}
        }

 	private long iTIPOABONOID;
        public long ITIPOABONOID
        { 
        	get
        	{
         		return this.iTIPOABONOID;
        	}
        	set
        	{
        		this.iTIPOABONOID= value;
        		this.isnull["ITIPOABONOID"]=false;
        	}
        }

 	private long iPAGOREFID;
        public long IPAGOREFID
        { 
        	get
        	{
         		return this.iPAGOREFID;
        	}
        	set
        	{
        		this.iPAGOREFID= value;
        		this.isnull["IPAGOREFID"]=false;
        	}
        }

 	private string iREVERTIDO;
        public string IREVERTIDO
        { 
        	get
        	{
         		return this.iREVERTIDO;
        	}
        	set
        	{
        		this.iREVERTIDO= value;
        		this.isnull["IREVERTIDO"]=false;
        	}
        }

 	private long iCORTETRANSCANCELADA;
        public long ICORTETRANSCANCELADA
        { 
        	get
        	{
         		return this.iCORTETRANSCANCELADA;
        	}
        	set
        	{
        		this.iCORTETRANSCANCELADA= value;
        		this.isnull["ICORTETRANSCANCELADA"]=false;
        	}
        }

 	private long iFORMAPAGOSATID;
        public long IFORMAPAGOSATID
        { 
        	get
        	{
         		return this.iFORMAPAGOSATID;
        	}
        	set
        	{
        		this.iFORMAPAGOSATID= value;
        		this.isnull["IFORMAPAGOSATID"]=false;
        	}
        }

 	private long iFACTCONSID;
        public long IFACTCONSID
        { 
        	get
        	{
         		return this.iFACTCONSID;
        	}
        	set
        	{
        		this.iFACTCONSID= value;
        		this.isnull["IFACTCONSID"]=false;
        	}
        }

 	private long iRECIBOELECTRONICOID;
        public long IRECIBOELECTRONICOID
        { 
        	get
        	{
         		return this.iRECIBOELECTRONICOID;
        	}
        	set
        	{
        		this.iRECIBOELECTRONICOID= value;
        		this.isnull["IRECIBOELECTRONICOID"]=false;
        	}
        }

 	private string iCUENTAPAGOCREDITO;
        public string ICUENTAPAGOCREDITO
        { 
        	get
        	{
         		return this.iCUENTAPAGOCREDITO;
        	}
        	set
        	{
        		this.iCUENTAPAGOCREDITO= value;
        		this.isnull["ICUENTAPAGOCREDITO"]=false;
        	}
        }

 	private long iBANCOMERPARAMID;
        public long IBANCOMERPARAMID
        { 
        	get
        	{
         		return this.iBANCOMERPARAMID;
        	}
        	set
        	{
        		this.iBANCOMERPARAMID= value;
        		this.isnull["IBANCOMERPARAMID"]=false;
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

 	private long iPAGODOCTOSATID;
        public long IPAGODOCTOSATID
        { 
        	get
        	{
         		return this.iPAGODOCTOSATID;
        	}
        	set
        	{
        		this.iPAGODOCTOSATID= value;
        		this.isnull["IPAGODOCTOSATID"]=false;
        	}
        }


        private long iCUENTABANCOEMPRESAID;
        public long ICUENTABANCOEMPRESAID
        {
            get
            {
                return this.iCUENTABANCOEMPRESAID;
            }
            set
            {
                this.iCUENTABANCOEMPRESAID = value;
                this.isnull["ICUENTABANCOEMPRESAID"] = false;
            }
        }

        private long iPERSONAID;
        public long IPERSONAID
        {
            get
            {
                return iPERSONAID;
            }
            set
            {
                iPERSONAID = value;
                isnull["IPERSONAID"] = false;
            }
        }



        private string iAPLICADO;
        public string IAPLICADO
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


        private DateTime iFECHAAPLICADO;
        public DateTime IFECHAAPLICADO
        {
            get
            {
                return this.iFECHAAPLICADO;
            }
            set
            {
                this.iFECHAAPLICADO = value;
                this.isnull["IFECHAAPLICADO"] = false;
            }
        }


        private long iSUBTIPOPAGOID;
        public long ISUBTIPOPAGOID
        {
            get
            {
                return iSUBTIPOPAGOID;
            }
            set
            {
                iSUBTIPOPAGOID = value;
                isnull["ISUBTIPOPAGOID"] = false;
            }
        }



        private long iMOTIVO_CAMFEC_ID;
        public long IMOTIVO_CAMFEC_ID
        {
            get
            {
                return iMOTIVO_CAMFEC_ID;
            }
            set
            {
                iMOTIVO_CAMFEC_ID = value;
                isnull["IMOTIVO_CAMFEC_ID"] = false;
            }
        }




        private string iDEVUELTO;
        public string IDEVUELTO
        {
            get
            {
                return this.iDEVUELTO;
            }
            set
            {
                this.iDEVUELTO = value;
                this.isnull["IDEVUELTO"] = false;
            }
        }


        private DateTime iFECHAPROCESADO;
        public DateTime IFECHAPROCESADO
        {
            get
            {
                return this.iFECHAPROCESADO;
            }
            set
            {
                this.iFECHAPROCESADO = value;
                this.isnull["IFECHAPROCESADO"] = false;
            }
        }


        private long iDOCTODEVID;
        public long IDOCTODEVID
        {
            get
            {
                return iDOCTODEVID;
            }
            set
            {
                iDOCTODEVID = value;
                isnull["IDOCTODEVID"] = false;
            }
        }

        private DateTime iFECHADEVUELTO;
        public DateTime IFECHADEVUELTO
        {
            get
            {
                return this.iFECHADEVUELTO;
            }
            set
            {
                this.iFECHADEVUELTO = value;
                this.isnull["IFECHADEVUELTO"] = false;
            }
        }


        private string iREFINTERNO;
        public string IREFINTERNO
        {
            get
            {
                return this.iREFINTERNO;
            }
            set
            {
                this.iREFINTERNO = value;
                this.isnull["IREFINTERNO"] = false;
            }
        }


        private long iVERIFONEPAYMENTID;
        public long IVERIFONEPAYMENTID
        {
            get
            {
                return this.iVERIFONEPAYMENTID;
            }
            set
            {
                this.iVERIFONEPAYMENTID = value;
                this.isnull["IVERIFONEPAYMENTID"] = false;
            }
        }
        public CPAGOBE()
		{
            isnull =new Hashtable();
	

			isnull.Add("IID",true);
	

			isnull.Add("IACTIVO",true);
	

			isnull.Add("ICREADO",true);
	

			isnull.Add("ICREADOPOR_USERID",true);
	

			isnull.Add("IMODIFICADO",true);
	

			isnull.Add("IMODIFICADOPOR_USERID",true);
	

			isnull.Add("IFORMAPAGOID",true);
	

			isnull.Add("IFECHA",true);
	

			isnull.Add("IFECHAHORA",true);
	

			isnull.Add("ICORTEID",true);
	

			isnull.Add("IIMPORTE",true);
	

			isnull.Add("IIMPORTERECIBIDO",true);
	

			isnull.Add("IIMPORTECAMBIO",true);
	

			isnull.Add("ITIPOPAGOID",true);
	

			isnull.Add("IESAPARTADO",true);
	

			isnull.Add("ITIPOAPLICACIONCREDITOID",true);
	

			isnull.Add("IBANCO",true);
	

			isnull.Add("IREFERENCIABANCARIA",true);
	

			isnull.Add("INOTAS",true);
	

			isnull.Add("IFECHAELABORACION",true);
	

			isnull.Add("IFECHARECEPCION",true);
	

			isnull.Add("IESPAGOINICIAL",true);
	

			isnull.Add("ITIPOABONOID",true);
	

			isnull.Add("IPAGOREFID",true);
	

			isnull.Add("IREVERTIDO",true);
	

			isnull.Add("ICORTETRANSCANCELADA",true);
	

			isnull.Add("IFORMAPAGOSATID",true);
	

			isnull.Add("IFACTCONSID",true);
	

			isnull.Add("IRECIBOELECTRONICOID",true);
	

			isnull.Add("ICUENTAPAGOCREDITO",true);
	

			isnull.Add("IBANCOMERPARAMID",true);
	

			isnull.Add("ICOMISION",true);
	

			isnull.Add("IPAGODOCTOSATID",true);

            isnull.Add("ICUENTABANCOEMPRESAID", true);

            isnull.Add("IPERSONAID", true);

            isnull.Add("IAPLICADO", true);
            isnull.Add("IFECHAAPLICADO", true);

            isnull.Add("ISUBTIPOPAGOID", true);

            isnull.Add("IMOTIVO_CAMFEC_ID", true);

            isnull.Add("IDEVUELTO", true);
            isnull.Add("IFECHAPROCESADO", true);
            isnull.Add("IDOCTODEVID", true);

            isnull.Add("IFECHADEVUELTO", true);

            isnull.Add("IREFINTERNO", true);

            isnull.Add("IVERIFONEPAYMENTID", true);

            
        }
	}
}
