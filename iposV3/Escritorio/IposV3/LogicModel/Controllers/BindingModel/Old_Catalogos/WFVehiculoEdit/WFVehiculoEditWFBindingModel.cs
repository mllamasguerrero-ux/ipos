
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
    public class WFVehiculoEditWFBindingModel : Validatable
    {

        public WFVehiculoEditWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Sat_configautotransporteid;
        [XmlAttribute]
        public long? Sat_configautotransporteid { get => _Sat_configautotransporteid; set { if (RaiseAcceptPendingChange(value, _Sat_configautotransporteid)) { _Sat_configautotransporteid = value; OnPropertyChanged(); } } }

        private string? _Sat_configautotransporteidClave;
        [XmlAttribute]
        public string? Sat_configautotransporteidClave { get => _Sat_configautotransporteidClave; set { if (RaiseAcceptPendingChange(value, _Sat_configautotransporteidClave)) { _Sat_configautotransporteidClave = value; OnPropertyChanged(); } } }

        private string? _Sat_configautotransporteidNombre;
        [XmlAttribute]
        public string? Sat_configautotransporteidNombre { get => _Sat_configautotransporteidNombre; set { if (RaiseAcceptPendingChange(value, _Sat_configautotransporteidNombre)) { _Sat_configautotransporteidNombre = value; OnPropertyChanged(); } } }

        private string? _Placavm;
        [XmlAttribute]
        public string? Placavm { get => _Placavm; set { if (RaiseAcceptPendingChange(value, _Placavm)) { _Placavm = value; OnPropertyChanged(); } } }

        private string? _Aniomodelovm;
        [XmlAttribute]
        public string? Aniomodelovm { get => _Aniomodelovm; set { if (RaiseAcceptPendingChange(value, _Aniomodelovm)) { _Aniomodelovm = value; OnPropertyChanged(); } } }

        private string? _Polizarespcivil;
        [XmlAttribute]
        public string? Polizarespcivil { get => _Polizarespcivil; set { if (RaiseAcceptPendingChange(value, _Polizarespcivil)) { _Polizarespcivil = value; OnPropertyChanged(); } } }

        private string? _Asegurarespcivil;
        [XmlAttribute]
        public string? Asegurarespcivil { get => _Asegurarespcivil; set { if (RaiseAcceptPendingChange(value, _Asegurarespcivil)) { _Asegurarespcivil = value; OnPropertyChanged(); } } }

        private string? _Aseguramedambiente;
        [XmlAttribute]
        public string? Aseguramedambiente { get => _Aseguramedambiente; set { if (RaiseAcceptPendingChange(value, _Aseguramedambiente)) { _Aseguramedambiente = value; OnPropertyChanged(); } } }

        private string? _Polizamedambiente;
        [XmlAttribute]
        public string? Polizamedambiente { get => _Polizamedambiente; set { if (RaiseAcceptPendingChange(value, _Polizamedambiente)) { _Polizamedambiente = value; OnPropertyChanged(); } } }

        private string? _Polizacarga;
        [XmlAttribute]
        public string? Polizacarga { get => _Polizacarga; set { if (RaiseAcceptPendingChange(value, _Polizacarga)) { _Polizacarga = value; OnPropertyChanged(); } } }

        private string? _Aseguracarga;
        [XmlAttribute]
        public string? Aseguracarga { get => _Aseguracarga; set { if (RaiseAcceptPendingChange(value, _Aseguracarga)) { _Aseguracarga = value; OnPropertyChanged(); } } }

        private string? _Primaseguro;
        [XmlAttribute]
        public string? Primaseguro { get => _Primaseguro; set { if (RaiseAcceptPendingChange(value, _Primaseguro)) { _Primaseguro = value; OnPropertyChanged(); } } }

        private long? _Sat_subtiporem1id;
        [XmlAttribute]
        public long? Sat_subtiporem1id { get => _Sat_subtiporem1id; set { if (RaiseAcceptPendingChange(value, _Sat_subtiporem1id)) { _Sat_subtiporem1id = value; OnPropertyChanged(); } } }

        private string? _Sat_subtiporem1idClave;
        [XmlAttribute]
        public string? Sat_subtiporem1idClave { get => _Sat_subtiporem1idClave; set { if (RaiseAcceptPendingChange(value, _Sat_subtiporem1idClave)) { _Sat_subtiporem1idClave = value; OnPropertyChanged(); } } }

        private string? _Sat_subtiporem1idNombre;
        [XmlAttribute]
        public string? Sat_subtiporem1idNombre { get => _Sat_subtiporem1idNombre; set { if (RaiseAcceptPendingChange(value, _Sat_subtiporem1idNombre)) { _Sat_subtiporem1idNombre = value; OnPropertyChanged(); } } }

        private string? _Placa1;
        [XmlAttribute]
        public string? Placa1 { get => _Placa1; set { if (RaiseAcceptPendingChange(value, _Placa1)) { _Placa1 = value; OnPropertyChanged(); } } }

        private long? _Sat_subtiporem2id;
        [XmlAttribute]
        public long? Sat_subtiporem2id { get => _Sat_subtiporem2id; set { if (RaiseAcceptPendingChange(value, _Sat_subtiporem2id)) { _Sat_subtiporem2id = value; OnPropertyChanged(); } } }

        private string? _Sat_subtiporem2idClave;
        [XmlAttribute]
        public string? Sat_subtiporem2idClave { get => _Sat_subtiporem2idClave; set { if (RaiseAcceptPendingChange(value, _Sat_subtiporem2idClave)) { _Sat_subtiporem2idClave = value; OnPropertyChanged(); } } }

        private string? _Sat_subtiporem2idNombre;
        [XmlAttribute]
        public string? Sat_subtiporem2idNombre { get => _Sat_subtiporem2idNombre; set { if (RaiseAcceptPendingChange(value, _Sat_subtiporem2idNombre)) { _Sat_subtiporem2idNombre = value; OnPropertyChanged(); } } }

        private string? _Placa2;
        [XmlAttribute]
        public string? Placa2 { get => _Placa2; set { if (RaiseAcceptPendingChange(value, _Placa2)) { _Placa2 = value; OnPropertyChanged(); } } }

        private long? _Duenioid;
        [XmlAttribute]
        public long? Duenioid { get => _Duenioid; set { if (RaiseAcceptPendingChange(value, _Duenioid)) { _Duenioid = value; OnPropertyChanged(); } } }

        private string? _DuenioidClave;
        [XmlAttribute]
        public string? DuenioidClave { get => _DuenioidClave; set { if (RaiseAcceptPendingChange(value, _DuenioidClave)) { _DuenioidClave = value; OnPropertyChanged(); } } }

        private string? _DuenioidNombre;
        [XmlAttribute]
        public string? DuenioidNombre { get => _DuenioidNombre; set { if (RaiseAcceptPendingChange(value, _DuenioidNombre)) { _DuenioidNombre = value; OnPropertyChanged(); } } }

        private string? _Numpermisosct;
        [XmlAttribute]
        public string? Numpermisosct { get => _Numpermisosct; set { if (RaiseAcceptPendingChange(value, _Numpermisosct)) { _Numpermisosct = value; OnPropertyChanged(); } } }

        private long? _Sat_tipopermisoid;
        [XmlAttribute]
        public long? Sat_tipopermisoid { get => _Sat_tipopermisoid; set { if (RaiseAcceptPendingChange(value, _Sat_tipopermisoid)) { _Sat_tipopermisoid = value; OnPropertyChanged(); } } }

        private string? _Sat_tipopermisoidClave;
        [XmlAttribute]
        public string? Sat_tipopermisoidClave { get => _Sat_tipopermisoidClave; set { if (RaiseAcceptPendingChange(value, _Sat_tipopermisoidClave)) { _Sat_tipopermisoidClave = value; OnPropertyChanged(); } } }

        private string? _Sat_tipopermisoidNombre;
        [XmlAttribute]
        public string? Sat_tipopermisoidNombre { get => _Sat_tipopermisoidNombre; set { if (RaiseAcceptPendingChange(value, _Sat_tipopermisoidNombre)) { _Sat_tipopermisoidNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Activo;
        [XmlAttribute]
        public BoolCN? Activo { get => _Activo; set { if (RaiseAcceptPendingChange(value, _Activo)) { _Activo = value; OnPropertyChanged(); } } }

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

