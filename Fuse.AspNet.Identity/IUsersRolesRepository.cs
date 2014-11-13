using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fuse.AspNet.Identity
{
    public interface IUsersRolesRepository : IDisposable
    {
        void Insert(int userId, int roleId);
        List<string> GetByUserId(int userId);

        void Delete(int userId, string roleName);
    }
}
