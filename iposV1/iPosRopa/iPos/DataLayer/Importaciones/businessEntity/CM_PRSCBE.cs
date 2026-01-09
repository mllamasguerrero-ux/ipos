
using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public class CM_PRSCBE
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

        private string iSUCCLAVE;
        public string ISUCCLAVE
        {
            get
            {
                return this.iSUCCLAVE;
            }
            set
            {
                this.iSUCCLAVE = value;
                this.isnull["ISUCCLAVE"] = false;
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

        public CM_PRSCBE()
        {
            isnull = new Hashtable();


            isnull.Add("IPRODUCTO", true);


            isnull.Add("ISUCCLAVE", true);


            isnull.Add("IID", true);


            isnull.Add("IID_FECHA", true);


            isnull.Add("IID_HORA", true);

        }



    }
}
