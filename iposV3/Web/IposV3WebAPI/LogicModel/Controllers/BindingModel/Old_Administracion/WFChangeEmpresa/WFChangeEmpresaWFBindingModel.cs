
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
    public class WFChangeEmpresaWFBindingModel : Validatable
    {

        public WFChangeEmpresaWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Cmbchangecompany;
        [XmlAttribute]
        public long? Cmbchangecompany { get => _Cmbchangecompany; set { if (RaiseAcceptPendingChange(value, _Cmbchangecompany)) { _Cmbchangecompany = value; OnPropertyChanged(); } } }

        private string? _CmbchangecompanyClave;
        [XmlAttribute]
        public string? CmbchangecompanyClave { get => _CmbchangecompanyClave; set { if (RaiseAcceptPendingChange(value, _CmbchangecompanyClave)) { _CmbchangecompanyClave = value; OnPropertyChanged(); } } }

        private string? _CmbchangecompanyNombre;
        [XmlAttribute]
        public string? CmbchangecompanyNombre { get => _CmbchangecompanyNombre; set { if (RaiseAcceptPendingChange(value, _CmbchangecompanyNombre)) { _CmbchangecompanyNombre = value; OnPropertyChanged(); } } }

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

