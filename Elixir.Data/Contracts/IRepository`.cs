using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elixir.Data.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TKey">The type of the primary key of entity.</typeparam>
    public interface IRepository<TEntity, TKey> : IRepository<TEntity>
        where TEntity : class, IEntity<TKey>, new()
    {
        /// <summary>
        /// Gets the entity by primary key.
        /// </summary>
        /// <param name="Id">The primary key.</param>
        /// <returns>The entity with given primary key.</returns>
        TEntity GetById(TKey Id);

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The inserted entity.</returns>
        TEntity Save(TEntity entity);

        /// <summary>
        /// Deletes the entity by primary key.
        /// </summary>
        /// <param name="Id">The primary key of entity.</param>
        /// <returns>Affected rows count.</returns>
        int DeleteById(TKey Id);
    }
}
