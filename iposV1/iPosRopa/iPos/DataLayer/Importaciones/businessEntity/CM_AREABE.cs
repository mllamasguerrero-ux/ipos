
using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public class CM_AREABE
    {
        public Hashtable isnull;

        private string iAREA;
        public string IAREA
        {
            get
            {
                return this.iAREA;
            }
            set
            {
                this.iAREA = value;
                this.isnull["IAREA"] = false;
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



        public CM_AREABE()
        {
            isnull = new Hashtable();


            isnull.Add("IAREA", true);


            isnull.Add("INOMBRE", true);



            isnull.Add("IID", true);


            isnull.Add("IID_FECHA", true);


            isnull.Add("IID_HORA", true);

        }



    }
}
