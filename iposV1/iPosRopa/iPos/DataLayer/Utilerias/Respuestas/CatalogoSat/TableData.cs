using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Utilerias.Respuestas.CatalogoSat
{
    public class TableData
    {
        private string name;
        private List<ColumnInfo> columns;
        private long nextPage;
        private int version;
        private List<List<Field>> records;
        public string Name { get => name; set => name = value; }
        public List<ColumnInfo> Columns { get => columns; set => columns = value; }
        public List<List<Field>> Records { get => records; set => records = value; }
        public long NextPage { get => nextPage; set => nextPage = value; }
        public int Version { get => version; set => version = value; }
    }
}
