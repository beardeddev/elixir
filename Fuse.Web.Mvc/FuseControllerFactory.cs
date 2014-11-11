using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Fuse.Web.Mvc;
using RestfulRouting.RouteDebug;

namespace Fuse.Web.Mvc
{
    public class FuseControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            IController controller = base.GetControllerInstance(requestContext, controllerType);
            if (controller is ApplicationController || controller is RouteDebugController)
            {
                return controller;
            }

            throw new NotSupportedException("Controller is child of " + typeof(ApplicationController).FullName);
        }
    }
}