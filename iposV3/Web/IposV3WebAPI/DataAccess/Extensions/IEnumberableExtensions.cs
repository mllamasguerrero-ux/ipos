using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.Extensions
{
    public static class IEnumberableExtensions
    {

        public static IEnumerable<T> ToList<T>(this IEnumerable items)
        {
            foreach (object item in items)
            {
                yield return (T)item;
            }
        }
    }
}
