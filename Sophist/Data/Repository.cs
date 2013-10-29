using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sophist.Data
{
    public abstract class Repository<T, TKey> : RepositoryBase<T, TKey>
        where T : class, IEntity<T, TKey>, new()
    {   
        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T, TKey}" /> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        public Repository(IDbConnection connection)
            : base(connection)
        {
        }
    }
}
