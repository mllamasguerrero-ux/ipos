
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
    
    public class GuiaBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public GuiaBindingModelGenerated()
        {
        }
        
        #if PROYECTO_WEB
        public GuiaBindingModelGenerated(Guia item)
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

        private string? _Nota;
        [XmlAttribute]
        public string? Nota { get => _Nota; set { if (RaiseAcceptPendingChange(value, _Nota)) { _Nota = value; OnPropertyChanged(); } } }

        private string? _Guiapaqueteria;
        [XmlAttribute]
        public string? Guiapaqueteria { get => _Guiapaqueteria; set { if (RaiseAcceptPendingChange(value, _Guiapaqueteria)) { _Guiapaqueteria = value; OnPropertyChanged(); } } }

        private int? _Folio;
        [XmlAttribute]
        public int? Folio { get => _Folio; set { if (RaiseAcceptPendingChange(value, _Folio)) { _Folio = value; OnPropertyChanged(); } } }

        private long? _Encargadoguiaid;
        [XmlAttribute]
        public long? Encargadoguiaid { get => _Encargadoguiaid; set { if (RaiseAcceptPendingChange(value, _Encargadoguiaid)) { _Encargadoguiaid = value; OnPropertyChanged(); } } }

        private string? _EncargadoguiaClave;
        [XmlAttribute]
        public string? EncargadoguiaClave { get => _EncargadoguiaClave; set { if (RaiseAcceptPendingChange(value, _EncargadoguiaClave)) { _EncargadoguiaClave = value; OnPropertyChanged(); } } }

        private string? _EncargadoguiaNombre;
        [XmlAttribute]
        public string? EncargadoguiaNombre { get => _EncargadoguiaNombre; set { if (RaiseAcceptPendingChange(value, _EncargadoguiaNombre)) { _EncargadoguiaNombre = value; OnPropertyChanged(); } } }

        private long? _Estadoguiaid;
        [XmlAttribute]
        public long? Estadoguiaid { get => _Estadoguiaid; set { if (RaiseAcceptPendingChange(value, _Estadoguiaid)) { _Estadoguiaid = value; OnPropertyChanged(); } } }

        private string? _EstadoguiaClave;
        [XmlAttribute]
        public string? EstadoguiaClave { get => _EstadoguiaClave; set { if (RaiseAcceptPendingChange(value, _EstadoguiaClave)) { _EstadoguiaClave = value; OnPropertyChanged(); } } }

        private string? _EstadoguiaNombre;
        [XmlAttribute]
        public string? EstadoguiaNombre { get => _EstadoguiaNombre; set { if (RaiseAcceptPendingChange(value, _EstadoguiaNombre)) { _EstadoguiaNombre = value; OnPropertyChanged(); } } }

        private long? _Cajeroid;
        [XmlAttribute]
        public long? Cajeroid { get => _Cajeroid; set { if (RaiseAcceptPendingChange(value, _Cajeroid)) { _Cajeroid = value; OnPropertyChanged(); } } }

        private string? _CajeroClave;
        [XmlAttribute]
        public string? CajeroClave { get => _CajeroClave; set { if (RaiseAcceptPendingChange(value, _CajeroClave)) { _CajeroClave = value; OnPropertyChanged(); } } }

        private string? _CajeroNombre;
        [XmlAttribute]
        public string? CajeroNombre { get => _CajeroNombre; set { if (RaiseAcceptPendingChange(value, _CajeroNombre)) { _CajeroNombre = value; OnPropertyChanged(); } } }

        private long? _Corteid;
        [XmlAttribute]
        public long? Corteid { get => _Corteid; set { if (RaiseAcceptPendingChange(value, _Corteid)) { _Corteid = value; OnPropertyChanged(); } } }

        private string? _CorteClave;
        [XmlAttribute]
        public string? CorteClave { get => _CorteClave; set { if (RaiseAcceptPendingChange(value, _CorteClave)) { _CorteClave = value; OnPropertyChanged(); } } }

        private string? _CorteNombre;
        [XmlAttribute]
        public string? CorteNombre { get => _CorteNombre; set { if (RaiseAcceptPendingChange(value, _CorteNombre)) { _CorteNombre = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechahora;
        [XmlAttribute]
        public DateTimeOffset? Fechahora { get => _Fechahora; set { if (RaiseAcceptPendingChange(value, _Fechahora)) { _Fechahora = value; OnPropertyChanged(); } } }

        private long? _Tipoentregaid;
        [XmlAttribute]
        public long? Tipoentregaid { get => _Tipoentregaid; set { if (RaiseAcceptPendingChange(value, _Tipoentregaid)) { _Tipoentregaid = value; OnPropertyChanged(); } } }

        private string? _TipoentregaClave;
        [XmlAttribute]
        public string? TipoentregaClave { get => _TipoentregaClave; set { if (RaiseAcceptPendingChange(value, _TipoentregaClave)) { _TipoentregaClave = value; OnPropertyChanged(); } } }

        private string? _TipoentregaNombre;
        [XmlAttribute]
        public string? TipoentregaNombre { get => _TipoentregaNombre; set { if (RaiseAcceptPendingChange(value, _TipoentregaNombre)) { _TipoentregaNombre = value; OnPropertyChanged(); } } }

        private long? _Vehiculoid;
        [XmlAttribute]
        public long? Vehiculoid { get => _Vehiculoid; set { if (RaiseAcceptPendingChange(value, _Vehiculoid)) { _Vehiculoid = value; OnPropertyChanged(); } } }

        private string? _VehiculoClave;
        [XmlAttribute]
        public string? VehiculoClave { get => _VehiculoClave; set { if (RaiseAcceptPendingChange(value, _VehiculoClave)) { _VehiculoClave = value; OnPropertyChanged(); } } }

        private string? _VehiculoNombre;
        [XmlAttribute]
        public string? VehiculoNombre { get => _VehiculoNombre; set { if (RaiseAcceptPendingChange(value, _VehiculoNombre)) { _VehiculoNombre = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechaestimadarec;
        [XmlAttribute]
        public DateTimeOffset? Fechaestimadarec { get => _Fechaestimadarec; set { if (RaiseAcceptPendingChange(value, _Fechaestimadarec)) { _Fechaestimadarec = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Horaestimadrec;
        [XmlAttribute]
        public DateTimeOffset? Horaestimadrec { get => _Horaestimadrec; set { if (RaiseAcceptPendingChange(value, _Horaestimadrec)) { _Horaestimadrec = value; OnPropertyChanged(); } } }

        private string? _Clave;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public string? Clave { get => _Clave?? ""; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value?? ""; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public string? Nombre { get => _Nombre?? ""; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value?? ""; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Guia"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Nota|Guiapaqueteria|Encargadoguia.Clave|Encargadoguia.Nombre|Estadoguia.Clave|Estadoguia.Nombre|Cajero.Clave|Cajero.Nombre|Corte.Clave|Corte.Nombre|Tipoentrega.Clave|Tipoentrega.Nombre|Vehiculo.Clave|Vehiculo.Nombre|Clave|Nombre";
        }


        #if PROYECTO_WEB
        public void FillCatalogRelatedFields(Guia item)
        {

             this._EncargadoguiaClave = item.Encargadoguia?.Clave;

             this._EncargadoguiaNombre = item.Encargadoguia?.Nombre;

             this._EstadoguiaClave = item.Estadoguia?.Clave;

             this._EstadoguiaNombre = item.Estadoguia?.Nombre;

             this._CajeroClave = item.Cajero?.Clave;

             this._CajeroNombre = item.Cajero?.Nombre;

             this._CorteClave = item.Corte?.Clave;

             this._CorteNombre = item.Corte?.Nombre;

             this._TipoentregaClave = item.Tipoentrega?.Clave;

             this._TipoentregaNombre = item.Tipoentrega?.Nombre;

             this._VehiculoClave = item.Vehiculo?.Clave;

             this._VehiculoNombre = item.Vehiculo?.Nombre;


        }


        public void FillEntityValues(ref Guia item)
        {


            item.CreadoPorId = CreadoPorId ;


            item.ModificadoPorId = ModificadoPorId ;


            item.EmpresaId = EmpresaId ?? 0;


            item.SucursalId = SucursalId ?? 0;


            item.Id = Id ?? 0;


            item.Activo = Activo ?? BoolCS.S;


            item.Creado = Creado ?? DateTime.UtcNow;


            item.Modificado = Modificado ?? DateTime.UtcNow;


            item.Nota = Nota ;


            item.Guiapaqueteria = Guiapaqueteria ;


            item.Folio = Folio ;


            item.Encargadoguiaid = Encargadoguiaid ;


            item.Estadoguiaid = Estadoguiaid ;


            item.Cajeroid = Cajeroid ;


            item.Corteid = Corteid ;


            item.Fecha = Fecha ;


            item.Fechahora = Fechahora ;


            item.Tipoentregaid = Tipoentregaid ;


            item.Vehiculoid = Vehiculoid ;


            item.Fechaestimadarec = Fechaestimadarec ;


            item.Horaestimadrec = Horaestimadrec ;


            item.Clave = Clave ?? "";


            item.Nombre = Nombre ?? "";



        }

        public void FillFromEntity(Guia item)
        {

            CreadoPorId = item.CreadoPorId;

            ModificadoPorId = item.ModificadoPorId;

            EmpresaId = item.EmpresaId;

            SucursalId = item.SucursalId;

            Id = item.Id;

            Activo = item.Activo;

            Creado = item.Creado;

            Modificado = item.Modificado;

            Nota = item.Nota;

            Guiapaqueteria = item.Guiapaqueteria;

            Folio = item.Folio;

            Encargadoguiaid = item.Encargadoguiaid;

            Estadoguiaid = item.Estadoguiaid;

            Cajeroid = item.Cajeroid;

            Corteid = item.Corteid;

            Fecha = item.Fecha;

            Fechahora = item.Fechahora;

            Tipoentregaid = item.Tipoentregaid;

            Vehiculoid = item.Vehiculoid;

            Fechaestimadarec = item.Fechaestimadarec;

            Horaestimadrec = item.Horaestimadrec;

            Clave = item.Clave;

            Nombre = item.Nombre;


             FillCatalogRelatedFields(item);


        }
        #endif
        



    }
}

