using Fuse.Data;
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
    public class RolesRepository : RepositoryBase<IdentityRole, byte>, IRolesRepository
    {
        public RolesRepository(IDbConnection connection)
            : base(connection)
        {
        }

        public override IdentityRole Delete(IdentityRole entity)
        {
            this.Connection.Execute("usp_Roles_Delete", new { @Id = entity.Id }, 
                this.Transaction, null, CommandType.StoredProcedure);

            return entity;
        }

        public override IdentityRole GetById(byte id)
        {
            return this.Connection.Query<IdentityRole>("usp_Roles_GetById", new { @Id = id }, 
                this.Transaction, true, null, CommandType.StoredProcedure).FirstOrDefault();
        }

        public override IPagedCollection GetPaged(IFilter<IdentityRole, byte> filter)
        {
            throw new NotImplementedException();
        }

        public override IdentityRole Insert(IdentityRole entity)
        {
            var parameters = new
            {
                @Name = entity.Name,
                @CreatedOn = entity.CreatedOn,
                @UpdateOn = entity.UpdatedOn
            };

            return this.Connection.Query<IdentityRole>("usp_Roles_Insert", parameters, this.Transaction, 
                true, null, CommandType.StoredProcedure).FirstOrDefault();
        }

        public override IdentityRole Update(IdentityRole entity)
        {
            var parameters = new
            {
                @Id = entity.Id,
                @Name = entity.Name,
                @CreatedOn = entity.CreatedOn,
                @UpdateOn = entity.UpdatedOn
            };

            return this.Connection.Query<IdentityRole>("usp_Roles_Update", parameters, this.Transaction,
                true, null, CommandType.StoredProcedure).FirstOrDefault();
        }

        public byte GetIdByName(string roleName)
        {
            return this.Connection.ExecuteScalar<byte>("usp_Roles_GetIdByName", new { Name = roleName },
                this.Transaction, null, CommandType.StoredProcedure);
        }
    }
}
