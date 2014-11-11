using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuse.Web.Optimization.Configuration
{
    public class BundleElement : ConfigurationElement
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

        [ConfigurationProperty("files")]
        public FileElementCollection Files
        {
            get
            {
                return (FileElementCollection)base["files"];
            }
            set
            {
                base[string.Empty] = value;
            }
        }
    }
}
