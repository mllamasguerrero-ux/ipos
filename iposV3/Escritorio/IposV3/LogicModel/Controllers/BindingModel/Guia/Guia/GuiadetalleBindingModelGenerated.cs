
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
    
    public class GuiadetalleBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public GuiadetalleBindingModelGenerated()
        {
        }
        
        #if PROYECTO_WEB
        public GuiadetalleBindingModelGenerated(Guiadetalle item)
        {
            FillFromEntity(item);
        }


        public T CreateSubEntity<T>() where T : EntityBase, new()
        {
            return new T() { EmpresaId = (long)(EmpresaId ?? 0), SucursalId = (long)(SucursalId ?? 0) };
        }
        #endif
        


        private long? _CreadoPorId;
        [XmlAttribute]
        public long? CreadoPorId { get => _CreadoPorId; set { if (RaiseAcceptPendingChange(value, _CreadoPorId)) { _CreadoPorId = value; OnPropertyChanged(); } } }

        private long? _ModificadoPorId;
        [XmlAttribute]
        public long? ModificadoPorId { get => _ModificadoPorId; set { if (RaiseAcceptPendingChange(value, _ModificadoPorId)) { _ModificadoPorId = value; OnPropertyChanged(); } } }

        private long? _EmpresaId;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? EmpresaId { get => _EmpresaId?? 0; set { if (RaiseAcceptPendingChange(value, _EmpresaId)) { _EmpresaId = value?? 0; OnPropertyChanged(); } } }

        private long? _SucursalId;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? SucursalId { get => _SucursalId?? 0; set { if (RaiseAcceptPendingChange(value, _SucursalId)) { _SucursalId = value?? 0; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? Id { get => _Id?? 0; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value?? 0; OnPropertyChanged(); } } }

        private BoolCS? _Activo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCS? Activo { get => _Activo?? BoolCS.S; set { if (RaiseAcceptPendingChange(value, _Activo)) { _Activo = value?? BoolCS.S; OnPropertyChanged(); } } }

        private DateTimeOffset? _Creado;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public DateTimeOffset? Creado { get => _Creado?? DateTime.UtcNow; set { if (RaiseAcceptPendingChange(value, _Creado)) { _Creado = value?? DateTime.UtcNow; OnPropertyChanged(); } } }

        private DateTimeOffset? _Modificado;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public DateTimeOffset? Modificado { get => _Modificado?? DateTime.UtcNow; set { if (RaiseAcceptPendingChange(value, _Modificado)) { _Modificado = value?? DateTime.UtcNow; OnPropertyChanged(); } } }

        private long? _Guiaid;
        [XmlAttribute]
        public long? Guiaid { get => _Guiaid; set { if (RaiseAcceptPendingChange(value, _Guiaid)) { _Guiaid = value; OnPropertyChanged(); } } }

        private string? _GuiaClave;
        [XmlAttribute]
        public string? GuiaClave { get => _GuiaClave; set { if (RaiseAcceptPendingChange(value, _GuiaClave)) { _GuiaClave = value; OnPropertyChanged(); } } }

        private string? _GuiaNombre;
        [XmlAttribute]
        public string? GuiaNombre { get => _GuiaNombre; set { if (RaiseAcceptPendingChange(value, _GuiaNombre)) { _GuiaNombre = value; OnPropertyChanged(); } } }

        private long? _Doctoid;
        [XmlAttribute]
        public long? Doctoid { get => _Doctoid; set { if (RaiseAcceptPendingChange(value, _Doctoid)) { _Doctoid = value; OnPropertyChanged(); } } }

        private string? _DoctoClave;
        [XmlAttribute]
        public string? DoctoClave { get => _DoctoClave; set { if (RaiseAcceptPendingChange(value, _DoctoClave)) { _DoctoClave = value; OnPropertyChanged(); } } }

        private string? _DoctoNombre;
        [XmlAttribute]
        public string? DoctoNombre { get => _DoctoNombre; set { if (RaiseAcceptPendingChange(value, _DoctoNombre)) { _DoctoNombre = value; OnPropertyChanged(); } } }

        private long? _Estadoguiaid;
        [XmlAttribute]
        public long? Estadoguiaid { get => _Estadoguiaid; set { if (RaiseAcceptPendingChange(value, _Estadoguiaid)) { _Estadoguiaid = value; OnPropertyChanged(); } } }

        private string? _EstadoguiaClave;
        [XmlAttribute]
        public string? EstadoguiaClave { get => _EstadoguiaClave; set { if (RaiseAcceptPendingChange(value, _EstadoguiaClave)) { _EstadoguiaClave = value; OnPropertyChanged(); } } }

        private string? _EstadoguiaNombre;
        [XmlAttribute]
        public string? EstadoguiaNombre { get => _EstadoguiaNombre; set { if (RaiseAcceptPendingChange(value, _EstadoguiaNombre)) { _EstadoguiaNombre = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecharecibido;
        [XmlAttribute]
        public DateTimeOffset? Fecharecibido { get => _Fecharecibido; set { if (RaiseAcceptPendingChange(value, _Fecharecibido)) { _Fecharecibido = value; OnPropertyChanged(); } } }

        private string? _Fechahorarecibido;
        [XmlAttribute]
        public string? Fechahorarecibido { get => _Fechahorarecibido; set { if (RaiseAcceptPendingChange(value, _Fechahorarecibido)) { _Fechahorarecibido = value; OnPropertyChanged(); } } }

        private long? _Personaidrecibio;
        [XmlAttribute]
        public long? Personaidrecibio { get => _Personaidrecibio; set { if (RaiseAcceptPendingChange(value, _Personaidrecibio)) { _Personaidrecibio = value; OnPropertyChanged(); } } }

        private string? _PersonarecibioClave;
        [XmlAttribute]
        public string? PersonarecibioClave { get => _PersonarecibioClave; set { if (RaiseAcceptPendingChange(value, _PersonarecibioClave)) { _PersonarecibioClave = value; OnPropertyChanged(); } } }

        private string? _PersonarecibioNombre;
        [XmlAttribute]
        public string? PersonarecibioNombre { get => _PersonarecibioNombre; set { if (RaiseAcceptPendingChange(value, _PersonarecibioNombre)) { _PersonarecibioNombre = value; OnPropertyChanged(); } } }

        private long? _Cartaporteid;
        [XmlAttribute]
        public long? Cartaporteid { get => _Cartaporteid; set { if (RaiseAcceptPendingChange(value, _Cartaporteid)) { _Cartaporteid = value; OnPropertyChanged(); } } }

        private string? _CartaporteClave;
        [XmlAttribute]
        public string? CartaporteClave { get => _CartaporteClave; set { if (RaiseAcceptPendingChange(value, _CartaporteClave)) { _CartaporteClave = value; OnPropertyChanged(); } } }

        private string? _CartaporteNombre;
        [XmlAttribute]
        public string? CartaporteNombre { get => _CartaporteNombre; set { if (RaiseAcceptPendingChange(value, _CartaporteNombre)) { _CartaporteNombre = value; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Guiadetalle"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Guia.Clave|Guia.Nombre|Docto.Clave|Docto.Nombre|Estadoguia.Clave|Estadoguia.Nombre|Fechahorarecibido|Personarecibio.Clave|Personarecibio.Nombre|Cartaporte.Clave|Cartaporte.Nombre";
        }


        #if PROYECTO_WEB
        public void FillCatalogRelatedFields(Guiadetalle item)
        {

             this._GuiaClave = item.Guia?.Clave;

             this._GuiaNombre = item.Guia?.Nombre;

             this._DoctoClave = item.Docto?.Clave;

             this._DoctoNombre = item.Docto?.Nombre;

             this._EstadoguiaClave = item.Estadoguia?.Clave;

             this._EstadoguiaNombre = item.Estadoguia?.Nombre;

             this._PersonarecibioClave = item.Personarecibio?.Clave;

             this._PersonarecibioNombre = item.Personarecibio?.Nombre;

             this._CartaporteClave = item.Cartaporte?.Clave;

             this._CartaporteNombre = item.Cartaporte?.Nombre;


        }


        public void FillEntityValues(ref Guiadetalle item)
        {


            item.CreadoPorId = CreadoPorId ;


            item.ModificadoPorId = ModificadoPorId ;


            item.EmpresaId = EmpresaId ?? 0;


            item.SucursalId = SucursalId ?? 0;


            item.Id = Id ?? 0;


            item.Activo = Activo ?? BoolCS.S;


            item.Creado = Creado ?? DateTime.UtcNow;


            item.Modificado = Modificado ?? DateTime.UtcNow;


            item.Guiaid = Guiaid ;


            item.Doctoid = Doctoid ;


            item.Estadoguiaid = Estadoguiaid ;


            item.Fecharecibido = Fecharecibido ;


            item.Fechahorarecibido = Fechahorarecibido ;


            item.Personaidrecibio = Personaidrecibio ;


            item.Cartaporteid = Cartaporteid ;



        }

        public void FillFromEntity(Guiadetalle item)
        {

            CreadoPorId = item.CreadoPorId;

            ModificadoPorId = item.ModificadoPorId;

            EmpresaId = item.EmpresaId;

            SucursalId = item.SucursalId;

            Id = item.Id;

            Activo = item.Activo;

            Creado = item.Creado;

            Modificado = item.Modificado;

            Guiaid = item.Guiaid;

            Doctoid = item.Doctoid;

            Estadoguiaid = item.Estadoguiaid;

            Fecharecibido = item.Fecharecibido;

            Fechahorarecibido = item.Fechahorarecibido;

            Personaidrecibio = item.Personaidrecibio;

            Cartaporteid = item.Cartaporteid;


             FillCatalogRelatedFields(item);


        }
        #endif
        



    }
}

