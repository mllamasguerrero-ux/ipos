
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
    
    public class VehiculoBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public VehiculoBindingModelGenerated()
        {
        }
        public VehiculoBindingModelGenerated(Vehiculo item)
        {
            FillFromEntity(item);
        }


        public T CreateSubEntity<T>() where T : EntityBase, new()
        {
            return new T() { EmpresaId = (long)(EmpresaId ?? 0), SucursalId = (long)(SucursalId ?? 0) };
        }


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

        private long? _Sat_Tipopermisoid;
        [XmlAttribute]
        public long? Sat_Tipopermisoid { get => _Sat_Tipopermisoid; set { if (RaiseAcceptPendingChange(value, _Sat_Tipopermisoid)) { _Sat_Tipopermisoid = value; OnPropertyChanged(); } } }

        private string? _Sat_TipopermisoClave;
        [XmlAttribute]
        public string? Sat_TipopermisoClave { get => _Sat_TipopermisoClave; set { if (RaiseAcceptPendingChange(value, _Sat_TipopermisoClave)) { _Sat_TipopermisoClave = value; OnPropertyChanged(); } } }

        private string? _Sat_TipopermisoNombre;
        [XmlAttribute]
        public string? Sat_TipopermisoNombre { get => _Sat_TipopermisoNombre; set { if (RaiseAcceptPendingChange(value, _Sat_TipopermisoNombre)) { _Sat_TipopermisoNombre = value; OnPropertyChanged(); } } }

        private string? _Numpermisosct;
        [XmlAttribute]
        public string? Numpermisosct { get => _Numpermisosct; set { if (RaiseAcceptPendingChange(value, _Numpermisosct)) { _Numpermisosct = value; OnPropertyChanged(); } } }

        private long? _Sat_Configautotransporteid;
        [XmlAttribute]
        public long? Sat_Configautotransporteid { get => _Sat_Configautotransporteid; set { if (RaiseAcceptPendingChange(value, _Sat_Configautotransporteid)) { _Sat_Configautotransporteid = value; OnPropertyChanged(); } } }

        private string? _Sat_ConfigautotransporteClave;
        [XmlAttribute]
        public string? Sat_ConfigautotransporteClave { get => _Sat_ConfigautotransporteClave; set { if (RaiseAcceptPendingChange(value, _Sat_ConfigautotransporteClave)) { _Sat_ConfigautotransporteClave = value; OnPropertyChanged(); } } }

        private string? _Sat_ConfigautotransporteNombre;
        [XmlAttribute]
        public string? Sat_ConfigautotransporteNombre { get => _Sat_ConfigautotransporteNombre; set { if (RaiseAcceptPendingChange(value, _Sat_ConfigautotransporteNombre)) { _Sat_ConfigautotransporteNombre = value; OnPropertyChanged(); } } }

        private string? _Placavm;
        [XmlAttribute]
        public string? Placavm { get => _Placavm; set { if (RaiseAcceptPendingChange(value, _Placavm)) { _Placavm = value; OnPropertyChanged(); } } }

        private string? _Aniomodelovm;
        [XmlAttribute]
        public string? Aniomodelovm { get => _Aniomodelovm; set { if (RaiseAcceptPendingChange(value, _Aniomodelovm)) { _Aniomodelovm = value; OnPropertyChanged(); } } }

        private string? _Asegurarespcivil;
        [XmlAttribute]
        public string? Asegurarespcivil { get => _Asegurarespcivil; set { if (RaiseAcceptPendingChange(value, _Asegurarespcivil)) { _Asegurarespcivil = value; OnPropertyChanged(); } } }

        private string? _Polizarespcivil;
        [XmlAttribute]
        public string? Polizarespcivil { get => _Polizarespcivil; set { if (RaiseAcceptPendingChange(value, _Polizarespcivil)) { _Polizarespcivil = value; OnPropertyChanged(); } } }

        private string? _Aseguramedambiente;
        [XmlAttribute]
        public string? Aseguramedambiente { get => _Aseguramedambiente; set { if (RaiseAcceptPendingChange(value, _Aseguramedambiente)) { _Aseguramedambiente = value; OnPropertyChanged(); } } }

        private string? _Polizamedambiente;
        [XmlAttribute]
        public string? Polizamedambiente { get => _Polizamedambiente; set { if (RaiseAcceptPendingChange(value, _Polizamedambiente)) { _Polizamedambiente = value; OnPropertyChanged(); } } }

        private string? _Aseguracarga;
        [XmlAttribute]
        public string? Aseguracarga { get => _Aseguracarga; set { if (RaiseAcceptPendingChange(value, _Aseguracarga)) { _Aseguracarga = value; OnPropertyChanged(); } } }

        private string? _Polizacarga;
        [XmlAttribute]
        public string? Polizacarga { get => _Polizacarga; set { if (RaiseAcceptPendingChange(value, _Polizacarga)) { _Polizacarga = value; OnPropertyChanged(); } } }

        private string? _Primaseguro;
        [XmlAttribute]
        public string? Primaseguro { get => _Primaseguro; set { if (RaiseAcceptPendingChange(value, _Primaseguro)) { _Primaseguro = value; OnPropertyChanged(); } } }

        private long? _Sat_Subtiporem1id;
        [XmlAttribute]
        public long? Sat_Subtiporem1id { get => _Sat_Subtiporem1id; set { if (RaiseAcceptPendingChange(value, _Sat_Subtiporem1id)) { _Sat_Subtiporem1id = value; OnPropertyChanged(); } } }

        private string? _Sat_Subtiporem1Clave;
        [XmlAttribute]
        public string? Sat_Subtiporem1Clave { get => _Sat_Subtiporem1Clave; set { if (RaiseAcceptPendingChange(value, _Sat_Subtiporem1Clave)) { _Sat_Subtiporem1Clave = value; OnPropertyChanged(); } } }

        private string? _Sat_Subtiporem1Nombre;
        [XmlAttribute]
        public string? Sat_Subtiporem1Nombre { get => _Sat_Subtiporem1Nombre; set { if (RaiseAcceptPendingChange(value, _Sat_Subtiporem1Nombre)) { _Sat_Subtiporem1Nombre = value; OnPropertyChanged(); } } }

        private string? _Placa1;
        [XmlAttribute]
        public string? Placa1 { get => _Placa1; set { if (RaiseAcceptPendingChange(value, _Placa1)) { _Placa1 = value; OnPropertyChanged(); } } }

        private long? _Sat_Subtiporem2id;
        [XmlAttribute]
        public long? Sat_Subtiporem2id { get => _Sat_Subtiporem2id; set { if (RaiseAcceptPendingChange(value, _Sat_Subtiporem2id)) { _Sat_Subtiporem2id = value; OnPropertyChanged(); } } }


        private string? _Sat_Subtiporem2Clave;
        [XmlAttribute]
        public string? Sat_Subtiporem2Clave { get => _Sat_Subtiporem2Clave; set { if (RaiseAcceptPendingChange(value, _Sat_Subtiporem2Clave)) { _Sat_Subtiporem2Clave = value; OnPropertyChanged(); } } }

        private string? _Sat_Subtiporem2Nombre;
        [XmlAttribute]
        public string? Sat_Subtiporem2Nombre { get => _Sat_Subtiporem2Nombre; set { if (RaiseAcceptPendingChange(value, _Sat_Subtiporem2Nombre)) { _Sat_Subtiporem2Nombre = value; OnPropertyChanged(); } } }




        private string? _Placa2;
        [XmlAttribute]
        public string? Placa2 { get => _Placa2; set { if (RaiseAcceptPendingChange(value, _Placa2)) { _Placa2 = value; OnPropertyChanged(); } } }

        private long? _Duenioid;
        [XmlAttribute]
        public long? Duenioid { get => _Duenioid; set { if (RaiseAcceptPendingChange(value, _Duenioid)) { _Duenioid = value; OnPropertyChanged(); } } }

        private string? _DuenioClave;
        [XmlAttribute]
        public string? DuenioClave { get => _DuenioClave; set { if (RaiseAcceptPendingChange(value, _DuenioClave)) { _DuenioClave = value; OnPropertyChanged(); } } }

        private string? _DuenioNombre;
        [XmlAttribute]
        public string? DuenioNombre { get => _DuenioNombre; set { if (RaiseAcceptPendingChange(value, _DuenioNombre)) { _DuenioNombre = value; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Vehiculo"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Sat_Tipopermiso.Clave|Sat_Tipopermiso.Nombre|Numpermisosct|Sat_Configautotransporte.Clave|Sat_Configautotransporte.Nombre|Placavm|Aniomodelovm|Asegurarespcivil|Polizarespcivil|Aseguramedambiente|Polizamedambiente|Aseguracarga|Polizacarga|Primaseguro|Sat_Subtiporem1.Clave|Sat_Subtiporem1.Nombre|Placa1|Placa2|Duenio.Clave|Duenio.Nombre";
        }


        public void FillCatalogRelatedFields(Vehiculo item)
        {

             this._Sat_TipopermisoClave = item.Sat_Tipopermiso?.Clave;

             this._Sat_TipopermisoNombre = item.Sat_Tipopermiso?.Nombre;

             this._Sat_ConfigautotransporteClave = item.Sat_Configautotransporte?.Clave;

             this._Sat_ConfigautotransporteNombre = item.Sat_Configautotransporte?.Nombre;

             this._Sat_Subtiporem1Clave = item.Sat_Subtiporem1?.Clave;

             this._Sat_Subtiporem1Nombre = item.Sat_Subtiporem1?.Nombre;

            this._Sat_Subtiporem2Clave = item.Sat_Subtiporem2?.Clave;

            this._Sat_Subtiporem2Nombre = item.Sat_Subtiporem2?.Nombre;

            this._DuenioClave = item.Duenio?.Clave;

             this._DuenioNombre = item.Duenio?.Nombre;


        }


        public void FillEntityValues(ref Vehiculo item)
        {


            item.CreadoPorId = CreadoPorId ;


            item.ModificadoPorId = ModificadoPorId ;


            item.EmpresaId = EmpresaId ?? 0;


            item.SucursalId = SucursalId ?? 0;


            item.Id = Id ?? 0;


            item.Activo = Activo ?? BoolCS.S;


            item.Creado = Creado ?? DateTime.UtcNow;


            item.Modificado = Modificado ?? DateTime.UtcNow;


            item.Sat_Tipopermisoid = Sat_Tipopermisoid ;


            item.Numpermisosct = Numpermisosct ;


            item.Sat_Configautotransporteid = Sat_Configautotransporteid ;


            item.Placavm = Placavm ;


            item.Aniomodelovm = Aniomodelovm ;


            item.Asegurarespcivil = Asegurarespcivil ;


            item.Polizarespcivil = Polizarespcivil ;


            item.Aseguramedambiente = Aseguramedambiente ;


            item.Polizamedambiente = Polizamedambiente ;


            item.Aseguracarga = Aseguracarga ;


            item.Polizacarga = Polizacarga ;


            item.Primaseguro = Primaseguro ;


            item.Sat_Subtiporem1id = Sat_Subtiporem1id ;


            item.Placa1 = Placa1 ;


            item.Sat_Subtiporem2id = Sat_Subtiporem2id ;


            item.Placa2 = Placa2 ;


            item.Duenioid = Duenioid ;



        }

        public void FillFromEntity(Vehiculo item)
        {

            CreadoPorId = item.CreadoPorId;

            ModificadoPorId = item.ModificadoPorId;

            EmpresaId = item.EmpresaId;

            SucursalId = item.SucursalId;

            Id = item.Id;

            Activo = item.Activo;

            Creado = item.Creado;

            Modificado = item.Modificado;

            Sat_Tipopermisoid = item.Sat_Tipopermisoid;

            Numpermisosct = item.Numpermisosct;

            Sat_Configautotransporteid = item.Sat_Configautotransporteid;

            Placavm = item.Placavm;

            Aniomodelovm = item.Aniomodelovm;

            Asegurarespcivil = item.Asegurarespcivil;

            Polizarespcivil = item.Polizarespcivil;

            Aseguramedambiente = item.Aseguramedambiente;

            Polizamedambiente = item.Polizamedambiente;

            Aseguracarga = item.Aseguracarga;

            Polizacarga = item.Polizacarga;

            Primaseguro = item.Primaseguro;

            Sat_Subtiporem1id = item.Sat_Subtiporem1id;

            Placa1 = item.Placa1;

            Sat_Subtiporem2id = item.Sat_Subtiporem2id;

            Placa2 = item.Placa2;

            Duenioid = item.Duenioid;


             FillCatalogRelatedFields(item);


        }



    }
}

