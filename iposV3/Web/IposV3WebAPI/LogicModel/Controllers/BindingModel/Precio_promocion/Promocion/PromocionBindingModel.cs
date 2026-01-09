
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using IposV3.Model;
using MvvmFramework;
using System.Xml.Serialization;

#if PROYECTO_WEB
using Microsoft.EntityFrameworkCore.Query;
#endif

namespace BindingModels
{
    [XmlRoot]
    public class PromocionBindingModel: PromocionBindingModelGenerated
    {


        public PromocionBindingModel():base()
        {
        }
        
        #if PROYECTO_WEB
        public PromocionBindingModel(Promocion item):base(item)
        {
        }
        #endif
        



        private decimal? _Cant_x_llevate_mas_cant;
        [XmlAttribute]
        public decimal? Cant_x_llevate_mas_cant { get => _Cant_x_llevate_mas_cant; set { if (RaiseAcceptPendingChange(value, _Cant_x_llevate_mas_cant)) { _Cant_x_llevate_mas_cant = value; OnPropertyChanged(); } } }



        private decimal? _Cant_x_importe_menor_cant;
        [XmlAttribute]
        public decimal? Cant_x_importe_menor_cant { get => _Cant_x_importe_menor_cant; set { if (RaiseAcceptPendingChange(value, _Cant_x_importe_menor_cant)) { _Cant_x_importe_menor_cant = value; OnPropertyChanged(); } } }



        private decimal? _Cant_x_importe_menor_ext_cant;
        [XmlAttribute]
        public decimal? Cant_x_importe_menor_ext_cant { get => _Cant_x_importe_menor_ext_cant; set { if (RaiseAcceptPendingChange(value, _Cant_x_importe_menor_ext_cant)) { _Cant_x_importe_menor_ext_cant = value; OnPropertyChanged(); } } }



        private decimal? _Cant_x_llevate_mas_llevate;
        [XmlAttribute]
        public decimal? Cant_x_llevate_mas_llevate { get => _Cant_x_llevate_mas_llevate; set { if (RaiseAcceptPendingChange(value, _Cant_x_llevate_mas_llevate)) { _Cant_x_llevate_mas_llevate = value; OnPropertyChanged(); } } }



        private decimal? _Cant_x_importe_menor_importe;
        [XmlAttribute]
        public decimal? Cant_x_importe_menor_importe { get => _Cant_x_importe_menor_importe; set { if (RaiseAcceptPendingChange(value, _Cant_x_importe_menor_importe)) { _Cant_x_importe_menor_importe = value; OnPropertyChanged(); } } }



        private decimal? _Monto_min_desc_x_linea;
        [XmlAttribute]
        public decimal? Monto_min_desc_x_linea { get => _Monto_min_desc_x_linea; set { if (RaiseAcceptPendingChange(value, _Monto_min_desc_x_linea)) { _Monto_min_desc_x_linea = value; OnPropertyChanged(); } } }



        private decimal? _Monto_min_cupon;
        [XmlAttribute]
        public decimal? Monto_min_cupon { get => _Monto_min_cupon; set { if (RaiseAcceptPendingChange(value, _Monto_min_cupon)) { _Monto_min_cupon = value; OnPropertyChanged(); } } }



        private decimal? _Cant_x_importe_menor_ext_importe;
        [XmlAttribute]
        public decimal? Cant_x_importe_menor_ext_importe { get => _Cant_x_importe_menor_ext_importe; set { if (RaiseAcceptPendingChange(value, _Cant_x_importe_menor_ext_importe)) { _Cant_x_importe_menor_ext_importe = value; OnPropertyChanged(); } } }



        private decimal? _PorcDesc;
        [XmlAttribute]
        public decimal? PorcDesc { get => _PorcDesc; set { if (RaiseAcceptPendingChange(value, _PorcDesc)) { _PorcDesc = value; OnPropertyChanged(); } } }



        private decimal? _PorcDesc_min_desc_x_linea;
        [XmlAttribute]
        public decimal? PorcDesc_min_desc_x_linea { get => _PorcDesc_min_desc_x_linea; set { if (RaiseAcceptPendingChange(value, _PorcDesc_min_desc_x_linea)) { _PorcDesc_min_desc_x_linea = value; OnPropertyChanged(); } } }



        private decimal? _PorcAum_bodegazo;
        [XmlAttribute]
        public decimal? PorcAum_bodegazo { get => _PorcAum_bodegazo; set { if (RaiseAcceptPendingChange(value, _PorcAum_bodegazo)) { _PorcAum_bodegazo = value; OnPropertyChanged(); } } }



        private BoolCN? _Enmonedero_general;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public BoolCN? Enmonedero_general { get => _Enmonedero_general ?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Enmonedero_general)) { _Enmonedero_general = value ?? BoolCN.N; OnPropertyChanged(); } } }


        private BoolCN? _Enmonedero_bodegazo;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public BoolCN? Enmonedero_bodegazo { get => _Enmonedero_bodegazo ?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Enmonedero_bodegazo)) { _Enmonedero_bodegazo = value ?? BoolCN.N; OnPropertyChanged(); } } }



        #if PROYECTO_WEB
        public override void FillEntityValues(ref Promocion item)
        {
            base.FillEntityValues(ref item);
            switch(Tipopromocionid)
            {

                case DBValues._TIPOPROMOCIONCOMPRASXLLEVASMAS:
                    item.Cantidad = Cant_x_llevate_mas_cant;
                    item.Cantidadllevate = Cant_x_llevate_mas_llevate;
                    break;
                case DBValues._TIPOPROMOCIONCOMPRASXCONIMPORTE:
                    item.Cantidad = Cant_x_importe_menor_cant;
                    item.Importe = Cant_x_importe_menor_importe;
                    break;
                case DBValues._TIPOPROMOCIONDESCUENTOPORCENTAJE:
                    item.Porcentajedescuento = PorcDesc;
                    item.Enmonedero = Enmonedero_general ?? BoolCN.N;
                    break;
                case DBValues._TIPOPROMOCIONPORCADAIMPORTELLEVATE:
                    break;
                case DBValues._TIPOPROMOCIONDESC_MONTOMIN_LINEA:
                    item.Importe = Monto_min_desc_x_linea;
                    item.Porcentajedescuento = PorcDesc_min_desc_x_linea;
                    break;
                case DBValues._TIPOPROMOCIONCOMPRASXCONIMPORTEMANTEN:
                    item.Cantidad = Cant_x_importe_menor_ext_cant;
                    item.Importe = Cant_x_importe_menor_ext_importe;
                    break;
                case DBValues._TIPOPROMOCIONBODEGAZO:
                    item.Porcentajedescuento = PorcAum_bodegazo;
                    item.Enmonedero = Enmonedero_bodegazo ?? BoolCN.N;
                    break;
                case DBValues._TIPOPROMOCIONCUPONES:
                    item.Importe = Monto_min_cupon;
                    break;
                case DBValues._TIPOPROMOCIONCUPONPORCADAMONTODEIMPORTE:
                    item.Importe = Monto_min_cupon;
                    break;


                default: break;
            }
        }


        public override void FillFromEntity(Promocion item)
        {
            base.FillFromEntity(item);

            switch (item.Tipopromocionid)
            {

                case DBValues._TIPOPROMOCIONCOMPRASXLLEVASMAS:
                    Cant_x_llevate_mas_cant = item.Cantidad;
                    Cant_x_llevate_mas_llevate = item.Cantidadllevate;
                    break;
                case DBValues._TIPOPROMOCIONCOMPRASXCONIMPORTE:
                    Cant_x_importe_menor_cant = item.Cantidad;
                    Cant_x_importe_menor_importe = item.Importe;
                    break;
                case DBValues._TIPOPROMOCIONDESCUENTOPORCENTAJE:
                    PorcDesc = item.Porcentajedescuento;
                    Enmonedero_general = item.Enmonedero ;
                    break;
                case DBValues._TIPOPROMOCIONPORCADAIMPORTELLEVATE:
                    break;
                case DBValues._TIPOPROMOCIONDESC_MONTOMIN_LINEA:
                    Monto_min_desc_x_linea  = item.Importe;
                    PorcDesc_min_desc_x_linea = item.Porcentajedescuento;
                    break;
                case DBValues._TIPOPROMOCIONCOMPRASXCONIMPORTEMANTEN:
                    Cant_x_importe_menor_ext_cant = item.Cantidad ;
                    Cant_x_importe_menor_ext_importe = item.Importe;
                    break;
                case DBValues._TIPOPROMOCIONBODEGAZO:
                    PorcAum_bodegazo = item.Porcentajedescuento;
                    Enmonedero_bodegazo = item.Enmonedero;
                    break;
                case DBValues._TIPOPROMOCIONCUPONES:
                    Monto_min_cupon = item.Importe;
                    break;
                case DBValues._TIPOPROMOCIONCUPONPORCADAMONTODEIMPORTE:
                    Monto_min_cupon = item.Importe;
                    break;


                default: break;
            }

        }
        #endif

    }
}

