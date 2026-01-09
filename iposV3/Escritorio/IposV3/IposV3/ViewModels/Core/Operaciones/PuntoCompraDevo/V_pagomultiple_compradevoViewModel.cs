
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

namespace IposV3.ViewModels
{

    public class V_pagomultiple_compradevoViewModel : BaseGenericViewModel
    {

        public V_pagomultiple_compradevoWFBindingModel? PagoItem { get; set; }

        public bool BProcessSuccess { get; protected set; }


        public V_pagomultiple_compradevoViewModel(SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(selectorProvider, aggregator, winManager, messageBoxService)
        {
            PagoItem = new V_pagomultiple_compradevoWFBindingModel();
            PagoItem!.PendingChange += CatalogField_PropertyChanging;

            BProcessSuccess = false;
        }


        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                    };


            KendoFilter formaPagoTarjetaFilter = new KendoFilter("Tarjeta", "contains", "nombre", "S");

            KendoParams formaPagoSatParam = new KendoParams(null, null,
                  new KendoFilters(new List<KendoFilter>() { formaPagoTarjetaFilter }, " and "));

            lstCatalogDef = new List<CatalogDef>() {
                new CatalogDef("SatFormaPagoTarjeta",null,null, formaPagoSatParam),
                new CatalogDef("Banco"),
                new CatalogDef("Sat_usocfdi")};

        }


        public void Accept()
        {

            BProcessSuccess = true;


            this.PagoItem!.Montocreditoautomatico = this.PagoItem!.Total -
                                                        ZeroIfNull(this.PagoItem.Montoefectivo) ;

            this.TryCloseAsync();
        }


    }


}


