
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
using IposV3.Services.ExtensionsLocal;

namespace IposV3.ViewModels
{

    public class EncargadoguiaItemViewModel : BaseWebRecordViewModel<UsuarioBindingModel, UsuarioWebController, UsuarioItemVMInitialParameters, UsuarioListVMEventParameters>
    {

        public UsuarioBindingModel? Usuario { get { return Record; } set { Record = value; } }
        public EncargadoguiaItemViewModel(string mode, UsuarioWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(mode, provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }




        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                          new CatalogRelatedFields("Usuario","Grupousuario","Usuario_Preferencias_Grupousuarioid", "Usuario_Preferencias_GrupousuarioClave", "Usuario_Preferencias_GrupousuarioNombre","IposV3.ViewModels.GrupousuarioListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Usuario","Almacen","Usuario_Preferencias_Almacenid", "Usuario_Preferencias_AlmacenClave", "Usuario_Preferencias_AlmacenNombre","IposV3.ViewModels.AlmacenListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Usuario","Sat_pais","Usuario_fact_elect_Sat_id_pais", "Usuario_fact_elect_Sat_paisClave", "Usuario_fact_elect_Sat_paisNombre","IposV3.ViewModels.Sat_paisListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Usuario","Sat_colonia","Usuario_fact_elect_Sat_Coloniaid", "Usuario_fact_elect_Sat_ColoniaClave", "Usuario_fact_elect_Sat_ColoniaNombre","IposV3.ViewModels.Sat_coloniaListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Usuario","Sat_localidad","Usuario_fact_elect_Sat_Localidadid", "Usuario_fact_elect_Sat_LocalidadClave", "Usuario_fact_elect_Sat_LocalidadNombre","IposV3.ViewModels.Sat_localidadListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Usuario","Sat_municipio","Usuario_fact_elect_Sat_Municipioid", "Usuario_fact_elect_Sat_MunicipioClave", "Usuario_fact_elect_Sat_MunicipioNombre","IposV3.ViewModels.Sat_municipioListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Usuario","Estadopais","Usuario_fact_elect_Estadoid", "Usuario_fact_elect_EstadoClave", "Usuario_fact_elect_EstadoNombre","IposV3.ViewModels.EstadopaisListViewModel","SelectedItem","Clave")
                                    };
            lstCatalogDef = new List<CatalogDef>();
            
            if (!lstCatalogDef.Any(y => y.CatalogName == "Saludo"))
                lstCatalogDef.Add(new CatalogDef("Saludo"));  
            if (!lstCatalogDef.Any(y => y.CatalogName == "Tipoprecio"))
                lstCatalogDef.Add(new CatalogDef("Tipoprecio"));

            if (!lstCatalogDef.Any(y => y.CatalogName == "Sat_figuratransporte"))
                lstCatalogDef.Add(new CatalogDef("Sat_figuratransporte"));
            if (!lstCatalogDef.Any(y => y.CatalogName == "Sat_partetransporte"))
                lstCatalogDef.Add(new CatalogDef("Sat_partetransporte"));
            if (!lstCatalogDef.Any(y => y.CatalogName == "Estadopais"))
                lstCatalogDef.Add(new CatalogDef("Estadopais"));

        }


        public override void ShowPopUpSelector(string catalogClaveField)
        {

            if (!catalogClaveField.In(new string[] { "Usuario_fact_elect_Sat_ColoniaClave" , "Usuario_fact_elect_Sat_LocalidadClave", "Usuario_fact_elect_Sat_MunicipioClave"}))
            {
                base.ShowPopUpSelector(catalogClaveField);
                return;
            }

            var catalogRelated = this.catalogRelatedFields?.Where(x => x.ClaveField == catalogClaveField).FirstOrDefault();

            Dictionary<string, object?> specialProperties = new Dictionary<string, object?>();

            if (Record?.Domicilio_Codigopostal != null && Record?.Domicilio_Codigopostal.Length > 0 &&
                (catalogClaveField == "Usuario_fact_elect_Sat_ColoniaClave"))
                specialProperties.Add("Codigopostal", Record?.Domicilio_Codigopostal);


            if (Record!.Usuario_fact_elect_EstadoClave != null && Record?.Usuario_fact_elect_EstadoClave.Length > 0 &&
                (catalogClaveField == "Usuario_fact_elect_Sat_LocalidadClave" || catalogClaveField == "Usuario_fact_elect_Sat_MunicipioClave"))
            {
                var estadoSeleccionado = Catalogs?["Estadopais"]?.FirstOrDefault(x => x.Clave == Record!.Usuario_fact_elect_EstadoClave);

                if (estadoSeleccionado != null && estadoSeleccionado.Texto1 != null)
                {
                    specialProperties.Add("Clave_estado", estadoSeleccionado.Texto1);
                }
            }





            if (catalogRelated != null)
                ShowPopUpSelectorCatalogRelated(catalogRelated, null, specialProperties);

        }



        public override void AcceptAdd()
        {
            if(Record != null)
                Record.Esencargadoguia = BoolCN.S;

            base.AcceptAdd();
        }

    }


    public class EncargadoguiaShowViewModel : EncargadoguiaItemViewModel
    {
        public EncargadoguiaShowViewModel(UsuarioWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Show", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class EncargadoguiaEditViewModel : EncargadoguiaItemViewModel
    {
        public EncargadoguiaEditViewModel(UsuarioWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Edit", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class EncargadoguiaAddViewModel : EncargadoguiaItemViewModel
    {
        public EncargadoguiaAddViewModel(UsuarioWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Add", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

}


