
using System;
using System.Collections;
namespace iPosBusinessEntity
{
	public class CEXP_FILESBE
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

 	private string iNOMBRE;
        public string INOMBRE
        { 
        	get
        	{
         		return this.iNOMBRE;
        	}
        	set
        	{
        		this.iNOMBRE= value;
        		this.isnull["INOMBRE"]=false;
        	}
        }

 	private string iARCHIVOFTP;
        public string IARCHIVOFTP
        { 
        	get
        	{
         		return this.iARCHIVOFTP;
        	}
        	set
        	{
        		this.iARCHIVOFTP= value;
        		this.isnull["IARCHIVOFTP"]=false;
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

 	private long iTURNOID;
        public long ITURNOID
        { 
        	get
        	{
         		return this.iTURNOID;
        	}
        	set
        	{
        		this.iTURNOID= value;
        		this.isnull["ITURNOID"]=false;
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

 	private DateTime iFECHASUBIDA;
        public DateTime IFECHASUBIDA
        { 
        	get
        	{
         		return this.iFECHASUBIDA;
        	}
        	set
        	{
        		this.iFECHASUBIDA= value;
        		this.isnull["IFECHASUBIDA"]=false;
        	}
        }

 	private TimeSpan iHORASUBIDA;
    public TimeSpan IHORASUBIDA
        { 
        	get
        	{
         		return this.iHORASUBIDA;
        	}
        	set
        	{
        		this.iHORASUBIDA= value;
        		this.isnull["IHORASUBIDA"]=false;
        	}
        }

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

 	private int iDOCTOFOLIO;
        public int IDOCTOFOLIO
        { 
        	get
        	{
         		return this.iDOCTOFOLIO;
        	}
        	set
        	{
        		this.iDOCTOFOLIO= value;
        		this.isnull["IDOCTOFOLIO"]=false;
        	}
        }


        private DateTime iFECHATO;
        public DateTime IFECHATO
        {
            get
            {
                return this.iFECHATO;
            }
            set
            {
                this.iFECHATO = value;
                this.isnull["IFECHATO"] = false;
            }
        }


        private string iDOCTOSERIE;
        public string IDOCTOSERIE
        {
            get
            {
                return this.iDOCTOSERIE;
            }
            set
            {
                this.iDOCTOSERIE = value;
                this.isnull["IDOCTOSERIE"] = false;
            }
        }

        private long iTIPODOCTOID;
        public long ITIPODOCTOID
        {
            get
            {
                return this.iTIPODOCTOID;
            }
            set
            {
                this.iTIPODOCTOID = value;
                this.isnull["ITIPODOCTOID"] = false;
            }
        }

               public CEXP_FILESBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IID",true);
	

			isnull.Add("ITIPO",true);
	

			isnull.Add("INOMBRE",true);
	

			isnull.Add("IARCHIVOFTP",true);
	

			isnull.Add("IFECHA",true);
	

			isnull.Add("ITURNOID",true);
	

			isnull.Add("IPERSONAID",true);
	

			isnull.Add("IESTATUS",true);
	

			isnull.Add("IFECHASUBIDA",true);
	

			isnull.Add("IHORASUBIDA",true);
	

			isnull.Add("IDOCTOID",true);
	

			isnull.Add("IDOCTOFOLIO",true);

            isnull.Add("IFECHATO", true);

            isnull.Add("IDOCTOSERIE", true);

            isnull.Add("ITIPODOCTOID", true);

                   
	
		}

		

	}
}
