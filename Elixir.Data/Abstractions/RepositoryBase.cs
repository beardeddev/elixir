using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Elixir.Data.Abstractions
{
    using Elixir.Data.Contracts;
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class RepositoryBase<TEntity> : ReadOnlyRepositoryBase<TEntity>, IRepository<TEntity>
        where TEntity : class, new()
    {
        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="Repository&lt;TEntity&gt;"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        public RepositoryBase(IDbConnection connection)
            : base(connection)
        {
        }
        #endregion

        #region IRepository members
        /// <summary>
        /// Begins the transaction.
        /// </summary>
        public abstract void BeginTransaction();

        /// <summary>
        /// Begins the transaction.
        /// </summary>
        /// <param name="level">The level.</param>
        public abstract void BeginTransaction(IsolationLevel level);

        /// <summary>
        /// Rollbacks the transaction.
        /// </summary>
        public abstract void RollbackTransaction();

        /// <summary>
        /// Commits the transaction.
        /// </summary>
        public abstract void CommitTransaction();
        
        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public abstract TEntity GetById(dynamic id);

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Affected rows count.</returns>
        public abstract int Insert(TEntity entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Affected rows count.</returns>
        public abstract int Update(TEntity entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Affected rows count.</returns>
        public abstract int Delete(TEntity entity);
        #endregion
    }
}
