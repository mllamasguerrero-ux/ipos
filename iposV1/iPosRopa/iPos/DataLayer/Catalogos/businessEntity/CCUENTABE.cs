
using System;
using System.Collections;
namespace iPosBusinessEntity
{
	public class CCUENTABE
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

        private DateTime iCREADO;
        public DateTime ICREADO
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

        private DateTime iMODIFICADO;
        public DateTime IMODIFICADO
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

 	private string iNUMUCUENTA;
        public string INUMUCUENTA
        { 
        	get
        	{
         		return this.iNUMUCUENTA;
        	}
        	set
        	{
        		this.iNUMUCUENTA= value;
        		this.isnull["INUMUCUENTA"]=false;
        	}
        }

 	private string iDESCRIPCION;
        public string IDESCRIPCION
        { 
        	get
        	{
         		return this.iDESCRIPCION;
        	}
        	set
        	{
        		this.iDESCRIPCION= value;
        		this.isnull["IDESCRIPCION"]=false;
        	}
        }



        private long iTIPOLINEAPOLIZAID;
        public long ITIPOLINEAPOLIZAID
        {
            get
            {
                return this.iTIPOLINEAPOLIZAID;
            }
            set
            {
                this.iTIPOLINEAPOLIZAID = value;
                this.isnull["ITIPOLINEAPOLIZAID"] = false;
            }
        }



        private long iFORMAPAGOSATID;
        public long IFORMAPAGOSATID
        {
            get
            {
                return this.iFORMAPAGOSATID;
            }
            set
            {
                this.iFORMAPAGOSATID = value;
                this.isnull["IFORMAPAGOSATID"] = false;
            }
        }



        private string iESFACT;
        public string IESFACT
        {
            get
            {
                return this.iESFACT;
            }
            set
            {
                this.iESFACT = value;
                this.isnull["IESFACT"] = false;
            }
        }


        private decimal iTASA;
        public decimal ITASA
        {
            get
            {
                return this.iTASA;
            }
            set
            {
                this.iTASA = value;
                this.isnull["ITASA"] = false;
            }
        }




        private long iTIPOLINEAPOLIZAESPECIALID;
        public long ITIPOLINEAPOLIZAESPECIALID
        {
            get
            {
                return this.iTIPOLINEAPOLIZAESPECIALID;
            }
            set
            {
                this.iTIPOLINEAPOLIZAESPECIALID = value;
                this.isnull["ITIPOLINEAPOLIZAESPECIALID"] = false;
            }
        }



        private string iLEYENDA;
        public string ILEYENDA
        {
            get
            {
                return this.iLEYENDA;
            }
            set
            {
                this.iLEYENDA = value;
                this.isnull["ILEYENDA"] = false;
            }
        }




        private int iORDEN;
        public int IORDEN
        {
            get
            {
                return this.iORDEN;
            }
            set
            {
                this.iORDEN = value;
                this.isnull["IORDEN"] = false;
            }
        }

               public CCUENTABE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IID",true);
	

			isnull.Add("IACTIVO",true);
	

			isnull.Add("ICREADO",true);
	

			isnull.Add("ICREADOPOR_USERID",true);
	

			isnull.Add("IMODIFICADO",true);
	

			isnull.Add("IMODIFICADOPOR_USERID",true);
	

			isnull.Add("ICLAVE",true);
	

			isnull.Add("INUMUCUENTA",true);


            isnull.Add("IDESCRIPCION", true);
            isnull.Add("ITIPOLINEAPOLIZAID", true);


            isnull.Add("IFORMAPAGOSATID", true);


            isnull.Add("IESFACT", true);


            isnull.Add("ITASA", true);


            isnull.Add("ITIPOLINEAPOLIZAESPECIALID", true);


            isnull.Add("ILEYENDA", true);


            isnull.Add("IORDEN", true);
	
		}

		

	}
}
