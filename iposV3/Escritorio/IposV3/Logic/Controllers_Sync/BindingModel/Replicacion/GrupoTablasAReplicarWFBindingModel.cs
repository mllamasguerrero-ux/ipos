
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using IposV3.Model;
using MvvmFramework;
using System.Xml.Serialization;
using IposV3.Services;

namespace BindingModels
{
    
    [XmlRoot]
    public class GrupoTablasAReplicarWFBindingModel : Validatable
    {

        public GrupoTablasAReplicarWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Empresaid;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? Empresaid { get => _Empresaid?? 0; set { if (RaiseAcceptPendingChange(value, _Empresaid)) { _Empresaid = value?? 0; OnPropertyChanged(); } } }

        private long? _Sucursalid;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? Sucursalid { get => _Sucursalid?? 0; set { if (RaiseAcceptPendingChange(value, _Sucursalid)) { _Sucursalid = value?? 0; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private long? _IdGroupDef;
        [XmlAttribute]
        public long? IdGroupDef { get => _IdGroupDef; set { if (RaiseAcceptPendingChange(value, _IdGroupDef)) { _IdGroupDef = value; OnPropertyChanged(); } } }

        private BoolCS? _Activo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCS? Activo { get => _Activo?? BoolCS.S; set { if (RaiseAcceptPendingChange(value, _Activo)) { _Activo = value?? BoolCS.S; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public string? Nombre { get => _Nombre?? ""; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value?? ""; OnPropertyChanged(); } } }

        private string? _Clave;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public string? Clave { get => _Clave?? ""; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value?? ""; OnPropertyChanged(); } } }



        private bool _Replicar;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public bool Replicar { get => _Replicar; set { if (RaiseAcceptPendingChange(value, _Replicar)) { _Replicar = value ; Activo = _Replicar ? BoolCS.S : BoolCS.N; _FueModificado = true; OnPropertyChanged(); } } }




        private bool _FueModificado;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public bool FueModificado { get => _FueModificado; set { if (RaiseAcceptPendingChange(value, _FueModificado)) { _FueModificado = value; Activo = _FueModificado ? BoolCS.S : BoolCS.N; OnPropertyChanged(); } } }


        [XmlAttribute]
        public List<GrupoTablaItemAReplicar>? Tablas { get; set; }

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


        public static GrupoTablasAReplicarWFBindingModel CreateFromBasic(GrupoTablasAReplicar obj)
        {
            var buffer_GrupoTablasAReplicarWFBindingModel = new GrupoTablasAReplicarWFBindingModel();

        	buffer_GrupoTablasAReplicarWFBindingModel._Empresaid = obj.Empresaid;

        	buffer_GrupoTablasAReplicarWFBindingModel._Sucursalid = obj.Sucursalid;

        	buffer_GrupoTablasAReplicarWFBindingModel._Id = obj.Id;

        	buffer_GrupoTablasAReplicarWFBindingModel._IdGroupDef = obj.IdGroupDef;

        	buffer_GrupoTablasAReplicarWFBindingModel._Activo = obj.Activo;

        	buffer_GrupoTablasAReplicarWFBindingModel._Nombre = obj.Nombre;

        	buffer_GrupoTablasAReplicarWFBindingModel._Clave = obj.Clave;

            buffer_GrupoTablasAReplicarWFBindingModel._Replicar = obj.Activo == BoolCS.S;

            buffer_GrupoTablasAReplicarWFBindingModel._FueModificado = false;

            buffer_GrupoTablasAReplicarWFBindingModel.Tablas = obj.Tablas;

            return buffer_GrupoTablasAReplicarWFBindingModel;
        }


    }

    
     
}

