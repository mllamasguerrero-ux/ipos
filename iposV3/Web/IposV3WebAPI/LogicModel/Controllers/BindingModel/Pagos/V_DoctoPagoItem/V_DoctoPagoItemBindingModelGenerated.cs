
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using IposV3.Model;
using MvvmFramework;
using System.Xml.Serialization;
using IposV3.Services;

namespace BindingModels
{
    [XmlRoot]
    
    public class V_DoctoPagoItemBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public V_DoctoPagoItemBindingModelGenerated()
        {
        }
        
        #if PROYECTO_WEB
        public V_DoctoPagoItemBindingModelGenerated(TmpDoctoPagoItem item)
        {
            FillFromEntity(item);
        }


        public T CreateSubEntity<T>() where T : EntityBase, new()
        {
            return new T() { EmpresaId = (long)(EmpresaId ?? 0), SucursalId = (long)(SucursalId ?? 0) };
        }

        #endif
        

        private long? _EmpresaId;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? EmpresaId { get => _EmpresaId?? 0; set { if (RaiseAcceptPendingChange(value, _EmpresaId)) { _EmpresaId = value?? 0; OnPropertyChanged(); } } }

        private long? _SucursalId;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? SucursalId { get => _SucursalId?? 0; set { if (RaiseAcceptPendingChange(value, _SucursalId)) { _SucursalId = value?? 0; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? Id { get => _Id?? 0; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value?? 0; OnPropertyChanged(); } } }

        private long? _Pagoid;
        [XmlAttribute]
        public long? Pagoid { get => _Pagoid; set { if (RaiseAcceptPendingChange(value, _Pagoid)) { _Pagoid = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechahora;
        [XmlAttribute]
        public DateTimeOffset? Fechahora { get => _Fechahora; set { if (RaiseAcceptPendingChange(value, _Fechahora)) { _Fechahora = value; OnPropertyChanged(); } } }



        private string? _Formapago;
        [XmlAttribute]
        public string? Formapago { get => _Formapago; set { if (RaiseAcceptPendingChange(value, _Formapago)) { _Formapago = value; OnPropertyChanged(); } } }

        private decimal? _Monto;
        [XmlAttribute]
        public decimal? Monto { get => _Monto; set { if (RaiseAcceptPendingChange(value, _Monto)) { _Monto = value; OnPropertyChanged(); } } }

        private string? _Formapagoclave;
        [XmlAttribute]
        public string? Formapagoclave { get => _Formapagoclave; set { if (RaiseAcceptPendingChange(value, _Formapagoclave)) { _Formapagoclave = value; OnPropertyChanged(); } } }

        private string? _Formapagonombre;
        [XmlAttribute]
        public string? Formapagonombre { get => _Formapagonombre; set { if (RaiseAcceptPendingChange(value, _Formapagonombre)) { _Formapagonombre = value; OnPropertyChanged(); } } }

        private string? _Formapagosatclave;
        [XmlAttribute]
        public string? Formapagosatclave { get => _Formapagosatclave; set { if (RaiseAcceptPendingChange(value, _Formapagosatclave)) { _Formapagosatclave = value; OnPropertyChanged(); } } }

        private string? _Formapagosatnombre;
        [XmlAttribute]
        public string? Formapagosatnombre { get => _Formapagosatnombre; set { if (RaiseAcceptPendingChange(value, _Formapagosatnombre)) { _Formapagosatnombre = value; OnPropertyChanged(); } } }

        private string? _Referenciabancaria;
        [XmlAttribute]
        public string? Referenciabancaria { get => _Referenciabancaria; set { if (RaiseAcceptPendingChange(value, _Referenciabancaria)) { _Referenciabancaria = value; OnPropertyChanged(); } } }

        private string? _Tipopagoclave;
        [XmlAttribute]
        public string? Tipopagoclave { get => _Tipopagoclave; set { if (RaiseAcceptPendingChange(value, _Tipopagoclave)) { _Tipopagoclave = value; OnPropertyChanged(); } } }

        private string? _Tipopagonombre;
        [XmlAttribute]
        public string? Tipopagonombre { get => _Tipopagonombre; set { if (RaiseAcceptPendingChange(value, _Tipopagonombre)) { _Tipopagonombre = value; OnPropertyChanged(); } } }

        private string? _Bancoclave;
        [XmlAttribute]
        public string? Bancoclave { get => _Bancoclave; set { if (RaiseAcceptPendingChange(value, _Bancoclave)) { _Bancoclave = value; OnPropertyChanged(); } } }

        private string? _Banconombre;
        [XmlAttribute]
        public string? Banconombre { get => _Banconombre; set { if (RaiseAcceptPendingChange(value, _Banconombre)) { _Banconombre = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechaelaboracion;
        [XmlAttribute]
        public DateTimeOffset? Fechaelaboracion { get => _Fechaelaboracion; set { if (RaiseAcceptPendingChange(value, _Fechaelaboracion)) { _Fechaelaboracion = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecharecepcion;
        [XmlAttribute]
        public DateTimeOffset? Fecharecepcion { get => _Fecharecepcion; set { if (RaiseAcceptPendingChange(value, _Fecharecepcion)) { _Fecharecepcion = value; OnPropertyChanged(); } } }

        private long? _Reciboelectronicoid;
        [XmlAttribute]
        public long? Reciboelectronicoid { get => _Reciboelectronicoid; set { if (RaiseAcceptPendingChange(value, _Reciboelectronicoid)) { _Reciboelectronicoid = value; OnPropertyChanged(); } } }

        private BoolCN? _Esconpinpadbancomer;
        [XmlAttribute]
        public BoolCN? Esconpinpadbancomer { get => _Esconpinpadbancomer; set { if (RaiseAcceptPendingChange(value, _Esconpinpadbancomer)) { _Esconpinpadbancomer = value; OnPropertyChanged(); } } }

        private long? _Bancomerparamid;
        [XmlAttribute]
        public long? Bancomerparamid { get => _Bancomerparamid; set { if (RaiseAcceptPendingChange(value, _Bancomerparamid)) { _Bancomerparamid = value; OnPropertyChanged(); } } }

        private decimal? _Comision;
        [XmlAttribute]
        public decimal? Comision { get => _Comision; set { if (RaiseAcceptPendingChange(value, _Comision)) { _Comision = value; OnPropertyChanged(); } } }

        private string? _Notas;
        [XmlAttribute]
        public string? Notas { get => _Notas; set { if (RaiseAcceptPendingChange(value, _Notas)) { _Notas = value; OnPropertyChanged(); } } }

        private BoolCN? _Aplicado;
        [XmlAttribute]
        public BoolCN? Aplicado { get => _Aplicado; set { if (RaiseAcceptPendingChange(value, _Aplicado)) { _Aplicado = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechaaplicado;
        [XmlAttribute]
        public DateTimeOffset? Fechaaplicado { get => _Fechaaplicado; set { if (RaiseAcceptPendingChange(value, _Fechaaplicado)) { _Fechaaplicado = value; OnPropertyChanged(); } } }

        private decimal? _Montopagocompuesto;
        [XmlAttribute]
        public decimal? Montopagocompuesto { get => _Montopagocompuesto; set { if (RaiseAcceptPendingChange(value, _Montopagocompuesto)) { _Montopagocompuesto = value; OnPropertyChanged(); } } }

        private string? _Refinterno;
        [XmlAttribute]
        public string? Refinterno { get => _Refinterno; set { if (RaiseAcceptPendingChange(value, _Refinterno)) { _Refinterno = value; OnPropertyChanged(); } } }

        private string? _Tipoabononombre;
        [XmlAttribute]
        public string? Tipoabononombre { get => _Tipoabononombre; set { if (RaiseAcceptPendingChange(value, _Tipoabononombre)) { _Tipoabononombre = value; OnPropertyChanged(); } } }



        private DateTimeOffset? _Creado;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public DateTimeOffset? Creado { get => _Creado ?? DateTime.UtcNow; set { if (RaiseAcceptPendingChange(value, _Creado)) { _Creado = value ?? DateTime.UtcNow; OnPropertyChanged(); } } }

        private DateTimeOffset? _Modificado;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public DateTimeOffset? Modificado { get => _Modificado ?? DateTime.UtcNow; set { if (RaiseAcceptPendingChange(value, _Modificado)) { _Modificado = value ?? DateTime.UtcNow; OnPropertyChanged(); } } }

        private long? _CreadoPorId;
        [XmlAttribute]
        public long? CreadoPorId { get => _CreadoPorId; set { if (RaiseAcceptPendingChange(value, _CreadoPorId)) { _CreadoPorId = value; OnPropertyChanged(); } } }

        private long? _ModificadoPorId;
        [XmlAttribute]
        public long? ModificadoPorId { get => _ModificadoPorId; set { if (RaiseAcceptPendingChange(value, _ModificadoPorId)) { _ModificadoPorId = value; OnPropertyChanged(); } } }




        private long? _Formapagoid;
        [XmlAttribute]
        public long? Formapagoid { get => _Formapagoid; set { if (RaiseAcceptPendingChange(value, _Formapagoid)) { _Formapagoid = value; OnPropertyChanged(); } } }

        private long? _Formapagosatid;
        [XmlAttribute]
        public long? Formapagosatid { get => _Formapagosatid; set { if (RaiseAcceptPendingChange(value, _Formapagosatid)) { _Formapagosatid = value; OnPropertyChanged(); } } }


        private long? _Clienteid;
        [XmlAttribute]
        public long? Clienteid { get => _Clienteid; set { if (RaiseAcceptPendingChange(value, _Clienteid)) { _Clienteid = value; OnPropertyChanged(); } } }


        private long? _Proveedorid;
        [XmlAttribute]
        public long? Proveedorid { get => _Proveedorid; set { if (RaiseAcceptPendingChange(value, _Proveedorid)) { _Proveedorid = value; OnPropertyChanged(); } } }


        private long? _Bancoid;
        [XmlAttribute]
        public long? Bancoid { get => _Bancoid; set { if (RaiseAcceptPendingChange(value, _Bancoid)) { _Bancoid = value; OnPropertyChanged(); } } }


        private long? _Tipopagoid;
        [XmlAttribute]
        public long? Tipopagoid { get => _Tipopagoid; set { if (RaiseAcceptPendingChange(value, _Tipopagoid)) { _Tipopagoid = value; OnPropertyChanged(); } } }


        private long? _Cuentabancoempresaid;
        [XmlAttribute]
        public long? Cuentabancoempresaid { get => _Cuentabancoempresaid; set { if (RaiseAcceptPendingChange(value, _Cuentabancoempresaid)) { _Cuentabancoempresaid = value; OnPropertyChanged(); } } }


        private string? _Cuentapagocredito;
        [XmlAttribute]
        public string? Cuentapagocredito { get => _Cuentapagocredito; set { if (RaiseAcceptPendingChange(value, _Cuentapagocredito)) { _Cuentapagocredito = value; OnPropertyChanged(); } } }


        private int? _Sentidopago;
        [XmlAttribute]
        public int? Sentidopago { get => _Sentidopago; set { if (RaiseAcceptPendingChange(value, _Sentidopago)) { _Sentidopago = value; OnPropertyChanged(); } } }



        private long? _Pagoparentid;
        [XmlAttribute]
        public long? Pagoparentid { get => _Pagoparentid; set { if (RaiseAcceptPendingChange(value, _Cuentabancoempresaid)) { _Cuentabancoempresaid = value; OnPropertyChanged(); } } }




        private string? _Cuentabancoempresaclave;
        [XmlAttribute]
        public string? Cuentabancoempresaclave { get => _Cuentabancoempresaclave; set { if (RaiseAcceptPendingChange(value, _Cuentabancoempresaclave)) { _Cuentabancoempresaclave = value; OnPropertyChanged(); } } }

        private string? _Cuentabancoempresanombre;
        [XmlAttribute]
        public string? Cuentabancoempresanombre { get => _Cuentabancoempresanombre; set { if (RaiseAcceptPendingChange(value, _Cuentabancoempresanombre)) { _Cuentabancoempresanombre = value; OnPropertyChanged(); } } }




        private string? _Clienteclave;
        [XmlAttribute]
        public string? Clienteclave { get => _Clienteclave; set { if (RaiseAcceptPendingChange(value, _Clienteclave)) { _Clienteclave = value; OnPropertyChanged(); } } }

        private string? _Clientenombre;
        [XmlAttribute]
        public string? Clientenombre { get => _Clientenombre; set { if (RaiseAcceptPendingChange(value, _Clientenombre)) { _Clientenombre = value; OnPropertyChanged(); } } }


        private string? _Proveedorclave;
        [XmlAttribute]
        public string? Proveedorclave { get => _Proveedorclave; set { if (RaiseAcceptPendingChange(value, _Proveedorclave)) { _Proveedorclave = value; OnPropertyChanged(); } } }

        private string? _Proveedornombre;
        [XmlAttribute]
        public string? Proveedornombre { get => _Proveedornombre; set { if (RaiseAcceptPendingChange(value, _Proveedornombre)) { _Proveedornombre = value; OnPropertyChanged(); } } }


        private BoolCN _Revertido;
        public BoolCN Revertido { get => _Revertido; 
                                  set { if (RaiseAcceptPendingChange(value, _Revertido)) 
                                      { _Revertido = value; OnPropertyChanged(); } } }


        private bool _Espagocompuesto;
        public bool Espagocompuesto
        {
            get => _Espagocompuesto;
            set
            {
                if (RaiseAcceptPendingChange(value, _Espagocompuesto))
                { _Espagocompuesto = value; OnPropertyChanged(); }
            }
        }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""TmpDoctoPagoItem"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Formapago|Formapagoclave|Formapagonombre|Formapagosatclave|Formapagosatnombre|Referenciabancaria|Tipopagoclave|Tipopagonombre|Bancoclave|Banconombre|Notas|Refinterno|Tipoabononombre";
        }


        #if PROYECTO_WEB
        public virtual void FillCatalogRelatedFields(TmpDoctoPagoItem item)
        {


        }


        public virtual void FillFromEntity(TmpDoctoPagoItem item)
        {

            EmpresaId = item.EmpresaId;

            SucursalId = item.SucursalId;

            Id = item.Id;

            Pagoid = item.Pagoid;

            Fecha = item.Fecha;

            Fechahora = item.Fechahora;

            Formapago = item.Formapago;

            Monto = item.Monto;

            Formapagoclave = item.Formapagoclave;

            Formapagonombre = item.Formapagonombre;

            Formapagosatclave = item.Formapagosatclave;

            Formapagosatnombre = item.Formapagosatnombre;

            Referenciabancaria = item.Referenciabancaria;

            Tipopagoclave = item.Tipopagoclave;

            Tipopagonombre = item.Tipopagonombre;

            Bancoclave = item.Bancoclave;

            Banconombre = item.Banconombre;

            Fechaelaboracion = item.Fechaelaboracion;

            Fecharecepcion = item.Fecharecepcion;

            Reciboelectronicoid = item.Reciboelectronicoid;

            Esconpinpadbancomer = item.Esconpinpadbancomer;

            Bancomerparamid = item.Bancomerparamid;

            Comision = item.Comision;

            Notas = item.Notas;

            Aplicado = item.Aplicado;

            Fechaaplicado = item.Fechaaplicado;

            Montopagocompuesto = item.Montopagocompuesto;

            Refinterno = item.Refinterno;

            Tipoabononombre = item.Tipoabononombre;


            Formapagoid = item.Formapagoid;
            Formapagosatid = item.Formapagosatid;
            Clienteid = item.Clienteid;
            Proveedorid = item.Proveedorid;
            Bancoid = item.Bancoid;
            Tipopagoid = item.Tipopagoid;
            Cuentabancoempresaid = item.Cuentabancoempresaid;
            Cuentapagocredito = item.Cuentapagocredito;
            Sentidopago = item.Sentidopago;
            Pagoparentid = item.Pagoparentid;

            Cuentabancoempresaclave = item.Cuentabancoempresaclave;
            Cuentabancoempresanombre = item.Cuentabancoempresanombre;
            Clienteclave = item.Clienteclave;
            Clientenombre = item.Clientenombre;
            Proveedorclave = item.Proveedorclave;
            Proveedornombre = item.Proveedornombre;

            Revertido = item.Revertido;
            Espagocompuesto = item.Espagocompuesto;


            FillCatalogRelatedFields(item);


        }
        #endif



    }
}

