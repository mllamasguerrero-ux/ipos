
using System;
using System.Collections;

namespace iPosBusinessEntity
{
	public class CLISTAPRECIODETALLEBE
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

 	private long iLISTAPRECIOID;
        public long ILISTAPRECIOID
        { 
        	get
        	{
         		return this.iLISTAPRECIOID;
        	}
        	set
        	{
        		this.iLISTAPRECIOID= value;
        		this.isnull["ILISTAPRECIOID"]=false;
        	}
        }

 	private decimal iPRECIO1;
        public decimal IPRECIO1
        { 
        	get
        	{
         		return this.iPRECIO1;
        	}
        	set
        	{
        		this.iPRECIO1= value;
        		this.isnull["IPRECIO1"]=false;
        	}
        }

 	private decimal iPRECIO2;
        public decimal IPRECIO2
        { 
        	get
        	{
         		return this.iPRECIO2;
        	}
        	set
        	{
        		this.iPRECIO2= value;
        		this.isnull["IPRECIO2"]=false;
        	}
        }

 	private decimal iPRECIO3;
        public decimal IPRECIO3
        { 
        	get
        	{
         		return this.iPRECIO3;
        	}
        	set
        	{
        		this.iPRECIO3= value;
        		this.isnull["IPRECIO3"]=false;
        	}
        }

 	private decimal iPRECIO4;
        public decimal IPRECIO4
        { 
        	get
        	{
         		return this.iPRECIO4;
        	}
        	set
        	{
        		this.iPRECIO4= value;
        		this.isnull["IPRECIO4"]=false;
        	}
        }

 	private decimal iPRECIO5;
        public decimal IPRECIO5
        { 
        	get
        	{
         		return this.iPRECIO5;
        	}
        	set
        	{
        		this.iPRECIO5= value;
        		this.isnull["IPRECIO5"]=false;
        	}
        }

 	private decimal iPRECIO6;
        public decimal IPRECIO6
        { 
        	get
        	{
         		return this.iPRECIO6;
        	}
        	set
        	{
        		this.iPRECIO6= value;
        		this.isnull["IPRECIO6"]=false;
        	}
        }

 	private long iPRODUCTOID;
        public long IPRODUCTOID
        { 
        	get
        	{
         		return this.iPRODUCTOID;
        	}
        	set
        	{
        		this.iPRODUCTOID= value;
        		this.isnull["IPRODUCTOID"]=false;
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


        private decimal iCOSTOREPOSICION;
        public decimal ICOSTOREPOSICION
        {
            get
            {
                return this.iCOSTOREPOSICION;
            }
            set
            {
                this.iCOSTOREPOSICION = value;
                this.isnull["ICOSTOREPOSICION"] = false;
            }
        }



        private string iTIENEVIG;
        public string ITIENEVIG
        {
            get
            {
                return this.iTIENEVIG;
            }
            set
            {
                this.iTIENEVIG = value;
                this.isnull["ITIENEVIG"] = false;
            }
        }


        private DateTime iFECHAVIG;
        public DateTime IFECHAVIG
        {
            get
            {
                return this.iFECHAVIG;
            }
            set
            {
                this.iFECHAVIG = value;
                this.isnull["IFECHAVIG"] = false;
            }
        }


        public CLISTAPRECIODETALLEBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IID",true);
	

			isnull.Add("IACTIVO",true);
	

			isnull.Add("ICREADO",true);
	

			isnull.Add("ICREADOPOR_USERID",true);
	

			isnull.Add("IMODIFICADO",true);
	

			isnull.Add("IMODIFICADOPOR_USERID",true);
	

			isnull.Add("ILISTAPRECIOID",true);
	

			isnull.Add("IPRECIO1",true);
	

			isnull.Add("IPRECIO2",true);
	

			isnull.Add("IPRECIO3",true);
	

			isnull.Add("IPRECIO4",true);
	

			isnull.Add("IPRECIO5",true);
	

			isnull.Add("IPRECIO6",true);
	

			isnull.Add("IPRODUCTOID",true);

            isnull.Add("IPRODUCTOCLAVE", true);

            isnull.Add("ICOSTOREPOSICION", true);


            isnull.Add("ITIENEVIG", true);
            isnull.Add("IFECHAVIG", true);


        }

		

	}
}
