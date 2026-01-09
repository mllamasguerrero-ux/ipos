using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public class CM_USERBE
    {

        public Hashtable isnull;


        private string iCLAVE;
        public string ICLAVE
        {
            get
            {
                return this.iCLAVE;
            }
            set
            {
                this.iCLAVE = value;
                this.isnull["ICLAVE"] = false;
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

        private string iEXPORTAUT;
        public string IEXPORTAUT
        {
            get
            {
                return this.iEXPORTAUT;
            }
            set
            {
                this.iEXPORTAUT = value;
                this.isnull["IEXPORTAUT"] = false;
            }
        }

        private string iIMPRESORA;
        public string IIMPRESORA
        {
            get
            {
                return this.iIMPRESORA;
            }
            set
            {
                this.iIMPRESORA = value;
                this.isnull["IIMPRESORA"] = false;
            }
        }

        private string iVENDEDOR;
        public string IVENDEDOR
        {
            get
            {
                return this.iVENDEDOR;
            }
            set
            {
                this.iVENDEDOR = value;
                this.isnull["IVENDEDOR"] = false;
            }
        }

        private string iPASSWORD;
        public string IPASSWORD
        {
            get
            {
                return this.iPASSWORD;
            }
            set
            {
                this.iPASSWORD = value;
                this.isnull["IPASSWORD"] = false;
            }
        }


        private string iCAJASBOTELLAS;
        public string ICAJASBOTELLAS
        {
            get
            {
                return this.iCAJASBOTELLAS;
            }
            set
            {
                this.iCAJASBOTELLAS = value;
                this.isnull["ICAJASBOTELLAS"] = false;
            }
        }

        public CM_USERBE()
        {
            isnull = new Hashtable();
            isnull.Add("ICLAVE", true);
            isnull.Add("INOMBRE", true);
            isnull.Add("IEXPORTAUT", true);
            isnull.Add("IIMPRESORA", true);
            isnull.Add("IVENDEDOR", true);
            isnull.Add("IPASSWORD", true);
            isnull.Add("ICAJASBOTELLAS", true);

            


        }

    }
 }
