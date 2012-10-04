using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BLToolkit.Data;

namespace TIL.Data.Entity
{
    public interface IDbManagerFactory
    {
        DbManager GetDbManager();
    }
}
