
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using IposV3.Model;
using MvvmFramework;
using System.Xml.Serialization;

namespace BindingModels
{
    
    [XmlRoot]
    public class WFMovimientosXProductoLoteWFBindingModel : Validatable
    {

        public WFMovimientosXProductoLoteWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Combolote;
        [XmlAttribute]
        public long? Combolote { get => _Combolote; set { if (RaiseAcceptPendingChange(value, _Combolote)) { _Combolote = value; OnPropertyChanged(); } } }

        private long? _Itemid;
        [XmlAttribute]
        public long? Itemid { get => _Itemid; set { if (RaiseAcceptPendingChange(value, _Itemid)) { _Itemid = value; OnPropertyChanged(); } } }

        private string? _ItemidClave;
        [XmlAttribute]
        public string? ItemidClave { get => _ItemidClave; set { if (RaiseAcceptPendingChange(value, _ItemidClave)) { _ItemidClave = value; OnPropertyChanged(); } } }

        private string? _ItemidNombre;
        [XmlAttribute]
        public string? ItemidNombre { get => _ItemidNombre; set { if (RaiseAcceptPendingChange(value, _ItemidNombre)) { _ItemidNombre = value; OnPropertyChanged(); } } }

        private string? _Tblote;
        [XmlAttribute]
        public string? Tblote { get => _Tblote; set { if (RaiseAcceptPendingChange(value, _Tblote)) { _Tblote = value; OnPropertyChanged(); } } }

        private string? _ComboloteClave;
        [XmlAttribute]
        public string? ComboloteClave { get => _ComboloteClave; set { if (RaiseAcceptPendingChange(value, _ComboloteClave)) { _ComboloteClave = value; OnPropertyChanged(); } } }

        private string? _ComboloteNombre;
        [XmlAttribute]
        public string? ComboloteNombre { get => _ComboloteNombre; set { if (RaiseAcceptPendingChange(value, _ComboloteNombre)) { _ComboloteNombre = value; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {
            return "";
        }


        public static string GetFieldsForGeneralSearch()
        {
            return "";
        }


        public void FillCatalogRelatedFields()
        {

        }



    }

    
     
}

