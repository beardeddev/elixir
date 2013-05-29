using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Elixir.Data.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IReadOnlyRepository<TEntity> : IDisposable
        where TEntity : class, new()
    {
        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns>A list of entities.</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Gets the paged.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>A slice of entities.</returns>
        IPagedCollection<TEntity> GetPaged(IFilter filter);
    }
}
