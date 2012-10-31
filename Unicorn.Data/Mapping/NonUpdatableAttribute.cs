using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unicorn.Data.Mapping
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class NonUpdatableAttribute : Attribute
    {
    }
}
