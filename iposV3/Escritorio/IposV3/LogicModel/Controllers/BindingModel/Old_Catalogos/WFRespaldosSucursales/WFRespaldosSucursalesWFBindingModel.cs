
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
    public class WFRespaldosSucursalesWFBindingModel : Validatable
    {

        public WFRespaldosSucursalesWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Sucursal;
        [XmlAttribute]
        public long? Sucursal { get => _Sucursal; set { if (RaiseAcceptPendingChange(value, _Sucursal)) { _Sucursal = value; OnPropertyChanged(); } } }

        private string? _SucursalClave;
        [XmlAttribute]
        public string? SucursalClave { get => _SucursalClave; set { if (RaiseAcceptPendingChange(value, _SucursalClave)) { _SucursalClave = value; OnPropertyChanged(); } } }

        private string? _SucursalNombre;
        [XmlAttribute]
        public string? SucursalNombre { get => _SucursalNombre; set { if (RaiseAcceptPendingChange(value, _SucursalNombre)) { _SucursalNombre = value; OnPropertyChanged(); } } }

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

