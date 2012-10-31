using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace Unicorn.Data.Entity
{
    public interface IDbContextFactory
    {
        DbContext GetDbContext();
    }
}
