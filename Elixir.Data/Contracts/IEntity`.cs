using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elixir.Data.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    public interface IEntity<TKey> : IEntity
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        TKey Id { get; set; }
    }
}
