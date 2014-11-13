using Fuse.Data;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Fuse.AspNet.Identity
{
    public class UserStore<TUser> : IUserLoginStore<TUser, int>,
        IUserClaimStore<TUser, int>,
        IUserRoleStore<TUser, int>,
        IUserPasswordStore<TUser, int>,
        IUserSecurityStampStore<TUser, int>,
        IQueryableUserStore<TUser, int>,
        IUserEmailStore<TUser, int>,
        IUserPhoneNumberStore<TUser, int>,
        IUserTwoFactorStore<TUser, int>,
        IUserLockoutStore<TUser, int>,
        IUserStore<TUser, int>
        where TUser : IdentityUser
    {
        private IUsersRepository<TUser> usersRepository;
        private IUserLoginsRepository userLoginsRepository;
        private IUserClaimsRepository userClaimsRepository;
        private IUsersRolesRepository usersRolesRepository;
        private IRolesRepository rolesRepository;

        public UserStore(IUsersRepository<TUser> userRepository, IUserLoginsRepository userLoginsRepository,
            IUserClaimsRepository userClaimsRepository, IUsersRolesRepository usersRolesRepository,
            IRolesRepository rolesRepository)
        {
            this.usersRepository = userRepository;
            this.userLoginsRepository = userLoginsRepository;
            this.userClaimsRepository = userClaimsRepository;
            this.usersRolesRepository = usersRolesRepository;
            this.rolesRepository = rolesRepository;
        }

        public Task AddLoginAsync(TUser user, UserLoginInfo login)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (login == null)
            {
                throw new ArgumentNullException("login");
            }

            this.userLoginsRepository.Insert(user, login);

            return Task.FromResult<object>(null);
        }

        public Task<TUser> FindAsync(UserLoginInfo login)
        {
            if (login == null)
            {
                throw new ArgumentNullException("login");
            }

            int userId = this.userLoginsRepository.GetUserIdByLogin(login);
            if (userId != 0)
            {
                TUser user = this.usersRepository.GetById(userId);
                if (user != null)
                {
                    return Task.FromResult<TUser>(user);
                }
            }

            return Task.FromResult<TUser>(null);
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(TUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            List<UserLoginInfo> logins = this.userLoginsRepository.GetByUserId(user.Id);
            if (logins != null)
            {
                return Task.FromResult<IList<UserLoginInfo>>(logins);
            }

            return Task.FromResult<IList<UserLoginInfo>>(null);
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

            this.userLoginsRepository.Delete(user, login);

            return Task.FromResult<Object>(null);
        }

        public Task CreateAsync(TUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            this.usersRepository.Insert(user);

            return Task.FromResult<object>(null);
        }

        public Task DeleteAsync(TUser user)
        {
            if (user != null)
            {
                this.usersRepository.Delete(user);
            }

            return Task.FromResult<Object>(null);
        }

        public Task<TUser> FindByIdAsync(int userId)
        {
            TUser result = this.usersRepository.GetById(userId);
            if (result != null)
            {
                return Task.FromResult<TUser>(result);
            }

            return Task.FromResult<TUser>(null);
        }

        public Task<TUser> FindByNameAsync(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("Null or empty argument: userName");
            }

            TUser result = this.usersRepository.GetByUserName(userName);

            if (result != null)
            {
                return Task.FromResult<TUser>(result);
            }

            return Task.FromResult<TUser>(null);
        }

        public Task UpdateAsync(TUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            this.usersRepository.Update(user);

            return Task.FromResult<object>(null);
        }

        public Task AddClaimAsync(TUser user, Claim claim)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (claim == null)
            {
                throw new ArgumentNullException("user");
            }

            this.userClaimsRepository.Insert(claim, user.Id);

            return Task.FromResult<object>(null);
        }

        public Task<IList<Claim>> GetClaimsAsync(TUser user)
        {
            ClaimsIdentity identity = this.userClaimsRepository.GetByUserId(user.Id);
            return Task.FromResult<IList<Claim>>(identity.Claims.ToList());
        }

        public Task RemoveClaimAsync(TUser user, System.Security.Claims.Claim claim)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (claim == null)
            {
                throw new ArgumentNullException("claim");
            }

            this.userClaimsRepository.Delete(user.Id, claim);

            return Task.FromResult<object>(null);
        }

        public Task AddToRoleAsync(TUser user, string roleName)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (string.IsNullOrEmpty(roleName))
            {
                throw new ArgumentException("Argument cannot be null or empty: roleName.");
            }

            int roleId = this.rolesRepository.GetIdByName(roleName);
            if (roleId > 0)
            {
                this.usersRolesRepository.Insert(user.Id, roleId);
            }

            return Task.FromResult<object>(null);
        }

        public Task<IList<string>> GetRolesAsync(TUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            List<string> roles = this.usersRolesRepository.GetByUserId(user.Id);

            if (roles != null)
            {
                return Task.FromResult<IList<string>>(roles);
            }

            return Task.FromResult<IList<string>>(null);
        }

        public Task<bool> IsInRoleAsync(TUser user, string roleName)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (string.IsNullOrEmpty(roleName))
            {
                throw new ArgumentNullException("role");
            }

            List<string> roles = this.usersRolesRepository.GetByUserId(user.Id);

            if (roles != null && roles.Contains(roleName))
            {
                return Task.FromResult<bool>(true);
            }

            return Task.FromResult<bool>(false);
        }

        public Task RemoveFromRoleAsync(TUser user, string roleName)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (string.IsNullOrEmpty(roleName))
            {
                throw new ArgumentNullException("role");
            }

            this.usersRolesRepository.Delete(user.Id, roleName);

            return Task.FromResult<object>(null);
        }

        public void Dispose()
        {
            if (this.usersRepository != null)
                this.usersRepository.Dispose();

            if (this.userLoginsRepository != null)
                this.userLoginsRepository.Dispose();

            if (this.userClaimsRepository != null)
                this.userClaimsRepository.Dispose();

            if (this.usersRolesRepository != null)
                this.usersRolesRepository.Dispose();

            if (this.rolesRepository == null)
                this.rolesRepository.Dispose();
        }

        public Task<string> GetPasswordHashAsync(TUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            string passwordHash = this.usersRepository.GetPasswordHashByUserId(user.Id);

            return Task.FromResult<string>(passwordHash);
        }

        public Task<bool> HasPasswordAsync(TUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            bool hasPassword = !string.IsNullOrEmpty(this.usersRepository.GetPasswordHashByUserId(user.Id));

            return Task.FromResult<bool>(hasPassword);
        }

        public Task SetPasswordHashAsync(TUser user, string passwordHash)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            if(string.IsNullOrEmpty(passwordHash))
                throw new ArgumentNullException("Argument cannot be null or empty: passwordHash");

            user.PasswordHash = passwordHash;

            return Task.FromResult<Object>(null);
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

        public IQueryable<TUser> Users
        {
            get { throw new NotImplementedException(); }
        }

        public Task<TUser> FindByEmailAsync(string email)
        {
            if (String.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException("email");
            }

            TUser result = this.usersRepository.GetByEmail(email);
            if (result != null)
            {
                return Task.FromResult<TUser>(result);
            }

            return Task.FromResult<TUser>(null);
        }

        public Task<string> GetEmailAsync(TUser user)
        {
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(TUser user)
        {
            return Task.FromResult(user.EmailConfirmed);
        }

        public Task SetEmailAsync(TUser user, string email)
        {
            user.Email = email;
            this.usersRepository.Update(user);

            return Task.FromResult(0);
        }

        public Task SetEmailConfirmedAsync(TUser user, bool confirmed)
        {
            user.EmailConfirmed = confirmed;
            this.usersRepository.Update(user);

            return Task.FromResult(0);
        }

        public Task<string> GetPhoneNumberAsync(TUser user)
        {
            return Task.FromResult(user.PhoneNumber);
        }

        public Task<bool> GetPhoneNumberConfirmedAsync(TUser user)
        {
            return Task.FromResult(user.PhoneNumberConfirmed);
        }

        public Task SetPhoneNumberAsync(TUser user, string phoneNumber)
        {
            user.PhoneNumber = phoneNumber;
            this.usersRepository.Update(user);

            return Task.FromResult(0);
        }

        public Task SetPhoneNumberConfirmedAsync(TUser user, bool confirmed)
        {
            user.PhoneNumberConfirmed = confirmed;
            this.usersRepository.Update(user);

            return Task.FromResult(0);
        }

        public Task<bool> GetTwoFactorEnabledAsync(TUser user)
        {
            return Task.FromResult(user.TwoFactorEnabled);
        }

        public Task SetTwoFactorEnabledAsync(TUser user, bool enabled)
        {
            user.TwoFactorEnabled = enabled;
            this.usersRepository.Update(user);

            return Task.FromResult(0);
        }

        public Task<int> GetAccessFailedCountAsync(TUser user)
        {
            return Task.FromResult(user.FailedLoginCount);
        }

        public Task<bool> GetLockoutEnabledAsync(TUser user)
        {
            return Task.FromResult(user.LockoutEnabled);
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(TUser user)
        {
            return
                Task.FromResult(user.LockoutEndDateUtc.HasValue
                    ? new DateTimeOffset(DateTime.SpecifyKind(user.LockoutEndDateUtc.Value, DateTimeKind.Utc))
                    : new DateTimeOffset());
        }

        public Task<int> IncrementAccessFailedCountAsync(TUser user)
        {
            user.FailedLoginCount++;
            this.usersRepository.Update(user);

            return Task.FromResult(user.FailedLoginCount);
        }

        public Task ResetAccessFailedCountAsync(TUser user)
        {
            user.FailedLoginCount = 0;
            this.usersRepository.Update(user);

            return Task.FromResult(0);
        }

        public Task SetLockoutEnabledAsync(TUser user, bool enabled)
        {
            user.LockoutEnabled = enabled;
            this.usersRepository.Update(user);

            return Task.FromResult(0);
        }

        public Task SetLockoutEndDateAsync(TUser user, DateTimeOffset lockoutEnd)
        {
            user.LockoutEndDateUtc = lockoutEnd.UtcDateTime;
            this.usersRepository.Update(user);

            return Task.FromResult(0);
        }
    }
}
