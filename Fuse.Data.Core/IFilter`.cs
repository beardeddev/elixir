using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuse.Data.Core
{
    public interface IFilter<T, TKey>
        where T : IEntity<TKey>
    {
        /// <summary>
        /// Gets or sets the index of the page.
        /// </summary>
        /// <value>
        /// The page index.
        /// </value>
        int PageIndex { get; set; }

        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the where clause.
        /// </summary>
        Func<T, bool> Where { get; set; }

        /// <summary>
        /// Gets or sets the query order by parameter.
        /// </summary>
        Func<T, object> OrderBy { get; set; }
    }
}
