
using System;
using System.Collections;
using System.Collections.Generic;

namespace iPosBusinessEntity
{
    public class FM_CMNPBE
    {
        public Hashtable isnull;

        private string iCOMPRA;
        public string ICOMPRA
        {
            get
            {
                return this.iCOMPRA;
            }
            set
            {
                this.iCOMPRA = value;
                this.isnull["ICOMPRA"] = false;
            }
        }

        private string iPROVEEDOR;
        public string IPROVEEDOR
        {
            get
            {
                return this.iPROVEEDOR;
            }
            set
            {
                this.iPROVEEDOR = value;
                this.isnull["IPROVEEDOR"] = false;
            }
        }

        private string iESTATUS;
        public string IESTATUS
        {
            get
            {
                return this.iESTATUS;
            }
            set
            {
                this.iESTATUS = value;
                this.isnull["IESTATUS"] = false;
            }
        }

        private string iESTATUS2;
        public string IESTATUS2
        {
            get
            {
                return this.iESTATUS2;
            }
            set
            {
                this.iESTATUS2 = value;
                this.isnull["IESTATUS2"] = false;
            }
        }

        private string iNOTA1;
        public string INOTA1
        {
            get
            {
                return this.iNOTA1;
            }
            set
            {
                this.iNOTA1 = value;
                this.isnull["INOTA1"] = false;
            }
        }

        private string iNOTA2;
        public string INOTA2
        {
            get
            {
                return this.iNOTA2;
            }
            set
            {
                this.iNOTA2 = value;
                this.isnull["INOTA2"] = false;
            }
        }

        private string iPLAZOS;
        public string IPLAZOS
        {
            get
            {
                return this.iPLAZOS;
            }
            set
            {
                this.iPLAZOS = value;
                this.isnull["IPLAZOS"] = false;
            }
        }

        private string iSUGERIDOS;
        public string ISUGERIDOS
        {
            get
            {
                return this.iSUGERIDOS;
            }
            set
            {
                this.iSUGERIDOS = value;
                this.isnull["ISUGERIDOS"] = false;
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
                this.iTOTAL = value;
                this.isnull["ITOTAL"] = false;
            }
        }

        private string iAUTOCRED;
        public string IAUTOCRED
        {
            get
            {
                return this.iAUTOCRED;
            }
            set
            {
                this.iAUTOCRED = value;
                this.isnull["IAUTOCRED"] = false;
            }
        }

        private string iCONTADO;
        public string ICONTADO
        {
            get
            {
                return this.iCONTADO;
            }
            set
            {
                this.iCONTADO = value;
                this.isnull["ICONTADO"] = false;
            }
        }

        private string iPROCESADO;
        public string IPROCESADO
        {
            get
            {
                return this.iPROCESADO;
            }
            set
            {
                this.iPROCESADO = value;
                this.isnull["IPROCESADO"] = false;
            }
        }

        private long? iID;
        public long? IID
        {
            get
            {
                return this.iID;
            }
            set
            {
                this.iID = value;
                this.isnull["IID"] = false;
            }
        }

        private DateTime iID_FECHA;
        public DateTime IID_FECHA
        {
            get
            {
                return this.iID_FECHA;
            }
            set
            {
                this.iID_FECHA = value;
                this.isnull["IID_FECHA"] = false;
            }
        }

        private string iID_HORA;
        public string IID_HORA
        {
            get
            {
                return this.iID_HORA;
            }
            set
            {
                this.iID_HORA = value;
                this.isnull["IID_HORA"] = false;
            }
        }

        private string iVENDCLAVE;
        public string IVENDCLAVE
        {
            get
            {
                return this.iVENDCLAVE;
            }
            set
            {
                this.iVENDCLAVE = value;
                this.isnull["IVENDCLAVE"] = false;
            }
        }


        private string iFACTURA;
        public string IFACTURA
        {
            get
            {
                return this.iFACTURA;
            }
            set
            {
                this.iFACTURA = value;
                this.isnull["IFACTURA"] = false;
            }
        }


        private DateTime iFECHAFACTURA;
        public DateTime IFECHAFACTURA
        {
            get
            {
                return this.iFECHAFACTURA;
            }
            set
            {
                this.iFECHAFACTURA = value;
                this.isnull["IFECHAFACTURA"] = false;
            }
        }


        private List<FM_CMDPBE> detalles;

        public List<FM_CMDPBE> Detalles
        {
            get
            {
                return this.detalles;
            }
            set
            {
                this.detalles = value;
            }
        }


        public FM_CMNPBE()
        {
            isnull = new Hashtable();


            isnull.Add("ICOMPRA", true);


            isnull.Add("IPROVEEDOR", true);


            isnull.Add("IESTATUS", true);


            isnull.Add("IESTATUS2", true);


            isnull.Add("INOTA1", true);


            isnull.Add("INOTA2", true);


            isnull.Add("IPLAZOS", true);


            isnull.Add("ISUGERIDOS", true);


            isnull.Add("ITOTAL", true);


            isnull.Add("IAUTOCRED", true);


            isnull.Add("ICONTADO", true);


            isnull.Add("IPROCESADO", true);


            isnull.Add("IID", true);


            isnull.Add("IID_FECHA", true);


            isnull.Add("IID_HORA", true);


            isnull.Add("IVENDCLAVE", true);


            isnull.Add("IFACTURA", true);


            isnull.Add("IFECHAFACTURA", true);




        }



    }
}
