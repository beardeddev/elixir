using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Sophist.Data
{
    using Sophist.Data;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    /// <typeparam name="TKey">The type of the primary key of entity.</typeparam>
    public abstract class RepositoryBase<T, TKey> : RepositoryBase<T>, IRepository<T, TKey>
        where T : class, IEntity<T, TKey>, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase{TKey}" /> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        public RepositoryBase(IDbConnection connection)
            : base(connection)
        {
        }

        /// <summary>
        /// Gets the entity by primary key.
        /// </summary>
        /// <param name="Id">The primary key.</param>
        /// <returns>The entity with given primary key.</returns>
        public abstract T GetById(TKey id);

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The inserted entity.</returns>
        public abstract T Save(T entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Affected rows count.</returns>
        public abstract void DeleteById(TKey id);

        /// <summary>
        /// Gets the entity by primary key.
        /// </summary>
        /// <param name="id">The primary key.</param>
        /// <returns>The entity with given primary key.</returns>
        T IRepository<T>.GetById(dynamic id)
        {
            return this.GetById((TKey)id);
        }
    }
}
