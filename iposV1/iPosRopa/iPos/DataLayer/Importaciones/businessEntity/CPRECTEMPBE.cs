
using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public class CPRECTEMPBE
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

        private double iPRECIO1;
        public double IPRECIO1
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

        private double iPRECIO2;
        public double IPRECIO2
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

        private double iPRECIO3;
        public double IPRECIO3
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

        private double iPRECIO4;
        public double IPRECIO4
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

        private double iPRECIO5;
        public double IPRECIO5
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

        private double iSUGERIDO;
        public double ISUGERIDO
        {
            get
            {
                return this.iSUGERIDO;
            }
            set
            {
                this.iSUGERIDO = value;
                this.isnull["ISUGERIDO"] = false;
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

        public CPRECTEMPBE()
        {
            isnull = new Hashtable();


            isnull.Add("IPRODUCTO", true);


            isnull.Add("IPRECIO1", true);


            isnull.Add("IPRECIO2", true);


            isnull.Add("IPRECIO3", true);


            isnull.Add("IPRECIO4", true);


            isnull.Add("IPRECIO5", true);


            isnull.Add("ISUGERIDO", true);


            isnull.Add("IID", true);


            isnull.Add("IID_FECHA", true);


            isnull.Add("IID_HORA", true);

        }



    }
}
