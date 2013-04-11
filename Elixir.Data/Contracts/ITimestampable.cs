using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elixir.Data.Contracts
{
    public interface ITimestampable
    {
        DateTime CreatedOn { get; set; }
        DateTime UpdatedOn { get; set; }
    }
}
