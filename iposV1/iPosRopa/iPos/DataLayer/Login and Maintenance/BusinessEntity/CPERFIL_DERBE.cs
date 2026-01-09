
using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public class CPERFIL_DERBE
    {
        public Hashtable isnull;
        private int iPD_PERFIL;
        public int IPD_PERFIL
        {
            get
            {
                return this.iPD_PERFIL;
            }
            set
            {
                this.iPD_PERFIL = value;
                this.isnull["IPD_PERFIL"] = false;
            }
        }
        private int iPD_DERECHO;
        public int IPD_DERECHO
        {
            get
            {
                return this.iPD_DERECHO;
            }
            set
            {
                this.iPD_DERECHO = value;
                this.isnull["IPD_DERECHO"] = false;
            }
        }
        public CPERFIL_DERBE()
        {
            isnull = new Hashtable();
            isnull.Add("IPD_PERFIL", true);
            isnull.Add("IPD_DERECHO", true);
        }
    }
}
