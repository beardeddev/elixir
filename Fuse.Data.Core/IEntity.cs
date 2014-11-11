using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuse.Data.Core
{
    public interface IEntity
    {
        dynamic Id { get; set; }

        bool IsNew { get; set; }

        DateTime CreatedOn { get; set; }

        DateTime UpdatedOn { get; set; }
    }
}
