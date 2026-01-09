
using System;

namespace IposV3Sync.Views {
    /// <summary>
    ///     Interaction logic for MainView.xaml
    /// </summary>
    public partial class TablasAReplicarWFView {
        public TablasAReplicarWFView() {
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


            var action = ((IposV3Sync.ViewModels.TablasAReplicarWFViewModel)DataContext).ContinueNavigationHandler(currentStepTitle, nextStepTitle, out cancelArg);
            args.Cancel = cancelArg;
            if (action.Action == "cambiar_conexion")
            {
                //ConnectionMgr.ChangeConnectionString(configurationAction.Parameters[0]);
            }
            // ((IposSyncV2.ViewModels.ConfiguracionsyncItemViewModel)DataContext).fillCatalogAfterStep(currentStepTitle);

        }

        private void AddItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}

