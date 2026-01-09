|||||100+++++
using BindingModels;
using IposV3.Model;
using Caliburn.Micro;
using Controllers;
using Controllers.Controller;
using DataAccess;
using Models.CatalogSelector; 
using IposV3.ViewModels.BaseScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.ViewModels
{

    public class (nombreTabla)WFViewModel : BaseGenericViewModel
    {

        public (nombreTabla)WFBindingModel? (nombreTabla)Item { get; set; }

|||||101+++++
        public List<(nombreTabla)WF_(nombreGrid)BindingModel> (nombreGrid)Items { get; set; }
|||||102+++++|||||103+++++

        public (nombreTabla)WFViewModel(SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(selectorProvider, aggregator, winManager, messageBoxService)
        {
            (nombreTabla)Item = new (nombreTabla)WFBindingModel();
            (nombreTabla)Item!.PendingChange += CatalogField_PropertyChanging;

|||||104+++++
            (nombreGrid)Items = new List<(nombreTabla)WF_(nombreGrid)BindingModel>();
|||||105+++++|||||106+++++
        }


        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>() {|||||109+++++
                                          new CatalogRelatedFields("(nombreTabla)Item","(catalogo)","(nombreCampoCapitalizado)", "(catalogocampoclave)", "(catalogocamponombre)","IposV3.ViewModels.(catalogolistavmname)","(catalogoselectobjectname)","(catalogoselectfieldtname)"),|||||110+++++
                                    };
            lstCatalogDef = new List<CatalogDef>() { |||||115+++++new CatalogDef(
                    "(catalogo)"),|||||120+++++};

        }

    }


}


!!!!!
100;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR
101;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;SI_AGRUPADOR_GRIDIN;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR
102;1;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;SI_AGRUPADO;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR
103;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR
104;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;SI_AGRUPADOR_GRIDIN;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR
105;1;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;SI_AGRUPADO;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR
106;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR
109;1;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;1;IGNORAR;IGNORAR;IGNORAR;SI;IGNORAR;IGNORAR;IGNORAR;IGNORAR;SELECTOR
110;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR
115;1;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;1;IGNORAR;IGNORAR;IGNORAR;SI;IGNORAR;IGNORAR;IGNORAR;IGNORAR;COMBOBOX
120;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR