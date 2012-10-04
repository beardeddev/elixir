using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TIL.Data
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Gets a value indicating whether this instance is new.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is new (not persisted in detector); otherwise, <c>false</c>.
        /// </value>
        bool IsNew { get; }

        /// <summary>
        /// Converts entity to Uri parameters.
        /// </summary>
        /// <returns>Anonymous object representing query string parameters.</returns>
        object ToUrlParams();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attributes"></param>
        /// <returns></returns>
        bool UpdateAttributes(object attributes);
    }
}
