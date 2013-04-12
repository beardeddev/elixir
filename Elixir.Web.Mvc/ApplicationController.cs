using System;
using System.Web.Mvc;
using RestfulRouting.Format;
using System.Resources;

using RestfulRouting;

namespace Elixir.Web.Mvc
{
    using Elixir.Web.Mvc.Factories;
    using Elixir.Web.Mvc.Components;

    public abstract class ApplicationController : Controller
    {
        protected Flash Flash { get; private set; }

        public RouteNames RouteNames { get; private set; }
        
        public ResourceManager ResourceManager { get; set; }

        public ApplicationController(IResourceManagerFactory factory)
        {
            this.ResourceManager = factory.GetResourceManager();
            this.RouteNames = new RouteNames();
            this.Flash = new Flash(this.TempData);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
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