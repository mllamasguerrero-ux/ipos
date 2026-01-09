using Controllers.BindingModel.utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Converters
{
    public class ValidationErrorConverter : MarkupExtension, IValueConverter
    {

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ValidationError[]? array = value as ValidationError[];
            int index = System.Convert.ToInt32(parameter);
            if (array?.Length <= index)
                return "";
            return array?[index].ErrorContent ?? "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
