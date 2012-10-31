using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unicorn.Data.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPagedCollection<T> : IPagedCollection, IEnumerable<T>
    {
    }
}
