using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Utilerias.Respuestas.CatalogoSat
{
    public class SatCatalogueInfo
    {
        private int version;

        private DateTime date;

        private string status;
        public int Version { get => version; set => version = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Status { get => status; set => status = value; }
    }
}
