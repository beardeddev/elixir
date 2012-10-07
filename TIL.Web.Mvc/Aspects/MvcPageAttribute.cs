using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace TIL.Web.Mvc.Aspects
{
    using TIL.Web.Mvc.ViewModels;

    public class MvcPageAttribute : ActionFilterAttribute
    {
        private Type resourceType;

        public MvcPageAttribute(Type resourceType)
        {
            this.resourceType = resourceType;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            filterContext.Controller.ViewBag.PageInfo = new MvcPage(resourceType, filterContext.RequestContext);
        }
    }
}
