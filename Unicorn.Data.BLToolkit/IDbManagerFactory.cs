using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BLToolkit.Data;

namespace Unicorn.Data.BLToolkit
{
    public interface IDbManagerFactory
    {
        DbManager GetDbManager();
    }
}
