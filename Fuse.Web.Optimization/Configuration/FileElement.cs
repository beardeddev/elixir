using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Fuse.Web.Optimization.Configuration
{
    public class FileElement : ConfigurationElement
    {
        [ConfigurationProperty("virtualPath")]
        public string VirtualPath
        {
            get
            {
                return (string)this["virtualPath"];
            }
            set
            {
                this["virtualPath"] = value;
            }
        }
    }
}
