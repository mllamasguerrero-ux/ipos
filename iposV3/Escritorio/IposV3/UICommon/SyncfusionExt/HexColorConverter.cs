using Controllers.BindingModel.utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Converters
{
    public class HexColorConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var hexColor = (value as IRecordColor)?.hexRecordColor();

            //custom condition is checked based on data.

            if (hexColor != null && hexColor.Length > 0)
                return new BrushConverter().ConvertFrom(hexColor) as SolidColorBrush ?? DependencyProperty.UnsetValue;
            else
                return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    public class HexTextColorConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var hexColor = (value as IRecordColor)?.hexTextRecordColor();

            //custom condition is checked based on data.

            if (hexColor != null && hexColor.Length > 0)
                return new BrushConverter().ConvertFrom(hexColor) as SolidColorBrush ?? DependencyProperty.UnsetValue;
            else
                return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
