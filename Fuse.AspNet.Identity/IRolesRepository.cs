using Fuse.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fuse.AspNet.Identity
{
    public interface IRolesRepository : IRepository<IdentityRole, byte>
    {
        byte GetIdByName(string roleName);
    }
}
