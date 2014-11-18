using Fuse.Data.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Fuse.AspNet.Identity.MSSql
{
    public class UsersRolesRepository : RepositoryBase, IUsersRolesRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UsersRolesRepository"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        public UsersRolesRepository(IDbConnection connection)
            : base(connection)
        {
        }

        public int Insert(int userId, int roleId)
        {
            return this.Connection.Execute("usp_UsersRoles_Insert", new { @UserId = userId, @RoleId = roleId },
                this.Transaction, null, CommandType.StoredProcedure);
        }

        public List<string> GetByUserId(int userId)
        {
            return this.Connection.Query<string>("usp_UsersRoles_GetByUserId", new { @UserId = userId },
                this.Transaction, true, null, CommandType.StoredProcedure).ToList();
        }

        public int Delete(int userId, string roleName)
        {
            return this.Connection.Execute("usp_UsersRoles_Delete", new { @UserId = userId, @RoleName = roleName },
                this.Transaction, null, CommandType.StoredProcedure);
        }
    }
}
