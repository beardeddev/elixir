using Fuse.Data.Common;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuse.AspNet.Identity
{
    public class IdentityRole : Entity<byte>, IRole<byte>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityRole"/> class.
        /// </summary>
        public IdentityRole()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityRole"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public IdentityRole(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public override byte Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is new.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is new; otherwise, <c>false</c>.
        /// </value>
        public override bool IsNew { get; set; }
    }
}
