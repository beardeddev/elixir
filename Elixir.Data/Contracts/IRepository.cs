using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elixir.Data.Contracts
{
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity>
        where TEntity : class, IEntity, new()
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
        /// <param name="keys">The primary keys.</param>
        /// <returns>The entity with given primary keys.</returns>
        TEntity GetById(params object[] keys);

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Affected rows count.</returns>
        int Insert(TEntity entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Affected rows count.</returns>
        int Update(TEntity entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Affected rows count.</returns>
        int Delete(TEntity entity);

    }
}
