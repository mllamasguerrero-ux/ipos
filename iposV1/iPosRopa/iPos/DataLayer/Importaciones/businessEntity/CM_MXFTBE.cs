
using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public class CM_MXFTBE
    {
        public Hashtable isnull;

        private string iSUCURSAL;
        public string ISUCURSAL
        {
            get
            {
                return this.iSUCURSAL;
            }
            set
            {
                this.iSUCURSAL = value;
                this.isnull["ISUCURSAL"] = false;
            }
        }
        



        private int iANIO;
        public int IANIO
        {
            get
            {
                return this.iANIO;
            }
            set
            {
                this.iANIO = value;
                this.isnull["IANIO"] = false;
            }
        }



        private int iMES;
        public int IMES
        {
            get
            {
                return this.iMES;
            }
            set
            {
                this.iMES = value;
                this.isnull["IMES"] = false;
            }
        }



        private string iLUN_HAY;
        public string ILUN_HAY
        {
            get
            {
                return this.iLUN_HAY;
            }
            set
            {
                this.iLUN_HAY = value;
                this.isnull["ILUN_HAY"] = false;
            }
        }



        private decimal iLUN_MAX;
        public decimal ILUN_MAX
        {
            get
            {
                return this.iLUN_MAX;
            }
            set
            {
                this.iLUN_MAX = value;
                this.isnull["ILUN_MAX"] = false;
            }
        }



        private string iMAR_HAY;
        public string IMAR_HAY
        {
            get
            {
                return this.iMAR_HAY;
            }
            set
            {
                this.iMAR_HAY = value;
                this.isnull["IMAR_HAY"] = false;
            }
        }



        private decimal iMAR_MAX;
        public decimal IMAR_MAX
        {
            get
            {
                return this.iMAR_MAX;
            }
            set
            {
                this.iMAR_MAX = value;
                this.isnull["IMAR_MAX"] = false;
            }
        }







        private string iMIE_HAY;
        public string IMIE_HAY
        {
            get
            {
                return this.iMIE_HAY;
            }
            set
            {
                this.iMIE_HAY = value;
                this.isnull["IMIE_HAY"] = false;
            }
        }



        private decimal iMIE_MAX;
        public decimal IMIE_MAX
        {
            get
            {
                return this.iMIE_MAX;
            }
            set
            {
                this.iMIE_MAX = value;
                this.isnull["IMIE_MAX"] = false;
            }
        }





        private string iJUE_HAY;
        public string IJUE_HAY
        {
            get
            {
                return this.iJUE_HAY;
            }
            set
            {
                this.iJUE_HAY = value;
                this.isnull["IJUE_HAY"] = false;
            }
        }



        private decimal iJUE_MAX;
        public decimal IJUE_MAX
        {
            get
            {
                return this.iJUE_MAX;
            }
            set
            {
                this.iJUE_MAX = value;
                this.isnull["IJUE_MAX"] = false;
            }
        }





        private string iVIE_HAY;
        public string IVIE_HAY
        {
            get
            {
                return this.iVIE_HAY;
            }
            set
            {
                this.iVIE_HAY = value;
                this.isnull["IVIE_HAY"] = false;
            }
        }



        private decimal iVIE_MAX;
        public decimal IVIE_MAX
        {
            get
            {
                return this.iVIE_MAX;
            }
            set
            {
                this.iVIE_MAX = value;
                this.isnull["IVIE_MAX"] = false;
            }
        }





        private string iSAB_HAY;
        public string ISAB_HAY
        {
            get
            {
                return this.iSAB_HAY;
            }
            set
            {
                this.iSAB_HAY = value;
                this.isnull["ISAB_HAY"] = false;
            }
        }



        private decimal iSAB_MAX;
        public decimal ISAB_MAX
        {
            get
            {
                return this.iSAB_MAX;
            }
            set
            {
                this.iSAB_MAX = value;
                this.isnull["ISAB_MAX"] = false;
            }
        }





        private string iDOM_HAY;
        public string IDOM_HAY
        {
            get
            {
                return this.iDOM_HAY;
            }
            set
            {
                this.iDOM_HAY = value;
                this.isnull["IDOM_HAY"] = false;
            }
        }



        private decimal iDOM_MAX;
        public decimal IDOM_MAX
        {
            get
            {
                return this.iDOM_MAX;
            }
            set
            {
                this.iDOM_MAX = value;
                this.isnull["IDOM_MAX"] = false;
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

        public CM_MXFTBE()
        {
            isnull = new Hashtable();


            isnull.Add("ISUCURSAL", true);


            isnull.Add("IANIO", true);


            isnull.Add("IMES", true);


            isnull.Add("IID", true);


            isnull.Add("IID_FECHA", true);


            isnull.Add("IID_HORA", true);


            isnull.Add("ILUN_HAY", true);


            isnull.Add("ILUN_MAX", true);


            isnull.Add("IMAR_HAY", true);


            isnull.Add("IMAR_MAX", true);


            isnull.Add("IMIE_HAY", true);


            isnull.Add("IMIE_MAX", true);


            isnull.Add("IJUE_HAY", true);


            isnull.Add("IJUE_MAX", true);


            isnull.Add("IVIE_HAY", true);


            isnull.Add("IVIE_MAX", true);


            isnull.Add("ISAB_HAY", true);


            isnull.Add("ISAB_MAX", true);


            isnull.Add("IDOM_HAY", true);


            isnull.Add("IDOM_MAX", true);



        }



    }
}
