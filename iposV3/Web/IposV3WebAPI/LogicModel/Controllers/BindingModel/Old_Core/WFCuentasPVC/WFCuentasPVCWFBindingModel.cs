
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
    public class WFCuentasPVCWFBindingModel : Validatable
    {

        public WFCuentasPVCWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Txtcuentasumaventas;
        [XmlAttribute]
        public string? Txtcuentasumaventas { get => _Txtcuentasumaventas; set { if (RaiseAcceptPendingChange(value, _Txtcuentasumaventas)) { _Txtcuentasumaventas = value; OnPropertyChanged(); } } }

        private string? _Txtcuentasumanotascredito;
        [XmlAttribute]
        public string? Txtcuentasumanotascredito { get => _Txtcuentasumanotascredito; set { if (RaiseAcceptPendingChange(value, _Txtcuentasumanotascredito)) { _Txtcuentasumanotascredito = value; OnPropertyChanged(); } } }

        private string? _Txtcuentaimpuestos;
        [XmlAttribute]
        public string? Txtcuentaimpuestos { get => _Txtcuentaimpuestos; set { if (RaiseAcceptPendingChange(value, _Txtcuentaimpuestos)) { _Txtcuentaimpuestos = value; OnPropertyChanged(); } } }

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

