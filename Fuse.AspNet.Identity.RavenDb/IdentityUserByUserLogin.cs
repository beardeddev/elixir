using Raven.Client.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beardeddev.AspNet.Identity.RavenDb
{
    public class IdentityUserByUserLogin : AbstractIndexCreationTask<IdentityUser>
    {
        public IdentityUserByUserLogin()
        {
            Map = users => from u in users
                           let doc = LoadDocument<IdentityUser>(u)
                           select u;
        }
    }
}
