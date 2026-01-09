
using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public class CPERFILESBE
    {
        public Hashtable isnull;
        private int iPF_PERFIL;
        public int IPF_PERFIL
        {
            get
            {
                return this.iPF_PERFIL;
            }
            set
            {
                this.iPF_PERFIL = value;
                this.isnull["IPF_PERFIL"] = false;
            }
        }
        private string iPF_DESCRIPCION;
        public string IPF_DESCRIPCION
        {
            get
            {
                return this.iPF_DESCRIPCION;
            }
            set
            {
                this.iPF_DESCRIPCION = value;
                this.isnull["IPF_DESCRIPCION"] = false;
            }
        }
        public CPERFILESBE()
        {
            isnull = new Hashtable();
            isnull.Add("IPF_PERFIL", true);
            isnull.Add("IPF_DESCRIPCION", true);
        }
    }
}
