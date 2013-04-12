using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elixir.Common
{
    public static class IEnumerableExtensions
    {
        public static bool IsNullOrEmpty<T>(IEnumerable<T> value)
        {
            return value == null || value.Count() != 0;
        }

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
