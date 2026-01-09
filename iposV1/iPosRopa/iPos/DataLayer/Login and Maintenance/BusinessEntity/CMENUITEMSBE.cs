
using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public class CMENUITEMSBE
    {
        public Hashtable isnull;
        private int iMN_ID;
        public int IMN_ID
        {
            get
            {
                return this.iMN_ID;
            }
            set
            {
                this.iMN_ID = value;
                this.isnull["IMN_ID"] = false;
            }
        }
        private int iMN_IDPARENT;
        public int IMN_IDPARENT
        {
            get
            {
                return this.iMN_IDPARENT;
            }
            set
            {
                this.iMN_IDPARENT = value;
                this.isnull["IMN_IDPARENT"] = false;
            }
        }
        private string iMN_ETIQUETA;
        public string IMN_ETIQUETA
        {
            get
            {
                return this.iMN_ETIQUETA;
            }
            set
            {
                this.iMN_ETIQUETA = value;
                this.isnull["IMN_ETIQUETA"] = false;
            }
        }
        private string iMN_DESC;
        public string IMN_DESC
        {
            get
            {
                return this.iMN_DESC;
            }
            set
            {
                this.iMN_DESC = value;
                this.isnull["IMN_DESC"] = false;
            }
        }
        private int iMN_DERECHO;
        public int IMN_DERECHO
        {
            get
            {
                return this.iMN_DERECHO;
            }
            set
            {
                this.iMN_DERECHO = value;
                this.isnull["IMN_DERECHO"] = false;
            }
        }
        private short iMN_LEVEL;
        public short IMN_LEVEL
        {
            get
            {
                return this.iMN_LEVEL;
            }
            set
            {
                this.iMN_LEVEL = value;
                this.isnull["IMN_LEVEL"] = false;
            }
        }
        public CMENUITEMSBE()
        {
            isnull = new Hashtable();
            isnull.Add("IMN_ID", true);
            isnull.Add("IMN_IDPARENT", true);
            isnull.Add("IMN_ETIQUETA", true);
            isnull.Add("IMN_DESC", true);
            isnull.Add("IMN_DERECHO", true);
            isnull.Add("IMN_LEVEL", true);
        }
    }
}
