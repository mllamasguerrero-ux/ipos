
using System;
using System.Collections;
namespace iPosBusinessEntity
{
	public class CTICKET_HEADERBE
	{
	public Hashtable isnull;

 	private long iDOCTOID;
        public long IDOCTOID
        { 
        	get
        	{
         		return this.iDOCTOID;
        	}
        	set
        	{
        		this.iDOCTOID= value;
        		this.isnull["IDOCTOID"]=false;
        	}
        }

 	private long iESTATUSDOCTOID;
        public long IESTATUSDOCTOID
        { 
        	get
        	{
         		return this.iESTATUSDOCTOID;
        	}
        	set
        	{
        		this.iESTATUSDOCTOID= value;
        		this.isnull["IESTATUSDOCTOID"]=false;
        	}
        }

 	private long iALMACENID;
        public long IALMACENID
        { 
        	get
        	{
         		return this.iALMACENID;
        	}
        	set
        	{
        		this.iALMACENID= value;
        		this.isnull["IALMACENID"]=false;
        	}
        }

 	private long iSUCURSALID;
        public long ISUCURSALID
        { 
        	get
        	{
         		return this.iSUCURSALID;
        	}
        	set
        	{
        		this.iSUCURSALID= value;
        		this.isnull["ISUCURSALID"]=false;
        	}
        }

 	private long iPERSONAID;
        public long IPERSONAID
        { 
        	get
        	{
         		return this.iPERSONAID;
        	}
        	set
        	{
        		this.iPERSONAID= value;
        		this.isnull["IPERSONAID"]=false;
        	}
        }

 	private long iTIPODOCTOID;
        public long ITIPODOCTOID
        { 
        	get
        	{
         		return this.iTIPODOCTOID;
        	}
        	set
        	{
        		this.iTIPODOCTOID= value;
        		this.isnull["ITIPODOCTOID"]=false;
        	}
        }

 	private decimal iTOTAL;
        public decimal ITOTAL
        { 
        	get
        	{
         		return this.iTOTAL;
        	}
        	set
        	{
        		this.iTOTAL= value;
        		this.isnull["ITOTAL"]=false;
        	}
        }

 	private string iNOMBRE;
        public string INOMBRE
        { 
        	get
        	{
         		return this.iNOMBRE;
        	}
        	set
        	{
        		this.iNOMBRE= value;
        		this.isnull["INOMBRE"]=false;
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

 	private string iRFC;
        public string IRFC
        { 
        	get
        	{
         		return this.iRFC;
        	}
        	set
        	{
        		this.iRFC= value;
        		this.isnull["IRFC"]=false;
        	}
        }

 	private string iCOLONIA;
        public string ICOLONIA
        { 
        	get
        	{
         		return this.iCOLONIA;
        	}
        	set
        	{
        		this.iCOLONIA= value;
        		this.isnull["ICOLONIA"]=false;
        	}
        }

 	private string iDOMICICIO;
        public string IDOMICICIO
        { 
        	get
        	{
         		return this.iDOMICICIO;
        	}
        	set
        	{
        		this.iDOMICICIO= value;
        		this.isnull["IDOMICICIO"]=false;
        	}
        }

 	private string iCODIGOPOSTAL;
        public string ICODIGOPOSTAL
        { 
        	get
        	{
         		return this.iCODIGOPOSTAL;
        	}
        	set
        	{
        		this.iCODIGOPOSTAL= value;
        		this.isnull["ICODIGOPOSTAL"]=false;
        	}
        }

 	private string iRAZON_SOCIAL;
        public string IRAZON_SOCIAL
        { 
        	get
        	{
         		return this.iRAZON_SOCIAL;
        	}
        	set
        	{
        		this.iRAZON_SOCIAL= value;
        		this.isnull["IRAZON_SOCIAL"]=false;
        	}
        }

 	private string iTELEFONO;
        public string ITELEFONO
        { 
        	get
        	{
         		return this.iTELEFONO;
        	}
        	set
        	{
        		this.iTELEFONO= value;
        		this.isnull["ITELEFONO"]=false;
        	}
        }

 	private string iCIUDAD;
        public string ICIUDAD
        { 
        	get
        	{
         		return this.iCIUDAD;
        	}
        	set
        	{
        		this.iCIUDAD= value;
        		this.isnull["ICIUDAD"]=false;
        	}
        }

 	private string iESTADO;
        public string IESTADO
        { 
        	get
        	{
         		return this.iESTADO;
        	}
        	set
        	{
        		this.iESTADO= value;
        		this.isnull["IESTADO"]=false;
        	}
        }

 	private string iMUNICIPIO;
        public string IMUNICIPIO
        { 
        	get
        	{
         		return this.iMUNICIPIO;
        	}
        	set
        	{
        		this.iMUNICIPIO= value;
        		this.isnull["IMUNICIPIO"]=false;
        	}
        }


        private int iTICKET;
        public int ITICKET
        {
            get
            {
                return this.iTICKET;
            }
            set
            {
                this.iTICKET = value;
                this.isnull["ITICKET"] = false;
            }
        }



        private long iSUCURSALTID;
        public long ISUCURSALTID
        {
            get
            {
                return this.iSUCURSALTID;
            }
            set
            {
                this.iSUCURSALTID = value;
                this.isnull["ISUCURSALTID"] = false;
            }
        }


        private long iVENDEDORID;
        public long IVENDEDORID
        {
            get
            {
                return this.iVENDEDORID;
            }
            set
            {
                this.iVENDEDORID = value;
                this.isnull["IVENDEDORID"] = false;
            }
        }



        private long iORIGENFISCALID;
        public long IORIGENFISCALID
        {
            get
            {
                return this.iORIGENFISCALID;
            }
            set
            {
                this.iORIGENFISCALID = value;
                this.isnull["IORIGENFISCALID"] = false;
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
                this.iFECHA = value;
                this.isnull["IFECHA"] = false;
            }
        }


        private string iVENDEDOR;
        public string IVENDEDOR
        {
            get
            {
                return this.iVENDEDOR;
            }
            set
            {
                this.iVENDEDOR = value;
                this.isnull["IVENDEDOR"] = false;
            }
        }


        private long iPERSONAAPARTADOID;
        public long IPERSONAAPARTADOID
        {
            get
            {
                return this.iPERSONAAPARTADOID;
            }
            set
            {
                this.iPERSONAAPARTADOID = value;
                this.isnull["IPERSONAAPARTADOID"] = false;
            }
        }


        private string iNUMEROEXTERIOR;
        public string INUMEROEXTERIOR
        {
            get
            {
                return this.iNUMEROEXTERIOR;
            }
            set
            {
                this.iNUMEROEXTERIOR = value;
                this.isnull["INUMEROEXTERIOR"] = false;
            }
        }


        private string iNUMEROINTERIOR;
        public string INUMEROINTERIOR
        {
            get
            {
                return this.iNUMEROINTERIOR;
            }
            set
            {
                this.iNUMEROINTERIOR = value;
                this.isnull["INUMEROINTERIOR"] = false;
            }
        }



        private string iREFERENCIA;
        public string IREFERENCIA
        {
            get
            {
                return this.iREFERENCIA;
            }
            set
            {
                this.iREFERENCIA = value;
                this.isnull["IREFERENCIA"] = false;
            }
        }



        private int iDOCTOREF_FOLIO;
        public int IDOCTOREF_FOLIO
        {
            get
            {
                return this.iDOCTOREF_FOLIO;
            }
            set
            {
                this.iDOCTOREF_FOLIO = value;
                this.isnull["IDOCTOREF_FOLIO"] = false;
            }
        }



        private string iDOCTOREF_REFERENCIA;
        public string IDOCTOREF_REFERENCIA
        {
            get
            {
                return this.iDOCTOREF_REFERENCIA;
            }
            set
            {
                this.iDOCTOREF_REFERENCIA = value;
                this.isnull["IDOCTOREF_REFERENCIA"] = false;
            }
        }


        private long iSUBTIPODOCTOID;
        public long ISUBTIPODOCTOID
        {
            get
            {
                return this.iSUBTIPODOCTOID;
            }
            set
            {
                this.iSUBTIPODOCTOID = value;
                this.isnull["ISUBTIPODOCTOID"] = false;
            }
        }


        private long iALMACENTID;
        public long IALMACENTID
        {
            get
            {
                return this.iALMACENTID;
            }
            set
            {
                this.iALMACENTID = value;
                this.isnull["IALMACENTID"] = false;
            }
        }

        private string iOBSERVACION;
        public string IOBSERVACION
        {
            get
            {
                return this.iOBSERVACION;
            }
            set
            {
                this.iOBSERVACION = value;
                this.isnull["IOBSERVACION"] = false;
            }
        }



        private string iRUTAEMBARQUECLAVE;
        public string IRUTAEMBARQUECLAVE
        {
            get
            {
                return this.iRUTAEMBARQUECLAVE;
            }
            set
            {
                this.iRUTAEMBARQUECLAVE = value;
                this.isnull["IRUTAEMBARQUECLAVE"] = false;
            }
        }



        private string iRUTAEMBARQUENOMBRE;
        public string IRUTAEMBARQUENOMBRE
        {
            get
            {
                return this.iRUTAEMBARQUENOMBRE;
            }
            set
            {
                this.iRUTAEMBARQUENOMBRE = value;
                this.isnull["IRUTAEMBARQUENOMBRE"] = false;
            }
        }

        private string iORDENCOMPRA;
        public string IORDENCOMPRA
        {
            get
            {
                return this.iORDENCOMPRA;
            }
            set
            {
                this.iORDENCOMPRA = value;
                this.isnull["IORDENCOMPRA"] = false;
            }
        }




        private string iALMACENCLAVE;
        public string IALMACENCLAVE
        {
            get
            {
                return this.iALMACENCLAVE;
            }
            set
            {
                this.iALMACENCLAVE = value;
                this.isnull["IALMACENCLAVE"] = false;
            }
        }



        private string iALMACENNOMBRE;
        public string IALMACENNOMBRE
        {
            get
            {
                return this.iALMACENNOMBRE;
            }
            set
            {
                this.iALMACENNOMBRE = value;
                this.isnull["IALMACENNOMBRE"] = false;
            }
        }

        public CTICKET_HEADERBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IDOCTOID",true);
	

			isnull.Add("IESTATUSDOCTOID",true);
	

			isnull.Add("IALMACENID",true);
	

			isnull.Add("ISUCURSALID",true);
	

			isnull.Add("IPERSONAID",true);
	

			isnull.Add("ITIPODOCTOID",true);
	

			isnull.Add("ITOTAL",true);
	

			isnull.Add("INOMBRE",true);
	

			isnull.Add("IDESCRIPCION",true);
	

			isnull.Add("IRFC",true);
	

			isnull.Add("ICOLONIA",true);
	

			isnull.Add("IDOMICICIO",true);
	

			isnull.Add("ICODIGOPOSTAL",true);
	

			isnull.Add("IRAZON_SOCIAL",true);
	

			isnull.Add("ITELEFONO",true);
	

			isnull.Add("ICIUDAD",true);
	

			isnull.Add("IESTADO",true);
	

			isnull.Add("IMUNICIPIO",true);

            isnull.Add("ITICKET", true);

            isnull.Add("ISUCURSALTID", true);

            isnull.Add("IVENDEDORID", true);

            isnull.Add("IORIGENFISCALID", true);

            isnull.Add("IFECHA", true);

            isnull.Add("IVENDEDOR", true);

            isnull.Add("IPERSONAAPARTADOID", true);

            isnull.Add("INUMEROEXTERIOR", true);

            isnull.Add("INUMEROINTERIOR", true);

            isnull.Add("IREFERENCIA", true);

            isnull.Add("IDOCTOREF_FOLIO", true);
            isnull.Add("IDOCTOREF_REFERENCIA", true);

            isnull.Add("ISUBTIPODOCTOID", true);

            isnull.Add("IALMACENTID", true);

            isnull.Add("IOBSERVACION", true);

            isnull.Add("IRUTAEMBARQUECLAVE", true);

            isnull.Add("IRUTAEMBARQUENOMBRE", true);

            isnull.Add("IORDENCOMPRA", true);

            isnull.Add("IALMACENCLAVE", true);

            isnull.Add("IALMACENNOMBRE", true);



        }

		

	}
}
