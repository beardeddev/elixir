using Raven.Client.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beardeddev.AspNet.Identity.RavenDb
{
    public class IdentityUserByUserName : AbstractIndexCreationTask<IdentityUser>
    {
        public IdentityUserByUserName()
        {
            Map = users => from u in users
                           let doc = LoadDocument<IdentityUser>(u.UserName)
                           select u;
        }
    }
}
