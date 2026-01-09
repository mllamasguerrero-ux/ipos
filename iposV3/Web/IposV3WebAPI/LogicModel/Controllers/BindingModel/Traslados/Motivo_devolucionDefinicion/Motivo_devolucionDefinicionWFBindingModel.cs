
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
    public class Motivo_devolucionDefinicionWFBindingModel : Validatable
    {

        public Motivo_devolucionDefinicionWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private long? _EmpresaId;
        [XmlAttribute]
        public long? EmpresaId { get => _EmpresaId; set { if (RaiseAcceptPendingChange(value, _EmpresaId)) { _EmpresaId = value; OnPropertyChanged(); } } }

        private long? _SucursalId;
        [XmlAttribute]
        public long? SucursalId { get => _SucursalId; set { if (RaiseAcceptPendingChange(value, _SucursalId)) { _SucursalId = value; OnPropertyChanged(); } } }

        private long? _Motivo_devolucionid;
        [XmlAttribute]
        public long? Motivo_devolucionid { get => _Motivo_devolucionid; set { if (RaiseAcceptPendingChange(value, _Motivo_devolucionid)) { _Motivo_devolucionid = value; OnPropertyChanged(); } } }

        private string? _Motivo_devolucionClave;
        [XmlAttribute]
        public string? Motivo_devolucionClave { get => _Motivo_devolucionClave; set { if (RaiseAcceptPendingChange(value, _Motivo_devolucionClave)) { _Motivo_devolucionClave = value; OnPropertyChanged(); } } }

        private string? _Motivo_devolucionNombre;
        [XmlAttribute]
        public string? Motivo_devolucionNombre { get => _Motivo_devolucionNombre; set { if (RaiseAcceptPendingChange(value, _Motivo_devolucionNombre)) { _Motivo_devolucionNombre = value; OnPropertyChanged(); } } }

        private string? _Otromotivodevolucion;
        [XmlAttribute]
        public string? Otromotivodevolucion { get => _Otromotivodevolucion; set { if (RaiseAcceptPendingChange(value, _Otromotivodevolucion)) { _Otromotivodevolucion = value; OnPropertyChanged(); } } }

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


        public static Motivo_devolucionDefinicionWFBindingModel CreateFromAnonymous( dynamic obj)
        {
            var buffer_Motivo_devolucionDefinicionWFBindingModel = new Motivo_devolucionDefinicionWFBindingModel();

        	buffer_Motivo_devolucionDefinicionWFBindingModel._Id = obj.Id;

        	buffer_Motivo_devolucionDefinicionWFBindingModel._EmpresaId = obj.EmpresaId;

        	buffer_Motivo_devolucionDefinicionWFBindingModel._SucursalId = obj.SucursalId;

        	buffer_Motivo_devolucionDefinicionWFBindingModel._Motivo_devolucionid = obj.Motivo_devolucionid;

        	buffer_Motivo_devolucionDefinicionWFBindingModel._Motivo_devolucionClave = obj.Motivo_devolucionClave;

        	buffer_Motivo_devolucionDefinicionWFBindingModel._Motivo_devolucionNombre = obj.Motivo_devolucionNombre;

        	buffer_Motivo_devolucionDefinicionWFBindingModel._Otromotivodevolucion = obj.Otromotivodevolucion;

            return buffer_Motivo_devolucionDefinicionWFBindingModel;
        }


    }

    
     
}

