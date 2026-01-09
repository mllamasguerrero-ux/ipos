
using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public class CM_LINEBE
    {
        public Hashtable isnull;

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
                this.isnull["ILINEA"] = false;
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


        private string iTRECARGA;
        public string ITRECARGA
        {
            get
            {
                return this.iTRECARGA;
            }
            set
            {
                this.iTRECARGA = value;
                this.isnull["ITRECARGA"] = false;
            }
        }



        private string iAPLIMAYO;
        public string IAPLIMAYO
        {
            get
            {
                return this.iAPLIMAYO;
            }
            set
            {
                this.iAPLIMAYO = value;
                this.isnull["IAPLIMAYO"] = false;
            }
        }


        private string iGPOIMP;
        public string IGPOIMP
        {
            get
            {
                return this.iGPOIMP;
            }
            set
            {
                this.iGPOIMP = value;
                this.isnull["IGPOIMP"] = false;
            }
        }


        public CM_LINEBE()
        {
            isnull = new Hashtable();


            isnull.Add("ILINEA", true);


            isnull.Add("INOMBRE", true);


            isnull.Add("ICANTIDAD", true);


            isnull.Add("IIMPORTE", true);


            isnull.Add("IID", true);


            isnull.Add("IID_FECHA", true);


            isnull.Add("IID_HORA", true);

            isnull.Add("ITRECARGA", true);

            isnull.Add("IAPLIMAYO", true);

            isnull.Add("IGPOIMP", true);



        }



    }
}
