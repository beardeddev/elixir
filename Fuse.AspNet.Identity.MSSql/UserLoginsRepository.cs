using Fuse.Data.Common;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Fuse.AspNet.Identity.MSSql
{
    public class UserLoginsRepository : RepositoryBase, IUserLoginsRepository
    {
        public UserLoginsRepository(IDbConnection connection)
            : base(connection)
        {
        }

        public int Insert(IdentityUser user, UserLoginInfo login)
        {
            var parameters = new
            {
                @UserId = user.Id,
                @LoginProvider = login.LoginProvider,
                @ProviderKey = login.ProviderKey
            };

            return this.Connection.Execute("usp_UserLogins_Insert", parameters, this.Transaction,
                null,  CommandType.StoredProcedure);
        }

        public int GetUserIdByLogin(UserLoginInfo login)
        {
            var parameters = new
            {
                @LoginProvider = login.LoginProvider,
                @ProviderKey = login.ProviderKey
            };

            return this.Connection.Execute("usp_UserLogins_GetUserIdByLogin", parameters, this.Transaction,
                null, CommandType.StoredProcedure);
        }

        public List<UserLoginInfo> GetByUserId(int userId)
        {
            return this.Connection.Query<UserLoginInfo>("usp_UserLogins_GetByUserId", new { @UserId = userId }, this.Transaction,
                true, null, CommandType.StoredProcedure).ToList();
        }

        public int Delete(int userId, UserLoginInfo login)
        {
            var parameters = new
            {
                @UserId = userId,
                @LoginProvider = login.LoginProvider,
                @ProviderKey = login.ProviderKey
            };

            return this.Connection.Execute("usp_UserLogins_Delete", parameters, this.Transaction,
                null, CommandType.StoredProcedure);
        }
    }
}
