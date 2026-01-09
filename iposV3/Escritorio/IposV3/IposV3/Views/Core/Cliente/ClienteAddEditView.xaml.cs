
using System;

using Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace IposV3.Views {
    /// <summary>
    ///     Interaction logic for ClienteAddEditWindow.xaml
    /// </summary>
    public partial class ClienteAddEditView {


        Control? controlToFocus;
        bool requiresFocusControl;

        public List<ControlSearchingAutocompleteBindingModel> ListControlFields { get; set; }

        public SfTextBoxExt2? BusquedaCampoControl { get; set; }

        public ClienteAddEditView() {
            InitializeComponent();

            HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            Height = Double.NaN;
            Width = Double.NaN;

            controlToFocus = null;
            requiresFocusControl = false;

            ListControlFields = new();
        }


        [Obsolete]
        public IEnumerable<ControlSearchingAutocompleteBindingModel> LlenarListaCampos(DependencyObject depObj, TabItem? tabItem, string? subgrupo)
        {
            if (depObj == null)
                yield return (ControlSearchingAutocompleteBindingModel)Enumerable.Empty<ControlSearchingAutocompleteBindingModel>();

            TabItem? currentTabItem = tabItem;
            string? currentSubgrupo = subgrupo;

            foreach (object rawChild in LogicalTreeHelper.GetChildren(depObj))
            {
                if (rawChild is DependencyObject)
                {
                    DependencyObject ithChild = (DependencyObject)rawChild;
                    if (ithChild == null) continue;

                    if (ithChild is TabItem t)
                        currentTabItem = t;


                    if (ithChild is TextBlock tb)
                        if (tb.FontWeight == FontWeights.Medium)
                            currentSubgrupo = tb.Text;

                    if (ithChild is Label l)
                    {
                        yield return new ControlSearchingAutocompleteBindingModel(l.Content?.ToString() ?? "-", l.PersistId, currentTabItem, currentSubgrupo);
                    }
                    foreach (ControlSearchingAutocompleteBindingModel childOfChild in LlenarListaCampos(ithChild, currentTabItem, currentSubgrupo)) yield return childOfChild;

                }
            }

        }



        [Obsolete]
        public static IEnumerable<(Control, TabItem?)> NextFocusableControlFromLabel(DependencyObject depObj, int uniqueLabelId, TabItem? tabItem)
        {
            if (depObj == null) yield return ((Control)Enumerable.Empty<Control>(), tabItem);

            bool nowLookForFocusable = false;

            TabItem? currentTabItem = tabItem;

            foreach (object rawChild in LogicalTreeHelper.GetChildren(depObj))
            {
                if (rawChild is DependencyObject)
                {
                    DependencyObject ithChild = (DependencyObject)rawChild;//LogicalTreeHelper.GetChildren(depObj, i);
                    if (ithChild == null) continue;

                    if (ithChild is TabItem t)
                        currentTabItem = t;

                    if (!nowLookForFocusable)
                    {
                        if (ithChild is Label l)
                        {
                            if (l.PersistId == uniqueLabelId)
                            {
                                nowLookForFocusable = true;
                            }
                        }
                        foreach ((Control, TabItem?) childOfChild in NextFocusableControlFromLabel(ithChild, uniqueLabelId, currentTabItem)) yield return childOfChild;
                    }
                    else
                    {
                        if (ithChild is Control)
                        {
                            var controlChild = (Control)ithChild;
                            if (controlChild.Focusable)
                                yield return (controlChild, currentTabItem);
                        }
                    }
                }


            }
        }



        private void TabControl1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (requiresFocusControl && controlToFocus != null)
            {
                requiresFocusControl = false;
                Dispatcher.BeginInvoke((Action)(() =>
                {
                    Keyboard.ClearFocus();
                    controlToFocus.Focus();
                }), System.Windows.Threading.DispatcherPriority.Render);
            }
        }

        [Obsolete]
        private void BusquedaCampo_Loaded(object sender, RoutedEventArgs e)
        {
            BusquedaCampoControl = (SfTextBoxExt2)sender;

            ListControlFields = LlenarListaCampos(this, null, null).ToList() ?? new List<ControlSearchingAutocompleteBindingModel>();
            if (BusquedaCampoControl != null)
            {
                BusquedaCampoControl.AutoCompleteSource = ListControlFields;
            }
        }


        [Obsolete]
        private void BusquedaCampo_SelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            if (BusquedaCampoControl!.SelectedItem != null)
            {
                var itemSelected = (ControlSearchingAutocompleteBindingModel)BusquedaCampoControl!.SelectedItem;
                if (itemSelected == null || itemSelected.Id == null)
                    return;

                var controlsTabItems = NextFocusableControlFromLabel(this, itemSelected!.Id!.Value, itemSelected!.TabItem);
                if (controlsTabItems != null && controlsTabItems.Count() > 0)
                {

                    controlToFocus = controlsTabItems.First()!.Item1!;

                    var newTabItemSelected = controlsTabItems.First().Item2;

                    if (newTabItemSelected != null && controlToFocus != null)
                    {

                        if (newTabItemSelected.IsSelected)
                        {

                            Dispatcher.BeginInvoke((Action)(() =>
                            {
                                Keyboard.ClearFocus();
                                controlToFocus.Focus();
                            }), System.Windows.Threading.DispatcherPriority.Render);
                        }
                        else
                        {

                            requiresFocusControl = true;
                            Dispatcher.BeginInvoke((Action)(() =>
                            {
                                controlsTabItems.First()!.Item2!.IsSelected = true;
                                controlsTabItems.First()!.Item2!.Focus();
                            }));
                        }


                    }

                    BusquedaCampoControl!.SelectedItem = null;
                    return;
                }
            }
        }
    }
}
