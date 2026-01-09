
using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public class CCUENTASPVCBE
    {
        public Hashtable isnull;

        private long iID;
        public long IID
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

        private string iCUENTASUMAVENTAS;
        public string ICUENTASUMAVENTAS
        {
            get
            {
                return this.iCUENTASUMAVENTAS;
            }
            set
            {
                this.iCUENTASUMAVENTAS = value;
                this.isnull["ICUENTASUMAVENTAS"] = false;
            }
        }

        private string iCUENTASUMNOTASCREDITO;
        public string ICUENTASUMNOTASCREDITO
        {
            get
            {
                return this.iCUENTASUMNOTASCREDITO;
            }
            set
            {
                this.iCUENTASUMNOTASCREDITO = value;
                this.isnull["ICUENTASUMNOTASCREDITO"] = false;
            }
        }

        private string iCUENTAIMPUESTOS;
        public string ICUENTAIMPUESTOS
        {
            get
            {
                return this.iCUENTAIMPUESTOS;
            }
            set
            {
                this.iCUENTAIMPUESTOS = value;
                this.isnull["ICUENTAIMPUESTOS"] = false;
            }
        }

        public CCUENTASPVCBE()
        {
            isnull = new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("ICUENTASUMAVENTAS", true);


            isnull.Add("ICUENTASUMNOTASCREDITO", true);


            isnull.Add("ICUENTAIMPUESTOS", true);

        }



    }
}
