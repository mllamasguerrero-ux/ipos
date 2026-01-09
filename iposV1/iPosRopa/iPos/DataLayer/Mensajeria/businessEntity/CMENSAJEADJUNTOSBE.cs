
using System;
using System.Collections;

namespace iPosBusinessEntity
{
	public class CMENSAJEADJUNTOSBE
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

 	private long iIDMENSAJE;
        public long IIDMENSAJE
        { 
        	get
        	{
         		return this.iIDMENSAJE;
        	}
        	set
        	{
        		this.iIDMENSAJE= value;
        		this.isnull["IIDMENSAJE"]=false;
        	}
        }

 	private string iRUTAADJUNTO;
        public string IRUTAADJUNTO
        { 
        	get
        	{
         		return this.iRUTAADJUNTO;
        	}
        	set
        	{
        		this.iRUTAADJUNTO= value;
        		this.isnull["IRUTAADJUNTO"]=false;
        	}
        }


        private string iNOMBREARCHIVO;
        public string INOMBREARCHIVO
        {
            get
            {
                return this.iNOMBREARCHIVO;
            }
            set
            {
                this.iNOMBREARCHIVO = value;
                this.isnull["INOMBREARCHIVO"] = false;
            }
        }


        private string iFTPADJUNTO;
        public string IFTPADJUNTO
        {
            get
            {
                return this.iFTPADJUNTO;
            }
            set
            {
                this.iFTPADJUNTO = value;
                this.isnull["IFTPADJUNTO"] = false;
            }
        }

		
               public CMENSAJEADJUNTOSBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IID",true);
	

			isnull.Add("IACTIVO",true);
	

			isnull.Add("ICREADO",true);
	

			isnull.Add("ICREADOPOR_USERID",true);
	

			isnull.Add("IMODIFICADO",true);
	

			isnull.Add("IMODIFICADOPOR_USERID",true);
	

			isnull.Add("IIDMENSAJE",true);
	

			isnull.Add("IRUTAADJUNTO",true);
                   
			isnull.Add("INOMBREARCHIVO",true);

            isnull.Add("IFTPADJUNTO", true);

                       
                   

	
		}

		

	}
}
