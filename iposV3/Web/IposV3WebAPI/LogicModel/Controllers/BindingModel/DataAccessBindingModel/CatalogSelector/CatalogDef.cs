using IposV3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CatalogSelector
{
    public class CatalogDef
    {

        public CatalogDef()
        {

        }

        public CatalogDef(string? catalogName, string?catalogKey , object? catalogParam, KendoParams? extraCondition)
        {
            CatalogName = catalogName;
            CatalogKey = catalogKey;
            CatalogParam = catalogParam;
            ExtraCondition = extraCondition;
        }

        public CatalogDef(string? catalogName, string? catalogKey): this(catalogName, catalogKey, null, null)
        {
        }


        public CatalogDef(string catalogName) : this(catalogName, null, null, null)
        {
        }
        public string? CatalogName { get; set; }
        public string? CatalogKey { get; set; }

        public object? CatalogParam { get; set; }
        public KendoParams? ExtraCondition { get; set; }
    }
}
