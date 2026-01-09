
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
using System.Windows;

namespace IposV3.ViewModels
{

    public class V_pagomultiple_compraViewModel : BaseGenericViewModel
    {



        public bool BIsReadOnly { get; protected set; }

        private V_pagomultiple_compraWFBindingModel? pagoItem;
        public V_pagomultiple_compraWFBindingModel? PagoItem
        {
            get => pagoItem;
            set
            {
                pagoItem = value; NotifyOfPropertyChange("PagoItem");

                if (pagoItem != null)
                {
                    pagoItem.PendingChange += CatalogField_PropertyChanging;
                    pagoItem.PropertyChanged += PagoPropertyChangedEventHandler;
                }
            }
        }


        public bool BProcessSuccess { get; protected set; }


        public V_pagomultiple_compraViewModel(SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(selectorProvider, aggregator, winManager, messageBoxService)
        {
            PagoItem = new V_pagomultiple_compraWFBindingModel();
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



        protected void PagoPropertyChangedEventHandler(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Montoefectivo":
                case "Montotarjeta":
                case "Montocheque":
                case "Montotransferencia":
                    this.PagoItem!.Restante = this.PagoItem!.Total -
                                                        ZeroIfNull(this.PagoItem.Montoefectivo) -
                                                        ZeroIfNull(this.PagoItem.Montotarjeta) -
                                                        ZeroIfNull(this.PagoItem.Montocheque) -
                                                        ZeroIfNull(this.PagoItem.Montotransferencia);
                    break;

                default:
                    break;
            }
        }

        public void Accept()
        {

            BProcessSuccess = true;

            if(this.PagoItem!.Montotarjeta > 0 && 
                (this.PagoItem!.Tipotarjeta == null || this.PagoItem!.Bancotarjetaid == null))
            {
                MessageBox.Show("Necesita definir el tipo de tarjeta y el banco");
                return;
            }

            if (this.PagoItem!.Montocheque > 0 &&
                (string.IsNullOrEmpty(this.PagoItem!.Referenciacheque) || this.PagoItem!.Bancochequeid == null))
            {
                MessageBox.Show("Necesita definir la referencia del cheque y el banco");
                return;
            }


            this.PagoItem!.Montocredito = this.PagoItem!.Total -
                                                        ZeroIfNull(this.PagoItem.Montoefectivo) -
                                                        ZeroIfNull(this.PagoItem.Montotarjeta) -
                                                        ZeroIfNull(this.PagoItem.Montocheque) -
                                                        ZeroIfNull(this.PagoItem.Montotransferencia);

            this.TryCloseAsync();
        }


    }


}


