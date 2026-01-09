
using System;
using System.Collections;
namespace iPosBusinessEntity
{
	public class CCORTEBE
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

 	private long iCAJAID;
        public long ICAJAID
        { 
        	get
        	{
         		return this.iCAJAID;
        	}
        	set
        	{
        		this.iCAJAID= value;
        		this.isnull["ICAJAID"]=false;
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

 	private long iTURNOID;
        public long ITURNOID
        { 
        	get
        	{
         		return this.iTURNOID;
        	}
        	set
        	{
        		this.iTURNOID= value;
        		this.isnull["ITURNOID"]=false;
        	}
        }

 	private DateTime iFECHACORTE;
        public DateTime IFECHACORTE
        { 
        	get
        	{
         		return this.iFECHACORTE;
        	}
        	set
        	{
        		this.iFECHACORTE= value;
        		this.isnull["IFECHACORTE"]=false;
        	}
        }

 	private object iINICIA;
        public object IINICIA
        { 
        	get
        	{
         		return this.iINICIA;
        	}
        	set
        	{
        		this.iINICIA= value;
        		this.isnull["IINICIA"]=false;
        	}
        }

 	private object iTERMINA;
        public object ITERMINA
        { 
        	get
        	{
         		return this.iTERMINA;
        	}
        	set
        	{
        		this.iTERMINA= value;
        		this.isnull["ITERMINA"]=false;
        	}
        }

 	private decimal iSALDOINICIAL;
        public decimal ISALDOINICIAL
        { 
        	get
        	{
         		return this.iSALDOINICIAL;
        	}
        	set
        	{
        		this.iSALDOINICIAL= value;
        		this.isnull["ISALDOINICIAL"]=false;
        	}
        }

 	private decimal iINGRESO;
        public decimal IINGRESO
        { 
        	get
        	{
         		return this.iINGRESO;
        	}
        	set
        	{
        		this.iINGRESO= value;
        		this.isnull["IINGRESO"]=false;
        	}
        }

 	private decimal iEGRESO;
        public decimal IEGRESO
        { 
        	get
        	{
         		return this.iEGRESO;
        	}
        	set
        	{
        		this.iEGRESO= value;
        		this.isnull["IEGRESO"]=false;
        	}
        }

 	private decimal iDEVOLUCION;
        public decimal IDEVOLUCION
        { 
        	get
        	{
         		return this.iDEVOLUCION;
        	}
        	set
        	{
        		this.iDEVOLUCION= value;
        		this.isnull["IDEVOLUCION"]=false;
        	}
        }

 	private decimal iAPORTACION;
        public decimal IAPORTACION
        { 
        	get
        	{
         		return this.iAPORTACION;
        	}
        	set
        	{
        		this.iAPORTACION= value;
        		this.isnull["IAPORTACION"]=false;
        	}
        }

 	private decimal iRETIRO;
        public decimal IRETIRO
        { 
        	get
        	{
         		return this.iRETIRO;
        	}
        	set
        	{
        		this.iRETIRO= value;
        		this.isnull["IRETIRO"]=false;
        	}
        }

 	private decimal iSALDOFINAL;
        public decimal ISALDOFINAL
        { 
        	get
        	{
         		return this.iSALDOFINAL;
        	}
        	set
        	{
        		this.iSALDOFINAL= value;
        		this.isnull["ISALDOFINAL"]=false;
        	}
        }

 	private int iNUMEROTICKETS;
        public int INUMEROTICKETS
        { 
        	get
        	{
         		return this.iNUMEROTICKETS;
        	}
        	set
        	{
        		this.iNUMEROTICKETS= value;
        		this.isnull["INUMEROTICKETS"]=false;
        	}
        }

 	private int iNUMERODEVOLUCIONES;
        public int INUMERODEVOLUCIONES
        { 
        	get
        	{
         		return this.iNUMERODEVOLUCIONES;
        	}
        	set
        	{
        		this.iNUMERODEVOLUCIONES= value;
        		this.isnull["INUMERODEVOLUCIONES"]=false;
        	}
        }

 	private decimal iSALDOREAL;
        public decimal ISALDOREAL
        { 
        	get
        	{
         		return this.iSALDOREAL;
        	}
        	set
        	{
        		this.iSALDOREAL= value;
        		this.isnull["ISALDOREAL"]=false;
        	}
        }

 	private decimal iDIFERENCIA;
        public decimal IDIFERENCIA
        { 
        	get
        	{
         		return this.iDIFERENCIA;
        	}
        	set
        	{
        		this.iDIFERENCIA= value;
        		this.isnull["IDIFERENCIA"]=false;
        	}
        }



        private decimal iINGRESOTARJETA;
        public decimal IINGRESOTARJETA
        {
            get
            {
                return this.iINGRESOTARJETA;
            }
            set
            {
                this.iINGRESOTARJETA = value;
                this.isnull["IINGRESOTARJETA"] = false;
            }
        }

        private decimal iINGRESOEFECTIVO;
        public decimal IINGRESOEFECTIVO
        {
            get
            {
                return this.iINGRESOEFECTIVO;
            }
            set
            {
                this.iINGRESOEFECTIVO = value;
                this.isnull["IINGRESOEFECTIVO"] = false;
            }
        }


        private decimal iINGRESOCREDITO;
        public decimal IINGRESOCREDITO
        {
            get
            {
                return this.iINGRESOCREDITO;
            }
            set
            {
                this.iINGRESOCREDITO = value;
                this.isnull["IINGRESOCREDITO"] = false;
            }
        }

        private decimal iINGRESOCHEQUE;
        public decimal IINGRESOCHEQUE
        {
            get
            {
                return this.iINGRESOCHEQUE;
            }
            set
            {
                this.iINGRESOCHEQUE = value;
                this.isnull["IINGRESOCHEQUE"] = false;
            }
        }

        private decimal iINGRESOVALE;
        public decimal IINGRESOVALE
        {
            get
            {
                return this.iINGRESOVALE;
            }
            set
            {
                this.iINGRESOVALE = value;
                this.isnull["IINGRESOVALE"] = false;
            }
        }


        private decimal iCAMBIOCHEQUE;
        public decimal ICAMBIOCHEQUE
        {
            get
            {
                return this.iCAMBIOCHEQUE;
            }
            set
            {
                this.iCAMBIOCHEQUE = value;
                this.isnull["ICAMBIOCHEQUE"] = false;
            }
        }


        private decimal iPAGOPROVEEDORES;
        public decimal IPAGOPROVEEDORES
        {
            get
            {
                return this.iPAGOPROVEEDORES;
            }
            set
            {
                this.iPAGOPROVEEDORES = value;
                this.isnull["IPAGOPROVEEDORES"] = false;
            }
        }



        private decimal iEGRESOTARJETA;
        public decimal IEGRESOTARJETA
        {
            get
            {
                return this.iEGRESOTARJETA;
            }
            set
            {
                this.iEGRESOTARJETA = value;
                this.isnull["IEGRESOTARJETA"] = false;
            }
        }

        private decimal iEGRESOEFECTIVO;
        public decimal IEGRESOEFECTIVO
        {
            get
            {
                return this.iEGRESOEFECTIVO;
            }
            set
            {
                this.iEGRESOEFECTIVO = value;
                this.isnull["IEGRESOEFECTIVO"] = false;
            }
        }


        private decimal iEGRESOCREDITO;
        public decimal IEGRESOCREDITO
        {
            get
            {
                return this.iEGRESOCREDITO;
            }
            set
            {
                this.iEGRESOCREDITO = value;
                this.isnull["IEGRESOCREDITO"] = false;
            }
        }

        private decimal iEGRESOCHEQUE;
        public decimal IEGRESOCHEQUE
        {
            get
            {
                return this.iEGRESOCHEQUE;
            }
            set
            {
                this.iEGRESOCHEQUE = value;
                this.isnull["IEGRESOCHEQUE"] = false;
            }
        }



        private decimal iEGRESOVALE;
        public decimal IEGRESOVALE
        {
            get
            {
                return this.iEGRESOVALE;
            }
            set
            {
                this.iEGRESOVALE = value;
                this.isnull["IEGRESOVALE"] = false;
            }
        }

        /*

        private decimal iINGRESOTARJETACONTADO;
        public decimal IINGRESOTARJETACONTADO
        {
            get
            {
                return this.iINGRESOTARJETACONTADO;
            }
            set
            {
                this.iINGRESOTARJETACONTADO = value;
                this.isnull["IINGRESOTARJETACONTADO"] = false;
            }
        }

        private decimal iINGRESOEFECTIVOCONTADO;
        public decimal IINGRESOEFECTIVOCONTADO
        {
            get
            {
                return this.iINGRESOEFECTIVOCONTADO;
            }
            set
            {
                this.iINGRESOEFECTIVOCONTADO = value;
                this.isnull["IINGRESOEFECTIVOCONTADO"] = false;
            }
        }


        private decimal iINGRESOCHEQUECONTADO;
        public decimal IINGRESOCHEQUECONTADO
        {
            get
            {
                return this.iINGRESOCHEQUECONTADO;
            }
            set
            {
                this.iINGRESOCHEQUECONTADO = value;
                this.isnull["IINGRESOCHEQUECONTADO"] = false;
            }
        }

        private decimal iINGRESOVALECONTADO;
        public decimal IINGRESOVALECONTADO
        {
            get
            {
                return this.iINGRESOVALECONTADO;
            }
            set
            {
                this.iINGRESOVALECONTADO = value;
                this.isnull["IINGRESOVALECONTADO"] = false;
            }
        }


        private decimal iINGRESOTARJETAABONO;
        public decimal IINGRESOTARJETAABONO
        {
            get
            {
                return this.iINGRESOTARJETAABONO;
            }
            set
            {
                this.iINGRESOTARJETAABONO = value;
                this.isnull["IINGRESOTARJETAABONO"] = false;
            }
        }

        private decimal iINGRESOEFECTIVOABONO;
        public decimal IINGRESOEFECTIVOABONO
        {
            get
            {
                return this.iINGRESOEFECTIVOABONO;
            }
            set
            {
                this.iINGRESOEFECTIVOABONO = value;
                this.isnull["IINGRESOEFECTIVOABONO"] = false;
            }
        }


        private decimal iINGRESOCHEQUEABONO;
        public decimal IINGRESOCHEQUEABONO
        {
            get
            {
                return this.iINGRESOCHEQUEABONO;
            }
            set
            {
                this.iINGRESOCHEQUEABONO = value;
                this.isnull["IINGRESOCHEQUEABONO"] = false;
            }
        }

        private decimal iINGRESOVALEABONO;
        public decimal IINGRESOVALEABONO
        {
            get
            {
                return this.iINGRESOVALEABONO;
            }
            set
            {
                this.iINGRESOVALEABONO = value;
                this.isnull["IINGRESOVALEABONO"] = false;
            }
        }



        private decimal iEGRESOTARJETACONTADO;
        public decimal IEGRESOTARJETACONTADO
        {
            get
            {
                return this.iEGRESOTARJETACONTADO;
            }
            set
            {
                this.iEGRESOTARJETACONTADO = value;
                this.isnull["IEGRESOTARJETACONTADO"] = false;
            }
        }

        private decimal iEGRESOEFECTIVOCONTADO;
        public decimal IEGRESOEFECTIVOCONTADO
        {
            get
            {
                return this.iEGRESOEFECTIVOCONTADO;
            }
            set
            {
                this.iEGRESOEFECTIVOCONTADO = value;
                this.isnull["IEGRESOEFECTIVOCONTADO"] = false;
            }
        }


        private decimal iEGRESOCHEQUECONTADO;
        public decimal IEGRESOCHEQUECONTADO
        {
            get
            {
                return this.iEGRESOCHEQUECONTADO;
            }
            set
            {
                this.iEGRESOCHEQUECONTADO = value;
                this.isnull["IEGRESOCHEQUECONTADO"] = false;
            }
        }

        private decimal iEGRESOVALECONTADO;
        public decimal IEGRESOVALECONTADO
        {
            get
            {
                return this.iEGRESOVALECONTADO;
            }
            set
            {
                this.iEGRESOVALECONTADO = value;
                this.isnull["IEGRESOVALECONTADO"] = false;
            }
        }


        private decimal iEGRESOTARJETAABONO;
        public decimal IEGRESOTARJETAABONO
        {
            get
            {
                return this.iEGRESOTARJETAABONO;
            }
            set
            {
                this.iEGRESOTARJETAABONO = value;
                this.isnull["IEGRESOTARJETAABONO"] = false;
            }
        }

        private decimal iEGRESOEFECTIVOABONO;
        public decimal IEGRESOEFECTIVOABONO
        {
            get
            {
                return this.iEGRESOEFECTIVOABONO;
            }
            set
            {
                this.iEGRESOEFECTIVOABONO = value;
                this.isnull["IEGRESOEFECTIVOABONO"] = false;
            }
        }


        private decimal iEGRESOCHEQUEABONO;
        public decimal IEGRESOCHEQUEABONO
        {
            get
            {
                return this.iEGRESOCHEQUEABONO;
            }
            set
            {
                this.iEGRESOCHEQUEABONO = value;
                this.isnull["IEGRESOCHEQUEABONO"] = false;
            }
        }

        private decimal iEGRESOVALEABONO;
        public decimal IEGRESOVALEABONO
        {
            get
            {
                return this.iEGRESOVALEABONO;
            }
            set
            {
                this.iEGRESOVALEABONO = value;
                this.isnull["IEGRESOVALEABONO"] = false;
            }
        }*/



        private decimal iSALDOREALCREDITO;
        public decimal ISALDOREALCREDITO
        {
            get
            {
                return this.iSALDOREALCREDITO;
            }
            set
            {
                this.iSALDOREALCREDITO = value;
                this.isnull["ISALDOREALCREDITO"] = false;
            }
        }


        private decimal iINGRESOMONEDERO;
        public decimal IINGRESOMONEDERO
        {
            get
            {
                return this.iINGRESOMONEDERO;
            }
            set
            {
                this.iINGRESOMONEDERO = value;
                this.isnull["IINGRESOMONEDERO"] = false;
            }
        }


        private decimal iEGRESOMONEDERO;
        public decimal IEGRESOMONEDERO
        {
            get
            {
                return this.iEGRESOMONEDERO;
            }
            set
            {
                this.iEGRESOMONEDERO = value;
                this.isnull["IEGRESOMONEDERO"] = false;
            }
        }







        private decimal iINGRESOTRANSFERENCIA;
        public decimal IINGRESOTRANSFERENCIA
        {
            get
            {
                return this.iINGRESOTRANSFERENCIA;
            }
            set
            {
                this.iINGRESOTRANSFERENCIA = value;
                this.isnull["IINGRESOTRANSFERENCIA"] = false;
            }
        }


        private decimal iEGRESOTRANSFERENCIA;
        public decimal IEGRESOTRANSFERENCIA
        {
            get
            {
                return this.iEGRESOTRANSFERENCIA;
            }
            set
            {
                this.iEGRESOTRANSFERENCIA = value;
                this.isnull["IEGRESOTRANSFERENCIA"] = false;
            }
        }




        private decimal iINGRESOINDEFINIDO;
        public decimal IINGRESOINDEFINIDO
        {
            get
            {
                return this.iINGRESOINDEFINIDO;
            }
            set
            {
                this.iINGRESOINDEFINIDO = value;
                this.isnull["IINGRESOINDEFINIDO"] = false;
            }
        }


        private decimal iEGRESOINDEFINIDO;
        public decimal IEGRESOINDEFINIDO
        {
            get
            {
                return this.iEGRESOINDEFINIDO;
            }
            set
            {
                this.iEGRESOINDEFINIDO = value;
                this.isnull["IEGRESOINDEFINIDO"] = false;
            }
        }


        private long iTIPOCORTEID;
        public long ITIPOCORTEID
        {
            get
            {
                return this.iTIPOCORTEID;
            }
            set
            {
                this.iTIPOCORTEID = value;
                this.isnull["ITIPOCORTEID"] = false;
            }
        }


        private decimal iRETIROSDECAJA;
        public decimal IRETIROSDECAJA
        {
            get
            {
                return this.iRETIROSDECAJA;
            }
            set
            {
                this.iRETIROSDECAJA = value;
                this.isnull["IRETIROSDECAJA"] = false;
            }
        }

        private decimal iINGRESOTARJETAVENTATRASLADO;
        public decimal IINGRESOTARJETAVENTATRASLADO
        {
            get
            {
                return this.iINGRESOTARJETAVENTATRASLADO;
            }
            set
            {
                this.iINGRESOTARJETAVENTATRASLADO = value;
                this.isnull["IINGRESOTARJETAVENTATRASLADO"] = false;
            }
        }
        private decimal iINGRESOEFECTIVOVENTATRASLADO;
        public decimal IINGRESOEFECTIVOVENTATRASLADO
        {
            get
            {
                return this.iINGRESOEFECTIVOVENTATRASLADO;
            }
            set
            {
                this.iINGRESOEFECTIVOVENTATRASLADO = value;
                this.isnull["IINGRESOEFECTIVOVENTATRASLADO"] = false;
            }
        }
        private decimal iINGRESOCREDITOVENTATRASLADO;
        public decimal IINGRESOCREDITOVENTATRASLADO
        {
            get
            {
                return this.iINGRESOCREDITOVENTATRASLADO;
            }
            set
            {
                this.iINGRESOCREDITOVENTATRASLADO = value;
                this.isnull["IINGRESOCREDITOVENTATRASLADO"] = false;
            }
        }
       
        private decimal iINGRESOVALEVENTATRASLADO;
        public decimal IINGRESOVALEVENTATRASLADO
        {
            get
            {
                return this.iINGRESOVALEVENTATRASLADO;
            }
            set
            {
                this.iINGRESOVALEVENTATRASLADO = value;
                this.isnull["IINGRESOVALEVENTATRASLADO"] = false;
            }
        }
        private decimal iINGRESOCHEQUEVENTATRASLADO;
        public decimal IINGRESOCHEQUEVENTATRASLADO
        {
            get
            {
                return this.iINGRESOCHEQUEVENTATRASLADO;
            }
            set
            {
                this.iINGRESOCHEQUEVENTATRASLADO = value;
                this.isnull["IINGRESOCHEQUEVENTATRASLADO"] = false;
            }
        }
        private decimal iINGRESOMONEDEROVENTATRASLADO;
        public decimal IINGRESOMONEDEROVENTATRASLADO
        {
            get
            {
                return this.iINGRESOMONEDEROVENTATRASLADO;
            }
            set
            {
                this.iINGRESOMONEDEROVENTATRASLADO = value;
                this.isnull["IINGRESOMONEDEROVENTATRASLADO"] = false;
            }
        }
        private decimal iINGRESOTRANSFVENTATRASLADO;
        public decimal IINGRESOTRANSFVENTATRASLADO
        {
            get
            {
                return this.iINGRESOTRANSFVENTATRASLADO;
            }
            set
            {
                this.iINGRESOTRANSFVENTATRASLADO = value;
                this.isnull["IINGRESOTRANSFVENTATRASLADO"] = false;
            }
        }


        private decimal iEGRESOEFEVENTATRASLADO;
        public decimal IEGRESOEFEVENTATRASLADO
        {
            get
            {
                return this.iEGRESOEFEVENTATRASLADO;
            }
            set
            {
                this.iEGRESOEFEVENTATRASLADO = value;
                this.isnull["IEGRESOEFEVENTATRASLADO"] = false;
            }
        }


        private decimal iINGRESODEPOSITO;
        public decimal IINGRESODEPOSITO
        {
            get
            {
                return this.iINGRESODEPOSITO;
            }
            set
            {
                this.iINGRESODEPOSITO = value;
                this.isnull["IINGRESODEPOSITO"] = false;
            }
        }





        private decimal iEGRESODEPOSITO;
        public decimal IEGRESODEPOSITO
        {
            get
            {
                return this.iEGRESODEPOSITO;
            }
            set
            {
                this.iEGRESODEPOSITO = value;
                this.isnull["IEGRESODEPOSITO"] = false;
            }
        }



        private decimal iINGRESODEPOSITOVENTATRASLADO;
        public decimal IINGRESODEPOSITOVENTATRASLADO
        {
            get
            {
                return this.iINGRESODEPOSITOVENTATRASLADO;
            }
            set
            {
                this.iINGRESODEPOSITOVENTATRASLADO = value;
                this.isnull["IINGRESODEPOSITOVENTATRASLADO"] = false;
            }
        }





        private decimal iINGRESODEPTERCERO;
        public decimal IINGRESODEPTERCERO
        {
            get
            {
                return this.iINGRESODEPTERCERO;
            }
            set
            {
                this.iINGRESODEPTERCERO = value;
                this.isnull["IINGRESODEPTERCERO"] = false;
            }
        }





        private decimal iEGRESODEPTERCERO;
        public decimal IEGRESODEPTERCERO
        {
            get
            {
                return this.iEGRESODEPTERCERO;
            }
            set
            {
                this.iEGRESODEPTERCERO = value;
                this.isnull["IEGRESODEPTERCERO"] = false;
            }
        }



        private decimal iINGRESODEPTERCEROVENTATRASLADO;
        public decimal IINGRESODEPTERCEROVENTATRASLADO
        {
            get
            {
                return this.iINGRESODEPTERCEROVENTATRASLADO;
            }
            set
            {
                this.iINGRESODEPTERCEROVENTATRASLADO = value;
                this.isnull["IINGRESODEPTERCEROVENTATRASLADO"] = false;
            }
        }


        private decimal iINGRESOINDEFVENTATRASLADO;
        public decimal IINGRESOINDEFVENTATRASLADO
        {
            get
            {
                return this.iINGRESOINDEFVENTATRASLADO;
            }
            set
            {
                this.iINGRESOINDEFVENTATRASLADO = value;
                this.isnull["IINGRESOINDEFVENTATRASLADO"] = false;
            }
        }



        private decimal iFONDEOSDECAJA;
        public decimal IFONDEOSDECAJA
        {
            get
            {
                return this.iFONDEOSDECAJA;
            }
            set
            {
                this.iFONDEOSDECAJA = value;
                this.isnull["IFONDEOSDECAJA"] = false;
            }
        }



        private decimal iFONDODINAMICO;
        public decimal IFONDODINAMICO
        {
            get
            {
                return this.iFONDODINAMICO;
            }
            set
            {
                this.iFONDODINAMICO = value;
                this.isnull["IFONDODINAMICO"] = false;
            }
        }



        private decimal iFONDODINAMICOFINAL;
        public decimal IFONDODINAMICOFINAL
        {
            get
            {
                return this.iFONDODINAMICOFINAL;
            }
            set
            {
                this.iFONDODINAMICOFINAL = value;
                this.isnull["IFONDODINAMICOFINAL"] = false;
            }
        }


        private long iCORTERECOLECCIONID;
        public long ICORTERECOLECCIONID
        {
            get
            {
                return this.iCORTERECOLECCIONID;
            }
            set
            {
                this.iCORTERECOLECCIONID = value;
                this.isnull["ICORTERECOLECCIONID"] = false;
            }
        }


        public CCORTEBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IID",true);
	

			isnull.Add("IACTIVO",true);
	

			isnull.Add("ICREADO",true);
	

			isnull.Add("ICREADOPOR_USERID",true);
	

			isnull.Add("IMODIFICADO",true);
	

			isnull.Add("IMODIFICADOPOR_USERID",true);
	

			isnull.Add("ISUCURSALID",true);
	

			isnull.Add("ICAJAID",true);
	

			isnull.Add("ICAJEROID",true);
	

			isnull.Add("ITURNOID",true);
	

			isnull.Add("IFECHACORTE",true);
	

			isnull.Add("IINICIA",true);
	

			isnull.Add("ITERMINA",true);
	

			isnull.Add("ISALDOINICIAL",true);
	

			isnull.Add("IINGRESO",true);
	

			isnull.Add("IEGRESO",true);
	

			isnull.Add("IDEVOLUCION",true);
	

			isnull.Add("IAPORTACION",true);
	

			isnull.Add("IRETIRO",true);
	

			isnull.Add("ISALDOFINAL",true);
	

			isnull.Add("INUMEROTICKETS",true);
	

			isnull.Add("INUMERODEVOLUCIONES",true);
	

			isnull.Add("ISALDOREAL",true);


            isnull.Add("IDIFERENCIA", true);


            isnull.Add("IINGRESOTARJETA", true);


            isnull.Add("IINGRESOEFECTIVO", true);


            isnull.Add("IINGRESOCREDITO", true);


            isnull.Add("IINGRESOCHEQUE", true);


            isnull.Add("IINGRESOVALE", true);


            isnull.Add("ICAMBIOCHEQUE", true);

            isnull.Add("IPAGOPROVEEDORES", true);


            isnull.Add("IEGRESOTARJETA", true);


            isnull.Add("IEGRESOEFECTIVO", true);


            isnull.Add("IEGRESOCREDITO", true);


            isnull.Add("IEGRESOCHEQUE", true);


            isnull.Add("IEGRESOVALE", true);


            isnull.Add("ISALDOREALCREDITO", true);



            isnull.Add("IINGRESOMONEDERO", true);

            isnull.Add("IEGRESOMONEDERO", true);


            isnull.Add("IINGRESOTRANSFERENCIA", true);

            isnull.Add("IEGRESOMTRANSFERENCIA", true);

            isnull.Add("IINGRESOINDEFINIDO", true);

            isnull.Add("IEGRESOINDEFINIDO", true);

            isnull.Add("ITIPOCORTEID", true);

            isnull.Add("IRETIROSDECAJA", true);

            isnull.Add("IINGRESOTARJETAVENTATRASLADO", true);
            isnull.Add("IINGRESOEFECTIVOVENTATRASLADO", true);
            isnull.Add("IINGRESOCREDITOVENTATRASLADO", true);
            isnull.Add("IINGRESOVALEVENTATRASLADO", true);
            isnull.Add("IINGRESOCHEQUEVENTATRASLADO", true);
            isnull.Add("IINGRESOMONEDEROVENTATRASLADO", true);
            isnull.Add("IINGRESOTRANSFVENTATRASLADO", true);

            isnull.Add("IEGRESOEFEVENTATRASLADO", true);


            isnull.Add("IINGRESODEPOSITO", true);
            isnull.Add("IEGRESODEPOSITO", true);
            isnull.Add("IINGRESODEPOSITOVENTATRASLADO", true);
            isnull.Add("IINGRESODEPTERCERO", true);
            isnull.Add("IEGRESODEPTERCERO", true);
            isnull.Add("IINGRESODEPTERCEROVENTATRASLADO", true);

            isnull.Add("IINGRESOINDEFVENTATRASLADO", true);

            isnull.Add("IFONDEOSDECAJA", true);

            isnull.Add("IFONDODINAMICO", true);

            isnull.Add("IFONDODINAMICOFINAL", true);

            isnull.Add("ICORTERECOLECCIONID", true);
            


            /*
                        isnull.Add("IINGRESOEFECTIVOCONTADO", true);


                        isnull.Add("IINGRESOTARJETACONTADO", true);


                        isnull.Add("IINGRESOCREDITOCONTADO", true);


                        isnull.Add("IINGRESOCHEQUECONTADO", true);


                        isnull.Add("IINGRESOVALECONTADO", true);


                        isnull.Add("IINGRESOEFECTIVOABONO", true);


                        isnull.Add("IINGRESOTARJETAABONO", true);


                        isnull.Add("IINGRESOCREDITOABONO", true);


                        isnull.Add("IINGRESOCHEQUEABONO", true);


                        isnull.Add("IINGRESOVALEABONO", true);


                        isnull.Add("IEGRESOEFECTIVOCONTADO", true);


                        isnull.Add("IEGRESOTARJETACONTADO", true);


                        isnull.Add("IEGRESOCREDITOCONTADO", true);


                        isnull.Add("IEGRESOCHEQUECONTADO", true);


                        isnull.Add("IEGRESOVALECONTADO", true);


                        isnull.Add("IEGRESOEFECTIVOABONO", true);


                        isnull.Add("IEGRESOTARJETAABONO", true);


                        isnull.Add("IEGRESOCREDITOABONO", true);


                        isnull.Add("IEGRESOCHEQUEABONO", true);


                        isnull.Add("IEGRESOVALEABONO", true);
                               */



        }

		

	}
}
