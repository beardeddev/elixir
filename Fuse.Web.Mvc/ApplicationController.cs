using Fuse.Resources;
using Microsoft.Owin;
using MvcFlash.Core;
using RestfulRouting;
using RestfulRouting.Format;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Fuse.Web.Mvc
{
    public abstract class ApplicationController : Controller
    {
        protected virtual IFlashPusher Flash { get; private set; }

        public RouteNames RouteNames { get; private set; }

        protected dynamic Messages { get; private set; }
        
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            this.Messages = new DynamicResourceDictionary(requestContext.HttpContext, "Messages");
            this.RouteNames = Request.GetRouteNames();
            this.Flash = MvcFlash.Core.Flash.Instance;
        }

        protected ActionResult RespondTo(Action<FormatCollection> format)
        {
            return new FormatResult(format);
        }

        protected virtual ActionResult ObjectOr404(object entity)
        {
            return ObjectOr404(null, entity);
        }

        protected virtual ActionResult ObjectOr404(string viewName, object entity)
        {
            if (entity == null)
            {
                return new HttpNotFoundResult();
            }
            else
            {
                return View(viewName, entity);
            }
        }
    }
}