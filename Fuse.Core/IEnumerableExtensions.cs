using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuse.Common
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (T item in enumeration)
            {
                action(item);
                yield return item;
            }
        }
    }
}
