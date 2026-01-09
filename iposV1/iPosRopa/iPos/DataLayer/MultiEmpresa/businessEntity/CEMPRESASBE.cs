
using System;
using System.Collections;
namespace iPosBusinessEntity
{
	public class CEMPRESASBE
	{
	public Hashtable isnull;
 	private string iEM_NOMBRE;
        public string IEM_NOMBRE
        { 
        	get
        	{
         		return this.iEM_NOMBRE;
        	}
        	set
        	{
        		this.iEM_NOMBRE= value;
        		this.isnull["IEM_NOMBRE"]=false;
        	}
        }
 	private string iEM_DATABASE;
        public string IEM_DATABASE
        { 
        	get
        	{
         		return this.iEM_DATABASE;
        	}
        	set
        	{
        		this.iEM_DATABASE= value;
        		this.isnull["IEM_DATABASE"]=false;
        	}
        }
 	private string iEM_USUARIO;
        public string IEM_USUARIO
        { 
        	get
        	{
         		return this.iEM_USUARIO;
        	}
        	set
        	{
        		this.iEM_USUARIO= value;
        		this.isnull["IEM_USUARIO"]=false;
        	}
        }
 	private string iEM_PASSWORD;
        public string IEM_PASSWORD
        { 
        	get
        	{
         		return this.iEM_PASSWORD;
        	}
        	set
        	{
        		this.iEM_PASSWORD= value;
        		this.isnull["IEM_PASSWORD"]=false;
        	}
        }
 	private string iEM_SERVER;
        public string IEM_SERVER
        { 
        	get
        	{
         		return this.iEM_SERVER;
        	}
        	set
        	{
        		this.iEM_SERVER= value;
        		this.isnull["IEM_SERVER"]=false;
        	}
        }



        private int iEM_CAJA;
        public int IEM_CAJA
        {
            get
            {
                return this.iEM_CAJA;
            }
            set
            {
                this.iEM_CAJA = value;
                this.isnull["IEM_CAJA"] = false;
            }
        }




        private string iHABILITAR_IMPEXP_AUT;
        public string IHABILITAR_IMPEXP_AUT
        {
            get
            {
                return this.iHABILITAR_IMPEXP_AUT;
            }
            set
            {
                this.iHABILITAR_IMPEXP_AUT = value;
                this.isnull["IHABILITAR_IMPEXP_AUT"] = false;
            }
        }




        private string iESMATRIZ;
        public string IESMATRIZ
        {
            get
            {
                return this.iESMATRIZ;
            }
            set
            {
                this.iESMATRIZ = value;
                this.isnull["IESMATRIZ"] = false;
            }
        }


        private string iEM_CAJA_NOMBRE;
        public string IEM_CAJA_NOMBRE
        {
            get
            {
                return this.iEM_CAJA_NOMBRE;
            }
            set
            {
                this.iEM_CAJA_NOMBRE = value;
                this.isnull["IEM_CAJA_NOMBRE"] = false;
            }
        }


        private string iBASEDIRECTORY;
        public string IBASEDIRECTORY
        {
            get
            {
                return this.iBASEDIRECTORY;
            }
            set
            {
                this.iBASEDIRECTORY = value;
                this.isnull["IBASEDIRECTORY"] = false;
            }
        }

        private int iRED;
        public int IRED
        {
            get
            {
                return this.iRED;
            }
            set
            {
                this.iRED = value;
                this.isnull["IRED"] = false;
            }
        }

        private int iBLUE;
        public int IBLUE
        {
            get
            {
                return this.iBLUE;
            }
            set
            {
                this.iBLUE = value;
                this.isnull["IBLUE"] = false;
            }
        }

        private int iGREEN;
        public int IGREEN
        {
            get
            {
                return this.iGREEN;
            }
            set
            {
                this.iGREEN = value;
                this.isnull["IGREEN"] = false;
            }
        }



        private string iHAB_POOLING;
        public string IHAB_POOLING
        {
            get
            {
                return this.iHAB_POOLING;
            }
            set
            {
                this.iHAB_POOLING = value;
                this.isnull["IHAB_POOLING"] = false;
            }
        }


        private string iREPLICADOR;
        public string IREPLICADOR
        {
            get
            {
                return this.iREPLICADOR;
            }
            set
            {
                this.iREPLICADOR = value;
                this.isnull["IREPLICADOR"] = false;
            }
        }

        public CEMPRESASBE()
		{
		isnull=new Hashtable();
	
			isnull.Add("IEM_NOMBRE",true);
	
			isnull.Add("IEM_DATABASE",true);
	
			isnull.Add("IEM_USUARIO",true);
	
			isnull.Add("IEM_PASSWORD",true);
	
			isnull.Add("IEM_SERVER",true);

			isnull.Add("IHABILITAR_IMPEXP_AUT",true);
			isnull.Add("IEM_CAJA",true);
            isnull.Add("IEM_CAJA_NOMBRE", true);


            isnull.Add("IESMATRIZ", true);
            isnull.Add("IBASEDIRECTORY", true);


            isnull.Add("IRED", true);
            isnull.Add("IBLUE", true);
            isnull.Add("IGREEN", true);

            isnull.Add("IHAB_POOLING", true);

            isnull.Add("IREPLICADOR", true);


        }
		
	}
}
