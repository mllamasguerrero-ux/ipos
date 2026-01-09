
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
    public class ProductoBindingModel: ProductoBindingModelGenerated
    {


        public ProductoBindingModel():base()
        {
        }
        

        #if PROYECTO_WEB
        public ProductoBindingModel(Producto item):base(item)
        {
        }
        #endif




        [XmlAttribute]
        private decimal? _Producto_precios_Precio1_conImp;
        [XmlAttribute]
        public decimal? Producto_precios_Precio1_conImp { get => _Producto_precios_Precio1_conImp ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Precio1_conImp)) { _Producto_precios_Precio1_conImp = value ?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Precio2_conImp;
        [XmlAttribute]
        public decimal? Producto_precios_Precio2_conImp { get => _Producto_precios_Precio2_conImp ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Precio2_conImp)) { _Producto_precios_Precio2_conImp = value ?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Precio3_conImp;
        [XmlAttribute]
        public decimal? Producto_precios_Precio3_conImp { get => _Producto_precios_Precio3_conImp ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Precio3_conImp)) { _Producto_precios_Precio3_conImp = value ?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Precio4_conImp;
        [XmlAttribute]
        public decimal? Producto_precios_Precio4_conImp { get => _Producto_precios_Precio4_conImp ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Precio4_conImp)) { _Producto_precios_Precio4_conImp = value ?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Precio5_conImp;
        [XmlAttribute]
        public decimal? Producto_precios_Precio5_conImp { get => _Producto_precios_Precio5_conImp ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Precio5_conImp)) { _Producto_precios_Precio5_conImp = value ?? 0; OnPropertyChanged(); } } }


        private decimal? _Producto_precios_caja_conImp;
        [XmlAttribute]
        public decimal? Producto_precios_caja_conImp { get => _Producto_precios_caja_conImp ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_caja_conImp)) { _Producto_precios_caja_conImp = value ?? 0; OnPropertyChanged(); } } }




        private decimal? _Producto_precios_Costorepoconutilimp;
        [XmlAttribute]
        public decimal? Producto_precios_Costorepoconutilimp { get => _Producto_precios_Costorepoconutilimp ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Costorepoconutilimp)) { _Producto_precios_Costorepoconutilimp = value ?? 0; OnPropertyChanged(); } } }


        private decimal? _Producto_precios_Preciomediomayoreocontarjeta;
        [XmlAttribute]
        public decimal? Producto_precios_Preciomediomayoreocontarjeta { get => _Producto_precios_Preciomediomayoreocontarjeta ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Preciomediomayoreocontarjeta)) { _Producto_precios_Preciomediomayoreocontarjeta = value ?? 0; OnPropertyChanged(); } } }



        private decimal? _Producto_precios_Preciomayoreocontarjeta;
        [XmlAttribute]
        public decimal? Producto_precios_Preciomayoreocontarjeta { get => _Producto_precios_Preciomayoreocontarjeta ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Preciomayoreocontarjeta)) { _Producto_precios_Preciomayoreocontarjeta = value ?? 0; OnPropertyChanged(); } } }



        private decimal? _Producto_inventario_ExistenciaCajas;
        [XmlAttribute]
        public decimal? Producto_inventario_ExistenciaCajas { get => _Producto_inventario_ExistenciaCajas ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_inventario_ExistenciaCajas)) { _Producto_inventario_ExistenciaCajas = value ?? 0; OnPropertyChanged(); } } }



        private decimal? _Producto_inventario_ExistenciaPiezas;
        [XmlAttribute]
        public decimal? Producto_inventario_ExistenciaPiezas { get => _Producto_inventario_ExistenciaPiezas ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_inventario_ExistenciaPiezas)) { _Producto_inventario_ExistenciaPiezas = value ?? 0; OnPropertyChanged(); } } }





        #if PROYECTO_WEB
        public void FillEntityValues(ref Producto item, Parametro parametro, Cliente clienteMostrador)
        {
            base.FillEntityValues(ref item);
            _Producto_precios_Precio1_conImp = Math.Round((Producto_precios_Precio1 ?? 0m) * ((parametro.Desgloseieps != BoolCN.S) ? 1m : (1m + ((Iepsimpuesto ?? 0m) / 100m))) * (1m + ((Ivaimpuesto ?? 0m)/ 100m)) , 4);
            _Producto_precios_Precio2_conImp = Math.Round((Producto_precios_Precio2 ?? 0m) * ((parametro.Desgloseieps != BoolCN.S) ? 1m : (1m + ((Iepsimpuesto ?? 0m) / 100m))) * (1m + ((Ivaimpuesto ?? 0m) / 100m)), 4);
            _Producto_precios_Precio3_conImp = Math.Round((Producto_precios_Precio3 ?? 0m) * ((parametro.Desgloseieps != BoolCN.S) ? 1m : (1m + ((Iepsimpuesto ?? 0m) / 100m))) * (1m + ((Ivaimpuesto ?? 0m) / 100m)), 4);
            _Producto_precios_Precio4_conImp = Math.Round((Producto_precios_Precio4 ?? 0m) * ((parametro.Desgloseieps != BoolCN.S) ? 1m : (1m + ((Iepsimpuesto ?? 0m) / 100m))) * (1m + ((Ivaimpuesto ?? 0m) / 100m)), 4);
            _Producto_precios_Precio5_conImp = Math.Round((Producto_precios_Precio5 ?? 0m) * ((parametro.Desgloseieps != BoolCN.S) ? 1m : (1m + ((Iepsimpuesto ?? 0m) / 100m))) * (1m + ((Ivaimpuesto ?? 0m) / 100m)), 4);

            decimal? bufferPrecio;
            if ((item.Producto_inventario?.Pzacaja ?? 1m) > 1 && parametro.Cambiarprecioxpzacaja == BoolCN.S && parametro.Listaprecioxpzacaja > 0)
            {
                switch(parametro.Listaprecioxpzacaja_?.Clave)
                {
                    case "PRECIO 1": bufferPrecio = Producto_precios_Precio1;  break;
                    case "PRECIO 2": bufferPrecio = Producto_precios_Precio2; break;
                    case "PRECIO 3": bufferPrecio = Producto_precios_Precio3; break;
                    case "PRECIO 4": bufferPrecio = Producto_precios_Precio4; break;
                    case "PRECIO 5": bufferPrecio = Producto_precios_Precio5; break;
                    default: bufferPrecio = Producto_precios_Precio1; break;
                }
            }
            else
            {
                bufferPrecio = Producto_precios_Precio1;
            }
            _Producto_precios_caja_conImp = Math.Round(
                                                        Math.Round(
                                                            (bufferPrecio ?? 0m) * 
                                                            ((parametro.Desgloseieps != BoolCN.S) ? 1m : (1m + ((Iepsimpuesto ?? 0m) / 100m))) * 
                                                            (1m + ((Ivaimpuesto ?? 0m) / 100m))
                                                            , 4) * 
                                                        (Producto_inventario_Pzacaja ?? 1m)
                                                        , 4);

            _Producto_precios_Costorepoconutilimp = Math.Round(
                                               Math.Round((this.Producto_precios_Costorepo ?? 0m) * (1m + (parametro.Porcutilidadlistado/100m) ), 4)
                                               * ((parametro.Desgloseieps != BoolCN.S) ? 1m : (1m + ((Iepsimpuesto ?? 0m) / 100m))) * (1m + ((Ivaimpuesto ?? 0m) / 100m)),
                                               4);



            decimal? bufferPrecioMostrador = PrecioXListaPrecio(clienteMostrador.Cliente_precio?.Listaprecio);
            decimal? bufferPrecioConTarjeta ;
            decimal? bufferPrecioConTarjetaConPrecioEspecial ;

            //medio mayoreo
            bufferPrecioConTarjeta = PrecioXListaPrecio(parametro.Listapremedmaylinea_) * (1m + (parametro.Comisionportarjeta / 100m));
            bufferPrecio = (new List<decimal?>() { bufferPrecioMostrador, bufferPrecioConTarjeta }).Min();


            _Producto_precios_Preciomediomayoreocontarjeta =
                                                    Math.Round(
                                                        Math.Round(
                                                            (bufferPrecio ?? 0m) *
                                                            ((parametro.Desgloseieps != BoolCN.S) ? 1m : (1m + ((Iepsimpuesto ?? 0m) / 100m))) *
                                                            (1m + ((Ivaimpuesto ?? 0m) / 100m))
                                                            , 4)
                                                        , 4);

            //mayoreo
            bufferPrecioConTarjeta = PrecioXListaPrecio(parametro.Listapreciomaylinea_) * (1m + (parametro.Comisionportarjeta / 100m));
            bufferPrecioConTarjetaConPrecioEspecial = Producto_precios_Precio6 * (1m + (parametro.Comisionportarjeta / 100m));
            bufferPrecio = (new List<decimal?>() { bufferPrecioMostrador, bufferPrecioConTarjeta, bufferPrecioConTarjetaConPrecioEspecial }).Min();


            _Producto_precios_Preciomayoreocontarjeta =
                                                    Math.Round(
                                                        Math.Round(
                                                            (bufferPrecio ?? 0m) *
                                                            ((parametro.Desgloseieps != BoolCN.S) ? 1m : (1m + ((Iepsimpuesto ?? 0m) / 100m))) *
                                                            (1m + ((Ivaimpuesto ?? 0m) / 100m))
                                                            , 4)
                                                        , 4);

            if ((this.Producto_inventario_Pzacaja ?? 1m) <= 1m)
            {

                _Producto_inventario_ExistenciaCajas = 0m;
                _Producto_inventario_ExistenciaPiezas = this.Producto_existencia_Existencia ?? 0m;
            }
            else
            {
                _Producto_inventario_ExistenciaPiezas = (this.Producto_existencia_Existencia ?? 0m) % (this.Producto_inventario_Pzacaja ?? 1m);
                _Producto_inventario_ExistenciaCajas = Math.Truncate((this.Producto_existencia_Existencia ?? 0m) / (this.Producto_inventario_Pzacaja ?? 1m));

            }




        }

        private decimal? PrecioXListaPrecio( Tipoprecio? tipoPrecio)
        {
            decimal? bufferPrecio ;

            switch (tipoPrecio?.Clave)
            {
                case "PRECIO 1": bufferPrecio = Producto_precios_Precio1; break;
                case "PRECIO 2": bufferPrecio = Producto_precios_Precio2; break;
                case "PRECIO 3": bufferPrecio = Producto_precios_Precio3; break;
                case "PRECIO 4": bufferPrecio = Producto_precios_Precio4; break;
                case "PRECIO 5": bufferPrecio = Producto_precios_Precio5; break;
                default: bufferPrecio = Producto_precios_Precio1; break;

            }

            return bufferPrecio;
        }
#endif


#if PROYECTO_ESCRITORIO
        
        private decimal? PrecioXListaPrecio(TipoprecioBindingModel? tipoPrecio)
        {
            decimal? bufferPrecio ;

            switch (tipoPrecio?.Clave)
            {
                case "PRECIO 1": bufferPrecio = Producto_precios_Precio1; break;
                case "PRECIO 2": bufferPrecio = Producto_precios_Precio2; break;
                case "PRECIO 3": bufferPrecio = Producto_precios_Precio3; break;
                case "PRECIO 4": bufferPrecio = Producto_precios_Precio4; break;
                case "PRECIO 5": bufferPrecio = Producto_precios_Precio5; break;
                default: bufferPrecio = Producto_precios_Precio1; break;

            }

            return bufferPrecio;
        }
#endif




        public decimal calculaPrecioSinImpuestos(decimal precioConImpuestos)
        {

            decimal dTasaIva = this.Ivaimpuesto != null ? this.Ivaimpuesto.Value : 0;
            decimal dTasaIeps = this.Iepsimpuesto != null ? this.Iepsimpuesto.Value : 0;
            decimal iva = dTasaIva > 0 ? precioConImpuestos - Math.Round(precioConImpuestos / (1 + (dTasaIva / 100)), 2) : 0;
            decimal ieps = dTasaIeps > 0 ? (precioConImpuestos - iva) - (Math.Round((precioConImpuestos - iva) / (1 + (dTasaIeps / 100)), 2)) : 0;
            decimal dPrecioSinImpuestos = (precioConImpuestos - iva - ieps);
            return Math.Round(dPrecioSinImpuestos, 2);


        }
        public decimal calculaPrecioConImpuestos(decimal precioSinImpuestos)
        {
            decimal dTasaIva = this.Ivaimpuesto != null ? this.Ivaimpuesto.Value : 0;
            decimal dTasaIeps = this.Iepsimpuesto != null ? this.Iepsimpuesto.Value : 0;
            decimal ieps = Math.Round(precioSinImpuestos * (dTasaIeps / 100.00m), 2);
            decimal iva = Math.Round((precioSinImpuestos + ieps) * (dTasaIva / 100.00m), 2);
            decimal precioConImpuesto = precioSinImpuestos + ieps + iva;
            return Math.Round(precioConImpuesto, 2);


        }




    }
}

