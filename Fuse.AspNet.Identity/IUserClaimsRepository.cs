using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Fuse.AspNet.Identity
{
    public interface IUserClaimsRepository : IDisposable
    {
        int Insert(Claim claim, int userId);

        ClaimsIdentity GetByUserId(int userId);

        int Delete(int userId, Claim claim);
    }
}
