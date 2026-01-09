
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
    
    public class FormapagosatBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public FormapagosatBindingModelGenerated()
        {
        }

        #if PROYECTO_WEB
        public FormapagosatBindingModelGenerated(Formapagosat item)
        {
            FillFromEntity(item);
        }


        public T CreateSubEntity<T>() where T : EntityBase, new()
        {
            return new T() { EmpresaId = (long)(EmpresaId ?? 0), SucursalId = (long)(SucursalId ?? 0) };
        }

        #endif


        private long? _Id;
        [XmlAttribute]
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

        private string? _Clave;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public string? Clave { get => _Clave?? ""; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value?? ""; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public string? Nombre { get => _Nombre?? ""; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value?? ""; OnPropertyChanged(); } } }

        private long? _EmpresaId;
        [XmlAttribute]
        public long? EmpresaId { get => _EmpresaId?? 0; set { if (RaiseAcceptPendingChange(value, _EmpresaId)) { _EmpresaId = value?? 0; OnPropertyChanged(); } } }

        private long? _SucursalId;
        [XmlAttribute]
        public long? SucursalId { get => _SucursalId?? 0; set { if (RaiseAcceptPendingChange(value, _SucursalId)) { _SucursalId = value?? 0; OnPropertyChanged(); } } }

        private long? _CreadoPorId;
        [XmlAttribute]
        public long? CreadoPorId { get => _CreadoPorId; set { if (RaiseAcceptPendingChange(value, _CreadoPorId)) { _CreadoPorId = value; OnPropertyChanged(); } } }

        private long? _ModificadoPorId;
        [XmlAttribute]
        public long? ModificadoPorId { get => _ModificadoPorId; set { if (RaiseAcceptPendingChange(value, _ModificadoPorId)) { _ModificadoPorId = value; OnPropertyChanged(); } } }

        private string? _Sat_bancarizado;
        [XmlAttribute]
        public string? Sat_bancarizado { get => _Sat_bancarizado; set { if (RaiseAcceptPendingChange(value, _Sat_bancarizado)) { _Sat_bancarizado = value; OnPropertyChanged(); } } }

        private string? _Sat_numoperacion;
        [XmlAttribute]
        public string? Sat_numoperacion { get => _Sat_numoperacion; set { if (RaiseAcceptPendingChange(value, _Sat_numoperacion)) { _Sat_numoperacion = value; OnPropertyChanged(); } } }

        private string? _Sat_rfcemisorordenante;
        [XmlAttribute]
        public string? Sat_rfcemisorordenante { get => _Sat_rfcemisorordenante; set { if (RaiseAcceptPendingChange(value, _Sat_rfcemisorordenante)) { _Sat_rfcemisorordenante = value; OnPropertyChanged(); } } }

        private string? _Sat_cuentaordenante;
        [XmlAttribute]
        public string? Sat_cuentaordenante { get => _Sat_cuentaordenante; set { if (RaiseAcceptPendingChange(value, _Sat_cuentaordenante)) { _Sat_cuentaordenante = value; OnPropertyChanged(); } } }

        private string? _Sat_patronordenante;
        [XmlAttribute]
        public string? Sat_patronordenante { get => _Sat_patronordenante; set { if (RaiseAcceptPendingChange(value, _Sat_patronordenante)) { _Sat_patronordenante = value; OnPropertyChanged(); } } }

        private string? _Sat_rfcemisorbeneficiario;
        [XmlAttribute]
        public string? Sat_rfcemisorbeneficiario { get => _Sat_rfcemisorbeneficiario; set { if (RaiseAcceptPendingChange(value, _Sat_rfcemisorbeneficiario)) { _Sat_rfcemisorbeneficiario = value; OnPropertyChanged(); } } }

        private string? _Sat_cuentabeneficiario;
        [XmlAttribute]
        public string? Sat_cuentabeneficiario { get => _Sat_cuentabeneficiario; set { if (RaiseAcceptPendingChange(value, _Sat_cuentabeneficiario)) { _Sat_cuentabeneficiario = value; OnPropertyChanged(); } } }

        private string? _Sat_patronbeneficiario;
        [XmlAttribute]
        public string? Sat_patronbeneficiario { get => _Sat_patronbeneficiario; set { if (RaiseAcceptPendingChange(value, _Sat_patronbeneficiario)) { _Sat_patronbeneficiario = value; OnPropertyChanged(); } } }

        private string? _Sat_tipocadenapago;
        [XmlAttribute]
        public string? Sat_tipocadenapago { get => _Sat_tipocadenapago; set { if (RaiseAcceptPendingChange(value, _Sat_tipocadenapago)) { _Sat_tipocadenapago = value; OnPropertyChanged(); } } }

        private string? _Sat_bancoemisor;
        [XmlAttribute]
        public string? Sat_bancoemisor { get => _Sat_bancoemisor; set { if (RaiseAcceptPendingChange(value, _Sat_bancoemisor)) { _Sat_bancoemisor = value; OnPropertyChanged(); } } }

        private long? _Formapagoid;
        [XmlAttribute]
        public long? Formapagoid { get => _Formapagoid; set { if (RaiseAcceptPendingChange(value, _Formapagoid)) { _Formapagoid = value; OnPropertyChanged(); } } }

        private string? _FormapagoClave;
        [XmlAttribute]
        public string? FormapagoClave { get => _FormapagoClave; set { if (RaiseAcceptPendingChange(value, _FormapagoClave)) { _FormapagoClave = value; OnPropertyChanged(); } } }

        private string? _FormapagoNombre;
        [XmlAttribute]
        public string? FormapagoNombre { get => _FormapagoNombre; set { if (RaiseAcceptPendingChange(value, _FormapagoNombre)) { _FormapagoNombre = value; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Formapagosat"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Clave|Nombre|Sat_bancarizado|Sat_numoperacion|Sat_rfcemisorordenante|Sat_cuentaordenante|Sat_patronordenante|Sat_rfcemisorbeneficiario|Sat_cuentabeneficiario|Sat_patronbeneficiario|Sat_tipocadenapago|Sat_bancoemisor|Formapago.Clave|Formapago.Nombre";
        }



        #if PROYECTO_WEB
        public void FillCatalogRelatedFields(Formapagosat item)
        {

             this._FormapagoClave = item.Formapago?.Clave;

             this._FormapagoNombre = item.Formapago?.Nombre;


        }


        public void FillEntityValues(ref Formapagosat item)
        {


            item.Id = Id ?? 0;


            item.Activo = Activo ?? BoolCS.S;


            item.Creado = Creado ?? DateTime.UtcNow;


            item.Modificado = Modificado ?? DateTime.UtcNow;


            item.Clave = Clave ?? "";


            item.Nombre = Nombre ?? "";


            item.EmpresaId = EmpresaId ?? 0;


            item.SucursalId = SucursalId ?? 0;


            item.CreadoPorId = CreadoPorId ;


            item.ModificadoPorId = ModificadoPorId ;


            item.Sat_bancarizado = Sat_bancarizado ;


            item.Sat_numoperacion = Sat_numoperacion ;


            item.Sat_rfcemisorordenante = Sat_rfcemisorordenante ;


            item.Sat_cuentaordenante = Sat_cuentaordenante ;


            item.Sat_patronordenante = Sat_patronordenante ;


            item.Sat_rfcemisorbeneficiario = Sat_rfcemisorbeneficiario ;


            item.Sat_cuentabeneficiario = Sat_cuentabeneficiario ;


            item.Sat_patronbeneficiario = Sat_patronbeneficiario ;


            item.Sat_tipocadenapago = Sat_tipocadenapago ;


            item.Sat_bancoemisor = Sat_bancoemisor ;


            item.Formapagoid = Formapagoid ;



        }

        public void FillFromEntity(Formapagosat item)
        {

            Id = item.Id;

            Activo = item.Activo;

            Creado = item.Creado;

            Modificado = item.Modificado;

            Clave = item.Clave;

            Nombre = item.Nombre;

            EmpresaId = item.EmpresaId;

            SucursalId = item.SucursalId;

            CreadoPorId = item.CreadoPorId;

            ModificadoPorId = item.ModificadoPorId;

            Sat_bancarizado = item.Sat_bancarizado;

            Sat_numoperacion = item.Sat_numoperacion;

            Sat_rfcemisorordenante = item.Sat_rfcemisorordenante;

            Sat_cuentaordenante = item.Sat_cuentaordenante;

            Sat_patronordenante = item.Sat_patronordenante;

            Sat_rfcemisorbeneficiario = item.Sat_rfcemisorbeneficiario;

            Sat_cuentabeneficiario = item.Sat_cuentabeneficiario;

            Sat_patronbeneficiario = item.Sat_patronbeneficiario;

            Sat_tipocadenapago = item.Sat_tipocadenapago;

            Sat_bancoemisor = item.Sat_bancoemisor;

            Formapagoid = item.Formapagoid;


             FillCatalogRelatedFields(item);


        }
        #endif




    }
}

