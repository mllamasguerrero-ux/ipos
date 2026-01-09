
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
        public CartaporteBindingModel(Cartaporte item):base(item)
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



        public new void FillFromEntity(Cartaporte item)
        {
            base.FillFromEntity(item);

            if(item.CartaporteAutotransps != null)
            {
                CartaporteAutotranspBindingModel cartaporteAutotranspBindingModel = new CartaporteAutotranspBindingModel();
                cartaporteAutotranspBindingModel.FillFromEntity(item.CartaporteAutotransps);
                CartaporteAutotransps = cartaporteAutotranspBindingModel;
            }


            if (item.CartaporteCanttransps != null)
            {
                CartaporteCanttranspBindingModel cartaporteCanttranspBindingModel = new CartaporteCanttranspBindingModel();
                cartaporteCanttranspBindingModel.FillFromEntity(item.CartaporteCanttransps);
                this.CartaporteCanttransps = cartaporteCanttranspBindingModel;
            }


            if (item.CartaporteTotalmercancias != null)
            {
                CartaporteTotalmercanciasBindingModel cartaporteTotalmercanciasBindingModel = new CartaporteTotalmercanciasBindingModel();
                cartaporteTotalmercanciasBindingModel.FillFromEntity(item.CartaporteTotalmercancias);
                this.CartaporteTotalmercancias = cartaporteTotalmercanciasBindingModel;
            }


            if (item.CartaporteMercancias != null && item.CartaporteMercancias.Count() > 0)
            {
                this.CartaporteMercancias = new List<CartaporteMercanciaBindingModel>();
                foreach (var cartaporteMercancia in item.CartaporteMercancias)
                {
                    CartaporteMercanciaBindingModel cartaporteMercanciaBindingModel = new CartaporteMercanciaBindingModel();
                    cartaporteMercanciaBindingModel.FillFromEntity(cartaporteMercancia);
                    this.CartaporteMercancias.Add(cartaporteMercanciaBindingModel);
                }
            }


            if (item.CartaporteTransptipofiguras != null && item.CartaporteTransptipofiguras.Count() > 0)
            {
                this.CartaporteTransptipofiguras = new List<CartaporteTransptipofiguraBindingModel>();
                foreach (var cartaporteTransptipofigura in item.CartaporteTransptipofiguras)
                {
                    CartaporteTransptipofiguraBindingModel cartaporteTransptipofiguraBindingModel = new CartaporteTransptipofiguraBindingModel();
                    cartaporteTransptipofiguraBindingModel.FillFromEntity(cartaporteTransptipofigura);
                    this.CartaporteTransptipofiguras.Add(cartaporteTransptipofiguraBindingModel);
                }
            }


            if (item.CartaporteUbicacions != null && item.CartaporteUbicacions.Count() > 0)
            {
                this.CartaporteUbicacions = new List<CartaporteUbicacionBindingModel>();
                foreach (var cartaporteUbicacion in item.CartaporteUbicacions)
                {
                    CartaporteUbicacionBindingModel cartaporteUbicacionBindingModel = new CartaporteUbicacionBindingModel();
                    cartaporteUbicacionBindingModel.FillFromEntity(cartaporteUbicacion);
                    this.CartaporteUbicacions.Add(cartaporteUbicacionBindingModel);
                }
            }

        }

    }
}

