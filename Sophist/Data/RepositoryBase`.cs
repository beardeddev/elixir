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
    public abstract class RepositoryBase<T> : ReadOnlyRepositoryBase<T>, IRepository<T>
        where T : class, new()
    {

        /// <summary>
        /// Gets or sets the transaction.
        /// </summary>
        /// <value>
        /// The transaction.
        /// </value>
        protected IDbTransaction Transaction { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase{T}"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        public RepositoryBase(IDbConnection connection)
            : base(connection)
        {
        }

        /// <summary>
        /// Begins the transaction.
        /// </summary>
        public void BeginTransaction()
        {
            this.BeginTransaction(IsolationLevel.ReadUncommitted);
        }

        /// <summary>
        /// Begins the transaction.
        /// </summary>
        /// <param name="level">The level.</param>
        public void BeginTransaction(IsolationLevel level)
        {
            this.Transaction = this.Connection.BeginTransaction(level);
        }

        /// <summary>
        /// Commits the transaction.
        /// </summary>
        public void CommitTransaction()
        {
            if (this.Transaction == null)
            {
                throw new NoNullAllowedException("Transaction");
            }

            this.Transaction.Commit();
        }

        /// <summary>
        /// Rollbacks the transaction.
        /// </summary>
        public void RollbackTransaction()
        {
            if (this.Transaction == null)
            {
                throw new NoNullAllowedException("Transaction");
            }

            this.RollbackTransaction();
        }

        /// <summary>
        /// Gets the entity by primary key.
        /// </summary>
        /// <param name="id">The primary key.</param>
        /// <returns>The entity with given primary key.</returns>
        public abstract T GetById(dynamic id);

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Affected rows count.</returns>
        public abstract void Insert(T entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Affected rows count.</returns>
        public abstract void Update(T entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Affected rows count.</returns>
        public abstract void Delete(T entity);

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (this.Transaction != null)
            {
                this.Transaction.Rollback();
                this.Transaction.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
