using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Importaciones.businessEntity
{
    public class CM_KITSUCBE
    {
        public Hashtable isnull;

        private string iCLAVESUC;
        public string ICLAVESUC
        {
            get
            {
                return iCLAVESUC;
            }
            set
            {
                iCLAVESUC = value;
                isnull["ICLAVESUC"] = false;
            }
        }

        private string iKITID;
        public string IKITID
        {
            get
            {
                return iKITID;
            }
            set
            {
                iKITID = value;
                isnull["IKITID"] = false;
            }
        }

        public CM_KITSUCBE()
        {
            isnull = new Hashtable();

            isnull.Add("ICLAVESUC", true);
            isnull.Add("IKITID", true);
        }
    }
}
