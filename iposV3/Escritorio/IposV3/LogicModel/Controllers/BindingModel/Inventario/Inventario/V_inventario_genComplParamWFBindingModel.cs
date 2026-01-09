
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
    public class V_inventario_genComplParamWFBindingModel : Validatable
    {

        public V_inventario_genComplParamWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _EmpresaId;
        [XmlAttribute]
        public long? EmpresaId { get => _EmpresaId; set { if (RaiseAcceptPendingChange(value, _EmpresaId)) { _EmpresaId = value; OnPropertyChanged(); } } }

        private long? _SucursalId;
        [XmlAttribute]
        public long? SucursalId { get => _SucursalId; set { if (RaiseAcceptPendingChange(value, _SucursalId)) { _SucursalId = value; OnPropertyChanged(); } } }

        private long? _Doctoid;
        [XmlAttribute]
        public long? Doctoid { get => _Doctoid; set { if (RaiseAcceptPendingChange(value, _Doctoid)) { _Doctoid = value; OnPropertyChanged(); } } }

        private long? _Almacenid;
        [XmlAttribute]
        public long? Almacenid { get => _Almacenid; set { if (RaiseAcceptPendingChange(value, _Almacenid)) { _Almacenid = value; OnPropertyChanged(); } } }

        private string? _Almacenclave;
        [XmlAttribute]
        public string? Almacenclave { get => _Almacenclave; set { if (RaiseAcceptPendingChange(value, _Almacenclave)) { _Almacenclave = value; OnPropertyChanged(); } } }

        private string? _Almacennombre;
        [XmlAttribute]
        public string? Almacennombre { get => _Almacennombre; set { if (RaiseAcceptPendingChange(value, _Almacennombre)) { _Almacennombre = value; OnPropertyChanged(); } } }

        private long? _Usuarioid;
        [XmlAttribute]
        public long? Usuarioid { get => _Usuarioid; set { if (RaiseAcceptPendingChange(value, _Usuarioid)) { _Usuarioid = value; OnPropertyChanged(); } } }

        private long? _Subtipodoctoid;
        [XmlAttribute]
        public long? Subtipodoctoid { get => _Subtipodoctoid; set { if (RaiseAcceptPendingChange(value, _Subtipodoctoid)) { _Subtipodoctoid = value; OnPropertyChanged(); } } }

        private string? _Subtipodoctoclave;
        [XmlAttribute]
        public string? Subtipodoctoclave { get => _Subtipodoctoclave; set { if (RaiseAcceptPendingChange(value, _Subtipodoctoclave)) { _Subtipodoctoclave = value; OnPropertyChanged(); } } }

        private string? _Subtipodoctonombre;
        [XmlAttribute]
        public string? Subtipodoctonombre { get => _Subtipodoctonombre; set { if (RaiseAcceptPendingChange(value, _Subtipodoctonombre)) { _Subtipodoctonombre = value; OnPropertyChanged(); } } }

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


        public static V_inventario_genComplParamWFBindingModel CreateFromAnonymous( dynamic obj)
        {
            var buffer_V_inventario_genComplParamWFBindingModel = new V_inventario_genComplParamWFBindingModel();

        	buffer_V_inventario_genComplParamWFBindingModel._EmpresaId = obj.EmpresaId;

        	buffer_V_inventario_genComplParamWFBindingModel._SucursalId = obj.SucursalId;

        	buffer_V_inventario_genComplParamWFBindingModel._Doctoid = obj.Doctoid;

        	buffer_V_inventario_genComplParamWFBindingModel._Almacenid = obj.Almacenid;

        	buffer_V_inventario_genComplParamWFBindingModel._Almacenclave = obj.Almacenclave;

        	buffer_V_inventario_genComplParamWFBindingModel._Almacennombre = obj.Almacennombre;

        	buffer_V_inventario_genComplParamWFBindingModel._Usuarioid = obj.Usuarioid;

        	buffer_V_inventario_genComplParamWFBindingModel._Subtipodoctoid = obj.Subtipodoctoid;

        	buffer_V_inventario_genComplParamWFBindingModel._Subtipodoctoclave = obj.Subtipodoctoclave;

        	buffer_V_inventario_genComplParamWFBindingModel._Subtipodoctonombre = obj.Subtipodoctonombre;

            return buffer_V_inventario_genComplParamWFBindingModel;
        }


    }

    
     
}

