
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
    
    public class CajaBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public CajaBindingModelGenerated()
        {
        }
        
        #if PROYECTO_WEB
        public CajaBindingModelGenerated(Caja item)
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

        private string? _Descripcion;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public string? Descripcion { get => _Descripcion?? ""; set { if (RaiseAcceptPendingChange(value, _Descripcion)) { _Descripcion = value?? ""; OnPropertyChanged(); } } }

        private string? _Nombreimpresora;
        [XmlAttribute]
        public string? Nombreimpresora { get => _Nombreimpresora; set { if (RaiseAcceptPendingChange(value, _Nombreimpresora)) { _Nombreimpresora = value; OnPropertyChanged(); } } }

        private string? _Impresoracomanda;
        [XmlAttribute]
        public string? Impresoracomanda { get => _Impresoracomanda; set { if (RaiseAcceptPendingChange(value, _Impresoracomanda)) { _Impresoracomanda = value; OnPropertyChanged(); } } }

        private string? _Caja_bancomer_Nombrecertificadobancomer;
        [XmlAttribute]
        public string? Caja_bancomer_Nombrecertificadobancomer { get => _Caja_bancomer_Nombrecertificadobancomer; set { if (RaiseAcceptPendingChange(value, _Caja_bancomer_Nombrecertificadobancomer)) { _Caja_bancomer_Nombrecertificadobancomer = value; OnPropertyChanged(); } } }

        private string? _Caja_bancomer_Afiliacionbancomer;
        [XmlAttribute]
        public string? Caja_bancomer_Afiliacionbancomer { get => _Caja_bancomer_Afiliacionbancomer; set { if (RaiseAcceptPendingChange(value, _Caja_bancomer_Afiliacionbancomer)) { _Caja_bancomer_Afiliacionbancomer = value; OnPropertyChanged(); } } }

        private long? _Caja_bancomer_Numeroterminalbancomer;
        [XmlAttribute]
        public long? Caja_bancomer_Numeroterminalbancomer { get => _Caja_bancomer_Numeroterminalbancomer; set { if (RaiseAcceptPendingChange(value, _Caja_bancomer_Numeroterminalbancomer)) { _Caja_bancomer_Numeroterminalbancomer = value; OnPropertyChanged(); } } }

        private long? _Caja_emida_Terminalid;
        [XmlAttribute]
        public long? Caja_emida_Terminalid { get => _Caja_emida_Terminalid; set { if (RaiseAcceptPendingChange(value, _Caja_emida_Terminalid)) { _Caja_emida_Terminalid = value; OnPropertyChanged(); } } }

        private string? _Caja_emida_TerminalClave;
        [XmlAttribute]
        public string? Caja_emida_TerminalClave { get => _Caja_emida_TerminalClave; set { if (RaiseAcceptPendingChange(value, _Caja_emida_TerminalClave)) { _Caja_emida_TerminalClave = value; OnPropertyChanged(); } } }

        private string? _Caja_emida_TerminalNombre;
        [XmlAttribute]
        public string? Caja_emida_TerminalNombre { get => _Caja_emida_TerminalNombre; set { if (RaiseAcceptPendingChange(value, _Caja_emida_TerminalNombre)) { _Caja_emida_TerminalNombre = value; OnPropertyChanged(); } } }

        private long? _Caja_emida_Terminalserviciosid;
        [XmlAttribute]
        public long? Caja_emida_Terminalserviciosid { get => _Caja_emida_Terminalserviciosid; set { if (RaiseAcceptPendingChange(value, _Caja_emida_Terminalserviciosid)) { _Caja_emida_Terminalserviciosid = value; OnPropertyChanged(); } } }

        private string? _Caja_emida_TerminalserviciosClave;
        [XmlAttribute]
        public string? Caja_emida_TerminalserviciosClave { get => _Caja_emida_TerminalserviciosClave; set { if (RaiseAcceptPendingChange(value, _Caja_emida_TerminalserviciosClave)) { _Caja_emida_TerminalserviciosClave = value; OnPropertyChanged(); } } }

        private string? _Caja_emida_TerminalserviciosNombre;
        [XmlAttribute]
        public string? Caja_emida_TerminalserviciosNombre { get => _Caja_emida_TerminalserviciosNombre; set { if (RaiseAcceptPendingChange(value, _Caja_emida_TerminalserviciosNombre)) { _Caja_emida_TerminalserviciosNombre = value; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Caja"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Clave|Nombre|Descripcion|Nombreimpresora|Impresoracomanda|Caja_bancomer.Nombrecertificadobancomer|Caja_bancomer.Afiliacionbancomer|Caja_emida.Terminal.Clave|Caja_emida.Terminal.Nombre|Caja_emida.Terminalservicios.Clave|Caja_emida.Terminalservicios.Nombre";
        }


        #if PROYECTO_WEB
        public void FillCatalogRelatedFields(Caja item)
        {

             this._Caja_emida_TerminalClave = item.Caja_emida?.Terminal?.Clave;

             this._Caja_emida_TerminalNombre = item.Caja_emida?.Terminal?.Nombre;

             this._Caja_emida_TerminalserviciosClave = item.Caja_emida?.Terminalservicios?.Clave;

             this._Caja_emida_TerminalserviciosNombre = item.Caja_emida?.Terminalservicios?.Nombre;


        }


        public void FillEntityValues(ref Caja item)
        {


            item.CreadoPorId = CreadoPorId ;


            item.ModificadoPorId = ModificadoPorId ;


            item.EmpresaId = EmpresaId ?? 0;


            item.SucursalId = SucursalId ?? 0;


            item.Id = Id ?? 0;


            item.Activo = Activo ?? BoolCS.S;


            item.Creado = Creado ?? DateTime.UtcNow;


            item.Modificado = Modificado ?? DateTime.UtcNow;


            item.Clave = Clave ?? "";


            item.Nombre = Nombre ?? "";


            item.Descripcion = Descripcion ?? "";


            item.Nombreimpresora = Nombreimpresora ;


            item.Impresoracomanda = Impresoracomanda ;


            if (item.Caja_bancomer != null)
                item.Caja_bancomer!.Nombrecertificadobancomer = Caja_bancomer_Nombrecertificadobancomer;
            else if (item.Caja_bancomer == null && Caja_bancomer_Nombrecertificadobancomer != null)
            {
                item.Caja_bancomer = CreateSubEntity<Caja_bancomer>();
                item.Caja_bancomer!.Nombrecertificadobancomer = Caja_bancomer_Nombrecertificadobancomer;
            }

            if (item.Caja_bancomer != null)
                item.Caja_bancomer!.Afiliacionbancomer = Caja_bancomer_Afiliacionbancomer;
            else if (item.Caja_bancomer == null && Caja_bancomer_Afiliacionbancomer != null)
            {
                item.Caja_bancomer = CreateSubEntity<Caja_bancomer>();
                item.Caja_bancomer!.Afiliacionbancomer = Caja_bancomer_Afiliacionbancomer;
            }

            if (item.Caja_bancomer != null)
                item.Caja_bancomer!.Numeroterminalbancomer = Caja_bancomer_Numeroterminalbancomer;
            else if (item.Caja_bancomer == null && Caja_bancomer_Numeroterminalbancomer != null)
            {
                item.Caja_bancomer = CreateSubEntity<Caja_bancomer>();
                item.Caja_bancomer!.Numeroterminalbancomer = Caja_bancomer_Numeroterminalbancomer;
            }

            if (item.Caja_emida != null)
                item.Caja_emida!.Terminalid = Caja_emida_Terminalid;
            else if (item.Caja_emida == null && Caja_emida_Terminalid != null)
            {
                item.Caja_emida = CreateSubEntity<Caja_emida>();
                item.Caja_emida!.Terminalid = Caja_emida_Terminalid;
            }

            if (item.Caja_emida != null)
                item.Caja_emida!.Terminalserviciosid = Caja_emida_Terminalserviciosid;
            else if (item.Caja_emida == null && Caja_emida_Terminalserviciosid != null)
            {
                item.Caja_emida = CreateSubEntity<Caja_emida>();
                item.Caja_emida!.Terminalserviciosid = Caja_emida_Terminalserviciosid;
            }


        }

        public void FillFromEntity(Caja item)
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

            Descripcion = item.Descripcion;

            Nombreimpresora = item.Nombreimpresora;

            Impresoracomanda = item.Impresoracomanda;

            if (item.Caja_bancomer != null && item.Caja_bancomer?.Nombrecertificadobancomer != null)
                    Caja_bancomer_Nombrecertificadobancomer = item.Caja_bancomer!.Nombrecertificadobancomer;

            if (item.Caja_bancomer != null && item.Caja_bancomer?.Afiliacionbancomer != null)
                    Caja_bancomer_Afiliacionbancomer = item.Caja_bancomer!.Afiliacionbancomer;

            if (item.Caja_bancomer != null && item.Caja_bancomer?.Numeroterminalbancomer != null)
                    Caja_bancomer_Numeroterminalbancomer = item.Caja_bancomer!.Numeroterminalbancomer;

            if (item.Caja_emida != null && item.Caja_emida?.Terminalid != null)
                    Caja_emida_Terminalid = item.Caja_emida!.Terminalid;

            if (item.Caja_emida != null && item.Caja_emida?.Terminalserviciosid != null)
                    Caja_emida_Terminalserviciosid = item.Caja_emida!.Terminalserviciosid;


             FillCatalogRelatedFields(item);


        }
        #endif



    }
}

