using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sophist.Data
{
    public interface IRepository<T> : IReadOnlyRepository<T>
        where T : class, new()
    {
        /// <summary>
        /// Begins the transaction.
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// Rollbacks the transaction.
        /// </summary>
        void RollbackTransaction();

        /// <summary>
        /// Commits the transaction.
        /// </summary>
        void CommitTransaction();

        /// <summary>
        /// Gets the entity by primary keys.
        /// </summary>
        /// <param name="id">The primary key.</param>
        /// <returns>The entity with given primary key.</returns>
        T GetById(dynamic id);

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>        
        void Insert(T entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>        
        void Update(T entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>        
        void Delete(T entity);
    }
}
