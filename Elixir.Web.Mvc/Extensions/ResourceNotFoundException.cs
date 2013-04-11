using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elixir.Web.Mvc.Extensions
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(string message)
            : base(message)
        {

        }
    }
}
