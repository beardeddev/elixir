using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Reflection;

namespace Unicorn.Data.Common
{
    using Unicorn.Extensions;
    using @Timestamp = Unicorn.Data.Mapping.TimestampAttribute;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    public abstract class Entity<T, TKey> : Entity<TKey>
        where T : Entity<T, TKey>, new()
    {
        /// <summary>
        /// Updates entity attributes.
        /// </summary>
        /// <param name="attributes">Object containing entity attributes collection.</param>
        /// <returns>
        /// <c>true</c> if entity attributes updated successfully; otherwise, <c>false</c>.
        /// </returns>
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
