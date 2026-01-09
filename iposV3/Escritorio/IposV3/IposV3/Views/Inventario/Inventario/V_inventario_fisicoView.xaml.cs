
using Caliburn.Micro;
using IposV3.ViewModels;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace IposV3.Views {
    /// <summary>
    ///     Interaction logic for Fnc_inv_movto_insertAddEditWindow.xaml
    /// </summary>
    public partial class V_inventario_fisicoView : UserControl, IHandle<V_inventario_fisicoUICommParams>
    {
      
        public V_inventario_fisicoView() {
            InitializeComponent();

            HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            Height = Double.NaN;
            Width = Double.NaN;
        }



        public Task HandleAsync(V_inventario_fisicoUICommParams parameters, CancellationToken cancellationToken)
        {
            switch (parameters.Action)
            {
                case "SetFocus":
                    {
                        if (parameters.Parameters != null && parameters.Parameters.Count > 0)
                        {
                            SetFocus(parameters.Parameters[0]);
                        }
                    }
                    break;
                default: break;
            }

            return Task.CompletedTask;
        }

        public bool SetFocus(string property)
        {
            var view = this;
            if (view != null)
            {
                switch (property)
                {
                    case "Fnc_inv_movto_insertParam.P_cantidad":
                        {
                            this.Cantidad.Focus();
                            break;
                        }
                    case "Cajas":
                        {
                            this.Cajas.Focus();
                            break;
                        }

                    //case "Fnc_inv_movto_insertParam.Productoclave":
                    //    {
                    //        this.Productoclave.Focus();
                    //        break;
                    //    }



                }
            }
            return false;
        }


        private void OnPreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (MenuConfig.IsKeyboardFocusWithin)
            {
                e.Handled = true;
            }
        }
    }
}
