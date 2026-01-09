
using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public class CM_KITSBE
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

        private string iPARTE;
        public string IPARTE
        {
            get
            {
                return this.iPARTE;
            }
            set
            {
                this.iPARTE = value;
                this.isnull["IPARTE"] = false;
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

        private double iCOSTO;
        public double ICOSTO
        {
            get
            {
                return this.iCOSTO;
            }
            set
            {
                this.iCOSTO = value;
                this.isnull["ICOSTO"] = false;
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

        public CM_KITSBE()
        {
            isnull = new Hashtable();


            isnull.Add("IPRODUCTO", true);


            isnull.Add("IPARTE", true);


            isnull.Add("ICANTIDAD", true);


            isnull.Add("ICOSTO", true);


            isnull.Add("IID", true);


            isnull.Add("IID_FECHA", true);


            isnull.Add("IID_HORA", true);

        }



    }
}
