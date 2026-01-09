
using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public class CUSUARIO_DERBE
    {
        public Hashtable isnull;
        private int iUD_USERID;
        public int IUD_USERID
        {
            get
            {
                return this.iUD_USERID;
            }
            set
            {
                this.iUD_USERID = value;
                this.isnull["IUD_USERID"] = false;
            }
        }
        private int iUD_DERECHO;
        public int IUD_DERECHO
        {
            get
            {
                return this.iUD_DERECHO;
            }
            set
            {
                this.iUD_DERECHO = value;
                this.isnull["IUD_DERECHO"] = false;
            }
        }
        public CUSUARIO_DERBE()
        {
            isnull = new Hashtable();
            isnull.Add("IUD_USERID", true);
            isnull.Add("IUD_DERECHO", true);
        }
    }
}
