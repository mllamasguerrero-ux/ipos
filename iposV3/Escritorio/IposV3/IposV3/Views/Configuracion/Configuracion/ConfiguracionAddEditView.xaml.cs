
using Caliburn.Micro;
using IposV3.Model;
using System;
using System.Configuration;
using System.Windows.Controls;

namespace IposV3.Views {
    /// <summary>
    ///     Interaction logic for ConfiguracionAddEditWindow.xaml
    /// </summary>
    public partial class ConfiguracionAddEditView : UserControl
    {


        private string? currentString;
        public ConfiguracionAddEditView() {
            InitializeComponent();

            HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            Height = Double.NaN;
            Width = Double.NaN;

        }

        private void Stepper_ContinueNavigation(object sender, MaterialDesignExtensions.Controls.StepperNavigationEventArgs args)
        {
            bool cancelArg = false;
            string currentStepTitle = ((MaterialDesignExtensions.Model.StepTitleHeader)((MaterialDesignExtensions.Model.Step)(args).CurrentStep).Header).FirstLevelTitle;
            string nextStepTitle = (args).NextStep != null ? ((MaterialDesignExtensions.Model.StepTitleHeader)((MaterialDesignExtensions.Model.Step)(args).NextStep).Header).FirstLevelTitle : "";
            var configurationAction = ((IposV3.ViewModels.ConfiguracionItemViewModel)DataContext).ContinueNavigationHandler(currentStepTitle, nextStepTitle, out cancelArg);
            args.Cancel = cancelArg;


            //if (configurationAction.Action == "cambiar_conexion" && configurationAction.Parameters != null)
            //{
            //    ConnectionMgr.ChangeConnectionString(configurationAction.Parameters[0]);
            //    try
            //    {
            //        ((IposV3.ViewModels.ConfiguracionItemViewModel)DataContext).MigrateCurrentDatabase();
            //    }
            //    catch
            //    {
            //        args.Cancel = true;
            //    }
            //}

            //ConnectionMgr.ChangeConnectionString()
            //((IposV3.ViewModels.ConfiguracionItemViewModel)DataContext).MigrateCurrentDatabase();

        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            //currentString = ConnectionMgr.GetConnectionString();
            ((IposV3.ViewModels.ConfiguracionItemViewModel)DataContext).ResguardaCurrentConfiguracion();

        }

        private void UserControl_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {

            //OperationsContextFactory operationsContextFactory = IoC.Get<OperationsContextFactory>();
            //ConnectionMgr.ChangeConnectionString(currentString);
            //((IposV3.ViewModels.ConfiguracionItemViewModel)DataContext).ReponCurrentConfiguracion();


        }

    }
}
