using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sophist.Data
{
    using Sophist.Data;

    public abstract class EntityBase<TKey> : IEntity<TKey>
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        dynamic IEntity.Id
        {
            get
            {
                return this.Id;
            }
            set
            {
                this.Id = Convert.ChangeType(value, typeof(TKey));
            }
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public virtual TKey Id { get; set; }

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
        public virtual bool IsNew { get; set; }
    }
}
