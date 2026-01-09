
using System;
using System.Collections;

namespace iPosBusinessEntity
{
    public class CPAGODOCTOSAT_IMPBE
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

        private string iACTIVO;
        public string IACTIVO
        {
            get
            {
                return this.iACTIVO;
            }
            set
            {
                this.iACTIVO = value;
                this.isnull["IACTIVO"] = false;
            }
        }

        private object iCREADO;
        public object ICREADO
        {
            get
            {
                return this.iCREADO;
            }
            set
            {
                this.iCREADO = value;
                this.isnull["ICREADO"] = false;
            }
        }

        private long iCREADOPOR_USERID;
        public long ICREADOPOR_USERID
        {
            get
            {
                return this.iCREADOPOR_USERID;
            }
            set
            {
                this.iCREADOPOR_USERID = value;
                this.isnull["ICREADOPOR_USERID"] = false;
            }
        }

        private object iMODIFICADO;
        public object IMODIFICADO
        {
            get
            {
                return this.iMODIFICADO;
            }
            set
            {
                this.iMODIFICADO = value;
                this.isnull["IMODIFICADO"] = false;
            }
        }

        private long iMODIFICADOPOR_USERID;
        public long IMODIFICADOPOR_USERID
        {
            get
            {
                return this.iMODIFICADOPOR_USERID;
            }
            set
            {
                this.iMODIFICADOPOR_USERID = value;
                this.isnull["IMODIFICADOPOR_USERID"] = false;
            }
        }

        private decimal iBASEIMP;
        public decimal IBASEIMP
        {
            get
            {
                return this.iBASEIMP;
            }
            set
            {
                this.iBASEIMP = value;
                this.isnull["IBASEIMP"] = false;
            }
        }

        private string iTIPOFACTOR;
        public string ITIPOFACTOR
        {
            get
            {
                return this.iTIPOFACTOR;
            }
            set
            {
                this.iTIPOFACTOR = value;
                this.isnull["ITIPOFACTOR"] = false;
            }
        }

        private string iTASACUOTA;
        public string ITASACUOTA
        {
            get
            {
                return this.iTASACUOTA;
            }
            set
            {
                this.iTASACUOTA = value;
                this.isnull["ITASACUOTA"] = false;
            }
        }

        private decimal iTASA;
        public decimal ITASA
        {
            get
            {
                return this.iTASA;
            }
            set
            {
                this.iTASA = value;
                this.isnull["ITASA"] = false;
            }
        }

        private string iIMPUESTO;
        public string IIMPUESTO
        {
            get
            {
                return this.iIMPUESTO;
            }
            set
            {
                this.iIMPUESTO = value;
                this.isnull["IIMPUESTO"] = false;
            }
        }

        private decimal iIMPORTE;
        public decimal IIMPORTE
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

        private long iPAGODOCTOSATID;
        public long IPAGODOCTOSATID
        {
            get
            {
                return this.iPAGODOCTOSATID;
            }
            set
            {
                this.iPAGODOCTOSATID = value;
                this.isnull["IPAGODOCTOSATID"] = false;
            }
        }


        private string iTIPOIMPUESTO;
        public string ITIPOIMPUESTO
        {
            get
            {
                return this.iTIPOIMPUESTO;
            }
            set
            {
                this.iTIPOIMPUESTO = value;
                this.isnull["ITIPOIMPUESTO"] = false;
            }
        }


        //calculado
        private string iIDDOCUMENTO;
        public string IIDDOCUMENTO
        {
            get
            {
                return this.iIDDOCUMENTO;
            }
            set
            {
                this.iIDDOCUMENTO = value;
                this.isnull["IIDDOCUMENTO"] = false;
            }
        }

        public CPAGODOCTOSAT_IMPBE()
        {
            isnull = new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("IACTIVO", true);


            isnull.Add("ICREADO", true);


            isnull.Add("ICREADOPOR_USERID", true);


            isnull.Add("IMODIFICADO", true);


            isnull.Add("IMODIFICADOPOR_USERID", true);


            isnull.Add("IBASEIMP", true);


            isnull.Add("ITIPOFACTOR", true);


            isnull.Add("ITASACUOTA", true);


            isnull.Add("ITASA", true);


            isnull.Add("IIMPUESTO", true);


            isnull.Add("IIMPORTE", true);


            isnull.Add("IPAGODOCTOSATID", true);

            isnull.Add("ITIPOIMPUESTO", true);

            //calculado
            isnull.Add("IIDDOCUMENTO", true);

        }



    }
}
