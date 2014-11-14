using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuse.AspNet.Identity
{
    public interface IUserLoginsRepository : IDisposable
    {
        int Insert(IdentityUser user, UserLoginInfo login);

        int GetUserIdByLogin(UserLoginInfo login);

        List<UserLoginInfo> GetByUserId(int userId);

        int Delete(int userId, UserLoginInfo login);
    }
}
