
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
    public class WFProveedorSaldoWFBindingModel : Validatable
    {

        public WFProveedorSaldoWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Personaid;
        [XmlAttribute]
        public long? Personaid { get => _Personaid; set { if (RaiseAcceptPendingChange(value, _Personaid)) { _Personaid = value; OnPropertyChanged(); } } }

        private string? _PersonaidClave;
        [XmlAttribute]
        public string? PersonaidClave { get => _PersonaidClave; set { if (RaiseAcceptPendingChange(value, _PersonaidClave)) { _PersonaidClave = value; OnPropertyChanged(); } } }

        private string? _PersonaidNombre;
        [XmlAttribute]
        public string? PersonaidNombre { get => _PersonaidNombre; set { if (RaiseAcceptPendingChange(value, _PersonaidNombre)) { _PersonaidNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Rdsolovencidos;
        [XmlAttribute]
        public BoolCN? Rdsolovencidos { get => _Rdsolovencidos; set { if (RaiseAcceptPendingChange(value, _Rdsolovencidos)) { _Rdsolovencidos = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbsumarizado;
        [XmlAttribute]
        public BoolCN? Cbsumarizado { get => _Cbsumarizado; set { if (RaiseAcceptPendingChange(value, _Cbsumarizado)) { _Cbsumarizado = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbtodas;
        [XmlAttribute]
        public BoolCN? Cbtodas { get => _Cbtodas; set { if (RaiseAcceptPendingChange(value, _Cbtodas)) { _Cbtodas = value; OnPropertyChanged(); } } }

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

