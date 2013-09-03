using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sophist.Web.Mvc.Scaffolding
{
    /// <summary>
    /// 
    /// </summary>
    public interface IFilter<T>
        where T : IEntity
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
        /// Gets or sets the params.
        /// </summary>
        /// <value>
        /// The params.
        /// </value>
        Func<T, bool> Where { get; set; }

        /// <summary>
        /// Gets or sets the order by.
        /// </summary>
        /// <value>
        /// The order by.
        /// </value>
        Func<T, object> OrderBy { get; set; }
    }
}
