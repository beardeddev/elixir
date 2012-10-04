using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace TIL.Data.Entity
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly DbContext context;

        public DbContextFactory(DbContext context)
        {
            this.context = context;
        }

        public DbContext GetDbContext()
        {
            return context;
        }
    }
}
