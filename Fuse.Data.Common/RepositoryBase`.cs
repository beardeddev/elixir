using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuse.Data.Common
{
    public abstract class RepositoryBase<T, TKey> : RepositoryBase, IRepository<T, TKey>
        where T : class, IEntity<TKey>, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <exception cref="System.ArgumentNullException">connection</exception>
        public RepositoryBase(IDbConnection connection)
            : base(connection)
        {
        }

        public abstract T Delete(T entity);

        public abstract T GetById(TKey id);

        public abstract IPagedCollection GetPaged(IFilter<T, TKey> filter);

        public abstract T Insert(T entity);

        public abstract T Update(T entity);        
    }
}
