
using System;
using System.Collections;
namespace iPosBusinessEntity
{
	public class CUSUARIO_PERFILBE
	{
	public Hashtable isnull;

 	private int iUP_PERFIL;
        public int IUP_PERFIL
        { 
        	get
        	{
         		return this.iUP_PERFIL;
        	}
        	set
        	{
        		this.iUP_PERFIL= value;
        		this.isnull["IUP_PERFIL"]=false;
        	}
        }

 	private long iUP_PERSONAID;
        public long IUP_PERSONAID
        { 
        	get
        	{
         		return this.iUP_PERSONAID;
        	}
        	set
        	{
        		this.iUP_PERSONAID= value;
        		this.isnull["IUP_PERSONAID"]=false;
        	}
        }
		
               public CUSUARIO_PERFILBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IUP_PERFIL",true);
	

			isnull.Add("IUP_PERSONAID",true);
	
		}

		

	}
}
