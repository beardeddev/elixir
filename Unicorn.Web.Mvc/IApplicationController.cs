using System;
using System.Web.Mvc;

namespace Unicorn.Web.Mvc
{
    using Unicorn.Web.Mvc.Configuration;
    using Unicorn.Data.Contracts;
    
    public interface IApplicationController : IController    
    {
        RouteNames RouteNames { get; }
    }
}
