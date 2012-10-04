using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Reflection;

namespace TIL.Data
{
    using TIL.Data;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    public abstract class Entity<TKey> : IEntity<TKey>
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public abstract TKey Id { get; set; }

        /// <summary>
        /// Converts entity to Uri parameters.
        /// </summary>
        /// <returns>Anonymous object representing query string parameters.</returns>
        public virtual object ToUrlParams()
        {
            return new { @id = this.Id };
        }

        /// <summary>
        /// Gets a value indicating whether this instance is new.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is new (not persists in data store); otherwise, <c>false</c>.
        /// </value>
        public virtual bool IsNew
        {
            get
            {
                return Comparer<TKey>.Default.Compare(this.Id, default(TKey)) == 0;
            }
        }

        public abstract bool UpdateAttributes(object attributes);        
    }
}
