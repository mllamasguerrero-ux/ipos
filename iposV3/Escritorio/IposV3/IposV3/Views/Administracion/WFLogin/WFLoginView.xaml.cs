
using System;
using System.Windows;
using System.Windows.Controls;

namespace IposV3.Views {
    /// <summary>
    ///     Interaction logic for WFLoginWindow.xaml
    /// </summary>
    public partial class WFLoginView {
      
        public WFLoginView() {
            InitializeComponent();

            HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            Height = Double.NaN;
            Width = Double.NaN;
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).WFLoginParam.P_claveacceso = ((PasswordBox)sender).Password; }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            P_username.Focus();
        }
    }
}
