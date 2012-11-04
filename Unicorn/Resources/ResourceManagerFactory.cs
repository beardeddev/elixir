using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;

namespace Unicorn.Resources
{
    public class ResourceManagerFactory : IResourceManagerFactory
    {
        private Type resourceSource;

        public ResourceManagerFactory(Type resourceSource)
        {
            this.resourceSource = resourceSource;
        }

        public ResourceManager GetResourceManager()
        {
            return new ResourceManager(resourceSource);
        }

        public ResourceManager GetResourceManager(Type resourceSource)
        {
            return new ResourceManager(resourceSource);
        }
    }
}
