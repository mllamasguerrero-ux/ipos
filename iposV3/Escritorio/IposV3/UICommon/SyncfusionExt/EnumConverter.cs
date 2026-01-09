using Controllers.BindingModel.utils;
using IposV3.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;


namespace Converters
{

    public class EnumShortConverter<T> : MarkupExtension, IValueConverter where T : System.Enum
    {

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return DependencyProperty.UnsetValue;

            return (short)value;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return DependencyProperty.UnsetValue;

            short shortVal;
            bool result = short.TryParse(value.ToString(), out shortVal);
            if (result)
            {
                return (T)Enum.ToObject(typeof(T), shortVal);
            }
            else
            {
                return DependencyProperty.UnsetValue;
            }
        }
    }

    public class ConfigPantallaConverter : EnumShortConverter<ConfigPantalla>{ }
    

    public class FormatTicketCortoConverter : EnumShortConverter<FormatTicketCorto> { }
    public class OrdenImpresionConverter : EnumShortConverter<OrdenImpresion> { }
    public class FormatoFacturaConverter : EnumShortConverter<FormatoFactura> { }
    public class FiltroProductoSatConverter : EnumShortConverter<FiltroProductoSat> { }

    public class ModoAlertaPVConverter : EnumShortConverter<ModoAlertaPV> { }
    public class TipoSyncMovilConverter : EnumShortConverter<TipoSyncMovil> { }
    public class TipoConexionMovilConverter : EnumShortConverter<TipoConexionMovil> { }
}
