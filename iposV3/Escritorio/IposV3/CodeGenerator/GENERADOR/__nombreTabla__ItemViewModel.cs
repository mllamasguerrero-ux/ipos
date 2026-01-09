|||||100+++++
using BindingModels;
using IposV3.Model;
using Caliburn.Micro;
using Controllers;
using Controllers.Controller;
using IposV3.Controllers.Controller;
using DataAccess;
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

    public class (nombreTabla)ItemViewModel : BaseWebRecordViewModel<(nombreTabla)BindingModel, (nombreTabla)Controller, (nombreTabla)ItemVMInitialParameters, (nombreTabla)ListVMEventParameters>
    {

        public (nombreTabla)BindingModel? (nombreTabla) { get { return Record; } set { Record = value; } }
        public (nombreTabla)ItemViewModel(string mode, (nombreTabla)Controller provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(mode, provider, selectorProvider, aggregator, winManager, messageBoxService)
        {

        }


|||||101+++++
        protected override void preFillRecordToAdd()
        {

            (nombreTabla)BindingModel rec = new (nombreTabla)BindingModel();
            rec.Creadopor_userid = long.Parse(ConfigurationManager.AppSettings.Get("itemUserIdForEditing"));
            rec.Empresaid = 0;
            rec.Sucursalid = 0;

            Record = rec;
        }


        protected override void fillRecordToEdit((nombreTabla)ItemVMInitialParameters initialParameters)
        {

            (nombreTabla)BindingModel item = new (nombreTabla)BindingModel();

            item.Id = initialParameters.Id;
            item.Sucursalid = 0;
            item.Empresaid = 0;
            Record = provider.GetById(item);

            if (Record == null)
                Record = new (nombreTabla)BindingModel();

        }
|||||102+++++

        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>() {|||||105+++++
                                          new CatalogRelatedFields("(nombreTabla)","(catalogo)","(nombreCampoCapitalizado)", "(catalogocampoclave)", "(catalogocamponombre)","IposV3.ViewModels.(catalogolistavmname)","(catalogoselectobjectname)","(catalogoselectfieldtname)"),|||||110+++++
                                    };
            lstCatalogDef = new List<CatalogDef>();
            |||||115+++++
            if (!lstCatalogDef.Any(y => y.CatalogName == "(catalogo)"))
                lstCatalogDef.Add(new CatalogDef("(catalogo)"));  |||||120+++++

        }

    }


    public class (nombreTabla)ShowViewModel : (nombreTabla)ItemViewModel
    {
        public (nombreTabla)ShowViewModel((nombreTabla)Controller provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Show", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class (nombreTabla)EditViewModel : (nombreTabla)ItemViewModel
    {
        public (nombreTabla)EditViewModel((nombreTabla)Controller provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Edit", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class (nombreTabla)AddViewModel : (nombreTabla)ItemViewModel
    {
        public (nombreTabla)AddViewModel((nombreTabla)Controller provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Add", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

}


!!!!!
100;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR
101;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;SI
102;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR
105;1;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;1;IGNORAR;IGNORAR;IGNORAR;SI;IGNORAR;IGNORAR;IGNORAR;IGNORAR;SELECTOR
110;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR
115;1;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;1;IGNORAR;IGNORAR;IGNORAR;SI;IGNORAR;IGNORAR;IGNORAR;IGNORAR;COMBOBOX
120;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR