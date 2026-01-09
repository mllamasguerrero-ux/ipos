
using System;
using System.Windows.Controls;

namespace IposV3Sync.Views {
    /// <summary>
    ///     Interaction logic for ConfiguracionsyncAddEditWindow.xaml
    /// </summary>
    public partial class ConfiguracionsyncAddEditView {
      
        public ConfiguracionsyncAddEditView() {
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


            var configurationAction = ((IposV3Sync.ViewModels.ConfiguracionsyncItemViewModel)DataContext).ContinueNavigationHandler(currentStepTitle, nextStepTitle, out cancelArg);
            args.Cancel = cancelArg;
            if (configurationAction != null && configurationAction.Parameters != null && 
                configurationAction.Action == "cambiar_conexion")
            {
                ConnectionMgr.ChangeConnectionString(configurationAction.Parameters[0]);
            }
            ((IposV3Sync.ViewModels.ConfiguracionsyncItemViewModel)DataContext).fillCatalogAfterStep(currentStepTitle);

        }

        private void StartSync_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ((IposV3Sync.ViewModels.ConfiguracionsyncEditViewModel)DataContext).StartSync();
        }
    }
}
