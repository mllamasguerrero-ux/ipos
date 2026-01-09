using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.CatalogosSAT.businessEntity
{
    public class CSAT_VERSIONCATALOGOBE
    {
        private long version;

        private DateTime date;

        private string status;

        public long Version { get => version; set => version = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Status { get => status; set => status = value; }
    }
}
