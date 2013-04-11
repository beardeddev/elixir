using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;

namespace Elixir.Web.Mvc.Factories
{
    public interface IResourceManagerFactory
    {
        ResourceManager GetResourceManager();
        ResourceManager GetResourceManager(Type resourceType);
    }
}
