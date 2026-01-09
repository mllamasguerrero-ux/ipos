
using BindingModels;
using IposV3.Model;
using Caliburn.Micro;
using Controllers;
using Controllers.Controller;
//using IposV3.Controllers.Controller;
//using DataAccess;
using Models.CatalogSelector; 
using IposV3.ViewModels.BaseScreen;
using ViewModels.BaseScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace IposV3.ViewModels
{

    public class PromocionItemViewModel : BaseWebRecordViewModel<PromocionBindingModel, PromocionWebController, PromocionItemVMInitialParameters, PromocionListVMEventParameters>
    {

        public Dictionary<string, bool> BoolBindingExpression { get; set; }


        public PromocionBindingModel? Promocion { get { return Record; } set { Record = value; } }
        public PromocionItemViewModel(string mode, PromocionWebController provider, UsuarioWebController usuarioController , SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(mode, provider, usuarioController , selectorProvider, aggregator, winManager, messageBoxService)
        {

            BoolBindingExpression = new Dictionary<string, bool>();
            fillBoolBindingExpressions();
        }




        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                          new CatalogRelatedFields("Promocion","Producto","Productoid", "ProductoClave", "ProductoNombre","IposV3.ViewModels.ProductoListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Promocion","Tipopromocion","Tipopromocionid", "TipopromocionClave", "TipopromocionNombre","IposV3.ViewModels.TipopromocionListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Promocion","Rangopromocion","Rangopromocionid", "RangopromocionClave", "RangopromocionNombre","IposV3.ViewModels.RangopromocionListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Promocion","Linea","Lineaid", "LineaClave", "LineaNombre","IposV3.ViewModels.LineaListViewModel","SelectedItem","Clave")
                                    };
            lstCatalogDef = new List<CatalogDef>();
            

        }

        protected override void fillRecordToEdit(PromocionItemVMInitialParameters initialParameters)
        {
            base.fillRecordToEdit(initialParameters);
            fillBoolBindingExpressions();

        }
        protected override void preFillRecordToAdd()
        {
            base.preFillRecordToAdd();
            fillBoolBindingExpressions();
        }


        public override void RecordChangedEventHandler(object? sender, PropertyChangedEventArgs e)
        {

            switch (e.PropertyName)
            {
                case "Tipopromocionid":


                    BoolBindingExpression["COMPRATANTOSLLEVATETANTOS"] = !this.BIsReadOnly && this.Record != null && this.Record.Tipopromocionid == DBValues._TIPOPROMOCIONCOMPRASXLLEVASMAS;
                    BoolBindingExpression["COMPRATANTOSPORTALIMPORTE"] = !this.BIsReadOnly && this.Record != null && this.Record.Tipopromocionid == DBValues._TIPOPROMOCIONCOMPRASXCONIMPORTE;
                    BoolBindingExpression["CONPORCENTAJEDESCUENTO"] = !this.BIsReadOnly && this.Record != null && this.Record.Tipopromocionid == DBValues._TIPOPROMOCIONDESCUENTOPORCENTAJE;
                    BoolBindingExpression["PORCADAIMPORTELLEVATE"] = !this.BIsReadOnly && this.Record != null && this.Record.Tipopromocionid == DBValues._TIPOPROMOCIONPORCADAIMPORTELLEVATE;
                    BoolBindingExpression["DESC_MONTOMIN_LINEA"] = !this.BIsReadOnly && this.Record != null && this.Record.Tipopromocionid == DBValues._TIPOPROMOCIONDESC_MONTOMIN_LINEA;
                    BoolBindingExpression["COMPRATANTOSPORTALIMPORTEMANTEN"] = !this.BIsReadOnly && this.Record != null && this.Record.Tipopromocionid == DBValues._TIPOPROMOCIONCOMPRASXCONIMPORTEMANTEN;
                    BoolBindingExpression["BODEGAZO"] = !this.BIsReadOnly && this.Record != null && this.Record.Tipopromocionid == DBValues._TIPOPROMOCIONBODEGAZO;
                    BoolBindingExpression["CUPONES"] = !this.BIsReadOnly && this.Record != null && this.Record.Tipopromocionid == DBValues._TIPOPROMOCIONCUPONES;
                    BoolBindingExpression["CUPONPORCADAMONTODEIMPORTE"] = !this.BIsReadOnly && this.Record != null && this.Record.Tipopromocionid == DBValues._TIPOPROMOCIONCUPONPORCADAMONTODEIMPORTE;

                    if(this.Record != null && this.Record?.Tipopromocionid != DBValues._TIPOPROMOCIONCOMPRASXLLEVASMAS)
                    {
                        this.Record!.Cant_x_llevate_mas_cant = 0;
                        this.Record!.Cant_x_llevate_mas_llevate = 0;
                    }

                    if (this.Record != null && this.Record?.Tipopromocionid != DBValues._TIPOPROMOCIONCOMPRASXCONIMPORTE)
                    {
                        this.Record!.Cant_x_importe_menor_cant = 0;
                        this.Record!.Cant_x_importe_menor_importe = 0;
                    }

                    if (this.Record != null && this.Record?.Tipopromocionid != DBValues._TIPOPROMOCIONDESCUENTOPORCENTAJE)
                    {
                        this.Record!.PorcDesc = 0;
                        this.Record!.Enmonedero_general = 0;
                    }

                    if (this.Record != null && this.Record?.Tipopromocionid != DBValues._TIPOPROMOCIONPORCADAIMPORTELLEVATE)
                    {
                        this.Record!.Cant_x_llevate_mas_cant = 0;
                        this.Record!.Cant_x_llevate_mas_llevate = 0;
                    }

                    if (this.Record != null && this.Record?.Tipopromocionid != DBValues._TIPOPROMOCIONDESC_MONTOMIN_LINEA)
                    {
                        this.Record!.Monto_min_desc_x_linea = 0;
                        this.Record!.PorcDesc_min_desc_x_linea = 0;
                    }

                    if (this.Record != null && this.Record?.Tipopromocionid != DBValues._TIPOPROMOCIONCOMPRASXCONIMPORTEMANTEN)
                    {
                        this.Record!.Cant_x_importe_menor_ext_cant = 0;
                        this.Record!.Cant_x_importe_menor_ext_importe = 0;
                    }

                    if (this.Record != null && this.Record?.Tipopromocionid != DBValues._TIPOPROMOCIONBODEGAZO)
                    {
                        this.Record!.PorcAum_bodegazo = 0;
                        this.Record!.Enmonedero_bodegazo = 0;
                    }

                    if (this.Record != null && 
                        (this.Record?.Tipopromocionid != DBValues._TIPOPROMOCIONCUPONES &&
                        this.Record?.Tipopromocionid != DBValues._TIPOPROMOCIONCUPONPORCADAMONTODEIMPORTE
                        ))
                    {
                        this.Record!.Monto_min_cupon = 0;
                    }



                    NotifyOfPropertyChange("Record");
                    NotifyOfPropertyChange("BoolBindingExpression");
                    break;

                case "Rangopromocionid":


                    BoolBindingExpression["RANGOPORPRODUCTO"] = !this.BIsReadOnly && this.Record != null && this.Record.Rangopromocionid == DBValues._RANGOPROMOCIONXPRODUCTO;
                    BoolBindingExpression["RANGOPORLINEA"] = !this.BIsReadOnly && this.Record != null && this.Record.Rangopromocionid == DBValues._RANGOPROMOCIONXLINEA;
                    BoolBindingExpression["RANGOPORBODEGAZO"] = !this.BIsReadOnly && this.Record != null && this.Record.Rangopromocionid == DBValues._RANGOPROMOCIONXBODEGAZO;
                    BoolBindingExpression["RANGOGENERAL"] = !this.BIsReadOnly && this.Record != null && this.Record.Rangopromocionid == DBValues._RANGOPROMOCIONGENERAL;
                    BoolBindingExpression["RANGONOBODEGAZONILINEA"] = !this.BIsReadOnly && this.Record != null && this.Record.Rangopromocionid != DBValues._RANGOPROMOCIONXLINEA &&
                                                                                                                    this.Record.Rangopromocionid == DBValues._RANGOPROMOCIONXBODEGAZO;

                    if (this.Record != null && this.Record?.Rangopromocionid != DBValues._RANGOPROMOCIONXPRODUCTO)
                    {
                        this.Record!.Productoid = null;
                        this.Record!.ProductoClave = null;
                        this.Record!.ProductoNombre = null;
                    }

                    if (this.Record != null && this.Record?.Rangopromocionid != DBValues._RANGOPROMOCIONXLINEA)
                    {
                        this.Record!.Lineaid = null;
                        this.Record!.LineaClave = null;
                        this.Record!.LineaNombre = null;

                        if(this.Record?.Tipopromocionid == DBValues._TIPOPROMOCIONDESC_MONTOMIN_LINEA)
                        {
                            this.Record!.Tipopromocionid = null;
                        }
                    }

                    if (this.Record != null && this.Record?.Rangopromocionid != DBValues._RANGOPROMOCIONXBODEGAZO)
                    {
                        this.Record!.PorcAum_bodegazo = null;
                        this.Record!.Enmonedero_bodegazo = null;

                        if (this.Record?.Tipopromocionid == DBValues._TIPOPROMOCIONBODEGAZO)
                        {
                            this.Record!.Tipopromocionid = null;
                        }
                    }

                    NotifyOfPropertyChange("Record");
                    NotifyOfPropertyChange("BoolBindingExpression");
                    break;


                default:
                    break;
            }
        }


        private void fillBoolBindingExpressions()
        {

            var boolBindingExpression = new Dictionary<string, bool>();

            boolBindingExpression.Clear();

            boolBindingExpression.Add("COMPRATANTOSLLEVATETANTOS", !this.BIsReadOnly && this.Record != null  && (this.Record.Tipopromocionid  ?? -1)  == DBValues._TIPOPROMOCIONCOMPRASXLLEVASMAS);
            boolBindingExpression.Add("COMPRATANTOSPORTALIMPORTE", !this.BIsReadOnly && this.Record != null && (this.Record.Tipopromocionid ?? -1) == DBValues._TIPOPROMOCIONCOMPRASXCONIMPORTE);
            boolBindingExpression.Add("CONPORCENTAJEDESCUENTO", !this.BIsReadOnly && this.Record != null && (this.Record.Tipopromocionid  ?? -1) == DBValues._TIPOPROMOCIONDESCUENTOPORCENTAJE);
            boolBindingExpression.Add("PORCADAIMPORTELLEVATE", !this.BIsReadOnly && this.Record != null && (this.Record.Tipopromocionid  ?? -1) == DBValues._TIPOPROMOCIONPORCADAIMPORTELLEVATE);
            boolBindingExpression.Add("DESC_MONTOMIN_LINEA", !this.BIsReadOnly && this.Record != null && (this.Record.Tipopromocionid  ?? -1) == DBValues._TIPOPROMOCIONDESC_MONTOMIN_LINEA);
            boolBindingExpression.Add("COMPRATANTOSPORTALIMPORTEMANTEN", !this.BIsReadOnly && this.Record != null && (this.Record.Tipopromocionid  ?? -1) == DBValues._TIPOPROMOCIONCOMPRASXCONIMPORTEMANTEN);
            boolBindingExpression.Add("BODEGAZO", !this.BIsReadOnly && this.Record != null && (this.Record.Tipopromocionid  ?? -1) == DBValues._TIPOPROMOCIONBODEGAZO);
            boolBindingExpression.Add("CUPONES", !this.BIsReadOnly && this.Record != null && (this.Record.Tipopromocionid  ?? -1) == DBValues._TIPOPROMOCIONCUPONES);
            boolBindingExpression.Add("CUPONPORCADAMONTODEIMPORTE", !this.BIsReadOnly && this.Record != null && (this.Record.Tipopromocionid  ?? -1) == DBValues._TIPOPROMOCIONCUPONPORCADAMONTODEIMPORTE);
            boolBindingExpression.Add("ALGUNTIPOCUPON", !this.BIsReadOnly && this.Record != null && ((this.Record.Tipopromocionid ?? -1 ) == DBValues._TIPOPROMOCIONCUPONPORCADAMONTODEIMPORTE ||
                                                                                                     (this.Record.Tipopromocionid ?? -1) == DBValues._TIPOPROMOCIONCUPONES));


            boolBindingExpression.Add("RANGOPORPRODUCTO", !this.BIsReadOnly && this.Record != null && (this.Record.Rangopromocionid ?? -1) == DBValues._RANGOPROMOCIONXPRODUCTO);
            boolBindingExpression.Add("RANGOPORLINEA", !this.BIsReadOnly && this.Record != null && (this.Record.Rangopromocionid ?? -1) == DBValues._RANGOPROMOCIONXLINEA);
            boolBindingExpression.Add("RANGOPORBODEGAZO", !this.BIsReadOnly && this.Record != null && (this.Record.Rangopromocionid ?? -1) == DBValues._RANGOPROMOCIONXBODEGAZO);
            boolBindingExpression.Add("RANGOGENERAL", !this.BIsReadOnly && this.Record != null && (this.Record.Rangopromocionid ?? -1) == DBValues._RANGOPROMOCIONGENERAL);
            boolBindingExpression.Add("RANGONOBODEGAZONILINEA", !this.BIsReadOnly && this.Record != null && (this.Record.Rangopromocionid ?? -1) != DBValues._RANGOPROMOCIONXLINEA &&
                                                                                                            (this.Record.Rangopromocionid ?? -1) == DBValues._RANGOPROMOCIONXBODEGAZO);

            this.BoolBindingExpression = boolBindingExpression;
            NotifyOfPropertyChange("BoolBindingExpression");


        }

    }


     public class PromocionShowViewModel : PromocionItemViewModel
    {
        public PromocionShowViewModel(PromocionWebController provider, UsuarioWebController usuarioController , SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Show", provider, usuarioController , selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class PromocionEditViewModel : PromocionItemViewModel
    {
        public PromocionEditViewModel(PromocionWebController provider, UsuarioWebController usuarioController , SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Edit", provider, usuarioController , selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class PromocionAddViewModel : PromocionItemViewModel
    {
        public PromocionAddViewModel(PromocionWebController provider, UsuarioWebController usuarioController , SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Add", provider, usuarioController , selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

}


