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
    public class DateTimeOffsetToDateTimeConverter : MarkupExtension, IValueConverter
    {
        public object? Convert(object? value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTimeOffset? dto = (DateTimeOffset?)value;
            return dto?.DateTime;
        }

        public object? ConvertBack(object? value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime? date = (DateTime?)value;
            
            return date == null ? (DateTimeOffset?)null: new DateTimeOffset(date!.Value);
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}