using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Utilerias.Respuestas.CatalogoSat
{
    public class ColumnInfo
    {
        private string name;

        private string dataType;

        public string Name { get => name; set => name = value; }
        public string DataType { get => dataType; set => dataType = value; }
    }
}
