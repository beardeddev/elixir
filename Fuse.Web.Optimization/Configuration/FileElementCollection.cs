using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Fuse.Web.Optimization.Configuration
{
    public class FileElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new FileElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((FileElement)element).VirtualPath;
        }

        protected override string ElementName
        {
            get
            {
                return "include";
            }
        }

        public FileElementCollection()
        {
            AddElementName = "include";
        }
    }
}
