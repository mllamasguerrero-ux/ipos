
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
    public class WFSyncConfigWFBindingModel : Validatable
    {

        public WFSyncConfigWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Conexion;
        [XmlAttribute]
        public string? Conexion { get => _Conexion; set { if (RaiseAcceptPendingChange(value, _Conexion)) { _Conexion = value; OnPropertyChanged(); } } }

        private string? _Conexionenred;
        [XmlAttribute]
        public string? Conexionenred { get => _Conexionenred; set { if (RaiseAcceptPendingChange(value, _Conexionenred)) { _Conexionenred = value; OnPropertyChanged(); } } }

        private BoolCN? _Habsync;
        [XmlAttribute]
        public BoolCN? Habsync { get => _Habsync; set { if (RaiseAcceptPendingChange(value, _Habsync)) { _Habsync = value; OnPropertyChanged(); } } }

        private BoolCN? _Cambiomanualdefecha;
        [XmlAttribute]
        public BoolCN? Cambiomanualdefecha { get => _Cambiomanualdefecha; set { if (RaiseAcceptPendingChange(value, _Cambiomanualdefecha)) { _Cambiomanualdefecha = value; OnPropertyChanged(); } } }

        private BoolCN? _Autosync;
        [XmlAttribute]
        public BoolCN? Autosync { get => _Autosync; set { if (RaiseAcceptPendingChange(value, _Autosync)) { _Autosync = value; OnPropertyChanged(); } } }

        private BoolCN? _Limpiarnosync;
        [XmlAttribute]
        public BoolCN? Limpiarnosync { get => _Limpiarnosync; set { if (RaiseAcceptPendingChange(value, _Limpiarnosync)) { _Limpiarnosync = value; OnPropertyChanged(); } } }

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

