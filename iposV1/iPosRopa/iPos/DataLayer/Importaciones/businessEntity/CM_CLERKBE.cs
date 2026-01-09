
using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public class CM_CLERKBE
    {
        public Hashtable isnull;

        private string iCLERK;
        public string ICLERK
        {
            get
            {
                return this.iCLERK;
            }
            set
            {
                this.iCLERK = value;
                this.isnull["ICLERK"] = false;
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



        private string iESSERV;
        public string IESSERV
        {
            get
            {
                return this.iESSERV;
            }
            set
            {
                this.iESSERV = value;
                this.isnull["IESSERV"] = false;
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

        public CM_CLERKBE()
        {
            isnull = new Hashtable();


            isnull.Add("ITERMINAL", true);


            isnull.Add("ISUCCLAVE", true);

            isnull.Add("IESSERV", true);


            isnull.Add("IID", true);


            isnull.Add("IID_FECHA", true);


            isnull.Add("IID_HORA", true);

        }



    }
}