
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
    public class WFAbonoProveedoresWFBindingModel : Validatable
    {

        public WFAbonoProveedoresWFBindingModel()
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

        private BoolCN? _Cbtodosproveedores;
        [XmlAttribute]
        public BoolCN? Cbtodosproveedores { get => _Cbtodosproveedores; set { if (RaiseAcceptPendingChange(value, _Cbtodosproveedores)) { _Cbtodosproveedores = value; OnPropertyChanged(); } } }

        private long? _Usuarioid;
        [XmlAttribute]
        public long? Usuarioid { get => _Usuarioid; set { if (RaiseAcceptPendingChange(value, _Usuarioid)) { _Usuarioid = value; OnPropertyChanged(); } } }

        private string? _UsuarioidClave;
        [XmlAttribute]
        public string? UsuarioidClave { get => _UsuarioidClave; set { if (RaiseAcceptPendingChange(value, _UsuarioidClave)) { _UsuarioidClave = value; OnPropertyChanged(); } } }

        private string? _UsuarioidNombre;
        [XmlAttribute]
        public string? UsuarioidNombre { get => _UsuarioidNombre; set { if (RaiseAcceptPendingChange(value, _UsuarioidNombre)) { _UsuarioidNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbtodosusuarios;
        [XmlAttribute]
        public BoolCN? Cbtodosusuarios { get => _Cbtodosusuarios; set { if (RaiseAcceptPendingChange(value, _Cbtodosusuarios)) { _Cbtodosusuarios = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfrom;
        [XmlAttribute]
        public DateTimeOffset? Dtpfrom { get => _Dtpfrom; set { if (RaiseAcceptPendingChange(value, _Dtpfrom)) { _Dtpfrom = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpto;
        [XmlAttribute]
        public DateTimeOffset? Dtpto { get => _Dtpto; set { if (RaiseAcceptPendingChange(value, _Dtpto)) { _Dtpto = value; OnPropertyChanged(); } } }

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

