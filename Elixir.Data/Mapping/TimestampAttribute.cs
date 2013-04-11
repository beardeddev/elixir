using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elixir.Data.Mapping
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class TimestampAttribute : Attribute
    {
        public Boolean AutoAddNow { get; set; }
        public Boolean AutoUpdateNow { get; set; }
    }
}
