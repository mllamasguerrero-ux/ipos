
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

    public class MigracionBindingModel : Validatable

    {

        public MigracionBindingModel()
        {
        }


        private string? _Cadenaconexion;
        [XmlAttribute]
        public string? Cadenaconexion { get => _Cadenaconexion; set { if (RaiseAcceptPendingChange(value, _Cadenaconexion)) { _Cadenaconexion = value; OnPropertyChanged(); } } }



        private BoolCS? _Catalogos;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public BoolCS? Catalogos { get => _Catalogos ?? BoolCS.S; set { if (RaiseAcceptPendingChange(value, _Catalogos)) { _Catalogos = value ?? BoolCS.S; OnPropertyChanged(); } } }


        private BoolCS? _InformacionEmpresa;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public BoolCS? InformacionEmpresa { get => _InformacionEmpresa ?? BoolCS.S; set { if (RaiseAcceptPendingChange(value, _InformacionEmpresa)) { _InformacionEmpresa = value ?? BoolCS.S; OnPropertyChanged(); } } }


        private BoolCN? _Transacciones;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public BoolCN? Transacciones { get => _Transacciones ?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Transacciones)) { _Transacciones = value ?? BoolCN.N; OnPropertyChanged(); } } }

        
    }
}
