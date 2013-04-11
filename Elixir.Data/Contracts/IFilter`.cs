using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elixir.Data.Contracts
{
    /// <summary>
    /// Defines the methods and properties that are required collections filtering based on LINQ queries.
    /// </summary>
    /// <typeparam name="T">The type of entity.</typeparam>
    /// <typeparam name="TKey">The primary key type.</typeparam>
    public interface IFilter<T> : IFilter
    {
    }
}