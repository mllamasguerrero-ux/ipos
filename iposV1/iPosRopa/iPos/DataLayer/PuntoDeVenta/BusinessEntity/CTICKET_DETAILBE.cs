
using System;
using System.Collections;
namespace iPosBusinessEntity
{
	public class CTICKET_DETAILBE
	{
	public Hashtable isnull;

 	private long iDOCTOID;
        public long IDOCTOID
        { 
        	get
        	{
         		return this.iDOCTOID;
        	}
        	set
        	{
        		this.iDOCTOID= value;
        		this.isnull["IDOCTOID"]=false;
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

        private decimal iFALTANTE;
        public decimal IFALTANTE
        {
            get
            {
                return this.iFALTANTE;
            }
            set
            {
                this.iFALTANTE = value;
                this.isnull["IFALTANTE"] = false;
            }
        }

 	private string iDESCRIPCION1;
        public string IDESCRIPCION1
        { 
        	get
        	{
         		return this.iDESCRIPCION1;
        	}
        	set
        	{
        		this.iDESCRIPCION1= value;
        		this.isnull["IDESCRIPCION1"]=false;
        	}
        }

 	private string iDESCRIPCION2;
        public string IDESCRIPCION2
        { 
        	get
        	{
         		return this.iDESCRIPCION2;
        	}
        	set
        	{
        		this.iDESCRIPCION2= value;
        		this.isnull["IDESCRIPCION2"]=false;
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

 	private decimal iSUBTOTAL;
        public decimal ISUBTOTAL
        { 
        	get
        	{
         		return this.iSUBTOTAL;
        	}
        	set
        	{
        		this.iSUBTOTAL= value;
        		this.isnull["ISUBTOTAL"]=false;
        	}
        }

 	private decimal iIVA;
        public decimal IIVA
        { 
        	get
        	{
         		return this.iIVA;
        	}
        	set
        	{
        		this.iIVA= value;
        		this.isnull["IIVA"]=false;
        	}
        }

 	private decimal iTOTAL;
        public decimal ITOTAL
        { 
        	get
        	{
         		return this.iTOTAL;
        	}
        	set
        	{
        		this.iTOTAL= value;
        		this.isnull["ITOTAL"]=false;
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

 	private DateTime iFECHAVENCE;
        public DateTime IFECHAVENCE
        { 
        	get
        	{
         		return this.iFECHAVENCE;
        	}
        	set
        	{
        		this.iFECHAVENCE= value;
        		this.isnull["IFECHAVENCE"]=false;
        	}
        }


        private decimal iCANTIDADSURTIDA;
        public decimal ICANTIDADSURTIDA
        {
            get
            {
                return this.iCANTIDADSURTIDA;
            }
            set
            {
                this.iCANTIDADSURTIDA = value;
                this.isnull["ICANTIDADSURTIDA"] = false;
            }
        }
            
        private decimal iCANTIDADNOMINAL;
        public decimal ICANTIDADNOMINAL
        {
            get
            {
                return this.iCANTIDADNOMINAL;
            }
            set
            {
                this.iCANTIDADNOMINAL = value;
                this.isnull["ICANTIDADNOMINAL"] = false;
            }
        }


        private decimal iIMPORTEDESCUENTO;
        public decimal IIMPORTEDESCUENTO
        {
            get
            {
                return this.iIMPORTEDESCUENTO;
            }
            set
            {
                this.iIMPORTEDESCUENTO = value;
                this.isnull["IIMPORTEDESCUENTO"] = false;
            }
        }



        private decimal iIMPORTEIVA;
        public decimal IIMPORTEIVA
        {
            get
            {
                return this.iIMPORTEIVA;
            }
            set
            {
                this.iIMPORTEIVA = value;
                this.isnull["IIMPORTEIVA"] = false;
            }
        }


        private decimal iDESCUENTOVALE;
        public decimal IDESCUENTOVALE
        {
            get
            {
                return this.iDESCUENTOVALE;
            }
            set
            {
                this.iDESCUENTOVALE = value;
                this.isnull["IDESCUENTOVALE"] = false;
            }
        }


        private string iTIPORECARGA;
        public string ITIPORECARGA
        {
            get
            {
                return this.iTIPORECARGA;
            }
            set
            {
                this.iTIPORECARGA = value;
                this.isnull["ITIPORECARGA"] = false;
            }
        }


        private decimal iPRECIOCONIVA;
        public decimal IPRECIOCONIVA
        {
            get
            {
                return this.iPRECIOCONIVA;
            }
            set
            {
                this.iPRECIOCONIVA = value;
                this.isnull["IPRECIOCONIVA"] = false;
            }
        }

        private string iDESCRIPCION3;
        public string IDESCRIPCION3
        {
            get
            {
                return this.iDESCRIPCION3;
            }
            set
            {
                this.iDESCRIPCION3 = value;
                this.isnull["IDESCRIPCION3"] = false;
            }
        }


        private string iES_COMODIN;
        public string IES_COMODIN
        {
            get
            {
                return this.iES_COMODIN;
            }
            set
            {
                this.iES_COMODIN = value;
                this.isnull["IES_COMODIN"] = false;
            }
        }



        private decimal iTASAIEPS;
        public decimal ITASAIEPS
        {
            get
            {
                return this.iTASAIEPS;
            }
            set
            {
                this.iTASAIEPS = value;
                this.isnull["ITASAIEPS"] = false;
            }
        }


        private string iESKIT;
        public string IESKIT
        {
            get
            {
                return this.iESKIT;
            }
            set
            {
                this.iESKIT = value;
                this.isnull["IESKIT"] = false;
            }
        }



        //private string iESPARTEKIT;
        //public string IESPARTEKIT
        //{
        //    get
        //    {
        //        return this.iESPARTEKIT;
        //    }
        //    set
        //    {
        //        this.iESPARTEKIT = value;
        //        this.isnull["IESPARTEKIT"] = false;
        //    }
        //}



        private string iMOTIVODEVOLUCION;
        public string IMOTIVODEVOLUCION
        {
            get
            {
                return this.iMOTIVODEVOLUCION;
            }
            set
            {
                this.iMOTIVODEVOLUCION = value;
                this.isnull["IMOTIVODEVOLUCION"] = false;
            }
        }


        private long iMOVTOID;
        public long IMOVTOID
        {
            get
            {
                return this.iMOVTOID;
            }
            set
            {
                this.iMOVTOID = value;
                this.isnull["IMOVTOID"] = false;
            }
        }



        private long iEMIDAREQUESTID;
        public long IEMIDAREQUESTID
        {
            get
            {
                return this.iEMIDAREQUESTID;
            }
            set
            {
                this.iEMIDAREQUESTID = value;
                this.isnull["IEMIDAREQUESTID"] = false;
            }
        }



        private decimal iEMIDACOMISION;
        public decimal IEMIDACOMISION
        {
            get
            {
                return this.iEMIDACOMISION;
            }
            set
            {
                this.iEMIDACOMISION = value;
                this.isnull["IEMIDACOMISION"] = false;
            }
        }



        

        private string iSTRPEDIMENTO;
        public string ISTRPEDIMENTO
        {
            get
            {
                return this.iSTRPEDIMENTO;
            }
            set
            {
                this.iSTRPEDIMENTO = value;
                this.isnull["ISTRPEDIMENTO"] = false;
            }
        }

        

        private long iKITMOVTOID;
        public long IKITMOVTOID
        {
            get
            {
                return this.iKITMOVTOID;
            }
            set
            {
                this.iKITMOVTOID = value;
                this.isnull["IKITMOVTOID"] = false;
            }
        }

        

        private long iKITPRODUCTOID;
        public long IKITPRODUCTOID
        {
            get
            {
                return this.iKITPRODUCTOID;
            }
            set
            {
                this.iKITPRODUCTOID = value;
                this.isnull["IKITPRODUCTOID"] = false;
            }
        }

        
        private string iKITPRODCLAVE;
        public string IKITPRODCLAVE
        {
            get
            {
                return this.iKITPRODCLAVE;
            }
            set
            {
                this.iKITPRODCLAVE = value;
                this.isnull["IKITPRODCLAVE"] = false;
            }
        }

        
        private string iKITPRODNOMBRE;
        public string IKITPRODNOMBRE
        {
            get
            {
                return this.iKITPRODNOMBRE;
            }
            set
            {
                this.iKITPRODNOMBRE = value;
                this.isnull["IKITPRODNOMBRE"] = false;
            }
        }


        
        private string iKITPRODDESCRIPCION1;
        public string IKITPRODDESCRIPCION1
        {
            get
            {
                return this.iKITPRODDESCRIPCION1;
            }
            set
            {
                this.iKITPRODDESCRIPCION1 = value;
                this.isnull["IKITPRODDESCRIPCION1"] = false;
            }
        }

        

        private decimal iKITCANTIDAD;
        public decimal IKITCANTIDAD
        {
            get
            {
                return this.iKITCANTIDAD;
            }
            set
            {
                this.iKITCANTIDAD = value;
                this.isnull["IKITCANTIDAD"] = false;
            }
        }


        private decimal iCOSTOENDOLAR;
        public decimal ICOSTOENDOLAR
        {
            get
            {
                return this.iCOSTOENDOLAR;
            }
            set
            {
                this.iCOSTOENDOLAR = value;
                this.isnull["ICOSTOENDOLAR"] = false;
            }
        }


        private decimal iIMPORTEENDOLAR;
        public decimal IIMPORTEENDOLAR
        {
            get
            {
                return this.iIMPORTEENDOLAR;
            }
            set
            {
                this.iIMPORTEENDOLAR = value;
                this.isnull["IIMPORTEENDOLAR"] = false;
            }
        }



        //private long iLOTEIMPORTADO;
        //public long ILOTEIMPORTADO
        //{
        //    get
        //    {
        //        return this.iLOTEIMPORTADO;
        //    }
        //    set
        //    {
        //        this.iLOTEIMPORTADO = value;
        //        this.isnull["ILOTEIMPORTADO"] = false;
        //    }
        //}

        //private string iPEDIMENTO;
        //public string IPEDIMENTO
        //{
        //    get
        //    {
        //        return this.iPEDIMENTO;
        //    }
        //    set
        //    {
        //        this.iPEDIMENTO = value;
        //        this.isnull["IPEDIMENTO"] = false;
        //    }
        //}



        //private DateTime iFECHAIMPORTACION;
        //public DateTime IFECHAIMPORTACION
        //{
        //    get
        //    {
        //        return this.iFECHAIMPORTACION;
        //    }
        //    set
        //    {
        //        this.iFECHAIMPORTACION = value;
        //        this.isnull["IFECHAIMPORTACION"] = false;
        //    }
        //}


        //private string iADUANA;
        //public string IADUANA
        //{
        //    get
        //    {
        //        return this.iADUANA;
        //    }
        //    set
        //    {
        //        this.iADUANA = value;
        //        this.isnull["IADUANA"] = false;
        //    }
        //}


        //private decimal iTIPOCAMBIOIMPO;
        //public decimal ITIPOCAMBIOIMPO
        //{
        //    get
        //    {
        //        return this.iTIPOCAMBIOIMPO;
        //    }
        //    set
        //    {
        //        this.iTIPOCAMBIOIMPO = value;
        //        this.isnull["ITIPOCAMBIOIMPO"] = false;
        //    }
        //}


        private string iDESCPZACAJA;
        public string IDESCPZACAJA
        {
            get
            {
                return this.iDESCPZACAJA;
            }
            set
            {
                this.iDESCPZACAJA = value;
                this.isnull["IDESCPZACAJA"] = false;
            }
        }



        private decimal iKILOGRAMOS;
        public decimal IKILOGRAMOS
        {
            get
            {
                return this.iKILOGRAMOS;
            }
            set
            {
                this.iKILOGRAMOS = value;
                this.isnull["IKILOGRAMOS"] = false;
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
                this.iCAJAS = value;
                this.isnull["ICAJAS"] = false;
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
                this.iPIEZAS = value;
                this.isnull["IPIEZAS"] = false;
            }
        }



        private string iPRODUCTOCLAVE;
        public string IPRODUCTOCLAVE
        {
            get
            {
                return this.iPRODUCTOCLAVE;
            }
            set
            {
                this.iPRODUCTOCLAVE = value;
                this.isnull["IPRODUCTOCLAVE"] = false;
            }
        }



        private string iPLAZOCLAVE;
        public string IPLAZOCLAVE
        {
            get
            {
                return this.iPLAZOCLAVE;
            }
            set
            {
                this.iPLAZOCLAVE = value;
                this.isnull["IPLAZOCLAVE"] = false;
            }
        }



        private string iEAN;
        public string IEAN
        {
            get
            {
                return this.iEAN;
            }
            set
            {
                this.iEAN = value;
                this.isnull["IEAN"] = false;
            }
        }


        public CTICKET_DETAILBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IDOCTOID",true);


            isnull.Add("ICANTIDAD", true);

            isnull.Add("IFALTANTE", true);
	

			isnull.Add("IDESCRIPCION1",true);
	

			isnull.Add("IDESCRIPCION2",true);
	

			isnull.Add("IPRECIO",true);
	

			isnull.Add("IDESCUENTO",true);
	

			isnull.Add("ISUBTOTAL",true);
	

			isnull.Add("IIVA",true);
	

			isnull.Add("ITOTAL",true);
	

			isnull.Add("ILOTE",true);


            isnull.Add("IFECHAVENCE", true);


            isnull.Add("ICANTIDADSURTIDA", true);

    
            isnull.Add("ICANTIDADNOMINAL", true);


            isnull.Add("IIMPORTEDESCUENTO", true);

           
            isnull.Add("IIMPORTEIVA", true);

            isnull.Add("IDESCUENTOVALE", true);

            isnull.Add("ITIPORECARGA", true);

            isnull.Add("IPRECIOCONIVA", true);

            isnull.Add("IDESCRIPCION3", true);

            isnull.Add("IES_COMODIN", true);

            isnull.Add("ITASAIEPS", true);

            isnull.Add("IESKIT", true);

            //isnull.Add("IESPARTEKIT", true);

            isnull.Add("IMOTIVODEVOLUCION", true);

            isnull.Add("IMOVTOID", true);

            isnull.Add("IEMIDAREQUESTID", true);


            isnull.Add("IEMIDACOMISION", true);


            //isnull.Add("ILOTEIMPORTADO", true);
            //isnull.Add("IPEDIMENTO", true);
            //isnull.Add("IFECHAIMPORTACION", true);
            //isnull.Add("IADUANA", true);
            //isnull.Add("ITIPOCAMBIOIMPO", true);


            
            isnull.Add("ISTRPEDIMENTO", true);
            isnull.Add("IKITMOVTOID", true);
            isnull.Add("IKITPRODUCTOID", true);
            isnull.Add("IKITPRODCLAVE", true);
            isnull.Add("IKITPRODNOMBRE", true);
            isnull.Add("IKITPRODDESCRIPCION1", true);
            isnull.Add("IKITCANTIDAD", true);


            isnull.Add("ICOSTOENDOLAR", true);
            isnull.Add("IIMPORTEENDOLAR", true);

            isnull.Add("IDESCPZACAJA", true);


            isnull.Add("IKILOGRAMOS", true);

            isnull.Add("ICAJAS", true);

            isnull.Add("IPIEZAS", true);

            isnull.Add("IPRODUCTOCLAVE", true);

            isnull.Add("IPLAZOCLAVE", true);

            isnull.Add("IEAN", true);



        }

		

	}
}
