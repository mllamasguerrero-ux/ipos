
using System;
using System.Collections;

namespace iPosBusinessEntity
{
	public class CGUIABE
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

 	private int iFOLIO;
        public int IFOLIO
        { 
        	get
        	{
         		return this.iFOLIO;
        	}
        	set
        	{
        		this.iFOLIO= value;
        		this.isnull["IFOLIO"]=false;
        	}
        }

 	private long iENCARGADOGUIAID;
        public long IENCARGADOGUIAID
        { 
        	get
        	{
         		return this.iENCARGADOGUIAID;
        	}
        	set
        	{
        		this.iENCARGADOGUIAID= value;
        		this.isnull["IENCARGADOGUIAID"]=false;
        	}
        }

 	private long iESTADOGUIAID;
        public long IESTADOGUIAID
        { 
        	get
        	{
         		return this.iESTADOGUIAID;
        	}
        	set
        	{
        		this.iESTADOGUIAID= value;
        		this.isnull["IESTADOGUIAID"]=false;
        	}
        }

 	private long iCAJEROID;
        public long ICAJEROID
        { 
        	get
        	{
         		return this.iCAJEROID;
        	}
        	set
        	{
        		this.iCAJEROID= value;
        		this.isnull["ICAJEROID"]=false;
        	}
        }

 	private long iCORTEID;
        public long ICORTEID
        { 
        	get
        	{
         		return this.iCORTEID;
        	}
        	set
        	{
        		this.iCORTEID= value;
        		this.isnull["ICORTEID"]=false;
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

 	private string iNOTA;
        public string INOTA
        { 
        	get
        	{
         		return this.iNOTA;
        	}
        	set
        	{
        		this.iNOTA= value;
        		this.isnull["INOTA"]=false;
        	}
        }




        private long iTIPOENTREGAID;
        public long ITIPOENTREGAID
        {
            get
            {
                return this.iTIPOENTREGAID;
            }
            set
            {
                this.iTIPOENTREGAID = value;
                this.isnull["ITIPOENTREGAID"] = false;
            }
        }


        private string iGUIAPAQUETERIA;
        public string IGUIAPAQUETERIA
        {
            get
            {
                return this.iGUIAPAQUETERIA;
            }
            set
            {
                this.iGUIAPAQUETERIA = value;
                this.isnull["IGUIAPAQUETERIA"] = false;
            }
        }




        private long iVEHICULOID;
        public long IVEHICULOID
        {
            get
            {
                return this.iVEHICULOID;
            }
            set
            {
                this.iVEHICULOID = value;
                this.isnull["IVEHICULOID"] = false;
            }
        }



        private DateTime iFECHAESTIMADAREC;
        public DateTime IFECHAESTIMADAREC
        {
            get
            {
                return this.iFECHAESTIMADAREC;
            }
            set
            {
                this.iFECHAESTIMADAREC = value;
                this.isnull["IFECHAESTIMADAREC"] = false;
            }
        }

        private DateTime iHORAESTIMADREC;
        public DateTime IHORAESTIMADREC
        {
            get
            {
                return this.iHORAESTIMADREC;
            }
            set
            {
                this.iHORAESTIMADREC = value;
                this.isnull["IHORAESTIMADREC"] = false;
            }
        }


        private string iNOTARECEPCION;
        public string INOTARECEPCION
        {
            get
            {
                return this.iNOTARECEPCION;
            }
            set
            {
                this.iNOTARECEPCION = value;
                this.isnull["INOTARECEPCION"] = false;
            }
        }

        public CGUIABE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IID",true);
	

			isnull.Add("IACTIVO",true);
	

			isnull.Add("ICREADO",true);
	

			isnull.Add("ICREADOPOR_USERID",true);
	

			isnull.Add("IMODIFICADO",true);
	

			isnull.Add("IMODIFICADOPOR_USERID",true);
	

			isnull.Add("IFOLIO",true);
	

			isnull.Add("IENCARGADOGUIAID",true);
	

			isnull.Add("IESTADOGUIAID",true);
	

			isnull.Add("ICAJEROID",true);
	

			isnull.Add("ICORTEID",true);
	

			isnull.Add("IFECHA",true);
	

			isnull.Add("IFECHAHORA",true);
	

			isnull.Add("INOTA",true);

            isnull.Add("ITIPOENTREGAID", true);

            isnull.Add("IGUIAPAQUETERIA", true);

            isnull.Add("IVEHICULOID", true);


            isnull.Add("IFECHAESTIMADAREC", true);


            isnull.Add("IHORAESTIMADREC", true);

            isnull.Add("INOTARECEPCION", true);
            




        }

		

	}
}
