
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
    
    public class FormapagoBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public FormapagoBindingModelGenerated()
        {
        }
        
        #if PROYECTO_WEB
        public FormapagoBindingModelGenerated(Formapago item)
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

        private BoolCN? _Esefectivo;
        [XmlAttribute]
        public BoolCN? Esefectivo { get => _Esefectivo?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Esefectivo)) { _Esefectivo = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCS? _Abona;
        [XmlAttribute]
        public BoolCS? Abona { get => _Abona?? BoolCS.S; set { if (RaiseAcceptPendingChange(value, _Abona)) { _Abona = value?? BoolCS.S; OnPropertyChanged(); } } }

        private BoolCS? _Afectasaldopersona;
        [XmlAttribute]
        public BoolCS? Afectasaldopersona { get => _Afectasaldopersona?? BoolCS.S; set { if (RaiseAcceptPendingChange(value, _Afectasaldopersona)) { _Afectasaldopersona = value?? BoolCS.S; OnPropertyChanged(); } } }

        private BoolCN? _Afectasaldoapartados;
        [XmlAttribute]
        public BoolCN? Afectasaldoapartados { get => _Afectasaldoapartados?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Afectasaldoapartados)) { _Afectasaldoapartados = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCS? _Afectasaldocorte;
        [XmlAttribute]
        public BoolCS? Afectasaldocorte { get => _Afectasaldocorte?? BoolCS.S; set { if (RaiseAcceptPendingChange(value, _Afectasaldocorte)) { _Afectasaldocorte = value?? BoolCS.S; OnPropertyChanged(); } } }

        private int? _Sentidoabonopago;
        [XmlAttribute]
        public int? Sentidoabonopago { get => _Sentidoabonopago; set { if (RaiseAcceptPendingChange(value, _Sentidoabonopago)) { _Sentidoabonopago = value; OnPropertyChanged(); } } }

        private int? _Sentidoabono;
        [XmlAttribute]
        public int? Sentidoabono { get => _Sentidoabono; set { if (RaiseAcceptPendingChange(value, _Sentidoabono)) { _Sentidoabono = value; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Formapago"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Clave|Nombre";
        }


        #if PROYECTO_WEB
        public void FillCatalogRelatedFields(Formapago item)
        {


        }


        public void FillEntityValues(ref Formapago item)
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


            item.Esefectivo = Esefectivo ?? BoolCN.N;


            item.Abona = Abona ?? BoolCS.S;


            item.Afectasaldopersona = Afectasaldopersona ?? BoolCS.S;


            item.Afectasaldoapartados = Afectasaldoapartados ?? BoolCN.N;


            item.Afectasaldocorte = Afectasaldocorte ?? BoolCS.S;


            item.Sentidoabonopago = Sentidoabonopago ;


            item.Sentidoabono = Sentidoabono ;



        }

        public void FillFromEntity(Formapago item)
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

            Esefectivo = item.Esefectivo;

            Abona = item.Abona;

            Afectasaldopersona = item.Afectasaldopersona;

            Afectasaldoapartados = item.Afectasaldoapartados;

            Afectasaldocorte = item.Afectasaldocorte;

            Sentidoabonopago = item.Sentidoabonopago;

            Sentidoabono = item.Sentidoabono;


             FillCatalogRelatedFields(item);


        }
        #endif



    }
}

