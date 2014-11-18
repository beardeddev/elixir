using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuse.AspNet.Identity.MSSql
{
    public class UserStore<TUser> : Fuse.AspNet.Identity.UserStore<TUser>
        where TUser : IdentityUser
    {
        public UserStore(IUsersRepository<TUser> userRepository, IUserLoginsRepository userLoginsRepository,
            IUserClaimsRepository userClaimsRepository, IUsersRolesRepository usersRolesRepository,
            IRolesRepository rolesRepository)
            : base(userRepository, userLoginsRepository, userClaimsRepository, usersRolesRepository, rolesRepository)
        {

        }
    }
}
