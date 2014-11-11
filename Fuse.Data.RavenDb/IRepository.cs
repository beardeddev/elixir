using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuse.Data.RavenDb
{
    public interface IRepository<T> : IRepository<T, int>
        where T : Document
    {
    }
}
