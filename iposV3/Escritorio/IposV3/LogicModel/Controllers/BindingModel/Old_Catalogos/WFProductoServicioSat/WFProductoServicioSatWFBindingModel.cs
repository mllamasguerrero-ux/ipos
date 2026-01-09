
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
    public class WFProductoServicioSatWFBindingModel : Validatable
    {

        public WFProductoServicioSatWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Buscar;
        [XmlAttribute]
        public string? Buscar { get => _Buscar; set { if (RaiseAcceptPendingChange(value, _Buscar)) { _Buscar = value; OnPropertyChanged(); } } }

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

    
    [XmlRoot]
    public class WFProductoServicioSatWF_Sat_productoservicio_filtroBindingModel : Validatable
    {

        public WFProductoServicioSatWF_Sat_productoservicio_filtroBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private string? _Sat_claveprodserv;
        [XmlAttribute]
        public string? Sat_claveprodserv { get => _Sat_claveprodserv; set { if (RaiseAcceptPendingChange(value, _Sat_claveprodserv)) { _Sat_claveprodserv = value; OnPropertyChanged(); } } }

        private string? _Sat_descripcion;
        [XmlAttribute]
        public string? Sat_descripcion { get => _Sat_descripcion; set { if (RaiseAcceptPendingChange(value, _Sat_descripcion)) { _Sat_descripcion = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Sat_fechainicio;
        [XmlAttribute]
        public DateTimeOffset? Sat_fechainicio { get => _Sat_fechainicio; set { if (RaiseAcceptPendingChange(value, _Sat_fechainicio)) { _Sat_fechainicio = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Sat_fechafin;
        [XmlAttribute]
        public DateTimeOffset? Sat_fechafin { get => _Sat_fechafin; set { if (RaiseAcceptPendingChange(value, _Sat_fechafin)) { _Sat_fechafin = value; OnPropertyChanged(); } } }

        private string? _Sat_ivatrasladado;
        [XmlAttribute]
        public string? Sat_ivatrasladado { get => _Sat_ivatrasladado; set { if (RaiseAcceptPendingChange(value, _Sat_ivatrasladado)) { _Sat_ivatrasladado = value; OnPropertyChanged(); } } }

        private string? _Sat_iepstrasladado;
        [XmlAttribute]
        public string? Sat_iepstrasladado { get => _Sat_iepstrasladado; set { if (RaiseAcceptPendingChange(value, _Sat_iepstrasladado)) { _Sat_iepstrasladado = value; OnPropertyChanged(); } } }

        private string? _Sat_complemento;
        [XmlAttribute]
        public string? Sat_complemento { get => _Sat_complemento; set { if (RaiseAcceptPendingChange(value, _Sat_complemento)) { _Sat_complemento = value; OnPropertyChanged(); } } }

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

