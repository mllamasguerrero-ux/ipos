
using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public class CM_MARCBE
    {
        public Hashtable isnull;

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
                this.isnull["IMARCA"] = false;
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
                this.iNOMBRE = value;
                this.isnull["INOMBRE"] = false;
            }
        }

        private double iCANTIDAD;
        public double ICANTIDAD
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

        private double iIMPORTE;
        public double IIMPORTE
        {
            get
            {
                return this.iIMPORTE;
            }
            set
            {
                this.iIMPORTE = value;
                this.isnull["IIMPORTE"] = false;
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

        private string iDESCONTI;
        public string IDESCONTI
        {
            get
            {
                return this.iDESCONTI;
            }
            set
            {
                this.iDESCONTI = value;
                this.isnull["IDESCONTI"] = false;
            }
        }

        public CM_MARCBE()
        {
            isnull = new Hashtable();


            isnull.Add("IMARCA", true);


            isnull.Add("INOMBRE", true);


            isnull.Add("ICANTIDAD", true);


            isnull.Add("IIMPORTE", true);


            isnull.Add("IID", true);


            isnull.Add("IID_FECHA", true);


            isnull.Add("IID_HORA", true);


            isnull.Add("IDESCONTI", true);

        }



    }
}
