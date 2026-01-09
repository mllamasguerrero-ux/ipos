
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
    
    public class LookupBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public LookupBindingModelGenerated()
        {
        }
        
        #if PROYECTO_WEB
        public LookupBindingModelGenerated(Lookup item)
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

        private string? _Clave;
        [XmlAttribute]
        public string? Clave { get => _Clave; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Campo1;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Campo1 { get => _Campo1?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Campo1)) { _Campo1 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Campo2;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Campo2 { get => _Campo2?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Campo2)) { _Campo2 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Campo3;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Campo3 { get => _Campo3?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Campo3)) { _Campo3 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Campo4;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Campo4 { get => _Campo4?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Campo4)) { _Campo4 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Campo5;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Campo5 { get => _Campo5?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Campo5)) { _Campo5 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Campo6;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Campo6 { get => _Campo6?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Campo6)) { _Campo6 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Campo7;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Campo7 { get => _Campo7?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Campo7)) { _Campo7 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Campo8;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Campo8 { get => _Campo8?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Campo8)) { _Campo8 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Campo9;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Campo9 { get => _Campo9?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Campo9)) { _Campo9 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Campo10;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Campo10 { get => _Campo10?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Campo10)) { _Campo10 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Campo11;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Campo11 { get => _Campo11?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Campo11)) { _Campo11 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Campo12;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Campo12 { get => _Campo12?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Campo12)) { _Campo12 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Campo13;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Campo13 { get => _Campo13?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Campo13)) { _Campo13 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Campo14;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Campo14 { get => _Campo14?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Campo14)) { _Campo14 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Campo15;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Campo15 { get => _Campo15?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Campo15)) { _Campo15 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Campo16;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Campo16 { get => _Campo16?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Campo16)) { _Campo16 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Campo17;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Campo17 { get => _Campo17?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Campo17)) { _Campo17 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Campo18;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Campo18 { get => _Campo18?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Campo18)) { _Campo18 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Campo19;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Campo19 { get => _Campo19?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Campo19)) { _Campo19 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Campo20;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Campo20 { get => _Campo20?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Campo20)) { _Campo20 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Campo21;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Campo21 { get => _Campo21?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Campo21)) { _Campo21 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Campo22;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Campo22 { get => _Campo22?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Campo22)) { _Campo22 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Campo23;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Campo23 { get => _Campo23?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Campo23)) { _Campo23 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Campo24;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Campo24 { get => _Campo24?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Campo24)) { _Campo24 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Campo25;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Campo25 { get => _Campo25?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Campo25)) { _Campo25 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Campo26;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Campo26 { get => _Campo26?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Campo26)) { _Campo26 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Campo27;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Campo27 { get => _Campo27?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Campo27)) { _Campo27 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Campo28;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Campo28 { get => _Campo28?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Campo28)) { _Campo28 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Campo29;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Campo29 { get => _Campo29?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Campo29)) { _Campo29 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Campo30;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Campo30 { get => _Campo30?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Campo30)) { _Campo30 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Campo31;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Campo31 { get => _Campo31?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Campo31)) { _Campo31 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Campo32;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Campo32 { get => _Campo32?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Campo32)) { _Campo32 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Campo33;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Campo33 { get => _Campo33?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Campo33)) { _Campo33 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Campo34;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Campo34 { get => _Campo34?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Campo34)) { _Campo34 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Campo35;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Campo35 { get => _Campo35?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Campo35)) { _Campo35 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Campo36;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Campo36 { get => _Campo36?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Campo36)) { _Campo36 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Campo37;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Campo37 { get => _Campo37?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Campo37)) { _Campo37 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Campo38;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Campo38 { get => _Campo38?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Campo38)) { _Campo38 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Campo39;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Campo39 { get => _Campo39?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Campo39)) { _Campo39 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Campo40;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Campo40 { get => _Campo40?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Campo40)) { _Campo40 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Lbl_campo1;
        [XmlAttribute]
        public string? Lbl_campo1 { get => _Lbl_campo1; set { if (RaiseAcceptPendingChange(value, _Lbl_campo1)) { _Lbl_campo1 = value; OnPropertyChanged(); } } }

        private string? _Lbl_campo2;
        [XmlAttribute]
        public string? Lbl_campo2 { get => _Lbl_campo2; set { if (RaiseAcceptPendingChange(value, _Lbl_campo2)) { _Lbl_campo2 = value; OnPropertyChanged(); } } }

        private string? _Lbl_campo3;
        [XmlAttribute]
        public string? Lbl_campo3 { get => _Lbl_campo3; set { if (RaiseAcceptPendingChange(value, _Lbl_campo3)) { _Lbl_campo3 = value; OnPropertyChanged(); } } }

        private string? _Lbl_campo4;
        [XmlAttribute]
        public string? Lbl_campo4 { get => _Lbl_campo4; set { if (RaiseAcceptPendingChange(value, _Lbl_campo4)) { _Lbl_campo4 = value; OnPropertyChanged(); } } }

        private string? _Lbl_campo5;
        [XmlAttribute]
        public string? Lbl_campo5 { get => _Lbl_campo5; set { if (RaiseAcceptPendingChange(value, _Lbl_campo5)) { _Lbl_campo5 = value; OnPropertyChanged(); } } }

        private string? _Lbl_campo6;
        [XmlAttribute]
        public string? Lbl_campo6 { get => _Lbl_campo6; set { if (RaiseAcceptPendingChange(value, _Lbl_campo6)) { _Lbl_campo6 = value; OnPropertyChanged(); } } }

        private string? _Lbl_campo7;
        [XmlAttribute]
        public string? Lbl_campo7 { get => _Lbl_campo7; set { if (RaiseAcceptPendingChange(value, _Lbl_campo7)) { _Lbl_campo7 = value; OnPropertyChanged(); } } }

        private string? _Lbl_campo8;
        [XmlAttribute]
        public string? Lbl_campo8 { get => _Lbl_campo8; set { if (RaiseAcceptPendingChange(value, _Lbl_campo8)) { _Lbl_campo8 = value; OnPropertyChanged(); } } }

        private string? _Lbl_campo9;
        [XmlAttribute]
        public string? Lbl_campo9 { get => _Lbl_campo9; set { if (RaiseAcceptPendingChange(value, _Lbl_campo9)) { _Lbl_campo9 = value; OnPropertyChanged(); } } }

        private string? _Lbl_campo10;
        [XmlAttribute]
        public string? Lbl_campo10 { get => _Lbl_campo10; set { if (RaiseAcceptPendingChange(value, _Lbl_campo10)) { _Lbl_campo10 = value; OnPropertyChanged(); } } }

        private string? _Lbl_campo11;
        [XmlAttribute]
        public string? Lbl_campo11 { get => _Lbl_campo11; set { if (RaiseAcceptPendingChange(value, _Lbl_campo11)) { _Lbl_campo11 = value; OnPropertyChanged(); } } }

        private string? _Lbl_campo12;
        [XmlAttribute]
        public string? Lbl_campo12 { get => _Lbl_campo12; set { if (RaiseAcceptPendingChange(value, _Lbl_campo12)) { _Lbl_campo12 = value; OnPropertyChanged(); } } }

        private string? _Lbl_campo13;
        [XmlAttribute]
        public string? Lbl_campo13 { get => _Lbl_campo13; set { if (RaiseAcceptPendingChange(value, _Lbl_campo13)) { _Lbl_campo13 = value; OnPropertyChanged(); } } }

        private string? _Lbl_campo14;
        [XmlAttribute]
        public string? Lbl_campo14 { get => _Lbl_campo14; set { if (RaiseAcceptPendingChange(value, _Lbl_campo14)) { _Lbl_campo14 = value; OnPropertyChanged(); } } }

        private string? _Lbl_campo15;
        [XmlAttribute]
        public string? Lbl_campo15 { get => _Lbl_campo15; set { if (RaiseAcceptPendingChange(value, _Lbl_campo15)) { _Lbl_campo15 = value; OnPropertyChanged(); } } }

        private string? _Lbl_campo16;
        [XmlAttribute]
        public string? Lbl_campo16 { get => _Lbl_campo16; set { if (RaiseAcceptPendingChange(value, _Lbl_campo16)) { _Lbl_campo16 = value; OnPropertyChanged(); } } }

        private string? _Lbl_campo17;
        [XmlAttribute]
        public string? Lbl_campo17 { get => _Lbl_campo17; set { if (RaiseAcceptPendingChange(value, _Lbl_campo17)) { _Lbl_campo17 = value; OnPropertyChanged(); } } }

        private string? _Lbl_campo18;
        [XmlAttribute]
        public string? Lbl_campo18 { get => _Lbl_campo18; set { if (RaiseAcceptPendingChange(value, _Lbl_campo18)) { _Lbl_campo18 = value; OnPropertyChanged(); } } }

        private string? _Lbl_campo19;
        [XmlAttribute]
        public string? Lbl_campo19 { get => _Lbl_campo19; set { if (RaiseAcceptPendingChange(value, _Lbl_campo19)) { _Lbl_campo19 = value; OnPropertyChanged(); } } }

        private string? _Lbl_campo20;
        [XmlAttribute]
        public string? Lbl_campo20 { get => _Lbl_campo20; set { if (RaiseAcceptPendingChange(value, _Lbl_campo20)) { _Lbl_campo20 = value; OnPropertyChanged(); } } }

        private string? _Lbl_campo21;
        [XmlAttribute]
        public string? Lbl_campo21 { get => _Lbl_campo21; set { if (RaiseAcceptPendingChange(value, _Lbl_campo21)) { _Lbl_campo21 = value; OnPropertyChanged(); } } }

        private string? _Lbl_campo22;
        [XmlAttribute]
        public string? Lbl_campo22 { get => _Lbl_campo22; set { if (RaiseAcceptPendingChange(value, _Lbl_campo22)) { _Lbl_campo22 = value; OnPropertyChanged(); } } }

        private string? _Lbl_campo23;
        [XmlAttribute]
        public string? Lbl_campo23 { get => _Lbl_campo23; set { if (RaiseAcceptPendingChange(value, _Lbl_campo23)) { _Lbl_campo23 = value; OnPropertyChanged(); } } }

        private string? _Lbl_campo24;
        [XmlAttribute]
        public string? Lbl_campo24 { get => _Lbl_campo24; set { if (RaiseAcceptPendingChange(value, _Lbl_campo24)) { _Lbl_campo24 = value; OnPropertyChanged(); } } }

        private string? _Lbl_campo25;
        [XmlAttribute]
        public string? Lbl_campo25 { get => _Lbl_campo25; set { if (RaiseAcceptPendingChange(value, _Lbl_campo25)) { _Lbl_campo25 = value; OnPropertyChanged(); } } }

        private string? _Lbl_campo26;
        [XmlAttribute]
        public string? Lbl_campo26 { get => _Lbl_campo26; set { if (RaiseAcceptPendingChange(value, _Lbl_campo26)) { _Lbl_campo26 = value; OnPropertyChanged(); } } }

        private string? _Lbl_campo27;
        [XmlAttribute]
        public string? Lbl_campo27 { get => _Lbl_campo27; set { if (RaiseAcceptPendingChange(value, _Lbl_campo27)) { _Lbl_campo27 = value; OnPropertyChanged(); } } }

        private string? _Lbl_campo28;
        [XmlAttribute]
        public string? Lbl_campo28 { get => _Lbl_campo28; set { if (RaiseAcceptPendingChange(value, _Lbl_campo28)) { _Lbl_campo28 = value; OnPropertyChanged(); } } }

        private string? _Lbl_campo29;
        [XmlAttribute]
        public string? Lbl_campo29 { get => _Lbl_campo29; set { if (RaiseAcceptPendingChange(value, _Lbl_campo29)) { _Lbl_campo29 = value; OnPropertyChanged(); } } }

        private string? _Lbl_campo30;
        [XmlAttribute]
        public string? Lbl_campo30 { get => _Lbl_campo30; set { if (RaiseAcceptPendingChange(value, _Lbl_campo30)) { _Lbl_campo30 = value; OnPropertyChanged(); } } }

        private string? _Lbl_campo31;
        [XmlAttribute]
        public string? Lbl_campo31 { get => _Lbl_campo31; set { if (RaiseAcceptPendingChange(value, _Lbl_campo31)) { _Lbl_campo31 = value; OnPropertyChanged(); } } }

        private string? _Lbl_campo32;
        [XmlAttribute]
        public string? Lbl_campo32 { get => _Lbl_campo32; set { if (RaiseAcceptPendingChange(value, _Lbl_campo32)) { _Lbl_campo32 = value; OnPropertyChanged(); } } }

        private string? _Lbl_campo33;
        [XmlAttribute]
        public string? Lbl_campo33 { get => _Lbl_campo33; set { if (RaiseAcceptPendingChange(value, _Lbl_campo33)) { _Lbl_campo33 = value; OnPropertyChanged(); } } }

        private string? _Lbl_campo34;
        [XmlAttribute]
        public string? Lbl_campo34 { get => _Lbl_campo34; set { if (RaiseAcceptPendingChange(value, _Lbl_campo34)) { _Lbl_campo34 = value; OnPropertyChanged(); } } }

        private string? _Lbl_campo35;
        [XmlAttribute]
        public string? Lbl_campo35 { get => _Lbl_campo35; set { if (RaiseAcceptPendingChange(value, _Lbl_campo35)) { _Lbl_campo35 = value; OnPropertyChanged(); } } }

        private string? _Lbl_campo36;
        [XmlAttribute]
        public string? Lbl_campo36 { get => _Lbl_campo36; set { if (RaiseAcceptPendingChange(value, _Lbl_campo36)) { _Lbl_campo36 = value; OnPropertyChanged(); } } }

        private string? _Lbl_campo37;
        [XmlAttribute]
        public string? Lbl_campo37 { get => _Lbl_campo37; set { if (RaiseAcceptPendingChange(value, _Lbl_campo37)) { _Lbl_campo37 = value; OnPropertyChanged(); } } }

        private string? _Lbl_campo38;
        [XmlAttribute]
        public string? Lbl_campo38 { get => _Lbl_campo38; set { if (RaiseAcceptPendingChange(value, _Lbl_campo38)) { _Lbl_campo38 = value; OnPropertyChanged(); } } }

        private string? _Lbl_campo39;
        [XmlAttribute]
        public string? Lbl_campo39 { get => _Lbl_campo39; set { if (RaiseAcceptPendingChange(value, _Lbl_campo39)) { _Lbl_campo39 = value; OnPropertyChanged(); } } }

        private string? _Lbl_campo40;
        [XmlAttribute]
        public string? Lbl_campo40 { get => _Lbl_campo40; set { if (RaiseAcceptPendingChange(value, _Lbl_campo40)) { _Lbl_campo40 = value; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Lookup"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Clave|Nombre|Lbl_campo1|Lbl_campo2|Lbl_campo3|Lbl_campo4|Lbl_campo5|Lbl_campo6|Lbl_campo7|Lbl_campo8|Lbl_campo9|Lbl_campo10|Lbl_campo11|Lbl_campo12|Lbl_campo13|Lbl_campo14|Lbl_campo15|Lbl_campo16|Lbl_campo17|Lbl_campo18|Lbl_campo19|Lbl_campo20|Lbl_campo21|Lbl_campo22|Lbl_campo23|Lbl_campo24|Lbl_campo25|Lbl_campo26|Lbl_campo27|Lbl_campo28|Lbl_campo29|Lbl_campo30|Lbl_campo31|Lbl_campo32|Lbl_campo33|Lbl_campo34|Lbl_campo35|Lbl_campo36|Lbl_campo37|Lbl_campo38|Lbl_campo39|Lbl_campo40";
        }

        #if PROYECTO_WEB
        public virtual void FillCatalogRelatedFields(Lookup item)
        {


        }


        public virtual void FillEntityValues(ref Lookup item)
        {


            item.CreadoPorId = CreadoPorId ;


            item.ModificadoPorId = ModificadoPorId ;


            item.EmpresaId = EmpresaId ?? 0;


            item.SucursalId = SucursalId ?? 0;


            item.Id = Id ?? 0;


            item.Activo = Activo ?? BoolCS.S;


            item.Creado = Creado ?? DateTime.UtcNow;


            item.Modificado = Modificado ?? DateTime.UtcNow;


            item.Clave = Clave ;


            item.Nombre = Nombre ;


            item.Campo1 = Campo1 ?? BoolCN.N;


            item.Campo2 = Campo2 ?? BoolCN.N;


            item.Campo3 = Campo3 ?? BoolCN.N;


            item.Campo4 = Campo4 ?? BoolCN.N;


            item.Campo5 = Campo5 ?? BoolCN.N;


            item.Campo6 = Campo6 ?? BoolCN.N;


            item.Campo7 = Campo7 ?? BoolCN.N;


            item.Campo8 = Campo8 ?? BoolCN.N;


            item.Campo9 = Campo9 ?? BoolCN.N;


            item.Campo10 = Campo10 ?? BoolCN.N;


            item.Campo11 = Campo11 ?? BoolCN.N;


            item.Campo12 = Campo12 ?? BoolCN.N;


            item.Campo13 = Campo13 ?? BoolCN.N;


            item.Campo14 = Campo14 ?? BoolCN.N;


            item.Campo15 = Campo15 ?? BoolCN.N;


            item.Campo16 = Campo16 ?? BoolCN.N;


            item.Campo17 = Campo17 ?? BoolCN.N;


            item.Campo18 = Campo18 ?? BoolCN.N;


            item.Campo19 = Campo19 ?? BoolCN.N;


            item.Campo20 = Campo20 ?? BoolCN.N;


            item.Campo21 = Campo21 ?? BoolCN.N;


            item.Campo22 = Campo22 ?? BoolCN.N;


            item.Campo23 = Campo23 ?? BoolCN.N;


            item.Campo24 = Campo24 ?? BoolCN.N;


            item.Campo25 = Campo25 ?? BoolCN.N;


            item.Campo26 = Campo26 ?? BoolCN.N;


            item.Campo27 = Campo27 ?? BoolCN.N;


            item.Campo28 = Campo28 ?? BoolCN.N;


            item.Campo29 = Campo29 ?? BoolCN.N;


            item.Campo30 = Campo30 ?? BoolCN.N;


            item.Campo31 = Campo31 ?? BoolCN.N;


            item.Campo32 = Campo32 ?? BoolCN.N;


            item.Campo33 = Campo33 ?? BoolCN.N;


            item.Campo34 = Campo34 ?? BoolCN.N;


            item.Campo35 = Campo35 ?? BoolCN.N;


            item.Campo36 = Campo36 ?? BoolCN.N;


            item.Campo37 = Campo37 ?? BoolCN.N;


            item.Campo38 = Campo38 ?? BoolCN.N;


            item.Campo39 = Campo39 ?? BoolCN.N;


            item.Campo40 = Campo40 ?? BoolCN.N;


            item.Lbl_campo1 = Lbl_campo1 ;


            item.Lbl_campo2 = Lbl_campo2 ;


            item.Lbl_campo3 = Lbl_campo3 ;


            item.Lbl_campo4 = Lbl_campo4 ;


            item.Lbl_campo5 = Lbl_campo5 ;


            item.Lbl_campo6 = Lbl_campo6 ;


            item.Lbl_campo7 = Lbl_campo7 ;


            item.Lbl_campo8 = Lbl_campo8 ;


            item.Lbl_campo9 = Lbl_campo9 ;


            item.Lbl_campo10 = Lbl_campo10 ;


            item.Lbl_campo11 = Lbl_campo11 ;


            item.Lbl_campo12 = Lbl_campo12 ;


            item.Lbl_campo13 = Lbl_campo13 ;


            item.Lbl_campo14 = Lbl_campo14 ;


            item.Lbl_campo15 = Lbl_campo15 ;


            item.Lbl_campo16 = Lbl_campo16 ;


            item.Lbl_campo17 = Lbl_campo17 ;


            item.Lbl_campo18 = Lbl_campo18 ;


            item.Lbl_campo19 = Lbl_campo19 ;


            item.Lbl_campo20 = Lbl_campo20 ;


            item.Lbl_campo21 = Lbl_campo21 ;


            item.Lbl_campo22 = Lbl_campo22 ;


            item.Lbl_campo23 = Lbl_campo23 ;


            item.Lbl_campo24 = Lbl_campo24 ;


            item.Lbl_campo25 = Lbl_campo25 ;


            item.Lbl_campo26 = Lbl_campo26 ;


            item.Lbl_campo27 = Lbl_campo27 ;


            item.Lbl_campo28 = Lbl_campo28 ;


            item.Lbl_campo29 = Lbl_campo29 ;


            item.Lbl_campo30 = Lbl_campo30 ;


            item.Lbl_campo31 = Lbl_campo31 ;


            item.Lbl_campo32 = Lbl_campo32 ;


            item.Lbl_campo33 = Lbl_campo33 ;


            item.Lbl_campo34 = Lbl_campo34 ;


            item.Lbl_campo35 = Lbl_campo35 ;


            item.Lbl_campo36 = Lbl_campo36 ;


            item.Lbl_campo37 = Lbl_campo37 ;


            item.Lbl_campo38 = Lbl_campo38 ;


            item.Lbl_campo39 = Lbl_campo39 ;


            item.Lbl_campo40 = Lbl_campo40 ;



        }

        public virtual void FillFromEntity(Lookup item)
        {

            CreadoPorId = item.CreadoPorId;

            ModificadoPorId = item.ModificadoPorId;

            EmpresaId = item.EmpresaId;

            SucursalId = item.SucursalId;

            Id = item.Id;

            Activo = item.Activo;

            Creado = item.Creado;

            Modificado = item.Modificado;

            Clave = item.Clave;

            Nombre = item.Nombre;

            Campo1 = item.Campo1;

            Campo2 = item.Campo2;

            Campo3 = item.Campo3;

            Campo4 = item.Campo4;

            Campo5 = item.Campo5;

            Campo6 = item.Campo6;

            Campo7 = item.Campo7;

            Campo8 = item.Campo8;

            Campo9 = item.Campo9;

            Campo10 = item.Campo10;

            Campo11 = item.Campo11;

            Campo12 = item.Campo12;

            Campo13 = item.Campo13;

            Campo14 = item.Campo14;

            Campo15 = item.Campo15;

            Campo16 = item.Campo16;

            Campo17 = item.Campo17;

            Campo18 = item.Campo18;

            Campo19 = item.Campo19;

            Campo20 = item.Campo20;

            Campo21 = item.Campo21;

            Campo22 = item.Campo22;

            Campo23 = item.Campo23;

            Campo24 = item.Campo24;

            Campo25 = item.Campo25;

            Campo26 = item.Campo26;

            Campo27 = item.Campo27;

            Campo28 = item.Campo28;

            Campo29 = item.Campo29;

            Campo30 = item.Campo30;

            Campo31 = item.Campo31;

            Campo32 = item.Campo32;

            Campo33 = item.Campo33;

            Campo34 = item.Campo34;

            Campo35 = item.Campo35;

            Campo36 = item.Campo36;

            Campo37 = item.Campo37;

            Campo38 = item.Campo38;

            Campo39 = item.Campo39;

            Campo40 = item.Campo40;

            Lbl_campo1 = item.Lbl_campo1;

            Lbl_campo2 = item.Lbl_campo2;

            Lbl_campo3 = item.Lbl_campo3;

            Lbl_campo4 = item.Lbl_campo4;

            Lbl_campo5 = item.Lbl_campo5;

            Lbl_campo6 = item.Lbl_campo6;

            Lbl_campo7 = item.Lbl_campo7;

            Lbl_campo8 = item.Lbl_campo8;

            Lbl_campo9 = item.Lbl_campo9;

            Lbl_campo10 = item.Lbl_campo10;

            Lbl_campo11 = item.Lbl_campo11;

            Lbl_campo12 = item.Lbl_campo12;

            Lbl_campo13 = item.Lbl_campo13;

            Lbl_campo14 = item.Lbl_campo14;

            Lbl_campo15 = item.Lbl_campo15;

            Lbl_campo16 = item.Lbl_campo16;

            Lbl_campo17 = item.Lbl_campo17;

            Lbl_campo18 = item.Lbl_campo18;

            Lbl_campo19 = item.Lbl_campo19;

            Lbl_campo20 = item.Lbl_campo20;

            Lbl_campo21 = item.Lbl_campo21;

            Lbl_campo22 = item.Lbl_campo22;

            Lbl_campo23 = item.Lbl_campo23;

            Lbl_campo24 = item.Lbl_campo24;

            Lbl_campo25 = item.Lbl_campo25;

            Lbl_campo26 = item.Lbl_campo26;

            Lbl_campo27 = item.Lbl_campo27;

            Lbl_campo28 = item.Lbl_campo28;

            Lbl_campo29 = item.Lbl_campo29;

            Lbl_campo30 = item.Lbl_campo30;

            Lbl_campo31 = item.Lbl_campo31;

            Lbl_campo32 = item.Lbl_campo32;

            Lbl_campo33 = item.Lbl_campo33;

            Lbl_campo34 = item.Lbl_campo34;

            Lbl_campo35 = item.Lbl_campo35;

            Lbl_campo36 = item.Lbl_campo36;

            Lbl_campo37 = item.Lbl_campo37;

            Lbl_campo38 = item.Lbl_campo38;

            Lbl_campo39 = item.Lbl_campo39;

            Lbl_campo40 = item.Lbl_campo40;


             FillCatalogRelatedFields(item);


        }
        #endif




    }
}

