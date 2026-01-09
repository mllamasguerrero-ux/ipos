
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
using IposV3.Services;

namespace ApiParam
{
    [XmlRoot]
    
    public class Inventario_Docto_inventario_insert_ApiParam
    
    {
        
        #pragma warning disable 8618
        public Inventario_Docto_inventario_insert_ApiParam()
        {
        }
        #pragma warning restore 8618


        private DoctoInventarioTrans? _DoctoTrans;
        [XmlAttribute]
        public DoctoInventarioTrans? DoctoTrans { get => _DoctoTrans; set { _DoctoTrans = value;  } }


        //NOTNEEDED MLG 2025 Migracion web out
        //private out Int64? _DoctoId;
        //[XmlAttribute]
        //public out Int64? DoctoId { get => _DoctoId; set { _DoctoId = value;  } } 





    }
}

