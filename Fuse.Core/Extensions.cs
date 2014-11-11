using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuse.Common
{
    public static class Extensions
    {
        public static string ExpandMessage(this Exception ex)
        {
            if (ex.InnerException != null)
                return ExpandMessage(ex.InnerException);

            return ex.Message;
        }
    }
}
