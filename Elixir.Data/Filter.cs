using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elixir.Data
{
    using Elixir.Data.Abstractions;

    public class Filter<T> : FilterBase<T>
        where T : class, new()
    {
    }
}
