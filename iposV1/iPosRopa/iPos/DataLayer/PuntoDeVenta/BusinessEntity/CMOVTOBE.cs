
using System;
using System.Collections;
namespace iPosBusinessEntity
{
	public class CMOVTOBE
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

 	private short iPARTIDA;
        public short IPARTIDA
        { 
        	get
        	{
         		return this.iPARTIDA;
        	}
        	set
        	{
        		this.iPARTIDA= value;
        		this.isnull["IPARTIDA"]=false;
        	}
        }

 	private long iESTATUSMOVTOID;
        public long IESTATUSMOVTOID
        { 
        	get
        	{
         		return this.iESTATUSMOVTOID;
        	}
        	set
        	{
        		this.iESTATUSMOVTOID= value;
        		this.isnull["IESTATUSMOVTOID"]=false;
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

 	private object iFECHAHORA;
        public object IFECHAHORA
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

 	private long iPRODUCTOID;
        public long IPRODUCTOID
        { 
        	get
        	{
         		return this.iPRODUCTOID;
        	}
        	set
        	{
        		this.iPRODUCTOID= value;
        		this.isnull["IPRODUCTOID"]=false;
        	}
        }

 	private string iLOTE;
        public string ILOTE
        { 
        	get
        	{
         		return this.iLOTE;
        	}
        	set
        	{
        		this.iLOTE= value;
        		this.isnull["ILOTE"]=false;
        	}
        }

 	private DateTime iFECHAVENCE;
        public DateTime IFECHAVENCE
        { 
        	get
        	{
         		return this.iFECHAVENCE;
        	}
        	set
        	{
        		this.iFECHAVENCE= value;
        		this.isnull["IFECHAVENCE"]=false;
        	}
        }

 	private decimal iCANTIDAD;
        public decimal ICANTIDAD
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

 	private decimal iCANTIDADSURTIDA;
        public decimal ICANTIDADSURTIDA
        { 
        	get
        	{
         		return this.iCANTIDADSURTIDA;
        	}
        	set
        	{
        		this.iCANTIDADSURTIDA= value;
        		this.isnull["ICANTIDADSURTIDA"]=false;
        	}
        }

 	private decimal iCANTIDADFALTANTE;
        public decimal ICANTIDADFALTANTE
        { 
        	get
        	{
         		return this.iCANTIDADFALTANTE;
        	}
        	set
        	{
        		this.iCANTIDADFALTANTE= value;
        		this.isnull["ICANTIDADFALTANTE"]=false;
        	}
        }

 	private decimal iCANTIDADDEVUELTA;
        public decimal ICANTIDADDEVUELTA
        { 
        	get
        	{
         		return this.iCANTIDADDEVUELTA;
        	}
        	set
        	{
        		this.iCANTIDADDEVUELTA= value;
        		this.isnull["ICANTIDADDEVUELTA"]=false;
        	}
        }

 	private decimal iCANTIDADSALDO;
        public decimal ICANTIDADSALDO
        { 
        	get
        	{
         		return this.iCANTIDADSALDO;
        	}
        	set
        	{
        		this.iCANTIDADSALDO= value;
        		this.isnull["ICANTIDADSALDO"]=false;
        	}
        }

 	private decimal iPRECIOLISTA;
        public decimal IPRECIOLISTA
        { 
        	get
        	{
         		return this.iPRECIOLISTA;
        	}
        	set
        	{
        		this.iPRECIOLISTA= value;
        		this.isnull["IPRECIOLISTA"]=false;
        	}
        }

 	private decimal iDESCUENTOPORCENTAJE;
        public decimal IDESCUENTOPORCENTAJE
        { 
        	get
        	{
         		return this.iDESCUENTOPORCENTAJE;
        	}
        	set
        	{
        		this.iDESCUENTOPORCENTAJE= value;
        		this.isnull["IDESCUENTOPORCENTAJE"]=false;
        	}
        }

 	private decimal iDESCUENTO;
        public decimal IDESCUENTO
        { 
        	get
        	{
         		return this.iDESCUENTO;
        	}
        	set
        	{
        		this.iDESCUENTO= value;
        		this.isnull["IDESCUENTO"]=false;
        	}
        }

 	private decimal iPRECIO;
        public decimal IPRECIO
        { 
        	get
        	{
         		return this.iPRECIO;
        	}
        	set
        	{
        		this.iPRECIO= value;
        		this.isnull["IPRECIO"]=false;
        	}
        }

 	private decimal iIMPORTE;
        public decimal IIMPORTE
        { 
        	get
        	{
         		return this.iIMPORTE;
        	}
        	set
        	{
        		this.iIMPORTE= value;
        		this.isnull["IIMPORTE"]=false;
        	}
        }

 	private decimal iSUBTOTAL;
        public decimal ISUBTOTAL
        { 
        	get
        	{
         		return this.iSUBTOTAL;
        	}
        	set
        	{
        		this.iSUBTOTAL= value;
        		this.isnull["ISUBTOTAL"]=false;
        	}
        }

 	private decimal iIVA;
        public decimal IIVA
        { 
        	get
        	{
         		return this.iIVA;
        	}
        	set
        	{
        		this.iIVA= value;
        		this.isnull["IIVA"]=false;
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

 	private decimal iCOSTO;
        public decimal ICOSTO
        { 
        	get
        	{
         		return this.iCOSTO;
        	}
        	set
        	{
        		this.iCOSTO= value;
        		this.isnull["ICOSTO"]=false;
        	}
        }

 	private decimal iCOSTOIMPORTE;
        public decimal ICOSTOIMPORTE
        { 
        	get
        	{
         		return this.iCOSTOIMPORTE;
        	}
        	set
        	{
        		this.iCOSTOIMPORTE= value;
        		this.isnull["ICOSTOIMPORTE"]=false;
        	}
        }

 	private decimal iCARGO;
        public decimal ICARGO
        { 
        	get
        	{
         		return this.iCARGO;
        	}
        	set
        	{
        		this.iCARGO= value;
        		this.isnull["ICARGO"]=false;
        	}
        }

 	private decimal iABONO;
        public decimal IABONO
        { 
        	get
        	{
         		return this.iABONO;
        	}
        	set
        	{
        		this.iABONO= value;
        		this.isnull["IABONO"]=false;
        	}
        }

 	private decimal iSALDO;
        public decimal ISALDO
        { 
        	get
        	{
         		return this.iSALDO;
        	}
        	set
        	{
        		this.iSALDO= value;
        		this.isnull["ISALDO"]=false;
        	}
        }




        private long iTIPODIFERENCIAINVENTARIOID;
        public long ITIPODIFERENCIAINVENTARIOID
        {
            get
            {
                return this.iTIPODIFERENCIAINVENTARIOID;
            }
            set
            {
                this.iTIPODIFERENCIAINVENTARIOID = value;
                this.isnull["ITIPODIFERENCIAINVENTARIOID"] = false;
            }
        }




        private string iEXISTENCIASEXPORTADAS;
        public string IEXISTENCIASEXPORTADAS
        {
            get
            {
                return this.iEXISTENCIASEXPORTADAS;
            }
            set
            {
                this.iEXISTENCIASEXPORTADAS = value;
                this.isnull["IEXISTENCIASEXPORTADAS"] = false;
            }
        }


        private decimal iCAJAS;
        public decimal ICAJAS
        {
            get
            {
                return this.iCAJAS;
            }
            set
            {
                this.iCAJAS = value;
                this.isnull["ICAJAS"] = false;
            }
        }


        private decimal iPIEZAS;
        public decimal IPIEZAS
        {
            get
            {
                return this.iPIEZAS;
            }
            set
            {
                this.iPIEZAS = value;
                this.isnull["IPIEZAS"] = false;
            }
        }


        private decimal iPZACAJA;
        public decimal IPZACAJA
        {
            get
            {
                return this.iPZACAJA;
            }
            set
            {
                this.iPZACAJA = value;
                this.isnull["IPZACAJA"] = false;
            }
        }



        private string iRAZONDESCUENTOCAJERO;
        public string IRAZONDESCUENTOCAJERO
        {
            get
            {
                return this.iRAZONDESCUENTOCAJERO;
            }
            set
            {
                this.iRAZONDESCUENTOCAJERO = value;
                this.isnull["IRAZONDESCUENTOCAJERO"] = false;
            }
        }




        private string iDESCRIPCION1;
        public string IDESCRIPCION1
        {
            get
            {
                return this.iDESCRIPCION1;
            }
            set
            {
                this.iDESCRIPCION1 = value;
                this.isnull["IDESCRIPCION1"] = false;
            }
        }


        private string iDESCRIPCION2;
        public string IDESCRIPCION2
        {
            get
            {
                return this.iDESCRIPCION2;
            }
            set
            {
                this.iDESCRIPCION2 = value;
                this.isnull["IDESCRIPCION2"] = false;
            }
        }


        private string iDESCRIPCION3;
        public string IDESCRIPCION3
        {
            get
            {
                return this.iDESCRIPCION3;
            }
            set
            {
                this.iDESCRIPCION3 = value;
                this.isnull["IDESCRIPCION3"] = false;
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



        private decimal iTASAIEPS;
        public decimal ITASAIEPS
        {
            get
            {
                return this.iTASAIEPS;
            }
            set
            {
                this.iTASAIEPS = value;
                this.isnull["ITASAIEPS"] = false;
            }
        }


        private decimal iIEPS;
        public decimal IIEPS
        {
            get
            {
                return this.iIEPS;
            }
            set
            {
                this.iIEPS = value;
                this.isnull["IIEPS"] = false;
            }
        }

        private decimal iTASAIMPUESTO;
        public decimal ITASAIMPUESTO
        {
            get
            {
                return this.iTASAIMPUESTO;
            }
            set
            {
                this.iTASAIMPUESTO = value;
                this.isnull["ITASAIMPUESTO"] = false;
            }
        }

        private decimal iIMPUESTO;
        public decimal IIMPUESTO
        {
            get
            {
                return this.iIMPUESTO;
            }
            set
            {
                this.iIMPUESTO = value;
                this.isnull["IIMPUESTO"] = false;
            }
        }



        private string iCLAVEPROD;
        public string ICLAVEPROD
        {
            get
            {
                return this.iCLAVEPROD;
            }
            set
            {
                this.iCLAVEPROD = value;
                this.isnull["ICLAVEPROD"] = false;
            }
        }


        private long iMOVTOADJUNTOAID;
        public long IMOVTOADJUNTOAID
        {
            get
            {
                return this.iMOVTOADJUNTOAID;
            }
            set
            {
                this.iMOVTOADJUNTOAID  = value;
                this.isnull["IMOVTOADJUNTOAID"] = false;
            }
        }





        private long iLOTEIMPORTADO;
        public long ILOTEIMPORTADO
        {
            get
            {
                return this.iLOTEIMPORTADO;
            }
            set
            {
                this.iLOTEIMPORTADO = value;
                this.isnull["ILOTEIMPORTADO"] = false;
            }
        }



        private decimal iCOSTOENDOLAR;
        public decimal ICOSTOENDOLAR
        {
            get
            {
                return this.iCOSTOENDOLAR;
            }
            set
            {
                this.iCOSTOENDOLAR = value;
                this.isnull["ICOSTOENDOLAR"] = false;
            }
        }



        private decimal iCOMISION;
        public decimal ICOMISION
        {
            get
            {
                return this.iCOMISION;
            }
            set
            {
                this.iCOMISION = value;
                this.isnull["ICOMISION"] = false;
            }
        }



        private decimal iCOMISIONPORC;
        public decimal ICOMISIONPORC
        {
            get
            {
                return this.iCOMISIONPORC;
            }
            set
            {
                this.iCOMISIONPORC = value;
                this.isnull["ICOMISIONPORC"] = false;
            }
        }




        private decimal iCANTIDADREVISADA;
        public decimal ICANTIDADREVISADA
        {
            get
            {
                return this.iCANTIDADREVISADA;
            }
            set
            {
                this.iCANTIDADREVISADA = value;
                this.isnull["ICANTIDADREVISADA"] = false;
            }
        }


        private long iLISTAPRECIOID;
        public long ILISTAPRECIOID
        {
            get
            {
                return this.iLISTAPRECIOID;
            }
            set
            {
                this.iLISTAPRECIOID = value;
                this.isnull["ILISTAPRECIOID"] = false;
            }
        }



        private long iTIPOMAYOREOLINEAID;
        public long ITIPOMAYOREOLINEAID
        {
            get
            {
                return this.iTIPOMAYOREOLINEAID;
            }
            set
            {
                this.iTIPOMAYOREOLINEAID = value;
                this.isnull["ITIPOMAYOREOLINEAID"] = false;
            }
        }


        public CMOVTOBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IID",true);
	

			isnull.Add("IACTIVO",true);
	

			isnull.Add("ICREADO",true);
	

			isnull.Add("ICREADOPOR_USERID",true);
	

			isnull.Add("IMODIFICADO",true);
	

			isnull.Add("IMODIFICADOPOR_USERID",true);
	

			isnull.Add("IDOCTOID",true);
	

			isnull.Add("IPARTIDA",true);
	

			isnull.Add("IESTATUSMOVTOID",true);
	

			isnull.Add("IFECHA",true);
	

			isnull.Add("IFECHAHORA",true);
	

			isnull.Add("IPRODUCTOID",true);
	

			isnull.Add("ILOTE",true);
	

			isnull.Add("IFECHAVENCE",true);
	

			isnull.Add("ICANTIDAD",true);
	

			isnull.Add("ICANTIDADSURTIDA",true);
	

			isnull.Add("ICANTIDADFALTANTE",true);
	

			isnull.Add("ICANTIDADDEVUELTA",true);
	

			isnull.Add("ICANTIDADSALDO",true);
	

			isnull.Add("IPRECIOLISTA",true);
	

			isnull.Add("IDESCUENTOPORCENTAJE",true);
	

			isnull.Add("IDESCUENTO",true);
	

			isnull.Add("IPRECIO",true);
	

			isnull.Add("IIMPORTE",true);
	

			isnull.Add("ISUBTOTAL",true);
	

			isnull.Add("IIVA",true);
	

			isnull.Add("ITOTAL",true);
	

			isnull.Add("ICOSTO",true);
	

			isnull.Add("ICOSTOIMPORTE",true);
	

			isnull.Add("ICARGO",true);
	

			isnull.Add("IABONO",true);
	

			isnull.Add("ISALDO",true);


            isnull.Add("ITIPODIFERENCIAINVENTARIOID", true);

            isnull.Add("EXISTENCIASEXPORTADAS", true);

            isnull.Add("ICAJAS", true);
            isnull.Add("IPIEZAS", true);
            isnull.Add("IPZACAJA", true);

            isnull.Add("IRAZONDESCUENTOCAJERO", true);

            isnull.Add("IDESCRIPCION1", true);
            isnull.Add("IDESCRIPCION2", true);
            isnull.Add("IDESCRIPCION3", true);


            isnull.Add("IORDEN", true);



            isnull.Add("ITASAIEPS", true);
            isnull.Add("IIMPUESTO", true);

            isnull.Add("ITASAIMPUESTO", true);
            isnull.Add("IIEPS", true);

            isnull.Add("ICLAVEPROD", true);

            isnull.Add("IMOVTOADJUNTOAID", true);

            isnull.Add("ILOTEIMPORTADO", true);

            isnull.Add("ICOSTOENDOLAR", true);

            isnull.Add("ICOMISIONPORC", true);
            isnull.Add("ICOMISION", true);

            isnull.Add("ICANTIDADREVISADA", true);


            isnull.Add("ILISTAPRECIOID", true);


            isnull.Add("ITIPOMAYOREOLINEAID", true);



        }

		

	}
}
