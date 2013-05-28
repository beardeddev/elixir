using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Elixir.Data.Abstractions
{
    using Elixir.Data.Contracts;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class FilterBase<T> : IFilter<T>
        where T : class, new()
    {
        private int pageIndex = 1;
        /// <summary>
        /// Gets or sets the index of the page.
        /// </summary>
        /// <value>
        /// The page index.
        /// </value>
        public virtual int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }

        private int pageSize = 25;
        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        public virtual int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        /// <summary>
        /// Gets or sets the order by.
        /// </summary>
        /// <value>
        /// The order by.
        /// </value>
        public dynamic OrderBy { get; set; }

        /// <summary>
        /// Gets or sets the params.
        /// </summary>
        /// <value>
        /// The params.
        /// </value>
        public dynamic Params { get; set; }
    }
}
