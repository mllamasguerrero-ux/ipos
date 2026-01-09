

using System;
namespace iPosBusinessEntity
{
	public class CEXIST_SUCURSALBE
	{

 	private string iSUCURSALCLAVE;
        public string ISUCURSALCLAVE
        { 
        	get
        	{
         		return this.iSUCURSALCLAVE;
        	}
        	set
        	{
        		this.iSUCURSALCLAVE= value;
        	}
        }


 	private string iGRUPOCLAVE;
        public string IGRUPOCLAVE
        { 
        	get
        	{
                return this.iGRUPOCLAVE;
        	}
        	set
        	{
                this.iGRUPOCLAVE = value;
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
            }
        }


 	private string iPRODUCTOCLAVE;
        public string IPRODUCTOCLAVE
        { 
        	get
        	{
         		return this.iPRODUCTOCLAVE;
        	}
        	set
        	{
        		this.iPRODUCTOCLAVE= value;
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
                this.iLOTE = value;
            }
        }


        private DateTime iVENCE;
        public DateTime IVENCE
        {
            get
            {
                return this.iVENCE;
            }
            set
            {
                this.iVENCE = value;
            }
        }


        private string iPROVEE;
        public string IPROVEE
        {
            get
            {
                return this.iPROVEE;
            }
            set
            {
                this.iPROVEE = value;
            }
        }


        private string iLINEA;
        public string ILINEA
        {
            get
            {
                return this.iLINEA;
            }
            set
            {
                this.iLINEA = value;
            }
        }


        private string iMARCA;
        public string IMARCA
        {
            get
            {
                return this.iMARCA;
            }
            set
            {
                this.iMARCA = value;
            }
        }




        private string iIMP_PED;
        public string IIMP_PED
        {
            get
            {
                return this.iIMP_PED;
            }
            set
            {
                this.iIMP_PED = value;
            }
        }



        private DateTime iIMP_FEC;
        public DateTime IIMP_FEC
        {
            get
            {
                return this.iIMP_FEC;
            }
            set
            {
                this.iIMP_FEC = value;
            }
        }



        private string iIMP_ADU;
        public string IIMP_ADU
        {
            get
            {
                return this.iIMP_ADU;
            }
            set
            {
                this.iIMP_ADU = value;
            }
        }


        private decimal iIMP_TC;
        public decimal IIMP_TC
        {
            get
            {
                return this.iIMP_TC;
            }
            set
            {
                this.iIMP_TC = value;
            }
        }



		
         public CEXIST_SUCURSALBE()
		{
	
		}

         public CEXIST_SUCURSALBE(
            string pSUCURSALCLAVE,
            string pGRUPOCLAVE,
            string pALMACENCLAVE,
            string pPRODUCTOCLAVE,
            decimal pCANTIDAD,
            decimal pCOSTO,
            DateTime pFECHA)
         {
             ISUCURSALCLAVE = pSUCURSALCLAVE;
             IGRUPOCLAVE = pGRUPOCLAVE;
             IALMACENCLAVE = pALMACENCLAVE;
             IPRODUCTOCLAVE = pPRODUCTOCLAVE;
             ICANTIDAD = pCANTIDAD;
             ICOSTO = pCOSTO;
             IFECHA = pFECHA;
         }


         public CEXIST_SUCURSALBE(
          string pSUCURSALCLAVE,
          string pGRUPOCLAVE,
          string pALMACENCLAVE,
          string pPRODUCTOCLAVE,
          decimal pCANTIDAD,
          decimal pCOSTO,
          DateTime pFECHA,
          string pLOTE,
          DateTime pVENCE,
          string pPROVEE,
          string pLINEA,
          string pMARCA,
          string pIMP_PED,
          DateTime pIMP_FEC,
          string pIMP_ADU,
          decimal pIMP_TC

           )
         {
             ISUCURSALCLAVE = pSUCURSALCLAVE;
             IGRUPOCLAVE = pGRUPOCLAVE;
             IALMACENCLAVE = pALMACENCLAVE;
             IPRODUCTOCLAVE = pPRODUCTOCLAVE;
             ICANTIDAD = pCANTIDAD;
             ICOSTO = pCOSTO;
             IFECHA = pFECHA;

             ILOTE = pLOTE;
             IVENCE = pVENCE;
             IPROVEE = pPROVEE;
             ILINEA = pLINEA;
             IMARCA = pMARCA;
             IIMP_PED = pIMP_PED;
             IIMP_FEC = pIMP_FEC;
             IIMP_ADU = pIMP_ADU;
             IIMP_TC = pIMP_TC;




         }

		


	}
}
