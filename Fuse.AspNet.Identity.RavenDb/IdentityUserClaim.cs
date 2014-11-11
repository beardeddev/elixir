using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuse.AspNet.Identity.RavenDb
{
    public class IdentityUserClaim
    {
        /// <summary>
        /// Gets or sets the type of the claim.
        /// </summary>
        /// <value>
        /// The type of the claim.
        /// </value>
        public virtual string ClaimType { get; set; }

        /// <summary>
        /// Gets or sets the claim value.
        /// </summary>
        /// <value>
        /// The claim value.
        /// </value>
        public virtual string ClaimValue { get; set; }
    }
}
