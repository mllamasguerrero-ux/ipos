
using System;
using System.Collections;
namespace iPosBusinessEntity
{
	public class CINCREMENTABLESBE
	{
	public Hashtable isnull;
 	private short iNC_INCR;
        public short INC_INCR
        { 
        	get
        	{
         		return this.iNC_INCR;
        	}
        	set
        	{
        		this.iNC_INCR= value;
        		this.isnull["INC_INCR"]=false;
        	}
        }
 	private string iNC_DESC;
        public string INC_DESC
        { 
        	get
        	{
         		return this.iNC_DESC;
        	}
        	set
        	{
        		this.iNC_DESC= value;
        		this.isnull["INC_DESC"]=false;
        	}
        }
 	private long iNC_NEXTID;
        public long INC_NEXTID
        { 
        	get
        	{
         		return this.iNC_NEXTID;
        	}
        	set
        	{
        		this.iNC_NEXTID= value;
        		this.isnull["INC_NEXTID"]=false;
        	}
        }
		
               public CINCREMENTABLESBE()
		{
		isnull=new Hashtable();
	
			isnull.Add("INC_INCR",true);
	
			isnull.Add("INC_DESC",true);
	
			isnull.Add("INC_NEXTID",true);
	
		}
		
	}
}
