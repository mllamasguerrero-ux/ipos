
using System;
using System.Collections;
namespace iPosBusinessEntity
{
	public class CPRODUCTOLOCATIONSBE
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

 	private string iANAQUEL;
        public string IANAQUEL
        { 
        	get
        	{
         		return this.iANAQUEL;
        	}
        	set
        	{
        		this.iANAQUEL= value;
        		this.isnull["IANAQUEL"]=false;
        	}
        }

 	private string iLOCALIDAD;
        public string ILOCALIDAD
        { 
        	get
        	{
         		return this.iLOCALIDAD;
        	}
        	set
        	{
        		this.iLOCALIDAD= value;
        		this.isnull["ILOCALIDAD"]=false;
        	}
        }


        private long iANAQUELID;
        public long IANAQUELID
        {
            get
            {
                return this.iANAQUELID;
            }
            set
            {
                this.iANAQUELID = value;
                this.isnull["IANAQUELID"] = false;
            }
        }


        private long iALMACENID;
        public long IALMACENID
        {
            get
            {
                return this.iALMACENID;
            }
            set
            {
                this.iALMACENID = value;
                this.isnull["IALMACENID"] = false;
            }
        }
		

               public CPRODUCTOLOCATIONSBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IID",true);
	

			isnull.Add("IACTIVO",true);
	

			isnull.Add("ICREADO",true);
	

			isnull.Add("ICREADOPOR_USERID",true);
	

			isnull.Add("IMODIFICADO",true);
	

			isnull.Add("IMODIFICADOPOR_USERID",true);
	

			isnull.Add("IPRODUCTOID",true);
	

			isnull.Add("IANAQUEL",true);
	

			isnull.Add("ILOCALIDAD",true);

            isnull.Add("IANAQUELID", true);


            isnull.Add("IALMACENID", true);
                   
	
		}

		

	}
}
