
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
    
    public class ClerkpagoservicioBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public ClerkpagoservicioBindingModelGenerated()
        {
        }

        #if PROYECTO_WEB
        public ClerkpagoservicioBindingModelGenerated(Clerkpagoservicio item)
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

        private string? _Clerkid;
        [XmlAttribute]
        public string? Clerkid { get => _Clerkid; set { if (RaiseAcceptPendingChange(value, _Clerkid)) { _Clerkid = value; OnPropertyChanged(); } } }

        private BoolCN? _Esservicio;
        [XmlAttribute]
        public BoolCN? Esservicio { get => _Esservicio; set { if (RaiseAcceptPendingChange(value, _Esservicio)) { _Esservicio = value; OnPropertyChanged(); } } }

        private long? _Sucursal_id;
        [XmlAttribute]
        public long? Sucursal_id { get => _Sucursal_id; set { if (RaiseAcceptPendingChange(value, _Sucursal_id)) { _Sucursal_id = value; OnPropertyChanged(); } } }

        private string? _Sucursal_infoClave;
        [XmlAttribute]
        public string? Sucursal_infoClave { get => _Sucursal_infoClave; set { if (RaiseAcceptPendingChange(value, _Sucursal_infoClave)) { _Sucursal_infoClave = value; OnPropertyChanged(); } } }

        private string? _Sucursal_infoNombre;
        [XmlAttribute]
        public string? Sucursal_infoNombre { get => _Sucursal_infoNombre; set { if (RaiseAcceptPendingChange(value, _Sucursal_infoNombre)) { _Sucursal_infoNombre = value; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Clerkpagoservicio"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Clerkid|Sucursal_info.Clave|Sucursal_info.Nombre";
        }



        #if PROYECTO_WEB
        public void FillCatalogRelatedFields(Clerkpagoservicio item)
        {

             this._Sucursal_infoClave = item.Sucursal_info?.Clave;

             this._Sucursal_infoNombre = item.Sucursal_info?.Nombre;


        }


        public void FillEntityValues(ref Clerkpagoservicio item)
        {


            item.CreadoPorId = CreadoPorId ;


            item.ModificadoPorId = ModificadoPorId ;


            item.EmpresaId = EmpresaId ?? 0;


            item.SucursalId = SucursalId ?? 0;


            item.Id = Id ?? 0;


            item.Activo = Activo ?? BoolCS.S;


            item.Creado = Creado ?? DateTime.UtcNow;


            item.Modificado = Modificado ?? DateTime.UtcNow;


            item.Clerkid = Clerkid ;


            item.Esservicio = Esservicio ;


            item.Sucursal_id = Sucursal_id ;



        }

        public void FillFromEntity(Clerkpagoservicio item)
        {

            CreadoPorId = item.CreadoPorId;

            ModificadoPorId = item.ModificadoPorId;

            EmpresaId = item.EmpresaId;

            SucursalId = item.SucursalId;

            Id = item.Id;

            Activo = item.Activo;

            Creado = item.Creado;

            Modificado = item.Modificado;

            Clerkid = item.Clerkid;

            Esservicio = item.Esservicio;

            Sucursal_id = item.Sucursal_id;


             FillCatalogRelatedFields(item);


        }

        #endif



    }
}

