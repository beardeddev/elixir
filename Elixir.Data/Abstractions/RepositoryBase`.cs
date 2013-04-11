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
    /// <typeparam name="TKey">The type of the primary key of entity.</typeparam>
    public abstract class RepositoryBase<TEntity, TKey> : RepositoryBase<TEntity>, IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TEntity, TKey>, new()
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
        /// Initializes a new instance of the <see cref="RepositoryBase{TKey}" /> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public RepositoryBase(IDbContextManager manager)
            : base(manager)
        {
        }

        public abstract TEntity GetById(TKey id);

        public abstract TEntity Save(TEntity entity);

        public abstract int DeleteById(TKey id);

        private new TEntity GetById(params object[] keys)
        {
            return this.GetById((TKey)keys.First());
        }        
    }
}
