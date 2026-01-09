using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public class CM_DER_UBE
    {
        public Hashtable isnull;

        private string iCLAVEDERECHO;
        public string ICLAVEDERECHO
        {
            get
            {
                return this.iCLAVEDERECHO;
            }
            set
            {
                this.iCLAVEDERECHO = value;
                this.isnull["ICLAVEDERECHO"] = false;
            }
        }

        private string iCLAVEUSUARIO;
        public string ICLAVEUSUARIO
        {
            get
            {
                return this.iCLAVEUSUARIO;
            }
            set
            {
                this.iCLAVEUSUARIO = value;
                this.isnull["ICLAVEUSUARIO"] = false;
            }
        }


        public CM_DER_UBE()
        {
            isnull = new Hashtable();
            isnull.Add("ICLAVEDERECHO", true);
            isnull.Add("ICLAVEUSUARIO", true);

        }
    }
}
