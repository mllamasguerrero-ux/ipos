using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingModels
{
    public class FastReportInfo
    {

        public string RutaReporte { get; set; } = "";
        public Dictionary<string, object>? DictionaryReporte { get; set; }
        public string ConnectionString { get; set; } = "";
        public long Userid { get; set; }
        public string UserName { get; set; } = "";
        public string Format { get; set; } = "pdf";

        public string RutaLocalReporte { get; set; } = "";

        public Dictionary<string,DataTable>? DictionaryTables { get; set; }
    }
}
