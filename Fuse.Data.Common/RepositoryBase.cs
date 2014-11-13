using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuse.Data.Common
{
    public abstract class RepositoryBase<T, TKey> : IRepository<T, TKey>
        where T : class, IEntity<TKey>, new()
    {
        private bool disposed = false;

        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <value>
        /// The connection.
        /// </value>
        protected IDbConnection Connection { get; private set; }

        /// <summary>
        /// Gets or sets the transaction.
        /// </summary>
        /// <value>
        /// The transaction.
        /// </value>
        protected IDbTransaction Transaction { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <exception cref="System.ArgumentNullException">connection</exception>
        public RepositoryBase(IDbConnection connection)
        {
            if (connection == null)
            {
                throw new ArgumentNullException("connection");
            }

            this.Connection = connection;
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
                throw new NullReferenceException("Transaction");
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
                throw new NullReferenceException("Transaction");
            }

            this.RollbackTransaction();
        }

        public abstract T Delete(T entity);

        public abstract T GetById(TKey id);

        public abstract IPagedCollection GetPaged(IFilter<T, TKey> filter);

        public abstract T Insert(T entity);

        public abstract T Update(T entity);

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (this.Connection != null)
                    {
                        if (this.Connection.State == ConnectionState.Open)
                            this.Connection.Close();

                        this.Connection.Dispose();
                    }

                    if (this.Transaction != null)
                    {
                        this.Transaction.Rollback();
                        this.Transaction.Dispose();
                    }
                }

                disposed = true;
            }
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="RepositoryBase"/> is reclaimed by garbage collection.
        /// </summary>
        ~RepositoryBase()
        {
            Dispose(false);
        }
    }
}
