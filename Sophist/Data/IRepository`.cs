using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sophist.Data
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    /// <typeparam name="TKey">The type of the primary key of entity.</typeparam>
    public interface IRepository<T, TKey> : IRepository<T>
        where T : class, IEntity<TKey>, new()
    {
        /// <summary>
        /// Gets the entity by primary key.
        /// </summary>
        /// <param name="Id">The primary key.</param>
        /// <returns>The entity with given primary key.</returns>
        T GetById(TKey Id);

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The inserted entity.</returns>
        T Save(T entity);

        /// <summary>
        /// Deletes the entity by primary key.
        /// </summary>
        /// <param name="Id">The primary key of entity.</param>
        /// <returns>Affected rows count.</returns>
        void DeleteById(TKey Id);
    }
}
