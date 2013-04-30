using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Elixir.Data.Abstractions
{
    using Elixir.Data.Contracts;
    using Elixir.Data.Fluent;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class RepositoryBase<TEntity> : ReadOnlyRepositoryBase<TEntity>, IRepository<TEntity>
        where TEntity : class, IEntity, new()
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

        public RepositoryBase(IDbManager manager)
            : base(manager)
        {

        }
        #endregion

        #region IRepository members
        /// <summary>
        /// Begins the transaction.
        /// </summary>
        public virtual void BeginTransaction()
        {
            this.BeginTransaction(IsolationLevel.Unspecified);
        }

        public virtual void BeginTransaction(IsolationLevel level)
        {
            this.DbManager.BeginTransaction(level);
        }

        /// <summary>
        /// Rollbacks the transaction.
        /// </summary>
        public virtual void RollbackTransaction()
        {
            this.DbManager.RollbackTransaction();
        }

        /// <summary>
        /// Commits the transaction.
        /// </summary>
        public virtual void CommitTransaction()
        {
            this.DbManager.CommitTransaction();
        }

        /// <summary>
        /// Gets the entity by primary keys.
        /// </summary>
        /// <param name="keys">The primary keys.</param>
        /// <returns>The entity with given primary keys.</returns>
        public abstract TEntity GetById(params object[] keys);

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
