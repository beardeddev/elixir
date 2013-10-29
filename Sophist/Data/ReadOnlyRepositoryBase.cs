using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace Sophist.Data
{
    using Sophist.Data;
    
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    public abstract class ReadOnlyRepositoryBase<T> : RepositoryBase, IReadOnlyRepository<T>
        where T : class, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReadOnlyRepositoryBase{T}"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        public ReadOnlyRepositoryBase(IDbConnection connection)
            : base(connection)
        {
        }

        /// <summary>
        /// Gets a slice of entities from the data store.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>A slice of entities from the data store.</returns>
        public abstract IPagedCollection<T> GetPaged(IFilter filter);
    }
}
