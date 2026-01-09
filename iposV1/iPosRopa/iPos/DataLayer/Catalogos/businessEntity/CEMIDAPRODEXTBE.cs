using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPosBusinessEntity
{
    public class CEMIDAPRODEXTBE : CEMIDAPRODBE
    {
        private string iREFERENCE;
        public string IREFERENCE
        {
            get
            {
                return this.iREFERENCE;
            }
            set
            {
                this.iREFERENCE = value;
                this.isnull["IREFERENCE"] = false;
            }
        }


        private string iESSERVICIO;
        public string IESSERVICIO
        {
            get
            {
                return this.iESSERVICIO;
            }
            set
            {
                this.iESSERVICIO = value;
                this.isnull["IESSERVICIO"] = false;
            }
        }

        public CEMIDAPRODEXTBE() : base()
        {
            isnull.Add("IREFERENCE", true);
            isnull.Add("IESSERVICIO", true);

        }
    }
}
