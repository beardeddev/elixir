using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TIL.Data.Entity
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public class Filter<T, TKey> : IFilter<T, TKey>
        where T : IEntity<TKey>
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
        /// 
        /// </summary>
        private Func<T, bool> _where = new Func<T, bool>(x => x != null);

        /// <summary>
        /// Gets or sets the where.
        /// </summary>
        public virtual Func<T, bool> Where
        {
            get { return _where; }
            set { _where = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private Func<T, object> _orderBy = new Func<T, object>(x => x.Id);

        /// <summary>
        /// Gets or sets the order by.
        /// </summary>
        public virtual Func<T, object> OrderBy
        {
            get { return _orderBy; }
            set { _orderBy = value; }
        }
    }
}
