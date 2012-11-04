using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BLToolkit.Data;

namespace Unicorn.Data.BLToolkit
{
    /// <summary>
    /// 
    /// </summary>
    public class DbManagerFactory : IDbManagerFactory
    {
        private readonly DbManager dbManager;

        public DbManagerFactory(DbManager dbManager)
        {
            this.dbManager = dbManager;
        }

        public DbManager GetDbManager()
        {
            return dbManager;
        }
    }
}
