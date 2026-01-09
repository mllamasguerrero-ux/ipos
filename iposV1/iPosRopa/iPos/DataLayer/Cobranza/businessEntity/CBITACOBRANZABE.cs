
using System;
using System.Collections;
namespace iPosBusinessEntity
{
	public class CBITACOBRANZABE
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

 	private long iCOBRADORID;
        public long ICOBRADORID
        { 
        	get
        	{
         		return this.iCOBRADORID;
        	}
        	set
        	{
        		this.iCOBRADORID= value;
        		this.isnull["ICOBRADORID"]=false;
        	}
        }

 	private decimal iTOTALABONADO;
        public decimal ITOTALABONADO
        { 
        	get
        	{
         		return this.iTOTALABONADO;
        	}
        	set
        	{
        		this.iTOTALABONADO= value;
        		this.isnull["ITOTALABONADO"]=false;
        	}
        }

 	private long iESTADO;
        public long IESTADO
        { 
        	get
        	{
         		return this.iESTADO;
        	}
        	set
        	{
        		this.iESTADO= value;
        		this.isnull["IESTADO"]=false;
        	}
        }

        private string iNOTARECEPCION;
        public string INOTARECEPCION
        {
            get
            {
                return this.iNOTARECEPCION;
            }
            set
            {
                this.iNOTARECEPCION = value;
                this.isnull["INOTARECEPCION"] = false;
            }
        }

        public CBITACOBRANZABE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IID",true);
	

			isnull.Add("IACTIVO",true);
	

			isnull.Add("ICREADO",true);
	

			isnull.Add("ICREADOPOR_USERID",true);
	

			isnull.Add("IMODIFICADO",true);
	

			isnull.Add("IMODIFICADOPOR_USERID",true);
	

			isnull.Add("IFECHA",true);
	

			isnull.Add("ICOBRADORID",true);
	

			isnull.Add("ITOTALABONADO",true);
	

			isnull.Add("IESTADO",true);

            isnull.Add("INOTARECEPCION", true);

        }

		

	}
}
