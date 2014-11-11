using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuse.Data.Core
{
    public interface IEntity<TKey> : IEntity
    {
        new TKey Id { get; set; }
    }
}
