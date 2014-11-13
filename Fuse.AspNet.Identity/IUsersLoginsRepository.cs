﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuse.AspNet.Identity
{
    public interface IUsersLoginsRepository : IDisposable
    {
        int Insert(IdentityUser user, UserLoginInfo login);

        int GetUserIdByLogin(UserLoginInfo login);

        List<UserLoginInfo> GetByUserId(int userId);

        void Delete(object user, UserLoginInfo login);
    }
}
