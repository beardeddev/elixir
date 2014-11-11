using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuse.Web.Optimization.Configuration
{
    public class BundleSection : ConfigurationSection
    {
        [ConfigurationProperty("scripts", IsRequired = true)]
        public BundleElementCollection Scripts
        {
            get
            {
                return (BundleElementCollection)base["scripts"];
            }
            set
            {
                base["scripts"] = value;
            }
        }

        [ConfigurationProperty("styles", IsRequired = true)]
        public BundleElementCollection Styles
        {
            get
            {
                return (BundleElementCollection)base["styles"];
            }
            set
            {
                base["styles"] = value;
            }
        }
    }
}
