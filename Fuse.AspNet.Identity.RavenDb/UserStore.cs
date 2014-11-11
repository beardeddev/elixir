using Microsoft.AspNet.Identity;
using Raven.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Fuse.AspNet.Identity.RavenDb
{
    public class UserStore<TUser> : IUserStore<TUser>, 
                                    IUserClaimStore<TUser>,
                                    IUserLoginStore<TUser>,
                                    IUserRoleStore<TUser>,
                                    IUserPasswordStore<TUser>,
                                    IUserSecurityStampStore<TUser>
        where TUser : IdentityUser
    {
        private IDocumentSession session;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserStore"/> class.
        /// </summary>
        /// <param name="session">The session.</param>
        public UserStore(IDocumentSession session)
        {
            this.session = session;
        }

        public Task CreateAsync(TUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            this.session.Store(user);

            return Task.FromResult(true);
        }

        public Task DeleteAsync(TUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            this.session.Delete(user);

            return Task.FromResult(true);
        }

        public Task<TUser> FindByIdAsync(string userId)
        {
            var user = this.session.Load<TUser>(userId);
            return Task.FromResult(user);
        }

        public Task<TUser> FindByNameAsync(string userName)
        {
            var user = this.session.Query<TUser>()
                .FirstOrDefault(x => x.UserName.Equals(userName, StringComparison.InvariantCultureIgnoreCase));

            return Task.FromResult(user);
        }

        public Task UpdateAsync(TUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            this.session.Store(user);

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            if(this.session != null)
                this.session.Dispose();
        }

        public Task AddClaimAsync(TUser user, Claim claim)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            if (!user.Claims.Any(x => x.ClaimType == claim.Type && x.ClaimValue == claim.Value))
            {
                user.Claims.Add(new IdentityUserClaim
                {
                    ClaimType = claim.Type,
                    ClaimValue = claim.Value
                });
            }

            return Task.FromResult(0);
        }

        public Task<IList<Claim>> GetClaimsAsync(TUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            IList<Claim> result = user.Claims.Select(c => new Claim(c.ClaimType, c.ClaimValue)).ToList();
            return Task.FromResult(result);
        }

        public Task RemoveClaimAsync(TUser user, Claim claim)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            user.Claims.RemoveAll(x => x.ClaimType == claim.Type && x.ClaimValue == claim.Value);
            return Task.FromResult(0);
        }

        public Task AddLoginAsync(TUser user, UserLoginInfo login)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (!user.Logins.Any(x => x.LoginProvider == login.LoginProvider && x.ProviderKey == login.ProviderKey))
            {
                user.Logins.Add(login);

                this.session.Store(new IdentityUserLoginInfo
                {
                    Provider = login.LoginProvider,
                    ProviderKey = login.ProviderKey
                });
            }

            return Task.FromResult(true);
        }

        public Task<TUser> FindAsync(UserLoginInfo login)
        {
            if (login == null)
            {
                throw new ArgumentNullException("login");
            }

            TUser user = this.session.Query<TUser>().FirstOrDefault(x => 
                x.Logins.Any(l => l.LoginProvider.Equals(login.LoginProvider, StringComparison.InvariantCultureIgnoreCase)
                    && l.ProviderKey.Equals(login.ProviderKey, StringComparison.InvariantCultureIgnoreCase)));

            return Task.FromResult<TUser>(user);

        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(TUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            return Task.FromResult<IList<UserLoginInfo>>(user.Logins);
        }

        public Task RemoveLoginAsync(TUser user, UserLoginInfo login)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (login == null)
            {
                throw new ArgumentNullException("login");
            }

            IdentityUserLoginInfo loginDoc = this.session.Query<IdentityUserLoginInfo>().FirstOrDefault(x => x.Provider.Equals(login.LoginProvider, StringComparison.InvariantCultureIgnoreCase)
                    && x.ProviderKey.Equals(login.ProviderKey, StringComparison.InvariantCultureIgnoreCase));

            if (loginDoc != null)
                this.session.Delete(loginDoc);

            user.Logins.RemoveAll(x => x.LoginProvider == login.LoginProvider && x.ProviderKey == login.ProviderKey);

            return Task.FromResult<Object>(null);
        }

        public Task AddToRoleAsync(TUser user, string roleName)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            if (!user.Roles.Contains(roleName, StringComparer.InvariantCultureIgnoreCase))
                user.Roles.Add(roleName);

            return Task.FromResult(0);
        }

        public Task<IList<string>> GetRolesAsync(TUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.FromResult<IList<string>>(user.Roles);
        }

        public Task<bool> IsInRoleAsync(TUser user, string roleName)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.FromResult(user.Roles.Contains(roleName, StringComparer.InvariantCultureIgnoreCase));
        }

        public Task RemoveFromRoleAsync(TUser user, string roleName)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            user.Roles.RemoveAll(r => String.Equals(r, roleName, StringComparison.InvariantCultureIgnoreCase));

            return Task.FromResult(0);
        }

        public Task<string> GetPasswordHashAsync(TUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(TUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.FromResult<bool>(user.PasswordHash != null);
        }

        public Task SetPasswordHashAsync(TUser user, string passwordHash)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            user.PasswordHash = passwordHash;
            return Task.FromResult(0);
        }

        public Task<string> GetSecurityStampAsync(TUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.FromResult(user.SecurityStamp);
        }

        public Task SetSecurityStampAsync(TUser user, string stamp)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            user.SecurityStamp = stamp;
            return Task.FromResult(0);
        }
    }
}
