using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Fuse.AspNet.Identity
{
    public interface IUsersClaimsRepository : IDisposable
    {
        void Insert(Claim claim, int userId);

        ClaimsIdentity GetByUserId(int userId);

        void Delete(int userId, Claim claim);
    }
}
