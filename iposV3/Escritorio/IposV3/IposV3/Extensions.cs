using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.Services.ExtensionsLocal
{
    static class Extensions
    {

        public static bool In<T>(this T item, params T[] items)
        {
            if (items == null)
                throw new ArgumentNullException("items");

            return items.Contains(item);
        }

    }



    public static class DateTimeExtension
    {
        //
        // Summary:
        //     Returns the DateTime of the given object
        //
        // Parameters:
        //   dateTime:
        //     date time value
        //
        // Returns:
        //     Returns the DateTime of the given object
        public static DateTime ToDateTime(this object dateTime)
        {
            DateTime.TryParse(dateTime.ToString(), out var result);
            return result;
        }
    }

}
