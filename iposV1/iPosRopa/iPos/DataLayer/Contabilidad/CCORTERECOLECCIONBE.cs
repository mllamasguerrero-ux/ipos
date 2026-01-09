
using System;
using System.Collections;

namespace iPosBusinessEntity
{
	public class CCORTERECOLECCIONBE
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

 	private long iENCARGADOID;
        public long IENCARGADOID
        { 
        	get
        	{
         		return this.iENCARGADOID;
        	}
        	set
        	{
        		this.iENCARGADOID= value;
        		this.isnull["IENCARGADOID"]=false;
        	}
        }

 	private DateTime iFECHAHORA;
        public DateTime IFECHAHORA
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

 	private decimal iMONTO;
        public decimal IMONTO
        { 
        	get
        	{
         		return this.iMONTO;
        	}
        	set
        	{
        		this.iMONTO= value;
        		this.isnull["IMONTO"]=false;
        	}
        }


        private string iOBSERVACIONES;
        public string IOBSERVACIONES
        {
            get
            {
                return this.iOBSERVACIONES;
            }
            set
            {
                this.iOBSERVACIONES = value;
                this.isnull["IOBSERVACIONES"] = false;
            }
        }

        public CCORTERECOLECCIONBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IID",true);
	

			isnull.Add("IACTIVO",true);
	

			isnull.Add("ICREADO",true);
	

			isnull.Add("ICREADOPOR_USERID",true);
	

			isnull.Add("IMODIFICADO",true);
	

			isnull.Add("IMODIFICADOPOR_USERID",true);
	

			isnull.Add("IENCARGADOID",true);
	

			isnull.Add("IFECHAHORA",true);
	

			isnull.Add("IMONTO",true);

            isnull.Add("IOBSERVACIONES", true);



        }

		

	}
}
