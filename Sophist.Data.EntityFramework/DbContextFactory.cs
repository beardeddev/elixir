using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sophist.Data.EntityFramework
{
    public class DbContextFactory : IDbContextFactory
    {
        public DbContext DbContext { get; private set; }

        public DbContextFactory(DbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public DbContext GetDbContext()
        {
            return this.DbContext;
        }
    }
}
