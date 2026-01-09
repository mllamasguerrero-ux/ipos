
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
    public class WFPagosBasicoComprasWFBindingModel : Validatable
    {

        public WFPagosBasicoComprasWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Tbpagostotalventa;
        [XmlAttribute]
        public string? Tbpagostotalventa { get => _Tbpagostotalventa; set { if (RaiseAcceptPendingChange(value, _Tbpagostotalventa)) { _Tbpagostotalventa = value; OnPropertyChanged(); } } }

        private decimal? _Tbmontocheque;
        [XmlAttribute]
        public decimal? Tbmontocheque { get => _Tbmontocheque; set { if (RaiseAcceptPendingChange(value, _Tbmontocheque)) { _Tbmontocheque = value; OnPropertyChanged(); } } }

        private long? _Combobancocheque;
        [XmlAttribute]
        public long? Combobancocheque { get => _Combobancocheque; set { if (RaiseAcceptPendingChange(value, _Combobancocheque)) { _Combobancocheque = value; OnPropertyChanged(); } } }

        private string? _Tbreferenciacheque;
        [XmlAttribute]
        public string? Tbreferenciacheque { get => _Tbreferenciacheque; set { if (RaiseAcceptPendingChange(value, _Tbreferenciacheque)) { _Tbreferenciacheque = value; OnPropertyChanged(); } } }

        private decimal? _Tbmontotransferencia;
        [XmlAttribute]
        public decimal? Tbmontotransferencia { get => _Tbmontotransferencia; set { if (RaiseAcceptPendingChange(value, _Tbmontotransferencia)) { _Tbmontotransferencia = value; OnPropertyChanged(); } } }

        private long? _Combobancotransferencia;
        [XmlAttribute]
        public long? Combobancotransferencia { get => _Combobancotransferencia; set { if (RaiseAcceptPendingChange(value, _Combobancotransferencia)) { _Combobancotransferencia = value; OnPropertyChanged(); } } }

        private string? _Tbreferenciatransferencia;
        [XmlAttribute]
        public string? Tbreferenciatransferencia { get => _Tbreferenciatransferencia; set { if (RaiseAcceptPendingChange(value, _Tbreferenciatransferencia)) { _Tbreferenciatransferencia = value; OnPropertyChanged(); } } }

        private string? _Notapago;
        [XmlAttribute]
        public string? Notapago { get => _Notapago; set { if (RaiseAcceptPendingChange(value, _Notapago)) { _Notapago = value; OnPropertyChanged(); } } }

        private decimal? _Pa_abono;
        [XmlAttribute]
        public decimal? Pa_abono { get => _Pa_abono; set { if (RaiseAcceptPendingChange(value, _Pa_abono)) { _Pa_abono = value; OnPropertyChanged(); } } }

        private decimal? _Tbmontotarjeta;
        [XmlAttribute]
        public decimal? Tbmontotarjeta { get => _Tbmontotarjeta; set { if (RaiseAcceptPendingChange(value, _Tbmontotarjeta)) { _Tbmontotarjeta = value; OnPropertyChanged(); } } }

        private long? _Cbtipotarjeta;
        [XmlAttribute]
        public long? Cbtipotarjeta { get => _Cbtipotarjeta; set { if (RaiseAcceptPendingChange(value, _Cbtipotarjeta)) { _Cbtipotarjeta = value; OnPropertyChanged(); } } }

        private long? _Combobancotarjeta;
        [XmlAttribute]
        public long? Combobancotarjeta { get => _Combobancotarjeta; set { if (RaiseAcceptPendingChange(value, _Combobancotarjeta)) { _Combobancotarjeta = value; OnPropertyChanged(); } } }

        private string? _Tbreferenciatarjeta;
        [XmlAttribute]
        public string? Tbreferenciatarjeta { get => _Tbreferenciatarjeta; set { if (RaiseAcceptPendingChange(value, _Tbreferenciatarjeta)) { _Tbreferenciatarjeta = value; OnPropertyChanged(); } } }

        private string? _CombobancochequeClave;
        [XmlAttribute]
        public string? CombobancochequeClave { get => _CombobancochequeClave; set { if (RaiseAcceptPendingChange(value, _CombobancochequeClave)) { _CombobancochequeClave = value; OnPropertyChanged(); } } }

        private string? _CombobancochequeNombre;
        [XmlAttribute]
        public string? CombobancochequeNombre { get => _CombobancochequeNombre; set { if (RaiseAcceptPendingChange(value, _CombobancochequeNombre)) { _CombobancochequeNombre = value; OnPropertyChanged(); } } }

        private string? _CombobancotransferenciaClave;
        [XmlAttribute]
        public string? CombobancotransferenciaClave { get => _CombobancotransferenciaClave; set { if (RaiseAcceptPendingChange(value, _CombobancotransferenciaClave)) { _CombobancotransferenciaClave = value; OnPropertyChanged(); } } }

        private string? _CombobancotransferenciaNombre;
        [XmlAttribute]
        public string? CombobancotransferenciaNombre { get => _CombobancotransferenciaNombre; set { if (RaiseAcceptPendingChange(value, _CombobancotransferenciaNombre)) { _CombobancotransferenciaNombre = value; OnPropertyChanged(); } } }

        private string? _CbtipotarjetaClave;
        [XmlAttribute]
        public string? CbtipotarjetaClave { get => _CbtipotarjetaClave; set { if (RaiseAcceptPendingChange(value, _CbtipotarjetaClave)) { _CbtipotarjetaClave = value; OnPropertyChanged(); } } }

        private string? _CbtipotarjetaNombre;
        [XmlAttribute]
        public string? CbtipotarjetaNombre { get => _CbtipotarjetaNombre; set { if (RaiseAcceptPendingChange(value, _CbtipotarjetaNombre)) { _CbtipotarjetaNombre = value; OnPropertyChanged(); } } }

        private string? _CombobancotarjetaClave;
        [XmlAttribute]
        public string? CombobancotarjetaClave { get => _CombobancotarjetaClave; set { if (RaiseAcceptPendingChange(value, _CombobancotarjetaClave)) { _CombobancotarjetaClave = value; OnPropertyChanged(); } } }

        private string? _CombobancotarjetaNombre;
        [XmlAttribute]
        public string? CombobancotarjetaNombre { get => _CombobancotarjetaNombre; set { if (RaiseAcceptPendingChange(value, _CombobancotarjetaNombre)) { _CombobancotarjetaNombre = value; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {
            return "";
        }


        public static string GetFieldsForGeneralSearch()
        {
            return "";
        }


        public void FillCatalogRelatedFields()
        {

        }



    }

    
     
}

