using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elixir.Data
{
    using Elixir.Data.Contracts;
    using Elixir.Data.Abstractions;
    using Elixir.Data.Mapping;

    public class Entity<T, TKey> : EntityBase<T, TKey>, IEntity<T, TKey>, ITimestampable
        where T : Entity<T, TKey>, new()
    {
        /// <summary>
        /// Gets or sets the create on.
        /// </summary>
        /// <value>
        /// The create on.
        /// </value>
        [Timestamp(AutoAddNow = true, AutoUpdateNow = false)]
        public virtual DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the updated on.
        /// </summary>
        /// <value>
        /// The updated on.
        /// </value>
        [Timestamp(AutoAddNow = true, AutoUpdateNow = true)]
        public virtual DateTime UpdatedOn { get; set; }
    }
}
