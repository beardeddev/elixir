using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sophist.Data
{
    public interface IEntity
    {
        dynamic Id { get; set; }
        object ToUrlParams();

        bool IsNew { get; set; }
    }
}
