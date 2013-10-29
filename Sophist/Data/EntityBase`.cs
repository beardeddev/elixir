using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sophist.Data
{
    using Sophist.Data;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    public abstract class EntityBase<T, TKey> : EntityBase<TKey>, IEntity<T, TKey>
        where T : EntityBase<T, TKey>, new()
    {
    }
}
