
using System;
using System.Collections;

namespace iPosBusinessEntity
{
	public class CKITDEFTEMPBE
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

 	private long iPRODUCTOKITID;
        public long IPRODUCTOKITID
        { 
        	get
        	{
         		return this.iPRODUCTOKITID;
        	}
        	set
        	{
        		this.iPRODUCTOKITID= value;
        		this.isnull["IPRODUCTOKITID"]=false;
        	}
        }

 	private long iPRODUCTOPARTEID;
        public long IPRODUCTOPARTEID
        { 
        	get
        	{
         		return this.iPRODUCTOPARTEID;
        	}
        	set
        	{
        		this.iPRODUCTOPARTEID= value;
        		this.isnull["IPRODUCTOPARTEID"]=false;
        	}
        }

 	private decimal iCANTIDADPARTE;
        public decimal ICANTIDADPARTE
        { 
        	get
        	{
         		return this.iCANTIDADPARTE;
        	}
        	set
        	{
        		this.iCANTIDADPARTE= value;
        		this.isnull["ICANTIDADPARTE"]=false;
        	}
        }

 	private string iPRODUCTOKITCLAVE;
        public string IPRODUCTOKITCLAVE
        { 
        	get
        	{
         		return this.iPRODUCTOKITCLAVE;
        	}
        	set
        	{
        		this.iPRODUCTOKITCLAVE= value;
        		this.isnull["IPRODUCTOKITCLAVE"]=false;
        	}
        }

 	private string iPRODUCTOPARTECLAVE;
        public string IPRODUCTOPARTECLAVE
        { 
        	get
        	{
         		return this.iPRODUCTOPARTECLAVE;
        	}
        	set
        	{
        		this.iPRODUCTOPARTECLAVE= value;
        		this.isnull["IPRODUCTOPARTECLAVE"]=false;
        	}
        }


        private decimal iCOSTOPARTE;
        public decimal ICOSTOPARTE
        {
            get
            {
                return this.iCOSTOPARTE;
            }
            set
            {
                this.iCOSTOPARTE = value;
                this.isnull["ICOSTOPARTE"] = false;
            }
        }


		
               public CKITDEFTEMPBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IID",true);
	

			isnull.Add("IACTIVO",true);
	

			isnull.Add("ICREADO",true);
	

			isnull.Add("ICREADOPOR_USERID",true);
	

			isnull.Add("IMODIFICADO",true);
	

			isnull.Add("IMODIFICADOPOR_USERID",true);
	

			isnull.Add("IPRODUCTOKITID",true);
	

			isnull.Add("IPRODUCTOPARTEID",true);
	

			isnull.Add("ICANTIDADPARTE",true);
	

			isnull.Add("IPRODUCTOKITCLAVE",true);


            isnull.Add("IPRODUCTOPARTECLAVE", true);

            isnull.Add("ICOSTOPARTE", true);
		}

		

	}
}
