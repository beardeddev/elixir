using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Resources;

namespace Sophist.Resources
{
    public interface IResourceManagerFactory
    {
        ResourceManager GetResourceManager();
        ResourceManager GetResourceManager(Type resourceType);
    }
}