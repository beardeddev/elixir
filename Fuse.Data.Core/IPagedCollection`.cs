using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fuse.Data.Core
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPagedCollection<T> : IPagedCollection, IEnumerable<T>
    {
    }
}