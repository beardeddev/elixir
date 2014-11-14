using Fuse.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuse.AspNet.Identity
{
    public interface IUsersRepository<TUser> : IRepository<TUser, int>
        where TUser : IdentityUser
    {
        /// <summary>
        /// Gets the user by name.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>The user with given user name.</returns>
        TUser GetByUserName(string userName);

        /// <summary>
        /// Gets the by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        TUser GetByEmail(string email);

        /// <summary>
        /// Gets the password hash by user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        string GetPasswordHashById(int userId);
    }
}
