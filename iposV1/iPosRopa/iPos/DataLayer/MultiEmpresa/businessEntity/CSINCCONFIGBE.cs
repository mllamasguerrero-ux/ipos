
using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public class CSINCCONFIGBE
    {
        public Hashtable isnull;

        private string iHAB_SINC;
        public string IHAB_SINC
        {
            get
            {
                return this.iHAB_SINC;
            }
            set
            {
                this.iHAB_SINC = value;
                this.isnull["IHAB_SINC"] = false;
            }
        }

        private string iES_COPIA;
        public string IES_COPIA
        {
            get
            {
                return this.iES_COPIA;
            }
            set
            {
                this.iES_COPIA = value;
                this.isnull["IES_COPIA"] = false;
            }
        }

        private string iC_CONEXORIG;
        public string IC_CONEXORIG
        {
            get
            {
                return this.iC_CONEXORIG;
            }
            set
            {
                this.iC_CONEXORIG = value;
                this.isnull["IC_CONEXORIG"] = false;
            }
        }

        private string iC_SINCAUTO;
        public string IC_SINCAUTO
        {
            get
            {
                return this.iC_SINCAUTO;
            }
            set
            {
                this.iC_SINCAUTO = value;
                this.isnull["IC_SINCAUTO"] = false;
            }
        }

        private DateTime iC_FECHAULTISINC;
        public DateTime IC_FECHAULTISINC
        {
            get
            {
                return this.iC_FECHAULTISINC;
            }
            set
            {
                this.iC_FECHAULTISINC = value;
                this.isnull["IC_FECHAULTISINC"] = false;
            }
        }

        private string iC_LIMPNOSINC;
        public string IC_LIMPNOSINC
        {
            get
            {
                return this.iC_LIMPNOSINC;
            }
            set
            {
                this.iC_LIMPNOSINC = value;
                this.isnull["IC_LIMPNOSINC"] = false;
            }
        }

        private DateTime iO_ULTIFECHACAMBIO;
        public DateTime IO_ULTIFECHACAMBIO
        {
            get
            {
                return this.iO_ULTIFECHACAMBIO;
            }
            set
            {
                this.iO_ULTIFECHACAMBIO = value;
                this.isnull["IO_ULTIFECHACAMBIO"] = false;
            }
        }

        private string iO_FECHACAMBIOMANUAL;
        public string IO_FECHACAMBIOMANUAL
        {
            get
            {
                return this.iO_FECHACAMBIOMANUAL;
            }
            set
            {
                this.iO_FECHACAMBIOMANUAL = value;
                this.isnull["IO_FECHACAMBIOMANUAL"] = false;
            }
        }

        private string iO_RUTASYSTEMDATA_ENRED;
        public string IO_RUTASYSTEMDATA_ENRED
        {
            get
            {
                return this.iO_RUTASYSTEMDATA_ENRED;
            }
            set
            {
                this.iO_RUTASYSTEMDATA_ENRED = value;
                this.isnull["IO_RUTASYSTEMDATA_ENRED"] = false;
            }
        }

        public CSINCCONFIGBE()
        {
            isnull = new Hashtable();


            isnull.Add("IHAB_SINC", true);


            isnull.Add("IES_COPIA", true);


            isnull.Add("IC_CONEXORIG", true);


            isnull.Add("IC_SINCAUTO", true);


            isnull.Add("IC_FECHAULTISINC", true);


            isnull.Add("IC_LIMPNOSINC", true);


            isnull.Add("IO_ULTIFECHACAMBIO", true);


            isnull.Add("IO_FECHACAMBIOMANUAL", true);

            isnull.Add("IO_RUTASYSTEMDATA_ENRED", true);

        }



    }
}
