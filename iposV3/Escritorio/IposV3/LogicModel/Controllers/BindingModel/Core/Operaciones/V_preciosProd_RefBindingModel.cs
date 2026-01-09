
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
    public class V_preciosProd_RefBindingModel : Validatable
    {

        public V_preciosProd_RefBindingModel()
        {

        }


        private decimal? _Preciolista;

        [XmlAttribute]
        public virtual decimal? Preciolista { get => _Preciolista; set { _Preciolista = value; OnPropertyChanged();  } }



        private decimal? _Preciotraspaso;
        [XmlAttribute]
        public virtual decimal? Preciotraspaso { get => _Preciotraspaso; set { _Preciotraspaso = value; OnPropertyChanged();  } }



        private decimal? _Preciominimo;
        [XmlAttribute]
        public virtual decimal? Preciominimo { get => _Preciominimo; set { _Preciominimo = value; OnPropertyChanged();  } }



        private decimal? _Costo;

        [XmlAttribute]
        public virtual decimal? Costo { get => _Costo; set {  _Costo = value; OnPropertyChanged(); } }



        public decimal Precio { get; set; }
        public bool Espromocion { get; set; }
        public long? Promocionid { get; set; }
        public string? Promociondesglose { get; set; }
        public decimal Monederoabono { get; set; }
        public long? TipoMayoreoLineaIdAplicado { get; set; }

    }
}
