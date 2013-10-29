using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Sophist.Data
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    public interface IReadOnlyRepository<T> : IDisposable
        where T : class, new()
    {
        /// <summary>
        /// Gets the paged.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>A slice of entities.</returns>
        IPagedCollection<T> GetPaged(IFilter filter);
    }
}
