
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
    public class CartaporteBindingModel: CartaporteBindingModelGenerated
    {


        public CartaporteBindingModel():base()
        {
        }

        private CartaporteAutotranspBindingModel? _CartaporteAutotransps;
        public CartaporteAutotranspBindingModel? CartaporteAutotransps { get => _CartaporteAutotransps; set { _CartaporteAutotransps = value; } }


        private CartaporteCanttranspBindingModel? _CartaporteCanttransps;
        public CartaporteCanttranspBindingModel? CartaporteCanttransps { get => _CartaporteCanttransps; set { _CartaporteCanttransps = value; }  }


        private CartaporteTotalmercanciasBindingModel? _CartaporteTotalmercancias;
        public CartaporteTotalmercanciasBindingModel? CartaporteTotalmercancias { get => _CartaporteTotalmercancias; set { _CartaporteTotalmercancias = value; } }



        private ICollection<CartaporteMercanciaBindingModel>? _CartaporteMercancias;
        public ICollection<CartaporteMercanciaBindingModel>? CartaporteMercancias { get => _CartaporteMercancias; set { _CartaporteMercancias = value; } }



        private ICollection<CartaporteTransptipofiguraBindingModel>? _CartaporteTransptipofiguras;
        public ICollection<CartaporteTransptipofiguraBindingModel>? CartaporteTransptipofiguras { get => _CartaporteTransptipofiguras; set { _CartaporteTransptipofiguras = value; } }



        private ICollection<CartaporteUbicacionBindingModel>? _CartaporteUbicacions;
        public ICollection<CartaporteUbicacionBindingModel>? CartaporteUbicacions { get => _CartaporteUbicacions; set { _CartaporteUbicacions = value; } }




    }
}

