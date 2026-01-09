
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
    
    public class TerminalpagoservicioBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public TerminalpagoservicioBindingModelGenerated()
        {
        }

        #if PROYECTO_WEB
        public TerminalpagoservicioBindingModelGenerated(Terminalpagoservicio item)
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
        [XmlAttribute]
        public long? EmpresaId { get => _EmpresaId?? 0; set { if (RaiseAcceptPendingChange(value, _EmpresaId)) { _EmpresaId = value?? 0; OnPropertyChanged(); } } }

        private long? _SucursalId;
        [XmlAttribute]
        public long? SucursalId { get => _SucursalId?? 0; set { if (RaiseAcceptPendingChange(value, _SucursalId)) { _SucursalId = value?? 0; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? Id { get => _Id?? 0; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value?? 0; OnPropertyChanged(); } } }

        private BoolCS? _Activo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCS? Activo { get => _Activo?? BoolCS.S; set { if (RaiseAcceptPendingChange(value, _Activo)) { _Activo = value?? BoolCS.S; OnPropertyChanged(); } } }

        private DateTimeOffset? _Creado;
        [XmlAttribute]
        public DateTimeOffset? Creado { get => _Creado?? DateTime.UtcNow; set { if (RaiseAcceptPendingChange(value, _Creado)) { _Creado = value?? DateTime.UtcNow; OnPropertyChanged(); } } }

        private DateTimeOffset? _Modificado;
        [XmlAttribute]
        public DateTimeOffset? Modificado { get => _Modificado?? DateTime.UtcNow; set { if (RaiseAcceptPendingChange(value, _Modificado)) { _Modificado = value?? DateTime.UtcNow; OnPropertyChanged(); } } }

        private string? _Terminal;
        [XmlAttribute]
        public string? Terminal { get => _Terminal; set { if (RaiseAcceptPendingChange(value, _Terminal)) { _Terminal = value; OnPropertyChanged(); } } }

        private BoolCN? _Esservicio;
        [XmlAttribute]
        public BoolCN? Esservicio { get => _Esservicio; set { if (RaiseAcceptPendingChange(value, _Esservicio)) { _Esservicio = value; OnPropertyChanged(); } } }

        private long? _Sucursalinfoid;
        [XmlAttribute]
        public long? Sucursalinfoid { get => _Sucursalinfoid; set { if (RaiseAcceptPendingChange(value, _Sucursalinfoid)) { _Sucursalinfoid = value; OnPropertyChanged(); } } }

        private string? _SucursalinfoClave;
        [XmlAttribute]
        public string? SucursalinfoClave { get => _SucursalinfoClave; set { if (RaiseAcceptPendingChange(value, _SucursalinfoClave)) { _SucursalinfoClave = value; OnPropertyChanged(); } } }

        private string? _SucursalinfoNombre;
        [XmlAttribute]
        public string? SucursalinfoNombre { get => _SucursalinfoNombre; set { if (RaiseAcceptPendingChange(value, _SucursalinfoNombre)) { _SucursalinfoNombre = value; OnPropertyChanged(); } } }

        private long? _Consecutivo;
        [XmlAttribute]
        public long? Consecutivo { get => _Consecutivo; set { if (RaiseAcceptPendingChange(value, _Consecutivo)) { _Consecutivo = value; OnPropertyChanged(); } } }

        private string? _Clave;
        [XmlAttribute]
        public string? Clave { get => _Clave; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Terminalpagoservicio"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Terminal|Sucursalinfo.Clave|Sucursalinfo.Nombre|Clave|Nombre";
        }


        #if PROYECTO_WEB
        public void FillCatalogRelatedFields(Terminalpagoservicio item)
        {

             this._SucursalinfoClave = item.Sucursalinfo?.Clave;

             this._SucursalinfoNombre = item.Sucursalinfo?.Nombre;


        }


        public void FillEntityValues(ref Terminalpagoservicio item)
        {


            item.CreadoPorId = CreadoPorId ;


            item.ModificadoPorId = ModificadoPorId ;


            item.EmpresaId = EmpresaId ?? 0;


            item.SucursalId = SucursalId ?? 0;


            item.Id = Id ?? 0;


            item.Activo = Activo ?? BoolCS.S;


            item.Creado = Creado ?? DateTime.UtcNow;


            item.Modificado = Modificado ?? DateTime.UtcNow;


            item.Terminal = Terminal ;


            item.Esservicio = Esservicio ;


            item.Sucursalinfoid = Sucursalinfoid ;


            item.Consecutivo = Consecutivo ;


            //item.Clave = Clave ;


            //item.Nombre = Nombre ;



        }

        public void FillFromEntity(Terminalpagoservicio item)
        {

            CreadoPorId = item.CreadoPorId;

            ModificadoPorId = item.ModificadoPorId;

            EmpresaId = item.EmpresaId;

            SucursalId = item.SucursalId;

            Id = item.Id;

            Activo = item.Activo;

            Creado = item.Creado;

            Modificado = item.Modificado;

            Terminal = item.Terminal;

            Esservicio = item.Esservicio;

            Sucursalinfoid = item.Sucursalinfoid;

            Consecutivo = item.Consecutivo;

            Clave = item.Clave;

            Nombre = item.Nombre;


             FillCatalogRelatedFields(item);


        }
        #endif





    }
}

