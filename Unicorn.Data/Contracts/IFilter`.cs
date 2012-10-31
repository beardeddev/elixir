using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Unicorn.Data.Contracts
{
    /// <summary>
    /// Defines the methods and properties that are required collections filtering based on LINQ queries.
    /// </summary>
    /// <typeparam name="T">The type of entity.</typeparam>
    /// <typeparam name="TKey">The primary key type.</typeparam>
    /// <summary>
    /// Specifies a parameters that is used by the query to filter documents that have the file format that is associated with the IFilter.
    /// </summary>
    /// <typeparam name="T">The type of a document.</typeparam>
    public interface IFilter<T, TKey> where T : IEntity<TKey>
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