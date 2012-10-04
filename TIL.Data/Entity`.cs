using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Reflection;

namespace TIL.Data
{
    using @Timestamp = TIL.Data.Mapping.TimestampAttribute;
    using TIL.Extensions;
    
    public abstract class Entity<T, TKey> : Entity<TKey>
        where T : Entity<T, TKey>, new()
    {
        /// <summary>
        /// Updates the attributes.
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        public override bool UpdateAttributes(object attributes)
        {
            IDictionary attrs = attributes.ToDictionary();

            IEnumerable<PropertyInfo> properties = typeof(T)
                .GetProperties().Where(x => x.CanWrite && !x.GetCustomAttributes(true).Any(a => a is @Timestamp));

            foreach (var p in properties)
            {
                if (attrs[p.Name] != null)
                {
                    object val = attrs[p.Name].GetValue(p.PropertyType);
                    ((T)this).SetPropertyValue(p.Name, val);
                }
            }

            return true;
        }
    }
}
