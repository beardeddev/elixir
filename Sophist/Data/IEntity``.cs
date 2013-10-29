using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sophist.Data
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    public interface IEntity<T, TKey> : IEntity<TKey>
        where T : IEntity<T, TKey>
    {
    }
}
