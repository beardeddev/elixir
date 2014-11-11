using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuse.Web.Optimization.Configuration
{
    public class BundleElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new BundleElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((BundleElement)element).VirtualPath;
        }

        protected override string ElementName
        {
            get
            {
                return "bundle";
            }
        }

        public BundleElementCollection()
        {
            AddElementName = "bundle";
        }
    }
}
