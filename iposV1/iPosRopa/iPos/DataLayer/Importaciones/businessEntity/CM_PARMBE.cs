using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public class CM_PARMBE
    {
        public Hashtable isnull;

        private float iMINUTILIDAD;
        public float IMINUTILIDAD
        {
            get
            {
                return this.iMINUTILIDAD;
            }
            set
            {
                this.iMINUTILIDAD = value;
                this.isnull["IMINUTILIDAD"] = false;
            }
        }

        private string iDESGLOSEIEPS;
        public string IDESGLOSEIEPS
        {
            get
            {
                return this.iDESGLOSEIEPS;
            }
            set
            {
                this.iDESGLOSEIEPS = value;
                this.isnull["IDESGLOSEIEPS"] = false;
            }
        }


        private int iLISTAPRECIOMINIMO;
        public int ILISTAPRECIOMINIMO
        {
            get
            {
                return this.iLISTAPRECIOMINIMO;
            }
            set
            {
                this.iLISTAPRECIOMINIMO = value;
                this.isnull["ILISTAPRECIOMINIMO"] = false;
            }
        }

        public CM_PARMBE()
        {
            isnull = new Hashtable();
            isnull.Add("IMINUTILIDAD", true);
            isnull.Add("IDESGLOSEIEPS", true);
            isnull.Add("ILISTAPRECIOMINIMO", true);
            

        }


    }
}
