using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fuse.Data.Core
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedCollection<T> : IPagedCollection<T>, IPagedCollection
    {
        #region Private members
        private readonly IEnumerable<T> items;
        #endregion

        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="PagedCollection&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="items">The collection of items.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="totalCount">The total count.</param>
        public PagedCollection(IEnumerable<T> items, int pageIndex, int pageSize, int totalCount)
        {
            this.items = items;
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.TotalCount = totalCount;
        }
        #endregion

        #region IEnumerable implementation
        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this.items.GetEnumerator();
        }

        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns></returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this.items.GetEnumerator();
        }
        #endregion

        #region IPagedCollection Members
        /// <summary>
        /// Gets the index of the page.
        /// </summary>
        /// <value>
        /// The index of the page.
        /// </value>
        public int PageIndex { get; private set; }

        /// <summary>
        /// Gets the size of the page.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        public int PageSize { get; private set; }

        /// <summary>
        /// Gets the total count.
        /// </summary>
        public int TotalCount { get; private set; }
        #endregion
    }
}