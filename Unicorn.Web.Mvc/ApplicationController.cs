using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Resources;

namespace Unicorn.Web.Mvc
{
    using Unicorn.Web.Mvc.Component;
    using Unicorn.Web.Mvc.ViewModels;
    using Unicorn.Resources;

    public class ApplicationController : Controller
    {
        public ResourceManager ResourceManager { get; private set; }
        public dynamic Flash { get; private set; }

        public ApplicationController(IResourceManagerFactory resourceFactory)
        {
            this.ResourceManager = resourceFactory.GetResourceManager();
            this.ResourceManager.IgnoreCase = true;
            this.Flash = new Flash(this.TempData);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            filterContext.Controller.ViewBag.PageContext = new RequestPageInfo(this.ResourceManager, filterContext.RequestContext);
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
