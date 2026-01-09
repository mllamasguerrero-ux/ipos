
using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public class CTICKET_PROMOCIONESBE
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
                this.iDOCTOID = value;
                this.isnull["IDOCTOID"] = false;
            }
        }

        private long iMOVTOID;
        public long IMOVTOID
        {
            get
            {
                return this.iMOVTOID;
            }
            set
            {
                this.iMOVTOID = value;
                this.isnull["IMOVTOID"] = false;
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


        private string iPROMOCIONDESGLOSE;
        public string IPROMOCIONDESGLOSE
        {
            get
            {
                return this.iPROMOCIONDESGLOSE;
            }
            set
            {
                this.iPROMOCIONDESGLOSE = value;
                this.isnull["IPROMOCIONDESGLOSE"] = false;
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
                this.iCANTIDAD = value;
                this.isnull["ICANTIDAD"] = false;
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
                this.iPRECIO = value;
                this.isnull["IPRECIO"] = false;
            }
        }


        private decimal iPRECIOSINDESCUENTO;
        public decimal IPRECIOSINDESCUENTO
        {
            get
            {
                return this.iPRECIOSINDESCUENTO;
            }
            set
            {
                this.iPRECIOSINDESCUENTO = value;
                this.isnull["IPRECIOSINDESCUENTO"] = false;
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


        private decimal iTOTALSINDESCUENTO;
        public decimal ITOTALSINDESCUENTO
        {
            get
            {
                return this.iTOTALSINDESCUENTO;
            }
            set
            {
                this.iTOTALSINDESCUENTO = value;
                this.isnull["ITOTALSINDESCUENTO"] = false;
            }
        }

        public CTICKET_PROMOCIONESBE()
        {
            isnull = new Hashtable();


            isnull.Add("IDOCTOID", true);

            isnull.Add("IMOVTOID", true);

            isnull.Add("IDESCRIPCION1", true);


            isnull.Add("IDESCRIPCION2", true);

            isnull.Add("IPROMOCIONDESGLOSE", true);


            isnull.Add("ICANTIDAD", true);
            isnull.Add("IPRECIO", true);
            isnull.Add("IPRECIOSINDESCUENTO", true);
            isnull.Add("ITOTAL", true);
            isnull.Add("ITOTALSINDESCUENTO", true);

        }



    }
}
