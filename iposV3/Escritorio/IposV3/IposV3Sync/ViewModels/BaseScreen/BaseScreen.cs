using Caliburn.Micro;
using Controllers.BindingModel;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Runtime.CompilerServices;
using IposV3Sync.ViewModels;
using System.Reflection.Metadata;
using BindingModels;
using IposV3.Model;
using Models.CatalogSelector;
using Controllers.Controller;
using IposV3Sync.Controllers.Controller;
using ViewModels.BaseScreen;

namespace IposV3Sync.ViewModels.BaseScreen
{
    public class BaseScreen : Screen
    {

        protected List<CatalogRelatedFields>? catalogRelatedFields;
        protected SelectorController selectorProvider;

        public Dictionary<string, List<BaseSelector>?>? Catalogs { get; protected set; }
        protected List<CatalogDef>? lstCatalogDef;

        protected List<CatalogRelatedFields>? lstCatalogRelatedFieldsInProcess;


        protected readonly IWindowManager winManager;

        public IMainWindowCommProvider? MainWindowCommProvider { get; set; }

        public MessageToUser MessageToUser { get; set; }
        public IMessageBoxService messageBoxService;


        private bool isBusy;
        public bool IsBusy
        {
            get
            {
                return isBusy;
            }
            set
            {
                isBusy = value;
                Opacity = isBusy ? 0.5 : 1.0;
                NotifyOfPropertyChange("IsBusy");

            }
        }

        private double opacity;
        public double Opacity
        {
            get
            {
                return opacity;
            }
            set
            {
                opacity = value;
                NotifyOfPropertyChange("Opacity");
            }
        }


        private Dictionary<long, bool>? derechosUsuario;

        public Dictionary<long, bool>? DerechosUsuario
        {
            get { return derechosUsuario; }
            set { derechosUsuario = value; }
        }

        public BaseScreen(SelectorWebController selectorProvider, IWindowManager winManager, IMessageBoxService messageBoxService)
        {
            this.winManager = winManager;
            this.selectorProvider = selectorProvider;
            IsBusy = false;

            this.messageBoxService = messageBoxService;
            MessageToUser = new MessageToUser("titulo", "este es un mensaje", "Information", false);


            lstCatalogRelatedFieldsInProcess = new List<CatalogRelatedFields>();
        }




        public bool CatalogValueChanged(string? strCatalogo, string? strClave, out string strNombre, out long lId, out string strRealClave)
        {

            strNombre = "";
            lId = 0;
            strRealClave = strClave ?? "";

            if (strCatalogo == null || strClave == null)
                return false;

            var catalogItem = selectorProvider.obtainItemByClave(strCatalogo, strClave, new BaseParam(GlobalVariable.CurrentSession?.Empresaid, GlobalVariable.CurrentSession?.Sucursalid));
            var bRetorno = false;


            if (catalogItem != null && catalogItem.Id != null)
            {
                strNombre = catalogItem.Nombre ?? "";
                lId = catalogItem.Id.Value;
                strRealClave = catalogItem.Clave ?? "";
                bRetorno = true;
            }
            return bRetorno;
        }


        public bool CatalogValueChangedById(string? strCatalogo, long? lId, out string strNombre, out string strClave, out long? realId)
        {


            strNombre = "";
            strClave = "";
            realId = null;

            if (lId == null || !lId.HasValue || strCatalogo == null)
                return false;

            var catalogItem = selectorProvider.obtainItemById(strCatalogo, lId.Value, new BaseParam(GlobalVariable.CurrentSession?.Empresaid, GlobalVariable.CurrentSession?.Sucursalid));
            var bRetorno = false;


            if (catalogItem != null && catalogItem.Id != null)
            {
                strNombre = catalogItem.Nombre ?? "";
                realId = catalogItem.Id.Value;
                strClave = catalogItem.Clave ?? "";
                bRetorno = true;
            }
            return bRetorno;
        }



        public void CatalogField_PropertyChanging(object? sender, AcceptPendingChangeEventArgs e)
        {


            var catalogRelated = this.catalogRelatedFields?.Where(x => x.ClaveField == e.PropertyName || x.IdField == e.PropertyName).FirstOrDefault();
            if (catalogRelated == null)
                return;


            object? objectProperty = catalogRelated!.ObjectName == null ? null : GetType()?.GetProperty(catalogRelated!.ObjectName)?.GetValue(this);

            string? catalogRelatedBy = null;

            catalogRelated = this.catalogRelatedFields?.Where(x => x.ClaveField == e.PropertyName && Object.ReferenceEquals(objectProperty, sender)).FirstOrDefault();
            if (catalogRelated != null)
            {
                catalogRelatedBy = "byClave";
            }

            if (catalogRelatedBy == null)
            {

                catalogRelated = this.catalogRelatedFields?.Where(x => x.IdField == e.PropertyName && Object.ReferenceEquals(objectProperty, sender)).FirstOrDefault();
                if (catalogRelated != null)
                {
                    catalogRelatedBy = "byId";
                }
            }

            if (catalogRelated == null || catalogRelatedBy == null)
                return;




            if (lstCatalogRelatedFieldsInProcess?.Where(x => (x.ClaveField == e.PropertyName || x.IdField == e.PropertyName) && Object.ReferenceEquals(objectProperty, sender)).FirstOrDefault() != null)
            {
                return;
            }


            try
            {
                lstCatalogRelatedFieldsInProcess?.Add(catalogRelated!);

                switch (catalogRelatedBy)
                {
                    case "byClave":
                        {

                            if ((e.NewValue == DBNull.Value ? "" : (string)e.NewValue) == (e.OldValue == DBNull.Value ? "" : (string)e.OldValue))
                                return;

                            string strNombre = "";
                            long lId = 0;
                            string valueClave = (e.NewValue == DBNull.Value ? "" : (string)e.NewValue);//(string)(objectProperty.GetType().GetProperty(e.PropertyName).GetValue(objectProperty, null));
                            string strRealClave = "";
                            CatalogValueChanged(catalogRelated!.CatalogName, valueClave, out strNombre, out lId, out strRealClave);

                            if (lId > 0 && strRealClave != null && !strRealClave.Equals(valueClave))
                            {

                                if(catalogRelated!.ClaveField != null)
                                    objectProperty?.GetType()?.GetProperty(catalogRelated!.ClaveField)?.SetValue(objectProperty, strRealClave);
                                
                                e.CancelPendingChange = true;

                            }

                            //object boxedObject = RuntimeHelpers.GetObjectValue(objectProperty);

                            if (catalogRelated!.NombreField != null)
                                objectProperty?.GetType()?.GetProperty(catalogRelated!.NombreField)?.SetValue(objectProperty, strNombre);
                            
                            if (catalogRelated!.IdField != null)
                                objectProperty?.GetType()?.GetProperty(catalogRelated!.IdField)?.SetValue(objectProperty, lId);
                            //boxedObject.GetType().GetProperty(catalogRelated.IdField).SetValue(objectProperty, lId);



                            if (catalogRelated.MostrarPopUpIfNorFound && lId == 0 && valueClave != null && valueClave.Trim().Length > 0)
                            {
                                if (ShowPopUpSelectorCatalogRelated(catalogRelated, valueClave))
                                    e.CancelPendingChange = true;
                            }

                            if (!e.CancelPendingChange)
                            {
                                AfterCatalogFieldChanging(catalogRelated, lId, strRealClave!, strNombre);
                            }
                        }
                        break;

                    case "byId":
                        {

                            if ((long?)(e.NewValue != DBNull.Value ? e.NewValue : null) == (long?)(e.OldValue != DBNull.Value ? e.OldValue : null))
                                return;

                            string strNombre = "";
                            long? realId = 0;
                            long? lIdValue = (long?)e.NewValue;//(string)(objectProperty.GetType().GetProperty(e.PropertyName).GetValue(objectProperty, null));
                            string strClave = "";
                            CatalogValueChangedById(catalogRelated!.CatalogName, lIdValue, out strNombre, out strClave, out realId);


                            if (lIdValue != null && lIdValue != 0 && (realId == null || !realId.HasValue))
                            {
                                e.CancelPendingChange = true;
                            }

                            if(catalogRelated!.NombreField != null)
                                objectProperty?.GetType()?.GetProperty(catalogRelated!.NombreField)?.SetValue(objectProperty, strNombre == null ? "" : strNombre);

                            if (catalogRelated!.ClaveField != null)
                                objectProperty?.GetType()?.GetProperty(catalogRelated!.ClaveField)?.SetValue(objectProperty, strClave == null ? "" : strClave);
                            //objectProperty.GetType().GetProperty(catalogRelated.IdField).SetValue(objectProperty, lId);




                            if (!e.CancelPendingChange)
                            {
                                AfterCatalogFieldChanging(catalogRelated, lIdValue == null ? 0 : lIdValue.Value, strClave ?? "", strNombre ?? "");
                            }
                        }
                        break;

                    default:
                        break;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {

                lstCatalogRelatedFieldsInProcess?.RemoveAll(x => (x.ClaveField == e.PropertyName || x.IdField == e.PropertyName) && Object.ReferenceEquals(objectProperty, sender));
            }






        }


        protected virtual void AfterCatalogFieldChanging(CatalogRelatedFields catalogRelated, long lId, string strClave, string strNombre)
        {

        }




        protected decimal ZeroIfNull(decimal? monto)
        {
            return monto != null && monto.HasValue ? monto.Value : 0.0m;

        }



        public void ShowPopUpSelector(string catalogClaveField)
        {

            var catalogRelated = this.catalogRelatedFields?.Where(x => x.ClaveField == catalogClaveField).FirstOrDefault();

            if(catalogRelated != null)
                ShowPopUpSelectorCatalogRelated(catalogRelated);



        }




        public bool ShowPopUpSelectorCatalogRelated(CatalogRelatedFields catalogRelated, string? textSearch = null)
        {

            if (catalogRelated.ListVMName == null)
                return false;

            MethodInfo? openGenericMethod = typeof(IoC).GetMethod("Get");
            var type = Assembly.GetExecutingAssembly().GetType(catalogRelated.ListVMName);

            if (type == null)
                return false;

            MethodInfo? closedGenericMethod = openGenericMethod!.MakeGenericMethod(type!);


            object? rootModel = closedGenericMethod.Invoke(null, new object?[] { null });
            try
            {
                if (type!.GetProperty("IsSelectionMode") != null)
                {

                    type!.GetProperty("IsSelectionMode")?.SetValue(rootModel, true);
                    type!.GetProperty("AllowAdd")?.SetValue(rootModel, false);
                    type!.GetProperty("AllowEdit")?.SetValue(rootModel, false);
                    type!.GetProperty("AllowShow")?.SetValue(rootModel, false);
                }
            }
            catch { }

            if (catalogRelated.ListVMName == "IposV3Sync.ViewModels.Catalogo_genericoListViewModel")
            {
                //((Catalogo_genericoListViewModel)rootModel).CatalogTable = catalogRelated.ListTable;
                //((Catalogo_genericoListViewModel)rootModel).CatalogTitle = catalogRelated.ListTitle;
            }



            if (catalogRelated.KendoParams != null)
            {
                rootModel!.GetType()?.GetProperty("KendoParams")?.SetValue(rootModel, catalogRelated.KendoParams);
            }


            if (textSearch != null)
            {
                var kendoParams = (KendoParams?)rootModel!.GetType()?.GetProperty("KendoParams")?.GetValue(rootModel);
                if(kendoParams?.GeneralFilter != null)
                    kendoParams!.GeneralFilter!.Value = textSearch;
                rootModel!.GetType()?.GetProperty("KendoParams")?.SetValue(rootModel, kendoParams);

            }

            winManager.ShowDialogAsync(rootModel, null, CreateWinSettings(catalogRelated.CatalogName ?? "", 0.45, 0.65));

            if(catalogRelated!.ListVMSelectingObjectName == null)
                return false;

            object? selectedItem = rootModel!.GetType()?.GetProperty(catalogRelated!.ListVMSelectingObjectName)?.GetValue(rootModel);
            if (selectedItem != null)
            {
                object? objectProperty = null ;
                string? strClave = null;

                if(catalogRelated.ObjectName != null)
                    objectProperty = GetType()?.GetProperty(catalogRelated.ObjectName)?.GetValue(this);

                if(catalogRelated.ListVMSelectingFieldClaveName != null)
                strClave = (string?)selectedItem.GetType().GetProperty(catalogRelated.ListVMSelectingFieldClaveName)?.GetValue(selectedItem);

                if (catalogRelated.ClaveField != null)
                {
                    objectProperty?.GetType()?.GetProperty(catalogRelated.ClaveField)?.SetValue(objectProperty, strClave);
                }


                if (textSearch != null)
                    textSearch = strClave;

                try
                {
                    if (catalogRelated.ListVMSelectingFieldNombreName != null && catalogRelated.ListVMSelectingFieldNombreName.Length > 0 &&
                        catalogRelated.NombreField != null)
                    {
                        string? strNombre = (string?)selectedItem.GetType().GetProperty(catalogRelated.ListVMSelectingFieldNombreName)?.GetValue(selectedItem);
                        objectProperty?.GetType()?.GetProperty(catalogRelated.NombreField)?.SetValue(objectProperty, strNombre);
                    }
                }
                catch { 
                    if (catalogRelated.NombreField != null)
                        objectProperty?.GetType()?.GetProperty(catalogRelated.NombreField)?.SetValue(objectProperty, strClave); 
                }


            }

            return selectedItem != null;

        }



        public void showPopUpMessage(string title, string message, string tipo)
        {

            MessageToUser.Message = message;
            MessageToUser.Title = title;
            MessageToUser.Tipo = tipo;
            MessageToUser.IsOpen = true;
        }


        public void showPopUpMessage(MessageToUserSimple msg)
        {
            if (msg != null)
            {

                showPopUpMessage(msg.Title, msg.Message, msg.Tipo);
            }
        }

        public void hidePopUpMessage()
        {
            MessageToUser.IsOpen = false;
        }

        public bool ShowSiNoMessageBox(string text, string caption)
        {
            return messageBoxService.ShowSiNoMessage(text, caption, MessageType.information);
        }

        protected dynamic CreateWinSettings(string strTitle, double sizePercentage)
        {

            return CreateWinSettings(strTitle, sizePercentage, sizePercentage);
        }

        protected dynamic CreateWinSettings(string strTitle, double sizePercentageWidth, double sizePercentageHeight)
        {

            dynamic settings = new ExpandoObject();
            settings.WindowStyle = WindowStyle.ThreeDBorderWindow;
            settings.ShowInTaskbar = true;
            settings.Title = strTitle;
            settings.WindowState = WindowState.Normal;
            settings.ResizeMode = ResizeMode.CanResize;
            settings.SizeToContent = System.Windows.SizeToContent.Manual;
            settings.Width = SystemParameters.PrimaryScreenWidth * sizePercentageWidth;
            settings.Height = SystemParameters.PrimaryScreenHeight * sizePercentageHeight;

            return settings;
        }
    }



}