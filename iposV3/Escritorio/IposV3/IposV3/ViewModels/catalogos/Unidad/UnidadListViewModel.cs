
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Dynamic;
using System.Net.Mime;
using System.Windows;
using System.Windows.Input;
using IposV3.ViewModels.BaseScreen;
using ViewModels.BaseScreen;
using BindingModels;
using Caliburn.Micro;
using Controllers;
using Controllers.Controller;
//using IposV3.Controllers.Controller;
//using DataAccess;
using Models;
using IposV3.Model;
using IposV3.ViewModels;
using RestSharp;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace IposV3.ViewModels
{

    public class UnidadListViewModel : BaseWebListViewModel<UnidadBindingModel, UnidadWebController, UnidadItemVMInitialParameters, UnidadListVMEventParameters, UnidadParam>
    {

        //private UnidadWebController _unidadWebController;

        public UnidadListViewModel(UnidadWebController provider, UsuarioWebController usuarioControllerProvider, SelectorWebController selectorProvider, IWindowManager winManager, IEventAggregator aggregator, IMessageBoxService messageBoxService,
                                   UnidadWebController unidadWebController) :
                            base(provider, usuarioControllerProvider, selectorProvider, winManager, aggregator, messageBoxService, true)
        {
            //_unidadWebController = unidadWebController;
        }



        protected override System.Collections.Generic.List<long> DerechosEstandarToCheck()
        {
            return new System.Collections.Generic.List<long>{ Model.DBValues._DERECHO_UNIDAD_VER,
                                   Model.DBValues._DERECHO_UNIDAD_VER + 1000,
                                   Model.DBValues._DERECHO_UNIDAD_VER + 2000,
                                   Model.DBValues._DERECHO_UNIDAD_VER + 3000                };
        }


        protected override void preconfigureSearchParams()
        {
            KendoParams = new KendoParams("", "Clave | Nombre  ");
            
        }
    
        protected override object EditViewModel()
        {
            return IoC.Get<UnidadEditViewModel>();
        }

        protected override object ShowViewModel()
        {
            return IoC.Get<UnidadShowViewModel>();
        }


        protected override object AddViewModel()
        {
            return IoC.Get<UnidadAddViewModel>();
        }


        //public override void ShowItem(UnidadBindingModel selected)
        //{

        //    var task2 = _unidadWebController.GetById(selected);
        //    Task continuation2 = task2.ContinueWith(t =>
        //    {
        //        Console.WriteLine(t.ToString());
        //    });


        //    base.ShowItem(selected);
        //}


        //public override System.Collections.Generic.List<UnidadBindingModel> DoGetItems()
        //{
        //    if (ListParam == null)
        //        return new List<UnidadBindingModel>();


        //    var task2 = _unidadWebController.SelectList(ListParam, KendoParams);
        //    Task continuation2 = task2.ContinueWith(t =>
        //    {
        //        Console.WriteLine(t.ToString());
        //    });


        //    return base.DoGetItems();
        //}


        //public void Test()
        //{
        //    var client = new RestClient("http://localhost:49165/api");
        //    var strRequest = $"/unidad_/getall";
        //    var request = new RestRequest(strRequest, Method.Post);


        //    var task2 = _unidadWebController.GetAll();
        //    Task continuation2 = task2.ContinueWith(t =>
        //    {
        //        Console.WriteLine(t.ToString());
        //    });


        //    //var taskResponse = client.ExecuteAsync(request);
        //    //RestSharp.RestResponse? response = null;

        //    //Task continuation = taskResponse.ContinueWith(t =>
        //    //{
        //    //    Console.WriteLine(t.Result.Content);
        //    //    response = t.Result;
        //    //});


        //    //if (response?.StatusCode != System.Net.HttpStatusCode.OK)
        //    //    throw new Exception(response?.ErrorMessage ?? "Response es nulo");
        //}
    }
}
