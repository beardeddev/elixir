using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace Elixir.Data.Abstractions
{
    using Elixir.Data.Contracts;
    
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class ReadOnlyRepositoryBase<TEntity> : IReadOnlyRepository<TEntity>
        where TEntity : class, new()
    {
        #region Private members
        private bool disposed = false;
        #endregion

        #region Readnonly members
        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <value>
        /// The connection.
        /// </value>
        public IDbConnection Connection { get; private set; }
        
        #endregion

        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="Repository&lt;TEntity, TKey&gt;"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        public ReadOnlyRepositoryBase(IDbConnection connection)
        {
            if (connection == null)
            {
                throw new ArgumentNullException("connection");
            }

            this.Connection = connection;
        }
        #endregion

        #region IDisposable members
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
                }
                disposed = true;
            }
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="Repository&lt;T&gt;"/> is reclaimed by garbage collection.
        /// </summary>
        ~ReadOnlyRepositoryBase()
        {
            Dispose(false);
        }
        #endregion

        #region IReadOnlyRepository members
        /// <summary>
        /// Gets all entities from the data store.
        /// </summary>
        /// <returns>A list of entities.</returns>
        public abstract IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Gets the specified parameters.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <returns></returns>
        public abstract IEnumerable<TEntity> Get(dynamic parameters, dynamic orderBy);

        /// <summary>
        /// Gets the specified order by.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="orderBy">The order by.</param>
        /// <returns></returns>
        public abstract IEnumerable<TEntity> Get(dynamic orderBy);

        /// <summary>
        /// Gets a slice of entities from the data store.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>A slice of entities from the data store.</returns>
        public abstract IPagedCollection<TEntity> GetPaged(IFilter filter);
        #endregion
    }
}
