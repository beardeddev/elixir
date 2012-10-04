using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TIL.Extensions
{
    public static class IEnumerableExtensions
    {
        public static bool IsNullOrEmpty<T>(IEnumerable<T> value)
        {
            return value == null || value.Count() != 0;
        }
    }
}
