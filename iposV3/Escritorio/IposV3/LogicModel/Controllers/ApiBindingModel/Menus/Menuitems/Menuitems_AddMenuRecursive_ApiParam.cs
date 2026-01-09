
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using IposV3.Model;
using MvvmFramework;
using System.Xml.Serialization;
using BindingModels;

namespace ApiParam
{
    [XmlRoot]
    
    public class Menuitems_AddMenuRecursive_ApiParam
    
    {
        
        #pragma warning disable 8618
        public Menuitems_AddMenuRecursive_ApiParam()
        {
        }
        #pragma warning restore 8618


        private Controllers.BindingModel.Menu.MyMenuDataBindingModel? _MnuItem;
        [XmlAttribute]
        public Controllers.BindingModel.Menu.MyMenuDataBindingModel? MnuItem { get => _MnuItem; set { _MnuItem = value;  } }



#if PROYECTO_WEB
        private List<Menuitems>? _MenuItems;
        [XmlAttribute]
        public List<Menuitems>? MenuItems { get => _MenuItems; set { _MenuItems = value; } }
#endif


#if PROYECTO_ESCRITORIO
        private List<MenuitemsBindingModel>? _MenuItems;
        [XmlAttribute]
        public List<MenuitemsBindingModel>? MenuItems { get => _MenuItems; set { _MenuItems = value;  } } 
#endif







    }
}

