
using System;
using System.Collections;
namespace iPosBusinessEntity
{
	public class CPERFIL_REPOBE
	{
	public Hashtable isnull;

 	private int iPERFIL;
        public int IPERFIL
        { 
        	get
        	{
         		return this.iPERFIL;
        	}
        	set
        	{
        		this.iPERFIL= value;
        		this.isnull["IPERFIL"]=false;
        	}
        }

 	private int iREPORTE;
        public int IREPORTE
        { 
        	get
        	{
         		return this.iREPORTE;
        	}
        	set
        	{
        		this.iREPORTE= value;
        		this.isnull["IREPORTE"]=false;
        	}
        }
		
               public CPERFIL_REPOBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IPERFIL",true);
	

			isnull.Add("IREPORTE",true);
	
		}

		

	}
}
