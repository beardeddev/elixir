using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Sophist.Web.Mvc.Scaffolding
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPagedCollection : IEnumerable
    {
        /// <summary>
        /// Gets the index of the page.
        /// </summary>
        /// <value>
        /// The index of the page.
        /// </value>
        int PageIndex { get; }

        /// <summary>
        /// Gets the size of the page.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        int PageSize { get; }

        /// <summary>
        /// Gets the total count.
        /// </summary>
        int TotalCount { get; }
    }
}
