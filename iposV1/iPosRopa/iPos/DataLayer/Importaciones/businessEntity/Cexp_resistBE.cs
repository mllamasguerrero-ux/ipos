
using System;
using System.Collections;
namespace iPosBusinessEntity
{
	public class CEXP_EXISTBE
	{
	public Hashtable isnull;

 	private string iCLAVE;
        public string ICLAVE
        { 
        	get
        	{
         		return this.iCLAVE;
        	}
        	set
        	{
        		this.iCLAVE= value;
        		this.isnull["ICLAVE"]=false;
        	}
        }

 	private string iHORA;
        public string IHORA
        { 
        	get
        	{
         		return this.iHORA;
        	}
        	set
        	{
        		this.iHORA= value;
        		this.isnull["IHORA"]=false;
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

 	private double iCANTIDAD;
        public double ICANTIDAD
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
		
               public CEXP_EXISTBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("ICLAVE",true);
	

			isnull.Add("IHORA",true);
	

			isnull.Add("IFECHA",true);
	

			isnull.Add("ICANTIDAD",true);
	
		}

		

	}
}
