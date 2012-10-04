using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BLToolkit.Data;

namespace TIL.Data.Entity
{
    public class DbManagerFactory : IDbManagerFactory
    {
        private string connectionString;

        public DbManagerFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DbManager GetDbManager()
        {
            return new DbManager(this.connectionString);
        }

    }
}
