using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace Converters
{
    public class DictionaryItemConverter :  MarkupExtension, IValueConverter
    {
        public object? Convert(object? value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value == null)
                return null;

            var dict = value as Dictionary<string, string> ;
            if (dict != null && (parameter as string) != null)
            { 
                return dict[(parameter as string)!];
            }
            return null;
            //throw new NotImplementedException();
        }

        public object? ConvertBack(object? value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
