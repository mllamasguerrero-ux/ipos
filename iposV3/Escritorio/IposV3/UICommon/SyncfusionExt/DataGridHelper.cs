using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Converters
{
    public class DataGridHelper : DependencyObject
    {

        public static string GetHidableColumnIndices(DependencyObject attachingElement) => (string)attachingElement.GetValue(HidableColumnIndicesProperty);
        public static void SetHidableColumnIndices(DependencyObject attachingElement, string value) => attachingElement.SetValue(HidableColumnIndicesProperty, value);

        public static readonly DependencyProperty HidableColumnIndicesProperty = DependencyProperty.RegisterAttached(
            "HidableColumnIndices",
            typeof(string),
            typeof(DataGridHelper),
            new PropertyMetadata(default(string), OnHidableColumnIndicesChanged));


        private static void OnHidableColumnIndicesChanged(DependencyObject attachingElement, DependencyPropertyChangedEventArgs e)
        {
            if (attachingElement is not SfDataGrid dataGrid)
            {
                throw new ArgumentException("Attaching element must be of type DataGrid.");
            }



            ToggleColumnVisibility(dataGrid);
        }

        private static void ToggleColumnVisibility(SfDataGrid dataGrid)
        {

            IEnumerable<string> hiddenColumns = GetHidableColumnIndices(dataGrid)
              .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            IEnumerable<string> hiddenColumnNames = hiddenColumns.Where(y => !int.TryParse(y, out _)).ToList();
            IEnumerable<string> hiddenColumnIndexes = hiddenColumns.Where(y => int.TryParse(y, out _)).ToList();


            for (int columnIndex = 0; columnIndex < dataGrid.Columns.Count; columnIndex++) 
            {

                var mappingColumnName = dataGrid.Columns[columnIndex].MappingName;


                if (hiddenColumnIndexes.Contains(columnIndex.ToString()) ||
                    (mappingColumnName != null && hiddenColumnNames.Contains(mappingColumnName)))
                {
                    dataGrid.Columns[columnIndex].Width = 0;
                    dataGrid.Columns[columnIndex].MinimumWidth = 0;
                }
                //else if(mappingColumnName != null)
                //{
                //    dataGrid.Columns[columnIndex].Width = Double.NaN;
                //    dataGrid.Columns[columnIndex].MinimumWidth = Double.NaN;
                //}

            }
        }
    }
}
