using Fuse.Data.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Fuse.Data;

namespace Fuse.AspNet.Identity.MSSql
{
    public class UsersRepository<TUser> : RepositoryBase, IUsersRepository<TUser>
        where TUser : IdentityUser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UsersRepository{TUser}"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        public UsersRepository(IDbConnection connection)
            : base(connection)
        {
        }

        public TUser GetByUserName(string userName)
        {
            return this.Connection.Query<TUser>("usp_Users_GetByUserName", new { @Name = userName },
                this.Transaction, true, null, CommandType.StoredProcedure).FirstOrDefault();
        }

        public TUser GetByEmail(string email)
        {
            return this.Connection.Query<TUser>("usp_Users_GetByEmail", new { @Email = email },
                this.Transaction, true, null, CommandType.StoredProcedure).FirstOrDefault();
        }

        public string GetPasswordHashById(int userId)
        {
            return this.Connection.ExecuteScalar<string>("usp_Users_GetPasswordHashById", new { @Id = userId },
                this.Transaction, null, CommandType.StoredProcedure);
        }

        public TUser Delete(TUser entity)
        {
            this.Connection.Execute("usp_Users_Delete", new { @Id = entity.Id },
                this.Transaction, null, CommandType.StoredProcedure);

            return entity;
        }

        public TUser GetById(int id)
        {
            return this.Connection.Query<TUser>("usp_Users_GetById", new { @Id = id },
                this.Transaction, true, null, CommandType.StoredProcedure).FirstOrDefault();
        }

        public IPagedCollection GetPaged(IFilter<TUser, int> filter)
        {
            throw new NotImplementedException();
        }

        public TUser Insert(TUser entity)
        {
            var parameters = new
            {
                @Name = entity.UserName,
                @Email = entity.Email,
                @EmailConfirmed = entity.EmailConfirmed,
                @PasswordHash = entity.PasswordHash,
                @SecurityStamp = entity.SecurityStamp,
                @PhoneNumber = entity.PhoneNumber,
                @PhoneNumberConfirmed = entity.PhoneNumberConfirmed,
                @TwoFactorEnabled = entity.TwoFactorEnabled,
                @LockoutEndDateUtc = entity.LockoutEndDateUtc,
                @LockoutEnabled = entity.LockoutEnabled,
                @FailedLoginCount = entity.FailedLoginCount,
                @PerishableToken = entity.PerishableToken,
                @LastLoginDate = entity.LastLoginDate,
                @StatusId = entity.StatusId,
                @CreatedOn = entity.CreatedOn,
                @UpdatedOn = entity.UpdatedOn
            };

            return this.Connection.Query<TUser>("usp_Users_Insert", parameters, this.Transaction,
                true, null, CommandType.StoredProcedure).FirstOrDefault();
        }

        public TUser Update(TUser entity)
        {
            var parameters = new
            {
                @Id = entity.Id,
                @Name = entity.UserName,
                @Email = entity.Email,
                @EmailConfirmed = entity.EmailConfirmed,
                @PasswordHash = entity.PasswordHash,
                @SecurityStamp = entity.SecurityStamp,
                @PhoneNumber = entity.PhoneNumber,
                @PhoneNumberConfirmed = entity.PhoneNumberConfirmed,
                @TwoFactorEnabled = entity.TwoFactorEnabled,
                @LockoutEndDateUtc = entity.LockoutEndDateUtc,
                @LockoutEnabled = entity.LockoutEnabled,
                @FailedLoginCount = entity.FailedLoginCount,
                @PerishableToken = entity.PerishableToken,
                @LastLoginDate = entity.LastLoginDate,
                @StatusId = entity.StatusId,
                @CreatedOn = entity.CreatedOn,
                @UpdatedOn = entity.UpdatedOn
            };

            return this.Connection.Query<TUser>("usp_Users_Update", parameters, this.Transaction,
                true, null, CommandType.StoredProcedure).FirstOrDefault();
        }
    }
}
