
using System;
using System.Collections;
namespace iPosBusinessEntity
{
	public class CTICKET_FOOTERBE
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

 	private string iTOTAL_CON_LETRA;
        public string ITOTAL_CON_LETRA
        { 
        	get
        	{
         		return this.iTOTAL_CON_LETRA;
        	}
        	set
        	{
        		this.iTOTAL_CON_LETRA= value;
        		this.isnull["ITOTAL_CON_LETRA"]=false;
        	}
        }

        private decimal iDESCUENTO_TOTAL;
        public decimal IDESCUENTO_TOTAL
        {
            get
            {
                return this.iDESCUENTO_TOTAL;
            }
            set
            {
                this.iDESCUENTO_TOTAL = value;
                this.isnull["IDESCUENTO_TOTAL"] = false;
            }
        }

        private decimal iCAMBIO;
        public decimal ICAMBIO
        {
            get
            {
                return this.iCAMBIO;
            }
            set
            {
                this.iCAMBIO = value;
                this.isnull["ICAMBIO"] = false;
            }
        }

        private string iCAJA;
        public string ICAJA
        {
            get
            {
                return this.iCAJA;
            }
            set
            {
                this.iCAJA = value;
                this.isnull["ICAJA"] = false;
            }
        }

        private string iTURNO;
        public string ITURNO
        {
            get
            {
                return this.iTURNO;
            }
            set
            {
                this.iTURNO = value;
                this.isnull["ITURNO"] = false;
            }
        }


        private decimal iPAGOEFECTIVO;
        public decimal IPAGOEFECTIVO
        {
            get
            {
                return this.iPAGOEFECTIVO;
            }
            set
            {
                this.iPAGOEFECTIVO = value;
                this.isnull["IPAGOEFECTIVO"] = false;
            }
        }


        private decimal iPAGOTARJETA;
        public decimal IPAGOTARJETA
        {
            get
            {
                return this.iPAGOTARJETA;
            }
            set
            {
                this.iPAGOTARJETA = value;
                this.isnull["IPAGOTARJETA"] = false;
            }
        }


        private decimal iPAGOCREDITO;
        public decimal IPAGOCREDITO
        {
            get
            {
                return this.iPAGOCREDITO;
            }
            set
            {
                this.iPAGOCREDITO = value;
                this.isnull["IPAGOCREDITO"] = false;
            }
        }


        private decimal iPAGOCHEQUE;
        public decimal IPAGOCHEQUE
        {
            get
            {
                return this.iPAGOCHEQUE;
            }
            set
            {
                this.iPAGOCHEQUE = value;
                this.isnull["IPAGOCHEQUE"] = false;
            }
        }


        private decimal iPAGOVALE;
        public decimal IPAGOVALE
        {
            get
            {
                return this.iPAGOVALE;
            }
            set
            {
                this.iPAGOVALE = value;
                this.isnull["IPAGOVALE"] = false;
            }
        }


        private decimal iABONO;
        public decimal IABONO
        {
            get
            {
                return this.iABONO;
            }
            set
            {
                this.iABONO = value;
                this.isnull["IABONO"] = false;
            }
        }


        private decimal iSALDO;
        public decimal ISALDO
        {
            get
            {
                return this.iSALDO;
            }
            set
            {
                this.iSALDO = value;
                this.isnull["ISALDO"] = false;
            }
        }



        private decimal iPAGOMONEDERO;
        public decimal IPAGOMONEDERO
        {
            get
            {
                return this.iPAGOMONEDERO;
            }
            set
            {
                this.iPAGOMONEDERO = value;
                this.isnull["IPAGOMONEDERO"] = false;
            }
        }


        private decimal iABONOMONEDERO;
        public decimal IABONOMONEDERO
        {
            get
            {
                return this.iABONOMONEDERO;
            }
            set
            {
                this.iABONOMONEDERO = value;
                this.isnull["IABONOMONEDERO"] = false;
            }
        }


        private decimal iSALDOMONEDERO;
        public decimal ISALDOMONEDERO
        {
            get
            {
                return this.iSALDOMONEDERO;
            }
            set
            {
                this.iSALDOMONEDERO = value;
                this.isnull["ISALDOMONEDERO"] = false;
            }
        }

        private DateTime iVIGENCIAMONEDERO;
        public DateTime IVIGENCIAMONEDERO
        {
            get
            {
                return this.iVIGENCIAMONEDERO;
            }
            set
            {
                this.iVIGENCIAMONEDERO = value;
                this.isnull["IVIGENCIAMONEDERO"] = false;
            }
        }



        private long iMONEDERO;
        public long IMONEDERO
        {
            get
            {
                return this.iMONEDERO;
            }
            set
            {
                this.iMONEDERO = value;
                this.isnull["IMONEDERO"] = false;
            }
        }




        private decimal iPAGOTRANSFERENCIA;
        public decimal IPAGOTRANSFERENCIA
        {
            get
            {
                return this.iPAGOTRANSFERENCIA;
            }
            set
            {
                this.iPAGOTRANSFERENCIA  = value;
                this.isnull["IPAGOTRANSFERENCIA"] = false;
            }
        }


        private decimal iPAGONOIDENTIFICADO;
        public decimal IPAGONOIDENTIFICADO
        {
            get
            {
                return this.iPAGONOIDENTIFICADO;
            }
            set
            {
                this.iPAGONOIDENTIFICADO = value;
                this.isnull["IPAGONOIDENTIFICADO"] = false;
            }
        }



        private DateTime iFECHAFACTURA;
        public DateTime IFECHAFACTURA
        {
            get
            {
                return this.iFECHAFACTURA;
            }
            set
            {
                this.iFECHAFACTURA = value;
                this.isnull["IFECHAFACTURA"] = false;
            }
        }


        private string iNOTAPAGO;
        public string INOTAPAGO
        {
            get
            {
                return this.iNOTAPAGO;
            }
            set
            {
                this.iNOTAPAGO = value;
                this.isnull["INOTAPAGO"] = false;
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

        public CTICKET_FOOTERBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IDOCTOID",true);
	

			isnull.Add("ISUBTOTAL",true);
	

			isnull.Add("IIVA",true);
	

			isnull.Add("ITOTAL",true);
	

			isnull.Add("ITOTAL_CON_LETRA",true);



            isnull.Add("IDESCUENTO_TOTAL", true);


            isnull.Add("ICAMBIO", true);


            isnull.Add("ICAJA", true);


            isnull.Add("ITURNO", true);


            isnull.Add("IPAGOEFECTIVO", true);

            isnull.Add("IPAGOTARJETA", true);

            isnull.Add("IPAGOCREDITO", true);

            isnull.Add("IPAGOCHEQUE", true);

            isnull.Add("IPAGOVALE", true);

            isnull.Add("IABONO", true);

            isnull.Add("ISALDO", true);

            isnull.Add("IPAGOMONEDERO", true);
            isnull.Add("IABONOMONEDERO", true);
            isnull.Add("ISALDOMONEDERO", true);
            isnull.Add("IVIGENCIAMONEDERO", true);
            isnull.Add("IMONEDERO", true);


            isnull.Add("IPAGOTRANSFERENCIA", true);
            isnull.Add("IPAGONOIDENTIFICADO", true);

            isnull.Add("IFECHAFACTURA", true);
            isnull.Add("INOTAPAGO", true);

            isnull.Add("IIMPORTEENDOLAR", true);

            isnull.Add("IKILOGRAMOS", true);
            isnull.Add("ICAJAS", true);
            isnull.Add("IPIEZAS", true);
        }

		

	}
}
