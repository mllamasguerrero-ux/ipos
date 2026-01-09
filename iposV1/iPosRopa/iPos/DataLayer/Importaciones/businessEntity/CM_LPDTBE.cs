
using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public class CM_LPDTBE
    {
        public Hashtable isnull;

        private string iPRODUCTO;
        public string IPRODUCTO
        {
            get
            {
                return this.iPRODUCTO;
            }
            set
            {
                this.iPRODUCTO = value;
                this.isnull["IPRODUCTO"] = false;
            }
        }

        private string iLISTA;
        public string ILISTA
        {
            get
            {
                return this.iLISTA;
            }
            set
            {
                this.iLISTA = value;
                this.isnull["ILISTA"] = false;
            }
        }



        private decimal iPRECIO1;
        public decimal IPRECIO1
        {
            get
            {
                return this.iPRECIO1;
            }
            set
            {
                this.iPRECIO1 = value;
                this.isnull["IPRECIO1"] = false;
            }
        }



        private decimal iPRECIO2;
        public decimal IPRECIO2
        {
            get
            {
                return this.iPRECIO2;
            }
            set
            {
                this.iPRECIO2 = value;
                this.isnull["IPRECIO2"] = false;
            }
        }




        private decimal iPRECIO3;
        public decimal IPRECIO3
        {
            get
            {
                return this.iPRECIO3;
            }
            set
            {
                this.iPRECIO3 = value;
                this.isnull["IPRECIO3"] = false;
            }
        }




        private decimal iPRECIO4;
        public decimal IPRECIO4
        {
            get
            {
                return this.iPRECIO4;
            }
            set
            {
                this.iPRECIO4 = value;
                this.isnull["IPRECIO4"] = false;
            }
        }




        private decimal iPRECIO5;
        public decimal IPRECIO5
        {
            get
            {
                return this.iPRECIO5;
            }
            set
            {
                this.iPRECIO5 = value;
                this.isnull["IPRECIO5"] = false;
            }
        }


        private decimal iCOSTOREP;
        public decimal ICOSTOREP
        {
            get
            {
                return this.iCOSTOREP;
            }
            set
            {
                this.iCOSTOREP = value;
                this.isnull["ICOSTOREP"] = false;
            }
        }


        private string iTIENEVIG;
        public string ITIENEVIG
        {
            get
            {
                return this.iTIENEVIG;
            }
            set
            {
                this.iTIENEVIG = value;
                this.isnull["ITIENEVIG"] = false;
            }
        }


        private DateTime iFECHAVIG;
        public DateTime IFECHAVIG
        {
            get
            {
                return this.iFECHAVIG;
            }
            set
            {
                this.iFECHAVIG = value;
                this.isnull["IFECHAVIG"] = false;
            }
        }


        private string iID;
        public string IID
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

        private string iID_FECHA;
        public string IID_FECHA
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

        public CM_LPDTBE()
        {
            isnull = new Hashtable();


            isnull.Add("IPRODUCTO", true);


            isnull.Add("ILISTA", true);


            isnull.Add("IID", true);


            isnull.Add("IID_FECHA", true);


            isnull.Add("IID_HORA", true);


            isnull.Add("IPRECIO1", true);


            isnull.Add("IPRECIO2", true);


            isnull.Add("IPRECIO3", true);


            isnull.Add("IPRECIO4", true);


            isnull.Add("IPRECIO5", true);

            isnull.Add("ICOSTOREP", true);

            isnull.Add("ITIENEVIG", true);

            isnull.Add("IFECHAVIG", true);


        }



    }
}
