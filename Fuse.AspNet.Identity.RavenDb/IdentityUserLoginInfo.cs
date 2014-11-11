using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuse.AspNet.Identity.RavenDb
{
    public class IdentityUserLoginInfo
    {
        /// <summary>
        /// Gets or sets the login provider.
        /// </summary>
        /// <value>
        /// The login provider.
        /// </value>
        public string Provider { get; set; }

        /// <summary>
        /// Gets or sets the provider key.
        /// </summary>
        /// <value>
        /// The provider key.
        /// </value>
        public string ProviderKey { get; set; }
    }
}
