using System;
using System.Collections;
namespace iPosBusinessEntity
{
	public class CSUCURSALBE
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

 	private object iMEMO;
        public object IMEMO
        { 
        	get
        	{
         		return this.iMEMO;
        	}
        	set
        	{
        		this.iMEMO= value;
        		this.isnull["IMEMO"]=false;
        	}
        }




        private long iGRUPOSUCURSALID;
        public long IGRUPOSUCURSALID
        {
            get
            {
                return this.iGRUPOSUCURSALID;
            }
            set
            {
                this.iGRUPOSUCURSALID = value;
                this.isnull["IGRUPOSUCURSALID"] = false;
            }
        }

        private string iLISTA_PRECIO_TRASPASO;
        public string ILISTA_PRECIO_TRASPASO
        {
            get
            {
                return this.iLISTA_PRECIO_TRASPASO;
            }
            set
            {
                this.iLISTA_PRECIO_TRASPASO = value;
                this.isnull["ILISTA_PRECIO_TRASPASO"] = false;
            }
        }

        private long iMAXDOCTOSPENDIENTES;
        public long IMAXDOCTOSPENDIENTES
        {
            get
            {
                return this.iMAXDOCTOSPENDIENTES;
            }
            set
            {
                this.iMAXDOCTOSPENDIENTES = value;
                this.isnull["IMAXDOCTOSPENDIENTES"] = false;
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



        private long iPRECIORECEPCIONTRASLADO;
        public long IPRECIORECEPCIONTRASLADO
        {
            get
            {
                return this.iPRECIORECEPCIONTRASLADO;
            }
            set
            {
                this.iPRECIORECEPCIONTRASLADO = value;
                this.isnull["IPRECIORECEPCIONTRASLADO"] = false;
            }
        }



        private string iMOSTRARPRECIOREAL;
        public string IMOSTRARPRECIOREAL
        {
            get
            {
                return this.iMOSTRARPRECIOREAL;
            }
            set
            {
                this.iMOSTRARPRECIOREAL = value;
                this.isnull["IMOSTRARPRECIOREAL"] = false;
            }
        }


        private long iPRECIOENVIOTRASLADO;
        public long IPRECIOENVIOTRASLADO
        {
            get
            {
                return this.iPRECIOENVIOTRASLADO;
            }
            set
            {
                this.iPRECIOENVIOTRASLADO = value;
                this.isnull["IPRECIOENVIOTRASLADO"] = false;
            }
        }



        private string iCLIENTECLAVE;
        public string ICLIENTECLAVE
        {
            get
            {
                return this.iCLIENTECLAVE;
            }
            set
            {
                this.iCLIENTECLAVE = value;
                this.isnull["ICLIENTECLAVE"] = false;
            }
        }



        private string iPROVEEDORCLAVE;
        public string IPROVEEDORCLAVE
        {
            get
            {
                return this.iPROVEEDORCLAVE;
            }
            set
            {
                this.iPROVEEDORCLAVE = value;
                this.isnull["IPROVEEDORCLAVE"] = false;
            }
        }



        private string iESFRANQUICIA;
        public string IESFRANQUICIA
        {
            get
            {
                return this.iESFRANQUICIA;
            }
            set
            {
                this.iESFRANQUICIA = value;
                this.isnull["IESFRANQUICIA"] = false;
            }
        }


        private string iPOR_FACT_ELECT;
        public string IPOR_FACT_ELECT
        {
            get
            {
                return this.iPOR_FACT_ELECT;
            }
            set
            {
                this.iPOR_FACT_ELECT = value;
                this.isnull["IPOR_FACT_ELECT"] = false;
            }
        }





        private string iENTREGACALLE;
        public string IENTREGACALLE
        {
            get
            {
                return this.iENTREGACALLE;
            }
            set
            {
                this.iENTREGACALLE = value;
                this.isnull["IENTREGACALLE"] = false;
            }
        }
        private string iENTREGANUMEROINTERIOR;
        public string IENTREGANUMEROINTERIOR
        {
            get
            {
                return this.iENTREGANUMEROINTERIOR;
            }
            set
            {
                this.iENTREGANUMEROINTERIOR = value;
                this.isnull["IENTREGANUMEROINTERIOR"] = false;
            }
        }
        private string iENTREGANUMEROEXTERIOR;
        public string IENTREGANUMEROEXTERIOR
        {
            get
            {
                return this.iENTREGANUMEROEXTERIOR;
            }
            set
            {
                this.iENTREGANUMEROEXTERIOR = value;
                this.isnull["IENTREGANUMEROEXTERIOR"] = false;
            }
        }
        private string iENTREGACOLONIA;
        public string IENTREGACOLONIA
        {
            get
            {
                return this.iENTREGACOLONIA;
            }
            set
            {
                this.iENTREGACOLONIA = value;
                this.isnull["IENTREGACOLONIA"] = false;
            }
        }
        private string iENTREGAMUNICIPIO;
        public string IENTREGAMUNICIPIO
        {
            get
            {
                return this.iENTREGAMUNICIPIO;
            }
            set
            {
                this.iENTREGAMUNICIPIO = value;
                this.isnull["IENTREGAMUNICIPIO"] = false;
            }
        }
        private string iENTREGAESTADO;
        public string IENTREGAESTADO
        {
            get
            {
                return this.iENTREGAESTADO;
            }
            set
            {
                this.iENTREGAESTADO = value;
                this.isnull["IENTREGAESTADO"] = false;
            }
        }
        private string iENTREGACODIGOPOSTAL;
        public string IENTREGACODIGOPOSTAL
        {
            get
            {
                return this.iENTREGACODIGOPOSTAL;
            }
            set
            {
                this.iENTREGACODIGOPOSTAL = value;
                this.isnull["IENTREGACODIGOPOSTAL"] = false;
            }
        }



        private string iSURTIDOR;
        public string ISURTIDOR
        {
            get
            {
                return this.iSURTIDOR;
            }
            set
            {
                this.iSURTIDOR = value;
                this.isnull["ISURTIDOR"] = false;
            }
        }


        private decimal iPORC_AUMENTO_PRECIO;
        public decimal IPORC_AUMENTO_PRECIO
        {
            get
            {
                return this.iPORC_AUMENTO_PRECIO;
            }
            set
            {
                this.iPORC_AUMENTO_PRECIO = value;
                this.isnull["IPORC_AUMENTO_PRECIO"] = false;
            }
        }


        private string iRUTARESPALDOORIGEN;
        public string IRUTARESPALDOORIGEN
        {
            get
            {
                return this.iRUTARESPALDOORIGEN;
            }
            set
            {
                this.iRUTARESPALDOORIGEN = value;
                this.isnull["IRUTARESPALDOORIGEN"] = false;
            }
        }


        private string iRUTARESPALDODESTINO;
        public string IRUTARESPALDODESTINO
        {
            get
            {
                return this.iRUTARESPALDODESTINO;
            }
            set
            {
                this.iRUTARESPALDODESTINO = value;
                this.isnull["IRUTARESPALDODESTINO"] = false;
            }
        }


        private string iMANEJAPRECIOXDESCUENTO;
        public string IMANEJAPRECIOXDESCUENTO 
        {
            get
            {
                return this.iMANEJAPRECIOXDESCUENTO;
            }
            set
            {
                this.iMANEJAPRECIOXDESCUENTO = value;
                this.isnull["IMANEJAPRECIOXDESCUENTO"] = false;
            }
        }



        private string iPREFIJOPRECIOXDESCUENTO;
        public string IPREFIJOPRECIOXDESCUENTO
        {
            get
            {
                return this.iPREFIJOPRECIOXDESCUENTO;
            }
            set
            {
                this.iPREFIJOPRECIOXDESCUENTO = value;
                this.isnull["IPREFIJOPRECIOXDESCUENTO"] = false;
            }
        }


        private string iNOMBRERESPALDOBD;
        public string INOMBRERESPALDOBD
        {
            get
            {
                return this.iNOMBRERESPALDOBD;
            }
            set
            {
                this.iNOMBRERESPALDOBD = value;
                this.isnull["INOMBRERESPALDOBD"] = false;
            }
        }



        private string iBANCOCLAVE;
        public string IBANCOCLAVE
        {
            get
            {
                return this.iBANCOCLAVE;
            }
            set
            {
                this.iBANCOCLAVE = value;
                this.isnull["IBANCOCLAVE"] = false;
            }
        }

        private string iCUENTAREFERENCIA;
        public string ICUENTAREFERENCIA
        {
            get
            {
                return this.iCUENTAREFERENCIA;
            }
            set
            {
                this.iCUENTAREFERENCIA = value;
                this.isnull["ICUENTAREFERENCIA"] = false;
            }
        }


        private string iRUTARESPALDORED;
        public string IRUTARESPALDORED
        {
            get
            {
                return this.iRUTARESPALDORED;
            }
            set
            {
                this.iRUTARESPALDORED = value;
                this.isnull["IRUTARESPALDORED"] = false;
            }
        }


        private string iCUENTAPOLIZA;
        public string ICUENTAPOLIZA
        {
            get
            {
                return this.iCUENTAPOLIZA;
            }
            set
            {
                this.iCUENTAPOLIZA = value;
                this.isnull["ICUENTAPOLIZA"] = false;
            }
        }


        private string iLISTAPRECIOCLAVE;
        public string ILISTAPRECIOCLAVE
        {
            get
            {
                return this.iLISTAPRECIOCLAVE;
            }
            set
            {
                this.iLISTAPRECIOCLAVE = value;
                this.isnull["ILISTAPRECIOCLAVE"] = false;
            }
        }


        private string iEMPPROV;
        public string IEMPPROV
        {
            get
            {
                return this.iEMPPROV;
            }
            set
            {
                this.iEMPPROV = value;
                this.isnull["IEMPPROV"] = false;
            }
        }




        private string iIMNUPROD;
        public string IIMNUPROD
        {
            get
            {
                return this.iIMNUPROD;
            }
            set
            {
                this.iIMNUPROD = value;
                this.isnull["IIMNUPROD"] = false;
            }
        }




        private long iENTREGA_SAT_COLONIAID;
        public long IENTREGA_SAT_COLONIAID
        {
            get
            {
                return this.iENTREGA_SAT_COLONIAID;
            }
            set
            {
                this.iENTREGA_SAT_COLONIAID = value;
                this.isnull["IENTREGA_SAT_COLONIAID"] = false;
            }
        }

        private long iENTREGA_SAT_LOCALIDADID;
        public long IENTREGA_SAT_LOCALIDADID
        {
            get
            {
                return this.iENTREGA_SAT_LOCALIDADID;
            }
            set
            {
                this.iENTREGA_SAT_LOCALIDADID = value;
                this.isnull["IENTREGA_SAT_LOCALIDADID"] = false;
            }
        }

        private long iENTREGA_SAT_MUNICIPIOID;
        public long IENTREGA_SAT_MUNICIPIOID
        {
            get
            {
                return this.iENTREGA_SAT_MUNICIPIOID;
            }
            set
            {
                this.iENTREGA_SAT_MUNICIPIOID = value;
                this.isnull["IENTREGA_SAT_MUNICIPIOID"] = false;
            }
        }

        private decimal iENTREGA_DISTANCIA;
        public decimal IENTREGA_DISTANCIA
        {
            get
            {
                return this.iENTREGA_DISTANCIA;
            }
            set
            {
                this.iENTREGA_DISTANCIA = value;
                this.isnull["IENTREGA_DISTANCIA"] = false;
            }
        }

        private string iENTREGAREFERENCIADOM;
        public string IENTREGAREFERENCIADOM
        {
            get
            {
                return this.iENTREGAREFERENCIADOM;
            }
            set
            {
                this.iENTREGAREFERENCIADOM = value;
                this.isnull["IENTREGAREFERENCIADOM"] = false;
            }
        }

        public CSUCURSALBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IID",true);
	

			isnull.Add("IACTIVO",true);
	

			isnull.Add("ICREADO",true);
	

			isnull.Add("ICREADOPOR_USERID",true);
	

			isnull.Add("IMODIFICADO",true);
	

			isnull.Add("IMODIFICADOPOR_USERID",true);
	

			isnull.Add("ICLAVE",true);
	

			isnull.Add("INOMBRE",true);
	

			isnull.Add("IDESCRIPCION",true);
	

			isnull.Add("IMEMO",true);


            isnull.Add("IGRUPOSUCURSALID", true);

            isnull.Add("ILISTA_PRECIO_TRASPASO", true);

            isnull.Add("IMAXDOCTOSPENDIENTES", true);



            isnull.Add("IESMATRIZ", true);


            isnull.Add("IPRECIORECEPCIONTRASLADO", true);

            isnull.Add("IMOSTRARPRECIOREAL", true);

            isnull.Add("IPRECIOENVIOTRASLADO", true);

            isnull.Add("ICLIENTECLAVE", true);
            isnull.Add("IPROVEEDORCLAVE", true);
                   


            isnull.Add("IESFRANQUICIA", true);
            isnull.Add("IPOR_FACT_ELECT", true);

            isnull.Add("IENTREGACALLE", true);
            isnull.Add("IENTREGANUMEROINTERIOR", true);
            isnull.Add("IENTREGANUMEROEXTERIOR", true);
            isnull.Add("IENTREGACOLONIA", true);
            isnull.Add("IENTREGAMUNICIPIO", true);
            isnull.Add("IENTREGAESTADO", true);
            isnull.Add("IENTREGACODIGOPOSTAL", true);

            isnull.Add("ISURTIDOR", true);



            isnull.Add("IPORC_AUMENTO_PRECIO", true);

            isnull.Add("IRUTARESPALDOORIGEN", true);

            isnull.Add("IRUTARESPALDODESTINO", true);

            isnull.Add("IMANEJAPRECIOXDESCUENTO", true);

            isnull.Add("IPREFIJOPRECIOXDESCUENTO", true);

            isnull.Add("INOMBRERESPALDOBD", true);

            isnull.Add("IBANCOCLAVE", true);

            isnull.Add("ICUENTAREFERENCIA", true);

            isnull.Add("IRUTARESPALDORED", true);

            isnull.Add("ICUENTAPOLIZA", true);


            isnull.Add("ILISTAPRECIOCLAVE", true);

            isnull.Add("IEMPPROV", true);


            isnull.Add("IIMNUPROD", true);


            isnull.Add("IENTREGA_SAT_COLONIAID", true);


            isnull.Add("IENTREGA_SAT_LOCALIDADID", true);


            isnull.Add("IENTREGA_SAT_MUNICIPIOID", true);


            isnull.Add("IENTREGA_DISTANCIA", true);


            isnull.Add("IENTREGAREFERENCIADOM", true);




        }

		

	}
}
