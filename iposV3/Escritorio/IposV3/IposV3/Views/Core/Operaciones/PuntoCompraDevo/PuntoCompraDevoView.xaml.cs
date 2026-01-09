using BindingModels;
using Caliburn.Micro;
using IposV3.ViewModels.core.operaciones.puntocompra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Threading;

namespace IposV3.Views
{
    /// <summary>
    /// Interaction logic for PuntoCompraDevoView.xaml
    /// </summary>
    public partial class PuntoCompraDevoView : UserControl, IHandle<PuntoCompraUICommParams>, IHandle<TicketHelperInfo>
    {
        public PuntoCompraDevoView()
        {
            InitializeComponent();
        }



        public Task HandleAsync(PuntoCompraUICommParams parameters, CancellationToken cancellationToken)
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



        public Task HandleAsync(TicketHelperInfo message, CancellationToken cancellationToken)
        {
            //IposV3.impresion.TicketHelper.PrintTicketFromTemplateAndData(helperInfo);
            return Task.CompletedTask;
        }

        public bool SetFocus(string property)
        {
            var view = this;
            if (view != null)
            {
                switch (property)
                {
                    case "CurrentMovto.Cantidad":
                        {
                            this.P_cantidad.Focus();
                            break;
                        }
                    case "Cajas":
                        {
                            this.P_cajas.Focus();
                            break;
                        }
                    case "CurrentMovto.Precio":
                        {
                            this.P_precio.Focus();
                            break;
                        }
                    case "CurrentMovto.Descuentoporcentaje":
                        {
                            this.P_descuentoporcentaje.Focus();
                            break;
                        }

                    case "CurrentMovto.Productoclave":
                        {
                            this.P_productoclave.Focus();
                            break;
                        }

                    case "P_precioLista":
                        {
                            P_precioLista.SelectedIndex = -1;
                            P_precioLista.SelectedValue = 0;
                            P_precioLista.Focus();
                            break;
                        }



                }
            }
            return false;
        }

        private List<String>? GridViewsColumnSizesConfigurated;
        private void SfTableDataGridView_Loaded(object sender, RoutedEventArgs e)
        {

            var dataGrid = (Syncfusion.UI.Xaml.Grid.SfDataGrid)sender;

            if (GridViewsColumnSizesConfigurated == null)
                GridViewsColumnSizesConfigurated = new List<string>();

            if (GridViewsColumnSizesConfigurated.Contains(dataGrid.Name))
                return;

            var percentage = (ActualWidth * (4.0 / 5.0)) / 100.0;
            foreach (var column in dataGrid.Columns)
            {

                column.Width = percentage * column.Width;
            }
            GridViewsColumnSizesConfigurated.Add(dataGrid.Name);
        }



    }
}
