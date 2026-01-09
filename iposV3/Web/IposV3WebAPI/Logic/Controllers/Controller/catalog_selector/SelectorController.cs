using IposV3.Controllers.Controller.Utils;
using IposV3.Model;
using Models.CatalogSelector; 
using System;
using IposV3.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.Controllers.Controller
{
    public class SelectorController
    {

        private CatalogSelector catalogSelector;


        public SelectorController(CatalogSelector catalogSelector)
        {
            this.catalogSelector = catalogSelector;
        }


        public Dictionary<string, List<BaseSelector>?>? ObtainCatalogs(List<CatalogDef> lstCatalogDef, BaseParam baseParam)
        {
            return catalogSelector.obtainCatalogs(lstCatalogDef, baseParam);
        }

        public List<BaseSelector>? obtainCatalog(CatalogDef catalogDef, BaseParam baseParam)
        {
            return catalogSelector.obtainCatalog(catalogDef, baseParam);
        }

        public string obtainCatalogTitle(CatalogRelatedFields catalogRelatedField)
        {
            return catalogSelector.obtainCatalogTitle(catalogRelatedField);
        }

        public BaseSelector? obtainItemByClave(string strCatalogo, string strClave, BaseParam baseParam)
        {

            CatalogDef catDef = new CatalogDef(strCatalogo);
            return catalogSelector.obtainItemByClave(catDef, strClave, baseParam);
        }


        public BaseSelector? obtainItemById(string strCatalogo, long itemId, BaseParam baseParam)
        {

            CatalogDef catDef = new CatalogDef(strCatalogo);
            return catalogSelector.obtainItemById(catDef, itemId, baseParam);
        }

    }
}
