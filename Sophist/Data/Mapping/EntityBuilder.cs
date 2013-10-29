using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sophist.Data.Mapping
{
    public class EntityBuilder
    {
        protected ConcurrentDictionary<Type, IEntityMap> Mappings { get; private set; }

        public EntityBuilder()
        {
            this.Mappings = new ConcurrentDictionary<Type, IEntityMap>();
        }
    }
}
