using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elixir.Data.Abstractions
{
    using Elixir.Data.Contracts;

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
        public virtual bool IsNew
        {
            get
            {
                return Comparer<TKey>.Default.Compare(this.Id, default(TKey)) == 0;
            }
        }
    }
}
