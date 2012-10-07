using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;
using System.Web.Mvc;

namespace TIL.Web.Mvc
{
    using TIL.Web.Mvc.Components;
    using TIL.Web.Mvc.ViewModels;

    public abstract class ControllerBase : Controller
    {
        protected ResourceManager ResourceManager { get; private set; }
        protected Flash Flash { get; private set; }

        public ControllerBase(Type resourceType)
        {
            ResourceManager = new ResourceManager(resourceType);
            ResourceManager.IgnoreCase = true;
            Flash = new Flash(this.TempData);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            filterContext.Controller.ViewBag.PageInfo = new MvcPage(this.ResourceManager.ResourceSetType, filterContext.RequestContext);
        }

        protected string GetString(string key)
        {
            return ResourceManager.GetString(key);
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
