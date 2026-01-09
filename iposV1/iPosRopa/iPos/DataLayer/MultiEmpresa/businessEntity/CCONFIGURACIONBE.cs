
using System;
using System.Collections;
namespace iPosBusinessEntity
{
	public class CCONFIGURACIONBE
	{
	public Hashtable isnull;
 	private short iCF_ID;
        public short ICF_ID
        { 
        	get
        	{
         		return this.iCF_ID;
        	}
        	set
        	{
        		this.iCF_ID= value;
        		this.isnull["ICF_ID"]=false;
        	}
        }
 	private string iCF_DEFAULT_DB;
        public string ICF_DEFAULT_DB
        { 
        	get
        	{
         		return this.iCF_DEFAULT_DB;
        	}
        	set
        	{
        		this.iCF_DEFAULT_DB= value;
        		this.isnull["ICF_DEFAULT_DB"]=false;
        	}
        }


        private string iCF_LLAVE_EMPRESA;
        public string ICF_LLAVE_EMPRESA
        {
            get
            {
                return this.iCF_LLAVE_EMPRESA;
            }
            set
            {
                this.iCF_LLAVE_EMPRESA = value;
                this.isnull["ICF_LLAVE_EMPRESA"] = false;
            }
        }

        private string iCF_IS_SERVER;
        public string ICF_IS_SERVER
        {
            get
            {
                return this.iCF_IS_SERVER;
            }
            set
            {
                this.iCF_IS_SERVER = value;
                this.isnull["ICF_IS_SERVER"] = false;
            }
        }

        private string iCF_SERVER_NAME;
        public string ICF_SERVER_NAME
        {
            get
            {
                return this.iCF_SERVER_NAME;
            }
            set
            {
                this.iCF_SERVER_NAME = value;
                this.isnull["ICF_SERVER_NAME"] = false;
            }
        }

        private string iCF_PATH_IPOS_SERVER;
        public string ICF_PATH_IPOS_SERVER
        {
            get
            {
                return this.iCF_PATH_IPOS_SERVER;
            }
            set
            {
                this.iCF_PATH_IPOS_SERVER = value;
                this.isnull["ICF_PATH_IPOS_SERVER"] = false;
            }
        }

        private string iCF_MACHINE_NAME;
        public string ICF_MACHINE_NAME
        {
            get
            {
                return this.iCF_MACHINE_NAME;
            }
            set
            {
                this.iCF_MACHINE_NAME = value;
                this.isnull["ICF_MACHINE_NAME"] = false;
            }
        }

        private string iCF_SERVER_PATH;
        public string ICF_SERVER_PATH
        {
            get
            {
                return this.iCF_SERVER_PATH;
            }
            set
            {
                this.iCF_SERVER_PATH = value;
                this.isnull["ICF_SERVER_PATH"] = false;
            }
        }
		
               public CCONFIGURACIONBE()
		{
		isnull=new Hashtable();
	
			isnull.Add("ICF_ID",true);
	
			isnull.Add("ICF_DEFAULT_DB",true);

            isnull.Add("ICF_LLAVE_EMPRESA", true);

            isnull.Add("ICF_IS_SERVER", true);

            isnull.Add("ICF_SERVER_NAME", true);

            isnull.Add("ICF_PATH_IPOS_SERVER", true);

            isnull.Add("ICF_MACHINE_NAME", true);

            isnull.Add("ICF_SERVER_PATH", true);
		}
		
	}
}
