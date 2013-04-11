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
        /// Gets the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <returns></returns>
        IEnumerable<TEntity> Get<TEntity>(object parameters, object orderBy);

        /// <summary>
        /// Gets the specified order by.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <returns></returns>
        IEnumerable<TEntity> Get<TEntity>(object orderBy);

        /// <summary>
        /// Gets the paged.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>A slice of entities.</returns>
        IPagedCollection<TEntity> GetPaged(IFilter filter);
    }
}
