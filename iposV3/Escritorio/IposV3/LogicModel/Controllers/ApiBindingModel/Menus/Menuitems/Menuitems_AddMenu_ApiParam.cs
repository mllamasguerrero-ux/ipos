
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
    
    public class Menuitems_AddMenu_ApiParam
    
    {
        
        #pragma warning disable 8618
        public Menuitems_AddMenu_ApiParam()
        {
        }
        #pragma warning restore 8618


        private Int32? _IdParent;
        [XmlAttribute]
        public Int32? IdParent { get => _IdParent; set { _IdParent = value;  } } 

        private List<MenuitemsBindingModel>? _MenuItems;
        [XmlAttribute]
        public List<MenuitemsBindingModel>? MenuItems { get => _MenuItems; set { _MenuItems = value;  } }


        //NOTNEEDED MLG 2025 Migracion web out
        //private out List<Controllers.BindingModel.Menu.MyMenuDataBindingModel>? _Data;
        //[XmlAttribute]
        //public out List<Controllers.BindingModel.Menu.MyMenuDataBindingModel>? Data { get => _Data; set { _Data = value;  } } 





    }
}

