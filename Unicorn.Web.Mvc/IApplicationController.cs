using System;
using System.Web.Mvc;
using System.Resources;

namespace Unicorn.Web.Mvc
{
    using Unicorn.Web.Mvc.Configuration;
    using Unicorn.Data.Contracts;
        
    public interface IApplicationController : IController    
    {
        ResourceManager ResourceManager { get; }
        RouteNames RouteNames { get; }
    }
}
