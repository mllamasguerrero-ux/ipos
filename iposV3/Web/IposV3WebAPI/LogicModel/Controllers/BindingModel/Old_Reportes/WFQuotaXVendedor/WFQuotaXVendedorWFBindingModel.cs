
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
    public class WFQuotaXVendedorWFBindingModel : Validatable
    {

        public WFQuotaXVendedorWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Itemid;
        [XmlAttribute]
        public long? Itemid { get => _Itemid; set { if (RaiseAcceptPendingChange(value, _Itemid)) { _Itemid = value; OnPropertyChanged(); } } }

        private string? _ItemidClave;
        [XmlAttribute]
        public string? ItemidClave { get => _ItemidClave; set { if (RaiseAcceptPendingChange(value, _ItemidClave)) { _ItemidClave = value; OnPropertyChanged(); } } }

        private string? _ItemidNombre;
        [XmlAttribute]
        public string? ItemidNombre { get => _ItemidNombre; set { if (RaiseAcceptPendingChange(value, _ItemidNombre)) { _ItemidNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbtodas;
        [XmlAttribute]
        public BoolCN? Cbtodas { get => _Cbtodas; set { if (RaiseAcceptPendingChange(value, _Cbtodas)) { _Cbtodas = value; OnPropertyChanged(); } } }

        private int? _Anioinicial;
        [XmlAttribute]
        public int? Anioinicial { get => _Anioinicial; set { if (RaiseAcceptPendingChange(value, _Anioinicial)) { _Anioinicial = value; OnPropertyChanged(); } } }

        private int? _Aniofinal;
        [XmlAttribute]
        public int? Aniofinal { get => _Aniofinal; set { if (RaiseAcceptPendingChange(value, _Aniofinal)) { _Aniofinal = value; OnPropertyChanged(); } } }

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

