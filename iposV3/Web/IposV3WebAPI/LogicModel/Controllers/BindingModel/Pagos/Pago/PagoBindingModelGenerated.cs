
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
    
    public class PagoBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public PagoBindingModelGenerated()
        {
        }
        
        #if PROYECTO_WEB
        public PagoBindingModelGenerated(Pago item)
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

        private string? _Referenciabancaria;
        [XmlAttribute]
        public string? Referenciabancaria { get => _Referenciabancaria; set { if (RaiseAcceptPendingChange(value, _Referenciabancaria)) { _Referenciabancaria = value; OnPropertyChanged(); } } }

        private string? _Notas;
        [XmlAttribute]
        public string? Notas { get => _Notas; set { if (RaiseAcceptPendingChange(value, _Notas)) { _Notas = value; OnPropertyChanged(); } } }

        private BoolCN? _Aplicado;
        [XmlAttribute]
        public BoolCN? Aplicado { get => _Aplicado; set { if (RaiseAcceptPendingChange(value, _Aplicado)) { _Aplicado = value; OnPropertyChanged(); } } }

        private string? _Cuentapagocredito;
        [XmlAttribute]
        public string? Cuentapagocredito { get => _Cuentapagocredito; set { if (RaiseAcceptPendingChange(value, _Cuentapagocredito)) { _Cuentapagocredito = value; OnPropertyChanged(); } } }

        private BoolCN? _Revertido;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Revertido { get => _Revertido?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Revertido)) { _Revertido = value?? BoolCN.N; OnPropertyChanged(); } } }

        private long? _Formapagoid;
        [XmlAttribute]
        public long? Formapagoid { get => _Formapagoid; set { if (RaiseAcceptPendingChange(value, _Formapagoid)) { _Formapagoid = value; OnPropertyChanged(); } } }

        private string? _FormapagoClave;
        [XmlAttribute]
        public string? FormapagoClave { get => _FormapagoClave; set { if (RaiseAcceptPendingChange(value, _FormapagoClave)) { _FormapagoClave = value; OnPropertyChanged(); } } }

        private string? _FormapagoNombre;
        [XmlAttribute]
        public string? FormapagoNombre { get => _FormapagoNombre; set { if (RaiseAcceptPendingChange(value, _FormapagoNombre)) { _FormapagoNombre = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechahora;
        [XmlAttribute]
        public DateTimeOffset? Fechahora { get => _Fechahora; set { if (RaiseAcceptPendingChange(value, _Fechahora)) { _Fechahora = value; OnPropertyChanged(); } } }

        private long? _Corteid;
        [XmlAttribute]
        public long? Corteid { get => _Corteid; set { if (RaiseAcceptPendingChange(value, _Corteid)) { _Corteid = value; OnPropertyChanged(); } } }

        private string? _CorteClave;
        [XmlAttribute]
        public string? CorteClave { get => _CorteClave; set { if (RaiseAcceptPendingChange(value, _CorteClave)) { _CorteClave = value; OnPropertyChanged(); } } }

        private string? _CorteNombre;
        [XmlAttribute]
        public string? CorteNombre { get => _CorteNombre; set { if (RaiseAcceptPendingChange(value, _CorteNombre)) { _CorteNombre = value; OnPropertyChanged(); } } }

        private decimal? _Importe;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Importe { get => _Importe?? 0; set { if (RaiseAcceptPendingChange(value, _Importe)) { _Importe = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Importerecibido;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Importerecibido { get => _Importerecibido?? 0; set { if (RaiseAcceptPendingChange(value, _Importerecibido)) { _Importerecibido = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Importecambio;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Importecambio { get => _Importecambio?? 0; set { if (RaiseAcceptPendingChange(value, _Importecambio)) { _Importecambio = value?? 0; OnPropertyChanged(); } } }

        private long? _Tipopagoid;
        [XmlAttribute]
        public long? Tipopagoid { get => _Tipopagoid; set { if (RaiseAcceptPendingChange(value, _Tipopagoid)) { _Tipopagoid = value; OnPropertyChanged(); } } }

        private string? _TipopagoClave;
        [XmlAttribute]
        public string? TipopagoClave { get => _TipopagoClave; set { if (RaiseAcceptPendingChange(value, _TipopagoClave)) { _TipopagoClave = value; OnPropertyChanged(); } } }

        private string? _TipopagoNombre;
        [XmlAttribute]
        public string? TipopagoNombre { get => _TipopagoNombre; set { if (RaiseAcceptPendingChange(value, _TipopagoNombre)) { _TipopagoNombre = value; OnPropertyChanged(); } } }

        private long? _Estatuspagoid;
        [XmlAttribute]
        public long? Estatuspagoid { get => _Estatuspagoid; set { if (RaiseAcceptPendingChange(value, _Estatuspagoid)) { _Estatuspagoid = value; OnPropertyChanged(); } } }

        private string? _EstatuspagoClave;
        [XmlAttribute]
        public string? EstatuspagoClave { get => _EstatuspagoClave; set { if (RaiseAcceptPendingChange(value, _EstatuspagoClave)) { _EstatuspagoClave = value; OnPropertyChanged(); } } }

        private string? _EstatuspagoNombre;
        [XmlAttribute]
        public string? EstatuspagoNombre { get => _EstatuspagoNombre; set { if (RaiseAcceptPendingChange(value, _EstatuspagoNombre)) { _EstatuspagoNombre = value; OnPropertyChanged(); } } }

        private long? _Bancoid;
        [XmlAttribute]
        public long? Bancoid { get => _Bancoid; set { if (RaiseAcceptPendingChange(value, _Bancoid)) { _Bancoid = value; OnPropertyChanged(); } } }

        private string? _BancoClave;
        [XmlAttribute]
        public string? BancoClave { get => _BancoClave; set { if (RaiseAcceptPendingChange(value, _BancoClave)) { _BancoClave = value; OnPropertyChanged(); } } }

        private string? _BancoNombre;
        [XmlAttribute]
        public string? BancoNombre { get => _BancoNombre; set { if (RaiseAcceptPendingChange(value, _BancoNombre)) { _BancoNombre = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechaelaboracion;
        [XmlAttribute]
        public DateTimeOffset? Fechaelaboracion { get => _Fechaelaboracion; set { if (RaiseAcceptPendingChange(value, _Fechaelaboracion)) { _Fechaelaboracion = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecharecepcion;
        [XmlAttribute]
        public DateTimeOffset? Fecharecepcion { get => _Fecharecepcion; set { if (RaiseAcceptPendingChange(value, _Fecharecepcion)) { _Fecharecepcion = value; OnPropertyChanged(); } } }

        private long? _Pagoparentid;
        [XmlAttribute]
        public long? Pagoparentid { get => _Pagoparentid; set { if (RaiseAcceptPendingChange(value, _Pagoparentid)) { _Pagoparentid = value; OnPropertyChanged(); } } }

        private string? _PagoparentClave;
        [XmlAttribute]
        public string? PagoparentClave { get => _PagoparentClave; set { if (RaiseAcceptPendingChange(value, _PagoparentClave)) { _PagoparentClave = value; OnPropertyChanged(); } } }

        private string? _PagoparentNombre;
        [XmlAttribute]
        public string? PagoparentNombre { get => _PagoparentNombre; set { if (RaiseAcceptPendingChange(value, _PagoparentNombre)) { _PagoparentNombre = value; OnPropertyChanged(); } } }

        private long? _Formapagosatid;
        [XmlAttribute]
        public long? Formapagosatid { get => _Formapagosatid; set { if (RaiseAcceptPendingChange(value, _Formapagosatid)) { _Formapagosatid = value; OnPropertyChanged(); } } }

        private string? _FormapagosatClave;
        [XmlAttribute]
        public string? FormapagosatClave { get => _FormapagosatClave; set { if (RaiseAcceptPendingChange(value, _FormapagosatClave)) { _FormapagosatClave = value; OnPropertyChanged(); } } }

        private string? _FormapagosatNombre;
        [XmlAttribute]
        public string? FormapagosatNombre { get => _FormapagosatNombre; set { if (RaiseAcceptPendingChange(value, _FormapagosatNombre)) { _FormapagosatNombre = value; OnPropertyChanged(); } } }

        private long? _Clienteid;
        [XmlAttribute]
        public long? Clienteid { get => _Clienteid; set { if (RaiseAcceptPendingChange(value, _Clienteid)) { _Clienteid = value; OnPropertyChanged(); } } }

        private string? _ClienteClave;
        [XmlAttribute]
        public string? ClienteClave { get => _ClienteClave; set { if (RaiseAcceptPendingChange(value, _ClienteClave)) { _ClienteClave = value; OnPropertyChanged(); } } }

        private string? _ClienteNombre;
        [XmlAttribute]
        public string? ClienteNombre { get => _ClienteNombre; set { if (RaiseAcceptPendingChange(value, _ClienteNombre)) { _ClienteNombre = value; OnPropertyChanged(); } } }

        private long? _Proveedorid;
        [XmlAttribute]
        public long? Proveedorid { get => _Proveedorid; set { if (RaiseAcceptPendingChange(value, _Proveedorid)) { _Proveedorid = value; OnPropertyChanged(); } } }

        private string? _ProveedorClave;
        [XmlAttribute]
        public string? ProveedorClave { get => _ProveedorClave; set { if (RaiseAcceptPendingChange(value, _ProveedorClave)) { _ProveedorClave = value; OnPropertyChanged(); } } }

        private string? _ProveedorNombre;
        [XmlAttribute]
        public string? ProveedorNombre { get => _ProveedorNombre; set { if (RaiseAcceptPendingChange(value, _ProveedorNombre)) { _ProveedorNombre = value; OnPropertyChanged(); } } }

        private int? _Sentidopago;
        [XmlAttribute]
        public int? Sentidopago { get => _Sentidopago; set { if (RaiseAcceptPendingChange(value, _Sentidopago)) { _Sentidopago = value; OnPropertyChanged(); } } }

        private int? _Folio;
        [XmlAttribute]
        public int? Folio { get => _Folio; set { if (RaiseAcceptPendingChange(value, _Folio)) { _Folio = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechaaplicado;
        [XmlAttribute]
        public DateTimeOffset? Fechaaplicado { get => _Fechaaplicado; set { if (RaiseAcceptPendingChange(value, _Fechaaplicado)) { _Fechaaplicado = value; OnPropertyChanged(); } } }

        private decimal? _Comision;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Comision { get => _Comision?? 0; set { if (RaiseAcceptPendingChange(value, _Comision)) { _Comision = value?? 0; OnPropertyChanged(); } } }

        private long? _Cuentabancoempresaid;
        [XmlAttribute]
        public long? Cuentabancoempresaid { get => _Cuentabancoempresaid; set { if (RaiseAcceptPendingChange(value, _Cuentabancoempresaid)) { _Cuentabancoempresaid = value; OnPropertyChanged(); } } }

        private string? _CuentabancoempresaClave;
        [XmlAttribute]
        public string? CuentabancoempresaClave { get => _CuentabancoempresaClave; set { if (RaiseAcceptPendingChange(value, _CuentabancoempresaClave)) { _CuentabancoempresaClave = value; OnPropertyChanged(); } } }

        private string? _CuentabancoempresaNombre;
        [XmlAttribute]
        public string? CuentabancoempresaNombre { get => _CuentabancoempresaNombre; set { if (RaiseAcceptPendingChange(value, _CuentabancoempresaNombre)) { _CuentabancoempresaNombre = value; OnPropertyChanged(); } } }

        private long? _Reciboelectronicoid;
        [XmlAttribute]
        public long? Reciboelectronicoid { get => _Reciboelectronicoid; set { if (RaiseAcceptPendingChange(value, _Reciboelectronicoid)) { _Reciboelectronicoid = value; OnPropertyChanged(); } } }

        private string? _ReciboelectronicoClave;
        [XmlAttribute]
        public string? ReciboelectronicoClave { get => _ReciboelectronicoClave; set { if (RaiseAcceptPendingChange(value, _ReciboelectronicoClave)) { _ReciboelectronicoClave = value; OnPropertyChanged(); } } }

        private string? _ReciboelectronicoNombre;
        [XmlAttribute]
        public string? ReciboelectronicoNombre { get => _ReciboelectronicoNombre; set { if (RaiseAcceptPendingChange(value, _ReciboelectronicoNombre)) { _ReciboelectronicoNombre = value; OnPropertyChanged(); } } }

        private long? _Pago_bancomer_Bancomerparamid;
        [XmlAttribute]
        public long? Pago_bancomer_Bancomerparamid { get => _Pago_bancomer_Bancomerparamid; set { if (RaiseAcceptPendingChange(value, _Pago_bancomer_Bancomerparamid)) { _Pago_bancomer_Bancomerparamid = value; OnPropertyChanged(); } } }

        private string? _Pago_bancomer_BancomerparamClave;
        [XmlAttribute]
        public string? Pago_bancomer_BancomerparamClave { get => _Pago_bancomer_BancomerparamClave; set { if (RaiseAcceptPendingChange(value, _Pago_bancomer_BancomerparamClave)) { _Pago_bancomer_BancomerparamClave = value; OnPropertyChanged(); } } }

        private string? _Pago_bancomer_BancomerparamNombre;
        [XmlAttribute]
        public string? Pago_bancomer_BancomerparamNombre { get => _Pago_bancomer_BancomerparamNombre; set { if (RaiseAcceptPendingChange(value, _Pago_bancomer_BancomerparamNombre)) { _Pago_bancomer_BancomerparamNombre = value; OnPropertyChanged(); } } }

        private string? _Refinterno;
        [XmlAttribute]
        public string? Refinterno { get => _Refinterno; set { if (RaiseAcceptPendingChange(value, _Refinterno)) { _Refinterno = value; OnPropertyChanged(); } } }

        private string? _Clave;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public string? Clave { get => _Clave?? ""; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value?? ""; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public string? Nombre { get => _Nombre?? ""; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value?? ""; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Pago"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Referenciabancaria|Notas|Cuentapagocredito|Formapago.Clave|Formapago.Nombre|Corte.Clave|Corte.Nombre|Tipopago.Clave|Tipopago.Nombre|Estatuspago.Clave|Estatuspago.Nombre|Banco.Clave|Banco.Nombre|Pagoparent.Clave|Pagoparent.Nombre|Formapagosat.Clave|Formapagosat.Nombre|Cliente.Clave|Cliente.Nombre|Proveedor.Clave|Proveedor.Nombre|Cuentabancoempresa.Clave|Cuentabancoempresa.Nombre|Reciboelectronico.Clave|Reciboelectronico.Nombre|Pago_bancomer.Bancomerparam.Clave|Pago_bancomer.Bancomerparam.Nombre|Refinterno|Clave|Nombre";
        }


        #if PROYECTO_WEB
        public void FillCatalogRelatedFields(Pago item)
        {

             this._FormapagoClave = item.Formapago?.Clave;

             this._FormapagoNombre = item.Formapago?.Nombre;

             this._CorteClave = item.Corte?.Clave;

             this._CorteNombre = item.Corte?.Nombre;

             this._TipopagoClave = item.Tipopago?.Clave;

             this._TipopagoNombre = item.Tipopago?.Nombre;

             this._EstatuspagoClave = item.Estatuspago?.Clave;

             this._EstatuspagoNombre = item.Estatuspago?.Nombre;

             this._BancoClave = item.Banco?.Clave;

             this._BancoNombre = item.Banco?.Nombre;

             this._PagoparentClave = item.Pagoparent?.Clave;

             this._PagoparentNombre = item.Pagoparent?.Nombre;

             this._FormapagosatClave = item.Formapagosat?.Clave;

             this._FormapagosatNombre = item.Formapagosat?.Nombre;

             this._ClienteClave = item.Cliente?.Clave;

             this._ClienteNombre = item.Cliente?.Nombre;

             this._ProveedorClave = item.Proveedor?.Clave;

             this._ProveedorNombre = item.Proveedor?.Nombre;

             this._CuentabancoempresaClave = item.Cuentabancoempresa?.Clave;

             this._CuentabancoempresaNombre = item.Cuentabancoempresa?.Nombre;

             this._ReciboelectronicoClave = item.Reciboelectronico?.Clave;

             this._ReciboelectronicoNombre = item.Reciboelectronico?.Nombre;

             this._Pago_bancomer_BancomerparamClave = item.Pago_bancomer?.Bancomerparam?.Clave;

             this._Pago_bancomer_BancomerparamNombre = item.Pago_bancomer?.Bancomerparam?.Nombre;


        }


        public void FillEntityValues(ref Pago item)
        {


            item.CreadoPorId = CreadoPorId ;


            item.ModificadoPorId = ModificadoPorId ;


            item.EmpresaId = EmpresaId ?? 0;


            item.SucursalId = SucursalId ?? 0;


            item.Id = Id ?? 0;


            item.Activo = Activo ?? BoolCS.S;


            item.Creado = Creado ?? DateTime.UtcNow;


            item.Modificado = Modificado ?? DateTime.UtcNow;


            item.Referenciabancaria = Referenciabancaria ;


            item.Notas = Notas ;


            item.Aplicado = Aplicado ;


            item.Cuentapagocredito = Cuentapagocredito ;


            item.Revertido = Revertido ?? BoolCN.N;


            item.Formapagoid = Formapagoid ;


            item.Fecha = Fecha ;


            item.Fechahora = Fechahora ;


            item.Corteid = Corteid ;


            item.Importe = Importe ?? 0;


            item.Importerecibido = Importerecibido ?? 0;


            item.Importecambio = Importecambio ?? 0;


            item.Tipopagoid = Tipopagoid ;


            item.Estatuspagoid = Estatuspagoid ;


            item.Bancoid = Bancoid ;


            item.Fechaelaboracion = Fechaelaboracion ;


            item.Fecharecepcion = Fecharecepcion ;


            item.Pagoparentid = Pagoparentid ;


            item.Formapagosatid = Formapagosatid ;


            item.Clienteid = Clienteid ;


            item.Proveedorid = Proveedorid ;


            item.Sentidopago = Sentidopago ;


            item.Folio = Folio ;


            item.Fechaaplicado = Fechaaplicado ;


            item.Comision = Comision ?? 0;


            item.Cuentabancoempresaid = Cuentabancoempresaid ;


            item.Reciboelectronicoid = Reciboelectronicoid ;


            item.Refinterno = Refinterno ;


            item.Clave = Clave ?? "";


            item.Nombre = Nombre ?? "";


            if (item.Pago_bancomer != null)
                item.Pago_bancomer!.Bancomerparamid = Pago_bancomer_Bancomerparamid;
            else if (item.Pago_bancomer == null && Pago_bancomer_Bancomerparamid != null)
            {
                item.Pago_bancomer = CreateSubEntity<Pago_bancomer>();
                item.Pago_bancomer!.Bancomerparamid = Pago_bancomer_Bancomerparamid;
            }


        }

        public void FillFromEntity(Pago item)
        {

            CreadoPorId = item.CreadoPorId;

            ModificadoPorId = item.ModificadoPorId;

            EmpresaId = item.EmpresaId;

            SucursalId = item.SucursalId;

            Id = item.Id;

            Activo = item.Activo;

            Creado = item.Creado;

            Modificado = item.Modificado;

            Referenciabancaria = item.Referenciabancaria;

            Notas = item.Notas;

            Aplicado = item.Aplicado;

            Cuentapagocredito = item.Cuentapagocredito;

            Revertido = item.Revertido;

            Formapagoid = item.Formapagoid;

            Fecha = item.Fecha;

            Fechahora = item.Fechahora;

            Corteid = item.Corteid;

            Importe = item.Importe;

            Importerecibido = item.Importerecibido;

            Importecambio = item.Importecambio;

            Tipopagoid = item.Tipopagoid;

            Estatuspagoid = item.Estatuspagoid;

            Bancoid = item.Bancoid;

            Fechaelaboracion = item.Fechaelaboracion;

            Fecharecepcion = item.Fecharecepcion;

            Pagoparentid = item.Pagoparentid;

            Formapagosatid = item.Formapagosatid;

            Clienteid = item.Clienteid;

            Proveedorid = item.Proveedorid;

            Sentidopago = item.Sentidopago;

            Folio = item.Folio;

            Fechaaplicado = item.Fechaaplicado;

            Comision = item.Comision;

            Cuentabancoempresaid = item.Cuentabancoempresaid;

            Reciboelectronicoid = item.Reciboelectronicoid;

            Refinterno = item.Refinterno;

            Clave = item.Clave;

            Nombre = item.Nombre;

            if (item.Pago_bancomer != null && item.Pago_bancomer?.Bancomerparamid != null)
                    Pago_bancomer_Bancomerparamid = item.Pago_bancomer!.Bancomerparamid;


             FillCatalogRelatedFields(item);


        }
        #endif



    }
}

