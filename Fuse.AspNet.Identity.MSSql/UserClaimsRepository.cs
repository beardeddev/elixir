using Fuse.Data.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Fuse.AspNet.Identity.MSSql
{
    public class UserClaimsRepository : RepositoryBase, IUserClaimsRepository
    {
        private Claim FillEntity(IDataReader reader)
        {
            return new Claim(reader.GetString(3), reader.GetString(4));
        }

        public UserClaimsRepository(IDbConnection connection)
            : base(connection)
        {
        }

        public int Insert(Claim claim, int userId)
        {
            var parameters = new
            {
                @UserId = userId,
                @ClaimType = claim.Type,
                @ClaimValue = claim.Value
            };

            return this.Connection.Execute("usp_UserClaims_Insert", parameters,
                this.Transaction, null, CommandType.StoredProcedure);            
        }

        public ClaimsIdentity GetByUserId(int userId)
        {
            ClaimsIdentity claims = new ClaimsIdentity();

            using (IDataReader reader = this.Connection.ExecuteReader("usp_UserClaims_GetByUserId", new { @UserId = userId },
                this.Transaction, null, CommandType.StoredProcedure))
            {
                while (reader.Read())
                {
                    Claim item = FillEntity(reader);
                    claims.AddClaim(item);
                }
            }

            return claims;
        }

        public int Delete(int userId, Claim claim)
        {
            var parameters = new
            {
                @UserId = userId,
                @ClaimType = claim.Type,
                @ClaimValue = claim.Value
            };

            return this.Connection.Execute("usp_UserClaims_Delete", parameters,
                this.Transaction, null, CommandType.StoredProcedure);
        }
    }
}
