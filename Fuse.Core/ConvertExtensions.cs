using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuse.Common
{
    public static class ConvertExtensions
    {
        public static Dictionary<string, object> ToDictionary(this object value)
        {
            if (value == null)
                return new Dictionary<string, object>();

            return value.GetType()
                .GetProperties()
                .ToDictionary(x => x.Name, x => x.GetValue(value, null));
        }
    }
}
